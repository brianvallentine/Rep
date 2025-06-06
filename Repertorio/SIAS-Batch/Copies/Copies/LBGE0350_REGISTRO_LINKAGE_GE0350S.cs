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
    public class LBGE0350_REGISTRO_LINKAGE_GE0350S : VarBasis
    {
        /*"    10 LK-GE350-COD-FUNCAO        PIC  9(02)*/
        public IntBasis LK_GE350_COD_FUNCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"    10 LK-GE350-NUM-PROPOSTA      PIC S9(16)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 LK-GE350-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 LK-GE350-NUM-PARCELA       PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-NUM-APOLICE       PIC S9(13)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LK-GE350-NUM-ENDOSSO       PIC S9(09) USAGE COMP*/
        public IntBasis LK_GE350_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"    10 LK-GE350-SEQ-CNTRLE-SIGCB  PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_SEQ_CNTRLE_SIGCB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-NUM-OCORR-MOVTO   PIC S9(18)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 LK-GE350-NUM-IDLG          PIC  X(40)*/
        public StringBasis LK_GE350_NUM_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"    10 LK-GE350-COD-PRODUTO       PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-DTA-MOVIMENTO     PIC  X(10)*/
        public StringBasis LK_GE350_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-DTA-VENCIMENTO    PIC  X(10)*/
        public StringBasis LK_GE350_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-VLR-PREMIO-TOTAL  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis LK_GE350_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LK-GE350-VLR-IOF           PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis LK_GE350_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LK-GE350-QTD-PARCELA       PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_QTD_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-QTD-DIAS-CUSTODIA PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_QTD_DIAS_CUSTODIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-COD-CLIENTE       PIC S9(09) USAGE COMP*/
        public IntBasis LK_GE350_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"    10 LK-GE350-COD-CEDENTE-SAP   PIC  X(20)*/
        public StringBasis LK_GE350_COD_CEDENTE_SAP { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
        /*"    10 LK-GE350-NUM-BLTO-INTERNO  PIC S9(10)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NUM_BLTO_INTERNO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V"), 0);
        /*"    10 LK-GE350-NOSSO-NUMERO-SAP  PIC S9(18)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NOSSO_NUMERO_SAP { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 LK-GE350-COD-LINHA-DGTVEL  PIC  X(54)*/
        public StringBasis LK_GE350_COD_LINHA_DGTVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"");
        /*"    10 LK-GE350-NUM-TITULO        PIC S9(16)V USAGE COMP-3*/
        public DoubleBasis LK_GE350_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 LK-GE350-IDE-SISTEMA       PIC  X(02)*/
        public StringBasis LK_GE350_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"    10 LK-GE350-COD-USUARIO       PIC  X(10)*/
        public StringBasis LK_GE350_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-COD-SITUACAO      PIC  X(01)*/
        public StringBasis LK_GE350_COD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    10 LK-GE350-DTA-VENC-CUSTODIA PIC  X(10)*/
        public StringBasis LK_GE350_DTA_VENC_CUSTODIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-COD-SISTEMA       PIC  X(10)*/
        public StringBasis LK_GE350_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-COD-EVENTO        PIC  X(10)*/
        public StringBasis LK_GE350_COD_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-COD-FONTE         PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-COD-CANAL         PIC S9(04) USAGE COMP*/
        public IntBasis LK_GE350_COD_CANAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    10 LK-GE350-NUM-CONTA-CNTRO   PIC  X(25)*/
        public StringBasis LK_GE350_NUM_CONTA_CNTRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
        /*"    10 LK-GE350-COD-TP-CONVENIO   PIC  X(01)*/
        public StringBasis LK_GE350_COD_TP_CONVENIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    10 LK-GE350-COD-REJEICAO      PIC  X(10)*/
        public StringBasis LK_GE350_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 LK-GE350-COD-RETORNO       PIC  X(01)*/
        public StringBasis LK_GE350_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    10 LK-GE350-MENSAGEM*/
        public LBGE0350_LK_GE350_MENSAGEM LK_GE350_MENSAGEM { get; set; } = new LBGE0350_LK_GE350_MENSAGEM();

    }
}