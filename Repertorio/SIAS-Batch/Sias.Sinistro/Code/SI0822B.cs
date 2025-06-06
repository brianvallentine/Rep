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
using Sias.Sinistro.DB2.SI0822B;

namespace Code
{
    public class SI0822B
    {
        public bool IsCall { get; set; }

        public SI0822B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0822B                             *      */
        /*"      *   ANALISTA ............... HEIDER                              *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... AGOSTO / 1996                       *      */
        /*"      *   FUNCAO ................. ACOMPANHAMENTO DA CARTEIRA DE COSSEG*      */
        /*"      *   USUARIO SOLICITANTE .... ATUARIA                             *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 26/04/2005 - PRODEXTER                                         *      */
        /*"      *              UTILIZACAO DA GE_SIS_FUNCAO_OPER NO CALCULO DO    *      */
        /*"      *              VALOR DAS OPERACOES DE SINISTRO                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SICEDIDO { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SICEDIDO
        {
            get
            {
                _.Move(REG_SICEDIDO, _SICEDIDO); VarBasis.RedefinePassValue(REG_SICEDIDO, _SICEDIDO, REG_SICEDIDO); return _SICEDIDO;
            }
        }
        public FileBasis _SIACEITO { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SIACEITO
        {
            get
            {
                _.Move(REG_SIACEITO, _SIACEITO); VarBasis.RedefinePassValue(REG_SIACEITO, _SIACEITO, REG_SIACEITO); return _SIACEITO;
            }
        }
        /*"01                  REG-SICEDIDO.*/
        public SI0822B_REG_SICEDIDO REG_SICEDIDO { get; set; } = new SI0822B_REG_SICEDIDO();
        public class SI0822B_REG_SICEDIDO : VarBasis
        {
            /*"      05            LINHA-ARQUIVO      PIC  X(88).*/
            public StringBasis LINHA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "88", "X(88)."), @"");
            /*"01                  REG-SIACEITO.*/
        }
        public SI0822B_REG_SIACEITO REG_SIACEITO { get; set; } = new SI0822B_REG_SIACEITO();
        public class SI0822B_REG_SIACEITO : VarBasis
        {
            /*"      05            LINHA-ARQUIVO      PIC  X(88).*/
            public StringBasis LINHA_ARQUIVO_0 { get; set; } = new StringBasis(new PIC("X", "88", "X(88)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   V0RELA-PERI-INICIAL        PIC  X(010).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V0RELA-PERI-FINAL          PIC  X(010).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V1EMPR-COD-EMP             PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V1EMPR-NOM-EMP             PIC  X(040)     VALUE SPACES.*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77   V1EMPR-DTCURRENT           PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1EMPR_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   V0MEST-NUM-APOL-SINI       PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0MEST_NUM_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0MEST-TIPREG              PIC  X(001).*/
        public StringBasis V0MEST_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77   V0MEST-CODLIDER            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MEST_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0MEST-DATTEC              PIC  X(010).*/
        public StringBasis V0MEST_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   V0MEST-PCPARTIC            PIC S9(004)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0MEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77   V0MEST-RAMO                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0HISTSINI-NUM-APOL-SINI   PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0HISTSINI_NUM_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0HISTSINI-AA-DTMOVTO      PIC  X(004).*/
        public StringBasis V0HISTSINI_AA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77   V0HISTSINI-MM-DTMOVTO      PIC  X(002).*/
        public StringBasis V0HISTSINI_MM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77   V0HISTSINI-OPERACAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0HISTSINI-VAL-OPERACAO    PIC S9(013)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0HISTSINI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77   V0COHISTSI-CONGENER        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COHISTSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0COHISTSI-NUM-SINISTRO    PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0COHISTSI_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77   V0COHISTSI-AA-DTMOVTO      PIC  X(004).*/
        public StringBasis V0COHISTSI_AA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77   V0COHISTSI-MM-DTMOVTO      PIC  X(002).*/
        public StringBasis V0COHISTSI_MM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77   V0COHISTSI-OPERACAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COHISTSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0COHISTSI-VAL-OPERACAO    PIC S9(013)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0COHISTSI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77   V0CONGENERE-CONGENER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONGENERE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0CONGENERE-NOMECONG       PIC  X(040).*/
        public StringBasis V0CONGENERE_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01           AREA-DE-WORK.*/
        public SI0822B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0822B_AREA_DE_WORK();
        public class SI0822B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE               PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  W-CHAVE-ON-1-ACEITO        PIC  X(003)      VALUE SPACES.*/
            public StringBasis W_CHAVE_ON_1_ACEITO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-CHAVE-ON-1-CEDIDO        PIC  X(003)      VALUE SPACES.*/
            public StringBasis W_CHAVE_ON_1_CEDIDO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-CHAVES-FIM-ARQUIVO.*/
            public SI0822B_W_CHAVES_FIM_ARQUIVO W_CHAVES_FIM_ARQUIVO { get; set; } = new SI0822B_W_CHAVES_FIM_ARQUIVO();
            public class SI0822B_W_CHAVES_FIM_ARQUIVO : VarBasis
            {
                /*"      10  WFIM-CEDIDO            PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_CEDIDO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  WFIM-ACEITO            PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_ACEITO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  WFIM-V0RELATORIOS      PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  05  W-CHAVES-QUEBRA.*/
            }
            public SI0822B_W_CHAVES_QUEBRA W_CHAVES_QUEBRA { get; set; } = new SI0822B_W_CHAVES_QUEBRA();
            public class SI0822B_W_CHAVES_QUEBRA : VarBasis
            {
                /*"      10 W-RAMO-ANT            PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis W_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 W-AA-DTMOVTO-ANT      PIC  X(004)      VALUE     SPACES*/
                public StringBasis W_AA_DTMOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10 W-MM-DTMOVTO-ANT      PIC  X(002)      VALUE     SPACES*/
                public StringBasis W_MM_DTMOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10 W-CONGENERE-ANT       PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis W_CONGENERE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 W-CODLIDER-ANT        PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis W_CODLIDER_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03  W-ACUMULADORES.*/
            }
            public SI0822B_W_ACUMULADORES W_ACUMULADORES { get; set; } = new SI0822B_W_ACUMULADORES();
            public class SI0822B_W_ACUMULADORES : VarBasis
            {
                /*"  05  W-AC-VAL-CONGENERE        PIC S9(13)V99    VALUE +0 COMP-3*/
                public DoubleBasis W_AC_VAL_CONGENERE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"  05  W-AC-VAL-LIDER            PIC S9(13)V99    VALUE +0 COMP-3*/
                public DoubleBasis W_AC_VAL_LIDER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"  05  W-AC-VAL-AAMM-DTMOVTO     PIC S9(13)V99    VALUE +0 COMP-3*/
                public DoubleBasis W_AC_VAL_AAMM_DTMOVTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"  05  W-AC-VAL-RAMO             PIC S9(13)V99    VALUE +0 COMP-3*/
                public DoubleBasis W_AC_VAL_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"  05  W-TOT-VAL-CEDIDO          PIC S9(13)V99    VALUE +0 COMP-3*/
                public DoubleBasis W_TOT_VAL_CEDIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"  05  W-TOT-VAL-ACEITO          PIC S9(13)V99    VALUE +0 COMP-3*/
                public DoubleBasis W_TOT_VAL_ACEITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
                public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
                private _REDEF_SI0822B_FILLER_0 _filler_0 { get; set; }
                public _REDEF_SI0822B_FILLER_0 FILLER_0
                {
                    get { _filler_0 = new _REDEF_SI0822B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                    set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
                }  //Redefines
                public class _REDEF_SI0822B_FILLER_0 : VarBasis
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
                    /*"  05         WHORA-CURR-E.*/

                    public _REDEF_SI0822B_FILLER_0()
                    {
                        WDATA_AA_CURR.ValueChanged += OnValueChanged;
                        FILLER_1.ValueChanged += OnValueChanged;
                        WDATA_MM_CURR.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                        WDATA_DD_CURR.ValueChanged += OnValueChanged;
                    }

                }
                public SI0822B_WHORA_CURR_E WHORA_CURR_E { get; set; } = new SI0822B_WHORA_CURR_E();
                public class SI0822B_WHORA_CURR_E : VarBasis
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
                public SI0822B_WHORA_CURR WHORA_CURR { get; set; } = new SI0822B_WHORA_CURR();
                public class SI0822B_WHORA_CURR : VarBasis
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
                public SI0822B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0822B_WDATA_CABEC();
                public class SI0822B_WDATA_CABEC : VarBasis
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
                public SI0822B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0822B_WHORA_CABEC();
                public class SI0822B_WHORA_CABEC : VarBasis
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
                    /*"  05   W-DATA-1.*/
                }
                public SI0822B_W_DATA_1 W_DATA_1 { get; set; } = new SI0822B_W_DATA_1();
                public class SI0822B_W_DATA_1 : VarBasis
                {
                    /*"    10  W-AA-DATA-1             PIC  9(004)    VALUE ZEROS.*/
                    public IntBasis W_AA_DATA_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    10  FILLER                  PIC  X(001)    VALUE SPACES.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"    10  W-MM-DATA-1             PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis W_MM_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    10  FILLER                  PIC  X(001)    VALUE SPACES.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"    10  W-DD-DATA-1             PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis W_DD_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"  05   W-DATA-2.*/
                }
                public SI0822B_W_DATA_2 W_DATA_2 { get; set; } = new SI0822B_W_DATA_2();
                public class SI0822B_W_DATA_2 : VarBasis
                {
                    /*"    10  W-DD-DATA-2             PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis W_DD_DATA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    10  FILLER                  PIC  X(001)    VALUE '/'.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"    10  W-MM-DATA-2             PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis W_MM_DATA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    10  FILLER                  PIC  X(001)    VALUE '/'.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"    10  W-AA-DATA-2             PIC  9(004)    VALUE ZEROS.*/
                    public IntBasis W_AA_DATA_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"  05         WDATA-DTMOVTO.*/
                }
                public SI0822B_WDATA_DTMOVTO WDATA_DTMOVTO { get; set; } = new SI0822B_WDATA_DTMOVTO();
                public class SI0822B_WDATA_DTMOVTO : VarBasis
                {
                    /*"    10       WDATA-MOV-ANO     PIC  9(004)    VALUE ZEROS.*/
                    public IntBasis WDATA_MOV_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"    10       WDATA-MOV-MES     PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis WDATA_MOV_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"    10       WDATA-MOV-DIA     PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis WDATA_MOV_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
                }
                public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  03        WABEND.*/
                public SI0822B_WABEND WABEND { get; set; } = new SI0822B_WABEND();
                public class SI0822B_WABEND : VarBasis
                {
                    /*"    05      FILLER              PIC  X(010) VALUE           ' SI0822B'.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0822B");
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
                    /*"  05   AC00.*/
                }
                public SI0822B_AC00 AC00 { get; set; } = new SI0822B_AC00();
                public class SI0822B_AC00 : VarBasis
                {
                    /*"    10 FILLER                   PIC X(010) VALUE                                'EMPRESA  :'.*/
                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"EMPRESA  :");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AC01-EMPRESA             PIC X(040) VALUE  SPACES.*/
                    public StringBasis AC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC01.*/
                }
                public SI0822B_AC01 AC01 { get; set; } = new SI0822B_AC01();
                public class SI0822B_AC01 : VarBasis
                {
                    /*"    10 FILLER                   PIC X(010) VALUE                                'ARQUIVO  :'.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ARQUIVO  :");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(009) VALUE 'SI0822B.1'.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0822B.1");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC02.*/
                }
                public SI0822B_AC02 AC02 { get; set; } = new SI0822B_AC02();
                public class SI0822B_AC02 : VarBasis
                {
                    /*"    10 FILLER                   PIC X(010) VALUE                                'DESCRICAO:'.*/
                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DESCRICAO:");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(028) VALUE       'ACOMPANHAMENTO DE COSSEGURO '.*/
                    public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"ACOMPANHAMENTO DE COSSEGURO ");
                    /*"    10 AC02-TIPO-ARQUIVO        PIC X(006) VALUE  SPACES.*/
                    public StringBasis AC02_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC02-A.*/
                }
                public SI0822B_AC02_A AC02_A { get; set; } = new SI0822B_AC02_A();
                public class SI0822B_AC02_A : VarBasis
                {
                    /*"    10 FILLER                   PIC X(008) VALUE 'DATA   :'.*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA   :");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AC02-DATA                PIC X(010) VALUE  SPACES.*/
                    public StringBasis AC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC02-B.*/
                }
                public SI0822B_AC02_B AC02_B { get; set; } = new SI0822B_AC02_B();
                public class SI0822B_AC02_B : VarBasis
                {
                    /*"    10 FILLER                   PIC X(010) VALUE 'HORA     :'.*/
                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA     :");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AC03-HORA                PIC X(008) VALUE  SPACES.*/
                    public StringBasis AC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC03.*/
                }
                public SI0822B_AC03 AC03 { get; set; } = new SI0822B_AC03();
                public class SI0822B_AC03 : VarBasis
                {
                    /*"    10 FILLER                   PIC X(010) VALUE                'PERIODO  :'.*/
                    public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PERIODO  :");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AC03-DATA-INI-SOL        PIC X(010) VALUE SPACES.*/
                    public StringBasis AC03_DATA_INI_SOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(003) VALUE ' A '.*/
                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AC03-DATA-FIM-SOL        PIC X(010) VALUE SPACES.*/
                    public StringBasis AC03_DATA_FIM_SOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC04.*/
                }
                public SI0822B_AC04 AC04 { get; set; } = new SI0822B_AC04();
                public class SI0822B_AC04 : VarBasis
                {
                    /*"    10 FILLER                   PIC X(007) VALUE                   'CONG.  '.*/
                    public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CONG.  ");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(004) VALUE                   'NOME'.*/
                    public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NOME");
                    /*"    10 FILLER                   PIC X(036) VALUE  SPACES.*/
                    public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(008) VALUE                   'MES REF.'.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"MES REF.");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(003) VALUE  SPACES.*/
                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"    10 FILLER                   PIC X(004) VALUE                   'RAMO'.*/
                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                    /*"    10 FILLER                   PIC X(004) VALUE  SPACES.*/
                    public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(012) VALUE  SPACES.*/
                    public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                    /*"    10 FILLER                   PIC X(005) VALUE                   'VALOR'.*/
                    public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AC05.*/
                }
                public SI0822B_AC05 AC05 { get; set; } = new SI0822B_AC05();
                public class SI0822B_AC05 : VarBasis
                {
                    /*"    10 FILLER                   PIC X(087) VALUE ALL '-'.*/
                    public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "87", "X(087)"), @"ALL");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AD01.*/
                }
                public SI0822B_AD01 AD01 { get; set; } = new SI0822B_AD01();
                public class SI0822B_AD01 : VarBasis
                {
                    /*"    10 AD01-CONGENER            PIC 9(007) VALUE ZEROS.*/
                    public IntBasis AD01_CONGENER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AD01-NOMECONG            PIC X(040) VALUE SPACES.*/
                    public StringBasis AD01_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AD01-ANO-MOVIMENTO       PIC 9999.*/
                    public IntBasis AD01_ANO_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    10 FILLER                   PIC X(001) VALUE  '/'.*/
                    public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"    10 AD01-MES-MOVIMENTO       PIC 99.*/
                    public IntBasis AD01_MES_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 FILLER                   PIC X(005) VALUE SPACES.*/
                    public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 AD01-RAMO                PIC 9(02).*/
                    public IntBasis AD01_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"    10 FILLER                   PIC X(005) VALUE SPACES.*/
                    public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AD01-VAL-SINISTRO        PIC -------------9,99.*/
                    public DoubleBasis AD01_VAL_SINISTRO { get; set; } = new DoubleBasis(new PIC("9", "14", "-------------9V99."), 2);
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"  05   AT01.*/
                }
                public SI0822B_AT01 AT01 { get; set; } = new SI0822B_AT01();
                public class SI0822B_AT01 : VarBasis
                {
                    /*"    10 AT01-TIPO-TOTAL          PIC X(069) VALUE SPACES.*/
                    public StringBasis AT01_TIPO_TOTAL { get; set; } = new StringBasis(new PIC("X", "69", "X(069)"), @"");
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"    10 AT01-VAL-SINISTRO        PIC -------------9,99.*/
                    public DoubleBasis AT01_VAL_SINISTRO { get; set; } = new DoubleBasis(new PIC("9", "14", "-------------9V99."), 2);
                    /*"    10 FILLER                   PIC X(001) VALUE  ';'.*/
                    public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                    /*"01          LK-LINK.*/
                }
            }
            public SI0822B_LK_LINK LK_LINK { get; set; } = new SI0822B_LK_LINK();
            public class SI0822B_LK_LINK : VarBasis
            {
                /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
                public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
                public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
                public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            }
        }


        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public SI0822B_CEDIDO CEDIDO { get; set; } = new SI0822B_CEDIDO();
        public SI0822B_ACEITO ACEITO { get; set; } = new SI0822B_ACEITO();
        public SI0822B_V0RELATORIOS V0RELATORIOS { get; set; } = new SI0822B_V0RELATORIOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SICEDIDO_FILE_NAME_P, string SIACEITO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SICEDIDO.SetFile(SICEDIDO_FILE_NAME_P);
                SIACEITO.SetFile(SIACEITO_FILE_NAME_P);

                /*" -388- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

                /*" -389- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -392- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -395- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -395- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL */

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
            /*" -403- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.W_ACUMULADORES.WHORA_CURR);

            /*" -404- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.W_ACUMULADORES.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -405- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.W_ACUMULADORES.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -406- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.W_ACUMULADORES.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -408- MOVE WHORA-CABEC TO AC03-HORA. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.WHORA_CABEC, AREA_DE_WORK.W_ACUMULADORES.AC02_B.AC03_HORA);

            /*" -413- MOVE 'SIM' TO W-CHAVE-ON-1-ACEITO W-CHAVE-ON-1-CEDIDO. */
            _.Move("SIM", AREA_DE_WORK.W_CHAVE_ON_1_ACEITO, AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO);

            /*" -414- PERFORM 0000-00-DECLARE-V0RELATORIOS. */

            M_0000_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -415- MOVE 'NAO' TO WFIM-V0RELATORIOS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS);

            /*" -416- PERFORM 0000-00-FETCH-V0RELATORIOS. */

            M_0000_00_FETCH_V0RELATORIOS_SECTION();

            /*" -417- IF WFIM-V0RELATORIOS EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS == "SIM")
            {

                /*" -418- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -419- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -420- DISPLAY '//     ==>     SI0822B      <==        //' */
                _.Display($"//     ==>     SI0822B      <==        //");

                /*" -421- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -422- DISPLAY '// ==>  NAO HOUVE SOLICITACAO DO   <== //' */
                _.Display($"// ==>  NAO HOUVE SOLICITACAO DO   <== //");

                /*" -423- DISPLAY '// ==>  USUARIO PARA EXECUCAO DO   <== //' */
                _.Display($"// ==>  USUARIO PARA EXECUCAO DO   <== //");

                /*" -424- DISPLAY '// ==>  PGM. NA V0RELATORIOS       <== //' */
                _.Display($"// ==>  PGM. NA V0RELATORIOS       <== //");

                /*" -425- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -426- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -428- GO TO 0000-99-ENCERRA. */

                M_0000_99_ENCERRA(); //GOTO
                return;
            }


            /*" -431- PERFORM 0000-00-PROCESSA-V0RELATORIOS UNTIL (WFIM-V0RELATORIOS EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS == "SIM")))
            {

                M_0000_00_PROCESSA_V0RELATORIOS_SECTION();
            }

            /*" -433- PERFORM 0000-00-DELETE-V0RELATORIOS. */

            M_0000_00_DELETE_V0RELATORIOS_SECTION();

            /*" -434- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -434- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -436- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -437- DISPLAY 'ERRO ACESSO COMMIT' */
                _.Display($"ERRO ACESSO COMMIT");

                /*" -439- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -440- IF W-CHAVE-ON-1-CEDIDO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "NAO")
            {

                /*" -441- CLOSE SICEDIDO */
                SICEDIDO.Close();

                /*" -442- ELSE */
            }
            else
            {


                /*" -443- OPEN OUTPUT SICEDIDO */
                SICEDIDO.Open(REG_SICEDIDO);

                /*" -445- MOVE 'NADA FOI SELECIONADO PARA ESTE ARQUIVO' TO REG-SICEDIDO */
                _.Move("NADA FOI SELECIONADO PARA ESTE ARQUIVO", REG_SICEDIDO);

                /*" -446- WRITE REG-SICEDIDO */
                SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                /*" -448- CLOSE SICEDIDO. */
                SICEDIDO.Close();
            }


            /*" -449- IF W-CHAVE-ON-1-ACEITO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "NAO")
            {

                /*" -450- CLOSE SIACEITO */
                SIACEITO.Close();

                /*" -451- ELSE */
            }
            else
            {


                /*" -452- OPEN OUTPUT SIACEITO */
                SIACEITO.Open(REG_SIACEITO);

                /*" -454- MOVE 'NADA FOI SELECIONADO PARA ESTE ARQUIVO' TO REG-SIACEITO */
                _.Move("NADA FOI SELECIONADO PARA ESTE ARQUIVO", REG_SIACEITO);

                /*" -455- WRITE REG-SIACEITO */
                SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                /*" -455- CLOSE SIACEITO. */
                SIACEITO.Close();
            }


        }

        [StopWatch]
        /*" M-0000-99-ENCERRA */
        private void M_0000_99_ENCERRA(bool isPerform = false)
        {
            /*" -459- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -460- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -461- DISPLAY '//     ==>     SI0822B      <==        //' */
            _.Display($"//     ==>     SI0822B      <==        //");

            /*" -462- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -463- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -464- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -465- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -465- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-00-PROCESSA-V0RELATORIOS-SECTION */
        private void M_0000_00_PROCESSA_V0RELATORIOS_SECTION()
        {
            /*" -473- PERFORM 0000-00-PROCESSA-CEDIDO. */

            M_0000_00_PROCESSA_CEDIDO_SECTION();

            /*" -475- PERFORM 0000-00-PROCESSA-ACEITO. */

            M_0000_00_PROCESSA_ACEITO_SECTION();

            /*" -475- PERFORM 0000-00-FETCH-V0RELATORIOS. */

            M_0000_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-CEDIDO-SECTION */
        private void M_0000_00_PROCESSA_CEDIDO_SECTION()
        {
            /*" -487- MOVE ZEROS TO W-AC-VAL-CONGENERE W-AC-VAL-AAMM-DTMOVTO W-AC-VAL-RAMO W-TOT-VAL-CEDIDO. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_CONGENERE, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO, AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_CEDIDO);

            /*" -489- PERFORM 0000-00-DECLARE-CEDIDO. */

            M_0000_00_DECLARE_CEDIDO_SECTION();

            /*" -490- MOVE 'NAO' TO WFIM-CEDIDO. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CEDIDO);

            /*" -492- PERFORM 0000-00-FETCH-CEDIDO. */

            M_0000_00_FETCH_CEDIDO_SECTION();

            /*" -495- PERFORM 0000-00-TRATA-CEDIDO UNTIL (WFIM-CEDIDO EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CEDIDO == "SIM")))
            {

                M_0000_00_TRATA_CEDIDO_SECTION();
            }

            /*" -496- IF W-CHAVE-ON-1-CEDIDO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "NAO")
            {

                /*" -497- MOVE 'TOTAL CEDIDO       ==> ' TO AT01-TIPO-TOTAL */
                _.Move("TOTAL CEDIDO       ==> ", AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_TIPO_TOTAL);

                /*" -498- MOVE W-TOT-VAL-CEDIDO TO AT01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_CEDIDO, AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_VAL_SINISTRO);

                /*" -498- WRITE REG-SICEDIDO FROM AT01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AT01.GetMoveValues(), REG_SICEDIDO);

                SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_CEDIDO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-CEDIDO-SECTION */
        private void M_0000_00_DECLARE_CEDIDO_SECTION()
        {
            /*" -512- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -538- PERFORM M_0000_00_DECLARE_CEDIDO_DB_DECLARE_1 */

            M_0000_00_DECLARE_CEDIDO_DB_DECLARE_1();

            /*" -540- PERFORM M_0000_00_DECLARE_CEDIDO_DB_OPEN_1 */

            M_0000_00_DECLARE_CEDIDO_DB_OPEN_1();

            /*" -543- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -544- DISPLAY 'PROBLEMAS OPEN CEDIDO........... ' */
                _.Display($"PROBLEMAS OPEN CEDIDO........... ");

                /*" -544- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-CEDIDO-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_CEDIDO_DB_DECLARE_1()
        {
            /*" -538- EXEC SQL DECLARE CEDIDO CURSOR FOR SELECT T2.CONGENER , SUBSTR((CHAR(T2.DTMOVTO, ISO)),1,4) , SUBSTR((CHAR(T2.DTMOVTO, ISO)),6,2) , VALUE(MEST.RAMO, 0) , T2.OPERACAO , (T2.VAL_OPERACAO * O.NUM_FATOR) FROM SEGUROS.V0MESTSINI MEST, SEGUROS.V0COSSEG_HISTSIN T2, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE MEST.SITUACAO <> '2' AND MEST.TIPREG = '1' AND MEST.PCPARTIC <> 100 AND T2.DTMOVTO BETWEEN :V0RELA-PERI-INICIAL AND :V0RELA-PERI-FINAL AND T2.NUM_SINISTRO = MEST.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = T2.OPERACAO ORDER BY 1, 2, 3, 4 END-EXEC. */
            CEDIDO = new SI0822B_CEDIDO(true);
            string GetQuery_CEDIDO()
            {
                var query = @$"SELECT T2.CONGENER
							, 
							SUBSTR((CHAR(T2.DTMOVTO
							, ISO))
							,1
							,4)
							, 
							SUBSTR((CHAR(T2.DTMOVTO
							, ISO))
							,6
							,2)
							, 
							VALUE(MEST.RAMO
							, 0)
							, 
							T2.OPERACAO
							, 
							(T2.VAL_OPERACAO * O.NUM_FATOR) 
							FROM SEGUROS.V0MESTSINI MEST
							, 
							SEGUROS.V0COSSEG_HISTSIN T2
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER O 
							WHERE MEST.SITUACAO <> '2' 
							AND MEST.TIPREG = '1' 
							AND MEST.PCPARTIC <> 100 
							AND T2.DTMOVTO BETWEEN '{V0RELA_PERI_INICIAL}' 
							AND '{V0RELA_PERI_FINAL}' 
							AND T2.NUM_SINISTRO = MEST.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_FUNCAO = 2 
							AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA 
							AND O.COD_OPERACAO = T2.OPERACAO 
							ORDER BY 1
							, 2
							, 3
							, 4";

                return query;
            }
            CEDIDO.GetQueryEvent += GetQuery_CEDIDO;

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-CEDIDO-DB-OPEN-1 */
        public void M_0000_00_DECLARE_CEDIDO_DB_OPEN_1()
        {
            /*" -540- EXEC SQL OPEN CEDIDO END-EXEC. */

            CEDIDO.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-ACEITO-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_ACEITO_DB_DECLARE_1()
        {
            /*" -747- EXEC SQL DECLARE ACEITO CURSOR FOR SELECT MEST.CODLIDER , SUBSTR((CHAR(HIST.DTMOVTO, ISO)),1,4) , SUBSTR((CHAR(HIST.DTMOVTO, ISO)),6,2) , VALUE(MEST.RAMO, 0) , HIST.OPERACAO , (HIST.VAL_OPERACAO * O.NUM_FATOR) FROM SEGUROS.V0MESTSINI MEST, SEGUROS.V0HISTSINI HIST, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE MEST.SITUACAO <> '2' AND MEST.TIPREG = '0' AND MEST.PCPARTIC = 100 AND HIST.DTMOVTO BETWEEN :V0RELA-PERI-INICIAL AND :V0RELA-PERI-FINAL AND HIST.NUM_APOL_SINISTRO = MEST.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = HIST.OPERACAO ORDER BY 1, 2, 3, 4 END-EXEC. */
            ACEITO = new SI0822B_ACEITO(true);
            string GetQuery_ACEITO()
            {
                var query = @$"SELECT MEST.CODLIDER
							, 
							SUBSTR((CHAR(HIST.DTMOVTO
							, ISO))
							,1
							,4)
							, 
							SUBSTR((CHAR(HIST.DTMOVTO
							, ISO))
							,6
							,2)
							, 
							VALUE(MEST.RAMO
							, 0)
							, 
							HIST.OPERACAO
							, 
							(HIST.VAL_OPERACAO * O.NUM_FATOR) 
							FROM SEGUROS.V0MESTSINI MEST
							, 
							SEGUROS.V0HISTSINI HIST
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER O 
							WHERE MEST.SITUACAO <> '2' 
							AND MEST.TIPREG = '0' 
							AND MEST.PCPARTIC = 100 
							AND HIST.DTMOVTO BETWEEN '{V0RELA_PERI_INICIAL}' 
							AND '{V0RELA_PERI_FINAL}' 
							AND HIST.NUM_APOL_SINISTRO = MEST.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_FUNCAO = 2 
							AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA 
							AND O.COD_OPERACAO = HIST.OPERACAO 
							ORDER BY 1
							, 2
							, 3
							, 4";

                return query;
            }
            ACEITO.GetQueryEvent += GetQuery_ACEITO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_CEDIDO*/

        [StopWatch]
        /*" M-0000-00-FETCH-CEDIDO-SECTION */
        private void M_0000_00_FETCH_CEDIDO_SECTION()
        {
            /*" -553- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -561- PERFORM M_0000_00_FETCH_CEDIDO_DB_FETCH_1 */

            M_0000_00_FETCH_CEDIDO_DB_FETCH_1();

            /*" -564- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -565- IF W-CHAVE-ON-1-CEDIDO EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "SIM")
                {

                    /*" -566- OPEN OUTPUT SICEDIDO */
                    SICEDIDO.Open(REG_SICEDIDO);

                    /*" -567- PERFORM 0000-00-MONTA-CABECALHO */

                    M_0000_00_MONTA_CABECALHO_SECTION();

                    /*" -568- WRITE REG-SICEDIDO FROM AC00 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC00.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -569- WRITE REG-SICEDIDO FROM AC01 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC01.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -570- MOVE 'CEDIDO' TO AC02-TIPO-ARQUIVO */
                    _.Move("CEDIDO", AREA_DE_WORK.W_ACUMULADORES.AC02.AC02_TIPO_ARQUIVO);

                    /*" -571- WRITE REG-SICEDIDO FROM AC02 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC02.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -572- WRITE REG-SICEDIDO FROM AC02-A */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC02_A.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -573- WRITE REG-SICEDIDO FROM AC02-B */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC02_B.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -574- WRITE REG-SICEDIDO FROM AC03 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC03.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -575- WRITE REG-SICEDIDO FROM AC05 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC05.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -576- WRITE REG-SICEDIDO FROM AC04 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC04.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -577- WRITE REG-SICEDIDO FROM AC05 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC05.GetMoveValues(), REG_SICEDIDO);

                    SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());

                    /*" -579- MOVE 'NAO' TO W-CHAVE-ON-1-CEDIDO. */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO);
                }

            }


            /*" -580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -581- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -582- MOVE 'SIM' TO WFIM-CEDIDO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CEDIDO);

                    /*" -583- PERFORM 0000-00-CLOSE-CEDIDO */

                    M_0000_00_CLOSE_CEDIDO_SECTION();

                    /*" -584- ELSE */
                }
                else
                {


                    /*" -585- DISPLAY 'PROBLEMAS NO FETCH DO CEDIDO .....' */
                    _.Display($"PROBLEMAS NO FETCH DO CEDIDO .....");

                    /*" -585- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-CEDIDO-DB-FETCH-1 */
        public void M_0000_00_FETCH_CEDIDO_DB_FETCH_1()
        {
            /*" -561- EXEC SQL FETCH CEDIDO INTO :V0COHISTSI-CONGENER , :V0COHISTSI-AA-DTMOVTO, :V0COHISTSI-MM-DTMOVTO, :V0MEST-RAMO , :V0COHISTSI-OPERACAO , :V0COHISTSI-VAL-OPERACAO END-EXEC. */

            if (CEDIDO.Fetch())
            {
                _.Move(CEDIDO.V0COHISTSI_CONGENER, V0COHISTSI_CONGENER);
                _.Move(CEDIDO.V0COHISTSI_AA_DTMOVTO, V0COHISTSI_AA_DTMOVTO);
                _.Move(CEDIDO.V0COHISTSI_MM_DTMOVTO, V0COHISTSI_MM_DTMOVTO);
                _.Move(CEDIDO.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(CEDIDO.V0COHISTSI_OPERACAO, V0COHISTSI_OPERACAO);
                _.Move(CEDIDO.V0COHISTSI_VAL_OPERACAO, V0COHISTSI_VAL_OPERACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_CEDIDO*/

        [StopWatch]
        /*" M-0000-00-CLOSE-CEDIDO-SECTION */
        private void M_0000_00_CLOSE_CEDIDO_SECTION()
        {
            /*" -595- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -595- PERFORM M_0000_00_CLOSE_CEDIDO_DB_CLOSE_1 */

            M_0000_00_CLOSE_CEDIDO_DB_CLOSE_1();

            /*" -598- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -599- DISPLAY 'PROBLEMAS CLOSE CEDIDO  ......... ' */
                _.Display($"PROBLEMAS CLOSE CEDIDO  ......... ");

                /*" -599- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-CEDIDO-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_CEDIDO_DB_CLOSE_1()
        {
            /*" -595- EXEC SQL CLOSE CEDIDO END-EXEC. */

            CEDIDO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_CEDIDO*/

        [StopWatch]
        /*" M-0000-00-TRATA-CEDIDO-SECTION */
        private void M_0000_00_TRATA_CEDIDO_SECTION()
        {
            /*" -606- MOVE V0COHISTSI-CONGENER TO V0CONGENERE-CONGENER. */
            _.Move(V0COHISTSI_CONGENER, V0CONGENERE_CONGENER);

            /*" -607- PERFORM 0000-00-SELECT-CONGENERE. */

            M_0000_00_SELECT_CONGENERE_SECTION();

            /*" -608- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -609- MOVE V0CONGENERE-NOMECONG TO AD01-NOMECONG */
                _.Move(V0CONGENERE_NOMECONG, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_NOMECONG);

                /*" -610- ELSE */
            }
            else
            {


                /*" -611- MOVE ALL '*' TO AD01-NOMECONG */
                _.MoveAll("*", AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_NOMECONG);

                /*" -613- DISPLAY 'PROBLEMAS SELECT DA CONGENERE... ' . */
                _.Display($"PROBLEMAS SELECT DA CONGENERE... ");
            }


            /*" -615- MOVE V0COHISTSI-CONGENER TO W-CONGENERE-ANT AD01-CONGENER. */
            _.Move(V0COHISTSI_CONGENER, AREA_DE_WORK.W_CHAVES_QUEBRA.W_CONGENERE_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_CONGENER);

            /*" -617- MOVE ZEROS TO W-AC-VAL-CONGENERE. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_CONGENERE);

            /*" -621- PERFORM 0000-00-TRATA-CEDIDO-1 UNTIL (WFIM-CEDIDO EQUAL 'SIM' ) OR (V0COHISTSI-CONGENER NOT EQUAL W-CONGENERE-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CEDIDO == "SIM") || (V0COHISTSI_CONGENER != AREA_DE_WORK.W_CHAVES_QUEBRA.W_CONGENERE_ANT)))
            {

                M_0000_00_TRATA_CEDIDO_1_SECTION();
            }

            /*" -622- IF W-CHAVE-ON-1-CEDIDO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "NAO")
            {

                /*" -623- MOVE 'TOTAL DA CONGENERE ==> ' TO AT01-TIPO-TOTAL */
                _.Move("TOTAL DA CONGENERE ==> ", AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_TIPO_TOTAL);

                /*" -624- MOVE W-AC-VAL-CONGENERE TO AT01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_CONGENERE, AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_VAL_SINISTRO);

                /*" -624- WRITE REG-SICEDIDO FROM AT01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AT01.GetMoveValues(), REG_SICEDIDO);

                SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_CEDIDO*/

        [StopWatch]
        /*" M-0000-00-TRATA-CEDIDO-1-SECTION */
        private void M_0000_00_TRATA_CEDIDO_1_SECTION()
        {
            /*" -632- MOVE V0COHISTSI-AA-DTMOVTO TO W-AA-DTMOVTO-ANT AD01-ANO-MOVIMENTO. */
            _.Move(V0COHISTSI_AA_DTMOVTO, AREA_DE_WORK.W_CHAVES_QUEBRA.W_AA_DTMOVTO_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_ANO_MOVIMENTO);

            /*" -634- MOVE V0COHISTSI-MM-DTMOVTO TO W-MM-DTMOVTO-ANT AD01-MES-MOVIMENTO. */
            _.Move(V0COHISTSI_MM_DTMOVTO, AREA_DE_WORK.W_CHAVES_QUEBRA.W_MM_DTMOVTO_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_MES_MOVIMENTO);

            /*" -636- MOVE ZEROS TO W-AC-VAL-AAMM-DTMOVTO. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO);

            /*" -642- PERFORM 0000-00-TRATA-CEDIDO-2 UNTIL (WFIM-CEDIDO EQUAL 'SIM' ) OR (V0COHISTSI-CONGENER NOT EQUAL W-CONGENERE-ANT) OR (V0COHISTSI-AA-DTMOVTO NOT EQUAL W-AA-DTMOVTO-ANT) OR (V0COHISTSI-MM-DTMOVTO NOT EQUAL W-MM-DTMOVTO-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CEDIDO == "SIM") || (V0COHISTSI_CONGENER != AREA_DE_WORK.W_CHAVES_QUEBRA.W_CONGENERE_ANT) || (V0COHISTSI_AA_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_AA_DTMOVTO_ANT) || (V0COHISTSI_MM_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_MM_DTMOVTO_ANT)))
            {

                M_0000_00_TRATA_CEDIDO_2_SECTION();
            }

            /*" -643- IF W-CHAVE-ON-1-CEDIDO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "NAO")
            {

                /*" -644- MOVE 'TOTAL DO ANO/MES   ==> ' TO AT01-TIPO-TOTAL */
                _.Move("TOTAL DO ANO/MES   ==> ", AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_TIPO_TOTAL);

                /*" -645- MOVE W-AC-VAL-AAMM-DTMOVTO TO AT01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO, AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_VAL_SINISTRO);

                /*" -645- WRITE REG-SICEDIDO FROM AT01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AT01.GetMoveValues(), REG_SICEDIDO);

                SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_CEDIDO_1*/

        [StopWatch]
        /*" M-0000-00-TRATA-CEDIDO-2-SECTION */
        private void M_0000_00_TRATA_CEDIDO_2_SECTION()
        {
            /*" -652- MOVE ZEROS TO W-AC-VAL-RAMO. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO);

            /*" -655- MOVE V0MEST-RAMO TO W-RAMO-ANT AD01-RAMO. */
            _.Move(V0MEST_RAMO, AREA_DE_WORK.W_CHAVES_QUEBRA.W_RAMO_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_RAMO);

            /*" -662- PERFORM 0000-00-TRATA-CEDIDO-3 UNTIL (WFIM-CEDIDO EQUAL 'SIM' ) OR (V0COHISTSI-CONGENER NOT EQUAL W-CONGENERE-ANT) OR (V0COHISTSI-AA-DTMOVTO NOT EQUAL W-AA-DTMOVTO-ANT) OR (V0COHISTSI-MM-DTMOVTO NOT EQUAL W-MM-DTMOVTO-ANT) OR (V0MEST-RAMO NOT EQUAL W-RAMO-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_CEDIDO == "SIM") || (V0COHISTSI_CONGENER != AREA_DE_WORK.W_CHAVES_QUEBRA.W_CONGENERE_ANT) || (V0COHISTSI_AA_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_AA_DTMOVTO_ANT) || (V0COHISTSI_MM_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_MM_DTMOVTO_ANT) || (V0MEST_RAMO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_RAMO_ANT)))
            {

                M_0000_00_TRATA_CEDIDO_3_SECTION();
            }

            /*" -663- IF W-CHAVE-ON-1-CEDIDO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "NAO")
            {

                /*" -664- MOVE W-AC-VAL-RAMO TO AD01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_VAL_SINISTRO);

                /*" -664- WRITE REG-SICEDIDO FROM AD01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AD01.GetMoveValues(), REG_SICEDIDO);

                SICEDIDO.Write(REG_SICEDIDO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_CEDIDO_2*/

        [StopWatch]
        /*" M-0000-00-TRATA-CEDIDO-3-SECTION */
        private void M_0000_00_TRATA_CEDIDO_3_SECTION()
        {
            /*" -680- COMPUTE W-AC-VAL-RAMO = W-AC-VAL-RAMO + V0COHISTSI-VAL-OPERACAO */
            AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO.Value = AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO + V0COHISTSI_VAL_OPERACAO;

            /*" -684- ADD V0COHISTSI-VAL-OPERACAO TO W-AC-VAL-CONGENERE W-AC-VAL-AAMM-DTMOVTO W-TOT-VAL-CEDIDO. */
            AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_CONGENERE.Value = AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_CONGENERE + V0COHISTSI_VAL_OPERACAO;
            AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO.Value = AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO + V0COHISTSI_VAL_OPERACAO;
            AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_CEDIDO.Value = AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_CEDIDO + V0COHISTSI_VAL_OPERACAO;

            /*" -684- PERFORM 0000-00-FETCH-CEDIDO. */

            M_0000_00_FETCH_CEDIDO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_CEDIDO_3*/

        [StopWatch]
        /*" M-0000-00-PROCESSA-ACEITO-SECTION */
        private void M_0000_00_PROCESSA_ACEITO_SECTION()
        {
            /*" -696- MOVE ZEROS TO W-AC-VAL-CONGENERE W-AC-VAL-AAMM-DTMOVTO W-AC-VAL-RAMO W-TOT-VAL-ACEITO. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_CONGENERE, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO, AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_ACEITO);

            /*" -698- PERFORM 0000-00-DECLARE-ACEITO. */

            M_0000_00_DECLARE_ACEITO_SECTION();

            /*" -699- MOVE 'NAO' TO WFIM-ACEITO. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_ACEITO);

            /*" -701- PERFORM 0000-00-FETCH-ACEITO. */

            M_0000_00_FETCH_ACEITO_SECTION();

            /*" -704- PERFORM 0000-00-TRATA-ACEITO UNTIL (WFIM-ACEITO EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_ACEITO == "SIM")))
            {

                M_0000_00_TRATA_ACEITO_SECTION();
            }

            /*" -705- IF W-CHAVE-ON-1-ACEITO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "NAO")
            {

                /*" -706- MOVE 'TOTAL ACEITO       ==> ' TO AT01-TIPO-TOTAL */
                _.Move("TOTAL ACEITO       ==> ", AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_TIPO_TOTAL);

                /*" -707- MOVE W-TOT-VAL-ACEITO TO AT01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_ACEITO, AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_VAL_SINISTRO);

                /*" -707- WRITE REG-SIACEITO FROM AT01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AT01.GetMoveValues(), REG_SIACEITO);

                SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_PROCESSA_ACEITO*/

        [StopWatch]
        /*" M-0000-00-DECLARE-ACEITO-SECTION */
        private void M_0000_00_DECLARE_ACEITO_SECTION()
        {
            /*" -721- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -747- PERFORM M_0000_00_DECLARE_ACEITO_DB_DECLARE_1 */

            M_0000_00_DECLARE_ACEITO_DB_DECLARE_1();

            /*" -749- PERFORM M_0000_00_DECLARE_ACEITO_DB_OPEN_1 */

            M_0000_00_DECLARE_ACEITO_DB_OPEN_1();

            /*" -752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -753- DISPLAY 'PROBLEMAS OPEN ACEITO........... ' */
                _.Display($"PROBLEMAS OPEN ACEITO........... ");

                /*" -753- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-ACEITO-DB-OPEN-1 */
        public void M_0000_00_DECLARE_ACEITO_DB_OPEN_1()
        {
            /*" -749- EXEC SQL OPEN ACEITO END-EXEC. */

            ACEITO.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -973- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT PERI_INICIAL , PERI_FINAL FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0822B' AND IDSISTEM = 'SI' END-EXEC. */
            V0RELATORIOS = new SI0822B_V0RELATORIOS(false);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'SI0822B' 
							AND IDSISTEM = 'SI'";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_ACEITO*/

        [StopWatch]
        /*" M-0000-00-FETCH-ACEITO-SECTION */
        private void M_0000_00_FETCH_ACEITO_SECTION()
        {
            /*" -762- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -770- PERFORM M_0000_00_FETCH_ACEITO_DB_FETCH_1 */

            M_0000_00_FETCH_ACEITO_DB_FETCH_1();

            /*" -773- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -774- IF W-CHAVE-ON-1-ACEITO EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "SIM")
                {

                    /*" -775- OPEN OUTPUT SIACEITO */
                    SIACEITO.Open(REG_SIACEITO);

                    /*" -776- PERFORM 0000-00-MONTA-CABECALHO */

                    M_0000_00_MONTA_CABECALHO_SECTION();

                    /*" -777- WRITE REG-SIACEITO FROM AC00 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC00.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -778- WRITE REG-SIACEITO FROM AC01 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC01.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -779- MOVE 'ACEITO' TO AC02-TIPO-ARQUIVO */
                    _.Move("ACEITO", AREA_DE_WORK.W_ACUMULADORES.AC02.AC02_TIPO_ARQUIVO);

                    /*" -780- WRITE REG-SIACEITO FROM AC02 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC02.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -781- WRITE REG-SIACEITO FROM AC02-A */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC02_A.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -782- WRITE REG-SIACEITO FROM AC02-B */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC02_B.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -783- WRITE REG-SIACEITO FROM AC03 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC03.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -784- WRITE REG-SIACEITO FROM AC05 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC05.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -785- WRITE REG-SIACEITO FROM AC04 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC04.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -786- WRITE REG-SIACEITO FROM AC05 */
                    _.Move(AREA_DE_WORK.W_ACUMULADORES.AC05.GetMoveValues(), REG_SIACEITO);

                    SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());

                    /*" -788- MOVE 'NAO' TO W-CHAVE-ON-1-ACEITO. */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ON_1_ACEITO);
                }

            }


            /*" -789- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -790- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -791- MOVE 'SIM' TO WFIM-ACEITO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_ACEITO);

                    /*" -792- PERFORM 0000-00-CLOSE-ACEITO */

                    M_0000_00_CLOSE_ACEITO_SECTION();

                    /*" -793- ELSE */
                }
                else
                {


                    /*" -794- DISPLAY 'PROBLEMAS NO FETCH DO ACEITO .....' */
                    _.Display($"PROBLEMAS NO FETCH DO ACEITO .....");

                    /*" -794- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-ACEITO-DB-FETCH-1 */
        public void M_0000_00_FETCH_ACEITO_DB_FETCH_1()
        {
            /*" -770- EXEC SQL FETCH ACEITO INTO :V0MEST-CODLIDER , :V0HISTSINI-AA-DTMOVTO, :V0HISTSINI-MM-DTMOVTO, :V0MEST-RAMO , :V0HISTSINI-OPERACAO , :V0HISTSINI-VAL-OPERACAO END-EXEC. */

            if (ACEITO.Fetch())
            {
                _.Move(ACEITO.V0MEST_CODLIDER, V0MEST_CODLIDER);
                _.Move(ACEITO.V0HISTSINI_AA_DTMOVTO, V0HISTSINI_AA_DTMOVTO);
                _.Move(ACEITO.V0HISTSINI_MM_DTMOVTO, V0HISTSINI_MM_DTMOVTO);
                _.Move(ACEITO.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(ACEITO.V0HISTSINI_OPERACAO, V0HISTSINI_OPERACAO);
                _.Move(ACEITO.V0HISTSINI_VAL_OPERACAO, V0HISTSINI_VAL_OPERACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_ACEITO*/

        [StopWatch]
        /*" M-0000-00-CLOSE-ACEITO-SECTION */
        private void M_0000_00_CLOSE_ACEITO_SECTION()
        {
            /*" -804- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -804- PERFORM M_0000_00_CLOSE_ACEITO_DB_CLOSE_1 */

            M_0000_00_CLOSE_ACEITO_DB_CLOSE_1();

            /*" -807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- DISPLAY 'PROBLEMAS CLOSE ACEITO  ......... ' */
                _.Display($"PROBLEMAS CLOSE ACEITO  ......... ");

                /*" -808- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-ACEITO-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_ACEITO_DB_CLOSE_1()
        {
            /*" -804- EXEC SQL CLOSE ACEITO END-EXEC. */

            ACEITO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_CLOSE_ACEITO*/

        [StopWatch]
        /*" M-0000-00-TRATA-ACEITO-SECTION */
        private void M_0000_00_TRATA_ACEITO_SECTION()
        {
            /*" -815- MOVE V0MEST-CODLIDER TO V0CONGENERE-CONGENER. */
            _.Move(V0MEST_CODLIDER, V0CONGENERE_CONGENER);

            /*" -816- PERFORM 0000-00-SELECT-CONGENERE. */

            M_0000_00_SELECT_CONGENERE_SECTION();

            /*" -817- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -818- MOVE V0CONGENERE-NOMECONG TO AD01-NOMECONG */
                _.Move(V0CONGENERE_NOMECONG, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_NOMECONG);

                /*" -819- ELSE */
            }
            else
            {


                /*" -820- MOVE ALL '*' TO AD01-NOMECONG */
                _.MoveAll("*", AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_NOMECONG);

                /*" -822- DISPLAY 'PROBLEMAS SELECT DA CONGENERE... ' . */
                _.Display($"PROBLEMAS SELECT DA CONGENERE... ");
            }


            /*" -824- MOVE V0MEST-CODLIDER TO W-CODLIDER-ANT AD01-CONGENER. */
            _.Move(V0MEST_CODLIDER, AREA_DE_WORK.W_CHAVES_QUEBRA.W_CODLIDER_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_CONGENER);

            /*" -826- MOVE ZEROS TO W-AC-VAL-LIDER. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_LIDER);

            /*" -830- PERFORM 0000-00-TRATA-ACEITO-1 UNTIL (WFIM-ACEITO EQUAL 'SIM' ) OR (V0MEST-CODLIDER NOT EQUAL W-CODLIDER-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_ACEITO == "SIM") || (V0MEST_CODLIDER != AREA_DE_WORK.W_CHAVES_QUEBRA.W_CODLIDER_ANT)))
            {

                M_0000_00_TRATA_ACEITO_1_SECTION();
            }

            /*" -831- IF W-CHAVE-ON-1-ACEITO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "NAO")
            {

                /*" -832- MOVE 'TOTAL DA LIDER ==> ' TO AT01-TIPO-TOTAL */
                _.Move("TOTAL DA LIDER ==> ", AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_TIPO_TOTAL);

                /*" -833- MOVE W-AC-VAL-LIDER TO AT01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_LIDER, AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_VAL_SINISTRO);

                /*" -833- WRITE REG-SIACEITO FROM AT01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AT01.GetMoveValues(), REG_SIACEITO);

                SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_ACEITO*/

        [StopWatch]
        /*" M-0000-00-TRATA-ACEITO-1-SECTION */
        private void M_0000_00_TRATA_ACEITO_1_SECTION()
        {
            /*" -841- MOVE V0HISTSINI-AA-DTMOVTO TO W-AA-DTMOVTO-ANT AD01-ANO-MOVIMENTO. */
            _.Move(V0HISTSINI_AA_DTMOVTO, AREA_DE_WORK.W_CHAVES_QUEBRA.W_AA_DTMOVTO_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_ANO_MOVIMENTO);

            /*" -843- MOVE V0HISTSINI-MM-DTMOVTO TO W-MM-DTMOVTO-ANT AD01-MES-MOVIMENTO. */
            _.Move(V0HISTSINI_MM_DTMOVTO, AREA_DE_WORK.W_CHAVES_QUEBRA.W_MM_DTMOVTO_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_MES_MOVIMENTO);

            /*" -845- MOVE ZEROS TO W-AC-VAL-AAMM-DTMOVTO. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO);

            /*" -851- PERFORM 0000-00-TRATA-ACEITO-2 UNTIL (WFIM-ACEITO EQUAL 'SIM' ) OR (V0MEST-CODLIDER NOT EQUAL W-CODLIDER-ANT) OR (V0HISTSINI-AA-DTMOVTO NOT EQUAL W-AA-DTMOVTO-ANT) OR (V0HISTSINI-MM-DTMOVTO NOT EQUAL W-MM-DTMOVTO-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_ACEITO == "SIM") || (V0MEST_CODLIDER != AREA_DE_WORK.W_CHAVES_QUEBRA.W_CODLIDER_ANT) || (V0HISTSINI_AA_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_AA_DTMOVTO_ANT) || (V0HISTSINI_MM_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_MM_DTMOVTO_ANT)))
            {

                M_0000_00_TRATA_ACEITO_2_SECTION();
            }

            /*" -852- IF W-CHAVE-ON-1-ACEITO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "NAO")
            {

                /*" -853- MOVE 'TOTAL DO ANO/MES   ==> ' TO AT01-TIPO-TOTAL */
                _.Move("TOTAL DO ANO/MES   ==> ", AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_TIPO_TOTAL);

                /*" -854- MOVE W-AC-VAL-AAMM-DTMOVTO TO AT01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO, AREA_DE_WORK.W_ACUMULADORES.AT01.AT01_VAL_SINISTRO);

                /*" -854- WRITE REG-SIACEITO FROM AT01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AT01.GetMoveValues(), REG_SIACEITO);

                SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_ACEITO_1*/

        [StopWatch]
        /*" M-0000-00-TRATA-ACEITO-2-SECTION */
        private void M_0000_00_TRATA_ACEITO_2_SECTION()
        {
            /*" -861- MOVE ZEROS TO W-AC-VAL-RAMO. */
            _.Move(0, AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO);

            /*" -864- MOVE V0MEST-RAMO TO W-RAMO-ANT AD01-RAMO. */
            _.Move(V0MEST_RAMO, AREA_DE_WORK.W_CHAVES_QUEBRA.W_RAMO_ANT, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_RAMO);

            /*" -871- PERFORM 0000-00-TRATA-ACEITO-3 UNTIL (WFIM-ACEITO EQUAL 'SIM' ) OR (V0MEST-CODLIDER NOT EQUAL W-CODLIDER-ANT) OR (V0HISTSINI-AA-DTMOVTO NOT EQUAL W-AA-DTMOVTO-ANT) OR (V0HISTSINI-MM-DTMOVTO NOT EQUAL W-MM-DTMOVTO-ANT) OR (V0MEST-RAMO NOT EQUAL W-RAMO-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_ACEITO == "SIM") || (V0MEST_CODLIDER != AREA_DE_WORK.W_CHAVES_QUEBRA.W_CODLIDER_ANT) || (V0HISTSINI_AA_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_AA_DTMOVTO_ANT) || (V0HISTSINI_MM_DTMOVTO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_MM_DTMOVTO_ANT) || (V0MEST_RAMO != AREA_DE_WORK.W_CHAVES_QUEBRA.W_RAMO_ANT)))
            {

                M_0000_00_TRATA_ACEITO_3_SECTION();
            }

            /*" -872- IF W-CHAVE-ON-1-ACEITO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "NAO")
            {

                /*" -873- MOVE W-AC-VAL-RAMO TO AD01-VAL-SINISTRO */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO, AREA_DE_WORK.W_ACUMULADORES.AD01.AD01_VAL_SINISTRO);

                /*" -873- WRITE REG-SIACEITO FROM AD01. */
                _.Move(AREA_DE_WORK.W_ACUMULADORES.AD01.GetMoveValues(), REG_SIACEITO);

                SIACEITO.Write(REG_SIACEITO.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_ACEITO_2*/

        [StopWatch]
        /*" M-0000-00-TRATA-ACEITO-3-SECTION */
        private void M_0000_00_TRATA_ACEITO_3_SECTION()
        {
            /*" -889- COMPUTE W-AC-VAL-RAMO = W-AC-VAL-RAMO + V0HISTSINI-VAL-OPERACAO. */
            AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO.Value = AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_RAMO + V0HISTSINI_VAL_OPERACAO;

            /*" -893- ADD V0HISTSINI-VAL-OPERACAO TO W-AC-VAL-LIDER W-AC-VAL-AAMM-DTMOVTO W-TOT-VAL-ACEITO. */
            AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_LIDER.Value = AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_LIDER + V0HISTSINI_VAL_OPERACAO;
            AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO.Value = AREA_DE_WORK.W_ACUMULADORES.W_AC_VAL_AAMM_DTMOVTO + V0HISTSINI_VAL_OPERACAO;
            AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_ACEITO.Value = AREA_DE_WORK.W_ACUMULADORES.W_TOT_VAL_ACEITO + V0HISTSINI_VAL_OPERACAO;

            /*" -893- PERFORM 0000-00-FETCH-ACEITO. */

            M_0000_00_FETCH_ACEITO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_TRATA_ACEITO_3*/

        [StopWatch]
        /*" M-0000-00-MONTA-CABECALHO-SECTION */
        private void M_0000_00_MONTA_CABECALHO_SECTION()
        {
            /*" -904- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -908- PERFORM M_0000_00_MONTA_CABECALHO_DB_SELECT_1 */

            M_0000_00_MONTA_CABECALHO_DB_SELECT_1();

            /*" -911- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                /*" -914- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -915- MOVE V1EMPR-DTCURRENT TO WDATA-CURR */
            _.Move(V1EMPR_DTCURRENT, AREA_DE_WORK.W_ACUMULADORES.WDATA_CURR);

            /*" -916- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.W_ACUMULADORES.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -917- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.W_ACUMULADORES.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -918- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.W_ACUMULADORES.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -920- MOVE WDATA-CABEC TO AC02-DATA. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.WDATA_CABEC, AREA_DE_WORK.W_ACUMULADORES.AC02_A.AC02_DATA);

            /*" -921- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, AREA_DE_WORK.LK_LINK.LK_TITULO);

            /*" -923- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", AREA_DE_WORK.LK_LINK);

            /*" -924- IF LK-RTCODE EQUAL ZEROS */

            if (AREA_DE_WORK.LK_LINK.LK_RTCODE == 00)
            {

                /*" -925- MOVE LK-TITULO TO AC01-EMPRESA */
                _.Move(AREA_DE_WORK.LK_LINK.LK_TITULO, AREA_DE_WORK.W_ACUMULADORES.AC00.AC01_EMPRESA);

                /*" -926- ELSE */
            }
            else
            {


                /*" -927- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                /*" -929- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -930- MOVE V0RELA-PERI-INICIAL TO W-DATA-1. */
            _.Move(V0RELA_PERI_INICIAL, AREA_DE_WORK.W_ACUMULADORES.W_DATA_1);

            /*" -931- MOVE W-DD-DATA-1 TO W-DD-DATA-2. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_ACUMULADORES.W_DATA_2.W_DD_DATA_2);

            /*" -932- MOVE W-MM-DATA-1 TO W-MM-DATA-2. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_ACUMULADORES.W_DATA_2.W_MM_DATA_2);

            /*" -933- MOVE W-AA-DATA-1 TO W-AA-DATA-2. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_ACUMULADORES.W_DATA_2.W_AA_DATA_2);

            /*" -935- MOVE W-DATA-2 TO AC03-DATA-INI-SOL. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_2, AREA_DE_WORK.W_ACUMULADORES.AC03.AC03_DATA_INI_SOL);

            /*" -936- MOVE V0RELA-PERI-FINAL TO W-DATA-1. */
            _.Move(V0RELA_PERI_FINAL, AREA_DE_WORK.W_ACUMULADORES.W_DATA_1);

            /*" -937- MOVE W-DD-DATA-1 TO W-DD-DATA-2. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_ACUMULADORES.W_DATA_2.W_DD_DATA_2);

            /*" -938- MOVE W-MM-DATA-1 TO W-MM-DATA-2. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_ACUMULADORES.W_DATA_2.W_MM_DATA_2);

            /*" -939- MOVE W-AA-DATA-1 TO W-AA-DATA-2. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_ACUMULADORES.W_DATA_2.W_AA_DATA_2);

            /*" -939- MOVE W-DATA-2 TO AC03-DATA-FIM-SOL. */
            _.Move(AREA_DE_WORK.W_ACUMULADORES.W_DATA_2, AREA_DE_WORK.W_ACUMULADORES.AC03.AC03_DATA_FIM_SOL);

        }

        [StopWatch]
        /*" M-0000-00-MONTA-CABECALHO-DB-SELECT-1 */
        public void M_0000_00_MONTA_CABECALHO_DB_SELECT_1()
        {
            /*" -908- EXEC SQL SELECT NOME_EMPRESA, CURRENT DATE INTO :V1EMPR-NOM-EMP, :V1EMPR-DTCURRENT FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1 = new M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1.Execute(m_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
                _.Move(executed_1.V1EMPR_DTCURRENT, V1EMPR_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_MONTA_CABECALHO*/

        [StopWatch]
        /*" M-0000-00-SELECT-CONGENERE-SECTION */
        private void M_0000_00_SELECT_CONGENERE_SECTION()
        {
            /*" -949- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -954- PERFORM M_0000_00_SELECT_CONGENERE_DB_SELECT_1 */

            M_0000_00_SELECT_CONGENERE_DB_SELECT_1();

            /*" -957- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -958- DISPLAY 'PROBLEMAS OPEN ACEITO........... ' */
                _.Display($"PROBLEMAS OPEN ACEITO........... ");

                /*" -958- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-CONGENERE-DB-SELECT-1 */
        public void M_0000_00_SELECT_CONGENERE_DB_SELECT_1()
        {
            /*" -954- EXEC SQL SELECT NOMECONG INTO :V0CONGENERE-NOMECONG FROM SEGUROS.V0CONGENERE WHERE CONGENER = :V0CONGENERE-CONGENER END-EXEC. */

            var m_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1 = new M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1()
            {
                V0CONGENERE_CONGENER = V0CONGENERE_CONGENER.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONGENERE_NOMECONG, V0CONGENERE_NOMECONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SELECT_CONGENERE*/

        [StopWatch]
        /*" M-0000-00-DECLARE-V0RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -967- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -973- PERFORM M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -975- PERFORM M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -977- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -978- DISPLAY 'PROBLEMAS OPEN V0RELATORIOS....' */
                _.Display($"PROBLEMAS OPEN V0RELATORIOS....");

                /*" -978- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -975- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DECLARE_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-FETCH-V0RELATORIOS-SECTION */
        private void M_0000_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -988- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -991- PERFORM M_0000_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -994- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -995- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -996- DISPLAY '* PARAMETROS SOLICITADOS PELO USUARIO   *' */
                _.Display($"* PARAMETROS SOLICITADOS PELO USUARIO   *");

                /*" -997- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -998- DISPLAY 'PERIODO INICIAL     = ' V0RELA-PERI-INICIAL */
                _.Display($"PERIODO INICIAL     = {V0RELA_PERI_INICIAL}");

                /*" -1000- DISPLAY 'PERIODO FINAL       = ' V0RELA-PERI-FINAL. */
                _.Display($"PERIODO FINAL       = {V0RELA_PERI_FINAL}");
            }


            /*" -1001- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1002- MOVE 'SIM' TO WFIM-V0RELATORIOS */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS);

                /*" -1003- ELSE */
            }
            else
            {


                /*" -1004- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1005- DISPLAY 'PROBLEMAS ACESSO V0RELATORIOS....' */
                    _.Display($"PROBLEMAS ACESSO V0RELATORIOS....");

                    /*" -1005- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -991- EXEC SQL FETCH V0RELATORIOS INTO :V0RELA-PERI-INICIAL , :V0RELA-PERI-FINAL END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V0RELA_PERI_INICIAL, V0RELA_PERI_INICIAL);
                _.Move(V0RELATORIOS.V0RELA_PERI_FINAL, V0RELA_PERI_FINAL);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_FETCH_V0RELATORIOS*/

        [StopWatch]
        /*" M-0000-00-DELETE-V0RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1015- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL);

            /*" -1020- PERFORM M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1024- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1025- DISPLAY 'PROBLEMAS DELETE V0RELATORIOS....' */
                _.Display($"PROBLEMAS DELETE V0RELATORIOS....");

                /*" -1025- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1020- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0822B' AND IDSISTEM = 'SI' END-EXEC. */

            var m_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(m_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_DELETE_V0RELATORIOS*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1036- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1037- DISPLAY ' ' */
                _.Display($" ");

                /*" -1038- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1039- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0822B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0822B  *");

                /*" -1040- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1041- DISPLAY ' ' */
                _.Display($" ");

                /*" -1042- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.W_ACUMULADORES.WABEND.WNR_EXEC_SQL}");

                /*" -1043- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.W_ACUMULADORES.WABEND.WSQLCODE);

                /*" -1044- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.W_ACUMULADORES.WABEND.WSQLCODE1);

                /*" -1045- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.W_ACUMULADORES.WABEND.WSQLCODE2);

                /*" -1046- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.W_ACUMULADORES.WSQLCODE3);

                /*" -1048- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.W_ACUMULADORES.WABEND);
            }


            /*" -1049- IF W-CHAVE-ON-1-CEDIDO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_CEDIDO == "NAO")
            {

                /*" -1051- CLOSE SICEDIDO. */
                SICEDIDO.Close();
            }


            /*" -1052- IF W-CHAVE-ON-1-ACEITO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ON_1_ACEITO == "NAO")
            {

                /*" -1054- CLOSE SIACEITO. */
                SIACEITO.Close();
            }


            /*" -1054- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1055- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1057- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1057- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}