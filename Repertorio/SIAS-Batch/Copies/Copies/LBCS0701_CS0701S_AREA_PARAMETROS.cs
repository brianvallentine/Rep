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
    public class LBCS0701_CS0701S_AREA_PARAMETROS : VarBasis
    {
        /*"  05       CS0701S-OPERACAO            PIC X(002)*/
        public StringBasis CS0701S_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"  05       CS0701S-COD-PARAM           PIC S9(004)       COMP*/
        public IntBasis CS0701S_COD_PARAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       CS0701S-CLASSE-PARAM        PIC X(015)*/
        public StringBasis CS0701S_CLASSE_PARAM { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"  05       CS0701S-COD-SISTEMA         PIC X(005)*/
        public StringBasis CS0701S_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"  05       CS0701S-COD-PRODUTO         PIC S9(004)       COMP*/
        public IntBasis CS0701S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       CS0701S-DATA-INIVIGENCIA    PIC  X(010)*/
        public StringBasis CS0701S_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       CS0701S-DATA-TERVIGENCIA    PIC  X(010)*/
        public StringBasis CS0701S_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       CS0701S-TIPO-PARAM          PIC  S9(004)      COMP*/
        public IntBasis CS0701S_TIPO_PARAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       CS0701S-STATUS              PIC  S9(004)      COMP*/
        public IntBasis CS0701S_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       CS0701S-VALOR-DEC           PIC  S9(013)V9(2) COMP-3*/
        public DoubleBasis CS0701S_VALOR_DEC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"  05       CS0701S-VALOR-INT           PIC  S9(015)      COMP-3*/
        public IntBasis CS0701S_VALOR_INT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"  05       CS0701S-VALOR-PCT           PIC  S9(005)V9(2) COMP-3*/
        public DoubleBasis CS0701S_VALOR_PCT { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(2)"), 2);
        /*"  05       CS0701S-VALOR-TAXA          PIC  S9(003)V9(9) COMP-3*/
        public DoubleBasis CS0701S_VALOR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
        /*"  05       CS0701S-VALOR-DT            PIC  X(010)*/
        public StringBasis CS0701S_VALOR_DT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       CS0701S-VALOR-DESC          PIC  X(060)*/
        public StringBasis CS0701S_VALOR_DESC { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        /*"  05       CS0701S-DESCRICAO           PIC  X(100)*/
        public StringBasis CS0701S_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  05       CS0701S-TABELA-SAIDA*/
        public LBCS0701_CS0701S_TABELA_SAIDA CS0701S_TABELA_SAIDA { get; set; } = new LBCS0701_CS0701S_TABELA_SAIDA();

        public IntBasis CS0701S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       CS0701S-MSG-RETORNO         PIC  X(070)*/
        public StringBasis CS0701S_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
    }
}