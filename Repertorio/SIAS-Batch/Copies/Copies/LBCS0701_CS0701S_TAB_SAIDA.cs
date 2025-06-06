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
    public class LBCS0701_CS0701S_TAB_SAIDA : VarBasis
    {
        /*"      15   CS0701S-TB-CLASSE           PIC  X(015)*/
        public StringBasis CS0701S_TB_CLASSE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"      15   CS0701S-TB-SISTEMA          PIC  X(005)*/
        public StringBasis CS0701S_TB_SISTEMA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"      15   CS0701S-TB-PRODUTO          PIC  S9(004) COMP*/
        public IntBasis CS0701S_TB_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      15   CS0701S-TB-PARAM            PIC  S9(004) COMP*/
        public IntBasis CS0701S_TB_PARAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      15   CS0701S-TB-STATUS           PIC  S9(004) COMP*/
        public IntBasis CS0701S_TB_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      15   CS0701S-TB-IND-TP-PARAM     PIC  S9(004) COMP*/
        public IntBasis CS0701S_TB_IND_TP_PARAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      15   CS0701S-TB-DTINIVIG         PIC  X(010)*/
        public StringBasis CS0701S_TB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"      15   CS0701S-TB-DTTERVIG         PIC  X(010)*/
        public StringBasis CS0701S_TB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"      15   CS0701S-TB-DESCRICAO        PIC  X(100)*/
        public StringBasis CS0701S_TB_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"      15   CS0701S-TB-VALOR-DEC        PIC  S9(013)V9(2) COMP-3*/
        public DoubleBasis CS0701S_TB_VALOR_DEC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"      15   CS0701S-TB-VALOR-INT        PIC  S9(015)      COMP-3*/
        public IntBasis CS0701S_TB_VALOR_INT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"      15   CS0701S-TB-VALOR-PCT        PIC  S9(005)V9(2) COMP-3*/
        public DoubleBasis CS0701S_TB_VALOR_PCT { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(2)"), 2);
        /*"      15   CS0701S-TB-VALOR-TAXA       PIC  S9(003)V9(9) COMP-3*/
        public DoubleBasis CS0701S_TB_VALOR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
        /*"      15   CS0701S-TB-VALOR-DATA       PIC   X(010)*/
        public StringBasis CS0701S_TB_VALOR_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"      15   CS0701S-TB-VALOR-CHAR-RED   PIC   X(015)*/
        public StringBasis CS0701S_TB_VALOR_CHAR_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"      15   CS0701S-TB-VALOR-CHAR-EXT   PIC   X(060)*/
        public StringBasis CS0701S_TB_VALOR_CHAR_EXT { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        /*"  05       CS0701S-COD-RETORNO         PIC  S9(004) COMP*/
    }
}