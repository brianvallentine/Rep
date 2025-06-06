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
    public class FORNECED_DCLFORNECEDORES : VarBasis
    {
        /*"    10 FORNECED-TIPO-REGISTRO       PIC X(1).*/
        public StringBasis FORNECED_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-COD-FORNECEDOR       PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_COD_FORNECEDOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-NOME-FORNECEDOR       PIC X(40).*/
        public StringBasis FORNECED_NOME_FORNECEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FORNECED-ENDERECO    PIC X(40).*/
        public StringBasis FORNECED_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FORNECED-BAIRRO      PIC X(20).*/
        public StringBasis FORNECED_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 FORNECED-CIDADE      PIC X(20).*/
        public StringBasis FORNECED_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 FORNECED-SIGLA-UF    PIC X(2).*/
        public StringBasis FORNECED_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 FORNECED-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-TELEFONE    PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-INSC-PREFEITURA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_INSC_PREFEITURA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FORNECED-INSC-ESTADUAL       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_INSC_ESTADUAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FORNECED-INSC-INPS   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_INSC_INPS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FORNECED-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FORNECED-TIPO-PESSOA       PIC X(1).*/
        public StringBasis FORNECED_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-PCT-DESC-ISS       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FORNECED_PCT_DESC_ISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FORNECED-DATA-CADASTRAMENTO       PIC X(10).*/
        public StringBasis FORNECED_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FORNECED-IND-DESC-IRF       PIC X(1).*/
        public StringBasis FORNECED_IND_DESC_IRF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-SIT-REGISTRO       PIC X(1).*/
        public StringBasis FORNECED_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-FAX         PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-TELEX       PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-PCT-DESC-IRF       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FORNECED_PCT_DESC_IRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FORNECED-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-TIMESTAMP   PIC X(26).*/
        public StringBasis FORNECED_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FORNECED-NUM-RECIBO  PIC S9(9) USAGE COMP.*/
        public IntBasis FORNECED_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FORNECED-IDENT-ADIC-IRF       PIC X(1).*/
        public StringBasis FORNECED_IDENT_ADIC_IRF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-NUM-CTA-CORRENTE       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 FORNECED-CLASSE-INSS       PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_CLASSE_INSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-SITUACAO-INSS       PIC X(1).*/
        public StringBasis FORNECED_SITUACAO_INSS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-IND-DESC-ISS       PIC X(1).*/
        public StringBasis FORNECED_IND_DESC_ISS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-NUM-DEPENDENTE-IRF       PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_NUM_DEPENDENTE_IRF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-COD-SERVICO-ISS       PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_COD_SERVICO_ISS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-IND-DESC-INSS       PIC X(1).*/
        public StringBasis FORNECED_IND_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-PCT-DESC-INSS       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FORNECED_PCT_DESC_INSS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FORNECED-COD-USUARIO-CC       PIC X(8).*/
        public StringBasis FORNECED_COD_USUARIO_CC { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FORNECED-COD-USUARIO-AU       PIC X(8).*/
        public StringBasis FORNECED_COD_USUARIO_AU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FORNECED-DATA-ALT-CC       PIC X(10).*/
        public StringBasis FORNECED_DATA_ALT_CC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FORNECED-DATA-ALT-AU       PIC X(10).*/
        public StringBasis FORNECED_DATA_ALT_AU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FORNECED-TIPO-PRESTSERV       PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_TIPO_PRESTSERV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-NOME-CONTATO       PIC X(40).*/
        public StringBasis FORNECED_NOME_CONTATO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FORNECED-COD-REGIAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FORNECED_COD_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FORNECED-VAL-NREGIAO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_VAL_NREGIAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FORNECED-VAL-FREGIAO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FORNECED_VAL_FREGIAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FORNECED-ATENDE-TERCEIROS       PIC X(1).*/
        public StringBasis FORNECED_ATENDE_TERCEIROS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-OPT-SIMPLES-FED       PIC X(1).*/
        public StringBasis FORNECED_OPT_SIMPLES_FED { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-DATA-NASCIMENTO       PIC X(10).*/
        public StringBasis FORNECED_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FORNECED-INV-PERMANENTE       PIC X(1).*/
        public StringBasis FORNECED_INV_PERMANENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-DV-AGENCIA  PIC X(1).*/
        public StringBasis FORNECED_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-OPT-SIMPLES-MUN       PIC X(1).*/
        public StringBasis FORNECED_OPT_SIMPLES_MUN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FORNECED-DES-EMAIL   PIC X(100).*/
        public StringBasis FORNECED_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"*/
    }
}