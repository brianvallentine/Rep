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
using Sias.Sinistro.DB2.SI0809B;

namespace Code
{
    public class SI0809B
    {
        public bool IsCall { get; set; }

        public SI0809B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0809B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JUNHO / 1995                        *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            RELACAO DOS PAGAMENTOS COMPLEMENTAR *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * MESTRE DE SINISTRO                 V0MESTSINI        INPUT     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      * ALTERACAO BARAN 27/01/97 : NAO LER MAIS V0APOLICE E NAO RODAR  *      */
        /*"      *                            MAIS POR RAMO, APENAS POR APOLICE.  *      */
        /*"      *                            E O ACESSO A SEGURAVG               *      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO RILDO SICO - 16/10/2001 : MUDANCA PARA GERAR ARQUIVO *      */
        /*"      *                            PROCURAR RS001                      *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0809B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0809B
        {
            get
            {
                _.Move(REG_SI0809B, _RSI0809B); VarBasis.RedefinePassValue(REG_SI0809B, _RSI0809B, REG_SI0809B); return _RSI0809B;
            }
        }
        /*"01                  REG-SI0809B.*/
        public SI0809B_REG_SI0809B REG_SI0809B { get; set; } = new SI0809B_REG_SI0809B();
        public class SI0809B_REG_SI0809B : VarBasis
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
        public SI0809B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0809B_AREA_DE_WORK();
        public class SI0809B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  WCH-FINAL         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05  W-ARQUIVO-ABERTO  PIC  X(003)      VALUE SPACES.*/
            public StringBasis W_ARQUIVO_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-JOIN-HIST-MEST  PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_JOIN_HIST_MEST { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-V1RELATOR    PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05       W-AC-LINHAS         PIC  9(002)      VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05       W-AC-PAGINA         PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         CH-CHAVE-ATU.*/
            public SI0809B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new SI0809B_CH_CHAVE_ATU();
            public class SI0809B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10 W-APOLICE-ANT           PIC S9(013)      VALUE  +0 COMP-3*/
                public IntBasis W_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10 W-SINISTRO-ANT          PIC S9(013)      VALUE  +0 COMP-3*/
                public IntBasis W_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10 W-NOVA-APOLICE          PIC  X(003)      VALUE SPACES.*/
                public StringBasis W_NOVA_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  05  W-AC-PAGCOMP             PIC S9(013)V9(5) VALUE +0  COMP-3*/
            }
            public DoubleBasis W_AC_PAGCOMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TRANSF-VAL-OPERACAO    PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TRANSF_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-PAGCOMP            PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_PAGCOMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-TOT-GERAL-PAGCOMP      PIC S9(013)V9(5) VALUE +0  COMP-3*/
            public DoubleBasis W_TOT_GERAL_PAGCOMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05  W-COTACAO-HOJE           PIC S9(006)V9(09) VALUE +0 COMP-3*/
            public DoubleBasis W_COTACAO_HOJE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
            /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0809B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0809B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0809B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0809B_FILLER_0 : VarBasis
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

