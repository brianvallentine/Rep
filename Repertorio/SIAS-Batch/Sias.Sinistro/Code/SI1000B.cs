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
using Sias.Sinistro.DB2.SI1000B;

namespace Code
{
    public class SI1000B
    {
        public bool IsCall { get; set; }

        public SI1000B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI1000B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/1992                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CRIA HISTORICO PARA CORRECAO       *      */
        /*"      *                             MONETARIA (V0HISTSINI)             *      */
        /*"      *                             OPERACAO = 0122                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * COTACAO MOEDAS                      V1MOEDA           INPUT    *      */
        /*"      * MESTRE DE SINISTROS                 V1MESTSINI        INPUT    *      */
        /*"      * HISTORICO SINISTROS                 V0HISTSINI        I/O      *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO - ANO 2000          CONSEDA4           06/06/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19/09/2002 - EDUARDO (PRODEXTER)                               *      */
        /*"      *   ATUALIZA A COLUNA "NOM_PROGRAMA" NA SINISTRO_HISTORICO       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - WELLINGTON VERAS (POLITEC)                         *      */
        /*"      *             PROJETO FGV                                        *      */
        /*"      *                                                                *      */
        /*"      * 01/09/2008  INCLUSAO DA CLAUS. WITH UR NO COMANDO SELECT-WV0908*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-ANOREFER      PIC S9(004)                COMP.*/
        public IntBasis WHOST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-MESREFER      PIC S9(004)                COMP.*/
        public IntBasis WHOST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1MOED-CODUNIMO     PIC S9(004)                COMP.*/
        public IntBasis W1MOED_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1MOED-DTINIVIG     PIC  X(010).*/
        public StringBasis W1MOED_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DATINI        PIC  X(010).*/
        public StringBasis WHOST_DATINI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DATTER        PIC  X(010).*/
        public StringBasis WHOST_DATTER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DATMOV        PIC  X(010).*/
        public StringBasis WHOST_DATMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DATREF        PIC  X(010).*/
        public StringBasis WHOST_DATREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-NUM-APOL      PIC S9(013)                COMP-3*/
        public IntBasis WHOST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WOCORHIST           PIC S9(009)                COMP-3*/
        public IntBasis WOCORHIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1MOED-MESANT       PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1MOED_MESANT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1MOED-MESATU       PIC S9(009)V9(6) VALUE +0  COMP-3*/
        public DoubleBasis W1MOED_MESATU { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(009)V9(6)"), 6);
        /*"77         WPCPARTIC           PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis WPCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         WPCTRES             PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis WPCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         VIND-CORRECAO       PIC S9(004)                COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MOED-VLCRUZAD     PIC S9(006)V9(9)           COMP-3*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1MSIN-TIPREG       PIC  X(001).*/
        public StringBasis V1MSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-PROTSINI     PIC S9(009)                COMP.*/
        public IntBasis V1MSIN_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MSIN-DAC          PIC  X(001).*/
        public StringBasis V1MSIN_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-NUM-SINI     PIC S9(013)                COMP-3*/
        public IntBasis V1MSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1MSIN-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1MSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1MSIN-NRENDOS      PIC S9(009)                COMP-3*/
        public IntBasis V1MSIN_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MSIN-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-NRCERTIF     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_NRCERTIF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-DIGCERT      PIC  X(001).*/
        public StringBasis V1MSIN_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-IDTPSEGU     PIC  X(001).*/
        public StringBasis V1MSIN_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-NREMBARQ     PIC S9(009)                COMP.*/
        public IntBasis V1MSIN_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MSIN-REFEMBQ      PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_REFEMBQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-CODLIDER     PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-SINLID       PIC  X(015).*/
        public StringBasis V1MSIN_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V1MSIN-DATCMD       PIC  X(010).*/
        public StringBasis V1MSIN_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MSIN-DATORR       PIC  X(010).*/
        public StringBasis V1MSIN_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MSIN-DATTEC       PIC  X(010).*/
        public StringBasis V1MSIN_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MSIN-CODCAU       PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-NUMIRB       PIC S9(011)                COMP-3*/
        public IntBasis V1MSIN_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77         V1MSIN-AVIIRB       PIC  X(010).*/
        public StringBasis V1MSIN_AVIIRB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MSIN-COD-MOEDA    PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-CODPRODU     PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MSIN-SDOPAGBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_SDOPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-TOTPAGBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_TOTPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-SDORCPBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_SDORCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-TOTRCPBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_TOTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-SDORSABT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_SDORSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-TOTRSDBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_TOTRSDBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-TOTDSABT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_TOTDSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-TOTHONBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_TOTHONBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-SDOADTBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_SDOADTBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-ADTRCPBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_ADTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-VALSEGBT     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1MSIN-PCPARTIC     PIC S9(004)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1MSIN-PCTRES       PIC S9(004)V9(5)           COMP-3*/
        public DoubleBasis V1MSIN_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1MSIN-APVALD       PIC S9(009)                COMP.*/
        public IntBasis V1MSIN_APVALD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MSIN-APOEND       PIC  X(001).*/
        public StringBasis V1MSIN_APOEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-ORRPOL       PIC  X(001).*/
        public StringBasis V1MSIN_ORRPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CERBOM       PIC  X(001).*/
        public StringBasis V1MSIN_CERBOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-RELRGL       PIC  X(001).*/
        public StringBasis V1MSIN_RELRGL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-INDORC       PIC  X(001).*/
        public StringBasis V1MSIN_INDORC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-NFIREP       PIC  X(001).*/
        public StringBasis V1MSIN_NFIREP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-RELBEN       PIC  X(001).*/
        public StringBasis V1MSIN_RELBEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-VISSIN       PIC  X(001).*/
        public StringBasis V1MSIN_VISSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CERAVA       PIC  X(001).*/
        public StringBasis V1MSIN_CERAVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-FATCMC       PIC  X(001).*/
        public StringBasis V1MSIN_FATCMC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CNHEMB       PIC  X(001).*/
        public StringBasis V1MSIN_CNHEMB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-MFTCGA       PIC  X(001).*/
        public StringBasis V1MSIN_MFTCGA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-DCLIPC       PIC  X(001).*/
        public StringBasis V1MSIN_DCLIPC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CEREXV       PIC  X(001).*/
        public StringBasis V1MSIN_CEREXV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CNTCMB       PIC  X(001).*/
        public StringBasis V1MSIN_CNTCMB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CARPTT       PIC  X(001).*/
        public StringBasis V1MSIN_CARPTT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CERPPR       PIC  X(001).*/
        public StringBasis V1MSIN_CERPPR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-INDTRU       PIC  X(001).*/
        public StringBasis V1MSIN_INDTRU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-INDDPV       PIC  X(001).*/
        public StringBasis V1MSIN_INDDPV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-NGVMUL       PIC  X(001).*/
        public StringBasis V1MSIN_NGVMUL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-RECVDA       PIC  X(001).*/
        public StringBasis V1MSIN_RECVDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-NAOLOC       PIC  X(001).*/
        public StringBasis V1MSIN_NAOLOC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-DCLTCR       PIC  X(001).*/
        public StringBasis V1MSIN_DCLTCR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-ATDOBT       PIC  X(001).*/
        public StringBasis V1MSIN_ATDOBT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CERBFI       PIC  X(001).*/
        public StringBasis V1MSIN_CERBFI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CERSEG       PIC  X(001).*/
        public StringBasis V1MSIN_CERSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CERCMT       PIC  X(001).*/
        public StringBasis V1MSIN_CERCMT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-ALVJUD       PIC  X(001).*/
        public StringBasis V1MSIN_ALVJUD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-EXANCC       PIC  X(001).*/
        public StringBasis V1MSIN_EXANCC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-ATDINV       PIC  X(001).*/
        public StringBasis V1MSIN_ATDINV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-DSAMDC       PIC  X(001).*/
        public StringBasis V1MSIN_DSAMDC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-RCTMDC       PIC  X(001).*/
        public StringBasis V1MSIN_RCTMDC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-CARPRO       PIC  X(001).*/
        public StringBasis V1MSIN_CARPRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-INDSVD       PIC  X(001).*/
        public StringBasis V1MSIN_INDSVD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-PAGITG       PIC  X(001).*/
        public StringBasis V1MSIN_PAGITG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-MOVPCSAT     PIC S9(009)                COMP.*/
        public IntBasis V1MSIN_MOVPCSAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MSIN-MOVPCSAN     PIC S9(009)                COMP.*/
        public IntBasis V1MSIN_MOVPCSAN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MSIN-DTULTMOV     PIC  X(010).*/
        public StringBasis V1MSIN_DTULTMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1MSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1MSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HSIN-COD-EMP      PIC S9(009)                COMP.*/
        public IntBasis V0HSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HSIN-TIPREG       PIC  X(001).*/
        public StringBasis V0HSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HSIN-NUM-SINI     PIC S9(013)                COMP-3*/
        public IntBasis V0HSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HSIN-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0HSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HSIN-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V0HSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HSIN-HORAOPER     PIC  X(008).*/
        public StringBasis V0HSIN_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HSIN-NOMFAV       PIC  X(040).*/
        public StringBasis V0HSIN_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0HSIN-VAL-OPER     PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HSIN-LIMCRR       PIC  X(010).*/
        public StringBasis V0HSIN_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HSIN-TIPFAV       PIC  X(001).*/
        public StringBasis V0HSIN_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HSIN-DATNEG       PIC  X(010).*/
        public StringBasis V0HSIN_DATNEG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HSIN-FONPAG       PIC S9(004)                COMP.*/
        public IntBasis V0HSIN_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HSIN-CODPSVI      PIC S9(009)                COMP.*/
        public IntBasis V0HSIN_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HSIN-CODSVI       PIC S9(004)                COMP.*/
        public IntBasis V0HSIN_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HSIN-NUMOPG       PIC S9(009)                COMP.*/
        public IntBasis V0HSIN_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HSIN-NUMREC       PIC S9(009)                COMP.*/
        public IntBasis V0HSIN_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HSIN-MOVPCS       PIC S9(009)                COMP.*/
        public IntBasis V0HSIN_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HSIN-CODUSU       PIC  X(008).*/
        public StringBasis V0HSIN_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HSIN-SITCONTB     PIC  X(001).*/
        public StringBasis V0HSIN_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V0HSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0HSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0HSIN-DTMOVTO-MAX  PIC  X(010).*/
        public StringBasis V0HSIN_DTMOVTO_MAX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HSIN-VAR-INDICA   PIC S9(004)                 COMP.*/
        public IntBasis V0HSIN_VAR_INDICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HSIN-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0HSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HSIN-CODPRODU     PIC S9(004)                COMP.*/
        public IntBasis V0HSIN_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public SI1000B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI1000B_AREA_DE_WORK();
        public class SI1000B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WRESTO            PIC S9(003)    VALUE +0 COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WSINISTRO         PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WSINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WSINISTRO.*/
            private _REDEF_SI1000B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI1000B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI1000B_FILLER_0(); _.Move(WSINISTRO, _filler_0); VarBasis.RedefinePassValue(WSINISTRO, _filler_0, WSINISTRO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WSINISTRO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WSINISTRO); }
            }  //Redefines
            public class _REDEF_SI1000B_FILLER_0 : VarBasis
            {
                /*"    10       WORGAO            PIC  9(003).*/
                public IntBasis WORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WRAMO             PIC  9(002).*/
                public IntBasis WRAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WNUMSIN           PIC  9(008).*/
                public IntBasis WNUMSIN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WOPERACAO          PIC  9(004)   VALUE ZEROS.*/

