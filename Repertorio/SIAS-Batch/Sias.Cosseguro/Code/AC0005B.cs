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
using Sias.Cosseguro.DB2.AC0005B;

namespace Code
{
    public class AC0005B
    {
        public bool IsCall { get; set; }

        public AC0005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  ALEXANDRE BURGOS                   *      */
        /*"      *   PROGRAMADOR ............  ALEXANDRE BURGOS                   *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO/1993                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZAR DB DE COSSEGURO ACEITO   *      */
        /*"      *                             (CARREGAMENTO DAS TABELAS          *      */
        /*"      *                              V0COSSEG_PREM E V0COSSEG_HISTPRE) *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         INPUT    *      */
        /*"      * COSSEGURO ACEITO                    V0COSSEGACE       INPUT    *      */
        /*"      * PARCELAS                            V0PARCELA         INPUT    *      */
        /*"      * PREMIOS DE COSSEGURO                V0COSSEG_PREM     I-O      *      */
        /*"      * HISTORICO DE COSSEGURO              V0COSSEG_HISTPRE  OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 03/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DAT-QTBC        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DAT_QTBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OCR-HIST        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_OCR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-FINC        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-LIBR        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-OCOR        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-COUNT          PIC S9(009)               COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-OCORHIST       PIC S9(004)               COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-SITUACAO       PIC  X(001).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WHOST-SITCONG        PIC  X(001).*/
        public StringBasis WHOST_SITCONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SIST-DTMOVABE      PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-OCORHIST      PIC S9(004)               COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-OPERACAO      PIC S9(004)               COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DTMOVTO       PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-PRM-TAR       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VAL-DESC      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VLPRMLIQ      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VLADIFRA      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VLCUSEMI      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VLIOCC        PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VLPRMTOT      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-VLPREMIO      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-DTVENCTO      PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-BCOCOBR       PIC S9(004)               COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-AGECOBR       PIC S9(004)               COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-NRAVISO       PIC S9(009)               COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRENDOCA      PIC S9(009)               COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-DTQITBCO      PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-DTINIVIG      PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG      PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CORRECAO      PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COSC-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0COSC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COSC-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0COSC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COSC-ORDLIDER      PIC S9(015)               COMP-3*/
        public IntBasis V0COSC_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0COSC-CODLIDER      PIC S9(004)               COMP.*/
        public IntBasis V0COSC_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COSC-TPPARTIC      PIC  X(001).*/
        public StringBasis V0COSC_TPPARTIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COSC-PCPARTIC      PIC S9(004)V9(5)          COMP-3*/
        public DoubleBasis V0COSC_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0COSC-PCCOMCOS      PIC S9(003)V99            COMP-3*/
        public DoubleBasis V0COSC_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0COSC-APOLIDER      PIC  X(015).*/
        public StringBasis V0COSC_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0COSC-ENDOSLID      PIC  X(015).*/
        public StringBasis V0COSC_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0COSC-DTEMILID      PIC  X(010).*/
        public StringBasis V0COSC_DTEMILID { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COSC-PCADMCOS      PIC S9(003)V99            COMP-3*/
        public DoubleBasis V0COSC_PCADMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0COSC-SITUACAO      PIC  X(001).*/
        public StringBasis V0COSC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-DACPARC       PIC  X(001).*/
        public StringBasis V0PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-FONTE         PIC S9(004)               COMP.*/
        public IntBasis V0PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-NRTIT         PIC S9(013)               COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-PRM-TAR       PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-VAL-DESC      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNPRLIQ      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNADFRA      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNCUSTO      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNIOF        PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OTNTOTAL      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-OCORHIST      PIC S9(004)               COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-QTDDOC        PIC S9(004)               COMP.*/
        public IntBasis V0PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-SITUACAO      PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HISP-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-OCORHIST      PIC S9(004)               COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-OPERACAO      PIC S9(004)               COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DTMOVTO       PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-PRM-TAR       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VAL-DESC      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VLPRMLIQ      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VLADIFRA      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VLCUSEMI      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VLIOCC        PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VLPRMTOT      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-VLPREMIO      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V1HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HISP-DTVENCTO      PIC  X(010).*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-BCOCOBR       PIC S9(004)               COMP.*/
        public IntBasis V1HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-AGECOBR       PIC S9(004)               COMP.*/
        public IntBasis V1HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-NRAVISO       PIC S9(009)               COMP.*/
        public IntBasis V1HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRENDOCA      PIC S9(009)               COMP.*/
        public IntBasis V1HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-DTQITBCO      PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PARC-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-DACPARC       PIC  X(001).*/
        public StringBasis V1PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-FONTE         PIC S9(004)               COMP.*/
        public IntBasis V1PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-NRTIT         PIC S9(013)               COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-PRM-TAR       PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-VAL-DESC      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNPRLIQ      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNADFRA      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNCUSTO      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNIOF        PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNTOTAL      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V1PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OCORHIST      PIC S9(004)               COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-QTDDOC        PIC S9(004)               COMP.*/
        public IntBasis V1PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-SITUACAO      PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-COD-EMP       PIC S9(009)               COMP.*/
        public IntBasis V0CPRE_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CPRE-TIPSGU        PIC  X(001).*/
        public StringBasis V0CPRE_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-CONGENER      PIC S9(004)               COMP.*/
        public IntBasis V0CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CPRE-NUM-ORDEM     PIC S9(015)               COMP-3*/
        public IntBasis V0CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CPRE-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0CPRE-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0CPRE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CPRE-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CPRE-PRM-TAR-IX    PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0CPRE_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0CPRE-VAL-DES-IX    PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0CPRE_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0CPRE-OTNPRLIQ      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0CPRE-OTNADFRA      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0CPRE-VLCOMISIX     PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0CPRE_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0CPRE-OTNTOTAL      PIC S9(010)V9(5)          COMP-3*/
        public DoubleBasis V0CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0CPRE-SITUACAO      PIC  X(001).*/
        public StringBasis V0CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-SIT-CONG      PIC  X(001).*/
        public StringBasis V0CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0CPRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0CPRE-OCORHIST      PIC S9(004)               COMP.*/
        public IntBasis V0CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-COD-EMP       PIC S9(009)               COMP.*/
        public IntBasis V0CHIS_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHIS-CONGENER      PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0CHIS-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHIS-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-OCORHIST      PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-OPERACAO      PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-DTMOVTO       PIC  X(010).*/
        public StringBasis V0CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHIS-TIPSGU        PIC  X(001).*/
        public StringBasis V0CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-PRM-TAR       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VAL-DESC      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0CHIS_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLPRMLIQ      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLADIFRA      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLCOMIS       PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLPRMTOT      PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0CHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0CHIS-DTQITBCO      PIC  X(010).*/
        public StringBasis V0CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHIS-SIT-FINANC    PIC  X(001).*/
        public StringBasis V0CHIS_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-SIT-LIBRECUP  PIC  X(001).*/
        public StringBasis V0CHIS_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-NUMOCOR       PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         AREA-DE-WORK.*/
        public AC0005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0005B_AREA_DE_WORK();
        public class AC0005B_AREA_DE_WORK : VarBasis
        {
            /*"  05       WFIM-V0HISTOPARC     PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V0HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WFIM-V1HISTOPARC     PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       AC-COUNT             PIC  9(004)      VALUE ZEROS.*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       AC-L-V0HISTOPARC     PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-L-V1HISTOPARC     PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_V1HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-V0COSSEGPREM    PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-V0COSSEGHISP    PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGHISP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-U-V0COSSEGPREM    PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_U_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       WOPERACAO            PIC  9(004)      VALUE ZEROS.*/
            public IntBasis WOPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       FILLER               REDEFINES        WOPERACAO.*/
            private _REDEF_AC0005B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_AC0005B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_AC0005B_FILLER_0(); _.Move(WOPERACAO, _filler_0); VarBasis.RedefinePassValue(WOPERACAO, _filler_0, WOPERACAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WOPERACAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WOPERACAO); }
            }  //Redefines
            public class _REDEF_AC0005B_FILLER_0 : VarBasis
            {
                /*"    10     WTIPO-OPERACAO       PIC  9(002).*/
                public IntBasis WTIPO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10     WSEQC-OPERACAO       PIC  9(002).*/
                public IntBasis WSEQC_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WULTM-NUMOCOR        PIC S9(004)      VALUE +0 COMP.*/

