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
using Sias.FederalVida.DB2.VF0851B;

namespace Code
{
    public class VF0851B
    {
        public bool IsCall { get; set; }

        public VF0851B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FEDERAL VIDA                       *      */
        /*"      *   PROGRAMA ...............  VF0851B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  16/09/1998                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA A COBRANCA EM ATRASO          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 06 - CAD 87.342                                       *      */
        /*"      *                                                                *      */
        /*"      *              - NAO PERMITIR QUE GERE REPETIDAS VEZES NOVAS     *      */
        /*"      *                PARCELAS PARA A MESMA PARCELA EM ATRASO.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2013 -  FRANK CARVALHO (INDRA COMPANY)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *             - CAD 201.122                                      *      */
        /*"      *               AJUSTA INSERT DA TABELA HIST_LANC_CTA            *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2011 - LOPES                                        *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *             - CAD 35.547                                       *      */
        /*"      *               TRATAMENTO DO SQLCODE -803 NO INSERT DA TABELA   *      */
        /*"      *               SEGUROS.V0HISTREPSAF.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/01/2010 - TERCIO FREITAS                               *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02     22/09/2008  FAST COMPUTER                      *      */
        /*"      *   CAD-14573                 ALTERADO PARA NAO ABENDAR          *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE V.02       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01     25/08/2006  FAST COMPUTER                      *      */
        /*"      *                             ALTERADO PARA NAO ABENDAR          *      */
        /*"      *                             QUANDO NAO ENCONTRAR NA            *      */
        /*"      *                             V0COMPTITVA E V0HISTOBVA           *      */
        /*"      *                                             PROCURE V.01       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   16/09/1998                ESTE PROGRAMA EH UMA VERSAO DO     *      */
        /*"      *                             VA0851B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * CONVENIOS SICOV                     V0CONVSICOV       INPUT    *      */
        /*"      * PLANO DE COMISSAO DA PROPOSTA VF    V0PLANCOMISVF     INPUT    *      */
        /*"      * COBERTURAS DE APOLICE               V0COBERAPOL       INPUT    *      */
        /*"      * OPCOES DE PAGAMENTO VA              V0OPCAOPAGVA      INPUT    *      */
        /*"      * CONTROLE DE FATURAS                 V0FATURCONT       INPUT    *      */
        /*"      * SEGURADOS VG/APC                    V0SEGURAVG        INPUT    *      */
        /*"      * COBERTURAS SAF                      V0SAFCOBER        INPUT    *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       I-O      *      */
        /*"      * PROPOSTAS VA                        V0PROPOSTAVA      I-O      *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     I-O      *      */
        /*"      * DIFERENCAS DE PARCELAS              V0DIFPARCELVA     I-O      *      */
        /*"      * FONTES                              V0FONTE           I-O      *      */
        /*"      * HISTORICO REPASSE SAF               V0HISTREPSAF      I-O      *      */
        /*"      * PRODUTOR VF                         V0PRODUTORVF      I-O      *      */
        /*"      * COMPOSICAO DE TITULOS VA            V0COMPTITVA       I-O      *      */
        /*"      * RELATORIOS                          V0RELATORIOS      OUTPUT   *      */
        /*"      * EVENTOS VF                          V0EVENTOSVF       OUTPUT   *      */
        /*"      * MOVIMENTO VG/APC                    V0MOVIMENTO       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DTMOVTO          PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRPARCEL        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-VLPREMIO        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG           PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP           PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WS-NULL1              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCORMAISQD  PIC  X(010).*/
        public StringBasis V1SIST_DTCORMAISQD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCORMENOQD  PIC  X(010).*/
        public StringBasis V1SIST_DTCORMENOQD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCORRENTE   PIC  X(010).*/
        public StringBasis V1SIST_DTCORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CEDE-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0CEDE_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BANC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HCOB-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0HCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCOB-CODOPER      PIC S9(004) COMP.*/
        public IntBasis V0HCOB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCOB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HCOB-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HCOB-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HCTA-NSAS         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CODCONV      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRCERTIF     PIC S9(015) COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PROP-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0OPCP-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-AGECTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPRCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-NUMCTADEB    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0OPCP-DIGCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-IAGECTADEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_IAGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-IOPRCTADEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_IOPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INUMCTADEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-IDIGCTADEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_IDIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-PRMVG        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PRMAP        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0SEGU-TPINCLUS     PIC  X(001).*/
        public StringBasis V0SEGU_TPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SEGU-AGENCIADOR   PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGU_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGU-ITEM         PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGU_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGU-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0SEGU_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATC-DTREF        PIC  X(010).*/
        public StringBasis V0FATC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMTOTANT    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PARC_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-NRPARCELDIF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCELDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0DIFP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-SITUACAO     PIC  X(010).*/
        public StringBasis V0DIFP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RSAF-DTREFER      PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-SITUACAO     PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0SAFC-VLCUSTSAF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0FONT-PROPAUTOM    PIC S9(009)      COMP.*/
        public IntBasis V0FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MOVI-DTMOVTO      PIC  X(010).*/
        public StringBasis V0MOVI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0RELA-QTDPARATZ    PIC S9(004) COMP.*/
        public IntBasis V0RELA_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PLAC-CODPDT       PIC S9(009) COMP.*/
        public IntBasis V0PLAC_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PDVF-OCORHIST     PIC S9(004) COMP.*/
        public IntBasis V0PDVF_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COMP-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0COMP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COMP-CODOPER      PIC S9(004) COMP.*/
        public IntBasis V0COMP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COMP-PRMDIFVG     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COMP-PRMDIFAP     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0EVEN-NRCERTIF     PIC S9(015) COMP-3.*/
        public IntBasis V0EVEN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0EVEN-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0EVEN_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EVEN-CODOPER      PIC S9(004) COMP.*/
        public IntBasis V0EVEN_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EVEN-CODEVEN      PIC S9(004) COMP.*/
        public IntBasis V0EVEN_CODEVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EVEN-DTVENCTO     PIC  X(010).*/
        public StringBasis V0EVEN_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0EVEN-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0EVEN_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0EVEN-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0EVEN_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VF0851B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VF0851B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VF0851B_FILLER_0(); _.Move(W_NUMR_TITULO, _filler_0); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_0, W_NUMR_TITULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUMR_TITULO); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VF0851B_FILLER_0 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_VF0851B_FILLER_0()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VF0851B_DPARM01X DPARM01X { get; set; } = new VF0851B_DPARM01X();
        public class VF0851B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VF0851B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VF0851B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VF0851B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VF0851B_DPARM01_R : VarBasis
            {
                /*"    10          DPARM01-1         PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-2         PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-3         PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-4         PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-5         PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-6         PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-7         PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-8         PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-9         PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-10        PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05            DPARM01-D1        PIC  9(001).*/

                public _REDEF_VF0851B_DPARM01_R()
                {
                    DPARM01_1.ValueChanged += OnValueChanged;
                    DPARM01_2.ValueChanged += OnValueChanged;
                    DPARM01_3.ValueChanged += OnValueChanged;
                    DPARM01_4.ValueChanged += OnValueChanged;
                    DPARM01_5.ValueChanged += OnValueChanged;
                    DPARM01_6.ValueChanged += OnValueChanged;
                    DPARM01_7.ValueChanged += OnValueChanged;
                    DPARM01_8.ValueChanged += OnValueChanged;
                    DPARM01_9.ValueChanged += OnValueChanged;
                    DPARM01_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01           AREA-DE-WORK.*/
        }
        public VF0851B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VF0851B_AREA_DE_WORK();
        public class VF0851B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-CPROPVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CPARCEL    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CPARDIF    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPARDIF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CPLACOM    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPLACOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDATA-SISTEMA.*/
            public VF0851B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VF0851B_WDATA_SISTEMA();
            public class VF0851B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-CONT-ATZ      PIC 9(002).*/
            }
            public IntBasis WS_CONT_ATZ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05          WS-I-PARC        PIC 9(002).*/
            public IntBasis WS_I_PARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05          TAB-PARCELAS-ATRASO.*/
            public VF0851B_TAB_PARCELAS_ATRASO TAB_PARCELAS_ATRASO { get; set; } = new VF0851B_TAB_PARCELAS_ATRASO();
            public class VF0851B_TAB_PARCELAS_ATRASO : VarBasis
            {
                /*"    10        TAB-PARCELAS-ATR OCCURS 20.*/
                public ListBasis<VF0851B_TAB_PARCELAS_ATR> TAB_PARCELAS_ATR { get; set; } = new ListBasis<VF0851B_TAB_PARCELAS_ATR>(20);
                public class VF0851B_TAB_PARCELAS_ATR : VarBasis
                {
                    /*"      15      TAB-NRPARCEL     PIC S9(004) COMP.*/
                    public IntBasis TAB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      15      TAB-OCORHIST     PIC S9(004) COMP.*/
                    public IntBasis TAB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      15      TAB-NRTIT        PIC S9(013) COMP-3.*/
                    public IntBasis TAB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                    /*"      15      TAB-DTVENCTO     PIC  X(010).*/
                    public StringBasis TAB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"      15      TAB-DTPROXVEN    PIC  X(010).*/
                    public StringBasis TAB_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"      15      TAB-PRMVG        PIC S9(013)V99 COMP-3.*/
                    public DoubleBasis TAB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      15      TAB-PRMAP        PIC S9(013)V99 COMP-3.*/
                    public DoubleBasis TAB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      15      TAB-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
                    public DoubleBasis TAB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"  05        WABEND.*/
                }
            }
            public VF0851B_WABEND WABEND { get; set; } = new VF0851B_WABEND();
            public class VF0851B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VF0851B '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VF0851B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public VF0851B_CPROPVA CPROPVA { get; set; } = new VF0851B_CPROPVA();
        public VF0851B_CPARCEL CPARCEL { get; set; } = new VF0851B_CPARCEL();
        public VF0851B_CDIFPAR CDIFPAR { get; set; } = new VF0851B_CDIFPAR();
        public VF0851B_CPARDIF CPARDIF { get; set; } = new VF0851B_CPARDIF();
        public VF0851B_CPLACOM CPLACOM { get; set; } = new VF0851B_CPLACOM();
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
            /*" -392- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -395- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -398- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -402- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -403- DISPLAY 'PROGRAMA EM EXECUCAO VF0851B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VF0851B   ");

            /*" -404- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -407- DISPLAY 'VERSAO V.07 103.659 04/12/2014 ' . */
            _.Display($"VERSAO V.07 103.659 04/12/2014 ");

            /*" -408- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -412- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -414- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -425- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -428- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -429- DISPLAY 'ERRO SELECT V1SISTEMA VF' */
                _.Display($"ERRO SELECT V1SISTEMA VF");

                /*" -431- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -449- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -454- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -457- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -458- DISPLAY 'BANCO NAO CADASTRADO (V0BANCO) 104 ' */
                _.Display($"BANCO NAO CADASTRADO (V0BANCO) 104 ");

                /*" -460- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -461- MOVE V0BANC-NRTIT TO W-NUMR-TITULO. */
            _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

            /*" -462- DISPLAY ' ' */
            _.Display($" ");

            /*" -463- DISPLAY 'NUMERO BANCO TITULO <' W-NUMR-TITULO '>' */

            $"NUMERO BANCO TITULO <{W_NUMR_TITULO}>"
            .Display();

            /*" -465- DISPLAY ' ' */
            _.Display($" ");

            /*" -482- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -486- DISPLAY '*** VF0851B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VF0851B *** ABRINDO CURSOR ...");

            /*" -487- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -487- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -490- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -491- DISPLAY 'PROBLEMAS NO OPEN (CPROPVA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVA   ) ... ");

                /*" -493- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -495- DISPLAY '*** VF0851B *** PROCESSANDO ... ' . */
            _.Display($"*** VF0851B *** PROCESSANDO ... ");

