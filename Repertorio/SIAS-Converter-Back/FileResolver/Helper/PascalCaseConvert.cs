using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Formatting;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.FindSymbols;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.IO;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;

namespace FileResolver.Helper;

public class SolutionProcessor
{
    private Workspace _workspace;
    private Solution _modifiableSolution;
    private readonly string _solutionPath;

    public SolutionProcessor(string solutionPath)
    {
        _solutionPath = solutionPath;
        //_workspace = GetProjectsFromSolution(solutionPath);
    }

    //async Task LoadProject()
    //{
    //    using var msbuildWorkspace = MSBuildWorkspace.Create();
    //    var originalSolution = await msbuildWorkspace.OpenSolutionAsync(_solutionPath);

    //    // Criação manual de SolutionInfo com loops for
    //    var projects = new List<ProjectInfo>();
    //    foreach (var project in originalSolution.Projects)
    //    {
    //        var documents = new List<DocumentInfo>();
    //        foreach (var doc in project.Documents)
    //        {
    //            var documentInfo = DocumentInfo.Create(
    //                doc.Id,
    //                doc.Name,
    //                filePath: doc.FilePath,
    //                sourceCodeKind: doc.SourceCodeKind,
    //                loader: TextLoader.From(TextAndVersion.Create(await doc.GetTextAsync(), VersionStamp.Create(), doc.FilePath))
    //            );
    //            documents.Add(documentInfo);
    //        }

    //        var projectInfo = ProjectInfo.Create(
    //            project.Id,
    //            project.Version,
    //            project.Name,
    //            project.AssemblyName,
    //            project.Language,
    //            project.FilePath,
    //            project.OutputFilePath,
    //            project.CompilationOptions,
    //            project.ParseOptions,
    //            documents
    //        );

    //        projects.Add(projectInfo);
    //    }

    //    // Criação do SolutionInfo usando a lista de projetos
    //    var solutionInfo = SolutionInfo.Create(
    //        originalSolution.Id,
    //        originalSolution.Version,
    //        originalSolution.FilePath,
    //        projects
    //    );

    //    // Adiciona a Solution ao AdhocWorkspace para permitir modificações
    //    _workspace = new AdhocWorkspace();
    //    _modifiableSolution = _workspace.AddSolution(solutionInfo);

    //    //Thread.Sleep(2000);
    //    // Carrega a solução do caminho especificado
    //    //var solution = await _workspace.OpenSolutionAsync(_solutionPath);
    //    Console.WriteLine($"Solução carregada: {_modifiableSolution.FilePath}");
    //}

