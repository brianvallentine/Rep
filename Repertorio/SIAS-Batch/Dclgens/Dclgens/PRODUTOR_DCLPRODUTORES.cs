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
    public class PRODUTOR_DCLPRODUTORES : VarBasis
    {
        /*"    10 PRODUTOR-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTOR-COD-PRODUTOR       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_PRODUTOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-TIPO-PRODUTOR       PIC X(1).*/
        public StringBasis PRODUTOR_TIPO_PRODUTOR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUTOR-NOME-PRODUTOR       PIC X(40).*/
        public StringBasis PRODUTOR_NOME_PRODUTOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PRODUTOR-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PRODUTOR-COD-HIERARQUIA       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_HIERARQUIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-NOME-CONTATO       PIC X(40).*/
        public StringBasis PRODUTOR_NOME_CONTATO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PRODUTOR-ENDERECO    PIC X(40).*/
        public StringBasis PRODUTOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PRODUTOR-BAIRRO      PIC X(20).*/
        public StringBasis PRODUTOR_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PRODUTOR-CIDADE      PIC X(20).*/
        public StringBasis PRODUTOR_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PRODUTOR-SIGLA-UF    PIC X(2).*/
        public StringBasis PRODUTOR_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PRODUTOR-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTOR_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTOR-TELEFONE    PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-TELEX       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-REGISTRO-SUSEP       PIC X(13).*/
        public StringBasis PRODUTOR_REGISTRO_SUSEP { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
        /*"    10 PRODUTOR-TITULO-HABILITA       PIC X(12).*/
        public StringBasis PRODUTOR_TITULO_HABILITA { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 PRODUTOR-RAMO-VIDA   PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_RAMO_VIDA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PRODUTOR-INSC-PREFEITURA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_INSC_PREFEITURA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PRODUTOR-INSC-INPS   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_INSC_INPS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PRODUTOR-TIPO-PESSOA       PIC X(1).*/
        public StringBasis PRODUTOR_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUTOR-IND-DESC-IRF       PIC X(1).*/
        public StringBasis PRODUTOR_IND_DESC_IRF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUTOR-PCT-DESC-ISS       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_PCT_DESC_ISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PRODUTOR-NOME-PROCURADOR       PIC X(40).*/
        public StringBasis PRODUTOR_NOME_PROCURADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PRODUTOR-PRACA-PAGAMENTO       PIC X(20).*/
        public StringBasis PRODUTOR_PRACA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PRODUTOR-COD-BANGO   PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_BANGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTOR-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTOR-NUM-CTA-CORRENTE       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 PRODUTOR-DAC-CTA-CORRENTE       PIC X(1).*/
        public StringBasis PRODUTOR_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUTOR-TAB-COMISSIONADO       PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTOR_TAB_COMISSIONADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTOR-BASE-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTOR_BASE_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTOR-APROVACAO-ALCADA       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_APROVACAO_ALCADA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-CHAPA-AUTORIZADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PRODUTOR_CHAPA_AUTORIZADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PRODUTOR-DATA-VIGENCIA       PIC X(10).*/
        public StringBasis PRODUTOR_DATA_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUTOR-DATA-CADASTRAMENTO       PIC X(10).*/
        public StringBasis PRODUTOR_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUTOR-DATA-ULT-MOVIMENTO       PIC X(10).*/
        public StringBasis PRODUTOR_DATA_ULT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUTOR-NUM-RECIBO  PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-COD-CORRETOR       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-SIT-REGISTRO       PIC X(1).*/
        public StringBasis PRODUTOR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUTOR-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUTOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTOR-TIMESTAMP   PIC X(26).*/
        public StringBasis PRODUTOR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}