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
using Sias.VidaAzul.DB2.VA2139B;

namespace Code
{
    public class VA2139B
    {
        public bool IsCall { get; set; }

        public VA2139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL PREF. VIDA ATIVOS CEF.     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA2139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  TERCIO/LUIZ CARLOS                 *      */
        /*"      *   PROGRAMADOR ............  TERCIO/LUIZ CARLOS                 *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/1999                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO HISTORICO DE           *      */
        /*"      *                             CONTABILIZACAO DE PARCELAS         *      */
        /*"      *                             (V0HISTCONTABILVA), GERA O ENDOSSO *      */
        /*"      *                             CORRESPONDENTE PARA REGISTRAR A    *      */
        /*"      *                             EMISSAO (ENDOSSOS QUE SERAO BAIXA- *      */
        /*"      *                             DOS AUTOMATICAMENTE POLO PROGRAMA  *      */
        /*"      *                             VA3139 NO MES SUBSEQUENTE)         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * HISTORICO CONTABIL DE PARCELAS VA   V0HISTCONTABILVA  I-O      *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           I-O      *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * COBERTURA APOLICES                  V0COBERAPOL       OUTPUT   *      */
        /*"      * NUMERACAO GERAL                     V0NUMERO_AES      I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSOES:                                                       *      */
        /*"      * EM 12/1999           POR LUIZ CARLOS       PROCURE POR LC1299  *      */
        /*"      * - PASSOU A GERAR A NUMERACAO DE COSSEGURO.                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 02 - CAD 10.003                                        *      */
        /*"      *                                                                *      */
        /*"      *             - CONVERSAO DO DB2 PARA A VERSAO 10                *      */
        /*"      *                                                                *      */
        /*"      *  EM 30/09/2013 -  ROGERIO PEREIRA                              *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.02     *      */
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
        /*"77              WHOST-NRAVISO         PIC S9(009)     COMP.*/
        public IntBasis WHOST_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         VIND-VALADT         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-CODEMP         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-ORIGAVISO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"01         WHOST-PRMTOTAL       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WHOST_PRMTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01         WHOST-PRMLIQ         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WHOST_PRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0ORDC-NUM-APOL                  PIC S9(013) VALUE +0 COMP-3*/
        public IntBasis V0ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0ORDC-NRENDOS                   PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0ORDC-CODCOSS                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0ORDC-ORDEM-CED                 PIC S9(015) VALUE +0 COMP-3*/
        public IntBasis V0ORDC_ORDEM_CED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  V0ORDC-COD-EMPRESA               PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0ORDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0ORDC-TIMESTAMP                 PIC  X(026).*/
        public StringBasis V0ORDC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
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
        /*"01         V1SIST-DTMOVABE-1M  PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_1M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01         V1NCOS-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-NRORDEM      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0SUBGR-DTTERVIG     PIC  X(010).*/
        public StringBasis V0SUBGR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01         V0PRVG-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PRVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         TABELA-ULTIMOS-DIAS.*/
        public VA2139B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA2139B_TABELA_ULTIMOS_DIAS();
        public class VA2139B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VA2139B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VA2139B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VA2139B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VA2139B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VA2139B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA2139B_TAB_DIA_MESES>(12);
            public class VA2139B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VA2139B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VA2139B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VA2139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA2139B_AREA_DE_WORK();
        public class VA2139B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VA2139B_WS_DTBASE WS_DTBASE { get; set; } = new VA2139B_WS_DTBASE();
            public class VA2139B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VA2139B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VA2139B_WS_DTBASE_AM();
                public class VA2139B_WS_DTBASE_AM : VarBasis
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
            public VA2139B_WS_DTFATUR WS_DTFATUR { get; set; } = new VA2139B_WS_DTFATUR();
            public class VA2139B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VA2139B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VA2139B_WS_DTFATUR_AM();
                public class VA2139B_WS_DTFATUR_AM : VarBasis
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
            private _REDEF_VA2139B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA2139B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA2139B_FILLER_5(); _.Move(WWORK_NUM_ORDEM, _filler_5); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_5, WWORK_NUM_ORDEM); _filler_5.ValueChanged += () => { _.Move(_filler_5, WWORK_NUM_ORDEM); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VA2139B_FILLER_5 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VA2139B_FILLER_5()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VA2139B_WWORK_DATA WWORK_DATA { get; set; } = new VA2139B_WWORK_DATA();
            public class VA2139B_WWORK_DATA : VarBasis
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
            public VA2139B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VA2139B_WDATA_SISTEMA();
            public class VA2139B_WDATA_SISTEMA : VarBasis
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
            public VA2139B_WS_DATE WS_DATE { get; set; } = new VA2139B_WS_DATE();
            public class VA2139B_WS_DATE : VarBasis
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
            public VA2139B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA2139B_WDATA_CABEC();
            public class VA2139B_WDATA_CABEC : VarBasis
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
            /*"  05         AC-I-V0AVISOS-SALDO     PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0AVISOS_SALDO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0AVISOCRED        PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_V0AVISOCRED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
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
            /*"  05         WS-NRAVISO              PIC  9(009)   VALUE  0.*/
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         FILLER                  REDEFINES     WS-NRAVISO.*/
            private _REDEF_VA2139B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA2139B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA2139B_FILLER_14(); _.Move(WS_NRAVISO, _filler_14); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_14, WS_NRAVISO); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_NRAVISO); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_VA2139B_FILLER_14 : VarBasis
            {
                /*"             10 WS-AGEAVISO          PIC  9(004).*/
                public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"             10 WS-NSAC              PIC  9(005).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05            WS-ACG-TOTDBEFET     PIC  9(013)V99 VALUE ZEROS.*/

                public _REDEF_VA2139B_FILLER_14()
                {
                    WS_AGEAVISO.ValueChanged += OnValueChanged;
                    WS_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_ACG_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05        WABEND.*/
            public VA2139B_WABEND WABEND { get; set; } = new VA2139B_WABEND();
            public class VA2139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA2139B '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA2139B ");
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


        public VA2139B_CHISTCTBL CHISTCTBL { get; set; } = new VA2139B_CHISTCTBL();
        public VA2139B_CPROPVA CPROPVA { get; set; } = new VA2139B_CPROPVA();
        public VA2139B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new VA2139B_V1APOLCOSCED();
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
            /*" -510- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -513- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -516- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -520- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -529- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -534- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -535- MOVE V1SIST-DTMOVABE TO WWORK-DATA. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WWORK_DATA);

            /*" -536- MOVE 01 TO WWORK-DIA. */
            _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -538- MOVE WWORK-DATA TO V0ENDO-DTINIVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTINIVIG);

            /*" -539- MOVE TAB-DIA-MES(WWORK-MES) TO WWORK-DIA. */
            _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WWORK_DATA.WWORK_MES].TAB_DIA_MES, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -541- MOVE WWORK-DATA TO V0ENDO-DTTERVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTTERVIG);

            /*" -543- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -545- MOVE V1SIST-DTMOVABE-1M TO WWORK-DATA. */
            _.Move(V1SIST_DTMOVABE_1M, AREA_DE_WORK.WWORK_DATA);

            /*" -546- MOVE TAB-DIA-MES(WWORK-MES) TO WWORK-DIA. */
            _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WWORK_DATA.WWORK_MES].TAB_DIA_MES, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -548- MOVE WWORK-DATA TO V0ENDO-DTVENCTO. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTVENCTO);

            /*" -550- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -555- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -558- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -560- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -561- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

            /*" -562- DISPLAY 'INICIO VIGENCIA  : ' V0ENDO-DTINIVIG. */
            _.Display($"INICIO VIGENCIA  : {V0ENDO_DTINIVIG}");

            /*" -563- DISPLAY 'TERMINO VIGENCIA : ' V0ENDO-DTTERVIG. */
            _.Display($"TERMINO VIGENCIA : {V0ENDO_DTTERVIG}");

            /*" -565- DISPLAY 'VENCIMENTO       : ' V0ENDO-DTVENCTO. */
            _.Display($"VENCIMENTO       : {V0ENDO_DTVENCTO}");

            /*" -597- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -601- DISPLAY 'VA2139B - ABRINDO CURSOR ...' . */
            _.Display($"VA2139B - ABRINDO CURSOR ...");

            /*" -602- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -602- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -607- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -609- DISPLAY 'PROCESSANDO . .......... ' . */
            _.Display($"PROCESSANDO . .......... ");

            /*" -611- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

            /*" -612- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
            {

                /*" -614- DISPLAY 'VA2139B - NENHUMA COBRANCA ENCONTRADA' */
                _.Display($"VA2139B - NENHUMA COBRANCA ENCONTRADA");

                /*" -616- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -619- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -621- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -622- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -622- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -625- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -627- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -627- PERFORM R4500-00-GERA-V0RELATORIOS. */

            R4500_00_GERA_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -529- EXEC SQL SELECT DTMOVABE, DTMOVABE + 1 MONTH, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTMOVABE-1M, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_1M, V1SIST_DTMOVABE_1M);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -633- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -634- DISPLAY ' ' . */
            _.Display($" ");

            /*" -636- DISPLAY '*--------  VA2139B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VA2139B - FIM NORMAL  --------*");

            /*" -636- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -597- EXEC SQL DECLARE CHISTCTBL CURSOR FOR SELECT A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.PRMVG, A.PRMAP, A.CODOPER, A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.OCOORHIST, C.ESTR_COBR FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOSVG C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.NRCERTIF = A.NRCERTIF AND A.SITUACAO IN ( '0' , '3' ) AND A.DTMOVTO <= :V1SIST-DTMOVABE AND A.DTFATUR IS NULL AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.CODSUBES AND C.DIA_FATURA = 31 AND C.ESTR_COBR IN ( 'MULT' , 'FEDERAL' ) AND C.ORIG_PRODU = ( 'CEF DEB CC' ) ORDER BY A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE END-EXEC. */
            CHISTCTBL = new VA2139B_CHISTCTBL(true);
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
							C.ESTR_COBR 
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
							AND C.ESTR_COBR IN ( 'MULT'
							, 'FEDERAL' ) 
							AND C.ORIG_PRODU = ( 'CEF DEB CC' ) 
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
            /*" -602- EXEC SQL OPEN CHISTCTBL END-EXEC. */

            CHISTCTBL.Open();

        }

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-DB-DECLARE-1 */
        public void R1200_00_ACUMULA_IS_DB_DECLARE_1()
        {
            /*" -1243- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NRCERTIF, CODPRODU, IDADE, OPCAO_COBER FROM SEGUROS.V0PROPOSTAVA WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND SITUACAO = '3' END-EXEC. */
            CPROPVA = new VA2139B_CPROPVA(true);
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
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -555- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

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
            /*" -648- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -661- PERFORM R0910_00_FETCH_HCTBVA_DB_FETCH_1 */

            R0910_00_FETCH_HCTBVA_DB_FETCH_1();

            /*" -664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -665- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -665- PERFORM R0910_00_FETCH_HCTBVA_DB_CLOSE_1 */

                    R0910_00_FETCH_HCTBVA_DB_CLOSE_1();

                    /*" -667- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -668- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -669- ELSE */
                }
                else
                {


                    /*" -671- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -673- ADD 1 TO AC-L-V0HISTCONT. */
            AREA_DE_WORK.AC_L_V0HISTCONT.Value = AREA_DE_WORK.AC_L_V0HISTCONT + 1;

            /*" -674- IF V0HCTB-FONTE EQUAL ZEROS */

            if (V0HCTB_FONTE == 00)
            {

                /*" -674- MOVE 5 TO V0HCTB-FONTE. */
                _.Move(5, V0HCTB_FONTE);
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_HCTBVA_DB_FETCH_1()
        {
            /*" -661- EXEC SQL FETCH CHISTCTBL INTO :V0HCTB-SITUACAO , :V0HCTB-NUM-APOLICE , :V0HCTB-CODSUBES , :V0HCTB-FONTE , :V0HCTB-PRMVG , :V0HCTB-PRMAP , :V0HCTB-CODOPER , :V0HCTB-NRCERTIF , :V0HCTB-NRPARCEL , :V0HCTB-NRTIT , :V0HCTB-OCORHIST , :V0PRVG-ESTR-COBR END-EXEC. */

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
                _.Move(CHISTCTBL.V0PRVG_ESTR_COBR, V0PRVG_ESTR_COBR);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-HCTBVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_HCTBVA_DB_CLOSE_1()
        {
            /*" -665- EXEC SQL CLOSE CHISTCTBL END-EXEC */

            CHISTCTBL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -685- MOVE V0HCTB-NUM-APOLICE TO WS-NUM-APOLICE-ANT V0ENDO-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0ENDO_NUM_APOLICE);

            /*" -687- MOVE V0HCTB-CODSUBES TO WS-CODSUBES-ANT V0ENDO-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0ENDO_CODSUBES);

            /*" -690- MOVE V0HCTB-FONTE TO WS-FONTE-ANT V0ENDO-FONTE. */
            _.Move(V0HCTB_FONTE, AREA_DE_WORK.WS_FONTE_ANT, V0ENDO_FONTE);

            /*" -692- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -699- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -704- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -706- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -713- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -717- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -719- DISPLAY '*** VA2139B - SOLICITAR PRORROGACAO DA APOLICE ' V0HCTB-NUM-APOLICE ' ' V0ENDO-DTINIVIG */

                    $"*** VA2139B - SOLICITAR PRORROGACAO DA APOLICE {V0HCTB_NUM_APOLICE} {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -720- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -721- ELSE */
                }
                else
                {


                    /*" -723- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -725- MOVE '1A03' TO WNR-EXEC-SQL. */
            _.Move("1A03", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -731- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -734- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -736- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -737- MOVE V0SUBGR-DTTERVIG TO WS-DTRENOVA. */
            _.Move(V0SUBGR_DTTERVIG, WS_DTRENOVA);

            /*" -738- MOVE V0ENDO-DTINIVIG TO WS-DTFATUR. */
            _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WS_DTFATUR);

            /*" -739- PERFORM R1103-00-CALCULA-DTINIVIG. */

            R1103_00_CALCULA_DTINIVIG_SECTION();

            /*" -740- PERFORM R1105-00-ACESSA-V1RAMOIND. */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -742- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1. */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -744- MOVE '1003' TO WNR-EXEC-SQL. */
            _.Move("1003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -754- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -757- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -759- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -761- MOVE '1005' TO WNR-EXEC-SQL. */
            _.Move("1005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -767- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -770- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -774- ADD 1 TO V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS + 1;

            /*" -776- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -781- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -784- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -786- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -788- ADD 1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + 1;

            /*" -795- MOVE +0 TO AC-PRMVG AC-PRMAP WS-VLIOCC-TOT WS-VLIOCC-TOT-AP WS-VLIOCC-TOT-VG WS-VLIOCC-TOT-DIT. */
            _.Move(+0, AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.WS_VLIOCC_TOT, AREA_DE_WORK.WS_VLIOCC_TOT_AP, AREA_DE_WORK.WS_VLIOCC_TOT_VG, AREA_DE_WORK.WS_VLIOCC_TOT_DIT);

            /*" -801- PERFORM R1100-00-ACUMULA-PREMIO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR V0HCTB-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR V0HCTB-FONTE NOT EQUAL WS-FONTE-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || V0HCTB_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || V0HCTB_FONTE != AREA_DE_WORK.WS_FONTE_ANT))
            {

                R1100_00_ACUMULA_PREMIO_SECTION();
            }

            /*" -803- IF V0APOL-RAMO EQUAL 93 AND AC-PRMVG NOT GREATER ZEROES */

            if (V0APOL_RAMO == 93 && AREA_DE_WORK.AC_PRMVG <= 00)
            {

                /*" -804- DISPLAY ' ' */
                _.Display($" ");

                /*" -805- DISPLAY 'PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ' */
                _.Display($"PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ");

                /*" -806- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -807- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -808- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -809- DISPLAY 'PREMIO VG ' AC-PRMVG */
                _.Display($"PREMIO VG {AREA_DE_WORK.AC_PRMVG}");

                /*" -810- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -811- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -813- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -815- IF V0APOL-RAMO EQUAL 81 AND AC-PRMAP NOT GREATER ZEROES */

            if (V0APOL_RAMO == 81 && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -816- DISPLAY ' ' */
                _.Display($" ");

                /*" -817- DISPLAY 'PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ' */
                _.Display($"PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO ");

                /*" -818- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -819- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -820- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -821- DISPLAY 'PREMIO AP ' AC-PRMAP */
                _.Display($"PREMIO AP {AREA_DE_WORK.AC_PRMAP}");

                /*" -822- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -823- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -825- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -826- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -828- IF AC-PRMVG NOT GREATER ZEROES OR AC-PRMAP NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_PRMVG <= 00 || AREA_DE_WORK.AC_PRMAP <= 00)
                {

                    /*" -829- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -830- DISPLAY 'PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO' */
                    _.Display($"PREMIO NEGATIVO/ZERADO - ENDOSSO NAO GERADO");

                    /*" -831- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -832- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -833- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -834- DISPLAY 'PREMIO VG ' AC-PRMVG */
                    _.Display($"PREMIO VG {AREA_DE_WORK.AC_PRMVG}");

                    /*" -835- DISPLAY 'PREMIO AP ' AC-PRMAP */
                    _.Display($"PREMIO AP {AREA_DE_WORK.AC_PRMAP}");

                    /*" -836- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -837- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -839- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -846- MOVE +0 TO AC-IMPMORNATU AC-IMPMORACID AC-IMPINVPERM AC-IMPAMDS AC-IMPDH AC-IMPDIT. */
            _.Move(+0, AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDIT);

            /*" -848- PERFORM R1200-00-ACUMULA-IS. */

            R1200_00_ACUMULA_IS_SECTION();

            /*" -849- IF V0APOL-RAMO EQUAL 93 OR 97 */

            if (V0APOL_RAMO.In("93", "97"))
            {

                /*" -850- IF AC-IMPMORNATU NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORNATU <= 00)
                {

                    /*" -851- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -852- DISPLAY 'IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ' */
                    _.Display($"IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ");

                    /*" -853- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -854- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -855- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -856- DISPLAY 'IS MN     ' AC-IMPMORNATU */
                    _.Display($"IS MN     {AREA_DE_WORK.AC_IMPMORNATU}");

                    /*" -857- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -858- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -860- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -861- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -862- COMPUTE AC-IMPMORACID = AC-IMPMORACID - AC-IMPMORNATU */
                AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID - AREA_DE_WORK.AC_IMPMORNATU;

                /*" -864- COMPUTE AC-IMPMORACID = AC-IMPMORACID - (AC-IMPMORNATU * V0COND-IEA / 100) */
                AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID - (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IEA / 100f);

                /*" -865- IF V0COND-IPA GREATER ZEROES */

                if (V0COND_IPA > 00)
                {

                    /*" -867- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM - (AC-IMPMORNATU * V0COND-IPA / 100) */
                    AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM - (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IPA / 100f);

                    /*" -868- ELSE */
                }
                else
                {


                    /*" -869- IF V0COND-IPD GREATER ZEROES */

                    if (V0COND_IPD > 00)
                    {

                        /*" -871- COMPUTE AC-IMPINVPERM = (AC-IMPMORNATU * V0COND-IPD / 100) */
                        AREA_DE_WORK.AC_IMPINVPERM.Value = (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IPD / 100f);

                        /*" -872- END-IF */
                    }


                    /*" -873- END-IF */
                }


                /*" -875- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -876- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -877- DISPLAY 'IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ' */
                    _.Display($"IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ");

                    /*" -878- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -879- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -880- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -881- DISPLAY 'IS MA     ' AC-IMPMORACID */
                    _.Display($"IS MA     {AREA_DE_WORK.AC_IMPMORACID}");

                    /*" -882- DISPLAY 'IS IP     ' AC-IMPINVPERM */
                    _.Display($"IS IP     {AREA_DE_WORK.AC_IMPINVPERM}");

                    /*" -883- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -884- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -886- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -887- IF V0APOL-RAMO EQUAL 81 */

            if (V0APOL_RAMO == 81)
            {

                /*" -889- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -890- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -891- DISPLAY 'IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ' */
                    _.Display($"IS NEGATIVA/ZERADA - ENDOSSO NAO GERADO ");

                    /*" -892- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                    _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                    /*" -893- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                    _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                    /*" -894- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                    _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                    /*" -895- DISPLAY 'IS MA     ' AC-IMPMORACID */
                    _.Display($"IS MA     {AREA_DE_WORK.AC_IMPMORACID}");

                    /*" -896- DISPLAY 'IS IP     ' AC-IMPINVPERM */
                    _.Display($"IS IP     {AREA_DE_WORK.AC_IMPINVPERM}");

                    /*" -897- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                    /*" -898- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -900- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -902- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -907- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -910- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -915- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -917- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -921- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2();

            /*" -924- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -926- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -928- ADD 1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + 1;

            /*" -930- PERFORM R1300-00-GRAVA-V0ENDOSSO. */

            R1300_00_GRAVA_V0ENDOSSO_SECTION();

            /*" -932- PERFORM R1320-00-GRAVA-COSSEGURO. */

            R1320_00_GRAVA_COSSEGURO_SECTION();

            /*" -934- PERFORM R1350-00-GRAVA-V0PARCELA. */

            R1350_00_GRAVA_V0PARCELA_SECTION();

            /*" -937- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -939- COMPUTE WHOST-PRMTOTAL = AC-PRMVG + AC-PRMAP */
            WHOST_PRMTOTAL.Value = AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMAP;

            /*" -942- COMPUTE WHOST-PRMLIQ ROUNDED = WHOST-PRMTOTAL - WS-VLIOCC-TOT. */
            WHOST_PRMLIQ.Value = WHOST_PRMTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -943- MOVE V0ENDO-NUM-APOLICE TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0COBA_NUM_APOL);

            /*" -944- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -945- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -946- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -947- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -948- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -950- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -951- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -952- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -954- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -955- IF V0APOL-RAMO = 81 OR 97 */

            if (V0APOL_RAMO.In("81", "97"))
            {

                /*" -956- MOVE 81 TO V0COBA-RAMOFR */
                _.Move(81, V0COBA_RAMOFR);

                /*" -957- MOVE 0 TO V0COBA-MODALIFR */
                _.Move(0, V0COBA_MODALIFR);

                /*" -958- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -959- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX);

                /*" -961- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMAP - WS-VLIOCC-TOT-AP */
                V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMAP - AREA_DE_WORK.WS_VLIOCC_TOT_AP;

                /*" -962- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_VR);

                /*" -963- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                /*" -965- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / WHOST-PRMLIQ) * 100 */
                V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / WHOST_PRMLIQ) * 100;

                /*" -967- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -968- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -969- COMPUTE AC-PRMAP = AC-PRMAP - AC-PRMDIT */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP - AREA_DE_WORK.AC_PRMDIT;

                /*" -971- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMAP - WS-VLIOCC-TOT-AP */
                V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMAP - AREA_DE_WORK.WS_VLIOCC_TOT_AP;

                /*" -972- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                /*" -974- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / WHOST-PRMLIQ) * 100 */
                V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / WHOST_PRMLIQ) * 100;

                /*" -976- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -977- IF AC-IMPINVPERM GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPINVPERM > 00)
                {

                    /*" -979- MOVE AC-IMPINVPERM TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPINVPERM, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -981- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -982- MOVE 2 TO V0COBA-COD-COBER */
                    _.Move(2, V0COBA_COD_COBER);

                    /*" -983- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -984- END-IF */
                }


                /*" -985- IF AC-IMPAMDS GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPAMDS > 00)
                {

                    /*" -987- MOVE AC-IMPAMDS TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPAMDS, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -989- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -990- MOVE 3 TO V0COBA-COD-COBER */
                    _.Move(3, V0COBA_COD_COBER);

                    /*" -991- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -992- END-IF */
                }


                /*" -993- IF AC-IMPDH GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDH > 00)
                {

                    /*" -995- MOVE AC-IMPDH TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDH, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -997- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -998- MOVE 4 TO V0COBA-COD-COBER */
                    _.Move(4, V0COBA_COD_COBER);

                    /*" -999- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -1000- END-IF */
                }


                /*" -1001- IF AC-IMPDIT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDIT > 00)
                {

                    /*" -1003- MOVE AC-IMPDIT TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDIT, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -1005- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMDIT - WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMDIT - AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -1006- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -1007- MOVE 5 TO V0COBA-COD-COBER */
                    _.Move(5, V0COBA_COD_COBER);

                    /*" -1009- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / WHOST-PRMLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / WHOST_PRMLIQ) * 100;

                    /*" -1011- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();
                }

            }


            /*" -1012- IF V0APOL-RAMO = 93 OR 97 */

            if (V0APOL_RAMO.In("93", "97"))
            {

                /*" -1013- MOVE 93 TO V0COBA-RAMOFR */
                _.Move(93, V0COBA_RAMOFR);

                /*" -1014- MOVE 0 TO V0COBA-MODALIFR */
                _.Move(0, V0COBA_MODALIFR);

                /*" -1015- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -1017- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMVG - WS-VLIOCC-TOT-VG */
                V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                /*" -1018- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                /*" -1020- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / WHOST-PRMLIQ) * 100 */
                V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / WHOST_PRMLIQ) * 100;

                /*" -1022- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -1023- MOVE 11 TO V0COBA-COD-COBER */
                _.Move(11, V0COBA_COD_COBER);

                /*" -1023- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                R1600_00_INSERT_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -699- EXEC SQL SELECT RAMO, CODPRODU INTO :V0APOL-RAMO, :V0APOL-CODPRODU FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(executed_1.V0APOL_CODPRODU, V0APOL_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -713- EXEC SQL SELECT CODSUBES INTO :WHOST-CODSUBES FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 AND DTTERVIG > :V0ENDO-DTINIVIG END-EXEC. */

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
            /*" -1037- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1048- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1();

            /*" -1052- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1054- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1056- MOVE '1051' TO WNR-EXEC-SQL. */
            _.Move("1051", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1067- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2();

            /*" -1071- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1073- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1075- SUBTRACT 1 FROM V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS - 1;

            /*" -1077- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1082- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3();

            /*" -1085- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1085- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-1 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1()
        {
            /*" -1048- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 WHERE SITUACAO = '0' AND NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTMOVTO <= :V1SIST-DTMOVABE AND CODOPER �= 1000 END-EXEC. */

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
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -731- EXEC SQL SELECT DTTERVIG INTO :V0SUBGR-DTTERVIG FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND COD_SUBGRUPO = :V0HCTB-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0HCTB_CODSUBES = V0HCTB_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBGR_DTTERVIG, V0SUBGR_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-2 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2()
        {
            /*" -1067- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 WHERE SITUACAO = '3' AND NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTMOVTO <= :V1SIST-DTMOVABE AND CODOPER �= 1000 END-EXEC. */

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
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -781- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = 10 AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-3 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3()
        {
            /*" -1082- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = 10 AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -754- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD INTO :V0COND-IEA, :V0COND-IPA, :V0COND-IPD FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND COD_SUBGRUPO = :V0ENDO-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COND_IEA, V0COND_IEA);
                _.Move(executed_1.V0COND_IPA, V0COND_IPA);
                _.Move(executed_1.V0COND_IPD, V0COND_IPD);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2()
        {
            /*" -921- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-SECTION */
        private void R1100_00_ACUMULA_PREMIO_SECTION()
        {
            /*" -1095- IF V0HCTB-CODOPER = 1000 */

            if (V0HCTB_CODOPER == 1000)
            {

                /*" -1097- GO TO R1100-00-NEXT. */

                R1100_00_NEXT(); //GOTO
                return;
            }


            /*" -1100- COMPUTE WS-PREMIO-LIQ ROUNDED = (V0HCTB-PRMVG + V0HCTB-PRMAP) / WS-IND-IOF */
            AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP) / AREA_DE_WORK.WS_IND_IOF;

            /*" -1104- COMPUTE WS-VLIOCC = V0HCTB-PRMVG + V0HCTB-PRMAP - WS-PREMIO-LIQ */
            AREA_DE_WORK.WS_VLIOCC.Value = V0HCTB_PRMVG + V0HCTB_PRMAP - AREA_DE_WORK.WS_PREMIO_LIQ;

            /*" -1106- COMPUTE WS-PRM-LIQ-AP ROUNDED = V0HCTB-PRMAP / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP / AREA_DE_WORK.WS_IND_IOF;

            /*" -1108- COMPUTE WS-VLIOCC-AP = V0HCTB-PRMAP - WS-PRM-LIQ-AP */
            AREA_DE_WORK.WS_VLIOCC_AP.Value = V0HCTB_PRMAP - AREA_DE_WORK.WS_PRM_LIQ_AP;

            /*" -1110- COMPUTE WS-PRM-LIQ-VG ROUNDED = V0HCTB-PRMVG / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG / AREA_DE_WORK.WS_IND_IOF;

            /*" -1113- COMPUTE WS-VLIOCC-VG = V0HCTB-PRMVG - WS-PRM-LIQ-VG */
            AREA_DE_WORK.WS_VLIOCC_VG.Value = V0HCTB_PRMVG - AREA_DE_WORK.WS_PRM_LIQ_VG;

            /*" -1115- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -1116- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT + WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT + AREA_DE_WORK.WS_VLIOCC;

                /*" -1117- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP + WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP + AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -1118- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG + WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -1119- COMPUTE AC-PRMVG = AC-PRMVG + V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG + V0HCTB_PRMVG;

                /*" -1120- COMPUTE AC-PRMAP = AC-PRMAP + V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP + V0HCTB_PRMAP;

                /*" -1121- ELSE */
            }
            else
            {


                /*" -1122- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT - WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT - AREA_DE_WORK.WS_VLIOCC;

                /*" -1123- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP - WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP - AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -1124- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -1125- COMPUTE AC-PRMVG = AC-PRMVG - V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - V0HCTB_PRMVG;

                /*" -1127- COMPUTE AC-PRMAP = AC-PRMAP - V0HCTB-PRMAP. */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP - V0HCTB_PRMAP;
            }


            /*" -1129- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1139- PERFORM R1100_00_ACUMULA_PREMIO_DB_UPDATE_1 */

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1();

            /*" -1142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1144- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1144- ADD +1 TO AC-U-V0HISTCONTABILVA. */
            AREA_DE_WORK.AC_U_V0HISTCONTABILVA.Value = AREA_DE_WORK.AC_U_V0HISTCONTABILVA + +1;

            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-UPDATE-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_UPDATE_1()
        {
            /*" -1139- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' , NRENDOS = :V0ENDO-NRENDOS, DTFATUR = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST END-EXEC. */

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
            /*" -767- EXEC SQL SELECT ENDOSCOB INTO :V0ENDO-NRENDOS FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = 10 AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
            }


        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -1148- PERFORM R0910-00-FETCH-HCTBVA. */

            R0910_00_FETCH_HCTBVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -907- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1103-00-CALCULA-DTINIVIG-SECTION */
        private void R1103_00_CALCULA_DTINIVIG_SECTION()
        {
            /*" -1156- MOVE WS-DTRENOVA TO WS-DTBASE */
            _.Move(WS_DTRENOVA, AREA_DE_WORK.WS_DTBASE);

            /*" -1158- MOVE 01 TO WS-DIA. */
            _.Move(01, AREA_DE_WORK.WS_DIA);

            /*" -1159- IF WS-DTFATUR GREATER WS-DTBASE */

            if (AREA_DE_WORK.WS_DTFATUR > AREA_DE_WORK.WS_DTBASE)
            {

                /*" -1159- GO TO R1103-99-SAIDA. */
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
            /*" -1164- COMPUTE WS-AABASE = WS-AABASE - 1 */
            AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE - 1;

            /*" -1166- COMPUTE WS-DDBASE = WS-DDBASE + WS-DIA */
            AREA_DE_WORK.WS_DTBASE.WS_DDBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DDBASE + AREA_DE_WORK.WS_DIA;

            /*" -1168- IF WS-MMBASE EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -1169- IF WS-DDBASE GREATER 31 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 31)
                {

                    /*" -1170- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1171- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1172- END-IF */
                }


                /*" -1174- END-IF */
            }


            /*" -1175- IF WS-MMBASE EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("04", "06", "09", "11"))
            {

                /*" -1176- IF WS-DDBASE GREATER 30 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 30)
                {

                    /*" -1177- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1178- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1179- END-IF */
                }


                /*" -1181- END-IF */
            }


            /*" -1182- IF WS-MMBASE EQUAL 02 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE == 02)
            {

                /*" -1183- IF WS-DDBASE GREATER 28 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 28)
                {

                    /*" -1184- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1185- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1186- END-IF */
                }


                /*" -1188- END-IF */
            }


            /*" -1189- IF WS-MMBASE GREATER 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE > 12)
            {

                /*" -1190- MOVE 01 TO WS-MMBASE */
                _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE);

                /*" -1191- COMPUTE WS-AABASE = WS-AABASE + 1 */
                AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE + 1;

                /*" -1193- END-IF */
            }


            /*" -1194- IF WS-DTFATUR-AM LESS WS-DTBASE-AM */

            if (AREA_DE_WORK.WS_DTFATUR.WS_DTFATUR_AM < AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM)
            {

                /*" -1195- IF WS-DTBASE NOT GREATER V0SUBGR-DTTERVIG */

                if (AREA_DE_WORK.WS_DTBASE <= V0SUBGR_DTTERVIG)
                {

                    /*" -1196- MOVE V0SUBGR-DTTERVIG TO WS-DTBASE */
                    _.Move(V0SUBGR_DTTERVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -1197- ELSE */
                }
                else
                {


                    /*" -1198- MOVE ZEROS TO WS-DIA */
                    _.Move(0, AREA_DE_WORK.WS_DIA);

                    /*" -1198- GO TO R1103-10-DIMINUI-UM-ANO. */
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
            /*" -1209- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1210- MOVE V0APOL-RAMO TO V1RIND-RAMO */
            _.Move(V0APOL_RAMO, V1RIND_RAMO);

            /*" -1212- MOVE WS-DTBASE TO V1RIND-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DTBASE, V1RIND_DTINIVIG);

            /*" -1219- PERFORM R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1 */

            R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();

            /*" -1222- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1223- DISPLAY 'PROBLEMA NO ACESSAO V1RAMOIND' */
                _.Display($"PROBLEMA NO ACESSAO V1RAMOIND");

                /*" -1223- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-DB-SELECT-1 */
        public void R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1()
        {
            /*" -1219- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1RIND-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

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
            /*" -1243- PERFORM R1200_00_ACUMULA_IS_DB_DECLARE_1 */

            R1200_00_ACUMULA_IS_DB_DECLARE_1();

            /*" -1247- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1247- PERFORM R1200_00_ACUMULA_IS_DB_OPEN_1 */

            R1200_00_ACUMULA_IS_DB_OPEN_1();

            /*" -1249- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1251- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1252- MOVE 0 TO WFIM-V0PROPOSTAVA. */
            _.Move(0, AREA_DE_WORK.WFIM_V0PROPOSTAVA);

            /*" -1254- PERFORM R1290-00-FETCH. */

            R1290_00_FETCH_SECTION();

            /*" -1257- PERFORM R1210-00-ACUMULA-IS UNTIL WFIM-V0PROPOSTAVA = 1. */

            while (!(AREA_DE_WORK.WFIM_V0PROPOSTAVA == 1))
            {

                R1210_00_ACUMULA_IS_SECTION();
            }

            /*" -1259- MOVE '1205' TO WNR-EXEC-SQL. */
            _.Move("1205", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1259- PERFORM R1200_00_ACUMULA_IS_DB_CLOSE_1 */

            R1200_00_ACUMULA_IS_DB_CLOSE_1();

            /*" -1261- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1261- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-DB-OPEN-1 */
        public void R1200_00_ACUMULA_IS_DB_OPEN_1()
        {
            /*" -1247- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R1320-00-GRAVA-COSSEGURO-DB-DECLARE-1 */
        public void R1320_00_GRAVA_COSSEGURO_DB_DECLARE_1()
        {
            /*" -1575- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT DISTINCT CODCOSS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND DTINIVIG <= :V0ENDO-DTEMIS AND DTTERVIG >= :V0ENDO-DTEMIS ORDER BY CODCOSS END-EXEC. */
            V1APOLCOSCED = new VA2139B_V1APOLCOSCED(true);
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
            /*" -1259- EXEC SQL CLOSE CPROPVA END-EXEC. */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-SECTION */
        private void R1210_00_ACUMULA_IS_SECTION()
        {
            /*" -1272- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1289- PERFORM R1210_00_ACUMULA_IS_DB_SELECT_1 */

            R1210_00_ACUMULA_IS_DB_SELECT_1();

            /*" -1292- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1294- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1295- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1297- GO TO R1210-00-NEXT. */

                R1210_00_NEXT(); //GOTO
                return;
            }


            /*" -1298- COMPUTE AC-IMPMORNATU = AC-IMPMORNATU + V0CBPR-IMPMORNATU. */
            AREA_DE_WORK.AC_IMPMORNATU.Value = AREA_DE_WORK.AC_IMPMORNATU + V0CBPR_IMPMORNATU;

            /*" -1299- COMPUTE AC-IMPMORACID = AC-IMPMORACID + V0CBPR-IMPMORACID. */
            AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID + V0CBPR_IMPMORACID;

            /*" -1300- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM + V0CBPR-IMPINVPERM. */
            AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM + V0CBPR_IMPINVPERM;

            /*" -1301- COMPUTE AC-IMPAMDS = AC-IMPAMDS + V0CBPR-IMPAMDS. */
            AREA_DE_WORK.AC_IMPAMDS.Value = AREA_DE_WORK.AC_IMPAMDS + V0CBPR_IMPAMDS;

            /*" -1302- COMPUTE AC-IMPDH = AC-IMPDH + V0CBPR-IMPDH. */
            AREA_DE_WORK.AC_IMPDH.Value = AREA_DE_WORK.AC_IMPDH + V0CBPR_IMPDH;

            /*" -1304- COMPUTE AC-IMPDIT = AC-IMPDIT + V0CBPR-IMPDIT. */
            AREA_DE_WORK.AC_IMPDIT.Value = AREA_DE_WORK.AC_IMPDIT + V0CBPR_IMPDIT;

            /*" -1305- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

            if (V0CBPR_IMPDIT != 00)
            {

                /*" -1305- PERFORM R1220-00-LE-PREMIO-DIT. */

                R1220_00_LE_PREMIO_DIT_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1210_00_NEXT */

            R1210_00_NEXT();

        }

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-DB-SELECT-1 */
        public void R1210_00_ACUMULA_IS_DB_SELECT_1()
        {
            /*" -1289- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT INTO :V0CBPR-IMPMORNATU, :V0CBPR-IMPMORACID, :V0CBPR-IMPINVPERM, :V0CBPR-IMPAMDS, :V0CBPR-IMPDH, :V0CBPR-IMPDIT FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG END-EXEC. */

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
            /*" -1309- PERFORM R1290-00-FETCH. */

            R1290_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-SECTION */
        private void R1220_00_LE_PREMIO_DIT_SECTION()
        {
            /*" -1320- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1333- PERFORM R1220_00_LE_PREMIO_DIT_DB_SELECT_1 */

            R1220_00_LE_PREMIO_DIT_DB_SELECT_1();

            /*" -1336- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1337- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1338- MOVE '1221' TO WNR-EXEC-SQL */
                    _.Move("1221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1350- PERFORM R1220_00_LE_PREMIO_DIT_DB_SELECT_2 */

                    R1220_00_LE_PREMIO_DIT_DB_SELECT_2();

                    /*" -1352- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1353- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                        _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                        /*" -1354- DISPLAY 'V0PROP-IDADE    ' V0PROP-IDADE */
                        _.Display($"V0PROP-IDADE    {V0PROP_IDADE}");

                        /*" -1355- DISPLAY 'V0PROP-CODPRODU ' V0PROP-CODPRODU */
                        _.Display($"V0PROP-CODPRODU {V0PROP_CODPRODU}");

                        /*" -1356- DISPLAY 'V0ENDO-DTTERVIG ' V0ENDO-DTTERVIG */
                        _.Display($"V0ENDO-DTTERVIG {V0ENDO_DTTERVIG}");

                        /*" -1357- DISPLAY 'V0ENDO-IMPDIT   ' V0CBPR-IMPDIT */
                        _.Display($"V0ENDO-IMPDIT   {V0CBPR_IMPDIT}");

                        /*" -1358- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1360- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1361- ELSE */
                    }

                }
                else
                {


                    /*" -1363- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1364- IF V0PRVG-ESTR-COBR EQUAL 'MULT' */

            if (V0PRVG_ESTR_COBR == "MULT")
            {

                /*" -1366- MOVE V0PLAN-PRMAP TO V0PLAN-PRMDIT. */
                _.Move(V0PLAN_PRMAP, V0PLAN_PRMDIT);
            }


            /*" -1368- COMPUTE WS-PRM-LIQ-DIT ROUNDED = V0PLAN-PRMDIT / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_DIT.Value = V0PLAN_PRMDIT / AREA_DE_WORK.WS_IND_IOF;

            /*" -1371- COMPUTE WS-VLIOCC-DIT = V0PLAN-PRMDIT - WS-PRM-LIQ-DIT */
            AREA_DE_WORK.WS_VLIOCC_DIT.Value = V0PLAN_PRMDIT - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -1372- ADD V0PLAN-PRMDIT TO AC-PRMDIT. */
            AREA_DE_WORK.AC_PRMDIT.Value = AREA_DE_WORK.AC_PRMDIT + V0PLAN_PRMDIT;

            /*" -1373- COMPUTE WS-VLIOCC-TOT-DIT = WS-VLIOCC-TOT-DIT + WS-VLIOCC-DIT. */
            AREA_DE_WORK.WS_VLIOCC_TOT_DIT.Value = AREA_DE_WORK.WS_VLIOCC_TOT_DIT + AREA_DE_WORK.WS_VLIOCC_DIT;

        }

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-DB-SELECT-1 */
        public void R1220_00_LE_PREMIO_DIT_DB_SELECT_1()
        {
            /*" -1333- EXEC SQL SELECT PRMAP, PRMDIT INTO :V0PLAN-PRMAP, :V0PLAN-PRMDIT:V0PLAN-IPRMDIT FROM SEGUROS.V0PLANOSVA WHERE CODPRODU = :V0PROP-CODPRODU AND IDADE_INICIAL <= :V0PROP-IDADE AND IDADE_FINAL >= :V0PROP-IDADE AND OPCAO_COBER = :V0PROP-OPCAO-COBER AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG AND IMPDIT = :V0CBPR-IMPDIT END-EXEC. */

            var r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 = new R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1()
            {
                V0PROP_OPCAO_COBER = V0PROP_OPCAO_COBER.ToString(),
                V0PROP_CODPRODU = V0PROP_CODPRODU.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0CBPR_IMPDIT = V0CBPR_IMPDIT.ToString(),
                V0PROP_IDADE = V0PROP_IDADE.ToString(),
            };

            var executed_1 = R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1.Execute(r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PLAN_PRMAP, V0PLAN_PRMAP);
                _.Move(executed_1.V0PLAN_PRMDIT, V0PLAN_PRMDIT);
                _.Move(executed_1.V0PLAN_IPRMDIT, V0PLAN_IPRMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-DB-SELECT-2 */
        public void R1220_00_LE_PREMIO_DIT_DB_SELECT_2()
        {
            /*" -1350- EXEC SQL SELECT PRMAP, PRMDIT INTO :V0PLAN-PRMAP, :V0PLAN-PRMDIT:V0PLAN-IPRMDIT FROM SEGUROS.V0PLANOSVA WHERE CODPRODU = :V0PROP-CODPRODU AND IDADE_INICIAL <= :V0PROP-IDADE AND IDADE_FINAL >= :V0PROP-IDADE AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG AND IMPDIT = :V0CBPR-IMPDIT END-EXEC */

            var r1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1 = new R1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1()
            {
                V0PROP_CODPRODU = V0PROP_CODPRODU.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0CBPR_IMPDIT = V0CBPR_IMPDIT.ToString(),
                V0PROP_IDADE = V0PROP_IDADE.ToString(),
            };

            var executed_1 = R1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1.Execute(r1220_00_LE_PREMIO_DIT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PLAN_PRMAP, V0PLAN_PRMAP);
                _.Move(executed_1.V0PLAN_PRMDIT, V0PLAN_PRMDIT);
                _.Move(executed_1.V0PLAN_IPRMDIT, V0PLAN_IPRMDIT);
            }


        }

        [StopWatch]
        /*" R1290-00-FETCH-SECTION */
        private void R1290_00_FETCH_SECTION()
        {
            /*" -1384- MOVE '1290' TO WNR-EXEC-SQL. */
            _.Move("1290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1390- PERFORM R1290_00_FETCH_DB_FETCH_1 */

            R1290_00_FETCH_DB_FETCH_1();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1395- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1396- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1396- MOVE 1 TO WFIM-V0PROPOSTAVA. */
                _.Move(1, AREA_DE_WORK.WFIM_V0PROPOSTAVA);
            }


        }

        [StopWatch]
        /*" R1290-00-FETCH-DB-FETCH-1 */
        public void R1290_00_FETCH_DB_FETCH_1()
        {
            /*" -1390- EXEC SQL FETCH CPROPVA INTO :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-IDADE, :V0PROP-OPCAO-COBER END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVA.V0PROP_IDADE, V0PROP_IDADE);
                _.Move(CPROPVA.V0PROP_OPCAO_COBER, V0PROP_OPCAO_COBER);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1290_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-V0ENDOSSO-SECTION */
        private void R1300_00_GRAVA_V0ENDOSSO_SECTION()
        {
            /*" -1408- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1409- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -1410- MOVE V1SIST-DTMOVABE TO V0ENDO-DATPRO. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DATPRO);

            /*" -1411- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -1413- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -1417- MOVE 0 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR V0ENDO-AGERCAP V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_BCORCAP, V0ENDO_BCOCOBR, V0ENDO_AGERCAP, V0ENDO_AGECOBR);

            /*" -1419- MOVE '0' TO V0ENDO-DACCOBR. */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -1421- MOVE 0 TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);

            /*" -1422- MOVE ' ' TO V0ENDO-DACRCAP. */
            _.Move(" ", V0ENDO_DACRCAP);

            /*" -1423- MOVE ' ' TO V0ENDO-IDRCAP. */
            _.Move(" ", V0ENDO_IDRCAP);

            /*" -1424- MOVE SPACES TO V0ENDO-DATARCAP */
            _.Move("", V0ENDO_DATARCAP);

            /*" -1426- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -1427- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -1428- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -1429- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -1430- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -1431- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -1432- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -1433- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -1434- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -1436- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -1439- MOVE 1 TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(1, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -1440- MOVE '1' TO V0ENDO-TIPO-ENDO. */
            _.Move("1", V0ENDO_TIPO_ENDO);

            /*" -1442- MOVE 'VA2139B' TO V0ENDO-COD-USUAR. */
            _.Move("VA2139B", V0ENDO_COD_USUAR);

            /*" -1444- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -1446- MOVE '0' TO V0ENDO-SITUACAO. */
            _.Move("0", V0ENDO_SITUACAO);

            /*" -1447- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -1448- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -1449- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -1451- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -1452- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -1453- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -1461- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -1551- PERFORM R1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1 */

            R1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1();

            /*" -1554- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1556- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1556- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

        }

        [StopWatch]
        /*" R1300-00-GRAVA-V0ENDOSSO-DB-INSERT-1 */
        public void R1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1()
        {
            /*" -1551- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOLICE, :V0ENDO-NRENDOS, :V0ENDO-CODSUBES, :V0ENDO-FONTE, :V0ENDO-NRPROPOS, :V0ENDO-DATPRO, :V0ENDO-DT-LIBER, :V0ENDO-DTEMIS, :V0ENDO-NRRCAP, :V0ENDO-VLRCAP, :V0ENDO-BCORCAP, :V0ENDO-AGERCAP, :V0ENDO-DACRCAP, :V0ENDO-IDRCAP, :V0ENDO-BCOCOBR, :V0ENDO-AGECOBR, :V0ENDO-DACCOBR, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-CDFRACIO, :V0ENDO-PCENTRAD, :V0ENDO-PCADICIO, :V0ENDO-PRESTA1, :V0ENDO-QTPARCEL, :V0ENDO-QTPRESTA, :V0ENDO-QTITENS, :V0ENDO-CODTXT, :V0ENDO-CDACEITA, :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO, :V0ENDO-DATARCAP:VIND-DATARCAP, :V0ENDO-COD-EMPRESA, :V0ENDO-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI:VIND-VLCUSEMI, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

            var r1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1_Insert1 = new R1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1_Insert1()
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
                V0ENDO_CFPREFIX = V0ENDO_CFPREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                V0ENDO_VLCUSEMI = V0ENDO_VLCUSEMI.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1_Insert1.Execute(r1300_00_GRAVA_V0ENDOSSO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-GRAVA-COSSEGURO-SECTION */
        private void R1320_00_GRAVA_COSSEGURO_SECTION()
        {
            /*" -1575- PERFORM R1320_00_GRAVA_COSSEGURO_DB_DECLARE_1 */

            R1320_00_GRAVA_COSSEGURO_DB_DECLARE_1();

            /*" -1578- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1578- PERFORM R1320_00_GRAVA_COSSEGURO_DB_OPEN_1 */

            R1320_00_GRAVA_COSSEGURO_DB_OPEN_1();

            /*" -1581- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1581- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1320_10_FETCH_V1APOLCOSCED */

            R1320_10_FETCH_V1APOLCOSCED();

        }

        [StopWatch]
        /*" R1320-00-GRAVA-COSSEGURO-DB-OPEN-1 */
        public void R1320_00_GRAVA_COSSEGURO_DB_OPEN_1()
        {
            /*" -1578- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1320-10-FETCH-V1APOLCOSCED */
        private void R1320_10_FETCH_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -1589- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1591- PERFORM R1320_10_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R1320_10_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -1594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1595- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1595- PERFORM R1320_10_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R1320_10_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -1597- GO TO R1320-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/ //GOTO
                    return;

                    /*" -1598- ELSE */
                }
                else
                {


                    /*" -1601- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1603- MOVE '1303' TO WNR-EXEC-SQL. */
            _.Move("1303", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1604- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -1605- MOVE V0ENDO-NUM-APOLICE TO V0ORDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0ORDC_NUM_APOL);

            /*" -1606- MOVE V0ENDO-NRENDOS TO V0ORDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0ORDC_NRENDOS);

            /*" -1608- MOVE V1COSP-CONGENER TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V1COSP_CONGENER, V0ORDC_CODCOSS);
            _.Move(V1COSP_CONGENER, AREA_DE_WORK.FILLER_5.WWORK_ORD_CONGE);


            /*" -1610- MOVE 10 TO WWORK-ORD-ORGAO. */
            _.Move(10, AREA_DE_WORK.FILLER_5.WWORK_ORD_ORGAO);

            /*" -1611- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -1613- MOVE 10 TO V1NCOS-ORGAO. */
            _.Move(10, V1NCOS_ORGAO);

            /*" -1619- PERFORM R1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1 */

            R1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1();

            /*" -1622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1626- MOVE '2288' TO WNR-EXEC-SQL. */
            _.Move("2288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1628- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -1630- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_5.WWORK_ORD_SEQUE);

            /*" -1632- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -1640- PERFORM R1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1 */

            R1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1();

            /*" -1644- ADD 1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + 1;

            /*" -1645- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1647- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1649- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -1651- MOVE '1304' TO WNR-EXEC-SQL. */
            _.Move("1304", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1652- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -1654- MOVE 10 TO V1NCOS-ORGAO. */
            _.Move(10, V1NCOS_ORGAO);

            /*" -1660- PERFORM R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1 */

            R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1();

            /*" -1663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1665- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1667- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

            /*" -1667- GO TO R1320-10-FETCH-V1APOLCOSCED. */
            new Task(() => R1320_10_FETCH_V1APOLCOSCED()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1320-10-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R1320_10_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -1591- EXEC SQL FETCH V1APOLCOSCED INTO :V1COSP-CONGENER END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1COSP_CONGENER, V1COSP_CONGENER);
            }

        }

        [StopWatch]
        /*" R1320-10-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1320_10_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -1595- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }

        [StopWatch]
        /*" R1320-10-FETCH-V1APOLCOSCED-DB-SELECT-1 */
        public void R1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -1619- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1 = new R1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1()
            {
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            var executed_1 = R1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1.Execute(r1320_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NCOS_NRORDEM, V1NCOS_NRORDEM);
            }


        }

        [StopWatch]
        /*" R1320-10-FETCH-V1APOLCOSCED-DB-INSERT-1 */
        public void R1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1()
        {
            /*" -1640- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1 = new R1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0ORDC_NUM_APOL = V0ORDC_NUM_APOL.ToString(),
                V0ORDC_NRENDOS = V0ORDC_NRENDOS.ToString(),
                V0ORDC_CODCOSS = V0ORDC_CODCOSS.ToString(),
                V0ORDC_ORDEM_CED = V0ORDC_ORDEM_CED.ToString(),
                V0ORDC_COD_EMPRESA = V0ORDC_COD_EMPRESA.ToString(),
            };

            R1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1320_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1320-10-FETCH-V1APOLCOSCED-DB-UPDATE-1 */
        public void R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1()
        {
            /*" -1660- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 = new R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1()
            {
                V1NCOS_NRORDEM = V1NCOS_NRORDEM.ToString(),
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1.Execute(r1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-GRAVA-V0PARCELA-SECTION */
        private void R1350_00_GRAVA_V0PARCELA_SECTION()
        {
            /*" -1679- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1680- MOVE V0ENDO-NUM-APOLICE TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0PARC_NUM_APOL);

            /*" -1681- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -1683- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -1684- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -1685- MOVE V0ENDO-FONTE TO V0PARC-FONTE */
            _.Move(V0ENDO_FONTE, V0PARC_FONTE);

            /*" -1686- MOVE 0 TO V0PARC-NRTIT */
            _.Move(0, V0PARC_NRTIT);

            /*" -1687- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -1688- COMPUTE V0PARC-OTNTOTAL = AC-PRMVG + AC-PRMAP */
            V0PARC_OTNTOTAL.Value = AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMAP;

            /*" -1689- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -1691- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -1694- COMPUTE V0PARC-OTNPRLIQ ROUNDED = V0PARC-OTNTOTAL - WS-VLIOCC-TOT */
            V0PARC_OTNPRLIQ.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -1696- MOVE V0PARC-OTNPRLIQ TO V0PARC-PRM-TAR-IX. */
            _.Move(V0PARC_OTNPRLIQ, V0PARC_PRM_TAR_IX);

            /*" -1698- MOVE WS-VLIOCC-TOT TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VLIOCC_TOT, V0PARC_OTNIOF);

            /*" -1699- MOVE 1 TO V0PARC-OCORHIST */
            _.Move(1, V0PARC_OCORHIST);

            /*" -1700- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -1701- MOVE '0' TO V0PARC-SITUACAO */
            _.Move("0", V0PARC_SITUACAO);

            /*" -1704- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -1725- PERFORM R1350_00_GRAVA_V0PARCELA_DB_INSERT_1 */

            R1350_00_GRAVA_V0PARCELA_DB_INSERT_1();

            /*" -1728- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1730- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1730- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

        }

        [StopWatch]
        /*" R1350-00-GRAVA-V0PARCELA-DB-INSERT-1 */
        public void R1350_00_GRAVA_V0PARCELA_DB_INSERT_1()
        {
            /*" -1725- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1 = new R1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1()
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

            R1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1.Execute(r1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-V0HISTOPARC-SECTION */
        private void R1400_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -1744- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1745- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -1747- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -1748- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -1749- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -1750- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -1752- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -1754- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -1755- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -1756- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -1757- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -1758- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -1759- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -1760- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -1762- COMPUTE V0HISP-VLIOCC = V0HISP-VLPRMTOT - V0HISP-VLPRMLIQ */
            V0HISP_VLIOCC.Value = V0HISP_VLPRMTOT - V0HISP_VLPRMLIQ;

            /*" -1764- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -1766- MOVE V0ENDO-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DTVENCTO, V0HISP_DTVENCTO);

            /*" -1767- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -1768- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -1769- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -1770- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -1771- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -1772- MOVE 'VA2139B' TO V0HISP-COD-USUAR */
            _.Move("VA2139B", V0HISP_COD_USUAR);

            /*" -1774- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -1776- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1777- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -1779- ADD V0HISP-VLPRMTOT TO WS-ACG-TOTDBEFET */
            AREA_DE_WORK.WS_ACG_TOTDBEFET.Value = AREA_DE_WORK.WS_ACG_TOTDBEFET + V0HISP_VLPRMTOT;

            /*" -1808- PERFORM R1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1 */

            R1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1();

            /*" -1811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1813- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1400-00-GRAVA-V0HISTOPARC-DB-INSERT-1 */
        public void R1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -1808- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1_Insert1 = new R1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1_Insert1()
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

            R1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r1400_00_GRAVA_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-SECTION */
        private void R1600_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -1827- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1847- PERFORM R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -1850- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1852- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1852- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -1847- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

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
            /*" -1864- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -1865- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1866- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1868- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1869- DISPLAY 'LIDOS  V0HISTCONTABILVA   ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS  V0HISTCONTABILVA   {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -1870- DISPLAY 'INSERT V0ENDOSSO          ' AC-I-V0ENDOSSO. */
            _.Display($"INSERT V0ENDOSSO          {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -1871- DISPLAY 'INSERT V0COBERAPOL        ' AC-I-V0COBERAPOL. */
            _.Display($"INSERT V0COBERAPOL        {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -1872- DISPLAY 'INSERT V0HISTOPARC        ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC        {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -1873- DISPLAY 'INSERT V0PARCELA          ' AC-I-V0PARCELA. */
            _.Display($"INSERT V0PARCELA          {AREA_DE_WORK.AC_I_V0PARCELA}");

            /*" -1875- DISPLAY 'INSERT V0ORDECOSCED       ' AC-I-V0ORDECOSCED */
            _.Display($"INSERT V0ORDECOSCED       {AREA_DE_WORK.AC_I_V0ORDECOSCED}");

            /*" -1876- DISPLAY 'UPDATE V0NUMEROAES        ' AC-U-V0NUMERAES. */
            _.Display($"UPDATE V0NUMEROAES        {AREA_DE_WORK.AC_U_V0NUMERAES}");

            /*" -1877- DISPLAY 'UPDATE V0FONTE            ' AC-U-V0FONTE. */
            _.Display($"UPDATE V0FONTE            {AREA_DE_WORK.AC_U_V0FONTE}");

            /*" -1878- DISPLAY 'UPDATE V0HISTCONTABILVA   ' AC-U-V0HISTCONTABILVA. */
            _.Display($"UPDATE V0HISTCONTABILVA   {AREA_DE_WORK.AC_U_V0HISTCONTABILVA}");

            /*" -1878- DISPLAY 'UPDATE V0NUMERO-COSSEGURO ' AC-U-V0NUMERO-COSSEGURO. */
            _.Display($"UPDATE V0NUMERO-COSSEGURO {AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-GERA-V0RELATORIOS-SECTION */
        private void R4500_00_GERA_V0RELATORIOS_SECTION()
        {
            /*" -1886- MOVE 'VA2139B' TO V0RELA-CODUSU */
            _.Move("VA2139B", V0RELA_CODUSU);

            /*" -1887- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -1888- MOVE 'VA' TO V0RELA-IDSISTEM */
            _.Move("VA", V0RELA_IDSISTEM);

            /*" -1889- MOVE 'VA3139B' TO V0RELA-CODRELAT */
            _.Move("VA3139B", V0RELA_CODRELAT);

            /*" -1890- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -1891- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -1892- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -1893- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -1894- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -1895- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -1896- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -1897- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -1898- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -1899- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -1900- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -1901- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -1902- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -1903- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -1904- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -1905- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -1906- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -1907- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -1908- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -1909- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -1910- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -1911- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -1912- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -1913- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -1914- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -1915- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -1916- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -1917- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -1918- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -1919- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -1920- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -1921- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -1922- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -1923- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -1924- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -1926- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -1929- PERFORM R4600-00-INSERT-V0RELATORIOS. */

            R4600_00_INSERT_V0RELATORIOS_SECTION();

            /*" -1931- MOVE 'VA2417B' TO V0RELA-CODRELAT */
            _.Move("VA2417B", V0RELA_CODRELAT);

            /*" -1933- MOVE '1' TO V0RELA-SITUACAO. */
            _.Move("1", V0RELA_SITUACAO);

            /*" -1933- PERFORM R4600-00-INSERT-V0RELATORIOS. */

            R4600_00_INSERT_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INSERT-V0RELATORIOS-SECTION */
        private void R4600_00_INSERT_V0RELATORIOS_SECTION()
        {
            /*" -1983- PERFORM R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1 */

            R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1();

            /*" -1986- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1987- IF SQLCODE EQUAL -803 OR -811 */

                if (DB.SQLCODE.In("-803", "-811"))
                {

                    /*" -1988- DISPLAY 'B0300-10 (REGISTRO DUPLICADO) ... ' */
                    _.Display($"B0300-10 (REGISTRO DUPLICADO) ... ");

                    /*" -1989- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1990- ELSE */
                }
                else
                {


                    /*" -1991- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                    _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                    /*" -1991- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R4600-00-INSERT-V0RELATORIOS-DB-INSERT-1 */
        public void R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1()
        {
            /*" -1983- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 = new R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1()
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

            R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1.Execute(r4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2004- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2005- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2006- DISPLAY 'CERTIFICADO ' V0HCTB-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTB_NRCERTIF}");

            /*" -2007- DISPLAY 'LIDOS       ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -2008- DISPLAY 'VALOR       ' V0CBPR-IMPDIT. */
            _.Display($"VALOR       {V0CBPR_IMPDIT}");

            /*" -2009- DISPLAY V0PROP-CODPRODU */
            _.Display(V0PROP_CODPRODU);

            /*" -2010- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -2011- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -2013- DISPLAY V0CBPR-IMPDIT */
            _.Display(V0CBPR_IMPDIT);

            /*" -2013- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2015- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2019- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2019- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}