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
using Sias.Cobranca.DB2.CB1000B;

namespace Code
{
    public class CB1000B
    {
        public bool IsCall { get; set; }

        public CB1000B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FECHAMENTO MENSAL                  *      */
        /*"      *   PROGRAMA ...............  CB1000B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1991                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CALCULA E GRAVA NO HISTORICO DE    *      */
        /*"      *                             PARCELAS:                          *      */
        /*"      *                             . CORRECAO MONETARIA S/PENDENTE    *      */
        /*"      *                             . PREMIOS PENDENTES                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * RELATORIOS                          V0RELATORIOS      I-O      *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         INPUT    *      */
        /*"      * PARCELAS                            V1PARCELA         INPUT    *      */
        /*"      * COTACAO MOEDAS                      V0COTACAO         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      * 03/10/2008 - INCLUIR WITH UR NO SELECT              - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO EM 19/10/2011.  CADMUS GEFIC 62337.                *      */
        /*"      *                             CLOVIS        V.01                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 08/02/2013 POR GILSON PINTO DA SILVA              *      */
        /*"      * CADMUS 74620 - INIBIR O ACESSO AS TABLS DE CONTROLE V0CONTPROG *      */
        /*"      *                E V0CONTEXPRG PARA DESATIVACAO DO MODULO CONTA- *      */
        /*"      *                BIL CG DO SISTEMA SIAS  -  PROCURAR POR C74620  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO EM 15/05/2019.  AJUSTE COD_USUARIO.                *      */
        /*"      *                             CLOVIS        V.02                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 28/06/2021 POR GILSON PINTO DA SILVA              *      */
        /*"      *           EXCLUIR O ACESSO AS VIEWS DE CONTROLE V0CONTPROG E   *      */
        /*"      *           V0CONTEXPRG AS QUAIS NAO ESTAO SENDO MAIS UTILIZADAS *      */
        /*"      *           PELO MODULO CG DO SISTEMA SIAS          JAZZ  294860 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77        WHOST-DATA-REF        PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        WHOST-DTVENCTO        PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        WHOST-OCORHIST        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        W1-PRM-TAR            PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W1-VAL-DES            PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W1-VLPRMLIQ           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W1-VLADIFRA           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W1-VLCUSEMI           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W1-VLIOCC             PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W1-VLPRMTOT           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W1_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-PRM-TAR            PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-VAL-DES            PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-VLPRMLIQ           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-VLADIFRA           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-VLCUSEMI           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-VLIOCC             PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W2-VLPRMTOT           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W2_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-PRM-TAR            PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-VAL-DES            PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-VLPRMLIQ           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-VLADIFRA           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-VLCUSEMI           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-VLIOCC             PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        W3-VLPRMTOT           PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis W3_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        VIND-DTQITBCO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-COD-EMP          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1SIST-DTMOVABE       PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1SIST-TIMESTAMP      PIC  X(026).*/
        public StringBasis V1SIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77        V1RELA-CODRELAT       PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77        V1RELA-MES-REFER      PIC S9(004)               COMP.*/
        public IntBasis V1RELA_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1RELA-ANO-REFER      PIC S9(004)               COMP.*/
        public IntBasis V1RELA_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1RELA-SITUACAO       PIC  X(001).*/
        public StringBasis V1RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-CODCLIEN       PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-NUM-APOL       PIC S9(013)               COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V1ENDO-NRENDOS        PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-NUM-ITEM       PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-CODSUBES       PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-MODALIDA       PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-ORGAO          PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-RAMO           PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-APOL-ANT       PIC S9(013)               COMP-3*/
        public IntBasis V1ENDO_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V1ENDO-FONTE          PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-NRPROPOS       PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-DATPRO         PIC  X(010).*/
        public StringBasis V1ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-DATA-LIB       PIC  X(010).*/
        public StringBasis V1ENDO_DATA_LIB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-DTEMIS         PIC  X(010).*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-NUMBIL         PIC S9(015)               COMP-3*/
        public IntBasis V1ENDO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77        V1ENDO-TIPSEGU        PIC  X(001).*/
        public StringBasis V1ENDO_TIPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-TIPAPO         PIC  X(001).*/
        public StringBasis V1ENDO_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-TIPCALC        PIC  X(001).*/
        public StringBasis V1ENDO_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-PODPUBL        PIC  X(001).*/
        public StringBasis V1ENDO_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-NUM-ATA        PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-ANO-ATA        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-IDEMAN         PIC  X(001).*/
        public StringBasis V1ENDO_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-NRRCAP         PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-VLRCAP         PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V1ENDO-BCORCAP        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-AGERCAP        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-DACRCAP        PIC  X(001).*/
        public StringBasis V1ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-IDRCAP         PIC  X(001).*/
        public StringBasis V1ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-BCOCOBR        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-AGECOBR        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-DACCOBR        PIC  X(001).*/
        public StringBasis V1ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-DTINIVIG       PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-DTTERVIG       PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-CDFRACIO       PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-PCENTRAD       PIC S9(003)V99            COMP-3*/
        public DoubleBasis V1ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77        V1ENDO-PCADICIO       PIC S9(003)V99            COMP-3*/
        public DoubleBasis V1ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77        V1ENDO-PCDESCON       PIC S9(003)V99            COMP-3*/
        public DoubleBasis V1ENDO_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77        V1ENDO-PCIOCC         PIC S9(003)V99            COMP-3*/
        public DoubleBasis V1ENDO_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77        V1ENDO-PRESTA1        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-QTPARCEL       PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-QTPRESTA       PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-QTITENS        PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-CODTXT         PIC  X(003).*/
        public StringBasis V1ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77        V1ENDO-CDACEITA       PIC  X(001).*/
        public StringBasis V1ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-MOEDA-IMP      PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-MOEDA-PRM      PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-TIPO-END       PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_END { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-TPCOSCED       PIC  X(001).*/
        public StringBasis V1ENDO_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-QTCOSSEG       PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-PCTCED         PIC S9(004)V9(5)          COMP-3*/
        public DoubleBasis V1ENDO_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77        V1ENDO-OCORR-END      PIC S9(004)               COMP.*/
        public IntBasis V1ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1ENDO-COD-USUAR      PIC  X(008).*/
        public StringBasis V1ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77        V1ENDO-SITUACAO       PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-DATA-SORT      PIC  X(010).*/
        public StringBasis V1ENDO_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-DATARCAP       PIC  X(010).*/
        public StringBasis V1ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V1ENDO-CORRECAO       PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1ENDO-COD-EMP        PIC S9(009)               COMP.*/
        public IntBasis V1ENDO_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1ENDO-ISENTA-CST     PIC  X(001).*/
        public StringBasis V1ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1PARC-NUM-APOL       PIC S9(013)               COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V1PARC-NRENDOS        PIC S9(009)               COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1PARC-NRPARCEL       PIC S9(004)               COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1PARC-DACPARC        PIC  X(001).*/
        public StringBasis V1PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1PARC-FONTE          PIC S9(004)               COMP.*/
        public IntBasis V1PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1PARC-NRTIT          PIC S9(013)               COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V1PARC-PRM-TAR        PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-VAL-DES        PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-OTNPRLIQ       PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-OTNADFRA       PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-OTNCUSTO       PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-OTNIOF         PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-OTNTOTAL       PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77        V1PARC-OCORHIST       PIC S9(004)               COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1PARC-QTDDOC         PIC S9(004)               COMP.*/
        public IntBasis V1PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V1PARC-SITUACAO       PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V1PARC-COD-EMP        PIC S9(009)               COMP.*/
        public IntBasis V1PARC_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V1PARC-TIMESTAMP      PIC X(026).*/
        public StringBasis V1PARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77        V0COTM-CODUNIMO       PIC S9(004)               COMP.*/
        public IntBasis V0COTM_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0COTM-VAL-VNDA       PIC S9(006)V9(9)          COMP-3*/
        public DoubleBasis V0COTM_VAL_VNDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77        V0COTM-DTINIVIG       PIC  X(010).*/
        public StringBasis V0COTM_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V0COTM-DTTERVIG       PIC  X(010).*/
        public StringBasis V0COTM_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V0HISP-NUM-APOL       PIC S9(013)               COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V0HISP-NRENDOS        PIC S9(009)               COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0HISP-NRPARCEL       PIC S9(004)               COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0HISP-DACPARC        PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V0HISP-DTMOVTO        PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V0HISP-OPERACAO       PIC S9(004)               COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0HISP-HORAOPER       PIC  X(008).*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77        V0HISP-OCORHIST       PIC S9(004)               COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0HISP-PRM-TAR        PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VAL-DESC       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VLPRMLIQ       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VLADIFRA       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VLCUSEMI       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VLIOCC         PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VLPRMTOT       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-VLPREMIO       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0HISP-DTVENCTO       PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V0HISP-BCOCOBR        PIC S9(004)               COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0HISP-AGECOBR        PIC S9(004)               COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0HISP-NRAVISO        PIC S9(009)               COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0HISP-NRENDOCA       PIC S9(009)               COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0HISP-SITCONTB       PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        V0HISP-COD-USUR       PIC  X(008).*/
        public StringBasis V0HISP_COD_USUR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77        V0HISP-RNUDOC         PIC S9(009)               COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0HISP-DTQITBCO       PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77        V0HISP-COD-EMPR       PIC S9(009)               COMP.*/
        public IntBasis V0HISP_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0HISP-TIMESTAMP      PIC X(026).*/
        public StringBasis V0HISP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01        AREA-DE-WORK.*/
        public CB1000B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB1000B_AREA_DE_WORK();
        public class CB1000B_AREA_DE_WORK : VarBasis
        {
            /*"  05      WSL-SQLCODE           PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WRESTO                PIC S9(003)      VALUE +0 COMP-3*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05      AC-COUNT              PIC S9(007)      VALUE +0 COMP-3*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  05      AC-L-V1PARCELA        PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-P-V1PARCELA        PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_P_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-C-V0HISTOPARC      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_C_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-P-V0HISTOPARC      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_P_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      WFIM-V1PARCELA        PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-V1RELATORIOS     PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WNUM-APOL-ANT         PIC S9(013)      VALUE +0 COMP-3*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05      WNUM-ENDS-ANT         PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WNUM_ENDS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      WCOT-MOED-IVG         PIC S9(006)V9(9) VALUE +0 COMP-3*/
            public DoubleBasis WCOT_MOED_IVG { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"  05      WDATA-AUX             PIC  X(010)      VALUE SPACES.*/
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-AUX-R           REDEFINES        WDATA-AUX.*/
            private _REDEF_CB1000B_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_CB1000B_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_CB1000B_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_CB1000B_WDATA_AUX_R : VarBasis
            {
                /*"    10    WDAT-ANO-AUX          PIC  9(004).*/
                public IntBasis WDAT_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-MES-AUX          PIC  9(002).*/
                public IntBasis WDAT_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-DIA-AUX          PIC  9(002).*/
                public IntBasis WDAT_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-EDIT.*/

                public _REDEF_CB1000B_WDATA_AUX_R()
                {
                    WDAT_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WDAT_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public CB1000B_WDATA_EDIT WDATA_EDIT { get; set; } = new CB1000B_WDATA_EDIT();
            public class CB1000B_WDATA_EDIT : VarBasis
            {
                /*"    10    WDAT-DIA-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-MES-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-ANO-EDT          PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDAT_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WEMIS-DATA            PIC  X(010)      VALUE ZEROS.*/
            }
            public StringBasis WEMIS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WEMIS-DT-R            REDEFINES        WEMIS-DATA.*/
            private _REDEF_CB1000B_WEMIS_DT_R _wemis_dt_r { get; set; }
            public _REDEF_CB1000B_WEMIS_DT_R WEMIS_DT_R
            {
                get { _wemis_dt_r = new _REDEF_CB1000B_WEMIS_DT_R(); _.Move(WEMIS_DATA, _wemis_dt_r); VarBasis.RedefinePassValue(WEMIS_DATA, _wemis_dt_r, WEMIS_DATA); _wemis_dt_r.ValueChanged += () => { _.Move(_wemis_dt_r, WEMIS_DATA); }; return _wemis_dt_r; }
                set { VarBasis.RedefinePassValue(value, _wemis_dt_r, WEMIS_DATA); }
            }  //Redefines
            public class _REDEF_CB1000B_WEMIS_DT_R : VarBasis
            {
                /*"    10    WEMIS-ANOMES.*/
                public CB1000B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new CB1000B_WEMIS_ANOMES();
                public class CB1000B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15  WEMI-ANO              PIC  9(004).*/
                    public IntBasis WEMI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15  FILLER                PIC  X(001).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15  WEMI-MES              PIC  9(002).*/
                    public IntBasis WEMI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10    FILLER                PIC  X(001).*/

                    public CB1000B_WEMIS_ANOMES()
                    {
                        WEMI_ANO.ValueChanged += OnValueChanged;
                        FILLER_4.ValueChanged += OnValueChanged;
                        WEMI_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WEMI-DIA              PIC  9(002).*/
                public IntBasis WEMI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WVENCTO-DATA          PIC  X(010)      VALUE ZEROS.*/

                public _REDEF_CB1000B_WEMIS_DT_R()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WEMI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WVENCTO_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WVENCTO-DT-R          REDEFINES        WVENCTO-DATA.*/
            private _REDEF_CB1000B_WVENCTO_DT_R _wvencto_dt_r { get; set; }
            public _REDEF_CB1000B_WVENCTO_DT_R WVENCTO_DT_R
            {
                get { _wvencto_dt_r = new _REDEF_CB1000B_WVENCTO_DT_R(); _.Move(WVENCTO_DATA, _wvencto_dt_r); VarBasis.RedefinePassValue(WVENCTO_DATA, _wvencto_dt_r, WVENCTO_DATA); _wvencto_dt_r.ValueChanged += () => { _.Move(_wvencto_dt_r, WVENCTO_DATA); }; return _wvencto_dt_r; }
                set { VarBasis.RedefinePassValue(value, _wvencto_dt_r, WVENCTO_DATA); }
            }  //Redefines
            public class _REDEF_CB1000B_WVENCTO_DT_R : VarBasis
            {
                /*"    10    WVENCTO-ANOMES.*/
                public CB1000B_WVENCTO_ANOMES WVENCTO_ANOMES { get; set; } = new CB1000B_WVENCTO_ANOMES();
                public class CB1000B_WVENCTO_ANOMES : VarBasis
                {
                    /*"      15  WVENC-ANO             PIC  9(004).*/
                    public IntBasis WVENC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15  FILLER                PIC  X(001).*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15  WVENC-MES             PIC  9(002).*/
                    public IntBasis WVENC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10    FILLER                PIC  X(001).*/

                    public CB1000B_WVENCTO_ANOMES()
                    {
                        WVENC_ANO.ValueChanged += OnValueChanged;
                        FILLER_6.ValueChanged += OnValueChanged;
                        WVENC_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WVENC-DIA             PIC  9(002).*/
                public IntBasis WVENC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WSIST-DATA            PIC  X(010)      VALUE ZEROS.*/

                public _REDEF_CB1000B_WVENCTO_DT_R()
                {
                    WVENCTO_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WVENC_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WSIST-DATA-R          REDEFINES        WSIST-DATA.*/
            private _REDEF_CB1000B_WSIST_DATA_R _wsist_data_r { get; set; }
            public _REDEF_CB1000B_WSIST_DATA_R WSIST_DATA_R
            {
                get { _wsist_data_r = new _REDEF_CB1000B_WSIST_DATA_R(); _.Move(WSIST_DATA, _wsist_data_r); VarBasis.RedefinePassValue(WSIST_DATA, _wsist_data_r, WSIST_DATA); _wsist_data_r.ValueChanged += () => { _.Move(_wsist_data_r, WSIST_DATA); }; return _wsist_data_r; }
                set { VarBasis.RedefinePassValue(value, _wsist_data_r, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_CB1000B_WSIST_DATA_R : VarBasis
            {
                /*"    10    WSIST-ANOMES.*/
                public CB1000B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new CB1000B_WSIST_ANOMES();
                public class CB1000B_WSIST_ANOMES : VarBasis
                {
                    /*"      15  WSIS-ANO              PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15  FILLER                PIC  X(001).*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15  WSIS-MES              PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10    FILLER                PIC  X(001).*/

                    public CB1000B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_8.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WSIS-DIA              PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WTIME-DAY             PIC  99.99.99.99.*/

                public _REDEF_CB1000B_WSIST_DATA_R()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05      WTIME-DAY-R           REDEFINES        WTIME-DAY.*/
            private _REDEF_CB1000B_WTIME_DAY_R _wtime_day_r { get; set; }
            public _REDEF_CB1000B_WTIME_DAY_R WTIME_DAY_R
            {
                get { _wtime_day_r = new _REDEF_CB1000B_WTIME_DAY_R(); _.Move(WTIME_DAY, _wtime_day_r); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_day_r, WTIME_DAY); _wtime_day_r.ValueChanged += () => { _.Move(_wtime_day_r, WTIME_DAY); }; return _wtime_day_r; }
                set { VarBasis.RedefinePassValue(value, _wtime_day_r, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB1000B_WTIME_DAY_R : VarBasis
            {
                /*"    10    WTIME-DAYR.*/
                public CB1000B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB1000B_WTIME_DAYR();
                public class CB1000B_WTIME_DAYR : VarBasis
                {
                    /*"      15  WTIME-HORA            PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15  WTIME-2PT1            PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15  WTIME-MINU            PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15  WTIME-2PT2            PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15  WTIME-SEGU            PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10    WTIME-2PT3            PIC  X(001).*/

                    public CB1000B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WTIME-CCSG            PIC  X(002).*/
                public StringBasis WTIME_CCSG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      WS-TIME.*/

                public _REDEF_CB1000B_WTIME_DAY_R()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
            public CB1000B_WS_TIME WS_TIME { get; set; } = new CB1000B_WS_TIME();
            public class CB1000B_WS_TIME : VarBasis
            {
                /*"    10    WS-HH-TIME            PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    WS-MM-TIME            PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    WS-SS-TIME            PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    WS-CC-TIME            PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WHORA-EDIT.*/
            }
            public CB1000B_WHORA_EDIT WHORA_EDIT { get; set; } = new CB1000B_WHORA_EDIT();
            public class CB1000B_WHORA_EDIT : VarBasis
            {
                /*"    10    WHORA-HH-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10    WHORA-MM-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10    WHORA-SS-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01        WABEND.*/
            }
        }
        public CB1000B_WABEND WABEND { get; set; } = new CB1000B_WABEND();
        public class CB1000B_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(008)      VALUE         'CB1000B '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CB1000B ");
            /*"  05      FILLER                PIC  X(035)      VALUE         ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"  05      WNR-EXEC-SQL          PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER                PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE              PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public CB1000B_V1PARCELA V1PARCELA { get; set; } = new CB1000B_V1PARCELA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -398- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -399- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -402- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -405- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -409- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -411- PERFORM R0200-00-SELECT-V1RELATORIOS. */

            R0200_00_SELECT_V1RELATORIOS_SECTION();

            /*" -412- IF WFIM-V1RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty())
            {

                /*" -413- GO TO R0000-90-ENCERRA */

                R0000_90_ENCERRA(); //GOTO
                return;

                /*" -414- ELSE */
            }
            else
            {


                /*" -415- MOVE ZEROS TO WNUM-APOL-ANT */
                _.Move(0, AREA_DE_WORK.WNUM_APOL_ANT);

                /*" -416- MOVE ZEROS TO WNUM-ENDS-ANT */
                _.Move(0, AREA_DE_WORK.WNUM_ENDS_ANT);

                /*" -418- END-IF. */
            }


            /*" -419- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -420- MOVE WS-HH-TIME TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -421- MOVE WS-MM-TIME TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -422- MOVE WS-SS-TIME TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -424- DISPLAY 'INICIO DECLARE V1PARCELA    ' WHORA-EDIT. */
            _.Display($"INICIO DECLARE V1PARCELA    {AREA_DE_WORK.WHORA_EDIT}");

            /*" -426- PERFORM R0900-00-DECLARE-V1PARCELA. */

            R0900_00_DECLARE_V1PARCELA_SECTION();

            /*" -427- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -428- MOVE WS-HH-TIME TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -429- MOVE WS-MM-TIME TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -430- MOVE WS-SS-TIME TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -432- DISPLAY 'FINAL  DECLARE V1PARCELA    ' WHORA-EDIT. */
            _.Display($"FINAL  DECLARE V1PARCELA    {AREA_DE_WORK.WHORA_EDIT}");

            /*" -434- PERFORM R0950-00-FETCH-V1PARCELA. */

            R0950_00_FETCH_V1PARCELA_SECTION();

            /*" -435- IF WFIM-V1PARCELA EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty())
            {

                /*" -437- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1PARCELA NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty()))
                {

                    R1000_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -438- ELSE */
            }
            else
            {


                /*" -439- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -441- END-IF. */
            }


            /*" -441- PERFORM R0300-00-DELETE-V0RELATORIOS. */

            R0300_00_DELETE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -446- DISPLAY 'PARCELAS LIDAS ......... ' AC-L-V1PARCELA. */
            _.Display($"PARCELAS LIDAS ......... {AREA_DE_WORK.AC_L_V1PARCELA}");

            /*" -447- DISPLAY 'PARCELAS PROCESSADAS ... ' AC-P-V1PARCELA. */
            _.Display($"PARCELAS PROCESSADAS ... {AREA_DE_WORK.AC_P_V1PARCELA}");

            /*" -448- DISPLAY 'HISTORICOS INSERIDOS     ' . */
            _.Display($"HISTORICOS INSERIDOS     ");

            /*" -449- DISPLAY '. CORRECAO MONETARIA ... ' AC-C-V0HISTOPARC. */
            _.Display($". CORRECAO MONETARIA ... {AREA_DE_WORK.AC_C_V0HISTOPARC}");

            /*" -451- DISPLAY '. PENDENTE.............. ' AC-P-V0HISTOPARC. */
            _.Display($". PENDENTE.............. {AREA_DE_WORK.AC_P_V0HISTOPARC}");

            /*" -453- DISPLAY '*-------*  CB1000B - FIM NORMAL  *------*' . */
            _.Display($"*-------*  CB1000B - FIM NORMAL  *------*");

            /*" -453- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -457- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -457- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -470- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -478- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -482- DISPLAY 'R0100 - ERRO NO SELECT DA V1SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V1SISTEMA");

                /*" -483- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -484- ELSE */
            }
            else
            {


                /*" -485- DISPLAY 'DATA DO MOVIMENTO CB - ' V1SIST-DTMOVABE */
                _.Display($"DATA DO MOVIMENTO CB - {V1SIST_DTMOVABE}");

                /*" -485- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -478- EXEC SQL SELECT DTMOVABE, CURRENT TIMESTAMP INTO :V1SIST-DTMOVABE, :V1SIST-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_TIMESTAMP, V1SIST_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V1RELATORIOS-SECTION */
        private void R0200_00_SELECT_V1RELATORIOS_SECTION()
        {
            /*" -498- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -508- PERFORM R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1 */

            R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1();

            /*" -511- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -512- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -513- DISPLAY 'CB1000B - NAO HOUVE SOLICITACAO PARA EXECUCAO' */
                    _.Display($"CB1000B - NAO HOUVE SOLICITACAO PARA EXECUCAO");

                    /*" -514- MOVE 'S' TO WFIM-V1RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RELATORIOS);

                    /*" -515- GO TO R0200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                    return;

                    /*" -516- ELSE */
                }
                else
                {


                    /*" -517- DISPLAY 'R0200 - ERRO NO SELECT DA V1RELATORIOS' */
                    _.Display($"R0200 - ERRO NO SELECT DA V1RELATORIOS");

                    /*" -518- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -519- END-IF */
                }


                /*" -521- END-IF. */
            }


            /*" -524- MOVE V1SIST-DTMOVABE TO WDATA-AUX WSIST-DATA. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_AUX, AREA_DE_WORK.WSIST_DATA);

            /*" -525- MOVE WDAT-DIA-AUX TO WDAT-DIA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_DIA_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

            /*" -526- MOVE WDAT-MES-AUX TO WDAT-MES-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_MES_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

            /*" -528- MOVE WDAT-ANO-AUX TO WDAT-ANO-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_ANO_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

            /*" -529- MOVE V1RELA-MES-REFER TO WSIS-MES. */
            _.Move(V1RELA_MES_REFER, AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES.WSIS_MES);

            /*" -531- MOVE V1RELA-ANO-REFER TO WSIS-ANO. */
            _.Move(V1RELA_ANO_REFER, AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES.WSIS_ANO);

            /*" -533- IF WSIS-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES.WSIS_MES.In("04", "06", "09", "11"))
            {

                /*" -534- MOVE 30 TO WSIS-DIA */
                _.Move(30, AREA_DE_WORK.WSIST_DATA_R.WSIS_DIA);

                /*" -535- ELSE */
            }
            else
            {


                /*" -536- IF WSIS-MES EQUAL 02 */

                if (AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES.WSIS_MES == 02)
                {

                    /*" -539- COMPUTE WRESTO = WSIS-ANO - (WSIS-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES.WSIS_ANO - (AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES.WSIS_ANO / 4 * 4);

                    /*" -540- IF WRESTO EQUAL ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -541- MOVE 29 TO WSIS-DIA */
                        _.Move(29, AREA_DE_WORK.WSIST_DATA_R.WSIS_DIA);

                        /*" -542- ELSE */
                    }
                    else
                    {


                        /*" -543- MOVE 28 TO WSIS-DIA */
                        _.Move(28, AREA_DE_WORK.WSIST_DATA_R.WSIS_DIA);

                        /*" -544- END-IF */
                    }


                    /*" -545- ELSE */
                }
                else
                {


                    /*" -546- MOVE 31 TO WSIS-DIA */
                    _.Move(31, AREA_DE_WORK.WSIST_DATA_R.WSIS_DIA);

                    /*" -547- END-IF */
                }


                /*" -549- END-IF. */
            }


            /*" -550- IF V1SIST-DTMOVABE EQUAL WSIST-DATA */

            if (V1SIST_DTMOVABE == AREA_DE_WORK.WSIST_DATA)
            {

                /*" -551- MOVE WSIST-DATA TO WHOST-DATA-REF */
                _.Move(AREA_DE_WORK.WSIST_DATA, WHOST_DATA_REF);

                /*" -552- DISPLAY 'DATA DE REFERENCIA  - ' WHOST-DATA-REF */
                _.Display($"DATA DE REFERENCIA  - {WHOST_DATA_REF}");

                /*" -553- ELSE */
            }
            else
            {


                /*" -555- DISPLAY 'CB1000B - DATA DO SISTEMA INVALIDA PARA FECHA 'MENTO MENSAL - ' WDATA-EDIT */

                $"CB1000B - DATA DO SISTEMA INVALIDA PARA FECHA MENTOMENSAL-{AREA_DE_WORK.WDATA_EDIT}"
                .Display();

                /*" -556- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -556- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V1RELATORIOS-DB-SELECT-1 */
        public void R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1()
        {
            /*" -508- EXEC SQL SELECT CODRELAT, MES_REFERENCIA, ANO_REFERENCIA INTO :V1RELA-CODRELAT, :V1RELA-MES-REFER, :V1RELA-ANO-REFER FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'CB1000B1' AND SITUACAO = '0' END-EXEC. */

            var r0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RELA_CODRELAT, V1RELA_CODRELAT);
                _.Move(executed_1.V1RELA_MES_REFER, V1RELA_MES_REFER);
                _.Move(executed_1.V1RELA_ANO_REFER, V1RELA_ANO_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DELETE-V0RELATORIOS-SECTION */
        private void R0300_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -569- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -573- PERFORM R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -576- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -577- DISPLAY 'R0300 - ERRO NO DELETE DA V0RELATORIOS' */
                _.Display($"R0300 - ERRO NO DELETE DA V0RELATORIOS");

                /*" -578- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -578- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -573- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CB1000B1' AND SITUACAO = '0' END-EXEC. */

            var r0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r0300_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-SECTION */
        private void R0900_00_DECLARE_V1PARCELA_SECTION()
        {
            /*" -591- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -643- PERFORM R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1 */

            R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1();

            /*" -645- PERFORM R0900_00_DECLARE_V1PARCELA_DB_OPEN_1 */

            R0900_00_DECLARE_V1PARCELA_DB_OPEN_1();

            /*" -648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -649- DISPLAY 'R0900 - ERRO NO DECLARE DA V1PARCELA' */
                _.Display($"R0900 - ERRO NO DECLARE DA V1PARCELA");

                /*" -650- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -650- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1()
        {
            /*" -643- EXEC SQL DECLARE V1PARCELA CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.DACPARC , A.FONTE , A.NRTIT , A.PRM_TARIFARIO_IX , A.VAL_DESCONTO_IX , A.OTNPRLIQ , A.OTNADFRA , A.OTNCUSTO , A.OTNIOF , A.OTNTOTAL , A.OCORHIST , A.QTDDOC , A.SITUACAO , A.COD_EMPRESA , B.DTEMIS , B.DTINIVIG , B.DTTERVIG , B.COD_MOEDA_IMP , B.COD_MOEDA_PRM , B.BCORCAP , B.AGERCAP , B.DACRCAP , B.BCOCOBR , B.AGECOBR , B.DACCOBR FROM SEGUROS.V1PARCELA A, SEGUROS.V1ENDOSSO B WHERE A.SITUACAO = '0' AND A.OTNTOTAL > 0 AND A.TIMESTAMP < :V1SIST-TIMESTAMP AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NRENDOS = A.NRENDOS AND B.DTEMIS <= :WHOST-DATA-REF AND B.RAMO <> 66 AND B.TIPO_ENDOSSO IN ( '0' , '1' , '3' , '5' ) ORDER BY A.NUM_APOLICE, A.NRENDOS, A.NRPARCEL END-EXEC. */
            V1PARCELA = new CB1000B_V1PARCELA(true);
            string GetQuery_V1PARCELA()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.DACPARC
							, 
							A.FONTE
							, 
							A.NRTIT
							, 
							A.PRM_TARIFARIO_IX
							, 
							A.VAL_DESCONTO_IX
							, 
							A.OTNPRLIQ
							, 
							A.OTNADFRA
							, 
							A.OTNCUSTO
							, 
							A.OTNIOF
							, 
							A.OTNTOTAL
							, 
							A.OCORHIST
							, 
							A.QTDDOC
							, 
							A.SITUACAO
							, 
							A.COD_EMPRESA
							, 
							B.DTEMIS
							, 
							B.DTINIVIG
							, 
							B.DTTERVIG
							, 
							B.COD_MOEDA_IMP
							, 
							B.COD_MOEDA_PRM
							, 
							B.BCORCAP
							, 
							B.AGERCAP
							, 
							B.DACRCAP
							, 
							B.BCOCOBR
							, 
							B.AGECOBR
							, 
							B.DACCOBR 
							FROM SEGUROS.V1PARCELA A
							, 
							SEGUROS.V1ENDOSSO B 
							WHERE A.SITUACAO = '0' 
							AND A.OTNTOTAL > 0 
							AND A.TIMESTAMP < '{V1SIST_TIMESTAMP}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NRENDOS = A.NRENDOS 
							AND B.DTEMIS <= '{WHOST_DATA_REF}' 
							AND B.RAMO <> 66 
							AND B.TIPO_ENDOSSO IN ( '0'
							, '1'
							, '3'
							, '5' ) 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL";

                return query;
            }
            V1PARCELA.GetQueryEvent += GetQuery_V1PARCELA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1PARCELA_DB_OPEN_1()
        {
            /*" -645- EXEC SQL OPEN V1PARCELA END-EXEC. */

            V1PARCELA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-V1PARCELA-SECTION */
        private void R0950_00_FETCH_V1PARCELA_SECTION()
        {
            /*" -663- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WABEND.WNR_EXEC_SQL);

            /*" -692- PERFORM R0950_00_FETCH_V1PARCELA_DB_FETCH_1 */

            R0950_00_FETCH_V1PARCELA_DB_FETCH_1();

            /*" -695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -696- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -697- MOVE 'S' TO WFIM-V1PARCELA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                    /*" -697- PERFORM R0950_00_FETCH_V1PARCELA_DB_CLOSE_1 */

                    R0950_00_FETCH_V1PARCELA_DB_CLOSE_1();

                    /*" -699- GO TO R0950-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                    return;

                    /*" -700- ELSE */
                }
                else
                {


                    /*" -701- DISPLAY 'R0950 - ERRO NO FETCH DA V1PARCELA' */
                    _.Display($"R0950 - ERRO NO FETCH DA V1PARCELA");

                    /*" -702- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -703- END-IF */
                }


                /*" -704- ELSE */
            }
            else
            {


                /*" -705- ADD +1 TO AC-L-V1PARCELA */
                AREA_DE_WORK.AC_L_V1PARCELA.Value = AREA_DE_WORK.AC_L_V1PARCELA + +1;

                /*" -707- END-IF. */
            }


            /*" -709- MOVE V1PARC-OCORHIST TO WHOST-OCORHIST. */
            _.Move(V1PARC_OCORHIST, WHOST_OCORHIST);

            /*" -711- ADD +1 TO AC-COUNT. */
            AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + +1;

            /*" -712- IF AC-COUNT GREATER 99999 */

            if (AREA_DE_WORK.AC_COUNT > 99999)
            {

                /*" -713- MOVE +0 TO AC-COUNT */
                _.Move(+0, AREA_DE_WORK.AC_COUNT);

                /*" -714- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -715- MOVE WS-HH-TIME TO WHORA-HH-EDT */
                _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

                /*" -716- MOVE WS-MM-TIME TO WHORA-MM-EDT */
                _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

                /*" -717- MOVE WS-SS-TIME TO WHORA-SS-EDT */
                _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

                /*" -719- DISPLAY AC-L-V1PARCELA ' LIDOS NA V1PARCELA ' WHORA-EDIT */

                $"{AREA_DE_WORK.AC_L_V1PARCELA} LIDOS NA V1PARCELA {AREA_DE_WORK.WHORA_EDIT}"
                .Display();

                /*" -719- END-IF. */
            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-V1PARCELA-DB-FETCH-1 */
        public void R0950_00_FETCH_V1PARCELA_DB_FETCH_1()
        {
            /*" -692- EXEC SQL FETCH V1PARCELA INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNPRLIQ , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO , :V1PARC-OTNIOF , :V1PARC-OTNTOTAL , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO , :V1PARC-COD-EMP:VIND-COD-EMP, :V1ENDO-DTEMIS , :V1ENDO-DTINIVIG , :V1ENDO-DTTERVIG , :V1ENDO-MOEDA-IMP , :V1ENDO-MOEDA-PRM , :V1ENDO-BCORCAP , :V1ENDO-AGERCAP , :V1ENDO-DACRCAP , :V1ENDO-BCOCOBR , :V1ENDO-AGECOBR , :V1ENDO-DACCOBR END-EXEC. */

            if (V1PARCELA.Fetch())
            {
                _.Move(V1PARCELA.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(V1PARCELA.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(V1PARCELA.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(V1PARCELA.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(V1PARCELA.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(V1PARCELA.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(V1PARCELA.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(V1PARCELA.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(V1PARCELA.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(V1PARCELA.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(V1PARCELA.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(V1PARCELA.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(V1PARCELA.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
                _.Move(V1PARCELA.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(V1PARCELA.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(V1PARCELA.V1PARC_SITUACAO, V1PARC_SITUACAO);
                _.Move(V1PARCELA.V1PARC_COD_EMP, V1PARC_COD_EMP);
                _.Move(V1PARCELA.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(V1PARCELA.V1ENDO_DTEMIS, V1ENDO_DTEMIS);
                _.Move(V1PARCELA.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(V1PARCELA.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(V1PARCELA.V1ENDO_MOEDA_IMP, V1ENDO_MOEDA_IMP);
                _.Move(V1PARCELA.V1ENDO_MOEDA_PRM, V1ENDO_MOEDA_PRM);
                _.Move(V1PARCELA.V1ENDO_BCORCAP, V1ENDO_BCORCAP);
                _.Move(V1PARCELA.V1ENDO_AGERCAP, V1ENDO_AGERCAP);
                _.Move(V1PARCELA.V1ENDO_DACRCAP, V1ENDO_DACRCAP);
                _.Move(V1PARCELA.V1ENDO_BCOCOBR, V1ENDO_BCOCOBR);
                _.Move(V1PARCELA.V1ENDO_AGECOBR, V1ENDO_AGECOBR);
                _.Move(V1PARCELA.V1ENDO_DACCOBR, V1ENDO_DACCOBR);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-V1PARCELA-DB-CLOSE-1 */
        public void R0950_00_FETCH_V1PARCELA_DB_CLOSE_1()
        {
            /*" -697- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -732- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -734- PERFORM R2000-00-SELECT-DATA-VENCTO. */

            R2000_00_SELECT_DATA_VENCTO_SECTION();

            /*" -736- MOVE WHOST-DTVENCTO TO WVENCTO-DATA. */
            _.Move(WHOST_DTVENCTO, AREA_DE_WORK.WVENCTO_DATA);

            /*" -738- PERFORM R3000-00-CALCULA-CORRECAO. */

            R3000_00_CALCULA_CORRECAO_SECTION();

            /*" -739- IF W3-VLPRMTOT NOT EQUAL ZEROS */

            if (W3_VLPRMTOT != 00)
            {

                /*" -740- PERFORM R4000-00-MONTA-CORRECAO */

                R4000_00_MONTA_CORRECAO_SECTION();

                /*" -741- PERFORM R5000-00-INSERT-V0HISTOPARC */

                R5000_00_INSERT_V0HISTOPARC_SECTION();

                /*" -743- END-IF. */
            }


            /*" -744- IF W2-VLPRMTOT NOT EQUAL ZEROS */

            if (W2_VLPRMTOT != 00)
            {

                /*" -745- PERFORM R4500-00-MONTA-PENDENTE */

                R4500_00_MONTA_PENDENTE_SECTION();

                /*" -746- PERFORM R5000-00-INSERT-V0HISTOPARC */

                R5000_00_INSERT_V0HISTOPARC_SECTION();

                /*" -748- END-IF. */
            }


            /*" -752- PERFORM R6000-00-UPDATE-V0PARCELA. */

            R6000_00_UPDATE_V0PARCELA_SECTION();

            /*" -752- PERFORM R0950-00-FETCH-V1PARCELA. */

            R0950_00_FETCH_V1PARCELA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-DATA-VENCTO-SECTION */
        private void R2000_00_SELECT_DATA_VENCTO_SECTION()
        {
            /*" -765- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -773- PERFORM R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1 */

            R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1();

            /*" -776- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -777- DISPLAY 'R2000 - ERRO NO SELECT DA V1HISTOPARC' */
                _.Display($"R2000 - ERRO NO SELECT DA V1HISTOPARC");

                /*" -778- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                /*" -779- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                /*" -780- DISPLAY 'NUM PARCL - ' V1PARC-NRPARCEL */
                _.Display($"NUM PARCL - {V1PARC_NRPARCEL}");

                /*" -781- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -781- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-SELECT-DATA-VENCTO-DB-SELECT-1 */
        public void R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1()
        {
            /*" -773- EXEC SQL SELECT DTVENCTO INTO :WHOST-DTVENCTO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL AND OPERACAO BETWEEN 0100 AND 0199 END-EXEC. */

            var r2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1 = new R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1.Execute(r2000_00_SELECT_DATA_VENCTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTVENCTO, WHOST_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CALCULA-CORRECAO-SECTION */
        private void R3000_00_CALCULA_CORRECAO_SECTION()
        {
            /*" -794- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -796- MOVE V1ENDO-DTEMIS TO WEMIS-DATA. */
            _.Move(V1ENDO_DTEMIS, AREA_DE_WORK.WEMIS_DATA);

            /*" -797- IF WEMIS-ANOMES LESS WSIST-ANOMES */

            if (AREA_DE_WORK.WEMIS_DT_R.WEMIS_ANOMES < AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES)
            {

                /*" -798- PERFORM R3100-00-SALDO-ANTERIOR */

                R3100_00_SALDO_ANTERIOR_SECTION();

                /*" -799- GO TO R3000-10-CORRECAO-DOMES */

                R3000_10_CORRECAO_DOMES(); //GOTO
                return;

                /*" -801- END-IF. */
            }


            /*" -802- IF V1ENDO-MOEDA-PRM = 01 */

            if (V1ENDO_MOEDA_PRM == 01)
            {

                /*" -803- MOVE 01,000000000 TO WCOT-MOED-IVG */
                _.Move(01.000000000, AREA_DE_WORK.WCOT_MOED_IVG);

                /*" -804- ELSE */
            }
            else
            {


                /*" -807- IF V1PARC-NUM-APOL = WNUM-APOL-ANT AND V1PARC-NRENDOS = WNUM-ENDS-ANT NEXT SENTENCE */

                if (V1PARC_NUM_APOL == AREA_DE_WORK.WNUM_APOL_ANT && V1PARC_NRENDOS == AREA_DE_WORK.WNUM_ENDS_ANT)
                {

                    /*" -808- ELSE */
                }
                else
                {


                    /*" -809- MOVE V1PARC-NUM-APOL TO WNUM-APOL-ANT */
                    _.Move(V1PARC_NUM_APOL, AREA_DE_WORK.WNUM_APOL_ANT);

                    /*" -810- MOVE V1PARC-NRENDOS TO WNUM-ENDS-ANT */
                    _.Move(V1PARC_NRENDOS, AREA_DE_WORK.WNUM_ENDS_ANT);

                    /*" -811- PERFORM R3500-00-SELECT-V1MOEDA */

                    R3500_00_SELECT_V1MOEDA_SECTION();

                    /*" -812- END-IF */
                }


                /*" -814- END-IF. */
            }


            /*" -817- COMPUTE W1-PRM-TAR ROUNDED = V1PARC-PRM-TAR * WCOT-MOED-IVG. */
            W1_PRM_TAR.Value = V1PARC_PRM_TAR * AREA_DE_WORK.WCOT_MOED_IVG;

            /*" -820- COMPUTE W1-VAL-DES ROUNDED = V1PARC-VAL-DES * WCOT-MOED-IVG. */
            W1_VAL_DES.Value = V1PARC_VAL_DES * AREA_DE_WORK.WCOT_MOED_IVG;

            /*" -823- COMPUTE W1-VLPRMLIQ = W1-PRM-TAR - W1-VAL-DES. */
            W1_VLPRMLIQ.Value = W1_PRM_TAR - W1_VAL_DES;

            /*" -826- COMPUTE W1-VLADIFRA ROUNDED = V1PARC-OTNADFRA * WCOT-MOED-IVG. */
            W1_VLADIFRA.Value = V1PARC_OTNADFRA * AREA_DE_WORK.WCOT_MOED_IVG;

            /*" -829- COMPUTE W1-VLCUSEMI ROUNDED = V1PARC-OTNCUSTO * WCOT-MOED-IVG. */
            W1_VLCUSEMI.Value = V1PARC_OTNCUSTO * AREA_DE_WORK.WCOT_MOED_IVG;

            /*" -832- COMPUTE W1-VLIOCC ROUNDED = V1PARC-OTNIOF * WCOT-MOED-IVG. */
            W1_VLIOCC.Value = V1PARC_OTNIOF * AREA_DE_WORK.WCOT_MOED_IVG;

            /*" -837- COMPUTE W1-VLPRMTOT = W1-VLPRMLIQ + W1-VLADIFRA + W1-VLCUSEMI + W1-VLIOCC. */
            W1_VLPRMTOT.Value = W1_VLPRMLIQ + W1_VLADIFRA + W1_VLCUSEMI + W1_VLIOCC;

            /*" -838- IF WVENCTO-ANOMES < WSIST-ANOMES */

            if (AREA_DE_WORK.WVENCTO_DT_R.WVENCTO_ANOMES < AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES)
            {

                /*" -839- PERFORM R3600-00-MOEDA-VENCIMENTO */

                R3600_00_MOEDA_VENCIMENTO_SECTION();

                /*" -841- COMPUTE W2-PRM-TAR ROUNDED = V1PARC-PRM-TAR * V0COTM-VAL-VNDA */
                W2_PRM_TAR.Value = V1PARC_PRM_TAR * V0COTM_VAL_VNDA;

                /*" -843- COMPUTE W2-VAL-DES ROUNDED = V1PARC-VAL-DES * V0COTM-VAL-VNDA */
                W2_VAL_DES.Value = V1PARC_VAL_DES * V0COTM_VAL_VNDA;

                /*" -845- COMPUTE W2-VLPRMLIQ = W2-PRM-TAR - W2-VAL-DES */
                W2_VLPRMLIQ.Value = W2_PRM_TAR - W2_VAL_DES;

                /*" -847- COMPUTE W2-VLADIFRA ROUNDED = V1PARC-OTNADFRA * V0COTM-VAL-VNDA */
                W2_VLADIFRA.Value = V1PARC_OTNADFRA * V0COTM_VAL_VNDA;

                /*" -849- COMPUTE W2-VLCUSEMI ROUNDED = V1PARC-OTNCUSTO * V0COTM-VAL-VNDA */
                W2_VLCUSEMI.Value = V1PARC_OTNCUSTO * V0COTM_VAL_VNDA;

                /*" -851- COMPUTE W2-VLIOCC ROUNDED = V1PARC-OTNIOF * V0COTM-VAL-VNDA */
                W2_VLIOCC.Value = V1PARC_OTNIOF * V0COTM_VAL_VNDA;

                /*" -855- COMPUTE W2-VLPRMTOT = W2-VLPRMLIQ + W2-VLADIFRA + W2-VLCUSEMI + W2-VLIOCC */
                W2_VLPRMTOT.Value = W2_VLPRMLIQ + W2_VLADIFRA + W2_VLCUSEMI + W2_VLIOCC;

                /*" -856- GO TO R3000-20-RESULT-CORRECAO */

                R3000_20_RESULT_CORRECAO(); //GOTO
                return;

                /*" -856- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_10_CORRECAO_DOMES */

            R3000_10_CORRECAO_DOMES();

        }

        [StopWatch]
        /*" R3000-10-CORRECAO-DOMES */
        private void R3000_10_CORRECAO_DOMES(bool isPerform = false)
        {
            /*" -861- IF WVENCTO-ANOMES > WSIST-ANOMES */

            if (AREA_DE_WORK.WVENCTO_DT_R.WVENCTO_ANOMES > AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES)
            {

                /*" -862- IF V1ENDO-MOEDA-PRM = 01 */

                if (V1ENDO_MOEDA_PRM == 01)
                {

                    /*" -863- MOVE 01,000000000 TO V0COTM-VAL-VNDA */
                    _.Move(01.000000000, V0COTM_VAL_VNDA);

                    /*" -864- ELSE */
                }
                else
                {


                    /*" -865- PERFORM R3700-00-SELECT-V0COTACAO */

                    R3700_00_SELECT_V0COTACAO_SECTION();

                    /*" -866- END-IF */
                }


                /*" -867- ELSE */
            }
            else
            {


                /*" -868- IF WVENCTO-ANOMES = WSIST-ANOMES */

                if (AREA_DE_WORK.WVENCTO_DT_R.WVENCTO_ANOMES == AREA_DE_WORK.WSIST_DATA_R.WSIST_ANOMES)
                {

                    /*" -869- PERFORM R3600-00-MOEDA-VENCIMENTO */

                    R3600_00_MOEDA_VENCIMENTO_SECTION();

                    /*" -870- ELSE */
                }
                else
                {


                    /*" -871- MOVE W1-PRM-TAR TO W2-PRM-TAR */
                    _.Move(W1_PRM_TAR, W2_PRM_TAR);

                    /*" -872- MOVE W1-VAL-DES TO W2-VAL-DES */
                    _.Move(W1_VAL_DES, W2_VAL_DES);

                    /*" -873- MOVE W1-VLPRMLIQ TO W2-VLPRMLIQ */
                    _.Move(W1_VLPRMLIQ, W2_VLPRMLIQ);

                    /*" -874- MOVE W1-VLADIFRA TO W2-VLADIFRA */
                    _.Move(W1_VLADIFRA, W2_VLADIFRA);

                    /*" -875- MOVE W1-VLCUSEMI TO W2-VLCUSEMI */
                    _.Move(W1_VLCUSEMI, W2_VLCUSEMI);

                    /*" -876- MOVE W1-VLIOCC TO W2-VLIOCC */
                    _.Move(W1_VLIOCC, W2_VLIOCC);

                    /*" -877- MOVE W1-VLPRMTOT TO W2-VLPRMTOT */
                    _.Move(W1_VLPRMTOT, W2_VLPRMTOT);

                    /*" -878- GO TO R3000-20-RESULT-CORRECAO */

                    R3000_20_RESULT_CORRECAO(); //GOTO
                    return;

                    /*" -879- END-IF */
                }


                /*" -881- END-IF. */
            }


            /*" -884- COMPUTE W2-PRM-TAR ROUNDED = V1PARC-PRM-TAR * V0COTM-VAL-VNDA. */
            W2_PRM_TAR.Value = V1PARC_PRM_TAR * V0COTM_VAL_VNDA;

            /*" -887- COMPUTE W2-VAL-DES ROUNDED = V1PARC-VAL-DES * V0COTM-VAL-VNDA. */
            W2_VAL_DES.Value = V1PARC_VAL_DES * V0COTM_VAL_VNDA;

            /*" -890- COMPUTE W2-VLPRMLIQ = W2-PRM-TAR - W2-VAL-DES. */
            W2_VLPRMLIQ.Value = W2_PRM_TAR - W2_VAL_DES;

            /*" -893- COMPUTE W2-VLADIFRA ROUNDED = V1PARC-OTNADFRA * V0COTM-VAL-VNDA. */
            W2_VLADIFRA.Value = V1PARC_OTNADFRA * V0COTM_VAL_VNDA;

            /*" -896- COMPUTE W2-VLCUSEMI ROUNDED = V1PARC-OTNCUSTO * V0COTM-VAL-VNDA. */
            W2_VLCUSEMI.Value = V1PARC_OTNCUSTO * V0COTM_VAL_VNDA;

            /*" -899- COMPUTE W2-VLIOCC ROUNDED = V1PARC-OTNIOF * V0COTM-VAL-VNDA. */
            W2_VLIOCC.Value = V1PARC_OTNIOF * V0COTM_VAL_VNDA;

            /*" -902- COMPUTE W2-VLPRMTOT = W2-VLPRMLIQ + W2-VLADIFRA + W2-VLCUSEMI + W2-VLIOCC. */
            W2_VLPRMTOT.Value = W2_VLPRMLIQ + W2_VLADIFRA + W2_VLCUSEMI + W2_VLIOCC;

        }

        [StopWatch]
        /*" R3000-20-RESULT-CORRECAO */
        private void R3000_20_RESULT_CORRECAO(bool isPerform = false)
        {
            /*" -909- COMPUTE W3-PRM-TAR = W2-PRM-TAR - W1-PRM-TAR. */
            W3_PRM_TAR.Value = W2_PRM_TAR - W1_PRM_TAR;

            /*" -912- COMPUTE W3-VAL-DES = W2-VAL-DES - W1-VAL-DES. */
            W3_VAL_DES.Value = W2_VAL_DES - W1_VAL_DES;

            /*" -915- COMPUTE W3-VLPRMLIQ = W2-VLPRMLIQ - W1-VLPRMLIQ. */
            W3_VLPRMLIQ.Value = W2_VLPRMLIQ - W1_VLPRMLIQ;

            /*" -918- COMPUTE W3-VLADIFRA = W2-VLADIFRA - W1-VLADIFRA. */
            W3_VLADIFRA.Value = W2_VLADIFRA - W1_VLADIFRA;

            /*" -921- COMPUTE W3-VLCUSEMI = W2-VLCUSEMI - W1-VLCUSEMI. */
            W3_VLCUSEMI.Value = W2_VLCUSEMI - W1_VLCUSEMI;

            /*" -924- COMPUTE W3-VLIOCC = W2-VLIOCC - W1-VLIOCC. */
            W3_VLIOCC.Value = W2_VLIOCC - W1_VLIOCC;

            /*" -925- COMPUTE W3-VLPRMTOT = W2-VLPRMTOT - W1-VLPRMTOT. */
            W3_VLPRMTOT.Value = W2_VLPRMTOT - W1_VLPRMTOT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SALDO-ANTERIOR-SECTION */
        private void R3100_00_SALDO_ANTERIOR_SECTION()
        {
            /*" -938- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -958- PERFORM R3100_00_SALDO_ANTERIOR_DB_SELECT_1 */

            R3100_00_SALDO_ANTERIOR_DB_SELECT_1();

            /*" -961- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -962- DISPLAY 'R3100 - ERRO NO SELECT DA V1HISTOPARC' */
                _.Display($"R3100 - ERRO NO SELECT DA V1HISTOPARC");

                /*" -963- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                /*" -964- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                /*" -965- DISPLAY 'NUM PARCL - ' V1PARC-NRPARCEL */
                _.Display($"NUM PARCL - {V1PARC_NRPARCEL}");

                /*" -966- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -966- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-SALDO-ANTERIOR-DB-SELECT-1 */
        public void R3100_00_SALDO_ANTERIOR_DB_SELECT_1()
        {
            /*" -958- EXEC SQL SELECT SUM(PRM_TARIFARIO), SUM(VAL_DESCONTO) , SUM(VLPRMLIQ) , SUM(VLADIFRA) , SUM(VLCUSEMI) , SUM(VLIOCC) , SUM(VLPRMTOT) INTO :W1-PRM-TAR , :W1-VAL-DES , :W1-VLPRMLIQ , :W1-VLADIFRA , :W1-VLCUSEMI , :W1-VLIOCC , :W1-VLPRMTOT FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL AND OPERACAO IN (0101,0801) END-EXEC. */

            var r3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1 = new R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1.Execute(r3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1_PRM_TAR, W1_PRM_TAR);
                _.Move(executed_1.W1_VAL_DES, W1_VAL_DES);
                _.Move(executed_1.W1_VLPRMLIQ, W1_VLPRMLIQ);
                _.Move(executed_1.W1_VLADIFRA, W1_VLADIFRA);
                _.Move(executed_1.W1_VLCUSEMI, W1_VLCUSEMI);
                _.Move(executed_1.W1_VLIOCC, W1_VLIOCC);
                _.Move(executed_1.W1_VLPRMTOT, W1_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-SELECT-V1MOEDA-SECTION */
        private void R3500_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -979- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", WABEND.WNR_EXEC_SQL);

            /*" -987- PERFORM R3500_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R3500_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -990- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -991- DISPLAY 'R3500 - ERRO NO SELECT DA V1MOEDA' */
                _.Display($"R3500 - ERRO NO SELECT DA V1MOEDA");

                /*" -992- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                /*" -993- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                /*" -994- DISPLAY 'COD MOEDA - ' V1ENDO-MOEDA-PRM */
                _.Display($"COD MOEDA - {V1ENDO_MOEDA_PRM}");

                /*" -995- DISPLAY 'INIC VIGC - ' V1ENDO-DTINIVIG */
                _.Display($"INIC VIGC - {V1ENDO_DTINIVIG}");

                /*" -996- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -997- ELSE */
            }
            else
            {


                /*" -998- MOVE V0COTM-VAL-VNDA TO WCOT-MOED-IVG */
                _.Move(V0COTM_VAL_VNDA, AREA_DE_WORK.WCOT_MOED_IVG);

                /*" -998- END-IF. */
            }


        }

        [StopWatch]
        /*" R3500-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R3500_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -987- EXEC SQL SELECT VAL_VENDA INTO :V0COTM-VAL-VNDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1ENDO-MOEDA-PRM AND DTINIVIG <= :V1ENDO-DTINIVIG AND DTTERVIG >= :V1ENDO-DTINIVIG WITH UR END-EXEC. */

            var r3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                V1ENDO_MOEDA_PRM = V1ENDO_MOEDA_PRM.ToString(),
                V1ENDO_DTINIVIG = V1ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r3500_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTM_VAL_VNDA, V0COTM_VAL_VNDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-MOEDA-VENCIMENTO-SECTION */
        private void R3600_00_MOEDA_VENCIMENTO_SECTION()
        {
            /*" -1011- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", WABEND.WNR_EXEC_SQL);

            /*" -1019- PERFORM R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1 */

            R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1();

            /*" -1022- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1023- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1024- DISPLAY 'R3600 - COTACAO DA MOEDA NAO CADASTRADA' */
                    _.Display($"R3600 - COTACAO DA MOEDA NAO CADASTRADA");

                    /*" -1025- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                    _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                    /*" -1026- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                    _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                    /*" -1027- DISPLAY 'COD MOEDA - ' V1ENDO-MOEDA-PRM */
                    _.Display($"COD MOEDA - {V1ENDO_MOEDA_PRM}");

                    /*" -1028- DISPLAY 'DAT VENCT - ' WHOST-DTVENCTO */
                    _.Display($"DAT VENCT - {WHOST_DTVENCTO}");

                    /*" -1029- IF V1ENDO-MOEDA-PRM = 01 */

                    if (V1ENDO_MOEDA_PRM == 01)
                    {

                        /*" -1030- MOVE 01,000000000 TO V0COTM-VAL-VNDA */
                        _.Move(01.000000000, V0COTM_VAL_VNDA);

                        /*" -1031- ELSE */
                    }
                    else
                    {


                        /*" -1032- PERFORM R3700-00-SELECT-V0COTACAO */

                        R3700_00_SELECT_V0COTACAO_SECTION();

                        /*" -1033- END-IF */
                    }


                    /*" -1034- ELSE */
                }
                else
                {


                    /*" -1035- DISPLAY 'R3600 - ERRO NO SELECT NA V1MOEDA' */
                    _.Display($"R3600 - ERRO NO SELECT NA V1MOEDA");

                    /*" -1036- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                    _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                    /*" -1037- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                    _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                    /*" -1038- DISPLAY 'COD MOEDA - ' V1ENDO-MOEDA-PRM */
                    _.Display($"COD MOEDA - {V1ENDO_MOEDA_PRM}");

                    /*" -1039- DISPLAY 'DAT VENCT - ' WHOST-DTVENCTO */
                    _.Display($"DAT VENCT - {WHOST_DTVENCTO}");

                    /*" -1040- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1041- END-IF */
                }


                /*" -1041- END-IF. */
            }


        }

        [StopWatch]
        /*" R3600-00-MOEDA-VENCIMENTO-DB-SELECT-1 */
        public void R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1()
        {
            /*" -1019- EXEC SQL SELECT VAL_VENDA INTO :V0COTM-VAL-VNDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1ENDO-MOEDA-PRM AND DTINIVIG <= :WHOST-DTVENCTO AND DTTERVIG >= :WHOST-DTVENCTO WITH UR END-EXEC. */

            var r3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1 = new R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1()
            {
                V1ENDO_MOEDA_PRM = V1ENDO_MOEDA_PRM.ToString(),
                WHOST_DTVENCTO = WHOST_DTVENCTO.ToString(),
            };

            var executed_1 = R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1.Execute(r3600_00_MOEDA_VENCIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTM_VAL_VNDA, V0COTM_VAL_VNDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-SELECT-V0COTACAO-SECTION */
        private void R3700_00_SELECT_V0COTACAO_SECTION()
        {
            /*" -1054- MOVE '3700' TO WNR-EXEC-SQL. */
            _.Move("3700", WABEND.WNR_EXEC_SQL);

            /*" -1062- PERFORM R3700_00_SELECT_V0COTACAO_DB_SELECT_1 */

            R3700_00_SELECT_V0COTACAO_DB_SELECT_1();

            /*" -1065- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1066- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1067- MOVE ZEROS TO V0COTM-VAL-VNDA */
                    _.Move(0, V0COTM_VAL_VNDA);

                    /*" -1068- ELSE */
                }
                else
                {


                    /*" -1069- DISPLAY 'R3700 - ERRO NO SELECT DA V0COTACAO' */
                    _.Display($"R3700 - ERRO NO SELECT DA V0COTACAO");

                    /*" -1070- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                    _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                    /*" -1071- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                    _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                    /*" -1072- DISPLAY 'COD MOEDA - ' V1ENDO-MOEDA-PRM */
                    _.Display($"COD MOEDA - {V1ENDO_MOEDA_PRM}");

                    /*" -1073- DISPLAY 'DAT REFER - ' V1SIST-DTMOVABE */
                    _.Display($"DAT REFER - {V1SIST_DTMOVABE}");

                    /*" -1074- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1075- END-IF */
                }


                /*" -1075- END-IF. */
            }


        }

        [StopWatch]
        /*" R3700-00-SELECT-V0COTACAO-DB-SELECT-1 */
        public void R3700_00_SELECT_V0COTACAO_DB_SELECT_1()
        {
            /*" -1062- EXEC SQL SELECT VAL_VENDA INTO :V0COTM-VAL-VNDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1ENDO-MOEDA-PRM AND DTINIVIG <= :V1SIST-DTMOVABE AND DTTERVIG >= :V1SIST-DTMOVABE WITH UR END-EXEC. */

            var r3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 = new R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1()
            {
                V1ENDO_MOEDA_PRM = V1ENDO_MOEDA_PRM.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1.Execute(r3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTM_VAL_VNDA, V0COTM_VAL_VNDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-MONTA-CORRECAO-SECTION */
        private void R4000_00_MONTA_CORRECAO_SECTION()
        {
            /*" -1088- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -1089- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL. */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -1090- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS. */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -1091- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL. */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -1092- MOVE V1PARC-DACPARC TO V0HISP-DACPARC. */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -1093- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -1095- MOVE 0801 TO V0HISP-OPERACAO. */
            _.Move(0801, V0HISP_OPERACAO);

            /*" -1096- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1097- MOVE WS-HH-TIME TO WTIME-HORA. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_HORA);

            /*" -1098- MOVE '.' TO WTIME-2PT1. */
            _.Move(".", AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_2PT1);

            /*" -1099- MOVE WS-MM-TIME TO WTIME-MINU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_MINU);

            /*" -1100- MOVE '.' TO WTIME-2PT2. */
            _.Move(".", AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_2PT2);

            /*" -1101- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_SEGU);

            /*" -1103- MOVE WTIME-DAYR TO V0HISP-HORAOPER. */
            _.Move(AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -1104- ADD +1 TO WHOST-OCORHIST. */
            WHOST_OCORHIST.Value = WHOST_OCORHIST + +1;

            /*" -1106- MOVE WHOST-OCORHIST TO V0HISP-OCORHIST. */
            _.Move(WHOST_OCORHIST, V0HISP_OCORHIST);

            /*" -1107- MOVE W3-PRM-TAR TO V0HISP-PRM-TAR. */
            _.Move(W3_PRM_TAR, V0HISP_PRM_TAR);

            /*" -1108- MOVE W3-VAL-DES TO V0HISP-VAL-DESC. */
            _.Move(W3_VAL_DES, V0HISP_VAL_DESC);

            /*" -1109- MOVE W3-VLPRMLIQ TO V0HISP-VLPRMLIQ. */
            _.Move(W3_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -1110- MOVE W3-VLADIFRA TO V0HISP-VLADIFRA. */
            _.Move(W3_VLADIFRA, V0HISP_VLADIFRA);

            /*" -1111- MOVE W3-VLCUSEMI TO V0HISP-VLCUSEMI. */
            _.Move(W3_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -1113- MOVE W3-VLIOCC TO V0HISP-VLIOCC. */
            _.Move(W3_VLIOCC, V0HISP_VLIOCC);

            /*" -1116- MOVE W3-VLPRMTOT TO V0HISP-VLPRMTOT V0HISP-VLPREMIO. */
            _.Move(W3_VLPRMTOT, V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -1117- MOVE WHOST-DTVENCTO TO V0HISP-DTVENCTO. */
            _.Move(WHOST_DTVENCTO, V0HISP_DTVENCTO);

            /*" -1118- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR. */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -1119- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR. */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -1120- MOVE ZEROS TO V0HISP-NRAVISO. */
            _.Move(0, V0HISP_NRAVISO);

            /*" -1121- MOVE ZEROS TO V0HISP-NRENDOCA. */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -1124- MOVE '0' TO V0HISP-SITCONTB. */
            _.Move("0", V0HISP_SITCONTB);

            /*" -1126- MOVE 'CB1000B' TO V0HISP-COD-USUR. */
            _.Move("CB1000B", V0HISP_COD_USUR);

            /*" -1128- MOVE ZEROS TO V0HISP-RNUDOC. */
            _.Move(0, V0HISP_RNUDOC);

            /*" -1129- MOVE SPACES TO V0HISP-DTQITBCO. */
            _.Move("", V0HISP_DTQITBCO);

            /*" -1131- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1131- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPR. */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-MONTA-PENDENTE-SECTION */
        private void R4500_00_MONTA_PENDENTE_SECTION()
        {
            /*" -1144- MOVE '4500' TO WNR-EXEC-SQL. */
            _.Move("4500", WABEND.WNR_EXEC_SQL);

            /*" -1145- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL. */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -1146- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS. */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -1147- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL. */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -1148- MOVE V1PARC-DACPARC TO V0HISP-DACPARC. */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -1149- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -1151- MOVE 1000 TO V0HISP-OPERACAO. */
            _.Move(1000, V0HISP_OPERACAO);

            /*" -1152- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1153- MOVE WS-HH-TIME TO WTIME-HORA. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_HORA);

            /*" -1154- MOVE '.' TO WTIME-2PT1. */
            _.Move(".", AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_2PT1);

            /*" -1155- MOVE WS-MM-TIME TO WTIME-MINU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_MINU);

            /*" -1156- MOVE '.' TO WTIME-2PT2. */
            _.Move(".", AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_2PT2);

            /*" -1157- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR.WTIME_SEGU);

            /*" -1159- MOVE WTIME-DAYR TO V0HISP-HORAOPER. */
            _.Move(AREA_DE_WORK.WTIME_DAY_R.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -1160- ADD +1 TO WHOST-OCORHIST. */
            WHOST_OCORHIST.Value = WHOST_OCORHIST + +1;

            /*" -1162- MOVE WHOST-OCORHIST TO V0HISP-OCORHIST. */
            _.Move(WHOST_OCORHIST, V0HISP_OCORHIST);

            /*" -1163- MOVE W2-PRM-TAR TO V0HISP-PRM-TAR. */
            _.Move(W2_PRM_TAR, V0HISP_PRM_TAR);

            /*" -1164- MOVE W2-VAL-DES TO V0HISP-VAL-DESC. */
            _.Move(W2_VAL_DES, V0HISP_VAL_DESC);

            /*" -1165- MOVE W2-VLPRMLIQ TO V0HISP-VLPRMLIQ. */
            _.Move(W2_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -1166- MOVE W2-VLADIFRA TO V0HISP-VLADIFRA. */
            _.Move(W2_VLADIFRA, V0HISP_VLADIFRA);

            /*" -1167- MOVE W2-VLCUSEMI TO V0HISP-VLCUSEMI. */
            _.Move(W2_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -1169- MOVE W2-VLIOCC TO V0HISP-VLIOCC. */
            _.Move(W2_VLIOCC, V0HISP_VLIOCC);

            /*" -1172- MOVE W2-VLPRMTOT TO V0HISP-VLPRMTOT V0HISP-VLPREMIO. */
            _.Move(W2_VLPRMTOT, V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -1173- MOVE WHOST-DTVENCTO TO V0HISP-DTVENCTO. */
            _.Move(WHOST_DTVENCTO, V0HISP_DTVENCTO);

            /*" -1174- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR. */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -1175- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR. */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -1176- MOVE ZEROS TO V0HISP-NRAVISO. */
            _.Move(0, V0HISP_NRAVISO);

            /*" -1177- MOVE ZEROS TO V0HISP-NRENDOCA. */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -1180- MOVE '0' TO V0HISP-SITCONTB. */
            _.Move("0", V0HISP_SITCONTB);

            /*" -1182- MOVE 'CB1000B' TO V0HISP-COD-USUR. */
            _.Move("CB1000B", V0HISP_COD_USUR);

            /*" -1184- MOVE ZEROS TO V0HISP-RNUDOC. */
            _.Move(0, V0HISP_RNUDOC);

            /*" -1185- MOVE SPACES TO V0HISP-DTQITBCO. */
            _.Move("", V0HISP_DTQITBCO);

            /*" -1187- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1187- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPR. */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERT-V0HISTOPARC-SECTION */
        private void R5000_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -1200- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", WABEND.WNR_EXEC_SQL);

            /*" -1229- PERFORM R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -1232- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1233- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1234- DISPLAY 'R5000 - REGISTRO DUPLICADO NA V0HISTOPARC' */
                    _.Display($"R5000 - REGISTRO DUPLICADO NA V0HISTOPARC");

                    /*" -1235- DISPLAY 'NUM APOLC - ' V0HISP-NUM-APOL */
                    _.Display($"NUM APOLC - {V0HISP_NUM_APOL}");

                    /*" -1236- DISPLAY 'NUM ENDOS - ' V0HISP-NRENDOS */
                    _.Display($"NUM ENDOS - {V0HISP_NRENDOS}");

                    /*" -1237- DISPLAY 'NUM PARCL - ' V0HISP-NRPARCEL */
                    _.Display($"NUM PARCL - {V0HISP_NRPARCEL}");

                    /*" -1238- DISPLAY 'OCR HISTR - ' V0HISP-OCORHIST */
                    _.Display($"OCR HISTR - {V0HISP_OCORHIST}");

                    /*" -1239- GO TO R5000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/ //GOTO
                    return;

                    /*" -1240- ELSE */
                }
                else
                {


                    /*" -1241- DISPLAY 'R5000 - ERRO NO INSERT DA V0HISTOPARC' */
                    _.Display($"R5000 - ERRO NO INSERT DA V0HISTOPARC");

                    /*" -1242- DISPLAY 'NUM APOLC - ' V0HISP-NUM-APOL */
                    _.Display($"NUM APOLC - {V0HISP_NUM_APOL}");

                    /*" -1243- DISPLAY 'NUM ENDOS - ' V0HISP-NRENDOS */
                    _.Display($"NUM ENDOS - {V0HISP_NRENDOS}");

                    /*" -1244- DISPLAY 'NUM PARCL - ' V0HISP-NRPARCEL */
                    _.Display($"NUM PARCL - {V0HISP_NRPARCEL}");

                    /*" -1245- DISPLAY 'OCR HISTR - ' V0HISP-OCORHIST */
                    _.Display($"OCR HISTR - {V0HISP_OCORHIST}");

                    /*" -1246- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1247- END-IF */
                }


                /*" -1248- ELSE */
            }
            else
            {


                /*" -1249- IF V0HISP-OPERACAO = 0801 */

                if (V0HISP_OPERACAO == 0801)
                {

                    /*" -1250- ADD +1 TO AC-C-V0HISTOPARC */
                    AREA_DE_WORK.AC_C_V0HISTOPARC.Value = AREA_DE_WORK.AC_C_V0HISTOPARC + +1;

                    /*" -1251- ELSE */
                }
                else
                {


                    /*" -1252- ADD +1 TO AC-P-V0HISTOPARC */
                    AREA_DE_WORK.AC_P_V0HISTOPARC.Value = AREA_DE_WORK.AC_P_V0HISTOPARC + +1;

                    /*" -1253- END-IF */
                }


                /*" -1253- END-IF. */
            }


        }

        [StopWatch]
        /*" R5000-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -1229- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TAR , :V0HISP-VAL-DESC , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO, :V0HISP-COD-EMPR, CURRENT TIMESTAMP) END-EXEC. */

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
                V0HISP_COD_USUR = V0HISP_COD_USUR.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPR = V0HISP_COD_EMPR.ToString(),
            };

            R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-UPDATE-V0PARCELA-SECTION */
        private void R6000_00_UPDATE_V0PARCELA_SECTION()
        {
            /*" -1266- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", WABEND.WNR_EXEC_SQL);

            /*" -1273- PERFORM R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -1276- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1277- DISPLAY 'R6000 - ERRO NO UPDATE DA V0PARCELA' */
                _.Display($"R6000 - ERRO NO UPDATE DA V0PARCELA");

                /*" -1278- DISPLAY 'NUM APOLC - ' V1PARC-NUM-APOL */
                _.Display($"NUM APOLC - {V1PARC_NUM_APOL}");

                /*" -1279- DISPLAY 'NUM ENDOS - ' V1PARC-NRENDOS */
                _.Display($"NUM ENDOS - {V1PARC_NRENDOS}");

                /*" -1280- DISPLAY 'NUM PARCL - ' V1PARC-NRPARCEL */
                _.Display($"NUM PARCL - {V1PARC_NRPARCEL}");

                /*" -1281- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1282- ELSE */
            }
            else
            {


                /*" -1283- ADD +1 TO AC-P-V1PARCELA */
                AREA_DE_WORK.AC_P_V1PARCELA.Value = AREA_DE_WORK.AC_P_V1PARCELA + +1;

                /*" -1283- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-00-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -1273- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = :WHOST-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL END-EXEC. */

            var r6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WHOST_OCORHIST = WHOST_OCORHIST.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1297- MOVE V1SIST-DTMOVABE TO WDATA-AUX. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_AUX);

            /*" -1298- MOVE WDAT-DIA-AUX TO WDAT-DIA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_DIA_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

            /*" -1299- MOVE WDAT-MES-AUX TO WDAT-MES-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_MES_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

            /*" -1301- MOVE WDAT-ANO-AUX TO WDAT-ANO-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_ANO_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

            /*" -1302- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1303- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1304- DISPLAY '*   CB1000B - FECHAMENTO MENSAL COBRANCA   *' . */
            _.Display($"*   CB1000B - FECHAMENTO MENSAL COBRANCA   *");

            /*" -1305- DISPLAY '*   -------   ---------- ------ --------   *' . */
            _.Display($"*   -------   ---------- ------ --------   *");

            /*" -1306- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1307- DISPLAY '*   NAO HOUVE MOVIMENTACAO DE PARCELAS     *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO DE PARCELAS     *");

            /*" -1309- DISPLAY '*   NESTA DATA ' WDATA-EDIT '                    *' . */

            $"*   NESTA DATA {AREA_DE_WORK.WDATA_EDIT}                    *"
            .Display();

            /*" -1310- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1310- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1325- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1327- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1327- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1329- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1333- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1333- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}