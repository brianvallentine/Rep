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
    public class GE403_DCLGE_CONTROLE_EMISSAO_SIGCB : VarBasis
    {
        /*"    10 GE403-NUM-PROPOSTA   PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 GE403-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE403-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE403_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE403-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE403-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE403_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE403-SEQ-CONTROLE-SIGCB       PIC S9(4) USAGE COMP.*/
        public IntBasis GE403_SEQ_CONTROLE_SIGCB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE403-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE403-NUM-IDLG       PIC X(40).*/
        public StringBasis GE403_NUM_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE403-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE403_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE403-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE403_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE403-DTA-VENCIMENTO       PIC X(10).*/
        public StringBasis GE403_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE403-VLR-PREMIO-TOTAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE403_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE403-VLR-IOF        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE403_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE403-QTD-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE403_QTD_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE403-QTD-DIAS-CUSTODIA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE403_QTD_DIAS_CUSTODIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE403-COD-CLIENTE    PIC S9(9) USAGE COMP.*/
        public IntBasis GE403_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE403-COD-CEDENTE-SAP       PIC X(20).*/
        public StringBasis GE403_COD_CEDENTE_SAP { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE403-NUM-BOLETO-INTERNO       PIC S9(10)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_BOLETO_INTERNO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V"), 0);
        /*"    10 GE403-NUM-NOSSO-NUMERO-SAP       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_NOSSO_NUMERO_SAP { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE403-COD-LINHA-DIGITAVEL       PIC X(54).*/
        public StringBasis GE403_COD_LINHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(54)."), @"");
        /*"    10 GE403-NUM-TITULO     PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis GE403_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 GE403-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE403_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE403-COD-USUARIO    PIC X(8).*/
        public StringBasis GE403_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE403-COD-SITUACAO   PIC X(1).*/
        public StringBasis GE403_COD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE403-DTH-PROCESSAMENTO       PIC X(26).*/
        public StringBasis GE403_DTH_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}