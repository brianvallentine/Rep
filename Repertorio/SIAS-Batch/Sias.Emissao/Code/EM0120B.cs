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
using Sias.Emissao.DB2.EM0120B;

namespace Code
{
    public class EM0120B
    {
        public bool IsCall { get; set; }

        public EM0120B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM0120B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1991                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CANCELAMENTO AUTOMATICO            *      */
        /*"      *                             . PREMIO                           *      */
        /*"      *                             . CORRECAO MONETARIA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PARCELAS                            V1PARCELA         INPUT    *      */
        /*"      * NUMERACAO APOLICE/ENDOSSOS          V1NUMERO_AES      I-O      *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *  31/07/2017 - OLIVEIRA                - AJUSTE CADMUS 152932   *      */
        /*"      *     PROJETO SIGCB - CANCELAMENTO DO AUTO FACIL - AJUSTE        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *  16/06/2017 - LISIANE BRAGANCA SOARES - AJUSTE CADMUS 144133   *      */
        /*"      *     PROJETO SIGCB - CANCELAMENTO DO AUTO FACIL                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *  21/12/2016 - LISIANE BRAGANCA SOARES - CADMUS 144143          *      */
        /*"V.02D1*  23/05/2017                                                           */
        /*"      *     PROJETO SIGCB - CANCELAMENTO DO AUTO FACIL                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  *  18/05/2016 - LISIANE BRAGANCA SOARES - CADMUS 136030          *      */
        /*"      *     CANCELAMENTO AUTOMATICO DO LOTERICO/CCA POR INADIMPLENCIA  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 05/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO EM 10/06/2008  - WELLINGTON VERAS TE39902 (POLITEC)*      */
        /*"      *     PROJETO FGV                                                *      */
        /*"      *             INIBIR COMANDO DISPLAY       WV0608                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-QT-REG                      PIC S9(02) VALUE +0 COMP.*/
        public IntBasis WS_QT_REG { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)"));
        /*"77 WS-DT-VENCIM                   PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_VENCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DT-VENCIM-20DIAS            PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_VENCIM_20DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77           WHOST-DTINIVIG    PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WHOST-DTTERVIG    PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WHOST-DTCANCEL    PIC  X(010).*/
        public StringBasis WHOST_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W1HISP-DTVENCTO   PIC  X(010).*/
        public StringBasis W1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WOCORHIST         PIC S9(004)                 COMP.*/
        public IntBasis WOCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           W0NAES-NRENDOCA   PIC S9(009)      VALUE +0   COMP.*/
        public IntBasis W0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           WP-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPREMIO       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPREMIO       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         VIND-DATA-SORT      PIC S9(004)                COMP.*/
        public IntBasis VIND_DATA_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DATARCAP       PIC S9(004)                COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)                COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ISENTA-CST     PIC S9(004)                COMP.*/
        public IntBasis VIND_ISENTA_CST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-PRODU      PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1EDIA-NUM-APOL     PIC S9(013)  COMP-3.*/
        public IntBasis V1EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1EDIA-NRENDOS      PIC S9(009)  COMP.*/
        public IntBasis V1EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-CODCLIEN    PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-NUM-ITEM    PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-CODSUBES    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODPRODU    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MODALIDA    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-ORGAO       PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NUM-APOLANT PIC S9(013)                 COMP-3*/
        public IntBasis V1ENDO_NUM_APOLANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-FONTE       PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NRPROPOS    PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-DATPRO      PIC  X(010).*/
        public StringBasis V1ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DATA-LIB    PIC  X(010).*/
        public StringBasis V1ENDO_DATA_LIB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-NUMBIL      PIC S9(015)                 COMP-3*/
        public IntBasis V1ENDO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1ENDO-TIPSEGU     PIC  X(001).*/
        public StringBasis V1ENDO_TIPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TIPAPO      PIC  X(001).*/
        public StringBasis V1ENDO_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TIPCALC     PIC  X(001).*/
        public StringBasis V1ENDO_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-PODPUBL     PIC  X(001).*/
        public StringBasis V1ENDO_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-NUM-ATA     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-ANO-ATA     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-IDEMAN      PIC  X(001).*/
        public StringBasis V1ENDO_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-NRRCAP      PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-VLRCAP      PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-BCORCAP     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-AGERCAP     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DACRCAP     PIC  X(001).*/
        public StringBasis V1ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-IDRCAP      PIC  X(001).*/
        public StringBasis V1ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-BCOCOBR     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-AGECOBR     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-DACCOBR     PIC  X(001).*/
        public StringBasis V1ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-CDFRACIO    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-PCENTRAD    PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-PCADICIO    PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-PCDESCON    PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-PCIOCC      PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-PRESTA1     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-QTPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-QTPRESTA    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-QTITENS     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODTXT      PIC  X(003).*/
        public StringBasis V1ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1ENDO-CDACEITA    PIC  X(001).*/
        public StringBasis V1ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-MOEDA-IMP   PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-PRM   PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-TIPO-END    PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_END { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TPCOSCED    PIC  X(001).*/
        public StringBasis V1ENDO_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-QTCOSSEG    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-PCTCED      PIC S9(004)V9(5)            COMP-3*/
        public DoubleBasis V1ENDO_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1ENDO-OCORR-END   PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-COD-USUAR   PIC  X(008).*/
        public StringBasis V1ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-DATA-SORT   PIC  X(010).*/
        public StringBasis V1ENDO_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DATARCAP    PIC  X(010).*/
        public StringBasis V1ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-COD-EMP     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-ISENTA-CST  PIC  X(001).*/
        public StringBasis V1ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-NRPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-DACPARC     PIC  X(001).*/
        public StringBasis V1PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-FONTE       PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-NRTIT       PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-OCORHIST    PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-QTDDOC      PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-COD-EMP     PIC S9(009)                 COMP.*/
        public IntBasis V1PARC_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NRPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-SIT-COBRAN  PIC  X(001).*/
        public StringBasis V0PARC_SIT_COBRAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HISP-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DACPARC      PIC  X(001).*/
        public StringBasis V1HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V1HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HISP-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-BCOCOBR      PIC S9(004)                COMP.*/
        public IntBasis V1HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-AGECOBR      PIC S9(004)                COMP.*/
        public IntBasis V1HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-NRAVISO      PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V1HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-COD-USUARIO  PIC  X(008).*/
        public StringBasis V1HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HISP-RNUDOC       PIC S9(009)                COMP.*/
        public IntBasis V1HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-BCOCOBR      PIC S9(004)                COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-AGECOBR      PIC S9(004)                COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-NRAVISO      PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-RNUDOC       PIC S9(009)                COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 AREA-DE-WORK.*/
        public EM0120B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0120B_AREA_DE_WORK();
        public class EM0120B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"   05 WRESTO            PIC S9(003)    VALUE +0   COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"   05 WHORA             PIC  99.99.99.*/
            public IntBasis WHORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"  05         AC-PARCELAS       PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PARCELAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-L-V1EMISDIA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1EMISDIA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1PARCELA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-P-V1PARCELA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_P_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0HISTOPARC  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-P-V0HISTOPARC  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_P_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1HISTOPARC  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1EMISDIARIA PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1EMISDIARIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1HISTOPARC  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1FOLLOWUP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_V1FOLLOWUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-JANELA       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_JANELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WHOUVE-CANCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WHOUVE_CANCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_EM0120B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM0120B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM0120B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM0120B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_EM0120B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public EM0120B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new EM0120B_WDAT_REL_LIT();
            public class EM0120B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WUNIM-DATA        PIC  X(010)    VALUE ZEROS.*/
            }
            public StringBasis WUNIM_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WEMIS-DATA        PIC  X(010)    VALUE ZEROS.*/
            public StringBasis WEMIS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WEMIS-DATA.*/
            private _REDEF_EM0120B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_EM0120B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_EM0120B_FILLER_5(); _.Move(WEMIS_DATA, _filler_5); VarBasis.RedefinePassValue(WEMIS_DATA, _filler_5, WEMIS_DATA); _filler_5.ValueChanged += () => { _.Move(_filler_5, WEMIS_DATA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WEMIS_DATA); }
            }  //Redefines
            public class _REDEF_EM0120B_FILLER_5 : VarBasis
            {
                /*"    10       WEMIS-ANOMES.*/
                public EM0120B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new EM0120B_WEMIS_ANOMES();
                public class EM0120B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15     WEMI-ANO          PIC  9(004).*/
                    public IntBasis WEMI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WEMI-MES          PIC  9(002).*/
                    public IntBasis WEMI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public EM0120B_WEMIS_ANOMES()
                    {
                        WEMI_ANO.ValueChanged += OnValueChanged;
                        FILLER_6.ValueChanged += OnValueChanged;
                        WEMI_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WEMI-DIA          PIC  9(002).*/
                public IntBasis WEMI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSIST-DATA        PIC  X(010)    VALUE ZEROS.*/

                public _REDEF_EM0120B_FILLER_5()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WEMI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA.*/
            private _REDEF_EM0120B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_EM0120B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_EM0120B_FILLER_8(); _.Move(WSIST_DATA, _filler_8); VarBasis.RedefinePassValue(WSIST_DATA, _filler_8, WSIST_DATA); _filler_8.ValueChanged += () => { _.Move(_filler_8, WSIST_DATA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_EM0120B_FILLER_8 : VarBasis
            {
                /*"    10       WSIST-ANOMES.*/
                public EM0120B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new EM0120B_WSIST_ANOMES();
                public class EM0120B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO          PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WSIS-MES          PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public EM0120B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DIA          PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CH-CHAVE-ATU.*/

                public _REDEF_EM0120B_FILLER_8()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public EM0120B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new EM0120B_CH_CHAVE_ATU();
            public class EM0120B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-APOLI-ATU      PIC  9(013)    VALUE ZEROS.*/
                public IntBasis CH_APOLI_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       CH-ENDOS-ATU      PIC  9(006)    VALUE ZEROS.*/
                public IntBasis CH_ENDOS_ATU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05         CH-CHAVE-ANT.*/
            }
            public EM0120B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new EM0120B_CH_CHAVE_ANT();
            public class EM0120B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10       CH-APOLI-ANT      PIC  9(013)    VALUE ZEROS.*/
                public IntBasis CH_APOLI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       CH-ENDOS-ANT      PIC  9(006)    VALUE ZEROS.*/
                public IntBasis CH_ENDOS_ANT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05  W-DATA.*/
            }
            public EM0120B_W_DATA W_DATA { get; set; } = new EM0120B_W_DATA();
            public class EM0120B_W_DATA : VarBasis
            {
                /*"    07  W-DD                    PIC  9(02).*/
                public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  W-MM                    PIC  9(02).*/
                public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  W-AA                    PIC  9(04).*/
                public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05  PROSOMW099.*/
            }
            public EM0120B_PROSOMW099 PROSOMW099 { get; set; } = new EM0120B_PROSOMW099();
            public class EM0120B_PROSOMW099 : VarBasis
            {
                /*"    07  W-DATA01                PIC  9(08).*/
                public IntBasis W_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"    07  W-QTDIA                 PIC S9(05)  COMP-3.*/
                public IntBasis W_QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
                /*"    07  W-DATA02                PIC  9(08).*/
                public IntBasis W_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"  05  W-DATA-EDITADA.*/
            }
            public EM0120B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new EM0120B_W_DATA_EDITADA();
            public class EM0120B_W_DATA_EDITADA : VarBasis
            {
                /*"    07  W-ANO                   PIC  9(04).*/
                public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    07  FILLER                  PIC  X(01).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    07  W-MES                   PIC  9(02).*/
                public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  FILLER                  PIC  X(01).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    07  W-DIA                   PIC  9(02).*/
                public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05         WTIME-DAY         PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_EM0120B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_EM0120B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_EM0120B_FILLER_13(); _.Move(WTIME_DAY, _filler_13); VarBasis.RedefinePassValue(WTIME_DAY, _filler_13, WTIME_DAY); _filler_13.ValueChanged += () => { _.Move(_filler_13, WTIME_DAY); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_EM0120B_FILLER_13 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public EM0120B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM0120B_WTIME_DAYR();
                public class EM0120B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public EM0120B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSG        PIC  X(002).*/
                public StringBasis WTIME_CCSG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"01 WS-VARIAVEIS-GLOBAIS.*/

                public _REDEF_EM0120B_FILLER_13()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM0120B_WS_VARIAVEIS_GLOBAIS WS_VARIAVEIS_GLOBAIS { get; set; } = new EM0120B_WS_VARIAVEIS_GLOBAIS();
        public class EM0120B_WS_VARIAVEIS_GLOBAIS : VarBasis
        {
            /*"   05 WS-CURRENT-DATE.*/
            public EM0120B_WS_CURRENT_DATE WS_CURRENT_DATE { get; set; } = new EM0120B_WS_CURRENT_DATE();
            public class EM0120B_WS_CURRENT_DATE : VarBasis
            {
                /*"      10 WS-DATE                  PIC X(16) VALUE SPACES.*/
                public StringBasis WS_DATE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"      10 FILLER REDEFINES WS-DATE.*/
                private _REDEF_EM0120B_FILLER_14 _filler_14 { get; set; }
                public _REDEF_EM0120B_FILLER_14 FILLER_14
                {
                    get { _filler_14 = new _REDEF_EM0120B_FILLER_14(); _.Move(WS_DATE, _filler_14); VarBasis.RedefinePassValue(WS_DATE, _filler_14, WS_DATE); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_DATE); }; return _filler_14; }
                    set { VarBasis.RedefinePassValue(value, _filler_14, WS_DATE); }
                }  //Redefines
                public class _REDEF_EM0120B_FILLER_14 : VarBasis
                {
                    /*"         15 WS-DT-TODAY           PIC 9(08).*/
                    public IntBasis WS_DT_TODAY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"         15 WS-HR-TODAY           PIC 9(06).*/
                    public IntBasis WS_HR_TODAY { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"         15 WS-FILLER             PIC X(02).*/
                    public StringBasis WS_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"01 WABEND.*/

                    public _REDEF_EM0120B_FILLER_14()
                    {
                        WS_DT_TODAY.ValueChanged += OnValueChanged;
                        WS_HR_TODAY.ValueChanged += OnValueChanged;
                        WS_FILLER.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public EM0120B_WABEND WABEND { get; set; } = new EM0120B_WABEND();
        public class EM0120B_WABEND : VarBasis
        {
            /*"   05 FILLER                      PIC X(09) VALUE      'EM0120B '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"EM0120B ");
            /*"   05 FILLER                      PIC X(35) VALUE      ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"   05 WNR-EXEC-SQL                PIC X(05) VALUE '00000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"00000");
            /*"   05 FILLER                      PIC X(13) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
            /*"   05 WSQLCODE                    PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public EM0120B_V1EMISDIA V1EMISDIA { get; set; } = new EM0120B_V1EMISDIA();
        public EM0120B_V1PARCELA V1PARCELA { get; set; } = new EM0120B_V1PARCELA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -379- MOVE 'R0000' TO WNR-EXEC-SQL. */
                _.Move("R0000", WABEND.WNR_EXEC_SQL);

                /*" -379- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -381- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -383- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -383- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -391- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -392- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -393- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -395- END-IF */
            }


            /*" -397- PERFORM R0200-00-DECLARE-V1EMISDIARIA */

            R0200_00_DECLARE_V1EMISDIARIA_SECTION();

            /*" -399- PERFORM R0210-00-FETCH-V1EMISDIARIA */

            R0210_00_FETCH_V1EMISDIARIA_SECTION();

            /*" -400- IF WFIM-V1EMISDIARIA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1EMISDIARIA.IsEmpty())
            {

                /*" -401- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -402- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -404- END-IF */
            }


            /*" -407- PERFORM R0050-00-PROCESSA UNTIL WFIM-V1EMISDIARIA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1EMISDIARIA.IsEmpty()))
            {

                R0050_00_PROCESSA_SECTION();
            }

            /*" -408- DISPLAY 'APOLICES LIDAS ......... ' AC-L-V1EMISDIA */
            _.Display($"APOLICES LIDAS ......... {AREA_DE_WORK.AC_L_V1EMISDIA}");

            /*" -409- DISPLAY 'PARCELAS LIDAS ......... ' AC-L-V1PARCELA */
            _.Display($"PARCELAS LIDAS ......... {AREA_DE_WORK.AC_L_V1PARCELA}");

            /*" -410- DISPLAY 'PARCELAS PROCESSADAS ... ' AC-P-V1PARCELA */
            _.Display($"PARCELAS PROCESSADAS ... {AREA_DE_WORK.AC_P_V1PARCELA}");

            /*" -411- DISPLAY 'HISTORICOS INSERIDOS     ' */
            _.Display($"HISTORICOS INSERIDOS     ");

            /*" -412- DISPLAY '. PREMIOS .............. ' AC-P-V0HISTOPARC */
            _.Display($". PREMIOS .............. {AREA_DE_WORK.AC_P_V0HISTOPARC}");

            /*" -412- DISPLAY '. CORRECAO ............. ' AC-C-V0HISTOPARC. */
            _.Display($". CORRECAO ............. {AREA_DE_WORK.AC_C_V0HISTOPARC}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -418- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -418- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -423- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -426- DISPLAY 'DATA TERMINO: ' WS-DT-TODAY ' - HORA TERMINO: ' WS-HR-TODAY */

            $"DATA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_14.WS_DT_TODAY} - HORA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_14.WS_HR_TODAY}"
            .Display();

            /*" -426- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCESSA-SECTION */
        private void R0050_00_PROCESSA_SECTION()
        {
            /*" -437- MOVE 'R0050' TO WNR-EXEC-SQL. */
            _.Move("R0050", WABEND.WNR_EXEC_SQL);

            /*" -440- DISPLAY 'CURSOR: ' V1EDIA-NUM-APOL ' END ' V1EDIA-NRENDOS */

            $"CURSOR: {V1EDIA_NUM_APOL} END {V1EDIA_NRENDOS}"
            .Display();

            /*" -442- INITIALIZE DCLAPOLICE-COBRANCA */
            _.Initialize(
                APOLCOBR.DCLAPOLICE_COBRANCA
            );

            /*" -449- PERFORM R0050_00_PROCESSA_DB_SELECT_1 */

            R0050_00_PROCESSA_DB_SELECT_1();

            /*" -452- IF SQLCODE NOT = ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -453- DISPLAY 'R0500 - ERRO NO SELECT DA APOLICE_COBRANCA' */
                _.Display($"R0500 - ERRO NO SELECT DA APOLICE_COBRANCA");

                /*" -454- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL */
                _.Display($"APOLICE - {V1EDIA_NUM_APOL}");

                /*" -455- DISPLAY 'ENDOSSO - ' V1EDIA-NRENDOS */
                _.Display($"ENDOSSO - {V1EDIA_NRENDOS}");

                /*" -456- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -458- END-IF */
            }


            /*" -460- MOVE SPACES TO WFIM-V1PARCELA */
            _.Move("", AREA_DE_WORK.WFIM_V1PARCELA);

            /*" -462- PERFORM R0900-00-DECLARE-V1PARCELA */

            R0900_00_DECLARE_V1PARCELA_SECTION();

            /*" -464- PERFORM R0910-00-FETCH-V1PARCELA */

            R0910_00_FETCH_V1PARCELA_SECTION();

            /*" -467- IF WFIM-V1PARCELA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty())
            {

                /*" -469- GO TO R0050-10-NEXT. */

                R0050_10_NEXT(); //GOTO
                return;
            }


            /*" -471- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT. */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

            /*" -472- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1PARCELA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0050_10_NEXT */

            R0050_10_NEXT();

        }

        [StopWatch]
        /*" R0050-00-PROCESSA-DB-SELECT-1 */
        public void R0050_00_PROCESSA_DB_SELECT_1()
        {
            /*" -449- EXEC SQL SELECT TIPO_COBRANCA INTO :APOLCOBR-TIPO-COBRANCA FROM SEGUROS.APOLICE_COBRANCA WHERE NUM_APOLICE = :V1EDIA-NUM-APOL AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r0050_00_PROCESSA_DB_SELECT_1_Query1 = new R0050_00_PROCESSA_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
            };

            var executed_1 = R0050_00_PROCESSA_DB_SELECT_1_Query1.Execute(r0050_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOBR_TIPO_COBRANCA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA);
            }


        }

        [StopWatch]
        /*" R0050-10-NEXT */
        private void R0050_10_NEXT(bool isPerform = false)
        {
            /*" -476- PERFORM R0210-00-FETCH-V1EMISDIARIA. */

            R0210_00_FETCH_V1EMISDIARIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -487- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WABEND.WNR_EXEC_SQL);

            /*" -489- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -493- DISPLAY 'PROG. EM0120 - DATA INICIO: ' WS-DT-TODAY ' - HORA INICIO: ' WS-HR-TODAY ' VERSAO: V.04' . */

            $"PROG. EM0120 - DATA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_14.WS_DT_TODAY} - HORA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_14.WS_HR_TODAY} VERSAO: V.04"
            .Display();

            /*" -498- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -501- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -502- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -503- DISPLAY 'EM0120B - SISTEMA DE COBRANCA NAO CADASTRADO' */
                    _.Display($"EM0120B - SISTEMA DE COBRANCA NAO CADASTRADO");

                    /*" -504- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -505- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -506- ELSE */
                }
                else
                {


                    /*" -507- DISPLAY 'PROBLEMAS SELECT V1SISTEMA ... ' */
                    _.Display($"PROBLEMAS SELECT V1SISTEMA ... ");

                    /*" -511- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -513- DISPLAY 'DATA DO MOVIMENTO: ' V1SIST-DTMOVABE */
            _.Display($"DATA DO MOVIMENTO: {V1SIST_DTMOVABE}");

            /*" -515- MOVE V1SIST-DTMOVABE TO WSIST-DATA WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.WDATA_REL);

            /*" -516- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -517- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -517- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -498- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V1EMISDIARIA-SECTION */
        private void R0200_00_DECLARE_V1EMISDIARIA_SECTION()
        {
            /*" -528- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", WABEND.WNR_EXEC_SQL);

            /*" -535- PERFORM R0200_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1 */

            R0200_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1();

            /*" -537- PERFORM R0200_00_DECLARE_V1EMISDIARIA_DB_OPEN_1 */

            R0200_00_DECLARE_V1EMISDIARIA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1EMISDIARIA-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1()
        {
            /*" -535- EXEC SQL DECLARE V1EMISDIA CURSOR FOR SELECT NUM_APOLICE ,NRENDOS FROM SEGUROS.V1EMISDIARIA WHERE CODRELAT = 'EM0120B1' AND SITUACAO = '0' END-EXEC */
            V1EMISDIA = new EM0120B_V1EMISDIA(false);
            string GetQuery_V1EMISDIA()
            {
                var query = @$"SELECT NUM_APOLICE 
							,NRENDOS 
							FROM SEGUROS.V1EMISDIARIA 
							WHERE CODRELAT = 'EM0120B1' 
							AND SITUACAO = '0'";

                return query;
            }
            V1EMISDIA.GetQueryEvent += GetQuery_V1EMISDIA;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1EMISDIARIA-DB-OPEN-1 */
        public void R0200_00_DECLARE_V1EMISDIARIA_DB_OPEN_1()
        {
            /*" -537- EXEC SQL OPEN V1EMISDIA END-EXEC. */

            V1EMISDIA.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1()
        {
            /*" -621- EXEC SQL DECLARE V1PARCELA CURSOR FOR SELECT A.NUM_APOLICE ,A.NRENDOS ,A.NRPARCEL ,A.DACPARC ,A.FONTE ,A.NRTIT ,A.OCORHIST ,A.QTDDOC ,A.SITUACAO ,A.COD_EMPRESA ,B.DTEMIS ,B.DTINIVIG ,B.DTTERVIG ,B.BCORCAP ,B.AGERCAP ,B.DACRCAP ,B.BCOCOBR ,B.AGECOBR ,B.DACCOBR ,B.QTPARCEL ,B.ORGAO ,B.RAMO ,B.CODPRODU ,C.PRM_TARIFARIO ,C.VAL_DESCONTO ,C.VLPRMLIQ ,C.VLADIFRA ,C.VLCUSEMI ,C.VLIOCC ,C.VLPRMTOT ,C.VLPREMIO ,C.DTVENCTO FROM SEGUROS.V1PARCELA A ,SEGUROS.V1ENDOSSO B ,SEGUROS.V1HISTOPARC C WHERE A.NUM_APOLICE = :V1EDIA-NUM-APOL AND B.TIPSEGU = '1' AND B.TIPO_ENDOSSO IN ( '0' , '1' ) AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS AND A.NUM_APOLICE = C.NUM_APOLICE AND A.NRENDOS = C.NRENDOS AND A.NRPARCEL = C.NRPARCEL AND A.OCORHIST = C.OCORHIST ORDER BY A.NUM_APOLICE ,A.NRENDOS ,A.NRPARCEL END-EXEC. */
            V1PARCELA = new EM0120B_V1PARCELA(true);
            string GetQuery_V1PARCELA()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,A.NRENDOS 
							,A.NRPARCEL 
							,A.DACPARC 
							,A.FONTE 
							,A.NRTIT 
							,A.OCORHIST 
							,A.QTDDOC 
							,A.SITUACAO 
							,A.COD_EMPRESA 
							,B.DTEMIS 
							,B.DTINIVIG 
							,B.DTTERVIG 
							,B.BCORCAP 
							,B.AGERCAP 
							,B.DACRCAP 
							,B.BCOCOBR 
							,B.AGECOBR 
							,B.DACCOBR 
							,B.QTPARCEL 
							,B.ORGAO 
							,B.RAMO 
							,B.CODPRODU 
							,C.PRM_TARIFARIO 
							,C.VAL_DESCONTO 
							,C.VLPRMLIQ 
							,C.VLADIFRA 
							,C.VLCUSEMI 
							,C.VLIOCC 
							,C.VLPRMTOT 
							,C.VLPREMIO 
							,C.DTVENCTO 
							FROM SEGUROS.V1PARCELA A 
							,SEGUROS.V1ENDOSSO B 
							,SEGUROS.V1HISTOPARC C 
							WHERE A.NUM_APOLICE = '{V1EDIA_NUM_APOL}' 
							AND B.TIPSEGU = '1' 
							AND B.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NRENDOS = B.NRENDOS 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.NRENDOS = C.NRENDOS 
							AND A.NRPARCEL = C.NRPARCEL 
							AND A.OCORHIST = C.OCORHIST 
							ORDER BY A.NUM_APOLICE 
							,A.NRENDOS 
							,A.NRPARCEL";

                return query;
            }
            V1PARCELA.GetQueryEvent += GetQuery_V1PARCELA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V1EMISDIARIA-SECTION */
        private void R0210_00_FETCH_V1EMISDIARIA_SECTION()
        {
            /*" -548- MOVE 'R0210' TO WNR-EXEC-SQL. */
            _.Move("R0210", WABEND.WNR_EXEC_SQL);

            /*" -551- PERFORM R0210_00_FETCH_V1EMISDIARIA_DB_FETCH_1 */

            R0210_00_FETCH_V1EMISDIARIA_DB_FETCH_1();

            /*" -554- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -555- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -556- MOVE 'S' TO WFIM-V1EMISDIARIA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1EMISDIARIA);

                    /*" -556- PERFORM R0210_00_FETCH_V1EMISDIARIA_DB_CLOSE_1 */

                    R0210_00_FETCH_V1EMISDIARIA_DB_CLOSE_1();

                    /*" -558- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -559- ELSE */
                }
                else
                {


                    /*" -560- DISPLAY 'R0210 - PROBLEMAS FETCH V1EMISDIARIA. ' */
                    _.Display($"R0210 - PROBLEMAS FETCH V1EMISDIARIA. ");

                    /*" -562- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -562- ADD 1 TO AC-L-V1EMISDIA. */
            AREA_DE_WORK.AC_L_V1EMISDIA.Value = AREA_DE_WORK.AC_L_V1EMISDIA + 1;

        }

        [StopWatch]
        /*" R0210-00-FETCH-V1EMISDIARIA-DB-FETCH-1 */
        public void R0210_00_FETCH_V1EMISDIARIA_DB_FETCH_1()
        {
            /*" -551- EXEC SQL FETCH V1EMISDIA INTO :V1EDIA-NUM-APOL ,:V1EDIA-NRENDOS END-EXEC. */

            if (V1EMISDIA.Fetch())
            {
                _.Move(V1EMISDIA.V1EDIA_NUM_APOL, V1EDIA_NUM_APOL);
                _.Move(V1EMISDIA.V1EDIA_NRENDOS, V1EDIA_NRENDOS);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V1EMISDIARIA-DB-CLOSE-1 */
        public void R0210_00_FETCH_V1EMISDIARIA_DB_CLOSE_1()
        {
            /*" -556- EXEC SQL CLOSE V1EMISDIA END-EXEC */

            V1EMISDIA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-SECTION */
        private void R0900_00_DECLARE_V1PARCELA_SECTION()
        {
            /*" -573- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", WABEND.WNR_EXEC_SQL);

            /*" -621- PERFORM R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1 */

            R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1();

            /*" -623- PERFORM R0900_00_DECLARE_V1PARCELA_DB_OPEN_1 */

            R0900_00_DECLARE_V1PARCELA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1PARCELA_DB_OPEN_1()
        {
            /*" -623- EXEC SQL OPEN V1PARCELA END-EXEC. */

            V1PARCELA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1PARCELA-SECTION */
        private void R0910_00_FETCH_V1PARCELA_SECTION()
        {
            /*" -632- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LEITURA */

            R0910_10_LEITURA();

        }

        [StopWatch]
        /*" R0910-10-LEITURA */
        private void R0910_10_LEITURA(bool isPerform = false)
        {
            /*" -669- PERFORM R0910_10_LEITURA_DB_FETCH_1 */

            R0910_10_LEITURA_DB_FETCH_1();

            /*" -672- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -673- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -674- MOVE 'S' TO WFIM-V1PARCELA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                    /*" -675- MOVE SPACES TO CH-CHAVE-ATU */
                    _.Move("", AREA_DE_WORK.CH_CHAVE_ATU);

                    /*" -675- PERFORM R0910_10_LEITURA_DB_CLOSE_1 */

                    R0910_10_LEITURA_DB_CLOSE_1();

                    /*" -677- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -678- ELSE */
                }
                else
                {


                    /*" -679- DISPLAY 'R0910 - PROBLEMAS FETCH V1PARCELA ... ' */
                    _.Display($"R0910 - PROBLEMAS FETCH V1PARCELA ... ");

                    /*" -681- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -682- MOVE V1PARC-NUM-APOL TO CH-APOLI-ATU */
            _.Move(V1PARC_NUM_APOL, AREA_DE_WORK.CH_CHAVE_ATU.CH_APOLI_ATU);

            /*" -684- MOVE V1PARC-NRENDOS TO CH-ENDOS-ATU */
            _.Move(V1PARC_NRENDOS, AREA_DE_WORK.CH_CHAVE_ATU.CH_ENDOS_ATU);

            /*" -685- IF VIND-COD-PRODU LESS ZEROS */

            if (VIND_COD_PRODU < 00)
            {

                /*" -687- MOVE ZEROS TO V1ENDO-CODPRODU. */
                _.Move(0, V1ENDO_CODPRODU);
            }


            /*" -687- ADD 1 TO AC-L-V1PARCELA. */
            AREA_DE_WORK.AC_L_V1PARCELA.Value = AREA_DE_WORK.AC_L_V1PARCELA + 1;

        }

        [StopWatch]
        /*" R0910-10-LEITURA-DB-FETCH-1 */
        public void R0910_10_LEITURA_DB_FETCH_1()
        {
            /*" -669- EXEC SQL FETCH V1PARCELA INTO :V1PARC-NUM-APOL ,:V1PARC-NRENDOS ,:V1PARC-NRPARCEL ,:V1PARC-DACPARC ,:V1PARC-FONTE ,:V1PARC-NRTIT ,:V1PARC-OCORHIST ,:V1PARC-QTDDOC ,:V1PARC-SITUACAO ,:V1PARC-COD-EMP:VIND-COD-EMP ,:V1ENDO-DTEMIS ,:V1ENDO-DTINIVIG ,:V1ENDO-DTTERVIG ,:V1ENDO-BCORCAP ,:V1ENDO-AGERCAP ,:V1ENDO-DACRCAP ,:V1ENDO-BCOCOBR ,:V1ENDO-AGECOBR ,:V1ENDO-DACCOBR ,:V1ENDO-QTPARCEL ,:V1ENDO-ORGAO ,:V1ENDO-RAMO ,:V1ENDO-CODPRODU:VIND-COD-PRODU ,:V1HISP-PRM-TAR ,:V1HISP-VAL-DESC ,:V1HISP-VLPRMLIQ ,:V1HISP-VLADIFRA ,:V1HISP-VLCUSEMI ,:V1HISP-VLIOCC ,:V1HISP-VLPRMTOT ,:V1HISP-VLPREMIO ,:V1HISP-DTVENCTO END-EXEC. */

            if (V1PARCELA.Fetch())
            {
                _.Move(V1PARCELA.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(V1PARCELA.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(V1PARCELA.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(V1PARCELA.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(V1PARCELA.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(V1PARCELA.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(V1PARCELA.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(V1PARCELA.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(V1PARCELA.V1PARC_SITUACAO, V1PARC_SITUACAO);
                _.Move(V1PARCELA.V1PARC_COD_EMP, V1PARC_COD_EMP);
                _.Move(V1PARCELA.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(V1PARCELA.V1ENDO_DTEMIS, V1ENDO_DTEMIS);
                _.Move(V1PARCELA.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(V1PARCELA.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(V1PARCELA.V1ENDO_BCORCAP, V1ENDO_BCORCAP);
                _.Move(V1PARCELA.V1ENDO_AGERCAP, V1ENDO_AGERCAP);
                _.Move(V1PARCELA.V1ENDO_DACRCAP, V1ENDO_DACRCAP);
                _.Move(V1PARCELA.V1ENDO_BCOCOBR, V1ENDO_BCOCOBR);
                _.Move(V1PARCELA.V1ENDO_AGECOBR, V1ENDO_AGECOBR);
                _.Move(V1PARCELA.V1ENDO_DACCOBR, V1ENDO_DACCOBR);
                _.Move(V1PARCELA.V1ENDO_QTPARCEL, V1ENDO_QTPARCEL);
                _.Move(V1PARCELA.V1ENDO_ORGAO, V1ENDO_ORGAO);
                _.Move(V1PARCELA.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(V1PARCELA.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(V1PARCELA.VIND_COD_PRODU, VIND_COD_PRODU);
                _.Move(V1PARCELA.V1HISP_PRM_TAR, V1HISP_PRM_TAR);
                _.Move(V1PARCELA.V1HISP_VAL_DESC, V1HISP_VAL_DESC);
                _.Move(V1PARCELA.V1HISP_VLPRMLIQ, V1HISP_VLPRMLIQ);
                _.Move(V1PARCELA.V1HISP_VLADIFRA, V1HISP_VLADIFRA);
                _.Move(V1PARCELA.V1HISP_VLCUSEMI, V1HISP_VLCUSEMI);
                _.Move(V1PARCELA.V1HISP_VLIOCC, V1HISP_VLIOCC);
                _.Move(V1PARCELA.V1HISP_VLPRMTOT, V1HISP_VLPRMTOT);
                _.Move(V1PARCELA.V1HISP_VLPREMIO, V1HISP_VLPREMIO);
                _.Move(V1PARCELA.V1HISP_DTVENCTO, V1HISP_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R0910-10-LEITURA-DB-CLOSE-1 */
        public void R0910_10_LEITURA_DB_CLOSE_1()
        {
            /*" -675- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -702- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -703- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT. */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

            /*" -705- MOVE SPACES TO WHOUVE-CANCELA */
            _.Move("", AREA_DE_WORK.WHOUVE_CANCELA);

            /*" -708- PERFORM R2000-00-CANCELAMENTO UNTIL CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT))
            {

                R2000_00_CANCELAMENTO_SECTION();
            }

            /*" -709- IF WHOUVE-CANCELA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WHOUVE_CANCELA.IsEmpty())
            {

                /*" -710- PERFORM R6100-00-ALTERA-V0ENDOSSO */

                R6100_00_ALTERA_V0ENDOSSO_SECTION();

                /*" -711- PERFORM R6150-00-ALTERA-V0APOLICE */

                R6150_00_ALTERA_V0APOLICE_SECTION();

                /*" -712- PERFORM R6200-00-ALTERA-V0EMISDIARIA */

                R6200_00_ALTERA_V0EMISDIARIA_SECTION();

                /*" -712- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_DESPREZA_APOLICE */

            R1000_90_DESPREZA_APOLICE();

        }

        [StopWatch]
        /*" R1000-90-DESPREZA-APOLICE */
        private void R1000_90_DESPREZA_APOLICE(bool isPerform = false)
        {
            /*" -719- PERFORM R0910-00-FETCH-V1PARCELA UNTIL CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT))
            {

                R0910_00_FETCH_V1PARCELA_SECTION();
            }

            /*" -719- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT. */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CANCELAMENTO-SECTION */
        private void R2000_00_CANCELAMENTO_SECTION()
        {
            /*" -735- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -736- IF V1PARC-SITUACAO NOT EQUAL ZEROS */

            if (V1PARC_SITUACAO != 00)
            {

                /*" -738- GO TO R2000-10-CANCELAMENTO. */

                R2000_10_CANCELAMENTO(); //GOTO
                return;
            }


            /*" -739- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

            /*" -741- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL. */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -743- PERFORM R3200-00-ACUMULA-CORRECAO. */

            R3200_00_ACUMULA_CORRECAO_SECTION();

            /*" -744- IF WC-VLPRMTOT NOT EQUAL +0 */

            if (WC_VLPRMTOT != +0)
            {

                /*" -745- PERFORM R4200-00-MONTA-CORRECAO */

                R4200_00_MONTA_CORRECAO_SECTION();

                /*" -747- PERFORM R5000-00-INSERT-V0HISTOPARC. */

                R5000_00_INSERT_V0HISTOPARC_SECTION();
            }


            /*" -749- PERFORM R3100-00-ACUMULA-PREMIOS */

            R3100_00_ACUMULA_PREMIOS_SECTION();

            /*" -750- PERFORM R4100-00-MONTA-PREMIOS */

            R4100_00_MONTA_PREMIOS_SECTION();

            /*" -752- PERFORM R5000-00-INSERT-V0HISTOPARC */

            R5000_00_INSERT_V0HISTOPARC_SECTION();

            /*" -754- PERFORM R6000-00-ALTERA-V0PARCELA. */

            R6000_00_ALTERA_V0PARCELA_SECTION();

            /*" -754- PERFORM R2000-10-CANCELAMENTO. */

            R2000_10_CANCELAMENTO();

            /*" -0- FLUXCONTROL_PERFORM R2000_10_CANCELAMENTO */

            R2000_10_CANCELAMENTO();

        }

        [StopWatch]
        /*" R2000-10-CANCELAMENTO */
        private void R2000_10_CANCELAMENTO(bool isPerform = false)
        {
            /*" -758- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -759- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -761- MOVE '*' TO WHOUVE-CANCELA. */
            _.Move("*", AREA_DE_WORK.WHOUVE_CANCELA);

            /*" -761- PERFORM R2000-90-LER-REGISTRO. */

            R2000_90_LER_REGISTRO(true);

        }

        [StopWatch]
        /*" R2000-90-LER-REGISTRO */
        private void R2000_90_LER_REGISTRO(bool isPerform = false)
        {
            /*" -764- PERFORM R0910-00-FETCH-V1PARCELA. */

            R0910_00_FETCH_V1PARCELA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-ACUMULA-PREMIOS-SECTION */
        private void R3100_00_ACUMULA_PREMIOS_SECTION()
        {
            /*" -775- MOVE 'R3100' TO WNR-EXEC-SQL. */
            _.Move("R3100", WABEND.WNR_EXEC_SQL);

            /*" -797- PERFORM R3100_00_ACUMULA_PREMIOS_DB_SELECT_1 */

            R3100_00_ACUMULA_PREMIOS_DB_SELECT_1();

            /*" -800- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -804- DISPLAY 'R3100-00 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R3100-00 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-ACUMULA-PREMIOS-DB-SELECT-1 */
        public void R3100_00_ACUMULA_PREMIOS_DB_SELECT_1()
        {
            /*" -797- EXEC SQL SELECT PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCUSEMI , VLIOCC , VLPRMTOT , VLPREMIO INTO :WP-PRM-TAR , :WP-VAL-DESC , :WP-VLPRMLIQ , :WP-VLADIFRA , :WP-VLCUSEMI , :WP-VLIOCC , :WP-VLPRMTOT , :WP-VLPREMIO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND OPERACAO = 0101 END-EXEC. */

            var r3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1 = new R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1.Execute(r3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WP_PRM_TAR, WP_PRM_TAR);
                _.Move(executed_1.WP_VAL_DESC, WP_VAL_DESC);
                _.Move(executed_1.WP_VLPRMLIQ, WP_VLPRMLIQ);
                _.Move(executed_1.WP_VLADIFRA, WP_VLADIFRA);
                _.Move(executed_1.WP_VLCUSEMI, WP_VLCUSEMI);
                _.Move(executed_1.WP_VLIOCC, WP_VLIOCC);
                _.Move(executed_1.WP_VLPRMTOT, WP_VLPRMTOT);
                _.Move(executed_1.WP_VLPREMIO, WP_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-ACUMULA-CORRECAO-SECTION */
        private void R3200_00_ACUMULA_CORRECAO_SECTION()
        {
            /*" -815- MOVE 'R3200' TO WNR-EXEC-SQL. */
            _.Move("R3200", WABEND.WNR_EXEC_SQL);

            /*" -837- PERFORM R3200_00_ACUMULA_CORRECAO_DB_SELECT_1 */

            R3200_00_ACUMULA_CORRECAO_DB_SELECT_1();

            /*" -840- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -844- DISPLAY 'R3200-00 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R3200-00 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -844- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-ACUMULA-CORRECAO-DB-SELECT-1 */
        public void R3200_00_ACUMULA_CORRECAO_DB_SELECT_1()
        {
            /*" -837- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),0) , VALUE(SUM(VAL_DESCONTO),0) , VALUE(SUM(VLPRMLIQ),0) , VALUE(SUM(VLADIFRA),0) , VALUE(SUM(VLCUSEMI),0) , VALUE(SUM(VLIOCC),0) , VALUE(SUM(VLPRMTOT),0) , VALUE(SUM(VLPREMIO),0) INTO :WC-PRM-TAR , :WC-VAL-DESC , :WC-VLPRMLIQ , :WC-VLADIFRA , :WC-VLCUSEMI , :WC-VLIOCC , :WC-VLPRMTOT , :WC-VLPREMIO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND OPERACAO = 0801 END-EXEC. */

            var r3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 = new R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1.Execute(r3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WC_PRM_TAR, WC_PRM_TAR);
                _.Move(executed_1.WC_VAL_DESC, WC_VAL_DESC);
                _.Move(executed_1.WC_VLPRMLIQ, WC_VLPRMLIQ);
                _.Move(executed_1.WC_VLADIFRA, WC_VLADIFRA);
                _.Move(executed_1.WC_VLCUSEMI, WC_VLCUSEMI);
                _.Move(executed_1.WC_VLIOCC, WC_VLIOCC);
                _.Move(executed_1.WC_VLPRMTOT, WC_VLPRMTOT);
                _.Move(executed_1.WC_VLPREMIO, WC_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-MONTA-PREMIOS-SECTION */
        private void R4100_00_MONTA_PREMIOS_SECTION()
        {
            /*" -855- MOVE 'R4100' TO WNR-EXEC-SQL. */
            _.Move("R4100", WABEND.WNR_EXEC_SQL);

            /*" -856- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -858- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -859- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -860- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -862- MOVE 0404 TO V0HISP-OPERACAO */
            _.Move(0404, V0HISP_OPERACAO);

            /*" -863- IF (V1ENDO-RAMO = 18) AND (V1ENDO-CODPRODU = 1803 OR 1805) */

            if ((V1ENDO_RAMO == 18) && (V1ENDO_CODPRODU.In("1803", "1805")))
            {

                /*" -865- MOVE 0 TO WS-QT-REG */
                _.Move(0, WS_QT_REG);

                /*" -872- PERFORM R4100_00_MONTA_PREMIOS_DB_SELECT_1 */

                R4100_00_MONTA_PREMIOS_DB_SELECT_1();

                /*" -875- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -879- DISPLAY 'R4100-00 (PROBLEMAS ACESSO CBAPOLICE): ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                    $"R4100-00 (PROBLEMAS ACESSO CBAPOLICE): {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                    .Display();

                    /*" -880- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -882- END-IF */
                }


                /*" -883- IF WS-QT-REG > 0 */

                if (WS_QT_REG > 0)
                {

                    /*" -884- MOVE 401 TO V0HISP-OPERACAO */
                    _.Move(401, V0HISP_OPERACAO);

                    /*" -885- END-IF */
                }


                /*" -887- END-IF */
            }


            /*" -888- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -890- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -892- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -894- MOVE WTIME-DAYR TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_13.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -895- MOVE V1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -896- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -897- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -898- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -899- MOVE V1EDIA-NRENDOS TO V0HISP-NRENDOCA */
            _.Move(V1EDIA_NRENDOS, V0HISP_NRENDOCA);

            /*" -900- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -901- MOVE V1ENDO-COD-USUAR TO V0HISP-COD-USUARIO */
            _.Move(V1ENDO_COD_USUAR, V0HISP_COD_USUARIO);

            /*" -902- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -903- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -905- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPRESA */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPRESA);

            /*" -906- MOVE WP-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(WP_PRM_TAR, V0HISP_PRM_TAR);

            /*" -907- MOVE WP-VAL-DESC TO V0HISP-VAL-DESC */
            _.Move(WP_VAL_DESC, V0HISP_VAL_DESC);

            /*" -908- MOVE WP-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(WP_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -909- MOVE WP-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(WP_VLADIFRA, V0HISP_VLADIFRA);

            /*" -910- MOVE WP-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(WP_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -911- MOVE WP-VLIOCC TO V0HISP-VLIOCC */
            _.Move(WP_VLIOCC, V0HISP_VLIOCC);

            /*" -912- MOVE WP-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(WP_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -914- MOVE WP-VLPREMIO TO V0HISP-VLPREMIO */
            _.Move(WP_VLPREMIO, V0HISP_VLPREMIO);

            /*" -914- ADD +1 TO AC-P-V0HISTOPARC. */
            AREA_DE_WORK.AC_P_V0HISTOPARC.Value = AREA_DE_WORK.AC_P_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R4100-00-MONTA-PREMIOS-DB-SELECT-1 */
        public void R4100_00_MONTA_PREMIOS_DB_SELECT_1()
        {
            /*" -872- EXEC SQL SELECT COUNT(*) INTO :WS-QT-REG FROM SEGUROS.CB_APOLICE_VIGPROP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND SITUACAO = 'Y' WITH UR END-EXEC */

            var r4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1 = new R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
            };

            var executed_1 = R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1.Execute(r4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_REG, WS_QT_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-MONTA-CORRECAO-SECTION */
        private void R4200_00_MONTA_CORRECAO_SECTION()
        {
            /*" -925- MOVE 'R4200' TO WNR-EXEC-SQL. */
            _.Move("R4200", WABEND.WNR_EXEC_SQL);

            /*" -926- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -928- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -929- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -930- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -932- MOVE 0804 TO V0HISP-OPERACAO */
            _.Move(0804, V0HISP_OPERACAO);

            /*" -933- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -935- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -936- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -938- MOVE WTIME-DAYR TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_13.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -939- MOVE V1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -940- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -941- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -943- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -944- MOVE V1EDIA-NRENDOS TO V0HISP-NRENDOCA */
            _.Move(V1EDIA_NRENDOS, V0HISP_NRENDOCA);

            /*" -945- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -946- MOVE V1ENDO-COD-USUAR TO V0HISP-COD-USUARIO */
            _.Move(V1ENDO_COD_USUAR, V0HISP_COD_USUARIO);

            /*" -947- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -948- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -950- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPRESA */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPRESA);

            /*" -951- MOVE WC-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(WC_PRM_TAR, V0HISP_PRM_TAR);

            /*" -952- MOVE WC-VAL-DESC TO V0HISP-VAL-DESC */
            _.Move(WC_VAL_DESC, V0HISP_VAL_DESC);

            /*" -953- MOVE WC-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(WC_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -954- MOVE WC-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(WC_VLADIFRA, V0HISP_VLADIFRA);

            /*" -955- MOVE WC-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(WC_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -956- MOVE WC-VLIOCC TO V0HISP-VLIOCC */
            _.Move(WC_VLIOCC, V0HISP_VLIOCC);

            /*" -957- MOVE WC-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(WC_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -959- MOVE WC-VLPREMIO TO V0HISP-VLPREMIO. */
            _.Move(WC_VLPREMIO, V0HISP_VLPREMIO);

            /*" -959- ADD +1 TO AC-C-V0HISTOPARC. */
            AREA_DE_WORK.AC_C_V0HISTOPARC.Value = AREA_DE_WORK.AC_C_V0HISTOPARC + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERT-V0HISTOPARC-SECTION */
        private void R5000_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -970- MOVE 'R5000' TO WNR-EXEC-SQL. */
            _.Move("R5000", WABEND.WNR_EXEC_SQL);

            /*" -999- PERFORM R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -1002- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1007- DISPLAY 'R5000-00 (REGISTRO DUPLICADO) ... ' ' ' V0HISP-NUM-APOL ' ' V0HISP-NRENDOS ' ' V0HISP-NRPARCEL ' ' V0HISP-OCORHIST */

                $"R5000-00 (REGISTRO DUPLICADO) ...  {V0HISP_NUM_APOL} {V0HISP_NRENDOS} {V0HISP_NRPARCEL} {V0HISP_OCORHIST}"
                .Display();

                /*" -1010- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1011- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1015- DISPLAY 'R5000-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0HISP-NUM-APOL ' ' V0HISP-NRENDOS ' ' V0HISP-NRPARCEL */

                $"R5000-00 (PROBLEMAS NA INSERCAO) ...  {V0HISP_NUM_APOL} {V0HISP_NRENDOS} {V0HISP_NRPARCEL}"
                .Display();

                /*" -1015- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -999- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TAR , :V0HISP-VAL-DESC , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUARIO , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO, :V0HISP-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_HORAOPER = V0HISP_HORAOPER.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TAR = V0HISP_PRM_TAR.ToString(),
                V0HISP_VAL_DESC = V0HISP_VAL_DESC.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUARIO = V0HISP_COD_USUARIO.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-ALTERA-V0PARCELA-SECTION */
        private void R6000_00_ALTERA_V0PARCELA_SECTION()
        {
            /*" -1028- MOVE 'R6000' TO WNR-EXEC-SQL. */
            _.Move("R6000", WABEND.WNR_EXEC_SQL);

            /*" -1037- PERFORM R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1 */

            R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1();

            /*" -1040- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1041- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1043- DISPLAY 'R6000-00 (PARCELA NAO ESTA PENDENTE - ' V1PARC-NRPARCEL */
                    _.Display($"R6000-00 (PARCELA NAO ESTA PENDENTE - {V1PARC_NRPARCEL}");

                    /*" -1044- ELSE */
                }
                else
                {


                    /*" -1048- DISPLAY 'R6000-00 (PROBLEMAS UPDATE V0PARCELA) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                    $"R6000-00 (PROBLEMAS UPDATE V0PARCELA) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                    .Display();

                    /*" -1050- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1052- IF ((V1ENDO-RAMO = 53 OR 31) AND (APOLCOBR-TIPO-COBRANCA = '0' )) */

            if (((V1ENDO_RAMO.In("53", "31")) && (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA == "0")))
            {

                /*" -1053- PERFORM R6010-00-ROTINA-SIGCB */

                R6010_00_ROTINA_SIGCB_SECTION();

                /*" -1053- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-00-ALTERA-V0PARCELA-DB-UPDATE-1 */
        public void R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1()
        {
            /*" -1037- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = :WOCORHIST ,SITUACAO = '2' ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND SITUACAO = '0' END-EXEC. */

            var r6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1 = new R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WOCORHIST = WOCORHIST.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1.Execute(r6000_00_ALTERA_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-ROTINA-SIGCB-SECTION */
        private void R6010_00_ROTINA_SIGCB_SECTION()
        {
            /*" -1064- MOVE 'R6010' TO WNR-EXEC-SQL. */
            _.Move("R6010", WABEND.WNR_EXEC_SQL);

            /*" -1068- MOVE ZEROS TO APOLIAUT-NUM-PROPOSTA-CONV APOLIAUT-CANAL-PROPOSTA APOLIAUT-COD-FONTE */
            _.Move(0, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE);

            /*" -1081- PERFORM R6010_00_ROTINA_SIGCB_DB_SELECT_1 */

            R6010_00_ROTINA_SIGCB_DB_SELECT_1();

            /*" -1084- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1085- DISPLAY 'R6010 (PROBLEMAS SELECT APOLICE_AUTO)' */
                _.Display($"R6010 (PROBLEMAS SELECT APOLICE_AUTO)");

                /*" -1086- DISPLAY 'APOLICE ' V1PARC-NUM-APOL */
                _.Display($"APOLICE {V1PARC_NUM_APOL}");

                /*" -1087- DISPLAY 'ENDOSSO ' V1PARC-NRENDOS */
                _.Display($"ENDOSSO {V1PARC_NRENDOS}");

                /*" -1088- DISPLAY 'PARCELA ' V1PARC-NRPARCEL */
                _.Display($"PARCELA {V1PARC_NRPARCEL}");

                /*" -1089- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1091- END-IF */
            }


            /*" -1093- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -1094- MOVE 01 TO LK-GE350-COD-FUNCAO */
            _.Move(01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -1095- MOVE 'EM0120B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0120B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -1096- MOVE V1PARC-NUM-APOL TO LK-GE350-NUM-APOLICE */
            _.Move(V1PARC_NUM_APOL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -1097- MOVE V1PARC-NRENDOS TO LK-GE350-NUM-ENDOSSO */
            _.Move(V1PARC_NRENDOS, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -1098- MOVE V1PARC-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(V1PARC_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -1101- MOVE APOLIAUT-NUM-PROPOSTA-CONV TO LK-GE350-NUM-PROPOSTA */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -1103- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -1108- IF ( LK-GE350-COD-RETORNO = '3' ) OR ( LK-GE350-COD-RETORNO = '2' AND V1ENDO-DTEMIS < '2017-06-06' ) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "3") || (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "2" && V1ENDO_DTEMIS < "2017-06-06"))
            {

                /*" -1109- GO TO R6010-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/ //GOTO
                return;

                /*" -1111- END-IF */
            }


            /*" -1112- IF LK-GE350-COD-RETORNO NOT = '0' */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
            {

                /*" -1113- DISPLAY 'ERRO NA EXECUCAO DO CALL GE0350S' */
                _.Display($"ERRO NA EXECUCAO DO CALL GE0350S");

                /*" -1114- DISPLAY 'SQLCODE: ' LK-GE350-SQLCODE */
                _.Display($"SQLCODE: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -1115- DISPLAY 'MSG ERRO: ' LK-GE350-MSG-RETORNO */
                _.Display($"MSG ERRO: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}");

                /*" -1116- DISPLAY ' R6010-BOLETO NN NAO ENCONTRADO - ANALISAR -' */
                _.Display($" R6010-BOLETO NN NAO ENCONTRADO - ANALISAR -");

                /*" -1123- DISPLAY ' COD-RET  ' LK-GE350-COD-RETORNO ' FUNCAO   ' LK-GE350-COD-FUNCAO ' PROPOSTA ' LK-GE350-NUM-PROPOSTA ' APOLICE  ' LK-GE350-NUM-APOLICE ' ENDOSSO  ' LK-GE350-NUM-ENDOSSO ' PARCELA  ' LK-GE350-NUM-PARCELA */

                $" COD-RET  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO} FUNCAO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO} PROPOSTA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA} APOLICE  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE} ENDOSSO  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO} PARCELA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}"
                .Display();

                /*" -1124- GO TO R6010-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/ //GOTO
                return;

                /*" -1125- ELSE */
            }
            else
            {


                /*" -1132- DISPLAY 'R6010-BOLETO NN ENCONTRADO' ' COD-RET  ' LK-GE350-COD-RETORNO ' FUNCAO   ' LK-GE350-COD-FUNCAO ' PROPOSTA ' LK-GE350-NUM-PROPOSTA ' APOLICE  ' LK-GE350-NUM-APOLICE ' ENDOSSO  ' LK-GE350-NUM-ENDOSSO ' PARCELA  ' LK-GE350-NUM-PARCELA */

                $"R6010-BOLETO NN ENCONTRADO COD-RET  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO} FUNCAO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO} PROPOSTA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA} APOLICE  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE} ENDOSSO  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO} PARCELA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}"
                .Display();

                /*" -1134- END-IF. */
            }


            /*" -1135- MOVE LK-GE350-DTA-VENCIMENTO TO WS-DT-VENCIM */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO, WS_DT_VENCIM);

            /*" -1137- MOVE SPACES TO WS-DT-VENCIM-20DIAS */
            _.Move("", WS_DT_VENCIM_20DIAS);

            /*" -1141- PERFORM R6010_00_ROTINA_SIGCB_DB_SELECT_2 */

            R6010_00_ROTINA_SIGCB_DB_SELECT_2();

            /*" -1144- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1145- DISPLAY 'ERRO NO CALCULO DATA VENCIMENTO - 20 DIAS' */
                _.Display($"ERRO NO CALCULO DATA VENCIMENTO - 20 DIAS");

                /*" -1146- DISPLAY 'NUM-PROPOSTA ' LK-GE350-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -1147- DISPLAY 'NUM-APOLICE  ' LK-GE350-NUM-APOLICE */
                _.Display($"NUM-APOLICE  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -1148- DISPLAY 'NUM-ENDOSSO  ' LK-GE350-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -1149- DISPLAY 'NUM-PARCELA  ' LK-GE350-NUM-PARCELA */
                _.Display($"NUM-PARCELA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -1150- DISPLAY 'DTA-VENCIMENTO ' LK-GE350-DTA-VENCIMENTO */
                _.Display($"DTA-VENCIMENTO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

                /*" -1151- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1158- END-IF */
            }


            /*" -1160- IF (LK-GE350-COD-SITUACAO = 'F' OR 'H' OR 'C' ) OR (V1SIST-DTMOVABE > WS-DT-VENCIM-20DIAS) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO.In("F", "H", "C")) || (V1SIST_DTMOVABE > WS_DT_VENCIM_20DIAS))
            {

                /*" -1161- GO TO R6010-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/ //GOTO
                return;

                /*" -1163- END-IF */
            }


            /*" -1164- MOVE 07 TO LK-GE350-COD-FUNCAO */
            _.Move(07, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -1165- MOVE 'G' TO LK-GE350-COD-TP-CONVENIO */
            _.Move("G", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO);

            /*" -1166- MOVE 'SIAS' TO LK-GE350-COD-SISTEMA */
            _.Move("SIAS", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA);

            /*" -1167- MOVE 'SIAS_09518' TO LK-GE350-COD-EVENTO */
            _.Move("SIAS_09518", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_EVENTO);

            /*" -1168- MOVE 'C' TO LK-GE350-COD-SITUACAO */
            _.Move("C", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -1169- MOVE 'EM0120B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0120B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -1170- MOVE APOLIAUT-CANAL-PROPOSTA TO LK-GE350-COD-CANAL */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CANAL);

            /*" -1171- MOVE V1PARC-NUM-APOL TO LK-GE350-NUM-CONTA-CNTRO */
            _.Move(V1PARC_NUM_APOL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CONTA_CNTRO);

            /*" -1172- MOVE APOLIAUT-COD-FONTE TO LK-GE350-COD-FONTE */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FONTE);

            /*" -1174- MOVE 0 TO LK-GE350-VLR-IOF */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

            /*" -1176- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -1178- IF LK-GE350-COD-RETORNO NOT = '0' AND '8' */

            if (!LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO.In("0", "8"))
            {

                /*" -1179- MOVE 02 TO LK-GE350-COD-FUNCAO */
                _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

                /*" -1181- MOVE 'P' TO LK-GE350-COD-SITUACAO */
                _.Move("P", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -1183- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
                _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

                /*" -1184- IF LK-GE350-COD-RETORNO NOT = '0' */

                if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
                {

                    /*" -1185- DISPLAY '*ERRO NA EXECUCAO DO CALL GE0350S*' */
                    _.Display($"*ERRO NA EXECUCAO DO CALL GE0350S*");

                    /*" -1186- DISPLAY 'SQLCODE: ' LK-GE350-SQLCODE */
                    _.Display($"SQLCODE: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                    /*" -1187- DISPLAY 'MSG ERRO: ' LK-GE350-MSG-RETORNO */
                    _.Display($"MSG ERRO: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}");

                    /*" -1197- DISPLAY ' R6010-BOLETO NN NAO CANCELADO - ANALISAR' ' COD-RET  ' LK-GE350-COD-RETORNO ' FUNCAO   ' LK-GE350-COD-FUNCAO ' SITUACAO ' LK-GE350-COD-SITUACAO ' PROPOSTA ' LK-GE350-NUM-PROPOSTA ' APOLICE  ' LK-GE350-NUM-APOLICE ' ENDOSSO  ' LK-GE350-NUM-ENDOSSO ' PARCELA  ' LK-GE350-NUM-PARCELA ' NUM-IDLG ' LK-GE350-NUM-IDLG */

                    $" R6010-BOLETO NN NAO CANCELADO - ANALISAR COD-RET  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO} FUNCAO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO} SITUACAO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO} PROPOSTA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA} APOLICE  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE} ENDOSSO  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO} PARCELA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA} NUM-IDLG {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}"
                    .Display();

                    /*" -1198- ELSE */
                }
                else
                {


                    /*" -1207- DISPLAY ' R6010-BOLETO NN CANCELADO COM SUCESSO ' ' COD-RET  ' LK-GE350-COD-RETORNO ' FUNCAO   ' LK-GE350-COD-FUNCAO ' SITUACAO ' LK-GE350-COD-SITUACAO ' PROPOSTA ' LK-GE350-NUM-PROPOSTA ' APOLICE  ' LK-GE350-NUM-APOLICE ' ENDOSSO  ' LK-GE350-NUM-ENDOSSO ' PARCELA  ' LK-GE350-NUM-PARCELA ' NUM-IDLG ' LK-GE350-NUM-IDLG */

                    $" R6010-BOLETO NN CANCELADO COM SUCESSO  COD-RET  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO} FUNCAO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO} SITUACAO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO} PROPOSTA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA} APOLICE  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE} ENDOSSO  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO} PARCELA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA} NUM-IDLG {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}"
                    .Display();

                    /*" -1208- END-IF */
                }


                /*" -1208- END-IF. */
            }


        }

        [StopWatch]
        /*" R6010-00-ROTINA-SIGCB-DB-SELECT-1 */
        public void R6010_00_ROTINA_SIGCB_DB_SELECT_1()
        {
            /*" -1081- EXEC SQL SELECT NUM_PROPOSTA_CONV ,CANAL_PROPOSTA ,COD_FONTE INTO :APOLIAUT-NUM-PROPOSTA-CONV ,:APOLIAUT-CANAL-PROPOSTA ,:APOLIAUT-COD-FONTE FROM SEGUROS.APOLICE_AUTO WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NUM_ENDOSSO = :V1PARC-NRENDOS AND SIT_REGISTRO = ' ' WITH UR END-EXEC */

            var r6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1 = new R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1.Execute(r6010_00_ROTINA_SIGCB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV);
                _.Move(executed_1.APOLIAUT_CANAL_PROPOSTA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA);
                _.Move(executed_1.APOLIAUT_COD_FONTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-ROTINA-SIGCB-DB-SELECT-2 */
        public void R6010_00_ROTINA_SIGCB_DB_SELECT_2()
        {
            /*" -1141- EXEC SQL SELECT DATE(DAYS(:WS-DT-VENCIM) - 20) INTO :WS-DT-VENCIM-20DIAS FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var r6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1 = new R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1()
            {
                WS_DT_VENCIM = WS_DT_VENCIM.ToString(),
            };

            var executed_1 = R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1.Execute(r6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DT_VENCIM_20DIAS, WS_DT_VENCIM_20DIAS);
            }


        }

        [StopWatch]
        /*" R6100-00-ALTERA-V0ENDOSSO-SECTION */
        private void R6100_00_ALTERA_V0ENDOSSO_SECTION()
        {
            /*" -1219- MOVE 'R6100' TO WNR-EXEC-SQL. */
            _.Move("R6100", WABEND.WNR_EXEC_SQL);

            /*" -1226- PERFORM R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1 */

            R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1();

            /*" -1229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1237- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1238- GO TO R6100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1239- ELSE */
                }
                else
                {


                    /*" -1242- DISPLAY 'R6100-00 (PROBLEMAS UPDATE V0ENDOSSO) ... ' ' ' V0HISP-NUM-APOL ' ' V1PARC-NRENDOS */

                    $"R6100-00 (PROBLEMAS UPDATE V0ENDOSSO) ...  {V0HISP_NUM_APOL} {V1PARC_NRENDOS}"
                    .Display();

                    /*" -1242- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6100-00-ALTERA-V0ENDOSSO-DB-UPDATE-1 */
        public void R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -1226- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS AND SITUACAO = '0' END-EXEC. */

            var r6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1_Update1 = new R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            R6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r6100_00_ALTERA_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6150-00-ALTERA-V0APOLICE-SECTION */
        private void R6150_00_ALTERA_V0APOLICE_SECTION()
        {
            /*" -1253- MOVE 'R6150' TO WNR-EXEC-SQL. */
            _.Move("R6150", WABEND.WNR_EXEC_SQL);

            /*" -1259- PERFORM R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1 */

            R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1();

            /*" -1262- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1263- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1264- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -1265- DISPLAY '   R6150-00 (PROBLEMAS UPDATE V0ENDOSSO) ...    ' */
                    _.Display($"   R6150-00 (PROBLEMAS UPDATE V0ENDOSSO) ...    ");

                    /*" -1266- DISPLAY '   NAO ENCONTRADO O ENDOSSO ZERO P/ APOLICE     ' */
                    _.Display($"   NAO ENCONTRADO O ENDOSSO ZERO P/ APOLICE     ");

                    /*" -1267- DISPLAY 'CONTINUAR A ROTINA E AVISAR ANALISTA RESPONSAVEL' */
                    _.Display($"CONTINUAR A ROTINA E AVISAR ANALISTA RESPONSAVEL");

                    /*" -1268- DISPLAY '  NUM_APOLICE  --->> ' V0HISP-NUM-APOL */
                    _.Display($"  NUM_APOLICE  --->> {V0HISP_NUM_APOL}");

                    /*" -1269- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -1270- GO TO R6150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_99_SAIDA*/ //GOTO
                    return;

                    /*" -1271- ELSE */
                }
                else
                {


                    /*" -1274- DISPLAY 'R6150-00 (PROBLEMAS UPDATE V0ENDOSSO) ... ' ' ' V0HISP-NUM-APOL ' ' V1PARC-NRENDOS */

                    $"R6150-00 (PROBLEMAS UPDATE V0ENDOSSO) ...  {V0HISP_NUM_APOL} {V1PARC_NRENDOS}"
                    .Display();

                    /*" -1274- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6150-00-ALTERA-V0APOLICE-DB-UPDATE-1 */
        public void R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1()
        {
            /*" -1259- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = 0 END-EXEC. */

            var r6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1 = new R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
            };

            R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1.Execute(r6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-ALTERA-V0EMISDIARIA-SECTION */
        private void R6200_00_ALTERA_V0EMISDIARIA_SECTION()
        {
            /*" -1285- MOVE 'R6200' TO WNR-EXEC-SQL. */
            _.Move("R6200", WABEND.WNR_EXEC_SQL);

            /*" -1292- PERFORM R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1 */

            R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1();

            /*" -1295- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1296- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1299- DISPLAY 'R6200-00 (NAO ENCONTROU P/ UPDATE V0EMISDIARIA)' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                    $"R6200-00 (NAO ENCONTROU P/ UPDATE V0EMISDIARIA) {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                    .Display();

                    /*" -1300- GO TO R6200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/ //GOTO
                    return;

                    /*" -1301- ELSE */
                }
                else
                {


                    /*" -1304- DISPLAY 'R6200-00 (PROBLEMAS UPDATE V0EMISDIARIA)..' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                    $"R6200-00 (PROBLEMAS UPDATE V0EMISDIARIA).. {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                    .Display();

                    /*" -1304- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6200-00-ALTERA-V0EMISDIARIA-DB-UPDATE-1 */
        public void R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1()
        {
            /*" -1292- EXEC SQL UPDATE SEGUROS.V0EMISDIARIA SET SITUACAO = '1' ,TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'EM0120B1' AND NUM_APOLICE = :V0HISP-NUM-APOL AND SITUACAO = '0' END-EXEC. */

            var r6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1_Update1 = new R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1_Update1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
            };

            R6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1_Update1.Execute(r6200_00_ALTERA_V0EMISDIARIA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1318- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1319- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1320- DISPLAY '*   EM0120B - CANCELAMENTO APOLICES        *' */
            _.Display($"*   EM0120B - CANCELAMENTO APOLICES        *");

            /*" -1321- DISPLAY '*   -------   ------------ --------        *' */
            _.Display($"*   -------   ------------ --------        *");

            /*" -1322- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1323- DISPLAY '*          NAO HOUVE MOVIMENTO             *' */
            _.Display($"*          NAO HOUVE MOVIMENTO             *");

            /*" -1324- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1324- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1338- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -1339- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1340- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1342- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1343- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1344- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1345- DISPLAY '*   EM0120B - CANCELAMENTO APOLICE         *' */
            _.Display($"*   EM0120B - CANCELAMENTO APOLICE         *");

            /*" -1346- DISPLAY '*   -------   ------------ -------         *' */
            _.Display($"*   -------   ------------ -------         *");

            /*" -1347- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1348- DISPLAY '*  NAO HOUVE PARCELAS A SEREM CANCELADAS   *' */
            _.Display($"*  NAO HOUVE PARCELAS A SEREM CANCELADAS   *");

            /*" -1349- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1349- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1364- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1366- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1366- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1368- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1373- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1373- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}