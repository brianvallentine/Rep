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
using Sias.VidaEmGrupo.DB2.VG0817B;

namespace Code
{
    public class VG0817B
    {
        public bool IsCall { get; set; }

        public VG0817B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   GERA SOLICITACAO NA V0RELATORIOS PARA CALCULO DO PRO-LABORE  *      */
        /*"      *      DAS LOJAS MARISA.                                         *      */
        /*"      *              EM 30/04/04 - FREDERICO FONSECA                   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 000                                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  12/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0808                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  V0APOC-DTINIVIG                    PIC  X(10).*/
        public StringBasis V0APOC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0APOC-DTTERVIG                    PIC  X(10).*/
        public StringBasis V0APOC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SUBG-TIPO-FATURAMENTO            PIC  X(01).*/
        public StringBasis V0SUBG_TIPO_FATURAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0SUBG-PERI-FATURAMENTO            PIC S9(04)    COMP.*/
        public IntBasis V0SUBG_PERI_FATURAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-DTVENCTO                    PIC  X(10).*/
        public StringBasis V0RELA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-PRMAP                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0RELA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RELA-PRMVG                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0RELA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RELA-PRMTOT                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0RELA_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RELA-PRMTOTVG                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0RELA_PRMTOTVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RELA-SITUACAO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0RELA_SITUACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RELA-DTINIVIG                    PIC  X(10).*/
        public StringBasis V0RELA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-DTTERVIG                    PIC  X(10).*/
        public StringBasis V0RELA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-DTTERVIG-CALC               PIC  X(10).*/
        public StringBasis V0RELA_DTTERVIG_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-PERIFAT                     PIC S9(04)    COMP.*/
        public IntBasis V0RELA_PERIFAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PERI-INICIAL                PIC  X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-PERI-FINAL                  PIC  X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  VIND-OPCAOCAP                      PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NRPARCEL                      PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTMOVTO                       PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-TEM-SAF                       PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-TEM-CDG                       PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RISCO                         PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-ESTR-COBR                     PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0SIST-DTMOVABE                    PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0CCOR-OPCAOCAP                    PIC S9(004) COMP VALUE +0*/
        public IntBasis V0CCOR_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CCOR-NRPARCEL                    PIC S9(004) COMP VALUE +0*/
        public IntBasis V0CCOR_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PARCELCAP                    PIC S9(004) COMP VALUE +0*/
        public IntBasis WHOST_PARCELCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-SITUACAO                     PIC  X(001).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0MOVC-NRTIT                       PIC S9(013)    COMP-3.*/
        public IntBasis V0MOVC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0MOVC-DTQITBCO                    PIC  X(010).*/
        public StringBasis V0MOVC_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0MOVC-VALTIT                      PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0MOVC_VALTIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0MOVC-SITUACAO                    PIC  X(001).*/
        public StringBasis V0MOVC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0MOVC-TIMESTAMP                   PIC  X(026).*/
        public StringBasis V0MOVC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  V0MOVC-BCOAVISO                    PIC S9(004) COMP.*/
        public IntBasis V0MOVC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0MOVC-AGEAVISO                    PIC S9(004) COMP.*/
        public IntBasis V0MOVC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0MOVC-NRAVISO                     PIC S9(009) COMP.*/
        public IntBasis V0MOVC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0PARC-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PARC-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PARC-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PARC-PRMTOT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PARC-PRMTOTVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMTOT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-QTTITCAP                  PIC S9(04)    COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTVA-VLCOBADIC                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_VLCOBADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-PRMVG                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-PRMAP                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RCDG-DTREFER                   PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RCDG-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0RSAF-DTREFER                   PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RSAF-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NRPARCE                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_NRPARCE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0PROP-NRMATRFUN                 PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PROP-INRMATRFUN                PIC S9(04)    COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-QTDPARATZ                 PIC S9(04)    COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-TEM-SAF                   PIC  X(01).*/
        public StringBasis V0PROP_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PROP_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-RISCO                     PIC  X(01).*/
        public StringBasis V0PROP_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis V0PROP_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-ESTR-COBR                 PIC  X(10).*/
        public StringBasis V0PROP_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0CDGC-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SAFC-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0HCOB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0HCOB-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-NRTIT                     PIC S9(013)   COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0CMPT-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0CMPT_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CMPT-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0CMPT_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CMPT-VLPRMDIF                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CMPT_VLPRMDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTB-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-PRMDEVVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDEVAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFPA-NRPARCELDIF              PIC S9(04)    COMP.*/
        public IntBasis V0DIFPA_NRPARCELDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFPA-DTVENCTO                 PIC  X(10).*/
        public StringBasis V0DIFPA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0OPCP-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    V0PLCO-CODPDT                  PIC S9(009) COMP.*/
        public IntBasis V0PLCO_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0PDTV-OCORHIST                PIC S9(004) COMP.*/
        public IntBasis V0PDTV_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SEGU-NUM-ITEM                PIC S9(009) COMP.*/
        public IntBasis V0SEGU_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    VIND-CODEMP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-SITUACAO               PIC  X(001).*/
        public StringBasis WS_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VG0817B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VG0817B_WS_WORK_AREAS();
        public class VG0817B_WS_WORK_AREAS : VarBasis
        {
            /*"  03            WS-EOF             PIC  9(001)    VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WS-EOF-D           PIC  9(001)    VALUE 0.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WS-EOC             PIC  9(001)    VALUE 0.*/
            public IntBasis WS_EOC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WS-EOP             PIC  9(001)    VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            ACC-SOL-PRO-LAB    PIC  9(006)    VALUE 0.*/
            public IntBasis ACC_SOL_PRO_LAB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            AC-LIDOS           PIC  9(006)    VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            AC-PARCEL          PIC  9(006)    VALUE 0.*/
            public IntBasis AC_PARCEL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            AC-FOLLOWUP        PIC  9(006)    VALUE 0.*/
            public IntBasis AC_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WS-DIFERENCA       PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  03            WS-PC-VG           PIC  9(03)V9(7).*/
            public DoubleBasis WS_PC_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)."), 7);
            /*"  03            WS-PCT-COB-VG      PIC  9(03)V9(7).*/
            public DoubleBasis WS_PCT_COB_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)."), 7);
            /*"  03            WS-PCT-COB-AP      PIC  9(03)V9(7).*/
            public DoubleBasis WS_PCT_COB_AP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)."), 7);
            /*"  03 DATA-SQL.*/
            public VG0817B_DATA_SQL DATA_SQL { get; set; } = new VG0817B_DATA_SQL();
            public class VG0817B_DATA_SQL : VarBasis
            {
                /*"     05 ANO-SQL    PIC 9(04).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     05 FILLER     PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     05 MES-SQL    PIC 9(02).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     05 FILLER     PIC X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     05 DIA-SQL    PIC 9(02).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03 WS-TIME.*/
            }
            public VG0817B_WS_TIME WS_TIME { get; set; } = new VG0817B_WS_TIME();
            public class VG0817B_WS_TIME : VarBasis
            {
                /*"     05 WS-HH-TIME              PIC 9(02).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     05 WS-MM-TIME              PIC 9(02).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     05 WS-SS-TIME              PIC 9(02).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     05 WS-CC-TIME              PIC 9(02).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03 WTIME-DAY                  PIC 99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03 FILLER     REDEFINES       WTIME-DAY.*/
            private _REDEF_VG0817B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_VG0817B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_VG0817B_FILLER_2(); _.Move(WTIME_DAY, _filler_2); VarBasis.RedefinePassValue(WTIME_DAY, _filler_2, WTIME_DAY); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTIME_DAY); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG0817B_FILLER_2 : VarBasis
            {
                /*"     05 WTIME-DAYR.*/
                public VG0817B_WTIME_DAYR WTIME_DAYR { get; set; } = new VG0817B_WTIME_DAYR();
                public class VG0817B_WTIME_DAYR : VarBasis
                {
                    /*"        10 WTIME-HORA           PIC X(02).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"        10 WTIME-2PT1           PIC X(01).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10 WTIME-MINU           PIC X(02).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"        10 WTIME-2PT2           PIC X(01).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10 WTIME-SEGU           PIC X(02).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"     05 WTIME-2PT3              PIC X(01).*/

                    public VG0817B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     05 WTIME-CCSE              PIC X(02).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"01  WABEND.*/

                public _REDEF_VG0817B_FILLER_2()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
        }
        public VG0817B_WABEND WABEND { get; set; } = new VG0817B_WABEND();
        public class VG0817B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VG0817B  '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0817B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10      LOCALIZA-ABEND-1.*/
            public VG0817B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0817B_LOCALIZA_ABEND_1();
            public class VG0817B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        05    FILLER                PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        05    PARAGRAFO             PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public VG0817B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0817B_LOCALIZA_ABEND_2();
            public class VG0817B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        05    FILLER                PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        05    COMANDO               PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VG0817B_CPARCEL CPARCEL { get; set; } = new VG0817B_CPARCEL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -260- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -262- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -264- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -272- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -291- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -296- MOVE 'OPEN CPARCEL' TO COMANDO. */
            _.Move("OPEN CPARCEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -296- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -300- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -301- IF WS-EOF = 1 */

            if (WS_WORK_AREAS.WS_EOF == 1)
            {

                /*" -302- DISPLAY '*** VG0817B *** NAO HA PARCELAS GERADAS  ' */
                _.Display($"*** VG0817B *** NAO HA PARCELAS GERADAS  ");

                /*" -304- GO TO 0000-TERMINA. */

                M_0000_TERMINA(); //GOTO
                return;
            }


            /*" -305- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -307- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -312- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -315- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -317- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -320- PERFORM 0100-PROCESSA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -321- DISPLAY '-----------> TOTAIS <----------- ' . */
            _.Display($"-----------> TOTAIS <----------- ");

            /*" -322- DISPLAY 'PARCELAS LIDAS ......... ' AC-LIDOS. */
            _.Display($"PARCELAS LIDAS ......... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -323- DISPLAY 'SOLICITACOES PRO-LAB ... ' ACC-SOL-PRO-LAB. */
            _.Display($"SOLICITACOES PRO-LAB ... {WS_WORK_AREAS.ACC_SOL_PRO_LAB}");

            /*" -323- DISPLAY '-------------------------------- ' . */
            _.Display($"-------------------------------- ");

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -291- EXEC SQL DECLARE CPARCEL CURSOR FOR SELECT B.NRCERTIF, B.NRPARCEL, B.DTVENCTO, B.PRMVG + B.PRMAP, B.PRMVG, B.PRMAP, B.SITUACAO, C.TIPO_FATURAMENTO, C.PERI_FATURAMENTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PARCELVA B, SEGUROS.V0SUBGRUPO C WHERE A.NUM_APOLICE = 0107700000003 AND A.NRCERTIF = B.NRCERTIF AND A.NUM_APOLICE = C.NUM_APOLICE AND A.CODSUBES = C.COD_SUBGRUPO AND A.CODCLIEN = C.COD_CLIENTE END-EXEC. */
            CPARCEL = new VG0817B_CPARCEL(false);
            string GetQuery_CPARCEL()
            {
                var query = @$"SELECT B.NRCERTIF
							, 
							B.NRPARCEL
							, 
							B.DTVENCTO
							, 
							B.PRMVG + B.PRMAP
							, 
							B.PRMVG
							, 
							B.PRMAP
							, 
							B.SITUACAO
							, 
							C.TIPO_FATURAMENTO
							, 
							C.PERI_FATURAMENTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0PARCELVA B
							, 
							SEGUROS.V0SUBGRUPO C 
							WHERE A.NUM_APOLICE = 0107700000003 
							AND A.NRCERTIF = B.NRCERTIF 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.CODSUBES = C.COD_SUBGRUPO 
							AND A.CODCLIEN = C.COD_CLIENTE";

                return query;
            }
            CPARCEL.GetQueryEvent += GetQuery_CPARCEL;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -296- EXEC SQL OPEN CPARCEL END-EXEC. */

            CPARCEL.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -312- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -328- MOVE '0000-TERMINA' TO PARAGRAFO. */
            _.Move("0000-TERMINA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -329- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -329- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -333- DISPLAY '*** VG0817B *** TERMINO NORMAL' . */
            _.Display($"*** VG0817B *** TERMINO NORMAL");

            /*" -334- IF ACC-SOL-PRO-LAB GREATER ZEROS */

            if (WS_WORK_AREAS.ACC_SOL_PRO_LAB > 00)
            {

                /*" -335- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -336- ELSE */
            }
            else
            {


                /*" -337- DISPLAY 'NENHUMA SOLICITACAO GERADA ' */
                _.Display($"NENHUMA SOLICITACAO GERADA ");

                /*" -339- MOVE 01 TO RETURN-CODE. */
                _.Move(01, RETURN_CODE);
            }


            /*" -339- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0100-PROCESSA */
        private void M_0100_PROCESSA(bool isPerform = false)
        {
            /*" -350- MOVE '0100-PROCESSA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -352- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -356- IF V0PARC-PRMTOT EQUAL ZEROS */

            if (V0PARC_PRMTOT == 00)
            {

                /*" -358- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -362- IF V0PARC-SITUACAO NOT EQUAL '1' */

            if (V0PARC_SITUACAO != "1")
            {

                /*" -364- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -366- MOVE 'SELECT V0HISTCOBVA' TO COMANDO. */
            _.Move("SELECT V0HISTCOBVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -384- PERFORM M_0100_PROCESSA_DB_SELECT_1 */

            M_0100_PROCESSA_DB_SELECT_1();

            /*" -387- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -390- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -391- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -392- ELSE */
                }
                else
                {


                    /*" -394- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -396- MOVE 'SELECT V0PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -430- PERFORM M_0100_PROCESSA_DB_SELECT_2 */

            M_0100_PROCESSA_DB_SELECT_2();

            /*" -433- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -435- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -438- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -440- MOVE SPACES TO V0PROP-ESTR-COBR. */
                _.Move("", V0PROP_ESTR_COBR);
            }


            /*" -442- MOVE 'SELECT V0COBERPROPVA ' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -454- PERFORM M_0100_PROCESSA_DB_SELECT_3 */

            M_0100_PROCESSA_DB_SELECT_3();

            /*" -457- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -459- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -460- IF V0RELA-DTTERVIG = '9999-12-31' */

            if (V0RELA_DTTERVIG == "9999-12-31")
            {

                /*" -462- MOVE V0RELA-DTTERVIG-CALC TO V0RELA-DTTERVIG. */
                _.Move(V0RELA_DTTERVIG_CALC, V0RELA_DTTERVIG);
            }


            /*" -464- MOVE 'SELECT V0APOLCORRET  ' TO COMANDO. */
            _.Move("SELECT V0APOLCORRET  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -476- PERFORM M_0100_PROCESSA_DB_SELECT_4 */

            M_0100_PROCESSA_DB_SELECT_4();

            /*" -479- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -481- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -482- ELSE */
                }
                else
                {


                    /*" -483- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -488- ELSE */
                }

            }
            else
            {


                /*" -490- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -492- MOVE 'SELECT V0RELATORIOS  ' TO COMANDO. */
            _.Move("SELECT V0RELATORIOS  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -493- MOVE V0RELA-DTINIVIG TO V0RELA-PERI-INICIAL. */
            _.Move(V0RELA_DTINIVIG, V0RELA_PERI_INICIAL);

            /*" -495- MOVE V0RELA-DTTERVIG TO V0RELA-PERI-FINAL. */
            _.Move(V0RELA_DTTERVIG, V0RELA_PERI_FINAL);

            /*" -506- PERFORM M_0100_PROCESSA_DB_SELECT_5 */

            M_0100_PROCESSA_DB_SELECT_5();

            /*" -509- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -511- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -512- ELSE */
                }
                else
                {


                    /*" -513- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -519- ELSE */
                }

            }
            else
            {


                /*" -521- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -523- MOVE 'INSERT V0RELATORIOS  ' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -566- PERFORM M_0100_PROCESSA_DB_INSERT_1 */

            M_0100_PROCESSA_DB_INSERT_1();

            /*" -569- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -571- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -571- ADD 1 TO ACC-SOL-PRO-LAB. */
            WS_WORK_AREAS.ACC_SOL_PRO_LAB.Value = WS_WORK_AREAS.ACC_SOL_PRO_LAB + 1;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-1 */
        public void M_0100_PROCESSA_DB_SELECT_1()
        {
            /*" -384- EXEC SQL SELECT NRCERTIF, NRPARCEL, VLPRMTOT, SITUACAO, OCORHIST, CODOPER, NRTIT INTO :V0HCOB-NRCERTIF, :V0HCOB-NRPARCEL, :V0HCOB-VLPRMTOT, :V0HCOB-SITUACAO, :V0HCOB-OCORHIST, :V0HCOB-CODOPER, :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_DB_SELECT_1_Query1()
            {
                V0PARC_NRCERTIF = V0PARC_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRCERTIF, V0HCOB_NRCERTIF);
                _.Move(executed_1.V0HCOB_NRPARCEL, V0HCOB_NRPARCEL);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_CODOPER, V0HCOB_CODOPER);
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -575- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-2 */
        public void M_0100_PROCESSA_DB_SELECT_2()
        {
            /*" -430- EXEC SQL SELECT A.CODCLIEN, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.SITUACAO, A.QTDPARATZ, A.NUM_MATRICULA, A.CODPRODU, A.NRPARCE, B.TEM_SAF, B.TEM_CDG, B.RISCO, B.ESTR_COBR, B.CUSTOCAP_TOTAL INTO :V0PROP-CODCLIEN, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0PROP-SITUACAO, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN, :V0PROP-CODPRODU, :V0PROP-NRPARCE, :V0PROP-TEM-SAF:VIND-TEM-SAF, :V0PROP-TEM-CDG:VIND-TEM-CDG, :V0PROP-RISCO:VIND-RISCO, :V0PROP-ESTR-COBR:VIND-ESTR-COBR, :V0PROP-CUSTOCAP-TOTAL FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCOB-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_DB_SELECT_2_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(executed_1.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(executed_1.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(executed_1.V0PROP_INRMATRFUN, V0PROP_INRMATRFUN);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NRPARCE, V0PROP_NRPARCE);
                _.Move(executed_1.V0PROP_TEM_SAF, V0PROP_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PROP_TEM_CDG, V0PROP_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.V0PROP_RISCO, V0PROP_RISCO);
                _.Move(executed_1.VIND_RISCO, VIND_RISCO);
                _.Move(executed_1.V0PROP_ESTR_COBR, V0PROP_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.V0PROP_CUSTOCAP_TOTAL, V0PROP_CUSTOCAP_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-3 */
        public void M_0100_PROCESSA_DB_SELECT_3()
        {
            /*" -454- EXEC SQL SELECT DTINIVIG, DTINIVIG + :V0SUBG-PERI-FATURAMENTO MONTHS - 1 DAY, DTTERVIG INTO :V0RELA-DTINIVIG, :V0RELA-DTTERVIG-CALC, :V0RELA-DTTERVIG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND OCORHIST = :V0HCOB-NRPARCEL END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_DB_SELECT_3_Query1()
            {
                V0SUBG_PERI_FATURAMENTO = V0SUBG_PERI_FATURAMENTO.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DTINIVIG, V0RELA_DTINIVIG);
                _.Move(executed_1.V0RELA_DTTERVIG_CALC, V0RELA_DTTERVIG_CALC);
                _.Move(executed_1.V0RELA_DTTERVIG, V0RELA_DTTERVIG);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-DB-INSERT-1 */
        public void M_0100_PROCESSA_DB_INSERT_1()
        {
            /*" -566- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0817B' , :V0SIST-DTMOVABE, 'VG' , 'VG9574B' , 0, 0, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-PERI-INICIAL, 0, 0, 0, 0, 0, 0, 0, 0, :V0PROP-NUM-APOLICE, 0, :V0HCOB-NRPARCEL, :V0HCOB-NRCERTIF, :V0HCOB-NRTIT, :V0PROP-CODSUBES, 1201, 9999, :V0HCOB-NRPARCEL, ' ' , ' ' , 0, 0, ' ' , 0, 0, :V0SUBG-TIPO-FATURAMENTO, '0' , ' ' , ' ' , NULL, :V0SUBG-PERI-FATURAMENTO, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_0100_PROCESSA_DB_INSERT_1_Insert1 = new M_0100_PROCESSA_DB_INSERT_1_Insert1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0SUBG_TIPO_FATURAMENTO = V0SUBG_TIPO_FATURAMENTO.ToString(),
                V0SUBG_PERI_FATURAMENTO = V0SUBG_PERI_FATURAMENTO.ToString(),
            };

            M_0100_PROCESSA_DB_INSERT_1_Insert1.Execute(m_0100_PROCESSA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -586- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -588- MOVE 'FETCH CPARCEL' TO COMANDO. */
            _.Move("FETCH CPARCEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -599- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -602- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -603- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -604- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -605- MOVE 'CLOSE CPARCEL' TO COMANDO */
                    _.Move("CLOSE CPARCEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -605- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -607- ELSE */
                }
                else
                {


                    /*" -608- DISPLAY ' ERRO  NA  LEITURA  CPARCEL ' SQLCODE */
                    _.Display($" ERRO  NA  LEITURA  CPARCEL {DB.SQLCODE}");

                    /*" -608- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -599- EXEC SQL FETCH CPARCEL INTO :V0PARC-NRCERTIF, :V0PARC-NRPARCEL, :V0PARC-DTVENCTO, :V0PARC-PRMTOT , :V0PARC-PRMVG , :V0PARC-PRMAP , :V0PARC-SITUACAO, :V0SUBG-TIPO-FATURAMENTO, :V0SUBG-PERI-FATURAMENTO END-EXEC. */

            if (CPARCEL.Fetch())
            {
                _.Move(CPARCEL.V0PARC_NRCERTIF, V0PARC_NRCERTIF);
                _.Move(CPARCEL.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(CPARCEL.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(CPARCEL.V0PARC_PRMTOT, V0PARC_PRMTOT);
                _.Move(CPARCEL.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(CPARCEL.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(CPARCEL.V0PARC_SITUACAO, V0PARC_SITUACAO);
                _.Move(CPARCEL.V0SUBG_TIPO_FATURAMENTO, V0SUBG_TIPO_FATURAMENTO);
                _.Move(CPARCEL.V0SUBG_PERI_FATURAMENTO, V0SUBG_PERI_FATURAMENTO);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -605- EXEC SQL CLOSE CPARCEL END-EXEC */

            CPARCEL.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-4 */
        public void M_0100_PROCESSA_DB_SELECT_4()
        {
            /*" -476- EXEC SQL SELECT DTINIVIG, DTTERVIG INTO :V0APOC-DTINIVIG, :V0APOC-DTTERVIG FROM SEGUROS.V0APOLCORRET WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES AND DTINIVIG = :V0RELA-DTINIVIG AND TIPCOM = '2' END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_DB_SELECT_4_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0RELA_DTINIVIG = V0RELA_DTINIVIG.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOC_DTINIVIG, V0APOC_DTINIVIG);
                _.Move(executed_1.V0APOC_DTTERVIG, V0APOC_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-5 */
        public void M_0100_PROCESSA_DB_SELECT_5()
        {
            /*" -506- EXEC SQL SELECT PERI_INICIAL INTO :V0RELA-PERI-INICIAL FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VG9574B' AND NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES AND PERI_INICIAL = :V0RELA-PERI-INICIAL AND PERI_FINAL = :V0RELA-PERI-FINAL END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_DB_SELECT_5_Query1()
            {
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_PERI_INICIAL, V0RELA_PERI_INICIAL);
            }


        }

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -621- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -622- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -623- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -624- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -625- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WABEND.LOCALIZA_ABEND_1);

            /*" -627- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WABEND.LOCALIZA_ABEND_2);

            /*" -629- DISPLAY '*** VG0817B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VG0817B *** ROLLBACK EM ANDAMENTO ...");

            /*" -631- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -635- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -638- DISPLAY ' ' . */
            _.Display($" ");

            /*" -639- DISPLAY 'TITULO ................. ' V0HCOB-NRTIT. */
            _.Display($"TITULO ................. {V0HCOB_NRTIT}");

            /*" -641- DISPLAY ' ' . */
            _.Display($" ");

            /*" -643- DISPLAY '*** VG0817B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VG0817B *** ERRO DE EXECUCAO");

            /*" -644- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -644- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}