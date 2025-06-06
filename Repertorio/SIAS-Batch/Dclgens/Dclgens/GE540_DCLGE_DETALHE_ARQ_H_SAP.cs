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
    public class GE540_DCLGE_DETALHE_ARQ_H_SAP : VarBasis
    {
        /*"    10 GE540-NUM-NSA-SAP    PIC S9(9) USAGE COMP.*/
        public IntBasis GE540_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE540-SEQ-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE540_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE540-NUM-IDLG       PIC S9(18) USAGE COMP.*/
        public IntBasis GE540_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE540-COD-ID-PAGAM-COBR       PIC X(40).*/
        public StringBasis GE540_COD_ID_PAGAM_COBR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE540-COD-TIPO-REGISTRO       PIC X(2).*/
        public StringBasis GE540_COD_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-STA-COMPENSACAO       PIC X(1).*/
        public StringBasis GE540_STA_COMPENSACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE540-COD-MOTIVO-COMPENS       PIC X(2).*/
        public StringBasis GE540_COD_MOTIVO_COMPENS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-COD-FATURA-AP  PIC X(10).*/
        public StringBasis GE540_COD_FATURA_AP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE540-NUM-LANC-FATURA-AP       PIC S9(4) USAGE COMP.*/
        public IntBasis GE540_NUM_LANC_FATURA_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE540-COD-FATURA-CA  PIC X(12).*/
        public StringBasis GE540_COD_FATURA_CA { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 GE540-NUM-LANC-FATURA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE540_NUM_LANC_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE540-COD-COMPENS-CRED       PIC X(12).*/
        public StringBasis GE540_COD_COMPENS_CRED { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 GE540-DTA-LANC-COMPENS       PIC X(10).*/
        public StringBasis GE540_DTA_LANC_COMPENS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE540-COD-TIPO-DOCTO       PIC X(2).*/
        public StringBasis GE540_COD_TIPO_DOCTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-DTA-DOC-ORIGEM       PIC X(10).*/
        public StringBasis GE540_DTA_DOC_ORIGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE540-DTA-LANC-DOC-CONT       PIC X(10).*/
        public StringBasis GE540_DTA_LANC_DOC_CONT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE540-COD-EMPRESA    PIC X(4).*/
        public StringBasis GE540_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE540-NUM-NSA-BANCO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE540_NUM_NSA_BANCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE540-STA-CONSUMO-SOLICITANTE       PIC X(1).*/
        public StringBasis GE540_STA_CONSUMO_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE540-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE540_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE540-COD-BANCO      PIC S9(4) USAGE COMP.*/
        public IntBasis GE540_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE540-COD-DV-BANCO   PIC X(2).*/
        public StringBasis GE540_COD_DV_BANCO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE540_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE540-COD-DV-AGENCIA       PIC X(2).*/
        public StringBasis GE540_COD_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-COD-OPER-CAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE540_COD_OPER_CAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE540-NUM-CONTA-CORRENTE       PIC S9(18) USAGE COMP.*/
        public IntBasis GE540_NUM_CONTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE540-COD-DV-CONTA-CORRENTE       PIC X(2).*/
        public StringBasis GE540_COD_DV_CONTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-COD-CONVENIO-CEDENTE       PIC S9(18) USAGE COMP.*/
        public IntBasis GE540_COD_CONVENIO_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE540-COD-IDE-SISTEMA       PIC X(2).*/
        public StringBasis GE540_COD_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE540-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE540_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE540-STA-DEPOSITO-TER       PIC X(1).*/
        public StringBasis GE540_STA_DEPOSITO_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE540-STA-ACOMPANHAMENTO       PIC X(1).*/
        public StringBasis GE540_STA_ACOMPANHAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE540-COD-MODULO-SAP       PIC X(2).*/
        public StringBasis GE540_COD_MODULO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}