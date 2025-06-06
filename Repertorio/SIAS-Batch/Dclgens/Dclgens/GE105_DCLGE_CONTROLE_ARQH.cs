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
    public class GE105_DCLGE_CONTROLE_ARQH : VarBasis
    {
        /*"    10 GE105-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE105_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE105-SEQ-RETORNO-MOVIMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE105_SEQ_RETORNO_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE105-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE105_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE105-NUM-ESTRUTURA-ARQH       PIC S9(4) USAGE COMP.*/
        public IntBasis GE105_NUM_ESTRUTURA_ARQH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE105-STA-COMPENSACAO       PIC X(1).*/
        public StringBasis GE105_STA_COMPENSACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE105-NUM-NSAS-ARQH  PIC S9(9) USAGE COMP.*/
        public IntBasis GE105_NUM_NSAS_ARQH { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE105-IND-MOTIVO-COMPENSACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE105_IND_MOTIVO_COMPENSACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE105-COD-FATURA-SAP       PIC X(12).*/
        public StringBasis GE105_COD_FATURA_SAP { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 GE105-NUM-ITEM-FATURA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE105_NUM_ITEM_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE105-NUM-NSAS-BANCO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE105_NUM_NSAS_BANCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE105-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE105_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}