//using Copybook.Converter;
//using FileResolver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace CobolLanguageConverter.Converter.CobolDivisions
//{
//    public class CobolCodeSql
//    {
//        private Dictionary<string, string> db2ClassNames = new Dictionary<string, string>();

//        #region SQL
//        //public string ConvertWorkingStorageSqlSection(string cobolSqlCode)
//        //{
//        //    // Separar declarações de cursor
//        //    string[] cursorDeclarations = ExtractCursorDeclarations(cobolSqlCode);

//        //    // Converter declarações de cursor para SQL Dapper
//        //    string convertedSqlCode = ConvertCursorDeclarationsToDapper(cursorDeclarations);

//        //    foreach (var db2Class in db2ClassNames)
//        //    {
//        //        var generator = new FileGenerator();
//        //        generator.PushClassToDb2Folder(db2Class.Key, db2Class.Value);
//        //    }

//        //    return convertedSqlCode;
//        //}

//        //private string[] ExtractCursorDeclarations(string cobolSqlCode)
//        //{
//        //    // Utilizar expressão regular para encontrar declarações de cursor
//        //    string pattern = @"(?i)(EXEC\s+SQL)?(\DECLARE)(\s|\S)+?END-EXEC.";
//        //    Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
//        //    MatchCollection matches = regex.Matches(cobolSqlCode);

//        //    string[] cursorDeclarations = new string[matches.Count];
//        //    for (int i = 0; i < matches.Count; i++)
//        //    {
//        //        cursorDeclarations[i] = matches[i].Groups[0].Value.Trim();
//        //    }

//        //    return cursorDeclarations;
//        //}

//        //private string ConvertCursorDeclarationsToDapper(string[] cursorDeclarations)
//        //{
//        //    string convertedSqlCode = "";
//        //    foreach (string cursorDeclaration in cursorDeclarations)
//        //    {
//        //        // Mapear variáveis e tabela
//        //        string cursorName = GetCursorName(cursorDeclaration);
//        //        string tableName = GetTableName(cursorDeclaration);
//        //        string selectClause = GetSelectClause(cursorDeclaration);
//        //        string whereClause = GetWhereClause(cursorDeclaration);

//        //        // Criar método Dapper para execução do cursor
//        //        string translatedSql = GenerateNewSQLQuery(cursorName, selectClause, tableName, whereClause, cursorDeclaration);
//        //        translatedSql = translatedSql.Replace($"DECLARE {cursorName} CURSOR", "");
//        //        translatedSql = translatedSql.Replace($"WITH HOLD FOR", "");
//        //        translatedSql = translatedSql.Replace($"WITH HOLD", "");
//        //        translatedSql = translatedSql.Replace($"HOLD FOR", "");
//        //        translatedSql = translatedSql.Replace($"END-EXEC.", "");
//        //        translatedSql = translatedSql.Replace($"END-EXEC", "");
//        //        translatedSql = string.Join("\n", translatedSql.Split("\n").Select(x => x.Length > 6 ? x.Substring(7) : x));

//        //        string sqlCopy = GenerateSQLCopy(cursorName, selectClause, translatedSql);

//        //        // Adicionar ao código convertido
//        //        //convertedSqlCode += dapperMethod;
//        //        convertedSqlCode += sqlCopy;
//        //    }

//        //    return convertedSqlCode;
//        //}

//        //private string GetCursorName(string cursorDeclaration)
//        //{
//        //    // Implementar lógica para extrair o nome do cursor
//        //    // Neste exemplo, estamos usando uma expressão regular simples
//        //    Match match = Regex.Match(cursorDeclaration, @"DECLARE\s+(\w+)\s+CURSOR", RegexOptions.IgnoreCase);
//        //    return match.Success ? match.Groups[1].Value : "UnknownCursor";
//        //}

//        //private string GetTableName(string cursorDeclaration)
//        //{
//        //    // Implementar lógica para extrair o nome da tabela
//        //    // Neste exemplo, estamos usando uma expressão regular simples
//        //    Match match = Regex.Match(cursorDeclaration, @"FROM\s+(\s|\S)+(\w+(?:\.\w+)*)\s+WHERE", RegexOptions.IgnoreCase);
//        //    return match.Success ? match.Groups[0].Value?.Replace("WHERE", "").Replace("FROM", "").Trim() : "UnknownTable";
//        //}

