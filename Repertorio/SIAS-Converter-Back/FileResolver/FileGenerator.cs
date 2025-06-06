using DocumentFormat.OpenXml.Presentation;
using FileResolver.Helper;
using FileResolver.Model;
using FileTests.Test;
using IA_ConverterCommons;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace FileResolver;

public class FileGenerator
{
    //public static Dictionary<string, List<string>> programsToRefferNamespace = new Dictionary<string, List<string>>();
    public static bool HasCopyFolder { get; set; }
    public static bool HasDclFolder { get; set; }
    public void ClearInputFiles()
    {
        var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
        var copyProjecName = FileResolverHelper.Conf.ProjectCopyName;
        var dclProjecName = FileResolverHelper.Conf.ProjectDclName;
        var cobolProjecName = FileResolverHelper.Conf.ProjectCobolName;
        var solutionName = FileResolverHelper.Conf.SolutionName;

        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, solutionName, copyProjecName), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, solutionName, dclProjecName), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, solutionName, "IA_ConverterCommons"), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, solutionName, cobolProjecName), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, solutionName), true); } catch (Exception) { }

        RemoveConvertedFiles();
    }

    public void RemoveConvertedFiles()
    {
        var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
        var copyProjecName = FileResolverHelper.Conf.ProjectCopyName;
        var dclProjecName = FileResolverHelper.Conf.ProjectDclName;
        var cobolProjecName = FileResolverHelper.Conf.ProjectCobolName;

        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, copyProjecName), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, dclProjecName), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, cobolProjecName), true); } catch (Exception) { }
        try { Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), sourceFolderPath, "IA_ConverterCommons"), true); } catch (Exception) { }
    }

    public void CreateSolutionForGeneratedCode(List<MethodReferenceInfo> apiMethodsReference)
    {
        try
        {
            var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
            var copyProjecName = FileResolverHelper.Conf.ProjectCopyName;
            var dclProjecName = FileResolverHelper.Conf.ProjectDclName;
            var cobolProjecName = FileResolverHelper.Conf.ProjectCobolName;
            var testProjecName = FileResolverHelper.Conf.ProjectTestName;
            var solutionName = FileResolverHelper.Conf.SolutionName;


            //Copy
            GenerateProjectFiles(solutionName, copyProjecName, sourceFolderPath);

            //Dcl
            GenerateProjectFiles(solutionName, dclProjecName, sourceFolderPath);

            PushCommonsToOutputFolder(solutionName, sourceFolderPath);

            if (FileResolverHelper.Conf.AddTestProject)
                PushTestProgramToDestination(solutionName, sourceFolderPath);

            //Generate Test Project
            if (FileResolverHelper.Conf.GenerateTestProject)
                GenerateProjectFiles(solutionName, testProjecName, sourceFolderPath);

            foreach (var module in FileResolverHelper.Conf.InputConfig.ListModuleConsider)
            {
                //Cobol
                GenerateModuleProjectFiles(solutionName, module, sourceFolderPath);

                //DB2
                MoveDB2ModuleFolder(module);
            }

            // Criação da solução (.sln)
            CreateSolutionFile(solutionName, copyProjecName, dclProjecName);

            Console.WriteLine($"Solução gerada em: {solutionName}");

            //Properties
            MovePropertiesFolder();

            if (FileResolverHelper.Conf.GenerateApiProject)
                CreateApiForReferencesMethods(apiMethodsReference);

            if (FileResolverHelper.Conf.RenamePascalCase)
                ConvertNamesToPascalCase();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar o projeto ou a solução: {ex.Message}");
        }
    }


    public static void ConvertNamesToPascalCase()
    {
        var solutionPath = Path.Combine(FileResolverHelper.GetOutputPathCombined(Path.Combine(FileResolverHelper.Conf.SolutionName)), $"{FileResolverHelper.Conf.SolutionName}.sln");
        var solutionConverter = new SolutionProcessor(solutionPath);

        //solutionConverter.ProcessSolutionAsync(solutionPath).Wait();
        //solutionConverter.RenameSymbolsAndFilesAsync().Wait();
        solutionConverter.RenameSolutionSymbolsAsync().Wait();
    }

    static bool IsUsingDirectiveNecessary(UsingDirectiveSyntax usingDirective, SemanticModel semanticModel)
    {
        // Verificar se o `using` é necessário analisando o semantic model
        var namespaceSymbol = semanticModel.GetSymbolInfo(usingDirective.Name).Symbol as INamespaceSymbol;
        if (namespaceSymbol == null)
        {
            return true; // Não é possível determinar se o using é necessário, mantê-lo por segurança
        }

        var namespaceName = namespaceSymbol.ToDisplayString();
        var nodes = usingDirective.Parent.DescendantNodes()
            .Where(n => !(n is UsingDirectiveSyntax) && semanticModel.GetSymbolInfo(n).Symbol != null);

        return nodes.Any(n => semanticModel.GetSymbolInfo(n).Symbol?.ContainingNamespace?.ToDisplayString() == namespaceName);
    }




    public void PushClassToDb2Folder(string className, string classCode, string programName)
    {
        var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
        var cobolProjectName = FileResolverHelper.Conf.ProjectCobolName;
        var path = Path.Combine(sourceFolderPath, cobolProjectName, "DB2", programName);
        var fullPath = Path.Combine(path, className + ".cs");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        try { if (File.Exists(fullPath)) throw new Exception("Arquivo já existe, deve conter outro nome"); } catch { }

        File.WriteAllText(fullPath, classCode);
    }

    void PushTestProgramToDestination(string solutionName, string sourceFolderPath)
    {
        var fullPath = Directory.GetCurrentDirectory();
        fullPath = Directory.GetParent(fullPath).FullName;
        fullPath = Directory.GetParent(fullPath).FullName;
        fullPath = Directory.GetParent(fullPath).FullName;
        fullPath = Directory.GetParent(fullPath).FullName;
        fullPath = Path.Combine(fullPath, "Converter.Test");
        var files = Directory.GetFiles(fullPath, "*").ToList();
        files.AddRange(Directory.GetFiles(fullPath, "*.csproj").ToList());

        foreach (string file in files)
        {
            var destFile = Path.Combine(sourceFolderPath, solutionName, "Converter.Test", Path.GetFileName(file));
            Directory.CreateDirectory(Directory.GetParent(destFile).FullName);
            File.Copy(file, destFile, true);
        }
    }

    void PushCommonsToOutputFolder(string solutionName, string sourceFolderPath)
    {
        var projectName = "IA_ConverterCommons";

        var csFiles = Directory.GetFiles(projectName, "*").ToList();
        foreach (var pathInner in Directory.GetDirectories(Path.Combine(projectName)))
        {
            var innerFiles = Directory.GetFiles(pathInner, "*");
            if (innerFiles?.Any() == true)
                csFiles.AddRange(innerFiles);
        }

        foreach (string file in csFiles)
        {
            var currentFileName = Path.GetFileName(file);

            if (FileResolverHelper.Conf.ConvertToSqlServer)
            {
                if (currentFileName.Contains("DatabaseConnection_DB2"))
                    continue;
            }
            else
                if (currentFileName.Contains("DatabaseConnection_SQL"))
                continue;

            var considerProjectName = projectName;
            //if (FileResolverHelper.Conf.GenerateAtSingleProject)
            //    considerProjectName = Path.Combine(FileResolverHelper.Conf.ProjectCobolName, projectName);

            var currentFileOutputFullPath = Path.Combine(FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, file)));

            File.Copy(file, currentFileOutputFullPath, true);
            //content.AppendLine($"    <Compile Include=\"{Path.Combine(projectName, currentFileName)}\" />");
        }

        GenerateProjectFiles(solutionName, "IA_ConverterCommons", sourceFolderPath, false);
    }

    void GenerateModuleProjectFiles(string solutionName, InputConfigModules module, string sourceFolderPath, bool format = true)
    {
        Directory.CreateDirectory(Path.Combine(sourceFolderPath, module.Name));

        CreateModuleProjectFile(solutionName, module, sourceFolderPath);

        GenerateLaunchSettings(solutionName, module, sourceFolderPath);

        if (format)
        {
            isAlreadAddedModule = false;
            FormatProject(solutionName, module.Name, sourceFolderPath, module);
        }
    }
    void CreateModuleProjectFile(string solutionName, InputConfigModules module, string sourceFolderPath)
    {
        var content = new StringBuilder();

        if (FileResolverHelper.Conf.GenerateApiProject)
            content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Web\">");
        else
            content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");

        content.AppendLine("  <PropertyGroup>");

        if (!FileResolverHelper.Conf.GenerateApiProject)
            content.AppendLine("    <OutputType>Library</OutputType>");

        content.AppendLine("    <TargetFramework>net8.0</TargetFramework>");
        content.AppendLine("    <PlatformTarget>x64</PlatformTarget>");
        content.AppendLine("  </PropertyGroup>");

        if (!FileResolverHelper.Conf.ConvertToSqlServer)
        {
            content.AppendLine("  <PropertyGroup>");
            content.AppendLine("    <DefineConstants>$(DefineConstants);DB2</DefineConstants>");
            content.AppendLine("  </PropertyGroup>");
        }

        content.AppendLine("  <ItemGroup>");
        content.AppendLine(@"    <PackageReference Include=""MethodDecorator.Fody"" Version=""1.1.1"" />");
        content.AppendLine("  </ItemGroup>");


        if (FileResolverHelper.Conf.GenerateApiProject)
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine("  <PackageReference Include=\"Microsoft.AspNetCore.Mvc.Core\" Version=\"2.2.5\" />");
            content.AppendLine("  <PackageReference Include=\"Swashbuckle.AspNetCore\" Version=\"6.6.2\" />");
            content.AppendLine("  <PackageReference Include=\"System.Text.Encoding.CodePages\" Version=\"9.0.1\" />");
            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
            content.AppendLine("  <Target Name=\"CopyToSharedFolder\" AfterTargets=\"Build\">");
            content.AppendLine("    <Copy SourceFiles=\"$(TargetDir)$(TargetName).dll\" DestinationFolder=\"..\\SharedLibs\\\" />");
            content.AppendLine("  </Target>");
            content.AppendLine("  ");
        }

        if (!FileResolverHelper.Conf.GenerateAtSingleProject)
        {
            content.AppendLine("  <PropertyGroup>");
            content.AppendLine("    <ErrorOnDuplicatePublishOutputFiles>false</ErrorOnDuplicatePublishOutputFiles>");
            content.AppendLine("  </PropertyGroup>");

            content.AppendLine("");

            content.AppendLine("  <ItemGroup>");
            content.AppendLine($"    <ProjectReference Include=\"..\\{FileResolverHelper.Conf.ProjectCopyName}\\{FileResolverHelper.Conf.ProjectCopyName}.csproj\" />");
            content.AppendLine("  </ItemGroup>");

            content.AppendLine("  ");

            content.AppendLine("  <ItemGroup>");
            content.AppendLine($"    <ProjectReference Include=\"..\\{FileResolverHelper.Conf.ProjectDclName}\\{FileResolverHelper.Conf.ProjectDclName}.csproj\" />");
            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
        }


        if (FileResolverHelper.Conf.GenerateAtSingleProject)
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine("    <PackageReference Include=\"dapper\" Version=\"2.1.24\" />");
            content.AppendLine("    <PackageReference Include=\"Dapper.Contrib\" Version=\"2.0.78\" />");
            content.AppendLine("    <PackageReference Include=\"Microsoft.EntityFrameworkCore\" Version=\"8.0.10\" />");
            content.AppendLine("    <PackageReference Include=\"Microsoft.Extensions.Configuration\" Version=\"8.0.0\" />");
            content.AppendLine("    <PackageReference Include=\"Microsoft.Extensions.Configuration.Json\" Version=\"8.0.0\" />");

            if (!FileResolverHelper.Conf.ConvertToSqlServer)
            {
                content.AppendLine("    <PackageReference Include=\"IBM.EntityFrameworkCore\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Windows'))\" />");
                content.AppendLine("    <PackageReference Include=\"IBM.EntityFrameworkCore-lnx\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Linux'))\" />");
                content.AppendLine("    <PackageReference Include=\"Net.IBM.Data.Db2\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Windows'))\" />");
                content.AppendLine("    <PackageReference Include=\"Net.IBM.Data.Db2-lnx\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Linux'))\" />");
            }
            else
                content.AppendLine("    <PackageReference Include=\"System.Data.SqlClient\" Version=\"4.8.6\" />");

            content.AppendLine("    <PackageReference Include=\"newtonsoft.json\" Version=\"13.0.3\" />");
            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
        }

        if (!FileResolverHelper.Conf.GenerateAtSingleProject)
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine("    <ProjectReference Include=\"..\\IA_ConverterCommons\\IA_ConverterCommons.csproj\" />");
            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
        }

        // Adiciona todos os arquivos .cs da pasta de origem ao projeto
        foreach (string file in Directory.GetFiles(Path.Combine(sourceFolderPath, "CODE"), "*.cs"))
        {
            var considerProjectName = module.Name;
            if (!module.Files.Any(x => Path.GetFileNameWithoutExtension(x.Name) == Path.GetFileNameWithoutExtension(file)))
                continue;

            if (FileResolverHelper.Conf.GenerateAtSingleProject)
                considerProjectName = Path.Combine(FileResolverHelper.Conf.ProjectCobolName, controllerFolder);

            var currentFileName = Path.GetFileName(file);
            var currentFileOutputFullPath = Path.Combine(FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, considerProjectName, controllerFolder, currentFileName)));

            var relativeSource = @"..\..\..\..\FileResolver\_Module.cs";
            var sourcePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, relativeSource));

            var targetDir = Path.GetDirectoryName(currentFileOutputFullPath)!;

            var destinationPath = Path.Combine(targetDir, Path.GetFileName(sourcePath));

            if (File.Exists(sourcePath) && !File.Exists(destinationPath))
                File.Copy(sourcePath, destinationPath, overwrite: true);

            File.Move(file, currentFileOutputFullPath, true);
            //content.AppendLine($"    <Compile Include=\"{Path.Combine(projectName, currentFileName)}\" />");
        }

        //content.AppendLine("  </ItemGroup>");
        content.AppendLine("</Project>");

        var projectFullPath = FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, module.Name, module.Name + ".csproj"));
        File.WriteAllText(projectFullPath, content.ToString());
    }

    void GenerateLaunchSettings(string solutionName, InputConfigModules module, string sourceFolderPath)
    {
        if (module.LaunchSettings == null) return;

        var propertiesFolder = FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, module.Name, "Properties"));
        if (!Directory.Exists(propertiesFolder))
            Directory.CreateDirectory(propertiesFolder);

        File.WriteAllText(Path.Combine(propertiesFolder, "launchSettings.json"), $@"{{
   ""profiles"": {{
     ""{module.Name}"": {{
       ""commandName"": ""Project"",
       ""launchBrowser"": true,
       ""environmentVariables"": {{
         ""ASPNETCORE_ENVIRONMENT"": ""Development""
       }},
       ""applicationUrl"": ""{module.LaunchSettings.ApplicationUrl}""
     }}
   }}
 }}");
    }

    void MoveDB2ModuleFolder(InputConfigModules module)
    {
        var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
        var cobolProjectName = FileResolverHelper.Conf.ProjectCobolName;
        var solutionName = FileResolverHelper.Conf.SolutionName;
        var path = Path.Combine(sourceFolderPath, cobolProjectName, "DB2");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        // Obter todos os arquivos .cs na pasta
        var csDirectories = Directory.GetDirectories(path).ToList();
        var csFiles = Directory.GetFiles(path, "*.cs").ToList();
        foreach (var directory in csDirectories)
            csFiles.AddRange(Directory.GetFiles(directory, "*.cs"));

        foreach (var file in csFiles)
        {
            var pth = file.Replace(FileResolverHelper.Conf.OutputDirectory + "\\" + cobolProjectName + "\\", "");
            var fileName = Path.GetFileName(file);
            var sourceFilePath = Path.Combine(sourceFolderPath, solutionName, module.Name, pth.Replace("\\" + fileName, ""));

            if (!module.Files.Any(x => file.Contains("\\" + Path.GetFileNameWithoutExtension(x.Name) + "\\")))
                continue;

            if (!Directory.Exists(sourceFilePath))
                Directory.CreateDirectory(sourceFilePath);

            File.Move(file, Path.Combine(sourceFilePath, fileName), true);
        }

        FormatProject(solutionName, Path.Combine(module.Name, "DB2"), sourceFolderPath, module);
        //FormatProject(solutionName, "DB2", sourceFolderPath, module);
    }

    void GenerateProjectFiles(string solutionName, string projectName, string sourceFolderPath, bool format = true)
    {
        Directory.CreateDirectory(Path.Combine(sourceFolderPath, projectName));

        CreateProjectFile(solutionName, projectName, Path.Combine(sourceFolderPath, projectName));

        if (projectName == "FileTests.Test")
        {
            var relativeSource = @"..\..\..\..\FileResolver\TestAlphabeticalOrderer\TestAlphabeticalOrderer.cs";
            var sourcePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, relativeSource));

            if (!File.Exists(sourcePath)) return;

            var destinationDir = Path.Combine(AppContext.BaseDirectory, "OutputFiles", "Sias", projectName);

            var destinationPath = Path.Combine(destinationDir, Path.GetFileName(sourcePath));
            File.Copy(sourcePath, destinationPath, overwrite: true);
        }

        if (format)
            FormatProject(solutionName, projectName, sourceFolderPath);
    }

    void CreateProjectFile(string solutionName, string projectName, string sourceFolderPath)
    {
        var content = new StringBuilder();
        if (FileResolverHelper.Conf.GenerateApiProject && projectName == FileResolverHelper.Conf.ProjectCobolName)
            content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Web\">");
        else
            content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");


        content.AppendLine("  <PropertyGroup>");

        if (!FileResolverHelper.Conf.GenerateApiProject || FileResolverHelper.Conf.ProjectTestName == projectName)
            content.AppendLine("    <OutputType>Library</OutputType>");

        content.AppendLine("    <TargetFramework>net8.0</TargetFramework>");
        content.AppendLine("    <PlatformTarget>x64</PlatformTarget>");

        if (FileResolverHelper.Conf.ProjectTestName == projectName)
        {
            content.AppendLine("<IsPackable>false</IsPackable>");
            content.AppendLine("<RunAnalyzersDuringBuild>True</RunAnalyzersDuringBuild>");
            content.AppendLine(@"   <UseMicrosoftTestingPlatformRunner>true</UseMicrosoftTestingPlatformRunner>");
        }

        if (!FileResolverHelper.Conf.ConvertToSqlServer)
        {
            content.AppendLine("<DefineConstants>$(DefineConstants);DB2</DefineConstants>");
        }

        content.AppendLine("  </PropertyGroup>");

        if (projectName == FileResolverHelper.Conf.ProjectCobolName)
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine(@"    <PackageReference Include=""MethodDecorator.Fody"" Version=""1.1.1"" />");
            content.AppendLine("  </ItemGroup>");

            if (FileResolverHelper.Conf.GenerateApiProject)
            {
                content.AppendLine("  <ItemGroup>");
                content.AppendLine("  <PackageReference Include=\"Microsoft.AspNetCore.Mvc.Core\" Version=\"2.2.5\" />");
                content.AppendLine("  <PackageReference Include=\"Swashbuckle.AspNetCore\" Version=\"6.6.2\" />");
                content.AppendLine("  <PackageReference Include=\"System.Text.Encoding.CodePages\" Version=\"9.0.1\" />");
                content.AppendLine("  </ItemGroup>");
                content.AppendLine("  ");
                content.AppendLine("  <Target Name=\"CopyToSharedFolder\" AfterTargets=\"Build\">");
                content.AppendLine("    <Copy SourceFiles=\"$(TargetDir)$(TargetName).dll\" DestinationFolder=\"..\\SharedLibs\\\" />");
                content.AppendLine("  </Target>");
            }

            if (!FileResolverHelper.Conf.GenerateAtSingleProject)
            {
                content.AppendLine("  <ItemGroup>");
                content.AppendLine($"    <ProjectReference Include=\"..\\{FileResolverHelper.Conf.ProjectCopyName}\\{FileResolverHelper.Conf.ProjectCopyName}.csproj\" />");
                content.AppendLine("  </ItemGroup>");

                content.AppendLine("  ");

                content.AppendLine("  <ItemGroup>");
                content.AppendLine($"    <ProjectReference Include=\"..\\{FileResolverHelper.Conf.ProjectDclName}\\{FileResolverHelper.Conf.ProjectDclName}.csproj\" />");
                content.AppendLine("  </ItemGroup>");
                content.AppendLine("  ");
            }
        }

        if (projectName == "IA_ConverterCommons" || FileResolverHelper.Conf.ProjectTestName == projectName || (FileResolverHelper.Conf.GenerateAtSingleProject && (projectName == FileResolverHelper.Conf.ProjectCobolName)))
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine("    <PackageReference Include=\"dapper\" Version=\"2.1.24\" />");
            content.AppendLine("    <PackageReference Include=\"Dapper.Contrib\" Version=\"2.0.78\" />");
            content.AppendLine("    <PackageReference Include=\"Microsoft.EntityFrameworkCore\" Version=\"8.0.10\" />");
            content.AppendLine("    <PackageReference Include=\"Microsoft.Extensions.Configuration\" Version=\"8.0.0\" />");
            content.AppendLine("    <PackageReference Include=\"Microsoft.Extensions.Configuration.Json\" Version=\"8.0.0\" />");
            content.AppendLine(@"   <PackageReference Include=""MethodDecorator.Fody"" Version=""1.1.1"" />");
            content.AppendLine(@"   <PackageReference Include=""System.Text.Encoding.CodePages"" Version=""9.0.1"" />");
            content.AppendLine(@"   <PackageReference Include=""Microsoft.Extensions.Configuration.EnvironmentVariables"" Version=""8.0.0"" />");
            content.AppendLine(@"   <PackageReference Include=""Moq"" Version=""4.20.70"" />");

            if (!FileResolverHelper.Conf.ConvertToSqlServer)
            {
                content.AppendLine("    <PackageReference Include=\"IBM.EntityFrameworkCore\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Windows'))\" />");
                content.AppendLine("    <PackageReference Include=\"IBM.EntityFrameworkCore-lnx\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Linux'))\" />");
                content.AppendLine("    <PackageReference Include=\"Net.IBM.Data.Db2\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Windows'))\" />");
                content.AppendLine("    <PackageReference Include=\"Net.IBM.Data.Db2-lnx\" Version=\"8.0.0.300\" Condition=\"$([MSBuild]::IsOsPlatform('Linux'))\" />");
            }
            else
                content.AppendLine("    <PackageReference Include=\"System.Data.SqlClient\" Version=\"4.8.6\" />");

            content.AppendLine("    <PackageReference Include=\"newtonsoft.json\" Version=\"13.0.3\" />");
            if (FileResolverHelper.Conf.ProjectTestName == projectName)
            {
                content.AppendLine(@"   <PackageReference Include=""Microsoft.Testing.Extensions.HangDump"" Version=""1.6.0"" />");
                content.AppendLine(@"   <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.8.0"" />");
                content.AppendLine(@"   <PackageReference Include=""xunit.v3"" Version=""1.1.0"" />");
                content.AppendLine(@"   <PackageReference Include=""xunit.runner.visualstudio"" Version=""3.0.2"">");
                content.AppendLine(@"   <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>");
                content.AppendLine(@"   <PrivateAssets>all</PrivateAssets>");
                content.AppendLine(@"   </PackageReference>");
                content.AppendLine(@"   <PackageReference Include=""coverlet.collector"" Version=""3.1.2"">");
                content.AppendLine(@"   <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>");
                content.AppendLine(@"   <PrivateAssets>all</PrivateAssets>");
                content.AppendLine(@"</PackageReference>");
            }

            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
        }

        if (projectName != "IA_ConverterCommons" && !FileResolverHelper.Conf.GenerateAtSingleProject)
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine("    <ProjectReference Include=\"..\\IA_ConverterCommons\\IA_ConverterCommons.csproj\" />");
            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
        }

        if (projectName == "IA_ConverterCommons")
        {
            content.AppendLine("  <ItemGroup>");
            content.AppendLine("    <None Update=\"appsettings.json\">");
            content.AppendLine("      <CopyToOutputDirectory>Always</CopyToOutputDirectory>");
            content.AppendLine("    </None>");
            content.AppendLine("  </ItemGroup>");
            content.AppendLine("  ");
        }


        if (FileResolverHelper.Conf.ProjectTestName == projectName)
        {
            content.AppendLine("  <ItemGroup>");
            foreach (var item in FileResolverHelper.Conf.InputConfig.ListModuleConsider)
                content.AppendLine($"    <ProjectReference Include=\"..\\{item.Name}\\{item.Name}.csproj\" />");
            content.AppendLine("  </ItemGroup>");
        }
        //content.AppendLine("  <ItemGroup>");

        // Adiciona todos os arquivos .cs da pasta de origem ao projeto
        foreach (string file in Directory.GetFiles(sourceFolderPath, "*.cs"))
        {
            if (FileResolverHelper.Conf.ProjectCopyName == projectName && !HasCopyFolder)
                HasCopyFolder = true;

            if (FileResolverHelper.Conf.ProjectDclName == projectName && !HasDclFolder)
                HasDclFolder = true;

            var considerProjectName = projectName;
            if (FileResolverHelper.Conf.GenerateAtSingleProject && FileResolverHelper.Conf.ProjectTestName != projectName)
                considerProjectName = Path.Combine(FileResolverHelper.Conf.ProjectCobolName, (projectName == FileResolverHelper.Conf.ProjectCobolName ? controllerFolder : projectName));

            var currentFileName = Path.GetFileName(file);
            var currentFileOutputFullPath = Path.Combine(FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, considerProjectName, projectName, currentFileName)));

            File.Move(file, currentFileOutputFullPath, true);
            //content.AppendLine($"    <Compile Include=\"{Path.Combine(projectName, currentFileName)}\" />");
        }

        //content.AppendLine("  </ItemGroup>");
        content.AppendLine("</Project>");

        if (!FileResolverHelper.Conf.GenerateAtSingleProject || projectName == FileResolverHelper.Conf.ProjectCobolName || FileResolverHelper.Conf.ProjectTestName == projectName)
        {
            var projectFullPath = FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, projectName, projectName + ".csproj"));
            File.WriteAllText(projectFullPath, content.ToString());
        }
    }

    void CreateSolutionFile(string solutionName, string projectCopyName, string dclProjecName)
    {
        var commonsName = "IA_ConverterCommons";
        var copies = FileResolverHelper.Conf.ProjectCopyName;
        var dclGens = FileResolverHelper.Conf.ProjectDclName;
        var testGeneratedName = FileResolverHelper.Conf.ProjectTestName;
        var content = new StringBuilder();
        content.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
        content.AppendLine("# Visual Studio Version 16");
        var guidList = new List<Guid>();
        var commomGuid = Guid.NewGuid();

        foreach (var module in FileResolverHelper.Conf.InputConfig.ListModuleConsider)
        {
            var outputSolutionFolder = FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName));

            var file = Path.Combine(module.Name, module.Name + ".csproj");
            if (!File.Exists(Path.Combine(outputSolutionFolder, file))) continue;

            if (File.Exists(Path.Combine(outputSolutionFolder, commonsName, "appSettings.json")))
                File.Copy(Path.Combine(outputSolutionFolder, commonsName, "appSettings.json"), Path.Combine(outputSolutionFolder, module.Name, "appSettings.json"));

            guidList.Add(Guid.NewGuid());

            // Adiciona o projeto à solução
            content.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{module.Name}\", \"{file}\", \"{guidList.Last()}\"");
            content.AppendLine("EndProject");
        }

        // Adiciona o projeto à solução testGeneratedName
        if (FileResolverHelper.Conf.GenerateTestProject)
        {
            guidList.Add(Guid.NewGuid());
            content.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{testGeneratedName}\", \"{Path.Combine(testGeneratedName, testGeneratedName + ".csproj")}\", \"{guidList.Last()}\"");
            content.AppendLine("EndProject");
        }

        //IA_ConverterCommons
        guidList.Add(Guid.NewGuid());
        content.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{commonsName}\", \"{Path.Combine(commonsName, commonsName + ".csproj")}\", \"{guidList.Last()}\"");
        content.AppendLine("EndProject");

        //Copies
        guidList.Add(Guid.NewGuid());
        content.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{copies}\", \"{Path.Combine(copies, copies + ".csproj")}\", \"{guidList.Last()}\"");
        content.AppendLine("EndProject");

        //DclGens
        guidList.Add(Guid.NewGuid());
        content.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{dclGens}\", \"{Path.Combine(dclGens, dclGens + ".csproj")}\", \"{guidList.Last()}\"");
        content.AppendLine("EndProject");

        // Adiciona informações globais da solução, se necessário
        content.AppendLine("Global");
        content.AppendLine("\tGlobalSection(SolutionConfigurationPlatforms) = preSolution");
        content.AppendLine("\t\tDebug|Any CPU = Debug|Any CPU");
        content.AppendLine("\t\tRelease|Any CPU = Release|Any CPU");
        content.AppendLine("\tEndGlobalSection");
        content.AppendLine("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution");

        foreach (var guid in guidList)
        {
            content.AppendLine($"\t\t{guid}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
            content.AppendLine($"\t\t{guid}.Debug|Any CPU.Build.0 = Debug|Any CPU");
            content.AppendLine($"\t\t{guid}.Release|Any CPU.ActiveCfg = Release|Any CPU");
            content.AppendLine($"\t\t{guid}.Release|Any CPU.Build.0 = Release|Any CPU");
        }

        content.AppendLine("\tEndGlobalSection");
        content.AppendLine("\tGlobalSection(SolutionProperties) = preSolution");
        content.AppendLine("\t\tHideSolutionNode = FALSE");
        content.AppendLine("\tEndGlobalSection");
        content.AppendLine("EndGlobal");

        var solutionFullPath = FileResolverHelper.GetOutputPathCombined(Path.Combine(solutionName, solutionName + ".sln"));
        File.WriteAllText(solutionFullPath, content.ToString());
    }

    bool isAlreadAddedModule = false;
    void FormatProject(string solutionName, string projectName, string sourceFolderPath, InputConfigModules module = null)
    {
        try
        {
            using var workspace = new AdhocWorkspace();

            // Carregar o projeto usando o AdhocWorkspace
            var project = workspace.AddProject("MyProject", LanguageNames.CSharp)
                                   .AddMetadataReference(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));

            var considerProjectName = projectName;
            if (FileResolverHelper.Conf.GenerateAtSingleProject && projectName != FileResolverHelper.Conf.ProjectTestName)
                considerProjectName = Path.Combine(FileResolverHelper.Conf.ProjectCobolName, (projectName == FileResolverHelper.Conf.ProjectCobolName ? controllerFolder : projectName));
            //else if (projectName == "DB2")
            //    considerProjectName = Path.Combine(FileResolverHelper.Conf.ProjectCobolName, projectName);

            if (!Directory.Exists(Path.Combine(sourceFolderPath, solutionName, considerProjectName)))
            {
                Console.WriteLine($"Pulando formatação do projeto {projectName}, arquivos não encontrados.");
                return;
            }

            // Obter todos os arquivos .cs na pasta
            var csDirectories = Directory.GetDirectories(Path.Combine(sourceFolderPath, solutionName, considerProjectName)).Where(x => !x.Contains("\\bin", StringComparison.OrdinalIgnoreCase) && !x.Contains("\\obj", StringComparison.OrdinalIgnoreCase)).ToList();
            var csFiles = new List<string>();
            foreach (var directory in csDirectories)
            {
                csFiles.AddRange(Directory.GetFiles(directory, "*.cs").Where(f => !f.EndsWith("_Module.cs", StringComparison.OrdinalIgnoreCase)));
                foreach (var innerDir in Directory.GetDirectories(directory))
                    csFiles.AddRange(Directory.GetFiles(innerDir, "*.cs"));
            }

            foreach (var csFile in csFiles)
            {
                // Adicionar o documento ao projeto
                var cSharpCode = File.ReadAllText(csFile);
                var document = workspace.AddDocument(project.Id, Path.GetFileName(csFile), Microsoft.CodeAnalysis.Text.SourceText.From(cSharpCode));
                var fileName = Path.GetFileName(csFile);
                var isDbTest = csFile.Contains("_Tests_DB");
                var fileNameWExt = Path.GetFileNameWithoutExtension(csFile).Replace("_Tests_DB", "").Replace("_Tests", "");
                //var nameSpace = $"{considerProjectName}";
                var nameSpace = csFile.Replace($"{fileName}", "").Replace($"{sourceFolderPath}\\{solutionName}\\{considerProjectName}\\", "").Replace("\\", ".").TrimEnd('.');
                if (string.IsNullOrEmpty(nameSpace))
                    nameSpace = considerProjectName.Replace("\\", ".");

                if (module != null)
                    if (csFile.Contains("\\DB2\\"))
                        nameSpace = csFile.Replace($"{fileName}", "").Replace($"{sourceFolderPath}\\{solutionName}\\", "").Replace("\\", ".").TrimEnd('.');

                if (isDbTest)
                    nameSpace += "_DB";

                // Formatar o código do documento
                var formattedDocument = document.WithSyntaxRoot(Microsoft.CodeAnalysis.Formatting.Formatter.FormatAsync(document).Result.GetSyntaxRootAsync().Result);

                // Obter a árvore de sintaxe atualizada
                var syntaxRoot = formattedDocument.GetSyntaxRootAsync().Result;
                var semanticModel = formattedDocument.GetSemanticModelAsync().Result;

                //processo para remover código que não é "atingível", aqueles códigos depois de return's ou throw's
                var unreachableCode = syntaxRoot.DescendantNodes()
                              .OfType<BlockSyntax>()
                              .SelectMany(block => FindUnreachableStatements(block))
                              .ToList();

                // Remove the unreachable code from the syntax tree
                syntaxRoot = syntaxRoot.RemoveNodes(unreachableCode, SyntaxRemoveOptions.KeepNoTrivia);


                AttributeSyntax attributeSyntax = null;
                AttributeListSyntax attributeListSyntax = null;

                // Criar um novo namespace e adicionar membros da classe
                var usingList = new List<UsingDirectiveSyntax> {
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("IA_ConverterCommons")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Text.Json.Serialization")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Threading.Tasks")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq")),
                    SyntaxFactory.UsingDirective(
                            SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(FileResolverHelper.Conf.ProjectQualifierGeneralCommands)),
                            SyntaxFactory.QualifiedName(
                                SyntaxFactory.IdentifierName("IA_ConverterCommons"),
                                SyntaxFactory.IdentifierName("Statements")
                            )
                        ),
                    SyntaxFactory.UsingDirective(
                            SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(FileResolverHelper.Conf.ProjectDBQualifierGeneralCommands)),
                            SyntaxFactory.QualifiedName(
                                SyntaxFactory.IdentifierName("IA_ConverterCommons"),
                                SyntaxFactory.IdentifierName("DatabaseBasis")
                            )
                        )
                };

                if (projectName == FileResolverHelper.Conf.ProjectCobolName)
                {
                    if (HasCopyFolder) usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectCopyName)));
                    if (HasDclFolder) usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectDclName)));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Dapper")));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("DB2")));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectCobolName)));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq")));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Text.RegularExpressions")));

                    attributeSyntax = SyntaxFactory.Attribute(SyntaxFactory.ParseName("module: StopWatch"));
                    attributeListSyntax = SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(attributeSyntax));
                }

                if (projectName == FileResolverHelper.Conf.ProjectTestName)
                {
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Xunit")));
                    if (HasCopyFolder) usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectCopyName)));
                    if (HasDclFolder) usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectDclName)));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(controllerFolder)));
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.Token(SyntaxKind.StaticKeyword), default(NameEqualsSyntax), SyntaxFactory.ParseName($"{controllerFolder}.{fileNameWExt}")));
                }

                if (projectName == module?.Name)
                {
                    if (HasDclFolder) usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectDclName)));
                    if (HasCopyFolder) usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(FileResolverHelper.Conf.ProjectCopyName)));
                    attributeSyntax = SyntaxFactory.Attribute(SyntaxFactory.ParseName("module: StopWatch"));
                    attributeListSyntax = SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(attributeSyntax));
                }

                var hasSqlCall = cSharpCode.Contains(".Execute") || cSharpCode.Contains(".Open()");

                if (!nameSpace.Contains(".DB2") && !nameSpace.Contains(FileResolverHelper.Conf.ProjectCopyName) && !nameSpace.Contains(FileResolverHelper.Conf.ProjectTestName) && !nameSpace.Contains(FileResolverHelper.Conf.ProjectDclName) && hasSqlCall)
                    usingList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName($"{module?.Name}.DB2.{fileNameWExt}")));

                var newSyntaxRoot = SyntaxFactory.CompilationUnit()
                    .AddUsings(usingList.ToArray());

                if (attributeListSyntax != null && !nameSpace.Trim().Contains("\\DB2\\") && !isAlreadAddedModule)
                {
                    //Esse Comentario remove o [module: StopWatch] da transpilação
                    // newSyntaxRoot = newSyntaxRoot?.AddAttributeLists(attributeListSyntax);
                    isAlreadAddedModule = true;
                }

                newSyntaxRoot = newSyntaxRoot?.AddMembers(
                        SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(nameSpace))
                            .AddMembers(
                                syntaxRoot.DescendantNodes()
                                         .OfType<MemberDeclarationSyntax>()
                                         .Where(m => m.Parent is not ClassDeclarationSyntax)
                                         .ToArray()
                            )
                    );

                //newSyntaxRoot = newSyntaxRoot.RemoveNodes(newSyntaxRoot.Usings.Where(usingDirective => usingDirective.Name.ToString() != "System"), SyntaxRemoveOptions.kee);
                //var syntaxTree = CSharpSyntaxTree.ParseText(cSharpCode);
                //var semanticModel = GetSemanticModel(syntaxTree);

                //var newRoot = RemoveUnusedUsingDirectives(newSyntaxRoot, semanticModel);
                //var progReffNames = programsToRefferNamespace.Where(x => x.Key == fileNameWExt);
                //if (progReffNames?.Any() == true)
                //{
                //    foreach (var item in progReffNames)
                //    {
                //        newSyntaxRoot = newSyntaxRoot.AddUsings(
                //        item.Value.Distinct().Select(x =>
                //            SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(x))).ToArray()
                //        );
                //    }
                //}

                // Atualizar o documento com a nova árvore de sintaxe
                var newDocument = formattedDocument.WithSyntaxRoot(newSyntaxRoot);

                formattedDocument = Microsoft.CodeAnalysis.Formatting.Formatter.FormatAsync(newDocument).Result;

                var res = formattedDocument.GetTextAsync().Result.ToString();
                //Console.WriteLine(res);
                File.WriteAllText(csFile, res);
                // Atualizar o projeto com o novo documento
                //workspace.TryApplyChanges(newSolution);
            }

            Console.WriteLine("Projeto Atualizado com Código Formatado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao formatar o projeto: {ex.Message}");
        }
    }
    private static IEnumerable<StatementSyntax> FindUnreachableStatements(BlockSyntax block)
    {
        var unreachable = false;

        foreach (var statement in block.Statements)
        {
            if (unreachable)
            {
                // After identifying the unreachable point, return all subsequent statements
                yield return statement;
            }

            // Check for flow-breaking statements
            if (statement is ReturnStatementSyntax ||
                statement is ThrowStatementSyntax ||
                statement is ContinueStatementSyntax ||
                statement is BreakStatementSyntax ||
                statement is GotoStatementSyntax)
            {
                unreachable = true;
            }
        }
    }

    void MovePropertiesFolder()
    {
        if (!FileResolverHelper.Conf.GenerateJsonIndicators)
            return;

        try
        {
            var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
            var cobolProjectName = FileResolverHelper.Conf.ProjectCobolName;
            var solutionName = FileResolverHelper.Conf.SolutionName;
            var path = Path.Combine(sourceFolderPath, cobolProjectName, "Properties");

            // Obter todos os arquivos .cs na pasta
            var csDirectories = Directory.GetDirectories(path).ToList();
            var csFiles = Directory.GetFiles(path, "*.json").ToList();
            foreach (var directory in csDirectories)
                csFiles.AddRange(Directory.GetFiles(directory, "*.json"));

            foreach (var file in csFiles)
            {
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file).Replace("_Methods", "");
                var module = FileResolverHelper.Conf.InputConfig.ListModuleConsider.FirstOrDefault(x => x.Files.Any(a => Path.GetFileNameWithoutExtension(a.Name) == fileNameWithoutExt));

                if (module == null)
                    continue;

                var cleanedModule = module.Name.Split(".").LastOrDefault();

                var pth = file.Replace(FileResolverHelper.Conf.OutputDirectory + "\\", "");
                var fileName = Path.GetFileName(file);
                var innerPath = Path.Combine(sourceFolderPath, solutionName, module.Name, "Properties", "Indicators");

                if (!Directory.Exists(innerPath))
                    Directory.CreateDirectory(innerPath);

                File.Move(file, Path.Combine(innerPath, fileName), true);

                Console.WriteLine($"Copiando mapas em Json método: {fileName}");
            }
        }
        catch { }

    }

    //void MoveDB2Folder()
    //{
    //    var sourceFolderPath = FileResolverHelper.Conf.OutputDirectory;
    //    var cobolProjectName = FileResolverHelper.Conf.ProjectCobolName;
    //    var solutionName = FileResolverHelper.Conf.SolutionName;
    //    var path = Path.Combine(sourceFolderPath, cobolProjectName, "DB2");

    //    if (!Directory.Exists(path))
    //        Directory.CreateDirectory(path);

    //    // Obter todos os arquivos .cs na pasta
    //    var csDirectories = Directory.GetDirectories(path).ToList();
    //    var csFiles = Directory.GetFiles(path, "*.cs").ToList();
    //    foreach (var directory in csDirectories)
    //        csFiles.AddRange(Directory.GetFiles(directory, "*.cs"));

    //    foreach (var file in csFiles)
    //    {
    //        var pth = file.Replace(FileResolverHelper.Conf.OutputDirectory + "\\", "");
    //        var fileName = Path.GetFileName(file);
    //        var innerPath = Path.Combine(sourceFolderPath, solutionName, pth.Replace(fileName, "").Replace("DB2", Path.Combine("DB2", "DB2")));
    //        if (!Directory.Exists(innerPath))
    //            Directory.CreateDirectory(innerPath);

    //        File.Move(file, Path.Combine(innerPath, fileName), true);
    //    }

    //    FormatProject(solutionName, "DB2", sourceFolderPath);
    //}

    string CreateModelApiFor(MethodReferenceInfo methodRef, out string modelName)
    {
        var hasCopyDir = Directory.Exists(Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, FileResolverHelper.Conf.ProjectCopyName, FileResolverHelper.Conf.ProjectCopyName));
        var hasDclDir = Directory.Exists(Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, FileResolverHelper.Conf.ProjectDclName, FileResolverHelper.Conf.ProjectDclName));
        //var oldhasDclDir = Directory.Exists(Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, FileResolverHelper.Conf.ProjectDclName));
        modelName = $"{methodRef.MethodName}Model";
        var modelCode = new StringBuilder($@"
            {(hasCopyDir ? $"using {FileResolverHelper.Conf.ProjectCopyName};" : "")}
            {(hasDclDir ? $"using {FileResolverHelper.Conf.ProjectDclName};" : "")}
            using IA_ConverterCommons;
            using static {controllerFolder}.{methodRef.MethodName};

            namespace {methodRef.ModuleName}.Model
            {{
                public class {modelName}
                {{
        ");

        foreach (var reference in methodRef.References)
        {
            var refName = !reference.PropertyNameOnModel.IsEmpty() ? reference.PropertyNameOnModel.Split(".").LastOrDefault() : reference.PropertyName.Split(".").LastOrDefault();
            var type = reference.PropertyType;
            var isNewType = type != "string";

            modelCode.AppendLine($"public {type} {refName} {{ get; set; }}{(isNewType ? $" = new {type}();" : "")}");
        }

        modelCode.Append($@"
            }}
        }}
        ");

        var path = Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, methodRef.ModuleName, "Model");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        File.WriteAllText(Path.Combine(path, $"{modelName}.cs"), SimpleFormatDocument(modelCode.ToString()));

        return modelName;
    }

    string SimpleFormatDocument(string code)
    {
        using var workspace = new AdhocWorkspace();

        var project = workspace
                        .AddProject("MyProject", LanguageNames.CSharp)
                        .AddMetadataReference(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
        var document = workspace.AddDocument(project.Id, FileResolverHelper.Conf.ProjectCobolName, Microsoft.CodeAnalysis.Text.SourceText.From(code.ToString()));
        var formattedDocument = Microsoft.CodeAnalysis.Formatting.Formatter.FormatAsync(document).Result;
        var res = formattedDocument.GetTextAsync().Result.ToString();

        return res;
    }

    static string controllerFolder = "Code";
    void CreateApiForReferencesMethods(List<MethodReferenceInfo> apiMethodsReference)
    {
        var hasCopyDir = Directory.Exists(Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, FileResolverHelper.Conf.ProjectCopyName, FileResolverHelper.Conf.ProjectCopyName));

        //var modules = apiMethodsReference.Select(x => x.ModuleName).Distinct();
        //using static {controllerFolder}.{methodRef.MethodName}; removido da linha 1006
        foreach (var methodRef in apiMethodsReference.DistinctBy(x => x.ModuleName))
        {
            var modName = methodRef.ModuleName;
            var cleanedModule = modName.Split(".").LastOrDefault();
            var controllerCode = new StringBuilder($@"
            using Microsoft.AspNetCore.Mvc;
            {(hasCopyDir ? $"using {FileResolverHelper.Conf.ProjectCopyName};" : "")}
            using {modName}.Model;
            using IA_ConverterCommons;

            using {controllerFolder};

            namespace {modName}
            {{
                [ApiController]
                [Route(""{cleanedModule}"")]
                public class {cleanedModule}Controller : ControllerBase
                {{
            ");

            foreach (var methodReference in apiMethodsReference.Where(x => x.ModuleName == modName))
            {
                CreateModelApiFor(methodReference, out var modelName);
                var modelVarName = $"{modelName}_P";

                controllerCode.AppendLine($@"
                [HttpPost(""{methodReference.MethodName}"")]
                public IActionResult {methodReference.MethodName}({modelName} {modelVarName})
                {{ 
                    var program = new {methodReference.MethodName}();
                    var result = program.Execute({string.Join(",", methodReference.References.Select(x =>
                                                         $"{modelVarName}.{(string.IsNullOrEmpty(x.PropertyNameOnModel) ? x.PropertyName.Split('.').LastOrDefault() : x.PropertyNameOnModel)}"
                                    ))});
                    return Ok(result);
                }} ");
            }

            controllerCode.Append($@"
                }}
            }}
            ");

            // Crie uma árvore de sintaxe a partir do código
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(controllerCode.ToString());

            // Crie e configure a compilação
            //var compilation = CSharpCompilation.Create($"{module}_API")
            //    .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            //    .AddReferences(
            //        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            //        MetadataReference.CreateFromFile(typeof(ControllerBase).Assembly.Location),
            //        MetadataReference.CreateFromFile(typeof(IActionResult).Assembly.Location),
            //        MetadataReference.CreateFromFile(Assembly.Load("Microsoft.AspNetCore.Mvc.Core").Location)
            //    )
            //    .AddSyntaxTrees(syntaxTree);

            // Compilar o código
            using (var ms = new MemoryStream())
            {
                //var result = compilation.Emit(ms);

                var local = Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, modName);
                if (!Directory.Exists(local)) Directory.CreateDirectory(local);

                File.WriteAllText(Path.Combine(local, $"{cleanedModule}Controller.cs"), SimpleFormatDocument(controllerCode.ToString()));
                File.WriteAllText(Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, modName, $"Program.cs"), GetStartupCode(modName));

                //if (!result.Success)
                //{
                //    Console.WriteLine("Erro ao compilar o código dinâmico:");
                //    //foreach (Diagnostic diagnostic in result.Diagnostics)
                //    //{
                //    //    Console.WriteLine(diagnostic);
                //    //}
                //}
                //else
                //{
                //    // Salvar o arquivo compilado
                //    var outputPath = $"{FileResolverHelper.Conf.ProjectCobolName}_API.dll";
                //    File.WriteAllBytes(outputPath, ms.ToArray());
                //    Console.WriteLine("Controlador dinâmico salvo em: " + Path.GetFullPath(outputPath));
                //}
            }
        }
    }

    string GetStartupCode(string module)
    {
        var cleanedModule = module.Split(".").LastOrDefault();

        return $@"
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{{
    c.SwaggerDoc(""v1"", new OpenApiInfo {{ Title = ""{cleanedModule}"", Description = """", Version = ""v1"" }});
}});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{{
    c.SwaggerEndpoint(""/swagger/v1/swagger.json"", ""{cleanedModule} v1"");
}});

app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{{
    endpoints.MapGet(""/"", context =>
    {{
        context.Response.Redirect(""swagger"");
        return Task.CompletedTask;
    }});
}});

app.Run();
        ";
    }

    //void CreateProjectTestFile()
    //{
    //    var content = new StringBuilder();
    //    content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");

    //    content.AppendLine(@"
    //        <PropertyGroup>
    //      <TargetFramework>net6.0</TargetFramework>
    //      <ImplicitUsings>enable</ImplicitUsings>
    //      <Nullable>enable</Nullable>

    //      <IsPackable>false</IsPackable>

    //      <RunAnalyzersDuringBuild>True</RunAnalyzersDuringBuild>
    //     </PropertyGroup>
    //    ");

    //    content.AppendLine(@"
    //        <ItemGroup>
    //      <PackageReference Include=""dapper"" Version=""2.1.24"" />
    //      <PackageReference Include=""Dapper.Contrib"" Version=""2.0.78"" />
    //      <PackageReference Include=""IBM.EntityFrameworkCore"" Version=""7.0.0.200"" />
    //      <PackageReference Include=""Microsoft.EntityFrameworkCore"" Version=""7.0.1"" />
    //      <PackageReference Include=""Microsoft.EntityFrameworkCore.Design"" Version=""7.0.1"">
    //       <PrivateAssets>all</PrivateAssets>
    //       <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    //      </PackageReference>
    //      <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.8.0"" />

    //      <PackageReference Include=""xunit"" Version=""2.4.1"" />
    //      <PackageReference Include=""xunit.extensibility.core"" Version=""2.6.3"" />
    //      <PackageReference Include=""xunit.runner.visualstudio"" Version=""2.4.3"">
    //       <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    //       <PrivateAssets>all</PrivateAssets>
    //      </PackageReference>
    //      <PackageReference Include=""coverlet.collector"" Version=""3.1.2"">
    //       <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    //       <PrivateAssets>all</PrivateAssets>
    //      </PackageReference>
    //     </ItemGroup>
    //    ");

    //    content.AppendLine("</Project>");

    //    var folder = Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, FileResolverHelper.Conf.ProjectTestName);
    //    if (!Directory.Exists(folder))
    //        Directory.CreateDirectory(folder);

    //    var projectFullPath = FileResolverHelper.GetOutputPathCombined(Path.Combine(folder, FileResolverHelper.Conf.ProjectTestName + ".csproj"));
    //    File.WriteAllText(projectFullPath, content.ToString());
    //}
}
