using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.Sinistro.DB2.SI0820B;

namespace Code
{
    public class SI0820B
    {
        public bool IsCall { get; set; }

        public SI0820B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0820B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... MAIO / 1996                         *      */
        /*"      *   FUNCAO ................. ACOMPANHAMENTO DA SINISTRALIDADE.   *      */
        /*"      *            PELO REGIME DE CAIXA. USUARIO PRINCIPAL ATUARIA     *      */
        /*"      *            PROGRAMA SOLICITADO PELO USUSARIO (V0RELATORIOS)    *      */
        /*"      *            PODENDO SER EXECUTADO PARA UM RAMO OU APOLICE.      *      */
        /*"      *   USUARIO SOLICITANTE .... ATUARIA                             *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DA NOVA CODIFICACAO DE ESCRITORIO DE NEGOCIOS    *      */
        /*"      * (PROCURAR POR EB0202) - ENRICO (PRODEXTER)            FEV/2002 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0820B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0820B
        {
            get
            {
                _.Move(REG_SI0820B, _RSI0820B); VarBasis.RedefinePassValue(REG_SI0820B, _RSI0820B, REG_SI0820B); return _RSI0820B;
            }
        }
        /*"01                  REG-SI0820B.*/
        public SI0820B_REG_SI0820B REG_SI0820B { get; set; } = new SI0820B_REG_SI0820B();
        public class SI0820B_REG_SI0820B : VarBasis
        {
            /*"      05            LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   V0RELA-RAMO                PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0RELA-NUM-APOLICE         PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0RELA-PERI-INICIAL        PIC  X(010).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V0RELA-PERI-FINAL          PIC  X(010).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V0RELA-CODUSU              PIC  X(008).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77   V0RELA-APOLIDER            PIC  X(015).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77   V0RELA-ENDOSLID            PIC  X(015).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77   V1SIST-COD-EMPRESA         PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis V1SIST_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   V1SIST-MES-REFERENCIA      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1SIST_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V1SIST-ANO-REFERENCIA      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1SIST_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V1SIST-DATA-REFERENCIA     PIC  X(010).*/
        public StringBasis V1SIST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V1SIST-DTCURRENT           PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   W-TIMESTAMP                PIC  X(026).*/
        public StringBasis W_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77   V1EMPR-COD-EMP             PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V1EMPR-NOM-EMP             PIC  X(040)     VALUE SPACES.*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77   V0HISTSINI-OPERACAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0HISTSINI-VAL-OPERACAO    PIC S9(013)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0HISTSINI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77   V0HISTSINI-DTMOVTO         PIC  X(010).*/
        public StringBasis V0HISTSINI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V0ESCNEG-COD-ESCNEG         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESCNEG_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0ESCNEG-REGIAO-ESCNEG      PIC  X(040).*/
        public StringBasis V0ESCNEG_REGIAO_ESCNEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77   V0AGEN-COD-ESCNEG          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0AGEN_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0SINCRED-NUM-APOL-SINISTRO PIC S9(013)     VALUE +0 COMP-3*/
        public IntBasis V0SINCRED_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0CRED-COD-EMPRESA     PIC S9(009)          VALUE +0 COMP.*/
        public IntBasis V0CRED_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0CRED-NUM-FATURA      PIC S9(009)          VALUE +0 COMP.*/
        public IntBasis V0CRED_NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0CRED-COD-SUREG       PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CRED-COD-AGENCIA     PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CRED-CODOPER         PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CRED-NUM-CONTRATO    PIC S9(009)          VALUE +0 COMP.*/
        public IntBasis V0CRED_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0CRED-CONTRATO-DIGITO PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_CONTRATO_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CRED-DTINIVIG        PIC  X(010).*/
        public StringBasis V0CRED_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0CRED-DTTERVIG        PIC  X(010).*/
        public StringBasis V0CRED_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0CRED-PRAZO           PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CRED-PROPRIET        PIC  X(040).*/
        public StringBasis V0CRED_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0CRED-TPPESSOA        PIC  X(001).*/
        public StringBasis V0CRED_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0CRED-CGCCPF          PIC S9(015)          VALUE +0 COMP-3.*/
        public IntBasis V0CRED_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0CRED-SITUACAO        PIC  X(001).*/
        public StringBasis V0CRED_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0CRED-NUM-APOLICE     PIC S9(013)          VALUE +0 COMP-3.*/
        public IntBasis V0CRED_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0CRED-NRENDOS         PIC S9(009)          VALUE +0 COMP.*/
        public IntBasis V0CRED_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0CRED-TIMESTAMP       PIC  X(026).*/
        public StringBasis V0CRED_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77  V0CRED-VLSEGURO        PIC S9(015)V99       VALUE +0 COMP-3.*/
        public DoubleBasis V0CRED_VLSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77  V0CRED-VAL-PREMIO      PIC S9(015)V99       VALUE +0 COMP-3.*/
        public DoubleBasis V0CRED_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77  V0CRED-RAMO            PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CRED-TIPO-CREDITO    PIC S9(004)          VALUE +0 COMP.*/
        public IntBasis V0CRED_TIPO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W-V0CRED-QTD-DIAS-VIGENCIA   PIC S9(009)    VALUE +0 COMP-3.*/
        public IntBasis W_V0CRED_QTD_DIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   W-QTD-DIAS-COMP-TERVIG     PIC S9(009)      VALUE +0 COMP-3*/
        public IntBasis W_QTD_DIAS_COMP_TERVIG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   WHOST-RAMO-INI             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_RAMO_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WHOST-RAMO-FIM             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_RAMO_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WHOST-NUM-APOLICE-INI      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis WHOST_NUM_APOLICE_INI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   WHOST-NUM-APOLICE-FIM      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis WHOST_NUM_APOLICE_FIM { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01           AREA-DE-WORK.*/
        public SI0820B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0820B_AREA_DE_WORK();
        public class SI0820B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE               PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  W-CHAVES-FIM-ARQUIVO.*/
            public SI0820B_W_CHAVES_FIM_ARQUIVO W_CHAVES_FIM_ARQUIVO { get; set; } = new SI0820B_W_CHAVES_FIM_ARQUIVO();
            public class SI0820B_W_CHAVES_FIM_ARQUIVO : VarBasis
            {
                /*"      10  WFIM-CUR-PRINC         PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_CUR_PRINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  WFIM-V0RELATORIOS      PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  WFIM-V0SINCREDINT      PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_V0SINCREDINT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  W-CONTRATO-TEM-SINISTRO PIC  X(003)     VALUE SPACES.*/
                public StringBasis W_CONTRATO_TEM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  W-CHAVE-TEM-SINI-NA-COMP  PIC X(003)   VALUE SPACES.*/
                public StringBasis W_CHAVE_TEM_SINI_NA_COMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  05  W-TIPO-SOLICITACAO        PIC  X(010)      VALUE  SPACES.*/
            }
            public StringBasis W_TIPO_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  W-AC-LINHAS               PIC  9(002)      VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05  W-AC-PAGINA               PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  W-AC-LIDOS-DECLARE        PIC  9(018)     VALUE ZEROS.*/
            public IntBasis W_AC_LIDOS_DECLARE { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"  05  W-AC-LIDOS-DECLARE2       PIC  9(018)     VALUE ZEROS.*/
            public IntBasis W_AC_LIDOS_DECLARE2 { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"  05  W-SINISTROS-LIDOS         PIC  9(018)     VALUE ZEROS.*/
            public IntBasis W_SINISTROS_LIDOS { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"  05  W-CHAVES-QUEBRA.*/
            public SI0820B_W_CHAVES_QUEBRA W_CHAVES_QUEBRA { get; set; } = new SI0820B_W_CHAVES_QUEBRA();
            public class SI0820B_W_CHAVES_QUEBRA : VarBasis
            {
                /*"      10 W-COD-ESCNEG-ANT      PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis W_COD_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 W-AGENCIA-ANT         PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis W_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03  W-AREAS-CALCULO.*/
            }
            public SI0820B_W_AREAS_CALCULO W_AREAS_CALCULO { get; set; } = new SI0820B_W_AREAS_CALCULO();
            public class SI0820B_W_AREAS_CALCULO : VarBasis
            {
                /*"  05  W-SALDO-PREMIO           PIC S9(013)V9(5) VALUE +0  COMP-3*/
                public DoubleBasis W_SALDO_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"  05  W-VAL-PAG-COMPETENCIA    PIC S9(013)V9(5) VALUE +0  COMP-3*/
                public DoubleBasis W_VAL_PAG_COMPETENCIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"  05  W-PRO-RATA-PREMIO        PIC S9(013)V9(5) VALUE +0  COMP-3*/
                public DoubleBasis W_PRO_RATA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"  03  W-ACUMULADORES-DETALHE.*/
                public SI0820B_W_ACUMULADORES_DETALHE W_ACUMULADORES_DETALHE { get; set; } = new SI0820B_W_ACUMULADORES_DETALHE();
                public class SI0820B_W_ACUMULADORES_DETALHE : VarBasis
                {
                    /*"  05  W-AC-QTD-PRE-MENSAL      PIC S9(007)      VALUE +0  COMP-3*/
                    public IntBasis W_AC_QTD_PRE_MENSAL { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                    /*"  05  W-AC-VAL-PRE-MENSAL      PIC S9(013)V9(2) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_VAL_PRE_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"  05  W-AC-QTD-SIN-MENSAL      PIC S9(007)      VALUE +0  COMP-3*/
                    public IntBasis W_AC_QTD_SIN_MENSAL { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                    /*"  05  W-AC-VAL-SIN-MENSAL      PIC S9(013)V9(2) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_VAL_SIN_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"  05  W-AC-QTD-PRE-ACUMULADO   PIC S9(007)      VALUE +0  COMP-3*/
                    public IntBasis W_AC_QTD_PRE_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                    /*"  05  W-AC-VAL-PRE-ACUMULADO   PIC S9(013)V9(2) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_VAL_PRE_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"  05  W-AC-QTD-SIN-ACUMULADO   PIC S9(007)      VALUE +0  COMP-3*/
                    public IntBasis W_AC_QTD_SIN_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                    /*"  05  W-AC-VAL-SIN-ACUMULADO   PIC S9(013)V9(2) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_VAL_SIN_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"  05  W-AC-QTD-PEN-ACUMULADO   PIC S9(007)      VALUE +0  COMP-3*/
                    public IntBasis W_AC_QTD_PEN_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                    /*"  05  W-AC-VAL-PEN-ACUMULADO   PIC S9(013)V9(2) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_VAL_PEN_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"  05  W-AC-C-A                 PIC S9(005)V9(5) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_C_A { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                    /*"  05  W-AC-D-B                 PIC S9(005)V9(5) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_D_B { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                    /*"  05  W-AC-G-E                 PIC S9(005)V9(5) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_G_E { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                    /*"  05  W-AC-G-E-PEND            PIC S9(005)V9(5) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_G_E_PEND { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                    /*"  05  W-AC-H-F                 PIC S9(005)V9(5) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_H_F { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                    /*"  05  W-AC-H-F-PEND            PIC S9(005)V9(5) VALUE +0  COMP-3*/
                    public DoubleBasis W_AC_H_F_PEND { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                    /*"  03  W-ACUMULADORES-ESCNEG.*/
                    public SI0820B_W_ACUMULADORES_ESCNEG W_ACUMULADORES_ESCNEG { get; set; } = new SI0820B_W_ACUMULADORES_ESCNEG();
                    public class SI0820B_W_ACUMULADORES_ESCNEG : VarBasis
                    {
                        /*"  05  W-ESC-QTD-PRE-MENSAL     PIC S9(007)      VALUE +0  COMP-3*/
                        public IntBasis W_ESC_QTD_PRE_MENSAL { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                        /*"  05  W-ESC-VAL-PRE-MENSAL     PIC S9(013)V9(2) VALUE +0  COMP-3*/
                        public DoubleBasis W_ESC_VAL_PRE_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                        /*"  05  W-ESC-QTD-SIN-MENSAL     PIC S9(007)      VALUE +0  COMP-3*/
                        public IntBasis W_ESC_QTD_SIN_MENSAL { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                        /*"  05  W-ESC-VAL-SIN-MENSAL     PIC S9(013)V9(2) VALUE +0  COMP-3*/
                        public DoubleBasis W_ESC_VAL_SIN_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                        /*"  05  W-ESC-QTD-PRE-ACUMULADO  PIC S9(007)      VALUE +0  COMP-3*/
                        public IntBasis W_ESC_QTD_PRE_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                        /*"  05  W-ESC-VAL-PRE-ACUMULADO  PIC S9(013)V9(2) VALUE +0  COMP-3*/
                        public DoubleBasis W_ESC_VAL_PRE_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                        /*"  05  W-ESC-QTD-SIN-ACUMULADO  PIC S9(007)      VALUE +0  COMP-3*/
                        public IntBasis W_ESC_QTD_SIN_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                        /*"  05  W-ESC-VAL-SIN-ACUMULADO  PIC S9(013)V9(2) VALUE +0  COMP-3*/
                        public DoubleBasis W_ESC_VAL_SIN_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                        /*"  05  W-ESC-QTD-PEN-ACUMULADO  PIC S9(007)      VALUE +0  COMP-3*/
                        public IntBasis W_ESC_QTD_PEN_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                        /*"  05  W-ESC-VAL-PEN-ACUMULADO  PIC S9(013)V9(2) VALUE +0  COMP-3*/
                        public DoubleBasis W_ESC_VAL_PEN_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                        /*"  05  W-EDICAO                 PIC ZZZ.ZZZ.ZZZ.ZZ9,99-.*/
                        public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                        /*"  05  W-TOT-CALCULO-GERAL      PIC S9(005)V9(5) VALUE +0  COMP-3*/
                        public DoubleBasis W_TOT_CALCULO_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                        /*"  03  W-ACUMULADORES-FINAL.*/
                        public SI0820B_W_ACUMULADORES_FINAL W_ACUMULADORES_FINAL { get; set; } = new SI0820B_W_ACUMULADORES_FINAL();
                        public class SI0820B_W_ACUMULADORES_FINAL : VarBasis
                        {
                            /*"  05  W-GER-QTD-PRE-MENSAL     PIC S9(007)      VALUE +0  COMP-3*/
                            public IntBasis W_GER_QTD_PRE_MENSAL { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                            /*"  05  W-GER-VAL-PRE-MENSAL     PIC S9(013)V9(2) VALUE +0  COMP-3*/
                            public DoubleBasis W_GER_VAL_PRE_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"  05  W-GER-QTD-SIN-MENSAL     PIC S9(007)      VALUE +0  COMP-3*/
                            public IntBasis W_GER_QTD_SIN_MENSAL { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                            /*"  05  W-GER-VAL-SIN-MENSAL     PIC S9(013)V9(2) VALUE +0  COMP-3*/
                            public DoubleBasis W_GER_VAL_SIN_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"  05  W-GER-QTD-PRE-ACUMULADO  PIC S9(007)      VALUE +0  COMP-3*/
                            public IntBasis W_GER_QTD_PRE_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                            /*"  05  W-GER-VAL-PRE-ACUMULADO  PIC S9(013)V9(2) VALUE +0  COMP-3*/
                            public DoubleBasis W_GER_VAL_PRE_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"  05  W-GER-QTD-SIN-ACUMULADO  PIC S9(007)      VALUE +0  COMP-3*/
                            public IntBasis W_GER_QTD_SIN_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                            /*"  05  W-GER-VAL-SIN-ACUMULADO  PIC S9(013)V9(2) VALUE +0  COMP-3*/
                            public DoubleBasis W_GER_VAL_SIN_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"  05  W-GER-QTD-PEN-ACUMULADO  PIC S9(007)      VALUE +0  COMP-3*/
                            public IntBasis W_GER_QTD_PEN_ACUMULADO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
                            /*"  05  W-GER-VAL-PEN-ACUMULADO  PIC S9(013)V9(2) VALUE +0  COMP-3*/
                            public DoubleBasis W_GER_VAL_PEN_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"  05  W-GER-CALCULO-GERAL      PIC S9(005)V9(5) VALUE +0  COMP-3*/
                            public DoubleBasis W_GER_CALCULO_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(5)"), 5);
                            /*"  03  ACUMULADORES-AUXILIARES.*/
                            public SI0820B_ACUMULADORES_AUXILIARES ACUMULADORES_AUXILIARES { get; set; } = new SI0820B_ACUMULADORES_AUXILIARES();
                            public class SI0820B_ACUMULADORES_AUXILIARES : VarBasis
                            {
                                /*"  05  W-VAL-PRO-RATA-PREMIO    PIC S9(013)V9(5) VALUE +0  COMP-3*/
                                public DoubleBasis W_VAL_PRO_RATA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                                /*"  05  W-SINISTRO-PAGO-ACUMULADO PIC S9(13)V9(2) VALUE +0  COMP-3*/
                                public DoubleBasis W_SINISTRO_PAGO_ACUMULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                                /*"  05  W-SINISTRO-PAGO-MENSAL   PIC S9(013)V9(2) VALUE +0  COMP-3*/
                                public DoubleBasis W_SINISTRO_PAGO_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                                /*"  05  W-SINISTRO-PENDENTE      PIC S9(013)V9(2) VALUE +0  COMP-3*/
                                public DoubleBasis W_SINISTRO_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                                /*"  05  W-APOLICE-ALFA-INI.*/
                                public SI0820B_W_APOLICE_ALFA_INI W_APOLICE_ALFA_INI { get; set; } = new SI0820B_W_APOLICE_ALFA_INI();
                                public class SI0820B_W_APOLICE_ALFA_INI : VarBasis
                                {
                                    /*"      10  W-ORGAO-APOLICE-INI  PIC  9(003)    VALUE 010.*/
                                    public IntBasis W_ORGAO_APOLICE_INI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 010);
                                    /*"      10  W-RAMO-APOLICE-INI   PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis W_RAMO_APOLICE_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"      10  W-NUM-APOLICE-INI    PIC  9(008)    VALUE ZEROS.*/
                                    public IntBasis W_NUM_APOLICE_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                                    /*"  05  W-APOLICE-NUM-INI  REDEFINES W-APOLICE-ALFA-INI                               PIC  9(013).*/
                                }
                                private _REDEF_IntBasis _w_apolice_num_ini { get; set; }
                                public _REDEF_IntBasis W_APOLICE_NUM_INI
                                {
                                    get { _w_apolice_num_ini = new _REDEF_IntBasis(new PIC("9", "013", "9(013).")); ; _.Move(W_APOLICE_ALFA_INI, _w_apolice_num_ini); VarBasis.RedefinePassValue(W_APOLICE_ALFA_INI, _w_apolice_num_ini, W_APOLICE_ALFA_INI); _w_apolice_num_ini.ValueChanged += () => { _.Move(_w_apolice_num_ini, W_APOLICE_ALFA_INI); }; return _w_apolice_num_ini; }
                                    set { VarBasis.RedefinePassValue(value, _w_apolice_num_ini, W_APOLICE_ALFA_INI); }
                                }  //Redefines
                                /*"  05  W-APOLICE-ALFA-FIM.*/
                                public SI0820B_W_APOLICE_ALFA_FIM W_APOLICE_ALFA_FIM { get; set; } = new SI0820B_W_APOLICE_ALFA_FIM();
                                public class SI0820B_W_APOLICE_ALFA_FIM : VarBasis
                                {
                                    /*"      10  W-ORGAO-APOLICE-FIM  PIC  9(003)    VALUE 010.*/
                                    public IntBasis W_ORGAO_APOLICE_FIM { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 010);
                                    /*"      10  W-RAMO-APOLICE-FIM   PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis W_RAMO_APOLICE_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"      10  W-NUM-APOLICE-FIM    PIC  9(008)    VALUE ZEROS.*/
                                    public IntBasis W_NUM_APOLICE_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                                    /*"  05  W-APOLICE-NUM-FIM      REDEFINES W-APOLICE-ALFA-FIM                               PIC  9(013).*/
                                }
                                private _REDEF_IntBasis _w_apolice_num_fim { get; set; }
                                public _REDEF_IntBasis W_APOLICE_NUM_FIM
                                {
                                    get { _w_apolice_num_fim = new _REDEF_IntBasis(new PIC("9", "013", "9(013).")); ; _.Move(W_APOLICE_ALFA_FIM, _w_apolice_num_fim); VarBasis.RedefinePassValue(W_APOLICE_ALFA_FIM, _w_apolice_num_fim, W_APOLICE_ALFA_FIM); _w_apolice_num_fim.ValueChanged += () => { _.Move(_w_apolice_num_fim, W_APOLICE_ALFA_FIM); }; return _w_apolice_num_fim; }
                                    set { VarBasis.RedefinePassValue(value, _w_apolice_num_fim, W_APOLICE_ALFA_FIM); }
                                }  //Redefines
                                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
                                public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                                /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
                                private _REDEF_SI0820B_FILLER_0 _filler_0 { get; set; }
                                public _REDEF_SI0820B_FILLER_0 FILLER_0
                                {
                                    get { _filler_0 = new _REDEF_SI0820B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                                    set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
                                }  //Redefines
                                public class _REDEF_SI0820B_FILLER_0 : VarBasis
                                {
                                    /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                                    public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                                    /*"    10       FILLER            PIC  X(001).*/
                                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                    /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                                    public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                                    /*"    10       FILLER            PIC  X(001).*/
                                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                    /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                                    public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                                    /*"  05    W-DATA-INI-COMP.*/

                                    public _REDEF_SI0820B_FILLER_0()
                                    {
                                        WDATA_AA_CURR.ValueChanged += OnValueChanged;
                                        FILLER_1.ValueChanged += OnValueChanged;
                                        WDATA_MM_CURR.ValueChanged += OnValueChanged;
                                        FILLER_2.ValueChanged += OnValueChanged;
                                        WDATA_DD_CURR.ValueChanged += OnValueChanged;
                                    }

                                }
                                public SI0820B_W_DATA_INI_COMP W_DATA_INI_COMP { get; set; } = new SI0820B_W_DATA_INI_COMP();
                                public class SI0820B_W_DATA_INI_COMP : VarBasis
                                {
                                    /*"    10  W-DATA-INI-COMP-AAAA   PIC  9(004)    VALUE ZEROS.*/
                                    public IntBasis W_DATA_INI_COMP_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10  FILLER                 PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  W-DATA-INI-COMP-MM     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis W_DATA_INI_COMP_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10  FILLER                 PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  W-DATA-INI-COMP-DD     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis W_DATA_INI_COMP_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  05    W-DATA-FIM-COMP.*/
                                }
                                public SI0820B_W_DATA_FIM_COMP W_DATA_FIM_COMP { get; set; } = new SI0820B_W_DATA_FIM_COMP();
                                public class SI0820B_W_DATA_FIM_COMP : VarBasis
                                {
                                    /*"    10  W-DATA-FIM-COMP-AAAA   PIC  9(004)    VALUE ZEROS.*/
                                    public IntBasis W_DATA_FIM_COMP_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10  FILLER                 PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  W-DATA-FIM-COMP-MM     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis W_DATA_FIM_COMP_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10  FILLER                 PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  W-DATA-FIM-COMP-DD     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis W_DATA_FIM_COMP_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  05         WHORA-CURR-E.*/
                                }
                                public SI0820B_WHORA_CURR_E WHORA_CURR_E { get; set; } = new SI0820B_WHORA_CURR_E();
                                public class SI0820B_WHORA_CURR_E : VarBasis
                                {
                                    /*"    10       WHORA-HH-CURR-E   PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_HH_CURR_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       WHORA-MM-CURR-E   PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_MM_CURR_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       WHORA-SS-CURR-E   PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_SS_CURR_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       WHORA-CC-CURR-E   PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_CC_CURR_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  05         WHORA-CURR.*/
                                }
                                public SI0820B_WHORA_CURR WHORA_CURR { get; set; } = new SI0820B_WHORA_CURR();
                                public class SI0820B_WHORA_CURR : VarBasis
                                {
                                    /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  05         WDATA-CABEC.*/
                                }
                                public SI0820B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0820B_WDATA_CABEC();
                                public class SI0820B_WDATA_CABEC : VarBasis
                                {
                                    /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                                    /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                                    /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                                    public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"  05         WHORA-CABEC.*/
                                }
                                public SI0820B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0820B_WHORA_CABEC();
                                public class SI0820B_WHORA_CABEC : VarBasis
                                {
                                    /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                                    /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                                    /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  05         WDATA-VIGENCIA.*/
                                }
                                public SI0820B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new SI0820B_WDATA_VIGENCIA();
                                public class SI0820B_WDATA_VIGENCIA : VarBasis
                                {
                                    /*"    10       WDATA-VIG-ANO     PIC  9(004)    VALUE ZEROS.*/
                                    public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10       WDATA-VIG-MES     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10       WDATA-VIG-DIA     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  05         WDATA-DTMOVTO.*/
                                }
                                public SI0820B_WDATA_DTMOVTO WDATA_DTMOVTO { get; set; } = new SI0820B_WDATA_DTMOVTO();
                                public class SI0820B_WDATA_DTMOVTO : VarBasis
                                {
                                    /*"    10       WDATA-MOV-ANO     PIC  9(004)    VALUE ZEROS.*/
                                    public IntBasis WDATA_MOV_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10       WDATA-MOV-MES     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WDATA_MOV_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10       WDATA-MOV-DIA     PIC  9(002)    VALUE ZEROS.*/
                                    public IntBasis WDATA_MOV_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
                                }
                                public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                                /*"  03        WABEND.*/
                                public SI0820B_WABEND WABEND { get; set; } = new SI0820B_WABEND();
                                public class SI0820B_WABEND : VarBasis
                                {
                                    /*"    05      FILLER              PIC  X(010) VALUE           ' SI0820B'.*/
                                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0820B");
                                    /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                                    /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                                    /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                                    /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                                    /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                                    /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                                    /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                                    /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                                    /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                                    /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                                    /*"  05            LC00.*/
                                }
                                public SI0820B_LC00 LC00 { get; set; } = new SI0820B_LC00();
                                public class SI0820B_LC00 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(023) VALUE  ALL  '*'.*/
                                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"ALL");
                                    /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10          FILLER         PIC  X(021) VALUE                'USUARIO SOLICITANTE: '.*/
                                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"USUARIO SOLICITANTE: ");
                                    /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10          LC00-CODUSU    PIC  X(008) VALUE  SPACES.*/
                                    public StringBasis LC00_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  ' - '.*/
                                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                                    /*"    10          LC00-APOLIDER  PIC  X(015) VALUE  SPACES.*/
                                    public StringBasis LC00_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                                    /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10          FILLER         PIC  X(020) VALUE                'DIVISAO DE DESTINO: '.*/
                                    public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DIVISAO DE DESTINO: ");
                                    /*"    10          LC00-ENDOSLID  PIC  X(015) VALUE  SPACES.*/
                                    public StringBasis LC00_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                                    /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10          FILLER         PIC  X(023) VALUE  ALL  '*'.*/
                                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"ALL");
                                    /*"  05            LC00-A.*/
                                }
                                public SI0820B_LC00_A LC00_A { get; set; } = new SI0820B_LC00_A();
                                public class SI0820B_LC00_A : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(132) VALUE  ALL  '*'.*/
                                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                                    /*"  05            LC01.*/
                                }
                                public SI0820B_LC01 LC01 { get; set; } = new SI0820B_LC01();
                                public class SI0820B_LC01 : VarBasis
                                {
                                    /*"    10          LC01-RELATOR   PIC  X(010) VALUE 'SI0820B.1'.*/
                                    public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0820B.1");
                                    /*"    10          FILLER         PIC  X(033) VALUE  SPACES.*/
                                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                                    /*"    10          LC01-EMPRESA   PIC  X(040) VALUE  SPACES.*/
                                    public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                                    /*"    10          FILLER         PIC  X(034) VALUE  SPACES.*/
                                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                                    /*"    10          FILLER         PIC  X(011) VALUE 'PAGINA'.*/
                                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                                    /*"    10          LC01-PAGINA    PIC  ZZZ9.*/
                                    public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                                    /*"  05            LC02.*/
                                }
                                public SI0820B_LC02 LC02 { get; set; } = new SI0820B_LC02();
                                public class SI0820B_LC02 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(042) VALUE  SPACES.*/
                                    public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"");
                                    /*"    10          FILLER         PIC  X(036) VALUE      '- SINISTRALIDADE (REGIME DE CAIXA) -'.*/
                                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"- SINISTRALIDADE (REGIME DE CAIXA) -");
                                    /*"    10          FILLER         PIC  X(039) VALUE  SPACES.*/
                                    public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                                    /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                                    /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                                    public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                                    /*"  05    LC03.*/
                                }
                                public SI0820B_LC03 LC03 { get; set; } = new SI0820B_LC03();
                                public class SI0820B_LC03 : VarBasis
                                {
                                    /*"    10  FILLER                 PIC  X(036) VALUE SPACES.*/
                                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                                    /*"    10  FILLER                 PIC  X(025) VALUE                'PERIODO DE COMPETENCIA - '.*/
                                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"PERIODO DE COMPETENCIA - ");
                                    /*"    10  LC03-DD-INI-COMP       PIC  9(002) VALUE ZEROS.*/
                                    public IntBasis LC03_DD_INI_COMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10  FILLER                 PIC  X(001) VALUE '/'.*/
                                    public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                                    /*"    10  LC03-MM-INI-COMP       PIC  9(002) VALUE ZEROS.*/
                                    public IntBasis LC03_MM_INI_COMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10  FILLER                 PIC  X(001) VALUE '/'.*/
                                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                                    /*"    10  LC03-AA-INI-COMP       PIC  9(004) VALUE ZEROS.*/
                                    public IntBasis LC03_AA_INI_COMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10  FILLER                 PIC  X(003) VALUE ' A '.*/
                                    public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                                    /*"    10  LC03-DD-FIM-COMP       PIC  9(002) VALUE ZEROS.*/
                                    public IntBasis LC03_DD_FIM_COMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10  FILLER                 PIC  X(001) VALUE '/'.*/
                                    public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                                    /*"    10  LC03-MM-FIM-COMP       PIC  9(002) VALUE ZEROS.*/
                                    public IntBasis LC03_MM_FIM_COMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                                    /*"    10  FILLER                 PIC  X(001) VALUE '/'.*/
                                    public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                                    /*"    10  LC03-AA-FIM-COMP       PIC  9(004) VALUE ZEROS.*/
                                    public IntBasis LC03_AA_FIM_COMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10          FILLER         PIC  X(033) VALUE SPACES.*/
                                    public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                                    /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                                    /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                                    public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                                    /*"  05            LC04.*/
                                }
                                public SI0820B_LC04 LC04 { get; set; } = new SI0820B_LC04();
                                public class SI0820B_LC04 : VarBasis
                                {
                                    /*"    10  FILLER                  PIC  X(010) VALUE  'ESC. NEG.:'.*/
                                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ESC. NEG.:");
                                    /*"    10  LC04-COD-ESCNEG         PIC  9(004) VALUE  ZEROS.*/
                                    public IntBasis LC04_COD_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                                    /*"    10  FILLER                  PIC  X(003) VALUE  ' - '.*/
                                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                                    /*"    10  LC04-NOME-ESCNEG        PIC  X(040) VALUE  SPACES.*/
                                    public StringBasis LC04_NOME_ESCNEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                                    /*"    10  FILLER                  PIC  X(002) VALUE  SPACES.*/
                                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                                    /*"    10  LC04-FILLER-RAMO        PIC  X(005) VALUE  SPACES.*/
                                    public StringBasis LC04_FILLER_RAMO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                                    /*"    10  FILLER                  PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  LC04-FILLER-NUM-RAMO    PIC  Z(002).*/
                                    public IntBasis LC04_FILLER_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "2", "Z(002)."));
                                    /*"    10  FILLER                  PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  LC04-FILLER-NOME-RAMO   PIC  X(030) VALUE  ZEROS.*/
                                    public StringBasis LC04_FILLER_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                                    /*"    10  FILLER                  PIC  X(002) VALUE  SPACES.*/
                                    public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                                    /*"    10  LC04-FILLER-APOLICE     PIC  X(008) VALUE  SPACES.*/
                                    public StringBasis LC04_FILLER_APOLICE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                                    /*"    10  FILLER                  PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10  LC04-FILLER-NUM-APOLICE PIC  Z(013).*/
                                    public IntBasis LC04_FILLER_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "Z(013)."));
                                    /*"    10  FILLER                  PIC  X(011) VALUE  SPACES.*/
                                    public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                                    /*"  05            LC05.*/
                                }
                                public SI0820B_LC05 LC05 { get; set; } = new SI0820B_LC05();
                                public class SI0820B_LC05 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(028) VALUE  SPACES.*/
                                    public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                                    /*"    10          FILLER         PIC  X(012) VALUE                               '** MENSAL **'.*/
                                    public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"** MENSAL **");
                                    /*"    10          FILLER         PIC  X(024) VALUE  SPACES.*/
                                    public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                                    /*"    10          FILLER         PIC  X(001) VALUE  '*'.*/
                                    public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10          FILLER         PIC  X(037) VALUE  SPACES.*/
                                    public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                                    /*"    10          FILLER         PIC  X(015) VALUE                               '** ACUMULADO **'.*/
                                    public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"** ACUMULADO **");
                                    /*"    10          FILLER         PIC  X(014) VALUE  SPACES.*/
                                    public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                                    /*"  05            LC06.*/
                                }
                                public SI0820B_LC06 LC06 { get; set; } = new SI0820B_LC06();
                                public class SI0820B_LC06 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(005) VALUE  'AGENC'.*/
                                    public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"AGENC");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'QTD'.*/
                                    public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"QTD");
                                    /*"    10          FILLER         PIC  X(010) VALUE  SPACES.*/
                                    public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                                    /*"    10          FILLER         PIC  X(006) VALUE  'PREMIO'.*/
                                    public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'QTD'.*/
                                    public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"QTD");
                                    /*"    10          FILLER         PIC  X(005) VALUE  SPACES.*/
                                    public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                                    /*"    10          FILLER         PIC  X(009) VALUE                               'SIN. PAGO'.*/
                                    public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SIN. PAGO");
                                    /*"    10          FILLER         PIC  X(015) VALUE  SPACES.*/
                                    public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                                    /*"    10          FILLER         PIC  X(001) VALUE  '*'.*/
                                    public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10          FILLER         PIC  X(006) VALUE  SPACES.*/
                                    public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'QTD'.*/
                                    public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"QTD");
                                    /*"    10          FILLER         PIC  X(011) VALUE  SPACES.*/
                                    public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                                    /*"    10          FILLER         PIC  X(006) VALUE  'PREMIO'.*/
                                    public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
                                    /*"    10          FILLER         PIC  X(006) VALUE  SPACES.*/
                                    public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'QTD'.*/
                                    public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"QTD");
                                    /*"    10          FILLER         PIC  X(008) VALUE  SPACES.*/
                                    public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                                    /*"    10          FILLER         PIC  X(009) VALUE                               'SIN. PAGO'.*/
                                    public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SIN. PAGO");
                                    /*"    10          FILLER         PIC  X(013) VALUE  SPACES.*/
                                    public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                                    /*"  05            LC07.*/
                                }
                                public SI0820B_LC07 LC07 { get; set; } = new SI0820B_LC07();
                                public class SI0820B_LC07 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(064) VALUE  SPACES.*/
                                    public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"");
                                    /*"    10          FILLER         PIC  X(001) VALUE  '*'.*/
                                    public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10          FILLER         PIC  X(043) VALUE  SPACES.*/
                                    public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                                    /*"    10          FILLER         PIC  X(009) VALUE                               'SIN. PEND'.*/
                                    public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SIN. PEND");
                                    /*"    10          FILLER         PIC  X(013) VALUE  SPACES.*/
                                    public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                                    /*"  05            LC08.*/
                                }
                                public SI0820B_LC08 LC08 { get; set; } = new SI0820B_LC08();
                                public class SI0820B_LC08 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(009) VALUE  SPACES.*/
                                    public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(A)'.*/
                                    public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(A)");
                                    /*"    10          FILLER         PIC  X(013) VALUE  SPACES.*/
                                    public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(B)'.*/
                                    public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(B)");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(C)'.*/
                                    public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(C)");
                                    /*"    10          FILLER         PIC  X(011) VALUE  SPACES.*/
                                    public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(D)'.*/
                                    public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(D)");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'C/A'.*/
                                    public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"C/A");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'D/B'.*/
                                    public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"D/B");
                                    /*"    10          FILLER         PIC  X(001) VALUE  SPACES.*/
                                    public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10          FILLER         PIC  X(001) VALUE  '*'.*/
                                    public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10          FILLER         PIC  X(006) VALUE  SPACES.*/
                                    public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(E)'.*/
                                    public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(E)");
                                    /*"    10          FILLER         PIC  X(014) VALUE  SPACES.*/
                                    public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(F)'.*/
                                    public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(F)");
                                    /*"    10          FILLER         PIC  X(006) VALUE  SPACES.*/
                                    public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(G)'.*/
                                    public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(G)");
                                    /*"    10          FILLER         PIC  X(014) VALUE  SPACES.*/
                                    public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  '(H)'.*/
                                    public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(H)");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'G/E'.*/
                                    public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"G/E");
                                    /*"    10          FILLER         PIC  X(004) VALUE  SPACES.*/
                                    public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                                    /*"    10          FILLER         PIC  X(003) VALUE  'H/F'.*/
                                    public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"H/F");
                                    /*"  05            LC09.*/
                                }
                                public SI0820B_LC09 LC09 { get; set; } = new SI0820B_LC09();
                                public class SI0820B_LC09 : VarBasis
                                {
                                    /*"    10          FILLER         PIC  X(132) VALUE ALL '-'.*/
                                    public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                                    /*"  05     LD01.*/
                                }
                                public SI0820B_LD01 LD01 { get; set; } = new SI0820B_LD01();
                                public class SI0820B_LD01 : VarBasis
                                {
                                    /*"    10   LD01-COD-AGENCIA      PIC  X(005) VALUE SPACES.*/
                                    public StringBasis LD01_COD_AGENCIA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                                    /*"    10   LD01-QTD-PR-MEN       PIC  ZZZ.ZZ9.*/
                                    public IntBasis LD01_QTD_PR_MEN { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-VAL-PR-MEN       PIC  ZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LD01_VAL_PR_MEN { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-QTD-SI-MEN       PIC  ZZZZZ9.*/
                                    public IntBasis LD01_QTD_SI_MEN { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-VAL-SI-MEN       PIC  ZZZZZZ.ZZ9,99.*/
                                    public DoubleBasis LD01_VAL_SI_MEN { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-C-A-MEN          PIC  ZZ9,99.*/
                                    public DoubleBasis LD01_C_A_MEN { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-D-B-MEN          PIC  ZZ9,99.*/
                                    public DoubleBasis LD01_D_B_MEN { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   FILLER                PIC  X(001) VALUE '*'.*/
                                    public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10   FILLER                PIC  X(001) VALUE ' '.*/
                                    public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                                    /*"    10   LD01-QTD-PR-ACU       PIC  ZZZZ.ZZ9.*/
                                    public IntBasis LD01_QTD_PR_ACU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-VAL-PR-ACU       PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LD01_VAL_PR_ACU { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-QTD-SI-ACU       PIC  ZZZZ.ZZ9.*/
                                    public IntBasis LD01_QTD_SI_ACU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-VAL-SI-ACU       PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LD01_VAL_SI_ACU { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-G-E-ACU          PIC  ZZ9,9.*/
                                    public DoubleBasis LD01_G_E_ACU { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9."), 1);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD01-H-F-ACU          PIC  ZZZZ9,99.*/
                                    public DoubleBasis LD01_H_F_ACU { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
                                    /*"  05     LD02.*/
                                }
                                public SI0820B_LD02 LD02 { get; set; } = new SI0820B_LD02();
                                public class SI0820B_LD02 : VarBasis
                                {
                                    /*"    10   FILLER                PIC  X(064) VALUE SPACES.*/
                                    public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"");
                                    /*"    10   FILLER                PIC  X(001) VALUE '*'.*/
                                    public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10   FILLER                PIC  X(027) VALUE SPACE.*/
                                    public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                                    /*"    10   LD02-QTD-SI-ACU       PIC  ZZZZ.ZZ9.*/
                                    public IntBasis LD02_QTD_SI_ACU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACE.*/
                                    public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD02-VAL-SI-ACU       PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LD02_VAL_SI_ACU { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD02-G-E-ACU          PIC  ZZ9,9.*/
                                    public DoubleBasis LD02_G_E_ACU { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9."), 1);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LD02-H-F-ACU          PIC  ZZZZ9,99.*/
                                    public DoubleBasis LD02_H_F_ACU { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
                                    /*"  05     LT01.*/
                                }
                                public SI0820B_LT01 LT01 { get; set; } = new SI0820B_LT01();
                                public class SI0820B_LT01 : VarBasis
                                {
                                    /*"    10   FILLER                PIC  X(005) VALUE 'TOTAL'.*/
                                    public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"TOTAL");
                                    /*"    10   LT01-QTD-PR-MEN       PIC  ZZZ.ZZ9.*/
                                    public IntBasis LT01_QTD_PR_MEN { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACE.*/
                                    public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-VAL-PR-MEN       PIC  ZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LT01_VAL_PR_MEN { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-QTD-SI-MEN       PIC  ZZZZZ9.*/
                                    public IntBasis LT01_QTD_SI_MEN { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACE.*/
                                    public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-VAL-SI-MEN       PIC  ZZZZZZ.ZZ9,99.*/
                                    public DoubleBasis LT01_VAL_SI_MEN { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-C-A-MEN          PIC  ZZ9,99.*/
                                    public DoubleBasis LT01_C_A_MEN { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-D-B-MEN          PIC  ZZ9,99.*/
                                    public DoubleBasis LT01_D_B_MEN { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   FILLER                PIC  X(001) VALUE '*'.*/
                                    public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-QTD-PR-ACU       PIC  ZZZZ.ZZ9.*/
                                    public IntBasis LT01_QTD_PR_ACU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACE.*/
                                    public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-VAL-PR-ACU       PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LT01_VAL_PR_ACU { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-QTD-SI-ACU       PIC  ZZZZ.ZZ9.*/
                                    public IntBasis LT01_QTD_SI_ACU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACE.*/
                                    public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-VAL-SI-ACU       PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LT01_VAL_SI_ACU { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-G-E-ACU          PIC  ZZ9,9.*/
                                    public DoubleBasis LT01_G_E_ACU { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9."), 1);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT01-H-F-ACU          PIC  ZZZZ9,99.*/
                                    public DoubleBasis LT01_H_F_ACU { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
                                    /*"  05     LT02.*/
                                }
                                public SI0820B_LT02 LT02 { get; set; } = new SI0820B_LT02();
                                public class SI0820B_LT02 : VarBasis
                                {
                                    /*"    10   LT02-TIPO-TOTAL       PIC  X(012) VALUE SPACES.*/
                                    public StringBasis LT02_TIPO_TOTAL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                                    /*"    10   FILER                 PIC  X(052) VALUE SPACES.*/
                                    public StringBasis FILER { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
                                    /*"    10   FILLER                PIC  X(001) VALUE '*'.*/
                                    public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                                    /*"    10   FILLER                PIC  X(027) VALUE SPACE.*/
                                    public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                                    /*"    10   LT02-QTD-SI-ACU       PIC  ZZZZ.ZZ9.*/
                                    public IntBasis LT02_QTD_SI_ACU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACE.*/
                                    public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT02-VAL-SI-ACU       PIC  ZZZZZ.ZZZ.ZZ9,99.*/
                                    public DoubleBasis LT02_VAL_SI_ACU { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99."), 2);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT02-G-E-ACU          PIC  ZZ9,9.*/
                                    public DoubleBasis LT02_G_E_ACU { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9."), 1);
                                    /*"    10   FILLER                PIC  X(001) VALUE SPACES.*/
                                    public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                                    /*"    10   LT02-H-F-ACU          PIC  ZZZZ9,99.*/
                                    public DoubleBasis LT02_H_F_ACU { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V99."), 2);
                                    /*"01          LK-LINK.*/
                                }
                            }
                            public SI0820B_LK_LINK LK_LINK { get; set; } = new SI0820B_LK_LINK();
                            public class SI0820B_LK_LINK : VarBasis
                            {
                                /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
                                public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                                /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
                                public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                                /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
                                public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                            }
                        }
                    }
                }
            }
        }


        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public SI0820B_CURSOR_PRINC CURSOR_PRINC { get; set; } = new SI0820B_CURSOR_PRINC();
        public SI0820B_V0HISTSINI V0HISTSINI { get; set; } = new SI0820B_V0HISTSINI();
        public SI0820B_V0RELATORIOS V0RELATORIOS { get; set; } = new SI0820B_V0RELATORIOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0820B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0820B.SetFile(RSI0820B_FILE_NAME_P);

                /*" -629- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

                /*" -630- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -633- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -636- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -636- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL */

                R0000_00_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL */
        private void R0000_00_PRINCIPAL(bool isPerform = false)
        {
            /*" -647- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -649- PERFORM 0000-00-ACESSA-V1SISTEMA. */

            M_0000_00_ACESSA_V1SISTEMA_SECTION();

            /*" -650- PERFORM 0000-00-DECLARE-V0RELATORIOS. */

            M_0000_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -651- MOVE 'NAO' TO WFIM-V0RELATORIOS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS);

            /*" -652- PERFORM 0000-00-FETCH-V0RELATORIOS. */

            M_0000_00_FETCH_V0RELATORIOS_SECTION();

            /*" -653- IF WFIM-V0RELATORIOS EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS == "SIM")
            {

                /*" -654- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -655- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -656- DISPLAY '//     ==>     SI0820B      <==        //' */
                _.Display($"//     ==>     SI0820B      <==        //");

                /*" -657- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -658- DISPLAY '// ==>  NAO HOUVE SOLICITACAO DO   <== //' */
                _.Display($"// ==>  NAO HOUVE SOLICITACAO DO   <== //");

                /*" -659- DISPLAY '// ==>  USUARIO PARA EXECUCAO DO   <== //' */
                _.Display($"// ==>  USUARIO PARA EXECUCAO DO   <== //");

                /*" -660- DISPLAY '// ==>  PGM. NA V0RELATORIOS       <== //' */
                _.Display($"// ==>  PGM. NA V0RELATORIOS       <== //");

                /*" -661- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -662- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -664- GO TO 0000-99-ENCERRA. */

                M_0000_99_ENCERRA(); //GOTO
                return;
            }


            /*" -666- OPEN OUTPUT RSI0820B. */
            RSI0820B.Open(REG_SI0820B);

            /*" -669- PERFORM 0000-00-PROCESSA-V0RELATORIOS UNTIL (WFIM-V0RELATORIOS EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS == "SIM")))
            {

                M_0000_00_PROCESSA_V0RELATORIOS_SECTION();
            }

            /*" -671- PERFORM 0000-00-DELETE-V0RELATORIOS. */

            M_0000_00_DELETE_V0RELATORIOS_SECTION();

            /*" -672- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -672- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -675- DISPLAY 'ERRO ACESSO COMMIT' */
                _.Display($"ERRO ACESSO COMMIT");

                /*" -677- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -678- DISPLAY '////////////////////////' . */
            _.Display($"////////////////////////");

            /*" -679- DISPLAY '//  RELATORIO GERADO  //' . */
            _.Display($"//  RELATORIO GERADO  //");

            /*" -681- DISPLAY '////////////////////////' . */
            _.Display($"////////////////////////");

            /*" -681- CLOSE RSI0820B. */
            RSI0820B.Close();

        }

        [StopWatch]
        /*" M-0000-99-ENCERRA */
        private void M_0000_99_ENCERRA(bool isPerform = false)
        {
            /*" -685- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -686- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -687- DISPLAY '//     ==>     SI0820B      <==        //' */
            _.Display($"//     ==>     SI0820B      <==        //");

            /*" -688- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -689- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -690- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -691- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -691- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-00-PROCESSA-V0RELATORIOS-SECTION */
        private void M_0000_00_PROCESSA_V0RELATORIOS_SECTION()
        {
            /*" -706- PERFORM 0000-00-PREPARA-DESTINATARIO. */

            M_0000_00_PREPARA_DESTINATARIO_SECTION();

            /*" -707- MOVE SPACES TO W-TIPO-SOLICITACAO. */
            _.Move("", AREA_DE_WORK.W_TIPO_SOLICITACAO);

            /*" -708- IF V0RELA-RAMO EQUAL ZERO */

            if (V0RELA_RAMO == 00)
            {

                /*" -709- MOVE ZEROS TO WHOST-RAMO-INI */
                _.Move(0, WHOST_RAMO_INI);

                /*" -710- MOVE 99 TO WHOST-RAMO-FIM */
                _.Move(99, WHOST_RAMO_FIM);

                /*" -711- ELSE */
            }
            else
            {


                /*" -712- MOVE 'RAMO' TO W-TIPO-SOLICITACAO */
                _.Move("RAMO", AREA_DE_WORK.W_TIPO_SOLICITACAO);

                /*" -714- MOVE V0RELA-RAMO TO W-RAMO-APOLICE-INI W-RAMO-APOLICE-FIM */
                _.Move(V0RELA_RAMO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_ALFA_INI.W_RAMO_APOLICE_INI, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_ALFA_FIM.W_RAMO_APOLICE_FIM);

                /*" -716- MOVE 010 TO W-ORGAO-APOLICE-INI W-ORGAO-APOLICE-FIM */
                _.Move(010, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_ALFA_INI.W_ORGAO_APOLICE_INI, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_ALFA_FIM.W_ORGAO_APOLICE_FIM);

                /*" -717- MOVE ZEROS TO W-NUM-APOLICE-INI */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_ALFA_INI.W_NUM_APOLICE_INI);

                /*" -718- MOVE 99999999 TO W-NUM-APOLICE-FIM */
                _.Move(99999999, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_ALFA_FIM.W_NUM_APOLICE_FIM);

                /*" -719- MOVE W-APOLICE-NUM-INI TO WHOST-NUM-APOLICE-INI */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_NUM_INI, WHOST_NUM_APOLICE_INI);

                /*" -720- MOVE W-APOLICE-NUM-FIM TO WHOST-NUM-APOLICE-FIM */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_APOLICE_NUM_FIM, WHOST_NUM_APOLICE_FIM);

                /*" -723- MOVE V0RELA-RAMO TO WHOST-RAMO-INI WHOST-RAMO-FIM. */
                _.Move(V0RELA_RAMO, WHOST_RAMO_INI, WHOST_RAMO_FIM);
            }


            /*" -724- IF V0RELA-NUM-APOLICE NOT EQUAL ZERO */

            if (V0RELA_NUM_APOLICE != 00)
            {

                /*" -725- MOVE 'APOLICE' TO W-TIPO-SOLICITACAO */
                _.Move("APOLICE", AREA_DE_WORK.W_TIPO_SOLICITACAO);

                /*" -728- MOVE V0RELA-NUM-APOLICE TO WHOST-NUM-APOLICE-INI WHOST-NUM-APOLICE-FIM. */
                _.Move(V0RELA_NUM_APOLICE, WHOST_NUM_APOLICE_INI, WHOST_NUM_APOLICE_FIM);
            }


            /*" -729- PERFORM 0000-00-DECLARE-CUR-PRINC. */

            M_0000_00_DECLARE_CUR_PRINC_SECTION();

            /*" -730- MOVE 'NAO' TO WFIM-CUR-PRINC. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CUR_PRINC);

            /*" -732- PERFORM 0000-00-FETCH-CUR-PRINC. */

            M_0000_00_FETCH_CUR_PRINC_SECTION();

            /*" -733- IF WFIM-CUR-PRINC EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CUR_PRINC == "SIM")
            {

                /*" -734- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -735- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -736- DISPLAY '//     ==>     SI0820B      <==        //' */
                _.Display($"//     ==>     SI0820B      <==        //");

                /*" -737- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -738- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -739- DISPLAY '// ==> NADA SELECIONADO NA TABELA  <== //' */
                _.Display($"// ==> NADA SELECIONADO NA TABELA  <== //");

                /*" -740- DISPLAY '// ==> CREDIAPOL PARA OS DADOS     <== //' */
                _.Display($"// ==> CREDIAPOL PARA OS DADOS     <== //");

                /*" -741- DISPLAY '// ==> SOLICITADOS NA V0RELATORIOS <== //' */
                _.Display($"// ==> SOLICITADOS NA V0RELATORIOS <== //");

                /*" -742- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -743- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -744- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -745- PERFORM 0000-00-FETCH-V0RELATORIOS */

                M_0000_00_FETCH_V0RELATORIOS_SECTION();

                /*" -747- GO TO 0000-99-PROCESSA-V0RELATORIOS. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V0RELATORIOS*/ //GOTO
                return;
            }


            /*" -749- PERFORM 0000-00-PREPARA-CABECALHO. */

            M_0000_00_PREPARA_CABECALHO_SECTION();

            /*" -761- MOVE ZEROS TO W-GER-QTD-PRE-MENSAL W-GER-VAL-PRE-MENSAL W-GER-QTD-SIN-MENSAL W-GER-VAL-SIN-MENSAL W-GER-QTD-PRE-ACUMULADO W-GER-VAL-PRE-ACUMULADO W-GER-QTD-SIN-ACUMULADO W-GER-VAL-SIN-ACUMULADO W-GER-QTD-PEN-ACUMULADO W-GER-VAL-PEN-ACUMULADO W-AC-PAGINA. */
            _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PEN_ACUMULADO, AREA_DE_WORK.W_AC_PAGINA);

            /*" -764- PERFORM 0000-00-PROCESSA-CUR-PRINC UNTIL WFIM-CUR-PRINC EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CUR_PRINC == "SIM"))
            {

                M_0000_00_PROCESSA_CUR_PRINC_SECTION();
            }

            /*" -766- PERFORM 0000-00-IMPRIME-TOTAL-GERAL. */

            M_0000_00_IMPRIME_TOTAL_GERAL_SECTION();

            /*" -767- DISPLAY '//////////////////////////////////////////////////' . */
            _.Display($"//////////////////////////////////////////////////");

            /*" -768- DISPLAY '// TERMINADO O RELATORIO PARA V0RELATORIOS LIDA //' . */
            _.Display($"// TERMINADO O RELATORIO PARA V0RELATORIOS LIDA //");

            /*" -770- DISPLAY '//////////////////////////////////////////////////' . */
            _.Display($"//////////////////////////////////////////////////");

            /*" -770- PERFORM 0000-00-FETCH-V0RELATORIOS. */

            M_0000_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-DECLARE-CUR-PRINC-SECTION */
        private void M_0000_00_DECLARE_CUR_PRINC_SECTION()
        {
            /*" -779- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -802- PERFORM M_0000_00_DECLARE_CUR_PRINC_DB_DECLARE_1 */

            M_0000_00_DECLARE_CUR_PRINC_DB_DECLARE_1();

            /*" -805- DISPLAY '1> INICIO OPEN DECLARE ENDOSSO/AGENCIACEF <=' */
            _.Display($"1> INICIO OPEN DECLARE ENDOSSO/AGENCIACEF <=");

            /*" -807- PERFORM 0000-00-CONTROLE-EXECUCAO */

            M_0000_00_CONTROLE_EXECUCAO_SECTION();

            /*" -808- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -808- PERFORM M_0000_00_DECLARE_CUR_PRINC_DB_OPEN_1 */

            M_0000_00_DECLARE_CUR_PRINC_DB_OPEN_1();

            /*" -811- DISPLAY '2> FIM    OPEN DECLARE ENDOSSO/AGENCIACEF <=' */
            _.Display($"2> FIM    OPEN DECLARE ENDOSSO/AGENCIACEF <=");

            /*" -813- PERFORM 0000-00-CONTROLE-EXECUCAO */

            M_0000_00_CONTROLE_EXECUCAO_SECTION();

            /*" -814- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -815- DISPLAY 'PROBLEMAS OPEN CURSOR-PRINC..... ' */
                _.Display($"PROBLEMAS OPEN CURSOR-PRINC..... ");

                /*" -815- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-CUR-PRINC-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_CUR_PRINC_DB_DECLARE_1()
        {
            /*" -802- EXEC SQL DECLARE CURSOR-PRINC CURSOR FOR SELECT AGEN.COD_ESCNEG , CRED.COD_SUREG , CRED.COD_AGENCIA , CRED.CODOPER , CRED.NUM_CONTRATO , CRED.CONTRATO_DIGITO, CRED.DTINIVIG , CRED.DTTERVIG , CRED.NUM_APOLICE , CRED.VAL_PREMIO , VALUE( ( DAYS(CRED.DTTERVIG) - DAYS(CRED.DTINIVIG) ) - 1, 00) FROM SEGUROS.V0CREDIAPOL CRED, SEGUROS.V0AGENCIACEF AGEN WHERE CRED.NUM_APOLICE BETWEEN :WHOST-NUM-APOLICE-INI AND :WHOST-NUM-APOLICE-FIM AND CRED.SITUACAO IN ( '1' , '3' ) AND CRED.COD_AGENCIA = AGEN.COD_AGENCIA AND CRED.DTINIVIG <= :V0RELA-PERI-FINAL ORDER BY AGEN.COD_ESCNEG, CRED.COD_AGENCIA END-EXEC. */
            CURSOR_PRINC = new SI0820B_CURSOR_PRINC(true);
            string GetQuery_CURSOR_PRINC()
            {
                var query = @$"SELECT AGEN.COD_ESCNEG
							, 
							CRED.COD_SUREG
							, 
							CRED.COD_AGENCIA
							, 
							CRED.CODOPER
							, 
							CRED.NUM_CONTRATO
							, 
							CRED.CONTRATO_DIGITO
							, 
							CRED.DTINIVIG
							, 
							CRED.DTTERVIG
							, 
							CRED.NUM_APOLICE
							, 
							CRED.VAL_PREMIO
							, 
							VALUE( ( DAYS(CRED.DTTERVIG) - 
							DAYS(CRED.DTINIVIG) ) - 1
							, 00) 
							FROM SEGUROS.V0CREDIAPOL CRED
							, 
							SEGUROS.V0AGENCIACEF AGEN 
							WHERE CRED.NUM_APOLICE BETWEEN 
							'{WHOST_NUM_APOLICE_INI}' AND 
							'{WHOST_NUM_APOLICE_FIM}' 
							AND CRED.SITUACAO IN ( '1'
							, '3' ) 
							AND CRED.COD_AGENCIA = AGEN.COD_AGENCIA 
							AND CRED.DTINIVIG <= '{V0RELA_PERI_FINAL}' 
							ORDER BY AGEN.COD_ESCNEG
							, CRED.COD_AGENCIA";

                return query;
            }
            CURSOR_PRINC.GetQueryEvent += GetQuery_CURSOR_PRINC;

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-CUR-PRINC-DB-OPEN-1 */
        public void M_0000_00_DECLARE_CUR_PRINC_DB_OPEN_1()
        {
            /*" -808- EXEC SQL OPEN CURSOR-PRINC END-EXEC. */

            CURSOR_PRINC.Open();

        }

        [StopWatch]
        /*" M-0000-00-SOMA-OPERACOES-SINI-DB-DECLARE-1 */
        public void M_0000_00_SOMA_OPERACOES_SINI_DB_DECLARE_1()
        {
            /*" -1088- EXEC SQL DECLARE V0HISTSINI CURSOR FOR SELECT OPERACAO , VAL_OPERACAO , DTMOVTO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0SINCRED-NUM-APOL-SINISTRO AND DTMOVTO <= :V0RELA-PERI-FINAL AND OPERACAO IN (0101, 0102, 0103, 0104, 0105, 0106, 0107, 0108, 0112, 0113, 0114, 0115, 0116, 0117, 0118, 0122, 0123, 1001, 1002, 1003, 1004, 1009, 1050) END-EXEC. */
            V0HISTSINI = new SI0820B_V0HISTSINI(true);
            string GetQuery_V0HISTSINI()
            {
                var query = @$"SELECT OPERACAO
							, 
							VAL_OPERACAO
							, 
							DTMOVTO 
							FROM SEGUROS.V0HISTSINI 
							WHERE NUM_APOL_SINISTRO = '{V0SINCRED_NUM_APOL_SINISTRO}' 
							AND DTMOVTO <= '{V0RELA_PERI_FINAL}' 
							AND OPERACAO IN (0101
							, 0102
							, 0103
							, 0104
							, 0105
							, 0106
							, 
							0107
							, 0108
							, 
							0112
							, 0113
							, 0114
							, 0115
							, 0116
							, 
							0117
							, 0118
							, 
							0122
							, 0123
							, 
							1001
							, 1002
							, 1003
							, 1004
							, 1009
							, 1050)";

                return query;
            }
            V0HISTSINI.GetQueryEvent += GetQuery_V0HISTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_CUR_PRINC*/

        [StopWatch]
        /*" M-0000-00-FETCH-CUR-PRINC-SECTION */
        private void M_0000_00_FETCH_CUR_PRINC_SECTION()
        {
            /*" -824- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -837- PERFORM M_0000_00_FETCH_CUR_PRINC_DB_FETCH_1 */

            M_0000_00_FETCH_CUR_PRINC_DB_FETCH_1();

            /*" -841- ADD 1 TO W-AC-LIDOS-DECLARE W-AC-LIDOS-DECLARE2. */
            AREA_DE_WORK.W_AC_LIDOS_DECLARE.Value = AREA_DE_WORK.W_AC_LIDOS_DECLARE + 1;
            AREA_DE_WORK.W_AC_LIDOS_DECLARE2.Value = AREA_DE_WORK.W_AC_LIDOS_DECLARE2 + 1;

            /*" -842- IF W-AC-LIDOS-DECLARE GREATER 10000 */

            if (AREA_DE_WORK.W_AC_LIDOS_DECLARE > 10000)
            {

                /*" -843- DISPLAY '7> LIDOS 10.000 DO CURSOR PRINCIPAL <=' */
                _.Display($"7> LIDOS 10.000 DO CURSOR PRINCIPAL <=");

                /*" -844- PERFORM 0000-00-CONTROLE-EXECUCAO */

                M_0000_00_CONTROLE_EXECUCAO_SECTION();

                /*" -846- DISPLAY '8> NUM. DE LIDOS NO CUR P ATE AGORA <= ' W-AC-LIDOS-DECLARE2 */
                _.Display($"8> NUM. DE LIDOS NO CUR P ATE AGORA <= {AREA_DE_WORK.W_AC_LIDOS_DECLARE2}");

                /*" -848- MOVE ZEROS TO W-AC-LIDOS-DECLARE. */
                _.Move(0, AREA_DE_WORK.W_AC_LIDOS_DECLARE);
            }


            /*" -849- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -850- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -851- MOVE 'SIM' TO WFIM-CUR-PRINC */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CUR_PRINC);

                    /*" -852- PERFORM 0000-00-CLOSE-CUR-PRINC */

                    M_0000_00_CLOSE_CUR_PRINC_SECTION();

                    /*" -853- ELSE */
                }
                else
                {


                    /*" -854- DISPLAY 'REGISTRO COM ABEND ======> ' */
                    _.Display($"REGISTRO COM ABEND ======> ");

                    /*" -856- DISPLAY 'V0AGEN-COD-ESCNEG    = ' V0AGEN-COD-ESCNEG */
                    _.Display($"V0AGEN-COD-ESCNEG    = {V0AGEN_COD_ESCNEG}");

                    /*" -858- DISPLAY 'V0CRED-COD-SUREG     = ' V0CRED-COD-SUREG */
                    _.Display($"V0CRED-COD-SUREG     = {V0CRED_COD_SUREG}");

                    /*" -860- DISPLAY 'V0CRED-COD-AGENCIA   = ' V0CRED-COD-AGENCIA */
                    _.Display($"V0CRED-COD-AGENCIA   = {V0CRED_COD_AGENCIA}");

                    /*" -862- DISPLAY 'V0CRED-CODOPER       = ' V0CRED-CODOPER */
                    _.Display($"V0CRED-CODOPER       = {V0CRED_CODOPER}");

                    /*" -864- DISPLAY 'V0CRED-NUM-CONTRATO  = ' V0CRED-NUM-CONTRATO */
                    _.Display($"V0CRED-NUM-CONTRATO  = {V0CRED_NUM_CONTRATO}");

                    /*" -866- DISPLAY 'V0CRED-CONTRATO-DIGITO = ' V0CRED-CONTRATO-DIGITO */
                    _.Display($"V0CRED-CONTRATO-DIGITO = {V0CRED_CONTRATO_DIGITO}");

                    /*" -867- DISPLAY 'PROBLEMAS NO FETCH DA CURSOR-PRINC' */
                    _.Display($"PROBLEMAS NO FETCH DA CURSOR-PRINC");

                    /*" -867- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-CUR-PRINC-DB-FETCH-1 */
        public void M_0000_00_FETCH_CUR_PRINC_DB_FETCH_1()
        {
            /*" -837- EXEC SQL FETCH CURSOR-PRINC INTO :V0AGEN-COD-ESCNEG , :V0CRED-COD-SUREG , :V0CRED-COD-AGENCIA , :V0CRED-CODOPER , :V0CRED-NUM-CONTRATO , :V0CRED-CONTRATO-DIGITO, :V0CRED-DTINIVIG , :V0CRED-DTTERVIG , :V0CRED-NUM-APOLICE , :V0CRED-VAL-PREMIO , :W-V0CRED-QTD-DIAS-VIGENCIA END-EXEC. */

            if (CURSOR_PRINC.Fetch())
            {
                _.Move(CURSOR_PRINC.V0AGEN_COD_ESCNEG, V0AGEN_COD_ESCNEG);
                _.Move(CURSOR_PRINC.V0CRED_COD_SUREG, V0CRED_COD_SUREG);
                _.Move(CURSOR_PRINC.V0CRED_COD_AGENCIA, V0CRED_COD_AGENCIA);
                _.Move(CURSOR_PRINC.V0CRED_CODOPER, V0CRED_CODOPER);
                _.Move(CURSOR_PRINC.V0CRED_NUM_CONTRATO, V0CRED_NUM_CONTRATO);
                _.Move(CURSOR_PRINC.V0CRED_CONTRATO_DIGITO, V0CRED_CONTRATO_DIGITO);
                _.Move(CURSOR_PRINC.V0CRED_DTINIVIG, V0CRED_DTINIVIG);
                _.Move(CURSOR_PRINC.V0CRED_DTTERVIG, V0CRED_DTTERVIG);
                _.Move(CURSOR_PRINC.V0CRED_NUM_APOLICE, V0CRED_NUM_APOLICE);
                _.Move(CURSOR_PRINC.V0CRED_VAL_PREMIO, V0CRED_VAL_PREMIO);
                _.Move(CURSOR_PRINC.W_V0CRED_QTD_DIAS_VIGENCIA, W_V0CRED_QTD_DIAS_VIGENCIA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_CUR_PRINC*/

        [StopWatch]
        /*" M-0000-00-CLOSE-CUR-PRINC-SECTION */
        private void M_0000_00_CLOSE_CUR_PRINC_SECTION()
        {
            /*" -876- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM M_0000_00_CLOSE_CUR_PRINC_DB_CLOSE_1 */

            M_0000_00_CLOSE_CUR_PRINC_DB_CLOSE_1();

            /*" -879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -880- DISPLAY 'PROBLEMAS CLOSE CURSOR-PRINC .... ' */
                _.Display($"PROBLEMAS CLOSE CURSOR-PRINC .... ");

                /*" -880- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-CUR-PRINC-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_CUR_PRINC_DB_CLOSE_1()
        {
            /*" -876- EXEC SQL CLOSE CURSOR-PRINC END-EXEC. */

            CURSOR_PRINC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_CUR_PRINC*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-CUR-PRINC-SECTION */
        private void M_0000_00_PROCESSA_CUR_PRINC_SECTION()
        {
            /*" -888- PERFORM 0000-00-ACESSA-NOME-ESCNEG. */

            M_0000_00_ACESSA_NOME_ESCNEG_SECTION();

            /*" -889- MOVE 80 TO W-AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.W_AC_LINHAS);

            /*" -900- MOVE ZEROS TO W-ESC-QTD-PRE-MENSAL W-ESC-VAL-PRE-MENSAL W-ESC-QTD-SIN-MENSAL W-ESC-VAL-SIN-MENSAL W-ESC-QTD-PRE-ACUMULADO W-ESC-VAL-PRE-ACUMULADO W-ESC-QTD-SIN-ACUMULADO W-ESC-VAL-SIN-ACUMULADO W-ESC-QTD-PEN-ACUMULADO W-ESC-VAL-PEN-ACUMULADO. */
            _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PEN_ACUMULADO);

            /*" -902- MOVE V0AGEN-COD-ESCNEG TO W-COD-ESCNEG-ANT. */
            _.Move(V0AGEN_COD_ESCNEG, AREA_DE_WORK.W_CHAVES_QUEBRA.W_COD_ESCNEG_ANT);

            /*" -906- PERFORM 0000-00-PROCESSA-AGENCIA UNTIL (V0AGEN-COD-ESCNEG NOT EQUAL W-COD-ESCNEG-ANT) OR (WFIM-CUR-PRINC EQUAL 'SIM' ). */

            while (!((V0AGEN_COD_ESCNEG != AREA_DE_WORK.W_CHAVES_QUEBRA.W_COD_ESCNEG_ANT) || (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CUR_PRINC == "SIM")))
            {

                M_0000_00_PROCESSA_AGENCIA_SECTION();
            }

            /*" -906- PERFORM 0000-00-IMPRIME-TOTAL-ESCNEG. */

            M_0000_00_IMPRIME_TOTAL_ESCNEG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_CUR_PRINC*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-AGENCIA-SECTION */
        private void M_0000_00_PROCESSA_AGENCIA_SECTION()
        {
            /*" -932- MOVE ZEROS TO W-AC-QTD-PRE-MENSAL W-AC-VAL-PRE-MENSAL W-AC-QTD-SIN-MENSAL W-AC-VAL-SIN-MENSAL W-AC-QTD-PRE-ACUMULADO W-AC-VAL-PRE-ACUMULADO W-AC-QTD-SIN-ACUMULADO W-AC-VAL-SIN-ACUMULADO W-AC-QTD-PEN-ACUMULADO W-AC-VAL-PEN-ACUMULADO W-AC-C-A W-AC-D-B W-AC-G-E W-AC-G-E-PEND W-AC-H-F W-AC-H-F-PEND. */
            _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_C_A, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_D_B, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_G_E, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_G_E_PEND, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_H_F, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_H_F_PEND);

            /*" -934- MOVE V0CRED-COD-AGENCIA TO W-AGENCIA-ANT. */
            _.Move(V0CRED_COD_AGENCIA, AREA_DE_WORK.W_CHAVES_QUEBRA.W_AGENCIA_ANT);

            /*" -939- PERFORM 0000-00-PROCESSA-CONTRATO UNTIL (V0AGEN-COD-ESCNEG NOT EQUAL W-COD-ESCNEG-ANT) OR (V0CRED-COD-AGENCIA NOT EQUAL W-AGENCIA-ANT) OR (WFIM-CUR-PRINC EQUAL 'SIM' ). */

            while (!((V0AGEN_COD_ESCNEG != AREA_DE_WORK.W_CHAVES_QUEBRA.W_COD_ESCNEG_ANT) || (V0CRED_COD_AGENCIA != AREA_DE_WORK.W_CHAVES_QUEBRA.W_AGENCIA_ANT) || (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CUR_PRINC == "SIM")))
            {

                M_0000_00_PROCESSA_CONTRATO_SECTION();
            }

            /*" -939- PERFORM 0000-00-IMPRIME-DETALHE. */

            M_0000_00_IMPRIME_DETALHE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_AGENCIA*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-CONTRATO-SECTION */
        private void M_0000_00_PROCESSA_CONTRATO_SECTION()
        {
            /*" -955- MOVE 'NAO' TO W-CONTRATO-TEM-SINISTRO W-CHAVE-TEM-SINI-NA-COMP. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CONTRATO_TEM_SINISTRO, AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CHAVE_TEM_SINI_NA_COMP);

            /*" -962- PERFORM 0000-00-VERIFICA-SINISTRO. */

            M_0000_00_VERIFICA_SINISTRO_SECTION();

            /*" -963- IF W-CONTRATO-TEM-SINISTRO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CONTRATO_TEM_SINISTRO == "SIM")
            {

                /*" -964- ADD 1 TO W-SINISTROS-LIDOS */
                AREA_DE_WORK.W_SINISTROS_LIDOS.Value = AREA_DE_WORK.W_SINISTROS_LIDOS + 1;

                /*" -966- PERFORM 0000-00-SOMA-OPERACOES-SINI THRU 0000-99-SOMA-OPERACOES-SINI */

                M_0000_00_SOMA_OPERACOES_SINI_SECTION();

                M_0000_01_FETCH_V0HISTSINI();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SOMA_OPERACOES_SINI*/


                /*" -967- IF W-SINISTRO-PAGO-ACUMULADO NOT EQUAL ZERO */

                if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO != 00)
                {

                    /*" -969- ADD W-SINISTRO-PAGO-ACUMULADO TO W-AC-VAL-SIN-ACUMULADO */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO;

                    /*" -970- ADD 1 TO W-AC-QTD-SIN-ACUMULADO */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO + 1;

                    /*" -972- END-IF */
                }


                /*" -973- IF W-SINISTRO-PENDENTE NOT EQUAL ZERO */

                if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE != 00)
                {

                    /*" -975- ADD W-SINISTRO-PENDENTE TO W-AC-VAL-PEN-ACUMULADO */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE;

                    /*" -976- ADD 1 TO W-AC-QTD-PEN-ACUMULADO */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO + 1;

                    /*" -978- END-IF */
                }


                /*" -979- IF W-SINISTRO-PAGO-MENSAL NOT EQUAL ZERO */

                if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL != 00)
                {

                    /*" -981- ADD W-SINISTRO-PAGO-MENSAL TO W-AC-VAL-SIN-MENSAL */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL;

                    /*" -982- ADD 1 TO W-AC-QTD-SIN-MENSAL */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL + 1;

                    /*" -990- END-IF. */
                }

            }


            /*" -991- ADD V0CRED-VAL-PREMIO TO W-AC-VAL-PRE-ACUMULADO. */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO + V0CRED_VAL_PREMIO;

            /*" -995- ADD 1 TO W-AC-QTD-PRE-ACUMULADO. */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO + 1;

            /*" -999- IF (V0CRED-DTINIVIG NOT GREATER V0RELA-PERI-INICIAL) AND (V0CRED-DTTERVIG NOT LESS V0RELA-PERI-FINAL) */

            if ((V0CRED_DTINIVIG <= V0RELA_PERI_INICIAL) && (V0CRED_DTTERVIG >= V0RELA_PERI_FINAL))
            {

                /*" -1003- IF W-CHAVE-TEM-SINI-NA-COMP EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CHAVE_TEM_SINI_NA_COMP == "SIM")
                {

                    /*" -1007- PERFORM 0000-00-CALCULA-SALDO-PREMIO */

                    M_0000_00_CALCULA_SALDO_PREMIO_SECTION();

                    /*" -1008- IF W-SALDO-PREMIO NOT EQUAL ZERO */

                    if (AREA_DE_WORK.W_AREAS_CALCULO.W_SALDO_PREMIO != 00)
                    {

                        /*" -1010- ADD W-SALDO-PREMIO TO W-AC-VAL-PRE-MENSAL */
                        AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_SALDO_PREMIO;

                        /*" -1012- ADD 1 TO W-AC-QTD-PRE-MENSAL */
                        AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL + 1;

                        /*" -1013- END-IF */
                    }


                    /*" -1018- ELSE */
                }
                else
                {


                    /*" -1025- COMPUTE W-VAL-PRO-RATA-PREMIO = (V0CRED-VAL-PREMIO / W-V0CRED-QTD-DIAS-VIGENCIA) * 30 */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_VAL_PRO_RATA_PREMIO.Value = (V0CRED_VAL_PREMIO / W_V0CRED_QTD_DIAS_VIGENCIA) * 30;

                    /*" -1026- IF W-VAL-PRO-RATA-PREMIO NOT EQUAL ZERO */

                    if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_VAL_PRO_RATA_PREMIO != 00)
                    {

                        /*" -1028- ADD W-VAL-PRO-RATA-PREMIO TO W-AC-VAL-PRE-MENSAL */
                        AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_VAL_PRO_RATA_PREMIO;

                        /*" -1031- ADD 1 TO W-AC-QTD-PRE-MENSAL. */
                        AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL + 1;
                    }

                }

            }


            /*" -1031- PERFORM 0000-00-FETCH-CUR-PRINC. */

            M_0000_00_FETCH_CUR_PRINC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_CONTRATO*/

        [StopWatch]
        /*" M-0000-00-VERIFICA-SINISTRO-SECTION */
        private void M_0000_00_VERIFICA_SINISTRO_SECTION()
        {
            /*" -1041- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1050- PERFORM M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1 */

            M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1();

            /*" -1053- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -1054- MOVE 'SIM' TO W-CONTRATO-TEM-SINISTRO */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CONTRATO_TEM_SINISTRO);

                /*" -1055- ELSE */
            }
            else
            {


                /*" -1056- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1057- MOVE 'NAO' TO W-CONTRATO-TEM-SINISTRO */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CONTRATO_TEM_SINISTRO);

                    /*" -1058- ELSE */
                }
                else
                {


                    /*" -1059- DISPLAY 'PROBLEMAS NA VERIFICA SINISTRO ......' */
                    _.Display($"PROBLEMAS NA VERIFICA SINISTRO ......");

                    /*" -1059- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-VERIFICA-SINISTRO-DB-SELECT-1 */
        public void M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1()
        {
            /*" -1050- EXEC SQL SELECT NUM_APOL_SINISTRO INTO :V0SINCRED-NUM-APOL-SINISTRO FROM SEGUROS.V0SINCREDINT WHERE COD_SUREG = :V0CRED-COD-SUREG AND COD_AGENCIA = :V0CRED-COD-AGENCIA AND CODOPER = :V0CRED-CODOPER AND NUM_CONTRATO = :V0CRED-NUM-CONTRATO AND CONTRATO_DIGITO = :V0CRED-CONTRATO-DIGITO END-EXEC. */

            var m_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1 = new M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1()
            {
                V0CRED_CONTRATO_DIGITO = V0CRED_CONTRATO_DIGITO.ToString(),
                V0CRED_NUM_CONTRATO = V0CRED_NUM_CONTRATO.ToString(),
                V0CRED_COD_AGENCIA = V0CRED_COD_AGENCIA.ToString(),
                V0CRED_COD_SUREG = V0CRED_COD_SUREG.ToString(),
                V0CRED_CODOPER = V0CRED_CODOPER.ToString(),
            };

            var executed_1 = M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1.Execute(m_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SINCRED_NUM_APOL_SINISTRO, V0SINCRED_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_VERIFICA_SINISTRO*/

        [StopWatch]
        /*" M-0000-00-SOMA-OPERACOES-SINI-SECTION */
        private void M_0000_00_SOMA_OPERACOES_SINI_SECTION()
        {
            /*" -1072- MOVE ZEROS TO W-SINISTRO-PAGO-ACUMULADO W-SINISTRO-PAGO-MENSAL W-SINISTRO-PENDENTE. */
            _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE);

            /*" -1074- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1088- PERFORM M_0000_00_SOMA_OPERACOES_SINI_DB_DECLARE_1 */

            M_0000_00_SOMA_OPERACOES_SINI_DB_DECLARE_1();

            /*" -1090- PERFORM M_0000_00_SOMA_OPERACOES_SINI_DB_OPEN_1 */

            M_0000_00_SOMA_OPERACOES_SINI_DB_OPEN_1();

            /*" -1093- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1094- MOVE '010' TO WNR-EXEC-SQL */
                _.Move("010", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

                /*" -1095- DISPLAY 'PROBLEMAS OPEN V0HISTSINI ...... ' */
                _.Display($"PROBLEMAS OPEN V0HISTSINI ...... ");

                /*" -1095- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM M_0000_01_FETCH_V0HISTSINI */

            M_0000_01_FETCH_V0HISTSINI();

        }

        [StopWatch]
        /*" M-0000-00-SOMA-OPERACOES-SINI-DB-OPEN-1 */
        public void M_0000_00_SOMA_OPERACOES_SINI_DB_OPEN_1()
        {
            /*" -1090- EXEC SQL OPEN V0HISTSINI END-EXEC. */

            V0HISTSINI.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -1613- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT RAMO , NUM_APOLICE , PERI_INICIAL , PERI_FINAL , CODUSU , APOLIDER , ENDOSLID FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0820B' AND IDSISTEM = 'SI' END-EXEC. */
            V0RELATORIOS = new SI0820B_V0RELATORIOS(false);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT RAMO
							, 
							NUM_APOLICE
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							CODUSU
							, 
							APOLIDER
							, 
							ENDOSLID 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'SI0820B' 
							AND IDSISTEM = 'SI'";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" M-0000-01-FETCH-V0HISTSINI */
        private void M_0000_01_FETCH_V0HISTSINI(bool isPerform = false)
        {
            /*" -1100- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1106- PERFORM M_0000_01_FETCH_V0HISTSINI_DB_FETCH_1 */

            M_0000_01_FETCH_V0HISTSINI_DB_FETCH_1();

            /*" -1110- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1111- DISPLAY 'PROBLEMAS FETCH V0HISTSINI ...... ' */
                _.Display($"PROBLEMAS FETCH V0HISTSINI ...... ");

                /*" -1113- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1114- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1115- MOVE '012' TO WNR-EXEC-SQL */
                _.Move("012", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

                /*" -1115- PERFORM M_0000_01_FETCH_V0HISTSINI_DB_CLOSE_1 */

                M_0000_01_FETCH_V0HISTSINI_DB_CLOSE_1();

                /*" -1117- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1118- DISPLAY 'PROBLEMAS CLOSE V0HISTSINI ...... ' */
                    _.Display($"PROBLEMAS CLOSE V0HISTSINI ...... ");

                    /*" -1119- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1120- ELSE */
                }
                else
                {


                    /*" -1124- GO TO 0000-99-SOMA-OPERACOES-SINI. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SOMA_OPERACOES_SINI*/ //GOTO
                    return;
                }

            }


            /*" -1125- IF V0HISTSINI-OPERACAO EQUAL 101 */

            if (V0HISTSINI_OPERACAO == 101)
            {

                /*" -1128- IF (V0HISTSINI-DTMOVTO NOT GREATER V0RELA-PERI-FINAL) AND (V0HISTSINI-DTMOVTO NOT LESS V0RELA-PERI-INICIAL) */

                if ((V0HISTSINI_DTMOVTO <= V0RELA_PERI_FINAL) && (V0HISTSINI_DTMOVTO >= V0RELA_PERI_INICIAL))
                {

                    /*" -1133- MOVE 'SIM' TO W-CHAVE-TEM-SINI-NA-COMP. */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.W_CHAVE_TEM_SINI_NA_COMP);
                }

            }


            /*" -1135- IF V0HISTSINI-OPERACAO EQUAL 1001 OR 1002 OR 1003 OR 1004 OR 1009 */

            if (V0HISTSINI_OPERACAO.In("1001", "1002", "1003", "1004", "1009"))
            {

                /*" -1142- COMPUTE W-SINISTRO-PAGO-ACUMULADO = W-SINISTRO-PAGO-ACUMULADO + V0HISTSINI-VAL-OPERACAO. */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO + V0HISTSINI_VAL_OPERACAO;
            }


            /*" -1143- IF V0HISTSINI-OPERACAO EQUAL 1050 */

            if (V0HISTSINI_OPERACAO == 1050)
            {

                /*" -1150- COMPUTE W-SINISTRO-PAGO-ACUMULADO = W-SINISTRO-PAGO-ACUMULADO - V0HISTSINI-VAL-OPERACAO. */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_ACUMULADO - V0HISTSINI_VAL_OPERACAO;
            }


            /*" -1152- IF V0HISTSINI-OPERACAO EQUAL 1001 OR 1002 OR 1003 OR 1004 OR 1009 */

            if (V0HISTSINI_OPERACAO.In("1001", "1002", "1003", "1004", "1009"))
            {

                /*" -1155- IF (V0HISTSINI-DTMOVTO NOT GREATER V0RELA-PERI-FINAL) AND (V0HISTSINI-DTMOVTO NOT LESS V0RELA-PERI-INICIAL) */

                if ((V0HISTSINI_DTMOVTO <= V0RELA_PERI_FINAL) && (V0HISTSINI_DTMOVTO >= V0RELA_PERI_INICIAL))
                {

                    /*" -1162- COMPUTE W-SINISTRO-PAGO-MENSAL = W-SINISTRO-PAGO-MENSAL + V0HISTSINI-VAL-OPERACAO. */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL + V0HISTSINI_VAL_OPERACAO;
                }

            }


            /*" -1163- IF V0HISTSINI-OPERACAO EQUAL 1050 */

            if (V0HISTSINI_OPERACAO == 1050)
            {

                /*" -1166- IF (V0HISTSINI-DTMOVTO NOT GREATER V0RELA-PERI-FINAL) AND (V0HISTSINI-DTMOVTO NOT LESS V0RELA-PERI-INICIAL) */

                if ((V0HISTSINI_DTMOVTO <= V0RELA_PERI_FINAL) && (V0HISTSINI_DTMOVTO >= V0RELA_PERI_INICIAL))
                {

                    /*" -1173- COMPUTE W-SINISTRO-PAGO-MENSAL = W-SINISTRO-PAGO-MENSAL - V0HISTSINI-VAL-OPERACAO. */
                    AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PAGO_MENSAL - V0HISTSINI_VAL_OPERACAO;
                }

            }


            /*" -1178- IF V0HISTSINI-OPERACAO EQUAL 0101 OR 0102 OR 0103 OR 0104 OR 0112 OR 0113 OR 0114 OR 0122 OR 0123 OR 1050 */

            if (V0HISTSINI_OPERACAO.In("0101", "0102", "0103", "0104", "0112", "0113", "0114", "0122", "0123", "1050"))
            {

                /*" -1180- COMPUTE W-SINISTRO-PENDENTE = W-SINISTRO-PENDENTE + V0HISTSINI-VAL-OPERACAO */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE + V0HISTSINI_VAL_OPERACAO;

                /*" -1181- ELSE */
            }
            else
            {


                /*" -1184- COMPUTE W-SINISTRO-PENDENTE = W-SINISTRO-PENDENTE - V0HISTSINI-VAL-OPERACAO. */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_SINISTRO_PENDENTE - V0HISTSINI_VAL_OPERACAO;
            }


            /*" -1184- GO TO 0000-01-FETCH-V0HISTSINI. */
            new Task(() => M_0000_01_FETCH_V0HISTSINI()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" M-0000-01-FETCH-V0HISTSINI-DB-FETCH-1 */
        public void M_0000_01_FETCH_V0HISTSINI_DB_FETCH_1()
        {
            /*" -1106- EXEC SQL FETCH V0HISTSINI INTO :V0HISTSINI-OPERACAO , :V0HISTSINI-VAL-OPERACAO , :V0HISTSINI-DTMOVTO END-EXEC. */

            if (V0HISTSINI.Fetch())
            {
                _.Move(V0HISTSINI.V0HISTSINI_OPERACAO, V0HISTSINI_OPERACAO);
                _.Move(V0HISTSINI.V0HISTSINI_VAL_OPERACAO, V0HISTSINI_VAL_OPERACAO);
                _.Move(V0HISTSINI.V0HISTSINI_DTMOVTO, V0HISTSINI_DTMOVTO);
            }

        }

        [StopWatch]
        /*" M-0000-01-FETCH-V0HISTSINI-DB-CLOSE-1 */
        public void M_0000_01_FETCH_V0HISTSINI_DB_CLOSE_1()
        {
            /*" -1115- EXEC SQL CLOSE V0HISTSINI END-EXEC */

            V0HISTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SOMA_OPERACOES_SINI*/

        [StopWatch]
        /*" M-0000-00-CALCULA-SALDO-PREMIO-SECTION */
        private void M_0000_00_CALCULA_SALDO_PREMIO_SECTION()
        {
            /*" -1201- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1207- PERFORM M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1 */

            M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1();

            /*" -1210- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1211- DISPLAY 'PROBLEMAS NO ACESSO A V1SISTEMA   ......' */
                _.Display($"PROBLEMAS NO ACESSO A V1SISTEMA   ......");

                /*" -1216- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1217- IF W-QTD-DIAS-COMP-TERVIG GREATER ZERO */

            if (W_QTD_DIAS_COMP_TERVIG > 00)
            {

                /*" -1219- COMPUTE W-SALDO-PREMIO = (V0CRED-VAL-PREMIO / W-V0CRED-QTD-DIAS-VIGENCIA) * W-QTD-DIAS-COMP-TERVIG. */
                AREA_DE_WORK.W_AREAS_CALCULO.W_SALDO_PREMIO.Value = (V0CRED_VAL_PREMIO / W_V0CRED_QTD_DIAS_VIGENCIA) * W_QTD_DIAS_COMP_TERVIG;
            }


        }

        [StopWatch]
        /*" M-0000-00-CALCULA-SALDO-PREMIO-DB-SELECT-1 */
        public void M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1()
        {
            /*" -1207- EXEC SQL SELECT VALUE( ( DAYS(:V0CRED-DTTERVIG) - DAYS(:V0RELA-PERI-INICIAL) ) - 1, 0) INTO :W-QTD-DIAS-COMP-TERVIG FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1 = new M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1()
            {
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0CRED_DTTERVIG = V0CRED_DTTERVIG.ToString(),
            };

            var executed_1 = M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1.Execute(m_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_QTD_DIAS_COMP_TERVIG, W_QTD_DIAS_COMP_TERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CALCULA_SALDO_PREMIO*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-DETALHE-SECTION */
        private void M_0000_00_IMPRIME_DETALHE_SECTION()
        {
            /*" -1227- MOVE W-AGENCIA-ANT TO LD01-COD-AGENCIA. */
            _.Move(AREA_DE_WORK.W_CHAVES_QUEBRA.W_AGENCIA_ANT, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_COD_AGENCIA);

            /*" -1228- MOVE W-AC-QTD-PRE-MENSAL TO LD01-QTD-PR-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_QTD_PR_MEN);

            /*" -1229- MOVE W-AC-VAL-PRE-MENSAL TO LD01-VAL-PR-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_VAL_PR_MEN);

            /*" -1230- MOVE W-AC-QTD-SIN-MENSAL TO LD01-QTD-SI-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_QTD_SI_MEN);

            /*" -1232- MOVE W-AC-VAL-SIN-MENSAL TO LD01-VAL-SI-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_VAL_SI_MEN);

            /*" -1233- IF W-AC-QTD-PRE-MENSAL NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL != 00)
            {

                /*" -1235- COMPUTE W-AC-C-A = (W-AC-QTD-SIN-MENSAL / W-AC-QTD-PRE-MENSAL) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_C_A.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL) * 100;

                /*" -1236- MOVE W-AC-C-A TO LD01-C-A-MEN */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_C_A, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_C_A_MEN);

                /*" -1237- ELSE */
            }
            else
            {


                /*" -1239- MOVE ZEROS TO LD01-C-A-MEN. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_C_A_MEN);
            }


            /*" -1240- IF W-AC-VAL-PRE-MENSAL NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL != 00)
            {

                /*" -1242- COMPUTE W-AC-D-B = (W-AC-VAL-SIN-MENSAL / W-AC-VAL-PRE-MENSAL) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_D_B.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL) * 100;

                /*" -1243- MOVE W-AC-D-B TO LD01-D-B-MEN */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_D_B, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_D_B_MEN);

                /*" -1244- ELSE */
            }
            else
            {


                /*" -1246- MOVE ZEROS TO LD01-D-B-MEN. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_D_B_MEN);
            }


            /*" -1247- MOVE W-AC-QTD-PRE-ACUMULADO TO LD01-QTD-PR-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_QTD_PR_ACU);

            /*" -1248- MOVE W-AC-VAL-PRE-ACUMULADO TO LD01-VAL-PR-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_VAL_PR_ACU);

            /*" -1249- MOVE W-AC-QTD-SIN-ACUMULADO TO LD01-QTD-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_QTD_SI_ACU);

            /*" -1251- MOVE W-AC-VAL-SIN-ACUMULADO TO LD01-VAL-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_VAL_SI_ACU);

            /*" -1252- IF W-AC-QTD-PRE-ACUMULADO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO != 00)
            {

                /*" -1255- COMPUTE W-AC-G-E = (W-AC-QTD-SIN-ACUMULADO / W-AC-QTD-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_G_E.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO) * 100;

                /*" -1256- MOVE W-AC-G-E TO LD01-G-E-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_G_E, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_G_E_ACU);

                /*" -1257- ELSE */
            }
            else
            {


                /*" -1259- MOVE ZEROS TO LD01-G-E-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_G_E_ACU);
            }


            /*" -1260- IF W-AC-VAL-PRE-ACUMULADO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO != 00)
            {

                /*" -1263- COMPUTE W-AC-H-F = (W-AC-VAL-SIN-ACUMULADO / W-AC-VAL-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_H_F.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO) * 100;

                /*" -1264- MOVE W-AC-H-F TO LD01-H-F-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_H_F, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_H_F_ACU);

                /*" -1265- ELSE */
            }
            else
            {


                /*" -1267- MOVE ZEROS TO LD01-H-F-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.LD01_H_F_ACU);
            }


            /*" -1268- MOVE W-AC-QTD-PEN-ACUMULADO TO LD02-QTD-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.LD02_QTD_SI_ACU);

            /*" -1270- MOVE W-AC-VAL-PEN-ACUMULADO TO LD02-VAL-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.LD02_VAL_SI_ACU);

            /*" -1271- IF W-AC-QTD-PRE-ACUMULADO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO != 00)
            {

                /*" -1274- COMPUTE W-AC-G-E-PEND = (W-AC-QTD-PEN-ACUMULADO / W-AC-QTD-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_G_E_PEND.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO) * 100;

                /*" -1275- MOVE W-AC-G-E-PEND TO LD02-G-E-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_G_E_PEND, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.LD02_G_E_ACU);

                /*" -1276- ELSE */
            }
            else
            {


                /*" -1278- MOVE ZEROS TO LD02-G-E-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.LD02_G_E_ACU);
            }


            /*" -1279- IF W-AC-VAL-PRE-ACUMULADO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO != 00)
            {

                /*" -1282- COMPUTE W-AC-H-F-PEND = (W-AC-VAL-PEN-ACUMULADO / W-AC-VAL-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_H_F_PEND.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO) * 100;

                /*" -1283- MOVE W-AC-H-F-PEND TO LD02-H-F-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_H_F_PEND, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.LD02_H_F_ACU);

                /*" -1284- ELSE */
            }
            else
            {


                /*" -1286- MOVE ZEROS TO LD02-H-F-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.LD02_H_F_ACU);
            }


            /*" -1287- IF W-AC-LINHAS GREATER 58 */

            if (AREA_DE_WORK.W_AC_LINHAS > 58)
            {

                /*" -1289- PERFORM 0000-00-MONTA-CABECALHO. */

                M_0000_00_MONTA_CABECALHO_SECTION();
            }


            /*" -1290- WRITE REG-SI0820B FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD01.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1291- WRITE REG-SI0820B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LD02.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1295- ADD 2 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 2;

            /*" -1298- ADD W-AC-QTD-PRE-MENSAL TO W-ESC-QTD-PRE-MENSAL W-GER-QTD-PRE-MENSAL . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_MENSAL;

            /*" -1301- ADD W-AC-VAL-PRE-MENSAL TO W-ESC-VAL-PRE-MENSAL W-GER-VAL-PRE-MENSAL . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_MENSAL;

            /*" -1304- ADD W-AC-QTD-SIN-MENSAL TO W-ESC-QTD-SIN-MENSAL W-GER-QTD-SIN-MENSAL . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_MENSAL;

            /*" -1307- ADD W-AC-VAL-SIN-MENSAL TO W-ESC-VAL-SIN-MENSAL W-GER-VAL-SIN-MENSAL . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_MENSAL.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_MENSAL + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_MENSAL;

            /*" -1310- ADD W-AC-QTD-PRE-ACUMULADO TO W-ESC-QTD-PRE-ACUMULADO W-GER-QTD-PRE-ACUMULADO . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PRE_ACUMULADO;

            /*" -1313- ADD W-AC-VAL-PRE-ACUMULADO TO W-ESC-VAL-PRE-ACUMULADO W-GER-VAL-PRE-ACUMULADO . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PRE_ACUMULADO;

            /*" -1316- ADD W-AC-QTD-SIN-ACUMULADO TO W-ESC-QTD-SIN-ACUMULADO W-GER-QTD-SIN-ACUMULADO . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_SIN_ACUMULADO;

            /*" -1319- ADD W-AC-VAL-SIN-ACUMULADO TO W-ESC-VAL-SIN-ACUMULADO W-GER-VAL-SIN-ACUMULADO . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_SIN_ACUMULADO;

            /*" -1322- ADD W-AC-QTD-PEN-ACUMULADO TO W-ESC-QTD-PEN-ACUMULADO W-GER-QTD-PEN-ACUMULADO . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PEN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PEN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_QTD_PEN_ACUMULADO;

            /*" -1324- ADD W-AC-VAL-PEN-ACUMULADO TO W-ESC-VAL-PEN-ACUMULADO W-GER-VAL-PEN-ACUMULADO . */
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PEN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO;
            AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PEN_ACUMULADO.Value = AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_AC_VAL_PEN_ACUMULADO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_DETALHE*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-TOTAL-ESCNEG-SECTION */
        private void M_0000_00_IMPRIME_TOTAL_ESCNEG_SECTION()
        {
            /*" -1334- MOVE 'ESC. NEG.   ' TO LT02-TIPO-TOTAL . */
            _.Move("ESC. NEG.   ", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_TIPO_TOTAL);

            /*" -1335- MOVE W-ESC-QTD-PRE-MENSAL TO LT01-QTD-PR-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_PR_MEN);

            /*" -1336- MOVE W-ESC-VAL-PRE-MENSAL TO LT01-VAL-PR-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_PR_MEN);

            /*" -1337- MOVE W-ESC-QTD-SIN-MENSAL TO LT01-QTD-SI-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_SI_MEN);

            /*" -1338- MOVE W-ESC-VAL-SIN-MENSAL TO LT01-VAL-SI-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_SI_MEN);

            /*" -1339- MOVE W-ESC-QTD-PRE-ACUMULADO TO LT01-QTD-PR-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_PR_ACU);

            /*" -1340- MOVE W-ESC-VAL-PRE-ACUMULADO TO LT01-VAL-PR-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_PR_ACU);

            /*" -1341- MOVE W-ESC-QTD-SIN-ACUMULADO TO LT01-QTD-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_SI_ACU);

            /*" -1342- MOVE W-ESC-VAL-SIN-ACUMULADO TO LT01-VAL-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_SI_ACU);

            /*" -1343- MOVE W-ESC-QTD-PEN-ACUMULADO TO LT02-QTD-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_QTD_SI_ACU);

            /*" -1345- MOVE W-ESC-VAL-PEN-ACUMULADO TO LT02-VAL-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_VAL_SI_ACU);

            /*" -1346- IF W-ESC-QTD-PRE-MENSAL NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_MENSAL != 00)
            {

                /*" -1349- COMPUTE W-TOT-CALCULO-GERAL = (W-ESC-QTD-SIN-MENSAL / W-ESC-QTD-PRE-MENSAL) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_MENSAL / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_MENSAL) * 100;

                /*" -1350- MOVE W-TOT-CALCULO-GERAL TO LT01-C-A-MEN */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_C_A_MEN);

                /*" -1351- ELSE */
            }
            else
            {


                /*" -1353- MOVE ZEROS TO LT01-C-A-MEN. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_C_A_MEN);
            }


            /*" -1354- IF W-ESC-VAL-PRE-MENSAL NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_MENSAL != 00)
            {

                /*" -1357- COMPUTE W-TOT-CALCULO-GERAL = (W-ESC-VAL-SIN-MENSAL / W-ESC-VAL-PRE-MENSAL) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_MENSAL / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_MENSAL) * 100;

                /*" -1358- MOVE W-TOT-CALCULO-GERAL TO LT01-D-B-MEN */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_D_B_MEN);

                /*" -1359- ELSE */
            }
            else
            {


                /*" -1361- MOVE ZEROS TO LT01-D-B-MEN. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_D_B_MEN);
            }


            /*" -1362- IF W-ESC-QTD-PRE-ACUMULADO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO != 00)
            {

                /*" -1365- COMPUTE W-TOT-CALCULO-GERAL = (W-ESC-QTD-SIN-ACUMULADO / W-ESC-QTD-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO) * 100;

                /*" -1366- MOVE W-TOT-CALCULO-GERAL TO LT01-G-E-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_G_E_ACU);

                /*" -1367- ELSE */
            }
            else
            {


                /*" -1369- MOVE ZEROS TO LT01-G-E-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_G_E_ACU);
            }


            /*" -1370- IF W-ESC-VAL-PRE-ACUMULADO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO != 00)
            {

                /*" -1373- COMPUTE W-TOT-CALCULO-GERAL = (W-ESC-VAL-SIN-ACUMULADO / W-ESC-VAL-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO) * 100;

                /*" -1374- MOVE W-TOT-CALCULO-GERAL TO LT01-H-F-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_H_F_ACU);

                /*" -1375- ELSE */
            }
            else
            {


                /*" -1377- MOVE ZEROS TO LT01-H-F-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_H_F_ACU);
            }


            /*" -1378- IF W-ESC-QTD-PRE-ACUMULADO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO != 00)
            {

                /*" -1382- COMPUTE W-TOT-CALCULO-GERAL = ( (W-ESC-QTD-PEN-ACUMULADO + W-ESC-QTD-SIN-ACUMULADO) / W-ESC-QTD-PRE-ACUMULADO ) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL.Value = ((AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_SIN_ACUMULADO) / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_QTD_PRE_ACUMULADO) * 100;

                /*" -1383- MOVE W-TOT-CALCULO-GERAL TO LT02-G-E-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_G_E_ACU);

                /*" -1384- ELSE */
            }
            else
            {


                /*" -1386- MOVE ZEROS TO LT02-G-E-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_G_E_ACU);
            }


            /*" -1387- IF W-ESC-VAL-PRE-ACUMULADO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO != 00)
            {

                /*" -1391- COMPUTE W-TOT-CALCULO-GERAL = ( (W-ESC-VAL-PEN-ACUMULADO + W-ESC-VAL-SIN-ACUMULADO) / W-ESC-VAL-PRE-ACUMULADO ) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL.Value = ((AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_SIN_ACUMULADO) / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ESC_VAL_PRE_ACUMULADO) * 100;

                /*" -1392- MOVE W-TOT-CALCULO-GERAL TO LT02-H-F-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_TOT_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_H_F_ACU);

                /*" -1393- ELSE */
            }
            else
            {


                /*" -1395- MOVE ZEROS TO LT02-H-F-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_H_F_ACU);
            }


            /*" -1396- IF W-AC-LINHAS GREATER 58 */

            if (AREA_DE_WORK.W_AC_LINHAS > 58)
            {

                /*" -1397- PERFORM 0000-00-MONTA-CABECALHO. */

                M_0000_00_MONTA_CABECALHO_SECTION();
            }


            /*" -1398- WRITE REG-SI0820B FROM LC09 AFTER 3. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC09.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1399- WRITE REG-SI0820B FROM LT01 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1400- WRITE REG-SI0820B FROM LT02 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1401- WRITE REG-SI0820B FROM LC09 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC09.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1401- ADD 1 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_TOTAL_ESCNEG*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-TOTAL-GERAL-SECTION */
        private void M_0000_00_IMPRIME_TOTAL_GERAL_SECTION()
        {
            /*" -1411- MOVE 'GERAL       ' TO LT02-TIPO-TOTAL . */
            _.Move("GERAL       ", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_TIPO_TOTAL);

            /*" -1412- MOVE W-GER-QTD-PRE-MENSAL TO LT01-QTD-PR-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_PR_MEN);

            /*" -1413- MOVE W-GER-VAL-PRE-MENSAL TO LT01-VAL-PR-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_PR_MEN);

            /*" -1414- MOVE W-GER-QTD-SIN-MENSAL TO LT01-QTD-SI-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_SI_MEN);

            /*" -1415- MOVE W-GER-VAL-SIN-MENSAL TO LT01-VAL-SI-MEN . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_MENSAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_SI_MEN);

            /*" -1416- MOVE W-GER-QTD-PRE-ACUMULADO TO LT01-QTD-PR-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_PR_ACU);

            /*" -1417- MOVE W-GER-VAL-PRE-ACUMULADO TO LT01-VAL-PR-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_PR_ACU);

            /*" -1418- MOVE W-GER-QTD-SIN-ACUMULADO TO LT01-QTD-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_QTD_SI_ACU);

            /*" -1419- MOVE W-GER-VAL-SIN-ACUMULADO TO LT01-VAL-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_VAL_SI_ACU);

            /*" -1420- MOVE W-GER-QTD-PEN-ACUMULADO TO LT02-QTD-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_QTD_SI_ACU);

            /*" -1422- MOVE W-GER-VAL-PEN-ACUMULADO TO LT02-VAL-SI-ACU . */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PEN_ACUMULADO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_VAL_SI_ACU);

            /*" -1423- IF W-GER-QTD-PRE-MENSAL NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_MENSAL != 00)
            {

                /*" -1426- COMPUTE W-GER-CALCULO-GERAL = (W-GER-QTD-SIN-MENSAL / W-GER-QTD-PRE-MENSAL) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_MENSAL / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_MENSAL) * 100;

                /*" -1427- MOVE W-GER-CALCULO-GERAL TO LT01-C-A-MEN */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_C_A_MEN);

                /*" -1428- ELSE */
            }
            else
            {


                /*" -1430- MOVE ZEROS TO LT01-C-A-MEN. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_C_A_MEN);
            }


            /*" -1431- IF W-GER-VAL-PRE-MENSAL NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_MENSAL != 00)
            {

                /*" -1434- COMPUTE W-GER-CALCULO-GERAL = (W-GER-VAL-SIN-MENSAL / W-GER-VAL-PRE-MENSAL) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_MENSAL / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_MENSAL) * 100;

                /*" -1435- MOVE W-GER-CALCULO-GERAL TO LT01-D-B-MEN */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_D_B_MEN);

                /*" -1436- ELSE */
            }
            else
            {


                /*" -1438- MOVE ZEROS TO LT01-D-B-MEN. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_D_B_MEN);
            }


            /*" -1439- IF W-GER-QTD-PRE-ACUMULADO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO != 00)
            {

                /*" -1442- COMPUTE W-GER-CALCULO-GERAL = (W-GER-QTD-SIN-ACUMULADO / W-GER-QTD-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO) * 100;

                /*" -1443- MOVE W-GER-CALCULO-GERAL TO LT01-G-E-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_G_E_ACU);

                /*" -1444- ELSE */
            }
            else
            {


                /*" -1446- MOVE ZEROS TO LT01-G-E-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_G_E_ACU);
            }


            /*" -1447- IF W-GER-VAL-PRE-ACUMULADO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO != 00)
            {

                /*" -1450- COMPUTE W-GER-CALCULO-GERAL = (W-GER-VAL-SIN-ACUMULADO / W-GER-VAL-PRE-ACUMULADO) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL.Value = (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_ACUMULADO / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO) * 100;

                /*" -1451- MOVE W-GER-CALCULO-GERAL TO LT01-H-F-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_H_F_ACU);

                /*" -1452- ELSE */
            }
            else
            {


                /*" -1454- MOVE ZEROS TO LT01-H-F-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.LT01_H_F_ACU);
            }


            /*" -1455- IF W-GER-QTD-PRE-ACUMULADO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO != 00)
            {

                /*" -1459- COMPUTE W-GER-CALCULO-GERAL = ( (W-GER-QTD-PEN-ACUMULADO + W-GER-QTD-SIN-ACUMULADO) / W-GER-QTD-PRE-ACUMULADO ) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL.Value = ((AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_SIN_ACUMULADO) / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_QTD_PRE_ACUMULADO) * 100;

                /*" -1460- MOVE W-GER-CALCULO-GERAL TO LT02-G-E-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_G_E_ACU);

                /*" -1461- ELSE */
            }
            else
            {


                /*" -1463- MOVE ZEROS TO LT02-G-E-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_G_E_ACU);
            }


            /*" -1464- IF W-GER-VAL-PRE-ACUMULADO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO != 00)
            {

                /*" -1468- COMPUTE W-GER-CALCULO-GERAL = ( (W-GER-VAL-PEN-ACUMULADO + W-GER-VAL-SIN-ACUMULADO) / W-GER-VAL-PRE-ACUMULADO ) * 100 */
                AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL.Value = ((AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PEN_ACUMULADO + AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_SIN_ACUMULADO) / AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_VAL_PRE_ACUMULADO) * 100;

                /*" -1469- MOVE W-GER-CALCULO-GERAL TO LT02-H-F-ACU */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.W_GER_CALCULO_GERAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_H_F_ACU);

                /*" -1470- ELSE */
            }
            else
            {


                /*" -1472- MOVE ZEROS TO LT02-H-F-ACU. */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.LT02_H_F_ACU);
            }


            /*" -1473- IF W-AC-LINHAS GREATER 58 */

            if (AREA_DE_WORK.W_AC_LINHAS > 58)
            {

                /*" -1474- PERFORM 0000-00-MONTA-CABECALHO. */

                M_0000_00_MONTA_CABECALHO_SECTION();
            }


            /*" -1475- WRITE REG-SI0820B FROM LC09 AFTER 4. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC09.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1476- WRITE REG-SI0820B FROM LT01 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT01.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1477- WRITE REG-SI0820B FROM LT02 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LT02.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1477- WRITE REG-SI0820B FROM LC09 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC09.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_TOTAL_GERAL*/

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-SECTION */
        private void M_0000_00_PREPARA_CABECALHO_SECTION()
        {
            /*" -1487- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WDATA_CURR);

            /*" -1488- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1489- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1490- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1492- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WDATA_CABEC, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC02.LC02_DATA);

            /*" -1493- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CURR);

            /*" -1494- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -1495- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -1496- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -1498- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WHORA_CABEC, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_HORA);

            /*" -1499- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1503- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_1 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_1();

            /*" -1506- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1507- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                /*" -1509- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1510- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.LK_LINK.LK_TITULO);

            /*" -1512- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.LK_LINK);

            /*" -1513- IF LK-RTCODE EQUAL ZEROS */

            if (AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.LK_LINK.LK_RTCODE == 00)
            {

                /*" -1514- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.LK_LINK.LK_TITULO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC01.LC01_EMPRESA);

                /*" -1515- ELSE */
            }
            else
            {


                /*" -1516- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                /*" -1520- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1521- MOVE V0RELA-PERI-INICIAL TO W-DATA-INI-COMP. */
            _.Move(V0RELA_PERI_INICIAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_INI_COMP);

            /*" -1523- MOVE V0RELA-PERI-FINAL TO W-DATA-FIM-COMP. */
            _.Move(V0RELA_PERI_FINAL, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_FIM_COMP);

            /*" -1524- MOVE W-DATA-INI-COMP-AAAA TO LC03-AA-INI-COMP. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_INI_COMP.W_DATA_INI_COMP_AAAA, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_AA_INI_COMP);

            /*" -1525- MOVE W-DATA-INI-COMP-MM TO LC03-MM-INI-COMP. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_INI_COMP.W_DATA_INI_COMP_MM, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_MM_INI_COMP);

            /*" -1527- MOVE W-DATA-INI-COMP-DD TO LC03-DD-INI-COMP. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_INI_COMP.W_DATA_INI_COMP_DD, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_DD_INI_COMP);

            /*" -1528- MOVE W-DATA-FIM-COMP-AAAA TO LC03-AA-FIM-COMP. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_FIM_COMP.W_DATA_FIM_COMP_AAAA, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_AA_FIM_COMP);

            /*" -1529- MOVE W-DATA-FIM-COMP-MM TO LC03-MM-FIM-COMP. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_FIM_COMP.W_DATA_FIM_COMP_MM, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_MM_FIM_COMP);

            /*" -1529- MOVE W-DATA-FIM-COMP-DD TO LC03-DD-FIM-COMP. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.W_DATA_FIM_COMP.W_DATA_FIM_COMP_DD, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.LC03_DD_FIM_COMP);

        }

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-DB-SELECT-1 */
        public void M_0000_00_PREPARA_CABECALHO_DB_SELECT_1()
        {
            /*" -1503- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1 = new M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1.Execute(m_0000_00_PREPARA_CABECALHO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PREPARA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-MONTA-CABECALHO-SECTION */
        private void M_0000_00_MONTA_CABECALHO_SECTION()
        {
            /*" -1540- ADD 1 TO W-AC-PAGINA. */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -1542- MOVE W-AC-PAGINA TO LC01-PAGINA. */
            _.Move(AREA_DE_WORK.W_AC_PAGINA, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC01.LC01_PAGINA);

            /*" -1543- MOVE W-COD-ESCNEG-ANT TO LC04-COD-ESCNEG. */
            _.Move(AREA_DE_WORK.W_CHAVES_QUEBRA.W_COD_ESCNEG_ANT, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_COD_ESCNEG);

            /*" -1545- MOVE V0ESCNEG-REGIAO-ESCNEG TO LC04-NOME-ESCNEG. */
            _.Move(V0ESCNEG_REGIAO_ESCNEG, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_NOME_ESCNEG);

            /*" -1546- IF W-TIPO-SOLICITACAO EQUAL 'APOLICE' */

            if (AREA_DE_WORK.W_TIPO_SOLICITACAO == "APOLICE")
            {

                /*" -1547- MOVE SPACES TO LC04-FILLER-RAMO */
                _.Move("", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_RAMO);

                /*" -1548- MOVE ZEROS TO LC04-FILLER-NUM-RAMO */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_NUM_RAMO);

                /*" -1549- MOVE SPACES TO LC04-FILLER-NOME-RAMO */
                _.Move("", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_NOME_RAMO);

                /*" -1550- MOVE 'APOLICE' TO LC04-FILLER-APOLICE */
                _.Move("APOLICE", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_APOLICE);

                /*" -1551- MOVE V0RELA-NUM-APOLICE TO LC04-FILLER-NUM-APOLICE */
                _.Move(V0RELA_NUM_APOLICE, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_NUM_APOLICE);

                /*" -1552- ELSE */
            }
            else
            {


                /*" -1553- MOVE 'RAMO' TO LC04-FILLER-RAMO */
                _.Move("RAMO", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_RAMO);

                /*" -1554- MOVE V0RELA-RAMO TO LC04-FILLER-NUM-RAMO */
                _.Move(V0RELA_RAMO, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_NUM_RAMO);

                /*" -1555- MOVE SPACES TO LC04-FILLER-NOME-RAMO */
                _.Move("", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_NOME_RAMO);

                /*" -1556- MOVE '       ' TO LC04-FILLER-APOLICE */
                _.Move("       ", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_APOLICE);

                /*" -1558- MOVE ZEROS TO LC04-FILLER-NUM-APOLICE . */
                _.Move(0, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.LC04_FILLER_NUM_APOLICE);
            }


            /*" -1559- WRITE REG-SI0820B FROM LC01 AFTER NEW-PAGE */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC01.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1560- WRITE REG-SI0820B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC02.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1561- WRITE REG-SI0820B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC03.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1562- WRITE REG-SI0820B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC04.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1563- WRITE REG-SI0820B FROM LC09 AFTER 1 */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC09.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1564- WRITE REG-SI0820B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC05.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1565- WRITE REG-SI0820B FROM LC06 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC06.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1566- WRITE REG-SI0820B FROM LC07 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC07.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1567- WRITE REG-SI0820B FROM LC08 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC08.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1569- WRITE REG-SI0820B FROM LC09 AFTER 1. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC09.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1569- MOVE 10 TO W-AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.W_AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_MONTA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-SECTION */
        private void M_0000_00_ACESSA_V1SISTEMA_SECTION()
        {
            /*" -1578- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1589- PERFORM M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1 */

            M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();

            /*" -1593- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1594- DISPLAY 'PROBLEMAS ACESSO V1SISTEMA  .....' */
                _.Display($"PROBLEMAS ACESSO V1SISTEMA  .....");

                /*" -1594- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1589- EXEC SQL SELECT MONTH(DTMOVABE) , YEAR(DTMOVABE) , DTMOVABE , CURRENT DATE INTO :V1SIST-MES-REFERENCIA , :V1SIST-ANO-REFERENCIA , :V1SIST-DATA-REFERENCIA , :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_MES_REFERENCIA, V1SIST_MES_REFERENCIA);
                _.Move(executed_1.V1SIST_ANO_REFERENCIA, V1SIST_ANO_REFERENCIA);
                _.Move(executed_1.V1SIST_DATA_REFERENCIA, V1SIST_DATA_REFERENCIA);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ACESSA_V1SISTEMA*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V0RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -1602- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1613- PERFORM M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -1615- PERFORM M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -1617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1618- DISPLAY 'PROBLEMAS OPEN V0RELATORIOS....' */
                _.Display($"PROBLEMAS OPEN V0RELATORIOS....");

                /*" -1618- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -1615- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-FETCH-V0RELATORIOS-SECTION */
        private void M_0000_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -1627- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1635- PERFORM M_0000_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -1638- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1639- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1640- DISPLAY '* PARAMETROS INFORMADOS NA V0RELATORIOS *' */
                _.Display($"* PARAMETROS INFORMADOS NA V0RELATORIOS *");

                /*" -1641- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1642- DISPLAY 'RAMO                = ' V0RELA-RAMO */
                _.Display($"RAMO                = {V0RELA_RAMO}");

                /*" -1643- DISPLAY 'NUM. APOLICE        = ' V0RELA-NUM-APOLICE */
                _.Display($"NUM. APOLICE        = {V0RELA_NUM_APOLICE}");

                /*" -1644- DISPLAY 'PERIODO INICIAL     = ' V0RELA-PERI-INICIAL */
                _.Display($"PERIODO INICIAL     = {V0RELA_PERI_INICIAL}");

                /*" -1645- DISPLAY 'PERIODO FINAL       = ' V0RELA-PERI-FINAL */
                _.Display($"PERIODO FINAL       = {V0RELA_PERI_FINAL}");

                /*" -1647- DISPLAY 'USUARIO SOLICITANTE = ' V0RELA-CODUSU. */
                _.Display($"USUARIO SOLICITANTE = {V0RELA_CODUSU}");
            }


            /*" -1648- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1649- MOVE 'SIM' TO WFIM-V0RELATORIOS */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS);

                /*" -1650- ELSE */
            }
            else
            {


                /*" -1651- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1652- DISPLAY 'PROBLEMAS ACESSO V0RELATORIOS....' */
                    _.Display($"PROBLEMAS ACESSO V0RELATORIOS....");

                    /*" -1652- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -1635- EXEC SQL FETCH V0RELATORIOS INTO :V0RELA-RAMO , :V0RELA-NUM-APOLICE , :V0RELA-PERI-INICIAL , :V0RELA-PERI-FINAL , :V0RELA-CODUSU , :V0RELA-APOLIDER , :V0RELA-ENDOSLID END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V0RELA_RAMO, V0RELA_RAMO);
                _.Move(V0RELATORIOS.V0RELA_NUM_APOLICE, V0RELA_NUM_APOLICE);
                _.Move(V0RELATORIOS.V0RELA_PERI_INICIAL, V0RELA_PERI_INICIAL);
                _.Move(V0RELATORIOS.V0RELA_PERI_FINAL, V0RELA_PERI_FINAL);
                _.Move(V0RELATORIOS.V0RELA_CODUSU, V0RELA_CODUSU);
                _.Move(V0RELATORIOS.V0RELA_APOLIDER, V0RELA_APOLIDER);
                _.Move(V0RELATORIOS.V0RELA_ENDOSLID, V0RELA_ENDOSLID);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-DELETE-V0RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1661- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1666- PERFORM M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1670- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1671- DISPLAY 'PROBLEMAS DELETE V0RELATORIOS....' */
                _.Display($"PROBLEMAS DELETE V0RELATORIOS....");

                /*" -1671- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1666- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0820B' AND IDSISTEM = 'SI' END-EXEC. */

            var m_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(m_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DELETE_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-ACESSA-NOME-ESCNEG-SECTION */
        private void M_0000_00_ACESSA_NOME_ESCNEG_SECTION()
        {
            /*" -1688- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1693- PERFORM M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1 */

            M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1();

            /*" -1696- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1698- DISPLAY 'ESC. NEG. NAO ENCONTRADO (E R R O) = ' V0ESCNEG-REGIAO-ESCNEG */
                _.Display($"ESC. NEG. NAO ENCONTRADO (E R R O) = {V0ESCNEG_REGIAO_ESCNEG}");

                /*" -1699- MOVE ALL '*' TO V0ESCNEG-REGIAO-ESCNEG */
                _.MoveAll("*", V0ESCNEG_REGIAO_ESCNEG);

                /*" -1700- ELSE */
            }
            else
            {


                /*" -1701- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1702- DISPLAY 'ESC. NEG. = ' V0ESCNEG-REGIAO-ESCNEG */
                    _.Display($"ESC. NEG. = {V0ESCNEG_REGIAO_ESCNEG}");

                    /*" -1703- DISPLAY 'PROBLEMAS ACESSO V0ESCNEG  .........' */
                    _.Display($"PROBLEMAS ACESSO V0ESCNEG  .........");

                    /*" -1703- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-NOME-ESCNEG-DB-SELECT-1 */
        public void M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1()
        {
            /*" -1693- EXEC SQL SELECT REGIAO_ESCNEG INTO :V0ESCNEG-REGIAO-ESCNEG FROM SEGUROS.ESCRITORIO_NEGOCIO WHERE COD_ESCNEG = :V0AGEN-COD-ESCNEG END-EXEC. */

            var m_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1()
            {
                V0AGEN_COD_ESCNEG = V0AGEN_COD_ESCNEG.ToString(),
            };

            var executed_1 = M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ESCNEG_REGIAO_ESCNEG, V0ESCNEG_REGIAO_ESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ACESSA_NOME_ESCNEG*/

        [StopWatch]
        /*" M-0000-00-PREPARA-DESTINATARIO-SECTION */
        private void M_0000_00_PREPARA_DESTINATARIO_SECTION()
        {
            /*" -1710- MOVE V0RELA-CODUSU TO LC00-CODUSU . */
            _.Move(V0RELA_CODUSU, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC00.LC00_CODUSU);

            /*" -1711- MOVE V0RELA-APOLIDER TO LC00-APOLIDER . */
            _.Move(V0RELA_APOLIDER, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC00.LC00_APOLIDER);

            /*" -1712- MOVE V0RELA-ENDOSLID TO LC00-ENDOSLID . */
            _.Move(V0RELA_ENDOSLID, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC00.LC00_ENDOSLID);

            /*" -1713- WRITE REG-SI0820B FROM LC00-A AFTER 20. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC00_A.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1714- WRITE REG-SI0820B FROM LC00 AFTER 4. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC00.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

            /*" -1714- WRITE REG-SI0820B FROM LC00-A AFTER 4. */
            _.Move(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.LC00_A.GetMoveValues(), REG_SI0820B);

            RSI0820B.Write(REG_SI0820B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PREPARA_DESTINATARIO*/

        [StopWatch]
        /*" M-0000-00-CONTROLE-EXECUCAO-SECTION */
        private void M_0000_00_CONTROLE_EXECUCAO_SECTION()
        {
            /*" -1725- PERFORM M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1 */

            M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1();

            /*" -1726- DISPLAY W-TIMESTAMP. */
            _.Display(W_TIMESTAMP);

        }

        [StopWatch]
        /*" M-0000-00-CONTROLE-EXECUCAO-DB-SELECT-1 */
        public void M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1()
        {
            /*" -1725- EXEC SQL SELECT CURRENT TIMESTAMP INTO :W-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1 = new M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1.Execute(m_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_TIMESTAMP, W_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CONTROLE_EXECUCAO*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1737- DISPLAY ' ' */
                _.Display($" ");

                /*" -1738- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1739- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0820B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0820B  *");

                /*" -1740- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1741- DISPLAY ' ' */
                _.Display($" ");

                /*" -1742- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WNR_EXEC_SQL}");

                /*" -1743- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WSQLCODE);

                /*" -1744- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WSQLCODE1);

                /*" -1745- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND.WSQLCODE2);

                /*" -1746- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WSQLCODE3);

                /*" -1748- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.W_AREAS_CALCULO.W_ACUMULADORES_DETALHE.W_ACUMULADORES_ESCNEG.W_ACUMULADORES_FINAL.ACUMULADORES_AUXILIARES.WABEND);
            }


            /*" -1749- CLOSE RSI0820B. */
            RSI0820B.Close();

            /*" -1749- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1750- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1752- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1752- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}