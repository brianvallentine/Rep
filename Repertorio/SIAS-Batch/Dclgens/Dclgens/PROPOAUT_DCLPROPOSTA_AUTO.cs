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
    public class PROPOAUT_DCLPROPOSTA_AUTO : VarBasis
    {
        /*"    10 PROPOAUT-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis PROPOAUT_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOAUT-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis PROPOAUT_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOAUT-TIPO-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_TIPO_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-COD-FABRICANTE       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_FABRICANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-COD-VEICULO       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_VEICULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-TIPO-COMBUSTIVEL       PIC X(1).*/
        public StringBasis PROPOAUT_TIPO_COMBUSTIVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-ANO-FABRICACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_ANO_FABRICACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-ANO-MODELO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_ANO_MODELO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-COR-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_COR_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-CAPACIDADE-VEICULO       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_CAPACIDADE_VEICULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-LOTACAO-VEICULO       PIC X(1).*/
        public StringBasis PROPOAUT_LOTACAO_VEICULO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-PLACA-UF    PIC X(2).*/
        public StringBasis PROPOAUT_PLACA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PROPOAUT-PLACA-LETRA       PIC X(3).*/
        public StringBasis PROPOAUT_PLACA_LETRA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PROPOAUT-PLACA-NUMERO       PIC X(4).*/
        public StringBasis PROPOAUT_PLACA_NUMERO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 PROPOAUT-NUM-CHASSIS       PIC X(20).*/
        public StringBasis PROPOAUT_NUM_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PROPOAUT-TIPO-UTILIZACAO       PIC X(1).*/
        public StringBasis PROPOAUT_TIPO_UTILIZACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-QTD-ACESSORIOS       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_QTD_ACESSORIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-DATA-BAIXA  PIC X(10).*/
        public StringBasis PROPOAUT_DATA_BAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOAUT-COD-VISTORIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_VISTORIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-NOME-PROPRIETARIO       PIC X(40).*/
        public StringBasis PROPOAUT_NOME_PROPRIETARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PROPOAUT-DATA-INIVIG-EXTENS       PIC X(10).*/
        public StringBasis PROPOAUT_DATA_INIVIG_EXTENS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOAUT-COD-ACEITACAO       PIC X(1).*/
        public StringBasis PROPOAUT_COD_ACEITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-NUM-PRM-RESSEGURO       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_NUM_PRM_RESSEGURO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-NUM-PROTOCOLO-SINI       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-SIT-REGISTRO       PIC X(1).*/
        public StringBasis PROPOAUT_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPOAUT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPOAUT-TIPO-MOVIMENTO       PIC X(1).*/
        public StringBasis PROPOAUT_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-ZEROKM      PIC X(1).*/
        public StringBasis PROPOAUT_ZEROKM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-SEGURAD-BONUS       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_SEGURAD_BONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-FIDEL-AUTO  PIC X(1).*/
        public StringBasis PROPOAUT_FIDEL_AUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-FIDEL-VIDA  PIC X(1).*/
        public StringBasis PROPOAUT_FIDEL_VIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-FIDEL-PREV  PIC X(1).*/
        public StringBasis PROPOAUT_FIDEL_PREV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-DANOS-MORAIS       PIC X(1).*/
        public StringBasis PROPOAUT_DANOS_MORAIS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-SEG-MERC-DET       PIC X(1).*/
        public StringBasis PROPOAUT_SEG_MERC_DET { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-ADIC-VLR-MERCADO       PIC X(1).*/
        public StringBasis PROPOAUT_ADIC_VLR_MERCADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-PERFIL      PIC X(1).*/
        public StringBasis PROPOAUT_PERFIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-DESPEXTR    PIC X(1).*/
        public StringBasis PROPOAUT_DESPEXTR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-VLNOVO      PIC X(1).*/
        public StringBasis PROPOAUT_VLNOVO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-CODDESPEXTR       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_CODDESPEXTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-DESPEXTR-PT       PIC X(1).*/
        public StringBasis PROPOAUT_DESPEXTR_PT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-PERC-VARIACAO-IS       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOAUT_PERC_VARIACAO_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PROPOAUT-CANAL-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-TIPO-COBRANCA       PIC X(1).*/
        public StringBasis PROPOAUT_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-NUM-PROPOSTA-CONV       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOAUT_NUM_PROPOSTA_CONV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOAUT-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOAUT_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOAUT-NUM-RENAVAM       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOAUT_NUM_RENAVAM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOAUT-COD-CI      PIC X(16).*/
        public StringBasis PROPOAUT_COD_CI { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
        /*"    10 PROPOAUT-NUM-CONTRATO-CONV       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOAUT_NUM_CONTRATO_CONV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOAUT-NUM-RECIBO-CONV       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOAUT_NUM_RECIBO_CONV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOAUT-COD-IDENT-PEP       PIC X(1).*/
        public StringBasis PROPOAUT_COD_IDENT_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOAUT-IND-REL-CLI-PROPR       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_IND_REL_CLI_PROPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-IND-ORIGEM-PROP       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_IND_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-COD-CONGENERE       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-COD-CBO-CONV       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_CBO_CONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-COD-ATIVIDADE-CONV       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOAUT_COD_ATIVIDADE_CONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOAUT-IND-USO-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_IND_USO_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOAUT-DTH-PROP-EFETIVACAO       PIC X(26).*/
        public StringBasis PROPOAUT_DTH_PROP_EFETIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPOAUT-IND-TP-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOAUT_IND_TP_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}