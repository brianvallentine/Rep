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
using Sias.Sinistro.DB2.SI0109B;

namespace Code
{
    public class SI0109B
    {
        public bool IsCall { get; set; }

        public SI0109B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    APOLICE                           //      */
        /*"      * PROGRAMA             :    SI0109B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELACAO DE CAUSAS DE   //      */
        /*"      *                           SINISTROS                         //      */
        /*"      * ANALISTA/PROGRAMADOR :    PROCAS/FREDERICO                  //      */
        /*"      * DATA                 :    ABRIL/92                          //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0109M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0109M1
        {
            get
            {
                _.Move(REG_SI0109M1, _SI0109M1); VarBasis.RedefinePassValue(REG_SI0109M1, _SI0109M1, REG_SI0109M1); return _SI0109M1;
            }
        }
        /*"01  REG-SI0109M1.*/
        public SI0109B_REG_SI0109M1 REG_SI0109M1 { get; set; } = new SI0109B_REG_SI0109M1();
        public class SI0109B_REG_SI0109M1 : VarBasis
        {
            /*"    05          LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EMPRESA-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SISTEMA-DTMOVABE       PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SISTEMA-DTCURRENT      PIC  X(010).*/
        public StringBasis SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELATO-DTINIVIG        PIC  X(010).*/
        public StringBasis RELATO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELATO-DTTERVIG        PIC  X(010).*/
        public StringBasis RELATO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELATO-RAMO           PIC  S9(004)    COMP.*/
        public IntBasis RELATO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SINICAU-RAMO          PIC S9(004)       COMP.*/
        public IntBasis SINICAU_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SINICAU-CODCAU        PIC S9(004)       COMP.*/
        public IntBasis SINICAU_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SINICAU-DESCAU        PIC  X(040).*/
        public StringBasis SINICAU_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          TGERAMO-NOMERAMO        PIC  X(040).*/
        public StringBasis TGERAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          TGERAMO-RAMO          PIC S9(004)       COMP.*/
        public IntBasis TGERAMO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WRAMO-INI             PIC S9(004) COMP VALUE +0.*/
        public IntBasis WRAMO_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WRAMO-FIM             PIC S9(004) COMP VALUE +0.*/
        public IntBasis WRAMO_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              W.*/
        public SI0109B_W W { get; set; } = new SI0109B_W();
        public class SI0109B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0109B_LC01 LC01 { get; set; } = new SI0109B_LC01();
            public class SI0109B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC  X(009) VALUE 'SI0109B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0109B.1");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC01-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG            PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0109B_LC02 LC02 { get; set; } = new SI0109B_LC02();
            public class SI0109B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(050) VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    05          FILLER              PIC  X(055) VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0109B_LC03 LC03 { get; set; } = new SI0109B_LC03();
            public class SI0109B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04B.*/
            }
            public SI0109B_LC04B LC04B { get; set; } = new SI0109B_LC04B();
            public class SI0109B_LC04B : VarBasis
            {
                /*"    05          FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(045) VALUE               'RELACAO DE CAUSAS DE SINISTROS NO PERIODO DE '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"RELACAO DE CAUSAS DE SINISTROS NO PERIODO DE ");
                /*"    05          LC04B-DATAI.*/
                public SI0109B_LC04B_DATAI LC04B_DATAI { get; set; } = new SI0109B_LC04B_DATAI();
                public class SI0109B_LC04B_DATAI : VarBasis
                {
                    /*"      07        LC04B-DDI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_DDI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-MMI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_MMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-AAI           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04B_AAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(005) VALUE                ' ATE'.*/
                }
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ATE");
                /*"    05          LC04B-DATAT.*/
                public SI0109B_LC04B_DATAT LC04B_DATAT { get; set; } = new SI0109B_LC04B_DATAT();
                public class SI0109B_LC04B_DATAT : VarBasis
                {
                    /*"      07        LC04B-DDT           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_DDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-MMT           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_MMT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-AAT           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04B_AAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                }
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"  03            LC05.*/
            }
            public SI0109B_LC05 LC05 { get; set; } = new SI0109B_LC05();
            public class SI0109B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE                'RAMO - '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"RAMO - ");
                /*"    05          LC05-RAMO          PIC  9(003) VALUE ZEROS.*/
                public IntBasis LC05_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC05-NOMERAMO        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC05_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC06.*/
            }
            public SI0109B_LC06 LC06 { get; set; } = new SI0109B_LC06();
            public class SI0109B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(025) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(025) VALUE                                    'CODIGO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"CODIGO");
                /*"    05          FILLER              PIC  X(070) VALUE                                    'DESCRICAO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"DESCRICAO");
                /*"  03            LD01.*/
            }
            public SI0109B_LD01 LD01 { get; set; } = new SI0109B_LD01();
            public class SI0109B_LD01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(025) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          LD01-CODIGO         PIC  9(003) VALUE ZEROS.*/
                public IntBasis LD01_CODIGO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(022) VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05          LD01-DESCRICAO      PIC  X(060).*/
                public StringBasis LD01_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WFIM-TRELATO        PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELATO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TSINICAU       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TSINICAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0109B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_SI0109B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_SI0109B_FILLER_25(); _.Move(WDATA_CURR, _filler_25); VarBasis.RedefinePassValue(WDATA_CURR, _filler_25, WDATA_CURR); _filler_25.ValueChanged += () => { _.Move(_filler_25, WDATA_CURR); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0109B_FILLER_25 : VarBasis
            {
                /*"    05       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-CURR.*/

                public _REDEF_SI0109B_FILLER_25()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_26.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0109B_WHORA_CURR WHORA_CURR { get; set; } = new SI0109B_WHORA_CURR();
            public class SI0109B_WHORA_CURR : VarBasis
            {
                /*"    05          WHORA-HH-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SS-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-CC-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA-CABEC.*/
            }
            public SI0109B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0109B_WDATA_CABEC();
            public class SI0109B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0109B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0109B_WHORA_CABEC();
            public class SI0109B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA               PIC  X(010).*/
            }
            public StringBasis WDATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03            FILLER  REDEFINES   WDATA.*/
            private _REDEF_SI0109B_FILLER_32 _filler_32 { get; set; }
            public _REDEF_SI0109B_FILLER_32 FILLER_32
            {
                get { _filler_32 = new _REDEF_SI0109B_FILLER_32(); _.Move(WDATA, _filler_32); VarBasis.RedefinePassValue(WDATA, _filler_32, WDATA); _filler_32.ValueChanged += () => { _.Move(_filler_32, WDATA); }; return _filler_32; }
                set { VarBasis.RedefinePassValue(value, _filler_32, WDATA); }
            }  //Redefines
            public class _REDEF_SI0109B_FILLER_32 : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD            PIC  9(002).*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WLIDOS              PIC  9(007) VALUE ZEROS.*/

                public _REDEF_SI0109B_FILLER_32()
                {
                    WDATA_AA.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                    WDATA_MM.ValueChanged += OnValueChanged;
                    FILLER_34.ValueChanged += OnValueChanged;
                    WDATA_DD.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WLIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WLIDOS-REL          PIC  9(007) VALUE ZEROS.*/
            public IntBasis WLIDOS_REL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WIMPRES             PIC  9(007) VALUE ZEROS.*/
            public IntBasis WIMPRES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WCONT-PAG           PIC  S9(004) COMP VALUE +0.*/
            public IntBasis WCONT_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WCONT-LIN           PIC  S9(004) COMP VALUE +70.*/
            public IntBasis WCONT_LIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +70);
            /*"  03            WRAMO-ANT          PIC S9(004) COMP VALUE +0.*/
            public IntBasis WRAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WABEND.*/
            public SI0109B_WABEND WABEND { get; set; } = new SI0109B_WABEND();
            public class SI0109B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0109B'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0109B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0109B_LK_LINK LK_LINK { get; set; } = new SI0109B_LK_LINK();
        public class SI0109B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0109B_V1RELATSINI V1RELATSINI { get; set; } = new SI0109B_V1RELATSINI();
        public SI0109B_V1SINICAUSA V1SINICAUSA { get; set; } = new SI0109B_V1SINICAUSA();
        public SI0109B_V1RAMO V1RAMO { get; set; } = new SI0109B_V1RAMO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0109M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0109M1.SetFile(SI0109M1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -282- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -283- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -285- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -287- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -291- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -293- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -296- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -298- PERFORM 090-000-CURSOR-TRELATO. */

            M_090_000_CURSOR_TRELATO_SECTION();

            /*" -300- PERFORM 300-000-LER-TRELATO. */

            M_300_000_LER_TRELATO_SECTION();

            /*" -301- IF WFIM-TRELATO EQUAL 'S' */

            if (W.WFIM_TRELATO == "S")
            {

                /*" -302- DISPLAY 'SI0109B - NAO HOUVE PEDIDO DE EMISSAO' */
                _.Display($"SI0109B - NAO HOUVE PEDIDO DE EMISSAO");

                /*" -305- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -309- PERFORM 120-000-PROCESSA UNTIL WFIM-TRELATO EQUAL 'S' . */

            while (!(W.WFIM_TRELATO == "S"))
            {

                M_120_000_PROCESSA_SECTION();
            }

            /*" -309- PERFORM 600-000-ATUALIZA-TRELATO. */

            M_600_000_ATUALIZA_TRELATO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -316- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -316- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -329- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -330- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -331- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -332- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -335- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -339- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -342- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -344- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -345- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -346- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -347- ELSE */
            }
            else
            {


                /*" -348- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -348- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -339- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOM_EMP, V1EMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -367- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -367- OPEN OUTPUT SI0109M1. */
            SI0109M1.Open(REG_SI0109M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -382- MOVE '060' TO WNR-EXEC-SQL */
            _.Move("060", W.WABEND.WNR_EXEC_SQL);

            /*" -388- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -393- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -396- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -397- DISPLAY 'SI0109B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0109B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -399- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -400- MOVE SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(SISTEMA_DTCURRENT, W.WDATA_CURR);

            /*" -401- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.FILLER_25.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -402- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.FILLER_25.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -403- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.FILLER_25.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -403- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -393- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SISTEMA-DTMOVABE, :SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_DTCURRENT, SISTEMA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-TRELATO-SECTION */
        private void M_090_000_CURSOR_TRELATO_SECTION()
        {
            /*" -418- MOVE '090' TO WNR-EXEC-SQL */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -424- MOVE '090-000-CURSOR-TRELATO' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-TRELATO", W.WABEND.PARAGRAFO);

            /*" -434- PERFORM M_090_000_CURSOR_TRELATO_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELATO_DB_DECLARE_1();

            /*" -436- PERFORM M_090_000_CURSOR_TRELATO_DB_OPEN_1 */

            M_090_000_CURSOR_TRELATO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELATO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELATO_DB_DECLARE_1()
        {
            /*" -434- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, RAMO FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0109B' AND IDSISTEM = 'SI' AND DATA_SOLICITACAO = :SISTEMA-DTMOVABE ORDER BY RAMO, PERI_INICIAL, PERI_FINAL END-EXEC. */
            V1RELATSINI = new SI0109B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							RAMO 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'SI0109B' 
							AND IDSISTEM = 'SI' 
							AND DATA_SOLICITACAO = '{SISTEMA_DTMOVABE}' 
							ORDER BY RAMO
							, PERI_INICIAL
							, PERI_FINAL";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELATO-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELATO_DB_OPEN_1()
        {
            /*" -436- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-150-000-CURSOR-TSINICAU-DB-DECLARE-1 */
        public void M_150_000_CURSOR_TSINICAU_DB_DECLARE_1()
        {
            /*" -497- EXEC SQL DECLARE V1SINICAUSA CURSOR FOR SELECT RAMO, CODCAU, DESCAU FROM SEGUROS.V1SINICAUSA WHERE RAMO >= :WRAMO-INI AND RAMO <= :WRAMO-FIM ORDER BY RAMO, CODCAU END-EXEC. */
            V1SINICAUSA = new SI0109B_V1SINICAUSA(true);
            string GetQuery_V1SINICAUSA()
            {
                var query = @$"SELECT RAMO
							, 
							CODCAU
							, 
							DESCAU 
							FROM SEGUROS.V1SINICAUSA 
							WHERE RAMO >= '{WRAMO_INI}' 
							AND RAMO <= '{WRAMO_FIM}' 
							ORDER BY RAMO
							, CODCAU";

                return query;
            }
            V1SINICAUSA.GetQueryEvent += GetQuery_V1SINICAUSA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-SECTION */
        private void M_120_000_PROCESSA_SECTION()
        {
            /*" -455- MOVE '120-000-PROCESSA' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA", W.WABEND.PARAGRAFO);

            /*" -457- MOVE 'N' TO WFIM-TSINICAU. */
            _.Move("N", W.WFIM_TSINICAU);

            /*" -457- PERFORM 150-000-CURSOR-TSINICAU. */

            M_150_000_CURSOR_TSINICAU_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_120_010_LOOP */

            M_120_010_LOOP();

        }

        [StopWatch]
        /*" M-120-010-LOOP */
        private void M_120_010_LOOP(bool isPerform = false)
        {
            /*" -461- PERFORM 180-000-LER-TSINICAU */

            M_180_000_LER_TSINICAU_SECTION();

            /*" -462- IF WFIM-TSINICAU EQUAL 'N' */

            if (W.WFIM_TSINICAU == "N")
            {

                /*" -463- PERFORM 400-000-IMPRIME */

                M_400_000_IMPRIME_SECTION();

                /*" -466- GO TO 120-010-LOOP. */
                new Task(() => M_120_010_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -467- MOVE 70 TO WCONT-LIN. */
            _.Move(70, W.WCONT_LIN);

            /*" -469- MOVE 0 TO WCONT-PAG. */
            _.Move(0, W.WCONT_PAG);

            /*" -469- PERFORM 300-000-LER-TRELATO. */

            M_300_000_LER_TRELATO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-CURSOR-TSINICAU-SECTION */
        private void M_150_000_CURSOR_TSINICAU_SECTION()
        {
            /*" -483- MOVE '120' TO WNR-EXEC-SQL */
            _.Move("120", W.WABEND.WNR_EXEC_SQL);

            /*" -489- MOVE '120-000-CURSOR-TSINICAU' TO PARAGRAFO. */
            _.Move("120-000-CURSOR-TSINICAU", W.WABEND.PARAGRAFO);

            /*" -497- PERFORM M_150_000_CURSOR_TSINICAU_DB_DECLARE_1 */

            M_150_000_CURSOR_TSINICAU_DB_DECLARE_1();

            /*" -499- PERFORM M_150_000_CURSOR_TSINICAU_DB_OPEN_1 */

            M_150_000_CURSOR_TSINICAU_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-150-000-CURSOR-TSINICAU-DB-OPEN-1 */
        public void M_150_000_CURSOR_TSINICAU_DB_OPEN_1()
        {
            /*" -499- EXEC SQL OPEN V1SINICAUSA END-EXEC. */

            V1SINICAUSA.Open();

        }

        [StopWatch]
        /*" M-240-000-ACESSA-TGERAMO-DB-DECLARE-1 */
        public void M_240_000_ACESSA_TGERAMO_DB_DECLARE_1()
        {
            /*" -558- EXEC SQL DECLARE V1RAMO CURSOR FOR SELECT NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :TGERAMO-RAMO END-EXEC. */
            V1RAMO = new SI0109B_V1RAMO(true);
            string GetQuery_V1RAMO()
            {
                var query = @$"SELECT NOMERAMO 
							FROM SEGUROS.V1RAMO 
							WHERE 
							RAMO = '{TGERAMO_RAMO}'";

                return query;
            }
            V1RAMO.GetQueryEvent += GetQuery_V1RAMO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-180-000-LER-TSINICAU-SECTION */
        private void M_180_000_LER_TSINICAU_SECTION()
        {
            /*" -516- MOVE '180' TO WNR-EXEC-SQL */
            _.Move("180", W.WABEND.WNR_EXEC_SQL);

            /*" -522- MOVE '180-000-LER-TSINICAU' TO PARAGRAFO. */
            _.Move("180-000-LER-TSINICAU", W.WABEND.PARAGRAFO);

            /*" -526- PERFORM M_180_000_LER_TSINICAU_DB_FETCH_1 */

            M_180_000_LER_TSINICAU_DB_FETCH_1();

            /*" -529- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -529- PERFORM M_180_000_LER_TSINICAU_DB_CLOSE_1 */

                M_180_000_LER_TSINICAU_DB_CLOSE_1();

                /*" -531- MOVE 'S' TO WFIM-TSINICAU */
                _.Move("S", W.WFIM_TSINICAU);

                /*" -532- ELSE */
            }
            else
            {


                /*" -532- ADD 1 TO WLIDOS. */
                W.WLIDOS.Value = W.WLIDOS + 1;
            }


        }

        [StopWatch]
        /*" M-180-000-LER-TSINICAU-DB-FETCH-1 */
        public void M_180_000_LER_TSINICAU_DB_FETCH_1()
        {
            /*" -526- EXEC SQL FETCH V1SINICAUSA INTO :SINICAU-RAMO, :SINICAU-CODCAU, :SINICAU-DESCAU END-EXEC. */

            if (V1SINICAUSA.Fetch())
            {
                _.Move(V1SINICAUSA.SINICAU_RAMO, SINICAU_RAMO);
                _.Move(V1SINICAUSA.SINICAU_CODCAU, SINICAU_CODCAU);
                _.Move(V1SINICAUSA.SINICAU_DESCAU, SINICAU_DESCAU);
            }

        }

        [StopWatch]
        /*" M-180-000-LER-TSINICAU-DB-CLOSE-1 */
        public void M_180_000_LER_TSINICAU_DB_CLOSE_1()
        {
            /*" -529- EXEC SQL CLOSE V1SINICAUSA END-EXEC */

            V1SINICAUSA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-240-000-ACESSA-TGERAMO-SECTION */
        private void M_240_000_ACESSA_TGERAMO_SECTION()
        {
            /*" -548- MOVE '240-000-ACESSA-TGERAMO' TO PARAGRAFO. */
            _.Move("240-000-ACESSA-TGERAMO", W.WABEND.PARAGRAFO);

            /*" -550- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", W.WABEND.WNR_EXEC_SQL);

            /*" -553- MOVE SINICAU-RAMO TO TGERAMO-RAMO. */
            _.Move(SINICAU_RAMO, TGERAMO_RAMO);

            /*" -558- PERFORM M_240_000_ACESSA_TGERAMO_DB_DECLARE_1 */

            M_240_000_ACESSA_TGERAMO_DB_DECLARE_1();

            /*" -561- PERFORM M_240_000_ACESSA_TGERAMO_DB_OPEN_1 */

            M_240_000_ACESSA_TGERAMO_DB_OPEN_1();

            /*" -567- PERFORM M_240_000_ACESSA_TGERAMO_DB_FETCH_1 */

            M_240_000_ACESSA_TGERAMO_DB_FETCH_1();

            /*" -570- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -571- DISPLAY 'SI0109B  - NAO CONSTA RAMO CADASTRADA' */
                _.Display($"SI0109B  - NAO CONSTA RAMO CADASTRADA");

                /*" -572- DISPLAY 'RAMO = ' TGERAMO-RAMO */
                _.Display($"RAMO = {TGERAMO_RAMO}");

                /*" -574- MOVE SPACES TO TGERAMO-NOMERAMO. */
                _.Move("", TGERAMO_NOMERAMO);
            }


            /*" -574- PERFORM M_240_000_ACESSA_TGERAMO_DB_CLOSE_1 */

            M_240_000_ACESSA_TGERAMO_DB_CLOSE_1();

            /*" -578- MOVE TGERAMO-RAMO TO LC05-RAMO */
            _.Move(TGERAMO_RAMO, W.LC05.LC05_RAMO);

            /*" -578- MOVE TGERAMO-NOMERAMO TO LC05-NOMERAMO. */
            _.Move(TGERAMO_NOMERAMO, W.LC05.LC05_NOMERAMO);

        }

        [StopWatch]
        /*" M-240-000-ACESSA-TGERAMO-DB-OPEN-1 */
        public void M_240_000_ACESSA_TGERAMO_DB_OPEN_1()
        {
            /*" -561- EXEC SQL OPEN V1RAMO END-EXEC. */

            V1RAMO.Open();

        }

        [StopWatch]
        /*" M-240-000-ACESSA-TGERAMO-DB-FETCH-1 */
        public void M_240_000_ACESSA_TGERAMO_DB_FETCH_1()
        {
            /*" -567- EXEC SQL FETCH V1RAMO INTO :TGERAMO-NOMERAMO END-EXEC. */

            if (V1RAMO.Fetch())
            {
                _.Move(V1RAMO.TGERAMO_NOMERAMO, TGERAMO_NOMERAMO);
            }

        }

        [StopWatch]
        /*" M-240-000-ACESSA-TGERAMO-DB-CLOSE-1 */
        public void M_240_000_ACESSA_TGERAMO_DB_CLOSE_1()
        {
            /*" -574- EXEC SQL CLOSE V1RAMO END-EXEC. */

            V1RAMO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-300-000-LER-TRELATO-SECTION */
        private void M_300_000_LER_TRELATO_SECTION()
        {
            /*" -594- MOVE '300' TO WNR-EXEC-SQL */
            _.Move("300", W.WABEND.WNR_EXEC_SQL);

            /*" -600- MOVE '300-000-LER-TRELATO' TO PARAGRAFO. */
            _.Move("300-000-LER-TRELATO", W.WABEND.PARAGRAFO);

            /*" -604- PERFORM M_300_000_LER_TRELATO_DB_FETCH_1 */

            M_300_000_LER_TRELATO_DB_FETCH_1();

            /*" -607- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -607- PERFORM M_300_000_LER_TRELATO_DB_CLOSE_1 */

                M_300_000_LER_TRELATO_DB_CLOSE_1();

                /*" -609- MOVE 'S' TO WFIM-TRELATO */
                _.Move("S", W.WFIM_TRELATO);

                /*" -612- GO TO 300-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/ //GOTO
                return;
            }


            /*" -613- IF RELATO-RAMO EQUAL 0 */

            if (RELATO_RAMO == 0)
            {

                /*" -614- MOVE ZEROS TO WRAMO-INI */
                _.Move(0, WRAMO_INI);

                /*" -615- MOVE ALL '9' TO WRAMO-FIM */
                _.MoveAll("9", WRAMO_FIM);

                /*" -616- ELSE */
            }
            else
            {


                /*" -619- MOVE RELATO-RAMO TO WRAMO-INI WRAMO-FIM. */
                _.Move(RELATO_RAMO, WRAMO_INI, WRAMO_FIM);
            }


            /*" -621- ADD 1 TO WLIDOS-REL. */
            W.WLIDOS_REL.Value = W.WLIDOS_REL + 1;

            /*" -622- MOVE RELATO-DTINIVIG TO WDATA. */
            _.Move(RELATO_DTINIVIG, W.WDATA);

            /*" -623- MOVE WDATA-DD TO LC04B-DDI. */
            _.Move(W.FILLER_32.WDATA_DD, W.LC04B.LC04B_DATAI.LC04B_DDI);

            /*" -624- MOVE WDATA-MM TO LC04B-MMI. */
            _.Move(W.FILLER_32.WDATA_MM, W.LC04B.LC04B_DATAI.LC04B_MMI);

            /*" -625- MOVE WDATA-AA TO LC04B-AAI. */
            _.Move(W.FILLER_32.WDATA_AA, W.LC04B.LC04B_DATAI.LC04B_AAI);

            /*" -626- MOVE RELATO-DTTERVIG TO WDATA. */
            _.Move(RELATO_DTTERVIG, W.WDATA);

            /*" -627- MOVE WDATA-DD TO LC04B-DDT. */
            _.Move(W.FILLER_32.WDATA_DD, W.LC04B.LC04B_DATAT.LC04B_DDT);

            /*" -628- MOVE WDATA-MM TO LC04B-MMT. */
            _.Move(W.FILLER_32.WDATA_MM, W.LC04B.LC04B_DATAT.LC04B_MMT);

            /*" -628- MOVE WDATA-AA TO LC04B-AAT. */
            _.Move(W.FILLER_32.WDATA_AA, W.LC04B.LC04B_DATAT.LC04B_AAT);

        }

        [StopWatch]
        /*" M-300-000-LER-TRELATO-DB-FETCH-1 */
        public void M_300_000_LER_TRELATO_DB_FETCH_1()
        {
            /*" -604- EXEC SQL FETCH V1RELATSINI INTO :RELATO-DTINIVIG, :RELATO-DTTERVIG, :RELATO-RAMO END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELATO_DTINIVIG, RELATO_DTINIVIG);
                _.Move(V1RELATSINI.RELATO_DTTERVIG, RELATO_DTTERVIG);
                _.Move(V1RELATSINI.RELATO_RAMO, RELATO_RAMO);
            }

        }

        [StopWatch]
        /*" M-300-000-LER-TRELATO-DB-CLOSE-1 */
        public void M_300_000_LER_TRELATO_DB_CLOSE_1()
        {
            /*" -607- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-400-000-IMPRIME-SECTION */
        private void M_400_000_IMPRIME_SECTION()
        {
            /*" -643- MOVE '400-000-IMPRIME' TO PARAGRAFO. */
            _.Move("400-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -644- IF SINICAU-RAMO NOT = WRAMO-ANT */

            if (SINICAU_RAMO != W.WRAMO_ANT)
            {

                /*" -645- PERFORM 240-000-ACESSA-TGERAMO */

                M_240_000_ACESSA_TGERAMO_SECTION();

                /*" -647- MOVE SINICAU-RAMO TO WRAMO-ANT LC05-RAMO */
                _.Move(SINICAU_RAMO, W.WRAMO_ANT, W.LC05.LC05_RAMO);

                /*" -649- MOVE 77 TO WCONT-LIN. */
                _.Move(77, W.WCONT_LIN);
            }


            /*" -650- IF WCONT-LIN GREATER 60 */

            if (W.WCONT_LIN > 60)
            {

                /*" -652- PERFORM 430-000-CABEC. */

                M_430_000_CABEC_SECTION();
            }


            /*" -652- PERFORM 460-000-DETALHE. */

            M_460_000_DETALHE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-430-000-CABEC-SECTION */
        private void M_430_000_CABEC_SECTION()
        {
            /*" -671- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -672- ADD 1 TO WCONT-PAG. */
            W.WCONT_PAG.Value = W.WCONT_PAG + 1;

            /*" -674- MOVE WCONT-PAG TO LC01-PAG. */
            _.Move(W.WCONT_PAG, W.LC01.LC01_PAG);

            /*" -677- WRITE REG-SI0109M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -680- WRITE REG-SI0109M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -685- WRITE REG-SI0109M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -686- MOVE RELATO-DTINIVIG TO WDATA */
            _.Move(RELATO_DTINIVIG, W.WDATA);

            /*" -687- MOVE WDATA-DD TO LC04B-DDI */
            _.Move(W.FILLER_32.WDATA_DD, W.LC04B.LC04B_DATAI.LC04B_DDI);

            /*" -688- MOVE WDATA-MM TO LC04B-MMI */
            _.Move(W.FILLER_32.WDATA_MM, W.LC04B.LC04B_DATAI.LC04B_MMI);

            /*" -689- MOVE WDATA-AA TO LC04B-AAI */
            _.Move(W.FILLER_32.WDATA_AA, W.LC04B.LC04B_DATAI.LC04B_AAI);

            /*" -690- MOVE RELATO-DTTERVIG TO WDATA */
            _.Move(RELATO_DTTERVIG, W.WDATA);

            /*" -691- MOVE WDATA-DD TO LC04B-DDT */
            _.Move(W.FILLER_32.WDATA_DD, W.LC04B.LC04B_DATAT.LC04B_DDT);

            /*" -692- MOVE WDATA-MM TO LC04B-MMT */
            _.Move(W.FILLER_32.WDATA_MM, W.LC04B.LC04B_DATAT.LC04B_MMT);

            /*" -693- MOVE WDATA-AA TO LC04B-AAT */
            _.Move(W.FILLER_32.WDATA_AA, W.LC04B.LC04B_DATAT.LC04B_AAT);

            /*" -696- WRITE REG-SI0109M1 FROM LC04B AFTER 1 */
            _.Move(W.LC04B.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -699- WRITE REG-SI0109M1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -702- WRITE REG-SI0109M1 FROM LC06 AFTER 2. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -702- MOVE 8 TO WCONT-LIN. */
            _.Move(8, W.WCONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/

        [StopWatch]
        /*" M-460-000-DETALHE-SECTION */
        private void M_460_000_DETALHE_SECTION()
        {
            /*" -719- MOVE '460-000-DETALHE' TO PARAGRAFO. */
            _.Move("460-000-DETALHE", W.WABEND.PARAGRAFO);

            /*" -720- MOVE SINICAU-CODCAU TO LD01-CODIGO. */
            _.Move(SINICAU_CODCAU, W.LD01.LD01_CODIGO);

            /*" -722- MOVE SINICAU-DESCAU TO LD01-DESCRICAO. */
            _.Move(SINICAU_DESCAU, W.LD01.LD01_DESCRICAO);

            /*" -725- WRITE REG-SI0109M1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0109M1);

            SI0109M1.Write(REG_SI0109M1.GetMoveValues().ToString());

            /*" -727- ADD 2 TO WCONT-LIN. */
            W.WCONT_LIN.Value = W.WCONT_LIN + 2;

            /*" -727- ADD 1 TO WIMPRES. */
            W.WIMPRES.Value = W.WIMPRES + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_460_999_EXIT*/

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELATO-SECTION */
        private void M_600_000_ATUALIZA_TRELATO_SECTION()
        {
            /*" -745- MOVE '600' TO WNR-EXEC-SQL */
            _.Move("600", W.WABEND.WNR_EXEC_SQL);

            /*" -751- MOVE '600-000-ATUALIZA-TRELATO' TO PARAGRAFO. */
            _.Move("600-000-ATUALIZA-TRELATO", W.WABEND.PARAGRAFO);

            /*" -757- PERFORM M_600_000_ATUALIZA_TRELATO_DB_DELETE_1 */

            M_600_000_ATUALIZA_TRELATO_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELATO-DB-DELETE-1 */
        public void M_600_000_ATUALIZA_TRELATO_DB_DELETE_1()
        {
            /*" -757- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0109B' AND DATA_SOLICITACAO = :SISTEMA-DTMOVABE END-EXEC. */

            var m_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1 = new M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1()
            {
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1.Execute(m_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -777- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -780- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -782- CLOSE SI0109M1. */
            SI0109M1.Close();

            /*" -783- DISPLAY 'TOTAL LIDOS            = ' WLIDOS */
            _.Display($"TOTAL LIDOS            = {W.WLIDOS}");

            /*" -784- DISPLAY 'TOTAL LIDOS RELAT.     = ' WLIDOS-REL. */
            _.Display($"TOTAL LIDOS RELAT.     = {W.WLIDOS_REL}");

            /*" -787- DISPLAY 'TOTAL IMPRESSOS        = ' WIMPRES. */
            _.Display($"TOTAL IMPRESSOS        = {W.WIMPRES}");

            /*" -788- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -788- DISPLAY 'SI0109B        *** FIM NORMAL ***' . */
            _.Display($"SI0109B        *** FIM NORMAL ***");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -802- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -803- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -804- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -805- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -807- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -808- CLOSE SI0109M1. */
            SI0109M1.Close();

            /*" -808- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -809- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -811- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -811- GOBACK. */

            throw new GoBack();

        }
    }
}