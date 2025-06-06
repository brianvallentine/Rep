using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Xml.Linq;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using Copybook.Converter;
using CodeAnalyser.Helper;
using FileResolver.Helper;
using System.Reflection;
using FileResolver;
using CobolLanguageConverter.Converter.Commands.SQL;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_ResolveSqlToFileCommand : ICSharpCommand
    {
        public int Order { get; set; } = 25;
        public Dictionary<string, string> db2ClassNames = new Dictionary<string, string>();
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = ConvertWorkingStorageSqlSection(csharpCode, ref divisionAndLines);
            return ret;
        }

        #region SQL
        public StringBuilder ConvertWorkingStorageSqlSection(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = csharpCode;
            var sections = new List<string>
            {
                @"FILE(.*?)+SECTION"             ,
                @"WORKING-STORAGE(.*?)+SECTION"   ,
                @"LOCAL-STORAGE(.*?)+SECTION"   ,
                @"LINKAGE(.*?)+SECTION"           ,
            };

            for (int i = 0; i < divisionAndLines.Count; i++)
            {
                var secLine = divisionAndLines.ElementAt(i);
                var matchItem = sections.FirstOrDefault(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500)));
                if (matchItem == null)
                    continue;

                foreach (var currentLine in secLine.Value)
                {
                    if (!Regex.IsMatch(currentLine.Line, @"EXEC\s+SQL\s+DECLARE(\s|\S)+?END-EXEC") || Regex.IsMatch(currentLine.Line, @"EXEC\s+SQL\s+DECLARE\s+\S+\s+TABLE\s+"))
                        continue;

                    // Converter declarações de cursor para SQL Dapper
                    var convertedSqlCode = ParseSqlDeclareCurrentLine(currentLine);

                    ret.AppendLine($"{convertedSqlCode}");
                }
            }

            return ret;
        }

        public string ParseSqlDeclareCurrentLine(CurrentLineType currentLine, bool internalDeclare = false)
        {
            var ret = currentLine.Line;

            if (!Regex.IsMatch(currentLine.Line, @"EXEC\s+SQL\s+DECLARE(\s|\S)+?END-EXEC"))
                return ret;

            // Separar declarações de cursor
            var cursorDeclarations = ExtractCursorDeclarations(currentLine);

            // Converter declarações de cursor para SQL Dapper
            var convertedSqlCode = ConvertCursorDeclarationsToDapper(cursorDeclarations, internalDeclare);

            foreach (var db2Class in db2ClassNames)
            {
                var generator = new FileGenerator();
                generator.PushClassToDb2Folder(db2Class.Key, db2Class.Value, Result.programName);
            }

            return convertedSqlCode;
        }

        private CurrentLineType ExtractCursorDeclarations(CurrentLineType cobolSqlCodeLine)
        {
            // Utilizar expressão regular para encontrar declarações de cursor
            var match = Regex.Match(cobolSqlCodeLine.Line, @"(?i)(EXEC\s+SQL)?(\DECLARE)(\s|\S)+?END-EXEC[.]*", RegexOptions.IgnoreCase);
            return new CurrentLineType(match.Groups[0].Value.Trim(), cobolSqlCodeLine.LineNumber);
            //string[] cursorDeclarations = new string[matches.Count];
            //for (int i = 0; i < matches.Count; i++)
            //{
            //    cursorDeclarations[i] = matches[i].Groups[0].Value.Trim();
            //}

            //return cursorDeclarations;
        }

        private string ConvertCursorDeclarationsToDapper(CurrentLineType cursorDeclaration, bool internalDeclare)
        {
            string convertedSqlCode = "";
            //foreach (string cursorDeclaration in cursorDeclarations)
            //{
            // Mapear variáveis e tabela
            string cursorName = GetCursorName(cursorDeclaration.Line);
            cursorName = Regex.Replace(cursorName, @"\s+INSENSITIVE\s+SCROLL", "").Trim();
            //string tableName = GetTableName(cursorDeclaration);

            // Criar método Dapper para execução do cursor
            string translatedSql = cursorDeclaration.Line;

            if (Regex.IsMatch(translatedSql, @"WITH\s+RETURN\s+FOR"))
                Result.CursorReturnName.Add(cursorName);

            if (Regex.IsMatch(translatedSql, @"WITH\s+RETURN\s+WITH\s+HOLD\s+FOR"))
                Result.CursorReturnName.Add(cursorName);

            var passLine = cursorDeclaration.Line;
            var procFetch = Result.ProcedureReference.FirstOrDefault(x => x.Value.Any(a => Regex.IsMatch(a.Line, @$"EXEC\s+SQL\s+FETCH(\s+NEXT)*\s+({cursorName}|{cursorName.Replace("_", "-")})")));

            //deve encontrar o FETCH ou ser um cursor de retorno
            //if (procFetch.Key == null && !Result.CursorReturnName.Contains(cursorName))
            //    throw new Exception("Erro de validação: DEVE ENCONTRAR O FETCH PARA MONTAR O SELECT");

            if (procFetch.Key != null)
            {
                var lineFetch = procFetch.Value.FirstOrDefault(a => Regex.IsMatch(a.Line, @$"EXEC\s+SQL\s+FETCH(\s+NEXT)*\s+({cursorName}|{cursorName.Replace("_", "-")})"));
                passLine = lineFetch != null ? lineFetch.Line : cursorDeclaration.Line;
            }

            var selectClause = GetSelectClause(passLine);
            //string whereClause = GetWhereClause(cursorDeclaration);

            //translatedSql = Regex.Replace(translatedSql, @"\s+", " ");

            //trata alias com aspas simples e espaços
            string singleQuotesPattern = @"AS\s+\'(.*?)\'";
            //trata alias com aspas duplas e espaços
            string doubleQuotesPattern = @"AS\s+\""(.*?)\""";
            translatedSql = Regex.Replace(translatedSql, singleQuotesPattern, match => $"AS {match.Groups[1].Value.Replace(" ", "").Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Replace("+", "")}");
            translatedSql = Regex.Replace(translatedSql, doubleQuotesPattern, match => $"AS {match.Groups[1].Value.Replace(" ", "").Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Replace("+", "")}");
            translatedSql = Regex.Replace(translatedSql, @$"DECLARE\s+{cursorName.Replace("_", "-")}\s+CURSOR\s+FOR", "");
            translatedSql = Regex.Replace(translatedSql, @$"DECLARE\s+{cursorName}\s+CURSOR\s+FOR", "");
            translatedSql = Regex.Replace(translatedSql, @$"DECLARE\s+{cursorName.Replace("_", "-")}\s+CURSOR", "");
            translatedSql = Regex.Replace(translatedSql, @$"DECLARE\s+{cursorName.Replace("_", "-")}\s+INSENSITIVE\s+SCROLL\s+CURSOR", "");
            translatedSql = Regex.Replace(translatedSql, @"WITH\s+HOLD\s+FOR", "");
            translatedSql = Regex.Replace(translatedSql, @"WITH\s+RETURN\s+FOR", "");
            translatedSql = Regex.Replace(translatedSql, @"WITH\s+RETURN", "");
            translatedSql = Regex.Replace(translatedSql, @"WITH\s+HOLD", "");
            translatedSql = Regex.Replace(translatedSql, @"WITH\s+UR", "");
            translatedSql = Regex.Replace(translatedSql, @"HOLD\s+FOR", "");
            translatedSql = Regex.Replace(translatedSql, @"END-EXEC.", "");
            translatedSql = Regex.Replace(translatedSql, @"END-EXEC", "");
            translatedSql = Regex.Replace(translatedSql, @"\s+FOR\s+UPDATE\s+OF[^$]+", "");
            translatedSql = string.Join("\n", translatedSql.Split("\n").Select(x => Regex.Replace(x, @"\s+", " ")));
            translatedSql = Regex.Replace(translatedSql, $" ,", ",");

            selectClause = Regex.Replace(selectClause, @"(?<r1>VALUE\()(?<r2>[^\)|^\(]+),.+?\)", "${r1}${r2}").Replace("(", "_").Replace(")", "");

            var intosColumns = new List<string>();
            var wheresColumns = new List<string>();
            var query = "";

            var command = new SELECT_PreProcessCommand();
            command.Result = Result;
            command.CurrentLine = cursorDeclaration;
            var ret = command.Execute(translatedSql, ref query, ref intosColumns, ref wheresColumns);

            var command2 = new SELECT_ReplaceQueryValuesCommand();
            command2.Result = Result;
            command2.CurrentLine = cursorDeclaration;
            command2.ConsiderExternal = true;
            ret = command2.Execute(ret, ref query, ref intosColumns, ref wheresColumns);

            var command3 = new SELECT_ConvertSqlServerCommand();
            command3.Result = Result;
            command3.CurrentLine = cursorDeclaration;
            ret = command3.Execute(ret, ref query, ref intosColumns, ref wheresColumns);
            ret = query;
            ret = Regex.Replace(ret, @"DECLARE\s+\S+\s+CURSOR\s+", @"");
            if (ret.Contains("FOR")) ret = Regex.Replace(ret, @"^\s*\bFOR\b(?=.*SELECT)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            ret = ResolveReferences(ret);

            string sqlCopy = GenerateSQLCopy(cursorDeclaration, cursorName, ret, internalDeclare, selectClause, wheresColumns);

            // Adicionar ao código convertido
            //convertedSqlCode += dapperMethod;
            convertedSqlCode += sqlCopy;
            //}

            return convertedSqlCode;
        }

        private string ResolveReferences(string ret)
        {

            //var ResolveRefs = Regex.Matches(ret, @":\s*\S+", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //Remove trechos entre aspas simples para desconsiderar :(dois pontos) dentro de aspas simples e não criar um parâmetro a partir deste
            //exemplo: WHERE T2.TIMESTAMP > '2014-01-01 00:00:00.000000'
            string sqlWithoutSingleQuotes = Regex.Replace(ret, @"'[^']*'", string.Empty);
            var ResolveRefs = Regex.Matches(sqlWithoutSingleQuotes, @":\s*\S+", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (ResolveRefs.Any())
            {
                foreach (Match item in ResolveRefs)
                {
                    var originalCode = item.Value.Replace(")", "");
                    var varName = H.GetReferenceProperty(originalCode, Result);
                    var newVarName = varName?.PropertyName;
                    if (varName == null)
                        newVarName = originalCode.Replace(":", "").Replace("-", "_");

                    var replaceFor = $"{{{newVarName}}}";
                    if (varName?.PropertyType == "StringBasis")
                        replaceFor = $"'{replaceFor}'";

                    ret = ret.Replace(originalCode, replaceFor);
                }
            }

            return ret;
        }

        private string GetCursorName(string cursorDeclaration)
        {
            // Implementar lógica para extrair o nome do cursor
            // Neste exemplo, estamos usando uma expressão regular simples
            Match match = Regex.Match(cursorDeclaration, @"DECLARE\s+(.*)\s+CURSOR", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value.Replace("-", "_").Trim() : "UnknownCursor";
        }

        private string GetTableName(string cursorDeclaration)
        {
            // Implementar lógica para extrair o nome da tabela
            // Neste exemplo, estamos usando uma expressão regular simples
            Match match = Regex.Match(cursorDeclaration, @"FROM\s+(\s|\S)+(\w+(?:\.\w+)*)\s+WHERE", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[0].Value?.Replace("WHERE", "").Replace("FROM", "").Trim() : "UnknownTable";
        }

        private string GetSelectClause(string cursorDeclaration)
        {
            // Implementar lógica para extrair a cláusula SELECT
            // Neste exemplo, estamos usando uma expressão regular simples
            var rex = Regex.Match(cursorDeclaration, @"EXEC\s+SQL\s+FETCH(\s+NEXT)*\s+\S+\s+INTO\s*(?<variables>\S+(\s+OF\s+\S+)*\s+)+END-EXEC.*");
            var variables = string.Join(" ", rex.Groups["variables"].Captures);
            variables = Regex.Replace(variables, @"\s*:", @" :");

            if (!string.IsNullOrWhiteSpace(variables))
                return variables;

            Match match = Regex.Match(cursorDeclaration, @"SELECT\s+(.*?)(?:FROM|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            return match.Success ? Regex.Replace(match.Groups[1].Value.Trim(), @"DISTINCT\s*\(\s*(?<inside>\S+)\s*\)", @"${inside}") : "*";
        }

        private string GetWhereClause(string cursorDeclaration)
        {
            // Implementar lógica para extrair a cláusula WHERE
            // Neste exemplo, estamos usando uma expressão regular simples
            var match = Regex.Match(cursorDeclaration, @"FROM\s+(.*?)(?:WITH|:END-EXEC|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!match.Success) return "";

            var ret = match.Groups[1].Value.Trim();

            var dotRex = Regex.Matches(ret, @":\s*\S+", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!dotRex.Any())
                return ret;

            foreach (Match item in dotRex)
            {
                var originalCode = item.Value.Replace(")", "");
                var varName = H.GetReferenceProperty(originalCode, Result);
                var newVarName = varName?.PropertyName;
                if (varName == null)
                    newVarName = originalCode.Replace(":", "").Replace("-", "_");

                var replaceFor = $"{{{newVarName}}}";
                if (varName?.PropertyType == "StringBasis")
                    replaceFor = $"'{replaceFor}'";

                ret = ret.Replace(originalCode, replaceFor);
            }

            return ret;
        }

        private List<string> GetSqlColumnsCSharpNamed(string cursorName, string selectClause)
        {
            var output = new List<string>();

            // Use regex para extrair os nomes das colunas
            //var matches = Regex.Matches(selectClause, @"(\w+(\s*\,|$))");
            var matches = selectClause.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var match in matches)
            {
                var colHandler = match.Replace(".", "_").Replace(",", "").Trim(); // Substituir "." por "_"
                if (Regex.IsMatch(colHandler, @"^CASE\s+"))
                    colHandler = Regex.Match(colHandler, @"^CASE\s+\S+").Value.Replace(" ", "_");

                var columnName = colHandler;
                output.Add(columnName);
            }

            return output;
        }

        public string GenerateSQLCopy(CurrentLineType cursorDeclaration, string cursorName, string translatedSql, bool internalDeclare, string selectClause, List<string> wheresColumns)
        {
            // Use regex para extrair os nomes das colunas
            var columns = GetSqlColumnsCSharpNamed(cursorName, selectClause);
            if (columns.Count == 0) return "";

            var cursorClassName = $"{Result.programName}_{cursorName}";

            //IDivisionCommand.Result.DclReference.Add(cursorName, new ReferenceModel(cursorName, cursorName, true));

            // Criar a string SQL para a classe
            var sqlCopyBuilder = new StringBuilder();
            if (!internalDeclare)
                sqlCopyBuilder.AppendLine($"\npublic {cursorClassName} {cursorName} {{ get; set; }} = new {cursorClassName}({(wheresColumns.Count() > 0 ? "true" : "false")});");
            else
                sqlCopyBuilder.AppendLine($"{cursorName} = new {cursorClassName}({(wheresColumns.Count() > 0 ? "true" : "false")});");

            sqlCopyBuilder.Append(@$"string GetQuery_{cursorName}()
                {{
                    var query = @$""{translatedSql}"";

                    return query;
                }}
                {(internalDeclare ? $"{cursorName}.GetQueryEvent += GetQuery_{cursorName};" : "")}");

            var db2Class = new StringBuilder();
            db2Class.AppendLine($"public class {cursorClassName} : QueryBasis<{cursorClassName}>");
            db2Class.AppendLine("{");


            db2Class.AppendLine($"    [JsonIgnore] public bool JustACursor {{ get; set; }} = false;");
            db2Class.AppendLine(@"
                public delegate string GetQueryDelegateHandler();
                public event GetQueryDelegateHandler GetQueryEvent;
            ");

            db2Class.AppendLine("//ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )");
            db2Class.AppendLine($"public {cursorClassName}() {{ IsCursor = true; }}");
            db2Class.AppendLine("");
            db2Class.AppendLine(@$"public {cursorClassName}(bool justACursor)
            {{
                JustACursor = justACursor;
                IsCursor = true;
            }}");
            db2Class.AppendLine("");

            if (!Result.DclReference.ContainsKey(cursorName))
                Result.DclReference.Add(cursorName, new ReferenceModel($"{cursorName}", cursorClassName, true, dCLColumns: columns, nameSpace: "Dcl"));
            else
                Result.DclReference[cursorName].DCLColumns = columns;

            Result.DclReference[cursorName].CurrentLine = cursorDeclaration.Line;
            foreach (var col in columns)
            {
                foreach (var item in col.Trim().Split(" "))
                {
                    var columnName = item.Trim().Split(" ").FirstOrDefault().Replace("+", "_").Replace("-", "_").Replace(":", "");
                    if (!IsValidColumnName(columnName) || db2Class.ToString().Contains($"string {columnName} "))
                    {
                        //old
                        //db2Class.AppendLine($"//    public string {columnName} {{ get; set; }}");
                        continue;
                    }

                    db2Class.AppendLine($"    public string {columnName} {{ get; set; }}");
                    //CopybookConverter.LocalPropertyReferences.Add(columnName, new ReferenceModel($"{cursorName}.{columnName}", cursorName, false));
                }
            }

            db2Class.AppendLine(@"
            public new void Open()
            {
                if (!IsProcedure)
                    SetQuery(GetQueryEvent());
                base.Open();
            }
            ");

            db2Class.AppendLine(@"
            public new bool Fetch()
            {
                if(!JustACursor)
                {
                    var idx = CurrentIndex;
                    Open();
                    CurrentIndex = idx > -1 ? idx : 0;
                }

                return base.Fetch();
            }
            ");

            db2Class.AppendLine("");
            db2Class.AppendLine($"public override {cursorClassName} OpenData(List<KeyValuePair<string, object>> result)");
            db2Class.AppendLine($"{{");
            db2Class.AppendLine($"var dta = new {cursorClassName}();");
            db2Class.AppendLine($"var i = 0;");
            db2Class.AppendLine("");

            var tstLst = new List<string>();
            var nameCount = new Dictionary<string, int>();

            for (int i = 0; i < columns.Count; i++)
            {
                var columnName = columns[i];
                var splitted = columnName.Trim().Replace("+", "_").Replace("-", "_").Replace(":", "").Split(" ");
                columnName = splitted.FirstOrDefault();

                // Verifica se o nome é inválido ou já foi adicionado ao db2Class
                bool isValid = IsValidColumnName(columnName);
                if (!isValid || db2Class.ToString().Contains($"dta.{columnName} ="))
                {
                    if (isValid)
                    {
                        db2Class.AppendLine($"dta.{columnName} = result[i++].Value?.ToString();");
                        // Contagem para nome final em tstLst
                        if (!nameCount.ContainsKey(columnName))
                            nameCount[columnName] = 0;
                        else
                            nameCount[columnName]++;

                        string tstName = columnName;
                        if (nameCount[columnName] > 0)
                            tstName = columnName + nameCount[columnName];

                        tstLst.Add(tstName);
                    }

                    continue;
                }

                // Contagem para nome final em tstLst
                if (!nameCount.ContainsKey(columnName))
                    nameCount[columnName] = 0;
                else
                    nameCount[columnName]++;

                string tstFinalName = columnName;
                if (nameCount[columnName] > 0)
                    tstFinalName = columnName + nameCount[columnName];

                if (isValid)
                {
                    db2Class.AppendLine($"dta.{columnName} = result[i++].Value?.ToString();");
                    tstLst.Add(tstFinalName);

                    if (splitted.Length == 2)
                    {
                        var rightPart = splitted[1].Split(".").LastOrDefault()?.Replace("-", "_");
                        var leftPart = columnName.Split(".").LastOrDefault();
                        db2Class.AppendLine($"dta.{rightPart} = string.IsNullOrWhiteSpace(dta.{leftPart}) ? \"-1\" : \"0\";");
                    }
                }
            }




            db2Class.AppendLine("");
            db2Class.AppendLine($"return dta;");
            db2Class.AppendLine($"}}");
            db2Class.AppendLine("\n}");

            db2ClassNames.Add(cursorClassName, db2Class.ToString());

            if ((!internalDeclare && !translatedSql.IsEmpty()) || Result?.CurrentMethod != null)
                Result.AddSqlTest(cursorClassName, Result?.CurrentMethod?.NameWithoutSection, tstLst, SqlTestType.CURSOR);

            return sqlCopyBuilder.ToString();
        }

        private bool IsValidColumnName(string columnName)
        {
            return !Regex.IsMatch(columnName, @"^\d+");
        }
        #endregion
    }
}
