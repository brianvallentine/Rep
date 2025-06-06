using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Xml.Linq;
using IA_ConverterCommons;
using FileResolver.Helper;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_CopiesDeclarationCommand : ICSharpCommand
    {
        public int Order { get; set; } = 23;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = CopiesDeclaration(csharpCode);
            return ret;
        }

        StringBuilder CopiesDeclaration(StringBuilder csharpCode)
        {
            var allCopies = Result.ALLCopiesReference.Where(x => x.Key != "SQLCA" && x.Key != "SQLCODE" && x.Key != "SQLERRMC" && x.Key != "SQLSTATE" && x.Key != "SQLCAID" && x.Key != "SQLERRD" && x.Key != "SQLCABC" && x.Key != "SQLWARN");
            var jumpFirstLine = true;
            foreach (var item in allCopies)
            {
                if (item.Value.PropertyName == item.Value.PropertyParent)
                {
                    var nameToPlace = "";
                    if (item.Value.Namespace == "Dcl")
                        nameToPlace = FileResolverHelper.Conf.ProjectDclName + ".";
                    else if (item.Value.Namespace == "Copy")
                        nameToPlace = FileResolverHelper.Conf.ProjectCopyName + ".";

                    var propType = $"{nameToPlace}{item.Value.PropertyType}";

                    csharpCode.AppendLine($"{(jumpFirstLine ? "\n" : "")}\tpublic {propType} {item.Key} {{ get; set; }} = new {propType}();");
                    jumpFirstLine = false;
                }
            }

            return csharpCode;
        }

    }
}
