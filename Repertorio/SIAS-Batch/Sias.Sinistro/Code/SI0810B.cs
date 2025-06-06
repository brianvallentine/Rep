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
using Sias.Sinistro.DB2.SI0810B;

namespace Code
{
    public class SI0810B
    {
        public bool IsCall { get; set; }

        public SI0810B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0810B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JUNHO / 1995                        *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            RELACAO DOS SINISTROS CANCELADOS    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * MESTRE DE SINISTRO                 V0MESTSINI        INPUT     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO BARAN 27/01/97 : NAO LER MAIS V0APOLICE E NAO RODAR  *      */
        /*"      *                            MAIS POR RAMO, APENAS POR APOLICE.  *      */
        /*"      *                            E O ACESSO A SEGURAVG               *      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO RILDO SICO - 26/09/2000 : INCLUSAO DA VIEW DE OPERA- *      */
        /*"      *                            COES - V0SINI_OPER_FUNCAO           *      */
        /*"      *                            PROCURAR RS001                      *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO E   *      */
        /*"      * GE_SIS_OPER_FUNCAO                                             *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0810B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0810B
        {
            get
            {
                _.Move(REG_SI0810B, _RSI0810B); VarBasis.RedefinePassValue(REG_SI0810B, _RSI0810B, REG_SI0810B); return _RSI0810B;
            }
        }
        /*"01                  REG-SI0810B.*/
        public SI0810B_REG_SI0810B REG_SI0810B { get; set; } = new SI0810B_REG_SI0810B();
        public class SI0810B_REG_SI0810B : VarBasis
        {
            /*"      05            LINHA              PIC  X(150).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-CODUNIMO      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis WHOST_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-CODCLIEN      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis WHOST_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040)     VALUE SPACES.*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77         V1RELA-COD-EMPRESA  PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis V1RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1RELA-RAMO         PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-NUM-APOLICE  PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis V1RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1RELA-CODUNIMO     PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-PERI-INI     PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1RELA_PERI_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1RELA-PERI-FIM     PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1RELA_PERI_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1RELA-CODUSU       PIC  X(008)     VALUE SPACES.*/
        public StringBasis V1RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V1RELA-DT-SOLICITA  PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1RELA_DT_SOLICITA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V1MOED-CODUNIMO   PIC S9(004)        VALUE +0 COMP.*/
        public IntBasis V1MOED_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MOED-VLCRUZAD   PIC S9(006)V9(09)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
        /*"77          V0MOED-SIGLUNIM   PIC  X(006)      VALUE SPACES.*/
        public StringBasis V0MOED_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
        /*"77         V1CLIE-NOME        PIC  X(040)      VALUE SPACES.*/
        public StringBasis V1CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77         V1APOL-NUM-APOLICE PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1APOL_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APOL-CODCLIEN    PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-RAMO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0MEST-NUM-APOL-I      PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOL_I { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0MEST-NUM-APOL-F      PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOL_F { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0MEST-RAMO-I          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0MEST-RAMO-F          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0MEST-NUM-APOLICE     PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0MEST-NUM-APOL-SINI   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0MEST-RAMO            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0MEST-NRCERTIF        PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77   V0MEST-SITUACAO        PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0MEST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77   V0MEST-DATCMD          PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   V0MEST-DTULTMOV        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0MEST_DTULTMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77      V0HIST-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      V0HIST-VAL-OPERACAO   PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V0HIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77      V0HIST-SITUACAO       PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77      V0HIST-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77      V0HIST-OPERACAO-2     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OPERACAO_2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      V0HIST-VAL-OPERACAO-2 PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V0HIST_VAL_OPERACAO_2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77      V0HIST-DTMOVTO-2      PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HIST_DTMOVTO_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   V0HIST-NUM-APOL-SINI-3   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HIST_NUM_APOL_SINI_3 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0HIST-OPERACAO-3        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OPERACAO_3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0HIST-VAL-OPERACAO-3    PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V0HIST_VAL_OPERACAO_3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77   V0HIST-DTMOVTO-3         PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HIST_DTMOVTO_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1SEGU-NUM-APOLICE PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1SEGU_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SEGU-CODCLIEN    PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1SEGU_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SEGU-NRCERTIF    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1SEGU_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01           AREA-DE-WORK.*/
        public SI0810B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0810B_AREA_DE_WORK();
        public class SI0810B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  WCH-FINAL         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05  W-ARQUIVO-ABERTO  PIC  X(003)      VALUE SPACES.*/
            public StringBasis W_ARQUIVO_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-JOIN-HIST-MEST  PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_JOIN_HIST_MEST { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-AVISADO         PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_AVISADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-PAGAMENTOS   PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_PAGAMENTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-V1RELATOR    PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05       W-AC-LINHAS         PIC  9(002)      VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05       W-AC-PAGINA         PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         CH-CHAVE-ATU.*/
            public SI0810B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new SI0810B_CH_CHAVE_ATU();
            public class SI0810B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10 W-APOLICE-ANT           PIC S9(013)      VALUE  +0 COMP-3*/
                public IntBasis W_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10 W-SINISTRO-ANT          PIC S9(013)      VALUE  +0 COMP-3*/
                public IntBasis W_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10 W-NOVA-APOLICE          PIC  X(003)      VALUE SPACES.*/
                public StringBasis W_NOVA_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  05  W-AC-AVISADO             PIC S9(013)V9(5) VALUE +0  COMP-3*/
            }
            public DoubleBasis W_AC_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-AC-AJUSTE              PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_AC_AJUSTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-AC-OPERACAO            PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_AC_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TRANSF-VAL-OPERACAO    PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TRANSF_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-AVISADO            PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-OPERACAO           PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-AJUSTE             PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_AJUSTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-AVISADO      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-OPERACAO     PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-AJUSTE       PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL_AJUSTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-COTACAO-HOJE           PIC S9(006)V9(09) VALUE +0 COMP-3*/
            public DoubleBasis W_COTACAO_HOJE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
            /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0810B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0810B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0810B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0810B_FILLER_0 : VarBasis
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
                /*"  05         WHORA-CURR.*/

                public _REDEF_SI0810B_FILLER_0()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0810B_WHORA_CURR WHORA_CURR { get; set; } = new SI0810B_WHORA_CURR();
            public class SI0810B_WHORA_CURR : VarBasis
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
            public SI0810B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0810B_WDATA_CABEC();
            public class SI0810B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public SI0810B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0810B_WHORA_CABEC();
            public class SI0810B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public SI0810B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new SI0810B_WDATA_VIGENCIA();
            public class SI0810B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-DTMOVTO.*/
            }
            public SI0810B_WDATA_DTMOVTO WDATA_DTMOVTO { get; set; } = new SI0810B_WDATA_DTMOVTO();
            public class SI0810B_WDATA_DTMOVTO : VarBasis
            {
                /*"    10       WDATA-MOV-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_MOV_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MOV-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MOV_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MOV-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MOV_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CANCELAMENTO.*/
            }
            public SI0810B_WDATA_CANCELAMENTO WDATA_CANCELAMENTO { get; set; } = new SI0810B_WDATA_CANCELAMENTO();
            public class SI0810B_WDATA_CANCELAMENTO : VarBasis
            {
                /*"    10       WDATA-CAN-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_CAN_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-CAN-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_CAN_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-CAN-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_CAN_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WABEND.*/
            public SI0810B_WABEND WABEND { get; set; } = new SI0810B_WABEND();
            public class SI0810B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0810B'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0810B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05            LC01.*/
            }
            public SI0810B_LC01 LC01 { get; set; } = new SI0810B_LC01();
            public class SI0810B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATOR   PIC  X(010) VALUE 'SI0810B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0810B.1");
                /*"    10          FILLER         PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          LC01-EMPRESA   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER         PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER         PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA    PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public SI0810B_LC02 LC02 { get; set; } = new SI0810B_LC02();
            public class SI0810B_LC02 : VarBasis
            {
                /*"    10 FILLER                  PIC  X(010) VALUE 'SI0810B.1'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0810B.1");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(032) VALUE      'APURACAO DOS EXCEDENTES TECNICOS'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"APURACAO DOS EXCEDENTES TECNICOS");
                /*"    10          FILLER         PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public SI0810B_LC03 LC03 { get; set; } = new SI0810B_LC03();
            public class SI0810B_LC03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(034) VALUE        'SINISTROS CANCELADOS NO PERIODO - '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"SINISTROS CANCELADOS NO PERIODO - ");
                /*"    10          LC03-DIA-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-INI   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10          LC03-DIA-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-TER   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public SI0810B_LC04 LC04 { get; set; } = new SI0810B_LC04();
            public class SI0810B_LC04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(022) VALUE    'USUARIO SOLICITANTE - '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"USUARIO SOLICITANTE - ");
                /*"    10          LC02-CODUSU    PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC02_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(002) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          FILLER         PIC  X(019) VALUE    'DATA SOLICITACAO - '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DATA SOLICITACAO - ");
                /*"    10          LC04-DIA-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_DIA_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-MES-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_MES_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-ANO-SOL   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC04_ANO_SOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"    10          FILLER         PIC  X(021) VALUE                               'FATORES EXPRESSOS EM '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"FATORES EXPRESSOS EM ");
                /*"    10          LC04-MOEDA     PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_MOEDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC05.*/
            }
            public SI0810B_LC05 LC05 { get; set; } = new SI0810B_LC05();
            public class SI0810B_LC05 : VarBasis
            {
                /*"    10          FILLER         PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC06.*/
            }
            public SI0810B_LC06 LC06 { get; set; } = new SI0810B_LC06();
            public class SI0810B_LC06 : VarBasis
            {
                /*"    10          FILLER         PIC  X(013) VALUE 'APOLICE'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(031) VALUE 'SEGURADO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"SEGURADO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(013) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(010) VALUE 'DT AVISO'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT AVISO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(010) VALUE 'DT CANC.'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT CANC.");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(015) VALUE 'VALOR AVISO'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR AVISO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(015) VALUE 'VALOR PAGO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR PAGO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(015) VALUE 'VALOR AJUSTE'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR AJUSTE");
                /*"  05            LD01.*/
            }
            public SI0810B_LD01 LD01 { get; set; } = new SI0810B_LD01();
            public class SI0810B_LD01 : VarBasis
            {
                /*"    10          LD01-APOLICE   PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NOME      PIC  X(031) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NUM-SINI  PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_NUM_SINI { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-DIAAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIAAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MESAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_MESAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANOAV     PIC   9999  BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANOAV { get; set; } = new IntBasis(new PIC("9", "4", "9999"));
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-DIACAN    PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIACAN { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MESCAN    PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_MESCAN { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANOCAN    PIC   9999  BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANOCAN { get; set; } = new IntBasis(new PIC("9", "4", "9999"));
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLAVISO   PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLAVISO { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLPAGO    PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLPAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLAJUSTE  PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLAJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"  05    LD02.*/
            }
            public SI0810B_LD02 LD02 { get; set; } = new SI0810B_LD02();
            public class SI0810B_LD02 : VarBasis
            {
                /*"    10  FILLER             PIC  X(020) VALUE        'TOTAL APOLICE  .....'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL APOLICE  .....");
                /*"    10  FILLER             PIC  X(005) VALUE ';;;;;'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @";;;;;");
                /*"    10  LD02-TOT-AVISADO   PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD02-TOT-OPERACAO  PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD02-TOT-AJUSTE    PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"  05    LD03.*/
            }
            public SI0810B_LD03 LD03 { get; set; } = new SI0810B_LD03();
            public class SI0810B_LD03 : VarBasis
            {
                /*"    10  FILLER             PIC  X(020) VALUE        'TOTAL GERAL    .....'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL GERAL    .....");
                /*"    10  FILLER             PIC  X(005) VALUE ';;;;;'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @";;;;;");
                /*"    10  LD03-TOT-GERAL-AVISADO   PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD03-TOT-GERAL-OPERACAO  PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD03-TOT-GERAL-AJUSTE    PIC  -------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "-------.--9V999"), 3);
                /*"  05            LD04.*/
            }
            public SI0810B_LD04 LD04 { get; set; } = new SI0810B_LD04();
            public class SI0810B_LD04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(003) VALUE '** '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"** ");
                /*"    10  LD04-DEBITAR-CREDITAR  PIC  X(008) VALUE SPACES.*/
                public StringBasis LD04_DEBITAR_CREDITAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(057) VALUE        ' O TOTAL GERAL DO VALOR DE AJUSTE DA APURACAO, PORQUE EH        ' '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @" O TOTAL GERAL DO VALOR DE AJUSTE DA APURACAO, PORQUE EH        ");
                /*"    10  LD04-POSITIVO-NEGATIVO PIC  X(008) VALUE SPACES.*/
                public StringBasis LD04_POSITIVO_NEGATIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(003) VALUE ' **'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" **");
                /*"    10          FILLER         PIC  X(027) VALUE SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"01          LK-LINK.*/
            }
        }
        public SI0810B_LK_LINK LK_LINK { get; set; } = new SI0810B_LK_LINK();
        public class SI0810B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public SI0810B_V1RELATORIOS V1RELATORIOS { get; set; } = new SI0810B_V1RELATORIOS();
        public SI0810B_JOIN_HIST_MEST JOIN_HIST_MEST { get; set; } = new SI0810B_JOIN_HIST_MEST();
        public SI0810B_AVISADO AVISADO { get; set; } = new SI0810B_AVISADO();
        public SI0810B_PARCIAL PARCIAL { get; set; } = new SI0810B_PARCIAL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0810B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0810B.SetFile(RSI0810B_FILE_NAME_P);

                /*" -508- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -509- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -512- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -515- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -515- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -523- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -524- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -525- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -526- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -528- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -529- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -533- OPEN OUTPUT RSI0810B */
            RSI0810B.Open(REG_SI0810B);

            /*" -535- PERFORM 0000-00-DECLARE-V1RELATORIOS. */

            M_0000_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -536- MOVE 'NAO' TO WFIM-V1RELATOR. */
            _.Move("NAO", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -538- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

            /*" -539- IF WFIM-V1RELATOR EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V1RELATOR == "SIM")
            {

                /*" -540- MOVE 'A' TO WCH-FINAL */
                _.Move("A", AREA_DE_WORK.WCH_FINAL);

                /*" -542- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -546- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -548- PERFORM 0000-00-ACESSA-V1SISTEMA */

            M_0000_00_ACESSA_V1SISTEMA_SECTION();

            /*" -549- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -550- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -551- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -552- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -554- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -557- PERFORM 0000-00-PROCESSA-V1RELATORIO UNTIL WFIM-V1RELATOR EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_V1RELATOR == "SIM"))
            {

                M_0000_00_PROCESSA_V1RELATORIO_SECTION();
            }

            /*" -559- PERFORM 0000-00-DELETE-V1RELATORIOS. */

            M_0000_00_DELETE_V1RELATORIOS_SECTION();

            /*" -560- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -560- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -562- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -563- DISPLAY 'ERRO ACESSO COMMIT' */
                _.Display($"ERRO ACESSO COMMIT");

                /*" -565- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -567- MOVE SPACES TO WCH-FINAL. */
            _.Move("", AREA_DE_WORK.WCH_FINAL);

            /*" -567- GO TO 0000-00-ENCERRA. */

            M_0000_00_ENCERRA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_PRINCIPAL*/

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-SECTION */
        private void M_0000_00_ACESSA_V1SISTEMA_SECTION()
        {
            /*" -576- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -581- PERFORM M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1 */

            M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();

            /*" -584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -585- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -586- MOVE 'B' TO WCH-FINAL */
                    _.Move("B", AREA_DE_WORK.WCH_FINAL);

                    /*" -587- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -588- ELSE */
                }
                else
                {


                    /*" -589- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -591- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -592- MOVE V1SIST-DTMOVABE TO WHOST-DTINIVIG. */
            _.Move(V1SIST_DTMOVABE, WHOST_DTINIVIG);

            /*" -594- MOVE 'G' TO WCH-FINAL. */
            _.Move("G", AREA_DE_WORK.WCH_FINAL);

            /*" -596- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -596- MOVE V1MOED-VLCRUZAD TO W-COTACAO-HOJE. */
            _.Move(V1MOED_VLCRUZAD, AREA_DE_WORK.W_COTACAO_HOJE);

        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1()
        {
            /*" -581- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ACESSA_V1SISTEMA*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-V1RELATORIO-SECTION */
        private void M_0000_00_PROCESSA_V1RELATORIO_SECTION()
        {
            /*" -606- MOVE ZEROS TO W-AC-PAGINA. */
            _.Move(0, AREA_DE_WORK.W_AC_PAGINA);

            /*" -615- MOVE 80 TO W-AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.W_AC_LINHAS);

            /*" -617- MOVE ZEROS TO V0MEST-NUM-APOL-I V0MEST-RAMO-I. */
            _.Move(0, V0MEST_NUM_APOL_I, V0MEST_RAMO_I);

            /*" -618- MOVE 9999999999999 TO V0MEST-NUM-APOL-F. */
            _.Move(9999999999999, V0MEST_NUM_APOL_F);

            /*" -620- MOVE 99 TO V0MEST-RAMO-F. */
            _.Move(99, V0MEST_RAMO_F);

            /*" -621- IF V1RELA-RAMO NOT EQUAL ZEROS */

            if (V1RELA_RAMO != 00)
            {

                /*" -623- MOVE V1RELA-RAMO TO V0MEST-RAMO-I V0MEST-RAMO-F */
                _.Move(V1RELA_RAMO, V0MEST_RAMO_I, V0MEST_RAMO_F);

                /*" -624- ELSE */
            }
            else
            {


                /*" -625- IF V1RELA-NUM-APOLICE NOT EQUAL ZEROS */

                if (V1RELA_NUM_APOLICE != 00)
                {

                    /*" -628- MOVE V1RELA-NUM-APOLICE TO V0MEST-NUM-APOL-I V0MEST-NUM-APOL-F. */
                    _.Move(V1RELA_NUM_APOLICE, V0MEST_NUM_APOL_I, V0MEST_NUM_APOL_F);
                }

            }


            /*" -630- PERFORM 0000-00-DECLARE-JOIN-HIST-MEST. */

            M_0000_00_DECLARE_JOIN_HIST_MEST_SECTION();

            /*" -632- MOVE 'NAO' TO WFIM-JOIN-HIST-MEST. */
            _.Move("NAO", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

            /*" -634- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

            /*" -635- IF WFIM-JOIN-HIST-MEST EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM")
            {

                /*" -636- MOVE 'C' TO WCH-FINAL */
                _.Move("C", AREA_DE_WORK.WCH_FINAL);

                /*" -637- PERFORM 0000-00-ENCERRA */

                M_0000_00_ENCERRA_SECTION();

                /*" -639- GO TO 0000-01-LER-NOVO-V1RELATORIO. */

                M_0000_01_LER_NOVO_V1RELATORIO(); //GOTO
                return;
            }


            /*" -641- PERFORM 0000-00-PREPARA-CABECALHO. */

            M_0000_00_PREPARA_CABECALHO_SECTION();

            /*" -643- PERFORM 0000-00-MONTA-CABECALHO */

            M_0000_00_MONTA_CABECALHO_SECTION();

            /*" -649- MOVE ZEROS TO W-TOT-GERAL-AVISADO W-TOT-GERAL-OPERACAO W-TOT-GERAL-AJUSTE W-TOT-AVISADO W-TOT-OPERACAO W-TOT-AJUSTE. */
            _.Move(0, AREA_DE_WORK.W_TOT_GERAL_AVISADO, AREA_DE_WORK.W_TOT_GERAL_OPERACAO, AREA_DE_WORK.W_TOT_GERAL_AJUSTE, AREA_DE_WORK.W_TOT_AVISADO, AREA_DE_WORK.W_TOT_OPERACAO, AREA_DE_WORK.W_TOT_AJUSTE);

            /*" -650- MOVE 'SIM' TO W-NOVA-APOLICE. */
            _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

            /*" -653- PERFORM 0000-00-TRATA-JOIN-HIST-MEST UNTIL WFIM-JOIN-HIST-MEST EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
            {

                M_0000_00_TRATA_JOIN_HIST_MEST_SECTION();
            }

            /*" -653- PERFORM 0000-00-TOTAL-RELATORIO. */

            M_0000_00_TOTAL_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0000_01_LER_NOVO_V1RELATORIO */

            M_0000_01_LER_NOVO_V1RELATORIO();

        }

        [StopWatch]
        /*" M-0000-01-LER-NOVO-V1RELATORIO */
        private void M_0000_01_LER_NOVO_V1RELATORIO(bool isPerform = false)
        {
            /*" -659- PERFORM 0000-00-CLOSE-JOIN-HIST-MEST. */

            M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION();

            /*" -659- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V1RELATORIO*/

        [StopWatch]
        /*" M-0000-00-TRATA-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_TRATA_JOIN_HIST_MEST_SECTION()
        {
            /*" -673- MOVE ZEROS TO W-AC-AVISADO W-AC-OPERACAO W-AC-AJUSTE. */
            _.Move(0, AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.W_AC_OPERACAO, AREA_DE_WORK.W_AC_AJUSTE);

            /*" -674- MOVE 'NAO' TO WFIM-AVISADO. */
            _.Move("NAO", AREA_DE_WORK.WFIM_AVISADO);

            /*" -675- PERFORM 0000-00-DECLARE-AVISADO. */

            M_0000_00_DECLARE_AVISADO_SECTION();

            /*" -676- PERFORM 0000-00-FETCH-AVISADO. */

            M_0000_00_FETCH_AVISADO_SECTION();

            /*" -677- IF WFIM-AVISADO EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_AVISADO == "SIM")
            {

                /*" -678- MOVE '005' TO WNR-EXEC-SQL */
                _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -679- DISPLAY 'ERRO NA PRIMEIRA LEITURA DO AVISADO.....' */
                _.Display($"ERRO NA PRIMEIRA LEITURA DO AVISADO.....");

                /*" -680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -682- PERFORM 0000-00-PROCESSA-VALOR-AVISADO UNTIL (WFIM-AVISADO EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.WFIM_AVISADO == "SIM")))
            {

                M_0000_00_PROCESSA_VALOR_AVISADO_SECTION();
            }

            /*" -686- PERFORM 0000-00-CLOSE-AVISADO. */

            M_0000_00_CLOSE_AVISADO_SECTION();

            /*" -687- MOVE V0MEST-NUM-APOL-SINI TO V0HIST-NUM-APOL-SINI-3. */
            _.Move(V0MEST_NUM_APOL_SINI, V0HIST_NUM_APOL_SINI_3);

            /*" -688- MOVE 'NAO' TO WFIM-PAGAMENTOS. */
            _.Move("NAO", AREA_DE_WORK.WFIM_PAGAMENTOS);

            /*" -689- PERFORM 0000-00-DECLARE-PAGAMENTOS. */

            M_0000_00_DECLARE_PAGAMENTOS_SECTION();

            /*" -690- PERFORM 0000-00-FETCH-PAGAMENTOS. */

            M_0000_00_FETCH_PAGAMENTOS_SECTION();

            /*" -691- IF WFIM-PAGAMENTOS EQUAL 'NAO' */

            if (AREA_DE_WORK.WFIM_PAGAMENTOS == "NAO")
            {

                /*" -693- PERFORM 0000-00-PROCESSA-PAGAMENTOS UNTIL (WFIM-PAGAMENTOS EQUAL 'SIM' ). */

                while (!((AREA_DE_WORK.WFIM_PAGAMENTOS == "SIM")))
                {

                    M_0000_00_PROCESSA_PAGAMENTOS_SECTION();
                }
            }


            /*" -695- PERFORM 0000-00-CLOSE-PAGAMENTOS. */

            M_0000_00_CLOSE_PAGAMENTOS_SECTION();

            /*" -697- PERFORM 0000-00-PREPARA-DETALHE. */

            M_0000_00_PREPARA_DETALHE_SECTION();

            /*" -698- MOVE V0MEST-NUM-APOL-SINI TO W-SINISTRO-ANT. */
            _.Move(V0MEST_NUM_APOL_SINI, AREA_DE_WORK.CH_CHAVE_ATU.W_SINISTRO_ANT);

            /*" -700- MOVE V0MEST-NUM-APOLICE TO W-APOLICE-ANT. */
            _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);

            /*" -702- PERFORM 0000-00-IMPRIME-REGISTRO. */

            M_0000_00_IMPRIME_REGISTRO_SECTION();

            /*" -704- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

            /*" -706- IF (V0MEST-NUM-APOLICE NOT EQUAL W-APOLICE-ANT) OR (WFIM-JOIN-HIST-MEST EQUAL 'SIM' ) */

            if ((V0MEST_NUM_APOLICE != AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT) || (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
            {

                /*" -707- PERFORM 0000-00-TOTAL-APOLICE */

                M_0000_00_TOTAL_APOLICE_SECTION();

                /*" -710- MOVE ZEROS TO W-TOT-AVISADO W-TOT-OPERACAO W-TOT-AJUSTE */
                _.Move(0, AREA_DE_WORK.W_TOT_AVISADO, AREA_DE_WORK.W_TOT_OPERACAO, AREA_DE_WORK.W_TOT_AJUSTE);

                /*" -711- MOVE 'SIM' TO W-NOVA-APOLICE */
                _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

                /*" -711- MOVE V0MEST-NUM-APOLICE TO W-APOLICE-ANT. */
                _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-VALOR-AVISADO-SECTION */
        private void M_0000_00_PROCESSA_VALOR_AVISADO_SECTION()
        {
            /*" -730- PERFORM M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1 */

            M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1();

            /*" -733- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -734- MOVE ZEROS TO GESISFUO-NUM-FATOR */
                _.Move(0, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                /*" -735- ELSE */
            }
            else
            {


                /*" -736- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -737- DISPLAY 'PROBLEMAS SELECT GE_SIS_FUNCAO_OPER' */
                    _.Display($"PROBLEMAS SELECT GE_SIS_FUNCAO_OPER");

                    /*" -739- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -742- COMPUTE V0HIST-VAL-OPERACAO-2 = V0HIST-VAL-OPERACAO-2 * GESISFUO-NUM-FATOR. */
            V0HIST_VAL_OPERACAO_2.Value = V0HIST_VAL_OPERACAO_2 * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR;

            /*" -743- IF V0HIST-OPERACAO-2 EQUAL 101 */

            if (V0HIST_OPERACAO_2 == 101)
            {

                /*" -744- MOVE V0MEST-DATCMD TO WHOST-DTINIVIG */
                _.Move(V0MEST_DATCMD, WHOST_DTINIVIG);

                /*" -745- ELSE */
            }
            else
            {


                /*" -747- MOVE V0HIST-DTMOVTO-2 TO WHOST-DTINIVIG. */
                _.Move(V0HIST_DTMOVTO_2, WHOST_DTINIVIG);
            }


            /*" -748- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -750- MOVE 'H' TO WCH-FINAL. */
            _.Move("H", AREA_DE_WORK.WCH_FINAL);

            /*" -752- PERFORM 0000-00-ACESSA-COTACAO-MOEDA. */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -755- COMPUTE W-TRANSF-VAL-OPERACAO = V0HIST-VAL-OPERACAO-2 / V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_TRANSF_VAL_OPERACAO.Value = V0HIST_VAL_OPERACAO_2 / V1MOED_VLCRUZAD;

            /*" -764- COMPUTE W-AC-AVISADO = W-AC-AVISADO + W-TRANSF-VAL-OPERACAO */
            AREA_DE_WORK.W_AC_AVISADO.Value = AREA_DE_WORK.W_AC_AVISADO + AREA_DE_WORK.W_TRANSF_VAL_OPERACAO;

            /*" -764- PERFORM 0000-00-FETCH-AVISADO. */

            M_0000_00_FETCH_AVISADO_SECTION();

        }

        [StopWatch]
        /*" M-0000-00-PROCESSA-VALOR-AVISADO-DB-SELECT-1 */
        public void M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1()
        {
            /*" -730- EXEC SQL SELECT NUM_FATOR INTO :GESISFUO-NUM-FATOR FROM SEGUROS.GE_SIS_FUNCAO_OPER WHERE IDE_SISTEMA = 'SI' AND COD_FUNCAO = 3 AND IDE_SISTEMA_OPER = IDE_SISTEMA AND COD_OPERACAO = :V0HIST-OPERACAO-2 AND TIPO_ENDOSSO = '9' END-EXEC. */

            var m_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1 = new M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1()
            {
                V0HIST_OPERACAO_2 = V0HIST_OPERACAO_2.ToString(),
            };

            var executed_1 = M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1.Execute(m_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_VALOR_AVISADO*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-PAGAMENTOS-SECTION */
        private void M_0000_00_PROCESSA_PAGAMENTOS_SECTION()
        {
            /*" -772- MOVE V0HIST-DTMOVTO-3 TO WHOST-DTINIVIG */
            _.Move(V0HIST_DTMOVTO_3, WHOST_DTINIVIG);

            /*" -773- MOVE 'J' TO WCH-FINAL */
            _.Move("J", AREA_DE_WORK.WCH_FINAL);

            /*" -774- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -783- COMPUTE W-TRANSF-VAL-OPERACAO = V0HIST-VAL-OPERACAO-3 / V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_TRANSF_VAL_OPERACAO.Value = V0HIST_VAL_OPERACAO_3 / V1MOED_VLCRUZAD;

            /*" -786- COMPUTE W-AC-OPERACAO = W-AC-OPERACAO + W-TRANSF-VAL-OPERACAO. */
            AREA_DE_WORK.W_AC_OPERACAO.Value = AREA_DE_WORK.W_AC_OPERACAO + AREA_DE_WORK.W_TRANSF_VAL_OPERACAO;

            /*" -786- PERFORM 0000-00-FETCH-PAGAMENTOS. */

            M_0000_00_FETCH_PAGAMENTOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_PAGAMENTOS*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-REGISTRO-SECTION */
        private void M_0000_00_IMPRIME_REGISTRO_SECTION()
        {
            /*" -797- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -806- MOVE W-APOLICE-ANT TO LD01-APOLICE */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT, AREA_DE_WORK.LD01.LD01_APOLICE);

            /*" -812- MOVE W-AC-AVISADO TO LD01-VLAVISO */
            _.Move(AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.LD01.LD01_VLAVISO);

            /*" -814- MOVE W-AC-OPERACAO TO LD01-VLPAGO */
            _.Move(AREA_DE_WORK.W_AC_OPERACAO, AREA_DE_WORK.LD01.LD01_VLPAGO);

            /*" -815- IF W-AC-OPERACAO NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AC_OPERACAO != 00)
            {

                /*" -817- COMPUTE W-AC-AJUSTE = W-AC-AVISADO - W-AC-OPERACAO */
                AREA_DE_WORK.W_AC_AJUSTE.Value = AREA_DE_WORK.W_AC_AVISADO - AREA_DE_WORK.W_AC_OPERACAO;

                /*" -818- MOVE W-AC-AJUSTE TO LD01-VLAJUSTE */
                _.Move(AREA_DE_WORK.W_AC_AJUSTE, AREA_DE_WORK.LD01.LD01_VLAJUSTE);

                /*" -820- ADD W-AC-AJUSTE TO W-TOT-AJUSTE W-TOT-GERAL-AJUSTE */
                AREA_DE_WORK.W_TOT_AJUSTE.Value = AREA_DE_WORK.W_TOT_AJUSTE + AREA_DE_WORK.W_AC_AJUSTE;
                AREA_DE_WORK.W_TOT_GERAL_AJUSTE.Value = AREA_DE_WORK.W_TOT_GERAL_AJUSTE + AREA_DE_WORK.W_AC_AJUSTE;

                /*" -821- ELSE */
            }
            else
            {


                /*" -822- MOVE W-AC-AVISADO TO LD01-VLAJUSTE */
                _.Move(AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.LD01.LD01_VLAJUSTE);

                /*" -825- ADD W-AC-AVISADO TO W-TOT-AJUSTE W-TOT-GERAL-AJUSTE. */
                AREA_DE_WORK.W_TOT_AJUSTE.Value = AREA_DE_WORK.W_TOT_AJUSTE + AREA_DE_WORK.W_AC_AVISADO;
                AREA_DE_WORK.W_TOT_GERAL_AJUSTE.Value = AREA_DE_WORK.W_TOT_GERAL_AJUSTE + AREA_DE_WORK.W_AC_AVISADO;
            }


            /*" -827- ADD W-AC-AVISADO TO W-TOT-AVISADO W-TOT-GERAL-AVISADO. */
            AREA_DE_WORK.W_TOT_AVISADO.Value = AREA_DE_WORK.W_TOT_AVISADO + AREA_DE_WORK.W_AC_AVISADO;
            AREA_DE_WORK.W_TOT_GERAL_AVISADO.Value = AREA_DE_WORK.W_TOT_GERAL_AVISADO + AREA_DE_WORK.W_AC_AVISADO;

            /*" -834- ADD W-AC-OPERACAO TO W-TOT-OPERACAO W-TOT-GERAL-OPERACAO. */
            AREA_DE_WORK.W_TOT_OPERACAO.Value = AREA_DE_WORK.W_TOT_OPERACAO + AREA_DE_WORK.W_AC_OPERACAO;
            AREA_DE_WORK.W_TOT_GERAL_OPERACAO.Value = AREA_DE_WORK.W_TOT_GERAL_OPERACAO + AREA_DE_WORK.W_AC_OPERACAO;

            /*" -835- WRITE REG-SI0810B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

            /*" -835- ADD 1 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_REGISTRO*/

        [StopWatch]
        /*" M-0000-00-PREPARA-DETALHE-SECTION */
        private void M_0000_00_PREPARA_DETALHE_SECTION()
        {
            /*" -845- IF V0MEST-RAMO EQUAL 97 OR 93 OR 81 OR 80 OR 81 OR 91 */

            if (V0MEST_RAMO.In("97", "93", "81", "80", "81", "91"))
            {

                /*" -846- MOVE V0MEST-NUM-APOLICE TO V1SEGU-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOLICE, V1SEGU_NUM_APOLICE);

                /*" -847- MOVE V0MEST-NRCERTIF TO V1SEGU-NRCERTIF */
                _.Move(V0MEST_NRCERTIF, V1SEGU_NRCERTIF);

                /*" -848- PERFORM 0000-00-SELECT-V1SEGURAVG */

                M_0000_00_SELECT_V1SEGURAVG_SECTION();

                /*" -849- MOVE V1SEGU-CODCLIEN TO WHOST-CODCLIEN */
                _.Move(V1SEGU_CODCLIEN, WHOST_CODCLIEN);

                /*" -850- ELSE */
            }
            else
            {


                /*" -851- MOVE V0MEST-NUM-APOLICE TO V1APOL-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOLICE, V1APOL_NUM_APOLICE);

                /*" -852- PERFORM 0000-00-SELECT-V1APOLICE */

                M_0000_00_SELECT_V1APOLICE_SECTION();

                /*" -854- MOVE V1APOL-CODCLIEN TO WHOST-CODCLIEN. */
                _.Move(V1APOL_CODCLIEN, WHOST_CODCLIEN);
            }


            /*" -855- IF WHOST-CODCLIEN EQUAL ZEROS */

            if (WHOST_CODCLIEN == 00)
            {

                /*" -856- MOVE '* CLIENTE  N A O  CADASTRADO *' TO LD01-NOME */
                _.Move("* CLIENTE  N A O  CADASTRADO *", AREA_DE_WORK.LD01.LD01_NOME);

                /*" -857- ELSE */
            }
            else
            {


                /*" -858- PERFORM 0000-00-SELECT-V1CLIENTE */

                M_0000_00_SELECT_V1CLIENTE_SECTION();

                /*" -860- MOVE V1CLIE-NOME TO LD01-NOME. */
                _.Move(V1CLIE_NOME, AREA_DE_WORK.LD01.LD01_NOME);
            }


            /*" -861- MOVE V0MEST-NUM-APOL-SINI TO LD01-NUM-SINI. */
            _.Move(V0MEST_NUM_APOL_SINI, AREA_DE_WORK.LD01.LD01_NUM_SINI);

            /*" -862- MOVE V0MEST-DATCMD TO WDATA-VIGENCIA. */
            _.Move(V0MEST_DATCMD, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -863- MOVE WDATA-VIG-DIA TO LD01-DIAAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIAAV);

            /*" -864- MOVE WDATA-VIG-MES TO LD01-MESAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MESAV);

            /*" -865- MOVE WDATA-VIG-ANO TO LD01-ANOAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANOAV);

            /*" -866- MOVE V0MEST-DTULTMOV TO WDATA-CANCELAMENTO. */
            _.Move(V0MEST_DTULTMOV, AREA_DE_WORK.WDATA_CANCELAMENTO);

            /*" -867- MOVE WDATA-CAN-DIA TO LD01-DIACAN. */
            _.Move(AREA_DE_WORK.WDATA_CANCELAMENTO.WDATA_CAN_DIA, AREA_DE_WORK.LD01.LD01_DIACAN);

            /*" -868- MOVE WDATA-CAN-MES TO LD01-MESCAN. */
            _.Move(AREA_DE_WORK.WDATA_CANCELAMENTO.WDATA_CAN_MES, AREA_DE_WORK.LD01.LD01_MESCAN);

            /*" -868- MOVE WDATA-CAN-ANO TO LD01-ANOCAN. */
            _.Move(AREA_DE_WORK.WDATA_CANCELAMENTO.WDATA_CAN_ANO, AREA_DE_WORK.LD01.LD01_ANOCAN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PREPARA_DETALHE*/

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-SECTION */
        private void M_0000_00_PREPARA_CABECALHO_SECTION()
        {
            /*" -879- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -883- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_1 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_1();

            /*" -886- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -887- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -888- MOVE 'D' TO WCH-FINAL */
                    _.Move("D", AREA_DE_WORK.WCH_FINAL);

                    /*" -889- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -890- ELSE */
                }
                else
                {


                    /*" -891- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -893- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -894- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -896- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -897- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -898- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -899- ELSE */
            }
            else
            {


                /*" -900- MOVE 'E' TO WCH-FINAL */
                _.Move("E", AREA_DE_WORK.WCH_FINAL);

                /*" -902- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -904- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -908- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_2 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_2();

            /*" -911- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -913- MOVE 'F' TO WCH-FINAL */
                    _.Move("F", AREA_DE_WORK.WCH_FINAL);

                    /*" -914- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -915- ELSE */
                }
                else
                {


                    /*" -916- DISPLAY 'PROBLEMAS ACESSO V0MOEDA' */
                    _.Display($"PROBLEMAS ACESSO V0MOEDA");

                    /*" -918- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -920- MOVE V1RELA-CODUSU TO LC02-CODUSU. */
            _.Move(V1RELA_CODUSU, AREA_DE_WORK.LC04.LC02_CODUSU);

            /*" -921- MOVE V1RELA-DT-SOLICITA TO WDATA-VIGENCIA */
            _.Move(V1RELA_DT_SOLICITA, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -922- MOVE WDATA-VIG-DIA TO LC04-DIA-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC04.LC04_DIA_SOL);

            /*" -923- MOVE WDATA-VIG-MES TO LC04-MES-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC04.LC04_MES_SOL);

            /*" -925- MOVE WDATA-VIG-ANO TO LC04-ANO-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC04.LC04_ANO_SOL);

            /*" -927- MOVE V0MOED-SIGLUNIM TO LC04-MOEDA. */
            _.Move(V0MOED_SIGLUNIM, AREA_DE_WORK.LC04.LC04_MOEDA);

            /*" -928- MOVE V1RELA-PERI-INI TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_INI, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -929- MOVE WDATA-VIG-DIA TO LC03-DIA-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_INI);

            /*" -930- MOVE WDATA-VIG-MES TO LC03-MES-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_INI);

            /*" -932- MOVE WDATA-VIG-ANO TO LC03-ANO-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_INI);

            /*" -933- MOVE V1RELA-PERI-FIM TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_FIM, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -934- MOVE WDATA-VIG-DIA TO LC03-DIA-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_TER);

            /*" -935- MOVE WDATA-VIG-MES TO LC03-MES-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_TER);

            /*" -935- MOVE WDATA-VIG-ANO TO LC03-ANO-TER. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_TER);

        }

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-DB-SELECT-1 */
        public void M_0000_00_PREPARA_CABECALHO_DB_SELECT_1()
        {
            /*" -883- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
        /*" M-0000-00-PREPARA-CABECALHO-DB-SELECT-2 */
        public void M_0000_00_PREPARA_CABECALHO_DB_SELECT_2()
        {
            /*" -908- EXEC SQL SELECT SIGLUNIM INTO :V0MOED-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO END-EXEC. */

            var m_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1 = new M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1()
            {
                V1RELA_CODUNIMO = V1RELA_CODUNIMO.ToString(),
            };

            var executed_1 = M_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1.Execute(m_0000_00_PREPARA_CABECALHO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOED_SIGLUNIM, V0MOED_SIGLUNIM);
            }


        }

        [StopWatch]
        /*" M-0000-00-MONTA-CABECALHO-SECTION */
        private void M_0000_00_MONTA_CABECALHO_SECTION()
        {
            /*" -946- ADD 1 TO W-AC-PAGINA */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -949- MOVE W-AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.W_AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -950- WRITE REG-SI0810B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

            /*" -951- WRITE REG-SI0810B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

            /*" -953- WRITE REG-SI0810B FROM LC04 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

            /*" -953- WRITE REG-SI0810B FROM LC06. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_MONTA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-SECTION */
        private void M_0000_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -965- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -970- PERFORM M_0000_00_SELECT_V1APOLICE_DB_SELECT_1 */

            M_0000_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -973- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -974- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -975- MOVE ZEROS TO V1APOL-CODCLIEN */
                    _.Move(0, V1APOL_CODCLIEN);

                    /*" -976- ELSE */
                }
                else
                {


                    /*" -977- DISPLAY 'ERRO ACESSO V1APOLICE' */
                    _.Display($"ERRO ACESSO V1APOLICE");

                    /*" -977- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -970- EXEC SQL SELECT CODCLIEN INTO :V1APOL-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1APOL-NUM-APOLICE END-EXEC. */

            var m_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 = new M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1()
            {
                V1APOL_NUM_APOLICE = V1APOL_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_CODCLIEN, V1APOL_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SELECT_V1APOLICE*/

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-SECTION */
        private void M_0000_00_SELECT_V1SEGURAVG_SECTION()
        {
            /*" -988- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -996- PERFORM M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -999- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1000- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1001- MOVE ZEROS TO V1SEGU-CODCLIEN */
                    _.Move(0, V1SEGU_CODCLIEN);

                    /*" -1002- ELSE */
                }
                else
                {


                    /*" -1003- DISPLAY 'ERRO ACESSO V1SUBGRUPO' */
                    _.Display($"ERRO ACESSO V1SUBGRUPO");

                    /*" -1003- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -996- EXEC SQL SELECT COD_CLIENTE INTO :V1SEGU-CODCLIEN FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :V1SEGU-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 = new M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1()
            {
                V1SEGU_NRCERTIF = V1SEGU_NRCERTIF.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGU_CODCLIEN, V1SEGU_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SELECT_V1SEGURAVG*/

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-SECTION */
        private void M_0000_00_SELECT_V1CLIENTE_SECTION()
        {
            /*" -1013- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1018- PERFORM M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -1021- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1022- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1023- MOVE 'SEGURADO NAO CADASTRADO' TO V1CLIE-NOME */
                    _.Move("SEGURADO NAO CADASTRADO", V1CLIE_NOME);

                    /*" -1024- ELSE */
                }
                else
                {


                    /*" -1025- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -1025- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1018- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

            var m_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 = new M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1()
            {
                WHOST_CODCLIEN = WHOST_CODCLIEN.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIE_NOME, V1CLIE_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SELECT_V1CLIENTE*/

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-SECTION */
        private void M_0000_00_ACESSA_COTACAO_MOEDA_SECTION()
        {
            /*" -1035- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1042- PERFORM M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1 */

            M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1();

            /*" -1045- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1046- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1047- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -1048- ELSE */
                }
                else
                {


                    /*" -1049- DISPLAY 'PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -1049- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1()
        {
            /*" -1042- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-CODUNIMO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

            var m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1()
            {
                WHOST_CODUNIMO = WHOST_CODUNIMO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ACESSA_COTACAO_MOEDA*/

        [StopWatch]
        /*" M-0000-00-TOTAL-APOLICE-SECTION */
        private void M_0000_00_TOTAL_APOLICE_SECTION()
        {
            /*" -1058- MOVE W-TOT-AVISADO TO LD02-TOT-AVISADO. */
            _.Move(AREA_DE_WORK.W_TOT_AVISADO, AREA_DE_WORK.LD02.LD02_TOT_AVISADO);

            /*" -1059- MOVE W-TOT-OPERACAO TO LD02-TOT-OPERACAO. */
            _.Move(AREA_DE_WORK.W_TOT_OPERACAO, AREA_DE_WORK.LD02.LD02_TOT_OPERACAO);

            /*" -1063- MOVE W-TOT-AJUSTE TO LD02-TOT-AJUSTE. */
            _.Move(AREA_DE_WORK.W_TOT_AJUSTE, AREA_DE_WORK.LD02.LD02_TOT_AJUSTE);

            /*" -1063- WRITE REG-SI0810B FROM LD02. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_APOLICE*/

        [StopWatch]
        /*" M-0000-00-TOTAL-RELATORIO-SECTION */
        private void M_0000_00_TOTAL_RELATORIO_SECTION()
        {
            /*" -1072- MOVE W-TOT-GERAL-AVISADO TO LD03-TOT-GERAL-AVISADO. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_AVISADO, AREA_DE_WORK.LD03.LD03_TOT_GERAL_AVISADO);

            /*" -1073- MOVE W-TOT-GERAL-OPERACAO TO LD03-TOT-GERAL-OPERACAO. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_OPERACAO, AREA_DE_WORK.LD03.LD03_TOT_GERAL_OPERACAO);

            /*" -1078- MOVE W-TOT-GERAL-AJUSTE TO LD03-TOT-GERAL-AJUSTE. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_AJUSTE, AREA_DE_WORK.LD03.LD03_TOT_GERAL_AJUSTE);

            /*" -1080- WRITE REG-SI0810B FROM LD03. */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

            /*" -1081- IF W-TOT-GERAL-AJUSTE GREATER ZERO */

            if (AREA_DE_WORK.W_TOT_GERAL_AJUSTE > 00)
            {

                /*" -1082- MOVE 'CREDITAR' TO LD04-DEBITAR-CREDITAR */
                _.Move("CREDITAR", AREA_DE_WORK.LD04.LD04_DEBITAR_CREDITAR);

                /*" -1083- MOVE 'POSITIVO' TO LD04-POSITIVO-NEGATIVO */
                _.Move("POSITIVO", AREA_DE_WORK.LD04.LD04_POSITIVO_NEGATIVO);

                /*" -1084- ELSE */
            }
            else
            {


                /*" -1085- MOVE 'DEBITAR' TO LD04-DEBITAR-CREDITAR */
                _.Move("DEBITAR", AREA_DE_WORK.LD04.LD04_DEBITAR_CREDITAR);

                /*" -1087- MOVE 'NEGATIVO' TO LD04-POSITIVO-NEGATIVO. */
                _.Move("NEGATIVO", AREA_DE_WORK.LD04.LD04_POSITIVO_NEGATIVO);
            }


            /*" -1087- WRITE REG-SI0810B FROM LD04. */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_SI0810B);

            RSI0810B.Write(REG_SI0810B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_RELATORIO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -1098- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1110- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -1112- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -1115- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1116- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -1116- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -1110- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT RAMO , NUM_APOLICE , CODUNIMO , PERI_INICIAL , PERI_FINAL , CODUSU , DATA_SOLICITACAO FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0810B' ORDER BY CODUSU, DATA_SOLICITACAO, PERI_INICIAL, RAMO,NUM_APOLICE END-EXEC. */
            V1RELATORIOS = new SI0810B_V1RELATORIOS(false);
            string GetQuery_V1RELATORIOS()
            {
                var query = @$"SELECT RAMO
							, 
							NUM_APOLICE
							, 
							CODUNIMO
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							CODUSU
							, 
							DATA_SOLICITACAO 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'SI0810B' 
							ORDER BY CODUSU
							, DATA_SOLICITACAO
							, 
							PERI_INICIAL
							, RAMO
							,NUM_APOLICE";

                return query;
            }
            V1RELATORIOS.GetQueryEvent += GetQuery_V1RELATORIOS;

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-OPEN-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -1112- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1()
        {
            /*" -1193- EXEC SQL DECLARE JOIN-HIST-MEST CURSOR FOR SELECT NUM_APOLICE , NUM_APOL_SINISTRO , RAMO , NRCERTIF , SITUACAO , DATCMD , DTULTMOV FROM SEGUROS.V0MESTSINI WHERE DTULTMOV BETWEEN :V1RELA-PERI-INI AND :V1RELA-PERI-FIM AND DATCMD < :V1RELA-PERI-INI AND SITUACAO = '2' AND NUM_APOLICE BETWEEN :V0MEST-NUM-APOL-I AND :V0MEST-NUM-APOL-F ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            JOIN_HIST_MEST = new SI0810B_JOIN_HIST_MEST(true);
            string GetQuery_JOIN_HIST_MEST()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NUM_APOL_SINISTRO
							, 
							RAMO
							, 
							NRCERTIF
							, 
							SITUACAO
							, 
							DATCMD
							, 
							DTULTMOV 
							FROM SEGUROS.V0MESTSINI 
							WHERE DTULTMOV BETWEEN '{V1RELA_PERI_INI}' 
							AND 
							'{V1RELA_PERI_FIM}' 
							AND DATCMD < '{V1RELA_PERI_INI}' 
							AND SITUACAO = '2' 
							AND NUM_APOLICE BETWEEN '{V0MEST_NUM_APOL_I}' 
							AND 
							'{V0MEST_NUM_APOL_F}' 
							ORDER BY 
							NUM_APOL_SINISTRO";

                return query;
            }
            JOIN_HIST_MEST.GetQueryEvent += GetQuery_JOIN_HIST_MEST;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_V1RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-SECTION */
        private void M_0000_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -1128- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1136- PERFORM M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -1139- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1140- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1141- MOVE 'SIM' TO WFIM-V1RELATOR */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -1142- ELSE */
                }
                else
                {


                    /*" -1143- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -1145- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1146- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -1147- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1148- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1149- DISPLAY '*      ==>     SI0810B      <==         *' */
                _.Display($"*      ==>     SI0810B      <==         *");

                /*" -1150- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1151- DISPLAY '*  DISPLAY DOS DADOS INFORMADOS PELO    *' */
                _.Display($"*  DOS DADOS INFORMADOS PELO    *");

                /*" -1152- DISPLAY '*  USUARIO NA V1RELATORIOS              *' */
                _.Display($"*  USUARIO NA V1RELATORIOS              *");

                /*" -1153- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1154- DISPLAY '* COD-EMPRESA ...... ' V1RELA-COD-EMPRESA */
                _.Display($"* COD-EMPRESA ...... {V1RELA_COD_EMPRESA}");

                /*" -1155- DISPLAY '* RAMO        ...... ' V1RELA-RAMO */
                _.Display($"* RAMO        ...... {V1RELA_RAMO}");

                /*" -1156- DISPLAY '* NUM. APOL.  ...... ' V1RELA-NUM-APOLICE */
                _.Display($"* NUM. APOL.  ...... {V1RELA_NUM_APOLICE}");

                /*" -1157- DISPLAY '* CODUNIMO    ...... ' V1RELA-CODUNIMO */
                _.Display($"* CODUNIMO    ...... {V1RELA_CODUNIMO}");

                /*" -1158- DISPLAY '* PERI. INIC. ...... ' V1RELA-PERI-INI */
                _.Display($"* PERI. INIC. ...... {V1RELA_PERI_INI}");

                /*" -1159- DISPLAY '* PERI. FIM   ...... ' V1RELA-PERI-FIM */
                _.Display($"* PERI. FIM   ...... {V1RELA_PERI_FIM}");

                /*" -1160- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1160- DISPLAY '*****************************************' . */
                _.Display($"*****************************************");
            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -1136- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-RAMO , :V1RELA-NUM-APOLICE , :V1RELA-CODUNIMO , :V1RELA-PERI-INI , :V1RELA-PERI-FIM , :V1RELA-CODUSU , :V1RELA-DT-SOLICITA END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_RAMO, V1RELA_RAMO);
                _.Move(V1RELATORIOS.V1RELA_NUM_APOLICE, V1RELA_NUM_APOLICE);
                _.Move(V1RELATORIOS.V1RELA_CODUNIMO, V1RELA_CODUNIMO);
                _.Move(V1RELATORIOS.V1RELA_PERI_INI, V1RELA_PERI_INI);
                _.Move(V1RELATORIOS.V1RELA_PERI_FIM, V1RELA_PERI_FIM);
                _.Move(V1RELATORIOS.V1RELA_CODUSU, V1RELA_CODUSU);
                _.Move(V1RELATORIOS.V1RELA_DT_SOLICITA, V1RELA_DT_SOLICITA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_V1RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_DECLARE_JOIN_HIST_MEST_SECTION()
        {
            /*" -1171- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1193- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1();

            /*" -1195- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1();

            /*" -1198- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1199- DISPLAY 'PROBLEMAS OPEN JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS OPEN JOIN-HIST-MEST.. ");

                /*" -1199- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-OPEN-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1()
        {
            /*" -1195- EXEC SQL OPEN JOIN-HIST-MEST END-EXEC. */

            JOIN_HIST_MEST.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-AVISADO-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_AVISADO_DB_DECLARE_1()
        {
            /*" -1271- EXEC SQL DECLARE AVISADO CURSOR FOR SELECT H.OPERACAO, H.VAL_OPERACAO, H.DTMOVTO FROM SEGUROS.V0HISTSINI H, SEGUROS.GE_OPERACAO F WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINI AND H.SITUACAO <> '2' AND F.IDE_SISTEMA = 'SI' AND H.OPERACAO = F.COD_OPERACAO AND F.IND_TIPO_FUNCAO = 'AV' END-EXEC. */
            AVISADO = new SI0810B_AVISADO(true);
            string GetQuery_AVISADO()
            {
                var query = @$"SELECT H.OPERACAO
							, 
							H.VAL_OPERACAO
							, 
							H.DTMOVTO 
							FROM SEGUROS.V0HISTSINI H
							, 
							SEGUROS.GE_OPERACAO F 
							WHERE H.NUM_APOL_SINISTRO = '{V0MEST_NUM_APOL_SINI}' 
							AND H.SITUACAO <> '2' 
							AND F.IDE_SISTEMA = 'SI' 
							AND H.OPERACAO = F.COD_OPERACAO 
							AND F.IND_TIPO_FUNCAO = 'AV'";

                return query;
            }
            AVISADO.GetQueryEvent += GetQuery_AVISADO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_FETCH_JOIN_HIST_MEST_SECTION()
        {
            /*" -1208- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1218- PERFORM M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1 */

            M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1();

            /*" -1232- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1233- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1234- MOVE 'SIM' TO WFIM-JOIN-HIST-MEST */
                    _.Move("SIM", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

                    /*" -1235- ELSE */
                }
                else
                {


                    /*" -1236- DISPLAY 'PROBLEMAS NO FETCH DA JOIN-HIST-MEST' */
                    _.Display($"PROBLEMAS NO FETCH DA JOIN-HIST-MEST");

                    /*" -1236- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-DB-FETCH-1 */
        public void M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1()
        {
            /*" -1218- EXEC SQL FETCH JOIN-HIST-MEST INTO :V0MEST-NUM-APOLICE , :V0MEST-NUM-APOL-SINI , :V0MEST-RAMO , :V0MEST-NRCERTIF , :V0MEST-SITUACAO , :V0MEST-DATCMD , :V0MEST-DTULTMOV , :V0APOL-RAMO END-EXEC. */

            if (JOIN_HIST_MEST.Fetch())
            {
                _.Move(JOIN_HIST_MEST.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(JOIN_HIST_MEST.V0MEST_NUM_APOL_SINI, V0MEST_NUM_APOL_SINI);
                _.Move(JOIN_HIST_MEST.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(JOIN_HIST_MEST.V0MEST_NRCERTIF, V0MEST_NRCERTIF);
                _.Move(JOIN_HIST_MEST.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(JOIN_HIST_MEST.V0MEST_DATCMD, V0MEST_DATCMD);
                _.Move(JOIN_HIST_MEST.V0MEST_DTULTMOV, V0MEST_DTULTMOV);
                _.Move(JOIN_HIST_MEST.V0APOL_RAMO, V0APOL_RAMO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION()
        {
            /*" -1246- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1246- PERFORM M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1 */

            M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1();

            /*" -1249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1250- DISPLAY 'PROBLEMAS CLOSE JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS CLOSE JOIN-HIST-MEST.. ");

                /*" -1250- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1()
        {
            /*" -1246- EXEC SQL CLOSE JOIN-HIST-MEST END-EXEC. */

            JOIN_HIST_MEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-DECLARE-AVISADO-SECTION */
        private void M_0000_00_DECLARE_AVISADO_SECTION()
        {
            /*" -1260- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1271- PERFORM M_0000_00_DECLARE_AVISADO_DB_DECLARE_1 */

            M_0000_00_DECLARE_AVISADO_DB_DECLARE_1();

            /*" -1273- PERFORM M_0000_00_DECLARE_AVISADO_DB_OPEN_1 */

            M_0000_00_DECLARE_AVISADO_DB_OPEN_1();

            /*" -1276- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1277- DISPLAY 'PROBLEMAS OPEN AVISADO  ....... ' */
                _.Display($"PROBLEMAS OPEN AVISADO  ....... ");

                /*" -1277- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-AVISADO-DB-OPEN-1 */
        public void M_0000_00_DECLARE_AVISADO_DB_OPEN_1()
        {
            /*" -1273- EXEC SQL OPEN AVISADO END-EXEC. */

            AVISADO.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -1336- EXEC SQL DECLARE PARCIAL CURSOR FOR SELECT (H.VAL_OPERACAO * F.NUM_FATOR), H.DTMOVTO , H.OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.GE_SIS_FUNCAO_OPER F WHERE F.IDE_SISTEMA = 'SI' AND F.COD_FUNCAO = 2 AND F.IDE_SISTEMA_OPER = F.IDE_SISTEMA AND F.COD_OPERACAO = H.OPERACAO AND H.NUM_APOL_SINISTRO = :V0HIST-NUM-APOL-SINI-3 END-EXEC. */
            PARCIAL = new SI0810B_PARCIAL(true);
            string GetQuery_PARCIAL()
            {
                var query = @$"SELECT (H.VAL_OPERACAO * F.NUM_FATOR)
							, 
							H.DTMOVTO
							, 
							H.OPERACAO 
							FROM SEGUROS.V0HISTSINI H
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER F 
							WHERE F.IDE_SISTEMA = 'SI' 
							AND F.COD_FUNCAO = 2 
							AND F.IDE_SISTEMA_OPER = F.IDE_SISTEMA 
							AND F.COD_OPERACAO = H.OPERACAO 
							AND H.NUM_APOL_SINISTRO = '{V0HIST_NUM_APOL_SINI_3}'";

                return query;
            }
            PARCIAL.GetQueryEvent += GetQuery_PARCIAL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_AVISADO*/

        [StopWatch]
        /*" M-0000-00-FETCH-AVISADO-SECTION */
        private void M_0000_00_FETCH_AVISADO_SECTION()
        {
            /*" -1286- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1291- PERFORM M_0000_00_FETCH_AVISADO_DB_FETCH_1 */

            M_0000_00_FETCH_AVISADO_DB_FETCH_1();

            /*" -1294- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1295- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1296- MOVE 'SIM' TO WFIM-AVISADO */
                    _.Move("SIM", AREA_DE_WORK.WFIM_AVISADO);

                    /*" -1297- ELSE */
                }
                else
                {


                    /*" -1298- DISPLAY 'PROBLEMAS NO FETCH DO AVISADO ......' */
                    _.Display($"PROBLEMAS NO FETCH DO AVISADO ......");

                    /*" -1298- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-AVISADO-DB-FETCH-1 */
        public void M_0000_00_FETCH_AVISADO_DB_FETCH_1()
        {
            /*" -1291- EXEC SQL FETCH AVISADO INTO :V0HIST-OPERACAO-2 , :V0HIST-VAL-OPERACAO-2 , :V0HIST-DTMOVTO-2 END-EXEC. */

            if (AVISADO.Fetch())
            {
                _.Move(AVISADO.V0HIST_OPERACAO_2, V0HIST_OPERACAO_2);
                _.Move(AVISADO.V0HIST_VAL_OPERACAO_2, V0HIST_VAL_OPERACAO_2);
                _.Move(AVISADO.V0HIST_DTMOVTO_2, V0HIST_DTMOVTO_2);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_AVISADO*/

        [StopWatch]
        /*" M-0000-00-CLOSE-AVISADO-SECTION */
        private void M_0000_00_CLOSE_AVISADO_SECTION()
        {
            /*" -1308- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1308- PERFORM M_0000_00_CLOSE_AVISADO_DB_CLOSE_1 */

            M_0000_00_CLOSE_AVISADO_DB_CLOSE_1();

            /*" -1311- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1312- DISPLAY 'PROBLEMAS CLOSE AVISADO  ....... ' */
                _.Display($"PROBLEMAS CLOSE AVISADO  ....... ");

                /*" -1312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-AVISADO-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_AVISADO_DB_CLOSE_1()
        {
            /*" -1308- EXEC SQL CLOSE AVISADO END-EXEC. */

            AVISADO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_AVISADO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGAMENTOS-SECTION */
        private void M_0000_00_DECLARE_PAGAMENTOS_SECTION()
        {
            /*" -1323- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1336- PERFORM M_0000_00_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -1338- PERFORM M_0000_00_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            M_0000_00_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -1341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1342- DISPLAY 'PROBLEMAS OPEN PARCIAL  ....... ' */
                _.Display($"PROBLEMAS OPEN PARCIAL  ....... ");

                /*" -1342- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void M_0000_00_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -1338- EXEC SQL OPEN PARCIAL END-EXEC. */

            PARCIAL.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_PAGAMENTOS*/

        [StopWatch]
        /*" M-0000-00-FETCH-PAGAMENTOS-SECTION */
        private void M_0000_00_FETCH_PAGAMENTOS_SECTION()
        {
            /*" -1351- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1356- PERFORM M_0000_00_FETCH_PAGAMENTOS_DB_FETCH_1 */

            M_0000_00_FETCH_PAGAMENTOS_DB_FETCH_1();

            /*" -1359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1360- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1361- MOVE 'SIM' TO WFIM-PAGAMENTOS */
                    _.Move("SIM", AREA_DE_WORK.WFIM_PAGAMENTOS);

                    /*" -1362- ELSE */
                }
                else
                {


                    /*" -1363- DISPLAY 'PROBLEMAS NO FETCH DO PARCIAL ......' */
                    _.Display($"PROBLEMAS NO FETCH DO PARCIAL ......");

                    /*" -1363- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-PAGAMENTOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_PAGAMENTOS_DB_FETCH_1()
        {
            /*" -1356- EXEC SQL FETCH PARCIAL INTO :V0HIST-VAL-OPERACAO-3 , :V0HIST-DTMOVTO-3 , :V0HIST-operacao-3 END-EXEC. */

            if (PARCIAL.Fetch())
            {
                _.Move(PARCIAL.V0HIST_VAL_OPERACAO_3, V0HIST_VAL_OPERACAO_3);
                _.Move(PARCIAL.V0HIST_DTMOVTO_3, V0HIST_DTMOVTO_3);
                _.Move(PARCIAL.V0HIST_operacao_3, V0HIST_OPERACAO_3);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_PAGAMENTOS*/

        [StopWatch]
        /*" M-0000-00-CLOSE-PAGAMENTOS-SECTION */
        private void M_0000_00_CLOSE_PAGAMENTOS_SECTION()
        {
            /*" -1373- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1373- PERFORM M_0000_00_CLOSE_PAGAMENTOS_DB_CLOSE_1 */

            M_0000_00_CLOSE_PAGAMENTOS_DB_CLOSE_1();

            /*" -1376- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1377- DISPLAY 'PROBLEMAS CLOSE PARCIAL  ....... ' */
                _.Display($"PROBLEMAS CLOSE PARCIAL  ....... ");

                /*" -1377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-PAGAMENTOS-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_PAGAMENTOS_DB_CLOSE_1()
        {
            /*" -1373- EXEC SQL CLOSE PARCIAL END-EXEC. */

            PARCIAL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_PAGAMENTOS*/

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V1RELATORIOS_SECTION()
        {
            /*" -1388- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1390- PERFORM M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1394- DISPLAY 'PROBLEMA DELETE V1RELATORIOS' */
                _.Display($"PROBLEMA DELETE V1RELATORIOS");

                /*" -1394- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -1390- EXEC SQL DELETE FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0810B' END-EXEC. */

            var m_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1 = new M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1.Execute(m_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DELETE_V1RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-ENCERRA-SECTION */
        private void M_0000_00_ENCERRA_SECTION()
        {
            /*" -1406- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1407- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -1408- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1409- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1410- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1411- DISPLAY '//     ==>     SI0810B      <==        //' */
                _.Display($"//     ==>     SI0810B      <==        //");

                /*" -1412- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1413- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -1414- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1415- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1416- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1417- ELSE */
            }
            else
            {


                /*" -1418- IF WCH-FINAL EQUAL 'A' */

                if (AREA_DE_WORK.WCH_FINAL == "A")
                {

                    /*" -1419- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1420- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1421- DISPLAY '*      ==>     SI0810B      <==         *' */
                    _.Display($"*      ==>     SI0810B      <==         *");

                    /*" -1422- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1423- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                    _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                    /*" -1424- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1425- DISPLAY '*  NAO HOUVE SOLICITACAO PELO USUARIO,  *' */
                    _.Display($"*  NAO HOUVE SOLICITACAO PELO USUARIO,  *");

                    /*" -1426- DISPLAY '*  PARA EXECUCAO DO PROGRAMA SI0810B.   *' */
                    _.Display($"*  PARA EXECUCAO DO PROGRAMA SI0810B.   *");

                    /*" -1427- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1428- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1429- ELSE */
                }
                else
                {


                    /*" -1430- IF WCH-FINAL EQUAL 'B' */

                    if (AREA_DE_WORK.WCH_FINAL == "B")
                    {

                        /*" -1431- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1432- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1433- DISPLAY '*      ==>     SI0810B      <==         *' */
                        _.Display($"*      ==>     SI0810B      <==         *");

                        /*" -1434- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1435- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                        /*" -1436- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1437- DISPLAY '*  DATA DO SISTEMA NAO FOI ENCONTRADO   *' */
                        _.Display($"*  DATA DO SISTEMA NAO FOI ENCONTRADO   *");

                        /*" -1438- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1439- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1440- ELSE */
                    }
                    else
                    {


                        /*" -1441- IF WCH-FINAL EQUAL 'C' */

                        if (AREA_DE_WORK.WCH_FINAL == "C")
                        {

                            /*" -1442- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1443- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1444- DISPLAY '*      ==>     SI0810B      <==         *' */
                            _.Display($"*      ==>     SI0810B      <==         *");

                            /*" -1445- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1446- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                            _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                            /*" -1447- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1448- DISPLAY '*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*' */
                            _.Display($"*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*");

                            /*" -1449- DISPLAY '*  PARA OS PARAMETROS INFORMADOS.       *' */
                            _.Display($"*  PARA OS PARAMETROS INFORMADOS.       *");

                            /*" -1450- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1451- DISPLAY '*  RAMO   ............ ' V1RELA-RAMO */
                            _.Display($"*  RAMO   ............ {V1RELA_RAMO}");

                            /*" -1452- DISPLAY '*  APOLICE ........... ' V1RELA-NUM-APOLICE */
                            _.Display($"*  APOLICE ........... {V1RELA_NUM_APOLICE}");

                            /*" -1453- DISPLAY '*  PERIODO INCIAL .... ' V1RELA-PERI-INI */
                            _.Display($"*  PERIODO INCIAL .... {V1RELA_PERI_INI}");

                            /*" -1454- DISPLAY '*  PERIODO FINAL  .... ' V1RELA-PERI-FIM */
                            _.Display($"*  PERIODO FINAL  .... {V1RELA_PERI_FIM}");

                            /*" -1455- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1456- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1457- ELSE */
                        }
                        else
                        {


                            /*" -1458- IF WCH-FINAL EQUAL 'D' */

                            if (AREA_DE_WORK.WCH_FINAL == "D")
                            {

                                /*" -1459- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1460- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1461- DISPLAY '*      ==>     SI0810B      <==         *' */
                                _.Display($"*      ==>     SI0810B      <==         *");

                                /*" -1462- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1463- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                /*" -1464- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1465- DISPLAY '*       EMPRESA NAO CADASTRADA          *' */
                                _.Display($"*       EMPRESA NAO CADASTRADA          *");

                                /*" -1466- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1467- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1468- ELSE */
                            }
                            else
                            {


                                /*" -1469- IF WCH-FINAL EQUAL 'E' */

                                if (AREA_DE_WORK.WCH_FINAL == "E")
                                {

                                    /*" -1470- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1471- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1472- DISPLAY '*      ==>     SI0810B      <==         *' */
                                    _.Display($"*      ==>     SI0810B      <==         *");

                                    /*" -1473- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1474- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                    _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                    /*" -1475- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1476- DISPLAY '*  PROBLEMA NO LINK PARA A SUBROTINA    *' */
                                    _.Display($"*  PROBLEMA NO LINK PARA A SUBROTINA    *");

                                    /*" -1477- DISPLAY '*  PROALN01 PARA ACESSO AO NOME EMPRESA *' */
                                    _.Display($"*  PROALN01 PARA ACESSO AO NOME EMPRESA *");

                                    /*" -1478- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1479- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1480- ELSE */
                                }
                                else
                                {


                                    /*" -1481- IF WCH-FINAL EQUAL 'F' */

                                    if (AREA_DE_WORK.WCH_FINAL == "F")
                                    {

                                        /*" -1482- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1483- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1484- DISPLAY '*      ==>     SI0810B      <==         *' */
                                        _.Display($"*      ==>     SI0810B      <==         *");

                                        /*" -1485- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1486- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                        /*" -1487- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1488- DISPLAY '*  MOEDA SOLICITADA NAO CADASTRADA      *' */
                                        _.Display($"*  MOEDA SOLICITADA NAO CADASTRADA      *");

                                        /*" -1489- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1490- DISPLAY '* CODIGO DA MOEDA ....... ' V1RELA-CODUNIMO */
                                        _.Display($"* CODIGO DA MOEDA ....... {V1RELA_CODUNIMO}");

                                        /*" -1491- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1492- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1493- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1495- IF WCH-FINAL EQUAL 'I' OR 'G' OR 'H' OR 'J' */

                                        if (AREA_DE_WORK.WCH_FINAL.In("I", "G", "H", "J"))
                                        {

                                            /*" -1496- DISPLAY '*****************************************' */
                                            _.Display($"*****************************************");

                                            /*" -1497- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1498- DISPLAY '*      ==>     SI0810B      <==         *' */
                                            _.Display($"*      ==>     SI0810B      <==         *");

                                            /*" -1499- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1500- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                            _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                            /*" -1501- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1502- DISPLAY '*  COTACAO PARA A DATA DO SISTEMA       *' */
                                            _.Display($"*  COTACAO PARA A DATA DO SISTEMA       *");

                                            /*" -1503- DISPLAY '*  NAO CADASTRADA                       *' */
                                            _.Display($"*  NAO CADASTRADA                       *");

                                            /*" -1504- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1505- DISPLAY '* CODIGO DA MOEDA ....... ' WHOST-CODUNIMO */
                                            _.Display($"* CODIGO DA MOEDA ....... {WHOST_CODUNIMO}");

                                            /*" -1506- DISPLAY '* DATA DA MOEDA   ....... ' WHOST-DTINIVIG */
                                            _.Display($"* DATA DA MOEDA   ....... {WHOST_DTINIVIG}");

                                            /*" -1507- DISPLAY '* WCH-FINAL       ....... ' WCH-FINAL */
                                            _.Display($"* WCH-FINAL       ....... {AREA_DE_WORK.WCH_FINAL}");

                                            /*" -1508- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1510- DISPLAY '*****************************************' . */
                                            _.Display($"*****************************************");
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1511- IF WCH-FINAL NOT EQUAL 'C' */

            if (AREA_DE_WORK.WCH_FINAL != "C")
            {

                /*" -1512- CLOSE RSI0810B */
                RSI0810B.Close();

                /*" -1513- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1513- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ENCERRA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1525- DISPLAY ' ' */
                _.Display($" ");

                /*" -1526- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1527- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0810B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0810B  *");

                /*" -1528- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1529- DISPLAY ' ' */
                _.Display($" ");

                /*" -1530- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -1531- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1532- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLCODE1);

                /*" -1533- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLCODE2);

                /*" -1534- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE3);

                /*" -1536- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.WABEND);
            }


            /*" -1537- IF W-ARQUIVO-ABERTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_ARQUIVO_ABERTO == "SIM")
            {

                /*" -1538- CLOSE RSI0810B. */
                RSI0810B.Close();
            }


            /*" -1538- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1539- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1541- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1541- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}