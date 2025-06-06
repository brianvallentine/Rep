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
using Sias.Sinistro.DB2.SI0808B;

namespace Code
{
    public class SI0808B
    {
        public bool IsCall { get; set; }

        public SI0808B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0808B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JUNHO / 1995                        *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            RELACAO DOS SINISTROS PAGOS         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * MESTRE DE SINISTRO                 V0MESTSINI        INPUT     *      */
        /*"      * HISTORICO DO SINISTRO              V0HISTSINI        INPUT     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO BARAN 27/01/97 : NAO LER MAIS V0APOLICE E NAO RODAR  *      */
        /*"      *                            MAIS POR RAMO, APENAS POR APOLICE.  *      */
        /*"      *                                                                *      */
        /*"      *                            ALTERADO O ACESSO A SEGURAVG        *      */
        /*"      * ALTERACAO RILDO SICO - 26/09/2000 : INCLUSAO DA VIEW DE OPERA- *      */
        /*"      *                            COES - V0SINI_OPER_FUNCAO           *      */
        /*"      *                            PROCURAR RS001                      *      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO RILDO SICO - 16/10/2001 : MUDANCA PARA GERAR ARQUIVO *      */
        /*"      *                            PROCURAR RS002                      *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 07/05/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0808B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0808B
        {
            get
            {
                _.Move(REG_SI0808B, _RSI0808B); VarBasis.RedefinePassValue(REG_SI0808B, _RSI0808B, REG_SI0808B); return _RSI0808B;
            }
        }
        /*"01                  REG-SI0808B.*/
        public SI0808B_REG_SI0808B REG_SI0808B { get; set; } = new SI0808B_REG_SI0808B();
        public class SI0808B_REG_SI0808B : VarBasis
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
        /*"77         V0APOL-RAMO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APOL-CODCLIEN    PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77      V0HIST-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      V0HIST-VAL-OPERACAO   PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V0HIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77      V0HIST-SITUACAO       PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77      V0HIST-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1SEGU-NUM-APOLICE PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1SEGU_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SEGU-CODCLIEN    PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1SEGU_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SEGU-NRCERTIF    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1SEGU_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01           AREA-DE-WORK.*/
        public SI0808B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0808B_AREA_DE_WORK();
        public class SI0808B_AREA_DE_WORK : VarBasis
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
            /*"  05  WFIM-PAGTO-ANT       PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_PAGTO_ANT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-PAGTO-PERI      PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_PAGTO_PERI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-V1RELATOR    PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05       W-AC-LINHAS         PIC  9(002)      VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05       W-AC-PAGINA         PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         CH-CHAVE-ATU.*/
            public SI0808B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new SI0808B_CH_CHAVE_ATU();
            public class SI0808B_CH_CHAVE_ATU : VarBasis
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
            /*"  05  W-AC-OPERACAO-ANT        PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_AC_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-AC-OPERACAO-PERI       PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_AC_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TRANSF-VAL-OPERACAO    PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TRANSF_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-AVISADO            PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-OPERACAO-ANT       PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-OPERACAO-PERI      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-AJUSTE             PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_AJUSTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-AVISADO      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-OPERACAO-ANT PIC S9(013)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis W_TOT_GERAL_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-OPERACAO-PERI PIC S9(013)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis W_TOT_GERAL_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-AJUSTE       PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL_AJUSTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-COTACAO-HOJE           PIC S9(006)V9(09) VALUE +0 COMP-3*/
            public DoubleBasis W_COTACAO_HOJE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
            /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0808B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0808B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0808B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0808B_FILLER_0 : VarBasis
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

