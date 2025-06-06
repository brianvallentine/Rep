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
using Sias.Sinistro.DB2.SI0803B;

namespace Code
{
    public class SI0803B
    {
        public bool IsCall { get; set; }

        public SI0803B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    SINISTRO                          //      */
        /*"      * PROGRAMA             :    SI0803B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELACAO DE SINISTRO POR//      */
        /*"      *                           APOLICE PAGOS NO MES/ANO SOLICIT. //      */
        /*"      * ANALISTA/PROGRAMADOR :    BARAN/LIGIA                       //      */
        /*"      * DATA                 :    MAIO/94                           //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *                                                                *      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR JO0800)                                          *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0803M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0803M1
        {
            get
            {
                _.Move(REG_SI0803M1, _SI0803M1); VarBasis.RedefinePassValue(REG_SI0803M1, _SI0803M1, REG_SI0803M1); return _SI0803M1;
            }
        }
        /*"01  REG-SI0803M1.*/
        public SI0803B_REG_SI0803M1 REG_SI0803M1 { get; set; } = new SI0803B_REG_SI0803M1();
        public class SI0803B_REG_SI0803M1 : VarBasis
        {
            /*"    05          LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          TEMPRESA-NOM-EMP      PIC  X(040).*/
        public StringBasis TEMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SIST-DTMOVABE          PIC  X(010).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTCURRENT         PIC  X(010).*/
        public StringBasis SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-APOLICE         PIC S9(013)       COMP-3.*/
        public IntBasis RELSIN_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           RELSIN-ANO-REF         PIC S9(004)       COMP.*/
        public IntBasis RELSIN_ANO_REF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           RELSIN-MES-REF         PIC S9(004)       COMP.*/
        public IntBasis RELSIN_MES_REF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-NUM-APOL          PIC S9(013)       COMP-3.*/
        public IntBasis MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-DATCMD            PIC  X(010).*/
        public StringBasis MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-APOL-SINI         PIC S9(013)       COMP-3.*/
        public IntBasis MEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-DATORR            PIC  X(010).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-CODSUBES          PIC S9(004)       COMP.*/
        public IntBasis MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-FONTE             PIC S9(004)       COMP.*/
        public IntBasis MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-MOEDA-SIN         PIC S9(004)       COMP.*/
        public IntBasis MEST_MOEDA_SIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           HIST-OPERACAO         PIC S9(004)       COMP.*/
        public IntBasis HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           HIST-DTMOVTO          PIC  X(010).*/
        public StringBasis HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           HIST-VALPRI           PIC S9(013)V99    COMP-3.*/
        public DoubleBasis HIST_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           HIST-QTD-MOEDA        PIC S9(010)V9(5)  COMP-3.*/
        public DoubleBasis HIST_QTD_MOEDA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77           HIST-SITUACAO         PIC  X(001).*/
        public StringBasis HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           CLIE-COD-CLIENTE       PIC S9(009)       COMP.*/
        public IntBasis CLIE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           CLIE-NOME-RAZAO        PIC  X(040).*/
        public StringBasis CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           TFONTE-NOMEFTE         PIC  X(040).*/
        public StringBasis TFONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           APOL-NOME              PIC  X(040).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           WDATA-INI              PIC  X(010).*/
        public StringBasis WDATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WDATA-FIM              PIC  X(010).*/
        public StringBasis WDATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              W.*/
        public SI0803B_W W { get; set; } = new SI0803B_W();
        public class SI0803B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0803B_LC01 LC01 { get; set; } = new SI0803B_LC01();
            public class SI0803B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC  X(009) VALUE 'SI0803B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0803B.1");
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
            public SI0803B_LC02 LC02 { get; set; } = new SI0803B_LC02();
            public class SI0803B_LC02 : VarBasis
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
            public SI0803B_LC03 LC03 { get; set; } = new SI0803B_LC03();
            public class SI0803B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04.*/
            }
            public SI0803B_LC04 LC04 { get; set; } = new SI0803B_LC04();
            public class SI0803B_LC04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(031) VALUE               'SINISTROS PAGOS POR APOLICE EM '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"SINISTROS PAGOS POR APOLICE EM ");
                /*"    05          LC04-MES-REF        PIC  X(010) VALUE ZEROS.*/
                public StringBasis LC04_MES_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    05          LC04-ANO-REF        PIC  9(004) VALUE ZEROS.*/
                public IntBasis LC04_ANO_REF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            LC05.*/
            }
            public SI0803B_LC05 LC05 { get; set; } = new SI0803B_LC05();
            public class SI0803B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                'APOLICE - '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"APOLICE - ");
                /*"    05          LC05-APOLICE        PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC05_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          FILLER              PIC  X(011) VALUE               'SEGURADO - '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SEGURADO - ");
                /*"    05          LC05-SEGURADO       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC05_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC06.*/
            }
            public SI0803B_LC06 LC06 { get; set; } = new SI0803B_LC06();
            public class SI0803B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE               'SUB-GRUPO : '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"SUB-GRUPO : ");
                /*"    05          LC06-CODSUBES       PIC  9(004) VALUE ZEROES.*/
                public IntBasis LC06_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC06-NOME-RAZAO     PIC  X(040) VALUE SPACES.*/
                public StringBasis LC06_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC07.*/
            }
            public SI0803B_LC07 LC07 { get; set; } = new SI0803B_LC07();
            public class SI0803B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            LC08.*/
            }
            public SI0803B_LC08 LC08 { get; set; } = new SI0803B_LC08();
            public class SI0803B_LC08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE                                    'SINISTRO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                                    'DATA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA");
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                                    'VALOR'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR");
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                    'OBSERVACAO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"OBSERVACAO");
                /*"  03            LC09.*/
            }
            public SI0803B_LC09 LC09 { get; set; } = new SI0803B_LC09();
            public class SI0803B_LC09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE               'FONTE: '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"FONTE: ");
                /*"    05          LC09-FONTE          PIC  9(004) VALUE ZEROES.*/
                public IntBasis LC09_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC09-NOME-FONTE     PIC  X(040) VALUE SPACES.*/
                public StringBasis LC09_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LD01.*/
            }
            public SI0803B_LD01 LD01 { get; set; } = new SI0803B_LD01();
            public class SI0803B_LD01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-SINISTRO       PIC  9(013) BLANK WHEN ZERO.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(019) VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    05          LD01-DTPAGTO.*/
                public SI0803B_LD01_DTPAGTO LD01_DTPAGTO { get; set; } = new SI0803B_LD01_DTPAGTO();
                public class SI0803B_LD01_DTPAGTO : VarBasis
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
                    /*"    05          FILLER              PIC  X(019) VALUE SPACES.*/
                }
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    05          LD01-VL-PAGO        PIC  ZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LD01-OBS            PIC  X(021) VALUE SPACES.*/
                public StringBasis LD01_OBS { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"  03            LT01.*/
            }
            public SI0803B_LT01 LT01 { get; set; } = new SI0803B_LT01();
            public class SI0803B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LT01-DESCRICAO      PIC  X(030) VALUE SPACES.*/
                public StringBasis LT01_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          LT01-VALOR-PAGO     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT01_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03        WSN-APOLICE-ANT        PIC  9(013) VALUE ZEROS.*/
            }
            public IntBasis WSN_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03        WSN-ANO-REF-ANT        PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSN_ANO_REF_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WSN-MES-REF-ANT        PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSN_MES_REF_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WSN-CODSUBES-ANT       PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSN_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WSN-FONTE-ANT          PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSN_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WSN-APOL-SINI-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WSN_APOL_SINI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03        WSX-DTMOVTO-ANT        PIC  X(010) VALUE ZEROS.*/
            public StringBasis WSX_DTMOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03        WSN-VRPAGO-PFISICA   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_PFISICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-PJURIDI   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_PJURIDI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-APOLICE   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-CODSUBES  PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_CODSUBES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-FONTE     PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_FONTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGAMENTO      PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRCOMPLEMENTO    PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRCOMPLEMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA-CURR.*/
            public SI0803B_WDATA_CURR WDATA_CURR { get; set; } = new SI0803B_WDATA_CURR();
            public class SI0803B_WDATA_CURR : VarBasis
            {
                /*"    05          WDATA-AA-CURR       PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-CURR.*/
            }
            public SI0803B_WHORA_CURR WHORA_CURR { get; set; } = new SI0803B_WHORA_CURR();
            public class SI0803B_WHORA_CURR : VarBasis
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
            public SI0803B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0803B_WDATA_CABEC();
            public class SI0803B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0803B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0803B_WHORA_CABEC();
            public class SI0803B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA.*/
            }
            public SI0803B_WDATA WDATA { get; set; } = new SI0803B_WDATA();
            public class SI0803B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"  03            WDATA-SQL.*/
            public SI0803B_WDATA_SQL WDATA_SQL { get; set; } = new SI0803B_WDATA_SQL();
            public class SI0803B_WDATA_SQL : VarBasis
            {
                /*"    05          W-ANO-SQL           PIC  9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          W-MES-SQL           PIC  9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          W-DIA-SQL           PIC  9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WFIM-TRELSIN        PIC  X(001) VALUE 'N'.*/
            }
            public StringBasis WFIM_TRELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TMESTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TMESTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            W-CONT-PAG          PIC  S9(005) VALUE  +0.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            W-CONT-LIN          PIC  S9(002) VALUE  +99.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +99);
            /*"  03            AC-LID-MESTHIST    PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_LID_MESTHIST { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            AC-LID-TRELSIN     PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_LID_TRELSIN { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            AC-IMPRE           PIC S9(006) COMP VALUE +0.*/
            public IntBasis AC_IMPRE { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03      WANO-BISSEXTO           PIC 9(004)        VALUE ZEROS.*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03      WRESTO                  PIC 9(001)        VALUE ZEROS.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03      J                       PIC 9(002)        VALUE ZEROS.*/
            public IntBasis J { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03        WABEND.*/
            public SI0803B_WABEND WABEND { get; set; } = new SI0803B_WABEND();
            public class SI0803B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0803B'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0803B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0803B_LK_LINK LK_LINK { get; set; } = new SI0803B_LK_LINK();
        public class SI0803B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0803B_V1RELATSINI V1RELATSINI { get; set; } = new SI0803B_V1RELATSINI();
        public SI0803B_TMESTSIN TMESTSIN { get; set; } = new SI0803B_TMESTSIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0803M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0803M1.SetFile(SI0803M1_FILE_NAME_P);

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
            /*" -362- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -365- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -366- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -368- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -370- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -375- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -376- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -377- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -378- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -380- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -382- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -384- PERFORM 520-000-LER-TSISTEMA. */

            M_520_000_LER_TSISTEMA_SECTION();

            /*" -385- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, W.WDATA_CURR);

            /*" -386- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.WDATA_CURR.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -387- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.WDATA_CURR.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -388- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.WDATA_CURR.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -390- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -392- PERFORM 530-000-CURSOR-TRELSIN. */

            M_530_000_CURSOR_TRELSIN_SECTION();

            /*" -394- PERFORM 540-000-LER-TRELSIN. */

            M_540_000_LER_TRELSIN_SECTION();

            /*" -395- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -396- DISPLAY 'SI0803B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0803B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -398- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -401- PERFORM 110-000-PROCESSA-EMISSAO UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_110_000_PROCESSA_EMISSAO_SECTION();
            }

            /*" -401- PERFORM 590-000-ATUALIZA-TRELSIN. */

            M_590_000_ATUALIZA_TRELSIN_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -408- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -408- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -422- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -422- OPEN OUTPUT SI0803M1. */
            SI0803M1.Open(REG_SI0803M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-110-000-PROCESSA-EMISSAO-SECTION */
        private void M_110_000_PROCESSA_EMISSAO_SECTION()
        {
            /*" -436- MOVE '110-000-PROCESSA-EMISSAO' TO PARAGRAFO. */
            _.Move("110-000-PROCESSA-EMISSAO", W.WABEND.PARAGRAFO);

            /*" -437- MOVE RELSIN-APOLICE TO WSN-APOLICE-ANT. */
            _.Move(RELSIN_APOLICE, W.WSN_APOLICE_ANT);

            /*" -438- MOVE RELSIN-ANO-REF TO WSN-ANO-REF-ANT. */
            _.Move(RELSIN_ANO_REF, W.WSN_ANO_REF_ANT);

            /*" -440- MOVE RELSIN-MES-REF TO WSN-MES-REF-ANT. */
            _.Move(RELSIN_MES_REF, W.WSN_MES_REF_ANT);

            /*" -441- MOVE RELSIN-APOLICE TO LC05-APOLICE. */
            _.Move(RELSIN_APOLICE, W.LC05.LC05_APOLICE);

            /*" -443- MOVE RELSIN-ANO-REF TO LC04-ANO-REF. */
            _.Move(RELSIN_ANO_REF, W.LC04.LC04_ANO_REF);

            /*" -444- IF RELSIN-MES-REF = 1 */

            if (RELSIN_MES_REF == 1)
            {

                /*" -445- MOVE 'JANEIRO' TO LC04-MES-REF */
                _.Move("JANEIRO", W.LC04.LC04_MES_REF);

                /*" -446- MOVE 31 TO W-DIA-SQL */
                _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                /*" -447- ELSE */
            }
            else
            {


                /*" -448- IF RELSIN-MES-REF = 2 */

                if (RELSIN_MES_REF == 2)
                {

                    /*" -449- MOVE 'FEVEREIRO' TO LC04-MES-REF */
                    _.Move("FEVEREIRO", W.LC04.LC04_MES_REF);

                    /*" -450- MOVE RELSIN-ANO-REF TO WANO-BISSEXTO */
                    _.Move(RELSIN_ANO_REF, W.WANO_BISSEXTO);

                    /*" -451- DIVIDE WANO-BISSEXTO BY 4 GIVING J REMAINDER WRESTO */
                    _.Divide(W.WANO_BISSEXTO, 4, W.J, W.WRESTO);

                    /*" -452- IF WRESTO EQUAL ZERO */

                    if (W.WRESTO == 00)
                    {

                        /*" -453- MOVE 29 TO W-DIA-SQL */
                        _.Move(29, W.WDATA_SQL.W_DIA_SQL);

                        /*" -454- ELSE */
                    }
                    else
                    {


                        /*" -455- MOVE 28 TO W-DIA-SQL */
                        _.Move(28, W.WDATA_SQL.W_DIA_SQL);

                        /*" -456- END-IF */
                    }


                    /*" -457- ELSE */
                }
                else
                {


                    /*" -458- IF RELSIN-MES-REF = 3 */

                    if (RELSIN_MES_REF == 3)
                    {

                        /*" -459- MOVE 'MARCO' TO LC04-MES-REF */
                        _.Move("MARCO", W.LC04.LC04_MES_REF);

                        /*" -460- MOVE 31 TO W-DIA-SQL */
                        _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                        /*" -461- ELSE */
                    }
                    else
                    {


                        /*" -462- IF RELSIN-MES-REF = 4 */

                        if (RELSIN_MES_REF == 4)
                        {

                            /*" -463- MOVE 'ABRIL' TO LC04-MES-REF */
                            _.Move("ABRIL", W.LC04.LC04_MES_REF);

                            /*" -464- MOVE 30 TO W-DIA-SQL */
                            _.Move(30, W.WDATA_SQL.W_DIA_SQL);

                            /*" -465- ELSE */
                        }
                        else
                        {


                            /*" -466- IF RELSIN-MES-REF = 5 */

                            if (RELSIN_MES_REF == 5)
                            {

                                /*" -467- MOVE 'MAIO' TO LC04-MES-REF */
                                _.Move("MAIO", W.LC04.LC04_MES_REF);

                                /*" -468- MOVE 31 TO W-DIA-SQL */
                                _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                                /*" -469- ELSE */
                            }
                            else
                            {


                                /*" -470- IF RELSIN-MES-REF = 6 */

                                if (RELSIN_MES_REF == 6)
                                {

                                    /*" -471- MOVE 'JUNHO' TO LC04-MES-REF */
                                    _.Move("JUNHO", W.LC04.LC04_MES_REF);

                                    /*" -472- MOVE 30 TO W-DIA-SQL */
                                    _.Move(30, W.WDATA_SQL.W_DIA_SQL);

                                    /*" -473- ELSE */
                                }
                                else
                                {


                                    /*" -474- IF RELSIN-MES-REF = 7 */

                                    if (RELSIN_MES_REF == 7)
                                    {

                                        /*" -475- MOVE 'JULHO' TO LC04-MES-REF */
                                        _.Move("JULHO", W.LC04.LC04_MES_REF);

                                        /*" -476- MOVE 31 TO W-DIA-SQL */
                                        _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                                        /*" -477- ELSE */
                                    }
                                    else
                                    {


                                        /*" -478- IF RELSIN-MES-REF = 8 */

                                        if (RELSIN_MES_REF == 8)
                                        {

                                            /*" -479- MOVE 'AGOSTO' TO LC04-MES-REF */
                                            _.Move("AGOSTO", W.LC04.LC04_MES_REF);

                                            /*" -480- MOVE 31 TO W-DIA-SQL */
                                            _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                                            /*" -481- ELSE */
                                        }
                                        else
                                        {


                                            /*" -482- IF RELSIN-MES-REF = 9 */

                                            if (RELSIN_MES_REF == 9)
                                            {

                                                /*" -483- MOVE 'SETEMBRO' TO LC04-MES-REF */
                                                _.Move("SETEMBRO", W.LC04.LC04_MES_REF);

                                                /*" -484- MOVE 30 TO W-DIA-SQL */
                                                _.Move(30, W.WDATA_SQL.W_DIA_SQL);

                                                /*" -485- ELSE */
                                            }
                                            else
                                            {


                                                /*" -486- IF RELSIN-MES-REF = 10 */

                                                if (RELSIN_MES_REF == 10)
                                                {

                                                    /*" -487- MOVE 'OUTUBRO' TO LC04-MES-REF */
                                                    _.Move("OUTUBRO", W.LC04.LC04_MES_REF);

                                                    /*" -488- MOVE 31 TO W-DIA-SQL */
                                                    _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                                                    /*" -489- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -490- IF RELSIN-MES-REF = 11 */

                                                    if (RELSIN_MES_REF == 11)
                                                    {

                                                        /*" -491- MOVE 'NOVEMBRO' TO LC04-MES-REF */
                                                        _.Move("NOVEMBRO", W.LC04.LC04_MES_REF);

                                                        /*" -492- MOVE 30 TO W-DIA-SQL */
                                                        _.Move(30, W.WDATA_SQL.W_DIA_SQL);

                                                        /*" -493- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -494- IF RELSIN-MES-REF = 12 */

                                                        if (RELSIN_MES_REF == 12)
                                                        {

                                                            /*" -495- MOVE 'DEZEMBRO' TO LC04-MES-REF */
                                                            _.Move("DEZEMBRO", W.LC04.LC04_MES_REF);

                                                            /*" -497- MOVE 31 TO W-DIA-SQL. */
                                                            _.Move(31, W.WDATA_SQL.W_DIA_SQL);
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


            /*" -498- MOVE RELSIN-ANO-REF TO W-ANO-SQL. */
            _.Move(RELSIN_ANO_REF, W.WDATA_SQL.W_ANO_SQL);

            /*" -499- MOVE RELSIN-MES-REF TO W-MES-SQL. */
            _.Move(RELSIN_MES_REF, W.WDATA_SQL.W_MES_SQL);

            /*" -501- MOVE WDATA-SQL TO WDATA-FIM. */
            _.Move(W.WDATA_SQL, WDATA_FIM);

            /*" -502- MOVE 01 TO W-DIA-SQL. */
            _.Move(01, W.WDATA_SQL.W_DIA_SQL);

            /*" -504- MOVE WDATA-SQL TO WDATA-INI. */
            _.Move(W.WDATA_SQL, WDATA_INI);

            /*" -505- PERFORM 580-000-LER-TAPOLICE. */

            M_580_000_LER_TAPOLICE_SECTION();

            /*" -507- MOVE APOL-NOME TO LC05-SEGURADO. */
            _.Move(APOL_NOME, W.LC05.LC05_SEGURADO);

            /*" -511- PERFORM 150-000-PROCESSA-TRELSIN UNTIL WFIM-TRELSIN EQUAL 'S' OR RELSIN-APOLICE NOT EQUAL WSN-APOLICE-ANT OR RELSIN-ANO-REF NOT EQUAL WSN-ANO-REF-ANT OR RELSIN-MES-REF NOT EQUAL WSN-MES-REF-ANT. */

            while (!(W.WFIM_TRELSIN == "S" || RELSIN_APOLICE != W.WSN_APOLICE_ANT || RELSIN_ANO_REF != W.WSN_ANO_REF_ANT || RELSIN_MES_REF != W.WSN_MES_REF_ANT))
            {

                M_150_000_PROCESSA_TRELSIN_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_999_EXIT*/

        [StopWatch]
        /*" M-150-000-PROCESSA-TRELSIN-SECTION */
        private void M_150_000_PROCESSA_TRELSIN_SECTION()
        {
            /*" -526- MOVE '150-000-PROCESSA-TRELSIN' TO PARAGRAFO */
            _.Move("150-000-PROCESSA-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -528- MOVE 'N' TO WFIM-TMESTSIN */
            _.Move("N", W.WFIM_TMESTSIN);

            /*" -529- PERFORM 550-000-CURSOR-TMESTSIN */

            M_550_000_CURSOR_TMESTSIN_SECTION();

            /*" -530- PERFORM 560-000-LER-TMESTSIN */

            M_560_000_LER_TMESTSIN_SECTION();

            /*" -533- PERFORM 230-000-PROCESSA-CODSUBES UNTIL WFIM-TMESTSIN EQUAL 'S' . */

            while (!(W.WFIM_TMESTSIN == "S"))
            {

                M_230_000_PROCESSA_CODSUBES_SECTION();
            }

            /*" -533- PERFORM 380-000-IMPRIME-TOTAL-APOLICE. */

            M_380_000_IMPRIME_TOTAL_APOLICE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_150_010_LEITURA */

            M_150_010_LEITURA();

        }

        [StopWatch]
        /*" M-150-010-LEITURA */
        private void M_150_010_LEITURA(bool isPerform = false)
        {
            /*" -539- PERFORM 540-000-LER-TRELSIN. */

            M_540_000_LER_TRELSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-230-000-PROCESSA-CODSUBES-SECTION */
        private void M_230_000_PROCESSA_CODSUBES_SECTION()
        {
            /*" -553- MOVE '230-000-PROCESSA-CODSUBES' TO PARAGRAFO. */
            _.Move("230-000-PROCESSA-CODSUBES", W.WABEND.PARAGRAFO);

            /*" -554- MOVE MEST-CODSUBES TO LC06-CODSUBES */
            _.Move(MEST_CODSUBES, W.LC06.LC06_CODSUBES);

            /*" -555- PERFORM 570-000-LER-TCLIENTE */

            M_570_000_LER_TCLIENTE_SECTION();

            /*" -557- MOVE CLIE-NOME-RAZAO TO LC06-NOME-RAZAO */
            _.Move(CLIE_NOME_RAZAO, W.LC06.LC06_NOME_RAZAO);

            /*" -559- MOVE MEST-CODSUBES TO WSN-CODSUBES-ANT */
            _.Move(MEST_CODSUBES, W.WSN_CODSUBES_ANT);

            /*" -563- PERFORM 240-000-PROCESSA-FONTE UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT))
            {

                M_240_000_PROCESSA_FONTE_SECTION();
            }

            /*" -564- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -566- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -567- MOVE 'TOTAL SUB-GRUPO' TO LT01-DESCRICAO */
            _.Move("TOTAL SUB-GRUPO", W.LT01.LT01_DESCRICAO);

            /*" -569- MOVE WSN-VRPAGO-CODSUBES TO LT01-VALOR-PAGO */
            _.Move(W.WSN_VRPAGO_CODSUBES, W.LT01.LT01_VALOR_PAGO);

            /*" -571- WRITE REG-SI0803M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -573- MOVE +70 TO W-CONT-LIN. */
            _.Move(+70, W.W_CONT_LIN);

            /*" -574- IF WSN-CODSUBES-ANT = 1 */

            if (W.WSN_CODSUBES_ANT == 1)
            {

                /*" -575- ADD WSN-VRPAGO-CODSUBES TO WSN-VRPAGO-PFISICA */
                W.WSN_VRPAGO_PFISICA.Value = W.WSN_VRPAGO_PFISICA + W.WSN_VRPAGO_CODSUBES;

                /*" -576- ELSE */
            }
            else
            {


                /*" -578- ADD WSN-VRPAGO-CODSUBES TO WSN-VRPAGO-PJURIDI. */
                W.WSN_VRPAGO_PJURIDI.Value = W.WSN_VRPAGO_PJURIDI + W.WSN_VRPAGO_CODSUBES;
            }


            /*" -579- ADD WSN-VRPAGO-CODSUBES TO WSN-VRPAGO-APOLICE */
            W.WSN_VRPAGO_APOLICE.Value = W.WSN_VRPAGO_APOLICE + W.WSN_VRPAGO_CODSUBES;

            /*" -579- MOVE +0 TO WSN-VRPAGO-CODSUBES. */
            _.Move(+0, W.WSN_VRPAGO_CODSUBES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-240-000-PROCESSA-FONTE-SECTION */
        private void M_240_000_PROCESSA_FONTE_SECTION()
        {
            /*" -593- MOVE '240-000-PROCESSA-FONTE' TO PARAGRAFO. */
            _.Move("240-000-PROCESSA-FONTE", W.WABEND.PARAGRAFO);

            /*" -595- MOVE MEST-FONTE TO WSN-FONTE-ANT */
            _.Move(MEST_FONTE, W.WSN_FONTE_ANT);

            /*" -596- MOVE MEST-FONTE TO LC09-FONTE */
            _.Move(MEST_FONTE, W.LC09.LC09_FONTE);

            /*" -597- PERFORM 575-000-LER-TFONTE */

            M_575_000_LER_TFONTE_SECTION();

            /*" -599- MOVE TFONTE-NOMEFTE TO LC09-NOME-FONTE */
            _.Move(TFONTE_NOMEFTE, W.LC09.LC09_NOME_FONTE);

            /*" -600- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -602- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -604- WRITE REG-SI0803M1 FROM LC09 AFTER 1. */
            _.Move(W.LC09.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -606- ADD 1 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 1;

            /*" -611- PERFORM 250-000-PROCESSA-APOL-SINI UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT OR MEST-FONTE NOT EQUAL WSN-FONTE-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT || MEST_FONTE != W.WSN_FONTE_ANT))
            {

                M_250_000_PROCESSA_APOL_SINI_SECTION();
            }

            /*" -612- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -614- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -615- MOVE 'TOTAL FONTE' TO LT01-DESCRICAO */
            _.Move("TOTAL FONTE", W.LT01.LT01_DESCRICAO);

            /*" -617- MOVE WSN-VRPAGO-FONTE TO LT01-VALOR-PAGO */
            _.Move(W.WSN_VRPAGO_FONTE, W.LT01.LT01_VALOR_PAGO);

            /*" -619- WRITE REG-SI0803M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -621- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

            /*" -622- ADD WSN-VRPAGO-FONTE TO WSN-VRPAGO-CODSUBES */
            W.WSN_VRPAGO_CODSUBES.Value = W.WSN_VRPAGO_CODSUBES + W.WSN_VRPAGO_FONTE;

            /*" -622- MOVE +0 TO WSN-VRPAGO-FONTE. */
            _.Move(+0, W.WSN_VRPAGO_FONTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-250-000-PROCESSA-APOL-SINI-SECTION */
        private void M_250_000_PROCESSA_APOL_SINI_SECTION()
        {
            /*" -636- MOVE '250-000-PROCESSA-APOL-SINI' TO PARAGRAFO. */
            _.Move("250-000-PROCESSA-APOL-SINI", W.WABEND.PARAGRAFO);

            /*" -637- MOVE MEST-APOL-SINI TO WSN-APOL-SINI-ANT */
            _.Move(MEST_APOL_SINI, W.WSN_APOL_SINI_ANT);

            /*" -638- MOVE SPACES TO LD01 */
            _.Move("", W.LD01);

            /*" -640- MOVE MEST-APOL-SINI TO LD01-SINISTRO */
            _.Move(MEST_APOL_SINI, W.LD01.LD01_SINISTRO);

            /*" -644- PERFORM 260-000-PROCESSA-DTMOVTO UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT OR MEST-FONTE NOT EQUAL WSN-FONTE-ANT OR MEST-APOL-SINI NOT EQUAL WSN-APOL-SINI-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT || MEST_FONTE != W.WSN_FONTE_ANT || MEST_APOL_SINI != W.WSN_APOL_SINI_ANT))
            {

                M_260_000_PROCESSA_DTMOVTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_250_999_EXIT*/

        [StopWatch]
        /*" M-260-000-PROCESSA-DTMOVTO-SECTION */
        private void M_260_000_PROCESSA_DTMOVTO_SECTION()
        {
            /*" -658- MOVE '260-000-PROCESSA-DTMOVTO' TO PARAGRAFO. */
            _.Move("260-000-PROCESSA-DTMOVTO", W.WABEND.PARAGRAFO);

            /*" -660- MOVE ZEROS TO WSN-VRPAGAMENTO WSN-VRCOMPLEMENTO. */
            _.Move(0, W.WSN_VRPAGAMENTO, W.WSN_VRCOMPLEMENTO);

            /*" -661- MOVE HIST-DTMOVTO TO WSX-DTMOVTO-ANT */
            _.Move(HIST_DTMOVTO, W.WSX_DTMOVTO_ANT);

            /*" -662- MOVE HIST-DTMOVTO TO WDATA-R */
            _.Move(HIST_DTMOVTO, W.WDATA_R);

            /*" -663- MOVE WDATA-DD TO LD01-DTPAGTO-DD */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_DD);

            /*" -664- MOVE WDATA-MM TO LD01-DTPAGTO-MM */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_MM);

            /*" -665- MOVE WDATA-AA TO LD01-DTPAGTO-AA */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_AA);

            /*" -666- MOVE '/' TO LD01-FIL3 */
            _.Move("/", W.LD01.LD01_DTPAGTO.LD01_FIL3);

            /*" -668- MOVE '/' TO LD01-FIL4 */
            _.Move("/", W.LD01.LD01_DTPAGTO.LD01_FIL4);

            /*" -675- PERFORM 280-000-CONSOLIDA-OPERACAO UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT OR MEST-FONTE NOT EQUAL WSN-FONTE-ANT OR MEST-APOL-SINI NOT EQUAL WSN-APOL-SINI-ANT OR HIST-DTMOVTO NOT EQUAL WSX-DTMOVTO-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT || MEST_FONTE != W.WSN_FONTE_ANT || MEST_APOL_SINI != W.WSN_APOL_SINI_ANT || HIST_DTMOVTO != W.WSX_DTMOVTO_ANT))
            {

                M_280_000_CONSOLIDA_OPERACAO_SECTION();
            }

            /*" -676- IF WSN-VRPAGAMENTO NOT EQUAL ZEROS */

            if (W.WSN_VRPAGAMENTO != 00)
            {

                /*" -677- MOVE WSN-VRPAGAMENTO TO LD01-VL-PAGO */
                _.Move(W.WSN_VRPAGAMENTO, W.LD01.LD01_VL_PAGO);

                /*" -678- MOVE 'PAGAMENTO' TO LD01-OBS */
                _.Move("PAGAMENTO", W.LD01.LD01_OBS);

                /*" -680- PERFORM 350-000-IMPRIME-PAGAMENTO. */

                M_350_000_IMPRIME_PAGAMENTO_SECTION();
            }


            /*" -681- IF WSN-VRCOMPLEMENTO NOT EQUAL ZEROS */

            if (W.WSN_VRCOMPLEMENTO != 00)
            {

                /*" -682- MOVE WSN-VRCOMPLEMENTO TO LD01-VL-PAGO */
                _.Move(W.WSN_VRCOMPLEMENTO, W.LD01.LD01_VL_PAGO);

                /*" -683- MOVE 'PAGTO.COMPLEMENTAR' TO LD01-OBS */
                _.Move("PAGTO.COMPLEMENTAR", W.LD01.LD01_OBS);

                /*" -683- PERFORM 350-000-IMPRIME-PAGAMENTO. */

                M_350_000_IMPRIME_PAGAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-280-000-CONSOLIDA-OPERACAO-SECTION */
        private void M_280_000_CONSOLIDA_OPERACAO_SECTION()
        {
            /*" -697- MOVE '280-000-CONSOLIDA-OPERACAO' TO PARAGRAFO. */
            _.Move("280-000-CONSOLIDA-OPERACAO", W.WABEND.PARAGRAFO);

            /*" -700- IF HIST-OPERACAO EQUAL 1001 OR 1002 OR 1003 OR 1009 OR 9001 */

            if (HIST_OPERACAO.In("1001", "1002", "1003", "1009", "9001"))
            {

                /*" -701- ADD HIST-VALPRI TO WSN-VRPAGAMENTO */
                W.WSN_VRPAGAMENTO.Value = W.WSN_VRPAGAMENTO + HIST_VALPRI;

                /*" -702- ELSE */
            }
            else
            {


                /*" -703- IF HIST-OPERACAO EQUAL 1004 */

                if (HIST_OPERACAO == 1004)
                {

                    /*" -703- ADD HIST-VALPRI TO WSN-VRCOMPLEMENTO. */
                    W.WSN_VRCOMPLEMENTO.Value = W.WSN_VRCOMPLEMENTO + HIST_VALPRI;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_280_010_LEITURA */

            M_280_010_LEITURA();

        }

        [StopWatch]
        /*" M-280-010-LEITURA */
        private void M_280_010_LEITURA(bool isPerform = false)
        {
            /*" -708- PERFORM 560-000-LER-TMESTSIN. */

            M_560_000_LER_TMESTSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/

        [StopWatch]
        /*" M-350-000-IMPRIME-PAGAMENTO-SECTION */
        private void M_350_000_IMPRIME_PAGAMENTO_SECTION()
        {
            /*" -721- MOVE '350-000-IMPRIME-PAGAMENTO' TO PARAGRAFO. */
            _.Move("350-000-IMPRIME-PAGAMENTO", W.WABEND.PARAGRAFO);

            /*" -722- IF W-CONT-LIN GREATER 60 */

            if (W.W_CONT_LIN > 60)
            {

                /*" -724- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -727- WRITE REG-SI0803M1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -728- ADD 1 TO AC-IMPRE. */
            W.AC_IMPRE.Value = W.AC_IMPRE + 1;

            /*" -729- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

            /*" -731- MOVE SPACES TO LD01. */
            _.Move("", W.LD01);

            /*" -732- ADD WSN-VRPAGAMENTO TO WSN-VRPAGO-FONTE */
            W.WSN_VRPAGO_FONTE.Value = W.WSN_VRPAGO_FONTE + W.WSN_VRPAGAMENTO;

            /*" -733- ADD WSN-VRCOMPLEMENTO TO WSN-VRPAGO-FONTE */
            W.WSN_VRPAGO_FONTE.Value = W.WSN_VRPAGO_FONTE + W.WSN_VRCOMPLEMENTO;

            /*" -734- MOVE ZEROS TO WSN-VRPAGAMENTO WSN-VRCOMPLEMENTO. */
            _.Move(0, W.WSN_VRPAGAMENTO, W.WSN_VRCOMPLEMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/

        [StopWatch]
        /*" M-380-000-IMPRIME-TOTAL-APOLICE-SECTION */
        private void M_380_000_IMPRIME_TOTAL_APOLICE_SECTION()
        {
            /*" -748- MOVE '380-000-IMPRIME-TOTAL-APOLICE' TO PARAGRAFO. */
            _.Move("380-000-IMPRIME-TOTAL-APOLICE", W.WABEND.PARAGRAFO);

            /*" -749- IF W-CONT-LIN GREATER 50 */

            if (W.W_CONT_LIN > 50)
            {

                /*" -750- ADD 1 TO W-CONT-PAG */
                W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

                /*" -751- MOVE W-CONT-PAG TO LC01-PAG */
                _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

                /*" -753- WRITE REG-SI0803M1 FROM LC01 AFTER NEW-PAGE */
                _.Move(W.LC01.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -755- WRITE REG-SI0803M1 FROM LC02 AFTER 1 */
                _.Move(W.LC02.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -757- WRITE REG-SI0803M1 FROM LC03 AFTER 1 */
                _.Move(W.LC03.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -759- WRITE REG-SI0803M1 FROM LC04 AFTER 1 */
                _.Move(W.LC04.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -761- WRITE REG-SI0803M1 FROM LC05 AFTER 2 */
                _.Move(W.LC05.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -763- WRITE REG-SI0803M1 FROM LC07 AFTER 1 */
                _.Move(W.LC07.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -765- MOVE 6 TO W-CONT-LIN. */
                _.Move(6, W.W_CONT_LIN);
            }


            /*" -766- IF WSN-APOLICE-ANT = 0097010000889 */

            if (W.WSN_APOLICE_ANT == 0097010000889)
            {

                /*" -767- MOVE 'TOTAL PESSOA FISICA' TO LT01-DESCRICAO */
                _.Move("TOTAL PESSOA FISICA", W.LT01.LT01_DESCRICAO);

                /*" -768- MOVE WSN-VRPAGO-PFISICA TO LT01-VALOR-PAGO */
                _.Move(W.WSN_VRPAGO_PFISICA, W.LT01.LT01_VALOR_PAGO);

                /*" -770- WRITE REG-SI0803M1 FROM LT01 AFTER 2 */
                _.Move(W.LT01.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

                /*" -771- MOVE 'TOTAL PESSOA JURIDICA' TO LT01-DESCRICAO */
                _.Move("TOTAL PESSOA JURIDICA", W.LT01.LT01_DESCRICAO);

                /*" -772- MOVE WSN-VRPAGO-PJURIDI TO LT01-VALOR-PAGO */
                _.Move(W.WSN_VRPAGO_PJURIDI, W.LT01.LT01_VALOR_PAGO);

                /*" -775- WRITE REG-SI0803M1 FROM LT01 AFTER 2. */
                _.Move(W.LT01.GetMoveValues(), REG_SI0803M1);

                SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());
            }


            /*" -776- MOVE 'TOTAL APOLICE' TO LT01-DESCRICAO */
            _.Move("TOTAL APOLICE", W.LT01.LT01_DESCRICAO);

            /*" -778- MOVE WSN-VRPAGO-APOLICE TO LT01-VALOR-PAGO */
            _.Move(W.WSN_VRPAGO_APOLICE, W.LT01.LT01_VALOR_PAGO);

            /*" -781- WRITE REG-SI0803M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -784- MOVE +0 TO WSN-VRPAGO-PFISICA WSN-VRPAGO-PJURIDI WSN-VRPAGO-APOLICE. */
            _.Move(+0, W.WSN_VRPAGO_PFISICA, W.WSN_VRPAGO_PJURIDI, W.WSN_VRPAGO_APOLICE);

            /*" -785- MOVE +99 TO W-CONT-LIN. */
            _.Move(+99, W.W_CONT_LIN);

            /*" -785- MOVE +0 TO W-CONT-PAG. */
            _.Move(+0, W.W_CONT_PAG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_380_999_EXIT*/

        [StopWatch]
        /*" M-390-000-CABEC-SECTION */
        private void M_390_000_CABEC_SECTION()
        {
            /*" -798- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -799- IF W-CONT-LIN GREATER 90 */

            if (W.W_CONT_LIN > 90)
            {

                /*" -801- PERFORM 400-000-CARGA-CABEC. */

                M_400_000_CARGA_CABEC_SECTION();
            }


            /*" -802- ADD 1 TO W-CONT-PAG. */
            W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

            /*" -805- MOVE W-CONT-PAG TO LC01-PAG. */
            _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

            /*" -808- WRITE REG-SI0803M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -811- WRITE REG-SI0803M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -814- WRITE REG-SI0803M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -817- WRITE REG-SI0803M1 FROM LC04 AFTER 1 */
            _.Move(W.LC04.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -820- WRITE REG-SI0803M1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -823- WRITE REG-SI0803M1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -826- WRITE REG-SI0803M1 FROM LC07 AFTER 1. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -829- WRITE REG-SI0803M1 FROM LC08 AFTER 1. */
            _.Move(W.LC08.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -832- WRITE REG-SI0803M1 FROM LC07 AFTER 1. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0803M1);

            SI0803M1.Write(REG_SI0803M1.GetMoveValues().ToString());

            /*" -832- MOVE 10 TO W-CONT-LIN. */
            _.Move(10, W.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-400-000-CARGA-CABEC-SECTION */
        private void M_400_000_CARGA_CABEC_SECTION()
        {
            /*" -846- PERFORM 510-000-LER-TEMPRESA. */

            M_510_000_LER_TEMPRESA_SECTION();

            /*" -847- MOVE TEMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(TEMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -849- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -850- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -851- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -852- ELSE */
            }
            else
            {


                /*" -853- DISPLAY 'SI0803B - PROBLEMA CALL PROALN01 ' */
                _.Display($"SI0803B - PROBLEMA CALL PROALN01 ");

                /*" -854- DISPLAY '          EMPRESA: ' TEMPRESA-NOM-EMP */
                _.Display($"          EMPRESA: {TEMPRESA_NOM_EMP}");

                /*" -855- CLOSE SI0803M1 */
                SI0803M1.Close();

                /*" -855- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-510-000-LER-TEMPRESA-SECTION */
        private void M_510_000_LER_TEMPRESA_SECTION()
        {
            /*" -870- MOVE '510-000-LER-TEMPRESA' TO PARAGRAFO. */
            _.Move("510-000-LER-TEMPRESA", W.WABEND.PARAGRAFO);

            /*" -872- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", W.WABEND.WNR_EXEC_SQL);

            /*" -877- PERFORM M_510_000_LER_TEMPRESA_DB_SELECT_1 */

            M_510_000_LER_TEMPRESA_DB_SELECT_1();

            /*" -880- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -881- DISPLAY 'SI0803B - NAO CONSTA REGISTRO NA TEMPRESA' */
                _.Display($"SI0803B - NAO CONSTA REGISTRO NA TEMPRESA");

                /*" -881- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-510-000-LER-TEMPRESA-DB-SELECT-1 */
        public void M_510_000_LER_TEMPRESA_DB_SELECT_1()
        {
            /*" -877- EXEC SQL SELECT NOME_EMPRESA INTO :TEMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_510_000_LER_TEMPRESA_DB_SELECT_1_Query1 = new M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1.Execute(m_510_000_LER_TEMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TEMPRESA_NOM_EMP, TEMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_999_EXIT*/

        [StopWatch]
        /*" M-520-000-LER-TSISTEMA-SECTION */
        private void M_520_000_LER_TSISTEMA_SECTION()
        {
            /*" -896- MOVE '520-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("520-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -898- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", W.WABEND.WNR_EXEC_SQL);

            /*" -903- PERFORM M_520_000_LER_TSISTEMA_DB_SELECT_1 */

            M_520_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -906- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -907- DISPLAY 'SI0803B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0803B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -907- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-520-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_520_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -903- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_520_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_520_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
                _.Move(executed_1.SIST_DTCURRENT, SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_520_999_EXIT*/

        [StopWatch]
        /*" M-530-000-CURSOR-TRELSIN-SECTION */
        private void M_530_000_CURSOR_TRELSIN_SECTION()
        {
            /*" -924- MOVE '530-000-CURSOR-TRELSIN' TO PARAGRAFO */
            _.Move("530-000-CURSOR-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -926- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", W.WABEND.WNR_EXEC_SQL);

            /*" -936- PERFORM M_530_000_CURSOR_TRELSIN_DB_DECLARE_1 */

            M_530_000_CURSOR_TRELSIN_DB_DECLARE_1();

            /*" -938- PERFORM M_530_000_CURSOR_TRELSIN_DB_OPEN_1 */

            M_530_000_CURSOR_TRELSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-530-000-CURSOR-TRELSIN-DB-DECLARE-1 */
        public void M_530_000_CURSOR_TRELSIN_DB_DECLARE_1()
        {
            /*" -936- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT NUM_APOLICE, ANO_REFERENCIA, MES_REFERENCIA FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0803B' AND DATA_SOLICITACAO = :SIST-DTMOVABE AND SITUACAO = '0' ORDER BY NUM_APOLICE, ANO_REFERENCIA, MES_REFERENCIA END-EXEC. */
            V1RELATSINI = new SI0803B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							ANO_REFERENCIA
							, 
							MES_REFERENCIA 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0803B' 
							AND DATA_SOLICITACAO = '{SIST_DTMOVABE}' 
							AND SITUACAO = '0' 
							ORDER BY NUM_APOLICE
							, ANO_REFERENCIA
							, MES_REFERENCIA";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-530-000-CURSOR-TRELSIN-DB-OPEN-1 */
        public void M_530_000_CURSOR_TRELSIN_DB_OPEN_1()
        {
            /*" -938- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-DB-DECLARE-1 */
        public void M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1()
        {
            /*" -1014- EXEC SQL DECLARE TMESTSIN CURSOR FOR SELECT M.CODSUBES, M.FONTE, M.NUM_APOL_SINISTRO, H.DTMOVTO, H.OPERACAO, H.VAL_OPERACAO FROM SEGUROS.V1MESTSINI M, SEGUROS.V1HISTSINI H WHERE M.NUM_APOLICE = :RELSIN-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.OPERACAO IN (1001, 1002, 1003, 1004, 1009, 9001) AND H.DTMOVTO BETWEEN :WDATA-INI AND :WDATA-FIM AND H.SITUACAO IN ( '1' , '0' ) ORDER BY M.CODSUBES, M.FONTE, M.NUM_APOL_SINISTRO, H.DTMOVTO, H.OPERACAO END-EXEC. */
            TMESTSIN = new SI0803B_TMESTSIN(true);
            string GetQuery_TMESTSIN()
            {
                var query = @$"SELECT M.CODSUBES
							, 
							M.FONTE
							, 
							M.NUM_APOL_SINISTRO
							, 
							H.DTMOVTO
							, 
							H.OPERACAO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.V1MESTSINI M
							, 
							SEGUROS.V1HISTSINI H 
							WHERE 
							M.NUM_APOLICE = '{RELSIN_APOLICE}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.OPERACAO IN (1001
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
							AND H.DTMOVTO BETWEEN '{WDATA_INI}' 
							AND '{WDATA_FIM}' 
							AND H.SITUACAO IN ( '1'
							, '0' ) 
							ORDER BY M.CODSUBES
							, 
							M.FONTE
							, 
							M.NUM_APOL_SINISTRO
							, 
							H.DTMOVTO
							, 
							H.OPERACAO";

                return query;
            }
            TMESTSIN.GetQueryEvent += GetQuery_TMESTSIN;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_999_EXIT*/

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-SECTION */
        private void M_540_000_LER_TRELSIN_SECTION()
        {
            /*" -954- MOVE '540-000-LER-TRELSIN' TO PARAGRAFO. */
            _.Move("540-000-LER-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -956- MOVE '540' TO WNR-EXEC-SQL. */
            _.Move("540", W.WABEND.WNR_EXEC_SQL);

            /*" -960- PERFORM M_540_000_LER_TRELSIN_DB_FETCH_1 */

            M_540_000_LER_TRELSIN_DB_FETCH_1();

            /*" -963- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -963- PERFORM M_540_000_LER_TRELSIN_DB_CLOSE_1 */

                M_540_000_LER_TRELSIN_DB_CLOSE_1();

                /*" -965- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -966- ELSE */
            }
            else
            {


                /*" -966- ADD 1 TO AC-LID-TRELSIN. */
                W.AC_LID_TRELSIN.Value = W.AC_LID_TRELSIN + 1;
            }


        }

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-DB-FETCH-1 */
        public void M_540_000_LER_TRELSIN_DB_FETCH_1()
        {
            /*" -960- EXEC SQL FETCH V1RELATSINI INTO :RELSIN-APOLICE, :RELSIN-ANO-REF, :RELSIN-MES-REF END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELSIN_APOLICE, RELSIN_APOLICE);
                _.Move(V1RELATSINI.RELSIN_ANO_REF, RELSIN_ANO_REF);
                _.Move(V1RELATSINI.RELSIN_MES_REF, RELSIN_MES_REF);
            }

        }

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-DB-CLOSE-1 */
        public void M_540_000_LER_TRELSIN_DB_CLOSE_1()
        {
            /*" -963- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_540_999_EXIT*/

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-SECTION */
        private void M_550_000_CURSOR_TMESTSIN_SECTION()
        {
            /*" -984- MOVE '550-000-CURSOR-TMESTSIN' TO PARAGRAFO. */
            _.Move("550-000-CURSOR-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -986- MOVE '550' TO WNR-EXEC-SQL. */
            _.Move("550", W.WABEND.WNR_EXEC_SQL);

            /*" -1014- PERFORM M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1 */

            M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1();

            /*" -1015- PERFORM M_550_000_CURSOR_TMESTSIN_DB_OPEN_1 */

            M_550_000_CURSOR_TMESTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-DB-OPEN-1 */
        public void M_550_000_CURSOR_TMESTSIN_DB_OPEN_1()
        {
            /*" -1015- EXEC SQL OPEN TMESTSIN END-EXEC. */

            TMESTSIN.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_999_EXIT*/

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-SECTION */
        private void M_560_000_LER_TMESTSIN_SECTION()
        {
            /*" -1031- MOVE '560-000-LER-TMESTSIN' TO PARAGRAFO. */
            _.Move("560-000-LER-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -1033- MOVE '560' TO WNR-EXEC-SQL. */
            _.Move("560", W.WABEND.WNR_EXEC_SQL);

            /*" -1040- PERFORM M_560_000_LER_TMESTSIN_DB_FETCH_1 */

            M_560_000_LER_TMESTSIN_DB_FETCH_1();

            /*" -1043- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1043- PERFORM M_560_000_LER_TMESTSIN_DB_CLOSE_1 */

                M_560_000_LER_TMESTSIN_DB_CLOSE_1();

                /*" -1045- MOVE 'S' TO WFIM-TMESTSIN */
                _.Move("S", W.WFIM_TMESTSIN);

                /*" -1046- ELSE */
            }
            else
            {


                /*" -1046- ADD 1 TO AC-LID-MESTHIST. */
                W.AC_LID_MESTHIST.Value = W.AC_LID_MESTHIST + 1;
            }


        }

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-DB-FETCH-1 */
        public void M_560_000_LER_TMESTSIN_DB_FETCH_1()
        {
            /*" -1040- EXEC SQL FETCH TMESTSIN INTO :MEST-CODSUBES, :MEST-FONTE, :MEST-APOL-SINI, :HIST-DTMOVTO, :HIST-OPERACAO, :HIST-VALPRI END-EXEC. */

            if (TMESTSIN.Fetch())
            {
                _.Move(TMESTSIN.MEST_CODSUBES, MEST_CODSUBES);
                _.Move(TMESTSIN.MEST_FONTE, MEST_FONTE);
                _.Move(TMESTSIN.MEST_APOL_SINI, MEST_APOL_SINI);
                _.Move(TMESTSIN.HIST_DTMOVTO, HIST_DTMOVTO);
                _.Move(TMESTSIN.HIST_OPERACAO, HIST_OPERACAO);
                _.Move(TMESTSIN.HIST_VALPRI, HIST_VALPRI);
            }

        }

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-DB-CLOSE-1 */
        public void M_560_000_LER_TMESTSIN_DB_CLOSE_1()
        {
            /*" -1043- EXEC SQL CLOSE TMESTSIN END-EXEC */

            TMESTSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_560_999_EXIT*/

        [StopWatch]
        /*" M-570-000-LER-TCLIENTE-SECTION */
        private void M_570_000_LER_TCLIENTE_SECTION()
        {
            /*" -1061- MOVE '570-000-LER-TCLIENTE' TO PARAGRAFO. */
            _.Move("570-000-LER-TCLIENTE", W.WABEND.PARAGRAFO);

            /*" -1063- MOVE '570' TO WNR-EXEC-SQL. */
            _.Move("570", W.WABEND.WNR_EXEC_SQL);

            /*" -1069- PERFORM M_570_000_LER_TCLIENTE_DB_SELECT_1 */

            M_570_000_LER_TCLIENTE_DB_SELECT_1();

            /*" -1072- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1073- DISPLAY 'SI0803B- NAO EXISTE REGISTRO NA TSUBGRUPO' */
                _.Display($"SI0803B- NAO EXISTE REGISTRO NA TSUBGRUPO");

                /*" -1074- DISPLAY 'NUM-APOLICE = ' RELSIN-APOLICE */
                _.Display($"NUM-APOLICE = {RELSIN_APOLICE}");

                /*" -1076- DISPLAY 'COD-SUBGRUPO= ' MEST-CODSUBES. */
                _.Display($"COD-SUBGRUPO= {MEST_CODSUBES}");
            }


            /*" -1078- MOVE SPACES TO CLIE-NOME-RAZAO */
            _.Move("", CLIE_NOME_RAZAO);

            /*" -1083- PERFORM M_570_000_LER_TCLIENTE_DB_SELECT_2 */

            M_570_000_LER_TCLIENTE_DB_SELECT_2();

            /*" -1086- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1087- DISPLAY 'SI0803B- NAO EXISTE REGISTRO NA TCLIENTE' */
                _.Display($"SI0803B- NAO EXISTE REGISTRO NA TCLIENTE");

                /*" -1087- DISPLAY 'COD-CLIENTE = ' CLIE-COD-CLIENTE. */
                _.Display($"COD-CLIENTE = {CLIE_COD_CLIENTE}");
            }


        }

        [StopWatch]
        /*" M-570-000-LER-TCLIENTE-DB-SELECT-1 */
        public void M_570_000_LER_TCLIENTE_DB_SELECT_1()
        {
            /*" -1069- EXEC SQL SELECT COD_CLIENTE INTO :CLIE-COD-CLIENTE FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :RELSIN-APOLICE AND COD_SUBGRUPO = :MEST-CODSUBES END-EXEC. */

            var m_570_000_LER_TCLIENTE_DB_SELECT_1_Query1 = new M_570_000_LER_TCLIENTE_DB_SELECT_1_Query1()
            {
                RELSIN_APOLICE = RELSIN_APOLICE.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
            };

            var executed_1 = M_570_000_LER_TCLIENTE_DB_SELECT_1_Query1.Execute(m_570_000_LER_TCLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_COD_CLIENTE, CLIE_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_570_999_EXIT*/

        [StopWatch]
        /*" M-570-000-LER-TCLIENTE-DB-SELECT-2 */
        public void M_570_000_LER_TCLIENTE_DB_SELECT_2()
        {
            /*" -1083- EXEC SQL SELECT NOME_RAZAO INTO :CLIE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :CLIE-COD-CLIENTE END-EXEC. */

            var m_570_000_LER_TCLIENTE_DB_SELECT_2_Query1 = new M_570_000_LER_TCLIENTE_DB_SELECT_2_Query1()
            {
                CLIE_COD_CLIENTE = CLIE_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_570_000_LER_TCLIENTE_DB_SELECT_2_Query1.Execute(m_570_000_LER_TCLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_NOME_RAZAO, CLIE_NOME_RAZAO);
            }


        }

        [StopWatch]
        /*" M-575-000-LER-TFONTE-SECTION */
        private void M_575_000_LER_TFONTE_SECTION()
        {
            /*" -1103- MOVE '575-000-LER-TFONTE' TO PARAGRAFO. */
            _.Move("575-000-LER-TFONTE", W.WABEND.PARAGRAFO);

            /*" -1105- MOVE '575' TO WNR-EXEC-SQL. */
            _.Move("575", W.WABEND.WNR_EXEC_SQL);

            /*" -1107- MOVE SPACES TO TFONTE-NOMEFTE */
            _.Move("", TFONTE_NOMEFTE);

            /*" -1112- PERFORM M_575_000_LER_TFONTE_DB_SELECT_1 */

            M_575_000_LER_TFONTE_DB_SELECT_1();

            /*" -1115- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1116- DISPLAY 'SI0803B - NAO EXISTE REGISTRO NA TFONTE' */
                _.Display($"SI0803B - NAO EXISTE REGISTRO NA TFONTE");

                /*" -1116- DISPLAY '          FONTE = ' MEST-FONTE. */
                _.Display($"          FONTE = {MEST_FONTE}");
            }


        }

        [StopWatch]
        /*" M-575-000-LER-TFONTE-DB-SELECT-1 */
        public void M_575_000_LER_TFONTE_DB_SELECT_1()
        {
            /*" -1112- EXEC SQL SELECT NOMEFTE INTO :TFONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :MEST-FONTE END-EXEC. */

            var m_575_000_LER_TFONTE_DB_SELECT_1_Query1 = new M_575_000_LER_TFONTE_DB_SELECT_1_Query1()
            {
                MEST_FONTE = MEST_FONTE.ToString(),
            };

            var executed_1 = M_575_000_LER_TFONTE_DB_SELECT_1_Query1.Execute(m_575_000_LER_TFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TFONTE_NOMEFTE, TFONTE_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_575_999_EXIT*/

        [StopWatch]
        /*" M-580-000-LER-TAPOLICE-SECTION */
        private void M_580_000_LER_TAPOLICE_SECTION()
        {
            /*" -1132- MOVE '580-000-LER-TAPOLICE' TO PARAGRAFO. */
            _.Move("580-000-LER-TAPOLICE", W.WABEND.PARAGRAFO);

            /*" -1134- MOVE '580' TO WNR-EXEC-SQL. */
            _.Move("580", W.WABEND.WNR_EXEC_SQL);

            /*" -1136- MOVE SPACES TO APOL-NOME */
            _.Move("", APOL_NOME);

            /*" -1141- PERFORM M_580_000_LER_TAPOLICE_DB_SELECT_1 */

            M_580_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -1144- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1145- DISPLAY 'SI0803B - NAO EXISTE REGISTRO NA TAPOLICE' */
                _.Display($"SI0803B - NAO EXISTE REGISTRO NA TAPOLICE");

                /*" -1145- DISPLAY '          APOLICE  = ' RELSIN-APOLICE. */
                _.Display($"          APOLICE  = {RELSIN_APOLICE}");
            }


        }

        [StopWatch]
        /*" M-580-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_580_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -1141- EXEC SQL SELECT NOME INTO :APOL-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :RELSIN-APOLICE END-EXEC. */

            var m_580_000_LER_TAPOLICE_DB_SELECT_1_Query1 = new M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1()
            {
                RELSIN_APOLICE = RELSIN_APOLICE.ToString(),
            };

            var executed_1 = M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1.Execute(m_580_000_LER_TAPOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_NOME, APOL_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_580_999_EXIT*/

        [StopWatch]
        /*" M-590-000-ATUALIZA-TRELSIN-SECTION */
        private void M_590_000_ATUALIZA_TRELSIN_SECTION()
        {
            /*" -1163- MOVE '590-000-ATUALIZA-TRELSIN' TO PARAGRAFO. */
            _.Move("590-000-ATUALIZA-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -1165- MOVE '590' TO WNR-EXEC-SQL. */
            _.Move("590", W.WABEND.WNR_EXEC_SQL);

            /*" -1171- PERFORM M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1 */

            M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-590-000-ATUALIZA-TRELSIN-DB-DELETE-1 */
        public void M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1()
        {
            /*" -1171- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0803B' AND DATA_SOLICITACAO = :SIST-DTMOVABE END-EXEC. */

            var m_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1 = new M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
            };

            M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1.Execute(m_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_590_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -1189- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -1191- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -1193- CLOSE SI0803M1. */
            SI0803M1.Close();

            /*" -1194- DISPLAY 'SI0803B.................   *** FIM NORMAL ***' . */
            _.Display($"SI0803B.................   *** FIM NORMAL ***");

            /*" -1195- DISPLAY 'DATA PROCESSADA......... ' SIST-DTMOVABE */
            _.Display($"DATA PROCESSADA......... {SIST_DTMOVABE}");

            /*" -1196- DISPLAY 'LIDOS RELATORIOS........ ' AC-LID-TRELSIN */
            _.Display($"LIDOS RELATORIOS........ {W.AC_LID_TRELSIN}");

            /*" -1197- DISPLAY 'LIDOS MESTSINI/HISTSINI. ' AC-LID-MESTHIST */
            _.Display($"LIDOS MESTSINI/HISTSINI. {W.AC_LID_MESTHIST}");

            /*" -1199- DISPLAY 'TOTAL IMPRESSOS EMISSAO. ' AC-IMPRE */
            _.Display($"TOTAL IMPRESSOS EMISSAO. {W.AC_IMPRE}");

            /*" -1199- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1212- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1213- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1214- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1215- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1216- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1218- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1219- CLOSE SI0803M1. */
            SI0803M1.Close();

            /*" -1219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1220- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1222- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1222- GOBACK. */

            throw new GoBack();

        }
    }
}