    int counter = 1;
    public async Task RenameSolutionSymbolsAsync()
    {
        using var workspace = MSBuildWorkspace.Create();
        workspace.WorkspaceFailed += (s, e) => Console.WriteLine(e.Diagnostic.Message);

        // Carrega a solução do caminho especificado
        var solution = await workspace.OpenSolutionAsync(_solutionPath);
        //Console.WriteLine($"Solução carregada: {Path.GetFileName(solution.FilePath)}");

        var updatedSolution = solution;
        var renamedSymbols = new HashSet<ISymbol>(); // Armazena símbolos já renomeados para evitar duplicação
        //var newsolution = solution;

        for (int p = 0; p < solution.Projects.Count(); p++)
        {
            var project = solution.Projects.ElementAt(p);
            for (int d = 0; d < project.Documents.Count(); d++)
            {
                var document = project.Documents.ElementAt(d);

                if (NeedsRenaming(Path.GetFileNameWithoutExtension(document.Name)))
                {
                    var newDocName = ConvertToPascalCase(document.Name);

                    File.Move(document.FilePath, Path.Combine(Path.GetDirectoryName(document.FilePath), newDocName)); 
                    
                    Console.WriteLine($"{counter++.ToString().PadLeft(4, '0')} - alterando nome do arquivo de {document.Name} para {newDocName} - assumindo novo workspace");
                    await RenameSolutionSymbolsAsync();
                    return;
                }

                var semanticModel = await document.GetSemanticModelAsync();
                var root = await document.GetSyntaxRootAsync();
                if (root == null || semanticModel == null) continue;

                var symbolsToRename = root.DescendantNodes()
                .Where(node =>
                {
                    return node is VariableDeclaratorSyntax ||   // Variáveis
                    node is MethodDeclarationSyntax ||     // Métodos
                    node is ParameterSyntax ||             // Parâmetros
                    node is PropertyDeclarationSyntax ||    // Propriedades
                    node is IdentifierNameSyntax ||         // Identificadores
                    node is ClassDeclarationSyntax;

                })         // Classes
                .Select(node => semanticModel.GetDeclaredSymbol(node))
                .Where(symbol => symbol != null && NeedsRenaming(symbol.Name))
                .ToList();

                //mustToDoAgain
                // Renomeia classes para PascalCase
                foreach (var symbol in symbolsToRename)
                {
                    var currentName = symbol.Name;
                    //enterWhile = true;

                    var newName = ConvertToPascalCase(currentName);

                    if (currentName != newName)
                    {
                        // Renomeia e atualiza a solução
                        try
                        {
                            //funciona
                            solution = await Renamer.RenameSymbolAsync(solution, symbol, newName, workspace.Options);
                        }
                        catch (Exception)
                        {
                            if (workspace.TryApplyChanges(solution))
                            {
                                Console.WriteLine($"{counter++.ToString().PadLeft(4, '0')} - erro Renomeada de {currentName} para {newName} - assumindo novo workspace");
                                await RenameSolutionSymbolsAsync();
                                return;
                            }
                            else
                            {
                                //Console.WriteLine($"Falha ao aplicar mudanças no workspace. {currentName} para {newName}");
                            }
                        }

                        //// Reaplica a solução atualizada ao workspace
                        //if (workspace.TryApplyChanges(solution))
                        //{
                        //    Console.WriteLine($"{counter++.ToString().PadLeft(4, '0')} - Renomeada de {currentName} para {newName}");
                        //    //await RenameSolutionSymbolsAsync();
                        //    //return;
                        //}
                        //else
                        //{
                        //    Console.WriteLine($"Falha ao aplicar mudanças no workspace. {currentName} para {newName}");
                        //}
                    }
                }

                if (symbolsToRename.Count == 0)
                {
                    Console.WriteLine($"{counter++.ToString().PadLeft(4, '0')} - Sem simbolos para conversão {document.Name}...");
                    continue;
                }

                if (workspace.TryApplyChanges(solution))
                {
                    Console.WriteLine($"{counter++.ToString().PadLeft(4, '0')} - renomeação do arquivo {document.Name} sucesso");
                    await RenameSolutionSymbolsAsync();
                    return;
                    //await RenameSolutionSymbolsAsync();
                    //return;
                }
                else
                {
                    //Console.WriteLine($"Falha ao aplicar mudanças no workspace. {currentName} para {newName}");
                }
                //} //while
                //updatedSolution = await RenameSymbolsAsync(updatedSolution, semanticModel, classDeclarations, renamedSymbols, ConvertToPascalCase);

                //// Renomeia variáveis para camelCase
                //var variableDeclarations = root.DescendantNodes().OfType<VariableDeclaratorSyntax>();
                //updatedSolution = await RenameSymbolsAsync(updatedSolution, semanticModel, variableDeclarations, renamedSymbols, ConvertToCamelCase);
            }
        }
    }

    private static async Task<Solution> RenameSymbolsAsync<T>(
        Solution solution,
        SemanticModel semanticModel,
        IEnumerable<T> declarations,
        HashSet<ISymbol> renamedSymbols,
        Func<string, string> namingConvention)
        where T : SyntaxNode
    {
        foreach (var declaration in declarations)
        {
            var symbol = semanticModel.GetDeclaredSymbol(declaration);
            if (symbol == null || renamedSymbols.Contains(symbol)) continue;

            var newName = namingConvention(symbol.Name);
            if (newName != symbol.Name)
            {
                solution = await Renamer.RenameSymbolAsync(solution, symbol, newName, solution.Workspace.Options);
                renamedSymbols.Add(symbol); // Marca o símbolo como renomeado
            }
        }

        return solution;
    }






















