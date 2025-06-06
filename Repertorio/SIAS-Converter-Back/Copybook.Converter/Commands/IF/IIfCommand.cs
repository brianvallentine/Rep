using CobolLanguageConverter.Converter.DIVISION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CobolLanguageConverter.Converter.Commands.IF
{
    internal interface IIfCommand
    {
        public int Order { get; set; }
        public CurrentLineType? CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        public string Execute(string line, ref Dictionary<string, string> markedList);
    }
}   