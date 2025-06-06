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
using Sias.Sinistro.DB2.SI0807B;

namespace Code
{
    public class SI0807B
    {
        public bool IsCall { get; set; }

        public SI0807B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0807B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JUNHO / 1995                        *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            RELACAO DOS SINISTROS AVISADOS      *      */
        /*"      *                            SEM QUALQUER PAGAMENTO              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * MESTRE DE SINISTRO                 V0MESTSINI        INPUT     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      * ALTERACAO BARAN 27/01/97 : NAO LER MAIS V0APOLICE E NAO RODAR         */
        /*"      *                            MAIS POR RAMO, APENAS POR APOLICE.         */
        /*"      *                            E O ACESSO A SEGURAVG                      */
        /*"      * ALTERACAO RILDO SICO - 26/09/2000 : INCLUSAO DA VIEW DE OPERA- *      */
        /*"      *                            COES - V0SINI_OPER_FUNCAO           *      */
        /*"      *                            PROCURAR RS001                      *      */
        /*"      * ALTERACAO RILDO SICO - 16/10/2001 : MUDANCA PARA GERAR ARQUIVO *      */
        /*"      *                            PROCURAR RS002                      *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                       */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 03/05/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0807B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0807B
        {
            get
            {
                _.Move(REG_SI0807B, _RSI0807B); VarBasis.RedefinePassValue(REG_SI0807B, _RSI0807B, REG_SI0807B); return _RSI0807B;
            }
        }
        /*"01                  REG-SI0807B.*/
        public SI0807B_REG_SI0807B REG_SI0807B { get; set; } = new SI0807B_REG_SI0807B();
        public class SI0807B_REG_SI0807B : VarBasis
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
        /*"77         V1RELA-RAMO         PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-NUM-APOL     PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis V1RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
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
        /*"77   V0MEST-NUM-APOL        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
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
        /*"77      V0HIST-NUM-APOL-SINI  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HIST_NUM_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77      V0HIST-OCORHIST       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      V0HIST-OPERACAO       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      V0HIST-DTMOVTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77      V0HIST-VAL-OPER       PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V0HIST_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77      V0HIST-SITUACAO       PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77      W-COUNT-V0HISTSINI    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis W_COUNT_V0HISTSINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SEGU-NUM-APOLICE PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V1SEGU_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SEGU-CODCLIEN    PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1SEGU_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SEGU-NRCERTIF    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V1SEGU_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01           AREA-DE-WORK.*/
        public SI0807B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0807B_AREA_DE_WORK();
        public class SI0807B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  WCH-FINAL         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05  W-ARQUIVO-ABERTO  PIC  X(003)      VALUE SPACES.*/
            public StringBasis W_ARQUIVO_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-V0MESTSINI   PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V0MESTSINI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WTEM-V0MESTSINI   PIC  X(003)      VALUE SPACES.*/
            public StringBasis WTEM_V0MESTSINI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-V0HISTSINI   PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V0HISTSINI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-V1RELATOR    PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05       W-AC-LINHAS         PIC  9(002)      VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05       W-AC-PAGINA         PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         CH-CHAVE-ATU.*/
            public SI0807B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new SI0807B_CH_CHAVE_ATU();
            public class SI0807B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10 W-APOLICE-ANT           PIC S9(013)      VALUE  +0 COMP-3*/
                public IntBasis W_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10       CH-NRCERTIF-ATU   PIC S9(015)      VALUE  +0 COMP-3*/
                public IntBasis CH_NRCERTIF_ATU { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"    10       CH-SITUACAO-ATU   PIC  X(001)      VALUE  SPACES.*/
                public StringBasis CH_SITUACAO_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05  W-AC-AVISADO             PIC S9(013)V9(5) VALUE +0  COMP-3*/
            }
            public DoubleBasis W_AC_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TRANSF-VAL-OPERACAO    PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TRANSF_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-APOLICE            PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL              PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-COTACAO-HOJE           PIC S9(006)V9(09) VALUE +0 COMP-3*/
            public DoubleBasis W_COTACAO_HOJE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
            /*"  05  W-TIPO-SOL-RAMO.*/
            public SI0807B_W_TIPO_SOL_RAMO W_TIPO_SOL_RAMO { get; set; } = new SI0807B_W_TIPO_SOL_RAMO();
            public class SI0807B_W_TIPO_SOL_RAMO : VarBasis
            {
                /*"      10  FILLER               PIC X(06)        VALUE                               'RAMO: '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"RAMO: ");
                /*"      10  W-TIPO-SOL-RAMO-RAMO PIC 9(02)        VALUE ZEROS.*/
                public IntBasis W_TIPO_SOL_RAMO_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05  W-TIPO-SOL-APOL.*/
            }
            public SI0807B_W_TIPO_SOL_APOL W_TIPO_SOL_APOL { get; set; } = new SI0807B_W_TIPO_SOL_APOL();
            public class SI0807B_W_TIPO_SOL_APOL : VarBasis
            {
                /*"      10  FILLER               PIC X(09)        VALUE                               'APOLICE: '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"APOLICE: ");
                /*"      10  W-TIPO-SOL-APOL-APOL PIC X(13)        VALUE ZEROS.*/
                public StringBasis W_TIPO_SOL_APOL_APOL { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"  05         WDATA-CURR.*/
            }
            public SI0807B_WDATA_CURR WDATA_CURR { get; set; } = new SI0807B_WDATA_CURR();
            public class SI0807B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-CURR.*/
            }
            public SI0807B_WHORA_CURR WHORA_CURR { get; set; } = new SI0807B_WHORA_CURR();
            public class SI0807B_WHORA_CURR : VarBasis
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
            public SI0807B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0807B_WDATA_CABEC();
            public class SI0807B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public SI0807B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0807B_WHORA_CABEC();
            public class SI0807B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public SI0807B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new SI0807B_WDATA_VIGENCIA();
            public class SI0807B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-DTMOVTO.*/
            }
            public SI0807B_WDATA_DTMOVTO WDATA_DTMOVTO { get; set; } = new SI0807B_WDATA_DTMOVTO();
            public class SI0807B_WDATA_DTMOVTO : VarBasis
            {
                /*"    10       WDATA-MOV-ANO     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_MOV_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MOV-MES     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MOV_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MOV-DIA     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MOV_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WABEND.*/
            public SI0807B_WABEND WABEND { get; set; } = new SI0807B_WABEND();
            public class SI0807B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0806B'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0806B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05            LC01.*/
            }
            public SI0807B_LC01 LC01 { get; set; } = new SI0807B_LC01();
            public class SI0807B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATOR   PIC  X(010) VALUE 'SI0807B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0807B.1");
                /*"    10          FILLER         PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          LC01-EMPRESA   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER         PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER         PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA    PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public SI0807B_LC02 LC02 { get; set; } = new SI0807B_LC02();
            public class SI0807B_LC02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(010) VALUE  'SI0807B.1'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0807B.1");
                /*"    10 FILLER                  PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(032) VALUE      'APURACAO DOS EXCEDENTES TECNICOS'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"APURACAO DOS EXCEDENTES TECNICOS");
                /*"    10          FILLER         PIC  X(038) VALUE  SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"    10 FILLER                  PIC  X(005) VALUE ';;;;'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @";;;;");
                /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public SI0807B_LC03 LC03 { get; set; } = new SI0807B_LC03();
            public class SI0807B_LC03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(046) VALUE        'SINISTROS AVISADOS SEM PAGAMENTO NO PERIODO - '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"SINISTROS AVISADOS SEM PAGAMENTO NO PERIODO - ");
                /*"    10          LC03-DIA-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-INI   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10          LC03-DIA-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-TER   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10 FILLER                  PIC  X(005) VALUE ';;;;;'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @";;;;;");
                /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public SI0807B_LC04 LC04 { get; set; } = new SI0807B_LC04();
            public class SI0807B_LC04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(010) VALUE    'USUARIO - '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"USUARIO - ");
                /*"    10          LC02-CODUSU    PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC02_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(002) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          FILLER         PIC  X(019) VALUE    'DATA SOLICITACAO - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DATA SOLICITACAO - ");
                /*"    10          LC04-DIA-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_DIA_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-MES-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_MES_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-ANO-SOL   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC04_ANO_SOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10 FILLER                  PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          LC04-TIPO-SOL  PIC  X(029) VALUE  SPACES.*/
                public StringBasis LC04_TIPO_SOL { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    10 FILLER                  PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(006) VALUE                               'MOEDA '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"MOEDA ");
                /*"    10          LC04-MOEDA     PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_MOEDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC05.*/
            }
            public SI0807B_LC05 LC05 { get; set; } = new SI0807B_LC05();
            public class SI0807B_LC05 : VarBasis
            {
                /*"    10          FILLER         PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC06.*/
            }
            public SI0807B_LC06 LC06 { get; set; } = new SI0807B_LC06();
            public class SI0807B_LC06 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER         PIC  X(013) VALUE 'APOLICE'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(040) VALUE 'SEGURADO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(013) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(010) VALUE 'DT AVISO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT AVISO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(018) VALUE                                    '       VALOR AVISO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"       VALOR AVISO");
                /*"  05            LD01.*/
            }
            public SI0807B_LD01 LD01 { get; set; } = new SI0807B_LD01();
            public class SI0807B_LD01 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-APOLICE   PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NOME      PIC  X(040) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NUM-SINI  PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_NUM_SINI { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-DIAAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIAAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MESAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_MESAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANOAV     PIC   9999  BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANOAV { get; set; } = new IntBasis(new PIC("9", "4", "9999"));
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLAVISO   PIC  --------.--9,99999.*/
                public DoubleBasis LD01_VLAVISO { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V99999."), 5);
                /*"  05            LD02.*/
            }
            public SI0807B_LD02 LD02 { get; set; } = new SI0807B_LD02();
            public class SI0807B_LD02 : VarBasis
            {
                /*"    10          FILLER         PIC  X(040) VALUE                'TOTAL APOLICE  ...............'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL APOLICE  ...............");
                /*"    10 FILLER                  PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          LD02-TOT-APO   PIC  --------.--9,99999.*/
                public DoubleBasis LD02_TOT_APO { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V99999."), 5);
                /*"  05            LD03.*/
            }
            public SI0807B_LD03 LD03 { get; set; } = new SI0807B_LD03();
            public class SI0807B_LD03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(040) VALUE                'TOTAL GERAL ..................'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL GERAL ..................");
                /*"    10 FILLER                  PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          LD03-TOT-GERAL PIC  --------.--9,99999.*/
                public DoubleBasis LD03_TOT_GERAL { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V99999."), 5);
                /*"  05            LD04.*/
            }
            public SI0807B_LD04 LD04 { get; set; } = new SI0807B_LD04();
            public class SI0807B_LD04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(056) VALUE    '** DEBITAR O TOTAL GERAL DO VALOR AVISADO DA APURACAO **'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"** DEBITAR O TOTAL GERAL DO VALOR AVISADO DA APURACAO **");
                /*"    10          FILLER         PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"01          LK-LINK.*/
            }
        }
        public SI0807B_LK_LINK LK_LINK { get; set; } = new SI0807B_LK_LINK();
        public class SI0807B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public SI0807B_V1RELATORIOS V1RELATORIOS { get; set; } = new SI0807B_V1RELATORIOS();
        public SI0807B_V0MESTSINI V0MESTSINI { get; set; } = new SI0807B_V0MESTSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0807B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0807B.SetFile(RSI0807B_FILE_NAME_P);

                /*" -471- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -472- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -475- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -478- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -478- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -488- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -489- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -490- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -491- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -493- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -494- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -498- OPEN OUTPUT RSI0807B */
            RSI0807B.Open(REG_SI0807B);

            /*" -500- PERFORM 0000-00-DECLARE-V1RELATORIOS. */

            M_0000_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -501- MOVE 'NAO' TO WFIM-V1RELATOR. */
            _.Move("NAO", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -503- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

            /*" -505- MOVE 'NAO' TO W-ARQUIVO-ABERTO. */
            _.Move("NAO", AREA_DE_WORK.W_ARQUIVO_ABERTO);

            /*" -506- IF WFIM-V1RELATOR EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V1RELATOR == "SIM")
            {

                /*" -507- MOVE 'A' TO WCH-FINAL */
                _.Move("A", AREA_DE_WORK.WCH_FINAL);

                /*" -508- GO TO 0000-00-ENCERRA */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;

                /*" -509- ELSE */
            }
            else
            {


                /*" -511- MOVE 'SIM' TO W-ARQUIVO-ABERTO. */
                _.Move("SIM", AREA_DE_WORK.W_ARQUIVO_ABERTO);
            }


            /*" -513- PERFORM 0000-00-ACESSA-V1SISTEMA */

            M_0000_00_ACESSA_V1SISTEMA_SECTION();

            /*" -514- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -515- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -516- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -517- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -519- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -522- PERFORM 0000-00-PROCESSA-V1RELATORIO UNTIL WFIM-V1RELATOR EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_V1RELATOR == "SIM"))
            {

                M_0000_00_PROCESSA_V1RELATORIO_SECTION();
            }

            /*" -524- PERFORM 0000-00-DELETE-V1RELATORIOS. */

            M_0000_00_DELETE_V1RELATORIOS_SECTION();

            /*" -525- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -525- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -528- DISPLAY 'ERRO ACESSO COMMIT' */
                _.Display($"ERRO ACESSO COMMIT");

                /*" -530- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -532- MOVE SPACES TO WCH-FINAL. */
            _.Move("", AREA_DE_WORK.WCH_FINAL);

            /*" -532- GO TO 0000-00-ENCERRA. */

            M_0000_00_ENCERRA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_PRINCIPAL*/

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-SECTION */
        private void M_0000_00_ACESSA_V1SISTEMA_SECTION()
        {
            /*" -541- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -546- PERFORM M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1 */

            M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();

            /*" -549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -550- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -551- MOVE 'B' TO WCH-FINAL */
                    _.Move("B", AREA_DE_WORK.WCH_FINAL);

                    /*" -552- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -553- ELSE */
                }
                else
                {


                    /*" -554- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -556- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -557- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -558- MOVE V1SIST-DTMOVABE TO WHOST-DTINIVIG. */
            _.Move(V1SIST_DTMOVABE, WHOST_DTINIVIG);

            /*" -560- MOVE 'G' TO WCH-FINAL. */
            _.Move("G", AREA_DE_WORK.WCH_FINAL);

            /*" -562- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -562- MOVE V1MOED-VLCRUZAD TO W-COTACAO-HOJE. */
            _.Move(V1MOED_VLCRUZAD, AREA_DE_WORK.W_COTACAO_HOJE);

        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1()
        {
            /*" -546- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -572- MOVE ZEROS TO W-AC-PAGINA. */
            _.Move(0, AREA_DE_WORK.W_AC_PAGINA);

            /*" -581- MOVE 80 TO W-AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.W_AC_LINHAS);

            /*" -583- MOVE ZEROS TO V0MEST-NUM-APOL-I V0MEST-RAMO-I. */
            _.Move(0, V0MEST_NUM_APOL_I, V0MEST_RAMO_I);

            /*" -584- MOVE 9999999999999 TO V0MEST-NUM-APOL-F. */
            _.Move(9999999999999, V0MEST_NUM_APOL_F);

            /*" -586- MOVE 99 TO V0MEST-RAMO-F. */
            _.Move(99, V0MEST_RAMO_F);

            /*" -587- IF V1RELA-RAMO NOT EQUAL ZEROS */

            if (V1RELA_RAMO != 00)
            {

                /*" -589- MOVE V1RELA-RAMO TO V0MEST-RAMO-I V0MEST-RAMO-F */
                _.Move(V1RELA_RAMO, V0MEST_RAMO_I, V0MEST_RAMO_F);

                /*" -590- ELSE */
            }
            else
            {


                /*" -591- IF V1RELA-NUM-APOL NOT EQUAL ZEROS */

                if (V1RELA_NUM_APOL != 00)
                {

                    /*" -594- MOVE V1RELA-NUM-APOL TO V0MEST-NUM-APOL-I V0MEST-NUM-APOL-F. */
                    _.Move(V1RELA_NUM_APOL, V0MEST_NUM_APOL_I, V0MEST_NUM_APOL_F);
                }

            }


            /*" -596- PERFORM 0000-00-PREPARA-CABECALHO. */

            M_0000_00_PREPARA_CABECALHO_SECTION();

            /*" -598- PERFORM 0000-00-DECLARE-V0MESTSINI. */

            M_0000_00_DECLARE_V0MESTSINI_SECTION();

            /*" -600- MOVE 'NAO' TO WFIM-V0MESTSINI WTEM-V0MESTSINI. */
            _.Move("NAO", AREA_DE_WORK.WFIM_V0MESTSINI, AREA_DE_WORK.WTEM_V0MESTSINI);

            /*" -602- PERFORM 0000-00-FETCH-V0MESTSINI. */

            M_0000_00_FETCH_V0MESTSINI_SECTION();

            /*" -603- IF WFIM-V0MESTSINI EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V0MESTSINI == "SIM")
            {

                /*" -604- MOVE 'C' TO WCH-FINAL */
                _.Move("C", AREA_DE_WORK.WCH_FINAL);

                /*" -605- PERFORM 0000-00-ENCERRA */

                M_0000_00_ENCERRA_SECTION();

                /*" -606- GO TO 0000-01-LER-NOVO-V1RELATORIO */

                M_0000_01_LER_NOVO_V1RELATORIO(); //GOTO
                return;

                /*" -607- ELSE */
            }
            else
            {


                /*" -609- MOVE 'SIM' TO WTEM-V0MESTSINI. */
                _.Move("SIM", AREA_DE_WORK.WTEM_V0MESTSINI);
            }


            /*" -611- MOVE ZEROS TO W-TOT-GERAL W-APOLICE-ANT. */
            _.Move(0, AREA_DE_WORK.W_TOT_GERAL, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);

            /*" -613- PERFORM 0000-00-MONTA-CABECALHO */

            M_0000_00_MONTA_CABECALHO_SECTION();

            /*" -616- PERFORM 0000-00-PROCESSA-V0MESTSINI UNTIL WFIM-V0MESTSINI EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_V0MESTSINI == "SIM"))
            {

                M_0000_00_PROCESSA_V0MESTSINI_SECTION();
            }

            /*" -616- PERFORM 0000-00-TOTAL-RELATORIO. */

            M_0000_00_TOTAL_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0000_01_LER_NOVO_V1RELATORIO */

            M_0000_01_LER_NOVO_V1RELATORIO();

        }

        [StopWatch]
        /*" M-0000-01-LER-NOVO-V1RELATORIO */
        private void M_0000_01_LER_NOVO_V1RELATORIO(bool isPerform = false)
        {
            /*" -622- PERFORM 0000-00-CLOSE-V0MESTSINI. */

            M_0000_00_CLOSE_V0MESTSINI_SECTION();

            /*" -622- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V1RELATORIO*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-V0MESTSINI-SECTION */
        private void M_0000_00_PROCESSA_V0MESTSINI_SECTION()
        {
            /*" -630- MOVE ZEROS TO W-COUNT-V0HISTSINI. */
            _.Move(0, W_COUNT_V0HISTSINI);

            /*" -631- PERFORM 0000-00-SELECT-V0HISTSINI. */

            M_0000_00_SELECT_V0HISTSINI_SECTION();

            /*" -632- IF W-COUNT-V0HISTSINI NOT EQUAL ZERO */

            if (W_COUNT_V0HISTSINI != 00)
            {

                /*" -634- GO TO 0000-LER-V0MESTSINI. */

                M_0000_LER_V0MESTSINI(); //GOTO
                return;
            }


            /*" -638- MOVE ZEROS TO W-AC-AVISADO. */
            _.Move(0, AREA_DE_WORK.W_AC_AVISADO);

            /*" -640- PERFORM 0000-00-OBTEM-VALOR-AVISADO. */

            M_0000_00_OBTEM_VALOR_AVISADO_SECTION();

            /*" -640- PERFORM 0000-00-IMPRIME-REGISTRO. */

            M_0000_00_IMPRIME_REGISTRO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0000_LER_V0MESTSINI */

            M_0000_LER_V0MESTSINI();

        }

        [StopWatch]
        /*" M-0000-LER-V0MESTSINI */
        private void M_0000_LER_V0MESTSINI(bool isPerform = false)
        {
            /*" -646- PERFORM 0000-00-FETCH-V0MESTSINI. */

            M_0000_00_FETCH_V0MESTSINI_SECTION();

            /*" -647- IF WFIM-V0MESTSINI EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V0MESTSINI == "SIM")
            {

                /*" -648- PERFORM 0000-00-TOTAL-APOLICE */

                M_0000_00_TOTAL_APOLICE_SECTION();

                /*" -648- MOVE ZEROS TO W-TOT-APOLICE. */
                _.Move(0, AREA_DE_WORK.W_TOT_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V0MESTSINI*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-REGISTRO-SECTION */
        private void M_0000_00_IMPRIME_REGISTRO_SECTION()
        {
            /*" -659- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -660- MOVE V0MEST-NUM-APOL TO LD01-APOLICE */
            _.Move(V0MEST_NUM_APOL, AREA_DE_WORK.LD01.LD01_APOLICE);

            /*" -664- MOVE V0MEST-NUM-APOL TO W-APOLICE-ANT */
            _.Move(V0MEST_NUM_APOL, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);

            /*" -666- IF V0MEST-RAMO EQUAL 97 OR 93 OR 81 OR 80 OR 81 OR 91 */

            if (V0MEST_RAMO.In("97", "93", "81", "80", "81", "91"))
            {

                /*" -667- MOVE V0MEST-NUM-APOL TO V1SEGU-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOL, V1SEGU_NUM_APOLICE);

                /*" -668- MOVE V0MEST-NRCERTIF TO V1SEGU-NRCERTIF */
                _.Move(V0MEST_NRCERTIF, V1SEGU_NRCERTIF);

                /*" -669- PERFORM 0000-00-SELECT-V1SEGURAVG */

                M_0000_00_SELECT_V1SEGURAVG_SECTION();

                /*" -670- MOVE V1SEGU-CODCLIEN TO WHOST-CODCLIEN */
                _.Move(V1SEGU_CODCLIEN, WHOST_CODCLIEN);

                /*" -671- ELSE */
            }
            else
            {


                /*" -672- MOVE V0MEST-NUM-APOL TO V1APOL-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOL, V1APOL_NUM_APOLICE);

                /*" -673- PERFORM 0000-00-SELECT-V1APOLICE */

                M_0000_00_SELECT_V1APOLICE_SECTION();

                /*" -675- MOVE V1APOL-CODCLIEN TO WHOST-CODCLIEN. */
                _.Move(V1APOL_CODCLIEN, WHOST_CODCLIEN);
            }


            /*" -676- IF WHOST-CODCLIEN EQUAL ZEROS */

            if (WHOST_CODCLIEN == 00)
            {

                /*" -677- MOVE '* CLIENTE  N A O  CADASTRADO *' TO LD01-NOME */
                _.Move("* CLIENTE  N A O  CADASTRADO *", AREA_DE_WORK.LD01.LD01_NOME);

                /*" -678- ELSE */
            }
            else
            {


                /*" -679- PERFORM 0000-00-SELECT-V1CLIENTE */

                M_0000_00_SELECT_V1CLIENTE_SECTION();

                /*" -681- MOVE V1CLIE-NOME TO LD01-NOME. */
                _.Move(V1CLIE_NOME, AREA_DE_WORK.LD01.LD01_NOME);
            }


            /*" -682- MOVE V0MEST-NUM-APOL-SINI TO LD01-NUM-SINI. */
            _.Move(V0MEST_NUM_APOL_SINI, AREA_DE_WORK.LD01.LD01_NUM_SINI);

            /*" -683- MOVE V0MEST-DATCMD TO WDATA-VIGENCIA */
            _.Move(V0MEST_DATCMD, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -684- MOVE WDATA-VIG-DIA TO LD01-DIAAV */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIAAV);

            /*" -685- MOVE WDATA-VIG-MES TO LD01-MESAV */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MESAV);

            /*" -691- MOVE WDATA-VIG-ANO TO LD01-ANOAV */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANOAV);

            /*" -693- MOVE W-AC-AVISADO TO LD01-VLAVISO */
            _.Move(AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.LD01.LD01_VLAVISO);

            /*" -700- ADD W-AC-AVISADO TO W-TOT-APOLICE W-TOT-GERAL. */
            AREA_DE_WORK.W_TOT_APOLICE.Value = AREA_DE_WORK.W_TOT_APOLICE + AREA_DE_WORK.W_AC_AVISADO;
            AREA_DE_WORK.W_TOT_GERAL.Value = AREA_DE_WORK.W_TOT_GERAL + AREA_DE_WORK.W_AC_AVISADO;

            /*" -701- WRITE REG-SI0807B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

            /*" -701- ADD 1 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_REGISTRO*/

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-SECTION */
        private void M_0000_00_PREPARA_CABECALHO_SECTION()
        {
            /*" -713- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -717- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_1 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_1();

            /*" -720- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -721- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -722- MOVE 'D' TO WCH-FINAL */
                    _.Move("D", AREA_DE_WORK.WCH_FINAL);

                    /*" -723- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -724- ELSE */
                }
                else
                {


                    /*" -725- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -727- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -728- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -730- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -731- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -732- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -733- ELSE */
            }
            else
            {


                /*" -734- MOVE 'E' TO WCH-FINAL */
                _.Move("E", AREA_DE_WORK.WCH_FINAL);

                /*" -736- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -738- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -742- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_2 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_2();

            /*" -745- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -746- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -747- MOVE 'F' TO WCH-FINAL */
                    _.Move("F", AREA_DE_WORK.WCH_FINAL);

                    /*" -748- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -749- ELSE */
                }
                else
                {


                    /*" -750- DISPLAY 'PROBLEMAS ACESSO V0MOEDA' */
                    _.Display($"PROBLEMAS ACESSO V0MOEDA");

                    /*" -752- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -754- MOVE V1RELA-CODUSU TO LC02-CODUSU. */
            _.Move(V1RELA_CODUSU, AREA_DE_WORK.LC04.LC02_CODUSU);

            /*" -756- MOVE V0MOED-SIGLUNIM TO LC04-MOEDA. */
            _.Move(V0MOED_SIGLUNIM, AREA_DE_WORK.LC04.LC04_MOEDA);

            /*" -757- MOVE V1RELA-PERI-INI TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_INI, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -758- MOVE WDATA-VIG-DIA TO LC03-DIA-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_INI);

            /*" -759- MOVE WDATA-VIG-MES TO LC03-MES-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_INI);

            /*" -761- MOVE WDATA-VIG-ANO TO LC03-ANO-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_INI);

            /*" -762- MOVE V1RELA-PERI-FIM TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_FIM, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -763- MOVE WDATA-VIG-DIA TO LC03-DIA-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_TER);

            /*" -764- MOVE WDATA-VIG-MES TO LC03-MES-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_TER);

            /*" -766- MOVE WDATA-VIG-ANO TO LC03-ANO-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_TER);

            /*" -767- MOVE V1RELA-DT-SOLICITA TO WDATA-VIGENCIA */
            _.Move(V1RELA_DT_SOLICITA, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -768- MOVE WDATA-VIG-DIA TO LC04-DIA-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC04.LC04_DIA_SOL);

            /*" -769- MOVE WDATA-VIG-MES TO LC04-MES-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC04.LC04_MES_SOL);

            /*" -771- MOVE WDATA-VIG-ANO TO LC04-ANO-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC04.LC04_ANO_SOL);

            /*" -772- IF V1RELA-RAMO NOT EQUAL ZEROS */

            if (V1RELA_RAMO != 00)
            {

                /*" -773- MOVE V1RELA-RAMO TO W-TIPO-SOL-RAMO-RAMO */
                _.Move(V1RELA_RAMO, AREA_DE_WORK.W_TIPO_SOL_RAMO.W_TIPO_SOL_RAMO_RAMO);

                /*" -774- MOVE W-TIPO-SOL-RAMO TO LC04-TIPO-SOL */
                _.Move(AREA_DE_WORK.W_TIPO_SOL_RAMO, AREA_DE_WORK.LC04.LC04_TIPO_SOL);

                /*" -775- ELSE */
            }
            else
            {


                /*" -776- IF V1RELA-NUM-APOL NOT EQUAL ZEROS */

                if (V1RELA_NUM_APOL != 00)
                {

                    /*" -777- MOVE V1RELA-NUM-APOL TO W-TIPO-SOL-APOL-APOL */
                    _.Move(V1RELA_NUM_APOL, AREA_DE_WORK.W_TIPO_SOL_APOL.W_TIPO_SOL_APOL_APOL);

                    /*" -777- MOVE W-TIPO-SOL-APOL TO LC04-TIPO-SOL . */
                    _.Move(AREA_DE_WORK.W_TIPO_SOL_APOL, AREA_DE_WORK.LC04.LC04_TIPO_SOL);
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-DB-SELECT-1 */
        public void M_0000_00_PREPARA_CABECALHO_DB_SELECT_1()
        {
            /*" -717- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -742- EXEC SQL SELECT SIGLUNIM INTO :V0MOED-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO END-EXEC. */

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
            /*" -788- ADD 1 TO W-AC-PAGINA */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -791- MOVE W-AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.W_AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -792- WRITE REG-SI0807B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

            /*" -793- WRITE REG-SI0807B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

            /*" -794- WRITE REG-SI0807B FROM LC04 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

            /*" -794- WRITE REG-SI0807B FROM LC06. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_MONTA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-SECTION */
        private void M_0000_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -805- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -810- PERFORM M_0000_00_SELECT_V1APOLICE_DB_SELECT_1 */

            M_0000_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -814- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -815- MOVE ZEROS TO V1APOL-CODCLIEN */
                    _.Move(0, V1APOL_CODCLIEN);

                    /*" -816- ELSE */
                }
                else
                {


                    /*" -817- DISPLAY 'ERRO ACESSO V1APOLICE' */
                    _.Display($"ERRO ACESSO V1APOLICE");

                    /*" -817- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -810- EXEC SQL SELECT CODCLIEN INTO :V1APOL-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1APOL-NUM-APOLICE END-EXEC. */

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
            /*" -828- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -836- PERFORM M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -840- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -841- MOVE ZEROS TO V1SEGU-CODCLIEN */
                    _.Move(0, V1SEGU_CODCLIEN);

                    /*" -842- ELSE */
                }
                else
                {


                    /*" -843- DISPLAY 'ERRO ACESSO V1SUBGRUPO' */
                    _.Display($"ERRO ACESSO V1SUBGRUPO");

                    /*" -843- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -836- EXEC SQL SELECT COD_CLIENTE INTO :V1SEGU-CODCLIEN FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :V1SEGU-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

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
            /*" -853- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -858- PERFORM M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -861- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -862- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -863- MOVE 'SEGURADO NAO CADASTRADO' TO V1CLIE-NOME */
                    _.Move("SEGURADO NAO CADASTRADO", V1CLIE_NOME);

                    /*" -864- ELSE */
                }
                else
                {


                    /*" -865- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -865- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -858- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

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
            /*" -875- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -882- PERFORM M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1 */

            M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1();

            /*" -885- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -886- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -887- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -888- ELSE */
                }
                else
                {


                    /*" -889- DISPLAY 'PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -889- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1()
        {
            /*" -882- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-CODUNIMO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

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
            /*" -901- MOVE W-TOT-APOLICE TO LD02-TOT-APO. */
            _.Move(AREA_DE_WORK.W_TOT_APOLICE, AREA_DE_WORK.LD02.LD02_TOT_APO);

            /*" -901- WRITE REG-SI0807B FROM LD02. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_APOLICE*/

        [StopWatch]
        /*" M-0000-00-TOTAL-RELATORIO-SECTION */
        private void M_0000_00_TOTAL_RELATORIO_SECTION()
        {
            /*" -913- MOVE W-TOT-GERAL TO LD03-TOT-GERAL. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL, AREA_DE_WORK.LD03.LD03_TOT_GERAL);

            /*" -914- WRITE REG-SI0807B FROM LD03 */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

            /*" -914- WRITE REG-SI0807B FROM LD04. */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_SI0807B);

            RSI0807B.Write(REG_SI0807B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_RELATORIO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -925- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -937- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -939- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -943- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -943- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -937- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT RAMO , NUM_APOLICE , CODUNIMO , PERI_INICIAL , PERI_FINAL , CODUSU , DATA_SOLICITACAO FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0807B' ORDER BY CODUSU, DATA_SOLICITACAO, PERI_INICIAL, RAMO,NUM_APOLICE END-EXEC. */
            V1RELATORIOS = new SI0807B_V1RELATORIOS(false);
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
							WHERE CODRELAT = 'SI0807B' 
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
            /*" -939- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V0MESTSINI-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V0MESTSINI_DB_DECLARE_1()
        {
            /*" -1018- EXEC SQL DECLARE V0MESTSINI CURSOR FOR SELECT NUM_APOLICE , RAMO , NUM_APOL_SINISTRO, NRCERTIF , SITUACAO , DATCMD FROM SEGUROS.V0MESTSINI WHERE NUM_APOLICE BETWEEN :V0MEST-NUM-APOL-I AND :V0MEST-NUM-APOL-F AND DATCMD BETWEEN :V1RELA-PERI-INI AND :V1RELA-PERI-FIM AND SITUACAO <> '2' ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            V0MESTSINI = new SI0807B_V0MESTSINI(true);
            string GetQuery_V0MESTSINI()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							RAMO
							, 
							NUM_APOL_SINISTRO
							, 
							NRCERTIF
							, 
							SITUACAO
							, 
							DATCMD 
							FROM SEGUROS.V0MESTSINI 
							WHERE NUM_APOLICE BETWEEN '{V0MEST_NUM_APOL_I}' 
							AND 
							'{V0MEST_NUM_APOL_F}' 
							AND DATCMD BETWEEN '{V1RELA_PERI_INI}' 
							AND 
							'{V1RELA_PERI_FIM}' 
							AND SITUACAO <> '2' 
							ORDER BY 
							NUM_APOL_SINISTRO";

                return query;
            }
            V0MESTSINI.GetQueryEvent += GetQuery_V0MESTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_V1RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-SECTION */
        private void M_0000_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -955- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -963- PERFORM M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -966- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -967- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -968- MOVE 'SIM' TO WFIM-V1RELATOR */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -969- ELSE */
                }
                else
                {


                    /*" -970- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -972- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -973- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -974- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -975- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -976- DISPLAY '*      ==>     SI0807B      <==         *' */
                _.Display($"*      ==>     SI0807B      <==         *");

                /*" -977- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -978- DISPLAY '*  DISPLAY DOS DADOS INFORMADOS PELO    *' */
                _.Display($"*  DOS DADOS INFORMADOS PELO    *");

                /*" -979- DISPLAY '*  USUARIO NA V1RELATORIOS              *' */
                _.Display($"*  USUARIO NA V1RELATORIOS              *");

                /*" -980- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -981- DISPLAY '* RAMO        ...... ' V1RELA-RAMO */
                _.Display($"* RAMO        ...... {V1RELA_RAMO}");

                /*" -982- DISPLAY '* NUM. APOL.  ...... ' V1RELA-NUM-APOL */
                _.Display($"* NUM. APOL.  ...... {V1RELA_NUM_APOL}");

                /*" -983- DISPLAY '* CODUNIMO    ...... ' V1RELA-CODUNIMO */
                _.Display($"* CODUNIMO    ...... {V1RELA_CODUNIMO}");

                /*" -984- DISPLAY '* PERI. INIC. ...... ' V1RELA-PERI-INI */
                _.Display($"* PERI. INIC. ...... {V1RELA_PERI_INI}");

                /*" -985- DISPLAY '* PERI. FIM   ...... ' V1RELA-PERI-FIM */
                _.Display($"* PERI. FIM   ...... {V1RELA_PERI_FIM}");

                /*" -986- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -986- DISPLAY '*****************************************' . */
                _.Display($"*****************************************");
            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -963- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-RAMO , :V1RELA-NUM-APOL , :V1RELA-CODUNIMO , :V1RELA-PERI-INI , :V1RELA-PERI-FIM , :V1RELA-CODUSU , :V1RELA-DT-SOLICITA END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_RAMO, V1RELA_RAMO);
                _.Move(V1RELATORIOS.V1RELA_NUM_APOL, V1RELA_NUM_APOL);
                _.Move(V1RELATORIOS.V1RELA_CODUNIMO, V1RELA_CODUNIMO);
                _.Move(V1RELATORIOS.V1RELA_PERI_INI, V1RELA_PERI_INI);
                _.Move(V1RELATORIOS.V1RELA_PERI_FIM, V1RELA_PERI_FIM);
                _.Move(V1RELATORIOS.V1RELA_CODUSU, V1RELA_CODUSU);
                _.Move(V1RELATORIOS.V1RELA_DT_SOLICITA, V1RELA_DT_SOLICITA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_V1RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V0MESTSINI-SECTION */
        private void M_0000_00_DECLARE_V0MESTSINI_SECTION()
        {
            /*" -997- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1018- PERFORM M_0000_00_DECLARE_V0MESTSINI_DB_DECLARE_1 */

            M_0000_00_DECLARE_V0MESTSINI_DB_DECLARE_1();

            /*" -1020- PERFORM M_0000_00_DECLARE_V0MESTSINI_DB_OPEN_1 */

            M_0000_00_DECLARE_V0MESTSINI_DB_OPEN_1();

            /*" -1023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1024- DISPLAY 'PROBLEMAS OPEN V0MESTSINI   ... ' */
                _.Display($"PROBLEMAS OPEN V0MESTSINI   ... ");

                /*" -1024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V0MESTSINI-DB-OPEN-1 */
        public void M_0000_00_DECLARE_V0MESTSINI_DB_OPEN_1()
        {
            /*" -1020- EXEC SQL OPEN V0MESTSINI END-EXEC. */

            V0MESTSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_V0MESTSINI*/

        [StopWatch]
        /*" M-0000-00-FETCH-V0MESTSINI-SECTION */
        private void M_0000_00_FETCH_V0MESTSINI_SECTION()
        {
            /*" -1033- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1042- PERFORM M_0000_00_FETCH_V0MESTSINI_DB_FETCH_1 */

            M_0000_00_FETCH_V0MESTSINI_DB_FETCH_1();

            /*" -1056- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1057- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1058- MOVE 'SIM' TO WFIM-V0MESTSINI */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V0MESTSINI);

                    /*" -1059- ELSE */
                }
                else
                {


                    /*" -1060- DISPLAY 'PROBLEMAS NO FETCH DA V0MESTSINI' */
                    _.Display($"PROBLEMAS NO FETCH DA V0MESTSINI");

                    /*" -1060- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V0MESTSINI-DB-FETCH-1 */
        public void M_0000_00_FETCH_V0MESTSINI_DB_FETCH_1()
        {
            /*" -1042- EXEC SQL FETCH V0MESTSINI INTO :V0MEST-NUM-APOL , :V0MEST-RAMO , :V0MEST-NUM-APOL-SINI, :V0MEST-NRCERTIF , :V0MEST-SITUACAO , :V0MEST-DATCMD END-EXEC. */

            if (V0MESTSINI.Fetch())
            {
                _.Move(V0MESTSINI.V0MEST_NUM_APOL, V0MEST_NUM_APOL);
                _.Move(V0MESTSINI.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(V0MESTSINI.V0MEST_NUM_APOL_SINI, V0MEST_NUM_APOL_SINI);
                _.Move(V0MESTSINI.V0MEST_NRCERTIF, V0MEST_NRCERTIF);
                _.Move(V0MESTSINI.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(V0MESTSINI.V0MEST_DATCMD, V0MEST_DATCMD);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_V0MESTSINI*/

        [StopWatch]
        /*" M-0000-00-CLOSE-V0MESTSINI-SECTION */
        private void M_0000_00_CLOSE_V0MESTSINI_SECTION()
        {
            /*" -1070- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1070- PERFORM M_0000_00_CLOSE_V0MESTSINI_DB_CLOSE_1 */

            M_0000_00_CLOSE_V0MESTSINI_DB_CLOSE_1();

            /*" -1073- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1074- DISPLAY 'PROBLEMAS CLOSE V0MESTSINI   ... ' */
                _.Display($"PROBLEMAS CLOSE V0MESTSINI   ... ");

                /*" -1074- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-V0MESTSINI-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_V0MESTSINI_DB_CLOSE_1()
        {
            /*" -1070- EXEC SQL CLOSE V0MESTSINI END-EXEC. */

            V0MESTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_V0MESTSINI*/

        [StopWatch]
        /*" M-0000-00-OBTEM-VALOR-AVISADO-SECTION */
        private void M_0000_00_OBTEM_VALOR_AVISADO_SECTION()
        {
            /*" -1084- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1086- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1088- MOVE V0MEST-NUM-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1090- CALL 'SI1003S' USING SI1001S-PARAMETROS */
            _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1091- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1093- DISPLAY 'PROBLEMA CALL SI1003S ' ' ' V0MEST-NUM-APOL-SINI */

                $"PROBLEMA CALL SI1003S  {V0MEST_NUM_APOL_SINI}"
                .Display();

                /*" -1094- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1095- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -1096- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1097- ELSE */
            }
            else
            {


                /*" -1097- MOVE SI1001S-VALOR-CALCULADO TO W-AC-AVISADO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.W_AC_AVISADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_OBTER_VALOR_AVISADO*/

        [StopWatch]
        /*" M-0000-00-SELECT-V0HISTSINI-SECTION */
        private void M_0000_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -1110- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1117- PERFORM M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -1121- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1122- DISPLAY 'PROBLEMAS SELECT COUNT PAGTO V0HISTSINI ...' */
                _.Display($"PROBLEMAS SELECT COUNT PAGTO V0HISTSINI ...");

                /*" -1122- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -1117- EXEC SQL SELECT COUNT(*) INTO :W-COUNT-V0HISTSINI FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINI AND OPERACAO IN (1001, 1002, 1003, 1009) AND SITUACAO <> '2' END-EXEC. */

            var m_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                V0MEST_NUM_APOL_SINI = V0MEST_NUM_APOL_SINI.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_COUNT_V0HISTSINI, W_COUNT_V0HISTSINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SELECT_V0HISTSINI*/

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V1RELATORIOS_SECTION()
        {
            /*" -1133- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1135- PERFORM M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1();

            /*" -1138- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1139- DISPLAY 'PROBLEMA DELETE V1RELATORIOS' */
                _.Display($"PROBLEMA DELETE V1RELATORIOS");

                /*" -1139- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -1135- EXEC SQL DELETE FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0807B' END-EXEC. */

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
            /*" -1151- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1152- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -1153- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1154- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1155- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1156- DISPLAY '//     ==>     SI0807B      <==        //' */
                _.Display($"//     ==>     SI0807B      <==        //");

                /*" -1157- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1158- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -1159- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1160- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1161- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1162- ELSE */
            }
            else
            {


                /*" -1163- IF WCH-FINAL EQUAL 'A' */

                if (AREA_DE_WORK.WCH_FINAL == "A")
                {

                    /*" -1164- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1165- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1166- DISPLAY '*      ==>     SI0807B      <==         *' */
                    _.Display($"*      ==>     SI0807B      <==         *");

                    /*" -1167- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1168- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                    _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                    /*" -1169- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1170- DISPLAY '*  NAO HOUVE SOLICITACAO PELO USUARIO,  *' */
                    _.Display($"*  NAO HOUVE SOLICITACAO PELO USUARIO,  *");

                    /*" -1171- DISPLAY '*  PARA EXECUCAO DO PROGRAMA SI0807B.   *' */
                    _.Display($"*  PARA EXECUCAO DO PROGRAMA SI0807B.   *");

                    /*" -1172- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1173- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1174- ELSE */
                }
                else
                {


                    /*" -1175- IF WCH-FINAL EQUAL 'B' */

                    if (AREA_DE_WORK.WCH_FINAL == "B")
                    {

                        /*" -1176- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1177- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1178- DISPLAY '*      ==>     SI0807B      <==         *' */
                        _.Display($"*      ==>     SI0807B      <==         *");

                        /*" -1179- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1180- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                        /*" -1181- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1182- DISPLAY '*  DATA DO SISTEMA NAO FOI ENCONTRADO   *' */
                        _.Display($"*  DATA DO SISTEMA NAO FOI ENCONTRADO   *");

                        /*" -1183- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1184- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1185- ELSE */
                    }
                    else
                    {


                        /*" -1186- IF WCH-FINAL EQUAL 'C' */

                        if (AREA_DE_WORK.WCH_FINAL == "C")
                        {

                            /*" -1187- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1188- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1189- DISPLAY '*      ==>     SI0807B      <==         *' */
                            _.Display($"*      ==>     SI0807B      <==         *");

                            /*" -1190- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1191- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                            _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                            /*" -1192- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1193- DISPLAY '*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*' */
                            _.Display($"*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*");

                            /*" -1194- DISPLAY '*  PARA OS PARAMETROS INFORMADOS.       *' */
                            _.Display($"*  PARA OS PARAMETROS INFORMADOS.       *");

                            /*" -1195- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1196- DISPLAY '*  RAMO   ............ ' V1RELA-RAMO */
                            _.Display($"*  RAMO   ............ {V1RELA_RAMO}");

                            /*" -1197- DISPLAY '*  APOLICE ........... ' V1RELA-NUM-APOL */
                            _.Display($"*  APOLICE ........... {V1RELA_NUM_APOL}");

                            /*" -1198- DISPLAY '*  PERIODO INCIAL .... ' V1RELA-PERI-INI */
                            _.Display($"*  PERIODO INCIAL .... {V1RELA_PERI_INI}");

                            /*" -1199- DISPLAY '*  PERIODO FINAL  .... ' V1RELA-PERI-FIM */
                            _.Display($"*  PERIODO FINAL  .... {V1RELA_PERI_FIM}");

                            /*" -1200- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1201- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1202- ELSE */
                        }
                        else
                        {


                            /*" -1203- IF WCH-FINAL EQUAL 'D' */

                            if (AREA_DE_WORK.WCH_FINAL == "D")
                            {

                                /*" -1204- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1205- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1206- DISPLAY '*      ==>     SI0807B      <==         *' */
                                _.Display($"*      ==>     SI0807B      <==         *");

                                /*" -1207- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1208- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                /*" -1209- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1210- DISPLAY '*       EMPRESA NAO CADASTRADA          *' */
                                _.Display($"*       EMPRESA NAO CADASTRADA          *");

                                /*" -1211- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1212- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1213- ELSE */
                            }
                            else
                            {


                                /*" -1214- IF WCH-FINAL EQUAL 'E' */

                                if (AREA_DE_WORK.WCH_FINAL == "E")
                                {

                                    /*" -1215- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1216- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1217- DISPLAY '*      ==>     SI0807B      <==         *' */
                                    _.Display($"*      ==>     SI0807B      <==         *");

                                    /*" -1218- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1219- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                    _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                    /*" -1220- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1221- DISPLAY '*  PROBLEMA NO LINK PARA A SUBROTINA    *' */
                                    _.Display($"*  PROBLEMA NO LINK PARA A SUBROTINA    *");

                                    /*" -1222- DISPLAY '*  PROALN01 PARA ACESSO AO NOME EMPRESA *' */
                                    _.Display($"*  PROALN01 PARA ACESSO AO NOME EMPRESA *");

                                    /*" -1223- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1224- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1225- ELSE */
                                }
                                else
                                {


                                    /*" -1226- IF WCH-FINAL EQUAL 'F' */

                                    if (AREA_DE_WORK.WCH_FINAL == "F")
                                    {

                                        /*" -1227- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1228- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1229- DISPLAY '*      ==>     SI0807B      <==         *' */
                                        _.Display($"*      ==>     SI0807B      <==         *");

                                        /*" -1230- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1231- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                        /*" -1232- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1233- DISPLAY '*  MOEDA SOLICITADA NAO CADASTRADA      *' */
                                        _.Display($"*  MOEDA SOLICITADA NAO CADASTRADA      *");

                                        /*" -1234- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1235- DISPLAY '* CODIGO DA MOEDA ....... ' V1RELA-CODUNIMO */
                                        _.Display($"* CODIGO DA MOEDA ....... {V1RELA_CODUNIMO}");

                                        /*" -1236- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1237- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1238- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1239- IF WCH-FINAL EQUAL 'G' OR 'H' */

                                        if (AREA_DE_WORK.WCH_FINAL.In("G", "H"))
                                        {

                                            /*" -1240- DISPLAY '*****************************************' */
                                            _.Display($"*****************************************");

                                            /*" -1241- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1242- DISPLAY '*      ==>     SI0807B      <==         *' */
                                            _.Display($"*      ==>     SI0807B      <==         *");

                                            /*" -1243- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1244- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                            _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                            /*" -1245- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1246- DISPLAY '*  COTACAO PARA A DATA DO SISTEMA       *' */
                                            _.Display($"*  COTACAO PARA A DATA DO SISTEMA       *");

                                            /*" -1247- DISPLAY '*  NAO CADASTRADA                       *' */
                                            _.Display($"*  NAO CADASTRADA                       *");

                                            /*" -1248- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1249- DISPLAY '* CODIGO DA MOEDA ....... ' WHOST-CODUNIMO */
                                            _.Display($"* CODIGO DA MOEDA ....... {WHOST_CODUNIMO}");

                                            /*" -1250- DISPLAY '* DATA DA MOEDA   ....... ' WHOST-DTINIVIG */
                                            _.Display($"* DATA DA MOEDA   ....... {WHOST_DTINIVIG}");

                                            /*" -1251- DISPLAY '* WCH-FINAL       ....... ' WCH-FINAL */
                                            _.Display($"* WCH-FINAL       ....... {AREA_DE_WORK.WCH_FINAL}");

                                            /*" -1252- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1256- DISPLAY '*****************************************' . */
                                            _.Display($"*****************************************");
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1257- IF WCH-FINAL NOT EQUAL 'C' */

            if (AREA_DE_WORK.WCH_FINAL != "C")
            {

                /*" -1258- CLOSE RSI0807B */
                RSI0807B.Close();

                /*" -1259- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1259- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ENCERRA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1271- DISPLAY ' ' */
                _.Display($" ");

                /*" -1272- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1273- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0807B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0807B  *");

                /*" -1274- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1275- DISPLAY ' ' */
                _.Display($" ");

                /*" -1276- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -1277- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1278- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLCODE1);

                /*" -1279- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLCODE2);

                /*" -1280- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE3);

                /*" -1282- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.WABEND);
            }


            /*" -1283- IF W-ARQUIVO-ABERTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_ARQUIVO_ABERTO == "SIM")
            {

                /*" -1284- CLOSE RSI0807B. */
                RSI0807B.Close();
            }


            /*" -1284- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1285- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1287- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1287- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}