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
using Sias.Auto.DB2.AU0032S;

namespace Code
{
    public class AU0032S
    {
        public bool IsCall { get; set; }

        public AU0032S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *========================                                               */
        /*"      *REMARKS.                                                               */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *                   S U B R O T I N A    C                    //      */
        /*"      * SISTEMA              =    AUTOMOVEL.   (VERSAO MONAVAL)     //      */
        /*"      * PROGRAMA             =    AU0032S.                          //      */
        /*"      *                                                             //      */
        /*"      * OBJETIVO             =    GERACAO DE CALCULO DE VALOR       //      */
        /*"      *                           DO PREMIO DE ACESSORIO            //      */
        /*"      * ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    //      */
        /*"      * DATA                 =    SETEMBRO/1993                     //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           07/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        #endregion


        #region VARIABLES

        /*"01  WDATA-NUM.*/
        public AU0032S_WDATA_NUM WDATA_NUM { get; set; } = new AU0032S_WDATA_NUM();
        public class AU0032S_WDATA_NUM : VarBasis
        {
            /*"    05  WANO-NUM        PIC   9(004)            VALUE 0.*/
            public IntBasis WANO_NUM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  WMES-NUM        PIC   9(002)            VALUE 0.*/
            public IntBasis WMES_NUM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  WDIA-NUM        PIC   9(002)            VALUE 0.*/
            public IntBasis WDIA_NUM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01  WDATA-CHAR.*/
        }
        public AU0032S_WDATA_CHAR WDATA_CHAR { get; set; } = new AU0032S_WDATA_CHAR();
        public class AU0032S_WDATA_CHAR : VarBasis
        {
            /*"    05  WANO-CHAR       PIC   9(004).*/
            public IntBasis WANO_CHAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  FILLER          PIC   X(001).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  WMES-CHAR       PIC   9(002).*/
            public IntBasis WMES_CHAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  FILLER          PIC   X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  WDIA-CHAR       PIC   9(002).*/
            public IntBasis WDIA_CHAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WS-DATA1.*/
        }
        public AU0032S_WS_DATA1 WS_DATA1 { get; set; } = new AU0032S_WS_DATA1();
        public class AU0032S_WS_DATA1 : VarBasis
        {
            /*"    05  WS-ANO1         PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-MES1         PIC  S9(002)     COMP   VALUE +0.*/
            public IntBasis WS_MES1 { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"));
            /*"    05  WS-DIA1         PIC  S9(002)     COMP   VALUE +0.*/
            public IntBasis WS_DIA1 { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"));
            /*"01  WS-DATA2.*/
        }
        public AU0032S_WS_DATA2 WS_DATA2 { get; set; } = new AU0032S_WS_DATA2();
        public class AU0032S_WS_DATA2 : VarBasis
        {
            /*"    05  WS-DIA2         PIC  S9(002)     COMP   VALUE +0.*/
            public IntBasis WS_DIA2 { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"));
            /*"    05  FILLER          PIC   X(001)            VALUE '/'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05  WS-MES2         PIC  S9(002)     COMP   VALUE +0.*/
            public IntBasis WS_MES2 { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"));
            /*"    05  FILLER          PIC   X(001)            VALUE '/'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05  WS-ANO2         PIC  S9(004)     COMP   VALUE +0.*/
            public IntBasis WS_ANO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01      WS-RETORNO      PIC  S9(004)     COMP   VALUE +0.*/
        }
        public IntBasis WS_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01      WS-ITEM-A       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_A { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-ITEM-B       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_B { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-ITEM-C       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_C { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-ITEM-D       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_D { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-ITEM-E       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_E { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-ITEM-F       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_F { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-ITEM-G       PIC  S9(013)V99  COMP-3 VALUE +0.*/
        public DoubleBasis WS_ITEM_G { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01      WS-AUX-DESC     PIC  S9(011)V9(4) COMP-3 VALUE +0.*/
        public DoubleBasis WS_AUX_DESC { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(4)"), 4);
        /*"01  CSP-RETORNO.*/
        public AU0032S_CSP_RETORNO CSP_RETORNO { get; set; } = new AU0032S_CSP_RETORNO();
        public class AU0032S_CSP_RETORNO : VarBasis
        {
            /*"    05  CSP-PROCPAR     PIC   X(008).*/
            public StringBasis CSP_PROCPAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  FILLER          PIC   X(003)  VALUE ' - '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
            /*"    05  CSP-TBLE        PIC   X(046).*/
            public StringBasis CSP_TBLE { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05  FILLER          PIC   X(003)  VALUE ' - '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
            /*"    05  CSP-CODE        PIC   9(005).*/
            public IntBasis CSP_CODE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  FILLER          PIC   X(012)  VALUE SPACES.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"77  BONUS-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
        }
        public IntBasis BONUS_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  BONUS-CLASSEBN      PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis BONUS_CLASSEBN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  BONUS-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis BONUS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  BONUS-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis BONUS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  BONUS-PCDESC        PIC  S9(003)V99  COMP-3 VALUE +0.*/
        public DoubleBasis BONUS_PCDESC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  BONUS-PCDESCFRANQ   PIC  S9(003)V99  COMP-3 VALUE +0.*/
        public DoubleBasis BONUS_PCDESCFRANQ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  BONUS-DESCPERI      PIC   X(020)            VALUE SPACES.*/
        public StringBasis BONUS_DESCPERI { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"77  BONUS-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
        public StringBasis BONUS_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  CATTF-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis CATTF_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CATTF-CODPRODU      PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis CATTF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CATTF-CATTARIF      PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis CATTF_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CATTF-REGIAO        PIC  S9(004)  COMP      VALUE ZEROS.*/
        public IntBasis CATTF_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CATTF-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis CATTF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  CATTF-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis CATTF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  CATTF-VLPRTXCF      PIC  S9(012)V999 COMP-3 VALUE +0.*/
        public DoubleBasis CATTF_VLPRTXCF { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(012)V999"), 3);
        /*"77  CATTF-PREBASBT      PIC  S9(010)V9(5) COMP-3 VALUE +0.*/
        public DoubleBasis CATTF_PREBASBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  CATTF-DTULTMAN      PIC   X(010)            VALUE SPACES.*/
        public StringBasis CATTF_DTULTMAN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  CATTF-HOULTMAN      PIC   X(008)            VALUE SPACES.*/
        public StringBasis CATTF_HOULTMAN { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  CATTF-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
        public StringBasis CATTF_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  PRAZO-CODTAB        PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis PRAZO_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PRAZO-PRAZOINI      PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis PRAZO_PRAZOINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PRAZO-PRAZOFIM      PIC  S9(004)     COMP   VALUE +0.*/
        public IntBasis PRAZO_PRAZOFIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PRAZO-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis PRAZO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  PRAZO-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis PRAZO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  PRAZO-PCPRMANO      PIC  S9(003)V99  COMP-3 VALUE +0.*/
        public DoubleBasis PRAZO_PCPRMANO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  PRAZO-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
        public StringBasis PRAZO_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  TXACE-CODTAB        PIC  S9(004)     COMP   VALUE ZEROS.*/
        public IntBasis TXACE_CODTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-CODPRODU      PIC  S9(004)     COMP   VALUE ZEROS.*/
        public IntBasis TXACE_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-CDACESS       PIC  S9(004)     COMP   VALUE ZEROS.*/
        public IntBasis TXACE_CDACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-CATTARIF      PIC  S9(004)     COMP   VALUE ZEROS.*/
        public IntBasis TXACE_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-TIPOCOB       PIC  S9(004)     COMP   VALUE ZEROS.*/
        public IntBasis TXACE_TIPOCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-FRANQFAC      PIC   X(001)            VALUE SPACES.*/
        public StringBasis TXACE_FRANQFAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  TXACE-REGIAO        PIC  S9(004)  COMP      VALUE ZEROS.*/
        public IntBasis TXACE_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-TIPACES       PIC  S9(004)     COMP   VALUE ZEROS.*/
        public IntBasis TXACE_TIPACES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  TXACE-DTINIVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis TXACE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  TXACE-DTTERVIG      PIC   X(010)            VALUE SPACES.*/
        public StringBasis TXACE_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  TXACE-TAXACARR      PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
        public DoubleBasis TXACE_TAXACARR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  TXACE-TAXAOUTR      PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
        public DoubleBasis TXACE_TAXAOUTR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  TXACE-TAXAEQUIP     PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
        public DoubleBasis TXACE_TAXAEQUIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  TXACE-TAXAREINT     PIC  S9(003)V99  COMP-3 VALUE ZEROS.*/
        public DoubleBasis TXACE_TAXAREINT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  TXACE-TPULTMAN      PIC   X(001)            VALUE SPACES.*/
        public StringBasis TXACE_TPULTMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  CSP-REGISTRO.*/
        public AU0032S_CSP_REGISTRO CSP_REGISTRO { get; set; } = new AU0032S_CSP_REGISTRO();
        public class AU0032S_CSP_REGISTRO : VarBasis
        {
            /*"    05  CSP-W01P0300    PIC  S9(003)   COMP-3.*/
            public IntBasis CSP_W01P0300 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    05  CSP-DTINIAUTO   PIC   9(008).*/
            public IntBasis CSP_DTINIAUTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  CSP-CLAFRFAC    PIC   X(001).*/
            public StringBasis CSP_CLAFRFAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-CATTARIO    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CATTARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-REGIAO      PIC  S9(004)  COMP.*/
            public IntBasis CSP_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-CLABONAT    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CLABONAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-PCDESCAT    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDESCAT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PCDESAUT    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCDESAUT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-PCINCROU    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCINCROU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
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
							/*" 88  CSP-PER-366 VALUE +365  THRU +366. */
							new SelectorItemBasis("CSP_PER_366", "+365 THRU +366")
                }
            };

            /*"    05  CSP-TIPOVEIC     PIC  S9(004)     COMP.*/
            public IntBasis CSP_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-PRAZOSEG    PIC  S9(004)     COMP.*/
            public IntBasis CSP_PRAZOSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-PCAGPLAC    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_PCAGPLAC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-VRISACCA    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRISACCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-CODACESS    PIC  S9(004)     COMP.*/
            public IntBasis CSP_CODACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-TPACESS     PIC   X(001).*/
            public StringBasis CSP_TPACESS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-ACE         PIC  S9(004)     COMP.*/
            public IntBasis CSP_ACE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-VRPLACES    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRADACES    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRADACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-VRPLAACE    PIC  S9(013)V99  COMP-3.*/
            public DoubleBasis CSP_VRPLAACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05  CSP-TTXISACE    PIC  S9(003)V99  COMP-3.*/
            public DoubleBasis CSP_TTXISACE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    05  CSP-TIPOCOB     PIC  S9(004)     COMP.*/
            public IntBasis CSP_TIPOCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  CSP-IDEPZSEG    PIC   X(001).*/
            public StringBasis CSP_IDEPZSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  CSP-W01A0077    PIC   X(077).*/
            public StringBasis CSP_W01A0077 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(AU0032S_CSP_REGISTRO AU0032S_CSP_REGISTRO_P) //PROCEDURE DIVISION USING 
        /*CSP_REGISTRO*/
        {
            try
            {
                this.CSP_REGISTRO = AU0032S_CSP_REGISTRO_P;

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
            /*" -336- MOVE 'AU0032S - 000-000-PRINCIPAL' TO CSP-RETORNO. */
            _.Move("AU0032S - 000-000-PRINCIPAL", CSP_RETORNO);

            /*" -337- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -340- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -343- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -349- MOVE ZEROS TO CSP-CODE CSP-W01P0300. */
            _.Move(0, CSP_RETORNO.CSP_CODE, CSP_REGISTRO.CSP_W01P0300);

            /*" -351- MOVE '9999-12-31' TO WDATA-CHAR. */
            _.Move("9999-12-31", WDATA_CHAR);

            /*" -353- IF CSP-PRAZOSEG EQUAL ZEROS OR CSP-PRAZOSEG GREATER 365 */

            if (CSP_REGISTRO.CSP_PRAZOSEG == 00 || CSP_REGISTRO.CSP_PRAZOSEG > 365)
            {

                /*" -355- MOVE 365 TO CSP-PRAZOSEG. */
                _.Move(365, CSP_REGISTRO.CSP_PRAZOSEG);
            }


            /*" -356- PERFORM 010-000-TRATA-TXACE. */

            M_010_000_TRATA_TXACE_SECTION();

            /*" -357- PERFORM 030-000-TRATA-PCINCROU. */

            M_030_000_TRATA_PCINCROU_SECTION();

            /*" -358- PERFORM 050-000-TRATA-BONUS. */

            M_050_000_TRATA_BONUS_SECTION();

            /*" -359- PERFORM 100-000-TRATA-PRAZO. */

            M_100_000_TRATA_PRAZO_SECTION();

            /*" -360- PERFORM 150-000-TRATA-ITEM-A. */

            M_150_000_TRATA_ITEM_A_SECTION();

            /*" -361- PERFORM 170-000-TRATA-DESCONTO-AUTO. */

            M_170_000_TRATA_DESCONTO_AUTO_SECTION();

            /*" -362- PERFORM 190-000-TRATA-PREMIO-ANUAL. */

            M_190_000_TRATA_PREMIO_ANUAL_SECTION();

            /*" -363- PERFORM 200-000-TRATA-EXTENSAO-PER. */

            M_200_000_TRATA_EXTENSAO_PER_SECTION();

            /*" -363- PERFORM 900-000-FINALIZAR. */

            M_900_000_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-010-000-TRATA-TXACE-SECTION */
        private void M_010_000_TRATA_TXACE_SECTION()
        {
            /*" -375- MOVE 'AU0032S - 010-000-TRATA-TXACE' TO CSP-RETORNO. */
            _.Move("AU0032S - 010-000-TRATA-TXACE", CSP_RETORNO);

            /*" -376- MOVE 17 TO TXACE-CODTAB. */
            _.Move(17, TXACE_CODTAB);

            /*" -377- MOVE CSP-CATTARIO TO TXACE-CATTARIF. */
            _.Move(CSP_REGISTRO.CSP_CATTARIO, TXACE_CATTARIF);

            /*" -378- MOVE CSP-CLAFRFAC TO TXACE-FRANQFAC. */
            _.Move(CSP_REGISTRO.CSP_CLAFRFAC, TXACE_FRANQFAC);

            /*" -379- MOVE CSP-TIPOCOB TO TXACE-TIPOCOB. */
            _.Move(CSP_REGISTRO.CSP_TIPOCOB, TXACE_TIPOCOB);

            /*" -380- MOVE CSP-REGIAO TO TXACE-REGIAO */
            _.Move(CSP_REGISTRO.CSP_REGIAO, TXACE_REGIAO);

            /*" -384- MOVE ZEROS TO TXACE-CATTARIF TXACE-FRANQFAC TXACE-TIPOCOB TXACE-REGIAO. */
            _.Move(0, TXACE_CATTARIF, TXACE_FRANQFAC, TXACE_TIPOCOB, TXACE_REGIAO);

            /*" -386- MOVE CSP-DTINIAUTO TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM, WS_DATA1);

            /*" -387- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -388- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -389- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -390- MOVE WDATA-CHAR TO TXACE-DTINIVIG */
            _.Move(WDATA_CHAR, TXACE_DTINIVIG);

            /*" -391- MOVE WS-DIA1 TO WS-DIA2 */
            _.Move(WS_DATA1.WS_DIA1, WS_DATA2.WS_DIA2);

            /*" -392- MOVE WS-MES1 TO WS-MES2 */
            _.Move(WS_DATA1.WS_MES1, WS_DATA2.WS_MES2);

            /*" -394- MOVE WS-ANO1 TO WS-ANO2 */
            _.Move(WS_DATA1.WS_ANO1, WS_DATA2.WS_ANO2);

            /*" -396- PERFORM 020-000-PESQ-TATTXACE */

            M_020_000_PESQ_TATTXACE_SECTION();

            /*" -397- COMPUTE WS-ITEM-A = CSP-VRISACCA * CSP-TTXISACE / 100. */
            WS_ITEM_A.Value = CSP_REGISTRO.CSP_VRISACCA * CSP_REGISTRO.CSP_TTXISACE / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_999_EXIT*/

        [StopWatch]
        /*" M-020-000-PESQ-TATTXACE-SECTION */
        private void M_020_000_PESQ_TATTXACE_SECTION()
        {
            /*" -409- MOVE 'AU0032S  - 020-000-PESQ-TATTXACE' TO CSP-RETORNO. */
            _.Move("AU0032S  - 020-000-PESQ-TATTXACE", CSP_RETORNO);

            /*" -428- PERFORM M_020_000_PESQ_TATTXACE_DB_SELECT_1 */

            M_020_000_PESQ_TATTXACE_DB_SELECT_1();

            /*" -431- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -432- MOVE 'AU0032S' TO CSP-PROCPAR */
                _.Move("AU0032S", CSP_RETORNO.CSP_PROCPAR);

                /*" -433- MOVE 'TAXAS ACESSORIOS NAO ENCONTRADAS' TO CSP-TBLE */
                _.Move("TAXAS ACESSORIOS NAO ENCONTRADAS", CSP_RETORNO.CSP_TBLE);

                /*" -434- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -435- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -436- ELSE */
            }
            else
            {


                /*" -437- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -438- MOVE 'AU0032S' TO CSP-PROCPAR */
                    _.Move("AU0032S", CSP_RETORNO.CSP_PROCPAR);

                    /*" -440- MOVE '020-000-PROBLEMAS DE ACESSO - V1TAXACESS' TO CSP-TBLE */
                    _.Move("020-000-PROBLEMAS DE ACESSO - V1TAXACESS", CSP_RETORNO.CSP_TBLE);

                    /*" -441- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -443- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


            /*" -444- IF CSP-TPACESS EQUAL 'C' */

            if (CSP_REGISTRO.CSP_TPACESS == "C")
            {

                /*" -445- MOVE TXACE-TAXACARR TO CSP-TTXISACE */
                _.Move(TXACE_TAXACARR, CSP_REGISTRO.CSP_TTXISACE);

                /*" -446- ELSE */
            }
            else
            {


                /*" -447- IF CSP-TPACESS EQUAL 'A' */

                if (CSP_REGISTRO.CSP_TPACESS == "A")
                {

                    /*" -448- MOVE TXACE-TAXAOUTR TO CSP-TTXISACE */
                    _.Move(TXACE_TAXAOUTR, CSP_REGISTRO.CSP_TTXISACE);

                    /*" -449- ELSE */
                }
                else
                {


                    /*" -449- MOVE TXACE-TAXAEQUIP TO CSP-TTXISACE. */
                    _.Move(TXACE_TAXAEQUIP, CSP_REGISTRO.CSP_TTXISACE);
                }

            }


        }

        [StopWatch]
        /*" M-020-000-PESQ-TATTXACE-DB-SELECT-1 */
        public void M_020_000_PESQ_TATTXACE_DB_SELECT_1()
        {
            /*" -428- EXEC SQL SELECT TAXACARR, TAXAOUTR, TAXAEQUIP, TAXAREINT INTO :TXACE-TAXACARR, :TXACE-TAXAOUTR, :TXACE-TAXAEQUIP, :TXACE-TAXAREINT FROM SEGUROS.V1TAXACESS WHERE CODTAB = :TXACE-CODTAB AND CODPRODU = 0 AND CDACESS = 0 AND CATTARIF = :TXACE-CATTARIF AND TIPOCOB = :TXACE-TIPOCOB AND FRANQFAC = :TXACE-FRANQFAC AND REGIAO = :TXACE-REGIAO AND DTINIVIG <= :TXACE-DTINIVIG AND DTTERVIG >= :TXACE-DTINIVIG END-EXEC. */

            var m_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1 = new M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1()
            {
                TXACE_CATTARIF = TXACE_CATTARIF.ToString(),
                TXACE_FRANQFAC = TXACE_FRANQFAC.ToString(),
                TXACE_DTINIVIG = TXACE_DTINIVIG.ToString(),
                TXACE_TIPOCOB = TXACE_TIPOCOB.ToString(),
                TXACE_CODTAB = TXACE_CODTAB.ToString(),
                TXACE_REGIAO = TXACE_REGIAO.ToString(),
            };

            var executed_1 = M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1.Execute(m_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TXACE_TAXACARR, TXACE_TAXACARR);
                _.Move(executed_1.TXACE_TAXAOUTR, TXACE_TAXAOUTR);
                _.Move(executed_1.TXACE_TAXAEQUIP, TXACE_TAXAEQUIP);
                _.Move(executed_1.TXACE_TAXAREINT, TXACE_TAXAREINT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-030-000-TRATA-PCINCROU-SECTION */
        private void M_030_000_TRATA_PCINCROU_SECTION()
        {
            /*" -459- MOVE 'AU0032S - 030-000-TRATA-PCINCROU' TO CSP-RETORNO. */
            _.Move("AU0032S - 030-000-TRATA-PCINCROU", CSP_RETORNO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-050-000-TRATA-BONUS-SECTION */
        private void M_050_000_TRATA_BONUS_SECTION()
        {
            /*" -488- MOVE 'AU0032S - 050-000-TRATA-BONUS   ' TO CSP-RETORNO. */
            _.Move("AU0032S - 050-000-TRATA-BONUS   ", CSP_RETORNO);

            /*" -490- IF CSP-CLABONAT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_CLABONAT == 00)
            {

                /*" -491- MOVE WS-ITEM-A TO WS-ITEM-C */
                _.Move(WS_ITEM_A, WS_ITEM_C);

                /*" -492- ELSE */
            }
            else
            {


                /*" -493- MOVE 06 TO BONUS-CODTAB */
                _.Move(06, BONUS_CODTAB);

                /*" -494- MOVE CSP-CLABONAT TO BONUS-CLASSEBN */
                _.Move(CSP_REGISTRO.CSP_CLABONAT, BONUS_CLASSEBN);

                /*" -496- MOVE CSP-DTINIAUTO TO WDATA-NUM WS-DATA1 */
                _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM, WS_DATA1);

                /*" -497- MOVE WANO-NUM TO WANO-CHAR */
                _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

                /*" -498- MOVE WMES-NUM TO WMES-CHAR */
                _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

                /*" -499- MOVE WDIA-NUM TO WDIA-CHAR */
                _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

                /*" -500- MOVE WDATA-CHAR TO BONUS-DTINIVIG */
                _.Move(WDATA_CHAR, BONUS_DTINIVIG);

                /*" -501- MOVE WS-DIA1 TO WS-DIA2 */
                _.Move(WS_DATA1.WS_DIA1, WS_DATA2.WS_DIA2);

                /*" -502- MOVE WS-MES1 TO WS-MES2 */
                _.Move(WS_DATA1.WS_MES1, WS_DATA2.WS_MES2);

                /*" -503- MOVE WS-ANO1 TO WS-ANO2 */
                _.Move(WS_DATA1.WS_ANO1, WS_DATA2.WS_ANO2);

                /*" -504- MOVE 'BONUS AUTO                         ' TO CSP-TBLE */
                _.Move("BONUS AUTO                         ", CSP_RETORNO.CSP_TBLE);

                /*" -505- PERFORM 060-000-PESQ-TATBONUS */

                M_060_000_PESQ_TATBONUS_SECTION();

                /*" -506- COMPUTE WS-ITEM-B = WS-ITEM-A * BONUS-PCDESC / 100 */
                WS_ITEM_B.Value = WS_ITEM_A * BONUS_PCDESC / 100f;

                /*" -506- COMPUTE WS-ITEM-C = WS-ITEM-A - WS-ITEM-B. */
                WS_ITEM_C.Value = WS_ITEM_A - WS_ITEM_B;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_050_999_EXIT*/

        [StopWatch]
        /*" M-060-000-PESQ-TATBONUS-SECTION */
        private void M_060_000_PESQ_TATBONUS_SECTION()
        {
            /*" -518- MOVE 'AU0032S - 060-000-PESQ-TATBONUS' TO CSP-RETORNO. */
            _.Move("AU0032S - 060-000-PESQ-TATBONUS", CSP_RETORNO);

            /*" -526- PERFORM M_060_000_PESQ_TATBONUS_DB_SELECT_1 */

            M_060_000_PESQ_TATBONUS_DB_SELECT_1();

            /*" -529- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -530- MOVE 'AU0032S' TO CSP-PROCPAR */
                _.Move("AU0032S", CSP_RETORNO.CSP_PROCPAR);

                /*" -531- MOVE 'BONUS AUTOS NAO ENCONTRADA' TO CSP-TBLE */
                _.Move("BONUS AUTOS NAO ENCONTRADA", CSP_RETORNO.CSP_TBLE);

                /*" -532- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -533- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -534- ELSE */
            }
            else
            {


                /*" -535- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -536- MOVE 'PROBLEMAS DE ACESSO - V1BONAUTO' TO CSP-TBLE */
                    _.Move("PROBLEMAS DE ACESSO - V1BONAUTO", CSP_RETORNO.CSP_TBLE);

                    /*" -537- MOVE '060-000' TO CSP-PROCPAR */
                    _.Move("060-000", CSP_RETORNO.CSP_PROCPAR);

                    /*" -538- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -538- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-060-000-PESQ-TATBONUS-DB-SELECT-1 */
        public void M_060_000_PESQ_TATBONUS_DB_SELECT_1()
        {
            /*" -526- EXEC SQL SELECT PCDESC INTO :BONUS-PCDESC FROM SEGUROS.V1BONAUTO WHERE CODTAB = :BONUS-CODTAB AND CLASSEBN = :BONUS-CLASSEBN AND DTINIVIG <= :BONUS-DTINIVIG AND DTTERVIG >= :BONUS-DTINIVIG END-EXEC. */

            var m_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1 = new M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1()
            {
                BONUS_CLASSEBN = BONUS_CLASSEBN.ToString(),
                BONUS_DTINIVIG = BONUS_DTINIVIG.ToString(),
                BONUS_CODTAB = BONUS_CODTAB.ToString(),
            };

            var executed_1 = M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1.Execute(m_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BONUS_PCDESC, BONUS_PCDESC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-100-000-TRATA-PRAZO-SECTION */
        private void M_100_000_TRATA_PRAZO_SECTION()
        {
            /*" -547- MOVE 'AU0032S - 100-000-TRATA-PRAZO  ' TO CSP-RETORNO. */
            _.Move("AU0032S - 100-000-TRATA-PRAZO  ", CSP_RETORNO);

            /*" -548- MOVE 05 TO PRAZO-CODTAB */
            _.Move(05, PRAZO_CODTAB);

            /*" -549- MOVE CSP-PRAZOSEG TO PRAZO-PRAZOINI */
            _.Move(CSP_REGISTRO.CSP_PRAZOSEG, PRAZO_PRAZOINI);

            /*" -551- MOVE CSP-DTINIAUTO TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM, WS_DATA1);

            /*" -552- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -553- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -554- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -555- MOVE WDATA-CHAR TO PRAZO-DTINIVIG */
            _.Move(WDATA_CHAR, PRAZO_DTINIVIG);

            /*" -556- MOVE WS-DIA1 TO WS-DIA2 */
            _.Move(WS_DATA1.WS_DIA1, WS_DATA2.WS_DIA2);

            /*" -557- MOVE WS-MES1 TO WS-MES2 */
            _.Move(WS_DATA1.WS_MES1, WS_DATA2.WS_MES2);

            /*" -558- MOVE WS-ANO1 TO WS-ANO2 */
            _.Move(WS_DATA1.WS_ANO1, WS_DATA2.WS_ANO2);

            /*" -559- MOVE ZEROS TO WS-RETORNO */
            _.Move(0, WS_RETORNO);

            /*" -560- PERFORM 120-000-PESQ-TATPRAZO. */

            M_120_000_PESQ_TATPRAZO_SECTION();

            /*" -561- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -562- COMPUTE WS-ITEM-D = WS-ITEM-C * PRAZO-PCPRMANO / 100 */
                WS_ITEM_D.Value = WS_ITEM_C * PRAZO_PCPRMANO / 100f;

                /*" -563- ELSE */
            }
            else
            {


                /*" -563- COMPUTE WS-ITEM-D = WS-ITEM-C * CSP-PRAZOSEG / 365. */
                WS_ITEM_D.Value = WS_ITEM_C * CSP_REGISTRO.CSP_PRAZOSEG / 365f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PESQ-TATPRAZO-SECTION */
        private void M_120_000_PESQ_TATPRAZO_SECTION()
        {
            /*" -574- MOVE 'AU0032S - 120-000-PESQ-TATPRAZO' TO CSP-RETORNO. */
            _.Move("AU0032S - 120-000-PESQ-TATPRAZO", CSP_RETORNO);

            /*" -583- PERFORM M_120_000_PESQ_TATPRAZO_DB_SELECT_1 */

            M_120_000_PESQ_TATPRAZO_DB_SELECT_1();

            /*" -586- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -587- MOVE 'AU0032S' TO CSP-PROCPAR */
                _.Move("AU0032S", CSP_RETORNO.CSP_PROCPAR);

                /*" -588- MOVE 'PRAZO SEGURO NAO ENCONTRADO' TO CSP-TBLE */
                _.Move("PRAZO SEGURO NAO ENCONTRADO", CSP_RETORNO.CSP_TBLE);

                /*" -589- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -590- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -591- ELSE */
            }
            else
            {


                /*" -592- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -593- MOVE 'PROBLEMAS DE ACESSO - V1PRAZOSEG' TO CSP-TBLE */
                    _.Move("PROBLEMAS DE ACESSO - V1PRAZOSEG", CSP_RETORNO.CSP_TBLE);

                    /*" -594- MOVE '120-000' TO CSP-PROCPAR */
                    _.Move("120-000", CSP_RETORNO.CSP_PROCPAR);

                    /*" -595- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -595- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-120-000-PESQ-TATPRAZO-DB-SELECT-1 */
        public void M_120_000_PESQ_TATPRAZO_DB_SELECT_1()
        {
            /*" -583- EXEC SQL SELECT PCPRMANO INTO :PRAZO-PCPRMANO FROM SEGUROS.V1PRAZOSEG WHERE CODTAB = :PRAZO-CODTAB AND PRAZOINI <= :PRAZO-PRAZOINI AND PRAZOFIM >= :PRAZO-PRAZOINI AND DTINIVIG <= :PRAZO-DTINIVIG AND DTTERVIG >= :PRAZO-DTINIVIG END-EXEC. */

            var m_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1 = new M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1()
            {
                PRAZO_PRAZOINI = PRAZO_PRAZOINI.ToString(),
                PRAZO_DTINIVIG = PRAZO_DTINIVIG.ToString(),
                PRAZO_CODTAB = PRAZO_CODTAB.ToString(),
            };

            var executed_1 = M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1.Execute(m_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRAZO_PCPRMANO, PRAZO_PCPRMANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-TRATA-ITEM-A-SECTION */
        private void M_150_000_TRATA_ITEM_A_SECTION()
        {
            /*" -609- MOVE 'AU0032S - 150-000-TRATA-ITEM-A ' TO CSP-RETORNO. */
            _.Move("AU0032S - 150-000-TRATA-ITEM-A ", CSP_RETORNO);

            /*" -610- IF CSP-PCDESCAT EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_PCDESCAT == 00)
            {

                /*" -611- MOVE WS-ITEM-D TO WS-ITEM-F */
                _.Move(WS_ITEM_D, WS_ITEM_F);

                /*" -612- ELSE */
            }
            else
            {


                /*" -613- COMPUTE WS-ITEM-E = WS-ITEM-D * CSP-PCDESCAT / 100 */
                WS_ITEM_E.Value = WS_ITEM_D * CSP_REGISTRO.CSP_PCDESCAT / 100f;

                /*" -615- COMPUTE WS-ITEM-F = WS-ITEM-D - WS-ITEM-E. */
                WS_ITEM_F.Value = WS_ITEM_D - WS_ITEM_E;
            }


            /*" -616- IF CSP-PCAGPLAC EQUAL ZEROS */

            if (CSP_REGISTRO.CSP_PCAGPLAC == 00)
            {

                /*" -617- MOVE WS-ITEM-F TO CSP-VRPLACES */
                _.Move(WS_ITEM_F, CSP_REGISTRO.CSP_VRPLACES);

                /*" -618- ELSE */
            }
            else
            {


                /*" -619- COMPUTE WS-ITEM-G = WS-ITEM-F * CSP-PCAGPLAC / 100 */
                WS_ITEM_G.Value = WS_ITEM_F * CSP_REGISTRO.CSP_PCAGPLAC / 100f;

                /*" -621- COMPUTE CSP-VRPLACES = WS-ITEM-F + WS-ITEM-G. */
                CSP_REGISTRO.CSP_VRPLACES.Value = WS_ITEM_F + WS_ITEM_G;
            }


            /*" -622- IF CSP-ACE EQUAL 050 */

            if (CSP_REGISTRO.CSP_ACE == 050)
            {

                /*" -623- COMPUTE CSP-VRPLACES = CSP-VRPLACES * 1,5. */
                CSP_REGISTRO.CSP_VRPLACES.Value = CSP_REGISTRO.CSP_VRPLACES * 1.5;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-170-000-TRATA-DESCONTO-AUTO-SECTION */
        private void M_170_000_TRATA_DESCONTO_AUTO_SECTION()
        {
            /*" -631- MOVE 'AU0032S - 170-000-TRATA-DESCONTO-AUTO' TO CSP-RETORNO. */
            _.Move("AU0032S - 170-000-TRATA-DESCONTO-AUTO", CSP_RETORNO);

            /*" -632- IF CSP-PCDESAUT > 0 */

            if (CSP_REGISTRO.CSP_PCDESAUT > 0)
            {

                /*" -633- COMPUTE WS-AUX-DESC = (100 - CSP-PCDESAUT ) / 100 */
                WS_AUX_DESC.Value = (100 - CSP_REGISTRO.CSP_PCDESAUT) / 100f;

                /*" -634- COMPUTE CSP-VRPLACES = CSP-VRPLACES * WS-AUX-DESC. */
                CSP_REGISTRO.CSP_VRPLACES.Value = CSP_REGISTRO.CSP_VRPLACES * WS_AUX_DESC;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_170_999_EXIT*/

        [StopWatch]
        /*" M-180-000-PESQ-V1CATTARIFA-SECTION */
        private void M_180_000_PESQ_V1CATTARIFA_SECTION()
        {
            /*" -646- MOVE 'AU0032S - 180-000-PESQ-V1CATTARIFA   ' TO CSP-RETORNO. */
            _.Move("AU0032S - 180-000-PESQ-V1CATTARIFA   ", CSP_RETORNO);

            /*" -647- IF CSP-TIPOCOB EQUAL 2 */

            if (CSP_REGISTRO.CSP_TIPOCOB == 2)
            {

                /*" -648- MOVE 14 TO CATTF-CODTAB */
                _.Move(14, CATTF_CODTAB);

                /*" -649- ELSE */
            }
            else
            {


                /*" -650- MOVE 15 TO CATTF-CODTAB. */
                _.Move(15, CATTF_CODTAB);
            }


            /*" -652- MOVE ZEROS TO CATTF-CODPRODU */
            _.Move(0, CATTF_CODPRODU);

            /*" -654- MOVE CSP-CATTARIO TO CATTF-CATTARIF. */
            _.Move(CSP_REGISTRO.CSP_CATTARIO, CATTF_CATTARIF);

            /*" -656- MOVE CSP-DTINIAUTO TO WDATA-NUM WS-DATA1 */
            _.Move(CSP_REGISTRO.CSP_DTINIAUTO, WDATA_NUM, WS_DATA1);

            /*" -657- MOVE WANO-NUM TO WANO-CHAR */
            _.Move(WDATA_NUM.WANO_NUM, WDATA_CHAR.WANO_CHAR);

            /*" -658- MOVE WMES-NUM TO WMES-CHAR */
            _.Move(WDATA_NUM.WMES_NUM, WDATA_CHAR.WMES_CHAR);

            /*" -659- MOVE WDIA-NUM TO WDIA-CHAR */
            _.Move(WDATA_NUM.WDIA_NUM, WDATA_CHAR.WDIA_CHAR);

            /*" -661- MOVE WDATA-CHAR TO CATTF-DTINIVIG */
            _.Move(WDATA_CHAR, CATTF_DTINIVIG);

            /*" -670- PERFORM M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1 */

            M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1();

            /*" -673- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -674- MOVE 'AU0032S' TO CSP-PROCPAR */
                _.Move("AU0032S", CSP_RETORNO.CSP_PROCPAR);

                /*" -675- MOVE 'PERCENTUAL INC. ROUBO NAO ENCONTRADO' TO CSP-TBLE */
                _.Move("PERCENTUAL INC. ROUBO NAO ENCONTRADO", CSP_RETORNO.CSP_TBLE);

                /*" -676- MOVE 1 TO CSP-W01P0300 */
                _.Move(1, CSP_REGISTRO.CSP_W01P0300);

                /*" -677- PERFORM 999-000-ERRO */

                M_999_000_ERRO_SECTION();

                /*" -678- ELSE */
            }
            else
            {


                /*" -679- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -680- MOVE 'PROBLEMAS DE ACESSO - V1CATTARIF' TO CSP-TBLE */
                    _.Move("PROBLEMAS DE ACESSO - V1CATTARIF", CSP_RETORNO.CSP_TBLE);

                    /*" -681- MOVE '120-000' TO CSP-PROCPAR */
                    _.Move("120-000", CSP_RETORNO.CSP_PROCPAR);

                    /*" -682- MOVE 2 TO CSP-W01P0300 */
                    _.Move(2, CSP_REGISTRO.CSP_W01P0300);

                    /*" -682- PERFORM 999-000-ERRO. */

                    M_999_000_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-180-000-PESQ-V1CATTARIFA-DB-SELECT-1 */
        public void M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1()
        {
            /*" -670- EXEC SQL SELECT VLPRTXCF INTO :CATTF-VLPRTXCF FROM SEGUROS.V1CATTARIFA WHERE CODTAB = :CATTF-CODTAB AND CODPRODU = :CATTF-CODPRODU AND CATTARIF = :CATTF-CATTARIF AND DTINIVIG <= :CATTF-DTINIVIG AND DTTERVIG >= :CATTF-DTINIVIG END-EXEC. */

            var m_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 = new M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1()
            {
                CATTF_CODPRODU = CATTF_CODPRODU.ToString(),
                CATTF_CATTARIF = CATTF_CATTARIF.ToString(),
                CATTF_DTINIVIG = CATTF_DTINIVIG.ToString(),
                CATTF_CODTAB = CATTF_CODTAB.ToString(),
            };

            var executed_1 = M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1.Execute(m_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CATTF_VLPRTXCF, CATTF_VLPRTXCF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-190-000-TRATA-PREMIO-ANUAL-SECTION */
        private void M_190_000_TRATA_PREMIO_ANUAL_SECTION()
        {
            /*" -692- MOVE 'AU0032S - 190-000-TRATA-PREMIO-ANUAL' TO CSP-RETORNO. */
            _.Move("AU0032S - 190-000-TRATA-PREMIO-ANUAL", CSP_RETORNO);

            /*" -693- IF CSP-IDEPZSEG EQUAL 'S' */

            if (CSP_REGISTRO.CSP_IDEPZSEG == "S")
            {

                /*" -695- COMPUTE CSP-VRPLAACE = CSP-VRPLACES * 100 / PRAZO-PCPRMANO */
                CSP_REGISTRO.CSP_VRPLAACE.Value = CSP_REGISTRO.CSP_VRPLACES * 100 / PRAZO_PCPRMANO;

                /*" -696- ELSE */
            }
            else
            {


                /*" -697- COMPUTE CSP-VRPLAACE = CSP-VRPLACES * 365 / CSP-PRAZOSEG. */
                CSP_REGISTRO.CSP_VRPLAACE.Value = CSP_REGISTRO.CSP_VRPLACES * 365 / CSP_REGISTRO.CSP_PRAZOSEG;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/

        [StopWatch]
        /*" M-200-000-TRATA-EXTENSAO-PER-SECTION */
        private void M_200_000_TRATA_EXTENSAO_PER_SECTION()
        {
            /*" -713- MOVE 'AU0032S - 200-000-TRATA-EXTENSAO-PER' TO CSP-RETORNO. */
            _.Move("AU0032S - 200-000-TRATA-EXTENSAO-PER", CSP_RETORNO);

            /*" -714- MOVE ZEROS TO CSP-VRADACES. */
            _.Move(0, CSP_REGISTRO.CSP_VRADACES);

            /*" -715- IF CSP-EXTPER EQUAL '1' */

            if (CSP_REGISTRO.CSP_EXTPER == "1")
            {

                /*" -716- IF CSP-PER-30 */

                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
                {

                    /*" -717- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,10 */
                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.10;

                    /*" -718- ELSE */
                }
                else
                {


                    /*" -719- IF CSP-PER-60 */

                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
                    {

                        /*" -720- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,20 */
                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.20;

                        /*" -721- ELSE */
                    }
                    else
                    {


                        /*" -722- IF CSP-PER-90 */

                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
                        {

                            /*" -723- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,30 */
                            CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.30;

                            /*" -724- ELSE */
                        }
                        else
                        {


                            /*" -725- IF CSP-PER-120 */

                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
                            {

                                /*" -726- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,35 */
                                CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.35;

                                /*" -727- ELSE */
                            }
                            else
                            {


                                /*" -728- IF CSP-PER-150 */

                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
                                {

                                    /*" -729- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,40 */
                                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.40;

                                    /*" -730- ELSE */
                                }
                                else
                                {


                                    /*" -731- IF CSP-PER-180 */

                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
                                    {

                                        /*" -732- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,45 */
                                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.45;

                                        /*" -733- ELSE */
                                    }
                                    else
                                    {


                                        /*" -734- IF CSP-PER-210 */

                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
                                        {

                                            /*" -735- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,50 */
                                            CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.50;

                                            /*" -736- ELSE */
                                        }
                                        else
                                        {


                                            /*" -737- IF CSP-PER-240 */

                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
                                            {

                                                /*" -738- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,55 */
                                                CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.55;

                                                /*" -739- ELSE */
                                            }
                                            else
                                            {


                                                /*" -740- IF CSP-PER-270 */

                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
                                                {

                                                    /*" -741- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,60 */
                                                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.60;

                                                    /*" -742- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -743- IF CSP-PER-300 */

                                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
                                                    {

                                                        /*" -744- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,65 */
                                                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.65;

                                                        /*" -745- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -746- IF CSP-PER-330 */

                                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
                                                        {

                                                            /*" -747- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,70 */
                                                            CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.70;

                                                            /*" -748- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -749- IF CSP-PER-360 */

                                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
                                                            {

                                                                /*" -750- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,75 */
                                                                CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.75;

                                                                /*" -751- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -752- IF CSP-PER-364 */

                                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"])
                                                                {

                                                                    /*" -753- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,80 */
                                                                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.80;

                                                                    /*" -754- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -755- IF CSP-PER-366 */

                                                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_366"])
                                                                    {

                                                                        /*" -757- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,60. */
                                                                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.60;
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


            /*" -758- IF CSP-EXTPER EQUAL '2' */

            if (CSP_REGISTRO.CSP_EXTPER == "2")
            {

                /*" -759- IF CSP-PER-30 */

                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_30"])
                {

                    /*" -760- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,15 */
                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.15;

                    /*" -761- ELSE */
                }
                else
                {


                    /*" -762- IF CSP-PER-60 */

                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_60"])
                    {

                        /*" -763- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,30 */
                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.30;

                        /*" -764- ELSE */
                    }
                    else
                    {


                        /*" -765- IF CSP-PER-90 */

                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_90"])
                        {

                            /*" -766- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,45 */
                            CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.45;

                            /*" -767- ELSE */
                        }
                        else
                        {


                            /*" -768- IF CSP-PER-120 */

                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_120"])
                            {

                                /*" -769- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,60 */
                                CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.60;

                                /*" -770- ELSE */
                            }
                            else
                            {


                                /*" -771- IF CSP-PER-150 */

                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_150"])
                                {

                                    /*" -772- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,75 */
                                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.75;

                                    /*" -773- ELSE */
                                }
                                else
                                {


                                    /*" -774- IF CSP-PER-180 */

                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_180"])
                                    {

                                        /*" -775- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 0,90 */
                                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 0.90;

                                        /*" -776- ELSE */
                                    }
                                    else
                                    {


                                        /*" -777- IF CSP-PER-210 */

                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_210"])
                                        {

                                            /*" -778- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,05 */
                                            CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.05;

                                            /*" -779- ELSE */
                                        }
                                        else
                                        {


                                            /*" -780- IF CSP-PER-240 */

                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_240"])
                                            {

                                                /*" -781- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,20 */
                                                CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.20;

                                                /*" -782- ELSE */
                                            }
                                            else
                                            {


                                                /*" -783- IF CSP-PER-270 */

                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_270"])
                                                {

                                                    /*" -784- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,35 */
                                                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.35;

                                                    /*" -785- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -786- IF CSP-PER-300 */

                                                    if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_300"])
                                                    {

                                                        /*" -787- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,50 */
                                                        CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.50;

                                                        /*" -788- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -789- IF CSP-PER-330 */

                                                        if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_330"])
                                                        {

                                                            /*" -790- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,65 */
                                                            CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.65;

                                                            /*" -791- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -792- IF CSP-PER-360 */

                                                            if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_360"])
                                                            {

                                                                /*" -793- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,80 */
                                                                CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.80;

                                                                /*" -794- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -795- IF CSP-PER-364 OR CSP-PER-366 */

                                                                if (CSP_REGISTRO.CSP_PERIODO["CSP_PER_364"] || CSP_REGISTRO.CSP_PERIODO["CSP_PER_366"])
                                                                {

                                                                    /*" -797- COMPUTE CSP-VRADACES = CSP-VRPLAACE * 1,95. */
                                                                    CSP_REGISTRO.CSP_VRADACES.Value = CSP_REGISTRO.CSP_VRPLAACE * 1.95;
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


            /*" -798- COMPUTE CSP-VRPLAACE = CSP-VRPLAACE + CSP-VRADACES. */
            CSP_REGISTRO.CSP_VRPLAACE.Value = CSP_REGISTRO.CSP_VRPLAACE + CSP_REGISTRO.CSP_VRADACES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZAR-SECTION */
        private void M_900_000_FINALIZAR_SECTION()
        {
            /*" -807- MOVE 'AU0032S - 900-000-FINALIZAR  ' TO CSP-RETORNO. */
            _.Move("AU0032S - 900-000-FINALIZAR  ", CSP_RETORNO);

            /*" -815- MOVE 0 TO WS-RETORNO WS-ITEM-A WS-ITEM-B WS-ITEM-C WS-ITEM-D WS-ITEM-E WS-ITEM-F WS-ITEM-G. */
            _.Move(0, WS_RETORNO, WS_ITEM_A, WS_ITEM_B, WS_ITEM_C, WS_ITEM_D, WS_ITEM_E, WS_ITEM_F, WS_ITEM_G);

            /*" -818- MOVE SPACES TO WS-DATA1 WS-DATA2. */
            _.Move("", WS_DATA1, WS_DATA2);

            /*" -818- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-000-ERRO-SECTION */
        private void M_999_000_ERRO_SECTION()
        {
            /*" -825- MOVE SQLCODE TO CSP-CODE */
            _.Move(DB.SQLCODE, CSP_RETORNO.CSP_CODE);

            /*" -827- MOVE CSP-RETORNO TO CSP-W01A0077 */
            _.Move(CSP_RETORNO, CSP_REGISTRO.CSP_W01A0077);

            /*" -827- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT*/

        [StopWatch]
        /*" M-990-000-ABEND-SECTION */
        private void M_990_000_ABEND_SECTION()
        {
            /*" -834- MOVE 9 TO CSP-CODE */
            _.Move(9, CSP_RETORNO.CSP_CODE);

            /*" -836- MOVE CSP-RETORNO TO CSP-W01A0077 */
            _.Move(CSP_RETORNO, CSP_REGISTRO.CSP_W01A0077);

            /*" -836- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_990_999_EXIT*/
    }
}