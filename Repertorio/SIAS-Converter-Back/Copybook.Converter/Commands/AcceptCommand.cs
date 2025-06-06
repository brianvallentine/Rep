using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class AcceptCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);
            var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            try
            {
                if (line.StartsWith("ACCEPT "))
                {
                    //Accept From Time Exactly
                    var match = Regex.Match(line, @"ACCEPT\s+(?<variable>\S+)\s+FROM\s+(?<model>\S+)(?<format>\s+\S+)*\.*");
                    if (!match.Success) return response;

                    var variable = match.Groups["variable"].Value.TrimEnd('.');
                    var model = match.Groups["model"].Value.TrimEnd('.');
                    var format = match.Groups["format"].Value.Trim().TrimEnd('.');
                    var reffer = H.GetReferenceName(variable, Result);
                    var isSysin = model.Trim() == "SYSIN";

                    if (model.Trim() == "SYSIN")
                    {
                        output.AppendLine("/*-Accept convertido para parametro de entrada...*/");
                        response.Executed = true;
                    }
                    else
                    if (!string.IsNullOrEmpty(reffer))
                    {
                        output.AppendLine($@"{qf}.Move({qf}.AcceptDate(""{model}""{(string.IsNullOrEmpty(format) ? "" : $",{format}")}),{reffer});");
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
