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
using Sias.Sinistro.DB2.SI0812B;

namespace Code
{
    public class SI0812B
    {
        public bool IsCall { get; set; }

        public SI0812B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    SINISTRO                          //      */
        /*"      * PROGRAMA             :    SI0812B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELACAO DE CAUSAS DE   //      */
        /*"      *                           SINISTROS AVISADOS POR APOLICE    //      */
        /*"      *                           NO MES/ANO SOLICITADO.            //      */
        /*"      * ANALISTA/PROGRAMADOR :    NELSON                            //      */
        /*"      * DATA                 :    SETEMBRO/95                       //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *                                                                *      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR JO0800)                                          *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  Avaliado pelo projeto JV1 em 15/01/2019                       *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0812M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0812M1
        {
            get
            {
                _.Move(REG_SI0812M1, _SI0812M1); VarBasis.RedefinePassValue(REG_SI0812M1, _SI0812M1, REG_SI0812M1); return _SI0812M1;
            }
        }
        /*"01  REG-SI0812M1.*/
        public SI0812B_REG_SI0812M1 REG_SI0812M1 { get; set; } = new SI0812B_REG_SI0812M1();
        public class SI0812B_REG_SI0812M1 : VarBasis
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
        /*"77           MEST-NRCERTIF          PIC S9(015)       COMP-3.*/
        public IntBasis MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77           MEST-DATORR            PIC  X(010).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-CODSUBES          PIC S9(004)       COMP.*/
        public IntBasis MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-FONTE             PIC S9(004)       COMP.*/
        public IntBasis MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-RAMO              PIC S9(004)       COMP.*/
        public IntBasis MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-CODCAU            PIC S9(004)       COMP.*/
        public IntBasis MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-IDTPSEGU          PIC  X(001).*/
        public StringBasis MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"77           SUBG-COD-CLIENTE       PIC S9(009)       COMP.*/
        public IntBasis SUBG_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           CLIE-COD-CLIENTE       PIC S9(009)       COMP.*/
        public IntBasis CLIE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           CLIE-NOME-RAZAO        PIC  X(040).*/
        public StringBasis CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           TFONTE-NOMEFTE         PIC  X(040).*/
        public StringBasis TFONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SINICAU-RAMO           PIC S9(004)       COMP.*/
        public IntBasis SINICAU_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SINICAU-CODCAU         PIC S9(004)       COMP.*/
        public IntBasis SINICAU_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SINICAU-DESCAU         PIC  X(040).*/
        public StringBasis SINICAU_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SEGU-COD-AGENCIADOR    PIC S9(009)       COMP.*/
        public IntBasis SEGU_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           SEGU-COD-CLIENTE       PIC S9(009)       COMP.*/
        public IntBasis SEGU_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           APOL-NOME              PIC  X(040).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           WDATA-INI              PIC  X(010).*/
        public StringBasis WDATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WDATA-FIM              PIC  X(010).*/
        public StringBasis WDATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              W.*/
        public SI0812B_W W { get; set; } = new SI0812B_W();
        public class SI0812B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0812B_LC01 LC01 { get; set; } = new SI0812B_LC01();
            public class SI0812B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC  X(009) VALUE 'SI0812B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0812B.1");
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
            public SI0812B_LC02 LC02 { get; set; } = new SI0812B_LC02();
            public class SI0812B_LC02 : VarBasis
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
            public SI0812B_LC03 LC03 { get; set; } = new SI0812B_LC03();
            public class SI0812B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04.*/
            }
            public SI0812B_LC04 LC04 { get; set; } = new SI0812B_LC04();
            public class SI0812B_LC04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(031) VALUE               'SINISTROS AVISADOS - CAUSAS EM '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"SINISTROS AVISADOS - CAUSAS EM ");
                /*"    05          LC04-MES-REF        PIC  X(010) VALUE ZEROS.*/
                public StringBasis LC04_MES_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    05          LC04-ANO-REF        PIC  9(004) VALUE ZEROS.*/
                public IntBasis LC04_ANO_REF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            LC05.*/
            }
            public SI0812B_LC05 LC05 { get; set; } = new SI0812B_LC05();
            public class SI0812B_LC05 : VarBasis
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
            public SI0812B_LC06 LC06 { get; set; } = new SI0812B_LC06();
            public class SI0812B_LC06 : VarBasis
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
            public SI0812B_LC07 LC07 { get; set; } = new SI0812B_LC07();
            public class SI0812B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE               'FONTE: '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"FONTE: ");
                /*"    05          LC07-FONTE          PIC  9(004) VALUE ZEROES.*/
                public IntBasis LC07_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC07-NOME-FONTE     PIC  X(040) VALUE SPACES.*/
                public StringBasis LC07_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC08.*/
            }
            public SI0812B_LC08 LC08 { get; set; } = new SI0812B_LC08();
            public class SI0812B_LC08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            LC09.*/
            }
            public SI0812B_LC09 LC09 { get; set; } = new SI0812B_LC09();
            public class SI0812B_LC09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE                                    'SINISTRO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          FILLER              PIC  X(040) VALUE                                    'SEGURADO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                                    'CERTIFICADO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"CERTIFICADO");
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE                                    'AGENCIADOR'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"AGENCIADOR");
                /*"    05          FILLER              PIC  X(011) VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE                                    'VALOR'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"  03            LC10.*/
            }
            public SI0812B_LC10 LC10 { get; set; } = new SI0812B_LC10();
            public class SI0812B_LC10 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE               'RAMO: '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"RAMO: ");
                /*"    05          LC10-RAMO           PIC  9(004) VALUE ZEROES.*/
                public IntBasis LC10_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE               'CAUSA: '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CAUSA: ");
                /*"    05          LC10-CODCAU         PIC  9(004) VALUE ZEROES.*/
                public IntBasis LC10_CODCAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC10-DESCAU         PIC  X(040) VALUE SPACES.*/
                public StringBasis LC10_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LD01.*/
            }
            public SI0812B_LD01 LD01 { get; set; } = new SI0812B_LD01();
            public class SI0812B_LD01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LD01-SINISTRO       PIC  9(013) BLANK WHEN ZERO.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LD01-NOME           PIC  X(040) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LD01-NRCERTIF       PIC  9(015) BLANK WHEN ZERO.*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LD01-COD-AGENC      PIC  9(009) BLANK WHEN ZERO.*/
                public IntBasis LD01_COD_AGENC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LD01-VL-AVIS        PIC  ZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LD01_VL_AVIS { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99B."), 2);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  03            LT01.*/
            }
            public SI0812B_LT01 LT01 { get; set; } = new SI0812B_LT01();
            public class SI0812B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LT01-DESCRICAO      PIC  X(030) VALUE SPACES.*/
                public StringBasis LT01_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE               'QUANTIDADE: '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"QUANTIDADE: ");
                /*"    05          LT01-QUANTIDADE     PIC  9(006) BLANK WHEN ZERO.*/
                public IntBasis LT01_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05          FILLER              PIC  X(035) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE               'VOLUME: '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VOLUME: ");
                /*"    05          LT01-VALOR-AVIS     PIC  ZZZZZ.ZZZ.ZZ9,99B.*/
                public DoubleBasis LT01_VALOR_AVIS { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZ.ZZZ.ZZ9V99B."), 2);
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
            /*"  03        WSN-RAMO-ANT           PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSN_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WSN-CODCAU-ANT         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSN_CODCAU_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WSN-APOL-SINI-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WSN_APOL_SINI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03        WSN-VRAVIS-PFISICA   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_PFISICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRAVIS-PJURIDI   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_PJURIDI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WSN-VRAVIS-APOLICE   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        W-CONT-APOL          PIC S9(006)    VALUE +0.*/
            public IntBasis W_CONT_APOL { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03        WSN-VRAVIS-CODSUBES  PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_CODSUBES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        W-CONT-SUB           PIC S9(006)    VALUE +0.*/
            public IntBasis W_CONT_SUB { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03        WSN-VRAVIS-FONTE     PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_FONTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        W-CONT-FONTE         PIC S9(006)    VALUE +0.*/
            public IntBasis W_CONT_FONTE { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03        WSN-VRAVIS-RAMO      PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        W-CONT-RAMO          PIC S9(006)    VALUE +0.*/
            public IntBasis W_CONT_RAMO { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03        WSN-VRAVIS-CAUSA     PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVIS_CAUSA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        W-CONT-CAUSA         PIC S9(006)    VALUE +0.*/
            public IntBasis W_CONT_CAUSA { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  03        WSN-VRAVISADO        PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WSN_VRAVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA-CURR.*/
            public SI0812B_WDATA_CURR WDATA_CURR { get; set; } = new SI0812B_WDATA_CURR();
            public class SI0812B_WDATA_CURR : VarBasis
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
            public SI0812B_WHORA_CURR WHORA_CURR { get; set; } = new SI0812B_WHORA_CURR();
            public class SI0812B_WHORA_CURR : VarBasis
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
            public SI0812B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0812B_WDATA_CABEC();
            public class SI0812B_WDATA_CABEC : VarBasis
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
            public SI0812B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0812B_WHORA_CABEC();
            public class SI0812B_WHORA_CABEC : VarBasis
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
                /*"  03            WDATA.*/
            }
            public SI0812B_WDATA WDATA { get; set; } = new SI0812B_WDATA();
            public class SI0812B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            public SI0812B_WDATA_SQL WDATA_SQL { get; set; } = new SI0812B_WDATA_SQL();
            public class SI0812B_WDATA_SQL : VarBasis
            {
                /*"    05          W-ANO-SQL           PIC  9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          W-MES-SQL           PIC  9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"  03            MESES.*/
            public SI0812B_MESES MESES { get; set; } = new SI0812B_MESES();
            public class SI0812B_MESES : VarBasis
            {
                /*"  05            TABELA-MESES.*/
                public SI0812B_TABELA_MESES TABELA_MESES { get; set; } = new SI0812B_TABELA_MESES();
                public class SI0812B_TABELA_MESES : VarBasis
                {
                    /*"    10          FILLER          PIC X(010)  VALUE '0  JANEIRO'.*/
                    public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  JANEIRO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0FEVEREIRO'.*/
                    public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0FEVEREIRO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0    MARCO'.*/
                    public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    MARCO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0    ABRIL'.*/
                    public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    ABRIL");
                    /*"    10          FILLER          PIC X(010)  VALUE '0     MAIO'.*/
                    public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0     MAIO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0    JUNHO'.*/
                    public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    JUNHO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0    JULHO'.*/
                    public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    JULHO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0   AGOSTO'.*/
                    public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0   AGOSTO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0 SETEMBRO'.*/
                    public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 SETEMBRO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0  OUTUBRO'.*/
                    public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  OUTUBRO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0 NOVEMBRO'.*/
                    public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 NOVEMBRO");
                    /*"    10          FILLER          PIC X(010)  VALUE '0 DEZEMBRO'.*/
                    public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 DEZEMBRO");
                    /*"  05            FILLER          REDEFINES   TABELA-MESES                                OCCURS      12.*/
                }
                private ListBasis<_REDEF_SI0812B_FILLER_70> _filler_70 { get; set; }
                public ListBasis<_REDEF_SI0812B_FILLER_70> FILLER_70
                {
                    get { _filler_70 = new ListBasis<_REDEF_SI0812B_FILLER_70>(12); _.Move(TABELA_MESES, _filler_70); VarBasis.RedefinePassValue(TABELA_MESES, _filler_70, TABELA_MESES); _filler_70.ValueChanged += () => { _.Move(_filler_70, TABELA_MESES); }; return _filler_70; }
                    set { VarBasis.RedefinePassValue(value, _filler_70, TABELA_MESES); }
                }  //Redefines
                public class _REDEF_SI0812B_FILLER_70 : VarBasis
                {
                    /*"    10          TAB-FLGMES      PIC  X(001).*/
                    public StringBasis TAB_FLGMES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10          TAB-MES         PIC  X(009).*/
                    public StringBasis TAB_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                    /*"  03        WABEND.*/

                    public _REDEF_SI0812B_FILLER_70()
                    {
                        TAB_FLGMES.ValueChanged += OnValueChanged;
                        TAB_MES.ValueChanged += OnValueChanged;
                    }

                }
                public SI0812B_WABEND WABEND { get; set; } = new SI0812B_WABEND();
                public class SI0812B_WABEND : VarBasis
                {
                    /*"    05      FILLER              PIC  X(010) VALUE           ' SI0812B'.*/
                    public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0812B");
                    /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                    /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                    public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                    /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                    public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                    /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                    public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                    /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                    public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                    /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"01          LK-LINK.*/
                }
            }
            public SI0812B_LK_LINK LK_LINK { get; set; } = new SI0812B_LK_LINK();
            public class SI0812B_LK_LINK : VarBasis
            {
                /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
                public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
                public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
                public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            }
        }


        public SI0812B_V1RELATSINI V1RELATSINI { get; set; } = new SI0812B_V1RELATSINI();
        public SI0812B_TMESTSIN TMESTSIN { get; set; } = new SI0812B_TMESTSIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0812M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0812M1.SetFile(SI0812M1_FILE_NAME_P);

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
            /*" -441- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -444- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.MESES.WABEND.PARAGRAFO);

            /*" -445- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -447- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -449- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -454- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -455- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -456- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -457- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -459- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -461- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -463- PERFORM 520-000-LER-TSISTEMA. */

            M_520_000_LER_TSISTEMA_SECTION();

            /*" -464- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, W.WDATA_CURR);

            /*" -465- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.WDATA_CURR.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -466- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.WDATA_CURR.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -467- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.WDATA_CURR.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -469- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -471- PERFORM 530-000-CURSOR-TRELSIN. */

            M_530_000_CURSOR_TRELSIN_SECTION();

            /*" -473- PERFORM 540-000-LER-TRELSIN. */

            M_540_000_LER_TRELSIN_SECTION();

            /*" -474- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -475- DISPLAY 'SI0812B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0812B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -477- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -480- PERFORM 110-000-PROCESSA-EMISSAO UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_110_000_PROCESSA_EMISSAO_SECTION();
            }

            /*" -480- PERFORM 590-000-ATUALIZA-TRELSIN. */

            M_590_000_ATUALIZA_TRELSIN_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -487- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -487- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -501- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.MESES.WABEND.PARAGRAFO);

            /*" -501- OPEN OUTPUT SI0812M1. */
            SI0812M1.Open(REG_SI0812M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-110-000-PROCESSA-EMISSAO-SECTION */
        private void M_110_000_PROCESSA_EMISSAO_SECTION()
        {
            /*" -515- MOVE '110-000-PROCESSA-EMISSAO' TO PARAGRAFO. */
            _.Move("110-000-PROCESSA-EMISSAO", W.MESES.WABEND.PARAGRAFO);

            /*" -516- MOVE RELSIN-APOLICE TO WSN-APOLICE-ANT. */
            _.Move(RELSIN_APOLICE, W.WSN_APOLICE_ANT);

            /*" -517- MOVE RELSIN-ANO-REF TO WSN-ANO-REF-ANT. */
            _.Move(RELSIN_ANO_REF, W.WSN_ANO_REF_ANT);

            /*" -519- MOVE RELSIN-MES-REF TO WSN-MES-REF-ANT. */
            _.Move(RELSIN_MES_REF, W.WSN_MES_REF_ANT);

            /*" -520- MOVE RELSIN-APOLICE TO LC05-APOLICE. */
            _.Move(RELSIN_APOLICE, W.LC05.LC05_APOLICE);

            /*" -522- MOVE RELSIN-ANO-REF TO LC04-ANO-REF. */
            _.Move(RELSIN_ANO_REF, W.LC04.LC04_ANO_REF);

            /*" -524- MOVE TAB-MES(RELSIN-MES-REF) TO LC04-MES-REF. */
            _.Move(W.MESES.FILLER_70[RELSIN_MES_REF].TAB_MES, W.LC04.LC04_MES_REF);

            /*" -525- MOVE RELSIN-ANO-REF TO W-ANO-SQL. */
            _.Move(RELSIN_ANO_REF, W.WDATA_SQL.W_ANO_SQL);

            /*" -527- MOVE RELSIN-MES-REF TO W-MES-SQL. */
            _.Move(RELSIN_MES_REF, W.WDATA_SQL.W_MES_SQL);

            /*" -529- IF RELSIN-MES-REF = 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (RELSIN_MES_REF.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -530- MOVE 31 TO W-DIA-SQL */
                _.Move(31, W.WDATA_SQL.W_DIA_SQL);

                /*" -531- ELSE */
            }
            else
            {


                /*" -532- IF RELSIN-MES-REF = 4 OR 6 OR 9 OR 11 */

                if (RELSIN_MES_REF.In("4", "6", "9", "11"))
                {

                    /*" -533- MOVE 30 TO W-DIA-SQL */
                    _.Move(30, W.WDATA_SQL.W_DIA_SQL);

                    /*" -534- ELSE */
                }
                else
                {


                    /*" -535- MOVE RELSIN-ANO-REF TO WANO-BISSEXTO */
                    _.Move(RELSIN_ANO_REF, W.WANO_BISSEXTO);

                    /*" -536- DIVIDE WANO-BISSEXTO BY 4 GIVING J REMAINDER WRESTO */
                    _.Divide(W.WANO_BISSEXTO, 4, W.J, W.WRESTO);

                    /*" -537- IF WRESTO EQUAL ZERO */

                    if (W.WRESTO == 00)
                    {

                        /*" -538- MOVE 29 TO W-DIA-SQL */
                        _.Move(29, W.WDATA_SQL.W_DIA_SQL);

                        /*" -539- ELSE */
                    }
                    else
                    {


                        /*" -540- MOVE 28 TO W-DIA-SQL */
                        _.Move(28, W.WDATA_SQL.W_DIA_SQL);

                        /*" -542- END-IF. */
                    }

                }

            }


            /*" -544- MOVE WDATA-SQL TO WDATA-FIM. */
            _.Move(W.WDATA_SQL, WDATA_FIM);

            /*" -545- MOVE 01 TO W-DIA-SQL */
            _.Move(01, W.WDATA_SQL.W_DIA_SQL);

            /*" -547- MOVE WDATA-SQL TO WDATA-INI. */
            _.Move(W.WDATA_SQL, WDATA_INI);

            /*" -548- PERFORM 580-000-LER-TAPOLICE. */

            M_580_000_LER_TAPOLICE_SECTION();

            /*" -550- MOVE APOL-NOME TO LC05-SEGURADO. */
            _.Move(APOL_NOME, W.LC05.LC05_SEGURADO);

            /*" -556- MOVE +0 TO W-CONT-APOL W-CONT-SUB W-CONT-FONTE W-CONT-RAMO W-CONT-CAUSA. */
            _.Move(+0, W.W_CONT_APOL, W.W_CONT_SUB, W.W_CONT_FONTE, W.W_CONT_RAMO, W.W_CONT_CAUSA);

            /*" -560- PERFORM 150-000-PROCESSA-TRELSIN UNTIL WFIM-TRELSIN EQUAL 'S' OR RELSIN-APOLICE NOT EQUAL WSN-APOLICE-ANT OR RELSIN-ANO-REF NOT EQUAL WSN-ANO-REF-ANT OR RELSIN-MES-REF NOT EQUAL WSN-MES-REF-ANT. */

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
            /*" -575- MOVE '150-000-PROCESSA-TRELSIN' TO PARAGRAFO */
            _.Move("150-000-PROCESSA-TRELSIN", W.MESES.WABEND.PARAGRAFO);

            /*" -577- MOVE 'N' TO WFIM-TMESTSIN */
            _.Move("N", W.WFIM_TMESTSIN);

            /*" -578- PERFORM 550-000-CURSOR-TMESTSIN */

            M_550_000_CURSOR_TMESTSIN_SECTION();

            /*" -579- PERFORM 560-000-LER-TMESTSIN */

            M_560_000_LER_TMESTSIN_SECTION();

            /*" -582- PERFORM 230-000-PROCESSA-CODSUBES UNTIL WFIM-TMESTSIN EQUAL 'S' . */

            while (!(W.WFIM_TMESTSIN == "S"))
            {

                M_230_000_PROCESSA_CODSUBES_SECTION();
            }

            /*" -582- PERFORM 380-000-IMPRIME-TOTAL-APOLICE. */

            M_380_000_IMPRIME_TOTAL_APOLICE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_150_010_LEITURA */

            M_150_010_LEITURA();

        }

        [StopWatch]
        /*" M-150-010-LEITURA */
        private void M_150_010_LEITURA(bool isPerform = false)
        {
            /*" -588- PERFORM 540-000-LER-TRELSIN. */

            M_540_000_LER_TRELSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-230-000-PROCESSA-CODSUBES-SECTION */
        private void M_230_000_PROCESSA_CODSUBES_SECTION()
        {
            /*" -602- MOVE '230-000-PROCESSA-CODSUBES' TO PARAGRAFO. */
            _.Move("230-000-PROCESSA-CODSUBES", W.MESES.WABEND.PARAGRAFO);

            /*" -603- MOVE MEST-CODSUBES TO LC06-CODSUBES */
            _.Move(MEST_CODSUBES, W.LC06.LC06_CODSUBES);

            /*" -604- PERFORM 570-000-LER-SUBGRUPO */

            M_570_000_LER_SUBGRUPO_SECTION();

            /*" -605- PERFORM 572-000-LER-TCLIENTE */

            M_572_000_LER_TCLIENTE_SECTION();

            /*" -607- MOVE CLIE-NOME-RAZAO TO LC06-NOME-RAZAO */
            _.Move(CLIE_NOME_RAZAO, W.LC06.LC06_NOME_RAZAO);

            /*" -609- MOVE MEST-CODSUBES TO WSN-CODSUBES-ANT */
            _.Move(MEST_CODSUBES, W.WSN_CODSUBES_ANT);

            /*" -613- PERFORM 240-000-PROCESSA-FONTE UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT))
            {

                M_240_000_PROCESSA_FONTE_SECTION();
            }

            /*" -614- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -617- PERFORM 390-000-CABEC THRU 390-000-LC06. */

                M_390_000_CABEC_SECTION();

                M_390_000_LC05();

                M_390_000_LC06();
            }


            /*" -618- MOVE 'TOTAL SUB-GRUPO' TO LT01-DESCRICAO */
            _.Move("TOTAL SUB-GRUPO", W.LT01.LT01_DESCRICAO);

            /*" -619- MOVE W-CONT-SUB TO LT01-QUANTIDADE */
            _.Move(W.W_CONT_SUB, W.LT01.LT01_QUANTIDADE);

            /*" -621- MOVE WSN-VRAVIS-CODSUBES TO LT01-VALOR-AVIS */
            _.Move(W.WSN_VRAVIS_CODSUBES, W.LT01.LT01_VALOR_AVIS);

            /*" -623- WRITE REG-SI0812M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -625- MOVE +70 TO W-CONT-LIN. */
            _.Move(+70, W.W_CONT_LIN);

            /*" -626- IF WSN-CODSUBES-ANT = 1 */

            if (W.WSN_CODSUBES_ANT == 1)
            {

                /*" -627- ADD WSN-VRAVIS-CODSUBES TO WSN-VRAVIS-PFISICA */
                W.WSN_VRAVIS_PFISICA.Value = W.WSN_VRAVIS_PFISICA + W.WSN_VRAVIS_CODSUBES;

                /*" -628- ELSE */
            }
            else
            {


                /*" -630- ADD WSN-VRAVIS-CODSUBES TO WSN-VRAVIS-PJURIDI. */
                W.WSN_VRAVIS_PJURIDI.Value = W.WSN_VRAVIS_PJURIDI + W.WSN_VRAVIS_CODSUBES;
            }


            /*" -631- ADD WSN-VRAVIS-CODSUBES TO WSN-VRAVIS-APOLICE */
            W.WSN_VRAVIS_APOLICE.Value = W.WSN_VRAVIS_APOLICE + W.WSN_VRAVIS_CODSUBES;

            /*" -633- MOVE +0 TO WSN-VRAVIS-CODSUBES. */
            _.Move(+0, W.WSN_VRAVIS_CODSUBES);

            /*" -634- ADD W-CONT-SUB TO W-CONT-APOL */
            W.W_CONT_APOL.Value = W.W_CONT_APOL + W.W_CONT_SUB;

            /*" -634- MOVE +0 TO W-CONT-SUB. */
            _.Move(+0, W.W_CONT_SUB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-240-000-PROCESSA-FONTE-SECTION */
        private void M_240_000_PROCESSA_FONTE_SECTION()
        {
            /*" -648- MOVE '240-000-PROCESSA-FONTE' TO PARAGRAFO. */
            _.Move("240-000-PROCESSA-FONTE", W.MESES.WABEND.PARAGRAFO);

            /*" -649- MOVE +0 TO W-CONT-CAUSA. */
            _.Move(+0, W.W_CONT_CAUSA);

            /*" -651- MOVE MEST-FONTE TO WSN-FONTE-ANT */
            _.Move(MEST_FONTE, W.WSN_FONTE_ANT);

            /*" -652- MOVE MEST-FONTE TO LC07-FONTE */
            _.Move(MEST_FONTE, W.LC07.LC07_FONTE);

            /*" -653- PERFORM 575-000-LER-TFONTE */

            M_575_000_LER_TFONTE_SECTION();

            /*" -659- MOVE TFONTE-NOMEFTE TO LC07-NOME-FONTE */
            _.Move(TFONTE_NOMEFTE, W.LC07.LC07_NOME_FONTE);

            /*" -661- PERFORM 390-000-CABEC THRU 390-000-LC08. */

            M_390_000_CABEC_SECTION();

            M_390_000_LC05();

            M_390_000_LC06();

            M_390_000_LC07();

            M_390_000_LC08();

            /*" -666- PERFORM 250-000-PROCESSA-RAMO UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT OR MEST-FONTE NOT EQUAL WSN-FONTE-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT || MEST_FONTE != W.WSN_FONTE_ANT))
            {

                M_250_000_PROCESSA_RAMO_SECTION();
            }

            /*" -667- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -670- PERFORM 390-000-CABEC THRU 390-000-LC07. */

                M_390_000_CABEC_SECTION();

                M_390_000_LC05();

                M_390_000_LC06();

                M_390_000_LC07();
            }


            /*" -671- MOVE 'TOTAL FONTE' TO LT01-DESCRICAO */
            _.Move("TOTAL FONTE", W.LT01.LT01_DESCRICAO);

            /*" -672- MOVE W-CONT-FONTE TO LT01-QUANTIDADE */
            _.Move(W.W_CONT_FONTE, W.LT01.LT01_QUANTIDADE);

            /*" -674- MOVE WSN-VRAVIS-FONTE TO LT01-VALOR-AVIS */
            _.Move(W.WSN_VRAVIS_FONTE, W.LT01.LT01_VALOR_AVIS);

            /*" -676- WRITE REG-SI0812M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -678- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

            /*" -679- ADD WSN-VRAVIS-FONTE TO WSN-VRAVIS-CODSUBES */
            W.WSN_VRAVIS_CODSUBES.Value = W.WSN_VRAVIS_CODSUBES + W.WSN_VRAVIS_FONTE;

            /*" -681- MOVE +0 TO WSN-VRAVIS-FONTE. */
            _.Move(+0, W.WSN_VRAVIS_FONTE);

            /*" -682- ADD W-CONT-FONTE TO W-CONT-SUB */
            W.W_CONT_SUB.Value = W.W_CONT_SUB + W.W_CONT_FONTE;

            /*" -682- MOVE +0 TO W-CONT-FONTE. */
            _.Move(+0, W.W_CONT_FONTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-250-000-PROCESSA-RAMO-SECTION */
        private void M_250_000_PROCESSA_RAMO_SECTION()
        {
            /*" -696- MOVE '250-000-PROCESSA-RAMO' TO PARAGRAFO. */
            _.Move("250-000-PROCESSA-RAMO", W.MESES.WABEND.PARAGRAFO);

            /*" -697- MOVE +0 TO W-CONT-RAMO. */
            _.Move(+0, W.W_CONT_RAMO);

            /*" -699- MOVE MEST-RAMO TO WSN-RAMO-ANT */
            _.Move(MEST_RAMO, W.WSN_RAMO_ANT);

            /*" -701- MOVE MEST-RAMO TO LC10-RAMO */
            _.Move(MEST_RAMO, W.LC10.LC10_RAMO);

            /*" -707- PERFORM 255-000-PROCESSA-CODCAU UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT OR MEST-FONTE NOT EQUAL WSN-FONTE-ANT OR MEST-RAMO NOT EQUAL WSN-RAMO-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT || MEST_FONTE != W.WSN_FONTE_ANT || MEST_RAMO != W.WSN_RAMO_ANT))
            {

                M_255_000_PROCESSA_CODCAU_SECTION();
            }

            /*" -708- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -709- MOVE +0 TO LC10-CODCAU */
                _.Move(+0, W.LC10.LC10_CODCAU);

                /*" -710- MOVE SPACES TO LC10-DESCAU */
                _.Move("", W.LC10.LC10_DESCAU);

                /*" -713- PERFORM 390-000-CABEC THRU 390-000-LC10. */

                M_390_000_CABEC_SECTION();

                M_390_000_LC05();

                M_390_000_LC06();

                M_390_000_LC07();

                M_390_000_LC08();

                M_390_000_LC10();
            }


            /*" -714- MOVE 'TOTAL RAMO' TO LT01-DESCRICAO */
            _.Move("TOTAL RAMO", W.LT01.LT01_DESCRICAO);

            /*" -715- MOVE W-CONT-RAMO TO LT01-QUANTIDADE */
            _.Move(W.W_CONT_RAMO, W.LT01.LT01_QUANTIDADE);

            /*" -717- MOVE WSN-VRAVIS-RAMO TO LT01-VALOR-AVIS */
            _.Move(W.WSN_VRAVIS_RAMO, W.LT01.LT01_VALOR_AVIS);

            /*" -719- WRITE REG-SI0812M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -721- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

            /*" -722- ADD WSN-VRAVIS-RAMO TO WSN-VRAVIS-FONTE */
            W.WSN_VRAVIS_FONTE.Value = W.WSN_VRAVIS_FONTE + W.WSN_VRAVIS_RAMO;

            /*" -724- MOVE +0 TO WSN-VRAVIS-RAMO. */
            _.Move(+0, W.WSN_VRAVIS_RAMO);

            /*" -725- ADD W-CONT-RAMO TO W-CONT-FONTE */
            W.W_CONT_FONTE.Value = W.W_CONT_FONTE + W.W_CONT_RAMO;

            /*" -725- MOVE +0 TO W-CONT-RAMO. */
            _.Move(+0, W.W_CONT_RAMO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_250_999_EXIT*/

        [StopWatch]
        /*" M-255-000-PROCESSA-CODCAU-SECTION */
        private void M_255_000_PROCESSA_CODCAU_SECTION()
        {
            /*" -739- MOVE '255-000-PROCESSA-CODCAU' TO PARAGRAFO. */
            _.Move("255-000-PROCESSA-CODCAU", W.MESES.WABEND.PARAGRAFO);

            /*" -741- MOVE MEST-CODCAU TO WSN-CODCAU-ANT */
            _.Move(MEST_CODCAU, W.WSN_CODCAU_ANT);

            /*" -743- MOVE MEST-CODCAU TO LC10-CODCAU */
            _.Move(MEST_CODCAU, W.LC10.LC10_CODCAU);

            /*" -744- PERFORM 585-000-LER-SINICAU */

            M_585_000_LER_SINICAU_SECTION();

            /*" -746- MOVE SINICAU-DESCAU TO LC10-DESCAU */
            _.Move(SINICAU_DESCAU, W.LC10.LC10_DESCAU);

            /*" -747- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -749- PERFORM 390-000-CABEC THRU 390-000-LC08. */

                M_390_000_CABEC_SECTION();

                M_390_000_LC05();

                M_390_000_LC06();

                M_390_000_LC07();

                M_390_000_LC08();
            }


            /*" -751- PERFORM 390-000-LC10. */

            M_390_000_LC10();

            /*" -758- PERFORM 250-000-PROCESSA-APOL-SINI UNTIL WFIM-TMESTSIN EQUAL 'S' OR MEST-CODSUBES NOT EQUAL WSN-CODSUBES-ANT OR MEST-FONTE NOT EQUAL WSN-FONTE-ANT OR MEST-RAMO NOT EQUAL WSN-RAMO-ANT OR MEST-CODCAU NOT EQUAL WSN-CODCAU-ANT. */

            while (!(W.WFIM_TMESTSIN == "S" || MEST_CODSUBES != W.WSN_CODSUBES_ANT || MEST_FONTE != W.WSN_FONTE_ANT || MEST_RAMO != W.WSN_RAMO_ANT || MEST_CODCAU != W.WSN_CODCAU_ANT))
            {

                M_250_000_PROCESSA_APOL_SINI_SECTION();
            }

            /*" -759- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -762- PERFORM 390-000-CABEC THRU 390-000-LC10. */

                M_390_000_CABEC_SECTION();

                M_390_000_LC05();

                M_390_000_LC06();

                M_390_000_LC07();

                M_390_000_LC08();

                M_390_000_LC10();
            }


            /*" -763- MOVE 'TOTAL CAUSA' TO LT01-DESCRICAO */
            _.Move("TOTAL CAUSA", W.LT01.LT01_DESCRICAO);

            /*" -764- MOVE W-CONT-CAUSA TO LT01-QUANTIDADE */
            _.Move(W.W_CONT_CAUSA, W.LT01.LT01_QUANTIDADE);

            /*" -766- MOVE WSN-VRAVIS-CAUSA TO LT01-VALOR-AVIS */
            _.Move(W.WSN_VRAVIS_CAUSA, W.LT01.LT01_VALOR_AVIS);

            /*" -768- WRITE REG-SI0812M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -770- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

            /*" -771- ADD WSN-VRAVIS-CAUSA TO WSN-VRAVIS-RAMO. */
            W.WSN_VRAVIS_RAMO.Value = W.WSN_VRAVIS_RAMO + W.WSN_VRAVIS_CAUSA;

            /*" -773- MOVE +0 TO WSN-VRAVIS-CAUSA. */
            _.Move(+0, W.WSN_VRAVIS_CAUSA);

            /*" -774- ADD W-CONT-CAUSA TO W-CONT-RAMO */
            W.W_CONT_RAMO.Value = W.W_CONT_RAMO + W.W_CONT_CAUSA;

            /*" -774- MOVE +0 TO W-CONT-CAUSA. */
            _.Move(+0, W.W_CONT_CAUSA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_255_999_EXIT*/

        [StopWatch]
        /*" M-250-000-PROCESSA-APOL-SINI-SECTION */
        private void M_250_000_PROCESSA_APOL_SINI_SECTION()
        {
            /*" -788- MOVE '250-000-PROCESSA-APOL-SINI' TO PARAGRAFO. */
            _.Move("250-000-PROCESSA-APOL-SINI", W.MESES.WABEND.PARAGRAFO);

            /*" -789- MOVE SPACES TO LD01 */
            _.Move("", W.LD01);

            /*" -790- MOVE MEST-APOL-SINI TO LD01-SINISTRO */
            _.Move(MEST_APOL_SINI, W.LD01.LD01_SINISTRO);

            /*" -791- PERFORM 571-000-LER-SEGURAVG */

            M_571_000_LER_SEGURAVG_SECTION();

            /*" -792- PERFORM 572-000-LER-TCLIENTE */

            M_572_000_LER_TCLIENTE_SECTION();

            /*" -793- MOVE CLIE-NOME-RAZAO TO LD01-NOME */
            _.Move(CLIE_NOME_RAZAO, W.LD01.LD01_NOME);

            /*" -794- MOVE MEST-NRCERTIF TO LD01-NRCERTIF */
            _.Move(MEST_NRCERTIF, W.LD01.LD01_NRCERTIF);

            /*" -796- MOVE WSN-VRAVISADO TO LD01-VL-AVIS */
            _.Move(W.WSN_VRAVISADO, W.LD01.LD01_VL_AVIS);

            /*" -797- IF W-CONT-LIN GREATER 55 */

            if (W.W_CONT_LIN > 55)
            {

                /*" -800- PERFORM 390-000-CABEC THRU 390-999-EXIT. */

                M_390_000_CABEC_SECTION();

                M_390_000_LC05();

                M_390_000_LC06();

                M_390_000_LC07();

                M_390_000_LC08();

                M_390_000_LC10();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

            }


            /*" -803- WRITE REG-SI0812M1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -804- ADD 1 TO AC-IMPRE. */
            W.AC_IMPRE.Value = W.AC_IMPRE + 1;

            /*" -805- ADD 1 TO W-CONT-CAUSA. */
            W.W_CONT_CAUSA.Value = W.W_CONT_CAUSA + 1;

            /*" -806- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

            /*" -808- MOVE SPACES TO LD01. */
            _.Move("", W.LD01);

            /*" -809- ADD WSN-VRAVISADO TO WSN-VRAVIS-CAUSA */
            W.WSN_VRAVIS_CAUSA.Value = W.WSN_VRAVIS_CAUSA + W.WSN_VRAVISADO;

            /*" -809- MOVE +0 TO WSN-VRAVISADO. */
            _.Move(+0, W.WSN_VRAVISADO);

            /*" -0- FLUXCONTROL_PERFORM M_250_010_LEITURA */

            M_250_010_LEITURA();

        }

        [StopWatch]
        /*" M-250-010-LEITURA */
        private void M_250_010_LEITURA(bool isPerform = false)
        {
            /*" -813- PERFORM 560-000-LER-TMESTSIN. */

            M_560_000_LER_TMESTSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_251_999_EXIT*/

        [StopWatch]
        /*" M-380-000-IMPRIME-TOTAL-APOLICE-SECTION */
        private void M_380_000_IMPRIME_TOTAL_APOLICE_SECTION()
        {
            /*" -828- MOVE '380-000-IMPRIME-TOTAL-APOLICE' TO PARAGRAFO. */
            _.Move("380-000-IMPRIME-TOTAL-APOLICE", W.MESES.WABEND.PARAGRAFO);

            /*" -829- IF W-CONT-LIN GREATER 50 */

            if (W.W_CONT_LIN > 50)
            {

                /*" -830- ADD 1 TO W-CONT-PAG */
                W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

                /*" -831- MOVE W-CONT-PAG TO LC01-PAG */
                _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

                /*" -833- WRITE REG-SI0812M1 FROM LC01 AFTER NEW-PAGE */
                _.Move(W.LC01.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -835- WRITE REG-SI0812M1 FROM LC02 AFTER 1 */
                _.Move(W.LC02.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -837- WRITE REG-SI0812M1 FROM LC03 AFTER 1 */
                _.Move(W.LC03.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -839- WRITE REG-SI0812M1 FROM LC04 AFTER 1 */
                _.Move(W.LC04.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -841- WRITE REG-SI0812M1 FROM LC05 AFTER 2 */
                _.Move(W.LC05.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -843- WRITE REG-SI0812M1 FROM LC08 AFTER 1 */
                _.Move(W.LC08.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -846- MOVE 6 TO W-CONT-LIN. */
                _.Move(6, W.W_CONT_LIN);
            }


            /*" -847- IF WSN-APOLICE-ANT = 0097010000889 */

            if (W.WSN_APOLICE_ANT == 0097010000889)
            {

                /*" -848- MOVE 'TOTAL PESSOA FISICA' TO LT01-DESCRICAO */
                _.Move("TOTAL PESSOA FISICA", W.LT01.LT01_DESCRICAO);

                /*" -849- MOVE WSN-VRAVIS-PFISICA TO LT01-VALOR-AVIS */
                _.Move(W.WSN_VRAVIS_PFISICA, W.LT01.LT01_VALOR_AVIS);

                /*" -851- WRITE REG-SI0812M1 FROM LT01 AFTER 2 */
                _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

                /*" -852- MOVE 'TOTAL PESSOA JURIDICA' TO LT01-DESCRICAO */
                _.Move("TOTAL PESSOA JURIDICA", W.LT01.LT01_DESCRICAO);

                /*" -853- MOVE WSN-VRAVIS-PJURIDI TO LT01-VALOR-AVIS */
                _.Move(W.WSN_VRAVIS_PJURIDI, W.LT01.LT01_VALOR_AVIS);

                /*" -856- WRITE REG-SI0812M1 FROM LT01 AFTER 2. */
                _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

                SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());
            }


            /*" -857- MOVE W-CONT-APOL TO LT01-QUANTIDADE */
            _.Move(W.W_CONT_APOL, W.LT01.LT01_QUANTIDADE);

            /*" -858- MOVE 'TOTAL APOLICE' TO LT01-DESCRICAO */
            _.Move("TOTAL APOLICE", W.LT01.LT01_DESCRICAO);

            /*" -860- MOVE WSN-VRAVIS-APOLICE TO LT01-VALOR-AVIS */
            _.Move(W.WSN_VRAVIS_APOLICE, W.LT01.LT01_VALOR_AVIS);

            /*" -863- WRITE REG-SI0812M1 FROM LT01 AFTER 2. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -866- MOVE +0 TO WSN-VRAVIS-PFISICA WSN-VRAVIS-PJURIDI WSN-VRAVIS-APOLICE. */
            _.Move(+0, W.WSN_VRAVIS_PFISICA, W.WSN_VRAVIS_PJURIDI, W.WSN_VRAVIS_APOLICE);

            /*" -867- MOVE +90 TO W-CONT-LIN. */
            _.Move(+90, W.W_CONT_LIN);

            /*" -868- MOVE +0 TO W-CONT-PAG. */
            _.Move(+0, W.W_CONT_PAG);

            /*" -872- MOVE +0 TO W-CONT-APOL W-CONT-SUB W-CONT-FONTE W-CONT-RAMO W-CONT-CAUSA. */
            _.Move(+0, W.W_CONT_APOL, W.W_CONT_SUB, W.W_CONT_FONTE, W.W_CONT_RAMO, W.W_CONT_CAUSA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_380_999_EXIT*/

        [StopWatch]
        /*" M-390-000-CABEC-SECTION */
        private void M_390_000_CABEC_SECTION()
        {
            /*" -885- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.MESES.WABEND.PARAGRAFO);

            /*" -886- IF W-CONT-LIN = +99 */

            if (W.W_CONT_LIN == +99)
            {

                /*" -888- PERFORM 400-000-CARGA-CABEC. */

                M_400_000_CARGA_CABEC_SECTION();
            }


            /*" -889- ADD 1 TO W-CONT-PAG. */
            W.W_CONT_PAG.Value = W.W_CONT_PAG + 1;

            /*" -892- MOVE W-CONT-PAG TO LC01-PAG. */
            _.Move(W.W_CONT_PAG, W.LC01.LC01_PAG);

            /*" -895- WRITE REG-SI0812M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -898- WRITE REG-SI0812M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -901- WRITE REG-SI0812M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -903- WRITE REG-SI0812M1 FROM LC04 AFTER 1 */
            _.Move(W.LC04.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -903- MOVE 4 TO W-CONT-LIN. */
            _.Move(4, W.W_CONT_LIN);

            /*" -0- FLUXCONTROL_PERFORM M_390_000_LC05 */

            M_390_000_LC05();

        }

        [StopWatch]
        /*" M-390-000-LC05 */
        private void M_390_000_LC05(bool isPerform = false)
        {
            /*" -908- WRITE REG-SI0812M1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -908- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

        }

        [StopWatch]
        /*" M-390-000-LC06 */
        private void M_390_000_LC06(bool isPerform = false)
        {
            /*" -913- WRITE REG-SI0812M1 FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -913- ADD 1 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 1;

        }

        [StopWatch]
        /*" M-390-000-LC07 */
        private void M_390_000_LC07(bool isPerform = false)
        {
            /*" -918- WRITE REG-SI0812M1 FROM LC07 AFTER 1. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -918- ADD 1 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 1;

        }

        [StopWatch]
        /*" M-390-000-LC08 */
        private void M_390_000_LC08(bool isPerform = false)
        {
            /*" -924- WRITE REG-SI0812M1 FROM LC08 AFTER 1. */
            _.Move(W.LC08.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -927- WRITE REG-SI0812M1 FROM LC09 AFTER 1. */
            _.Move(W.LC09.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -930- WRITE REG-SI0812M1 FROM LC08 AFTER 1. */
            _.Move(W.LC08.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -930- ADD 3 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 3;

        }

        [StopWatch]
        /*" M-390-000-LC10 */
        private void M_390_000_LC10(bool isPerform = false)
        {
            /*" -935- WRITE REG-SI0812M1 FROM LC10 AFTER 2. */
            _.Move(W.LC10.GetMoveValues(), REG_SI0812M1);

            SI0812M1.Write(REG_SI0812M1.GetMoveValues().ToString());

            /*" -935- ADD 2 TO W-CONT-LIN. */
            W.W_CONT_LIN.Value = W.W_CONT_LIN + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-400-000-CARGA-CABEC-SECTION */
        private void M_400_000_CARGA_CABEC_SECTION()
        {
            /*" -949- PERFORM 510-000-LER-TEMPRESA. */

            M_510_000_LER_TEMPRESA_SECTION();

            /*" -950- MOVE TEMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(TEMPRESA_NOM_EMP, W.LK_LINK.LK_TITULO);

            /*" -952- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", W.LK_LINK);

            /*" -953- IF LK-RTCODE EQUAL ZEROS */

            if (W.LK_LINK.LK_RTCODE == 00)
            {

                /*" -954- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(W.LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -955- ELSE */
            }
            else
            {


                /*" -956- DISPLAY 'SI0812B - PROBLEMA CALL PROALN01 ' */
                _.Display($"SI0812B - PROBLEMA CALL PROALN01 ");

                /*" -957- DISPLAY '          EMPRESA: ' TEMPRESA-NOM-EMP */
                _.Display($"          EMPRESA: {TEMPRESA_NOM_EMP}");

                /*" -958- CLOSE SI0812M1 */
                SI0812M1.Close();

                /*" -958- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-510-000-LER-TEMPRESA-SECTION */
        private void M_510_000_LER_TEMPRESA_SECTION()
        {
            /*" -973- MOVE '510-000-LER-TEMPRESA' TO PARAGRAFO. */
            _.Move("510-000-LER-TEMPRESA", W.MESES.WABEND.PARAGRAFO);

            /*" -975- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -980- PERFORM M_510_000_LER_TEMPRESA_DB_SELECT_1 */

            M_510_000_LER_TEMPRESA_DB_SELECT_1();

            /*" -983- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -984- DISPLAY 'SI0812B - NAO CONSTA REGISTRO NA TEMPRESA' */
                _.Display($"SI0812B - NAO CONSTA REGISTRO NA TEMPRESA");

                /*" -984- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-510-000-LER-TEMPRESA-DB-SELECT-1 */
        public void M_510_000_LER_TEMPRESA_DB_SELECT_1()
        {
            /*" -980- EXEC SQL SELECT NOME_EMPRESA INTO :TEMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -999- MOVE '520-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("520-000-LER-TSISTEMA", W.MESES.WABEND.PARAGRAFO);

            /*" -1001- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1006- PERFORM M_520_000_LER_TSISTEMA_DB_SELECT_1 */

            M_520_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -1009- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1010- DISPLAY 'SI0812B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0812B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -1010- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-520-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_520_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -1006- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -1027- MOVE '530-000-CURSOR-TRELSIN' TO PARAGRAFO */
            _.Move("530-000-CURSOR-TRELSIN", W.MESES.WABEND.PARAGRAFO);

            /*" -1029- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1039- PERFORM M_530_000_CURSOR_TRELSIN_DB_DECLARE_1 */

            M_530_000_CURSOR_TRELSIN_DB_DECLARE_1();

            /*" -1041- PERFORM M_530_000_CURSOR_TRELSIN_DB_OPEN_1 */

            M_530_000_CURSOR_TRELSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-530-000-CURSOR-TRELSIN-DB-DECLARE-1 */
        public void M_530_000_CURSOR_TRELSIN_DB_DECLARE_1()
        {
            /*" -1039- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT NUM_APOLICE, ANO_REFERENCIA, MES_REFERENCIA FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0812B' AND DATA_SOLICITACAO = :SIST-DTMOVABE AND SITUACAO = '0' ORDER BY NUM_APOLICE, ANO_REFERENCIA, MES_REFERENCIA END-EXEC. */
            V1RELATSINI = new SI0812B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							ANO_REFERENCIA
							, 
							MES_REFERENCIA 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0812B' 
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
            /*" -1041- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-DB-DECLARE-1 */
        public void M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1()
        {
            /*" -1124- EXEC SQL DECLARE TMESTSIN CURSOR FOR SELECT M.CODSUBES, M.FONTE, M.RAMO, M.CODCAU, M.NUM_APOL_SINISTRO, M.NRCERTIF, M.IDTPSEGU, SUM(H.VAL_OPERACAO) FROM SEGUROS.V1MESTSINI M, SEGUROS.V1HISTSINI H WHERE M.NUM_APOLICE = :RELSIN-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NRCERTIF <> 0 AND H.OPERACAO = 101 AND H.DTMOVTO BETWEEN :WDATA-INI AND :WDATA-FIM AND H.SITUACAO IN ( '1' , '0' ) GROUP BY M.CODSUBES, M.FONTE, M.RAMO, M.CODCAU, M.NUM_APOL_SINISTRO, M.NRCERTIF, M.IDTPSEGU ORDER BY M.CODSUBES, M.FONTE, M.RAMO, M.CODCAU, M.NUM_APOL_SINISTRO, M.NRCERTIF, M.IDTPSEGU END-EXEC. */
            TMESTSIN = new SI0812B_TMESTSIN(true);
            string GetQuery_TMESTSIN()
            {
                var query = @$"SELECT M.CODSUBES
							, 
							M.FONTE
							, 
							M.RAMO
							, 
							M.CODCAU
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NRCERTIF
							, 
							M.IDTPSEGU
							, 
							SUM(H.VAL_OPERACAO) 
							FROM SEGUROS.V1MESTSINI M
							, 
							SEGUROS.V1HISTSINI H 
							WHERE 
							M.NUM_APOLICE = '{RELSIN_APOLICE}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND M.NRCERTIF <> 0 
							AND H.OPERACAO = 101 
							AND H.DTMOVTO BETWEEN '{WDATA_INI}' 
							AND '{WDATA_FIM}' 
							AND H.SITUACAO IN ( '1'
							, '0' ) 
							GROUP BY M.CODSUBES
							, 
							M.FONTE
							, 
							M.RAMO
							, 
							M.CODCAU
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NRCERTIF
							, 
							M.IDTPSEGU 
							ORDER BY M.CODSUBES
							, 
							M.FONTE
							, 
							M.RAMO
							, 
							M.CODCAU
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NRCERTIF
							, 
							M.IDTPSEGU";

                return query;
            }
            TMESTSIN.GetQueryEvent += GetQuery_TMESTSIN;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_999_EXIT*/

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-SECTION */
        private void M_540_000_LER_TRELSIN_SECTION()
        {
            /*" -1057- MOVE '540-000-LER-TRELSIN' TO PARAGRAFO. */
            _.Move("540-000-LER-TRELSIN", W.MESES.WABEND.PARAGRAFO);

            /*" -1059- MOVE '540' TO WNR-EXEC-SQL. */
            _.Move("540", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1063- PERFORM M_540_000_LER_TRELSIN_DB_FETCH_1 */

            M_540_000_LER_TRELSIN_DB_FETCH_1();

            /*" -1066- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1066- PERFORM M_540_000_LER_TRELSIN_DB_CLOSE_1 */

                M_540_000_LER_TRELSIN_DB_CLOSE_1();

                /*" -1068- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -1069- ELSE */
            }
            else
            {


                /*" -1069- ADD 1 TO AC-LID-TRELSIN. */
                W.AC_LID_TRELSIN.Value = W.AC_LID_TRELSIN + 1;
            }


        }

        [StopWatch]
        /*" M-540-000-LER-TRELSIN-DB-FETCH-1 */
        public void M_540_000_LER_TRELSIN_DB_FETCH_1()
        {
            /*" -1063- EXEC SQL FETCH V1RELATSINI INTO :RELSIN-APOLICE, :RELSIN-ANO-REF, :RELSIN-MES-REF END-EXEC. */

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
            /*" -1066- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_540_999_EXIT*/

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-SECTION */
        private void M_550_000_CURSOR_TMESTSIN_SECTION()
        {
            /*" -1087- MOVE '550-000-CURSOR-TMESTSIN' TO PARAGRAFO. */
            _.Move("550-000-CURSOR-TMESTSIN", W.MESES.WABEND.PARAGRAFO);

            /*" -1089- MOVE '550' TO WNR-EXEC-SQL. */
            _.Move("550", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1124- PERFORM M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1 */

            M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1();

            /*" -1125- PERFORM M_550_000_CURSOR_TMESTSIN_DB_OPEN_1 */

            M_550_000_CURSOR_TMESTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-550-000-CURSOR-TMESTSIN-DB-OPEN-1 */
        public void M_550_000_CURSOR_TMESTSIN_DB_OPEN_1()
        {
            /*" -1125- EXEC SQL OPEN TMESTSIN END-EXEC. */

            TMESTSIN.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_999_EXIT*/

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-SECTION */
        private void M_560_000_LER_TMESTSIN_SECTION()
        {
            /*" -1141- MOVE '560-000-LER-TMESTSIN' TO PARAGRAFO. */
            _.Move("560-000-LER-TMESTSIN", W.MESES.WABEND.PARAGRAFO);

            /*" -1143- MOVE '560' TO WNR-EXEC-SQL. */
            _.Move("560", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1145- MOVE +0 TO WSN-VRAVISADO. */
            _.Move(+0, W.WSN_VRAVISADO);

            /*" -1154- PERFORM M_560_000_LER_TMESTSIN_DB_FETCH_1 */

            M_560_000_LER_TMESTSIN_DB_FETCH_1();

            /*" -1157- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1157- PERFORM M_560_000_LER_TMESTSIN_DB_CLOSE_1 */

                M_560_000_LER_TMESTSIN_DB_CLOSE_1();

                /*" -1159- MOVE 'S' TO WFIM-TMESTSIN */
                _.Move("S", W.WFIM_TMESTSIN);

                /*" -1160- ELSE */
            }
            else
            {


                /*" -1161- MOVE HIST-VALPRI TO WSN-VRAVISADO */
                _.Move(HIST_VALPRI, W.WSN_VRAVISADO);

                /*" -1161- ADD 1 TO AC-LID-MESTHIST. */
                W.AC_LID_MESTHIST.Value = W.AC_LID_MESTHIST + 1;
            }


        }

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-DB-FETCH-1 */
        public void M_560_000_LER_TMESTSIN_DB_FETCH_1()
        {
            /*" -1154- EXEC SQL FETCH TMESTSIN INTO :MEST-CODSUBES, :MEST-FONTE, :MEST-RAMO, :MEST-CODCAU, :MEST-APOL-SINI, :MEST-NRCERTIF, :MEST-IDTPSEGU, :HIST-VALPRI END-EXEC. */

            if (TMESTSIN.Fetch())
            {
                _.Move(TMESTSIN.MEST_CODSUBES, MEST_CODSUBES);
                _.Move(TMESTSIN.MEST_FONTE, MEST_FONTE);
                _.Move(TMESTSIN.MEST_RAMO, MEST_RAMO);
                _.Move(TMESTSIN.MEST_CODCAU, MEST_CODCAU);
                _.Move(TMESTSIN.MEST_APOL_SINI, MEST_APOL_SINI);
                _.Move(TMESTSIN.MEST_NRCERTIF, MEST_NRCERTIF);
                _.Move(TMESTSIN.MEST_IDTPSEGU, MEST_IDTPSEGU);
                _.Move(TMESTSIN.HIST_VALPRI, HIST_VALPRI);
            }

        }

        [StopWatch]
        /*" M-560-000-LER-TMESTSIN-DB-CLOSE-1 */
        public void M_560_000_LER_TMESTSIN_DB_CLOSE_1()
        {
            /*" -1157- EXEC SQL CLOSE TMESTSIN END-EXEC */

            TMESTSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_560_999_EXIT*/

        [StopWatch]
        /*" M-570-000-LER-SUBGRUPO-SECTION */
        private void M_570_000_LER_SUBGRUPO_SECTION()
        {
            /*" -1176- MOVE '570-000-LER-SUBGRUPO' TO PARAGRAFO. */
            _.Move("570-000-LER-SUBGRUPO", W.MESES.WABEND.PARAGRAFO);

            /*" -1178- MOVE '570' TO WNR-EXEC-SQL. */
            _.Move("570", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1184- PERFORM M_570_000_LER_SUBGRUPO_DB_SELECT_1 */

            M_570_000_LER_SUBGRUPO_DB_SELECT_1();

            /*" -1187- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1188- MOVE +0 TO CLIE-COD-CLIENTE */
                _.Move(+0, CLIE_COD_CLIENTE);

                /*" -1189- DISPLAY 'SI0812B- NAO EXISTE REGISTRO NA TSUBGRUPO' */
                _.Display($"SI0812B- NAO EXISTE REGISTRO NA TSUBGRUPO");

                /*" -1190- DISPLAY 'NUM-APOLICE = ' RELSIN-APOLICE */
                _.Display($"NUM-APOLICE = {RELSIN_APOLICE}");

                /*" -1191- DISPLAY 'COD-SUBGRUPO= ' MEST-CODSUBES */
                _.Display($"COD-SUBGRUPO= {MEST_CODSUBES}");

                /*" -1192- ELSE */
            }
            else
            {


                /*" -1192- MOVE SUBG-COD-CLIENTE TO CLIE-COD-CLIENTE. */
                _.Move(SUBG_COD_CLIENTE, CLIE_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-570-000-LER-SUBGRUPO-DB-SELECT-1 */
        public void M_570_000_LER_SUBGRUPO_DB_SELECT_1()
        {
            /*" -1184- EXEC SQL SELECT COD_CLIENTE INTO :SUBG-COD-CLIENTE FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :RELSIN-APOLICE AND COD_SUBGRUPO = :MEST-CODSUBES END-EXEC. */

            var m_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1 = new M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1()
            {
                RELSIN_APOLICE = RELSIN_APOLICE.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
            };

            var executed_1 = M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1.Execute(m_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBG_COD_CLIENTE, SUBG_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_570_999_EXIT*/

        [StopWatch]
        /*" M-571-000-LER-SEGURAVG-SECTION */
        private void M_571_000_LER_SEGURAVG_SECTION()
        {
            /*" -1208- MOVE '571-000-LER-SEGURAVG' TO PARAGRAFO. */
            _.Move("571-000-LER-SEGURAVG", W.MESES.WABEND.PARAGRAFO);

            /*" -1210- MOVE '571' TO WNR-EXEC-SQL. */
            _.Move("571", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1220- PERFORM M_571_000_LER_SEGURAVG_DB_SELECT_1 */

            M_571_000_LER_SEGURAVG_DB_SELECT_1();

            /*" -1223- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1224- MOVE +0 TO CLIE-COD-CLIENTE */
                _.Move(+0, CLIE_COD_CLIENTE);

                /*" -1225- MOVE ZEROS TO LD01-COD-AGENC */
                _.Move(0, W.LD01.LD01_COD_AGENC);

                /*" -1226- DISPLAY 'SI0812B- NAO EXISTE REGISTRO NA SEGURAVG' */
                _.Display($"SI0812B- NAO EXISTE REGISTRO NA SEGURAVG");

                /*" -1227- DISPLAY 'NUM-APOLICE = ' RELSIN-APOLICE */
                _.Display($"NUM-APOLICE = {RELSIN_APOLICE}");

                /*" -1228- DISPLAY 'COD-SUBGRUPO= ' MEST-CODSUBES */
                _.Display($"COD-SUBGRUPO= {MEST_CODSUBES}");

                /*" -1229- DISPLAY 'NUM-CERTIFICADO= ' MEST-NRCERTIF */
                _.Display($"NUM-CERTIFICADO= {MEST_NRCERTIF}");

                /*" -1230- DISPLAY 'TIPO-SEGURADO= ' MEST-IDTPSEGU */
                _.Display($"TIPO-SEGURADO= {MEST_IDTPSEGU}");

                /*" -1231- ELSE */
            }
            else
            {


                /*" -1232- MOVE SEGU-COD-CLIENTE TO CLIE-COD-CLIENTE */
                _.Move(SEGU_COD_CLIENTE, CLIE_COD_CLIENTE);

                /*" -1232- MOVE SEGU-COD-AGENCIADOR TO LD01-COD-AGENC. */
                _.Move(SEGU_COD_AGENCIADOR, W.LD01.LD01_COD_AGENC);
            }


        }

        [StopWatch]
        /*" M-571-000-LER-SEGURAVG-DB-SELECT-1 */
        public void M_571_000_LER_SEGURAVG_DB_SELECT_1()
        {
            /*" -1220- EXEC SQL SELECT COD_CLIENTE, COD_AGENCIADOR INTO :SEGU-COD-CLIENTE, :SEGU-COD-AGENCIADOR FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :RELSIN-APOLICE AND COD_SUBGRUPO = :MEST-CODSUBES AND NUM_CERTIFICADO = :MEST-NRCERTIF END-EXEC. */

            var m_571_000_LER_SEGURAVG_DB_SELECT_1_Query1 = new M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1()
            {
                RELSIN_APOLICE = RELSIN_APOLICE.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
                MEST_NRCERTIF = MEST_NRCERTIF.ToString(),
            };

            var executed_1 = M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1.Execute(m_571_000_LER_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGU_COD_CLIENTE, SEGU_COD_CLIENTE);
                _.Move(executed_1.SEGU_COD_AGENCIADOR, SEGU_COD_AGENCIADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_571_999_EXIT*/

        [StopWatch]
        /*" M-572-000-LER-TCLIENTE-SECTION */
        private void M_572_000_LER_TCLIENTE_SECTION()
        {
            /*" -1249- MOVE '572-000-LER-TCLIENTE' TO PARAGRAFO. */
            _.Move("572-000-LER-TCLIENTE", W.MESES.WABEND.PARAGRAFO);

            /*" -1251- MOVE '572' TO WNR-EXEC-SQL. */
            _.Move("572", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1253- MOVE SPACES TO CLIE-NOME-RAZAO */
            _.Move("", CLIE_NOME_RAZAO);

            /*" -1258- PERFORM M_572_000_LER_TCLIENTE_DB_SELECT_1 */

            M_572_000_LER_TCLIENTE_DB_SELECT_1();

            /*" -1261- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1262- MOVE SPACES TO CLIE-NOME-RAZAO */
                _.Move("", CLIE_NOME_RAZAO);

                /*" -1263- DISPLAY 'SI0812B- NAO EXISTE REGISTRO NA TCLIENTE' */
                _.Display($"SI0812B- NAO EXISTE REGISTRO NA TCLIENTE");

                /*" -1263- DISPLAY 'COD-CLIENTE = ' CLIE-COD-CLIENTE. */
                _.Display($"COD-CLIENTE = {CLIE_COD_CLIENTE}");
            }


        }

        [StopWatch]
        /*" M-572-000-LER-TCLIENTE-DB-SELECT-1 */
        public void M_572_000_LER_TCLIENTE_DB_SELECT_1()
        {
            /*" -1258- EXEC SQL SELECT NOME_RAZAO INTO :CLIE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :CLIE-COD-CLIENTE END-EXEC. */

            var m_572_000_LER_TCLIENTE_DB_SELECT_1_Query1 = new M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1()
            {
                CLIE_COD_CLIENTE = CLIE_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1.Execute(m_572_000_LER_TCLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_NOME_RAZAO, CLIE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_572_999_EXIT*/

        [StopWatch]
        /*" M-575-000-LER-TFONTE-SECTION */
        private void M_575_000_LER_TFONTE_SECTION()
        {
            /*" -1279- MOVE '575-000-LER-TFONTE' TO PARAGRAFO. */
            _.Move("575-000-LER-TFONTE", W.MESES.WABEND.PARAGRAFO);

            /*" -1281- MOVE '575' TO WNR-EXEC-SQL. */
            _.Move("575", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1283- MOVE SPACES TO TFONTE-NOMEFTE */
            _.Move("", TFONTE_NOMEFTE);

            /*" -1288- PERFORM M_575_000_LER_TFONTE_DB_SELECT_1 */

            M_575_000_LER_TFONTE_DB_SELECT_1();

            /*" -1291- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1292- MOVE SPACES TO TFONTE-NOMEFTE */
                _.Move("", TFONTE_NOMEFTE);

                /*" -1293- DISPLAY 'SI0812B - NAO EXISTE REGISTRO NA TFONTE' */
                _.Display($"SI0812B - NAO EXISTE REGISTRO NA TFONTE");

                /*" -1293- DISPLAY '          FONTE = ' MEST-FONTE. */
                _.Display($"          FONTE = {MEST_FONTE}");
            }


        }

        [StopWatch]
        /*" M-575-000-LER-TFONTE-DB-SELECT-1 */
        public void M_575_000_LER_TFONTE_DB_SELECT_1()
        {
            /*" -1288- EXEC SQL SELECT NOMEFTE INTO :TFONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :MEST-FONTE END-EXEC. */

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
            /*" -1309- MOVE '580-000-LER-TAPOLICE' TO PARAGRAFO. */
            _.Move("580-000-LER-TAPOLICE", W.MESES.WABEND.PARAGRAFO);

            /*" -1311- MOVE '580' TO WNR-EXEC-SQL. */
            _.Move("580", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1313- MOVE SPACES TO APOL-NOME */
            _.Move("", APOL_NOME);

            /*" -1318- PERFORM M_580_000_LER_TAPOLICE_DB_SELECT_1 */

            M_580_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -1321- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1322- DISPLAY 'SI0812B - NAO EXISTE REGISTRO NA TAPOLICE' */
                _.Display($"SI0812B - NAO EXISTE REGISTRO NA TAPOLICE");

                /*" -1322- DISPLAY '          APOLICE  = ' RELSIN-APOLICE. */
                _.Display($"          APOLICE  = {RELSIN_APOLICE}");
            }


        }

        [StopWatch]
        /*" M-580-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_580_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -1318- EXEC SQL SELECT NOME INTO :APOL-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :RELSIN-APOLICE END-EXEC. */

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
        /*" M-585-000-LER-SINICAU-SECTION */
        private void M_585_000_LER_SINICAU_SECTION()
        {
            /*" -1338- MOVE '585-000-LER-SINICAU' TO PARAGRAFO. */
            _.Move("585-000-LER-SINICAU", W.MESES.WABEND.PARAGRAFO);

            /*" -1340- MOVE '585' TO WNR-EXEC-SQL. */
            _.Move("585", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1342- MOVE SPACES TO SINICAU-DESCAU */
            _.Move("", SINICAU_DESCAU);

            /*" -1348- PERFORM M_585_000_LER_SINICAU_DB_SELECT_1 */

            M_585_000_LER_SINICAU_DB_SELECT_1();

            /*" -1351- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1352- MOVE SPACES TO SINICAU-DESCAU */
                _.Move("", SINICAU_DESCAU);

                /*" -1353- DISPLAY 'SI0812B - NAO EXISTE REGISTRO NA SINICAUSA' */
                _.Display($"SI0812B - NAO EXISTE REGISTRO NA SINICAUSA");

                /*" -1354- DISPLAY '          RAMO   = ' MEST-RAMO */
                _.Display($"          RAMO   = {MEST_RAMO}");

                /*" -1354- DISPLAY '          CODCAU = ' MEST-CODCAU. */
                _.Display($"          CODCAU = {MEST_CODCAU}");
            }


        }

        [StopWatch]
        /*" M-585-000-LER-SINICAU-DB-SELECT-1 */
        public void M_585_000_LER_SINICAU_DB_SELECT_1()
        {
            /*" -1348- EXEC SQL SELECT DESCAU INTO :SINICAU-DESCAU FROM SEGUROS.V1SINICAUSA WHERE RAMO = :MEST-RAMO AND CODCAU = :MEST-CODCAU END-EXEC. */

            var m_585_000_LER_SINICAU_DB_SELECT_1_Query1 = new M_585_000_LER_SINICAU_DB_SELECT_1_Query1()
            {
                MEST_CODCAU = MEST_CODCAU.ToString(),
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_585_000_LER_SINICAU_DB_SELECT_1_Query1.Execute(m_585_000_LER_SINICAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINICAU_DESCAU, SINICAU_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_585_999_EXIT*/

        [StopWatch]
        /*" M-590-000-ATUALIZA-TRELSIN-SECTION */
        private void M_590_000_ATUALIZA_TRELSIN_SECTION()
        {
            /*" -1372- MOVE '590-000-ATUALIZA-TRELSIN' TO PARAGRAFO. */
            _.Move("590-000-ATUALIZA-TRELSIN", W.MESES.WABEND.PARAGRAFO);

            /*" -1374- MOVE '590' TO WNR-EXEC-SQL. */
            _.Move("590", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1380- PERFORM M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1 */

            M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-590-000-ATUALIZA-TRELSIN-DB-DELETE-1 */
        public void M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1()
        {
            /*" -1380- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0812B' AND DATA_SOLICITACAO = :SIST-DTMOVABE END-EXEC. */

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
            /*" -1398- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.MESES.WABEND.PARAGRAFO);

            /*" -1400- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.MESES.WABEND.WNR_EXEC_SQL);

            /*" -1402- CLOSE SI0812M1. */
            SI0812M1.Close();

            /*" -1403- DISPLAY 'SI0812B.................   *** FIM NORMAL ***' . */
            _.Display($"SI0812B.................   *** FIM NORMAL ***");

            /*" -1404- DISPLAY 'DATA PROCESSADA......... ' SIST-DTMOVABE */
            _.Display($"DATA PROCESSADA......... {SIST_DTMOVABE}");

            /*" -1405- DISPLAY 'LIDOS RELATORIOS........ ' AC-LID-TRELSIN */
            _.Display($"LIDOS RELATORIOS........ {W.AC_LID_TRELSIN}");

            /*" -1406- DISPLAY 'LIDOS MESTSINI/HISTSINI. ' AC-LID-MESTHIST */
            _.Display($"LIDOS MESTSINI/HISTSINI. {W.AC_LID_MESTHIST}");

            /*" -1408- DISPLAY 'TOTAL IMPRESSOS EMISSAO. ' AC-IMPRE */
            _.Display($"TOTAL IMPRESSOS EMISSAO. {W.AC_IMPRE}");

            /*" -1408- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1421- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1422- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.MESES.WABEND.WSQLCODE);

                /*" -1423- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.MESES.WABEND.WSQLCODE1);

                /*" -1424- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.MESES.WABEND.WSQLCODE2);

                /*" -1425- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1427- DISPLAY WABEND. */
            _.Display(W.MESES.WABEND);

            /*" -1428- CLOSE SI0812M1. */
            SI0812M1.Close();

            /*" -1428- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1429- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1431- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1431- GOBACK. */

            throw new GoBack();

        }
    }
}