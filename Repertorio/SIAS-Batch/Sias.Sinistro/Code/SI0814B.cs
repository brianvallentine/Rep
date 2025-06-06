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
using Sias.Sinistro.DB2.SI0814B;

namespace Code
{
    public class SI0814B
    {
        public bool IsCall { get; set; }

        public SI0814B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    SINISTRO                          //      */
        /*"      * PROGRAMA             :    SI0814B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELACAO DE SINISTROS   //      */
        /*"      *                           PAGOS OCORRIDOS NO PERIODO POR    //      */
        /*"      *                           RAMO/MODALIDADE                   //      */
        /*"      * ANALISTA/PROGRAMADOR :    NELSON                            //      */
        /*"      * DATA                 :    SETEMBRO/95                       //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0814M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0814M1
        {
            get
            {
                _.Move(REG_SI0814M1, _SI0814M1); VarBasis.RedefinePassValue(REG_SI0814M1, _SI0814M1, REG_SI0814M1); return _SI0814M1;
            }
        }
        /*"01  REG-SI0814M1.*/
        public SI0814B_REG_SI0814M1 REG_SI0814M1 { get; set; } = new SI0814B_REG_SI0814M1();
        public class SI0814B_REG_SI0814M1 : VarBasis
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
        /*"77           RELSIN-PERI-INICIAL    PIC  X(010).*/
        public StringBasis RELSIN_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-PERI-FINAL      PIC  X(010).*/
        public StringBasis RELSIN_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-RAMO            PIC S9(004)       COMP.*/
        public IntBasis RELSIN_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           W-RELSIN-RAMO-INI      PIC S9(004)       COMP.*/
        public IntBasis W_RELSIN_RAMO_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           W-RELSIN-RAMO-FIM      PIC S9(004)       COMP.*/
        public IntBasis W_RELSIN_RAMO_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-APOLICE           PIC S9(013)       COMP-3.*/
        public IntBasis MEST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-DATORR            PIC  X(010).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-APOL-SINI         PIC S9(013)       COMP-3.*/
        public IntBasis MEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-RAMO              PIC S9(004)       COMP.*/
        public IntBasis MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-CODCAU            PIC S9(004)       COMP.*/
        public IntBasis MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77           HIST-FONPAG           PIC S9(004)       COMP.*/
        public IntBasis HIST_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APOL-NOME             PIC  X(040).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           ENDO-DTINIVIG         PIC  X(010).*/
        public StringBasis ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           CLIE-COD-CLIENTE       PIC S9(009)       COMP.*/
        public IntBasis CLIE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           CLIE-NOME-RAZAO        PIC  X(040).*/
        public StringBasis CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           RAMO-NOMERAMO          PIC  X(040).*/
        public StringBasis RAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           CAUS-NOMECAUSA         PIC  X(020).*/
        public StringBasis CAUS_NOMECAUSA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01              W.*/
        public SI0814B_W W { get; set; } = new SI0814B_W();
        public class SI0814B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0814B_LC01 LC01 { get; set; } = new SI0814B_LC01();
            public class SI0814B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC  X(009) VALUE 'SI0814B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0814B.1");
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
            public SI0814B_LC02 LC02 { get; set; } = new SI0814B_LC02();
            public class SI0814B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(025) VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(029) VALUE               'SINISTROS PAGOS OCORRIDOS DE '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"SINISTROS PAGOS OCORRIDOS DE ");
                /*"    05          LC02-DT-INICIO.*/
                public SI0814B_LC02_DT_INICIO LC02_DT_INICIO { get; set; } = new SI0814B_LC02_DT_INICIO();
                public class SI0814B_LC02_DT_INICIO : VarBasis
                {
                    /*"       10       LC02-DD-INICIO      PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC02_DD_INICIO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"       10       LC02-FILLER         PIC  X(001) VALUE '/'.*/
                    public StringBasis LC02_FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"       10       LC02-MM-INICIO      PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC02_MM_INICIO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"       10       LC02-FILLER         PIC  X(001) VALUE '/'.*/
                    public StringBasis LC02_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"       10       LC02-AA-INICIO      PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC02_AA_INICIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(003) VALUE ' A '.*/
                }
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    05          LC02-DT-TERMINO.*/
                public SI0814B_LC02_DT_TERMINO LC02_DT_TERMINO { get; set; } = new SI0814B_LC02_DT_TERMINO();
                public class SI0814B_LC02_DT_TERMINO : VarBasis
                {
                    /*"       10       LC02-DD-TERMINO     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC02_DD_TERMINO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"       10       LC02-FILLER         PIC  X(001) VALUE '/'.*/
                    public StringBasis LC02_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"       10       LC02-MM-TERMINO     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC02_MM_TERMINO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"       10       LC02-FILLER         PIC  X(001) VALUE '/'.*/
                    public StringBasis LC02_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"       10       LC02-AA-TERMINO     PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC02_AA_TERMINO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(024) VALUE SPACES.*/
                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC02-HORA           PIC  X(008) VALUE SPACES.*/
                public StringBasis LC02_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC03.*/
            }
            public SI0814B_LC03 LC03 { get; set; } = new SI0814B_LC03();
            public class SI0814B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE               'RAMO : '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"RAMO : ");
                /*"    05          LC03-RAMO           PIC  9(003) VALUE ZEROES.*/
                public IntBasis LC03_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC03-NOME-RAMO      PIC  X(040) VALUE SPACES.*/
                public StringBasis LC03_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC04.*/
            }
            public SI0814B_LC04 LC04 { get; set; } = new SI0814B_LC04();
            public class SI0814B_LC04 : VarBasis
            {
                /*"    05          FILLER            PIC  X(013) VALUE                                  '   APOLICE   '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"   APOLICE   ");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(034) VALUE                                  '             SEGURADO'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"             SEGURADO");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(013) VALUE                                  '   SINISTRO  '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"   SINISTRO  ");
                /*"    05          FILLER            PIC  X(005) VALUE 'FONTE'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"    05          FILLER            PIC  X(014) VALUE                                  '    CAUSA     '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    CAUSA     ");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(010) VALUE ' DT.OCORR'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" DT.OCORR");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(010) VALUE ' VIGENCIA'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VIGENCIA");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(010) VALUE ' DT.PAGTO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" DT.PAGTO");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(016) VALUE                                  '     VALOR PAGO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"     VALOR PAGO");
                /*"  03            LD01.*/
            }
            public SI0814B_LD01 LD01 { get; set; } = new SI0814B_LD01();
            public class SI0814B_LD01 : VarBasis
            {
                /*"    05          LD01-APOLICE        PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-SEGURADO       PIC  X(034) VALUE SPACES.*/
                public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-SINISTRO       PIC  9(013) BLANK WHEN ZERO.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-FONTE          PIC  9(003) BLANK WHEN ZERO.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-CAUSA          PIC  X(014) VALUE SPACES.*/
                public StringBasis LD01_CAUSA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-DTOCORR.*/
                public SI0814B_LD01_DTOCORR LD01_DTOCORR { get; set; } = new SI0814B_LD01_DTOCORR();
                public class SI0814B_LD01_DTOCORR : VarBasis
                {
                    /*"      07        LD01-DTOCORR-DD     PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTOCORR_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL1           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTOCORR-MM     PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTOCORR_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL2           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTOCORR-AA     PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTOCORR_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-DTINIVIG.*/
                public SI0814B_LD01_DTINIVIG LD01_DTINIVIG { get; set; } = new SI0814B_LD01_DTINIVIG();
                public class SI0814B_LD01_DTINIVIG : VarBasis
                {
                    /*"      07        LD01-DTINIVIG-DD    PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTINIVIG_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL3           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTINIVIG-MM    PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTINIVIG_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL4           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTINIVIG-AA    PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTINIVIG_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-DTPAGTO.*/
                public SI0814B_LD01_DTPAGTO LD01_DTPAGTO { get; set; } = new SI0814B_LD01_DTPAGTO();
                public class SI0814B_LD01_DTPAGTO : VarBasis
                {
                    /*"      07        LD01-DTPAGTO-DD     PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTPAGTO_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL5           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTPAGTO-MM     PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTPAGTO_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        LD01-FIL6           PIC  X(001) VALUE SPACES.*/
                    public StringBasis LD01_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LD01-DTPAGTO-AA     PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LD01_DTPAGTO_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-VL-PAGO        PIC  ZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03            LT01.*/
            }
            public SI0814B_LT01 LT01 { get; set; } = new SI0814B_LT01();
            public class SI0814B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                    'TOTAL DO RAMO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"TOTAL DO RAMO");
                /*"    05          LT01-RAMO           PIC  9(003) VALUE ZEROS.*/
                public IntBasis LT01_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' -'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" -");
                /*"    05          LT01-NOME-RAMO      PIC  X(040) VALUE SPACES.*/
                public StringBasis LT01_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE '  -'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  -");
                /*"    05          LT01-VALOR-PAGO     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT01_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03            LT02.*/
            }
            public SI0814B_LT02 LT02 { get; set; } = new SI0814B_LT02();
            public class SI0814B_LT02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(042) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"");
                /*"    05          FILLER              PIC  X(021) VALUE                                    'TOTAL GERAL DO RAMO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"TOTAL GERAL DO RAMO");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(040) VALUE ALL '.'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ALL");
                /*"    05          FILLER              PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05          LT02-VALOR-PAGO     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT02_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"  03        WSN-RAMO-ANT           PIC  9(003) VALUE ZEROS.*/
            }
            public IntBasis WSN_RAMO_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        WSN-SINISTRO-ANT       PIC  9(013) VALUE ZEROS.*/
            public IntBasis WSN_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03        WSN-VRPAGAMENTO      PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-RAMO      PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-RAMO-TOT  PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_RAMO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRPAGO-SINISTRO  PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRPAGO_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA-CURR.*/
            public SI0814B_WDATA_CURR WDATA_CURR { get; set; } = new SI0814B_WDATA_CURR();
            public class SI0814B_WDATA_CURR : VarBasis
            {
                /*"    05          WDATA-AA-CURR       PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-CURR.*/
            }
            public SI0814B_WHORA_CURR WHORA_CURR { get; set; } = new SI0814B_WHORA_CURR();
            public class SI0814B_WHORA_CURR : VarBasis
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
            public SI0814B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0814B_WDATA_CABEC();
            public class SI0814B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0814B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0814B_WHORA_CABEC();
            public class SI0814B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA.*/
            }
            public SI0814B_WDATA WDATA { get; set; } = new SI0814B_WDATA();
            public class SI0814B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"  03            WDATA1-R.*/
            public SI0814B_WDATA1_R WDATA1_R { get; set; } = new SI0814B_WDATA1_R();
            public class SI0814B_WDATA1_R : VarBasis
            {
                /*"    05          WDATA1-AA           PIC  9(004).*/
                public IntBasis WDATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA1-MM           PIC  9(002).*/
                public IntBasis WDATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA1-DD           PIC  9(002).*/
                public IntBasis WDATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA1              REDEFINES WDATA1-R                                    PIC  X(010).*/
            }
            private _REDEF_StringBasis _wdata1 { get; set; }
            public _REDEF_StringBasis WDATA1
            {
                get { _wdata1 = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATA1_R, _wdata1); VarBasis.RedefinePassValue(WDATA1_R, _wdata1, WDATA1_R); _wdata1.ValueChanged += () => { _.Move(_wdata1, WDATA1_R); }; return _wdata1; }
                set { VarBasis.RedefinePassValue(value, _wdata1, WDATA1_R); }
            }  //Redefines
            /*"  03            WFIM-TRELSIN        PIC  X(001) VALUE 'N'.*/
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
            /*"  03        WABEND.*/
            public SI0814B_WABEND WABEND { get; set; } = new SI0814B_WABEND();
            public class SI0814B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0814B'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0814B");
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
                /*"01          LK-LINK.*/
            }
        }
        public SI0814B_LK_LINK LK_LINK { get; set; } = new SI0814B_LK_LINK();
        public class SI0814B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0814B_V1RELATSINI V1RELATSINI { get; set; } = new SI0814B_V1RELATSINI();
        public SI0814B_MESTSINI MESTSINI { get; set; } = new SI0814B_MESTSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0814M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0814M1.SetFile(SI0814M1_FILE_NAME_P);

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
            /*" -360- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -363- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -364- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -366- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -368- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -373- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -374- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -375- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -376- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -378- MOVE WHORA-CABEC TO LC02-HORA */
            _.Move(W.WHORA_CABEC, W.LC02.LC02_HORA);

            /*" -380- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -382- PERFORM 520-000-LER-TSISTEMA. */

            M_520_000_LER_TSISTEMA_SECTION();

            /*" -383- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, W.WDATA_CURR);

            /*" -384- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.WDATA_CURR.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -385- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.WDATA_CURR.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -386- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.WDATA_CURR.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -388- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -390- PERFORM 530-000-CURSOR-TRELSIN. */

            M_530_000_CURSOR_TRELSIN_SECTION();

            /*" -392- PERFORM 540-000-LER-TRELSIN. */

            M_540_000_LER_TRELSIN_SECTION();

            /*" -393- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -394- DISPLAY 'SI0814B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0814B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -396- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -399- PERFORM 110-000-PROCESSA-EMISSAO UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_110_000_PROCESSA_EMISSAO_SECTION();
            }

            /*" -401- PERFORM 800-000-IMPRIME-TOTAL-GERAL. */

            M_800_000_IMPRIME_TOTAL_GERAL_SECTION();

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

            /*" -422- OPEN OUTPUT SI0814M1. */
            SI0814M1.Open(REG_SI0814M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-110-000-PROCESSA-EMISSAO-SECTION */
        private void M_110_000_PROCESSA_EMISSAO_SECTION()
        {
            /*" -436- MOVE '110-000-PROCESSA-EMISSAO' TO PARAGRAFO. */
            _.Move("110-000-PROCESSA-EMISSAO", W.WABEND.PARAGRAFO);

            /*" -437- MOVE RELSIN-PERI-INICIAL TO WDATA1. */
            _.Move(RELSIN_PERI_INICIAL, W.WDATA1);

            /*" -438- MOVE WDATA1-AA TO LC02-AA-INICIO. */
            _.Move(W.WDATA1_R.WDATA1_AA, W.LC02.LC02_DT_INICIO.LC02_AA_INICIO);

            /*" -439- MOVE WDATA1-MM TO LC02-MM-INICIO. */
            _.Move(W.WDATA1_R.WDATA1_MM, W.LC02.LC02_DT_INICIO.LC02_MM_INICIO);

            /*" -441- MOVE WDATA1-DD TO LC02-DD-INICIO. */
            _.Move(W.WDATA1_R.WDATA1_DD, W.LC02.LC02_DT_INICIO.LC02_DD_INICIO);

            /*" -442- MOVE RELSIN-PERI-FINAL TO WDATA1. */
            _.Move(RELSIN_PERI_FINAL, W.WDATA1);

            /*" -443- MOVE WDATA1-AA TO LC02-AA-TERMINO. */
            _.Move(W.WDATA1_R.WDATA1_AA, W.LC02.LC02_DT_TERMINO.LC02_AA_TERMINO);

            /*" -444- MOVE WDATA1-MM TO LC02-MM-TERMINO. */
            _.Move(W.WDATA1_R.WDATA1_MM, W.LC02.LC02_DT_TERMINO.LC02_MM_TERMINO);

            /*" -446- MOVE WDATA1-DD TO LC02-DD-TERMINO. */
            _.Move(W.WDATA1_R.WDATA1_DD, W.LC02.LC02_DT_TERMINO.LC02_DD_TERMINO);

            /*" -447- IF RELSIN-RAMO EQUAL ZERO */

            if (RELSIN_RAMO == 00)
            {

                /*" -448- MOVE ZERO TO W-RELSIN-RAMO-INI */
                _.Move(0, W_RELSIN_RAMO_INI);

                /*" -449- MOVE 99 TO W-RELSIN-RAMO-FIM */
                _.Move(99, W_RELSIN_RAMO_FIM);

                /*" -450- ELSE */
            }
            else
            {


                /*" -453- MOVE RELSIN-RAMO TO W-RELSIN-RAMO-INI W-RELSIN-RAMO-FIM. */
                _.Move(RELSIN_RAMO, W_RELSIN_RAMO_INI, W_RELSIN_RAMO_FIM);
            }


            /*" -455- MOVE 'N' TO WFIM-TMESTSIN */
            _.Move("N", W.WFIM_TMESTSIN);

            /*" -457- PERFORM 550-000-CURSOR-TMESTSIN. */

            M_550_000_CURSOR_TMESTSIN_SECTION();

            /*" -459- PERFORM 560-000-LER-TMESTSIN. */

            M_560_000_LER_TMESTSIN_SECTION();

            /*" -463- PERFORM 150-000-PROCESSA-TMESTSIN UNTIL WFIM-TMESTSIN EQUAL 'S' . */

            while (!(W.WFIM_TMESTSIN == "S"))
            {

                M_150_000_PROCESSA_TMESTSIN_SECTION();
            }

            /*" -463- PERFORM 540-000-LER-TRELSIN. */

            M_540_000_LER_TRELSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_999_EXIT*/

        [StopWatch]
        /*" M-150-000-PROCESSA-TMESTSIN-SECTION */
        private void M_150_000_PROCESSA_TMESTSIN_SECTION()
        {
            /*" -478- MOVE '150-000-PROCESSA-TMESTSIN' TO PARAGRAFO */
            _.Move("150-000-PROCESSA-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -480- PERFORM 260-000-PROCESSA-MOVTO. */

            M_260_000_PROCESSA_MOVTO_SECTION();

            /*" -480- PERFORM 560-000-LER-TMESTSIN. */

            M_560_000_LER_TMESTSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-260-000-PROCESSA-MOVTO-SECTION */
        private void M_260_000_PROCESSA_MOVTO_SECTION()
        {
            /*" -494- MOVE '260-000-PROCESSA-MOVTO' TO PARAGRAFO. */
            _.Move("260-000-PROCESSA-MOVTO", W.WABEND.PARAGRAFO);

            /*" -496- IF MEST-APOL-SINI NOT EQUAL WSN-SINISTRO-ANT AND WSN-SINISTRO-ANT NOT EQUAL ZEROS */

            if (MEST_APOL_SINI != W.WSN_SINISTRO_ANT && W.WSN_SINISTRO_ANT != 00)
            {

                /*" -498- PERFORM 350-000-IMPRIME-PAGAMENTO. */

                M_350_000_IMPRIME_PAGAMENTO_SECTION();
            }


            /*" -500- IF MEST-RAMO NOT EQUAL WSN-RAMO-ANT AND WSN-RAMO-ANT NOT EQUAL ZEROS */

            if (MEST_RAMO != W.WSN_RAMO_ANT && W.WSN_RAMO_ANT != 00)
            {

                /*" -502- PERFORM 380-000-IMPRIME-TOTAL-RAMO. */

                M_380_000_IMPRIME_TOTAL_RAMO_SECTION();
            }


            /*" -503- IF MEST-APOL-SINI NOT EQUAL WSN-SINISTRO-ANT */

            if (MEST_APOL_SINI != W.WSN_SINISTRO_ANT)
            {

                /*" -504- PERFORM 575-000-LER-TRAMO */

                M_575_000_LER_TRAMO_SECTION();

                /*" -505- PERFORM 580-000-LER-TAPOLICE */

                M_580_000_LER_TAPOLICE_SECTION();

                /*" -506- PERFORM 600-000-LER-TCAUSA */

                M_600_000_LER_TCAUSA_SECTION();

                /*" -507- PERFORM 610-000-LER-TENDOSSO */

                M_610_000_LER_TENDOSSO_SECTION();

                /*" -508- MOVE MEST-APOLICE TO LD01-APOLICE */
                _.Move(MEST_APOLICE, W.LD01.LD01_APOLICE);

                /*" -509- MOVE APOL-NOME TO LD01-SEGURADO */
                _.Move(APOL_NOME, W.LD01.LD01_SEGURADO);

                /*" -510- ELSE */
            }
            else
            {


                /*" -511- MOVE SPACES TO LD01-APOLICE */
                _.Move("", W.LD01.LD01_APOLICE);

                /*" -513- MOVE SPACES TO LD01-SEGURADO. */
                _.Move("", W.LD01.LD01_SEGURADO);
            }


            /*" -514- MOVE MEST-APOL-SINI TO WSN-SINISTRO-ANT. */
            _.Move(MEST_APOL_SINI, W.WSN_SINISTRO_ANT);

            /*" -515- MOVE MEST-RAMO TO WSN-RAMO-ANT. */
            _.Move(MEST_RAMO, W.WSN_RAMO_ANT);

            /*" -516- MOVE MEST-RAMO TO LC03-RAMO. */
            _.Move(MEST_RAMO, W.LC03.LC03_RAMO);

            /*" -517- MOVE MEST-RAMO TO LT01-RAMO. */
            _.Move(MEST_RAMO, W.LT01.LT01_RAMO);

            /*" -518- MOVE RAMO-NOMERAMO TO LC03-NOME-RAMO. */
            _.Move(RAMO_NOMERAMO, W.LC03.LC03_NOME_RAMO);

            /*" -519- MOVE RAMO-NOMERAMO TO LT01-NOME-RAMO. */
            _.Move(RAMO_NOMERAMO, W.LT01.LT01_NOME_RAMO);

            /*" -520- MOVE MEST-APOL-SINI TO LD01-SINISTRO. */
            _.Move(MEST_APOL_SINI, W.LD01.LD01_SINISTRO);

            /*" -521- MOVE HIST-FONPAG TO LD01-FONTE. */
            _.Move(HIST_FONPAG, W.LD01.LD01_FONTE);

            /*" -522- MOVE CAUS-NOMECAUSA TO LD01-CAUSA. */
            _.Move(CAUS_NOMECAUSA, W.LD01.LD01_CAUSA);

            /*" -523- MOVE MEST-DATORR TO WDATA-R. */
            _.Move(MEST_DATORR, W.WDATA_R);

            /*" -524- MOVE WDATA-DD TO LD01-DTOCORR-DD. */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTOCORR.LD01_DTOCORR_DD);

            /*" -525- MOVE WDATA-MM TO LD01-DTOCORR-MM. */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTOCORR.LD01_DTOCORR_MM);

            /*" -526- MOVE WDATA-AA TO LD01-DTOCORR-AA. */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTOCORR.LD01_DTOCORR_AA);

            /*" -527- MOVE ENDO-DTINIVIG TO WDATA-R. */
            _.Move(ENDO_DTINIVIG, W.WDATA_R);

            /*" -528- MOVE WDATA-DD TO LD01-DTINIVIG-DD. */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTINIVIG.LD01_DTINIVIG_DD);

            /*" -529- MOVE WDATA-MM TO LD01-DTINIVIG-MM. */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTINIVIG.LD01_DTINIVIG_MM);

            /*" -530- MOVE WDATA-AA TO LD01-DTINIVIG-AA. */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTINIVIG.LD01_DTINIVIG_AA);

            /*" -531- MOVE HIST-DTMOVTO TO WDATA-R. */
            _.Move(HIST_DTMOVTO, W.WDATA_R);

            /*" -532- MOVE WDATA-DD TO LD01-DTPAGTO-DD. */
            _.Move(W.WDATA.WDATA_DD, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_DD);

            /*" -533- MOVE WDATA-MM TO LD01-DTPAGTO-MM. */
            _.Move(W.WDATA.WDATA_MM, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_MM);

            /*" -534- MOVE WDATA-AA TO LD01-DTPAGTO-AA. */
            _.Move(W.WDATA.WDATA_AA, W.LD01.LD01_DTPAGTO.LD01_DTPAGTO_AA);

            /*" -535- MOVE '/' TO LD01-FIL3. */
            _.Move("/", W.LD01.LD01_DTINIVIG.LD01_FIL3);

            /*" -536- MOVE '/' TO LD01-FIL4. */
            _.Move("/", W.LD01.LD01_DTINIVIG.LD01_FIL4);

            /*" -536- ADD HIST-VALPRI TO WSN-VRPAGAMENTO. */
            W.WSN_VRPAGAMENTO.Value = W.WSN_VRPAGAMENTO + HIST_VALPRI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_260_999_EXIT*/

        [StopWatch]
        /*" M-350-000-IMPRIME-PAGAMENTO-SECTION */
        private void M_350_000_IMPRIME_PAGAMENTO_SECTION()
        {
            /*" -550- MOVE '350-000-IMPRIME-PAGAMENTO' TO PARAGRAFO. */
            _.Move("350-000-IMPRIME-PAGAMENTO", W.WABEND.PARAGRAFO);

            /*" -552- MOVE WSN-VRPAGAMENTO TO LD01-VL-PAGO. */
            _.Move(W.WSN_VRPAGAMENTO, W.LD01.LD01_VL_PAGO);

            /*" -553- IF W-CONT-LIN GREATER 60 */

            if (W.W_CONT_LIN > 60)
            {

                /*" -555- PERFORM 390-000-CABEC. */

                M_390_000_CABEC_SECTION();
            }


            /*" -558- WRITE REG-SI0814M1 FROM LD01 AFTER 1. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

            /*" -559- ADD 1 TO AC-IMPRE. */
            W.AC_IMPRE.Value = W.AC_IMPRE + 1;

            /*" -560- ADD 1 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 1;

            /*" -562- MOVE SPACES TO LD01. */
            _.Move("", W.LD01);

            /*" -564- ADD WSN-VRPAGAMENTO TO WSN-VRPAGO-RAMO WSN-VRPAGO-RAMO-TOT. */
            W.WSN_VRPAGO_RAMO.Value = W.WSN_VRPAGO_RAMO + W.WSN_VRPAGAMENTO;
            W.WSN_VRPAGO_RAMO_TOT.Value = W.WSN_VRPAGO_RAMO_TOT + W.WSN_VRPAGAMENTO;

            /*" -564- MOVE ZEROS TO WSN-VRPAGAMENTO. */
            _.Move(0, W.WSN_VRPAGAMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/

        [StopWatch]
        /*" M-380-000-IMPRIME-TOTAL-RAMO-SECTION */
        private void M_380_000_IMPRIME_TOTAL_RAMO_SECTION()
        {
            /*" -578- MOVE '380-000-IMPRIME-TOTAL-RAMO' TO PARAGRAFO. */
            _.Move("380-000-IMPRIME-TOTAL-RAMO", W.WABEND.PARAGRAFO);

            /*" -579- IF W-CONT-LIN GREATER 50 */

            if (W.W_CONT_LIN > 50)
            {

                /*" -580- ADD 1 TO W-CONT-PAG */
                W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

                /*" -581- MOVE W-CONT-PAG TO LC01-PAG */
                _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

                /*" -583- WRITE REG-SI0814M1 FROM LC01 AFTER NEW-PAGE */
                _.Move(W.LC01.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -585- WRITE REG-SI0814M1 FROM LC02 AFTER 1 */
                _.Move(W.LC02.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -587- WRITE REG-SI0814M1 FROM LC03 AFTER 2 */
                _.Move(W.LC03.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -589- WRITE REG-SI0814M1 FROM LC04 AFTER 2 */
                _.Move(W.LC04.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -591- MOVE 5 TO W-CONT-LIN. */
                _.Move(5, W.W_CONT_LIN);
            }


            /*" -593- MOVE WSN-VRPAGO-RAMO TO LT01-VALOR-PAGO. */
            _.Move(W.WSN_VRPAGO_RAMO, W.LT01.LT01_VALOR_PAGO);

            /*" -596- WRITE REG-SI0814M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

            /*" -598- MOVE +0 TO WSN-VRPAGO-RAMO WSN-VRPAGO-SINISTRO. */
            _.Move(+0, W.WSN_VRPAGO_RAMO, W.WSN_VRPAGO_SINISTRO);

            /*" -599- MOVE +0 TO WSN-SINISTRO-ANT. */
            _.Move(+0, W.WSN_SINISTRO_ANT);

            /*" -600- MOVE +0 TO WSN-RAMO-ANT. */
            _.Move(+0, W.WSN_RAMO_ANT);

            /*" -601- MOVE +99 TO W-CONT-LIN. */
            _.Move(+99, W.W_CONT_LIN);

            /*" -601- MOVE +0 TO W-CONT-PAG. */
            _.Move(+0, W.W_CONT_PAG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_380_999_EXIT*/

        [StopWatch]
        /*" M-390-000-CABEC-SECTION */
        private void M_390_000_CABEC_SECTION()
        {
            /*" -614- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -615- IF W-CONT-LIN GREATER 90 */

            if (W.W_CONT_LIN > 90)
            {

                /*" -617- PERFORM 400-000-CARGA-CABEC. */

                M_400_000_CARGA_CABEC_SECTION();
            }


            /*" -618- ADD 1 TO W-CONT-PAG. */
            W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

            /*" -621- MOVE W-CONT-PAG TO LC01-PAG. */
            _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

            /*" -624- WRITE REG-SI0814M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

            /*" -627- WRITE REG-SI0814M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

            /*" -630- WRITE REG-SI0814M1 FROM LC03 AFTER 2. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

            /*" -633- WRITE REG-SI0814M1 FROM LC04 AFTER 2. */
            _.Move(W.LC04.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

            /*" -633- MOVE 5 TO W-CONT-LIN. */
            _.Move(5, W.W_CONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-400-000-CARGA-CABEC-SECTION */
        private void M_400_000_CARGA_CABEC_SECTION()
        {
            /*" -647- PERFORM 510-000-LER-TEMPRESA. */

            M_510_000_LER_TEMPRESA_SECTION();

            /*" -648- MOVE TEMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(TEMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -650- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -651- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -652- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -653- ELSE */
            }
            else
            {


                /*" -654- DISPLAY 'SI0814B - PROBLEMA CALL PROALN01 ' */
                _.Display($"SI0814B - PROBLEMA CALL PROALN01 ");

                /*" -655- DISPLAY '          EMPRESA: ' TEMPRESA-NOM-EMP */
                _.Display($"          EMPRESA: {TEMPRESA_NOM_EMP}");

                /*" -656- CLOSE SI0814M1 */
                SI0814M1.Close();

                /*" -656- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-510-000-LER-TEMPRESA-SECTION */
        private void M_510_000_LER_TEMPRESA_SECTION()
        {
            /*" -671- MOVE '510-000-LER-TEMPRESA' TO PARAGRAFO. */
            _.Move("510-000-LER-TEMPRESA", W.WABEND.PARAGRAFO);

            /*" -673- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", W.WABEND.WNR_EXEC_SQL);

            /*" -678- PERFORM M_510_000_LER_TEMPRESA_DB_SELECT_1 */

            M_510_000_LER_TEMPRESA_DB_SELECT_1();

            /*" -681- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -682- DISPLAY 'SI0814B - NAO CONSTA REGISTRO NA TEMPRESA' */
                _.Display($"SI0814B - NAO CONSTA REGISTRO NA TEMPRESA");

                /*" -682- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-510-000-LER-TEMPRESA-DB-SELECT-1 */
        public void M_510_000_LER_TEMPRESA_DB_SELECT_1()
        {
            /*" -678- EXEC SQL SELECT NOME_EMPRESA INTO :TEMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -697- MOVE '520-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("520-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -699- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", W.WABEND.WNR_EXEC_SQL);

            /*" -704- PERFORM M_520_000_LER_TSISTEMA_DB_SELECT_1 */

            M_520_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -707- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -708- DISPLAY 'SI0814B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0814B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -708- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-520-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_520_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -704- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -725- MOVE '530-000-CURSOR-TRELSIN' TO PARAGRAFO */
            _.Move("530-000-CURSOR-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -727- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", W.WABEND.WNR_EXEC_SQL);

            /*" -737- PERFORM M_530_000_CURSOR_TRELSIN_DB_DECLARE_1 */

            M_530_000_CURSOR_TRELSIN_DB_DECLARE_1();

            /*" -739- PERFORM M_530_000_CURSOR_TRELSIN_DB_OPEN_1 */

            M_530_000_CURSOR_TRELSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-530-000-CURSOR-TRELSIN-DB-DECLARE-1 */
        public void M_530_000_CURSOR_TRELSIN_DB_DECLARE_1()
        {
            /*" -737- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, RAMO FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0814B' AND DATA_SOLICITACAO = :SIST-DTMOVABE AND SITUACAO = '0' ORDER BY PERI_INICIAL END-EXEC. */
            V1RELATSINI = new SI0814B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							RAMO 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0814B' 
							AND DATA_SOLICITACAO = '{SIST_DTMOVABE}' 
							AND SITUACAO = '0' 
							ORDER BY PERI_INICIAL";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-530-000-CURSOR-TRELSIN-DB-OPEN-1 */
        public void M_530_000_CURSOR_TRELSIN_DB_OPEN_1()
        {
            /*" -739- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-DB-DECLARE-1 */
        public void M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1()
        {
            /*" -818- EXEC SQL DECLARE MESTSINI CURSOR FOR SELECT M.RAMO, M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.DATORR, M.CODCAU, H.DTMOVTO, H.FONPAG, H.OPERACAO, H.VAL_OPERACAO FROM SEGUROS.V0MESTSINI M, SEGUROS.V0HISTSINI H WHERE M.SDOPAGBT = 0 AND M.SITUACAO �= '2' AND M.DATORR >= :RELSIN-PERI-INICIAL AND M.DATORR <= :RELSIN-PERI-FINAL AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.OPERACAO IN (1001, 1002, 1003, 1004, 1009, 9001) AND H.SITUACAO IN ( '0' , '1' ) AND M.RAMO BETWEEN :W-RELSIN-RAMO-INI AND :W-RELSIN-RAMO-FIM ORDER BY M.RAMO, M.NUM_APOL_SINISTRO, H.DTMOVTO, H.OPERACAO END-EXEC. */
            MESTSINI = new SI0814B_MESTSINI(true);
            string GetQuery_MESTSINI()
            {
                var query = @$"SELECT M.RAMO
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.DATORR
							, 
							M.CODCAU
							, 
							H.DTMOVTO
							, 
							H.FONPAG
							, 
							H.OPERACAO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0HISTSINI H 
							WHERE 
							M.SDOPAGBT = 0 
							AND M.SITUACAO �= '2' 
							AND M.DATORR >= '{RELSIN_PERI_INICIAL}' 
							AND M.DATORR <= '{RELSIN_PERI_FINAL}' 
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
							AND H.SITUACAO IN ( '0'
							, '1' ) 
							AND M.RAMO BETWEEN '{W_RELSIN_RAMO_INI}' 
							AND '{W_RELSIN_RAMO_FIM}' 
							ORDER BY M.RAMO
							, 
							M.NUM_APOL_SINISTRO
							, 
							H.DTMOVTO
							, 
							H.OPERACAO";

                return query;
            }
            MESTSINI.GetQueryEvent += GetQuery_MESTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_999_EXIT*/

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-SECTION */
        private void M_540_000_LER_TRELSIN_SECTION()
        {
            /*" -755- MOVE '540-000-LER-TRELSIN' TO PARAGRAFO. */
            _.Move("540-000-LER-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -757- MOVE '540' TO WNR-EXEC-SQL. */
            _.Move("540", W.WABEND.WNR_EXEC_SQL);

            /*" -761- PERFORM M_540_000_LER_TRELSIN_DB_FETCH_1 */

            M_540_000_LER_TRELSIN_DB_FETCH_1();

            /*" -764- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -764- PERFORM M_540_000_LER_TRELSIN_DB_CLOSE_1 */

                M_540_000_LER_TRELSIN_DB_CLOSE_1();

                /*" -766- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -767- ELSE */
            }
            else
            {


                /*" -767- ADD 1 TO AC-LID-TRELSIN. */
                W.AC_LID_TRELSIN.Value = W.AC_LID_TRELSIN + 1;
            }


        }

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-DB-FETCH-1 */
        public void M_540_000_LER_TRELSIN_DB_FETCH_1()
        {
            /*" -761- EXEC SQL FETCH V1RELATSINI INTO :RELSIN-PERI-INICIAL, :RELSIN-PERI-FINAL, :RELSIN-RAMO END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELSIN_PERI_INICIAL, RELSIN_PERI_INICIAL);
                _.Move(V1RELATSINI.RELSIN_PERI_FINAL, RELSIN_PERI_FINAL);
                _.Move(V1RELATSINI.RELSIN_RAMO, RELSIN_RAMO);
            }

        }

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-DB-CLOSE-1 */
        public void M_540_000_LER_TRELSIN_DB_CLOSE_1()
        {
            /*" -764- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_540_999_EXIT*/

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-SECTION */
        private void M_550_000_CURSOR_TMESTSIN_SECTION()
        {
            /*" -785- MOVE '550-000-CURSOR-TMESTSIN' TO PARAGRAFO. */
            _.Move("550-000-CURSOR-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -787- MOVE '550' TO WNR-EXEC-SQL. */
            _.Move("550", W.WABEND.WNR_EXEC_SQL);

            /*" -818- PERFORM M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1 */

            M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1();

            /*" -819- PERFORM M_550_000_CURSOR_TMESTSIN_DB_OPEN_1 */

            M_550_000_CURSOR_TMESTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-DB-OPEN-1 */
        public void M_550_000_CURSOR_TMESTSIN_DB_OPEN_1()
        {
            /*" -819- EXEC SQL OPEN MESTSINI END-EXEC. */

            MESTSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_999_EXIT*/

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-SECTION */
        private void M_560_000_LER_TMESTSIN_SECTION()
        {
            /*" -835- MOVE '560-000-LER-TMESTSIN' TO PARAGRAFO. */
            _.Move("560-000-LER-TMESTSIN", W.WABEND.PARAGRAFO);

            /*" -837- MOVE '560' TO WNR-EXEC-SQL. */
            _.Move("560", W.WABEND.WNR_EXEC_SQL);

            /*" -847- PERFORM M_560_000_LER_TMESTSIN_DB_FETCH_1 */

            M_560_000_LER_TMESTSIN_DB_FETCH_1();

            /*" -850- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -850- PERFORM M_560_000_LER_TMESTSIN_DB_CLOSE_1 */

                M_560_000_LER_TMESTSIN_DB_CLOSE_1();

                /*" -852- MOVE 'S' TO WFIM-TMESTSIN */
                _.Move("S", W.WFIM_TMESTSIN);

                /*" -853- ELSE */
            }
            else
            {


                /*" -853- ADD 1 TO AC-LID-MESTHIST. */
                W.AC_LID_MESTHIST.Value = W.AC_LID_MESTHIST + 1;
            }


        }

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-DB-FETCH-1 */
        public void M_560_000_LER_TMESTSIN_DB_FETCH_1()
        {
            /*" -847- EXEC SQL FETCH MESTSINI INTO :MEST-RAMO, :MEST-APOLICE, :MEST-APOL-SINI, :MEST-DATORR, :MEST-CODCAU, :HIST-DTMOVTO, :HIST-FONPAG, :HIST-OPERACAO, :HIST-VALPRI END-EXEC. */

            if (MESTSINI.Fetch())
            {
                _.Move(MESTSINI.MEST_RAMO, MEST_RAMO);
                _.Move(MESTSINI.MEST_APOLICE, MEST_APOLICE);
                _.Move(MESTSINI.MEST_APOL_SINI, MEST_APOL_SINI);
                _.Move(MESTSINI.MEST_DATORR, MEST_DATORR);
                _.Move(MESTSINI.MEST_CODCAU, MEST_CODCAU);
                _.Move(MESTSINI.HIST_DTMOVTO, HIST_DTMOVTO);
                _.Move(MESTSINI.HIST_FONPAG, HIST_FONPAG);
                _.Move(MESTSINI.HIST_OPERACAO, HIST_OPERACAO);
                _.Move(MESTSINI.HIST_VALPRI, HIST_VALPRI);
            }

        }

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-DB-CLOSE-1 */
        public void M_560_000_LER_TMESTSIN_DB_CLOSE_1()
        {
            /*" -850- EXEC SQL CLOSE MESTSINI END-EXEC */

            MESTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_560_999_EXIT*/

        [StopWatch]
        /*" M-575-000-LER-TRAMO-SECTION */
        private void M_575_000_LER_TRAMO_SECTION()
        {
            /*" -868- MOVE '575-000-LER-TRAMO' TO PARAGRAFO. */
            _.Move("575-000-LER-TRAMO", W.WABEND.PARAGRAFO);

            /*" -870- MOVE '575' TO WNR-EXEC-SQL. */
            _.Move("575", W.WABEND.WNR_EXEC_SQL);

            /*" -872- MOVE SPACES TO RAMO-NOMERAMO. */
            _.Move("", RAMO_NOMERAMO);

            /*" -878- PERFORM M_575_000_LER_TRAMO_DB_SELECT_1 */

            M_575_000_LER_TRAMO_DB_SELECT_1();

            /*" -881- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -882- DISPLAY 'SI0814B - NAO EXISTE REGISTRO NA TRAMO' */
                _.Display($"SI0814B - NAO EXISTE REGISTRO NA TRAMO");

                /*" -883- DISPLAY '          RAMO  = ' MEST-RAMO */
                _.Display($"          RAMO  = {MEST_RAMO}");

                /*" -883- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-575-000-LER-TRAMO-DB-SELECT-1 */
        public void M_575_000_LER_TRAMO_DB_SELECT_1()
        {
            /*" -878- EXEC SQL SELECT NOMERAMO INTO :RAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :MEST-RAMO AND MODALIDA = 0 END-EXEC. */

            var m_575_000_LER_TRAMO_DB_SELECT_1_Query1 = new M_575_000_LER_TRAMO_DB_SELECT_1_Query1()
            {
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_575_000_LER_TRAMO_DB_SELECT_1_Query1.Execute(m_575_000_LER_TRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMO_NOMERAMO, RAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_575_999_EXIT*/

        [StopWatch]
        /*" M-580-000-LER-TAPOLICE-SECTION */
        private void M_580_000_LER_TAPOLICE_SECTION()
        {
            /*" -899- MOVE '580-000-LER-TAPOLICE' TO PARAGRAFO. */
            _.Move("580-000-LER-TAPOLICE", W.WABEND.PARAGRAFO);

            /*" -901- MOVE '580' TO WNR-EXEC-SQL. */
            _.Move("580", W.WABEND.WNR_EXEC_SQL);

            /*" -903- MOVE SPACES TO APOL-NOME */
            _.Move("", APOL_NOME);

            /*" -908- PERFORM M_580_000_LER_TAPOLICE_DB_SELECT_1 */

            M_580_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -911- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -912- DISPLAY 'SI0814B - NAO EXISTE REGISTRO NA TAPOLICE' */
                _.Display($"SI0814B - NAO EXISTE REGISTRO NA TAPOLICE");

                /*" -913- DISPLAY '          APOLICE  = ' MEST-APOLICE */
                _.Display($"          APOLICE  = {MEST_APOLICE}");

                /*" -913- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-580-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_580_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -908- EXEC SQL SELECT NOME INTO :APOL-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :MEST-APOLICE END-EXEC. */

            var m_580_000_LER_TAPOLICE_DB_SELECT_1_Query1 = new M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1()
            {
                MEST_APOLICE = MEST_APOLICE.ToString(),
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
            /*" -931- MOVE '590-000-ATUALIZA-TRELSIN' TO PARAGRAFO. */
            _.Move("590-000-ATUALIZA-TRELSIN", W.WABEND.PARAGRAFO);

            /*" -933- MOVE '590' TO WNR-EXEC-SQL. */
            _.Move("590", W.WABEND.WNR_EXEC_SQL);

            /*" -939- PERFORM M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1 */

            M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-590-000-ATUALIZA-TRELSIN-DB-DELETE-1 */
        public void M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1()
        {
            /*" -939- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0814B' AND DATA_SOLICITACAO = :SIST-DTMOVABE END-EXEC. */

            var m_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1 = new M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
            };

            M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1.Execute(m_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_590_999_EXIT*/

        [StopWatch]
        /*" M-600-000-LER-TCAUSA-SECTION */
        private void M_600_000_LER_TCAUSA_SECTION()
        {
            /*" -955- MOVE '600-000-LER-TCAUSA' TO PARAGRAFO. */
            _.Move("600-000-LER-TCAUSA", W.WABEND.PARAGRAFO);

            /*" -957- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", W.WABEND.WNR_EXEC_SQL);

            /*" -959- MOVE SPACES TO CAUS-NOMECAUSA. */
            _.Move("", CAUS_NOMECAUSA);

            /*" -965- PERFORM M_600_000_LER_TCAUSA_DB_SELECT_1 */

            M_600_000_LER_TCAUSA_DB_SELECT_1();

            /*" -968- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -969- DISPLAY 'SI0814B - NAO EXISTE REGISTRO NA TCAUSA' */
                _.Display($"SI0814B - NAO EXISTE REGISTRO NA TCAUSA");

                /*" -970- DISPLAY '          RAMO  = ' MEST-RAMO */
                _.Display($"          RAMO  = {MEST_RAMO}");

                /*" -971- DISPLAY '          CAUSA = ' MEST-CODCAU */
                _.Display($"          CAUSA = {MEST_CODCAU}");

                /*" -971- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-600-000-LER-TCAUSA-DB-SELECT-1 */
        public void M_600_000_LER_TCAUSA_DB_SELECT_1()
        {
            /*" -965- EXEC SQL SELECT DESCAU INTO :CAUS-NOMECAUSA FROM SEGUROS.V1SINICAUSA WHERE RAMO = :MEST-RAMO AND CODCAU = :MEST-CODCAU END-EXEC. */

            var m_600_000_LER_TCAUSA_DB_SELECT_1_Query1 = new M_600_000_LER_TCAUSA_DB_SELECT_1_Query1()
            {
                MEST_CODCAU = MEST_CODCAU.ToString(),
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_600_000_LER_TCAUSA_DB_SELECT_1_Query1.Execute(m_600_000_LER_TCAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAUS_NOMECAUSA, CAUS_NOMECAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TENDOSSO-SECTION */
        private void M_610_000_LER_TENDOSSO_SECTION()
        {
            /*" -987- MOVE '610-000-LER-TENDOSSO' TO PARAGRAFO. */
            _.Move("610-000-LER-TENDOSSO", W.WABEND.PARAGRAFO);

            /*" -989- MOVE '610' TO WNR-EXEC-SQL. */
            _.Move("610", W.WABEND.WNR_EXEC_SQL);

            /*" -991- MOVE SPACES TO ENDO-DTINIVIG. */
            _.Move("", ENDO_DTINIVIG);

            /*" -997- PERFORM M_610_000_LER_TENDOSSO_DB_SELECT_1 */

            M_610_000_LER_TENDOSSO_DB_SELECT_1();

            /*" -1000- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1001- DISPLAY 'SI0814B - NAO EXISTE REGISTRO NA TENDOSSO' */
                _.Display($"SI0814B - NAO EXISTE REGISTRO NA TENDOSSO");

                /*" -1002- DISPLAY '       APOLICE  = ' MEST-APOLICE */
                _.Display($"       APOLICE  = {MEST_APOLICE}");

                /*" -1002- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-610-000-LER-TENDOSSO-DB-SELECT-1 */
        public void M_610_000_LER_TENDOSSO_DB_SELECT_1()
        {
            /*" -997- EXEC SQL SELECT DTINIVIG INTO :ENDO-DTINIVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :MEST-APOLICE AND NRENDOS = 0 END-EXEC. */

            var m_610_000_LER_TENDOSSO_DB_SELECT_1_Query1 = new M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1()
            {
                MEST_APOLICE = MEST_APOLICE.ToString(),
            };

            var executed_1 = M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1.Execute(m_610_000_LER_TENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDO_DTINIVIG, ENDO_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-800-000-IMPRIME-TOTAL-GERAL-SECTION */
        private void M_800_000_IMPRIME_TOTAL_GERAL_SECTION()
        {
            /*" -1018- MOVE '800-000-IMPRIME-TOTAL-GERAL' TO PARAGRAFO. */
            _.Move("800-000-IMPRIME-TOTAL-GERAL", W.WABEND.PARAGRAFO);

            /*" -1020- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", W.WABEND.WNR_EXEC_SQL);

            /*" -1021- IF W-CONT-LIN GREATER 50 */

            if (W.W_CONT_LIN > 50)
            {

                /*" -1022- ADD 1 TO W-CONT-PAG */
                W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

                /*" -1023- MOVE W-CONT-PAG TO LC01-PAG */
                _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

                /*" -1025- WRITE REG-SI0814M1 FROM LC01 AFTER NEW-PAGE */
                _.Move(W.LC01.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -1027- WRITE REG-SI0814M1 FROM LC02 AFTER 1 */
                _.Move(W.LC02.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -1029- WRITE REG-SI0814M1 FROM LC03 AFTER 2 */
                _.Move(W.LC03.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -1031- WRITE REG-SI0814M1 FROM LC04 AFTER 2 */
                _.Move(W.LC04.GetMoveValues(), REG_SI0814M1);

                SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

                /*" -1033- MOVE 5 TO W-CONT-LIN. */
                _.Move(5, W.W_CONT_LIN);
            }


            /*" -1035- MOVE WSN-VRPAGO-RAMO-TOT TO LT02-VALOR-PAGO. */
            _.Move(W.WSN_VRPAGO_RAMO_TOT, W.LT02.LT02_VALOR_PAGO);

            /*" -1036- WRITE REG-SI0814M1 FROM LT02 AFTER 2. */
            _.Move(W.LT02.GetMoveValues(), REG_SI0814M1);

            SI0814M1.Write(REG_SI0814M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -1054- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -1056- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -1058- CLOSE SI0814M1. */
            SI0814M1.Close();

            /*" -1059- DISPLAY 'SI0814B.................   *** FIM NORMAL ***' . */
            _.Display($"SI0814B.................   *** FIM NORMAL ***");

            /*" -1060- DISPLAY 'DATA PROCESSADA......... ' SIST-DTMOVABE */
            _.Display($"DATA PROCESSADA......... {SIST_DTMOVABE}");

            /*" -1061- DISPLAY 'LIDOS RELATORIOS........ ' AC-LID-TRELSIN */
            _.Display($"LIDOS RELATORIOS........ {W.AC_LID_TRELSIN}");

            /*" -1062- DISPLAY 'LIDOS MESTSINI/HISTSINI. ' AC-LID-MESTHIST */
            _.Display($"LIDOS MESTSINI/HISTSINI. {W.AC_LID_MESTHIST}");

            /*" -1064- DISPLAY 'TOTAL IMPRESSOS EMISSAO. ' AC-IMPRE */
            _.Display($"TOTAL IMPRESSOS EMISSAO. {W.AC_IMPRE}");

            /*" -1064- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1077- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1078- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1079- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1080- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1081- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1083- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1084- CLOSE SI0814M1. */
            SI0814M1.Close();

            /*" -1084- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1085- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1087- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1087- GOBACK. */

            throw new GoBack();

        }
    }
}