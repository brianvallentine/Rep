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
    public class LBLT3201_TABELA_DESCONTO_RET : VarBasis
    {
        /*"           20 LT3201-COD-DESC-RET       PIC S9(004)      COMP*/
        public IntBasis LT3201_COD_DESC_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"           20 LT3201-PCT-DESC-RET       PIC S9(003)V9(4) COMP*/
        public DoubleBasis LT3201_PCT_DESC_RET { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"           20 LT3201-VLR-DESC-RET       PIC S9(010)V9(2) COMP*/
        public DoubleBasis LT3201_VLR_DESC_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"  05  LT3201-TABELA-PREMIOS*/
    }
}