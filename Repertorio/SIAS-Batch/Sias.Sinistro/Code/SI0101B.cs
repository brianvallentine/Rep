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
using Sias.Sinistro.DB2.SI0101B;

namespace Code
{
    public class SI0101B
    {
        public bool IsCall { get; set; }

        public SI0101B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    SINISTRO                          //      */
        /*"      * PROGRAMA             :    SI0101B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELACAO DE SINISTRO POR//      */
        /*"      *                           APOLICE                           //      */
        /*"      * ANALISTA/PROGRAMADOR :    PROCAS/ENRICO                     //      */
        /*"      * DATA                 :    JUNHO/91                          //      */
        /*"      *                           MARCO/92   -   FREDERICO          //      */
        /*"      *---------------------------------------------------------------//      */
        /*"      * ALTERACAO BARAN 13/06/95: A SELECAO PELA MESTSINI SERA' FEI-//      */
        /*"      *                           TA PELA DATA DE OCORRENCIA.       //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0101M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0101M1
        {
            get
            {
                _.Move(REG_SI0101M1, _SI0101M1); VarBasis.RedefinePassValue(REG_SI0101M1, _SI0101M1, REG_SI0101M1); return _SI0101M1;
            }
        }
        /*"01  REG-SI0101M1.*/
        public SI0101B_REG_SI0101M1 REG_SI0101M1 { get; set; } = new SI0101B_REG_SI0101M1();
        public class SI0101B_REG_SI0101M1 : VarBasis
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
        /*"77           CLIE-NOME-RAZAO        PIC  X(040).*/
        public StringBasis CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           CLIE-COD-CLIENTE       PIC S9(009)       COMP.*/
        public IntBasis CLIE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           MEST-NUM-APOL          PIC S9(013)       COMP-3.*/
        public IntBasis MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-DATCMD            PIC  X(010).*/
        public StringBasis MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-DATORR            PIC  X(010).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-FONTE             PIC S9(004)       COMP.*/
        public IntBasis MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-APOL-SINI         PIC S9(013)       COMP-3.*/
        public IntBasis MEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-CODSUBES          PIC S9(004)       COMP.*/
        public IntBasis MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-MOEDA-SIN         PIC S9(004)       COMP.*/
        public IntBasis MEST_MOEDA_SIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-CODCAU            PIC S9(004)       COMP.*/
        public IntBasis MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-RAMO              PIC S9(004)       COMP.*/
        public IntBasis MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-DTMOVTO1         PIC  X(010).*/
        public StringBasis THIST_DTMOVTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           THIST-VALPRI1          PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-OPERACAO         PIC S9(004)       COMP.*/
        public IntBasis THIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-DTMOVTO          PIC  X(010).*/
        public StringBasis THIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           THIST-VALPRI           PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-QTD-MOEDA        PIC S9(010)V9(5)  COMP-3.*/
        public DoubleBasis THIST_QTD_MOEDA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77           THIST-SITUACAO         PIC  X(001).*/
        public StringBasis THIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           RELSIN-DTINIVIG        PIC  X(010).*/
        public StringBasis RELSIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-DTTERVIG        PIC  X(010).*/
        public StringBasis RELSIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-APOLICE       PIC S9(013)       COMP-3.*/
        public IntBasis RELSIN_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           SIST-DTMOVABE          PIC  X(010).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTCURRENT         PIC  X(010).*/
        public StringBasis SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           APOL-NOME              PIC  X(040).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SCAU-DESCAU            PIC  X(040).*/
        public StringBasis SCAU_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           W-SINISTRO             PIC S9(013)    COMP-3.*/
        public IntBasis W_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           W-DTINIVIG             PIC  X(010).*/
        public StringBasis W_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W-DTTERVIG             PIC  X(010).*/
        public StringBasis W_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W-DATA                 PIC  X(010).*/
        public StringBasis W_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W-CODUNIMO             PIC S9(004)      COMP.*/
        public IntBasis W_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           GEUNIMO-VLCRUZAD       PIC S9(006)V9(9)  COMP-3.*/
        public DoubleBasis GEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77           GEUNIMO-SIGLUNIM       PIC  X(006).*/
        public StringBasis GEUNIMO_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77           WMOEDA                 PIC S9(004) COMP VALUE ZEROS*/
        public IntBasis WMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WGEUNIMO-DTTERVIG      PIC X(010).*/
        public StringBasis WGEUNIMO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WGEUNIMO-DTINIVIG      PIC X(010).*/
        public StringBasis WGEUNIMO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              W.*/
        public SI0101B_W W { get; set; } = new SI0101B_W();
        public class SI0101B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0101B_LC01 LC01 { get; set; } = new SI0101B_LC01();
            public class SI0101B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC  X(009) VALUE 'SI0101B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0101B.1");
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
            public SI0101B_LC02 LC02 { get; set; } = new SI0101B_LC02();
            public class SI0101B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(050) VALUE  SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    05          FILLER              PIC  X(059) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0101B_LC03 LC03 { get; set; } = new SI0101B_LC03();
            public class SI0101B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04C.*/
            }
            public SI0101B_LC04C LC04C { get; set; } = new SI0101B_LC04C();
            public class SI0101B_LC04C : VarBasis
            {
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(043) VALUE               'SINISTROS OCORRIDOS POR APOLICE NO PERIODO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"SINISTROS OCORRIDOS POR APOLICE NO PERIODO");
                /*"    05          LC04C-DATA.*/
                public SI0101B_LC04C_DATA LC04C_DATA { get; set; } = new SI0101B_LC04C_DATA();
                public class SI0101B_LC04C_DATA : VarBasis
                {
                    /*"      07        LC04C-DDI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_DDI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-MMI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_MMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-AAI           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04C_AAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(003) VALUE ' A '.*/
                }
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    05          LC04C-DATA.*/
                public SI0101B_LC04C_DATA_0 LC04C_DATA_0 { get; set; } = new SI0101B_LC04C_DATA_0();
                public class SI0101B_LC04C_DATA_0 : VarBasis
                {
                    /*"      07        LC04C-DDF           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_DDF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-MMF           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_MMF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-AAF           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04C_AAF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"  03            LC05.*/
                }
            }
            public SI0101B_LC05 LC05 { get; set; } = new SI0101B_LC05();
            public class SI0101B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                'APOLICE - '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"APOLICE - ");
                /*"    05          LC05-APOLICE        PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC05_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER REDEFINES LC05-APOLICE.*/
                private _REDEF_SI0101B_FILLER_18 _filler_18 { get; set; }
                public _REDEF_SI0101B_FILLER_18 FILLER_18
                {
                    get { _filler_18 = new _REDEF_SI0101B_FILLER_18(); _.Move(LC05_APOLICE, _filler_18); VarBasis.RedefinePassValue(LC05_APOLICE, _filler_18, LC05_APOLICE); _filler_18.ValueChanged += () => { _.Move(_filler_18, LC05_APOLICE); }; return _filler_18; }
                    set { VarBasis.RedefinePassValue(value, _filler_18, LC05_APOLICE); }
                }  //Redefines
                public class _REDEF_SI0101B_FILLER_18 : VarBasis
                {
                    /*"      07        LC05-ORGAO          PIC  9(003).*/
                    public IntBasis LC05_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      07        LC05-RAMO           PIC  9(002).*/
                    public IntBasis LC05_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        LC05-NUMAPOL        PIC  9(008).*/
                    public IntBasis LC05_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/

                    public _REDEF_SI0101B_FILLER_18()
                    {
                        LC05_ORGAO.ValueChanged += OnValueChanged;
                        LC05_RAMO.ValueChanged += OnValueChanged;
                        LC05_NUMAPOL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          FILLER              PIC  X(011) VALUE               'SEGURADO - '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SEGURADO - ");
                /*"    05          LC05-SEGURADO       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC05_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC5A.*/
            }
            public SI0101B_LC5A LC5A { get; set; } = new SI0101B_LC5A();
            public class SI0101B_LC5A : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE               'SUB-GRUPO : '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"SUB-GRUPO : ");
                /*"    05          LC5A-CODSUBES       PIC  9(004) VALUE ZEROES.*/
                public IntBasis LC5A_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC5A-NOME-RAZAO     PIC  X(040) VALUE SPACES.*/
                public StringBasis LC5A_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC06.*/
            }
            public SI0101B_LC06 LC06 { get; set; } = new SI0101B_LC06();
            public class SI0101B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            LC07.*/
            }
            public SI0101B_LC07 LC07 { get; set; } = new SI0101B_LC07();
            public class SI0101B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                   '         '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"         ");
                /*"    05          FILLER              PIC  X(014) VALUE                                   '       '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"       ");
                /*"    05          FILLER              PIC  X(008) VALUE                                   '     '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"     ");
                /*"    05          FILLER              PIC  X(034) VALUE                '     V A L O R     A V I S A D O'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"     V A L O R     A V I S A D O");
                /*"    05          FILLER              PIC  X(016) VALUE                                    '        '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"        ");
                /*"    05          FILLER              PIC  X(031) VALUE                'V A L O R      P A G O'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"V A L O R      P A G O");
                /*"  03            LC08.*/
            }
            public SI0101B_LC08 LC08 { get; set; } = new SI0101B_LC08();
            public class SI0101B_LC08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(042) VALUE                'SINISTRO     COMUNICADO OCORR. FONTE MOEDA'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"SINISTRO     COMUNICADO OCORR. FONTE MOEDA");
                /*"    05          FILLER              PIC  X(017) VALUE                                    '      QUANTIDADE '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"      QUANTIDADE ");
                /*"    05          FILLER              PIC  X(016) VALUE                                    '          VALOR '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"          VALOR ");
                /*"    05          FILLER              PIC  X(009) VALUE                                    'PAGAMENTO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PAGAMENTO");
                /*"    05          FILLER              PIC  X(016) VALUE                                    '     QUANTIDADE '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"     QUANTIDADE ");
                /*"    05          FILLER              PIC  X(016) VALUE                                    '          VALOR '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"          VALOR ");
                /*"    05          FILLER              PIC  X(016) VALUE                                    'OBSERVACAO      '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"OBSERVACAO      ");
                /*"  03            LD01.*/
            }
            public SI0101B_LD01 LD01 { get; set; } = new SI0101B_LD01();
            public class SI0101B_LD01 : VarBasis
            {
                /*"    05          LD01-SINISTRO       PIC  9(013) BLANK WHEN ZERO.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-DTCMD.*/
                public SI0101B_LD01_DTCMD LD01_DTCMD { get; set; } = new SI0101B_LD01_DTCMD();
                public class SI0101B_LD01_DTCMD : VarBasis
                {
                    /*"      07        LD01-DTCMD-DD       PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTCMD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL1           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTCMD-MM       PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTCMD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL2           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTCMD-AA       PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTCMD_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-DTORR.*/
                public SI0101B_LD01_DTORR LD01_DTORR { get; set; } = new SI0101B_LD01_DTORR();
                public class SI0101B_LD01_DTORR : VarBasis
                {
                    /*"      07        LD01-DTORR-DD       PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTORR_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL5           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTORR-MM       PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTORR_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL6           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTORR-AA       PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTORR_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-FONTE          PIC  9(003) BLANK WHEN ZERO.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-MOEDA          PIC  X(006) VALUE SPACES.*/
                public StringBasis LD01_MOEDA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LD01-VA-BTNF        PIC  ZZZZZZ.ZZ9,99999B.*/
                public DoubleBasis LD01_VA_BTNF { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZZZZ.ZZ9V99999B."), 5);
                /*"    05          LD01-VA-CRUZ        PIC  ZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VA_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          LD01-DTPAGTO.*/
                public SI0101B_LD01_DTPAGTO LD01_DTPAGTO { get; set; } = new SI0101B_LD01_DTPAGTO();
                public class SI0101B_LD01_DTPAGTO : VarBasis
                {
                    /*"      07        LD01-DTPAGTO-DD     PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTPAGTO_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL3           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTPAGTO-MM     PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTPAGTO_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL4           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTPAGTO-AA     PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTPAGTO_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-VP-BTNF        PIC  ZZZZZ.ZZ9,99999B.*/
                public DoubleBasis LD01_VP_BTNF { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZZZZ.ZZ9V99999B."), 5);
                /*"    05          LD01-VP-CRUZ        PIC  ZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VP_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          LD01-OBS            PIC  X(010) VALUE SPACES.*/
                public StringBasis LD01_OBS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LD02.*/
            }
            public SI0101B_LD02 LD02 { get; set; } = new SI0101B_LD02();
            public class SI0101B_LD02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD02-DESCAU         PIC  X(040) VALUE SPACES.*/
                public StringBasis LD02_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(078) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "78", "X(078)"), @"");
                /*"  03            LT01.*/
            }
            public SI0101B_LT01 LT01 { get; set; } = new SI0101B_LT01();
            public class SI0101B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(024) VALUE               'TOTAL GERAL'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"TOTAL GERAL");
                /*"    05          LT01-VALOR-AVIS     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT01_VALOR_AVIS { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          LT01-VALOR-PAGO     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT01_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03            LT02.*/
            }
            public SI0101B_LT02 LT02 { get; set; } = new SI0101B_LT02();
            public class SI0101B_LT02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(024) VALUE               'TOTAL SUBGRUPO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"TOTAL SUBGRUPO");
                /*"    05          LT02-VALOR-AVIS     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT02_VALOR_AVIS { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          LT02-VALOR-PAGO     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT02_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0101B_FILLER_53 _filler_53 { get; set; }
            public _REDEF_SI0101B_FILLER_53 FILLER_53
            {
                get { _filler_53 = new _REDEF_SI0101B_FILLER_53(); _.Move(WDATA_CURR, _filler_53); VarBasis.RedefinePassValue(WDATA_CURR, _filler_53, WDATA_CURR); _filler_53.ValueChanged += () => { _.Move(_filler_53, WDATA_CURR); }; return _filler_53; }
                set { VarBasis.RedefinePassValue(value, _filler_53, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0101B_FILLER_53 : VarBasis
            {
                /*"    05       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-CURR.*/

                public _REDEF_SI0101B_FILLER_53()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_54.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_55.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0101B_WHORA_CURR WHORA_CURR { get; set; } = new SI0101B_WHORA_CURR();
            public class SI0101B_WHORA_CURR : VarBasis
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
            public SI0101B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0101B_WDATA_CABEC();
            public class SI0101B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0101B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0101B_WHORA_CABEC();
            public class SI0101B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA.*/
            }
            public SI0101B_WDATA WDATA { get; set; } = new SI0101B_WDATA();
            public class SI0101B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"  03            WDATAX.*/
            public SI0101B_WDATAX WDATAX { get; set; } = new SI0101B_WDATAX();
            public class SI0101B_WDATAX : VarBasis
            {
                /*"    05          WDATAX-ANO          PIC  9(004).*/
                public IntBasis WDATAX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATAX-MES          PIC  9(002).*/
                public IntBasis WDATAX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATAX-DIA          PIC  9(002).*/
                public IntBasis WDATAX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATAX-R            REDEFINES WDATAX                                    PIC  X(010).*/
            }
            private _REDEF_StringBasis _wdatax_r { get; set; }
            public _REDEF_StringBasis WDATAX_R
            {
                get { _wdatax_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATAX, _wdatax_r); VarBasis.RedefinePassValue(WDATAX, _wdatax_r, WDATAX); _wdatax_r.ValueChanged += () => { _.Move(_wdatax_r, WDATAX); }; return _wdatax_r; }
                set { VarBasis.RedefinePassValue(value, _wdatax_r, WDATAX); }
            }  //Redefines
            /*"  03            WCODSUBES-ANT       PIC S9(004) COMP VALUE +0.*/
            public IntBasis WCODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WFLAG-VEZ           PIC  X(001)      VALUE ' '.*/
            public StringBasis WFLAG_VEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"  03            W-OPERACAO-ANT      PIC S9(004) COMP VALUE +0.*/
            public IntBasis W_OPERACAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            W-APOLICE-ANT       PIC  9(013) VALUE ZEROS.*/
            public IntBasis W_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            W-APOLICE-ANT-R     REDEFINES   W-APOLICE-ANT.*/
            private _REDEF_SI0101B_W_APOLICE_ANT_R _w_apolice_ant_r { get; set; }
            public _REDEF_SI0101B_W_APOLICE_ANT_R W_APOLICE_ANT_R
            {
                get { _w_apolice_ant_r = new _REDEF_SI0101B_W_APOLICE_ANT_R(); _.Move(W_APOLICE_ANT, _w_apolice_ant_r); VarBasis.RedefinePassValue(W_APOLICE_ANT, _w_apolice_ant_r, W_APOLICE_ANT); _w_apolice_ant_r.ValueChanged += () => { _.Move(_w_apolice_ant_r, W_APOLICE_ANT); }; return _w_apolice_ant_r; }
                set { VarBasis.RedefinePassValue(value, _w_apolice_ant_r, W_APOLICE_ANT); }
            }  //Redefines
            public class _REDEF_SI0101B_W_APOLICE_ANT_R : VarBasis
            {
                /*"    05          W-ORGAO-ANT         PIC  9(003).*/
                public IntBasis W_ORGAO_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          W-RAMO-ANT          PIC  9(002).*/
                public IntBasis W_RAMO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          W-NUMAPOL-ANT       PIC  9(008).*/
                public IntBasis W_NUMAPOL_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            W-APOLICE-ATU       PIC  9(013) VALUE ZEROS.*/

                public _REDEF_SI0101B_W_APOLICE_ANT_R()
                {
                    W_ORGAO_ANT.ValueChanged += OnValueChanged;
                    W_RAMO_ANT.ValueChanged += OnValueChanged;
                    W_NUMAPOL_ANT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            W-APOLICE-ATU-R     REDEFINES   W-APOLICE-ATU.*/
            private _REDEF_SI0101B_W_APOLICE_ATU_R _w_apolice_atu_r { get; set; }
            public _REDEF_SI0101B_W_APOLICE_ATU_R W_APOLICE_ATU_R
            {
                get { _w_apolice_atu_r = new _REDEF_SI0101B_W_APOLICE_ATU_R(); _.Move(W_APOLICE_ATU, _w_apolice_atu_r); VarBasis.RedefinePassValue(W_APOLICE_ATU, _w_apolice_atu_r, W_APOLICE_ATU); _w_apolice_atu_r.ValueChanged += () => { _.Move(_w_apolice_atu_r, W_APOLICE_ATU); }; return _w_apolice_atu_r; }
                set { VarBasis.RedefinePassValue(value, _w_apolice_atu_r, W_APOLICE_ATU); }
            }  //Redefines
            public class _REDEF_SI0101B_W_APOLICE_ATU_R : VarBasis
            {
                /*"    05          W-ORGAO-ATU         PIC  9(003).*/
                public IntBasis W_ORGAO_ATU { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          W-RAMO-ATU          PIC  9(002).*/
                public IntBasis W_RAMO_ATU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          W-NUMAPOL-ATU       PIC  9(008).*/
                public IntBasis W_NUMAPOL_ATU { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            W-DTINIVIG-ANT      PIC  X(010) VALUE ZEROS.*/

                public _REDEF_SI0101B_W_APOLICE_ATU_R()
                {
                    W_ORGAO_ATU.ValueChanged += OnValueChanged;
                    W_RAMO_ATU.ValueChanged += OnValueChanged;
                    W_NUMAPOL_ATU.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTINIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            W-DTINIVIG-ATU      PIC  X(010) VALUE ZEROS.*/
            public StringBasis W_DTINIVIG_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            W-DTTERVIG-ANT      PIC  X(010) VALUE ZEROS.*/
            public StringBasis W_DTTERVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            W-DTTERVIG-ATU      PIC  X(010) VALUE ZEROS.*/
            public StringBasis W_DTTERVIG_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            WIMPRES             PIC S9(006) COMP VALUE +0.*/
            public IntBasis WIMPRES { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03            EXISTE-THISTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis EXISTE_THISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            EXISTE-FIN-TOT-COMP   PIC  X(001) VALUE 'N'.*/
            public StringBasis EXISTE_FIN_TOT_COMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TRELSIN        PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-THISTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_THISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TMESTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TMESTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TMESTSIN1      PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TMESTSIN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WS-PRIMEIRA-VEZ     PIC  X(001) VALUE 'S'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03            WQTD-MOEDA      PIC 9(013)V9(4)   VALUE ZEROS.*/
            public DoubleBasis WQTD_MOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V9(4)"), 4);
            /*"  03            WGEUNIMO-CODUNIMO  PIC 9(004).*/
            public IntBasis WGEUNIMO_CODUNIMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03            W-CONT-PAG          PIC  S9(005) VALUE  +0.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            W-CONT-LIN          PIC  S9(002) VALUE  +70.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +70);
            /*"  03            WS-VALOR-AVIS PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_VALOR_AVIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-QTDE-AVIS  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS_QTDE_AVIS { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            WS-VALOR-PAGO PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-QTDE-PAGO  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS_QTDE_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            WS-SUBES-AVIS PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_SUBES_AVIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-SUBES-PAGO PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_SUBES_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-TOTAL-AVIS PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_TOTAL_AVIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-TOTAL-PAGO PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_TOTAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-PAGBT           PIC S9(013)V99   VALUE ZEROS.*/
            public DoubleBasis WS_PAGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-PAGBT-G         PIC S9(013)V99   VALUE ZEROS.*/
            public DoubleBasis WS_PAGBT_G { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-VRPAGO-BT       PIC S9(010)V9(5) VALUE ZEROS.*/
            public DoubleBasis WS_VRPAGO_BT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            WS-VRPAGO          PIC S9(013)V99  VALUE ZEROS.*/
            public DoubleBasis WS_VRPAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-VRAVIS          PIC S9(013)V99  VALUE ZEROS.*/
            public DoubleBasis WS_VRAVIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-PEND-B          PIC S9(013)V9(5) VALUE ZEROS.*/
            public DoubleBasis WS_PEND_B { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  03            WS-PEND            PIC S9(013)V99   VALUE ZEROS.*/
            public DoubleBasis WS_PEND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-PEND-BTN        PIC S9(010)V9(5) VALUE ZEROS.*/
            public DoubleBasis WS_PEND_BTN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            WS-PEND-C          PIC S9(013)V99  VALUE ZEROS.*/
            public DoubleBasis WS_PEND_C { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-PEND-CRUZ       PIC S9(013)V99  VALUE ZEROS.*/
            public DoubleBasis WS_PEND_CRUZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-SOMA-VAL         PIC S9(010)V9(5) VALUE ZEROS*/
            public DoubleBasis WS_SOMA_VAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            WS-SOMA-VAL1        PIC S9(010)V9(5) VALUE ZEROS*/
            public DoubleBasis WS_SOMA_VAL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            AC-PAGBT-G         PIC S9(013)V99   VALUE ZEROS.*/
            public DoubleBasis AC_PAGBT_G { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            AC-VRPAGO-BT       PIC S9(010)V9(5) VALUE ZEROS.*/
            public DoubleBasis AC_VRPAGO_BT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            AC-PEND-BTN        PIC S9(010)V9(5) VALUE ZEROS.*/
            public DoubleBasis AC_PEND_BTN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03            AC-PEND-CRUZ       PIC S9(013)V99  VALUE ZEROS.*/
            public DoubleBasis AC_PEND_CRUZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            AC-TMESTSIN        PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_TMESTSIN { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03        WABEND.*/
            public SI0101B_WABEND WABEND { get; set; } = new SI0101B_WABEND();
            public class SI0101B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0101B'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0101B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0101B_LK_LINK LK_LINK { get; set; } = new SI0101B_LK_LINK();
        public class SI0101B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0101B_V1RELATSINI V1RELATSINI { get; set; } = new SI0101B_V1RELATSINI();
        public SI0101B_TMESTSIN1 TMESTSIN1 { get; set; } = new SI0101B_TMESTSIN1();
        public SI0101B_V1HISTSINI V1HISTSINI { get; set; } = new SI0101B_V1HISTSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0101M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0101M1.SetFile(SI0101M1_FILE_NAME_P);

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
            /*" -483- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -487- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -488- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -490- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -493- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -499- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -501- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -503- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -505- PERFORM 090-000-CURSOR-TRELSIN-E. */

            M_090_000_CURSOR_TRELSIN_E_SECTION();

            /*" -507- PERFORM 150-000-LER-TRELSIN-E */

            M_150_000_LER_TRELSIN_E_SECTION();

            /*" -508- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -509- DISPLAY 'SI0101B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0101B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -511- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -513- MOVE RELSIN-APOLICE TO W-APOLICE-ANT. */
            _.Move(RELSIN_APOLICE, W.W_APOLICE_ANT);

            /*" -514- MOVE RELSIN-DTINIVIG TO W-DTINIVIG-ANT. */
            _.Move(RELSIN_DTINIVIG, W.W_DTINIVIG_ANT);

            /*" -517- MOVE RELSIN-DTTERVIG TO W-DTTERVIG-ANT. */
            _.Move(RELSIN_DTTERVIG, W.W_DTTERVIG_ANT);

            /*" -520- PERFORM 120-000-PROCESSA-E UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_120_000_PROCESSA_E_SECTION();
            }

            /*" -522- PERFORM 370-000-IMPRIME-TOTAL. */

            M_370_000_IMPRIME_TOTAL_SECTION();

            /*" -524- MOVE 90 TO W-CONT-LIN. */
            _.Move(90, W.W_CONT_LIN);

            /*" -524- PERFORM 600-000-ATUALIZA-TRELSIN-E. */

            M_600_000_ATUALIZA_TRELSIN_E_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -531- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -531- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -545- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, W.WDATA_CURR);

            /*" -546- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.FILLER_53.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -547- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.FILLER_53.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -548- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.FILLER_53.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -550- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -551- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -552- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -553- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -554- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -557- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -561- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -564- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -566- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -567- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -568- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -569- ELSE */
            }
            else
            {


                /*" -570- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -570- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -561- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -585- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -585- OPEN OUTPUT SI0101M1. */
            SI0101M1.Open(REG_SI0101M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -601- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -603- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", W.WABEND.WNR_EXEC_SQL);

            /*" -609- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -612- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -613- DISPLAY 'SI0101B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0101B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -615- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -615- MOVE SIST-DTMOVABE TO WDATA-R. */
            _.Move(SIST_DTMOVABE, W.WDATA_R);

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -609- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
                _.Move(executed_1.SIST_DTCURRENT, SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-SECTION */
        private void M_090_000_CURSOR_TRELSIN_E_SECTION()
        {
            /*" -632- MOVE '090-000-CURSOR-TRELSIN-E' TO PARAGRAFO */
            _.Move("090-000-CURSOR-TRELSIN-E", W.WABEND.PARAGRAFO);

            /*" -634- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -643- PERFORM M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1();

            /*" -645- PERFORM M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1 */

            M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1()
        {
            /*" -643- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT NUM_APOLICE, PERI_INICIAL, PERI_FINAL FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0101B' AND DATA_SOLICITACAO = :SIST-DTMOVABE ORDER BY PERI_INICIAL, PERI_FINAL, NUM_APOLICE END-EXEC. */
            V1RELATSINI = new SI0101B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							PERI_INICIAL
							, 
							PERI_FINAL 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0101B' 
							AND DATA_SOLICITACAO = '{SIST_DTMOVABE}' 
							ORDER BY PERI_INICIAL
							, PERI_FINAL
							, NUM_APOLICE";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1()
        {
            /*" -645- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-240-000-CURSOR-TMESTSIN-DB-DECLARE-1 */
        public void M_240_000_CURSOR_TMESTSIN_DB_DECLARE_1()
        {
            /*" -774- EXEC SQL DECLARE TMESTSIN1 CURSOR FOR SELECT M.NUM_APOL_SINISTRO, M.DATCMD, M.DATORR, M.FONTE, M.CODSUBES, H.DTMOVTO, H.VAL_OPERACAO, M.COD_MOEDA_SINI, M.RAMO, M.CODCAU FROM SEGUROS.V1MESTSINI M, SEGUROS.V1HISTSINI H WHERE M.NUM_APOLICE = :RELSIN-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.OPERACAO = 101 AND M.DATORR >= :W-DTINIVIG AND M.DATORR <= :W-DTTERVIG ORDER BY M.CODSUBES, H.DTMOVTO, M.NUM_APOL_SINISTRO END-EXEC. */
            TMESTSIN1 = new SI0101B_TMESTSIN1(true);
            string GetQuery_TMESTSIN1()
            {
                var query = @$"SELECT M.NUM_APOL_SINISTRO
							, 
							M.DATCMD
							, 
							M.DATORR
							, 
							M.FONTE
							, 
							M.CODSUBES
							, 
							H.DTMOVTO
							, 
							H.VAL_OPERACAO
							, 
							M.COD_MOEDA_SINI
							, 
							M.RAMO
							, 
							M.CODCAU 
							FROM SEGUROS.V1MESTSINI M
							, 
							SEGUROS.V1HISTSINI H 
							WHERE 
							M.NUM_APOLICE = '{RELSIN_APOLICE}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.OPERACAO = 101 
							AND M.DATORR >= '{W_DTINIVIG}' 
							AND M.DATORR <= '{W_DTTERVIG}' 
							ORDER BY M.CODSUBES
							, H.DTMOVTO
							, M.NUM_APOL_SINISTRO";

                return query;
            }
            TMESTSIN1.GetQueryEvent += GetQuery_TMESTSIN1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-E-SECTION */
        private void M_120_000_PROCESSA_E_SECTION()
        {
            /*" -659- MOVE '120-000-PROCESSA-E' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA-E", W.WABEND.PARAGRAFO);

            /*" -661- IF W-DTINIVIG-ATU NOT EQUAL W-DTINIVIG-ANT OR W-DTTERVIG-ATU NOT EQUAL W-DTTERVIG-ANT */

            if (W.W_DTINIVIG_ATU != W.W_DTINIVIG_ANT || W.W_DTTERVIG_ATU != W.W_DTTERVIG_ANT)
            {

                /*" -662- PERFORM 370-000-IMPRIME-TOTAL */

                M_370_000_IMPRIME_TOTAL_SECTION();

                /*" -663- MOVE W-DTINIVIG-ATU TO W-DTINIVIG-ANT */
                _.Move(W.W_DTINIVIG_ATU, W.W_DTINIVIG_ANT);

                /*" -664- MOVE W-DTTERVIG-ATU TO W-DTTERVIG-ANT */
                _.Move(W.W_DTTERVIG_ATU, W.W_DTTERVIG_ANT);

                /*" -665- MOVE W-ORGAO-ATU TO W-ORGAO-ANT */
                _.Move(W.W_APOLICE_ATU_R.W_ORGAO_ATU, W.W_APOLICE_ANT_R.W_ORGAO_ANT);

                /*" -666- MOVE W-RAMO-ATU TO W-RAMO-ANT */
                _.Move(W.W_APOLICE_ATU_R.W_RAMO_ATU, W.W_APOLICE_ANT_R.W_RAMO_ANT);

                /*" -667- MOVE W-NUMAPOL-ATU TO W-NUMAPOL-ANT */
                _.Move(W.W_APOLICE_ATU_R.W_NUMAPOL_ATU, W.W_APOLICE_ANT_R.W_NUMAPOL_ANT);

                /*" -668- MOVE 90 TO W-CONT-LIN */
                _.Move(90, W.W_CONT_LIN);

                /*" -669- ELSE */
            }
            else
            {


                /*" -670- IF W-APOLICE-ATU NOT EQUAL W-APOLICE-ANT */

                if (W.W_APOLICE_ATU != W.W_APOLICE_ANT)
                {

                    /*" -671- PERFORM 370-000-IMPRIME-TOTAL */

                    M_370_000_IMPRIME_TOTAL_SECTION();

                    /*" -672- MOVE W-ORGAO-ATU TO W-ORGAO-ANT */
                    _.Move(W.W_APOLICE_ATU_R.W_ORGAO_ATU, W.W_APOLICE_ANT_R.W_ORGAO_ANT);

                    /*" -673- MOVE W-RAMO-ATU TO W-RAMO-ANT */
                    _.Move(W.W_APOLICE_ATU_R.W_RAMO_ATU, W.W_APOLICE_ANT_R.W_RAMO_ANT);

                    /*" -674- MOVE W-NUMAPOL-ATU TO W-NUMAPOL-ANT */
                    _.Move(W.W_APOLICE_ATU_R.W_NUMAPOL_ATU, W.W_APOLICE_ANT_R.W_NUMAPOL_ANT);

                    /*" -675- MOVE 90 TO W-CONT-LIN */
                    _.Move(90, W.W_CONT_LIN);

                    /*" -676- ELSE */
                }
                else
                {


                    /*" -678- MOVE 90 TO W-CONT-LIN. */
                    _.Move(90, W.W_CONT_LIN);
                }

            }


            /*" -679- MOVE '1' TO WFLAG-VEZ. */
            _.Move("1", W.WFLAG_VEZ);

            /*" -680- MOVE 0 TO AC-TMESTSIN. */
            _.Move(0, W.AC_TMESTSIN);

            /*" -682- MOVE 'N' TO WFIM-TMESTSIN1 */
            _.Move("N", W.WFIM_TMESTSIN1);

            /*" -683- PERFORM 240-000-CURSOR-TMESTSIN */

            M_240_000_CURSOR_TMESTSIN_SECTION();

            /*" -684- PERFORM 245-000-LER-TMESTSIN UNTIL WFIM-TMESTSIN1 EQUAL 'S' . */

            while (!(W.WFIM_TMESTSIN1 == "S"))
            {

                M_245_000_LER_TMESTSIN_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_120_010_LEITURA */

            M_120_010_LEITURA();

        }

        [StopWatch]
        /*" M-120-010-LEITURA */
        private void M_120_010_LEITURA(bool isPerform = false)
        {
            /*" -690- MOVE ' ' TO WFIM-TMESTSIN1 */
            _.Move(" ", W.WFIM_TMESTSIN1);

            /*" -692- MOVE 'S' TO WS-PRIMEIRA-VEZ. */
            _.Move("S", W.WS_PRIMEIRA_VEZ);

            /*" -692- PERFORM 150-000-LER-TRELSIN-E. */

            M_150_000_LER_TRELSIN_E_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-E-SECTION */
        private void M_150_000_LER_TRELSIN_E_SECTION()
        {
            /*" -710- MOVE '150-000-LER-TRELSIN-E' TO PARAGRAFO. */
            _.Move("150-000-LER-TRELSIN-E", W.WABEND.PARAGRAFO);

            /*" -714- PERFORM M_150_000_LER_TRELSIN_E_DB_FETCH_1 */

            M_150_000_LER_TRELSIN_E_DB_FETCH_1();

            /*" -717- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -717- PERFORM M_150_000_LER_TRELSIN_E_DB_CLOSE_1 */

                M_150_000_LER_TRELSIN_E_DB_CLOSE_1();

                /*" -719- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -722- GO TO 150-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/ //GOTO
                return;
            }


            /*" -724- MOVE RELSIN-APOLICE TO W-APOLICE-ATU. */
            _.Move(RELSIN_APOLICE, W.W_APOLICE_ATU);

            /*" -725- MOVE RELSIN-DTINIVIG TO W-DTINIVIG-ATU. */
            _.Move(RELSIN_DTINIVIG, W.W_DTINIVIG_ATU);

            /*" -725- MOVE RELSIN-DTTERVIG TO W-DTTERVIG-ATU. */
            _.Move(RELSIN_DTTERVIG, W.W_DTTERVIG_ATU);

        }

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-E-DB-FETCH-1 */
        public void M_150_000_LER_TRELSIN_E_DB_FETCH_1()
        {
            /*" -714- EXEC SQL FETCH V1RELATSINI INTO :RELSIN-APOLICE, :RELSIN-DTINIVIG, :RELSIN-DTTERVIG END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELSIN_APOLICE, RELSIN_APOLICE);
                _.Move(V1RELATSINI.RELSIN_DTINIVIG, RELSIN_DTINIVIG);
                _.Move(V1RELATSINI.RELSIN_DTTERVIG, RELSIN_DTTERVIG);
            }

        }

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-E-DB-CLOSE-1 */
        public void M_150_000_LER_TRELSIN_E_DB_CLOSE_1()
        {
            /*" -717- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-240-000-CURSOR-TMESTSIN-SECTION */
        private void M_240_000_CURSOR_TMESTSIN_SECTION()
        {
            /*" -746- MOVE '240-000-CURSOR-TMESTSIN' TO PARAGRAFO. */
            _.Move("240-000-CURSOR-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -747- MOVE RELSIN-DTINIVIG TO W-DTINIVIG */
            _.Move(RELSIN_DTINIVIG, W_DTINIVIG);

            /*" -748- MOVE RELSIN-DTTERVIG TO W-DTTERVIG */
            _.Move(RELSIN_DTTERVIG, W_DTTERVIG);

            /*" -750- MOVE RELSIN-DTTERVIG TO WDATAX-R */
            _.Move(RELSIN_DTTERVIG, W.WDATAX_R);

            /*" -752- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", W.WABEND.WNR_EXEC_SQL);

            /*" -774- PERFORM M_240_000_CURSOR_TMESTSIN_DB_DECLARE_1 */

            M_240_000_CURSOR_TMESTSIN_DB_DECLARE_1();

            /*" -775- PERFORM M_240_000_CURSOR_TMESTSIN_DB_OPEN_1 */

            M_240_000_CURSOR_TMESTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-240-000-CURSOR-TMESTSIN-DB-OPEN-1 */
        public void M_240_000_CURSOR_TMESTSIN_DB_OPEN_1()
        {
            /*" -775- EXEC SQL OPEN TMESTSIN1 END-EXEC. */

            TMESTSIN1.Open();

        }

        [StopWatch]
        /*" M-270-000-CURSOR-THISTSIN-DB-DECLARE-1 */
        public void M_270_000_CURSOR_THISTSIN_DB_DECLARE_1()
        {
            /*" -904- EXEC SQL DECLARE V1HISTSINI CURSOR FOR SELECT DTMOVTO, VAL_OPERACAO, OPERACAO FROM SEGUROS.V1HISTSINI WHERE OPERACAO IN (102, 103, 112, 113, 105, 106, 115, 116, 1001, 1002, 1003, 1004, 1009, 9001) AND NUM_APOL_SINISTRO = :MEST-APOL-SINI AND SITUACAO IN ( '1' , '0' ) ORDER BY DTMOVTO, OPERACAO END-EXEC. */
            V1HISTSINI = new SI0101B_V1HISTSINI(true);
            string GetQuery_V1HISTSINI()
            {
                var query = @$"SELECT DTMOVTO
							, VAL_OPERACAO
							, 
							OPERACAO 
							FROM SEGUROS.V1HISTSINI 
							WHERE OPERACAO IN (102
							, 
							103
							, 
							112
							, 
							113
							, 
							105
							, 
							106
							, 
							115
							, 
							116
							, 
							1001
							, 
							1002
							, 
							1003
							, 
							1004
							, 
							1009
							, 
							9001) 
							AND NUM_APOL_SINISTRO = '{MEST_APOL_SINI}' 
							AND SITUACAO IN ( '1'
							, '0' ) 
							ORDER BY DTMOVTO
							, OPERACAO";

                return query;
            }
            V1HISTSINI.GetQueryEvent += GetQuery_V1HISTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-245-000-LER-TMESTSIN-SECTION */
        private void M_245_000_LER_TMESTSIN_SECTION()
        {
            /*" -794- MOVE '245-000-LER-TMESTSIN' TO PARAGRAFO. */
            _.Move("245-000-LER-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -805- PERFORM M_245_000_LER_TMESTSIN_DB_FETCH_1 */

            M_245_000_LER_TMESTSIN_DB_FETCH_1();

            /*" -808- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -808- PERFORM M_245_000_LER_TMESTSIN_DB_CLOSE_1 */

                M_245_000_LER_TMESTSIN_DB_CLOSE_1();

                /*" -810- MOVE 'S' TO WFIM-TMESTSIN1 */
                _.Move("S", W.WFIM_TMESTSIN1);

                /*" -811- ELSE */
            }
            else
            {


                /*" -812- MOVE 1 TO AC-TMESTSIN */
                _.Move(1, W.AC_TMESTSIN);

                /*" -813- PERFORM 300-000-MOVE-OPERACAO-101 */

                M_300_000_MOVE_OPERACAO_101_SECTION();

                /*" -814- MOVE ' ' TO WFIM-THISTSIN */
                _.Move(" ", W.WFIM_THISTSIN);

                /*" -815- PERFORM 260-000-LER-TCLIENTE */

                M_260_000_LER_TCLIENTE_SECTION();

                /*" -816- PERFORM 270-000-CURSOR-THISTSIN */

                M_270_000_CURSOR_THISTSIN_SECTION();

                /*" -819- PERFORM 280-000-LER-THISTSIN UNTIL WFIM-THISTSIN EQUAL 'S' . */

                while (!(W.WFIM_THISTSIN == "S"))
                {

                    M_280_000_LER_THISTSIN_SECTION();
                }
            }


            /*" -819- MOVE ' ' TO WFIM-THISTSIN. */
            _.Move(" ", W.WFIM_THISTSIN);

        }

        [StopWatch]
        /*" M-245-000-LER-TMESTSIN-DB-FETCH-1 */
        public void M_245_000_LER_TMESTSIN_DB_FETCH_1()
        {
            /*" -805- EXEC SQL FETCH TMESTSIN1 INTO :MEST-APOL-SINI, :MEST-DATCMD, :MEST-DATORR, :MEST-FONTE, :MEST-CODSUBES, :THIST-DTMOVTO1, :THIST-VALPRI1, :MEST-MOEDA-SIN, :MEST-RAMO, :MEST-CODCAU END-EXEC. */

            if (TMESTSIN1.Fetch())
            {
                _.Move(TMESTSIN1.MEST_APOL_SINI, MEST_APOL_SINI);
                _.Move(TMESTSIN1.MEST_DATCMD, MEST_DATCMD);
                _.Move(TMESTSIN1.MEST_DATORR, MEST_DATORR);
                _.Move(TMESTSIN1.MEST_FONTE, MEST_FONTE);
                _.Move(TMESTSIN1.MEST_CODSUBES, MEST_CODSUBES);
                _.Move(TMESTSIN1.THIST_DTMOVTO1, THIST_DTMOVTO1);
                _.Move(TMESTSIN1.THIST_VALPRI1, THIST_VALPRI1);
                _.Move(TMESTSIN1.MEST_MOEDA_SIN, MEST_MOEDA_SIN);
                _.Move(TMESTSIN1.MEST_RAMO, MEST_RAMO);
                _.Move(TMESTSIN1.MEST_CODCAU, MEST_CODCAU);
            }

        }

        [StopWatch]
        /*" M-245-000-LER-TMESTSIN-DB-CLOSE-1 */
        public void M_245_000_LER_TMESTSIN_DB_CLOSE_1()
        {
            /*" -808- EXEC SQL CLOSE TMESTSIN1 END-EXEC */

            TMESTSIN1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_245_999_EXIT*/

        [StopWatch]
        /*" M-260-000-LER-TCLIENTE-SECTION */
        private void M_260_000_LER_TCLIENTE_SECTION()
        {
            /*" -834- MOVE '260-000-LER-TCLIENTE' TO PARAGRAFO. */
            _.Move("260-000-LER-TCLIENTE", W.WABEND.PARAGRAFO);

            /*" -836- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", W.WABEND.WNR_EXEC_SQL);

            /*" -845- PERFORM M_260_000_LER_TCLIENTE_DB_SELECT_1 */

            M_260_000_LER_TCLIENTE_DB_SELECT_1();

            /*" -848- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -849- DISPLAY 'SI0101B- NAO EXISTE REGISTRO NA TSUBGRUPO' */
                _.Display($"SI0101B- NAO EXISTE REGISTRO NA TSUBGRUPO");

                /*" -850- DISPLAY 'NUM-APOLICE = ' RELSIN-APOLICE */
                _.Display($"NUM-APOLICE = {RELSIN_APOLICE}");

                /*" -852- DISPLAY 'COD-SUBGRUPO= ' MEST-CODSUBES. */
                _.Display($"COD-SUBGRUPO= {MEST_CODSUBES}");
            }


            /*" -860- PERFORM M_260_000_LER_TCLIENTE_DB_SELECT_2 */

            M_260_000_LER_TCLIENTE_DB_SELECT_2();

            /*" -863- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -864- DISPLAY 'SI0101B- NAO EXISTE REGISTRO NA TCLIENTE' */
                _.Display($"SI0101B- NAO EXISTE REGISTRO NA TCLIENTE");

                /*" -864- DISPLAY 'COD-CLIENTE = ' CLIE-COD-CLIENTE. */
                _.Display($"COD-CLIENTE = {CLIE_COD_CLIENTE}");
            }


        }

        [StopWatch]
        /*" M-260-000-LER-TCLIENTE-DB-SELECT-1 */
        public void M_260_000_LER_TCLIENTE_DB_SELECT_1()
        {
            /*" -845- EXEC SQL SELECT COD_CLIENTE INTO :CLIE-COD-CLIENTE FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :RELSIN-APOLICE AND COD_SUBGRUPO = :MEST-CODSUBES END-EXEC. */

            var m_260_000_LER_TCLIENTE_DB_SELECT_1_Query1 = new M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1()
            {
                RELSIN_APOLICE = RELSIN_APOLICE.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
            };

            var executed_1 = M_260_000_LER_TCLIENTE_DB_SELECT_1_Query1.Execute(m_260_000_LER_TCLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_COD_CLIENTE, CLIE_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-260-000-LER-TCLIENTE-DB-SELECT-2 */
        public void M_260_000_LER_TCLIENTE_DB_SELECT_2()
        {
            /*" -860- EXEC SQL SELECT NOME_RAZAO INTO :CLIE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :CLIE-COD-CLIENTE END-EXEC. */

            var m_260_000_LER_TCLIENTE_DB_SELECT_2_Query1 = new M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1()
            {
                CLIE_COD_CLIENTE = CLIE_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1.Execute(m_260_000_LER_TCLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_NOME_RAZAO, CLIE_NOME_RAZAO);
            }


        }

        [StopWatch]
        /*" M-270-000-CURSOR-THISTSIN-SECTION */
        private void M_270_000_CURSOR_THISTSIN_SECTION()
        {
            /*" -880- MOVE '270-000-CURSOR-THISTSIN' TO PARAGRAFO. */
            _.Move("270-000-CURSOR-THISTSIN", W.WABEND.PARAGRAFO);

            /*" -883- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", W.WABEND.WNR_EXEC_SQL);

            /*" -904- PERFORM M_270_000_CURSOR_THISTSIN_DB_DECLARE_1 */

            M_270_000_CURSOR_THISTSIN_DB_DECLARE_1();

            /*" -905- PERFORM M_270_000_CURSOR_THISTSIN_DB_OPEN_1 */

            M_270_000_CURSOR_THISTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-270-000-CURSOR-THISTSIN-DB-OPEN-1 */
        public void M_270_000_CURSOR_THISTSIN_DB_OPEN_1()
        {
            /*" -905- EXEC SQL OPEN V1HISTSINI END-EXEC. */

            V1HISTSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-280-000-LER-THISTSIN-SECTION */
        private void M_280_000_LER_THISTSIN_SECTION()
        {
            /*" -924- MOVE '280-000-LER-THISTSIN' TO PARAGRAFO. */
            _.Move("280-000-LER-THISTSIN", W.WABEND.PARAGRAFO);

            /*" -927- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", W.WABEND.WNR_EXEC_SQL);

            /*" -930- PERFORM M_280_000_LER_THISTSIN_DB_FETCH_1 */

            M_280_000_LER_THISTSIN_DB_FETCH_1();

            /*" -933- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -933- PERFORM M_280_000_LER_THISTSIN_DB_CLOSE_1 */

                M_280_000_LER_THISTSIN_DB_CLOSE_1();

                /*" -935- MOVE 'S' TO WFIM-THISTSIN */
                _.Move("S", W.WFIM_THISTSIN);

                /*" -938- IF WS-VALOR-PAGO = ZEROS */

                if (W.WS_VALOR_PAGO == 00)
                {

                    /*" -939- PERFORM 360-000-IMPRIME */

                    M_360_000_IMPRIME_SECTION();

                    /*" -940- GO TO 280-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/ //GOTO
                    return;

                    /*" -941- ELSE */
                }
                else
                {


                    /*" -943- GO TO 280-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -945- PERFORM 600-000-CALCULA-VALOR. */

            M_600_000_CALCULA_VALOR_SECTION();

            /*" -949- IF THIST-OPERACAO EQUAL 102 OR THIST-OPERACAO EQUAL 103 OR THIST-OPERACAO EQUAL 112 OR THIST-OPERACAO EQUAL 113 */

            if (THIST_OPERACAO == 102 || THIST_OPERACAO == 103 || THIST_OPERACAO == 112 || THIST_OPERACAO == 113)
            {

                /*" -950- ADD THIST-VALPRI TO WS-VALOR-AVIS */
                W.WS_VALOR_AVIS.Value = W.WS_VALOR_AVIS + THIST_VALPRI;

                /*" -951- ADD THIST-QTD-MOEDA TO WS-QTDE-AVIS */
                W.WS_QTDE_AVIS.Value = W.WS_QTDE_AVIS + THIST_QTD_MOEDA;

                /*" -952- GO TO 280-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/ //GOTO
                return;

                /*" -953- ELSE */
            }
            else
            {


                /*" -957- IF THIST-OPERACAO EQUAL 105 OR THIST-OPERACAO EQUAL 106 OR THIST-OPERACAO EQUAL 115 OR THIST-OPERACAO EQUAL 116 */

                if (THIST_OPERACAO == 105 || THIST_OPERACAO == 106 || THIST_OPERACAO == 115 || THIST_OPERACAO == 116)
                {

                    /*" -958- SUBTRACT THIST-VALPRI FROM WS-VALOR-AVIS */
                    W.WS_VALOR_AVIS.Value = W.WS_VALOR_AVIS - THIST_VALPRI;

                    /*" -959- SUBTRACT THIST-QTD-MOEDA FROM WS-QTDE-AVIS */
                    W.WS_QTDE_AVIS.Value = W.WS_QTDE_AVIS - THIST_QTD_MOEDA;

                    /*" -963- GO TO 280-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -966- IF WS-VALOR-PAGO = ZEROS */

            if (W.WS_VALOR_PAGO == 00)
            {

                /*" -967- MOVE WS-VALOR-AVIS TO LD01-VA-CRUZ */
                _.Move(W.WS_VALOR_AVIS, W.LD01.LD01_VA_CRUZ);

                /*" -968- MOVE WS-QTDE-AVIS TO LD01-VA-BTNF */
                _.Move(W.WS_QTDE_AVIS, W.LD01.LD01_VA_BTNF);

                /*" -969- ELSE */
            }
            else
            {


                /*" -972- MOVE SPACES TO LD01. */
                _.Move("", W.LD01);
            }


            /*" -973- MOVE THIST-DTMOVTO TO WDATA-R */
            _.Move(THIST_DTMOVTO, W.WDATA_R);

            /*" -974- MOVE WDATA-DD TO LD01-DTPAGTO-DD */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_DD);

            /*" -975- MOVE WDATA-MM TO LD01-DTPAGTO-MM */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_MM);

            /*" -976- MOVE WDATA-AA TO LD01-DTPAGTO-AA */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_AA);

            /*" -977- MOVE '/' TO LD01-FIL3 */
            _.Move("/", W.LD01.LD01_DTPAGTO.LD01_FIL3);

            /*" -978- MOVE '/' TO LD01-FIL4 */
            _.Move("/", W.LD01.LD01_DTPAGTO.LD01_FIL4);

            /*" -979- MOVE THIST-VALPRI TO LD01-VP-CRUZ */
            _.Move(THIST_VALPRI, W.LD01.LD01_VP_CRUZ);

            /*" -980- MOVE THIST-QTD-MOEDA TO LD01-VP-BTNF */
            _.Move(THIST_QTD_MOEDA, W.LD01.LD01_VP_BTNF);

            /*" -985- MOVE THIST-VALPRI TO WS-VALOR-PAGO. */
            _.Move(THIST_VALPRI, W.WS_VALOR_PAGO);

            /*" -986- IF THIST-OPERACAO EQUAL 1001 */

            if (THIST_OPERACAO == 1001)
            {

                /*" -987- MOVE 'PAGAMENTO PARCIAL' TO LD01-OBS */
                _.Move("PAGAMENTO PARCIAL", W.LD01.LD01_OBS);

                /*" -988- ELSE */
            }
            else
            {


                /*" -989- IF THIST-OPERACAO EQUAL 1002 */

                if (THIST_OPERACAO == 1002)
                {

                    /*" -990- MOVE 'PAGAMENTO FINAL ' TO LD01-OBS */
                    _.Move("PAGAMENTO FINAL ", W.LD01.LD01_OBS);

                    /*" -991- ELSE */
                }
                else
                {


                    /*" -992- IF THIST-OPERACAO EQUAL 1003 */

                    if (THIST_OPERACAO == 1003)
                    {

                        /*" -993- MOVE 'PAGAMENTO TOTAL ' TO LD01-OBS */
                        _.Move("PAGAMENTO TOTAL ", W.LD01.LD01_OBS);

                        /*" -994- ELSE */
                    }
                    else
                    {


                        /*" -995- IF THIST-OPERACAO EQUAL 1004 */

                        if (THIST_OPERACAO == 1004)
                        {

                            /*" -996- MOVE 'PAGTO.COMPLEMENTAR' TO LD01-OBS */
                            _.Move("PAGTO.COMPLEMENTAR", W.LD01.LD01_OBS);

                            /*" -997- ELSE */
                        }
                        else
                        {


                            /*" -998- IF THIST-OPERACAO EQUAL 1009 */

                            if (THIST_OPERACAO == 1009)
                            {

                                /*" -999- MOVE 'INDZ.S/EMIS.CHEQUE' TO LD01-OBS */
                                _.Move("INDZ.S/EMIS.CHEQUE", W.LD01.LD01_OBS);

                                /*" -1000- ELSE */
                            }
                            else
                            {


                                /*" -1001- IF THIST-OPERACAO EQUAL 9001 */

                                if (THIST_OPERACAO == 9001)
                                {

                                    /*" -1004- MOVE 'ADIANTAMENTO    ' TO LD01-OBS. */
                                    _.Move("ADIANTAMENTO    ", W.LD01.LD01_OBS);
                                }

                            }

                        }

                    }

                }

            }


            /*" -1004- PERFORM 360-000-IMPRIME. */

            M_360_000_IMPRIME_SECTION();

        }

        [StopWatch]
        /*" M-280-000-LER-THISTSIN-DB-FETCH-1 */
        public void M_280_000_LER_THISTSIN_DB_FETCH_1()
        {
            /*" -930- EXEC SQL FETCH V1HISTSINI INTO :THIST-DTMOVTO, :THIST-VALPRI, :THIST-OPERACAO END-EXEC. */

            if (V1HISTSINI.Fetch())
            {
                _.Move(V1HISTSINI.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(V1HISTSINI.THIST_VALPRI, THIST_VALPRI);
                _.Move(V1HISTSINI.THIST_OPERACAO, THIST_OPERACAO);
            }

        }

        [StopWatch]
        /*" M-280-000-LER-THISTSIN-DB-CLOSE-1 */
        public void M_280_000_LER_THISTSIN_DB_CLOSE_1()
        {
            /*" -933- EXEC SQL CLOSE V1HISTSINI END-EXEC */

            V1HISTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/

        [StopWatch]
        /*" M-300-000-MOVE-OPERACAO-101-SECTION */
        private void M_300_000_MOVE_OPERACAO_101_SECTION()
        {
            /*" -1020- MOVE '300-000-MOVE-OPERACAO' TO PARAGRAFO. */
            _.Move("300-000-MOVE-OPERACAO", W.WABEND.PARAGRAFO);

            /*" -1022- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", W.WABEND.WNR_EXEC_SQL);

            /*" -1023- MOVE SPACES TO LD01 */
            _.Move("", W.LD01);

            /*" -1024- MOVE 'PENDENTE         ' TO LD01-OBS */
            _.Move("PENDENTE         ", W.LD01.LD01_OBS);

            /*" -1026- MOVE MEST-APOL-SINI TO LD01-SINISTRO */
            _.Move(MEST_APOL_SINI, W.LD01.LD01_SINISTRO);

            /*" -1028- MOVE MEST-FONTE TO LD01-FONTE */
            _.Move(MEST_FONTE, W.LD01.LD01_FONTE);

            /*" -1029- MOVE MEST-DATORR TO WDATA-R */
            _.Move(MEST_DATORR, W.WDATA_R);

            /*" -1030- MOVE WDATA-DD TO LD01-DTORR-DD */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTORR.LD01_DTORR_DD);

            /*" -1031- MOVE WDATA-MM TO LD01-DTORR-MM */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTORR.LD01_DTORR_MM);

            /*" -1032- MOVE WDATA-AA TO LD01-DTORR-AA */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTORR.LD01_DTORR_AA);

            /*" -1033- MOVE '/' TO LD01-FIL5 */
            _.Move("/", W.LD01.LD01_DTORR.LD01_FIL5);

            /*" -1035- MOVE '/' TO LD01-FIL6 */
            _.Move("/", W.LD01.LD01_DTORR.LD01_FIL6);

            /*" -1036- MOVE MEST-DATCMD TO WDATA-R */
            _.Move(MEST_DATCMD, W.WDATA_R);

            /*" -1037- MOVE WDATA-DD TO LD01-DTCMD-DD */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTCMD.LD01_DTCMD_DD);

            /*" -1038- MOVE WDATA-MM TO LD01-DTCMD-MM */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTCMD.LD01_DTCMD_MM);

            /*" -1039- MOVE WDATA-AA TO LD01-DTCMD-AA */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTCMD.LD01_DTCMD_AA);

            /*" -1040- MOVE '/' TO LD01-FIL1 */
            _.Move("/", W.LD01.LD01_DTCMD.LD01_FIL1);

            /*" -1042- MOVE '/' TO LD01-FIL2 */
            _.Move("/", W.LD01.LD01_DTCMD.LD01_FIL2);

            /*" -1045- MOVE THIST-VALPRI1 TO WS-VALOR-AVIS LD01-VA-CRUZ */
            _.Move(THIST_VALPRI1, W.WS_VALOR_AVIS, W.LD01.LD01_VA_CRUZ);

            /*" -1046- MOVE THIST-VALPRI1 TO THIST-VALPRI */
            _.Move(THIST_VALPRI1, THIST_VALPRI);

            /*" -1047- MOVE MEST-DATCMD TO THIST-DTMOVTO */
            _.Move(MEST_DATCMD, THIST_DTMOVTO);

            /*" -1048- PERFORM 600-000-CALCULA-VALOR. */

            M_600_000_CALCULA_VALOR_SECTION();

            /*" -1051- MOVE THIST-QTD-MOEDA TO WS-QTDE-AVIS LD01-VA-BTNF */
            _.Move(THIST_QTD_MOEDA, W.WS_QTDE_AVIS, W.LD01.LD01_VA_BTNF);

            /*" -1055- MOVE GEUNIMO-SIGLUNIM TO LD01-MOEDA. */
            _.Move(GEUNIMO_SIGLUNIM, W.LD01.LD01_MOEDA);

            /*" -1055- MOVE +0 TO WS-VALOR-PAGO. */
            _.Move(+0, W.WS_VALOR_PAGO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-330-000-LER-TAPOLICE-SECTION */
        private void M_330_000_LER_TAPOLICE_SECTION()
        {
            /*" -1071- MOVE '330-000-LER-TAPOLICE' TO PARAGRAFO. */
            _.Move("330-000-LER-TAPOLICE", W.WABEND.PARAGRAFO);

            /*" -1073- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", W.WABEND.WNR_EXEC_SQL);

            /*" -1076- MOVE W-APOLICE-ANT TO W-SINISTRO. */
            _.Move(W.W_APOLICE_ANT, W_SINISTRO);

            /*" -1084- PERFORM M_330_000_LER_TAPOLICE_DB_SELECT_1 */

            M_330_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -1087- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1088- MOVE SPACES TO LC05-SEGURADO */
                _.Move("", W.LC05.LC05_SEGURADO);

                /*" -1089- DISPLAY 'SI0101B- NAO EXISTE REGISTRO NA TAPOLICE' */
                _.Display($"SI0101B- NAO EXISTE REGISTRO NA TAPOLICE");

                /*" -1090- DISPLAY 'APOL-SINI = ' RELSIN-APOLICE */
                _.Display($"APOL-SINI = {RELSIN_APOLICE}");

                /*" -1091- ELSE */
            }
            else
            {


                /*" -1091- MOVE APOL-NOME TO LC05-SEGURADO. */
                _.Move(APOL_NOME, W.LC05.LC05_SEGURADO);
            }


        }

        [StopWatch]
        /*" M-330-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_330_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -1084- EXEC SQL SELECT NOME INTO :APOL-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :W-SINISTRO END-EXEC. */

            var m_330_000_LER_TAPOLICE_DB_SELECT_1_Query1 = new M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1()
            {
                W_SINISTRO = W_SINISTRO.ToString(),
            };

            var executed_1 = M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1.Execute(m_330_000_LER_TAPOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_NOME, APOL_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-360-000-IMPRIME-SECTION */
        private void M_360_000_IMPRIME_SECTION()
        {
            /*" -1105- MOVE '360-000-IMPRIME' TO PARAGRAFO. */
            _.Move("360-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -1107- IF W-CONT-LIN GREATER 60 OR MEST-CODSUBES NOT EQUAL LC5A-CODSUBES */

            if (W.W_CONT_LIN > 60 || MEST_CODSUBES != W.LC5A.LC5A_CODSUBES)
            {

                /*" -1111- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -1112- PERFORM 360-010-ACESSA-V0SINICAUSA. */

            M_360_010_ACESSA_V0SINICAUSA_SECTION();

            /*" -1114- MOVE SCAU-DESCAU TO LD02-DESCAU. */
            _.Move(SCAU_DESCAU, W.LD02.LD02_DESCAU);

            /*" -1116- WRITE REG-SI0101M1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1119- WRITE REG-SI0101M1 FROM LD02 AFTER 1. */
            _.Move(W.LD02.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1120- ADD 1 TO WIMPRES. */
            W.WIMPRES.Value = W.WIMPRES + 1;

            /*" -1122- ADD 3 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 3;

            /*" -1123- ADD WS-VALOR-AVIS TO WS-SUBES-AVIS. */
            W.WS_SUBES_AVIS.Value = W.WS_SUBES_AVIS + W.WS_VALOR_AVIS;

            /*" -1124- IF WS-VALOR-PAGO NOT = +0 */

            if (W.WS_VALOR_PAGO != +0)
            {

                /*" -1125- ADD THIST-VALPRI TO WS-SUBES-PAGO. */
                W.WS_SUBES_PAGO.Value = W.WS_SUBES_PAGO + THIST_VALPRI;
            }


            /*" -1125- MOVE +0 TO WS-VALOR-AVIS. */
            _.Move(+0, W.WS_VALOR_AVIS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-360-010-ACESSA-V0SINICAUSA-SECTION */
        private void M_360_010_ACESSA_V0SINICAUSA_SECTION()
        {
            /*" -1141- MOVE '360-010-ACESSA-V0SINICAUSA' TO PARAGRAFO. */
            _.Move("360-010-ACESSA-V0SINICAUSA", W.WABEND.PARAGRAFO);

            /*" -1143- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", W.WABEND.WNR_EXEC_SQL);

            /*" -1150- PERFORM M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1 */

            M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1();

            /*" -1153- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1154- DISPLAY 'SI0101B - NAO CONSTA CAUSA DO SINISTRO' */
                _.Display($"SI0101B - NAO CONSTA CAUSA DO SINISTRO");

                /*" -1154- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-360-010-ACESSA-V0SINICAUSA-DB-SELECT-1 */
        public void M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1()
        {
            /*" -1150- EXEC SQL SELECT DESCAU INTO :SCAU-DESCAU FROM SEGUROS.V0SINICAUSA WHERE RAMO = :MEST-RAMO AND CODCAU = :MEST-CODCAU END-EXEC. */

            var m_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1 = new M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1()
            {
                MEST_CODCAU = MEST_CODCAU.ToString(),
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1.Execute(m_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SCAU_DESCAU, SCAU_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_010_EXIT*/

        [StopWatch]
        /*" M-370-000-IMPRIME-TOTAL-SECTION */
        private void M_370_000_IMPRIME_TOTAL_SECTION()
        {
            /*" -1167- MOVE '370-000-IMPRIME-TOTAL' TO PARAGRAFO. */
            _.Move("370-000-IMPRIME-TOTAL", W.WABEND.PARAGRAFO);

            /*" -1168- MOVE 9999 TO LC5A-CODSUBES. */
            _.Move(9999, W.LC5A.LC5A_CODSUBES);

            /*" -1170- MOVE 'TOTAL GERAL' TO LC5A-NOME-RAZAO. */
            _.Move("TOTAL GERAL", W.LC5A.LC5A_NOME_RAZAO);

            /*" -1171- MOVE WS-SUBES-AVIS TO LT02-VALOR-AVIS */
            _.Move(W.WS_SUBES_AVIS, W.LT02.LT02_VALOR_AVIS);

            /*" -1172- MOVE WS-SUBES-PAGO TO LT02-VALOR-PAGO */
            _.Move(W.WS_SUBES_PAGO, W.LT02.LT02_VALOR_PAGO);

            /*" -1173- ADD WS-SUBES-AVIS TO WS-TOTAL-AVIS */
            W.WS_TOTAL_AVIS.Value = W.WS_TOTAL_AVIS + W.WS_SUBES_AVIS;

            /*" -1175- ADD WS-SUBES-PAGO TO WS-TOTAL-PAGO */
            W.WS_TOTAL_PAGO.Value = W.WS_TOTAL_PAGO + W.WS_SUBES_PAGO;

            /*" -1178- WRITE REG-SI0101M1 FROM LT02 AFTER 2. */
            _.Move(W.LT02.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1180- IF WS-TOTAL-AVIS = ZEROS AND WS-TOTAL-PAGO = ZEROS */

            if (W.WS_TOTAL_AVIS == 00 && W.WS_TOTAL_PAGO == 00)
            {

                /*" -1182- DISPLAY 'SI0101B - APOLICE DESPREZADA - SEM MOVTO = ' W-APOLICE-ANT */
                _.Display($"SI0101B - APOLICE DESPREZADA - SEM MOVTO = {W.W_APOLICE_ANT}");

                /*" -1184- GO TO 370-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/ //GOTO
                return;
            }


            /*" -1185- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -1188- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -1189- MOVE WS-TOTAL-AVIS TO LT01-VALOR-AVIS. */
            _.Move(W.WS_TOTAL_AVIS, W.LT01.LT01_VALOR_AVIS);

            /*" -1191- MOVE WS-TOTAL-PAGO TO LT01-VALOR-PAGO. */
            _.Move(W.WS_TOTAL_PAGO, W.LT01.LT01_VALOR_PAGO);

            /*" -1194- WRITE REG-SI0101M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1195- ADD 4 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 4;

            /*" -1202- MOVE +0 TO WS-TOTAL-AVIS WS-TOTAL-PAGO WS-SUBES-AVIS WS-SUBES-PAGO WS-VALOR-AVIS WS-VALOR-PAGO WS-QTDE-AVIS WS-QTDE-PAGO. */
            _.Move(+0, W.WS_TOTAL_AVIS, W.WS_TOTAL_PAGO, W.WS_SUBES_AVIS, W.WS_SUBES_PAGO, W.WS_VALOR_AVIS, W.WS_VALOR_PAGO, W.WS_QTDE_AVIS, W.WS_QTDE_PAGO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/

        [StopWatch]
        /*" M-390-000-CABEC-SECTION */
        private void M_390_000_CABEC_SECTION()
        {
            /*" -1215- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -1217- IF W-CONT-PAG NOT EQUAL 0 AND MEST-CODSUBES NOT EQUAL LC5A-CODSUBES */

            if (W.W_CONT_PAG != 0 && MEST_CODSUBES != W.LC5A.LC5A_CODSUBES)
            {

                /*" -1218- MOVE WS-SUBES-AVIS TO LT02-VALOR-AVIS */
                _.Move(W.WS_SUBES_AVIS, W.LT02.LT02_VALOR_AVIS);

                /*" -1219- MOVE WS-SUBES-PAGO TO LT02-VALOR-PAGO */
                _.Move(W.WS_SUBES_PAGO, W.LT02.LT02_VALOR_PAGO);

                /*" -1220- ADD WS-SUBES-AVIS TO WS-TOTAL-AVIS */
                W.WS_TOTAL_AVIS.Value = W.WS_TOTAL_AVIS + W.WS_SUBES_AVIS;

                /*" -1221- ADD WS-SUBES-PAGO TO WS-TOTAL-PAGO */
                W.WS_TOTAL_PAGO.Value = W.WS_TOTAL_PAGO + W.WS_SUBES_PAGO;

                /*" -1222- MOVE 0 TO WS-SUBES-AVIS */
                _.Move(0, W.WS_SUBES_AVIS);

                /*" -1224- MOVE 0 TO WS-SUBES-PAGO */
                _.Move(0, W.WS_SUBES_PAGO);

                /*" -1227- WRITE REG-SI0101M1 FROM LT02 AFTER 2. */
                _.Move(W.LT02.GetMoveValues(), REG_SI0101M1);

                SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());
            }


            /*" -1228- MOVE MEST-CODSUBES TO LC5A-CODSUBES */
            _.Move(MEST_CODSUBES, W.LC5A.LC5A_CODSUBES);

            /*" -1230- MOVE CLIE-NOME-RAZAO TO LC5A-NOME-RAZAO */
            _.Move(CLIE_NOME_RAZAO, W.LC5A.LC5A_NOME_RAZAO);

            /*" -1231- ADD 1 TO W-CONT-PAG. */
            W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

            /*" -1234- MOVE W-CONT-PAG TO LC01-PAG. */
            _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

            /*" -1235- MOVE W-ORGAO-ANT TO LC05-ORGAO */
            _.Move(W.W_APOLICE_ANT_R.W_ORGAO_ANT, W.LC05.FILLER_18.LC05_ORGAO);

            /*" -1236- MOVE W-RAMO-ANT TO LC05-RAMO */
            _.Move(W.W_APOLICE_ANT_R.W_RAMO_ANT, W.LC05.FILLER_18.LC05_RAMO);

            /*" -1238- MOVE W-NUMAPOL-ANT TO LC05-NUMAPOL. */
            _.Move(W.W_APOLICE_ANT_R.W_NUMAPOL_ANT, W.LC05.FILLER_18.LC05_NUMAPOL);

            /*" -1240- PERFORM 330-000-LER-TAPOLICE. */

            M_330_000_LER_TAPOLICE_SECTION();

            /*" -1243- WRITE REG-SI0101M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1246- WRITE REG-SI0101M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1250- WRITE REG-SI0101M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1251- MOVE W-DTINIVIG-ANT TO WDATA-R */
            _.Move(W.W_DTINIVIG_ANT, W.WDATA_R);

            /*" -1252- MOVE WDATA-DD TO LC04C-DDI */
            _.Move(W.WDATA.WDATA_DD, W.LC04C.LC04C_DATA.LC04C_DDI);

            /*" -1253- MOVE WDATA-MM TO LC04C-MMI */
            _.Move(W.WDATA.WDATA_MM, W.LC04C.LC04C_DATA.LC04C_MMI);

            /*" -1254- MOVE WDATA-AA TO LC04C-AAI */
            _.Move(W.WDATA.WDATA_AA, W.LC04C.LC04C_DATA.LC04C_AAI);

            /*" -1255- MOVE W-DTTERVIG-ANT TO WDATAX-R */
            _.Move(W.W_DTTERVIG_ANT, W.WDATAX_R);

            /*" -1256- MOVE W-DTTERVIG-ANT TO WDATA-R */
            _.Move(W.W_DTTERVIG_ANT, W.WDATA_R);

            /*" -1257- MOVE WDATA-DD TO LC04C-DDF */
            _.Move(W.WDATA.WDATA_DD, W.LC04C.LC04C_DATA_0.LC04C_DDF);

            /*" -1258- MOVE WDATA-MM TO LC04C-MMF */
            _.Move(W.WDATA.WDATA_MM, W.LC04C.LC04C_DATA_0.LC04C_MMF);

            /*" -1259- MOVE WDATA-AA TO LC04C-AAF */
            _.Move(W.WDATA.WDATA_AA, W.LC04C.LC04C_DATA_0.LC04C_AAF);

            /*" -1262- WRITE REG-SI0101M1 FROM LC04C AFTER 1 */
            _.Move(W.LC04C.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1265- WRITE REG-SI0101M1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1268- WRITE REG-SI0101M1 FROM LC5A AFTER 1. */
            _.Move(W.LC5A.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1271- WRITE REG-SI0101M1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1274- WRITE REG-SI0101M1 FROM LC07 AFTER 1. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1277- WRITE REG-SI0101M1 FROM LC08 AFTER 1. */
            _.Move(W.LC08.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1280- WRITE REG-SI0101M1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0101M1);

            SI0101M1.Write(REG_SI0101M1.GetMoveValues().ToString());

            /*" -1280- MOVE 10 TO W-CONT-LIN. */
            _.Move(10, W.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELSIN-E-SECTION */
        private void M_600_000_ATUALIZA_TRELSIN_E_SECTION()
        {
            /*" -1296- MOVE '600-000-ATUALIZA-TRELSIN' TO PARAGRAFO. */
            _.Move("600-000-ATUALIZA-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -1299- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", W.WABEND.WNR_EXEC_SQL);

            /*" -1305- PERFORM M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1 */

            M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELSIN-E-DB-DELETE-1 */
        public void M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1()
        {
            /*" -1305- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0101B' AND DATA_SOLICITACAO = :SIST-DTMOVABE END-EXEC. */

            var m_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1 = new M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
            };

            M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1.Execute(m_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-600-000-CALCULA-VALOR-SECTION */
        private void M_600_000_CALCULA_VALOR_SECTION()
        {
            /*" -1322- MOVE MEST-MOEDA-SIN TO WGEUNIMO-CODUNIMO WMOEDA. */
            _.Move(MEST_MOEDA_SIN, W.WGEUNIMO_CODUNIMO, WMOEDA);

            /*" -1325- MOVE THIST-DTMOVTO TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(THIST_DTMOVTO, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -1327- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -1328- COMPUTE THIST-QTD-MOEDA = THIST-VALPRI / GEUNIMO-VLCRUZAD. */
            THIST_QTD_MOEDA.Value = THIST_VALPRI / GEUNIMO_VLCRUZAD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_0_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-SECTION */
        private void M_610_000_LER_TGEUNIMO_SECTION()
        {
            /*" -1341- MOVE '610' TO WNR-EXEC-SQL */
            _.Move("610", W.WABEND.WNR_EXEC_SQL);

            /*" -1344- MOVE '610-000-LER-TGEUNIMO' TO PARAGRAFO. */
            _.Move("610-000-LER-TGEUNIMO", W.WABEND.PARAGRAFO);

            /*" -1353- PERFORM M_610_000_LER_TGEUNIMO_DB_SELECT_1 */

            M_610_000_LER_TGEUNIMO_DB_SELECT_1();

            /*" -1356- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1360- DISPLAY 'SI0101B  - NAO CONSTA REGISTRO NA V1MOEDA ' ' - CODUNIMO = ' WMOEDA ' - DTINIVIG = ' WGEUNIMO-DTINIVIG ' - DTTERVIG = ' WGEUNIMO-DTTERVIG */

                $"SI0101B  - NAO CONSTA REGISTRO NA V1MOEDA  - CODUNIMO = {WMOEDA} - DTINIVIG = {WGEUNIMO_DTINIVIG} - DTTERVIG = {WGEUNIMO_DTTERVIG}"
                .Display();

                /*" -1360- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-DB-SELECT-1 */
        public void M_610_000_LER_TGEUNIMO_DB_SELECT_1()
        {
            /*" -1353- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :GEUNIMO-VLCRUZAD, :GEUNIMO-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WMOEDA AND DTINIVIG <= :WGEUNIMO-DTINIVIG AND DTTERVIG >= :WGEUNIMO-DTTERVIG END-EXEC. */

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
                _.Move(executed_1.GEUNIMO_SIGLUNIM, GEUNIMO_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -1378- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -1382- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -1384- CLOSE SI0101M1. */
            SI0101M1.Close();

            /*" -1387- DISPLAY 'TOTAL IMPRESSOS EMISSAO   = ' WIMPRES. */
            _.Display($"TOTAL IMPRESSOS EMISSAO   = {W.WIMPRES}");

            /*" -1388- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1388- DISPLAY 'SI0101B        *** FIM NORMAL ***' . */
            _.Display($"SI0101B        *** FIM NORMAL ***");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1401- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1402- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1403- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1404- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1405- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1407- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1408- CLOSE SI0101M1. */
            SI0101M1.Close();

            /*" -1408- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1409- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1411- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1411- GOBACK. */

            throw new GoBack();

        }
    }
}