    public async Task ProcessSolutionAsync(string solutionPath)
    {
        await RenameInternalsAsync(solutionPath);
    }

    private IEnumerable<string> GetCSharpFilesFromSolution(string solutionPath)
    {
        var jumpProjLst = new List<string>
        {
            $"IA_ConverterCommons.csproj",
        };
        var solutionDir = Path.GetDirectoryName(solutionPath);

        // Encontra todos os arquivos `.csproj` na solução
        var csprojFiles = Directory.GetFiles(solutionDir, "*.csproj", SearchOption.AllDirectories);

        var csFiles = new List<string>();

        // Para cada projeto `.csproj`, encontra os arquivos `.cs`
        foreach (var csprojFile in csprojFiles)
        {
            if (jumpProjLst.Any(csprojFile.Contains)) continue;

            var projectDir = Path.GetDirectoryName(csprojFile);
            var projectFiles = Directory.GetFiles(projectDir, "*.cs", SearchOption.AllDirectories).ToList();
            projectFiles = projectFiles.Where(x => !x.Contains("\\obj\\")).ToList();
            csFiles.AddRange(projectFiles);
        }

        return csFiles;
    }


    public async Task RenameInternalsAsync(string solutionPath)
    {
        var workspace = GetProjectsFromSolution(solutionPath);
        var files = GetCSharpFilesFromSolution(solutionPath);

        foreach (var project in workspace.CurrentSolution.Projects)
            foreach (var document in project.Documents)
                await RenameSymbolsInCodeAsync(document.Id, project, workspace);

        //foreach (var project in workspace.CurrentSolution.Projects)
        //    foreach (var document in project.Documents)
        //    {
        //        var file = files.FirstOrDefault(x => Path.GetFileName(x) == document.Name);
        //        var fileName = Path.GetFileName(file);
        //        var newFileName = "";

        //        if (NeedsRenaming(Path.GetFileNameWithoutExtension(fileName)))
        //            newFileName = ConvertToPascalCase(fileName);

        //        //var code = await RenameSymbolsInCodeAsync(document.Id, project, workspace);

        //        // Salva o código atualizado no mesmo arquivo
        //        if (File.Exists(file)) File.Delete(file);
        //        var fileNameToSave = string.IsNullOrWhiteSpace(newFileName) ? fileName : newFileName;
        //        var folder = Path.GetDirectoryName(file);

        //        File.WriteAllText(Path.Combine(folder, fileNameToSave), (await document.GetSyntaxRootAsync()).ToFullString());
        //    }
    }

