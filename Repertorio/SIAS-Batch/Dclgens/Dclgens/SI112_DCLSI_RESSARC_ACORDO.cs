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
    public class SI112_DCLSI_RESSARC_ACORDO : VarBasis
    {
        /*"    10 SI112-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI112_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI112-NUM-RESSARC    PIC S9(9) USAGE COMP.*/
        public IntBasis SI112_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI112-SEQ-RESSARC    PIC S9(4) USAGE COMP.*/
        public IntBasis SI112_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI112-COD-SISTEMA-ORIGEM  PIC S9(4) USAGE COMP.*/
        public IntBasis SI112_COD_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI112-IND-PESSOA-ACORDO  PIC X(1).*/
        public StringBasis SI112_IND_PESSOA_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI112-NUM-CPFCGC-ACORDO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SI112_NUM_CPFCGC_ACORDO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SI112-NOM-RESP-ACORDO  PIC X(40).*/
        public StringBasis SI112_NOM_RESP_ACORDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SI112-STA-ACORDO     PIC X(1).*/
        public StringBasis SI112_STA_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI112-DTH-ACORDO     PIC X(10).*/
        public StringBasis SI112_DTH_ACORDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI112-QTD-PARCELAS   PIC S9(4) USAGE COMP.*/
        public IntBasis SI112_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI112-COD-CONDICAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI112_COD_CONDICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI112-VLR-INDENIZACAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI112_VLR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI112-DTH-INDENIZACAO  PIC X(10).*/
        public StringBasis SI112_DTH_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI112-VLR-PART-TERCEIROS  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI112_VLR_PART_TERCEIROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI112-COD-MOEDA-ACORDO  PIC S9(4) USAGE COMP.*/
        public IntBasis SI112_COD_MOEDA_ACORDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI112-VLR-DIVIDA     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI112_VLR_DIVIDA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI112-PCT-DESCONTO   PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SI112_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SI112-VLR-TOTAL-ACORDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI112_VLR_TOTAL_ACORDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI112-COD-FORNECEDOR  PIC S9(9) USAGE COMP.*/
        public IntBasis SI112_COD_FORNECEDOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI112-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis SI112_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI112-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis SI112_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI112-DTH-CANCELA-ACORDO  PIC X(10).*/
        public StringBasis SI112_DTH_CANCELA_ACORDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
    }
}