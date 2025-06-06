//using Cobol.Converter;
//using Copybook.Converter;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace CobolLanguageConverter.Converter.CobolDivisions
//{
//    public class CobolLinkageSectionCode
//    {
//        public string ConvertLinkageSection(string sectionCode)
//        {
//            var splited = sectionCode.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

//            //Commom copy
//            foreach (var line in splited)
//            {
//                if (line.Trim().StartsWith("COPY "))
//                {
//                    var spLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
//                    CopybookConverter.copyLinkageReferences.Add(spLine[1].Replace(".", ""));
//                }
//            }

//            var copybookConverter = new CopybookConverter("", "", true);
//            var convertedCode = copybookConverter.ConvertCopybookToCSharpAllText(sectionCode, false);

//            //return sectionCode + "\n\n" + convertedCode;
//            //TODO: a linkage pode ter variaveis, tratar ...
//            return "";
//        }
//    }
//}
