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
using Sias.VidaEmGrupo.DB2.VG0816B;

namespace Code
{
    public class VG0816B
    {
        public bool IsCall { get; set; }

        public VG0816B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   BAIXA PARCELAS EM V0HISTCOBVA                                *      */
        /*"      *                                                                *      */
        /*"      *              EM 03/11/97 - FONSECA                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                     A L T E R A C A O                          *      */
        /*"JV141 *----------------------------------------------------------------*      */
        /*"JV141 *VERSAO 41: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV141 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV141 *           - PROCURAR POR JV141                                 *      */
        /*"JV141 *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   EM 07/12/2019 - CLOVIS                                       *      */
        /*"      *   OCORR�NCIA DE FALHA N� 179326                                *      */
        /*"      *   VG0816B *** ERRO  EXEC SQL NUMERO 0800 SQLCODE =  803-       *      */
        /*"      *   R0800-00 - PROBLEMAS INSERT (VG_HIST_CONT_COBER)             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2019 - CLOVIS                                       *      */
        /*"      *   OCORR�NCIA DE FALHA N� 179259                                *      */
        /*"      *   VG0816B *** ERRO  EXEC SQL NUMERO 0510 SQLCODE =  803-       *      */
        /*"      *   R0510-00 - PROBLEMAS INSERT (V0HISTCONT)                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 12/08/2019 - CLOVIS                                       *      */
        /*"      *   PROGRAMA REMANAJADO DE ACORDO COM REGRAS ATUAIS.             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37 - HIST 181.577                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTMOVTO              PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TEM-SAF              PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TEM-CDG              PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RISCO                PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ESTR-COBR            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORIG-PRODU           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTNASC               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATSEL               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRP               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMBIL               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLVARMON             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-GRUPO-SUSEP         PIC S9(004)      COMP   VALUE +0*/
        public IntBasis WHOST_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-COD-RAMO            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis WHOST_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-CODSUBES            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-ANO-VENC            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis WHOST_ANO_VENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-ANO-NASC            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis WHOST_ANO_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-IDADE               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-TAXA-RAMO           PIC S9(003)V9(4) COMP-3 VALUE +0*/
        public DoubleBasis WHOST_TAXA_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77    WHOST-PERC-CDG            PIC S9(003)V9(4) COMP-3 VALUE +0*/
        public DoubleBasis WHOST_PERC_CDG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77    WHOST-PERC-DIT            PIC S9(003)V9(4) COMP-3 VALUE +0*/
        public DoubleBasis WHOST_PERC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77    WHOST-PERCENT             PIC S9(003)V9(4) COMP-3 VALUE +0*/
        public DoubleBasis WHOST_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77    WHOST-PREMIO-CONJ         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis WHOST_PREMIO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WHOST-IMPSEG              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis WHOST_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTVENCTO            PIC  X(010).*/
        public StringBasis WHOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTVENCTO1           PIC  X(010).*/
        public StringBasis WHOST_DTVENCTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-SITUACAO            PIC  X(001).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WHOST-OPCAO-COBER         PIC  X(001).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0COBP-IMPSEGAUXF-I       PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COBP-VLCUSTAUXF-I       PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COBP-QTTITCAP           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COBP-QUANT-VIDAS        PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0COBP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COBP-PRMTOT             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-VLPREMIO           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-PRMVG              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-PRMAP              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPSEGAUXF         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-VLCUSTAUXF         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPSEGCDG          PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-VLCUSTCDG          PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-VLCUSTCAP          PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPMORNATU         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPMORACID         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPDIT             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPINVPERM         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COBP-IMPDH              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0COBP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCTVA-VLCOBADIC         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0HCTVA_VLCOBADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCTVA-PRMVG             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0HCTVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCTVA-PRMAP             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0HCTVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCDG-DTREFER            PIC  X(010).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCDG-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RSAF-DTREFER            PIC  X(010).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RSAF-SITUACAO           PIC  X(001).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-CODSUBES           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-CODPRODU           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-NRPARCEL           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-FONTE              PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-INRMATRFUN         PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-QTDPARATZ          PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-RAMO               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PROP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROP-CODCLIEN           PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0PROP-NUM-APOLICE        PIC S9(013)      COMP-3 VALUE +0*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0PROP-NRMATRFUN          PIC S9(015)      COMP-3 VALUE +0*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0PROP-SITUACAO           PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-TEM-SAF            PIC  X(001).*/
        public StringBasis V0PROP_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-TEM-CDG            PIC  X(001).*/
        public StringBasis V0PROP_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-RISCO              PIC  X(001).*/
        public StringBasis V0PROP_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-CUSTOCAP-TOTAL     PIC  X(001).*/
        public StringBasis V0PROP_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-OPCAO-COBER        PIC  X(001).*/
        public StringBasis V0PROP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0PROP-ESTR-COBR          PIC  X(010).*/
        public StringBasis V0PROP_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0PROP-ORIG-PRODU         PIC  X(010).*/
        public StringBasis V0PROP_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0PROP-DTQITBCO           PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CDGC-VLCUSTCDG          PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SAFC-VLCUSTAUXF         PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0SAFC_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCOB-CODOPER            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0HCOB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HCOB-NRPARCEL           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0HCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HCOB-OCORHIST           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HCOB-NRTIT              PIC S9(013)      COMP-3 VALUE +0*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0HCOB-NRCERTIF           PIC S9(015)      COMP-3 VALUE +0*/
        public IntBasis V0HCOB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0HCOB-VLPRMTOT           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCOB-SITUACAO           PIC  X(001).*/
        public StringBasis V0HCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0HCOB-OPCAOPAG           PIC  X(001).*/
        public StringBasis V0HCOB_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0HCOB-DTVENCTO           PIC  X(010).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CMPT-NRPARCEL           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0CMPT_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CMPT-CODOPER            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0CMPT_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CMPT-VLPRMDIF           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0CMPT_VLPRMDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCTB-CODOPER            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HCTB-PRMVG              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0HCTB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HCTB-PRMAP              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0HCTB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFP-CODOPER            PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DIFP-NRPARCEL           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DIFP-PRMDEVVG           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0DIFP_PRMDEVVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFP-PRMDEVAP           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0DIFP_PRMDEVAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFP-PRMPAGVG           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0DIFP_PRMPAGVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFP-PRMPAGAP           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0DIFP_PRMPAGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFP-PRMDIFVG           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFP-PRMDIFAP           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DIFPA-NRPARCELDIF       PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0DIFPA_NRPARCELDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DIFPA-DTVENCTO          PIC  X(010).*/
        public StringBasis V0DIFPA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0OPCP-PERIPGTO           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PARC-DTVENCTO           PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0PARC-PRMAP              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0PARC-PRMVG              PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0PARC-PRMTOT             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0PARC_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0PARC-PRMTOTVG           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0PARC_PRMTOTVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0PDTV-OCORHIST           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0PDTV_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PLCO-CODPDT             PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0PLCO_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SEGU-NUM-ITEM           PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0SEGU_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MOVC-CODMOV             PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0MOVC_CODMOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MOVC-BCOAVISO           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0MOVC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MOVC-AGEAVISO           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0MOVC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MOVC-NRPARCEL           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0MOVC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MOVC-COD-EMPRESA        PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0MOVC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MOVC-NRAVISO            PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0MOVC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MOVC-NUMFITA            PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0MOVC_NUMFITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MOVC-NRENDOS            PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0MOVC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MOVC-NRTIT              PIC S9(013)      COMP-3 VALUE +0*/
        public IntBasis V0MOVC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MOVC-NUM-APOLICE        PIC S9(013)      COMP-3 VALUE +0*/
        public IntBasis V0MOVC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MOVC-NOSSO-TITULO       PIC S9(016)      COMP-3 VALUE +0*/
        public IntBasis V0MOVC_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77    V0MOVC-VALTIT             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0MOVC_VALTIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MOVC-VLIOCC             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0MOVC_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MOVC-VALCDT             PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0MOVC_VALCDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MOVC-SITUACAO           PIC  X(001).*/
        public StringBasis V0MOVC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MOVC-TIPO-MOVIMENTO     PIC  X(001).*/
        public StringBasis V0MOVC_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MOVC-DTMOVTO            PIC  X(010).*/
        public StringBasis V0MOVC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MOVC-DTQITBCO           PIC  X(010).*/
        public StringBasis V0MOVC_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MOVC-NOME               PIC  X(040).*/
        public StringBasis V0MOVC_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0FOLL-NRPARCEL           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-BCOAVISO           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-AGEAVISO           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-CODBAIXA           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-OPERACAO           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-CODLIDER           PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-FONTE              PIC S9(004)      COMP   VALUE +0*/
        public IntBasis V0FOLL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRRCAP             PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0FOLL_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NRENDOS            PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0FOLL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NRAVISO            PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0FOLL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-CODEMP             PIC S9(009)      COMP   VALUE +0*/
        public IntBasis V0FOLL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NUMAPOL            PIC S9(013)      COMP-3 VALUE +0*/
        public IntBasis V0FOLL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FOLL-ORDLIDER           PIC S9(015)      COMP-3 VALUE +0*/
        public IntBasis V0FOLL_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FOLL-VLPREMIO           PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis V0FOLL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FOLL-DACPARC            PIC  X(001).*/
        public StringBasis V0FOLL_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO01           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO02           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO03           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO04           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO05           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO06           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITUACAO           PIC  X(001).*/
        public StringBasis V0FOLL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITCONTB           PIC  X(001).*/
        public StringBasis V0FOLL_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-TIPSGU             PIC  X(001).*/
        public StringBasis V0FOLL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-HORAOPER           PIC  X(008).*/
        public StringBasis V0FOLL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FOLL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FOLL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTLIBER            PIC  X(010).*/
        public StringBasis V0FOLL_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FOLL_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-APOLIDER           PIC  X(015).*/
        public StringBasis V0FOLL_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-ENDOSLID           PIC  X(015).*/
        public StringBasis V0FOLL_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VG0816B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VG0816B_WS_WORK_AREAS();
        public class VG0816B_WS_WORK_AREAS : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-VGRAMOCOMP           PIC  X(003)         VALUE SPACES*/
            public StringBasis WFIM_VGRAMOCOMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  WFIM-TAB-RAMO             PIC  X(003)         VALUE SPACES*/
            public StringBasis WFIM_TAB_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  WS-EOF-D                  PIC  9(001)         VALUE ZEROS.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03  WS-EOC                    PIC  9(001)         VALUE ZEROS.*/
            public IntBasis WS_EOC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03  WS-EOP                    PIC  9(001)         VALUE ZEROS.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03  LD-MOVIMCOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-HISTCOBVA              PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TE_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-GE403                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TE_GE403 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-GE403                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_GE403 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TE_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-COBHISVI               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TE_COBHISVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-COBHISVI               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_COBHISVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-PARCEL                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_PARCEL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FOLLOWUP               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-DIFERENCA              PIC S9(13)V99       VALUE ZEROS.*/
            public DoubleBasis WS_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  03  WS-PC-VG                  PIC  9(03)V9(7)     VALUE ZEROS.*/
            public DoubleBasis WS_PC_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"  03  WS-PCT-COB-VG             PIC  9(03)V9(7)     VALUE ZEROS.*/
            public DoubleBasis WS_PCT_COB_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"  03  WS-RESTO                  PIC S9(007)         VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03  WS-PREMIO-TOTAL           PIC S9(13)V99       VALUE ZEROS.*/
            public DoubleBasis WS_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  03  WS-PREMIO-TOTAL-AC        PIC S9(13)V99       VALUE ZEROS.*/
            public DoubleBasis WS_PREMIO_TOTAL_AC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  03  WS-IMP-SEGURADA           PIC S9(13)V99       VALUE ZEROS.*/
            public DoubleBasis WS_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VG0816B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG0816B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG0816B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VG0816B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WS-RESULT          PIC  9(006)    VALUE   ZEROS.*/

                public _REDEF_VG0816B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         AUX-ANO            PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         FILLER             REDEFINES      AUX-ANO.*/
            private _REDEF_VG0816B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VG0816B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VG0816B_FILLER_1(); _.Move(AUX_ANO, _filler_1); VarBasis.RedefinePassValue(AUX_ANO, _filler_1, AUX_ANO); _filler_1.ValueChanged += () => { _.Move(_filler_1, AUX_ANO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, AUX_ANO); }
            }  //Redefines
            public class _REDEF_VG0816B_FILLER_1 : VarBasis
            {
                /*"    10       AUX-ANO1           PIC  9(002).*/
                public IntBasis AUX_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-ANO2           PIC  9(002).*/
                public IntBasis AUX_ANO2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_VG0816B_FILLER_1()
                {
                    AUX_ANO1.ValueChanged += OnValueChanged;
                    AUX_ANO2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_VG0816B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_VG0816B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_VG0816B_FILLER_2(); _.Move(WTIME_DAY, _filler_2); VarBasis.RedefinePassValue(WTIME_DAY, _filler_2, WTIME_DAY); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTIME_DAY); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG0816B_FILLER_2 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VG0816B_WTIME_DAYR WTIME_DAYR { get; set; } = new VG0816B_WTIME_DAYR();
                public class VG0816B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  9(002).*/
                    public IntBasis WTIME_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  9(002).*/
                    public IntBasis WTIME_MINU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  9(002).*/
                    public IntBasis WTIME_SEGU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public VG0816B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  9(002).*/
                public IntBasis WTIME_CCSE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-TIME.*/

