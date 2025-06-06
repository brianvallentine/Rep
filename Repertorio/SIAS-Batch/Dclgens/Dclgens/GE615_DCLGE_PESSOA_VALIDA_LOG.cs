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
    public class GE615_DCLGE_PESSOA_VALIDA_LOG : VarBasis
    {
        /*"    10 GE615-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis GE615_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE615-SEQ-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE615_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE615-NUM-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-COD-PRODUTO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE615_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE615-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis GE615_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE615-NUM-CERTIFICADO-EXT       PIC S9(18) USAGE COMP.*/
        public IntBasis GE615_NUM_CERTIFICADO_EXT { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE615-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis GE615_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE615-NUM-ENDOSSO    PIC S9(18) USAGE COMP.*/
        public IntBasis GE615_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE615-NUM-SINISTRO   PIC S9(18) USAGE COMP.*/
        public IntBasis GE615_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE615-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-COD-OPER-SINISTRO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_COD_OPER_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-NOM-SEGURADO   PIC X(70).*/
        public StringBasis GE615_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"    10 GE615-COD-CARGO      PIC S9(9) USAGE COMP.*/
        public IntBasis GE615_COD_CARGO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE615-DES-CARGO      PIC X(70).*/
        public StringBasis GE615_DES_CARGO { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"    10 GE615-NOM-ORGAO      PIC X(70).*/
        public StringBasis GE615_NOM_ORGAO { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"    10 GE615-COD-RELACAO-EXTERNO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_COD_RELACAO_EXTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-IND-TP-RELAC-INTERNO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_IND_TP_RELAC_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-IND-TIPO-PESSOA       PIC X(1).*/
        public StringBasis GE615_IND_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE615-IND-MOVIMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_IND_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-IND-EVENTO     PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_IND_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-DTA-INCLUSAO   PIC X(10).*/
        public StringBasis GE615_DTA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE615-STA-REGISTRO   PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_STA_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-COD-ORIGEM     PIC S9(4) USAGE COMP.*/
        public IntBasis GE615_COD_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE615-COD-USUARIO    PIC X(8).*/
        public StringBasis GE615_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE615-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE615_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE615-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE615_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}