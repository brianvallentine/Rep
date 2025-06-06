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
using Sias.VidaEmGrupo.DB2.VG1853B;

namespace Code
{
    public class VG1853B
    {
        public bool IsCall { get; set; }

        public VG1853B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDA EM GRUPO / ESPECIFICAS        *      */
        /*"      *   PROGRAMA ...............  VG1853B (VERSAO DO VA0853B)        *      */
        /*"      *                                     (26/12/2001 - FRED)        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  06/10/1997                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   GERA PARCELAS DO NOVO FATURAMENTO PARA APOLICES NOS MOLDES   *      */
        /*"      *   DA SINDUSCON/CE                                              *      */
        /*"      *                       * * * ATENCAO * * *                      *      */
        /*"      *   **** VERIFICAR SE A ALTERACAO EFETUADA NESTE PROGRAMA TERA   *      */
        /*"      *   **** QUE SER EXECUTADA TAMBEM NA SUBROTINA ON-LINE VG0853S.  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *             HISTORICO  DE  ALTERACOES                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               O NUMERO DO CARTAO DE CREDITO FOI ALTERADO NA    *      */
        /*"      *               TABELA OPCAO_PAG_VIDAZUL PARA CHAR(16), POIS O   *      */
        /*"      *               NUMERO QUE O LEGADO RECEBE ESTA MASCARADO COM "*"*      */
        /*"      *               A TABELAS HISTCONTAVA RECEBERA ZEROS.           *       */
        /*"      *   EM 05/08/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD  201.122                                     *      */
        /*"      *               INSERIR COLUNAS NA CLAUSULA INSERT DAS TABELAS   *      */
        /*"      *               HIST_LANC_CTA OU V0HISTCONTAVA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.05             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 20/12/2005 - TERCIO CARVALHO       PROCURE POR TL0512   *      */
        /*"      *   NAO ACUMULA PARCELA                                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 16/12/2005 - TERCIO CARVALHO       PROCURE POR TL0512   *      */
        /*"      *   NAO PRORROGA O VENCIMENTO DA PARCELA                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                           PROCURE POR MM0503   *      */
        /*"      *  003 - 19/05/2003 - MANOEL MESSIAS / FREDERICO FONSECA         *      */
        /*"      *   NAO ESTAVA GERANDO PARCELA, POIS, O RAMO 81 FOI MUDADO PARA  *      */
        /*"      * O RAMO 82, MAS, A CRITICA DOS RAMOS CONTINUAVA.                *      */
        /*"      *                                           PROCURE POR MM0503   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 19/07/2002 - MANOEL MESSIAS                             *      */
        /*"      *   SE O SEGURADO POSSUIR PARCELAS EM ATRASO, AS COLUNAS DA TABE *      */
        /*"      * LA V0PROPOSTAVA, NRPRIPARATZ E QTDPARATZ SERAO ATUALIZADAS.    *      */
        /*"      *                                           PROCURE POR MM0702   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 17/05/2002 - MANOEL MESSIAS                             *      */
        /*"      *   PARA AS APOLICES DOS PRODUTOS EMPRESARIAL E ESPECIFICA, SE A *      */
        /*"      * FORMA DE FATURAMENTO FOR MANUAL ('1') A PARCELA DE COBRANCA SE-*      */
        /*"      * GERADA CANCELADA ('2') PARA QUE O USUARIO INTERVENHA A QUALQUER*      */
        /*"      * MOMENTO PARA LIBERAR A COBRANCA DA PARCELA.                    *      */
        /*"      *                                           PROCURE POR MM0502   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PROPOSTAS VA                        CPROPVA           INPUT    *      */
        /*"      * COBERTURAS PROPOSTA VA              V0COBERPROPVA     INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     OUTPUT   *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DTMOVTO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ESTR-COBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ORIG-PRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-SAF        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-IGPM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-RAMO         PIC S9(004)    COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MOVF-COUNT        PIC S9(009)    COMP.*/
        public IntBasis V0MOVF_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-MIN-DTPROXVEN PIC  X(010).*/
        public StringBasis WHOST_MIN_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-VLPREMIO      PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-NRPARCEL1     PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRPARCEL      PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-PARCELCAP     PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_PARCELCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         DESCON-PERC         PIC S9(003)V9999 COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"77         DESCON-PRMVG        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DESCON-PRMAP        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLPREMIO-W    PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG-W       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP-W       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1SIST-DTVENFIM-CN  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_CN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-DB  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_DB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTTERCOT     PIC  X(010).*/
        public StringBasis V1SIST_DTTERCOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMAXALTIGPM PIC  X(010).*/
        public StringBasis V1SIST_DTMAXALTIGPM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BANC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0SEGV-NUM-ITEM     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGV_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGV-SITUACAO     PIC  X(001).*/
        public StringBasis V0SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COTA-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COTA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HIST-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-DTMOVTO-1YEAR PIC  X(010).*/
        public StringBasis V0HIST_DTMOVTO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0SUBG-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0SUBG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0SUBG-TIPO-FATURA  PIC  X(001).*/
        public StringBasis V0SUBG_TIPO_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SUBG-SIT-REGISTRO PIC  X(001).*/
        public StringBasis V0SUBG_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SUBG-FORMA-FATURA  PIC  X(001).*/
        public StringBasis V0SUBG_FORMA_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PROP-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL-NEW PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL_NEW { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PROP-NRPRIPARATZ  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRMATRFUN    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-INRMATRFUN   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0PROP-DTMINVEN     PIC  X(010).*/
        public StringBasis V0PROP_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO-1YEAR PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-DTADMISSAO   PIC  X(010).*/
        public StringBasis V0PROP_DTADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RCDG-DTREFER      PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RCDG-SITUACAO     PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0CDGC-VLCUSTCDG    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0PRDVG-ORIG-PRODU         PIC  X(10).*/
        public StringBasis V0PRDVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0PRDVG-ESTR-COBR          PIC  X(10).*/
        public StringBasis V0PRDVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0PRDVG-COBERADIC-PREMIO   PIC  X(01).*/
        public StringBasis V0PRDVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-CUSTOCAP-TOTAL     PIC  X(01).*/
        public StringBasis V0PRDVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-SAF            PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-IGPM           PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-OPCAOCAP           PIC S9(004) COMP.*/
        public IntBasis V0PRDVG_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRDVG-CODPRODAZ          PIC  X(003).*/
        public StringBasis V0PRDVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0RSAF-DTREFER      PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-SITUACAO     PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0RSAF-CODOPER      PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0SAFC-VLCUSTSAF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0OPCP-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-PERIPGTO-ANT PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-DIA-DEBITO   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-AGECTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPRCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-NUMCTADEB    PIC  X(013)      VALUE SPACES.*/
        public StringBasis V0OPCP_NUMCTADEB { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
        /*"77         V0OPCP-DIGCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDAGE       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDOPR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDNUM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDDIG       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-CARTAO-CRED  PIC  X(016)      VALUE SPACES.*/
        public StringBasis V0OPCP_CARTAO_CRED { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
        /*"77         V0COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG-NEW  PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG_NEW { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG-NEW2 PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG_NEW2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG-ORIG PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG_ORIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG-PARC PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBP-VLPREMIO     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCAP    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCDG    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTAUXF   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-IVLCUSTAUXF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-QTTITCAP     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         HISCOBPR-NUM-CERTIFICADO     PIC S9(15)       COMP-3.*/
        public IntBasis HISCOBPR_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77         HISCOBPR-OCORR-HISTORICO     PIC S9(4)        COMP.*/
        public IntBasis HISCOBPR_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         HISCOBPR-DATA-INIVIGENCIA    PIC X(10).*/
        public StringBasis HISCOBPR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         HISCOBPR-DATA-TERVIGENCIA    PIC X(10).*/
        public StringBasis HISCOBPR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         HISCOBPR-IMPSEGUR            PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-QUANT-VIDAS         PIC S9(9)        COMP.*/
        public IntBasis HISCOBPR_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77         HISCOBPR-IMPSEGIND           PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-COD-OPERACAO        PIC S9(4)        COMP.*/
        public IntBasis HISCOBPR_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         HISCOBPR-OPCAO-COBERTURA     PIC X(1).*/
        public StringBasis HISCOBPR_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77         HISCOBPR-IMP-MORNATU         PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPMORACID          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPINVPERM          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPAMDS             PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPDH               PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPDIT              PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VLPREMIO            PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-PRMVG               PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-PRMAP               PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-QTDE-TIT-CAPITALIZ  PIC S9(4)        COMP.*/
        public IntBasis HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         HISCOBPR-VAL-TIT-CAPITALIZ   PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VAL-CUSTO-CAPITALI  PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPSEGCDG           PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VLCUSTCDG           PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-COD-USUARIO         PIC X(8).*/
        public StringBasis HISCOBPR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77         HISCOBPR-IMPSEGAUXF          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPSEGAUXF-I        PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-VLCUSTAUXF          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VLCUSTAUXF-I        PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-PRMDIT              PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-PRMDIT-I            PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-QTMDIT              PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-QTMDIT-I            PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_QTMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0PARC-DTVENCTO-PAR PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO_PAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMTOTANT    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V3DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V3DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         HOST-CODCONV        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CODCONV      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CCRED        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HICB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HICB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HICB-SITUACAO     PIC  X(001).*/
        public StringBasis V0HICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HICB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-DTVENCTO     PIC  X(010).*/
        public StringBasis V0RELA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HCTA-NSAS         PIC S9(004) COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCTA-SITUACAO     PIC  X(001).*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  TABELA-ULTIMOS-DIAS.*/
        public VG1853B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG1853B_TABELA_ULTIMOS_DIAS();
        public class VG1853B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 FILLER                      PIC  X(024)  VALUE                                  '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01  TAB-ULTIMOS-DIAS               REDEFINES                                   TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG1853B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG1853B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG1853B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG1853B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 TAB-DIA-MESES               OCCURS 12.*/
            public ListBasis<VG1853B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG1853B_TAB_DIA_MESES>(12);
            public class VG1853B_TAB_DIA_MESES : VarBasis
            {
                /*"      07 TAB-DIA-MES               PIC  9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  CONT-ATRASO                 PIC  9(005)   VALUE ZEROS.*/

                public VG1853B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG1853B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis CONT_ATRASO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  PROX-PARCELA                PIC S9(004) COMP VALUE ZEROS.*/
        public IntBasis PROX_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CHAVE-FIM                   PIC  X(001)   VALUE SPACES.*/
        public StringBasis CHAVE_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  HOST-PARCELA-ATRASO         PIC S9(004) COMP VALUE ZEROS.*/
        public IntBasis HOST_PARCELA_ATRASO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WPRI-PARCELA                PIC  9(001)   VALUE ZEROS.*/
        public IntBasis WPRI_PARCELA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  W-IGPM-CADASTRADO           PIC  X(001)   VALUE SPACES.*/
        public StringBasis W_IGPM_CADASTRADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VG1853B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_VG1853B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_VG1853B_FILLER_1(); _.Move(W_NUMR_TITULO, _filler_1); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_1, W_NUMR_TITULO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NUMR_TITULO); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VG1853B_FILLER_1 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_VG1853B_FILLER_1()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VG1853B_DPARM01X DPARM01X { get; set; } = new VG1853B_DPARM01X();
        public class VG1853B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VG1853B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VG1853B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VG1853B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VG1853B_DPARM01_R : VarBasis
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

                public _REDEF_VG1853B_DPARM01_R()
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
        public VG1853B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG1853B_AREA_DE_WORK();
        public class VG1853B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WANO-BISSEXTO     PIC  9(004).*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WACC-COMMIT       PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WFIM-CPROPVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WREGULARIZOU    PIC X(001)  VALUE SPACES.*/
            public StringBasis WREGULARIZOU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WNSAS           PIC 9(005).*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05         WDATA-SISTEMA.*/
            public VG1853B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VG1853B_WDATA_SISTEMA();
            public class VG1853B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-PRIMEIRA.*/
            }
            public VG1853B_WDATA_PRIMEIRA WDATA_PRIMEIRA { get; set; } = new VG1853B_WDATA_PRIMEIRA();
            public class VG1853B_WDATA_PRIMEIRA : VarBasis
            {
                /*"    10       WDATA-PRI-ANO     PIC  9(004).*/
                public IntBasis WDATA_PRI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-MES     PIC  9(002).*/
                public IntBasis WDATA_PRI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-DIA     PIC  9(002).*/
                public IntBasis WDATA_PRI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VG1853B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VG1853B_WDATA_VIGENCIA();
            public class VG1853B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002).*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA1.*/
            }
            public VG1853B_WDATA_VIGENCIA1 WDATA_VIGENCIA1 { get; set; } = new VG1853B_WDATA_VIGENCIA1();
            public class VG1853B_WDATA_VIGENCIA1 : VarBasis
            {
                /*"    10       WDATA-VIG-ANO1    PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES1    PIC  9(002).*/
                public IntBasis WDATA_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA1    PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VENCIMENTO.*/
            }
            public VG1853B_WDATA_VENCIMENTO WDATA_VENCIMENTO { get; set; } = new VG1853B_WDATA_VENCIMENTO();
            public class VG1853B_WDATA_VENCIMENTO : VarBasis
            {
                /*"    10       WDATA-VCT-ANO     PIC  9(004).*/
                public IntBasis WDATA_VCT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-MES     PIC  9(002).*/
                public IntBasis WDATA_VCT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-DIA     PIC  9(002).*/
                public IntBasis WDATA_VCT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W01DTSQL.*/
            }
            public VG1853B_W01DTSQL W01DTSQL { get; set; } = new VG1853B_W01DTSQL();
            public class VG1853B_W01DTSQL : VarBasis
            {
                /*"    10       W01AASQL          PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W01T1SQL          PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01MMSQL          PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01T2SQL          PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01DDSQL          PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W02DTSQL.*/
            }
            public VG1853B_W02DTSQL W02DTSQL { get; set; } = new VG1853B_W02DTSQL();
            public class VG1853B_W02DTSQL : VarBasis
            {
                /*"    10       W02AASQL          PIC 9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W02T1SQL          PIC X(001).*/
                public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W02MMSQL          PIC 9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02T2SQL          PIC X(001).*/
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W02DDSQL          PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
            }
            public VG1853B_WABEND WABEND { get; set; } = new VG1853B_WABEND();
            public class VG1853B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG1853B '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG1853B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public VG1853B_CPROPVA CPROPVA { get; set; } = new VG1853B_CPROPVA();
        public VG1853B_CATRASO CATRASO { get; set; } = new VG1853B_CATRASO();
        public VG1853B_CDIFPAR CDIFPAR { get; set; } = new VG1853B_CDIFPAR();
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
            /*" -498- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -501- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -504- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -507- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -508- DISPLAY 'PROGRAMA EM EXECUCAO VG1853B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VG1853B   ");

            /*" -509- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -512- DISPLAY 'VERSAO V.07 CIELO  ' FUNCTION WHEN-COMPILED */

            $"VERSAO V.07 CIELO  FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -514- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -515- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -517- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -528- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -531- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -532- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                _.Display($"ERRO SELECT V1SISTEMA VA");

                /*" -538- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -539- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -541- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -542- MOVE V1SIST-DTTERCOT TO W01DTSQL. */
            _.Move(V1SIST_DTTERCOT, AREA_DE_WORK.W01DTSQL);

            /*" -543- MOVE 01 TO W01DDSQL. */
            _.Move(01, AREA_DE_WORK.W01DTSQL.W01DDSQL);

            /*" -549- MOVE W01DTSQL TO V1SIST-DTTERCOT. */
            _.Move(AREA_DE_WORK.W01DTSQL, V1SIST_DTTERCOT);

            /*" -550- MOVE V1SIST-DTMOVABE TO W01DTSQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.W01DTSQL);

            /*" -551- MOVE 01 TO W01DDSQL. */
            _.Move(01, AREA_DE_WORK.W01DTSQL.W01DDSQL);

            /*" -553- MOVE W01DTSQL TO V1SIST-DTMAXALTIGPM. */
            _.Move(AREA_DE_WORK.W01DTSQL, V1SIST_DTMAXALTIGPM);

            /*" -554- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -556- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -562- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -565- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -566- MOVE 'S' TO W-IGPM-CADASTRADO */
                _.Move("S", W_IGPM_CADASTRADO);

                /*" -567- ELSE */
            }
            else
            {


                /*" -569- MOVE 'N' TO W-IGPM-CADASTRADO. */
                _.Move("N", W_IGPM_CADASTRADO);
            }


