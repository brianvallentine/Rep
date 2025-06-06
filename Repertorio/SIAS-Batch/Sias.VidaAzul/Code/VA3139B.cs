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
using Sias.VidaAzul.DB2.VA3139B;

namespace Code
{
    public class VA3139B
    {
        public bool IsCall { get; set; }

        public VA3139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ...............  VIDA - PREFERENCIAL VIDA ATIVOS CEF *      */
        /*"      *   PROGRAMA ..............  VA3139B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ..............  TERCIO/LUIZ CARLOS                  *      */
        /*"      *   PROGRAMADOR ...........  TERCIO/LUIZ CARLOS                  *      */
        /*"      *   DATA CODIFICACAO ......  23/09/1999                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................  A PARTIR DO ENDOSSO DE COBRANCA PEN-*      */
        /*"      *                            DENTE BAIXA A COBRANCA.             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * APOLICE COSSEGURO                   V1APOLCOSCED      INPUT    *      */
        /*"      * PRODUTOS SISTEMA VIDA               V0PRODUTOSVG      INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         I-O      *      */
        /*"      * PARCELAS                            V0PARCELA         I-O      *      */
        /*"      * HISTORICO DE PARCELAS               V0HISTOPARC       I-O      *      */
        /*"      * ORDEM COSSEGURO CEDIDO              V0ORDECOSCED      OUTPUT   *      */
        /*"      * RELATORIOS                          V0RELATORIOS      OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77              WHOST-NRAVISO         PIC S9(009)      COMP.*/
        public IntBasis WHOST_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77              VIND-CODEMP           PIC S9(004)      COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              VIND-ORIGAVISO        PIC S9(004)      COMP.*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              VIND-VALADT           PIC S9(004)      COMP.*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"01  V0SALD-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0SALD_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-BCOAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-AGEAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-TIPSGU                    PIC X(01).*/
        public StringBasis V0SALD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0SALD-NRAVISO                   PIC S9(09)    COMP.*/
        public IntBasis V0SALD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-DTAVISO                   PIC X(10).*/
        public StringBasis V0SALD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-DTMOVTO                   PIC X(10).*/
        public StringBasis V0SALD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-SDOATU                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SALD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SALD-SITUACAO                  PIC X(01).*/
        public StringBasis V0SALD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-BCOAVISO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-AGEAVISO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-NRAVISO                   PIC S9(09)    COMP VALUE +0*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-NRSEQ                     PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-DTMOVTO                   PIC X(10).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-OPERACAO                  PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-TIPAVI                    PIC X(01).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-DTAVISO                   PIC X(10).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-VLIOCC                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLDESPES                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-PRECED                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMLIQ                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-SITCONTB                  PIC X(01).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0AVIS_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-ORIGAVISO                 PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-VALADT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
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
        /*"01         V1SIST-DTMOVARG     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVARG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0APOL-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"01         V0PLAN-IPRMDIT      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PLAN_IPRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PLAN-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"01         V0PRVF-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PRVF_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         TABELA-ULTIMOS-DIAS.*/
        public VA3139B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA3139B_TABELA_ULTIMOS_DIAS();
        public class VA3139B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VA3139B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VA3139B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VA3139B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VA3139B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VA3139B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA3139B_TAB_DIA_MESES>(12);
            public class VA3139B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VA3139B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VA3139B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VA3139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA3139B_AREA_DE_WORK();
        public class VA3139B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VA3139B_WS_DTBASE WS_DTBASE { get; set; } = new VA3139B_WS_DTBASE();
            public class VA3139B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VA3139B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VA3139B_WS_DTBASE_AM();
                public class VA3139B_WS_DTBASE_AM : VarBasis
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
            public VA3139B_WS_DTFATUR WS_DTFATUR { get; set; } = new VA3139B_WS_DTFATUR();
            public class VA3139B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VA3139B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VA3139B_WS_DTFATUR_AM();
                public class VA3139B_WS_DTFATUR_AM : VarBasis
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
            /*"  05         WFIM-V0ENDOSSO           PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V0ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
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
            private _REDEF_VA3139B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA3139B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA3139B_FILLER_5(); _.Move(WWORK_NUM_ORDEM, _filler_5); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_5, WWORK_NUM_ORDEM); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUM_ORDEM); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VA3139B_FILLER_5 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VA3139B_FILLER_5()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VA3139B_WWORK_DATA WWORK_DATA { get; set; } = new VA3139B_WWORK_DATA();
            public class VA3139B_WWORK_DATA : VarBasis
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
            public VA3139B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VA3139B_WDATA_SISTEMA();
            public class VA3139B_WDATA_SISTEMA : VarBasis
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
            public VA3139B_WS_DATE WS_DATE { get; set; } = new VA3139B_WS_DATE();
            public class VA3139B_WS_DATE : VarBasis
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
            public VA3139B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA3139B_WDATA_CABEC();
            public class VA3139B_WDATA_CABEC : VarBasis
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
            /*"  05         AC-L-V0ENDOSSO         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_L_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ENDOSSO          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0RCAPCOMP         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ORDECOSCED       PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0PARCELA          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V0PARCELA          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_L_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0HISTOPARC        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0COBERAPOL        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0ENDOSSO          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERAES         PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0PARCELA          PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0ENDOSSOABILVA    PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0ENDOSSOABILVA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-U-V0NUMERO-COSSEGURO PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERO_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WS-NRAVISO              PIC  9(009)   VALUE  0.*/
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         FILLER                  REDEFINES     WS-NRAVISO.*/
            private _REDEF_VA3139B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA3139B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA3139B_FILLER_14(); _.Move(WS_NRAVISO, _filler_14); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_14, WS_NRAVISO); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_NRAVISO); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_VA3139B_FILLER_14 : VarBasis
            {
                /*"             10 WS-AGEAVISO          PIC  9(004).*/
                public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"             10 WS-NSAC              PIC  9(005).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05            WS-ACG-TOTDBEFET     PIC  9(013)V99 VALUE ZEROS.*/

                public _REDEF_VA3139B_FILLER_14()
                {
                    WS_AGEAVISO.ValueChanged += OnValueChanged;
                    WS_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_ACG_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05        WABEND.*/
            public VA3139B_WABEND WABEND { get; set; } = new VA3139B_WABEND();
            public class VA3139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA3139B '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA3139B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public VA3139B_ENDOSSO ENDOSSO { get; set; } = new VA3139B_ENDOSSO();
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
            /*" -467- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -470- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -473- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -477- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -484- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -489- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -491- MOVE V1SIST-DTMOVARG TO WWORK-DATA. */
            _.Move(V1SIST_DTMOVARG, AREA_DE_WORK.WWORK_DATA);

            /*" -492- MOVE 01 TO WWORK-DIA. */
            _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -493- MOVE WWORK-DATA TO V0ENDO-DTINIVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTINIVIG);

            /*" -495- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -500- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -503- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -505- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -510- PERFORM R0000_00_PRINCIPAL_DB_SELECT_3 */

            R0000_00_PRINCIPAL_DB_SELECT_3();

            /*" -513- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -515- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -517- PERFORM R0100-00-MONTA-AVISO. */

            R0100_00_MONTA_AVISO_SECTION();

            /*" -519- DISPLAY 'INICIO VIGENCIA  : ' V0ENDO-DTINIVIG. */
            _.Display($"INICIO VIGENCIA  : {V0ENDO_DTINIVIG}");

            /*" -540- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -544- DISPLAY 'VA3139B - ABRINDO CURSOR ...' . */
            _.Display($"VA3139B - ABRINDO CURSOR ...");

            /*" -545- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -545- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -550- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -552- DISPLAY 'PROCESSANDO . .......... ' . */
            _.Display($"PROCESSANDO . .......... ");

            /*" -554- PERFORM R0910-00-FETCH-ENDOSSO. */

            R0910_00_FETCH_ENDOSSO_SECTION();

            /*" -555- IF WFIM-V0ENDOSSO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0ENDOSSO.IsEmpty())
            {

                /*" -557- DISPLAY 'VA3139B - NENHUM ENDOSSO A BAIXAR' */
                _.Display($"VA3139B - NENHUM ENDOSSO A BAIXAR");

                /*" -559- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -562- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0ENDOSSO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0ENDOSSO.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -564- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -570- PERFORM R0200-00-INSERT-AVISOS. */

            R0200_00_INSERT_AVISOS_SECTION();

            /*" -572- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -572- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -576- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -576- GO TO R9999-00-ROT-ERRO. */

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
            /*" -484- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVARG, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'RG' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVARG, V1SIST_DTMOVARG);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -584- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -585- DISPLAY ' ' . */
            _.Display($" ");

            /*" -587- DISPLAY '*--------  VA3139B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VA3139B - FIM NORMAL  --------*");

            /*" -587- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -500- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -540- EXEC SQL DECLARE ENDOSSO CURSOR FOR SELECT A.NUM_APOLICE, A.NRENDOS, A.CODSUBES, A.FONTE, A.DTEMIS, A.DTVENCTO FROM SEGUROS.V0ENDOSSO A, SEGUROS.V0PRODUTOSVG B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND A.TIPO_ENDOSSO = '1' AND A.SITUACAO = '0' AND A.DTINIVIG = :V0ENDO-DTINIVIG AND B.DIA_FATURA = 31 AND B.ESTR_COBR IN ( 'MULT' , 'FEDERAL' ) AND B.ORIG_PRODU = 'CEF DEB CC' ORDER BY A.NUM_APOLICE, A.CODSUBES, A.FONTE END-EXEC. */
            ENDOSSO = new VA3139B_ENDOSSO(true);
            string GetQuery_ENDOSSO()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.CODSUBES
							, 
							A.FONTE
							, 
							A.DTEMIS
							, 
							A.DTVENCTO 
							FROM SEGUROS.V0ENDOSSO A
							, 
							SEGUROS.V0PRODUTOSVG B 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND A.TIPO_ENDOSSO = '1' 
							AND A.SITUACAO = '0' 
							AND A.DTINIVIG = '{V0ENDO_DTINIVIG}' 
							AND B.DIA_FATURA = 31 
							AND B.ESTR_COBR IN ( 'MULT'
							, 'FEDERAL' ) 
							AND B.ORIG_PRODU = 'CEF DEB CC' 
							ORDER BY A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE";

                return query;
            }
            ENDOSSO.GetQueryEvent += GetQuery_ENDOSSO;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -545- EXEC SQL OPEN ENDOSSO END-EXEC. */

            ENDOSSO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-3 */
        public void R0000_00_PRINCIPAL_DB_SELECT_3()
        {
            /*" -510- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_3_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_3_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0100-00-MONTA-AVISO-SECTION */
        private void R0100_00_MONTA_AVISO_SECTION()
        {
            /*" -599- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -605- PERFORM R0100_00_MONTA_AVISO_DB_SELECT_1 */

            R0100_00_MONTA_AVISO_DB_SELECT_1();

            /*" -609- ADD 1 TO WHOST-NRAVISO. */
            WHOST_NRAVISO.Value = WHOST_NRAVISO + 1;

            /*" -610- MOVE 104 TO V0AVIS-BCOAVISO */
            _.Move(104, V0AVIS_BCOAVISO);

            /*" -611- MOVE 7215 TO V0AVIS-AGEAVISO */
            _.Move(7215, V0AVIS_AGEAVISO);

            /*" -612- MOVE WHOST-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WHOST_NRAVISO, V0AVIS_NRAVISO);

            /*" -613- MOVE 1 TO V0AVIS-NRSEQ */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -614- MOVE V1SIST-DTMOVABE TO V0AVIS-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -615- MOVE 100 TO V0AVIS-OPERACAO */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -616- MOVE 'C' TO V0AVIS-TIPAVI */
            _.Move("C", V0AVIS_TIPAVI);

            /*" -617- MOVE V1SIST-DTMOVABE TO V0AVIS-DTAVISO */
            _.Move(V1SIST_DTMOVABE, V0AVIS_DTAVISO);

            /*" -618- MOVE ZEROS TO V0AVIS-VLIOCC */
            _.Move(0, V0AVIS_VLIOCC);

            /*" -619- MOVE ZEROS TO V0AVIS-VLDESPES */
            _.Move(0, V0AVIS_VLDESPES);

            /*" -620- MOVE ZEROS TO V0AVIS-PRECED */
            _.Move(0, V0AVIS_PRECED);

            /*" -621- MOVE '0' TO V0AVIS-SITCONTB */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -622- MOVE ZEROS TO V0AVIS-CODEMP */
            _.Move(0, V0AVIS_CODEMP);

            /*" -623- MOVE 12 TO V0AVIS-ORIGAVISO */
            _.Move(12, V0AVIS_ORIGAVISO);

            /*" -623- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

        }

        [StopWatch]
        /*" R0100-00-MONTA-AVISO-DB-SELECT-1 */
        public void R0100_00_MONTA_AVISO_DB_SELECT_1()
        {
            /*" -605- EXEC SQL SELECT MAX(NRAVISO) INTO :WHOST-NRAVISO FROM SEGUROS.V0AVISOCRED WHERE BCOAVISO = 104 AND AGEAVISO = 7215 END-EXEC. */

            var r0100_00_MONTA_AVISO_DB_SELECT_1_Query1 = new R0100_00_MONTA_AVISO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_MONTA_AVISO_DB_SELECT_1_Query1.Execute(r0100_00_MONTA_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRAVISO, WHOST_NRAVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INSERT-AVISOS-SECTION */
        private void R0200_00_INSERT_AVISOS_SECTION()
        {
            /*" -636- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -637- MOVE WS-ACG-TOTDBEFET TO V0AVIS-VLPRMLIQ */
            _.Move(AREA_DE_WORK.WS_ACG_TOTDBEFET, V0AVIS_VLPRMLIQ);

            /*" -639- MOVE WS-ACG-TOTDBEFET TO V0AVIS-VLPRMTOT. */
            _.Move(AREA_DE_WORK.WS_ACG_TOTDBEFET, V0AVIS_VLPRMTOT);

            /*" -643- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -663- PERFORM R0200_00_INSERT_AVISOS_DB_INSERT_1 */

            R0200_00_INSERT_AVISOS_DB_INSERT_1();

            /*" -666- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -667- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -668- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -669- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -670- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -671- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -672- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -673- MOVE ZEROS TO V0SALD-SDOATU */
            _.Move(0, V0SALD_SDOATU);

            /*" -675- MOVE '0' TO V0SALD-SITUACAO. */
            _.Move("0", V0SALD_SITUACAO);

            /*" -687- PERFORM R0200_00_INSERT_AVISOS_DB_INSERT_2 */

            R0200_00_INSERT_AVISOS_DB_INSERT_2();

        }

        [StopWatch]
        /*" R0200-00-INSERT-AVISOS-DB-INSERT-1 */
        public void R0200_00_INSERT_AVISOS_DB_INSERT_1()
        {
            /*" -663- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO:VIND-ORIGAVISO , :V0AVIS-VALADT:VIND-VALADT) END-EXEC. */

            var r0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1 = new R0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
                V0AVIS_DTMOVTO = V0AVIS_DTMOVTO.ToString(),
                V0AVIS_OPERACAO = V0AVIS_OPERACAO.ToString(),
                V0AVIS_TIPAVI = V0AVIS_TIPAVI.ToString(),
                V0AVIS_DTAVISO = V0AVIS_DTAVISO.ToString(),
                V0AVIS_VLIOCC = V0AVIS_VLIOCC.ToString(),
                V0AVIS_VLDESPES = V0AVIS_VLDESPES.ToString(),
                V0AVIS_PRECED = V0AVIS_PRECED.ToString(),
                V0AVIS_VLPRMLIQ = V0AVIS_VLPRMLIQ.ToString(),
                V0AVIS_VLPRMTOT = V0AVIS_VLPRMTOT.ToString(),
                V0AVIS_SITCONTB = V0AVIS_SITCONTB.ToString(),
                V0AVIS_CODEMP = V0AVIS_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0AVIS_ORIGAVISO = V0AVIS_ORIGAVISO.ToString(),
                VIND_ORIGAVISO = VIND_ORIGAVISO.ToString(),
                V0AVIS_VALADT = V0AVIS_VALADT.ToString(),
                VIND_VALADT = VIND_VALADT.ToString(),
            };

            R0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1.Execute(r0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INSERT-AVISOS-DB-INSERT-2 */
        public void R0200_00_INSERT_AVISOS_DB_INSERT_2()
        {
            /*" -687- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r0200_00_INSERT_AVISOS_DB_INSERT_2_Insert1 = new R0200_00_INSERT_AVISOS_DB_INSERT_2_Insert1()
            {
                V0SALD_CODEMP = V0SALD_CODEMP.ToString(),
                V0SALD_BCOAVISO = V0SALD_BCOAVISO.ToString(),
                V0SALD_AGEAVISO = V0SALD_AGEAVISO.ToString(),
                V0SALD_TIPSGU = V0SALD_TIPSGU.ToString(),
                V0SALD_NRAVISO = V0SALD_NRAVISO.ToString(),
                V0SALD_DTAVISO = V0SALD_DTAVISO.ToString(),
                V0SALD_DTMOVTO = V0SALD_DTMOVTO.ToString(),
                V0SALD_SDOATU = V0SALD_SDOATU.ToString(),
                V0SALD_SITUACAO = V0SALD_SITUACAO.ToString(),
            };

            R0200_00_INSERT_AVISOS_DB_INSERT_2_Insert1.Execute(r0200_00_INSERT_AVISOS_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R0910-00-FETCH-ENDOSSO-SECTION */
        private void R0910_00_FETCH_ENDOSSO_SECTION()
        {
            /*" -698- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -705- PERFORM R0910_00_FETCH_ENDOSSO_DB_FETCH_1 */

            R0910_00_FETCH_ENDOSSO_DB_FETCH_1();

            /*" -708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -709- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -709- PERFORM R0910_00_FETCH_ENDOSSO_DB_CLOSE_1 */

                    R0910_00_FETCH_ENDOSSO_DB_CLOSE_1();

                    /*" -711- MOVE 'S' TO WFIM-V0ENDOSSO */
                    _.Move("S", AREA_DE_WORK.WFIM_V0ENDOSSO);

                    /*" -712- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -713- ELSE */
                }
                else
                {


                    /*" -715- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -715- ADD 1 TO AC-L-V0ENDOSSO. */
            AREA_DE_WORK.AC_L_V0ENDOSSO.Value = AREA_DE_WORK.AC_L_V0ENDOSSO + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-ENDOSSO-DB-FETCH-1 */
        public void R0910_00_FETCH_ENDOSSO_DB_FETCH_1()
        {
            /*" -705- EXEC SQL FETCH ENDOSSO INTO :V0ENDO-NUM-APOLICE , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-DTEMIS , :V0ENDO-DTVENCTO END-EXEC. */

            if (ENDOSSO.Fetch())
            {
                _.Move(ENDOSSO.V0ENDO_NUM_APOLICE, V0ENDO_NUM_APOLICE);
                _.Move(ENDOSSO.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
                _.Move(ENDOSSO.V0ENDO_CODSUBES, V0ENDO_CODSUBES);
                _.Move(ENDOSSO.V0ENDO_FONTE, V0ENDO_FONTE);
                _.Move(ENDOSSO.V0ENDO_DTEMIS, V0ENDO_DTEMIS);
                _.Move(ENDOSSO.V0ENDO_DTVENCTO, V0ENDO_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-ENDOSSO-DB-CLOSE-1 */
        public void R0910_00_FETCH_ENDOSSO_DB_CLOSE_1()
        {
            /*" -709- EXEC SQL CLOSE ENDOSSO END-EXEC */

            ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -728- PERFORM R1330-00-LER-V0PARCELA. */

            R1330_00_LER_V0PARCELA_SECTION();

            /*" -730- PERFORM R1350-00-LER-V0HISTOPARC. */

            R1350_00_LER_V0HISTOPARC_SECTION();

            /*" -732- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -734- PERFORM R1550-00-ATUALIZA-V0PARCELA. */

            R1550_00_ATUALIZA_V0PARCELA_SECTION();

            /*" -736- PERFORM R1600-00-ATUALIZA-V0ENDOSSO. */

            R1600_00_ATUALIZA_V0ENDOSSO_SECTION();

            /*" -736- PERFORM R0910-00-FETCH-ENDOSSO. */

            R0910_00_FETCH_ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1330-00-LER-V0PARCELA-SECTION */
        private void R1330_00_LER_V0PARCELA_SECTION()
        {
            /*" -749- MOVE '1330' TO WNR-EXEC-SQL. */
            _.Move("1330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -755- PERFORM R1330_00_LER_V0PARCELA_DB_SELECT_1 */

            R1330_00_LER_V0PARCELA_DB_SELECT_1();

            /*" -758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -759- DISPLAY 'PROBLEMAS NO ACESSO V0PARCELA.... ' SQLCODE */
                _.Display($"PROBLEMAS NO ACESSO V0PARCELA.... {DB.SQLCODE}");

                /*" -760- DISPLAY 'APOLICE.............  ' V0ENDO-NUM-APOLICE */
                _.Display($"APOLICE.............  {V0ENDO_NUM_APOLICE}");

                /*" -761- DISPLAY 'ENDOSSO.............  ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO.............  {V0ENDO_NRENDOS}");

                /*" -763- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -763- ADD 1 TO V0PARC-OCORHIST. */
            V0PARC_OCORHIST.Value = V0PARC_OCORHIST + 1;

        }

        [StopWatch]
        /*" R1330-00-LER-V0PARCELA-DB-SELECT-1 */
        public void R1330_00_LER_V0PARCELA_DB_SELECT_1()
        {
            /*" -755- EXEC SQL SELECT OCORHIST INTO :V0PARC-OCORHIST FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND NRENDOS = :V0ENDO-NRENDOS END-EXEC. */

            var r1330_00_LER_V0PARCELA_DB_SELECT_1_Query1 = new R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
            };

            var executed_1 = R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1.Execute(r1330_00_LER_V0PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_OCORHIST, V0PARC_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-LER-V0HISTOPARC-SECTION */
        private void R1350_00_LER_V0HISTOPARC_SECTION()
        {
            /*" -777- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -833- PERFORM R1350_00_LER_V0HISTOPARC_DB_SELECT_1 */

            R1350_00_LER_V0HISTOPARC_DB_SELECT_1();

            /*" -836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -838- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -838- ADD +1 TO AC-L-V0PARCELA. */
            AREA_DE_WORK.AC_L_V0PARCELA.Value = AREA_DE_WORK.AC_L_V0PARCELA + +1;

        }

        [StopWatch]
        /*" R1350-00-LER-V0HISTOPARC-DB-SELECT-1 */
        public void R1350_00_LER_V0HISTOPARC_DB_SELECT_1()
        {
            /*" -833- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NRPARCEL, DACPARC, DTMOVTO, OPERACAO, OCORHIST, PRM_TARIFARIO, VAL_DESCONTO, VLPRMLIQ, VLADIFRA, VLCUSEMI, VLIOCC, VLPRMTOT, VLPREMIO, DTVENCTO, BCOCOBR, AGECOBR, NRAVISO, NRENDOCA, SITCONTB, COD_USUARIO, RNUDOC, DTQITBCO, COD_EMPRESA INTO :V0HISP-NUM-APOL, :V0HISP-NRENDOS, :V0HISP-NRPARCEL, :V0HISP-DACPARC, :V0HISP-DTMOVTO, :V0HISP-OPERACAO, :V0HISP-OCORHIST, :V0HISP-PRM-TARIFA, :V0HISP-VAL-DESCON, :V0HISP-VLPRMLIQ, :V0HISP-VLADIFRA, :V0HISP-VLCUSEMI, :V0HISP-VLIOCC, :V0HISP-VLPRMTOT, :V0HISP-VLPREMIO, :V0HISP-DTVENCTO, :V0HISP-BCOCOBR, :V0HISP-AGECOBR, :V0HISP-NRAVISO, :V0HISP-NRENDOCA, :V0HISP-SITCONTB, :V0HISP-COD-USUAR, :V0HISP-RNUDOC, :V0HISP-DTQITBCO:VIND-DTQITBCO, :V0HISP-COD-EMPRESA FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND NRENDOS = :V0ENDO-NRENDOS AND OPERACAO >= 100 AND OPERACAO <= 199 END-EXEC. */

            var r1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1 = new R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
            };

            var executed_1 = R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1.Execute(r1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HISP_NUM_APOL, V0HISP_NUM_APOL);
                _.Move(executed_1.V0HISP_NRENDOS, V0HISP_NRENDOS);
                _.Move(executed_1.V0HISP_NRPARCEL, V0HISP_NRPARCEL);
                _.Move(executed_1.V0HISP_DACPARC, V0HISP_DACPARC);
                _.Move(executed_1.V0HISP_DTMOVTO, V0HISP_DTMOVTO);
                _.Move(executed_1.V0HISP_OPERACAO, V0HISP_OPERACAO);
                _.Move(executed_1.V0HISP_OCORHIST, V0HISP_OCORHIST);
                _.Move(executed_1.V0HISP_PRM_TARIFA, V0HISP_PRM_TARIFA);
                _.Move(executed_1.V0HISP_VAL_DESCON, V0HISP_VAL_DESCON);
                _.Move(executed_1.V0HISP_VLPRMLIQ, V0HISP_VLPRMLIQ);
                _.Move(executed_1.V0HISP_VLADIFRA, V0HISP_VLADIFRA);
                _.Move(executed_1.V0HISP_VLCUSEMI, V0HISP_VLCUSEMI);
                _.Move(executed_1.V0HISP_VLIOCC, V0HISP_VLIOCC);
                _.Move(executed_1.V0HISP_VLPRMTOT, V0HISP_VLPRMTOT);
                _.Move(executed_1.V0HISP_VLPREMIO, V0HISP_VLPREMIO);
                _.Move(executed_1.V0HISP_DTVENCTO, V0HISP_DTVENCTO);
                _.Move(executed_1.V0HISP_BCOCOBR, V0HISP_BCOCOBR);
                _.Move(executed_1.V0HISP_AGECOBR, V0HISP_AGECOBR);
                _.Move(executed_1.V0HISP_NRAVISO, V0HISP_NRAVISO);
                _.Move(executed_1.V0HISP_NRENDOCA, V0HISP_NRENDOCA);
                _.Move(executed_1.V0HISP_SITCONTB, V0HISP_SITCONTB);
                _.Move(executed_1.V0HISP_COD_USUAR, V0HISP_COD_USUAR);
                _.Move(executed_1.V0HISP_RNUDOC, V0HISP_RNUDOC);
                _.Move(executed_1.V0HISP_DTQITBCO, V0HISP_DTQITBCO);
                _.Move(executed_1.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(executed_1.V0HISP_COD_EMPRESA, V0HISP_COD_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-V0HISTOPARC-SECTION */
        private void R1400_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -851- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -853- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -854- MOVE 104 TO V0HISP-BCOCOBR. */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -855- MOVE 0 TO V0HISP-AGECOBR. */
            _.Move(0, V0HISP_AGECOBR);

            /*" -857- MOVE 0 TO V0HISP-NRAVISO. */
            _.Move(0, V0HISP_NRAVISO);

            /*" -860- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO, V0HISP-DTQITBCO. */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO, V0HISP_DTQITBCO);

            /*" -862- MOVE 0221 TO V0HISP-OPERACAO */
            _.Move(0221, V0HISP_OPERACAO);

            /*" -864- MOVE V0PARC-OCORHIST TO V0HISP-OCORHIST */
            _.Move(V0PARC_OCORHIST, V0HISP_OCORHIST);

            /*" -866- MOVE 'VA3139B' TO V0HISP-COD-USUAR */
            _.Move("VA3139B", V0HISP_COD_USUAR);

            /*" -866- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-SECTION */
        private void R1450_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -879- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -880- ADD V0HISP-VLPRMTOT TO WS-ACG-TOTDBEFET. */
            AREA_DE_WORK.WS_ACG_TOTDBEFET.Value = AREA_DE_WORK.WS_ACG_TOTDBEFET + V0HISP_VLPRMTOT;

            /*" -882- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO. */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -911- PERFORM R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -914- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -916- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -916- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -911- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R1550-00-ATUALIZA-V0PARCELA-SECTION */
        private void R1550_00_ATUALIZA_V0PARCELA_SECTION()
        {
            /*" -928- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -935- PERFORM R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1 */

            R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1();

            /*" -938- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -940- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -940- ADD 1 TO AC-U-V0PARCELA. */
            AREA_DE_WORK.AC_U_V0PARCELA.Value = AREA_DE_WORK.AC_U_V0PARCELA + 1;

        }

        [StopWatch]
        /*" R1550-00-ATUALIZA-V0PARCELA-DB-UPDATE-1 */
        public void R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1()
        {
            /*" -935- EXEC SQL UPDATE SEGUROS.V0PARCELA SET SITUACAO = '1' , OCORHIST = :V0PARC-OCORHIST WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND NRENDOS = :V0ENDO-NRENDOS AND SITUACAO = '0' END-EXEC. */

            var r1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1 = new R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1()
            {
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
            };

            R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1.Execute(r1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-ATUALIZA-V0ENDOSSO-SECTION */
        private void R1600_00_ATUALIZA_V0ENDOSSO_SECTION()
        {
            /*" -953- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -959- PERFORM R1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1 */

            R1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1();

            /*" -962- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -964- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -964- ADD 1 TO AC-U-V0ENDOSSO. */
            AREA_DE_WORK.AC_U_V0ENDOSSO.Value = AREA_DE_WORK.AC_U_V0ENDOSSO + 1;

        }

        [StopWatch]
        /*" R1600-00-ATUALIZA-V0ENDOSSO-DB-UPDATE-1 */
        public void R1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -959- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '1' WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND NRENDOS = :V0ENDO-NRENDOS AND SITUACAO = '0' END-EXEC. */

            var r1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1_Update1 = new R1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
            };

            R1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r1600_00_ATUALIZA_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -977- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -978- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -979- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -981- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -982- DISPLAY ' ' */
            _.Display($" ");

            /*" -983- DISPLAY 'LIDOS  V0ENDOSSO...........  ' AC-L-V0ENDOSSO. */
            _.Display($"LIDOS  V0ENDOSSO...........  {AREA_DE_WORK.AC_L_V0ENDOSSO}");

            /*" -984- DISPLAY ' ' */
            _.Display($" ");

            /*" -985- DISPLAY 'INSERT V0HISTOPARC.........  ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC.........  {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -986- DISPLAY ' ' */
            _.Display($" ");

            /*" -987- DISPLAY 'UPDATE V0ENDOSSO...........  ' AC-U-V0ENDOSSO. */
            _.Display($"UPDATE V0ENDOSSO...........  {AREA_DE_WORK.AC_U_V0ENDOSSO}");

            /*" -987- DISPLAY 'UPDATE V0PARCELA...........  ' AC-U-V0PARCELA. */
            _.Display($"UPDATE V0PARCELA...........  {AREA_DE_WORK.AC_U_V0PARCELA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-GERA-SOLICITACAO-SECTION */
        private void R4500_00_GERA_SOLICITACAO_SECTION()
        {
            /*" -999- MOVE 'VA3139B' TO V0RELA-CODUSU */
            _.Move("VA3139B", V0RELA_CODUSU);

            /*" -1000- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -1001- MOVE 'VA' TO V0RELA-IDSISTEM */
            _.Move("VA", V0RELA_IDSISTEM);

            /*" -1002- MOVE 'VA2417B' TO V0RELA-CODRELAT */
            _.Move("VA2417B", V0RELA_CODRELAT);

            /*" -1003- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -1004- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -1005- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -1007- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -1010- MOVE V0ENDO-DTVENCTO TO V0RELA-DATA-REFERENCIA */
            _.Move(V0ENDO_DTVENCTO, V0RELA_DATA_REFERENCIA);

            /*" -1011- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -1012- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -1013- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -1014- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -1015- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -1016- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -1017- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -1018- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -1019- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -1020- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -1021- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -1022- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -1023- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -1024- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -1025- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -1026- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -1027- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -1028- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -1029- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -1030- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -1031- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -1032- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -1033- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -1034- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -1035- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -1036- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -1037- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -1038- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -1039- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -1040- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -1042- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -1085- PERFORM R4500_00_GERA_SOLICITACAO_DB_INSERT_1 */

            R4500_00_GERA_SOLICITACAO_DB_INSERT_1();

            /*" -1088- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -1089- DISPLAY 'B0300-10 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B0300-10 (REGISTRO DUPLICADO) ... ");

                /*" -1091- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1093- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -1093- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4500-00-GERA-SOLICITACAO-DB-INSERT-1 */
        public void R4500_00_GERA_SOLICITACAO_DB_INSERT_1()
        {
            /*" -1085- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r4500_00_GERA_SOLICITACAO_DB_INSERT_1_Insert1 = new R4500_00_GERA_SOLICITACAO_DB_INSERT_1_Insert1()
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

            R4500_00_GERA_SOLICITACAO_DB_INSERT_1_Insert1.Execute(r4500_00_GERA_SOLICITACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1110- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1111- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1112- DISPLAY 'APOLICE.... ' V0ENDO-NUM-APOLICE */
            _.Display($"APOLICE.... {V0ENDO_NUM_APOLICE}");

            /*" -1113- DISPLAY 'ENDOSSO.... ' V0ENDO-NRENDOS */
            _.Display($"ENDOSSO.... {V0ENDO_NRENDOS}");

            /*" -1115- DISPLAY 'LIDOS       ' AC-L-V0ENDOSSO. */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_V0ENDOSSO}");

            /*" -1115- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1117- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1121- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1121- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}