                public _REDEF_AC0005B_FILLER_0()
                {
                    WTIPO_OPERACAO.ValueChanged += OnValueChanged;
                    WSEQC_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WULTM_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WTOTAL               PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WCOMISSAO            PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WCOMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WTOTAL-IX            PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WTOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WCOMISSAO-IX         PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WCOMISSAO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WPRM-TOT             PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLRCOMIS            PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WVLRCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRM-TOT-IX          PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TOT_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WVLRCOMIS-IX         PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WVLRCOMIS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WHORA-ACCEPT.*/
            public AC0005B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0005B_WHORA_ACCEPT();
            public class AC0005B_WHORA_ACCEPT : VarBasis
            {
                /*"    10     WHH-ACCEPT           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WMM-ACCEPT           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WSS-ACCEPT           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WCC-ACCEPT           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WHORA-CABEC.*/
            }
            public AC0005B_WHORA_CABEC WHORA_CABEC { get; set; } = new AC0005B_WHORA_CABEC();
            public class AC0005B_WHORA_CABEC : VarBasis
            {
                /*"    10     WHORA-HH-CABEC       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER               PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WHORA-MM-CABEC       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER               PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WHORA-SS-CABEC       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WDATA-AUX            PIC  X(010)      VALUE SPACES.*/
            }
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WDATA-AUX-R          REDEFINES        WDATA-AUX.*/
            private _REDEF_AC0005B_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_AC0005B_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_AC0005B_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_AC0005B_WDATA_AUX_R : VarBasis
            {
                /*"    10     WDATA-ANO-AUX        PIC  9(004).*/
                public IntBasis WDATA_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10     FILLER               PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10     WDATA-MES-AUX        PIC  9(002).*/
                public IntBasis WDATA_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10     FILLER               PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10     WDATA-DIA-AUX        PIC  9(002).*/
                public IntBasis WDATA_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WDATA-EDIT.*/

                public _REDEF_AC0005B_WDATA_AUX_R()
                {
                    WDATA_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDATA_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public AC0005B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0005B_WDATA_EDIT();
            public class AC0005B_WDATA_EDIT : VarBasis
            {
                /*"    10     WDATA-DIA-EDT        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10     WDATA-MES-EDT        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10     WDATA-ANO-EDT        PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDATA_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"01         WABEND.*/
            }
        }
        public AC0005B_WABEND WABEND { get; set; } = new AC0005B_WABEND();
        public class AC0005B_WABEND : VarBasis
        {
            /*"  05       FILLER               PIC  X(010)      VALUE          ' AC0005B'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0005B");
            /*"  05       FILLER               PIC  X(026)      VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05       WNR-EXEC-SQL         PIC  X(003)      VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05       FILLER               PIC  X(013)      VALUE          ' *** SQLCODE '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05       WSQLCODE             PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public AC0005B_V0HISTOPARC V0HISTOPARC { get; set; } = new AC0005B_V0HISTOPARC();
        public AC0005B_V1HISTOPARC V1HISTOPARC { get; set; } = new AC0005B_V1HISTOPARC();
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
            /*" -380- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -381- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -384- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -387- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -391- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -393- PERFORM R0200-00-CHECA-EXECUCAO. */

            R0200_00_CHECA_EXECUCAO_SECTION();

            /*" -394- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -395- MOVE WHH-ACCEPT TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -396- MOVE WMM-ACCEPT TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -398- MOVE WSS-ACCEPT TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -400- DISPLAY 'INICIO DECLARE V0HISTOPARC - ' WHORA-CABEC. */
            _.Display($"INICIO DECLARE V0HISTOPARC - {AREA_DE_WORK.WHORA_CABEC}");

            /*" -402- PERFORM R0500-00-DECLARE-V0HISTOPARC. */

            R0500_00_DECLARE_V0HISTOPARC_SECTION();

            /*" -403- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -404- MOVE WHH-ACCEPT TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -405- MOVE WMM-ACCEPT TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -407- MOVE WSS-ACCEPT TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -409- DISPLAY 'FINAL  DECLARE V0HISTOPARC - ' WHORA-CABEC */
            _.Display($"FINAL  DECLARE V0HISTOPARC - {AREA_DE_WORK.WHORA_CABEC}");

            /*" -411- PERFORM R0700-00-FETCH-V0HISTOPARC. */

            R0700_00_FETCH_V0HISTOPARC_SECTION();

            /*" -412- IF WFIM-V0HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty())
            {

                /*" -413- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -414- ELSE */
            }
            else
            {


                /*" -415- PERFORM R0800-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty()))
                {

                    R0800_00_PROCESSA_REGISTRO_SECTION();
                }
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -420- DISPLAY 'HISTORICOS   LIDOS         - ' AC-L-V0HISTOPARC. */
            _.Display($"HISTORICOS   LIDOS         - {AREA_DE_WORK.AC_L_V0HISTOPARC}");

            /*" -421- DISPLAY 'HISTORICOS   INTEGRADOS    - ' AC-L-V1HISTOPARC. */
            _.Display($"HISTORICOS   INTEGRADOS    - {AREA_DE_WORK.AC_L_V1HISTOPARC}");

            /*" -422- DISPLAY 'DOCUMENTOS   INSERIDOS :     ' . */
            _.Display($"DOCUMENTOS   INSERIDOS :     ");

            /*" -423- DISPLAY '. PREMIOS    COSSEGURO     - ' AC-I-V0COSSEGPREM. */
            _.Display($". PREMIOS    COSSEGURO     - {AREA_DE_WORK.AC_I_V0COSSEGPREM}");

            /*" -424- DISPLAY '. HISTORICOS COSSEGURO     - ' AC-I-V0COSSEGHISP. */
            _.Display($". HISTORICOS COSSEGURO     - {AREA_DE_WORK.AC_I_V0COSSEGHISP}");

            /*" -426- DISPLAY 'PREMIOS COSSEG ATUALIZADOS - ' AC-U-V0COSSEGPREM. */
            _.Display($"PREMIOS COSSEG ATUALIZADOS - {AREA_DE_WORK.AC_U_V0COSSEGPREM}");

            /*" -426- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -430- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -430- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -443- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -448- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -452- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA - AC' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA - AC");

                /*" -453- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -454- ELSE */
            }
            else
            {


                /*" -454- DISPLAY 'DATA DO MOVIMENTO - ' V0SIST-DTMOVABE. */
                _.Display($"DATA DO MOVIMENTO - {V0SIST_DTMOVABE}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -448- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-SECTION */
        private void R0200_00_CHECA_EXECUCAO_SECTION()
        {
            /*" -467- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -474- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -477- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -478- DISPLAY 'R0200 - ERRO NO SELECT DA V1COSSEG-HISTPRE' */
                _.Display($"R0200 - ERRO NO SELECT DA V1COSSEG-HISTPRE");

                /*" -479- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -480- ELSE */
            }
            else
            {


                /*" -481- IF WHOST-COUNT NOT EQUAL ZEROS */

                if (WHOST_COUNT != 00)
                {

                    /*" -482- DISPLAY 'AC0005B - DUPLICIDADE DE PROCESSAMENTO' */
                    _.Display($"AC0005B - DUPLICIDADE DE PROCESSAMENTO");

                    /*" -482- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -474- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.V1COSSEG_HISTPRE WHERE DTMOVTO = :V0SIST-DTMOVABE AND TIPSGU = '0' AND OPERACAO < 0600 END-EXEC. */

            var r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1.Execute(r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V0HISTOPARC-SECTION */
        private void R0500_00_DECLARE_V0HISTOPARC_SECTION()
        {
            /*" -495- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -526- PERFORM R0500_00_DECLARE_V0HISTOPARC_DB_DECLARE_1 */

            R0500_00_DECLARE_V0HISTOPARC_DB_DECLARE_1();

            /*" -528- PERFORM R0500_00_DECLARE_V0HISTOPARC_DB_OPEN_1 */

            R0500_00_DECLARE_V0HISTOPARC_DB_OPEN_1();

            /*" -531- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -532- DISPLAY 'R0500 - ERRO NO DECLARE DA V0HISTOPARC' */
                _.Display($"R0500 - ERRO NO DECLARE DA V0HISTOPARC");

                /*" -533- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -534- ELSE */
            }
            else
            {


                /*" -534- MOVE SPACES TO WFIM-V0HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V0HISTOPARC);
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0HISTOPARC-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V0HISTOPARC_DB_DECLARE_1()
        {
            /*" -526- EXEC SQL DECLARE V0HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST , A.OPERACAO , A.DTMOVTO , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.VLPRMLIQ , A.VLADIFRA , A.VLCUSEMI , A.VLIOCC , A.VLPRMTOT , A.VLPREMIO , A.DTVENCTO , A.BCOCOBR , A.AGECOBR , A.NRAVISO , A.NRENDOCA , A.DTQITBCO FROM SEGUROS.V0HISTOPARC A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V0SIST-DTMOVABE AND B.TIPSGU = '0' AND B.NUM_APOLICE = A.NUM_APOLICE ORDER BY A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST END-EXEC. */
            V0HISTOPARC = new AC0005B_V0HISTOPARC(true);
            string GetQuery_V0HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.VLPRMLIQ
							, 
							A.VLADIFRA
							, 
							A.VLCUSEMI
							, 
							A.VLIOCC
							, 
							A.VLPRMTOT
							, 
							A.VLPREMIO
							, 
							A.DTVENCTO
							, 
							A.BCOCOBR
							, 
							A.AGECOBR
							, 
							A.NRAVISO
							, 
							A.NRENDOCA
							, 
							A.DTQITBCO 
							FROM SEGUROS.V0HISTOPARC A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.DTMOVTO = '{V0SIST_DTMOVABE}' 
							AND B.TIPSGU = '0' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST";

                return query;
            }
            V0HISTOPARC.GetQueryEvent += GetQuery_V0HISTOPARC;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0HISTOPARC-DB-OPEN-1 */
        public void R0500_00_DECLARE_V0HISTOPARC_DB_OPEN_1()
        {
            /*" -528- EXEC SQL OPEN V0HISTOPARC END-EXEC. */

            V0HISTOPARC.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-V1HISTOPARC-DB-DECLARE-1 */
        public void R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1()
        {
            /*" -1194- EXEC SQL DECLARE V1HISTOPARC CURSOR FOR SELECT NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST , OPERACAO , DTMOVTO , PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCUSEMI , VLIOCC , VLPRMTOT , VLPREMIO , DTVENCTO , BCOCOBR , AGECOBR , NRAVISO , NRENDOCA , DTQITBCO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NRENDOS = :V0ENDO-NRENDOS AND DTMOVTO < :V0SIST-DTMOVABE AND OPERACAO < 0900 ORDER BY NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST END-EXEC. */
            V1HISTOPARC = new AC0005B_V1HISTOPARC(true);
            string GetQuery_V1HISTOPARC()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							PRM_TARIFARIO
							, 
							VAL_DESCONTO
							, 
							VLPRMLIQ
							, 
							VLADIFRA
							, 
							VLCUSEMI
							, 
							VLIOCC
							, 
							VLPRMTOT
							, 
							VLPREMIO
							, 
							DTVENCTO
							, 
							BCOCOBR
							, 
							AGECOBR
							, 
							NRAVISO
							, 
							NRENDOCA
							, 
							DTQITBCO 
							FROM SEGUROS.V1HISTOPARC 
							WHERE NUM_APOLICE = '{V0ENDO_NUM_APOL}' 
							AND NRENDOS = '{V0ENDO_NRENDOS}' 
							AND DTMOVTO < '{V0SIST_DTMOVABE}' 
							AND OPERACAO < 0900 
							ORDER BY 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST";

                return query;
            }
            V1HISTOPARC.GetQueryEvent += GetQuery_V1HISTOPARC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-FETCH-V0HISTOPARC-SECTION */
        private void R0700_00_FETCH_V0HISTOPARC_SECTION()
        {
            /*" -545- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0700_10_LER_V0HISTOPARC */

            R0700_10_LER_V0HISTOPARC();

        }

        [StopWatch]
        /*" R0700-10-LER-V0HISTOPARC */
        private void R0700_10_LER_V0HISTOPARC(bool isPerform = false)
        {
            /*" -570- PERFORM R0700_10_LER_V0HISTOPARC_DB_FETCH_1 */

            R0700_10_LER_V0HISTOPARC_DB_FETCH_1();

            /*" -573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -574- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -575- MOVE 'S' TO WFIM-V0HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTOPARC);

                    /*" -575- PERFORM R0700_10_LER_V0HISTOPARC_DB_CLOSE_1 */

                    R0700_10_LER_V0HISTOPARC_DB_CLOSE_1();

                    /*" -577- GO TO R0700-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                    return;

                    /*" -578- ELSE */
                }
                else
                {


                    /*" -579- DISPLAY 'R0700 - ERRO NO FETCH DA V0HISTOPARC' */
                    _.Display($"R0700 - ERRO NO FETCH DA V0HISTOPARC");

                    /*" -581- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -583- MOVE V0HISP-OPERACAO TO WOPERACAO. */
            _.Move(V0HISP_OPERACAO, AREA_DE_WORK.WOPERACAO);

            /*" -584- IF WTIPO-OPERACAO = 06 OR 07 OR 09 OR 10 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO.In("06", "07", "09", "10"))
            {

                /*" -586- GO TO R0700-10-LER-V0HISTOPARC. */
                new Task(() => R0700_10_LER_V0HISTOPARC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -588- ADD 1 TO AC-L-V0HISTOPARC. */
            AREA_DE_WORK.AC_L_V0HISTOPARC.Value = AREA_DE_WORK.AC_L_V0HISTOPARC + 1;

            /*" -590- ADD 1 TO AC-COUNT. */
            AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + 1;

            /*" -591- IF AC-COUNT > 999 */

            if (AREA_DE_WORK.AC_COUNT > 999)
            {

                /*" -592- MOVE ZEROS TO AC-COUNT */
                _.Move(0, AREA_DE_WORK.AC_COUNT);

                /*" -593- ACCEPT WHORA-ACCEPT FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

                /*" -594- MOVE WHH-ACCEPT TO WHORA-HH-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

                /*" -595- MOVE WMM-ACCEPT TO WHORA-MM-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

                /*" -596- MOVE WSS-ACCEPT TO WHORA-SS-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

                /*" -597- DISPLAY AC-L-V0HISTOPARC ' LIDOS NA V0HISTOPARC ' WHORA-CABEC. */

                $"{AREA_DE_WORK.AC_L_V0HISTOPARC} LIDOS NA V0HISTOPARC {AREA_DE_WORK.WHORA_CABEC}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0700-10-LER-V0HISTOPARC-DB-FETCH-1 */
        public void R0700_10_LER_V0HISTOPARC_DB_FETCH_1()
        {
            /*" -570- EXEC SQL FETCH V0HISTOPARC INTO :V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-OCORHIST , :V0HISP-OPERACAO , :V0HISP-DTMOVTO , :V0HISP-PRM-TAR , :V0HISP-VAL-DESC , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-DTQITBCO:VIND-DAT-QTBC END-EXEC. */

            if (V0HISTOPARC.Fetch())
            {
                _.Move(V0HISTOPARC.V0HISP_NUM_APOL, V0HISP_NUM_APOL);
                _.Move(V0HISTOPARC.V0HISP_NRENDOS, V0HISP_NRENDOS);
                _.Move(V0HISTOPARC.V0HISP_NRPARCEL, V0HISP_NRPARCEL);
                _.Move(V0HISTOPARC.V0HISP_OCORHIST, V0HISP_OCORHIST);
                _.Move(V0HISTOPARC.V0HISP_OPERACAO, V0HISP_OPERACAO);
                _.Move(V0HISTOPARC.V0HISP_DTMOVTO, V0HISP_DTMOVTO);
                _.Move(V0HISTOPARC.V0HISP_PRM_TAR, V0HISP_PRM_TAR);
                _.Move(V0HISTOPARC.V0HISP_VAL_DESC, V0HISP_VAL_DESC);
                _.Move(V0HISTOPARC.V0HISP_VLPRMLIQ, V0HISP_VLPRMLIQ);
                _.Move(V0HISTOPARC.V0HISP_VLADIFRA, V0HISP_VLADIFRA);
                _.Move(V0HISTOPARC.V0HISP_VLCUSEMI, V0HISP_VLCUSEMI);
                _.Move(V0HISTOPARC.V0HISP_VLIOCC, V0HISP_VLIOCC);
                _.Move(V0HISTOPARC.V0HISP_VLPRMTOT, V0HISP_VLPRMTOT);
                _.Move(V0HISTOPARC.V0HISP_VLPREMIO, V0HISP_VLPREMIO);
                _.Move(V0HISTOPARC.V0HISP_DTVENCTO, V0HISP_DTVENCTO);
                _.Move(V0HISTOPARC.V0HISP_BCOCOBR, V0HISP_BCOCOBR);
                _.Move(V0HISTOPARC.V0HISP_AGECOBR, V0HISP_AGECOBR);
                _.Move(V0HISTOPARC.V0HISP_NRAVISO, V0HISP_NRAVISO);
                _.Move(V0HISTOPARC.V0HISP_NRENDOCA, V0HISP_NRENDOCA);
                _.Move(V0HISTOPARC.V0HISP_DTQITBCO, V0HISP_DTQITBCO);
                _.Move(V0HISTOPARC.VIND_DAT_QTBC, VIND_DAT_QTBC);
            }

        }

        [StopWatch]
        /*" R0700-10-LER-V0HISTOPARC-DB-CLOSE-1 */
        public void R0700_10_LER_V0HISTOPARC_DB_CLOSE_1()
        {
            /*" -575- EXEC SQL CLOSE V0HISTOPARC END-EXEC */

            V0HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-REGISTRO-SECTION */
        private void R0800_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -610- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -612- PERFORM R0900-00-SELECT-V0ENDOSSO. */

            R0900_00_SELECT_V0ENDOSSO_SECTION();

            /*" -614- PERFORM R0950-00-SELECT-V0COSSEGACE. */

            R0950_00_SELECT_V0COSSEGACE_SECTION();

            /*" -617- PERFORM R1000-00-PROCESSA-DOCUMENTO UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES OR V0HISP-NUM-APOL NOT EQUAL V0ENDO-NUM-APOL OR V0HISP-NRENDOS NOT EQUAL V0ENDO-NRENDOS. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty() || V0HISP_NUM_APOL != V0ENDO_NUM_APOL || V0HISP_NRENDOS != V0ENDO_NRENDOS))
            {

                R1000_00_PROCESSA_DOCUMENTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-V0ENDOSSO-SECTION */
        private void R0900_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -630- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -640- PERFORM R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -643- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -644- DISPLAY 'R0900 - ERRO NO SELECT DA V0ENDOSSO' */
                _.Display($"R0900 - ERRO NO SELECT DA V0ENDOSSO");

                /*" -645- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -646- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -646- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -640- EXEC SQL SELECT NUM_APOLICE, NRENDOS, CORRECAO INTO :V0ENDO-NUM-APOL, :V0ENDO-NRENDOS, :V0ENDO-CORRECAO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS END-EXEC. */

            var r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NUM_APOL, V0ENDO_NUM_APOL);
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
                _.Move(executed_1.V0ENDO_CORRECAO, V0ENDO_CORRECAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-SELECT-V0COSSEGACE-SECTION */
        private void R0950_00_SELECT_V0COSSEGACE_SECTION()
        {
            /*" -659- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1 */

            R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1();

            /*" -676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- DISPLAY 'R0950 -  ERRO NO SELECT DA V0COSSEGACE' */
                _.Display($"R0950 -  ERRO NO SELECT DA V0COSSEGACE");

                /*" -678- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -679- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -679- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0950-00-SELECT-V0COSSEGACE-DB-SELECT-1 */
        public void R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1()
        {
            /*" -673- EXEC SQL SELECT NUM_APOLICE, NRENDOS, CODLIDER , ORDLIDER , PCCOMCOS INTO :V0COSC-NUM-APOL , :V0COSC-NRENDOS , :V0COSC-CODLIDER , :V0COSC-ORDLIDER , :V0COSC-PCCOMCOS FROM SEGUROS.V0COSSEGACE WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS END-EXEC. */

            var r0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1 = new R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1.Execute(r0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COSC_NUM_APOL, V0COSC_NUM_APOL);
                _.Move(executed_1.V0COSC_NRENDOS, V0COSC_NRENDOS);
                _.Move(executed_1.V0COSC_CODLIDER, V0COSC_CODLIDER);
                _.Move(executed_1.V0COSC_ORDLIDER, V0COSC_ORDLIDER);
                _.Move(executed_1.V0COSC_PCCOMCOS, V0COSC_PCCOMCOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DOCUMENTO-SECTION */
        private void R1000_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -692- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -694- MOVE ZEROS TO WHOST-OCORHIST. */
            _.Move(0, WHOST_OCORHIST);

            /*" -696- PERFORM R1100-00-SELECT-V0PARCELA. */

            R1100_00_SELECT_V0PARCELA_SECTION();

            /*" -697- IF WTIPO-OPERACAO > 01 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO > 01)
            {

                /*" -699- PERFORM R1200-00-SELECT-V1COSSEG-PREM. */

                R1200_00_SELECT_V1COSSEG_PREM_SECTION();
            }


            /*" -705- PERFORM R1300-00-PROCESSA-PARCELA UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES OR V0HISP-NUM-APOL NOT EQUAL V0ENDO-NUM-APOL OR V0HISP-NRENDOS NOT EQUAL V0ENDO-NRENDOS OR V0HISP-NRPARCEL NOT EQUAL V0PARC-NRPARCEL. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty() || V0HISP_NUM_APOL != V0ENDO_NUM_APOL || V0HISP_NRENDOS != V0ENDO_NRENDOS || V0HISP_NRPARCEL != V0PARC_NRPARCEL))
            {

                R1300_00_PROCESSA_PARCELA_SECTION();
            }

            /*" -706- IF WHOST-OCORHIST > 01 */

            if (WHOST_OCORHIST > 01)
            {

                /*" -706- PERFORM R2000-00-UPDATE-V0COSSEG-PREM. */

                R2000_00_UPDATE_V0COSSEG_PREM_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0PARCELA-SECTION */
        private void R1100_00_SELECT_V0PARCELA_SECTION()
        {
            /*" -719- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -744- PERFORM R1100_00_SELECT_V0PARCELA_DB_SELECT_1 */

            R1100_00_SELECT_V0PARCELA_DB_SELECT_1();

            /*" -747- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -748- DISPLAY 'R1100 - ERRO NO SELECT DA V0PARCELA' */
                _.Display($"R1100 - ERRO NO SELECT DA V0PARCELA");

                /*" -749- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -750- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -751- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -751- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0PARCELA-DB-SELECT-1 */
        public void R1100_00_SELECT_V0PARCELA_DB_SELECT_1()
        {
            /*" -744- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , OTNCUSTO , OTNIOF , OTNTOTAL INTO :V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-PRM-TAR , :V0PARC-VAL-DESC , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL END-EXEC. */

            var r1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 = new R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NUM_APOL, V0PARC_NUM_APOL);
                _.Move(executed_1.V0PARC_NRENDOS, V0PARC_NRENDOS);
                _.Move(executed_1.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(executed_1.V0PARC_PRM_TAR, V0PARC_PRM_TAR);
                _.Move(executed_1.V0PARC_VAL_DESC, V0PARC_VAL_DESC);
                _.Move(executed_1.V0PARC_OTNPRLIQ, V0PARC_OTNPRLIQ);
                _.Move(executed_1.V0PARC_OTNADFRA, V0PARC_OTNADFRA);
                _.Move(executed_1.V0PARC_OTNCUSTO, V0PARC_OTNCUSTO);
                _.Move(executed_1.V0PARC_OTNIOF, V0PARC_OTNIOF);
                _.Move(executed_1.V0PARC_OTNTOTAL, V0PARC_OTNTOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1COSSEG-PREM-SECTION */
        private void R1200_00_SELECT_V1COSSEG_PREM_SECTION()
        {
            /*" -764- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -774- PERFORM R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1 */

            R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1();

            /*" -777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -778- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -779- DISPLAY 'R1200 - NAO EXISTE NA V1COSSEG-PREM' */
                    _.Display($"R1200 - NAO EXISTE NA V1COSSEG-PREM");

                    /*" -780- DISPLAY 'DOCUMENTO SERA INCLUIDO - INTEGRIDADE' */
                    _.Display($"DOCUMENTO SERA INCLUIDO - INTEGRIDADE");

                    /*" -781- DISPLAY 'COD LIDER - ' V0COSC-CODLIDER */
                    _.Display($"COD LIDER - {V0COSC_CODLIDER}");

                    /*" -782- DISPLAY 'NUM ORDEM - ' V0COSC-ORDLIDER */
                    _.Display($"NUM ORDEM - {V0COSC_ORDLIDER}");

                    /*" -783- DISPLAY 'APOLICE   - ' V0HISP-NUM-APOL */
                    _.Display($"APOLICE   - {V0HISP_NUM_APOL}");

                    /*" -784- DISPLAY 'ENDOSSO   - ' V0HISP-NRENDOS */
                    _.Display($"ENDOSSO   - {V0HISP_NRENDOS}");

                    /*" -785- DISPLAY 'PARCELA   - ' V0HISP-NRPARCEL */
                    _.Display($"PARCELA   - {V0HISP_NRPARCEL}");

                    /*" -786- PERFORM R3000-00-PROCESSA-INTEGRIDADE */

                    R3000_00_PROCESSA_INTEGRIDADE_SECTION();

                    /*" -787- ELSE */
                }
                else
                {


                    /*" -788- DISPLAY 'R1200 - ERRO NO SELECT DA V1COSSEG-PREM' */
                    _.Display($"R1200 - ERRO NO SELECT DA V1COSSEG-PREM");

                    /*" -789- DISPLAY 'COD LIDER - ' V0COSC-CODLIDER */
                    _.Display($"COD LIDER - {V0COSC_CODLIDER}");

                    /*" -790- DISPLAY 'NUM ORDEM - ' V0COSC-ORDLIDER */
                    _.Display($"NUM ORDEM - {V0COSC_ORDLIDER}");

                    /*" -791- DISPLAY 'APOLICE   - ' V0HISP-NUM-APOL */
                    _.Display($"APOLICE   - {V0HISP_NUM_APOL}");

                    /*" -792- DISPLAY 'ENDOSSO   - ' V0HISP-NRENDOS */
                    _.Display($"ENDOSSO   - {V0HISP_NRENDOS}");

                    /*" -793- DISPLAY 'PARCELA   - ' V0HISP-NRPARCEL */
                    _.Display($"PARCELA   - {V0HISP_NRPARCEL}");

                    /*" -793- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V1COSSEG-PREM-DB-SELECT-1 */
        public void R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1()
        {
            /*" -774- EXEC SQL SELECT OCORHIST INTO :WHOST-OCORHIST FROM SEGUROS.V1COSSEG_PREM WHERE CONGENER = :V0COSC-CODLIDER AND NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND TIPSGU = '0' AND NUM_ORDEM = :V0COSC-ORDLIDER END-EXEC. */

            var r1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1()
            {
                V0COSC_CODLIDER = V0COSC_CODLIDER.ToString(),
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0COSC_ORDLIDER = V0COSC_ORDLIDER.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OCORHIST, WHOST_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-PARCELA-SECTION */
        private void R1300_00_PROCESSA_PARCELA_SECTION()
        {
            /*" -806- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -811- MOVE ZEROS TO WTOTAL WTOTAL-IX WCOMISSAO WCOMISSAO-IX. */
            _.Move(0, AREA_DE_WORK.WTOTAL, AREA_DE_WORK.WTOTAL_IX, AREA_DE_WORK.WCOMISSAO, AREA_DE_WORK.WCOMISSAO_IX);

            /*" -813- PERFORM R1400-00-CALCULA-COMISSAO. */

            R1400_00_CALCULA_COMISSAO_SECTION();

            /*" -817- COMPUTE WTOTAL = V0HISP-VLPRMLIQ + V0HISP-VLADIFRA - WCOMISSAO. */
            AREA_DE_WORK.WTOTAL.Value = V0HISP_VLPRMLIQ + V0HISP_VLADIFRA - AREA_DE_WORK.WCOMISSAO;

            /*" -821- COMPUTE WTOTAL-IX = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA - WCOMISSAO-IX. */
            AREA_DE_WORK.WTOTAL_IX.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA - AREA_DE_WORK.WCOMISSAO_IX;

            /*" -822- IF WTIPO-OPERACAO = 01 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 01)
            {

                /*" -823- PERFORM R1600-00-MONTA-V0COSSEG-PREM */

                R1600_00_MONTA_V0COSSEG_PREM_SECTION();

                /*" -824- PERFORM R1700-00-INSERT-V0COSSEG-PREM */

                R1700_00_INSERT_V0COSSEG_PREM_SECTION();

                /*" -825- PERFORM R1800-00-MONTA-V0COSEG-HSTPRM */

                R1800_00_MONTA_V0COSEG_HSTPRM_SECTION();

                /*" -826- PERFORM R1900-00-INSERT-V0COSEG-HSTPRM */

                R1900_00_INSERT_V0COSEG_HSTPRM_SECTION();

                /*" -827- ELSE */
            }
            else
            {


                /*" -828- PERFORM R1500-00-VERIFICA-SITUACAO */

                R1500_00_VERIFICA_SITUACAO_SECTION();

                /*" -829- PERFORM R1800-00-MONTA-V0COSEG-HSTPRM */

                R1800_00_MONTA_V0COSEG_HSTPRM_SECTION();

                /*" -833- PERFORM R1900-00-INSERT-V0COSEG-HSTPRM. */

                R1900_00_INSERT_V0COSEG_HSTPRM_SECTION();
            }


            /*" -833- PERFORM R0700-00-FETCH-V0HISTOPARC. */

            R0700_00_FETCH_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-CALCULA-COMISSAO-SECTION */
        private void R1400_00_CALCULA_COMISSAO_SECTION()
        {
            /*" -846- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -852- COMPUTE WCOMISSAO ROUNDED = (V0HISP-PRM-TAR + V0HISP-VLADIFRA - V0HISP-VAL-DESC) * V0COSC-PCCOMCOS / 100. */
            AREA_DE_WORK.WCOMISSAO.Value = (V0HISP_PRM_TAR + V0HISP_VLADIFRA - V0HISP_VAL_DESC) * V0COSC_PCCOMCOS / 100f;

            /*" -853- IF V0ENDO-CORRECAO = '2' OR '4' */

            if (V0ENDO_CORRECAO.In("2", "4"))
            {

                /*" -858- COMPUTE WCOMISSAO-IX ROUNDED = (V0PARC-PRM-TAR + V0PARC-OTNADFRA - V0PARC-VAL-DESC) * V0COSC-PCCOMCOS / 100 */
                AREA_DE_WORK.WCOMISSAO_IX.Value = (V0PARC_PRM_TAR + V0PARC_OTNADFRA - V0PARC_VAL_DESC) * V0COSC_PCCOMCOS / 100f;

                /*" -859- ELSE */
            }
            else
            {


                /*" -859- MOVE WCOMISSAO TO WCOMISSAO-IX. */
                _.Move(AREA_DE_WORK.WCOMISSAO, AREA_DE_WORK.WCOMISSAO_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-VERIFICA-SITUACAO-SECTION */
        private void R1500_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -872- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -874- IF WTIPO-OPERACAO = 02 OR V0HISP-OPERACAO = 802 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 02 || V0HISP_OPERACAO == 802)
            {

                /*" -875- MOVE '1' TO WHOST-SITUACAO */
                _.Move("1", WHOST_SITUACAO);

                /*" -876- MOVE '1' TO WHOST-SITCONG */
                _.Move("1", WHOST_SITCONG);

                /*" -877- ELSE */
            }
            else
            {


                /*" -879- IF WTIPO-OPERACAO = 03 OR V0HISP-OPERACAO = 803 */

                if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 03 || V0HISP_OPERACAO == 803)
                {

                    /*" -880- MOVE '0' TO WHOST-SITUACAO */
                    _.Move("0", WHOST_SITUACAO);

                    /*" -881- MOVE '0' TO WHOST-SITCONG */
                    _.Move("0", WHOST_SITCONG);

                    /*" -882- ELSE */
                }
                else
                {


                    /*" -884- IF WTIPO-OPERACAO = 04 OR V0HISP-OPERACAO = 804 */

                    if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 04 || V0HISP_OPERACAO == 804)
                    {

                        /*" -885- MOVE '2' TO WHOST-SITUACAO */
                        _.Move("2", WHOST_SITUACAO);

                        /*" -886- MOVE '2' TO WHOST-SITCONG */
                        _.Move("2", WHOST_SITCONG);

                        /*" -887- ELSE */
                    }
                    else
                    {


                        /*" -889- IF WTIPO-OPERACAO = 05 OR V0HISP-OPERACAO = 801 OR 805 */

                        if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 05 || V0HISP_OPERACAO.In("801", "805"))
                        {

                            /*" -890- MOVE '0' TO WHOST-SITUACAO */
                            _.Move("0", WHOST_SITUACAO);

                            /*" -891- MOVE '0' TO WHOST-SITCONG */
                            _.Move("0", WHOST_SITCONG);

                            /*" -892- ELSE */
                        }
                        else
                        {


                            /*" -893- DISPLAY 'R1500 - OPERACAO NAO PREVISTA' */
                            _.Display($"R1500 - OPERACAO NAO PREVISTA");

                            /*" -894- DISPLAY 'APOLICE  - ' V0HISP-NUM-APOL */
                            _.Display($"APOLICE  - {V0HISP_NUM_APOL}");

                            /*" -895- DISPLAY 'ENDOSSO  - ' V0HISP-NRENDOS */
                            _.Display($"ENDOSSO  - {V0HISP_NRENDOS}");

                            /*" -896- DISPLAY 'PARCELA  - ' V0HISP-NRPARCEL */
                            _.Display($"PARCELA  - {V0HISP_NRPARCEL}");

                            /*" -897- DISPLAY 'OC HIST  - ' V0HISP-OCORHIST */
                            _.Display($"OC HIST  - {V0HISP_OCORHIST}");

                            /*" -898- DISPLAY 'OPERACAO - ' V0HISP-OPERACAO */
                            _.Display($"OPERACAO - {V0HISP_OPERACAO}");

                            /*" -898- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-MONTA-V0COSSEG-PREM-SECTION */
        private void R1600_00_MONTA_V0COSSEG_PREM_SECTION()
        {
            /*" -911- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -912- MOVE ZEROS TO V0CPRE-COD-EMP. */
            _.Move(0, V0CPRE_COD_EMP);

            /*" -913- MOVE '0' TO V0CPRE-TIPSGU. */
            _.Move("0", V0CPRE_TIPSGU);

            /*" -914- MOVE V0COSC-CODLIDER TO V0CPRE-CONGENER. */
            _.Move(V0COSC_CODLIDER, V0CPRE_CONGENER);

            /*" -915- MOVE V0COSC-ORDLIDER TO V0CPRE-NUM-ORDEM. */
            _.Move(V0COSC_ORDLIDER, V0CPRE_NUM_ORDEM);

            /*" -916- MOVE V0HISP-NUM-APOL TO V0CPRE-NUM-APOL. */
            _.Move(V0HISP_NUM_APOL, V0CPRE_NUM_APOL);

            /*" -917- MOVE V0HISP-NRENDOS TO V0CPRE-NRENDOS. */
            _.Move(V0HISP_NRENDOS, V0CPRE_NRENDOS);

            /*" -918- MOVE V0HISP-NRPARCEL TO V0CPRE-NRPARCEL. */
            _.Move(V0HISP_NRPARCEL, V0CPRE_NRPARCEL);

            /*" -919- MOVE V0PARC-PRM-TAR TO V0CPRE-PRM-TAR-IX. */
            _.Move(V0PARC_PRM_TAR, V0CPRE_PRM_TAR_IX);

            /*" -920- MOVE V0PARC-VAL-DESC TO V0CPRE-VAL-DES-IX. */
            _.Move(V0PARC_VAL_DESC, V0CPRE_VAL_DES_IX);

            /*" -921- MOVE V0PARC-OTNPRLIQ TO V0CPRE-OTNPRLIQ. */
            _.Move(V0PARC_OTNPRLIQ, V0CPRE_OTNPRLIQ);

            /*" -922- MOVE V0PARC-OTNADFRA TO V0CPRE-OTNADFRA. */
            _.Move(V0PARC_OTNADFRA, V0CPRE_OTNADFRA);

            /*" -923- MOVE WCOMISSAO-IX TO V0CPRE-VLCOMISIX. */
            _.Move(AREA_DE_WORK.WCOMISSAO_IX, V0CPRE_VLCOMISIX);

            /*" -924- MOVE WTOTAL-IX TO V0CPRE-OTNTOTAL. */
            _.Move(AREA_DE_WORK.WTOTAL_IX, V0CPRE_OTNTOTAL);

            /*" -925- MOVE '0' TO V0CPRE-SITUACAO. */
            _.Move("0", V0CPRE_SITUACAO);

            /*" -926- MOVE '0' TO V0CPRE-SIT-CONG. */
            _.Move("0", V0CPRE_SIT_CONG);

            /*" -928- MOVE 01 TO V0CPRE-OCORHIST. */
            _.Move(01, V0CPRE_OCORHIST);

            /*" -928- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-INSERT-V0COSSEG-PREM-SECTION */
        private void R1700_00_INSERT_V0COSSEG_PREM_SECTION()
        {
            /*" -941- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -960- PERFORM R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1 */

            R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1();

            /*" -963- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -964- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -965- DISPLAY 'R1700 - REGISTRO DUPLICADO NA V0COSSEG-PREM' */
                    _.Display($"R1700 - REGISTRO DUPLICADO NA V0COSSEG-PREM");

                    /*" -966- DISPLAY 'TP SEGURO - ' V0CPRE-TIPSGU */
                    _.Display($"TP SEGURO - {V0CPRE_TIPSGU}");

                    /*" -967- DISPLAY 'COD LIDER - ' V0CPRE-CONGENER */
                    _.Display($"COD LIDER - {V0CPRE_CONGENER}");

                    /*" -968- DISPLAY 'NUM ORDEM - ' V0CPRE-NUM-ORDEM */
                    _.Display($"NUM ORDEM - {V0CPRE_NUM_ORDEM}");

                    /*" -969- DISPLAY 'APOLICE   - ' V0CPRE-NUM-APOL */
                    _.Display($"APOLICE   - {V0CPRE_NUM_APOL}");

                    /*" -970- DISPLAY 'ENDOSSO   - ' V0CPRE-NRENDOS */
                    _.Display($"ENDOSSO   - {V0CPRE_NRENDOS}");

                    /*" -971- DISPLAY 'PARCELA   - ' V0CPRE-NRPARCEL */
                    _.Display($"PARCELA   - {V0CPRE_NRPARCEL}");

                    /*" -972- ELSE */
                }
                else
                {


                    /*" -973- DISPLAY 'R1700 - ERRO NO INSERT DA V0COSSEG-PREM' */
                    _.Display($"R1700 - ERRO NO INSERT DA V0COSSEG-PREM");

                    /*" -974- DISPLAY 'TP SEGURO - ' V0CPRE-TIPSGU */
                    _.Display($"TP SEGURO - {V0CPRE_TIPSGU}");

                    /*" -975- DISPLAY 'COD LIDER - ' V0CPRE-CONGENER */
                    _.Display($"COD LIDER - {V0CPRE_CONGENER}");

                    /*" -976- DISPLAY 'NUM ORDEM - ' V0CPRE-NUM-ORDEM */
                    _.Display($"NUM ORDEM - {V0CPRE_NUM_ORDEM}");

                    /*" -977- DISPLAY 'APOLICE   - ' V0CPRE-NUM-APOL */
                    _.Display($"APOLICE   - {V0CPRE_NUM_APOL}");

                    /*" -978- DISPLAY 'ENDOSSO   - ' V0CPRE-NRENDOS */
                    _.Display($"ENDOSSO   - {V0CPRE_NRENDOS}");

                    /*" -979- DISPLAY 'PARCELA   - ' V0CPRE-NRPARCEL */
                    _.Display($"PARCELA   - {V0CPRE_NRPARCEL}");

                    /*" -980- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -981- ELSE */
                }

            }
            else
            {


                /*" -981- ADD +1 TO AC-I-V0COSSEGPREM. */
                AREA_DE_WORK.AC_I_V0COSSEGPREM.Value = AREA_DE_WORK.AC_I_V0COSSEGPREM + +1;
            }


        }

        [StopWatch]
        /*" R1700-00-INSERT-V0COSSEG-PREM-DB-INSERT-1 */
        public void R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1()
        {
            /*" -960- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_PREM VALUES (:V0CPRE-COD-EMP , :V0CPRE-TIPSGU , :V0CPRE-CONGENER , :V0CPRE-NUM-ORDEM , :V0CPRE-NUM-APOL , :V0CPRE-NRENDOS , :V0CPRE-NRPARCEL , :V0CPRE-PRM-TAR-IX , :V0CPRE-VAL-DES-IX , :V0CPRE-OTNPRLIQ , :V0CPRE-OTNADFRA , :V0CPRE-VLCOMISIX , :V0CPRE-OTNTOTAL , :V0CPRE-SITUACAO , :V0CPRE-SIT-CONG , CURRENT TIMESTAMP , :V0CPRE-OCORHIST:VIND-OCR-HIST) END-EXEC. */

            var r1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1 = new R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1()
            {
                V0CPRE_COD_EMP = V0CPRE_COD_EMP.ToString(),
                V0CPRE_TIPSGU = V0CPRE_TIPSGU.ToString(),
                V0CPRE_CONGENER = V0CPRE_CONGENER.ToString(),
                V0CPRE_NUM_ORDEM = V0CPRE_NUM_ORDEM.ToString(),
                V0CPRE_NUM_APOL = V0CPRE_NUM_APOL.ToString(),
                V0CPRE_NRENDOS = V0CPRE_NRENDOS.ToString(),
                V0CPRE_NRPARCEL = V0CPRE_NRPARCEL.ToString(),
                V0CPRE_PRM_TAR_IX = V0CPRE_PRM_TAR_IX.ToString(),
                V0CPRE_VAL_DES_IX = V0CPRE_VAL_DES_IX.ToString(),
                V0CPRE_OTNPRLIQ = V0CPRE_OTNPRLIQ.ToString(),
                V0CPRE_OTNADFRA = V0CPRE_OTNADFRA.ToString(),
                V0CPRE_VLCOMISIX = V0CPRE_VLCOMISIX.ToString(),
                V0CPRE_OTNTOTAL = V0CPRE_OTNTOTAL.ToString(),
                V0CPRE_SITUACAO = V0CPRE_SITUACAO.ToString(),
                V0CPRE_SIT_CONG = V0CPRE_SIT_CONG.ToString(),
                V0CPRE_OCORHIST = V0CPRE_OCORHIST.ToString(),
                VIND_OCR_HIST = VIND_OCR_HIST.ToString(),
            };

            R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1.Execute(r1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-MONTA-V0COSEG-HSTPRM-SECTION */
        private void R1800_00_MONTA_V0COSEG_HSTPRM_SECTION()
        {
            /*" -994- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -995- MOVE ZEROS TO V0CHIS-COD-EMP. */
            _.Move(0, V0CHIS_COD_EMP);

            /*" -996- MOVE V0COSC-CODLIDER TO V0CHIS-CONGENER. */
            _.Move(V0COSC_CODLIDER, V0CHIS_CONGENER);

            /*" -997- MOVE V0HISP-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(V0HISP_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -998- MOVE V0HISP-NRENDOS TO V0CHIS-NRENDOS. */
            _.Move(V0HISP_NRENDOS, V0CHIS_NRENDOS);

            /*" -1000- MOVE V0HISP-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(V0HISP_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -1002- COMPUTE WHOST-OCORHIST = WHOST-OCORHIST + 1. */
            WHOST_OCORHIST.Value = WHOST_OCORHIST + 1;

            /*" -1004- MOVE WHOST-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(WHOST_OCORHIST, V0CHIS_OCORHIST);

            /*" -1005- MOVE V0HISP-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(V0HISP_OPERACAO, V0CHIS_OPERACAO);

            /*" -1006- MOVE V0HISP-DTMOVTO TO V0CHIS-DTMOVTO. */
            _.Move(V0HISP_DTMOVTO, V0CHIS_DTMOVTO);

            /*" -1007- MOVE '0' TO V0CHIS-TIPSGU. */
            _.Move("0", V0CHIS_TIPSGU);

            /*" -1008- MOVE V0HISP-PRM-TAR TO V0CHIS-PRM-TAR. */
            _.Move(V0HISP_PRM_TAR, V0CHIS_PRM_TAR);

            /*" -1009- MOVE V0HISP-VAL-DESC TO V0CHIS-VAL-DESC. */
            _.Move(V0HISP_VAL_DESC, V0CHIS_VAL_DESC);

            /*" -1010- MOVE V0HISP-VLPRMLIQ TO V0CHIS-VLPRMLIQ. */
            _.Move(V0HISP_VLPRMLIQ, V0CHIS_VLPRMLIQ);

            /*" -1011- MOVE V0HISP-VLADIFRA TO V0CHIS-VLADIFRA. */
            _.Move(V0HISP_VLADIFRA, V0CHIS_VLADIFRA);

            /*" -1012- MOVE WCOMISSAO TO V0CHIS-VLCOMIS. */
            _.Move(AREA_DE_WORK.WCOMISSAO, V0CHIS_VLCOMIS);

            /*" -1014- MOVE WTOTAL TO V0CHIS-VLPRMTOT. */
            _.Move(AREA_DE_WORK.WTOTAL, V0CHIS_VLPRMTOT);

            /*" -1016- IF V0HISP-OPERACAO > 0199 AND V0HISP-OPERACAO < 0400 */

            if (V0HISP_OPERACAO > 0199 && V0HISP_OPERACAO < 0400)
            {

                /*" -1017- MOVE +1 TO VIND-DAT-QTBC */
                _.Move(+1, VIND_DAT_QTBC);

                /*" -1018- MOVE V0HISP-DTQITBCO TO V0CHIS-DTQITBCO */
                _.Move(V0HISP_DTQITBCO, V0CHIS_DTQITBCO);

                /*" -1019- ELSE */
            }
            else
            {


                /*" -1020- MOVE -1 TO VIND-DAT-QTBC */
                _.Move(-1, VIND_DAT_QTBC);

                /*" -1022- MOVE SPACES TO V0CHIS-DTQITBCO. */
                _.Move("", V0CHIS_DTQITBCO);
            }


            /*" -1025- MOVE '0' TO V0CHIS-SIT-LIBRECUP V0CHIS-SIT-FINANC. */
            _.Move("0", V0CHIS_SIT_LIBRECUP, V0CHIS_SIT_FINANC);

            /*" -1028- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -1030- MOVE WHOST-OCORHIST TO V0CHIS-NUMOCOR. */
            _.Move(WHOST_OCORHIST, V0CHIS_NUMOCOR);

            /*" -1030- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-INSERT-V0COSEG-HSTPRM-SECTION */
        private void R1900_00_INSERT_V0COSEG_HSTPRM_SECTION()
        {
            /*" -1043- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -1065- PERFORM R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1 */

            R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1();

            /*" -1068- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1069- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1070- DISPLAY 'R1900 - REG. DUPLICADO NA V0COSSEG-HISTPRE' */
                    _.Display($"R1900 - REG. DUPLICADO NA V0COSSEG-HISTPRE");

                    /*" -1071- DISPLAY 'TP SEGURO - ' V0CHIS-TIPSGU */
                    _.Display($"TP SEGURO - {V0CHIS_TIPSGU}");

                    /*" -1072- DISPLAY 'COD LIDER - ' V0CHIS-CONGENER */
                    _.Display($"COD LIDER - {V0CHIS_CONGENER}");

                    /*" -1073- DISPLAY 'APOLICE   - ' V0CHIS-NUM-APOL */
                    _.Display($"APOLICE   - {V0CHIS_NUM_APOL}");

                    /*" -1074- DISPLAY 'ENDOSSO   - ' V0CHIS-NRENDOS */
                    _.Display($"ENDOSSO   - {V0CHIS_NRENDOS}");

                    /*" -1075- DISPLAY 'PARCELA   - ' V0CHIS-NRPARCEL */
                    _.Display($"PARCELA   - {V0CHIS_NRPARCEL}");

                    /*" -1076- DISPLAY 'OCOR HIST - ' V0CHIS-OCORHIST */
                    _.Display($"OCOR HIST - {V0CHIS_OCORHIST}");

                    /*" -1077- DISPLAY 'OPERACAO  - ' V0CHIS-OPERACAO */
                    _.Display($"OPERACAO  - {V0CHIS_OPERACAO}");

                    /*" -1078- DISPLAY 'DT MOVTO. - ' V0CHIS-DTMOVTO */
                    _.Display($"DT MOVTO. - {V0CHIS_DTMOVTO}");

                    /*" -1079- DISPLAY 'NUM OCORR - ' V0CHIS-NUMOCOR */
                    _.Display($"NUM OCORR - {V0CHIS_NUMOCOR}");

                    /*" -1080- ELSE */
                }
                else
                {


                    /*" -1081- DISPLAY 'R1900 - ERRO NO INSERT DA V0COSSEG-HISTPRE' */
                    _.Display($"R1900 - ERRO NO INSERT DA V0COSSEG-HISTPRE");

                    /*" -1082- DISPLAY 'TP SEGURO - ' V0CHIS-TIPSGU */
                    _.Display($"TP SEGURO - {V0CHIS_TIPSGU}");

                    /*" -1083- DISPLAY 'COD LIDER - ' V0CHIS-CONGENER */
                    _.Display($"COD LIDER - {V0CHIS_CONGENER}");

                    /*" -1084- DISPLAY 'APOLICE   - ' V0CHIS-NUM-APOL */
                    _.Display($"APOLICE   - {V0CHIS_NUM_APOL}");

                    /*" -1085- DISPLAY 'ENDOSSO   - ' V0CHIS-NRENDOS */
                    _.Display($"ENDOSSO   - {V0CHIS_NRENDOS}");

                    /*" -1086- DISPLAY 'PARCELA   - ' V0CHIS-NRPARCEL */
                    _.Display($"PARCELA   - {V0CHIS_NRPARCEL}");

                    /*" -1087- DISPLAY 'OCOR HIST - ' V0CHIS-OCORHIST */
                    _.Display($"OCOR HIST - {V0CHIS_OCORHIST}");

                    /*" -1088- DISPLAY 'OPERACAO  - ' V0CHIS-OPERACAO */
                    _.Display($"OPERACAO  - {V0CHIS_OPERACAO}");

                    /*" -1089- DISPLAY 'DT MOVTO. - ' V0CHIS-DTMOVTO */
                    _.Display($"DT MOVTO. - {V0CHIS_DTMOVTO}");

                    /*" -1090- DISPLAY 'NUM OCORR - ' V0CHIS-NUMOCOR */
                    _.Display($"NUM OCORR - {V0CHIS_NUMOCOR}");

                    /*" -1091- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1092- ELSE */
                }

            }
            else
            {


                /*" -1092- ADD +1 TO AC-I-V0COSSEGHISP. */
                AREA_DE_WORK.AC_I_V0COSSEGHISP.Value = AREA_DE_WORK.AC_I_V0COSSEGHISP + +1;
            }


        }

        [StopWatch]
        /*" R1900-00-INSERT-V0COSEG-HSTPRM-DB-INSERT-1 */
        public void R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1()
        {
            /*" -1065- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V0CHIS-COD-EMP , :V0CHIS-CONGENER , :V0CHIS-NUM-APOL , :V0CHIS-NRENDOS , :V0CHIS-NRPARCEL , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DTMOVTO , :V0CHIS-TIPSGU , :V0CHIS-PRM-TAR , :V0CHIS-VAL-DESC , :V0CHIS-VLPRMLIQ , :V0CHIS-VLADIFRA , :V0CHIS-VLCOMIS , :V0CHIS-VLPRMTOT , CURRENT TIMESTAMP, :V0CHIS-DTQITBCO:VIND-DAT-QTBC, :V0CHIS-SIT-FINANC:VIND-SIT-FINC, :V0CHIS-SIT-LIBRECUP:VIND-SIT-LIBR, :V0CHIS-NUMOCOR:VIND-NUM-OCOR) END-EXEC. */

            var r1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1 = new R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1()
            {
                V0CHIS_COD_EMP = V0CHIS_COD_EMP.ToString(),
                V0CHIS_CONGENER = V0CHIS_CONGENER.ToString(),
                V0CHIS_NUM_APOL = V0CHIS_NUM_APOL.ToString(),
                V0CHIS_NRENDOS = V0CHIS_NRENDOS.ToString(),
                V0CHIS_NRPARCEL = V0CHIS_NRPARCEL.ToString(),
                V0CHIS_OCORHIST = V0CHIS_OCORHIST.ToString(),
                V0CHIS_OPERACAO = V0CHIS_OPERACAO.ToString(),
                V0CHIS_DTMOVTO = V0CHIS_DTMOVTO.ToString(),
                V0CHIS_TIPSGU = V0CHIS_TIPSGU.ToString(),
                V0CHIS_PRM_TAR = V0CHIS_PRM_TAR.ToString(),
                V0CHIS_VAL_DESC = V0CHIS_VAL_DESC.ToString(),
                V0CHIS_VLPRMLIQ = V0CHIS_VLPRMLIQ.ToString(),
                V0CHIS_VLADIFRA = V0CHIS_VLADIFRA.ToString(),
                V0CHIS_VLCOMIS = V0CHIS_VLCOMIS.ToString(),
                V0CHIS_VLPRMTOT = V0CHIS_VLPRMTOT.ToString(),
                V0CHIS_DTQITBCO = V0CHIS_DTQITBCO.ToString(),
                VIND_DAT_QTBC = VIND_DAT_QTBC.ToString(),
                V0CHIS_SIT_FINANC = V0CHIS_SIT_FINANC.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                V0CHIS_SIT_LIBRECUP = V0CHIS_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V0CHIS_NUMOCOR = V0CHIS_NUMOCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1.Execute(r1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-V0COSSEG-PREM-SECTION */
        private void R2000_00_UPDATE_V0COSSEG_PREM_SECTION()
        {
            /*" -1105- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1117- PERFORM R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1 */

            R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1();

            /*" -1120- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1121- DISPLAY 'R2000 - ERRO NO UPDATE DA V0COSSEG-PREM' */
                _.Display($"R2000 - ERRO NO UPDATE DA V0COSSEG-PREM");

                /*" -1122- DISPLAY 'CONGENER  - ' V0COSC-CODLIDER */
                _.Display($"CONGENER  - {V0COSC_CODLIDER}");

                /*" -1123- DISPLAY 'NUM ORDEM - ' V0COSC-ORDLIDER */
                _.Display($"NUM ORDEM - {V0COSC_ORDLIDER}");

                /*" -1124- DISPLAY 'APOLICE   - ' V0ENDO-NUM-APOL */
                _.Display($"APOLICE   - {V0ENDO_NUM_APOL}");

                /*" -1125- DISPLAY 'ENDOSSO   - ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   - {V0ENDO_NRENDOS}");

                /*" -1126- DISPLAY 'PARCELA   - ' V0PARC-NRPARCEL */
                _.Display($"PARCELA   - {V0PARC_NRPARCEL}");

                /*" -1127- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1128- ELSE */
            }
            else
            {


                /*" -1128- ADD 1 TO AC-U-V0COSSEGPREM. */
                AREA_DE_WORK.AC_U_V0COSSEGPREM.Value = AREA_DE_WORK.AC_U_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-V0COSSEG-PREM-DB-UPDATE-1 */
        public void R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1()
        {
            /*" -1117- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET SITUACAO = :WHOST-SITUACAO, SIT_CONGENERE = :WHOST-SITCONG, TIMESTAMP = CURRENT TIMESTAMP, OCORHIST = :WHOST-OCORHIST WHERE CONGENER = :V0COSC-CODLIDER AND NUM_APOLICE = :V0ENDO-NUM-APOL AND NRENDOS = :V0ENDO-NRENDOS AND NRPARCEL = :V0PARC-NRPARCEL AND TIPSGU = '0' AND NUM_ORDEM = :V0COSC-ORDLIDER END-EXEC. */

            var r2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1()
            {
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                WHOST_OCORHIST = WHOST_OCORHIST.ToString(),
                WHOST_SITCONG = WHOST_SITCONG.ToString(),
                V0COSC_CODLIDER = V0COSC_CODLIDER.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0COSC_ORDLIDER = V0COSC_ORDLIDER.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
            };

            R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-INTEGRIDADE-SECTION */
        private void R3000_00_PROCESSA_INTEGRIDADE_SECTION()
        {
            /*" -1141- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -1143- MOVE ZEROS TO WULTM-NUMOCOR. */
            _.Move(0, AREA_DE_WORK.WULTM_NUMOCOR);

            /*" -1145- PERFORM R3100-00-DECLARE-V1HISTOPARC. */

            R3100_00_DECLARE_V1HISTOPARC_SECTION();

            /*" -1147- PERFORM R3200-00-FETCH-V1HISTOPARC. */

            R3200_00_FETCH_V1HISTOPARC_SECTION();

            /*" -1150- PERFORM R3300-00-PROCESSA-DOCUMENTO UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty()))
            {

                R3300_00_PROCESSA_DOCUMENTO_SECTION();
            }

            /*" -1150- MOVE WULTM-NUMOCOR TO WHOST-OCORHIST. */
            _.Move(AREA_DE_WORK.WULTM_NUMOCOR, WHOST_OCORHIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DECLARE-V1HISTOPARC-SECTION */
        private void R3100_00_DECLARE_V1HISTOPARC_SECTION()
        {
            /*" -1163- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -1194- PERFORM R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1 */

            R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();

            /*" -1196- PERFORM R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1 */

            R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1();

            /*" -1199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1200- DISPLAY 'R3100 - ERRO NO DECLARE DA V1HISTOPARC' */
                _.Display($"R3100 - ERRO NO DECLARE DA V1HISTOPARC");

                /*" -1201- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1202- ELSE */
            }
            else
            {


                /*" -1202- MOVE SPACES TO WFIM-V1HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V1HISTOPARC);
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-V1HISTOPARC-DB-OPEN-1 */
        public void R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1()
        {
            /*" -1196- EXEC SQL OPEN V1HISTOPARC END-EXEC. */

            V1HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-FETCH-V1HISTOPARC-SECTION */
        private void R3200_00_FETCH_V1HISTOPARC_SECTION()
        {
            /*" -1215- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -1236- PERFORM R3200_00_FETCH_V1HISTOPARC_DB_FETCH_1 */

            R3200_00_FETCH_V1HISTOPARC_DB_FETCH_1();

            /*" -1239- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1240- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1241- MOVE 'S' TO WFIM-V1HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V1HISTOPARC);

                    /*" -1241- PERFORM R3200_00_FETCH_V1HISTOPARC_DB_CLOSE_1 */

                    R3200_00_FETCH_V1HISTOPARC_DB_CLOSE_1();

                    /*" -1243- ELSE */
                }
                else
                {


                    /*" -1244- DISPLAY 'R3200 - ERRO NO FETCH DA V1HISTOPARC' */
                    _.Display($"R3200 - ERRO NO FETCH DA V1HISTOPARC");

                    /*" -1245- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1246- ELSE */
                }

            }
            else
            {


                /*" -1246- ADD 1 TO AC-L-V1HISTOPARC. */
                AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;
            }


        }

        [StopWatch]
        /*" R3200-00-FETCH-V1HISTOPARC-DB-FETCH-1 */
        public void R3200_00_FETCH_V1HISTOPARC_DB_FETCH_1()
        {
            /*" -1236- EXEC SQL FETCH V1HISTOPARC INTO :V1HISP-NUM-APOL , :V1HISP-NRENDOS , :V1HISP-NRPARCEL , :V1HISP-OCORHIST , :V1HISP-OPERACAO , :V1HISP-DTMOVTO , :V1HISP-PRM-TAR , :V1HISP-VAL-DESC , :V1HISP-VLPRMLIQ , :V1HISP-VLADIFRA , :V1HISP-VLCUSEMI , :V1HISP-VLIOCC , :V1HISP-VLPRMTOT , :V1HISP-VLPREMIO , :V1HISP-DTVENCTO , :V1HISP-BCOCOBR , :V1HISP-AGECOBR , :V1HISP-NRAVISO , :V1HISP-NRENDOCA , :V1HISP-DTQITBCO:VIND-DAT-QTBC END-EXEC. */

            if (V1HISTOPARC.Fetch())
            {
                _.Move(V1HISTOPARC.V1HISP_NUM_APOL, V1HISP_NUM_APOL);
                _.Move(V1HISTOPARC.V1HISP_NRENDOS, V1HISP_NRENDOS);
                _.Move(V1HISTOPARC.V1HISP_NRPARCEL, V1HISP_NRPARCEL);
                _.Move(V1HISTOPARC.V1HISP_OCORHIST, V1HISP_OCORHIST);
                _.Move(V1HISTOPARC.V1HISP_OPERACAO, V1HISP_OPERACAO);
                _.Move(V1HISTOPARC.V1HISP_DTMOVTO, V1HISP_DTMOVTO);
                _.Move(V1HISTOPARC.V1HISP_PRM_TAR, V1HISP_PRM_TAR);
                _.Move(V1HISTOPARC.V1HISP_VAL_DESC, V1HISP_VAL_DESC);
                _.Move(V1HISTOPARC.V1HISP_VLPRMLIQ, V1HISP_VLPRMLIQ);
                _.Move(V1HISTOPARC.V1HISP_VLADIFRA, V1HISP_VLADIFRA);
                _.Move(V1HISTOPARC.V1HISP_VLCUSEMI, V1HISP_VLCUSEMI);
                _.Move(V1HISTOPARC.V1HISP_VLIOCC, V1HISP_VLIOCC);
                _.Move(V1HISTOPARC.V1HISP_VLPRMTOT, V1HISP_VLPRMTOT);
                _.Move(V1HISTOPARC.V1HISP_VLPREMIO, V1HISP_VLPREMIO);
                _.Move(V1HISTOPARC.V1HISP_DTVENCTO, V1HISP_DTVENCTO);
                _.Move(V1HISTOPARC.V1HISP_BCOCOBR, V1HISP_BCOCOBR);
                _.Move(V1HISTOPARC.V1HISP_AGECOBR, V1HISP_AGECOBR);
                _.Move(V1HISTOPARC.V1HISP_NRAVISO, V1HISP_NRAVISO);
                _.Move(V1HISTOPARC.V1HISP_NRENDOCA, V1HISP_NRENDOCA);
                _.Move(V1HISTOPARC.V1HISP_DTQITBCO, V1HISP_DTQITBCO);
                _.Move(V1HISTOPARC.VIND_DAT_QTBC, VIND_DAT_QTBC);
            }

        }

        [StopWatch]
        /*" R3200-00-FETCH-V1HISTOPARC-DB-CLOSE-1 */
        public void R3200_00_FETCH_V1HISTOPARC_DB_CLOSE_1()
        {
            /*" -1241- EXEC SQL CLOSE V1HISTOPARC END-EXEC */

            V1HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-PROCESSA-DOCUMENTO-SECTION */
        private void R3300_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -1259- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WABEND.WNR_EXEC_SQL);

            /*" -1261- MOVE ZEROS TO WHOST-OCORHIST. */
            _.Move(0, WHOST_OCORHIST);

            /*" -1263- PERFORM R3400-00-SELECT-V1PARCELA. */

            R3400_00_SELECT_V1PARCELA_SECTION();

            /*" -1269- PERFORM R3500-00-PROCESSA-PARCELA UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES OR V1HISP-NUM-APOL NOT EQUAL V0ENDO-NUM-APOL OR V1HISP-NRENDOS NOT EQUAL V0ENDO-NRENDOS OR V1HISP-NRPARCEL NOT EQUAL V1PARC-NRPARCEL. */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty() || V1HISP_NUM_APOL != V0ENDO_NUM_APOL || V1HISP_NRENDOS != V0ENDO_NRENDOS || V1HISP_NRPARCEL != V1PARC_NRPARCEL))
            {

                R3500_00_PROCESSA_PARCELA_SECTION();
            }

            /*" -1270- IF V1PARC-NRPARCEL = V0PARC-NRPARCEL */

            if (V1PARC_NRPARCEL == V0PARC_NRPARCEL)
            {

                /*" -1272- MOVE WHOST-OCORHIST TO WULTM-NUMOCOR. */
                _.Move(WHOST_OCORHIST, AREA_DE_WORK.WULTM_NUMOCOR);
            }


            /*" -1273- IF WHOST-OCORHIST > 01 */

            if (WHOST_OCORHIST > 01)
            {

                /*" -1273- PERFORM R4000-00-UPDATE-V0COSSEG-PREM. */

                R4000_00_UPDATE_V0COSSEG_PREM_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-SELECT-V1PARCELA-SECTION */
        private void R3400_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -1286- MOVE '340' TO WNR-EXEC-SQL. */
            _.Move("340", WABEND.WNR_EXEC_SQL);

            /*" -1311- PERFORM R3400_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R3400_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -1314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1315- DISPLAY 'R3400 - ERRO NO SELECT DA V1PARCELA' */
                _.Display($"R3400 - ERRO NO SELECT DA V1PARCELA");

                /*" -1316- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1317- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1318- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1318- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3400-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R3400_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -1311- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , OTNCUSTO , OTNIOF , OTNTOTAL INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-PRM-TAR , :V1PARC-VAL-DESC , :V1PARC-OTNPRLIQ , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO , :V1PARC-OTNIOF , :V1PARC-OTNTOTAL FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DESC, V1PARC_VAL_DESC);
                _.Move(executed_1.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(executed_1.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(executed_1.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-PROCESSA-PARCELA-SECTION */
        private void R3500_00_PROCESSA_PARCELA_SECTION()
        {
            /*" -1331- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WABEND.WNR_EXEC_SQL);

            /*" -1336- MOVE ZEROS TO WPRM-TOT WPRM-TOT-IX WVLRCOMIS WVLRCOMIS-IX. */
            _.Move(0, AREA_DE_WORK.WPRM_TOT, AREA_DE_WORK.WPRM_TOT_IX, AREA_DE_WORK.WVLRCOMIS, AREA_DE_WORK.WVLRCOMIS_IX);

            /*" -1342- COMPUTE WVLRCOMIS ROUNDED = (V1HISP-PRM-TAR + V1HISP-VLADIFRA - V1HISP-VAL-DESC) * V0COSC-PCCOMCOS / 100. */
            AREA_DE_WORK.WVLRCOMIS.Value = (V1HISP_PRM_TAR + V1HISP_VLADIFRA - V1HISP_VAL_DESC) * V0COSC_PCCOMCOS / 100f;

            /*" -1343- IF V0ENDO-CORRECAO = '2' OR '4' */

            if (V0ENDO_CORRECAO.In("2", "4"))
            {

                /*" -1348- COMPUTE WVLRCOMIS-IX ROUNDED = (V1PARC-PRM-TAR + V1PARC-OTNADFRA - V1PARC-VAL-DESC) * V0COSC-PCCOMCOS / 100 */
                AREA_DE_WORK.WVLRCOMIS_IX.Value = (V1PARC_PRM_TAR + V1PARC_OTNADFRA - V1PARC_VAL_DESC) * V0COSC_PCCOMCOS / 100f;

                /*" -1349- ELSE */
            }
            else
            {


                /*" -1351- MOVE WVLRCOMIS TO WVLRCOMIS-IX. */
                _.Move(AREA_DE_WORK.WVLRCOMIS, AREA_DE_WORK.WVLRCOMIS_IX);
            }


            /*" -1355- COMPUTE WPRM-TOT = V1HISP-VLPRMLIQ + V1HISP-VLADIFRA - WVLRCOMIS. */
            AREA_DE_WORK.WPRM_TOT.Value = V1HISP_VLPRMLIQ + V1HISP_VLADIFRA - AREA_DE_WORK.WVLRCOMIS;

            /*" -1359- COMPUTE WPRM-TOT-IX = V1PARC-OTNPRLIQ + V1PARC-OTNADFRA - WVLRCOMIS-IX. */
            AREA_DE_WORK.WPRM_TOT_IX.Value = V1PARC_OTNPRLIQ + V1PARC_OTNADFRA - AREA_DE_WORK.WVLRCOMIS_IX;

            /*" -1360- IF V1HISP-OPERACAO < 0200 */

            if (V1HISP_OPERACAO < 0200)
            {

                /*" -1361- PERFORM R3700-00-MONTA-V0COSSEG-PREM */

                R3700_00_MONTA_V0COSSEG_PREM_SECTION();

                /*" -1362- PERFORM R1700-00-INSERT-V0COSSEG-PREM */

                R1700_00_INSERT_V0COSSEG_PREM_SECTION();

                /*" -1363- PERFORM R3800-00-MONTA-V0COSEG-HSTPRM */

                R3800_00_MONTA_V0COSEG_HSTPRM_SECTION();

                /*" -1364- PERFORM R1900-00-INSERT-V0COSEG-HSTPRM */

                R1900_00_INSERT_V0COSEG_HSTPRM_SECTION();

                /*" -1365- ELSE */
            }
            else
            {


                /*" -1366- PERFORM R3600-00-VERIFICA-SITUACAO */

                R3600_00_VERIFICA_SITUACAO_SECTION();

                /*" -1367- PERFORM R3800-00-MONTA-V0COSEG-HSTPRM */

                R3800_00_MONTA_V0COSEG_HSTPRM_SECTION();

                /*" -1369- PERFORM R1900-00-INSERT-V0COSEG-HSTPRM. */

                R1900_00_INSERT_V0COSEG_HSTPRM_SECTION();
            }


            /*" -1369- PERFORM R3200-00-FETCH-V1HISTOPARC. */

            R3200_00_FETCH_V1HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-VERIFICA-SITUACAO-SECTION */
        private void R3600_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -1382- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", WABEND.WNR_EXEC_SQL);

            /*" -1385- IF (V1HISP-OPERACAO > 199 AND V1HISP-OPERACAO < 300) OR V1HISP-OPERACAO = 802 */

            if ((V1HISP_OPERACAO > 199 && V1HISP_OPERACAO < 300) || V1HISP_OPERACAO == 802)
            {

                /*" -1386- MOVE '1' TO WHOST-SITUACAO */
                _.Move("1", WHOST_SITUACAO);

                /*" -1387- MOVE '1' TO WHOST-SITCONG */
                _.Move("1", WHOST_SITCONG);

                /*" -1388- ELSE */
            }
            else
            {


                /*" -1391- IF (V1HISP-OPERACAO > 299 AND V1HISP-OPERACAO < 400) OR V1HISP-OPERACAO = 803 */

                if ((V1HISP_OPERACAO > 299 && V1HISP_OPERACAO < 400) || V1HISP_OPERACAO == 803)
                {

                    /*" -1392- MOVE '0' TO WHOST-SITUACAO */
                    _.Move("0", WHOST_SITUACAO);

                    /*" -1393- MOVE '0' TO WHOST-SITCONG */
                    _.Move("0", WHOST_SITCONG);

                    /*" -1394- ELSE */
                }
                else
                {


                    /*" -1397- IF (V1HISP-OPERACAO > 399 AND V1HISP-OPERACAO < 500) OR V1HISP-OPERACAO = 804 */

                    if ((V1HISP_OPERACAO > 399 && V1HISP_OPERACAO < 500) || V1HISP_OPERACAO == 804)
                    {

                        /*" -1398- MOVE '2' TO WHOST-SITUACAO */
                        _.Move("2", WHOST_SITUACAO);

                        /*" -1399- MOVE '2' TO WHOST-SITCONG */
                        _.Move("2", WHOST_SITCONG);

                        /*" -1400- ELSE */
                    }
                    else
                    {


                        /*" -1403- IF (V1HISP-OPERACAO > 499 AND V1HISP-OPERACAO < 600) OR V1HISP-OPERACAO = 801 OR 805 */

                        if ((V1HISP_OPERACAO > 499 && V1HISP_OPERACAO < 600) || V1HISP_OPERACAO.In("801", "805"))
                        {

                            /*" -1404- MOVE '0' TO WHOST-SITUACAO */
                            _.Move("0", WHOST_SITUACAO);

                            /*" -1405- MOVE '0' TO WHOST-SITCONG */
                            _.Move("0", WHOST_SITCONG);

                            /*" -1406- ELSE */
                        }
                        else
                        {


                            /*" -1407- DISPLAY 'R3600 - OPERACAO NAO PREVISTA' */
                            _.Display($"R3600 - OPERACAO NAO PREVISTA");

                            /*" -1408- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                            _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                            /*" -1409- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                            _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                            /*" -1410- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                            _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                            /*" -1411- DISPLAY 'OC HIST  - ' V1HISP-OCORHIST */
                            _.Display($"OC HIST  - {V1HISP_OCORHIST}");

                            /*" -1412- DISPLAY 'OPERACAO - ' V1HISP-OPERACAO */
                            _.Display($"OPERACAO - {V1HISP_OPERACAO}");

                            /*" -1412- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-MONTA-V0COSSEG-PREM-SECTION */
        private void R3700_00_MONTA_V0COSSEG_PREM_SECTION()
        {
            /*" -1425- MOVE '370' TO WNR-EXEC-SQL. */
            _.Move("370", WABEND.WNR_EXEC_SQL);

            /*" -1426- MOVE ZEROS TO V0CPRE-COD-EMP. */
            _.Move(0, V0CPRE_COD_EMP);

            /*" -1427- MOVE '0' TO V0CPRE-TIPSGU. */
            _.Move("0", V0CPRE_TIPSGU);

            /*" -1428- MOVE V0COSC-CODLIDER TO V0CPRE-CONGENER. */
            _.Move(V0COSC_CODLIDER, V0CPRE_CONGENER);

            /*" -1429- MOVE V0COSC-ORDLIDER TO V0CPRE-NUM-ORDEM. */
            _.Move(V0COSC_ORDLIDER, V0CPRE_NUM_ORDEM);

            /*" -1430- MOVE V1HISP-NUM-APOL TO V0CPRE-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V0CPRE_NUM_APOL);

            /*" -1431- MOVE V1HISP-NRENDOS TO V0CPRE-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V0CPRE_NRENDOS);

            /*" -1432- MOVE V1HISP-NRPARCEL TO V0CPRE-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V0CPRE_NRPARCEL);

            /*" -1433- MOVE V1PARC-PRM-TAR TO V0CPRE-PRM-TAR-IX. */
            _.Move(V1PARC_PRM_TAR, V0CPRE_PRM_TAR_IX);

            /*" -1434- MOVE V1PARC-VAL-DESC TO V0CPRE-VAL-DES-IX. */
            _.Move(V1PARC_VAL_DESC, V0CPRE_VAL_DES_IX);

            /*" -1435- MOVE V1PARC-OTNPRLIQ TO V0CPRE-OTNPRLIQ. */
            _.Move(V1PARC_OTNPRLIQ, V0CPRE_OTNPRLIQ);

            /*" -1436- MOVE V1PARC-OTNADFRA TO V0CPRE-OTNADFRA. */
            _.Move(V1PARC_OTNADFRA, V0CPRE_OTNADFRA);

            /*" -1437- MOVE WVLRCOMIS-IX TO V0CPRE-VLCOMISIX. */
            _.Move(AREA_DE_WORK.WVLRCOMIS_IX, V0CPRE_VLCOMISIX);

            /*" -1438- MOVE WPRM-TOT-IX TO V0CPRE-OTNTOTAL. */
            _.Move(AREA_DE_WORK.WPRM_TOT_IX, V0CPRE_OTNTOTAL);

            /*" -1439- MOVE '0' TO V0CPRE-SITUACAO. */
            _.Move("0", V0CPRE_SITUACAO);

            /*" -1440- MOVE '0' TO V0CPRE-SIT-CONG. */
            _.Move("0", V0CPRE_SIT_CONG);

            /*" -1442- MOVE 01 TO V0CPRE-OCORHIST. */
            _.Move(01, V0CPRE_OCORHIST);

            /*" -1442- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-MONTA-V0COSEG-HSTPRM-SECTION */
        private void R3800_00_MONTA_V0COSEG_HSTPRM_SECTION()
        {
            /*" -1455- MOVE '380' TO WNR-EXEC-SQL. */
            _.Move("380", WABEND.WNR_EXEC_SQL);

            /*" -1456- MOVE ZEROS TO V0CHIS-COD-EMP. */
            _.Move(0, V0CHIS_COD_EMP);

            /*" -1457- MOVE V0COSC-CODLIDER TO V0CHIS-CONGENER. */
            _.Move(V0COSC_CODLIDER, V0CHIS_CONGENER);

            /*" -1458- MOVE V1HISP-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -1459- MOVE V1HISP-NRENDOS TO V0CHIS-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V0CHIS_NRENDOS);

            /*" -1461- MOVE V1HISP-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -1463- COMPUTE WHOST-OCORHIST = WHOST-OCORHIST + 1. */
            WHOST_OCORHIST.Value = WHOST_OCORHIST + 1;

            /*" -1465- MOVE WHOST-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(WHOST_OCORHIST, V0CHIS_OCORHIST);

            /*" -1466- MOVE V1HISP-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(V1HISP_OPERACAO, V0CHIS_OPERACAO);

            /*" -1467- MOVE V1HISP-DTMOVTO TO V0CHIS-DTMOVTO. */
            _.Move(V1HISP_DTMOVTO, V0CHIS_DTMOVTO);

            /*" -1468- MOVE '0' TO V0CHIS-TIPSGU. */
            _.Move("0", V0CHIS_TIPSGU);

            /*" -1469- MOVE V1HISP-PRM-TAR TO V0CHIS-PRM-TAR. */
            _.Move(V1HISP_PRM_TAR, V0CHIS_PRM_TAR);

            /*" -1470- MOVE V1HISP-VAL-DESC TO V0CHIS-VAL-DESC. */
            _.Move(V1HISP_VAL_DESC, V0CHIS_VAL_DESC);

            /*" -1471- MOVE V1HISP-VLPRMLIQ TO V0CHIS-VLPRMLIQ. */
            _.Move(V1HISP_VLPRMLIQ, V0CHIS_VLPRMLIQ);

            /*" -1472- MOVE V1HISP-VLADIFRA TO V0CHIS-VLADIFRA. */
            _.Move(V1HISP_VLADIFRA, V0CHIS_VLADIFRA);

            /*" -1473- MOVE WVLRCOMIS TO V0CHIS-VLCOMIS. */
            _.Move(AREA_DE_WORK.WVLRCOMIS, V0CHIS_VLCOMIS);

            /*" -1475- MOVE WPRM-TOT TO V0CHIS-VLPRMTOT. */
            _.Move(AREA_DE_WORK.WPRM_TOT, V0CHIS_VLPRMTOT);

            /*" -1477- IF V1HISP-OPERACAO > 0199 AND V1HISP-OPERACAO < 0400 */

            if (V1HISP_OPERACAO > 0199 && V1HISP_OPERACAO < 0400)
            {

                /*" -1478- MOVE +1 TO VIND-DAT-QTBC */
                _.Move(+1, VIND_DAT_QTBC);

                /*" -1479- MOVE V1HISP-DTQITBCO TO V0CHIS-DTQITBCO */
                _.Move(V1HISP_DTQITBCO, V0CHIS_DTQITBCO);

                /*" -1480- ELSE */
            }
            else
            {


                /*" -1481- MOVE -1 TO VIND-DAT-QTBC */
                _.Move(-1, VIND_DAT_QTBC);

                /*" -1483- MOVE SPACES TO V0CHIS-DTQITBCO. */
                _.Move("", V0CHIS_DTQITBCO);
            }


            /*" -1486- MOVE '0' TO V0CHIS-SIT-LIBRECUP V0CHIS-SIT-FINANC. */
            _.Move("0", V0CHIS_SIT_LIBRECUP, V0CHIS_SIT_FINANC);

            /*" -1489- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -1491- MOVE WHOST-OCORHIST TO V0CHIS-NUMOCOR. */
            _.Move(WHOST_OCORHIST, V0CHIS_NUMOCOR);

            /*" -1491- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-V0COSSEG-PREM-SECTION */
        private void R4000_00_UPDATE_V0COSSEG_PREM_SECTION()
        {
            /*" -1504- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -1516- PERFORM R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1 */

            R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1();

            /*" -1519- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1520- DISPLAY 'R4000 - ERRO NO UPDATE DA V0COSSEG-PREM' */
                _.Display($"R4000 - ERRO NO UPDATE DA V0COSSEG-PREM");

                /*" -1521- DISPLAY 'CONGENER  - ' V0COSC-CODLIDER */
                _.Display($"CONGENER  - {V0COSC_CODLIDER}");

                /*" -1522- DISPLAY 'NUM ORDEM - ' V0COSC-ORDLIDER */
                _.Display($"NUM ORDEM - {V0COSC_ORDLIDER}");

                /*" -1523- DISPLAY 'APOLICE   - ' V0ENDO-NUM-APOL */
                _.Display($"APOLICE   - {V0ENDO_NUM_APOL}");

                /*" -1524- DISPLAY 'ENDOSSO   - ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   - {V0ENDO_NRENDOS}");

                /*" -1525- DISPLAY 'PARCELA   - ' V1PARC-NRPARCEL */
                _.Display($"PARCELA   - {V1PARC_NRPARCEL}");

                /*" -1526- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1527- ELSE */
            }
            else
            {


                /*" -1527- ADD 1 TO AC-U-V0COSSEGPREM. */
                AREA_DE_WORK.AC_U_V0COSSEGPREM.Value = AREA_DE_WORK.AC_U_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-V0COSSEG-PREM-DB-UPDATE-1 */
        public void R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1()
        {
            /*" -1516- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET SITUACAO = :WHOST-SITUACAO, SIT_CONGENERE = :WHOST-SITCONG, TIMESTAMP = CURRENT TIMESTAMP, OCORHIST = :WHOST-OCORHIST WHERE CONGENER = :V0COSC-CODLIDER AND NUM_APOLICE = :V0ENDO-NUM-APOL AND NRENDOS = :V0ENDO-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL AND TIPSGU = '0' AND NUM_ORDEM = :V0COSC-ORDLIDER END-EXEC. */

            var r4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1()
            {
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                WHOST_OCORHIST = WHOST_OCORHIST.ToString(),
                WHOST_SITCONG = WHOST_SITCONG.ToString(),
                V0COSC_CODLIDER = V0COSC_CODLIDER.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V0COSC_ORDLIDER = V0COSC_ORDLIDER.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
            };

            R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1541- MOVE V0SIST-DTMOVABE TO WDATA-AUX. */
            _.Move(V0SIST_DTMOVABE, AREA_DE_WORK.WDATA_AUX);

            /*" -1542- MOVE WDATA-DIA-AUX TO WDATA-DIA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDATA_DIA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DIA_EDT);

            /*" -1543- MOVE WDATA-MES-AUX TO WDATA-MES-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDATA_MES_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MES_EDT);

            /*" -1545- MOVE WDATA-ANO-AUX TO WDATA-ANO-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDATA_ANO_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_ANO_EDT);

            /*" -1546- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1547- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1548- DISPLAY '*   AC0005B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0005B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -1549- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -1550- DISPLAY '*                  COSSEGURO ACEITO        *' . */
            _.Display($"*                  COSSEGURO ACEITO        *");

            /*" -1551- DISPLAY '*                  --------- ------        *' . */
            _.Display($"*                  --------- ------        *");

            /*" -1552- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1553- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1555- DISPLAY '*              ' WDATA-EDIT '                    *' . */

            $"*              {AREA_DE_WORK.WDATA_EDIT}                    *"
            .Display();

            /*" -1556- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1556- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1571- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1573- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1573- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1577- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1577- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}