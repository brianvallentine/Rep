using Copybook.Converter;
using FileResolver.Model;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using static CobolLanguageConverter.Converter.CSHARP.CSharpCommand;

namespace CobolLanguageConverter.Converter.DIVISION
{
    public interface IDivisionCommand
    {
        public int Order { get; set; }
        public ResultSet Result { get; set; }
        public string Execute(string line, ref Dictionary<string, List<CurrentLineType>> divisionAndLines);
    }

    public enum CurrentMethodTypeEnum
    {
        SECTION = 0,
        PARAGRAPH
    }

    public class CurrentMethodType
    {
        public CurrentMethodType(string name, int lineNumber)
        {
            Name = name;
            LineNumber = lineNumber;
            MethodType = (name.EndsWith("_SECTION") || name.EndsWith("-SECTION")) ? CurrentMethodTypeEnum.SECTION : CurrentMethodTypeEnum.PARAGRAPH;
        }

        public string Name { get; set; }
        public string NameWithoutSection => Regex.Replace(Name.Trim(), @"_SECTION$", "");
        public int LineNumber { get; set; }
        public CurrentMethodTypeEnum MethodType { get; set; }
    }

    public class CurrentLineType
    {
        public CurrentLineType(string line, int lineNumber)
        {
            Line = line;
            LineNumber = lineNumber;
        }

        public string Line { get; set; }
        public int LineNumber { get; set; }
    }

    public class ResultSet
    {
        public string programName;  // Nova propriedade para armazenar o nome do programa
        public string module;  // Nova propriedade para armazenar o modulo do programa
        public CurrentMethodType? CurrentMethod { get; set; }
        public bool PassByValidLineFromAnotherProcess { get; set; }
        public bool IsCursorReturnProgram => CursorReturnName.Any();
        public List<string> CursorReturnName { get; set; } = new List<string>();

        public List<InternalMethodDelegate> WaitingFor { get; set; } = new List<InternalMethodDelegate>();

        /// <summary>
        /// contem as variaveis LIDAS DOS ARQUIVOS de Copy
        /// </summary>
        public Dictionary<string, ReferenceModel> CopybooksReference { get; set; } = new Dictionary<string, ReferenceModel>();

        /// <summary>
        /// contem as variaveis LIDAS DOS ARQUIVOS de Copy de DCLGEN
        /// </summary>
        public Dictionary<string, ReferenceModel> DclReference { get; set; } = new Dictionary<string, ReferenceModel>();
        public Dictionary<string, ReferenceModel> LinkageReference { get; set; } = new Dictionary<string, ReferenceModel>();
        public Dictionary<string, ReferenceModel> WorkingStorageReference { get; set; } = new Dictionary<string, ReferenceModel>();
        public Dictionary<string, ReferenceModel> FileReference { get; set; } = new Dictionary<string, ReferenceModel>();
        public Dictionary<string, SelectorBasis> SelectorsList { get; set; } = new Dictionary<string, SelectorBasis>();

        /// <summary>
        /// (nome_da_variavel_do_arquivo_STATUS, nome_da_variavel_de_status)
        /// (nome_da_variavel_do_arquivo_RELATIVE, nome_da_variavel_de_read)
        /// </summary>
        public Dictionary<string, string> FileSelectReference { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> FileAssignReference { get; set; } = new Dictionary<string, string>();
        public Dictionary<CurrentMethodType, List<CurrentLineType>> ProcedureReference { get; set; } = new Dictionary<CurrentMethodType, List<CurrentLineType>>();
        public List<MethodReferenceInfo> ApiMethodsReference { get; set; } = new List<MethodReferenceInfo>();


        public Dictionary<string, ReferenceModel> _allReference = new Dictionary<string, ReferenceModel>();
        public Dictionary<string, ReferenceModel> _allReferenceCache = new Dictionary<string, ReferenceModel>();

        public Dictionary<string, ReferenceModel> ALLReference => FileReference
                                        .Concat(WorkingStorageReference)
                                        .Concat(CopybooksReference)
                                        .Concat(DclReference)
                                        .Concat(LinkageReference)
                                        .OrderBy(x => x.Key.Length)
                                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        //{
        //    get
        //    {
        //        //se contagem for igual e contador > 0
        //        if (_allReference.Count == _allReferenceCache.Count && _allReferenceCache.Count > 0)
        //            return _allReference;

        //        _allReferenceCache = FileReference
        //                                .Concat(WorkingStorageReference)
        //                                .Concat(CopybooksReference)
        //                                .Concat(DclReference)
        //                                .Concat(LinkageReference)
        //                                .OrderByDescending(x => x.Key.Length)
        //                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        //        _allReference = _allReferenceCache;
        //        return _allReferenceCache;
        //    }
        //}


        public Dictionary<string, ReferenceModel> ALLWorkingReference => FileReference
                                                                    .Concat(WorkingStorageReference)
                                                                    .Concat(LinkageReference)
                                                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        public Dictionary<string, ReferenceModel> ALLCopiesReference => CopybooksReference
                                                                    .Concat(DclReference)
                                                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        public List<string> IsIn { get; set; } = new List<string>();

        public List<string> IfControl { get; set; } = new List<string>();

        public List<string> SqlInMethodCounter { get; set; } = new List<string>();

        public List<SqlTestManager> SqlToTest { get; set; } = new List<SqlTestManager>();
        public List<AnalisysMethodManager> MethodsToAnalise { get; set; } = new List<AnalisysMethodManager>();

        public Dictionary<string, string> ParametersReference { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> SQLLocatorsReference { get; set; } = new Dictionary<string, string>();

        public void AddSqlTest(string methodName, string? parentMethodName, List<string> fields, SqlTestType type = SqlTestType.SELECT)
        {
            SqlToTest.Add(new SqlTestManager(methodName, parentMethodName, fields, type));
        }
    }

    public class AnalisysMethodManager
    {
        public bool EntraceMethod { get; set; }
        public int Lines { get; set; }
        public string Name { get; set; }
        public bool IgnoredMethod => Obs == "Método ignorado por falta de comandos";
        public List<string> Parameters { get; set; } = new List<string>();
        public string Obs { get; set; }
        public List<string> Calls { get; set; } = new List<string>();
    }

    public class SqlTestManager
    {
        public string MethodName { get; set; }
        public string ParentMethodName { get; set; }
        public SqlTestType Type { get; set; }
        public List<string> Fields { get; set; } = new List<string>();

        public SqlTestManager(string methodName, string parentMethodName, List<string> fields, SqlTestType type)
        {
            MethodName = methodName;
            ParentMethodName = parentMethodName;
            Type = type;
            Fields = fields;
        }
    }

    public enum SqlTestType
    {
        SELECT,
        INSERT,
        UPDATE,
        DELETE,
        CURSOR,
        PROCEDURE,
    }
}