                public _REDEF_SI1000B_FILLER_0()
                {
                    WORGAO.ValueChanged += OnValueChanged;
                    WRAMO.ValueChanged += OnValueChanged;
                    WNUMSIN.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WOPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         FILLER             REDEFINES     WOPERACAO.*/
            private _REDEF_SI1000B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_SI1000B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_SI1000B_FILLER_1(); _.Move(WOPERACAO, _filler_1); VarBasis.RedefinePassValue(WOPERACAO, _filler_1, WOPERACAO); _filler_1.ValueChanged += () => { _.Move(_filler_1, WOPERACAO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WOPERACAO); }
            }  //Redefines
            public class _REDEF_SI1000B_FILLER_1 : VarBasis
            {
                /*"    10       WTIPO-OPERACAO     PIC  9(002).*/
                public IntBasis WTIPO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  9(002).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         AC-PENDENTE        PIC S9(013)V99   VALUE +0 COMP-3*/

                public _REDEF_SI1000B_FILLER_1()
                {
                    WTIPO_OPERACAO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis AC_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-INICIAL         PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-CORRECAO        PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_CORRECAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-L-V1MESTSINI   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1MESTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-R-V1MESTSINI   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_R_V1MESTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-P-V1MESTSINI   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_P_V1MESTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0HISTSINI   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0MESTSINI   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0MESTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOEDA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MESTSINI   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1MESTSINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PROCESSO     PIC  X(001)    VALUE LOW-VALUES.*/
            public StringBasis WFIM_PROCESSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05         WREFE-REFERENCIA.*/
            public SI1000B_WREFE_REFERENCIA WREFE_REFERENCIA { get; set; } = new SI1000B_WREFE_REFERENCIA();
            public class SI1000B_WREFE_REFERENCIA : VarBasis
            {
                /*"    10       FILLER            PIC  X(008).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10       WREFE-DIAREFER    PIC  9(002).*/
                public IntBasis WREFE_DIAREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSIST-DATA        PIC  X(010)    VALUE ZEROS.*/
            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA.*/
            private _REDEF_SI1000B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_SI1000B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_SI1000B_FILLER_4(); _.Move(WSIST_DATA, _filler_4); VarBasis.RedefinePassValue(WSIST_DATA, _filler_4, WSIST_DATA); _filler_4.ValueChanged += () => { _.Move(_filler_4, WSIST_DATA); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_SI1000B_FILLER_4 : VarBasis
            {
                /*"    10       WSIST-ANOMES.*/
                public SI1000B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new SI1000B_WSIST_ANOMES();
                public class SI1000B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO          PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WSIS-MES          PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public SI1000B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_5.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DIA          PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         V1SIST-DATA-ANT   PIC  X(010).*/

                public _REDEF_SI1000B_FILLER_4()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis V1SIST_DATA_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         WDATA-AVISO.*/
            public SI1000B_WDATA_AVISO WDATA_AVISO { get; set; } = new SI1000B_WDATA_AVISO();
            public class SI1000B_WDATA_AVISO : VarBasis
            {
                /*"    10       WAVIS-ANOMES.*/
                public SI1000B_WAVIS_ANOMES WAVIS_ANOMES { get; set; } = new SI1000B_WAVIS_ANOMES();
                public class SI1000B_WAVIS_ANOMES : VarBasis
                {
                    /*"      15     WANOMES           PIC  X(007).*/
                    public StringBasis WANOMES { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"    10       FILLER            PIC  X(001).*/
                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DD           PIC  9(002).*/
                public IntBasis WSIS_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-MOVTO.*/
            }
            public SI1000B_WDATA_MOVTO WDATA_MOVTO { get; set; } = new SI1000B_WDATA_MOVTO();
            public class SI1000B_WDATA_MOVTO : VarBasis
            {
                /*"    10       WMOVTO-ANOMES.*/
                public SI1000B_WMOVTO_ANOMES WMOVTO_ANOMES { get; set; } = new SI1000B_WMOVTO_ANOMES();
                public class SI1000B_WMOVTO_ANOMES : VarBasis
                {
                    /*"      15     WANOMES-MOVTO     PIC  X(007).*/
                    public StringBasis WANOMES_MOVTO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"    10       FILLER            PIC  X(001).*/
                }
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-MOV          PIC  9(002).*/
                public IntBasis WSIS_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WAVIS-AVIANT       PIC  X(010)     VALUE SPACES.*/
            }
            public StringBasis WAVIS_AVIANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WDATA-ULTANT       PIC  X(010)     VALUE SPACES.*/
            public StringBasis WDATA_ULTANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WTIME-DAY.*/
            public SI1000B_WTIME_DAY WTIME_DAY { get; set; } = new SI1000B_WTIME_DAY();
            public class SI1000B_WTIME_DAY : VarBasis
            {
                /*"    10       WTIME-HH          PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WTIME-MM          PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WTIME-SS          PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WTIME-CC          PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WTIME-DAYR.*/
            }
            public SI1000B_WTIME_DAYR WTIME_DAYR { get; set; } = new SI1000B_WTIME_DAYR();
            public class SI1000B_WTIME_DAYR : VarBasis
            {
                /*"    10       WTIME-HHR         PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_HHR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WTIME-MMR         PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_MMR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WTIME-SSR         PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WTIME_SSR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WABEND.*/
            }
            public SI1000B_WABEND WABEND { get; set; } = new SI1000B_WABEND();
            public class SI1000B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE           'SI1000B '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI1000B ");
                /*"    10      FILLER              PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public SI1000B_V1MESTSINI V1MESTSINI { get; set; } = new SI1000B_V1MESTSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -377- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -378- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -381- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

                /*" -384- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -384- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -394- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -395- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -397- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -399- PERFORM R0900-00-DECLARE-V1MESTSINI */

            R0900_00_DECLARE_V1MESTSINI_SECTION();

            /*" -400- PERFORM R0910-00-FETCH-V1MESTSINI */

            R0910_00_FETCH_V1MESTSINI_SECTION();

            /*" -401- IF WFIM-V1MESTSINI NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1MESTSINI.IsEmpty())
            {

                /*" -402- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -404- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -407- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-PROCESSO EQUAL HIGH-VALUES */

            while (!(AREA_DE_WORK.WFIM_PROCESSO.IsHighValues))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -408- DISPLAY 'MESTRE SINISTRO LIDOS     ' AC-L-V1MESTSINI */
            _.Display($"MESTRE SINISTRO LIDOS     {AREA_DE_WORK.AC_L_V1MESTSINI}");

            /*" -408- DISPLAY 'REGS. INSERIDOS HISTORICO ' AC-I-V0HISTSINI. */
            _.Display($"REGS. INSERIDOS HISTORICO {AREA_DE_WORK.AC_I_V0HISTSINI}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -414- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -414- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -427- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -433- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -436- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -437- DISPLAY 'SI1000B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI1000B - SISTEMA SI NAO CADASTRADO");

                /*" -438- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -442- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -443- MOVE V1SIST-DTMOVABE TO WSIST-DATA */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA);

            /*" -445- IF WSIS-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES.In("04", "06", "09", "11"))
            {

                /*" -446- MOVE 30 TO WSIS-DIA */
                _.Move(30, AREA_DE_WORK.FILLER_4.WSIS_DIA);

                /*" -447- ELSE */
            }
            else
            {


                /*" -448- IF WSIS-MES EQUAL 02 */

                if (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES == 02)
                {

                    /*" -451- COMPUTE WRESTO = WSIS-ANO - (WSIS-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_ANO - (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_ANO / 4 * 4);

                    /*" -452- IF WRESTO EQUAL ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -453- MOVE 29 TO WSIS-DIA */
                        _.Move(29, AREA_DE_WORK.FILLER_4.WSIS_DIA);

                        /*" -454- ELSE */
                    }
                    else
                    {


                        /*" -455- MOVE 28 TO WSIS-DIA */
                        _.Move(28, AREA_DE_WORK.FILLER_4.WSIS_DIA);

                        /*" -456- ELSE */
                    }

                }
                else
                {


                    /*" -458- MOVE 31 TO WSIS-DIA. */
                    _.Move(31, AREA_DE_WORK.FILLER_4.WSIS_DIA);
                }

            }


            /*" -459- IF V1SIST-DTMOVABE LESS WSIST-DATA */

            if (V1SIST_DTMOVABE < AREA_DE_WORK.WSIST_DATA)
            {

                /*" -461- DISPLAY 'SI1000B - DATA DO SISTEMA INVALIDA PARA FECHA 'MENTO MENSAL ' WSIST-DATA */

                $"SI1000B - DATA DO SISTEMA INVALIDA PARA FECHA MENTOMENSAL{AREA_DE_WORK.WSIST_DATA}"
                .Display();

                /*" -462- DISPLAY ' . MES EM ABERTO PARA O FECHAMENTO.' */
                _.Display($" . MES EM ABERTO PARA O FECHAMENTO.");

                /*" -463- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -468- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -469- MOVE V1SIST-DTMOVABE TO WREFE-REFERENCIA */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WREFE_REFERENCIA);

            /*" -470- MOVE WREFE-REFERENCIA TO WHOST-DTTERVIG */
            _.Move(AREA_DE_WORK.WREFE_REFERENCIA, WHOST_DTTERVIG);

            /*" -471- MOVE 01 TO WREFE-DIAREFER */
            _.Move(01, AREA_DE_WORK.WREFE_REFERENCIA.WREFE_DIAREFER);

            /*" -475- MOVE WREFE-REFERENCIA TO WHOST-DTINIVIG. */
            _.Move(AREA_DE_WORK.WREFE_REFERENCIA, WHOST_DTINIVIG);

            /*" -476- MOVE V1SIST-DTMOVABE TO WSIST-DATA */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA);

            /*" -477- IF WSIS-MES EQUAL 01 */

            if (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES == 01)
            {

                /*" -478- MOVE 12 TO WSIS-MES */
                _.Move(12, AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES);

                /*" -479- SUBTRACT 1 FROM WSIS-ANO */
                AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_ANO.Value = AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_ANO - 1;

                /*" -480- ELSE */
            }
            else
            {


                /*" -482- SUBTRACT 1 FROM WSIS-MES. */
                AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES.Value = AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES - 1;
            }


            /*" -484- IF WSIS-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES.In("04", "06", "09", "11"))
            {

                /*" -485- MOVE 30 TO WSIS-DIA */
                _.Move(30, AREA_DE_WORK.FILLER_4.WSIS_DIA);

                /*" -486- ELSE */
            }
            else
            {


                /*" -487- IF WSIS-MES EQUAL 02 */

                if (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_MES == 02)
                {

                    /*" -490- COMPUTE WRESTO = WSIS-ANO - (WSIS-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_ANO - (AREA_DE_WORK.FILLER_4.WSIST_ANOMES.WSIS_ANO / 4 * 4);

                    /*" -491- IF WRESTO EQUAL ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -492- MOVE 29 TO WSIS-DIA */
                        _.Move(29, AREA_DE_WORK.FILLER_4.WSIS_DIA);

                        /*" -493- ELSE */
                    }
                    else
                    {


                        /*" -494- MOVE 28 TO WSIS-DIA */
                        _.Move(28, AREA_DE_WORK.FILLER_4.WSIS_DIA);

                        /*" -495- ELSE */
                    }

                }
                else
                {


                    /*" -497- MOVE 31 TO WSIS-DIA. */
                    _.Move(31, AREA_DE_WORK.FILLER_4.WSIS_DIA);
                }

            }


