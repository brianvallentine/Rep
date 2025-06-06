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
using Sias.VidaEmGrupo.DB2.VG0138B;

namespace Code
{
    public class VG0138B
    {
        public bool IsCall { get; set; }

        public VG0138B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL EMPRESARIAL/PESSOA JURIDICA*      */
        /*"      *   PROGRAMA ...............  VG0138B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MANOEL MESSIAS                     *      */
        /*"      *   PROGRAMADOR ............  MANOEL MESSIAS                     *      */
        /*"      *   DATA CODIFICACAO .......  30/07/2002                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO HISTORICO DE CONTABILI-*      */
        /*"      *                             ZACAO DE PARCELAS(V0HISTCONTABILVA)*      */
        /*"      *                             GERA O ENDOSSO DE RESTITUICAO PARA *      */
        /*"      *                             O SEGURADO QUE POSSUI ESTA OCORREN-*      */
        /*"      *                             CIA NO FATURAMENTO DO MES.         *      */
        /*"      *          ================>  SOMENTE PARA AS APOLICES ESPECIFICA*      */
        /*"      *                             E VIDAZUL EMPRESARIAL.             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                     A L T E R A C O E S                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - HISTORIA 197.465                                 *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTES INSERT APOLICE_COBERTURAS.               *      */
        /*"      *               PASSAR A MOVER COD_MODALIDADE DA APOLICES.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/04/2019 - BRICE HO (ALTRAN)                            *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - DEMANDA 196.405                                  *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERAR A DATA DE INICIO E TERMINO DE VIGENCIA   *      */
        /*"      *               DO ENDOSSO DE RESTITUICAO PARA A MESMA DATA DO   *      */
        /*"      *               ENDOSSO DE BAIXA DA PARCELA.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/04/2019 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 95.972                                       *      */
        /*"      *                                                                *      */
        /*"      *            - ATENDIMENTO DA CIRC-SUSEP 360:                    *      */
        /*"      *              DATA DA PROPOSTA NAO PODE SER MAIOR QUE A DATA    *      */
        /*"      *              DE INICIO DE VIGENCIA NA TABELA DE ENDOSSOS       *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *             - CAD 69.225                                       *      */
        /*"      *               CORRECAO DO ABEND SQLCODE = 100                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - MANOEL MESSIAS 20/05/2004                               *      */
        /*"      *    ESTAVA GRAVANDO A ENDOSSO COM O TIPO DE ENDOSSO IGUAL A '1' *      */
        /*"      *  E PASSOU A SER GRAVADO COM '3'.                               *      */
        /*"      *                                         PROCURE POR MM0504     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  06/08/08   WELLINGTON VERAS (POLITEC)              *      */
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
        /*"01         WHOST-DTTERVIG       PIC  X(10).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         V0COBP-DTINIVIG-ENDO PIC  X(10).*/
        public StringBasis V0COBP_DTINIVIG_ENDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"01         V0PARC-DTVENCTO     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-MODALIDA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        public VG0138B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG0138B_TABELA_ULTIMOS_DIAS();
        public class VG0138B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG0138B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG0138B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG0138B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG0138B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VG0138B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG0138B_TAB_DIA_MESES>(12);
            public class VG0138B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VG0138B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0138B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VG0138B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0138B_AREA_DE_WORK();
        public class VG0138B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VG0138B_WS_DTBASE WS_DTBASE { get; set; } = new VG0138B_WS_DTBASE();
            public class VG0138B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VG0138B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VG0138B_WS_DTBASE_AM();
                public class VG0138B_WS_DTBASE_AM : VarBasis
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
            public VG0138B_WS_DTFATUR WS_DTFATUR { get; set; } = new VG0138B_WS_DTFATUR();
            public class VG0138B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VG0138B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VG0138B_WS_DTFATUR_AM();
                public class VG0138B_WS_DTFATUR_AM : VarBasis
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
            private _REDEF_VG0138B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG0138B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG0138B_FILLER_5(); _.Move(WWORK_NUM_ORDEM, _filler_5); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_5, WWORK_NUM_ORDEM); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUM_ORDEM); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VG0138B_FILLER_5 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VG0138B_FILLER_5()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VG0138B_WWORK_DATA WWORK_DATA { get; set; } = new VG0138B_WWORK_DATA();
            public class VG0138B_WWORK_DATA : VarBasis
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
            public VG0138B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VG0138B_WDATA_SISTEMA();
            public class VG0138B_WDATA_SISTEMA : VarBasis
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
            public VG0138B_WS_DATE WS_DATE { get; set; } = new VG0138B_WS_DATE();
            public class VG0138B_WS_DATE : VarBasis
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
            public VG0138B_WS_DATA_INIVIGENCIA WS_DATA_INIVIGENCIA { get; set; } = new VG0138B_WS_DATA_INIVIGENCIA();
            public class VG0138B_WS_DATA_INIVIGENCIA : VarBasis
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
            public VG0138B_WS_DATA_QUITACAO WS_DATA_QUITACAO { get; set; } = new VG0138B_WS_DATA_QUITACAO();
            public class VG0138B_WS_DATA_QUITACAO : VarBasis
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
            public VG0138B_WDATA_CABEC WDATA_CABEC { get; set; } = new VG0138B_WDATA_CABEC();
            public class VG0138B_WDATA_CABEC : VarBasis
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
            public VG0138B_WABEND WABEND { get; set; } = new VG0138B_WABEND();
            public class VG0138B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG0138B '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0138B ");
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
        public VG0138B_WS_HORAS WS_HORAS { get; set; } = new VG0138B_WS_HORAS();
        public class VG0138B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG0138B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG0138B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG0138B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG0138B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VG0138B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG0138B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG0138B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG0138B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG0138B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_VG0138B_WS_HORA_FIM_R()
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
        public VG0138B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG0138B_TOTAIS_ROT();
        public class VG0138B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG0138B_FILLER_21> FILLER_21 { get; set; } = new ListBasis<VG0138B_FILLER_21>(50);
            public class VG0138B_FILLER_21 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public VG0138B_CHISTCTBL CHISTCTBL { get; set; } = new VG0138B_CHISTCTBL();
        public VG0138B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new VG0138B_V1APOLCOSCED();
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
            /*" -627- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -630- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -633- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -636- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -637- DISPLAY ' PROGRAMA EM EXECUCAO <VG0138B>                    ' */
            _.Display($" PROGRAMA EM EXECUCAO <VG0138B>                    ");

            /*" -638- DISPLAY '                                                   ' */
            _.Display($"                                                   ");

            /*" -640- DISPLAY ' VERSAO  <V.05>  DEM <196.405>  DATA <03/04/2019>  ' */
            _.Display($" VERSAO  <V.05>  DEM <196.405>  DATA <03/04/2019>  ");

            /*" -641- DISPLAY '                                                   ' */
            _.Display($"                                                   ");

            /*" -643- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -645- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -647- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -648- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -649- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -656- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -659- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -660- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -662- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -664- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -665- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -666- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -671- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -674- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -675- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -679- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

            /*" -680- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -681- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -724- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -729- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -730- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -730- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -733- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -734- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -740- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

            /*" -741- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
            {

                /*" -743- DISPLAY 'VG0138B - NENHUMA COBRANCA ENCONTRADA' */
                _.Display($"VG0138B - NENHUMA COBRANCA ENCONTRADA");

                /*" -745- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -748- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -750- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -752- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -753- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -753- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -756- GO TO R9999-00-ROT-ERRO. */

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
            /*" -656- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

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
            /*" -762- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -763- DISPLAY ' ' . */
            _.Display($" ");

            /*" -765- DISPLAY '*--------  VG0138B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VG0138B - FIM NORMAL  --------*");

            /*" -765- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -724- EXEC SQL DECLARE CHISTCTBL CURSOR FOR SELECT A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.PRMVG, A.PRMAP, A.CODOPER, A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.OCOORHIST, B.DTQITBCO, B.CODCLIEN, C.ESTR_COBR, C.ORIG_PRODU, B.OCORHIST FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOSVG C, SEGUROS.V0SUBGRUPO D WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.NRCERTIF = A.NRCERTIF AND B.CODCLIEN = D.COD_CLIENTE AND B.NUM_APOLICE = D.NUM_APOLICE AND B.CODSUBES = D.COD_SUBGRUPO AND A.SITUACAO IN ( '0' , '3' ) AND A.DTMOVTO <= :V1SIST-DTMOVABE AND A.DTFATUR IS NULL AND A.CODOPER >= 500 AND A.CODOPER <= 599 AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.CODSUBES AND C.DIA_FATURA = 31 AND C.ESTR_COBR = 'MULT' ORDER BY A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.NRPARCEL, A.FONTE END-EXEC. */
            CHISTCTBL = new VG0138B_CHISTCTBL(true);
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
							AND A.CODOPER >= 500 
							AND A.CODOPER <= 599 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.CODSUBES = B.CODSUBES 
							AND C.DIA_FATURA = 31 
							AND C.ESTR_COBR = 'MULT' 
							ORDER BY A.SITUACAO
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.NRPARCEL
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
            /*" -730- EXEC SQL OPEN CHISTCTBL END-EXEC. */

            CHISTCTBL.Open();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-DECLARE-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1()
        {
            /*" -1879- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT DISTINCT CODCOSS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG ORDER BY CODCOSS END-EXEC. */
            V1APOLCOSCED = new VG0138B_V1APOLCOSCED(true);
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
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -671- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

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
            /*" -776- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -793- PERFORM R0910_00_FETCH_HCTBVA_DB_FETCH_1 */

            R0910_00_FETCH_HCTBVA_DB_FETCH_1();

            /*" -796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -797- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -797- PERFORM R0910_00_FETCH_HCTBVA_DB_CLOSE_1 */

                    R0910_00_FETCH_HCTBVA_DB_CLOSE_1();

                    /*" -799- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -800- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -801- ELSE */
                }
                else
                {


                    /*" -803- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -805- ADD 1 TO AC-L-V0HISTCONT. */
            AREA_DE_WORK.AC_L_V0HISTCONT.Value = AREA_DE_WORK.AC_L_V0HISTCONT + 1;

            /*" -806- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' */

            if (V0PRVG_ORIG_PRODU == "EMPRE")
            {

                /*" -807- IF V0HCTB-CODSUBES EQUAL ZEROS */

                if (V0HCTB_CODSUBES == 00)
                {

                    /*" -809- GO TO R0910-00-FETCH-HCTBVA. */
                    new Task(() => R0910_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -810- IF V0HCTB-FONTE EQUAL ZEROS */

            if (V0HCTB_FONTE == 00)
            {

                /*" -812- MOVE 5 TO V0HCTB-FONTE. */
                _.Move(5, V0HCTB_FONTE);
            }


            /*" -814- MOVE '091Z' TO WNR-EXEC-SQL. */
            _.Move("091Z", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -815- MOVE 42 TO SII. */
            _.Move(42, WS_HORAS.SII);

            /*" -816- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -823- PERFORM R0910_00_FETCH_HCTBVA_DB_SELECT_1 */

            R0910_00_FETCH_HCTBVA_DB_SELECT_1();

            /*" -826- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -827- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -828- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -829- GO TO R0910-00-FETCH-HCTBVA */
                    new Task(() => R0910_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -830- ELSE */
                }
                else
                {


                    /*" -830- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_HCTBVA_DB_FETCH_1()
        {
            /*" -793- EXEC SQL FETCH CHISTCTBL INTO :V0HCTB-SITUACAO , :V0HCTB-NUM-APOLICE , :V0HCTB-CODSUBES , :V0HCTB-FONTE , :V0HCTB-PRMVG , :V0HCTB-PRMAP , :V0HCTB-CODOPER , :V0HCTB-NRCERTIF , :V0HCTB-NRPARCEL , :V0HCTB-NRTIT , :V0HCTB-OCORHIST , :V0PROP-DTQITBCO , :V0PROP-CODCLIEN , :V0PRVG-ESTR-COBR , :V0PRVG-ORIG-PRODU , :V0PROP-OCORHIST END-EXEC. */

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
            /*" -797- EXEC SQL CLOSE CHISTCTBL END-EXEC */

            CHISTCTBL.Close();

        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-SELECT-1 */
        public void R0910_00_FETCH_HCTBVA_DB_SELECT_1()
        {
            /*" -823- EXEC SQL SELECT NUM_APOLICE INTO :V0SUBG-NUM-APOLICE FROM SEGUROS.V0SUBGRUPO WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND NUM_APOLICE = :V0HCTB-NUM-APOLICE AND COD_SUBGRUPO = :V0HCTB-CODSUBES END-EXEC. */

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
            /*" -841- MOVE V0HCTB-NUM-APOLICE TO WS-NUM-APOLICE-ANT V0ENDO-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0ENDO_NUM_APOLICE);

            /*" -843- MOVE V0HCTB-CODSUBES TO WS-CODSUBES-ANT V0ENDO-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0ENDO_CODSUBES);

            /*" -845- MOVE V0HCTB-FONTE TO WS-FONTE-ANT V0ENDO-FONTE. */
            _.Move(V0HCTB_FONTE, AREA_DE_WORK.WS_FONTE_ANT, V0ENDO_FONTE);

            /*" -847- MOVE V0HCTB-NRPARCEL TO WS-NRPARCEL-ANT WHOST-NRPARCEL. */
            _.Move(V0HCTB_NRPARCEL, AREA_DE_WORK.WS_NRPARCEL_ANT, WHOST_NRPARCEL);

            /*" -850- MOVE V0HCTB-NRCERTIF TO WS-NRCERTIF-ANT WHOST-NRCERTIF. */
            _.Move(V0HCTB_NRCERTIF, AREA_DE_WORK.WS_NRCERTIF_ANT, WHOST_NRCERTIF);

            /*" -852- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -853- MOVE 05 TO SII. */
            _.Move(05, WS_HORAS.SII);

            /*" -854- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -863- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -866- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -867- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -869- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -871- MOVE '10A1' TO WNR-EXEC-SQL. */
            _.Move("10A1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -872- MOVE 06 TO SII. */
            _.Move(06, WS_HORAS.SII);

            /*" -873- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -879- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -882- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -883- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -885- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -887- MOVE '10B1' TO WNR-EXEC-SQL. */
            _.Move("10B1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -888- MOVE 17 TO SII. */
            _.Move(17, WS_HORAS.SII);

            /*" -889- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -895- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -898- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -901- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -903- MOVE '10B2' TO WNR-EXEC-SQL. */
            _.Move("10B2", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -904- MOVE 44 TO SII. */
            _.Move(44, WS_HORAS.SII);

            /*" -905- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -930- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -933- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -934- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -935- DISPLAY 'VG0138B - ERRO ACESSO ENDOSSO BAIXA ' */
                _.Display($"VG0138B - ERRO ACESSO ENDOSSO BAIXA ");

                /*" -936- DISPLAY ' CERTIFICADO - ' V0HCTB-NRCERTIF */
                _.Display($" CERTIFICADO - {V0HCTB_NRCERTIF}");

                /*" -949- DISPLAY ' PARCELA     - ' V0HCTB-NRPARCEL */
                _.Display($" PARCELA     - {V0HCTB_NRPARCEL}");

                /*" -950- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -999- END-IF */
            }


            /*" -1001- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1002- MOVE 07 TO SII. */
            _.Move(07, WS_HORAS.SII);

            /*" -1003- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1012- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -1015- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1017- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1019- DISPLAY '*** VG0138B - SOLICITAR PRORROGACAO DA APOLICE ' V0HCTB-NUM-APOLICE ' ' V0ENDO-DTINIVIG */

                    $"*** VG0138B - SOLICITAR PRORROGACAO DA APOLICE {V0HCTB_NUM_APOLICE} {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -1022- PERFORM R0910-00-FETCH-HCTBVA UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

                    while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT))
                    {

                        R0910_00_FETCH_HCTBVA_SECTION();
                    }

                    /*" -1023- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

                    if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
                    {

                        /*" -1024- GO TO R1000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;

                        /*" -1025- ELSE */
                    }
                    else
                    {


                        /*" -1026- GO TO R1000-00-PROCESSA-REGISTRO */
                        new Task(() => R1000_00_PROCESSA_REGISTRO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1027- END-IF */
                    }


                    /*" -1028- ELSE */
                }
                else
                {


                    /*" -1029- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1030- END-IF */
                }


                /*" -1032- END-IF */
            }


            /*" -1034- MOVE '1005' TO WNR-EXEC-SQL. */
            _.Move("1005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1035- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -1036- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1042- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -1045- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1048- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1050- ADD 1 TO V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS + 1;

            /*" -1052- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1053- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -1054- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1059- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -1062- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1063- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1065- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1067- ADD 1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + 1;

            /*" -1076- MOVE +0 TO AC-PRMVG AC-PRMAP AC-PRMRTO WS-VLIOCC-TOT WS-VLIOCC-TOT-AP WS-VLIOCC-TOT-VG WS-VLIOCC-TOT-DIT WS-VLIOCC-TOT-RTO. */
            _.Move(+0, AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.AC_PRMRTO, AREA_DE_WORK.WS_VLIOCC_TOT, AREA_DE_WORK.WS_VLIOCC_TOT_AP, AREA_DE_WORK.WS_VLIOCC_TOT_VG, AREA_DE_WORK.WS_VLIOCC_TOT_DIT, AREA_DE_WORK.WS_VLIOCC_TOT_RTO);

            /*" -1083- PERFORM R1100-00-ACUMULA-PREMIO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR V0HCTB-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR V0HCTB-NRPARCEL NOT EQUAL WS-NRPARCEL-ANT OR V0HCTB-FONTE NOT EQUAL WS-FONTE-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || V0HCTB_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || V0HCTB_NRPARCEL != AREA_DE_WORK.WS_NRPARCEL_ANT || V0HCTB_FONTE != AREA_DE_WORK.WS_FONTE_ANT))
            {

                R1100_00_ACUMULA_PREMIO_SECTION();
            }

            /*" -1093- IF (V0APOL-RAMO EQUAL 93 OR 77) AND AC-PRMVG NOT GREATER ZEROES */

            if ((V0APOL_RAMO.In("93", "77")) && AREA_DE_WORK.AC_PRMVG <= 00)
            {

                /*" -1094- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -1096- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1106- IF (V0APOL-RAMO EQUAL 81 OR 82) AND AC-PRMAP NOT GREATER ZEROES */

            if ((V0APOL_RAMO.In("81", "82")) && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -1107- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -1109- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1110- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -1112- IF AC-PRMVG NOT GREATER ZEROES OR AC-PRMAP NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_PRMVG <= 00 || AREA_DE_WORK.AC_PRMAP <= 00)
                {

                    /*" -1114- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -1124- ELSE */
                    }
                    else
                    {


                        /*" -1125- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -1127- GO TO R1000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1135- MOVE +0 TO AC-IMPMORNATU AC-IMPMORACID AC-IMPINVPERM AC-IMPAMDS AC-IMPDH AC-IMPDIT AC-IMPRTO. */
            _.Move(+0, AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDIT, AREA_DE_WORK.AC_IMPRTO);

            /*" -1137- PERFORM R1200-00-ACUMULA-IS. */

            R1200_00_ACUMULA_IS_SECTION();

            /*" -1138- IF V0APOL-RAMO EQUAL 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -1139- IF AC-IMPMORNATU NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORNATU <= 00)
                {

                    /*" -1141- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -1150- ELSE */
                    }
                    else
                    {


                        /*" -1151- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -1153- GO TO R1000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1154- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -1156- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -1158- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -1168- ELSE */
                    }
                    else
                    {


                        /*" -1169- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -1171- GO TO R1000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1172- IF V0APOL-RAMO EQUAL 81 OR 82 */

            if (V0APOL_RAMO.In("81", "82"))
            {

                /*" -1183- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -1184- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -1186- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1188- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1189- MOVE 10 TO SII. */
            _.Move(10, WS_HORAS.SII);

            /*" -1190- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1195- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_7 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_7();

            /*" -1198- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1199- GO TO R9999-00-ROT-ERRO. */

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
            /*" -863- EXEC SQL SELECT RAMO, MODALIDA, CODPRODU INTO :V0APOL-RAMO, :V0APOL-MODALIDA, :V0APOL-CODPRODU FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(executed_1.V0APOL_MODALIDA, V0APOL_MODALIDA);
                _.Move(executed_1.V0APOL_CODPRODU, V0APOL_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1000-10-LOOP-PROPAUTOM */
        private void R1000_10_LOOP_PROPAUTOM(bool isPerform = false)
        {
            /*" -1207- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -1208- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -1209- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -1211- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -1215- MOVE 0 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR V0ENDO-AGERCAP V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_BCORCAP, V0ENDO_BCOCOBR, V0ENDO_AGERCAP, V0ENDO_AGECOBR);

            /*" -1217- MOVE '0' TO V0ENDO-DACCOBR. */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -1219- MOVE 0 TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);

            /*" -1220- MOVE ' ' TO V0ENDO-DACRCAP. */
            _.Move(" ", V0ENDO_DACRCAP);

            /*" -1221- MOVE ' ' TO V0ENDO-IDRCAP. */
            _.Move(" ", V0ENDO_IDRCAP);

            /*" -1222- MOVE SPACES TO V0ENDO-DATARCAP */
            _.Move("", V0ENDO_DATARCAP);

            /*" -1224- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -1225- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -1226- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -1227- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -1228- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -1229- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -1230- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -1231- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -1232- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -1234- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -1238- MOVE 1 TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(1, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -1239- MOVE '3' TO V0ENDO-TIPO-ENDO. */
            _.Move("3", V0ENDO_TIPO_ENDO);

            /*" -1241- MOVE 'VG0138B' TO V0ENDO-COD-USUAR. */
            _.Move("VG0138B", V0ENDO_COD_USUAR);

            /*" -1243- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -1245- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -1246- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -1247- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -1248- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -1249- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -1251- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -1252- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -1253- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -1256- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -1272- MOVE V0ENDO-DTINIVIG TO V0ENDO-DATPRO. */
            _.Move(V0ENDO_DTINIVIG, V0ENDO_DATPRO);

            /*" -1275- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1276- MOVE 11 TO SII. */
            _.Move(11, WS_HORAS.SII);

            /*" -1277- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1367- PERFORM R1000_10_LOOP_PROPAUTOM_DB_INSERT_1 */

            R1000_10_LOOP_PROPAUTOM_DB_INSERT_1();

            /*" -1370- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1372- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1373- IF V0ENDO-NRPROPOS NOT EQUAL ZEROS */

                    if (V0ENDO_NRPROPOS != 00)
                    {

                        /*" -1374- GO TO R1000-10-LOOP-PROPAUTOM */
                        new Task(() => R1000_10_LOOP_PROPAUTOM()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1375- ELSE */
                    }
                    else
                    {


                        /*" -1376- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1377- ELSE */
                    }

                }
                else
                {


                    /*" -1379- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1381- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -1383- MOVE '1026' TO WNR-EXEC-SQL. */
            _.Move("1026", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1384- MOVE 12 TO SII. */
            _.Move(12, WS_HORAS.SII);

            /*" -1385- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1389- PERFORM R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1 */

            R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1();

            /*" -1392- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1395- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1397- ADD 1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + 1;

            /*" -1399- PERFORM R1300-00-GRAVA-COSSEGURO. */

            R1300_00_GRAVA_COSSEGURO_SECTION();

            /*" -1400- MOVE V0ENDO-NUM-APOLICE TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0PARC_NUM_APOL);

            /*" -1401- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -1403- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -1404- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -1405- MOVE V0ENDO-FONTE TO V0PARC-FONTE */
            _.Move(V0ENDO_FONTE, V0PARC_FONTE);

            /*" -1406- MOVE 0 TO V0PARC-NRTIT */
            _.Move(0, V0PARC_NRTIT);

            /*" -1407- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -1408- COMPUTE V0PARC-OTNTOTAL = AC-PRMVG + AC-PRMAP */
            V0PARC_OTNTOTAL.Value = AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMAP;

            /*" -1409- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -1411- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -1414- COMPUTE V0PARC-OTNPRLIQ ROUNDED = V0PARC-OTNTOTAL - WS-VLIOCC-TOT */
            V0PARC_OTNPRLIQ.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -1416- MOVE V0PARC-OTNPRLIQ TO V0PARC-PRM-TAR-IX. */
            _.Move(V0PARC_OTNPRLIQ, V0PARC_PRM_TAR_IX);

            /*" -1418- MOVE WS-VLIOCC-TOT TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VLIOCC_TOT, V0PARC_OTNIOF);

            /*" -1419- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -1420- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -1421- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -1423- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -1426- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1427- MOVE 13 TO SII. */
            _.Move(13, WS_HORAS.SII);

            /*" -1428- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1449- PERFORM R1000_10_LOOP_PROPAUTOM_DB_INSERT_2 */

            R1000_10_LOOP_PROPAUTOM_DB_INSERT_2();

            /*" -1452- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1455- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1457- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -1459- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -1461- PERFORM R1500-00-GRAVA-OPERACAO-BAIXA. */

            R1500_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -1462- MOVE V0ENDO-NUM-APOLICE TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0COBA_NUM_APOL);

            /*" -1463- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -1464- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -1465- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -1466- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -1467- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -1469- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -1470- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -1471- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -1473- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -1474- IF V0APOL-RAMO = 81 OR 97 OR 82 */

            if (V0APOL_RAMO.In("81", "97", "82"))
            {

                /*" -1475- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1476- MOVE 82 TO V0COBA-RAMOFR */
                    _.Move(82, V0COBA_RAMOFR);

                    /*" -1477- ELSE */
                }
                else
                {


                    /*" -1478- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -1480- END-IF */
                }


                /*" -1481- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                /*" -1482- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1484- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -1485- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1488- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMVG + WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -1489- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1491- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1492- ELSE */
                }
                else
                {


                    /*" -1494- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1495- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -1496- END-IF */
                }


                /*" -1498- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1499- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -1500- IF AC-PRMDIT GREATER 0 */

                if (AREA_DE_WORK.AC_PRMDIT > 0)
                {

                    /*" -1503- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0COBA-PRM-TAR-IX - AC-PRMDIT + WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.AC_PRMDIT + AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -1504- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1506- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1507- ELSE */
                }
                else
                {


                    /*" -1509- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1510- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -1511- END-IF */
                }


                /*" -1513- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1514- IF AC-IMPINVPERM GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPINVPERM > 00)
                {

                    /*" -1516- MOVE AC-IMPINVPERM TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPINVPERM, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1518- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1519- MOVE 2 TO V0COBA-COD-COBER */
                    _.Move(2, V0COBA_COD_COBER);

                    /*" -1520- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1522- END-IF */
                }


                /*" -1523- IF AC-IMPAMDS GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPAMDS > 00)
                {

                    /*" -1525- MOVE AC-IMPAMDS TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPAMDS, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1527- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1528- MOVE 3 TO V0COBA-COD-COBER */
                    _.Move(3, V0COBA_COD_COBER);

                    /*" -1529- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1531- END-IF */
                }


                /*" -1532- IF AC-IMPDH GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDH > 00)
                {

                    /*" -1534- MOVE AC-IMPDH TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDH, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1536- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1537- MOVE 4 TO V0COBA-COD-COBER */
                    _.Move(4, V0COBA_COD_COBER);

                    /*" -1538- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1540- END-IF */
                }


                /*" -1541- IF AC-IMPDIT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDIT > 00)
                {

                    /*" -1543- MOVE AC-IMPDIT TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDIT, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1545- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMDIT - WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMDIT - AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -1546- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1547- MOVE 5 TO V0COBA-COD-COBER */
                    _.Move(5, V0COBA_COD_COBER);

                    /*" -1549- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1551- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();
                }

            }


            /*" -1552- IF V0APOL-RAMO = 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -1553- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1554- MOVE 93 TO V0COBA-RAMOFR */
                    _.Move(93, V0COBA_RAMOFR);

                    /*" -1555- ELSE */
                }
                else
                {


                    /*" -1556- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -1558- END-IF */
                }


                /*" -1559- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                /*" -1560- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1562- MOVE AC-IMPMORNATU TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORNATU, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -1564- COMPUTE AC-PRMVG = AC-PRMVG - AC-PRMRTO */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.AC_PRMRTO;

                /*" -1566- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-TOT-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                /*" -1567- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1569- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMVG - WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -1570- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1572- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -1573- ELSE */
                }
                else
                {


                    /*" -1574- IF AC-IMPRTO GREATER 0 */

                    if (AREA_DE_WORK.AC_IMPRTO > 0)
                    {

                        /*" -1576- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMRTO */
                        V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMRTO;

                        /*" -1577- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -1579- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -1580- ELSE */
                    }
                    else
                    {


                        /*" -1582- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -1583- MOVE 100 TO V0COBA-PCT-COBERT */
                        _.Move(100, V0COBA_PCT_COBERT);

                        /*" -1584- END-IF */
                    }


                    /*" -1585- END-IF */
                }


                /*" -1587- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1588- MOVE 11 TO V0COBA-COD-COBER */
                _.Move(11, V0COBA_COD_COBER);

                /*" -1588- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                R1600_00_INSERT_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" R1000-10-LOOP-PROPAUTOM-DB-INSERT-1 */
        public void R1000_10_LOOP_PROPAUTOM_DB_INSERT_1()
        {
            /*" -1367- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOLICE, :V0ENDO-NRENDOS, :V0ENDO-CODSUBES, :V0ENDO-FONTE, :V0ENDO-NRPROPOS, :V0ENDO-DATPRO, :V0ENDO-DT-LIBER, :V0ENDO-DTEMIS, :V0ENDO-NRRCAP, :V0ENDO-VLRCAP, :V0ENDO-BCORCAP, :V0ENDO-AGERCAP, :V0ENDO-DACRCAP, :V0ENDO-IDRCAP, :V0ENDO-BCOCOBR, :V0ENDO-AGECOBR, :V0ENDO-DACCOBR, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-CDFRACIO, :V0ENDO-PCENTRAD, :V0ENDO-PCADICIO, :V0ENDO-PRESTA1, :V0ENDO-QTPARCEL, :V0ENDO-QTPRESTA, :V0ENDO-QTITENS, :V0ENDO-CODTXT, :V0ENDO-CDACEITA, :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO, :V0ENDO-DATARCAP:VIND-DATARCAP, :V0ENDO-COD-EMPRESA, :V0ENDO-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:VIND-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI:VIND-VLCUSEMI, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

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
            /*" -1389- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

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
            /*" -879- EXEC SQL SELECT VALUE(IND_IOF, 'S' ) INTO :V0SUBG-IND-IOF FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND COD_SUBGRUPO = :V0HCTB-CODSUBES END-EXEC. */

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
            /*" -1449- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -895- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL END-EXEC. */

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

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-SECTION */
        private void R1050_00_ESTORNA_CONTABIL_SECTION()
        {
            /*" -1599- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1600- MOVE 14 TO SII. */
            _.Move(14, WS_HORAS.SII);

            /*" -1601- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1613- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1();

            /*" -1616- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1618- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1620- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1622- SUBTRACT 1 FROM V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS - 1;

            /*" -1624- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1625- MOVE 15 TO SII. */
            _.Move(15, WS_HORAS.SII);

            /*" -1626- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1631- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2();

            /*" -1634- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1635- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1635- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-1 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1()
        {
            /*" -1613- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTFATUR = :V1SIST-DTMOVABE AND NRPARCEL = :WHOST-NRPARCEL AND CODOPER �= 1000 END-EXEC. */

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
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -1059- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSRES = :V0ENDO-NRENDOS WHERE COD_ORGAO = 10 AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-2 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2()
        {
            /*" -1631- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSRES = :V0ENDO-NRENDOS WHERE COD_ORGAO = 10 AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -930- EXEC SQL SELECT B.DATA_INIVIGENCIA , B.DATA_TERVIGENCIA INTO :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :V0HCTB-NRCERTIF AND A.NUM_PARCELA = :V0HCTB-NRPARCEL AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.COD_OPERACAO BETWEEN 200 AND 299 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO ORDER BY A.DATA_MOVIMENTO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -1012- EXEC SQL SELECT CODSUBES, DTTERVIG INTO :WHOST-CODSUBES, :WHOST-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 AND DTTERVIG > :V0ENDO-DTINIVIG END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODSUBES, WHOST_CODSUBES);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-SECTION */
        private void R1100_00_ACUMULA_PREMIO_SECTION()
        {
            /*" -1645- MOVE 'S' TO WTEM-CONVERSAO. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSAO);

            /*" -1647- MOVE '110A' TO WNR-EXEC-SQL. */
            _.Move("110A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1648- MOVE 16 TO SII. */
            _.Move(16, WS_HORAS.SII);

            /*" -1649- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1654- PERFORM R1100_00_ACUMULA_PREMIO_DB_SELECT_1 */

            R1100_00_ACUMULA_PREMIO_DB_SELECT_1();

            /*" -1657- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1659- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1660- MOVE 'N' TO WTEM-CONVERSAO */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSAO);

                    /*" -1661- ELSE */
                }
                else
                {


                    /*" -1663- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1664- IF V0PRVG-ESTR-COBR EQUAL 'MULT' */

            if (V0PRVG_ESTR_COBR == "MULT")
            {

                /*" -1665- IF WTEM-CONVERSAO EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_CONVERSAO == "S")
                {

                    /*" -1666- MOVE NUM-SICOB TO V0RCAP-NRTIT */
                    _.Move(NUM_SICOB, V0RCAP_NRTIT);

                    /*" -1667- ELSE */
                }
                else
                {


                    /*" -1668- MOVE V0HCTB-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0HCTB_NRCERTIF, V0RCAP_NRTIT);

                    /*" -1669- END-IF */
                }


                /*" -1670- ELSE */
            }
            else
            {


                /*" -1672- DISPLAY 'ESTRUTURA DE COBRANCA DESCONHECIDA ' V0PRVG-ESTR-COBR */
                _.Display($"ESTRUTURA DE COBRANCA DESCONHECIDA {V0PRVG_ESTR_COBR}");

                /*" -1674- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1676- MOVE V0PARC-DTVENCTO TO WS-DTBASE. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WS_DTBASE);

            /*" -1677- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -1680- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -1683- COMPUTE WS-PREMIO-LIQ ROUNDED = (V0HCTB-PRMVG + V0HCTB-PRMAP) / WS-IND-IOF */
            AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP) / AREA_DE_WORK.WS_IND_IOF;

            /*" -1687- COMPUTE WS-VLIOCC = V0HCTB-PRMVG + V0HCTB-PRMAP - WS-PREMIO-LIQ */
            AREA_DE_WORK.WS_VLIOCC.Value = V0HCTB_PRMVG + V0HCTB_PRMAP - AREA_DE_WORK.WS_PREMIO_LIQ;

            /*" -1689- COMPUTE WS-PRM-LIQ-AP ROUNDED = V0HCTB-PRMAP / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP / AREA_DE_WORK.WS_IND_IOF;

            /*" -1691- COMPUTE WS-VLIOCC-AP = V0HCTB-PRMAP - WS-PRM-LIQ-AP */
            AREA_DE_WORK.WS_VLIOCC_AP.Value = V0HCTB_PRMAP - AREA_DE_WORK.WS_PRM_LIQ_AP;

            /*" -1693- COMPUTE WS-PRM-LIQ-VG ROUNDED = V0HCTB-PRMVG / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG / AREA_DE_WORK.WS_IND_IOF;

            /*" -1696- COMPUTE WS-VLIOCC-VG = V0HCTB-PRMVG - WS-PRM-LIQ-VG. */
            AREA_DE_WORK.WS_VLIOCC_VG.Value = V0HCTB_PRMVG - AREA_DE_WORK.WS_PRM_LIQ_VG;

            /*" -1697- IF V0SUBG-IND-IOF = 'N' */

            if (V0SUBG_IND_IOF == "N")
            {

                /*" -1700- MOVE ZEROS TO WS-VLIOCC WS-VLIOCC-VG WS-VLIOCC-AP */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC, AREA_DE_WORK.WS_VLIOCC_VG, AREA_DE_WORK.WS_VLIOCC_AP);

                /*" -1702- COMPUTE WS-PREMIO-LIQ = (V0HCTB-PRMVG + V0HCTB-PRMAP) */
                AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP);

                /*" -1703- COMPUTE WS-PRM-LIQ-VG = V0HCTB-PRMVG */
                AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG;

                /*" -1706- COMPUTE WS-PRM-LIQ-AP = V0HCTB-PRMAP. */
                AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP;
            }


            /*" -1709- MOVE 0 TO WS-PRMRTO WS-VLIOCC-RTO. */
            _.Move(0, AREA_DE_WORK.WS_PRMRTO, AREA_DE_WORK.WS_VLIOCC_RTO);

            /*" -1710- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT + WS-VLIOCC */
            AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT + AREA_DE_WORK.WS_VLIOCC;

            /*" -1711- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP + WS-VLIOCC-AP */
            AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP + AREA_DE_WORK.WS_VLIOCC_AP;

            /*" -1712- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG + WS-VLIOCC-VG */
            AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_VG;

            /*" -1714- COMPUTE WS-VLIOCC-TOT-RTO = WS-VLIOCC-TOT-RTO + WS-VLIOCC-RTO */
            AREA_DE_WORK.WS_VLIOCC_TOT_RTO.Value = AREA_DE_WORK.WS_VLIOCC_TOT_RTO + AREA_DE_WORK.WS_VLIOCC_RTO;

            /*" -1715- COMPUTE AC-PRMVG = AC-PRMVG + V0HCTB-PRMVG */
            AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG + V0HCTB_PRMVG;

            /*" -1716- COMPUTE AC-PRMAP = AC-PRMAP + V0HCTB-PRMAP */
            AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP + V0HCTB_PRMAP;

            /*" -1718- COMPUTE AC-PRMRTO = AC-PRMRTO + WS-PRMRTO. */
            AREA_DE_WORK.AC_PRMRTO.Value = AREA_DE_WORK.AC_PRMRTO + AREA_DE_WORK.WS_PRMRTO;

            /*" -1720- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1721- MOVE 18 TO SII. */
            _.Move(18, WS_HORAS.SII);

            /*" -1722- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1732- PERFORM R1100_00_ACUMULA_PREMIO_DB_UPDATE_1 */

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1();

            /*" -1735- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1738- ADD +1 TO AC-U-V0HISTCONTABILVA. */
            AREA_DE_WORK.AC_U_V0HISTCONTABILVA.Value = AREA_DE_WORK.AC_U_V0HISTCONTABILVA + +1;

            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-SELECT-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_SELECT_1()
        {
            /*" -1654- EXEC SQL SELECT NUM_SICOB INTO :NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0HCTB-NRCERTIF END-EXEC. */

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
            /*" -1732- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' , NRENDOS = :V0ENDO-NRENDOS, DTFATUR = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST END-EXEC. */

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
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -1042- EXEC SQL SELECT ENDOSRES INTO :V0ENDO-NRENDOS FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = 10 AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
            }


        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -1742- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-7 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_7()
        {
            /*" -1195- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1()
            {
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-SECTION */
        private void R1105_00_ACESSA_V1RAMOIND_SECTION()
        {
            /*" -1753- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1754- MOVE V0APOL-RAMO TO V1RIND-RAMO */
            _.Move(V0APOL_RAMO, V1RIND_RAMO);

            /*" -1756- MOVE WS-DTBASE TO V1RIND-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DTBASE, V1RIND_DTINIVIG);

            /*" -1757- MOVE 21 TO SII. */
            _.Move(21, WS_HORAS.SII);

            /*" -1758- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1765- PERFORM R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1 */

            R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();

            /*" -1768- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1769- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1770- DISPLAY 'PROBLEMA NO ACESSAO V1RAMOIND' */
                _.Display($"PROBLEMA NO ACESSAO V1RAMOIND");

                /*" -1770- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-DB-SELECT-1 */
        public void R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1()
        {
            /*" -1765- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1RIND-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

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
        /*" R1200-00-ACUMULA-IS-SECTION */
        private void R1200_00_ACUMULA_IS_SECTION()
        {
            /*" -1779- PERFORM R1210-00-ACUMULA-IS. */

            R1210_00_ACUMULA_IS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-SECTION */
        private void R1210_00_ACUMULA_IS_SECTION()
        {
            /*" -1790- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1791- MOVE 32 TO SII. */
            _.Move(32, WS_HORAS.SII);

            /*" -1792- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1811- PERFORM R1210_00_ACUMULA_IS_DB_SELECT_1 */

            R1210_00_ACUMULA_IS_DB_SELECT_1();

            /*" -1814- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1815- IF SQLCODE NOT EQUAL ZEROES AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -1817- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1818- IF SQLCODE NOT EQUAL ZEROES AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -1820- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1821- IF V0CBPR-PRMDIT-I LESS ZEROS */

            if (V0CBPR_PRMDIT_I < 00)
            {

                /*" -1823- MOVE ZEROS TO V0CBPR-PRMDIT. */
                _.Move(0, V0CBPR_PRMDIT);
            }


            /*" -1824- COMPUTE AC-IMPMORNATU = AC-IMPMORNATU + V0CBPR-IMPMORNATU. */
            AREA_DE_WORK.AC_IMPMORNATU.Value = AREA_DE_WORK.AC_IMPMORNATU + V0CBPR_IMPMORNATU;

            /*" -1825- COMPUTE AC-IMPMORACID = AC-IMPMORACID + V0CBPR-IMPMORACID. */
            AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID + V0CBPR_IMPMORACID;

            /*" -1826- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM + V0CBPR-IMPINVPERM. */
            AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM + V0CBPR_IMPINVPERM;

            /*" -1827- COMPUTE AC-IMPAMDS = AC-IMPAMDS + V0CBPR-IMPAMDS. */
            AREA_DE_WORK.AC_IMPAMDS.Value = AREA_DE_WORK.AC_IMPAMDS + V0CBPR_IMPAMDS;

            /*" -1828- COMPUTE AC-IMPDH = AC-IMPDH + V0CBPR-IMPDH. */
            AREA_DE_WORK.AC_IMPDH.Value = AREA_DE_WORK.AC_IMPDH + V0CBPR_IMPDH;

            /*" -1830- COMPUTE AC-IMPDIT = AC-IMPDIT + V0CBPR-IMPDIT. */
            AREA_DE_WORK.AC_IMPDIT.Value = AREA_DE_WORK.AC_IMPDIT + V0CBPR_IMPDIT;

            /*" -1831- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

            if (V0CBPR_IMPDIT != 00)
            {

                /*" -1831- PERFORM R1220-00-LE-PREMIO-DIT. */

                R1220_00_LE_PREMIO_DIT_SECTION();
            }


        }

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-DB-SELECT-1 */
        public void R1210_00_ACUMULA_IS_DB_SELECT_1()
        {
            /*" -1811- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, PRMDIT INTO :V0CBPR-IMPMORNATU, :V0CBPR-IMPMORACID, :V0CBPR-IMPINVPERM, :V0CBPR-IMPAMDS, :V0CBPR-IMPDH, :V0CBPR-IMPDIT, :V0CBPR-PRMDIT:V0CBPR-PRMDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO END-EXEC. */

            var r1210_00_ACUMULA_IS_DB_SELECT_1_Query1 = new R1210_00_ACUMULA_IS_DB_SELECT_1_Query1()
            {
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
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
            /*" -1842- MOVE V0CBPR-PRMDIT TO V0PLAN-PRMDIT. */
            _.Move(V0CBPR_PRMDIT, V0PLAN_PRMDIT);

            /*" -1844- MOVE '1222' TO WNR-EXEC-SQL. */
            _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1846- MOVE V0PARC-DTVENCTO TO WS-DTBASE. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WS_DTBASE);

            /*" -1848- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -1850- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -1852- COMPUTE WS-PRM-LIQ-DIT ROUNDED = V0PLAN-PRMDIT / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_DIT.Value = V0PLAN_PRMDIT / AREA_DE_WORK.WS_IND_IOF;

            /*" -1855- COMPUTE WS-VLIOCC-DIT = V0PLAN-PRMDIT - WS-PRM-LIQ-DIT */
            AREA_DE_WORK.WS_VLIOCC_DIT.Value = V0PLAN_PRMDIT - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -1856- IF V0SUBG-IND-IOF = 'N' */

            if (V0SUBG_IND_IOF == "N")
            {

                /*" -1857- MOVE ZEROS TO WS-VLIOCC-DIT */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_DIT);

                /*" -1859- MOVE V0PLAN-PRMDIT TO WS-PRM-LIQ-DIT. */
                _.Move(V0PLAN_PRMDIT, AREA_DE_WORK.WS_PRM_LIQ_DIT);
            }


            /*" -1860- ADD V0PLAN-PRMDIT TO AC-PRMDIT. */
            AREA_DE_WORK.AC_PRMDIT.Value = AREA_DE_WORK.AC_PRMDIT + V0PLAN_PRMDIT;

            /*" -1861- COMPUTE WS-VLIOCC-TOT-DIT = WS-VLIOCC-TOT-DIT + WS-VLIOCC-DIT. */
            AREA_DE_WORK.WS_VLIOCC_TOT_DIT.Value = AREA_DE_WORK.WS_VLIOCC_TOT_DIT + AREA_DE_WORK.WS_VLIOCC_DIT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-SECTION */
        private void R1300_00_GRAVA_COSSEGURO_SECTION()
        {
            /*" -1871- MOVE 34 TO SII. */
            _.Move(34, WS_HORAS.SII);

            /*" -1872- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1879- PERFORM R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1 */

            R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1();

            /*" -1882- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1883- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1883- PERFORM R1300_00_GRAVA_COSSEGURO_DB_OPEN_1 */

            R1300_00_GRAVA_COSSEGURO_DB_OPEN_1();

            /*" -1886- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1886- GO TO R9999-00-ROT-ERRO. */

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
            /*" -1883- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED */
        private void R1300_10_FETCH_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -1893- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1895- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -1898- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1899- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1899- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -1901- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -1902- ELSE */
                }
                else
                {


                    /*" -1905- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1907- MOVE '1303' TO WNR-EXEC-SQL. */
            _.Move("1303", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1908- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -1909- MOVE V0ENDO-NUM-APOLICE TO V0ORDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0ORDC_NUM_APOL);

            /*" -1910- MOVE V0ENDO-NRENDOS TO V0ORDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0ORDC_NRENDOS);

            /*" -1912- MOVE V1COSP-CONGENER TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V1COSP_CONGENER, V0ORDC_CODCOSS);
            _.Move(V1COSP_CONGENER, AREA_DE_WORK.FILLER_5.WWORK_ORD_CONGE);


            /*" -1914- MOVE 10 TO WWORK-ORD-ORGAO. */
            _.Move(10, AREA_DE_WORK.FILLER_5.WWORK_ORD_ORGAO);

            /*" -1915- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -1917- MOVE 10 TO V1NCOS-ORGAO. */
            _.Move(10, V1NCOS_ORGAO);

            /*" -1923- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1();

            /*" -1926- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1927- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1929- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1931- MOVE '2288' TO WNR-EXEC-SQL. */
            _.Move("2288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1933- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -1935- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_5.WWORK_ORD_SEQUE);

            /*" -1937- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -1938- MOVE 35 TO SII. */
            _.Move(35, WS_HORAS.SII);

            /*" -1939- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1947- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1();

            /*" -1950- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1953- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1955- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -1957- MOVE '1304' TO WNR-EXEC-SQL. */
            _.Move("1304", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1958- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -1960- MOVE 10 TO V1NCOS-ORGAO. */
            _.Move(10, V1NCOS_ORGAO);

            /*" -1961- MOVE 36 TO SII. */
            _.Move(36, WS_HORAS.SII);

            /*" -1962- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1968- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1();

            /*" -1971- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1972- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1974- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1976- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

            /*" -1977- MOVE 'EM0103B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0103B1", V0EDIA_CODRELAT);

            /*" -1978- MOVE V0ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -1979- MOVE V0ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -1980- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -1981- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -1982- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -1983- MOVE V0APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(V0APOL_RAMO, V0EDIA_RAMO);

            /*" -1984- MOVE ZEROS TO V0EDIA-FONTE. */
            _.Move(0, V0EDIA_FONTE);

            /*" -1985- MOVE V1COSP-CONGENER TO V0EDIA-CONGENER. */
            _.Move(V1COSP_CONGENER, V0EDIA_CONGENER);

            /*" -1987- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -1989- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -1990- MOVE V0ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(V0ENDO_FONTE, V0EDIA_FONTE);

            /*" -1991- MOVE 'EM0105B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0105B1", V0EDIA_CODRELAT);

            /*" -1993- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -1993- GO TO R1300-10-FETCH-V1APOLCOSCED. */
            new Task(() => R1300_10_FETCH_V1APOLCOSCED()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -1895- EXEC SQL FETCH V1APOLCOSCED INTO :V1COSP-CONGENER END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1COSP_CONGENER, V1COSP_CONGENER);
            }

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -1899- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-SELECT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -1923- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -1947- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -1968- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -2004- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2005- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -2007- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -2008- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -2009- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -2010- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -2012- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -2014- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -2015- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -2016- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -2017- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -2018- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -2019- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -2020- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -2022- COMPUTE V0HISP-VLIOCC = V0HISP-VLPRMTOT - V0HISP-VLPRMLIQ */
            V0HISP_VLIOCC.Value = V0HISP_VLPRMTOT - V0HISP_VLPRMLIQ;

            /*" -2023- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -2024- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -2025- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -2026- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -2027- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2028- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -2029- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2030- MOVE 'VG0138B' TO V0HISP-COD-USUAR */
            _.Move("VG0138B", V0HISP_COD_USUAR);

            /*" -2032- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2034- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -2036- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -2036- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R1500_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -2046- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -2047- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -2049- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -2050- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -2052- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -2054- MOVE 0290 TO V0HISP-OPERACAO */
            _.Move(0290, V0HISP_OPERACAO);

            /*" -2056- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -2057- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -2058- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -2059- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -2060- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -2061- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -2062- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -2064- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -2065- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -2066- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -2067- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -2068- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -2069- MOVE 0 TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2070- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -2071- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2072- MOVE 'VG0138B' TO V0HISP-COD-USUAR */
            _.Move("VG0138B", V0HISP_COD_USUAR);

            /*" -2074- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2075- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -2077- MOVE V1SIST-DTMOVACB TO V0HISP-DTQITBCO. */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTQITBCO);

            /*" -2079- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -2079- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-SECTION */
        private void R1450_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -2090- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2091- MOVE 37 TO SII. */
            _.Move(37, WS_HORAS.SII);

            /*" -2092- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2121- PERFORM R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -2124- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2125- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2127- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2127- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -2121- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2139- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2140- MOVE 38 TO SII. */
            _.Move(38, WS_HORAS.SII);

            /*" -2141- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2161- PERFORM R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -2164- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2165- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2167- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2167- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -2161- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

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
            /*" -2178- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2179- MOVE 39 TO SII. */
            _.Move(39, WS_HORAS.SII);

            /*" -2180- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2195- PERFORM R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -2198- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2199- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2200- DISPLAY 'R1700-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"R1700-00 (REGISTRO DUPLICADO) ... ");

                /*" -2202- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2204- DISPLAY 'R1700-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1700-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -2206- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2206- ADD 1 TO AC-I-V0EMISDIARIA. */
            AREA_DE_WORK.AC_I_V0EMISDIARIA.Value = AREA_DE_WORK.AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -2195- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , NULL , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2218- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -2219- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2220- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2222- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2223- DISPLAY 'LIDOS  V0HISTCONTABILVA  ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS  V0HISTCONTABILVA  {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -2224- DISPLAY 'INSERT V0ENDOSSO         ' AC-I-V0ENDOSSO. */
            _.Display($"INSERT V0ENDOSSO         {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -2225- DISPLAY 'INSERT V0ORDECOSCED      ' AC-I-V0ORDECOSCED. */
            _.Display($"INSERT V0ORDECOSCED      {AREA_DE_WORK.AC_I_V0ORDECOSCED}");

            /*" -2226- DISPLAY 'INSERT V0EMISDIARIA      ' AC-I-V0EMISDIARIA. */
            _.Display($"INSERT V0EMISDIARIA      {AREA_DE_WORK.AC_I_V0EMISDIARIA}");

            /*" -2227- DISPLAY 'INSERT V0PARCELA         ' AC-I-V0PARCELA. */
            _.Display($"INSERT V0PARCELA         {AREA_DE_WORK.AC_I_V0PARCELA}");

            /*" -2228- DISPLAY 'INSERT V0HISTOPARC       ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC       {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -2230- DISPLAY 'INSERT V0COBERAPOL       ' AC-I-V0COBERAPOL. */
            _.Display($"INSERT V0COBERAPOL       {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -2231- DISPLAY 'UPDATE V0NUMEROAES       ' AC-U-V0NUMERAES. */
            _.Display($"UPDATE V0NUMEROAES       {AREA_DE_WORK.AC_U_V0NUMERAES}");

            /*" -2232- DISPLAY 'UPDATE V0FONTE           ' AC-U-V0FONTE. */
            _.Display($"UPDATE V0FONTE           {AREA_DE_WORK.AC_U_V0FONTE}");

            /*" -2233- DISPLAY 'UPDATE V0HISTCONTABILVA  ' AC-U-V0HISTCONTABILVA. */
            _.Display($"UPDATE V0HISTCONTABILVA  {AREA_DE_WORK.AC_U_V0HISTCONTABILVA}");

            /*" -2233- DISPLAY 'UPDATE V0NUMERO-COSSEGURO' AC-U-V0NUMERO-COSSEGURO. */
            _.Display($"UPDATE V0NUMERO-COSSEGURO{AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -2242- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2242- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -2252- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2253- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2254- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2255- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_21[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_21[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -2255- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_21[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_21[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -2265- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2265- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -2271- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -2272- IF SII < 51 */

            if (WS_HORAS.SII < 51)
            {

                /*" -2273- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_21[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -2275- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_21[WS_HORAS.SII]}"
                .Display();

                /*" -2277- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2277- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2290- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2291- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2292- DISPLAY 'CERTIFICADO ' V0HCTB-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTB_NRCERTIF}");

            /*" -2293- DISPLAY 'LIDOS       ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -2294- DISPLAY 'VALOR       ' V0CBPR-IMPDIT. */
            _.Display($"VALOR       {V0CBPR_IMPDIT}");

            /*" -2295- DISPLAY V0PROP-CODPRODU */
            _.Display(V0PROP_CODPRODU);

            /*" -2296- DISPLAY V0ENDO-DTINIVIG */
            _.Display(V0ENDO_DTINIVIG);

            /*" -2297- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -2299- DISPLAY V0CBPR-IMPDIT */
            _.Display(V0CBPR_IMPDIT);

            /*" -2300- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -2302- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -2302- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2304- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2308- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2308- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}