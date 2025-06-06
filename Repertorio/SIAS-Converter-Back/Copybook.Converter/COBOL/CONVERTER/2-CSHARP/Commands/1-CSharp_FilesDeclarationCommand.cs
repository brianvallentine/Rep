using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text;
using Copybook.Converter;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using System.Text.RegularExpressions;
using FileResolver.Helper;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_FilesDeclarationCommand : ICSharpCommand
    {
        public int Order { get; set; } = 21;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = FilesDeclarationFileControl(csharpCode, ref divisionAndLines);
            ret = FilesDeclarationFileSectionFD(ret, ref divisionAndLines);
            ret = FilesDeclarationFileSectionSD(ret, ref divisionAndLines);
            return ret;
        }

        public StringBuilder FilesDeclarationFileControl(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = csharpCode;
            var considerList = Result.FileReference;

            if (!considerList.Any()) return ret;

            var inOutSection = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, @"INPUT-OUTPUT\s+SECTION"));
            if (inOutSection.Key == null)
                return csharpCode;

            for (var i = 0; i < inOutSection.Value.Count; i++)
            {
                var fileSecLine = inOutSection.Value[i].Line;
                if (!fileSecLine.Trim().StartsWith("SELECT"))
                    continue;

                var rex = Regex.Match(fileSecLine.Replace(Environment.NewLine, " "), @"SELECT\s+(?<varname>\S+)(\s+ASSIGN\s+TO\s+(?<filename>\w+))*(\s+.+(FILE\s+)*STATUS\s+(IS\s+)*(?<fileStatus>\S+))*");
                var varname = rex.Groups["varname"].Value.Replace("-", "_");
                var filename = rex.Groups["filename"].Value.Replace("-", "_");
                var fileStatus = rex.Groups["fileStatus"].Value.Replace("-", "_").TrimEnd('.');

                Result.FileAssignReference.Add(varname, filename);
                Result.FileSelectReference.Add($"{varname}_STATUS", fileStatus);

            }

            return ret;
        }

        public StringBuilder FilesDeclarationFileSectionSD(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = csharpCode;
            var considerList = Result.FileReference;

            var fileSection = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, @"FILE\s+SECTION"));
            if (fileSection.Key == null)
                return csharpCode;

            var varname = "";
            for (var i = 0; i < fileSection.Value.Count; i++)
            {
                var fileSecLine = fileSection.Value[i].Line;
                if (!fileSecLine.Trim().StartsWith("SD"))
                    continue;

                var rex = Regex.Match(fileSecLine.Replace(Environment.NewLine, " "), @"SD\s+(?<varname>\S+)\.");
                varname = rex.Groups["varname"].Value.Replace("-", "_").TrimEnd('.');

                var sortName = fileSection.Value.Skip(i + 1).FirstOrDefault()?.Line;
                var rexSortName = Regex.Match(sortName, @"\d+\s+(?<varType>\S+)\s*");
                var vartype = rexSortName.Groups["varType"].Value.TrimEnd('.');

                var sortType = H.GetReferenceProperty(vartype, Result).PropertyType;
                var sortDerivedType = $"SortBasis<{sortType}>";

                ret.AppendLine($"public {sortDerivedType} {varname} {{ get; set; }} = new {sortDerivedType}(new {sortType}());");

                Result.FileSelectReference.Add($"{varname}_ASSIGN", $"{varname}");
                var refModel = new ReferenceModel($"{varname}", sortDerivedType, true, nameSpace: "File");
                refModel.CurrentLine = fileSecLine;

                Result.FileReference.Add(varname, refModel);
            }

            return ret;
        }

        public StringBuilder FilesDeclarationFileSectionFD(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, string copyRef = "")
        {
            var ret = csharpCode;
            var considerList = Result.FileReference;

            var fileSection = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, @"FILE\s+SECTION"));
            if (fileSection.Key == null)
                return csharpCode;

            var searchNextVarLine = false;
            //var varname = "";
            FdModel fdModel = null;
            var alreadyAddedFileBasis = false;
            var relativeIndex = 0;

            for (var i = 0; i < fileSection.Value.Count; i++)
            {
                var fileSecLine = fileSection.Value[i].Line;

                //o arquivo pode estar dentro de um copybook
                if (fileSecLine.Trim().StartsWith("COPY"))
                {
                    var rex = Regex.Match(fileSecLine.Trim(), @"^COPY\s+(?<copyName>\S+)[.]*?");
                    if (!rex.Success) continue;

                    var copyNameOriginal = rex.Groups["copyName"].Value.TrimEnd('.');
                    var copyName = copyNameOriginal;
                    var fileDir = Path.Combine(Directory.GetCurrentDirectory(), FileResolverHelper.Conf.InputDirectory, "COPY");
                    var filePath = Path.Combine(fileDir, copyName);

                    if (!Directory.Exists(fileDir) || !File.Exists(filePath))
                    {
                        //alguns arquivos estão com .BKL
                        copyName += ".bkl";
                        filePath = Path.Combine(fileDir, copyName);
                        if (!Directory.Exists(fileDir) || !File.Exists(filePath))
                        {
                            ret.AppendLine($"/* Erro ao encontrar o local do arquivo de copy {copyName}");
                            continue;
                        }
                    }

                    var fileLines = File.ReadAllLines(filePath);
                    var validStringLines = fileLines.Where(x => x.Length > 6 && x[6] != '*').Select(x => x.Substring(7, (x.Length > 72 ? 72 : x.Length) - 7));
                    validStringLines = string.Join("", validStringLines).Split(".").Select(x => $"{x}.");
                    var validLines = validStringLines.Select(x => new CurrentLineType(x, fileSection.Value[i].LineNumber));

                    var lst = new Dictionary<string, List<CurrentLineType>>();
                    if (validLines.Any())
                        lst.Add("FILE SECTION", validLines.ToList());

                    ret = FilesDeclarationFileSectionFD(ret, ref lst, copyNameOriginal);
                    continue;
                }

                //se não for FD e ainda não entrou no search
                if (!fileSecLine.Trim().StartsWith("FD") && !searchNextVarLine)
                    continue;

                //se encontrar FD
                if (fileSecLine.Trim().StartsWith("FD") || fileSecLine.Trim().StartsWith("SD"))
                {
                    alreadyAddedFileBasis = false;
                    relativeIndex = 0;
                    searchNextVarLine = false;
                }

                //se não for FD e ainda não entrou no search
                if (fileSecLine.Trim().StartsWith("SD"))
                    continue;

                if (searchNextVarLine)
                {
                    var innerRex = Regex.Match(fileSecLine, @"^\d+\s+(?<varRegisterName>\S+)");
                    if (innerRex.Success)
                    {
                        var varRegisterName = innerRex.Groups["varRegisterName"].Value.Replace("-", "_").TrimEnd('.');
                        if (fdModel.Record?.Integer3Or4 == null)
                        {
                            var altLengthProp = H.GetReferenceProperty(varRegisterName, Result);
                            var altLength = 0;

                            if (altLengthProp.PIC != null)
                                altLength = altLengthProp.PIC.Length;

                            ret = ret.Replace("===ALT===", altLength.ToString());
                        }

                        var fileName = fdModel.FileName1.Replace("-", "_");
                        var localCopyRef = string.IsNullOrWhiteSpace(copyRef) ? "" : $"{copyRef}.";
                        if (!alreadyAddedFileBasis)
                        {
                            alreadyAddedFileBasis = true;

                            ret.Append($@"
                            public FileBasis {fileName}
                            {{
                                get {{ 
                                    _.Move({localCopyRef}{varRegisterName}, _{fileName}); VarBasis.RedefinePassValue({localCopyRef}{varRegisterName}, _{fileName}, {localCopyRef}{varRegisterName}); return _{fileName}; 
                                }}
                            }}
                        ");
                        }

                        Result.FileSelectReference.Add($"{fileName}_RELATIVE{relativeIndex++}", $"{localCopyRef}{varRegisterName}");
                    }
                    continue;
                }

                fdModel = GetFDModel(fileSecLine);

                var length = fdModel.Record?.Integer3Or4 ?? "===ALT===";
                ret.AppendLine($"public FileBasis _{fdModel.FileName1.Replace("-", "_")} {{ get; set; }} = new FileBasis(new PIC(\"X\", \"{length}\", \"X({length})\"));");

                searchNextVarLine = true;
            }

            return ret;
        }

        //https://www.cadcobol.com.br/cobol_data_division_fde_file_description_entries.htm
        public FdModel GetFDModel(string fileSecLine)
        {
            var lineToMask = fileSecLine.ToString();
            var markerList = new Dictionary<string, string>();

            //https://regex101.com/r/PfEz3R/2
            var fdExtGlob = Regex.Match(lineToMask.Replace(Environment.NewLine, " "), @"FD\s+(?<filename1>\S+)+\s*((?<isExternal>IS\s+EXTERNAL)*(?<isGlobal>\s*IS\s+GLOBAL)*)*");

            var fdModel = new FdModel();
            if (fdExtGlob.Success)
            {
                fdModel.FileName1 = fdExtGlob.Groups["filename1"].Value;
                fdModel.IsExternal = !string.IsNullOrEmpty(fdExtGlob.Groups["isExternal"].Value);
                fdModel.IsGlobal = !string.IsNullOrEmpty(fdExtGlob.Groups["isGlobal"].Value);
                lineToMask = lineToMask.Replace(fdExtGlob.Value.Trim(), H.Mark(lineToMask, ref markerList));
            }

            //https://regex101.com/r/IcnuPm/1
            var fdBlock = Regex.Match(lineToMask.Replace(Environment.NewLine, " "), @"(?<block>BLOCK\s+(?<blockContains>CONTAINS)*\s*(?<integer1>\S+\s+TO)*\s*(?<integer2>\S+)*\s*(?<records>(RECORDS|CHARACTERS))*)");
            if (fdBlock.Success)
            {
                fdModel.Block.HasBlock = !string.IsNullOrEmpty(fdBlock.Groups["block"].Value);
                fdModel.Block.HasBlockContains = !string.IsNullOrEmpty(fdBlock.Groups["blockContains"].Value);
                fdModel.Block.Integer1 = fdBlock.Groups["integer1"].Value;
                fdModel.Block.IsTo = !string.IsNullOrEmpty(fdBlock.Groups["integer1"].Value);
                fdModel.Block.Integer2 = fdBlock.Groups["integer2"].Value;
                fdModel.Block.IsRecords = fdBlock.Groups["records"].Value.Trim() == "RECORDS";
                fdModel.Block.IsCharacters = fdBlock.Groups["records"].Value.Trim() == "CHARACTERS";
                lineToMask = lineToMask.Replace(fdBlock.Value.Trim(), H.Mark(lineToMask, ref markerList));
            }

            //https://regex101.com/r/dV5ZYj/1
            var fdLabel = Regex.Match(lineToMask.Replace(Environment.NewLine, " "), @"(?<label>LABEL\s+(?<recordLabel>(RECORDS|RECORD)\s+(?<isAre>(ARE|IS)\s+)*(?<recordVar>(STANDARD|OMITTED|\S+)))+)");
            if (fdLabel.Success)
            {
                fdModel.Label.HasLabel = !string.IsNullOrEmpty(fdLabel.Groups["label"].Value);
                fdModel.Label.IsRecords = fdLabel.Groups["recordLabel"].Value.Trim() == "RECORDS";
                fdModel.Label.IsRecord = fdLabel.Groups["recordLabel"].Value.Trim() == "RECORD";
                fdModel.Label.IsAre = fdLabel.Groups["isAre"].Value.Trim() == "ARE";
                fdModel.Label.IsIs = fdLabel.Groups["isAre"].Value.Trim() == "IS";
                fdModel.Label.IsStandard = fdLabel.Groups["recordVar"].Value.Trim() == "STANDARD";
                fdModel.Label.IsOmitted = fdLabel.Groups["recordVar"].Value.Trim() == "OMITTED";
                fdModel.Label.RecordVar = fdLabel.Groups["recordVar"].Value;
                lineToMask = lineToMask.Replace(fdLabel.Value.Trim(), H.Mark(lineToMask, ref markerList));
            }

            //https://regex101.com/r/6243E1/1
            var fdRecord = Regex.Match(lineToMask.Replace(Environment.NewLine, " "), @"(?<record>RECORD\s+(?!OMITTED)+(?<contains>CONTAINS\s+)*((?<integer3Or4>\S+)+(\s*TO\s*(?<integer5>\S+))*)+(?<characters>\s*CHARACTERS)*)");
            if (fdRecord.Success)
            {
                fdModel.Record.HasRecord = !string.IsNullOrEmpty(fdRecord.Groups["record"].Value);
                fdModel.Record.HasContains = !string.IsNullOrEmpty(fdRecord.Groups["contains"].Value);
                fdModel.Record.Integer3Or4 = fdRecord.Groups["integer3Or4"].Value;
                fdModel.Record.IsTo = !string.IsNullOrEmpty(fdRecord.Groups["integer5"].Value);
                fdModel.Record.Integer5 = fdRecord.Groups["integer5"].Value;
                fdModel.Record.IsCharacters = !string.IsNullOrEmpty(fdRecord.Groups["characters"].Value);
                lineToMask = lineToMask.Replace(fdRecord.Value.Trim(), H.Mark(lineToMask, ref markerList));
            }

            return fdModel;
        }

    }

    public class FdModel
    {
        public string FileName1 { get; set; }
        public bool IsExternal { get; set; }
        public bool IsGlobal { get; set; }

        public FdBlock Block { get; set; } = new FdBlock();
        public FdRecord Record { get; set; } = new FdRecord();
        public FdLabel Label { get; set; } = new FdLabel();
    }

    public class FdLabel
    {
        public bool HasLabel { get; internal set; }
        public bool IsRecords { get; internal set; }
        public bool IsRecord { get; internal set; }
        public bool IsAre { get; internal set; }
        public bool IsIs { get; internal set; }
        public bool IsStandard { get; internal set; }
        public bool IsOmitted { get; internal set; }
        public string RecordVar { get; internal set; }
    }

    public class FdRecord
    {
        public bool HasRecord { get; set; }
        public bool HasContains { get; set; }
        public string Integer3Or4 { get; set; }
        public bool IsTo { get; set; }
        public string Integer5 { get; set; }
        public bool IsCharacters { get; set; }
    }

    public class FdBlock
    {
        public bool HasBlock { get; set; }
        public bool HasBlockContains { get; set; }
        public string Integer1 { get; set; }
        public bool IsTo { get; set; }
        public string Integer2 { get; set; }
        public bool IsRecords { get; set; }
        public bool IsCharacters { get; set; }
    }
}
