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
using Sias.Auto.DB2.AU0025S;

namespace Code
{
    public class AU0025S
    {
        public bool IsCall { get; set; }

        public AU0025S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *========================                                               */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *                      S U B R O T I N A    A                 //      */
        /*"      * SISTEMA              =    AUTOMOVEL.      (VERSAO PORTO)    //      */
        /*"      * PROGRAMA             =    AU0025S.                          //      */
        /*"      *                                                             //      */
        /*"      * OBJETIVO             =    GERACAO DE CALCULO DE VALOR       //      */
        /*"      *                           INDEXADO-PREFIXADO                //      */
        /*"      * ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    //      */
        /*"      * DATA                 =    ABRIL/1995.                       //      */
        /*"      *                                                               //      */
        /*"      *   ALTERACAO : KATIA - 29/01/96                                //      */
        /*"      *               INIBIR ACESSO A DESCONTO DE APP                 //      */
        /*"      *                                                               //      */
        /*"      *   ALTERACAO : HELEN MOURA JORDAO - 01/12/2000 - PROCURAR V202 //      */
        /*"      *               VM + 10% - MULTIPLICAR POR 1,20 SE VERSAO >=202 //      */
        /*"      *                                                               //      */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        /*"01  WS-FRQOBR           PIC  S9(010)V9(5) COMP-3 VALUE +0.*/
        public DoubleBasis WS_FRQOBR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01  WS-FRQFAC           PIC  S9(010)V9(5) COMP-3 VALUE +0.*/
        public DoubleBasis WS_FRQFAC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01  WS-PRREF            PIC  S9(013)V99   COMP-3 VALUE +0.*/
        public DoubleBasis WS_PRREF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-CALCPR           PIC  S9(013)V99   COMP-3 VALUE +0.*/
        public DoubleBasis WS_CALCPR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-CODUNIMO         PIC  S9(004)      COMP   VALUE +0.*/
        public IntBasis WS_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-CHRET            PIC  S9(004)      COMP   VALUE +0.*/
        public IntBasis WS_CHRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-ANOVEICL         PIC  S9(004)      COMP   VALUE +0.*/
        public IntBasis WS_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-CALC-DATA        PIC  S9(004)      COMP   VALUE +0.*/
        public IntBasis WS_CALC_DATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-CALC-PRAZO       PIC  S9(004)      COMP   VALUE +0.*/
        public IntBasis WS_CALC_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-CATTARIO         PIC  S9(004)      COMP   VALUE +0.*/
        public IntBasis WS_CATTARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VL-VRPRREF          PIC  S9(013)V99  COMP-3  VALUE +0.*/
        public DoubleBasis VL_VRPRREF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-VLCRUZAD-IS      PIC  S9(06)V9(9) COMP-3  VALUE +0.*/
        public DoubleBasis WS_VLCRUZAD_IS { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"01  WS-VLCRUZAD-PRM     PIC  S9(06)V9(9) COMP-3  VALUE +0.*/
        public DoubleBasis WS_VLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"01  WS-VLCRUZAD         PIC  S9(06)V9(9) COMP-3  VALUE +0.*/
        public DoubleBasis WS_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"01          WDATA-NUM.*/
        public AU0025S_WDATA_NUM WDATA_NUM { get; set; } = new AU0025S_WDATA_NUM();
        public class AU0025S_WDATA_NUM : VarBasis
        {
            /*"       05       WANO-NUM             PIC 9(004).*/
            public IntBasis WANO_NUM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"       05       WMES-NUM             PIC 9(002).*/
            public IntBasis WMES_NUM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"       05       WDIA-NUM             PIC 9(002).*/
            public IntBasis WDIA_NUM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01          WDATA-CHAR.*/
        }
        public AU0025S_WDATA_CHAR WDATA_CHAR { get; set; } = new AU0025S_WDATA_CHAR();
        public class AU0025S_WDATA_CHAR : VarBasis
        {
            /*"       05       WANO-CHAR            PIC 9(004).*/
            public IntBasis WANO_CHAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"       05       FILLER               PIC X(001).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"       05       WMES-CHAR            PIC 9(002).*/
            public IntBasis WMES_CHAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"       05       FILLER               PIC X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"       05       WDIA-CHAR            PIC 9(002).*/
            public IntBasis WDIA_CHAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WS-DATA1            PIC   9(008)            VALUE ZEROS.*/
        }
        public IntBasis WS_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01  FILLER    REDEFINES WS-DATA1.*/
        private _REDEF_AU0025S_FILLER_2 _filler_2 { get; set; }
        public _REDEF_AU0025S_FILLER_2 FILLER_2
        {
            get { _filler_2 = new _REDEF_AU0025S_FILLER_2(); _.Move(WS_DATA1, _filler_2); VarBasis.RedefinePassValue(WS_DATA1, _filler_2, WS_DATA1); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_DATA1); }; return _filler_2; }
            set { VarBasis.RedefinePassValue(value, _filler_2, WS_DATA1); }
        }  //Redefines
        public class _REDEF_AU0025S_FILLER_2 : VarBasis
        {
            /*"    05  WS-ANO1         PIC   9(004).*/
            public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  WS-MES1         PIC   9(002).*/
            public IntBasis WS_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WS-DIA1         PIC   9(002).*/
            public IntBasis WS_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  CSP-RETORNO.*/