                public _REDEF_SI0809B_FILLER_0()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0809B_WHORA_CURR WHORA_CURR { get; set; } = new SI0809B_WHORA_CURR();
            public class SI0809B_WHORA_CURR : VarBasis
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
            public SI0809B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0809B_WDATA_CABEC();
            public class SI0809B_WDATA_CABEC : VarBasis
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
            public SI0809B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0809B_WHORA_CABEC();
            public class SI0809B_WHORA_CABEC : VarBasis
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
            public SI0809B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new SI0809B_WDATA_VIGENCIA();
            public class SI0809B_WDATA_VIGENCIA : VarBasis
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
            public SI0809B_WDATA_DTMOVTO WDATA_DTMOVTO { get; set; } = new SI0809B_WDATA_DTMOVTO();
            public class SI0809B_WDATA_DTMOVTO : VarBasis
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
            public SI0809B_WABEND WABEND { get; set; } = new SI0809B_WABEND();
            public class SI0809B_WABEND : VarBasis
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
                /*"  05            LC01.*/
            }
            public SI0809B_LC01 LC01 { get; set; } = new SI0809B_LC01();
            public class SI0809B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATOR   PIC  X(010) VALUE 'SI0809B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0809B.1");
                /*"    10          FILLER         PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          LC01-EMPRESA   PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER         PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER         PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA    PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public SI0809B_LC02 LC02 { get; set; } = new SI0809B_LC02();
            public class SI0809B_LC02 : VarBasis
            {
                /*"    10 FILLER                  PIC  X(010) VALUE 'SI0809B.1'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0809B.1");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(032) VALUE      'APURACAO DOS EXCEDENTES TECNICOS'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"APURACAO DOS EXCEDENTES TECNICOS");
                /*"    10          FILLER         PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          FILLER         PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public SI0809B_LC03 LC03 { get; set; } = new SI0809B_LC03();
            public class SI0809B_LC03 : VarBasis
            {
                /*"    10          FILLER         PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(050) VALUE        'SINISTROS COM PAGAMENTO COMPLEMENTAR NO PERIODO - '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"SINISTROS COM PAGAMENTO COMPLEMENTAR NO PERIODO - ");
                /*"    10          LC03-DIA-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-INI   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-INI   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10          LC03-DIA-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-MES-TER   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC03_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC03-ANO-TER   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC03_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10          FILLER         PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA      PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public SI0809B_LC04 LC04 { get; set; } = new SI0809B_LC04();
            public class SI0809B_LC04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(022) VALUE    'USUARIO SOLICITANTE - '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"USUARIO SOLICITANTE - ");
                /*"    10          LC02-CODUSU    PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC02_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER         PIC  X(002) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          FILLER         PIC  X(019) VALUE    'DATA SOLICITACAO - '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DATA SOLICITACAO - ");
                /*"    10          LC04-DIA-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_DIA_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-MES-SOL   PIC  9(002) VALUE  ZEROS.*/
                public IntBasis LC04_MES_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LC04-ANO-SOL   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC04_ANO_SOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER         PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"    10          FILLER         PIC  X(021) VALUE                               'FATORES EXPRESSOS EM '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"FATORES EXPRESSOS EM ");
                /*"    10          LC04-MOEDA     PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_MOEDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC05.*/
            }
            public SI0809B_LC05 LC05 { get; set; } = new SI0809B_LC05();
            public class SI0809B_LC05 : VarBasis
            {
                /*"    10          FILLER         PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC06.*/
            }
            public SI0809B_LC06 LC06 { get; set; } = new SI0809B_LC06();
            public class SI0809B_LC06 : VarBasis
            {
                /*"    10          FILLER         PIC  X(013) VALUE 'APOLICE'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(035) VALUE 'SEGURADO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"SEGURADO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(013) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(010) VALUE 'DT AVISO'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT AVISO");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER         PIC  X(018) VALUE 'VALOR COMP.'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"VALOR COMP.");
                /*"  05            LD01.*/
            }
            public SI0809B_LD01 LD01 { get; set; } = new SI0809B_LD01();
            public class SI0809B_LD01 : VarBasis
            {
                /*"    10          LD01-APOLICE   PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NOME      PIC  X(035) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-NUM-SINI  PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_NUM_SINI { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-DIAAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_DIAAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MESAV     PIC     99  BLANK WHEN ZEROS.*/
                public IntBasis LD01_MESAV { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                /*"    10          FILLER         PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANOAV     PIC   9999  BLANK WHEN ZEROS.*/
                public IntBasis LD01_ANOAV { get; set; } = new IntBasis(new PIC("9", "4", "9999"));
                /*"    10          FILLER         PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LD01-VLCOMP    PIC  --------.--9,99999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLCOMP { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V99999"), 5);
                /*"    10          FILLER         PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"  05    LD02.*/
            }
            public SI0809B_LD02 LD02 { get; set; } = new SI0809B_LD02();
            public class SI0809B_LD02 : VarBasis
            {
                /*"    10  FILLER             PIC  X(020) VALUE        'TOTAL APOLICE  .....'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL APOLICE  .....");
                /*"    10  FILLER             PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10  LD02-TOT-PAGCOMP   PIC  --------.--9,99999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_PAGCOMP { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V99999"), 5);
                /*"    10  FILLER             PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"  05    LD03.*/
            }
            public SI0809B_LD03 LD03 { get; set; } = new SI0809B_LD03();
            public class SI0809B_LD03 : VarBasis
            {
                /*"    10  FILLER             PIC  X(020) VALUE        'TOTAL GERAL    .....'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL GERAL    .....");
                /*"    10  FILLER             PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"    10  LD03-TOT-GERAL-PAGCOMP   PIC  --------.--9,99999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_PAGCOMP { get; set; } = new DoubleBasis(new PIC("9", "11", "--------.--9V99999"), 5);
                /*"    10  FILLER             PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"  05            LD04.*/
            }
            public SI0809B_LD04 LD04 { get; set; } = new SI0809B_LD04();
            public class SI0809B_LD04 : VarBasis
            {
                /*"    10          FILLER         PIC  X(054) VALUE    '** DEBITAR O TOTAL GERAL DO VALOR COMP. DA APURACAO **'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"** DEBITAR O TOTAL GERAL DO VALOR COMP. DA APURACAO **");
                /*"    10          FILLER         PIC  X(039) VALUE SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"01          LK-LINK.*/
            }
        }
        public SI0809B_LK_LINK LK_LINK { get; set; } = new SI0809B_LK_LINK();
        public class SI0809B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0809B_V1RELATORIOS V1RELATORIOS { get; set; } = new SI0809B_V1RELATORIOS();
        public SI0809B_JOIN_HIST_MEST JOIN_HIST_MEST { get; set; } = new SI0809B_JOIN_HIST_MEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0809B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0809B.SetFile(RSI0809B_FILE_NAME_P);

                /*" -441- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -442- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -445- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -448- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -448- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -456- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -457- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -458- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -459- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -461- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -462- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -466- OPEN OUTPUT RSI0809B */
            RSI0809B.Open(REG_SI0809B);

            /*" -468- PERFORM 0000-00-DECLARE-V1RELATORIOS. */

            M_0000_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -469- MOVE 'NAO' TO WFIM-V1RELATOR. */
            _.Move("NAO", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -471- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

            /*" -472- IF WFIM-V1RELATOR EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V1RELATOR == "SIM")
            {

                /*" -473- MOVE 'A' TO WCH-FINAL */
                _.Move("A", AREA_DE_WORK.WCH_FINAL);

                /*" -475- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -479- MOVE V1RELA-CODUNIMO TO WHOST-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, WHOST_CODUNIMO);

            /*" -481- PERFORM 0000-00-ACESSA-V1SISTEMA */

            M_0000_00_ACESSA_V1SISTEMA_SECTION();

            /*" -482- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -483- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -484- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -485- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -487- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -490- PERFORM 0000-00-PROCESSA-V1RELATORIO UNTIL WFIM-V1RELATOR EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_V1RELATOR == "SIM"))
            {

                M_0000_00_PROCESSA_V1RELATORIO_SECTION();
            }

            /*" -492- PERFORM 0000-00-DELETE-V1RELATORIOS. */

            M_0000_00_DELETE_V1RELATORIOS_SECTION();

            /*" -493- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -493- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -495- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -496- DISPLAY 'ERRO ACESSO COMMIT' */
                _.Display($"ERRO ACESSO COMMIT");

                /*" -498- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -500- MOVE SPACES TO WCH-FINAL. */
            _.Move("", AREA_DE_WORK.WCH_FINAL);

            /*" -500- GO TO 0000-00-ENCERRA. */

            M_0000_00_ENCERRA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_PRINCIPAL*/

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-SECTION */
        private void M_0000_00_ACESSA_V1SISTEMA_SECTION()
        {
            /*" -509- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -514- PERFORM M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1 */

            M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();

            /*" -517- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -518- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -519- MOVE 'B' TO WCH-FINAL */
                    _.Move("B", AREA_DE_WORK.WCH_FINAL);

                    /*" -520- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -521- ELSE */
                }
                else
                {


                    /*" -522- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -524- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -525- MOVE V1SIST-DTMOVABE TO WHOST-DTINIVIG. */
            _.Move(V1SIST_DTMOVABE, WHOST_DTINIVIG);

            /*" -527- MOVE 'G' TO WCH-FINAL. */
            _.Move("G", AREA_DE_WORK.WCH_FINAL);

            /*" -529- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -529- MOVE V1MOED-VLCRUZAD TO W-COTACAO-HOJE. */
            _.Move(V1MOED_VLCRUZAD, AREA_DE_WORK.W_COTACAO_HOJE);

        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1()
        {
            /*" -514- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -539- MOVE ZEROS TO W-AC-PAGINA. */
            _.Move(0, AREA_DE_WORK.W_AC_PAGINA);

            /*" -548- MOVE 80 TO W-AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.W_AC_LINHAS);

            /*" -550- MOVE ZEROS TO V0MEST-NUM-APOL-I V0MEST-RAMO-I. */
            _.Move(0, V0MEST_NUM_APOL_I, V0MEST_RAMO_I);

            /*" -551- MOVE 9999999999999 TO V0MEST-NUM-APOL-F. */
            _.Move(9999999999999, V0MEST_NUM_APOL_F);

            /*" -553- MOVE 99 TO V0MEST-RAMO-F. */
            _.Move(99, V0MEST_RAMO_F);

            /*" -554- IF V1RELA-RAMO NOT EQUAL ZEROS */

            if (V1RELA_RAMO != 00)
            {

                /*" -556- MOVE V1RELA-RAMO TO V0MEST-RAMO-I V0MEST-RAMO-F */
                _.Move(V1RELA_RAMO, V0MEST_RAMO_I, V0MEST_RAMO_F);

                /*" -557- ELSE */
            }
            else
            {


                /*" -558- IF V1RELA-NUM-APOLICE NOT EQUAL ZEROS */

                if (V1RELA_NUM_APOLICE != 00)
                {

                    /*" -561- MOVE V1RELA-NUM-APOLICE TO V0MEST-NUM-APOL-I V0MEST-NUM-APOL-F. */
                    _.Move(V1RELA_NUM_APOLICE, V0MEST_NUM_APOL_I, V0MEST_NUM_APOL_F);
                }

            }


            /*" -563- PERFORM 0000-00-DECLARE-JOIN-HIST-MEST. */

            M_0000_00_DECLARE_JOIN_HIST_MEST_SECTION();

            /*" -565- MOVE 'NAO' TO WFIM-JOIN-HIST-MEST. */
            _.Move("NAO", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

            /*" -567- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

            /*" -568- IF WFIM-JOIN-HIST-MEST EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM")
            {

                /*" -569- MOVE 'C' TO WCH-FINAL */
                _.Move("C", AREA_DE_WORK.WCH_FINAL);

                /*" -570- PERFORM 0000-00-ENCERRA */

                M_0000_00_ENCERRA_SECTION();

                /*" -572- GO TO 0000-01-LER-NOVO-V1RELATORIO. */

                M_0000_01_LER_NOVO_V1RELATORIO(); //GOTO
                return;
            }


            /*" -574- PERFORM 0000-00-PREPARA-CABECALHO. */

            M_0000_00_PREPARA_CABECALHO_SECTION();

            /*" -576- PERFORM 0000-00-MONTA-CABECALHO */

            M_0000_00_MONTA_CABECALHO_SECTION();

            /*" -578- MOVE ZEROS TO W-TOT-GERAL-PAGCOMP W-TOT-PAGCOMP. */
            _.Move(0, AREA_DE_WORK.W_TOT_GERAL_PAGCOMP, AREA_DE_WORK.W_TOT_PAGCOMP);

            /*" -579- MOVE 'SIM' TO W-NOVA-APOLICE. */
            _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

            /*" -582- PERFORM 0000-00-TRATA-JOIN-HIST-MEST UNTIL WFIM-JOIN-HIST-MEST EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
            {

                M_0000_00_TRATA_JOIN_HIST_MEST_SECTION();
            }

            /*" -582- PERFORM 0000-00-TOTAL-RELATORIO. */

            M_0000_00_TOTAL_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0000_01_LER_NOVO_V1RELATORIO */

            M_0000_01_LER_NOVO_V1RELATORIO();

        }

        [StopWatch]
        /*" M-0000-01-LER-NOVO-V1RELATORIO */
        private void M_0000_01_LER_NOVO_V1RELATORIO(bool isPerform = false)
        {
            /*" -588- PERFORM 0000-00-CLOSE-JOIN-HIST-MEST. */

            M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION();

            /*" -588- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V1RELATORIO*/

        [StopWatch]
        /*" M-0000-00-TRATA-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_TRATA_JOIN_HIST_MEST_SECTION()
        {
            /*" -599- MOVE ZEROS TO W-AC-PAGCOMP. */
            _.Move(0, AREA_DE_WORK.W_AC_PAGCOMP);

            /*" -601- PERFORM 0000-00-PREPARA-DETALHE. */

            M_0000_00_PREPARA_DETALHE_SECTION();

            /*" -602- MOVE V0MEST-NUM-APOL-SINI TO W-SINISTRO-ANT. */
            _.Move(V0MEST_NUM_APOL_SINI, AREA_DE_WORK.CH_CHAVE_ATU.W_SINISTRO_ANT);

            /*" -606- MOVE V0MEST-NUM-APOLICE TO W-APOLICE-ANT. */
            _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);

            /*" -613- PERFORM 0000-00-PROCESSA-SINISTRO UNTIL (WFIM-JOIN-HIST-MEST EQUAL 'SIM' ) OR (W-SINISTRO-ANT NOT EQUAL V0MEST-NUM-APOL-SINI) OR (W-APOLICE-ANT NOT EQUAL V0MEST-NUM-APOLICE). */

            while (!((AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM") || (AREA_DE_WORK.CH_CHAVE_ATU.W_SINISTRO_ANT != V0MEST_NUM_APOL_SINI) || (AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT != V0MEST_NUM_APOLICE)))
            {

                M_0000_00_PROCESSA_SINISTRO_SECTION();
            }

            /*" -615- PERFORM 0000-00-IMPRIME-REGISTRO. */

            M_0000_00_IMPRIME_REGISTRO_SECTION();

            /*" -617- IF (V0MEST-NUM-APOLICE NOT EQUAL W-APOLICE-ANT) OR (WFIM-JOIN-HIST-MEST EQUAL 'SIM' ) */

            if ((V0MEST_NUM_APOLICE != AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT) || (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
            {

                /*" -618- PERFORM 0000-00-TOTAL-APOLICE */

                M_0000_00_TOTAL_APOLICE_SECTION();

                /*" -619- MOVE ZEROS TO W-TOT-PAGCOMP */
                _.Move(0, AREA_DE_WORK.W_TOT_PAGCOMP);

                /*" -620- MOVE 'SIM' TO W-NOVA-APOLICE */
                _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

                /*" -620- MOVE V0MEST-NUM-APOLICE TO W-APOLICE-ANT. */
                _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-SINISTRO-SECTION */
        private void M_0000_00_PROCESSA_SINISTRO_SECTION()
        {
            /*" -628- MOVE V0HIST-DTMOVTO TO WHOST-DTINIVIG */
            _.Move(V0HIST_DTMOVTO, WHOST_DTINIVIG);

            /*" -629- MOVE 'I' TO WCH-FINAL */
            _.Move("I", AREA_DE_WORK.WCH_FINAL);

            /*" -630- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -632- COMPUTE W-TRANSF-VAL-OPERACAO = V0HIST-VAL-OPERACAO / V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_TRANSF_VAL_OPERACAO.Value = V0HIST_VAL_OPERACAO / V1MOED_VLCRUZAD;

            /*" -635- COMPUTE W-AC-PAGCOMP = W-AC-PAGCOMP + W-TRANSF-VAL-OPERACAO. */
            AREA_DE_WORK.W_AC_PAGCOMP.Value = AREA_DE_WORK.W_AC_PAGCOMP + AREA_DE_WORK.W_TRANSF_VAL_OPERACAO;

            /*" -635- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_SINISTRO*/

        [StopWatch]
        /*" M-0000-00-IMPRIME-REGISTRO-SECTION */
        private void M_0000_00_IMPRIME_REGISTRO_SECTION()
        {
            /*" -647- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -652- MOVE W-APOLICE-ANT TO LD01-APOLICE */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT, AREA_DE_WORK.LD01.LD01_APOLICE);

            /*" -654- MOVE W-AC-PAGCOMP TO LD01-VLCOMP. */
            _.Move(AREA_DE_WORK.W_AC_PAGCOMP, AREA_DE_WORK.LD01.LD01_VLCOMP);

            /*" -661- ADD W-AC-PAGCOMP TO W-TOT-PAGCOMP W-TOT-GERAL-PAGCOMP. */
            AREA_DE_WORK.W_TOT_PAGCOMP.Value = AREA_DE_WORK.W_TOT_PAGCOMP + AREA_DE_WORK.W_AC_PAGCOMP;
            AREA_DE_WORK.W_TOT_GERAL_PAGCOMP.Value = AREA_DE_WORK.W_TOT_GERAL_PAGCOMP + AREA_DE_WORK.W_AC_PAGCOMP;

            /*" -662- WRITE REG-SI0809B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

            /*" -662- ADD 1 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_IMPRIME_REGISTRO*/

        [StopWatch]
        /*" M-0000-00-PREPARA-DETALHE-SECTION */
        private void M_0000_00_PREPARA_DETALHE_SECTION()
        {
            /*" -672- IF V0MEST-RAMO EQUAL 97 OR 93 OR 81 OR 80 OR 81 OR 91 */

            if (V0MEST_RAMO.In("97", "93", "81", "80", "81", "91"))
            {

                /*" -673- MOVE V0MEST-NUM-APOLICE TO V1SEGU-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOLICE, V1SEGU_NUM_APOLICE);

                /*" -674- MOVE V0MEST-NRCERTIF TO V1SEGU-NRCERTIF */
                _.Move(V0MEST_NRCERTIF, V1SEGU_NRCERTIF);

                /*" -675- PERFORM 0000-00-SELECT-V1SEGURAVG */

                M_0000_00_SELECT_V1SEGURAVG_SECTION();

                /*" -676- MOVE V1SEGU-CODCLIEN TO WHOST-CODCLIEN */
                _.Move(V1SEGU_CODCLIEN, WHOST_CODCLIEN);

                /*" -677- ELSE */
            }
            else
            {


                /*" -678- MOVE V0MEST-NUM-APOLICE TO V1APOL-NUM-APOLICE */
                _.Move(V0MEST_NUM_APOLICE, V1APOL_NUM_APOLICE);

                /*" -679- PERFORM 0000-00-SELECT-V1APOLICE */

                M_0000_00_SELECT_V1APOLICE_SECTION();

                /*" -681- MOVE V1APOL-CODCLIEN TO WHOST-CODCLIEN. */
                _.Move(V1APOL_CODCLIEN, WHOST_CODCLIEN);
            }


            /*" -682- PERFORM 0000-00-SELECT-V1CLIENTE */

            M_0000_00_SELECT_V1CLIENTE_SECTION();

            /*" -683- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -684- MOVE '* CLIENTE  N A O  CADASTRADO *' TO LD01-NOME */
                _.Move("* CLIENTE  N A O  CADASTRADO *", AREA_DE_WORK.LD01.LD01_NOME);

                /*" -685- ELSE */
            }
            else
            {


                /*" -687- MOVE V1CLIE-NOME TO LD01-NOME. */
                _.Move(V1CLIE_NOME, AREA_DE_WORK.LD01.LD01_NOME);
            }


            /*" -688- MOVE V0MEST-NUM-APOL-SINI TO LD01-NUM-SINI. */
            _.Move(V0MEST_NUM_APOL_SINI, AREA_DE_WORK.LD01.LD01_NUM_SINI);

            /*" -689- MOVE V0MEST-DATCMD TO WDATA-VIGENCIA. */
            _.Move(V0MEST_DATCMD, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -690- MOVE WDATA-VIG-DIA TO LD01-DIAAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LD01.LD01_DIAAV);

            /*" -691- MOVE WDATA-VIG-MES TO LD01-MESAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LD01.LD01_MESAV);

            /*" -691- MOVE WDATA-VIG-ANO TO LD01-ANOAV. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LD01.LD01_ANOAV);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PREPARA_DETALHE*/

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-SECTION */
        private void M_0000_00_PREPARA_CABECALHO_SECTION()
        {
            /*" -702- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -706- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_1 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_1();

            /*" -709- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -710- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -711- MOVE 'D' TO WCH-FINAL */
                    _.Move("D", AREA_DE_WORK.WCH_FINAL);

                    /*" -712- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -713- ELSE */
                }
                else
                {


                    /*" -714- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -716- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -717- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -719- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -721- MOVE LK-TITULO TO LC01-EMPRESA */
            _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

            /*" -723- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -727- PERFORM M_0000_00_PREPARA_CABECALHO_DB_SELECT_2 */

            M_0000_00_PREPARA_CABECALHO_DB_SELECT_2();

            /*" -730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -731- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -732- MOVE 'F' TO WCH-FINAL */
                    _.Move("F", AREA_DE_WORK.WCH_FINAL);

                    /*" -733- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -734- ELSE */
                }
                else
                {


                    /*" -735- DISPLAY 'PROBLEMAS ACESSO V0MOEDA' */
                    _.Display($"PROBLEMAS ACESSO V0MOEDA");

                    /*" -736- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -738- MOVE V1RELA-CODUSU TO LC02-CODUSU. */
            _.Move(V1RELA_CODUSU, AREA_DE_WORK.LC04.LC02_CODUSU);

            /*" -739- MOVE V1RELA-DT-SOLICITA TO WDATA-VIGENCIA */
            _.Move(V1RELA_DT_SOLICITA, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -740- MOVE WDATA-VIG-DIA TO LC04-DIA-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC04.LC04_DIA_SOL);

            /*" -741- MOVE WDATA-VIG-MES TO LC04-MES-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC04.LC04_MES_SOL);

            /*" -743- MOVE WDATA-VIG-ANO TO LC04-ANO-SOL */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC04.LC04_ANO_SOL);

            /*" -745- MOVE V0MOED-SIGLUNIM TO LC04-MOEDA. */
            _.Move(V0MOED_SIGLUNIM, AREA_DE_WORK.LC04.LC04_MOEDA);

            /*" -746- MOVE V1RELA-PERI-INI TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_INI, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -747- MOVE WDATA-VIG-DIA TO LC03-DIA-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_INI);

            /*" -748- MOVE WDATA-VIG-MES TO LC03-MES-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_INI);

            /*" -750- MOVE WDATA-VIG-ANO TO LC03-ANO-INI */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_INI);

            /*" -751- MOVE V1RELA-PERI-FIM TO WDATA-VIGENCIA */
            _.Move(V1RELA_PERI_FIM, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -752- MOVE WDATA-VIG-DIA TO LC03-DIA-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA, AREA_DE_WORK.LC03.LC03_DIA_TER);

            /*" -753- MOVE WDATA-VIG-MES TO LC03-MES-TER */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES, AREA_DE_WORK.LC03.LC03_MES_TER);

            /*" -753- MOVE WDATA-VIG-ANO TO LC03-ANO-TER. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO, AREA_DE_WORK.LC03.LC03_ANO_TER);

        }

        [StopWatch]
        /*" M-0000-00-PREPARA-CABECALHO-DB-SELECT-1 */
        public void M_0000_00_PREPARA_CABECALHO_DB_SELECT_1()
        {
            /*" -706- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -727- EXEC SQL SELECT SIGLUNIM INTO :V0MOED-SIGLUNIM FROM SEGUROS.V0MOEDA WHERE CODUNIMO = :V1RELA-CODUNIMO END-EXEC. */

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
            /*" -763- WRITE REG-SI0809B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

            /*" -764- WRITE REG-SI0809B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

            /*" -766- WRITE REG-SI0809B FROM LC04. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

            /*" -766- WRITE REG-SI0809B FROM LC06. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_MONTA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-SECTION */
        private void M_0000_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -777- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -782- PERFORM M_0000_00_SELECT_V1APOLICE_DB_SELECT_1 */

            M_0000_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -785- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -786- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -787- MOVE ZEROS TO V1APOL-CODCLIEN */
                    _.Move(0, V1APOL_CODCLIEN);

                    /*" -788- ELSE */
                }
                else
                {


                    /*" -789- DISPLAY 'ERRO ACESSO V1APOLICE' */
                    _.Display($"ERRO ACESSO V1APOLICE");

                    /*" -789- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -782- EXEC SQL SELECT CODCLIEN INTO :V1APOL-CODCLIEN FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1APOL-NUM-APOLICE END-EXEC. */

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
            /*" -799- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -807- PERFORM M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -810- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -811- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -812- MOVE ZEROS TO V1SEGU-CODCLIEN */
                    _.Move(0, V1SEGU_CODCLIEN);

                    /*" -813- ELSE */
                }
                else
                {


                    /*" -814- DISPLAY 'ERRO ACESSO V1SUBGRUPO' */
                    _.Display($"ERRO ACESSO V1SUBGRUPO");

                    /*" -814- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -807- EXEC SQL SELECT COD_CLIENTE INTO :V1SEGU-CODCLIEN FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :V1SEGU-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

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
            /*" -823- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -828- PERFORM M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -832- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -833- MOVE 'SEGURADO NAO CADASTRADO' TO V1CLIE-NOME */
                    _.Move("SEGURADO NAO CADASTRADO", V1CLIE_NOME);

                    /*" -834- ELSE */
                }
                else
                {


                    /*" -835- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -835- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -828- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN END-EXEC. */

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
            /*" -844- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -851- PERFORM M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1 */

            M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1();

            /*" -854- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -855- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -856- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -857- ELSE */
                }
                else
                {


                    /*" -858- DISPLAY 'PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -858- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1()
        {
            /*" -851- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-CODUNIMO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

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
            /*" -868- MOVE W-TOT-PAGCOMP TO LD02-TOT-PAGCOMP. */
            _.Move(AREA_DE_WORK.W_TOT_PAGCOMP, AREA_DE_WORK.LD02.LD02_TOT_PAGCOMP);

            /*" -868- WRITE REG-SI0809B FROM LD02. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_APOLICE*/

        [StopWatch]
        /*" M-0000-00-TOTAL-RELATORIO-SECTION */
        private void M_0000_00_TOTAL_RELATORIO_SECTION()
        {
            /*" -881- MOVE W-TOT-GERAL-PAGCOMP TO LD03-TOT-GERAL-PAGCOMP. */
            _.Move(AREA_DE_WORK.W_TOT_GERAL_PAGCOMP, AREA_DE_WORK.LD03.LD03_TOT_GERAL_PAGCOMP);

            /*" -883- WRITE REG-SI0809B FROM LD03. */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

            /*" -883- WRITE REG-SI0809B FROM LD04. */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_SI0809B);

            RSI0809B.Write(REG_SI0809B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TOTAL_RELATORIO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -894- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -906- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -908- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -911- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -912- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -906- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT RAMO , NUM_APOLICE , CODUNIMO , PERI_INICIAL , PERI_FINAL , CODUSU , DATA_SOLICITACAO FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0809B' ORDER BY CODUSU, DATA_SOLICITACAO, PERI_INICIAL, RAMO,NUM_APOLICE END-EXEC. */
            V1RELATORIOS = new SI0809B_V1RELATORIOS(false);
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
							WHERE CODRELAT = 'SI0809B' 
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
            /*" -908- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1()
        {
            /*" -996- EXEC SQL DECLARE JOIN-HIST-MEST CURSOR FOR SELECT MEST.NUM_APOLICE , MEST.NUM_APOL_SINISTRO , MEST.RAMO , MEST.NRCERTIF , MEST.SITUACAO , MEST.DATCMD , HIST.OPERACAO , HIST.VAL_OPERACAO , HIST.SITUACAO , HIST.DTMOVTO FROM SEGUROS.V0MESTSINI MEST, SEGUROS.V0HISTSINI HIST WHERE HIST.DTMOVTO BETWEEN :V1RELA-PERI-INI AND :V1RELA-PERI-FIM AND HIST.OPERACAO = 1004 AND HIST.SITUACAO <> '2' AND MEST.SITUACAO <> '2' AND MEST.NUM_APOLICE BETWEEN :V0MEST-NUM-APOL-I AND :V0MEST-NUM-APOL-F AND MEST.NUM_APOL_SINISTRO = HIST.NUM_APOL_SINISTRO ORDER BY MEST.NUM_APOL_SINISTRO END-EXEC. */
            JOIN_HIST_MEST = new SI0809B_JOIN_HIST_MEST(true);
            string GetQuery_JOIN_HIST_MEST()
            {
                var query = @$"SELECT MEST.NUM_APOLICE
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
							, 
							HIST.OPERACAO
							, 
							HIST.VAL_OPERACAO
							, 
							HIST.SITUACAO
							, 
							HIST.DTMOVTO 
							FROM SEGUROS.V0MESTSINI MEST
							, 
							SEGUROS.V0HISTSINI HIST 
							WHERE HIST.DTMOVTO BETWEEN '{V1RELA_PERI_INI}' 
							AND 
							'{V1RELA_PERI_FIM}' 
							AND HIST.OPERACAO = 1004 
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
            /*" -924- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -932- PERFORM M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -935- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -936- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -937- MOVE 'SIM' TO WFIM-V1RELATOR */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -938- ELSE */
                }
                else
                {


                    /*" -939- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -941- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -942- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -943- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -944- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -945- DISPLAY '*      ==>     SI0809B      <==         *' */
                _.Display($"*      ==>     SI0809B      <==         *");

                /*" -946- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -947- DISPLAY '*  DISPLAY DOS DADOS INFORMADOS PELO    *' */
                _.Display($"*  DOS DADOS INFORMADOS PELO    *");

                /*" -948- DISPLAY '*  USUARIO NA V1RELATORIOS              *' */
                _.Display($"*  USUARIO NA V1RELATORIOS              *");

                /*" -949- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -950- DISPLAY '* COD-EMPRESA ...... ' V1RELA-COD-EMPRESA */
                _.Display($"* COD-EMPRESA ...... {V1RELA_COD_EMPRESA}");

                /*" -951- DISPLAY '* RAMO        ...... ' V1RELA-RAMO */
                _.Display($"* RAMO        ...... {V1RELA_RAMO}");

                /*" -952- DISPLAY '* NUM. APOL.  ...... ' V1RELA-NUM-APOLICE */
                _.Display($"* NUM. APOL.  ...... {V1RELA_NUM_APOLICE}");

                /*" -953- DISPLAY '* CODUNIMO    ...... ' V1RELA-CODUNIMO */
                _.Display($"* CODUNIMO    ...... {V1RELA_CODUNIMO}");

                /*" -954- DISPLAY '* PERI. INIC. ...... ' V1RELA-PERI-INI */
                _.Display($"* PERI. INIC. ...... {V1RELA_PERI_INI}");

                /*" -955- DISPLAY '* PERI. FIM   ...... ' V1RELA-PERI-FIM */
                _.Display($"* PERI. FIM   ...... {V1RELA_PERI_FIM}");

                /*" -956- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -956- DISPLAY '*****************************************' . */
                _.Display($"*****************************************");
            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -932- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-RAMO , :V1RELA-NUM-APOLICE , :V1RELA-CODUNIMO , :V1RELA-PERI-INI , :V1RELA-PERI-FIM , :V1RELA-CODUSU , :V1RELA-DT-SOLICITA END-EXEC. */

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
            /*" -967- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -996- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1();

            /*" -998- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1();

            /*" -1001- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1002- DISPLAY 'PROBLEMAS OPEN JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS OPEN JOIN-HIST-MEST.. ");

                /*" -1002- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-OPEN-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1()
        {
            /*" -998- EXEC SQL OPEN JOIN-HIST-MEST END-EXEC. */

            JOIN_HIST_MEST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_FETCH_JOIN_HIST_MEST_SECTION()
        {
            /*" -1011- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1024- PERFORM M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1 */

            M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1();

            /*" -1040- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1041- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1042- MOVE 'SIM' TO WFIM-JOIN-HIST-MEST */
                    _.Move("SIM", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

                    /*" -1043- ELSE */
                }
                else
                {


                    /*" -1044- DISPLAY 'PROBLEMAS NO FETCH DA JOIN-HIST-MEST' */
                    _.Display($"PROBLEMAS NO FETCH DA JOIN-HIST-MEST");

                    /*" -1044- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-DB-FETCH-1 */
        public void M_0000_00_FETCH_JOIN_HIST_MEST_DB_FETCH_1()
        {
            /*" -1024- EXEC SQL FETCH JOIN-HIST-MEST INTO :V0MEST-NUM-APOLICE , :V0MEST-NUM-APOL-SINI , :V0MEST-RAMO , :V0MEST-NRCERTIF , :V0MEST-SITUACAO , :V0MEST-DATCMD , :V0HIST-OPERACAO , :V0HIST-VAL-OPERACAO , :V0HIST-SITUACAO , :V0HIST-DTMOVTO , :V0APOL-RAMO END-EXEC. */

            if (JOIN_HIST_MEST.Fetch())
            {
                _.Move(JOIN_HIST_MEST.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(JOIN_HIST_MEST.V0MEST_NUM_APOL_SINI, V0MEST_NUM_APOL_SINI);
                _.Move(JOIN_HIST_MEST.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(JOIN_HIST_MEST.V0MEST_NRCERTIF, V0MEST_NRCERTIF);
                _.Move(JOIN_HIST_MEST.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(JOIN_HIST_MEST.V0MEST_DATCMD, V0MEST_DATCMD);
                _.Move(JOIN_HIST_MEST.V0HIST_OPERACAO, V0HIST_OPERACAO);
                _.Move(JOIN_HIST_MEST.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
                _.Move(JOIN_HIST_MEST.V0HIST_SITUACAO, V0HIST_SITUACAO);
                _.Move(JOIN_HIST_MEST.V0HIST_DTMOVTO, V0HIST_DTMOVTO);
                _.Move(JOIN_HIST_MEST.V0APOL_RAMO, V0APOL_RAMO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION()
        {
            /*" -1054- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1054- PERFORM M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1 */

            M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1();

            /*" -1057- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1058- DISPLAY 'PROBLEMAS CLOSE JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS CLOSE JOIN-HIST-MEST.. ");

                /*" -1058- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1()
        {
            /*" -1054- EXEC SQL CLOSE JOIN-HIST-MEST END-EXEC. */

            JOIN_HIST_MEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_JOIN_HIST_MEST*/

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V1RELATORIOS_SECTION()
        {
            /*" -1069- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1071- PERFORM M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1();

            /*" -1074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1075- DISPLAY 'PROBLEMA DELETE V1RELATORIOS' */
                _.Display($"PROBLEMA DELETE V1RELATORIOS");

                /*" -1075- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -1071- EXEC SQL DELETE FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0809B' END-EXEC. */

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
            /*" -1087- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1088- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -1089- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1090- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1091- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1092- DISPLAY '//     ==>     SI0809B      <==        //' */
                _.Display($"//     ==>     SI0809B      <==        //");

                /*" -1093- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1094- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -1095- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1096- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1097- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1098- ELSE */
            }
            else
            {


                /*" -1099- IF WCH-FINAL EQUAL 'A' */

                if (AREA_DE_WORK.WCH_FINAL == "A")
                {

                    /*" -1100- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1101- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1102- DISPLAY '*      ==>     SI0809B      <==         *' */
                    _.Display($"*      ==>     SI0809B      <==         *");

                    /*" -1103- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1104- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                    _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                    /*" -1105- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1106- DISPLAY '*  NAO HOUVE SOLICITACAO PELO USUARIO,  *' */
                    _.Display($"*  NAO HOUVE SOLICITACAO PELO USUARIO,  *");

                    /*" -1107- DISPLAY '*  PARA EXECUCAO DO PROGRAMA SI0809B.   *' */
                    _.Display($"*  PARA EXECUCAO DO PROGRAMA SI0809B.   *");

                    /*" -1108- DISPLAY '*                                       *' */
                    _.Display($"*                                       *");

                    /*" -1109- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1110- ELSE */
                }
                else
                {


                    /*" -1111- IF WCH-FINAL EQUAL 'B' */

                    if (AREA_DE_WORK.WCH_FINAL == "B")
                    {

                        /*" -1112- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1113- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1114- DISPLAY '*      ==>     SI0809B      <==         *' */
                        _.Display($"*      ==>     SI0809B      <==         *");

                        /*" -1115- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1116- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                        /*" -1117- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1118- DISPLAY '*  DATA DO SISTEMA NAO FOI ENCONTRADO   *' */
                        _.Display($"*  DATA DO SISTEMA NAO FOI ENCONTRADO   *");

                        /*" -1119- DISPLAY '*                                       *' */
                        _.Display($"*                                       *");

                        /*" -1120- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -1121- ELSE */
                    }
                    else
                    {


                        /*" -1122- IF WCH-FINAL EQUAL 'C' */

                        if (AREA_DE_WORK.WCH_FINAL == "C")
                        {

                            /*" -1123- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1124- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1125- DISPLAY '*      ==>     SI0809B      <==         *' */
                            _.Display($"*      ==>     SI0809B      <==         *");

                            /*" -1126- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1127- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                            _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                            /*" -1128- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1129- DISPLAY '*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*' */
                            _.Display($"*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*");

                            /*" -1130- DISPLAY '*  PARA OS PARAMETROS INFORMADOS.       *' */
                            _.Display($"*  PARA OS PARAMETROS INFORMADOS.       *");

                            /*" -1131- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1132- DISPLAY '*  RAMO   ............ ' V1RELA-RAMO */
                            _.Display($"*  RAMO   ............ {V1RELA_RAMO}");

                            /*" -1133- DISPLAY '*  APOLICE ........... ' V1RELA-NUM-APOLICE */
                            _.Display($"*  APOLICE ........... {V1RELA_NUM_APOLICE}");

                            /*" -1134- DISPLAY '*  PERIODO INCIAL .... ' V1RELA-PERI-INI */
                            _.Display($"*  PERIODO INCIAL .... {V1RELA_PERI_INI}");

                            /*" -1135- DISPLAY '*  PERIODO FINAL  .... ' V1RELA-PERI-FIM */
                            _.Display($"*  PERIODO FINAL  .... {V1RELA_PERI_FIM}");

                            /*" -1136- DISPLAY '*                                       *' */
                            _.Display($"*                                       *");

                            /*" -1137- DISPLAY '*****************************************' */
                            _.Display($"*****************************************");

                            /*" -1138- ELSE */
                        }
                        else
                        {


                            /*" -1139- IF WCH-FINAL EQUAL 'D' */

                            if (AREA_DE_WORK.WCH_FINAL == "D")
                            {

                                /*" -1140- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1141- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1142- DISPLAY '*      ==>     SI0809B      <==         *' */
                                _.Display($"*      ==>     SI0809B      <==         *");

                                /*" -1143- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1144- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                /*" -1145- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1146- DISPLAY '*       EMPRESA NAO CADASTRADA          *' */
                                _.Display($"*       EMPRESA NAO CADASTRADA          *");

                                /*" -1147- DISPLAY '*                                       *' */
                                _.Display($"*                                       *");

                                /*" -1148- DISPLAY '*****************************************' */
                                _.Display($"*****************************************");

                                /*" -1149- ELSE */
                            }
                            else
                            {


                                /*" -1150- IF WCH-FINAL EQUAL 'E' */

                                if (AREA_DE_WORK.WCH_FINAL == "E")
                                {

                                    /*" -1151- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1152- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1153- DISPLAY '*      ==>     SI0809B      <==         *' */
                                    _.Display($"*      ==>     SI0809B      <==         *");

                                    /*" -1154- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1155- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                    _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                    /*" -1156- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1157- DISPLAY '*  PROBLEMA NO LINK PARA A SUBROTINA    *' */
                                    _.Display($"*  PROBLEMA NO LINK PARA A SUBROTINA    *");

                                    /*" -1158- DISPLAY '*  PROALN01 PARA ACESSO AO NOME EMPRESA *' */
                                    _.Display($"*  PROALN01 PARA ACESSO AO NOME EMPRESA *");

                                    /*" -1159- DISPLAY '*                                       *' */
                                    _.Display($"*                                       *");

                                    /*" -1160- DISPLAY '*****************************************' */
                                    _.Display($"*****************************************");

                                    /*" -1161- ELSE */
                                }
                                else
                                {


                                    /*" -1162- IF WCH-FINAL EQUAL 'F' */

                                    if (AREA_DE_WORK.WCH_FINAL == "F")
                                    {

                                        /*" -1163- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1164- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1165- DISPLAY '*      ==>     SI0809B      <==         *' */
                                        _.Display($"*      ==>     SI0809B      <==         *");

                                        /*" -1166- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1167- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                        _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                        /*" -1168- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1169- DISPLAY '*  MOEDA SOLICITADA NAO CADASTRADA      *' */
                                        _.Display($"*  MOEDA SOLICITADA NAO CADASTRADA      *");

                                        /*" -1170- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1171- DISPLAY '* CODIGO DA MOEDA ....... ' V1RELA-CODUNIMO */
                                        _.Display($"* CODIGO DA MOEDA ....... {V1RELA_CODUNIMO}");

                                        /*" -1172- DISPLAY '*                                       *' */
                                        _.Display($"*                                       *");

                                        /*" -1173- DISPLAY '*****************************************' */
                                        _.Display($"*****************************************");

                                        /*" -1174- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1176- IF WCH-FINAL EQUAL 'I' OR 'G' OR 'H' OR 'J' */

                                        if (AREA_DE_WORK.WCH_FINAL.In("I", "G", "H", "J"))
                                        {

                                            /*" -1177- DISPLAY '*****************************************' */
                                            _.Display($"*****************************************");

                                            /*" -1178- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1179- DISPLAY '*      ==>     SI0809B      <==         *' */
                                            _.Display($"*      ==>     SI0809B      <==         *");

                                            /*" -1180- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1181- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                                            _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                                            /*" -1182- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1183- DISPLAY '*  COTACAO PARA A DATA DO SISTEMA       *' */
                                            _.Display($"*  COTACAO PARA A DATA DO SISTEMA       *");

                                            /*" -1184- DISPLAY '*  NAO CADASTRADA                       *' */
                                            _.Display($"*  NAO CADASTRADA                       *");

                                            /*" -1185- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1186- DISPLAY '* CODIGO DA MOEDA ....... ' WHOST-CODUNIMO */
                                            _.Display($"* CODIGO DA MOEDA ....... {WHOST_CODUNIMO}");

                                            /*" -1187- DISPLAY '* DATA DA MOEDA   ....... ' WHOST-DTINIVIG */
                                            _.Display($"* DATA DA MOEDA   ....... {WHOST_DTINIVIG}");

                                            /*" -1188- DISPLAY '* WCH-FINAL       ....... ' WCH-FINAL */
                                            _.Display($"* WCH-FINAL       ....... {AREA_DE_WORK.WCH_FINAL}");

                                            /*" -1189- DISPLAY '*                                       *' */
                                            _.Display($"*                                       *");

                                            /*" -1191- DISPLAY '*****************************************' . */
                                            _.Display($"*****************************************");
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1192- IF WCH-FINAL NOT EQUAL 'C' */

            if (AREA_DE_WORK.WCH_FINAL != "C")
            {

                /*" -1193- CLOSE RSI0809B */
                RSI0809B.Close();

                /*" -1194- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1194- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_ENCERRA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1205- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1206- DISPLAY ' ' */
                _.Display($" ");

                /*" -1207- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1208- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0809B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0809B  *");

                /*" -1209- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1210- DISPLAY ' ' */
                _.Display($" ");

                /*" -1211- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -1212- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1213- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLCODE1);

                /*" -1214- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLCODE2);

                /*" -1215- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE3);

                /*" -1217- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.WABEND);
            }


            /*" -1218- IF W-ARQUIVO-ABERTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_ARQUIVO_ABERTO == "SIM")
            {

                /*" -1219- CLOSE RSI0809B. */
                RSI0809B.Close();
            }


            /*" -1219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1220- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1222- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1222- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}