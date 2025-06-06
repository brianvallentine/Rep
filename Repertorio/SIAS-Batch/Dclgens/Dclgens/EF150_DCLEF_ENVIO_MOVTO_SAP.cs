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
    public class EF150_DCLEF_ENVIO_MOVTO_SAP : VarBasis
    {
        /*"    10 EF150-NUM-OCORR-MOVTO       PIC S9(9) USAGE COMP.*/
        public IntBasis EF150_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF150-NUM-CONTRATO-SEGUR       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF150_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF150-SEQ-PREMIO     PIC S9(9) USAGE COMP.*/
        public IntBasis EF150_SEQ_PREMIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF150-NOM-ARQUIVO    PIC X(8).*/
        public StringBasis EF150_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EF150-NUM-CONTR-TERC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF150_NUM_CONTR_TERC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF150-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis EF150_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 EF150-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF150_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF150-NUM-PESSOA-ODS       PIC S9(9) USAGE COMP.*/
        public IntBasis EF150_NUM_PESSOA_ODS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF150-VLR-RESTITUIR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF150_VLR_RESTITUIR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 EF150-VLR-PREMIO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF150_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 EF150-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis EF150_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EF150-COD-USUARIO    PIC X(8).*/
        public StringBasis EF150_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EF150-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis EF150_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 EF150-NUM-PEDIDO-CANCEL       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF150_NUM_PEDIDO_CANCEL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF150-ID-VLR-RESTIT-ALT       PIC X(1).*/
        public StringBasis EF150_ID_VLR_RESTIT_ALT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF150-DTA-SOLICITA-SAP       PIC X(10).*/
        public StringBasis EF150_DTA_SOLICITA_SAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF150-DTA-RETORNO-SAP       PIC X(10).*/
        public StringBasis EF150_DTA_RETORNO_SAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF150-COD-DEVOLUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis EF150_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF150-STA-SITUACAO-SAP       PIC X(1).*/
        public StringBasis EF150_STA_SITUACAO_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF150-STA-ENVIO-REL  PIC X(1).*/
        public StringBasis EF150_STA_ENVIO_REL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}