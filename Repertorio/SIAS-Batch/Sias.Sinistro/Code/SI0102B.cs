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
using Sias.Sinistro.DB2.SI0102B;

namespace Code
{
    public class SI0102B
    {
        public bool IsCall { get; set; }

        public SI0102B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * SISTEMA              =    SINISTRO.                         //      */
        /*"      * PROGRAMA             =    SI0102B.                          //      */
        /*"      *                                                             //      */
        /*"      * OBJETIVO             =    EMISSAO DE RELACAO DE SINISTROS   //      */
        /*"      *                           POR CORRETOR.                     //      */
        /*"      * ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    //      */
        /*"      * DATA                 =    JULHO / 91 .                      //      */
        /*"      *                           MARCO / 92    -   FREDERICO       //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0102M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0102M1
        {
            get
            {
                _.Move(REG_SI0102M1, _SI0102M1); VarBasis.RedefinePassValue(REG_SI0102M1, _SI0102M1, REG_SI0102M1); return _SI0102M1;
            }
        }
        /*"01  REG-SI0102M1.*/
        public SI0102B_REG_SI0102M1 REG_SI0102M1 { get; set; } = new SI0102B_REG_SI0102M1();
        public class SI0102B_REG_SI0102M1 : VarBasis
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
        /*"77          RAMO-VGAPC             PIC S9(004)       COMP.*/
        public IntBasis RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          RAMO-VG                PIC S9(004)       COMP.*/
        public IntBasis RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          RAMO-AP                PIC S9(004)       COMP.*/
        public IntBasis RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          RAMO-SAUDE             PIC S9(004)       COMP.*/
        public IntBasis RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          RAMO-EDUCACAO          PIC S9(004)       COMP.*/
        public IntBasis RAMO_EDUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          SEGV-CLIENTE           PIC S9(009)       COMP.*/
        public IntBasis SEGV_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          CLIE-NOME-RAZAO        PIC  X(040).*/
        public StringBasis CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          PRODUTOR-NOMPDT         PIC  X(040).*/
        public StringBasis PRODUTOR_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          TAPDCORR-NUM-APOL       PIC S9(013)       COMP-3.*/
        public IntBasis TAPDCORR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          TAPDCORR-CODCORR        PIC S9(009)       COMP.*/
        public IntBasis TAPDCORR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          TMESTSIN-DATCMD         PIC  X(010).*/
        public StringBasis TMESTSIN_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          TMESTSIN-APOL-SINI      PIC S9(013)       COMP-3.*/
        public IntBasis TMESTSIN_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          TMESTSIN-MOEDA-SIN      PIC S9(004)      COMP.*/
        public IntBasis TMESTSIN_MOEDA_SIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          TMESTSIN-NUM-APOL       PIC S9(013)       COMP-3.*/
        public IntBasis TMESTSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          TMESTSIN-NRCERTIF       PIC S9(015)       COMP-3.*/
        public IntBasis TMESTSIN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          TMESTSIN-IDTPSEGU       PIC  X(001).*/
        public StringBasis TMESTSIN_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          TMESTSIN-CODSUBES       PIC S9(004)       COMP.*/
        public IntBasis TMESTSIN_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          THISTSIN-DTMOVTO        PIC  X(010).*/
        public StringBasis THISTSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          THISTSIN-VAL-OPER       PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THISTSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          THISTSIN-OPERACAO       PIC S9(004)       COMP.*/
        public IntBasis THISTSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          TRELSIN-DTINIVIG        PIC  X(010).*/
        public StringBasis TRELSIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          TRELSIN-DTTERVIG        PIC  X(010).*/
        public StringBasis TRELSIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          TRELSIN-CODCORR         PIC S9(009)       COMP.*/
        public IntBasis TRELSIN_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          TAPOLICE-NOME           PIC  X(040).*/
        public StringBasis TAPOLICE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          TSISTEMA-DTMOVABE       PIC  X(010).*/
        public StringBasis TSISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          TSISTEMA-DTCURRENT      PIC  X(010).*/
        public StringBasis TSISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W-DTINIVIG             PIC  X(010).*/
        public StringBasis W_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W-DTTERVIG             PIC  X(010).*/
        public StringBasis W_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           GEUNIMO-VLCRUZAD       PIC S9(006)V9(9)  COMP-3.*/
        public DoubleBasis GEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77            WMOEDA                PIC S9(004) COMP VALUE ZEROS*/
        public IntBasis WMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WGEUNIMO-DTTERVIG     PIC X(010).*/
        public StringBasis WGEUNIMO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WGEUNIMO-DTINIVIG     PIC X(010).*/
        public StringBasis WGEUNIMO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              W.*/
        public SI0102B_W W { get; set; } = new SI0102B_W();
        public class SI0102B_W : VarBasis
        {
            /*"  03            LC00.*/
            public SI0102B_LC00 LC00 { get; set; } = new SI0102B_LC00();
            public class SI0102B_LC00 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03            LC01.*/
            }
            public SI0102B_LC01 LC01 { get; set; } = new SI0102B_LC01();
            public class SI0102B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO  PIC  X(009) VALUE 'SI0102B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0102B.1");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC01-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG            PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0102B_LC02 LC02 { get; set; } = new SI0102B_LC02();
            public class SI0102B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(059) VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"");
                /*"    05          FILLER              PIC  X(055) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0102B_LC03 LC03 { get; set; } = new SI0102B_LC03();
            public class SI0102B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04C.*/
            }
            public SI0102B_LC04C LC04C { get; set; } = new SI0102B_LC04C();
            public class SI0102B_LC04C : VarBasis
            {
                /*"    05          FILLER              PIC  X(035) VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(037) VALUE               'SINISTROS POR CORRETOR NO PERIODO DE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"SINISTROS POR CORRETOR NO PERIODO DE ");
                /*"    05          LC04C-DATA.*/
                public SI0102B_LC04C_DATA LC04C_DATA { get; set; } = new SI0102B_LC04C_DATA();
                public class SI0102B_LC04C_DATA : VarBasis
                {
                    /*"      07        LC04C-DDI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_DDI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-MMI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_MMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-AAI           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04C_AAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(003) VALUE ' A '.*/
                }
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    05          LC04C-DATA.*/
                public SI0102B_LC04C_DATA_0 LC04C_DATA_0 { get; set; } = new SI0102B_LC04C_DATA_0();
                public class SI0102B_LC04C_DATA_0 : VarBasis
                {
                    /*"      07        LC04C-DDF           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_DDF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-MMF           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_MMF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-AAF           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04C_AAF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"  03            LC05.*/
                }
            }
            public SI0102B_LC05 LC05 { get; set; } = new SI0102B_LC05();
            public class SI0102B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE                'CORRETOR  -'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"CORRETOR  -");
                /*"    05          LC05-CODCORR        PIC  9(006) VALUE ZEROS.*/
                public IntBasis LC05_CODCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC05-NOMECORR       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC05_NOMECORR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC06.*/
            }
            public SI0102B_LC06 LC06 { get; set; } = new SI0102B_LC06();
            public class SI0102B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            LC07.*/
            }
            public SI0102B_LC07 LC07 { get; set; } = new SI0102B_LC07();
            public class SI0102B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          FILLER              PIC  X(053) VALUE               'APOLICE      SINISTRO     SEGURADO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"APOLICE      SINISTRO     SEGURADO");
                /*"    05          FILLER              PIC  X(047) VALUE               'COMUNICADO   VALOR ESTIMADO             VALOR'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"COMUNICADO   VALOR ESTIMADO             VALOR");
                /*"    05          FILLER              PIC  X(028) VALUE               'MOVIMENTO TIPO DO MOVIMENTO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"MOVIMENTO TIPO DO MOVIMENTO");
                /*"  03            LD01.*/
            }
            public SI0102B_LD01 LD01 { get; set; } = new SI0102B_LD01();
            public class SI0102B_LD01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-APOLICE        PIC  9(013) VALUE ZEROS.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER REDEFINES LD01-APOLICE.*/
                private _REDEF_SI0102B_FILLER_26 _filler_26 { get; set; }
                public _REDEF_SI0102B_FILLER_26 FILLER_26
                {
                    get { _filler_26 = new _REDEF_SI0102B_FILLER_26(); _.Move(LD01_APOLICE, _filler_26); VarBasis.RedefinePassValue(LD01_APOLICE, _filler_26, LD01_APOLICE); _filler_26.ValueChanged += () => { _.Move(_filler_26, LD01_APOLICE); }; return _filler_26; }
                    set { VarBasis.RedefinePassValue(value, _filler_26, LD01_APOLICE); }
                }  //Redefines
                public class _REDEF_SI0102B_FILLER_26 : VarBasis
                {
                    /*"      07        LD01-ORGAO          PIC  9(003).*/
                    public IntBasis LD01_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      07        LD01-RAMO           PIC  9(002).*/
                    public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        LD01-NUMAPOL        PIC  9(008).*/
                    public IntBasis LD01_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/

                    public _REDEF_SI0102B_FILLER_26()
                    {
                        LD01_ORGAO.ValueChanged += OnValueChanged;
                        LD01_RAMO.ValueChanged += OnValueChanged;
                        LD01_NUMAPOL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-SINISTRO       PIC  9(013) VALUE ZEROS.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER REDEFINES  LD01-SINISTRO.*/
                private _REDEF_SI0102B_FILLER_28 _filler_28 { get; set; }
                public _REDEF_SI0102B_FILLER_28 FILLER_28
                {
                    get { _filler_28 = new _REDEF_SI0102B_FILLER_28(); _.Move(LD01_SINISTRO, _filler_28); VarBasis.RedefinePassValue(LD01_SINISTRO, _filler_28, LD01_SINISTRO); _filler_28.ValueChanged += () => { _.Move(_filler_28, LD01_SINISTRO); }; return _filler_28; }
                    set { VarBasis.RedefinePassValue(value, _filler_28, LD01_SINISTRO); }
                }  //Redefines
                public class _REDEF_SI0102B_FILLER_28 : VarBasis
                {
                    /*"      07        LD01-ORGSIN         PIC  9(003).*/
                    public IntBasis LD01_ORGSIN { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      07        LD01-RMOSIN         PIC  9(002).*/
                    public IntBasis LD01_RMOSIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        LD01-NUMSIN         PIC  9(008).*/
                    public IntBasis LD01_NUMSIN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/

                    public _REDEF_SI0102B_FILLER_28()
                    {
                        LD01_ORGSIN.ValueChanged += OnValueChanged;
                        LD01_RMOSIN.ValueChanged += OnValueChanged;
                        LD01_NUMSIN.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-SEGURADO       PIC  X(027) VALUE SPACES.*/
                public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-DTCOMUNIC.*/
                public SI0102B_LD01_DTCOMUNIC LD01_DTCOMUNIC { get; set; } = new SI0102B_LD01_DTCOMUNIC();
                public class SI0102B_LD01_DTCOMUNIC : VarBasis
                {
                    /*"      07        LD01-COMUNI-DD      PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_COMUNI_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL1           PIC  X(001) VALUE '/'.*/
                    public StringBasis LD01_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LD01-COMUNI-MM      PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_COMUNI_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL2           PIC  X(001) VALUE '/'.*/
                    public StringBasis LD01_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LD01-COMUNI-AA      PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_COMUNI_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-VALESTIM       PIC  Z.ZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VALESTIM { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          LD01-VALOR          PIC  ZZ.ZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          LD01-DTMOVTO.*/
                public SI0102B_LD01_DTMOVTO LD01_DTMOVTO { get; set; } = new SI0102B_LD01_DTMOVTO();
                public class SI0102B_LD01_DTMOVTO : VarBasis
                {
                    /*"      07        LD01-MOVTO-DD       PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_MOVTO_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL1           PIC  X(001) VALUE '/'.*/
                    public StringBasis LD01_FIL1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LD01-MOVTO-MM       PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_MOVTO_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL2           PIC  X(001) VALUE '/'.*/
                    public StringBasis LD01_FIL2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LD01-MOVTO-AA       PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_MOVTO_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-OPERACAO       PIC  X(017) VALUE SPACES.*/
                public StringBasis LD01_OPERACAO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"  03            LT01.*/
            }
            public SI0102B_LT01 LT01 { get; set; } = new SI0102B_LT01();
            public class SI0102B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(058) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
                /*"    05          FILLER              PIC  X(024) VALUE                'VALOR TOTAL ESTIMADO '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"VALOR TOTAL ESTIMADO ");
                /*"    05          LT01-TOTAL          PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  03            LT02.*/
            }
            public SI0102B_LT02 LT02 { get; set; } = new SI0102B_LT02();
            public class SI0102B_LT02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(058) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
                /*"    05          FILLER              PIC  X(024) VALUE                'VALOR TOTAL PAGO     '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"VALOR TOTAL PAGO     ");
                /*"    05          LT02-TOTAL          PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  03            LT03.*/
            }
            public SI0102B_LT03 LT03 { get; set; } = new SI0102B_LT03();
            public class SI0102B_LT03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(058) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
                /*"    05          FILLER              PIC  X(024) VALUE                'QTDE TOTAL SINISTROS '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"QTDE TOTAL SINISTROS ");
                /*"    05          LT03-TOTAL          PIC  Z.ZZZ.ZZZ.ZZ9,999999.*/
                public DoubleBasis LT03_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V999999."), 6);
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA.*/
            public SI0102B_WDATA WDATA { get; set; } = new SI0102B_WDATA();
            public class SI0102B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-DD            PIC  9(002).*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-R             REDEFINES WDATA                                    PIC  X(010).*/
            }
            private _REDEF_StringBasis _wdata_r { get; set; }
            public _REDEF_StringBasis WDATA_R
            {
                get { _wdata_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATA, _wdata_r); VarBasis.RedefinePassValue(WDATA, _wdata_r, WDATA); _wdata_r.ValueChanged += () => { _.Move(_wdata_r, WDATA); }; return _wdata_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_r, WDATA); }
            }  //Redefines
            /*"  03         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0102B_FILLER_41 _filler_41 { get; set; }
            public _REDEF_SI0102B_FILLER_41 FILLER_41
            {
                get { _filler_41 = new _REDEF_SI0102B_FILLER_41(); _.Move(WDATA_CURR, _filler_41); VarBasis.RedefinePassValue(WDATA_CURR, _filler_41, WDATA_CURR); _filler_41.ValueChanged += () => { _.Move(_filler_41, WDATA_CURR); }; return _filler_41; }
                set { VarBasis.RedefinePassValue(value, _filler_41, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0102B_FILLER_41 : VarBasis
            {
                /*"    05       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-CURR.*/

                public _REDEF_SI0102B_FILLER_41()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_42.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_43.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0102B_WHORA_CURR WHORA_CURR { get; set; } = new SI0102B_WHORA_CURR();
            public class SI0102B_WHORA_CURR : VarBasis
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
            public SI0102B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0102B_WDATA_CABEC();
            public class SI0102B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0102B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0102B_WHORA_CABEC();
            public class SI0102B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            W-IND               PIC  9(003) VALUE ZEROS.*/
            }
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03            WLIDOS-TRELSIN      PIC  9(006) VALUE 0.*/
            public IntBasis WLIDOS_TRELSIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WLIDOS-TAPDCORR     PIC  9(006) VALUE 0.*/
            public IntBasis WLIDOS_TAPDCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WLIDOS-THISTSIN     PIC  9(006) VALUE 0.*/
            public IntBasis WLIDOS_THISTSIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WIMPRESSOS          PIC  9(006) VALUE 0.*/
            public IntBasis WIMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WCODCORR-ATU        PIC S9(004) COMP VALUE +0.*/
            public IntBasis WCODCORR_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WCODCORR-ANT        PIC S9(004) COMP VALUE +0.*/
            public IntBasis WCODCORR_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WSINISTRO           PIC  9(013) VALUE ZEROS.*/
            public IntBasis WSINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            FILLER              REDEFINES   WSINISTRO.*/
            private _REDEF_SI0102B_FILLER_48 _filler_48 { get; set; }
            public _REDEF_SI0102B_FILLER_48 FILLER_48
            {
                get { _filler_48 = new _REDEF_SI0102B_FILLER_48(); _.Move(WSINISTRO, _filler_48); VarBasis.RedefinePassValue(WSINISTRO, _filler_48, WSINISTRO); _filler_48.ValueChanged += () => { _.Move(_filler_48, WSINISTRO); }; return _filler_48; }
                set { VarBasis.RedefinePassValue(value, _filler_48, WSINISTRO); }
            }  //Redefines
            public class _REDEF_SI0102B_FILLER_48 : VarBasis
            {
                /*"    10          WORGSIN             PIC  9(003).*/
                public IntBasis WORGSIN { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10          WRMOSIN             PIC  9(002).*/
                public IntBasis WRMOSIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WNUMSIN             PIC  9(008).*/
                public IntBasis WNUMSIN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            WIMPRES             PIC S9(006) COMP VALUE +0.*/

                public _REDEF_SI0102B_FILLER_48()
                {
                    WORGSIN.ValueChanged += OnValueChanged;
                    WRMOSIN.ValueChanged += OnValueChanged;
                    WNUMSIN.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WIMPRES { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03            WFIM-TRELSIN        PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TAPDCORR       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TAPDCORR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-THISTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_THISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WS-PRIMEIRA-VEZ     PIC  X(001) VALUE 'S'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03            W-CONT-PAG          PIC  S9(005) VALUE  +0.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            W-CONT-LIN          PIC  S9(002) VALUE  +70.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +70);
            /*"  03            WC-SOMA             PIC  9(013)V99   VALUE ZEROS*/
            public DoubleBasis WC_SOMA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03            WC-VALOR            PIC  9(011)V99   VALUE ZEROS*/
            public DoubleBasis WC_VALOR { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  03            WC-TOTAL            PIC  9(011)V99   VALUE ZEROS*/
            public DoubleBasis WC_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  03            WC-QUANTIDADE       PIC  9(010)      VALUE ZEROS*/
            public IntBasis WC_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  03            WQTD-MOEDA      PIC 9(013)V9(4)   VALUE ZEROS.*/
            public DoubleBasis WQTD_MOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V9(4)"), 4);
            /*"  03            WGEUNIMO-CODUNIMO  PIC 9(004).*/
            public IntBasis WGEUNIMO_CODUNIMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03             CH1-ON1           PIC 9(001)     VALUE ZEROS.*/
            public IntBasis CH1_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03             CH2-ON1           PIC 9(001)     VALUE ZEROS.*/
            public IntBasis CH2_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03             CH3-ON1           PIC 9(001)     VALUE ZEROS.*/
            public IntBasis CH3_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        WABEND.*/
            public SI0102B_WABEND WABEND { get; set; } = new SI0102B_WABEND();
            public class SI0102B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0102B'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0102B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0102B_LK_LINK LK_LINK { get; set; } = new SI0102B_LK_LINK();
        public class SI0102B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0102B_V1RELATSINI V1RELATSINI { get; set; } = new SI0102B_V1RELATSINI();
        public SI0102B_V1APOLCORRET V1APOLCORRET { get; set; } = new SI0102B_V1APOLCORRET();
        public SI0102B_V1HISTSINI V1HISTSINI { get; set; } = new SI0102B_V1HISTSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0102M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0102M1.SetFile(SI0102M1_FILE_NAME_P);

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
            /*" -422- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -426- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -427- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -429- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -431- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -436- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -438- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -440- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -442- PERFORM 070-000-LER-PARAMRAMO. */

            M_070_000_LER_PARAMRAMO_SECTION();

            /*" -444- PERFORM 090-000-CURSOR-TRELSIN. */

            M_090_000_CURSOR_TRELSIN_SECTION();

            /*" -446- PERFORM 150-000-LER-TRELSIN. */

            M_150_000_LER_TRELSIN_SECTION();

            /*" -447- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -448- DISPLAY 'SI0102B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0102B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -450- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -454- PERFORM 120-000-PROCESSA-E UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_120_000_PROCESSA_E_SECTION();
            }

            /*" -454- PERFORM 600-000-ATUALIZA-TRELSIN-E. */

            M_600_000_ATUALIZA_TRELSIN_E_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -461- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -461- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -473- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -474- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -475- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -476- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -478- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -479- MOVE TSISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(TSISTEMA_DTCURRENT, W.WDATA_CURR);

            /*" -480- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.FILLER_41.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -481- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.FILLER_41.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -482- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.FILLER_41.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -485- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -489- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -492- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -494- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -495- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -496- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -497- ELSE */
            }
            else
            {


                /*" -498- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -498- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -514- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -514- OPEN OUTPUT SI0102M1. */
            SI0102M1.Open(REG_SI0102M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -531- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -533- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", W.WABEND.WNR_EXEC_SQL);

            /*" -539- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -542- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -543- DISPLAY 'SI0102B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0102B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -545- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -545- MOVE TSISTEMA-DTMOVABE TO WDATA-R. */
            _.Move(TSISTEMA_DTMOVABE, W.WDATA_R);

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -539- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :TSISTEMA-DTMOVABE, :TSISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TSISTEMA_DTMOVABE, TSISTEMA_DTMOVABE);
                _.Move(executed_1.TSISTEMA_DTCURRENT, TSISTEMA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-LER-PARAMRAMO-SECTION */
        private void M_070_000_LER_PARAMRAMO_SECTION()
        {
            /*" -561- MOVE '070-000-LER-PARAMRAMO' TO PARAGRAFO. */
            _.Move("070-000-LER-PARAMRAMO", W.WABEND.PARAGRAFO);

            /*" -563- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", W.WABEND.WNR_EXEC_SQL);

            /*" -575- PERFORM M_070_000_LER_PARAMRAMO_DB_SELECT_1 */

            M_070_000_LER_PARAMRAMO_DB_SELECT_1();

            /*" -578- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -579- DISPLAY 'NAO CONSTA REGISTRO NA PARAMRAMO' */
                _.Display($"NAO CONSTA REGISTRO NA PARAMRAMO");

                /*" -579- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-070-000-LER-PARAMRAMO-DB-SELECT-1 */
        public void M_070_000_LER_PARAMRAMO_DB_SELECT_1()
        {
            /*" -575- EXEC SQL SELECT RAMO_VGAPC , RAMO_VG , RAMO_AP , RAMO_SAUDE , RAMO_EDUCACAO INTO :RAMO-VGAPC , :RAMO-VG , :RAMO-AP , :RAMO-SAUDE , :RAMO-EDUCACAO FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1 = new M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1.Execute(m_070_000_LER_PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMO_VGAPC, RAMO_VGAPC);
                _.Move(executed_1.RAMO_VG, RAMO_VG);
                _.Move(executed_1.RAMO_AP, RAMO_AP);
                _.Move(executed_1.RAMO_SAUDE, RAMO_SAUDE);
                _.Move(executed_1.RAMO_EDUCACAO, RAMO_EDUCACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-071-000-LER-SEGURAVG-SECTION */
        private void M_071_000_LER_SEGURAVG_SECTION()
        {
            /*" -595- MOVE '071-000-LER-SEGURAVG ' TO PARAGRAFO. */
            _.Move("071-000-LER-SEGURAVG ", W.WABEND.PARAGRAFO);

            /*" -597- MOVE '071' TO WNR-EXEC-SQL. */
            _.Move("071", W.WABEND.WNR_EXEC_SQL);

            /*" -599- IF TMESTSIN-IDTPSEGU EQUAL '8' OR TMESTSIN-IDTPSEGU EQUAL '9' */

            if (TMESTSIN_IDTPSEGU == "8" || TMESTSIN_IDTPSEGU == "9")
            {

                /*" -601- MOVE '1' TO TMESTSIN-IDTPSEGU. */
                _.Move("1", TMESTSIN_IDTPSEGU);
            }


            /*" -602- DISPLAY 'NUM_APOLICE      = ' TMESTSIN-NUM-APOL */
            _.Display($"NUM_APOLICE      = {TMESTSIN_NUM_APOL}");

            /*" -603- DISPLAY 'COD_SUBGRUPO     = ' TMESTSIN-CODSUBES */
            _.Display($"COD_SUBGRUPO     = {TMESTSIN_CODSUBES}");

            /*" -604- DISPLAY 'NUM_CERTIFICADO  = ' TMESTSIN-NRCERTIF */
            _.Display($"NUM_CERTIFICADO  = {TMESTSIN_NRCERTIF}");

            /*" -606- DISPLAY 'TIPO_SEGURADO    = ' TMESTSIN-IDTPSEGU */
            _.Display($"TIPO_SEGURADO    = {TMESTSIN_IDTPSEGU}");

            /*" -614- PERFORM M_071_000_LER_SEGURAVG_DB_SELECT_1 */

            M_071_000_LER_SEGURAVG_DB_SELECT_1();

            /*" -617- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -618- DISPLAY 'NAO CONSTA REGISTRO NA SUBGRUPO' */
                _.Display($"NAO CONSTA REGISTRO NA SUBGRUPO");

                /*" -618- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-071-000-LER-SEGURAVG-DB-SELECT-1 */
        public void M_071_000_LER_SEGURAVG_DB_SELECT_1()
        {
            /*" -614- EXEC SQL SELECT COD_CLIENTE INTO :SEGV-CLIENTE FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :TAPDCORR-NUM-APOL AND COD_SUBGRUPO = :TMESTSIN-CODSUBES AND NUM_CERTIFICADO = :TMESTSIN-NRCERTIF AND TIPO_SEGURADO = :TMESTSIN-IDTPSEGU END-EXEC. */

            var m_071_000_LER_SEGURAVG_DB_SELECT_1_Query1 = new M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1()
            {
                TAPDCORR_NUM_APOL = TAPDCORR_NUM_APOL.ToString(),
                TMESTSIN_CODSUBES = TMESTSIN_CODSUBES.ToString(),
                TMESTSIN_NRCERTIF = TMESTSIN_NRCERTIF.ToString(),
                TMESTSIN_IDTPSEGU = TMESTSIN_IDTPSEGU.ToString(),
            };

            var executed_1 = M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1.Execute(m_071_000_LER_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGV_CLIENTE, SEGV_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_071_999_EXIT*/

        [StopWatch]
        /*" M-072-000-LER-SINIITEM-SECTION */
        private void M_072_000_LER_SINIITEM_SECTION()
        {
            /*" -634- MOVE '072-000-LER-SINIITEM' TO PARAGRAFO. */
            _.Move("072-000-LER-SINIITEM", W.WABEND.PARAGRAFO);

            /*" -636- MOVE '072' TO WNR-EXEC-SQL. */
            _.Move("072", W.WABEND.WNR_EXEC_SQL);

            /*" -638- IF TMESTSIN-IDTPSEGU EQUAL '8' OR TMESTSIN-IDTPSEGU EQUAL '9' */

            if (TMESTSIN_IDTPSEGU == "8" || TMESTSIN_IDTPSEGU == "9")
            {

                /*" -640- MOVE '1' TO TMESTSIN-IDTPSEGU. */
                _.Move("1", TMESTSIN_IDTPSEGU);
            }


            /*" -642- DISPLAY 'NUM-APOL-SINISTRO = ' TMESTSIN-APOL-SINI. */
            _.Display($"NUM-APOL-SINISTRO = {TMESTSIN_APOL_SINI}");

            /*" -647- PERFORM M_072_000_LER_SINIITEM_DB_SELECT_1 */

            M_072_000_LER_SINIITEM_DB_SELECT_1();

            /*" -650- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -651- DISPLAY 'NAO CONSTA REGISTRO NA SUBGRUPO' */
                _.Display($"NAO CONSTA REGISTRO NA SUBGRUPO");

                /*" -651- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-072-000-LER-SINIITEM-DB-SELECT-1 */
        public void M_072_000_LER_SINIITEM_DB_SELECT_1()
        {
            /*" -647- EXEC SQL SELECT COD_CLIENTE INTO :SEGV-CLIENTE FROM SEGUROS.V1SINI_ITEM WHERE NUM_APOL_SINISTRO= :TMESTSIN-APOL-SINI END-EXEC. */

            var m_072_000_LER_SINIITEM_DB_SELECT_1_Query1 = new M_072_000_LER_SINIITEM_DB_SELECT_1_Query1()
            {
                TMESTSIN_APOL_SINI = TMESTSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_072_000_LER_SINIITEM_DB_SELECT_1_Query1.Execute(m_072_000_LER_SINIITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGV_CLIENTE, SEGV_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_072_999_EXIT*/

        [StopWatch]
        /*" M-073-000-LER-APOLICE-SECTION */
        private void M_073_000_LER_APOLICE_SECTION()
        {
            /*" -664- MOVE '073-000-LER-APOLICE' TO PARAGRAFO. */
            _.Move("073-000-LER-APOLICE", W.WABEND.PARAGRAFO);

            /*" -666- MOVE '073' TO WNR-EXEC-SQL. */
            _.Move("073", W.WABEND.WNR_EXEC_SQL);

            /*" -668- IF TMESTSIN-IDTPSEGU EQUAL '8' OR TMESTSIN-IDTPSEGU EQUAL '9' */

            if (TMESTSIN_IDTPSEGU == "8" || TMESTSIN_IDTPSEGU == "9")
            {

                /*" -670- MOVE '1' TO TMESTSIN-IDTPSEGU. */
                _.Move("1", TMESTSIN_IDTPSEGU);
            }


            /*" -672- DISPLAY 'NUM-APOLICE = ' TAPDCORR-NUM-APOL. */
            _.Display($"NUM-APOLICE = {TAPDCORR_NUM_APOL}");

            /*" -677- PERFORM M_073_000_LER_APOLICE_DB_SELECT_1 */

            M_073_000_LER_APOLICE_DB_SELECT_1();

            /*" -680- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -681- DISPLAY 'NAO CONSTA REGISTRO NA APOLICE' */
                _.Display($"NAO CONSTA REGISTRO NA APOLICE");

                /*" -681- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-073-000-LER-APOLICE-DB-SELECT-1 */
        public void M_073_000_LER_APOLICE_DB_SELECT_1()
        {
            /*" -677- EXEC SQL SELECT CODCLIEN INTO :SEGV-CLIENTE FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE= :TAPDCORR-NUM-APOL END-EXEC. */

            var m_073_000_LER_APOLICE_DB_SELECT_1_Query1 = new M_073_000_LER_APOLICE_DB_SELECT_1_Query1()
            {
                TAPDCORR_NUM_APOL = TAPDCORR_NUM_APOL.ToString(),
            };

            var executed_1 = M_073_000_LER_APOLICE_DB_SELECT_1_Query1.Execute(m_073_000_LER_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGV_CLIENTE, SEGV_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_073_999_EXIT*/

        [StopWatch]
        /*" M-074-000-LER-CLIENTES-SECTION */
        private void M_074_000_LER_CLIENTES_SECTION()
        {
            /*" -696- MOVE '074-000-LER-CLIENTES ' TO PARAGRAFO. */
            _.Move("074-000-LER-CLIENTES ", W.WABEND.PARAGRAFO);

            /*" -698- MOVE '074' TO WNR-EXEC-SQL. */
            _.Move("074", W.WABEND.WNR_EXEC_SQL);

            /*" -703- PERFORM M_074_000_LER_CLIENTES_DB_SELECT_1 */

            M_074_000_LER_CLIENTES_DB_SELECT_1();

            /*" -706- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -707- DISPLAY 'NAO CONSTA REGISTRO NA CLIENTES' */
                _.Display($"NAO CONSTA REGISTRO NA CLIENTES");

                /*" -707- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-074-000-LER-CLIENTES-DB-SELECT-1 */
        public void M_074_000_LER_CLIENTES_DB_SELECT_1()
        {
            /*" -703- EXEC SQL SELECT NOME_RAZAO INTO :CLIE-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :SEGV-CLIENTE END-EXEC. */

            var m_074_000_LER_CLIENTES_DB_SELECT_1_Query1 = new M_074_000_LER_CLIENTES_DB_SELECT_1_Query1()
            {
                SEGV_CLIENTE = SEGV_CLIENTE.ToString(),
            };

            var executed_1 = M_074_000_LER_CLIENTES_DB_SELECT_1_Query1.Execute(m_074_000_LER_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_NOME_RAZAO, CLIE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_074_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-SECTION */
        private void M_090_000_CURSOR_TRELSIN_SECTION()
        {
            /*" -725- MOVE '090-000-CURSOR-TRELSIN' TO PARAGRAFO */
            _.Move("090-000-CURSOR-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -727- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -735- PERFORM M_090_000_CURSOR_TRELSIN_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELSIN_DB_DECLARE_1();

            /*" -737- PERFORM M_090_000_CURSOR_TRELSIN_DB_OPEN_1 */

            M_090_000_CURSOR_TRELSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELSIN_DB_DECLARE_1()
        {
            /*" -735- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, CODPDT FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0102B' AND DATA_SOLICITACAO = :TSISTEMA-DTMOVABE ORDER BY PERI_INICIAL, PERI_FINAL, CODPDT END-EXEC. */
            V1RELATSINI = new SI0102B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT PERI_INICIAL
							, PERI_FINAL
							, CODPDT 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0102B' 
							AND DATA_SOLICITACAO = '{TSISTEMA_DTMOVABE}' 
							ORDER BY PERI_INICIAL
							, PERI_FINAL
							, CODPDT";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELSIN_DB_OPEN_1()
        {
            /*" -737- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-170-000-CURSOR-TAPDCORR-DB-DECLARE-1 */
        public void M_170_000_CURSOR_TAPDCORR_DB_DECLARE_1()
        {
            /*" -843- EXEC SQL DECLARE V1APOLCORRET CURSOR FOR SELECT DISTINCT C.NUM_APOLICE, M.DATCMD, M.NUM_APOL_SINISTRO, C.CODCORR, M.COD_MOEDA_SINI, M.CODSUBES, M.NRCERTIF, M.IDTPSEGU FROM SEGUROS.V1APOLCORRET C, SEGUROS.V1MESTSINI M WHERE C.CODCORR = :TRELSIN-CODCORR AND C.NUM_APOLICE = M.NUM_APOLICE AND M.DATCMD >= :W-DTINIVIG AND M.DATCMD <= :W-DTTERVIG ORDER BY C.NUM_APOLICE END-EXEC. */
            V1APOLCORRET = new SI0102B_V1APOLCORRET(true);
            string GetQuery_V1APOLCORRET()
            {
                var query = @$"SELECT DISTINCT 
							C.NUM_APOLICE
							, M.DATCMD
							, 
							M.NUM_APOL_SINISTRO
							, C.CODCORR
							, 
							M.COD_MOEDA_SINI
							, 
							M.CODSUBES
							, 
							M.NRCERTIF
							, 
							M.IDTPSEGU 
							FROM SEGUROS.V1APOLCORRET C
							, 
							SEGUROS.V1MESTSINI M 
							WHERE C.CODCORR = '{TRELSIN_CODCORR}' 
							AND C.NUM_APOLICE = M.NUM_APOLICE 
							AND M.DATCMD >= '{W_DTINIVIG}' 
							AND M.DATCMD <= '{W_DTTERVIG}' 
							ORDER BY C.NUM_APOLICE";

                return query;
            }
            V1APOLCORRET.GetQueryEvent += GetQuery_V1APOLCORRET;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-E-SECTION */
        private void M_120_000_PROCESSA_E_SECTION()
        {
            /*" -752- MOVE '120-000-PROCESSA-E' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA-E", W.WABEND.PARAGRAFO);

            /*" -754- PERFORM 300-000-ACESSA-CORRETOR. */

            M_300_000_ACESSA_CORRETOR_SECTION();

            /*" -756- PERFORM 170-000-CURSOR-TAPDCORR. */

            M_170_000_CURSOR_TAPDCORR_SECTION();

            /*" -758- PERFORM 190-000-LER-TAPDCORR. */

            M_190_000_LER_TAPDCORR_SECTION();

            /*" -759- IF WFIM-TAPDCORR EQUAL 'S' */

            if (W.WFIM_TAPDCORR == "S")
            {

                /*" -761- GO TO 120-010-LEITURA. */

                M_120_010_LEITURA(); //GOTO
                return;
            }


            /*" -764- PERFORM 190-000-LER-TAPDCORR UNTIL WFIM-TAPDCORR EQUAL 'S' . */

            while (!(W.WFIM_TAPDCORR == "S"))
            {

                M_190_000_LER_TAPDCORR_SECTION();
            }

            /*" -764- PERFORM 320-000-IMPRIME-TOTAL. */

            M_320_000_IMPRIME_TOTAL_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_120_010_LEITURA */

            M_120_010_LEITURA();

        }

        [StopWatch]
        /*" M-120-010-LEITURA */
        private void M_120_010_LEITURA(bool isPerform = false)
        {
            /*" -772- PERFORM 150-000-LER-TRELSIN. */

            M_150_000_LER_TRELSIN_SECTION();

            /*" -773- MOVE 'N' TO WFIM-TAPDCORR. */
            _.Move("N", W.WFIM_TAPDCORR);

            /*" -773- MOVE 99 TO W-CONT-LIN. */
            _.Move(99, W.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-SECTION */
        private void M_150_000_LER_TRELSIN_SECTION()
        {
            /*" -791- MOVE '150-000-LER-TRELSIN' TO PARAGRAFO. */
            _.Move("150-000-LER-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -794- PERFORM M_150_000_LER_TRELSIN_DB_FETCH_1 */

            M_150_000_LER_TRELSIN_DB_FETCH_1();

            /*" -798- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -798- PERFORM M_150_000_LER_TRELSIN_DB_CLOSE_1 */

                M_150_000_LER_TRELSIN_DB_CLOSE_1();

                /*" -800- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -802- GO TO 150-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/ //GOTO
                return;
            }


            /*" -803- ADD 1 TO WLIDOS-TRELSIN. */
            W.WLIDOS_TRELSIN.Value = W.WLIDOS_TRELSIN + 1;

            /*" -803- MOVE 0 TO W-CONT-PAG. */
            _.Move(0, W.W_CONT_PAG);

        }

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-DB-FETCH-1 */
        public void M_150_000_LER_TRELSIN_DB_FETCH_1()
        {
            /*" -794- EXEC SQL FETCH V1RELATSINI INTO :TRELSIN-DTINIVIG, :TRELSIN-DTTERVIG, :TRELSIN-CODCORR END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.TRELSIN_DTINIVIG, TRELSIN_DTINIVIG);
                _.Move(V1RELATSINI.TRELSIN_DTTERVIG, TRELSIN_DTTERVIG);
                _.Move(V1RELATSINI.TRELSIN_CODCORR, TRELSIN_CODCORR);
            }

        }

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-DB-CLOSE-1 */
        public void M_150_000_LER_TRELSIN_DB_CLOSE_1()
        {
            /*" -798- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-170-000-CURSOR-TAPDCORR-SECTION */
        private void M_170_000_CURSOR_TAPDCORR_SECTION()
        {
            /*" -822- MOVE '170-000-CURSOR-TAPDCORR' TO PARAGRAFO */
            _.Move("170-000-CURSOR-TAPDCORR", W.WABEND.PARAGRAFO);

            /*" -823- MOVE TRELSIN-DTINIVIG TO W-DTINIVIG */
            _.Move(TRELSIN_DTINIVIG, W_DTINIVIG);

            /*" -825- MOVE TRELSIN-DTTERVIG TO W-DTTERVIG */
            _.Move(TRELSIN_DTTERVIG, W_DTTERVIG);

            /*" -828- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", W.WABEND.WNR_EXEC_SQL);

            /*" -843- PERFORM M_170_000_CURSOR_TAPDCORR_DB_DECLARE_1 */

            M_170_000_CURSOR_TAPDCORR_DB_DECLARE_1();

            /*" -845- PERFORM M_170_000_CURSOR_TAPDCORR_DB_OPEN_1 */

            M_170_000_CURSOR_TAPDCORR_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-170-000-CURSOR-TAPDCORR-DB-OPEN-1 */
        public void M_170_000_CURSOR_TAPDCORR_DB_OPEN_1()
        {
            /*" -845- EXEC SQL OPEN V1APOLCORRET END-EXEC. */

            V1APOLCORRET.Open();

        }

        [StopWatch]
        /*" M-210-000-CURSOR-THISTSIN-DB-DECLARE-1 */
        public void M_210_000_CURSOR_THISTSIN_DB_DECLARE_1()
        {
            /*" -917- EXEC SQL DECLARE V1HISTSINI CURSOR FOR SELECT DTMOVTO, VAL_OPERACAO, OPERACAO FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :TMESTSIN-APOL-SINI AND OPERACAO IN (101, 1001, 1002, 1003, 1004, 9001, 107, 117) ORDER BY DTMOVTO END-EXEC. */
            V1HISTSINI = new SI0102B_V1HISTSINI(true);
            string GetQuery_V1HISTSINI()
            {
                var query = @$"SELECT DTMOVTO
							, VAL_OPERACAO
							, 
							OPERACAO 
							FROM SEGUROS.V1HISTSINI 
							WHERE NUM_APOL_SINISTRO = '{TMESTSIN_APOL_SINI}' 
							AND OPERACAO IN 
							(101
							, 1001
							, 1002
							, 1003
							, 1004
							, 9001
							, 107
							, 117) 
							ORDER BY DTMOVTO";

                return query;
            }
            V1HISTSINI.GetQueryEvent += GetQuery_V1HISTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_170_999_EXIT*/

        [StopWatch]
        /*" M-190-000-LER-TAPDCORR-SECTION */
        private void M_190_000_LER_TAPDCORR_SECTION()
        {
            /*" -864- MOVE '190-000-LER-TAPDCORR' TO PARAGRAFO. */
            _.Move("190-000-LER-TAPDCORR", W.WABEND.PARAGRAFO);

            /*" -867- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", W.WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM M_190_000_LER_TAPDCORR_DB_FETCH_1 */

            M_190_000_LER_TAPDCORR_DB_FETCH_1();

            /*" -879- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -879- PERFORM M_190_000_LER_TAPDCORR_DB_CLOSE_1 */

                M_190_000_LER_TAPDCORR_DB_CLOSE_1();

                /*" -881- MOVE 'S' TO WFIM-TAPDCORR */
                _.Move("S", W.WFIM_TAPDCORR);

                /*" -883- GO TO 190-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/ //GOTO
                return;
            }


            /*" -884- ADD 1 TO WLIDOS-TAPDCORR. */
            W.WLIDOS_TAPDCORR.Value = W.WLIDOS_TAPDCORR + 1;

            /*" -886- PERFORM 210-000-CURSOR-THISTSIN. */

            M_210_000_CURSOR_THISTSIN_SECTION();

            /*" -889- PERFORM 240-000-LER-THISTSIN UNTIL WFIM-THISTSIN EQUAL 'S' . */

            while (!(W.WFIM_THISTSIN == "S"))
            {

                M_240_000_LER_THISTSIN_SECTION();
            }

            /*" -889- MOVE 'N' TO WFIM-THISTSIN. */
            _.Move("N", W.WFIM_THISTSIN);

        }

        [StopWatch]
        /*" M-190-000-LER-TAPDCORR-DB-FETCH-1 */
        public void M_190_000_LER_TAPDCORR_DB_FETCH_1()
        {
            /*" -876- EXEC SQL FETCH V1APOLCORRET INTO :TAPDCORR-NUM-APOL, :TMESTSIN-DATCMD, :TMESTSIN-APOL-SINI, :TAPDCORR-CODCORR, :TMESTSIN-MOEDA-SIN, :TMESTSIN-CODSUBES, :TMESTSIN-NRCERTIF, :TMESTSIN-IDTPSEGU END-EXEC. */

            if (V1APOLCORRET.Fetch())
            {
                _.Move(V1APOLCORRET.TAPDCORR_NUM_APOL, TAPDCORR_NUM_APOL);
                _.Move(V1APOLCORRET.TMESTSIN_DATCMD, TMESTSIN_DATCMD);
                _.Move(V1APOLCORRET.TMESTSIN_APOL_SINI, TMESTSIN_APOL_SINI);
                _.Move(V1APOLCORRET.TAPDCORR_CODCORR, TAPDCORR_CODCORR);
                _.Move(V1APOLCORRET.TMESTSIN_MOEDA_SIN, TMESTSIN_MOEDA_SIN);
                _.Move(V1APOLCORRET.TMESTSIN_CODSUBES, TMESTSIN_CODSUBES);
                _.Move(V1APOLCORRET.TMESTSIN_NRCERTIF, TMESTSIN_NRCERTIF);
                _.Move(V1APOLCORRET.TMESTSIN_IDTPSEGU, TMESTSIN_IDTPSEGU);
            }

        }

        [StopWatch]
        /*" M-190-000-LER-TAPDCORR-DB-CLOSE-1 */
        public void M_190_000_LER_TAPDCORR_DB_CLOSE_1()
        {
            /*" -879- EXEC SQL CLOSE V1APOLCORRET END-EXEC */

            V1APOLCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/

        [StopWatch]
        /*" M-210-000-CURSOR-THISTSIN-SECTION */
        private void M_210_000_CURSOR_THISTSIN_SECTION()
        {
            /*" -906- MOVE '210-000-CURSOR-THISTSIN' TO PARAGRAFO. */
            _.Move("210-000-CURSOR-THISTSIN", W.WABEND.PARAGRAFO);

            /*" -909- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", W.WABEND.WNR_EXEC_SQL);

            /*" -917- PERFORM M_210_000_CURSOR_THISTSIN_DB_DECLARE_1 */

            M_210_000_CURSOR_THISTSIN_DB_DECLARE_1();

            /*" -919- PERFORM M_210_000_CURSOR_THISTSIN_DB_OPEN_1 */

            M_210_000_CURSOR_THISTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-210-000-CURSOR-THISTSIN-DB-OPEN-1 */
        public void M_210_000_CURSOR_THISTSIN_DB_OPEN_1()
        {
            /*" -919- EXEC SQL OPEN V1HISTSINI END-EXEC. */

            V1HISTSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-240-000-LER-THISTSIN-SECTION */
        private void M_240_000_LER_THISTSIN_SECTION()
        {
            /*" -936- MOVE '240-000-LER-THISTSIN' TO PARAGRAFO. */
            _.Move("240-000-LER-THISTSIN", W.WABEND.PARAGRAFO);

            /*" -938- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", W.WABEND.WNR_EXEC_SQL);

            /*" -942- PERFORM M_240_000_LER_THISTSIN_DB_FETCH_1 */

            M_240_000_LER_THISTSIN_DB_FETCH_1();

            /*" -945- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -945- PERFORM M_240_000_LER_THISTSIN_DB_CLOSE_1 */

                M_240_000_LER_THISTSIN_DB_CLOSE_1();

                /*" -947- MOVE 'S' TO WFIM-THISTSIN */
                _.Move("S", W.WFIM_THISTSIN);

                /*" -949- GO TO 240-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/ //GOTO
                return;
            }


            /*" -951- ADD 1 TO WLIDOS-THISTSIN. */
            W.WLIDOS_THISTSIN.Value = W.WLIDOS_THISTSIN + 1;

            /*" -953- IF TMESTSIN-APOL-SINI EQUAL WSINISTRO NEXT SENTENCE */

            if (TMESTSIN_APOL_SINI == W.WSINISTRO)
            {

                /*" -954- ELSE */
            }
            else
            {


                /*" -955- ADD 1 TO WC-QUANTIDADE */
                W.WC_QUANTIDADE.Value = W.WC_QUANTIDADE + 1;

                /*" -958- MOVE TMESTSIN-APOL-SINI TO WSINISTRO. */
                _.Move(TMESTSIN_APOL_SINI, W.WSINISTRO);
            }


            /*" -959- MOVE TAPDCORR-NUM-APOL TO LD01-APOLICE. */
            _.Move(TAPDCORR_NUM_APOL, W.LD01.LD01_APOLICE);

            /*" -961- MOVE TMESTSIN-APOL-SINI TO LD01-SINISTRO. */
            _.Move(TMESTSIN_APOL_SINI, W.LD01.LD01_SINISTRO);

            /*" -963- PERFORM 260-000-ACESSA-TAPOLICE. */

            M_260_000_ACESSA_TAPOLICE_SECTION();

            /*" -964- MOVE TAPOLICE-NOME TO LD01-SEGURADO */
            _.Move(TAPOLICE_NOME, W.LD01.LD01_SEGURADO);

            /*" -965- MOVE TMESTSIN-DATCMD TO WDATA-R */
            _.Move(TMESTSIN_DATCMD, W.WDATA_R);

            /*" -966- MOVE WDATA-DD TO LD01-COMUNI-DD */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTCOMUNIC.LD01_COMUNI_DD);

            /*" -967- MOVE WDATA-MM TO LD01-COMUNI-MM */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTCOMUNIC.LD01_COMUNI_MM);

            /*" -969- MOVE WDATA-AA TO LD01-COMUNI-AA. */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTCOMUNIC.LD01_COMUNI_AA);

            /*" -971- MOVE THISTSIN-VAL-OPER TO LD01-VALESTIM */
            _.Move(THISTSIN_VAL_OPER, W.LD01.LD01_VALESTIM);

            /*" -972- PERFORM 600-000-CALCULA-VALOR. */

            M_600_000_CALCULA_VALOR_SECTION();

            /*" -974- MOVE WC-SOMA TO LD01-VALOR */
            _.Move(W.WC_SOMA, W.LD01.LD01_VALOR);

            /*" -979- IF THISTSIN-OPERACAO EQUAL 1001 OR 1002 OR 1003 OR 1004 OR 9001 */

            if (THISTSIN_OPERACAO.In("1001", "1002", "1003", "1004", "9001"))
            {

                /*" -980- ADD THISTSIN-VAL-OPER TO WC-VALOR */
                W.WC_VALOR.Value = W.WC_VALOR + THISTSIN_VAL_OPER;

                /*" -982- ADD WC-SOMA TO WC-TOTAL. */
                W.WC_TOTAL.Value = W.WC_TOTAL + W.WC_SOMA;
            }


            /*" -983- MOVE THISTSIN-DTMOVTO TO WDATA-R */
            _.Move(THISTSIN_DTMOVTO, W.WDATA_R);

            /*" -984- MOVE WDATA-DD TO LD01-MOVTO-DD */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTMOVTO.LD01_MOVTO_DD);

            /*" -985- MOVE WDATA-MM TO LD01-MOVTO-MM */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTMOVTO.LD01_MOVTO_MM);

            /*" -987- MOVE WDATA-AA TO LD01-MOVTO-AA. */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTMOVTO.LD01_MOVTO_AA);

            /*" -988- IF THISTSIN-OPERACAO EQUAL 101 */

            if (THISTSIN_OPERACAO == 101)
            {

                /*" -990- MOVE 'CADASTRAMEN.DE AVISO' TO LD01-OPERACAO */
                _.Move("CADASTRAMEN.DE AVISO", W.LD01.LD01_OPERACAO);

                /*" -991- ELSE */
            }
            else
            {


                /*" -992- IF THISTSIN-OPERACAO EQUAL 1001 */

                if (THISTSIN_OPERACAO == 1001)
                {

                    /*" -994- MOVE 'INDENIZACAO PARCIAL ' TO LD01-OPERACAO */
                    _.Move("INDENIZACAO PARCIAL ", W.LD01.LD01_OPERACAO);

                    /*" -995- ELSE */
                }
                else
                {


                    /*" -996- IF THISTSIN-OPERACAO EQUAL 1002 */

                    if (THISTSIN_OPERACAO == 1002)
                    {

                        /*" -998- MOVE 'INDENIZACAO FINAL   ' TO LD01-OPERACAO */
                        _.Move("INDENIZACAO FINAL   ", W.LD01.LD01_OPERACAO);

                        /*" -999- ELSE */
                    }
                    else
                    {


                        /*" -1000- IF THISTSIN-OPERACAO EQUAL 1003 */

                        if (THISTSIN_OPERACAO == 1003)
                        {

                            /*" -1002- MOVE 'INDENIZACAO TOTAL   ' TO LD01-OPERACAO */
                            _.Move("INDENIZACAO TOTAL   ", W.LD01.LD01_OPERACAO);

                            /*" -1003- ELSE */
                        }
                        else
                        {


                            /*" -1004- IF THISTSIN-OPERACAO EQUAL 1004 */

                            if (THISTSIN_OPERACAO == 1004)
                            {

                                /*" -1006- MOVE 'INDENIZ.COMPLEMENTAR' TO LD01-OPERACAO */
                                _.Move("INDENIZ.COMPLEMENTAR", W.LD01.LD01_OPERACAO);

                                /*" -1007- ELSE */
                            }
                            else
                            {


                                /*" -1008- IF THISTSIN-OPERACAO EQUAL 9001 */

                                if (THISTSIN_OPERACAO == 9001)
                                {

                                    /*" -1010- MOVE 'ADIANTAMENTO        ' TO LD01-OPERACAO */
                                    _.Move("ADIANTAMENTO        ", W.LD01.LD01_OPERACAO);

                                    /*" -1011- ELSE */
                                }
                                else
                                {


                                    /*" -1012- IF THISTSIN-OPERACAO EQUAL 107 */

                                    if (THISTSIN_OPERACAO == 107)
                                    {

                                        /*" -1014- MOVE 'CANCEL.PROCES.NO MES' TO LD01-OPERACAO */
                                        _.Move("CANCEL.PROCES.NO MES", W.LD01.LD01_OPERACAO);

                                        /*" -1015- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1016- IF THISTSIN-OPERACAO EQUAL 117 */

                                        if (THISTSIN_OPERACAO == 117)
                                        {

                                            /*" -1019- MOVE 'CANCEL.PROC.MES POST' TO LD01-OPERACAO. */
                                            _.Move("CANCEL.PROC.MES POST", W.LD01.LD01_OPERACAO);
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1019- PERFORM 360-000-IMPRIME. */

            M_360_000_IMPRIME_SECTION();

        }

        [StopWatch]
        /*" M-240-000-LER-THISTSIN-DB-FETCH-1 */
        public void M_240_000_LER_THISTSIN_DB_FETCH_1()
        {
            /*" -942- EXEC SQL FETCH V1HISTSINI INTO :THISTSIN-DTMOVTO, :THISTSIN-VAL-OPER, :THISTSIN-OPERACAO END-EXEC. */

            if (V1HISTSINI.Fetch())
            {
                _.Move(V1HISTSINI.THISTSIN_DTMOVTO, THISTSIN_DTMOVTO);
                _.Move(V1HISTSINI.THISTSIN_VAL_OPER, THISTSIN_VAL_OPER);
                _.Move(V1HISTSINI.THISTSIN_OPERACAO, THISTSIN_OPERACAO);
            }

        }

        [StopWatch]
        /*" M-240-000-LER-THISTSIN-DB-CLOSE-1 */
        public void M_240_000_LER_THISTSIN_DB_CLOSE_1()
        {
            /*" -945- EXEC SQL CLOSE V1HISTSINI END-EXEC */

            V1HISTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-260-000-ACESSA-TAPOLICE-SECTION */
        private void M_260_000_ACESSA_TAPOLICE_SECTION()
        {
            /*" -1036- MOVE '260-000-ACESSA-TAPOLICE' TO PARAGRAFO. */
            _.Move("260-000-ACESSA-TAPOLICE", W.WABEND.PARAGRAFO);

            /*" -1039- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", W.WABEND.WNR_EXEC_SQL);

            /*" -1044- PERFORM M_260_000_ACESSA_TAPOLICE_DB_SELECT_1 */

            M_260_000_ACESSA_TAPOLICE_DB_SELECT_1();

            /*" -1047- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1048- DISPLAY 'SI0102A - NAO EXISTE TAPOLICE' */
                _.Display($"SI0102A - NAO EXISTE TAPOLICE");

                /*" -1050- DISPLAY ' NUM_APOLICE = ' TAPDCORR-NUM-APOL */
                _.Display($" NUM_APOLICE = {TAPDCORR_NUM_APOL}");

                /*" -1052- MOVE SPACES TO TAPOLICE-NOME. */
                _.Move("", TAPOLICE_NOME);
            }


            /*" -1053- MOVE TMESTSIN-APOL-SINI TO WSINISTRO */
            _.Move(TMESTSIN_APOL_SINI, W.WSINISTRO);

            /*" -1064- IF WRMOSIN EQUAL RAMO-VGAPC OR RAMO-VG OR RAMO-AP OR RAMO-SAUDE OR RAMO-EDUCACAO */

            if (W.FILLER_48.WRMOSIN.In(RAMO_VGAPC.ToString(), RAMO_VG.ToString(), RAMO_AP.ToString(), RAMO_SAUDE.ToString(), RAMO_EDUCACAO.ToString()))
            {

                /*" -1067- IF WRMOSIN EQUAL RAMO-AP AND TMESTSIN-NRCERTIF EQUAL ZEROES AND TMESTSIN-IDTPSEGU EQUAL ' ' */

                if (W.FILLER_48.WRMOSIN == RAMO_AP && TMESTSIN_NRCERTIF == 00 && TMESTSIN_IDTPSEGU == " ")
                {

                    /*" -1068- PERFORM 072-000-LER-SINIITEM */

                    M_072_000_LER_SINIITEM_SECTION();

                    /*" -1069- PERFORM 074-000-LER-CLIENTES */

                    M_074_000_LER_CLIENTES_SECTION();

                    /*" -1070- MOVE CLIE-NOME-RAZAO TO TAPOLICE-NOME */
                    _.Move(CLIE_NOME_RAZAO, TAPOLICE_NOME);

                    /*" -1071- ELSE */
                }
                else
                {


                    /*" -1072- PERFORM 071-000-LER-SEGURAVG */

                    M_071_000_LER_SEGURAVG_SECTION();

                    /*" -1073- PERFORM 074-000-LER-CLIENTES */

                    M_074_000_LER_CLIENTES_SECTION();

                    /*" -1074- MOVE CLIE-NOME-RAZAO TO TAPOLICE-NOME */
                    _.Move(CLIE_NOME_RAZAO, TAPOLICE_NOME);

                    /*" -1075- ELSE */
                }

            }
            else
            {


                /*" -1076- IF WRMOSIN NOT EQUAL 32 */

                if (W.FILLER_48.WRMOSIN != 32)
                {

                    /*" -1077- PERFORM 072-000-LER-SINIITEM */

                    M_072_000_LER_SINIITEM_SECTION();

                    /*" -1078- PERFORM 074-000-LER-CLIENTES */

                    M_074_000_LER_CLIENTES_SECTION();

                    /*" -1079- MOVE CLIE-NOME-RAZAO TO TAPOLICE-NOME */
                    _.Move(CLIE_NOME_RAZAO, TAPOLICE_NOME);

                    /*" -1080- ELSE */
                }
                else
                {


                    /*" -1081- PERFORM 073-000-LER-APOLICE */

                    M_073_000_LER_APOLICE_SECTION();

                    /*" -1082- PERFORM 074-000-LER-CLIENTES */

                    M_074_000_LER_CLIENTES_SECTION();

                    /*" -1084- MOVE CLIE-NOME-RAZAO TO TAPOLICE-NOME. */
                    _.Move(CLIE_NOME_RAZAO, TAPOLICE_NOME);
                }

            }


            /*" -1084- MOVE TAPOLICE-NOME TO LD01-SEGURADO. */
            _.Move(TAPOLICE_NOME, W.LD01.LD01_SEGURADO);

        }

        [StopWatch]
        /*" M-260-000-ACESSA-TAPOLICE-DB-SELECT-1 */
        public void M_260_000_ACESSA_TAPOLICE_DB_SELECT_1()
        {
            /*" -1044- EXEC SQL SELECT NOME INTO :TAPOLICE-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :TAPDCORR-NUM-APOL END-EXEC. */

            var m_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1 = new M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1()
            {
                TAPDCORR_NUM_APOL = TAPDCORR_NUM_APOL.ToString(),
            };

            var executed_1 = M_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1.Execute(m_260_000_ACESSA_TAPOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAPOLICE_NOME, TAPOLICE_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-300-000-ACESSA-CORRETOR-SECTION */
        private void M_300_000_ACESSA_CORRETOR_SECTION()
        {
            /*" -1100- MOVE '300-000-ACESSA-CORRETOR' TO PARAGRAFO. */
            _.Move("300-000-ACESSA-CORRETOR", W.WABEND.PARAGRAFO);

            /*" -1103- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", W.WABEND.WNR_EXEC_SQL);

            /*" -1108- PERFORM M_300_000_ACESSA_CORRETOR_DB_SELECT_1 */

            M_300_000_ACESSA_CORRETOR_DB_SELECT_1();

            /*" -1111- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1112- DISPLAY 'SI0102A - NAO EXISTE PRODUTOR CADASTRADO' */
                _.Display($"SI0102A - NAO EXISTE PRODUTOR CADASTRADO");

                /*" -1113- DISPLAY ' CODPDT = ' TRELSIN-CODCORR */
                _.Display($" CODPDT = {TRELSIN_CODCORR}");

                /*" -1115- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1116- MOVE TRELSIN-CODCORR TO LC05-CODCORR. */
            _.Move(TRELSIN_CODCORR, W.LC05.LC05_CODCORR);

            /*" -1116- MOVE PRODUTOR-NOMPDT TO LC05-NOMECORR. */
            _.Move(PRODUTOR_NOMPDT, W.LC05.LC05_NOMECORR);

        }

        [StopWatch]
        /*" M-300-000-ACESSA-CORRETOR-DB-SELECT-1 */
        public void M_300_000_ACESSA_CORRETOR_DB_SELECT_1()
        {
            /*" -1108- EXEC SQL SELECT NOMPDT INTO :PRODUTOR-NOMPDT FROM SEGUROS.V1PRODUTOR WHERE CODPDT = :TRELSIN-CODCORR END-EXEC. */

            var m_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1 = new M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1()
            {
                TRELSIN_CODCORR = TRELSIN_CODCORR.ToString(),
            };

            var executed_1 = M_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1.Execute(m_300_000_ACESSA_CORRETOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTOR_NOMPDT, PRODUTOR_NOMPDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-320-000-IMPRIME-TOTAL-SECTION */
        private void M_320_000_IMPRIME_TOTAL_SECTION()
        {
            /*" -1133- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", W.WABEND.WNR_EXEC_SQL);

            /*" -1137- MOVE '320-000-IMPRIME-TOTAL' TO PARAGRAFO. */
            _.Move("320-000-IMPRIME-TOTAL", W.WABEND.PARAGRAFO);

            /*" -1138- MOVE WC-VALOR TO LT01-TOTAL */
            _.Move(W.WC_VALOR, W.LT01.LT01_TOTAL);

            /*" -1139- MOVE WC-TOTAL TO LT02-TOTAL */
            _.Move(W.WC_TOTAL, W.LT02.LT02_TOTAL);

            /*" -1141- MOVE WC-QUANTIDADE TO LT03-TOTAL */
            _.Move(W.WC_QUANTIDADE, W.LT03.LT03_TOTAL);

            /*" -1142- IF W-CONT-LIN GREATER 49 */

            if (W.W_CONT_LIN > 49)
            {

                /*" -1145- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -1148- WRITE REG-SI0102M1 FROM LT01 AFTER 4. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1151- WRITE REG-SI0102M1 FROM LT02 AFTER 2. */
            _.Move(W.LT02.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1154- WRITE REG-SI0102M1 FROM LT03 AFTER 2. */
            _.Move(W.LT03.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1158- MOVE ZEROS TO WC-VALOR WC-TOTAL WC-QUANTIDADE. */
            _.Move(0, W.WC_VALOR, W.WC_TOTAL, W.WC_QUANTIDADE);

            /*" -1159- MOVE 90 TO W-CONT-LIN. */
            _.Move(90, W.W_CONT_LIN);

            /*" -1160- MOVE ZEROS TO W-CONT-PAG. */
            _.Move(0, W.W_CONT_PAG);

            /*" -1160- MOVE WCODCORR-ATU TO WCODCORR-ANT. */
            _.Move(W.WCODCORR_ATU, W.WCODCORR_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_999_EXIT*/

        [StopWatch]
        /*" M-360-000-IMPRIME-SECTION */
        private void M_360_000_IMPRIME_SECTION()
        {
            /*" -1174- MOVE '360-000-IMPRIME' TO PARAGRAFO. */
            _.Move("360-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -1175- IF W-CONT-LIN GREATER 60 */

            if (W.W_CONT_LIN > 60)
            {

                /*" -1177- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -1180- WRITE REG-SI0102M1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1181- ADD 1 TO WIMPRESSOS. */
            W.WIMPRESSOS.Value = W.WIMPRESSOS + 1;

            /*" -1181- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-390-000-CABEC-SECTION */
        private void M_390_000_CABEC_SECTION()
        {
            /*" -1196- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -1197- ADD 1 TO W-CONT-PAG. */
            W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

            /*" -1199- MOVE W-CONT-PAG TO LC01-PAG. */
            _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

            /*" -1202- WRITE REG-SI0102M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1205- WRITE REG-SI0102M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1209- WRITE REG-SI0102M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1210- MOVE TRELSIN-DTINIVIG TO WDATA-R */
            _.Move(TRELSIN_DTINIVIG, W.WDATA_R);

            /*" -1211- MOVE WDATA-DD TO LC04C-DDI */
            _.Move(W.WDATA.WDATA_DD, W.LC04C.LC04C_DATA.LC04C_DDI);

            /*" -1212- MOVE WDATA-MM TO LC04C-MMI */
            _.Move(W.WDATA.WDATA_MM, W.LC04C.LC04C_DATA.LC04C_MMI);

            /*" -1213- MOVE WDATA-AA TO LC04C-AAI */
            _.Move(W.WDATA.WDATA_AA, W.LC04C.LC04C_DATA.LC04C_AAI);

            /*" -1214- MOVE TRELSIN-DTTERVIG TO WDATA-R */
            _.Move(TRELSIN_DTTERVIG, W.WDATA_R);

            /*" -1215- MOVE WDATA-DD TO LC04C-DDF */
            _.Move(W.WDATA.WDATA_DD, W.LC04C.LC04C_DATA_0.LC04C_DDF);

            /*" -1216- MOVE WDATA-MM TO LC04C-MMF */
            _.Move(W.WDATA.WDATA_MM, W.LC04C.LC04C_DATA_0.LC04C_MMF);

            /*" -1217- MOVE WDATA-AA TO LC04C-AAF */
            _.Move(W.WDATA.WDATA_AA, W.LC04C.LC04C_DATA_0.LC04C_AAF);

            /*" -1220- WRITE REG-SI0102M1 FROM LC04C AFTER 1 */
            _.Move(W.LC04C.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1223- WRITE REG-SI0102M1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1226- WRITE REG-SI0102M1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1229- WRITE REG-SI0102M1 FROM LC07 AFTER 1. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1233- WRITE REG-SI0102M1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0102M1);

            SI0102M1.Write(REG_SI0102M1.GetMoveValues().ToString());

            /*" -1233- MOVE 09 TO W-CONT-LIN. */
            _.Move(09, W.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELSIN-E-SECTION */
        private void M_600_000_ATUALIZA_TRELSIN_E_SECTION()
        {
            /*" -1250- MOVE '600-000-ATUALIZA-TRELSIN' TO PARAGRAFO. */
            _.Move("600-000-ATUALIZA-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -1253- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", W.WABEND.WNR_EXEC_SQL);

            /*" -1259- PERFORM M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1 */

            M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELSIN-E-DB-DELETE-1 */
        public void M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1()
        {
            /*" -1259- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0102B' AND DATA_SOLICITACAO = :TSISTEMA-DTMOVABE END-EXEC. */

            var m_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1 = new M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1()
            {
                TSISTEMA_DTMOVABE = TSISTEMA_DTMOVABE.ToString(),
            };

            M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1.Execute(m_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-600-000-CALCULA-VALOR-SECTION */
        private void M_600_000_CALCULA_VALOR_SECTION()
        {
            /*" -1275- MOVE TMESTSIN-MOEDA-SIN TO WGEUNIMO-CODUNIMO WMOEDA. */
            _.Move(TMESTSIN_MOEDA_SIN, W.WGEUNIMO_CODUNIMO, WMOEDA);

            /*" -1278- MOVE THISTSIN-DTMOVTO TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(THISTSIN_DTMOVTO, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -1280- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -1284- COMPUTE WQTD-MOEDA = THISTSIN-VAL-OPER / GEUNIMO-VLCRUZAD. */
            W.WQTD_MOEDA.Value = THISTSIN_VAL_OPER / GEUNIMO_VLCRUZAD;

            /*" -1287- MOVE TSISTEMA-DTMOVABE TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(TSISTEMA_DTMOVABE, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -1289- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -1290- COMPUTE WC-SOMA = WQTD-MOEDA * GEUNIMO-VLCRUZAD. */
            W.WC_SOMA.Value = W.WQTD_MOEDA * GEUNIMO_VLCRUZAD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_0_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-SECTION */
        private void M_610_000_LER_TGEUNIMO_SECTION()
        {
            /*" -1301- MOVE '610' TO WNR-EXEC-SQL */
            _.Move("610", W.WABEND.WNR_EXEC_SQL);

            /*" -1305- MOVE '610-000-LER-TGEUNIMO' TO PARAGRAFO. */
            _.Move("610-000-LER-TGEUNIMO", W.WABEND.PARAGRAFO);

            /*" -1312- PERFORM M_610_000_LER_TGEUNIMO_DB_SELECT_1 */

            M_610_000_LER_TGEUNIMO_DB_SELECT_1();

            /*" -1315- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1319- DISPLAY 'SI0102B  - NAO CONSTA REGISTRO NA TGEUNIMO' ' - MOEDA    = ' WMOEDA ' - DATA 1   = ' WGEUNIMO-DTINIVIG ' - DATA 2   = ' WGEUNIMO-DTTERVIG */

                $"SI0102B  - NAO CONSTA REGISTRO NA TGEUNIMO - MOEDA    = {WMOEDA} - DATA 1   = {WGEUNIMO_DTINIVIG} - DATA 2   = {WGEUNIMO_DTTERVIG}"
                .Display();

                /*" -1319- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-DB-SELECT-1 */
        public void M_610_000_LER_TGEUNIMO_DB_SELECT_1()
        {
            /*" -1312- EXEC SQL SELECT VLCRUZAD INTO :GEUNIMO-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WMOEDA AND DTINIVIG <= :WGEUNIMO-DTINIVIG AND DTTERVIG >= :WGEUNIMO-DTTERVIG END-EXEC. */

            var m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 = new M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1()
            {
                WGEUNIMO_DTINIVIG = WGEUNIMO_DTINIVIG.ToString(),
                WGEUNIMO_DTTERVIG = WGEUNIMO_DTTERVIG.ToString(),
                WMOEDA = WMOEDA.ToString(),
            };

            var executed_1 = M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1.Execute(m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEUNIMO_VLCRUZAD, GEUNIMO_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -1337- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -1341- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -1342- CLOSE SI0102M1. */
            SI0102M1.Close();

            /*" -1343- DISPLAY 'TOTAL DE CONTROLE - SI0102B' . */
            _.Display($"TOTAL DE CONTROLE - SI0102B");

            /*" -1344- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1345- DISPLAY 'LIDOS NA TRELSIN  = ' WLIDOS-TRELSIN. */
            _.Display($"LIDOS NA TRELSIN  = {W.WLIDOS_TRELSIN}");

            /*" -1346- DISPLAY 'LIDOS NA TAPDCORR = ' WLIDOS-TAPDCORR. */
            _.Display($"LIDOS NA TAPDCORR = {W.WLIDOS_TAPDCORR}");

            /*" -1347- DISPLAY 'LIDOS NA THISTSIN = ' WLIDOS-THISTSIN. */
            _.Display($"LIDOS NA THISTSIN = {W.WLIDOS_THISTSIN}");

            /*" -1348- DISPLAY 'IMPRESSOS         = ' WIMPRESSOS. */
            _.Display($"IMPRESSOS         = {W.WIMPRESSOS}");

            /*" -1349- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1350- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1350- DISPLAY 'SI0102B         *** FIM NORMAL ***' . */
            _.Display($"SI0102B         *** FIM NORMAL ***");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1364- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1365- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1366- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1367- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1369- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1370- CLOSE SI0102M1. */
            SI0102M1.Close();

            /*" -1370- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1371- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1373- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1373- GOBACK. */

            throw new GoBack();

        }
    }
}