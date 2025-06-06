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
using Sias.Sinistro.DB2.SI0140B;

namespace Code
{
    public class SI0140B
    {
        public bool IsCall { get; set; }

        public SI0140B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0140B                             *      */
        /*"      *   ANALISTA ............... HEIDER COELHO                       *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JANEIRO / 98                        *      */
        /*"      *   FUNCAO ................. EMITE A RELACAO DE SINISTROS        *      */
        /*"      *       AVISADOS NO DIA, SOLICITADO PELO ON-LINE.                *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO - ANO 2000          CONSEDA4           05/06/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR JO0800)                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SI0140BR { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0140BR
        {
            get
            {
                _.Move(REG_SI0140BR, _SI0140BR); VarBasis.RedefinePassValue(REG_SI0140BR, _SI0140BR, REG_SI0140BR); return _SI0140BR;
            }
        }
        /*"01                  REG-SI0140BR.*/
        public SI0140B_REG_SI0140BR REG_SI0140BR { get; set; } = new SI0140B_REG_SI0140BR();
        public class SI0140B_REG_SI0140BR : VarBasis
        {
            /*"      05            LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1SIST-DTMOVABE              PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SIST-DTCURRENT             PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0MEST-FONTE                PIC S9(04) COMP VALUE +0.*/
        public IntBasis V0MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-RAMO                 PIC S9(04) COMP VALUE +0.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-CODCAU               PIC S9(04) COMP VALUE +0.*/
        public IntBasis V0MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-SITUACAO             PIC  X(01).*/
        public StringBasis V0MEST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-NUM-APOLICE          PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NUM-APOL-SINISTRO    PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0SINI-DESCAU               PIC  X(40).*/
        public StringBasis V0SINI_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0AUTO-PROPRIET             PIC  X(40).*/
        public StringBasis V0AUTO_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0AUTO1-NUM-ITEM            PIC S9(09) COMP VALUE +0.*/
        public IntBasis V0AUTO1_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HIST-VAL-OPERACAO         PIC S9(015)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0HIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(2)"), 2);
        /*"01           AREA-DE-WORK.*/
        public SI0140B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0140B_AREA_DE_WORK();
        public class SI0140B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE               PIC  9(009)     VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  WFONTE-ANT                PIC S9(004)     VALUE ZEROS.*/
            public IntBasis WFONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WRAMO-ANT                 PIC S9(004)     VALUE +0 COMP.*/
            public IntBasis WRAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  W-CHAVES-FIM-ARQUIVO.*/
            public SI0140B_W_CHAVES_FIM_ARQUIVO W_CHAVES_FIM_ARQUIVO { get; set; } = new SI0140B_W_CHAVES_FIM_ARQUIVO();
            public class SI0140B_W_CHAVES_FIM_ARQUIVO : VarBasis
            {
                /*"      10  WFIM-MESTHIST          PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_MESTHIST { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  05  W-AC-LINHAS               PIC  9(002)     VALUE  80.*/
            }
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05  W-AC-PAGINA               PIC  9(004)     VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  W-AC-VAL-OPERACAO         PIC S9(13)V99   COMP-3 VALUE +0.*/
            public DoubleBasis W_AC_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05  W-QTD-SINISTROS           PIC  9(06)      VALUE ZEROS.*/
            public IntBasis W_QTD_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0140B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0140B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0140B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0140B_FILLER_0 : VarBasis
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
                /*"  05         W-DATA-1.*/

