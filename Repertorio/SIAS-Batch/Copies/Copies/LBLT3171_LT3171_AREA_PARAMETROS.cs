using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBLT3171_LT3171_AREA_PARAMETROS : VarBasis
    {
        /*"    05       LT3171-NUM-LOTERICO           PIC S9(010)  COMP-3*/
        public IntBasis LT3171_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(010)"));
        /*"    05       LT3171-PRODUTO                PIC 9(004)*/
        public IntBasis LT3171_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05       LT3171-COD-RETORNO            PIC 9(005)*/
        public IntBasis LT3171_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"    05       LT3171-MSG-RETORNO            PIC X(050)*/
        public StringBasis LT3171_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
    }
}