            public _REDEF_AU0025S_FILLER_2()
            {
                WS_ANO1.ValueChanged += OnValueChanged;
                WS_MES1.ValueChanged += OnValueChanged;
                WS_DIA1.ValueChanged += OnValueChanged;
            }

        }
        public AU0025S_CSP_RETORNO CSP_RETORNO { get; set; } = new AU0025S_CSP_RETORNO();
        public class AU0025S_CSP_RETORNO : VarBasis
        {
            /*"    03  FILLER          PIC   X(008).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03  CSP-MSG.*/
            public AU0025S_CSP_MSG CSP_MSG { get; set; } = new AU0025S_CSP_MSG();
            public class AU0025S_CSP_MSG : VarBasis
            {
                /*"    05  CSP-PROCPAR     PIC   X(007).*/
                public StringBasis CSP_PROCPAR { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    05  FILLER          PIC   X(003).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05  CSP-LIT         PIC   X(050).*/
                public StringBasis CSP_LIT { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    05  FILLER          PIC   X(002).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  CSP-CODE        PIC  -9(003).*/
                public IntBasis CSP_CODE { get; set; } = new IntBasis(new PIC("-9", "3", "-9(003)."));
                /*"01      WS-RETORNO      PIC  S9(004)     COMP   VALUE +0.*/
            }
            public IntBasis WS_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01      WS-CFFROBR      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_CFFROBR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01      WS-CFFRFACC     PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_CFFRFACC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01      WS-CFPRREF      PIC  S9(003)V999 COMP-3 VALUE +0.*/
            public DoubleBasis WS_CFPRREF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V999"), 3);
            /*"01      WS-PCDSCFRF     PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_PCDSCFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01      WS-PCISCASC     PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_PCISCASC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01      WS-PCINCROU     PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_PCINCROU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01      WS-VRPRRCDM     PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VRPRRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01      WS-VRPRRCDP     PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VRPRRCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01      WS-VRPRRCDMO    PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VRPRRCDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01      WS-FRANQUIA     PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01      WS-FLPRREF      PIC   X(001)            VALUE ' '.*/
            public StringBasis WS_FLPRREF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"01      WS-TEMBONUS     PIC   X(001)            VALUE ' '.*/
            public StringBasis WS_TEMBONUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"01  WS-ITEM-A           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_A { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-B           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_B { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-C           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_C { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-D           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_D { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-E           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_E { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-F           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_F { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-R           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-T           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_T { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-V           PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_V { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X1          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X2          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X3          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X4          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X5          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X5 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X6          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X6 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X7          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X7 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X8          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X8 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X9          PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X9 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X10         PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X10 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X11         PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X11 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  WS-ITEM-X12         PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis WS_ITEM_X12 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  TAXAC-COD-EMPRESA   PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-CATTARIF      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-REGIAO        PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-ANOVEICL      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-CODAGRUPA     PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_CODAGRUPA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis TAXAC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  TAXAC-TAXA-IS       PIC  S9(005)V99  COMP-3 VALUE ZEROS.*/
            public DoubleBasis TAXAC_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
            /*"01  TAXAC-PRMREF-IX     PIC  S9(010)V9(5) COMP-3 VALUE ZEROS.*/
            public DoubleBasis TAXAC_PRMREF_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"01  TAXAC-CODUNIMO      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis TAXAC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  TAXAC-FABRICAN      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-CDVEICL       PIC  S9(009)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"01  TAXAC-CODPRODU      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TAXAC-VERSAO        PIC  S9(009)     COMP   VALUE ZEROS.*/
            public IntBasis TAXAC_VERSAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"01  BONAU-CODTAB        PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis BONAU_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  BONAU-CLASSEBN      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis BONAU_CLASSEBN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  BONAU-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis BONAU_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  BONAU-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis BONAU_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  BONAU-PCDESC        PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
            public DoubleBasis BONAU_PCDESC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  PRREF-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRREF_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRREF-TIPOVEIC      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRREF_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRREF-FABRICAN      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRREF_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRREF-CDVEICL       PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRREF_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRREF-CODUNIMO      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRREF_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRREF-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis PRREF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  PRREF-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis PRREF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  PRREF-VLPREMIO      PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis PRREF_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  PRREF-PREREFBT      PIC  S9(010)V9(5) COMP-3 VALUE +0.*/
            public DoubleBasis PRREF_PREREFBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"01  PRREF-PCIMPSEG      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis PRREF_PCIMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  PRREF-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis PRREF_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  CATTF-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CATTF_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CATTF-CODPRODU      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CATTF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CATTF-CATTARIF      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CATTF_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CATTF-REGIAO        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CATTF_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CATTF-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis CATTF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CATTF-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis CATTF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CATTF-VLPRTXCF      PIC  S9(012)V999 COMP-3 VALUE +0.*/
            public DoubleBasis CATTF_VLPRTXCF { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V999"), 3);
            /*"01  CATTF-PREBASBT      PIC  S9(010)V9(5) COMP-3 VALUE +0.*/
            public DoubleBasis CATTF_PREBASBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"01  CATTF-DTULTMAN      PIC   X(010)            VALUE SPACES.*/
            public StringBasis CATTF_DTULTMAN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CATTF-HOULTMAN      PIC   X(008)            VALUE SPACES.*/
            public StringBasis CATTF_HOULTMAN { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"01  CATTF-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis CATTF_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  CATTF-VLPRTXCF1     PIC  S9(012)V999 COMP-3 VALUE +0.*/
            public DoubleBasis CATTF_VLPRTXCF1 { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V999"), 3);
            /*"01  FRFAC-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis FRFAC_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  FRFAC-CLASSEFR      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis FRFAC_CLASSEFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  FRFAC-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis FRFAC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  FRFAC-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis FRFAC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  FRFAC-PCDESC        PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis FRFAC_PCDESC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  FRFAC-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis FRFAC_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  TXACE-CODTAB        PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TXACE_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TXACE-CATTARIF      PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TXACE_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TXACE-FRANQFAC      PIC   X(001)            VALUE SPACES.*/
            public StringBasis TXACE_FRANQFAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  TXACE-REGIAO        PIC  S9(004)     COMP   VALUE ZEROS.*/
            public IntBasis TXACE_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TXACE-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis TXACE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  TXACE-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis TXACE_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  TXACE-TAXACARR      PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
            public DoubleBasis TXACE_TAXACARR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  TXACE-TAXAOUTR      PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
            public DoubleBasis TXACE_TAXAOUTR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  TXACE-TAXAEQUIP     PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
            public DoubleBasis TXACE_TAXAEQUIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  DESCI-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis DESCI_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  DESCI-IDADE         PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis DESCI_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  DESCI-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis DESCI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  DESCI-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis DESCI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  DESCI-PCDESC        PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis DESCI_PCDESC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  DESCI-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis DESCI_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  PRAZO-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRAZO_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRAZO-PRAZOINI      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRAZO_PRAZOINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRAZO-PRAZOFIM      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis PRAZO_PRAZOFIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  PRAZO-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis PRAZO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  PRAZO-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis PRAZO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  PRAZO-PCPRMANO      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis PRAZO_PCPRMANO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  PRAZO-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis PRAZO_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  TXAPP-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis TXAPP_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TXAPP-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis TXAPP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  TXAPP-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis TXAPP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  TXAPP-TAXAAPPM      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis TXAPP_TAXAAPPM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  TXAPP-TAXAAPPI      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis TXAPP_TAXAAPPI { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  TXAPP-TAXAAPPA      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis TXAPP_TAXAAPPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  TXAPP-TAXAAPPD      PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis TXAPP_TAXAAPPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  TXAPP-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis TXAPP_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  DESCA-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis DESCA_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  DESCA-LOTINI        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis DESCA_LOTINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  DESCA-LOTFIM        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis DESCA_LOTFIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  DESCA-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis DESCA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  DESCA-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis DESCA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  DESCA-PCDESC        PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis DESCA_PCDESC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  DESCA-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis DESCA_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  NIVCS-CODTAB        PIC  S9(004)      COMP   VALUE +0.*/
            public IntBasis NIVCS_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  NIVCS-CODPRODU      PIC  S9(004)      COMP   VALUE +0.*/
            public IntBasis NIVCS_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  NIVCS-DTINIVIG      PIC   X(010)             VALUE SPACES.*/
            public StringBasis NIVCS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  NIVCS-DTTERVIG      PIC   X(010)             VALUE SPACES.*/
            public StringBasis NIVCS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  NIVCS-VLIMPSEG      PIC  S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis NIVCS_VLIMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  NIVCS-IMPSEGBT      PIC  S9(010)V9(5) COMP-3 VALUE +0.*/
            public DoubleBasis NIVCS_IMPSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"01  NIVCS-NIVEL         PIC  S9(004)      COMP   VALUE +0.*/
            public IntBasis NIVCS_NIVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  NIVCS-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis NIVCS_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  CFRCF-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CFRCF_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CFRCF-CODPRODU      PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CFRCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CFRCF-NIVEL         PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis CFRCF_NIVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  CFRCF-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis CFRCF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CFRCF-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis CFRCF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  CFRCF-COEFIC        PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis CFRCF_COEFIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  CFRCF-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis CFRCF_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  VLPRM-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis VLPRM_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  VLPRM-TIPOVEIC       PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis VLPRM_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  VLPRM-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis VLPRM_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  VLPRM-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
            public StringBasis VLPRM_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  VLPRM-VLPRM         PIC  S9(013)V99  COMP-3 VALUE +0.*/
            public DoubleBasis VLPRM_VLPRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  VLPRM-PCPRM         PIC  S9(003)V99  COMP-3 VALUE +0.*/
            public DoubleBasis VLPRM_PCPRM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"01  VLPRM-DTULTMAN      PIC   X(010)            VALUE SPACES.*/
            public StringBasis VLPRM_DTULTMAN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  VLPRM-HOULTMAN      PIC   X(008)            VALUE SPACES.*/
            public StringBasis VLPRM_HOULTMAN { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"01  VLPRM-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
            public StringBasis VLPRM_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  V1MOEDA-CODUNIMO          PIC  S9(004)    COMP.*/
            public IntBasis V1MOEDA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  V1MOEDA-DTINIVIG          PIC   X(010)         VALUE SPACES.*/
            public StringBasis V1MOEDA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  V1MOEDA-VLCRUZAD          PIC S9(10)V9(5) COMP-3 VALUE +0.*/
            public DoubleBasis V1MOEDA_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
            /*"01  CSP-REGISTRO.*/
        }
        public AU0025S_CSP_REGISTRO CSP_REGISTRO { get; set; } = new AU0025S_CSP_REGISTRO();
        public class AU0025S_CSP_REGISTRO : VarBasis
        {
            /*"    05  CSP-W01P0300    PIC   9(003)  COMP-3.*/
            public IntBasis CSP_W01P0300 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  CSP-DTINIAUTO   PIC   9(008).*/
            public IntBasis CSP_DTINIAUTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-MOEDA-IMP   PIC  S9(004)  COMP.*/
            public IntBasis CSP_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-MOEDA-PRM   PIC  S9(004)  COMP.*/
            public IntBasis CSP_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-VLSEGIMP    PIC  S9(006)V9(9) COMP-3.*/
            public DoubleBasis CSP_VLSEGIMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"    05  CSP-VLTARPRM    PIC  S9(006)V9(9) COMP-3.*/
            public DoubleBasis CSP_VLTARPRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"    05  CSP-CLAFRFAC    PIC   9(001).*/
            public IntBasis CSP_CLAFRFAC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  CSP-TERCEIXO    PIC   X(001).*/
            public StringBasis CSP_TERCEIXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-CDVEICL     PIC  S9(009)     COMP.*/
            public IntBasis CSP_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05  CSP-ANOVEICL    PIC  S9(004)     COMP.*/
            public IntBasis CSP_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-CATTARIO    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CATTARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-REGIAO      PIC  S9(004)     COMP.*/
            public IntBasis CSP_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-TIPOCOB     PIC  S9(004)     COMP.*/
            public IntBasis CSP_TIPOCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-VRISCASC    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISCASC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-CLABONAT    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CLABONAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-PCDESCAT    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDESCAT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-CATTARIR    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CATTARIR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-DTINIRCDM   PIC   9(008).*/
            public IntBasis CSP_DTINIRCDM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISRCDM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DTINIRCDP   PIC   9(008).*/
            public IntBasis CSP_DTINIRCDP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISRCDP    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISRCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DTINIRCDMO  PIC   9(008).*/
            public IntBasis CSP_DTINIRCDMO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISRCDMO   PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISRCDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DTINIAPPM   PIC   9(008).*/
            public IntBasis CSP_DTINIAPPM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISAPPM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISAPPM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DTINIAPPI   PIC   9(008).*/
            public IntBasis CSP_DTINIAPPI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISAPPI    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISAPPI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DTINIAPPA   PIC   9(008).*/
            public IntBasis CSP_DTINIAPPA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISAPPA    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISAPPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DTINIAPPD   PIC   9(008).*/
            public IntBasis CSP_DTINIAPPD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-VRISAPPD    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISAPPD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-NUMPASSG    PIC  S9(004)     COMP.*/
            public IntBasis CSP_NUMPASSG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-EXTPER      PIC   X(001).*/
            public StringBasis CSP_EXTPER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-PERIODO     PIC  S9(004)     COMP.*/

            public SelectorBasis CSP_PERIODO { get; set; } = new SelectorBasis("004")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  CSP-PER-30  VALUE   +0  THRU  +30. */
							new SelectorItemBasis("CSP_PER_30", "+0 THRU +30"),
							/*" 88  CSP-PER-60  VALUE  +31  THRU  +60. */
							new SelectorItemBasis("CSP_PER_60", "+31 THRU +60"),
							/*" 88  CSP-PER-90  VALUE  +61  THRU  +90. */
							new SelectorItemBasis("CSP_PER_90", "+61 THRU +90"),
							/*" 88  CSP-PER-120 VALUE  +91  THRU +120. */
							new SelectorItemBasis("CSP_PER_120", "+91 THRU +120"),
							/*" 88  CSP-PER-150 VALUE +121  THRU +150. */
							new SelectorItemBasis("CSP_PER_150", "+121 THRU +150"),
							/*" 88  CSP-PER-180 VALUE +151  THRU +180. */
							new SelectorItemBasis("CSP_PER_180", "+151 THRU +180"),
							/*" 88  CSP-PER-210 VALUE +181  THRU +210. */
							new SelectorItemBasis("CSP_PER_210", "+181 THRU +210"),
							/*" 88  CSP-PER-240 VALUE +211  THRU +240. */
							new SelectorItemBasis("CSP_PER_240", "+211 THRU +240"),
							/*" 88  CSP-PER-270 VALUE +241  THRU +270. */
							new SelectorItemBasis("CSP_PER_270", "+241 THRU +270"),
							/*" 88  CSP-PER-300 VALUE +271  THRU +300. */
							new SelectorItemBasis("CSP_PER_300", "+271 THRU +300"),
							/*" 88  CSP-PER-330 VALUE +301  THRU +330. */
							new SelectorItemBasis("CSP_PER_330", "+301 THRU +330"),
							/*" 88  CSP-PER-360 VALUE +331  THRU +360. */
							new SelectorItemBasis("CSP_PER_360", "+331 THRU +360"),
							/*" 88  CSP-PER-364 VALUE +361  THRU +364. */
							new SelectorItemBasis("CSP_PER_364", "+361 THRU +364"),
							/*" 88  CSP-PER-366 VALUE +365  THRU +999. */
							new SelectorItemBasis("CSP_PER_366", "+365 THRU +999")
                }
            };

            /*"    05  CSP-PCFRADIC    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCFRADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-VRPRREF     PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPRREF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-CFFROBR     PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_CFFROBR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-CFFRFACC    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_CFFRFACC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TIPOVEIC     PIC  S9(004)     COMP.*/
            public IntBasis CSP_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-FABRICAN    PIC  S9(004)     COMP.*/
            public IntBasis CSP_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-CFPRREF     PIC  S9(002)V999 COMP-3.*/
            public DoubleBasis CSP_CFPRREF { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V999"), 3);
            /*"    05  CSP-PCDSCFRF    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDSCFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PRAZOSEG    PIC  S9(004)     COMP.*/
            public IntBasis CSP_PRAZOSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-PCISCASC    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCISCASC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PCINCROU    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCINCROU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-VRPLCASC    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLCASC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPACASC    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPACASC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLACAS    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLACAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLRCDM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPARCDM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPARCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLARDM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLARDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLRCDP    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLRCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPARCDP    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPARCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLARDP    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLARDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLRCDMO   PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLRCDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPARCDMO   PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPARCDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLARDMO   PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLARDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAPPM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAPPM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAAPM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAAPM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAPPI    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAPPI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAAPI    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAAPI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAPPA    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAPPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAAPA    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAAPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAPPD    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAPPD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAAPD    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAAPD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPRRCDM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPRRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPRRCDP    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPRRCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPRRCDMO   PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPRRCDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRISFROB    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISFROB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRISFRCA    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISFRCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRISFRAC    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISFRAC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRISFRAD    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISFRAD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-CFFRFACA    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_CFFRFACA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-CLABONDM    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CLABONDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-CLABONDP    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CLABONDP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-CLABONDMO   PIC  S9(004)     COMP.*/
            public IntBasis CSP_CLABONDMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-VRISACCA    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISACCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DESCFROT    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_DESCFROT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-CODACESS    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CODACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-VRPLACES    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRADACES    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRADACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-ACEANU      PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_ACEANU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-DESCIDAD    PIC   X(001).*/
            public StringBasis CSP_DESCIDAD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-TVRPRREF    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_TVRPRREF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-TCFFROBR    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TCFFROBR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TCFFRFCC    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TCFFRFCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TCFFRFCA    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TCFFRFCA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TCFAPLPR    PIC  S9(002)V999 COMP-3.*/
            public DoubleBasis CSP_TCFAPLPR { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V999"), 3);
            /*"    05  CSP-TPCDSFRF    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCDSFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCDSIDA    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCDSIDA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCDSBAU    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCDSBAU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TTXAPLIS    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXAPLIS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCINROU    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCINROU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCPZSEG    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCPZSEG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TTXISACE    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXISACE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPRBRCDM    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_TPRBRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-TCFPBRDM    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TCFPBRDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPRBRCDP    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_TPRBRCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-TCFPBRDP    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TCFPBRDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPRBRCDMO   PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_TPRBRCDMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-TCFPBRDMO   PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TCFPBRDMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCBONDM    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCBONDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCBONDP    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCBONDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCBONDMO   PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCBONDMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TTXAPPM     PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXAPPM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TTXAPPI     PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXAPPI { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TTXAPPA     PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXAPPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TTXAPPD     PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXAPPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TPCDSAPP    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TPCDSAPP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TIPCALC     PIC   X(001).*/
            public StringBasis CSP_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-CORRECAO    PIC   X(001).*/
            public StringBasis CSP_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-ACEITE      PIC   X(001).*/
            public StringBasis CSP_ACEITE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-DTINIVIG    PIC   9(008).*/
            public IntBasis CSP_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-IDEPZSEG    PIC   X(001).*/
            public StringBasis CSP_IDEPZSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-PCDESAUT    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDESAUT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PCDESRCF    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDESRCF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PCDESAPP    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDESAPP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PCREDTAX    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCREDTAX { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-INDANO      PIC  9(004).*/
            public IntBasis CSP_INDANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  FILLER          PIC  X(018).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
            /*"    05  CSP-W01A0077    PIC  X(077).*/
            public StringBasis CSP_W01A0077 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"    05  CSP-CODPRODU    PIC  9(004).*/
            public IntBasis CSP_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  CSP-DESPEXTR    PIC  X(001).*/
            public StringBasis CSP_DESPEXTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-VERSAON     PIC  9(005).*/
            public IntBasis CSP_VERSAON { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  CSP-ADIC-VLR-MERC PIC  X(001).*/
            public StringBasis CSP_ADIC_VLR_MERC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        }


        public AU0025S_NIVCSBT NIVCSBT { get; set; } = new AU0025S_NIVCSBT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(AU0025S_CSP_REGISTRO AU0025S_CSP_REGISTRO_P) //PROCEDURE DIVISION USING 
        /*CSP_REGISTRO*/
        {
            try
            {
                this.CSP_REGISTRO = AU0025S_CSP_REGISTRO_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CSP_REGISTRO };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -753- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_000_005_PRINCIPAL */

            M_000_005_PRINCIPAL();

        }

        [StopWatch]
        /*" M-000-005-PRINCIPAL */
        private void M_000_005_PRINCIPAL(bool isPerform = false)
        {
            /*" -757- MOVE 'AU0025S 000-000 - PRINCIPAL' TO CSP-RETORNO. */
            _.Move("AU0025S 000-000 - PRINCIPAL", CSP_RETORNO);

            /*" -758- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -761- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -764- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -802- MOVE ZEROS TO CSP-CODE CSP-W01P0300 WS-FRQOBR WS-FRQFAC WS-PRREF WS-CALCPR WS-CHRET WS-ANOVEICL WS-CALC-DATA WS-CALC-PRAZO WS-VLCRUZAD-IS WS-VLCRUZAD-PRM WS-VLCRUZAD VL-VRPRREF WS-RETORNO WS-CFFROBR WS-CFPRREF WS-PCDSCFRF WS-PCISCASC WS-PCINCROU WS-ITEM-R WS-ITEM-T WS-ITEM-X WS-ITEM-V WS-ITEM-X1 WS-ITEM-X2 WS-ITEM-X3 WS-ITEM-X4 WS-ITEM-X5 WS-ITEM-X6 WS-ITEM-X7 WS-ITEM-X8 WS-ITEM-X9 WS-ITEM-X10 WS-ITEM-X11 WS-ITEM-X12. */
            _.Move(0, CSP_RETORNO.CSP_MSG.CSP_CODE, CSP_REGISTRO.CSP_W01P0300, WS_FRQOBR, WS_FRQFAC, WS_PRREF, WS_CALCPR, WS_CHRET, WS_ANOVEICL, WS_CALC_DATA, WS_CALC_PRAZO, WS_VLCRUZAD_IS, WS_VLCRUZAD_PRM, WS_VLCRUZAD, VL_VRPRREF, CSP_RETORNO.WS_RETORNO, CSP_RETORNO.WS_CFFROBR, CSP_RETORNO.WS_CFPRREF, CSP_RETORNO.WS_PCDSCFRF, CSP_RETORNO.WS_PCISCASC, CSP_RETORNO.WS_PCINCROU, CSP_RETORNO.WS_ITEM_R, CSP_RETORNO.WS_ITEM_T, CSP_RETORNO.WS_ITEM_X, CSP_RETORNO.WS_ITEM_V, CSP_RETORNO.WS_ITEM_X1, CSP_RETORNO.WS_ITEM_X2, CSP_RETORNO.WS_ITEM_X3, CSP_RETORNO.WS_ITEM_X4, CSP_RETORNO.WS_ITEM_X5, CSP_RETORNO.WS_ITEM_X6, CSP_RETORNO.WS_ITEM_X7, CSP_RETORNO.WS_ITEM_X8, CSP_RETORNO.WS_ITEM_X9, CSP_RETORNO.WS_ITEM_X10, CSP_RETORNO.WS_ITEM_X11, CSP_RETORNO.WS_ITEM_X12);

            /*" -803- MOVE SPACES TO WS-FLPRREF. */
            _.Move("", CSP_RETORNO.WS_FLPRREF);

            /*" -804- MOVE '9999-12-31' TO WDATA-CHAR. */
            _.Move("9999-12-31", WDATA_CHAR);

            /*" -806- PERFORM 005-000-TRATA-NUMERICO. */

            M_005_000_TRATA_NUMERICO_SECTION();

            /*" -808- MOVE '005-001' TO CSP-PROCPAR. */
            _.Move("005-001", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -809- MOVE CSP-DTINIAUTO TO WDATA-NUM. */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM);

            /*" -811- MOVE CSP-DTINIAUTO TO CSP-DTINIVIG. */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, CSP_REGISTRO.CSP_DTINIVIG);

            /*" -813- MOVE '005-002 - ACESSA TAXA PRAZO-CURTO/LONGO' TO CSP-MSG. */
            _.Move("005-002 - ACESSA TAXA PRAZO-CURTO/LONGO", CSP_RETORNO.CSP_MSG);

            /*" -814- MOVE 05 TO PRAZO-CODTAB */
            _.Move(05, CSP_RETORNO.PRAZO_CODTAB);

            /*" -815- MOVE CSP-PRAZOSEG TO PRAZO-PRAZOINI */
            _.Move(CSP_REGISTRO.CSP_PRAZOSEG, CSP_RETORNO.PRAZO_PRAZOINI);

            /*" -817- MOVE CSP-DTINIAUTO TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM, WS_DATA1);

            /*" -818- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -819- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -820- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -821- MOVE WDATA-CHAR TO PRAZO-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.PRAZO_DTINIVIG);

            /*" -822- MOVE ZEROS TO WS-RETORNO */
            _.Move(0, CSP_RETORNO.WS_RETORNO);

            /*" -823- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -824- PERFORM 210-000-PESQ-V1PRAZOSEG */

                M_210_000_PESQ_V1PRAZOSEG_SECTION();

                /*" -825- ELSE */
            }
            else
            {


                /*" -827- MOVE ZEROS TO CSP-TPCPZSEG. */
                _.Move(0, CSP_REGISTRO.CSP_TPCPZSEG);
            }


            /*" -828- IF CSP-PRAZOSEG GREATER 365 */

            if (CSP_REGISTRO.CSP_PRAZOSEG > 365)
            {

                /*" -829- IF CSP-PRAZOSEG EQUAL 366 */

                if (CSP_REGISTRO.CSP_PRAZOSEG == 366)
                {

                    /*" -830- MOVE 365 TO CSP-PRAZOSEG */
                    _.Move(365, CSP_REGISTRO.CSP_PRAZOSEG);

                    /*" -831- ELSE */
                }
                else
                {


                    /*" -833- MOVE '005-003 - PRAZO NAO DEVE SER SUPERIOR A 1 ANO' TO CSP-MSG */
                    _.Move("005-003 - PRAZO NAO DEVE SER SUPERIOR A 1 ANO", CSP_RETORNO.CSP_MSG);

                    /*" -834- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -836- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


            /*" -837- MOVE CSP-VLSEGIMP TO WS-VLCRUZAD-IS. */
            _.Move(CSP_REGISTRO.CSP_VLSEGIMP, WS_VLCRUZAD_IS);

            /*" -838- MOVE CSP-VLTARPRM TO WS-VLCRUZAD-PRM. */
            _.Move(CSP_REGISTRO.CSP_VLTARPRM, WS_VLCRUZAD_PRM);

            /*" -839- MOVE CSP-MOEDA-PRM TO WS-CODUNIMO. */
            _.Move(CSP_REGISTRO.CSP_MOEDA_PRM, WS_CODUNIMO);

            /*" -840- PERFORM 010-000-SELECIONA-TAXAS. */

            M_010_000_SELECIONA_TAXAS_SECTION();

            /*" -842- PERFORM 020-000-SELECIONA-BONUS. */

            M_020_000_SELECIONA_BONUS_SECTION();

            /*" -843- IF CSP-VRISCASC GREATER ZEROS */

            if (CSP_REGISTRO.CSP_VRISCASC > 00)
            {

                /*" -844- PERFORM 030-000-TRATA-FROBR */

                M_030_000_TRATA_FROBR_SECTION();

                /*" -845- PERFORM 040-000-TRATA-FRFACC */

                M_040_000_TRATA_FRFACC_SECTION();

                /*" -847- PERFORM 050-000-TRATA-PCFRADIC */

                M_050_000_TRATA_PCFRADIC_SECTION();

                /*" -848- PERFORM 070-000-CALCULA-PREMIO-CASCO */

                M_070_000_CALCULA_PREMIO_CASCO_SECTION();

                /*" -849- PERFORM 080-000-CALC-PRO-RATA-PZCURTO */

                M_080_000_CALC_PRO_RATA_PZCURTO_SECTION();

                /*" -850- PERFORM 090-000-APLICA-DESC-ANTIFURTO */

                M_090_000_APLICA_DESC_ANTIFURTO_SECTION();

                /*" -852- PERFORM 100-000-TRATA-EXTENSAO-PER. */

                M_100_000_TRATA_EXTENSAO_PER_SECTION();
            }


            /*" -853- PERFORM 230-000-TRATA-ITEM-R */

            M_230_000_TRATA_ITEM_R_SECTION();

            /*" -854- PERFORM 250-000-TRATA-BONUS-RCFDM */

            M_250_000_TRATA_BONUS_RCFDM_SECTION();

            /*" -855- PERFORM 260-000-APLIC-DESC-FROTA-RCDM */

            M_260_000_APLIC_DESC_FROTA_RCDM_SECTION();

            /*" -856- PERFORM 270-000-CALC-PRO-RATA-PZCURTO */

            M_270_000_CALC_PRO_RATA_PZCURTO_SECTION();

            /*" -857- PERFORM 290-000-TRATA-ITEM-T */

            M_290_000_TRATA_ITEM_T_SECTION();

            /*" -858- PERFORM 310-000-TRATA-BONUS-RCFDP */

            M_310_000_TRATA_BONUS_RCFDP_SECTION();

            /*" -859- PERFORM 320-000-APLIC-DESC-FROTA-RCDP */

            M_320_000_APLIC_DESC_FROTA_RCDP_SECTION();

            /*" -860- PERFORM 330-000-CALC-PRO-RATA-PZCURTO */

            M_330_000_CALC_PRO_RATA_PZCURTO_SECTION();

            /*" -861- PERFORM 332-000-TRATA-ITEM-V */

            M_332_000_TRATA_ITEM_V_SECTION();

            /*" -862- PERFORM 334-000-TRATA-BONUS-RCFDMO */

            M_334_000_TRATA_BONUS_RCFDMO_SECTION();

            /*" -863- PERFORM 336-000-APLIC-DESC-FROTA-RCDMO */

            M_336_000_APLIC_DESC_FROTA_RCDMO_SECTION();

            /*" -864- PERFORM 338-000-CALC-PRO-RATA-PZCURTO */

            M_338_000_CALC_PRO_RATA_PZCURTO_SECTION();

            /*" -865- PERFORM 350-000-TRATA-ITEM-X */

            M_350_000_TRATA_ITEM_X_SECTION();

            /*" -866- PERFORM 410-000-TRATA-DESCONTOS */

            M_410_000_TRATA_DESCONTOS_SECTION();

            /*" -868- PERFORM 430-000-SOMA-PRM-ADICIONAL. */

            M_430_000_SOMA_PRM_ADICIONAL_SECTION();

            /*" -868- PERFORM 900-000-FINALIZAR. */

            M_900_000_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-005-000-TRATA-NUMERICO-SECTION */
        private void M_005_000_TRATA_NUMERICO_SECTION()
        {
            /*" -878- MOVE '005-000' TO CSP-PROCPAR. */
            _.Move("005-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -879- MOVE 'TRATA-NUMERICO' TO CSP-LIT. */
            _.Move("TRATA-NUMERICO", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -880- MOVE 'DTINIAUTO   ' TO CSP-LIT. */
            _.Move("DTINIAUTO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -881- IF CSP-DTINIAUTO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIAUTO.IsNumeric())
            {

                /*" -882- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -884- MOVE 'DTINIAUTO   ' TO CSP-LIT. */
                _.Move("DTINIAUTO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -885- MOVE 'CODUNIMO    ' TO CSP-LIT. */
            _.Move("CODUNIMO    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -886- IF CSP-MOEDA-IMP EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_MOEDA_IMP == 00)
            {

                /*" -887- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -889- MOVE 'MOEDA IMP   ' TO CSP-LIT. */
                _.Move("MOEDA IMP   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -890- IF CSP-MOEDA-PRM EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_MOEDA_PRM == 00)
            {

                /*" -891- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -898- MOVE 'MOEDA PRM   ' TO CSP-LIT. */
                _.Move("MOEDA PRM   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -900- IF (CSP-VLTARPRM NOT NUMERIC) OR (CSP-VLTARPRM EQUAL ZEROS) */

            if ((!CSP_REGISTRO.CSP_VLTARPRM.IsNumeric()) || (CSP_REGISTRO.CSP_VLTARPRM == 00))
            {

                /*" -901- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -903- MOVE 'MOEDA PRM VL' TO CSP-LIT. */
                _.Move("MOEDA PRM VL", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -904- MOVE 'VRISCASC    ' TO CSP-LIT. */
            _.Move("VRISCASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -905- IF CSP-VRISCASC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISCASC.IsNumeric())
            {

                /*" -906- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -908- MOVE 'VRISCASC    ' TO CSP-LIT. */
                _.Move("VRISCASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -909- MOVE 'PCDESCAT    ' TO CSP-LIT. */
            _.Move("PCDESCAT    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -910- IF CSP-PCDESCAT NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCDESCAT.IsNumeric())
            {

                /*" -911- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -913- MOVE 'PCDESCAT    ' TO CSP-LIT. */
                _.Move("PCDESCAT    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -914- MOVE 'DTINIRCDM   ' TO CSP-LIT. */
            _.Move("DTINIRCDM   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -915- IF CSP-DTINIRCDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIRCDM.IsNumeric())
            {

                /*" -916- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -918- MOVE 'DTINIRCDM   ' TO CSP-LIT. */
                _.Move("DTINIRCDM   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -919- MOVE 'VRISRCDM    ' TO CSP-LIT. */
            _.Move("VRISRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -920- IF CSP-VRISRCDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISRCDM.IsNumeric())
            {

                /*" -921- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -923- MOVE 'VRISRCDM    ' TO CSP-LIT. */
                _.Move("VRISRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -924- MOVE 'DTINIRCDP   ' TO CSP-LIT. */
            _.Move("DTINIRCDP   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -925- IF CSP-DTINIRCDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIRCDP.IsNumeric())
            {

                /*" -926- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -928- MOVE 'DTINIRCDP   ' TO CSP-LIT. */
                _.Move("DTINIRCDP   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -929- MOVE 'VRISRCDP    ' TO CSP-LIT. */
            _.Move("VRISRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -930- IF CSP-VRISRCDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISRCDP.IsNumeric())
            {

                /*" -931- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -933- MOVE 'VRISRCDP    ' TO CSP-LIT. */
                _.Move("VRISRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -934- MOVE 'DTINIRCDMO  ' TO CSP-LIT. */
            _.Move("DTINIRCDMO  ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -935- IF CSP-DTINIRCDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIRCDMO.IsNumeric())
            {

                /*" -936- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -938- MOVE 'DTINIRCDMO  ' TO CSP-LIT. */
                _.Move("DTINIRCDMO  ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -939- MOVE 'VRISRCDMO   ' TO CSP-LIT. */
            _.Move("VRISRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -940- IF CSP-VRISRCDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISRCDMO.IsNumeric())
            {

                /*" -941- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -943- MOVE 'VRISRCDMO   ' TO CSP-LIT. */
                _.Move("VRISRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -944- MOVE 'DTINIAPPM   ' TO CSP-LIT. */
            _.Move("DTINIAPPM   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -945- IF CSP-DTINIAPPM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIAPPM.IsNumeric())
            {

                /*" -946- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -948- MOVE 'DTINIAPPM   ' TO CSP-LIT. */
                _.Move("DTINIAPPM   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -949- MOVE 'VRISAPPM    ' TO CSP-LIT. */
            _.Move("VRISAPPM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -950- IF CSP-VRISAPPM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISAPPM.IsNumeric())
            {

                /*" -951- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -953- MOVE 'VRISAPPM    ' TO CSP-LIT. */
                _.Move("VRISAPPM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -954- MOVE 'DTINIAPPI   ' TO CSP-LIT. */
            _.Move("DTINIAPPI   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -955- IF CSP-DTINIAPPI NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIAPPI.IsNumeric())
            {

                /*" -956- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -958- MOVE 'DTINIAPPI   ' TO CSP-LIT. */
                _.Move("DTINIAPPI   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -959- MOVE 'VRISAPPI    ' TO CSP-LIT. */
            _.Move("VRISAPPI    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -960- IF CSP-VRISAPPI NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISAPPI.IsNumeric())
            {

                /*" -961- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -963- MOVE 'VRISAPPI    ' TO CSP-LIT. */
                _.Move("VRISAPPI    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -964- MOVE 'DTINIAPPA   ' TO CSP-LIT. */
            _.Move("DTINIAPPA   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -965- IF CSP-DTINIAPPA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIAPPA.IsNumeric())
            {

                /*" -966- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -968- MOVE 'DTINIAPPA   ' TO CSP-LIT. */
                _.Move("DTINIAPPA   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -969- MOVE 'VRISAPPA    ' TO CSP-LIT. */
            _.Move("VRISAPPA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -970- IF CSP-VRISAPPA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISAPPA.IsNumeric())
            {

                /*" -971- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -973- MOVE 'VRISAPPA    ' TO CSP-LIT. */
                _.Move("VRISAPPA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -974- MOVE 'DTINIAPPD   ' TO CSP-LIT. */
            _.Move("DTINIAPPD   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -975- IF CSP-DTINIAPPD NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIAPPD.IsNumeric())
            {

                /*" -976- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -978- MOVE 'DTINIAPPD   ' TO CSP-LIT. */
                _.Move("DTINIAPPD   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -979- MOVE 'VRISAPPD    ' TO CSP-LIT. */
            _.Move("VRISAPPD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -980- IF CSP-VRISAPPD NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISAPPD.IsNumeric())
            {

                /*" -981- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -983- MOVE 'VRISAPPD    ' TO CSP-LIT. */
                _.Move("VRISAPPD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -984- MOVE 'PCFRADIC    ' TO CSP-LIT. */
            _.Move("PCFRADIC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -985- IF CSP-PCFRADIC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCFRADIC.IsNumeric())
            {

                /*" -986- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -988- MOVE 'PCFRADIC    ' TO CSP-LIT. */
                _.Move("PCFRADIC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -989- MOVE 'VRPRREF     ' TO CSP-LIT. */
            _.Move("VRPRREF     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -990- IF CSP-VRPRREF NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPRREF.IsNumeric())
            {

                /*" -991- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -993- MOVE 'VRPRREF     ' TO CSP-LIT. */
                _.Move("VRPRREF     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -994- MOVE 'CFFROBR     ' TO CSP-LIT. */
            _.Move("CFFROBR     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -995- IF CSP-CFFROBR NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_CFFROBR.IsNumeric())
            {

                /*" -996- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -998- MOVE 'CFFROBR     ' TO CSP-LIT. */
                _.Move("CFFROBR     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -999- MOVE 'CFFRFACC    ' TO CSP-LIT. */
            _.Move("CFFRFACC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1000- IF CSP-CFFRFACC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_CFFRFACC.IsNumeric())
            {

                /*" -1001- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1003- MOVE 'CFFRFACC    ' TO CSP-LIT. */
                _.Move("CFFRFACC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1004- MOVE 'CFPRREF     ' TO CSP-LIT. */
            _.Move("CFPRREF     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1005- IF CSP-CFPRREF NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_CFPRREF.IsNumeric())
            {

                /*" -1006- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1008- MOVE 'CFPRREF     ' TO CSP-LIT. */
                _.Move("CFPRREF     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1009- MOVE 'PCDSCFRF    ' TO CSP-LIT. */
            _.Move("PCDSCFRF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1010- IF CSP-PCDSCFRF NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCDSCFRF.IsNumeric())
            {

                /*" -1011- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1013- MOVE 'PCDSCFRF    ' TO CSP-LIT. */
                _.Move("PCDSCFRF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1014- MOVE 'PCISCASC    ' TO CSP-LIT. */
            _.Move("PCISCASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1015- IF CSP-PCISCASC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCISCASC.IsNumeric())
            {

                /*" -1016- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1018- MOVE 'PCISCASC    ' TO CSP-LIT. */
                _.Move("PCISCASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1019- MOVE 'PCINCROU    ' TO CSP-LIT. */
            _.Move("PCINCROU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1020- IF CSP-PCINCROU NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCINCROU.IsNumeric())
            {

                /*" -1021- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1023- MOVE 'PCINCROU    ' TO CSP-LIT. */
                _.Move("PCINCROU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1024- MOVE 'VRPLCASC    ' TO CSP-LIT. */
            _.Move("VRPLCASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1025- IF CSP-VRPLCASC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLCASC.IsNumeric())
            {

                /*" -1026- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1028- MOVE 'VRPLCASC    ' TO CSP-LIT. */
                _.Move("VRPLCASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1029- MOVE 'VRPACASC    ' TO CSP-LIT. */
            _.Move("VRPACASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1030- IF CSP-VRPACASC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPACASC.IsNumeric())
            {

                /*" -1031- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1033- MOVE 'VRPACASC    ' TO CSP-LIT. */
                _.Move("VRPACASC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1034- MOVE 'VRPLACAS    ' TO CSP-LIT. */
            _.Move("VRPLACAS    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1035- IF CSP-VRPLACAS NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLACAS.IsNumeric())
            {

                /*" -1036- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1038- MOVE 'VRPLACAS    ' TO CSP-LIT. */
                _.Move("VRPLACAS    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1039- MOVE 'VRPLRCDM    ' TO CSP-LIT. */
            _.Move("VRPLRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1040- IF CSP-VRPLRCDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLRCDM.IsNumeric())
            {

                /*" -1041- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1043- MOVE 'VRPLRCDM    ' TO CSP-LIT. */
                _.Move("VRPLRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1044- MOVE 'VRPARCDM    ' TO CSP-LIT. */
            _.Move("VRPARCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1045- IF CSP-VRPARCDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPARCDM.IsNumeric())
            {

                /*" -1046- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1048- MOVE 'VRPARCDM    ' TO CSP-LIT. */
                _.Move("VRPARCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1049- MOVE 'VRPLARDM    ' TO CSP-LIT. */
            _.Move("VRPLARDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1050- IF CSP-VRPLARDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLARDM.IsNumeric())
            {

                /*" -1051- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1053- MOVE 'VRPLARDM    ' TO CSP-LIT. */
                _.Move("VRPLARDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1054- MOVE 'VRPLRCDP    ' TO CSP-LIT. */
            _.Move("VRPLRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1055- IF CSP-VRPLRCDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLRCDP.IsNumeric())
            {

                /*" -1056- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1058- MOVE 'VRPLRCDP    ' TO CSP-LIT. */
                _.Move("VRPLRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1059- MOVE 'VRPARCDP    ' TO CSP-LIT. */
            _.Move("VRPARCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1060- IF CSP-VRPARCDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPARCDP.IsNumeric())
            {

                /*" -1061- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1063- MOVE 'VRPARCDP    ' TO CSP-LIT. */
                _.Move("VRPARCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1064- MOVE 'VRPLARDP    ' TO CSP-LIT. */
            _.Move("VRPLARDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1065- IF CSP-VRPLARDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLARDP.IsNumeric())
            {

                /*" -1066- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1068- MOVE 'VRPLARDP    ' TO CSP-LIT. */
                _.Move("VRPLARDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1069- MOVE 'VRPLRCDMO   ' TO CSP-LIT. */
            _.Move("VRPLRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1070- IF CSP-VRPLRCDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLRCDMO.IsNumeric())
            {

                /*" -1071- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1073- MOVE 'VRPLRCDMO   ' TO CSP-LIT. */
                _.Move("VRPLRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1074- MOVE 'VRPARCDMO   ' TO CSP-LIT. */
            _.Move("VRPARCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1075- IF CSP-VRPARCDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPARCDMO.IsNumeric())
            {

                /*" -1076- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1078- MOVE 'VRPARCDMO   ' TO CSP-LIT. */
                _.Move("VRPARCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1079- MOVE 'VRPLARDMO   ' TO CSP-LIT. */
            _.Move("VRPLARDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1080- IF CSP-VRPLARDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLARDMO.IsNumeric())
            {

                /*" -1081- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1083- MOVE 'VRPLARDMO   ' TO CSP-LIT. */
                _.Move("VRPLARDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1084- MOVE 'VRPLAPPM    ' TO CSP-LIT. */
            _.Move("VRPLAPPM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1085- IF CSP-VRPLAPPM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAPPM.IsNumeric())
            {

                /*" -1086- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1088- MOVE 'VRPLAPPM    ' TO CSP-LIT. */
                _.Move("VRPLAPPM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1089- MOVE 'VRPLAAPM    ' TO CSP-LIT. */
            _.Move("VRPLAAPM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1090- IF CSP-VRPLAAPM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAAPM.IsNumeric())
            {

                /*" -1091- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1093- MOVE 'VRPLAAPM    ' TO CSP-LIT. */
                _.Move("VRPLAAPM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1094- MOVE 'VRPLAPPI    ' TO CSP-LIT. */
            _.Move("VRPLAPPI    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1095- IF CSP-VRPLAPPI NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAPPI.IsNumeric())
            {

                /*" -1096- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1098- MOVE 'VRPLAPPI    ' TO CSP-LIT. */
                _.Move("VRPLAPPI    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1099- MOVE 'VRPLAAPI    ' TO CSP-LIT. */
            _.Move("VRPLAAPI    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1100- IF CSP-VRPLAAPI NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAAPI.IsNumeric())
            {

                /*" -1101- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1103- MOVE 'VRPLAAPI    ' TO CSP-LIT. */
                _.Move("VRPLAAPI    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1104- MOVE 'VRPLAPPA    ' TO CSP-LIT. */
            _.Move("VRPLAPPA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1105- IF CSP-VRPLAPPA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAPPA.IsNumeric())
            {

                /*" -1106- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1108- MOVE 'VRPLAPPA    ' TO CSP-LIT. */
                _.Move("VRPLAPPA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1109- MOVE 'VRPLAAPA    ' TO CSP-LIT. */
            _.Move("VRPLAAPA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1110- IF CSP-VRPLAAPA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAAPA.IsNumeric())
            {

                /*" -1111- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1113- MOVE 'VRPLAAPA    ' TO CSP-LIT. */
                _.Move("VRPLAAPA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1114- MOVE 'VRPLAPPD    ' TO CSP-LIT. */
            _.Move("VRPLAPPD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1115- IF CSP-VRPLAPPD NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAPPD.IsNumeric())
            {

                /*" -1116- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1118- MOVE 'VRPLAPPD    ' TO CSP-LIT. */
                _.Move("VRPLAPPD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1119- MOVE 'VRPLAAPD    ' TO CSP-LIT. */
            _.Move("VRPLAAPD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1120- IF CSP-VRPLAAPD NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLAAPD.IsNumeric())
            {

                /*" -1121- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1123- MOVE 'VRPLAAPD    ' TO CSP-LIT. */
                _.Move("VRPLAAPD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1124- MOVE 'VRPRRCDM    ' TO CSP-LIT. */
            _.Move("VRPRRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1125- IF CSP-VRPRRCDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPRRCDM.IsNumeric())
            {

                /*" -1126- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1128- MOVE 'VRPRRCDM    ' TO CSP-LIT. */
                _.Move("VRPRRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1129- MOVE 'VRPRRCDP    ' TO CSP-LIT. */
            _.Move("VRPRRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1130- IF CSP-VRPRRCDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPRRCDP.IsNumeric())
            {

                /*" -1131- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1133- MOVE 'VRPRRCDP    ' TO CSP-LIT. */
                _.Move("VRPRRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1134- MOVE 'VRPRRCDMO   ' TO CSP-LIT. */
            _.Move("VRPRRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1135- IF CSP-VRPRRCDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPRRCDMO.IsNumeric())
            {

                /*" -1136- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1138- MOVE 'VRPRRCDMO   ' TO CSP-LIT. */
                _.Move("VRPRRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1139- MOVE 'VRISFROB    ' TO CSP-LIT. */
            _.Move("VRISFROB    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1140- IF CSP-VRISFROB NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISFROB.IsNumeric())
            {

                /*" -1141- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1143- MOVE 'VRISFROB    ' TO CSP-LIT. */
                _.Move("VRISFROB    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1144- MOVE 'VRISFRCA    ' TO CSP-LIT. */
            _.Move("VRISFRCA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1145- IF CSP-VRISFRCA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISFRCA.IsNumeric())
            {

                /*" -1146- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1148- MOVE 'VRISFRCA    ' TO CSP-LIT. */
                _.Move("VRISFRCA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1149- MOVE 'VRISFRAC    ' TO CSP-LIT. */
            _.Move("VRISFRAC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1150- IF CSP-VRISFRAC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISFRAC.IsNumeric())
            {

                /*" -1151- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1153- MOVE 'VRISFRAC    ' TO CSP-LIT. */
                _.Move("VRISFRAC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1154- MOVE 'VRISFRAD    ' TO CSP-LIT. */
            _.Move("VRISFRAD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1155- IF CSP-VRISFRAD NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISFRAD.IsNumeric())
            {

                /*" -1156- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1158- MOVE 'VRISFRAD    ' TO CSP-LIT. */
                _.Move("VRISFRAD    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1159- MOVE 'CFFRFACA    ' TO CSP-LIT. */
            _.Move("CFFRFACA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1160- IF CSP-CFFRFACA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_CFFRFACA.IsNumeric())
            {

                /*" -1161- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1163- MOVE 'CFFRFACA    ' TO CSP-LIT. */
                _.Move("CFFRFACA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1164- MOVE 'VRISACCA    ' TO CSP-LIT. */
            _.Move("VRISACCA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1165- IF CSP-VRISACCA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRISACCA.IsNumeric())
            {

                /*" -1166- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1168- MOVE 'VRISACCA    ' TO CSP-LIT. */
                _.Move("VRISACCA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1169- MOVE 'DESCFROT    ' TO CSP-LIT. */
            _.Move("DESCFROT    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1170- IF CSP-DESCFROT NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DESCFROT.IsNumeric())
            {

                /*" -1171- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1173- MOVE 'DESCFROT    ' TO CSP-LIT. */
                _.Move("DESCFROT    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1174- MOVE 'VRPLACES    ' TO CSP-LIT. */
            _.Move("VRPLACES    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1175- IF CSP-VRPLACES NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRPLACES.IsNumeric())
            {

                /*" -1176- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1178- MOVE 'VRPLACES    ' TO CSP-LIT. */
                _.Move("VRPLACES    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1179- MOVE 'VRADACES    ' TO CSP-LIT. */
            _.Move("VRADACES    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1180- IF CSP-VRADACES NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VRADACES.IsNumeric())
            {

                /*" -1181- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1183- MOVE 'VRADACES    ' TO CSP-LIT. */
                _.Move("VRADACES    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1184- MOVE 'ACEANU      ' TO CSP-LIT. */
            _.Move("ACEANU      ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1185- IF CSP-ACEANU NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_ACEANU.IsNumeric())
            {

                /*" -1186- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1188- MOVE 'ACEANU      ' TO CSP-LIT. */
                _.Move("ACEANU      ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1189- MOVE 'TVRPRREF    ' TO CSP-LIT. */
            _.Move("TVRPRREF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1190- IF CSP-TVRPRREF NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TVRPRREF.IsNumeric())
            {

                /*" -1191- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1193- MOVE 'TVRPRREF    ' TO CSP-LIT. */
                _.Move("TVRPRREF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1194- MOVE 'TCFFROBR    ' TO CSP-LIT. */
            _.Move("TCFFROBR    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1195- IF CSP-TCFFROBR NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFFROBR.IsNumeric())
            {

                /*" -1196- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1198- MOVE 'TCFFROBR    ' TO CSP-LIT. */
                _.Move("TCFFROBR    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1199- MOVE 'TCFFRFCC    ' TO CSP-LIT. */
            _.Move("TCFFRFCC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1200- IF CSP-TCFFRFCC NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFFRFCC.IsNumeric())
            {

                /*" -1201- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1203- MOVE 'TCFFRFCC    ' TO CSP-LIT. */
                _.Move("TCFFRFCC    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1204- MOVE 'TCFFRFCA    ' TO CSP-LIT. */
            _.Move("TCFFRFCA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1205- IF CSP-TCFFRFCA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFFRFCA.IsNumeric())
            {

                /*" -1206- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1208- MOVE 'TCFFRFCA    ' TO CSP-LIT. */
                _.Move("TCFFRFCA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1209- MOVE 'TCFAPLPR    ' TO CSP-LIT. */
            _.Move("TCFAPLPR    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1210- IF CSP-TCFAPLPR NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFAPLPR.IsNumeric())
            {

                /*" -1211- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1213- MOVE 'TCFAPLPR    ' TO CSP-LIT. */
                _.Move("TCFAPLPR    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1214- MOVE 'TPCDSFRF    ' TO CSP-LIT. */
            _.Move("TPCDSFRF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1215- IF CSP-TPCDSFRF NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCDSFRF.IsNumeric())
            {

                /*" -1216- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1218- MOVE 'TPCDSFRF    ' TO CSP-LIT. */
                _.Move("TPCDSFRF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1219- MOVE 'TPCDSIDA    ' TO CSP-LIT. */
            _.Move("TPCDSIDA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1220- IF CSP-TPCDSIDA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCDSIDA.IsNumeric())
            {

                /*" -1221- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1223- MOVE 'TPCDSIDA    ' TO CSP-LIT. */
                _.Move("TPCDSIDA    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1224- MOVE 'TPCDSBAU    ' TO CSP-LIT. */
            _.Move("TPCDSBAU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1225- IF CSP-TPCDSBAU NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCDSBAU.IsNumeric())
            {

                /*" -1226- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1228- MOVE 'TPCDSBAU    ' TO CSP-LIT. */
                _.Move("TPCDSBAU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1229- MOVE 'TTXAPLIS    ' TO CSP-LIT. */
            _.Move("TTXAPLIS    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1230- IF CSP-TTXAPLIS NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TTXAPLIS.IsNumeric())
            {

                /*" -1231- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1233- MOVE 'TTXAPLIS    ' TO CSP-LIT. */
                _.Move("TTXAPLIS    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1234- MOVE 'TPCINROU    ' TO CSP-LIT. */
            _.Move("TPCINROU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1235- IF CSP-TPCINROU NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCINROU.IsNumeric())
            {

                /*" -1236- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1238- MOVE 'TPCINROU    ' TO CSP-LIT. */
                _.Move("TPCINROU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1239- MOVE 'TPCPZSEG    ' TO CSP-LIT. */
            _.Move("TPCPZSEG    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1240- IF CSP-TPCPZSEG NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCPZSEG.IsNumeric())
            {

                /*" -1241- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1243- MOVE 'TPCPZSEG    ' TO CSP-LIT. */
                _.Move("TPCPZSEG    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1244- MOVE 'TTXISACE    ' TO CSP-LIT. */
            _.Move("TTXISACE    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1245- IF CSP-TTXISACE NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TTXISACE.IsNumeric())
            {

                /*" -1246- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1248- MOVE 'TTXISACE    ' TO CSP-LIT. */
                _.Move("TTXISACE    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1249- MOVE 'TPRBRCDM    ' TO CSP-LIT. */
            _.Move("TPRBRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1250- IF CSP-TPRBRCDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPRBRCDM.IsNumeric())
            {

                /*" -1251- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1253- MOVE 'TPRBRCDM    ' TO CSP-LIT. */
                _.Move("TPRBRCDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1254- MOVE 'TCFPBRDM    ' TO CSP-LIT. */
            _.Move("TCFPBRDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1255- IF CSP-TCFPBRDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFPBRDM.IsNumeric())
            {

                /*" -1256- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1258- MOVE 'TCFPBRDM    ' TO CSP-LIT. */
                _.Move("TCFPBRDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1259- MOVE 'TPRBRCDP    ' TO CSP-LIT. */
            _.Move("TPRBRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1260- IF CSP-TPRBRCDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPRBRCDP.IsNumeric())
            {

                /*" -1261- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1263- MOVE 'TPRBRCDP    ' TO CSP-LIT. */
                _.Move("TPRBRCDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1264- MOVE 'TCFPBRDP    ' TO CSP-LIT. */
            _.Move("TCFPBRDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1265- IF CSP-TCFPBRDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFPBRDP.IsNumeric())
            {

                /*" -1266- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1268- MOVE 'TCFPBRDP    ' TO CSP-LIT. */
                _.Move("TCFPBRDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1269- MOVE 'TPRBRCDMO   ' TO CSP-LIT. */
            _.Move("TPRBRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1270- IF CSP-TPRBRCDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPRBRCDMO.IsNumeric())
            {

                /*" -1271- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1273- MOVE 'TPRBRCDMO   ' TO CSP-LIT. */
                _.Move("TPRBRCDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1274- MOVE 'TCFPBRDMO   ' TO CSP-LIT. */
            _.Move("TCFPBRDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1275- IF CSP-TCFPBRDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TCFPBRDMO.IsNumeric())
            {

                /*" -1276- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1278- MOVE 'TCFPBRDMO   ' TO CSP-LIT. */
                _.Move("TCFPBRDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1279- MOVE 'TPCBONDM    ' TO CSP-LIT. */
            _.Move("TPCBONDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1280- IF CSP-TPCBONDM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCBONDM.IsNumeric())
            {

                /*" -1281- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1283- MOVE 'TPCBONDM    ' TO CSP-LIT. */
                _.Move("TPCBONDM    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1284- MOVE 'TPCBONDP    ' TO CSP-LIT. */
            _.Move("TPCBONDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1285- IF CSP-TPCBONDP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCBONDP.IsNumeric())
            {

                /*" -1286- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1288- MOVE 'TPCBONDP    ' TO CSP-LIT. */
                _.Move("TPCBONDP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1289- MOVE 'TPCBONDMO   ' TO CSP-LIT. */
            _.Move("TPCBONDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1290- IF CSP-TPCBONDMO NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCBONDMO.IsNumeric())
            {

                /*" -1291- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1293- MOVE 'TPCBONDMO   ' TO CSP-LIT. */
                _.Move("TPCBONDMO   ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1294- MOVE 'TTXAPPM     ' TO CSP-LIT. */
            _.Move("TTXAPPM     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1295- IF CSP-TTXAPPM NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TTXAPPM.IsNumeric())
            {

                /*" -1296- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1298- MOVE 'TTXAPPM     ' TO CSP-LIT. */
                _.Move("TTXAPPM     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1299- MOVE 'TTXAPPI     ' TO CSP-LIT. */
            _.Move("TTXAPPI     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1300- IF CSP-TTXAPPI NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TTXAPPI.IsNumeric())
            {

                /*" -1301- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1303- MOVE 'TTXAPPI     ' TO CSP-LIT. */
                _.Move("TTXAPPI     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1304- MOVE 'TTXAPPA     ' TO CSP-LIT. */
            _.Move("TTXAPPA     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1305- IF CSP-TTXAPPA NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TTXAPPA.IsNumeric())
            {

                /*" -1306- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1308- MOVE 'TTXAPPA     ' TO CSP-LIT. */
                _.Move("TTXAPPA     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1309- MOVE 'TTXAPPD     ' TO CSP-LIT. */
            _.Move("TTXAPPD     ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1310- IF CSP-TTXAPPD NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TTXAPPD.IsNumeric())
            {

                /*" -1311- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1313- MOVE 'TTXAPPD     ' TO CSP-LIT. */
                _.Move("TTXAPPD     ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1314- MOVE 'TPCDSAPP    ' TO CSP-LIT. */
            _.Move("TPCDSAPP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1315- IF CSP-TPCDSAPP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_TPCDSAPP.IsNumeric())
            {

                /*" -1316- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1318- MOVE 'TPCDSAPP    ' TO CSP-LIT. */
                _.Move("TPCDSAPP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1319- MOVE 'DTINIVIG    ' TO CSP-LIT. */
            _.Move("DTINIVIG    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1320- IF CSP-DTINIVIG NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_DTINIVIG.IsNumeric())
            {

                /*" -1321- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1323- MOVE 'DTINIVIG    ' TO CSP-LIT. */
                _.Move("DTINIVIG    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1324- MOVE 'PCDESAUT    ' TO CSP-LIT. */
            _.Move("PCDESAUT    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1325- IF CSP-PCDESAUT NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCDESAUT.IsNumeric())
            {

                /*" -1326- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1328- MOVE 'PCDESAUT    ' TO CSP-LIT. */
                _.Move("PCDESAUT    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1329- MOVE 'PCDESRCF    ' TO CSP-LIT. */
            _.Move("PCDESRCF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1330- IF CSP-PCDESRCF NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCDESRCF.IsNumeric())
            {

                /*" -1331- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1333- MOVE 'PCDESRCF    ' TO CSP-LIT. */
                _.Move("PCDESRCF    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1334- MOVE 'PCDESAPP    ' TO CSP-LIT. */
            _.Move("PCDESAPP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1335- IF CSP-PCDESAPP NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCDESAPP.IsNumeric())
            {

                /*" -1336- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1338- MOVE 'PCDESAPP    ' TO CSP-LIT. */
                _.Move("PCDESAPP    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1339- MOVE 'PCREDTAX    ' TO CSP-LIT. */
            _.Move("PCREDTAX    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1340- IF CSP-PCREDTAX NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_PCREDTAX.IsNumeric())
            {

                /*" -1341- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1343- MOVE 'PCREDTAX    ' TO CSP-LIT. */
                _.Move("PCREDTAX    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1344- MOVE 'CODPRODU    ' TO CSP-LIT. */
            _.Move("CODPRODU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1345- IF CSP-CODPRODU NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_CODPRODU.IsNumeric())
            {

                /*" -1346- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1348- MOVE 'CODPRODU    ' TO CSP-LIT. */
                _.Move("CODPRODU    ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1349- MOVE 'VERSAO      ' TO CSP-LIT. */
            _.Move("VERSAO      ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1350- IF CSP-VERSAON NOT NUMERIC */

            if (!CSP_REGISTRO.CSP_VERSAON.IsNumeric())
            {

                /*" -1351- MOVE 999 TO CSP-CODE */
                _.Move(999, CSP_RETORNO.CSP_MSG.CSP_CODE);

                /*" -1353- MOVE 'VERSAO      ' TO CSP-LIT. */
                _.Move("VERSAO      ", CSP_RETORNO.CSP_MSG.CSP_LIT);
            }


            /*" -1354- MOVE 'CSP-CODE    ' TO CSP-LIT. */
            _.Move("CSP-CODE    ", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -1355- IF CSP-CODE EQUAL 999 */

            if (CSP_RETORNO.CSP_MSG.CSP_CODE == 999)
            {

                /*" -1356- MOVE 3 TO CSP-W01P0300 */
                _.Move(3, CSP_REGISTRO.CSP_W01P0300);

                /*" -1358- MOVE CSP-RETORNO TO CSP-W01A0077 */
                _.Move(CSP_RETORNO, CSP_REGISTRO.CSP_W01A0077);

                /*" -1358- GOBACK. */

                throw new GoBack();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_005_999_EXIT*/

        [StopWatch]
        /*" M-010-000-SELECIONA-TAXAS-SECTION */
        private void M_010_000_SELECIONA_TAXAS_SECTION()
        {
            /*" -1370- MOVE '010-000 - SELECIONA TAXAS P/ I.S.' TO CSP-MSG. */
            _.Move("010-000 - SELECIONA TAXAS P/ I.S.", CSP_RETORNO.CSP_MSG);

            /*" -1371- MOVE CSP-REGIAO TO TAXAC-REGIAO */
            _.Move(CSP_REGISTRO.CSP_REGIAO, CSP_RETORNO.TAXAC_REGIAO);

            /*" -1372- MOVE CSP-TIPOVEIC TO TAXAC-CODAGRUPA */
            _.Move(CSP_REGISTRO.CSP_TIPOVEIC, CSP_RETORNO.TAXAC_CODAGRUPA);

            /*" -1373- MOVE CSP-INDANO TO TAXAC-ANOVEICL */
            _.Move(CSP_REGISTRO.CSP_INDANO, CSP_RETORNO.TAXAC_ANOVEICL);

            /*" -1374- MOVE CSP-CODPRODU TO TAXAC-CODPRODU */
            _.Move(CSP_REGISTRO.CSP_CODPRODU, CSP_RETORNO.TAXAC_CODPRODU);

            /*" -1376- MOVE CSP-VERSAON TO TAXAC-VERSAO. */
            _.Move(CSP_REGISTRO.CSP_VERSAON, CSP_RETORNO.TAXAC_VERSAO);

            /*" -1390- PERFORM M_010_000_SELECIONA_TAXAS_DB_SELECT_1 */

            M_010_000_SELECIONA_TAXAS_DB_SELECT_1();

            /*" -1393- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1394- GO TO 010-000-SEL-PULA */

                M_010_000_SEL_PULA(); //GOTO
                return;

                /*" -1395- ELSE */
            }
            else
            {


                /*" -1396- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1397- MOVE '010-000' TO CSP-PROCPAR */
                    _.Move("010-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -1398- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -1400- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


            /*" -1402- MOVE '010-100 - SELECIONA TAXAS P/ I.S.' TO CSP-MSG. */
            _.Move("010-100 - SELECIONA TAXAS P/ I.S.", CSP_RETORNO.CSP_MSG);

            /*" -1403- MOVE CSP-REGIAO TO TAXAC-REGIAO */
            _.Move(CSP_REGISTRO.CSP_REGIAO, CSP_RETORNO.TAXAC_REGIAO);

            /*" -1404- MOVE CSP-CATTARIO TO TAXAC-CATTARIF */
            _.Move(CSP_REGISTRO.CSP_CATTARIO, CSP_RETORNO.TAXAC_CATTARIF);

            /*" -1405- MOVE CSP-TIPOVEIC TO TAXAC-CODAGRUPA */
            _.Move(CSP_REGISTRO.CSP_TIPOVEIC, CSP_RETORNO.TAXAC_CODAGRUPA);

            /*" -1406- MOVE CSP-INDANO TO TAXAC-ANOVEICL */
            _.Move(CSP_REGISTRO.CSP_INDANO, CSP_RETORNO.TAXAC_ANOVEICL);

            /*" -1407- MOVE CSP-CODPRODU TO TAXAC-CODPRODU */
            _.Move(CSP_REGISTRO.CSP_CODPRODU, CSP_RETORNO.TAXAC_CODPRODU);

            /*" -1409- MOVE CSP-DTINIAUTO TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM, WS_DATA1);

            /*" -1410- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -1411- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -1412- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -1414- MOVE WDATA-CHAR TO TAXAC-DTINIVIG. */
            _.Move(WDATA_CHAR, CSP_RETORNO.TAXAC_DTINIVIG);

            /*" -1430- PERFORM M_010_000_SELECIONA_TAXAS_DB_SELECT_2 */

            M_010_000_SELECIONA_TAXAS_DB_SELECT_2();

            /*" -1433- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1434- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -1435- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -1436- ELSE */
            }
            else
            {


                /*" -1437- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1438- MOVE '010-000' TO CSP-PROCPAR */
                    _.Move("010-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -1439- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -1439- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_010_000_SEL_PULA */

            M_010_000_SEL_PULA();

        }

        [StopWatch]
        /*" M-010-000-SELECIONA-TAXAS-DB-SELECT-1 */
        public void M_010_000_SELECIONA_TAXAS_DB_SELECT_1()
        {
            /*" -1390- EXEC SQL SELECT PRMREF_IX, TAXA_IS, CODUNIMO INTO :TAXAC-PRMREF-IX, :TAXAC-TAXA-IS, :TAXAC-CODUNIMO FROM SEGUROS.V1AUTOCONVTAXA WHERE COD_EMPRESA = 0 AND REGIAO = :TAXAC-REGIAO AND CODPRODU = :TAXAC-CODPRODU AND CODAGRUPA = :TAXAC-CODAGRUPA AND ANOVEICL = :TAXAC-ANOVEICL AND VERSAO = :TAXAC-VERSAO END-EXEC. */

            var m_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1 = new M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1()
            {
                TAXAC_CODAGRUPA = CSP_RETORNO.TAXAC_CODAGRUPA.ToString(),
                TAXAC_CODPRODU = CSP_RETORNO.TAXAC_CODPRODU.ToString(),
                TAXAC_ANOVEICL = CSP_RETORNO.TAXAC_ANOVEICL.ToString(),
                TAXAC_REGIAO = CSP_RETORNO.TAXAC_REGIAO.ToString(),
                TAXAC_VERSAO = CSP_RETORNO.TAXAC_VERSAO.ToString(),
            };

            var executed_1 = M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1.Execute(m_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXAC_PRMREF_IX, CSP_RETORNO.TAXAC_PRMREF_IX);
                _.Move(executed_1.TAXAC_TAXA_IS, CSP_RETORNO.TAXAC_TAXA_IS);
                _.Move(executed_1.TAXAC_CODUNIMO, CSP_RETORNO.TAXAC_CODUNIMO);
            }


        }

        [StopWatch]
        /*" M-010-000-SEL-PULA */
        private void M_010_000_SEL_PULA(bool isPerform = false)
        {
            /*" -1444- IF TAXAC-CODUNIMO EQUAL CSP-MOEDA-IMP */

            if (CSP_RETORNO.TAXAC_CODUNIMO == CSP_REGISTRO.CSP_MOEDA_IMP)
            {

                /*" -1445- MOVE WS-VLCRUZAD-IS TO WS-VLCRUZAD */
                _.Move(WS_VLCRUZAD_IS, WS_VLCRUZAD);

                /*" -1446- ELSE */
            }
            else
            {


                /*" -1447- IF TAXAC-CODUNIMO EQUAL CSP-MOEDA-PRM */

                if (CSP_RETORNO.TAXAC_CODUNIMO == CSP_REGISTRO.CSP_MOEDA_PRM)
                {

                    /*" -1448- MOVE WS-VLCRUZAD-PRM TO WS-VLCRUZAD */
                    _.Move(WS_VLCRUZAD_PRM, WS_VLCRUZAD);

                    /*" -1449- ELSE */
                }
                else
                {


                    /*" -1450- MOVE TAXAC-CODUNIMO TO V1MOEDA-CODUNIMO */
                    _.Move(CSP_RETORNO.TAXAC_CODUNIMO, CSP_RETORNO.V1MOEDA_CODUNIMO);

                    /*" -1451- MOVE WDATA-CHAR TO V1MOEDA-DTINIVIG */
                    _.Move(WDATA_CHAR, CSP_RETORNO.V1MOEDA_DTINIVIG);

                    /*" -1452- PERFORM 015-000-SQL-SELECT-V1MOEDA */

                    M_015_000_SQL_SELECT_V1MOEDA_SECTION();

                    /*" -1454- MOVE V1MOEDA-VLCRUZAD TO WS-VLCRUZAD. */
                    _.Move(CSP_RETORNO.V1MOEDA_VLCRUZAD, WS_VLCRUZAD);
                }

            }


            /*" -1456- MOVE TAXAC-CODUNIMO TO WS-CODUNIMO. */
            _.Move(CSP_RETORNO.TAXAC_CODUNIMO, WS_CODUNIMO);

            /*" -1457- IF CSP-VRPRREF EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRPRREF == 00)
            {

                /*" -1460- COMPUTE CSP-VRPRREF ROUNDED = TAXAC-PRMREF-IX * WS-VLCRUZAD */
                CSP_REGISTRO.CSP_VRPRREF.Value = CSP_RETORNO.TAXAC_PRMREF_IX * WS_VLCRUZAD;

                /*" -1462- IF TAXAC-CODAGRUPA EQUAL ( 9301 OR 9302 OR 9303 OR 9304 OR 9401 ) */

                if (CSP_RETORNO.TAXAC_CODAGRUPA.In("9301", "9302", "9303", "9304", "9401"))
                {

                    /*" -1463- COMPUTE WS-FRANQUIA = CSP-VRISCASC * 4,0 / 100 */
                    CSP_RETORNO.WS_FRANQUIA.Value = CSP_REGISTRO.CSP_VRISCASC * 4.0 / 100f;

                    /*" -1464- IF WS-FRANQUIA GREATER CSP-VRPRREF */

                    if (CSP_RETORNO.WS_FRANQUIA > CSP_REGISTRO.CSP_VRPRREF)
                    {

                        /*" -1465- MOVE WS-FRANQUIA TO CSP-VRPRREF */
                        _.Move(CSP_RETORNO.WS_FRANQUIA, CSP_REGISTRO.CSP_VRPRREF);

                        /*" -1467- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1468- ELSE */
                    }

                }
                else
                {


                    /*" -1469- IF TAXAC-CODAGRUPA EQUAL 9400 */

                    if (CSP_RETORNO.TAXAC_CODAGRUPA == 9400)
                    {

                        /*" -1470- COMPUTE WS-FRANQUIA = CSP-VRISCASC * 20,0 / 100 */
                        CSP_RETORNO.WS_FRANQUIA.Value = CSP_REGISTRO.CSP_VRISCASC * 20.0 / 100f;

                        /*" -1472- IF WS-FRANQUIA LESS CSP-VRPRREF NEXT SENTENCE */

                        if (CSP_RETORNO.WS_FRANQUIA < CSP_REGISTRO.CSP_VRPRREF)
                        {

                            /*" -1473- ELSE */
                        }
                        else
                        {


                            /*" -1474- MOVE WS-FRANQUIA TO CSP-VRPRREF */
                            _.Move(CSP_RETORNO.WS_FRANQUIA, CSP_REGISTRO.CSP_VRPRREF);

                            /*" -1475- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1479- IF TAXAC-CODAGRUPA EQUAL ( 9001 OR 9002 OR 9003 OR 9004 OR 9005 OR 9006 OR 9007 OR 9008 OR 9009 OR 9010 OR 9011 OR 9012 OR 9013 ) */

                        if (CSP_RETORNO.TAXAC_CODAGRUPA.In("9001", "9002", "9003", "9004", "9005", "9006", "9007", "9008", "9009", "9010", "9011", "9012", "9013"))
                        {

                            /*" -1480- COMPUTE WS-FRANQUIA = CSP-VRISCASC * 5,0 / 100 */
                            CSP_RETORNO.WS_FRANQUIA.Value = CSP_REGISTRO.CSP_VRISCASC * 5.0 / 100f;

                            /*" -1481- IF WS-FRANQUIA GREATER CSP-VRPRREF */

                            if (CSP_RETORNO.WS_FRANQUIA > CSP_REGISTRO.CSP_VRPRREF)
                            {

                                /*" -1482- MOVE WS-FRANQUIA TO CSP-VRPRREF */
                                _.Move(CSP_RETORNO.WS_FRANQUIA, CSP_REGISTRO.CSP_VRPRREF);

                                /*" -1484- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -1485- ELSE */
                            }

                        }
                        else
                        {


                            /*" -1486- IF TAXAC-CODAGRUPA EQUAL 9018 */

                            if (CSP_RETORNO.TAXAC_CODAGRUPA == 9018)
                            {

                                /*" -1487- COMPUTE WS-FRANQUIA = CSP-VRISCASC * 5,5 / 100 */
                                CSP_RETORNO.WS_FRANQUIA.Value = CSP_REGISTRO.CSP_VRISCASC * 5.5 / 100f;

                                /*" -1488- IF WS-FRANQUIA GREATER CSP-VRPRREF */

                                if (CSP_RETORNO.WS_FRANQUIA > CSP_REGISTRO.CSP_VRPRREF)
                                {

                                    /*" -1490- MOVE WS-FRANQUIA TO CSP-VRPRREF. */
                                    _.Move(CSP_RETORNO.WS_FRANQUIA, CSP_REGISTRO.CSP_VRPRREF);
                                }

                            }

                        }

                    }

                }

            }


            /*" -1493- MOVE CSP-VRPRREF TO CSP-TVRPRREF. */
            _.Move(CSP_REGISTRO.CSP_VRPRREF, CSP_REGISTRO.CSP_TVRPRREF);

            /*" -1494- IF CSP-TTXAPLIS EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_TTXAPLIS == 00)
            {

                /*" -1494- MOVE TAXAC-TAXA-IS TO CSP-TTXAPLIS. */
                _.Move(CSP_RETORNO.TAXAC_TAXA_IS, CSP_REGISTRO.CSP_TTXAPLIS);
            }


        }

        [StopWatch]
        /*" M-010-000-SELECIONA-TAXAS-DB-SELECT-2 */
        public void M_010_000_SELECIONA_TAXAS_DB_SELECT_2()
        {
            /*" -1430- EXEC SQL SELECT PRMREF_IX, TAXA_IS, CODUNIMO INTO :TAXAC-PRMREF-IX, :TAXAC-TAXA-IS, :TAXAC-CODUNIMO FROM SEGUROS.V1AUTOCONVTAXA WHERE COD_EMPRESA = 0 AND REGIAO = :TAXAC-REGIAO AND CODPRODU = :TAXAC-CODPRODU AND CODAGRUPA = :TAXAC-CODAGRUPA AND ANOVEICL = :TAXAC-ANOVEICL AND DTINIVIG <= :TAXAC-DTINIVIG AND DTTERVIG >= :TAXAC-DTINIVIG AND VERSAO < 203 END-EXEC. */

            var m_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1 = new M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1()
            {
                TAXAC_CODAGRUPA = CSP_RETORNO.TAXAC_CODAGRUPA.ToString(),
                TAXAC_CODPRODU = CSP_RETORNO.TAXAC_CODPRODU.ToString(),
                TAXAC_ANOVEICL = CSP_RETORNO.TAXAC_ANOVEICL.ToString(),
                TAXAC_DTINIVIG = CSP_RETORNO.TAXAC_DTINIVIG.ToString(),
                TAXAC_REGIAO = CSP_RETORNO.TAXAC_REGIAO.ToString(),
            };

            var executed_1 = M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1.Execute(m_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXAC_PRMREF_IX, CSP_RETORNO.TAXAC_PRMREF_IX);
                _.Move(executed_1.TAXAC_TAXA_IS, CSP_RETORNO.TAXAC_TAXA_IS);
                _.Move(executed_1.TAXAC_CODUNIMO, CSP_RETORNO.TAXAC_CODUNIMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_999_EXIT*/

        [StopWatch]
        /*" M-015-000-SQL-SELECT-V1MOEDA-SECTION */
        private void M_015_000_SQL_SELECT_V1MOEDA_SECTION()
        {
            /*" -1505- MOVE '015-000 - SELECIONA COTACAO DA MOEDA' TO CSP-MSG. */
            _.Move("015-000 - SELECIONA COTACAO DA MOEDA", CSP_RETORNO.CSP_MSG);

            /*" -1506- MOVE WDATA-CHAR TO V1MOEDA-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.V1MOEDA_DTINIVIG);

            /*" -1518- PERFORM M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1 */

            M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -1521- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1522- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -1523- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -1524- ELSE */
            }
            else
            {


                /*" -1525- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1526- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -1526- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-015-000-SQL-SELECT-V1MOEDA-DB-SELECT-1 */
        public void M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -1518- EXEC SQL SELECT VLCRUZAD INTO :V1MOEDA-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :V1MOEDA-CODUNIMO AND DTINIVIG <= :V1MOEDA-DTINIVIG AND DTTERVIG >= :V1MOEDA-DTINIVIG AND SITUACAO = '0' END-EXEC. */

            var m_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                V1MOEDA_CODUNIMO = CSP_RETORNO.V1MOEDA_CODUNIMO.ToString(),
                V1MOEDA_DTINIVIG = CSP_RETORNO.V1MOEDA_DTINIVIG.ToString(),
            };

            var executed_1 = M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(m_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOEDA_VLCRUZAD, CSP_RETORNO.V1MOEDA_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-020-000-SELECIONA-BONUS-SECTION */
        private void M_020_000_SELECIONA_BONUS_SECTION()
        {
            /*" -1538- MOVE '020-000 - SELECIONA PERCENTUAL POR BONUS' TO CSP-MSG. */
            _.Move("020-000 - SELECIONA PERCENTUAL POR BONUS", CSP_RETORNO.CSP_MSG);

            /*" -1540- MOVE SPACES TO WS-TEMBONUS. */
            _.Move("", CSP_RETORNO.WS_TEMBONUS);

            /*" -1542- IF CSP-TIPOCOB EQUAL 1 AND CSP-CLABONAT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1 && CSP_REGISTRO.CSP_CLABONAT == 00)
            {

                /*" -1543- IF CSP-DTINIAUTO GREATER 19970131 */

                if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131)
                {

                    /*" -1544- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                    M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                    /*" -1545- IF WS-TEMBONUS EQUAL 'S' */

                    if (CSP_RETORNO.WS_TEMBONUS == "S")
                    {

                        /*" -1546- PERFORM 021-000-SELEC-BONUS-PLUS */

                        M_021_000_SELEC_BONUS_PLUS_SECTION();

                        /*" -1547- ELSE */
                    }
                    else
                    {


                        /*" -1548- MOVE ZEROS TO CSP-TPCDSBAU */
                        _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                        /*" -1549- MOVE ZEROS TO CSP-TPCBONDM */
                        _.Move(0, CSP_REGISTRO.CSP_TPCBONDM);

                        /*" -1550- MOVE ZEROS TO CSP-TPCBONDP */
                        _.Move(0, CSP_REGISTRO.CSP_TPCBONDP);

                        /*" -1551- MOVE ZEROS TO CSP-TPCBONDMO */
                        _.Move(0, CSP_REGISTRO.CSP_TPCBONDMO);

                        /*" -1552- GO TO 020-999-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                        return;

                        /*" -1553- ELSE */
                    }

                }
                else
                {


                    /*" -1554- MOVE ZEROS TO CSP-TPCDSBAU */
                    _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                    /*" -1555- MOVE ZEROS TO CSP-TPCBONDM */
                    _.Move(0, CSP_REGISTRO.CSP_TPCBONDM);

                    /*" -1556- MOVE ZEROS TO CSP-TPCBONDP */
                    _.Move(0, CSP_REGISTRO.CSP_TPCBONDP);

                    /*" -1557- MOVE ZEROS TO CSP-TPCBONDMO */
                    _.Move(0, CSP_REGISTRO.CSP_TPCBONDMO);

                    /*" -1559- GO TO 020-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -1561- IF CSP-TIPOCOB EQUAL 1 AND CSP-CLABONAT GREATER ZEROS */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1 && CSP_REGISTRO.CSP_CLABONAT > 00)
            {

                /*" -1562- IF CSP-DTINIAUTO GREATER 19970131 */

                if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131)
                {

                    /*" -1563- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                    M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                    /*" -1564- IF WS-TEMBONUS EQUAL 'S' */

                    if (CSP_RETORNO.WS_TEMBONUS == "S")
                    {

                        /*" -1565- PERFORM 021-000-SELEC-BONUS-PLUS */

                        M_021_000_SELEC_BONUS_PLUS_SECTION();

                        /*" -1566- ELSE */
                    }
                    else
                    {


                        /*" -1567- MOVE 6 TO BONAU-CODTAB */
                        _.Move(6, CSP_RETORNO.BONAU_CODTAB);

                        /*" -1568- MOVE CSP-CLABONAT TO BONAU-CLASSEBN */
                        _.Move(CSP_REGISTRO.CSP_CLABONAT, CSP_RETORNO.BONAU_CLASSEBN);

                        /*" -1569- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                        _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                        /*" -1570- PERFORM 025-000-LE-BONUS */

                        M_025_000_LE_BONUS_SECTION();

                        /*" -1574- MOVE BONAU-PCDESC TO CSP-TPCDSBAU CSP-TPCBONDM CSP-TPCBONDP CSP-TPCBONDMO */
                        _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCDSBAU, CSP_REGISTRO.CSP_TPCBONDM, CSP_REGISTRO.CSP_TPCBONDP, CSP_REGISTRO.CSP_TPCBONDMO);

                        /*" -1575- GO TO 020-999-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                        return;

                        /*" -1576- ELSE */
                    }

                }
                else
                {


                    /*" -1577- MOVE 6 TO BONAU-CODTAB */
                    _.Move(6, CSP_RETORNO.BONAU_CODTAB);

                    /*" -1578- MOVE CSP-CLABONAT TO BONAU-CLASSEBN */
                    _.Move(CSP_REGISTRO.CSP_CLABONAT, CSP_RETORNO.BONAU_CLASSEBN);

                    /*" -1579- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                    _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                    /*" -1580- PERFORM 025-000-LE-BONUS */

                    M_025_000_LE_BONUS_SECTION();

                    /*" -1584- MOVE BONAU-PCDESC TO CSP-TPCDSBAU CSP-TPCBONDM CSP-TPCBONDP CSP-TPCBONDMO */
                    _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCDSBAU, CSP_REGISTRO.CSP_TPCBONDM, CSP_REGISTRO.CSP_TPCBONDP, CSP_REGISTRO.CSP_TPCBONDMO);

                    /*" -1586- GO TO 020-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -1587- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -1588- IF CSP-CLABONDM EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONDM == 00)
                {

                    /*" -1589- IF CSP-DTINIRCDM GREATER 19970131 */

                    if (CSP_REGISTRO.CSP_DTINIRCDM.GetMoveValues().ToInt() > 19970131)
                    {

                        /*" -1590- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                        M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                        /*" -1591- IF WS-TEMBONUS EQUAL 'S' */

                        if (CSP_RETORNO.WS_TEMBONUS == "S")
                        {

                            /*" -1592- PERFORM 022-000-SELEC-BONUS-PLUS-DM */

                            M_022_000_SELEC_BONUS_PLUS_DM_SECTION();

                            /*" -1593- ELSE */
                        }
                        else
                        {


                            /*" -1594- MOVE ZEROS TO CSP-TPCBONDM */
                            _.Move(0, CSP_REGISTRO.CSP_TPCBONDM);

                            /*" -1595- MOVE ZEROS TO CSP-TPCDSBAU */
                            _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                            /*" -1596- GO TO 020-999-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                            return;

                            /*" -1597- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1598- MOVE ZEROS TO CSP-TPCBONDM */
                        _.Move(0, CSP_REGISTRO.CSP_TPCBONDM);

                        /*" -1599- MOVE ZEROS TO CSP-TPCDSBAU */
                        _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                        /*" -1601- GO TO 020-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1602- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -1603- IF CSP-CLABONDM GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONDM > 00)
                {

                    /*" -1604- IF CSP-DTINIAUTO GREATER 19970131 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131)
                    {

                        /*" -1605- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                        M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                        /*" -1606- IF WS-TEMBONUS EQUAL 'S' */

                        if (CSP_RETORNO.WS_TEMBONUS == "S")
                        {

                            /*" -1607- PERFORM 022-000-SELEC-BONUS-PLUS-DM */

                            M_022_000_SELEC_BONUS_PLUS_DM_SECTION();

                            /*" -1608- ELSE */
                        }
                        else
                        {


                            /*" -1609- MOVE 7 TO BONAU-CODTAB */
                            _.Move(7, CSP_RETORNO.BONAU_CODTAB);

                            /*" -1610- MOVE CSP-CLABONDM TO BONAU-CLASSEBN */
                            _.Move(CSP_REGISTRO.CSP_CLABONDM, CSP_RETORNO.BONAU_CLASSEBN);

                            /*" -1611- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                            _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                            /*" -1612- PERFORM 025-000-LE-BONUS */

                            M_025_000_LE_BONUS_SECTION();

                            /*" -1613- MOVE BONAU-PCDESC TO CSP-TPCBONDM */
                            _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCBONDM);

                            /*" -1614- MOVE ZEROS TO CSP-TPCDSBAU */
                            _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                            /*" -1615- GO TO 020-999-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                            return;

                            /*" -1616- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1617- MOVE 7 TO BONAU-CODTAB */
                        _.Move(7, CSP_RETORNO.BONAU_CODTAB);

                        /*" -1618- MOVE CSP-CLABONDM TO BONAU-CLASSEBN */
                        _.Move(CSP_REGISTRO.CSP_CLABONDM, CSP_RETORNO.BONAU_CLASSEBN);

                        /*" -1619- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                        _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                        /*" -1620- PERFORM 025-000-LE-BONUS */

                        M_025_000_LE_BONUS_SECTION();

                        /*" -1621- MOVE BONAU-PCDESC TO CSP-TPCBONDM */
                        _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCBONDM);

                        /*" -1622- MOVE ZEROS TO CSP-TPCDSBAU */
                        _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                        /*" -1624- GO TO 020-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1625- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -1626- IF CSP-CLABONDP EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONDP == 00)
                {

                    /*" -1627- IF CSP-DTINIRCDM GREATER 19970131 */

                    if (CSP_REGISTRO.CSP_DTINIRCDM.GetMoveValues().ToInt() > 19970131)
                    {

                        /*" -1628- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                        M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                        /*" -1629- IF WS-TEMBONUS EQUAL 'S' */

                        if (CSP_RETORNO.WS_TEMBONUS == "S")
                        {

                            /*" -1630- PERFORM 023-000-SELEC-BONUS-PLUS-DP */

                            M_023_000_SELEC_BONUS_PLUS_DP_SECTION();

                            /*" -1631- ELSE */
                        }
                        else
                        {


                            /*" -1632- MOVE ZEROS TO CSP-TPCBONDP */
                            _.Move(0, CSP_REGISTRO.CSP_TPCBONDP);

                            /*" -1633- MOVE ZEROS TO CSP-TPCDSBAU */
                            _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                            /*" -1634- GO TO 020-999-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                            return;

                            /*" -1635- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1636- MOVE ZEROS TO CSP-TPCBONDP */
                        _.Move(0, CSP_REGISTRO.CSP_TPCBONDP);

                        /*" -1637- MOVE ZEROS TO CSP-TPCDSBAU */
                        _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                        /*" -1639- GO TO 020-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1640- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -1641- IF CSP-CLABONDP GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONDP > 00)
                {

                    /*" -1642- IF CSP-DTINIAUTO GREATER 19970131 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131)
                    {

                        /*" -1643- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                        M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                        /*" -1644- IF WS-TEMBONUS EQUAL 'S' */

                        if (CSP_RETORNO.WS_TEMBONUS == "S")
                        {

                            /*" -1645- PERFORM 023-000-SELEC-BONUS-PLUS-DP */

                            M_023_000_SELEC_BONUS_PLUS_DP_SECTION();

                            /*" -1646- ELSE */
                        }
                        else
                        {


                            /*" -1647- MOVE 7 TO BONAU-CODTAB */
                            _.Move(7, CSP_RETORNO.BONAU_CODTAB);

                            /*" -1648- MOVE CSP-CLABONDP TO BONAU-CLASSEBN */
                            _.Move(CSP_REGISTRO.CSP_CLABONDP, CSP_RETORNO.BONAU_CLASSEBN);

                            /*" -1649- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                            _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                            /*" -1650- PERFORM 025-000-LE-BONUS */

                            M_025_000_LE_BONUS_SECTION();

                            /*" -1651- MOVE BONAU-PCDESC TO CSP-TPCBONDP */
                            _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCBONDP);

                            /*" -1652- MOVE ZEROS TO CSP-TPCDSBAU */
                            _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

                            /*" -1653- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1654- MOVE 7 TO BONAU-CODTAB */
                        _.Move(7, CSP_RETORNO.BONAU_CODTAB);

                        /*" -1655- MOVE CSP-CLABONDP TO BONAU-CLASSEBN */
                        _.Move(CSP_REGISTRO.CSP_CLABONDP, CSP_RETORNO.BONAU_CLASSEBN);

                        /*" -1656- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                        _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                        /*" -1657- PERFORM 025-000-LE-BONUS */

                        M_025_000_LE_BONUS_SECTION();

                        /*" -1658- MOVE BONAU-PCDESC TO CSP-TPCBONDP */
                        _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCBONDP);

                        /*" -1661- MOVE ZEROS TO CSP-TPCDSBAU. */
                        _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);
                    }

                }

            }


            /*" -1663- IF CSP-TIPOCOB EQUAL ZEROS AND CSP-CLABONAT GREATER ZEROS */

            if (CSP_REGISTRO.CSP_TIPOCOB == 00 && CSP_REGISTRO.CSP_CLABONAT > 00)
            {

                /*" -1664- IF CSP-DTINIAUTO GREATER 19970131 */

                if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131)
                {

                    /*" -1665- PERFORM 024-000-VERIF-FAIXA-BONUS-PLUS */

                    M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION();

                    /*" -1666- IF WS-TEMBONUS EQUAL 'S' */

                    if (CSP_RETORNO.WS_TEMBONUS == "S")
                    {

                        /*" -1667- PERFORM 021-000-SELEC-BONUS-PLUS */

                        M_021_000_SELEC_BONUS_PLUS_SECTION();

                        /*" -1668- ELSE */
                    }
                    else
                    {


                        /*" -1669- MOVE 6 TO BONAU-CODTAB */
                        _.Move(6, CSP_RETORNO.BONAU_CODTAB);

                        /*" -1670- MOVE CSP-CLABONAT TO BONAU-CLASSEBN */
                        _.Move(CSP_REGISTRO.CSP_CLABONAT, CSP_RETORNO.BONAU_CLASSEBN);

                        /*" -1671- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                        _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                        /*" -1672- PERFORM 025-000-LE-BONUS */

                        M_025_000_LE_BONUS_SECTION();

                        /*" -1676- MOVE BONAU-PCDESC TO CSP-TPCDSBAU CSP-TPCBONDM CSP-TPCBONDP CSP-TPCBONDMO */
                        _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCDSBAU, CSP_REGISTRO.CSP_TPCBONDM, CSP_REGISTRO.CSP_TPCBONDP, CSP_REGISTRO.CSP_TPCBONDMO);

                        /*" -1677- GO TO 020-999-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                        return;

                        /*" -1678- ELSE */
                    }

                }
                else
                {


                    /*" -1679- MOVE 6 TO BONAU-CODTAB */
                    _.Move(6, CSP_RETORNO.BONAU_CODTAB);

                    /*" -1680- MOVE CSP-CLABONAT TO BONAU-CLASSEBN */
                    _.Move(CSP_REGISTRO.CSP_CLABONAT, CSP_RETORNO.BONAU_CLASSEBN);

                    /*" -1681- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
                    _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

                    /*" -1682- PERFORM 025-000-LE-BONUS */

                    M_025_000_LE_BONUS_SECTION();

                    /*" -1686- MOVE BONAU-PCDESC TO CSP-TPCDSBAU CSP-TPCBONDM CSP-TPCBONDP CSP-TPCBONDMO */
                    _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCDSBAU, CSP_REGISTRO.CSP_TPCBONDM, CSP_REGISTRO.CSP_TPCBONDP, CSP_REGISTRO.CSP_TPCBONDMO);

                    /*" -1686- GO TO 020-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                    return;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-021-000-SELEC-BONUS-PLUS-SECTION */
        private void M_021_000_SELEC_BONUS_PLUS_SECTION()
        {
            /*" -1698- MOVE '021-000 - SELEC. PERC. POR BONUS PLUS' TO CSP-MSG. */
            _.Move("021-000 - SELEC. PERC. POR BONUS PLUS", CSP_RETORNO.CSP_MSG);

            /*" -1700- MOVE 6 TO BONAU-CODTAB */
            _.Move(6, CSP_RETORNO.BONAU_CODTAB);

            /*" -1701- MOVE CSP-CLABONAT TO BONAU-CLASSEBN */
            _.Move(CSP_REGISTRO.CSP_CLABONAT, CSP_RETORNO.BONAU_CLASSEBN);

            /*" -1702- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

            /*" -1703- PERFORM 025-000-LE-BONUS */

            M_025_000_LE_BONUS_SECTION();

            /*" -1706- MOVE BONAU-PCDESC TO CSP-TPCDSBAU CSP-TPCBONDM CSP-TPCBONDP CSP-TPCBONDMO. */
            _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCDSBAU, CSP_REGISTRO.CSP_TPCBONDM, CSP_REGISTRO.CSP_TPCBONDP, CSP_REGISTRO.CSP_TPCBONDMO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_021_999_EXIT*/

        [StopWatch]
        /*" M-022-000-SELEC-BONUS-PLUS-DM-SECTION */
        private void M_022_000_SELEC_BONUS_PLUS_DM_SECTION()
        {
            /*" -1718- MOVE '022-000 - SELEC. PERC. POR BONUS PLUS' TO CSP-MSG. */
            _.Move("022-000 - SELEC. PERC. POR BONUS PLUS", CSP_RETORNO.CSP_MSG);

            /*" -1720- MOVE 7 TO BONAU-CODTAB */
            _.Move(7, CSP_RETORNO.BONAU_CODTAB);

            /*" -1721- MOVE CSP-CLABONDM TO BONAU-CLASSEBN */
            _.Move(CSP_REGISTRO.CSP_CLABONDM, CSP_RETORNO.BONAU_CLASSEBN);

            /*" -1722- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

            /*" -1723- PERFORM 025-000-LE-BONUS */

            M_025_000_LE_BONUS_SECTION();

            /*" -1724- MOVE BONAU-PCDESC TO CSP-TPCBONDM */
            _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCBONDM);

            /*" -1724- MOVE ZEROS TO CSP-TPCDSBAU. */
            _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_022_999_EXIT*/

        [StopWatch]
        /*" M-023-000-SELEC-BONUS-PLUS-DP-SECTION */
        private void M_023_000_SELEC_BONUS_PLUS_DP_SECTION()
        {
            /*" -1736- MOVE '023-000 - SELEC. PERC. POR BONUS PLUS' TO CSP-MSG. */
            _.Move("023-000 - SELEC. PERC. POR BONUS PLUS", CSP_RETORNO.CSP_MSG);

            /*" -1738- MOVE 7 TO BONAU-CODTAB */
            _.Move(7, CSP_RETORNO.BONAU_CODTAB);

            /*" -1739- MOVE CSP-CLABONDP TO BONAU-CLASSEBN */
            _.Move(CSP_REGISTRO.CSP_CLABONDP, CSP_RETORNO.BONAU_CLASSEBN);

            /*" -1740- MOVE WDATA-CHAR TO BONAU-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.BONAU_DTINIVIG);

            /*" -1741- PERFORM 025-000-LE-BONUS */

            M_025_000_LE_BONUS_SECTION();

            /*" -1742- MOVE BONAU-PCDESC TO CSP-TPCBONDP */
            _.Move(CSP_RETORNO.BONAU_PCDESC, CSP_REGISTRO.CSP_TPCBONDP);

            /*" -1742- MOVE ZEROS TO CSP-TPCDSBAU. */
            _.Move(0, CSP_REGISTRO.CSP_TPCDSBAU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_023_999_EXIT*/

        [StopWatch]
        /*" M-024-000-VERIF-FAIXA-BONUS-PLUS-SECTION */
        private void M_024_000_VERIF_FAIXA_BONUS_PLUS_SECTION()
        {
            /*" -1761- MOVE '024-000 -VERIF.FAIXA DE CLASSE BONUS ' TO CSP-MSG. */
            _.Move("024-000 -VERIF.FAIXA DE CLASSE BONUS ", CSP_RETORNO.CSP_MSG);

            /*" -1762- IF CSP-DTINIAUTO GREATER 19980930 */

            if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19980930)
            {

                /*" -1779- GO TO 024-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                return;
            }


            /*" -1780- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1781- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -1784- IF CSP-DTINIAUTO GREATER 19980131 AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19980131 && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -1785- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -1786- IF CSP-INDANO EQUAL ( 1 OR 2 OR 3 ) */

                            if (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3"))
                            {

                                /*" -1787- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -1788- MOVE 2 TO CSP-CLABONAT */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONAT);

                                /*" -1789- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -1790- ELSE */
                            }
                            else
                            {


                                /*" -1792- IF CSP-INDANO EQUAL ( 4 OR 5 OR 6 OR 7 OR 8 OR 9 OR 10 OR 11 ) */

                                if (CSP_REGISTRO.CSP_INDANO.In("4", "5", "6", "7", "8", "9", "10", "11"))
                                {

                                    /*" -1793- MOVE 'S' TO WS-TEMBONUS */
                                    _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                    /*" -1794- MOVE 1 TO CSP-CLABONAT */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONAT);

                                    /*" -1795- GO TO 024-999-EXIT */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                    return;

                                    /*" -1796- ELSE */
                                }
                                else
                                {


                                    /*" -1798- IF CSP-INDANO EQUAL (0 OR 2000 OR 1999 OR 1998) */

                                    if (CSP_REGISTRO.CSP_INDANO.In("0", "2000", "1999", "1998"))
                                    {

                                        /*" -1799- MOVE 'S' TO WS-TEMBONUS */
                                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                        /*" -1800- MOVE 2 TO CSP-CLABONAT */
                                        _.Move(2, CSP_REGISTRO.CSP_CLABONAT);

                                        /*" -1801- GO TO 024-999-EXIT */
                                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                        return;

                                        /*" -1802- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1805- IF CSP-INDANO EQUAL (1997 OR 1996 OR 1995 OR 1994 OR 1993 OR 1992 OR 1991 OR 1990) */

                                        if (CSP_REGISTRO.CSP_INDANO.In("1997", "1996", "1995", "1994", "1993", "1992", "1991", "1990"))
                                        {

                                            /*" -1806- MOVE 'S' TO WS-TEMBONUS */
                                            _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                            /*" -1807- MOVE 1 TO CSP-CLABONAT */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONAT);

                                            /*" -1824- GO TO 024-999-EXIT. */
                                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                            return;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1825- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1826- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -1829- IF CSP-DTINIAUTO GREATER 19970831 AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970831 && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -1830- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -1831- IF CSP-INDANO EQUAL ( 1 OR 2 OR 3 ) */

                            if (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3"))
                            {

                                /*" -1832- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -1833- MOVE 2 TO CSP-CLABONAT */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONAT);

                                /*" -1834- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -1835- ELSE */
                            }
                            else
                            {


                                /*" -1837- IF CSP-INDANO EQUAL ( 4 OR 5 OR 6 OR 7 OR 8 OR 9 OR 10 OR 11 ) */

                                if (CSP_REGISTRO.CSP_INDANO.In("4", "5", "6", "7", "8", "9", "10", "11"))
                                {

                                    /*" -1838- MOVE 'S' TO WS-TEMBONUS */
                                    _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                    /*" -1839- MOVE 1 TO CSP-CLABONAT */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONAT);

                                    /*" -1840- GO TO 024-999-EXIT */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                    return;

                                    /*" -1841- ELSE */
                                }
                                else
                                {


                                    /*" -1843- IF CSP-INDANO EQUAL (0 OR 2000 OR 1999 OR 1998) */

                                    if (CSP_REGISTRO.CSP_INDANO.In("0", "2000", "1999", "1998"))
                                    {

                                        /*" -1844- MOVE 'S' TO WS-TEMBONUS */
                                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                        /*" -1845- MOVE 2 TO CSP-CLABONAT */
                                        _.Move(2, CSP_REGISTRO.CSP_CLABONAT);

                                        /*" -1846- GO TO 024-999-EXIT */
                                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                        return;

                                        /*" -1847- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1850- IF CSP-INDANO EQUAL (1997 OR 1996 OR 1995 OR 1994 OR 1993 OR 1992 OR 1991 OR 1990) */

                                        if (CSP_REGISTRO.CSP_INDANO.In("1997", "1996", "1995", "1994", "1993", "1992", "1991", "1990"))
                                        {

                                            /*" -1851- MOVE 'S' TO WS-TEMBONUS */
                                            _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                            /*" -1852- MOVE 1 TO CSP-CLABONAT */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONAT);

                                            /*" -1861- GO TO 024-999-EXIT. */
                                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                            return;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1862- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1863- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -1867- IF CSP-DTINIAUTO GREATER 19970430 AND CSP-DTINIAUTO LESS 19970901 AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970430 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19970901 && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -1868- IF CSP-INDANO EQUAL ( 1 OR 2 OR 3 ) */

                        if (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3"))
                        {

                            /*" -1869- MOVE 'S' TO WS-TEMBONUS */
                            _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                            /*" -1870- MOVE 3 TO CSP-CLABONAT */
                            _.Move(3, CSP_REGISTRO.CSP_CLABONAT);

                            /*" -1871- GO TO 024-999-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                            return;

                            /*" -1872- ELSE */
                        }
                        else
                        {


                            /*" -1873- IF CSP-INDANO EQUAL ( 4 OR 5 OR 6 OR 7 ) */

                            if (CSP_REGISTRO.CSP_INDANO.In("4", "5", "6", "7"))
                            {

                                /*" -1874- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -1875- MOVE 1 TO CSP-CLABONAT */
                                _.Move(1, CSP_REGISTRO.CSP_CLABONAT);

                                /*" -1883- GO TO 024-999-EXIT. */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -1884- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1885- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -1888- IF CSP-DTINIAUTO GREATER 19970131 AND CSP-DTINIAUTO LESS 19970501 AND CSP-INDANO EQUAL 1 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19970501 && CSP_REGISTRO.CSP_INDANO == 1)
                    {

                        /*" -1889- MOVE 'S' TO WS-TEMBONUS */
                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                        /*" -1890- MOVE 3 TO CSP-CLABONAT */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONAT);

                        /*" -1910- GO TO 024-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1911- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1912- IF CSP-CLABONAT GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT > 00)
                {

                    /*" -1913- IF CSP-DTINIAUTO GREATER 19970831 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970831)
                    {

                        /*" -1914- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -1918- IF CSP-CLABONAT EQUAL 1 OR 2 AND (CSP-INDANO EQUAL 1 OR 2 OR 3) AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                            if (CSP_REGISTRO.CSP_CLABONAT.In("1", "2") && (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3")) && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                            {

                                /*" -1919- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -1920- MOVE 2 TO CSP-CLABONAT */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONAT);

                                /*" -1921- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -1922- END-IF */
                            }


                            /*" -1923- ELSE */
                        }
                        else
                        {


                            /*" -1928- IF CSP-CLABONAT EQUAL 1 OR 2 AND (CSP-INDANO EQUAL 0 OR 2000 OR 1999 OR 1998) AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                            if (CSP_REGISTRO.CSP_CLABONAT.In("1", "2") && (CSP_REGISTRO.CSP_INDANO.In("0", "2000", "1999", "1998")) && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                            {

                                /*" -1929- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -1930- MOVE 2 TO CSP-CLABONAT */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONAT);

                                /*" -1931- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -1940- END-IF. */
                            }

                        }

                    }

                }

            }


            /*" -1941- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1942- IF CSP-CLABONAT GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT > 00)
                {

                    /*" -1948- IF CSP-DTINIAUTO GREATER 19970430 AND CSP-DTINIAUTO LESS 19970901 AND (CSP-CLABONAT EQUAL 1 OR 2 OR 3) AND (CSP-INDANO EQUAL 1 OR 2 OR 3) AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970430 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19970901 && (CSP_REGISTRO.CSP_CLABONAT.In("1", "2", "3")) && (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3")) && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -1949- MOVE 'S' TO WS-TEMBONUS */
                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                        /*" -1950- MOVE 3 TO CSP-CLABONAT */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONAT);

                        /*" -1959- GO TO 024-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1960- IF CSP-TIPOCOB EQUAL 1 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 1)
            {

                /*" -1961- IF CSP-CLABONAT GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT > 00)
                {

                    /*" -1965- IF CSP-DTINIAUTO GREATER 19970131 AND CSP-DTINIAUTO LESS 19970501 AND (CSP-CLABONAT EQUAL 1 OR 2 OR 3) AND CSP-INDANO EQUAL 1 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19970501 && (CSP_REGISTRO.CSP_CLABONAT.In("1", "2", "3")) && CSP_REGISTRO.CSP_INDANO == 1)
                    {

                        /*" -1966- MOVE 'S' TO WS-TEMBONUS */
                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                        /*" -1967- MOVE 3 TO CSP-CLABONAT */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONAT);

                        /*" -1978- GO TO 024-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1979- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -1980- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -1983- IF CSP-DTINIAUTO GREATER 19970430 AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970430 && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -1984- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -1985- IF CSP-INDANO EQUAL ( 1 OR 2 OR 3 ) */

                            if (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3"))
                            {

                                /*" -1986- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -1987- MOVE 2 TO CSP-CLABONDM */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDM);

                                /*" -1988- MOVE 2 TO CSP-CLABONDP */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDP);

                                /*" -1989- MOVE 2 TO CSP-CLABONDMO */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDMO);

                                /*" -1990- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -1991- ELSE */
                            }
                            else
                            {


                                /*" -1993- IF CSP-INDANO EQUAL ( 4 OR 5 OR 6 OR 7 OR 8 OR 9 OR 10 OR 11 ) */

                                if (CSP_REGISTRO.CSP_INDANO.In("4", "5", "6", "7", "8", "9", "10", "11"))
                                {

                                    /*" -1994- MOVE 'S' TO WS-TEMBONUS */
                                    _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                    /*" -1995- MOVE 1 TO CSP-CLABONDM */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONDM);

                                    /*" -1996- MOVE 1 TO CSP-CLABONDP */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONDP);

                                    /*" -1997- MOVE 1 TO CSP-CLABONDMO */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONDMO);

                                    /*" -1998- GO TO 024-999-EXIT */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                    return;

                                    /*" -1999- ELSE */
                                }
                                else
                                {


                                    /*" -2001- IF CSP-INDANO EQUAL (0 OR 2000 OR 1999 OR 1998) */

                                    if (CSP_REGISTRO.CSP_INDANO.In("0", "2000", "1999", "1998"))
                                    {

                                        /*" -2002- MOVE 'S' TO WS-TEMBONUS */
                                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                        /*" -2003- MOVE 2 TO CSP-CLABONDM */
                                        _.Move(2, CSP_REGISTRO.CSP_CLABONDM);

                                        /*" -2004- MOVE 2 TO CSP-CLABONDP */
                                        _.Move(2, CSP_REGISTRO.CSP_CLABONDP);

                                        /*" -2005- MOVE 2 TO CSP-CLABONDMO */
                                        _.Move(2, CSP_REGISTRO.CSP_CLABONDMO);

                                        /*" -2006- GO TO 024-999-EXIT */
                                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                        return;

                                        /*" -2007- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2010- IF CSP-INDANO EQUAL (1997 OR 1996 OR 1995 OR 1994 OR 1993 OR 1992 OR 1991) */

                                        if (CSP_REGISTRO.CSP_INDANO.In("1997", "1996", "1995", "1994", "1993", "1992", "1991"))
                                        {

                                            /*" -2011- MOVE 'S' TO WS-TEMBONUS */
                                            _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                            /*" -2012- MOVE 1 TO CSP-CLABONDM */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONDM);

                                            /*" -2013- MOVE 1 TO CSP-CLABONDP */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONDP);

                                            /*" -2014- MOVE 1 TO CSP-CLABONDMO */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONDMO);

                                            /*" -2023- GO TO 024-999-EXIT. */
                                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                            return;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -2024- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -2025- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -2028- IF CSP-DTINIAUTO GREATER 19970430 AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970430 && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -2029- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -2030- IF CSP-INDANO EQUAL ( 1 OR 2 OR 3 ) */

                            if (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3"))
                            {

                                /*" -2031- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -2032- MOVE 3 TO CSP-CLABONDM */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDM);

                                /*" -2033- MOVE 3 TO CSP-CLABONDP */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDP);

                                /*" -2034- MOVE 3 TO CSP-CLABONDMO */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDMO);

                                /*" -2035- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -2036- ELSE */
                            }
                            else
                            {


                                /*" -2037- IF CSP-INDANO EQUAL ( 4 OR 5 OR 6 OR 7 ) */

                                if (CSP_REGISTRO.CSP_INDANO.In("4", "5", "6", "7"))
                                {

                                    /*" -2038- MOVE 'S' TO WS-TEMBONUS */
                                    _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                    /*" -2039- MOVE 1 TO CSP-CLABONDM */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONDM);

                                    /*" -2040- MOVE 1 TO CSP-CLABONDP */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONDP);

                                    /*" -2041- MOVE 1 TO CSP-CLABONDMO */
                                    _.Move(1, CSP_REGISTRO.CSP_CLABONDMO);

                                    /*" -2042- GO TO 024-999-EXIT */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                    return;

                                    /*" -2043- ELSE */
                                }
                                else
                                {


                                    /*" -2045- IF CSP-INDANO EQUAL ( 0 OR 2000 OR 1999 OR 1998 ) */

                                    if (CSP_REGISTRO.CSP_INDANO.In("0", "2000", "1999", "1998"))
                                    {

                                        /*" -2046- MOVE 'S' TO WS-TEMBONUS */
                                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                        /*" -2047- MOVE 3 TO CSP-CLABONDM */
                                        _.Move(3, CSP_REGISTRO.CSP_CLABONDM);

                                        /*" -2048- MOVE 3 TO CSP-CLABONDP */
                                        _.Move(3, CSP_REGISTRO.CSP_CLABONDP);

                                        /*" -2049- MOVE 3 TO CSP-CLABONDMO */
                                        _.Move(3, CSP_REGISTRO.CSP_CLABONDMO);

                                        /*" -2050- GO TO 024-999-EXIT */
                                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                        return;

                                        /*" -2051- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2053- IF CSP-INDANO EQUAL ( 1997 OR 1996 OR 1995 OR 1994 ) */

                                        if (CSP_REGISTRO.CSP_INDANO.In("1997", "1996", "1995", "1994"))
                                        {

                                            /*" -2054- MOVE 'S' TO WS-TEMBONUS */
                                            _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                            /*" -2055- MOVE 1 TO CSP-CLABONDM */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONDM);

                                            /*" -2056- MOVE 1 TO CSP-CLABONDP */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONDP);

                                            /*" -2057- MOVE 1 TO CSP-CLABONDMO */
                                            _.Move(1, CSP_REGISTRO.CSP_CLABONDMO);

                                            /*" -2065- GO TO 024-999-EXIT. */
                                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                            return;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -2066- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -2067- IF CSP-CLABONAT EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT == 00)
                {

                    /*" -2068- IF CSP-DTINIAUTO GREATER 19970131 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131)
                    {

                        /*" -2069- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -2070- IF CSP-INDANO EQUAL 1 */

                            if (CSP_REGISTRO.CSP_INDANO == 1)
                            {

                                /*" -2071- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -2072- MOVE 3 TO CSP-CLABONDM */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDM);

                                /*" -2073- MOVE 3 TO CSP-CLABONDP */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDP);

                                /*" -2074- MOVE 3 TO CSP-CLABONDMO */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDMO);

                                /*" -2075- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -2076- END-IF */
                            }


                            /*" -2077- ELSE */
                        }
                        else
                        {


                            /*" -2078- IF CSP-INDANO EQUAL 0 */

                            if (CSP_REGISTRO.CSP_INDANO == 0)
                            {

                                /*" -2079- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -2080- MOVE 3 TO CSP-CLABONDM */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDM);

                                /*" -2081- MOVE 3 TO CSP-CLABONDP */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDP);

                                /*" -2082- MOVE 3 TO CSP-CLABONDMO */
                                _.Move(3, CSP_REGISTRO.CSP_CLABONDMO);

                                /*" -2083- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -2104- END-IF. */
                            }

                        }

                    }

                }

            }


            /*" -2105- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -2106- IF CSP-CLABONAT GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT > 00)
                {

                    /*" -2107- IF CSP-DTINIAUTO GREATER 19970831 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970831)
                    {

                        /*" -2108- IF CSP-DTINIAUTO LESS 19990701 */

                        if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19990701)
                        {

                            /*" -2112- IF CSP-CLABONAT EQUAL 1 OR 2 AND (CSP-INDANO EQUAL 1 OR 2 OR 3) AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                            if (CSP_REGISTRO.CSP_CLABONAT.In("1", "2") && (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3")) && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                            {

                                /*" -2113- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -2114- MOVE 2 TO CSP-CLABONDM */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDM);

                                /*" -2115- MOVE 2 TO CSP-CLABONDP */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDP);

                                /*" -2116- MOVE 2 TO CSP-CLABONDMO */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDMO);

                                /*" -2117- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -2118- END-IF */
                            }


                            /*" -2119- ELSE */
                        }
                        else
                        {


                            /*" -2124- IF CSP-CLABONAT EQUAL 1 OR 2 AND (CSP-INDANO EQUAL 0 OR 2000 OR 1999 OR 1998) AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                            if (CSP_REGISTRO.CSP_CLABONAT.In("1", "2") && (CSP_REGISTRO.CSP_INDANO.In("0", "2000", "1999", "1998")) && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                            {

                                /*" -2125- MOVE 'S' TO WS-TEMBONUS */
                                _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                                /*" -2126- MOVE 2 TO CSP-CLABONDM */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDM);

                                /*" -2127- MOVE 2 TO CSP-CLABONDP */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDP);

                                /*" -2128- MOVE 2 TO CSP-CLABONDMO */
                                _.Move(2, CSP_REGISTRO.CSP_CLABONDMO);

                                /*" -2129- GO TO 024-999-EXIT */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                                return;

                                /*" -2138- END-IF. */
                            }

                        }

                    }

                }

            }


            /*" -2139- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -2140- IF CSP-CLABONAT GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT > 00)
                {

                    /*" -2146- IF CSP-DTINIAUTO GREATER 19970430 AND CSP-DTINIAUTO LESS 19970901 AND (CSP-CLABONAT EQUAL 1 OR 2 OR 3) AND (CSP-INDANO EQUAL 1 OR 2 OR 3) AND CSP-CATTARIO EQUAL ( 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 20 OR 21 OR 22 OR 23 ) */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970430 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19970901 && (CSP_REGISTRO.CSP_CLABONAT.In("1", "2", "3")) && (CSP_REGISTRO.CSP_INDANO.In("1", "2", "3")) && CSP_REGISTRO.CSP_CATTARIO.In("10", "11", "14", "15", "16", "17", "20", "21", "22", "23"))
                    {

                        /*" -2147- MOVE 'S' TO WS-TEMBONUS */
                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                        /*" -2148- MOVE 3 TO CSP-CLABONDM */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONDM);

                        /*" -2149- MOVE 3 TO CSP-CLABONDP */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONDP);

                        /*" -2150- MOVE 3 TO CSP-CLABONDMO */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONDMO);

                        /*" -2159- GO TO 024-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -2160- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -2161- IF CSP-CLABONAT GREATER ZEROS */

                if (CSP_REGISTRO.CSP_CLABONAT > 00)
                {

                    /*" -2165- IF CSP-DTINIAUTO GREATER 19970131 AND CSP-DTINIAUTO LESS 19970501 AND (CSP-CLABONAT EQUAL 1 OR 2 OR 3) AND CSP-INDANO EQUAL 1 */

                    if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19970131 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19970501 && (CSP_REGISTRO.CSP_CLABONAT.In("1", "2", "3")) && CSP_REGISTRO.CSP_INDANO == 1)
                    {

                        /*" -2166- MOVE 'S' TO WS-TEMBONUS */
                        _.Move("S", CSP_RETORNO.WS_TEMBONUS);

                        /*" -2167- MOVE 3 TO CSP-CLABONDM */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONDM);

                        /*" -2168- MOVE 3 TO CSP-CLABONDP */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONDP);

                        /*" -2169- MOVE 3 TO CSP-CLABONDMO */
                        _.Move(3, CSP_REGISTRO.CSP_CLABONDMO);

                        /*" -2169- GO TO 024-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_024_999_EXIT*/

        [StopWatch]
        /*" M-025-000-LE-BONUS-SECTION */
        private void M_025_000_LE_BONUS_SECTION()
        {
            /*" -2182- MOVE '025-000 - LE- BONUS                     ' TO CSP-MSG. */
            _.Move("025-000 - LE- BONUS                     ", CSP_RETORNO.CSP_MSG);

            /*" -2191- PERFORM M_025_000_LE_BONUS_DB_SELECT_1 */

            M_025_000_LE_BONUS_DB_SELECT_1();

            /*" -2194- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2195- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2196- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2197- ELSE */
            }
            else
            {


                /*" -2198- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2199- MOVE '025-000' TO CSP-PROCPAR */
                    _.Move("025-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2200- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2200- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-025-000-LE-BONUS-DB-SELECT-1 */
        public void M_025_000_LE_BONUS_DB_SELECT_1()
        {
            /*" -2191- EXEC SQL SELECT PCDESC INTO :BONAU-PCDESC FROM SEGUROS.V1BONAUTO WHERE CODTAB = :BONAU-CODTAB AND CLASSEBN = :BONAU-CLASSEBN AND DTINIVIG <= :BONAU-DTINIVIG AND DTTERVIG >= :BONAU-DTINIVIG END-EXEC. */

            var m_025_000_LE_BONUS_DB_SELECT_1_Query1 = new M_025_000_LE_BONUS_DB_SELECT_1_Query1()
            {
                BONAU_CLASSEBN = CSP_RETORNO.BONAU_CLASSEBN.ToString(),
                BONAU_DTINIVIG = CSP_RETORNO.BONAU_DTINIVIG.ToString(),
                BONAU_CODTAB = CSP_RETORNO.BONAU_CODTAB.ToString(),
            };

            var executed_1 = M_025_000_LE_BONUS_DB_SELECT_1_Query1.Execute(m_025_000_LE_BONUS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BONAU_PCDESC, CSP_RETORNO.BONAU_PCDESC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_025_999_EXIT*/

        [StopWatch]
        /*" M-030-000-TRATA-FROBR-SECTION */
        private void M_030_000_TRATA_FROBR_SECTION()
        {
            /*" -2216- MOVE '030-000 - TRATA-FROBR  ' TO CSP-MSG. */
            _.Move("030-000 - TRATA-FROBR  ", CSP_RETORNO.CSP_MSG);

            /*" -2217- IF CSP-CFFROBR EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_CFFROBR == 00)
            {

                /*" -2218- MOVE 16 TO CATTF-CODTAB */
                _.Move(16, CSP_RETORNO.CATTF_CODTAB);

                /*" -2219- MOVE ZEROS TO CATTF-CODPRODU */
                _.Move(0, CSP_RETORNO.CATTF_CODPRODU);

                /*" -2220- MOVE CSP-CATTARIO TO CATTF-CATTARIF */
                _.Move(CSP_REGISTRO.CSP_CATTARIO, CSP_RETORNO.CATTF_CATTARIF);

                /*" -2221- MOVE WDATA-CHAR TO CATTF-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.CATTF_DTINIVIG);

                /*" -2222- PERFORM 035-000-PESQ-FRANQOBR */

                M_035_000_PESQ_FRANQOBR_SECTION();

                /*" -2223- MOVE CATTF-VLPRTXCF TO CSP-TCFFROBR */
                _.Move(CSP_RETORNO.CATTF_VLPRTXCF, CSP_REGISTRO.CSP_TCFFROBR);

                /*" -2224- ELSE */
            }
            else
            {


                /*" -2230- MOVE CSP-CFFROBR TO CSP-TCFFROBR. */
                _.Move(CSP_REGISTRO.CSP_CFFROBR, CSP_REGISTRO.CSP_TCFFROBR);
            }


            /*" -2231- COMPUTE CSP-VRISFROB ROUNDED = CSP-VRPRREF * CSP-TCFFROBR. */
            CSP_REGISTRO.CSP_VRISFROB.Value = CSP_REGISTRO.CSP_VRPRREF * CSP_REGISTRO.CSP_TCFFROBR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-035-000-PESQ-FRANQOBR-SECTION */
        private void M_035_000_PESQ_FRANQOBR_SECTION()
        {
            /*" -2240- MOVE '035-000 - PESQ-FRANQOBR' TO CSP-MSG. */
            _.Move("035-000 - PESQ-FRANQOBR", CSP_RETORNO.CSP_MSG);

            /*" -2249- PERFORM M_035_000_PESQ_FRANQOBR_DB_SELECT_1 */

            M_035_000_PESQ_FRANQOBR_DB_SELECT_1();

            /*" -2252- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2253- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2254- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2255- ELSE */
            }
            else
            {


                /*" -2256- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2257- MOVE '035-000' TO CSP-PROCPAR */
                    _.Move("035-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2258- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2258- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-035-000-PESQ-FRANQOBR-DB-SELECT-1 */
        public void M_035_000_PESQ_FRANQOBR_DB_SELECT_1()
        {
            /*" -2249- EXEC SQL SELECT VLPRTXCF INTO :CATTF-VLPRTXCF FROM SEGUROS.V1CATTARIFA WHERE CODTAB = :CATTF-CODTAB AND CODPRODU = :CATTF-CODPRODU AND CATTARIF = :CATTF-CATTARIF AND DTINIVIG <= :CATTF-DTINIVIG AND DTTERVIG >= :CATTF-DTINIVIG END-EXEC. */

            var m_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1 = new M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1()
            {
                CATTF_CODPRODU = CSP_RETORNO.CATTF_CODPRODU.ToString(),
                CATTF_CATTARIF = CSP_RETORNO.CATTF_CATTARIF.ToString(),
                CATTF_DTINIVIG = CSP_RETORNO.CATTF_DTINIVIG.ToString(),
                CATTF_CODTAB = CSP_RETORNO.CATTF_CODTAB.ToString(),
            };

            var executed_1 = M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1.Execute(m_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CATTF_VLPRTXCF, CSP_RETORNO.CATTF_VLPRTXCF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_035_999_EXIT*/

        [StopWatch]
        /*" M-040-000-TRATA-FRFACC-SECTION */
        private void M_040_000_TRATA_FRFACC_SECTION()
        {
            /*" -2272- MOVE '040-000 - TRATA-FRFACC ' TO CSP-MSG. */
            _.Move("040-000 - TRATA-FRFACC ", CSP_RETORNO.CSP_MSG);

            /*" -2273- IF CSP-DTINIVIG LESS 19981231 */

            if (CSP_REGISTRO.CSP_DTINIVIG.GetMoveValues().ToInt() < 19981231)
            {

                /*" -2274- IF CSP-CLAFRFAC EQUAL 1 */

                if (CSP_REGISTRO.CSP_CLAFRFAC == 1)
                {

                    /*" -2275- MOVE ZEROS TO CSP-VRISFRCA */
                    _.Move(0, CSP_REGISTRO.CSP_VRISFRCA);

                    /*" -2276- GO TO 040-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/ //GOTO
                    return;

                    /*" -2277- ELSE */
                }
                else
                {


                    /*" -2278- MOVE ZEROS TO CSP-TCFFROBR */
                    _.Move(0, CSP_REGISTRO.CSP_TCFFROBR);

                    /*" -2279- MOVE ZEROS TO CSP-VRISFROB */
                    _.Move(0, CSP_REGISTRO.CSP_VRISFROB);

                    /*" -2280- IF CSP-CFFRFACC EQUAL 2 OR 3 */

                    if (CSP_REGISTRO.CSP_CFFRFACC.In("2", "3"))
                    {

                        /*" -2281- MOVE CSP-CFFRFACC TO CSP-TCFFRFCC */
                        _.Move(CSP_REGISTRO.CSP_CFFRFACC, CSP_REGISTRO.CSP_TCFFRFCC);

                        /*" -2282- ELSE */
                    }
                    else
                    {


                        /*" -2283- IF CSP-CFFRFACC EQUAL 4 */

                        if (CSP_REGISTRO.CSP_CFFRFACC == 4)
                        {

                            /*" -2284- MOVE 0,5 TO CSP-TCFFRFCC */
                            _.Move(0.5, CSP_REGISTRO.CSP_TCFFRFCC);

                            /*" -2285- ELSE */
                        }
                        else
                        {


                            /*" -2286- MOVE 1 TO FRFAC-CODTAB */
                            _.Move(1, CSP_RETORNO.FRFAC_CODTAB);

                            /*" -2287- MOVE CSP-CLAFRFAC TO FRFAC-CLASSEFR */
                            _.Move(CSP_REGISTRO.CSP_CLAFRFAC, CSP_RETORNO.FRFAC_CLASSEFR);

                            /*" -2288- MOVE WDATA-CHAR TO FRFAC-DTINIVIG */
                            _.Move(WDATA_CHAR, CSP_RETORNO.FRFAC_DTINIVIG);

                            /*" -2290- MOVE 'COEFICIENTE DE FRANQUIA FACULTATIVA - (CASCO)' TO CSP-LIT */
                            _.Move("COEFICIENTE DE FRANQUIA FACULTATIVA - (CASCO)", CSP_RETORNO.CSP_MSG.CSP_LIT);

                            /*" -2291- PERFORM 072-000-PESQ-V1FRANQFAC */

                            M_072_000_PESQ_V1FRANQFAC_SECTION();

                            /*" -2292- MOVE FRFAC-PCDESC TO CSP-TCFFRFCC */
                            _.Move(CSP_RETORNO.FRFAC_PCDESC, CSP_REGISTRO.CSP_TCFFRFCC);

                            /*" -2293- ELSE */
                        }

                    }

                }

            }
            else
            {


                /*" -2294- IF CSP-CLAFRFAC EQUAL 2 */

                if (CSP_REGISTRO.CSP_CLAFRFAC == 2)
                {

                    /*" -2295- MOVE ZEROS TO CSP-VRISFRCA */
                    _.Move(0, CSP_REGISTRO.CSP_VRISFRCA);

                    /*" -2296- GO TO 040-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/ //GOTO
                    return;

                    /*" -2297- ELSE */
                }
                else
                {


                    /*" -2298- MOVE ZEROS TO CSP-TCFFROBR */
                    _.Move(0, CSP_REGISTRO.CSP_TCFFROBR);

                    /*" -2299- MOVE ZEROS TO CSP-VRISFROB */
                    _.Move(0, CSP_REGISTRO.CSP_VRISFROB);

                    /*" -2300- IF CSP-CLAFRFAC EQUAL 3 OR 4 */

                    if (CSP_REGISTRO.CSP_CLAFRFAC.In("3", "4"))
                    {

                        /*" -2301- MOVE CSP-CFFRFACC TO CSP-TCFFRFCC */
                        _.Move(CSP_REGISTRO.CSP_CFFRFACC, CSP_REGISTRO.CSP_TCFFRFCC);

                        /*" -2302- ELSE */
                    }
                    else
                    {


                        /*" -2303- IF CSP-CLAFRFAC EQUAL 1 */

                        if (CSP_REGISTRO.CSP_CLAFRFAC == 1)
                        {

                            /*" -2304- MOVE 0,5 TO CSP-TCFFRFCC */
                            _.Move(0.5, CSP_REGISTRO.CSP_TCFFRFCC);

                            /*" -2305- ELSE */
                        }
                        else
                        {


                            /*" -2306- MOVE 1 TO FRFAC-CODTAB */
                            _.Move(1, CSP_RETORNO.FRFAC_CODTAB);

                            /*" -2307- MOVE CSP-CLAFRFAC TO FRFAC-CLASSEFR */
                            _.Move(CSP_REGISTRO.CSP_CLAFRFAC, CSP_RETORNO.FRFAC_CLASSEFR);

                            /*" -2308- MOVE WDATA-CHAR TO FRFAC-DTINIVIG */
                            _.Move(WDATA_CHAR, CSP_RETORNO.FRFAC_DTINIVIG);

                            /*" -2310- MOVE 'COEFICIENTE DE FRANQUIA FACULTATIVA - (CASCO)' TO CSP-LIT */
                            _.Move("COEFICIENTE DE FRANQUIA FACULTATIVA - (CASCO)", CSP_RETORNO.CSP_MSG.CSP_LIT);

                            /*" -2311- PERFORM 072-000-PESQ-V1FRANQFAC */

                            M_072_000_PESQ_V1FRANQFAC_SECTION();

                            /*" -2317- MOVE FRFAC-PCDESC TO CSP-TCFFRFCC. */
                            _.Move(CSP_RETORNO.FRFAC_PCDESC, CSP_REGISTRO.CSP_TCFFRFCC);
                        }

                    }

                }

            }


            /*" -2318- COMPUTE CSP-VRISFRCA = CSP-VRPRREF * CSP-TCFFRFCC. */
            CSP_REGISTRO.CSP_VRISFRCA.Value = CSP_REGISTRO.CSP_VRPRREF * CSP_REGISTRO.CSP_TCFFRFCC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/

        [StopWatch]
        /*" M-050-000-TRATA-PCFRADIC-SECTION */
        private void M_050_000_TRATA_PCFRADIC_SECTION()
        {
            /*" -2333- MOVE '050-000 - TRATA-PCFRADI' TO CSP-MSG. */
            _.Move("050-000 - TRATA-PCFRADI", CSP_RETORNO.CSP_MSG);

            /*" -2334- IF CSP-PCFRADIC NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_PCFRADIC != 00)
            {

                /*" -2335- COMPUTE CSP-VRISFRAD = CSP-VRPRREF * CSP-PCFRADIC. */
                CSP_REGISTRO.CSP_VRISFRAD.Value = CSP_REGISTRO.CSP_VRPRREF * CSP_REGISTRO.CSP_PCFRADIC;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_050_999_EXIT*/

        [StopWatch]
        /*" M-060-000-TRATA-FRFACA-SECTION */
        private void M_060_000_TRATA_FRFACA_SECTION()
        {
            /*" -2348- MOVE '060-000 - TRATA-FRFACA ' TO CSP-MSG. */
            _.Move("060-000 - TRATA-FRFACA ", CSP_RETORNO.CSP_MSG);

            /*" -2349- IF CSP-VRISACCA EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISACCA == 00)
            {

                /*" -2350- MOVE ZEROS TO CSP-VRISFRAC */
                _.Move(0, CSP_REGISTRO.CSP_VRISFRAC);

                /*" -2352- GO TO 060-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/ //GOTO
                return;
            }


            /*" -2353- IF CSP-CFFRFACA GREATER ZEROS */

            if (CSP_REGISTRO.CSP_CFFRFACA > 00)
            {

                /*" -2354- MOVE CSP-CFFRFACA TO CSP-TCFFRFCA */
                _.Move(CSP_REGISTRO.CSP_CFFRFACA, CSP_REGISTRO.CSP_TCFFRFCA);

                /*" -2355- ELSE */
            }
            else
            {


                /*" -2356- MOVE 3 TO FRFAC-CODTAB */
                _.Move(3, CSP_RETORNO.FRFAC_CODTAB);

                /*" -2357- MOVE CSP-CLAFRFAC TO FRFAC-CLASSEFR */
                _.Move(CSP_REGISTRO.CSP_CLAFRFAC, CSP_RETORNO.FRFAC_CLASSEFR);

                /*" -2358- MOVE WDATA-CHAR TO FRFAC-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.FRFAC_DTINIVIG);

                /*" -2360- MOVE 'COEFICIENTE FRANQUIA FACULTATIVA - (ACESSORIO)' TO CSP-LIT */
                _.Move("COEFICIENTE FRANQUIA FACULTATIVA - (ACESSORIO)", CSP_RETORNO.CSP_MSG.CSP_LIT);

                /*" -2361- PERFORM 072-000-PESQ-V1FRANQFAC */

                M_072_000_PESQ_V1FRANQFAC_SECTION();

                /*" -2363- MOVE FRFAC-PCDESC TO CSP-TCFFRFCA. */
                _.Move(CSP_RETORNO.FRFAC_PCDESC, CSP_REGISTRO.CSP_TCFFRFCA);
            }


            /*" -2364- COMPUTE CSP-VRISFRAC = CSP-VRISACCA * CSP-TCFFRFCA. */
            CSP_REGISTRO.CSP_VRISFRAC.Value = CSP_REGISTRO.CSP_VRISACCA * CSP_REGISTRO.CSP_TCFFRFCA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-CALCULA-PREMIO-CASCO-SECTION */
        private void M_070_000_CALCULA_PREMIO_CASCO_SECTION()
        {
            /*" -2372- MOVE '070-000 - CALCULA PREMIO CASCO' TO CSP-MSG. */
            _.Move("070-000 - CALCULA PREMIO CASCO", CSP_RETORNO.CSP_MSG);

            /*" -0- FLUXCONTROL_PERFORM M_070_010_APLICA_TAXAS */

            M_070_010_APLICA_TAXAS();

        }

        [StopWatch]
        /*" M-070-010-APLICA-TAXAS */
        private void M_070_010_APLICA_TAXAS(bool isPerform = false)
        {
            /*" -2384- IF CSP-ADIC-VLR-MERC EQUAL 'S' */

            if (CSP_REGISTRO.CSP_ADIC_VLR_MERC == "S")
            {

                /*" -2385- IF TAXAC-VERSAO GREATER 201 */

                if (CSP_RETORNO.TAXAC_VERSAO > 201)
                {

                    /*" -2391- COMPUTE CSP-VRPLACAS ROUNDED = ((CSP-VRISCASC * 1,20) * CSP-TTXAPLIS / 100 * (100 - CSP-PCREDTAX) / 100 * (100 - CSP-TPCDSBAU) / 100) */
                    CSP_REGISTRO.CSP_VRPLACAS.Value = ((CSP_REGISTRO.CSP_VRISCASC * 1.20) * CSP_REGISTRO.CSP_TTXAPLIS / 100f * (100 - CSP_REGISTRO.CSP_PCREDTAX) / 100f * (100 - CSP_REGISTRO.CSP_TPCDSBAU) / 100f);

                    /*" -2392- ELSE */
                }
                else
                {


                    /*" -2398- COMPUTE CSP-VRPLACAS ROUNDED = ((CSP-VRISCASC * 1,14) * CSP-TTXAPLIS / 100 * (100 - CSP-PCREDTAX) / 100 * (100 - CSP-TPCDSBAU) / 100) */
                    CSP_REGISTRO.CSP_VRPLACAS.Value = ((CSP_REGISTRO.CSP_VRISCASC * 1.14) * CSP_REGISTRO.CSP_TTXAPLIS / 100f * (100 - CSP_REGISTRO.CSP_PCREDTAX) / 100f * (100 - CSP_REGISTRO.CSP_TPCDSBAU) / 100f);

                    /*" -2399- END-IF */
                }


                /*" -2400- ELSE */
            }
            else
            {


                /*" -2407- COMPUTE CSP-VRPLACAS ROUNDED = CSP-VRISCASC * CSP-TTXAPLIS / 100 * (100 - CSP-PCREDTAX) / 100 * (100 - CSP-TPCDSBAU) / 100. */
                CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRISCASC * CSP_REGISTRO.CSP_TTXAPLIS / 100f * (100 - CSP_REGISTRO.CSP_PCREDTAX) / 100f * (100 - CSP_REGISTRO.CSP_TPCDSBAU) / 100f;
            }


            /*" -2407- PERFORM 070-020-APLICA-DESC-FRANQUIA. */

            M_070_020_APLICA_DESC_FRANQUIA(true);

        }

        [StopWatch]
        /*" M-070-020-APLICA-DESC-FRANQUIA */
        private void M_070_020_APLICA_DESC_FRANQUIA(bool isPerform = false)
        {
            /*" -2421- IF CSP-CLAFRFAC LESS 2 */

            if (CSP_REGISTRO.CSP_CLAFRFAC < 2)
            {

                /*" -2422- MOVE 1 TO CSP-TPCDSFRF */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);

                /*" -2423- ELSE */
            }
            else
            {


                /*" -2424- IF CSP-CLAFRFAC EQUAL 2 */

                if (CSP_REGISTRO.CSP_CLAFRFAC == 2)
                {

                    /*" -2425- IF CSP-REGIAO EQUAL 18 OR 6 OR 11 OR 12 */

                    if (CSP_REGISTRO.CSP_REGIAO.In("18", "6", "11", "12"))
                    {

                        /*" -2426- MOVE 0,95 TO CSP-TPCDSFRF */
                        _.Move(0.95, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2427- ELSE */
                    }
                    else
                    {


                        /*" -2428- MOVE 0,93 TO CSP-TPCDSFRF */
                        _.Move(0.93, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2429- ELSE */
                    }

                }
                else
                {


                    /*" -2430- IF CSP-CLAFRFAC EQUAL 3 */

                    if (CSP_REGISTRO.CSP_CLAFRFAC == 3)
                    {

                        /*" -2431- IF CSP-REGIAO EQUAL 18 OR 6 OR 11 OR 12 */

                        if (CSP_REGISTRO.CSP_REGIAO.In("18", "6", "11", "12"))
                        {

                            /*" -2432- MOVE 0,9 TO CSP-TPCDSFRF */
                            _.Move(0.9, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2433- ELSE */
                        }
                        else
                        {


                            /*" -2434- MOVE 0,85 TO CSP-TPCDSFRF */
                            _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2435- ELSE */
                        }

                    }
                    else
                    {


                        /*" -2436- IF CSP-CLAFRFAC EQUAL 4 */

                        if (CSP_REGISTRO.CSP_CLAFRFAC == 4)
                        {

                            /*" -2437- IF CSP-REGIAO EQUAL 18 OR 6 OR 11 OR 12 */

                            if (CSP_REGISTRO.CSP_REGIAO.In("18", "6", "11", "12"))
                            {

                                /*" -2438- MOVE 1,15 TO CSP-TPCDSFRF */
                                _.Move(1.15, CSP_REGISTRO.CSP_TPCDSFRF);

                                /*" -2439- ELSE */
                            }
                            else
                            {


                                /*" -2440- MOVE 1,35 TO CSP-TPCDSFRF */
                                _.Move(1.35, CSP_REGISTRO.CSP_TPCDSFRF);

                                /*" -2441- ELSE */
                            }

                        }
                        else
                        {


                            /*" -2444- MOVE 1 TO CSP-TPCDSFRF. */
                            _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
                        }

                    }

                }

            }


            /*" -2445- IF CSP-DTINIAUTO LESS 19981001 */

            if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19981001)
            {

                /*" -2452- GO TO 070-025-APLICA-DESC-FRANQUIA. */

                M_070_025_APLICA_DESC_FRANQUIA(); //GOTO
                return;
            }


            /*" -2453- IF CSP-CLAFRFAC LESS 2 */

            if (CSP_REGISTRO.CSP_CLAFRFAC < 2)
            {

                /*" -2455- MOVE 1 TO CSP-TPCDSFRF. */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
            }


            /*" -2456- IF CSP-CLAFRFAC EQUAL 2 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 2)
            {

                /*" -2458- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22"))
                {

                    /*" -2459- MOVE 0,90 TO CSP-TPCDSFRF */
                    _.Move(0.90, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2460- ELSE */
                }
                else
                {


                    /*" -2461- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2462- MOVE 0,85 TO CSP-TPCDSFRF */
                        _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2463- ELSE */
                    }
                    else
                    {


                        /*" -2465- IF CSP-CATTARIO EQUAL ( 11 OR 15 OR 17 OR 21 OR 23 OR 91 ) */

                        if (CSP_REGISTRO.CSP_CATTARIO.In("11", "15", "17", "21", "23", "91"))
                        {

                            /*" -2466- MOVE 0,90 TO CSP-TPCDSFRF */
                            _.Move(0.90, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2467- ELSE */
                        }
                        else
                        {


                            /*" -2469- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2471- MOVE 0,92 TO CSP-TPCDSFRF. */
                                _.Move(0.92, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2472- IF CSP-CLAFRFAC EQUAL 3 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 3)
            {

                /*" -2474- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22"))
                {

                    /*" -2475- MOVE 0,75 TO CSP-TPCDSFRF */
                    _.Move(0.75, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2476- ELSE */
                }
                else
                {


                    /*" -2477- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2478- MOVE 0,65 TO CSP-TPCDSFRF */
                        _.Move(0.65, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2479- ELSE */
                    }
                    else
                    {


                        /*" -2481- IF CSP-CATTARIO EQUAL ( 11 OR 15 OR 17 OR 21 OR 23 OR 91 ) */

                        if (CSP_REGISTRO.CSP_CATTARIO.In("11", "15", "17", "21", "23", "91"))
                        {

                            /*" -2482- MOVE 0,80 TO CSP-TPCDSFRF */
                            _.Move(0.80, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2483- ELSE */
                        }
                        else
                        {


                            /*" -2485- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2487- MOVE 0,85 TO CSP-TPCDSFRF. */
                                _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2488- IF CSP-CLAFRFAC EQUAL 4 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 4)
            {

                /*" -2490- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22"))
                {

                    /*" -2491- MOVE 1,25 TO CSP-TPCDSFRF */
                    _.Move(1.25, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2492- ELSE */
                }
                else
                {


                    /*" -2493- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2494- MOVE 1,35 TO CSP-TPCDSFRF */
                        _.Move(1.35, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2495- ELSE */
                    }
                    else
                    {


                        /*" -2497- IF CSP-CATTARIO EQUAL ( 11 OR 15 OR 17 OR 21 OR 23 OR 91 ) */

                        if (CSP_REGISTRO.CSP_CATTARIO.In("11", "15", "17", "21", "23", "91"))
                        {

                            /*" -2498- MOVE 1 TO CSP-TPCDSFRF */
                            _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2499- ELSE */
                        }
                        else
                        {


                            /*" -2501- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2503- MOVE 1 TO CSP-TPCDSFRF. */
                                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2504- IF CSP-CLAFRFAC GREATER 4 */

            if (CSP_REGISTRO.CSP_CLAFRFAC > 4)
            {

                /*" -2506- MOVE 1 TO CSP-TPCDSFRF. */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
            }


            /*" -2507- IF CSP-DTINIAUTO LESS 19981116 */

            if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19981116)
            {

                /*" -2514- GO TO 070-025-APLICA-DESC-FRANQUIA. */

                M_070_025_APLICA_DESC_FRANQUIA(); //GOTO
                return;
            }


            /*" -2515- IF CSP-CLAFRFAC LESS 2 */

            if (CSP_REGISTRO.CSP_CLAFRFAC < 2)
            {

                /*" -2517- MOVE 1 TO CSP-TPCDSFRF. */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
            }


            /*" -2518- IF CSP-CLAFRFAC EQUAL 2 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 2)
            {

                /*" -2520- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22"))
                {

                    /*" -2521- MOVE 0,90 TO CSP-TPCDSFRF */
                    _.Move(0.90, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2522- ELSE */
                }
                else
                {


                    /*" -2523- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2524- MOVE 0,85 TO CSP-TPCDSFRF */
                        _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2525- ELSE */
                    }
                    else
                    {


                        /*" -2527- IF CSP-CATTARIO EQUAL ( 11 OR 15 OR 17 OR 21 OR 23 OR 91 ) */

                        if (CSP_REGISTRO.CSP_CATTARIO.In("11", "15", "17", "21", "23", "91"))
                        {

                            /*" -2528- MOVE 0,90 TO CSP-TPCDSFRF */
                            _.Move(0.90, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2529- ELSE */
                        }
                        else
                        {


                            /*" -2531- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2533- MOVE 0,92 TO CSP-TPCDSFRF. */
                                _.Move(0.92, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2534- IF CSP-CLAFRFAC EQUAL 3 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 3)
            {

                /*" -2537- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 OR 11 OR 15 OR 17 OR 21 OR 23 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22", "11", "15", "17", "21", "23"))
                {

                    /*" -2538- MOVE 0,75 TO CSP-TPCDSFRF */
                    _.Move(0.75, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2539- ELSE */
                }
                else
                {


                    /*" -2540- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2541- MOVE 0,65 TO CSP-TPCDSFRF */
                        _.Move(0.65, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2542- ELSE */
                    }
                    else
                    {


                        /*" -2543- IF CSP-CATTARIO EQUAL 91 */

                        if (CSP_REGISTRO.CSP_CATTARIO == 91)
                        {

                            /*" -2544- MOVE 0,80 TO CSP-TPCDSFRF */
                            _.Move(0.80, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2545- ELSE */
                        }
                        else
                        {


                            /*" -2547- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2549- MOVE 0,85 TO CSP-TPCDSFRF. */
                                _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2550- IF CSP-CLAFRFAC EQUAL 4 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 4)
            {

                /*" -2553- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 OR 11 OR 15 OR 17 OR 21 OR 23 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22", "11", "15", "17", "21", "23"))
                {

                    /*" -2554- MOVE 1,25 TO CSP-TPCDSFRF */
                    _.Move(1.25, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2555- ELSE */
                }
                else
                {


                    /*" -2556- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2557- MOVE 1,35 TO CSP-TPCDSFRF */
                        _.Move(1.35, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2558- ELSE */
                    }
                    else
                    {


                        /*" -2559- IF CSP-CATTARIO EQUAL 91 */

                        if (CSP_REGISTRO.CSP_CATTARIO == 91)
                        {

                            /*" -2560- MOVE 1 TO CSP-TPCDSFRF */
                            _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2561- ELSE */
                        }
                        else
                        {


                            /*" -2563- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2565- MOVE 1 TO CSP-TPCDSFRF. */
                                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2566- IF CSP-CLAFRFAC GREATER 4 */

            if (CSP_REGISTRO.CSP_CLAFRFAC > 4)
            {

                /*" -2568- MOVE 1 TO CSP-TPCDSFRF. */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
            }


            /*" -2569- IF CSP-DTINIAUTO LESS 19981231 */

            if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19981231)
            {

                /*" -2574- GO TO 070-025-APLICA-DESC-FRANQUIA. */

                M_070_025_APLICA_DESC_FRANQUIA(); //GOTO
                return;
            }


            /*" -2575- IF CSP-CLAFRFAC EQUAL 2 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 2)
            {

                /*" -2577- MOVE 1 TO CSP-TPCDSFRF. */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
            }


            /*" -2578- IF CSP-CLAFRFAC EQUAL 3 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 3)
            {

                /*" -2580- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22"))
                {

                    /*" -2581- MOVE 0,90 TO CSP-TPCDSFRF */
                    _.Move(0.90, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2582- ELSE */
                }
                else
                {


                    /*" -2583- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2584- MOVE 0,85 TO CSP-TPCDSFRF */
                        _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2585- ELSE */
                    }
                    else
                    {


                        /*" -2587- IF CSP-CATTARIO EQUAL ( 11 OR 15 OR 17 OR 21 OR 23 OR 91 ) */

                        if (CSP_REGISTRO.CSP_CATTARIO.In("11", "15", "17", "21", "23", "91"))
                        {

                            /*" -2588- MOVE 0,90 TO CSP-TPCDSFRF */
                            _.Move(0.90, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2589- ELSE */
                        }
                        else
                        {


                            /*" -2591- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2593- MOVE 0,92 TO CSP-TPCDSFRF. */
                                _.Move(0.92, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2594- IF CSP-CLAFRFAC EQUAL 4 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 4)
            {

                /*" -2597- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 OR 11 OR 15 OR 17 OR 21 OR 23 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22", "11", "15", "17", "21", "23"))
                {

                    /*" -2598- MOVE 0,75 TO CSP-TPCDSFRF */
                    _.Move(0.75, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2599- ELSE */
                }
                else
                {


                    /*" -2600- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2601- MOVE 0,65 TO CSP-TPCDSFRF */
                        _.Move(0.65, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2602- ELSE */
                    }
                    else
                    {


                        /*" -2603- IF CSP-CATTARIO EQUAL 91 */

                        if (CSP_REGISTRO.CSP_CATTARIO == 91)
                        {

                            /*" -2604- MOVE 0,80 TO CSP-TPCDSFRF */
                            _.Move(0.80, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2605- ELSE */
                        }
                        else
                        {


                            /*" -2607- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2609- MOVE 0,85 TO CSP-TPCDSFRF. */
                                _.Move(0.85, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2610- IF CSP-CLAFRFAC EQUAL 1 */

            if (CSP_REGISTRO.CSP_CLAFRFAC == 1)
            {

                /*" -2613- IF CSP-CATTARIO EQUAL ( 10 OR 14 OR 16 OR 20 OR 22 OR 11 OR 15 OR 17 OR 21 OR 23 ) */

                if (CSP_REGISTRO.CSP_CATTARIO.In("10", "14", "16", "20", "22", "11", "15", "17", "21", "23"))
                {

                    /*" -2614- MOVE 1,25 TO CSP-TPCDSFRF */
                    _.Move(1.25, CSP_REGISTRO.CSP_TPCDSFRF);

                    /*" -2615- ELSE */
                }
                else
                {


                    /*" -2616- IF CSP-CATTARIO EQUAL ( 80 OR 81 ) */

                    if (CSP_REGISTRO.CSP_CATTARIO.In("80", "81"))
                    {

                        /*" -2617- MOVE 1,35 TO CSP-TPCDSFRF */
                        _.Move(1.35, CSP_REGISTRO.CSP_TPCDSFRF);

                        /*" -2618- ELSE */
                    }
                    else
                    {


                        /*" -2619- IF CSP-CATTARIO EQUAL 91 */

                        if (CSP_REGISTRO.CSP_CATTARIO == 91)
                        {

                            /*" -2620- MOVE 1 TO CSP-TPCDSFRF */
                            _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);

                            /*" -2621- ELSE */
                        }
                        else
                        {


                            /*" -2623- IF CSP-CATTARIO EQUAL ( 40 OR 41 OR 42 OR 43 OR 50 OR 51 OR 52 OR 53 ) */

                            if (CSP_REGISTRO.CSP_CATTARIO.In("40", "41", "42", "43", "50", "51", "52", "53"))
                            {

                                /*" -2625- MOVE 1 TO CSP-TPCDSFRF. */
                                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
                            }

                        }

                    }

                }

            }


            /*" -2626- IF CSP-CLAFRFAC GREATER 4 */

            if (CSP_REGISTRO.CSP_CLAFRFAC > 4)
            {

                /*" -2626- MOVE 1 TO CSP-TPCDSFRF. */
                _.Move(1, CSP_REGISTRO.CSP_TPCDSFRF);
            }


        }

        [StopWatch]
        /*" M-070-025-APLICA-DESC-FRANQUIA */
        private void M_070_025_APLICA_DESC_FRANQUIA(bool isPerform = false)
        {
            /*" -2634- IF CSP-DTINIAUTO GREATER 19990718 AND CSP-DTINIAUTO LESS 19991015 */

            if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19990718 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19991015)
            {

                /*" -2641- COMPUTE CSP-VRPLACAS ROUNDED = CSP-VRPLACAS * CSP-TPCDSFRF. */
                CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRPLACAS * CSP_REGISTRO.CSP_TPCDSFRF;
            }


            /*" -2643- IF CSP-DTINIAUTO GREATER 19990718 AND CSP-DTINIAUTO LESS 19991015 */

            if (CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() > 19990718 && CSP_REGISTRO.CSP_DTINIAUTO.GetMoveValues().ToInt() < 19991015)
            {

                /*" -2644- IF CSP-DESPEXTR EQUAL 'S' */

                if (CSP_REGISTRO.CSP_DESPEXTR == "S")
                {

                    /*" -2645- IF CSP-CLAFRFAC EQUAL 3 */

                    if (CSP_REGISTRO.CSP_CLAFRFAC == 3)
                    {

                        /*" -2647- COMPUTE CSP-VRPLACAS ROUNDED = CSP-VRPLACAS * 1,10 */
                        CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.10;

                        /*" -2649- COMPUTE CSP-TPCDSFRF = CSP-TPCDSFRF * 1,10 */
                        CSP_REGISTRO.CSP_TPCDSFRF.Value = CSP_REGISTRO.CSP_TPCDSFRF * 1.10;

                        /*" -2650- ELSE */
                    }
                    else
                    {


                        /*" -2651- IF CSP-CLAFRFAC EQUAL 4 */

                        if (CSP_REGISTRO.CSP_CLAFRFAC == 4)
                        {

                            /*" -2653- COMPUTE CSP-VRPLACAS ROUNDED = CSP-VRPLACAS * 1,20 */
                            CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.20;

                            /*" -2657- COMPUTE CSP-TPCDSFRF = CSP-TPCDSFRF * 1,20. */
                            CSP_REGISTRO.CSP_TPCDSFRF.Value = CSP_REGISTRO.CSP_TPCDSFRF * 1.20;
                        }

                    }

                }

            }


            /*" -2657- PERFORM 070-030-APLICA-DESCONTO-INCROU. */

            M_070_030_APLICA_DESCONTO_INCROU(true);

        }

        [StopWatch]
        /*" M-070-030-APLICA-DESCONTO-INCROU */
        private void M_070_030_APLICA_DESCONTO_INCROU(bool isPerform = false)
        {
            /*" -2666- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -2667- IF CSP-PCINCROU EQUAL ZEROS */

                if (CSP_REGISTRO.CSP_PCINCROU == 00)
                {

                    /*" -2670- IF CSP-CATTARIO EQUAL 30 AND CSP-TIPOVEIC EQUAL 9400 NEXT SENTENCE */

                    if (CSP_REGISTRO.CSP_CATTARIO == 30 && CSP_REGISTRO.CSP_TIPOVEIC == 9400)
                    {

                        /*" -2671- ELSE */
                    }
                    else
                    {


                        /*" -2672- PERFORM 074-000-PESQ-V1CATTARIFA */

                        M_074_000_PESQ_V1CATTARIFA_SECTION();

                        /*" -2673- MOVE CATTF-VLPRTXCF TO CSP-TPCINROU */
                        _.Move(CSP_RETORNO.CATTF_VLPRTXCF, CSP_REGISTRO.CSP_TPCINROU);

                        /*" -2674- ELSE */
                    }

                }
                else
                {


                    /*" -2675- MOVE CSP-PCINCROU TO CSP-TPCINROU */
                    _.Move(CSP_REGISTRO.CSP_PCINCROU, CSP_REGISTRO.CSP_TPCINROU);

                    /*" -2676- ELSE */
                }

            }
            else
            {


                /*" -2678- MOVE ZEROS TO CSP-TPCINROU. */
                _.Move(0, CSP_REGISTRO.CSP_TPCINROU);
            }


            /*" -2680- COMPUTE CSP-VRPLACAS ROUNDED = CSP-VRPLACAS * (100 - CSP-TPCINROU) / 100. */
            CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRPLACAS * (100 - CSP_REGISTRO.CSP_TPCINROU) / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-072-000-PESQ-V1FRANQFAC-SECTION */
        private void M_072_000_PESQ_V1FRANQFAC_SECTION()
        {
            /*" -2695- PERFORM M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1 */

            M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1();

            /*" -2698- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2699- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2700- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2701- ELSE */
            }
            else
            {


                /*" -2702- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2703- MOVE '072-000' TO CSP-PROCPAR */
                    _.Move("072-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2704- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2704- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-072-000-PESQ-V1FRANQFAC-DB-SELECT-1 */
        public void M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1()
        {
            /*" -2695- EXEC SQL SELECT PCDESC INTO :FRFAC-PCDESC FROM SEGUROS.V1FRANQFAC WHERE CODTAB = :FRFAC-CODTAB AND CLASSEFR = :FRFAC-CLASSEFR AND DTINIVIG <= :FRFAC-DTINIVIG AND DTTERVIG >= :FRFAC-DTINIVIG END-EXEC. */

            var m_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1 = new M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1()
            {
                FRFAC_CLASSEFR = CSP_RETORNO.FRFAC_CLASSEFR.ToString(),
                FRFAC_DTINIVIG = CSP_RETORNO.FRFAC_DTINIVIG.ToString(),
                FRFAC_CODTAB = CSP_RETORNO.FRFAC_CODTAB.ToString(),
            };

            var executed_1 = M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1.Execute(m_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FRFAC_PCDESC, CSP_RETORNO.FRFAC_PCDESC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_072_999_EXIT*/

        [StopWatch]
        /*" M-074-000-PESQ-V1CATTARIFA-SECTION */
        private void M_074_000_PESQ_V1CATTARIFA_SECTION()
        {
            /*" -2713- MOVE '074-000 - PESQ-V1CATTARIFA' TO CSP-MSG. */
            _.Move("074-000 - PESQ-V1CATTARIFA", CSP_RETORNO.CSP_MSG);

            /*" -2714- MOVE 'PERC. APLICAVEIS S/ INC/ROUBO' TO CSP-LIT */
            _.Move("PERC. APLICAVEIS S/ INC/ROUBO", CSP_RETORNO.CSP_MSG.CSP_LIT);

            /*" -2716- MOVE 14 TO CATTF-CODTAB. */
            _.Move(14, CSP_RETORNO.CATTF_CODTAB);

            /*" -2717- MOVE ZEROS TO CATTF-CODPRODU */
            _.Move(0, CSP_RETORNO.CATTF_CODPRODU);

            /*" -2719- MOVE CSP-CATTARIO TO CATTF-CATTARIF */
            _.Move(CSP_REGISTRO.CSP_CATTARIO, CSP_RETORNO.CATTF_CATTARIF);

            /*" -2721- MOVE WDATA-CHAR TO CATTF-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.CATTF_DTINIVIG);

            /*" -2730- PERFORM M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1 */

            M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1();

            /*" -2733- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2734- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2735- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2736- ELSE */
            }
            else
            {


                /*" -2737- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2738- MOVE '074-000' TO CSP-PROCPAR */
                    _.Move("074-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2739- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2739- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-074-000-PESQ-V1CATTARIFA-DB-SELECT-1 */
        public void M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1()
        {
            /*" -2730- EXEC SQL SELECT VALUE(VLPRTXCF,50) INTO :CATTF-VLPRTXCF FROM SEGUROS.V1CATTARIFA WHERE CODTAB = :CATTF-CODTAB AND CODPRODU = :CATTF-CODPRODU AND CATTARIF = :CATTF-CATTARIF AND DTINIVIG <= :CATTF-DTINIVIG AND DTTERVIG >= :CATTF-DTINIVIG END-EXEC. */

            var m_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 = new M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1()
            {
                CATTF_CODPRODU = CSP_RETORNO.CATTF_CODPRODU.ToString(),
                CATTF_CATTARIF = CSP_RETORNO.CATTF_CATTARIF.ToString(),
                CATTF_DTINIVIG = CSP_RETORNO.CATTF_DTINIVIG.ToString(),
                CATTF_CODTAB = CSP_RETORNO.CATTF_CODTAB.ToString(),
            };

            var executed_1 = M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1.Execute(m_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CATTF_VLPRTXCF, CSP_RETORNO.CATTF_VLPRTXCF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_074_999_EXIT*/

        [StopWatch]
        /*" M-080-000-CALC-PRO-RATA-PZCURTO-SECTION */
        private void M_080_000_CALC_PRO_RATA_PZCURTO_SECTION()
        {
            /*" -2748- MOVE '080-000 - CALC-PRO-RATA-PZCURTO' TO CSP-MSG. */
            _.Move("080-000 - CALC-PRO-RATA-PZCURTO", CSP_RETORNO.CSP_MSG);

            /*" -2750- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -2752- COMPUTE CSP-VRPLCASC = CSP-VRPLACAS * CSP-TPCPZSEG / 100 */
                CSP_REGISTRO.CSP_VRPLCASC.Value = CSP_REGISTRO.CSP_VRPLACAS * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                /*" -2754- ELSE */
            }
            else
            {


                /*" -2755- COMPUTE CSP-VRPLCASC = CSP-VRPLACAS * CSP-PRAZOSEG / 365. */
                CSP_REGISTRO.CSP_VRPLCASC.Value = CSP_REGISTRO.CSP_VRPLACAS * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_080_999_EXIT*/

        [StopWatch]
        /*" M-090-000-APLICA-DESC-ANTIFURTO-SECTION */
        private void M_090_000_APLICA_DESC_ANTIFURTO_SECTION()
        {
            /*" -2765- MOVE '090-000 - APLICA-DESC-ANTIFURTO' TO CSP-MSG. */
            _.Move("090-000 - APLICA-DESC-ANTIFURTO", CSP_RETORNO.CSP_MSG);

            /*" -2767- IF CSP-PCDESCAT EQUAL ZEROS NEXT SENTENCE */

            if (CSP_REGISTRO.CSP_PCDESCAT == 00)
            {

                /*" -2768- ELSE */
            }
            else
            {


                /*" -2769- COMPUTE CSP-VRPLCASC = CSP-VRPLCASC * (100 - CSP-PCDESCAT) / 100. */
                CSP_REGISTRO.CSP_VRPLCASC.Value = CSP_REGISTRO.CSP_VRPLCASC * (100 - CSP_REGISTRO.CSP_PCDESCAT) / 100f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-100-000-TRATA-EXTENSAO-PER-SECTION */
        private void M_100_000_TRATA_EXTENSAO_PER_SECTION()
        {
            /*" -2784- MOVE '100-000 - TRATA-EXTENSAO-PER' TO CSP-MSG. */
            _.Move("100-000 - TRATA-EXTENSAO-PER", CSP_RETORNO.CSP_MSG);

            /*" -2785- MOVE ZEROS TO CSP-VRPACASC. */
            _.Move(0, CSP_REGISTRO.CSP_VRPACASC);

            /*" -2787- IF CSP-EXTPER EQUAL '1' NEXT SENTENCE */

            if (CSP_REGISTRO.CSP_EXTPER == "1")
            {

                /*" -2788- ELSE */
            }
            else
            {


                /*" -2789- IF CSP-EXTPER EQUAL '2' */

                if (CSP_REGISTRO.CSP_EXTPER == "2")
                {

                    /*" -2790- GO TO 100-040-EXTENSAO2 */

                    M_100_040_EXTENSAO2(); //GOTO
                    return;

                    /*" -2791- ELSE */
                }
                else
                {


                    /*" -2791- GO TO 100-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_100_020_EXTENSAO1 */

            M_100_020_EXTENSAO1();

        }

        [StopWatch]
        /*" M-100-020-EXTENSAO1 */
        private void M_100_020_EXTENSAO1(bool isPerform = false)
        {
            /*" -2796- IF CSP-PER-30 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
            {

                /*" -2797- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,10 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.10;

                /*" -2799- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2800- IF CSP-PER-60 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
            {

                /*" -2801- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,20 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.20;

                /*" -2803- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2804- IF CSP-PER-90 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
            {

                /*" -2805- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,30 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.30;

                /*" -2807- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2808- IF CSP-PER-120 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
            {

                /*" -2809- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,35 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.35;

                /*" -2811- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2812- IF CSP-PER-150 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
            {

                /*" -2813- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,40 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.40;

                /*" -2815- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2816- IF CSP-PER-180 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
            {

                /*" -2817- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,45 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.45;

                /*" -2819- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2820- IF CSP-PER-210 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
            {

                /*" -2821- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,50 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.50;

                /*" -2823- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2824- IF CSP-PER-240 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
            {

                /*" -2825- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,55 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.55;

                /*" -2827- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2828- IF CSP-PER-270 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
            {

                /*" -2829- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,60 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.60;

                /*" -2831- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2832- IF CSP-PER-300 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
            {

                /*" -2833- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,65 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.65;

                /*" -2835- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2836- IF CSP-PER-330 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
            {

                /*" -2837- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,70 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.70;

                /*" -2839- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2840- IF CSP-PER-360 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
            {

                /*" -2841- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,75 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.75;

                /*" -2843- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2844- IF CSP-PER-364 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"])
            {

                /*" -2845- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,80 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.80;

                /*" -2847- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2848- IF CSP-PER-366 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_366"])
            {

                /*" -2849- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,6. */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.6;
            }


            /*" -2849- GO TO 100-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-100-040-EXTENSAO2 */
        private void M_100_040_EXTENSAO2(bool isPerform = false)
        {
            /*" -2854- IF CSP-PER-30 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
            {

                /*" -2855- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,15 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.15;

                /*" -2857- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2858- IF CSP-PER-60 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
            {

                /*" -2859- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,30 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.30;

                /*" -2861- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2862- IF CSP-PER-90 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
            {

                /*" -2863- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,45 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.45;

                /*" -2865- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2866- IF CSP-PER-120 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
            {

                /*" -2867- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,60 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.60;

                /*" -2869- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2870- IF CSP-PER-150 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
            {

                /*" -2871- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,75 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.75;

                /*" -2873- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2874- IF CSP-PER-180 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
            {

                /*" -2875- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 0,90 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 0.90;

                /*" -2877- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2878- IF CSP-PER-210 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
            {

                /*" -2879- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,05 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.05;

                /*" -2881- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2882- IF CSP-PER-240 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
            {

                /*" -2883- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,20 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.20;

                /*" -2885- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2886- IF CSP-PER-270 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
            {

                /*" -2887- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,35 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.35;

                /*" -2889- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2890- IF CSP-PER-300 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
            {

                /*" -2891- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,50 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.50;

                /*" -2893- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2894- IF CSP-PER-330 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
            {

                /*" -2895- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,65 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.65;

                /*" -2897- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2898- IF CSP-PER-360 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
            {

                /*" -2899- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,80 */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.80;

                /*" -2901- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -2902- IF CSP-PER-364 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"])
            {

                /*" -2903- COMPUTE CSP-VRPACASC = CSP-VRPLACAS * 1,95. */
                CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPLACAS * 1.95;
            }


            /*" -2903- GO TO 100-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-160-000-PESQ-V1CATTARIFA-SECTION */
        private void M_160_000_PESQ_V1CATTARIFA_SECTION()
        {
            /*" -2923- PERFORM M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1 */

            M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1();

            /*" -2926- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2927- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2928- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2929- ELSE */
            }
            else
            {


                /*" -2930- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2931- MOVE '160-000' TO CSP-PROCPAR */
                    _.Move("160-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2932- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2932- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-160-000-PESQ-V1CATTARIFA-DB-SELECT-1 */
        public void M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1()
        {
            /*" -2923- EXEC SQL SELECT VLPRTXCF , PREBASBT INTO :CATTF-VLPRTXCF , :CATTF-PREBASBT FROM SEGUROS.V1CATTARIFA WHERE CODTAB = :CATTF-CODTAB AND CODPRODU = :CATTF-CODPRODU AND CATTARIF = :CATTF-CATTARIF AND REGIAO = :CATTF-REGIAO AND DTINIVIG <= :CATTF-DTINIVIG AND DTTERVIG >= :CATTF-DTINIVIG END-EXEC. */

            var m_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 = new M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1()
            {
                CATTF_CODPRODU = CSP_RETORNO.CATTF_CODPRODU.ToString(),
                CATTF_CATTARIF = CSP_RETORNO.CATTF_CATTARIF.ToString(),
                CATTF_DTINIVIG = CSP_RETORNO.CATTF_DTINIVIG.ToString(),
                CATTF_CODTAB = CSP_RETORNO.CATTF_CODTAB.ToString(),
                CATTF_REGIAO = CSP_RETORNO.CATTF_REGIAO.ToString(),
            };

            var executed_1 = M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1.Execute(m_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CATTF_VLPRTXCF, CSP_RETORNO.CATTF_VLPRTXCF);
                _.Move(executed_1.CATTF_PREBASBT, CSP_RETORNO.CATTF_PREBASBT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-162-000-PESQ-V1CATTARIFA-SECTION */
        private void M_162_000_PESQ_V1CATTARIFA_SECTION()
        {
            /*" -2952- PERFORM M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1 */

            M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1();

            /*" -2955- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2956- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2957- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2958- ELSE */
            }
            else
            {


                /*" -2959- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2960- MOVE '162-000' TO CSP-PROCPAR */
                    _.Move("162-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2961- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2961- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-162-000-PESQ-V1CATTARIFA-DB-SELECT-1 */
        public void M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1()
        {
            /*" -2952- EXEC SQL SELECT PREBASBT INTO :CATTF-PREBASBT FROM SEGUROS.V1CATTARIFA WHERE CODTAB = :CATTF-CODTAB AND CODPRODU = :CATTF-CODPRODU AND CATTARIF = :CATTF-CATTARIF AND VLPRTXCF BETWEEN :CATTF-VLPRTXCF AND :CATTF-VLPRTXCF1 AND DTINIVIG <= :CATTF-DTINIVIG AND DTTERVIG >= :CATTF-DTINIVIG END-EXEC. */

            var m_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 = new M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1()
            {
                CATTF_VLPRTXCF1 = CSP_RETORNO.CATTF_VLPRTXCF1.ToString(),
                CATTF_CODPRODU = CSP_RETORNO.CATTF_CODPRODU.ToString(),
                CATTF_CATTARIF = CSP_RETORNO.CATTF_CATTARIF.ToString(),
                CATTF_VLPRTXCF = CSP_RETORNO.CATTF_VLPRTXCF.ToString(),
                CATTF_DTINIVIG = CSP_RETORNO.CATTF_DTINIVIG.ToString(),
                CATTF_CODTAB = CSP_RETORNO.CATTF_CODTAB.ToString(),
            };

            var executed_1 = M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1.Execute(m_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CATTF_PREBASBT, CSP_RETORNO.CATTF_PREBASBT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_162_999_EXIT*/

        [StopWatch]
        /*" M-210-000-PESQ-V1PRAZOSEG-SECTION */
        private void M_210_000_PESQ_V1PRAZOSEG_SECTION()
        {
            /*" -2970- MOVE '210-000 - PESQ-V1PRAZOSEG' TO CSP-MSG. */
            _.Move("210-000 - PESQ-V1PRAZOSEG", CSP_RETORNO.CSP_MSG);

            /*" -2979- PERFORM M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1 */

            M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1();

            /*" -2982- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2983- MOVE 'PRAZO DE SEGURO                 ' TO CSP-LIT */
                _.Move("PRAZO DE SEGURO                 ", CSP_RETORNO.CSP_MSG.CSP_LIT);

                /*" -2984- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -2985- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -2986- ELSE */
            }
            else
            {


                /*" -2987- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2988- MOVE '210-000' TO CSP-PROCPAR */
                    _.Move("210-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -2989- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -2990- PERFORM 999-000-ERRO */

                    M_999_000_ERRO_SECTION();

                    /*" -2991- ELSE */
                }
                else
                {


                    /*" -2991- MOVE PRAZO-PCPRMANO TO CSP-TPCPZSEG. */
                    _.Move(CSP_RETORNO.PRAZO_PCPRMANO, CSP_REGISTRO.CSP_TPCPZSEG);
                }

            }


        }

        [StopWatch]
        /*" M-210-000-PESQ-V1PRAZOSEG-DB-SELECT-1 */
        public void M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1()
        {
            /*" -2979- EXEC SQL SELECT PCPRMANO INTO :PRAZO-PCPRMANO FROM SEGUROS.V1PRAZOSEG WHERE CODTAB = :PRAZO-CODTAB AND PRAZOINI <= :PRAZO-PRAZOINI AND PRAZOFIM >= :PRAZO-PRAZOINI AND DTINIVIG <= :PRAZO-DTINIVIG AND DTTERVIG >= :PRAZO-DTINIVIG END-EXEC. */

            var m_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1 = new M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1()
            {
                PRAZO_PRAZOINI = CSP_RETORNO.PRAZO_PRAZOINI.ToString(),
                PRAZO_DTINIVIG = CSP_RETORNO.PRAZO_DTINIVIG.ToString(),
                PRAZO_CODTAB = CSP_RETORNO.PRAZO_CODTAB.ToString(),
            };

            var executed_1 = M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1.Execute(m_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRAZO_PCPRMANO, CSP_RETORNO.PRAZO_PCPRMANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-230-000-TRATA-ITEM-R-SECTION */
        private void M_230_000_TRATA_ITEM_R_SECTION()
        {
            /*" -3003- MOVE '230-000 - TRATA-ITEM-R ' TO CSP-MSG. */
            _.Move("230-000 - TRATA-ITEM-R ", CSP_RETORNO.CSP_MSG);

            /*" -3004- IF CSP-VRISRCDM EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISRCDM == 00)
            {

                /*" -3006- GO TO 230-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/ //GOTO
                return;
            }


            /*" -3007- MOVE 18 TO NIVCS-CODTAB */
            _.Move(18, CSP_RETORNO.NIVCS_CODTAB);

            /*" -3008- MOVE ZEROS TO NIVCS-CODPRODU */
            _.Move(0, CSP_RETORNO.NIVCS_CODPRODU);

            /*" -3009- MOVE CSP-DTINIRCDM TO WDATA-NUM */
            _.Move(CSP_REGISTRO.CSP_DTINIRCDM, WDATA_NUM);

            /*" -3010- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -3011- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -3012- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -3014- MOVE WDATA-CHAR TO NIVCS-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.NIVCS_DTINIVIG);

            /*" -3016- COMPUTE NIVCS-IMPSEGBT = CSP-VRISRCDM / WS-VLCRUZAD-IS */
            CSP_RETORNO.NIVCS_IMPSEGBT.Value = CSP_REGISTRO.CSP_VRISRCDM / WS_VLCRUZAD_IS;

            /*" -3018- MOVE '237-000 - PESQUISA NIVEL RCF DM' TO CSP-MSG. */
            _.Move("237-000 - PESQUISA NIVEL RCF DM", CSP_RETORNO.CSP_MSG);

            /*" -3020- PERFORM 237-000-PESQ-V1NIVELCAP-BTN */

            M_237_000_PESQ_V1NIVELCAP_BTN_SECTION();

            /*" -3021- MOVE 19 TO CFRCF-CODTAB */
            _.Move(19, CSP_RETORNO.CFRCF_CODTAB);

            /*" -3022- MOVE ZEROS TO CFRCF-CODPRODU */
            _.Move(0, CSP_RETORNO.CFRCF_CODPRODU);

            /*" -3023- MOVE NIVCS-NIVEL TO CFRCF-NIVEL */
            _.Move(CSP_RETORNO.NIVCS_NIVEL, CSP_RETORNO.CFRCF_NIVEL);

            /*" -3025- MOVE CSP-DTINIRCDM TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIRCDM, WDATA_NUM, WS_DATA1);

            /*" -3026- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -3027- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -3028- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -3029- MOVE WDATA-CHAR TO CFRCF-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.CFRCF_DTINIVIG);

            /*" -3030- PERFORM 240-000-PESQ-V1RCFCOEFIC */

            M_240_000_PESQ_V1RCFCOEFIC_SECTION();

            /*" -3030- PERFORM 245-000-TRATA-PRBAS-RCDM. */

            M_245_000_TRATA_PRBAS_RCDM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-237-000-PESQ-V1NIVELCAP-BTN-SECTION */
        private void M_237_000_PESQ_V1NIVELCAP_BTN_SECTION()
        {
            /*" -3049- PERFORM M_237_000_PESQ_V1NIVELCAP_BTN_DB_DECLARE_1 */

            M_237_000_PESQ_V1NIVELCAP_BTN_DB_DECLARE_1();

            /*" -3051- PERFORM M_237_000_PESQ_V1NIVELCAP_BTN_DB_OPEN_1 */

            M_237_000_PESQ_V1NIVELCAP_BTN_DB_OPEN_1();

            /*" -3056- PERFORM M_237_000_PESQ_V1NIVELCAP_BTN_DB_FETCH_1 */

            M_237_000_PESQ_V1NIVELCAP_BTN_DB_FETCH_1();

            /*" -3059- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3059- PERFORM M_237_000_PESQ_V1NIVELCAP_BTN_DB_CLOSE_1 */

                M_237_000_PESQ_V1NIVELCAP_BTN_DB_CLOSE_1();

                /*" -3062- GO TO 237-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_237_999_EXIT*/ //GOTO
                return;
            }


            /*" -3063- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3064- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -3065- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -3066- ELSE */
            }
            else
            {


                /*" -3067- MOVE 2 TO CSP-W01P0300 */
                _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                /*" -3067- PERFORM 999-000-ERRO. */

                M_999_000_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" M-237-000-PESQ-V1NIVELCAP-BTN-DB-DECLARE-1 */
        public void M_237_000_PESQ_V1NIVELCAP_BTN_DB_DECLARE_1()
        {
            /*" -3049- EXEC SQL DECLARE NIVCSBT CURSOR FOR SELECT NIVEL, IMPSEGBT FROM SEGUROS.V1NIVELCAP WHERE CODTAB = :NIVCS-CODTAB AND CODPRODU = :NIVCS-CODPRODU AND IMPSEGBT >= :NIVCS-IMPSEGBT AND DTINIVIG <= :NIVCS-DTINIVIG AND DTTERVIG >= :NIVCS-DTINIVIG ORDER BY IMPSEGBT END-EXEC. */
            NIVCSBT = new AU0025S_NIVCSBT(true);
            string GetQuery_NIVCSBT()
            {
                var query = @$"SELECT NIVEL
							, IMPSEGBT 
							FROM SEGUROS.V1NIVELCAP 
							WHERE CODTAB = '{CSP_RETORNO.NIVCS_CODTAB}' 
							AND CODPRODU = '{CSP_RETORNO.NIVCS_CODPRODU}' 
							AND IMPSEGBT >= '{CSP_RETORNO.NIVCS_IMPSEGBT}' 
							AND DTINIVIG <= '{CSP_RETORNO.NIVCS_DTINIVIG}' 
							AND DTTERVIG >= '{CSP_RETORNO.NIVCS_DTINIVIG}' 
							ORDER BY IMPSEGBT";

                return query;
            }
            NIVCSBT.GetQueryEvent += GetQuery_NIVCSBT;

        }

        [StopWatch]
        /*" M-237-000-PESQ-V1NIVELCAP-BTN-DB-OPEN-1 */
        public void M_237_000_PESQ_V1NIVELCAP_BTN_DB_OPEN_1()
        {
            /*" -3051- EXEC SQL OPEN NIVCSBT END-EXEC. */

            NIVCSBT.Open();

        }

        [StopWatch]
        /*" M-237-000-PESQ-V1NIVELCAP-BTN-DB-FETCH-1 */
        public void M_237_000_PESQ_V1NIVELCAP_BTN_DB_FETCH_1()
        {
            /*" -3056- EXEC SQL FETCH NIVCSBT INTO :NIVCS-NIVEL, :NIVCS-IMPSEGBT END-EXEC. */

            if (NIVCSBT.Fetch())
            {
                _.Move(NIVCSBT.NIVCS_NIVEL, CSP_RETORNO.NIVCS_NIVEL);
                _.Move(NIVCSBT.NIVCS_IMPSEGBT, CSP_RETORNO.NIVCS_IMPSEGBT);
            }

        }

        [StopWatch]
        /*" M-237-000-PESQ-V1NIVELCAP-BTN-DB-CLOSE-1 */
        public void M_237_000_PESQ_V1NIVELCAP_BTN_DB_CLOSE_1()
        {
            /*" -3059- EXEC SQL CLOSE NIVCSBT END-EXEC */

            NIVCSBT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_237_999_EXIT*/

        [StopWatch]
        /*" M-240-000-PESQ-V1RCFCOEFIC-SECTION */
        private void M_240_000_PESQ_V1RCFCOEFIC_SECTION()
        {
            /*" -3076- MOVE '240-000 - PESQ-V1RCFCOEFIC ' TO CSP-MSG. */
            _.Move("240-000 - PESQ-V1RCFCOEFIC ", CSP_RETORNO.CSP_MSG);

            /*" -3085- PERFORM M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1 */

            M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1();

            /*" -3088- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3089- MOVE 'COEFICIENTES RCFV               ' TO CSP-LIT */
                _.Move("COEFICIENTES RCFV               ", CSP_RETORNO.CSP_MSG.CSP_LIT);

                /*" -3090- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -3091- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -3092- ELSE */
            }
            else
            {


                /*" -3093- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3094- MOVE '240-000' TO CSP-PROCPAR */
                    _.Move("240-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -3095- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -3095- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-240-000-PESQ-V1RCFCOEFIC-DB-SELECT-1 */
        public void M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1()
        {
            /*" -3085- EXEC SQL SELECT COEFIC INTO :CFRCF-COEFIC FROM SEGUROS.V1RCFCOEFIC WHERE CODTAB = :CFRCF-CODTAB AND CODPRODU = :CFRCF-CODPRODU AND NIVEL = :CFRCF-NIVEL AND DTINIVIG <= :CFRCF-DTINIVIG AND DTTERVIG >= :CFRCF-DTINIVIG END-EXEC. */

            var m_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1 = new M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1()
            {
                CFRCF_CODPRODU = CSP_RETORNO.CFRCF_CODPRODU.ToString(),
                CFRCF_DTINIVIG = CSP_RETORNO.CFRCF_DTINIVIG.ToString(),
                CFRCF_CODTAB = CSP_RETORNO.CFRCF_CODTAB.ToString(),
                CFRCF_NIVEL = CSP_RETORNO.CFRCF_NIVEL.ToString(),
            };

            var executed_1 = M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1.Execute(m_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CFRCF_COEFIC, CSP_RETORNO.CFRCF_COEFIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-245-000-TRATA-PRBAS-RCDM-SECTION */
        private void M_245_000_TRATA_PRBAS_RCDM_SECTION()
        {
            /*" -3108- MOVE '245-000-              ' TO CSP-PROCPAR. */
            _.Move("245-000-              ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3109- IF CSP-VRPRRCDM EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRPRRCDM == 00)
            {

                /*" -3110- MOVE 10 TO CATTF-CODTAB */
                _.Move(10, CSP_RETORNO.CATTF_CODTAB);

                /*" -3111- MOVE ZEROS TO CATTF-CODPRODU */
                _.Move(0, CSP_RETORNO.CATTF_CODPRODU);

                /*" -3112- MOVE CSP-CATTARIR TO CATTF-CATTARIF */
                _.Move(CSP_REGISTRO.CSP_CATTARIR, CSP_RETORNO.CATTF_CATTARIF);

                /*" -3113- MOVE CSP-REGIAO TO CATTF-REGIAO */
                _.Move(CSP_REGISTRO.CSP_REGIAO, CSP_RETORNO.CATTF_REGIAO);

                /*" -3115- MOVE CSP-DTINIRCDM TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIRCDM, WDATA_NUM, WS_DATA1);

                /*" -3116- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3117- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3118- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3119- MOVE WDATA-CHAR TO CATTF-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.CATTF_DTINIVIG);

                /*" -3122- MOVE '160-000 - PREMIO BAS. ANUAL - RCFV - DM NAO CADASTRADO' TO CSP-MSG */
                _.Move("160-000 - PREMIO BAS. ANUAL - RCFV - DM NAO CADASTRADO", CSP_RETORNO.CSP_MSG);

                /*" -3123- PERFORM 160-000-PESQ-V1CATTARIFA */

                M_160_000_PESQ_V1CATTARIFA_SECTION();

                /*" -3124- IF CATTF-PREBASBT EQUAL ZEROS */

                if (CSP_RETORNO.CATTF_PREBASBT == 00)
                {

                    /*" -3125- MOVE CATTF-VLPRTXCF TO CSP-TPRBRCDM */
                    _.Move(CSP_RETORNO.CATTF_VLPRTXCF, CSP_REGISTRO.CSP_TPRBRCDM);

                    /*" -3126- ELSE */
                }
                else
                {


                    /*" -3127- COMPUTE CSP-TPRBRCDM = CATTF-PREBASBT * WS-VLCRUZAD */
                    CSP_REGISTRO.CSP_TPRBRCDM.Value = CSP_RETORNO.CATTF_PREBASBT * WS_VLCRUZAD;

                    /*" -3128- ELSE */
                }

            }
            else
            {


                /*" -3132- MOVE CSP-VRPRRCDM TO CSP-TPRBRCDM. */
                _.Move(CSP_REGISTRO.CSP_VRPRRCDM, CSP_REGISTRO.CSP_TPRBRCDM);
            }


            /*" -3133- COMPUTE WS-ITEM-R = CSP-TPRBRCDM * CFRCF-COEFIC */
            CSP_RETORNO.WS_ITEM_R.Value = CSP_REGISTRO.CSP_TPRBRCDM * CSP_RETORNO.CFRCF_COEFIC;

            /*" -3133- MOVE CFRCF-COEFIC TO CSP-TCFPBRDM. */
            _.Move(CSP_RETORNO.CFRCF_COEFIC, CSP_REGISTRO.CSP_TCFPBRDM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_245_999_EXIT*/

        [StopWatch]
        /*" M-250-000-TRATA-BONUS-RCFDM-SECTION */
        private void M_250_000_TRATA_BONUS_RCFDM_SECTION()
        {
            /*" -3141- MOVE '250-000-TRATA-BONUS-RCFDM' TO CSP-PROCPAR. */
            _.Move("250-000-TRATA-BONUS-RCFDM", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3142- COMPUTE CSP-VRPLARDM = WS-ITEM-R * (100 - CSP-TPCBONDM) / 100. */
            CSP_REGISTRO.CSP_VRPLARDM.Value = CSP_RETORNO.WS_ITEM_R * (100 - CSP_REGISTRO.CSP_TPCBONDM) / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_250_999_EXIT*/

        [StopWatch]
        /*" M-260-000-APLIC-DESC-FROTA-RCDM-SECTION */
        private void M_260_000_APLIC_DESC_FROTA_RCDM_SECTION()
        {
            /*" -3152- MOVE '260-000-APLIC-DESC-FROTA-RCDM' TO CSP-PROCPAR. */
            _.Move("260-000-APLIC-DESC-FROTA-RCDM", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3154- IF CSP-DESCFROT EQUAL ZEROS NEXT SENTENCE */

            if (CSP_REGISTRO.CSP_DESCFROT == 00)
            {

                /*" -3155- ELSE */
            }
            else
            {


                /*" -3156- COMPUTE CSP-VRPLARDM = CSP-VRPLARDM * (100 - CSP-DESCFROT) / 100. */
                CSP_REGISTRO.CSP_VRPLARDM.Value = CSP_REGISTRO.CSP_VRPLARDM * (100 - CSP_REGISTRO.CSP_DESCFROT) / 100f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-270-000-CALC-PRO-RATA-PZCURTO-SECTION */
        private void M_270_000_CALC_PRO_RATA_PZCURTO_SECTION()
        {
            /*" -3168- MOVE '270-000-CALC-PRO-RATA-PZCURTO' TO CSP-PROCPAR. */
            _.Move("270-000-CALC-PRO-RATA-PZCURTO", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3170- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -3171- COMPUTE CSP-VRPLRCDM = CSP-VRPLARDM * CSP-TPCPZSEG / 100 */
                CSP_REGISTRO.CSP_VRPLRCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                /*" -3173- ELSE */
            }
            else
            {


                /*" -3179- COMPUTE CSP-VRPLRCDM = CSP-VRPLARDM * CSP-PRAZOSEG / 365. */
                CSP_REGISTRO.CSP_VRPLRCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
            }


            /*" -3180- IF CSP-EXTPER EQUAL '1' */

            if (CSP_REGISTRO.CSP_EXTPER == "1")
            {

                /*" -3180- PERFORM 280-000-TRATA-EXTENSAO-RCDM. */

                M_280_000_TRATA_EXTENSAO_RCDM_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-280-000-TRATA-EXTENSAO-RCDM-SECTION */
        private void M_280_000_TRATA_EXTENSAO_RCDM_SECTION()
        {
            /*" -3193- MOVE '280-000-TRATA-EXTENSAO-RCDM' TO CSP-PROCPAR. */
            _.Move("280-000-TRATA-EXTENSAO-RCDM", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3194- MOVE ZEROS TO CSP-VRPARCDM. */
            _.Move(0, CSP_REGISTRO.CSP_VRPARCDM);

            /*" -3195- IF CSP-PER-30 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
            {

                /*" -3196- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,05 */
                CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.05;

                /*" -3197- ELSE */
            }
            else
            {


                /*" -3198- IF CSP-PER-60 */

                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
                {

                    /*" -3199- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,10 */
                    CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.10;

                    /*" -3200- ELSE */
                }
                else
                {


                    /*" -3201- IF CSP-PER-90 */

                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
                    {

                        /*" -3202- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,15 */
                        CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.15;

                        /*" -3203- ELSE */
                    }
                    else
                    {


                        /*" -3204- IF CSP-PER-120 */

                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
                        {

                            /*" -3205- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,17 */
                            CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.17;

                            /*" -3206- ELSE */
                        }
                        else
                        {


                            /*" -3207- IF CSP-PER-150 */

                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
                            {

                                /*" -3208- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,19 */
                                CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.19;

                                /*" -3209- ELSE */
                            }
                            else
                            {


                                /*" -3210- IF CSP-PER-180 */

                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
                                {

                                    /*" -3211- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,21 */
                                    CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.21;

                                    /*" -3212- ELSE */
                                }
                                else
                                {


                                    /*" -3213- IF CSP-PER-210 */

                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
                                    {

                                        /*" -3214- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,23 */
                                        CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.23;

                                        /*" -3215- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3216- IF CSP-PER-240 */

                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
                                        {

                                            /*" -3217- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,25 */
                                            CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.25;

                                            /*" -3218- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3219- IF CSP-PER-270 */

                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
                                            {

                                                /*" -3220- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,27 */
                                                CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.27;

                                                /*" -3221- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3222- IF CSP-PER-300 */

                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
                                                {

                                                    /*" -3223- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,29 */
                                                    CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.29;

                                                    /*" -3224- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3225- IF CSP-PER-330 */

                                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
                                                    {

                                                        /*" -3226- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,31 */
                                                        CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.31;

                                                        /*" -3227- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -3228- IF CSP-PER-360 */

                                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
                                                        {

                                                            /*" -3229- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,33 */
                                                            CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.33;

                                                            /*" -3230- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -3231- IF CSP-PER-364 */

                                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"])
                                                            {

                                                                /*" -3232- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,35 */
                                                                CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.35;

                                                                /*" -3233- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -3234- IF CSP-PER-366 */

                                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_366"])
                                                                {

                                                                    /*" -3234- COMPUTE CSP-VRPARCDM = CSP-VRPLARDM * 0,30. */
                                                                    CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPLARDM * 0.30;
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/

        [StopWatch]
        /*" M-290-000-TRATA-ITEM-T-SECTION */
        private void M_290_000_TRATA_ITEM_T_SECTION()
        {
            /*" -3247- MOVE '290-000-TRATA-ITEM-T  ' TO CSP-PROCPAR. */
            _.Move("290-000-TRATA-ITEM-T  ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3249- IF CSP-VRISRCDP EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISRCDP == 00)
            {

                /*" -3251- GO TO 290-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_290_999_EXIT*/ //GOTO
                return;
            }


            /*" -3252- MOVE 18 TO NIVCS-CODTAB */
            _.Move(18, CSP_RETORNO.NIVCS_CODTAB);

            /*" -3253- MOVE ZEROS TO NIVCS-CODPRODU */
            _.Move(0, CSP_RETORNO.NIVCS_CODPRODU);

            /*" -3255- MOVE CSP-DTINIRCDP TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIRCDP, WDATA_NUM, WS_DATA1);

            /*" -3256- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -3257- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -3258- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -3260- MOVE WDATA-CHAR TO NIVCS-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.NIVCS_DTINIVIG);

            /*" -3262- COMPUTE NIVCS-IMPSEGBT = CSP-VRISRCDP / WS-VLCRUZAD-IS */
            CSP_RETORNO.NIVCS_IMPSEGBT.Value = CSP_REGISTRO.CSP_VRISRCDP / WS_VLCRUZAD_IS;

            /*" -3264- MOVE '237-000 - PESQUISA NIVEL RCF DP' TO CSP-MSG. */
            _.Move("237-000 - PESQUISA NIVEL RCF DP", CSP_RETORNO.CSP_MSG);

            /*" -3266- PERFORM 237-000-PESQ-V1NIVELCAP-BTN. */

            M_237_000_PESQ_V1NIVELCAP_BTN_SECTION();

            /*" -3267- MOVE 20 TO CFRCF-CODTAB */
            _.Move(20, CSP_RETORNO.CFRCF_CODTAB);

            /*" -3268- MOVE ZEROS TO CFRCF-CODPRODU */
            _.Move(0, CSP_RETORNO.CFRCF_CODPRODU);

            /*" -3269- MOVE NIVCS-NIVEL TO CFRCF-NIVEL */
            _.Move(CSP_RETORNO.NIVCS_NIVEL, CSP_RETORNO.CFRCF_NIVEL);

            /*" -3271- MOVE CSP-DTINIRCDP TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIRCDP, WDATA_NUM, WS_DATA1);

            /*" -3272- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -3273- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -3274- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -3275- MOVE WDATA-CHAR TO CFRCF-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.CFRCF_DTINIVIG);

            /*" -3276- PERFORM 240-000-PESQ-V1RCFCOEFIC */

            M_240_000_PESQ_V1RCFCOEFIC_SECTION();

            /*" -3276- PERFORM 300-000-TRATA-PRBAS-RCDP. */

            M_300_000_TRATA_PRBAS_RCDP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_290_999_EXIT*/

        [StopWatch]
        /*" M-300-000-TRATA-PRBAS-RCDP-SECTION */
        private void M_300_000_TRATA_PRBAS_RCDP_SECTION()
        {
            /*" -3289- MOVE '300-000-              ' TO CSP-PROCPAR. */
            _.Move("300-000-              ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3290- IF CSP-VRPRRCDP EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRPRRCDP == 00)
            {

                /*" -3291- MOVE 11 TO CATTF-CODTAB */
                _.Move(11, CSP_RETORNO.CATTF_CODTAB);

                /*" -3292- MOVE ZEROS TO CATTF-CODPRODU */
                _.Move(0, CSP_RETORNO.CATTF_CODPRODU);

                /*" -3293- MOVE CSP-CATTARIR TO CATTF-CATTARIF */
                _.Move(CSP_REGISTRO.CSP_CATTARIR, CSP_RETORNO.CATTF_CATTARIF);

                /*" -3294- MOVE CSP-REGIAO TO CATTF-REGIAO */
                _.Move(CSP_REGISTRO.CSP_REGIAO, CSP_RETORNO.CATTF_REGIAO);

                /*" -3296- MOVE CSP-DTINIRCDP TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIRCDP, WDATA_NUM, WS_DATA1);

                /*" -3297- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3298- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3299- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3300- MOVE WDATA-CHAR TO CATTF-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.CATTF_DTINIVIG);

                /*" -3303- MOVE '160-000 - PREMIO BAS. ANUAL - RCFV - DP NAO CADASTRADO' TO CSP-MSG */
                _.Move("160-000 - PREMIO BAS. ANUAL - RCFV - DP NAO CADASTRADO", CSP_RETORNO.CSP_MSG);

                /*" -3304- PERFORM 160-000-PESQ-V1CATTARIFA */

                M_160_000_PESQ_V1CATTARIFA_SECTION();

                /*" -3305- IF CATTF-PREBASBT EQUAL ZEROS */

                if (CSP_RETORNO.CATTF_PREBASBT == 00)
                {

                    /*" -3306- MOVE CATTF-VLPRTXCF TO CSP-TPRBRCDP */
                    _.Move(CSP_RETORNO.CATTF_VLPRTXCF, CSP_REGISTRO.CSP_TPRBRCDP);

                    /*" -3307- ELSE */
                }
                else
                {


                    /*" -3308- COMPUTE CSP-TPRBRCDP = CATTF-PREBASBT * WS-VLCRUZAD */
                    CSP_REGISTRO.CSP_TPRBRCDP.Value = CSP_RETORNO.CATTF_PREBASBT * WS_VLCRUZAD;

                    /*" -3309- ELSE */
                }

            }
            else
            {


                /*" -3314- MOVE CSP-VRPRRCDP TO CSP-TPRBRCDP. */
                _.Move(CSP_REGISTRO.CSP_VRPRRCDP, CSP_REGISTRO.CSP_TPRBRCDP);
            }


            /*" -3315- COMPUTE WS-ITEM-T = CSP-TPRBRCDP * CFRCF-COEFIC */
            CSP_RETORNO.WS_ITEM_T.Value = CSP_REGISTRO.CSP_TPRBRCDP * CSP_RETORNO.CFRCF_COEFIC;

            /*" -3315- MOVE CFRCF-COEFIC TO CSP-TCFPBRDP. */
            _.Move(CSP_RETORNO.CFRCF_COEFIC, CSP_REGISTRO.CSP_TCFPBRDP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-310-000-TRATA-BONUS-RCFDP-SECTION */
        private void M_310_000_TRATA_BONUS_RCFDP_SECTION()
        {
            /*" -3322- MOVE '310-000-TRATA-BONUS-RCFDP' TO CSP-PROCPAR. */
            _.Move("310-000-TRATA-BONUS-RCFDP", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3323- COMPUTE CSP-VRPLARDP = WS-ITEM-T * (100 - CSP-TPCBONDP) / 100. */
            CSP_REGISTRO.CSP_VRPLARDP.Value = CSP_RETORNO.WS_ITEM_T * (100 - CSP_REGISTRO.CSP_TPCBONDP) / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_999_EXIT*/

        [StopWatch]
        /*" M-320-000-APLIC-DESC-FROTA-RCDP-SECTION */
        private void M_320_000_APLIC_DESC_FROTA_RCDP_SECTION()
        {
            /*" -3333- MOVE '320-000-APLIC-DESC-FROTA-RCDP' TO CSP-PROCPAR. */
            _.Move("320-000-APLIC-DESC-FROTA-RCDP", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3335- IF CSP-DESCFROT EQUAL ZEROS NEXT SENTENCE */

            if (CSP_REGISTRO.CSP_DESCFROT == 00)
            {

                /*" -3336- ELSE */
            }
            else
            {


                /*" -3337- COMPUTE CSP-VRPLARDP = CSP-VRPLARDP * (100 - CSP-DESCFROT) / 100. */
                CSP_REGISTRO.CSP_VRPLARDP.Value = CSP_REGISTRO.CSP_VRPLARDP * (100 - CSP_REGISTRO.CSP_DESCFROT) / 100f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_999_EXIT*/

        [StopWatch]
        /*" M-330-000-CALC-PRO-RATA-PZCURTO-SECTION */
        private void M_330_000_CALC_PRO_RATA_PZCURTO_SECTION()
        {
            /*" -3351- MOVE '330-000-CALC-PRO-RATA-PZCURTO' TO CSP-PROCPAR. */
            _.Move("330-000-CALC-PRO-RATA-PZCURTO", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3353- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -3354- COMPUTE CSP-VRPLRCDP = CSP-VRPLARDP * CSP-TPCPZSEG / 100 */
                CSP_REGISTRO.CSP_VRPLRCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                /*" -3356- ELSE */
            }
            else
            {


                /*" -3361- COMPUTE CSP-VRPLRCDP = CSP-VRPLARDP * CSP-PRAZOSEG / 365. */
                CSP_REGISTRO.CSP_VRPLRCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
            }


            /*" -3362- IF CSP-EXTPER EQUAL '1' */

            if (CSP_REGISTRO.CSP_EXTPER == "1")
            {

                /*" -3362- PERFORM 340-000-TRATA-EXTENSAO-RCDP. */

                M_340_000_TRATA_EXTENSAO_RCDP_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-340-000-TRATA-EXTENSAO-RCDP-SECTION */
        private void M_340_000_TRATA_EXTENSAO_RCDP_SECTION()
        {
            /*" -3375- MOVE '340-000-TRATA-EXTENSAO-RCDP' TO CSP-PROCPAR. */
            _.Move("340-000-TRATA-EXTENSAO-RCDP", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3376- MOVE ZEROS TO CSP-VRPARCDP. */
            _.Move(0, CSP_REGISTRO.CSP_VRPARCDP);

            /*" -3377- IF CSP-PER-30 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
            {

                /*" -3378- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,05 */
                CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.05;

                /*" -3379- ELSE */
            }
            else
            {


                /*" -3380- IF CSP-PER-60 */

                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
                {

                    /*" -3381- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,10 */
                    CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.10;

                    /*" -3382- ELSE */
                }
                else
                {


                    /*" -3383- IF CSP-PER-90 */

                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
                    {

                        /*" -3384- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,15 */
                        CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.15;

                        /*" -3385- ELSE */
                    }
                    else
                    {


                        /*" -3386- IF CSP-PER-120 */

                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
                        {

                            /*" -3387- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,17 */
                            CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.17;

                            /*" -3388- ELSE */
                        }
                        else
                        {


                            /*" -3389- IF CSP-PER-150 */

                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
                            {

                                /*" -3390- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,19 */
                                CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.19;

                                /*" -3391- ELSE */
                            }
                            else
                            {


                                /*" -3392- IF CSP-PER-180 */

                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
                                {

                                    /*" -3393- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,21 */
                                    CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.21;

                                    /*" -3394- ELSE */
                                }
                                else
                                {


                                    /*" -3395- IF CSP-PER-210 */

                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
                                    {

                                        /*" -3396- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,23 */
                                        CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.23;

                                        /*" -3397- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3398- IF CSP-PER-240 */

                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
                                        {

                                            /*" -3399- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,25 */
                                            CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.25;

                                            /*" -3400- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3401- IF CSP-PER-270 */

                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
                                            {

                                                /*" -3402- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,27 */
                                                CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.27;

                                                /*" -3403- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3404- IF CSP-PER-300 */

                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
                                                {

                                                    /*" -3405- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,29 */
                                                    CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.29;

                                                    /*" -3406- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3407- IF CSP-PER-330 */

                                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
                                                    {

                                                        /*" -3408- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,31 */
                                                        CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.31;

                                                        /*" -3409- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -3410- IF CSP-PER-360 */

                                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
                                                        {

                                                            /*" -3411- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,33 */
                                                            CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.33;

                                                            /*" -3412- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -3413- IF CSP-PER-364 */

                                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"])
                                                            {

                                                                /*" -3414- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,35 */
                                                                CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.35;

                                                                /*" -3415- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -3416- IF CSP-PER-366 */

                                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_366"])
                                                                {

                                                                    /*" -3416- COMPUTE CSP-VRPARCDP = CSP-VRPLARDP * 0,30. */
                                                                    CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPLARDP * 0.30;
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_340_999_EXIT*/

        [StopWatch]
        /*" M-332-000-TRATA-ITEM-V-SECTION */
        private void M_332_000_TRATA_ITEM_V_SECTION()
        {
            /*" -3429- MOVE '332-000-TRATA-ITEM-V  ' TO CSP-PROCPAR. */
            _.Move("332-000-TRATA-ITEM-V  ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3431- IF CSP-VRISRCDMO EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISRCDMO == 00)
            {

                /*" -3433- GO TO 332-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_332_999_EXIT*/ //GOTO
                return;
            }


            /*" -3434- MOVE 18 TO NIVCS-CODTAB */
            _.Move(18, CSP_RETORNO.NIVCS_CODTAB);

            /*" -3435- MOVE ZEROS TO NIVCS-CODPRODU */
            _.Move(0, CSP_RETORNO.NIVCS_CODPRODU);

            /*" -3437- MOVE CSP-DTINIRCDMO TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIRCDMO, WDATA_NUM, WS_DATA1);

            /*" -3438- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -3439- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -3440- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -3442- MOVE WDATA-CHAR TO NIVCS-DTINIVIG */
            _.Move(WDATA_CHAR, CSP_RETORNO.NIVCS_DTINIVIG);

            /*" -3444- COMPUTE NIVCS-IMPSEGBT = CSP-VRISRCDMO / WS-VLCRUZAD-IS */
            CSP_RETORNO.NIVCS_IMPSEGBT.Value = CSP_REGISTRO.CSP_VRISRCDMO / WS_VLCRUZAD_IS;

            /*" -3446- MOVE '237-000 - PESQUISA NIVEL RCF DMO' TO CSP-MSG. */
            _.Move("237-000 - PESQUISA NIVEL RCF DMO", CSP_RETORNO.CSP_MSG);

            /*" -3448- PERFORM 237-000-PESQ-V1NIVELCAP-BTN. */

            M_237_000_PESQ_V1NIVELCAP_BTN_SECTION();

            /*" -3448- PERFORM 333-000-TRATA-PRBAS-RCDMO. */

            M_333_000_TRATA_PRBAS_RCDMO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_332_999_EXIT*/

        [StopWatch]
        /*" M-333-000-TRATA-PRBAS-RCDMO-SECTION */
        private void M_333_000_TRATA_PRBAS_RCDMO_SECTION()
        {
            /*" -3461- MOVE '333-000-              ' TO CSP-PROCPAR. */
            _.Move("333-000-              ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3462- IF CSP-VRPRRCDMO EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRPRRCDMO == 00)
            {

                /*" -3466- IF CSP-CATTARIR EQUAL 10 OR 11 OR 14 OR 15 OR 16 OR 17 OR 18 OR 19 OR 20 OR 21 OR 22 OR 23 */

                if (CSP_REGISTRO.CSP_CATTARIR.In("10", "11", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"))
                {

                    /*" -3467- MOVE 60 TO CATTF-CODTAB */
                    _.Move(60, CSP_RETORNO.CATTF_CODTAB);

                    /*" -3468- ELSE */
                }
                else
                {


                    /*" -3469- MOVE 61 TO CATTF-CODTAB */
                    _.Move(61, CSP_RETORNO.CATTF_CODTAB);

                    /*" -3470- END-IF */
                }


                /*" -3471- MOVE ZEROS TO CATTF-CODPRODU */
                _.Move(0, CSP_RETORNO.CATTF_CODPRODU);

                /*" -3472- MOVE ZEROS TO CATTF-CATTARIF */
                _.Move(0, CSP_RETORNO.CATTF_CATTARIF);

                /*" -3473- MOVE CSP-VRISRCDMO TO CATTF-VLPRTXCF */
                _.Move(CSP_REGISTRO.CSP_VRISRCDMO, CSP_RETORNO.CATTF_VLPRTXCF);

                /*" -3474- COMPUTE CATTF-VLPRTXCF1 = CATTF-VLPRTXCF + 0,01 */
                CSP_RETORNO.CATTF_VLPRTXCF1.Value = CSP_RETORNO.CATTF_VLPRTXCF + 0.01;

                /*" -3476- MOVE CSP-DTINIRCDMO TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIRCDMO, WDATA_NUM, WS_DATA1);

                /*" -3477- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3478- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3479- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3480- MOVE WDATA-CHAR TO CATTF-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.CATTF_DTINIVIG);

                /*" -3483- MOVE '160-000 - PREMIO BAS. ANUAL - RCFV - DMO NAO CADASTRADO' TO CSP-MSG */
                _.Move("160-000 - PREMIO BAS. ANUAL - RCFV - DMO NAO CADASTRADO", CSP_RETORNO.CSP_MSG);

                /*" -3484- PERFORM 162-000-PESQ-V1CATTARIFA */

                M_162_000_PESQ_V1CATTARIFA_SECTION();

                /*" -3485- IF CATTF-PREBASBT EQUAL ZEROS */

                if (CSP_RETORNO.CATTF_PREBASBT == 00)
                {

                    /*" -3486- MOVE CATTF-VLPRTXCF TO CSP-TPRBRCDMO */
                    _.Move(CSP_RETORNO.CATTF_VLPRTXCF, CSP_REGISTRO.CSP_TPRBRCDMO);

                    /*" -3487- ELSE */
                }
                else
                {


                    /*" -3488- COMPUTE CSP-TPRBRCDMO = CATTF-PREBASBT * WS-VLCRUZAD */
                    CSP_REGISTRO.CSP_TPRBRCDMO.Value = CSP_RETORNO.CATTF_PREBASBT * WS_VLCRUZAD;

                    /*" -3489- ELSE */
                }

            }
            else
            {


                /*" -3494- MOVE CSP-VRPRRCDMO TO CSP-TPRBRCDMO. */
                _.Move(CSP_REGISTRO.CSP_VRPRRCDMO, CSP_REGISTRO.CSP_TPRBRCDMO);
            }


            /*" -3495- COMPUTE WS-ITEM-V = CSP-TPRBRCDMO * 1 */
            CSP_RETORNO.WS_ITEM_V.Value = CSP_REGISTRO.CSP_TPRBRCDMO * 1;

            /*" -3495- MOVE 1 TO CSP-TCFPBRDMO. */
            _.Move(1, CSP_REGISTRO.CSP_TCFPBRDMO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_333_999_EXIT*/

        [StopWatch]
        /*" M-334-000-TRATA-BONUS-RCFDMO-SECTION */
        private void M_334_000_TRATA_BONUS_RCFDMO_SECTION()
        {
            /*" -3502- MOVE '334-000-TRATA-BONUS-RCFDMO' TO CSP-PROCPAR. */
            _.Move("334-000-TRATA-BONUS-RCFDMO", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3503- COMPUTE CSP-VRPLARDMO = WS-ITEM-V * (100 - CSP-TPCBONDMO) / 100. */
            CSP_REGISTRO.CSP_VRPLARDMO.Value = CSP_RETORNO.WS_ITEM_V * (100 - CSP_REGISTRO.CSP_TPCBONDMO) / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_334_999_EXIT*/

        [StopWatch]
        /*" M-336-000-APLIC-DESC-FROTA-RCDMO-SECTION */
        private void M_336_000_APLIC_DESC_FROTA_RCDMO_SECTION()
        {
            /*" -3513- MOVE '336-000-APLIC-DESC-FROTA-RCDMO' TO CSP-PROCPAR. */
            _.Move("336-000-APLIC-DESC-FROTA-RCDMO", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3515- IF CSP-DESCFROT EQUAL ZEROS NEXT SENTENCE */

            if (CSP_REGISTRO.CSP_DESCFROT == 00)
            {

                /*" -3516- ELSE */
            }
            else
            {


                /*" -3517- COMPUTE CSP-VRPLARDMO = CSP-VRPLARDMO * (100 - CSP-DESCFROT) / 100. */
                CSP_REGISTRO.CSP_VRPLARDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * (100 - CSP_REGISTRO.CSP_DESCFROT) / 100f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_336_999_EXIT*/

        [StopWatch]
        /*" M-338-000-CALC-PRO-RATA-PZCURTO-SECTION */
        private void M_338_000_CALC_PRO_RATA_PZCURTO_SECTION()
        {
            /*" -3531- MOVE '338-000-CALC-PRO-RATA-PZCURTO' TO CSP-PROCPAR. */
            _.Move("338-000-CALC-PRO-RATA-PZCURTO", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3533- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -3534- COMPUTE CSP-VRPLRCDMO = CSP-VRPLARDMO * CSP-TPCPZSEG / 100 */
                CSP_REGISTRO.CSP_VRPLRCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                /*" -3536- ELSE */
            }
            else
            {


                /*" -3541- COMPUTE CSP-VRPLRCDMO = CSP-VRPLARDMO * CSP-PRAZOSEG / 365. */
                CSP_REGISTRO.CSP_VRPLRCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
            }


            /*" -3542- IF CSP-EXTPER EQUAL '1' */

            if (CSP_REGISTRO.CSP_EXTPER == "1")
            {

                /*" -3542- PERFORM 339-000-TRATA-EXTENSAO-RCDMO. */

                M_339_000_TRATA_EXTENSAO_RCDMO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_338_999_EXIT*/

        [StopWatch]
        /*" M-339-000-TRATA-EXTENSAO-RCDMO-SECTION */
        private void M_339_000_TRATA_EXTENSAO_RCDMO_SECTION()
        {
            /*" -3555- MOVE '339-000-TRATA-EXTENSAO-RCDMO' TO CSP-PROCPAR. */
            _.Move("339-000-TRATA-EXTENSAO-RCDMO", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3556- MOVE ZEROS TO CSP-VRPARCDMO. */
            _.Move(0, CSP_REGISTRO.CSP_VRPARCDMO);

            /*" -3557- IF CSP-PER-30 */

            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
            {

                /*" -3558- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,05 */
                CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.05;

                /*" -3559- ELSE */
            }
            else
            {


                /*" -3560- IF CSP-PER-60 */

                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
                {

                    /*" -3561- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,10 */
                    CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.10;

                    /*" -3562- ELSE */
                }
                else
                {


                    /*" -3563- IF CSP-PER-90 */

                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
                    {

                        /*" -3564- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,15 */
                        CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.15;

                        /*" -3565- ELSE */
                    }
                    else
                    {


                        /*" -3566- IF CSP-PER-120 */

                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
                        {

                            /*" -3567- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,17 */
                            CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.17;

                            /*" -3568- ELSE */
                        }
                        else
                        {


                            /*" -3569- IF CSP-PER-150 */

                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
                            {

                                /*" -3570- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,19 */
                                CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.19;

                                /*" -3571- ELSE */
                            }
                            else
                            {


                                /*" -3572- IF CSP-PER-180 */

                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
                                {

                                    /*" -3573- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,21 */
                                    CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.21;

                                    /*" -3574- ELSE */
                                }
                                else
                                {


                                    /*" -3575- IF CSP-PER-210 */

                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
                                    {

                                        /*" -3576- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,23 */
                                        CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.23;

                                        /*" -3577- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3578- IF CSP-PER-240 */

                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
                                        {

                                            /*" -3579- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,25 */
                                            CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.25;

                                            /*" -3580- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3581- IF CSP-PER-270 */

                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
                                            {

                                                /*" -3582- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,27 */
                                                CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.27;

                                                /*" -3583- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3584- IF CSP-PER-300 */

                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
                                                {

                                                    /*" -3585- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,29 */
                                                    CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.29;

                                                    /*" -3586- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3587- IF CSP-PER-330 */

                                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
                                                    {

                                                        /*" -3588- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,31 */
                                                        CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.31;

                                                        /*" -3589- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -3590- IF CSP-PER-360 */

                                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
                                                        {

                                                            /*" -3591- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,33 */
                                                            CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.33;

                                                            /*" -3592- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -3593- IF CSP-PER-364 */

                                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"])
                                                            {

                                                                /*" -3594- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,35 */
                                                                CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.35;

                                                                /*" -3595- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -3596- IF CSP-PER-366 */

                                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_366"])
                                                                {

                                                                    /*" -3596- COMPUTE CSP-VRPARCDMO = CSP-VRPLARDMO * 0,30. */
                                                                    CSP_REGISTRO.CSP_VRPARCDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO * 0.30;
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_339_999_EXIT*/

        [StopWatch]
        /*" M-350-000-TRATA-ITEM-X-SECTION */
        private void M_350_000_TRATA_ITEM_X_SECTION()
        {
            /*" -3609- MOVE '350-000-              ' TO CSP-PROCPAR. */
            _.Move("350-000-              ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3610- IF CSP-VRISAPPM NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPM != 00)
            {

                /*" -3611- MOVE 29 TO TXAPP-CODTAB */
                _.Move(29, CSP_RETORNO.TXAPP_CODTAB);

                /*" -3613- MOVE CSP-DTINIAPPM TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIAPPM, WDATA_NUM, WS_DATA1);

                /*" -3614- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3615- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3616- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3617- MOVE WDATA-CHAR TO TXAPP-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.TXAPP_DTINIVIG);

                /*" -3618- PERFORM 360-000-PESQ-V1TAXASAPP */

                M_360_000_PESQ_V1TAXASAPP_SECTION();

                /*" -3619- MOVE TXAPP-TAXAAPPM TO CSP-TTXAPPM */
                _.Move(CSP_RETORNO.TXAPP_TAXAAPPM, CSP_REGISTRO.CSP_TTXAPPM);

                /*" -3621- COMPUTE WS-ITEM-X1 = CSP-VRISAPPM * TXAPP-TAXAAPPM / 100 */
                CSP_RETORNO.WS_ITEM_X1.Value = CSP_REGISTRO.CSP_VRISAPPM * CSP_RETORNO.TXAPP_TAXAAPPM / 100f;

                /*" -3623- COMPUTE WS-ITEM-X2 = WS-ITEM-X1 * CSP-NUMPASSG */
                CSP_RETORNO.WS_ITEM_X2.Value = CSP_RETORNO.WS_ITEM_X1 * CSP_REGISTRO.CSP_NUMPASSG;

                /*" -3625- COMPUTE WS-ITEM-X3 ROUNDED = WS-ITEM-X2 * (100 - CSP-TPCBONDM) / 100. */
                CSP_RETORNO.WS_ITEM_X3.Value = CSP_RETORNO.WS_ITEM_X2 * (100 - CSP_REGISTRO.CSP_TPCBONDM) / 100f;
            }


            /*" -3627- MOVE WS-ITEM-X3 TO CSP-VRPLAAPM. */
            _.Move(CSP_RETORNO.WS_ITEM_X3, CSP_REGISTRO.CSP_VRPLAAPM);

            /*" -3628- IF CSP-VRISAPPM NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPM != 00)
            {

                /*" -3630- IF CSP-IDEPZSEG EQUAL 'S' */

                if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
                {

                    /*" -3631- COMPUTE CSP-VRPLAPPM = WS-ITEM-X3 * CSP-TPCPZSEG / 100 */
                    CSP_REGISTRO.CSP_VRPLAPPM.Value = CSP_RETORNO.WS_ITEM_X3 * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                    /*" -3633- ELSE */
                }
                else
                {


                    /*" -3640- COMPUTE CSP-VRPLAPPM = WS-ITEM-X3 * CSP-PRAZOSEG / 365. */
                    CSP_REGISTRO.CSP_VRPLAPPM.Value = CSP_RETORNO.WS_ITEM_X3 * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
                }

            }


            /*" -3641- IF CSP-VRISAPPI NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPI != 00)
            {

                /*" -3642- MOVE 29 TO TXAPP-CODTAB */
                _.Move(29, CSP_RETORNO.TXAPP_CODTAB);

                /*" -3644- MOVE CSP-DTINIAPPI TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIAPPI, WDATA_NUM, WS_DATA1);

                /*" -3645- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3646- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3647- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3648- MOVE WDATA-CHAR TO TXAPP-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.TXAPP_DTINIVIG);

                /*" -3649- PERFORM 360-000-PESQ-V1TAXASAPP */

                M_360_000_PESQ_V1TAXASAPP_SECTION();

                /*" -3650- MOVE TXAPP-TAXAAPPI TO CSP-TTXAPPI */
                _.Move(CSP_RETORNO.TXAPP_TAXAAPPI, CSP_REGISTRO.CSP_TTXAPPI);

                /*" -3651- COMPUTE WS-ITEM-X4 = CSP-VRISAPPI * TXAPP-TAXAAPPI / 100 */
                CSP_RETORNO.WS_ITEM_X4.Value = CSP_REGISTRO.CSP_VRISAPPI * CSP_RETORNO.TXAPP_TAXAAPPI / 100f;

                /*" -3652- COMPUTE WS-ITEM-X5 = WS-ITEM-X4 * CSP-NUMPASSG */
                CSP_RETORNO.WS_ITEM_X5.Value = CSP_RETORNO.WS_ITEM_X4 * CSP_REGISTRO.CSP_NUMPASSG;

                /*" -3655- COMPUTE WS-ITEM-X6 ROUNDED = WS-ITEM-X5 * (100 - CSP-TPCBONDM) / 100. */
                CSP_RETORNO.WS_ITEM_X6.Value = CSP_RETORNO.WS_ITEM_X5 * (100 - CSP_REGISTRO.CSP_TPCBONDM) / 100f;
            }


            /*" -3656- MOVE WS-ITEM-X6 TO CSP-VRPLAAPI. */
            _.Move(CSP_RETORNO.WS_ITEM_X6, CSP_REGISTRO.CSP_VRPLAAPI);

            /*" -3657- IF CSP-VRISAPPI NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPI != 00)
            {

                /*" -3659- IF CSP-IDEPZSEG EQUAL 'S' */

                if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
                {

                    /*" -3660- COMPUTE CSP-VRPLAPPI = WS-ITEM-X6 * CSP-TPCPZSEG / 100 */
                    CSP_REGISTRO.CSP_VRPLAPPI.Value = CSP_RETORNO.WS_ITEM_X6 * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                    /*" -3662- ELSE */
                }
                else
                {


                    /*" -3667- COMPUTE CSP-VRPLAPPI = WS-ITEM-X6 * CSP-PRAZOSEG / 365. */
                    CSP_REGISTRO.CSP_VRPLAPPI.Value = CSP_RETORNO.WS_ITEM_X6 * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
                }

            }


            /*" -3668- IF CSP-VRISAPPA NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPA != 00)
            {

                /*" -3669- MOVE 29 TO TXAPP-CODTAB */
                _.Move(29, CSP_RETORNO.TXAPP_CODTAB);

                /*" -3671- MOVE CSP-DTINIAPPA TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIAPPA, WDATA_NUM, WS_DATA1);

                /*" -3672- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3673- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3674- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3675- MOVE WDATA-CHAR TO TXAPP-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.TXAPP_DTINIVIG);

                /*" -3676- PERFORM 360-000-PESQ-V1TAXASAPP */

                M_360_000_PESQ_V1TAXASAPP_SECTION();

                /*" -3677- MOVE TXAPP-TAXAAPPA TO CSP-TTXAPPA */
                _.Move(CSP_RETORNO.TXAPP_TAXAAPPA, CSP_REGISTRO.CSP_TTXAPPA);

                /*" -3678- COMPUTE WS-ITEM-X7 = CSP-VRISAPPA * TXAPP-TAXAAPPA / 100 */
                CSP_RETORNO.WS_ITEM_X7.Value = CSP_REGISTRO.CSP_VRISAPPA * CSP_RETORNO.TXAPP_TAXAAPPA / 100f;

                /*" -3679- COMPUTE WS-ITEM-X8 = WS-ITEM-X7 * CSP-NUMPASSG */
                CSP_RETORNO.WS_ITEM_X8.Value = CSP_RETORNO.WS_ITEM_X7 * CSP_REGISTRO.CSP_NUMPASSG;

                /*" -3682- COMPUTE WS-ITEM-X9 ROUNDED = WS-ITEM-X8 * (100 - CSP-TPCBONDM) / 100. */
                CSP_RETORNO.WS_ITEM_X9.Value = CSP_RETORNO.WS_ITEM_X8 * (100 - CSP_REGISTRO.CSP_TPCBONDM) / 100f;
            }


            /*" -3683- MOVE WS-ITEM-X9 TO CSP-VRPLAAPA. */
            _.Move(CSP_RETORNO.WS_ITEM_X9, CSP_REGISTRO.CSP_VRPLAAPA);

            /*" -3684- IF CSP-VRISAPPA NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPA != 00)
            {

                /*" -3686- IF CSP-IDEPZSEG EQUAL 'S' */

                if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
                {

                    /*" -3687- COMPUTE CSP-VRPLAPPA = WS-ITEM-X9 * CSP-TPCPZSEG / 100 */
                    CSP_REGISTRO.CSP_VRPLAPPA.Value = CSP_RETORNO.WS_ITEM_X9 * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                    /*" -3689- ELSE */
                }
                else
                {


                    /*" -3694- COMPUTE CSP-VRPLAPPA = WS-ITEM-X9 * CSP-PRAZOSEG / 365. */
                    CSP_REGISTRO.CSP_VRPLAPPA.Value = CSP_RETORNO.WS_ITEM_X9 * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
                }

            }


            /*" -3695- IF CSP-VRISAPPD NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPD != 00)
            {

                /*" -3696- MOVE 29 TO TXAPP-CODTAB */
                _.Move(29, CSP_RETORNO.TXAPP_CODTAB);

                /*" -3698- MOVE CSP-DTINIAPPD TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIAPPD, WDATA_NUM, WS_DATA1);

                /*" -3699- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -3700- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -3701- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -3702- MOVE WDATA-CHAR TO TXAPP-DTINIVIG */
                _.Move(WDATA_CHAR, CSP_RETORNO.TXAPP_DTINIVIG);

                /*" -3703- PERFORM 360-000-PESQ-V1TAXASAPP */

                M_360_000_PESQ_V1TAXASAPP_SECTION();

                /*" -3704- MOVE TXAPP-TAXAAPPD TO CSP-TTXAPPD */
                _.Move(CSP_RETORNO.TXAPP_TAXAAPPD, CSP_REGISTRO.CSP_TTXAPPD);

                /*" -3705- COMPUTE WS-ITEM-X10 = CSP-VRISAPPD * TXAPP-TAXAAPPD / 100 */
                CSP_RETORNO.WS_ITEM_X10.Value = CSP_REGISTRO.CSP_VRISAPPD * CSP_RETORNO.TXAPP_TAXAAPPD / 100f;

                /*" -3706- COMPUTE WS-ITEM-X11 = WS-ITEM-X10 * CSP-NUMPASSG */
                CSP_RETORNO.WS_ITEM_X11.Value = CSP_RETORNO.WS_ITEM_X10 * CSP_REGISTRO.CSP_NUMPASSG;

                /*" -3709- COMPUTE WS-ITEM-X12 ROUNDED = WS-ITEM-X11 * (100 - CSP-TPCBONDM) / 100. */
                CSP_RETORNO.WS_ITEM_X12.Value = CSP_RETORNO.WS_ITEM_X11 * (100 - CSP_REGISTRO.CSP_TPCBONDM) / 100f;
            }


            /*" -3710- MOVE WS-ITEM-X12 TO CSP-VRPLAAPD. */
            _.Move(CSP_RETORNO.WS_ITEM_X12, CSP_REGISTRO.CSP_VRPLAAPD);

            /*" -3711- IF CSP-VRISAPPD NOT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_VRISAPPD != 00)
            {

                /*" -3713- IF CSP-IDEPZSEG EQUAL 'S' */

                if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
                {

                    /*" -3714- COMPUTE CSP-VRPLAPPD = WS-ITEM-X12 * CSP-TPCPZSEG / 100 */
                    CSP_REGISTRO.CSP_VRPLAPPD.Value = CSP_RETORNO.WS_ITEM_X12 * CSP_REGISTRO.CSP_TPCPZSEG / 100f;

                    /*" -3716- ELSE */
                }
                else
                {


                    /*" -3716- COMPUTE CSP-VRPLAPPD = WS-ITEM-X12 * CSP-PRAZOSEG / 365. */
                    CSP_REGISTRO.CSP_VRPLAPPD.Value = CSP_RETORNO.WS_ITEM_X12 * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/

        [StopWatch]
        /*" M-360-000-PESQ-V1TAXASAPP-SECTION */
        private void M_360_000_PESQ_V1TAXASAPP_SECTION()
        {
            /*" -3724- MOVE '360-000-              ' TO CSP-PROCPAR. */
            _.Move("360-000-              ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3735- PERFORM M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1 */

            M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1();

            /*" -3737- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3738- MOVE 'TAXAS APLICAVEIS S/ APP         ' TO CSP-LIT */
                _.Move("TAXAS APLICAVEIS S/ APP         ", CSP_RETORNO.CSP_MSG.CSP_LIT);

                /*" -3739- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -3740- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -3741- ELSE */
            }
            else
            {


                /*" -3742- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3743- MOVE '360-000' TO CSP-PROCPAR */
                    _.Move("360-000", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

                    /*" -3744- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -3744- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-360-000-PESQ-V1TAXASAPP-DB-SELECT-1 */
        public void M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1()
        {
            /*" -3735- EXEC SQL SELECT TAXAAPPM, TAXAAPPI, TAXAAPPA, TAXAAPPD INTO :TXAPP-TAXAAPPM, :TXAPP-TAXAAPPI, :TXAPP-TAXAAPPA, :TXAPP-TAXAAPPD FROM SEGUROS.V1TAXASAPP WHERE CODTAB = :TXAPP-CODTAB AND DTINIVIG <= :TXAPP-DTINIVIG AND DTTERVIG >= :TXAPP-DTINIVIG END-EXEC. */

            var m_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1 = new M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1()
            {
                TXAPP_DTINIVIG = CSP_RETORNO.TXAPP_DTINIVIG.ToString(),
                TXAPP_CODTAB = CSP_RETORNO.TXAPP_CODTAB.ToString(),
            };

            var executed_1 = M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1.Execute(m_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TXAPP_TAXAAPPM, CSP_RETORNO.TXAPP_TAXAAPPM);
                _.Move(executed_1.TXAPP_TAXAAPPI, CSP_RETORNO.TXAPP_TAXAAPPI);
                _.Move(executed_1.TXAPP_TAXAAPPA, CSP_RETORNO.TXAPP_TAXAAPPA);
                _.Move(executed_1.TXAPP_TAXAAPPD, CSP_RETORNO.TXAPP_TAXAAPPD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-410-000-TRATA-DESCONTOS-SECTION */
        private void M_410_000_TRATA_DESCONTOS_SECTION()
        {
            /*" -3755- MOVE '410-000-TRATA-DESCONTOS' TO CSP-MSG. */
            _.Move("410-000-TRATA-DESCONTOS", CSP_RETORNO.CSP_MSG);

            /*" -3757- COMPUTE CSP-VRPLCASC = CSP-VRPLCASC * (100 - CSP-PCDESAUT) / 100. */
            CSP_REGISTRO.CSP_VRPLCASC.Value = CSP_REGISTRO.CSP_VRPLCASC * (100 - CSP_REGISTRO.CSP_PCDESAUT) / 100f;

            /*" -3759- COMPUTE CSP-VRPLRCDM = CSP-VRPLRCDM * (100 - CSP-PCDESRCF) / 100. */
            CSP_REGISTRO.CSP_VRPLRCDM.Value = CSP_REGISTRO.CSP_VRPLRCDM * (100 - CSP_REGISTRO.CSP_PCDESRCF) / 100f;

            /*" -3761- COMPUTE CSP-VRPLRCDP = CSP-VRPLRCDP * (100 - CSP-PCDESRCF) / 100. */
            CSP_REGISTRO.CSP_VRPLRCDP.Value = CSP_REGISTRO.CSP_VRPLRCDP * (100 - CSP_REGISTRO.CSP_PCDESRCF) / 100f;

            /*" -3763- COMPUTE CSP-VRPLAPPM = CSP-VRPLAPPM * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAPPM.Value = CSP_REGISTRO.CSP_VRPLAPPM * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3765- COMPUTE CSP-VRPLAPPI = CSP-VRPLAPPI * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAPPI.Value = CSP_REGISTRO.CSP_VRPLAPPI * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3767- COMPUTE CSP-VRPLAPPA = CSP-VRPLAPPA * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAPPA.Value = CSP_REGISTRO.CSP_VRPLAPPA * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3770- COMPUTE CSP-VRPLAPPD = CSP-VRPLAPPD * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAPPD.Value = CSP_REGISTRO.CSP_VRPLAPPD * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3772- COMPUTE CSP-VRPACASC = CSP-VRPACASC * (100 - CSP-PCDESAUT) / 100. */
            CSP_REGISTRO.CSP_VRPACASC.Value = CSP_REGISTRO.CSP_VRPACASC * (100 - CSP_REGISTRO.CSP_PCDESAUT) / 100f;

            /*" -3774- COMPUTE CSP-VRPARCDM = CSP-VRPARCDM * (100 - CSP-PCDESRCF) / 100. */
            CSP_REGISTRO.CSP_VRPARCDM.Value = CSP_REGISTRO.CSP_VRPARCDM * (100 - CSP_REGISTRO.CSP_PCDESRCF) / 100f;

            /*" -3777- COMPUTE CSP-VRPARCDP = CSP-VRPARCDP * (100 - CSP-PCDESRCF) / 100. */
            CSP_REGISTRO.CSP_VRPARCDP.Value = CSP_REGISTRO.CSP_VRPARCDP * (100 - CSP_REGISTRO.CSP_PCDESRCF) / 100f;

            /*" -3779- COMPUTE CSP-VRPLACAS = CSP-VRPLACAS * (100 - CSP-PCDESAUT) / 100. */
            CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRPLACAS * (100 - CSP_REGISTRO.CSP_PCDESAUT) / 100f;

            /*" -3781- COMPUTE CSP-VRPLARDM = CSP-VRPLARDM * (100 - CSP-PCDESRCF) / 100. */
            CSP_REGISTRO.CSP_VRPLARDM.Value = CSP_REGISTRO.CSP_VRPLARDM * (100 - CSP_REGISTRO.CSP_PCDESRCF) / 100f;

            /*" -3783- COMPUTE CSP-VRPLARDP = CSP-VRPLARDP * (100 - CSP-PCDESRCF) / 100. */
            CSP_REGISTRO.CSP_VRPLARDP.Value = CSP_REGISTRO.CSP_VRPLARDP * (100 - CSP_REGISTRO.CSP_PCDESRCF) / 100f;

            /*" -3785- COMPUTE CSP-VRPLAAPM = CSP-VRPLAAPM * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAAPM.Value = CSP_REGISTRO.CSP_VRPLAAPM * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3787- COMPUTE CSP-VRPLAAPI = CSP-VRPLAAPI * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAAPI.Value = CSP_REGISTRO.CSP_VRPLAAPI * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3789- COMPUTE CSP-VRPLAAPA = CSP-VRPLAAPA * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAAPA.Value = CSP_REGISTRO.CSP_VRPLAAPA * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

            /*" -3790- COMPUTE CSP-VRPLAAPD = CSP-VRPLAAPD * (100 - CSP-PCDESAPP) / 100. */
            CSP_REGISTRO.CSP_VRPLAAPD.Value = CSP_REGISTRO.CSP_VRPLAAPD * (100 - CSP_REGISTRO.CSP_PCDESAPP) / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/

        [StopWatch]
        /*" M-430-000-SOMA-PRM-ADICIONAL-SECTION */
        private void M_430_000_SOMA_PRM_ADICIONAL_SECTION()
        {
            /*" -3800- MOVE '430-000-SOMA-PRM-ADICIONAL' TO CSP-MSG. */
            _.Move("430-000-SOMA-PRM-ADICIONAL", CSP_RETORNO.CSP_MSG);

            /*" -3801- COMPUTE CSP-VRPLACAS = CSP-VRPLACAS + CSP-VRPACASC. */
            CSP_REGISTRO.CSP_VRPLACAS.Value = CSP_REGISTRO.CSP_VRPLACAS + CSP_REGISTRO.CSP_VRPACASC;

            /*" -3802- COMPUTE CSP-VRPLARDM = CSP-VRPLARDM + CSP-VRPARCDM. */
            CSP_REGISTRO.CSP_VRPLARDM.Value = CSP_REGISTRO.CSP_VRPLARDM + CSP_REGISTRO.CSP_VRPARCDM;

            /*" -3803- COMPUTE CSP-VRPLARDP = CSP-VRPLARDP + CSP-VRPARCDP. */
            CSP_REGISTRO.CSP_VRPLARDP.Value = CSP_REGISTRO.CSP_VRPLARDP + CSP_REGISTRO.CSP_VRPARCDP;

            /*" -3803- COMPUTE CSP-VRPLARDMO = CSP-VRPLARDMO + CSP-VRPARCDMO. */
            CSP_REGISTRO.CSP_VRPLARDMO.Value = CSP_REGISTRO.CSP_VRPLARDMO + CSP_REGISTRO.CSP_VRPARCDMO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZAR-SECTION */
        private void M_900_000_FINALIZAR_SECTION()
        {
            /*" -3809- MOVE '900-000-              ' TO CSP-PROCPAR. */
            _.Move("900-000-              ", CSP_RETORNO.CSP_MSG.CSP_PROCPAR);

            /*" -3838- MOVE 0 TO WS-RETORNO WS-PRREF WS-CALCPR WS-CHRET WS-ANOVEICL WS-CALC-DATA WS-CALC-PRAZO WS-CFFROBR WS-CFFRFACC WS-CFPRREF WS-PCDSCFRF WS-PCISCASC WS-PCINCROU WS-ITEM-R WS-ITEM-T WS-ITEM-X WS-ITEM-V WS-ITEM-X1 WS-ITEM-X2 WS-ITEM-X3 WS-ITEM-X4 WS-ITEM-X5 WS-ITEM-X6 WS-ITEM-X7 WS-ITEM-X8 WS-ITEM-X9 WS-ITEM-X10 WS-ITEM-X11 WS-ITEM-X12. */
            _.Move(0, CSP_RETORNO.WS_RETORNO, WS_PRREF, WS_CALCPR, WS_CHRET, WS_ANOVEICL, WS_CALC_DATA, WS_CALC_PRAZO, CSP_RETORNO.WS_CFFROBR, CSP_RETORNO.WS_CFFRFACC, CSP_RETORNO.WS_CFPRREF, CSP_RETORNO.WS_PCDSCFRF, CSP_RETORNO.WS_PCISCASC, CSP_RETORNO.WS_PCINCROU, CSP_RETORNO.WS_ITEM_R, CSP_RETORNO.WS_ITEM_T, CSP_RETORNO.WS_ITEM_X, CSP_RETORNO.WS_ITEM_V, CSP_RETORNO.WS_ITEM_X1, CSP_RETORNO.WS_ITEM_X2, CSP_RETORNO.WS_ITEM_X3, CSP_RETORNO.WS_ITEM_X4, CSP_RETORNO.WS_ITEM_X5, CSP_RETORNO.WS_ITEM_X6, CSP_RETORNO.WS_ITEM_X7, CSP_RETORNO.WS_ITEM_X8, CSP_RETORNO.WS_ITEM_X9, CSP_RETORNO.WS_ITEM_X10, CSP_RETORNO.WS_ITEM_X11, CSP_RETORNO.WS_ITEM_X12);

            /*" -3839- MOVE SPACES TO WS-FLPRREF. */
            _.Move("", CSP_RETORNO.WS_FLPRREF);

            /*" -3841- MOVE ZEROS TO WS-DATA1. */
            _.Move(0, WS_DATA1);

            /*" -3841- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-000-ERRO-SECTION */
        private void M_999_000_ERRO_SECTION()
        {
            /*" -3846- MOVE SQLCODE TO CSP-CODE */
            _.Move(DB.SQLCODE, CSP_RETORNO.CSP_MSG.CSP_CODE);

            /*" -3848- MOVE CSP-RETORNO TO CSP-W01A0077. */
            _.Move(CSP_RETORNO, CSP_REGISTRO.CSP_W01A0077);

            /*" -3848- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT*/

        [StopWatch]
        /*" M-990-000-ABEND-SECTION */
        private void M_990_000_ABEND_SECTION()
        {
            /*" -3853- MOVE 9 TO CSP-W01P0300 */
            _.Move(9, CSP_REGISTRO.CSP_W01P0300);

            /*" -3855- MOVE CSP-RETORNO TO CSP-W01A0077. */
            _.Move(CSP_RETORNO, CSP_REGISTRO.CSP_W01A0077);

            /*" -3855- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_990_999_EXIT*/
    }
}