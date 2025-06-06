using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CobolLanguageConverter.Converter.CSHARP
{
    internal interface ICSharpCommand
    {
        public int Order { get; set; }
        public ResultSet Result { get; set; }
        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines);
    }
}