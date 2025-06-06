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
using Sias.Sinistro.DB2.SI0112B;

namespace Code
{
    public class SI0112B
    {
        public bool IsCall { get; set; }

        public SI0112B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * SISTEMA              =    SINISTRO.                         //      */
        /*"      * PROGRAMA             =    SI0112B.                          //      */
        /*"      * OBJETIVO             =    EMITE CARTA DE SINISTRO           //      */
        /*"      *                           DE COSSEGURO.                     //      */
        /*"      *                           EMISSAO VIA SOLICITACAO           //      */
        /*"      * ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    //      */
        /*"      * DATA                 =    AGOSTO / 92.                      //      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * 24/09/2018 - CADMUS 168975 - LISIANE BRAGANCA SOARES           *      */
        /*"      *              MUDANCA NA PLACA DO VEICULO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR JO0800)                                          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0112M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0112M1
        {
            get
            {
                _.Move(REG_SI0112M1, _SI0112M1); VarBasis.RedefinePassValue(REG_SI0112M1, _SI0112M1, REG_SI0112M1); return _SI0112M1;
            }
        }
        /*"01  REG-SI0112M1.*/
        public SI0112B_REG_SI0112M1 REG_SI0112M1 { get; set; } = new SI0112B_REG_SI0112M1();
        public class SI0112B_REG_SI0112M1 : VarBasis
        {
            /*"    05          LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EMPRESA-MNUEMP       PIC  X(040).*/
        public StringBasis V1EMPRESA_MNUEMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          V1EMPRESA-DTCURRENT    PIC  X(010).*/
        public StringBasis V1EMPRESA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-NUM-APOL          PIC S9(013)       COMP-3.*/
        public IntBasis MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-NRENDOS           PIC S9(009)       COMP.*/
        public IntBasis MEST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           MEST-APOL-SINI         PIC S9(013)       COMP-3.*/
        public IntBasis MEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-DATCMD            PIC  X(010).*/
        public StringBasis MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-DATORR            PIC  X(010).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-NRCERTIF          PIC S9(015)       COMP-3.*/
        public IntBasis MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77           MEST-NRITEM            PIC S9(009)       COMP.*/
        public IntBasis MEST_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           MEST-PCPARTIC          PIC S9(004)V9(5)  COMP-3.*/
        public DoubleBasis MEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77           MEST-MOEDA-SINI        PIC S9(004)       COMP.*/
        public IntBasis MEST_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-IDTPSEGU          PIC  X(001).*/
        public StringBasis MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           MEST-NUMIRB            PIC S9(011)       COMP-3.*/
        public IntBasis MEST_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77           MEST-CODSUBES          PIC S9(004)       COMP.*/
        public IntBasis MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-NREMBARQ          PIC S9(009)       COMP.*/
        public IntBasis MEST_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           MEST-REFEMBQ           PIC S9(004)       COMP.*/
        public IntBasis MEST_REFEMBQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-VALSEGBT          PIC S9(013)V9(2)  COMP-3.*/
        public DoubleBasis MEST_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77           V1RELA-NUMSINI         PIC S9(013)       COMP-3.*/
        public IntBasis V1RELA_NUMSINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           V1RELA-CONGE           PIC S9(004)       COMP.*/
        public IntBasis V1RELA_CONGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1RELA-OPERACAO        PIC S9(004)       COMP.*/
        public IntBasis V1RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1RELA-OCORHIST        PIC S9(004)       COMP.*/
        public IntBasis V1RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1RELA-DTMOVTO         PIC  X(010).*/
        public StringBasis V1RELA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           APCOSSC-PCPARTIC       PIC S9(004)V9(5) COMP-3.*/
        public DoubleBasis APCOSSC_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77           APCOSSC-DTINIVIG       PIC  X(010).*/
        public StringBasis APCOSSC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           ORDEM-NRORDEM          PIC S9(015)      COMP-3.*/
        public IntBasis ORDEM_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77           ENDOS-DTINIVIG         PIC  X(010).*/
        public StringBasis ENDOS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           ENDOS-DTTERVIG         PIC  X(010).*/
        public StringBasis ENDOS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           ENDOS-CORRECAO         PIC  X(001).*/
        public StringBasis ENDOS_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           APVEI-CDVEICL          PIC S9(004)   COMP.*/
        public IntBasis APVEI_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APVEI-PLACAUF          PIC  X(002).*/
        public StringBasis APVEI_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77           APVEI-PLACALET         PIC  X(003).*/
        public StringBasis APVEI_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77           APVEI-PLACANR          PIC  X(004).*/
        public StringBasis APVEI_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77           APVEI-CHASSIS          PIC  X(020).*/
        public StringBasis APVEI_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77           APVEI-ANOVEICL         PIC S9(004)   COMP.*/
        public IntBasis APVEI_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APVEI-TIPOVEIC         PIC S9(004)   COMP.*/
        public IntBasis APVEI_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APVEI-FABRICAN         PIC S9(004)   COMP.*/
        public IntBasis APVEI_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           DESCR-DESCVEIC         PIC  X(040).*/
        public StringBasis DESCR_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           AVBNA-NRAVERB          PIC S9(004)   COMP.*/
        public IntBasis AVBNA_NRAVERB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           AVBNA-PREFIXO          PIC  X(010).*/
        public StringBasis AVBNA_PREFIXO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           AVBNA-NREMBARQ         PIC S9(009)   COMP.*/
        public IntBasis AVBNA_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           AVBNA-MARCMERC         PIC  X(010).*/
        public StringBasis AVBNA_MARCMERC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           AVBNA-LOCALINI         PIC  X(002).*/
        public StringBasis AVBNA_LOCALINI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77           AVBNA-LOCALDES         PIC  X(002).*/
        public StringBasis AVBNA_LOCALDES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77           AVBIN-NRAVERB          PIC S9(004)   COMP.*/
        public IntBasis AVBIN_NRAVERB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           AVBIN-PREFIXO          PIC  X(010).*/
        public StringBasis AVBIN_PREFIXO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           AVBIN-DESCMERC         PIC  X(080).*/
        public StringBasis AVBIN_DESCMERC { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"77           AVBIN-PAISINI          PIC  X(015).*/
        public StringBasis AVBIN_PAISINI { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77           AVBIN-PAISDEST         PIC  X(015).*/
        public StringBasis AVBIN_PAISDEST { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77           V1CONGE-NOMECONG       PIC  X(040).*/
        public StringBasis V1CONGE_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SEGVG-COD-CLIENTE      PIC S9(009)      COMP.*/
        public IntBasis SEGVG_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           SEGVG-DTNASCIM         PIC  X(010).*/
        public StringBasis SEGVG_DTNASCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1COND-GARAN-IEA       PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1COND-GARAN-IPA       PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1COND-GARAN-IPD       PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1COND-GARAN-HD        PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_HD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1RAMO-NOMERAMO        PIC  X(040).*/
        public StringBasis V1RAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1RAMO-RAMO            PIC S9(004)      COMP.*/
        public IntBasis V1RAMO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APOL-NOME              PIC  X(040).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           APOL-CODCLIEN          PIC S9(006)      COMP.*/
        public IntBasis APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
        /*"77           APOL-MODALIDA          PIC S9(004)      COMP.*/
        public IntBasis APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APOL-PODPUBL           PIC  X(001).*/
        public StringBasis APOL_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           THIST-OPERACAO         PIC S9(004)       COMP.*/
        public IntBasis THIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-VAL-OPERACAO     PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-OCORHIST         PIC S9(004)       COMP.*/
        public IntBasis THIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-DTMOVTO          PIC  X(010).*/
        public StringBasis THIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           THIST-NOMFAV           PIC  X(040).*/
        public StringBasis THIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           MOEDA-VLCRUZAD         PIC S9(006)V9(09) COMP-3.*/
        public DoubleBasis MOEDA_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
        /*"77           MOEDA-SIGLUNIM         PIC  X(006).*/
        public StringBasis MOEDA_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77           APITE-DESCRITEM        PIC  X(080).*/
        public StringBasis APITE_DESCRITEM { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"77           CLIEN-NOME             PIC  X(040).*/
        public StringBasis CLIEN_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01              W.*/
        public SI0112B_W W { get; set; } = new SI0112B_W();
        public class SI0112B_W : VarBasis
        {
            /*"  03            LCB.*/
            public SI0112B_LCB LCB { get; set; } = new SI0112B_LCB();
            public class SI0112B_LCB : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03            LC00.*/
            }
            public SI0112B_LC00 LC00 { get; set; } = new SI0112B_LC00();
            public class SI0112B_LC00 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(130) VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC01.*/
            }
            public SI0112B_LC01 LC01 { get; set; } = new SI0112B_LC01();
            public class SI0112B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO      PIC  X(007) VALUE 'SI0112B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0112B");
                /*"    05          FILLER              PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    05          LC01-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG            PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0112B_LC02 LC02 { get; set; } = new SI0112B_LC02();
            public class SI0112B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(060) VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05          FILLER              PIC  X(057) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0112B_LC03 LC03 { get; set; } = new SI0112B_LC03();
            public class SI0112B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(048) VALUE  SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    05          FILLER              PIC  X(030) VALUE               'CARTA DE SINISTRO DE COSSEGURO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CARTA DE SINISTRO DE COSSEGURO");
                /*"    05          FILLER              PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04.*/
            }
            public SI0112B_LC04 LC04 { get; set; } = new SI0112B_LC04();
            public class SI0112B_LC04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE               'A CIA.'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"A CIA.");
                /*"    05          FILLER              PIC  X(125) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "125", "X(125)"), @"");
                /*"  03            LC05.*/
            }
            public SI0112B_LC05 LC05 { get; set; } = new SI0112B_LC05();
            public class SI0112B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC05-CODCOSS        PIC  9(004).*/
                public IntBasis LC05_CODCOSS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC05-NOMECONG       PIC  X(046) VALUE SPACES.*/
                public StringBasis LC05_NOMECONG { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          FILLER              PIC  X(079) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "79", "X(079)"), @"");
                /*"  03            LC06.*/
            }
            public SI0112B_LC06 LC06 { get; set; } = new SI0112B_LC06();
            public class SI0112B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE                                               'REFERENTE  '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"REFERENTE  ");
                /*"    05          LC06-REFER          PIC  X(045) VALUE SPACES.*/
                public StringBasis LC06_REFER { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                /*"    05          FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                                   'SINISTRO LIDER  '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SINISTRO LIDER  ");
                /*"    05          LC06-SINISTRO       PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC06_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"  03            LC07.*/
            }
            public SI0112B_LC07 LC07 { get; set; } = new SI0112B_LC07();
            public class SI0112B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(049) VALUE ALL '-'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(024) VALUE                                   'D A D O S    G E R A I S'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"D A D O S    G E R A I S");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(049) VALUE ALL '-'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC08.*/
            }
            public SI0112B_LC08 LC08 { get; set; } = new SI0112B_LC08();
            public class SI0112B_LC08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE 'SEGURADO'*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SEGURADO");
                /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE 'RAMO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    05          FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"    05          FILLER              PIC  X(017) VALUE                                   'PERC.PARTICIPACAO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PERC.PARTICIPACAO");
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE                                   'DATA SINISTRO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA SINISTRO");
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                                   'DATA AVISO'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA AVISO");
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC09.*/
            }
            public SI0112B_LC09 LC09 { get; set; } = new SI0112B_LC09();
            public class SI0112B_LC09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC09-NOME           PIC  X(040) VALUE SPACES.*/
                public StringBasis LC09_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC09-NOMERAMO       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC09_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          LC09-PCPARTIC       PIC  ZZ9,99999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LC09_PCPARTIC { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99999"), 5);
                /*"    05          FILLER              PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05          LC09-DTSINI.*/
                public SI0112B_LC09_DTSINI LC09_DTSINI { get; set; } = new SI0112B_LC09_DTSINI();
                public class SI0112B_LC09_DTSINI : VarBasis
                {
                    /*"      07        LC09-DD-SINI        PIC  9(002).*/
                    public IntBasis LC09_DD_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-MM-SINI        PIC  9(002).*/
                    public IntBasis LC09_MM_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-AA-SINI        PIC  9(004).*/
                    public IntBasis LC09_AA_SINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                }
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC09-DTAVISO.*/
                public SI0112B_LC09_DTAVISO LC09_DTAVISO { get; set; } = new SI0112B_LC09_DTAVISO();
                public class SI0112B_LC09_DTAVISO : VarBasis
                {
                    /*"      07        LC09-DD-AVISO       PIC  9(002).*/
                    public IntBasis LC09_DD_AVISO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-MM-AVISO       PIC  9(002).*/
                    public IntBasis LC09_MM_AVISO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-AA-AVISO       PIC  9(004).*/
                    public IntBasis LC09_AA_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC10.*/
            }
            public SI0112B_LC10 LC10 { get; set; } = new SI0112B_LC10();
            public class SI0112B_LC10 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE                                   'APOLICE'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"APOLICE");
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                   'NUMERO DE ORDEM'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NUMERO DE ORDEM");
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'MOEDA'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"MOEDA");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                   'V I G E N C I A'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"V I G E N C I A");
                /*"    05          FILLER              PIC  X(012) VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE 'ITEM'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"ITEM");
                /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'IS ITEM'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"IS ITEM");
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC11.*/
            }
            public SI0112B_LC11 LC11 { get; set; } = new SI0112B_LC11();
            public class SI0112B_LC11 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC11-APOLICE        PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC11_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC11-NRORDEM        PIC  9(015) BLANK WHEN ZERO.*/
                public IntBasis LC11_NRORDEM { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          LC11-SIGLUNIM       PIC  X(006) VALUE SPACES.*/
                public StringBasis LC11_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC11-DTINIVIG.*/
                public SI0112B_LC11_DTINIVIG LC11_DTINIVIG { get; set; } = new SI0112B_LC11_DTINIVIG();
                public class SI0112B_LC11_DTINIVIG : VarBasis
                {
                    /*"      07        LC11-DD-I           PIC  9(002).*/
                    public IntBasis LC11_DD_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-MM-I           PIC  9(002).*/
                    public IntBasis LC11_MM_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-AA-I           PIC  9(004).*/
                    public IntBasis LC11_AA_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(003) VALUE ' A '.*/
                }
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    05          LC11-DTTERVIG.*/
                public SI0112B_LC11_DTTERVIG LC11_DTTERVIG { get; set; } = new SI0112B_LC11_DTTERVIG();
                public class SI0112B_LC11_DTTERVIG : VarBasis
                {
                    /*"      07        LC11-DD-T           PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LC11_DD_T { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-MM-T           PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LC11_MM_T { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-AA-T           PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LC11_AA_T { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(008) VALUE SPACES.*/
                }
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05          LC11-ITEM           PIC  9(015) VALUE ZEROS.*/
                public IntBasis LC11_ITEM { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC11-IDTPSEGU       PIC  X(001) VALUE ZEROS.*/
                public StringBasis LC11_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05          LC11-ISITEM         PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99                                    BLANK WHEN ZERO.*/
                public DoubleBasis LC11_ISITEM { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC12.*/
            }
            public SI0112B_LC12 LC12 { get; set; } = new SI0112B_LC12();
            public class SI0112B_LC12 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                'FAVORECIDO'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FAVORECIDO");
                /*"    05          FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE                'SINISTRO IRB'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"SINISTRO IRB");
                /*"    05          FILLER              PIC  X(061) VALUE SPACES.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC13.*/
            }
            public SI0112B_LC13 LC13 { get; set; } = new SI0112B_LC13();
            public class SI0112B_LC13 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC13-NOMFAV         PIC  X(030) VALUE SPACES.*/
                public StringBasis LC13_NOMFAV { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          LC13-SINIRB         PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC13_SINIRB { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(060) VALUE SPACES.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC14.*/
            }
            public SI0112B_LC14 LC14 { get; set; } = new SI0112B_LC14();
            public class SI0112B_LC14 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(026) VALUE                                   'DADOS ESPECIFICOS AUTO/RCF'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"DADOS ESPECIFICOS AUTO/RCF");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC15.*/
            }
            public SI0112B_LC15 LC15 { get; set; } = new SI0112B_LC15();
            public class SI0112B_LC15 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'MARCA'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"MARCA");
                /*"    05          FILLER              PIC  X(051) VALUE SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'PLACA'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PLACA");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'CHASSIS'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CHASSIS");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(014) VALUE                                   'ANO FABRICACAO'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"ANO FABRICACAO");
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC16.*/
            }
            public SI0112B_LC16 LC16 { get; set; } = new SI0112B_LC16();
            public class SI0112B_LC16 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC16-DESCVEIC       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC16_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    05          LC16-PLACA.*/
                public SI0112B_LC16_PLACA LC16_PLACA { get; set; } = new SI0112B_LC16_PLACA();
                public class SI0112B_LC16_PLACA : VarBasis
                {
                    /*"      07        LC16-PLACALET       PIC  X(003) VALUE SPACES.*/
                    public StringBasis LC16_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      07        FILLER              PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LC16-PLACANR        PIC  X(004) VALUE SPACES.*/
                    public StringBasis LC16_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                }
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LC16-CHASSIS        PIC  X(022) VALUE SPACES.*/
                public StringBasis LC16_CHASSIS { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          LC16-ANOVEICL       PIC  9(004) BLANK WHEN ZERO.*/
                public IntBasis LC16_ANOVEICL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC17.*/
            }
            public SI0112B_LC17 LC17 { get; set; } = new SI0112B_LC17();
            public class SI0112B_LC17 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(041) VALUE ALL '-'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(039) VALUE                'DADOS ESPECIFICOS INC / LC / RD / R.ENG'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"DADOS ESPECIFICOS INC / LC / RD / R.ENG");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(042) VALUE ALL '-'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC18.*/
            }
            public SI0112B_LC18 LC18 { get; set; } = new SI0112B_LC18();
            public class SI0112B_LC18 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                'LOCAL OCORRENCIA'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"LOCAL OCORRENCIA");
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE SPACES.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC19.*/
            }
            public SI0112B_LC19 LC19 { get; set; } = new SI0112B_LC19();
            public class SI0112B_LC19 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC19-DESCRITEM      PIC  X(100) VALUE SPACES.*/
                public StringBasis LC19_DESCRITEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"    05          FILLER              PIC  X(029) VALUE SPACES.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC20.*/
            }
            public SI0112B_LC20 LC20 { get; set; } = new SI0112B_LC20();
            public class SI0112B_LC20 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(019) VALUE ALL '-'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(083) VALUE    'DADOS ESPECIFICOS TRANSPORTE / CASCO / AERONAUTICO / PENHOR    'RURAL / CRED.EXPORTACAO'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"DADOS ESPECIFICOS TRANSPORTE / CASCO / AERONAUTICO / PENHOR    ");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(020) VALUE ALL '-'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC21.*/
            }
            public SI0112B_LC21 LC21 { get; set; } = new SI0112B_LC21();
            public class SI0112B_LC21 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(023) VALUE               'AVERBACAO / CERTIFICADO'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"AVERBACAO / CERTIFICADO");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(018) VALUE               'MEIO DE TRANSPORTE'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"MEIO DE TRANSPORTE");
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'PLACA'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PLACA");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'PREFIXO'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PREFIXO");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE 'EMBARQUE'*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"EMBARQUE");
                /*"    05          FILLER              PIC  X(019) VALUE SPACES.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC22.*/
            }
            public SI0112B_LC22 LC22 { get; set; } = new SI0112B_LC22();
            public class SI0112B_LC22 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC22-AVERBACAO      PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC22_AVERBACAO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(011) VALUE SPACES.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    05          LC22-TRANSP         PIC  X(025) VALUE SPACES.*/
                public StringBasis LC22_TRANSP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC22-PLACA.*/
                public SI0112B_LC22_PLACA LC22_PLACA { get; set; } = new SI0112B_LC22_PLACA();
                public class SI0112B_LC22_PLACA : VarBasis
                {
                    /*"      07        LC22-PLACLET        PIC  X(003) VALUE SPACES.*/
                    public StringBasis LC22_PLACLET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      07        FILLER              PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LC22-PLACNUM        PIC  X(004) VALUE SPACES.*/
                    public StringBasis LC22_PLACNUM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                }
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC22-PREFIXO        PIC  X(021) VALUE SPACES.*/
                public StringBasis LC22_PREFIXO { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          LC22-EMBARQUE       PIC  X(026) VALUE SPACES.*/
                public StringBasis LC22_EMBARQUE { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC23.*/
            }
            public SI0112B_LC23 LC23 { get; set; } = new SI0112B_LC23();
            public class SI0112B_LC23 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(022) VALUE               'EMPRESA TRANSPORTADORA'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"EMPRESA TRANSPORTADORA");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE               'MERCADORIA'.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"MERCADORIA");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE               'NATUREZA'.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NATUREZA");
                /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(009) VALUE               'COBERTURA'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COBERTURA");
                /*"    05          FILLER              PIC  X(018) VALUE SPACES.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC24.*/
            }
            public SI0112B_LC24 LC24 { get; set; } = new SI0112B_LC24();
            public class SI0112B_LC24 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC24-EMPRESA        PIC  X(025) VALUE SPACES.*/
                public StringBasis LC24_EMPRESA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC24-MERCAD         PIC  X(025) VALUE SPACES.*/
                public StringBasis LC24_MERCAD { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC24-NATUREZA       PIC  X(035) VALUE SPACES.*/
                public StringBasis LC24_NATUREZA { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          LC24-COBERTUR       PIC  X(026) VALUE SPACES.*/
                public StringBasis LC24_COBERTUR { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC25.*/
            }
            public SI0112B_LC25 LC25 { get; set; } = new SI0112B_LC25();
            public class SI0112B_LC25 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'ORIGEM'.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ORIGEM");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'DESTINO'.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DESTINO");
                /*"    05          FILLER              PIC  X(024) VALUE SPACES.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                'LOCAL OCORRENCIA'.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"LOCAL OCORRENCIA");
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'CIDADE'.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CIDADE");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC26.*/
            }
            public SI0112B_LC26 LC26 { get; set; } = new SI0112B_LC26();
            public class SI0112B_LC26 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC26-ORIGEM         PIC  X(025) VALUE SPACES.*/
                public StringBasis LC26_ORIGEM { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC26-DESTINO        PIC  X(025) VALUE SPACES.*/
                public StringBasis LC26_DESTINO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC26-LOCAL          PIC  X(035) VALUE SPACES.*/
                public StringBasis LC26_LOCAL { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          LC26-CIDADE         PIC  X(026) VALUE SPACES.*/
                public StringBasis LC26_CIDADE { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC27.*/
            }
            public SI0112B_LC27 LC27 { get; set; } = new SI0112B_LC27();
            public class SI0112B_LC27 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(026) VALUE               'DADOS ESPECIFICOS VG / APC'.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"DADOS ESPECIFICOS VG / APC");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC28.*/
            }
            public SI0112B_LC28 LC28 { get; set; } = new SI0112B_LC28();
            public class SI0112B_LC28 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE               'ESTIPULANTE'.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ESTIPULANTE");
                /*"    05          FILLER              PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    05          FILLER              PIC  X(018) VALUE               'SEGURADO PRINCIPAL'.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"SEGURADO PRINCIPAL");
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(019) VALUE               'SEGURADO SINISTRADO'.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"SEGURADO SINISTRADO");
                /*"    05          FILLER              PIC  X(022) VALUE SPACES.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC29.*/
            }
            public SI0112B_LC29 LC29 { get; set; } = new SI0112B_LC29();
            public class SI0112B_LC29 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC29-ESTIPUL        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC29_ESTIPUL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC29-SEG-PRI        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC29_SEG_PRI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC29-SEG-SIN        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC29_SEG_SIN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC30.*/
            }
            public SI0112B_LC30 LC30 { get; set; } = new SI0112B_LC30();
            public class SI0112B_LC30 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(020) VALUE               'GARANTIA DO SEGURADO'.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"GARANTIA DO SEGURADO");
                /*"    05          FILLER              PIC  X(024) VALUE SPACES.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    05          FILLER              PIC  X(027) VALUE               'DATA NASCIMENTO (PRINCIPAL)'.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"DATA NASCIMENTO (PRINCIPAL)");
                /*"    05          FILLER              PIC  X(017) VALUE SPACES.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    05          FILLER              PIC  X(028) VALUE               'DATA NASCIMENTO (SINISTRADO)'.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"DATA NASCIMENTO (SINISTRADO)");
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC31.*/
            }
            public SI0112B_LC31 LC31 { get; set; } = new SI0112B_LC31();
            public class SI0112B_LC31 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC31-GARANTIA       PIC  X(020) VALUE SPACES.*/
                public StringBasis LC31_GARANTIA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER              REDEFINES   LC31-GARANTIA                                    OCCURS      5 TIMES.*/
                private ListBasis<_REDEF_SI0112B_FILLER_238> _filler_238 { get; set; }
                public ListBasis<_REDEF_SI0112B_FILLER_238> FILLER_238
                {
                    get { _filler_238 = new ListBasis<_REDEF_SI0112B_FILLER_238>(5); _.Move(LC31_GARANTIA, _filler_238); VarBasis.RedefinePassValue(LC31_GARANTIA, _filler_238, LC31_GARANTIA); _filler_238.ValueChanged += () => { _.Move(_filler_238, LC31_GARANTIA); }; return _filler_238; }
                    set { VarBasis.RedefinePassValue(value, _filler_238, LC31_GARANTIA); }
                }  //Redefines
                public class _REDEF_SI0112B_FILLER_238 : VarBasis
                {
                    /*"      07        LC31-DESCR          PIC  X(004).*/
                    public StringBasis LC31_DESCR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"    05          FILLER              PIC  X(029) VALUE SPACES.*/

                    public _REDEF_SI0112B_FILLER_238()
                    {
                        LC31_DESCR.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    05          LC31-DATA1.*/
                public SI0112B_LC31_DATA1 LC31_DATA1 { get; set; } = new SI0112B_LC31_DATA1();
                public class SI0112B_LC31_DATA1 : VarBasis
                {
                    /*"      07        LC31-DIA1           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-MES1           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-ANO1           PIC  9(004) BLANK WHEN ZEROS*/
                    public IntBasis LC31_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                }
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC31-DATA2.*/
                public SI0112B_LC31_DATA2 LC31_DATA2 { get; set; } = new SI0112B_LC31_DATA2();
                public class SI0112B_LC31_DATA2 : VarBasis
                {
                    /*"      07        LC31-DIA2           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-MES2           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-ANO2           PIC  9(004) BLANK WHEN ZEROS*/
                    public IntBasis LC31_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                }
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC32.*/
            }
            public SI0112B_LC32 LC32 { get; set; } = new SI0112B_LC32();
            public class SI0112B_LC32 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(025) VALUE               'PARTICIPACAO DA CONGENERE'.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"PARTICIPACAO DA CONGENERE");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(049) VALUE ALL '-'.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC33.*/
            }
            public SI0112B_LC33 LC33 { get; set; } = new SI0112B_LC33();
            public class SI0112B_LC33 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC33-REFER          PIC  X(040) VALUE SPACES.*/
                public StringBasis LC33_REFER { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE               'VALOR TOTAL'.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"VALOR TOTAL");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE               'SUA PARTICIPACAO'.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SUA PARTICIPACAO");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE               'TOTAL COSSEGURO '.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"TOTAL COSSEGURO ");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC34.*/
            }
            public SI0112B_LC34 LC34 { get; set; } = new SI0112B_LC34();
            public class SI0112B_LC34 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LC34-VAL-TOTAL      PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC34_VAL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          LC34-SUA-PARTIC     PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC34_SUA_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LC34-TOT-COSSEG     PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC34_TOT_COSSEG { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC35.*/
            }
            public SI0112B_LC35 LC35 { get; set; } = new SI0112B_LC35();
            public class SI0112B_LC35 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LC35-VAL-TOTAL      PIC  ZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC35_VAL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          LC35-SUA-PARTIC     PIC  ZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC35_SUA_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LC35-TOT-COSSEG     PIC  ZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC35_TOT_COSSEG { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC36.*/
            }
            public SI0112B_LC36 LC36 { get; set; } = new SI0112B_LC36();
            public class SI0112B_LC36 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(130) VALUE ALL '-'.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA.*/
            public SI0112B_WDATA WDATA { get; set; } = new SI0112B_WDATA();
            public class SI0112B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            private _REDEF_SI0112B_FILLER_280 _filler_280 { get; set; }
            public _REDEF_SI0112B_FILLER_280 FILLER_280
            {
                get { _filler_280 = new _REDEF_SI0112B_FILLER_280(); _.Move(WDATA_CURR, _filler_280); VarBasis.RedefinePassValue(WDATA_CURR, _filler_280, WDATA_CURR); _filler_280.ValueChanged += () => { _.Move(_filler_280, WDATA_CURR); }; return _filler_280; }
                set { VarBasis.RedefinePassValue(value, _filler_280, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0112B_FILLER_280 : VarBasis
            {
                /*"    05       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-CURR.*/

                public _REDEF_SI0112B_FILLER_280()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_281.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_282.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0112B_WHORA_CURR WHORA_CURR { get; set; } = new SI0112B_WHORA_CURR();
            public class SI0112B_WHORA_CURR : VarBasis
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
            public SI0112B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0112B_WDATA_CABEC();
            public class SI0112B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0112B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0112B_WHORA_CABEC();
            public class SI0112B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WFIM-TRELSIN        PIC  X(001) VALUE 'N'.*/
            }
            public StringBasis WFIM_TRELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WCONT-PAG           PIC  9(005) VALUE 0.*/
            public IntBasis WCONT_PAG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            WPROXIMO            PIC  X(001) VALUE SPACES.*/
            public StringBasis WPROXIMO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WIND                PIC S9(003) VALUE +0 COMP-3.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WLIDOS              PIC  9(006) VALUE 0.*/
            public IntBasis WLIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WIMPRES             PIC  9(006) VALUE 0.*/
            public IntBasis WIMPRES { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            W01P1502            PIC S9(015)V99 COMP-3                                        VALUE +0.*/
            public DoubleBasis W01P1502 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            W01P1505            PIC S9(10)V99999 VALUE +0.*/
            public DoubleBasis W01P1505 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V99999"), 5);
            /*"  03            W02P1505            PIC S9(10)V99999 VALUE +0.*/
            public DoubleBasis W02P1505 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V99999"), 5);
            /*"  03            W-APOLSINI          PIC S9(013) VALUE ZEROS.*/
            public IntBasis W_APOLSINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            FILLER              REDEFINES   W-APOLSINI.*/
            private _REDEF_SI0112B_FILLER_287 _filler_287 { get; set; }
            public _REDEF_SI0112B_FILLER_287 FILLER_287
            {
                get { _filler_287 = new _REDEF_SI0112B_FILLER_287(); _.Move(W_APOLSINI, _filler_287); VarBasis.RedefinePassValue(W_APOLSINI, _filler_287, W_APOLSINI); _filler_287.ValueChanged += () => { _.Move(_filler_287, W_APOLSINI); }; return _filler_287; }
                set { VarBasis.RedefinePassValue(value, _filler_287, W_APOLSINI); }
            }  //Redefines
            public class _REDEF_SI0112B_FILLER_287 : VarBasis
            {
                /*"    05          W-ORGSINI           PIC  9(003).*/
                public IntBasis W_ORGSINI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          W-RMOSINI           PIC  9(002).*/
                public IntBasis W_RMOSINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          W-NUMSINI           PIC  9(008).*/
                public IntBasis W_NUMSINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            WSINISTRO-ANT       PIC  9(010) VALUE ZEROS.*/

                public _REDEF_SI0112B_FILLER_287()
                {
                    W_ORGSINI.ValueChanged += OnValueChanged;
                    W_RMOSINI.ValueChanged += OnValueChanged;
                    W_NUMSINI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  03            FILLER              REDEFINES   WSINISTRO-ANT.*/
            private _REDEF_SI0112B_FILLER_288 _filler_288 { get; set; }
            public _REDEF_SI0112B_FILLER_288 FILLER_288
            {
                get { _filler_288 = new _REDEF_SI0112B_FILLER_288(); _.Move(WSINISTRO_ANT, _filler_288); VarBasis.RedefinePassValue(WSINISTRO_ANT, _filler_288, WSINISTRO_ANT); _filler_288.ValueChanged += () => { _.Move(_filler_288, WSINISTRO_ANT); }; return _filler_288; }
                set { VarBasis.RedefinePassValue(value, _filler_288, WSINISTRO_ANT); }
            }  //Redefines
            public class _REDEF_SI0112B_FILLER_288 : VarBasis
            {
                /*"    05          WORGSIN-ANT         PIC  9(003).*/
                public IntBasis WORGSIN_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          WRMOSIN-ANT         PIC  9(002).*/
                public IntBasis WRMOSIN_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WNUMSIN-ANT         PIC  9(005).*/
                public IntBasis WNUMSIN_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03            WCODCOSS-ANT        PIC S9(004) COMP VALUE +0.*/

                public _REDEF_SI0112B_FILLER_288()
                {
                    WORGSIN_ANT.ValueChanged += OnValueChanged;
                    WRMOSIN_ANT.ValueChanged += OnValueChanged;
                    WNUMSIN_ANT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WCODCOSS_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WABEND.*/
            public SI0112B_WABEND WABEND { get; set; } = new SI0112B_WABEND();
            public class SI0112B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0112B'.*/
                public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0112B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_290 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_291 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_292 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_293 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_294 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0112B_LK_LINK LK_LINK { get; set; } = new SI0112B_LK_LINK();
        public class SI0112B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01          WORK9S              PIC 9(16) COMP SYNC VALUE                                    9999999999999999.*/
        }
        public IntBasis WORK9S { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"), 9999999999999999);


        public SI0112B_TRELSIN TRELSIN { get; set; } = new SI0112B_TRELSIN();
        public SI0112B_TAPOCOS TAPOCOS { get; set; } = new SI0112B_TAPOCOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0112M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0112M1.SetFile(SI0112M1_FILE_NAME_P);

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
            /*" -808- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -811- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -812- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -814- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -816- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -821- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -823- PERFORM 090-000-CURSOR-V1RELATORIOS. */

            M_090_000_CURSOR_V1RELATORIOS_SECTION();

            /*" -825- PERFORM 150-000-LER-V1RELATORIOS. */

            M_150_000_LER_V1RELATORIOS_SECTION();

            /*" -826- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -827- DISPLAY 'SI0112B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0112B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -829- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -831- PERFORM 020-000-MASCARA. */

            M_020_000_MASCARA_SECTION();

            /*" -833- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -836- PERFORM 120-000-PROCESSA UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_120_000_PROCESSA_SECTION();
            }

            /*" -836- PERFORM 800-000-ATUALIZA-V0RELATORIOS. */

            M_800_000_ATUALIZA_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -841- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -841- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -850- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -851- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -852- MOVE WHORA-HH-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -853- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -856- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -860- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -863- MOVE V1EMPRESA-DTCURRENT TO WDATA-CURR */
            _.Move(V1EMPRESA_DTCURRENT, W.WDATA_CURR);

            /*" -864- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.FILLER_280.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -865- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.FILLER_280.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -866- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.FILLER_280.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -868- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -869- MOVE V1EMPRESA-MNUEMP TO LK-TITULO */
            _.Move(V1EMPRESA_MNUEMP, LK_LINK.LK_TITULO);

            /*" -871- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -872- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -873- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -874- ELSE */
            }
            else
            {


                /*" -875- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -875- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -860- EXEC SQL SELECT NOME_EMPRESA, CURRENT DATE INTO :V1EMPRESA-MNUEMP, :V1EMPRESA-DTCURRENT FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_MNUEMP, V1EMPRESA_MNUEMP);
                _.Move(executed_1.V1EMPRESA_DTCURRENT, V1EMPRESA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-020-000-MASCARA-SECTION */
        private void M_020_000_MASCARA_SECTION()
        {
            /*" -885- MOVE '020-000-MASCARA' TO PARAGRAFO. */
            _.Move("020-000-MASCARA", W.WABEND.PARAGRAFO);

            /*" -887- PERFORM 015-000-CABECALHOS */

            M_015_000_CABECALHOS_SECTION();

            /*" -918- MOVE ALL 'X' TO LC01-EMPRESA LC05-NOMECONG LC06-REFER LC09-NOME LC09-NOMERAMO LC11-SIGLUNIM LC13-NOMFAV LC16-DESCVEIC LC16-PLACALET LC16-CHASSIS LC19-DESCRITEM LC22-TRANSP LC22-PLACLET LC22-PREFIXO LC22-EMBARQUE LC24-EMPRESA LC24-MERCAD LC24-NATUREZA LC24-COBERTUR LC26-ORIGEM LC26-DESTINO LC26-LOCAL LC26-CIDADE LC29-ESTIPUL LC29-SEG-PRI LC29-SEG-SIN LC31-GARANTIA LC33-REFER LC16-PLACANR LC22-PLACNUM */
            _.MoveAll("X", W.LC01.LC01_EMPRESA, W.LC05.LC05_NOMECONG, W.LC06.LC06_REFER, W.LC09.LC09_NOME, W.LC09.LC09_NOMERAMO, W.LC11.LC11_SIGLUNIM, W.LC13.LC13_NOMFAV, W.LC16.LC16_DESCVEIC, W.LC16.LC16_PLACA.LC16_PLACALET, W.LC16.LC16_CHASSIS, W.LC19.LC19_DESCRITEM, W.LC22.LC22_TRANSP, W.LC22.LC22_PLACA.LC22_PLACLET, W.LC22.LC22_PREFIXO, W.LC22.LC22_EMBARQUE, W.LC24.LC24_EMPRESA, W.LC24.LC24_MERCAD, W.LC24.LC24_NATUREZA, W.LC24.LC24_COBERTUR, W.LC26.LC26_ORIGEM, W.LC26.LC26_DESTINO, W.LC26.LC26_LOCAL, W.LC26.LC26_CIDADE, W.LC29.LC29_ESTIPUL, W.LC29.LC29_SEG_PRI, W.LC29.LC29_SEG_SIN, W.LC31.LC31_GARANTIA, W.LC33.LC33_REFER, W.LC16.LC16_PLACA.LC16_PLACANR, W.LC22.LC22_PLACA.LC22_PLACNUM);

            /*" -956- MOVE WORK9S TO LC01-PAG LC05-CODCOSS LC06-SINISTRO LC09-PCPARTIC LC09-DD-SINI LC09-MM-SINI LC09-AA-SINI LC09-DD-AVISO LC09-MM-AVISO LC09-AA-AVISO LC11-APOLICE LC11-NRORDEM LC11-DD-I LC11-MM-I LC11-AA-I LC11-DD-T LC11-MM-T LC11-AA-T LC11-ITEM LC11-ISITEM LC13-SINIRB LC16-ANOVEICL LC22-AVERBACAO LC31-DIA1 LC31-MES1 LC31-ANO1 LC31-DIA2 LC31-MES2 LC31-ANO2 LC34-VAL-TOTAL LC34-SUA-PARTIC LC34-TOT-COSSEG LC35-VAL-TOTAL LC35-SUA-PARTIC LC35-TOT-COSSEG. */
            _.Move(WORK9S, W.LC01.LC01_PAG, W.LC05.LC05_CODCOSS, W.LC06.LC06_SINISTRO, W.LC09.LC09_PCPARTIC, W.LC09.LC09_DTSINI.LC09_DD_SINI, W.LC09.LC09_DTSINI.LC09_MM_SINI, W.LC09.LC09_DTSINI.LC09_AA_SINI, W.LC09.LC09_DTAVISO.LC09_DD_AVISO, W.LC09.LC09_DTAVISO.LC09_MM_AVISO, W.LC09.LC09_DTAVISO.LC09_AA_AVISO, W.LC11.LC11_APOLICE, W.LC11.LC11_NRORDEM, W.LC11.LC11_DTINIVIG.LC11_DD_I, W.LC11.LC11_DTINIVIG.LC11_MM_I, W.LC11.LC11_DTINIVIG.LC11_AA_I, W.LC11.LC11_DTTERVIG.LC11_DD_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_ITEM, W.LC11.LC11_ISITEM, W.LC13.LC13_SINIRB, W.LC16.LC16_ANOVEICL, W.LC22.LC22_AVERBACAO, W.LC31.LC31_DATA1.LC31_DIA1, W.LC31.LC31_DATA1.LC31_MES1, W.LC31.LC31_DATA1.LC31_ANO1, W.LC31.LC31_DATA2.LC31_DIA2, W.LC31.LC31_DATA2.LC31_MES2, W.LC31.LC31_DATA2.LC31_ANO2, W.LC34.LC34_VAL_TOTAL, W.LC34.LC34_SUA_PARTIC, W.LC34.LC34_TOT_COSSEG, W.LC35.LC35_VAL_TOTAL, W.LC35.LC35_SUA_PARTIC, W.LC35.LC35_TOT_COSSEG);

            /*" -958- PERFORM 700-000-IMPRIME 2 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                M_700_000_IMPRIME_SECTION();

            }

            /*" -960- PERFORM 750-000-LIMPA-LINHAS. */

            M_750_000_LIMPA_LINHAS_SECTION();

            /*" -961- MOVE ZEROS TO WCONT-PAG */
            _.Move(0, W.WCONT_PAG);

            /*" -961- MOVE ZEROS TO WIMPRES. */
            _.Move(0, W.WIMPRES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -971- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -971- OPEN OUTPUT SI0112M1. */
            SI0112M1.Open(REG_SI0112M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V1RELATORIOS-SECTION */
        private void M_090_000_CURSOR_V1RELATORIOS_SECTION()
        {
            /*" -981- MOVE '090-000-CURSOR-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-V1RELATORIOS", W.WABEND.PARAGRAFO);

            /*" -983- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -994- PERFORM M_090_000_CURSOR_V1RELATORIOS_DB_DECLARE_1 */

            M_090_000_CURSOR_V1RELATORIOS_DB_DECLARE_1();

            /*" -996- PERFORM M_090_000_CURSOR_V1RELATORIOS_DB_OPEN_1 */

            M_090_000_CURSOR_V1RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1RELATORIOS-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -994- EXEC SQL DECLARE TRELSIN CURSOR FOR SELECT NUM_SINISTRO, CONGENER, OPERACAO, OCORHIST, DATA_SOLICITACAO FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND SITUACAO = '0' AND CODRELAT = 'SI0112B1' ORDER BY CONGENER, NUM_SINISTRO END-EXEC. */
            TRELSIN = new SI0112B_TRELSIN(false);
            string GetQuery_TRELSIN()
            {
                var query = @$"SELECT NUM_SINISTRO
							, 
							CONGENER
							, 
							OPERACAO
							, 
							OCORHIST
							, 
							DATA_SOLICITACAO 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND SITUACAO = '0' 
							AND CODRELAT = 'SI0112B1' 
							ORDER BY CONGENER
							, NUM_SINISTRO";

                return query;
            }
            TRELSIN.GetQueryEvent += GetQuery_TRELSIN;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1RELATORIOS-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -996- EXEC SQL OPEN TRELSIN END-EXEC. */

            TRELSIN.Open();

        }

        [StopWatch]
        /*" M-360-000-LER-V1APOLCOSCED-DB-DECLARE-1 */
        public void M_360_000_LER_V1APOLCOSCED_DB_DECLARE_1()
        {
            /*" -1418- EXEC SQL DECLARE TAPOCOS CURSOR FOR SELECT PCPARTIC, DTINIVIG FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :MEST-NUM-APOL AND CODCOSS = :V1RELA-CONGE AND DTINIVIG <= :MEST-DATORR AND DTTERVIG >= :MEST-DATORR ORDER BY DTINIVIG DESC END-EXEC. */
            TAPOCOS = new SI0112B_TAPOCOS(true);
            string GetQuery_TAPOCOS()
            {
                var query = @$"SELECT PCPARTIC
							, DTINIVIG 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{MEST_NUM_APOL}' 
							AND CODCOSS = '{V1RELA_CONGE}' 
							AND DTINIVIG <= '{MEST_DATORR}' 
							AND DTTERVIG >= '{MEST_DATORR}' 
							ORDER BY 
							DTINIVIG DESC";

                return query;
            }
            TAPOCOS.GetQueryEvent += GetQuery_TAPOCOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-SECTION */
        private void M_120_000_PROCESSA_SECTION()
        {
            /*" -1006- MOVE '120-000-PROCESSA' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA", W.WABEND.PARAGRAFO);

            /*" -1007- IF V1RELA-CONGE NOT EQUAL WCODCOSS-ANT */

            if (V1RELA_CONGE != W.WCODCOSS_ANT)
            {

                /*" -1008- PERFORM 160-000-LER-V1CONGENERE */

                M_160_000_LER_V1CONGENERE_SECTION();

                /*" -1009- MOVE V1RELA-CONGE TO WCODCOSS-ANT */
                _.Move(V1RELA_CONGE, W.WCODCOSS_ANT);

                /*" -1011- MOVE 0 TO WSINISTRO-ANT. */
                _.Move(0, W.WSINISTRO_ANT);
            }


            /*" -1013- PERFORM 180-000-LER-V1HISTSINI */

            M_180_000_LER_V1HISTSINI_SECTION();

            /*" -1014- IF WPROXIMO EQUAL 'S' */

            if (W.WPROXIMO == "S")
            {

                /*" -1015- MOVE SPACES TO WPROXIMO */
                _.Move("", W.WPROXIMO);

                /*" -1017- GO TO LER-O-PROXIMO. */

                LER_O_PROXIMO(); //GOTO
                return;
            }


            /*" -1018- IF V1RELA-NUMSINI NOT EQUAL WSINISTRO-ANT */

            if (V1RELA_NUMSINI != W.WSINISTRO_ANT)
            {

                /*" -1019- PERFORM 210-000-LER-V1MESTSINI */

                M_210_000_LER_V1MESTSINI_SECTION();

                /*" -1020- PERFORM 240-000-LER-V1APOLICE */

                M_240_000_LER_V1APOLICE_SECTION();

                /*" -1021- PERFORM 270-000-LER-V1ENDOSSO */

                M_270_000_LER_V1ENDOSSO_SECTION();

                /*" -1022- MOVE W-RMOSINI TO V1RAMO-RAMO */
                _.Move(W.FILLER_287.W_RMOSINI, V1RAMO_RAMO);

                /*" -1023- PERFORM 300-000-LER-V1RAMO */

                M_300_000_LER_V1RAMO_SECTION();

                /*" -1024- PERFORM 330-000-LER-V1ORDECOSCED */

                M_330_000_LER_V1ORDECOSCED_SECTION();

                /*" -1025- IF W-RMOSINI EQUAL 93 OR 97 */

                if (W.FILLER_287.W_RMOSINI.In("93", "97"))
                {

                    /*" -1027- PERFORM 570-000-LER-V1SEGURAVG. */

                    M_570_000_LER_V1SEGURAVG_SECTION();
                }

            }


            /*" -1029- PERFORM 360-000-LER-V1APOLCOSCED. */

            M_360_000_LER_V1APOLCOSCED_SECTION();

            /*" -1030- IF WPROXIMO EQUAL 'S' */

            if (W.WPROXIMO == "S")
            {

                /*" -1031- MOVE SPACES TO WPROXIMO */
                _.Move("", W.WPROXIMO);

                /*" -1035- GO TO LER-O-PROXIMO. */

                LER_O_PROXIMO(); //GOTO
                return;
            }


            /*" -1036- IF W-RMOSINI EQUAL 31 OR 53 */

            if (W.FILLER_287.W_RMOSINI.In("31", "53"))
            {

                /*" -1037- PERFORM 420-000-LER-V1APOLVEIC */

                M_420_000_LER_V1APOLVEIC_SECTION();

                /*" -1038- PERFORM 450-000-LER-V1DESCRVEI */

                M_450_000_LER_V1DESCRVEI_SECTION();

                /*" -1039- MOVE V1RELA-NUMSINI TO WSINISTRO-ANT */
                _.Move(V1RELA_NUMSINI, W.WSINISTRO_ANT);

                /*" -1041- ELSE */
            }
            else
            {


                /*" -1043- IF W-RMOSINI EQUAL 11 OR 41 OR 71 OR 67 */

                if (W.FILLER_287.W_RMOSINI.In("11", "41", "71", "67"))
                {

                    /*" -1044- PERFORM 410-000-LER-V1APOLITEM */

                    M_410_000_LER_V1APOLITEM_SECTION();

                    /*" -1045- MOVE V1RELA-NUMSINI TO WSINISTRO-ANT */
                    _.Move(V1RELA_NUMSINI, W.WSINISTRO_ANT);

                    /*" -1047- ELSE */
                }
                else
                {


                    /*" -1048- IF W-RMOSINI EQUAL 21 OR 22 */

                    if (W.FILLER_287.W_RMOSINI.In("21", "22"))
                    {

                        /*" -1050- MOVE V1RELA-NUMSINI TO WSINISTRO-ANT */
                        _.Move(V1RELA_NUMSINI, W.WSINISTRO_ANT);

                        /*" -1051- IF W-RMOSINI EQUAL 21 */

                        if (W.FILLER_287.W_RMOSINI == 21)
                        {

                            /*" -1052- PERFORM 480-000-LER-V1AVERBNAC */

                            M_480_000_LER_V1AVERBNAC_SECTION();

                            /*" -1053- ELSE */
                        }
                        else
                        {


                            /*" -1054- PERFORM 510-000-LER-V1AVERBINT */

                            M_510_000_LER_V1AVERBINT_SECTION();

                            /*" -1056- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1057- IF W-RMOSINI EQUAL 93 OR 97 */

                        if (W.FILLER_287.W_RMOSINI.In("93", "97"))
                        {

                            /*" -1058- MOVE APOL-NOME TO LC29-ESTIPUL */
                            _.Move(APOL_NOME, W.LC29.LC29_ESTIPUL);

                            /*" -1060- PERFORM 576-000-LER-V1CONDTEC */

                            M_576_000_LER_V1CONDTEC_SECTION();

                            /*" -1063- IF MEST-IDTPSEGU EQUAL 2 */

                            if (MEST_IDTPSEGU == 2)
                            {

                                /*" -1064- MOVE CLIEN-NOME TO LC29-SEG-SIN */
                                _.Move(CLIEN_NOME, W.LC29.LC29_SEG_SIN);

                                /*" -1065- MOVE SEGVG-DTNASCIM TO WDATA-R */
                                _.Move(SEGVG_DTNASCIM, W.WDATA_R);

                                /*" -1066- MOVE WDATA-DD TO LC31-DIA2 */
                                _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA2.LC31_DIA2);

                                /*" -1067- MOVE WDATA-MM TO LC31-MES2 */
                                _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA2.LC31_MES2);

                                /*" -1070- MOVE WDATA-AA TO LC31-ANO2 */
                                _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA2.LC31_ANO2);

                                /*" -1072- PERFORM 570-000-LER-V1SEGURAVG */

                                M_570_000_LER_V1SEGURAVG_SECTION();

                                /*" -1073- MOVE CLIEN-NOME TO LC29-SEG-PRI */
                                _.Move(CLIEN_NOME, W.LC29.LC29_SEG_PRI);

                                /*" -1074- MOVE SEGVG-DTNASCIM TO WDATA-R */
                                _.Move(SEGVG_DTNASCIM, W.WDATA_R);

                                /*" -1075- MOVE WDATA-DD TO LC31-DIA1 */
                                _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA1.LC31_DIA1);

                                /*" -1076- MOVE WDATA-MM TO LC31-MES1 */
                                _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA1.LC31_MES1);

                                /*" -1078- MOVE WDATA-AA TO LC31-ANO1 */
                                _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA1.LC31_ANO1);

                                /*" -1081- ELSE */
                            }
                            else
                            {


                                /*" -1082- MOVE CLIEN-NOME TO LC29-SEG-PRI */
                                _.Move(CLIEN_NOME, W.LC29.LC29_SEG_PRI);

                                /*" -1083- MOVE SEGVG-DTNASCIM TO WDATA-R */
                                _.Move(SEGVG_DTNASCIM, W.WDATA_R);

                                /*" -1084- MOVE WDATA-DD TO LC31-DIA1 */
                                _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA1.LC31_DIA1);

                                /*" -1085- MOVE WDATA-MM TO LC31-MES1 */
                                _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA1.LC31_MES1);

                                /*" -1087- MOVE WDATA-AA TO LC31-ANO1 */
                                _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA1.LC31_ANO1);

                                /*" -1088- MOVE CLIEN-NOME TO LC29-SEG-SIN */
                                _.Move(CLIEN_NOME, W.LC29.LC29_SEG_SIN);

                                /*" -1089- MOVE SEGVG-DTNASCIM TO WDATA-R */
                                _.Move(SEGVG_DTNASCIM, W.WDATA_R);

                                /*" -1090- MOVE WDATA-DD TO LC31-DIA2 */
                                _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA2.LC31_DIA2);

                                /*" -1091- MOVE WDATA-MM TO LC31-MES2 */
                                _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA2.LC31_MES2);

                                /*" -1093- MOVE WDATA-AA TO LC31-ANO2 */
                                _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA2.LC31_ANO2);

                                /*" -1095- MOVE V1RELA-NUMSINI TO WSINISTRO-ANT. */
                                _.Move(V1RELA_NUMSINI, W.WSINISTRO_ANT);
                            }

                        }

                    }

                }

            }


            /*" -1095- PERFORM 700-000-IMPRIME. */

            M_700_000_IMPRIME_SECTION();

            /*" -0- FLUXCONTROL_PERFORM LER_O_PROXIMO */

            LER_O_PROXIMO();

        }

        [StopWatch]
        /*" LER-O-PROXIMO */
        private void LER_O_PROXIMO(bool isPerform = false)
        {
            /*" -1099- PERFORM 150-000-LER-V1RELATORIOS. */

            M_150_000_LER_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-LER-V1RELATORIOS-SECTION */
        private void M_150_000_LER_V1RELATORIOS_SECTION()
        {
            /*" -1108- MOVE '150-000-LER-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("150-000-LER-V1RELATORIOS", W.WABEND.PARAGRAFO);

            /*" -1110- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", W.WABEND.WNR_EXEC_SQL);

            /*" -1116- PERFORM M_150_000_LER_V1RELATORIOS_DB_FETCH_1 */

            M_150_000_LER_V1RELATORIOS_DB_FETCH_1();

            /*" -1119- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1119- PERFORM M_150_000_LER_V1RELATORIOS_DB_CLOSE_1 */

                M_150_000_LER_V1RELATORIOS_DB_CLOSE_1();

                /*" -1121- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -1122- ELSE */
            }
            else
            {


                /*" -1123- MOVE V1RELA-CONGE TO LC05-CODCOSS */
                _.Move(V1RELA_CONGE, W.LC05.LC05_CODCOSS);

                /*" -1124- MOVE V1RELA-NUMSINI TO LC06-SINISTRO */
                _.Move(V1RELA_NUMSINI, W.LC06.LC06_SINISTRO);

                /*" -1124- ADD 1 TO WLIDOS. */
                W.WLIDOS.Value = W.WLIDOS + 1;
            }


        }

        [StopWatch]
        /*" M-150-000-LER-V1RELATORIOS-DB-FETCH-1 */
        public void M_150_000_LER_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -1116- EXEC SQL FETCH TRELSIN INTO :V1RELA-NUMSINI , :V1RELA-CONGE , :V1RELA-OPERACAO, :V1RELA-OCORHIST, :V1RELA-DTMOVTO END-EXEC. */

            if (TRELSIN.Fetch())
            {
                _.Move(TRELSIN.V1RELA_NUMSINI, V1RELA_NUMSINI);
                _.Move(TRELSIN.V1RELA_CONGE, V1RELA_CONGE);
                _.Move(TRELSIN.V1RELA_OPERACAO, V1RELA_OPERACAO);
                _.Move(TRELSIN.V1RELA_OCORHIST, V1RELA_OCORHIST);
                _.Move(TRELSIN.V1RELA_DTMOVTO, V1RELA_DTMOVTO);
            }

        }

        [StopWatch]
        /*" M-150-000-LER-V1RELATORIOS-DB-CLOSE-1 */
        public void M_150_000_LER_V1RELATORIOS_DB_CLOSE_1()
        {
            /*" -1119- EXEC SQL CLOSE TRELSIN END-EXEC */

            TRELSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-160-000-LER-V1CONGENERE-SECTION */
        private void M_160_000_LER_V1CONGENERE_SECTION()
        {
            /*" -1134- MOVE '160-000-LER-V1CONGENERE' TO PARAGRAFO. */
            _.Move("160-000-LER-V1CONGENERE", W.WABEND.PARAGRAFO);

            /*" -1140- PERFORM M_160_000_LER_V1CONGENERE_DB_SELECT_1 */

            M_160_000_LER_V1CONGENERE_DB_SELECT_1();

            /*" -1143- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1144- DISPLAY 'SI0112B - CONGENERE NAO CADASTRADA ' */
                _.Display($"SI0112B - CONGENERE NAO CADASTRADA ");

                /*" -1145- DISPLAY 'CONGENER = ' V1RELA-CONGE */
                _.Display($"CONGENER = {V1RELA_CONGE}");

                /*" -1146- MOVE SPACES TO LC05-NOMECONG */
                _.Move("", W.LC05.LC05_NOMECONG);

                /*" -1147- ELSE */
            }
            else
            {


                /*" -1147- MOVE V1CONGE-NOMECONG TO LC05-NOMECONG. */
                _.Move(V1CONGE_NOMECONG, W.LC05.LC05_NOMECONG);
            }


        }

        [StopWatch]
        /*" M-160-000-LER-V1CONGENERE-DB-SELECT-1 */
        public void M_160_000_LER_V1CONGENERE_DB_SELECT_1()
        {
            /*" -1140- EXEC SQL SELECT NOMECONG INTO :V1CONGE-NOMECONG FROM SEGUROS.V1CONGENERE WHERE CONGENER = :V1RELA-CONGE END-EXEC. */

            var m_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1 = new M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1()
            {
                V1RELA_CONGE = V1RELA_CONGE.ToString(),
            };

            var executed_1 = M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1.Execute(m_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CONGE_NOMECONG, V1CONGE_NOMECONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-180-000-LER-V1HISTSINI-SECTION */
        private void M_180_000_LER_V1HISTSINI_SECTION()
        {
            /*" -1157- MOVE '180-000-LER-V1HISTSINI' TO PARAGRAFO. */
            _.Move("180-000-LER-V1HISTSINI", W.WABEND.PARAGRAFO);

            /*" -1159- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", W.WABEND.WNR_EXEC_SQL);

            /*" -1171- PERFORM M_180_000_LER_V1HISTSINI_DB_SELECT_1 */

            M_180_000_LER_V1HISTSINI_DB_SELECT_1();

            /*" -1174- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1175- DISPLAY 'SI0112B - SINISTRO NAO CADASTRADO NA V1HISTSINI' */
                _.Display($"SI0112B - SINISTRO NAO CADASTRADO NA V1HISTSINI");

                /*" -1180- DISPLAY ' APOLICE_SINISTRO = ' V1RELA-NUMSINI ' DTMOVTO  = ' V1RELA-DTMOVTO ' OPERACAO = ' V1RELA-OPERACAO ' OCORHIST = ' V1RELA-OCORHIST */

                $" APOLICE_SINISTRO = {V1RELA_NUMSINI} DTMOVTO  = {V1RELA_DTMOVTO} OPERACAO = {V1RELA_OPERACAO} OCORHIST = {V1RELA_OCORHIST}"
                .Display();

                /*" -1182- GO TO 180-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/ //GOTO
                return;
            }


            /*" -1183- IF THIST-OPERACAO EQUAL 101 */

            if (THIST_OPERACAO == 101)
            {

                /*" -1185- MOVE 'AVISO DE SINISTRO' TO LC06-REFER LC33-REFER */
                _.Move("AVISO DE SINISTRO", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                /*" -1186- ELSE */
            }
            else
            {


                /*" -1188- IF THIST-OPERACAO EQUAL 107 OR 117 OR 108 OR 118 */

                if (THIST_OPERACAO.In("107", "117", "108", "118"))
                {

                    /*" -1190- MOVE 'CANCELAMENTO' TO LC06-REFER LC33-REFER */
                    _.Move("CANCELAMENTO", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                    /*" -1191- ELSE */
                }
                else
                {


                    /*" -1192- IF THIST-OPERACAO EQUAL 1001 */

                    if (THIST_OPERACAO == 1001)
                    {

                        /*" -1194- MOVE 'PAGAMENTO PARCIAL' TO LC06-REFER LC33-REFER */
                        _.Move("PAGAMENTO PARCIAL", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                        /*" -1195- ELSE */
                    }
                    else
                    {


                        /*" -1196- IF THIST-OPERACAO EQUAL 1002 */

                        if (THIST_OPERACAO == 1002)
                        {

                            /*" -1198- MOVE 'PAGAMENTO FINAL' TO LC06-REFER LC33-REFER */
                            _.Move("PAGAMENTO FINAL", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                            /*" -1199- ELSE */
                        }
                        else
                        {


                            /*" -1200- IF THIST-OPERACAO EQUAL 1003 */

                            if (THIST_OPERACAO == 1003)
                            {

                                /*" -1202- MOVE 'PAGAMENTO TOTAL' TO LC06-REFER LC33-REFER */
                                _.Move("PAGAMENTO TOTAL", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                                /*" -1203- ELSE */
                            }
                            else
                            {


                                /*" -1204- IF THIST-OPERACAO EQUAL 1004 */

                                if (THIST_OPERACAO == 1004)
                                {

                                    /*" -1207- MOVE 'PAGAMENTO COMPLEMENTAR' TO LC06-REFER LC33-REFER */
                                    _.Move("PAGAMENTO COMPLEMENTAR", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                                    /*" -1208- ELSE */
                                }
                                else
                                {


                                    /*" -1209- IF THIST-OPERACAO EQUAL 9001 */

                                    if (THIST_OPERACAO == 9001)
                                    {

                                        /*" -1211- MOVE 'ADIANTAMENTO' TO LC06-REFER LC33-REFER */
                                        _.Move("ADIANTAMENTO", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                                        /*" -1212- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1213- IF THIST-OPERACAO EQUAL 2010 */

                                        if (THIST_OPERACAO == 2010)
                                        {

                                            /*" -1215- MOVE 'PAGAMENTO DE DESPESA' TO LC06-REFER LC33-REFER */
                                            _.Move("PAGAMENTO DE DESPESA", W.LC06.LC06_REFER, W.LC33.LC33_REFER);

                                            /*" -1216- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1217- IF THIST-OPERACAO EQUAL 3010 */

                                            if (THIST_OPERACAO == 3010)
                                            {

                                                /*" -1218- MOVE 'PAGAMENTO DE HONORARIO' TO LC06-REFER LC33-REFER. */
                                                _.Move("PAGAMENTO DE HONORARIO", W.LC06.LC06_REFER, W.LC33.LC33_REFER);
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

        [StopWatch]
        /*" M-180-000-LER-V1HISTSINI-DB-SELECT-1 */
        public void M_180_000_LER_V1HISTSINI_DB_SELECT_1()
        {
            /*" -1171- EXEC SQL SELECT OPERACAO, OCORHIST, NOMFAV , DTMOVTO , VAL_OPERACAO INTO :THIST-OPERACAO, :THIST-OCORHIST, :THIST-NOMFAV , :THIST-DTMOVTO , :THIST-VAL-OPERACAO FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :V1RELA-NUMSINI AND OPERACAO = :V1RELA-OPERACAO AND OCORHIST = :V1RELA-OCORHIST END-EXEC. */

            var m_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1 = new M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1()
            {
                V1RELA_OPERACAO = V1RELA_OPERACAO.ToString(),
                V1RELA_OCORHIST = V1RELA_OCORHIST.ToString(),
                V1RELA_NUMSINI = V1RELA_NUMSINI.ToString(),
            };

            var executed_1 = M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1.Execute(m_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_OPERACAO, THIST_OPERACAO);
                _.Move(executed_1.THIST_OCORHIST, THIST_OCORHIST);
                _.Move(executed_1.THIST_NOMFAV, THIST_NOMFAV);
                _.Move(executed_1.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(executed_1.THIST_VAL_OPERACAO, THIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-210-000-LER-V1MESTSINI-SECTION */
        private void M_210_000_LER_V1MESTSINI_SECTION()
        {
            /*" -1227- MOVE '210-000-LER-V1MESTSINI' TO PARAGRAFO. */
            _.Move("210-000-LER-V1MESTSINI", W.WABEND.PARAGRAFO);

            /*" -1229- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", W.WABEND.WNR_EXEC_SQL);

            /*" -1246- PERFORM M_210_000_LER_V1MESTSINI_DB_SELECT_1 */

            M_210_000_LER_V1MESTSINI_DB_SELECT_1();

            /*" -1249- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1250- DISPLAY 'SI0112B - SINISTRO NAO CADASTRADO NA V1MESTSINI' */
                _.Display($"SI0112B - SINISTRO NAO CADASTRADO NA V1MESTSINI");

                /*" -1251- DISPLAY ' SINISTRO = ' V1RELA-NUMSINI */
                _.Display($" SINISTRO = {V1RELA_NUMSINI}");

                /*" -1252- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1254- ELSE */
            }
            else
            {


                /*" -1257- MOVE MEST-APOL-SINI TO LC06-SINISTRO W-APOLSINI. */
                _.Move(MEST_APOL_SINI, W.LC06.LC06_SINISTRO, W.W_APOLSINI);
            }


            /*" -1258- MOVE MEST-DATORR TO WDATA-R */
            _.Move(MEST_DATORR, W.WDATA_R);

            /*" -1259- MOVE WDATA-DD TO LC09-DD-SINI */
            _.Move(W.WDATA.WDATA_DD, W.LC09.LC09_DTSINI.LC09_DD_SINI);

            /*" -1260- MOVE WDATA-MM TO LC09-MM-SINI */
            _.Move(W.WDATA.WDATA_MM, W.LC09.LC09_DTSINI.LC09_MM_SINI);

            /*" -1262- MOVE WDATA-AA TO LC09-AA-SINI. */
            _.Move(W.WDATA.WDATA_AA, W.LC09.LC09_DTSINI.LC09_AA_SINI);

            /*" -1263- MOVE MEST-DATCMD TO WDATA-R */
            _.Move(MEST_DATCMD, W.WDATA_R);

            /*" -1264- MOVE WDATA-DD TO LC09-DD-AVISO */
            _.Move(W.WDATA.WDATA_DD, W.LC09.LC09_DTAVISO.LC09_DD_AVISO);

            /*" -1265- MOVE WDATA-MM TO LC09-MM-AVISO */
            _.Move(W.WDATA.WDATA_MM, W.LC09.LC09_DTAVISO.LC09_MM_AVISO);

            /*" -1267- MOVE WDATA-AA TO LC09-AA-AVISO. */
            _.Move(W.WDATA.WDATA_AA, W.LC09.LC09_DTAVISO.LC09_AA_AVISO);

            /*" -1268- MOVE MEST-NUM-APOL TO LC11-APOLICE */
            _.Move(MEST_NUM_APOL, W.LC11.LC11_APOLICE);

            /*" -1269- MOVE MEST-NRCERTIF TO LC11-ITEM */
            _.Move(MEST_NRCERTIF, W.LC11.LC11_ITEM);

            /*" -1270- MOVE MEST-IDTPSEGU TO LC11-IDTPSEGU */
            _.Move(MEST_IDTPSEGU, W.LC11.LC11_IDTPSEGU);

            /*" -1271- MOVE MEST-VALSEGBT TO LC11-ISITEM */
            _.Move(MEST_VALSEGBT, W.LC11.LC11_ISITEM);

            /*" -1272- MOVE MEST-NUMIRB TO LC13-SINIRB */
            _.Move(MEST_NUMIRB, W.LC13.LC13_SINIRB);

            /*" -1272- MOVE THIST-NOMFAV TO LC13-NOMFAV. */
            _.Move(THIST_NOMFAV, W.LC13.LC13_NOMFAV);

        }

        [StopWatch]
        /*" M-210-000-LER-V1MESTSINI-DB-SELECT-1 */
        public void M_210_000_LER_V1MESTSINI_DB_SELECT_1()
        {
            /*" -1246- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NUM_APOL_SINISTRO, DATCMD, DATORR, NRCERTIF, COD_MOEDA_SINI, IDTPSEGU, NUMIRB, CODSUBES, NREMBARQ, REFEMBQ, VALSEGBT, PCPARTIC INTO :MEST-NUM-APOL, :MEST-NRENDOS, :MEST-APOL-SINI, :MEST-DATCMD, :MEST-DATORR, :MEST-NRCERTIF, :MEST-MOEDA-SINI, :MEST-IDTPSEGU, :MEST-NUMIRB, :MEST-CODSUBES, :MEST-NREMBARQ, :MEST-REFEMBQ, :MEST-VALSEGBT, :MEST-PCPARTIC FROM SEGUROS.V1MESTSINI WHERE NUM_APOL_SINISTRO = :V1RELA-NUMSINI END-EXEC. */

            var m_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1 = new M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1()
            {
                V1RELA_NUMSINI = V1RELA_NUMSINI.ToString(),
            };

            var executed_1 = M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1.Execute(m_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MEST_NUM_APOL, MEST_NUM_APOL);
                _.Move(executed_1.MEST_NRENDOS, MEST_NRENDOS);
                _.Move(executed_1.MEST_APOL_SINI, MEST_APOL_SINI);
                _.Move(executed_1.MEST_DATCMD, MEST_DATCMD);
                _.Move(executed_1.MEST_DATORR, MEST_DATORR);
                _.Move(executed_1.MEST_NRCERTIF, MEST_NRCERTIF);
                _.Move(executed_1.MEST_MOEDA_SINI, MEST_MOEDA_SINI);
                _.Move(executed_1.MEST_IDTPSEGU, MEST_IDTPSEGU);
                _.Move(executed_1.MEST_NUMIRB, MEST_NUMIRB);
                _.Move(executed_1.MEST_CODSUBES, MEST_CODSUBES);
                _.Move(executed_1.MEST_NREMBARQ, MEST_NREMBARQ);
                _.Move(executed_1.MEST_REFEMBQ, MEST_REFEMBQ);
                _.Move(executed_1.MEST_VALSEGBT, MEST_VALSEGBT);
                _.Move(executed_1.MEST_PCPARTIC, MEST_PCPARTIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-240-000-LER-V1APOLICE-SECTION */
        private void M_240_000_LER_V1APOLICE_SECTION()
        {
            /*" -1281- MOVE '240-000-LER-V1APOLICE' TO PARAGRAFO. */
            _.Move("240-000-LER-V1APOLICE", W.WABEND.PARAGRAFO);

            /*" -1283- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", W.WABEND.WNR_EXEC_SQL);

            /*" -1294- PERFORM M_240_000_LER_V1APOLICE_DB_SELECT_1 */

            M_240_000_LER_V1APOLICE_DB_SELECT_1();

            /*" -1297- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1298- DISPLAY 'SI0112B - APOLICE NAO CASTRADA NA V1APOLICE' */
                _.Display($"SI0112B - APOLICE NAO CASTRADA NA V1APOLICE");

                /*" -1299- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL */
                _.Display($"NUM_APOLICE = {MEST_NUM_APOL}");

                /*" -1300- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1302- ELSE */
            }
            else
            {


                /*" -1303- IF W-RMOSINI NOT EQUAL 93 OR 97 */

                if (!W.FILLER_287.W_RMOSINI.In("93", "97"))
                {

                    /*" -1303- MOVE APOL-NOME TO LC09-NOME. */
                    _.Move(APOL_NOME, W.LC09.LC09_NOME);
                }

            }


        }

        [StopWatch]
        /*" M-240-000-LER-V1APOLICE-DB-SELECT-1 */
        public void M_240_000_LER_V1APOLICE_DB_SELECT_1()
        {
            /*" -1294- EXEC SQL SELECT NOME, MODALIDA, CODCLIEN, PODPUBL INTO :APOL-NOME, :APOL-MODALIDA, :APOL-CODCLIEN, :APOL-PODPUBL FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :MEST-NUM-APOL END-EXEC. */

            var m_240_000_LER_V1APOLICE_DB_SELECT_1_Query1 = new M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
            };

            var executed_1 = M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1.Execute(m_240_000_LER_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_NOME, APOL_NOME);
                _.Move(executed_1.APOL_MODALIDA, APOL_MODALIDA);
                _.Move(executed_1.APOL_CODCLIEN, APOL_CODCLIEN);
                _.Move(executed_1.APOL_PODPUBL, APOL_PODPUBL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-270-000-LER-V1ENDOSSO-SECTION */
        private void M_270_000_LER_V1ENDOSSO_SECTION()
        {
            /*" -1312- MOVE '270-000-LER-V1ENDOSSO' TO PARAGRAFO. */
            _.Move("270-000-LER-V1ENDOSSO", W.WABEND.PARAGRAFO);

            /*" -1314- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", W.WABEND.WNR_EXEC_SQL);

            /*" -1324- PERFORM M_270_000_LER_V1ENDOSSO_DB_SELECT_1 */

            M_270_000_LER_V1ENDOSSO_DB_SELECT_1();

            /*" -1327- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1328- DISPLAY 'SI0112B - APOLICE NAO CADASTRADA NA V1ENDOSSO' */
                _.Display($"SI0112B - APOLICE NAO CADASTRADA NA V1ENDOSSO");

                /*" -1330- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL 'NRENDOS     = ' MEST-NRENDOS */

                $"NUM_APOLICE = {MEST_NUM_APOL}NRENDOS     = {MEST_NRENDOS}"
                .Display();

                /*" -1331- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1332- ELSE */
            }
            else
            {


                /*" -1333- MOVE ENDOS-DTINIVIG TO WDATA-R */
                _.Move(ENDOS_DTINIVIG, W.WDATA_R);

                /*" -1334- MOVE WDATA-AA TO LC11-AA-I */
                _.Move(W.WDATA.WDATA_AA, W.LC11.LC11_DTINIVIG.LC11_AA_I);

                /*" -1335- MOVE WDATA-MM TO LC11-MM-I */
                _.Move(W.WDATA.WDATA_MM, W.LC11.LC11_DTINIVIG.LC11_MM_I);

                /*" -1337- MOVE WDATA-DD TO LC11-DD-I */
                _.Move(W.WDATA.WDATA_DD, W.LC11.LC11_DTINIVIG.LC11_DD_I);

                /*" -1339- IF W-RMOSINI EQUAL 93 OR 97 OR 21 OR 22 */

                if (W.FILLER_287.W_RMOSINI.In("93", "97", "21", "22"))
                {

                    /*" -1342- MOVE ZEROS TO LC11-AA-T LC11-MM-T LC11-DD-T */
                    _.Move(0, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_DD_T);

                    /*" -1343- ELSE */
                }
                else
                {


                    /*" -1344- MOVE ENDOS-DTTERVIG TO WDATA-R */
                    _.Move(ENDOS_DTTERVIG, W.WDATA_R);

                    /*" -1345- MOVE WDATA-AA TO LC11-AA-T */
                    _.Move(W.WDATA.WDATA_AA, W.LC11.LC11_DTTERVIG.LC11_AA_T);

                    /*" -1346- MOVE WDATA-MM TO LC11-MM-T */
                    _.Move(W.WDATA.WDATA_MM, W.LC11.LC11_DTTERVIG.LC11_MM_T);

                    /*" -1346- MOVE WDATA-DD TO LC11-DD-T. */
                    _.Move(W.WDATA.WDATA_DD, W.LC11.LC11_DTTERVIG.LC11_DD_T);
                }

            }


        }

        [StopWatch]
        /*" M-270-000-LER-V1ENDOSSO-DB-SELECT-1 */
        public void M_270_000_LER_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -1324- EXEC SQL SELECT DTINIVIG, DTTERVIG, CORRECAO INTO :ENDOS-DTINIVIG, :ENDOS-DTTERVIG, :ENDOS-CORRECAO FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :MEST-NUM-APOL AND NRENDOS = :MEST-NRENDOS END-EXEC. */

            var m_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1 = new M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_NRENDOS = MEST_NRENDOS.ToString(),
            };

            var executed_1 = M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1.Execute(m_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOS_DTINIVIG, ENDOS_DTINIVIG);
                _.Move(executed_1.ENDOS_DTTERVIG, ENDOS_DTTERVIG);
                _.Move(executed_1.ENDOS_CORRECAO, ENDOS_CORRECAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-300-000-LER-V1RAMO-SECTION */
        private void M_300_000_LER_V1RAMO_SECTION()
        {
            /*" -1355- MOVE '300-000-LER-V1RAMO' TO PARAGRAFO. */
            _.Move("300-000-LER-V1RAMO", W.WABEND.PARAGRAFO);

            /*" -1357- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", W.WABEND.WNR_EXEC_SQL);

            /*" -1363- PERFORM M_300_000_LER_V1RAMO_DB_SELECT_1 */

            M_300_000_LER_V1RAMO_DB_SELECT_1();

            /*" -1366- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1367- DISPLAY 'SI0112B-RAMO NAO CADASTRADO' */
                _.Display($"SI0112B-RAMO NAO CADASTRADO");

                /*" -1369- DISPLAY 'RAMO   = ' V1RAMO-RAMO ' MODALIDA =  ' APOL-MODALIDA */

                $"RAMO   = {V1RAMO_RAMO} MODALIDA =  {APOL_MODALIDA}"
                .Display();

                /*" -1370- MOVE ' ' TO LC09-NOMERAMO */
                _.Move(" ", W.LC09.LC09_NOMERAMO);

                /*" -1371- ELSE */
            }
            else
            {


                /*" -1371- MOVE V1RAMO-NOMERAMO TO LC09-NOMERAMO. */
                _.Move(V1RAMO_NOMERAMO, W.LC09.LC09_NOMERAMO);
            }


        }

        [StopWatch]
        /*" M-300-000-LER-V1RAMO-DB-SELECT-1 */
        public void M_300_000_LER_V1RAMO_DB_SELECT_1()
        {
            /*" -1363- EXEC SQL SELECT NOMERAMO INTO :V1RAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :V1RAMO-RAMO AND MODALIDA = :APOL-MODALIDA END-EXEC. */

            var m_300_000_LER_V1RAMO_DB_SELECT_1_Query1 = new M_300_000_LER_V1RAMO_DB_SELECT_1_Query1()
            {
                APOL_MODALIDA = APOL_MODALIDA.ToString(),
                V1RAMO_RAMO = V1RAMO_RAMO.ToString(),
            };

            var executed_1 = M_300_000_LER_V1RAMO_DB_SELECT_1_Query1.Execute(m_300_000_LER_V1RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_NOMERAMO, V1RAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-330-000-LER-V1ORDECOSCED-SECTION */
        private void M_330_000_LER_V1ORDECOSCED_SECTION()
        {
            /*" -1380- MOVE '330-000-LER-V1ORDECOSCED' TO PARAGRAFO. */
            _.Move("330-000-LER-V1ORDECOSCED", W.WABEND.PARAGRAFO);

            /*" -1382- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", W.WABEND.WNR_EXEC_SQL);

            /*" -1389- PERFORM M_330_000_LER_V1ORDECOSCED_DB_SELECT_1 */

            M_330_000_LER_V1ORDECOSCED_DB_SELECT_1();

            /*" -1392- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1393- DISPLAY 'SI0112B - APOLICE NAO CADASTRADA NA V1ORDECOSCED' */
                _.Display($"SI0112B - APOLICE NAO CADASTRADA NA V1ORDECOSCED");

                /*" -1396- DISPLAY ' NUM_APOLICE = ' MEST-NUM-APOL ' NRENDOS     = ' MEST-NRENDOS ' CODCOSS     = ' V1RELA-CONGE */

                $" NUM_APOLICE = {MEST_NUM_APOL} NRENDOS     = {MEST_NRENDOS} CODCOSS     = {V1RELA_CONGE}"
                .Display();

                /*" -1397- MOVE ZEROS TO LC11-NRORDEM */
                _.Move(0, W.LC11.LC11_NRORDEM);

                /*" -1398- ELSE */
            }
            else
            {


                /*" -1398- MOVE ORDEM-NRORDEM TO LC11-NRORDEM. */
                _.Move(ORDEM_NRORDEM, W.LC11.LC11_NRORDEM);
            }


        }

        [StopWatch]
        /*" M-330-000-LER-V1ORDECOSCED-DB-SELECT-1 */
        public void M_330_000_LER_V1ORDECOSCED_DB_SELECT_1()
        {
            /*" -1389- EXEC SQL SELECT ORDEM_CEDIDO INTO :ORDEM-NRORDEM FROM SEGUROS.V1ORDECOSCED WHERE NUM_APOLICE = :MEST-NUM-APOL AND NRENDOS = :MEST-NRENDOS AND CODCOSS = :V1RELA-CONGE END-EXEC. */

            var m_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1 = new M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_NRENDOS = MEST_NRENDOS.ToString(),
                V1RELA_CONGE = V1RELA_CONGE.ToString(),
            };

            var executed_1 = M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1.Execute(m_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ORDEM_NRORDEM, ORDEM_NRORDEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-360-000-LER-V1APOLCOSCED-SECTION */
        private void M_360_000_LER_V1APOLCOSCED_SECTION()
        {
            /*" -1407- MOVE '360-000-LER-V1APOLCOSCED' TO PARAGRAFO. */
            _.Move("360-000-LER-V1APOLCOSCED", W.WABEND.PARAGRAFO);

            /*" -1409- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", W.WABEND.WNR_EXEC_SQL);

            /*" -1418- PERFORM M_360_000_LER_V1APOLCOSCED_DB_DECLARE_1 */

            M_360_000_LER_V1APOLCOSCED_DB_DECLARE_1();

            /*" -1422- PERFORM M_360_000_LER_V1APOLCOSCED_DB_OPEN_1 */

            M_360_000_LER_V1APOLCOSCED_DB_OPEN_1();

            /*" -1427- PERFORM M_360_000_LER_V1APOLCOSCED_DB_FETCH_1 */

            M_360_000_LER_V1APOLCOSCED_DB_FETCH_1();

            /*" -1430- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1431- DISPLAY 'SI0112B - NAO EXISTE NA V1APOLCOSCED' */
                _.Display($"SI0112B - NAO EXISTE NA V1APOLCOSCED");

                /*" -1433- DISPLAY 'APOLICE  = ' MEST-NUM-APOL ' CODCOSS = ' V1RELA-CONGE */

                $"APOLICE  = {MEST_NUM_APOL} CODCOSS = {V1RELA_CONGE}"
                .Display();

                /*" -1434- MOVE 'S' TO WPROXIMO */
                _.Move("S", W.WPROXIMO);

                /*" -1435- ELSE */
            }
            else
            {


                /*" -1437- MOVE APCOSSC-PCPARTIC TO LC09-PCPARTIC */
                _.Move(APCOSSC_PCPARTIC, W.LC09.LC09_PCPARTIC);

                /*" -1439- PERFORM 370-000-LER-V1MOEDA. */

                M_370_000_LER_V1MOEDA_SECTION();
            }


            /*" -1441- PERFORM M_360_000_LER_V1APOLCOSCED_DB_CLOSE_1 */

            M_360_000_LER_V1APOLCOSCED_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-360-000-LER-V1APOLCOSCED-DB-OPEN-1 */
        public void M_360_000_LER_V1APOLCOSCED_DB_OPEN_1()
        {
            /*" -1422- EXEC SQL OPEN TAPOCOS END-EXEC. */

            TAPOCOS.Open();

        }

        [StopWatch]
        /*" M-360-000-LER-V1APOLCOSCED-DB-FETCH-1 */
        public void M_360_000_LER_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -1427- EXEC SQL FETCH TAPOCOS INTO :APCOSSC-PCPARTIC, :APCOSSC-DTINIVIG END-EXEC. */

            if (TAPOCOS.Fetch())
            {
                _.Move(TAPOCOS.APCOSSC_PCPARTIC, APCOSSC_PCPARTIC);
                _.Move(TAPOCOS.APCOSSC_DTINIVIG, APCOSSC_DTINIVIG);
            }

        }

        [StopWatch]
        /*" M-360-000-LER-V1APOLCOSCED-DB-CLOSE-1 */
        public void M_360_000_LER_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -1441- EXEC SQL CLOSE TAPOCOS END-EXEC. */

            TAPOCOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-370-000-LER-V1MOEDA-SECTION */
        private void M_370_000_LER_V1MOEDA_SECTION()
        {
            /*" -1450- MOVE '370-000-LER-V1MOEDA' TO PARAGRAFO. */
            _.Move("370-000-LER-V1MOEDA", W.WABEND.PARAGRAFO);

            /*" -1452- MOVE '370' TO WNR-EXEC-SQL. */
            _.Move("370", W.WABEND.WNR_EXEC_SQL);

            /*" -1461- PERFORM M_370_000_LER_V1MOEDA_DB_SELECT_1 */

            M_370_000_LER_V1MOEDA_DB_SELECT_1();

            /*" -1464- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1465- DISPLAY 'SI0112B - MOEDA NAO CADASTRADA' */
                _.Display($"SI0112B - MOEDA NAO CADASTRADA");

                /*" -1467- DISPLAY ' MOEDA   = ' MEST-MOEDA-SINI ' DTMOVTO = ' THIST-DTMOVTO */

                $" MOEDA   = {MEST_MOEDA_SINI} DTMOVTO = {THIST_DTMOVTO}"
                .Display();

                /*" -1468- MOVE 'S' TO WPROXIMO */
                _.Move("S", W.WPROXIMO);

                /*" -1469- ELSE */
            }
            else
            {


                /*" -1473- MOVE MOEDA-SIGLUNIM TO LC11-SIGLUNIM */
                _.Move(MOEDA_SIGLUNIM, W.LC11.LC11_SIGLUNIM);

                /*" -1475- MOVE THIST-VAL-OPERACAO TO LC34-VAL-TOTAL */
                _.Move(THIST_VAL_OPERACAO, W.LC34.LC34_VAL_TOTAL);

                /*" -1476- MOVE ZEROS TO W01P1502 */
                _.Move(0, W.W01P1502);

                /*" -1479- COMPUTE W01P1502 = THIST-VAL-OPERACAO * APCOSSC-PCPARTIC / 100 */
                W.W01P1502.Value = THIST_VAL_OPERACAO * APCOSSC_PCPARTIC / 100f;

                /*" -1481- MOVE W01P1502 TO LC34-SUA-PARTIC */
                _.Move(W.W01P1502, W.LC34.LC34_SUA_PARTIC);

                /*" -1482- MOVE ZEROS TO W01P1502 */
                _.Move(0, W.W01P1502);

                /*" -1485- COMPUTE W01P1502 = THIST-VAL-OPERACAO * (100 - MEST-PCPARTIC) / 100 */
                W.W01P1502.Value = THIST_VAL_OPERACAO * (100 - MEST_PCPARTIC) / 100f;

                /*" -1489- MOVE W01P1502 TO LC34-TOT-COSSEG */
                _.Move(W.W01P1502, W.LC34.LC34_TOT_COSSEG);

                /*" -1490- MOVE ZEROS TO W01P1505 */
                _.Move(0, W.W01P1505);

                /*" -1492- COMPUTE W01P1505 = THIST-VAL-OPERACAO / MOEDA-VLCRUZAD */
                W.W01P1505.Value = THIST_VAL_OPERACAO / MOEDA_VLCRUZAD;

                /*" -1494- MOVE W01P1505 TO LC35-VAL-TOTAL */
                _.Move(W.W01P1505, W.LC35.LC35_VAL_TOTAL);

                /*" -1495- MOVE ZEROS TO W02P1505 */
                _.Move(0, W.W02P1505);

                /*" -1498- COMPUTE W02P1505 = W01P1505 * APCOSSC-PCPARTIC / 100 */
                W.W02P1505.Value = W.W01P1505 * APCOSSC_PCPARTIC / 100f;

                /*" -1500- MOVE W02P1505 TO LC35-SUA-PARTIC */
                _.Move(W.W02P1505, W.LC35.LC35_SUA_PARTIC);

                /*" -1501- MOVE ZEROS TO W02P1505 */
                _.Move(0, W.W02P1505);

                /*" -1504- COMPUTE W02P1505 = W01P1505 * (100 - MEST-PCPARTIC) / 100 */
                W.W02P1505.Value = W.W01P1505 * (100 - MEST_PCPARTIC) / 100f;

                /*" -1504- MOVE W02P1505 TO LC35-TOT-COSSEG. */
                _.Move(W.W02P1505, W.LC35.LC35_TOT_COSSEG);
            }


        }

        [StopWatch]
        /*" M-370-000-LER-V1MOEDA-DB-SELECT-1 */
        public void M_370_000_LER_V1MOEDA_DB_SELECT_1()
        {
            /*" -1461- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :MOEDA-VLCRUZAD, :MOEDA-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :MEST-MOEDA-SINI AND DTINIVIG <= :THIST-DTMOVTO AND DTTERVIG >= :THIST-DTMOVTO END-EXEC. */

            var m_370_000_LER_V1MOEDA_DB_SELECT_1_Query1 = new M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1()
            {
                MEST_MOEDA_SINI = MEST_MOEDA_SINI.ToString(),
                THIST_DTMOVTO = THIST_DTMOVTO.ToString(),
            };

            var executed_1 = M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1.Execute(m_370_000_LER_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDA_VLCRUZAD, MOEDA_VLCRUZAD);
                _.Move(executed_1.MOEDA_SIGLUNIM, MOEDA_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/

        [StopWatch]
        /*" M-410-000-LER-V1APOLITEM-SECTION */
        private void M_410_000_LER_V1APOLITEM_SECTION()
        {
            /*" -1512- MOVE '410-000-LER-V1APOLITEM' TO PARAGRAFO. */
            _.Move("410-000-LER-V1APOLITEM", W.WABEND.PARAGRAFO);

            /*" -1513- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", W.WABEND.WNR_EXEC_SQL);

            /*" -1515- MOVE MEST-NRCERTIF TO MEST-NRITEM. */
            _.Move(MEST_NRCERTIF, MEST_NRITEM);

            /*" -1523- PERFORM M_410_000_LER_V1APOLITEM_DB_SELECT_1 */

            M_410_000_LER_V1APOLITEM_DB_SELECT_1();

            /*" -1526- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1527- DISPLAY 'SI0112B - NAO EXISTE V1APOLITEM' */
                _.Display($"SI0112B - NAO EXISTE V1APOLITEM");

                /*" -1531- DISPLAY ' NUM_APOLICE = ' MEST-NUM-APOL ' NRENDOS     = ' MEST-NRENDOS ' NRITEM      = ' MEST-NRITEM */

                $" NUM_APOLICE = {MEST_NUM_APOL} NRENDOS     = {MEST_NRENDOS} NRITEM      = {MEST_NRITEM}"
                .Display();

                /*" -1532- MOVE SPACES TO LC19-DESCRITEM */
                _.Move("", W.LC19.LC19_DESCRITEM);

                /*" -1533- ELSE */
            }
            else
            {


                /*" -1533- MOVE APITE-DESCRITEM TO LC19-DESCRITEM. */
                _.Move(APITE_DESCRITEM, W.LC19.LC19_DESCRITEM);
            }


        }

        [StopWatch]
        /*" M-410-000-LER-V1APOLITEM-DB-SELECT-1 */
        public void M_410_000_LER_V1APOLITEM_DB_SELECT_1()
        {
            /*" -1523- EXEC SQL SELECT DESCR_ITEM INTO :APITE-DESCRITEM FROM SEGUROS.V1APOLITEM WHERE NUM_APOLICE = :MEST-NUM-APOL AND NRENDOS = :MEST-NRENDOS AND NRITEM = :MEST-NRITEM END-EXEC. */

            var m_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1 = new M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_NRENDOS = MEST_NRENDOS.ToString(),
                MEST_NRITEM = MEST_NRITEM.ToString(),
            };

            var executed_1 = M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1.Execute(m_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APITE_DESCRITEM, APITE_DESCRITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/

        [StopWatch]
        /*" M-420-000-LER-V1APOLVEIC-SECTION */
        private void M_420_000_LER_V1APOLVEIC_SECTION()
        {
            /*" -1579- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-450-000-LER-V1DESCRVEI-SECTION */
        private void M_450_000_LER_V1DESCRVEI_SECTION()
        {
            /*" -1607- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_450_999_EXIT*/

        [StopWatch]
        /*" M-480-000-LER-V1AVERBNAC-SECTION */
        private void M_480_000_LER_V1AVERBNAC_SECTION()
        {
            /*" -1676- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_480_999_EXIT*/

        [StopWatch]
        /*" M-510-000-LER-V1AVERBINT-SECTION */
        private void M_510_000_LER_V1AVERBINT_SECTION()
        {
            /*" -1743- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_999_EXIT*/

        [StopWatch]
        /*" M-570-000-LER-V1SEGURAVG-SECTION */
        private void M_570_000_LER_V1SEGURAVG_SECTION()
        {
            /*" -1750- MOVE '570-000-LER-V1SEGURAVG' TO PARAGRAFO. */
            _.Move("570-000-LER-V1SEGURAVG", W.WABEND.PARAGRAFO);

            /*" -1752- MOVE '570' TO WNR-EXEC-SQL. */
            _.Move("570", W.WABEND.WNR_EXEC_SQL);

            /*" -1760- PERFORM M_570_000_LER_V1SEGURAVG_DB_SELECT_1 */

            M_570_000_LER_V1SEGURAVG_DB_SELECT_1();

            /*" -1763- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1764- DISPLAY 'SI0112B - NAO CADASTRADO NA V1SEGURAVG' */
                _.Display($"SI0112B - NAO CADASTRADO NA V1SEGURAVG");

                /*" -1768- DISPLAY 'APOLICE = ' MEST-NUM-APOL ' CODSUBES = ' MEST-CODSUBES ' NRCERTIF = ' MEST-NRCERTIF ' IDTPSEGU = ' MEST-IDTPSEGU */

                $"APOLICE = {MEST_NUM_APOL} CODSUBES = {MEST_CODSUBES} NRCERTIF = {MEST_NRCERTIF} IDTPSEGU = {MEST_IDTPSEGU}"
                .Display();

                /*" -1770- MOVE SPACES TO CLIEN-NOME LC09-NOME */
                _.Move("", CLIEN_NOME, W.LC09.LC09_NOME);

                /*" -1771- MOVE ZEROS TO SEGVG-DTNASCIM */
                _.Move(0, SEGVG_DTNASCIM);

                /*" -1772- ELSE */
            }
            else
            {


                /*" -1772- PERFORM 575-000-LER-V1CLIENTE. */

                M_575_000_LER_V1CLIENTE_SECTION();
            }


        }

        [StopWatch]
        /*" M-570-000-LER-V1SEGURAVG-DB-SELECT-1 */
        public void M_570_000_LER_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -1760- EXEC SQL SELECT COD_CLIENTE, DATA_NASCIMENTO INTO :SEGVG-COD-CLIENTE, :SEGVG-DTNASCIM FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :MEST-NUM-APOL AND COD_SUBGRUPO = :MEST-CODSUBES AND NUM_CERTIFICADO = :MEST-NRCERTIF AND TIPO_SEGURADO = :MEST-IDTPSEGU END-EXEC. */

            var m_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 = new M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
                MEST_NRCERTIF = MEST_NRCERTIF.ToString(),
                MEST_IDTPSEGU = MEST_IDTPSEGU.ToString(),
            };

            var executed_1 = M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1.Execute(m_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVG_COD_CLIENTE, SEGVG_COD_CLIENTE);
                _.Move(executed_1.SEGVG_DTNASCIM, SEGVG_DTNASCIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_570_999_EXIT*/

        [StopWatch]
        /*" M-575-000-LER-V1CLIENTE-SECTION */
        private void M_575_000_LER_V1CLIENTE_SECTION()
        {
            /*" -1781- MOVE '575-000-LER-V1CLIENTE' TO PARAGRAFO. */
            _.Move("575-000-LER-V1CLIENTE", W.WABEND.PARAGRAFO);

            /*" -1783- MOVE '575' TO WNR-EXEC-SQL. */
            _.Move("575", W.WABEND.WNR_EXEC_SQL);

            /*" -1788- PERFORM M_575_000_LER_V1CLIENTE_DB_SELECT_1 */

            M_575_000_LER_V1CLIENTE_DB_SELECT_1();

            /*" -1791- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1792- DISPLAY 'SI0112B - CLIENTE NAO CADASTRADO' */
                _.Display($"SI0112B - CLIENTE NAO CADASTRADO");

                /*" -1793- DISPLAY 'CLIENTE = ' SEGVG-COD-CLIENTE */
                _.Display($"CLIENTE = {SEGVG_COD_CLIENTE}");

                /*" -1795- MOVE SPACES TO CLIEN-NOME LC09-NOME */
                _.Move("", CLIEN_NOME, W.LC09.LC09_NOME);

                /*" -1796- ELSE */
            }
            else
            {


                /*" -1796- MOVE CLIEN-NOME TO LC09-NOME. */
                _.Move(CLIEN_NOME, W.LC09.LC09_NOME);
            }


        }

        [StopWatch]
        /*" M-575-000-LER-V1CLIENTE-DB-SELECT-1 */
        public void M_575_000_LER_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1788- EXEC SQL SELECT NOME_RAZAO INTO :CLIEN-NOME FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :SEGVG-COD-CLIENTE END-EXEC. */

            var m_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1 = new M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1()
            {
                SEGVG_COD_CLIENTE = SEGVG_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1.Execute(m_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIEN_NOME, CLIEN_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_575_999_EXIT*/

        [StopWatch]
        /*" M-576-000-LER-V1CONDTEC-SECTION */
        private void M_576_000_LER_V1CONDTEC_SECTION()
        {
            /*" -1805- MOVE '576-000-LER-V1CONDTEC' TO PARAGRAFO. */
            _.Move("576-000-LER-V1CONDTEC", W.WABEND.PARAGRAFO);

            /*" -1807- MOVE '576' TO WNR-EXEC-SQL. */
            _.Move("576", W.WABEND.WNR_EXEC_SQL);

            /*" -1819- PERFORM M_576_000_LER_V1CONDTEC_DB_SELECT_1 */

            M_576_000_LER_V1CONDTEC_DB_SELECT_1();

            /*" -1822- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1823- DISPLAY 'SI0112B - REGISTRO NAO CADASTRADO (V1CONDTEC) ' */
                _.Display($"SI0112B - REGISTRO NAO CADASTRADO (V1CONDTEC) ");

                /*" -1824- DISPLAY 'APOLICE = ' MEST-NUM-APOL */
                _.Display($"APOLICE = {MEST_NUM_APOL}");

                /*" -1825- DISPLAY 'SUBGRUPO = ' MEST-CODSUBES */
                _.Display($"SUBGRUPO = {MEST_CODSUBES}");

                /*" -1826- MOVE SPACES TO LC31-GARANTIA */
                _.Move("", W.LC31.LC31_GARANTIA);

                /*" -1828- GO TO 576-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_576_999_EXIT*/ //GOTO
                return;
            }


            /*" -1830- MOVE 1 TO WIND */
            _.Move(1, W.WIND);

            /*" -1832- MOVE SPACES TO LC31-GARANTIA */
            _.Move("", W.LC31.LC31_GARANTIA);

            /*" -1833- IF V1COND-GARAN-IEA GREATER ZEROS */

            if (V1COND_GARAN_IEA > 00)
            {

                /*" -1834- MOVE 'IEA' TO LC31-DESCR (WIND) */
                _.Move("IEA", W.LC31.FILLER_238[W.WIND].LC31_DESCR);

                /*" -1836- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -1837- IF V1COND-GARAN-IPA GREATER ZEROS */

            if (V1COND_GARAN_IPA > 00)
            {

                /*" -1838- MOVE 'IPA' TO LC31-DESCR (WIND) */
                _.Move("IPA", W.LC31.FILLER_238[W.WIND].LC31_DESCR);

                /*" -1840- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -1841- IF V1COND-GARAN-IPD GREATER ZEROS */

            if (V1COND_GARAN_IPD > 00)
            {

                /*" -1842- MOVE 'IPD' TO LC31-DESCR (WIND) */
                _.Move("IPD", W.LC31.FILLER_238[W.WIND].LC31_DESCR);

                /*" -1844- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -1845- IF V1COND-GARAN-HD GREATER ZEROS */

            if (V1COND_GARAN_HD > 00)
            {

                /*" -1846- MOVE 'HD' TO LC31-DESCR (WIND) */
                _.Move("HD", W.LC31.FILLER_238[W.WIND].LC31_DESCR);

                /*" -1848- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -1848- MOVE ZEROS TO WIND. */
            _.Move(0, W.WIND);

        }

        [StopWatch]
        /*" M-576-000-LER-V1CONDTEC-DB-SELECT-1 */
        public void M_576_000_LER_V1CONDTEC_DB_SELECT_1()
        {
            /*" -1819- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :V1COND-GARAN-IEA, :V1COND-GARAN-IPA, :V1COND-GARAN-IPD, :V1COND-GARAN-HD FROM SEGUROS.V1CONDTEC WHERE NUM_APOLICE = :MEST-NUM-APOL AND COD_SUBGRUPO = :MEST-CODSUBES END-EXEC. */

            var m_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1 = new M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
            };

            var executed_1 = M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1.Execute(m_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COND_GARAN_IEA, V1COND_GARAN_IEA);
                _.Move(executed_1.V1COND_GARAN_IPA, V1COND_GARAN_IPA);
                _.Move(executed_1.V1COND_GARAN_IPD, V1COND_GARAN_IPD);
                _.Move(executed_1.V1COND_GARAN_HD, V1COND_GARAN_HD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_576_999_EXIT*/

        [StopWatch]
        /*" M-700-000-IMPRIME-SECTION */
        private void M_700_000_IMPRIME_SECTION()
        {
            /*" -1858- MOVE '700-000-IMPRIME' TO PARAGRAFO. */
            _.Move("700-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -1859- ADD 1 TO WCONT-PAG */
            W.WCONT_PAG.Value = W.WCONT_PAG + 1;

            /*" -1861- MOVE WCONT-PAG TO LC01-PAG */
            _.Move(W.WCONT_PAG, W.LC01.LC01_PAG);

            /*" -1862- WRITE REG-SI0112M1 FROM LC01 AFTER 1 */
            _.Move(W.LC01.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1863- WRITE REG-SI0112M1 FROM LC02 AFTER 1 */
            _.Move(W.LC02.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1864- WRITE REG-SI0112M1 FROM LC03 AFTER 1 */
            _.Move(W.LC03.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1865- WRITE REG-SI0112M1 FROM LC04 AFTER 2 */
            _.Move(W.LC04.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1866- WRITE REG-SI0112M1 FROM LC05 AFTER 1 */
            _.Move(W.LC05.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1867- WRITE REG-SI0112M1 FROM LC06 AFTER 2 */
            _.Move(W.LC06.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1868- WRITE REG-SI0112M1 FROM LC07 AFTER 2 */
            _.Move(W.LC07.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1869- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1870- WRITE REG-SI0112M1 FROM LC08 AFTER 1 */
            _.Move(W.LC08.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1871- WRITE REG-SI0112M1 FROM LC09 AFTER 1 */
            _.Move(W.LC09.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1872- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1873- WRITE REG-SI0112M1 FROM LC10 AFTER 1 */
            _.Move(W.LC10.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1874- WRITE REG-SI0112M1 FROM LC11 AFTER 1 */
            _.Move(W.LC11.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1875- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1876- WRITE REG-SI0112M1 FROM LC12 AFTER 1 */
            _.Move(W.LC12.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1877- WRITE REG-SI0112M1 FROM LC13 AFTER 1 */
            _.Move(W.LC13.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1878- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1879- WRITE REG-SI0112M1 FROM LC14 AFTER 1 */
            _.Move(W.LC14.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1880- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1881- WRITE REG-SI0112M1 FROM LC15 AFTER 1 */
            _.Move(W.LC15.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1882- WRITE REG-SI0112M1 FROM LC16 AFTER 1 */
            _.Move(W.LC16.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1883- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1884- WRITE REG-SI0112M1 FROM LC17 AFTER 1 */
            _.Move(W.LC17.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1885- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1886- WRITE REG-SI0112M1 FROM LC18 AFTER 1 */
            _.Move(W.LC18.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1887- WRITE REG-SI0112M1 FROM LC19 AFTER 1 */
            _.Move(W.LC19.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1888- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1889- WRITE REG-SI0112M1 FROM LC20 AFTER 1 */
            _.Move(W.LC20.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1890- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1891- WRITE REG-SI0112M1 FROM LC21 AFTER 1 */
            _.Move(W.LC21.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1892- WRITE REG-SI0112M1 FROM LC22 AFTER 1 */
            _.Move(W.LC22.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1893- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1894- WRITE REG-SI0112M1 FROM LC23 AFTER 1 */
            _.Move(W.LC23.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1895- WRITE REG-SI0112M1 FROM LC24 AFTER 1 */
            _.Move(W.LC24.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1896- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1897- WRITE REG-SI0112M1 FROM LC25 AFTER 1 */
            _.Move(W.LC25.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1898- WRITE REG-SI0112M1 FROM LC26 AFTER 1 */
            _.Move(W.LC26.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1899- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1900- WRITE REG-SI0112M1 FROM LC27 AFTER 1 */
            _.Move(W.LC27.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1901- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1902- WRITE REG-SI0112M1 FROM LC28 AFTER 1 */
            _.Move(W.LC28.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1903- WRITE REG-SI0112M1 FROM LC29 AFTER 1 */
            _.Move(W.LC29.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1904- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1905- WRITE REG-SI0112M1 FROM LC30 AFTER 1 */
            _.Move(W.LC30.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1906- WRITE REG-SI0112M1 FROM LC31 AFTER 1 */
            _.Move(W.LC31.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1907- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1908- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1909- WRITE REG-SI0112M1 FROM LC32 AFTER 1 */
            _.Move(W.LC32.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1910- WRITE REG-SI0112M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1911- WRITE REG-SI0112M1 FROM LC33 AFTER 1 */
            _.Move(W.LC33.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1912- WRITE REG-SI0112M1 FROM LC34 AFTER 1 */
            _.Move(W.LC34.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1913- WRITE REG-SI0112M1 FROM LC35 AFTER 1 */
            _.Move(W.LC35.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1914- WRITE REG-SI0112M1 FROM LC36 AFTER 1 */
            _.Move(W.LC36.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1916- WRITE REG-SI0112M1 FROM LCB AFTER 10. */
            _.Move(W.LCB.GetMoveValues(), REG_SI0112M1);

            SI0112M1.Write(REG_SI0112M1.GetMoveValues().ToString());

            /*" -1916- ADD 1 TO WIMPRES. */
            W.WIMPRES.Value = W.WIMPRES + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_999_EXIT*/

        [StopWatch]
        /*" M-750-000-LIMPA-LINHAS-SECTION */
        private void M_750_000_LIMPA_LINHAS_SECTION()
        {
            /*" -1926- MOVE '750-000-LIMPA-LINHAS' TO PARAGRAFO. */
            _.Move("750-000-LIMPA-LINHAS", W.WABEND.PARAGRAFO);

            /*" -1957- MOVE SPACES TO LC01-EMPRESA LC05-NOMECONG LC06-REFER LC09-NOME LC09-NOMERAMO LC11-SIGLUNIM LC13-NOMFAV LC16-DESCVEIC LC16-PLACALET LC16-CHASSIS LC19-DESCRITEM LC22-TRANSP LC22-PLACLET LC22-PREFIXO LC22-EMBARQUE LC24-EMPRESA LC24-MERCAD LC24-NATUREZA LC24-COBERTUR LC26-ORIGEM LC26-DESTINO LC26-LOCAL LC26-CIDADE LC29-ESTIPUL LC29-SEG-PRI LC29-SEG-SIN LC31-GARANTIA LC33-REFER LC16-PLACANR LC22-PLACNUM */
            _.Move("", W.LC01.LC01_EMPRESA, W.LC05.LC05_NOMECONG, W.LC06.LC06_REFER, W.LC09.LC09_NOME, W.LC09.LC09_NOMERAMO, W.LC11.LC11_SIGLUNIM, W.LC13.LC13_NOMFAV, W.LC16.LC16_DESCVEIC, W.LC16.LC16_PLACA.LC16_PLACALET, W.LC16.LC16_CHASSIS, W.LC19.LC19_DESCRITEM, W.LC22.LC22_TRANSP, W.LC22.LC22_PLACA.LC22_PLACLET, W.LC22.LC22_PREFIXO, W.LC22.LC22_EMBARQUE, W.LC24.LC24_EMPRESA, W.LC24.LC24_MERCAD, W.LC24.LC24_NATUREZA, W.LC24.LC24_COBERTUR, W.LC26.LC26_ORIGEM, W.LC26.LC26_DESTINO, W.LC26.LC26_LOCAL, W.LC26.LC26_CIDADE, W.LC29.LC29_ESTIPUL, W.LC29.LC29_SEG_PRI, W.LC29.LC29_SEG_SIN, W.LC31.LC31_GARANTIA, W.LC33.LC33_REFER, W.LC16.LC16_PLACA.LC16_PLACANR, W.LC22.LC22_PLACA.LC22_PLACNUM);

            /*" -1993- MOVE ZEROS TO LC01-PAG LC05-CODCOSS LC06-SINISTRO LC09-PCPARTIC LC09-DD-SINI LC09-MM-SINI LC09-AA-SINI LC09-DD-AVISO LC09-MM-AVISO LC09-AA-AVISO LC11-APOLICE LC11-NRORDEM LC11-DD-I LC11-MM-I LC11-AA-I LC11-DD-T LC11-MM-T LC11-AA-T LC11-ITEM LC11-ISITEM LC13-SINIRB LC16-ANOVEICL LC22-AVERBACAO LC31-DIA1 LC31-MES1 LC31-ANO1 LC31-DIA2 LC31-MES2 LC31-ANO2 LC34-VAL-TOTAL LC34-SUA-PARTIC LC34-TOT-COSSEG LC35-VAL-TOTAL LC35-SUA-PARTIC LC35-TOT-COSSEG. */
            _.Move(0, W.LC01.LC01_PAG, W.LC05.LC05_CODCOSS, W.LC06.LC06_SINISTRO, W.LC09.LC09_PCPARTIC, W.LC09.LC09_DTSINI.LC09_DD_SINI, W.LC09.LC09_DTSINI.LC09_MM_SINI, W.LC09.LC09_DTSINI.LC09_AA_SINI, W.LC09.LC09_DTAVISO.LC09_DD_AVISO, W.LC09.LC09_DTAVISO.LC09_MM_AVISO, W.LC09.LC09_DTAVISO.LC09_AA_AVISO, W.LC11.LC11_APOLICE, W.LC11.LC11_NRORDEM, W.LC11.LC11_DTINIVIG.LC11_DD_I, W.LC11.LC11_DTINIVIG.LC11_MM_I, W.LC11.LC11_DTINIVIG.LC11_AA_I, W.LC11.LC11_DTTERVIG.LC11_DD_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_ITEM, W.LC11.LC11_ISITEM, W.LC13.LC13_SINIRB, W.LC16.LC16_ANOVEICL, W.LC22.LC22_AVERBACAO, W.LC31.LC31_DATA1.LC31_DIA1, W.LC31.LC31_DATA1.LC31_MES1, W.LC31.LC31_DATA1.LC31_ANO1, W.LC31.LC31_DATA2.LC31_DIA2, W.LC31.LC31_DATA2.LC31_MES2, W.LC31.LC31_DATA2.LC31_ANO2, W.LC34.LC34_VAL_TOTAL, W.LC34.LC34_SUA_PARTIC, W.LC34.LC34_TOT_COSSEG, W.LC35.LC35_VAL_TOTAL, W.LC35.LC35_SUA_PARTIC, W.LC35.LC35_TOT_COSSEG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_750_999_EXIT*/

        [StopWatch]
        /*" M-800-000-ATUALIZA-V0RELATORIOS-SECTION */
        private void M_800_000_ATUALIZA_V0RELATORIOS_SECTION()
        {
            /*" -2002- MOVE '800-000-ATUALIZA-V0RELATORIOS' TO PARAGRAFO. */
            _.Move("800-000-ATUALIZA-V0RELATORIOS", W.WABEND.PARAGRAFO);

            /*" -2004- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", W.WABEND.WNR_EXEC_SQL);

            /*" -2008- PERFORM M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1 */

            M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-800-000-ATUALIZA-V0RELATORIOS-DB-DELETE-1 */
        public void M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -2008- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0112B1' END-EXEC. */

            var m_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1 = new M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(m_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -2017- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -2019- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -2020- IF WLIDOS NOT EQUAL 0 */

            if (W.WLIDOS != 0)
            {

                /*" -2021- DISPLAY 'TOTAL LIDOS EMISSAO       =  ' WLIDOS */
                _.Display($"TOTAL LIDOS EMISSAO       =  {W.WLIDOS}");

                /*" -2023- DISPLAY 'TOTAL IMPRESSOS EMISSAO   =  ' WIMPRES. */
                _.Display($"TOTAL IMPRESSOS EMISSAO   =  {W.WIMPRES}");
            }


            /*" -2023- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2028- CLOSE SI0112M1. */
            SI0112M1.Close();

            /*" -2029- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -2029- DISPLAY 'SI0112B        *** FIM NORMAL ***' . */
            _.Display($"SI0112B        *** FIM NORMAL ***");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -2039- DISPLAY 'NUM_SINISTRO  = ' V1RELA-NUMSINI */
            _.Display($"NUM_SINISTRO  = {V1RELA_NUMSINI}");

            /*" -2040- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2041- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -2042- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -2043- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -2044- MOVE SQLCODE TO WSQLCODE3 . */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -2046- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -2047- CLOSE SI0112M1. */
            SI0112M1.Close();

            /*" -2047- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2048- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2050- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2050- GOBACK. */

            throw new GoBack();

        }
    }
}