using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class GE332_DCLGE_DNE_FAIXA_UF : VarBasis
    {
        /*"    10 GE332-COD-UF         PIC X(2).*/
        public StringBasis GE332_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE332-COD-INI-CEP    PIC X(8).*/
        public StringBasis GE332_COD_INI_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE332-COD-FIM-CEP    PIC X(8).*/
        public StringBasis GE332_COD_FIM_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}