            /*" -570- MOVE 'A003' TO WNR-EXEC-SQL. */
            _.Move("A003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -572- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -577- PERFORM R0000_00_PRINCIPAL_DB_SELECT_3 */

            R0000_00_PRINCIPAL_DB_SELECT_3();

            /*" -580- MOVE 'B003' TO WNR-EXEC-SQL. */
            _.Move("B003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -582- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -612- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -616- DISPLAY '*** VG1853B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG1853B *** ABRINDO CURSOR ...");

            /*" -617- MOVE 'C003' TO WNR-EXEC-SQL. */
            _.Move("C003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -617- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -620- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -622- DISPLAY 'PROBLEMAS NO OPEN (CPROPVA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVA   ) ... ");

                /*" -624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -626- DISPLAY '*** VG1853B *** PROCESSANDO ... ' . */
            _.Display($"*** VG1853B *** PROCESSANDO ... ");

            /*" -628- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

            /*" -629- IF WFIM-CPROPVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty())
            {

                /*" -631- DISPLAY '*** VG1853B *** NENHUMA PARCELA A PROCESSAR' */
                _.Display($"*** VG1853B *** NENHUMA PARCELA A PROCESSAR");

                /*" -633- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -634- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -636- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -641- PERFORM R0000_00_PRINCIPAL_DB_SELECT_4 */

            R0000_00_PRINCIPAL_DB_SELECT_4();

            /*" -644- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -645- DISPLAY 'BANCO NAO CADASTRADO (V0BANCO) 104 ' */
                _.Display($"BANCO NAO CADASTRADO (V0BANCO) 104 ");

                /*" -647- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -649- MOVE V0BANC-NRTIT TO W-NUMR-TITULO. */
            _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

            /*" -652- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CPROPVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -653- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -655- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -660- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_1 */

            R0000_00_PRINCIPAL_DB_UPDATE_1();

            /*" -663- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -664- DISPLAY 'R0000 - ERRO UPDATE V0BANCO 104' */
                _.Display($"R0000 - ERRO UPDATE V0BANCO 104");

                /*" -666- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -667- DISPLAY 'PROPOSTAS LIDAS ............ ' WACC-LIDOS. */
            _.Display($"PROPOSTAS LIDAS ............ {AREA_DE_WORK.WACC_LIDOS}");

            /*" -669- DISPLAY 'PARCELAS GERADAS ........... ' WACC-GRAVADOS. */
            _.Display($"PARCELAS GERADAS ........... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -670- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -674- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -674- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -528- EXEC SQL SELECT CURRENT DATE + 20 DAYS, CURRENT DATE + 1 DAY, DTMOVABE, DTMOVABE - 1 MONTH INTO :V1SIST-DTVENFIM-CN, :V1SIST-DTVENFIM-DB, :V1SIST-DTMOVABE, :V1SIST-DTTERCOT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTVENFIM_CN, V1SIST_DTVENFIM_CN);
                _.Move(executed_1.V1SIST_DTVENFIM_DB, V1SIST_DTVENFIM_DB);
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTTERCOT, V1SIST_DTTERCOT);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -680- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -681- DISPLAY ' ' */
            _.Display($" ");

            /*" -683- DISPLAY '*--------  VG1853B - FIM NORMAL  --------*' */
            _.Display($"*--------  VG1853B - FIM NORMAL  --------*");

            /*" -683- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -562- EXEC SQL SELECT DTINIVIG INTO :V0COTA-DTINIVIG FROM SEGUROS.V0COTACAO WHERE CODUNIMO = 23 AND DTINIVIG = :V1SIST-DTTERCOT END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
                V1SIST_DTTERCOT = V1SIST_DTTERCOT.ToString(),
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTA_DTINIVIG, V0COTA_DTINIVIG);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -612- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT A.NUM_APOLICE, A.CODSUBES, A.NRCERTIF, A.CODPRODU, A.CODCLIEN, A.NRPARCE, A.SITUACAO, A.DTQITBCO, A.DTVENCTO, A.DTPROXVEN, A.NRPRIPARATZ, A.QTDPARATZ, A.NUM_MATRICULA, A.TIMESTAMP, A.DTQITBCO + 1 MONTH, A.DTQITBCO + 1 YEAR, A.CODOPER, VALUE(A.DATA_ADMISSAO, DATE( '1900-01-01' )), A.OCORHIST FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.DTPROXVEN BETWEEN :WHOST-MIN-DTPROXVEN AND :V1SIST-DTVENFIM-CN AND A.SITUACAO IN ( '3' , '6' ) AND A.DTPROXVEN <> '9999-12-31' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.ORIG_PRODU = 'ESPE1' END-EXEC. */
            CPROPVA = new VG1853B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.NRCERTIF
							, 
							A.CODPRODU
							, 
							A.CODCLIEN
							, 
							A.NRPARCE
							, 
							A.SITUACAO
							, 
							A.DTQITBCO
							, 
							A.DTVENCTO
							, 
							A.DTPROXVEN
							, 
							A.NRPRIPARATZ
							, 
							A.QTDPARATZ
							, 
							A.NUM_MATRICULA
							, 
							A.TIMESTAMP
							, 
							A.DTQITBCO + 1 MONTH
							, 
							A.DTQITBCO + 1 YEAR
							, 
							A.CODOPER
							, 
							VALUE(A.DATA_ADMISSAO
							, DATE( '1900-01-01' ))
							, 
							A.OCORHIST 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0PRODUTOSVG B 
							WHERE A.DTPROXVEN BETWEEN '{WHOST_MIN_DTPROXVEN}' 
							AND '{V1SIST_DTVENFIM_CN}' 
							AND A.SITUACAO IN ( '3'
							, '6' ) 
							AND A.DTPROXVEN <> '9999-12-31' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.ORIG_PRODU = 'ESPE1'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -617- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-DECLARE-1 */
        public void R1000_10_LEITURA_RAMO_DB_DECLARE_1()
        {
            /*" -957- EXEC SQL DECLARE CATRASO CURSOR FOR SELECT NRPARCEL FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND SITUACAO = ' ' ORDER BY NRPARCEL END-EXEC. */
            CATRASO = new VG1853B_CATRASO(true);
            string GetQuery_CATRASO()
            {
                var query = @$"SELECT NRPARCEL 
							FROM SEGUROS.V0PARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND SITUACAO = ' ' 
							ORDER BY NRPARCEL";

                return query;
            }
            CATRASO.GetQueryEvent += GetQuery_CATRASO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-1 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -660- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_UPDATE_1_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_1_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-3 */
        public void R0000_00_PRINCIPAL_DB_SELECT_3()
        {
            /*" -577- EXEC SQL SELECT VALUE(MIN(DTPROXVEN),DATE( '1999-12-31' )) INTO :WHOST-MIN-DTPROXVEN FROM SEGUROS.V0PROPOSTAVA WHERE SITUACAO IN ( '3' , '6' ) END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_3_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_3_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MIN_DTPROXVEN, WHOST_MIN_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-SECTION */
        private void R0910_00_FETCH_CPROPVA_SECTION()
        {
            /*" -693- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -695- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R0910_00_FETCH_CPROPVA_DB_FETCH_1 */

            R0910_00_FETCH_CPROPVA_DB_FETCH_1();

            /*" -718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -719- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -719- PERFORM R0910_00_FETCH_CPROPVA_DB_CLOSE_1 */

                    R0910_00_FETCH_CPROPVA_DB_CLOSE_1();

                    /*" -721- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -722- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -723- ELSE */
                }
                else
                {


                    /*" -724- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPVA   )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPVA   )...");

                    /*" -726- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -727- IF V0PROP-INRMATRFUN LESS 0 */

            if (V0PROP_INRMATRFUN < 0)
            {

                /*" -729- MOVE 0 TO V0PROP-NRMATRFUN. */
                _.Move(0, V0PROP_NRMATRFUN);
            }


            /*" -730- ADD 1 TO WACC-LIDOS WACC-COMMIT. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_COMMIT.Value = AREA_DE_WORK.WACC_COMMIT + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-FETCH-1 */
        public void R0910_00_FETCH_CPROPVA_DB_FETCH_1()
        {
            /*" -715- EXEC SQL FETCH CPROPVA INTO :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-NRPRIPARATZ, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN, :V0PROP-TIMESTAMP, :V0PROP-DTMINVEN, :V0PROP-DTQITBCO-1YEAR, :V0PROP-CODOPER, :V0PROP-DTADMISSAO, :V0PROP-OCORHIST END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPVA.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPVA.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(CPROPVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVA.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPVA.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(CPROPVA.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(CPROPVA.V0PROP_NRPRIPARATZ, V0PROP_NRPRIPARATZ);
                _.Move(CPROPVA.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(CPROPVA.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(CPROPVA.V0PROP_INRMATRFUN, V0PROP_INRMATRFUN);
                _.Move(CPROPVA.V0PROP_TIMESTAMP, V0PROP_TIMESTAMP);
                _.Move(CPROPVA.V0PROP_DTMINVEN, V0PROP_DTMINVEN);
                _.Move(CPROPVA.V0PROP_DTQITBCO_1YEAR, V0PROP_DTQITBCO_1YEAR);
                _.Move(CPROPVA.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPVA.V0PROP_DTADMISSAO, V0PROP_DTADMISSAO);
                _.Move(CPROPVA.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_CPROPVA_DB_CLOSE_1()
        {
            /*" -719- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-4 */
        public void R0000_00_PRINCIPAL_DB_SELECT_4()
        {
            /*" -641- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_4_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_4_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_4_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -744- MOVE '100P' TO WNR-EXEC-SQL. */
            _.Move("100P", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -745- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -751- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -754- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -755- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -756- ELSE */
            }
            else
            {


                /*" -758- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -759- ELSE */
                }
                else
                {


                    /*" -761- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -762- MOVE '100Z' TO WNR-EXEC-SQL. */
            _.Move("100Z", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -764- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -777- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -780- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -781- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -782- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -783- ELSE */
                }
                else
                {


                    /*" -785- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -786- MOVE ' ' TO V0PRDVG-ESTR-COBR. */
            _.Move(" ", V0PRDVG_ESTR_COBR);

            /*" -787- MOVE ' ' TO V0PRDVG-ORIG-PRODU. */
            _.Move(" ", V0PRDVG_ORIG_PRODU);

            /*" -788- MOVE 'N' TO V0PRDVG-TEM-SAF. */
            _.Move("N", V0PRDVG_TEM_SAF);

            /*" -790- MOVE 'N' TO V0PRDVG-TEM-IGPM. */
            _.Move("N", V0PRDVG_TEM_IGPM);

            /*" -791- MOVE '100Y' TO WNR-EXEC-SQL. */
            _.Move("100Y", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -793- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -813- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -817- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -818- DISPLAY 'APOLICE ...' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE ...{V0PROP_NUM_APOLICE}");

                /*" -819- DISPLAY 'SUBGRUPO...' V0PROP-CODSUBES */
                _.Display($"SUBGRUPO...{V0PROP_CODSUBES}");

                /*" -825- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -826- IF V0SUBG-SIT-REGISTRO EQUAL '2' */

            if (V0SUBG_SIT_REGISTRO == "2")
            {

                /*" -828- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

            }


            /*" -832- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -834- MOVE ' ' TO V0PRDVG-ORIG-PRODU. */
                _.Move(" ", V0PRDVG_ORIG_PRODU);
            }


            /*" -835- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -837- MOVE 'N' TO V0PRDVG-TEM-SAF. */
                _.Move("N", V0PRDVG_TEM_SAF);
            }


            /*" -838- IF VIND-TEM-IGPM LESS 0 */

            if (VIND_TEM_IGPM < 0)
            {

                /*" -840- MOVE 'N' TO V0PRDVG-TEM-IGPM. */
                _.Move("N", V0PRDVG_TEM_IGPM);
            }


            /*" -841- IF V0PRDVG-ORIG-PRODU NOT EQUAL 'ESPE1' */

            if (V0PRDVG_ORIG_PRODU != "ESPE1")
            {

                /*" -846- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -847- IF V0PRDVG-ORIG-PRODU EQUAL 'ESPE1' */

            if (V0PRDVG_ORIG_PRODU == "ESPE1")
            {

                /*" -849- IF V0SUBG-FORMA-FATURA EQUAL '2' NEXT SENTENCE */

                if (V0SUBG_FORMA_FATURA == "2")
                {

                    /*" -850- ELSE */
                }
                else
                {


                    /*" -856- GO TO R1000-90-LEITURA. */

                    R1000_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -857- IF V0SUBG-TIPO-FATURA EQUAL '2' */

            if (V0SUBG_TIPO_FATURA == "2")
            {

                /*" -858- IF V0PROP-CODSUBES = 0 */

                if (V0PROP_CODSUBES == 0)
                {

                    /*" -859- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -861- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -862- ELSE */
                }

            }
            else
            {


                /*" -863- IF V0SUBG-TIPO-FATURA EQUAL '1' OR '3' */

                if (V0SUBG_TIPO_FATURA.In("1", "3"))
                {

                    /*" -865- IF V0PROP-CODSUBES = 0 NEXT SENTENCE */

                    if (V0PROP_CODSUBES == 0)
                    {

                        /*" -866- ELSE */
                    }
                    else
                    {


                        /*" -867- GO TO R1000-90-LEITURA */

                        R1000_90_LEITURA(); //GOTO
                        return;

                        /*" -868- ELSE */
                    }

                }
                else
                {


                    /*" -872- DISPLAY 'TIPO DE FATURAMENTO INVALIDO ' V0SUBG-TIPO-FATURA ' ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES */

                    $"TIPO DE FATURAMENTO INVALIDO {V0SUBG_TIPO_FATURA} {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES}"
                    .Display();

                    /*" -872- GO TO R1000-90-LEITURA. */

                    R1000_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA_RAMO */

            R1000_10_LEITURA_RAMO();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -751- EXEC SQL SELECT NRPARCEL INTO :WHOST-NRPARCEL1 FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-OCORHIST END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRPARCEL1, WHOST_NRPARCEL1);
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO */
        private void R1000_10_LEITURA_RAMO(bool isPerform = false)
        {
            /*" -877- MOVE '100A' TO WNR-EXEC-SQL. */
            _.Move("100A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -879- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -884- PERFORM R1000_10_LEITURA_RAMO_DB_SELECT_1 */

            R1000_10_LEITURA_RAMO_DB_SELECT_1();

            /*" -887- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -888- DISPLAY 'APOLICE  ' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE  {V0PROP_NUM_APOLICE}");

                /*" -893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -894- MOVE '100B' TO WNR-EXEC-SQL. */
            _.Move("100B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -896- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -902- PERFORM R1000_10_LEITURA_RAMO_DB_SELECT_2 */

            R1000_10_LEITURA_RAMO_DB_SELECT_2();

            /*" -905- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -906- DISPLAY 'ERRO ACESSO ENDOSSO ' */
                _.Display($"ERRO ACESSO ENDOSSO ");

                /*" -907- DISPLAY 'APOLICE  ' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE  {V0PROP_NUM_APOLICE}");

                /*" -909- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -910- IF V0ENDO-DTTERVIG LESS V0PROP-DTPROXVEN */

            if (V0ENDO_DTTERVIG < V0PROP_DTPROXVEN)
            {

                /*" -912- DISPLAY 'APOLICE COM VIGENCIA EXPIRADA - ' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE COM VIGENCIA EXPIRADA - {V0PROP_NUM_APOLICE}");

                /*" -914- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -916- MOVE V0PROP-DTQITBCO TO WDATA-PRIMEIRA. */
            _.Move(V0PROP_DTQITBCO, AREA_DE_WORK.WDATA_PRIMEIRA);

            /*" -917- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -919- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -925- PERFORM R1000_10_LEITURA_RAMO_DB_SELECT_3 */

            R1000_10_LEITURA_RAMO_DB_SELECT_3();

            /*" -928- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -929- DISPLAY 'R1000-00 (ERRO - SELECT V0CONVENIOSVG)' */
                _.Display($"R1000-00 (ERRO - SELECT V0CONVENIOSVG)");

                /*" -932- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'APOL...: ' V0PROP-NUM-APOLICE 'SUBGRUP: ' V0PROP-CODSUBES */

                $"CERTIF: {V0PROP_NRCERTIF}  APOL...: {V0PROP_NUM_APOLICE}SUBGRUP: {V0PROP_CODSUBES}"
                .Display();

                /*" -934- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -935- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -936- MOVE 9019 TO V0CONV-CCRED */
                _.Move(9019, V0CONV_CCRED);

                /*" -938- MOVE 6088 TO V0CONV-CODCONV. */
                _.Move(6088, V0CONV_CODCONV);
            }


            /*" -939- IF V0PROP-DTPROXVEN EQUAL '9999-12-31' */

            if (V0PROP_DTPROXVEN == "9999-12-31")
            {

                /*" -941- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -943- MOVE V0PROP-DTPROXVEN TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -946- MOVE ZEROS TO CONT-ATRASO PROX-PARCELA. */
            _.Move(0, CONT_ATRASO, PROX_PARCELA);

            /*" -948- MOVE 'N' TO CHAVE-FIM. */
            _.Move("N", CHAVE_FIM);

            /*" -949- MOVE '1011' TO WNR-EXEC-SQL. */
            _.Move("1011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -950- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -957- PERFORM R1000_10_LEITURA_RAMO_DB_DECLARE_1 */

            R1000_10_LEITURA_RAMO_DB_DECLARE_1();

            /*" -960- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -962- DISPLAY 'ERRO NA BUSCA DA PARCELA EM ATRASO' V0PROP-NRCERTIF */
                _.Display($"ERRO NA BUSCA DA PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                /*" -964- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -966- PERFORM R1000_10_LEITURA_RAMO_DB_OPEN_1 */

            R1000_10_LEITURA_RAMO_DB_OPEN_1();

            /*" -969- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -971- DISPLAY 'ERRO NO OPEN  DA PARCELA EM ATRASO' V0PROP-NRCERTIF */
                _.Display($"ERRO NO OPEN  DA PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                /*" -973- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -977- PERFORM R1000_10_LEITURA_RAMO_DB_FETCH_1 */

            R1000_10_LEITURA_RAMO_DB_FETCH_1();

            /*" -980- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -981- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -981- PERFORM R1000_10_LEITURA_RAMO_DB_CLOSE_1 */

                    R1000_10_LEITURA_RAMO_DB_CLOSE_1();

                    /*" -983- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -984- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -985- END-IF */
                    }


                    /*" -986- MOVE 'S' TO CHAVE-FIM */
                    _.Move("S", CHAVE_FIM);

                    /*" -987- MOVE ZEROS TO CONT-ATRASO */
                    _.Move(0, CONT_ATRASO);

                    /*" -988- MOVE ZEROS TO V0PROP-NRPRIPARATZ */
                    _.Move(0, V0PROP_NRPRIPARATZ);

                    /*" -989- ELSE */
                }
                else
                {


                    /*" -991- DISPLAY 'ERRO NA BUSCA DA PARCELA EM ATRASO' V0PROP-NRCERTIF */
                    _.Display($"ERRO NA BUSCA DA PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                    /*" -992- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -993- ELSE */
                }

            }
            else
            {


                /*" -994- MOVE HOST-PARCELA-ATRASO TO V0PROP-NRPRIPARATZ */
                _.Move(HOST_PARCELA_ATRASO, V0PROP_NRPRIPARATZ);

                /*" -995- ADD 1 TO CONT-ATRASO */
                CONT_ATRASO.Value = CONT_ATRASO + 1;

                /*" -996- COMPUTE PROX-PARCELA = HOST-PARCELA-ATRASO + 1 */
                PROX_PARCELA.Value = HOST_PARCELA_ATRASO + 1;

                /*" -998- PERFORM R1010-00-FETCH-PARCELAS-ATRASO. */

                R1010_00_FETCH_PARCELAS_ATRASO_SECTION();
            }


            /*" -1001- PERFORM R1020-00-PROC-PARCELAS-ATRASO UNTIL CHAVE-FIM = 'S' OR CONT-ATRASO > 2. */

            while (!(CHAVE_FIM == "S" || CONT_ATRASO > 2))
            {

                R1020_00_PROC_PARCELAS_ATRASO_SECTION();
            }

            /*" -1003- MOVE CONT-ATRASO TO V0PROP-QTDPARATZ */
            _.Move(CONT_ATRASO, V0PROP_QTDPARATZ);

            /*" -1005- IF CONT-ATRASO > 2 AND CHAVE-FIM = 'N' */

            if (CONT_ATRASO > 2 && CHAVE_FIM == "N")
            {

                /*" -1005- PERFORM R1000_10_LEITURA_RAMO_DB_CLOSE_2 */

                R1000_10_LEITURA_RAMO_DB_CLOSE_2();

                /*" -1007- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1009- DISPLAY 'ERRO NO FECHAMENTO DO CURSOR CATRASO ' V0PROP-NRCERTIF */
                    _.Display($"ERRO NO FECHAMENTO DO CURSOR CATRASO {V0PROP_NRCERTIF}");

                    /*" -1010- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1011- END-IF */
                }


                /*" -1012- MOVE 'S' TO CHAVE-FIM */
                _.Move("S", CHAVE_FIM);

                /*" -1014- END-IF */
            }


            /*" -1017- PERFORM R1200-00-GERA-PARCELAS UNTIL V0PROP-DTPROXVEN GREATER V1SIST-DTVENFIM-CN. */

            while (!(V0PROP_DTPROXVEN > V1SIST_DTVENFIM_CN))
            {

                R1200_00_GERA_PARCELAS_SECTION();
            }

            /*" -1018- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1020- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1031- PERFORM R1000_10_LEITURA_RAMO_DB_UPDATE_1 */

            R1000_10_LEITURA_RAMO_DB_UPDATE_1();

            /*" -1034- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1035- DISPLAY 'R1000-00 (ERRO - UPDATE CPROPVA   )' */
                _.Display($"R1000-00 (ERRO - UPDATE CPROPVA   )");

                /*" -1036- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1036- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-SELECT-1 */
        public void R1000_10_LEITURA_RAMO_DB_SELECT_1()
        {
            /*" -884- EXEC SQL SELECT RAMO INTO :V0APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_SELECT_1_Query1 = new R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1.Execute(r1000_10_LEITURA_RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -777- EXEC SQL SELECT NUM_APOLICE, SIT_REGISTRO, TIPO_FATURAMENTO, FORMA_FATURAMENTO INTO :V0SUBG-NUM-APOLICE, :V0SUBG-SIT-REGISTRO, :V0SUBG-TIPO-FATURA, :V0SUBG-FORMA-FATURA FROM SEGUROS.V0SUBGRUPO WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_NUM_APOLICE, V0SUBG_NUM_APOLICE);
                _.Move(executed_1.V0SUBG_SIT_REGISTRO, V0SUBG_SIT_REGISTRO);
                _.Move(executed_1.V0SUBG_TIPO_FATURA, V0SUBG_TIPO_FATURA);
                _.Move(executed_1.V0SUBG_FORMA_FATURA, V0SUBG_FORMA_FATURA);
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-SELECT-2 */
        public void R1000_10_LEITURA_RAMO_DB_SELECT_2()
        {
            /*" -902- EXEC SQL SELECT DTTERVIG INTO :V0ENDO-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_SELECT_2_Query1 = new R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1.Execute(r1000_10_LEITURA_RAMO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-OPEN-1 */
        public void R1000_10_LEITURA_RAMO_DB_OPEN_1()
        {
            /*" -966- EXEC SQL OPEN CATRASO END-EXEC. */

            CATRASO.Open();

        }

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-DB-DECLARE-1 */
        public void R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1()
        {
            /*" -1533- EXEC SQL DECLARE CDIFPAR CURSOR FOR SELECT NRPARCEL, CODOPER, PRMDIFVG + PRMDIFAP, PRMDIFVG, PRMDIFAP FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTVENCTO <= :V0PROP-DTVENCTO AND SITUACAO = ' ' FOR UPDATE OF NRPARCEL, CODOPER END-EXEC. */
            CDIFPAR = new VG1853B_CDIFPAR(true);
            string GetQuery_CDIFPAR()
            {
                var query = @$"SELECT NRPARCEL
							, 
							CODOPER
							, 
							PRMDIFVG + PRMDIFAP
							, 
							PRMDIFVG
							, 
							PRMDIFAP 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND DTVENCTO <= '{V0PROP_DTVENCTO}' 
							AND SITUACAO = ' '";

                return query;
            }
            CDIFPAR.GetQueryEvent += GetQuery_CDIFPAR;

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-FETCH-1 */
        public void R1000_10_LEITURA_RAMO_DB_FETCH_1()
        {
            /*" -977- EXEC SQL FETCH CATRASO INTO :HOST-PARCELA-ATRASO END-EXEC. */

            if (CATRASO.Fetch())
            {
                _.Move(CATRASO.HOST_PARCELA_ATRASO, HOST_PARCELA_ATRASO);
            }

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-CLOSE-1 */
        public void R1000_10_LEITURA_RAMO_DB_CLOSE_1()
        {
            /*" -981- EXEC SQL CLOSE CATRASO END-EXEC */

            CATRASO.Close();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1041- IF WACC-COMMIT GREATER 100 */

            if (AREA_DE_WORK.WACC_COMMIT > 100)
            {

                /*" -1042- DISPLAY 'LIDOS ATE AGORA ............' WACC-LIDOS */
                _.Display($"LIDOS ATE AGORA ............{AREA_DE_WORK.WACC_LIDOS}");

                /*" -1044- MOVE ZEROES TO WACC-COMMIT. */
                _.Move(0, AREA_DE_WORK.WACC_COMMIT);
            }


            /*" -1044- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-UPDATE-1 */
        public void R1000_10_LEITURA_RAMO_DB_UPDATE_1()
        {
            /*" -1031- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET NRPARCE = :V0PROP-NRPARCEL, SITUACAO = :V0PROP-SITUACAO, DTVENCTO = :V0PROP-DTVENCTO, DTPROXVEN = :V0PROP-DTPROXVEN, NRPRIPARATZ = :V0PROP-NRPRIPARATZ, QTDPARATZ = :V0PROP-QTDPARATZ, OCORHIST = :V0PROP-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 = new R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1()
            {
                V0PROP_NRPRIPARATZ = V0PROP_NRPRIPARATZ.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_SITUACAO = V0PROP_SITUACAO.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1.Execute(r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-CLOSE-2 */
        public void R1000_10_LEITURA_RAMO_DB_CLOSE_2()
        {
            /*" -1005- EXEC SQL CLOSE CATRASO END-EXEC */

            CATRASO.Close();

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-SELECT-3 */
        public void R1000_10_LEITURA_RAMO_DB_SELECT_3()
        {
            /*" -925- EXEC SQL SELECT COD_SEGURO, COD_CONV_CARTAO INTO :V0CONV-CODCONV, :V0CONV-CCRED FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_SELECT_3_Query1 = new R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1.Execute(r1000_10_LEITURA_RAMO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
                _.Move(executed_1.V0CONV_CCRED, V0CONV_CCRED);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -813- EXEC SQL SELECT ESTR_COBR, ORIG_PRODU, TEM_SAF, TEM_IGPM, CODPRODAZ, OPCAOCAP, COBERADIC_PREMIO, CUSTOCAP_TOTAL INTO :V0PRDVG-ESTR-COBR:VIND-ESTR-COBR, :V0PRDVG-ORIG-PRODU:VIND-ORIG-PRODU, :V0PRDVG-TEM-SAF:VIND-TEM-SAF, :V0PRDVG-TEM-IGPM:VIND-TEM-IGPM, :V0PRDVG-CODPRODAZ, :V0PRDVG-OPCAOCAP, :V0PRDVG-COBERADIC-PREMIO, :V0PRDVG-CUSTOCAP-TOTAL FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRDVG_ESTR_COBR, V0PRDVG_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.V0PRDVG_ORIG_PRODU, V0PRDVG_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.V0PRDVG_TEM_SAF, V0PRDVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PRDVG_TEM_IGPM, V0PRDVG_TEM_IGPM);
                _.Move(executed_1.VIND_TEM_IGPM, VIND_TEM_IGPM);
                _.Move(executed_1.V0PRDVG_CODPRODAZ, V0PRDVG_CODPRODAZ);
                _.Move(executed_1.V0PRDVG_OPCAOCAP, V0PRDVG_OPCAOCAP);
                _.Move(executed_1.V0PRDVG_COBERADIC_PREMIO, V0PRDVG_COBERADIC_PREMIO);
                _.Move(executed_1.V0PRDVG_CUSTOCAP_TOTAL, V0PRDVG_CUSTOCAP_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-ATRASO-SECTION */
        private void R1010_00_FETCH_PARCELAS_ATRASO_SECTION()
        {
            /*" -1054- MOVE '101X' TO WNR-EXEC-SQL. */
            _.Move("101X", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1056- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1060- PERFORM R1010_00_FETCH_PARCELAS_ATRASO_DB_FETCH_1 */

            R1010_00_FETCH_PARCELAS_ATRASO_DB_FETCH_1();

            /*" -1063- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1064- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1064- PERFORM R1010_00_FETCH_PARCELAS_ATRASO_DB_CLOSE_1 */

                    R1010_00_FETCH_PARCELAS_ATRASO_DB_CLOSE_1();

                    /*" -1066- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1067- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1068- END-IF */
                    }


                    /*" -1069- MOVE 'S' TO CHAVE-FIM */
                    _.Move("S", CHAVE_FIM);

                    /*" -1070- GO TO R1010-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/ //GOTO
                    return;

                    /*" -1071- ELSE */
                }
                else
                {


                    /*" -1073- DISPLAY 'ERRO NA BUSCA DA PARCELA EM ATRASO' V0PROP-NRCERTIF */
                    _.Display($"ERRO NA BUSCA DA PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                    /*" -1073- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-ATRASO-DB-FETCH-1 */
        public void R1010_00_FETCH_PARCELAS_ATRASO_DB_FETCH_1()
        {
            /*" -1060- EXEC SQL FETCH CATRASO INTO :HOST-PARCELA-ATRASO END-EXEC. */

            if (CATRASO.Fetch())
            {
                _.Move(CATRASO.HOST_PARCELA_ATRASO, HOST_PARCELA_ATRASO);
            }

        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-ATRASO-DB-CLOSE-1 */
        public void R1010_00_FETCH_PARCELAS_ATRASO_DB_CLOSE_1()
        {
            /*" -1064- EXEC SQL CLOSE CATRASO END-EXEC */

            CATRASO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-PROC-PARCELAS-ATRASO-SECTION */
        private void R1020_00_PROC_PARCELAS_ATRASO_SECTION()
        {
            /*" -1083- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1085- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1086- IF HOST-PARCELA-ATRASO EQUAL PROX-PARCELA */

            if (HOST_PARCELA_ATRASO == PROX_PARCELA)
            {

                /*" -1087- ADD 1 TO CONT-ATRASO */
                CONT_ATRASO.Value = CONT_ATRASO + 1;

                /*" -1088- COMPUTE PROX-PARCELA = HOST-PARCELA-ATRASO + 1 */
                PROX_PARCELA.Value = HOST_PARCELA_ATRASO + 1;

                /*" -1089- ELSE */
            }
            else
            {


                /*" -1090- MOVE 1 TO CONT-ATRASO */
                _.Move(1, CONT_ATRASO);

                /*" -1091- MOVE HOST-PARCELA-ATRASO TO V0PROP-NRPRIPARATZ */
                _.Move(HOST_PARCELA_ATRASO, V0PROP_NRPRIPARATZ);

                /*" -1093- COMPUTE PROX-PARCELA = HOST-PARCELA-ATRASO + 1. */
                PROX_PARCELA.Value = HOST_PARCELA_ATRASO + 1;
            }


            /*" -1094- PERFORM R1010-00-FETCH-PARCELAS-ATRASO. */

            R1010_00_FETCH_PARCELAS_ATRASO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-SECTION */
        private void R1200_00_GERA_PARCELAS_SECTION()
        {
            /*" -1105- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1107- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1129- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_1 */

            R1200_00_GERA_PARCELAS_DB_SELECT_1();

            /*" -1132- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1133- DISPLAY 'R1200-00 (ERRO - SELECT V0OPCAOPAGVA)' */
                _.Display($"R1200-00 (ERRO - SELECT V0OPCAOPAGVA)");

                /*" -1135- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-DTPROXVEN */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_DTPROXVEN}"
                .Display();

                /*" -1138- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1139- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -1140- MOVE ZEROS TO V0OPCP-CARTAO-CRED */
                _.Move(0, V0OPCP_CARTAO_CRED);

                /*" -1144- IF V0OPCP-INDAGE LESS ZEROES OR V0OPCP-INDOPR LESS ZEROES OR V0OPCP-INDNUM LESS ZEROES OR V0OPCP-INDDIG LESS ZEROES */

                if (V0OPCP_INDAGE < 00 || V0OPCP_INDOPR < 00 || V0OPCP_INDNUM < 00 || V0OPCP_INDDIG < 00)
                {

                    /*" -1146- DISPLAY 'SEGURADO NAO TEM CONTA PARA DEBITAR ' V0PROP-NRCERTIF */
                    _.Display($"SEGURADO NAO TEM CONTA PARA DEBITAR {V0PROP_NRCERTIF}");

                    /*" -1162- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1163- IF V0PROP-DTVENCTO GREATER V0PROP-DTPROXVEN */

            if (V0PROP_DTVENCTO > V0PROP_DTPROXVEN)
            {

                /*" -1164- MOVE '1ABC' TO WNR-EXEC-SQL */
                _.Move("1ABC", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1165- DISPLAY WNR-EXEC-SQL */
                _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1171- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_2 */

                R1200_00_GERA_PARCELAS_DB_SELECT_2();

                /*" -1173- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -1174- MOVE V0HICB-DTVENCTO TO V0PROP-DTVENCTO */
                    _.Move(V0HICB_DTVENCTO, V0PROP_DTVENCTO);

                    /*" -1175- ELSE */
                }
                else
                {


                    /*" -1177- DISPLAY ' ERRO ACESSO PARCELA CORRENTE - PARCELVA  ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL ' ' SQLCODE */

                    $" ERRO ACESSO PARCELA CORRENTE - PARCELVA  {V0PROP_NRCERTIF} {V0PROP_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -1179- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1181- MOVE V0PROP-DTVENCTO TO WDATA-VIGENCIA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -1183- COMPUTE WDATA-VIG-MES = WDATA-VIG-MES + V0OPCP-PERIPGTO. */
            AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES + V0OPCP_PERIPGTO;

            /*" -1184- IF WDATA-VIG-MES > 12 */

            if (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES > 12)
            {

                /*" -1185- COMPUTE WDATA-VIG-MES = WDATA-VIG-MES - 12 */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES - 12;

                /*" -1187- COMPUTE WDATA-VIG-ANO = WDATA-VIG-ANO + 1. */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO + 1;
            }


            /*" -1188- MOVE WDATA-VIGENCIA TO WDATA-VIGENCIA1. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA, AREA_DE_WORK.WDATA_VIGENCIA1);

            /*" -1190- MOVE V0OPCP-DIA-DEBITO TO WDATA-VIG-DIA1. */
            _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_VIGENCIA1.WDATA_VIG_DIA1);

            /*" -1191- IF V0OPCP-DIA-DEBITO NOT LESS 31 */

            if (V0OPCP_DIA_DEBITO >= 31)
            {

                /*" -1193- MOVE TAB-DIA-MES(WDATA-VIG-MES) TO WDATA-VIG-DIA */
                _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES].TAB_DIA_MES, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -1194- ELSE */
            }
            else
            {


                /*" -1196- MOVE V0OPCP-DIA-DEBITO TO WDATA-VIG-DIA. */
                _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);
            }


            /*" -1197- IF V0OPCP-DIA-DEBITO NOT LESS 29 */

            if (V0OPCP_DIA_DEBITO >= 29)
            {

                /*" -1198- IF WDATA-VIG-MES = 02 */

                if (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES == 02)
                {

                    /*" -1200- MOVE 28 TO WDATA-VIG-DIA. */
                    _.Move(28, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);
                }

            }


            /*" -1203- MOVE WDATA-VIGENCIA TO V0COBP-DTINIVIG V0PROP-DTPROXVEN W02DTSQL. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA, V0COBP_DTINIVIG, V0PROP_DTPROXVEN, AREA_DE_WORK.W02DTSQL);

            /*" -1204- MOVE 01 TO W02DDSQL. */
            _.Move(01, AREA_DE_WORK.W02DTSQL.W02DDSQL);

            /*" -1206- MOVE W02DTSQL TO WHOST-DTINIVIG-PARC. */
            _.Move(AREA_DE_WORK.W02DTSQL, WHOST_DTINIVIG_PARC);

            /*" -1208- PERFORM R1700-00-GERA-COBERPROPVA. */

            R1700_00_GERA_COBERPROPVA_SECTION();

            /*" -1209- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1211- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1231- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_3 */

            R1200_00_GERA_PARCELAS_DB_SELECT_3();

            /*" -1234- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1235- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1236- DISPLAY 'R1200-00-AUSENCIA DE COBERTURA P/ PARCELA ' */
                    _.Display($"R1200-00-AUSENCIA DE COBERTURA P/ PARCELA ");

                    /*" -1238- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW */

                    $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW}"
                    .Display();

                    /*" -1239- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1240- ELSE */
                }
                else
                {


                    /*" -1241- DISPLAY 'R1200-00 (ERRO - SELECT V0COBERPROPVA)' */
                    _.Display($"R1200-00 (ERRO - SELECT V0COBERPROPVA)");

                    /*" -1243- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW */

                    $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW}"
                    .Display();

                    /*" -1243- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1200_10_GERA_PARCELAS */

            R1200_10_GERA_PARCELAS();

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-1 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_1()
        {
            /*" -1129- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO INTO :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIA-DEBITO, :V0OPCP-AGECTADEB:V0OPCP-INDAGE, :V0OPCP-OPRCTADEB:V0OPCP-INDOPR, :V0OPCP-NUMCTADEB:V0OPCP-INDNUM, :V0OPCP-DIGCTADEB:V0OPCP-INDDIG, :V0OPCP-CARTAO-CRED FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN END-EXEC. */

            var r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIA_DEBITO, V0OPCP_DIA_DEBITO);
                _.Move(executed_1.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_INDAGE, V0OPCP_INDAGE);
                _.Move(executed_1.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_INDOPR, V0OPCP_INDOPR);
                _.Move(executed_1.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_INDNUM, V0OPCP_INDNUM);
                _.Move(executed_1.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0OPCP_INDDIG, V0OPCP_INDDIG);
                _.Move(executed_1.V0OPCP_CARTAO_CRED, V0OPCP_CARTAO_CRED);
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS */
        private void R1200_10_GERA_PARCELAS(bool isPerform = false)
        {
            /*" -1247- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1249- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1255- PERFORM R1200_10_GERA_PARCELAS_DB_SELECT_1 */

            R1200_10_GERA_PARCELAS_DB_SELECT_1();

            /*" -1258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1259- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1260- IF V0PROP-NRPARCEL = 0 */

                    if (V0PROP_NRPARCEL == 0)
                    {

                        /*" -1261- MOVE ZEROS TO V0PARC-PRMTOTANT */
                        _.Move(0, V0PARC_PRMTOTANT);

                        /*" -1262- ELSE */
                    }
                    else
                    {


                        /*" -1263- IF V0PROP-NRPARCEL > 0 */

                        if (V0PROP_NRPARCEL > 0)
                        {

                            /*" -1264- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL - 1 */
                            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL - 1;

                            /*" -1265- GO TO R1200-10-GERA-PARCELAS */
                            new Task(() => R1200_10_GERA_PARCELAS()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -1266- ELSE */
                        }
                        else
                        {


                            /*" -1267- DISPLAY 'R1200-00 (ERRO - SELECT V0PARCELVA)' */
                            _.Display($"R1200-00 (ERRO - SELECT V0PARCELVA)");

                            /*" -1269- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                            $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                            .Display();

                            /*" -1270- MOVE '9999-12-31' TO V0PROP-DTPROXVEN */
                            _.Move("9999-12-31", V0PROP_DTPROXVEN);

                            /*" -1271- GO TO R1200-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                            return;

                            /*" -1272- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -1273- DISPLAY 'R1200-00 (ERRO - SELECT V0PARCELVA)' */
                    _.Display($"R1200-00 (ERRO - SELECT V0PARCELVA)");

                    /*" -1275- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                    $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                    .Display();

                    /*" -1276- MOVE '9999-12-31' TO V0PROP-DTPROXVEN */
                    _.Move("9999-12-31", V0PROP_DTPROXVEN);

                    /*" -1278- GO TO R1200-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1279- MOVE V0PROP-NRPARCEL TO V0RELA-NRPARCEL. */
            _.Move(V0PROP_NRPARCEL, V0RELA_NRPARCEL);

            /*" -1281- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL + 1. */
            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL + 1;

            /*" -1283- MOVE V0PROP-DTPROXVEN TO V0PROP-DTVENCTO. */
            _.Move(V0PROP_DTPROXVEN, V0PROP_DTVENCTO);

            /*" -1284- IF V0OPCP-OPCAOPAG = '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -1285- MOVE 0 TO V0PARC-OCORHIST */
                _.Move(0, V0PARC_OCORHIST);

                /*" -1286- ELSE */
            }
            else
            {


                /*" -1288- MOVE 1 TO V0PARC-OCORHIST. */
                _.Move(1, V0PARC_OCORHIST);
            }


            /*" -1289- MOVE V0COBP-PRMVG TO WHOST-PRMVG-W. */
            _.Move(V0COBP_PRMVG, WHOST_PRMVG_W);

            /*" -1290- MOVE V0COBP-PRMAP TO WHOST-PRMAP-W */
            _.Move(V0COBP_PRMAP, WHOST_PRMAP_W);

            /*" -1298- COMPUTE WHOST-VLPREMIO-W = WHOST-PRMAP-W + WHOST-PRMVG-W */
            WHOST_VLPREMIO_W.Value = WHOST_PRMAP_W + WHOST_PRMVG_W;

            /*" -1299- IF V0PARC-SITUACAO EQUAL ' ' */

            if (V0PARC_SITUACAO == " ")
            {

                /*" -1300- IF V0PROP-DTVENCTO LESS V1SIST-DTMOVABE */

                if (V0PROP_DTVENCTO < V1SIST_DTMOVABE)
                {

                    /*" -1302- MOVE '2' TO V0PARC-SITUACAO. */
                    _.Move("2", V0PARC_SITUACAO);
                }

            }


            /*" -1303- MOVE '1224' TO WNR-EXEC-SQL. */
            _.Move("1224", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1305- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1306- DISPLAY ' V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
            _.Display($" V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

            /*" -1307- DISPLAY ' V0PROP-NRPARCEL ' V0PROP-NRPARCEL */
            _.Display($" V0PROP-NRPARCEL {V0PROP_NRPARCEL}");

            /*" -1319- PERFORM R1200_10_GERA_PARCELAS_DB_INSERT_1 */

            R1200_10_GERA_PARCELAS_DB_INSERT_1();

            /*" -1322- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1325- DISPLAY 'PARCELA DUPLICADA ==> ' 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"PARCELA DUPLICADA ==> CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -1327- GO TO R1200-00-PROXIMA. */

                R1200_00_PROXIMA(); //GOTO
                return;
            }


            /*" -1329- MOVE V0PROP-DTVENCTO TO V0HICB-DTVENCTO. */
            _.Move(V0PROP_DTVENCTO, V0HICB_DTVENCTO);

            /*" -1330- IF V0PARC-SITUACAO EQUAL ' ' */

            if (V0PARC_SITUACAO == " ")
            {

                /*" -1332- IF V0OPCP-OPCAOPAG NOT EQUAL '3' AND V0OPCP-OPCAOPAG NOT EQUAL '4' */

                if (V0OPCP_OPCAOPAG != "3" && V0OPCP_OPCAOPAG != "4")
                {

                    /*" -1333- IF V0PROP-DTVENCTO < V1SIST-DTVENFIM-DB */

                    if (V0PROP_DTVENCTO < V1SIST_DTVENFIM_DB)
                    {

                        /*" -1334- MOVE V1SIST-DTVENFIM-DB TO V0HICB-DTVENCTO */
                        _.Move(V1SIST_DTVENFIM_DB, V0HICB_DTVENCTO);

                        /*" -1335- END-IF */
                    }


                    /*" -1340- PERFORM R1300-00-GERA-DEBITO. */

                    R1300_00_GERA_DEBITO_SECTION();
                }

            }


            /*" -1342- PERFORM R1400-00-GERA-HIST-COBRANCA. */

            R1400_00_GERA_HIST_COBRANCA_SECTION();

            /*" -1343- IF V0PARC-SITUACAO EQUAL '2' */

            if (V0PARC_SITUACAO == "2")
            {

                /*" -1345- GO TO R1200-00-GRAVADOS. */

                R1200_00_GRAVADOS(); //GOTO
                return;
            }


            /*" -1346- IF V0PARC-SITUACAO EQUAL '1' */

            if (V0PARC_SITUACAO == "1")
            {

                /*" -1346- PERFORM R1600-00-VERIFICA-REPASSE. */

                R1600_00_VERIFICA_REPASSE_SECTION();
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-SELECT-1 */
        public void R1200_10_GERA_PARCELAS_DB_SELECT_1()
        {
            /*" -1255- EXEC SQL SELECT PRMVG + PRMAP - VLMULTA INTO :V0PARC-PRMTOTANT FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC. */

            var r1200_10_GERA_PARCELAS_DB_SELECT_1_Query1 = new R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_10_GERA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMTOTANT, V0PARC_PRMTOTANT);
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-INSERT-1 */
        public void R1200_10_GERA_PARCELAS_DB_INSERT_1()
        {
            /*" -1319- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, :WHOST-PRMVG-W, :WHOST-PRMAP-W, 0, :V0OPCP-OPCAOPAG, :V0PARC-SITUACAO, :V0PARC-OCORHIST, CURRENT TIMESTAMP) END-EXEC. */

            var r1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1 = new R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG_W = WHOST_PRMVG_W.ToString(),
                WHOST_PRMAP_W = WHOST_PRMAP_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1.Execute(r1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-2 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_2()
        {
            /*" -1171- EXEC SQL SELECT DTVENCTO INTO :V0HICB-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HICB_DTVENCTO, V0HICB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1200-00-GRAVADOS */
        private void R1200_00_GRAVADOS(bool isPerform = false)
        {
            /*" -1349- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-3 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_3()
        {
            /*" -1231- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLCUSTCAP, VLCUSTCDG, VLCUSTAUXF, CODOPER INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-QTTITCAP, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF, :V0COBP-CODOPER FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-NRPARCEL-NEW END-EXEC. */

            var r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1()
            {
                V0PROP_NRPARCEL_NEW = V0PROP_NRPARCEL_NEW.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_IVLCUSTAUXF, V0COBP_IVLCUSTAUXF);
                _.Move(executed_1.V0COBP_CODOPER, V0COBP_CODOPER);
            }


        }

        [StopWatch]
        /*" R1200-00-PROXIMA */
        private void R1200_00_PROXIMA(bool isPerform = false)
        {
            /*" -1355- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -1357- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -1358- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -1359- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -1361- COMPUTE WDATA-SIS-ANO = WDATA-SIS-ANO + 1. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -1362- IF V0OPCP-DIA-DEBITO NOT LESS 31 */

            if (V0OPCP_DIA_DEBITO >= 31)
            {

                /*" -1364- MOVE TAB-DIA-MES(WDATA-SIS-MES) TO WDATA-SIS-DIA */
                _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES].TAB_DIA_MES, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                /*" -1365- ELSE */
            }
            else
            {


                /*" -1367- MOVE V0OPCP-DIA-DEBITO TO WDATA-SIS-DIA. */
                _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);
            }


            /*" -1368- IF V0OPCP-DIA-DEBITO NOT LESS 29 */

            if (V0OPCP_DIA_DEBITO >= 29)
            {

                /*" -1369- IF WDATA-SIS-MES = 02 */

                if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES == 02)
                {

                    /*" -1371- MOVE 28 TO WDATA-SIS-DIA. */
                    _.Move(28, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);
                }

            }


            /*" -1371- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-SECTION */
        private void R1300_00_GERA_DEBITO_SECTION()
        {
            /*" -1383- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -1384- MOVE V0CONV-CODCONV TO HOST-CODCONV */
                _.Move(V0CONV_CODCONV, HOST_CODCONV);

                /*" -1386- MOVE ZEROS TO V0OPCP-CARTAO-CRED. */
                _.Move(0, V0OPCP_CARTAO_CRED);
            }


            /*" -1387- IF V0OPCP-OPCAOPAG EQUAL '5' */

            if (V0OPCP_OPCAOPAG == "5")
            {

                /*" -1388- MOVE 0 TO V0OPCP-CARTAO-CRED */
                _.Move(0, V0OPCP_CARTAO_CRED);

                /*" -1389- MOVE V0CONV-CCRED TO HOST-CODCONV */
                _.Move(V0CONV_CCRED, HOST_CODCONV);

                /*" -1394- MOVE ZEROS TO V0OPCP-AGECTADEB V0OPCP-OPRCTADEB V0OPCP-NUMCTADEB V0OPCP-DIGCTADEB. */
                _.Move(0, V0OPCP_AGECTADEB, V0OPCP_OPRCTADEB, V0OPCP_NUMCTADEB, V0OPCP_DIGCTADEB);
            }


            /*" -1395- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1397- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1440- PERFORM R1300_00_GERA_DEBITO_DB_INSERT_1 */

            R1300_00_GERA_DEBITO_DB_INSERT_1();

            /*" -1443- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1444- DISPLAY 'R1300-00 (ERRO - INSERT V0HISTCONTAVA)' */
                _.Display($"R1300-00 (ERRO - INSERT V0HISTCONTAVA)");

                /*" -1446- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -1446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-DB-INSERT-1 */
        public void R1300_00_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -1440- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, 1, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HICB-DTVENCTO, :WHOST-VLPREMIO-W, '0' , '1' , CURRENT TIMESTAMP, 0, :HOST-CODCONV, NULL, NULL, NULL, NULL, NULL, :V0OPCP-CARTAO-CRED) END-EXEC. */

            var r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 = new R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                HOST_CODCONV = HOST_CODCONV.ToString(),
                V0OPCP_CARTAO_CRED = V0OPCP_CARTAO_CRED.ToString(),
            };

            R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-SECTION */
        private void R1400_00_GERA_HIST_COBRANCA_SECTION()
        {
            /*" -1457- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1459- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1461- MOVE '5' TO V0HICB-SITUACAO. */
            _.Move("5", V0HICB_SITUACAO);

            /*" -1463- MOVE 000 TO V0HICB-CODOPER. */
            _.Move(000, V0HICB_CODOPER);

            /*" -1464- IF V0PARC-SITUACAO EQUAL '1' */

            if (V0PARC_SITUACAO == "1")
            {

                /*" -1465- MOVE '1' TO V0HICB-SITUACAO */
                _.Move("1", V0HICB_SITUACAO);

                /*" -1467- MOVE 000 TO V0HICB-CODOPER. */
                _.Move(000, V0HICB_CODOPER);
            }


            /*" -1468- IF V0PARC-SITUACAO EQUAL '2' */

            if (V0PARC_SITUACAO == "2")
            {

                /*" -1469- MOVE '2' TO V0HICB-SITUACAO */
                _.Move("2", V0HICB_SITUACAO);

                /*" -1471- MOVE 000 TO V0HICB-CODOPER. */
                _.Move(000, V0HICB_CODOPER);
            }


            /*" -1473- ADD 1 TO WTITL-SEQUENCIA. */
            FILLER_1.WTITL_SEQUENCIA.Value = FILLER_1.WTITL_SEQUENCIA + 1;

            /*" -1475- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(FILLER_1.WTITL_SEQUENCIA, DPARM01X.DPARM01);

            /*" -1477- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", DPARM01X);

            /*" -1478- IF DPARM01-RC NOT EQUAL +0 */

            if (DPARM01X.DPARM01_RC != +0)
            {

                /*" -1479- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -1480- DISPLAY 'CERTIFICADO     ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO     {V0PROP_NRCERTIF}");

                /*" -1481- DISPLAY 'AREA            ' DPARM01X */
                _.Display($"AREA            {DPARM01X}");

                /*" -1483- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1485- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(DPARM01X.DPARM01_D1, FILLER_1.WTITL_DIGITO);

            /*" -1487- MOVE W-NUMR-TITULO TO V0BANC-NRTIT. */
            _.Move(W_NUMR_TITULO, V0BANC_NRTIT);

            /*" -1504- PERFORM R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1 */

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1();

            /*" -1507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1508- DISPLAY 'R1400-00 (ERRO - INSERT V0HISTCOBVA)' */
                _.Display($"R1400-00 (ERRO - INSERT V0HISTCOBVA)");

                /*" -1510- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -1510- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-DB-INSERT-1 */
        public void R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1()
        {
            /*" -1504- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0BANC-NRTIT, :V0HICB-DTVENCTO, :WHOST-VLPREMIO-W, :V0OPCP-OPCAOPAG, :V0HICB-SITUACAO, :V0HICB-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 = new R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HICB_SITUACAO = V0HICB_SITUACAO.ToString(),
                V0HICB_CODOPER = V0HICB_CODOPER.ToString(),
            };

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1.Execute(r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-SECTION */
        private void R1500_00_TRATA_V0DIFPARCELVA_SECTION()
        {
            /*" -1533- PERFORM R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1 */

            R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1();

            /*" -1536- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1538- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1538- PERFORM R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1 */

            R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1();

            /*" -1541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1542- DISPLAY 'PROBLEMAS NO OPEN (CDIFPAR   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CDIFPAR   ) ... ");

                /*" -1544- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1545- MOVE SPACES TO WFIM-CDIFPAR. */
            _.Move("", AREA_DE_WORK.WFIM_CDIFPAR);

            /*" -1546- MOVE V0COBP-VLPREMIO TO WHOST-VLPREMIO. */
            _.Move(V0COBP_VLPREMIO, WHOST_VLPREMIO);

            /*" -1547- MOVE V0COBP-PRMVG TO WHOST-PRMVG. */
            _.Move(V0COBP_PRMVG, WHOST_PRMVG);

            /*" -1549- MOVE V0COBP-PRMAP TO WHOST-PRMAP. */
            _.Move(V0COBP_PRMAP, WHOST_PRMAP);

            /*" -1551- PERFORM R1510-00-FETCH-CDIFPAR. */

            R1510_00_FETCH_CDIFPAR_SECTION();

            /*" -1552- IF WFIM-CDIFPAR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty())
            {

                /*" -1552- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1500_10_LOOP_CDIFPAR */

            R1500_10_LOOP_CDIFPAR();

        }

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-DB-OPEN-1 */
        public void R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1()
        {
            /*" -1538- EXEC SQL OPEN CDIFPAR END-EXEC. */

            CDIFPAR.Open();

        }

        [StopWatch]
        /*" R1500-10-LOOP-CDIFPAR */
        private void R1500_10_LOOP_CDIFPAR(bool isPerform = false)
        {
            /*" -1558- IF V0DIFP-CODOPER NOT LESS 600 AND V0DIFP-CODOPER NOT GREATER 699 */

            if (V0DIFP_CODOPER >= 600 && V0DIFP_CODOPER <= 699)
            {

                /*" -1559- COMPUTE WHOST-PRMVG = WHOST-PRMVG - V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG - V0DIFP_PRMDIFVG;

                /*" -1560- COMPUTE WHOST-PRMAP = WHOST-PRMAP - V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP - V0DIFP_PRMDIFAP;

                /*" -1562- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP. */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;
            }


            /*" -1564- IF V0DIFP-CODOPER NOT LESS 400 AND V0DIFP-CODOPER NOT GREATER 499 */

            if (V0DIFP_CODOPER >= 400 && V0DIFP_CODOPER <= 499)
            {

                /*" -1565- COMPUTE WHOST-PRMVG = WHOST-PRMVG + V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG + V0DIFP_PRMDIFVG;

                /*" -1566- COMPUTE WHOST-PRMAP = WHOST-PRMAP + V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP + V0DIFP_PRMDIFAP;

                /*" -1568- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP. */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;
            }


            /*" -1568- MOVE V0DIFP-CODOPER TO V3DIFP-CODOPER. */
            _.Move(V0DIFP_CODOPER, V3DIFP_CODOPER);

        }

        [StopWatch]
        /*" R1500-10-UPDATE */
        private void R1500_10_UPDATE(bool isPerform = false)
        {
            /*" -1573- MOVE '1501' TO WNR-EXEC-SQL. */
            _.Move("1501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1575- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1580- PERFORM R1500_10_UPDATE_DB_UPDATE_1 */

            R1500_10_UPDATE_DB_UPDATE_1();

            /*" -1583- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1584- COMPUTE V3DIFP-CODOPER = V0DIFP-CODOPER + 10 */
                V3DIFP_CODOPER.Value = V0DIFP_CODOPER + 10;

                /*" -1585- GO TO R1500-10-UPDATE */
                new Task(() => R1500_10_UPDATE()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1586- ELSE */
            }
            else
            {


                /*" -1587- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1588- DISPLAY 'R1500-00 (ERRO - UPDATE CDIFPAR   )' */
                    _.Display($"R1500-00 (ERRO - UPDATE CDIFPAR   )");

                    /*" -1589- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -1589- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-10-UPDATE-DB-UPDATE-1 */
        public void R1500_10_UPDATE_DB_UPDATE_1()
        {
            /*" -1580- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0PROP-NRPARCEL, CODOPER = :V3DIFP-CODOPER WHERE CURRENT OF CDIFPAR END-EXEC. */

            var r1500_10_UPDATE_DB_UPDATE_1_Update1 = new R1500_10_UPDATE_DB_UPDATE_1_Update1(CDIFPAR)
            {
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V3DIFP_CODOPER = V3DIFP_CODOPER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            R1500_10_UPDATE_DB_UPDATE_1_Update1.Execute(r1500_10_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1500-20-LE-CDIFPAR */
        private void R1500_20_LE_CDIFPAR(bool isPerform = false)
        {
            /*" -1595- PERFORM R1510-00-FETCH-CDIFPAR. */

            R1510_00_FETCH_CDIFPAR_SECTION();

            /*" -1597- IF WFIM-CDIFPAR NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty())
            {

                /*" -1598- ELSE */
            }
            else
            {


                /*" -1598- GO TO R1500-10-LOOP-CDIFPAR. */

                R1500_10_LOOP_CDIFPAR(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-SECTION */
        private void R1510_00_FETCH_CDIFPAR_SECTION()
        {
            /*" -1607- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1609- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1615- PERFORM R1510_00_FETCH_CDIFPAR_DB_FETCH_1 */

            R1510_00_FETCH_CDIFPAR_DB_FETCH_1();

            /*" -1618- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1619- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1619- PERFORM R1510_00_FETCH_CDIFPAR_DB_CLOSE_1 */

                    R1510_00_FETCH_CDIFPAR_DB_CLOSE_1();

                    /*" -1621- MOVE 'S' TO WFIM-CDIFPAR */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFPAR);

                    /*" -1622- ELSE */
                }
                else
                {


                    /*" -1623- DISPLAY 'R1510-00 (ERRO -  FETCH CDIFPAR   )...' */
                    _.Display($"R1510-00 (ERRO -  FETCH CDIFPAR   )...");

                    /*" -1623- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-DB-FETCH-1 */
        public void R1510_00_FETCH_CDIFPAR_DB_FETCH_1()
        {
            /*" -1615- EXEC SQL FETCH CDIFPAR INTO :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0DIFP-VLPRMTOT, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP END-EXEC. */

            if (CDIFPAR.Fetch())
            {
                _.Move(CDIFPAR.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CDIFPAR.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CDIFPAR.V0DIFP_VLPRMTOT, V0DIFP_VLPRMTOT);
                _.Move(CDIFPAR.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CDIFPAR.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
            }

        }

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-DB-CLOSE-1 */
        public void R1510_00_FETCH_CDIFPAR_DB_CLOSE_1()
        {
            /*" -1619- EXEC SQL CLOSE CDIFPAR END-EXEC */

            CDIFPAR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-SECTION */
        private void R1600_00_VERIFICA_REPASSE_SECTION()
        {
            /*" -1635- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1637- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1643- PERFORM R1600_00_VERIFICA_REPASSE_DB_UPDATE_1 */

            R1600_00_VERIFICA_REPASSE_DB_UPDATE_1();

            /*" -1646- MOVE '1602' TO WNR-EXEC-SQL. */
            _.Move("1602", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1648- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1654- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_1 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_1();

            /*" -1657- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1659- PERFORM R1650-00-REPASSA-CDG. */

                R1650_00_REPASSA_CDG_SECTION();
            }


            /*" -1661- MOVE '1604' TO WNR-EXEC-SQL. */
            _.Move("1604", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1667- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_2 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_2();

            /*" -1670- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1671- IF V0PRDVG-TEM-SAF = 'S' */

                if (V0PRDVG_TEM_SAF == "S")
                {

                    /*" -1671- PERFORM R1670-00-REPASSA-SAF. */

                    R1670_00_REPASSA_SAF_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-UPDATE-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_UPDATE_1()
        {
            /*" -1643- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL AND SITUACAO = ' ' END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1 = new R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1.Execute(r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_1()
        {
            /*" -1654- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-2 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_2()
        {
            /*" -1667- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-SECTION */
        private void R1650_00_REPASSA_CDG_SECTION()
        {
            /*" -1681- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -1683- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -1684- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -1685- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -1686- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -1688- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -1690- MOVE WDATA-SISTEMA TO V0RCDG-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RCDG_DTREFER);

            /*" -1692- MOVE '1650' TO WNR-EXEC-SQL. */
            _.Move("1650", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1698- PERFORM R1650_00_REPASSA_CDG_DB_SELECT_1 */

            R1650_00_REPASSA_CDG_DB_SELECT_1();

            /*" -1701- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1703- GO TO R1650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1705- MOVE '1652' TO WNR-EXEC-SQL. */
            _.Move("1652", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1715- PERFORM R1650_00_REPASSA_CDG_DB_INSERT_1 */

            R1650_00_REPASSA_CDG_DB_INSERT_1();

            /*" -1718- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1718- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1650_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -1698- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

            var r1650_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R1650_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1650_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r1650_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-DB-INSERT-1 */
        public void R1650_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -1715- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, '0' , :V1SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1650_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r1650_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-SECTION */
        private void R1670_00_REPASSA_SAF_SECTION()
        {
            /*" -1727- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -1729- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -1730- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -1731- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -1732- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -1734- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -1736- MOVE WDATA-SISTEMA TO V0RSAF-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RSAF_DTREFER);

            /*" -1738- MOVE '1670' TO WNR-EXEC-SQL. */
            _.Move("1670", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1744- PERFORM R1670_00_REPASSA_SAF_DB_SELECT_1 */

            R1670_00_REPASSA_SAF_DB_SELECT_1();

            /*" -1747- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1749- GO TO R1670-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1750- IF WREGULARIZOU EQUAL 'S' */

            if (AREA_DE_WORK.WREGULARIZOU == "S")
            {

                /*" -1751- MOVE 501 TO V0RSAF-CODOPER */
                _.Move(501, V0RSAF_CODOPER);

                /*" -1753- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

                R1675_00_INSERT_V0HISTREPSAF_SECTION();
            }


            /*" -1754- MOVE 1100 TO V0RSAF-CODOPER. */
            _.Move(1100, V0RSAF_CODOPER);

            /*" -1754- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

            R1675_00_INSERT_V0HISTREPSAF_SECTION();

        }

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1670_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -1744- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER END-EXEC. */

            var r1670_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1670_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1670_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1670_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-SECTION */
        private void R1675_00_INSERT_V0HISTREPSAF_SECTION()
        {
            /*" -1764- MOVE '1675' TO WNR-EXEC-SQL. */
            _.Move("1675", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1780- PERFORM R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1 */

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1();

            /*" -1783- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1783- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-DB-INSERT-1 */
        public void R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1()
        {
            /*" -1780- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, :V0RSAF-CODOPER, '0' , '0' , 0, 0, 'VG1853B' , CURRENT TIMESTAMP, :V0PROP-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 = new R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0RSAF_CODOPER = V0RSAF_CODOPER.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1.Execute(r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1675_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-GERA-COBERPROPVA-SECTION */
        private void R1700_00_GERA_COBERPROPVA_SECTION()
        {
            /*" -1793- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1793- COMPUTE V0PROP-NRPARCEL-NEW = V0PROP-NRPARCEL + 1. */
            V0PROP_NRPARCEL_NEW.Value = V0PROP_NRPARCEL + 1;

            /*" -0- FLUXCONTROL_PERFORM R1700_10_LOOP */

            R1700_10_LOOP();

        }

        [StopWatch]
        /*" R1700-10-LOOP */
        private void R1700_10_LOOP(bool isPerform = false)
        {
            /*" -1805- PERFORM R1700_10_LOOP_DB_SELECT_1 */

            R1700_10_LOOP_DB_SELECT_1();

            /*" -1808- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1809- GO TO R1700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;

                /*" -1810- ELSE */
            }
            else
            {


                /*" -1812- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1813- ELSE */
                }
                else
                {


                    /*" -1815- DISPLAY 'R1700 - ERRO ACESSO COBERPROPVA  ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW */

                    $"R1700 - ERRO ACESSO COBERPROPVA  {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW}"
                    .Display();

                    /*" -1817- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1819- MOVE '170A' TO WNR-EXEC-SQL. */
            _.Move("170A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1821- MOVE V0PROP-OCORHIST TO V0PARC-NRPARCEL. */
            _.Move(V0PROP_OCORHIST, V0PARC_NRPARCEL);

            /*" -1827- PERFORM R1700_10_LOOP_DB_SELECT_2 */

            R1700_10_LOOP_DB_SELECT_2();

            /*" -1830- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1831- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1832- IF V0PARC-NRPARCEL EQUAL V0PROP-NRPARCEL-NEW */

                    if (V0PARC_NRPARCEL == V0PROP_NRPARCEL_NEW)
                    {

                        /*" -1833- MOVE V0PROP-DTPROXVEN TO V0PARC-DTVENCTO-PAR */
                        _.Move(V0PROP_DTPROXVEN, V0PARC_DTVENCTO_PAR);

                        /*" -1834- ELSE */
                    }
                    else
                    {


                        /*" -1835- IF V0PROP-NRPARCEL > 1 */

                        if (V0PROP_NRPARCEL > 1)
                        {

                            /*" -1836- SUBTRACT 1 FROM V0PROP-NRPARCEL */
                            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL - 1;

                            /*" -1837- GO TO R1700-00-GERA-COBERPROPVA */

                            R1700_00_GERA_COBERPROPVA_SECTION(); //GOTO
                            return;

                            /*" -1838- ELSE */
                        }
                        else
                        {


                            /*" -1839- IF V0PROP-NRPARCEL = 1 */

                            if (V0PROP_NRPARCEL == 1)
                            {

                                /*" -1840- MOVE V0PROP-DTPROXVEN TO V0PARC-DTVENCTO-PAR */
                                _.Move(V0PROP_DTPROXVEN, V0PARC_DTVENCTO_PAR);

                                /*" -1841- ELSE */
                            }
                            else
                            {


                                /*" -1843- DISPLAY 'ERRO NA BUSCA DA PARCELA ' V0PROP-NRCERTIF ' ' V0PARC-NRPARCEL */

                                $"ERRO NA BUSCA DA PARCELA {V0PROP_NRCERTIF} {V0PARC_NRPARCEL}"
                                .Display();

                                /*" -1844- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -1845- END-IF */
                            }


                            /*" -1846- END-IF */
                        }


                        /*" -1847- ELSE */
                    }

                }
                else
                {


                    /*" -1849- DISPLAY 'ERRO NO SELECT DA PARCELA ' V0PROP-NRCERTIF ' ' V0PARC-NRPARCEL */

                    $"ERRO NO SELECT DA PARCELA {V0PROP_NRCERTIF} {V0PARC_NRPARCEL}"
                    .Display();

                    /*" -1851- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1853- MOVE '170B' TO WNR-EXEC-SQL. */
            _.Move("170B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1862- PERFORM R1700_10_LOOP_DB_SELECT_3 */

            R1700_10_LOOP_DB_SELECT_3();

            /*" -1865- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1866- DISPLAY 'R1700-00 (ERRO - SELECT V0OPCAOPAGVA)' */
                _.Display($"R1700-00 (ERRO - SELECT V0OPCAOPAGVA)");

                /*" -1868- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PARC-DTVENCTO-PAR */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PARC_DTVENCTO_PAR}"
                .Display();

                /*" -1871- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1873- MOVE '1701' TO WNR-EXEC-SQL. */
            _.Move("1701", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1893- PERFORM R1700_10_LOOP_DB_SELECT_4 */

            R1700_10_LOOP_DB_SELECT_4();

            /*" -1896- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1916- PERFORM R1700_10_LOOP_DB_SELECT_5 */

                R1700_10_LOOP_DB_SELECT_5();

                /*" -1919- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1940- PERFORM R1700_10_LOOP_DB_SELECT_6 */

                    R1700_10_LOOP_DB_SELECT_6();

                    /*" -1943- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1945- DISPLAY 'R1700 - CERTIFICADO/APOLICE SEM COBERTURAS ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                        $"R1700 - CERTIFICADO/APOLICE SEM COBERTURAS {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                        .Display();

                        /*" -1947- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1949- IF WHOST-DTTERVIG-ORIG EQUAL '9999-12-31' NEXT SENTENCE */

            if (WHOST_DTTERVIG_ORIG == "9999-12-31")
            {

                /*" -1950- ELSE */
            }
            else
            {


                /*" -1951- MOVE WHOST-DTTERVIG-ORIG TO WHOST-DTTERVIG */
                _.Move(WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG);

                /*" -1953- MOVE WHOST-DTINIVIG-NEW2 TO WHOST-DTINIVIG-NEW. */
                _.Move(WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW);
            }


            /*" -1955- MOVE '1702' TO WNR-EXEC-SQL. */
            _.Move("1702", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2021- PERFORM R1700_10_LOOP_DB_SELECT_7 */

            R1700_10_LOOP_DB_SELECT_7();

            /*" -2024- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2026- DISPLAY 'R1700 - CERTIFICADO/APOLICE SEM COBERTURA  ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                $"R1700 - CERTIFICADO/APOLICE SEM COBERTURA  {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                .Display();

                /*" -2028- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2030- MOVE '1703' TO WNR-EXEC-SQL. */
            _.Move("1703", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2035- PERFORM R1700_10_LOOP_DB_UPDATE_1 */

            R1700_10_LOOP_DB_UPDATE_1();

            /*" -2038- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2040- DISPLAY 'R1700 - ERRO UPDATE ULTIMO OCORHIST ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                $"R1700 - ERRO UPDATE ULTIMO OCORHIST {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                .Display();

                /*" -2042- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2044- MOVE '1704' TO WNR-EXEC-SQL. */
            _.Move("1704", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2046- COMPUTE V0PROP-OCORHIST = V0PROP-OCORHIST + 1. */
            V0PROP_OCORHIST.Value = V0PROP_OCORHIST + 1;

            /*" -2048- MOVE V0PROP-OCORHIST TO HISCOBPR-OCORR-HISTORICO. */
            _.Move(V0PROP_OCORHIST, HISCOBPR_OCORR_HISTORICO);

            /*" -2049- MOVE WHOST-DTINIVIG-NEW TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(WHOST_DTINIVIG_NEW, HISCOBPR_DATA_INIVIGENCIA);

            /*" -2050- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR_DATA_TERVIGENCIA);

            /*" -2051- MOVE 'VG0853B' TO HISCOBPR-COD-USUARIO. */
            _.Move("VG0853B", HISCOBPR_COD_USUARIO);

            /*" -2053- MOVE ZEROS TO HISCOBPR-COD-OPERACAO. */
            _.Move(0, HISCOBPR_COD_OPERACAO);

            /*" -2117- PERFORM R1700_10_LOOP_DB_INSERT_1 */

            R1700_10_LOOP_DB_INSERT_1();

            /*" -2120- IF SQLCODE NOT EQUAL ZEROES AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2122- DISPLAY 'R1700 - ERRO INSERT NOVA COBERPROPVA       ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                $"R1700 - ERRO INSERT NOVA COBERPROPVA       {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                .Display();

                /*" -2124- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2125- IF V0PROP-OCORHIST LESS V0PROP-NRPARCEL-NEW */

            if (V0PROP_OCORHIST < V0PROP_NRPARCEL_NEW)
            {

                /*" -2125- GO TO R1700-10-LOOP. */
                new Task(() => R1700_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-1 */
        public void R1700_10_LOOP_DB_SELECT_1()
        {
            /*" -1805- EXEC SQL SELECT DTINIVIG INTO :WHOST-DTINIVIG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-NRPARCEL-NEW END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_1_Query1 = new R1700_10_LOOP_DB_SELECT_1_Query1()
            {
                V0PROP_NRPARCEL_NEW = V0PROP_NRPARCEL_NEW.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_1_Query1.Execute(r1700_10_LOOP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-2 */
        public void R1700_10_LOOP_DB_SELECT_2()
        {
            /*" -1827- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO-PAR FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_2_Query1 = new R1700_10_LOOP_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_2_Query1.Execute(r1700_10_LOOP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO_PAR, V0PARC_DTVENCTO_PAR);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2137- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2139- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2139- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2143- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2143- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-3 */
        public void R1700_10_LOOP_DB_SELECT_3()
        {
            /*" -1862- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO-ANT FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-PAR AND DTTERVIG >= :V0PARC-DTVENCTO-PAR END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_3_Query1 = new R1700_10_LOOP_DB_SELECT_3_Query1()
            {
                V0PARC_DTVENCTO_PAR = V0PARC_DTVENCTO_PAR.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_3_Query1.Execute(r1700_10_LOOP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO_ANT, V0OPCP_PERIPGTO_ANT);
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-4 */
        public void R1700_10_LOOP_DB_SELECT_4()
        {
            /*" -1893- EXEC SQL SELECT DTINIVIG, DTTERVIG, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH, CASE WHEN DTTERVIG <> '9999-12-31' THEN (DTTERVIG + 1 DAY) ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH END INTO :WHOST-DTINIVIG, :WHOST-DTTERVIG-ORIG, :WHOST-DTTERVIG, :WHOST-DTINIVIG-NEW, :WHOST-DTINIVIG-NEW2 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_4_Query1 = new R1700_10_LOOP_DB_SELECT_4_Query1()
            {
                V0OPCP_PERIPGTO_ANT = V0OPCP_PERIPGTO_ANT.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_4_Query1.Execute(r1700_10_LOOP_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG_ORIG);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
                _.Move(executed_1.WHOST_DTINIVIG_NEW, WHOST_DTINIVIG_NEW);
                _.Move(executed_1.WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW2);
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-5 */
        public void R1700_10_LOOP_DB_SELECT_5()
        {
            /*" -1916- EXEC SQL SELECT DTINIVIG, DTTERVIG, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH, CASE WHEN DTTERVIG <> '9999-12-31' THEN (DTTERVIG + 1 DAY) ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH END INTO :WHOST-DTINIVIG, :WHOST-DTTERVIG-ORIG, :WHOST-DTTERVIG, :WHOST-DTINIVIG-NEW, :WHOST-DTINIVIG-NEW2 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_5_Query1 = new R1700_10_LOOP_DB_SELECT_5_Query1()
            {
                V0OPCP_PERIPGTO_ANT = V0OPCP_PERIPGTO_ANT.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_5_Query1.Execute(r1700_10_LOOP_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG_ORIG);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
                _.Move(executed_1.WHOST_DTINIVIG_NEW, WHOST_DTINIVIG_NEW);
                _.Move(executed_1.WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW2);
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-UPDATE-1 */
        public void R1700_10_LOOP_DB_UPDATE_1()
        {
            /*" -2035- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = :WHOST-DTTERVIG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND OCORR_HISTORICO = :V0PROP-OCORHIST END-EXEC. */

            var r1700_10_LOOP_DB_UPDATE_1_Update1 = new R1700_10_LOOP_DB_UPDATE_1_Update1()
            {
                WHOST_DTTERVIG = WHOST_DTTERVIG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            R1700_10_LOOP_DB_UPDATE_1_Update1.Execute(r1700_10_LOOP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-INSERT-1 */
        public void R1700_10_LOOP_DB_INSERT_1()
        {
            /*" -2117- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST ( NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES ( :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO , :HISCOBPR-OPCAO-COBERTURA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ , :HISCOBPR-VAL-TIT-CAPITALIZ , :HISCOBPR-VAL-CUSTO-CAPITALI , :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO , CURRENT TIMESTAMP , :HISCOBPR-IMPSEGAUXF :HISCOBPR-IMPSEGAUXF-I , :HISCOBPR-VLCUSTAUXF :HISCOBPR-VLCUSTAUXF-I , :HISCOBPR-PRMDIT :HISCOBPR-PRMDIT-I , :HISCOBPR-QTMDIT :HISCOBPR-QTMDIT-I) END-EXEC. */

            var r1700_10_LOOP_DB_INSERT_1_Insert1 = new R1700_10_LOOP_DB_INSERT_1_Insert1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR_NUM_CERTIFICADO.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR_OCORR_HISTORICO.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_QUANT_VIDAS = HISCOBPR_QUANT_VIDAS.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR_IMPSEGIND.ToString(),
                HISCOBPR_COD_OPERACAO = HISCOBPR_COD_OPERACAO.ToString(),
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR_OPCAO_COBERTURA.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_VLPREMIO = HISCOBPR_VLPREMIO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR_PRMAP.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR_VLCUSTCDG.ToString(),
                HISCOBPR_COD_USUARIO = HISCOBPR_COD_USUARIO.ToString(),
                HISCOBPR_IMPSEGAUXF = HISCOBPR_IMPSEGAUXF.ToString(),
                HISCOBPR_IMPSEGAUXF_I = HISCOBPR_IMPSEGAUXF_I.ToString(),
                HISCOBPR_VLCUSTAUXF = HISCOBPR_VLCUSTAUXF.ToString(),
                HISCOBPR_VLCUSTAUXF_I = HISCOBPR_VLCUSTAUXF_I.ToString(),
                HISCOBPR_PRMDIT = HISCOBPR_PRMDIT.ToString(),
                HISCOBPR_PRMDIT_I = HISCOBPR_PRMDIT_I.ToString(),
                HISCOBPR_QTMDIT = HISCOBPR_QTMDIT.ToString(),
                HISCOBPR_QTMDIT_I = HISCOBPR_QTMDIT_I.ToString(),
            };

            R1700_10_LOOP_DB_INSERT_1_Insert1.Execute(r1700_10_LOOP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-6 */
        public void R1700_10_LOOP_DB_SELECT_6()
        {
            /*" -1940- EXEC SQL SELECT DTINIVIG, DTTERVIG, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH, CASE WHEN DTTERVIG <> '9999-12-31' THEN (DTTERVIG + 1 DAY) ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH END INTO :WHOST-DTINIVIG, :WHOST-DTTERVIG-ORIG, :WHOST-DTTERVIG, :WHOST-DTINIVIG-NEW, :WHOST-DTINIVIG-NEW2 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-PAR AND DTTERVIG >= :V0PARC-DTVENCTO-PAR END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_6_Query1 = new R1700_10_LOOP_DB_SELECT_6_Query1()
            {
                V0PARC_DTVENCTO_PAR = V0PARC_DTVENCTO_PAR.ToString(),
                V0OPCP_PERIPGTO_ANT = V0OPCP_PERIPGTO_ANT.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_6_Query1.Execute(r1700_10_LOOP_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG_ORIG);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
                _.Move(executed_1.WHOST_DTINIVIG_NEW, WHOST_DTINIVIG_NEW);
                _.Move(executed_1.WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW2);
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-7 */
        public void R1700_10_LOOP_DB_SELECT_7()
        {
            /*" -2021- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO , :HISCOBPR-OPCAO-COBERTURA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ , :HISCOBPR-VAL-TIT-CAPITALIZ , :HISCOBPR-VAL-CUSTO-CAPITALI , :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO , :HISCOBPR-IMPSEGAUXF :HISCOBPR-IMPSEGAUXF-I , :HISCOBPR-VLCUSTAUXF :HISCOBPR-VLCUSTAUXF-I , :HISCOBPR-PRMDIT :HISCOBPR-PRMDIT-I , :HISCOBPR-QTMDIT :HISCOBPR-QTMDIT-I FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND OCORR_HISTORICO = :V0PROP-OCORHIST END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_7_Query1 = new R1700_10_LOOP_DB_SELECT_7_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_7_Query1.Execute(r1700_10_LOOP_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_IMPSEGIND, HISCOBPR_IMPSEGIND);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLCUSTCDG, HISCOBPR_VLCUSTCDG);
                _.Move(executed_1.HISCOBPR_COD_USUARIO, HISCOBPR_COD_USUARIO);
                _.Move(executed_1.HISCOBPR_IMPSEGAUXF, HISCOBPR_IMPSEGAUXF);
                _.Move(executed_1.HISCOBPR_IMPSEGAUXF_I, HISCOBPR_IMPSEGAUXF_I);
                _.Move(executed_1.HISCOBPR_VLCUSTAUXF, HISCOBPR_VLCUSTAUXF);
                _.Move(executed_1.HISCOBPR_VLCUSTAUXF_I, HISCOBPR_VLCUSTAUXF_I);
                _.Move(executed_1.HISCOBPR_PRMDIT, HISCOBPR_PRMDIT);
                _.Move(executed_1.HISCOBPR_PRMDIT_I, HISCOBPR_PRMDIT_I);
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR_QTMDIT);
                _.Move(executed_1.HISCOBPR_QTMDIT_I, HISCOBPR_QTMDIT_I);
            }


        }
    }
}