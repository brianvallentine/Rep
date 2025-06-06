using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using FileResolver.Helper;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_ReadCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);
            var q = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            try
            {
                if (Result.IsIn.Any(x => x.Contains("READ_")))
                {
                    //rotina de NOT AT END do read
                    if (Regex.IsMatch(line, @"NOT\s+(AT\s+)*END"))
                    {
                        //se houver AT END finaliza
                        if (Result.IsIn.Any(x => x.Contains("READ_AT_END_")))
                        {
                            //remove o controle de AT END e adiciona o controle de NOT AT END
                            var inn = Result.IsIn.LastOrDefault(x => x.Contains("READ_AT_END_"));
                            var splited = inn.Replace("READ_AT_END_", "").Trim().Split(" ");
                            var fileName = splited[0];
                            var atEndName = splited.Length > 1 ? splited[1].Trim() : "";

                            Result.IsIn.Remove(inn);

                            var key = $"READ_NOT_AT_END_{fileName} {atEndName}";
                            Result.IsIn.Add(key);

                            output.AppendLine($@"}}, () => {{");

                            response.Executed = true;
                        }
                    }

                    //aqui termina todo método do READ aberto
                    if (line.Trim().EndsWith(".") || Regex.IsMatch(line, @"END-READ"))
                    {
                        var inn = Result.IsIn.LastOrDefault(x => x.Contains("READ_NOT_AT_END_"));
                        var splited = inn?.Replace("READ_NOT_AT_END_", "").Trim().Split(" ");
                        var fileName = splited?[0];
                        var atEndName = splited?.Length > 1 ? splited[1].Trim() : "";

                        if (inn != null)
                            Result.IsIn.Remove(inn);
                        else
                        {
                            inn = Result.IsIn.LastOrDefault(x => x.Contains("READ_AT_END_"));
                            splited = inn?.Replace("READ_AT_END_", "").Trim().Split(" ");
                            fileName = splited?[0];
                            atEndName = splited?.Length > 1 ? splited[1].Trim() : "";

                            Result.IsIn.Remove(inn);
                        }

                        response.AfterExecuted = "});\n\n";

                        if (!string.IsNullOrEmpty(atEndName))
                            response.AfterExecuted += $"{q}.Move({fileName}.Value,{H.GetReferenceProperty(atEndName, Result, true)?.PropertyName});";

                        var relatives = Result.FileSelectReference.Where(x => x.Key.Contains(fileName.Replace("-", "_") + "_RELATIVE")).ToList();

                        foreach (var item in relatives)
                        {
                            response.AfterExecuted += $"{q}.Move({fileName}.Value,{H.GetReferenceProperty(item.Value, Result, true)?.PropertyName});" + Environment.NewLine;
                        }

                        response.AfterExecuted += $@"
                            }}
                            catch (GoToException ex)
                            {{
                                return;
                            }}";

                        //ocorreu um erro na conversão quando Read ficava dentro do IF, houve um erro com brackets
                        //se tiver "ponto" o conjunto de IF acabou
                        if (line.Contains("."))
                        {
                            var ifCount = Result.IfControl.Count(x => x == "IF");
                            if (ifCount > 0)
                            {
                                response.AfterExecuted += string.Join(Environment.NewLine, new string('}', ifCount));
                                Result.IfControl.Clear();
                            }
                        }



                        response.Executed = true;
                    }
                }

                if (line.StartsWith("READ "))
                {
                    var match = Regex.Match(line, @"READ\s+(?<variable>\S+)(\s+INTO\s+(?<intoVar>\S+(\s+OF\s+\S+)*))*(?<isAtEnd>\s+AT\s+END)*");
                    if (match.Success)
                    {
                        var varname = match.Groups["variable"].Value.Replace("-", "_").TrimEnd('.');
                        var intoVar = match.Groups["intoVar"].Value.Replace("-", "_").TrimEnd('.');
                        var hasIntoVar = !string.IsNullOrWhiteSpace(intoVar);
                        var isAtEnd = !string.IsNullOrEmpty(match.Groups["isAtEnd"].Value);

                        var findRelativeFile = Result.FileSelectReference.FirstOrDefault(x => x.Key.Contains(varname.Replace("-", "_") + "_RELATIVE"));
                        if (findRelativeFile.Key == null) throw new Exception($"variavel relativa não encontrada! VAR:> {varname.Replace("-", "_")}");

                        var fileName = Regex.Replace(findRelativeFile.Key, @"_RELATIVE\d+", "");

                        if (!isAtEnd)
                        {
                            output.AppendLine($"{fileName}.Read();");
                            if (hasIntoVar)
                                output.AppendLine($"{q}.Move({fileName}.Value,{H.GetReferenceProperty(intoVar, Result, true)?.PropertyName});");
                        }
                        else
                        {
                            var key = $"READ_AT_END_{fileName} {intoVar}";

                            //Add IsIn para fechar o bloco
                            if (!Result.IsIn.Contains(key))
                                Result.IsIn.Add(key);

                            output.AppendLine($@"try
                            {{
                                {fileName}.Read(() => {{");
                        }

                        response.Executed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }
    }
}
