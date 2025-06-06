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
    public class GE407_DCLGE_CONTROLE_CARTAO_CIELO : VarBasis
    {
        /*"    10 GE407-NUM-PROPOSTA   PIC S9(18) USAGE COMP.*/
        public IntBasis GE407_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE407-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis GE407_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE407-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE407_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE407-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis GE407_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE407-NUM-ENDOSSO    PIC S9(18) USAGE COMP.*/
        public IntBasis GE407_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE407-SEQ-CONTROL-CARTAO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE407_SEQ_CONTROL_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE407-COD-TP-PAGAMENTO       PIC X(2).*/
        public StringBasis GE407_COD_TP_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE407-COD-IDLG       PIC X(40).*/
        public StringBasis GE407_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE407-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE407_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE407-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE407_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE407-DTA-VENCIMENTO       PIC X(10).*/
        public StringBasis GE407_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE407-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE407_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE407-VLR-TOT-PREMIO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE407_VLR_TOT_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE407-COD-SISTEMA    PIC X(2).*/
        public StringBasis GE407_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE407-COD-USUARIO    PIC X(8).*/
        public StringBasis GE407_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE407-STA-REGISTRO   PIC X(1).*/
        public StringBasis GE407_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE407-DTH-PROCESSAMENTO       PIC X(26).*/
        public StringBasis GE407_DTH_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}