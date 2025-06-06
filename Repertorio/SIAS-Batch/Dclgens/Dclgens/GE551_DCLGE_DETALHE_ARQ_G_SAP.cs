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
    public class GE551_DCLGE_DETALHE_ARQ_G_SAP : VarBasis
    {
        /*"    10 GE551-COD-LOTE-G     PIC X(24).*/
        public StringBasis GE551_COD_LOTE_G { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE551-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE551_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE551-SEQ-REGISTRO-LOTE-G       PIC S9(9) USAGE COMP.*/
        public IntBasis GE551_SEQ_REGISTRO_LOTE_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE551-SEQ-REGISTRO-LOTE-A       PIC S9(9) USAGE COMP.*/
        public IntBasis GE551_SEQ_REGISTRO_LOTE_A { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE551-COD-ID-PAGAM-COBR       PIC X(40).*/
        public StringBasis GE551_COD_ID_PAGAM_COBR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE551-DTA-PROCESSAMENTO-ECC       PIC X(10).*/
        public StringBasis GE551_DTA_PROCESSAMENTO_ECC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE551-COD-CHAVE-SAP  PIC X(33).*/
        public StringBasis GE551_COD_CHAVE_SAP { get; set; } = new StringBasis(new PIC("X", "33", "X(33)."), @"");
        /*"    10 GE551-COD-DOCTO-BELNR       PIC X(10).*/
        public StringBasis GE551_COD_DOCTO_BELNR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE551-COD-DOCTO-OPBEL       PIC X(12).*/
        public StringBasis GE551_COD_DOCTO_OPBEL { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 GE551-COD-EVENTO     PIC X(10).*/
        public StringBasis GE551_COD_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE551-DTA-DOCTO-ORIGINAL       PIC X(10).*/
        public StringBasis GE551_DTA_DOCTO_ORIGINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE551-DTA-LANC-CONTABIL       PIC X(10).*/
        public StringBasis GE551_DTA_LANC_CONTABIL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE551-STA-PROCESSAMENTO       PIC X(1).*/
        public StringBasis GE551_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE551-STA-ENVIO-BANCO       PIC X(1).*/
        public StringBasis GE551_STA_ENVIO_BANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE551-STA-CONSUMO-SOLICITANTE       PIC X(1).*/
        public StringBasis GE551_STA_CONSUMO_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE551-NUM-BOLETO-INTERNO-SAP       PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis GE551_NUM_BOLETO_INTERNO_SAP { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 GE551-NUM-BOLETO-REGISTRADO       PIC S9(18) USAGE COMP.*/
        public IntBasis GE551_NUM_BOLETO_REGISTRADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE551-COD-LINHA-DIGITAVEL       PIC X(54).*/
        public StringBasis GE551_COD_LINHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(54)."), @"");
        /*"    10 GE551-COD-CEDENTE-BOLETO       PIC X(20).*/
        public StringBasis GE551_COD_CEDENTE_BOLETO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE551-VLR-TOTAL-BOLETO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE551_VLR_TOTAL_BOLETO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}