            /*" -497- MOVE WSIST-DATA TO V1SIST-DATA-ANT. */
            _.Move(AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.V1SIST_DATA_ANT);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -433- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' WITH UR END-EXEC. */

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
        /*" R0200-00-SELECT-V1MOEDA-SECTION */
        private void R0200_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -511- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -519- PERFORM R0200_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R0200_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -522- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -525- DISPLAY 'R0200-00 (NAO EXITE NA V1MOEDA) ... ' ' ' W1MOED-CODUNIMO ' ' W1MOED-DTINIVIG */

                $"R0200-00 (NAO EXITE NA V1MOEDA) ...  {W1MOED_CODUNIMO} {W1MOED_DTINIVIG}"
                .Display();

                /*" -525- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R0200_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -519- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :W1MOED-CODUNIMO AND DTINIVIG <= :W1MOED-DTINIVIG AND DTTERVIG >= :W1MOED-DTINIVIG WITH UR END-EXEC. */

            var r0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                W1MOED_CODUNIMO = W1MOED_CODUNIMO.ToString(),
                W1MOED_DTINIVIG = W1MOED_DTINIVIG.ToString(),
            };

            var executed_1 = R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1MESTSINI-SECTION */
        private void R0900_00_DECLARE_V1MESTSINI_SECTION()
        {
            /*" -538- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -555- PERFORM R0900_00_DECLARE_V1MESTSINI_DB_DECLARE_1 */

            R0900_00_DECLARE_V1MESTSINI_DB_DECLARE_1();

            /*" -557- PERFORM R0900_00_DECLARE_V1MESTSINI_DB_OPEN_1 */

            R0900_00_DECLARE_V1MESTSINI_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1MESTSINI-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1MESTSINI_DB_DECLARE_1()
        {
            /*" -555- EXEC SQL DECLARE V1MESTSINI CURSOR FOR SELECT M.TIPREG, M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.CODPRODU, M.IDTPSEGU, M.OCORHIST, M.DATCMD, M.COD_MOEDA_SINI, M.SDOPAGBT, H.DTMOVTO FROM SEGUROS.V1MESTSINI M, SEGUROS.V1HISTSINI H WHERE M.SDOPAGBT > 0 AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.OPERACAO = 101 AND H.DTMOVTO <= :V1SIST-DTMOVABE END-EXEC. */
            V1MESTSINI = new SI1000B_V1MESTSINI(true);
            string GetQuery_V1MESTSINI()
            {
                var query = @$"SELECT M.TIPREG
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.CODPRODU
							, 
							M.IDTPSEGU
							, 
							M.OCORHIST
							, 
							M.DATCMD
							, 
							M.COD_MOEDA_SINI
							, 
							M.SDOPAGBT
							, 
							H.DTMOVTO 
							FROM SEGUROS.V1MESTSINI M
							, 
							SEGUROS.V1HISTSINI H 
							WHERE M.SDOPAGBT > 0 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.OPERACAO = 101 
							AND H.DTMOVTO <= '{V1SIST_DTMOVABE}'";

                return query;
            }
            V1MESTSINI.GetQueryEvent += GetQuery_V1MESTSINI;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1MESTSINI-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1MESTSINI_DB_OPEN_1()
        {
            /*" -557- EXEC SQL OPEN V1MESTSINI END-EXEC. */

            V1MESTSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1MESTSINI-SECTION */
        private void R0910_00_FETCH_V1MESTSINI_SECTION()
        {
            /*" -570- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -581- PERFORM R0910_00_FETCH_V1MESTSINI_DB_FETCH_1 */

            R0910_00_FETCH_V1MESTSINI_DB_FETCH_1();

            /*" -584- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -585- MOVE HIGH-VALUES TO WFIM-PROCESSO */

                AREA_DE_WORK.WFIM_PROCESSO.IsHighValues = true;

                /*" -586- MOVE 'S' TO WFIM-V1MESTSINI */
                _.Move("S", AREA_DE_WORK.WFIM_V1MESTSINI);

                /*" -586- PERFORM R0910_00_FETCH_V1MESTSINI_DB_CLOSE_1 */

                R0910_00_FETCH_V1MESTSINI_DB_CLOSE_1();

                /*" -589- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -589- ADD 1 TO AC-L-V1MESTSINI. */
            AREA_DE_WORK.AC_L_V1MESTSINI.Value = AREA_DE_WORK.AC_L_V1MESTSINI + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1MESTSINI-DB-FETCH-1 */
        public void R0910_00_FETCH_V1MESTSINI_DB_FETCH_1()
        {
            /*" -581- EXEC SQL FETCH V1MESTSINI INTO :V1MSIN-TIPREG, :V1MSIN-NUM-SINI, :V1MSIN-NUM-APOL, :V1MSIN-CODPRODU, :V1MSIN-IDTPSEGU, :V1MSIN-OCORHIST, :V1MSIN-DATCMD, :V1MSIN-COD-MOEDA, :V1MSIN-SDOPAGBT, :V1HSIN-DTMOVTO END-EXEC. */

            if (V1MESTSINI.Fetch())
            {
                _.Move(V1MESTSINI.V1MSIN_TIPREG, V1MSIN_TIPREG);
                _.Move(V1MESTSINI.V1MSIN_NUM_SINI, V1MSIN_NUM_SINI);
                _.Move(V1MESTSINI.V1MSIN_NUM_APOL, V1MSIN_NUM_APOL);
                _.Move(V1MESTSINI.V1MSIN_CODPRODU, V1MSIN_CODPRODU);
                _.Move(V1MESTSINI.V1MSIN_IDTPSEGU, V1MSIN_IDTPSEGU);
                _.Move(V1MESTSINI.V1MSIN_OCORHIST, V1MSIN_OCORHIST);
                _.Move(V1MESTSINI.V1MSIN_DATCMD, V1MSIN_DATCMD);
                _.Move(V1MESTSINI.V1MSIN_COD_MOEDA, V1MSIN_COD_MOEDA);
                _.Move(V1MESTSINI.V1MSIN_SDOPAGBT, V1MSIN_SDOPAGBT);
                _.Move(V1MESTSINI.V1HSIN_DTMOVTO, V1HSIN_DTMOVTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1MESTSINI-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1MESTSINI_DB_CLOSE_1()
        {
            /*" -586- EXEC SQL CLOSE V1MESTSINI END-EXEC */

            V1MESTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -602- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -604- MOVE V1MSIN-OCORHIST TO WOCORHIST */
            _.Move(V1MSIN_OCORHIST, WOCORHIST);

            /*" -606- MOVE V1SIST-DTMOVABE TO WSIST-DATA. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA);

            /*" -607- MOVE V1MSIN-COD-MOEDA TO W1MOED-CODUNIMO */
            _.Move(V1MSIN_COD_MOEDA, W1MOED_CODUNIMO);

            /*" -608- MOVE V1SIST-DTMOVABE TO W1MOED-DTINIVIG */
            _.Move(V1SIST_DTMOVABE, W1MOED_DTINIVIG);

            /*" -610- PERFORM R0200-00-SELECT-V1MOEDA */

            R0200_00_SELECT_V1MOEDA_SECTION();

            /*" -618- COMPUTE AC-PENDENTE = V1MSIN-SDOPAGBT * V1MOED-VLCRUZAD */
            AREA_DE_WORK.AC_PENDENTE.Value = V1MSIN_SDOPAGBT * V1MOED_VLCRUZAD;

            /*" -619- MOVE V1MSIN-DATCMD TO WDATA-AVISO. */
            _.Move(V1MSIN_DATCMD, AREA_DE_WORK.WDATA_AVISO);

            /*" -621- MOVE V1HSIN-DTMOVTO TO WDATA-MOVTO */
            _.Move(V1HSIN_DTMOVTO, AREA_DE_WORK.WDATA_MOVTO);

            /*" -622- IF WAVIS-ANOMES EQUAL WSIST-ANOMES */

            if (AREA_DE_WORK.WDATA_AVISO.WAVIS_ANOMES == AREA_DE_WORK.FILLER_4.WSIST_ANOMES)
            {

                /*" -623- PERFORM R6000-00-ACESSA-DATA-CORRECAO */

                R6000_00_ACESSA_DATA_CORRECAO_SECTION();

                /*" -624- MOVE V0HSIN-DTMOVTO-MAX TO W1MOED-DTINIVIG */
                _.Move(V0HSIN_DTMOVTO_MAX, W1MOED_DTINIVIG);

                /*" -625- PERFORM R0200-00-SELECT-V1MOEDA */

                R0200_00_SELECT_V1MOEDA_SECTION();

                /*" -627- COMPUTE AC-INICIAL = V1MSIN-SDOPAGBT * V1MOED-VLCRUZAD */
                AREA_DE_WORK.AC_INICIAL.Value = V1MSIN_SDOPAGBT * V1MOED_VLCRUZAD;

                /*" -628- ELSE */
            }
            else
            {


                /*" -629- IF WMOVTO-ANOMES EQUAL WSIST-ANOMES */

                if (AREA_DE_WORK.WDATA_MOVTO.WMOVTO_ANOMES == AREA_DE_WORK.FILLER_4.WSIST_ANOMES)
                {

                    /*" -630- MOVE V1MSIN-DATCMD TO W1MOED-DTINIVIG */
                    _.Move(V1MSIN_DATCMD, W1MOED_DTINIVIG);

                    /*" -631- PERFORM R0200-00-SELECT-V1MOEDA */

                    R0200_00_SELECT_V1MOEDA_SECTION();

                    /*" -633- COMPUTE AC-INICIAL = V1MSIN-SDOPAGBT * V1MOED-VLCRUZAD */
                    AREA_DE_WORK.AC_INICIAL.Value = V1MSIN_SDOPAGBT * V1MOED_VLCRUZAD;

                    /*" -634- ELSE */
                }
                else
                {


                    /*" -635- MOVE V1SIST-DATA-ANT TO W1MOED-DTINIVIG */
                    _.Move(AREA_DE_WORK.V1SIST_DATA_ANT, W1MOED_DTINIVIG);

                    /*" -636- PERFORM R0200-00-SELECT-V1MOEDA */

                    R0200_00_SELECT_V1MOEDA_SECTION();

                    /*" -639- COMPUTE AC-INICIAL = V1MSIN-SDOPAGBT * V1MOED-VLCRUZAD. */
                    AREA_DE_WORK.AC_INICIAL.Value = V1MSIN_SDOPAGBT * V1MOED_VLCRUZAD;
                }

            }


            /*" -642- COMPUTE AC-CORRECAO = AC-PENDENTE - AC-INICIAL. */
            AREA_DE_WORK.AC_CORRECAO.Value = AREA_DE_WORK.AC_PENDENTE - AREA_DE_WORK.AC_INICIAL;

            /*" -643- IF AC-CORRECAO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_CORRECAO != 00)
            {

                /*" -644- PERFORM R3000-00-MONTA-CORRECAO */

                R3000_00_MONTA_CORRECAO_SECTION();

                /*" -645- PERFORM R4000-00-INSERT-V0HISTSINI */

                R4000_00_INSERT_V0HISTSINI_SECTION();

                /*" -647- PERFORM R5000-00-ATUALIZA-V0MESTSINI. */

                R5000_00_ATUALIZA_V0MESTSINI_SECTION();
            }


            /*" -647- PERFORM R0910-00-FETCH-V1MESTSINI. */

            R0910_00_FETCH_V1MESTSINI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-CORRECAO-SECTION */
        private void R3000_00_MONTA_CORRECAO_SECTION()
        {
            /*" -660- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -661- MOVE ZEROS TO V0HSIN-COD-EMP */
            _.Move(0, V0HSIN_COD_EMP);

            /*" -662- MOVE V1MSIN-TIPREG TO V0HSIN-TIPREG */
            _.Move(V1MSIN_TIPREG, V0HSIN_TIPREG);

            /*" -664- MOVE V1MSIN-NUM-SINI TO V0HSIN-NUM-SINI */
            _.Move(V1MSIN_NUM_SINI, V0HSIN_NUM_SINI);

            /*" -665- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -667- MOVE WOCORHIST TO V0HSIN-OCORHIST */
            _.Move(WOCORHIST, V0HSIN_OCORHIST);

            /*" -668- MOVE 0122 TO V0HSIN-OPERACAO */
            _.Move(0122, V0HSIN_OPERACAO);

            /*" -670- MOVE V1SIST-DTMOVABE TO V0HSIN-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HSIN_DTMOVTO);

            /*" -671- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -672- MOVE WTIME-HH TO WTIME-HHR */
            _.Move(AREA_DE_WORK.WTIME_DAY.WTIME_HH, AREA_DE_WORK.WTIME_DAYR.WTIME_HHR);

            /*" -673- MOVE WTIME-MM TO WTIME-MMR */
            _.Move(AREA_DE_WORK.WTIME_DAY.WTIME_MM, AREA_DE_WORK.WTIME_DAYR.WTIME_MMR);

            /*" -674- MOVE WTIME-SS TO WTIME-SSR */
            _.Move(AREA_DE_WORK.WTIME_DAY.WTIME_SS, AREA_DE_WORK.WTIME_DAYR.WTIME_SSR);

            /*" -676- MOVE WTIME-DAYR TO V0HSIN-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAYR, V0HSIN_HORAOPER);

            /*" -677- MOVE SPACES TO V0HSIN-NOMFAV */
            _.Move("", V0HSIN_NOMFAV);

            /*" -678- MOVE AC-CORRECAO TO V0HSIN-VAL-OPER */
            _.Move(AREA_DE_WORK.AC_CORRECAO, V0HSIN_VAL_OPER);

            /*" -679- MOVE V1SIST-DTMOVABE TO V0HSIN-LIMCRR */
            _.Move(V1SIST_DTMOVABE, V0HSIN_LIMCRR);

            /*" -680- MOVE SPACES TO V0HSIN-TIPFAV */
            _.Move("", V0HSIN_TIPFAV);

            /*" -681- MOVE V1SIST-DTMOVABE TO V0HSIN-DATNEG */
            _.Move(V1SIST_DTMOVABE, V0HSIN_DATNEG);

            /*" -682- MOVE 0 TO V0HSIN-FONPAG */
            _.Move(0, V0HSIN_FONPAG);

            /*" -683- MOVE 0 TO V0HSIN-CODPSVI */
            _.Move(0, V0HSIN_CODPSVI);

            /*" -684- MOVE 0 TO V0HSIN-CODSVI */
            _.Move(0, V0HSIN_CODSVI);

            /*" -685- MOVE 0 TO V0HSIN-NUMOPG */
            _.Move(0, V0HSIN_NUMOPG);

            /*" -686- MOVE 0 TO V0HSIN-NUMREC */
            _.Move(0, V0HSIN_NUMREC);

            /*" -687- MOVE 0 TO V0HSIN-MOVPCS */
            _.Move(0, V0HSIN_MOVPCS);

            /*" -688- MOVE SPACES TO V0HSIN-CODUSU */
            _.Move("", V0HSIN_CODUSU);

            /*" -689- MOVE SPACES TO V0HSIN-SITCONTB */
            _.Move("", V0HSIN_SITCONTB);

            /*" -691- MOVE SPACES TO V0HSIN-SITUACAO. */
            _.Move("", V0HSIN_SITUACAO);

            /*" -692- MOVE V1MSIN-NUM-APOL TO V0HSIN-NUM-APOL. */
            _.Move(V1MSIN_NUM_APOL, V0HSIN_NUM_APOL);

            /*" -692- MOVE V1MSIN-CODPRODU TO V0HSIN-CODPRODU. */
            _.Move(V1MSIN_CODPRODU, V0HSIN_CODPRODU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-V0HISTSINI-SECTION */
        private void R4000_00_INSERT_V0HISTSINI_SECTION()
        {
            /*" -705- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -757- PERFORM R4000_00_INSERT_V0HISTSINI_DB_INSERT_1 */

            R4000_00_INSERT_V0HISTSINI_DB_INSERT_1();

            /*" -761- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -765- DISPLAY 'R4000-00 (REGISTRO DUPLICADO) ... ' ' SINISTRO   = ' V0HSIN-NUM-SINI ' OCORRENCIA = ' V0HSIN-OCORHIST ' OPERACAO   = ' V0HSIN-OPERACAO */

                $"R4000-00 (REGISTRO DUPLICADO) ...  SINISTRO   = {V0HSIN_NUM_SINI} OCORRENCIA = {V0HSIN_OCORHIST} OPERACAO   = {V0HSIN_OPERACAO}"
                .Display();

                /*" -767- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -768- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -772- DISPLAY 'R4000-00 (PROBLEMAS NA INSERCAO) ... ' ' SINISTRO   = ' V0HSIN-NUM-SINI ' OCORRENCIA = ' V0HSIN-OCORHIST ' OPERACAO   = ' V0HSIN-OPERACAO */

                $"R4000-00 (PROBLEMAS NA INSERCAO) ...  SINISTRO   = {V0HSIN_NUM_SINI} OCORRENCIA = {V0HSIN_OCORHIST} OPERACAO   = {V0HSIN_OPERACAO}"
                .Display();

                /*" -775- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -775- ADD +1 TO AC-I-V0HISTSINI. */
            AREA_DE_WORK.AC_I_V0HISTSINI.Value = AREA_DE_WORK.AC_I_V0HISTSINI + +1;

        }

        [StopWatch]
        /*" R4000-00-INSERT-V0HISTSINI-DB-INSERT-1 */
        public void R4000_00_INSERT_V0HISTSINI_DB_INSERT_1()
        {
            /*" -757- EXEC SQL INSERT INTO SEGUROS.V0HISTSINI (COD_EMPRESA, TIPREG, NUM_APOL_SINISTRO, OCORHIST, OPERACAO, DTMOVTO, HORAOPER, NOMFAV, VAL_OPERACAO, LIMCRR, TIPFAV, DATNEG, FONPAG, CODPSVI, CODSVI, NUMOPG, NUMREC, MOVPCS, CODUSU, SITCONTB, SITUACAO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:V0HSIN-COD-EMP, :V0HSIN-TIPREG, :V0HSIN-NUM-SINI, :V0HSIN-OCORHIST, :V0HSIN-OPERACAO, :V0HSIN-DTMOVTO, :V0HSIN-HORAOPER, :V0HSIN-NOMFAV, :V0HSIN-VAL-OPER, :V0HSIN-LIMCRR, :V0HSIN-TIPFAV, :V0HSIN-DATNEG, :V0HSIN-FONPAG, :V0HSIN-CODPSVI, :V0HSIN-CODSVI, :V0HSIN-NUMOPG, :V0HSIN-NUMREC, :V0HSIN-MOVPCS, :V0HSIN-CODUSU, :V0HSIN-SITCONTB, :V0HSIN-SITUACAO, CURRENT TIMESTAMP, :V0HSIN-NUM-APOL, :V0HSIN-CODPRODU, 'SI1000B' ) END-EXEC. */

            var r4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1 = new R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1()
            {
                V0HSIN_COD_EMP = V0HSIN_COD_EMP.ToString(),
                V0HSIN_TIPREG = V0HSIN_TIPREG.ToString(),
                V0HSIN_NUM_SINI = V0HSIN_NUM_SINI.ToString(),
                V0HSIN_OCORHIST = V0HSIN_OCORHIST.ToString(),
                V0HSIN_OPERACAO = V0HSIN_OPERACAO.ToString(),
                V0HSIN_DTMOVTO = V0HSIN_DTMOVTO.ToString(),
                V0HSIN_HORAOPER = V0HSIN_HORAOPER.ToString(),
                V0HSIN_NOMFAV = V0HSIN_NOMFAV.ToString(),
                V0HSIN_VAL_OPER = V0HSIN_VAL_OPER.ToString(),
                V0HSIN_LIMCRR = V0HSIN_LIMCRR.ToString(),
                V0HSIN_TIPFAV = V0HSIN_TIPFAV.ToString(),
                V0HSIN_DATNEG = V0HSIN_DATNEG.ToString(),
                V0HSIN_FONPAG = V0HSIN_FONPAG.ToString(),
                V0HSIN_CODPSVI = V0HSIN_CODPSVI.ToString(),
                V0HSIN_CODSVI = V0HSIN_CODSVI.ToString(),
                V0HSIN_NUMOPG = V0HSIN_NUMOPG.ToString(),
                V0HSIN_NUMREC = V0HSIN_NUMREC.ToString(),
                V0HSIN_MOVPCS = V0HSIN_MOVPCS.ToString(),
                V0HSIN_CODUSU = V0HSIN_CODUSU.ToString(),
                V0HSIN_SITCONTB = V0HSIN_SITCONTB.ToString(),
                V0HSIN_SITUACAO = V0HSIN_SITUACAO.ToString(),
                V0HSIN_NUM_APOL = V0HSIN_NUM_APOL.ToString(),
                V0HSIN_CODPRODU = V0HSIN_CODPRODU.ToString(),
            };

            R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1.Execute(r4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-ATUALIZA-V0MESTSINI-SECTION */
        private void R5000_00_ATUALIZA_V0MESTSINI_SECTION()
        {
            /*" -786- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -793- PERFORM R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1 */

            R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1();

            /*" -796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -799- DISPLAY 'R4000-00 (PROBLEMAS NA ATUALIZACAO ...)' ' SINISTRO   = ' V0HSIN-NUM-SINI ' OCORRENCIA = ' V0HSIN-OCORHIST */

                $"R4000-00 (PROBLEMAS NA ATUALIZACAO ...) SINISTRO   = {V0HSIN_NUM_SINI} OCORRENCIA = {V0HSIN_OCORHIST}"
                .Display();

                /*" -799- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-ATUALIZA-V0MESTSINI-DB-UPDATE-1 */
        public void R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1()
        {
            /*" -793- EXEC SQL UPDATE SEGUROS.V0MESTSINI SET OCORHIST = :V0HSIN-OCORHIST WHERE NUM_APOL_SINISTRO = :V0HSIN-NUM-SINI END-EXEC. */

            var r5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1 = new R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1()
            {
                V0HSIN_OCORHIST = V0HSIN_OCORHIST.ToString(),
                V0HSIN_NUM_SINI = V0HSIN_NUM_SINI.ToString(),
            };

            R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1.Execute(r5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-ACESSA-DATA-CORRECAO-SECTION */
        private void R6000_00_ACESSA_DATA_CORRECAO_SECTION()
        {
            /*" -813- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -814- MOVE SPACES TO V0HSIN-DTMOVTO-MAX. */
            _.Move("", V0HSIN_DTMOVTO_MAX);

            /*" -816- MOVE ZEROS TO V0HSIN-VAR-INDICA. */
            _.Move(0, V0HSIN_VAR_INDICA);

            /*" -829- PERFORM R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1 */

            R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1();

            /*" -832- IF V0HSIN-VAR-INDICA LESS ZEROS */

            if (V0HSIN_VAR_INDICA < 00)
            {

                /*" -834- MOVE V1MSIN-DATCMD TO V0HSIN-DTMOVTO-MAX. */
                _.Move(V1MSIN_DATCMD, V0HSIN_DTMOVTO_MAX);
            }


            /*" -835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -837- DISPLAY 'R6000-00 (ERRO NO ACESSO AO ULTIMO MOVTO...)' ' SINISTRO   = ' V0HSIN-NUM-SINI */

                $"R6000-00 (ERRO NO ACESSO AO ULTIMO MOVTO...) SINISTRO   = {V0HSIN_NUM_SINI}"
                .Display();

                /*" -837- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6000-00-ACESSA-DATA-CORRECAO-DB-SELECT-1 */
        public void R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1()
        {
            /*" -829- EXEC SQL SELECT MAX(DTMOVTO) INTO :V0HSIN-DTMOVTO-MAX:V0HSIN-VAR-INDICA FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND SITUACAO = '2' AND DTMOVTO <= :V1SIST-DTMOVABE AND OPERACAO IN (1001, 1009, 107, 117) END-EXEC. */

            var r6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1 = new R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1.Execute(r6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSIN_DTMOVTO_MAX, V0HSIN_DTMOVTO_MAX);
                _.Move(executed_1.V0HSIN_VAR_INDICA, V0HSIN_VAR_INDICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -851- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -852- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -853- DISPLAY '*   SI1000B - ATUALIZACAO DB SINISTROS     *' */
            _.Display($"*   SI1000B - ATUALIZACAO DB SINISTROS     *");

            /*" -854- DISPLAY '*   -------   ----------- -- ---------     *' */
            _.Display($"*   -------   ----------- -- ---------     *");

            /*" -855- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -856- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA    *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA    *");

            /*" -858- DISPLAY '*              ' V1SIST-DTMOVABE '*                                          *' */

            $"*              {V1SIST_DTMOVABE}*                                          *"
            .Display();

            /*" -859- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -859- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -877- DISPLAY ' SINISTRO   = ' V0HSIN-NUM-SINI ' OCORRENCIA = ' V0HSIN-OCORHIST ' OPERACAO   = ' V0HSIN-OPERACAO */

            $" SINISTRO   = {V0HSIN_NUM_SINI} OCORRENCIA = {V0HSIN_OCORHIST} OPERACAO   = {V0HSIN_OPERACAO}"
            .Display();

            /*" -879- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -881- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -881- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -883- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -886- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -886- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}