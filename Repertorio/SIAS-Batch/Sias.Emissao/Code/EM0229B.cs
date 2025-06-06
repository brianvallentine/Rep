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
using Sias.Emissao.DB2.EM0229B;

namespace Code
{
    public class EM0229B
    {
        public bool IsCall { get; set; }

        public EM0229B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0229B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  WANGER                             *      */
        /*"      *   DATA CODIFICACAO .......  JULHO/1995                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA TABELA PARA EMISSAO DE BLOQUE-*      */
        /*"      *                             TES (V0EMISICOB)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 07                                                   *      */
        /*"      * MOTIVO  : VERIFICAR NUMERO DE BOLETO PELA APOLICE TAMBEM       *      */
        /*"      * CADMUS  : XXXXXX                                               *      */
        /*"      * DATA    : 14/07/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.7                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 06                                                   *      */
        /*"      * MOTIVO  : TRATAMENTO NULLIDADE PARA AUTO - SIGCB               *      */
        /*"      *           TRATAMENTO PALIATIVO AT� SOLUCAO DEFINITIVA DA REGRA *      */
        /*"      *           DE AUTO.                                             *      */
        /*"      * CADMUS  : 140525                                               *      */
        /*"      * DATA    : 06/06/2017                                           *      */
        /*"      * NOME    : DIEGO DIAS                                           *      */
        /*"      * MARCADOR: V.06                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 5                                                    *      */
        /*"      * MOTIVO  : ESTOURO DE VALOR NA VARIAVEL WS-COUNT S9(4) COMP.    *      */
        /*"      * CADMUS  : 150473                                               *      */
        /*"      * DATA    : 03/05/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.5                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 4                                                    *      */
        /*"      * MOTIVO  : INIBIR GERACAO DE BOLETO SIGCB PARA APOLICE PAGO EM  *      */
        /*"      *           DEBITO EM CONTA                                      *      */
        /*"      * CADMUS  : 148877                                               *      */
        /*"      * DATA    : 19/04/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.4                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 3                                                    *      */
        /*"      * MOTIVO  : BOLETO REGISTRADO VIA SAP SIGCB                      *      */
        /*"      * CADMUS  : 134569                                               *      */
        /*"      * DATA    : 22/09/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.3                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO...............  VER CL001                          *      */
        /*"      *                             ALTERADO POR CLOVIS EM 09/07/98    *      */
        /*"      *                             SOLICITACAO DE 2. VIA ESTAVA       *      */
        /*"      *                             EMITINDO BLOQUETE EM DUPLICIDADE   *      */
        /*"      *                             QUANDO SOLICITADO PARCELA A PARCELA*      */
        /*"      *   ALTERACAO...............  VER LP0100                         *      */
        /*"      *                             ALTERADO POR LIANE  EM 07/01/2000  *      */
        /*"      *                             SOLICITACAO DE 2. VIA ESTAVA       *      */
        /*"      *                             EMITINDO BLOQUETE PARA DOCUMENTOS  *      */
        /*"      *                             JA VENCIDOS E COM NUMERO DO TITULO *      */
        /*"      *                             ZERADO.                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * EMISSAO DIARIA                      V1EMISDIARIA      INPUT    *      */
        /*"      * PARCELAS                            V0PARCELA         INPUT    *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         INPUT    *      */
        /*"      * EMISSAO DE SICOB                    V0EMISICOB        OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           10/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-NUMAPOL     PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V1ENDO_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NRENDOS     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-FONTE       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NRPROPOS    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-QTPARCEL    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-COUNT                PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-ORGAO       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO        PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-CODUNIMO    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODCLIEN    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-OCORR-END   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODSUBES    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODPRODU    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-TIPAPO      PIC  X(001).*/
        public StringBasis V1ENDO_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-CODCLIEN    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1SUBG_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SUBG-OCORR-END   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1SUBG_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TOMA-CODCLIEN    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0TOMA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0TOMA-OCORR-END   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0TOMA_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-CODRELAT   PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V1RELA-NUM-APOL   PIC S9(013)      COMP-3.*/
        public IntBasis V1RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1RELA-NRENDOS    PIC S9(009)      COMP.*/
        public IntBasis V1RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1RELA-NRPARCEL   PIC S9(004)      COMP.*/
        public IntBasis V1RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-DTSOLIC    PIC  X(010).*/
        public StringBasis V1RELA_DTSOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1RELA-ORGAO      PIC S9(004)      COMP.*/
        public IntBasis V1RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-RAMO       PIC S9(004)      COMP.*/
        public IntBasis V1RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-FONTE      PIC S9(004)      COMP.*/
        public IntBasis V1RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-CONGENER   PIC S9(004)      COMP.*/
        public IntBasis V1RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-CODPDT     PIC S9(009)      COMP.*/
        public IntBasis V1RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1RELA-SITUACAO   PIC  X(001).*/
        public StringBasis V1RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1RELA-COD-EMP    PIC S9(004)      COMP.*/
        public IntBasis V1RELA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-CODRELAT   PIC  X(008).*/
        public StringBasis V1EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V1EDIA-NUMAPOL    PIC S9(013)      COMP-3.*/
        public IntBasis V1EDIA_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1EDIA-NRENDOS    PIC S9(009)      COMP.*/
        public IntBasis V1EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1EDIA-NRPARCEL   PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-DTMOVTO    PIC  X(010).*/
        public StringBasis V1EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1EDIA-ORGAO      PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-RAMO       PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-FONTE      PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-CONGENER   PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-CODCORR    PIC S9(009)      COMP.*/
        public IntBasis V1EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1EDIA-SITUACAO   PIC  X(001).*/
        public StringBasis V1EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1EDIA-COD-EMP    PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-NRTIT        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-OTNTOTAL     PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0PARC-VLPRMTOT     PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0PARC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1PARR-RAMO-VG      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-AP      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-VGAPC   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-SAUDE   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-EDUCA   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_EDUCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0ESIC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ESIC-CODCDT       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_CODCDT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-NUMAPOL      PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0ESIC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ESIC-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ESIC-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0ESIC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0ESIC-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-NRPROPOS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ESIC-NRCARNE      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_NRCARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-QTPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-DTVENCTO     PIC  X(010).*/
        public StringBasis V0ESIC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ESIC-DTDOCTO      PIC  X(010).*/
        public StringBasis V0ESIC_DTDOCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ESIC-NRDOCTO      PIC  X(021).*/
        public StringBasis V0ESIC_NRDOCTO { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
        /*"77         V0ESIC-CORRECAO     PIC  X(001).*/
        public StringBasis V0ESIC_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ESIC-CODUNIMO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-VL-PRM-IX    PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0ESIC_VL_PRM_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0ESIC-VL-PRM-VAR   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0ESIC_VL_PRM_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0ESIC-RECVENCTO    PIC  X(001).*/
        public StringBasis V0ESIC_RECVENCTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ESIC-IOFINCLUSO   PIC  X(001).*/
        public StringBasis V0ESIC_IOFINCLUSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ESIC-RECIOF       PIC  X(001).*/
        public StringBasis V0ESIC_RECIOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ESIC-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ESIC-OCORR-END    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-CODPGM       PIC  X(008).*/
        public StringBasis V0ESIC_CODPGM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ESIC-CODMENS      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ESIC_CODMENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ESIC-SITUACAO     PIC  X(001).*/
        public StringBasis V0ESIC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ESIC-DTMOVTO      PIC  X(010).*/
        public StringBasis V0ESIC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           AREA-DE-WORK.*/
        public EM0229B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0229B_AREA_DE_WORK();
        public class EM0229B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WZEROS            PIC S9(003)    VALUE +0 COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1EMISDIA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1EMISDIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RELATORIOS PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-TOMADOR      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_TOMADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-L-V1EMISDIA    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_L_V1EMISDIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-G-V0EMISICOB   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_G_V0EMISICOB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WS-ALFA-NUMAPOL.*/
            public EM0229B_WS_ALFA_NUMAPOL WS_ALFA_NUMAPOL { get; set; } = new EM0229B_WS_ALFA_NUMAPOL();
            public class EM0229B_WS_ALFA_NUMAPOL : VarBasis
            {
                /*"   10        WS-NUM-NUMAPOL    PIC  9(013)    VALUE ZEROS.*/
                public IntBasis WS_NUM_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"  05        WABEND.*/
            }
            public EM0229B_WABEND WABEND { get; set; } = new EM0229B_WABEND();
            public class EM0229B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0229B'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0229B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(005) VALUE '00000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public EM0229B_LK_LINK LK_LINK { get; set; } = new EM0229B_LK_LINK();
        public class EM0229B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public EM0229B_V1EMIS V1EMIS { get; set; } = new EM0229B_V1EMIS();
        public EM0229B_V1PARCELA V1PARCELA { get; set; } = new EM0229B_V1PARCELA();
        public EM0229B_V1RELATORIOS V1RELATORIOS { get; set; } = new EM0229B_V1RELATORIOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -348- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -349- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -352- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -355- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -355- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -371- DISPLAY 'EM0229B VERSAO 7 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"EM0229B VERSAO 7 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -373- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -374- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -376- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -378- PERFORM R0200-00-SELECT-V1PARAMRAMO. */

            R0200_00_SELECT_V1PARAMRAMO_SECTION();

            /*" -380- PERFORM S1000-00-VERIFICA-2VIA. */

            S1000_00_VERIFICA_2VIA_SECTION();

            /*" -381- MOVE SPACES TO WFIM-V1EMISDIA */
            _.Move("", AREA_DE_WORK.WFIM_V1EMISDIA);

            /*" -383- PERFORM R0900-00-DECLARE-V1EMISDIARIA */

            R0900_00_DECLARE_V1EMISDIARIA_SECTION();

            /*" -384- PERFORM R0910-00-FETCH-V1EMISDIARIA */

            R0910_00_FETCH_V1EMISDIARIA_SECTION();

            /*" -385- IF WFIM-V1EMISDIA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1EMISDIA.IsEmpty())
            {

                /*" -386- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -388- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -400- PERFORM R1000-00-PROCESSA UNTIL WFIM-V1EMISDIA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1EMISDIA.IsEmpty()))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -401- DISPLAY 'REGISTROS  LIDOS           ' AC-L-V1EMISDIA */
            _.Display($"REGISTROS  LIDOS           {AREA_DE_WORK.AC_L_V1EMISDIA}");

            /*" -401- DISPLAY 'QUANTIDADE DE BLOQUETES    ' AC-G-V0EMISICOB. */
            _.Display($"QUANTIDADE DE BLOQUETES    {AREA_DE_WORK.AC_G_V0EMISICOB}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -409- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -409- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -422- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -427- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -430- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -431- DISPLAY 'EM0229B - SISTEMA DE EMISSAO NAO CADASTRADO' */
                _.Display($"EM0229B - SISTEMA DE EMISSAO NAO CADASTRADO");

                /*" -432- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -432- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -427- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V1PARAMRAMO-SECTION */
        private void R0200_00_SELECT_V1PARAMRAMO_SECTION()
        {
            /*" -445- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -457- PERFORM R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1 */

            R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1();

            /*" -460- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -461- DISPLAY 'EM0229B - NAO EXISTE NA V1PARAMRAMO' */
                _.Display($"EM0229B - NAO EXISTE NA V1PARAMRAMO");

                /*" -461- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V1PARAMRAMO-DB-SELECT-1 */
        public void R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -457- EXEC SQL SELECT RAMO_VG , RAMO_AP , RAMO_VGAPC , RAMO_SAUDE , RAMO_EDUCACAO INTO :V1PARR-RAMO-VG , :V1PARR-RAMO-AP , :V1PARR-RAMO-VGAPC , :V1PARR-RAMO-SAUDE , :V1PARR-RAMO-EDUCA FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var r0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARR_RAMO_VG, V1PARR_RAMO_VG);
                _.Move(executed_1.V1PARR_RAMO_AP, V1PARR_RAMO_AP);
                _.Move(executed_1.V1PARR_RAMO_VGAPC, V1PARR_RAMO_VGAPC);
                _.Move(executed_1.V1PARR_RAMO_SAUDE, V1PARR_RAMO_SAUDE);
                _.Move(executed_1.V1PARR_RAMO_EDUCA, V1PARR_RAMO_EDUCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1EMISDIARIA-SECTION */
        private void R0900_00_DECLARE_V1EMISDIARIA_SECTION()
        {
            /*" -474- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -476- DISPLAY 'V1SIST-DTMOVABE = ' V1SIST-DTMOVABE */
            _.Display($"V1SIST-DTMOVABE = {V1SIST_DTMOVABE}");

            /*" -491- PERFORM R0900_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1 */

            R0900_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1();

            /*" -493- PERFORM R0900_00_DECLARE_V1EMISDIARIA_DB_OPEN_1 */

            R0900_00_DECLARE_V1EMISDIARIA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1EMISDIARIA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1EMISDIARIA_DB_DECLARE_1()
        {
            /*" -491- EXEC SQL DECLARE V1EMIS CURSOR FOR SELECT NUM_APOLICE , NRENDOS , NRPARCEL , CODRELAT , RAMO FROM SEGUROS.V1EMISDIARIA WHERE CODRELAT IN ( 'EM0230B1' , 'EM0230B2' ) AND DTMOVTO = :V1SIST-DTMOVABE AND SITUACAO = '0' ORDER BY NUM_APOLICE,NRENDOS,NRPARCEL END-EXEC. */
            V1EMIS = new EM0229B_V1EMIS(true);
            string GetQuery_V1EMIS()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							CODRELAT
							, 
							RAMO 
							FROM SEGUROS.V1EMISDIARIA 
							WHERE CODRELAT IN ( 'EM0230B1'
							, 
							'EM0230B2' ) 
							AND DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND SITUACAO = '0' 
							ORDER BY NUM_APOLICE
							,NRENDOS
							,NRPARCEL";

                return query;
            }
            V1EMIS.GetQueryEvent += GetQuery_V1EMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1EMISDIARIA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1EMISDIARIA_DB_OPEN_1()
        {
            /*" -493- EXEC SQL OPEN V1EMIS END-EXEC. */

            V1EMIS.Open();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1PARCELA-DB-DECLARE-1 */
        public void R1500_00_DECLARE_V1PARCELA_DB_DECLARE_1()
        {
            /*" -729- EXEC SQL DECLARE V1PARCELA CURSOR FOR SELECT A.NRTIT , A.NRPARCEL , B.DTVENCTO , A.OTNTOTAL , B.VLPRMTOT FROM SEGUROS.V0PARCELA A, SEGUROS.V1HISTOPARC B WHERE A.NUM_APOLICE = :V1EDIA-NUMAPOL AND A.NRENDOS = :V1EDIA-NRENDOS AND A.SITUACAO = '0' AND B.OPERACAO = 101 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS AND A.NRPARCEL = B.NRPARCEL ORDER BY NRPARCEL END-EXEC. */
            V1PARCELA = new EM0229B_V1PARCELA(true);
            string GetQuery_V1PARCELA()
            {
                var query = @$"SELECT 
							A.NRTIT
							, 
							A.NRPARCEL
							, 
							B.DTVENCTO
							, 
							A.OTNTOTAL
							, 
							B.VLPRMTOT 
							FROM SEGUROS.V0PARCELA A
							, 
							SEGUROS.V1HISTOPARC B 
							WHERE A.NUM_APOLICE = '{V1EDIA_NUMAPOL}' 
							AND A.NRENDOS = '{V1EDIA_NRENDOS}' 
							AND A.SITUACAO = '0' 
							AND B.OPERACAO = 101 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NRENDOS = B.NRENDOS 
							AND A.NRPARCEL = B.NRPARCEL 
							ORDER BY NRPARCEL";

                return query;
            }
            V1PARCELA.GetQueryEvent += GetQuery_V1PARCELA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1EMISDIARIA-SECTION */
        private void R0910_00_FETCH_V1EMISDIARIA_SECTION()
        {
            /*" -504- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0910_10_FETCH_V1EMISDIARIA */

            R0910_10_FETCH_V1EMISDIARIA();

        }

        [StopWatch]
        /*" R0910-10-FETCH-V1EMISDIARIA */
        private void R0910_10_FETCH_V1EMISDIARIA(bool isPerform = false)
        {
            /*" -510- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -516- PERFORM R0910_10_FETCH_V1EMISDIARIA_DB_FETCH_1 */

            R0910_10_FETCH_V1EMISDIARIA_DB_FETCH_1();

            /*" -520- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -521- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -522- MOVE 'S' TO WFIM-V1EMISDIA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1EMISDIA);

                    /*" -522- PERFORM R0910_10_FETCH_V1EMISDIARIA_DB_CLOSE_1 */

                    R0910_10_FETCH_V1EMISDIARIA_DB_CLOSE_1();

                    /*" -524- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -525- ELSE */
                }
                else
                {


                    /*" -527- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -533- ADD 1 TO AC-L-V1EMISDIA. */
            AREA_DE_WORK.AC_L_V1EMISDIA.Value = AREA_DE_WORK.AC_L_V1EMISDIA + 1;

            /*" -550- IF V1EDIA-NUMAPOL = 106100000001 OR 106100000002 OR 106100000003 OR 106100000007 OR 106100000005 OR 106100000010 OR 106100000008 OR 106100000009 OR 106100000012 OR 106100000013 OR 106100000014 OR 106100000015 OR 106100000016 OR 106100000017 OR 106100000018 OR 106100000024 OR 106100000027 OR 106100000019 OR 106100000028 OR 106100000029 OR 106100000030 OR 106100000031 OR 106100000032 OR 6501000001 OR 106800000001 OR 106800000003 OR 106800000004 OR 106800000005 OR 106800000006 OR 106800000008 OR 106800000009 OR 106800000018 OR 106800000019 OR 106800000020 OR 106800000021 OR 106800000022 OR 106800000023 OR 104800000041 OR 104800000041 OR 107000000001 OR 107700000010 OR 107700000023 OR 107700000022 OR 107700000021 OR 107700000038 OR 101402541675 OR 101402541679 OR 109300000006 */

            if (V1EDIA_NUMAPOL.In("106100000001", "106100000002", "106100000003", "106100000007", "106100000005", "106100000010", "106100000008", "106100000009", "106100000012", "106100000013", "106100000014", "106100000015", "106100000016", "106100000017", "106100000018", "106100000024", "106100000027", "106100000019", "106100000028", "106100000029", "106100000030", "106100000031", "106100000032", "6501000001", "106800000001", "106800000003", "106800000004", "106800000005", "106800000006", "106800000008", "106800000009", "106800000018", "106800000019", "106800000020", "106800000021", "106800000022", "106800000023", "104800000041", "104800000041", "107000000001", "107700000010", "107700000023", "107700000022", "107700000021", "107700000038", "101402541675", "101402541679", "109300000006"))
            {

                /*" -551- GO TO R0910-10-FETCH-V1EMISDIARIA */
                new Task(() => R0910_10_FETCH_V1EMISDIARIA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -553- END-IF. */
            }


            /*" -555- PERFORM R0911-00-LER-PEDIDO-NN-SAP */

            R0911_00_LER_PEDIDO_NN_SAP_SECTION();

            /*" -557- IF WS-COUNT > 0 OR (V1EDIA-RAMO EQUAL 31 OR 53) */

            if (WS_COUNT > 0 || (V1EDIA_RAMO.In("31", "53")))
            {

                /*" -558- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -559- DISPLAY 'PEDIDO DE BOLETO JA SOLICITADO AO SAP' */
                _.Display($"PEDIDO DE BOLETO JA SOLICITADO AO SAP");

                /*" -560- DISPLAY 'V1EDIA-NUMAPOL = ' V1EDIA-NUMAPOL */
                _.Display($"V1EDIA-NUMAPOL = {V1EDIA_NUMAPOL}");

                /*" -561- DISPLAY 'V1EDIA-NRENDOS = ' V1EDIA-NRENDOS */
                _.Display($"V1EDIA-NRENDOS = {V1EDIA_NRENDOS}");

                /*" -562- DISPLAY 'V1EDIA-RAMO    = ' V1EDIA-RAMO */
                _.Display($"V1EDIA-RAMO    = {V1EDIA_RAMO}");

                /*" -563- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -564- GO TO R0910-10-FETCH-V1EMISDIARIA */
                new Task(() => R0910_10_FETCH_V1EMISDIARIA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -564- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-10-FETCH-V1EMISDIARIA-DB-FETCH-1 */
        public void R0910_10_FETCH_V1EMISDIARIA_DB_FETCH_1()
        {
            /*" -516- EXEC SQL FETCH V1EMIS INTO :V1EDIA-NUMAPOL , :V1EDIA-NRENDOS , :V1EDIA-NRPARCEL, :V1EDIA-CODRELAT, :V1EDIA-RAMO END-EXEC. */

            if (V1EMIS.Fetch())
            {
                _.Move(V1EMIS.V1EDIA_NUMAPOL, V1EDIA_NUMAPOL);
                _.Move(V1EMIS.V1EDIA_NRENDOS, V1EDIA_NRENDOS);
                _.Move(V1EMIS.V1EDIA_NRPARCEL, V1EDIA_NRPARCEL);
                _.Move(V1EMIS.V1EDIA_CODRELAT, V1EDIA_CODRELAT);
                _.Move(V1EMIS.V1EDIA_RAMO, V1EDIA_RAMO);
            }

        }

        [StopWatch]
        /*" R0910-10-FETCH-V1EMISDIARIA-DB-CLOSE-1 */
        public void R0910_10_FETCH_V1EMISDIARIA_DB_CLOSE_1()
        {
            /*" -522- EXEC SQL CLOSE V1EMIS END-EXEC */

            V1EMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0911-00-LER-PEDIDO-NN-SAP-SECTION */
        private void R0911_00_LER_PEDIDO_NN_SAP_SECTION()
        {
            /*" -574- MOVE 'R0911' TO WNR-EXEC-SQL. */
            _.Move("R0911", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -575- MOVE ZEROS TO WS-COUNT */
            _.Move(0, WS_COUNT);

            /*" -576- MOVE V1EDIA-NRENDOS TO GE403-NUM-ENDOSSO */
            _.Move(V1EDIA_NRENDOS, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -578- MOVE V1EDIA-NUMAPOL TO GE403-NUM-APOLICE */
            _.Move(V1EDIA_NUMAPOL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -587- PERFORM R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1 */

            R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1();

            /*" -590- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -591- MOVE 1 TO WS-COUNT */
                _.Move(1, WS_COUNT);

                /*" -593- END-IF */
            }


            /*" -594- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -595- DISPLAY 'PROBLEMAS NO SELECT GE_CONTROLE_EMISSAO_SIGCB' */
                _.Display($"PROBLEMAS NO SELECT GE_CONTROLE_EMISSAO_SIGCB");

                /*" -596- DISPLAY 'NUM_ENDOSSO    = ' GE403-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO    = {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                /*" -597- DISPLAY 'V1EDIA-NUMAPOL = ' V1EDIA-NUMAPOL */
                _.Display($"V1EDIA-NUMAPOL = {V1EDIA_NUMAPOL}");

                /*" -598- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -598- END-IF. */
            }


        }

        [StopWatch]
        /*" R0911-00-LER-PEDIDO-NN-SAP-DB-SELECT-1 */
        public void R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1()
        {
            /*" -587- EXEC SQL SELECT VALUE(NUM_IDLG, ' ' ) INTO :GE403-NUM-IDLG FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB WHERE NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND NUM_APOLICE = :GE403-NUM-APOLICE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1 = new R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1()
            {
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1.Execute(r0911_00_LER_PEDIDO_NN_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0911_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -607- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -608- IF V1EDIA-RAMO EQUAL 31 OR 53 */

            if (V1EDIA_RAMO.In("31", "53"))
            {

                /*" -609- DISPLAY 'CASOS AUTO A SEREM TRATADOS POSTERIORMENTE' */
                _.Display($"CASOS AUTO A SEREM TRATADOS POSTERIORMENTE");

                /*" -613- DISPLAY 'NUMAPOL= ' V1EDIA-NUMAPOL 'NRENDOS= ' V1EDIA-NRENDOS 'NRPARCEL= ' V1EDIA-NRPARCEL 'CODRELAT= ' V1EDIA-CODRELAT */

                $"NUMAPOL= {V1EDIA_NUMAPOL}NRENDOS= {V1EDIA_NRENDOS}NRPARCEL= {V1EDIA_NRPARCEL}CODRELAT= {V1EDIA_CODRELAT}"
                .Display();

                /*" -614- GO TO R1000-90-LEITURA-V1EMISDIA */

                R1000_90_LEITURA_V1EMISDIA(); //GOTO
                return;

                /*" -615- END-IF */
            }


            /*" -617- PERFORM R1100-00-SELECT-V1ENDOSSO */

            R1100_00_SELECT_V1ENDOSSO_SECTION();

            /*" -622- IF V1ENDO-RAMO EQUAL V1PARR-RAMO-VG OR V1PARR-RAMO-AP OR V1PARR-RAMO-VGAPC OR V1PARR-RAMO-SAUDE OR V1PARR-RAMO-EDUCA */

            if (V1ENDO_RAMO.In(V1PARR_RAMO_VG.ToString(), V1PARR_RAMO_AP.ToString(), V1PARR_RAMO_VGAPC.ToString(), V1PARR_RAMO_SAUDE.ToString(), V1PARR_RAMO_EDUCA.ToString()))
            {

                /*" -624- PERFORM R2700-00-SELECT-V1SUBGRUPO. */

                R2700_00_SELECT_V1SUBGRUPO_SECTION();
            }


            /*" -625- MOVE SPACES TO WFIM-V1PARCELA */
            _.Move("", AREA_DE_WORK.WFIM_V1PARCELA);

            /*" -626- PERFORM R1500-00-DECLARE-V1PARCELA */

            R1500_00_DECLARE_V1PARCELA_SECTION();

            /*" -628- PERFORM R1510-00-FETCH-V1PARCELA */

            R1510_00_FETCH_V1PARCELA_SECTION();

            /*" -629- IF WFIM-V1PARCELA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty())
            {

                /*" -631- GO TO R1000-90-LEITURA-V1EMISDIA. */

                R1000_90_LEITURA_V1EMISDIA(); //GOTO
                return;
            }


            /*" -634- PERFORM R2000-00-PROCESSA-PARCELA UNTIL WFIM-V1PARCELA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty()))
            {

                R2000_00_PROCESSA_PARCELA_SECTION();
            }

            /*" -634- PERFORM R1000-90-LEITURA-V1EMISDIA. */

            R1000_90_LEITURA_V1EMISDIA();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA_V1EMISDIA */

            R1000_90_LEITURA_V1EMISDIA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA-V1EMISDIA */
        private void R1000_90_LEITURA_V1EMISDIA(bool isPerform = false)
        {
            /*" -639- PERFORM R0910-00-FETCH-V1EMISDIARIA. */

            R0910_00_FETCH_V1EMISDIARIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-SECTION */
        private void R1100_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -653- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -687- PERFORM R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -690- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -691- DISPLAY 'NAO EXISTE NA V1ENDOSSO ... ' */
                _.Display($"NAO EXISTE NA V1ENDOSSO ... ");

                /*" -692- DISPLAY 'NUM_APOLICE        = ' V1EDIA-NUMAPOL */
                _.Display($"NUM_APOLICE        = {V1EDIA_NUMAPOL}");

                /*" -693- DISPLAY 'NRENDOS            = ' V1EDIA-NRENDOS */
                _.Display($"NRENDOS            = {V1EDIA_NRENDOS}");

                /*" -695- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -699- DISPLAY 'PROBLEMAS NO SELECT (V1PROPOSTA)... ' ' ' V1EDIA-NUMAPOL ' ' V1EDIA-NRENDOS */

                $"PROBLEMAS NO SELECT (V1PROPOSTA)...  {V1EDIA_NUMAPOL} {V1EDIA_NRENDOS}"
                .Display();

                /*" -699- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -687- EXEC SQL SELECT NUM_APOLICE , NRENDOS , FONTE , NRPROPOS , QTPARCEL , DTEMIS , ORGAO , RAMO , CORRECAO , COD_MOEDA_PRM , CODCLIEN , OCORR_ENDERECO, CODSUBES , VALUE(CODPRODU,0), TIPAPO INTO :V1ENDO-NUMAPOL , :V1ENDO-NRENDOS , :V1ENDO-FONTE , :V1ENDO-NRPROPOS , :V1ENDO-QTPARCEL , :V1ENDO-DTEMIS , :V1ENDO-ORGAO , :V1ENDO-RAMO , :V1ENDO-CORRECAO , :V1ENDO-CODUNIMO , :V1ENDO-CODCLIEN , :V1ENDO-OCORR-END, :V1ENDO-CODSUBES , :V1ENDO-CODPRODU , :V1ENDO-TIPAPO FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V1EDIA-NUMAPOL AND NRENDOS = :V1EDIA-NRENDOS END-EXEC. */

            var r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V1EDIA_NUMAPOL = V1EDIA_NUMAPOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_NUMAPOL, V1ENDO_NUMAPOL);
                _.Move(executed_1.V1ENDO_NRENDOS, V1ENDO_NRENDOS);
                _.Move(executed_1.V1ENDO_FONTE, V1ENDO_FONTE);
                _.Move(executed_1.V1ENDO_NRPROPOS, V1ENDO_NRPROPOS);
                _.Move(executed_1.V1ENDO_QTPARCEL, V1ENDO_QTPARCEL);
                _.Move(executed_1.V1ENDO_DTEMIS, V1ENDO_DTEMIS);
                _.Move(executed_1.V1ENDO_ORGAO, V1ENDO_ORGAO);
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_CORRECAO, V1ENDO_CORRECAO);
                _.Move(executed_1.V1ENDO_CODUNIMO, V1ENDO_CODUNIMO);
                _.Move(executed_1.V1ENDO_CODCLIEN, V1ENDO_CODCLIEN);
                _.Move(executed_1.V1ENDO_OCORR_END, V1ENDO_OCORR_END);
                _.Move(executed_1.V1ENDO_CODSUBES, V1ENDO_CODSUBES);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.V1ENDO_TIPAPO, V1ENDO_TIPAPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-DECLARE-V1PARCELA-SECTION */
        private void R1500_00_DECLARE_V1PARCELA_SECTION()
        {
            /*" -712- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -729- PERFORM R1500_00_DECLARE_V1PARCELA_DB_DECLARE_1 */

            R1500_00_DECLARE_V1PARCELA_DB_DECLARE_1();

            /*" -731- PERFORM R1500_00_DECLARE_V1PARCELA_DB_OPEN_1 */

            R1500_00_DECLARE_V1PARCELA_DB_OPEN_1();

            /*" -734- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -734- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1PARCELA-DB-OPEN-1 */
        public void R1500_00_DECLARE_V1PARCELA_DB_OPEN_1()
        {
            /*" -731- EXEC SQL OPEN V1PARCELA END-EXEC. */

            V1PARCELA.Open();

        }

        [StopWatch]
        /*" S2000-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void S2000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -1271- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT CODRELAT , NUM_APOLICE, NRENDOS , NRPARCEL , DATA_SOLICITACAO, ORGAO , RAMO , FONTE , CONGENER , CODPDT FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'EM0230B1' AND DATA_SOLICITACAO = :V1SIST-DTMOVABE END-EXEC. */
            V1RELATORIOS = new EM0229B_V1RELATORIOS(true);
            string GetQuery_V1RELATORIOS()
            {
                var query = @$"SELECT CODRELAT
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							DATA_SOLICITACAO
							, 
							ORGAO
							, 
							RAMO
							, 
							FONTE
							, 
							CONGENER
							, 
							CODPDT 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'EM0230B1' 
							AND DATA_SOLICITACAO = '{V1SIST_DTMOVABE}'";

                return query;
            }
            V1RELATORIOS.GetQueryEvent += GetQuery_V1RELATORIOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-FETCH-V1PARCELA-SECTION */
        private void R1510_00_FETCH_V1PARCELA_SECTION()
        {
            /*" -747- MOVE '151' TO WNR-EXEC-SQL. */
            _.Move("151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -754- PERFORM R1510_00_FETCH_V1PARCELA_DB_FETCH_1 */

            R1510_00_FETCH_V1PARCELA_DB_FETCH_1();

            /*" -757- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -758- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -759- MOVE 'S' TO WFIM-V1PARCELA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                    /*" -759- PERFORM R1510_00_FETCH_V1PARCELA_DB_CLOSE_1 */

                    R1510_00_FETCH_V1PARCELA_DB_CLOSE_1();

                    /*" -761- GO TO R1510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/ //GOTO
                    return;

                    /*" -762- ELSE */
                }
                else
                {


                    /*" -762- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1510-00-FETCH-V1PARCELA-DB-FETCH-1 */
        public void R1510_00_FETCH_V1PARCELA_DB_FETCH_1()
        {
            /*" -754- EXEC SQL FETCH V1PARCELA INTO :V0PARC-NRTIT , :V0PARC-NRPARCEL , :V0PARC-DTVENCTO , :V0PARC-OTNTOTAL , :V0PARC-VLPRMTOT END-EXEC. */

            if (V1PARCELA.Fetch())
            {
                _.Move(V1PARCELA.V0PARC_NRTIT, V0PARC_NRTIT);
                _.Move(V1PARCELA.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(V1PARCELA.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(V1PARCELA.V0PARC_OTNTOTAL, V0PARC_OTNTOTAL);
                _.Move(V1PARCELA.V0PARC_VLPRMTOT, V0PARC_VLPRMTOT);
            }

        }

        [StopWatch]
        /*" R1510-00-FETCH-V1PARCELA-DB-CLOSE-1 */
        public void R1510_00_FETCH_V1PARCELA_DB_CLOSE_1()
        {
            /*" -759- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-PARCELA-SECTION */
        private void R2000_00_PROCESSA_PARCELA_SECTION()
        {
            /*" -776- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -778- IF V1ENDO-TIPAPO NOT EQUAL '5' AND V1ENDO-TIPAPO NOT EQUAL '4' */

            if (V1ENDO_TIPAPO != "5" && V1ENDO_TIPAPO != "4")
            {

                /*" -779- IF V0PARC-DTVENCTO LESS V1RELA-DTSOLIC */

                if (V0PARC_DTVENCTO < V1RELA_DTSOLIC)
                {

                    /*" -782- GO TO R2000-50-LEITURA. */

                    R2000_50_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -783- IF V1ENDO-CORRECAO EQUAL ( '1' OR '3' ) */

            if (V1ENDO_CORRECAO.In("1", "3"))
            {

                /*" -784- IF V0PARC-VLPRMTOT NOT GREATER ZEROS */

                if (V0PARC_VLPRMTOT <= 00)
                {

                    /*" -785- GO TO R2000-50-LEITURA */

                    R2000_50_LEITURA(); //GOTO
                    return;

                    /*" -787- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -788- ELSE */
                }

            }
            else
            {


                /*" -789- IF V1ENDO-CORRECAO EQUAL ( '2' OR '4' ) */

                if (V1ENDO_CORRECAO.In("2", "4"))
                {

                    /*" -790- IF V0PARC-OTNTOTAL NOT GREATER ZEROS */

                    if (V0PARC_OTNTOTAL <= 00)
                    {

                        /*" -791- GO TO R2000-50-LEITURA */

                        R2000_50_LEITURA(); //GOTO
                        return;

                        /*" -793- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -794- ELSE */
                    }

                }
                else
                {


                    /*" -799- GO TO R2000-50-LEITURA. */

                    R2000_50_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -801- IF V0PARC-NRTIT GREATER 84100000000 AND V0PARC-NRTIT LESS 84200000000 */

            if (V0PARC_NRTIT > 84100000000 && V0PARC_NRTIT < 84200000000)
            {

                /*" -802- MOVE 25 TO V0ESIC-CODCDT */
                _.Move(25, V0ESIC_CODCDT);

                /*" -806- ELSE */
            }
            else
            {


                /*" -809- IF V0PARC-NRTIT GREATER 3100000000000 AND V0PARC-NRTIT LESS 3200000000000 AND V1ENDO-ORGAO EQUAL 100 */

                if (V0PARC_NRTIT > 3100000000000 && V0PARC_NRTIT < 3200000000000 && V1ENDO_ORGAO == 100)
                {

                    /*" -810- MOVE 59 TO V0ESIC-CODCDT */
                    _.Move(59, V0ESIC_CODCDT);

                    /*" -814- ELSE */
                }
                else
                {


                    /*" -817- IF V0PARC-NRTIT GREATER 5500000000000 AND V0PARC-NRTIT LESS 5600000000000 AND V1ENDO-ORGAO EQUAL 100 */

                    if (V0PARC_NRTIT > 5500000000000 && V0PARC_NRTIT < 5600000000000 && V1ENDO_ORGAO == 100)
                    {

                        /*" -818- MOVE 59 TO V0ESIC-CODCDT */
                        _.Move(59, V0ESIC_CODCDT);

                        /*" -822- ELSE */
                    }
                    else
                    {


                        /*" -824- IF V0PARC-NRTIT GREATER 5500000000000 AND V0PARC-NRTIT LESS 5600000000000 */

                        if (V0PARC_NRTIT > 5500000000000 && V0PARC_NRTIT < 5600000000000)
                        {

                            /*" -825- MOVE 60 TO V0ESIC-CODCDT */
                            _.Move(60, V0ESIC_CODCDT);

                            /*" -826- ELSE */
                        }
                        else
                        {


                            /*" -829- GO TO R2000-50-LEITURA. */

                            R2000_50_LEITURA(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -834- MOVE V0PARC-NRTIT TO V0ESIC-NRTIT */
            _.Move(V0PARC_NRTIT, V0ESIC_NRTIT);

            /*" -835- MOVE V1ENDO-NUMAPOL TO V0ESIC-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, V0ESIC_NUMAPOL);

            /*" -836- MOVE V1ENDO-NRENDOS TO V0ESIC-NRENDOS */
            _.Move(V1ENDO_NRENDOS, V0ESIC_NRENDOS);

            /*" -837- MOVE ZEROS TO V0ESIC-NRCERTIF */
            _.Move(0, V0ESIC_NRCERTIF);

            /*" -838- MOVE V1ENDO-FONTE TO V0ESIC-FONTE */
            _.Move(V1ENDO_FONTE, V0ESIC_FONTE);

            /*" -839- MOVE V1ENDO-NRPROPOS TO V0ESIC-NRPROPOS */
            _.Move(V1ENDO_NRPROPOS, V0ESIC_NRPROPOS);

            /*" -841- MOVE ZEROS TO V0ESIC-NRCARNE. */
            _.Move(0, V0ESIC_NRCARNE);

            /*" -842- IF V1EDIA-CODRELAT EQUAL 'EM0230B2' */

            if (V1EDIA_CODRELAT == "EM0230B2")
            {

                /*" -844- IF V1EDIA-NRPARCEL EQUAL 99 NEXT SENTENCE */

                if (V1EDIA_NRPARCEL == 99)
                {

                    /*" -845- ELSE */
                }
                else
                {


                    /*" -847- IF V1EDIA-NRPARCEL EQUAL V0PARC-NRPARCEL NEXT SENTENCE */

                    if (V1EDIA_NRPARCEL == V0PARC_NRPARCEL)
                    {

                        /*" -848- ELSE */
                    }
                    else
                    {


                        /*" -850- GO TO R2000-50-LEITURA. */

                        R2000_50_LEITURA(); //GOTO
                        return;
                    }

                }

            }


            /*" -851- IF V0PARC-NRPARCEL EQUAL ZEROS */

            if (V0PARC_NRPARCEL == 00)
            {

                /*" -852- MOVE 1 TO V0ESIC-NRPARCEL */
                _.Move(1, V0ESIC_NRPARCEL);

                /*" -853- ELSE */
            }
            else
            {


                /*" -855- MOVE V0PARC-NRPARCEL TO V0ESIC-NRPARCEL. */
                _.Move(V0PARC_NRPARCEL, V0ESIC_NRPARCEL);
            }


            /*" -856- MOVE V1ENDO-QTPARCEL TO V0ESIC-QTPARCEL */
            _.Move(V1ENDO_QTPARCEL, V0ESIC_QTPARCEL);

            /*" -857- MOVE V0PARC-DTVENCTO TO V0ESIC-DTVENCTO */
            _.Move(V0PARC_DTVENCTO, V0ESIC_DTVENCTO);

            /*" -858- MOVE V1ENDO-DTEMIS TO V0ESIC-DTDOCTO */
            _.Move(V1ENDO_DTEMIS, V0ESIC_DTDOCTO);

            /*" -859- MOVE V1ENDO-NUMAPOL TO WS-NUM-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, AREA_DE_WORK.WS_ALFA_NUMAPOL.WS_NUM_NUMAPOL);

            /*" -860- MOVE WS-ALFA-NUMAPOL TO V0ESIC-NRDOCTO */
            _.Move(AREA_DE_WORK.WS_ALFA_NUMAPOL, V0ESIC_NRDOCTO);

            /*" -861- MOVE V1ENDO-CORRECAO TO V0ESIC-CORRECAO */
            _.Move(V1ENDO_CORRECAO, V0ESIC_CORRECAO);

            /*" -863- MOVE V1ENDO-CODUNIMO TO V0ESIC-CODUNIMO */
            _.Move(V1ENDO_CODUNIMO, V0ESIC_CODUNIMO);

            /*" -864- IF V1ENDO-CORRECAO EQUAL ( '1' OR '3' ) */

            if (V1ENDO_CORRECAO.In("1", "3"))
            {

                /*" -865- MOVE V0PARC-VLPRMTOT TO V0ESIC-VL-PRM-VAR */
                _.Move(V0PARC_VLPRMTOT, V0ESIC_VL_PRM_VAR);

                /*" -866- MOVE ZEROS TO V0ESIC-VL-PRM-IX */
                _.Move(0, V0ESIC_VL_PRM_IX);

                /*" -867- ELSE */
            }
            else
            {


                /*" -868- IF V1ENDO-CORRECAO EQUAL ( '2' OR '4' ) */

                if (V1ENDO_CORRECAO.In("2", "4"))
                {

                    /*" -869- MOVE ZEROS TO V0ESIC-VL-PRM-VAR */
                    _.Move(0, V0ESIC_VL_PRM_VAR);

                    /*" -871- MOVE V0PARC-OTNTOTAL TO V0ESIC-VL-PRM-IX. */
                    _.Move(V0PARC_OTNTOTAL, V0ESIC_VL_PRM_IX);
                }

            }


            /*" -872- MOVE 'N' TO V0ESIC-RECVENCTO */
            _.Move("N", V0ESIC_RECVENCTO);

            /*" -873- MOVE 'S' TO V0ESIC-IOFINCLUSO */
            _.Move("S", V0ESIC_IOFINCLUSO);

            /*" -875- MOVE ' ' TO V0ESIC-RECIOF */
            _.Move(" ", V0ESIC_RECIOF);

            /*" -876- MOVE V1ENDO-CODCLIEN TO V0ESIC-CODCLIEN */
            _.Move(V1ENDO_CODCLIEN, V0ESIC_CODCLIEN);

            /*" -878- MOVE V1ENDO-OCORR-END TO V0ESIC-OCORR-END */
            _.Move(V1ENDO_OCORR_END, V0ESIC_OCORR_END);

            /*" -879- IF V1ENDO-RAMO EQUAL 40 OR 45 OR 75 */

            if (V1ENDO_RAMO.In("40", "45", "75"))
            {

                /*" -880- PERFORM R2100-00-SELECT-V0TOMADOR */

                R2100_00_SELECT_V0TOMADOR_SECTION();

                /*" -881- IF WTEM-TOMADOR EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_TOMADOR == "S")
                {

                    /*" -882- MOVE V0TOMA-CODCLIEN TO V0ESIC-CODCLIEN */
                    _.Move(V0TOMA_CODCLIEN, V0ESIC_CODCLIEN);

                    /*" -884- MOVE V0TOMA-OCORR-END TO V0ESIC-OCORR-END. */
                    _.Move(V0TOMA_OCORR_END, V0ESIC_OCORR_END);
                }

            }


            /*" -885- MOVE V1ENDO-CODPRODU TO V0ESIC-CODPRODU */
            _.Move(V1ENDO_CODPRODU, V0ESIC_CODPRODU);

            /*" -886- MOVE ' ' TO V0ESIC-CODPGM */
            _.Move(" ", V0ESIC_CODPGM);

            /*" -887- MOVE ZEROS TO V0ESIC-CODMENS */
            _.Move(0, V0ESIC_CODMENS);

            /*" -888- MOVE '0' TO V0ESIC-SITUACAO */
            _.Move("0", V0ESIC_SITUACAO);

            /*" -890- MOVE V1SIST-DTMOVABE TO V0ESIC-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0ESIC_DTMOVTO);

            /*" -892- PERFORM R3000-00-INSERT-V0EMISICOB. */

            R3000_00_INSERT_V0EMISICOB_SECTION();

            /*" -892- PERFORM R4000-00-TRATAR-NOSSO-NUMERO. */

            R4000_00_TRATAR_NOSSO_NUMERO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2000_50_LEITURA */

            R2000_50_LEITURA();

        }

        [StopWatch]
        /*" R2000-50-LEITURA */
        private void R2000_50_LEITURA(bool isPerform = false)
        {
            /*" -898- PERFORM R1510-00-FETCH-V1PARCELA. */

            R1510_00_FETCH_V1PARCELA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V0TOMADOR-SECTION */
        private void R2100_00_SELECT_V0TOMADOR_SECTION()
        {
            /*" -911- MOVE 'R2100' TO WNR-EXEC-SQL. */
            _.Move("R2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -919- PERFORM R2100_00_SELECT_V0TOMADOR_DB_SELECT_1 */

            R2100_00_SELECT_V0TOMADOR_DB_SELECT_1();

            /*" -922- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -923- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -924- MOVE 'N' TO WTEM-TOMADOR */
                    _.Move("N", AREA_DE_WORK.WTEM_TOMADOR);

                    /*" -925- ELSE */
                }
                else
                {


                    /*" -926- DISPLAY 'EM0229B - ERRO NO ACESSO A V0TOMADOR' */
                    _.Display($"EM0229B - ERRO NO ACESSO A V0TOMADOR");

                    /*" -927- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -928- ELSE */
                }

            }
            else
            {


                /*" -928- MOVE 'S' TO WTEM-TOMADOR. */
                _.Move("S", AREA_DE_WORK.WTEM_TOMADOR);
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-V0TOMADOR-DB-SELECT-1 */
        public void R2100_00_SELECT_V0TOMADOR_DB_SELECT_1()
        {
            /*" -919- EXEC SQL SELECT COD_CLIENTE , OCORR_ENDERECO INTO :V0TOMA-CODCLIEN , :V0TOMA-OCORR-END FROM SEGUROS.V0TOMADOR WHERE FONTE = :V1ENDO-FONTE AND NRPROPOS = :V1ENDO-NRPROPOS END-EXEC. */

            var r2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1 = new R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1()
            {
                V1ENDO_NRPROPOS = V1ENDO_NRPROPOS.ToString(),
                V1ENDO_FONTE = V1ENDO_FONTE.ToString(),
            };

            var executed_1 = R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0TOMA_CODCLIEN, V0TOMA_CODCLIEN);
                _.Move(executed_1.V0TOMA_OCORR_END, V0TOMA_OCORR_END);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-V1SUBGRUPO-SECTION */
        private void R2700_00_SELECT_V1SUBGRUPO_SECTION()
        {
            /*" -941- MOVE 'R2700' TO WNR-EXEC-SQL. */
            _.Move("R2700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -949- PERFORM R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1 */

            R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1();

            /*" -952- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -954- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -955- ELSE */
                }
                else
                {


                    /*" -956- DISPLAY 'EM0229B - ERRO NO ACESSO A V1SUBGRUPO' */
                    _.Display($"EM0229B - ERRO NO ACESSO A V1SUBGRUPO");

                    /*" -957- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -958- ELSE */
                }

            }
            else
            {


                /*" -959- MOVE V1SUBG-CODCLIEN TO V1ENDO-CODCLIEN */
                _.Move(V1SUBG_CODCLIEN, V1ENDO_CODCLIEN);

                /*" -959- MOVE V1SUBG-OCORR-END TO V1ENDO-OCORR-END. */
                _.Move(V1SUBG_OCORR_END, V1ENDO_OCORR_END);
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-V1SUBGRUPO-DB-SELECT-1 */
        public void R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -949- EXEC SQL SELECT COD_CLIENTE , OCORR_END_COBRAN INTO :V1SUBG-CODCLIEN , :V1SUBG-OCORR-END FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND COD_SUBGRUPO = :V1ENDO-CODSUBES END-EXEC. */

            var r2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 = new R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1()
            {
                V1ENDO_CODSUBES = V1ENDO_CODSUBES.ToString(),
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
            };

            var executed_1 = R2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SUBG_CODCLIEN, V1SUBG_CODCLIEN);
                _.Move(executed_1.V1SUBG_OCORR_END, V1SUBG_OCORR_END);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-V0EMISICOB-SECTION */
        private void R3000_00_INSERT_V0EMISICOB_SECTION()
        {
            /*" -973- MOVE 'R3000' TO WNR-EXEC-SQL. */
            _.Move("R3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1002- PERFORM R3000_00_INSERT_V0EMISICOB_DB_INSERT_1 */

            R3000_00_INSERT_V0EMISICOB_DB_INSERT_1();

            /*" -1005- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1006- DISPLAY ' DADOS DO INSERT NA SEGUROS.V0EMISICOB ------' */
                _.Display($" DADOS DO INSERT NA SEGUROS.V0EMISICOB ------");

                /*" -1007- DISPLAY 'V0ESIC-NRTIT     = ' V0ESIC-NRTIT */
                _.Display($"V0ESIC-NRTIT     = {V0ESIC_NRTIT}");

                /*" -1008- DISPLAY 'V0ESIC-CODCDT    = ' V0ESIC-CODCDT */
                _.Display($"V0ESIC-CODCDT    = {V0ESIC_CODCDT}");

                /*" -1009- DISPLAY 'V0ESIC-NUMAPOL   = ' V0ESIC-NUMAPOL */
                _.Display($"V0ESIC-NUMAPOL   = {V0ESIC_NUMAPOL}");

                /*" -1010- DISPLAY 'V0ESIC-NRENDOS   = ' V0ESIC-NRENDOS */
                _.Display($"V0ESIC-NRENDOS   = {V0ESIC_NRENDOS}");

                /*" -1011- DISPLAY 'V0ESIC-NRCERTIF  = ' V0ESIC-NRCERTIF */
                _.Display($"V0ESIC-NRCERTIF  = {V0ESIC_NRCERTIF}");

                /*" -1012- DISPLAY 'V0ESIC-FONTE     = ' V0ESIC-FONTE */
                _.Display($"V0ESIC-FONTE     = {V0ESIC_FONTE}");

                /*" -1013- DISPLAY 'V0ESIC-NRPROPOS  = ' V0ESIC-NRPROPOS */
                _.Display($"V0ESIC-NRPROPOS  = {V0ESIC_NRPROPOS}");

                /*" -1014- DISPLAY 'V0ESIC-NRCARNE   = ' V0ESIC-NRCARNE */
                _.Display($"V0ESIC-NRCARNE   = {V0ESIC_NRCARNE}");

                /*" -1015- DISPLAY 'V0ESIC-NRPARCEL  = ' V0ESIC-NRPARCEL */
                _.Display($"V0ESIC-NRPARCEL  = {V0ESIC_NRPARCEL}");

                /*" -1016- DISPLAY 'V0ESIC-QTPARCEL  = ' V0ESIC-QTPARCEL */
                _.Display($"V0ESIC-QTPARCEL  = {V0ESIC_QTPARCEL}");

                /*" -1017- DISPLAY 'V0ESIC-DTVENCTO  = ' V0ESIC-DTVENCTO */
                _.Display($"V0ESIC-DTVENCTO  = {V0ESIC_DTVENCTO}");

                /*" -1018- DISPLAY 'V0ESIC-NRDOCTO   = ' V0ESIC-NRDOCTO */
                _.Display($"V0ESIC-NRDOCTO   = {V0ESIC_NRDOCTO}");

                /*" -1019- DISPLAY 'V0ESIC-DTDOCTO   = ' V0ESIC-DTDOCTO */
                _.Display($"V0ESIC-DTDOCTO   = {V0ESIC_DTDOCTO}");

                /*" -1020- DISPLAY 'V0ESIC-CORRECAO  = ' V0ESIC-CORRECAO */
                _.Display($"V0ESIC-CORRECAO  = {V0ESIC_CORRECAO}");

                /*" -1021- DISPLAY 'V0ESIC-CODUNIMO  = ' V0ESIC-CODUNIMO */
                _.Display($"V0ESIC-CODUNIMO  = {V0ESIC_CODUNIMO}");

                /*" -1022- DISPLAY 'V0ESIC-VL-PRM-IX = ' V0ESIC-VL-PRM-IX */
                _.Display($"V0ESIC-VL-PRM-IX = {V0ESIC_VL_PRM_IX}");

                /*" -1023- DISPLAY 'V0ESIC-VL-PRM-VAR= ' V0ESIC-VL-PRM-VAR */
                _.Display($"V0ESIC-VL-PRM-VAR= {V0ESIC_VL_PRM_VAR}");

                /*" -1024- DISPLAY 'V0ESIC-RECVENCTO = ' V0ESIC-RECVENCTO */
                _.Display($"V0ESIC-RECVENCTO = {V0ESIC_RECVENCTO}");

                /*" -1025- DISPLAY 'V0ESIC-IOFINCLUSO= ' V0ESIC-IOFINCLUSO */
                _.Display($"V0ESIC-IOFINCLUSO= {V0ESIC_IOFINCLUSO}");

                /*" -1026- DISPLAY 'V0ESIC-RECIOF    = ' V0ESIC-RECIOF */
                _.Display($"V0ESIC-RECIOF    = {V0ESIC_RECIOF}");

                /*" -1027- DISPLAY 'V0ESIC-CODCLIEN  = ' V0ESIC-CODCLIEN */
                _.Display($"V0ESIC-CODCLIEN  = {V0ESIC_CODCLIEN}");

                /*" -1028- DISPLAY 'V0ESIC-OCORR-END = ' V0ESIC-OCORR-END */
                _.Display($"V0ESIC-OCORR-END = {V0ESIC_OCORR_END}");

                /*" -1029- DISPLAY 'V0ESIC-CODPRODU  = ' V0ESIC-CODPRODU */
                _.Display($"V0ESIC-CODPRODU  = {V0ESIC_CODPRODU}");

                /*" -1030- DISPLAY 'V0ESIC-CODPGM    = ' V0ESIC-CODPGM */
                _.Display($"V0ESIC-CODPGM    = {V0ESIC_CODPGM}");

                /*" -1031- DISPLAY 'V0ESIC-CODMENS   = ' V0ESIC-CODMENS */
                _.Display($"V0ESIC-CODMENS   = {V0ESIC_CODMENS}");

                /*" -1032- DISPLAY 'V0ESIC-SITUACAO  = ' V0ESIC-SITUACAO */
                _.Display($"V0ESIC-SITUACAO  = {V0ESIC_SITUACAO}");

                /*" -1033- DISPLAY 'V0ESIC-DTMOVTO   = ' V0ESIC-DTMOVTO */
                _.Display($"V0ESIC-DTMOVTO   = {V0ESIC_DTMOVTO}");

                /*" -1034- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -1036- END-IF */
            }


            /*" -1037- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1038- DISPLAY 'EM0229B    - ERRO INSERT V0EMISICOB ' */
                _.Display($"EM0229B    - ERRO INSERT V0EMISICOB ");

                /*" -1039- DISPLAY 'APOLICE    -' V0ESIC-NUMAPOL */
                _.Display($"APOLICE    -{V0ESIC_NUMAPOL}");

                /*" -1040- DISPLAY 'ENDOSSO    -' V0ESIC-NRENDOS */
                _.Display($"ENDOSSO    -{V0ESIC_NRENDOS}");

                /*" -1041- DISPLAY 'PARCELA    -' V0ESIC-NRPARCEL */
                _.Display($"PARCELA    -{V0ESIC_NRPARCEL}");

                /*" -1042- DISPLAY 'VENCIMENTO -' V0ESIC-DTVENCTO */
                _.Display($"VENCIMENTO -{V0ESIC_DTVENCTO}");

                /*" -1043- DISPLAY 'EMISSAO    -' V0ESIC-DTDOCTO */
                _.Display($"EMISSAO    -{V0ESIC_DTDOCTO}");

                /*" -1044- DISPLAY 'DTMOVTO    -' V0ESIC-DTMOVTO */
                _.Display($"DTMOVTO    -{V0ESIC_DTMOVTO}");

                /*" -1046- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1046- ADD 1 TO AC-G-V0EMISICOB. */
            AREA_DE_WORK.AC_G_V0EMISICOB.Value = AREA_DE_WORK.AC_G_V0EMISICOB + 1;

        }

        [StopWatch]
        /*" R3000-00-INSERT-V0EMISICOB-DB-INSERT-1 */
        public void R3000_00_INSERT_V0EMISICOB_DB_INSERT_1()
        {
            /*" -1002- EXEC SQL INSERT INTO SEGUROS.V0EMISICOB VALUES (:V0ESIC-NRTIT, :V0ESIC-CODCDT, :V0ESIC-NUMAPOL, :V0ESIC-NRENDOS, :V0ESIC-NRCERTIF, :V0ESIC-FONTE, :V0ESIC-NRPROPOS, :V0ESIC-NRCARNE, :V0ESIC-NRPARCEL, :V0ESIC-QTPARCEL, :V0ESIC-DTVENCTO, :V0ESIC-NRDOCTO, :V0ESIC-DTDOCTO, :V0ESIC-CORRECAO, :V0ESIC-CODUNIMO, :V0ESIC-VL-PRM-IX, :V0ESIC-VL-PRM-VAR, :V0ESIC-RECVENCTO, :V0ESIC-IOFINCLUSO, :V0ESIC-RECIOF, :V0ESIC-CODCLIEN, :V0ESIC-OCORR-END, :V0ESIC-CODPRODU, :V0ESIC-CODPGM, :V0ESIC-CODMENS, :V0ESIC-SITUACAO, CURRENT TIMESTAMP, :V0ESIC-DTMOVTO) END-EXEC. */

            var r3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1 = new R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1()
            {
                V0ESIC_NRTIT = V0ESIC_NRTIT.ToString(),
                V0ESIC_CODCDT = V0ESIC_CODCDT.ToString(),
                V0ESIC_NUMAPOL = V0ESIC_NUMAPOL.ToString(),
                V0ESIC_NRENDOS = V0ESIC_NRENDOS.ToString(),
                V0ESIC_NRCERTIF = V0ESIC_NRCERTIF.ToString(),
                V0ESIC_FONTE = V0ESIC_FONTE.ToString(),
                V0ESIC_NRPROPOS = V0ESIC_NRPROPOS.ToString(),
                V0ESIC_NRCARNE = V0ESIC_NRCARNE.ToString(),
                V0ESIC_NRPARCEL = V0ESIC_NRPARCEL.ToString(),
                V0ESIC_QTPARCEL = V0ESIC_QTPARCEL.ToString(),
                V0ESIC_DTVENCTO = V0ESIC_DTVENCTO.ToString(),
                V0ESIC_NRDOCTO = V0ESIC_NRDOCTO.ToString(),
                V0ESIC_DTDOCTO = V0ESIC_DTDOCTO.ToString(),
                V0ESIC_CORRECAO = V0ESIC_CORRECAO.ToString(),
                V0ESIC_CODUNIMO = V0ESIC_CODUNIMO.ToString(),
                V0ESIC_VL_PRM_IX = V0ESIC_VL_PRM_IX.ToString(),
                V0ESIC_VL_PRM_VAR = V0ESIC_VL_PRM_VAR.ToString(),
                V0ESIC_RECVENCTO = V0ESIC_RECVENCTO.ToString(),
                V0ESIC_IOFINCLUSO = V0ESIC_IOFINCLUSO.ToString(),
                V0ESIC_RECIOF = V0ESIC_RECIOF.ToString(),
                V0ESIC_CODCLIEN = V0ESIC_CODCLIEN.ToString(),
                V0ESIC_OCORR_END = V0ESIC_OCORR_END.ToString(),
                V0ESIC_CODPRODU = V0ESIC_CODPRODU.ToString(),
                V0ESIC_CODPGM = V0ESIC_CODPGM.ToString(),
                V0ESIC_CODMENS = V0ESIC_CODMENS.ToString(),
                V0ESIC_SITUACAO = V0ESIC_SITUACAO.ToString(),
                V0ESIC_DTMOVTO = V0ESIC_DTMOVTO.ToString(),
            };

            R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1.Execute(r3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATAR-NOSSO-NUMERO-SECTION */
        private void R4000_00_TRATAR_NOSSO_NUMERO_SECTION()
        {
            /*" -1059- MOVE 'R4000' TO WNR-EXEC-SQL. */
            _.Move("R4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1061- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -1062- MOVE 02 TO LK-GE350-COD-FUNCAO */
            _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -1063- MOVE V1EDIA-NUMAPOL TO LK-GE350-NUM-APOLICE */
            _.Move(V1EDIA_NUMAPOL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -1065- MOVE V0PARC-NRTIT TO LK-GE350-NUM-CERTIFICADO LK-GE350-NUM-TITULO */
            _.Move(V0PARC_NRTIT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

            /*" -1066- MOVE V0PARC-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(V0PARC_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -1067- MOVE V1EDIA-NRENDOS TO LK-GE350-NUM-ENDOSSO */
            _.Move(V1EDIA_NRENDOS, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -1068- MOVE V1ENDO-NRPROPOS TO LK-GE350-NUM-PROPOSTA */
            _.Move(V1ENDO_NRPROPOS, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -1069- MOVE V1SIST-DTMOVABE TO LK-GE350-DTA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -1070- MOVE ZEROS TO LK-GE350-NUM-OCORR-MOVTO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

            /*" -1071- MOVE V1ENDO-CODPRODU TO LK-GE350-COD-PRODUTO */
            _.Move(V1ENDO_CODPRODU, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -1072- MOVE V0PARC-DTVENCTO TO LK-GE350-DTA-VENCIMENTO */
            _.Move(V0PARC_DTVENCTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -1073- MOVE V0PARC-VLPRMTOT TO LK-GE350-VLR-PREMIO-TOTAL */
            _.Move(V0PARC_VLPRMTOT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

            /*" -1074- MOVE ZEROS TO LK-GE350-VLR-IOF */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

            /*" -1077- COMPUTE LK-GE350-VLR-IOF = (LK-GE350-VLR-PREMIO-TOTAL * 0.0038) */
            LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF.Value = (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL * 0.0038);

            /*" -1078- IF V1ENDO-QTPARCEL = ZEROS */

            if (V1ENDO_QTPARCEL == 00)
            {

                /*" -1079- MOVE 1 TO LK-GE350-QTD-PARCELA */
                _.Move(1, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

                /*" -1080- ELSE */
            }
            else
            {


                /*" -1081- MOVE V1ENDO-QTPARCEL TO LK-GE350-QTD-PARCELA */
                _.Move(V1ENDO_QTPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

                /*" -1083- END-IF */
            }


            /*" -1084- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -1086- MOVE V1ENDO-CODCLIEN TO LK-GE350-COD-CLIENTE */
            _.Move(V1ENDO_CODCLIEN, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -1087- MOVE 'EF' TO LK-GE350-IDE-SISTEMA */
            _.Move("EF", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -1088- MOVE 'EM0229B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0229B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -1090- MOVE 'P' TO LK-GE350-COD-SITUACAO */
            _.Move("P", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -1091- DISPLAY 'EM0229B - ANTES DO CALL NA GE0350S ' */
            _.Display($"EM0229B - ANTES DO CALL NA GE0350S ");

            /*" -1093- DISPLAY ' ' */
            _.Display($" ");

            /*" -1095- PERFORM R4100-00-DISPLAY-DADOS */

            R4100_00_DISPLAY_DADOS_SECTION();

            /*" -1097- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -1098- IF (LK-GE350-COD-RETORNO NOT EQUAL '0' ) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0"))
            {

                /*" -1099- DISPLAY ' ' */
                _.Display($" ");

                /*" -1100- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1101- DISPLAY '*    R4000-00-TRATAR-NOSSO-NUMERO       *' */
                _.Display($"*    R4000-00-TRATAR-NOSSO-NUMERO       *");

                /*" -1102- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -1103- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1104- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -1105- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -1106- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -1107- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1108- PERFORM R4100-00-DISPLAY-DADOS */

                R4100_00_DISPLAY_DADOS_SECTION();

                /*" -1109- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1110- END-IF. */
            }


            /*" -1110- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-DISPLAY-DADOS-SECTION */
        private void R4100_00_DISPLAY_DADOS_SECTION()
        {
            /*" -1117- MOVE 'R4100' TO WNR-EXEC-SQL. */
            _.Move("R4100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1118- DISPLAY '-- EM0229B - DADOS ENVIADOS PARA ROTINA GE0350S' */
            _.Display($"-- EM0229B - DADOS ENVIADOS PARA ROTINA GE0350S");

            /*" -1120- DISPLAY 'LK-GE350-COD-FUNCAO       = ' LK-GE350-COD-FUNCAO */
            _.Display($"LK-GE350-COD-FUNCAO       = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

            /*" -1122- DISPLAY 'LK-GE350-NUM-APOLICE      = ' LK-GE350-NUM-APOLICE */
            _.Display($"LK-GE350-NUM-APOLICE      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

            /*" -1124- DISPLAY 'LK-GE350-NUM-CERTIFICADO  = ' LK-GE350-NUM-CERTIFICADO */
            _.Display($"LK-GE350-NUM-CERTIFICADO  = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

            /*" -1126- DISPLAY 'LK-GE350-NUM-PARCELA      = ' LK-GE350-NUM-PARCELA */
            _.Display($"LK-GE350-NUM-PARCELA      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

            /*" -1128- DISPLAY 'LK-GE350-NUM-ENDOSSO      = ' LK-GE350-NUM-ENDOSSO */
            _.Display($"LK-GE350-NUM-ENDOSSO      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

            /*" -1130- DISPLAY 'LK-GE350-NUM-PROPOSTA     = ' LK-GE350-NUM-PROPOSTA */
            _.Display($"LK-GE350-NUM-PROPOSTA     = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

            /*" -1132- DISPLAY 'LK-GE350-DTA-MOVIMENTO    = ' , LK-GE350-DTA-MOVIMENTO */

            $"LK-GE350-DTA-MOVIMENTO    = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.FILLER}{LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}"
            .Display();

            /*" -1134- DISPLAY 'LK-GE350-NUM-OCORR-MOVTO  = ' LK-GE350-NUM-OCORR-MOVTO */
            _.Display($"LK-GE350-NUM-OCORR-MOVTO  = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}");

            /*" -1136- DISPLAY 'LK-GE350-COD-PRODUTO      = ' LK-GE350-COD-PRODUTO */
            _.Display($"LK-GE350-COD-PRODUTO      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}");

            /*" -1138- DISPLAY 'LK-GE350-DTA-VENCIMENTO   = ' LK-GE350-DTA-VENCIMENTO */
            _.Display($"LK-GE350-DTA-VENCIMENTO   = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

            /*" -1140- DISPLAY 'LK-GE350-VLR-PREMIO-TOTAL = ' LK-GE350-VLR-PREMIO-TOTAL */
            _.Display($"LK-GE350-VLR-PREMIO-TOTAL = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}");

            /*" -1142- DISPLAY 'LK-GE350-QTD-PARCELA      = ' LK-GE350-QTD-PARCELA */
            _.Display($"LK-GE350-QTD-PARCELA      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}");

            /*" -1144- DISPLAY 'LK-GE350-QTD-DIAS-CUSTODIA= ' LK-GE350-QTD-DIAS-CUSTODIA */
            _.Display($"LK-GE350-QTD-DIAS-CUSTODIA= {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

            /*" -1146- DISPLAY 'LK-GE350-COD-CLIENTE      = ' LK-GE350-COD-CLIENTE */
            _.Display($"LK-GE350-COD-CLIENTE      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

            /*" -1148- DISPLAY 'LK-GE350-VLR-IOF          = ' LK-GE350-VLR-IOF */
            _.Display($"LK-GE350-VLR-IOF          = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF}");

            /*" -1150- DISPLAY 'LK-GE350-IDE-SISTEMA      = ' LK-GE350-IDE-SISTEMA */
            _.Display($"LK-GE350-IDE-SISTEMA      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA}");

            /*" -1152- DISPLAY 'LK-GE350-COD-USUARIO      = ' LK-GE350-COD-USUARIO */
            _.Display($"LK-GE350-COD-USUARIO      = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO}");

            /*" -1154- DISPLAY 'LK-GE350-COD-SITUACAO     = ' LK-GE350-COD-SITUACAO */
            _.Display($"LK-GE350-COD-SITUACAO     = {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}");

            /*" -1155- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -1155- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1193- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1194- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1195- DISPLAY '*  EM0229B - GERA ARQUIVO DE BLOQUETES       *' */
            _.Display($"*  EM0229B - GERA ARQUIVO DE BLOQUETES       *");

            /*" -1196- DISPLAY '*            (COM CODIGO DE BARRAS)          *' */
            _.Display($"*            (COM CODIGO DE BARRAS)          *");

            /*" -1197- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1198- DISPLAY '*            NAO HOUVE SOLICITACOES          *' */
            _.Display($"*            NAO HOUVE SOLICITACOES          *");

            /*" -1199- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1199- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1214- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1216- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1216- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1218- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1222- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1222- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/

        [StopWatch]
        /*" S1000-00-VERIFICA-2VIA-SECTION */
        private void S1000_00_VERIFICA_2VIA_SECTION()
        {
            /*" -1235- MOVE 'S1000' TO WNR-EXEC-SQL. */
            _.Move("S1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1237- PERFORM S2000-00-DECLARE-V1RELATORIOS */

            S2000_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -1238- PERFORM S2100-00-FETCH-V1RELATORIOS */

            S2100_00_FETCH_V1RELATORIOS_SECTION();

            /*" -1239- IF WFIM-V1RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty())
            {

                /*" -1241- GO TO S1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: S1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1244- PERFORM S3000-00-PROCESSA-REGISTRO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty()))
            {

                S3000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1244- PERFORM S4000-00-DELETE-V0RELATORIOS. */

            S4000_00_DELETE_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S1000_99_SAIDA*/

        [StopWatch]
        /*" S2000-00-DECLARE-V1RELATORIOS-SECTION */
        private void S2000_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -1257- MOVE 'S2000' TO WNR-EXEC-SQL. */
            _.Move("S2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1271- PERFORM S2000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            S2000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -1273- PERFORM S2000_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            S2000_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" S2000-00-DECLARE-V1RELATORIOS-DB-OPEN-1 */
        public void S2000_00_DECLARE_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -1273- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S2000_99_SAIDA*/

        [StopWatch]
        /*" S2100-00-FETCH-V1RELATORIOS-SECTION */
        private void S2100_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -1286- MOVE 'S2100' TO WNR-EXEC-SQL. */
            _.Move("S2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1297- PERFORM S2100_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            S2100_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -1300- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1301- MOVE 'S' TO WFIM-V1RELATORIOS */
                _.Move("S", AREA_DE_WORK.WFIM_V1RELATORIOS);

                /*" -1301- PERFORM S2100_00_FETCH_V1RELATORIOS_DB_CLOSE_1 */

                S2100_00_FETCH_V1RELATORIOS_DB_CLOSE_1();

                /*" -1302- GO TO S2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: S2100_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" S2100-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void S2100_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -1297- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-CODRELAT , :V1RELA-NUM-APOL , :V1RELA-NRENDOS , :V1RELA-NRPARCEL , :V1RELA-DTSOLIC , :V1RELA-ORGAO , :V1RELA-RAMO , :V1RELA-FONTE , :V1RELA-CONGENER , :V1RELA-CODPDT END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_CODRELAT, V1RELA_CODRELAT);
                _.Move(V1RELATORIOS.V1RELA_NUM_APOL, V1RELA_NUM_APOL);
                _.Move(V1RELATORIOS.V1RELA_NRENDOS, V1RELA_NRENDOS);
                _.Move(V1RELATORIOS.V1RELA_NRPARCEL, V1RELA_NRPARCEL);
                _.Move(V1RELATORIOS.V1RELA_DTSOLIC, V1RELA_DTSOLIC);
                _.Move(V1RELATORIOS.V1RELA_ORGAO, V1RELA_ORGAO);
                _.Move(V1RELATORIOS.V1RELA_RAMO, V1RELA_RAMO);
                _.Move(V1RELATORIOS.V1RELA_FONTE, V1RELA_FONTE);
                _.Move(V1RELATORIOS.V1RELA_CONGENER, V1RELA_CONGENER);
                _.Move(V1RELATORIOS.V1RELA_CODPDT, V1RELA_CODPDT);
            }

        }

        [StopWatch]
        /*" S2100-00-FETCH-V1RELATORIOS-DB-CLOSE-1 */
        public void S2100_00_FETCH_V1RELATORIOS_DB_CLOSE_1()
        {
            /*" -1301- EXEC SQL CLOSE V1RELATORIOS END-EXEC */

            V1RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S2100_99_SAIDA*/

        [StopWatch]
        /*" S3000-00-PROCESSA-REGISTRO-SECTION */
        private void S3000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1315- MOVE 'S3000' TO WNR-EXEC-SQL. */
            _.Move("S3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1316- MOVE 'EM0230B2' TO V1EDIA-CODRELAT */
            _.Move("EM0230B2", V1EDIA_CODRELAT);

            /*" -1317- MOVE V1RELA-NUM-APOL TO V1EDIA-NUMAPOL */
            _.Move(V1RELA_NUM_APOL, V1EDIA_NUMAPOL);

            /*" -1318- MOVE V1RELA-NRENDOS TO V1EDIA-NRENDOS */
            _.Move(V1RELA_NRENDOS, V1EDIA_NRENDOS);

            /*" -1320- MOVE V1RELA-NRPARCEL TO V1EDIA-NRPARCEL */
            _.Move(V1RELA_NRPARCEL, V1EDIA_NRPARCEL);

            /*" -1321- MOVE V1SIST-DTMOVABE TO V1EDIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V1EDIA_DTMOVTO);

            /*" -1322- MOVE V1RELA-ORGAO TO V1EDIA-ORGAO */
            _.Move(V1RELA_ORGAO, V1EDIA_ORGAO);

            /*" -1323- MOVE V1RELA-RAMO TO V1EDIA-RAMO */
            _.Move(V1RELA_RAMO, V1EDIA_RAMO);

            /*" -1324- MOVE V1RELA-FONTE TO V1EDIA-FONTE */
            _.Move(V1RELA_FONTE, V1EDIA_FONTE);

            /*" -1325- MOVE ZEROS TO V1EDIA-CONGENER */
            _.Move(0, V1EDIA_CONGENER);

            /*" -1326- MOVE ZEROS TO V1EDIA-CODCORR */
            _.Move(0, V1EDIA_CODCORR);

            /*" -1327- MOVE '0' TO V1EDIA-SITUACAO */
            _.Move("0", V1EDIA_SITUACAO);

            /*" -1329- MOVE ZEROS TO V1EDIA-COD-EMP */
            _.Move(0, V1EDIA_COD_EMP);

            /*" -1344- PERFORM S3000_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            S3000_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -1347- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1348- DISPLAY ' DADOS DO INSERT NA SEGUROS.V0EMISDIARIA ------' */
                _.Display($" DADOS DO INSERT NA SEGUROS.V0EMISDIARIA ------");

                /*" -1349- DISPLAY 'V1EDIA-CODRELAT= ' V1EDIA-CODRELAT */
                _.Display($"V1EDIA-CODRELAT= {V1EDIA_CODRELAT}");

                /*" -1350- DISPLAY 'V1EDIA-NUMAPOL = ' V1EDIA-NUMAPOL */
                _.Display($"V1EDIA-NUMAPOL = {V1EDIA_NUMAPOL}");

                /*" -1351- DISPLAY 'V1EDIA-NRENDOS = ' V1EDIA-NRENDOS */
                _.Display($"V1EDIA-NRENDOS = {V1EDIA_NRENDOS}");

                /*" -1352- DISPLAY 'V1EDIA-NRPARCEL= ' V1EDIA-NRPARCEL */
                _.Display($"V1EDIA-NRPARCEL= {V1EDIA_NRPARCEL}");

                /*" -1353- DISPLAY 'V1EDIA-DTMOVTO = ' V1EDIA-DTMOVTO */
                _.Display($"V1EDIA-DTMOVTO = {V1EDIA_DTMOVTO}");

                /*" -1354- DISPLAY 'V1EDIA-ORGAO   = ' V1EDIA-ORGAO */
                _.Display($"V1EDIA-ORGAO   = {V1EDIA_ORGAO}");

                /*" -1355- DISPLAY 'V1EDIA-RAMO    = ' V1EDIA-RAMO */
                _.Display($"V1EDIA-RAMO    = {V1EDIA_RAMO}");

                /*" -1356- DISPLAY 'V1EDIA-FONTE   = ' V1EDIA-FONTE */
                _.Display($"V1EDIA-FONTE   = {V1EDIA_FONTE}");

                /*" -1357- DISPLAY 'V1EDIA-CONGENER= ' V1EDIA-CONGENER */
                _.Display($"V1EDIA-CONGENER= {V1EDIA_CONGENER}");

                /*" -1358- DISPLAY 'V1EDIA-CODCORR = ' V1EDIA-CODCORR */
                _.Display($"V1EDIA-CODCORR = {V1EDIA_CODCORR}");

                /*" -1359- DISPLAY 'V1EDIA-SITUACAO= ' V1EDIA-SITUACAO */
                _.Display($"V1EDIA-SITUACAO= {V1EDIA_SITUACAO}");

                /*" -1360- DISPLAY 'V1EDIA-COD-EMP = ' V1EDIA-COD-EMP */
                _.Display($"V1EDIA-COD-EMP = {V1EDIA_COD_EMP}");

                /*" -1361- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -1363- END-IF */
            }


            /*" -1364- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1365- DISPLAY 'EM0229B - (PROBLEMAS INSERT V0EMISDIARIA) ' */
                _.Display($"EM0229B - (PROBLEMAS INSERT V0EMISDIARIA) ");

                /*" -1366- DISPLAY 'V1EDIA-CODRELAT= ' V1EDIA-CODRELAT */
                _.Display($"V1EDIA-CODRELAT= {V1EDIA_CODRELAT}");

                /*" -1367- DISPLAY 'V1EDIA-NUMAPOL = ' V1EDIA-NUMAPOL */
                _.Display($"V1EDIA-NUMAPOL = {V1EDIA_NUMAPOL}");

                /*" -1368- DISPLAY 'V1EDIA-NRENDOS = ' V1EDIA-NRENDOS */
                _.Display($"V1EDIA-NRENDOS = {V1EDIA_NRENDOS}");

                /*" -1369- DISPLAY 'V1EDIA-NRPARCEL= ' V1EDIA-NRPARCEL */
                _.Display($"V1EDIA-NRPARCEL= {V1EDIA_NRPARCEL}");

                /*" -1370- DISPLAY 'V1EDIA-DTMOVTO = ' V1EDIA-DTMOVTO */
                _.Display($"V1EDIA-DTMOVTO = {V1EDIA_DTMOVTO}");

                /*" -1371- DISPLAY 'V1EDIA-ORGAO   = ' V1EDIA-ORGAO */
                _.Display($"V1EDIA-ORGAO   = {V1EDIA_ORGAO}");

                /*" -1372- DISPLAY 'V1EDIA-RAMO    = ' V1EDIA-RAMO */
                _.Display($"V1EDIA-RAMO    = {V1EDIA_RAMO}");

                /*" -1373- DISPLAY 'V1EDIA-FONTE   = ' V1EDIA-FONTE */
                _.Display($"V1EDIA-FONTE   = {V1EDIA_FONTE}");

                /*" -1374- DISPLAY 'V1EDIA-CONGENER= ' V1EDIA-CONGENER */
                _.Display($"V1EDIA-CONGENER= {V1EDIA_CONGENER}");

                /*" -1375- DISPLAY 'V1EDIA-CODCORR = ' V1EDIA-CODCORR */
                _.Display($"V1EDIA-CODCORR = {V1EDIA_CODCORR}");

                /*" -1376- DISPLAY 'V1EDIA-SITUACAO= ' V1EDIA-SITUACAO */
                _.Display($"V1EDIA-SITUACAO= {V1EDIA_SITUACAO}");

                /*" -1377- DISPLAY 'V1EDIA-COD-EMP = ' V1EDIA-COD-EMP */
                _.Display($"V1EDIA-COD-EMP = {V1EDIA_COD_EMP}");

                /*" -1378- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -1380- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1380- PERFORM S2100-00-FETCH-V1RELATORIOS. */

            S2100_00_FETCH_V1RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" S3000-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void S3000_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -1344- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V1EDIA-CODRELAT , :V1EDIA-NUMAPOL , :V1EDIA-NRENDOS , :V1EDIA-NRPARCEL , :V1EDIA-DTMOVTO , :V1EDIA-ORGAO , :V1EDIA-RAMO , :V1EDIA-FONTE , :V1EDIA-CONGENER , :V1EDIA-CODCORR , :V1EDIA-SITUACAO , :V1EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var s3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 = new S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1()
            {
                V1EDIA_CODRELAT = V1EDIA_CODRELAT.ToString(),
                V1EDIA_NUMAPOL = V1EDIA_NUMAPOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
                V1EDIA_NRPARCEL = V1EDIA_NRPARCEL.ToString(),
                V1EDIA_DTMOVTO = V1EDIA_DTMOVTO.ToString(),
                V1EDIA_ORGAO = V1EDIA_ORGAO.ToString(),
                V1EDIA_RAMO = V1EDIA_RAMO.ToString(),
                V1EDIA_FONTE = V1EDIA_FONTE.ToString(),
                V1EDIA_CONGENER = V1EDIA_CONGENER.ToString(),
                V1EDIA_CODCORR = V1EDIA_CODCORR.ToString(),
                V1EDIA_SITUACAO = V1EDIA_SITUACAO.ToString(),
                V1EDIA_COD_EMP = V1EDIA_COD_EMP.ToString(),
            };

            S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1.Execute(s3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S3000_99_SAIDA*/

        [StopWatch]
        /*" S4000-00-DELETE-V0RELATORIOS-SECTION */
        private void S4000_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1393- MOVE 'S40' TO WNR-EXEC-SQL. */
            _.Move("S40", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1397- PERFORM S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1400- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1404- DISPLAY 'S4000-00 (PROBLEMAS DELETE V0RELATORIOS) ' ' ' V1RELA-NUM-APOL ' ' V1RELA-NRENDOS ' ' V1RELA-NRPARCEL */

                $"S4000-00 (PROBLEMAS DELETE V0RELATORIOS)  {V1RELA_NUM_APOL} {V1RELA_NRENDOS} {V1RELA_NRPARCEL}"
                .Display();

                /*" -1404- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" S4000-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1397- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'EM0230B1' AND DATA_SOLICITACAO = :V1SIST-DTMOVABE END-EXEC. */

            var s4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(s4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S4000_99_SAIDA*/
    }
}