            /*" -497- PERFORM R1010-00-FETCH-V0PROPOSTAVA. */

            R1010_00_FETCH_V0PROPOSTAVA_SECTION();

            /*" -498- IF WFIM-CPROPVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty())
            {

                /*" -500- DISPLAY '*** VF0851B *** NENHUM SEGURO A PROCESSAR' */
                _.Display($"*** VF0851B *** NENHUM SEGURO A PROCESSAR");

                /*" -502- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -505- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CPROPVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -518- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -523- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_1 */

            R0000_00_PRINCIPAL_DB_UPDATE_1();

            /*" -526- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -527- DISPLAY 'R0000 - ERRO UPDATE V0BANCO 104' */
                _.Display($"R0000 - ERRO UPDATE V0BANCO 104");

                /*" -530- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -531- DISPLAY 'PROPOSTAS LIDAS ............ ' WACC-LIDOS. */
            _.Display($"PROPOSTAS LIDAS ............ {AREA_DE_WORK.WACC_LIDOS}");

            /*" -533- DISPLAY 'PARCELAS GERADAS ........... ' WACC-GRAVADOS. */
            _.Display($"PARCELAS GERADAS ........... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -535- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -535- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -425- EXEC SQL SELECT CURRENT DATE, CURRENT DATE + 15 DAYS, CURRENT DATE - 15 DAYS, DTMOVABE INTO :V1SIST-DTCORRENTE, :V1SIST-DTCORMAISQD, :V1SIST-DTCORMENOQD, :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VF' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTCORRENTE, V1SIST_DTCORRENTE);
                _.Move(executed_1.V1SIST_DTCORMAISQD, V1SIST_DTCORMAISQD);
                _.Move(executed_1.V1SIST_DTCORMENOQD, V1SIST_DTCORMENOQD);
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -541- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -542- DISPLAY ' ' */
            _.Display($" ");

            /*" -544- DISPLAY '*--------  VF0851B - FIM NORMAL  --------*' */
            _.Display($"*--------  VF0851B - FIM NORMAL  --------*");

            /*" -544- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -482- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT B.NRCERTIF, B.CODPRODU, B.SITUACAO, B.FONTE, B.NUM_APOLICE, B.CODSUBES, B.CODCLIEN FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B WHERE A.ESTR_COBR = 'FEDERAL' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.SITUACAO IN ( '3' , '6' ) ORDER BY B.NRCERTIF END-EXEC. */
            CPROPVA = new VF0851B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT B.NRCERTIF
							, 
							B.CODPRODU
							, 
							B.SITUACAO
							, 
							B.FONTE
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.CODCLIEN 
							FROM SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B 
							WHERE A.ESTR_COBR = 'FEDERAL' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.SITUACAO IN ( '3'
							, '6' ) 
							ORDER BY 
							B.NRCERTIF";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -487- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-DECLARE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1()
        {
            /*" -591- EXEC SQL DECLARE CPARCEL CURSOR FOR SELECT NRPARCEL, PRMVG, PRMAP, PRMVG + PRMAP, OCORHIST, DTVENCTO + 1 MONTH, DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND SITUACAO = ' ' AND DTVENCTO <= :V1SIST-DTCORMENOQD ORDER BY 1 END-EXEC. */
            CPARCEL = new VF0851B_CPARCEL(true);
            string GetQuery_CPARCEL()
            {
                var query = @$"SELECT NRPARCEL
							, 
							PRMVG
							, 
							PRMAP
							, 
							PRMVG + PRMAP
							, 
							OCORHIST
							, 
							DTVENCTO + 1 MONTH
							, 
							DTVENCTO 
							FROM SEGUROS.V0PARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND SITUACAO = ' ' 
							AND DTVENCTO <= '{V1SIST_DTCORMENOQD}' 
							ORDER BY 1";

                return query;
            }
            CPARCEL.GetQueryEvent += GetQuery_CPARCEL;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-1 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -523- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_UPDATE_1_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_1_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -454- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -552- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

            /*" -554- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -570- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -575- DISPLAY 'R1000-00 (ERRO - SELECT V0OPCAOPAGVA)' */
                _.Display($"R1000-00 (ERRO - SELECT V0OPCAOPAGVA)");

                /*" -577- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -591- PERFORM R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1();

            /*" -593- PERFORM R1000_00_PROCESSA_REGISTRO_DB_OPEN_1 */

            R1000_00_PROCESSA_REGISTRO_DB_OPEN_1();

            /*" -596- MOVE SPACES TO WFIM-CPARCEL. */
            _.Move("", AREA_DE_WORK.WFIM_CPARCEL);

            /*" -598- PERFORM R1110-00-FETCH-V0PARCELVA. */

            R1110_00_FETCH_V0PARCELVA_SECTION();

            /*" -600- MOVE 0 TO WS-CONT-ATZ. */
            _.Move(0, AREA_DE_WORK.WS_CONT_ATZ);

            /*" -602- INITIALIZE TAB-PARCELAS-ATRASO. */
            _.Initialize(
                AREA_DE_WORK.TAB_PARCELAS_ATRASO
            );

            /*" -605- PERFORM R1100-00-ACUMULA-ATRASO UNTIL WFIM-CPARCEL NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CPARCEL.IsEmpty()))
            {

                R1100_00_ACUMULA_ATRASO_SECTION();
            }

            /*" -607- IF WS-CONT-ATZ GREATER 0 */

            if (AREA_DE_WORK.WS_CONT_ATZ > 0)
            {

                /*" -609- IF V0PROP-SITUACAO EQUAL '3' AND TAB-NRPARCEL (1) EQUAL 1 */

                if (V0PROP_SITUACAO == "3" && AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[1].TAB_NRPARCEL == 1)
                {

                    /*" -610- PERFORM R1200-00-CANCELA-NAO-ACEITACAO */

                    R1200_00_CANCELA_NAO_ACEITACAO_SECTION();

                    /*" -611- ELSE */
                }
                else
                {


                    /*" -612- IF WS-CONT-ATZ NOT LESS 3 */

                    if (AREA_DE_WORK.WS_CONT_ATZ >= 3)
                    {

                        /*" -613- PERFORM R1300-00-CANCELA-FALTA-PG */

                        R1300_00_CANCELA_FALTA_PG_SECTION();

                        /*" -614- ELSE */
                    }
                    else
                    {


                        /*" -616- PERFORM R1400-00-EMITE-AVISO-ATRASO. */

                        R1400_00_EMITE_AVISO_ATRASO_SECTION();
                    }

                }

            }


            /*" -616- PERFORM R1010-00-FETCH-V0PROPOSTAVA. */

            R1010_00_FETCH_V0PROPOSTAVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -570- EXEC SQL SELECT PERIPGTO, OPCAOPAG, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB INTO :V0OPCP-PERIPGTO, :V0OPCP-OPCAOPAG, :V0OPCP-AGECTADEB:V0OPCP-IAGECTADEB, :V0OPCP-OPRCTADEB:V0OPCP-IOPRCTADEB, :V0OPCP-NUMCTADEB:V0OPCP-INUMCTADEB, :V0OPCP-DIGCTADEB:V0OPCP-IDIGCTADEB FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_IAGECTADEB, V0OPCP_IAGECTADEB);
                _.Move(executed_1.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_IOPRCTADEB, V0OPCP_IOPRCTADEB);
                _.Move(executed_1.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_INUMCTADEB, V0OPCP_INUMCTADEB);
                _.Move(executed_1.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0OPCP_IDIGCTADEB, V0OPCP_IDIGCTADEB);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-OPEN-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_OPEN_1()
        {
            /*" -593- EXEC SQL OPEN CPARCEL END-EXEC. */

            CPARCEL.Open();

        }

        [StopWatch]
        /*" R1500-00-COMPOE-DIFERENCAS-DB-DECLARE-1 */
        public void R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1()
        {
            /*" -1388- EXEC SQL DECLARE CDIFPAR CURSOR FOR SELECT NRPARCELDIF, CODOPER, PRMDIFVG, PRMDIFAP FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND SITUACAO = ' ' END-EXEC. */
            CDIFPAR = new VF0851B_CDIFPAR(true);
            string GetQuery_CDIFPAR()
            {
                var query = @$"SELECT NRPARCELDIF
							, 
							CODOPER
							, 
							PRMDIFVG
							, 
							PRMDIFAP 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND SITUACAO = ' '";

                return query;
            }
            CDIFPAR.GetQueryEvent += GetQuery_CDIFPAR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-FETCH-V0PROPOSTAVA-SECTION */
        private void R1010_00_FETCH_V0PROPOSTAVA_SECTION()
        {
            /*" -627- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -635- PERFORM R1010_00_FETCH_V0PROPOSTAVA_DB_FETCH_1 */

            R1010_00_FETCH_V0PROPOSTAVA_DB_FETCH_1();

            /*" -638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -639- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -639- PERFORM R1010_00_FETCH_V0PROPOSTAVA_DB_CLOSE_1 */

                    R1010_00_FETCH_V0PROPOSTAVA_DB_CLOSE_1();

                    /*" -641- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -642- ELSE */
                }
                else
                {


                    /*" -643- DISPLAY 'R1010-00 (ERRO -  FETCH CPROPVA   )...' */
                    _.Display($"R1010-00 (ERRO -  FETCH CPROPVA   )...");

                    /*" -643- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1010-00-FETCH-V0PROPOSTAVA-DB-FETCH-1 */
        public void R1010_00_FETCH_V0PROPOSTAVA_DB_FETCH_1()
        {
            /*" -635- EXEC SQL FETCH CPROPVA INTO :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-SITUACAO, :V0PROP-FONTE, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-CODCLIEN END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVA.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(CPROPVA.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPVA.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
            }

        }

        [StopWatch]
        /*" R1010-00-FETCH-V0PROPOSTAVA-DB-CLOSE-1 */
        public void R1010_00_FETCH_V0PROPOSTAVA_DB_CLOSE_1()
        {
            /*" -639- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-ACUMULA-ATRASO-SECTION */
        private void R1100_00_ACUMULA_ATRASO_SECTION()
        {
            /*" -654- MOVE '1101' TO WNR-EXEC-SQL. */
            _.Move("1101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -663- PERFORM R1100_00_ACUMULA_ATRASO_DB_SELECT_1 */

            R1100_00_ACUMULA_ATRASO_DB_SELECT_1();

            /*" -666- IF V0DIFP-VLPRMTOT NOT LESS V0PARC-VLPRMTOT */

            if (V0DIFP_VLPRMTOT >= V0PARC_VLPRMTOT)
            {

                /*" -667- PERFORM R1700-00-QUITA-ATRASADA */

                R1700_00_QUITA_ATRASADA_SECTION();

                /*" -669- GO TO R1100-00-LEITURA. */

                R1100_00_LEITURA(); //GOTO
                return;
            }


            /*" -671- MOVE '1102' TO WNR-EXEC-SQL. */
            _.Move("1102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -679- PERFORM R1100_00_ACUMULA_ATRASO_DB_SELECT_2 */

            R1100_00_ACUMULA_ATRASO_DB_SELECT_2();

            /*" -692- IF V0HCOB-NRTIT EQUAL 0 */

            if (V0HCOB_NRTIT == 0)
            {

                /*" -693- GO TO R1100-00-LEITURA */

                R1100_00_LEITURA(); //GOTO
                return;

                /*" -695- END-IF. */
            }


            /*" -697- MOVE '1103' TO WNR-EXEC-SQL. */
            _.Move("1103", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -703- PERFORM R1100_00_ACUMULA_ATRASO_DB_SELECT_3 */

            R1100_00_ACUMULA_ATRASO_DB_SELECT_3();

            /*" -706- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -709- DISPLAY 'R1100-00 (ERRO SELECT V0HISTCOBVA) ' */
                _.Display($"R1100-00 (ERRO SELECT V0HISTCOBVA) ");

                /*" -710- DISPLAY 'NRTIT       ' V0HCOB-NRTIT */
                _.Display($"NRTIT       {V0HCOB_NRTIT}");

                /*" -712- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -713- IF V0HCOB-DTVENCTO GREATER V1SIST-DTCORMENOQD */

            if (V0HCOB_DTVENCTO > V1SIST_DTCORMENOQD)
            {

                /*" -725- GO TO R1100-00-LEITURA. */

                R1100_00_LEITURA(); //GOTO
                return;
            }


            /*" -726- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -727- MOVE '1100' TO WNR-EXEC-SQL */
                _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -737- PERFORM R1100_00_ACUMULA_ATRASO_DB_SELECT_4 */

                R1100_00_ACUMULA_ATRASO_DB_SELECT_4();

                /*" -743- IF SQLCODE EQUAL 0 */

                if (DB.SQLCODE == 0)
                {

                    /*" -745- GO TO R1100-00-LEITURA. */

                    R1100_00_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -747- ADD 1 TO WS-CONT-ATZ. */
            AREA_DE_WORK.WS_CONT_ATZ.Value = AREA_DE_WORK.WS_CONT_ATZ + 1;

            /*" -748- MOVE V0PARC-NRPARCEL TO TAB-NRPARCEL(WS-CONT-ATZ). */
            _.Move(V0PARC_NRPARCEL, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_NRPARCEL);

            /*" -749- MOVE V0PARC-DTVENCTO TO TAB-DTVENCTO(WS-CONT-ATZ). */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_DTVENCTO);

            /*" -750- MOVE V0PARC-PRMVG TO TAB-PRMVG(WS-CONT-ATZ). */
            _.Move(V0PARC_PRMVG, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_PRMVG);

            /*" -751- MOVE V0PARC-PRMAP TO TAB-PRMAP(WS-CONT-ATZ). */
            _.Move(V0PARC_PRMAP, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_PRMAP);

            /*" -752- MOVE V0PARC-VLPRMTOT TO TAB-VLPRMTOT(WS-CONT-ATZ). */
            _.Move(V0PARC_VLPRMTOT, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_VLPRMTOT);

            /*" -753- MOVE V0PARC-OCORHIST TO TAB-OCORHIST(WS-CONT-ATZ). */
            _.Move(V0PARC_OCORHIST, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_OCORHIST);

            /*" -754- MOVE V0PARC-DTPROXVEN TO TAB-DTPROXVEN(WS-CONT-ATZ). */
            _.Move(V0PARC_DTPROXVEN, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_DTPROXVEN);

            /*" -755- MOVE V0PARC-DTVENCTO TO TAB-DTVENCTO(WS-CONT-ATZ). */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_DTVENCTO);

            /*" -755- MOVE V0HCOB-NRTIT TO TAB-NRTIT(WS-CONT-ATZ). */
            _.Move(V0HCOB_NRTIT, AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_NRTIT);

            /*" -0- FLUXCONTROL_PERFORM R1100_00_LEITURA */

            R1100_00_LEITURA();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-ATRASO-DB-SELECT-1 */
        public void R1100_00_ACUMULA_ATRASO_DB_SELECT_1()
        {
            /*" -663- EXEC SQL SELECT VALUE(SUM(PRMDIFVG+PRMDIFAP),0) INTO :V0DIFP-VLPRMTOT FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = 9999 AND SITUACAO = ' ' AND CODOPER >= 600 AND CODOPER <= 699 END-EXEC. */

            var r1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1 = new R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1.Execute(r1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0DIFP_VLPRMTOT, V0DIFP_VLPRMTOT);
            }


        }

        [StopWatch]
        /*" R1100-00-LEITURA */
        private void R1100_00_LEITURA(bool isPerform = false)
        {
            /*" -759- PERFORM R1110-00-FETCH-V0PARCELVA. */

            R1110_00_FETCH_V0PARCELVA_SECTION();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-ATRASO-DB-SELECT-2 */
        public void R1100_00_ACUMULA_ATRASO_DB_SELECT_2()
        {
            /*" -679- EXEC SQL SELECT VALUE(MAX(B.NRTIT),0) INTO :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0COMPTITVA B WHERE A.NRCERTIF = :V0PROP-NRCERTIF AND B.NRTIT = A.NRTIT AND B.NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1 = new R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1.Execute(r1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-ACUMULA-ATRASO-DB-SELECT-3 */
        public void R1100_00_ACUMULA_ATRASO_DB_SELECT_3()
        {
            /*" -703- EXEC SQL SELECT DTVENCTO INTO :V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var r1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1 = new R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            var executed_1 = R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1.Execute(r1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-V0PARCELVA-SECTION */
        private void R1110_00_FETCH_V0PARCELVA_SECTION()
        {
            /*" -770- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -778- PERFORM R1110_00_FETCH_V0PARCELVA_DB_FETCH_1 */

            R1110_00_FETCH_V0PARCELVA_DB_FETCH_1();

            /*" -781- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -782- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -782- PERFORM R1110_00_FETCH_V0PARCELVA_DB_CLOSE_1 */

                    R1110_00_FETCH_V0PARCELVA_DB_CLOSE_1();

                    /*" -784- MOVE 'S' TO WFIM-CPARCEL */
                    _.Move("S", AREA_DE_WORK.WFIM_CPARCEL);

                    /*" -785- ELSE */
                }
                else
                {


                    /*" -786- DISPLAY 'R1110-00 (ERRO -  FETCH CPARCEL   )...' */
                    _.Display($"R1110-00 (ERRO -  FETCH CPARCEL   )...");

                    /*" -786- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-V0PARCELVA-DB-FETCH-1 */
        public void R1110_00_FETCH_V0PARCELVA_DB_FETCH_1()
        {
            /*" -778- EXEC SQL FETCH CPARCEL INTO :V0PARC-NRPARCEL, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-VLPRMTOT, :V0PARC-OCORHIST, :V0PARC-DTPROXVEN, :V0PARC-DTVENCTO END-EXEC. */

            if (CPARCEL.Fetch())
            {
                _.Move(CPARCEL.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(CPARCEL.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(CPARCEL.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(CPARCEL.V0PARC_VLPRMTOT, V0PARC_VLPRMTOT);
                _.Move(CPARCEL.V0PARC_OCORHIST, V0PARC_OCORHIST);
                _.Move(CPARCEL.V0PARC_DTPROXVEN, V0PARC_DTPROXVEN);
                _.Move(CPARCEL.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-V0PARCELVA-DB-CLOSE-1 */
        public void R1110_00_FETCH_V0PARCELVA_DB_CLOSE_1()
        {
            /*" -782- EXEC SQL CLOSE CPARCEL END-EXEC */

            CPARCEL.Close();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-ATRASO-DB-SELECT-4 */
        public void R1100_00_ACUMULA_ATRASO_DB_SELECT_4()
        {
            /*" -737- EXEC SQL SELECT NSAS INTO :V0HCTA-NSAS:WS-NULL1 FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND SITUACAO IN ( '0' , '3' ) FETCH FIRST 1 ROW ONLY END-EXEC */

            var r1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1 = new R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1.Execute(r1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(executed_1.WS_NULL1, WS_NULL1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CANCELA-NAO-ACEITACAO-SECTION */
        private void R1200_00_CANCELA_NAO_ACEITACAO_SECTION()
        {
            /*" -799- MOVE '1201' TO WNR-EXEC-SQL. */
            _.Move("1201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -806- PERFORM R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1 */

            R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1();

            /*" -809- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -814- MOVE V0PROP-NRCERTIF TO V0EVEN-NRCERTIF. */
            _.Move(V0PROP_NRCERTIF, V0EVEN_NRCERTIF);

            /*" -815- MOVE TAB-NRPARCEL(1) TO V0EVEN-NRPARCEL */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[1].TAB_NRPARCEL, V0EVEN_NRPARCEL);

            /*" -816- MOVE TAB-DTVENCTO(1) TO V0EVEN-DTVENCTO. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[1].TAB_DTVENCTO, V0EVEN_DTVENCTO);

            /*" -818- MOVE TAB-VLPRMTOT(1) TO V0EVEN-VLPRMTOT. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[1].TAB_VLPRMTOT, V0EVEN_VLPRMTOT);

            /*" -819- MOVE 4 TO V0EVEN-CODEVEN. */
            _.Move(4, V0EVEN_CODEVEN);

            /*" -821- MOVE 403 TO V0EVEN-CODOPER. */
            _.Move(403, V0EVEN_CODOPER);

            /*" -823- PERFORM R2000-00-GERA-EVENTO. */

            R2000_00_GERA_EVENTO_SECTION();

            /*" -825- MOVE TAB-NRTIT(1) TO V0HCOB-NRTIT. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[1].TAB_NRTIT, V0HCOB_NRTIT);

            /*" -827- MOVE '1202' TO WNR-EXEC-SQL. */
            _.Move("1202", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -834- PERFORM R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2 */

            R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2();

            /*" -837- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -838- DISPLAY 'R1200-00 (UPDATE V0HISTCOBVA) ' */
                _.Display($"R1200-00 (UPDATE V0HISTCOBVA) ");

                /*" -841- DISPLAY 'CERTIF ' V0PROP-NRCERTIF ' PARC ' V0EVEN-NRPARCEL ' TIT  ' V0HCOB-NRTIT */

                $"CERTIF {V0PROP_NRCERTIF} PARC {V0EVEN_NRPARCEL} TIT  {V0HCOB_NRTIT}"
                .Display();

                /*" -841- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-CANCELA-NAO-ACEITACAO-DB-UPDATE-1 */
        public void R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1()
        {
            /*" -806- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '4' , CODOPER = 403, DTMOVTO = DTQITBCO, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF END-EXEC. */

            var r1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1 = new R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1.Execute(r1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CANCELA-NAO-ACEITACAO-DB-UPDATE-2 */
        public void R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2()
        {
            /*" -834- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '5' , CODOPER = 138 WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0EVEN-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var r1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1 = new R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0EVEN_NRPARCEL = V0EVEN_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1.Execute(r1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-SECTION */
        private void R1300_00_CANCELA_FALTA_PG_SECTION()
        {
            /*" -857- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -863- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_1 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_1();

            /*" -866- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -868- DISPLAY 'R1300-00 (ERRO - SELECT V0PARCELVA)' */
                _.Display($"R1300-00 (ERRO - SELECT V0PARCELVA)");

                /*" -870- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -872- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -878- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_2 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_2();

            /*" -881- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -883- DISPLAY 'R1300-00 (ERRO - SELECT V0PARCELVA)' */
                _.Display($"R1300-00 (ERRO - SELECT V0PARCELVA)");

                /*" -887- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -889- MOVE '1308' TO WNR-EXEC-SQL. */
            _.Move("1308", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -896- PERFORM R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1 */

            R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1();

            /*" -899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -901- DISPLAY 'R1300-00 (ERRO - UPDATE V0PROPOSTAVA)' */
                _.Display($"R1300-00 (ERRO - UPDATE V0PROPOSTAVA)");

                /*" -905- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -907- MOVE '1314' TO WNR-EXEC-SQL. */
            _.Move("1314", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -913- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_3 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_3();

            /*" -916- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -917- MOVE '1315' TO WNR-EXEC-SQL */
                _.Move("1315", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -923- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_4 */

                R1300_00_CANCELA_FALTA_PG_DB_SELECT_4();

                /*" -925- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -927- DISPLAY 'R1300-00 (ERRO - SELECT V0FATURCONT)' */
                    _.Display($"R1300-00 (ERRO - SELECT V0FATURCONT)");

                    /*" -931- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -933- MOVE '1316' TO WNR-EXEC-SQL. */
            _.Move("1316", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -945- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_5 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_5();

            /*" -948- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -950- DISPLAY 'R1300-00 (ERRO - SELECT V0SEGURAVG)' */
                _.Display($"R1300-00 (ERRO - SELECT V0SEGURAVG)");

                /*" -954- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -956- MOVE '1317' TO WNR-EXEC-SQL. */
            _.Move("1317", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -969- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_6 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_6();

            /*" -972- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -974- DISPLAY 'R1300-00 (ERRO - SELECT V0COBERAPOL)' */
                _.Display($"R1300-00 (ERRO - SELECT V0COBERAPOL)");

                /*" -976- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -978- MOVE '1318' TO WNR-EXEC-SQL. */
            _.Move("1318", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -991- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_7 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_7();

            /*" -994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -997- MOVE 0 TO V0COBA-IMPMORACID V0COBA-PRMAP. */
                _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);
            }


            /*" -999- MOVE '1319' TO WNR-EXEC-SQL. */
            _.Move("1319", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1010- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_8 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_8();

            /*" -1013- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1015- MOVE 0 TO V0COBA-IMPINVPERM. */
                _.Move(0, V0COBA_IMPINVPERM);
            }


            /*" -1017- MOVE '1320' TO WNR-EXEC-SQL. */
            _.Move("1320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1028- PERFORM R1300_00_CANCELA_FALTA_PG_DB_SELECT_9 */

            R1300_00_CANCELA_FALTA_PG_DB_SELECT_9();

            /*" -1031- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1031- MOVE 0 TO V0COBA-IMPDIT. */
                _.Move(0, V0COBA_IMPDIT);
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_20_LOOP_PROPOSTA */

            R1300_20_LOOP_PROPOSTA();

        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-1 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_1()
        {
            /*" -863- EXEC SQL SELECT VALUE(MAX(NRPARCEL),01) INTO :WHOST-NRPARCEL FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND SITUACAO = '1' END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRPARCEL, WHOST_NRPARCEL);
            }


        }

        [StopWatch]
        /*" R1300-20-LOOP-PROPOSTA */
        private void R1300_20_LOOP_PROPOSTA(bool isPerform = false)
        {
            /*" -1040- MOVE '1309' TO WNR-EXEC-SQL. */
            _.Move("1309", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1045- PERFORM R1300_20_LOOP_PROPOSTA_DB_SELECT_1 */

            R1300_20_LOOP_PROPOSTA_DB_SELECT_1();

            /*" -1048- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1050- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1052- COMPUTE V0FONT-PROPAUTOM = V0FONT-PROPAUTOM + 1. */
            V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

            /*" -1054- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1059- PERFORM R1300_20_LOOP_PROPOSTA_DB_UPDATE_1 */

            R1300_20_LOOP_PROPOSTA_DB_UPDATE_1();

            /*" -1062- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1067- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1069- MOVE '1321' TO WNR-EXEC-SQL. */
            _.Move("1321", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1146- PERFORM R1300_20_LOOP_PROPOSTA_DB_INSERT_1 */

            R1300_20_LOOP_PROPOSTA_DB_INSERT_1();

            /*" -1149- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1150- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1151- GO TO R1300-20-LOOP-PROPOSTA */
                    new Task(() => R1300_20_LOOP_PROPOSTA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1152- ELSE */
                }
                else
                {


                    /*" -1153- DISPLAY 'R1300-00 (ERRO - INSERT V0MOVIMENTO  )' */
                    _.Display($"R1300-00 (ERRO - INSERT V0MOVIMENTO  )");

                    /*" -1156- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' 'FONTE:  ' V0PROP-FONTE ' ' 'PROPOS: ' V0FONT-PROPAUTOM */

                    $"CERTIF: {V0PROP_NRCERTIF} FONTE:  {V0PROP_FONTE} PROPOS: {V0FONT_PROPAUTOM}"
                    .Display();

                    /*" -1160- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1161- MOVE V0PROP-NRCERTIF TO V0EVEN-NRCERTIF. */
            _.Move(V0PROP_NRCERTIF, V0EVEN_NRCERTIF);

            /*" -1162- MOVE TAB-NRPARCEL(WS-CONT-ATZ) TO V0EVEN-NRPARCEL */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_NRPARCEL, V0EVEN_NRPARCEL);

            /*" -1163- MOVE TAB-DTVENCTO(WS-CONT-ATZ) TO V0EVEN-DTVENCTO. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_DTVENCTO, V0EVEN_DTVENCTO);

            /*" -1165- MOVE V0PARC-VLPRMTOT TO V0EVEN-VLPRMTOT. */
            _.Move(V0PARC_VLPRMTOT, V0EVEN_VLPRMTOT);

            /*" -1166- MOVE 4 TO V0EVEN-CODEVEN. */
            _.Move(4, V0EVEN_CODEVEN);

            /*" -1168- MOVE 403 TO V0EVEN-CODOPER. */
            _.Move(403, V0EVEN_CODOPER);

            /*" -1170- PERFORM R2000-00-GERA-EVENTO. */

            R2000_00_GERA_EVENTO_SECTION();

            /*" -1172- MOVE TAB-NRTIT(WS-CONT-ATZ) TO V0HCOB-NRTIT. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_NRTIT, V0HCOB_NRTIT);

            /*" -1174- MOVE '1330' TO WNR-EXEC-SQL. */
            _.Move("1330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1180- PERFORM R1300_20_LOOP_PROPOSTA_DB_UPDATE_2 */

            R1300_20_LOOP_PROPOSTA_DB_UPDATE_2();

            /*" -1183- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1184- DISPLAY 'R1330-00 (UPDATE V0HISTCOBVA) ' */
                _.Display($"R1330-00 (UPDATE V0HISTCOBVA) ");

                /*" -1186- DISPLAY 'CERTIF ' V0PROP-NRCERTIF ' TIT  ' V0HCOB-NRTIT */

                $"CERTIF {V0PROP_NRCERTIF} TIT  {V0HCOB_NRTIT}"
                .Display();

                /*" -1186- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-20-LOOP-PROPOSTA-DB-SELECT-1 */
        public void R1300_20_LOOP_PROPOSTA_DB_SELECT_1()
        {
            /*" -1045- EXEC SQL SELECT PROPAUTOM INTO :V0FONT-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :V0PROP-FONTE END-EXEC. */

            var r1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1 = new R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1()
            {
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
            };

            var executed_1 = R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1.Execute(r1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONT_PROPAUTOM, V0FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R1300-20-LOOP-PROPOSTA-DB-UPDATE-1 */
        public void R1300_20_LOOP_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1059- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V0FONT-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0PROP-FONTE END-EXEC. */

            var r1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1 = new R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1()
            {
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
            };

            R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1.Execute(r1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1300-20-LOOP-PROPOSTA-DB-INSERT-1 */
        public void R1300_20_LOOP_PROPOSTA_DB_INSERT_1()
        {
            /*" -1146- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0FONT-PROPAUTOM, '1' , :V0PROP-NRCERTIF, ' ' , :V0SEGU-TPINCLUS, :V0PROP-CODCLIEN, :V0SEGU-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :V0OPCP-PERIPGTO, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , 0, 0, ' ' , 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, 403, CURRENT DATE, 0, '1' , 'VF0851B' , CURRENT DATE, NULL, NULL, NULL, NULL, :V0FATC-DTREF, :V0MOVI-DTMOVTO, NULL, NULL) END-EXEC. */

            var r1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1 = new R1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SEGU_TPINCLUS = V0SEGU_TPINCLUS.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0SEGU_AGENCIADOR = V0SEGU_AGENCIADOR.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0COBA_IMPMORNATU = V0COBA_IMPMORNATU.ToString(),
                V0COBA_IMPMORACID = V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = V0COBA_IMPDIT.ToString(),
                V0COBA_PRMVG = V0COBA_PRMVG.ToString(),
                V0COBA_PRMAP = V0COBA_PRMAP.ToString(),
                V0FATC_DTREF = V0FATC_DTREF.ToString(),
                V0MOVI_DTMOVTO = V0MOVI_DTMOVTO.ToString(),
            };

            R1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1.Execute(r1300_20_LOOP_PROPOSTA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-UPDATE-1 */
        public void R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1()
        {
            /*" -896- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '4' , CODOPER = 403, DTMOVTO = :V0MOVI-DTMOVTO, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1 = new R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1()
            {
                V0MOVI_DTMOVTO = V0MOVI_DTMOVTO.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1.Execute(r1300_00_CANCELA_FALTA_PG_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1300-20-LOOP-PROPOSTA-DB-UPDATE-2 */
        public void R1300_20_LOOP_PROPOSTA_DB_UPDATE_2()
        {
            /*" -1180- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '5' , CODOPER = 138 WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var r1300_20_LOOP_PROPOSTA_DB_UPDATE_2_Update1 = new R1300_20_LOOP_PROPOSTA_DB_UPDATE_2_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1300_20_LOOP_PROPOSTA_DB_UPDATE_2_Update1.Execute(r1300_20_LOOP_PROPOSTA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-2 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_2()
        {
            /*" -878- EXEC SQL SELECT DTVENCTO + 1 MONTH INTO :V0MOVI-DTMOVTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVI_DTMOVTO, V0MOVI_DTMOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-3 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_3()
        {
            /*" -913- EXEC SQL SELECT DATA_REFERENCIA INTO :V0FATC-DTREF FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FATC_DTREF, V0FATC_DTREF);
            }


        }

        [StopWatch]
        /*" R1400-00-EMITE-AVISO-ATRASO-SECTION */
        private void R1400_00_EMITE_AVISO_ATRASO_SECTION()
        {
            /*" -1200- IF TAB-DTPROXVEN(WS-CONT-ATZ) NOT GREATER V1SIST-DTCORRENTE */

            if (AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_DTPROXVEN <= V1SIST_DTCORRENTE)
            {

                /*" -1204- GO TO R1400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1206- MOVE WS-CONT-ATZ TO V0PROP-QTDPARATZ. */
            _.Move(AREA_DE_WORK.WS_CONT_ATZ, V0PROP_QTDPARATZ);

            /*" -1208- MOVE '1401' TO WNR-EXEC-SQL. */
            _.Move("1401", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1214- PERFORM R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1 */

            R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1();

            /*" -1217- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1219- DISPLAY 'R1400-00 (ERRO - UPDATE V0PROPOSTAVA)' */
                _.Display($"R1400-00 (ERRO - UPDATE V0PROPOSTAVA)");

                /*" -1223- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1225- ADD 1 TO WTITL-SEQUENCIA. */
            FILLER_0.WTITL_SEQUENCIA.Value = FILLER_0.WTITL_SEQUENCIA + 1;

            /*" -1227- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(FILLER_0.WTITL_SEQUENCIA, DPARM01X.DPARM01);

            /*" -1229- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", DPARM01X);

            /*" -1230- IF DPARM01-RC NOT EQUAL +0 */

            if (DPARM01X.DPARM01_RC != +0)
            {

                /*" -1231- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -1232- DISPLAY 'CERTIFICADO     ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO     {V0PROP_NRCERTIF}");

                /*" -1233- DISPLAY 'AREA            ' DPARM01X */
                _.Display($"AREA            {DPARM01X}");

                /*" -1235- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1238- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(DPARM01X.DPARM01_D1, FILLER_0.WTITL_DIGITO);

            /*" -1240- MOVE W-NUMR-TITULO TO V0BANC-NRTIT. */
            _.Move(W_NUMR_TITULO, V0BANC_NRTIT);

            /*" -1241- MOVE 1 TO WS-I-PARC. */
            _.Move(1, AREA_DE_WORK.WS_I_PARC);

            /*" -1245- MOVE 0 TO WHOST-VLPREMIO WHOST-PRMVG WHOST-PRMAP. */
            _.Move(0, WHOST_VLPREMIO, WHOST_PRMVG, WHOST_PRMAP);

            /*" -1248- PERFORM R1410-00-MONTA-TITULO UNTIL WS-I-PARC > WS-CONT-ATZ. */

            while (!(AREA_DE_WORK.WS_I_PARC > AREA_DE_WORK.WS_CONT_ATZ))
            {

                R1410_00_MONTA_TITULO_SECTION();
            }

            /*" -1250- MOVE TAB-DTPROXVEN(WS-CONT-ATZ) TO V0HCOB-DTVENCTO. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_DTPROXVEN, V0HCOB_DTVENCTO);

            /*" -1251- IF V0OPCP-OPCAOPAG EQUAL '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -1253- PERFORM R1500-00-COMPOE-DIFERENCAS. */

                R1500_00_COMPOE_DIFERENCAS_SECTION();
            }


            /*" -1255- MOVE TAB-NRPARCEL(WS-CONT-ATZ) TO V0HCOB-NRPARCEL. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_CONT_ATZ].TAB_NRPARCEL, V0HCOB_NRPARCEL);

            /*" -1256- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -1257- IF WS-CONT-ATZ EQUAL 1 */

                if (AREA_DE_WORK.WS_CONT_ATZ == 1)
                {

                    /*" -1258- MOVE 136 TO V0HCOB-CODOPER */
                    _.Move(136, V0HCOB_CODOPER);

                    /*" -1259- ELSE */
                }
                else
                {


                    /*" -1260- MOVE 137 TO V0HCOB-CODOPER */
                    _.Move(137, V0HCOB_CODOPER);

                    /*" -1261- ELSE */
                }

            }
            else
            {


                /*" -1262- IF WS-CONT-ATZ EQUAL 1 */

                if (AREA_DE_WORK.WS_CONT_ATZ == 1)
                {

                    /*" -1263- MOVE 148 TO V0HCOB-CODOPER */
                    _.Move(148, V0HCOB_CODOPER);

                    /*" -1264- ELSE */
                }
                else
                {


                    /*" -1266- MOVE 149 TO V0HCOB-CODOPER. */
                    _.Move(149, V0HCOB_CODOPER);
                }

            }


            /*" -1268- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1285- PERFORM R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1 */

            R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1();

            /*" -1288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1290- DISPLAY 'R1400-00 (ERRO - INSERT V0HISTCOBVA)' */
                _.Display($"R1400-00 (ERRO - INSERT V0HISTCOBVA)");

                /*" -1292- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1293- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -1294- MOVE '1405' TO WNR-EXEC-SQL */
                _.Move("1405", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1299- PERFORM R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1 */

                R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1();

                /*" -1301- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1303- DISPLAY 'R0000-00 (SELECT V0CONSICOV) PRODUTO ' V0PROP-CODPRODU */
                    _.Display($"R0000-00 (SELECT V0CONSICOV) PRODUTO {V0PROP_CODPRODU}");

                    /*" -1304- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1305- END-IF */
                }


                /*" -1306- IF V0CONV-CODCONV EQUAL ZEROES */

                if (V0CONV_CODCONV == 00)
                {

                    /*" -1308- DISPLAY 'R0000-00 (SELECT V0CONSICOV) PRODUTO ' V0PROP-CODPRODU */
                    _.Display($"R0000-00 (SELECT V0CONSICOV) PRODUTO {V0PROP_CODPRODU}");

                    /*" -1309- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1310- END-IF */
                }


                /*" -1311- MOVE 1 TO WS-I-PARC */
                _.Move(1, AREA_DE_WORK.WS_I_PARC);

                /*" -1314- PERFORM R1600-00-GERA-DEBITO UNTIL WS-I-PARC > WS-CONT-ATZ. */

                while (!(AREA_DE_WORK.WS_I_PARC > AREA_DE_WORK.WS_CONT_ATZ))
                {

                    R1600_00_GERA_DEBITO_SECTION();
                }
            }


            /*" -1314- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R1400-00-EMITE-AVISO-ATRASO-DB-UPDATE-1 */
        public void R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1()
        {
            /*" -1214- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = :V0PROP-QTDPARATZ, SITUACAO = '6' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF END-EXEC. */

            var r1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1_Update1 = new R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1_Update1()
            {
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1_Update1.Execute(r1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1400-00-EMITE-AVISO-ATRASO-DB-INSERT-1 */
        public void R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1()
        {
            /*" -1285- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0HCOB-NRPARCEL, :V0BANC-NRTIT, :V0HCOB-DTVENCTO, :WHOST-VLPREMIO, :V0OPCP-OPCAOPAG, '5' , :V0HCOB-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1 = new R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                WHOST_VLPREMIO = WHOST_VLPREMIO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HCOB_CODOPER = V0HCOB_CODOPER.ToString(),
            };

            R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1.Execute(r1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1400-00-EMITE-AVISO-ATRASO-DB-SELECT-1 */
        public void R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1()
        {
            /*" -1299- EXEC SQL SELECT COD_SEGURO INTO :V0CONV-CODCONV FROM SEGUROS.V0CONVSICOV WHERE CODPRODU = :V0PROP-CODPRODU END-EXEC */

            var r1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1 = new R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1()
            {
                V0PROP_CODPRODU = V0PROP_CODPRODU.ToString(),
            };

            var executed_1 = R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1.Execute(r1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
            }


        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-4 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_4()
        {
            /*" -923- EXEC SQL SELECT DATA_REFERENCIA INTO :V0FATC-DTREF FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = 0 END-EXEC */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FATC_DTREF, V0FATC_DTREF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-5 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_5()
        {
            /*" -945- EXEC SQL SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO INTO :V0SEGU-TPINCLUS, :V0SEGU-AGENCIADOR, :V0SEGU-ITEM, :V0SEGU-OCORHIST FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGU_TPINCLUS, V0SEGU_TPINCLUS);
                _.Move(executed_1.V0SEGU_AGENCIADOR, V0SEGU_AGENCIADOR);
                _.Move(executed_1.V0SEGU_ITEM, V0SEGU_ITEM);
                _.Move(executed_1.V0SEGU_OCORHIST, V0SEGU_OCORHIST);
            }


        }

        [StopWatch]
        /*" R1410-00-MONTA-TITULO-SECTION */
        private void R1410_00_MONTA_TITULO_SECTION()
        {
            /*" -1328- MOVE V0PROP-NRCERTIF TO V0EVEN-NRCERTIF. */
            _.Move(V0PROP_NRCERTIF, V0EVEN_NRCERTIF);

            /*" -1329- MOVE TAB-NRPARCEL(WS-I-PARC) TO V0EVEN-NRPARCEL */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_NRPARCEL, V0EVEN_NRPARCEL);

            /*" -1330- MOVE TAB-DTVENCTO(WS-I-PARC) TO V0EVEN-DTVENCTO. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_DTVENCTO, V0EVEN_DTVENCTO);

            /*" -1332- MOVE TAB-VLPRMTOT(WS-I-PARC) TO V0EVEN-VLPRMTOT. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_VLPRMTOT, V0EVEN_VLPRMTOT);

            /*" -1333- MOVE 10 TO V0EVEN-CODEVEN. */
            _.Move(10, V0EVEN_CODEVEN);

            /*" -1335- MOVE 0 TO V0EVEN-CODOPER. */
            _.Move(0, V0EVEN_CODOPER);

            /*" -1337- PERFORM R2000-00-GERA-EVENTO. */

            R2000_00_GERA_EVENTO_SECTION();

            /*" -1338- MOVE TAB-NRPARCEL(WS-I-PARC) TO V0COMP-NRPARCEL. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_NRPARCEL, V0COMP_NRPARCEL);

            /*" -1339- MOVE TAB-PRMVG(WS-I-PARC) TO V0COMP-PRMDIFVG. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_PRMVG, V0COMP_PRMDIFVG);

            /*" -1341- MOVE TAB-PRMAP(WS-I-PARC) TO V0COMP-PRMDIFAP. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_PRMAP, V0COMP_PRMDIFAP);

            /*" -1343- COMPUTE V0COMP-CODOPER = 120 + WS-I-PARC. */
            V0COMP_CODOPER.Value = 120 + AREA_DE_WORK.WS_I_PARC;

            /*" -1345- MOVE '1411' TO WNR-EXEC-SQL */
            _.Move("1411", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1356- PERFORM R1410_00_MONTA_TITULO_DB_INSERT_1 */

            R1410_00_MONTA_TITULO_DB_INSERT_1();

            /*" -1359- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1360- DISPLAY 'R1410-00 (INSERT V0COMPTITVA)' */
                _.Display($"R1410-00 (INSERT V0COMPTITVA)");

                /*" -1362- DISPLAY 'CERTIF ' V0PROP-NRCERTIF ' PARC ' V0COMP-NRPARCEL */

                $"CERTIF {V0PROP_NRCERTIF} PARC {V0COMP_NRPARCEL}"
                .Display();

                /*" -1364- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1365- ADD TAB-VLPRMTOT(WS-I-PARC) TO WHOST-VLPREMIO. */
            WHOST_VLPREMIO.Value = WHOST_VLPREMIO + AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_VLPRMTOT;

            /*" -1366- ADD TAB-PRMVG(WS-I-PARC) TO WHOST-PRMVG. */
            WHOST_PRMVG.Value = WHOST_PRMVG + AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_PRMVG;

            /*" -1368- ADD TAB-PRMAP(WS-I-PARC) TO WHOST-PRMAP. */
            WHOST_PRMAP.Value = WHOST_PRMAP + AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_PRMAP;

            /*" -1368- ADD 1 TO WS-I-PARC. */
            AREA_DE_WORK.WS_I_PARC.Value = AREA_DE_WORK.WS_I_PARC + 1;

        }

        [StopWatch]
        /*" R1410-00-MONTA-TITULO-DB-INSERT-1 */
        public void R1410_00_MONTA_TITULO_DB_INSERT_1()
        {
            /*" -1356- EXEC SQL INSERT INTO SEGUROS.V0COMPTITVA VALUES (:V0BANC-NRTIT, :V0COMP-NRPARCEL, :V0COMP-CODOPER, :V0COMP-PRMDIFVG, :V0COMP-PRMDIFAP, CURRENT DATE, 'VF0851B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1410_00_MONTA_TITULO_DB_INSERT_1_Insert1 = new R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
                V0COMP_NRPARCEL = V0COMP_NRPARCEL.ToString(),
                V0COMP_CODOPER = V0COMP_CODOPER.ToString(),
                V0COMP_PRMDIFVG = V0COMP_PRMDIFVG.ToString(),
                V0COMP_PRMDIFAP = V0COMP_PRMDIFAP.ToString(),
            };

            R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1.Execute(r1410_00_MONTA_TITULO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-6 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_6()
        {
            /*" -969- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = 93 AND MODALIFR = 0 AND COD_COBERTURA = 11 END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, V0COBA_PRMVG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-7 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_7()
        {
            /*" -991- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = 81 AND MODALIFR = 0 AND COD_COBERTURA = 1 END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }

        [StopWatch]
        /*" R1500-00-COMPOE-DIFERENCAS-SECTION */
        private void R1500_00_COMPOE_DIFERENCAS_SECTION()
        {
            /*" -1388- PERFORM R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1 */

            R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1();

            /*" -1392- MOVE '1501' TO WNR-EXEC-SQL. */
            _.Move("1501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1392- PERFORM R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1 */

            R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1();

            /*" -1395- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1396- DISPLAY 'PROBLEMAS NO OPEN (CDIFPAR   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CDIFPAR   ) ... ");

                /*" -1398- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1400- MOVE SPACES TO WFIM-CDIFPAR. */
            _.Move("", AREA_DE_WORK.WFIM_CDIFPAR);

            /*" -1402- PERFORM R1520-00-FETCH-CDIFPAR. */

            R1520_00_FETCH_CDIFPAR_SECTION();

            /*" -1403- PERFORM R1510-00-MONTA-DIFERENCA UNTIL WFIM-CDIFPAR NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty()))
            {

                R1510_00_MONTA_DIFERENCA_SECTION();
            }

        }

        [StopWatch]
        /*" R1500-00-COMPOE-DIFERENCAS-DB-OPEN-1 */
        public void R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1()
        {
            /*" -1392- EXEC SQL OPEN CDIFPAR END-EXEC. */

            CDIFPAR.Open();

        }

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-DB-DECLARE-1 */
        public void R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1()
        {
            /*" -1615- EXEC SQL DECLARE CPARDIF CURSOR FOR SELECT NRPARCEL, NRPARCELDIF, CODOPER, DTVENCTO, PRMDIFVG, PRMDIFAP, SITUACAO FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = 9999 AND CODOPER >= 600 AND CODOPER <= 699 AND SITUACAO = ' ' FOR UPDATE OF NRPARCEL, SITUACAO, PRMDIFVG, PRMDIFAP END-EXEC. */
            CPARDIF = new VF0851B_CPARDIF(true);
            string GetQuery_CPARDIF()
            {
                var query = @$"SELECT NRPARCEL
							, 
							NRPARCELDIF
							, 
							CODOPER
							, 
							DTVENCTO
							, 
							PRMDIFVG
							, 
							PRMDIFAP
							, 
							SITUACAO 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND NRPARCEL = 9999 
							AND CODOPER >= 600 
							AND CODOPER <= 699 
							AND SITUACAO = ' '";

                return query;
            }
            CPARDIF.GetQueryEvent += GetQuery_CPARDIF;

        }

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-8 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_8()
        {
            /*" -1010- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = 81 AND MODALIFR = 0 AND COD_COBERTURA = 2 END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CANCELA-FALTA-PG-DB-SELECT-9 */
        public void R1300_00_CANCELA_FALTA_PG_DB_SELECT_9()
        {
            /*" -1028- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = 81 AND MODALIFR = 0 AND COD_COBERTURA = 5 END-EXEC. */

            var r1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1 = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1.Execute(r1300_00_CANCELA_FALTA_PG_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }

        [StopWatch]
        /*" R1510-00-MONTA-DIFERENCA-SECTION */
        private void R1510_00_MONTA_DIFERENCA_SECTION()
        {
            /*" -1413- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1424- PERFORM R1510_00_MONTA_DIFERENCA_DB_INSERT_1 */

            R1510_00_MONTA_DIFERENCA_DB_INSERT_1();

            /*" -1427- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1428- DISPLAY 'R1510-00 (INSERT V0COMPTITVA)' */
                _.Display($"R1510-00 (INSERT V0COMPTITVA)");

                /*" -1430- DISPLAY 'CERTIF ' V0PROP-NRCERTIF ' PARC ' V0DIFP-NRPARCEL */

                $"CERTIF {V0PROP_NRCERTIF} PARC {V0DIFP_NRPARCEL}"
                .Display();

                /*" -1432- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1434- IF V0DIFP-CODOPER NOT LESS 600 AND V0DIFP-CODOPER NOT GREATER 699 */

            if (V0DIFP_CODOPER >= 600 && V0DIFP_CODOPER <= 699)
            {

                /*" -1435- IF WHOST-VLPREMIO < V0DIFP-VLPRMTOT */

                if (WHOST_VLPREMIO < V0DIFP_VLPRMTOT)
                {

                    /*" -1436- DISPLAY 'R1510-00 (DIFERENCA NAO ESPERADA) ' */
                    _.Display($"R1510-00 (DIFERENCA NAO ESPERADA) ");

                    /*" -1437- DISPLAY ' CERTIF ' V0PROP-NRCERTIF */
                    _.Display($" CERTIF {V0PROP_NRCERTIF}");

                    /*" -1438- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1439- ELSE */
                }
                else
                {


                    /*" -1440- COMPUTE WHOST-PRMVG = WHOST-PRMVG - V0DIFP-PRMDIFVG */
                    WHOST_PRMVG.Value = WHOST_PRMVG - V0DIFP_PRMDIFVG;

                    /*" -1441- COMPUTE WHOST-PRMAP = WHOST-PRMAP - V0DIFP-PRMDIFAP */
                    WHOST_PRMAP.Value = WHOST_PRMAP - V0DIFP_PRMDIFAP;

                    /*" -1443- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP. */
                    WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;
                }

            }


            /*" -1445- IF V0DIFP-CODOPER NOT LESS 400 AND V0DIFP-CODOPER NOT GREATER 499 */

            if (V0DIFP_CODOPER >= 400 && V0DIFP_CODOPER <= 499)
            {

                /*" -1446- COMPUTE WHOST-PRMVG = WHOST-PRMVG + V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG + V0DIFP_PRMDIFVG;

                /*" -1447- COMPUTE WHOST-PRMAP = WHOST-PRMAP + V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP + V0DIFP_PRMDIFAP;

                /*" -1449- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP. */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;
            }


            /*" -1449- PERFORM R1520-00-FETCH-CDIFPAR. */

            R1520_00_FETCH_CDIFPAR_SECTION();

        }

        [StopWatch]
        /*" R1510-00-MONTA-DIFERENCA-DB-INSERT-1 */
        public void R1510_00_MONTA_DIFERENCA_DB_INSERT_1()
        {
            /*" -1424- EXEC SQL INSERT INTO SEGUROS.V0COMPTITVA VALUES (:V0BANC-NRTIT, :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, CURRENT DATE, 'VF0851B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1 = new R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0DIFP_PRMDIFVG = V0DIFP_PRMDIFVG.ToString(),
                V0DIFP_PRMDIFAP = V0DIFP_PRMDIFAP.ToString(),
            };

            R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1.Execute(r1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1520-00-FETCH-CDIFPAR-SECTION */
        private void R1520_00_FETCH_CDIFPAR_SECTION()
        {
            /*" -1460- MOVE '1520' TO WNR-EXEC-SQL. */
            _.Move("1520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1465- PERFORM R1520_00_FETCH_CDIFPAR_DB_FETCH_1 */

            R1520_00_FETCH_CDIFPAR_DB_FETCH_1();

            /*" -1468- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1469- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1469- PERFORM R1520_00_FETCH_CDIFPAR_DB_CLOSE_1 */

                    R1520_00_FETCH_CDIFPAR_DB_CLOSE_1();

                    /*" -1471- MOVE 'S' TO WFIM-CDIFPAR */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFPAR);

                    /*" -1472- ELSE */
                }
                else
                {


                    /*" -1473- DISPLAY 'R1520-00 (ERRO -  FETCH CDIFPAR   )...' */
                    _.Display($"R1520-00 (ERRO -  FETCH CDIFPAR   )...");

                    /*" -1473- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1520-00-FETCH-CDIFPAR-DB-FETCH-1 */
        public void R1520_00_FETCH_CDIFPAR_DB_FETCH_1()
        {
            /*" -1465- EXEC SQL FETCH CDIFPAR INTO :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP END-EXEC. */

            if (CDIFPAR.Fetch())
            {
                _.Move(CDIFPAR.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CDIFPAR.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CDIFPAR.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CDIFPAR.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
            }

        }

        [StopWatch]
        /*" R1520-00-FETCH-CDIFPAR-DB-CLOSE-1 */
        public void R1520_00_FETCH_CDIFPAR_DB_CLOSE_1()
        {
            /*" -1469- EXEC SQL CLOSE CDIFPAR END-EXEC */

            CDIFPAR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-GERA-DEBITO-SECTION */
        private void R1600_00_GERA_DEBITO_SECTION()
        {
            /*" -1485- ADD 1 TO TAB-OCORHIST(WS-I-PARC). */
            AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_OCORHIST.Value = AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_OCORHIST + 1;

            /*" -1487- MOVE TAB-OCORHIST(WS-I-PARC) TO V0PARC-OCORHIST. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_OCORHIST, V0PARC_OCORHIST);

            /*" -1488- MOVE TAB-NRPARCEL(WS-I-PARC) TO V0PARC-NRPARCEL. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_NRPARCEL, V0PARC_NRPARCEL);

            /*" -1490- MOVE TAB-VLPRMTOT(WS-I-PARC) TO V0PARC-VLPRMTOT. */
            _.Move(AREA_DE_WORK.TAB_PARCELAS_ATRASO.TAB_PARCELAS_ATR[AREA_DE_WORK.WS_I_PARC].TAB_VLPRMTOT, V0PARC_VLPRMTOT);

            /*" -1492- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1533- PERFORM R1600_00_GERA_DEBITO_DB_INSERT_1 */

            R1600_00_GERA_DEBITO_DB_INSERT_1();

            /*" -1536- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1537- DISPLAY 'R1600-00 (ERRO - INSERT V0HISTCONTAVA)' */
                _.Display($"R1600-00 (ERRO - INSERT V0HISTCONTAVA)");

                /*" -1539- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PARC-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PARC_NRPARCEL}"
                .Display();

                /*" -1541- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1543- MOVE '1610' TO WNR-EXEC-SQL. */
            _.Move("1610", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1548- PERFORM R1600_00_GERA_DEBITO_DB_UPDATE_1 */

            R1600_00_GERA_DEBITO_DB_UPDATE_1();

            /*" -1551- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1552- DISPLAY 'R1600-00 (ERRO - UPDATE V0PARCELVA)' */
                _.Display($"R1600-00 (ERRO - UPDATE V0PARCELVA)");

                /*" -1554- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PARC-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PARC_NRPARCEL}"
                .Display();

                /*" -1556- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1556- ADD 1 TO WS-I-PARC. */
            AREA_DE_WORK.WS_I_PARC.Value = AREA_DE_WORK.WS_I_PARC + 1;

        }

        [StopWatch]
        /*" R1600-00-GERA-DEBITO-DB-INSERT-1 */
        public void R1600_00_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -1533- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0PROP-NRCERTIF, :V0PARC-NRPARCEL, :V0PARC-OCORHIST, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HCOB-DTVENCTO, :V0PARC-VLPRMTOT, '0' , '1' , CURRENT TIMESTAMP, 0, :V0CONV-CODCONV, NULL, NULL, NULL, NULL, NULL,0) END-EXEC. */

            var r1600_00_GERA_DEBITO_DB_INSERT_1_Insert1 = new R1600_00_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0PARC_VLPRMTOT = V0PARC_VLPRMTOT.ToString(),
                V0CONV_CODCONV = V0CONV_CODCONV.ToString(),
            };

            R1600_00_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(r1600_00_GERA_DEBITO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1600-00-GERA-DEBITO-DB-UPDATE-1 */
        public void R1600_00_GERA_DEBITO_DB_UPDATE_1()
        {
            /*" -1548- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET OCORHIST = :V0PARC-OCORHIST WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r1600_00_GERA_DEBITO_DB_UPDATE_1_Update1 = new R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1()
            {
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1.Execute(r1600_00_GERA_DEBITO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-QUITA-ATRASADA-SECTION */
        private void R1700_00_QUITA_ATRASADA_SECTION()
        {
            /*" -1571- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF ' ' 'PARCELA     ' V0PARC-NRPARCEL ' ' 'QUITOU ATRASADA ' . */

            $"CERTIFICADO {V0PROP_NRCERTIF} PARCELA     {V0PARC_NRPARCEL} QUITOU ATRASADA "
            .Display();

            /*" -1573- MOVE '1705' TO WNR-EXEC-SQL. */
            _.Move("1705", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1579- PERFORM R1700_00_QUITA_ATRASADA_DB_UPDATE_1 */

            R1700_00_QUITA_ATRASADA_DB_UPDATE_1();

            /*" -1582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1583- DISPLAY 'R1700-00 (ERRO - UPDATE V0PARCELVA)' */
                _.Display($"R1700-00 (ERRO - UPDATE V0PARCELVA)");

                /*" -1584- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PARC-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PARC_NRPARCEL}"
                .Display();

                /*" -1586- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1588- PERFORM R1750-00-APROPRIA-DIFERENCAS. */

            R1750_00_APROPRIA_DIFERENCAS_SECTION();

            /*" -1588- PERFORM R1800-00-VERIFICA-REPASSES. */

            R1800_00_VERIFICA_REPASSES_SECTION();

        }

        [StopWatch]
        /*" R1700-00-QUITA-ATRASADA-DB-UPDATE-1 */
        public void R1700_00_QUITA_ATRASADA_DB_UPDATE_1()
        {
            /*" -1579- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1 = new R1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            R1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1.Execute(r1700_00_QUITA_ATRASADA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-SECTION */
        private void R1750_00_APROPRIA_DIFERENCAS_SECTION()
        {
            /*" -1615- PERFORM R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1 */

            R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1();

            /*" -1619- MOVE '1751' TO WNR-EXEC-SQL. */
            _.Move("1751", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1619- PERFORM R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1 */

            R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1();

            /*" -1622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1623- DISPLAY 'R1750-00 (OPEN CURSOR CPARDIF)' */
                _.Display($"R1750-00 (OPEN CURSOR CPARDIF)");

                /*" -1624- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1626- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1627- MOVE SPACES TO WFIM-CPARDIF. */
            _.Move("", AREA_DE_WORK.WFIM_CPARDIF);

            /*" -1629- PERFORM R1770-00-FETCH-V0DIFPARCELVA. */

            R1770_00_FETCH_V0DIFPARCELVA_SECTION();

            /*" -1630- IF WFIM-CPARDIF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPARDIF.IsEmpty())
            {

                /*" -1631- DISPLAY 'R1750-00 (DIFERENCAS NAO ENCONTRADAS) ' */
                _.Display($"R1750-00 (DIFERENCAS NAO ENCONTRADAS) ");

                /*" -1632- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1634- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1638- PERFORM R1760-00-APROPRIA-DIFERENCA UNTIL V0PARC-VLPRMTOT EQUAL 0 OR WFIM-CPARDIF NOT EQUAL SPACES. */

            while (!(V0PARC_VLPRMTOT == 0 || !AREA_DE_WORK.WFIM_CPARDIF.IsEmpty()))
            {

                R1760_00_APROPRIA_DIFERENCA_SECTION();
            }

            /*" -1639- IF WFIM-CPARDIF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPARDIF.IsEmpty())
            {

                /*" -1640- DISPLAY 'R1750-00 (FIM DAS DIFERENCAS NAO ESPERADO ' */
                _.Display($"R1750-00 (FIM DAS DIFERENCAS NAO ESPERADO ");

                /*" -1643- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF. */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");
            }


            /*" -1645- MOVE '1752' TO WNR-EXEC-SQL. */
            _.Move("1752", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1645- PERFORM R1750_00_APROPRIA_DIFERENCAS_DB_CLOSE_1 */

            R1750_00_APROPRIA_DIFERENCAS_DB_CLOSE_1();

            /*" -1648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1649- DISPLAY 'R1750-00 (CLOSE CURSOR CPARDIF)' */
                _.Display($"R1750-00 (CLOSE CURSOR CPARDIF)");

                /*" -1650- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1650- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-DB-OPEN-1 */
        public void R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1()
        {
            /*" -1619- EXEC SQL OPEN CPARDIF END-EXEC. */

            CPARDIF.Open();

        }

        [StopWatch]
        /*" R2000-00-GERA-EVENTO-DB-DECLARE-1 */
        public void R2000_00_GERA_EVENTO_DB_DECLARE_1()
        {
            /*" -1846- EXEC SQL DECLARE CPLACOM CURSOR FOR SELECT DISTINCT CODPDT FROM SEGUROS.V0PLANCOMISVF WHERE NRCERTIF = :V0EVEN-NRCERTIF ORDER BY CODPDT END-EXEC. */
            CPLACOM = new VF0851B_CPLACOM(true);
            string GetQuery_CPLACOM()
            {
                var query = @$"SELECT DISTINCT CODPDT 
							FROM SEGUROS.V0PLANCOMISVF 
							WHERE NRCERTIF = '{V0EVEN_NRCERTIF}' 
							ORDER BY CODPDT";

                return query;
            }
            CPLACOM.GetQueryEvent += GetQuery_CPLACOM;

        }

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-DB-CLOSE-1 */
        public void R1750_00_APROPRIA_DIFERENCAS_DB_CLOSE_1()
        {
            /*" -1645- EXEC SQL CLOSE CPARDIF END-EXEC. */

            CPARDIF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R1760-00-APROPRIA-DIFERENCA-SECTION */
        private void R1760_00_APROPRIA_DIFERENCA_SECTION()
        {
            /*" -1659- IF V0DIFP-VLPRMTOT GREATER V0PARC-VLPRMTOT */

            if (V0DIFP_VLPRMTOT > V0PARC_VLPRMTOT)
            {

                /*" -1660- MOVE '1761' TO WNR-EXEC-SQL */
                _.Move("1761", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1667- PERFORM R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1 */

                R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1();

                /*" -1669- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1670- DISPLAY 'R1760-00 (UPDATE V0DIFPARCELVA) ' */
                    _.Display($"R1760-00 (UPDATE V0DIFPARCELVA) ");

                    /*" -1672- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' PARCEL: ' V0PARC-NRPARCEL */

                    $"CERTIF: {V0PROP_NRCERTIF} PARCEL: {V0PARC_NRPARCEL}"
                    .Display();

                    /*" -1673- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1674- END-IF */
                }


                /*" -1676- COMPUTE V0DIFP-VLPRMTOT = V0DIFP-VLPRMTOT - V0PARC-VLPRMTOT */
                V0DIFP_VLPRMTOT.Value = V0DIFP_VLPRMTOT - V0PARC_VLPRMTOT;

                /*" -1678- COMPUTE V0DIFP-PRMDIFVG = V0DIFP-PRMDIFVG - V0PARC-PRMVG */
                V0DIFP_PRMDIFVG.Value = V0DIFP_PRMDIFVG - V0PARC_PRMVG;

                /*" -1680- COMPUTE V0DIFP-PRMDIFAP = V0DIFP-PRMDIFAP - V0PARC-PRMVG */
                V0DIFP_PRMDIFAP.Value = V0DIFP_PRMDIFAP - V0PARC_PRMVG;

                /*" -1681- MOVE '1762' TO WNR-EXEC-SQL */
                _.Move("1762", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1696- PERFORM R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1 */

                R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1();

                /*" -1698- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1699- DISPLAY 'R1760-00 (INSERT V0DIFPARCELVA)' */
                    _.Display($"R1760-00 (INSERT V0DIFPARCELVA)");

                    /*" -1701- DISPLAY 'CERTIF ' V0PROP-NRCERTIF ' PARC ' V0PARC-NRPARCEL */

                    $"CERTIF {V0PROP_NRCERTIF} PARC {V0PARC_NRPARCEL}"
                    .Display();

                    /*" -1702- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1703- END-IF */
                }


                /*" -1704- MOVE 0 TO V0PARC-VLPRMTOT */
                _.Move(0, V0PARC_VLPRMTOT);

                /*" -1705- ELSE */
            }
            else
            {


                /*" -1706- MOVE '1763' TO WNR-EXEC-SQL */
                _.Move("1763", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1711- PERFORM R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2 */

                R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2();

                /*" -1713- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1714- DISPLAY 'R1760-00 (UPDATE V0DIFPARCELVA)' */
                    _.Display($"R1760-00 (UPDATE V0DIFPARCELVA)");

                    /*" -1716- DISPLAY 'CERTIF ' V0PROP-NRCERTIF ' PARCEL ' V0PARC-NRPARCEL */

                    $"CERTIF {V0PROP_NRCERTIF} PARCEL {V0PARC_NRPARCEL}"
                    .Display();

                    /*" -1717- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1718- END-IF */
                }


                /*" -1720- COMPUTE V0PARC-VLPRMTOT = V0PARC-VLPRMTOT - V0DIFP-VLPRMTOT */
                V0PARC_VLPRMTOT.Value = V0PARC_VLPRMTOT - V0DIFP_VLPRMTOT;

                /*" -1722- COMPUTE V0PARC-PRMVG = V0PARC-PRMVG - V0DIFP-PRMDIFVG */
                V0PARC_PRMVG.Value = V0PARC_PRMVG - V0DIFP_PRMDIFVG;

                /*" -1725- COMPUTE V0PARC-PRMAP = V0PARC-PRMAP - V0DIFP-PRMDIFAP. */
                V0PARC_PRMAP.Value = V0PARC_PRMAP - V0DIFP_PRMDIFAP;
            }


            /*" -1725- PERFORM R1770-00-FETCH-V0DIFPARCELVA. */

            R1770_00_FETCH_V0DIFPARCELVA_SECTION();

        }

        [StopWatch]
        /*" R1760-00-APROPRIA-DIFERENCA-DB-UPDATE-1 */
        public void R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1()
        {
            /*" -1667- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0PARC-NRPARCEL, PRMDIFVG = :V0PARC-PRMVG, PRMDIFAP = :V0PARC-PRMAP, SITUACAO = '1' WHERE CURRENT OF CPARDIF END-EXEC */

            var r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 = new R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1(CPARDIF)
            {
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1.Execute(r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1760-00-APROPRIA-DIFERENCA-DB-INSERT-1 */
        public void R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1()
        {
            /*" -1696- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, 9999, :V0DIFP-NRPARCELDIF, :V0DIFP-CODOPER, :V0DIFP-DTVENCTO, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, 0, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, ' ' ) END-EXEC */

            var r1760_00_APROPRIA_DIFERENCA_DB_INSERT_1_Insert1 = new R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0DIFP_NRPARCELDIF = V0DIFP_NRPARCELDIF.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0DIFP_DTVENCTO = V0DIFP_DTVENCTO.ToString(),
                V0DIFP_PRMDIFVG = V0DIFP_PRMDIFVG.ToString(),
                V0DIFP_PRMDIFAP = V0DIFP_PRMDIFAP.ToString(),
            };

            R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1_Insert1.Execute(r1760_00_APROPRIA_DIFERENCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1760_99_SAIDA*/

        [StopWatch]
        /*" R1760-00-APROPRIA-DIFERENCA-DB-UPDATE-2 */
        public void R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2()
        {
            /*" -1711- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0PARC-NRPARCEL, SITUACAO = '1' WHERE CURRENT OF CPARDIF END-EXEC */

            var r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1 = new R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1(CPARDIF)
            {
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1.Execute(r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1770-00-FETCH-V0DIFPARCELVA-SECTION */
        private void R1770_00_FETCH_V0DIFPARCELVA_SECTION()
        {
            /*" -1735- MOVE '1770' TO WNR-EXEC-SQL. */
            _.Move("1770", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1743- PERFORM R1770_00_FETCH_V0DIFPARCELVA_DB_FETCH_1 */

            R1770_00_FETCH_V0DIFPARCELVA_DB_FETCH_1();

            /*" -1746- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1747- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1748- MOVE 'S' TO WFIM-CPARDIF */
                    _.Move("S", AREA_DE_WORK.WFIM_CPARDIF);

                    /*" -1749- ELSE */
                }
                else
                {


                    /*" -1750- DISPLAY 'R1770-00 (FETCH CPARDIF)' */
                    _.Display($"R1770-00 (FETCH CPARDIF)");

                    /*" -1750- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1770-00-FETCH-V0DIFPARCELVA-DB-FETCH-1 */
        public void R1770_00_FETCH_V0DIFPARCELVA_DB_FETCH_1()
        {
            /*" -1743- EXEC SQL FETCH CPARDIF INTO :V0DIFP-NRPARCEL, :V0DIFP-NRPARCELDIF, :V0DIFP-CODOPER, :V0DIFP-DTVENCTO, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, :V0DIFP-SITUACAO END-EXEC. */

            if (CPARDIF.Fetch())
            {
                _.Move(CPARDIF.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CPARDIF.V0DIFP_NRPARCELDIF, V0DIFP_NRPARCELDIF);
                _.Move(CPARDIF.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CPARDIF.V0DIFP_DTVENCTO, V0DIFP_DTVENCTO);
                _.Move(CPARDIF.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CPARDIF.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
                _.Move(CPARDIF.V0DIFP_SITUACAO, V0DIFP_SITUACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1770_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-VERIFICA-REPASSES-SECTION */
        private void R1800_00_VERIFICA_REPASSES_SECTION()
        {
            /*" -1761- MOVE '1805' TO WNR-EXEC-SQL. */
            _.Move("1805", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1767- PERFORM R1800_00_VERIFICA_REPASSES_DB_SELECT_1 */

            R1800_00_VERIFICA_REPASSES_DB_SELECT_1();

            /*" -1770- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1770- PERFORM R1900-00-REPASSA-SAF. */

                R1900_00_REPASSA_SAF_SECTION();
            }


        }

        [StopWatch]
        /*" R1800-00-VERIFICA-REPASSES-DB-SELECT-1 */
        public void R1800_00_VERIFICA_REPASSES_DB_SELECT_1()
        {
            /*" -1767- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1 = new R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1.Execute(r1800_00_VERIFICA_REPASSES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-REPASSA-SAF-SECTION */
        private void R1900_00_REPASSA_SAF_SECTION()
        {
            /*" -1781- MOVE V0PARC-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -1782- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -1783- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -1784- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -1785- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -1786- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -1788- MOVE WDATA-SISTEMA TO V0RSAF-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RSAF_DTREFER);

            /*" -1790- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1797- PERFORM R1900_00_REPASSA_SAF_DB_SELECT_1 */

            R1900_00_REPASSA_SAF_DB_SELECT_1();

            /*" -1800- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1802- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1804- MOVE '1930' TO WNR-EXEC-SQL. */
            _.Move("1930", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1820- PERFORM R1900_00_REPASSA_SAF_DB_INSERT_1 */

            R1900_00_REPASSA_SAF_DB_INSERT_1();

            /*" -1825- IF SQLCODE EQUAL ZEROES OR -803 NEXT SENTENCE */

            if (DB.SQLCODE.In("00", "-803"))
            {

                /*" -1826- ELSE */
            }
            else
            {


                /*" -1826- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1900-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1900_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -1797- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 END-EXEC. */

            var r1900_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1900_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1900_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1900_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1900-00-REPASSA-SAF-DB-INSERT-1 */
        public void R1900_00_REPASSA_SAF_DB_INSERT_1()
        {
            /*" -1820- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0PROP-NRCERTIF, :V0PARC-NRPARCEL, 0, :V0SAFC-VLCUSTSAF, 1100, '0' , '0' , 0, 0, 'VF0851B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1900_00_REPASSA_SAF_DB_INSERT_1_Insert1 = new R1900_00_REPASSA_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1900_00_REPASSA_SAF_DB_INSERT_1_Insert1.Execute(r1900_00_REPASSA_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GERA-EVENTO-SECTION */
        private void R2000_00_GERA_EVENTO_SECTION()
        {
            /*" -1840- MOVE '2001' TO WNR-EXEC-SQL */
            _.Move("2001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1846- PERFORM R2000_00_GERA_EVENTO_DB_DECLARE_1 */

            R2000_00_GERA_EVENTO_DB_DECLARE_1();

            /*" -1849- MOVE '2002' TO WNR-EXEC-SQL. */
            _.Move("2002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1849- PERFORM R2000_00_GERA_EVENTO_DB_OPEN_1 */

            R2000_00_GERA_EVENTO_DB_OPEN_1();

            /*" -1852- MOVE 0 TO WFIM-CPLACOM. */
            _.Move(0, AREA_DE_WORK.WFIM_CPLACOM);

            /*" -1854- PERFORM R2110-00-FETCH. */

            R2110_00_FETCH_SECTION();

            /*" -1857- PERFORM R2100-00-GERA-EVENTO UNTIL WFIM-CPLACOM = 1. */

            while (!(AREA_DE_WORK.WFIM_CPLACOM == 1))
            {

                R2100_00_GERA_EVENTO_SECTION();
            }

            /*" -1858- MOVE '2003' TO WNR-EXEC-SQL. */
            _.Move("2003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1858- PERFORM R2000_00_GERA_EVENTO_DB_CLOSE_1 */

            R2000_00_GERA_EVENTO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R2000-00-GERA-EVENTO-DB-OPEN-1 */
        public void R2000_00_GERA_EVENTO_DB_OPEN_1()
        {
            /*" -1849- EXEC SQL OPEN CPLACOM END-EXEC. */

            CPLACOM.Open();

        }

        [StopWatch]
        /*" R2000-00-GERA-EVENTO-DB-CLOSE-1 */
        public void R2000_00_GERA_EVENTO_DB_CLOSE_1()
        {
            /*" -1858- EXEC SQL CLOSE CPLACOM END-EXEC. */

            CPLACOM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-GERA-EVENTO-SECTION */
        private void R2100_00_GERA_EVENTO_SECTION()
        {
            /*" -1873- MOVE '2101' TO WNR-EXEC-SQL. */
            _.Move("2101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1878- PERFORM R2100_00_GERA_EVENTO_DB_SELECT_1 */

            R2100_00_GERA_EVENTO_DB_SELECT_1();

            /*" -1881- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1883- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1885- ADD 1 TO V0PDVF-OCORHIST. */
            V0PDVF_OCORHIST.Value = V0PDVF_OCORHIST + 1;

            /*" -1887- MOVE '2102' TO WNR-EXEC-SQL. */
            _.Move("2102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1891- PERFORM R2100_00_GERA_EVENTO_DB_UPDATE_1 */

            R2100_00_GERA_EVENTO_DB_UPDATE_1();

            /*" -1894- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1896- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1898- MOVE '2103' TO WNR-EXEC-SQL. */
            _.Move("2103", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1914- PERFORM R2100_00_GERA_EVENTO_DB_INSERT_1 */

            R2100_00_GERA_EVENTO_DB_INSERT_1();

            /*" -1916- PERFORM R2110-00-FETCH. */

            R2110_00_FETCH_SECTION();

        }

        [StopWatch]
        /*" R2100-00-GERA-EVENTO-DB-SELECT-1 */
        public void R2100_00_GERA_EVENTO_DB_SELECT_1()
        {
            /*" -1878- EXEC SQL SELECT OCORHIST INTO :V0PDVF-OCORHIST FROM SEGUROS.V0PRODUTORVF WHERE CODPDT = :V0PLAC-CODPDT END-EXEC. */

            var r2100_00_GERA_EVENTO_DB_SELECT_1_Query1 = new R2100_00_GERA_EVENTO_DB_SELECT_1_Query1()
            {
                V0PLAC_CODPDT = V0PLAC_CODPDT.ToString(),
            };

            var executed_1 = R2100_00_GERA_EVENTO_DB_SELECT_1_Query1.Execute(r2100_00_GERA_EVENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PDVF_OCORHIST, V0PDVF_OCORHIST);
            }


        }

        [StopWatch]
        /*" R2100-00-GERA-EVENTO-DB-UPDATE-1 */
        public void R2100_00_GERA_EVENTO_DB_UPDATE_1()
        {
            /*" -1891- EXEC SQL UPDATE SEGUROS.V0PRODUTORVF SET OCORHIST = :V0PDVF-OCORHIST WHERE CODPDT = :V0PLAC-CODPDT END-EXEC. */

            var r2100_00_GERA_EVENTO_DB_UPDATE_1_Update1 = new R2100_00_GERA_EVENTO_DB_UPDATE_1_Update1()
            {
                V0PDVF_OCORHIST = V0PDVF_OCORHIST.ToString(),
                V0PLAC_CODPDT = V0PLAC_CODPDT.ToString(),
            };

            R2100_00_GERA_EVENTO_DB_UPDATE_1_Update1.Execute(r2100_00_GERA_EVENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2100-00-GERA-EVENTO-DB-INSERT-1 */
        public void R2100_00_GERA_EVENTO_DB_INSERT_1()
        {
            /*" -1914- EXEC SQL INSERT INTO SEGUROS.V0EVENTOSVF VALUES (:V0PLAC-CODPDT, :V0PDVF-OCORHIST, 0, :V0EVEN-NRCERTIF, :V0EVEN-NRPARCEL, :V0EVEN-CODEVEN, :V0EVEN-CODOPER, :V1SIST-DTMOVABE, :V0EVEN-DTVENCTO, '0' , :V0EVEN-VLPRMTOT, 0, 'VF0851B' , CURRENT TIMESTAMP) END-EXEC. */

            var r2100_00_GERA_EVENTO_DB_INSERT_1_Insert1 = new R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1()
            {
                V0PLAC_CODPDT = V0PLAC_CODPDT.ToString(),
                V0PDVF_OCORHIST = V0PDVF_OCORHIST.ToString(),
                V0EVEN_NRCERTIF = V0EVEN_NRCERTIF.ToString(),
                V0EVEN_NRPARCEL = V0EVEN_NRPARCEL.ToString(),
                V0EVEN_CODEVEN = V0EVEN_CODEVEN.ToString(),
                V0EVEN_CODOPER = V0EVEN_CODOPER.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0EVEN_DTVENCTO = V0EVEN_DTVENCTO.ToString(),
                V0EVEN_VLPRMTOT = V0EVEN_VLPRMTOT.ToString(),
            };

            R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1.Execute(r2100_00_GERA_EVENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-FETCH-SECTION */
        private void R2110_00_FETCH_SECTION()
        {
            /*" -1930- MOVE '2110' TO WNR-EXEC-SQL. */
            _.Move("2110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1933- PERFORM R2110_00_FETCH_DB_FETCH_1 */

            R2110_00_FETCH_DB_FETCH_1();

            /*" -1936- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1937- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1938- MOVE 1 TO WFIM-CPLACOM */
                    _.Move(1, AREA_DE_WORK.WFIM_CPLACOM);

                    /*" -1939- ELSE */
                }
                else
                {


                    /*" -1939- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2110-00-FETCH-DB-FETCH-1 */
        public void R2110_00_FETCH_DB_FETCH_1()
        {
            /*" -1933- EXEC SQL FETCH CPLACOM INTO :V0PLAC-CODPDT END-EXEC. */

            if (CPLACOM.Fetch())
            {
                _.Move(CPLACOM.V0PLAC_CODPDT, V0PLAC_CODPDT);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1951- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1953- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1954- DISPLAY 'LIDOS ' WACC-LIDOS. */
            _.Display($"LIDOS {AREA_DE_WORK.WACC_LIDOS}");

            /*" -1958- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF ' PARCELA ' V0PARC-NRPARCEL ' OCORHIST ' V0PARC-OCORHIST. */

            $"CERTIFICADO {V0PROP_NRCERTIF} PARCELA {V0PARC_NRPARCEL} OCORHIST {V0PARC_OCORHIST}"
            .Display();

            /*" -1958- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1960- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1964- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1964- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}