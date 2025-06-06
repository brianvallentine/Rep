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
using Sias.VidaAzul.DB2.VA2513B;

namespace Code
{
    public class VA2513B
    {
        public bool IsCall { get; set; }

        public VA2513B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      * GERA COMUNICADO DE CDG PARA  FORMULARIO PRE-IMPRESSO           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    CODOPER     DESCRICAO                            OPCAOPAG   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *        112     CDG                                         =   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 -  ADAILTON DIAS                                   *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 04/02/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  19/06/98  *   TERCIO     *                       *      */
        /*"      ******************************************************************      */
        /*"      * ADEQUACAO PARA CALCULAR DATA DE POSTAGEM COM 2 DIAS UTEIS      *      */
        /*"      * VERSAO                          PRODEXTER          09/07/2003  *      */
        /*"      * (PROCURAR POR CH0703)                                          *      */
        /*"      ******************************************************************      */
        /*"      * PASSA A TRATAR OS PRODUTOS 9320 E 9321                         *      */
        /*"      * VERSAO                          TERCIO CARVALHO    29/06/2006  *      */
        /*"      * (PROCURAR POR FC0606)                                          *      */
        /*"      ******************************************************************      */
        /*"      *         TRATAR ABEND 112139                                    *      */
        /*"      *         THIAGO BLAIER                              09/03/2015  *      */
        /*"      *         V.04                                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - HISTORIA 200.461                                 *      */
        /*"      *                                                                *      */
        /*"      *             - PREPARAR PARA JV1                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/05/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVA2513B { get; set; } = new FileBasis(new PIC("X", "1500", "X(1500)"));

        public FileBasis RVA2513B
        {
            get
            {
                _.Move(RVA2513B_RECORD, _RVA2513B); VarBasis.RedefinePassValue(RVA2513B_RECORD, _RVA2513B, RVA2513B_RECORD); return _RVA2513B;
            }
        }
        public FileBasis _FVA2513B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis FVA2513B
        {
            get
            {
                _.Move(FVA2513B_RECORD, _FVA2513B); VarBasis.RedefinePassValue(FVA2513B_RECORD, _FVA2513B, FVA2513B_RECORD); return _FVA2513B;
            }
        }
        public SortBasis<VA2513B_REG_SVA2513B> SVA2513B { get; set; } = new SortBasis<VA2513B_REG_SVA2513B>(new VA2513B_REG_SVA2513B());
        /*"01            RVA2513B-RECORD     PIC X(1500).*/
        public StringBasis RVA2513B_RECORD { get; set; } = new StringBasis(new PIC("X", "1500", "X(1500)."), @"");
        /*"01            FVA2513B-RECORD     PIC X(132).*/
        public StringBasis FVA2513B_RECORD { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01            REG-SVA2513B.*/
        public VA2513B_REG_SVA2513B REG_SVA2513B { get; set; } = new VA2513B_REG_SVA2513B();
        public class VA2513B_REG_SVA2513B : VarBasis
        {
            /*"    05        SVA-NRAPOLICE       PIC  9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-CODSUBES        PIC  9(004).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CEP-G           PIC  9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        SVA-NUM-CEP.*/
            public VA2513B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VA2513B_SVA_NUM_CEP();
            public class VA2513B_SVA_NUM_CEP : VarBasis
            {
                /*"      15      SVA-CEP             PIC  9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SVA-CEP-COMPL       PIC  9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SVA-NRCERTIF        PIC  9(015).*/
            }
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-OCORHIST        PIC  9(004).*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NRTIT           PIC  9(013).*/
            public IntBasis SVA_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-NRTITCOMP       PIC  9(013).*/
            public IntBasis SVA_NRTITCOMP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-NRCPF           PIC  9(011).*/
            public IntBasis SVA_NRCPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"    05        SVA-NRPARCEL        PIC  9(004).*/
            public IntBasis SVA_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-DTVENCTO        PIC  X(010).*/
            public StringBasis SVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-VLPRMTOT        PIC  9(007)V99.*/
            public DoubleBasis SVA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V99."), 2);
            /*"    05        SVA-CODOPER         PIC  9(004).*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-ENDERECO        PIC  X(040).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SVA-BAIRRO          PIC  X(020).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05        SVA-CIDADE          PIC  X(020).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05        SVA-UF              PIC  X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05        SVA-NOME-RAZAO      PIC  X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SVA-DTNASC          PIC  X(010).*/
            public StringBasis SVA_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-IDE-SEXO        PIC  X(001).*/
            public StringBasis SVA_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-OPCOBERT        PIC  X(001).*/
            public StringBasis SVA_OPCOBERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-OPCAOPAG        PIC  X(001).*/
            public StringBasis SVA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-NOME-CORREIO    PIC  X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05        SVA-CODPRODU        PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-FONTE           PIC  9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-TEXTO           PIC  X(002).*/
            public StringBasis SVA_TEXTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            V0CLIE-IDTNASC      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis V0CLIE_IDTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-ORIG-PRODU     PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRCOPIAS       PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRTITCOMP      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            WHOST-NRCERTIF      PIC S9(015)    COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            WHOST-NRPARCEL      PIC S9(004)    COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRTIT         PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-NRTITCOMP     PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-OCORHIST      PIC S9(004)    COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRAPOLICE     PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-CODSUBES      PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODPRODU      PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODOPER       PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-MESREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1SIST-ANOREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-DTMOVABE      PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77            V0PROD-NOMPRODU     PIC  X(030).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77            V0PROD-CODPRODU     PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-CODCDT       PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODCDT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-ORIG-PRODU   PIC  X(008).*/
        public StringBasis V0PROD_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0MENS-APOLICE      PIC S9(013)    COMP-3.*/
        public IntBasis V0MENS_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0MENS-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-JDE          PIC  X(008).*/
        public StringBasis V0MENS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0MENS-JDL          PIC  X(008).*/
        public StringBasis V0MENS_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0FAIC-FAIXA        PIC S9(004)    COMP.*/
        public IntBasis V0FAIC_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0FAIC-CEPINI       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-CEPFIM       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPFIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-DESC-FAIXA   PIC  X(072).*/
        public StringBasis V0FAIC_DESC_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0FAIC-CENTRALIZA   PIC  X(072).*/
        public StringBasis V0FAIC_CENTRALIZA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0COBE-IMPMORNATU   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-IMPCONJUGE   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPCONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-IMPMORACID   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-IMPSEGCDG    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-VLPREMIO     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HIST-NRCERTIF     PIC S9(015)    COMP-3.*/
        public IntBasis V0HIST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0HIST-OCORHIST     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-NRPARCEL     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-NRTIT        PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-NRTITCOMP    PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HIST-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0HIST-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-CODPRODU     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-CDCLIENTE    PIC S9(009)    COMP.*/
        public IntBasis V0HIST_CDCLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0HIST-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0HIST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-IDSEXO       PIC  X(001).*/
        public StringBasis V0HIST_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-OPCOBERT     PIC  X(001).*/
        public StringBasis V0HIST_OPCOBERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-NRAPOLICE    PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-AGECOBR      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-FONTE        PIC S9(004)    COMP.*/
        public IntBasis V0HIST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0RELA-NRCOPIAS     PIC S9(004)    COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CLIE-NOME-RAZAO   PIC  X(040).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CLIE-CPF          PIC S9(015)    COMP-3.*/
        public IntBasis V0CLIE_CPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0CLIE-DTNASC       PIC  X(010).*/
        public StringBasis V0CLIE_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0ENDE-ENDERECO     PIC  X(040).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0ENDE-BAIRRO       PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-CIDADE       PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-UF           PIC  X(002).*/
        public StringBasis V0ENDE_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP          PIC S9(009)    COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0COND-CAR-CONJUGE  PIC S9(003)V99 COMP-3.*/
        public DoubleBasis V0COND_CAR_CONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77            V0SEGV-SIT-REGISTRO PIC  X(001).*/
        public StringBasis V0SEGV_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0SEGV-IDE-SEXO     PIC  X(001).*/
        public StringBasis V0SEGV_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V1MCEF-COD-FONTE    PIC S9(04)    COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1ACEF-COD-AGENCIA  PIC S9(04)    COMP.*/
        public IntBasis V1ACEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-ENDERFTE     PIC  X(040).*/
        public StringBasis V1FONT_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-BAIRRO       PIC  X(020).*/
        public StringBasis V1FONT_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-CIDADE       PIC  X(020).*/
        public StringBasis V1FONT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-UF           PIC  X(002).*/
        public StringBasis V1FONT_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V1FONT-CEP          PIC S9(009)    COMP.*/
        public IntBasis V1FONT_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           AREA-DE-WORK.*/
        public VA2513B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA2513B_AREA_DE_WORK();
        public class VA2513B_AREA_DE_WORK : VarBasis
        {
            /*"    05            LC01-LINHA01.*/
            public VA2513B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VA2513B_LC01_LINHA01();
            public class VA2513B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC02-LINHA02.*/
            }
            public VA2513B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new VA2513B_LC02_LINHA02();
            public class VA2513B_LC02_LINHA02 : VarBasis
            {
                /*"      10          LC02-FILLER          PIC X(070) VALUE    '%%DocumentMedia: papel1 595 842 75 white normal'.*/
                public StringBasis LC02_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
                /*"    05            LC03-LINHA03.*/
            }
            public VA2513B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new VA2513B_LC03_LINHA03();
            public class VA2513B_LC03_LINHA03 : VarBasis
            {
                /*"      10          LC03-FILLER          PIC X(070) VALUE    '%%+papel2 595 842 75 blue azul'.*/
                public StringBasis LC03_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%+papel2 595 842 75 blue azul");
                /*"    05            LC04-LINHA04.*/
            }
            public VA2513B_LC04_LINHA04 LC04_LINHA04 { get; set; } = new VA2513B_LC04_LINHA04();
            public class VA2513B_LC04_LINHA04 : VarBasis
            {
                /*"      10          LC04-FILLER          PIC X(070) VALUE    '%XRXrequeriments: duplex'.*/
                public StringBasis LC04_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%XRXrequeriments: duplex");
                /*"    05            LC05-LINHA05.*/
            }
            public VA2513B_LC05_LINHA05 LC05_LINHA05 { get; set; } = new VA2513B_LC05_LINHA05();
            public class VA2513B_LC05_LINHA05 : VarBasis
            {
                /*"      10          LC05-FILLER          PIC X(070) VALUE    '%%BeginFeature: *Duplex True'.*/
                public StringBasis LC05_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Duplex True");
                /*"    05            LC06-LINHA06.*/
            }
            public VA2513B_LC06_LINHA06 LC06_LINHA06 { get; set; } = new VA2513B_LC06_LINHA06();
            public class VA2513B_LC06_LINHA06 : VarBasis
            {
                /*"      10          LC06-FILLER          PIC X(070) VALUE    '<</Duplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Duplex true>> setpagedevice");
                /*"    05            LC07-LINHA07.*/
            }
            public VA2513B_LC07_LINHA07 LC07_LINHA07 { get; set; } = new VA2513B_LC07_LINHA07();
            public class VA2513B_LC07_LINHA07 : VarBasis
            {
                /*"      10          LC07-FILLER          PIC X(070) VALUE    '%%EndFeature'.*/
                public StringBasis LC07_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EndFeature");
                /*"    05            LC08-LINHA08.*/
            }
            public VA2513B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VA2513B_LC08_LINHA08();
            public class VA2513B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09.*/
            }
            public VA2513B_LC09_LINHA09 LC09_LINHA09 { get; set; } = new VA2513B_LC09_LINHA09();
            public class VA2513B_LC09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public VA2513B_LC09_FORM LC09_FORM { get; set; } = new VA2513B_LC09_FORM();
                public class VA2513B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE             PIC X(008).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"        15        LC09-PONTO           PIC X(001) VALUE '.'.*/
                    public StringBasis LC09_PONTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            FILLER     REDEFINES LC09-LINHA09.*/
            }
            private _REDEF_VA2513B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA2513B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA2513B_FILLER_5(); _.Move(LC09_LINHA09, _filler_5); VarBasis.RedefinePassValue(LC09_LINHA09, _filler_5, LC09_LINHA09); _filler_5.ValueChanged += () => { _.Move(_filler_5, LC09_LINHA09); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, LC09_LINHA09); }
            }  //Redefines
            public class _REDEF_VA2513B_FILLER_5 : VarBasis
            {
                /*"      10          LC09-LIN09           PIC X(023).*/
                public StringBasis LC09_LIN09 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LC10-LINHA10.*/

                public _REDEF_VA2513B_FILLER_5()
                {
                    LC09_LIN09.ValueChanged += OnValueChanged;
                }

            }
            public VA2513B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VA2513B_LC10_LINHA10();
            public class VA2513B_LC10_LINHA10 : VarBasis
            {
                /*"       10         FILLER              PIC X(006) VALUE      'TEXTO|'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"TEXTO|");
                /*"       10         FILLER              PIC X(051) VALUE      'CLIENTE|CONTRATO|DTPOSTAGEM|NUMOBJETO|DESTINATARIO|'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"CLIENTE|CONTRATO|DTPOSTAGEM|NUMOBJETO|DESTINATARIO|");
                /*"       10         FILLER              PIC X(051) VALUE      'ENDERECO|BAIRRO|CIDADE|UF|CEP|PROD-SUSEP-CNPJ'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ENDERECO|BAIRRO|CIDADE|UF|CEP|PROD_SUSEP_CNPJ");
                /*"    05            LC11-LINHA11.*/
            }
            public VA2513B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VA2513B_LC11_LINHA11();
            public class VA2513B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-TEXTO          PIC X(002).*/
                public StringBasis LC11_TEXTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE.*/
                public VA2513B_LC11_CLIENTE LC11_CLIENTE { get; set; } = new VA2513B_LC11_CLIENTE();
                public class VA2513B_LC11_CLIENTE : VarBasis
                {
                    /*"         15       LC11-NOME-TRATA.*/
                    public VA2513B_LC11_NOME_TRATA LC11_NOME_TRATA { get; set; } = new VA2513B_LC11_NOME_TRATA();
                    public class VA2513B_LC11_NOME_TRATA : VarBasis
                    {
                        /*"           20     LC11-NOME-TRATAI    PIC X(001).*/
                        public StringBasis LC11_NOME_TRATAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-NOME-TRATAC    PIC X(010).*/
                        public StringBasis LC11_NOME_TRATAC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                        /*"         15       LC11-NOME-RAZAO.*/
                    }
                    public VA2513B_LC11_NOME_RAZAO LC11_NOME_RAZAO { get; set; } = new VA2513B_LC11_NOME_RAZAO();
                    public class VA2513B_LC11_NOME_RAZAO : VarBasis
                    {
                        /*"           20     LC11-NOME-RAZAOI    PIC X(001).*/
                        public StringBasis LC11_NOME_RAZAOI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-NOME-RAZAOC    PIC X(039).*/
                        public StringBasis LC11_NOME_RAZAOC { get; set; } = new StringBasis(new PIC("X", "39", "X(039)."), @"");
                        /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                    }
                }
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CONTRATO-ECT    PIC X(030) VALUE      'CONTRATO 100134700-5'.*/
                public StringBasis LC11_CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CONTRATO 100134700-5");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTPOSTAGEM     PIC X(010).*/
                public StringBasis LC11_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEQUENCIA      PIC ZZZ.999.*/
                public IntBasis LC11_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO_END { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO       PIC X(040).*/
                public StringBasis LC11_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO         PIC X(020).*/
                public StringBasis LC11_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE         PIC X(020).*/
                public StringBasis LC11_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF             PIC X(002).*/
                public StringBasis LC11_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP            PIC 99999.*/
                public IntBasis LC11_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL      PIC 999.*/
                public IntBasis LC11_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-PRODUTO        PIC X(200) VALUE    'PI045-02/2002 Cod. prod. 9309 proc. SUSEP 10.002684/01-29    'CNPJ 34.020.354/0001-10'.*/
                public StringBasis LC11_PRODUTO { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"PI045-02/2002 Cod. prod. 9309 proc. SUSEP 10.002684/01-29    ");
                /*"    05            LC12-LINHA12.*/
            }
            public VA2513B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VA2513B_LC12_LINHA12();
            public class VA2513B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(070) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EOF");
                /*"    05            LF01-LINHA01.*/
            }
            public VA2513B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new VA2513B_LF01_LINHA01();
            public class VA2513B_LF01_LINHA01 : VarBasis
            {
                /*"      10          FILLER              PIC X(055) VALUE     '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>");
                /*"      10          FILLER              PIC X(080) VALUE     'setpagedevice'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"setpagedevice");
                /*"    05            LF02-LINHA02.*/
            }
            public VA2513B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new VA2513B_LF02_LINHA02();
            public class VA2513B_LF02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LF02-FORM.*/
                public VA2513B_LF02_FORM LF02_FORM { get; set; } = new VA2513B_LF02_FORM();
                public class VA2513B_LF02_FORM : VarBasis
                {
                    /*"        15        LF02-JDE             PIC X(004).*/
                    public StringBasis LF02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            LF03-LINHA03.*/
            }
            public VA2513B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new VA2513B_LF03_LINHA03();
            public class VA2513B_LF03_LINHA03 : VarBasis
            {
                /*"      10          FILLER               PIC X(070) VALUE     'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
                /*"    05            LF04-LINHA04.*/
            }
            public VA2513B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new VA2513B_LF04_LINHA04();
            public class VA2513B_LF04_LINHA04 : VarBasis
            {
                /*"      10          LF04-NOME-FAIXA     PIC X(072).*/
                public StringBasis LF04_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-FAIXA1         PIC X(005).*/
                public StringBasis LF04_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF04-FAIXA1C        PIC X(003).*/
                public StringBasis LF04_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(005) VALUE '  A '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                /*"      10          LF04-FAIXA2         PIC X(005).*/
                public StringBasis LF04_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF04-FAIXA2C        PIC X(003).*/
                public StringBasis LF04_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-QTD-OBJ        PIC 9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-AMARRADO       PIC ZZZ.999.*/
                public IntBasis LF04_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-SEQ-INICIAL    PIC ZZZ.999.*/
                public IntBasis LF04_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LF04-SEQ-FINAL      PIC ZZZ.999.*/
                public IntBasis LF04_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    05        LC88-LINHA88.*/
            }
            public VA2513B_LC88_LINHA88 LC88_LINHA88 { get; set; } = new VA2513B_LC88_LINHA88();
            public class VA2513B_LC88_LINHA88 : VarBasis
            {
                /*"      10      LC88-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC88_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LC89-LINHA89.*/
            }
            public VA2513B_LC89_LINHA89 LC89_LINHA89 { get; set; } = new VA2513B_LC89_LINHA89();
            public class VA2513B_LC89_LINHA89 : VarBasis
            {
                /*"      10      LC89-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LC89_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LC89-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC89_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LC99-LINHA99.*/
            }
            public VA2513B_LC99_LINHA99 LC99_LINHA99 { get; set; } = new VA2513B_LC99_LINHA99();
            public class VA2513B_LC99_LINHA99 : VarBasis
            {
                /*"      10      LC99-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LC99_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LC99-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LC99_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(031)    VALUE            '$DJDE$ JDE=1VZ6,JDL=DFAULT,END;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"$DJDE$ JDE=1VZ6,JDL=DFAULT,END;");
                /*"    05        LM01-LINHA01.*/
            }
            public VA2513B_LM01_LINHA01 LM01_LINHA01 { get; set; } = new VA2513B_LM01_LINHA01();
            public class VA2513B_LM01_LINHA01 : VarBasis
            {
                /*"      10      LM01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LM01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LM01-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LM01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(011)    VALUE             '$DJDE$ JDE='.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"$DJDE$ JDE=");
                /*"      10      LM01-JDE            PIC  X(008).*/
                public StringBasis LM01_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      FILLER              PIC  X(005)    VALUE             ',JDL='.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @",JDL=");
                /*"      10      LM01-JDL            PIC  X(006).*/
                public StringBasis LM01_JDL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"      10      FILLER              PIC  X(015)    VALUE             ',FEED=MAIN,END;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @",FEED=MAIN,END;");
                /*"    05        LV08-LINHA01.*/
            }
            public VA2513B_LV08_LINHA01 LV08_LINHA01 { get; set; } = new VA2513B_LV08_LINHA01();
            public class VA2513B_LV08_LINHA01 : VarBasis
            {
                /*"      10      LV08-CANAL-1        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_CANAL_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LV08-FONTE-1        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_FONTE_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      FILLER              PIC  X(035)    VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"      10      LV08-IMPCDG-1       PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LV08_IMPCDG_1 { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"    05        LV08-LINHA02.*/
            }
            public VA2513B_LV08_LINHA02 LV08_LINHA02 { get; set; } = new VA2513B_LV08_LINHA02();
            public class VA2513B_LV08_LINHA02 : VarBasis
            {
                /*"      10      LV08-CANAL-2        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_CANAL_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LV08-FONTE-2        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_FONTE_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      FILLER              PIC  X(043)    VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"      10      LV08-IMPCDG-2       PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LV08_IMPCDG_2 { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"    05        LV09-LINHA01.*/
            }
            public VA2513B_LV09_LINHA01 LV09_LINHA01 { get; set; } = new VA2513B_LV09_LINHA01();
            public class VA2513B_LV09_LINHA01 : VarBasis
            {
                /*"      10      LV09-CANAL          PIC  X(001)    VALUE '3'.*/
                public StringBasis LV09_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LV09-FONTE          PIC  X(001)    VALUE '3'.*/
                public StringBasis LV09_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      FILLER              PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LV09-IMPMORNATU     PIC  ZZZZZ9,99.*/
                public DoubleBasis LV09_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LV09-IMPMORACID     PIC  ZZZZZ9,99.*/
                public DoubleBasis LV09_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LV09-IMPINVPERM     PIC  ZZZZZ9,99.*/
                public DoubleBasis LV09_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LV09-IMPMORESPO-X   PIC  X(009)    VALUE  SPACES.*/
                public StringBasis LV09_IMPMORESPO_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      LV09-IMPMORESPO     REDEFINES              LV09-IMPMORESPO-X   PIC  ZZZZZ9,99.*/
                private _REDEF_DoubleBasis _lv09_impmorespo { get; set; }
                public _REDEF_DoubleBasis LV09_IMPMORESPO
                {
                    get { _lv09_impmorespo = new _REDEF_DoubleBasis(new PIC("9", "ZZZZZ9,99", "ZZZZZ9V99."), 2); ; _.Move(LV09_IMPMORESPO_X, _lv09_impmorespo); VarBasis.RedefinePassValue(LV09_IMPMORESPO_X, _lv09_impmorespo, LV09_IMPMORESPO_X); _lv09_impmorespo.ValueChanged += () => { _.Move(_lv09_impmorespo, LV09_IMPMORESPO_X); }; return _lv09_impmorespo; }
                    set { VarBasis.RedefinePassValue(value, _lv09_impmorespo, LV09_IMPMORESPO_X); }
                }  //Redefines
                /*"      10      FILLER              PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LV09-VLPRMTOT       PIC  ZZZZZ9,99.*/
                public DoubleBasis LV09_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"    05        LMF2-LINHAF2.*/
            }
            public VA2513B_LMF2_LINHAF2 LMF2_LINHAF2 { get; set; } = new VA2513B_LMF2_LINHAF2();
            public class VA2513B_LMF2_LINHAF2 : VarBasis
            {
                /*"      10      LMF2-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMF2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMF2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMF2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(013)    VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF2-VLPRMANT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMF2_VLPRMANT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(029)    VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF2-VLMULTA        PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMF2_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"    05        LMF3-LINHAF3.*/
            }
            public VA2513B_LMF3_LINHAF3 LMF3_LINHAF3 { get; set; } = new VA2513B_LMF3_LINHAF3();
            public class VA2513B_LMF3_LINHAF3 : VarBasis
            {
                /*"      10      LMF3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMF3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMF3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMF3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF3-VLDESPESA      PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMF3_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(032)    VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF3-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMF3_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMG2-LINHAG2.*/
            }
            public VA2513B_LMG2_LINHAG2 LMG2_LINHAG2 { get; set; } = new VA2513B_LMG2_LINHAG2();
            public class VA2513B_LMG2_LINHAG2 : VarBasis
            {
                /*"      10      LMG2-CANAL          PIC  X(001)    VALUE '3'.*/
                public StringBasis LMG2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LMG2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMG2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(013)    VALUE  SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG2-VLPRMANT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG2_VLPRMANT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(030)    VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG2-VLMULTA        PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMG2_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"    05        LMG3-LINHAG3.*/
            }
            public VA2513B_LMG3_LINHAG3 LMG3_LINHAG3 { get; set; } = new VA2513B_LMG3_LINHAG3();
            public class VA2513B_LMG3_LINHAG3 : VarBasis
            {
                /*"      10      LMG3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMG3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMG3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMG3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG3-VLDESPESA      PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMG3_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(028)    VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG3-VLPRMINT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG3_VLPRMINT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMG4-LINHAG4.*/
            }
            public VA2513B_LMG4_LINHAG4 LMG4_LINHAG4 { get; set; } = new VA2513B_LMG4_LINHAG4();
            public class VA2513B_LMG4_LINHAG4 : VarBasis
            {
                /*"      10      LMG4-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMG4_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMG4-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMG4_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(026)    VALUE  SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG4-VLPROXPAR      PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG4_VLPROXPAR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(024)    VALUE  SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG4-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG4_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMH2-LINHAH2.*/
            }
            public VA2513B_LMH2_LINHAH2 LMH2_LINHAH2 { get; set; } = new VA2513B_LMH2_LINHAH2();
            public class VA2513B_LMH2_LINHAH2 : VarBasis
            {
                /*"      10      LMH2-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMH2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMH2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMH2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(022)    VALUE  SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH2-VLPRMANT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH2_VLPRMANT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(021)    VALUE  SPACES.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH2-VLMULTA        PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH2_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMH3-LINHAH3.*/
            }
            public VA2513B_LMH3_LINHAH3 LMH3_LINHAH3 { get; set; } = new VA2513B_LMH3_LINHAH3();
            public class VA2513B_LMH3_LINHAH3 : VarBasis
            {
                /*"      10      LMH3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMH3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMH3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMH3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH3-VLDESPESA      PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMH3_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(029)    VALUE  SPACES.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH3-VLPRMINT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH3_VLPRMINT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMH4-LINHAH4.*/
            }
            public VA2513B_LMH4_LINHAH4 LMH4_LINHAH4 { get; set; } = new VA2513B_LMH4_LINHAH4();
            public class VA2513B_LMH4_LINHAH4 : VarBasis
            {
                /*"      10      LMH4-CANAL-1        PIC  X(001)    VALUE '2'.*/
                public StringBasis LMH4_CANAL_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMH4-FONTE-1        PIC  X(001)    VALUE '1'.*/
                public StringBasis LMH4_FONTE_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(034)    VALUE  SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH4-VLPROXPAR      PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH4_VLPROXPAR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(019)    VALUE  SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH4-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH4_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMM2-LINHAM2.*/
            }
            public VA2513B_LMM2_LINHAM2 LMM2_LINHAM2 { get; set; } = new VA2513B_LMM2_LINHAM2();
            public class VA2513B_LMM2_LINHAM2 : VarBasis
            {
                /*"      10      LMM2-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMM2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMM2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMM2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(031)    VALUE  SPACES.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"      10      LMM2-VLPRMDIF       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMM2_VLPRMDIF { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMM3-LINHAM3.*/
            }
            public VA2513B_LMM3_LINHAM3 LMM3_LINHAM3 { get; set; } = new VA2513B_LMM3_LINHAM3();
            public class VA2513B_LMM3_LINHAM3 : VarBasis
            {
                /*"      10      LMM3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMM3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMM3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMM3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(024)    VALUE  SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"      10      LMM3-VLPREMIO       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMM3_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMM4-LINHAM4.*/
            }
            public VA2513B_LMM4_LINHAM4 LMM4_LINHAM4 { get; set; } = new VA2513B_LMM4_LINHAM4();
            public class VA2513B_LMM4_LINHAM4 : VarBasis
            {
                /*"      10      LMM4-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMM4_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMM4-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMM4_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(011)    VALUE  SPACES.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      LMM4-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMM4_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMN1-LINHAN1.*/
            }
            public VA2513B_LMN1_LINHAN1 LMN1_LINHAN1 { get; set; } = new VA2513B_LMN1_LINHAN1();
            public class VA2513B_LMN1_LINHAN1 : VarBasis
            {
                /*"      10      LMN1-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LMN1_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LMN1-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMN1_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE  SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      FILLER              PIC  X(030)    VALUE             'HISTORICO'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"HISTORICO");
                /*"      10      FILLER              PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      FILLER              PIC  X(010)    VALUE             'REFERENCIA'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"REFERENCIA");
                /*"      10      FILLER              PIC  X(006)    VALUE  SPACES.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      FILLER              PIC  X(010)    VALUE             '     VALOR'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"     VALOR");
                /*"    05        LMN2-LINHAN2.*/
            }
            public VA2513B_LMN2_LINHAN2 LMN2_LINHAN2 { get; set; } = new VA2513B_LMN2_LINHAN2();
            public class VA2513B_LMN2_LINHAN2 : VarBasis
            {
                /*"      10      LMN2-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LMN2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LMN2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMN2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE  SPACES.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LMN2-HISTORICO      PIC  X(030).*/
                public StringBasis LMN2_HISTORICO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      FILLER              PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LMN2-MMREFER        PIC  9(002).*/
                public IntBasis LMN2_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LMN2-AAREFER        PIC  9(004).*/
                public IntBasis LMN2_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LMN2-MOEDA          PIC  X(002)    VALUE 'R$'.*/
                public StringBasis LMN2_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"R$");
                /*"      10      LMN2-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMN2_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(001)    VALUE '('.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10      LMN2-SINAL          PIC  X(001).*/
                public StringBasis LMN2_SINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE ')'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @")");
                /*"    05        LMN3-LINHAN3.*/
            }
            public VA2513B_LMN3_LINHAN3 LMN3_LINHAN3 { get; set; } = new VA2513B_LMN3_LINHAN3();
            public class VA2513B_LMN3_LINHAN3 : VarBasis
            {
                /*"      10      LMN3-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LMN3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LMN3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMN3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE  SPACES.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LMN3-HISTORICO      PIC  X(030).*/
                public StringBasis LMN3_HISTORICO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      LMN3-MOEDA          PIC  X(002)    VALUE 'R$'.*/
                public StringBasis LMN3_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"R$");
                /*"      10      LMN3-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMN3_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LM88-LINHA88.*/
            }
            public VA2513B_LM88_LINHA88 LM88_LINHA88 { get; set; } = new VA2513B_LM88_LINHA88();
            public class VA2513B_LM88_LINHA88 : VarBasis
            {
                /*"      10      LM88-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LM88_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LM88-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LM88_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LM89-LINHA89.*/
            }
            public VA2513B_LM89_LINHA89 LM89_LINHA89 { get; set; } = new VA2513B_LM89_LINHA89();
            public class VA2513B_LM89_LINHA89 : VarBasis
            {
                /*"      10      LM89-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LM89_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LM89-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LM89_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LE01-LINHA01.*/
            }
            public VA2513B_LE01_LINHA01 LE01_LINHA01 { get; set; } = new VA2513B_LE01_LINHA01();
            public class VA2513B_LE01_LINHA01 : VarBasis
            {
                /*"      10      LE01-CANAL          PIC  X(001)    VALUE 'C'.*/
                public StringBasis LE01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"      10      LE01-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(057)    VALUE SPACES.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"");
                /*"      10      LE01-DTPOSTAGEM     PIC  X(010).*/
                public StringBasis LE01_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LE01-SEQUENCIA      PIC  ZZZ.999.*/
                public IntBasis LE01_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    05        LE02-LINHA02.*/
            }
            public VA2513B_LE02_LINHA02 LE02_LINHA02 { get; set; } = new VA2513B_LE02_LINHA02();
            public class VA2513B_LE02_LINHA02 : VarBasis
            {
                /*"      10      LE02-CANAL          PIC  X(001)    VALUE 'C'.*/
                public StringBasis LE02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"      10      LE02-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE02-NOME-RAZAO     PIC  X(040).*/
                public StringBasis LE02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LE03-LINHA03.*/
            }
            public VA2513B_LE03_LINHA03 LE03_LINHA03 { get; set; } = new VA2513B_LE03_LINHA03();
            public class VA2513B_LE03_LINHA03 : VarBasis
            {
                /*"      10      LE03-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE03-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE03-ENDERECO       PIC  X(040).*/
                public StringBasis LE03_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LE04-LINHA04.*/
            }
            public VA2513B_LE04_LINHA04 LE04_LINHA04 { get; set; } = new VA2513B_LE04_LINHA04();
            public class VA2513B_LE04_LINHA04 : VarBasis
            {
                /*"      10      LE04-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE04-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE04-BAIRRO         PIC  X(020).*/
                public StringBasis LE04_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LE04-CIDADE         PIC  X(020).*/
                public StringBasis LE04_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LE04-UF             PIC  X(002).*/
                public StringBasis LE04_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        LE05-LINHA05.*/
            }
            public VA2513B_LE05_LINHA05 LE05_LINHA05 { get; set; } = new VA2513B_LE05_LINHA05();
            public class VA2513B_LE05_LINHA05 : VarBasis
            {
                /*"      10      LE05-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE05-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE05-CEP            PIC  99999.*/
                public IntBasis LE05_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LE05-CEP-COMPL      PIC  999.*/
                public IntBasis LE05_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"    05        LE00-LINHA00.*/
            }
            public VA2513B_LE00_LINHA00 LE00_LINHA00 { get; set; } = new VA2513B_LE00_LINHA00();
            public class VA2513B_LE00_LINHA00 : VarBasis
            {
                /*"      10      LE00-CANAL          PIC  X(001)    VALUE 'C'.*/
                public StringBasis LE00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"      10      LE00-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE00_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(022)    VALUE SPACES.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"      10      FILLER              PIC  X(008)    VALUE                                 'GEPES - '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"      10      LE00-NOMPRODU       PIC  X(032).*/
                public StringBasis LE00_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"    05        LE06-LINHA06.*/
            }
            public VA2513B_LE06_LINHA06 LE06_LINHA06 { get; set; } = new VA2513B_LE06_LINHA06();
            public class VA2513B_LE06_LINHA06 : VarBasis
            {
                /*"      10      LE06-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE06-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE06_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      FILLER              PIC  X(009)    VALUE                                 'FILIAL - '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FILIAL - ");
                /*"      10      LE06-REMETENTE      PIC  X(031).*/
                public StringBasis LE06_REMETENTE { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"    05        LE07-LINHA07.*/
            }
            public VA2513B_LE07_LINHA07 LE07_LINHA07 { get; set; } = new VA2513B_LE07_LINHA07();
            public class VA2513B_LE07_LINHA07 : VarBasis
            {
                /*"      10      LE07-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE07_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE07-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE07_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE07-ENDERECO       PIC  X(040).*/
                public StringBasis LE07_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LE08-LINHA08.*/
            }
            public VA2513B_LE08_LINHA08 LE08_LINHA08 { get; set; } = new VA2513B_LE08_LINHA08();
            public class VA2513B_LE08_LINHA08 : VarBasis
            {
                /*"      10      LE08-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE08_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE08-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE08_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE08-CIDADE         PIC  X(020).*/
                public StringBasis LE08_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LE08-BAIRRO         PIC  X(020).*/
                public StringBasis LE08_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LE08-UF             PIC  X(002).*/
                public StringBasis LE08_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        LE09-LINHA09.*/
            }
            public VA2513B_LE09_LINHA09 LE09_LINHA09 { get; set; } = new VA2513B_LE09_LINHA09();
            public class VA2513B_LE09_LINHA09 : VarBasis
            {
                /*"      10      LE09-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE09_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE09-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE09_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      LE09-CEP            PIC  99999.*/
                public IntBasis LE09_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LE09-CEP-COMPL      PIC  999.*/
                public IntBasis LE09_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"    05            LR01-LINHA01.*/
            }
            public VA2513B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new VA2513B_LR01_LINHA01();
            public class VA2513B_LR01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05            LR02-LINHA02.*/
            }
            public VA2513B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new VA2513B_LR02_LINHA02();
            public class VA2513B_LR02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LR02-FORM.*/
                public VA2513B_LR02_FORM LR02_FORM { get; set; } = new VA2513B_LR02_FORM();
                public class VA2513B_LR02_FORM : VarBasis
                {
                    /*"        15        LR02-JDE             PIC X(004) VALUE 'CO05'.*/
                    public StringBasis LR02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"CO05");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'JDT'.*/
                    public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"JDT");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE     'STARTLM'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTLM");
                /*"    05            LR03-LINHA03.*/
            }
            public VA2513B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new VA2513B_LR03_LINHA03();
            public class VA2513B_LR03_LINHA03 : VarBasis
            {
                /*"      10          LR03-CONTRATO-ECT    PIC X(030) VALUE     '     100134700-5'.*/
                public StringBasis LR03_CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     100134700-5");
                /*"    05            LR04-LINHA04.*/
            }
            public VA2513B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new VA2513B_LR04_LINHA04();
            public class VA2513B_LR04_LINHA04 : VarBasis
            {
                /*"      10          LR04-USUARIO         PIC X(030) VALUE     '     CAIXA SEGUROS'.*/
                public StringBasis LR04_USUARIO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     CAIXA SEGUROS");
                /*"    05            LR05-LINHA05.*/
            }
            public VA2513B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new VA2513B_LR05_LINHA05();
            public class VA2513B_LR05_LINHA05 : VarBasis
            {
                /*"      10          LR05-ENDERECO        PIC X(070) VALUE     '     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR'.*/
                public StringBasis LR05_ENDERECO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR");
                /*"    05            LR06-LINHA06.*/
            }
            public VA2513B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new VA2513B_LR06_LINHA06();
            public class VA2513B_LR06_LINHA06 : VarBasis
            {
                /*"      10          LR06-UNID-POSTAGEM   PIC X(030) VALUE     '     DR/BSB/BSA'.*/
                public StringBasis LR06_UNID_POSTAGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     DR/BSB/BSA");
                /*"    05            LR07-LINHA07.*/
            }
            public VA2513B_LR07_LINHA07 LR07_LINHA07 { get; set; } = new VA2513B_LR07_LINHA07();
            public class VA2513B_LR07_LINHA07 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR07-SEQ             PIC ZZ.ZZ9.*/
                public IntBasis LR07_SEQ { get; set; } = new IntBasis(new PIC("9", "5", "ZZ.ZZ9."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR07-MES             PIC X(012).*/
                public StringBasis LR07_MES { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    05            LR08-LINHA08.*/
            }
            public VA2513B_LR08_LINHA08 LR08_LINHA08 { get; set; } = new VA2513B_LR08_LINHA08();
            public class VA2513B_LR08_LINHA08 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR08-TIPO.*/
                public VA2513B_LR08_TIPO LR08_TIPO { get; set; } = new VA2513B_LR08_TIPO();
                public class VA2513B_LR08_TIPO : VarBasis
                {
                    /*"        15        LR08-COD-PRODUTO     PIC 9(004).*/
                    public IntBasis LR08_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15        FILLER               PIC X(001) VALUE '-'.*/
                    public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15        LR08-NOM-PRODUTO     PIC X(030).*/
                    public StringBasis LR08_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '*'.*/
                    public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                    /*"        15        FILLER               PIC X(012)                  VALUE 'MALA DIRETA*'.*/
                    public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"MALA DIRETA*");
                    /*"    05            LR09-LINHA09.*/
                }
            }
            public VA2513B_LR09_LINHA09 LR09_LINHA09 { get; set; } = new VA2513B_LR09_LINHA09();
            public class VA2513B_LR09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR09-DATA            PIC X(010).*/
                public StringBasis LR09_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05            LR10-LINHA10-A.*/
            }
            public VA2513B_LR10_LINHA10_A LR10_LINHA10_A { get; set; } = new VA2513B_LR10_LINHA10_A();
            public class VA2513B_LR10_LINHA10_A : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR10-NUCLEO          PIC X(030) VALUE                 'BRASILIA(DF)'.*/
                public StringBasis LR10_NUCLEO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"BRASILIA(DF)");
                /*"    05            LR10-LINHA10.*/
            }
            public VA2513B_LR10_LINHA10 LR10_LINHA10 { get; set; } = new VA2513B_LR10_LINHA10();
            public class VA2513B_LR10_LINHA10 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR10-PAGINA          PIC 9(003).*/
                public IntBasis LR10_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR10-PAGINA-T        PIC 9(003).*/
                public IntBasis LR10_PAGINA_T { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            LR11-LINHA11.*/
            }
            public VA2513B_LR11_LINHA11 LR11_LINHA11 { get; set; } = new VA2513B_LR11_LINHA11();
            public class VA2513B_LR11_LINHA11 : VarBasis
            {
                /*"      10          FILLER              PIC X(101) VALUE SPACES.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "101", "X(101)"), @"");
                /*"      10          LR11-GEPES          PIC X(008) VALUE                                                'GEPES - '.*/
                public StringBasis LR11_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"      10          LR11-TP-PGTO        PIC X(022) VALUE SPACES.*/
                public StringBasis LR11_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05            LR12-LINHA12.*/
            }
            public VA2513B_LR12_LINHA12 LR12_LINHA12 { get; set; } = new VA2513B_LR12_LINHA12();
            public class VA2513B_LR12_LINHA12 : VarBasis
            {
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR12-CEPI           PIC 9(005).*/
                public IntBasis LR12_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR12-COMPL-CEPI     PIC 9(003).*/
                public IntBasis LR12_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR12-CEPF           PIC 9(005).*/
                public IntBasis LR12_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR12-COMPL-CEPF     PIC 9(003).*/
                public IntBasis LR12_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR12-OBJI           PIC ZZZ.999.*/
                public IntBasis LR12_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR12-OBJF           PIC ZZZ.999.*/
                public IntBasis LR12_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR12-AMARI          PIC ZZZ.999.*/
                public IntBasis LR12_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR12-AMARF          PIC ZZZ.999.*/
                public IntBasis LR12_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR12-QTD-OBJ        PIC ZZZ.999.*/
                public IntBasis LR12_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR12-QTD-AMAR       PIC ZZZ.999.*/
                public IntBasis LR12_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR12-OBS            PIC X(023).*/
                public StringBasis LR12_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LR13-LINHA13.*/
            }
            public VA2513B_LR13_LINHA13 LR13_LINHA13 { get; set; } = new VA2513B_LR13_LINHA13();
            public class VA2513B_LR13_LINHA13 : VarBasis
            {
                /*"      10          FILLER              PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LK-PROSOMU1.*/
            }
            public VA2513B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VA2513B_LK_PROSOMU1();
            public class VA2513B_LK_PROSOMU1 : VarBasis
            {
                /*"      10      LK-DATA-SOM         PIC  9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-SOM-R       REDEFINES              LK-DATA-SOM.*/
                private _REDEF_VA2513B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VA2513B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VA2513B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VA2513B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15    LK-DIA-SOM          PIC  9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-SOM          PIC  9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-SOM          PIC  9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      LK-QTDIAS           PIC S9(005)    COMP-3 VALUE +2*/

                    public _REDEF_VA2513B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +2);
                /*"      10      LK-DATA-CALC        PIC  9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-CALC-R      REDEFINES              LK-DATA-CALC.*/
                private _REDEF_VA2513B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VA2513B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VA2513B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VA2513B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15    LK-DIA-CALC         PIC  9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-CALC         PIC  9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-CALC         PIC  9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05        WSL-SQLCODE         PIC  9(009)    VALUE ZEROS.*/

                    public _REDEF_VA2513B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-LINHAS           PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05        WWORK-QTDE01.*/
            public VA2513B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new VA2513B_WWORK_QTDE01();
            public class VA2513B_WWORK_QTDE01 : VarBasis
            {
                /*"       10     WWORK-QTDE11        PIC  9(004).*/
                public IntBasis WWORK_QTDE11 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10     WWORK-QTDE12        PIC  9(002).*/
                public IntBasis WWORK_QTDE12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWORK-QTDE  REDEFINES  WWORK-QTDE01                                  PIC S9(004)V99.*/
            }
            private _REDEF_DoubleBasis _wwork_qtde { get; set; }
            public _REDEF_DoubleBasis WWORK_QTDE
            {
                get { _wwork_qtde = new _REDEF_DoubleBasis(new PIC("S9", "004", "S9(004)V99."), 2); ; _.Move(WWORK_QTDE01, _wwork_qtde); VarBasis.RedefinePassValue(WWORK_QTDE01, _wwork_qtde, WWORK_QTDE01); _wwork_qtde.ValueChanged += () => { _.Move(_wwork_qtde, WWORK_QTDE01); }; return _wwork_qtde; }
                set { VarBasis.RedefinePassValue(value, _wwork_qtde, WWORK_QTDE01); }
            }  //Redefines
            /*"    05        WCONTROLE           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WCONTROLE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WS-COUNT            PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05        WHOST-PROXIMA-DATA  PIC  X(010)    VALUE SPACES.*/
            public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05        AC-PAGINA           PIC  9(003)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        AC-CONTA1           PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA-910        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA_910 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-I-RELATORIOS     PIC S9(005)    COMP-3 VALUE +0*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05        WS-IMPMORACID       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-IMPMORESPO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORESPO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPRMTOT         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPREMIO         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLMULTA          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-CAR-CONJUGE      PIC  9(003)V99 VALUE ZEROS.*/
            public DoubleBasis WS_CAR_CONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
            /*"    05        WS-OCORR            PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-AMARRADO         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ-INICIAL      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTD-OBJ          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTROLE         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-AMAR       PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-OBJ        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-200        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-IDSEXO           PIC  X(001).*/
            public StringBasis WS_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-CONTR-PRODU      PIC  X(001).*/
            public StringBasis WS_CONTR_PRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-JDE-ANT          PIC  X(008).*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-JDE-TFORM        PIC  X(008).*/
            public StringBasis WS_JDE_TFORM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-APOLICE-ANT      PIC  9(013).*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        WS-OPER-ANT         PIC  9(004).*/
            public IntBasis WS_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        WS-CEP-G-ANT        PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        WS-NOME-COR-ANT.*/
            public VA2513B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VA2513B_WS_NOME_COR_ANT();
            public class VA2513B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10      WS-FAIXA1-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-FAIXA2-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-NOME-ANT         PIC  X(030).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05        WS-CEP-ANT          PIC  9(005).*/
            }
            public IntBasis WS_CEP_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-COMPL-ANT        PIC  9(003).*/
            public IntBasis WS_COMPL_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05        WS-INF              PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-SUP              PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-IND              PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND                PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDR               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND1               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDM               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDH               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND1            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND2            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        INF                 PIC S9(009)    COMP.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SUP                 PIC S9(009)    COMP.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        DEST-NUM-CEP.*/
            public VA2513B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VA2513B_DEST_NUM_CEP();
            public class VA2513B_DEST_NUM_CEP : VarBasis
            {
                /*"      15      DEST-CEP            PIC  9(005)    VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15      DEST-CEP-COMPL      PIC  9(003)    VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05            WS-CLIENTE.*/
            }
            public VA2513B_WS_CLIENTE WS_CLIENTE { get; set; } = new VA2513B_WS_CLIENTE();
            public class VA2513B_WS_CLIENTE : VarBasis
            {
                /*"      10          WS-PREZADO.*/
                public VA2513B_WS_PREZADO WS_PREZADO { get; set; } = new VA2513B_WS_PREZADO();
                public class VA2513B_WS_PREZADO : VarBasis
                {
                    /*"         15       WS-PREZADOI    PIC X(001).*/
                    public StringBasis WS_PREZADOI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       WS-PREZADOC    PIC X(009).*/
                    public StringBasis WS_PREZADOC { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                    /*"      10          WS-PRI-NOME.*/
                }
                public VA2513B_WS_PRI_NOME WS_PRI_NOME { get; set; } = new VA2513B_WS_PRI_NOME();
                public class VA2513B_WS_PRI_NOME : VarBasis
                {
                    /*"         15       WS-NOME-RAZAOI PIC X(001).*/
                    public StringBasis WS_NOME_RAZAOI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       WS-NOME-RAZAOC PIC X(039).*/
                    public StringBasis WS_NOME_RAZAOC { get; set; } = new StringBasis(new PIC("X", "39", "X(039)."), @"");
                    /*"      10          WS-PRI-NOME-R  REDEFINES                  WS-PRI-NOME.*/
                }
                private _REDEF_VA2513B_WS_PRI_NOME_R _ws_pri_nome_r { get; set; }
                public _REDEF_VA2513B_WS_PRI_NOME_R WS_PRI_NOME_R
                {
                    get { _ws_pri_nome_r = new _REDEF_VA2513B_WS_PRI_NOME_R(); _.Move(WS_PRI_NOME, _ws_pri_nome_r); VarBasis.RedefinePassValue(WS_PRI_NOME, _ws_pri_nome_r, WS_PRI_NOME); _ws_pri_nome_r.ValueChanged += () => { _.Move(_ws_pri_nome_r, WS_PRI_NOME); }; return _ws_pri_nome_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_pri_nome_r, WS_PRI_NOME); }
                }  //Redefines
                public class _REDEF_VA2513B_WS_PRI_NOME_R : VarBasis
                {
                    /*"         15       WS-NOME-RAZAO-X OCCURS 40 TIMES                                 PIC X(001).*/
                    public ListBasis<StringBasis, string> WS_NOME_RAZAO_X { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                    /*"    05            WS-CLIENTE1.*/

                    public _REDEF_VA2513B_WS_PRI_NOME_R()
                    {
                        WS_NOME_RAZAO_X.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA2513B_WS_CLIENTE1 WS_CLIENTE1 { get; set; } = new VA2513B_WS_CLIENTE1();
            public class VA2513B_WS_CLIENTE1 : VarBasis
            {
                /*"      10          WS-PREZADO1    PIC X(008).*/
                public StringBasis WS_PREZADO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10          WS-PRI-NOME1   PIC X(040).*/
                public StringBasis WS_PRI_NOME1 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            WS-CLIENTE2.*/
            }
            public VA2513B_WS_CLIENTE2 WS_CLIENTE2 { get; set; } = new VA2513B_WS_CLIENTE2();
            public class VA2513B_WS_CLIENTE2 : VarBasis
            {
                /*"      10          WS-PREZADO2    PIC X(011).*/
                public StringBasis WS_PREZADO2 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"      10          WS-PRI-NOME2   PIC X(040).*/
                public StringBasis WS_PRI_NOME2 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        WS-CPF              PIC  9(015).*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CPF-R            REDEFINES              WS-CPF.*/
            private _REDEF_VA2513B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_VA2513B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_VA2513B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_VA2513B_WS_CPF_R : VarBasis
            {
                /*"      10      WS-NRCPF            PIC  9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-DVCPF            PIC  9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SQL.*/

                public _REDEF_VA2513B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public VA2513B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA2513B_WS_DATA_SQL();
            public class VA2513B_WS_DATA_SQL : VarBasis
            {
                /*"      10      WS-ANO-SQL          PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-DATA.*/
            }
            public VA2513B_WS_DATA WS_DATA { get; set; } = new VA2513B_WS_DATA();
            public class VA2513B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-CERTIF           PIC  9(015).*/
            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CERTIF-R         REDEFINES WS-CERTIF.*/
            private _REDEF_VA2513B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VA2513B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VA2513B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VA2513B_WS_CERTIF_R : VarBasis
            {
                /*"      10      WS-NRCERTIF         PIC  9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      WS-DVCERTIF         PIC  9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-TITULO           PIC  9(013).*/

                public _REDEF_VA2513B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-TITULO-R         REDEFINES WS-TITULO.*/
            private _REDEF_VA2513B_WS_TITULO_R _ws_titulo_r { get; set; }
            public _REDEF_VA2513B_WS_TITULO_R WS_TITULO_R
            {
                get { _ws_titulo_r = new _REDEF_VA2513B_WS_TITULO_R(); _.Move(WS_TITULO, _ws_titulo_r); VarBasis.RedefinePassValue(WS_TITULO, _ws_titulo_r, WS_TITULO); _ws_titulo_r.ValueChanged += () => { _.Move(_ws_titulo_r, WS_TITULO); }; return _ws_titulo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_titulo_r, WS_TITULO); }
            }  //Redefines
            public class _REDEF_VA2513B_WS_TITULO_R : VarBasis
            {
                /*"      10      WS-NRTIT            PIC  9(012).*/
                public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      10      WS-DVTITULO         PIC  9(001).*/
                public IntBasis WS_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-DATA-I.*/

                public _REDEF_VA2513B_WS_TITULO_R()
                {
                    WS_NRTIT.ValueChanged += OnValueChanged;
                    WS_DVTITULO.ValueChanged += OnValueChanged;
                }

            }
            public VA2513B_WS_DATA_I WS_DATA_I { get; set; } = new VA2513B_WS_DATA_I();
            public class VA2513B_WS_DATA_I : VarBasis
            {
                /*"      10      WS-DIA-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB1            PIC  X(001).*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB2            PIC  X(001).*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO-I            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05        WHORA-CURR          PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05        WS-NOME-RAZAO.*/
            public VA2513B_WS_NOME_RAZAO WS_NOME_RAZAO { get; set; } = new VA2513B_WS_NOME_RAZAO();
            public class VA2513B_WS_NOME_RAZAO : VarBasis
            {
                /*"      10      WS-LETRA-NOME       OCCURS 41 TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_LETRA_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 41);
                /*"    05        WS-NUM-CEP-AUX      PIC  9(008).*/
            }
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-NUM-CEP-AUX-R    REDEFINES              WS-NUM-CEP-AUX.*/
            private _REDEF_VA2513B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VA2513B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VA2513B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA2513B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10      WS-CEP-AUX          PIC  9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CEP-COMPL-AUX    PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-NUM-CEP-AUX-R1   REDEFINES              WS-NUM-CEP-AUX.*/

                public _REDEF_VA2513B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2513B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VA2513B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VA2513B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA2513B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10      WS-CEP-COMPL-AUX1   PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-CEP-AUX1         PIC  9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-JDE-GER.*/

                public _REDEF_VA2513B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public VA2513B_WS_JDE_GER WS_JDE_GER { get; set; } = new VA2513B_WS_JDE_GER();
            public class VA2513B_WS_JDE_GER : VarBasis
            {
                /*"        15        WS-JDE               PIC X(008).*/
                public StringBasis WS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"        15        WS-PONTO             PIC X(001) VALUE '.'.*/
                public StringBasis WS_PONTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"        15        WS-DBM               PIC X(003).*/
                public StringBasis WS_DBM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05        WS-CHAVE            PIC  X(020).*/
            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VA2513B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VA2513B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VA2513B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VA2513B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-APOLICE          PIC  9(013).*/
                public IntBasis WS_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(004).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        AC-LIDOS            PIC  9(009)    VALUE ZEROES.*/

                public _REDEF_VA2513B_WS_CHAVE_R()
                {
                    WS_APOLICE.ValueChanged += OnValueChanged;
                    WS_CODSUBES.ValueChanged += OnValueChanged;
                    WS_CODOPER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-CONTA            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-IMPRESSOS        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        WFIM-V1SISTEMA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V1AGENCEF      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0FAIXACEP     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0HISTCOBVA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0MSGCOBR      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MSGCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0PARCELVA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0DIFPARCEL    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0DIFPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-SORT           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-TABELA         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-MULTIMSG       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_MULTIMSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-CONDTEC        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_CONDTEC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01            TAB-FILIAL.*/
        }
        public VA2513B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA2513B_TAB_FILIAL();
        public class VA2513B_TAB_FILIAL : VarBasis
        {
            /*"    05        FILLER              OCCURS 19 TIMES.*/
            public ListBasis<VA2513B_FILLER_149> FILLER_149 { get; set; } = new ListBasis<VA2513B_FILLER_149>(19);
            public class VA2513B_FILLER_149 : VarBasis
            {
                /*"      10      TAB-FONTE           PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      TAB-NOMEFTE         PIC  X(40).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-ENDERFTE        PIC  X(40).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-BAIRRO          PIC  X(20).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CIDADE          PIC  X(20).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CEP             PIC  9(08).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      TAB-UF              PIC  X(02).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"01            TABELA-REGISTROS.*/
            }
        }
        public VA2513B_TABELA_REGISTROS TABELA_REGISTROS { get; set; } = new VA2513B_TABELA_REGISTROS();
        public class VA2513B_TABELA_REGISTROS : VarBasis
        {
            /*"  03          TAB-REG             OCCURS 2 TIMES.*/
            public ListBasis<VA2513B_TAB_REG> TAB_REG { get; set; } = new ListBasis<VA2513B_TAB_REG>(2);
            public class VA2513B_TAB_REG : VarBasis
            {
                /*"    05        TVA-NUM-CEP.*/
                public VA2513B_TVA_NUM_CEP TVA_NUM_CEP { get; set; } = new VA2513B_TVA_NUM_CEP();
                public class VA2513B_TVA_NUM_CEP : VarBasis
                {
                    /*"      15      TVA-CEP             PIC  9(005).*/
                    public IntBasis TVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15      TVA-CEP-COMPL       PIC  9(003).*/
                    public IntBasis TVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"    05        TVA-NOME-RAZAO      PIC  X(040).*/
                }
                public StringBasis TVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        TVA-ENDERECO        PIC  X(040).*/
                public StringBasis TVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        TVA-BAIRRO          PIC  X(020).*/
                public StringBasis TVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05        TVA-CIDADE          PIC  X(020).*/
                public StringBasis TVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05        TVA-UF              PIC  X(002).*/
                public StringBasis TVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        TVA-NRAPOLICE       PIC  9(013).*/
                public IntBasis TVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05        TVA-CODSUBES        PIC  9(004).*/
                public IntBasis TVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        TVA-NRCERTIF        PIC  9(015).*/
                public IntBasis TVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    05        TVA-NRPARCEL        PIC  9(004).*/
                public IntBasis TVA_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        TVA-NRTIT           PIC  9(013).*/
                public IntBasis TVA_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05        TVA-CODPRODU        PIC  9(004).*/
                public IntBasis TVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        TVA-CODOPER         PIC  9(004).*/
                public IntBasis TVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        TVA-IDSEXO          PIC  X(001).*/
                public StringBasis TVA_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05        TVA-FONTE           PIC  9(004).*/
                public IntBasis TVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01            TABELA-CEP.*/
            }
        }
        public VA2513B_TABELA_CEP TABELA_CEP { get; set; } = new VA2513B_TABELA_CEP();
        public class VA2513B_TABELA_CEP : VarBasis
        {
            /*"    05        CEP                 OCCURS 2000 TIMES.*/
            public ListBasis<VA2513B_CEP> CEP { get; set; } = new ListBasis<VA2513B_CEP>(2000);
            public class VA2513B_CEP : VarBasis
            {
                /*"      10      TAB-FX-CEP-G        PIC  9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TAB-FAIXAS.*/
                public VA2513B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VA2513B_TAB_FAIXAS();
                public class VA2513B_TAB_FAIXAS : VarBasis
                {
                    /*"        15    TAB-FX-INI          PIC  9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-FIM          PIC  9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-NOME         PIC  X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15    TAB-FX-CENTR        PIC  X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-VALORES.*/
                }
            }
        }
        public VA2513B_TABELA_VALORES TABELA_VALORES { get; set; } = new VA2513B_TABELA_VALORES();
        public class VA2513B_TABELA_VALORES : VarBasis
        {
            /*"    05        TAB-VALORES         OCCURS    3 TIMES.*/
            public ListBasis<VA2513B_TAB_VALORES> TAB_VALORES { get; set; } = new ListBasis<VA2513B_TAB_VALORES>(3);
            public class VA2513B_TAB_VALORES : VarBasis
            {
                /*"      10      TAB-VLPRMTOT        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLPREMIO        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLMULTA         PIC  9(013)V99.*/
                public DoubleBasis TAB_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-HISTORICO.*/
            }
        }
        public VA2513B_TABELA_HISTORICO TABELA_HISTORICO { get; set; } = new VA2513B_TABELA_HISTORICO();
        public class VA2513B_TABELA_HISTORICO : VarBasis
        {
            /*"    05        TABH                OCCURS   10 TIMES.*/
            public ListBasis<VA2513B_TABH> TABH { get; set; } = new ListBasis<VA2513B_TABH>(10);
            public class VA2513B_TABH : VarBasis
            {
                /*"      10      TABH-DESCRICAO      PIC  X(030).*/
                public StringBasis TABH_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      TABH-MMREFER        PIC  9(002).*/
                public IntBasis TABH_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      TABH-AAREFER        PIC  9(004).*/
                public IntBasis TABH_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TABH-VLPRMTOT       PIC S9(013)V99.*/
                public DoubleBasis TABH_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
                /*"01            TABELA-TOTAIS.*/
            }
        }
        public VA2513B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new VA2513B_TABELA_TOTAIS();
        public class VA2513B_TABELA_TOTAIS : VarBasis
        {
            /*"    05        TAB-TOTAIS          OCCURS  2000 TIMES.*/
            public ListBasis<VA2513B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<VA2513B_TAB_TOTAIS>(2000);
            public class VA2513B_TAB_TOTAIS : VarBasis
            {
                /*"      10      TAB1-OBJI           PIC  9(006).*/
                public IntBasis TAB1_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-OBJF           PIC  9(006).*/
                public IntBasis TAB1_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARI          PIC  9(006).*/
                public IntBasis TAB1_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARF          PIC  9(006).*/
                public IntBasis TAB1_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-OBJ        PIC  9(006).*/
                public IntBasis TAB1_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-AMAR       PIC  9(006).*/
                public IntBasis TAB1_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01            TABELA-MSG.*/
            }
        }
        public VA2513B_TABELA_MSG TABELA_MSG { get; set; } = new VA2513B_TABELA_MSG();
        public class VA2513B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 3000  TIMES.*/
            public ListBasis<VA2513B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VA2513B_TAB_MSG>(3000);
            public class VA2513B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(020).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VA2513B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VA2513B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VA2513B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VA2513B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-APOLICE        PIC  9(013).*/
                    public IntBasis TABJ_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(004).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_VA2513B_TABJ_CHAVE_R()
                    {
                        TABJ_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01            TABELA-MESES.*/
            }
        }
        public VA2513B_TABELA_MESES TABELA_MESES { get; set; } = new VA2513B_TABELA_MESES();
        public class VA2513B_TABELA_MESES : VarBasis
        {
            /*"    05        TAB-MESES.*/
            public VA2513B_TAB_MESES TAB_MESES { get; set; } = new VA2513B_TAB_MESES();
            public class VA2513B_TAB_MESES : VarBasis
            {
                /*"      10      FILLER              PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10      FILLER              PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05        TAB-MESES-R         REDEFINES              TAB-MESES.*/
            }
            private _REDEF_VA2513B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VA2513B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VA2513B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VA2513B_TAB_MESES_R : VarBasis
            {
                /*"      10      TAB-MES             OCCURS 12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01          WABEND.*/

                public _REDEF_VA2513B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2513B_WABEND WABEND { get; set; } = new VA2513B_WABEND();
        public class VA2513B_WABEND : VarBasis
        {
            /*"      05    FILLER              PIC  X(010) VALUE           ' VA2513B'.*/
            public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA2513B");
            /*"      05    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05    WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA2513B_CFAIXACEP CFAIXACEP { get; set; } = new VA2513B_CFAIXACEP();
        public VA2513B_CMSG CMSG { get; set; } = new VA2513B_CMSG();
        public VA2513B_V1AGENCEF V1AGENCEF { get; set; } = new VA2513B_V1AGENCEF();
        public VA2513B_CHISTCOB CHISTCOB { get; set; } = new VA2513B_CHISTCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVA2513B_FILE_NAME_P, string SVA2513B_FILE_NAME_P, string FVA2513B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVA2513B.SetFile(RVA2513B_FILE_NAME_P);
                SVA2513B.SetFile(SVA2513B_FILE_NAME_P);
                FVA2513B.SetFile(FVA2513B_FILE_NAME_P);

                /*" -1179- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -1180- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1183- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -1186- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1186- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1195- MOVE ZEROS TO TABELA-TOTAIS */
            _.Move(0, TABELA_TOTAIS);

            /*" -1197- INITIALIZE TAB-FILIAL. */
            _.Initialize(
                TAB_FILIAL
            );

            /*" -1199- PERFORM R0500-00-DECLARE-V1AGENCEF. */

            R0500_00_DECLARE_V1AGENCEF_SECTION();

            /*" -1201- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

            /*" -1202- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -1203- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -1205- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1210- PERFORM R0520-00-CARREGA-FILIAL VARYING IDX-IND1 FROM 1 BY 1 UNTIL IDX-IND1 > 19 OR WFIM-V1AGENCEF EQUAL 'S' . */

            for (AREA_DE_WORK.IDX_IND1.Value = 1; !(AREA_DE_WORK.IDX_IND1 > 19 || AREA_DE_WORK.WFIM_V1AGENCEF == "S"); AREA_DE_WORK.IDX_IND1.Value += 1)
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1212- PERFORM R0900-00-DECLARE-V0HISTCOBVA. */

            R0900_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -1214- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -1215- IF WFIM-V0HISTCOBVA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0HISTCOBVA == "S")
            {

                /*" -1216- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1217- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1219- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1221- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1222- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1224- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1226- PERFORM R0200-00-CARREGA-V0FAIXACEP. */

            R0200_00_CARREGA_V0FAIXACEP_SECTION();

            /*" -1228- PERFORM R0300-00-CARREGA-V0MSGCOBR. */

            R0300_00_CARREGA_V0MSGCOBR_SECTION();

            /*" -1230- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1237- SORT SVA2513B ON ASCENDING KEY SVA-NRAPOLICE SVA-CODSUBES SVA-CEP-G SVA-NUM-CEP SVA-CODOPER INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SVA2513B.Sort("SVA-NRAPOLICE,SVA-CODSUBES,SVA-CEP-G,SVA-NUM-CEP,SVA-CODOPER", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1240- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1241- DISPLAY '*** VA2513B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VA2513B *** PROBLEMAS NO SORT ");

                /*" -1242- DISPLAY '*** VA2513B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VA2513B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1243- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1243- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1249- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1249- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1251- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1254- DISPLAY '*** VA2513B - ' */
            _.Display($"*** VA2513B - ");

            /*" -1255- DISPLAY 'LIDOS V0HISTCOBVA        ' AC-LIDOS. */
            _.Display($"LIDOS V0HISTCOBVA        {AREA_DE_WORK.AC_LIDOS}");

            /*" -1257- DISPLAY 'COBRANCAS IMPRESSAS      ' AC-IMPRESSOS. */
            _.Display($"COBRANCAS IMPRESSAS      {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1258- DISPLAY '*** VA2513B - TERMINO NORMAL ***' */
            _.Display($"*** VA2513B - TERMINO NORMAL ***");

            /*" -1258- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1272- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0HISTCOBVA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0HISTCOBVA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -1272- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1285- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1286- MOVE 'CO03.DBM' TO WS-JDE-GER. */
            _.Move("CO03.DBM", AREA_DE_WORK.WS_JDE_GER);

            /*" -1288- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LF02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LF02_LINHA02.LF02_FORM);

            /*" -1289- MOVE 'CO05.JDT' TO WS-JDE-GER. */
            _.Move("CO05.JDT", AREA_DE_WORK.WS_JDE_GER);

            /*" -1291- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LR02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LR02_LINHA02.LR02_FORM);

            /*" -1293- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -1294- WRITE RVA2513B-RECORD FROM LC01-LINHA01 */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1295- WRITE RVA2513B-RECORD FROM LC02-LINHA02 */
            _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1296- WRITE RVA2513B-RECORD FROM LC03-LINHA03 */
            _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1297- WRITE RVA2513B-RECORD FROM LC04-LINHA04 */
            _.Move(AREA_DE_WORK.LC04_LINHA04.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1298- WRITE RVA2513B-RECORD FROM LC05-LINHA05 */
            _.Move(AREA_DE_WORK.LC05_LINHA05.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1299- WRITE RVA2513B-RECORD FROM LC06-LINHA06 */
            _.Move(AREA_DE_WORK.LC06_LINHA06.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1301- WRITE RVA2513B-RECORD FROM LC07-LINHA07 */
            _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1311- WRITE FVA2513B-RECORD FROM LC01-LINHA01 */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1314- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1315- WRITE RVA2513B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1317- WRITE FVA2513B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -1317- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1330- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -1341- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1344- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1345- DISPLAY 'VA2513B - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"VA2513B - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1346- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -1346- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1341- EXEC SQL SELECT DTMOVABE, MONTH(DTMOVABE), YEAR(DTMOVABE), (DTMOVABE + 1 DAY) INTO :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, :WHOST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.WHOST_DTMOVABE, WHOST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-SECTION */
        private void R0200_00_CARREGA_V0FAIXACEP_SECTION()
        {
            /*" -1359- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -1369- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();

            /*" -1371- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1();

            /*" -1374- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1375- DISPLAY 'VA2513B - PROBLEMAS NA V0FAIXA_CEP' */
                _.Display($"VA2513B - PROBLEMAS NA V0FAIXA_CEP");

                /*" -1377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1378- PERFORM R0210-00-FETCH-V0FAIXACEP UNTIL WFIM-V0FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0FAIXACEP == "S"))
            {

                R0210_00_FETCH_V0FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1()
        {
            /*" -1369- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :V1SIST-DTMOVABE AND DATA_TERVIGENCIA >= :V1SIST-DTMOVABE ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VA2513B_CFAIXACEP(true);
            string GetQuery_CFAIXACEP()
            {
                var query = @$"SELECT FAIXA
							, 
							CEP_INICIAL
							, 
							CEP_FINAL
							, 
							DESCRICAO_FAIXA
							, 
							CENTRALIZADOR 
							FROM SEGUROS.GE_FAIXA_CEP 
							WHERE DATA_INIVIGENCIA <= '{V1SIST_DTMOVABE}' 
							AND DATA_TERVIGENCIA >= '{V1SIST_DTMOVABE}' 
							ORDER BY FAIXA";

                return query;
            }
            CFAIXACEP.GetQueryEvent += GetQuery_CFAIXACEP;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1()
        {
            /*" -1371- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0300-00-CARREGA-V0MSGCOBR-DB-DECLARE-1 */
        public void R0300_00_CARREGA_V0MSGCOBR_DB_DECLARE_1()
        {
            /*" -1436- EXEC SQL DECLARE CMSG CURSOR FOR SELECT NUM_APOLICE, CODSUBES, COD_OPERACAO, JDE, JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'PI' ORDER BY 1,2,3 END-EXEC. */
            CMSG = new VA2513B_CMSG(false);
            string GetQuery_CMSG()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							COD_OPERACAO
							, 
							JDE
							, 
							JDL 
							FROM SEGUROS.COBRANCA_MENS_VGAP 
							WHERE IDFORM = 'PI' 
							ORDER BY 1
							,2
							,3";

                return query;
            }
            CMSG.GetQueryEvent += GetQuery_CMSG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-SECTION */
        private void R0210_00_FETCH_V0FAIXACEP_SECTION()
        {
            /*" -1391- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -1398- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1();

            /*" -1401- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1402- MOVE 'S' TO WFIM-V0FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_V0FAIXACEP);

                /*" -1404- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1404- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1();

                /*" -1408- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1409- MOVE V0FAIC-FAIXA TO TAB-FX-CEP-G (V0FAIC-FAIXA). */
            _.Move(V0FAIC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FX_CEP_G);

            /*" -1410- MOVE V0FAIC-CEPINI TO TAB-FX-INI (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPINI, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1411- MOVE V0FAIC-CEPFIM TO TAB-FX-FIM (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPFIM, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1412- MOVE V0FAIC-DESC-FAIXA TO TAB-FX-NOME (V0FAIC-FAIXA). */
            _.Move(V0FAIC_DESC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1414- MOVE V0FAIC-CENTRALIZA TO TAB-FX-CENTR (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CENTRALIZA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1414- GO TO R0210-00-FETCH-V0FAIXACEP. */
            new Task(() => R0210_00_FETCH_V0FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1()
        {
            /*" -1398- EXEC SQL FETCH CFAIXACEP INTO :V0FAIC-FAIXA, :V0FAIC-CEPINI, :V0FAIC-CEPFIM, :V0FAIC-DESC-FAIXA, :V0FAIC-CENTRALIZA END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.V0FAIC_FAIXA, V0FAIC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CEPINI, V0FAIC_CEPINI);
                _.Move(CFAIXACEP.V0FAIC_CEPFIM, V0FAIC_CEPFIM);
                _.Move(CFAIXACEP.V0FAIC_DESC_FAIXA, V0FAIC_DESC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CENTRALIZA, V0FAIC_CENTRALIZA);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1()
        {
            /*" -1404- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CARREGA-V0MSGCOBR-SECTION */
        private void R0300_00_CARREGA_V0MSGCOBR_SECTION()
        {
            /*" -1427- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -1436- PERFORM R0300_00_CARREGA_V0MSGCOBR_DB_DECLARE_1 */

            R0300_00_CARREGA_V0MSGCOBR_DB_DECLARE_1();

            /*" -1438- PERFORM R0300_00_CARREGA_V0MSGCOBR_DB_OPEN_1 */

            R0300_00_CARREGA_V0MSGCOBR_DB_OPEN_1();

            /*" -1441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1442- DISPLAY 'VA2513B - PROBLEMAS NA V0MSGCOBR' */
                _.Display($"VA2513B - PROBLEMAS NA V0MSGCOBR");

                /*" -1444- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1445- PERFORM R0310-00-FETCH-V0MSGCOBR UNTIL WFIM-V0MSGCOBR EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0MSGCOBR == "S"))
            {

                R0310_00_FETCH_V0MSGCOBR_SECTION();
            }

        }

        [StopWatch]
        /*" R0300-00-CARREGA-V0MSGCOBR-DB-OPEN-1 */
        public void R0300_00_CARREGA_V0MSGCOBR_DB_OPEN_1()
        {
            /*" -1438- EXEC SQL OPEN CMSG END-EXEC. */

            CMSG.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -1517- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT DISTINCT B.COD_FONTE, C.NOMEFTE, C.ENDERFTE, C.BAIRRO, C.CIDADE, C.CEP, C.ESTADO FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B, SEGUROS.V1FONTE C WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE = C.FONTE ORDER BY B.COD_FONTE END-EXEC. */
            V1AGENCEF = new VA2513B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT DISTINCT B.COD_FONTE
							, 
							C.NOMEFTE
							, 
							C.ENDERFTE
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.CEP
							, 
							C.ESTADO 
							FROM SEGUROS.V1AGENCIACEF A
							, 
							SEGUROS.V1MALHACEF B
							, 
							SEGUROS.V1FONTE C 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							AND B.COD_FONTE = C.FONTE 
							ORDER BY B.COD_FONTE";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0MSGCOBR-SECTION */
        private void R0310_00_FETCH_V0MSGCOBR_SECTION()
        {
            /*" -1458- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WABEND.WNR_EXEC_SQL);

            /*" -1465- PERFORM R0310_00_FETCH_V0MSGCOBR_DB_FETCH_1 */

            R0310_00_FETCH_V0MSGCOBR_DB_FETCH_1();

            /*" -1468- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1469- MOVE 'S' TO WFIM-V0MSGCOBR */
                _.Move("S", AREA_DE_WORK.WFIM_V0MSGCOBR);

                /*" -1469- PERFORM R0310_00_FETCH_V0MSGCOBR_DB_CLOSE_1 */

                R0310_00_FETCH_V0MSGCOBR_DB_CLOSE_1();

                /*" -1473- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1475- ADD 1 TO WINDM. */
            AREA_DE_WORK.WINDM.Value = AREA_DE_WORK.WINDM + 1;

            /*" -1476- IF WINDM > 3000 */

            if (AREA_DE_WORK.WINDM > 3000)
            {

                /*" -1477- MOVE 3000 TO WINDM */
                _.Move(3000, AREA_DE_WORK.WINDM);

                /*" -1478- MOVE 'S' TO WFIM-V0MSGCOBR */
                _.Move("S", AREA_DE_WORK.WFIM_V0MSGCOBR);

                /*" -1478- PERFORM R0310_00_FETCH_V0MSGCOBR_DB_CLOSE_2 */

                R0310_00_FETCH_V0MSGCOBR_DB_CLOSE_2();

                /*" -1481- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1482- MOVE V0MENS-APOLICE TO TABJ-APOLICE (WINDM). */
            _.Move(V0MENS_APOLICE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_APOLICE);

            /*" -1483- MOVE V0MENS-CODSUBES TO TABJ-CODSUBES (WINDM). */
            _.Move(V0MENS_CODSUBES, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODSUBES);

            /*" -1484- MOVE V0MENS-CODOPER TO TABJ-CODOPER (WINDM). */
            _.Move(V0MENS_CODOPER, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODOPER);

            /*" -1485- MOVE V0MENS-JDE TO TABJ-JDE (WINDM). */
            _.Move(V0MENS_JDE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDE);

            /*" -1487- MOVE V0MENS-JDL TO TABJ-JDL (WINDM). */
            _.Move(V0MENS_JDL, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDL);

            /*" -1487- GO TO R0310-00-FETCH-V0MSGCOBR. */
            new Task(() => R0310_00_FETCH_V0MSGCOBR_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0MSGCOBR-DB-FETCH-1 */
        public void R0310_00_FETCH_V0MSGCOBR_DB_FETCH_1()
        {
            /*" -1465- EXEC SQL FETCH CMSG INTO :V0MENS-APOLICE, :V0MENS-CODSUBES, :V0MENS-CODOPER, :V0MENS-JDE, :V0MENS-JDL END-EXEC. */

            if (CMSG.Fetch())
            {
                _.Move(CMSG.V0MENS_APOLICE, V0MENS_APOLICE);
                _.Move(CMSG.V0MENS_CODSUBES, V0MENS_CODSUBES);
                _.Move(CMSG.V0MENS_CODOPER, V0MENS_CODOPER);
                _.Move(CMSG.V0MENS_JDE, V0MENS_JDE);
                _.Move(CMSG.V0MENS_JDL, V0MENS_JDL);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0MSGCOBR-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0MSGCOBR_DB_CLOSE_1()
        {
            /*" -1469- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0MSGCOBR-DB-CLOSE-2 */
        public void R0310_00_FETCH_V0MSGCOBR_DB_CLOSE_2()
        {
            /*" -1478- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-SECTION */
        private void R0500_00_DECLARE_V1AGENCEF_SECTION()
        {
            /*" -1500- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1517- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -1519- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -1522- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1523- DISPLAY 'R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -1524- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1524- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -1519- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -1624- EXEC SQL DECLARE CHISTCOB CURSOR FOR SELECT A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.DTVENCTO, A.VLPRMTOT, A.CODOPER, A.OPCAOPAG, A.NRTITCOMP, B.CODPRODU, B.OCORHIST, B.CODCLIEN, B.IDE_SEXO, B.OPCAO_COBER, B.NUM_APOLICE, B.CODSUBES, B.AGECOBR, B.FONTE FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOSVG C, SEGUROS.COBRANCA_MENS_VGAP D WHERE A.SITUACAO = '5' AND B.NRCERTIF = A.NRCERTIF AND B.SITUACAO IN ( '3' , '6' ) AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.CODSUBES AND C.ORIG_PRODU IN ( 'MULT' , 'VIDAZUL' ) AND D.NUM_APOLICE = B.NUM_APOLICE AND D.CODSUBES = B.CODSUBES AND D.IDFORM = 'PI' AND D.COD_OPERACAO = A.CODOPER END-EXEC. */
            CHISTCOB = new VA2513B_CHISTCOB(false);
            string GetQuery_CHISTCOB()
            {
                var query = @$"SELECT 
							A.NRCERTIF
							, 
							A.NRPARCEL
							, 
							A.NRTIT
							, 
							A.DTVENCTO
							, 
							A.VLPRMTOT
							, 
							A.CODOPER
							, 
							A.OPCAOPAG
							, 
							A.NRTITCOMP
							, 
							B.CODPRODU
							, 
							B.OCORHIST
							, 
							B.CODCLIEN
							, 
							B.IDE_SEXO
							, 
							B.OPCAO_COBER
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.AGECOBR
							, 
							B.FONTE 
							FROM SEGUROS.V0HISTCOBVA A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PRODUTOSVG C
							, 
							SEGUROS.COBRANCA_MENS_VGAP D 
							WHERE A.SITUACAO = '5' 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.SITUACAO IN ( '3'
							, '6' ) 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.CODSUBES = B.CODSUBES 
							AND C.ORIG_PRODU IN ( 'MULT'
							, 'VIDAZUL' ) 
							AND D.NUM_APOLICE = B.NUM_APOLICE 
							AND D.CODSUBES = B.CODSUBES 
							AND D.IDFORM = 'PI' 
							AND D.COD_OPERACAO = A.CODOPER";

                return query;
            }
            CHISTCOB.GetQueryEvent += GetQuery_CHISTCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-SECTION */
        private void R0510_00_FETCH_V1AGENCEF_SECTION()
        {
            /*" -1537- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1546- PERFORM R0510_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            R0510_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -1549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1550- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1551- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AGENCEF);

                    /*" -1551- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -1553- ELSE */
                }
                else
                {


                    /*" -1553- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -1555- DISPLAY 'R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -1556- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1556- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -1546- EXEC SQL FETCH V1AGENCEF INTO :V1MCEF-COD-FONTE, :V1FONT-NOMEFTE, :V1FONT-ENDERFTE, :V1FONT-BAIRRO, :V1FONT-CIDADE, :V1FONT-CEP, :V1FONT-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
                _.Move(V1AGENCEF.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
                _.Move(V1AGENCEF.V1FONT_ENDERFTE, V1FONT_ENDERFTE);
                _.Move(V1AGENCEF.V1FONT_BAIRRO, V1FONT_BAIRRO);
                _.Move(V1AGENCEF.V1FONT_CIDADE, V1FONT_CIDADE);
                _.Move(V1AGENCEF.V1FONT_CEP, V1FONT_CEP);
                _.Move(V1AGENCEF.V1FONT_UF, V1FONT_UF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -1551- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -1553- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1569- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1570- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(V1MCEF_COD_FONTE, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -1571- MOVE V1FONT-NOMEFTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(V1FONT_NOMEFTE, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -1572- MOVE V1FONT-ENDERFTE TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(V1FONT_ENDERFTE, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -1573- MOVE V1FONT-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(V1FONT_BAIRRO, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -1574- MOVE V1FONT-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(V1FONT_CIDADE, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -1575- MOVE V1FONT-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(V1FONT_CEP, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -1577- MOVE V1FONT-UF TO TAB-UF (IDX-IND1) */
            _.Move(V1FONT_UF, TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -1577- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-SECTION */
        private void R0900_00_DECLARE_V0HISTCOBVA_SECTION()
        {
            /*" -1590- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1624- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -1626- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -1626- EXEC SQL OPEN CHISTCOB END-EXEC. */

            CHISTCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0910_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -1639- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -1658- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -1661- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1662- MOVE 'S' TO WFIM-V0HISTCOBVA */
                _.Move("S", AREA_DE_WORK.WFIM_V0HISTCOBVA);

                /*" -1664- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1664- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -1667- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1668- IF VIND-NRTITCOMP < ZEROS */

            if (VIND_NRTITCOMP < 00)
            {

                /*" -1670- MOVE ZEROS TO V0HIST-NRTITCOMP. */
                _.Move(0, V0HIST_NRTITCOMP);
            }


            /*" -1673- ADD 1 TO AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1674- IF AC-CONTA > 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -1675- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1676- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1676- DISPLAY '**** LIDOS V0HISTCOBVA ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS V0HISTCOBVA {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -1658- EXEC SQL FETCH CHISTCOB INTO :V0HIST-NRCERTIF, :V0HIST-NRPARCEL, :V0HIST-NRTIT, :V0HIST-DTVENCTO, :V0HIST-VLPRMTOT, :V0HIST-CODOPER, :V0HIST-OPCAOPAG, :V0HIST-NRTITCOMP, :V0HIST-CODPRODU, :V0HIST-OCORHIST, :V0HIST-CDCLIENTE, :V0HIST-IDSEXO, :V0HIST-OPCOBERT, :V0HIST-NRAPOLICE, :V0HIST-CODSUBES, :V0HIST-AGECOBR, :V0HIST-FONTE END-EXEC. */

            if (CHISTCOB.Fetch())
            {
                _.Move(CHISTCOB.V0HIST_NRCERTIF, V0HIST_NRCERTIF);
                _.Move(CHISTCOB.V0HIST_NRPARCEL, V0HIST_NRPARCEL);
                _.Move(CHISTCOB.V0HIST_NRTIT, V0HIST_NRTIT);
                _.Move(CHISTCOB.V0HIST_DTVENCTO, V0HIST_DTVENCTO);
                _.Move(CHISTCOB.V0HIST_VLPRMTOT, V0HIST_VLPRMTOT);
                _.Move(CHISTCOB.V0HIST_CODOPER, V0HIST_CODOPER);
                _.Move(CHISTCOB.V0HIST_OPCAOPAG, V0HIST_OPCAOPAG);
                _.Move(CHISTCOB.V0HIST_NRTITCOMP, V0HIST_NRTITCOMP);
                _.Move(CHISTCOB.V0HIST_CODPRODU, V0HIST_CODPRODU);
                _.Move(CHISTCOB.V0HIST_OCORHIST, V0HIST_OCORHIST);
                _.Move(CHISTCOB.V0HIST_CDCLIENTE, V0HIST_CDCLIENTE);
                _.Move(CHISTCOB.V0HIST_IDSEXO, V0HIST_IDSEXO);
                _.Move(CHISTCOB.V0HIST_OPCOBERT, V0HIST_OPCOBERT);
                _.Move(CHISTCOB.V0HIST_NRAPOLICE, V0HIST_NRAPOLICE);
                _.Move(CHISTCOB.V0HIST_CODSUBES, V0HIST_CODSUBES);
                _.Move(CHISTCOB.V0HIST_AGECOBR, V0HIST_AGECOBR);
                _.Move(CHISTCOB.V0HIST_FONTE, V0HIST_FONTE);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1()
        {
            /*" -1664- EXEC SQL CLOSE CHISTCOB END-EXEC */

            CHISTCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1689- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1691- PERFORM R1200-00-SELECT-V0CLIENTE. */

            R1200_00_SELECT_V0CLIENTE_SECTION();

            /*" -1692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1694- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1696- PERFORM R1210-00-SELECT-V0SEGURAVG. */

            R1210_00_SELECT_V0SEGURAVG_SECTION();

            /*" -1697- IF V0SEGV-SIT-REGISTRO EQUAL '2' */

            if (V0SEGV_SIT_REGISTRO == "2")
            {

                /*" -1699- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1701- PERFORM R1300-00-SELECT-V0ENDERECO. */

            R1300_00_SELECT_V0ENDERECO_SECTION();

            /*" -1703- PERFORM R1500-00-SELECT-V1AGENCEF. */

            R1500_00_SELECT_V1AGENCEF_SECTION();

            /*" -1704- MOVE V1MCEF-COD-FONTE TO SVA-FONTE. */
            _.Move(V1MCEF_COD_FONTE, REG_SVA2513B.SVA_FONTE);

            /*" -1705- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVA2513B.SVA_NOME_RAZAO);

            /*" -1706- MOVE V0CLIE-CPF TO SVA-NRCPF. */
            _.Move(V0CLIE_CPF, REG_SVA2513B.SVA_NRCPF);

            /*" -1707- MOVE V0CLIE-DTNASC TO SVA-DTNASC. */
            _.Move(V0CLIE_DTNASC, REG_SVA2513B.SVA_DTNASC);

            /*" -1708- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVA2513B.SVA_ENDERECO);

            /*" -1709- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVA2513B.SVA_BAIRRO);

            /*" -1710- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVA2513B.SVA_CIDADE);

            /*" -1711- MOVE V0ENDE-UF TO SVA-UF. */
            _.Move(V0ENDE_UF, REG_SVA2513B.SVA_UF);

            /*" -1712- MOVE V0ENDE-CEP TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1713- MOVE V0HIST-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0HIST_NRCERTIF, REG_SVA2513B.SVA_NRCERTIF);

            /*" -1714- MOVE V0HIST-NRTIT TO SVA-NRTIT. */
            _.Move(V0HIST_NRTIT, REG_SVA2513B.SVA_NRTIT);

            /*" -1715- MOVE V0HIST-NRTITCOMP TO SVA-NRTITCOMP. */
            _.Move(V0HIST_NRTITCOMP, REG_SVA2513B.SVA_NRTITCOMP);

            /*" -1716- MOVE V0HIST-NRPARCEL TO SVA-NRPARCEL. */
            _.Move(V0HIST_NRPARCEL, REG_SVA2513B.SVA_NRPARCEL);

            /*" -1717- MOVE V0HIST-DTVENCTO TO SVA-DTVENCTO. */
            _.Move(V0HIST_DTVENCTO, REG_SVA2513B.SVA_DTVENCTO);

            /*" -1718- MOVE V0HIST-VLPRMTOT TO SVA-VLPRMTOT. */
            _.Move(V0HIST_VLPRMTOT, REG_SVA2513B.SVA_VLPRMTOT);

            /*" -1719- MOVE V0HIST-OPCAOPAG TO SVA-OPCAOPAG. */
            _.Move(V0HIST_OPCAOPAG, REG_SVA2513B.SVA_OPCAOPAG);

            /*" -1720- MOVE V0HIST-CODOPER TO SVA-CODOPER. */
            _.Move(V0HIST_CODOPER, REG_SVA2513B.SVA_CODOPER);

            /*" -1721- MOVE V0HIST-OCORHIST TO SVA-OCORHIST. */
            _.Move(V0HIST_OCORHIST, REG_SVA2513B.SVA_OCORHIST);

            /*" -1722- MOVE V0HIST-CODPRODU TO SVA-CODPRODU. */
            _.Move(V0HIST_CODPRODU, REG_SVA2513B.SVA_CODPRODU);

            /*" -1723- MOVE V0SEGV-IDE-SEXO TO SVA-IDE-SEXO. */
            _.Move(V0SEGV_IDE_SEXO, REG_SVA2513B.SVA_IDE_SEXO);

            /*" -1724- MOVE V0HIST-OPCOBERT TO SVA-OPCOBERT. */
            _.Move(V0HIST_OPCOBERT, REG_SVA2513B.SVA_OPCOBERT);

            /*" -1725- MOVE V0HIST-NRAPOLICE TO SVA-NRAPOLICE. */
            _.Move(V0HIST_NRAPOLICE, REG_SVA2513B.SVA_NRAPOLICE);

            /*" -1726- MOVE V0HIST-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0HIST_CODSUBES, REG_SVA2513B.SVA_CODSUBES);

            /*" -1727- MOVE V0HIST-NRAPOLICE TO WHOST-NRAPOLICE. */
            _.Move(V0HIST_NRAPOLICE, WHOST_NRAPOLICE);

            /*" -1729- MOVE V0HIST-CODSUBES TO WHOST-CODSUBES. */
            _.Move(V0HIST_CODSUBES, WHOST_CODSUBES);

            /*" -1731- PERFORM R2750-00-SELECT-V0CONDTEC. */

            R2750_00_SELECT_V0CONDTEC_SECTION();

            /*" -1732- IF WS-CAR-CONJUGE EQUAL ZEROES */

            if (AREA_DE_WORK.WS_CAR_CONJUGE == 00)
            {

                /*" -1733- MOVE '02' TO SVA-TEXTO */
                _.Move("02", REG_SVA2513B.SVA_TEXTO);

                /*" -1734- ELSE */
            }
            else
            {


                /*" -1736- MOVE '01' TO SVA-TEXTO. */
                _.Move("01", REG_SVA2513B.SVA_TEXTO);
            }


            /*" -1737- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -1738- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVA2513B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -1739- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVA2513B.SVA_NUM_CEP.SVA_CEP);

                /*" -1740- ELSE */
            }
            else
            {


                /*" -1741- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVA2513B.SVA_NUM_CEP.SVA_CEP);

                /*" -1743- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVA2513B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -1744- IF V0ENDE-CEP EQUAL ZEROS */

            if (V0ENDE_CEP == 00)
            {

                /*" -1745- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA2513B.SVA_CEP_G);

                /*" -1746- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA2513B.SVA_NOME_CORREIO);

                /*" -1747- ELSE */
            }
            else
            {


                /*" -1749- PERFORM R1900-00-LOCALIZA-CEP. */

                R1900_00_LOCALIZA_CEP_SECTION();
            }


            /*" -1749- RELEASE REG-SVA2513B. */
            SVA2513B.Release(REG_SVA2513B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1753- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-SECTION */
        private void R1200_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -1766- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1775- PERFORM R1200_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1200_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1778- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1779- DISPLAY 'VA2513B - PROBLEMAS NO ACESSO A V0CLIENTE' */
                _.Display($"VA2513B - PROBLEMAS NO ACESSO A V0CLIENTE");

                /*" -1780- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1780- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1200_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -1775- EXEC SQL SELECT NOME_RAZAO, CGCCPF, DATA_NASCIMENTO INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CPF, :V0CLIE-DTNASC:V0CLIE-IDTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0HIST-CDCLIENTE END-EXEC. */

            var r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0HIST_CDCLIENTE = V0HIST_CDCLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(executed_1.V0CLIE_CPF, V0CLIE_CPF);
                _.Move(executed_1.V0CLIE_DTNASC, V0CLIE_DTNASC);
                _.Move(executed_1.V0CLIE_IDTNASC, V0CLIE_IDTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-V0SEGURAVG-SECTION */
        private void R1210_00_SELECT_V0SEGURAVG_SECTION()
        {
            /*" -1793- MOVE '121' TO WNR-EXEC-SQL. */
            _.Move("121", WABEND.WNR_EXEC_SQL);

            /*" -1800- PERFORM R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1 */

            R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1();

            /*" -1803- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1804- DISPLAY 'VA2513B - PROBLEMAS NO ACESSO A V0SEGURAVG' */
                _.Display($"VA2513B - PROBLEMAS NO ACESSO A V0SEGURAVG");

                /*" -1805- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1805- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-V0SEGURAVG-DB-SELECT-1 */
        public void R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1()
        {
            /*" -1800- EXEC SQL SELECT SIT_REGISTRO , IDE_SEXO INTO :V0SEGV-SIT-REGISTRO , :V0SEGV-IDE-SEXO FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0HIST-NRCERTIF END-EXEC. */

            var r1210_00_SELECT_V0SEGURAVG_DB_SELECT_1_Query1 = new R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1_Query1()
            {
                V0HIST_NRCERTIF = V0HIST_NRCERTIF.ToString(),
            };

            var executed_1 = R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_V0SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGV_SIT_REGISTRO, V0SEGV_SIT_REGISTRO);
                _.Move(executed_1.V0SEGV_IDE_SEXO, V0SEGV_IDE_SEXO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-SECTION */
        private void R1300_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -1818- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1832- PERFORM R1300_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -1835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1836- DISPLAY 'VA2513B - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"VA2513B - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -1837- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1837- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -1832- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-UF, :V0ENDE-CEP FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0HIST-CDCLIENTE AND OCORR_ENDERECO = 1 END-EXEC. */

            var r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1()
            {
                V0HIST_CDCLIENTE = V0HIST_CDCLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(executed_1.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(executed_1.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(executed_1.V0ENDE_UF, V0ENDE_UF);
                _.Move(executed_1.V0ENDE_CEP, V0ENDE_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-SECTION */
        private void R1500_00_SELECT_V1AGENCEF_SECTION()
        {
            /*" -1850- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1859- PERFORM R1500_00_SELECT_V1AGENCEF_DB_SELECT_1 */

            R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();

            /*" -1862- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1863- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1864- MOVE V0HIST-FONTE TO V1MCEF-COD-FONTE */
                    _.Move(V0HIST_FONTE, V1MCEF_COD_FONTE);

                    /*" -1865- ELSE */
                }
                else
                {


                    /*" -1866- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                    /*" -1867- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1867- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_V1AGENCEF_DB_SELECT_1()
        {
            /*" -1859- EXEC SQL SELECT B.COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 1000 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :V0HIST-AGECOBR END-EXEC. */

            var r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1()
            {
                V0HIST_AGECOBR = V0HIST_AGECOBR.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -1877- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -1882- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1884- DISPLAY '*** VA2513B CEP NAO ENCONTRADO ' V0ENDE-CEP ' ' V0HIST-NRCERTIF */

                $"*** VA2513B CEP NAO ENCONTRADO {V0ENDE_CEP} {V0HIST_NRCERTIF}"
                .Display();

                /*" -1885- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA2513B.SVA_CEP_G);

                /*" -1886- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA2513B.SVA_NOME_CORREIO);

                /*" -1888- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1889- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -1891- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -1892- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -1894- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -1896- IF V0ENDE-CEP GREATER WS-INF AND V0ENDE-CEP LESS WS-SUP */

            if (V0ENDE_CEP > AREA_DE_WORK.WS_INF && V0ENDE_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -1897- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SVA2513B.SVA_CEP_G);

                /*" -1898- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SVA2513B.SVA_NOME_CORREIO);

                /*" -1899- ELSE */
            }
            else
            {


                /*" -1900- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -1900- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1915- MOVE SVA-CODPRODU TO WHOST-CODPRODU. */
            _.Move(REG_SVA2513B.SVA_CODPRODU, WHOST_CODPRODU);

            /*" -1918- MOVE SVA-NRAPOLICE TO WHOST-NRAPOLICE WS-APOLICE-ANT. */
            _.Move(REG_SVA2513B.SVA_NRAPOLICE, WHOST_NRAPOLICE, AREA_DE_WORK.WS_APOLICE_ANT);

            /*" -1921- MOVE SVA-CODSUBES TO WHOST-CODSUBES WS-CODSUBES-ANT. */
            _.Move(REG_SVA2513B.SVA_CODSUBES, WHOST_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT);

            /*" -1923- PERFORM R2900-00-TRATA-V0RELATORIOS. */

            R2900_00_TRATA_V0RELATORIOS_SECTION();

            /*" -1925- PERFORM R2950-00-SELECT-V0PRODUTOSVG. */

            R2950_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -1926- MOVE V0PROD-CODPRODU TO LR08-COD-PRODUTO */
            _.Move(V0PROD_CODPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

            /*" -1928- MOVE V0PROD-NOMPRODU TO LR08-NOM-PRODUTO. */
            _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_NOM_PRODUTO);

            /*" -1933- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-NRAPOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA2513B.SVA_NRAPOLICE != AREA_DE_WORK.WS_APOLICE_ANT || REG_SVA2513B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -1935- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -1937- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -1938- IF WCONTROLE EQUAL 'N' */

            if (AREA_DE_WORK.WCONTROLE == "N")
            {

                /*" -1939- WRITE FVA2513B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

                /*" -1941- WRITE FVA2513B-RECORD FROM LC01-LINHA01. */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());
            }


            /*" -1943- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -1945- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -1957- MOVE ZEROS TO TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR WIND. */
            _.Move(0, TABELA_TOTAIS, AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ, AREA_DE_WORK.WS_CONTR_200, AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.WS_OCORR, AREA_DE_WORK.WIND);

            /*" -1960- IF WFIM-SORT NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SORT != "S")
            {

                /*" -1961- WRITE RVA2513B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -1962- WRITE RVA2513B-RECORD FROM LC09-LINHA09 */
                _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -1962- WRITE RVA2513B-RECORD FROM LC10-LINHA10. */
                _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -1974- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVA2513B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -1975- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVA2513B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -1978- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -1979- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVA2513B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1980- MOVE WS-CEP-AUX TO LF04-FAIXA1. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA1);

            /*" -1981- MOVE WS-CEP-COMPL-AUX TO LF04-FAIXA1C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA1C);

            /*" -1982- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVA2513B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1983- MOVE WS-CEP-AUX TO LF04-FAIXA2. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA2);

            /*" -1986- MOVE WS-CEP-COMPL-AUX TO LF04-FAIXA2C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA2C);

            /*" -1992- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-NRAPOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA2513B.SVA_NRAPOLICE != AREA_DE_WORK.WS_APOLICE_ANT || REG_SVA2513B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVA2513B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -1993- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARF);

            /*" -1993- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -2008- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -2015- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-NRAPOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199. */

            while (!(REG_SVA2513B.SVA_NRAPOLICE != AREA_DE_WORK.WS_APOLICE_ANT || REG_SVA2513B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVA2513B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -2018- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR (WS-CEP-G-ANT). */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -2019- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -2020- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -2023- MOVE WS-AMARRADO TO TAB1-AMARI (WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -2024- MOVE WS-AMARRADO TO LF04-AMARRADO. */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF04_AMARRADO);

            /*" -2025- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -2026- MOVE WS-SEQ-INICIAL TO LF04-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF04_SEQ_INICIAL);

            /*" -2030- MOVE WS-SEQ TO LF04-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF04_LINHA04.LF04_SEQ_FINAL);

            /*" -2031- WRITE RVA2513B-RECORD FROM LC12-LINHA12 */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2032- WRITE RVA2513B-RECORD FROM LC01-LINHA01 */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2033- WRITE RVA2513B-RECORD FROM LF01-LINHA01. */
            _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2034- WRITE RVA2513B-RECORD FROM LC08-LINHA08 */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2035- WRITE RVA2513B-RECORD FROM LF02-LINHA02. */
            _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2037- WRITE RVA2513B-RECORD FROM LF03-LINHA03. */
            _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2038- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -2040- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF04-NOME-FAIXA */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, AREA_DE_WORK.LF04_LINHA04.LF04_NOME_FAIXA);

                /*" -2041- ELSE */
            }
            else
            {


                /*" -2044- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF04-NOME-FAIXA. */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, AREA_DE_WORK.LF04_LINHA04.LF04_NOME_FAIXA);
            }


            /*" -2046- WRITE RVA2513B-RECORD FROM LF04-LINHA04. */
            _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2048- MOVE 'N' TO WCONTROLE */
            _.Move("N", AREA_DE_WORK.WCONTROLE);

            /*" -2051- IF WFIM-SORT NOT EQUAL 'S' AND SVA-NRAPOLICE EQUAL WS-APOLICE-ANT AND SVA-CODSUBES EQUAL WS-CODSUBES-ANT */

            if (AREA_DE_WORK.WFIM_SORT != "S" && REG_SVA2513B.SVA_NRAPOLICE == AREA_DE_WORK.WS_APOLICE_ANT && REG_SVA2513B.SVA_CODSUBES == AREA_DE_WORK.WS_CODSUBES_ANT)
            {

                /*" -2052- MOVE 'S' TO WCONTROLE */
                _.Move("S", AREA_DE_WORK.WCONTROLE);

                /*" -2053- WRITE RVA2513B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2054- WRITE RVA2513B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2055- WRITE RVA2513B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2056- WRITE RVA2513B-RECORD FROM LC09-LINHA09 */
                _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2058- WRITE RVA2513B-RECORD FROM LC10-LINHA10. */
                _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());
            }


            /*" -2059- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

            /*" -2059- MOVE 1 TO WS-CONTROLE. */
            _.Move(1, AREA_DE_WORK.WS_CONTROLE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -2071- MOVE SVA-NRCERTIF TO WHOST-NRCERTIF. */
            _.Move(REG_SVA2513B.SVA_NRCERTIF, WHOST_NRCERTIF);

            /*" -2072- MOVE SVA-NRPARCEL TO WHOST-NRPARCEL. */
            _.Move(REG_SVA2513B.SVA_NRPARCEL, WHOST_NRPARCEL);

            /*" -2074- MOVE SVA-NRTIT TO WHOST-NRTIT. */
            _.Move(REG_SVA2513B.SVA_NRTIT, WHOST_NRTIT);

            /*" -2076- MOVE 1 TO INF */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -2078- MOVE WINDM TO SUP */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -2080- PERFORM R2600-00-IDENTIFICA-MSG */

            R2600_00_IDENTIFICA_MSG_SECTION();

            /*" -2082- PERFORM R2700-00-FORMATA-NOME-RAZAO */

            R2700_00_FORMATA_NOME_RAZAO_SECTION();

            /*" -2084- MOVE SVA-TEXTO TO LC11-TEXTO */
            _.Move(REG_SVA2513B.SVA_TEXTO, AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

            /*" -2085- MOVE SVA-NUM-CEP TO LC11-CEP */
            _.Move(REG_SVA2513B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

            /*" -2086- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL */
            _.Move(REG_SVA2513B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

            /*" -2087- MOVE SVA-CIDADE TO LC11-CIDADE */
            _.Move(REG_SVA2513B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

            /*" -2088- MOVE SVA-BAIRRO TO LC11-BAIRRO */
            _.Move(REG_SVA2513B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

            /*" -2089- MOVE SVA-UF TO LC11-UF */
            _.Move(REG_SVA2513B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

            /*" -2091- MOVE SVA-ENDERECO TO LC11-ENDERECO */
            _.Move(REG_SVA2513B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

            /*" -2092- IF SVA-CODPRODU = 9309 */

            if (REG_SVA2513B.SVA_CODPRODU == 9309)
            {

                /*" -2096- MOVE 'PI045-02/2002 Cod. prod. 9309 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10' TO LC11-PRODUTO */
                $"PI045-02/2002 Cod. prod. 9309 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10"
                .Move(AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO);

                /*" -2097- ELSE */
            }
            else
            {


                /*" -2099- IF SVA-CODPRODU = ( 9320 OR JVPRD9320 ) */

                if (REG_SVA2513B.SVA_CODPRODU.In("9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString()))
                {

                    /*" -2103- MOVE 'PI045-04/2006 Cod. prod. 9320 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10' TO LC11-PRODUTO */
                    $"PI045-04/2006 Cod. prod. 9320 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10"
                    .Move(AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO);

                    /*" -2104- ELSE */
                }
                else
                {


                    /*" -2106- IF SVA-CODPRODU = ( 9321 OR JVPRD9321 ) */

                    if (REG_SVA2513B.SVA_CODPRODU.In("9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString()))
                    {

                        /*" -2110- MOVE 'PI045-04/2006 Cod. prod. 9321 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10' TO LC11-PRODUTO */
                        $"PI045-04/2006 Cod. prod. 9321 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10"
                        .Move(AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO);

                        /*" -2111- ELSE */
                    }
                    else
                    {


                        /*" -2116- MOVE 'PI045-02/2002 Cod. prod. 9309 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10' TO LC11-PRODUTO. */
                        $"PI045-02/2002 Cod. prod. 9309 proc. SUSEP 10.002684/01-29 ' CNPJ 34.020.354/0001-10"
                        .Move(AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO);
                    }

                }

            }

            /*" -2120- ADD 1 TO WS-SEQ TAB1-QTD-OBJ (WS-CEP-G-ANT) AC-QTD-OBJ AC-CONTA1 */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_OBJ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -2122- MOVE WS-SEQ TO LC11-SEQUENCIA */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

            /*" -2123- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -2124- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -2127- MOVE WS-SEQ TO TAB1-OBJI (WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJI);
            }


            /*" -2128- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -2129- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -2131- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);
            }


            /*" -2133- WRITE RVA2513B-RECORD FROM LC11-LINHA11. */
            _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2134- IF SVA-OPCAOPAG EQUAL '1' OR '2' */

            if (REG_SVA2513B.SVA_OPCAOPAG.In("1", "2"))
            {

                /*" -2136- PERFORM R2850-00-UPDATE-V0HISTCOBVA. */

                R2850_00_UPDATE_V0HISTCOBVA_SECTION();
            }


            /*" -2138- ADD 1 TO AC-IMPRESSOS. */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -2138- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -2151- RETURN SVA2513B AT END */
            try
            {
                SVA2513B.Return(REG_SVA2513B, () =>
                {

                    /*" -2152- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -2154- GO TO R2400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2157- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -2158- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -2159- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -2160- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -2160- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-IDENTIFICA-MSG-SECTION */
        private void R2600_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -2172- IF INF > SUP */

            if (AREA_DE_WORK.INF > AREA_DE_WORK.SUP)
            {

                /*" -2173- MOVE 'N' TO WTEM-MULTIMSG */
                _.Move("N", AREA_DE_WORK.WTEM_MULTIMSG);

                /*" -2174- ELSE */
            }
            else
            {


                /*" -2175- COMPUTE WS-IND = (SUP + INF) / 2 */
                AREA_DE_WORK.WS_IND.Value = (AREA_DE_WORK.SUP + AREA_DE_WORK.INF) / 2;

                /*" -2176- IF WS-CHAVE < TABJ-CHAVE (WS-IND) */

                if (AREA_DE_WORK.WS_CHAVE < TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE)
                {

                    /*" -2177- COMPUTE SUP = WS-IND - 1 */
                    AREA_DE_WORK.SUP.Value = AREA_DE_WORK.WS_IND - 1;

                    /*" -2178- GO TO R2600-00-IDENTIFICA-MSG */
                    new Task(() => R2600_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2179- ELSE */
                }
                else
                {


                    /*" -2180- IF WS-CHAVE > TABJ-CHAVE (WS-IND) */

                    if (AREA_DE_WORK.WS_CHAVE > TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE)
                    {

                        /*" -2181- COMPUTE INF = WS-IND + 1 */
                        AREA_DE_WORK.INF.Value = AREA_DE_WORK.WS_IND + 1;

                        /*" -2182- GO TO R2600-00-IDENTIFICA-MSG */
                        new Task(() => R2600_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -2183- ELSE */
                    }
                    else
                    {


                        /*" -2185- MOVE 'S' TO WTEM-MULTIMSG. */
                        _.Move("S", AREA_DE_WORK.WTEM_MULTIMSG);
                    }

                }

            }


            /*" -2186- IF WTEM-MULTIMSG = 'S' */

            if (AREA_DE_WORK.WTEM_MULTIMSG == "S")
            {

                /*" -2188- MOVE TABJ-JDE (WS-IND) TO WS-JDE LM01-JDE */
                _.Move(TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE, AREA_DE_WORK.LM01_LINHA01.LM01_JDE);

                /*" -2190- MOVE 'DBM' TO WS-DBM */
                _.Move("DBM", AREA_DE_WORK.WS_JDE_GER.WS_DBM);

                /*" -2191- ELSE */
            }
            else
            {


                /*" -2192- MOVE SVA-CODOPER TO WHOST-CODOPER */
                _.Move(REG_SVA2513B.SVA_CODOPER, WHOST_CODOPER);

                /*" -2193- PERFORM R2610-00-SELECT-V0MULTIMENS */

                R2610_00_SELECT_V0MULTIMENS_SECTION();

                /*" -2195- MOVE V0MENS-JDE TO WS-JDE LM01-JDE */
                _.Move(V0MENS_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE, AREA_DE_WORK.LM01_LINHA01.LM01_JDE);

                /*" -2198- MOVE 'DBM' TO WS-DBM */
                _.Move("DBM", AREA_DE_WORK.WS_JDE_GER.WS_DBM);

                /*" -2200- END-IF */
            }


            /*" -2201- MOVE SPACES TO LC09-LIN09 */
            _.Move("", AREA_DE_WORK.FILLER_5.LC09_LIN09);

            /*" -2202- MOVE FUNCTION LOWER-CASE(WS-JDE) TO WS-JDE-TFORM */
            _.Move(AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower(), AREA_DE_WORK.WS_JDE_TFORM);

            /*" -2203-  EVALUATE TRUE  */

            /*" -2204-  WHEN WS-JDE(5:1)            = ' '  */

            /*" -2204- IF WS-JDE(5:1)            = ' ' */

            if (AREA_DE_WORK.WS_JDE_GER.WS_JDE.Substring(5, 1) == " ")
            {

                /*" -2206- STRING '(' WS-JDE-TFORM(1:4) '.dbm) STARTDBM' DELIMITED BY SIZE INTO LC09-LIN09 */
                #region STRING
                var spl1 = "(" + AREA_DE_WORK.WS_JDE_TFORM.Substring(1, 4).GetMoveValues();
                spl1 += ".dbm) STARTDBM";
                _.Move(spl1, AREA_DE_WORK.FILLER_5.LC09_LIN09);
                #endregion

                /*" -2207-  WHEN WS-JDE(8:1)            = ' '  */

                /*" -2207- ELSE IF WS-JDE(8:1)            = ' ' */
            }
            else

            if (AREA_DE_WORK.WS_JDE_GER.WS_JDE.Substring(8, 1) == " ")
            {

                /*" -2209- STRING '(' WS-JDE-TFORM(1:7) '.dbm) STARTDBM' DELIMITED BY SIZE INTO LC09-LIN09 */
                #region STRING
                var spl2 = "(" + AREA_DE_WORK.WS_JDE_TFORM.Substring(1, 7).GetMoveValues();
                spl2 += ".dbm) STARTDBM";
                _.Move(spl2, AREA_DE_WORK.FILLER_5.LC09_LIN09);
                #endregion

                /*" -2210-  WHEN WS-JDE(8:1)        NOT = ' '  */

                /*" -2210- ELSE IF WS-JDE(8:1)        NOT = ' ' */
            }
            else

            if (AREA_DE_WORK.WS_JDE_GER.WS_JDE.Substring(8, 1) != " ")
            {

                /*" -2212- STRING '(' WS-JDE-TFORM(1:8) '.dbm) STARTDBM' DELIMITED BY SIZE INTO LC09-LIN09 */
                #region STRING
                var spl3 = "(" + AREA_DE_WORK.WS_JDE_TFORM.Substring(1, 8).GetMoveValues();
                spl3 += ".dbm) STARTDBM";
                _.Move(spl3, AREA_DE_WORK.FILLER_5.LC09_LIN09);
                #endregion

                /*" -2213-  WHEN OTHER  */

                /*" -2213- ELSE */
            }
            else
            {


                /*" -2215- DISPLAY 'R2600 - NAO FOI PREVISTO ESTE TIPO DE ' 'FORMULARIO ' WS-JDE */

                $"R2600 - NAO FOI PREVISTO ESTE TIPO DE FORMULARIO {AREA_DE_WORK.WS_JDE_GER.WS_JDE}"
                .Display();

                /*" -2216- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2218-  END-EVALUATE.  */

                /*" -2218- END-IF. */
            }


            /*" -2219- IF LM01-JDE NOT EQUAL WS-JDE-ANT */

            if (AREA_DE_WORK.LM01_LINHA01.LM01_JDE != AREA_DE_WORK.WS_JDE_ANT)
            {

                /*" -2220- MOVE LM01-JDE TO WS-JDE-ANT */
                _.Move(AREA_DE_WORK.LM01_LINHA01.LM01_JDE, AREA_DE_WORK.WS_JDE_ANT);

                /*" -2221- WRITE RVA2513B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2222- WRITE RVA2513B-RECORD FROM LC09-LINHA09 */
                _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2222- WRITE RVA2513B-RECORD FROM LC10-LINHA10. */
                _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-SELECT-V0MULTIMENS-SECTION */
        private void R2610_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -2235- MOVE '261' TO WNR-EXEC-SQL */
            _.Move("261", WABEND.WNR_EXEC_SQL);

            /*" -2245- PERFORM R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -2248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2249- DISPLAY 'VA2513B NAO ENCONTRADO NA V0MSGCOBR   ' */
                _.Display($"VA2513B NAO ENCONTRADO NA V0MSGCOBR   ");

                /*" -2250- DISPLAY '        APOLICE....... ' WHOST-NRAPOLICE */
                _.Display($"        APOLICE....... {WHOST_NRAPOLICE}");

                /*" -2251- DISPLAY '        SUBGRUPO...... ' WHOST-CODSUBES */
                _.Display($"        SUBGRUPO...... {WHOST_CODSUBES}");

                /*" -2252- DISPLAY '        OPERACAO...... ' WHOST-CODOPER */
                _.Display($"        OPERACAO...... {WHOST_CODOPER}");

                /*" -2252- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2610-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -2245- EXEC SQL SELECT JDE, JDL INTO :V0MENS-JDE, :V0MENS-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'PI' AND NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :WHOST-CODSUBES AND COD_OPERACAO = :WHOST-CODOPER END-EXEC. */

            var r2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            var executed_1 = R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1.Execute(r2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MENS_JDE, V0MENS_JDE);
                _.Move(executed_1.V0MENS_JDL, V0MENS_JDL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-BUSCA-FONTE-SECTION */
        private void R2650_00_BUSCA_FONTE_SECTION()
        {
            /*" -2265- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -2265- MOVE ZEROS TO IDX-IND1. */
            _.Move(0, AREA_DE_WORK.IDX_IND1);

            /*" -0- FLUXCONTROL_PERFORM R2650_LOOP */

            R2650_LOOP();

        }

        [StopWatch]
        /*" R2650-LOOP */
        private void R2650_LOOP(bool isPerform = false)
        {
            /*" -2271- ADD 1 TO IDX-IND1. */
            AREA_DE_WORK.IDX_IND1.Value = AREA_DE_WORK.IDX_IND1 + 1;

            /*" -2272- IF IDX-IND1 > 19 */

            if (AREA_DE_WORK.IDX_IND1 > 19)
            {

                /*" -2274- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2275- IF TVA-FONTE(IDX-IND2) = TAB-FONTE (IDX-IND1) */

            if (TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.IDX_IND2].TVA_FONTE == TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_FONTE)
            {

                /*" -2277- MOVE TAB-NOMEFTE (IDX-IND1) TO LE06-REMETENTE */
                _.Move(TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE, AREA_DE_WORK.LE06_LINHA06.LE06_REMETENTE);

                /*" -2279- MOVE TAB-ENDERFTE(IDX-IND1) TO LE07-ENDERECO */
                _.Move(TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE, AREA_DE_WORK.LE07_LINHA07.LE07_ENDERECO);

                /*" -2281- MOVE TAB-BAIRRO (IDX-IND1) TO LE08-BAIRRO */
                _.Move(TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO, AREA_DE_WORK.LE08_LINHA08.LE08_BAIRRO);

                /*" -2283- MOVE TAB-CIDADE (IDX-IND1) TO LE08-CIDADE */
                _.Move(TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_CIDADE, AREA_DE_WORK.LE08_LINHA08.LE08_CIDADE);

                /*" -2285- MOVE TAB-UF (IDX-IND1) TO LE08-UF */
                _.Move(TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_UF, AREA_DE_WORK.LE08_LINHA08.LE08_UF);

                /*" -2287- MOVE TAB-CEP (IDX-IND1) TO DEST-NUM-CEP */
                _.Move(TAB_FILIAL.FILLER_149[AREA_DE_WORK.IDX_IND1].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

                /*" -2288- MOVE DEST-CEP TO LE09-CEP */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LE09_LINHA09.LE09_CEP);

                /*" -2289- MOVE DEST-CEP-COMPL TO LE09-CEP-COMPL */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LE09_LINHA09.LE09_CEP_COMPL);

                /*" -2291- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2291- GO TO R2650-LOOP. */
            new Task(() => R2650_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-FORMATA-NOME-RAZAO-SECTION */
        private void R2700_00_FORMATA_NOME_RAZAO_SECTION()
        {
            /*" -2303- IF SVA-IDE-SEXO EQUAL 'F' */

            if (REG_SVA2513B.SVA_IDE_SEXO == "F")
            {

                /*" -2304- MOVE 'PREZADA' TO WS-PREZADO */
                _.Move("PREZADA", AREA_DE_WORK.WS_CLIENTE.WS_PREZADO);

                /*" -2305- ELSE */
            }
            else
            {


                /*" -2306- IF SVA-IDE-SEXO EQUAL 'M' */

                if (REG_SVA2513B.SVA_IDE_SEXO == "M")
                {

                    /*" -2307- MOVE 'PREZADO' TO WS-PREZADO */
                    _.Move("PREZADO", AREA_DE_WORK.WS_CLIENTE.WS_PREZADO);

                    /*" -2308- ELSE */
                }
                else
                {


                    /*" -2310- MOVE 'PREZADO(A)' TO WS-PREZADO. */
                    _.Move("PREZADO(A)", AREA_DE_WORK.WS_CLIENTE.WS_PREZADO);
                }

            }


            /*" -2312- MOVE WS-PREZADOI TO LC11-NOME-TRATAI. */
            _.Move(AREA_DE_WORK.WS_CLIENTE.WS_PREZADO.WS_PREZADOI, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_TRATA.LC11_NOME_TRATAI);

            /*" -2315- MOVE FUNCTION LOWER-CASE(WS-PREZADOC) TO LC11-NOME-TRATAC. */
            _.Move(AREA_DE_WORK.WS_CLIENTE.WS_PREZADO.WS_PREZADOC.ToString().ToLower(), AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_TRATA.LC11_NOME_TRATAC);

            /*" -2318- MOVE SVA-NOME-RAZAO TO WS-NOME-RAZAO LC11-NOME-RAZAO-END */
            _.Move(REG_SVA2513B.SVA_NOME_RAZAO, AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

            /*" -2320- MOVE SPACES TO WS-PRI-NOME. */
            _.Move("", AREA_DE_WORK.WS_CLIENTE.WS_PRI_NOME);

            /*" -2320- MOVE ZEROS TO WIND1. */
            _.Move(0, AREA_DE_WORK.WIND1);

            /*" -0- FLUXCONTROL_PERFORM R2700_10_LOOP */

            R2700_10_LOOP();

        }

        [StopWatch]
        /*" R2700-10-LOOP */
        private void R2700_10_LOOP(bool isPerform = false)
        {
            /*" -2326- ADD 1 TO WIND1. */
            AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

            /*" -2327- IF WIND1 GREATER 40 */

            if (AREA_DE_WORK.WIND1 > 40)
            {

                /*" -2328- MOVE SPACES TO LC11-NOME-RAZAO */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_RAZAO);

                /*" -2330- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2331- IF WS-LETRA-NOME(WIND1) EQUAL SPACES */

            if (AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1] == string.Empty)
            {

                /*" -2332- MOVE WS-NOME-RAZAOI TO LC11-NOME-RAZAOI */
                _.Move(AREA_DE_WORK.WS_CLIENTE.WS_PRI_NOME.WS_NOME_RAZAOI, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_RAZAO.LC11_NOME_RAZAOI);

                /*" -2334- MOVE FUNCTION LOWER-CASE(WS-NOME-RAZAOC) TO LC11-NOME-RAZAOC */
                _.Move(AREA_DE_WORK.WS_CLIENTE.WS_PRI_NOME.WS_NOME_RAZAOC.ToString().ToLower(), AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_RAZAO.LC11_NOME_RAZAOC);

                /*" -2335- IF SVA-IDE-SEXO EQUAL 'F' OR 'M' */

                if (REG_SVA2513B.SVA_IDE_SEXO.In("F", "M"))
                {

                    /*" -2336- MOVE LC11-NOME-TRATA TO WS-PREZADO1 */
                    _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_TRATA, AREA_DE_WORK.WS_CLIENTE1.WS_PREZADO1);

                    /*" -2337- MOVE LC11-NOME-RAZAO TO WS-PRI-NOME1 */
                    _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_RAZAO, AREA_DE_WORK.WS_CLIENTE1.WS_PRI_NOME1);

                    /*" -2338- MOVE WS-CLIENTE1 TO LC11-CLIENTE */
                    _.Move(AREA_DE_WORK.WS_CLIENTE1, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);

                    /*" -2339- ELSE */
                }
                else
                {


                    /*" -2340- MOVE LC11-NOME-TRATA TO WS-PREZADO2 */
                    _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_TRATA, AREA_DE_WORK.WS_CLIENTE2.WS_PREZADO2);

                    /*" -2341- MOVE LC11-NOME-RAZAO TO WS-PRI-NOME2 */
                    _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE.LC11_NOME_RAZAO, AREA_DE_WORK.WS_CLIENTE2.WS_PRI_NOME2);

                    /*" -2342- MOVE WS-CLIENTE2 TO LC11-CLIENTE */
                    _.Move(AREA_DE_WORK.WS_CLIENTE2, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);

                    /*" -2343- END-IF */
                }


                /*" -2345- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2348- MOVE WS-LETRA-NOME(WIND1) TO WS-NOME-RAZAO-X(WIND1). */
            _.Move(AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1], AREA_DE_WORK.WS_CLIENTE.WS_PRI_NOME_R.WS_NOME_RAZAO_X[AREA_DE_WORK.WIND1]);

            /*" -2348- GO TO R2700-10-LOOP. */
            new Task(() => R2700_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-SELECT-V0CONDTEC-SECTION */
        private void R2750_00_SELECT_V0CONDTEC_SECTION()
        {
            /*" -2360- MOVE '275' TO WNR-EXEC-SQL. */
            _.Move("275", WABEND.WNR_EXEC_SQL);

            /*" -2362- MOVE 'S' TO WTEM-CONDTEC. */
            _.Move("S", AREA_DE_WORK.WTEM_CONDTEC);

            /*" -2368- PERFORM R2750_00_SELECT_V0CONDTEC_DB_SELECT_1 */

            R2750_00_SELECT_V0CONDTEC_DB_SELECT_1();

            /*" -2371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2372- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2373- MOVE 'N' TO WTEM-CONDTEC */
                    _.Move("N", AREA_DE_WORK.WTEM_CONDTEC);

                    /*" -2374- MOVE ZEROS TO WS-CAR-CONJUGE */
                    _.Move(0, AREA_DE_WORK.WS_CAR_CONJUGE);

                    /*" -2375- GO TO R2750-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/ //GOTO
                    return;

                    /*" -2376- ELSE */
                }
                else
                {


                    /*" -2377- DISPLAY 'VA2513B NAO ENCONTRADO NA V0CONDTEC ' */
                    _.Display($"VA2513B NAO ENCONTRADO NA V0CONDTEC ");

                    /*" -2378- DISPLAY 'APOLICE  ' WHOST-NRAPOLICE */
                    _.Display($"APOLICE  {WHOST_NRAPOLICE}");

                    /*" -2379- DISPLAY 'SUBGRUPO ' WHOST-CODSUBES */
                    _.Display($"SUBGRUPO {WHOST_CODSUBES}");

                    /*" -2381- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2383- MOVE V0COND-CAR-CONJUGE TO WS-CAR-CONJUGE. */
            _.Move(V0COND_CAR_CONJUGE, AREA_DE_WORK.WS_CAR_CONJUGE);

            /*" -2383- COMPUTE WS-CAR-CONJUGE = WS-CAR-CONJUGE / 100. */
            AREA_DE_WORK.WS_CAR_CONJUGE.Value = AREA_DE_WORK.WS_CAR_CONJUGE / 100f;

        }

        [StopWatch]
        /*" R2750-00-SELECT-V0CONDTEC-DB-SELECT-1 */
        public void R2750_00_SELECT_V0CONDTEC_DB_SELECT_1()
        {
            /*" -2368- EXEC SQL SELECT CARREGA_CONJUGE INTO :V0COND-CAR-CONJUGE FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 = new R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1.Execute(r2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COND_CAR_CONJUGE, V0COND_CAR_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-V0COBERPROPVA-SECTION */
        private void R2800_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -2396- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -2413- PERFORM R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -2416- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2417- DISPLAY 'VA2513B NAO ENCONTRADO NA V0COBERPROPVA' */
                _.Display($"VA2513B NAO ENCONTRADO NA V0COBERPROPVA");

                /*" -2418- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2420- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2421- MOVE V0COBE-IMPMORNATU TO LV09-IMPMORNATU. */
            _.Move(V0COBE_IMPMORNATU, AREA_DE_WORK.LV09_LINHA01.LV09_IMPMORNATU);

            /*" -2422- MOVE V0COBE-IMPMORACID TO LV09-IMPMORACID. */
            _.Move(V0COBE_IMPMORACID, AREA_DE_WORK.LV09_LINHA01.LV09_IMPMORACID);

            /*" -2423- MOVE V0COBE-IMPMORNATU TO LV09-IMPINVPERM. */
            _.Move(V0COBE_IMPMORNATU, AREA_DE_WORK.LV09_LINHA01.LV09_IMPINVPERM);

            /*" -2425- MOVE V0COBE-VLPREMIO TO LV09-VLPRMTOT. */
            _.Move(V0COBE_VLPREMIO, AREA_DE_WORK.LV09_LINHA01.LV09_VLPRMTOT);

            /*" -2434- MOVE V0COBE-IMPSEGCDG TO LV08-IMPCDG-1 LV08-IMPCDG-2. */
            _.Move(V0COBE_IMPSEGCDG, AREA_DE_WORK.LV08_LINHA01.LV08_IMPCDG_1, AREA_DE_WORK.LV08_LINHA02.LV08_IMPCDG_2);

            /*" -2436- IF WTEM-CONDTEC EQUAL 'N' OR WS-CAR-CONJUGE EQUAL ZEROES */

            if (AREA_DE_WORK.WTEM_CONDTEC == "N" || AREA_DE_WORK.WS_CAR_CONJUGE == 00)
            {

                /*" -2438- MOVE '*************' TO LV09-IMPMORESPO-X */
                _.Move("*************", AREA_DE_WORK.LV09_LINHA01.LV09_IMPMORESPO_X);

                /*" -2439- GO TO R2800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/ //GOTO
                return;

                /*" -2440- ELSE */
            }
            else
            {


                /*" -2442- COMPUTE V0COBE-IMPCONJUGE = V0COBE-IMPMORNATU * WS-CAR-CONJUGE */
                V0COBE_IMPCONJUGE.Value = V0COBE_IMPMORNATU * AREA_DE_WORK.WS_CAR_CONJUGE;

                /*" -2445- MOVE V0COBE-IMPCONJUGE TO LV09-IMPMORESPO. */
                _.Move(V0COBE_IMPCONJUGE, AREA_DE_WORK.LV09_LINHA01.LV09_IMPMORESPO);
            }


            /*" -2447- IF (V0PROD-ORIG-PRODU EQUAL 'MULT' ) AND (WS-IDSEXO EQUAL 'F' ) */

            if ((V0PROD_ORIG_PRODU == "MULT") && (AREA_DE_WORK.WS_IDSEXO == "F"))
            {

                /*" -2447- MOVE '*************' TO LV09-IMPMORESPO-X. */
                _.Move("*************", AREA_DE_WORK.LV09_LINHA01.LV09_IMPMORESPO_X);
            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -2413- EXEC SQL SELECT IMPMORNATU, IMPMORACID, VLPREMIO, DTINIVIG, IMPSEGCDC INTO :V0COBE-IMPMORNATU, :V0COBE-IMPMORACID, :V0COBE-VLPREMIO, :V0COBE-DTINIVIG, :V0COBE-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBE_IMPMORNATU, V0COBE_IMPMORNATU);
                _.Move(executed_1.V0COBE_IMPMORACID, V0COBE_IMPMORACID);
                _.Move(executed_1.V0COBE_VLPREMIO, V0COBE_VLPREMIO);
                _.Move(executed_1.V0COBE_DTINIVIG, V0COBE_DTINIVIG);
                _.Move(executed_1.V0COBE_IMPSEGCDG, V0COBE_IMPSEGCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2850-00-UPDATE-V0HISTCOBVA-SECTION */
        private void R2850_00_UPDATE_V0HISTCOBVA_SECTION()
        {
            /*" -2461- MOVE '285' TO WNR-EXEC-SQL. */
            _.Move("285", WABEND.WNR_EXEC_SQL);

            /*" -2467- PERFORM R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -2470- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2471- DISPLAY 'VA2513B NAO ENCONTRADO NA V0HISTCOBVA' */
                _.Display($"VA2513B NAO ENCONTRADO NA V0HISTCOBVA");

                /*" -2472- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2473- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -2474- DISPLAY 'TITULO      => ' WHOST-NRTIT */
                _.Display($"TITULO      => {WHOST_NRTIT}");

                /*" -2474- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2850-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -2467- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '0' WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL AND NRTIT = :WHOST-NRTIT END-EXEC. */

            var r2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 = new R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
            };

            R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1.Execute(r2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TRATA-V0RELATORIOS-SECTION */
        private void R2900_00_TRATA_V0RELATORIOS_SECTION()
        {
            /*" -2487- PERFORM R2910-00-OBTEM-NUMERACAO. */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -2489- MOVE V0RELA-NRCOPIAS TO LR07-SEQ. */
            _.Move(V0RELA_NRCOPIAS, AREA_DE_WORK.LR07_LINHA07.LR07_SEQ);

            /*" -2490- MOVE V1SIST-DTMOVABE TO WS-DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2491- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -2492- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -2494- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -2496- MOVE TAB-MES(WS-MES-SQL) TO LR07-MES. */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR07_LINHA07.LR07_MES);

            /*" -2497- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, AREA_DE_WORK.WS_COUNT);

            /*" -2499- MOVE WHOST-DTMOVABE TO WHOST-PROXIMA-DATA. */
            _.Move(WHOST_DTMOVABE, AREA_DE_WORK.WHOST_PROXIMA_DATA);

            /*" -2502- PERFORM R2920-00-CALC-DIAS-UTEIS UNTIL WS-COUNT EQUAL 2. */

            while (!(AREA_DE_WORK.WS_COUNT == 2))
            {

                R2920_00_CALC_DIAS_UTEIS_SECTION();
            }

            /*" -2503- MOVE CALENDAR-DATA-CALENDARIO TO WS-DATA-SQL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2504- MOVE WS-ANO-SQL TO WS-ANO-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_ANO_I);

            /*" -2505- MOVE WS-MES-SQL TO WS-MES-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -2506- MOVE WS-DIA-SQL TO WS-DIA-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -2509- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -2510- MOVE WS-DATA-I TO LR09-DATA LC11-DTPOSTAGEM. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LR09_LINHA09.LR09_DATA, AREA_DE_WORK.LC11_LINHA11.LC11_DTPOSTAGEM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -2523- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -2530- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -2533- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2534- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2535- MOVE ZEROS TO V0RELA-NRCOPIAS */
                    _.Move(0, V0RELA_NRCOPIAS);

                    /*" -2536- ELSE */
                }
                else
                {


                    /*" -2537- DISPLAY 'VA2513B - PROBLEMAS SELECT V0RELATORIOS' */
                    _.Display($"VA2513B - PROBLEMAS SELECT V0RELATORIOS");

                    /*" -2539- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2540- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -2540- MOVE ZEROS TO V0RELA-NRCOPIAS. */
                _.Move(0, V0RELA_NRCOPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -2530- EXEC SQL SELECT MAX(NRCOPIAS) INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

            var r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRCOPIAS, V0RELA_NRCOPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO */
        private void R2910_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -2547- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -2549- ADD 1 TO V0RELA-NRCOPIAS. */
            V0RELA_NRCOPIAS.Value = V0RELA_NRCOPIAS + 1;

            /*" -2592- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -2595- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -2596- DISPLAY 'R0300-10 (REGISTRO DUPLICADO) ... ' */
                _.Display($"R0300-10 (REGISTRO DUPLICADO) ... ");

                /*" -2598- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2600- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -2602- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2602- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -2592- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'EM0600B' , :V1SIST-DTMOVABE, 'EM' , 'CARTAECT' , :V0RELA-NRCOPIAS, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1.Execute(r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-00-CALC-DIAS-UTEIS-SECTION */
        private void R2920_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -2615- PERFORM R2930-00-CALCULA-DIA-UTIL. */

            R2930_00_CALCULA_DIA_UTIL_SECTION();

            /*" -2619- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -2620- ELSE */
            }
            else
            {


                /*" -2620- ADD 1 TO WS-COUNT. */
                AREA_DE_WORK.WS_COUNT.Value = AREA_DE_WORK.WS_COUNT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R2930-00-CALCULA-DIA-UTIL-SECTION */
        private void R2930_00_CALCULA_DIA_UTIL_SECTION()
        {
            /*" -2632- MOVE '293' TO WNR-EXEC-SQL. */
            _.Move("293", WABEND.WNR_EXEC_SQL);

            /*" -2646- PERFORM R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -2649- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2650- DISPLAY 'VA2513B - PROBLEMAS NO ACESSO A TABELA CALENDARIO' */
                _.Display($"VA2513B - PROBLEMAS NO ACESSO A TABELA CALENDARIO");

                /*" -2650- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2930-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -2646- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-PROXIMA-DATA END-EXEC. */

            var r2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = AREA_DE_WORK.WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(r2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, AREA_DE_WORK.WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2930_99_SAIDA*/

        [StopWatch]
        /*" R2950-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R2950_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -2662- MOVE '295' TO WNR-EXEC-SQL. */
            _.Move("295", WABEND.WNR_EXEC_SQL);

            /*" -2674- PERFORM R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -2677- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2678- DISPLAY 'VA2513B - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                _.Display($"VA2513B - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                /*" -2679- DISPLAY '          APOLICE........  ' WHOST-NRAPOLICE */
                _.Display($"          APOLICE........  {WHOST_NRAPOLICE}");

                /*" -2680- DISPLAY '          SUBGRUPO.......  ' WHOST-CODSUBES */
                _.Display($"          SUBGRUPO.......  {WHOST_CODSUBES}");

                /*" -2681- DISPLAY '          SQLCODE........  ' SQLCODE */
                _.Display($"          SQLCODE........  {DB.SQLCODE}");

                /*" -2683- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2684- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -2684- MOVE SPACES TO V0PROD-ORIG-PRODU. */
                _.Move("", V0PROD_ORIG_PRODU);
            }


        }

        [StopWatch]
        /*" R2950-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -2674- EXEC SQL SELECT CODPRODU, NOMPRODU, CODCDT, ORIG_PRODU INTO :V0PROD-CODPRODU, :V0PROD-NOMPRODU, :V0PROD-CODCDT, :V0PROD-ORIG-PRODU:VIND-ORIG-PRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :WHOST-CODSUBES END-EXEC. */

            var r2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 = new R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1.Execute(r2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_CODPRODU, V0PROD_CODPRODU);
                _.Move(executed_1.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
                _.Move(executed_1.V0PROD_CODCDT, V0PROD_CODCDT);
                _.Move(executed_1.V0PROD_ORIG_PRODU, V0PROD_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2950_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -2697- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -2697- WRITE FVA2513B-RECORD FROM LR02-LINHA02. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -2702- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2703- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -2705- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -2706- IF TAB1-QTD-OBJ (WIND) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ != 00)
            {

                /*" -2708- ADD 1 TO WS-OCORR. */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;
            }


            /*" -2709- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -2709- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -2714- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -2715- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -2717- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -2717- MOVE WWORK-QTDE11 TO LR10-PAGINA-T. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR10_LINHA10.LR10_PAGINA_T);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -2742- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2743- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -2745- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2746- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -2747- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2749- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2751- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -2753- MOVE AC-PAGINA TO LR10-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR10_LINHA10.LR10_PAGINA);

            /*" -2755- PERFORM R3010-00-CABECALHOS. */

            R3010_00_CABECALHOS_SECTION();

            /*" -2756- WRITE FVA2513B-RECORD FROM LR10-LINHA10. */
            _.Move(AREA_DE_WORK.LR10_LINHA10.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2758- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -2759- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2760- MOVE WS-CEP-AUX TO LR12-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_CEPI);

            /*" -2761- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_COMPL_CEPI);

            /*" -2762- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2763- MOVE WS-CEP-AUX TO LR12-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_CEPF);

            /*" -2764- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_COMPL_CEPF);

            /*" -2765- MOVE TAB1-OBJI (WIND) TO LR12-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR12_LINHA12.LR12_OBJI);

            /*" -2766- MOVE TAB1-OBJF (WIND) TO LR12-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR12_LINHA12.LR12_OBJF);

            /*" -2767- MOVE TAB1-AMARI (WIND) TO LR12-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR12_LINHA12.LR12_AMARI);

            /*" -2768- MOVE TAB1-AMARF (WIND) TO LR12-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR12_LINHA12.LR12_AMARF);

            /*" -2769- MOVE TAB1-QTD-OBJ (WIND) TO LR12-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR12_QTD_OBJ);

            /*" -2770- MOVE TAB1-QTD-AMAR(WIND) TO LR12-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR12_QTD_AMAR);

            /*" -2771- MOVE SPACES TO LR12-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR12_OBS);

            /*" -2771- WRITE FVA2513B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -2777- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -2778- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2779- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -2781- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2782- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -2784- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2785- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2786- MOVE WS-CEP-AUX TO LR12-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_CEPI);

            /*" -2787- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_COMPL_CEPI);

            /*" -2788- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2789- MOVE WS-CEP-AUX TO LR12-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_CEPF);

            /*" -2790- MOVE WS-CEP-COMPL-AUX TO LR12-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR12_COMPL_CEPF);

            /*" -2791- MOVE TAB1-OBJI (WIND) TO LR12-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR12_LINHA12.LR12_OBJI);

            /*" -2792- MOVE TAB1-OBJF (WIND) TO LR12-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR12_LINHA12.LR12_OBJF);

            /*" -2793- MOVE TAB1-AMARI (WIND) TO LR12-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR12_LINHA12.LR12_AMARI);

            /*" -2794- MOVE TAB1-AMARF (WIND) TO LR12-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR12_LINHA12.LR12_AMARF);

            /*" -2795- MOVE TAB1-QTD-OBJ (WIND) TO LR12-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR12_QTD_OBJ);

            /*" -2796- MOVE TAB1-QTD-AMAR(WIND) TO LR12-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR12_QTD_AMAR);

            /*" -2797- MOVE SPACES TO LR12-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR12_OBS);

            /*" -2798- WRITE FVA2513B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2800- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -2801- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -2802- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2803- WRITE FVA2513B-RECORD FROM LC88-LINHA88 */
                _.Move(AREA_DE_WORK.LC88_LINHA88.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2804- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -2805- ELSE */
            }
            else
            {


                /*" -2805- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-CABECALHOS-SECTION */
        private void R3010_00_CABECALHOS_SECTION()
        {
            /*" -2817- WRITE FVA2513B-RECORD FROM LR03-LINHA03 */
            _.Move(AREA_DE_WORK.LR03_LINHA03.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2818- WRITE FVA2513B-RECORD FROM LR04-LINHA04 */
            _.Move(AREA_DE_WORK.LR04_LINHA04.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2819- WRITE FVA2513B-RECORD FROM LR05-LINHA05 */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2820- WRITE FVA2513B-RECORD FROM LR06-LINHA06 */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2821- WRITE FVA2513B-RECORD FROM LR07-LINHA07 */
            _.Move(AREA_DE_WORK.LR07_LINHA07.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2822- WRITE FVA2513B-RECORD FROM LR08-LINHA08 */
            _.Move(AREA_DE_WORK.LR08_LINHA08.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2823- WRITE FVA2513B-RECORD FROM LR09-LINHA09 */
            _.Move(AREA_DE_WORK.LR09_LINHA09.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2823- WRITE FVA2513B-RECORD FROM LR10-LINHA10-A. */
            _.Move(AREA_DE_WORK.LR10_LINHA10_A.GetMoveValues(), FVA2513B_RECORD);

            FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SEPARA-PRODUTO-SECTION */
        private void R3100_00_SEPARA_PRODUTO_SECTION()
        {
            /*" -2842- MOVE 999999 TO LF04-FAIXA1 LF04-FAIXA2 LF04-FAIXA1C LF04-FAIXA2C LF04-AMARRADO LF04-QTD-OBJ LF04-SEQ-INICIAL LF04-SEQ-FINAL. */
            _.Move(999999, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA1, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA2, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA1C, AREA_DE_WORK.LF04_LINHA04.LF04_FAIXA2C, AREA_DE_WORK.LF04_LINHA04.LF04_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF04_SEQ_FINAL);

            /*" -2844- MOVE LR11-TP-PGTO TO LF04-NOME-FAIXA. */
            _.Move(AREA_DE_WORK.LR11_LINHA11.LR11_TP_PGTO, AREA_DE_WORK.LF04_LINHA04.LF04_NOME_FAIXA);

            /*" -2845- IF WS-CONTR-PRODU EQUAL 'C' */

            if (AREA_DE_WORK.WS_CONTR_PRODU == "C")
            {

                /*" -2846- PERFORM R3200-00-FAC-PRODUTO 3 TIMES */

                for (int i = 0; i < 3; i++)
                {

                    R3200_00_FAC_PRODUTO_SECTION();

                }

                /*" -2847- ELSE */
            }
            else
            {


                /*" -2849- PERFORM R3200-00-FAC-PRODUTO. */

                R3200_00_FAC_PRODUTO_SECTION();
            }


            /*" -2850- WRITE RVA2513B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

            /*" -2850- WRITE RVA2513B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA2513B_RECORD);

            RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-FAC-PRODUTO-SECTION */
        private void R3200_00_FAC_PRODUTO_SECTION()
        {
            /*" -2862- IF WS-CONTR-PRODU EQUAL 'C' */

            if (AREA_DE_WORK.WS_CONTR_PRODU == "C")
            {

                /*" -2863- WRITE RVA2513B-RECORD FROM LF04-LINHA04 */
                _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVA2513B_RECORD);

                RVA2513B.Write(RVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2864- ELSE */
            }
            else
            {


                /*" -2865- WRITE FVA2513B-RECORD FROM LF01-LINHA01 */
                _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2866- WRITE FVA2513B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2867- WRITE FVA2513B-RECORD FROM LF02-LINHA02 */
                _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2868- WRITE FVA2513B-RECORD FROM LF03-LINHA03 */
                _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());

                /*" -2868- WRITE FVA2513B-RECORD FROM LF04-LINHA04. */
                _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), FVA2513B_RECORD);

                FVA2513B.Write(FVA2513B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -2880- OPEN OUTPUT RVA2513B. */
            RVA2513B.Open(RVA2513B_RECORD);

            /*" -2880- OPEN OUTPUT FVA2513B. */
            FVA2513B.Open(FVA2513B_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -2892- CLOSE RVA2513B. */
            RVA2513B.Close();

            /*" -2892- CLOSE FVA2513B. */
            FVA2513B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -2906- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2907- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2908- DISPLAY '*   VA2513B - IMPRIME CORRESPONDENCIA      *' */
            _.Display($"*   VA2513B - IMPRIME CORRESPONDENCIA      *");

            /*" -2909- DISPLAY '*   -------   -----------------------      *' */
            _.Display($"*   -------   -----------------------      *");

            /*" -2910- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2911- DISPLAY '*             NAO EXISTE CORRESPONDENCIA   *' */
            _.Display($"*             NAO EXISTE CORRESPONDENCIA   *");

            /*" -2912- DISPLAY '*             PARA ESTA DATA               *' */
            _.Display($"*             PARA ESTA DATA               *");

            /*" -2913- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2913- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2927- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2929- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -2929- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2931- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2935- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2935- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}