                public _REDEF_SI0140B_FILLER_0()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0140B_W_DATA_1 W_DATA_1 { get; set; } = new SI0140B_W_DATA_1();
            public class SI0140B_W_DATA_1 : VarBasis
            {
                /*"    10       W-AA-DATA-1        PIC  9(004)     VALUE ZEROS.*/
                public IntBasis W_AA_DATA_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER             PIC  X(001)     VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       W-MM-DATA-1        PIC  9(002)     VALUE ZEROS.*/
                public IntBasis W_MM_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER             PIC  X(001)     VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       W-DD-DATA-1        PIC  9(002)     VALUE ZEROS.*/
                public IntBasis W_DD_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-CURR.*/
            }
            public SI0140B_WHORA_CURR WHORA_CURR { get; set; } = new SI0140B_WHORA_CURR();
            public class SI0140B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR      PIC  9(002)     VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR      PIC  9(002)     VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WK-HORA-2.*/
            }
            public SI0140B_WK_HORA_2 WK_HORA_2 { get; set; } = new SI0140B_WK_HORA_2();
            public class SI0140B_WK_HORA_2 : VarBasis
            {
                /*"     10      WK-HH-2            PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_HH_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLE              PIC X(001)     VALUE ':'.*/
                public StringBasis FILLE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10      WK-MM-2            PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_MM_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLE              PIC X(001)     VALUE ':'.*/
                public StringBasis FILLE_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10      WK-SS-2            PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_SS_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   LC01.*/
            }
            public SI0140B_LC01 LC01 { get; set; } = new SI0140B_LC01();
            public class SI0140B_LC01 : VarBasis
            {
                /*"    10 LC01-RELATOR             PIC X(010) VALUE 'SI0140B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0140B.1");
                /*"    10 FILLER                   PIC X(037) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"    10 LC01-EMPRESA             PIC X(038) VALUE      'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
                /*"    10 FILLER                   PIC X(031) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"    10 FILLER                   PIC X(013) VALUE 'PAGINA:'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA:");
                /*"    10 LC01-PAGINA              PIC 999.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"  05   LC02.*/
            }
            public SI0140B_LC02 LC02 { get; set; } = new SI0140B_LC02();
            public class SI0140B_LC02 : VarBasis
            {
                /*"    10 FILLER                        PIC  X(46)     VALUE SPACES*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"");
                /*"    10 FILLER                        PIC  X(27)     VALUE            '** SINISTROS AVISADOS EM - '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"** SINISTROS AVISADOS EM - ");
                /*"    10 LC02-DD-DTMOVABE              PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC02_DD_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10 FILLER                        PIC  X(01)     VALUE '/'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LC02-MM-DTMOVABE              PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC02_MM_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10 FILLER                        PIC  X(01)     VALUE '/'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LC02-AA-DTMOVABE              PIC  9(04)     VALUE ZEROS.*/
                public IntBasis LC02_AA_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    10 FILLER                        PIC  X(03)     VALUE ' **'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" **");
                /*"    10 FILLER                        PIC  X(30)     VALUE SPACES*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    10 FILLER                        PIC  X(06)     VALUE       'DATA'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"DATA");
                /*"    10 LC02-DD-DATA                  PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC02_DD_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10 FILLER                        PIC  X(01)     VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LC02-MM-DATA                  PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC02_MM_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10 FILLER                        PIC  X(01)     VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    10 LC02-AA-DATA                  PIC  9(04)     VALUE ZEROS.*/
                public IntBasis LC02_AA_DATA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  05   LC03.*/
            }
            public SI0140B_LC03 LC03 { get; set; } = new SI0140B_LC03();
            public class SI0140B_LC03 : VarBasis
            {
                /*"    10 FILLER                        PIC  X(116)    VALUE SPACES*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "116", "X(116)"), @"");
                /*"    10 FILLER                        PIC  X(08)     VALUE       'HORA  : '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"HORA  : ");
                /*"    10 LC03-HH-HORA                  PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC03_HH_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10 FILLER                        PIC  X(01)     VALUE ':'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"    10 LC03-MM-HORA                  PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC03_MM_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10 FILLER                        PIC  X(01)     VALUE ':'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"    10 LC03-SS-HORA                  PIC  9(02)     VALUE ZEROS.*/
                public IntBasis LC03_SS_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05    LC04.*/
            }
            public SI0140B_LC04 LC04 { get; set; } = new SI0140B_LC04();
            public class SI0140B_LC04 : VarBasis
            {
                /*"    10  FILLER                       PIC  X(132)   VALUE ALL '-'*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05    LC05.*/
            }
            public SI0140B_LC05 LC05 { get; set; } = new SI0140B_LC05();
            public class SI0140B_LC05 : VarBasis
            {
                /*"    10  FILLER                   PIC  X(05) VALUE        'FONTE'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(04) VALUE        'RAMO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"RAMO");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(05) VALUE        'CAUSA'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CAUSA");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(40) VALUE        'DESCRICAO DA CAUSA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"DESCRICAO DA CAUSA");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(13) VALUE        'APOLICE      '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"APOLICE      ");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(13) VALUE        'SINISTRO     '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SINISTRO     ");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(04) VALUE        'ITEM'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"ITEM");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(09) VALUE        'SITUACAO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SITUACAO");
                /*"    10  FILLER                   PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  FILLER                   PIC  X(20) VALUE        '        VAL. AVISADO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"        VAL. AVISADO");
                /*"  05    LC06.*/
            }
            public SI0140B_LC06 LC06 { get; set; } = new SI0140B_LC06();
            public class SI0140B_LC06 : VarBasis
            {
                /*"    10  FILLER                       PIC  X(20) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"    10  FILLER                       PIC  X(40) VALUE        'SEGURADO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"SEGURADO");
                /*"    10  FILLER                       PIC  X(72) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "72", "X(72)"), @"");
                /*"  05    LD01.*/
            }
            public SI0140B_LD01 LD01 { get; set; } = new SI0140B_LD01();
            public class SI0140B_LD01 : VarBasis
            {
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-FONTE                    PIC  Z99.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
                /*"    10  LD01-FONTE-R                  REDEFINES     LD01-FONTE                                      PIC  X(03).*/
                private _REDEF_StringBasis _ld01_fonte_r { get; set; }
                public _REDEF_StringBasis LD01_FONTE_R
                {
                    get { _ld01_fonte_r = new _REDEF_StringBasis(new PIC("X", "03", "X(03).")); ; _.Move(LD01_FONTE, _ld01_fonte_r); VarBasis.RedefinePassValue(LD01_FONTE, _ld01_fonte_r, LD01_FONTE); _ld01_fonte_r.ValueChanged += () => { _.Move(_ld01_fonte_r, LD01_FONTE); }; return _ld01_fonte_r; }
                    set { VarBasis.RedefinePassValue(value, _ld01_fonte_r, LD01_FONTE); }
                }  //Redefines
                /*"    10  FILLER                        PIC  X(04)    VALUE SPACES*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    10  LD01-RAMO                     PIC  9(02)    VALUE ZEROS.*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10  LD01-RAMO-R                   REDEFINES     LD01-RAMO                                      PIC  X(02).*/
                private _REDEF_StringBasis _ld01_ramo_r { get; set; }
                public _REDEF_StringBasis LD01_RAMO_R
                {
                    get { _ld01_ramo_r = new _REDEF_StringBasis(new PIC("X", "02", "X(02).")); ; _.Move(LD01_RAMO, _ld01_ramo_r); VarBasis.RedefinePassValue(LD01_RAMO, _ld01_ramo_r, LD01_RAMO); _ld01_ramo_r.ValueChanged += () => { _.Move(_ld01_ramo_r, LD01_RAMO); }; return _ld01_ramo_r; }
                    set { VarBasis.RedefinePassValue(value, _ld01_ramo_r, LD01_RAMO); }
                }  //Redefines
                /*"    10  FILLER                        PIC  X(05)    VALUE SPACES*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"    10  LD01-CODCAU                   PIC  9(02)    VALUE ZEROS.*/
                public IntBasis LD01_CODCAU { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-DESCAU                   PIC  X(40)    VALUE SPACES*/
                public StringBasis LD01_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-NUM-APOLICE              PIC  9(13)    VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-NUM-APOL-SINISTRO        PIC  9(13)    VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-NUM-ITEM                 PIC  9(04)    VALUE ZEROS.*/
                public IntBasis LD01_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-SITUACAO                 PIC  X(09)    VALUE SPACES*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LD01-VAL-OPERACAO             PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05    LD02.*/
            }
            public SI0140B_LD02 LD02 { get; set; } = new SI0140B_LD02();
            public class SI0140B_LD02 : VarBasis
            {
                /*"    10  FILLER                        PIC  X(05)    VALUE SPACES*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"    10  LD02-DTMOVTO                  PIC  X(10)    VALUE SPACES*/
                public StringBasis LD02_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    10  FILLER                        PIC  X(05)    VALUE SPACES*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"    10  LD02-PROPRIET                 PIC  X(40)    VALUE SPACES*/
                public StringBasis LD02_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    10  FILLER                        PIC  X(72)    VALUE SPACES*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "72", "X(72)"), @"");
                /*"  05    LT01.*/
            }
            public SI0140B_LT01 LT01 { get; set; } = new SI0140B_LT01();
            public class SI0140B_LT01 : VarBasis
            {
                /*"    10  FILLER                        PIC  X(66)    VALUE SPACES*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "66", "X(66)"), @"");
                /*"    10  FILLER                        PIC  X(17)    VALUE       'TOTAL DA FONTE - '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"TOTAL DA FONTE - ");
                /*"    10  LT01-FONTE                    PIC  Z99.*/
                public IntBasis LT01_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "Z99."));
                /*"    10  FILLER                        PIC  X(15)    VALUE       ' - QTD. E VALOR'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @" - QTD. E VALOR");
                /*"    10  FILLER                        PIC  X(03)    VALUE SPACES*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    10  LT01-QTD-SINISTROS            PIC  ZZZ.999.*/
                public IntBasis LT01_QTD_SINISTROS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    10  FILLER                        PIC  X(02)    VALUE SPACES*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10  LT01-VALOR-SINISTROS          PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VALOR_SINISTROS { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WABEND.*/
            public SI0140B_WABEND WABEND { get; set; } = new SI0140B_WABEND();
            public class SI0140B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(007) VALUE           'SI0140B'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0140B");
                /*"    10      FILLER              PIC  X(030) VALUE           ' *** ERRO  EXEC SQL  NUMERO = '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" *** ERRO  EXEC SQL  NUMERO = ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    10      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    10      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10      FILLER              PIC  X(014) VALUE           ' SQLCODE1= '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" SQLCODE1= ");
                /*"    10      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    10      FILLER              PIC  X(014) VALUE           ' SQLCODE2= '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" SQLCODE2= ");
                /*"    10      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public SI0140B_MESTHIST MESTHIST { get; set; } = new SI0140B_MESTHIST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0140BR_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0140BR.SetFile(SI0140BR_FILE_NAME_P);

                /*" -318- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -320- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -322- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -325- MOVE 'NAO' TO WFIM-MESTHIST. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_MESTHIST);

                /*" -326- PERFORM 100-00-DECLARE-MESTHIST THRU 100-00-EXIT. */

                M_100_00_DECLARE_MESTHIST(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_00_EXIT*/


                /*" -328- PERFORM 110-00-FETCH-MESTHIST THRU 110-00-EXIT. */

                M_110_00_FETCH_MESTHIST(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_00_EXIT*/


                /*" -329- IF WFIM-MESTHIST EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_MESTHIST == "SIM")
                {

                    /*" -330- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -331- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -332- DISPLAY '//     ==>     SI0140B      <==        //' */
                    _.Display($"//     ==>     SI0140B      <==        //");

                    /*" -333- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -334- DISPLAY '// ==>  NAO FORAM ENCONTRADOS      <== //' */
                    _.Display($"// ==>  NAO FORAM ENCONTRADOS      <== //");

                    /*" -335- DISPLAY '// ==>  SINISTROS AVISADOS PARA    <== //' */
                    _.Display($"// ==>  SINISTROS AVISADOS PARA    <== //");

                    /*" -336- DISPLAY '// ==>  O DIA SOLICITADO.          <== //' */
                    _.Display($"// ==>  O DIA SOLICITADO.          <== //");

                    /*" -337- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -338- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -340- GO TO R0000-99-ENCERRA. */

                    R0000_99_ENCERRA(); //GOTO
                    return Result;
                }


                /*" -342- OPEN OUTPUT SI0140BR. */
                SI0140BR.Open(REG_SI0140BR);

                /*" -343- PERFORM 200-00-MONTA-CABECALHO THRU 200-00-EXIT. */

                M_200_00_MONTA_CABECALHO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_00_EXIT*/


                /*" -346- PERFORM M-300-00-PROCESSA-MESTHIST THRU 300-00-EXIT UNTIL (WFIM-MESTHIST EQUAL 'SIM' ). */

                while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_MESTHIST == "SIM")))
                {

                    M_300_00_PROCESSA_MESTHIST(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_00_EXIT*/

                }

                /*" -348- CLOSE SI0140BR. */
                SI0140BR.Close();

                /*" -349- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -349- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -351- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -352- DISPLAY 'ERRO ACESSO COMMIT' */
                    _.Display($"ERRO ACESSO COMMIT");

                    /*" -352- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-99-ENCERRA */
        private void R0000_99_ENCERRA(bool isPerform = false)
        {
            /*" -358- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -359- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -360- DISPLAY '//     ==>     SI0140B      <==        //' */
            _.Display($"//     ==>     SI0140B      <==        //");

            /*" -361- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -362- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -363- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -364- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -364- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-100-00-DECLARE-MESTHIST */
        private void M_100_00_DECLARE_MESTHIST(bool isPerform = false)
        {
            /*" -371- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -403- PERFORM M_100_00_DECLARE_MESTHIST_DB_DECLARE_1 */

            M_100_00_DECLARE_MESTHIST_DB_DECLARE_1();

            /*" -406- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -407- DISPLAY 'R0100- PROBLEMA NO DECLARE DA V0MEST-V0HISTSINI ' */
                _.Display($"R0100- PROBLEMA NO DECLARE DA V0MEST-V0HISTSINI ");

                /*" -409- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -409- PERFORM M_100_00_DECLARE_MESTHIST_DB_OPEN_1 */

            M_100_00_DECLARE_MESTHIST_DB_OPEN_1();

            /*" -412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -413- DISPLAY 'R0100- PROBLEMAS OPEN V0MEST-V0HISTSINI' */
                _.Display($"R0100- PROBLEMAS OPEN V0MEST-V0HISTSINI");

                /*" -413- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-00-DECLARE-MESTHIST-DB-DECLARE-1 */
        public void M_100_00_DECLARE_MESTHIST_DB_DECLARE_1()
        {
            /*" -403- EXEC SQL DECLARE MESTHIST CURSOR FOR SELECT M.FONTE , M.RAMO , M.CODCAU , M.SITUACAO , S.DESCAU , M.NUM_APOLICE , M.NUM_APOL_SINISTRO , B.NUM_ITEM , H.VAL_OPERACAO , D.DTMOVABE , CURRENT DATE FROM SEGUROS.V0MESTSINI M, SEGUROS.V0HISTSINI H, SEGUROS.V0SINISTRO_AUTO1 B, SEGUROS.V0SINICAUSA S, SEGUROS.V1SISTEMA D WHERE D.IDSISTEM = 'SI' AND M.NUM_APOLICE BETWEEN 0103100000000 AND 0103199999999 AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DTMOVTO = D.DTMOVABE AND H.OPERACAO = 101 AND B.NUM_APOLICE = M.NUM_APOLICE AND B.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND S.RAMO = M.RAMO AND S.CODCAU = M.CODCAU ORDER BY M.FONTE , M.RAMO , M.CODCAU , M.NUM_APOLICE , M.NUM_APOL_SINISTRO END-EXEC. */
            MESTHIST = new SI0140B_MESTHIST(false);
            string GetQuery_MESTHIST()
            {
                var query = @$"SELECT M.FONTE
							, 
							M.RAMO
							, 
							M.CODCAU
							, 
							M.SITUACAO
							, 
							S.DESCAU
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							B.NUM_ITEM
							, 
							H.VAL_OPERACAO
							, 
							D.DTMOVABE
							, 
							CURRENT DATE 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0HISTSINI H
							, 
							SEGUROS.V0SINISTRO_AUTO1 B
							, 
							SEGUROS.V0SINICAUSA S
							, 
							SEGUROS.V1SISTEMA D 
							WHERE D.IDSISTEM = 'SI' 
							AND M.NUM_APOLICE BETWEEN 0103100000000 
							AND 0103199999999 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DTMOVTO = D.DTMOVABE 
							AND H.OPERACAO = 101 
							AND B.NUM_APOLICE = M.NUM_APOLICE 
							AND B.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND S.RAMO = M.RAMO 
							AND S.CODCAU = M.CODCAU 
							ORDER BY M.FONTE
							, 
							M.RAMO
							, 
							M.CODCAU
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO";

                return query;
            }
            MESTHIST.GetQueryEvent += GetQuery_MESTHIST;

        }

        [StopWatch]
        /*" M-100-00-DECLARE-MESTHIST-DB-OPEN-1 */
        public void M_100_00_DECLARE_MESTHIST_DB_OPEN_1()
        {
            /*" -409- EXEC SQL OPEN MESTHIST END-EXEC. */

            MESTHIST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_00_EXIT*/

        [StopWatch]
        /*" M-110-00-FETCH-MESTHIST */
        private void M_110_00_FETCH_MESTHIST(bool isPerform = false)
        {
            /*" -422- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -434- PERFORM M_110_00_FETCH_MESTHIST_DB_FETCH_1 */

            M_110_00_FETCH_MESTHIST_DB_FETCH_1();

            /*" -437- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -438- MOVE 'SIM' TO WFIM-MESTHIST */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_MESTHIST);

                /*" -438- PERFORM M_110_00_FETCH_MESTHIST_DB_CLOSE_1 */

                M_110_00_FETCH_MESTHIST_DB_CLOSE_1();

                /*" -440- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -441- DISPLAY 'PROBLEMAS CLOSE DA V0MEST-V0HISTSINI' */
                    _.Display($"PROBLEMAS CLOSE DA V0MEST-V0HISTSINI");

                    /*" -443- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -445- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -446- DISPLAY 'PROBLEMAS FETCH V0MEST-V0HISTSINI ' */
                _.Display($"PROBLEMAS FETCH V0MEST-V0HISTSINI ");

                /*" -446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-110-00-FETCH-MESTHIST-DB-FETCH-1 */
        public void M_110_00_FETCH_MESTHIST_DB_FETCH_1()
        {
            /*" -434- EXEC SQL FETCH MESTHIST INTO :V0MEST-FONTE , :V0MEST-RAMO , :V0MEST-CODCAU , :V0MEST-SITUACAO , :V0SINI-DESCAU , :V0MEST-NUM-APOLICE , :V0MEST-NUM-APOL-SINISTRO , :V0AUTO1-NUM-ITEM , :V0HIST-VAL-OPERACAO , :V1SIST-DTMOVABE , :V1SIST-DTCURRENT END-EXEC. */

            if (MESTHIST.Fetch())
            {
                _.Move(MESTHIST.V0MEST_FONTE, V0MEST_FONTE);
                _.Move(MESTHIST.V0MEST_RAMO, V0MEST_RAMO);
                _.Move(MESTHIST.V0MEST_CODCAU, V0MEST_CODCAU);
                _.Move(MESTHIST.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(MESTHIST.V0SINI_DESCAU, V0SINI_DESCAU);
                _.Move(MESTHIST.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(MESTHIST.V0MEST_NUM_APOL_SINISTRO, V0MEST_NUM_APOL_SINISTRO);
                _.Move(MESTHIST.V0AUTO1_NUM_ITEM, V0AUTO1_NUM_ITEM);
                _.Move(MESTHIST.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
                _.Move(MESTHIST.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(MESTHIST.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }

        }

        [StopWatch]
        /*" M-110-00-FETCH-MESTHIST-DB-CLOSE-1 */
        public void M_110_00_FETCH_MESTHIST_DB_CLOSE_1()
        {
            /*" -438- EXEC SQL CLOSE MESTHIST END-EXEC */

            MESTHIST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_00_EXIT*/

        [StopWatch]
        /*" M-200-00-MONTA-CABECALHO */
        private void M_200_00_MONTA_CABECALHO(bool isPerform = false)
        {
            /*" -454- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -455- MOVE WDATA-DD-CURR TO LC02-DD-DATA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.LC02.LC02_DD_DATA);

            /*" -456- MOVE WDATA-MM-CURR TO LC02-MM-DATA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.LC02.LC02_MM_DATA);

            /*" -458- MOVE WDATA-AA-CURR TO LC02-AA-DATA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.LC02.LC02_AA_DATA);

            /*" -459- MOVE V1SIST-DTMOVABE TO W-DATA-1. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.W_DATA_1);

            /*" -460- MOVE W-DD-DATA-1 TO LC02-DD-DTMOVABE. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.LC02.LC02_DD_DTMOVABE);

            /*" -461- MOVE W-MM-DATA-1 TO LC02-MM-DTMOVABE. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.LC02.LC02_MM_DTMOVABE);

            /*" -463- MOVE W-AA-DATA-1 TO LC02-AA-DTMOVABE. */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.LC02.LC02_AA_DTMOVABE);

            /*" -464- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -465- MOVE WHORA-HH-CURR TO LC03-HH-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.LC03.LC03_HH_HORA);

            /*" -466- MOVE WHORA-MM-CURR TO LC03-MM-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.LC03.LC03_MM_HORA);

            /*" -466- MOVE WHORA-SS-CURR TO LC03-SS-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.LC03.LC03_SS_HORA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_00_EXIT*/

        [StopWatch]
        /*" M-300-00-PROCESSA-MESTHIST */
        private void M_300_00_PROCESSA_MESTHIST(bool isPerform = false)
        {
            /*" -474- MOVE V0MEST-FONTE TO WFONTE-ANT. */
            _.Move(V0MEST_FONTE, AREA_DE_WORK.WFONTE_ANT);

            /*" -477- MOVE 0 TO W-AC-VAL-OPERACAO W-QTD-SINISTROS. */
            _.Move(0, AREA_DE_WORK.W_AC_VAL_OPERACAO, AREA_DE_WORK.W_QTD_SINISTROS);

            /*" -479- MOVE 99 TO W-AC-LINHAS. */
            _.Move(99, AREA_DE_WORK.W_AC_LINHAS);

            /*" -483- PERFORM 310-00-PROCESSA-FONTE THRU 310-00-EXIT UNTIL (WFIM-MESTHIST EQUAL 'SIM' ) OR (V0MEST-FONTE NOT EQUAL WFONTE-ANT). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_MESTHIST == "SIM") || (V0MEST_FONTE != AREA_DE_WORK.WFONTE_ANT)))
            {

                M_310_00_PROCESSA_FONTE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_00_EXIT*/

            }

            /*" -484- MOVE WFONTE-ANT TO LT01-FONTE. */
            _.Move(AREA_DE_WORK.WFONTE_ANT, AREA_DE_WORK.LT01.LT01_FONTE);

            /*" -485- MOVE W-AC-VAL-OPERACAO TO LT01-VALOR-SINISTROS. */
            _.Move(AREA_DE_WORK.W_AC_VAL_OPERACAO, AREA_DE_WORK.LT01.LT01_VALOR_SINISTROS);

            /*" -486- MOVE W-QTD-SINISTROS TO LT01-QTD-SINISTROS. */
            _.Move(AREA_DE_WORK.W_QTD_SINISTROS, AREA_DE_WORK.LT01.LT01_QTD_SINISTROS);

            /*" -486- WRITE REG-SI0140BR FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_00_EXIT*/

        [StopWatch]
        /*" M-310-00-PROCESSA-FONTE */
        private void M_310_00_PROCESSA_FONTE(bool isPerform = false)
        {
            /*" -494- PERFORM 320-00-NOME-PROPRIETARIO THRU 320-00-EXIT. */

            M_320_00_NOME_PROPRIETARIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_00_EXIT*/


            /*" -495- IF V0MEST-RAMO NOT EQUAL WRAMO-ANT */

            if (V0MEST_RAMO != AREA_DE_WORK.WRAMO_ANT)
            {

                /*" -496- MOVE 99 TO W-AC-LINHAS */
                _.Move(99, AREA_DE_WORK.W_AC_LINHAS);

                /*" -498- MOVE V0MEST-RAMO TO WRAMO-ANT. */
                _.Move(V0MEST_RAMO, AREA_DE_WORK.WRAMO_ANT);
            }


            /*" -499- MOVE V0MEST-RAMO TO LD01-RAMO. */
            _.Move(V0MEST_RAMO, AREA_DE_WORK.LD01.LD01_RAMO);

            /*" -500- MOVE V0MEST-FONTE TO LD01-FONTE. */
            _.Move(V0MEST_FONTE, AREA_DE_WORK.LD01.LD01_FONTE);

            /*" -501- MOVE V0MEST-CODCAU TO LD01-CODCAU. */
            _.Move(V0MEST_CODCAU, AREA_DE_WORK.LD01.LD01_CODCAU);

            /*" -502- MOVE V0SINI-DESCAU TO LD01-DESCAU. */
            _.Move(V0SINI_DESCAU, AREA_DE_WORK.LD01.LD01_DESCAU);

            /*" -503- MOVE V0MEST-NUM-APOLICE TO LD01-NUM-APOLICE. */
            _.Move(V0MEST_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_NUM_APOLICE);

            /*" -504- MOVE V0MEST-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO. */
            _.Move(V0MEST_NUM_APOL_SINISTRO, AREA_DE_WORK.LD01.LD01_NUM_APOL_SINISTRO);

            /*" -505- MOVE V0AUTO1-NUM-ITEM TO LD01-NUM-ITEM. */
            _.Move(V0AUTO1_NUM_ITEM, AREA_DE_WORK.LD01.LD01_NUM_ITEM);

            /*" -506- MOVE V0HIST-VAL-OPERACAO TO LD01-VAL-OPERACAO. */
            _.Move(V0HIST_VAL_OPERACAO, AREA_DE_WORK.LD01.LD01_VAL_OPERACAO);

            /*" -508- MOVE V0AUTO-PROPRIET TO LD02-PROPRIET. */
            _.Move(V0AUTO_PROPRIET, AREA_DE_WORK.LD02.LD02_PROPRIET);

            /*" -509- IF V0MEST-SITUACAO EQUAL '2' */

            if (V0MEST_SITUACAO == "2")
            {

                /*" -510- MOVE 'CANCELADO' TO LD01-SITUACAO */
                _.Move("CANCELADO", AREA_DE_WORK.LD01.LD01_SITUACAO);

                /*" -511- ELSE */
            }
            else
            {


                /*" -513- MOVE ' ' TO LD01-SITUACAO. */
                _.Move(" ", AREA_DE_WORK.LD01.LD01_SITUACAO);
            }


            /*" -514- IF W-AC-LINHAS GREATER 60 */

            if (AREA_DE_WORK.W_AC_LINHAS > 60)
            {

                /*" -516- PERFORM 400-00-IMPRIME-CABECALHO THRU 400-00-EXIT. */

                M_400_00_IMPRIME_CABECALHO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_00_EXIT*/

            }


            /*" -517- WRITE REG-SI0140BR FROM LD01 AFTER 2. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -519- WRITE REG-SI0140BR FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -520- ADD V0HIST-VAL-OPERACAO TO W-AC-VAL-OPERACAO. */
            AREA_DE_WORK.W_AC_VAL_OPERACAO.Value = AREA_DE_WORK.W_AC_VAL_OPERACAO + V0HIST_VAL_OPERACAO;

            /*" -521- ADD 1 TO W-QTD-SINISTROS. */
            AREA_DE_WORK.W_QTD_SINISTROS.Value = AREA_DE_WORK.W_QTD_SINISTROS + 1;

            /*" -523- ADD 3 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 3;

            /*" -523- PERFORM 110-00-FETCH-MESTHIST THRU 110-00-EXIT. */

            M_110_00_FETCH_MESTHIST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_00_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_00_EXIT*/

        [StopWatch]
        /*" M-320-00-NOME-PROPRIETARIO */
        private void M_320_00_NOME_PROPRIETARIO(bool isPerform = false)
        {
            /*" -531- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -541- PERFORM M_320_00_NOME_PROPRIETARIO_DB_SELECT_1 */

            M_320_00_NOME_PROPRIETARIO_DB_SELECT_1();

            /*" -544- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -545- MOVE ALL 'X' TO V0AUTO-PROPRIET */
                _.MoveAll("X", V0AUTO_PROPRIET);

                /*" -546- DISPLAY '********  ERRO NO ACESSO DA V0AUTOAPOL *****' */
                _.Display($"********  ERRO NO ACESSO DA V0AUTOAPOL *****");

                /*" -547- DISPLAY 'APOLICE = ' V0MEST-NUM-APOLICE */
                _.Display($"APOLICE = {V0MEST_NUM_APOLICE}");

                /*" -549- DISPLAY 'ITEM    = ' V0AUTO1-NUM-ITEM. */
                _.Display($"ITEM    = {V0AUTO1_NUM_ITEM}");
            }


            /*" -551- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -552- DISPLAY 'R0310- PROBLEMA NO SELECT V0AUTOAPOL' */
                _.Display($"R0310- PROBLEMA NO SELECT V0AUTOAPOL");

                /*" -553- DISPLAY 'APOLICE = ' V0MEST-NUM-APOLICE */
                _.Display($"APOLICE = {V0MEST_NUM_APOLICE}");

                /*" -554- DISPLAY 'ITEM    = ' V0AUTO1-NUM-ITEM */
                _.Display($"ITEM    = {V0AUTO1_NUM_ITEM}");

                /*" -554- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-320-00-NOME-PROPRIETARIO-DB-SELECT-1 */
        public void M_320_00_NOME_PROPRIETARIO_DB_SELECT_1()
        {
            /*" -541- EXEC SQL SELECT DISTINCT A.PROPRIET INTO :V0AUTO-PROPRIET FROM SEGUROS.V0AUTOAPOL A WHERE A.NUM_APOLICE = :V0MEST-NUM-APOLICE AND A.NRITEM = :V0AUTO1-NUM-ITEM AND A.SITUACAO <> '2' ORDER BY A.PROPRIET END-EXEC. */

            var m_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1 = new M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1()
            {
                V0MEST_NUM_APOLICE = V0MEST_NUM_APOLICE.ToString(),
                V0AUTO1_NUM_ITEM = V0AUTO1_NUM_ITEM.ToString(),
            };

            var executed_1 = M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1.Execute(m_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AUTO_PROPRIET, V0AUTO_PROPRIET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_00_EXIT*/

        [StopWatch]
        /*" M-400-00-IMPRIME-CABECALHO */
        private void M_400_00_IMPRIME_CABECALHO(bool isPerform = false)
        {
            /*" -562- ADD 1 TO W-AC-PAGINA. */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -564- MOVE W-AC-PAGINA TO LC01-PAGINA. */
            _.Move(AREA_DE_WORK.W_AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -565- WRITE REG-SI0140BR FROM LC01 AFTER NEW-PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -566- WRITE REG-SI0140BR FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -567- WRITE REG-SI0140BR FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -568- WRITE REG-SI0140BR FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -569- WRITE REG-SI0140BR FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -570- WRITE REG-SI0140BR FROM LC06 AFTER 1. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -572- WRITE REG-SI0140BR FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0140BR);

            SI0140BR.Write(REG_SI0140BR.GetMoveValues().ToString());

            /*" -572- MOVE 7 TO W-AC-LINHAS. */
            _.Move(7, AREA_DE_WORK.W_AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_00_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -579- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -580- DISPLAY ' ' */
                _.Display($" ");

                /*" -581- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -582- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0140B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0140B  *");

                /*" -583- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -584- DISPLAY ' ' */
                _.Display($" ");

                /*" -585- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -586- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -587- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLCODE1);

                /*" -588- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLCODE2);

                /*" -589- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE3);

                /*" -591- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.WABEND);
            }


            /*" -591- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -592- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -596- CLOSE SI0140BR. */
            SI0140BR.Close();

            /*" -597- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -597- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}