    public async Task RenameSymbolsAndFilesAsync()
    {
        var solution = _workspace.CurrentSolution;

        foreach (var project in solution.Projects)
        {
            foreach (var document in project.Documents)
            {
                var root = await document.GetSyntaxRootAsync();
                var semanticModel = await document.GetSemanticModelAsync();

                // Encontra todas as declarações de classe e variáveis
                var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                var variableDeclarations = root.DescendantNodes().OfType<VariableDeclaratorSyntax>();
                var propDeclarations = root.DescendantNodes().OfType<PropertyDeclarationSyntax>();

                var symbolsToRename = root.DescendantNodes()
                    .Where(node =>
                    {
                        return node is VariableDeclaratorSyntax ||   // Variáveis
                        node is MethodDeclarationSyntax ||     // Métodos
                        node is ParameterSyntax ||             // Parâmetros
                        node is PropertyDeclarationSyntax     // Propriedades
                        || node is IdentifierNameSyntax          // Identificadores
                                                                 //|| node is ClassDeclarationSyntax
                        ;

                    })         // Classes
                    .Select(node => semanticModel.GetDeclaredSymbol(node))
                    .Where(symbol => symbol != null && NeedsRenaming(symbol.Name))
                    .ToList();

                // Renomeia classes e arquivos associados
                foreach (var classDecl in classDeclarations)
                {
                    var className = classDecl.Identifier.Text;
                    var newName = ConvertToPascalCase(className);

                    if (newName != className)
                    {
                        var symbol = semanticModel.GetDeclaredSymbol(classDecl);
                        solution = await Renamer.RenameSymbolAsync(solution, symbol, newName, _workspace.Options);

                        _workspace.TryApplyChanges(solution);

                        // Renomeia o arquivo se o nome do arquivo atual for igual ao da classe
                        var filePath = document.FilePath;
                        var newFilePath = Path.Combine(Path.GetDirectoryName(filePath), $"{newName}.cs");
                        File.Move(filePath, newFilePath);
                    }
                }

                // Renomeia variáveis e suas referências
                foreach (var variableDecl in variableDeclarations)
                {
                    var variableName = variableDecl.Identifier.Text;
                    var newName = ConvertToCamelCase(variableName);

                    if (newName != variableName)
                    {
                        var symbol = semanticModel.GetDeclaredSymbol(variableDecl);
                        solution = await Renamer.RenameSymbolAsync(solution, symbol, newName, _workspace.Options);

                        _workspace.TryApplyChanges(solution);
                    }
                }

                // Renomeia variáveis e suas referências
                foreach (var prop in propDeclarations)
                {
                    var variableName = prop.Identifier.Text;
                    var newName = ConvertToCamelCase(variableName);

                    if (newName != variableName)
                    {
                        var symbol = semanticModel.GetDeclaredSymbol(prop);
                        solution = await Renamer.RenameSymbolAsync(solution, symbol, newName, _workspace.Options);

                        _workspace.TryApplyChanges(solution);
                    }
                }
            }
        }

        // Aplica as mudanças
        _workspace.TryApplyChanges(solution);
    }







    void RenameFile(string filePath, string newName, string code)
    {
        var fileName = Path.GetFileName(filePath);
        var newFileName = newName;

        if (NeedsRenaming(Path.GetFileNameWithoutExtension(fileName)))
            newFileName = ConvertToPascalCase(fileName);

        var fileNameToSave = string.IsNullOrWhiteSpace(newFileName) ? fileName : newFileName;
        var folder = Path.GetDirectoryName(filePath);

        File.WriteAllText(Path.Combine(folder, fileNameToSave), code);
    }

    private AdhocWorkspace GetProjectsFromSolution(string solutionPath)
    {
        var jumpProjLst = new List<string>
        {
            $"IA_ConverterCommons.csproj",
        };

        var workspace = new AdhocWorkspace();
        var solutionDir = Path.GetDirectoryName(solutionPath);

        // Encontra todos os arquivos `.csproj` na solução
        var csprojFiles = Directory.GetFiles(solutionDir, "*.csproj", SearchOption.AllDirectories);

        //adiciona projetos no worksapce
        foreach (var csProj in csprojFiles)
            if (jumpProjLst.Any(csProj.Contains)) continue;
            else
            {

                var projectDir = Path.GetDirectoryName(csProj);
                var projectFiles = Directory.GetFiles(projectDir, "*.cs", SearchOption.AllDirectories).ToList();
                projectFiles = projectFiles.Where(x => !x.Contains("\\obj\\")).ToList();

                if (projectFiles.Any())
                {
                    var project = workspace.AddProject(Path.GetFileName(csProj), LanguageNames.CSharp);
                    foreach (var projFile in projectFiles)
                    {
                        var code = File.ReadAllText(projFile);
                        var sourceText = SourceText.From(code);
                        var docInfo = DocumentInfo.Create(DocumentId.CreateNewId(project.Id), Path.GetFileName(projFile), filePath: projFile, sourceCodeKind: SourceCodeKind.Regular, loader: TextLoader.From(sourceText.Container, VersionStamp.Create(DateTime.UtcNow)));

                        workspace.AddDocument(docInfo);
                    }
                }
            }

        return workspace;
    }