                public _REDEF_VG0816B_FILLER_2()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VG0816B_WS_TIME WS_TIME { get; set; } = new VG0816B_WS_TIME();
            public class VG0816B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         DATA-SQL.*/
            }
            public VG0816B_DATA_SQL DATA_SQL { get; set; } = new VG0816B_DATA_SQL();
            public class VG0816B_DATA_SQL : VarBasis
            {
                /*"      10     ANO-SQL            PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     MES-SQL            PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     DIA-SQL            PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS1-IDLG.*/
            }
            public VG0816B_WS1_IDLG WS1_IDLG { get; set; } = new VG0816B_WS1_IDLG();
            public class VG0816B_WS1_IDLG : VarBasis
            {
                /*"    10       WS1-CONVENIO       PIC  9(006).*/
                public IntBasis WS1_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WS1-NSAS           PIC  9(006).*/
                public IntBasis WS1_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WS1-ENDOSSO        PIC  9(008).*/
                public IntBasis WS1_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       WS1-BRANCOS        PIC  X(020).*/
                public StringBasis WS1_BRANCOS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  03         WS2-IDLG.*/
            }
            public VG0816B_WS2_IDLG WS2_IDLG { get; set; } = new VG0816B_WS2_IDLG();
            public class VG0816B_WS2_IDLG : VarBasis
            {
                /*"    10       WS2-NRCERTIF       PIC  9(015).*/
                public IntBasis WS2_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       WS2-NRPARCEL       PIC  9(004).*/
                public IntBasis WS2_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS2-NRTIT          PIC  9(013).*/
                public IntBasis WS2_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WS2-BRANCOS        PIC  X(008).*/
                public StringBasis WS2_BRANCOS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01  WORK-TAB-RAMO-CONJ.*/
            }
        }
        public VG0816B_WORK_TAB_RAMO_CONJ WORK_TAB_RAMO_CONJ { get; set; } = new VG0816B_WORK_TAB_RAMO_CONJ();
        public class VG0816B_WORK_TAB_RAMO_CONJ : VarBasis
        {
            /*"    05  N5WORK-TAB-RAMO-CONJ    OCCURS 30 TIMES.*/
            public ListBasis<VG0816B_N5WORK_TAB_RAMO_CONJ> N5WORK_TAB_RAMO_CONJ { get; set; } = new ListBasis<VG0816B_N5WORK_TAB_RAMO_CONJ>(30);
            public class VG0816B_N5WORK_TAB_RAMO_CONJ : VarBasis
            {
                /*"      10  TB-GRUPO-SUSEP              PIC S9(004) COMP.*/
                public IntBasis TB_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-RAMO-CONJ                PIC S9(004) COMP.*/
                public IntBasis TB_RAMO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-TAXA-RAMO-CONJ           PIC S9(003)V9(4) COMP-3.*/
                public DoubleBasis TB_TAXA_RAMO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
                /*"01  WORK-RAMO-CONJ.*/
            }
        }
        public VG0816B_WORK_RAMO_CONJ WORK_RAMO_CONJ { get; set; } = new VG0816B_WORK_RAMO_CONJ();
        public class VG0816B_WORK_RAMO_CONJ : VarBasis
        {
            /*"    05  WS-GRUPO-SUSEP-ANT            PIC S9(004) COMP.*/
            public IntBasis WS_GRUPO_SUSEP_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-RAMO-CONJ-ANT              PIC S9(004) COMP.*/
            public IntBasis WS_RAMO_CONJ_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND                        PIC S9(004) COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND1                       PIC S9(004) COMP.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WHOST-VLR-PERC-PREMIO         PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WHOST-VLR-PERC-PREMIO-TOT     PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WS-SALVA                      PIC  X(020).*/
            public StringBasis WS_SALVA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"01  WABEND.*/
        }
        public VG0816B_WABEND WABEND { get; set; } = new VG0816B_WABEND();
        public class VG0816B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VG0816B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0816B  ");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
            /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public Dclgens.VG081 VG081 { get; set; } = new Dclgens.VG081();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.VGPROSIA VGPROSIA { get; set; } = new Dclgens.VGPROSIA();
        public Dclgens.PARAGEEM PARAGEEM { get; set; } = new Dclgens.PARAGEEM();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public VG0816B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new VG0816B_V0MOVIMCOB();
        public VG0816B_CVGRAMOCOMP CVGRAMOCOMP { get; set; } = new VG0816B_CVGRAMOCOMP();
        public VG0816B_CDIFP CDIFP { get; set; } = new VG0816B_CDIFP();
        public VG0816B_CDIFPA CDIFPA { get; set; } = new VG0816B_CDIFPA();
        public VG0816B_CCMPTIT CCMPTIT { get; set; } = new VG0816B_CCMPTIT();
        public VG0816B_CPLCOM CPLCOM { get; set; } = new VG0816B_CPLCOM();
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
            /*" -396- DISPLAY ' ' */
            _.Display($" ");

            /*" -398- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -406- DISPLAY 'PROGRAMA EM EXECUCAO VG0816B-' 'VERSAO V.41 - DEMANDA 259990 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VG0816B-VERSAO V.41 - DEMANDA 259990 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -408- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -410- DISPLAY ' ' */
            _.Display($" ");

            /*" -412- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -414- PERFORM R0150-00-SELECIONA. */

            R0150_00_SELECIONA_SECTION();

            /*" -415- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -416- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA);

            /*" -417- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT1);

            /*" -418- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);

            /*" -419- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT2);

            /*" -420- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

            /*" -420- DISPLAY 'FIM    VG0816B    ' WTIME-DAYR. */
            _.Display($"FIM    VG0816B    {WS_WORK_AREAS.FILLER_2.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -425- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -429- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -430- DISPLAY ' ' */
            _.Display($" ");

            /*" -431- DISPLAY 'VG0816B - FIM NORMAL' */
            _.Display($"VG0816B - FIM NORMAL");

            /*" -434- DISPLAY ' ' */
            _.Display($" ");

            /*" -434- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -443- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WABEND.WNR_EXEC_SQL);

            /*" -444- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -445- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA);

            /*" -446- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT1);

            /*" -447- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);

            /*" -448- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT2);

            /*" -449- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

            /*" -452- DISPLAY 'INICIO VG0816B    ' WTIME-DAYR. */
            _.Display($"INICIO VG0816B    {WS_WORK_AREAS.FILLER_2.WTIME_DAYR}");

            /*" -455- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -456- DISPLAY ' ' . */
            _.Display($" ");

            /*" -458- DISPLAY 'DATA DE MOVIMENTO ............... ' V0SIST-DTMOVABE. */
            _.Display($"DATA DE MOVIMENTO ............... {V0SIST_DTMOVABE}");

            /*" -461- DISPLAY ' ' . */
            _.Display($" ");

            /*" -461- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -474- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -481- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -485- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -486- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -486- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -481- EXEC SQL SELECT DATA_MOV_ABERTO INTO :V0SIST-DTMOVABE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECIONA-SECTION */
        private void R0150_00_SELECIONA_SECTION()
        {
            /*" -499- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -500- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -501- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA);

            /*" -502- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT1);

            /*" -503- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);

            /*" -504- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT2);

            /*" -505- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

            /*" -507- DISPLAY 'LEITURA MOVIMCOB  ' WTIME-DAYR. */
            _.Display($"LEITURA MOVIMCOB  {WS_WORK_AREAS.FILLER_2.WTIME_DAYR}");

            /*" -508- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", WS_WORK_AREAS.WFIM_MOVIMENTO);

            /*" -510- PERFORM R0160-00-DECLARE-MOVIMCOB. */

            R0160_00_DECLARE_MOVIMCOB_SECTION();

            /*" -512- PERFORM R0170-00-FETCH-MOVIMCOB. */

            R0170_00_FETCH_MOVIMCOB_SECTION();

            /*" -515- PERFORM R0180-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0180_00_PROCESSA_MOVIMCOB_SECTION();
            }

            /*" -516- DISPLAY ' ' . */
            _.Display($" ");

            /*" -517- DISPLAY 'LIDOS MOVIMCOB ............. ' LD-MOVIMCOB. */
            _.Display($"LIDOS MOVIMCOB ............. {WS_WORK_AREAS.LD_MOVIMCOB}");

            /*" -518- DISPLAY ' ' . */
            _.Display($" ");

            /*" -519- DISPLAY 'TEM HISTCOBVA .............. ' TE-HISTCOBVA. */
            _.Display($"TEM HISTCOBVA .............. {WS_WORK_AREAS.TE_HISTCOBVA}");

            /*" -520- DISPLAY ' ' . */
            _.Display($" ");

            /*" -521- DISPLAY 'TEM GE403 .................. ' TE-GE403. */
            _.Display($"TEM GE403 .................. {WS_WORK_AREAS.TE_GE403}");

            /*" -522- DISPLAY 'SEM GE403 .................. ' NT-GE403. */
            _.Display($"SEM GE403 .................. {WS_WORK_AREAS.NT_GE403}");

            /*" -523- DISPLAY ' ' . */
            _.Display($" ");

            /*" -524- DISPLAY 'TEM MOVDEBCE ............... ' TE-MOVDEBCE. */
            _.Display($"TEM MOVDEBCE ............... {WS_WORK_AREAS.TE_MOVDEBCE}");

            /*" -525- DISPLAY 'SEM MOVDEBCE ............... ' NT-MOVDEBCE. */
            _.Display($"SEM MOVDEBCE ............... {WS_WORK_AREAS.NT_MOVDEBCE}");

            /*" -526- DISPLAY ' ' . */
            _.Display($" ");

            /*" -527- DISPLAY 'TEM COBHISVI ............... ' TE-COBHISVI. */
            _.Display($"TEM COBHISVI ............... {WS_WORK_AREAS.TE_COBHISVI}");

            /*" -528- DISPLAY 'SEM COBHISVI ............... ' NT-COBHISVI. */
            _.Display($"SEM COBHISVI ............... {WS_WORK_AREAS.NT_COBHISVI}");

            /*" -529- DISPLAY ' ' . */
            _.Display($" ");

            /*" -530- DISPLAY 'REGISTROS EM FOLLOW-UP ..... ' AC-FOLLOWUP. */
            _.Display($"REGISTROS EM FOLLOW-UP ..... {WS_WORK_AREAS.AC_FOLLOWUP}");

            /*" -531- DISPLAY 'PARCELAS ATUALIZADAS ....... ' AC-PARCEL. */
            _.Display($"PARCELAS ATUALIZADAS ....... {WS_WORK_AREAS.AC_PARCEL}");

            /*" -534- DISPLAY ' ' . */
            _.Display($" ");

            /*" -534- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-DECLARE-MOVIMCOB-SECTION */
        private void R0160_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -547- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WABEND.WNR_EXEC_SQL);

            /*" -574- PERFORM R0160_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0160_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -576- PERFORM R0160_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0160_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -581- DISPLAY 'R0160-00 - PROBLEMAS DECLARE (MOVIMCOB)  ' */
                _.Display($"R0160-00 - PROBLEMAS DECLARE (MOVIMCOB)  ");

                /*" -581- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0160-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0160_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -574- EXEC SQL DECLARE V0MOVIMCOB CURSOR FOR SELECT COD_EMPRESA ,COD_MOVIMENTO ,COD_BANCO ,COD_AGENCIA ,NUM_AVISO ,NUM_FITA ,DATA_MOVIMENTO ,DATA_QUITACAO ,NUM_TITULO ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,VAL_TITULO ,VAL_IOCC ,VAL_CREDITO ,SIT_REGISTRO ,NOME_SEGURADO ,TIPO_MOVIMENTO ,NUM_NOSSO_TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO IN ( '2' , '3' ) FOR UPDATE OF NUM_TITULO ,NUM_PARCELA ,SIT_REGISTRO ,NOME_SEGURADO END-EXEC. */
            V0MOVIMCOB = new VG0816B_V0MOVIMCOB(false);
            string GetQuery_V0MOVIMCOB()
            {
                var query = @$"SELECT COD_EMPRESA 
							,COD_MOVIMENTO 
							,COD_BANCO 
							,COD_AGENCIA 
							,NUM_AVISO 
							,NUM_FITA 
							,DATA_MOVIMENTO 
							,DATA_QUITACAO 
							,NUM_TITULO 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,VAL_TITULO 
							,VAL_IOCC 
							,VAL_CREDITO 
							,SIT_REGISTRO 
							,NOME_SEGURADO 
							,TIPO_MOVIMENTO 
							,NUM_NOSSO_TITULO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO = ' ' 
							AND TIPO_MOVIMENTO IN ( '2'
							, '3' )";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }

        [StopWatch]
        /*" R0160-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0160_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -576- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }

        [StopWatch]
        /*" R0600-00-DECLARE-VGRAMOCOMP-DB-DECLARE-1 */
        public void R0600_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1()
        {
            /*" -1818- EXEC SQL DECLARE CVGRAMOCOMP CURSOR FOR SELECT DISTINCT B.NUM_APOLICE ,B.COD_SUBGRUPO ,B.COD_GRUPO_SUSEP ,B.RAMO_EMISSOR ,B.COD_MODALIDADE ,B.DTH_INI_VIGENCIA ,B.COD_OPCAO_COBERTURA ,B.NUM_IDADE_INICIAL ,B.NUM_IDADE_FINAL ,B.VLR_PERC_PREMIO ,B.COD_USUARIO ,B.DTH_ATUALIZACAO FROM SEGUROS.VG_PARAM_RAMO_CONJ A, SEGUROS.VG_PARAM_RAMO_COMP B WHERE A.NUM_APOLICE = :V0PROP-NUM-APOLICE AND A.COD_SUBGRUPO = :WHOST-CODSUBES AND A.DTH_INI_VIGENCIA <= :WHOST-DTVENCTO1 AND A.DTH_TER_VIGENCIA >= :WHOST-DTVENCTO1 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.RAMO_EMISSOR = A.RAMO_EMISSOR AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.NUM_IDADE_INICIAL <= :WHOST-IDADE AND B.NUM_IDADE_FINAL >= :WHOST-IDADE AND B.COD_OPCAO_COBERTURA = :WHOST-OPCAO-COBER ORDER BY B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO END-EXEC. */
            CVGRAMOCOMP = new VG0816B_CVGRAMOCOMP(true);
            string GetQuery_CVGRAMOCOMP()
            {
                var query = @$"SELECT DISTINCT 
							B.NUM_APOLICE 
							,B.COD_SUBGRUPO 
							,B.COD_GRUPO_SUSEP 
							,B.RAMO_EMISSOR 
							,B.COD_MODALIDADE 
							,B.DTH_INI_VIGENCIA 
							,B.COD_OPCAO_COBERTURA 
							,B.NUM_IDADE_INICIAL 
							,B.NUM_IDADE_FINAL 
							,B.VLR_PERC_PREMIO 
							,B.COD_USUARIO 
							,B.DTH_ATUALIZACAO 
							FROM SEGUROS.VG_PARAM_RAMO_CONJ A
							, 
							SEGUROS.VG_PARAM_RAMO_COMP B 
							WHERE A.NUM_APOLICE = '{V0PROP_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = '{WHOST_CODSUBES}' 
							AND A.DTH_INI_VIGENCIA <= '{WHOST_DTVENCTO1}' 
							AND A.DTH_TER_VIGENCIA >= '{WHOST_DTVENCTO1}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.RAMO_EMISSOR = A.RAMO_EMISSOR 
							AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA 
							AND B.NUM_IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND B.NUM_IDADE_FINAL >= '{WHOST_IDADE}' 
							AND B.COD_OPCAO_COBERTURA = '{WHOST_OPCAO_COBER}' 
							ORDER BY B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_GRUPO_SUSEP
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE
							, 
							B.DTH_INI_VIGENCIA
							, 
							B.COD_OPCAO_COBERTURA
							, 
							B.NUM_IDADE_INICIAL
							, 
							B.NUM_IDADE_FINAL
							, 
							B.VLR_PERC_PREMIO
							, 
							B.COD_USUARIO
							, 
							B.DTH_ATUALIZACAO";

                return query;
            }
            CVGRAMOCOMP.GetQueryEvent += GetQuery_CVGRAMOCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-FETCH-MOVIMCOB-SECTION */
        private void R0170_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -594- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", WABEND.WNR_EXEC_SQL);

            /*" -614- PERFORM R0170_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0170_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -618- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -618- PERFORM R0170_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0170_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -620- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WS_WORK_AREAS.WFIM_MOVIMENTO);

                /*" -622- GO TO R0170-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/ //GOTO
                return;
            }


            /*" -623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -624- DISPLAY 'R0170-00 - PROBLEMAS FETCH   (MOVIMCOB)  ' */
                _.Display($"R0170-00 - PROBLEMAS FETCH   (MOVIMCOB)  ");

                /*" -627- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -630- ADD 1 TO LD-MOVIMCOB. */
            WS_WORK_AREAS.LD_MOVIMCOB.Value = WS_WORK_AREAS.LD_MOVIMCOB + 1;

            /*" -632- MOVE LD-MOVIMCOB TO AC-LIDOS. */
            _.Move(WS_WORK_AREAS.LD_MOVIMCOB, WS_WORK_AREAS.AC_LIDOS);

            /*" -634- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (WS_WORK_AREAS.FILLER_0.LD_PARTE2 == 00 || WS_WORK_AREAS.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -635- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -636- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA);

                /*" -637- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT1);

                /*" -638- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);

                /*" -639- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT2);

                /*" -640- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

                /*" -641- DISPLAY 'LIDOS MOVIMCOB     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS MOVIMCOB     {WS_WORK_AREAS.AC_LIDOS}    {WS_WORK_AREAS.FILLER_2.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0170-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0170_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -614- EXEC SQL FETCH V0MOVIMCOB INTO :V0MOVC-COD-EMPRESA ,:V0MOVC-CODMOV ,:V0MOVC-BCOAVISO ,:V0MOVC-AGEAVISO ,:V0MOVC-NRAVISO ,:V0MOVC-NUMFITA ,:V0MOVC-DTMOVTO ,:V0MOVC-DTQITBCO ,:V0MOVC-NRTIT ,:V0MOVC-NUM-APOLICE ,:V0MOVC-NRENDOS ,:V0MOVC-NRPARCEL ,:V0MOVC-VALTIT ,:V0MOVC-VLIOCC ,:V0MOVC-VALCDT ,:V0MOVC-SITUACAO ,:V0MOVC-NOME ,:V0MOVC-TIPO-MOVIMENTO ,:V0MOVC-NOSSO-TITULO END-EXEC. */

            if (V0MOVIMCOB.Fetch())
            {
                _.Move(V0MOVIMCOB.V0MOVC_COD_EMPRESA, V0MOVC_COD_EMPRESA);
                _.Move(V0MOVIMCOB.V0MOVC_CODMOV, V0MOVC_CODMOV);
                _.Move(V0MOVIMCOB.V0MOVC_BCOAVISO, V0MOVC_BCOAVISO);
                _.Move(V0MOVIMCOB.V0MOVC_AGEAVISO, V0MOVC_AGEAVISO);
                _.Move(V0MOVIMCOB.V0MOVC_NRAVISO, V0MOVC_NRAVISO);
                _.Move(V0MOVIMCOB.V0MOVC_NUMFITA, V0MOVC_NUMFITA);
                _.Move(V0MOVIMCOB.V0MOVC_DTMOVTO, V0MOVC_DTMOVTO);
                _.Move(V0MOVIMCOB.V0MOVC_DTQITBCO, V0MOVC_DTQITBCO);
                _.Move(V0MOVIMCOB.V0MOVC_NRTIT, V0MOVC_NRTIT);
                _.Move(V0MOVIMCOB.V0MOVC_NUM_APOLICE, V0MOVC_NUM_APOLICE);
                _.Move(V0MOVIMCOB.V0MOVC_NRENDOS, V0MOVC_NRENDOS);
                _.Move(V0MOVIMCOB.V0MOVC_NRPARCEL, V0MOVC_NRPARCEL);
                _.Move(V0MOVIMCOB.V0MOVC_VALTIT, V0MOVC_VALTIT);
                _.Move(V0MOVIMCOB.V0MOVC_VLIOCC, V0MOVC_VLIOCC);
                _.Move(V0MOVIMCOB.V0MOVC_VALCDT, V0MOVC_VALCDT);
                _.Move(V0MOVIMCOB.V0MOVC_SITUACAO, V0MOVC_SITUACAO);
                _.Move(V0MOVIMCOB.V0MOVC_NOME, V0MOVC_NOME);
                _.Move(V0MOVIMCOB.V0MOVC_TIPO_MOVIMENTO, V0MOVC_TIPO_MOVIMENTO);
                _.Move(V0MOVIMCOB.V0MOVC_NOSSO_TITULO, V0MOVC_NOSSO_TITULO);
            }

        }

        [StopWatch]
        /*" R0170-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0170_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -618- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-PROCESSA-MOVIMCOB-SECTION */
        private void R0180_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -654- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", WABEND.WNR_EXEC_SQL);

            /*" -656- PERFORM R0200-00-SELECT-V0HISTCOBVA. */

            R0200_00_SELECT_V0HISTCOBVA_SECTION();

            /*" -657- IF V0HCOB-NRCERTIF EQUAL ZEROS */

            if (V0HCOB_NRCERTIF == 00)
            {

                /*" -659- MOVE 'VG0816B-PROPOSTA NAO CADASTRADA SIGCB' TO V0MOVC-NOME */
                _.Move("VG0816B-PROPOSTA NAO CADASTRADA SIGCB", V0MOVC_NOME);

                /*" -660- MOVE '1' TO V0FOLL-CDERRO01 */
                _.Move("1", V0FOLL_CDERRO01);

                /*" -661- MOVE SPACES TO V0FOLL-CDERRO04 */
                _.Move("", V0FOLL_CDERRO04);

                /*" -662- PERFORM R0300-00-MONTA-V0FOLLOWUP */

                R0300_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -665- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -667- PERFORM R0400-00-SELECT-V0PROPOVA. */

            R0400_00_SELECT_V0PROPOVA_SECTION();

            /*" -668- IF V0PROP-NUM-APOLICE EQUAL ZEROS */

            if (V0PROP_NUM_APOLICE == 00)
            {

                /*" -669- PERFORM R0300-00-MONTA-V0FOLLOWUP */

                R0300_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -672- GO TO R0180-90-LEITURA. */

                R0180_90_LEITURA(); //GOTO
                return;
            }


            /*" -674- PERFORM R0420-00-SELECT-V0PARCELVA. */

            R0420_00_SELECT_V0PARCELVA_SECTION();

            /*" -676- PERFORM R0440-00-SELECT-V0COBERPROPVA. */

            R0440_00_SELECT_V0COBERPROPVA_SECTION();

            /*" -678- PERFORM R0460-00-SELECT-V0OPCAOPAGVA. */

            R0460_00_SELECT_V0OPCAOPAGVA_SECTION();

            /*" -680- PERFORM R0500-00-TRATA-CONTABIL. */

            R0500_00_TRATA_CONTABIL_SECTION();

            /*" -683- PERFORM R0550-00-TRATA-CLIENTES. */

            R0550_00_TRATA_CLIENTES_SECTION();

            /*" -683- PERFORM R1000-00-PROCESSA. */

            R1000_00_PROCESSA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0180_90_LEITURA */

            R0180_90_LEITURA();

        }

        [StopWatch]
        /*" R0180-90-LEITURA */
        private void R0180_90_LEITURA(bool isPerform = false)
        {
            /*" -688- PERFORM R0170-00-FETCH-MOVIMCOB. */

            R0170_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0HISTCOBVA-SECTION */
        private void R0200_00_SELECT_V0HISTCOBVA_SECTION()
        {
            /*" -700- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -723- PERFORM R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1 */

            R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1();

            /*" -727- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -728- PERFORM R0210-00-SELECT-GE403 */

                R0210_00_SELECT_GE403_SECTION();

                /*" -731- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -733- DISPLAY 'R0200-00 - PROBLEMAS NO SELECT(BILHETE)' */
                _.Display($"R0200-00 - PROBLEMAS NO SELECT(BILHETE)");

                /*" -734- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -735- ELSE */
            }
            else
            {


                /*" -735- ADD 1 TO TE-HISTCOBVA. */
                WS_WORK_AREAS.TE_HISTCOBVA.Value = WS_WORK_AREAS.TE_HISTCOBVA + 1;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V0HISTCOBVA-DB-SELECT-1 */
        public void R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1()
        {
            /*" -723- EXEC SQL SELECT NRCERTIF ,NRPARCEL ,NRTIT ,VLPRMTOT ,SITUACAO ,OCORHIST ,CODOPER ,OPCAOPAG ,DTVENCTO INTO :V0HCOB-NRCERTIF ,:V0HCOB-NRPARCEL ,:V0HCOB-NRTIT ,:V0HCOB-VLPRMTOT ,:V0HCOB-SITUACAO ,:V0HCOB-OCORHIST ,:V0HCOB-CODOPER ,:V0HCOB-OPCAOPAG ,:V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRTIT = :V0MOVC-NRTIT FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1()
            {
                V0MOVC_NRTIT = V0MOVC_NRTIT.ToString(),
            };

            var executed_1 = R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRCERTIF, V0HCOB_NRCERTIF);
                _.Move(executed_1.V0HCOB_NRPARCEL, V0HCOB_NRPARCEL);
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_CODOPER, V0HCOB_CODOPER);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-SELECT-GE403-SECTION */
        private void R0210_00_SELECT_GE403_SECTION()
        {
            /*" -748- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -759- PERFORM R0210_00_SELECT_GE403_DB_SELECT_1 */

            R0210_00_SELECT_GE403_DB_SELECT_1();

            /*" -763- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -764- ADD 1 TO NT-GE403 */
                WS_WORK_AREAS.NT_GE403.Value = WS_WORK_AREAS.NT_GE403 + 1;

                /*" -766- MOVE ZEROS TO V0HCOB-NRCERTIF */
                _.Move(0, V0HCOB_NRCERTIF);

                /*" -769- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -770- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -771- DISPLAY 'R0210-00 - PROBLEMAS NO SELECT(GE403)  ' */
                _.Display($"R0210-00 - PROBLEMAS NO SELECT(GE403)  ");

                /*" -773- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -775- ADD 1 TO TE-GE403. */
            WS_WORK_AREAS.TE_GE403.Value = WS_WORK_AREAS.TE_GE403 + 1;

            /*" -776- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -779- MOVE SPACES TO GE403-NUM-IDLG. */
                _.Move("", GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
            }


            /*" -780- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -783- MOVE ZEROS TO GE403-NUM-NOSSO-NUMERO-SAP. */
                _.Move(0, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
            }


            /*" -784- IF GE403-NUM-IDLG EQUAL SPACES */

            if (GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG.IsEmpty())
            {

                /*" -786- MOVE ZEROS TO V0HCOB-NRCERTIF */
                _.Move(0, V0HCOB_NRCERTIF);

                /*" -789- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -792- MOVE GE403-NUM-IDLG TO WS1-IDLG WS2-IDLG. */
            _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG, WS_WORK_AREAS.WS1_IDLG, WS_WORK_AREAS.WS2_IDLG);

            /*" -793- IF WS1-BRANCOS EQUAL SPACES */

            if (WS_WORK_AREAS.WS1_IDLG.WS1_BRANCOS.IsEmpty())
            {

                /*" -795- MOVE WS1-CONVENIO TO MOVDEBCE-COD-CONVENIO */
                _.Move(WS_WORK_AREAS.WS1_IDLG.WS1_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -797- MOVE WS1-NSAS TO MOVDEBCE-NSAS */
                _.Move(WS_WORK_AREAS.WS1_IDLG.WS1_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                /*" -799- MOVE WS1-ENDOSSO TO MOVDEBCE-NUM-ENDOSSO */
                _.Move(WS_WORK_AREAS.WS1_IDLG.WS1_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                /*" -800- PERFORM R0220-00-SELECT-MOVDEBCE */

                R0220_00_SELECT_MOVDEBCE_SECTION();

                /*" -801- ELSE */
            }
            else
            {


                /*" -803- MOVE WS2-NRCERTIF TO V0HCOB-NRCERTIF */
                _.Move(WS_WORK_AREAS.WS2_IDLG.WS2_NRCERTIF, V0HCOB_NRCERTIF);

                /*" -805- MOVE WS2-NRPARCEL TO V0HCOB-NRPARCEL */
                _.Move(WS_WORK_AREAS.WS2_IDLG.WS2_NRPARCEL, V0HCOB_NRPARCEL);

                /*" -805- PERFORM R0240-00-SELECT-COBHISVI. */

                R0240_00_SELECT_COBHISVI_SECTION();
            }


        }

        [StopWatch]
        /*" R0210-00-SELECT-GE403-DB-SELECT-1 */
        public void R0210_00_SELECT_GE403_DB_SELECT_1()
        {
            /*" -759- EXEC SQL SELECT NUM_IDLG ,NUM_NOSSO_NUMERO_SAP INTO :GE403-NUM-IDLG:VIND-NULL01 ,:GE403-NUM-NOSSO-NUMERO-SAP:VIND-NULL02 FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB WHERE NUM_NOSSO_NUMERO_SAP = (:V0MOVC-NOSSO-TITULO + 140000000000000000) AND COD_SITUACAO = 'F' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0210_00_SELECT_GE403_DB_SELECT_1_Query1 = new R0210_00_SELECT_GE403_DB_SELECT_1_Query1()
            {
                V0MOVC_NOSSO_TITULO = V0MOVC_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R0210_00_SELECT_GE403_DB_SELECT_1_Query1.Execute(r0210_00_SELECT_GE403_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.GE403_NUM_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-SELECT-MOVDEBCE-SECTION */
        private void R0220_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -818- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WABEND.WNR_EXEC_SQL);

            /*" -829- PERFORM R0220_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R0220_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -833- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -834- ADD 1 TO NT-MOVDEBCE */
                WS_WORK_AREAS.NT_MOVDEBCE.Value = WS_WORK_AREAS.NT_MOVDEBCE + 1;

                /*" -836- MOVE ZEROS TO V0HCOB-NRCERTIF */
                _.Move(0, V0HCOB_NRCERTIF);

                /*" -839- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -840- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -841- DISPLAY 'R0220-00 - PROBLEMAS NO SELECT(MOVDEBCE)' */
                _.Display($"R0220-00 - PROBLEMAS NO SELECT(MOVDEBCE)");

                /*" -844- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -847- ADD 1 TO TE-MOVDEBCE. */
            WS_WORK_AREAS.TE_MOVDEBCE.Value = WS_WORK_AREAS.TE_MOVDEBCE + 1;

            /*" -848- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -850- MOVE ZEROS TO V0HCOB-NRCERTIF */
                _.Move(0, V0HCOB_NRCERTIF);

                /*" -853- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -855- MOVE MOVDEBCE-NUM-CARTAO TO V0HCOB-NRCERTIF. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, V0HCOB_NRCERTIF);

            /*" -858- MOVE MOVDEBCE-NUM-PARCELA TO V0HCOB-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, V0HCOB_NRPARCEL);

            /*" -858- PERFORM R0240-00-SELECT-COBHISVI. */

            R0240_00_SELECT_COBHISVI_SECTION();

        }

        [StopWatch]
        /*" R0220-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R0220_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -829- EXEC SQL SELECT NUM_PARCELA ,NUM_CARTAO INTO :MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-NUM-CARTAO:VIND-NULL01 FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0220_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R0220_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R0220_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0220_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-COBHISVI-SECTION */
        private void R0240_00_SELECT_COBHISVI_SECTION()
        {
            /*" -871- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", WABEND.WNR_EXEC_SQL);

            /*" -895- PERFORM R0240_00_SELECT_COBHISVI_DB_SELECT_1 */

            R0240_00_SELECT_COBHISVI_DB_SELECT_1();

            /*" -899- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -900- ADD 1 TO NT-COBHISVI */
                WS_WORK_AREAS.NT_COBHISVI.Value = WS_WORK_AREAS.NT_COBHISVI + 1;

                /*" -902- MOVE ZEROS TO V0HCOB-NRCERTIF */
                _.Move(0, V0HCOB_NRCERTIF);

                /*" -903- ELSE */
            }
            else
            {


                /*" -904- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -905- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(COBHISVI)' */
                    _.Display($"R0240-00 - PROBLEMAS NO SELECT(COBHISVI)");

                    /*" -906- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -907- ELSE */
                }
                else
                {


                    /*" -907- ADD 1 TO TE-COBHISVI. */
                    WS_WORK_AREAS.TE_COBHISVI.Value = WS_WORK_AREAS.TE_COBHISVI + 1;
                }

            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-COBHISVI-DB-SELECT-1 */
        public void R0240_00_SELECT_COBHISVI_DB_SELECT_1()
        {
            /*" -895- EXEC SQL SELECT NRCERTIF ,NRPARCEL ,NRTIT ,VLPRMTOT ,SITUACAO ,OCORHIST ,CODOPER ,OPCAOPAG ,DTVENCTO INTO :V0HCOB-NRCERTIF ,:V0HCOB-NRPARCEL ,:V0HCOB-NRTIT ,:V0HCOB-VLPRMTOT ,:V0HCOB-SITUACAO ,:V0HCOB-OCORHIST ,:V0HCOB-CODOPER ,:V0HCOB-OPCAOPAG ,:V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1 = new R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            var executed_1 = R0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_COBHISVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRCERTIF, V0HCOB_NRCERTIF);
                _.Move(executed_1.V0HCOB_NRPARCEL, V0HCOB_NRPARCEL);
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_CODOPER, V0HCOB_CODOPER);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-MONTA-V0FOLLOWUP-SECTION */
        private void R0300_00_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -920- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -921- MOVE SPACES TO V0FOLL-DACPARC */
            _.Move("", V0FOLL_DACPARC);

            /*" -922- MOVE 30 TO V0FOLL-CODBAIXA */
            _.Move(30, V0FOLL_CODBAIXA);

            /*" -926- MOVE SPACES TO V0FOLL-CDERRO02 V0FOLL-CDERRO03 V0FOLL-CDERRO05 V0FOLL-CDERRO06 */
            _.Move("", V0FOLL_CDERRO02, V0FOLL_CDERRO03, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -928- MOVE '0' TO V0FOLL-SITUACAO V0FOLL-SITCONTB */
            _.Move("0", V0FOLL_SITUACAO, V0FOLL_SITCONTB);

            /*" -929- MOVE 103 TO V0FOLL-OPERACAO */
            _.Move(103, V0FOLL_OPERACAO);

            /*" -930- MOVE SPACES TO V0FOLL-DTLIBER */
            _.Move("", V0FOLL_DTLIBER);

            /*" -931- MOVE ZEROS TO V0FOLL-CODEMP */
            _.Move(0, V0FOLL_CODEMP);

            /*" -932- MOVE '1' TO V0FOLL-TIPSGU */
            _.Move("1", V0FOLL_TIPSGU);

            /*" -936- MOVE ZEROS TO V0FOLL-ORDLIDER V0FOLL-CODLIDER V0FOLL-FONTE V0FOLL-NRRCAP */
            _.Move(0, V0FOLL_ORDLIDER, V0FOLL_CODLIDER, V0FOLL_FONTE, V0FOLL_NRRCAP);

            /*" -939- MOVE SPACES TO V0FOLL-APOLIDER V0FOLL-ENDOSLID. */
            _.Move("", V0FOLL_APOLIDER, V0FOLL_ENDOSLID);

            /*" -940- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -941- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA);

            /*" -942- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT1);

            /*" -943- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);

            /*" -944- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_2PT2);

            /*" -945- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

            /*" -948- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_WORK_AREAS.FILLER_2.WTIME_DAYR, V0FOLL_HORAOPER);

            /*" -950- MOVE ZEROS TO VIND-CODEMP VIND-TIPSGU */
            _.Move(0, VIND_CODEMP, VIND_TIPSGU);

            /*" -956- MOVE -1 TO VIND-DTLIBER VIND-ORDLIDER VIND-APOLIDER VIND-ENDOSLID VIND-CODLIDER. */
            _.Move(-1, VIND_DTLIBER, VIND_ORDLIDER, VIND_APOLIDER, VIND_ENDOSLID, VIND_CODLIDER);

            /*" -957- IF V0MOVC-DTQITBCO NOT EQUAL SPACES */

            if (!V0MOVC_DTQITBCO.IsEmpty())
            {

                /*" -958- MOVE ZEROS TO VIND-DTQITBCO */
                _.Move(0, VIND_DTQITBCO);

                /*" -959- ELSE */
            }
            else
            {


                /*" -961- MOVE -1 TO VIND-DTQITBCO. */
                _.Move(-1, VIND_DTQITBCO);
            }


            /*" -962- IF V0FOLL-FONTE NOT EQUAL ZEROS */

            if (V0FOLL_FONTE != 00)
            {

                /*" -963- MOVE ZEROS TO VIND-FONTE */
                _.Move(0, VIND_FONTE);

                /*" -964- ELSE */
            }
            else
            {


                /*" -966- MOVE -1 TO VIND-FONTE. */
                _.Move(-1, VIND_FONTE);
            }


            /*" -967- IF V0FOLL-NRRCAP NOT EQUAL ZEROS */

            if (V0FOLL_NRRCAP != 00)
            {

                /*" -968- MOVE ZEROS TO VIND-NRRCAP */
                _.Move(0, VIND_NRRCAP);

                /*" -969- ELSE */
            }
            else
            {


                /*" -972- MOVE -1 TO VIND-NRRCAP. */
                _.Move(-1, VIND_NRRCAP);
            }


            /*" -974- PERFORM R0310-00-INSERT-V0FOLLOWUP. */

            R0310_00_INSERT_V0FOLLOWUP_SECTION();

            /*" -975- MOVE '2' TO V0MOVC-SITUACAO. */
            _.Move("2", V0MOVC_SITUACAO);

            /*" -975- PERFORM R0320-00-UPDATE-V0MOVIMCOB. */

            R0320_00_UPDATE_V0MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-INSERT-V0FOLLOWUP-SECTION */
        private void R0310_00_INSERT_V0FOLLOWUP_SECTION()
        {
            /*" -988- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -1022- PERFORM R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1 */

            R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1();

            /*" -1026- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1027- PERFORM R0315-00-ADICIONA-TIME */

                R0315_00_ADICIONA_TIME_SECTION();

                /*" -1028- GO TO R0310-00-INSERT-V0FOLLOWUP */
                new Task(() => R0310_00_INSERT_V0FOLLOWUP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1029- ELSE */
            }
            else
            {


                /*" -1030- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1062- DISPLAY 'R0310-00 - PROBLEMAS INSERT (V0FOLLOWUP) ' ' V0MOVC-NUM-APOLICE  ' V0MOVC-NUM-APOLICE ' V0MOVC-NRENDOS      ' V0MOVC-NRENDOS ' V0MOVC-NRPARCEL     ' V0MOVC-NRPARCEL ' V0FOLL-DACPARC      ' V0FOLL-DACPARC ' V0MOVC-DTMOVTO      ' V0MOVC-DTMOVTO ' V0FOLL-HORAOPER     ' V0FOLL-HORAOPER ' V0MOVC-VALTIT       ' V0MOVC-VALTIT ' V0MOVC-BCOAVISO     ' V0MOVC-BCOAVISO ' V0MOVC-AGEAVISO     ' V0MOVC-AGEAVISO ' V0MOVC-NRAVISO      ' V0MOVC-NRAVISO ' V0FOLL-CODBAIXA     ' V0FOLL-CODBAIXA ' V0FOLL-CDERRO01     ' V0FOLL-CDERRO01 ' V0FOLL-CDERRO02     ' V0FOLL-CDERRO02 ' V0FOLL-CDERRO03     ' V0FOLL-CDERRO03 ' V0FOLL-CDERRO04     ' V0FOLL-CDERRO04 ' V0FOLL-CDERRO05     ' V0FOLL-CDERRO05 ' V0FOLL-CDERRO06     ' V0FOLL-CDERRO06 ' V0FOLL-SITUACAO     ' V0FOLL-SITUACAO ' V0FOLL-SITCONTB     ' V0FOLL-SITCONTB ' V0FOLL-OPERACAO     ' V0FOLL-OPERACAO ' V0FOLL-DTLIBER      ' V0FOLL-DTLIBER ' V0MOVC-DTQITBCO     ' V0MOVC-DTQITBCO ' V0FOLL-CODEMP       ' V0FOLL-CODEMP ' V0FOLL-ORDLIDER     ' V0FOLL-ORDLIDER ' V0FOLL-TIPSGU       ' V0FOLL-TIPSGU ' V0FOLL-APOLIDER     ' V0FOLL-APOLIDER ' V0FOLL-ENDOSLID     ' V0FOLL-ENDOSLID ' V0FOLL-CODLIDER     ' V0FOLL-CODLIDER ' V0FOLL-FONTE        ' V0FOLL-FONTE ' V0FOLL-NRRCAP       ' V0FOLL-NRRCAP ' V0MOVC-NOSSO-TITULO ' V0MOVC-NOSSO-TITULO */

                    $"R0310-00 - PROBLEMAS INSERT (V0FOLLOWUP)  V0MOVC-NUM-APOLICE  {V0MOVC_NUM_APOLICE} V0MOVC-NRENDOS      {V0MOVC_NRENDOS} V0MOVC-NRPARCEL     {V0MOVC_NRPARCEL} V0FOLL-DACPARC      {V0FOLL_DACPARC} V0MOVC-DTMOVTO      {V0MOVC_DTMOVTO} V0FOLL-HORAOPER     {V0FOLL_HORAOPER} V0MOVC-VALTIT       {V0MOVC_VALTIT} V0MOVC-BCOAVISO     {V0MOVC_BCOAVISO} V0MOVC-AGEAVISO     {V0MOVC_AGEAVISO} V0MOVC-NRAVISO      {V0MOVC_NRAVISO} V0FOLL-CODBAIXA     {V0FOLL_CODBAIXA} V0FOLL-CDERRO01     {V0FOLL_CDERRO01} V0FOLL-CDERRO02     {V0FOLL_CDERRO02} V0FOLL-CDERRO03     {V0FOLL_CDERRO03} V0FOLL-CDERRO04     {V0FOLL_CDERRO04} V0FOLL-CDERRO05     {V0FOLL_CDERRO05} V0FOLL-CDERRO06     {V0FOLL_CDERRO06} V0FOLL-SITUACAO     {V0FOLL_SITUACAO} V0FOLL-SITCONTB     {V0FOLL_SITCONTB} V0FOLL-OPERACAO     {V0FOLL_OPERACAO} V0FOLL-DTLIBER      {V0FOLL_DTLIBER} V0MOVC-DTQITBCO     {V0MOVC_DTQITBCO} V0FOLL-CODEMP       {V0FOLL_CODEMP} V0FOLL-ORDLIDER     {V0FOLL_ORDLIDER} V0FOLL-TIPSGU       {V0FOLL_TIPSGU} V0FOLL-APOLIDER     {V0FOLL_APOLIDER} V0FOLL-ENDOSLID     {V0FOLL_ENDOSLID} V0FOLL-CODLIDER     {V0FOLL_CODLIDER} V0FOLL-FONTE        {V0FOLL_FONTE} V0FOLL-NRRCAP       {V0FOLL_NRRCAP} V0MOVC-NOSSO-TITULO {V0MOVC_NOSSO_TITULO}"
                    .Display();

                    /*" -1063- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1064- ELSE */
                }
                else
                {


                    /*" -1064- ADD 1 TO AC-FOLLOWUP. */
                    WS_WORK_AREAS.AC_FOLLOWUP.Value = WS_WORK_AREAS.AC_FOLLOWUP + 1;
                }

            }


        }

        [StopWatch]
        /*" R0310-00-INSERT-V0FOLLOWUP-DB-INSERT-1 */
        public void R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1()
        {
            /*" -1022- EXEC SQL INSERT INTO SEGUROS.V0FOLLOWUP VALUES (:V0MOVC-NUM-APOLICE ,:V0MOVC-NRENDOS ,:V0MOVC-NRPARCEL ,:V0FOLL-DACPARC ,:V0MOVC-DTMOVTO ,:V0FOLL-HORAOPER ,:V0MOVC-VALTIT ,:V0MOVC-BCOAVISO ,:V0MOVC-AGEAVISO ,:V0MOVC-NRAVISO ,:V0FOLL-CODBAIXA ,:V0FOLL-CDERRO01 ,:V0FOLL-CDERRO02 ,:V0FOLL-CDERRO03 ,:V0FOLL-CDERRO04 ,:V0FOLL-CDERRO05 ,:V0FOLL-CDERRO06 ,:V0FOLL-SITUACAO ,:V0FOLL-SITCONTB ,:V0FOLL-OPERACAO ,:V0FOLL-DTLIBER:VIND-DTLIBER ,:V0MOVC-DTQITBCO:VIND-DTQITBCO ,:V0FOLL-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP ,:V0FOLL-ORDLIDER:VIND-ORDLIDER ,:V0FOLL-TIPSGU:VIND-TIPSGU ,:V0FOLL-APOLIDER:VIND-APOLIDER ,:V0FOLL-ENDOSLID:VIND-ENDOSLID ,:V0FOLL-CODLIDER:VIND-CODLIDER ,:V0FOLL-FONTE:VIND-FONTE ,:V0FOLL-NRRCAP:VIND-NRRCAP ,:V0MOVC-NOSSO-TITULO) END-EXEC. */

            var r0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 = new R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1()
            {
                V0MOVC_NUM_APOLICE = V0MOVC_NUM_APOLICE.ToString(),
                V0MOVC_NRENDOS = V0MOVC_NRENDOS.ToString(),
                V0MOVC_NRPARCEL = V0MOVC_NRPARCEL.ToString(),
                V0FOLL_DACPARC = V0FOLL_DACPARC.ToString(),
                V0MOVC_DTMOVTO = V0MOVC_DTMOVTO.ToString(),
                V0FOLL_HORAOPER = V0FOLL_HORAOPER.ToString(),
                V0MOVC_VALTIT = V0MOVC_VALTIT.ToString(),
                V0MOVC_BCOAVISO = V0MOVC_BCOAVISO.ToString(),
                V0MOVC_AGEAVISO = V0MOVC_AGEAVISO.ToString(),
                V0MOVC_NRAVISO = V0MOVC_NRAVISO.ToString(),
                V0FOLL_CODBAIXA = V0FOLL_CODBAIXA.ToString(),
                V0FOLL_CDERRO01 = V0FOLL_CDERRO01.ToString(),
                V0FOLL_CDERRO02 = V0FOLL_CDERRO02.ToString(),
                V0FOLL_CDERRO03 = V0FOLL_CDERRO03.ToString(),
                V0FOLL_CDERRO04 = V0FOLL_CDERRO04.ToString(),
                V0FOLL_CDERRO05 = V0FOLL_CDERRO05.ToString(),
                V0FOLL_CDERRO06 = V0FOLL_CDERRO06.ToString(),
                V0FOLL_SITUACAO = V0FOLL_SITUACAO.ToString(),
                V0FOLL_SITCONTB = V0FOLL_SITCONTB.ToString(),
                V0FOLL_OPERACAO = V0FOLL_OPERACAO.ToString(),
                V0FOLL_DTLIBER = V0FOLL_DTLIBER.ToString(),
                VIND_DTLIBER = VIND_DTLIBER.ToString(),
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0FOLL_CODEMP = V0FOLL_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0FOLL_ORDLIDER = V0FOLL_ORDLIDER.ToString(),
                VIND_ORDLIDER = VIND_ORDLIDER.ToString(),
                V0FOLL_TIPSGU = V0FOLL_TIPSGU.ToString(),
                VIND_TIPSGU = VIND_TIPSGU.ToString(),
                V0FOLL_APOLIDER = V0FOLL_APOLIDER.ToString(),
                VIND_APOLIDER = VIND_APOLIDER.ToString(),
                V0FOLL_ENDOSLID = V0FOLL_ENDOSLID.ToString(),
                VIND_ENDOSLID = VIND_ENDOSLID.ToString(),
                V0FOLL_CODLIDER = V0FOLL_CODLIDER.ToString(),
                VIND_CODLIDER = VIND_CODLIDER.ToString(),
                V0FOLL_FONTE = V0FOLL_FONTE.ToString(),
                VIND_FONTE = VIND_FONTE.ToString(),
                V0FOLL_NRRCAP = V0FOLL_NRRCAP.ToString(),
                VIND_NRRCAP = VIND_NRRCAP.ToString(),
                V0MOVC_NOSSO_TITULO = V0MOVC_NOSSO_TITULO.ToString(),
            };

            R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1.Execute(r0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0315-00-ADICIONA-TIME-SECTION */
        private void R0315_00_ADICIONA_TIME_SECTION()
        {
            /*" -1077- MOVE '0315' TO WNR-EXEC-SQL. */
            _.Move("0315", WABEND.WNR_EXEC_SQL);

            /*" -1079- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU > 00 && WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -1080- ADD 1 TO WTIME-SEGU */
                WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU.Value = WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -1081- ELSE */
            }
            else
            {


                /*" -1083- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU > 00 && WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -1084- ADD 1 TO WTIME-MINU */
                    WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU.Value = WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -1085- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

                    /*" -1086- ELSE */
                }
                else
                {


                    /*" -1088- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA > 00 && WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -1089- ADD 1 TO WTIME-HORA */
                        WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA.Value = WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -1091- MOVE 1 TO WTIME-MINU WTIME-SEGU */
                        _.Move(1, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);
                        _.Move(1, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);


                        /*" -1092- ELSE */
                    }
                    else
                    {


                        /*" -1097- MOVE 01 TO WTIME-HORA WTIME-MINU WTIME-SEGU. */
                        _.Move(01, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_HORA);
                        _.Move(01, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_MINU);
                        _.Move(01, WS_WORK_AREAS.FILLER_2.WTIME_DAYR.WTIME_SEGU);

                    }

                }

            }


            /*" -1097- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_WORK_AREAS.FILLER_2.WTIME_DAYR, V0FOLL_HORAOPER);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-UPDATE-V0MOVIMCOB-SECTION */
        private void R0320_00_UPDATE_V0MOVIMCOB_SECTION()
        {
            /*" -1110- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", WABEND.WNR_EXEC_SQL);

            /*" -1117- PERFORM R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1 */

            R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1();

            /*" -1121- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1122- DISPLAY 'R0320-00 - PROBLEMAS UPDATE (NOVIMCOB) ' */
                _.Display($"R0320-00 - PROBLEMAS UPDATE (NOVIMCOB) ");

                /*" -1122- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0320-00-UPDATE-V0MOVIMCOB-DB-UPDATE-1 */
        public void R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1()
        {
            /*" -1117- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET NUM_TITULO = :V0MOVC-NRTIT ,NUM_PARCELA = :V0MOVC-NRPARCEL ,SIT_REGISTRO = :V0MOVC-SITUACAO ,NOME_SEGURADO = :V0MOVC-NOME WHERE CURRENT OF V0MOVIMCOB END-EXEC. */

            var r0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1 = new R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1(V0MOVIMCOB)
            {
                V0MOVC_NRPARCEL = V0MOVC_NRPARCEL.ToString(),
                V0MOVC_SITUACAO = V0MOVC_SITUACAO.ToString(),
                V0MOVC_NRTIT = V0MOVC_NRTIT.ToString(),
                V0MOVC_NOME = V0MOVC_NOME.ToString(),
            };

            R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1.Execute(r0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-V0PROPOVA-SECTION */
        private void R0400_00_SELECT_V0PROPOVA_SECTION()
        {
            /*" -1135- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -1181- PERFORM R0400_00_SELECT_V0PROPOVA_DB_SELECT_1 */

            R0400_00_SELECT_V0PROPOVA_DB_SELECT_1();

            /*" -1185- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1187- MOVE 'VG0816B-PROPOSTA NAO ENCONTRADA PROPOVA' TO V0MOVC-NOME */
                _.Move("VG0816B-PROPOSTA NAO ENCONTRADA PROPOVA", V0MOVC_NOME);

                /*" -1189- MOVE ZEROS TO V0PROP-NUM-APOLICE */
                _.Move(0, V0PROP_NUM_APOLICE);

                /*" -1190- MOVE '1' TO V0FOLL-CDERRO01 */
                _.Move("1", V0FOLL_CDERRO01);

                /*" -1191- MOVE SPACES TO V0FOLL-CDERRO04 */
                _.Move("", V0FOLL_CDERRO04);

                /*" -1194- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1195- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1196- DISPLAY 'R0400-00 - PROBLEMAS NO SELECT(PROPOVA)' */
                _.Display($"R0400-00 - PROBLEMAS NO SELECT(PROPOVA)");

                /*" -1199- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1200- IF VIND-ESTR-COBR LESS ZEROS */

            if (VIND_ESTR_COBR < 00)
            {

                /*" -1202- MOVE SPACES TO V0PROP-ESTR-COBR. */
                _.Move("", V0PROP_ESTR_COBR);
            }


            /*" -1203- IF VIND-ORIG-PRODU LESS ZEROS */

            if (VIND_ORIG_PRODU < 00)
            {

                /*" -1205- MOVE SPACES TO V0PROP-ORIG-PRODU. */
                _.Move("", V0PROP_ORIG_PRODU);
            }


            /*" -1206- IF V0PROP-INRMATRFUN LESS ZEROS */

            if (V0PROP_INRMATRFUN < 00)
            {

                /*" -1208- MOVE ZEROS TO V0PROP-NRMATRFUN. */
                _.Move(0, V0PROP_NRMATRFUN);
            }


            /*" -1209- IF VIND-TEM-SAF LESS ZEROS */

            if (VIND_TEM_SAF < 00)
            {

                /*" -1211- MOVE 'N' TO V0PROP-TEM-SAF. */
                _.Move("N", V0PROP_TEM_SAF);
            }


            /*" -1212- IF VIND-TEM-CDG LESS ZEROS */

            if (VIND_TEM_CDG < 00)
            {

                /*" -1214- MOVE 'N' TO V0PROP-TEM-CDG. */
                _.Move("N", V0PROP_TEM_CDG);
            }


            /*" -1215- IF VIND-RISCO LESS ZEROS */

            if (VIND_RISCO < 00)
            {

                /*" -1218- MOVE '1' TO V0PROP-RISCO. */
                _.Move("1", V0PROP_RISCO);
            }


            /*" -1220- IF V0PROP-ESTR-COBR EQUAL 'MULT' NEXT SENTENCE */

            if (V0PROP_ESTR_COBR == "MULT")
            {

                /*" -1221- ELSE */
            }
            else
            {


                /*" -1223- IF V0PROP-ESTR-COBR EQUAL 'FEDERAL   ' NEXT SENTENCE */

                if (V0PROP_ESTR_COBR == "FEDERAL   ")
                {

                    /*" -1224- ELSE */
                }
                else
                {


                    /*" -1226- MOVE 'VG0816B-ESTR-COBR NAO PREVISTA  ' TO V0MOVC-NOME */
                    _.Move("VG0816B-ESTR-COBR NAO PREVISTA  ", V0MOVC_NOME);

                    /*" -1228- MOVE ZEROS TO V0PROP-NUM-APOLICE */
                    _.Move(0, V0PROP_NUM_APOLICE);

                    /*" -1229- MOVE SPACES TO V0FOLL-CDERRO01 */
                    _.Move("", V0FOLL_CDERRO01);

                    /*" -1230- MOVE '1' TO V0FOLL-CDERRO04 */
                    _.Move("1", V0FOLL_CDERRO04);

                    /*" -1233- GO TO R0400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1241- IF V0PROP-SITUACAO EQUAL '3' OR '4' OR '6' OR '8' OR 'A' OR 'C' OR 'D' NEXT SENTENCE */

            if (V0PROP_SITUACAO.In("3", "4", "6", "8", "A", "C", "D"))
            {

                /*" -1242- ELSE */
            }
            else
            {


                /*" -1244- MOVE 'VG0816B-SITUACAO PROPOSTA DIVERGE' TO V0MOVC-NOME */
                _.Move("VG0816B-SITUACAO PROPOSTA DIVERGE", V0MOVC_NOME);

                /*" -1246- MOVE ZEROS TO V0PROP-NUM-APOLICE */
                _.Move(0, V0PROP_NUM_APOLICE);

                /*" -1247- MOVE SPACES TO V0FOLL-CDERRO01 */
                _.Move("", V0FOLL_CDERRO01);

                /*" -1247- MOVE '1' TO V0FOLL-CDERRO04. */
                _.Move("1", V0FOLL_CDERRO04);
            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-V0PROPOVA-DB-SELECT-1 */
        public void R0400_00_SELECT_V0PROPOVA_DB_SELECT_1()
        {
            /*" -1181- EXEC SQL SELECT A.CODCLIEN ,A.NUM_APOLICE ,A.CODSUBES ,A.FONTE ,A.SITUACAO ,A.QTDPARATZ ,A.NUM_MATRICULA ,A.OPCAO_COBER ,A.DTQITBCO ,A.CODPRODU ,A.NRPARCE ,B.TEM_SAF ,B.TEM_CDG ,B.RISCO ,B.ESTR_COBR ,B.ORIG_PRODU ,B.CUSTOCAP_TOTAL ,C.RAMO INTO :V0PROP-CODCLIEN ,:V0PROP-NUM-APOLICE ,:V0PROP-CODSUBES ,:V0PROP-FONTE ,:V0PROP-SITUACAO ,:V0PROP-QTDPARATZ ,:V0PROP-NRMATRFUN:V0PROP-INRMATRFUN ,:V0PROP-OPCAO-COBER ,:V0PROP-DTQITBCO ,:V0PROP-CODPRODU ,:V0PROP-NRPARCEL ,:V0PROP-TEM-SAF:VIND-TEM-SAF ,:V0PROP-TEM-CDG:VIND-TEM-CDG ,:V0PROP-RISCO:VIND-RISCO ,:V0PROP-ESTR-COBR:VIND-ESTR-COBR ,:V0PROP-ORIG-PRODU:VIND-ORIG-PRODU ,:V0PROP-CUSTOCAP-TOTAL ,:V0PROP-RAMO FROM SEGUROS.V0PROPOSTAVA A ,SEGUROS.V0PRODUTOSVG B ,SEGUROS.V0APOLICE C WHERE A.NRCERTIF = :V0HCOB-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1 = new R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1);
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
                _.Move(executed_1.V0PROP_OPCAO_COBER, V0PROP_OPCAO_COBER);
                _.Move(executed_1.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(executed_1.V0PROP_TEM_SAF, V0PROP_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PROP_TEM_CDG, V0PROP_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.V0PROP_RISCO, V0PROP_RISCO);
                _.Move(executed_1.VIND_RISCO, VIND_RISCO);
                _.Move(executed_1.V0PROP_ESTR_COBR, V0PROP_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.V0PROP_ORIG_PRODU, V0PROP_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.V0PROP_CUSTOCAP_TOTAL, V0PROP_CUSTOCAP_TOTAL);
                _.Move(executed_1.V0PROP_RAMO, V0PROP_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-V0PARCELVA-SECTION */
        private void R0420_00_SELECT_V0PARCELVA_SECTION()
        {
            /*" -1260- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", WABEND.WNR_EXEC_SQL);

            /*" -1274- PERFORM R0420_00_SELECT_V0PARCELVA_DB_SELECT_1 */

            R0420_00_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -1278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1279- DISPLAY 'R0420-00 - PROBLEMAS NO SELECT(PARCELVA)' */
                _.Display($"R0420-00 - PROBLEMAS NO SELECT(PARCELVA)");

                /*" -1282- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1283- MOVE V0PARC-PRMVG TO V0HCTB-PRMVG. */
            _.Move(V0PARC_PRMVG, V0HCTB_PRMVG);

            /*" -1284- MOVE V0PARC-PRMAP TO V0HCTB-PRMAP. */
            _.Move(V0PARC_PRMAP, V0HCTB_PRMAP);

            /*" -1286- MOVE ZEROS TO WS-DIFERENCA. */
            _.Move(0, WS_WORK_AREAS.WS_DIFERENCA);

            /*" -1287- IF V0HCOB-SITUACAO EQUAL '1' */

            if (V0HCOB_SITUACAO == "1")
            {

                /*" -1288- MOVE 204 TO V0HCTB-CODOPER */
                _.Move(204, V0HCTB_CODOPER);

                /*" -1289- MOVE 604 TO V0DIFP-CODOPER */
                _.Move(604, V0DIFP_CODOPER);

                /*" -1290- MOVE V0MOVC-VALTIT TO WS-DIFERENCA */
                _.Move(V0MOVC_VALTIT, WS_WORK_AREAS.WS_DIFERENCA);

                /*" -1292- MOVE 0 TO V0DIFP-PRMDEVVG V0DIFP-PRMDEVAP */
                _.Move(0, V0DIFP_PRMDEVVG, V0DIFP_PRMDEVAP);

                /*" -1293- ELSE */
            }
            else
            {


                /*" -1294- IF V0MOVC-VALTIT EQUAL V0HCOB-VLPRMTOT */

                if (V0MOVC_VALTIT == V0HCOB_VLPRMTOT)
                {

                    /*" -1295- MOVE 201 TO V0HCTB-CODOPER */
                    _.Move(201, V0HCTB_CODOPER);

                    /*" -1296- ELSE */
                }
                else
                {


                    /*" -1297- MOVE V0PARC-PRMVG TO V0DIFP-PRMDEVVG */
                    _.Move(V0PARC_PRMVG, V0DIFP_PRMDEVVG);

                    /*" -1298- MOVE V0PARC-PRMAP TO V0DIFP-PRMDEVAP */
                    _.Move(V0PARC_PRMAP, V0DIFP_PRMDEVAP);

                    /*" -1299- IF V0MOVC-VALTIT LESS V0HCOB-VLPRMTOT */

                    if (V0MOVC_VALTIT < V0HCOB_VLPRMTOT)
                    {

                        /*" -1300- MOVE 206 TO V0HCTB-CODOPER */
                        _.Move(206, V0HCTB_CODOPER);

                        /*" -1301- MOVE 406 TO V0DIFP-CODOPER */
                        _.Move(406, V0DIFP_CODOPER);

                        /*" -1303- COMPUTE WS-DIFERENCA EQUAL V0HCOB-VLPRMTOT - V0MOVC-VALTIT */
                        WS_WORK_AREAS.WS_DIFERENCA.Value = V0HCOB_VLPRMTOT - V0MOVC_VALTIT;

                        /*" -1304- ELSE */
                    }
                    else
                    {


                        /*" -1305- MOVE 207 TO V0HCTB-CODOPER */
                        _.Move(207, V0HCTB_CODOPER);

                        /*" -1306- MOVE 607 TO V0DIFP-CODOPER */
                        _.Move(607, V0DIFP_CODOPER);

                        /*" -1307- COMPUTE WS-DIFERENCA EQUAL V0MOVC-VALTIT - V0HCOB-VLPRMTOT. */
                        WS_WORK_AREAS.WS_DIFERENCA.Value = V0MOVC_VALTIT - V0HCOB_VLPRMTOT;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void R0420_00_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -1274- EXEC SQL SELECT PRMVG ,PRMAP ,DTVENCTO ,PRMVG + PRMAP INTO :V0PARC-PRMVG ,:V0PARC-PRMAP ,:V0PARC-DTVENCTO ,:V0PARC-PRMTOT FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 = new R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            var executed_1 = R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(executed_1.V0PARC_PRMTOT, V0PARC_PRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-SELECT-V0COBERPROPVA-SECTION */
        private void R0440_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -1320- MOVE '0440' TO WNR-EXEC-SQL. */
            _.Move("0440", WABEND.WNR_EXEC_SQL);

            /*" -1359- PERFORM R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -1363- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1364- PERFORM R0450-00-SELECT-V0COBERPROPVA */

                R0450_00_SELECT_V0COBERPROPVA_SECTION();

                /*" -1365- ELSE */
            }
            else
            {


                /*" -1366- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1367- DISPLAY 'R0440-00 - PROBLEMAS NO SELECT(COBERPROPVA)' */
                    _.Display($"R0440-00 - PROBLEMAS NO SELECT(COBERPROPVA)");

                    /*" -1370- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1371- IF V0COBP-VLCUSTAUXF-I LESS ZEROS */

            if (V0COBP_VLCUSTAUXF_I < 00)
            {

                /*" -1373- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1374- IF V0COBP-IMPSEGAUXF-I LESS ZEROS */

            if (V0COBP_IMPSEGAUXF_I < 00)
            {

                /*" -1377- MOVE ZEROS TO V0COBP-IMPSEGAUXF. */
                _.Move(0, V0COBP_IMPSEGAUXF);
            }


            /*" -1379- IF V0PARC-PRMTOT EQUAL ZEROS AND V0COBP-PRMTOT EQUAL ZEROS */

            if (V0PARC_PRMTOT == 00 && V0COBP_PRMTOT == 00)
            {

                /*" -1382- GO TO R0440-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1383- IF WS-DIFERENCA NOT EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_DIFERENCA != 00)
            {

                /*" -1384- IF V0PARC-PRMTOT NOT EQUAL ZEROS */

                if (V0PARC_PRMTOT != 00)
                {

                    /*" -1385- IF V0HCOB-VLPRMTOT NOT EQUAL ZEROS */

                    if (V0HCOB_VLPRMTOT != 00)
                    {

                        /*" -1386- COMPUTE WS-PC-VG = V0PARC-PRMVG / V0HCOB-VLPRMTOT */
                        WS_WORK_AREAS.WS_PC_VG.Value = V0PARC_PRMVG / V0HCOB_VLPRMTOT;

                        /*" -1387- ELSE */
                    }
                    else
                    {


                        /*" -1388- COMPUTE WS-PC-VG = V0COBP-PRMVG / V0COBP-PRMTOT */
                        WS_WORK_AREAS.WS_PC_VG.Value = V0COBP_PRMVG / V0COBP_PRMTOT;

                        /*" -1389- ELSE */
                    }

                }
                else
                {


                    /*" -1390- COMPUTE WS-PC-VG = V0COBP-PRMVG / V0COBP-PRMTOT */
                    WS_WORK_AREAS.WS_PC_VG.Value = V0COBP_PRMVG / V0COBP_PRMTOT;

                    /*" -1391- END-IF */
                }


                /*" -1392- COMPUTE V0DIFP-PRMPAGVG = V0MOVC-VALTIT * WS-PC-VG */
                V0DIFP_PRMPAGVG.Value = V0MOVC_VALTIT * WS_WORK_AREAS.WS_PC_VG;

                /*" -1394- COMPUTE V0DIFP-PRMPAGAP = V0MOVC-VALTIT - V0DIFP-PRMPAGVG */
                V0DIFP_PRMPAGAP.Value = V0MOVC_VALTIT - V0DIFP_PRMPAGVG;

                /*" -1395- IF V0PROP-ESTR-COBR EQUAL 'MULT' */

                if (V0PROP_ESTR_COBR == "MULT")
                {

                    /*" -1396- MOVE V0DIFP-PRMPAGVG TO V0PARC-PRMVG */
                    _.Move(V0DIFP_PRMPAGVG, V0PARC_PRMVG);

                    /*" -1397- MOVE V0DIFP-PRMPAGAP TO V0PARC-PRMAP */
                    _.Move(V0DIFP_PRMPAGAP, V0PARC_PRMAP);

                    /*" -1398- END-IF */
                }


                /*" -1399- MOVE V0DIFP-PRMPAGVG TO V0HCTB-PRMVG */
                _.Move(V0DIFP_PRMPAGVG, V0HCTB_PRMVG);

                /*" -1400- MOVE V0DIFP-PRMPAGAP TO V0HCTB-PRMAP */
                _.Move(V0DIFP_PRMPAGAP, V0HCTB_PRMAP);

                /*" -1401- COMPUTE V0DIFP-PRMDIFVG = WS-DIFERENCA * WS-PC-VG */
                V0DIFP_PRMDIFVG.Value = WS_WORK_AREAS.WS_DIFERENCA * WS_WORK_AREAS.WS_PC_VG;

                /*" -1404- COMPUTE V0DIFP-PRMDIFAP = WS-DIFERENCA - V0DIFP-PRMDIFVG. */
                V0DIFP_PRMDIFAP.Value = WS_WORK_AREAS.WS_DIFERENCA - V0DIFP_PRMDIFVG;
            }


            /*" -1405- IF WS-DIFERENCA NOT EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_DIFERENCA != 00)
            {

                /*" -1406- IF V0PROP-ESTR-COBR EQUAL 'MULT' */

                if (V0PROP_ESTR_COBR == "MULT")
                {

                    /*" -1407- IF V0PARC-PRMAP LESS ZEROS */

                    if (V0PARC_PRMAP < 00)
                    {

                        /*" -1408- COMPUTE V0PARC-PRMTOTVG = V0PARC-PRMVG + V0PARC-PRMAP */
                        V0PARC_PRMTOTVG.Value = V0PARC_PRMVG + V0PARC_PRMAP;

                        /*" -1410- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                        if (V0PARC_PRMTOTVG < 00)
                        {

                            /*" -1411- ELSE */
                        }
                        else
                        {


                            /*" -1412- MOVE V0PARC-PRMTOTVG TO V0PARC-PRMVG */
                            _.Move(V0PARC_PRMTOTVG, V0PARC_PRMVG);

                            /*" -1414- MOVE ZEROS TO V0PARC-PRMAP. */
                            _.Move(0, V0PARC_PRMAP);
                        }

                    }

                }

            }


            /*" -1415- IF WS-DIFERENCA NOT EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_DIFERENCA != 00)
            {

                /*" -1416- IF V0DIFP-PRMPAGAP LESS ZEROS */

                if (V0DIFP_PRMPAGAP < 00)
                {

                    /*" -1418- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMPAGVG + V0DIFP-PRMPAGAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMPAGVG + V0DIFP_PRMPAGAP;

                    /*" -1420- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1421- ELSE */
                    }
                    else
                    {


                        /*" -1422- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMPAGVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMPAGVG);

                        /*" -1424- MOVE ZEROS TO V0DIFP-PRMPAGAP. */
                        _.Move(0, V0DIFP_PRMPAGAP);
                    }

                }

            }


            /*" -1425- IF WS-DIFERENCA NOT EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_DIFERENCA != 00)
            {

                /*" -1426- IF V0DIFP-PRMDIFAP LESS ZEROS */

                if (V0DIFP_PRMDIFAP < 00)
                {

                    /*" -1428- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMDIFVG + V0DIFP-PRMDIFAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMDIFVG + V0DIFP_PRMDIFAP;

                    /*" -1430- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1431- ELSE */
                    }
                    else
                    {


                        /*" -1432- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMDIFVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMDIFVG);

                        /*" -1432- MOVE ZEROS TO V0DIFP-PRMDIFAP. */
                        _.Move(0, V0DIFP_PRMDIFAP);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0440-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -1359- EXEC SQL SELECT PRMVG ,PRMAP ,VLPREMIO ,PRMVG + PRMAP ,IMPMORNATU ,IMPMORACID ,IMPDIT ,QUANT_VIDAS ,IMPINVPERM ,IMPDH ,VLCUSTAUXF ,IMPSEGAUXF ,VLCUSTCDG ,IMPSEGCDC ,VLCUSTCAP ,QTTITCAP INTO :V0COBP-PRMVG ,:V0COBP-PRMAP ,:V0COBP-VLPREMIO ,:V0COBP-PRMTOT ,:V0COBP-IMPMORNATU ,:V0COBP-IMPMORACID ,:V0COBP-IMPDIT ,:V0COBP-QUANT-VIDAS ,:V0COBP-IMPINVPERM ,:V0COBP-IMPDH ,:V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I ,:V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I ,:V0COBP-VLCUSTCDG ,:V0COBP-IMPSEGCDG ,:V0COBP-VLCUSTCAP ,:V0COBP-QTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMTOT, V0COBP_PRMTOT);
                _.Move(executed_1.V0COBP_IMPMORNATU, V0COBP_IMPMORNATU);
                _.Move(executed_1.V0COBP_IMPMORACID, V0COBP_IMPMORACID);
                _.Move(executed_1.V0COBP_IMPDIT, V0COBP_IMPDIT);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPINVPERM, V0COBP_IMPINVPERM);
                _.Move(executed_1.V0COBP_IMPDH, V0COBP_IMPDH);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-V0COBERPROPVA-SECTION */
        private void R0450_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -1445- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", WABEND.WNR_EXEC_SQL);

            /*" -1483- PERFORM R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -1487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1488- DISPLAY 'R0450-00 - PROBLEMAS NO SELECT(COBERPROPVA)' */
                _.Display($"R0450-00 - PROBLEMAS NO SELECT(COBERPROPVA)");

                /*" -1488- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -1483- EXEC SQL SELECT PRMVG ,PRMAP ,VLPREMIO ,PRMVG + PRMAP ,IMPMORNATU ,IMPMORACID ,IMPDIT ,QUANT_VIDAS ,IMPINVPERM ,IMPDH ,VLCUSTAUXF ,IMPSEGAUXF ,VLCUSTCDG ,IMPSEGCDC ,VLCUSTCAP ,QTTITCAP INTO :V0COBP-PRMVG ,:V0COBP-PRMAP ,:V0COBP-VLPREMIO ,:V0COBP-PRMTOT ,:V0COBP-IMPMORNATU ,:V0COBP-IMPMORACID ,:V0COBP-IMPDIT ,:V0COBP-QUANT-VIDAS ,:V0COBP-IMPINVPERM ,:V0COBP-IMPDH ,:V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I ,:V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I ,:V0COBP-VLCUSTCDG ,:V0COBP-IMPSEGCDG ,:V0COBP-VLCUSTCAP ,:V0COBP-QTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND DTTERVIG = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMTOT, V0COBP_PRMTOT);
                _.Move(executed_1.V0COBP_IMPMORNATU, V0COBP_IMPMORNATU);
                _.Move(executed_1.V0COBP_IMPMORACID, V0COBP_IMPMORACID);
                _.Move(executed_1.V0COBP_IMPDIT, V0COBP_IMPDIT);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPINVPERM, V0COBP_IMPINVPERM);
                _.Move(executed_1.V0COBP_IMPDH, V0COBP_IMPDH);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-V0OPCAOPAGVA-SECTION */
        private void R0460_00_SELECT_V0OPCAOPAGVA_SECTION()
        {
            /*" -1501- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", WABEND.WNR_EXEC_SQL);

            /*" -1509- PERFORM R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1 */

            R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1();

            /*" -1513- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1514- DISPLAY 'R0460-00 - PROBLEMAS NO SELECT(V0OPCAOPAGV)' */
                _.Display($"R0460-00 - PROBLEMAS NO SELECT(V0OPCAOPAGV)");

                /*" -1514- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-V0OPCAOPAGVA-DB-SELECT-1 */
        public void R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1509- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND DTTERVIG = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 = new R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-TRATA-CONTABIL-SECTION */
        private void R0500_00_TRATA_CONTABIL_SECTION()
        {
            /*" -1537- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1538- IF V0PROP-TEM-CDG EQUAL 'N' */

            if (V0PROP_TEM_CDG == "N")
            {

                /*" -1540- MOVE ZEROS TO V0COBP-VLCUSTCDG. */
                _.Move(0, V0COBP_VLCUSTCDG);
            }


            /*" -1541- IF V0PROP-TEM-SAF EQUAL 'N' */

            if (V0PROP_TEM_SAF == "N")
            {

                /*" -1543- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1544- IF V0PROP-CUSTOCAP-TOTAL EQUAL 'N' */

            if (V0PROP_CUSTOCAP_TOTAL == "N")
            {

                /*" -1547- COMPUTE V0COBP-VLCUSTCAP = V0COBP-VLCUSTCAP * V0COBP-QTTITCAP. */
                V0COBP_VLCUSTCAP.Value = V0COBP_VLCUSTCAP * V0COBP_QTTITCAP;
            }


            /*" -1551- COMPUTE V0HCTVA-VLCOBADIC = V0COBP-VLCUSTCDG + V0COBP-VLCUSTAUXF + V0COBP-VLCUSTCAP. */
            V0HCTVA_VLCOBADIC.Value = V0COBP_VLCUSTCDG + V0COBP_VLCUSTAUXF + V0COBP_VLCUSTCAP;

            /*" -1553- IF V0COBP-PRMVG GREATER ZEROS AND V0COBP-PRMTOT GREATER ZEROS */

            if (V0COBP_PRMVG > 00 && V0COBP_PRMTOT > 00)
            {

                /*" -1554- COMPUTE WS-PCT-COB-VG = V0COBP-PRMVG / V0COBP-PRMTOT */
                WS_WORK_AREAS.WS_PCT_COB_VG.Value = V0COBP_PRMVG / V0COBP_PRMTOT;

                /*" -1556- COMPUTE V0HCTVA-PRMVG ROUNDED = V0MOVC-VALTIT * WS-PCT-COB-VG */
                V0HCTVA_PRMVG.Value = V0MOVC_VALTIT * WS_WORK_AREAS.WS_PCT_COB_VG;

                /*" -1557- COMPUTE V0HCTVA-PRMAP = V0MOVC-VALTIT - V0HCTVA-PRMVG */
                V0HCTVA_PRMAP.Value = V0MOVC_VALTIT - V0HCTVA_PRMVG;

                /*" -1558- ELSE */
            }
            else
            {


                /*" -1559- MOVE ZEROS TO V0HCTVA-PRMVG */
                _.Move(0, V0HCTVA_PRMVG);

                /*" -1562- MOVE V0MOVC-VALTIT TO V0HCTVA-PRMAP. */
                _.Move(V0MOVC_VALTIT, V0HCTVA_PRMAP);
            }


            /*" -1565- COMPUTE V0HCOB-OCORHIST EQUAL V0HCOB-OCORHIST + 1. */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -1565- PERFORM R0510-00-INSERT-HISTCONTABIL. */

            R0510_00_INSERT_HISTCONTABIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-INSERT-HISTCONTABIL-SECTION */
        private void R0510_00_INSERT_HISTCONTABIL_SECTION()
        {
            /*" -1578- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1595- PERFORM R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1 */

            R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1();

            /*" -1599- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1600- DISPLAY 'R0510-00 - REGISTRO DUPLICADO            ' */
                _.Display($"R0510-00 - REGISTRO DUPLICADO            ");

                /*" -1601- DISPLAY ' V0HCOB-NRCERTIF    ' V0HCOB-NRCERTIF */
                _.Display($" V0HCOB-NRCERTIF    {V0HCOB_NRCERTIF}");

                /*" -1602- DISPLAY ' V0HCOB-NRPARCEL    ' V0HCOB-NRPARCEL */
                _.Display($" V0HCOB-NRPARCEL    {V0HCOB_NRPARCEL}");

                /*" -1603- DISPLAY ' V0MOVC-NRTIT       ' V0MOVC-NRTIT */
                _.Display($" V0MOVC-NRTIT       {V0MOVC_NRTIT}");

                /*" -1604- DISPLAY ' V0HCOB-OCORHIST    ' V0HCOB-OCORHIST */
                _.Display($" V0HCOB-OCORHIST    {V0HCOB_OCORHIST}");

                /*" -1605- DISPLAY ' V0PROP-NUM-APOLICE ' V0PROP-NUM-APOLICE */
                _.Display($" V0PROP-NUM-APOLICE {V0PROP_NUM_APOLICE}");

                /*" -1606- DISPLAY ' V0PROP-CODSUBES    ' V0PROP-CODSUBES */
                _.Display($" V0PROP-CODSUBES    {V0PROP_CODSUBES}");

                /*" -1607- DISPLAY ' V0PROP-FONTE       ' V0PROP-FONTE */
                _.Display($" V0PROP-FONTE       {V0PROP_FONTE}");

                /*" -1608- DISPLAY ' V0HCTB-CODOPER     ' V0HCTB-CODOPER */
                _.Display($" V0HCTB-CODOPER     {V0HCTB_CODOPER}");

                /*" -1609- ELSE */
            }
            else
            {


                /*" -1610- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1611- DISPLAY 'R0510-00 - PROBLEMAS INSERT (V0HISTCONTABILVA)' */
                    _.Display($"R0510-00 - PROBLEMAS INSERT (V0HISTCONTABILVA)");

                    /*" -1611- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-INSERT-HISTCONTABIL-DB-INSERT-1 */
        public void R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1()
        {
            /*" -1595- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCOB-NRCERTIF ,:V0HCOB-NRPARCEL ,:V0MOVC-NRTIT ,:V0HCOB-OCORHIST ,:V0PROP-NUM-APOLICE ,:V0PROP-CODSUBES ,:V0PROP-FONTE , 0 ,:V0HCTVA-PRMVG ,:V0HCTVA-PRMAP ,:V0SIST-DTMOVABE , '0' ,:V0HCTB-CODOPER ,CURRENT TIMESTAMP ,NULL) END-EXEC. */

            var r0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1 = new R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0MOVC_NRTIT = V0MOVC_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0HCTVA_PRMVG = V0HCTVA_PRMVG.ToString(),
                V0HCTVA_PRMAP = V0HCTVA_PRMAP.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0HCTB_CODOPER = V0HCTB_CODOPER.ToString(),
            };

            R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1.Execute(r0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-TRATA-CLIENTES-SECTION */
        private void R0550_00_TRATA_CLIENTES_SECTION()
        {
            /*" -1624- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", WABEND.WNR_EXEC_SQL);

            /*" -1627- PERFORM R0560-00-SELECT-V0CLIENTES. */

            R0560_00_SELECT_V0CLIENTES_SECTION();

            /*" -1629- IF V0PROP-DTQITBCO GREATER '2010-12-31' OR V0HCOB-DTVENCTO GREATER WHOST-DTVENCTO */

            if (V0PROP_DTQITBCO > "2010-12-31" || V0HCOB_DTVENCTO > WHOST_DTVENCTO)
            {

                /*" -1630- IF V0PROP-DTQITBCO GREATER '2010-12-31' */

                if (V0PROP_DTQITBCO > "2010-12-31")
                {

                    /*" -1631- MOVE V0PROP-DTQITBCO TO WHOST-DTVENCTO1 */
                    _.Move(V0PROP_DTQITBCO, WHOST_DTVENCTO1);

                    /*" -1632- ELSE */
                }
                else
                {


                    /*" -1633- MOVE WHOST-DTVENCTO TO WHOST-DTVENCTO1 */
                    _.Move(WHOST_DTVENCTO, WHOST_DTVENCTO1);

                    /*" -1635- END-IF */
                }


                /*" -1636- MOVE V0PROP-DTQITBCO(1:4) TO WHOST-ANO-VENC */
                _.Move(V0PROP_DTQITBCO.Substring(1, 4), WHOST_ANO_VENC);

                /*" -1638- MOVE CLIENTES-DATA-NASCIMENTO(1:4) TO WHOST-ANO-NASC */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(1, 4), WHOST_ANO_NASC);

                /*" -1639- COMPUTE WHOST-IDADE = WHOST-ANO-VENC - WHOST-ANO-NASC */
                WHOST_IDADE.Value = WHOST_ANO_VENC - WHOST_ANO_NASC;

                /*" -1641- IF CLIENTES-DATA-NASCIMENTO(6:5) GREATER V0PROP-DTQITBCO(6:5) */

                if (CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(6, 5) > V0PROP_DTQITBCO.Substring(6, 5))
                {

                    /*" -1642- COMPUTE WHOST-IDADE = WHOST-IDADE - 1 */
                    WHOST_IDADE.Value = WHOST_IDADE - 1;

                    /*" -1643- END-IF */
                }


                /*" -1644- IF CLIENTES-TIPO-PESSOA EQUAL 'J' */

                if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "J")
                {

                    /*" -1645- MOVE ZEROS TO WHOST-IDADE */
                    _.Move(0, WHOST_IDADE);

                    /*" -1646- END-IF */
                }


                /*" -1647- PERFORM R0600-00-DECLARE-VGRAMOCOMP */

                R0600_00_DECLARE_VGRAMOCOMP_SECTION();

                /*" -1648- PERFORM R0610-00-FETCH-VGRAMOCOMP */

                R0610_00_FETCH_VGRAMOCOMP_SECTION();

                /*" -1649- INITIALIZE WORK-TAB-RAMO-CONJ */
                _.Initialize(
                    WORK_TAB_RAMO_CONJ
                );

                /*" -1652- MOVE ZEROS TO WS-IND WHOST-VLR-PERC-PREMIO-TOT WS-PREMIO-TOTAL-AC */
                _.Move(0, WORK_RAMO_CONJ.WS_IND, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT, WS_WORK_AREAS.WS_PREMIO_TOTAL_AC);

                /*" -1655- COMPUTE WS-PREMIO-TOTAL = V0HCTVA-PRMVG + V0HCTVA-PRMAP */
                WS_WORK_AREAS.WS_PREMIO_TOTAL.Value = V0HCTVA_PRMVG + V0HCTVA_PRMAP;

                /*" -1658- PERFORM R0700-00-PROCESSA-VGRAMOCOMP UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' */

                while (!(WS_WORK_AREAS.WFIM_VGRAMOCOMP == "SIM"))
                {

                    R0700_00_PROCESSA_VGRAMOCOMP_SECTION();
                }

                /*" -1659- IF WS-IND GREATER ZEROS */

                if (WORK_RAMO_CONJ.WS_IND > 00)
                {

                    /*" -1660- IF V0PROP-RAMO NOT EQUAL TB-RAMO-CONJ (WS-IND) */

                    if (V0PROP_RAMO != WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ)
                    {

                        /*" -1661- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND) TO WS-SALVA */
                        _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND], WORK_RAMO_CONJ.WS_SALVA);

                        /*" -1664- PERFORM VARYING WS-IND1 FROM 1 BY 1 UNTIL WS-IND1 GREATER WS-IND OR TB-RAMO-CONJ (WS-IND1) EQUAL V0PROP-RAMO */

                        for (WORK_RAMO_CONJ.WS_IND1.Value = 1; !(WORK_RAMO_CONJ.WS_IND1 > WORK_RAMO_CONJ.WS_IND || WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ == V0PROP_RAMO); WORK_RAMO_CONJ.WS_IND1.Value += 1)
                        {

                            /*" -1665- END-PERFORM */
                        }

                        /*" -1666- IF WS-IND1 NOT GREATER WS-IND */

                        if (WORK_RAMO_CONJ.WS_IND1 <= WORK_RAMO_CONJ.WS_IND)
                        {

                            /*" -1668- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND1) TO N5WORK-TAB-RAMO-CONJ(WS-IND) */
                            _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1], WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND]);

                            /*" -1670- MOVE WS-SALVA TO N5WORK-TAB-RAMO-CONJ(WS-IND1) */
                            _.Move(WORK_RAMO_CONJ.WS_SALVA, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1]);

                            /*" -1671- END-IF */
                        }


                        /*" -1672- END-IF */
                    }


                    /*" -1674- END-IF */
                }


                /*" -1675- MOVE 'NAO' TO WFIM-TAB-RAMO */
                _.Move("NAO", WS_WORK_AREAS.WFIM_TAB_RAMO);

                /*" -1677- MOVE ZEROS TO WS-IND1 */
                _.Move(0, WORK_RAMO_CONJ.WS_IND1);

                /*" -1678- PERFORM R0800-00-INSERT-VGHISTCONT UNTIL WFIM-TAB-RAMO EQUAL 'SIM' . */

                while (!(WS_WORK_AREAS.WFIM_TAB_RAMO == "SIM"))
                {

                    R0800_00_INSERT_VGHISTCONT_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-SELECT-V0CLIENTES-SECTION */
        private void R0560_00_SELECT_V0CLIENTES_SECTION()
        {
            /*" -1691- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", WABEND.WNR_EXEC_SQL);

            /*" -1702- PERFORM R0560_00_SELECT_V0CLIENTES_DB_SELECT_1 */

            R0560_00_SELECT_V0CLIENTES_DB_SELECT_1();

            /*" -1706- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1707- DISPLAY 'R0560-00 - PROBLEMAS NO SELECT(CLIENTES)' */
                _.Display($"R0560-00 - PROBLEMAS NO SELECT(CLIENTES)");

                /*" -1710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1711- IF VIND-DTNASC LESS ZEROS */

            if (VIND_DTNASC < 00)
            {

                /*" -1714- MOVE '1900-01-01' TO CLIENTES-DATA-NASCIMENTO. */
                _.Move("1900-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


            /*" -1715- MOVE V0PROP-DTQITBCO TO WHOST-DTVENCTO. */
            _.Move(V0PROP_DTQITBCO, WHOST_DTVENCTO);

            /*" -1717- MOVE 2011 TO WHOST-DTVENCTO(1:4). */
            _.MoveAtPosition(2011, WHOST_DTVENCTO, 1, 4);

            /*" -1719- IF (WHOST-DTVENCTO(6:2) EQUAL 02) AND (WHOST-DTVENCTO(9:2) EQUAL 28 OR 29) */

            if ((WHOST_DTVENCTO.Substring(6, 2) == 02) && (WHOST_DTVENCTO.Substring(9, 2).In("28", "29")))
            {

                /*" -1719- PERFORM R0570-00-CALCULA-BISSEXTO. */

                R0570_00_CALCULA_BISSEXTO_SECTION();
            }


        }

        [StopWatch]
        /*" R0560-00-SELECT-V0CLIENTES-DB-SELECT-1 */
        public void R0560_00_SELECT_V0CLIENTES_DB_SELECT_1()
        {
            /*" -1702- EXEC SQL SELECT DATA_NASCIMENTO ,CGCCPF ,TIPO_PESSOA INTO :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC ,:CLIENTES-CGCCPF ,:CLIENTES-TIPO-PESSOA FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :V0PROP-CODCLIEN FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0560_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1 = new R0560_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R0560_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1.Execute(r0560_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-CALCULA-BISSEXTO-SECTION */
        private void R0570_00_CALCULA_BISSEXTO_SECTION()
        {
            /*" -1732- MOVE '0570' TO WNR-EXEC-SQL. */
            _.Move("0570", WABEND.WNR_EXEC_SQL);

            /*" -1735- MOVE WHOST-DTVENCTO(1:4) TO AUX-ANO. */
            _.Move(WHOST_DTVENCTO.Substring(1, 4), WS_WORK_AREAS.AUX_ANO);

            /*" -1736- IF AUX-ANO2 EQUAL ZEROS */

            if (WS_WORK_AREAS.FILLER_1.AUX_ANO2 == 00)
            {

                /*" -1738- DIVIDE AUX-ANO BY 400 GIVING WS-RESULT REMAINDER WS-RESTO */
                _.Divide(WS_WORK_AREAS.AUX_ANO, 400, WS_WORK_AREAS.WS_RESULT, WS_WORK_AREAS.WS_RESTO);

                /*" -1739- ELSE */
            }
            else
            {


                /*" -1742- DIVIDE AUX-ANO BY 4 GIVING WS-RESULT REMAINDER WS-RESTO. */
                _.Divide(WS_WORK_AREAS.AUX_ANO, 4, WS_WORK_AREAS.WS_RESULT, WS_WORK_AREAS.WS_RESTO);
            }


            /*" -1743- IF WS-RESTO EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_RESTO == 00)
            {

                /*" -1744- MOVE 29 TO WHOST-DTVENCTO(9:2) */
                _.MoveAtPosition(29, WHOST_DTVENCTO, 9, 2);

                /*" -1745- ELSE */
            }
            else
            {


                /*" -1745- MOVE 28 TO WHOST-DTVENCTO(9:2). */
                _.MoveAtPosition(28, WHOST_DTVENCTO, 9, 2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-DECLARE-VGRAMOCOMP-SECTION */
        private void R0600_00_DECLARE_VGRAMOCOMP_SECTION()
        {
            /*" -1758- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -1760- MOVE 'NAO' TO WFIM-VGRAMOCOMP. */
            _.Move("NAO", WS_WORK_AREAS.WFIM_VGRAMOCOMP);

            /*" -1765- IF V0PROP-NUM-APOLICE EQUAL 0109300000559 OR 0109300000709 OR 0109300001311 OR 0109300001392 OR 0109300001393 */

            if (V0PROP_NUM_APOLICE.In("0109300000559", "0109300000709", "0109300001311", "0109300001392", "0109300001393"))
            {

                /*" -1767- MOVE V0PROP-OPCAO-COBER TO WHOST-OPCAO-COBER */
                _.Move(V0PROP_OPCAO_COBER, WHOST_OPCAO_COBER);

                /*" -1768- ELSE */
            }
            else
            {


                /*" -1772- MOVE ' ' TO WHOST-OPCAO-COBER. */
                _.Move(" ", WHOST_OPCAO_COBER);
            }


            /*" -1774- MOVE V0PROP-CODSUBES TO WHOST-CODSUBES */
            _.Move(V0PROP_CODSUBES, WHOST_CODSUBES);

            /*" -1775- IF V0PROP-ORIG-PRODU EQUAL 'GLOBAL' */

            if (V0PROP_ORIG_PRODU == "GLOBAL")
            {

                /*" -1778- MOVE ZEROS TO WHOST-CODSUBES. */
                _.Move(0, WHOST_CODSUBES);
            }


            /*" -1818- PERFORM R0600_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1 */

            R0600_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();

            /*" -1820- PERFORM R0600_00_DECLARE_VGRAMOCOMP_DB_OPEN_1 */

            R0600_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();

            /*" -1823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1824- DISPLAY 'R0600-00 - PROBLEMAS DECLARE CVGRAMOCOMP)' */
                _.Display($"R0600-00 - PROBLEMAS DECLARE CVGRAMOCOMP)");

                /*" -1824- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0600-00-DECLARE-VGRAMOCOMP-DB-OPEN-1 */
        public void R0600_00_DECLARE_VGRAMOCOMP_DB_OPEN_1()
        {
            /*" -1820- EXEC SQL OPEN CVGRAMOCOMP END-EXEC. */

            CVGRAMOCOMP.Open();

        }

        [StopWatch]
        /*" R1040-REPASSA-ATRASO-DB-DECLARE-1 */
        public void R1040_REPASSA_ATRASO_DB_DECLARE_1()
        {
            /*" -2991- EXEC SQL DECLARE CDIFP CURSOR FOR SELECT NRPARCELDIF ,DTVENCTO FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND CODOPER IN (121, 122, 123) ORDER BY 1 END-EXEC. */
            CDIFP = new VG0816B_CDIFP(true);
            string GetQuery_CDIFP()
            {
                var query = @$"SELECT NRPARCELDIF 
							,DTVENCTO 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0HCOB_NRCERTIF}' 
							AND NRPARCEL = '{V0HCOB_NRPARCEL}' 
							AND CODOPER IN (121
							, 122
							, 123) 
							ORDER BY 1";

                return query;
            }
            CDIFP.GetQueryEvent += GetQuery_CDIFP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-FETCH-VGRAMOCOMP-SECTION */
        private void R0610_00_FETCH_VGRAMOCOMP_SECTION()
        {
            /*" -1837- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", WABEND.WNR_EXEC_SQL);

            /*" -1851- PERFORM R0610_00_FETCH_VGRAMOCOMP_DB_FETCH_1 */

            R0610_00_FETCH_VGRAMOCOMP_DB_FETCH_1();

            /*" -1854- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1855- MOVE 'SIM' TO WFIM-VGRAMOCOMP */
                _.Move("SIM", WS_WORK_AREAS.WFIM_VGRAMOCOMP);

                /*" -1855- PERFORM R0610_00_FETCH_VGRAMOCOMP_DB_CLOSE_1 */

                R0610_00_FETCH_VGRAMOCOMP_DB_CLOSE_1();

                /*" -1857- ELSE */
            }
            else
            {


                /*" -1858- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1859- DISPLAY 'R0610-00 - PROBLEMAS FETCH   CVGRAMOCOMP)' */
                    _.Display($"R0610-00 - PROBLEMAS FETCH   CVGRAMOCOMP)");

                    /*" -1859- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0610-00-FETCH-VGRAMOCOMP-DB-FETCH-1 */
        public void R0610_00_FETCH_VGRAMOCOMP_DB_FETCH_1()
        {
            /*" -1851- EXEC SQL FETCH CVGRAMOCOMP INTO :VG081-NUM-APOLICE ,:VG081-COD-SUBGRUPO ,:VG081-COD-GRUPO-SUSEP ,:VG081-RAMO-EMISSOR ,:VG081-COD-MODALIDADE ,:VG081-DTH-INI-VIGENCIA ,:VG081-COD-OPCAO-COBERTURA ,:VG081-NUM-IDADE-INICIAL ,:VG081-NUM-IDADE-FINAL ,:VG081-VLR-PERC-PREMIO ,:VG081-COD-USUARIO ,:VG081-DTH-ATUALIZACAO END-EXEC. */

            if (CVGRAMOCOMP.Fetch())
            {
                _.Move(CVGRAMOCOMP.VG081_NUM_APOLICE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_APOLICE);
                _.Move(CVGRAMOCOMP.VG081_COD_SUBGRUPO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_SUBGRUPO);
                _.Move(CVGRAMOCOMP.VG081_COD_GRUPO_SUSEP, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP);
                _.Move(CVGRAMOCOMP.VG081_RAMO_EMISSOR, VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR);
                _.Move(CVGRAMOCOMP.VG081_COD_MODALIDADE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE);
                _.Move(CVGRAMOCOMP.VG081_DTH_INI_VIGENCIA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_INI_VIGENCIA);
                _.Move(CVGRAMOCOMP.VG081_COD_OPCAO_COBERTURA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_OPCAO_COBERTURA);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_INICIAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_INICIAL);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_FINAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_FINAL);
                _.Move(CVGRAMOCOMP.VG081_VLR_PERC_PREMIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO);
                _.Move(CVGRAMOCOMP.VG081_COD_USUARIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_USUARIO);
                _.Move(CVGRAMOCOMP.VG081_DTH_ATUALIZACAO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" R0610-00-FETCH-VGRAMOCOMP-DB-CLOSE-1 */
        public void R0610_00_FETCH_VGRAMOCOMP_DB_CLOSE_1()
        {
            /*" -1855- EXEC SQL CLOSE CVGRAMOCOMP END-EXEC */

            CVGRAMOCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-VGRAMOCOMP-SECTION */
        private void R0700_00_PROCESSA_VGRAMOCOMP_SECTION()
        {
            /*" -1872- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -1874- MOVE VG081-COD-GRUPO-SUSEP TO WS-GRUPO-SUSEP-ANT. */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP, WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT);

            /*" -1876- MOVE VG081-RAMO-EMISSOR TO WS-RAMO-CONJ-ANT. */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR, WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT);

            /*" -1881- MOVE ZEROS TO WHOST-TAXA-RAMO WHOST-VLR-PERC-PREMIO. */
            _.Move(0, WHOST_TAXA_RAMO, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO);

            /*" -1882- IF V0PROP-ORIG-PRODU(1:4) EQUAL 'ESPE' */

            if (V0PROP_ORIG_PRODU.Substring(1, 4) == "ESPE")
            {

                /*" -1883- MOVE V0PROP-CODSUBES TO CONDITEC-COD-SUBGRUPO */
                _.Move(V0PROP_CODSUBES, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

                /*" -1884- PERFORM R0770-00-SELECT-CONDITEC */

                R0770_00_SELECT_CONDITEC_SECTION();

                /*" -1890- PERFORM R0750-00-PROCESSA-ESPECIFICA UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT */

                while (!(WS_WORK_AREAS.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
                {

                    R0750_00_PROCESSA_ESPECIFICA_SECTION();
                }

                /*" -1891- ELSE */
            }
            else
            {


                /*" -1892- IF V0PROP-ORIG-PRODU EQUAL 'GLOBAL' */

                if (V0PROP_ORIG_PRODU == "GLOBAL")
                {

                    /*" -1893- MOVE V0PROP-CODSUBES TO CONDITEC-COD-SUBGRUPO */
                    _.Move(V0PROP_CODSUBES, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

                    /*" -1894- PERFORM R0770-00-SELECT-CONDITEC */

                    R0770_00_SELECT_CONDITEC_SECTION();

                    /*" -1900- PERFORM R0780-00-PROCESSA-GLOBAL UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT */

                    while (!(WS_WORK_AREAS.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
                    {

                        R0780_00_PROCESSA_GLOBAL_SECTION();
                    }

                    /*" -1901- ELSE */
                }
                else
                {


                    /*" -1908- PERFORM R0710-00-PROCESSA-REGISTRO UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT. */

                    while (!(WS_WORK_AREAS.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
                    {

                        R0710_00_PROCESSA_REGISTRO_SECTION();
                    }
                }

            }


            /*" -1909- ADD 1 TO WS-IND */
            WORK_RAMO_CONJ.WS_IND.Value = WORK_RAMO_CONJ.WS_IND + 1;

            /*" -1911- MOVE WS-GRUPO-SUSEP-ANT TO TB-GRUPO-SUSEP(WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_GRUPO_SUSEP);

            /*" -1913- MOVE WS-RAMO-CONJ-ANT TO TB-RAMO-CONJ(WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ);

            /*" -1914- MOVE WHOST-VLR-PERC-PREMIO TO TB-TAXA-RAMO-CONJ(WS-IND). */
            _.Move(WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_TAXA_RAMO_CONJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-PROCESSA-REGISTRO-SECTION */
        private void R0710_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1927- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", WABEND.WNR_EXEC_SQL);

            /*" -1930- IF V0PROP-NUM-APOLICE EQUAL 0109300000550 OR 0109300000559 AND WS-RAMO-CONJ-ANT EQUAL 84 */

            if (V0PROP_NUM_APOLICE.In("0109300000550", "0109300000559") && WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 84)
            {

                /*" -1931- IF V0COBP-IMPMORNATU GREATER 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -1934- DIVIDE V0COBP-IMPSEGCDG BY V0COBP-IMPMORNATU GIVING WHOST-PERC-CDG */
                    _.Divide(V0COBP_IMPSEGCDG, V0COBP_IMPMORNATU, WHOST_PERC_CDG);

                    /*" -1935- ELSE */
                }
                else
                {


                    /*" -1936- IF V0COBP-IMPMORACID GREATER 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -1939- DIVIDE V0COBP-IMPSEGCDG BY V0COBP-IMPMORACID GIVING WHOST-PERC-CDG */
                        _.Divide(V0COBP_IMPSEGCDG, V0COBP_IMPMORACID, WHOST_PERC_CDG);

                        /*" -1940- ELSE */
                    }
                    else
                    {


                        /*" -1941- MOVE ZEROS TO WHOST-PERC-CDG */
                        _.Move(0, WHOST_PERC_CDG);

                        /*" -1942- END-IF */
                    }


                    /*" -1943- END-IF */
                }


                /*" -1945- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-CDG */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_CDG;

                /*" -1947- END-IF. */
            }


            /*" -1948- IF WS-RAMO-CONJ-ANT EQUAL 82 */

            if (WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 82)
            {

                /*" -1949- IF V0COBP-IMPMORNATU GREATER 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -1952- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORNATU GIVING WHOST-PERC-DIT */
                    _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORNATU, WHOST_PERC_DIT);

                    /*" -1953- ELSE */
                }
                else
                {


                    /*" -1954- IF V0COBP-IMPMORACID GREATER 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -1957- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORACID GIVING WHOST-PERC-DIT */
                        _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORACID, WHOST_PERC_DIT);

                        /*" -1958- ELSE */
                    }
                    else
                    {


                        /*" -1959- MOVE ZEROS TO WHOST-PERC-DIT */
                        _.Move(0, WHOST_PERC_DIT);

                        /*" -1960- END-IF */
                    }


                    /*" -1961- END-IF */
                }


                /*" -1963- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-DIT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_DIT;

                /*" -1965- END-IF */
            }


            /*" -1969- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -1969- PERFORM R0610-00-FETCH-VGRAMOCOMP. */

            R0610_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0750-00-PROCESSA-ESPECIFICA-SECTION */
        private void R0750_00_PROCESSA_ESPECIFICA_SECTION()
        {
            /*" -1985- MOVE '0750' TO WNR-EXEC-SQL. */
            _.Move("0750", WABEND.WNR_EXEC_SQL);

            /*" -1987- IF VG081-RAMO-EMISSOR = 29 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 29 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -1988- MOVE 03 TO VGCOBSUB-COD-COBERTURA */
                _.Move(03, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -1989- PERFORM R0760-00-LEITURA-VGCOBSUB */

                R0760_00_LEITURA_VGCOBSUB_SECTION();

                /*" -1992- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -1993- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -1996- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -1997- ELSE */
                }
                else
                {


                    /*" -1998- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2001- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2002- ELSE */
                    }
                    else
                    {


                        /*" -2003- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2004- END-IF */
                    }


                    /*" -2005- END-IF */
                }


                /*" -2007- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2009- END-IF. */
            }


            /*" -2011- IF VG081-RAMO-EMISSOR = 90 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -2012- MOVE 05 TO VGCOBSUB-COD-COBERTURA */
                _.Move(05, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -2013- PERFORM R0760-00-LEITURA-VGCOBSUB */

                R0760_00_LEITURA_VGCOBSUB_SECTION();

                /*" -2016- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -2017- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2020- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2021- ELSE */
                }
                else
                {


                    /*" -2022- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2025- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2026- ELSE */
                    }
                    else
                    {


                        /*" -2027- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2028- END-IF */
                    }


                    /*" -2029- END-IF */
                }


                /*" -2031- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2035- END-IF. */
            }


            /*" -2037- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1009 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1009)
            {

                /*" -2038- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2041- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2042- ELSE */
                }
                else
                {


                    /*" -2043- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2046- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2047- ELSE */
                    }
                    else
                    {


                        /*" -2048- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2049- END-IF */
                    }


                    /*" -2050- END-IF */
                }


                /*" -2052- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2054- END-IF. */
            }


            /*" -2056- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -2057- MOVE 06 TO VGCOBSUB-COD-COBERTURA */
                _.Move(06, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -2058- PERFORM R0760-00-LEITURA-VGCOBSUB */

                R0760_00_LEITURA_VGCOBSUB_SECTION();

                /*" -2061- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -2062- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2065- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2066- ELSE */
                }
                else
                {


                    /*" -2067- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2070- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2071- ELSE */
                    }
                    else
                    {


                        /*" -2072- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2073- END-IF */
                    }


                    /*" -2074- END-IF */
                }


                /*" -2076- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2078- END-IF. */
            }


            /*" -2080- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -2081- MOVE 22 TO VGCOBSUB-COD-COBERTURA */
                _.Move(22, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -2083- PERFORM R0760-00-LEITURA-VGCOBSUB */

                R0760_00_LEITURA_VGCOBSUB_SECTION();

                /*" -2085- IF V0COBP-IMPMORNATU > 0 AND V0COBP-QUANT-VIDAS > 0 */

                if (V0COBP_IMPMORNATU > 0 && V0COBP_QUANT_VIDAS > 0)
                {

                    /*" -2088- COMPUTE WS-IMP-SEGURADA = V0COBP-IMPMORNATU / V0COBP-QUANT-VIDAS * 0,30 */
                    WS_WORK_AREAS.WS_IMP_SEGURADA.Value = V0COBP_IMPMORNATU / V0COBP_QUANT_VIDAS * 0.30;

                    /*" -2090- IF VGCOBSUB-IMP-SEGURADA-IX > WS-IMP-SEGURADA */

                    if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX > WS_WORK_AREAS.WS_IMP_SEGURADA)
                    {

                        /*" -2092- MOVE WS-IMP-SEGURADA TO VGCOBSUB-IMP-SEGURADA-IX */
                        _.Move(WS_WORK_AREAS.WS_IMP_SEGURADA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);

                        /*" -2094- END-IF */
                    }


                    /*" -2098- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                    VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                    /*" -2101- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2102- ELSE */
                }
                else
                {


                    /*" -2104- IF V0COBP-IMPMORACID > 0 AND V0COBP-QUANT-VIDAS > 0 */

                    if (V0COBP_IMPMORACID > 0 && V0COBP_QUANT_VIDAS > 0)
                    {

                        /*" -2107- COMPUTE WS-IMP-SEGURADA = V0COBP-IMPMORACID / V0COBP-QUANT-VIDAS * 0,30 */
                        WS_WORK_AREAS.WS_IMP_SEGURADA.Value = V0COBP_IMPMORACID / V0COBP_QUANT_VIDAS * 0.30;

                        /*" -2109- IF VGCOBSUB-IMP-SEGURADA-IX > WS-IMP-SEGURADA */

                        if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX > WS_WORK_AREAS.WS_IMP_SEGURADA)
                        {

                            /*" -2111- MOVE WS-IMP-SEGURADA TO VGCOBSUB-IMP-SEGURADA-IX */
                            _.Move(WS_WORK_AREAS.WS_IMP_SEGURADA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);

                            /*" -2113- END-IF */
                        }


                        /*" -2116- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                        VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                        /*" -2119- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2120- ELSE */
                    }
                    else
                    {


                        /*" -2121- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2122- END-IF */
                    }


                    /*" -2123- END-IF */
                }


                /*" -2125- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2127- END-IF. */
            }


            /*" -2129- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1003 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1003)
            {

                /*" -2130- MOVE 11 TO VGCOBSUB-COD-COBERTURA */
                _.Move(11, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -2131- PERFORM R0760-00-LEITURA-VGCOBSUB */

                R0760_00_LEITURA_VGCOBSUB_SECTION();

                /*" -2134- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -2135- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2138- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2139- ELSE */
                }
                else
                {


                    /*" -2140- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2143- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2144- ELSE */
                    }
                    else
                    {


                        /*" -2145- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2146- END-IF */
                    }


                    /*" -2147- END-IF */
                }


                /*" -2149- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2151- END-IF. */
            }


            /*" -2153- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -2154- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2157- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -2160- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2161- ELSE */
                }
                else
                {


                    /*" -2162- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2165- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -2168- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2169- ELSE */
                    }
                    else
                    {


                        /*" -2170- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2171- END-IF */
                    }


                    /*" -2172- END-IF */
                }


                /*" -2174- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2176- END-IF. */
            }


            /*" -2178- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1003 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1003)
            {

                /*" -2179- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2182- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -2185- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2186- ELSE */
                }
                else
                {


                    /*" -2187- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2190- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -2193- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2194- ELSE */
                    }
                    else
                    {


                        /*" -2195- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2196- END-IF */
                    }


                    /*" -2197- END-IF */
                }


                /*" -2199- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2201- END-IF. */
            }


            /*" -2203- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1004 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1004)
            {

                /*" -2204- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2207- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-FILHOS / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS / 100f;

                    /*" -2210- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2211- ELSE */
                }
                else
                {


                    /*" -2212- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2215- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-FILHOS / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS / 100f;

                        /*" -2218- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2219- ELSE */
                    }
                    else
                    {


                        /*" -2220- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2221- END-IF */
                    }


                    /*" -2222- END-IF */
                }


                /*" -2224- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2226- END-IF. */
            }


            /*" -2228- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1005 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1005)
            {

                /*" -2229- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2232- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -2235- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2236- ELSE */
                }
                else
                {


                    /*" -2237- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2240- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -2243- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2244- ELSE */
                    }
                    else
                    {


                        /*" -2245- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2246- END-IF */
                    }


                    /*" -2247- END-IF */
                }


                /*" -2249- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2253- END-IF. */
            }


            /*" -2255- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -2256- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2259- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2260- ELSE */
                }
                else
                {


                    /*" -2261- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2264- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2265- ELSE */
                    }
                    else
                    {


                        /*" -2266- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2267- END-IF */
                    }


                    /*" -2268- END-IF */
                }


                /*" -2270- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2272- END-IF. */
            }


            /*" -2274- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1003 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1003)
            {

                /*" -2275- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2278- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-GARAN-ADIC-IEA / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA / 100f;

                    /*" -2281- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2282- ELSE */
                }
                else
                {


                    /*" -2283- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2286- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-GARAN-ADIC-IEA / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA / 100f;

                        /*" -2289- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2290- ELSE */
                    }
                    else
                    {


                        /*" -2291- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2292- END-IF */
                    }


                    /*" -2293- END-IF */
                }


                /*" -2295- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2297- END-IF. */
            }


            /*" -2299- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1004 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1004)
            {

                /*" -2300- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2303- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2304- ELSE */
                }
                else
                {


                    /*" -2305- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2308- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2309- ELSE */
                    }
                    else
                    {


                        /*" -2310- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2311- END-IF */
                    }


                    /*" -2312- END-IF */
                }


                /*" -2314- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2316- END-IF. */
            }


            /*" -2318- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1005 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1005)
            {

                /*" -2319- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2322- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -2325- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2326- ELSE */
                }
                else
                {


                    /*" -2327- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2330- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -2333- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2334- ELSE */
                    }
                    else
                    {


                        /*" -2335- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2336- END-IF */
                    }


                    /*" -2337- END-IF */
                }


                /*" -2339- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2341- END-IF. */
            }


            /*" -2343- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1006 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1006)
            {

                /*" -2344- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2347- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -2350- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2351- ELSE */
                }
                else
                {


                    /*" -2352- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2355- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -2358- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2359- ELSE */
                    }
                    else
                    {


                        /*" -2360- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2361- END-IF */
                    }


                    /*" -2362- END-IF */
                }


                /*" -2364- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2366- END-IF. */
            }


            /*" -2368- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1007 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1007)
            {

                /*" -2369- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2372- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -2375- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2376- ELSE */
                }
                else
                {


                    /*" -2377- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2380- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -2383- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2384- ELSE */
                    }
                    else
                    {


                        /*" -2385- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2386- END-IF */
                    }


                    /*" -2387- END-IF */
                }


                /*" -2389- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2391- END-IF. */
            }


            /*" -2393- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1008 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1008)
            {

                /*" -2394- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2397- DIVIDE V0COBP-IMPDH BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPDH, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2398- ELSE */
                }
                else
                {


                    /*" -2399- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2402- DIVIDE V0COBP-IMPDH BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPDH, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2403- ELSE */
                    }
                    else
                    {


                        /*" -2404- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2405- END-IF */
                    }


                    /*" -2406- END-IF */
                }


                /*" -2408- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2410- END-IF. */
            }


            /*" -2412- IF VG081-RAMO-EMISSOR = 90 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -2413- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2416- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-TAXA-AP-DH / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                    /*" -2419- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2420- ELSE */
                }
                else
                {


                    /*" -2421- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2424- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-TAXA-AP-DH / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                        /*" -2427- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2428- ELSE */
                    }
                    else
                    {


                        /*" -2429- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2430- END-IF */
                    }


                    /*" -2431- END-IF */
                }


                /*" -2433- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2437- END-IF. */
            }


            /*" -2442- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -2442- PERFORM R0610-00-FETCH-VGRAMOCOMP. */

            R0610_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_99_SAIDA*/

        [StopWatch]
        /*" R0760-00-LEITURA-VGCOBSUB-SECTION */
        private void R0760_00_LEITURA_VGCOBSUB_SECTION()
        {
            /*" -2456- MOVE '0760' TO WNR-EXEC-SQL. */
            _.Move("0760", WABEND.WNR_EXEC_SQL);

            /*" -2463- PERFORM R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1 */

            R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1();

            /*" -2466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2467- DISPLAY 'R0760-00 - PROBLEMAS NO SELECT VGCOBSUB ' */
                _.Display($"R0760-00 - PROBLEMAS NO SELECT VGCOBSUB ");

                /*" -2467- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0760-00-LEITURA-VGCOBSUB-DB-SELECT-1 */
        public void R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1()
        {
            /*" -2463- EXEC SQL SELECT IMP_SEGURADA_IX INTO :VGCOBSUB-IMP-SEGURADA-IX FROM SEGUROS.VG_COBERTURAS_SUBG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES AND COD_COBERTURA = :VGCOBSUB-COD-COBERTURA END-EXEC. */

            var r0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 = new R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1()
            {
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1.Execute(r0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOBSUB_IMP_SEGURADA_IX, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0760_99_SAIDA*/

        [StopWatch]
        /*" R0770-00-SELECT-CONDITEC-SECTION */
        private void R0770_00_SELECT_CONDITEC_SECTION()
        {
            /*" -2481- MOVE '0770' TO WNR-EXEC-SQL. */
            _.Move("0770", WABEND.WNR_EXEC_SQL);

            /*" -2509- PERFORM R0770_00_SELECT_CONDITEC_DB_SELECT_1 */

            R0770_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -2512- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2513- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2515- IF CONDITEC-COD-SUBGRUPO EQUAL 0 AND V0PROP-ORIG-PRODU(1:4) EQUAL 'ESPE' */

                    if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO == 0 && V0PROP_ORIG_PRODU.Substring(1, 4) == "ESPE")
                    {

                        /*" -2516- MOVE 1 TO CONDITEC-COD-SUBGRUPO */
                        _.Move(1, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

                        /*" -2517- GO TO R0770-00-SELECT-CONDITEC */
                        new Task(() => R0770_00_SELECT_CONDITEC_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -2518- ELSE */
                    }
                    else
                    {


                        /*" -2530- MOVE ZEROS TO CONDITEC-TAXA-AP-MORACID CONDITEC-TAXA-AP-INVPERM CONDITEC-TAXA-AP-AMDS CONDITEC-TAXA-AP-DH CONDITEC-TAXA-AP-DIT CONDITEC-TAXA-AP CONDITEC-CARREGA-PRINCIPAL CONDITEC-CARREGA-CONJUGE CONDITEC-CARREGA-FILHOS CONDITEC-GARAN-ADIC-IEA CONDITEC-GARAN-ADIC-IPA CONDITEC-GARAN-ADIC-IPD */
                        _.Move(0, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);

                        /*" -2531- END-IF */
                    }


                    /*" -2532- ELSE */
                }
                else
                {


                    /*" -2533- DISPLAY 'R0770-00 - PROBLEMAS NO SELECT CONDITEC ' */
                    _.Display($"R0770-00 - PROBLEMAS NO SELECT CONDITEC ");

                    /*" -2534- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2535- END-IF */
                }


                /*" -2535- END-IF. */
            }


        }

        [StopWatch]
        /*" R0770-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R0770_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -2509- EXEC SQL SELECT TAXA_AP_MORACID ,TAXA_AP_INVPERM ,TAXA_AP_AMDS ,TAXA_AP_DH ,TAXA_AP_DIT ,TAXA_AP ,CARREGA_PRINCIPAL ,CARREGA_CONJUGE ,CARREGA_FILHOS ,GARAN_ADIC_IEA ,GARAN_ADIC_IPA ,GARAN_ADIC_IPD INTO :CONDITEC-TAXA-AP-MORACID ,:CONDITEC-TAXA-AP-INVPERM ,:CONDITEC-TAXA-AP-AMDS ,:CONDITEC-TAXA-AP-DH ,:CONDITEC-TAXA-AP-DIT ,:CONDITEC-TAXA-AP ,:CONDITEC-CARREGA-PRINCIPAL ,:CONDITEC-CARREGA-CONJUGE ,:CONDITEC-CARREGA-FILHOS ,:CONDITEC-GARAN-ADIC-IEA ,:CONDITEC-GARAN-ADIC-IPA ,:CONDITEC-GARAN-ADIC-IPD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :CONDITEC-COD-SUBGRUPO END-EXEC. */

            var r0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                CONDITEC_COD_SUBGRUPO = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID);
                _.Move(executed_1.CONDITEC_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM);
                _.Move(executed_1.CONDITEC_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS);
                _.Move(executed_1.CONDITEC_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH);
                _.Move(executed_1.CONDITEC_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT);
                _.Move(executed_1.CONDITEC_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP);
                _.Move(executed_1.CONDITEC_CARREGA_PRINCIPAL, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL);
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0770_99_SAIDA*/

        [StopWatch]
        /*" R0780-00-PROCESSA-GLOBAL-SECTION */
        private void R0780_00_PROCESSA_GLOBAL_SECTION()
        {
            /*" -2550- MOVE '0780' TO WNR-EXEC-SQL. */
            _.Move("0780", WABEND.WNR_EXEC_SQL);

            /*" -2552- MOVE ZEROS TO WHOST-PERCENT. */
            _.Move(0, WHOST_PERCENT);

            /*" -2554- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -2555- IF CONDITEC-TAXA-AP-DH > 0 */

                if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH > 0)
                {

                    /*" -2556- IF V0COBP-IMPMORNATU > 0 */

                    if (V0COBP_IMPMORNATU > 0)
                    {

                        /*" -2559- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-TAXA-AP-DH / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                        /*" -2562- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                        /*" -2563- ELSE */
                    }
                    else
                    {


                        /*" -2564- IF V0COBP-IMPMORACID > 0 */

                        if (V0COBP_IMPMORACID > 0)
                        {

                            /*" -2567- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-TAXA-AP-DH / 100 */
                            WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                            /*" -2570- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                            _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                            /*" -2571- ELSE */
                        }
                        else
                        {


                            /*" -2572- MOVE ZEROS TO WHOST-PERCENT */
                            _.Move(0, WHOST_PERCENT);

                            /*" -2573- END-IF */
                        }


                        /*" -2574- END-IF */
                    }


                    /*" -2575- END-IF */
                }


                /*" -2577- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2579- END-IF. */
            }


            /*" -2581- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -2582- IF V0PROP-TEM-CDG = 'S' */

                if (V0PROP_TEM_CDG == "S")
                {

                    /*" -2583- IF V0COBP-IMPMORNATU > 0 */

                    if (V0COBP_IMPMORNATU > 0)
                    {

                        /*" -2585- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * 0,30 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * 0.30;

                        /*" -2588- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                        /*" -2589- ELSE */
                    }
                    else
                    {


                        /*" -2590- IF V0COBP-IMPMORACID > 0 */

                        if (V0COBP_IMPMORACID > 0)
                        {

                            /*" -2592- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * 0,30 */
                            WHOST_IMPSEG.Value = V0COBP_IMPMORACID * 0.30;

                            /*" -2595- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                            _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                            /*" -2596- ELSE */
                        }
                        else
                        {


                            /*" -2597- MOVE ZEROS TO WHOST-PERCENT */
                            _.Move(0, WHOST_PERCENT);

                            /*" -2598- END-IF */
                        }


                        /*" -2599- END-IF */
                    }


                    /*" -2600- END-IF */
                }


                /*" -2602- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2604- END-IF. */
            }


            /*" -2606- IF VG081-RAMO-EMISSOR = 90 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -2607- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -2609- COMPUTE WHOST-IMPSEG = 1000 * V0COBP-QUANT-VIDAS */
                    WHOST_IMPSEG.Value = 1000 * V0COBP_QUANT_VIDAS;

                    /*" -2612- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -2613- ELSE */
                }
                else
                {


                    /*" -2614- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -2616- COMPUTE WHOST-IMPSEG = 1000 * V0COBP-QUANT-VIDAS */
                        WHOST_IMPSEG.Value = 1000 * V0COBP_QUANT_VIDAS;

                        /*" -2619- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -2620- ELSE */
                    }
                    else
                    {


                        /*" -2621- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -2622- END-IF */
                    }


                    /*" -2623- END-IF */
                }


                /*" -2625- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -2627- END-IF. */
            }


            /*" -2632- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -2632- PERFORM R0610-00-FETCH-VGRAMOCOMP. */

            R0610_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0780_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-INSERT-VGHISTCONT-SECTION */
        private void R0800_00_INSERT_VGHISTCONT_SECTION()
        {
            /*" -2646- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -2647- IF WHOST-VLR-PERC-PREMIO-TOT NOT GREATER ZEROS */

            if (WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT <= 00)
            {

                /*" -2648- MOVE 'SIM' TO WFIM-TAB-RAMO */
                _.Move("SIM", WS_WORK_AREAS.WFIM_TAB_RAMO);

                /*" -2651- GO TO R0800-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2653- ADD 1 TO WS-IND1. */
            WORK_RAMO_CONJ.WS_IND1.Value = WORK_RAMO_CONJ.WS_IND1 + 1;

            /*" -2655- IF WS-IND1 GREATER 30 OR TB-GRUPO-SUSEP (WS-IND1) EQUAL ZEROS */

            if (WORK_RAMO_CONJ.WS_IND1 > 30 || WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP == 00)
            {

                /*" -2656- MOVE 'SIM' TO WFIM-TAB-RAMO */
                _.Move("SIM", WS_WORK_AREAS.WFIM_TAB_RAMO);

                /*" -2657- ELSE */
            }
            else
            {


                /*" -2658- INITIALIZE DCLVG-HIST-CONT-COBER */
                _.Initialize(
                    VG082.DCLVG_HIST_CONT_COBER
                );

                /*" -2659- MOVE TB-GRUPO-SUSEP (WS-IND1) TO WHOST-GRUPO-SUSEP */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP, WHOST_GRUPO_SUSEP);

                /*" -2660- MOVE TB-RAMO-CONJ (WS-IND1) TO WHOST-COD-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ, WHOST_COD_RAMO);

                /*" -2661- MOVE TB-TAXA-RAMO-CONJ (WS-IND1) TO WHOST-TAXA-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_TAXA_RAMO_CONJ, WHOST_TAXA_RAMO);

                /*" -2666- COMPUTE WHOST-PREMIO-CONJ ROUNDED = WS-PREMIO-TOTAL * WHOST-TAXA-RAMO / WHOST-VLR-PERC-PREMIO-TOT */
                WHOST_PREMIO_CONJ.Value = WS_WORK_AREAS.WS_PREMIO_TOTAL * WHOST_TAXA_RAMO / WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT;

                /*" -2667- IF WS-IND1 EQUAL WS-IND */

                if (WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND)
                {

                    /*" -2669- COMPUTE WHOST-PREMIO-CONJ = WS-PREMIO-TOTAL - WS-PREMIO-TOTAL-AC */
                    WHOST_PREMIO_CONJ.Value = WS_WORK_AREAS.WS_PREMIO_TOTAL - WS_WORK_AREAS.WS_PREMIO_TOTAL_AC;

                    /*" -2670- ELSE */
                }
                else
                {


                    /*" -2671- ADD WHOST-PREMIO-CONJ TO WS-PREMIO-TOTAL-AC */
                    WS_WORK_AREAS.WS_PREMIO_TOTAL_AC.Value = WS_WORK_AREAS.WS_PREMIO_TOTAL_AC + WHOST_PREMIO_CONJ;

                    /*" -2673- END-IF */
                }


                /*" -2674- IF WHOST-PREMIO-CONJ > 0 */

                if (WHOST_PREMIO_CONJ > 0)
                {

                    /*" -2699- PERFORM R0800_00_INSERT_VGHISTCONT_DB_INSERT_1 */

                    R0800_00_INSERT_VGHISTCONT_DB_INSERT_1();

                    /*" -2702- IF SQLCODE EQUAL -803 */

                    if (DB.SQLCODE == -803)
                    {

                        /*" -2703- DISPLAY 'R0800-00 - REGISTRO DUPLICADO            ' */
                        _.Display($"R0800-00 - REGISTRO DUPLICADO            ");

                        /*" -2704- DISPLAY ' V0HCOB-NRCERTIF    ' V0HCOB-NRCERTIF */
                        _.Display($" V0HCOB-NRCERTIF    {V0HCOB_NRCERTIF}");

                        /*" -2705- DISPLAY ' V0HCOB-NRPARCEL    ' V0HCOB-NRPARCEL */
                        _.Display($" V0HCOB-NRPARCEL    {V0HCOB_NRPARCEL}");

                        /*" -2706- DISPLAY ' V0MOVC-NRTIT       ' V0MOVC-NRTIT */
                        _.Display($" V0MOVC-NRTIT       {V0MOVC_NRTIT}");

                        /*" -2707- DISPLAY ' V0HCOB-OCORHIST    ' V0HCOB-OCORHIST */
                        _.Display($" V0HCOB-OCORHIST    {V0HCOB_OCORHIST}");

                        /*" -2708- DISPLAY ' V0PROP-NUM-APOLICE ' V0PROP-NUM-APOLICE */
                        _.Display($" V0PROP-NUM-APOLICE {V0PROP_NUM_APOLICE}");

                        /*" -2709- DISPLAY ' V0PROP-CODSUBES    ' V0PROP-CODSUBES */
                        _.Display($" V0PROP-CODSUBES    {V0PROP_CODSUBES}");

                        /*" -2710- DISPLAY ' V0PROP-FONTE       ' V0PROP-FONTE */
                        _.Display($" V0PROP-FONTE       {V0PROP_FONTE}");

                        /*" -2711- DISPLAY ' V0HCTB-CODOPER     ' V0HCTB-CODOPER */
                        _.Display($" V0HCTB-CODOPER     {V0HCTB_CODOPER}");

                        /*" -2712- ELSE */
                    }
                    else
                    {


                        /*" -2713- IF SQLCODE NOT EQUAL ZEROS */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -2714- DISPLAY 'R0800-00 - PROBLEMAS INSERT VG_HIST_CONT_COBER)' */
                            _.Display($"R0800-00 - PROBLEMAS INSERT VG_HIST_CONT_COBER)");

                            /*" -2714- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R0800-00-INSERT-VGHISTCONT-DB-INSERT-1 */
        public void R0800_00_INSERT_VGHISTCONT_DB_INSERT_1()
        {
            /*" -2699- EXEC SQL INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO ,NUM_PARCELA ,NUM_TITULO ,OCORR_HISTORICO ,COD_GRUPO_SUSEP ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_COBERTURA ,VLR_PREMIO_RAMO ,COD_USUARIO ,DTH_ATUALIZACAO ) VALUES (:V0HCOB-NRCERTIF ,:V0HCOB-NRPARCEL ,:V0HCOB-NRTIT ,:V0HCOB-OCORHIST ,:WHOST-GRUPO-SUSEP ,:WHOST-COD-RAMO ,:VG082-COD-MODALIDADE ,:VG082-COD-COBERTURA ,:WHOST-PREMIO-CONJ , 'VG0816B' , CURRENT TIMESTAMP ) END-EXEC */

            var r0800_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 = new R0800_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                WHOST_GRUPO_SUSEP = WHOST_GRUPO_SUSEP.ToString(),
                WHOST_COD_RAMO = WHOST_COD_RAMO.ToString(),
                VG082_COD_MODALIDADE = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE.ToString(),
                VG082_COD_COBERTURA = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA.ToString(),
                WHOST_PREMIO_CONJ = WHOST_PREMIO_CONJ.ToString(),
            };

            R0800_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1.Execute(r0800_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -2728- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -2734- PERFORM R1000_00_PROCESSA_DB_SELECT_1 */

            R1000_00_PROCESSA_DB_SELECT_1();

            /*" -2737- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2738- IF V0PROP-TEM-CDG EQUAL 'S' */

                if (V0PROP_TEM_CDG == "S")
                {

                    /*" -2739- PERFORM R1040-00-REPASSA-CDG */

                    R1040_00_REPASSA_CDG_SECTION();

                    /*" -2741- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2742- ELSE */
                }

            }
            else
            {


                /*" -2746- IF SQLCODE EQUAL 100 AND V0PROP-TEM-CDG EQUAL 'S' AND V0COBP-VLCUSTCDG GREATER ZEROS AND V0PROP-SITUACAO EQUAL '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PROP_TEM_CDG == "S" && V0COBP_VLCUSTCDG > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -2749- PERFORM R1020-00-INCLUI-CDG. */

                    R1020_00_INCLUI_CDG_SECTION();
                }

            }


            /*" -2755- PERFORM R1000_00_PROCESSA_DB_SELECT_2 */

            R1000_00_PROCESSA_DB_SELECT_2();

            /*" -2758- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2759- IF V0PROP-TEM-SAF EQUAL 'S' */

                if (V0PROP_TEM_SAF == "S")
                {

                    /*" -2760- PERFORM R1140-00-REPASSA-SAF */

                    R1140_00_REPASSA_SAF_SECTION();

                    /*" -2762- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2763- ELSE */
                }

            }
            else
            {


                /*" -2767- IF SQLCODE EQUAL 100 AND V0PROP-TEM-SAF EQUAL 'S' AND V0COBP-VLCUSTAUXF GREATER ZEROS AND V0PROP-SITUACAO EQUAL '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PROP_TEM_SAF == "S" && V0COBP_VLCUSTAUXF > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -2770- PERFORM R1120-00-INCLUI-SAF. */

                    R1120_00_INCLUI_SAF_SECTION();
                }

            }


            /*" -2773- MOVE '0' TO WHOST-SITUACAO */
            _.Move("0", WHOST_SITUACAO);

            /*" -2779- PERFORM R1000_00_PROCESSA_DB_UPDATE_1 */

            R1000_00_PROCESSA_DB_UPDATE_1();

            /*" -2782- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2783- DISPLAY 'R1000-00 - PROBLEMAS NO UPDATE(PARCELVA)' */
                _.Display($"R1000-00 - PROBLEMAS NO UPDATE(PARCELVA)");

                /*" -2786- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2788- MOVE '1' TO WHOST-SITUACAO */
            _.Move("1", WHOST_SITUACAO);

            /*" -2798- PERFORM R1000_00_PROCESSA_DB_UPDATE_2 */

            R1000_00_PROCESSA_DB_UPDATE_2();

            /*" -2801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2802- DISPLAY 'R1000-00 - PROBLEMAS NO UPDATE(HISTCOBVA)' */
                _.Display($"R1000-00 - PROBLEMAS NO UPDATE(HISTCOBVA)");

                /*" -2804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2805- IF V0HCOB-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (V0HCOB_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -2811- PERFORM R1000_00_PROCESSA_DB_UPDATE_3 */

                R1000_00_PROCESSA_DB_UPDATE_3();

                /*" -2814- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -2815- DISPLAY 'R1000-00 - PROBLEMAS NO UPDATE(HISTCONTA)' */
                    _.Display($"R1000-00 - PROBLEMAS NO UPDATE(HISTCONTA)");

                    /*" -2818- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2819- IF WS-DIFERENCA NOT EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_DIFERENCA != 00)
            {

                /*" -2821- PERFORM R1210-00-GRAVA-DIFERENCA. */

                R1210_00_GRAVA_DIFERENCA_SECTION();
            }


            /*" -2822- IF V0PROP-ESTR-COBR EQUAL 'MULT' */

            if (V0PROP_ESTR_COBR == "MULT")
            {

                /*" -2823- PERFORM R1230-00-BAIXA-DO-MULTI */

                R1230_00_BAIXA_DO_MULTI_SECTION();

                /*" -2824- ELSE */
            }
            else
            {


                /*" -2825- IF V0PROP-ESTR-COBR EQUAL 'FEDERAL' */

                if (V0PROP_ESTR_COBR == "FEDERAL")
                {

                    /*" -2826- PERFORM R1250-00-BAIXA-DO-FEDERAL */

                    R1250_00_BAIXA_DO_FEDERAL_SECTION();

                    /*" -2827- ELSE */
                }
                else
                {


                    /*" -2830- DISPLAY 'R1000-00 - RORINA COBRANCA NAO ESPERADA' ' NRCERTIF    ' V0HCOB-NRCERTIF ' ESTR-COBR   ' V0PROP-ESTR-COBR */

                    $"R1000-00 - RORINA COBRANCA NAO ESPERADA NRCERTIF    {V0HCOB_NRCERTIF} ESTR-COBR   {V0PROP_ESTR_COBR}"
                    .Display();

                    /*" -2833- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2834- MOVE '1' TO V0MOVC-SITUACAO. */
            _.Move("1", V0MOVC_SITUACAO);

            /*" -2837- PERFORM R0320-00-UPDATE-V0MOVIMCOB. */

            R0320_00_UPDATE_V0MOVIMCOB_SECTION();

            /*" -2845- PERFORM R1000_00_PROCESSA_DB_UPDATE_4 */

            R1000_00_PROCESSA_DB_UPDATE_4();

            /*" -2849- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2850- DISPLAY 'R1000-00 - PROBLEMAS NO UPDATE(AVISOSAL)' */
                _.Display($"R1000-00 - PROBLEMAS NO UPDATE(AVISOSAL)");

                /*" -2853- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2853- ADD 1 TO AC-PARCEL. */
            WS_WORK_AREAS.AC_PARCEL.Value = WS_WORK_AREAS.AC_PARCEL + 1;

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-SELECT-1 */
        public void R1000_00_PROCESSA_DB_SELECT_1()
        {
            /*" -2734- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '9999-12-31' ) END-EXEC. */

            var r1000_00_PROCESSA_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_DB_UPDATE_1()
        {
            /*" -2779- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL END-EXEC. */

            var r1000_00_PROCESSA_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_DB_UPDATE_1_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            R1000_00_PROCESSA_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-SELECT-2 */
        public void R1000_00_PROCESSA_DB_SELECT_2()
        {
            /*" -2755- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTAUXF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '9999-12-31' , '1999-12-31' ) END-EXEC. */

            var r1000_00_PROCESSA_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTAUXF, V0SAFC_VLCUSTAUXF);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-UPDATE-2 */
        public void R1000_00_PROCESSA_DB_UPDATE_2()
        {
            /*" -2798- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :WHOST-SITUACAO, OCORHIST = :V0HCOB-OCORHIST, BCOAVISO = :V0MOVC-BCOAVISO, AGEAVISO = :V0MOVC-AGEAVISO, NRAVISO = :V0MOVC-NRAVISO , NRTITCOMP = :V0MOVC-NRTIT WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL END-EXEC. */

            var r1000_00_PROCESSA_DB_UPDATE_2_Update1 = new R1000_00_PROCESSA_DB_UPDATE_2_Update1()
            {
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0MOVC_BCOAVISO = V0MOVC_BCOAVISO.ToString(),
                V0MOVC_AGEAVISO = V0MOVC_AGEAVISO.ToString(),
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V0MOVC_NRAVISO = V0MOVC_NRAVISO.ToString(),
                V0MOVC_NRTIT = V0MOVC_NRTIT.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            R1000_00_PROCESSA_DB_UPDATE_2_Update1.Execute(r1000_00_PROCESSA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1020-00-INCLUI-CDG-SECTION */
        private void R1020_00_INCLUI_CDG_SECTION()
        {
            /*" -2867- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", WABEND.WNR_EXEC_SQL);

            /*" -2869- IF V0COBP-VLCUSTCDG GREATER ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -2870- ELSE */
            }
            else
            {


                /*" -2874- GO TO R1020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2875- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WS_WORK_AREAS.DATA_SQL);

            /*" -2877- MOVE 01 TO DIA-SQL. */
            _.Move(01, WS_WORK_AREAS.DATA_SQL.DIA_SQL);

            /*" -2878- IF V0PROP-RISCO EQUAL '1' */

            if (V0PROP_RISCO == "1")
            {

                /*" -2880- ADD V0OPCP-PERIPGTO TO MES-SQL. */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;
            }


            /*" -2881- IF MES-SQL GREATER 12 */

            if (WS_WORK_AREAS.DATA_SQL.MES_SQL > 12)
            {

                /*" -2882- COMPUTE MES-SQL EQUAL MES-SQL - 12 */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL - 12;

                /*" -2884- ADD 1 TO ANO-SQL. */
                WS_WORK_AREAS.DATA_SQL.ANO_SQL.Value = WS_WORK_AREAS.DATA_SQL.ANO_SQL + 1;
            }


            /*" -2887- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WS_WORK_AREAS.DATA_SQL, V0RCDG_DTREFER);

            /*" -2899- PERFORM R1020_00_INCLUI_CDG_DB_INSERT_1 */

            R1020_00_INCLUI_CDG_DB_INSERT_1();

            /*" -2902- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2903- DISPLAY 'R1020-00 - PROBLEMAS INSERT(CDGCOBER)' */
                _.Display($"R1020-00 - PROBLEMAS INSERT(CDGCOBER)");

                /*" -2906- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2906- PERFORM R1040-00-REPASSA-CDG. */

            R1040_00_REPASSA_CDG_SECTION();

        }

        [StopWatch]
        /*" R1020-00-INCLUI-CDG-DB-INSERT-1 */
        public void R1020_00_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -2899- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, '9999-12-31' , :V0COBP-IMPSEGCDG, :V0CDGC-VLCUSTCDG, :V0HCOB-NRCERTIF, 0, '0' , 'VG0816B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1020_00_INCLUI_CDG_DB_INSERT_1_Insert1 = new R1020_00_INCLUI_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0COBP_IMPSEGCDG = V0COBP_IMPSEGCDG.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1020_00_INCLUI_CDG_DB_INSERT_1_Insert1.Execute(r1020_00_INCLUI_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-UPDATE-3 */
        public void R1000_00_PROCESSA_DB_UPDATE_3()
        {
            /*" -2811- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND TIPLANC = '1' END-EXEC */

            var r1000_00_PROCESSA_DB_UPDATE_3_Update1 = new R1000_00_PROCESSA_DB_UPDATE_3_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            R1000_00_PROCESSA_DB_UPDATE_3_Update1.Execute(r1000_00_PROCESSA_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-UPDATE-4 */
        public void R1000_00_PROCESSA_DB_UPDATE_4()
        {
            /*" -2845- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = SDOATU - :V0MOVC-VALTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BCOAVISO = :V0MOVC-BCOAVISO AND AGEAVISO = :V0MOVC-AGEAVISO AND TIPSGU = '1' AND NRAVISO = :V0MOVC-NRAVISO END-EXEC. */

            var r1000_00_PROCESSA_DB_UPDATE_4_Update1 = new R1000_00_PROCESSA_DB_UPDATE_4_Update1()
            {
                V0MOVC_VALTIT = V0MOVC_VALTIT.ToString(),
                V0MOVC_BCOAVISO = V0MOVC_BCOAVISO.ToString(),
                V0MOVC_AGEAVISO = V0MOVC_AGEAVISO.ToString(),
                V0MOVC_NRAVISO = V0MOVC_NRAVISO.ToString(),
            };

            R1000_00_PROCESSA_DB_UPDATE_4_Update1.Execute(r1000_00_PROCESSA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R1040-00-REPASSA-CDG-SECTION */
        private void R1040_00_REPASSA_CDG_SECTION()
        {
            /*" -2920- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", WABEND.WNR_EXEC_SQL);

            /*" -2922- IF V0COBP-VLCUSTCDG GREATER ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -2923- ELSE */
            }
            else
            {


                /*" -2926- GO TO R1040-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2929- IF V0HCOB-CODOPER EQUAL 121 OR 122 OR 123 */

            if (V0HCOB_CODOPER.In("121", "122", "123"))
            {

                /*" -2933- GO TO R1040-REPASSA-ATRASO. */

                R1040_REPASSA_ATRASO(); //GOTO
                return;
            }


            /*" -2934- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WS_WORK_AREAS.DATA_SQL);

            /*" -2936- MOVE 01 TO DIA-SQL. */
            _.Move(01, WS_WORK_AREAS.DATA_SQL.DIA_SQL);

            /*" -2937- IF V0PROP-RISCO EQUAL '1' */

            if (V0PROP_RISCO == "1")
            {

                /*" -2939- ADD V0OPCP-PERIPGTO TO MES-SQL. */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;
            }


            /*" -2940- IF MES-SQL GREATER 12 */

            if (WS_WORK_AREAS.DATA_SQL.MES_SQL > 12)
            {

                /*" -2941- COMPUTE MES-SQL EQUAL MES-SQL - 12 */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL - 12;

                /*" -2943- ADD 1 TO ANO-SQL. */
                WS_WORK_AREAS.DATA_SQL.ANO_SQL.Value = WS_WORK_AREAS.DATA_SQL.ANO_SQL + 1;
            }


            /*" -2946- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WS_WORK_AREAS.DATA_SQL, V0RCDG_DTREFER);

            /*" -2952- PERFORM R1040_00_REPASSA_CDG_DB_SELECT_1 */

            R1040_00_REPASSA_CDG_DB_SELECT_1();

            /*" -2955- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2958- GO TO R1040-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2968- PERFORM R1040_00_REPASSA_CDG_DB_INSERT_1 */

            R1040_00_REPASSA_CDG_DB_INSERT_1();

            /*" -2971- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2972- DISPLAY 'R1040-00 - PROBLEMAS INSERT(V0REPASSECDG)' */
                _.Display($"R1040-00 - PROBLEMAS INSERT(V0REPASSECDG)");

                /*" -2975- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2975- GO TO R1040-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R1040-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1040_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -2952- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

            var r1040_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R1040_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1040_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r1040_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1040-00-REPASSA-CDG-DB-INSERT-1 */
        public void R1040_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -2968- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HCOB-NRCERTIF, :V0HCOB-NRPARCEL, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1040_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R1040_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            R1040_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r1040_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1040-REPASSA-ATRASO */
        private void R1040_REPASSA_ATRASO(bool isPerform = false)
        {
            /*" -2982- MOVE ZEROS TO WS-EOF-D. */
            _.Move(0, WS_WORK_AREAS.WS_EOF_D);

            /*" -2991- PERFORM R1040_REPASSA_ATRASO_DB_DECLARE_1 */

            R1040_REPASSA_ATRASO_DB_DECLARE_1();

            /*" -2994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2995- DISPLAY 'R1040-00 - PROBLEMAS DECLARE DIFPARCELVA' */
                _.Display($"R1040-00 - PROBLEMAS DECLARE DIFPARCELVA");

                /*" -2998- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2998- PERFORM R1040_REPASSA_ATRASO_DB_OPEN_1 */

            R1040_REPASSA_ATRASO_DB_OPEN_1();

            /*" -3002- PERFORM R1050-00-FETCH-V0DIFPARCEL. */

            R1050_00_FETCH_V0DIFPARCEL_SECTION();

            /*" -3003- PERFORM R1060-00-PROCESSA-V0DIFPARCEL UNTIL WS-EOF-D EQUAL 1. */

            while (!(WS_WORK_AREAS.WS_EOF_D == 1))
            {

                R1060_00_PROCESSA_V0DIFPARCEL_SECTION();
            }

        }

        [StopWatch]
        /*" R1040-REPASSA-ATRASO-DB-OPEN-1 */
        public void R1040_REPASSA_ATRASO_DB_OPEN_1()
        {
            /*" -2998- EXEC SQL OPEN CDIFP END-EXEC. */

            CDIFP.Open();

        }

        [StopWatch]
        /*" R1140-REPASSA-ATRASO-DB-DECLARE-1 */
        public void R1140_REPASSA_ATRASO_DB_DECLARE_1()
        {
            /*" -3272- EXEC SQL DECLARE CDIFPA CURSOR FOR SELECT NRPARCELDIF, DTVENCTO FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND CODOPER IN (121, 122, 123) ORDER BY 1 END-EXEC. */
            CDIFPA = new VG0816B_CDIFPA(true);
            string GetQuery_CDIFPA()
            {
                var query = @$"SELECT NRPARCELDIF
							, 
							DTVENCTO 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0HCOB_NRCERTIF}' 
							AND NRPARCEL = '{V0HCOB_NRPARCEL}' 
							AND CODOPER IN (121
							, 122
							, 123) 
							ORDER BY 1";

                return query;
            }
            CDIFPA.GetQueryEvent += GetQuery_CDIFPA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-FETCH-V0DIFPARCEL-SECTION */
        private void R1050_00_FETCH_V0DIFPARCEL_SECTION()
        {
            /*" -3017- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", WABEND.WNR_EXEC_SQL);

            /*" -3021- PERFORM R1050_00_FETCH_V0DIFPARCEL_DB_FETCH_1 */

            R1050_00_FETCH_V0DIFPARCEL_DB_FETCH_1();

            /*" -3024- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3025- MOVE 1 TO WS-EOF-D */
                _.Move(1, WS_WORK_AREAS.WS_EOF_D);

                /*" -3025- PERFORM R1050_00_FETCH_V0DIFPARCEL_DB_CLOSE_1 */

                R1050_00_FETCH_V0DIFPARCEL_DB_CLOSE_1();

                /*" -3027- ELSE */
            }
            else
            {


                /*" -3028- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3029- DISPLAY 'R1050-00 - PROBLEMAS FETCH DIFPARCELVA' */
                    _.Display($"R1050-00 - PROBLEMAS FETCH DIFPARCELVA");

                    /*" -3029- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1050-00-FETCH-V0DIFPARCEL-DB-FETCH-1 */
        public void R1050_00_FETCH_V0DIFPARCEL_DB_FETCH_1()
        {
            /*" -3021- EXEC SQL FETCH CDIFP INTO :V0DIFPA-NRPARCELDIF ,:V0DIFPA-DTVENCTO END-EXEC. */

            if (CDIFP.Fetch())
            {
                _.Move(CDIFP.V0DIFPA_NRPARCELDIF, V0DIFPA_NRPARCELDIF);
                _.Move(CDIFP.V0DIFPA_DTVENCTO, V0DIFPA_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R1050-00-FETCH-V0DIFPARCEL-DB-CLOSE-1 */
        public void R1050_00_FETCH_V0DIFPARCEL_DB_CLOSE_1()
        {
            /*" -3025- EXEC SQL CLOSE CDIFP END-EXEC */

            CDIFP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-PROCESSA-V0DIFPARCEL-SECTION */
        private void R1060_00_PROCESSA_V0DIFPARCEL_SECTION()
        {
            /*" -3045- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", WABEND.WNR_EXEC_SQL);

            /*" -3046- MOVE V0DIFPA-DTVENCTO TO DATA-SQL. */
            _.Move(V0DIFPA_DTVENCTO, WS_WORK_AREAS.DATA_SQL);

            /*" -3048- MOVE 01 TO DIA-SQL. */
            _.Move(01, WS_WORK_AREAS.DATA_SQL.DIA_SQL);

            /*" -3049- IF V0PROP-RISCO EQUAL '1' */

            if (V0PROP_RISCO == "1")
            {

                /*" -3051- ADD V0OPCP-PERIPGTO TO MES-SQL. */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;
            }


            /*" -3052- IF MES-SQL GREATER 12 */

            if (WS_WORK_AREAS.DATA_SQL.MES_SQL > 12)
            {

                /*" -3053- COMPUTE MES-SQL EQUAL MES-SQL - 12 */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL - 12;

                /*" -3055- ADD 1 TO ANO-SQL. */
                WS_WORK_AREAS.DATA_SQL.ANO_SQL.Value = WS_WORK_AREAS.DATA_SQL.ANO_SQL + 1;
            }


            /*" -3058- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WS_WORK_AREAS.DATA_SQL, V0RCDG_DTREFER);

            /*" -3064- PERFORM R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1 */

            R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1();

            /*" -3067- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3070- GO TO R1060-90-LEITURA. */

                R1060_90_LEITURA(); //GOTO
                return;
            }


            /*" -3080- PERFORM R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1 */

            R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1();

            /*" -3083- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3084- DISPLAY 'R1060-00 - PROBLEMAS INSERT REPASSECDG' */
                _.Display($"R1060-00 - PROBLEMAS INSERT REPASSECDG");

                /*" -3084- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1060_90_LEITURA */

            R1060_90_LEITURA();

        }

        [StopWatch]
        /*" R1060-00-PROCESSA-V0DIFPARCEL-DB-SELECT-1 */
        public void R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1()
        {
            /*" -3064- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

            var r1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1 = new R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1.Execute(r1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1060-00-PROCESSA-V0DIFPARCEL-DB-INSERT-1 */
        public void R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1()
        {
            /*" -3080- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HCOB-NRCERTIF, :V0DIFPA-NRPARCELDIF, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1 = new R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0DIFPA_NRPARCELDIF = V0DIFPA_NRPARCELDIF.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1.Execute(r1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1060-90-LEITURA */
        private void R1060_90_LEITURA(bool isPerform = false)
        {
            /*" -3089- PERFORM R1050-00-FETCH-V0DIFPARCEL. */

            R1050_00_FETCH_V0DIFPARCEL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-INCLUI-SAF-SECTION */
        private void R1120_00_INCLUI_SAF_SECTION()
        {
            /*" -3102- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", WABEND.WNR_EXEC_SQL);

            /*" -3104- IF V0COBP-VLCUSTAUXF GREATER ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -3105- ELSE */
            }
            else
            {


                /*" -3110- GO TO R1120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3111- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WS_WORK_AREAS.DATA_SQL);

            /*" -3113- MOVE 01 TO DIA-SQL. */
            _.Move(01, WS_WORK_AREAS.DATA_SQL.DIA_SQL);

            /*" -3114- IF V0PROP-RISCO EQUAL '1' */

            if (V0PROP_RISCO == "1")
            {

                /*" -3116- ADD V0OPCP-PERIPGTO TO MES-SQL. */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;
            }


            /*" -3117- IF MES-SQL GREATER 12 */

            if (WS_WORK_AREAS.DATA_SQL.MES_SQL > 12)
            {

                /*" -3118- COMPUTE MES-SQL EQUAL MES-SQL - 12 */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL - 12;

                /*" -3120- ADD 1 TO ANO-SQL. */
                WS_WORK_AREAS.DATA_SQL.ANO_SQL.Value = WS_WORK_AREAS.DATA_SQL.ANO_SQL + 1;
            }


            /*" -3122- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WS_WORK_AREAS.DATA_SQL, V0RSAF_DTREFER);

            /*" -3125- MOVE V0COBP-VLCUSTAUXF TO V0SAFC-VLCUSTAUXF. */
            _.Move(V0COBP_VLCUSTAUXF, V0SAFC_VLCUSTAUXF);

            /*" -3137- PERFORM R1120_00_INCLUI_SAF_DB_INSERT_1 */

            R1120_00_INCLUI_SAF_DB_INSERT_1();

            /*" -3141- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3142- DISPLAY 'R1120-00 - PROBLEMAS INSERT V0SAFCOBER' */
                _.Display($"R1120-00 - PROBLEMAS INSERT V0SAFCOBER");

                /*" -3145- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3152- PERFORM R1120_00_INCLUI_SAF_DB_SELECT_1 */

            R1120_00_INCLUI_SAF_DB_SELECT_1();

            /*" -3155- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3158- GO TO R1120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3174- PERFORM R1120_00_INCLUI_SAF_DB_INSERT_2 */

            R1120_00_INCLUI_SAF_DB_INSERT_2();

            /*" -3178- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3179- DISPLAY 'R1120-00 - PROBLEMAS INSERT V0HISTREPSAF' */
                _.Display($"R1120-00 - PROBLEMAS INSERT V0HISTREPSAF");

                /*" -3182- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3182- PERFORM R1140-00-REPASSA-SAF. */

            R1140_00_REPASSA_SAF_SECTION();

        }

        [StopWatch]
        /*" R1120-00-INCLUI-SAF-DB-INSERT-1 */
        public void R1120_00_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -3137- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, '9999-12-31' , :V0COBP-IMPSEGAUXF, :V0SAFC-VLCUSTAUXF, :V0HCOB-NRCERTIF, 0, '0' , 'VG0816B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1120_00_INCLUI_SAF_DB_INSERT_1_Insert1 = new R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0COBP_IMPSEGAUXF = V0COBP_IMPSEGAUXF.ToString(),
                V0SAFC_VLCUSTAUXF = V0SAFC_VLCUSTAUXF.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(r1120_00_INCLUI_SAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1120-00-INCLUI-SAF-DB-SELECT-1 */
        public void R1120_00_INCLUI_SAF_DB_SELECT_1()
        {
            /*" -3152- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 102 END-EXEC. */

            var r1120_00_INCLUI_SAF_DB_SELECT_1_Query1 = new R1120_00_INCLUI_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1120_00_INCLUI_SAF_DB_SELECT_1_Query1.Execute(r1120_00_INCLUI_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-INCLUI-SAF-DB-INSERT-2 */
        public void R1120_00_INCLUI_SAF_DB_INSERT_2()
        {
            /*" -3174- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCOB-NRCERTIF, :V0HCOB-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTAUXF, 102, '0' , '0' , 0, 0, 'VG0816B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1120_00_INCLUI_SAF_DB_INSERT_2_Insert1 = new R1120_00_INCLUI_SAF_DB_INSERT_2_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTAUXF = V0SAFC_VLCUSTAUXF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1120_00_INCLUI_SAF_DB_INSERT_2_Insert1.Execute(r1120_00_INCLUI_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1140-00-REPASSA-SAF-SECTION */
        private void R1140_00_REPASSA_SAF_SECTION()
        {
            /*" -3196- MOVE '1140' TO WNR-EXEC-SQL. */
            _.Move("1140", WABEND.WNR_EXEC_SQL);

            /*" -3198- IF V0COBP-VLCUSTAUXF GREATER ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -3199- ELSE */
            }
            else
            {


                /*" -3201- GO TO R1140-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3204- IF V0HCOB-CODOPER EQUAL 121 OR 122 OR 123 */

            if (V0HCOB_CODOPER.In("121", "122", "123"))
            {

                /*" -3208- GO TO R1140-REPASSA-ATRASO. */

                R1140_REPASSA_ATRASO(); //GOTO
                return;
            }


            /*" -3209- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WS_WORK_AREAS.DATA_SQL);

            /*" -3211- MOVE 01 TO DIA-SQL. */
            _.Move(01, WS_WORK_AREAS.DATA_SQL.DIA_SQL);

            /*" -3212- IF V0PROP-RISCO EQUAL '1' */

            if (V0PROP_RISCO == "1")
            {

                /*" -3214- ADD V0OPCP-PERIPGTO TO MES-SQL. */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;
            }


            /*" -3215- IF MES-SQL GREATER 12 */

            if (WS_WORK_AREAS.DATA_SQL.MES_SQL > 12)
            {

                /*" -3216- COMPUTE MES-SQL EQUAL MES-SQL - 12 */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL - 12;

                /*" -3218- ADD 1 TO ANO-SQL. */
                WS_WORK_AREAS.DATA_SQL.ANO_SQL.Value = WS_WORK_AREAS.DATA_SQL.ANO_SQL + 1;
            }


            /*" -3221- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WS_WORK_AREAS.DATA_SQL, V0RSAF_DTREFER);

            /*" -3228- PERFORM R1140_00_REPASSA_SAF_DB_SELECT_1 */

            R1140_00_REPASSA_SAF_DB_SELECT_1();

            /*" -3231- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3233- GO TO R1140-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3249- PERFORM R1140_00_REPASSA_SAF_DB_INSERT_1 */

            R1140_00_REPASSA_SAF_DB_INSERT_1();

            /*" -3253- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3254- DISPLAY 'R1140-00 - PROBLEMAS INSERT V0HISTREPSAF' */
                _.Display($"R1140-00 - PROBLEMAS INSERT V0HISTREPSAF");

                /*" -3257- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3257- GO TO R1140-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R1140-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1140_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -3228- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 END-EXEC. */

            var r1140_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1140_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1140_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1140_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1140-00-REPASSA-SAF-DB-INSERT-1 */
        public void R1140_00_REPASSA_SAF_DB_INSERT_1()
        {
            /*" -3249- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCOB-NRCERTIF, :V0HCOB-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTAUXF, 1100, '0' , '0' , 0, 0, 'VG0816B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1140_00_REPASSA_SAF_DB_INSERT_1_Insert1 = new R1140_00_REPASSA_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTAUXF = V0SAFC_VLCUSTAUXF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1140_00_REPASSA_SAF_DB_INSERT_1_Insert1.Execute(r1140_00_REPASSA_SAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1140-REPASSA-ATRASO */
        private void R1140_REPASSA_ATRASO(bool isPerform = false)
        {
            /*" -3263- MOVE ZEROS TO WS-EOF-D. */
            _.Move(0, WS_WORK_AREAS.WS_EOF_D);

            /*" -3272- PERFORM R1140_REPASSA_ATRASO_DB_DECLARE_1 */

            R1140_REPASSA_ATRASO_DB_DECLARE_1();

            /*" -3274- PERFORM R1140_REPASSA_ATRASO_DB_OPEN_1 */

            R1140_REPASSA_ATRASO_DB_OPEN_1();

            /*" -3278- PERFORM R1150-00-FETCH-V0DIFPARCEL. */

            R1150_00_FETCH_V0DIFPARCEL_SECTION();

            /*" -3279- PERFORM R1160-00-PROCESSA-V0DIFPARCEL UNTIL WS-EOF-D EQUAL 1. */

            while (!(WS_WORK_AREAS.WS_EOF_D == 1))
            {

                R1160_00_PROCESSA_V0DIFPARCEL_SECTION();
            }

        }

        [StopWatch]
        /*" R1140-REPASSA-ATRASO-DB-OPEN-1 */
        public void R1140_REPASSA_ATRASO_DB_OPEN_1()
        {
            /*" -3274- EXEC SQL OPEN CDIFPA END-EXEC. */

            CDIFPA.Open();

        }

        [StopWatch]
        /*" R1250-00-BAIXA-DO-FEDERAL-DB-DECLARE-1 */
        public void R1250_00_BAIXA_DO_FEDERAL_DB_DECLARE_1()
        {
            /*" -3495- EXEC SQL DECLARE CCMPTIT CURSOR FOR SELECT NRPARCEL, CODOPER, PRMDIFVG + PRMDIFAP FROM SEGUROS.V0COMPTITVA WHERE NRTIT = :V0HCOB-NRTIT ORDER BY 1 WITH UR END-EXEC. */
            CCMPTIT = new VG0816B_CCMPTIT(true);
            string GetQuery_CCMPTIT()
            {
                var query = @$"SELECT NRPARCEL
							, 
							CODOPER
							, 
							PRMDIFVG + PRMDIFAP 
							FROM SEGUROS.V0COMPTITVA 
							WHERE NRTIT = '{V0HCOB_NRTIT}' 
							ORDER BY 1";

                return query;
            }
            CCMPTIT.GetQueryEvent += GetQuery_CCMPTIT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-FETCH-V0DIFPARCEL-SECTION */
        private void R1150_00_FETCH_V0DIFPARCEL_SECTION()
        {
            /*" -3293- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", WABEND.WNR_EXEC_SQL);

            /*" -3297- PERFORM R1150_00_FETCH_V0DIFPARCEL_DB_FETCH_1 */

            R1150_00_FETCH_V0DIFPARCEL_DB_FETCH_1();

            /*" -3300- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3301- MOVE 1 TO WS-EOF-D */
                _.Move(1, WS_WORK_AREAS.WS_EOF_D);

                /*" -3301- PERFORM R1150_00_FETCH_V0DIFPARCEL_DB_CLOSE_1 */

                R1150_00_FETCH_V0DIFPARCEL_DB_CLOSE_1();

                /*" -3302- END-IF. */
            }


        }

        [StopWatch]
        /*" R1150-00-FETCH-V0DIFPARCEL-DB-FETCH-1 */
        public void R1150_00_FETCH_V0DIFPARCEL_DB_FETCH_1()
        {
            /*" -3297- EXEC SQL FETCH CDIFPA INTO :V0DIFPA-NRPARCELDIF, :V0DIFPA-DTVENCTO END-EXEC. */

            if (CDIFPA.Fetch())
            {
                _.Move(CDIFPA.V0DIFPA_NRPARCELDIF, V0DIFPA_NRPARCELDIF);
                _.Move(CDIFPA.V0DIFPA_DTVENCTO, V0DIFPA_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R1150-00-FETCH-V0DIFPARCEL-DB-CLOSE-1 */
        public void R1150_00_FETCH_V0DIFPARCEL_DB_CLOSE_1()
        {
            /*" -3301- EXEC SQL CLOSE CDIFPA END-EXEC */

            CDIFPA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1160-00-PROCESSA-V0DIFPARCEL-SECTION */
        private void R1160_00_PROCESSA_V0DIFPARCEL_SECTION()
        {
            /*" -3317- MOVE '1160' TO WNR-EXEC-SQL. */
            _.Move("1160", WABEND.WNR_EXEC_SQL);

            /*" -3318- MOVE V0DIFPA-DTVENCTO TO DATA-SQL. */
            _.Move(V0DIFPA_DTVENCTO, WS_WORK_AREAS.DATA_SQL);

            /*" -3320- MOVE 01 TO DIA-SQL. */
            _.Move(01, WS_WORK_AREAS.DATA_SQL.DIA_SQL);

            /*" -3321- IF V0PROP-RISCO EQUAL '1' */

            if (V0PROP_RISCO == "1")
            {

                /*" -3323- ADD V0OPCP-PERIPGTO TO MES-SQL. */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;
            }


            /*" -3324- IF MES-SQL GREATER 12 */

            if (WS_WORK_AREAS.DATA_SQL.MES_SQL > 12)
            {

                /*" -3325- COMPUTE MES-SQL EQUAL MES-SQL - 12 */
                WS_WORK_AREAS.DATA_SQL.MES_SQL.Value = WS_WORK_AREAS.DATA_SQL.MES_SQL - 12;

                /*" -3327- ADD 1 TO ANO-SQL. */
                WS_WORK_AREAS.DATA_SQL.ANO_SQL.Value = WS_WORK_AREAS.DATA_SQL.ANO_SQL + 1;
            }


            /*" -3329- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WS_WORK_AREAS.DATA_SQL, V0RSAF_DTREFER);

            /*" -3336- PERFORM R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1 */

            R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1();

            /*" -3340- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3343- GO TO R1160-90-LEITURA. */

                R1160_90_LEITURA(); //GOTO
                return;
            }


            /*" -3359- PERFORM R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1 */

            R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1();

            /*" -3362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3363- DISPLAY 'R1160-00 - PROBLEMAS INSERT V0HISTREPSAF' */
                _.Display($"R1160-00 - PROBLEMAS INSERT V0HISTREPSAF");

                /*" -3363- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1160_90_LEITURA */

            R1160_90_LEITURA();

        }

        [StopWatch]
        /*" R1160-00-PROCESSA-V0DIFPARCEL-DB-SELECT-1 */
        public void R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1()
        {
            /*" -3336- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 END-EXEC. */

            var r1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1 = new R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1.Execute(r1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1160-00-PROCESSA-V0DIFPARCEL-DB-INSERT-1 */
        public void R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1()
        {
            /*" -3359- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCOB-NRCERTIF, :V0HCOB-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTAUXF, 1100, '0' , '0' , 0, 0, 'VG0816B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1 = new R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTAUXF = V0SAFC_VLCUSTAUXF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1.Execute(r1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1160-90-LEITURA */
        private void R1160_90_LEITURA(bool isPerform = false)
        {
            /*" -3368- PERFORM R1150-00-FETCH-V0DIFPARCEL. */

            R1150_00_FETCH_V0DIFPARCEL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-GRAVA-DIFERENCA-SECTION */
        private void R1210_00_GRAVA_DIFERENCA_SECTION()
        {
            /*" -3381- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -3381- MOVE V0HCOB-NRPARCEL TO V0DIFP-NRPARCEL. */
            _.Move(V0HCOB_NRPARCEL, V0DIFP_NRPARCEL);

            /*" -0- FLUXCONTROL_PERFORM R1210_50_LOOP */

            R1210_50_LOOP();

        }

        [StopWatch]
        /*" R1210-50-LOOP */
        private void R1210_50_LOOP(bool isPerform = false)
        {
            /*" -3400- PERFORM R1210_50_LOOP_DB_INSERT_1 */

            R1210_50_LOOP_DB_INSERT_1();

            /*" -3404- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3405- ADD 1 TO V0DIFP-NRPARCEL */
                V0DIFP_NRPARCEL.Value = V0DIFP_NRPARCEL + 1;

                /*" -3406- GO TO R1210-50-LOOP */
                new Task(() => R1210_50_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3407- ELSE */
            }
            else
            {


                /*" -3408- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3409- DISPLAY 'R1210-00 - PROBLEMAS INSERT V0DIFPARCELVA' */
                    _.Display($"R1210-00 - PROBLEMAS INSERT V0DIFPARCELVA");

                    /*" -3409- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-50-LOOP-DB-INSERT-1 */
        public void R1210_50_LOOP_DB_INSERT_1()
        {
            /*" -3400- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCOB-NRCERTIF, 9999, :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0PARC-DTVENCTO, :V0DIFP-PRMDEVVG, :V0DIFP-PRMDEVAP, :V0DIFP-PRMPAGVG, :V0DIFP-PRMPAGAP, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, ' ' ) END-EXEC. */

            var r1210_50_LOOP_DB_INSERT_1_Insert1 = new R1210_50_LOOP_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0DIFP_PRMDEVVG = V0DIFP_PRMDEVVG.ToString(),
                V0DIFP_PRMDEVAP = V0DIFP_PRMDEVAP.ToString(),
                V0DIFP_PRMPAGVG = V0DIFP_PRMPAGVG.ToString(),
                V0DIFP_PRMPAGAP = V0DIFP_PRMPAGAP.ToString(),
                V0DIFP_PRMDIFVG = V0DIFP_PRMDIFVG.ToString(),
                V0DIFP_PRMDIFAP = V0DIFP_PRMDIFAP.ToString(),
            };

            R1210_50_LOOP_DB_INSERT_1_Insert1.Execute(r1210_50_LOOP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-BAIXA-DO-MULTI-SECTION */
        private void R1230_00_BAIXA_DO_MULTI_SECTION()
        {
            /*" -3423- MOVE '1230' TO WNR-EXEC-SQL. */
            _.Move("1230", WABEND.WNR_EXEC_SQL);

            /*" -3428- PERFORM R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1 */

            R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1();

            /*" -3432- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3433- DISPLAY 'R1230-00 - PROBLEMAS UPDATE V0DIFPARCELVA' */
                _.Display($"R1230-00 - PROBLEMAS UPDATE V0DIFPARCELVA");

                /*" -3436- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3438- IF V0PROP-QTDPARATZ GREATER ZEROS AND WHOST-SITUACAO EQUAL '1' */

            if (V0PROP_QTDPARATZ > 00 && WHOST_SITUACAO == "1")
            {

                /*" -3439- SUBTRACT 1 FROM V0PROP-QTDPARATZ */
                V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ - 1;

                /*" -3443- PERFORM R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2 */

                R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2();

                /*" -3445- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3446- DISPLAY 'R1230-00 - PROBLEMAS UPDATE V0PROPOSTAVA1' */
                    _.Display($"R1230-00 - PROBLEMAS UPDATE V0PROPOSTAVA1");

                    /*" -3449- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3450- IF V0PROP-SITUACAO EQUAL '8' */

            if (V0PROP_SITUACAO == "8")
            {

                /*" -3455- PERFORM R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3 */

                R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3();

                /*" -3457- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3458- DISPLAY 'R1230-00 - PROBLEMAS UPDATE V0PROPOSTAVA2' */
                    _.Display($"R1230-00 - PROBLEMAS UPDATE V0PROPOSTAVA2");

                    /*" -3461- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3463- IF V0PROP-SITUACAO EQUAL '6' AND V0PROP-NRPARCEL EQUAL V0HCOB-NRPARCEL */

            if (V0PROP_SITUACAO == "6" && V0PROP_NRPARCEL == V0HCOB_NRPARCEL)
            {

                /*" -3469- PERFORM R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4 */

                R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4();

                /*" -3471- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3472- DISPLAY 'R1230-00 - PROBLEMAS UPDATE V0PROPOSTAVA2' */
                    _.Display($"R1230-00 - PROBLEMAS UPDATE V0PROPOSTAVA2");

                    /*" -3472- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1230-00-BAIXA-DO-MULTI-DB-UPDATE-1 */
        public void R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1()
        {
            /*" -3428- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL END-EXEC. */

            var r1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1 = new R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1.Execute(r1230_00_BAIXA_DO_MULTI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-BAIXA-DO-MULTI-DB-UPDATE-2 */
        public void R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2()
        {
            /*" -3443- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = :V0PROP-QTDPARATZ WHERE NRCERTIF = :V0HCOB-NRCERTIF END-EXEC */

            var r1230_00_BAIXA_DO_MULTI_DB_UPDATE_2_Update1 = new R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2_Update1()
            {
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2_Update1.Execute(r1230_00_BAIXA_DO_MULTI_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1250-00-BAIXA-DO-FEDERAL-SECTION */
        private void R1250_00_BAIXA_DO_FEDERAL_SECTION()
        {
            /*" -3486- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", WABEND.WNR_EXEC_SQL);

            /*" -3495- PERFORM R1250_00_BAIXA_DO_FEDERAL_DB_DECLARE_1 */

            R1250_00_BAIXA_DO_FEDERAL_DB_DECLARE_1();

            /*" -3497- PERFORM R1250_00_BAIXA_DO_FEDERAL_DB_OPEN_1 */

            R1250_00_BAIXA_DO_FEDERAL_DB_OPEN_1();

            /*" -3500- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3501- DISPLAY 'R1250-00 - PROBLEMAS DECLARE V0COMPTITVA' */
                _.Display($"R1250-00 - PROBLEMAS DECLARE V0COMPTITVA");

                /*" -3504- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3506- MOVE ZEROS TO WS-EOC. */
            _.Move(0, WS_WORK_AREAS.WS_EOC);

            /*" -3508- PERFORM R1260-00-FETCH-V0COMPTITVA. */

            R1260_00_FETCH_V0COMPTITVA_SECTION();

            /*" -3512- PERFORM R1280-00-PROC-COMPOSICAO UNTIL WS-EOC EQUAL 1. */

            while (!(WS_WORK_AREAS.WS_EOC == 1))
            {

                R1280_00_PROC_COMPOSICAO_SECTION();
            }

            /*" -3513- IF V0HCOB-NRPARCEL EQUAL 1 */

            if (V0HCOB_NRPARCEL == 1)
            {

                /*" -3513- PERFORM R1320-00-AJUSTA-VIGENCIA. */

                R1320_00_AJUSTA_VIGENCIA_SECTION();
            }


        }

        [StopWatch]
        /*" R1250-00-BAIXA-DO-FEDERAL-DB-OPEN-1 */
        public void R1250_00_BAIXA_DO_FEDERAL_DB_OPEN_1()
        {
            /*" -3497- EXEC SQL OPEN CCMPTIT END-EXEC. */

            CCMPTIT.Open();

        }

        [StopWatch]
        /*" R1280-00-PROC-COMPOSICAO-DB-DECLARE-1 */
        public void R1280_00_PROC_COMPOSICAO_DB_DECLARE_1()
        {
            /*" -3589- EXEC SQL DECLARE CPLCOM CURSOR FOR SELECT DISTINCT CODPDT FROM SEGUROS.V0PLANCOMISVF WHERE NRCERTIF = :V0HCOB-NRCERTIF ORDER BY CODPDT END-EXEC. */
            CPLCOM = new VG0816B_CPLCOM(true);
            string GetQuery_CPLCOM()
            {
                var query = @$"SELECT DISTINCT CODPDT 
							FROM SEGUROS.V0PLANCOMISVF 
							WHERE NRCERTIF = '{V0HCOB_NRCERTIF}' 
							ORDER BY CODPDT";

                return query;
            }
            CPLCOM.GetQueryEvent += GetQuery_CPLCOM;

        }

        [StopWatch]
        /*" R1230-00-BAIXA-DO-MULTI-DB-UPDATE-3 */
        public void R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3()
        {
            /*" -3455- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '0' , DTQITBCO = :V0MOVC-DTQITBCO WHERE NRCERTIF = :V0HCOB-NRCERTIF END-EXEC */

            var r1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1 = new R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1()
            {
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1.Execute(r1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-BAIXA-DO-MULTI-DB-UPDATE-4 */
        public void R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4()
        {
            /*" -3469- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '3' , NRPRIPARATZ = 0 , QTDPARATZ = 0 WHERE NRCERTIF = :V0HCOB-NRCERTIF END-EXEC */

            var r1230_00_BAIXA_DO_MULTI_DB_UPDATE_4_Update1 = new R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4_Update1.Execute(r1230_00_BAIXA_DO_MULTI_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R1260-00-FETCH-V0COMPTITVA-SECTION */
        private void R1260_00_FETCH_V0COMPTITVA_SECTION()
        {
            /*" -3527- MOVE '1260' TO WNR-EXEC-SQL. */
            _.Move("1260", WABEND.WNR_EXEC_SQL);

            /*" -3532- PERFORM R1260_00_FETCH_V0COMPTITVA_DB_FETCH_1 */

            R1260_00_FETCH_V0COMPTITVA_DB_FETCH_1();

            /*" -3535- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3536- MOVE 1 TO WS-EOC */
                _.Move(1, WS_WORK_AREAS.WS_EOC);

                /*" -3536- PERFORM R1260_00_FETCH_V0COMPTITVA_DB_CLOSE_1 */

                R1260_00_FETCH_V0COMPTITVA_DB_CLOSE_1();

                /*" -3537- END-IF. */
            }


        }

        [StopWatch]
        /*" R1260-00-FETCH-V0COMPTITVA-DB-FETCH-1 */
        public void R1260_00_FETCH_V0COMPTITVA_DB_FETCH_1()
        {
            /*" -3532- EXEC SQL FETCH CCMPTIT INTO :V0CMPT-NRPARCEL, :V0CMPT-CODOPER, :V0CMPT-VLPRMDIF END-EXEC. */

            if (CCMPTIT.Fetch())
            {
                _.Move(CCMPTIT.V0CMPT_NRPARCEL, V0CMPT_NRPARCEL);
                _.Move(CCMPTIT.V0CMPT_CODOPER, V0CMPT_CODOPER);
                _.Move(CCMPTIT.V0CMPT_VLPRMDIF, V0CMPT_VLPRMDIF);
            }

        }

        [StopWatch]
        /*" R1260-00-FETCH-V0COMPTITVA-DB-CLOSE-1 */
        public void R1260_00_FETCH_V0COMPTITVA_DB_CLOSE_1()
        {
            /*" -3536- EXEC SQL CLOSE CCMPTIT END-EXEC */

            CCMPTIT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/

        [StopWatch]
        /*" R1280-00-PROC-COMPOSICAO-SECTION */
        private void R1280_00_PROC_COMPOSICAO_SECTION()
        {
            /*" -3551- MOVE '1280' TO WNR-EXEC-SQL. */
            _.Move("1280", WABEND.WNR_EXEC_SQL);

            /*" -3555- IF (V0CMPT-CODOPER NOT LESS 400 AND V0CMPT-CODOPER NOT GREATER 499) OR (V0CMPT-CODOPER NOT LESS 600 AND V0CMPT-CODOPER NOT GREATER 699) */

            if ((V0CMPT_CODOPER >= 400 && V0CMPT_CODOPER <= 499) || (V0CMPT_CODOPER >= 600 && V0CMPT_CODOPER <= 699))
            {

                /*" -3562- PERFORM R1280_00_PROC_COMPOSICAO_DB_UPDATE_1 */

                R1280_00_PROC_COMPOSICAO_DB_UPDATE_1();

                /*" -3565- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -3566- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3567- END-IF */
                }


                /*" -3570- GO TO R1280-90-LEITURA. */

                R1280_90_LEITURA(); //GOTO
                return;
            }


            /*" -3576- PERFORM R1280_00_PROC_COMPOSICAO_DB_UPDATE_2 */

            R1280_00_PROC_COMPOSICAO_DB_UPDATE_2();

            /*" -3579- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3580- DISPLAY 'R1280-00 - PROBLEMAS UPDATE V0PARCELVA' */
                _.Display($"R1280-00 - PROBLEMAS UPDATE V0PARCELVA");

                /*" -3583- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3589- PERFORM R1280_00_PROC_COMPOSICAO_DB_DECLARE_1 */

            R1280_00_PROC_COMPOSICAO_DB_DECLARE_1();

            /*" -3591- PERFORM R1280_00_PROC_COMPOSICAO_DB_OPEN_1 */

            R1280_00_PROC_COMPOSICAO_DB_OPEN_1();

            /*" -3595- MOVE ZEROS TO WS-EOP. */
            _.Move(0, WS_WORK_AREAS.WS_EOP);

            /*" -3597- PERFORM R1290-00-FETCH-V0PLANCOMISVF. */

            R1290_00_FETCH_V0PLANCOMISVF_SECTION();

            /*" -3598- PERFORM R1300-00-GERA-EVENTO UNTIL WS-EOP EQUAL 1. */

            while (!(WS_WORK_AREAS.WS_EOP == 1))
            {

                R1300_00_GERA_EVENTO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R1280_90_LEITURA */

            R1280_90_LEITURA();

        }

        [StopWatch]
        /*" R1280-00-PROC-COMPOSICAO-DB-UPDATE-1 */
        public void R1280_00_PROC_COMPOSICAO_DB_UPDATE_1()
        {
            /*" -3562- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCELDIF = :V0CMPT-NRPARCEL AND CODOPER = :V0CMPT-CODOPER AND SITUACAO = ' ' END-EXEC */

            var r1280_00_PROC_COMPOSICAO_DB_UPDATE_1_Update1 = new R1280_00_PROC_COMPOSICAO_DB_UPDATE_1_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0CMPT_NRPARCEL = V0CMPT_NRPARCEL.ToString(),
                V0CMPT_CODOPER = V0CMPT_CODOPER.ToString(),
            };

            R1280_00_PROC_COMPOSICAO_DB_UPDATE_1_Update1.Execute(r1280_00_PROC_COMPOSICAO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1280-90-LEITURA */
        private void R1280_90_LEITURA(bool isPerform = false)
        {
            /*" -3604- PERFORM R1260-00-FETCH-V0COMPTITVA. */

            R1260_00_FETCH_V0COMPTITVA_SECTION();

        }

        [StopWatch]
        /*" R1280-00-PROC-COMPOSICAO-DB-OPEN-1 */
        public void R1280_00_PROC_COMPOSICAO_DB_OPEN_1()
        {
            /*" -3591- EXEC SQL OPEN CPLCOM END-EXEC. */

            CPLCOM.Open();

        }

        [StopWatch]
        /*" R1280-00-PROC-COMPOSICAO-DB-UPDATE-2 */
        public void R1280_00_PROC_COMPOSICAO_DB_UPDATE_2()
        {
            /*" -3576- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0CMPT-NRPARCEL END-EXEC. */

            var r1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1 = new R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0CMPT_NRPARCEL = V0CMPT_NRPARCEL.ToString(),
            };

            R1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1.Execute(r1280_00_PROC_COMPOSICAO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/

        [StopWatch]
        /*" R1290-00-FETCH-V0PLANCOMISVF-SECTION */
        private void R1290_00_FETCH_V0PLANCOMISVF_SECTION()
        {
            /*" -3616- MOVE '1290' TO WNR-EXEC-SQL. */
            _.Move("1290", WABEND.WNR_EXEC_SQL);

            /*" -3619- PERFORM R1290_00_FETCH_V0PLANCOMISVF_DB_FETCH_1 */

            R1290_00_FETCH_V0PLANCOMISVF_DB_FETCH_1();

            /*" -3622- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3622- PERFORM R1290_00_FETCH_V0PLANCOMISVF_DB_CLOSE_1 */

                R1290_00_FETCH_V0PLANCOMISVF_DB_CLOSE_1();

                /*" -3623- MOVE 1 TO WS-EOP. */
                _.Move(1, WS_WORK_AREAS.WS_EOP);
            }


        }

        [StopWatch]
        /*" R1290-00-FETCH-V0PLANCOMISVF-DB-FETCH-1 */
        public void R1290_00_FETCH_V0PLANCOMISVF_DB_FETCH_1()
        {
            /*" -3619- EXEC SQL FETCH CPLCOM INTO :V0PLCO-CODPDT END-EXEC. */

            if (CPLCOM.Fetch())
            {
                _.Move(CPLCOM.V0PLCO_CODPDT, V0PLCO_CODPDT);
            }

        }

        [StopWatch]
        /*" R1290-00-FETCH-V0PLANCOMISVF-DB-CLOSE-1 */
        public void R1290_00_FETCH_V0PLANCOMISVF_DB_CLOSE_1()
        {
            /*" -3622- EXEC SQL CLOSE CPLCOM END-EXEC. */

            CPLCOM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1290_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GERA-EVENTO-SECTION */
        private void R1300_00_GERA_EVENTO_SECTION()
        {
            /*" -3636- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -3641- PERFORM R1300_00_GERA_EVENTO_DB_SELECT_1 */

            R1300_00_GERA_EVENTO_DB_SELECT_1();

            /*" -3644- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3645- DISPLAY 'R1300-00 - PROBLEMAS SELECT V0PRODUTORVF' */
                _.Display($"R1300-00 - PROBLEMAS SELECT V0PRODUTORVF");

                /*" -3645- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_50_LOOP */

            R1300_50_LOOP();

        }

        [StopWatch]
        /*" R1300-00-GERA-EVENTO-DB-SELECT-1 */
        public void R1300_00_GERA_EVENTO_DB_SELECT_1()
        {
            /*" -3641- EXEC SQL SELECT OCORHIST INTO :V0PDTV-OCORHIST FROM SEGUROS.V0PRODUTORVF WHERE CODPDT = :V0PLCO-CODPDT END-EXEC. */

            var r1300_00_GERA_EVENTO_DB_SELECT_1_Query1 = new R1300_00_GERA_EVENTO_DB_SELECT_1_Query1()
            {
                V0PLCO_CODPDT = V0PLCO_CODPDT.ToString(),
            };

            var executed_1 = R1300_00_GERA_EVENTO_DB_SELECT_1_Query1.Execute(r1300_00_GERA_EVENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PDTV_OCORHIST, V0PDTV_OCORHIST);
            }


        }

        [StopWatch]
        /*" R1300-50-LOOP */
        private void R1300_50_LOOP(bool isPerform = false)
        {
            /*" -3653- ADD 1 TO V0PDTV-OCORHIST. */
            V0PDTV_OCORHIST.Value = V0PDTV_OCORHIST + 1;

            /*" -3657- PERFORM R1300_50_LOOP_DB_UPDATE_1 */

            R1300_50_LOOP_DB_UPDATE_1();

            /*" -3660- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3661- DISPLAY 'R1300-00 - PROBLEMAS UPDATE V0PRODUTORVF' */
                _.Display($"R1300-00 - PROBLEMAS UPDATE V0PRODUTORVF");

                /*" -3664- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3680- PERFORM R1300_50_LOOP_DB_INSERT_1 */

            R1300_50_LOOP_DB_INSERT_1();

            /*" -3683- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3684- GO TO R1300-50-LOOP */
                new Task(() => R1300_50_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3685- ELSE */
            }
            else
            {


                /*" -3686- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3687- DISPLAY 'R1300-00 - PROBLEMAS INSERT V0EVENTOSVF' */
                    _.Display($"R1300-00 - PROBLEMAS INSERT V0EVENTOSVF");

                    /*" -3690- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3690- PERFORM R1300-90-LEITURA. */

            R1300_90_LEITURA(true);

        }

        [StopWatch]
        /*" R1300-50-LOOP-DB-UPDATE-1 */
        public void R1300_50_LOOP_DB_UPDATE_1()
        {
            /*" -3657- EXEC SQL UPDATE SEGUROS.V0PRODUTORVF SET OCORHIST = :V0PDTV-OCORHIST WHERE CODPDT = :V0PLCO-CODPDT END-EXEC. */

            var r1300_50_LOOP_DB_UPDATE_1_Update1 = new R1300_50_LOOP_DB_UPDATE_1_Update1()
            {
                V0PDTV_OCORHIST = V0PDTV_OCORHIST.ToString(),
                V0PLCO_CODPDT = V0PLCO_CODPDT.ToString(),
            };

            R1300_50_LOOP_DB_UPDATE_1_Update1.Execute(r1300_50_LOOP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1300-50-LOOP-DB-INSERT-1 */
        public void R1300_50_LOOP_DB_INSERT_1()
        {
            /*" -3680- EXEC SQL INSERT INTO SEGUROS.V0EVENTOSVF VALUES (:V0PLCO-CODPDT, :V0PDTV-OCORHIST, 0, :V0HCOB-NRCERTIF, :V0CMPT-NRPARCEL, 8, :V0DIFP-CODOPER, :V0SIST-DTMOVABE, :V0MOVC-DTQITBCO, '0' , :V0CMPT-VLPRMDIF, 0, 'VG0816B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1300_50_LOOP_DB_INSERT_1_Insert1 = new R1300_50_LOOP_DB_INSERT_1_Insert1()
            {
                V0PLCO_CODPDT = V0PLCO_CODPDT.ToString(),
                V0PDTV_OCORHIST = V0PDTV_OCORHIST.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0CMPT_NRPARCEL = V0CMPT_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                V0CMPT_VLPRMDIF = V0CMPT_VLPRMDIF.ToString(),
            };

            R1300_50_LOOP_DB_INSERT_1_Insert1.Execute(r1300_50_LOOP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1300-90-LEITURA */
        private void R1300_90_LEITURA(bool isPerform = false)
        {
            /*" -3693- PERFORM R1290-00-FETCH-V0PLANCOMISVF. */

            R1290_00_FETCH_V0PLANCOMISVF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-AJUSTA-VIGENCIA-SECTION */
        private void R1320_00_AJUSTA_VIGENCIA_SECTION()
        {
            /*" -3705- MOVE '1320' TO WNR-EXEC-SQL. */
            _.Move("1320", WABEND.WNR_EXEC_SQL);

            /*" -3711- PERFORM R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1 */

            R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1();

            /*" -3714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3715- DISPLAY 'R1320-00 - PROBLEMAS SELECT V0SEGURAVG' */
                _.Display($"R1320-00 - PROBLEMAS SELECT V0SEGURAVG");

                /*" -3718- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3723- PERFORM R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1 */

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1();

            /*" -3726- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3727- DISPLAY 'R1320-00 - PROBLEMAS UPDATE V0SEGURAVG' */
                _.Display($"R1320-00 - PROBLEMAS UPDATE V0SEGURAVG");

                /*" -3730- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3737- PERFORM R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2 */

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2();

            /*" -3740- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3741- DISPLAY 'R1320-00 - PROBLEMAS UPDATE V0COBERAPOL' */
                _.Display($"R1320-00 - PROBLEMAS UPDATE V0COBERAPOL");

                /*" -3744- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3750- PERFORM R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3 */

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3();

            /*" -3753- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3754- DISPLAY 'R1320-00 - PROBLEMAS UPDATE V0HISTSEGVG' */
                _.Display($"R1320-00 - PROBLEMAS UPDATE V0HISTSEGVG");

                /*" -3757- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3762- PERFORM R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4 */

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4();

            /*" -3765- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3766- DISPLAY 'R1320-00 - PROBLEMAS UPDATE V0MOVIMENTO' */
                _.Display($"R1320-00 - PROBLEMAS UPDATE V0MOVIMENTO");

                /*" -3766- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1320-00-AJUSTA-VIGENCIA-DB-SELECT-1 */
        public void R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1()
        {
            /*" -3711- EXEC SQL SELECT NUM_ITEM INTO :V0SEGU-NUM-ITEM FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0HCOB-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 = new R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1.Execute(r1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGU_NUM_ITEM, V0SEGU_NUM_ITEM);
            }


        }

        [StopWatch]
        /*" R1320-00-AJUSTA-VIGENCIA-DB-UPDATE-1 */
        public void R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1()
        {
            /*" -3723- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET DATA_INIVIGENCIA = :V0MOVC-DTQITBCO WHERE NUM_CERTIFICADO = :V0HCOB-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1_Update1 = new R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1_Update1()
            {
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1_Update1.Execute(r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-AJUSTA-VIGENCIA-DB-UPDATE-2 */
        public void R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2()
        {
            /*" -3737- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET DATA_INIVIGENCIA = :V0MOVC-DTQITBCO WHERE NUM_APOLICE = 109700000028 AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-NUM-ITEM AND OCORHIST = 1 END-EXEC. */

            var r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1 = new R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1()
            {
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                V0SEGU_NUM_ITEM = V0SEGU_NUM_ITEM.ToString(),
            };

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1.Execute(r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3777- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -3778- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -3779- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -3780- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -3782- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -3782- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3786- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3786- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R1320-00-AJUSTA-VIGENCIA-DB-UPDATE-3 */
        public void R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3()
        {
            /*" -3750- EXEC SQL UPDATE SEGUROS.V0HISTSEGVG SET DATA_MOVIMENTO = :V0MOVC-DTQITBCO WHERE NUM_APOLICE = 109700000028 AND NUM_ITEM = :V0SEGU-NUM-ITEM AND OCORR_HISTORICO = 1 END-EXEC. */

            var r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3_Update1 = new R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3_Update1()
            {
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                V0SEGU_NUM_ITEM = V0SEGU_NUM_ITEM.ToString(),
            };

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3_Update1.Execute(r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1320-00-AJUSTA-VIGENCIA-DB-UPDATE-4 */
        public void R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4()
        {
            /*" -3762- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_MOVIMENTO = :V0MOVC-DTQITBCO WHERE NUM_CERTIFICADO = :V0HCOB-NRCERTIF AND COD_OPERACAO = 102 END-EXEC. */

            var r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4_Update1 = new R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4_Update1()
            {
                V0MOVC_DTQITBCO = V0MOVC_DTQITBCO.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4_Update1.Execute(r1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4_Update1);

        }
    }
}