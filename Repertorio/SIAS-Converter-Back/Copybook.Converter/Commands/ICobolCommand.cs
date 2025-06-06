using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobolLanguageConverter.Converter.Commands
{
    public interface ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }
        public CobolCommandResponse Execute(string line);
    }
}