//        //private string GetSelectClause(string cursorDeclaration)
//        //{
//        //    // Implementar lógica para extrair a cláusula SELECT
//        //    // Neste exemplo, estamos usando uma expressão regular simples
//        //    Match match = Regex.Match(cursorDeclaration, @"SELECT\s+(.*?)(?:FROM|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
//        //    return match.Success ? match.Groups[1].Value.Trim() : "*";
//        //}

//        //private string GetWhereClause(string cursorDeclaration)
//        //{
//        //    // Implementar lógica para extrair a cláusula WHERE
//        //    // Neste exemplo, estamos usando uma expressão regular simples
//        //    Match match = Regex.Match(cursorDeclaration, @"WHERE\s+(.*?)(?:WITH|:END-EXEC|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
//        //    return match.Success ? match.Groups[1].Value.Trim() : "";
//        //}

//        //private string GenerateNewSQLQuery(string cursorName, string selectClause, string tableName, string whereClause, string fullSql)
//        //{
//        //    // Implementar lógica para gerar o método Dapper
//        //    // Neste exemplo, estamos usando uma formatação simples
//        //    //var output = "";
//        //    //if (!whereClause.Contains(":"))
//        //    //{
//        //    //    output = @$"SELECT {selectClause} {"\n"}FROM {tableName} {"\n"}WHERE {whereClause}";
//        //    //}

//        //    return fullSql;
//        //}

//        //private List<string> GetSqlColumnsCSharpNamed(string cursorName, string selectClause)
//        //{
//        //    var output = new List<string>();

//        //    // Use regex para extrair os nomes das colunas
//        //    var matches = Regex.Matches(selectClause, @"(\w+\.\w+)");

//        //    foreach (Match match in matches)
//        //    {
//        //        var columnName = match.Value.Replace(".", "_"); // Substituir "." por "_"
//        //        output.Add(columnName);
//        //    }

//        //    return output;
//        //}

//        //private string GenerateSQLCopy(string cursorName, string selectClause, string translatedSql)
//        //{
//        //    // Use regex para extrair os nomes das colunas
//        //    var columns = GetSqlColumnsCSharpNamed(cursorName, selectClause);
//        //    if (columns.Count == 0) return "";

//        //    //CopybookConverter.LocalPropertyReferences.Add(cursorName, new ReferenceModel(cursorName, cursorName, true));

//        //    // Criar a string SQL para a classe
//        //    var sqlCopyBuilder = new StringBuilder();
//        //    sqlCopyBuilder.AppendLine($"\npublic {cursorName} {cursorName} {{ get; set; }} = new {cursorName}(@\"{translatedSql}\");");

//        //    var db2Class = new StringBuilder();
//        //    db2Class.AppendLine($"public class {cursorName} : QueryBasis<{cursorName}>");
//        //    db2Class.AppendLine("{");
//        //    db2Class.AppendLine("//ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )");
//        //    db2Class.AppendLine($"public {cursorName}() {{}}");
//        //    db2Class.AppendLine("");
//        //    db2Class.AppendLine($"public {cursorName}(string query) : base(query){{}}");
//        //    db2Class.AppendLine("");

//        //    foreach (var columnName in columns)
//        //    {
//        //        db2Class.AppendLine($"    public string {columnName} {{ get; set; }}");
//        //        //CopybookConverter.LocalPropertyReferences.Add(columnName, new ReferenceModel($"{cursorName}.{columnName}", cursorName, false));
//        //    }

//        //    db2Class.AppendLine("");
//        //    db2Class.AppendLine($"public override {cursorName} OpenData(List<KeyValuePair<string, object>> result)");
//        //    db2Class.AppendLine($"{{");
//        //    db2Class.AppendLine($"var dta = new {cursorName}();");
//        //    for (int i = 0; i < columns.Count; i++)
//        //    {
//        //        var columnName = columns[i];
//        //        db2Class.AppendLine("");
//        //        db2Class.AppendLine($"dta.{columnName} = result[{i}].Value?.ToString();");
//        //    }
//        //    db2Class.AppendLine($"return dta;");
//        //    db2Class.AppendLine($"}}");
//        //    db2Class.AppendLine("\n}");
//        //    db2ClassNames.Add(cursorName, db2Class.ToString());

//        //    return sqlCopyBuilder.ToString();
//        //}
//        #endregion
//    }
//}
