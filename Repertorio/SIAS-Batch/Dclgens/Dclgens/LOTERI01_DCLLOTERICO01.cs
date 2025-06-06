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
    public class LOTERI01_DCLLOTERICO01 : VarBasis
    {
        /*"    10 LOTERI01-COD-LOT-FENAL       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-COD-LOT-CEF       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTERI01_COD_LOT_CEF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTERI01-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-OPCAO-DEP   PIC X(1).*/
        public StringBasis LOTERI01_OPCAO_DEP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTERI01-DTINIVIG    PIC X(10).*/
        public StringBasis LOTERI01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-DTTERVIG    PIC X(10).*/
        public StringBasis LOTERI01_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-FORMA-PAGTO       PIC X(1).*/
        public StringBasis LOTERI01_FORMA_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTERI01-NUM-CONTROLE-FENAL       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_NUM_CONTROLE_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-SITUACAO    PIC X(1).*/
        public StringBasis LOTERI01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTERI01-BANCO       PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-AGENCIA     PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-NUMERO-CONTA       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTERI01_NUMERO_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTERI01-DV-CONTA    PIC X(1).*/
        public StringBasis LOTERI01_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTERI01-DATA-GERA-MOV       PIC X(10).*/
        public StringBasis LOTERI01_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-SINDICATO   PIC X(3).*/
        public StringBasis LOTERI01_SINDICATO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 LOTERI01-TIMESTAMP   PIC X(26).*/
        public StringBasis LOTERI01_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 LOTERI01-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTERI01_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTERI01-DES-EMAIL   PIC X(50).*/
        public StringBasis LOTERI01_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 LOTERI01-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTERI01_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTERI01-DATA-QUITACAO       PIC X(10).*/
        public StringBasis LOTERI01_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-TAXA-VLR-INICIAL       PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis LOTERI01_TAXA_VLR_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 LOTERI01-TAXA-VLR-ATUAL       PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis LOTERI01_TAXA_VLR_ATUAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 LOTERI01-DESC-SIN-ACUM       PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis LOTERI01_DESC_SIN_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 LOTERI01-NOME-FANTASIA       PIC X(30).*/
        public StringBasis LOTERI01_NOME_FANTASIA { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 LOTERI01-NUM-PVCEF   PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_NUM_PVCEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-NUM-ENCEF   PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_NUM_ENCEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-ENDERECO    PIC X(40).*/
        public StringBasis LOTERI01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 LOTERI01-COMPL-ENDERECO       PIC X(15).*/
        public StringBasis LOTERI01_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 LOTERI01-BAIRRO      PIC X(20).*/
        public StringBasis LOTERI01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 LOTERI01-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-CIDADE      PIC X(20).*/
        public StringBasis LOTERI01_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 LOTERI01-SIGLA-UF    PIC X(2).*/
        public StringBasis LOTERI01_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 LOTERI01-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-NUM-FONE    PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis LOTERI01_NUM_FONE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 LOTERI01-NUM-FAX     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis LOTERI01_NUM_FAX { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 LOTERI01-COD-CANCELAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_COD_CANCELAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-DATA-CANCELAMENTO       PIC X(10).*/
        public StringBasis LOTERI01_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-COD-CLASSE-ADESAO       PIC X(1).*/
        public StringBasis LOTERI01_COD_CLASSE_ADESAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTERI01-COD-MUNICIPIO       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_COD_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-QTD-PARCELAS       PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-PCT-JUROS   PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis LOTERI01_PCT_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 LOTERI01-IND-RENOVACAO       PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_IND_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-NUM-CLASSE  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTERI01_NUM_CLASSE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTERI01-DTH-INIVIG-CLASSE       PIC X(10).*/
        public StringBasis LOTERI01_DTH_INIVIG_CLASSE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-DTH-TERVIG-CLASSE       PIC X(10).*/
        public StringBasis LOTERI01_DTH_TERVIG_CLASSE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTERI01-IND-REGIAO  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_IND_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTERI01-STA-SEGURADO       PIC S9(4) USAGE COMP.*/
        public IntBasis LOTERI01_STA_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}