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
    public class APOLIAUT_DCLAPOLICE_AUTO : VarBasis
    {
        /*"    10 APOLIAUT-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis APOLIAUT_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLIAUT-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis APOLIAUT_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLIAUT-TIPO-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_TIPO_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-COD-FABRICANTE       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_FABRICANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-COD-VEICULO       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_VEICULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-TIPO-COMBUSTIVEL       PIC X(1).*/
        public StringBasis APOLIAUT_TIPO_COMBUSTIVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-ANO-FABRICACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_ANO_FABRICACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-ANO-MODELO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_ANO_MODELO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-COR-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_COR_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-CAPACIDADE-VEICULO       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_CAPACIDADE_VEICULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-LOTACAO-VEICULO       PIC X(1).*/
        public StringBasis APOLIAUT_LOTACAO_VEICULO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-PLACA-UF    PIC X(2).*/
        public StringBasis APOLIAUT_PLACA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 APOLIAUT-PLACA-LETRA       PIC X(3).*/
        public StringBasis APOLIAUT_PLACA_LETRA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 APOLIAUT-PLACA-NUMERO       PIC X(4).*/
        public StringBasis APOLIAUT_PLACA_NUMERO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 APOLIAUT-NUM-CHASSIS       PIC X(20).*/
        public StringBasis APOLIAUT_NUM_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 APOLIAUT-TIPO-UTILIZACAO       PIC X(1).*/
        public StringBasis APOLIAUT_TIPO_UTILIZACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-QTD-ACESSORIOS       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_QTD_ACESSORIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-DATA-BAIXA  PIC X(10).*/
        public StringBasis APOLIAUT_DATA_BAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLIAUT-COD-VISTORIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_VISTORIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-NOME-PROPRIETARIO       PIC X(40).*/
        public StringBasis APOLIAUT_NOME_PROPRIETARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 APOLIAUT-DATA-INIVIG-EXTENS       PIC X(10).*/
        public StringBasis APOLIAUT_DATA_INIVIG_EXTENS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLIAUT-COD-ACEITACAO       PIC X(1).*/
        public StringBasis APOLIAUT_COD_ACEITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-NUM-PRM-RESSEGURO       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_NUM_PRM_RESSEGURO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-NUM-PROTOCOLO-SINI       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-SIT-REGISTRO       PIC X(1).*/
        public StringBasis APOLIAUT_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLIAUT-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLIAUT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 APOLIAUT-TIPO-MOVIMENTO       PIC X(1).*/
        public StringBasis APOLIAUT_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-ZEROKM      PIC X(1).*/
        public StringBasis APOLIAUT_ZEROKM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-SEGURAD-BONUS       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_SEGURAD_BONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-FIDEL-AUTO  PIC X(1).*/
        public StringBasis APOLIAUT_FIDEL_AUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-FIDEL-VIDA  PIC X(1).*/
        public StringBasis APOLIAUT_FIDEL_VIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-FIDEL-PREV  PIC X(1).*/
        public StringBasis APOLIAUT_FIDEL_PREV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-DANOS-MORAIS       PIC X(1).*/
        public StringBasis APOLIAUT_DANOS_MORAIS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-SEG-MERC-DET       PIC X(1).*/
        public StringBasis APOLIAUT_SEG_MERC_DET { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-ADIC-VLR-MERCADO       PIC X(1).*/
        public StringBasis APOLIAUT_ADIC_VLR_MERCADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-PERFIL      PIC X(1).*/
        public StringBasis APOLIAUT_PERFIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-DESPEXTR    PIC X(1).*/
        public StringBasis APOLIAUT_DESPEXTR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-VLNOVO      PIC X(1).*/
        public StringBasis APOLIAUT_VLNOVO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-CODDESPEXTR       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_CODDESPEXTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-DESPEXTR-PT       PIC X(1).*/
        public StringBasis APOLIAUT_DESPEXTR_PT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-PERC-VARIACAO-IS       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_PERC_VARIACAO_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLIAUT-CANAL-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-TIPO-COBRANCA       PIC X(1).*/
        public StringBasis APOLIAUT_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-NUM-PROPOSTA-CONV       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_NUM_PROPOSTA_CONV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLIAUT-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLIAUT-NUM-RENAVAM       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_NUM_RENAVAM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLIAUT-COD-IDENTIFICACAO       PIC X(20).*/
        public StringBasis APOLIAUT_COD_IDENTIFICACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 APOLIAUT-COD-CI      PIC X(16).*/
        public StringBasis APOLIAUT_COD_CI { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
        /*"    10 APOLIAUT-NUM-CONTRATO-CONV       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_NUM_CONTRATO_CONV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLIAUT-NUM-RECIBO-CONV       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLIAUT_NUM_RECIBO_CONV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLIAUT-COD-IDENT-PEP       PIC X(1).*/
        public StringBasis APOLIAUT_COD_IDENT_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLIAUT-IND-REL-CLI-PROPR       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_IND_REL_CLI_PROPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-IND-USO-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_IND_USO_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-IND-ORIGEM-PROP       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_IND_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-COD-CONGENERE       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIAUT-COD-CBO-CONV       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_CBO_CONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-COD-ATIVIDADE-CONV       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIAUT_COD_ATIVIDADE_CONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIAUT-IND-TP-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIAUT_IND_TP_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}