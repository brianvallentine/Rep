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
using Sias.VidaAzul.DB2.VA1139B;

namespace Code
{
    public class VA1139B
    {
        public bool IsCall { get; set; }

        public VA1139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL MULTIPREMIADO/GLOBAL/FENAM *      */
        /*"      *   PROGRAMA ...............  VA1139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *  VERSAO 07 - TAREFA: 212833    HISTORIA: 211791                *      */
        /*"      *            - TRATAMENTO PARA JV1                               *      */
        /*"      *            - BUSCAR E TRABALHAR COM O ORGAO EMISSOR DA APOLICE.*      */
        /*"      *                                                                *      */
        /*"      *  EM 20/09/2019 -  HERVAL SOUZA                                 *      */
        /*"      *  EM 06/04/2020 -  HERVAL SOUZA :SOLICITADO PROMO��O P/PRODUCAO *      */
        /*"      *                                           PROCURE POR JV.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACOES                                      *      */
        /*"      *                                                                *      */
        /*"      *   09/10/1998                TERCIO                             *      */
        /*"      *                             CONVERTE FONTE 0 PARA FONTE 5      *      */
        /*"      *                             PARA QUE NAO SEJA GERADO ENDOSSO   *      */
        /*"      *                             NA FONTE 0, CAUSANDO PROBLEMAS     *      */
        /*"      *                             PARA A CONTABILIDADE.              *      */
        /*"      *                             PROCURE TL9810.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   23/11/1998                CLOVIS                             *      */
        /*"      *                             ALTERA V0AVISOS_SALDOS.            *      */
        /*"      *                             PROCURE CL9811.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   26/09/1999                TERCIO                             *      */
        /*"      *                             O PROGRAMA FOI ALTERADO PARA       *      */
        /*"      *                             NAO MAIS TRATAR PRODUTO.           *      */
        /*"      *                             PROCURE TL9906                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  10/11/1997                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO HISTORICO DE           *      */
        /*"      *                             CONTABILIZACAO DE PARCELAS         *      */
        /*"      *                             (V0HISTCONTABILVA), GERA O ENDOSSO *      */
        /*"      *                             CORRESPONDENTE PARA REGISTRAR A    *      */
        /*"      *                             EMISSAO E A COBRANCA               *      */
        /*"      *                        ***  APOLICES FENAM        ****         *      */
        /*"      *                        ***  APOLICE  CAAES        ****         *      */
        /*"      *----------------------------------------------------------------*      */
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
        /*"77              V1RIND-RAMO           PIC S9(004)      COMP.*/
        public IntBasis V1RIND_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              V1RIND-DTINIVIG       PIC  X(010).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77              V1RIND-PCIOF          PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77              WS-DTRENOVA           PIC X(010).*/
        public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77              WS-DTINIVIG           PIC X(010).*/
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
        /*"01         V0APOL-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-ORGAO        PIC S9(008)      VALUE +0 COMP-5.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"01         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-IDADE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-OPCAO-COBER  PIC  X(001).*/
        public StringBasis V0PROP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0COND-IEA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPD          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0PLAN-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"01         V0ENDO-DTVENCTO     PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"01         HOST-NUM-APOLICE    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis HOST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         HOST-CODSUBES       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis HOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         TABELA-ULTIMOS-DIAS.*/
        public VA1139B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA1139B_TABELA_ULTIMOS_DIAS();
        public class VA1139B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VA1139B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VA1139B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VA1139B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VA1139B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VA1139B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA1139B_TAB_DIA_MESES>(12);
            public class VA1139B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VA1139B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VA1139B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VA1139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA1139B_AREA_DE_WORK();
        public class VA1139B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VA1139B_WS_DTBASE WS_DTBASE { get; set; } = new VA1139B_WS_DTBASE();
            public class VA1139B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VA1139B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VA1139B_WS_DTBASE_AM();
                public class VA1139B_WS_DTBASE_AM : VarBasis
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
            public VA1139B_WS_DTFATUR WS_DTFATUR { get; set; } = new VA1139B_WS_DTFATUR();
            public class VA1139B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VA1139B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VA1139B_WS_DTFATUR_AM();
                public class VA1139B_WS_DTFATUR_AM : VarBasis
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
            /*"  05         WFIM-V0PROPOSTAVA        PIC 9(001)  VALUE 0.*/
            public IntBasis WFIM_V0PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WS-NUM-APOLICE-ANT     PIC S9(13)    COMP-3.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-CODSUBES-ANT        PIC S9(04)    COMP.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
            /*"  05         WS-VLIOCC-TOT          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-VG       PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-AP       PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-DIT      PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PREMIO-LIQ          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-AP          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-VG          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-DIT         PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_VA1139B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA1139B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA1139B_FILLER_5(); _.Move(WWORK_NUM_ORDEM, _filler_5); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_5, WWORK_NUM_ORDEM); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUM_ORDEM); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VA1139B_FILLER_5 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VA1139B_FILLER_5()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VA1139B_WWORK_DATA WWORK_DATA { get; set; } = new VA1139B_WWORK_DATA();
            public class VA1139B_WWORK_DATA : VarBasis
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
            public VA1139B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VA1139B_WDATA_SISTEMA();
            public class VA1139B_WDATA_SISTEMA : VarBasis
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
            public VA1139B_WS_DATE WS_DATE { get; set; } = new VA1139B_WS_DATE();
            public class VA1139B_WS_DATE : VarBasis
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
                /*"  05         WDATA-CABEC.*/
            }
            public VA1139B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA1139B_WDATA_CABEC();
            public class VA1139B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         AC-PRMVG      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            }
            public DoubleBasis AC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMAP      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMDIT     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
            /*"  05         AC-L-V0HISTCONT         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTCONT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ENDOSSO          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0RCAPCOMP         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ORDECOSCED       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
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
            public VA1139B_WABEND WABEND { get; set; } = new VA1139B_WABEND();
            public class VA1139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA1139B '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA1139B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public VA1139B_CHISTCTBL CHISTCTBL { get; set; } = new VA1139B_CHISTCTBL();
        public VA1139B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VA1139B_V1RCAPCOMP();
        public VA1139B_CPROPVA CPROPVA { get; set; } = new VA1139B_CPROPVA();
        public VA1139B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new VA1139B_V1APOLCOSCED();
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
            /*" -529- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -532- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -535- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -539- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -546- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -551- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -552- MOVE V1SIST-DTMOVABE TO WWORK-DATA. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WWORK_DATA);

            /*" -553- MOVE 01 TO WWORK-DIA. */
            _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -555- MOVE WWORK-DATA TO V0ENDO-DTINIVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTINIVIG);

            /*" -556- MOVE TAB-DIA-MES(WWORK-MES) TO WWORK-DIA. */
            _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WWORK_DATA.WWORK_MES].TAB_DIA_MES, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -558- MOVE WWORK-DATA TO V0ENDO-DTTERVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTTERVIG);

            /*" -560- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -565- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -568- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -570- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -571- DISPLAY 'VA1139B - VERSAO 07  25-09-2019' . */
            _.Display($"VA1139B - VERSAO 07  25-09-2019");

            /*" -572- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

            /*" -573- DISPLAY 'INICIO VIGENCIA  : ' V0ENDO-DTINIVIG. */
            _.Display($"INICIO VIGENCIA  : {V0ENDO_DTINIVIG}");

            /*" -576- DISPLAY 'TERMINO VIGENCIA : ' V0ENDO-DTTERVIG. */
            _.Display($"TERMINO VIGENCIA : {V0ENDO_DTTERVIG}");

            /*" -608- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -612- DISPLAY 'VA1139B - ABRINDO CURSOR ...' . */
            _.Display($"VA1139B - ABRINDO CURSOR ...");

            /*" -613- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -613- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -618- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -620- DISPLAY 'PROCESSANDO . .......... ' . */
            _.Display($"PROCESSANDO . .......... ");

            /*" -622- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

            /*" -623- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
            {

                /*" -625- DISPLAY 'VA1139B - NENHUMA COBRANCA ENCONTRADA' */
                _.Display($"VA1139B - NENHUMA COBRANCA ENCONTRADA");

                /*" -627- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -630- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -632- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -633- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -633- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -638- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -639- MOVE 'VA1139B' TO V0RELA-CODUSU */
            _.Move("VA1139B", V0RELA_CODUSU);

            /*" -640- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -641- MOVE 'VA' TO V0RELA-IDSISTEM */
            _.Move("VA", V0RELA_IDSISTEM);

            /*" -642- MOVE 'VA1417B' TO V0RELA-CODRELAT */
            _.Move("VA1417B", V0RELA_CODRELAT);

            /*" -643- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -644- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -645- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -646- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -647- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -648- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -649- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -650- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -651- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -652- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -653- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -654- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -655- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -656- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -657- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -658- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -659- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -660- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -661- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -662- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -663- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -664- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -665- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -666- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -667- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -668- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -669- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -670- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -671- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -672- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -673- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -674- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -675- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -676- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -677- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -679- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -722- PERFORM R0000_00_PRINCIPAL_DB_INSERT_1 */

            R0000_00_PRINCIPAL_DB_INSERT_1();

            /*" -725- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -726- DISPLAY 'B0300-10 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B0300-10 (REGISTRO DUPLICADO) ... ");

                /*" -728- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -729- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -730- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -730- GO TO R9999-00-ROT-ERRO. */

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
            /*" -546- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

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
            /*" -737- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -738- DISPLAY ' ' . */
            _.Display($" ");

            /*" -740- DISPLAY '*--------  VA1139B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VA1139B - FIM NORMAL  --------*");

            /*" -740- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -608- EXEC SQL DECLARE CHISTCTBL CURSOR FOR SELECT A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.PRMVG, A.PRMAP, A.CODOPER, A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.OCOORHIST FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOSVG C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.NRCERTIF = A.NRCERTIF AND A.SITUACAO IN ( '0' , '3' ) AND A.DTMOVTO <= :V1SIST-DTMOVABE AND A.DTFATUR IS NULL AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.CODSUBES AND C.DIA_FATURA = 31 AND C.ESTR_COBR = 'MULT' AND C.ORIG_PRODU IN ( 'FENAM' , 'CAAES' , 'VIDAZUL' ) ORDER BY A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE END-EXEC. */
            CHISTCTBL = new VA1139B_CHISTCTBL(true);
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
							FROM SEGUROS.V0HISTCONTABILVA A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PRODUTOSVG C 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.NRCERTIF = A.NRCERTIF 
							AND A.SITUACAO IN ( '0'
							, '3' ) 
							AND A.DTMOVTO <= '{V1SIST_DTMOVABE}' 
							AND A.DTFATUR IS NULL 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.CODSUBES = B.CODSUBES 
							AND C.DIA_FATURA = 31 
							AND C.ESTR_COBR = 'MULT' 
							AND C.ORIG_PRODU IN ( 'FENAM'
							, 'CAAES'
							, 
							'VIDAZUL' ) 
							ORDER BY A.SITUACAO
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE";

                return query;
            }
            CHISTCTBL.GetQueryEvent += GetQuery_CHISTCTBL;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -613- EXEC SQL OPEN CHISTCTBL END-EXEC. */

            CHISTCTBL.Open();

        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -1727- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */
            V1RCAPCOMP = new VA1139B_V1RCAPCOMP(true);
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
							WHERE FONTE = '{V0RCAP_FONTE}' 
							AND NRRCAP = '{V0RCAP_NRRCAP}' 
							AND OPERACAO >= 100 
							AND OPERACAO <= 199 
							AND SITUACAO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-INSERT-1 */
        public void R0000_00_PRINCIPAL_DB_INSERT_1()
        {
            /*" -722- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r0000_00_PRINCIPAL_DB_INSERT_1_Insert1 = new R0000_00_PRINCIPAL_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DATA_SOLICITACAO = V0RELA_DATA_SOLICITACAO.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QUANTIDADE = V0RELA_QUANTIDADE.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFERENCIA = V0RELA_DATA_REFERENCIA.ToString(),
                V0RELA_MES_REFERENCIA = V0RELA_MES_REFERENCIA.ToString(),
                V0RELA_ANO_REFERENCIA = V0RELA_ANO_REFERENCIA.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALIDA = V0RELA_MODALIDA.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOLICE = V0RELA_NUM_APOLICE.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOLIDER = V0RELA_APOLIDER.ToString(),
                V0RELA_ENDOSLID = V0RELA_ENDOSLID.ToString(),
                V0RELA_NUM_PARC_LIDER = V0RELA_NUM_PARC_LIDER.ToString(),
                V0RELA_NUM_SINISTRO = V0RELA_NUM_SINISTRO.ToString(),
                V0RELA_NUM_SINI_LIDER = V0RELA_NUM_SINI_LIDER.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PREVIA_DEFINITIVA = V0RELA_PREVIA_DEFINITIVA.ToString(),
                V0RELA_ANAL_RESUMO = V0RELA_ANAL_RESUMO.ToString(),
                V0RELA_COD_EMPRESA = V0RELA_COD_EMPRESA.ToString(),
                V0RELA_PERI_RENOVACAO = V0RELA_PERI_RENOVACAO.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
            };

            R0000_00_PRINCIPAL_DB_INSERT_1_Insert1.Execute(r0000_00_PRINCIPAL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -565- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

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
            /*" -751- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -763- PERFORM R0910_00_FETCH_HCTBVA_DB_FETCH_1 */

            R0910_00_FETCH_HCTBVA_DB_FETCH_1();

            /*" -766- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -767- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -767- PERFORM R0910_00_FETCH_HCTBVA_DB_CLOSE_1 */

                    R0910_00_FETCH_HCTBVA_DB_CLOSE_1();

                    /*" -769- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -770- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -771- ELSE */
                }
                else
                {


                    /*" -773- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -775- ADD 1 TO AC-L-V0HISTCONT. */
            AREA_DE_WORK.AC_L_V0HISTCONT.Value = AREA_DE_WORK.AC_L_V0HISTCONT + 1;

            /*" -776- IF V0HCTB-FONTE EQUAL ZEROS */

            if (V0HCTB_FONTE == 00)
            {

                /*" -776- MOVE 5 TO V0HCTB-FONTE. */
                _.Move(5, V0HCTB_FONTE);
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_HCTBVA_DB_FETCH_1()
        {
            /*" -763- EXEC SQL FETCH CHISTCTBL INTO :V0HCTB-SITUACAO , :V0HCTB-NUM-APOLICE , :V0HCTB-CODSUBES , :V0HCTB-FONTE , :V0HCTB-PRMVG , :V0HCTB-PRMAP , :V0HCTB-CODOPER , :V0HCTB-NRCERTIF , :V0HCTB-NRPARCEL , :V0HCTB-NRTIT , :V0HCTB-OCORHIST END-EXEC. */

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
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_HCTBVA_DB_CLOSE_1()
        {
            /*" -767- EXEC SQL CLOSE CHISTCTBL END-EXEC */

            CHISTCTBL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -787- MOVE V0HCTB-NUM-APOLICE TO WS-NUM-APOLICE-ANT V0ENDO-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0ENDO_NUM_APOLICE);

            /*" -789- MOVE V0HCTB-CODSUBES TO WS-CODSUBES-ANT V0ENDO-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0ENDO_CODSUBES);

            /*" -792- MOVE V0HCTB-FONTE TO WS-FONTE-ANT V0ENDO-FONTE. */
            _.Move(V0HCTB_FONTE, AREA_DE_WORK.WS_FONTE_ANT, V0ENDO_FONTE);

            /*" -794- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -803- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -806- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -810- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -817- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -821- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -823- DISPLAY '*** VA1139B - SOLICITAR PRORROGACAO DA APOLICE ' V0HCTB-NUM-APOLICE ' ' V0ENDO-DTINIVIG */

                    $"*** VA1139B - SOLICITAR PRORROGACAO DA APOLICE {V0HCTB_NUM_APOLICE} {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -824- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -825- ELSE */
                }
                else
                {


                    /*" -827- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -829- MOVE '1003' TO WNR-EXEC-SQL. */
            _.Move("1003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -839- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -842- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -844- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -846- MOVE '1005' TO WNR-EXEC-SQL. */
            _.Move("1005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -853- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -858- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -860- ADD 1 TO V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS + 1;

            /*" -862- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -868- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -871- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -873- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -875- ADD 1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + 1;

            /*" -882- MOVE +0 TO AC-PRMVG AC-PRMAP WS-VLIOCC-TOT WS-VLIOCC-TOT-AP WS-VLIOCC-TOT-VG WS-VLIOCC-TOT-DIT */
            _.Move(+0, AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.WS_VLIOCC_TOT, AREA_DE_WORK.WS_VLIOCC_TOT_AP, AREA_DE_WORK.WS_VLIOCC_TOT_VG, AREA_DE_WORK.WS_VLIOCC_TOT_DIT);

            /*" -888- PERFORM R1100-00-ACUMULA-PREMIO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR V0HCTB-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR V0HCTB-FONTE NOT EQUAL WS-FONTE-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || V0HCTB_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || V0HCTB_FONTE != AREA_DE_WORK.WS_FONTE_ANT))
            {

                R1100_00_ACUMULA_PREMIO_SECTION();
            }

            /*" -890- IF V0APOL-RAMO EQUAL 93 AND AC-PRMVG NOT GREATER ZEROES */

            if (V0APOL_RAMO == 93 && AREA_DE_WORK.AC_PRMVG <= 00)
            {

                /*" -891- DISPLAY ' ' */
                _.Display($" ");

                /*" -892- DISPLAY 'PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ' */
                _.Display($"PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ");

                /*" -893- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -894- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -895- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -896- DISPLAY 'PREMIO VG ' AC-PRMVG */
                _.Display($"PREMIO VG {AREA_DE_WORK.AC_PRMVG}");

                /*" -897- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -898- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -900- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -902- IF V0APOL-RAMO EQUAL 81 AND AC-PRMAP NOT GREATER ZEROES */

            if (V0APOL_RAMO == 81 && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -903- DISPLAY ' ' */
                _.Display($" ");

                /*" -904- DISPLAY 'PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ' */
                _.Display($"PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ");

                /*" -905- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -906- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -907- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -908- DISPLAY 'PREMIO AP ' AC-PRMAP */
                _.Display($"PREMIO AP {AREA_DE_WORK.AC_PRMAP}");

                /*" -909- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -910- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -912- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -913- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -915- IF AC-PRMVG NOT GREATER ZEROES OR AC-PRMAP NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_PRMVG <= 00 || AREA_DE_WORK.AC_PRMAP <= 00)
                {

                    /*" -916- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -917- DISPLAY 'PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO' */
                    _.Display($"PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO");

                    /*" -918- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -919- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -920- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -921- DISPLAY 'PREMIO VG ' AC-PRMVG */
                    _.Display($"PREMIO VG {AREA_DE_WORK.AC_PRMVG}");

                    /*" -922- DISPLAY 'PREMIO AP ' AC-PRMAP */
                    _.Display($"PREMIO AP {AREA_DE_WORK.AC_PRMAP}");

                    /*" -923- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -924- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -926- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -933- MOVE +0 TO AC-IMPMORNATU AC-IMPMORACID AC-IMPINVPERM AC-IMPAMDS AC-IMPDH AC-IMPDIT. */
            _.Move(+0, AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDIT);

            /*" -935- PERFORM R1200-00-ACUMULA-IS. */

            R1200_00_ACUMULA_IS_SECTION();

            /*" -936- IF V0APOL-RAMO EQUAL 93 OR 97 */

            if (V0APOL_RAMO.In("93", "97"))
            {

                /*" -937- IF AC-IMPMORNATU NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORNATU <= 00)
                {

                    /*" -938- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -939- DISPLAY 'IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ' */
                    _.Display($"IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ");

                    /*" -940- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -941- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -942- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -943- DISPLAY 'IS MN     ' AC-IMPMORNATU */
                    _.Display($"IS MN     {AREA_DE_WORK.AC_IMPMORNATU}");

                    /*" -944- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -945- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -947- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -948- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -949- COMPUTE AC-IMPMORACID = AC-IMPMORACID - AC-IMPMORNATU */
                AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID - AREA_DE_WORK.AC_IMPMORNATU;

                /*" -951- COMPUTE AC-IMPMORACID = AC-IMPMORACID - (AC-IMPMORNATU * V0COND-IEA / 100) */
                AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID - (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IEA / 100f);

                /*" -952- IF V0COND-IPA GREATER ZEROES */

                if (V0COND_IPA > 00)
                {

                    /*" -954- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM - (AC-IMPMORNATU * V0COND-IPA / 100) */
                    AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM - (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IPA / 100f);

                    /*" -955- ELSE */
                }
                else
                {


                    /*" -956- IF V0COND-IPD GREATER ZEROES */

                    if (V0COND_IPD > 00)
                    {

                        /*" -958- COMPUTE AC-IMPINVPERM = (AC-IMPMORNATU * V0COND-IPD / 100) */
                        AREA_DE_WORK.AC_IMPINVPERM.Value = (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IPD / 100f);

                        /*" -959- END-IF */
                    }


                    /*" -960- END-IF */
                }


                /*" -962- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -963- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -964- DISPLAY 'IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ' */
                    _.Display($"IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ");

                    /*" -965- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -966- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -967- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -968- DISPLAY 'IS MA     ' AC-IMPMORACID */
                    _.Display($"IS MA     {AREA_DE_WORK.AC_IMPMORACID}");

                    /*" -969- DISPLAY 'IS IP     ' AC-IMPINVPERM */
                    _.Display($"IS IP     {AREA_DE_WORK.AC_IMPINVPERM}");

                    /*" -970- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -971- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -973- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -974- IF V0APOL-RAMO EQUAL 81 */

            if (V0APOL_RAMO == 81)
            {

                /*" -976- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -977- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -978- DISPLAY 'IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ' */
                    _.Display($"IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ");

                    /*" -979- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -980- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -981- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -982- DISPLAY 'IS MA     ' AC-IMPMORACID */
                    _.Display($"IS MA     {AREA_DE_WORK.AC_IMPMORACID}");

                    /*" -983- DISPLAY 'IS IP     ' AC-IMPINVPERM */
                    _.Display($"IS IP     {AREA_DE_WORK.AC_IMPINVPERM}");

                    /*" -984- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -985- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -987- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -989- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -994- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -997- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -999- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1002- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -1004- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1008- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2();

            /*" -1011- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1013- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1015- ADD 1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + 1;

            /*" -1016- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -1017- MOVE V1SIST-DTMOVABE TO V0ENDO-DATPRO. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DATPRO);

            /*" -1018- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -1020- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -1024- MOVE 0 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR V0ENDO-AGERCAP V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_BCORCAP, V0ENDO_BCOCOBR, V0ENDO_AGERCAP, V0ENDO_AGECOBR);

            /*" -1026- MOVE '0' TO V0ENDO-DACCOBR. */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -1028- MOVE 0 TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);

            /*" -1029- MOVE ' ' TO V0ENDO-DACRCAP. */
            _.Move(" ", V0ENDO_DACRCAP);

            /*" -1030- MOVE ' ' TO V0ENDO-IDRCAP. */
            _.Move(" ", V0ENDO_IDRCAP);

            /*" -1031- MOVE SPACES TO V0ENDO-DATARCAP */
            _.Move("", V0ENDO_DATARCAP);

            /*" -1033- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -1034- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -1035- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -1036- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -1037- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -1038- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -1039- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -1040- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -1041- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -1043- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -1046- MOVE 1 TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(1, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -1047- MOVE '1' TO V0ENDO-TIPO-ENDO. */
            _.Move("1", V0ENDO_TIPO_ENDO);

            /*" -1049- MOVE 'VA1139B' TO V0ENDO-COD-USUAR. */
            _.Move("VA1139B", V0ENDO_COD_USUAR);

            /*" -1051- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -1053- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -1054- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -1055- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -1056- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -1057- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -1059- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -1060- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -1061- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -1063- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -1064- DISPLAY 'APOLICE  ' V0ENDO-NUM-APOLICE. */
            _.Display($"APOLICE  {V0ENDO_NUM_APOLICE}");

            /*" -1065- DISPLAY 'ENDOSSO  ' V0ENDO-NRENDOS. */
            _.Display($"ENDOSSO  {V0ENDO_NRENDOS}");

            /*" -1066- DISPLAY 'COBSUBES ' V0ENDO-CODSUBES. */
            _.Display($"COBSUBES {V0ENDO_CODSUBES}");

            /*" -1067- DISPLAY 'FONTE    ' V0ENDO-FONTE. */
            _.Display($"FONTE    {V0ENDO_FONTE}");

            /*" -1069- DISPLAY 'NRPROPOS ' V0ENDO-NRPROPOS. */
            _.Display($"NRPROPOS {V0ENDO_NRPROPOS}");

            /*" -1070- DISPLAY 'AC-IMPMORNATU       ' AC-IMPMORNATU */
            _.Display($"AC-IMPMORNATU       {AREA_DE_WORK.AC_IMPMORNATU}");

            /*" -1071- DISPLAY 'AC-IMPMORACID       ' AC-IMPMORACID */
            _.Display($"AC-IMPMORACID       {AREA_DE_WORK.AC_IMPMORACID}");

            /*" -1072- DISPLAY 'AC-IMPINVPERM       ' AC-IMPINVPERM */
            _.Display($"AC-IMPINVPERM       {AREA_DE_WORK.AC_IMPINVPERM}");

            /*" -1073- DISPLAY 'AC-IMPAMDS          ' AC-IMPAMDS */
            _.Display($"AC-IMPAMDS          {AREA_DE_WORK.AC_IMPAMDS}");

            /*" -1074- DISPLAY 'AC-IMPDH            ' AC-IMPDH */
            _.Display($"AC-IMPDH            {AREA_DE_WORK.AC_IMPDH}");

            /*" -1076- DISPLAY 'AC-IMPDIT           ' AC-IMPDIT */
            _.Display($"AC-IMPDIT           {AREA_DE_WORK.AC_IMPDIT}");

            /*" -1079- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1169- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -1172- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1174- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1176- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -1178- PERFORM R1300-00-GRAVA-COSSEGURO. */

            R1300_00_GRAVA_COSSEGURO_SECTION();

            /*" -1179- MOVE V0ENDO-NUM-APOLICE TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0PARC_NUM_APOL);

            /*" -1180- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -1182- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -1183- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -1184- MOVE V0ENDO-FONTE TO V0PARC-FONTE */
            _.Move(V0ENDO_FONTE, V0PARC_FONTE);

            /*" -1185- MOVE 0 TO V0PARC-NRTIT */
            _.Move(0, V0PARC_NRTIT);

            /*" -1186- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -1187- COMPUTE V0PARC-OTNTOTAL = AC-PRMVG + AC-PRMAP */
            V0PARC_OTNTOTAL.Value = AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMAP;

            /*" -1188- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -1190- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -1193- COMPUTE V0PARC-OTNPRLIQ ROUNDED = V0PARC-OTNTOTAL - WS-VLIOCC-TOT */
            V0PARC_OTNPRLIQ.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -1195- MOVE V0PARC-OTNPRLIQ TO V0PARC-PRM-TAR-IX. */
            _.Move(V0PARC_OTNPRLIQ, V0PARC_PRM_TAR_IX);

            /*" -1197- MOVE WS-VLIOCC-TOT TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VLIOCC_TOT, V0PARC_OTNIOF);

            /*" -1198- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -1199- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -1200- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -1202- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -1205- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1226- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2();

            /*" -1229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1231- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1233- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -1235- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -1237- PERFORM R1500-00-GRAVA-OPERACAO-BAIXA. */

            R1500_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -1238- MOVE V0ENDO-NUM-APOLICE TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0COBA_NUM_APOL);

            /*" -1239- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -1240- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -1241- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -1242- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -1243- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -1245- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -1246- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -1247- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -1249- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -1250- IF V0APOL-RAMO = 81 OR 97 */

            if (V0APOL_RAMO.In("81", "97"))
            {

                /*" -1251- MOVE 81 TO V0COBA-RAMOFR */
                _.Move(81, V0COBA_RAMOFR);

                /*" -1252- MOVE 0 TO V0COBA-MODALIFR */
                _.Move(0, V0COBA_MODALIFR);

                /*" -1253- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1254- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX);

                /*" -1256- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMAP - WS-VLIOCC-TOT-AP */
                V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMAP - AREA_DE_WORK.WS_VLIOCC_TOT_AP;

                /*" -1257- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_VR);

                /*" -1258- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                /*" -1260- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                /*" -1262- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1263- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -1264- COMPUTE AC-PRMAP = AC-PRMAP - AC-PRMDIT */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP - AREA_DE_WORK.AC_PRMDIT;

                /*" -1266- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMAP - WS-VLIOCC-TOT-AP */
                V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMAP - AREA_DE_WORK.WS_VLIOCC_TOT_AP;

                /*" -1267- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                /*" -1269- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                /*" -1271- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1272- IF AC-IMPINVPERM GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPINVPERM > 00)
                {

                    /*" -1274- MOVE AC-IMPINVPERM TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPINVPERM, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1276- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1277- MOVE 2 TO V0COBA-COD-COBER */
                    _.Move(2, V0COBA_COD_COBER);

                    /*" -1278- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1279- END-IF */
                }


                /*" -1280- IF AC-IMPAMDS GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPAMDS > 00)
                {

                    /*" -1282- MOVE AC-IMPAMDS TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPAMDS, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1284- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1285- MOVE 3 TO V0COBA-COD-COBER */
                    _.Move(3, V0COBA_COD_COBER);

                    /*" -1286- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1287- END-IF */
                }


                /*" -1288- IF AC-IMPDH GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDH > 00)
                {

                    /*" -1290- MOVE AC-IMPDH TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDH, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1292- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1293- MOVE 4 TO V0COBA-COD-COBER */
                    _.Move(4, V0COBA_COD_COBER);

                    /*" -1294- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1295- END-IF */
                }


                /*" -1296- IF AC-IMPDIT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDIT > 00)
                {

                    /*" -1298- MOVE AC-IMPDIT TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDIT, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1300- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMDIT - WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMDIT - AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -1301- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1302- MOVE 5 TO V0COBA-COD-COBER */
                    _.Move(5, V0COBA_COD_COBER);

                    /*" -1304- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1306- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();
                }

            }


            /*" -1307- IF V0APOL-RAMO = 93 OR 97 */

            if (V0APOL_RAMO.In("93", "97"))
            {

                /*" -1308- MOVE 93 TO V0COBA-RAMOFR */
                _.Move(93, V0COBA_RAMOFR);

                /*" -1309- MOVE 0 TO V0COBA-MODALIFR */
                _.Move(0, V0COBA_MODALIFR);

                /*" -1310- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1312- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMVG - WS-VLIOCC-TOT-VG */
                V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                /*" -1313- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                /*" -1315- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                /*" -1317- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1318- MOVE 11 TO V0COBA-COD-COBER */
                _.Move(11, V0COBA_COD_COBER);

                /*" -1318- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                R1600_00_INSERT_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -803- EXEC SQL SELECT RAMO, CODPRODU ,ORGAO INTO :V0APOL-RAMO, :V0APOL-CODPRODU ,:V0APOL-ORGAO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -817- EXEC SQL SELECT CODSUBES INTO :WHOST-CODSUBES FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 AND DTTERVIG > :V0ENDO-DTINIVIG END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODSUBES, WHOST_CODSUBES);
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-SECTION */
        private void R1050_00_ESTORNA_CONTABIL_SECTION()
        {
            /*" -1332- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1343- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1();

            /*" -1347- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1349- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1351- MOVE '1051' TO WNR-EXEC-SQL. */
            _.Move("1051", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1362- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2();

            /*" -1366- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1368- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1370- SUBTRACT 1 FROM V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS - 1;

            /*" -1372- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1378- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3();

            /*" -1381- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1381- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-1 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1()
        {
            /*" -1343- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 WHERE SITUACAO = '0' AND NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTMOVTO <= :V1SIST-DTMOVABE AND CODOPER �= 1000 END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -868- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-2 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2()
        {
            /*" -1362- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 WHERE SITUACAO = '3' AND NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTMOVTO <= :V1SIST-DTMOVABE AND CODOPER �= 1000 END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -839- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD INTO :V0COND-IEA, :V0COND-IPA, :V0COND-IPD FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND COD_SUBGRUPO = :V0ENDO-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COND_IEA, V0COND_IEA);
                _.Move(executed_1.V0COND_IPA, V0COND_IPA);
                _.Move(executed_1.V0COND_IPD, V0COND_IPD);
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-3 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3()
        {
            /*" -1378- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -1169- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOLICE, :V0ENDO-NRENDOS, :V0ENDO-CODSUBES, :V0ENDO-FONTE, :V0ENDO-NRPROPOS, :V0ENDO-DATPRO, :V0ENDO-DT-LIBER, :V0ENDO-DTEMIS, :V0ENDO-NRRCAP, :V0ENDO-VLRCAP, :V0ENDO-BCORCAP, :V0ENDO-AGERCAP, :V0ENDO-DACRCAP, :V0ENDO-IDRCAP, :V0ENDO-BCOCOBR, :V0ENDO-AGECOBR, :V0ENDO-DACCOBR, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-CDFRACIO, :V0ENDO-PCENTRAD, :V0ENDO-PCADICIO, :V0ENDO-PRESTA1, :V0ENDO-QTPARCEL, :V0ENDO-QTPRESTA, :V0ENDO-QTITENS, :V0ENDO-CODTXT, :V0ENDO-CDACEITA, :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO, :V0ENDO-DATARCAP:VIND-DATARCAP, :V0ENDO-COD-EMPRESA, :V0ENDO-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:VIND-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI:VIND-VLCUSEMI, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1()
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

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2()
        {
            /*" -1008- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_2()
        {
            /*" -1226- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1()
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

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -853- EXEC SQL SELECT ENDOSCOB INTO :V0ENDO-NRENDOS FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
            }


        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-SECTION */
        private void R1100_00_ACUMULA_PREMIO_SECTION()
        {
            /*" -1392- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1400- PERFORM R1100_00_ACUMULA_PREMIO_DB_SELECT_1 */

            R1100_00_ACUMULA_PREMIO_DB_SELECT_1();

            /*" -1403- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1404- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1405- MOVE V0HCTB-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0HCTB_NRCERTIF, V0RCAP_NRTIT);

                    /*" -1406- PERFORM R1102-00-SELECT-RCAP */

                    R1102_00_SELECT_RCAP_SECTION();

                    /*" -1407- IF WTEM-V0RCAP EQUAL 'S' */

                    if (AREA_DE_WORK.WTEM_V0RCAP == "S")
                    {

                        /*" -1408- MOVE V1RCAC-DATARCAP TO WS-DTBASE */
                        _.Move(V1RCAC_DATARCAP, AREA_DE_WORK.WS_DTBASE);

                        /*" -1409- ELSE */
                    }
                    else
                    {


                        /*" -1410- GO TO R1100-00-NEXT */

                        R1100_00_NEXT(); //GOTO
                        return;

                        /*" -1411- ELSE */
                    }

                }
                else
                {


                    /*" -1412- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1413- ELSE */
                }

            }
            else
            {


                /*" -1414- IF V1SEGVG-DTRENOVA-IND LESS ZEROS */

                if (V1SEGVG_DTRENOVA_IND < 00)
                {

                    /*" -1415- MOVE V1SEGVG-DTINIVIG TO WS-DTBASE */
                    _.Move(V1SEGVG_DTINIVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -1416- ELSE */
                }
                else
                {


                    /*" -1417- MOVE V1SEGVG-DTRENOVA TO WS-DTRENOVA */
                    _.Move(V1SEGVG_DTRENOVA, WS_DTRENOVA);

                    /*" -1418- MOVE V0ENDO-DTINIVIG TO WS-DTFATUR */
                    _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WS_DTFATUR);

                    /*" -1420- PERFORM R1103-00-CALCULA-DTINIVIG. */

                    R1103_00_CALCULA_DTINIVIG_SECTION();
                }

            }


            /*" -1421- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -1424- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -1427- COMPUTE WS-PREMIO-LIQ ROUNDED = (V0HCTB-PRMVG + V0HCTB-PRMAP) / WS-IND-IOF */
            AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP) / AREA_DE_WORK.WS_IND_IOF;

            /*" -1431- COMPUTE WS-VLIOCC = V0HCTB-PRMVG + V0HCTB-PRMAP - WS-PREMIO-LIQ */
            AREA_DE_WORK.WS_VLIOCC.Value = V0HCTB_PRMVG + V0HCTB_PRMAP - AREA_DE_WORK.WS_PREMIO_LIQ;

            /*" -1433- COMPUTE WS-PRM-LIQ-AP ROUNDED = V0HCTB-PRMAP / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP / AREA_DE_WORK.WS_IND_IOF;

            /*" -1435- COMPUTE WS-VLIOCC-AP = V0HCTB-PRMAP - WS-PRM-LIQ-AP */
            AREA_DE_WORK.WS_VLIOCC_AP.Value = V0HCTB_PRMAP - AREA_DE_WORK.WS_PRM_LIQ_AP;

            /*" -1437- COMPUTE WS-PRM-LIQ-VG ROUNDED = V0HCTB-PRMVG / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG / AREA_DE_WORK.WS_IND_IOF;

            /*" -1440- COMPUTE WS-VLIOCC-VG = V0HCTB-PRMVG - WS-PRM-LIQ-VG */
            AREA_DE_WORK.WS_VLIOCC_VG.Value = V0HCTB_PRMVG - AREA_DE_WORK.WS_PRM_LIQ_VG;

            /*" -1441- IF V0HCTB-CODOPER = 1000 */

            if (V0HCTB_CODOPER == 1000)
            {

                /*" -1443- GO TO R1100-00-NEXT. */

                R1100_00_NEXT(); //GOTO
                return;
            }


            /*" -1445- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -1446- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT + WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT + AREA_DE_WORK.WS_VLIOCC;

                /*" -1447- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP + WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP + AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -1448- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG + WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -1449- COMPUTE AC-PRMVG = AC-PRMVG + V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG + V0HCTB_PRMVG;

                /*" -1450- COMPUTE AC-PRMAP = AC-PRMAP + V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP + V0HCTB_PRMAP;

                /*" -1451- ELSE */
            }
            else
            {


                /*" -1452- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT - WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT - AREA_DE_WORK.WS_VLIOCC;

                /*" -1453- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP - WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP - AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -1454- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -1455- COMPUTE AC-PRMVG = AC-PRMVG - V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - V0HCTB_PRMVG;

                /*" -1457- COMPUTE AC-PRMAP = AC-PRMAP - V0HCTB-PRMAP. */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP - V0HCTB_PRMAP;
            }


            /*" -1459- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1469- PERFORM R1100_00_ACUMULA_PREMIO_DB_UPDATE_1 */

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1();

            /*" -1472- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1474- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1476- ADD +1 TO AC-U-V0HISTCONTABILVA. */
            AREA_DE_WORK.AC_U_V0HISTCONTABILVA.Value = AREA_DE_WORK.AC_U_V0HISTCONTABILVA + +1;

            /*" -1478- IF V0HCTB-SITUACAO EQUAL '0' AND V0HCTB-NRPARCEL EQUAL 1 */

            if (V0HCTB_SITUACAO == "0" && V0HCTB_NRPARCEL == 1)
            {

                /*" -1478- PERFORM R1110-00-VERIFICA-RCAP. */

                R1110_00_VERIFICA_RCAP_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-SELECT-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_SELECT_1()
        {
            /*" -1400- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_ADMISSAO INTO :V1SEGVG-DTINIVIG, :V1SEGVG-DTRENOVA:V1SEGVG-DTRENOVA-IND FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :V0HCTB-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1 = new R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1.Execute(r1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGVG_DTINIVIG, V1SEGVG_DTINIVIG);
                _.Move(executed_1.V1SEGVG_DTRENOVA, V1SEGVG_DTRENOVA);
                _.Move(executed_1.V1SEGVG_DTRENOVA_IND, V1SEGVG_DTRENOVA_IND);
            }


        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-UPDATE-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_UPDATE_1()
        {
            /*" -1469- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' , NRENDOS = :V0ENDO-NRENDOS, DTFATUR = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST END-EXEC. */

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
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -994- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -1482- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-SECTION */
        private void R1102_00_SELECT_RCAP_SECTION()
        {
            /*" -1492- MOVE '1102' TO WNR-EXEC-SQL. */
            _.Move("1102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1494- MOVE 'S' TO WTEM-V0RCAP. */
            _.Move("S", AREA_DE_WORK.WTEM_V0RCAP);

            /*" -1501- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_1 */

            R1102_00_SELECT_RCAP_DB_SELECT_1();

            /*" -1504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1505- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1506- MOVE 'N' TO WTEM-V0RCAP */
                    _.Move("N", AREA_DE_WORK.WTEM_V0RCAP);

                    /*" -1508- GO TO R1102-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1510- MOVE '11A2' TO WNR-EXEC-SQL. */
            _.Move("11A2", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1525- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_2 */

            R1102_00_SELECT_RCAP_DB_SELECT_2();

            /*" -1528- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1528- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-1 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_1()
        {
            /*" -1501- EXEC SQL SELECT FONTE, NRRCAP INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r1102_00_SELECT_RCAP_DB_SELECT_1_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_1_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-2 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_2()
        {
            /*" -1525- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 END-EXEC. */

            var r1102_00_SELECT_RCAP_DB_SELECT_2_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_2_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R1103-00-CALCULA-DTINIVIG-SECTION */
        private void R1103_00_CALCULA_DTINIVIG_SECTION()
        {
            /*" -1536- MOVE WS-DTRENOVA TO WS-DTBASE */
            _.Move(WS_DTRENOVA, AREA_DE_WORK.WS_DTBASE);

            /*" -1538- MOVE 01 TO WS-DIA. */
            _.Move(01, AREA_DE_WORK.WS_DIA);

            /*" -1539- IF WS-DTFATUR GREATER WS-DTBASE */

            if (AREA_DE_WORK.WS_DTFATUR > AREA_DE_WORK.WS_DTBASE)
            {

                /*" -1539- GO TO R1103-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1103_10_DIMINUI_UM_ANO */

            R1103_10_DIMINUI_UM_ANO();

        }

        [StopWatch]
        /*" R1103-10-DIMINUI-UM-ANO */
        private void R1103_10_DIMINUI_UM_ANO(bool isPerform = false)
        {
            /*" -1544- COMPUTE WS-AABASE = WS-AABASE - 1 */
            AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE - 1;

            /*" -1546- COMPUTE WS-DDBASE = WS-DDBASE + WS-DIA */
            AREA_DE_WORK.WS_DTBASE.WS_DDBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DDBASE + AREA_DE_WORK.WS_DIA;

            /*" -1548- IF WS-MMBASE EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -1549- IF WS-DDBASE GREATER 31 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 31)
                {

                    /*" -1550- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1551- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1552- END-IF */
                }


                /*" -1554- END-IF */
            }


            /*" -1555- IF WS-MMBASE EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("04", "06", "09", "11"))
            {

                /*" -1556- IF WS-DDBASE GREATER 30 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 30)
                {

                    /*" -1557- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1558- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1559- END-IF */
                }


                /*" -1561- END-IF */
            }


            /*" -1562- IF WS-MMBASE EQUAL 02 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE == 02)
            {

                /*" -1563- IF WS-DDBASE GREATER 28 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 28)
                {

                    /*" -1564- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1565- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1566- END-IF */
                }


                /*" -1568- END-IF */
            }


            /*" -1569- IF WS-MMBASE GREATER 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE > 12)
            {

                /*" -1570- MOVE 01 TO WS-MMBASE */
                _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE);

                /*" -1571- COMPUTE WS-AABASE = WS-AABASE + 1 */
                AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE + 1;

                /*" -1573- END-IF */
            }


            /*" -1574- IF WS-DTFATUR-AM LESS WS-DTBASE-AM */

            if (AREA_DE_WORK.WS_DTFATUR.WS_DTFATUR_AM < AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM)
            {

                /*" -1575- IF WS-DTBASE NOT GREATER V1SEGVG-DTINIVIG */

                if (AREA_DE_WORK.WS_DTBASE <= V1SEGVG_DTINIVIG)
                {

                    /*" -1576- MOVE V1SEGVG-DTINIVIG TO WS-DTBASE */
                    _.Move(V1SEGVG_DTINIVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -1577- ELSE */
                }
                else
                {


                    /*" -1578- MOVE ZEROS TO WS-DIA */
                    _.Move(0, AREA_DE_WORK.WS_DIA);

                    /*" -1578- GO TO R1103-10-DIMINUI-UM-ANO. */
                    new Task(() => R1103_10_DIMINUI_UM_ANO()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_99_SAIDA*/

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-SECTION */
        private void R1105_00_ACESSA_V1RAMOIND_SECTION()
        {
            /*" -1590- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1591- MOVE V0APOL-RAMO TO V1RIND-RAMO */
            _.Move(V0APOL_RAMO, V1RIND_RAMO);

            /*" -1593- MOVE WS-DTBASE TO V1RIND-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DTBASE, V1RIND_DTINIVIG);

            /*" -1600- PERFORM R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1 */

            R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();

            /*" -1603- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1604- DISPLAY 'PROBLEMA NO ACESSAO V1RAMOIND' */
                _.Display($"PROBLEMA NO ACESSAO V1RAMOIND");

                /*" -1604- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-DB-SELECT-1 */
        public void R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1()
        {
            /*" -1600- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1RIND-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-SECTION */
        private void R1110_00_VERIFICA_RCAP_SECTION()
        {
            /*" -1615- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -1617- MOVE V0HCTB-NRCERTIF TO V0RCAP-NRTIT. */
            _.Move(V0HCTB_NRCERTIF, V0RCAP_NRTIT);

            /*" -1619- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1631- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_1 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_1();

            /*" -1634- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1635- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1636- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -1637- ELSE */
                }
                else
                {


                    /*" -1639- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1640- IF V0RCAP-SITUACAO EQUAL '1' */

            if (V0RCAP_SITUACAO == "1")
            {

                /*" -1641- MOVE '111A' TO WNR-EXEC-SQL. */
                _.Move("111A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);
            }


            /*" -1647- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_1 */

            R1110_00_VERIFICA_RCAP_DB_UPDATE_1();

            /*" -1649- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1651- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1653- MOVE '1113' TO WNR-EXEC-SQL. */
            _.Move("1113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1669- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_2 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_2();

            /*" -1672- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1674- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1676- PERFORM R1120-00-BAIXA-RCAP. */

            R1120_00_BAIXA_RCAP_SECTION();

            /*" -1678- MOVE '1115' TO WNR-EXEC-SQL. */
            _.Move("1115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1688- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_2 */

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2();

            /*" -1691- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1693- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1693- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-1 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -1631- EXEC SQL SELECT FONTE, NRRCAP, SITUACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V0RCAP-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO IN ( '0' , '1' ) END-EXEC. */

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
            /*" -1647- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRENDOS = :V0ENDO-NRENDOS, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-2 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -1669- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
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
            /*" -1688- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0ENDO-NUM-APOLICE, NRENDOS = :V0ENDO-NRENDOS, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1120-00-BAIXA-RCAP-SECTION */
        private void R1120_00_BAIXA_RCAP_SECTION()
        {
            /*" -1702- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1120_10_DECLARE_V0RCAPCOMP */

            R1120_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP */
        private void R1120_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1727- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -1729- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -1732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1732- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -1729- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-DB-DECLARE-1 */
        public void R1200_00_ACUMULA_IS_DB_DECLARE_1()
        {
            /*" -1858- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NRCERTIF, CODPRODU, IDADE, OPCAO_COBER FROM SEGUROS.V0PROPOSTAVA WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND SITUACAO = '3' END-EXEC. */
            CPROPVA = new VA1139B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NRCERTIF
							, 
							CODPRODU
							, 
							IDADE
							, 
							OPCAO_COBER 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE NUM_APOLICE = '{V0ENDO_NUM_APOLICE}' 
							AND CODSUBES = '{V0ENDO_CODSUBES}' 
							AND FONTE = '{V0ENDO_FONTE}' 
							AND SITUACAO = '3'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP */
        private void R1120_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1739- MOVE '1121' TO WNR-EXEC-SQL. */
            _.Move("1121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1754- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -1757- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1758- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1758- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -1760- GO TO R1120-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/ //GOTO
                    return;

                    /*" -1761- ELSE */
                }
                else
                {


                    /*" -1761- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -1754- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

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
            /*" -1758- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP */
        private void R1120_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1767- MOVE '1122' TO WNR-EXEC-SQL. */
            _.Move("1122", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1777- PERFORM R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -1780- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1782- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1782- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -1777- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP */
        private void R1120_40_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1788- MOVE '1123' TO WNR-EXEC-SQL. */
            _.Move("1123", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1789- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -1790- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -1792- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -1810- PERFORM R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -1813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1815- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1817- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -1810- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , CURRENT TIME, :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -1823- MOVE '1124' TO WNR-EXEC-SQL. */
            _.Move("1124", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1830- PERFORM R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -1834- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1838- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1838- GO TO R1120-20-FETCH-V0RCAPCOMP. */

            R1120_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -1830- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

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
            /*" -1858- PERFORM R1200_00_ACUMULA_IS_DB_DECLARE_1 */

            R1200_00_ACUMULA_IS_DB_DECLARE_1();

            /*" -1862- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1862- PERFORM R1200_00_ACUMULA_IS_DB_OPEN_1 */

            R1200_00_ACUMULA_IS_DB_OPEN_1();

            /*" -1864- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1866- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1867- MOVE 0 TO WFIM-V0PROPOSTAVA. */
            _.Move(0, AREA_DE_WORK.WFIM_V0PROPOSTAVA);

            /*" -1869- PERFORM R1290-00-FETCH. */

            R1290_00_FETCH_SECTION();

            /*" -1872- PERFORM R1210-00-ACUMULA-IS UNTIL WFIM-V0PROPOSTAVA = 1. */

            while (!(AREA_DE_WORK.WFIM_V0PROPOSTAVA == 1))
            {

                R1210_00_ACUMULA_IS_SECTION();
            }

            /*" -1874- MOVE '1205' TO WNR-EXEC-SQL. */
            _.Move("1205", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1874- PERFORM R1200_00_ACUMULA_IS_DB_CLOSE_1 */

            R1200_00_ACUMULA_IS_DB_CLOSE_1();

            /*" -1876- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1876- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-DB-OPEN-1 */
        public void R1200_00_ACUMULA_IS_DB_OPEN_1()
        {
            /*" -1862- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-DECLARE-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1()
        {
            /*" -2058- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT DISTINCT CODCOSS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND DTINIVIG <= :V0ENDO-DTEMIS AND DTTERVIG >= :V0ENDO-DTEMIS ORDER BY CODCOSS END-EXEC. */
            V1APOLCOSCED = new VA1139B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT DISTINCT CODCOSS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V0ENDO_NUM_APOLICE}' 
							AND DTINIVIG <= '{V0ENDO_DTEMIS}' 
							AND DTTERVIG >= '{V0ENDO_DTEMIS}' 
							ORDER BY CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-DB-CLOSE-1 */
        public void R1200_00_ACUMULA_IS_DB_CLOSE_1()
        {
            /*" -1874- EXEC SQL CLOSE CPROPVA END-EXEC. */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-SECTION */
        private void R1210_00_ACUMULA_IS_SECTION()
        {
            /*" -1887- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1904- PERFORM R1210_00_ACUMULA_IS_DB_SELECT_1 */

            R1210_00_ACUMULA_IS_DB_SELECT_1();

            /*" -1907- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1909- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1910- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1912- GO TO R1210-00-NEXT. */

                R1210_00_NEXT(); //GOTO
                return;
            }


            /*" -1913- COMPUTE AC-IMPMORNATU = AC-IMPMORNATU + V0CBPR-IMPMORNATU. */
            AREA_DE_WORK.AC_IMPMORNATU.Value = AREA_DE_WORK.AC_IMPMORNATU + V0CBPR_IMPMORNATU;

            /*" -1914- COMPUTE AC-IMPMORACID = AC-IMPMORACID + V0CBPR-IMPMORACID. */
            AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID + V0CBPR_IMPMORACID;

            /*" -1915- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM + V0CBPR-IMPINVPERM. */
            AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM + V0CBPR_IMPINVPERM;

            /*" -1916- COMPUTE AC-IMPAMDS = AC-IMPAMDS + V0CBPR-IMPAMDS. */
            AREA_DE_WORK.AC_IMPAMDS.Value = AREA_DE_WORK.AC_IMPAMDS + V0CBPR_IMPAMDS;

            /*" -1917- COMPUTE AC-IMPDH = AC-IMPDH + V0CBPR-IMPDH. */
            AREA_DE_WORK.AC_IMPDH.Value = AREA_DE_WORK.AC_IMPDH + V0CBPR_IMPDH;

            /*" -1919- COMPUTE AC-IMPDIT = AC-IMPDIT + V0CBPR-IMPDIT. */
            AREA_DE_WORK.AC_IMPDIT.Value = AREA_DE_WORK.AC_IMPDIT + V0CBPR_IMPDIT;

            /*" -1920- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

            if (V0CBPR_IMPDIT != 00)
            {

                /*" -1920- PERFORM R1220-00-LE-PREMIO-DIT. */

                R1220_00_LE_PREMIO_DIT_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1210_00_NEXT */

            R1210_00_NEXT();

        }

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-DB-SELECT-1 */
        public void R1210_00_ACUMULA_IS_DB_SELECT_1()
        {
            /*" -1904- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT INTO :V0CBPR-IMPMORNATU, :V0CBPR-IMPMORACID, :V0CBPR-IMPINVPERM, :V0CBPR-IMPAMDS, :V0CBPR-IMPDH, :V0CBPR-IMPDIT FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG END-EXEC. */

            var r1210_00_ACUMULA_IS_DB_SELECT_1_Query1 = new R1210_00_ACUMULA_IS_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
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
            }


        }

        [StopWatch]
        /*" R1210-00-NEXT */
        private void R1210_00_NEXT(bool isPerform = false)
        {
            /*" -1924- PERFORM R1290-00-FETCH. */

            R1290_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-SECTION */
        private void R1220_00_LE_PREMIO_DIT_SECTION()
        {
            /*" -1935- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1936- MOVE V0ENDO-NUM-APOLICE TO HOST-NUM-APOLICE. */
            _.Move(V0ENDO_NUM_APOLICE, HOST_NUM_APOLICE);

            /*" -1938- MOVE V0ENDO-CODSUBES TO HOST-CODSUBES. */
            _.Move(V0ENDO_CODSUBES, HOST_CODSUBES);

            /*" -1950- PERFORM R1220_00_LE_PREMIO_DIT_DB_SELECT_1 */

            R1220_00_LE_PREMIO_DIT_DB_SELECT_1();

            /*" -1953- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1954- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1955- MOVE '1221' TO WNR-EXEC-SQL */
                    _.Move("1221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1966- PERFORM R1220_00_LE_PREMIO_DIT_DB_SELECT_2 */

                    R1220_00_LE_PREMIO_DIT_DB_SELECT_2();

                    /*" -1968- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1969- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                        _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                        /*" -1970- DISPLAY 'V0HCTB-NUM-APOL ' HOST-NUM-APOLICE */
                        _.Display($"V0HCTB-NUM-APOL {HOST_NUM_APOLICE}");

                        /*" -1971- DISPLAY 'V0HCTB-CODSUBES ' HOST-CODSUBES */
                        _.Display($"V0HCTB-CODSUBES {HOST_CODSUBES}");

                        /*" -1972- DISPLAY 'V0PROP-IDADE    ' V0PROP-IDADE */
                        _.Display($"V0PROP-IDADE    {V0PROP_IDADE}");

                        /*" -1973- DISPLAY 'V0PROP-CODPRODU ' V0PROP-CODPRODU */
                        _.Display($"V0PROP-CODPRODU {V0PROP_CODPRODU}");

                        /*" -1974- DISPLAY 'V0ENDO-DTTERVIG ' V0ENDO-DTTERVIG */
                        _.Display($"V0ENDO-DTTERVIG {V0ENDO_DTTERVIG}");

                        /*" -1975- DISPLAY 'V0ENDO-IMPDIT   ' V0CBPR-IMPDIT */
                        _.Display($"V0ENDO-IMPDIT   {V0CBPR_IMPDIT}");

                        /*" -1976- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1978- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1979- ELSE */
                    }

                }
                else
                {


                    /*" -1981- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1983- MOVE '1222' TO WNR-EXEC-SQL. */
            _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1991- PERFORM R1220_00_LE_PREMIO_DIT_DB_SELECT_3 */

            R1220_00_LE_PREMIO_DIT_DB_SELECT_3();

            /*" -1994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1995- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1996- MOVE V0PROP-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0PROP_NRCERTIF, V0RCAP_NRTIT);

                    /*" -1997- PERFORM R1102-00-SELECT-RCAP */

                    R1102_00_SELECT_RCAP_SECTION();

                    /*" -1998- MOVE V1RCAC-DATARCAP TO WS-DTBASE */
                    _.Move(V1RCAC_DATARCAP, AREA_DE_WORK.WS_DTBASE);

                    /*" -1999- ELSE */
                }
                else
                {


                    /*" -2000- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2001- ELSE */
                }

            }
            else
            {


                /*" -2002- IF V1SEGVG-DTRENOVA-IND LESS ZEROS */

                if (V1SEGVG_DTRENOVA_IND < 00)
                {

                    /*" -2003- MOVE V1SEGVG-DTINIVIG TO WS-DTBASE */
                    _.Move(V1SEGVG_DTINIVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -2004- ELSE */
                }
                else
                {


                    /*" -2005- MOVE V1SEGVG-DTRENOVA TO WS-DTRENOVA */
                    _.Move(V1SEGVG_DTRENOVA, WS_DTRENOVA);

                    /*" -2006- MOVE V0ENDO-DTINIVIG TO WS-DTFATUR */
                    _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WS_DTFATUR);

                    /*" -2008- PERFORM R1103-00-CALCULA-DTINIVIG. */

                    R1103_00_CALCULA_DTINIVIG_SECTION();
                }

            }


            /*" -2010- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -2012- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -2014- COMPUTE WS-PRM-LIQ-DIT ROUNDED = V0PLAN-PRMDIT / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_DIT.Value = V0PLAN_PRMDIT / AREA_DE_WORK.WS_IND_IOF;

            /*" -2017- COMPUTE WS-VLIOCC-DIT = V0PLAN-PRMDIT - WS-PRM-LIQ-DIT */
            AREA_DE_WORK.WS_VLIOCC_DIT.Value = V0PLAN_PRMDIT - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -2018- ADD V0PLAN-PRMDIT TO AC-PRMDIT. */
            AREA_DE_WORK.AC_PRMDIT.Value = AREA_DE_WORK.AC_PRMDIT + V0PLAN_PRMDIT;

            /*" -2019- COMPUTE WS-VLIOCC-TOT-DIT = WS-VLIOCC-TOT-DIT + WS-VLIOCC-DIT. */
            AREA_DE_WORK.WS_VLIOCC_TOT_DIT.Value = AREA_DE_WORK.WS_VLIOCC_TOT_DIT + AREA_DE_WORK.WS_VLIOCC_DIT;

        }

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-DB-SELECT-1 */
        public void R1220_00_LE_PREMIO_DIT_DB_SELECT_1()
        {
            /*" -1950- EXEC SQL SELECT PRMAP INTO :V0PLAN-PRMDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :HOST-NUM-APOLICE AND CODSUBES = :HOST-CODSUBES AND IDADE_INICIAL <= :V0PROP-IDADE AND IDADE_FINAL >= :V0PROP-IDADE AND OPCAO_COBER = :V0PROP-OPCAO-COBER AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG AND IMPDIT = :V0CBPR-IMPDIT END-EXEC. */

            var r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 = new R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1()
            {
                V0PROP_OPCAO_COBER = V0PROP_OPCAO_COBER.ToString(),
                HOST_NUM_APOLICE = HOST_NUM_APOLICE.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                HOST_CODSUBES = HOST_CODSUBES.ToString(),
                V0CBPR_IMPDIT = V0CBPR_IMPDIT.ToString(),
                V0PROP_IDADE = V0PROP_IDADE.ToString(),
            };

            var executed_1 = R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1.Execute(r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PLAN_PRMDIT, V0PLAN_PRMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-DB-SELECT-2 */
        public void R1220_00_LE_PREMIO_DIT_DB_SELECT_2()
        {
            /*" -1966- EXEC SQL SELECT PRMAP INTO :V0PLAN-PRMDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :HOST-NUM-APOLICE AND CODSUBES = :HOST-CODSUBES AND IDADE_INICIAL <= :V0PROP-IDADE AND IDADE_FINAL >= :V0PROP-IDADE AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG AND IMPDIT = :V0CBPR-IMPDIT END-EXEC */

            var r1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1 = new R1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1()
            {
                HOST_NUM_APOLICE = HOST_NUM_APOLICE.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                HOST_CODSUBES = HOST_CODSUBES.ToString(),
                V0CBPR_IMPDIT = V0CBPR_IMPDIT.ToString(),
                V0PROP_IDADE = V0PROP_IDADE.ToString(),
            };

            var executed_1 = R1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1.Execute(r1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PLAN_PRMDIT, V0PLAN_PRMDIT);
            }


        }

        [StopWatch]
        /*" R1290-00-FETCH-SECTION */
        private void R1290_00_FETCH_SECTION()
        {
            /*" -2030- MOVE '1290' TO WNR-EXEC-SQL. */
            _.Move("1290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2036- PERFORM R1290_00_FETCH_DB_FETCH_1 */

            R1290_00_FETCH_DB_FETCH_1();

            /*" -2039- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2041- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2042- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2042- MOVE 1 TO WFIM-V0PROPOSTAVA. */
                _.Move(1, AREA_DE_WORK.WFIM_V0PROPOSTAVA);
            }


        }

        [StopWatch]
        /*" R1290-00-FETCH-DB-FETCH-1 */
        public void R1290_00_FETCH_DB_FETCH_1()
        {
            /*" -2036- EXEC SQL FETCH CPROPVA INTO :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-IDADE, :V0PROP-OPCAO-COBER END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVA.V0PROP_IDADE, V0PROP_IDADE);
                _.Move(CPROPVA.V0PROP_OPCAO_COBER, V0PROP_OPCAO_COBER);
            }

        }

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-DB-SELECT-3 */
        public void R1220_00_LE_PREMIO_DIT_DB_SELECT_3()
        {
            /*" -1991- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_ADMISSAO INTO :V1SEGVG-DTINIVIG, :V1SEGVG-DTRENOVA:V1SEGVG-DTRENOVA-IND FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1220_00_LE_PREMIO_DIT_DB_SELECT_3_Query1 = new R1220_00_LE_PREMIO_DIT_DB_SELECT_3_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1220_00_LE_PREMIO_DIT_DB_SELECT_3_Query1.Execute(r1220_00_LE_PREMIO_DIT_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGVG_DTINIVIG, V1SEGVG_DTINIVIG);
                _.Move(executed_1.V1SEGVG_DTRENOVA, V1SEGVG_DTRENOVA);
                _.Move(executed_1.V1SEGVG_DTRENOVA_IND, V1SEGVG_DTRENOVA_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1290_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-SECTION */
        private void R1300_00_GRAVA_COSSEGURO_SECTION()
        {
            /*" -2058- PERFORM R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1 */

            R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1();

            /*" -2061- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2061- PERFORM R1300_00_GRAVA_COSSEGURO_DB_OPEN_1 */

            R1300_00_GRAVA_COSSEGURO_DB_OPEN_1();

            /*" -2064- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2064- GO TO R9999-00-ROT-ERRO. */

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
            /*" -2061- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED */
        private void R1300_10_FETCH_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -2071- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2073- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -2076- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2077- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2077- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -2079- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2080- ELSE */
                }
                else
                {


                    /*" -2083- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2085- MOVE '1303' TO WNR-EXEC-SQL. */
            _.Move("1303", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2086- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -2087- MOVE V0ENDO-NUM-APOLICE TO V0ORDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0ORDC_NUM_APOL);

            /*" -2088- MOVE V0ENDO-NRENDOS TO V0ORDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0ORDC_NRENDOS);

            /*" -2091- MOVE V1COSP-CONGENER TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V1COSP_CONGENER, V0ORDC_CODCOSS);
            _.Move(V1COSP_CONGENER, AREA_DE_WORK.FILLER_5.WWORK_ORD_CONGE);


            /*" -2093- MOVE V0APOL-ORGAO TO WWORK-ORD-ORGAO. */
            _.Move(V0APOL_ORGAO, AREA_DE_WORK.FILLER_5.WWORK_ORD_ORGAO);

            /*" -2095- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -2097- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -2103- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1();

            /*" -2106- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2108- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2110- MOVE '2288' TO WNR-EXEC-SQL. */
            _.Move("2288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2112- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -2114- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_5.WWORK_ORD_SEQUE);

            /*" -2116- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -2124- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1();

            /*" -2127- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2129- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2131- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -2133- MOVE '1304' TO WNR-EXEC-SQL. */
            _.Move("1304", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2135- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -2137- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -2143- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1();

            /*" -2146- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2148- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2150- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

            /*" -2150- GO TO R1300-10-FETCH-V1APOLCOSCED. */
            new Task(() => R1300_10_FETCH_V1APOLCOSCED()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -2073- EXEC SQL FETCH V1APOLCOSCED INTO :V1COSP-CONGENER END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1COSP_CONGENER, V1COSP_CONGENER);
            }

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -2077- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-SELECT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -2103- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -2124- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2143- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -2161- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2162- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -2164- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -2165- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -2166- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -2167- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -2169- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -2171- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -2172- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -2173- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -2174- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -2175- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -2176- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -2177- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -2179- COMPUTE V0HISP-VLIOCC = V0HISP-VLPRMTOT - V0HISP-VLPRMLIQ */
            V0HISP_VLIOCC.Value = V0HISP_VLPRMTOT - V0HISP_VLPRMLIQ;

            /*" -2180- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -2181- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -2182- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -2183- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -2184- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2185- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -2186- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2187- MOVE 'VA1139B' TO V0HISP-COD-USUAR */
            _.Move("VA1139B", V0HISP_COD_USUAR);

            /*" -2189- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2191- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -2193- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -2193- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R1500_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -2203- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -2204- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -2206- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -2207- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -2208- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -2210- MOVE 0221 TO V0HISP-OPERACAO */
            _.Move(0221, V0HISP_OPERACAO);

            /*" -2212- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -2213- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -2214- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -2215- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -2216- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -2217- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -2218- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -2220- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -2221- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -2222- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -2223- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -2224- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -2225- MOVE 0 TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2226- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -2227- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2228- MOVE 'VA1139B' TO V0HISP-COD-USUAR */
            _.Move("VA1139B", V0HISP_COD_USUAR);

            /*" -2230- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2231- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -2233- MOVE V1SIST-DTMOVACB TO V0HISP-DTQITBCO. */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTQITBCO);

            /*" -2235- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -2235- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-SECTION */
        private void R1450_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -2246- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2275- PERFORM R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -2278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2280- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2280- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -2275- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R1600-00-INSERT-V0COBERAPOL-SECTION */
        private void R1600_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -2292- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2312- PERFORM R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -2315- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2317- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2317- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -2312- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

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
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -2329- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -2330- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2331- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2333- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2334- DISPLAY 'LIDOS  V0HISTCONTABILVA  ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS  V0HISTCONTABILVA  {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -2335- DISPLAY 'INSERT V0ENDOSSO         ' AC-I-V0ENDOSSO. */
            _.Display($"INSERT V0ENDOSSO         {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -2336- DISPLAY 'INSERT V0RCAPCOMP        ' AC-I-V0RCAPCOMP. */
            _.Display($"INSERT V0RCAPCOMP        {AREA_DE_WORK.AC_I_V0RCAPCOMP}");

            /*" -2337- DISPLAY 'INSERT V0ORDECOSCED      ' AC-I-V0ORDECOSCED. */
            _.Display($"INSERT V0ORDECOSCED      {AREA_DE_WORK.AC_I_V0ORDECOSCED}");

            /*" -2338- DISPLAY 'INSERT V0PARCELA         ' AC-I-V0PARCELA. */
            _.Display($"INSERT V0PARCELA         {AREA_DE_WORK.AC_I_V0PARCELA}");

            /*" -2339- DISPLAY 'INSERT V0HISTOPARC       ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC       {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -2341- DISPLAY 'INSERT V0COBERAPOL       ' AC-I-V0COBERAPOL. */
            _.Display($"INSERT V0COBERAPOL       {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -2342- DISPLAY 'UPDATE V0RCAP            ' AC-U-V0RCAP. */
            _.Display($"UPDATE V0RCAP            {AREA_DE_WORK.AC_U_V0RCAP}");

            /*" -2343- DISPLAY 'UPDATE V0RCAPCOMP        ' AC-U-V0RCAPCOMP. */
            _.Display($"UPDATE V0RCAPCOMP        {AREA_DE_WORK.AC_U_V0RCAPCOMP}");

            /*" -2344- DISPLAY 'UPDATE V0NUMEROAES       ' AC-U-V0NUMERAES. */
            _.Display($"UPDATE V0NUMEROAES       {AREA_DE_WORK.AC_U_V0NUMERAES}");

            /*" -2345- DISPLAY 'UPDATE V0FONTE           ' AC-U-V0FONTE. */
            _.Display($"UPDATE V0FONTE           {AREA_DE_WORK.AC_U_V0FONTE}");

            /*" -2346- DISPLAY 'UPDATE V0HISTCONTABILVA  ' AC-U-V0HISTCONTABILVA. */
            _.Display($"UPDATE V0HISTCONTABILVA  {AREA_DE_WORK.AC_U_V0HISTCONTABILVA}");

            /*" -2346- DISPLAY 'UPDATE V0NUMERO-COSSEGURO' AC-U-V0NUMERO-COSSEGURO. */
            _.Display($"UPDATE V0NUMERO-COSSEGURO{AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2359- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2360- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2361- DISPLAY 'CERTIFICADO ' V0HCTB-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTB_NRCERTIF}");

            /*" -2362- DISPLAY 'LIDOS       ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -2363- DISPLAY 'VALOR       ' V0CBPR-IMPDIT. */
            _.Display($"VALOR       {V0CBPR_IMPDIT}");

            /*" -2364- DISPLAY V0PROP-CODPRODU */
            _.Display(V0PROP_CODPRODU);

            /*" -2365- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -2366- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -2368- DISPLAY V0CBPR-IMPDIT */
            _.Display(V0CBPR_IMPDIT);

            /*" -2368- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2370- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2374- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2374- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}