                public _REDEF_SI0808B_FILLER_0()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0808B_WHORA_CURR WHORA_CURR { get; set; } = new SI0808B_WHORA_CURR();
            public class SI0808B_WHORA_CURR : VarBasis
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
            public SI0808B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0808B_WDATA_CABEC();
            public class SI0808B_WDATA_CABEC : VarBasis
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
            public SI0808B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0808B_WHORA_CABEC();
            public class SI0808B_WHORA_CABEC : VarBasis
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
            public SI0808B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new SI0808B_WDATA_VIGENCIA();
            public class SI0808B_WDATA_VIGENCIA : VarBasis
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
            public SI0808B_WDATA_DTMOVTO WDATA_DTMOVTO { get; set; } = new SI0808B_WDATA_DTMOVTO();
            public class SI0808B_WDATA_DTMOVTO : VarBasis
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
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WABEND.*/
            public SI0808B_WABEND WABEND { get; set; } = new SI0808B_WABEND();
            public class SI0808B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0806B'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0806B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05            LC02.*/
            }
            public SI0808B_LC02 LC02 { get; set; } = new SI0808B_LC02();
            public class SI0808B_LC02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(010) VALUE  'SI0808B.1'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0808B.1");
                /*"    10 FILLER                  PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10 FILLER                  PIC  X(032) VALUE      'APURACAO DOS EXCEDENTES TECNICOS'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"APURACAO DOS EXCEDENTES TECNICOS");
                /*"    10          FILLER         PIC  X(004) VALUE  ';;;;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public SI0808B_LC03 LC03 { get; set; } = new SI0808B_LC03();
            public class SI0808B_LC03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(029) VALUE        'SINISTROS PAGOS NO PERIODO - '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"SINISTROS PAGOS NO PERIODO - ");
                /*"    10          LC03-DIA-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-INI   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10          LC03-DIA-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-TER   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public SI0808B_LC04 LC04 { get; set; } = new SI0808B_LC04();
            public class SI0808B_LC04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(022) VALUE    'USUARIO SOLICITANTE - '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"USUARIO SOLICITANTE - ");
                /*"    10          LC02-CODUSU    PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC02_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(002) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          FILLER         PIC  X(019) VALUE    'DATA SOLICITACAO - '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DATA SOLICITACAO - ");
                /*"    10          LC04-DIA-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_DIA_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-MES-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_MES_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-ANO-SOL   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC04_ANO_SOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"    10          FILLER         PIC  X(021) VALUE                               'FATORES EXPRESSOS EM '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"FATORES EXPRESSOS EM ");
                /*"    10          LC04-MOEDA     PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_MOEDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC06.*/
            }
            public SI0808B_LC06 LC06 { get; set; } = new SI0808B_LC06();
            public class SI0808B_LC06 : VarBasis
            {
                /*"    10          FILLER         PIC  X(013) VALUE 'APOLICE'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(034) VALUE 'SEGURADO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"SEGURADO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(013) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(010) VALUE 'DT AVISO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT AVISO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(016) VALUE 'VALOR AVISO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR AVISO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(016) VALUE 'PAGO ANT.'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PAGO ANT.");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(016) VALUE 'PAGO NO PER.'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PAGO NO PER.");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(016) VALUE 'VALOR AJUSTE'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR AJUSTE");
                /*"  05            LD01.*/
            }
            public SI0808B_LD01 LD01 { get; set; } = new SI0808B_LD01();
            public class SI0808B_LD01 : VarBasis
            {
                /*"    10          LD01-APOLICE   PIC  X(013) VALUE SPACE.*/
                public StringBasis LD01_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NOME      PIC  X(034) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NUM-SINI  PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_NUM_SINI { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-DIAAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIAAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MESAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_MESAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANOAV     PIC   9999  BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANOAV { get; set; } = new IntBasis(new PIC("9", "4", "9999"));
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLAVISO   PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLAVISO { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLPAGO-ANT PIC --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLPAGO_ANT { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLPAGO-PERI PIC --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLPAGO_PERI { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLAJUSTE  PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLAJUSTE { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"  05    LD02.*/
            }
            public SI0808B_LD02 LD02 { get; set; } = new SI0808B_LD02();
            public class SI0808B_LD02 : VarBasis
            {
                /*"    10  FILLER             PIC  X(020) VALUE        'TOTAL APOLICE  .....'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL APOLICE  .....");
                /*"    10  FILLER             PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10  LD02-TOT-AVISADO   PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD02-TOT-OPERACAO-ANT  PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD02-TOT-OPERACAO-PERI  PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD02-TOT-AJUSTE    PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"  05    LD03.*/
            }
            public SI0808B_LD03 LD03 { get; set; } = new SI0808B_LD03();
            public class SI0808B_LD03 : VarBasis
            {
                /*"    10  FILLER             PIC  X(020) VALUE        'TOTAL GERAL    .....'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL GERAL    .....");
                /*"    10  FILLER             PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10  LD03-TOT-GERAL-AVISADO   PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD03-TOT-GERAL-OPERACAO-ANT  PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD03-TOT-GERAL-OPERACAO-PERI  PIC --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"    10  FILLER             PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10  LD03-TOT-GERAL-AJUSTE    PIC  --------.--9,999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V999"), 3);
                /*"  05            LD04.*/
            }
            public SI0808B_LD04 LD04 { get; set; } = new SI0808B_LD04();
            public class SI0808B_LD04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(003) VALUE '** '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"** ");
                /*"    10  LD04-DEBITAR-CREDITAR  PIC  X(008) VALUE SPACES.*/
                public StringBasis LD04_DEBITAR_CREDITAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(057) VALUE        ' O TOTAL GERAL DO VALOR DE AJUSTE DA APURACAO, PORQUE EH        ' '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @" O TOTAL GERAL DO VALOR DE AJUSTE DA APURACAO, PORQUE EH        ");
                /*"    10  LD04-POSITIVO-NEGATIVO PIC  X(008) VALUE SPACES.*/
                public StringBasis LD04_POSITIVO_NEGATIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(003) VALUE ' **'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" **");
                /*"    10          FILLER         PIC  X(027) VALUE SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"01          LK-LINK.*/
            }
        }
        public SI0808B_LK_LINK LK_LINK { get; set; } = new SI0808B_LK_LINK();
        public class SI0808B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public SI0808B_V1RELATORIOS V1RELATORIOS { get; set; } = new SI0808B_V1RELATORIOS();
        public SI0808B_JOIN_HIST_MEST JOIN_HIST_MEST { get; set; } = new SI0808B_JOIN_HIST_MEST();
        public SI0808B_ANT ANT { get; set; } = new SI0808B_ANT();
        public SI0808B_PERI PERI { get; set; } = new SI0808B_PERI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0808B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0808B.SetFile(RSI0808B_FILE_NAME_P);

                /*" -491- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -492- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -495- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -498- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -498- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -506- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -507- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -508- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -509- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -511- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -512- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -516- OPEN OUTPUT RSI0808B */
            RSI0808B.Open(REG_SI0808B);

            /*" -518- PERFORM 0000-00-DECLARE-V1RELATORIOS. */

            M_0000_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -519- MOVE 'NAO' TO WFIM-V1RELATOR. */
            _.Move("NAO", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -521- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

            /*" -522- IF WFIM-V1RELATOR EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V1RELATOR == "SIM")
            {

                /*" -523- MOVE 'A' TO WCH-FINAL */
                _.Move("A", AREA_DE_WORK.WCH_FINAL);

                /*" -525- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -529- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -531- PERFORM 0000-00-ACESSA-V1SISTEMA */

            M_0000_00_ACESSA_V1SISTEMA_SECTION();

            /*" -532- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -533- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -534- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -535- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -537- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -540- PERFORM 0000-00-PROCESSA-V1RELATORIO UNTIL WFIM-V1RELATOR EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_V1RELATOR == "SIM"))
            {

                M_0000_00_PROCESSA_V1RELATORIO_SECTION();
            }

            /*" -542- PERFORM 0000-00-DELETE-V1RELATORIOS. */

            M_0000_00_DELETE_V1RELATORIOS_SECTION();

            /*" -543- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -543- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -545- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -546- DISPLAY 'ERRO ACESSO COMMIT' */
                _.Display($"ERRO ACESSO COMMIT");

                /*" -548- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -550- MOVE SPACES TO WCH-FINAL. */
            _.Move("", AREA_DE_WORK.WCH_FINAL);

            /*" -550- GO TO 0000-00-ENCERRA. */

            M_0000_00_ENCERRA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_PRINCIPAL*/

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-SECTION */
        private void M_0000_00_ACESSA_V1SISTEMA_SECTION()
        {
            /*" -559- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -564- PERFORM M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1 */

            M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();

            /*" -567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -568- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -569- MOVE 'B' TO WCH-FINAL */
                    _.Move("B", AREA_DE_WORK.WCH_FINAL);

                    /*" -570- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -571- ELSE */
                }
                else
                {


                    /*" -572- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -574- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -575- MOVE V1SIST-DTMOVABE TO WHOST-DTINIVIG. */
            _.Move(V1SIST_DTMOVABE, WHOST_DTINIVIG);

            /*" -577- MOVE 'G' TO WCH-FINAL. */
            _.Move("G", AREA_DE_WORK.WCH_FINAL);

            /*" -579- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -579- MOVE V1MOED-VLCRUZAD TO W-COTACAO-HOJE. */
            _.Move(V1MOED_VLCRUZAD, AREA_DE_WORK.W_COTACAO_HOJE);

        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1()
        {
            /*" -564- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -589- MOVE ZEROS TO W-AC-PAGINA. */
            _.Move(0, AREA_DE_WORK.W_AC_PAGINA);

            /*" -598- MOVE 80 TO W-AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.W_AC_LINHAS);

            /*" -600- MOVE ZEROS TO V0MEST-NUM-APOL-I V0MEST-RAMO-I. */
            _.Move(0, V0MEST_NUM_APOL_I, V0MEST_RAMO_I);

            /*" -601- MOVE 9999999999999 TO V0MEST-NUM-APOL-F. */
            _.Move(9999999999999, V0MEST_NUM_APOL_F);

            /*" -603- MOVE 99 TO V0MEST-RAMO-F. */
            _.Move(99, V0MEST_RAMO_F);

            /*" -604- IF V1RELA-RAMO NOT EQUAL ZEROS */

            if (V1RELA_RAMO != 00)
            {

                /*" -606- MOVE V1RELA-RAMO TO V0MEST-RAMO-I V0MEST-RAMO-F */
                _.Move(V1RELA_RAMO, V0MEST_RAMO_I, V0MEST_RAMO_F);

                /*" -607- ELSE */
            }
            else
            {


                /*" -608- IF V1RELA-NUM-APOLICE NOT EQUAL ZEROS */

                if (V1RELA_NUM_APOLICE != 00)
                {

                    /*" -611- MOVE V1RELA-NUM-APOLICE TO V0MEST-NUM-APOL-I V0MEST-NUM-APOL-F. */
                    _.Move(V1RELA_NUM_APOLICE, V0MEST_NUM_APOL_I, V0MEST_NUM_APOL_F);
                }

            }


            /*" -613- PERFORM 0000-00-DECLARE-JOIN-HIST-MEST. */

            M_0000_00_DECLARE_JOIN_HIST_MEST_SECTION();

            /*" -615- MOVE 'NAO' TO WFIM-JOIN-HIST-MEST. */
            _.Move("NAO", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

            /*" -617- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

            /*" -618- IF WFIM-JOIN-HIST-MEST EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM")
            {

                /*" -619- MOVE 'C' TO WCH-FINAL */
                _.Move("C", AREA_DE_WORK.WCH_FINAL);

                /*" -620- PERFORM 0000-00-ENCERRA */

                M_0000_00_ENCERRA_SECTION();

                /*" -622- GO TO 0000-01-LER-NOVO-V1RELATORIO. */

                M_0000_01_LER_NOVO_V1RELATORIO(); //GOTO
                return;
            }


            /*" -624- PERFORM 0000-00-PREPARA-CABECALHO. */

            M_0000_00_PREPARA_CABECALHO_SECTION();

            /*" -632- MOVE ZEROS TO W-TOT-GERAL-AVISADO W-TOT-GERAL-OPERACAO-ANT W-TOT-GERAL-OPERACAO-PERI W-TOT-GERAL-AJUSTE W-TOT-AVISADO W-TOT-OPERACAO-ANT W-TOT-OPERACAO-PERI W-TOT-AJUSTE. */
            _.Move(0, AREA_DE_WORK.W_TOT_GERAL_AVISADO, AREA_DE_WORK.W_TOT_GERAL_OPERACAO_ANT, AREA_DE_WORK.W_TOT_GERAL_OPERACAO_PERI, AREA_DE_WORK.W_TOT_GERAL_AJUSTE, AREA_DE_WORK.W_TOT_AVISADO, AREA_DE_WORK.W_TOT_OPERACAO_ANT, AREA_DE_WORK.W_TOT_OPERACAO_PERI, AREA_DE_WORK.W_TOT_AJUSTE);

            /*" -634- MOVE 'SIM' TO W-NOVA-APOLICE. */
            _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

            /*" -636- PERFORM 0000-00-MONTA-CABECALHO */

            M_0000_00_MONTA_CABECALHO_SECTION();

            /*" -639- PERFORM 0000-00-TRATA-JOIN-HIST-MEST UNTIL WFIM-JOIN-HIST-MEST EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
            {

                M_0000_00_TRATA_JOIN_HIST_MEST_SECTION();
            }

            /*" -639- PERFORM 0000-00-TOTAL-RELATORIO. */

            M_0000_00_TOTAL_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0000_01_LER_NOVO_V1RELATORIO */

            M_0000_01_LER_NOVO_V1RELATORIO();

        }

        [StopWatch]
        /*" M-0000-01-LER-NOVO-V1RELATORIO */
        private void M_0000_01_LER_NOVO_V1RELATORIO(bool isPerform = false)
        {
            /*" -645- PERFORM 0000-00-CLOSE-JOIN-HIST-MEST. */

            M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION();

            /*" -645- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V1RELATORIO*/

        [StopWatch]
        /*" M-0000-00-TRATA-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_TRATA_JOIN_HIST_MEST_SECTION()
        {
            /*" -656- MOVE ZEROS TO W-AC-AVISADO. */
            _.Move(0, AREA_DE_WORK.W_AC_AVISADO);

            /*" -660- PERFORM 0000-00-OBTEM-VALOR-AVISADO. */

            M_0000_00_OBTEM_VALOR_AVISADO_SECTION();

            /*" -661- MOVE ZEROS TO W-AC-OPERACAO-ANT. */
            _.Move(0, AREA_DE_WORK.W_AC_OPERACAO_ANT);

            /*" -662- IF V0MEST-DATCMD LESS V1RELA-PERI-INI */

            if (V0MEST_DATCMD < V1RELA_PERI_INI)
            {

                /*" -663- MOVE 'NAO' TO WFIM-PAGTO-ANT */
                _.Move("NAO", AREA_DE_WORK.WFIM_PAGTO_ANT);

                /*" -664- PERFORM 0000-00-DECLARE-PAGTO-ANT */

                M_0000_00_DECLARE_PAGTO_ANT_SECTION();

                /*" -665- PERFORM 0000-00-FETCH-PAGTO-ANT */

                M_0000_00_FETCH_PAGTO_ANT_SECTION();

                /*" -666- IF WFIM-PAGTO-ANT EQUAL 'NAO' */

                if (AREA_DE_WORK.WFIM_PAGTO_ANT == "NAO")
                {

                    /*" -668- PERFORM 0000-00-PROCESSA-PAGTO-ANT UNTIL (WFIM-PAGTO-ANT EQUAL 'SIM' ) */

                    while (!((AREA_DE_WORK.WFIM_PAGTO_ANT == "SIM")))
                    {

                        M_0000_00_PROCESSA_PAGTO_ANT_SECTION();
                    }

                    /*" -669- END-IF */
                }


                /*" -673- PERFORM 0000-00-CLOSE-PAGTO-ANT . */

                M_0000_00_CLOSE_PAGTO_ANT_SECTION();
            }


            /*" -674- MOVE ZEROS TO W-AC-OPERACAO-PERI. */
            _.Move(0, AREA_DE_WORK.W_AC_OPERACAO_PERI);

            /*" -675- MOVE 'NAO' TO WFIM-PAGTO-PERI */
            _.Move("NAO", AREA_DE_WORK.WFIM_PAGTO_PERI);

            /*" -676- PERFORM 0000-00-DECLARE-PAGTO-PERI */

            M_0000_00_DECLARE_PAGTO_PERI_SECTION();

            /*" -677- PERFORM 0000-00-FETCH-PAGTO-PERI */

            M_0000_00_FETCH_PAGTO_PERI_SECTION();

            /*" -678- IF WFIM-PAGTO-PERI EQUAL 'NAO' */

            if (AREA_DE_WORK.WFIM_PAGTO_PERI == "NAO")
            {

                /*" -680- PERFORM 0000-00-PROCESSA-PAGTO-PERI UNTIL (WFIM-PAGTO-PERI EQUAL 'SIM' ). */

                while (!((AREA_DE_WORK.WFIM_PAGTO_PERI == "SIM")))
                {

                    M_0000_00_PROCESSA_PAGTO_PERI_SECTION();
                }
            }


            /*" -682- PERFORM 0000-00-CLOSE-PAGTO-PERI . */

            M_0000_00_CLOSE_PAGTO_PERI_SECTION();

            /*" -685- PERFORM 0000-00-PREPARA-DETALHE. */

            M_0000_00_PREPARA_DETALHE_SECTION();

            /*" -697- MOVE V0MEST-NUM-APOLICE TO W-APOLICE-ANT. */
            _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);

            /*" -699- PERFORM 0000-00-IMPRIME-REGISTRO. */

            M_0000_00_IMPRIME_REGISTRO_SECTION();

            /*" -701- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

            /*" -703- IF (V0MEST-NUM-APOLICE NOT EQUAL W-APOLICE-ANT) OR (WFIM-JOIN-HIST-MEST EQUAL 'SIM' ) */

            if ((V0MEST_NUM_APOLICE != AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT) || (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
            {

                /*" -704- PERFORM 0000-00-TOTAL-APOLICE */

                M_0000_00_TOTAL_APOLICE_SECTION();

                /*" -708- MOVE ZEROS TO W-TOT-AVISADO W-TOT-OPERACAO-ANT W-TOT-OPERACAO-PERI W-TOT-AJUSTE */
                _.Move(0, AREA_DE_WORK.W_TOT_AVISADO, AREA_DE_WORK.W_TOT_OPERACAO_ANT, AREA_DE_WORK.W_TOT_OPERACAO_PERI, AREA_DE_WORK.W_TOT_AJUSTE);

                /*" -709- MOVE 'SIM' TO W-NOVA-APOLICE */
                _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

                /*" -709- MOVE V0MEST-NUM-APOLICE TO W-APOLICE-ANT. */
                _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-OBTEM-VALOR-AVISADO-SECTION */
        private void M_0000_00_OBTEM_VALOR_AVISADO_SECTION()
        {
            /*" -718- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -720- MOVE V0MEST-NUM-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -722- CALL 'SI1003S' USING SI1001S-PARAMETROS */
            _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

            /*" -723- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -725- DISPLAY 'PROBLEMA CALL SI1003S ' ' ' V0MEST-NUM-APOL-SINI */

                $"PROBLEMA CALL SI1003S  {V0MEST_NUM_APOL_SINI}"
                .Display();

                /*" -726- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -727- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -728- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -729- ELSE */
            }
            else
            {


                /*" -729- MOVE SI1001S-VALOR-CALCULADO TO W-AC-AVISADO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.W_AC_AVISADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_OBTEM_VALOR_AVISADO*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-VALOR-AVISADO-SECTION */
        private void M_0000_00_PROCESSA_VALOR_AVISADO_SECTION()
        {
            /*" -759- IF V0HIST-OPERACAO EQUAL 101 */

            if (V0HIST_OPERACAO == 101)
            {

                /*" -760- MOVE V0MEST-DATCMD TO WHOST-DTINIVIG */
                _.Move(V0MEST_DATCMD, WHOST_DTINIVIG);

                /*" -761- ELSE */
            }
            else
            {


                /*" -763- MOVE V0HIST-DTMOVTO TO WHOST-DTINIVIG. */
                _.Move(V0HIST_DTMOVTO, WHOST_DTINIVIG);
            }


            /*" -764- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -766- MOVE 'H' TO WCH-FINAL. */
            _.Move("H", AREA_DE_WORK.WCH_FINAL);

            /*" -768- PERFORM 0000-00-ACESSA-COTACAO-MOEDA. */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -771- COMPUTE W-TRANSF-VAL-OPERACAO = V0HIST-VAL-OPERACAO / V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_TRANSF_VAL_OPERACAO.Value = V0HIST_VAL_OPERACAO / V1MOED_VLCRUZAD;

            /*" -772- COMPUTE W-AC-AVISADO = W-AC-AVISADO + W-TRANSF-VAL-OPERACAO. */
            AREA_DE_WORK.W_AC_AVISADO.Value = AREA_DE_WORK.W_AC_AVISADO + AREA_DE_WORK.W_TRANSF_VAL_OPERACAO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_VALOR_AVISADO*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-PAGTO-ANT-SECTION */
        private void M_0000_00_PROCESSA_PAGTO_ANT_SECTION()
        {
            /*" -787- MOVE V0HIST-DTMOVTO TO WHOST-DTINIVIG. */
            _.Move(V0HIST_DTMOVTO, WHOST_DTINIVIG);

            /*" -788- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -790- MOVE 'H' TO WCH-FINAL. */
            _.Move("H", AREA_DE_WORK.WCH_FINAL);

            /*" -792- PERFORM 0000-00-ACESSA-COTACAO-MOEDA. */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -795- COMPUTE W-TRANSF-VAL-OPERACAO = V0HIST-VAL-OPERACAO / V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_TRANSF_VAL_OPERACAO.Value = V0HIST_VAL_OPERACAO / V1MOED_VLCRUZAD;

            /*" -798- COMPUTE W-AC-OPERACAO-ANT = W-AC-OPERACAO-ANT + W-TRANSF-VAL-OPERACAO. */
            AREA_DE_WORK.W_AC_OPERACAO_ANT.Value = AREA_DE_WORK.W_AC_OPERACAO_ANT + AREA_DE_WORK.W_TRANSF_VAL_OPERACAO;

            /*" -798- PERFORM 0000-00-FETCH-PAGTO-ANT . */

            M_0000_00_FETCH_PAGTO_ANT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_PAGTO_ANT*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-PAGTO-PERI-SECTION */
        private void M_0000_00_PROCESSA_PAGTO_PERI_SECTION()
        {
            /*" -806- MOVE V0HIST-DTMOVTO TO WHOST-DTINIVIG. */
            _.Move(V0HIST_DTMOVTO, WHOST_DTINIVIG);

            /*" -807- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -809- MOVE 'H' TO WCH-FINAL. */
            _.Move("H", AREA_DE_WORK.WCH_FINAL);

            /*" -811- PERFORM 0000-00-ACESSA-COTACAO-MOEDA. */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -814- COMPUTE W-TRANSF-VAL-OPERACAO = V0HIST-VAL-OPERACAO / V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_TRANSF_VAL_OPERACAO.Value = V0HIST_VAL_OPERACAO / V1MOED_VLCRUZAD;

            /*" -817- COMPUTE W-AC-OPERACAO-PERI = W-AC-OPERACAO-PERI + W-TRANSF-VAL-OPERACAO. */
            AREA_DE_WORK.W_AC_OPERACAO_PERI.Value = AREA_DE_WORK.W_AC_OPERACAO_PERI + AREA_DE_WORK.W_TRANSF_VAL_OPERACAO;

            /*" -817- PERFORM 0000-00-FETCH-PAGTO-PERI . */

            M_0000_00_FETCH_PAGTO_PERI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_PAGTO_PERI*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-REGISTRO-SECTION */
        private void M_0000_00_IMPRIME_REGISTRO_SECTION()
        {
            /*" -827- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -828- MOVE W-APOLICE-ANT TO LD01-APOLICE */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT, AREA_DE_WORK.LD01.LD01_APOLICE);

            /*" -833- MOVE ZEROS TO W-AC-AJUSTE. */
            _.Move(0, AREA_DE_WORK.W_AC_AJUSTE);

            /*" -834- IF W-AC-OPERACAO-ANT NOT EQUAL ZERO */

            if (AREA_DE_WORK.W_AC_OPERACAO_ANT != 00)
            {

                /*" -835- MOVE W-AC-AVISADO TO LD01-VLAVISO */
                _.Move(AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.LD01.LD01_VLAVISO);

                /*" -837- ADD W-AC-AVISADO TO W-TOT-AVISADO W-TOT-GERAL-AVISADO */
                AREA_DE_WORK.W_TOT_AVISADO.Value = AREA_DE_WORK.W_TOT_AVISADO + AREA_DE_WORK.W_AC_AVISADO;
                AREA_DE_WORK.W_TOT_GERAL_AVISADO.Value = AREA_DE_WORK.W_TOT_GERAL_AVISADO + AREA_DE_WORK.W_AC_AVISADO;

                /*" -840- COMPUTE W-AC-AJUSTE = W-AC-AVISADO - W-AC-OPERACAO-ANT - W-AC-OPERACAO-PERI */
                AREA_DE_WORK.W_AC_AJUSTE.Value = AREA_DE_WORK.W_AC_AVISADO - AREA_DE_WORK.W_AC_OPERACAO_ANT - AREA_DE_WORK.W_AC_OPERACAO_PERI;

                /*" -841- MOVE W-AC-AJUSTE TO LD01-VLAJUSTE */
                _.Move(AREA_DE_WORK.W_AC_AJUSTE, AREA_DE_WORK.LD01.LD01_VLAJUSTE);

                /*" -843- ADD W-AC-AJUSTE TO W-TOT-AJUSTE W-TOT-GERAL-AJUSTE */
                AREA_DE_WORK.W_TOT_AJUSTE.Value = AREA_DE_WORK.W_TOT_AJUSTE + AREA_DE_WORK.W_AC_AJUSTE;
                AREA_DE_WORK.W_TOT_GERAL_AJUSTE.Value = AREA_DE_WORK.W_TOT_GERAL_AJUSTE + AREA_DE_WORK.W_AC_AJUSTE;

                /*" -844- MOVE W-AC-OPERACAO-ANT TO LD01-VLPAGO-ANT */
                _.Move(AREA_DE_WORK.W_AC_OPERACAO_ANT, AREA_DE_WORK.LD01.LD01_VLPAGO_ANT);

                /*" -846- ADD W-AC-OPERACAO-ANT TO W-TOT-OPERACAO-ANT W-TOT-GERAL-OPERACAO-ANT */
                AREA_DE_WORK.W_TOT_OPERACAO_ANT.Value = AREA_DE_WORK.W_TOT_OPERACAO_ANT + AREA_DE_WORK.W_AC_OPERACAO_ANT;
                AREA_DE_WORK.W_TOT_GERAL_OPERACAO_ANT.Value = AREA_DE_WORK.W_TOT_GERAL_OPERACAO_ANT + AREA_DE_WORK.W_AC_OPERACAO_ANT;

                /*" -848- MOVE W-AC-OPERACAO-PERI TO LD01-VLPAGO-PERI */
                _.Move(AREA_DE_WORK.W_AC_OPERACAO_PERI, AREA_DE_WORK.LD01.LD01_VLPAGO_PERI);

                /*" -851- ADD W-AC-OPERACAO-PERI TO W-TOT-OPERACAO-PERI W-TOT-GERAL-OPERACAO-PERI */
                AREA_DE_WORK.W_TOT_OPERACAO_PERI.Value = AREA_DE_WORK.W_TOT_OPERACAO_PERI + AREA_DE_WORK.W_AC_OPERACAO_PERI;
                AREA_DE_WORK.W_TOT_GERAL_OPERACAO_PERI.Value = AREA_DE_WORK.W_TOT_GERAL_OPERACAO_PERI + AREA_DE_WORK.W_AC_OPERACAO_PERI;

                /*" -853- ELSE */
            }
            else
            {


                /*" -854- MOVE ZERO TO LD01-VLPAGO-ANT */
                _.Move(0, AREA_DE_WORK.LD01.LD01_VLPAGO_ANT);

                /*" -856- ADD ZERO TO W-TOT-OPERACAO-ANT W-TOT-GERAL-OPERACAO-ANT */
                AREA_DE_WORK.W_TOT_OPERACAO_ANT.Value = AREA_DE_WORK.W_TOT_OPERACAO_ANT + 00;
                AREA_DE_WORK.W_TOT_GERAL_OPERACAO_ANT.Value = AREA_DE_WORK.W_TOT_GERAL_OPERACAO_ANT + 00;

                /*" -858- MOVE W-AC-OPERACAO-PERI TO LD01-VLPAGO-PERI */
                _.Move(AREA_DE_WORK.W_AC_OPERACAO_PERI, AREA_DE_WORK.LD01.LD01_VLPAGO_PERI);

                /*" -861- ADD W-AC-OPERACAO-PERI TO W-TOT-OPERACAO-PERI W-TOT-GERAL-OPERACAO-PERI */
                AREA_DE_WORK.W_TOT_OPERACAO_PERI.Value = AREA_DE_WORK.W_TOT_OPERACAO_PERI + AREA_DE_WORK.W_AC_OPERACAO_PERI;
                AREA_DE_WORK.W_TOT_GERAL_OPERACAO_PERI.Value = AREA_DE_WORK.W_TOT_GERAL_OPERACAO_PERI + AREA_DE_WORK.W_AC_OPERACAO_PERI;

                /*" -862- IF V0MEST-DATCMD LESS V1RELA-PERI-INI */

                if (V0MEST_DATCMD < V1RELA_PERI_INI)
                {

                    /*" -863- MOVE W-AC-AVISADO TO LD01-VLAVISO */
                    _.Move(AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.LD01.LD01_VLAVISO);

                    /*" -865- ADD W-AC-AVISADO TO W-TOT-AVISADO W-TOT-GERAL-AVISADO */
                    AREA_DE_WORK.W_TOT_AVISADO.Value = AREA_DE_WORK.W_TOT_AVISADO + AREA_DE_WORK.W_AC_AVISADO;
                    AREA_DE_WORK.W_TOT_GERAL_AVISADO.Value = AREA_DE_WORK.W_TOT_GERAL_AVISADO + AREA_DE_WORK.W_AC_AVISADO;

                    /*" -867- COMPUTE W-AC-AJUSTE = W-AC-AVISADO - W-AC-OPERACAO-PERI */
                    AREA_DE_WORK.W_AC_AJUSTE.Value = AREA_DE_WORK.W_AC_AVISADO - AREA_DE_WORK.W_AC_OPERACAO_PERI;

                    /*" -868- ELSE */
                }
                else
                {


                    /*" -869- MOVE ZEROS TO LD01-VLAVISO */
                    _.Move(0, AREA_DE_WORK.LD01.LD01_VLAVISO);

                    /*" -871- ADD ZERO TO W-TOT-AVISADO W-TOT-GERAL-AVISADO */
                    AREA_DE_WORK.W_TOT_AVISADO.Value = AREA_DE_WORK.W_TOT_AVISADO + 00;
                    AREA_DE_WORK.W_TOT_GERAL_AVISADO.Value = AREA_DE_WORK.W_TOT_GERAL_AVISADO + 00;

                    /*" -873- MOVE W-AC-OPERACAO-PERI TO W-AC-AJUSTE */
                    _.Move(AREA_DE_WORK.W_AC_OPERACAO_PERI, AREA_DE_WORK.W_AC_AJUSTE);

                    /*" -875- COMPUTE W-AC-AJUSTE = W-AC-AJUSTE * -1. */
                    AREA_DE_WORK.W_AC_AJUSTE.Value = AREA_DE_WORK.W_AC_AJUSTE * -1;
                }

            }


            /*" -876- MOVE W-AC-AJUSTE TO LD01-VLAJUSTE. */
            _.Move(AREA_DE_WORK.W_AC_AJUSTE, AREA_DE_WORK.LD01.LD01_VLAJUSTE);

            /*" -879- ADD W-AC-AJUSTE TO W-TOT-AJUSTE W-TOT-GERAL-AJUSTE. */
            AREA_DE_WORK.W_TOT_AJUSTE.Value = AREA_DE_WORK.W_TOT_AJUSTE + AREA_DE_WORK.W_AC_AJUSTE;
            AREA_DE_WORK.W_TOT_GERAL_AJUSTE.Value = AREA_DE_WORK.W_TOT_GERAL_AJUSTE + AREA_DE_WORK.W_AC_AJUSTE;

            /*" -880- WRITE REG-SI0808B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

            /*" -880- ADD 2 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_REGISTRO*/

        [StopWatch]
        /*" M-0000-00-PREPARA-DETALHE-SECTION */
        private void M_0000_00_PREPARA_DETALHE_SECTION()
        {
            /*" -890- IF V0MEST-RAMO EQUAL 97 OR 93 OR 81 OR 80 OR 81 OR 91 */

            if (V0MEST_RAMO.In("97", "93", "81", "80", "81", "91"))
            {

                /*" -891- MOVE V0MEST-NUM-APOLICE TO V1SEGU-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOLICE, V1SEGU_NUM_APOLICE);

                /*" -892- MOVE V0MEST-NRCERTIF TO V1SEGU-NRCERTIF */
                _.Move(V0MEST_NRCERTIF, V1SEGU_NRCERTIF);

                /*" -893- PERFORM 0000-00-SELECT-V1SEGURAVG */

                M_0000_00_SELECT_V1SEGURAVG_SECTION();

                /*" -894- MOVE V1SEGU-CODCLIEN TO WHOST-CODCLIEN */
                _.Move(V1SEGU_CODCLIEN, WHOST_CODCLIEN);

                /*" -895- ELSE */
            }
            else
            {


                /*" -896- MOVE V0MEST-NUM-APOLICE TO V1APOL-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOLICE, V1APOL_NUM_APOLICE);

                /*" -897- PERFORM 0000-00-SELECT-V1APOLICE */

                M_0000_00_SELECT_V1APOLICE_SECTION();

                /*" -899- MOVE V1APOL-CODCLIEN TO WHOST-CODCLIEN. */
                _.Move(V1APOL_CODCLIEN, WHOST_CODCLIEN);
            }


            /*" -900- PERFORM 0000-00-SELECT-V1CLIENTE */

            M_0000_00_SELECT_V1CLIENTE_SECTION();

            /*" -901- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -902- MOVE '* CLIENTE  N A O  CADASTRADO *' TO LD01-NOME */
                _.Move("* CLIENTE  N A O  CADASTRADO *", AREA_DE_WORK.LD01.LD01_NOME);

                /*" -903- ELSE */
            }
            else
            {


                /*" -905- MOVE V1CLIE-NOME TO LD01-NOME. */
                _.Move(V1CLIE_NOME, AREA_DE_WORK.LD01.LD01_NOME);
            }


            /*" -906- MOVE V0MEST-NUM-APOL-SINI TO LD01-NUM-SINI. */
            _.Move(V0MEST_NUM_APOL_SINI, AREA_DE_WORK.LD01.LD01_NUM_SINI);

            /*" -907- MOVE V0MEST-DATCMD TO WDATA-VIGENCIA. */
            _.Move(V0MEST_DATCMD, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -908- MOVE WDATA-VIG-DIA TO LD01-DIAAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIAAV);

            /*" -909- MOVE WDATA-VIG-MES TO LD01-MESAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MESAV);

            /*" -909- MOVE WDATA-VIG-ANO TO LD01-ANOAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANOAV);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PREPARA_DETALHE*/

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-SECTION */
        private void M_0000_00_PREPARA_CABECALHO_SECTION()
        {
            /*" -920- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -924- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_1 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_1();

            /*" -927- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -928- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -929- MOVE 'D' TO WCH-FINAL */
                    _.Move("D", AREA_DE_WORK.WCH_FINAL);

                    /*" -930- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -931- ELSE */
                }
                else
                {


                    /*" -932- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -934- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -935- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -937- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -939- IF LK-RTCODE EQUAL ZEROS NEXT SENTENCE */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -940- ELSE */
            }
            else
            {


                /*" -941- MOVE 'E' TO WCH-FINAL */
                _.Move("E", AREA_DE_WORK.WCH_FINAL);

                /*" -943- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -945- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -949- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_2 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_2();

            /*" -952- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -953- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -954- MOVE 'F' TO WCH-FINAL */
                    _.Move("F", AREA_DE_WORK.WCH_FINAL);

                    /*" -955- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -956- ELSE */
                }
                else
                {


                    /*" -957- DISPLAY 'PROBLEMAS ACESSO V0MOEDA' */
                    _.Display($"PROBLEMAS ACESSO V0MOEDA");

                    /*" -959- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -961- MOVE V0MOED-SIGLUNIM TO LC04-MOEDA. */
            _.Move(V0MOED_SIGLUNIM, AREA_DE_WORK.LC04.LC04_MOEDA);

            /*" -963- MOVE V1RELA-CODUSU TO LC02-CODUSU. */
            _.Move(V1RELA_CODUSU, AREA_DE_WORK.LC04.LC02_CODUSU);

            /*" -964- MOVE V1RELA-DT-SOLICITA TO WDATA-VIGENCIA */
            _.Move(V1RELA_DT_SOLICITA, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -965- MOVE WDATA-VIG-DIA TO LC04-DIA-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC04.LC04_DIA_SOL);

            /*" -966- MOVE WDATA-VIG-MES TO LC04-MES-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC04.LC04_MES_SOL);

            /*" -968- MOVE WDATA-VIG-ANO TO LC04-ANO-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC04.LC04_ANO_SOL);

            /*" -969- MOVE V1RELA-PERI-INI TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_INI, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -970- MOVE WDATA-VIG-DIA TO LC03-DIA-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_INI);

            /*" -971- MOVE WDATA-VIG-MES TO LC03-MES-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_INI);

            /*" -973- MOVE WDATA-VIG-ANO TO LC03-ANO-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_INI);

            /*" -974- MOVE V1RELA-PERI-FIM TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_FIM, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -975- MOVE WDATA-VIG-DIA TO LC03-DIA-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_TER);

            /*" -976- MOVE WDATA-VIG-MES TO LC03-MES-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_TER);

            /*" -976- MOVE WDATA-VIG-ANO TO LC03-ANO-TER. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_TER);

        }

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-DB-SELECT-1 */
        public void M_0000_00_PREPARA_CABECALHO_DB_SELECT_1()
        {
            /*" -924- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -949- EXEC SQL SELECT SIGLUNIM INTO :V0MOED-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO END-EXEC. */

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
            /*" -988- ADD 1 TO W-AC-PAGINA */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -989- WRITE REG-SI0808B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

            /*" -990- WRITE REG-SI0808B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

            /*" -991- WRITE REG-SI0808B FROM LC04 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

            /*" -991- WRITE REG-SI0808B FROM LC06. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_MONTA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-SECTION */
        private void M_0000_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -1002- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1007- PERFORM M_0000_00_SELECT_V1APOLICE_DB_SELECT_1 */

            M_0000_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -1010- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1011- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1012- MOVE ZEROS TO V1APOL-CODCLIEN */
                    _.Move(0, V1APOL_CODCLIEN);

                    /*" -1013- ELSE */
                }
                else
                {


                    /*" -1014- DISPLAY 'ERRO ACESSO V1APOLICE' */
                    _.Display($"ERRO ACESSO V1APOLICE");

                    /*" -1014- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -1007- EXEC SQL SELECT CODCLIEN INTO :V1APOL-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1APOL-NUM-APOLICE END-EXEC. */

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
            /*" -1025- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1034- PERFORM M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -1037- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1038- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1039- MOVE ZEROS TO V1SEGU-CODCLIEN */
                    _.Move(0, V1SEGU_CODCLIEN);

                    /*" -1040- ELSE */
                }
                else
                {


                    /*" -1041- DISPLAY 'ERRO ACESSO V1SEGURAVG' */
                    _.Display($"ERRO ACESSO V1SEGURAVG");

                    /*" -1041- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -1034- EXEC SQL SELECT COD_CLIENTE INTO :V1SEGU-CODCLIEN FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :V1SEGU-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

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
            /*" -1051- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1056- PERFORM M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -1059- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1060- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1061- MOVE 'SEGURADO NAO CADASTRADO' TO V1CLIE-NOME */
                    _.Move("SEGURADO NAO CADASTRADO", V1CLIE_NOME);

                    /*" -1062- ELSE */
                }
                else
                {


                    /*" -1063- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -1063- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1056- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

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
            /*" -1073- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1080- PERFORM M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1 */

            M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1();

            /*" -1083- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1084- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1085- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -1086- ELSE */
                }
                else
                {


                    /*" -1087- DISPLAY 'PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -1087- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1()
        {
            /*" -1080- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-CODUNIMO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

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
            /*" -1096- MOVE W-TOT-AVISADO TO LD02-TOT-AVISADO. */
            _.Move(AREA_DE_WORK.W_TOT_AVISADO, AREA_DE_WORK.LD02.LD02_TOT_AVISADO);

            /*" -1097- MOVE W-TOT-OPERACAO-ANT TO LD02-TOT-OPERACAO-ANT. */
            _.Move(AREA_DE_WORK.W_TOT_OPERACAO_ANT, AREA_DE_WORK.LD02.LD02_TOT_OPERACAO_ANT);

            /*" -1098- MOVE W-TOT-OPERACAO-PERI TO LD02-TOT-OPERACAO-PERI. */
            _.Move(AREA_DE_WORK.W_TOT_OPERACAO_PERI, AREA_DE_WORK.LD02.LD02_TOT_OPERACAO_PERI);

            /*" -1100- MOVE W-TOT-AJUSTE TO LD02-TOT-AJUSTE. */
            _.Move(AREA_DE_WORK.W_TOT_AJUSTE, AREA_DE_WORK.LD02.LD02_TOT_AJUSTE);

            /*" -1100- WRITE REG-SI0808B FROM LD02. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_APOLICE*/

        [StopWatch]
        /*" M-0000-00-TOTAL-RELATORIO-SECTION */
        private void M_0000_00_TOTAL_RELATORIO_SECTION()
        {
            /*" -1109- MOVE W-TOT-GERAL-AVISADO TO LD03-TOT-GERAL-AVISADO. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_AVISADO, AREA_DE_WORK.LD03.LD03_TOT_GERAL_AVISADO);

            /*" -1111- MOVE W-TOT-GERAL-OPERACAO-ANT TO LD03-TOT-GERAL-OPERACAO-ANT. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_OPERACAO_ANT, AREA_DE_WORK.LD03.LD03_TOT_GERAL_OPERACAO_ANT);

            /*" -1113- MOVE W-TOT-GERAL-OPERACAO-PERI TO LD03-TOT-GERAL-OPERACAO-PERI. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_OPERACAO_PERI, AREA_DE_WORK.LD03.LD03_TOT_GERAL_OPERACAO_PERI);

            /*" -1115- MOVE W-TOT-GERAL-AJUSTE TO LD03-TOT-GERAL-AJUSTE. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_AJUSTE, AREA_DE_WORK.LD03.LD03_TOT_GERAL_AJUSTE);

            /*" -1117- WRITE REG-SI0808B FROM LD03. */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

            /*" -1118- IF W-TOT-GERAL-AJUSTE GREATER ZERO */

            if (AREA_DE_WORK.W_TOT_GERAL_AJUSTE > 00)
            {

                /*" -1119- MOVE 'CREDITAR' TO LD04-DEBITAR-CREDITAR */
                _.Move("CREDITAR", AREA_DE_WORK.LD04.LD04_DEBITAR_CREDITAR);

                /*" -1120- MOVE 'POSITIVO' TO LD04-POSITIVO-NEGATIVO */
                _.Move("POSITIVO", AREA_DE_WORK.LD04.LD04_POSITIVO_NEGATIVO);

                /*" -1121- ELSE */
            }
            else
            {


                /*" -1122- MOVE 'DEBITAR' TO LD04-DEBITAR-CREDITAR */
                _.Move("DEBITAR", AREA_DE_WORK.LD04.LD04_DEBITAR_CREDITAR);

                /*" -1124- MOVE 'NEGATIVO' TO LD04-POSITIVO-NEGATIVO. */
                _.Move("NEGATIVO", AREA_DE_WORK.LD04.LD04_POSITIVO_NEGATIVO);
            }


            /*" -1124- WRITE REG-SI0808B FROM LD04. */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_SI0808B);

            RSI0808B.Write(REG_SI0808B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_RELATORIO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -1135- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1147- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -1149- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -1152- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1153- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -1153- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -1147- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT RAMO , NUM_APOLICE , CODUNIMO , PERI_INICIAL , PERI_FINAL , CODUSU , DATA_SOLICITACAO FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0808B' ORDER BY CODUSU, DATA_SOLICITACAO, PERI_INICIAL, RAMO,NUM_APOLICE END-EXEC. */
            V1RELATORIOS = new SI0808B_V1RELATORIOS(false);
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
							WHERE CODRELAT = 'SI0808B' 
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
            /*" -1149- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1()
        {
            /*" -1233- EXEC SQL DECLARE JOIN-HIST-MEST CURSOR FOR SELECT DISTINCT(MEST.NUM_APOLICE), MEST.NUM_APOL_SINISTRO , MEST.RAMO , MEST.NRCERTIF , MEST.SITUACAO , MEST.DATCMD FROM SEGUROS.V0MESTSINI MEST, SEGUROS.V0HISTSINI HIST WHERE HIST.DTMOVTO BETWEEN :V1RELA-PERI-INI AND :V1RELA-PERI-FIM AND HIST.OPERACAO IN (1002, 1003, 1009) AND HIST.SITUACAO <> '2' AND MEST.SITUACAO <> '2' AND MEST.NUM_APOLICE BETWEEN :V0MEST-NUM-APOL-I AND :V0MEST-NUM-APOL-F AND MEST.NUM_APOL_SINISTRO = HIST.NUM_APOL_SINISTRO ORDER BY MEST.NUM_APOL_SINISTRO END-EXEC. */
            JOIN_HIST_MEST = new SI0808B_JOIN_HIST_MEST(true);
            string GetQuery_JOIN_HIST_MEST()
            {
                var query = @$"SELECT DISTINCT(MEST.NUM_APOLICE)
							, 
							MEST.NUM_APOL_SINISTRO
							, 
							MEST.RAMO
							, 
							MEST.NRCERTIF
							, 
							MEST.SITUACAO
							, 
							MEST.DATCMD 
							FROM SEGUROS.V0MESTSINI MEST
							, 
							SEGUROS.V0HISTSINI HIST 
							WHERE HIST.DTMOVTO BETWEEN '{V1RELA_PERI_INI}' 
							AND 
							'{V1RELA_PERI_FIM}' 
							AND HIST.OPERACAO IN (1002
							, 1003
							, 1009) 
							AND HIST.SITUACAO <> '2' 
							AND MEST.SITUACAO <> '2' 
							AND MEST.NUM_APOLICE BETWEEN '{V0MEST_NUM_APOL_I}' 
							AND 
							'{V0MEST_NUM_APOL_F}' 
							AND MEST.NUM_APOL_SINISTRO = HIST.NUM_APOL_SINISTRO 
							ORDER BY 
							MEST.NUM_APOL_SINISTRO";

                return query;
            }
            JOIN_HIST_MEST.GetQueryEvent += GetQuery_JOIN_HIST_MEST;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_V1RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-SECTION */
        private void M_0000_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -1165- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1173- PERFORM M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -1176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1177- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1178- MOVE 'SIM' TO WFIM-V1RELATOR */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -1179- ELSE */
                }
                else
                {


                    /*" -1180- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -1182- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1183- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -1184- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1185- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1186- DISPLAY '*      ==>     SI0808B      <==         *' */
                _.Display($"*      ==>     SI0808B      <==         *");

                /*" -1187- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1188- DISPLAY '*  DISPLAY DOS DADOS INFORMADOS PELO    *' */
                _.Display($"*  DOS DADOS INFORMADOS PELO    *");

                /*" -1189- DISPLAY '*  USUARIO NA V1RELATORIOS              *' */
                _.Display($"*  USUARIO NA V1RELATORIOS              *");

                /*" -1190- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1191- DISPLAY '* COD-EMPRESA ...... ' V1RELA-COD-EMPRESA */
                _.Display($"* COD-EMPRESA ...... {V1RELA_COD_EMPRESA}");

                /*" -1192- DISPLAY '* RAMO        ...... ' V1RELA-RAMO */
                _.Display($"* RAMO        ...... {V1RELA_RAMO}");

                /*" -1193- DISPLAY '* NUM. APOL.  ...... ' V1RELA-NUM-APOLICE */
                _.Display($"* NUM. APOL.  ...... {V1RELA_NUM_APOLICE}");

                /*" -1194- DISPLAY '* CODUNIMO    ...... ' V1RELA-CODUNIMO */
                _.Display($"* CODUNIMO    ...... {V1RELA_CODUNIMO}");

                /*" -1195- DISPLAY '* PERI. INIC. ...... ' V1RELA-PERI-INI */
                _.Display($"* PERI. INIC. ...... {V1RELA_PERI_INI}");

                /*" -1196- DISPLAY '* PERI. FIM   ...... ' V1RELA-PERI-FIM */
                _.Display($"* PERI. FIM   ...... {V1RELA_PERI_FIM}");

                /*" -1197- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1197- DISPLAY '*****************************************' . */
                _.Display($"*****************************************");
            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -1173- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-RAMO , :V1RELA-NUM-APOLICE , :V1RELA-CODUNIMO , :V1RELA-PERI-INI , :V1RELA-PERI-FIM , :V1RELA-CODUSU , :V1RELA-DT-SOLICITA END-EXEC. */

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
            /*" -1208- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1233- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1();

            /*" -1235- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1();

            /*" -1238- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1239- DISPLAY 'PROBLEMAS OPEN JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS OPEN JOIN-HIST-MEST.. ");

                /*" -1239- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-OPEN-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1()
        {
            /*" -1235- EXEC SQL OPEN JOIN-HIST-MEST END-EXEC. */

            JOIN_HIST_MEST.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGTO-ANT-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_PAGTO_ANT_DB_DECLARE_1()
        {
            /*" -1308- EXEC SQL DECLARE ANT CURSOR FOR SELECT VAL_OPERACAO , DTMOVTO FROM SEGUROS.V0HISTSINI WHERE OPERACAO IN (1001, 1002, 1003, 1009) AND DTMOVTO >= :V0MEST-DATCMD AND DTMOVTO < :V1RELA-PERI-INI AND SITUACAO <> '2' AND NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINI END-EXEC. */
            ANT = new SI0808B_ANT(true);
            string GetQuery_ANT()
            {
                var query = @$"SELECT VAL_OPERACAO
							, 
							DTMOVTO 
							FROM SEGUROS.V0HISTSINI 
							WHERE OPERACAO IN (1001
							, 1002
							, 1003
							, 1009) 
							AND DTMOVTO >= '{V0MEST_DATCMD}' 
							AND DTMOVTO < '{V1RELA_PERI_INI}' 
							AND SITUACAO <> '2' 
							AND NUM_APOL_SINISTRO = '{V0MEST_NUM_APOL_SINI}'";

                return query;
            }
            ANT.GetQueryEvent += GetQuery_ANT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_FETCH_JOIN_HIST_MEST_SECTION()
        {
            /*" -1248- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1257- PERFORM M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1 */

            M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1();

            /*" -1271- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1272- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1273- MOVE 'SIM' TO WFIM-JOIN-HIST-MEST */
                    _.Move("SIM", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

                    /*" -1274- ELSE */
                }
                else
                {


                    /*" -1275- DISPLAY 'PROBLEMAS NO FETCH DA JOIN-HIST-MEST' */
                    _.Display($"PROBLEMAS NO FETCH DA JOIN-HIST-MEST");

                    /*" -1275- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-DB-FETCH-1 */
        public void M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1()
        {
            /*" -1257- EXEC SQL FETCH JOIN-HIST-MEST INTO :V0MEST-NUM-APOLICE , :V0MEST-NUM-APOL-SINI , :V0MEST-RAMO , :V0MEST-NRCERTIF , :V0MEST-SITUACAO , :V0MEST-DATCMD END-EXEC. */

            if (JOIN_HIST_MEST.Fetch())
            {
                _.Move(JOIN_HIST_MEST.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(JOIN_HIST_MEST.V0MEST_NUM_APOL_SINI, V0MEST_NUM_APOL_SINI);
                _.Move(JOIN_HIST_MEST.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(JOIN_HIST_MEST.V0MEST_NRCERTIF, V0MEST_NRCERTIF);
                _.Move(JOIN_HIST_MEST.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(JOIN_HIST_MEST.V0MEST_DATCMD, V0MEST_DATCMD);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION()
        {
            /*" -1285- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1285- PERFORM M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1 */

            M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1();

            /*" -1288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1289- DISPLAY 'PROBLEMAS CLOSE JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS CLOSE JOIN-HIST-MEST.. ");

                /*" -1289- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1()
        {
            /*" -1285- EXEC SQL CLOSE JOIN-HIST-MEST END-EXEC. */

            JOIN_HIST_MEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGTO-ANT-SECTION */
        private void M_0000_00_DECLARE_PAGTO_ANT_SECTION()
        {
            /*" -1299- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1308- PERFORM M_0000_00_DECLARE_PAGTO_ANT_DB_DECLARE_1 */

            M_0000_00_DECLARE_PAGTO_ANT_DB_DECLARE_1();

            /*" -1310- PERFORM M_0000_00_DECLARE_PAGTO_ANT_DB_OPEN_1 */

            M_0000_00_DECLARE_PAGTO_ANT_DB_OPEN_1();

            /*" -1313- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1314- DISPLAY 'PROBLEMAS OPEN ANT      ....... ' */
                _.Display($"PROBLEMAS OPEN ANT      ....... ");

                /*" -1314- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGTO-ANT-DB-OPEN-1 */
        public void M_0000_00_DECLARE_PAGTO_ANT_DB_OPEN_1()
        {
            /*" -1310- EXEC SQL OPEN ANT END-EXEC. */

            ANT.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGTO-PERI-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_PAGTO_PERI_DB_DECLARE_1()
        {
            /*" -1368- EXEC SQL DECLARE PERI CURSOR FOR SELECT VAL_OPERACAO , DTMOVTO FROM SEGUROS.V0HISTSINI WHERE OPERACAO IN (1001, 1002, 1003, 1009) AND DTMOVTO BETWEEN :V1RELA-PERI-INI AND :V1RELA-PERI-FIM AND SITUACAO <> '2' AND NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINI END-EXEC. */
            PERI = new SI0808B_PERI(true);
            string GetQuery_PERI()
            {
                var query = @$"SELECT VAL_OPERACAO
							, 
							DTMOVTO 
							FROM SEGUROS.V0HISTSINI 
							WHERE OPERACAO IN (1001
							, 1002
							, 1003
							, 1009) 
							AND DTMOVTO BETWEEN '{V1RELA_PERI_INI}' 
							AND 
							'{V1RELA_PERI_FIM}' 
							AND SITUACAO <> '2' 
							AND NUM_APOL_SINISTRO = '{V0MEST_NUM_APOL_SINI}'";

                return query;
            }
            PERI.GetQueryEvent += GetQuery_PERI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_PAGTO_ANT*/

        [StopWatch]
        /*" M-0000-00-FETCH-PAGTO-ANT-SECTION */
        private void M_0000_00_FETCH_PAGTO_ANT_SECTION()
        {
            /*" -1323- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1327- PERFORM M_0000_00_FETCH_PAGTO_ANT_DB_FETCH_1 */

            M_0000_00_FETCH_PAGTO_ANT_DB_FETCH_1();

            /*" -1330- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1331- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1332- MOVE 'SIM' TO WFIM-PAGTO-ANT */
                    _.Move("SIM", AREA_DE_WORK.WFIM_PAGTO_ANT);

                    /*" -1333- ELSE */
                }
                else
                {


                    /*" -1334- DISPLAY 'PROBLEMAS NO FETCH DO ANT     ......' */
                    _.Display($"PROBLEMAS NO FETCH DO ANT     ......");

                    /*" -1334- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-PAGTO-ANT-DB-FETCH-1 */
        public void M_0000_00_FETCH_PAGTO_ANT_DB_FETCH_1()
        {
            /*" -1327- EXEC SQL FETCH ANT INTO :V0HIST-VAL-OPERACAO , :V0HIST-DTMOVTO END-EXEC. */

            if (ANT.Fetch())
            {
                _.Move(ANT.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
                _.Move(ANT.V0HIST_DTMOVTO, V0HIST_DTMOVTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_PAGTO_ANT*/

        [StopWatch]
        /*" M-0000-00-CLOSE-PAGTO-ANT-SECTION */
        private void M_0000_00_CLOSE_PAGTO_ANT_SECTION()
        {
            /*" -1344- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1344- PERFORM M_0000_00_CLOSE_PAGTO_ANT_DB_CLOSE_1 */

            M_0000_00_CLOSE_PAGTO_ANT_DB_CLOSE_1();

            /*" -1347- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1348- DISPLAY 'PROBLEMAS CLOSE ANT      ....... ' */
                _.Display($"PROBLEMAS CLOSE ANT      ....... ");

                /*" -1348- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-PAGTO-ANT-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_PAGTO_ANT_DB_CLOSE_1()
        {
            /*" -1344- EXEC SQL CLOSE ANT END-EXEC. */

            ANT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_PAGTO_ANT*/

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGTO-PERI-SECTION */
        private void M_0000_00_DECLARE_PAGTO_PERI_SECTION()
        {
            /*" -1358- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1368- PERFORM M_0000_00_DECLARE_PAGTO_PERI_DB_DECLARE_1 */

            M_0000_00_DECLARE_PAGTO_PERI_DB_DECLARE_1();

            /*" -1370- PERFORM M_0000_00_DECLARE_PAGTO_PERI_DB_OPEN_1 */

            M_0000_00_DECLARE_PAGTO_PERI_DB_OPEN_1();

            /*" -1373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1374- DISPLAY 'PROBLEMAS OPEN PERI     ....... ' */
                _.Display($"PROBLEMAS OPEN PERI     ....... ");

                /*" -1374- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-PAGTO-PERI-DB-OPEN-1 */
        public void M_0000_00_DECLARE_PAGTO_PERI_DB_OPEN_1()
        {
            /*" -1370- EXEC SQL OPEN PERI END-EXEC. */

            PERI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_PAGTO_PERI*/

        [StopWatch]
        /*" M-0000-00-FETCH-PAGTO-PERI-SECTION */
        private void M_0000_00_FETCH_PAGTO_PERI_SECTION()
        {
            /*" -1383- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1387- PERFORM M_0000_00_FETCH_PAGTO_PERI_DB_FETCH_1 */

            M_0000_00_FETCH_PAGTO_PERI_DB_FETCH_1();

            /*" -1390- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1391- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1392- MOVE 'SIM' TO WFIM-PAGTO-PERI */
                    _.Move("SIM", AREA_DE_WORK.WFIM_PAGTO_PERI);

                    /*" -1393- ELSE */
                }
                else
                {


                    /*" -1394- DISPLAY 'PROBLEMAS NO FETCH DO PERI    ......' */
                    _.Display($"PROBLEMAS NO FETCH DO PERI    ......");

                    /*" -1394- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-PAGTO-PERI-DB-FETCH-1 */
        public void M_0000_00_FETCH_PAGTO_PERI_DB_FETCH_1()
        {
            /*" -1387- EXEC SQL FETCH PERI INTO :V0HIST-VAL-OPERACAO , :V0HIST-DTMOVTO END-EXEC. */

            if (PERI.Fetch())
            {
                _.Move(PERI.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
                _.Move(PERI.V0HIST_DTMOVTO, V0HIST_DTMOVTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_PAGTO_PERI*/

        [StopWatch]
        /*" M-0000-00-CLOSE-PAGTO-PERI-SECTION */
        private void M_0000_00_CLOSE_PAGTO_PERI_SECTION()
        {
            /*" -1404- MOVE '026' TO WNR-EXEC-SQL. */
            _.Move("026", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1404- PERFORM M_0000_00_CLOSE_PAGTO_PERI_DB_CLOSE_1 */

            M_0000_00_CLOSE_PAGTO_PERI_DB_CLOSE_1();

            /*" -1407- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1408- DISPLAY 'PROBLEMAS CLOSE PERI     ....... ' */
                _.Display($"PROBLEMAS CLOSE PERI     ....... ");

                /*" -1408- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-PAGTO-PERI-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_PAGTO_PERI_DB_CLOSE_1()
        {
            /*" -1404- EXEC SQL CLOSE PERI END-EXEC. */

            PERI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_PAGTO_PERI*/

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V1RELATORIOS_SECTION()
        {
            /*" -1419- MOVE '027' TO WNR-EXEC-SQL. */
            _.Move("027", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1421- PERFORM M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1();

            /*" -1424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1425- DISPLAY 'PROBLEMA DELETE V1RELATORIOS' */
                _.Display($"PROBLEMA DELETE V1RELATORIOS");

                /*" -1425- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -1421- EXEC SQL DELETE FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0808B' END-EXEC. */

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
            /*" -1437- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1438- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -1439- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1440- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1441- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1442- DISPLAY '//     ==>     SI0808B      <==        //' */
                _.Display($"//     ==>     SI0808B      <==        //");

                /*" -1443- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1444- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -1445- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1446- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1447- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1448- ELSE */
            }
            else
            {


                /*" -1449- IF WCH-FINAL EQUAL 'A' */

                if (AREA_DE_WORK.WCH_FINAL == "A")
                {

                    /*" -1450- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1451- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1452- DISPLAY '*      ==>     SI0808B      <==         *' */
                    _.Display($"*      ==>     SI0808B      <==         *");

                    /*" -1453- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1454- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                    _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                    /*" -1455- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1456- DISPLAY '*  NAO HOUVE SOLICITACAO PELO USUARIO,  *' */
                    _.Display($"*  NAO HOUVE SOLICITACAO PELO USUARIO,  *");

                    /*" -1457- DISPLAY '*  PARA EXECUCAO DO PROGRAMA SI0808B.   *' */
                    _.Display($"*  PARA EXECUCAO DO PROGRAMA SI0808B.   *");

                    /*" -1458- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1459- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1460- ELSE */
                }
                else
                {


                    /*" -1461- IF WCH-FINAL EQUAL 'B' */

                    if (AREA_DE_WORK.WCH_FINAL == "B")
                    {

                        /*" -1462- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1463- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1464- DISPLAY '*      ==>     SI0808B      <==         *' */
                        _.Display($"*      ==>     SI0808B      <==         *");

                        /*" -1465- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1466- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                        /*" -1467- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1468- DISPLAY '*  DATA DO SISTEMA NAO FOI ENCONTRADO   *' */
                        _.Display($"*  DATA DO SISTEMA NAO FOI ENCONTRADO   *");

                        /*" -1469- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1470- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1471- ELSE */
                    }
                    else
                    {


                        /*" -1472- IF WCH-FINAL EQUAL 'C' */

                        if (AREA_DE_WORK.WCH_FINAL == "C")
                        {

                            /*" -1473- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1474- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1475- DISPLAY '*      ==>     SI0808B      <==         *' */
                            _.Display($"*      ==>     SI0808B      <==         *");

                            /*" -1476- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1477- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                            _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                            /*" -1478- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1479- DISPLAY '*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*' */
                            _.Display($"*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*");

                            /*" -1480- DISPLAY '*  PARA OS PARAMETROS INFORMADOS.       *' */
                            _.Display($"*  PARA OS PARAMETROS INFORMADOS.       *");

                            /*" -1481- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1482- DISPLAY '*  RAMO   ............ ' V1RELA-RAMO */
                            _.Display($"*  RAMO   ............ {V1RELA_RAMO}");

                            /*" -1483- DISPLAY '*  APOLICE ........... ' V1RELA-NUM-APOLICE */
                            _.Display($"*  APOLICE ........... {V1RELA_NUM_APOLICE}");

                            /*" -1484- DISPLAY '*  PERIODO INCIAL .... ' V1RELA-PERI-INI */
                            _.Display($"*  PERIODO INCIAL .... {V1RELA_PERI_INI}");

                            /*" -1485- DISPLAY '*  PERIODO FINAL  .... ' V1RELA-PERI-FIM */
                            _.Display($"*  PERIODO FINAL  .... {V1RELA_PERI_FIM}");

                            /*" -1486- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1487- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1488- ELSE */
                        }
                        else
                        {


                            /*" -1489- IF WCH-FINAL EQUAL 'D' */

                            if (AREA_DE_WORK.WCH_FINAL == "D")
                            {

                                /*" -1490- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1491- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1492- DISPLAY '*      ==>     SI0808B      <==         *' */
                                _.Display($"*      ==>     SI0808B      <==         *");

                                /*" -1493- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1494- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                /*" -1495- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1496- DISPLAY '*       EMPRESA NAO CADASTRADA          *' */
                                _.Display($"*       EMPRESA NAO CADASTRADA          *");

                                /*" -1497- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1498- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1499- ELSE */
                            }
                            else
                            {


                                /*" -1500- IF WCH-FINAL EQUAL 'E' */

                                if (AREA_DE_WORK.WCH_FINAL == "E")
                                {

                                    /*" -1501- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1502- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1503- DISPLAY '*      ==>     SI0808B      <==         *' */
                                    _.Display($"*      ==>     SI0808B      <==         *");

                                    /*" -1504- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1505- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                    _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                    /*" -1506- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1507- DISPLAY '*  PROBLEMA NO LINK PARA A SUBROTINA    *' */
                                    _.Display($"*  PROBLEMA NO LINK PARA A SUBROTINA    *");

                                    /*" -1508- DISPLAY '*  PROALN01 PARA ACESSO AO NOME EMPRESA *' */
                                    _.Display($"*  PROALN01 PARA ACESSO AO NOME EMPRESA *");

                                    /*" -1509- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1510- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1511- ELSE */
                                }
                                else
                                {


                                    /*" -1512- IF WCH-FINAL EQUAL 'F' */

                                    if (AREA_DE_WORK.WCH_FINAL == "F")
                                    {

                                        /*" -1513- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1514- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1515- DISPLAY '*      ==>     SI0808B      <==         *' */
                                        _.Display($"*      ==>     SI0808B      <==         *");

                                        /*" -1516- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1517- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                        /*" -1518- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1519- DISPLAY '*  MOEDA SOLICITADA NAO CADASTRADA      *' */
                                        _.Display($"*  MOEDA SOLICITADA NAO CADASTRADA      *");

                                        /*" -1520- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1521- DISPLAY '* CODIGO DA MOEDA ....... ' V1RELA-CODUNIMO */
                                        _.Display($"* CODIGO DA MOEDA ....... {V1RELA_CODUNIMO}");

                                        /*" -1522- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1523- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1524- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1526- IF WCH-FINAL EQUAL 'I' OR 'G' OR 'H' OR 'J' */

                                        if (AREA_DE_WORK.WCH_FINAL.In("I", "G", "H", "J"))
                                        {

                                            /*" -1527- DISPLAY '*****************************************' */
                                            _.Display($"*****************************************");

                                            /*" -1528- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1529- DISPLAY '*      ==>     SI0808B      <==         *' */
                                            _.Display($"*      ==>     SI0808B      <==         *");

                                            /*" -1530- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1531- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                            _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                            /*" -1532- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1533- DISPLAY '*  COTACAO PARA A DATA DO SISTEMA       *' */
                                            _.Display($"*  COTACAO PARA A DATA DO SISTEMA       *");

                                            /*" -1534- DISPLAY '*  NAO CADASTRADA                       *' */
                                            _.Display($"*  NAO CADASTRADA                       *");

                                            /*" -1535- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1536- DISPLAY '* CODIGO DA MOEDA ....... ' WHOST-CODUNIMO */
                                            _.Display($"* CODIGO DA MOEDA ....... {WHOST_CODUNIMO}");

                                            /*" -1537- DISPLAY '* DATA DA MOEDA   ....... ' WHOST-DTINIVIG */
                                            _.Display($"* DATA DA MOEDA   ....... {WHOST_DTINIVIG}");

                                            /*" -1538- DISPLAY '* WCH-FINAL       ....... ' WCH-FINAL */
                                            _.Display($"* WCH-FINAL       ....... {AREA_DE_WORK.WCH_FINAL}");

                                            /*" -1539- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1541- DISPLAY '*****************************************' . */
                                            _.Display($"*****************************************");
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1542- IF WCH-FINAL NOT EQUAL 'C' */

            if (AREA_DE_WORK.WCH_FINAL != "C")
            {

                /*" -1543- CLOSE RSI0808B */
                RSI0808B.Close();

                /*" -1544- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1544- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ENCERRA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1555- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1556- DISPLAY ' ' */
                _.Display($" ");

                /*" -1557- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1558- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0808B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0808B  *");

                /*" -1559- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1560- DISPLAY ' ' */
                _.Display($" ");

                /*" -1561- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -1562- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1563- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLCODE1);

                /*" -1564- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLCODE2);

                /*" -1565- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE3);

                /*" -1567- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.WABEND);
            }


            /*" -1568- IF W-ARQUIVO-ABERTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_ARQUIVO_ABERTO == "SIM")
            {

                /*" -1569- CLOSE RSI0808B. */
                RSI0808B.Close();
            }


            /*" -1569- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1570- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1572- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1572- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}