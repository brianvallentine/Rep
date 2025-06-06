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
using Sias.Sinistro.DB2.SI0106B;

namespace Code
{
    public class SI0106B
    {
        public bool IsCall { get; set; }

        public SI0106B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * SISTEMA              =    SINISTRO.                         //      */
        /*"      * PROGRAMA             =    SI0106B.                          //      */
        /*"      *                                                             //      */
        /*"      * OBJETIVO             =    EMISSAO DE RELACAO DE DESPESAS    //      */
        /*"      *                           HONORARIOS A PAGAR.               //      */
        /*"      * ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    //      */
        /*"      * DATA                 =    JULHO / 91 .                      //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0106R1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0106R1
        {
            get
            {
                _.Move(REG_SI0106R1, _SI0106R1); VarBasis.RedefinePassValue(REG_SI0106R1, _SI0106R1, REG_SI0106R1); return _SI0106R1;
            }
        }
        /*"01  REG-SI0106R1.*/
        public SI0106B_REG_SI0106R1 REG_SI0106R1 { get; set; } = new SI0106B_REG_SI0106R1();
        public class SI0106B_REG_SI0106R1 : VarBasis
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
        /*"77           TGEUNIMO-VLCRUZAD      PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis TGEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77           THIST-CODPSVI          PIC S9(009)       COMP.*/
        public IntBasis THIST_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           THIST-NUMOPG           PIC S9(009)       COMP.*/
        public IntBasis THIST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           THIST-OPERACAO         PIC S9(004)       COMP.*/
        public IntBasis THIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-APOL-SINI        PIC S9(013)       COMP-3.*/
        public IntBasis THIST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           THIST-MOVPCS           PIC S9(009)       COMP.*/
        public IntBasis THIST_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           THIST-VAL-OPERACAO     PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-NOMFAV           PIC  X(040).*/
        public StringBasis THIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           THIST-DTMOVTO          PIC  X(010).*/
        public StringBasis THIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-DTINIVIG        PIC  X(010).*/
        public StringBasis RELSIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-DTTERVIG        PIC  X(010).*/
        public StringBasis RELSIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTMOVABE          PIC  X(010).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTCURRENT         PIC  X(010).*/
        public StringBasis SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SERV-DESSVI            PIC  X(040).*/
        public StringBasis SERV_DESSVI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           GEUNIMO-VLCRUZAD       PIC S9(006)V9(9)  COMP-3.*/
        public DoubleBasis GEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77           GEUNIMO-SIGLUNIM       PIC  X(006).*/
        public StringBasis GEUNIMO_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77           MEST-MOEDA-SIN         PIC S9(004)       COMP.*/
        public IntBasis MEST_MOEDA_SIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WMOEDA                 PIC S9(004) COMP VALUE ZEROS*/
        public IntBasis WMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WGEUNIMO-DTTERVIG      PIC X(010).*/
        public StringBasis WGEUNIMO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WGEUNIMO-DTINIVIG      PIC X(010).*/
        public StringBasis WGEUNIMO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              W.*/
        public SI0106B_W W { get; set; } = new SI0106B_W();
        public class SI0106B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0106B_LC01 LC01 { get; set; } = new SI0106B_LC01();
            public class SI0106B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO    PIC  X(009) VALUE 'SI0106B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0106B.1");
                /*"    05          FILLER            PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC01-EMPRESA      PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER            PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER            PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG          PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0106B_LC02 LC02 { get; set; } = new SI0106B_LC02();
            public class SI0106B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0106B_LC03 LC03 { get; set; } = new SI0106B_LC03();
            public class SI0106B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04C.*/
            }
            public SI0106B_LC04C LC04C { get; set; } = new SI0106B_LC04C();
            public class SI0106B_LC04C : VarBasis
            {
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(053) VALUE     'RELACAO DE DESPESAS/HONORARIOS A PAGAR NO PERIODO DE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"RELACAO DE DESPESAS/HONORARIOS A PAGAR NO PERIODO DE ");
                /*"    05          LC04C-DATA.*/
                public SI0106B_LC04C_DATA LC04C_DATA { get; set; } = new SI0106B_LC04C_DATA();
                public class SI0106B_LC04C_DATA : VarBasis
                {
                    /*"      07        LC04C-DDI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_DDI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-MMI           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_MMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-AAI           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04C_AAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(003) VALUE ' A '.*/
                }
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    05          LC04C-DATA.*/
                public SI0106B_LC04C_DATA_0 LC04C_DATA_0 { get; set; } = new SI0106B_LC04C_DATA_0();
                public class SI0106B_LC04C_DATA_0 : VarBasis
                {
                    /*"      07        LC04C-DDF           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_DDF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-MMF           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04C_MMF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '.'.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"      07        LC04C-AAF           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04C_AAF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"  03            LC05.*/
                }
            }
            public SI0106B_LC05 LC05 { get; set; } = new SI0106B_LC05();
            public class SI0106B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(020) VALUE                'PREST. DE SERVICO: '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"PREST. DE SERVICO: ");
                /*"    05          LC05-CLIFOR         PIC  ZZZZZZ9.*/
                public IntBasis LC05_CLIFOR { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC05-NOME           PIC  X(040) VALUE SPACES.*/
                public StringBasis LC05_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC06.*/
            }
            public SI0106B_LC06 LC06 { get; set; } = new SI0106B_LC06();
            public class SI0106B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            LC07.*/
            }
            public SI0106B_LC07 LC07 { get; set; } = new SI0106B_LC07();
            public class SI0106B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(027) VALUE                                   'ORDEM DE PAGTO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"ORDEM DE PAGTO");
                /*"    05          FILLER              PIC  X(032) VALUE                                   'SINISTRO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"SINISTRO");
                /*"    05          FILLER              PIC  X(022) VALUE                                   'MPS'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"MPS");
                /*"    05          FILLER              PIC  X(039) VALUE                ' CORRECAO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @" CORRECAO");
                /*"    05          FILLER              PIC  X(011) VALUE                '    VALOR'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"    VALOR");
                /*"  03            LD01.*/
            }
            public SI0106B_LD01 LD01 { get; set; } = new SI0106B_LD01();
            public class SI0106B_LD01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LD01-NUMOPG         PIC  999999999.*/
                public IntBasis LD01_NUMOPG { get; set; } = new IntBasis(new PIC("9", "9", "999999999."));
                /*"    05          FILLER              PIC  X(014) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    05          LD01-SINISTRO       PIC  9(013).*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LD01-MOVPCS         PIC  9(006).*/
                public IntBasis LD01_MOVPCS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LD01-LITERAL        PIC  X(005) VALUE SPACES.*/
                public StringBasis LD01_LITERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LD01-VALOR          PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03            LT01.*/
            }
            public SI0106B_LT01 LT01 { get; set; } = new SI0106B_LT01();
            public class SI0106B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(085) VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)"), @"");
                /*"    05          FILLER              PIC  X(025) VALUE               'TOTAL A PAGAR ....... '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"TOTAL A PAGAR ....... ");
                /*"    05          LT01-VALOR          PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  03            LT02.*/
            }
            public SI0106B_LT02 LT02 { get; set; } = new SI0106B_LT02();
            public class SI0106B_LT02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(085) VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)"), @"");
                /*"    05          FILLER              PIC  X(025) VALUE               'TOTAL GERAL ......... '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"TOTAL GERAL ......... ");
                /*"    05          LT02-VALOR          PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  03            LT03.*/
            }
            public SI0106B_LT03 LT03 { get; set; } = new SI0106B_LT03();
            public class SI0106B_LT03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(085) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)"), @"");
                /*"    05          FILLER              PIC  X(025) VALUE               'TOTAL NUMOPG ........ '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"TOTAL NUMOPG ........ ");
                /*"    05          LT03-VALOR          PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            TOTAL-EDICAO        PIC ZZZ.ZZZ.ZZZ.999.*/
            public IntBasis TOTAL_EDICAO { get; set; } = new IntBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.999."));
            /*"  03            WDATA.*/
            public SI0106B_WDATA WDATA { get; set; } = new SI0106B_WDATA();
            public class SI0106B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"  03            W-DTINIVIG          PIC  X(010)   VALUE ZEROS.*/
            public StringBasis W_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            FILLER              REDEFINES W-DTINIVIG.*/
            private _REDEF_SI0106B_FILLER_40 _filler_40 { get; set; }
            public _REDEF_SI0106B_FILLER_40 FILLER_40
            {
                get { _filler_40 = new _REDEF_SI0106B_FILLER_40(); _.Move(W_DTINIVIG, _filler_40); VarBasis.RedefinePassValue(W_DTINIVIG, _filler_40, W_DTINIVIG); _filler_40.ValueChanged += () => { _.Move(_filler_40, W_DTINIVIG); }; return _filler_40; }
                set { VarBasis.RedefinePassValue(value, _filler_40, W_DTINIVIG); }
            }  //Redefines
            public class _REDEF_SI0106B_FILLER_40 : VarBasis
            {
                /*"    05          W-DTINI-AA          PIC  9(004).*/
                public IntBasis W_DTINI_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          W-DTINI-MM          PIC  9(002).*/
                public IntBasis W_DTINI_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          W-DTINI-DD          PIC  9(002).*/
                public IntBasis W_DTINI_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            W-DTTERVIG          PIC  X(010)   VALUE ZEROS.*/

                public _REDEF_SI0106B_FILLER_40()
                {
                    W_DTINI_AA.ValueChanged += OnValueChanged;
                    FILLER_41.ValueChanged += OnValueChanged;
                    W_DTINI_MM.ValueChanged += OnValueChanged;
                    FILLER_42.ValueChanged += OnValueChanged;
                    W_DTINI_DD.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            FILLER              REDEFINES W-DTTERVIG.*/
            private _REDEF_SI0106B_FILLER_43 _filler_43 { get; set; }
            public _REDEF_SI0106B_FILLER_43 FILLER_43
            {
                get { _filler_43 = new _REDEF_SI0106B_FILLER_43(); _.Move(W_DTTERVIG, _filler_43); VarBasis.RedefinePassValue(W_DTTERVIG, _filler_43, W_DTTERVIG); _filler_43.ValueChanged += () => { _.Move(_filler_43, W_DTTERVIG); }; return _filler_43; }
                set { VarBasis.RedefinePassValue(value, _filler_43, W_DTTERVIG); }
            }  //Redefines
            public class _REDEF_SI0106B_FILLER_43 : VarBasis
            {
                /*"    05          W-DTTER-AA          PIC  9(004).*/
                public IntBasis W_DTTER_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          W-DTTER-MM          PIC  9(002).*/
                public IntBasis W_DTTER_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          W-DTTER-DD          PIC  9(002).*/
                public IntBasis W_DTTER_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATAX.*/

                public _REDEF_SI0106B_FILLER_43()
                {
                    W_DTTER_AA.ValueChanged += OnValueChanged;
                    FILLER_44.ValueChanged += OnValueChanged;
                    W_DTTER_MM.ValueChanged += OnValueChanged;
                    FILLER_45.ValueChanged += OnValueChanged;
                    W_DTTER_DD.ValueChanged += OnValueChanged;
                }

            }
            public SI0106B_WDATAX WDATAX { get; set; } = new SI0106B_WDATAX();
            public class SI0106B_WDATAX : VarBasis
            {
                /*"    05          WDATAX-ANO          PIC  9(004).*/
                public IntBasis WDATAX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATAX-MES          PIC  9(002).*/
                public IntBasis WDATAX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATAX-DIA          PIC  9(002).*/
                public IntBasis WDATAX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATAX-R            REDEFINES WDATAX  PIC X(010)*/
            }
            private _REDEF_StringBasis _wdatax_r { get; set; }
            public _REDEF_StringBasis WDATAX_R
            {
                get { _wdatax_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010)")); ; _.Move(WDATAX, _wdatax_r); VarBasis.RedefinePassValue(WDATAX, _wdatax_r, WDATAX); _wdatax_r.ValueChanged += () => { _.Move(_wdatax_r, WDATAX); }; return _wdatax_r; }
                set { VarBasis.RedefinePassValue(value, _wdatax_r, WDATAX); }
            }  //Redefines
            /*"  03            WDATA-CURR.*/
            public SI0106B_WDATA_CURR WDATA_CURR { get; set; } = new SI0106B_WDATA_CURR();
            public class SI0106B_WDATA_CURR : VarBasis
            {
                /*"    05          WDATA-AA-CURR       PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-CURR.*/
            }
            public SI0106B_WHORA_CURR WHORA_CURR { get; set; } = new SI0106B_WHORA_CURR();
            public class SI0106B_WHORA_CURR : VarBasis
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
            public SI0106B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0106B_WDATA_CABEC();
            public class SI0106B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0106B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0106B_WHORA_CABEC();
            public class SI0106B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            W-CTR               PIC   X(001) VALUE  'N'.*/
            }
            public StringBasis W_CTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            W-FLAG              PIC   X(001) VALUE  'N'.*/
            public StringBasis W_FLAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WANT-NUMOPG         PIC  9(009) VALUE ZEROS.*/
            public IntBasis WANT_NUMOPG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03            W-PREST-ANT.*/
            public SI0106B_W_PREST_ANT W_PREST_ANT { get; set; } = new SI0106B_W_PREST_ANT();
            public class SI0106B_W_PREST_ANT : VarBasis
            {
                /*"    05          W-CLIFOR-ANT        PIC  9(009) VALUE ZEROS.*/
                public IntBasis W_CLIFOR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    05          W-NUMOPG-ANT        PIC  9(009) VALUE ZEROS.*/
                public IntBasis W_NUMOPG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"  03            W-PREST-ATL.*/
            }
            public SI0106B_W_PREST_ATL W_PREST_ATL { get; set; } = new SI0106B_W_PREST_ATL();
            public class SI0106B_W_PREST_ATL : VarBasis
            {
                /*"    05          W-CLIFOR-ATL        PIC  9(009) VALUE ZEROS.*/
                public IntBasis W_CLIFOR_ATL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    05          W-NUMOPG-ATL        PIC  9(009) VALUE ZEROS.*/
                public IntBasis W_NUMOPG_ATL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"  03            FINAL-THISTSIN      PIC  X(001) VALUE 'N'.*/
            }

            public SelectorBasis FINAL_THISTSIN { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88        WFIM-THISTSIN                   VALUE 'S'. */
							new SelectorItemBasis("WFIM_THISTSIN", "S")
                }
            };

            /*"  03            FINAL-TRELSIN       PIC  X(001) VALUE 'N'.*/

            public SelectorBasis FINAL_TRELSIN { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88        WFIM-TRELSIN                    VALUE 'S'. */
							new SelectorItemBasis("WFIM_TRELSIN", "S")
                }
            };

            /*"  03            WS-PRIMEIRA-VEZ     PIC  X(001) VALUE 'S'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03            WS-TIPO-CABECALHO   PIC  X(010) VALUE ' '.*/
            public StringBasis WS_TIPO_CABECALHO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"  03            W-CONT-PAG          PIC  S9(005) VALUE +0.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            W-CONT-LIN          PIC  S9(002) VALUE +70.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +70);
            /*"  03            WS-VALOR           PIC S9(015)V99  VALUE ZEROS.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOTAL           PIC S9(015)V99  VALUE ZEROS.*/
            public DoubleBasis WS_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOTAL-GERAL     PIC S9(015)V99  VALUE ZEROS.*/
            public DoubleBasis WS_TOTAL_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOTAL-NUMOPG    PIC S9(015)V99  VALUE ZEROS.*/
            public DoubleBasis WS_TOTAL_NUMOPG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOT-LIDOS       PIC S9(015)V99  VALUE ZEROS.*/
            public DoubleBasis WS_TOT_LIDOS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOT-IMPRESSOS   PIC S9(015)V99  VALUE ZEROS.*/
            public DoubleBasis WS_TOT_IMPRESSOS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03        WABEND.*/
            public SI0106B_WABEND WABEND { get; set; } = new SI0106B_WABEND();
            public class SI0106B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0106B  '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0106B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  03            WQTD-MOEDA      PIC 9(013)V9(4)   VALUE ZEROS.*/
            }
            public DoubleBasis WQTD_MOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V9(4)"), 4);
            /*"  03            WGEUNIMO-CODUNIMO  PIC 9(004).*/
            public IntBasis WGEUNIMO_CODUNIMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03             CH1-ON1           PIC 9(001)     VALUE ZEROS.*/
            public IntBasis CH1_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03             CH2-ON1           PIC 9(001)     VALUE ZEROS.*/
            public IntBasis CH2_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03             CH3-ON1           PIC 9(001)     VALUE ZEROS.*/
            public IntBasis CH3_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01          LK-LINK.*/
        }
        public SI0106B_LK_LINK LK_LINK { get; set; } = new SI0106B_LK_LINK();
        public class SI0106B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0106B_V1RELATSINI V1RELATSINI { get; set; } = new SI0106B_V1RELATSINI();
        public SI0106B_THISTSIN1 THISTSIN1 { get; set; } = new SI0106B_THISTSIN1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0106R1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0106R1.SetFile(SI0106R1_FILE_NAME_P);

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
            /*" -387- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -390- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -391- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -393- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -395- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -400- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -402- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -404- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -406- PERFORM 090-000-CURSOR-TRELSIN-E. */

            M_090_000_CURSOR_TRELSIN_E_SECTION();

            /*" -408- PERFORM 120-000-PROCESSA-E UNTIL WFIM-TRELSIN. */

            while (!(W.FINAL_TRELSIN["WFIM_TRELSIN"]))
            {

                M_120_000_PROCESSA_E_SECTION();
            }

            /*" -410- PERFORM 240-000-TOTAL-GERAL. */

            M_240_000_TOTAL_GERAL_SECTION();

            /*" -410- PERFORM 800-000-ATUALIZA-TRELSIN-E. */

            M_800_000_ATUALIZA_TRELSIN_E_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -417- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -417- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -430- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -431- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -432- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -433- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -435- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -436- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, W.WDATA_CURR);

            /*" -437- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.WDATA_CURR.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -438- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.WDATA_CURR.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -439- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.WDATA_CURR.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -441- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -445- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -448- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -450- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -451- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -452- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -453- ELSE */
            }
            else
            {


                /*" -454- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -454- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -445- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -470- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -470- OPEN OUTPUT SI0106R1. */
            SI0106R1.Open(REG_SI0106R1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -487- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -489- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", W.WABEND.WNR_EXEC_SQL);

            /*" -496- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -499- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -500- DISPLAY 'SI0106B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0106B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -502- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -502- MOVE SIST-DTMOVABE TO WDATA-R. */
            _.Move(SIST_DTMOVABE, W.WDATA_R);

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -496- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -519- MOVE '090-000-CURSOR-TRELSIN-E' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-TRELSIN-E", W.WABEND.PARAGRAFO);

            /*" -521- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -534- PERFORM M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1();

            /*" -536- PERFORM M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1 */

            M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1()
        {
            /*" -534- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0106B' AND DATA_SOLICITACAO = :SIST-DTMOVABE ORDER BY PERI_INICIAL, PERI_FINAL END-EXEC. */
            V1RELATSINI = new SI0106B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT 
							PERI_INICIAL
							, 
							PERI_FINAL 
							FROM 
							SEGUROS.V1RELATORIOS 
							WHERE 
							IDSISTEM = 'SI' AND 
							CODRELAT = 'SI0106B' AND 
							DATA_SOLICITACAO = '{SIST_DTMOVABE}' 
							ORDER BY 
							PERI_INICIAL
							, 
							PERI_FINAL";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1()
        {
            /*" -536- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-130-000-CURSOR-THISTSIN-DB-DECLARE-1 */
        public void M_130_000_CURSOR_THISTSIN_DB_DECLARE_1()
        {
            /*" -635- EXEC SQL DECLARE THISTSIN1 CURSOR FOR SELECT CODPSVI, NUMOPG, OPERACAO, NUM_APOL_SINISTRO, MOVPCS, NOMFAV, DTMOVTO, SUM(VAL_OPERACAO) FROM SEGUROS.V1HISTSINI WHERE SITUACAO = '0' AND DTMOVTO >= :RELSIN-DTINIVIG AND DTMOVTO <= :RELSIN-DTTERVIG AND (OPERACAO BETWEEN 2001 AND 2009 OR OPERACAO BETWEEN 3001 AND 3009) GROUP BY CODPSVI, NUMOPG, OPERACAO, NUM_APOL_SINISTRO ,MOVPCS, NOMFAV, DTMOVTO ORDER BY CODPSVI, NUMOPG, OPERACAO, NUM_APOL_SINISTRO ,MOVPCS, NOMFAV, DTMOVTO END-EXEC. */
            THISTSIN1 = new SI0106B_THISTSIN1(true);
            string GetQuery_THISTSIN1()
            {
                var query = @$"SELECT 
							CODPSVI
							, 
							NUMOPG
							, 
							OPERACAO
							, 
							NUM_APOL_SINISTRO
							, 
							MOVPCS
							, 
							NOMFAV
							, 
							DTMOVTO
							, 
							SUM(VAL_OPERACAO) 
							FROM 
							SEGUROS.V1HISTSINI 
							WHERE 
							SITUACAO = '0' AND 
							DTMOVTO >= '{RELSIN_DTINIVIG}' AND 
							DTMOVTO <= '{RELSIN_DTTERVIG}' AND 
							(OPERACAO BETWEEN 2001 AND 2009 OR 
							OPERACAO BETWEEN 3001 AND 3009) 
							GROUP BY 
							CODPSVI
							, NUMOPG
							, OPERACAO
							, 
							NUM_APOL_SINISTRO
							,MOVPCS
							, NOMFAV
							, DTMOVTO 
							ORDER BY 
							CODPSVI
							, NUMOPG
							, OPERACAO
							, 
							NUM_APOL_SINISTRO
							,MOVPCS
							, NOMFAV
							, DTMOVTO";

                return query;
            }
            THISTSIN1.GetQueryEvent += GetQuery_THISTSIN1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-E-SECTION */
        private void M_120_000_PROCESSA_E_SECTION()
        {
            /*" -554- MOVE '120-000-PROCESSA-E' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA-E", W.WABEND.PARAGRAFO);

            /*" -558- PERFORM M_120_000_PROCESSA_E_DB_FETCH_1 */

            M_120_000_PROCESSA_E_DB_FETCH_1();

            /*" -561- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -561- PERFORM M_120_000_PROCESSA_E_DB_CLOSE_1 */

                M_120_000_PROCESSA_E_DB_CLOSE_1();

                /*" -563- MOVE 'S' TO FINAL-TRELSIN */
                _.Move("S", W.FINAL_TRELSIN);

                /*" -565- GO TO 120-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                return;
            }


            /*" -566- MOVE 'S' TO WS-PRIMEIRA-VEZ. */
            _.Move("S", W.WS_PRIMEIRA_VEZ);

            /*" -567- MOVE '    ' TO WS-TIPO-CABECALHO. */
            _.Move("    ", W.WS_TIPO_CABECALHO);

            /*" -569- MOVE 90 TO W-CONT-LIN. */
            _.Move(90, W.W_CONT_LIN);

            /*" -570- MOVE RELSIN-DTINIVIG TO W-DTINIVIG. */
            _.Move(RELSIN_DTINIVIG, W.W_DTINIVIG);

            /*" -572- MOVE RELSIN-DTTERVIG TO W-DTTERVIG. */
            _.Move(RELSIN_DTTERVIG, W.W_DTTERVIG);

            /*" -573- MOVE W-DTINI-AA TO LC04C-AAI */
            _.Move(W.FILLER_40.W_DTINI_AA, W.LC04C.LC04C_DATA.LC04C_AAI);

            /*" -574- MOVE W-DTINI-MM TO LC04C-MMI */
            _.Move(W.FILLER_40.W_DTINI_MM, W.LC04C.LC04C_DATA.LC04C_MMI);

            /*" -575- MOVE W-DTINI-DD TO LC04C-DDI */
            _.Move(W.FILLER_40.W_DTINI_DD, W.LC04C.LC04C_DATA.LC04C_DDI);

            /*" -576- MOVE W-DTTER-AA TO LC04C-AAF */
            _.Move(W.FILLER_43.W_DTTER_AA, W.LC04C.LC04C_DATA_0.LC04C_AAF);

            /*" -577- MOVE W-DTTER-MM TO LC04C-MMF */
            _.Move(W.FILLER_43.W_DTTER_MM, W.LC04C.LC04C_DATA_0.LC04C_MMF);

            /*" -578- MOVE W-DTTER-DD TO LC04C-DDF */
            _.Move(W.FILLER_43.W_DTTER_DD, W.LC04C.LC04C_DATA_0.LC04C_DDF);

            /*" -580- MOVE 'PERIODO' TO WS-TIPO-CABECALHO */
            _.Move("PERIODO", W.WS_TIPO_CABECALHO);

            /*" -584- PERFORM 130-000-CURSOR-THISTSIN */

            M_130_000_CURSOR_THISTSIN_SECTION();

            /*" -586- MOVE 'N' TO FINAL-THISTSIN. */
            _.Move("N", W.FINAL_THISTSIN);

            /*" -588- PERFORM 160-000-LER-THISTSIN UNTIL WFIM-THISTSIN. */

            while (!(W.FINAL_THISTSIN["WFIM_THISTSIN"]))
            {

                M_160_000_LER_THISTSIN_SECTION();
            }

            /*" -590- PERFORM 260-000-IMPRIME-TOTAL-NUMOPG. */

            M_260_000_IMPRIME_TOTAL_NUMOPG_SECTION();

            /*" -590- PERFORM 230-000-IMPRIME-TOTAL. */

            M_230_000_IMPRIME_TOTAL_SECTION();

        }

        [StopWatch]
        /*" M-120-000-PROCESSA-E-DB-FETCH-1 */
        public void M_120_000_PROCESSA_E_DB_FETCH_1()
        {
            /*" -558- EXEC SQL FETCH V1RELATSINI INTO :RELSIN-DTINIVIG, :RELSIN-DTTERVIG END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELSIN_DTINIVIG, RELSIN_DTINIVIG);
                _.Move(V1RELATSINI.RELSIN_DTTERVIG, RELSIN_DTTERVIG);
            }

        }

        [StopWatch]
        /*" M-120-000-PROCESSA-E-DB-CLOSE-1 */
        public void M_120_000_PROCESSA_E_DB_CLOSE_1()
        {
            /*" -561- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-130-000-CURSOR-THISTSIN-SECTION */
        private void M_130_000_CURSOR_THISTSIN_SECTION()
        {
            /*" -609- MOVE '130-000-CURSOR-THISTSIN' TO PARAGRAFO. */
            _.Move("130-000-CURSOR-THISTSIN", W.WABEND.PARAGRAFO);

            /*" -611- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", W.WABEND.WNR_EXEC_SQL);

            /*" -635- PERFORM M_130_000_CURSOR_THISTSIN_DB_DECLARE_1 */

            M_130_000_CURSOR_THISTSIN_DB_DECLARE_1();

            /*" -637- PERFORM M_130_000_CURSOR_THISTSIN_DB_OPEN_1 */

            M_130_000_CURSOR_THISTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-130-000-CURSOR-THISTSIN-DB-OPEN-1 */
        public void M_130_000_CURSOR_THISTSIN_DB_OPEN_1()
        {
            /*" -637- EXEC SQL OPEN THISTSIN1 END-EXEC. */

            THISTSIN1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_130_999_EXIT*/

        [StopWatch]
        /*" M-160-000-LER-THISTSIN-SECTION */
        private void M_160_000_LER_THISTSIN_SECTION()
        {
            /*" -654- MOVE '160-000-LER-THISTSIN' TO PARAGRAFO. */
            _.Move("160-000-LER-THISTSIN", W.WABEND.PARAGRAFO);

            /*" -656- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", W.WABEND.WNR_EXEC_SQL);

            /*" -666- PERFORM M_160_000_LER_THISTSIN_DB_FETCH_1 */

            M_160_000_LER_THISTSIN_DB_FETCH_1();

            /*" -669- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -670- MOVE 'S' TO FINAL-THISTSIN */
                _.Move("S", W.FINAL_THISTSIN);

                /*" -670- PERFORM M_160_000_LER_THISTSIN_DB_CLOSE_1 */

                M_160_000_LER_THISTSIN_DB_CLOSE_1();

                /*" -672- ELSE */
            }
            else
            {


                /*" -673- ADD 1 TO WS-TOT-LIDOS */
                W.WS_TOT_LIDOS.Value = W.WS_TOT_LIDOS + 1;

                /*" -673- PERFORM 170-000-IMPR-RELAT. */

                M_170_000_IMPR_RELAT_SECTION();
            }


        }

        [StopWatch]
        /*" M-160-000-LER-THISTSIN-DB-FETCH-1 */
        public void M_160_000_LER_THISTSIN_DB_FETCH_1()
        {
            /*" -666- EXEC SQL FETCH THISTSIN1 INTO :THIST-CODPSVI, :THIST-NUMOPG, :THIST-OPERACAO, :THIST-APOL-SINI, :THIST-MOVPCS, :THIST-NOMFAV, :THIST-DTMOVTO, :THIST-VAL-OPERACAO END-EXEC */

            if (THISTSIN1.Fetch())
            {
                _.Move(THISTSIN1.THIST_CODPSVI, THIST_CODPSVI);
                _.Move(THISTSIN1.THIST_NUMOPG, THIST_NUMOPG);
                _.Move(THISTSIN1.THIST_OPERACAO, THIST_OPERACAO);
                _.Move(THISTSIN1.THIST_APOL_SINI, THIST_APOL_SINI);
                _.Move(THISTSIN1.THIST_MOVPCS, THIST_MOVPCS);
                _.Move(THISTSIN1.THIST_NOMFAV, THIST_NOMFAV);
                _.Move(THISTSIN1.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(THISTSIN1.THIST_VAL_OPERACAO, THIST_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" M-160-000-LER-THISTSIN-DB-CLOSE-1 */
        public void M_160_000_LER_THISTSIN_DB_CLOSE_1()
        {
            /*" -670- EXEC SQL CLOSE THISTSIN1 END-EXEC */

            THISTSIN1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-170-000-IMPR-RELAT-SECTION */
        private void M_170_000_IMPR_RELAT_SECTION()
        {
            /*" -690- MOVE '170-000-IMPR-RELAT' TO PARAGRAFO. */
            _.Move("170-000-IMPR-RELAT", W.WABEND.PARAGRAFO);

            /*" -691- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", W.WABEND.WNR_EXEC_SQL);

            /*" -692- MOVE THIST-CODPSVI TO W-CLIFOR-ATL */
            _.Move(THIST_CODPSVI, W.W_PREST_ATL.W_CLIFOR_ATL);

            /*" -694- MOVE THIST-NUMOPG TO W-NUMOPG-ATL */
            _.Move(THIST_NUMOPG, W.W_PREST_ATL.W_NUMOPG_ATL);

            /*" -696- MOVE SPACES TO LD01. */
            _.Move("", W.LD01);

            /*" -697- IF WS-PRIMEIRA-VEZ EQUAL 'S' */

            if (W.WS_PRIMEIRA_VEZ == "S")
            {

                /*" -698- MOVE 'N' TO WS-PRIMEIRA-VEZ */
                _.Move("N", W.WS_PRIMEIRA_VEZ);

                /*" -699- MOVE W-PREST-ATL TO W-PREST-ANT */
                _.Move(W.W_PREST_ATL, W.W_PREST_ANT);

                /*" -703- MOVE 0 TO WS-TOTAL. */
                _.Move(0, W.WS_TOTAL);
            }


            /*" -704- IF W-CLIFOR-ATL NOT EQUAL W-CLIFOR-ANT */

            if (W.W_PREST_ATL.W_CLIFOR_ATL != W.W_PREST_ANT.W_CLIFOR_ANT)
            {

                /*" -705- PERFORM 260-000-IMPRIME-TOTAL-NUMOPG */

                M_260_000_IMPRIME_TOTAL_NUMOPG_SECTION();

                /*" -706- PERFORM 230-000-IMPRIME-TOTAL */

                M_230_000_IMPRIME_TOTAL_SECTION();

                /*" -711- MOVE W-PREST-ATL TO W-PREST-ANT. */
                _.Move(W.W_PREST_ATL, W.W_PREST_ANT);
            }


            /*" -712- IF THIST-NUMOPG NOT EQUAL WANT-NUMOPG */

            if (THIST_NUMOPG != W.WANT_NUMOPG)
            {

                /*" -713- MOVE THIST-NUMOPG TO LD01-NUMOPG */
                _.Move(THIST_NUMOPG, W.LD01.LD01_NUMOPG);

                /*" -714- MOVE THIST-APOL-SINI TO LD01-SINISTRO */
                _.Move(THIST_APOL_SINI, W.LD01.LD01_SINISTRO);

                /*" -715- MOVE THIST-NUMOPG TO WANT-NUMOPG */
                _.Move(THIST_NUMOPG, W.WANT_NUMOPG);

                /*" -716- MOVE THIST-MOVPCS TO LD01-MOVPCS */
                _.Move(THIST_MOVPCS, W.LD01.LD01_MOVPCS);

                /*" -717- MOVE 'S' TO W-CTR */
                _.Move("S", W.W_CTR);

                /*" -718- IF W-FLAG EQUAL 'S' */

                if (W.W_FLAG == "S")
                {

                    /*" -720- PERFORM 260-000-IMPRIME-TOTAL-NUMOPG. */

                    M_260_000_IMPRIME_TOTAL_NUMOPG_SECTION();
                }

            }


            /*" -722- MOVE THIST-VAL-OPERACAO TO WS-VALOR LD01-VALOR */
            _.Move(THIST_VAL_OPERACAO, W.WS_VALOR, W.LD01.LD01_VALOR);

            /*" -724- ADD WS-VALOR TO WS-TOTAL WS-TOTAL-NUMOPG */
            W.WS_TOTAL.Value = W.WS_TOTAL + W.WS_VALOR;
            W.WS_TOTAL_NUMOPG.Value = W.WS_TOTAL_NUMOPG + W.WS_VALOR;

            /*" -726- PERFORM 600-000-CALCULA-VALOR. */

            M_600_000_CALCULA_VALOR_SECTION();

            /*" -728- PERFORM 200-000-IMPRIME. */

            M_200_000_IMPRIME_SECTION();

            /*" -730- ADD 1 TO WS-TOT-IMPRESSOS. */
            W.WS_TOT_IMPRESSOS.Value = W.WS_TOT_IMPRESSOS + 1;

            /*" -731- MOVE ZEROS TO LD01-SINISTRO */
            _.Move(0, W.LD01.LD01_SINISTRO);

            /*" -732- MOVE ' ' TO LD01-LITERAL */
            _.Move(" ", W.LD01.LD01_LITERAL);

            /*" -733- MOVE 'N' TO W-CTR */
            _.Move("N", W.W_CTR);

            /*" -733- MOVE 'S' TO W-FLAG. */
            _.Move("S", W.W_FLAG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_170_999_EXIT*/

        [StopWatch]
        /*" M-200-000-IMPRIME-SECTION */
        private void M_200_000_IMPRIME_SECTION()
        {
            /*" -746- MOVE '200-000-IMPRIME' TO PARAGRAFO. */
            _.Move("200-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -748- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", W.WABEND.WNR_EXEC_SQL);

            /*" -749- IF W-CONT-LIN GREATER 60 */

            if (W.W_CONT_LIN > 60)
            {

                /*" -751- PERFORM 210-000-CABEC. */

                M_210_000_CABEC_SECTION();
            }


            /*" -753- WRITE REG-SI0106R1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -753- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_999_EXIT*/

        [StopWatch]
        /*" M-210-000-CABEC-SECTION */
        private void M_210_000_CABEC_SECTION()
        {
            /*" -766- MOVE '210-000-CABEC' TO PARAGRAFO. */
            _.Move("210-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -768- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", W.WABEND.WNR_EXEC_SQL);

            /*" -769- ADD 1 TO W-CONT-PAG. */
            W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

            /*" -771- MOVE W-CONT-PAG TO LC01-PAG. */
            _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

            /*" -772- MOVE W-CLIFOR-ATL TO LC05-CLIFOR. */
            _.Move(W.W_PREST_ATL.W_CLIFOR_ATL, W.LC05.LC05_CLIFOR);

            /*" -774- MOVE THIST-NOMFAV TO LC05-NOME. */
            _.Move(THIST_NOMFAV, W.LC05.LC05_NOME);

            /*" -775- WRITE REG-SI0106R1 FROM LC01 AFTER NEW-PAGE */
            _.Move(W.LC01.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -776- WRITE REG-SI0106R1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -778- WRITE REG-SI0106R1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -780- WRITE REG-SI0106R1 FROM LC04C AFTER 1 */
            _.Move(W.LC04C.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -781- WRITE REG-SI0106R1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -782- WRITE REG-SI0106R1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -783- WRITE REG-SI0106R1 FROM LC07 AFTER 1. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -785- WRITE REG-SI0106R1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -785- MOVE 11 TO W-CONT-LIN. */
            _.Move(11, W.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-230-000-IMPRIME-TOTAL-SECTION */
        private void M_230_000_IMPRIME_TOTAL_SECTION()
        {
            /*" -799- MOVE '230-000-IMPRIME-TOTAL' TO PARAGRAFO. */
            _.Move("230-000-IMPRIME-TOTAL", W.WABEND.PARAGRAFO);

            /*" -801- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", W.WABEND.WNR_EXEC_SQL);

            /*" -802- IF WS-TOTAL EQUAL ZEROS */

            if (W.WS_TOTAL == 00)
            {

                /*" -804- GO TO 230-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/ //GOTO
                return;
            }


            /*" -805- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -807- PERFORM 210-000-CABEC. */

                M_210_000_CABEC_SECTION();
            }


            /*" -808- MOVE WS-TOTAL TO LT01-VALOR */
            _.Move(W.WS_TOTAL, W.LT01.LT01_VALOR);

            /*" -810- ADD WS-TOTAL TO WS-TOTAL-GERAL. */
            W.WS_TOTAL_GERAL.Value = W.WS_TOTAL_GERAL + W.WS_TOTAL;

            /*" -812- WRITE REG-SI0106R1 FROM LT01 AFTER 3. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -813- MOVE 90 TO W-CONT-LIN. */
            _.Move(90, W.W_CONT_LIN);

            /*" -814- MOVE 0 TO W-CONT-PAG. */
            _.Move(0, W.W_CONT_PAG);

            /*" -814- MOVE 0 TO WS-TOTAL. */
            _.Move(0, W.WS_TOTAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-240-000-TOTAL-GERAL-SECTION */
        private void M_240_000_TOTAL_GERAL_SECTION()
        {
            /*" -828- MOVE '240-000-TOTAL-GERAL' TO PARAGRAFO. */
            _.Move("240-000-TOTAL-GERAL", W.WABEND.PARAGRAFO);

            /*" -830- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", W.WABEND.WNR_EXEC_SQL);

            /*" -831- IF WS-TOTAL-GERAL EQUAL ZEROS */

            if (W.WS_TOTAL_GERAL == 00)
            {

                /*" -833- GO TO 240-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/ //GOTO
                return;
            }


            /*" -834- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -836- PERFORM 210-000-CABEC. */

                M_210_000_CABEC_SECTION();
            }


            /*" -838- MOVE WS-TOTAL-GERAL TO LT02-VALOR */
            _.Move(W.WS_TOTAL_GERAL, W.LT02.LT02_VALOR);

            /*" -838- WRITE REG-SI0106R1 FROM LT02 AFTER 3. */
            _.Move(W.LT02.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-260-000-IMPRIME-TOTAL-NUMOPG-SECTION */
        private void M_260_000_IMPRIME_TOTAL_NUMOPG_SECTION()
        {
            /*" -852- MOVE '260-000-IMPRIME-TOTAL-NUMOPG' TO PARAGRAFO. */
            _.Move("260-000-IMPRIME-TOTAL-NUMOPG", W.WABEND.PARAGRAFO);

            /*" -854- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", W.WABEND.WNR_EXEC_SQL);

            /*" -855- IF WS-TOTAL-NUMOPG EQUAL ZEROS */

            if (W.WS_TOTAL_NUMOPG == 00)
            {

                /*" -857- GO TO 260-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/ //GOTO
                return;
            }


            /*" -858- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -860- PERFORM 210-000-CABEC. */

                M_210_000_CABEC_SECTION();
            }


            /*" -862- MOVE WS-TOTAL-NUMOPG TO LT03-VALOR */
            _.Move(W.WS_TOTAL_NUMOPG, W.LT03.LT03_VALOR);

            /*" -864- WRITE REG-SI0106R1 FROM LT03 AFTER 3. */
            _.Move(W.LT03.GetMoveValues(), REG_SI0106R1);

            SI0106R1.Write(REG_SI0106R1.GetMoveValues().ToString());

            /*" -865- MOVE +0 TO WS-TOTAL-NUMOPG */
            _.Move(+0, W.WS_TOTAL_NUMOPG);

            /*" -865- ADD 3 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 3;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-600-000-CALCULA-VALOR-SECTION */
        private void M_600_000_CALCULA_VALOR_SECTION()
        {
            /*" -879- MOVE '600-000-CALCULA-VALOR' TO PARAGRAFO. */
            _.Move("600-000-CALCULA-VALOR", W.WABEND.PARAGRAFO);

            /*" -880- DISPLAY PARAGRAFO. */
            _.Display(W.WABEND.PARAGRAFO);

            /*" -882- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", W.WABEND.WNR_EXEC_SQL);

            /*" -884- PERFORM 620-000-LER-TMESTSINI */

            M_620_000_LER_TMESTSINI_SECTION();

            /*" -887- MOVE MEST-MOEDA-SIN TO WGEUNIMO-CODUNIMO WMOEDA. */
            _.Move(MEST_MOEDA_SIN, W.WGEUNIMO_CODUNIMO, WMOEDA);

            /*" -890- MOVE THIST-DTMOVTO TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(THIST_DTMOVTO, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -890- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-SECTION */
        private void M_610_000_LER_TGEUNIMO_SECTION()
        {
            /*" -902- MOVE '610' TO WNR-EXEC-SQL */
            _.Move("610", W.WABEND.WNR_EXEC_SQL);

            /*" -906- MOVE '610-000-LER-TGEUNIMO' TO PARAGRAFO. */
            _.Move("610-000-LER-TGEUNIMO", W.WABEND.PARAGRAFO);

            /*" -915- PERFORM M_610_000_LER_TGEUNIMO_DB_SELECT_1 */

            M_610_000_LER_TGEUNIMO_DB_SELECT_1();

            /*" -918- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -922- DISPLAY ' - SI0106B - NAO CONSTA REGISTRO NA VIMOEDA' ' - CODUNIMO = ' WMOEDA ' - DTINIVIG = ' WGEUNIMO-DTINIVIG ' - DTTERVIG = ' WGEUNIMO-DTTERVIG */

                $" - SI0106B - NAO CONSTA REGISTRO NA VIMOEDA - CODUNIMO = {WMOEDA} - DTINIVIG = {WGEUNIMO_DTINIVIG} - DTTERVIG = {WGEUNIMO_DTTERVIG}"
                .Display();

                /*" -924- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -924- MOVE GEUNIMO-SIGLUNIM TO LD01-LITERAL. */
            _.Move(GEUNIMO_SIGLUNIM, W.LD01.LD01_LITERAL);

        }

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-DB-SELECT-1 */
        public void M_610_000_LER_TGEUNIMO_DB_SELECT_1()
        {
            /*" -915- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :GEUNIMO-VLCRUZAD, :GEUNIMO-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WMOEDA AND DTINIVIG <= :WGEUNIMO-DTINIVIG AND DTTERVIG >= :WGEUNIMO-DTTERVIG END-EXEC. */

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
        /*" M-620-000-LER-TMESTSINI-SECTION */
        private void M_620_000_LER_TMESTSINI_SECTION()
        {
            /*" -935- MOVE '620' TO WNR-EXEC-SQL */
            _.Move("620", W.WABEND.WNR_EXEC_SQL);

            /*" -939- MOVE '620-000-LER-TMESTSINI' TO PARAGRAFO. */
            _.Move("620-000-LER-TMESTSINI", W.WABEND.PARAGRAFO);

            /*" -944- PERFORM M_620_000_LER_TMESTSINI_DB_SELECT_1 */

            M_620_000_LER_TMESTSINI_DB_SELECT_1();

            /*" -947- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -949- DISPLAY ' - SI0106B - NAO CONSTA NO CADASTRO DE MOEDA' ' - APOLICE ==> ' THIST-APOL-SINI */

                $" - SI0106B - NAO CONSTA NO CADASTRO DE MOEDA - APOLICE ==> {THIST_APOL_SINI}"
                .Display();

                /*" -949- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-620-000-LER-TMESTSINI-DB-SELECT-1 */
        public void M_620_000_LER_TMESTSINI_DB_SELECT_1()
        {
            /*" -944- EXEC SQL SELECT COD_MOEDA_SINI INTO :MEST-MOEDA-SIN FROM SEGUROS.V1MESTSINI WHERE NUM_APOL_SINISTRO = :THIST-APOL-SINI END-EXEC. */

            var m_620_000_LER_TMESTSINI_DB_SELECT_1_Query1 = new M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1()
            {
                THIST_APOL_SINI = THIST_APOL_SINI.ToString(),
            };

            var executed_1 = M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1.Execute(m_620_000_LER_TMESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MEST_MOEDA_SIN, MEST_MOEDA_SIN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_620_999_EXIT*/

        [StopWatch]
        /*" M-800-000-ATUALIZA-TRELSIN-E-SECTION */
        private void M_800_000_ATUALIZA_TRELSIN_E_SECTION()
        {
            /*" -964- MOVE '800-000-ATUALIZA-TRELSIN' TO PARAGRAFO. */
            _.Move("800-000-ATUALIZA-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -966- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", W.WABEND.WNR_EXEC_SQL);

            /*" -972- PERFORM M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1 */

            M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-800-000-ATUALIZA-TRELSIN-E-DB-DELETE-1 */
        public void M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1()
        {
            /*" -972- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0106B' AND DATA_SOLICITACAO = :SIST-DTMOVABE END-EXEC. */

            var m_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1 = new M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
            };

            M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1.Execute(m_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -990- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -993- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -995- CLOSE SI0106R1. */
            SI0106R1.Close();

            /*" -997- MOVE 0 TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -998- MOVE WS-TOT-LIDOS TO TOTAL-EDICAO. */
            _.Move(W.WS_TOT_LIDOS, W.TOTAL_EDICAO);

            /*" -999- DISPLAY 'REGISTROS LIDOS     = ' TOTAL-EDICAO. */
            _.Display($"REGISTROS LIDOS     = {W.TOTAL_EDICAO}");

            /*" -1000- MOVE WS-TOT-IMPRESSOS TO TOTAL-EDICAO. */
            _.Move(W.WS_TOT_IMPRESSOS, W.TOTAL_EDICAO);

            /*" -1002- DISPLAY 'REGISTROS IMPRESSOS = ' TOTAL-EDICAO. */
            _.Display($"REGISTROS IMPRESSOS = {W.TOTAL_EDICAO}");

            /*" -1002- DISPLAY 'SI0106B         *** FIM NORMAL ***' . */
            _.Display($"SI0106B         *** FIM NORMAL ***");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1015- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1016- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1017- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1018- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1020- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1022- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1023- CLOSE SI0106R1. */
            SI0106R1.Close();

            /*" -1023- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1024- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1026- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1026- GOBACK. */

            throw new GoBack();

        }
    }
}