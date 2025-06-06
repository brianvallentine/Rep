using Copybook.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CobolLanguageConverter.Converter.DIVISION
{
    internal interface IConverterCommand
    {
        public int Order { get; set; }
        public ResultSet Result { get; set; }
        public string Execute(string line, ref Dictionary<string, List<CurrentLineType>> divisionAndLines);
    }
}