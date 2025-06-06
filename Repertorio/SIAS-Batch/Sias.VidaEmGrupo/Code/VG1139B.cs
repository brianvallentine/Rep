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
using Sias.VidaEmGrupo.DB2.VG1139B;

namespace Code
{
    public class VG1139B
    {
        public bool IsCall { get; set; }

        public VG1139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL EMPRESARIAL/PESSOA JURIDICA*      */
        /*"      *   PROGRAMA ...............  VG1139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  10/11/1997                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO HISTORICO DE           *      */
        /*"      *                             CONTABILIZACAO DE PARCELAS         *      */
        /*"      *                             (V0HISTCONTABILVA), GERA O ENDOSSO *      */
        /*"      *                             CORRESPONDENTE PARA REGISTRAR A    *      */
        /*"      *                             EMISSAO E A COBRANCA PARA APOLICE  *      */
        /*"      *                             NOS MOLDES DO SINDUSCON / CE       *      */
        /*"      *                            (GERA ENDOSSOS DIARIAMENTE)         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * COPIA MODIFICADA DO VA0139B PARA ATENDER O NOVO FATURAMENTO    *      */
        /*"      * DAS APOLICES ESPECIFICAS / VIDAZUL EMPRESARIAL                 *      */
        /*"      *    FREDERICO FONSECA - 20/03/2002.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                  A L T E R A C O E S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - HIST 181.577                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 004 - 28/02/2013 - MARCO PAIVA                                 *      */
        /*"      *       CORRECAO DO ABEND (SQLCODE = 100) NA TABELA SEGUROS.     *      */
        /*"      *                             V0COBERPROPVA                      *      */
        /*"      *                                             PROCURE POR V.02   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 003 - 29/01/2004 - MANOEL MESSIAS                              *      */
        /*"      *                             GERAR NA COBERAPOL O RAMO 82 NO LU-*      */
        /*"      *                             GAR DO RAMO 81.                    *      */
        /*"      *                                             PROCURE POR MM2904 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 002 - 02/08/2002 - FREDERICO / MESSIAS                         *      */
        /*"      *                             CORRECAO NO CALCULO DOS PERCENTUAIS*      */
        /*"      *                             DE COBERTURA E PREMIOS DO RAMO 81  *      */
        /*"      *                             PARA EVITAR A GERACAO DE PREMIOS/CO*      */
        /*"      *                             BETURAS NEGATIVOS PARA A DIT.      *      */
        /*"      *                                             PROCURE POR MF0208 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 001 - 31/07/2002 - MANOEL MESSIAS                              *      */
        /*"      *   EXISTE NO PRODUTO EMPRESARIAL ALGUNS SUBGRUPOS QUE POSSUI    *      */
        /*"      * SOMENTE VG OU AP. E O PROGRAMA NAO ESTAVA PREPARADO PARA ESTE  *      */
        /*"      * TIPO DE COBERTURA.                                             *      */
        /*"      *                                             PROCURE POR MM3107 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  12/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0808                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * HISTORICO CONTABIL DE PARCELAS VA   V0HISTCONTABILVA  I-O      *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           I-O      *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * APOLICE COSSEGURO                   V1APOLCOSCED      INPUT    *      */
        /*"      * PARCELAS                            V0PARCELA         OUTPUT   *      */
        /*"      * HISTORICO DE PARCELAS               V0HISTOPARC       OUTPUT   *      */
        /*"      * COBERTURA APOLICES                  V0COBERAPOL       OUTPUT   *      */
        /*"      * ORDEM COSSEGURO CEDIDO              V0ORDECOSCED      OUTPUT   *      */
        /*"      * NUMERACAO GERAL                     V0NUMERO_AES      I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01              V1RIND-RAMO           PIC S9(004)      COMP.*/
        public IntBasis V1RIND_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              V1RIND-DTINIVIG       PIC  X(010).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              V1RIND-PCIOF          PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01              WS-DTRENOVA           PIC X(010).*/
        public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              WS-DTINIVIG           PIC X(010).*/
        public StringBasis WS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         VIND-DATARCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-DTQITBCO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-DTVENCTO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-VLCUSEMI       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-CFPREFIX       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-SITUACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         WHOST-CODSUBES       PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01         WHOST-NRPARCEL       PIC S9(04) COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01         WHOST-NRCERTIF       PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01         WHOST-NRTIT          PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01         WHOST-DTTERVIG       PIC  X(10).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         V0COBP-DTINIVIG-ENDO PIC  X(10).*/
        public StringBasis V0COBP_DTINIVIG_ENDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         V0COBP-DTTERVIG-ENDO PIC  X(10).*/
        public StringBasis V0COBP_DTTERVIG_ENDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         NUM-SICOB            PIC S9(15) COMP-3.*/
        public IntBasis NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-CODUSU               PIC X(8).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  V0RELA-DATA-SOLICITACAO     PIC X(10).*/
        public StringBasis V0RELA_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-IDSISTEM             PIC X(2).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"01  V0RELA-CODRELAT             PIC X(8).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  V0RELA-NRCOPIAS             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-QUANTIDADE           PIC S9(04) COMP.*/
        public IntBasis V0RELA_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PERI-INICIAL         PIC X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-PERI-FINAL           PIC X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-DATA-REFERENCIA      PIC X(10).*/
        public StringBasis V0RELA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-MES-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-ANO-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-ORGAO                PIC S9(04) COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-MODALIDA             PIC S9(04) COMP.*/
        public IntBasis V0RELA_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CONGENER             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NRCERTIF             PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-NRTIT                PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-CODSUBES             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-COD-PLANO            PIC S9(04) COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-OCORHIST             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-APOLIDER             PIC X(15).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-ENDOSLID             PIC X(15).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-NUM-PARC-LIDER       PIC S9(04) COMP.*/
        public IntBasis V0RELA_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NUM-SINISTRO         PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis V0RELA_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-NUM-ORDEM            PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-CODUNIMO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CORRECAO             PIC X(1).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-SITUACAO             PIC X(1).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-PREVIA-DEFINITIVA    PIC X(1).*/
        public StringBasis V0RELA_PREVIA_DEFINITIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-ANAL-RESUMO          PIC X(1).*/
        public StringBasis V0RELA_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-PERI-RENOVACAO       PIC S9(04) COMP.*/
        public IntBasis V0RELA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PCT-AUMENTO          PIC S9(3)V9(2) COMP-3.*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"01  V0RELA-TIMESTAMP            PIC X(26).*/
        public StringBasis V0RELA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HCTB-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0HCTB-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HCTB-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HCTB-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-OPCAO-COBER  PIC S9(004)               COMP.*/
        public IntBasis V0HCTB_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0HCTB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0HCTB-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0HCTB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0HCTB-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-SITUACAO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HCTB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0HCTB-DTMOVTO      PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCTB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCTB-DTMOVTO-ANT  PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCTB_DTMOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0PARC-DTVENCTO     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCOB-DTVENCTO     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCOB-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-ORGAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0SUBG-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SUBG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0SUBG-DTINIVIG-I   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0SUBG_DTINIVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0SUBG-IND-IOF      PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0SUBG_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0SUBG-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0SUBG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PROP-IDADE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-OPCAO-COBER  PIC  X(001).*/
        public StringBasis V0PROP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PROP-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COND-IEA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPD          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0PLAN-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0PLAN-IPRMDIT      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PLAN_IPRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PLAN-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAMDS      PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPDH        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-PRMDIT-I     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CBPR_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1FONT-PROPAUTOM    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V1COSP-CONGENER     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-NUM-APOLICE  PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0ENDO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0ENDO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-DATPRO       PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DT-LIBER     PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DTEMIS       PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-VLRCAP       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0ENDO-BCORCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-AGERCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-DACRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-IDRCAP       PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-DACCOBR      PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-CDFRACIO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-PCENTRAD     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"01         V0ENDO-PCADICIO     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"01         V0ENDO-PRESTA1      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTPRESTA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTITENS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-CODTXT       PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01         V0ENDO-CDACEITA     PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-MOEDA-IMP    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-MOEDA-PRM    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-COD-USUAR    PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0ENDO-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-SITUACAO     PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-DATARCAP     PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-ISENTA-CST   PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ENDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0ENDO-DTVENCTO     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0ENDO-CFPREFIX     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"01         V0ENDO-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0ENDO-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1NCOS-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-NRORDEM      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-DACPARC      PIC  X(001).*/
        public StringBasis V0PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PARC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-VAL-DES-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNPRLIQ     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNADFRA     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNCUSTO     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNIOF       PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNTOTAL     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-QTDDOC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PARC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0PARC-SIT-COBR     PIC  X(001).*/
        public StringBasis V0PARC_SIT_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-PRM-TARIFA   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VAL-DESCON   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VAL_DESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPRMLIQ     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLADIFRA     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLIOCC       PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPRMTOT     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPREMIO     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-COD-USUAR    PIC  X(008).*/
        public StringBasis V0HISP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0HISP-RNUDOC       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0HISP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1SEGVG-DTINIVIG    PIC  X(010).*/
        public StringBasis V1SEGVG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SEGVG-DTRENOVA    PIC  X(010).*/
        public StringBasis V1SEGVG_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SEGVG-DTRENOVA-IND PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1SEGVG_DTRENOVA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0COBA-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-COD-COBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0COBA-PCT-COBERT   PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"01         V0COBA-FATOR-MULT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0COBA-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0COBA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0COBA-SITUACAO     PIC  X(001)       VALUE '0'.*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"01         V0ORDC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0ORDC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ORDC-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ORDC-ORDEM-CED    PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_ORDEM_CED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0ORDC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ORDC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ORDC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0PRVG-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PRVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PRVG-ORIG-PRODU   PIC  X(010).*/
        public StringBasis V0PRVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PRVF-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PRVF_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0EDIA-CODRELAT            PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0EDIA-NUM-APOL            PIC S9(013)               COMP-3.*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0EDIA-NRENDOS             PIC S9(009)               COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0EDIA-NRPARCEL            PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-DTMOVTO             PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0EDIA-ORGAO               PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-RAMO                PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-FONTE               PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-CONGENER            PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-CODCORR             PIC S9(009)               COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0EDIA-SITUACAO            PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         TABELA-ULTIMOS-DIAS.*/
        public VG1139B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG1139B_TABELA_ULTIMOS_DIAS();
        public class VG1139B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG1139B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG1139B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG1139B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG1139B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VG1139B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG1139B_TAB_DIA_MESES>(12);
            public class VG1139B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VG1139B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG1139B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VG1139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG1139B_AREA_DE_WORK();
        public class VG1139B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VG1139B_WS_DTBASE WS_DTBASE { get; set; } = new VG1139B_WS_DTBASE();
            public class VG1139B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VG1139B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VG1139B_WS_DTBASE_AM();
                public class VG1139B_WS_DTBASE_AM : VarBasis
                {
                    /*"     15         WS-AABASE             PIC 9(004).*/
                    public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMBASE             PIC 9(002).*/
                    public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDBASE             PIC 9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DTFATUR.*/
            }
            public VG1139B_WS_DTFATUR WS_DTFATUR { get; set; } = new VG1139B_WS_DTFATUR();
            public class VG1139B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VG1139B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VG1139B_WS_DTFATUR_AM();
                public class VG1139B_WS_DTFATUR_AM : VarBasis
                {
                    /*"     15         WS-AAFATUR            PIC 9(004).*/
                    public IntBasis WS_AAFATUR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMFATUR            PIC 9(002).*/
                    public IntBasis WS_MMFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDFATUR            PIC 9(002).*/
                public IntBasis WS_DDFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DIA                PIC 9(002).*/
            }
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WFIM-V0HISTCONTABILVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAP              PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V0RCAP              PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-CONVERSAO           PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_CONVERSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0PROPOSTAVA        PIC 9(001)  VALUE 0.*/
            public IntBasis WFIM_V0PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WS-NUM-APOLICE-ANT     PIC S9(13)    COMP-3.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-CODSUBES-ANT        PIC S9(04)    COMP.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NRPARCEL-ANT        PIC S9(04)    COMP.*/
            public IntBasis WS_NRPARCEL_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NRCERTIF-ANT        PIC S9(15)    COMP-3.*/
            public IntBasis WS_NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"  05         WS-NRTIT-ANT           PIC S9(13)    COMP-3.*/
            public IntBasis WS_NRTIT_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-FONTE-ANT           PIC S9(04)    COMP.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-IND-IOF             PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"  05         WS-VLIOCC              PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-VG           PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-AP           PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-DIT          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-RTO          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-VG       PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-AP       PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-DIT      PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-RTO      PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PREMIO-LIQ          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-AP          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-VG          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-DIT         PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-RTO         PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-IMPRTO              PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_IMPRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRMRTO              PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRMRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_VG1139B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG1139B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG1139B_FILLER_5(); _.Move(WWORK_NUM_ORDEM, _filler_5); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_5, WWORK_NUM_ORDEM); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUM_ORDEM); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VG1139B_FILLER_5 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VG1139B_FILLER_5()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VG1139B_WWORK_DATA WWORK_DATA { get; set; } = new VG1139B_WWORK_DATA();
            public class VG1139B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-DIA         PIC  9(002).*/
                public IntBasis WWORK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/
            }
            public VG1139B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VG1139B_WDATA_SISTEMA();
            public class VG1139B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WS-DATE.*/
            }
            public VG1139B_WS_DATE WS_DATE { get; set; } = new VG1139B_WS_DATE();
            public class VG1139B_WS_DATE : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-INIVIGENCIA.*/
            }
            public VG1139B_WS_DATA_INIVIGENCIA WS_DATA_INIVIGENCIA { get; set; } = new VG1139B_WS_DATA_INIVIGENCIA();
            public class VG1139B_WS_DATA_INIVIGENCIA : VarBasis
            {
                /*"    10       WDATA-AA-INIV     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_INIV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-INIV     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-INIV     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-QUITACAO.*/
            }
            public VG1139B_WS_DATA_QUITACAO WS_DATA_QUITACAO { get; set; } = new VG1139B_WS_DATA_QUITACAO();
            public class VG1139B_WS_DATA_QUITACAO : VarBasis
            {
                /*"    10       WDATA-AA-QUIT     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_QUIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-QUIT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_QUIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-QUIT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_QUIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public VG1139B_WDATA_CABEC WDATA_CABEC { get; set; } = new VG1139B_WDATA_CABEC();
            public class VG1139B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         AC-PRMVG      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            }
            public DoubleBasis AC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMAP      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMDIT     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMRTO     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPMORNATU PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPMORACID PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPINVPERM PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPAMDS    PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPDH      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPDIT     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPRTO     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-L-V0HISTCONT         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTCONT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ENDOSSO          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0RCAPCOMP         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ORDECOSCED       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0EMISDIARIA       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0PARCELA          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0HISTOPARC        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0COBERAPOL        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0RCAP             PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0RCAPCOMP         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERAES         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0FONTE            PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0HISTCONTABILVA   PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0HISTCONTABILVA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERO-COSSEGURO PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERO_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05        WABEND.*/
            public VG1139B_WABEND WABEND { get; set; } = new VG1139B_WABEND();
            public class VG1139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG1139B '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG1139B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG1139B_WS_HORAS WS_HORAS { get; set; } = new VG1139B_WS_HORAS();
        public class VG1139B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG1139B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG1139B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG1139B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG1139B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VG1139B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG1139B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG1139B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG1139B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG1139B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VG1139B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VG1139B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG1139B_TOTAIS_ROT();
        public class VG1139B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG1139B_FILLER_21> FILLER_21 { get; set; } = new ListBasis<VG1139B_FILLER_21>(50);
            public class VG1139B_FILLER_21 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public VG1139B_CHISTCTBL CHISTCTBL { get; set; } = new VG1139B_CHISTCTBL();
        public VG1139B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VG1139B_V1RCAPCOMP();
        public VG1139B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new VG1139B_V1APOLCOSCED();
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
            /*" -625- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -628- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -631- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -635- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -636- DISPLAY 'PROGRAMA EM EXECUCAO VG1139B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VG1139B   ");

            /*" -637- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -638- DISPLAY 'VERSAO V.68  79.824 28/02/2013 ' */
            _.Display($"VERSAO V.68  79.824 28/02/2013 ");

            /*" -639- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -641- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -643- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -645- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -646- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -647- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -654- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -657- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -662- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -663- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -664- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -669- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -672- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -673- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -675- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -677- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

            /*" -678- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -679- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -723- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -728- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -729- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -729- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -732- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -733- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -737- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -739- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

            /*" -740- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
            {

                /*" -742- DISPLAY 'VG1139B - NENHUMA COBRANCA ENCONTRADA' */
                _.Display($"VG1139B - NENHUMA COBRANCA ENCONTRADA");

                /*" -744- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -747- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -749- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -751- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -752- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -752- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -755- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -755- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -654- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -859- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -860- DISPLAY ' ' . */
            _.Display($" ");

            /*" -862- DISPLAY '*--------  VG1139B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VG1139B - FIM NORMAL  --------*");

            /*" -862- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -723- EXEC SQL DECLARE CHISTCTBL CURSOR WITH HOLD FOR SELECT A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.PRMVG, A.PRMAP, A.CODOPER, A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.OCOORHIST, A.DTMOVTO, B.DTQITBCO, B.CODCLIEN, C.ESTR_COBR, C.ORIG_PRODU, B.OCORHIST FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOSVG C, SEGUROS.V0SUBGRUPO D WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.NRCERTIF = A.NRCERTIF AND B.CODCLIEN = D.COD_CLIENTE AND B.NUM_APOLICE = D.NUM_APOLICE AND B.CODSUBES = D.COD_SUBGRUPO AND A.SITUACAO IN ( '0' , '3' ) AND A.DTMOVTO <= :V1SIST-DTMOVABE AND A.DTFATUR IS NULL AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.CODSUBES AND C.DIA_FATURA = 99 AND C.ESTR_COBR = 'MULT' AND C.ORIG_PRODU IN ( 'EMPRE' , 'ESPEC' , 'ESPE1' ) ORDER BY A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.NRPARCEL, A.FONTE, A.NRTIT END-EXEC. */
            CHISTCTBL = new VG1139B_CHISTCTBL(true);
            string GetQuery_CHISTCTBL()
            {
                var query = @$"SELECT A.SITUACAO
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE
							, 
							A.PRMVG
							, 
							A.PRMAP
							, 
							A.CODOPER
							, 
							A.NRCERTIF
							, 
							A.NRPARCEL
							, 
							A.NRTIT
							, 
							A.OCOORHIST
							, 
							A.DTMOVTO
							, 
							B.DTQITBCO
							, 
							B.CODCLIEN
							, 
							C.ESTR_COBR
							, 
							C.ORIG_PRODU
							, 
							B.OCORHIST 
							FROM SEGUROS.V0HISTCONTABILVA A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PRODUTOSVG C
							, 
							SEGUROS.V0SUBGRUPO D 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.CODCLIEN = D.COD_CLIENTE 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND B.CODSUBES = D.COD_SUBGRUPO 
							AND A.SITUACAO IN ( '0'
							, '3' ) 
							AND A.DTMOVTO <= '{V1SIST_DTMOVABE}' 
							AND A.DTFATUR IS NULL 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.CODSUBES = B.CODSUBES 
							AND C.DIA_FATURA = 99 
							AND C.ESTR_COBR = 'MULT' 
							AND C.ORIG_PRODU IN ( 'EMPRE'
							, 'ESPEC'
							, 
							'ESPE1' ) 
							ORDER BY A.SITUACAO
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.NRPARCEL
							, 
							A.FONTE
							, 
							A.NRTIT";

                return query;
            }
            CHISTCTBL.GetQueryEvent += GetQuery_CHISTCTBL;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -729- EXEC SQL OPEN CHISTCTBL END-EXEC. */

            CHISTCTBL.Open();

        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -2191- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE NRRCAP = :V0RCAP-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */
            V1RCAPCOMP = new VG1139B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT FONTE
							, 
							NRRCAP
							, 
							NRRCAPCO
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							HORAOPER
							, 
							SITUACAO
							, 
							BCOAVISO
							, 
							AGEAVISO
							, 
							NRAVISO
							, 
							VLRCAP
							, 
							DATARCAP
							, 
							DTCADAST
							, 
							SITCONTB 
							FROM SEGUROS.V1RCAPCOMP 
							WHERE NRRCAP = '{V0RCAP_NRRCAP}' 
							AND OPERACAO >= 100 
							AND OPERACAO <= 199 
							AND SITUACAO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -669- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-SECTION */
        private void R0910_00_FETCH_HCTBVA_SECTION()
        {
            /*" -873- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -891- PERFORM R0910_00_FETCH_HCTBVA_DB_FETCH_1 */

            R0910_00_FETCH_HCTBVA_DB_FETCH_1();

            /*" -894- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -895- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -895- PERFORM R0910_00_FETCH_HCTBVA_DB_CLOSE_1 */

                    R0910_00_FETCH_HCTBVA_DB_CLOSE_1();

                    /*" -897- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -898- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -899- ELSE */
                }
                else
                {


                    /*" -901- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -903- ADD 1 TO AC-L-V0HISTCONT. */
            AREA_DE_WORK.AC_L_V0HISTCONT.Value = AREA_DE_WORK.AC_L_V0HISTCONT + 1;

            /*" -904- IF V0HCTB-FONTE EQUAL ZEROS */

            if (V0HCTB_FONTE == 00)
            {

                /*" -906- MOVE 5 TO V0HCTB-FONTE. */
                _.Move(5, V0HCTB_FONTE);
            }


            /*" -907- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' */

            if (V0PRVG_ORIG_PRODU == "EMPRE")
            {

                /*" -908- IF V0HCTB-CODSUBES EQUAL ZEROS */

                if (V0HCTB_CODSUBES == 00)
                {

                    /*" -910- GO TO R0910-00-FETCH-HCTBVA. */
                    new Task(() => R0910_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -912- MOVE '091Z' TO WNR-EXEC-SQL. */
            _.Move("091Z", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -913- MOVE 42 TO SII. */
            _.Move(42, WS_HORAS.SII);

            /*" -914- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -921- PERFORM R0910_00_FETCH_HCTBVA_DB_SELECT_1 */

            R0910_00_FETCH_HCTBVA_DB_SELECT_1();

            /*" -924- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -925- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -926- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -927- GO TO R0910-00-FETCH-HCTBVA */
                    new Task(() => R0910_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -928- ELSE */
                }
                else
                {


                    /*" -928- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_HCTBVA_DB_FETCH_1()
        {
            /*" -891- EXEC SQL FETCH CHISTCTBL INTO :V0HCTB-SITUACAO , :V0HCTB-NUM-APOLICE , :V0HCTB-CODSUBES , :V0HCTB-FONTE , :V0HCTB-PRMVG , :V0HCTB-PRMAP , :V0HCTB-CODOPER , :V0HCTB-NRCERTIF , :V0HCTB-NRPARCEL , :V0HCTB-NRTIT , :V0HCTB-OCORHIST , :V0HCTB-DTMOVTO , :V0PROP-DTQITBCO , :V0PROP-CODCLIEN , :V0PRVG-ESTR-COBR , :V0PRVG-ORIG-PRODU , :V0PROP-OCORHIST END-EXEC. */

            if (CHISTCTBL.Fetch())
            {
                _.Move(CHISTCTBL.V0HCTB_SITUACAO, V0HCTB_SITUACAO);
                _.Move(CHISTCTBL.V0HCTB_NUM_APOLICE, V0HCTB_NUM_APOLICE);
                _.Move(CHISTCTBL.V0HCTB_CODSUBES, V0HCTB_CODSUBES);
                _.Move(CHISTCTBL.V0HCTB_FONTE, V0HCTB_FONTE);
                _.Move(CHISTCTBL.V0HCTB_PRMVG, V0HCTB_PRMVG);
                _.Move(CHISTCTBL.V0HCTB_PRMAP, V0HCTB_PRMAP);
                _.Move(CHISTCTBL.V0HCTB_CODOPER, V0HCTB_CODOPER);
                _.Move(CHISTCTBL.V0HCTB_NRCERTIF, V0HCTB_NRCERTIF);
                _.Move(CHISTCTBL.V0HCTB_NRPARCEL, V0HCTB_NRPARCEL);
                _.Move(CHISTCTBL.V0HCTB_NRTIT, V0HCTB_NRTIT);
                _.Move(CHISTCTBL.V0HCTB_OCORHIST, V0HCTB_OCORHIST);
                _.Move(CHISTCTBL.V0HCTB_DTMOVTO, V0HCTB_DTMOVTO);
                _.Move(CHISTCTBL.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CHISTCTBL.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CHISTCTBL.V0PRVG_ESTR_COBR, V0PRVG_ESTR_COBR);
                _.Move(CHISTCTBL.V0PRVG_ORIG_PRODU, V0PRVG_ORIG_PRODU);
                _.Move(CHISTCTBL.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_HCTBVA_DB_CLOSE_1()
        {
            /*" -895- EXEC SQL CLOSE CHISTCTBL END-EXEC */

            CHISTCTBL.Close();

        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-SELECT-1 */
        public void R0910_00_FETCH_HCTBVA_DB_SELECT_1()
        {
            /*" -921- EXEC SQL SELECT NUM_APOLICE INTO :V0SUBG-NUM-APOLICE FROM SEGUROS.V0SUBGRUPO WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND NUM_APOLICE = :V0HCTB-NUM-APOLICE AND COD_SUBGRUPO = :V0HCTB-CODSUBES END-EXEC. */

            var r0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1 = new R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0HCTB_CODSUBES = V0HCTB_CODSUBES.ToString(),
            };

            var executed_1 = R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1.Execute(r0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_NUM_APOLICE, V0SUBG_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -939- MOVE V0HCTB-NUM-APOLICE TO WS-NUM-APOLICE-ANT V0ENDO-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0ENDO_NUM_APOLICE);

            /*" -941- MOVE V0HCTB-CODSUBES TO WS-CODSUBES-ANT V0ENDO-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0ENDO_CODSUBES);

            /*" -943- MOVE V0HCTB-FONTE TO WS-FONTE-ANT V0ENDO-FONTE. */
            _.Move(V0HCTB_FONTE, AREA_DE_WORK.WS_FONTE_ANT, V0ENDO_FONTE);

            /*" -945- MOVE V0HCTB-NRPARCEL TO WS-NRPARCEL-ANT WHOST-NRPARCEL. */
            _.Move(V0HCTB_NRPARCEL, AREA_DE_WORK.WS_NRPARCEL_ANT, WHOST_NRPARCEL);

            /*" -947- MOVE V0HCTB-NRCERTIF TO WS-NRCERTIF-ANT WHOST-NRCERTIF. */
            _.Move(V0HCTB_NRCERTIF, AREA_DE_WORK.WS_NRCERTIF_ANT, WHOST_NRCERTIF);

            /*" -949- MOVE V0HCTB-NRTIT TO WS-NRTIT-ANT WHOST-NRTIT. */
            _.Move(V0HCTB_NRTIT, AREA_DE_WORK.WS_NRTIT_ANT, WHOST_NRTIT);

            /*" -951- MOVE V0HCTB-DTMOVTO TO V0HCTB-DTMOVTO-ANT. */
            _.Move(V0HCTB_DTMOVTO, V0HCTB_DTMOVTO_ANT);

            /*" -953- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -954- MOVE 05 TO SII. */
            _.Move(05, WS_HORAS.SII);

            /*" -955- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -964- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -967- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -968- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -970- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -972- MOVE '10A1' TO WNR-EXEC-SQL. */
            _.Move("10A1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -973- MOVE 06 TO SII. */
            _.Move(06, WS_HORAS.SII);

            /*" -974- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -982- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -985- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -986- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -988- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -990- MOVE '10B1' TO WNR-EXEC-SQL. */
            _.Move("10B1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -991- MOVE 17 TO SII. */
            _.Move(17, WS_HORAS.SII);

            /*" -992- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1000- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -1003- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1004- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1006- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1008- MOVE '10BY' TO WNR-EXEC-SQL. */
            _.Move("10BY", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1009- MOVE 43 TO SII. */
            _.Move(43, WS_HORAS.SII);

            /*" -1010- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1019- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -1022- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1024- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1025- MOVE '10BZ' TO WNR-EXEC-SQL */
                    _.Move("10BZ", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1026- MOVE 44 TO SII */
                    _.Move(44, WS_HORAS.SII);

                    /*" -1027- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -1035- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

                    /*" -1037- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -1038- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1039- DISPLAY 'ERRO ACESSO HISTCOBVA ' V0HCTB-NRCERTIF */
                        _.Display($"ERRO ACESSO HISTCOBVA {V0HCTB_NRCERTIF}");

                        /*" -1040- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1041- END-IF */
                    }


                    /*" -1042- ELSE */
                }
                else
                {


                    /*" -1044- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1046- MOVE '10B2' TO WNR-EXEC-SQL. */
            _.Move("10B2", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1047- MOVE 44 TO SII. */
            _.Move(44, WS_HORAS.SII);

            /*" -1048- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1059- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -1062- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1063- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1064- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1072- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_7 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_7();

                    /*" -1074- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1075- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1076- END-IF */
                    }


                    /*" -1077- ELSE */
                }
                else
                {


                    /*" -1078- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1079- END-IF */
                }


                /*" -1081- END-IF. */
            }


            /*" -1083- MOVE '10C1' TO WNR-EXEC-SQL. */
            _.Move("10C1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1084- MOVE 31 TO SII. */
            _.Move(31, WS_HORAS.SII);

            /*" -1085- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1094- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_8 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_8();

            /*" -1097- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1098- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1100- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1106- MOVE '10D1' TO WNR-EXEC-SQL. */
            _.Move("10D1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1108- MOVE V0COBP-DTINIVIG-ENDO TO V0ENDO-DTINIVIG. */
            _.Move(V0COBP_DTINIVIG_ENDO, V0ENDO_DTINIVIG);

            /*" -1110- MOVE 41 TO SII. */
            _.Move(41, WS_HORAS.SII);

            /*" -1111- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1119- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_9 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_9();

            /*" -1122- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1123- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1125- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1126- IF V0COBP-DTTERVIG-ENDO NOT EQUAL '9999-12-31' */

            if (V0COBP_DTTERVIG_ENDO != "9999-12-31")
            {

                /*" -1132- MOVE V0COBP-DTTERVIG-ENDO TO V0ENDO-DTTERVIG. */
                _.Move(V0COBP_DTTERVIG_ENDO, V0ENDO_DTTERVIG);
            }


            /*" -1134- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1135- MOVE 07 TO SII. */
            _.Move(07, WS_HORAS.SII);

            /*" -1136- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1145- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_10 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_10();

            /*" -1148- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1149- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1150- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1152- DISPLAY '*** VG1139B - SOLICITAR PRORROGACAO DA APOLICE ' V0HCTB-NUM-APOLICE ' ' V0ENDO-DTINIVIG */

                    $"*** VG1139B - SOLICITAR PRORROGACAO DA APOLICE {V0HCTB_NUM_APOLICE} {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -1155- PERFORM R0910-00-FETCH-HCTBVA UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

                    while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT))
                    {

                        R0910_00_FETCH_HCTBVA_SECTION();
                    }

                    /*" -1156- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

                    if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
                    {

                        /*" -1157- GO TO R1000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;

                        /*" -1158- ELSE */
                    }
                    else
                    {


                        /*" -1159- GO TO R1000-00-PROCESSA-REGISTRO */
                        new Task(() => R1000_00_PROCESSA_REGISTRO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1160- END-IF */
                    }


                    /*" -1161- ELSE */
                }
                else
                {


                    /*" -1163- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1165- MOVE '1005' TO WNR-EXEC-SQL. */
            _.Move("1005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1166- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -1167- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1173- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_11 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_11();

            /*" -1176- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1177- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1179- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1181- ADD 1 TO V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS + 1;

            /*" -1183- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1184- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -1185- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1190- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -1193- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1194- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1196- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1198- ADD 1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + 1;

            /*" -1208- MOVE +0 TO AC-PRMVG AC-PRMAP AC-PRMRTO AC-PRMDIT WS-VLIOCC-TOT WS-VLIOCC-TOT-AP WS-VLIOCC-TOT-VG WS-VLIOCC-TOT-DIT WS-VLIOCC-TOT-RTO. */
            _.Move(+0, AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.AC_PRMRTO, AREA_DE_WORK.AC_PRMDIT, AREA_DE_WORK.WS_VLIOCC_TOT, AREA_DE_WORK.WS_VLIOCC_TOT_AP, AREA_DE_WORK.WS_VLIOCC_TOT_VG, AREA_DE_WORK.WS_VLIOCC_TOT_DIT, AREA_DE_WORK.WS_VLIOCC_TOT_RTO);

            /*" -1216- PERFORM R1100-00-ACUMULA-PREMIO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR V0HCTB-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR V0HCTB-NRPARCEL NOT EQUAL WS-NRPARCEL-ANT OR V0HCTB-FONTE NOT EQUAL WS-FONTE-ANT OR V0HCTB-NRTIT NOT EQUAL WS-NRTIT-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || V0HCTB_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || V0HCTB_NRPARCEL != AREA_DE_WORK.WS_NRPARCEL_ANT || V0HCTB_FONTE != AREA_DE_WORK.WS_FONTE_ANT || V0HCTB_NRTIT != AREA_DE_WORK.WS_NRTIT_ANT))
            {

                R1100_00_ACUMULA_PREMIO_SECTION();
            }

            /*" -1226- IF AC-PRMVG NOT GREATER ZEROES AND AC-PRMAP NOT GREATER ZEROES */

            if (AREA_DE_WORK.AC_PRMVG <= 00 && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -1227- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -1229- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1239- IF (V0APOL-RAMO EQUAL 93 OR 77) AND AC-PRMVG NOT GREATER ZEROES */

            if ((V0APOL_RAMO.In("93", "77")) && AREA_DE_WORK.AC_PRMVG <= 00)
            {

                /*" -1240- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -1242- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1252- IF (V0APOL-RAMO EQUAL 81 OR 82) AND AC-PRMAP NOT GREATER ZEROES */

            if ((V0APOL_RAMO.In("81", "82")) && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -1253- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -1255- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1256- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -1258- IF AC-PRMVG NOT GREATER ZEROES OR AC-PRMAP NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_PRMVG <= 00 || AREA_DE_WORK.AC_PRMAP <= 00)
                {

                    /*" -1260- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -1270- ELSE */
                    }
                    else
                    {


                        /*" -1271- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -1273- GO TO R1000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1281- MOVE +0 TO AC-IMPMORNATU AC-IMPMORACID AC-IMPINVPERM AC-IMPAMDS AC-IMPDH AC-IMPDIT AC-IMPRTO. */
            _.Move(+0, AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDIT, AREA_DE_WORK.AC_IMPRTO);

            /*" -1283- PERFORM R1200-00-ACUMULA-IS. */

            R1200_00_ACUMULA_IS_SECTION();

            /*" -1284- IF V0APOL-RAMO EQUAL 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -1285- IF AC-IMPMORNATU NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORNATU <= 00)
                {

                    /*" -1288- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' AND V0APOL-RAMO EQUAL 97 NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE" && V0APOL_RAMO == 97)
                    {

                        /*" -1297- ELSE */
                    }
                    else
                    {


                        /*" -1298- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -1300- GO TO R1000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1301- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -1303- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -1305- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -1315- ELSE */
                    }
                    else
                    {


                        /*" -1316- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -1318- GO TO R1000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1319- IF V0APOL-RAMO EQUAL 81 OR 82 */

            if (V0APOL_RAMO.In("81", "82"))
            {

                /*" -1330- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -1331- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -1333- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1335- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1336- MOVE 10 TO SII. */
            _.Move(10, WS_HORAS.SII);

            /*" -1337- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1342- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_12 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_12();

            /*" -1345- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1346- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_LOOP_PROPAUTOM */

            R1000_10_LOOP_PROPAUTOM();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -964- EXEC SQL SELECT RAMO, CODPRODU, ORGAO INTO :V0APOL-RAMO, :V0APOL-CODPRODU, :V0APOL-ORGAO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(executed_1.V0APOL_CODPRODU, V0APOL_CODPRODU);
                _.Move(executed_1.V0APOL_ORGAO, V0APOL_ORGAO);
            }


        }

        [StopWatch]
        /*" R1000-10-LOOP-PROPAUTOM */
        private void R1000_10_LOOP_PROPAUTOM(bool isPerform = false)
        {
            /*" -1354- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -1355- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -1356- MOVE V1SIST-DTMOVABE TO V0ENDO-DATPRO. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DATPRO);

            /*" -1357- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -1359- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -1363- MOVE 0 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR V0ENDO-AGERCAP V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_BCORCAP, V0ENDO_BCOCOBR, V0ENDO_AGERCAP, V0ENDO_AGECOBR);

            /*" -1365- MOVE '0' TO V0ENDO-DACCOBR. */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -1367- MOVE 0 TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);

            /*" -1368- MOVE ' ' TO V0ENDO-DACRCAP. */
            _.Move(" ", V0ENDO_DACRCAP);

            /*" -1369- MOVE ' ' TO V0ENDO-IDRCAP. */
            _.Move(" ", V0ENDO_IDRCAP);

            /*" -1370- MOVE SPACES TO V0ENDO-DATARCAP */
            _.Move("", V0ENDO_DATARCAP);

            /*" -1372- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -1373- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -1374- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -1375- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -1376- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -1377- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -1378- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -1379- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -1380- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -1382- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -1385- MOVE 1 TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(1, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -1386- MOVE '1' TO V0ENDO-TIPO-ENDO. */
            _.Move("1", V0ENDO_TIPO_ENDO);

            /*" -1388- MOVE 'VG1139B' TO V0ENDO-COD-USUAR. */
            _.Move("VG1139B", V0ENDO_COD_USUAR);

            /*" -1390- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -1392- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -1393- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -1394- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -1395- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -1396- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -1398- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -1399- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -1400- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -1416- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -1419- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1420- MOVE 11 TO SII. */
            _.Move(11, WS_HORAS.SII);

            /*" -1421- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1511- PERFORM R1000_10_LOOP_PROPAUTOM_DB_INSERT_1 */

            R1000_10_LOOP_PROPAUTOM_DB_INSERT_1();

            /*" -1514- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1516- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1517- IF V0ENDO-NRPROPOS NOT EQUAL ZEROS */

                    if (V0ENDO_NRPROPOS != 00)
                    {

                        /*" -1518- GO TO R1000-10-LOOP-PROPAUTOM */
                        new Task(() => R1000_10_LOOP_PROPAUTOM()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1519- ELSE */
                    }
                    else
                    {


                        /*" -1520- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1521- ELSE */
                    }

                }
                else
                {


                    /*" -1523- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1525- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -1527- MOVE '1026' TO WNR-EXEC-SQL. */
            _.Move("1026", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1528- MOVE 12 TO SII. */
            _.Move(12, WS_HORAS.SII);

            /*" -1529- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1533- PERFORM R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1 */

            R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1();

            /*" -1536- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1537- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1539- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1541- ADD 1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + 1;

            /*" -1543- PERFORM R1300-00-GRAVA-COSSEGURO. */

            R1300_00_GRAVA_COSSEGURO_SECTION();

            /*" -1544- MOVE V0ENDO-NUM-APOLICE TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0PARC_NUM_APOL);

            /*" -1545- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -1547- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -1548- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -1549- MOVE V0ENDO-FONTE TO V0PARC-FONTE */
            _.Move(V0ENDO_FONTE, V0PARC_FONTE);

            /*" -1550- MOVE WS-NRTIT-ANT TO V0PARC-NRTIT */
            _.Move(AREA_DE_WORK.WS_NRTIT_ANT, V0PARC_NRTIT);

            /*" -1551- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -1552- COMPUTE V0PARC-OTNTOTAL = AC-PRMVG + AC-PRMAP */
            V0PARC_OTNTOTAL.Value = AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMAP;

            /*" -1553- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -1555- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -1558- COMPUTE V0PARC-OTNPRLIQ ROUNDED = V0PARC-OTNTOTAL - WS-VLIOCC-TOT */
            V0PARC_OTNPRLIQ.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -1560- MOVE V0PARC-OTNPRLIQ TO V0PARC-PRM-TAR-IX. */
            _.Move(V0PARC_OTNPRLIQ, V0PARC_PRM_TAR_IX);

            /*" -1562- MOVE WS-VLIOCC-TOT TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VLIOCC_TOT, V0PARC_OTNIOF);

            /*" -1563- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -1564- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -1565- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -1567- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -1570- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1571- MOVE 13 TO SII. */
            _.Move(13, WS_HORAS.SII);

            /*" -1572- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1593- PERFORM R1000_10_LOOP_PROPAUTOM_DB_INSERT_2 */

            R1000_10_LOOP_PROPAUTOM_DB_INSERT_2();

            /*" -1596- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1597- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1599- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1601- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -1603- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -1605- PERFORM R1500-00-GRAVA-OPERACAO-BAIXA. */

            R1500_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -1606- MOVE V0ENDO-NUM-APOLICE TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0COBA_NUM_APOL);

            /*" -1607- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -1608- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -1609- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -1610- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -1611- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -1613- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -1614- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -1615- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -1617- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -1618- IF V0APOL-RAMO = 81 OR 97 OR 82 */

            if (V0APOL_RAMO.In("81", "97", "82"))
            {

                /*" -1619- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1620- MOVE 82 TO V0COBA-RAMOFR */
                    _.Move(82, V0COBA_RAMOFR);

                    /*" -1621- ELSE */
                }
                else
                {


                    /*" -1622- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -1623- END-IF */
                }


                /*" -1624- MOVE 0 TO V0COBA-MODALIFR */
                _.Move(0, V0COBA_MODALIFR);

                /*" -1625- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1627- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -1628- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1631- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMVG + WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -1632- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1634- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1635- ELSE */
                }
                else
                {


                    /*" -1637- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1638- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -1639- END-IF */
                }


                /*" -1641- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1642- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -1643- IF AC-PRMDIT GREATER 0 */

                if (AREA_DE_WORK.AC_PRMDIT > 0)
                {

                    /*" -1646- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0COBA-PRM-TAR-IX - AC-PRMDIT + WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.AC_PRMDIT + AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -1647- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1653- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1654- END-IF */
                }


                /*" -1656- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1657- IF AC-IMPINVPERM GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPINVPERM > 00)
                {

                    /*" -1659- MOVE AC-IMPINVPERM TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPINVPERM, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1661- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1662- MOVE 2 TO V0COBA-COD-COBER */
                    _.Move(2, V0COBA_COD_COBER);

                    /*" -1663- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1665- END-IF */
                }


                /*" -1666- IF AC-IMPAMDS GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPAMDS > 00)
                {

                    /*" -1668- MOVE AC-IMPAMDS TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPAMDS, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1670- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1671- MOVE 3 TO V0COBA-COD-COBER */
                    _.Move(3, V0COBA_COD_COBER);

                    /*" -1672- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1674- END-IF */
                }


                /*" -1675- IF AC-IMPDH GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDH > 00)
                {

                    /*" -1677- MOVE AC-IMPDH TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDH, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1679- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1680- MOVE 4 TO V0COBA-COD-COBER */
                    _.Move(4, V0COBA_COD_COBER);

                    /*" -1681- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1683- END-IF */
                }


                /*" -1684- IF AC-IMPDIT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDIT > 00)
                {

                    /*" -1686- MOVE AC-IMPDIT TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDIT, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1688- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMDIT - WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMDIT - AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -1689- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1690- MOVE 5 TO V0COBA-COD-COBER */
                    _.Move(5, V0COBA_COD_COBER);

                    /*" -1692- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1694- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();
                }

            }


            /*" -1695- IF V0APOL-RAMO = 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -1696- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1697- MOVE 93 TO V0COBA-RAMOFR */
                    _.Move(93, V0COBA_RAMOFR);

                    /*" -1698- ELSE */
                }
                else
                {


                    /*" -1699- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -1700- END-IF */
                }


                /*" -1701- MOVE 0 TO V0COBA-MODALIFR */
                _.Move(0, V0COBA_MODALIFR);

                /*" -1702- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1704- MOVE AC-IMPMORNATU TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORNATU, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -1706- COMPUTE AC-PRMVG = AC-PRMVG - AC-PRMRTO */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.AC_PRMRTO;

                /*" -1708- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-TOT-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                /*" -1709- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1711- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMVG - WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -1712- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1714- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1715- ELSE */
                }
                else
                {


                    /*" -1716- IF AC-IMPRTO GREATER 0 */

                    if (AREA_DE_WORK.AC_IMPRTO > 0)
                    {

                        /*" -1719- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMRTO + WS-VLIOCC-TOT-RTO */
                        V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMRTO + AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                        /*" -1720- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -1722- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -1723- ELSE */
                    }
                    else
                    {


                        /*" -1725- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -1726- MOVE 100 TO V0COBA-PCT-COBERT */
                        _.Move(100, V0COBA_PCT_COBERT);

                        /*" -1727- END-IF */
                    }


                    /*" -1728- END-IF */
                }


                /*" -1730- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1731- MOVE 11 TO V0COBA-COD-COBER */
                _.Move(11, V0COBA_COD_COBER);

                /*" -1731- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                R1600_00_INSERT_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" R1000-10-LOOP-PROPAUTOM-DB-INSERT-1 */
        public void R1000_10_LOOP_PROPAUTOM_DB_INSERT_1()
        {
            /*" -1511- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOLICE, :V0ENDO-NRENDOS, :V0ENDO-CODSUBES, :V0ENDO-FONTE, :V0ENDO-NRPROPOS, :V0ENDO-DATPRO, :V0ENDO-DT-LIBER, :V0ENDO-DTEMIS, :V0ENDO-NRRCAP, :V0ENDO-VLRCAP, :V0ENDO-BCORCAP, :V0ENDO-AGERCAP, :V0ENDO-DACRCAP, :V0ENDO-IDRCAP, :V0ENDO-BCOCOBR, :V0ENDO-AGECOBR, :V0ENDO-DACCOBR, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-CDFRACIO, :V0ENDO-PCENTRAD, :V0ENDO-PCADICIO, :V0ENDO-PRESTA1, :V0ENDO-QTPARCEL, :V0ENDO-QTPRESTA, :V0ENDO-QTITENS, :V0ENDO-CODTXT, :V0ENDO-CDACEITA, :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO, :V0ENDO-DATARCAP:VIND-DATARCAP, :V0ENDO-COD-EMPRESA, :V0ENDO-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:VIND-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI:VIND-VLCUSEMI, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

            var r1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1 = new R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_DATPRO = V0ENDO_DATPRO.ToString(),
                V0ENDO_DT_LIBER = V0ENDO_DT_LIBER.ToString(),
                V0ENDO_DTEMIS = V0ENDO_DTEMIS.ToString(),
                V0ENDO_NRRCAP = V0ENDO_NRRCAP.ToString(),
                V0ENDO_VLRCAP = V0ENDO_VLRCAP.ToString(),
                V0ENDO_BCORCAP = V0ENDO_BCORCAP.ToString(),
                V0ENDO_AGERCAP = V0ENDO_AGERCAP.ToString(),
                V0ENDO_DACRCAP = V0ENDO_DACRCAP.ToString(),
                V0ENDO_IDRCAP = V0ENDO_IDRCAP.ToString(),
                V0ENDO_BCOCOBR = V0ENDO_BCOCOBR.ToString(),
                V0ENDO_AGECOBR = V0ENDO_AGECOBR.ToString(),
                V0ENDO_DACCOBR = V0ENDO_DACCOBR.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V0ENDO_PCENTRAD = V0ENDO_PCENTRAD.ToString(),
                V0ENDO_PCADICIO = V0ENDO_PCADICIO.ToString(),
                V0ENDO_PRESTA1 = V0ENDO_PRESTA1.ToString(),
                V0ENDO_QTPARCEL = V0ENDO_QTPARCEL.ToString(),
                V0ENDO_QTPRESTA = V0ENDO_QTPRESTA.ToString(),
                V0ENDO_QTITENS = V0ENDO_QTITENS.ToString(),
                V0ENDO_CODTXT = V0ENDO_CODTXT.ToString(),
                V0ENDO_CDACEITA = V0ENDO_CDACEITA.ToString(),
                V0ENDO_MOEDA_IMP = V0ENDO_MOEDA_IMP.ToString(),
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_TIPO_ENDO = V0ENDO_TIPO_ENDO.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                V0ENDO_ISENTA_CST = V0ENDO_ISENTA_CST.ToString(),
                V0ENDO_DTVENCTO = V0ENDO_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0ENDO_CFPREFIX = V0ENDO_CFPREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                V0ENDO_VLCUSEMI = V0ENDO_VLCUSEMI.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-10-LOOP-PROPAUTOM-DB-UPDATE-1 */
        public void R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -1533- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 = new R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r1000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -982- EXEC SQL SELECT VALUE(IND_IOF, 'S' ) INTO :V0SUBG-IND-IOF FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND COD_SUBGRUPO = :V0HCTB-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0HCTB_CODSUBES = V0HCTB_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_IND_IOF, V0SUBG_IND_IOF);
            }


        }

        [StopWatch]
        /*" R1000-10-LOOP-PROPAUTOM-DB-INSERT-2 */
        public void R1000_10_LOOP_PROPAUTOM_DB_INSERT_2()
        {
            /*" -1593- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1 = new R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1()
            {
                V0PARC_NUM_APOL = V0PARC_NUM_APOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_DACPARC = V0PARC_DACPARC.ToString(),
                V0PARC_FONTE = V0PARC_FONTE.ToString(),
                V0PARC_NRTIT = V0PARC_NRTIT.ToString(),
                V0PARC_PRM_TAR_IX = V0PARC_PRM_TAR_IX.ToString(),
                V0PARC_VAL_DES_IX = V0PARC_VAL_DES_IX.ToString(),
                V0PARC_OTNPRLIQ = V0PARC_OTNPRLIQ.ToString(),
                V0PARC_OTNADFRA = V0PARC_OTNADFRA.ToString(),
                V0PARC_OTNCUSTO = V0PARC_OTNCUSTO.ToString(),
                V0PARC_OTNIOF = V0PARC_OTNIOF.ToString(),
                V0PARC_OTNTOTAL = V0PARC_OTNTOTAL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0PARC_QTDDOC = V0PARC_QTDDOC.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_COD_EMPRESA = V0PARC_COD_EMPRESA.ToString(),
            };

            R1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1.Execute(r1000_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-98-COMMIT */
        private void R1000_98_COMMIT(bool isPerform = false)
        {
            /*" -1734- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1737- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1737- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1000- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1019- EXEC SQL SELECT DTVENCTO INTO :V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-SECTION */
        private void R1050_00_ESTORNA_CONTABIL_SECTION()
        {
            /*" -1748- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1749- MOVE 14 TO SII. */
            _.Move(14, WS_HORAS.SII);

            /*" -1750- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1764- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1();

            /*" -1767- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1769- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1771- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1773- SUBTRACT 1 FROM V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS - 1;

            /*" -1775- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1776- MOVE 15 TO SII. */
            _.Move(15, WS_HORAS.SII);

            /*" -1777- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1782- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2();

            /*" -1785- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1786- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1786- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-1 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1()
        {
            /*" -1764- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 , DTFATUR = NULL WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTFATUR = :V1SIST-DTMOVABE AND NRPARCEL = :WHOST-NRPARCEL AND CODOPER = 1000 END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -1035- EXEC SQL SELECT DTVENCTO INTO :V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-2 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2()
        {
            /*" -1782- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -1059- EXEC SQL SELECT DTINIVIG, DTTERVIG INTO :V0COBP-DTINIVIG-ENDO, :V0COBP-DTTERVIG-ENDO FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_ENDO, V0COBP_DTINIVIG_ENDO);
                _.Move(executed_1.V0COBP_DTTERVIG_ENDO, V0COBP_DTTERVIG_ENDO);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -1190- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-SECTION */
        private void R1100_00_ACUMULA_PREMIO_SECTION()
        {
            /*" -1797- IF (V0HCTB-CODOPER = 1000) OR (V0HCTB-CODOPER > 499 AND V0HCTB-CODOPER < 600) */

            if ((V0HCTB_CODOPER == 1000) || (V0HCTB_CODOPER > 499 && V0HCTB_CODOPER < 600))
            {

                /*" -1799- GO TO R1100-00-NEXT. */

                R1100_00_NEXT(); //GOTO
                return;
            }


            /*" -1800- MOVE 'S' TO WTEM-CONVERSAO. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSAO);

            /*" -1802- MOVE '110A' TO WNR-EXEC-SQL. */
            _.Move("110A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1803- MOVE 16 TO SII. */
            _.Move(16, WS_HORAS.SII);

            /*" -1804- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1809- PERFORM R1100_00_ACUMULA_PREMIO_DB_SELECT_1 */

            R1100_00_ACUMULA_PREMIO_DB_SELECT_1();

            /*" -1812- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1814- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1815- MOVE 'N' TO WTEM-CONVERSAO */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSAO);

                    /*" -1816- ELSE */
                }
                else
                {


                    /*" -1818- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1819- IF V0PRVG-ESTR-COBR EQUAL 'MULT' */

            if (V0PRVG_ESTR_COBR == "MULT")
            {

                /*" -1820- IF WTEM-CONVERSAO EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_CONVERSAO == "S")
                {

                    /*" -1821- MOVE NUM-SICOB TO V0RCAP-NRTIT */
                    _.Move(NUM_SICOB, V0RCAP_NRTIT);

                    /*" -1822- ELSE */
                }
                else
                {


                    /*" -1823- MOVE V0HCTB-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0HCTB_NRCERTIF, V0RCAP_NRTIT);

                    /*" -1824- END-IF */
                }


                /*" -1825- ELSE */
            }
            else
            {


                /*" -1827- DISPLAY 'ESTRUTURA DE COBRANCA DESCONHECIDA ' V0PRVG-ESTR-COBR */
                _.Display($"ESTRUTURA DE COBRANCA DESCONHECIDA {V0PRVG_ESTR_COBR}");

                /*" -1829- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1831- MOVE V0PARC-DTVENCTO TO WS-DTBASE. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WS_DTBASE);

            /*" -1832- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -1835- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -1838- COMPUTE WS-PREMIO-LIQ ROUNDED = (V0HCTB-PRMVG + V0HCTB-PRMAP) / WS-IND-IOF */
            AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP) / AREA_DE_WORK.WS_IND_IOF;

            /*" -1842- COMPUTE WS-VLIOCC = V0HCTB-PRMVG + V0HCTB-PRMAP - WS-PREMIO-LIQ */
            AREA_DE_WORK.WS_VLIOCC.Value = V0HCTB_PRMVG + V0HCTB_PRMAP - AREA_DE_WORK.WS_PREMIO_LIQ;

            /*" -1844- COMPUTE WS-PRM-LIQ-AP ROUNDED = V0HCTB-PRMAP / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP / AREA_DE_WORK.WS_IND_IOF;

            /*" -1846- COMPUTE WS-VLIOCC-AP = V0HCTB-PRMAP - WS-PRM-LIQ-AP */
            AREA_DE_WORK.WS_VLIOCC_AP.Value = V0HCTB_PRMAP - AREA_DE_WORK.WS_PRM_LIQ_AP;

            /*" -1848- COMPUTE WS-PRM-LIQ-VG ROUNDED = V0HCTB-PRMVG / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG / AREA_DE_WORK.WS_IND_IOF;

            /*" -1851- COMPUTE WS-VLIOCC-VG = V0HCTB-PRMVG - WS-PRM-LIQ-VG. */
            AREA_DE_WORK.WS_VLIOCC_VG.Value = V0HCTB_PRMVG - AREA_DE_WORK.WS_PRM_LIQ_VG;

            /*" -1852- IF V0SUBG-IND-IOF = 'N' */

            if (V0SUBG_IND_IOF == "N")
            {

                /*" -1855- MOVE ZEROS TO WS-VLIOCC WS-VLIOCC-VG WS-VLIOCC-AP */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC, AREA_DE_WORK.WS_VLIOCC_VG, AREA_DE_WORK.WS_VLIOCC_AP);

                /*" -1857- COMPUTE WS-PREMIO-LIQ = (V0HCTB-PRMVG + V0HCTB-PRMAP) */
                AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP);

                /*" -1858- COMPUTE WS-PRM-LIQ-VG = V0HCTB-PRMVG */
                AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG;

                /*" -1861- COMPUTE WS-PRM-LIQ-AP = V0HCTB-PRMAP. */
                AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP;
            }


            /*" -1864- MOVE 0 TO WS-PRMRTO WS-VLIOCC-RTO. */
            _.Move(0, AREA_DE_WORK.WS_PRMRTO, AREA_DE_WORK.WS_VLIOCC_RTO);

            /*" -1866- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -1867- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT + WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT + AREA_DE_WORK.WS_VLIOCC;

                /*" -1868- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP + WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP + AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -1869- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG + WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -1871- COMPUTE WS-VLIOCC-TOT-RTO = WS-VLIOCC-TOT-RTO + WS-VLIOCC-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_RTO.Value = AREA_DE_WORK.WS_VLIOCC_TOT_RTO + AREA_DE_WORK.WS_VLIOCC_RTO;

                /*" -1872- COMPUTE AC-PRMVG = AC-PRMVG + V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG + V0HCTB_PRMVG;

                /*" -1873- COMPUTE AC-PRMAP = AC-PRMAP + V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP + V0HCTB_PRMAP;

                /*" -1874- COMPUTE AC-PRMRTO = AC-PRMRTO + WS-PRMRTO */
                AREA_DE_WORK.AC_PRMRTO.Value = AREA_DE_WORK.AC_PRMRTO + AREA_DE_WORK.WS_PRMRTO;

                /*" -1875- ELSE */
            }
            else
            {


                /*" -1876- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT - WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT - AREA_DE_WORK.WS_VLIOCC;

                /*" -1877- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP - WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP - AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -1878- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -1880- COMPUTE WS-VLIOCC-TOT-RTO = WS-VLIOCC-TOT-RTO - WS-VLIOCC-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_RTO.Value = AREA_DE_WORK.WS_VLIOCC_TOT_RTO - AREA_DE_WORK.WS_VLIOCC_RTO;

                /*" -1881- COMPUTE AC-PRMVG = AC-PRMVG - V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - V0HCTB_PRMVG;

                /*" -1882- COMPUTE AC-PRMAP = AC-PRMAP - V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP - V0HCTB_PRMAP;

                /*" -1884- COMPUTE AC-PRMRTO = AC-PRMRTO - WS-PRMRTO. */
                AREA_DE_WORK.AC_PRMRTO.Value = AREA_DE_WORK.AC_PRMRTO - AREA_DE_WORK.WS_PRMRTO;
            }


            /*" -1886- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1887- MOVE 18 TO SII. */
            _.Move(18, WS_HORAS.SII);

            /*" -1888- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1898- PERFORM R1100_00_ACUMULA_PREMIO_DB_UPDATE_1 */

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1();

            /*" -1901- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1902- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1904- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1906- ADD +1 TO AC-U-V0HISTCONTABILVA. */
            AREA_DE_WORK.AC_U_V0HISTCONTABILVA.Value = AREA_DE_WORK.AC_U_V0HISTCONTABILVA + +1;

            /*" -1908- IF V0HCTB-SITUACAO EQUAL '0' AND V0HCTB-NRPARCEL EQUAL 1 */

            if (V0HCTB_SITUACAO == "0" && V0HCTB_NRPARCEL == 1)
            {

                /*" -1908- PERFORM R1110-00-VERIFICA-RCAP. */

                R1110_00_VERIFICA_RCAP_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-SELECT-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_SELECT_1()
        {
            /*" -1809- EXEC SQL SELECT NUM_SICOB INTO :NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0HCTB-NRCERTIF END-EXEC. */

            var r1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1 = new R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1.Execute(r1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, NUM_SICOB);
            }


        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-UPDATE-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_UPDATE_1()
        {
            /*" -1898- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' , NRENDOS = :V0ENDO-NRENDOS, DTFATUR = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST END-EXEC. */

            var r1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1 = new R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
                V0HCTB_OCORHIST = V0HCTB_OCORHIST.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1.Execute(r1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-7 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_7()
        {
            /*" -1072- EXEC SQL SELECT DTINIVIG, DTTERVIG INTO :V0COBP-DTINIVIG-ENDO, :V0COBP-DTTERVIG-ENDO FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_ENDO, V0COBP_DTINIVIG_ENDO);
                _.Move(executed_1.V0COBP_DTTERVIG_ENDO, V0COBP_DTTERVIG_ENDO);
            }


        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -1912- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-8 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_8()
        {
            /*" -1094- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-9 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_9()
        {
            /*" -1119- EXEC SQL SELECT DATE(:V0ENDO-DTINIVIG) + :V0OPCP-PERIPGTO MONTHS - 1 DAY INTO :V0ENDO-DTTERVIG FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1()
            {
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-SECTION */
        private void R1102_00_SELECT_RCAP_SECTION()
        {
            /*" -1923- MOVE '1102' TO WNR-EXEC-SQL. */
            _.Move("1102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1924- MOVE 'S' TO WTEM-V0RCAP. */
            _.Move("S", AREA_DE_WORK.WTEM_V0RCAP);

            /*" -2003- MOVE V0HCTB-NRTIT TO V0RCAP-NRTIT. */
            _.Move(V0HCTB_NRTIT, V0RCAP_NRTIT);

            /*" -2005- MOVE '11A3' TO WNR-EXEC-SQL. */
            _.Move("11A3", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2006- MOVE 20 TO SII. */
            _.Move(20, WS_HORAS.SII);

            /*" -2007- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2015- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_1 */

            R1102_00_SELECT_RCAP_DB_SELECT_1();

            /*" -2018- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2019- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2020- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2024- DISPLAY 'TITULO / AVISO ' V0RCAP-NRTIT ' ' V1RCAC-AGEAVISO ' ' V1RCAC-NRAVISO */

                    $"TITULO / AVISO {V0RCAP_NRTIT} {V1RCAC_AGEAVISO} {V1RCAC_NRAVISO}"
                    .Display();

                    /*" -2025- MOVE 'N' TO WTEM-V0RCAP */
                    _.Move("N", AREA_DE_WORK.WTEM_V0RCAP);

                    /*" -2026- GO TO R1102-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/ //GOTO
                    return;

                    /*" -2027- ELSE */
                }
                else
                {


                    /*" -2029- DISPLAY 'TITULO / AVISO ' V0RCAP-NRTIT ' ' V1RCAC-AGEAVISO ' ' V1RCAC-NRAVISO */

                    $"TITULO / AVISO {V0RCAP_NRTIT} {V1RCAC_AGEAVISO} {V1RCAC_NRAVISO}"
                    .Display();

                    /*" -2030- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2031- END-IF */
                }


                /*" -2031- END-IF. */
            }


        }

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-1 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_1()
        {
            /*" -2015- EXEC SQL SELECT AGEAVISO , NRAVISO INTO :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO FROM SEGUROS.V0HISTCOBVA WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r1102_00_SELECT_RCAP_DB_SELECT_1_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_1_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-10 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_10()
        {
            /*" -1145- EXEC SQL SELECT CODSUBES, DTTERVIG INTO :WHOST-CODSUBES, :WHOST-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 AND DTTERVIG > :V0ENDO-DTINIVIG END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_10_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_10_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_10_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODSUBES, WHOST_CODSUBES);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-11 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_11()
        {
            /*" -1173- EXEC SQL SELECT ENDOSCOB INTO :V0ENDO-NRENDOS FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_11_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_11_Query1()
            {
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_11_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-SECTION */
        private void R1105_00_ACESSA_V1RAMOIND_SECTION()
        {
            /*" -2042- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2043- MOVE V0APOL-RAMO TO V1RIND-RAMO */
            _.Move(V0APOL_RAMO, V1RIND_RAMO);

            /*" -2045- MOVE WS-DTBASE TO V1RIND-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DTBASE, V1RIND_DTINIVIG);

            /*" -2046- MOVE 21 TO SII. */
            _.Move(21, WS_HORAS.SII);

            /*" -2047- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2054- PERFORM R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1 */

            R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();

            /*" -2057- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2058- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2059- DISPLAY 'PROBLEMA NO ACESSAO V1RAMOIND' */
                _.Display($"PROBLEMA NO ACESSAO V1RAMOIND");

                /*" -2059- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-DB-SELECT-1 */
        public void R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1()
        {
            /*" -2054- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1RIND-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

            var r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 = new R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1()
            {
                V1RIND_DTINIVIG = V1RIND_DTINIVIG.ToString(),
                V1RIND_RAMO = V1RIND_RAMO.ToString(),
            };

            var executed_1 = R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1.Execute(r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-12 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_12()
        {
            /*" -1342- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_12_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_12_Query1()
            {
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_12_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_12_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-SECTION */
        private void R1110_00_VERIFICA_RCAP_SECTION()
        {
            /*" -2070- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -2072- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2073- MOVE 24 TO SII. */
            _.Move(24, WS_HORAS.SII);

            /*" -2074- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2086- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_1 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_1();

            /*" -2089- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2090- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2091- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2092- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -2093- ELSE */
                }
                else
                {


                    /*" -2095- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2096- IF V0RCAP-SITUACAO EQUAL '1' */

            if (V0RCAP_SITUACAO == "1")
            {

                /*" -2097- MOVE '1110' TO WNR-EXEC-SQL */
                _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2103- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_1 */

                R1110_00_VERIFICA_RCAP_DB_UPDATE_1();

                /*" -2105- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2107- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2109- MOVE '1113' TO WNR-EXEC-SQL. */
            _.Move("1113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2110- MOVE 25 TO SII. */
            _.Move(25, WS_HORAS.SII);

            /*" -2111- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2127- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_2 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_2();

            /*" -2130- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2131- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2133- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2135- PERFORM R1120-00-BAIXA-RCAP. */

            R1120_00_BAIXA_RCAP_SECTION();

            /*" -2137- MOVE '1115' TO WNR-EXEC-SQL. */
            _.Move("1115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2138- MOVE 26 TO SII. */
            _.Move(26, WS_HORAS.SII);

            /*" -2139- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2149- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_2 */

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2();

            /*" -2152- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2153- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2155- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2155- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-1 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -2086- EXEC SQL SELECT FONTE, NRRCAP, SITUACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V0RCAP-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO IN ( '0' , '1' ) END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-UPDATE-1 */
        public void R1110_00_VERIFICA_RCAP_DB_UPDATE_1()
        {
            /*" -2103- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRENDOS = :V0ENDO-NRENDOS, TIMESTAMP = CURRENT TIMESTAMP WHERE NRRCAP = :V0RCAP-NRRCAP END-EXEC */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-2 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -2127- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-UPDATE-2 */
        public void R1110_00_VERIFICA_RCAP_DB_UPDATE_2()
        {
            /*" -2149- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0ENDO-NUM-APOLICE, NRENDOS = :V0ENDO-NRENDOS, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1120-00-BAIXA-RCAP-SECTION */
        private void R1120_00_BAIXA_RCAP_SECTION()
        {
            /*" -2164- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1120_10_DECLARE_V0RCAPCOMP */

            R1120_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP */
        private void R1120_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -2169- MOVE 27 TO SII. */
            _.Move(27, WS_HORAS.SII);

            /*" -2170- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2191- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -2193- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -2196- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2197- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2197- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -2193- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-DECLARE-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1()
        {
            /*" -2422- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT DISTINCT CODCOSS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG ORDER BY CODCOSS END-EXEC. */
            V1APOLCOSCED = new VG1139B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT DISTINCT CODCOSS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V0ENDO_NUM_APOLICE}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}' 
							ORDER BY CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP */
        private void R1120_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -2204- MOVE '1121' TO WNR-EXEC-SQL. */
            _.Move("1121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2219- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -2222- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2223- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2223- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -2225- GO TO R1120-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/ //GOTO
                    return;

                    /*" -2226- ELSE */
                }
                else
                {


                    /*" -2226- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -2219- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.V1RCAC_FONTE, V1RCAC_FONTE);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAP, V1RCAC_NRRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAPCO, V1RCAC_NRRCAPCO);
                _.Move(V1RCAPCOMP.V1RCAC_OPERACAO, V1RCAC_OPERACAO);
                _.Move(V1RCAPCOMP.V1RCAC_DTMOVTO, V1RCAC_DTMOVTO);
                _.Move(V1RCAPCOMP.V1RCAC_HORAOPER, V1RCAC_HORAOPER);
                _.Move(V1RCAPCOMP.V1RCAC_SITUACAO, V1RCAC_SITUACAO);
                _.Move(V1RCAPCOMP.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_VLRCAP, V1RCAC_VLRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DTCADAST, V1RCAC_DTCADAST);
                _.Move(V1RCAPCOMP.V1RCAC_SITCONTB, V1RCAC_SITCONTB);
            }

        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -2223- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP */
        private void R1120_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -2232- MOVE '1122' TO WNR-EXEC-SQL. */
            _.Move("1122", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2233- MOVE 28 TO SII. */
            _.Move(28, WS_HORAS.SII);

            /*" -2234- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2244- PERFORM R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -2247- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2250- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2250- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -2244- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
            };

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP */
        private void R1120_40_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -2256- MOVE '1123' TO WNR-EXEC-SQL. */
            _.Move("1123", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2257- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -2258- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -2260- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -2261- MOVE 29 TO SII. */
            _.Move(29, WS_HORAS.SII);

            /*" -2262- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2280- PERFORM R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -2283- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2286- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2288- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -2280- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , CURRENT TIME, :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
                V1RCAC_SITUACAO = V1RCAC_SITUACAO.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_DATARCAP = V1RCAC_DATARCAP.ToString(),
                V1RCAC_DTCADAST = V1RCAC_DTCADAST.ToString(),
                V1RCAC_SITCONTB = V1RCAC_SITCONTB.ToString(),
                V1RCAC_COD_EMPRESA = V1RCAC_COD_EMPRESA.ToString(),
            };

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO */
        private void R1120_50_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -2294- MOVE '1124' TO WNR-EXEC-SQL. */
            _.Move("1124", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2295- MOVE 30 TO SII. */
            _.Move(30, WS_HORAS.SII);

            /*" -2296- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2303- PERFORM R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -2306- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2308- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2312- GO TO R1120-20-FETCH-V0RCAPCOMP. */

            R1120_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -2303- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-SECTION */
        private void R1200_00_ACUMULA_IS_SECTION()
        {
            /*" -2321- PERFORM R1210-00-ACUMULA-IS. */

            R1210_00_ACUMULA_IS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-SECTION */
        private void R1210_00_ACUMULA_IS_SECTION()
        {
            /*" -2332- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2333- MOVE 32 TO SII. */
            _.Move(32, WS_HORAS.SII);

            /*" -2334- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2354- PERFORM R1210_00_ACUMULA_IS_DB_SELECT_1 */

            R1210_00_ACUMULA_IS_DB_SELECT_1();

            /*" -2357- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2358- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2360- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2361- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2363- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2364- IF V0CBPR-PRMDIT-I LESS ZEROS */

            if (V0CBPR_PRMDIT_I < 00)
            {

                /*" -2366- MOVE ZEROS TO V0CBPR-PRMDIT. */
                _.Move(0, V0CBPR_PRMDIT);
            }


            /*" -2367- COMPUTE AC-IMPMORNATU = AC-IMPMORNATU + V0CBPR-IMPMORNATU. */
            AREA_DE_WORK.AC_IMPMORNATU.Value = AREA_DE_WORK.AC_IMPMORNATU + V0CBPR_IMPMORNATU;

            /*" -2368- COMPUTE AC-IMPMORACID = AC-IMPMORACID + V0CBPR-IMPMORACID. */
            AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID + V0CBPR_IMPMORACID;

            /*" -2369- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM + V0CBPR-IMPINVPERM. */
            AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM + V0CBPR_IMPINVPERM;

            /*" -2370- COMPUTE AC-IMPAMDS = AC-IMPAMDS + V0CBPR-IMPAMDS. */
            AREA_DE_WORK.AC_IMPAMDS.Value = AREA_DE_WORK.AC_IMPAMDS + V0CBPR_IMPAMDS;

            /*" -2371- COMPUTE AC-IMPDH = AC-IMPDH + V0CBPR-IMPDH. */
            AREA_DE_WORK.AC_IMPDH.Value = AREA_DE_WORK.AC_IMPDH + V0CBPR_IMPDH;

            /*" -2373- COMPUTE AC-IMPDIT = AC-IMPDIT + V0CBPR-IMPDIT. */
            AREA_DE_WORK.AC_IMPDIT.Value = AREA_DE_WORK.AC_IMPDIT + V0CBPR_IMPDIT;

            /*" -2374- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

            if (V0CBPR_IMPDIT != 00)
            {

                /*" -2374- PERFORM R1220-00-LE-PREMIO-DIT. */

                R1220_00_LE_PREMIO_DIT_SECTION();
            }


        }

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-DB-SELECT-1 */
        public void R1210_00_ACUMULA_IS_DB_SELECT_1()
        {
            /*" -2354- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, PRMDIT INTO :V0CBPR-IMPMORNATU, :V0CBPR-IMPMORACID, :V0CBPR-IMPINVPERM, :V0CBPR-IMPAMDS, :V0CBPR-IMPDH, :V0CBPR-IMPDIT, :V0CBPR-PRMDIT:V0CBPR-PRMDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND OCORHIST = :WHOST-NRPARCEL END-EXEC. */

            var r1210_00_ACUMULA_IS_DB_SELECT_1_Query1 = new R1210_00_ACUMULA_IS_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
            };

            var executed_1 = R1210_00_ACUMULA_IS_DB_SELECT_1_Query1.Execute(r1210_00_ACUMULA_IS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CBPR_IMPMORNATU, V0CBPR_IMPMORNATU);
                _.Move(executed_1.V0CBPR_IMPMORACID, V0CBPR_IMPMORACID);
                _.Move(executed_1.V0CBPR_IMPINVPERM, V0CBPR_IMPINVPERM);
                _.Move(executed_1.V0CBPR_IMPAMDS, V0CBPR_IMPAMDS);
                _.Move(executed_1.V0CBPR_IMPDH, V0CBPR_IMPDH);
                _.Move(executed_1.V0CBPR_IMPDIT, V0CBPR_IMPDIT);
                _.Move(executed_1.V0CBPR_PRMDIT, V0CBPR_PRMDIT);
                _.Move(executed_1.V0CBPR_PRMDIT_I, V0CBPR_PRMDIT_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-SECTION */
        private void R1220_00_LE_PREMIO_DIT_SECTION()
        {
            /*" -2385- MOVE V0CBPR-PRMDIT TO V0PLAN-PRMDIT. */
            _.Move(V0CBPR_PRMDIT, V0PLAN_PRMDIT);

            /*" -2387- MOVE '1222' TO WNR-EXEC-SQL. */
            _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2389- MOVE V0PARC-DTVENCTO TO WS-DTBASE. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WS_DTBASE);

            /*" -2391- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -2393- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -2395- COMPUTE WS-PRM-LIQ-DIT ROUNDED = V0PLAN-PRMDIT / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_DIT.Value = V0PLAN_PRMDIT / AREA_DE_WORK.WS_IND_IOF;

            /*" -2398- COMPUTE WS-VLIOCC-DIT = V0PLAN-PRMDIT - WS-PRM-LIQ-DIT */
            AREA_DE_WORK.WS_VLIOCC_DIT.Value = V0PLAN_PRMDIT - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -2399- IF V0SUBG-IND-IOF = 'N' */

            if (V0SUBG_IND_IOF == "N")
            {

                /*" -2400- MOVE ZEROS TO WS-VLIOCC-DIT */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_DIT);

                /*" -2402- MOVE V0PLAN-PRMDIT TO WS-PRM-LIQ-DIT. */
                _.Move(V0PLAN_PRMDIT, AREA_DE_WORK.WS_PRM_LIQ_DIT);
            }


            /*" -2403- ADD V0PLAN-PRMDIT TO AC-PRMDIT. */
            AREA_DE_WORK.AC_PRMDIT.Value = AREA_DE_WORK.AC_PRMDIT + V0PLAN_PRMDIT;

            /*" -2404- COMPUTE WS-VLIOCC-TOT-DIT = WS-VLIOCC-TOT-DIT + WS-VLIOCC-DIT. */
            AREA_DE_WORK.WS_VLIOCC_TOT_DIT.Value = AREA_DE_WORK.WS_VLIOCC_TOT_DIT + AREA_DE_WORK.WS_VLIOCC_DIT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-SECTION */
        private void R1300_00_GRAVA_COSSEGURO_SECTION()
        {
            /*" -2414- MOVE 34 TO SII. */
            _.Move(34, WS_HORAS.SII);

            /*" -2415- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2422- PERFORM R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1 */

            R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1();

            /*" -2425- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2426- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2426- PERFORM R1300_00_GRAVA_COSSEGURO_DB_OPEN_1 */

            R1300_00_GRAVA_COSSEGURO_DB_OPEN_1();

            /*" -2429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2429- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_10_FETCH_V1APOLCOSCED */

            R1300_10_FETCH_V1APOLCOSCED();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-OPEN-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_OPEN_1()
        {
            /*" -2426- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED */
        private void R1300_10_FETCH_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -2436- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2438- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -2441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2442- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2442- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -2444- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2445- ELSE */
                }
                else
                {


                    /*" -2448- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2450- MOVE '1303' TO WNR-EXEC-SQL. */
            _.Move("1303", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2451- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -2452- MOVE V0ENDO-NUM-APOLICE TO V0ORDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0ORDC_NUM_APOL);

            /*" -2453- MOVE V0ENDO-NRENDOS TO V0ORDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0ORDC_NRENDOS);

            /*" -2455- MOVE V1COSP-CONGENER TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V1COSP_CONGENER, V0ORDC_CODCOSS);
            _.Move(V1COSP_CONGENER, AREA_DE_WORK.FILLER_5.WWORK_ORD_CONGE);


            /*" -2457- MOVE V0APOL-ORGAO TO WWORK-ORD-ORGAO. */
            _.Move(V0APOL_ORGAO, AREA_DE_WORK.FILLER_5.WWORK_ORD_ORGAO);

            /*" -2458- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -2460- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -2466- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1();

            /*" -2469- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2470- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2472- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2474- MOVE '2288' TO WNR-EXEC-SQL. */
            _.Move("2288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2476- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -2478- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_5.WWORK_ORD_SEQUE);

            /*" -2480- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -2481- MOVE 35 TO SII. */
            _.Move(35, WS_HORAS.SII);

            /*" -2482- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2490- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1();

            /*" -2493- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2494- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2496- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2498- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -2500- MOVE '1304' TO WNR-EXEC-SQL. */
            _.Move("1304", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2501- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -2503- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -2504- MOVE 36 TO SII. */
            _.Move(36, WS_HORAS.SII);

            /*" -2505- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2511- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1();

            /*" -2514- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2517- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2519- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

            /*" -2520- MOVE 'EM0103B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0103B1", V0EDIA_CODRELAT);

            /*" -2521- MOVE V0ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -2522- MOVE V0ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -2523- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -2524- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -2525- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -2526- MOVE V0APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(V0APOL_RAMO, V0EDIA_RAMO);

            /*" -2527- MOVE ZEROS TO V0EDIA-FONTE. */
            _.Move(0, V0EDIA_FONTE);

            /*" -2528- MOVE V1COSP-CONGENER TO V0EDIA-CONGENER. */
            _.Move(V1COSP_CONGENER, V0EDIA_CONGENER);

            /*" -2530- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -2532- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -2533- MOVE V0ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(V0ENDO_FONTE, V0EDIA_FONTE);

            /*" -2534- MOVE 'EM0105B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0105B1", V0EDIA_CODRELAT);

            /*" -2536- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -2536- GO TO R1300-10-FETCH-V1APOLCOSCED. */
            new Task(() => R1300_10_FETCH_V1APOLCOSCED()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -2438- EXEC SQL FETCH V1APOLCOSCED INTO :V1COSP-CONGENER END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1COSP_CONGENER, V1COSP_CONGENER);
            }

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -2442- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-SELECT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -2466- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1 = new R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1()
            {
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            var executed_1 = R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NCOS_NRORDEM, V1NCOS_NRORDEM);
            }


        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-INSERT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1()
        {
            /*" -2490- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1 = new R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0ORDC_NUM_APOL = V0ORDC_NUM_APOL.ToString(),
                V0ORDC_NRENDOS = V0ORDC_NRENDOS.ToString(),
                V0ORDC_CODCOSS = V0ORDC_CODCOSS.ToString(),
                V0ORDC_ORDEM_CED = V0ORDC_ORDEM_CED.ToString(),
                V0ORDC_COD_EMPRESA = V0ORDC_COD_EMPRESA.ToString(),
            };

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-UPDATE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1()
        {
            /*" -2511- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 = new R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1()
            {
                V1NCOS_NRORDEM = V1NCOS_NRORDEM.ToString(),
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-V0HISTOPARC-SECTION */
        private void R1400_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -2547- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2548- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -2550- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -2551- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -2552- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -2553- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -2555- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -2557- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -2558- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -2559- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -2560- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -2561- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -2562- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -2563- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -2565- COMPUTE V0HISP-VLIOCC = V0HISP-VLPRMTOT - V0HISP-VLPRMLIQ */
            V0HISP_VLIOCC.Value = V0HISP_VLPRMTOT - V0HISP_VLPRMLIQ;

            /*" -2566- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -2567- MOVE V0HCOB-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V0HCOB_DTVENCTO, V0HISP_DTVENCTO);

            /*" -2568- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -2569- MOVE 0 TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2570- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -2571- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -2572- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2573- MOVE 'VG1139B' TO V0HISP-COD-USUAR */
            _.Move("VG1139B", V0HISP_COD_USUAR);

            /*" -2575- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2577- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -2579- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -2579- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R1500_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -2589- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -2590- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -2592- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -2593- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -2594- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -2596- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -2598- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -2599- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -2600- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -2601- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -2602- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -2603- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -2604- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -2606- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -2607- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -2608- MOVE V0HCOB-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V0HCOB_DTVENCTO, V0HISP_DTVENCTO);

            /*" -2610- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -2612- PERFORM R1102-00-SELECT-RCAP */

            R1102_00_SELECT_RCAP_SECTION();

            /*" -2613- IF WTEM-V0RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_V0RCAP == "S")
            {

                /*" -2614- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
                _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

                /*" -2615- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
                _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

                /*" -2616- ELSE */
            }
            else
            {


                /*" -2617- MOVE 0 TO V0HISP-NRAVISO */
                _.Move(0, V0HISP_NRAVISO);

                /*" -2618- MOVE 0 TO V0HISP-AGECOBR */
                _.Move(0, V0HISP_AGECOBR);

                /*" -2620- END-IF */
            }


            /*" -2621- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -2622- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2623- MOVE 'VG1139B' TO V0HISP-COD-USUAR */
            _.Move("VG1139B", V0HISP_COD_USUAR);

            /*" -2625- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2626- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -2628- MOVE V0HCTB-DTMOVTO-ANT TO V0HISP-DTQITBCO. */
            _.Move(V0HCTB_DTMOVTO_ANT, V0HISP_DTQITBCO);

            /*" -2630- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -2632- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

            /*" -2632- PERFORM R1480-00-UPDATE-V0RCAP. */

            R1480_00_UPDATE_V0RCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-SECTION */
        private void R1450_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -2643- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2644- MOVE 37 TO SII. */
            _.Move(37, WS_HORAS.SII);

            /*" -2645- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2674- PERFORM R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -2677- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2678- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2680- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -2674- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TARIFA = V0HISP_PRM_TARIFA.ToString(),
                V0HISP_VAL_DESCON = V0HISP_VAL_DESCON.ToString(),
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
                V0HISP_COD_USUAR = V0HISP_COD_USUAR.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1480-00-UPDATE-V0RCAP-SECTION */
        private void R1480_00_UPDATE_V0RCAP_SECTION()
        {
            /*" -2691- MOVE '1480' TO WNR-EXEC-SQL. */
            _.Move("1480", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2695- PERFORM R1480_00_UPDATE_V0RCAP_DB_UPDATE_1 */

            R1480_00_UPDATE_V0RCAP_DB_UPDATE_1();

            /*" -2698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2700- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2701- ELSE */
                }
                else
                {


                    /*" -2701- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1480-00-UPDATE-V0RCAP-DB-UPDATE-1 */
        public void R1480_00_UPDATE_V0RCAP_DB_UPDATE_1()
        {
            /*" -2695- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRENDOS = :V0ENDO-NRENDOS WHERE NRTIT = :V0HCTB-NRTIT END-EXEC */

            var r1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 = new R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1.Execute(r1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1480_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-SECTION */
        private void R1600_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -2713- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2714- MOVE 38 TO SII. */
            _.Move(38, WS_HORAS.SII);

            /*" -2715- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2735- PERFORM R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -2738- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2741- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2741- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -2735- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1 = new R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_IMP_SEG_IX = V0COBA_IMP_SEG_IX.ToString(),
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_IMP_SEG_VR = V0COBA_IMP_SEG_VR.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_FATOR_MULT = V0COBA_FATOR_MULT.ToString(),
                V0COBA_DATA_INIVI = V0COBA_DATA_INIVI.ToString(),
                V0COBA_DATA_TERVI = V0COBA_DATA_TERVI.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
                V0COBA_SITUACAO = V0COBA_SITUACAO.ToString(),
                VIND_SITUACAO = VIND_SITUACAO.ToString(),
            };

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-SECTION */
        private void R1700_INCLUI_V0EMISDIARIA_SECTION()
        {
            /*" -2752- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2753- MOVE 39 TO SII. */
            _.Move(39, WS_HORAS.SII);

            /*" -2754- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2769- PERFORM R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -2772- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2774- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2776- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2778- DISPLAY 'R1700-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1700-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -2780- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2780- ADD 1 TO AC-I-V0EMISDIARIA. */
            AREA_DE_WORK.AC_I_V0EMISDIARIA.Value = AREA_DE_WORK.AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -2769- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , NULL , CURRENT TIMESTAMP) END-EXEC. */

            var r1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1()
            {
                V0EDIA_CODRELAT = V0EDIA_CODRELAT.ToString(),
                V0EDIA_NUM_APOL = V0EDIA_NUM_APOL.ToString(),
                V0EDIA_NRENDOS = V0EDIA_NRENDOS.ToString(),
                V0EDIA_NRPARCEL = V0EDIA_NRPARCEL.ToString(),
                V0EDIA_DTMOVTO = V0EDIA_DTMOVTO.ToString(),
                V0EDIA_ORGAO = V0EDIA_ORGAO.ToString(),
                V0EDIA_RAMO = V0EDIA_RAMO.ToString(),
                V0EDIA_FONTE = V0EDIA_FONTE.ToString(),
                V0EDIA_CONGENER = V0EDIA_CONGENER.ToString(),
                V0EDIA_CODCORR = V0EDIA_CODCORR.ToString(),
                V0EDIA_SITUACAO = V0EDIA_SITUACAO.ToString(),
            };

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -2792- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -2793- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2794- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2796- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2797- DISPLAY 'LIDOS  V0HISTCONTABILVA  ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS  V0HISTCONTABILVA  {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -2798- DISPLAY 'INSERT V0ENDOSSO         ' AC-I-V0ENDOSSO. */
            _.Display($"INSERT V0ENDOSSO         {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -2799- DISPLAY 'INSERT V0RCAPCOMP        ' AC-I-V0RCAPCOMP. */
            _.Display($"INSERT V0RCAPCOMP        {AREA_DE_WORK.AC_I_V0RCAPCOMP}");

            /*" -2800- DISPLAY 'INSERT V0ORDECOSCED      ' AC-I-V0ORDECOSCED. */
            _.Display($"INSERT V0ORDECOSCED      {AREA_DE_WORK.AC_I_V0ORDECOSCED}");

            /*" -2801- DISPLAY 'INSERT V0EMISDIARIA      ' AC-I-V0EMISDIARIA. */
            _.Display($"INSERT V0EMISDIARIA      {AREA_DE_WORK.AC_I_V0EMISDIARIA}");

            /*" -2802- DISPLAY 'INSERT V0PARCELA         ' AC-I-V0PARCELA. */
            _.Display($"INSERT V0PARCELA         {AREA_DE_WORK.AC_I_V0PARCELA}");

            /*" -2803- DISPLAY 'INSERT V0HISTOPARC       ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC       {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -2805- DISPLAY 'INSERT V0COBERAPOL       ' AC-I-V0COBERAPOL. */
            _.Display($"INSERT V0COBERAPOL       {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -2806- DISPLAY 'UPDATE V0RCAP            ' AC-U-V0RCAP. */
            _.Display($"UPDATE V0RCAP            {AREA_DE_WORK.AC_U_V0RCAP}");

            /*" -2807- DISPLAY 'UPDATE V0RCAPCOMP        ' AC-U-V0RCAPCOMP. */
            _.Display($"UPDATE V0RCAPCOMP        {AREA_DE_WORK.AC_U_V0RCAPCOMP}");

            /*" -2808- DISPLAY 'UPDATE V0NUMEROAES       ' AC-U-V0NUMERAES. */
            _.Display($"UPDATE V0NUMEROAES       {AREA_DE_WORK.AC_U_V0NUMERAES}");

            /*" -2809- DISPLAY 'UPDATE V0FONTE           ' AC-U-V0FONTE. */
            _.Display($"UPDATE V0FONTE           {AREA_DE_WORK.AC_U_V0FONTE}");

            /*" -2810- DISPLAY 'UPDATE V0HISTCONTABILVA  ' AC-U-V0HISTCONTABILVA. */
            _.Display($"UPDATE V0HISTCONTABILVA  {AREA_DE_WORK.AC_U_V0HISTCONTABILVA}");

            /*" -2810- DISPLAY 'UPDATE V0NUMERO-COSSEGURO' AC-U-V0NUMERO-COSSEGURO. */
            _.Display($"UPDATE V0NUMERO-COSSEGURO{AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -2819- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2820- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -2829- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2830- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2831- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2832- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_21[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_21[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -2833- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_21[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_21[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -2842- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2843- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -2848- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -2849- IF SII < 51 */

            if (WS_HORAS.SII < 51)
            {

                /*" -2850- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_21[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -2852- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_21[WS_HORAS.SII]}"
                .Display();

                /*" -2854- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2855- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2867- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2876- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2877- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -2879- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -2879- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2881- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2885- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2885- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}