    public async Task<string> RenameSymbolsInCodeAsync(DocumentId docId, Project project, AdhocWorkspace workspace)
    {
        //// Busca todas as declarações de classes para renomeá-las
        //var classDeclarations = root.DescendantNodes().OfType<PropertyDeclarationSyntax>();

        //foreach (var classDeclaration in classDeclarations)
        //{
        //    try
        //    {
        //        var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) as IPropertySymbol;
        //        if (classSymbol != null && NeedsRenaming(classSymbol.Type.Name))
        //        {
        //            var newName = ConvertToPascalCase(classSymbol.Type.Name);

        //            // Renomeia o símbolo da classe e suas referências no Solution
        //            var updatedSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, classSymbol.Type, newName, document.Project.Solution.Workspace.Options);

        //            // Propaga a solução atualizada para o workspace
        //            document.Project.Solution.Workspace.TryApplyChanges(updatedSolution);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        List<ISymbol?> symbolsToRename = null;
        string code = "";
        async Task UpdateSymbols()
        {
            var doc = workspace.CurrentSolution.GetDocument(docId);
            var root = await doc.GetSyntaxRootAsync();
            code = root.ToFullString();
            var semanticModel = await doc.GetSemanticModelAsync();

            symbolsToRename = root.DescendantNodes()
                .Where(node =>
                {
                    return node is VariableDeclaratorSyntax ||   // Variáveis
                    node is MethodDeclarationSyntax ||     // Métodos
                    node is ParameterSyntax ||             // Parâmetros
                    node is PropertyDeclarationSyntax ||    // Propriedades
                    node is IdentifierNameSyntax ||         // Identificadores
                    node is ClassDeclarationSyntax;

                })         // Classes
                .Select(node => semanticModel.GetDeclaredSymbol(node))
                .Where(symbol => symbol != null && NeedsRenaming(symbol.Name))
                .ToList();
        }

        await UpdateSymbols();

        var allsymbols = symbolsToRename.Count;
        if (allsymbols == 0)
            return code;

        var symbol = symbolsToRename[0];
        while (allsymbols > 0)
        {
            var newName = symbol.Kind == SymbolKind.Parameter
                ? ConvertToCamelCase(symbol.Name)  // camelCase para parâmetros
                : ConvertToPascalCase(symbol.Name); // PascalCase para classes, variáveis e métodos

            //Realiza a renomeação e obtém a Solution atualizada
            var updatedSolution = await Renamer.RenameSymbolAsync(
                workspace.CurrentSolution,
                symbol,
                new SymbolRenameOptions(true, false, false, true),
                newName
            );

            var references = await SymbolFinder.FindReferencesAsync(symbol, workspace.CurrentSolution);
            foreach (var reference in references)
            {
                foreach (var location in reference.Locations)
                {
                    try
                    {
                        // Acessar o documento onde a referência foi encontrada
                        var refDocument = workspace.CurrentSolution.GetDocument(location.Document.Id);

                        // Alterar o nome em cada local de referência para o novo padrão PascalCase
                        var refRoot = await refDocument.GetSyntaxRootAsync();
                        var refNode = refRoot.FindNode(location.Location.SourceSpan);

                        dynamic syntax = SyntaxFactory.IdentifierName(newName);
                        if (refNode is ConstructorDeclarationSyntax)
                            syntax = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("void"), newName);

                        //if (refNode is ArgumentSyntax)
                        //    syntax = SyntaxFactory.Argument(SyntaxFactory.ParseTypeName("void"), newName);

                        // Realiza a renomeação da referência
                        var updatedRoot = refRoot.ReplaceNode(refNode, (SyntaxNode)syntax);
                        var updat = workspace.TryApplyChanges(workspace.CurrentSolution.WithDocumentSyntaxRoot(refDocument.Id, updatedRoot));
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            var updated = workspace.TryApplyChanges(updatedSolution);
            if (!updated)
            {
                var updat = workspace.TryApplyChanges(updatedSolution);
            }
            await UpdateSymbols();
            allsymbols = symbolsToRename.Count;
            if (allsymbols == 0) break;

            symbol = symbolsToRename[0];
        }
        /*
        var symbol = symbolsToRename[0];
        while (allsymbols > 0)
        {
            var newName = symbol.Kind == SymbolKind.Parameter
                ? ConvertToCamelCase(symbol.Name)  // camelCase para parâmetros
                : ConvertToPascalCase(symbol.Name); // PascalCase para classes, variáveis e métodos

            // Realiza a renomeação e obtém a Solution atualizada
            var updatedSolution = await Renamer.RenameSymbolAsync(
                workspace.CurrentSolution,
                symbol,
                new SymbolRenameOptions(true, false, true, true),
                newName
            );


            //if (symbol is ClassDeclarationSyntax)
            //{
            // Encontrar todas as referências da classe e renomear para cada uma
            var references = await SymbolFinder.FindReferencesAsync(symbol, workspace.CurrentSolution);
            foreach (var reference in references)
            {
                foreach (var location in reference.Locations)
                {
                    // Acessar o documento onde a referência foi encontrada
                    var refDocument = workspace.CurrentSolution.GetDocument(location.Document.Id);

                    // Alterar o nome em cada local de referência para o novo padrão PascalCase
                    var refRoot = await refDocument.GetSyntaxRootAsync();
                    var refNode = refRoot.FindNode(location.Location.SourceSpan);

                    // Realiza a renomeação da referência
                    var updatedRoot = refRoot.ReplaceNode(refNode, SyntaxFactory.IdentifierName(newName));
                    var updated = workspace.TryApplyChanges(workspace.CurrentSolution.WithDocumentSyntaxRoot(refDocument.Id, updatedRoot));
                }
            }
            //}

            // Atualiza o documento para refletir a solução renomeada
            document = updatedSolution.GetDocument(document.Id);

            // Atualiza o root e o semanticModel para o novo documento
            root = await document.GetSyntaxRootAsync();
            semanticModel = await document.GetSemanticModelAsync();

            symbolsToRename = root.DescendantNodes()
                .Where(node =>
                {
                    return node is VariableDeclaratorSyntax ||   // Variáveis
                    node is MethodDeclarationSyntax ||     // Métodos
                    node is ParameterSyntax ||             // Parâmetros
                    node is PropertyDeclarationSyntax ||    // Propriedades
                    node is IdentifierNameSyntax ||         // Identificadores
                    node is ClassDeclarationSyntax;
                }
                    )         // Classes
                .Select(node => semanticModel.GetDeclaredSymbol(node))
                .Where(symbol => symbol != null && NeedsRenaming(symbol.Name))
                .ToList();

            allsymbols = symbolsToRename.Count;
            if (allsymbols == 0) break;

            symbol = symbolsToRename[0];
        }
        */

        // Formata o documento atualizado e retorna o código formatado
        var cdt = await Formatter.FormatAsync(workspace.CurrentSolution.GetDocument(docId));
        return (await cdt.GetSyntaxRootAsync()).ToFullString();
    }

    private bool NeedsRenaming(string name)
    {
        return (name.Contains("_") && name == name.ToUpper()) || name == name.ToUpper();
    }

    private string ConvertToPascalCase(string name)
    {
        var words = name.ToLower().Split('_');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
        }
        return string.Join("", words);
    }

    private string ConvertToCamelCase(string name)
    {
        var pascalCaseName = ConvertToPascalCase(name);
        return char.ToLower(pascalCaseName[0]) + pascalCaseName.Substring(1);
    }
}
