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
using Sias.Emissao.DB2.EM0911S;

namespace Code
{
    public class EM0911S
    {
        public bool IsCall { get; set; }

        public EM0911S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0911S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  BL                                 *      */
        /*"      *   DATA CODIFICACAO .......  NOVEMBRO/1994                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZA ITENS APOLICE DE OUTROS   *      */
        /*"      *                             RAMOS                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         INPUT    *      */
        /*"      * MOEDA / COTACAO                     V1MOEDA           INPUT    *      */
        /*"      * PROPOSTA OUTROS                     V1OUTROSPROP      INPUT    *      */
        /*"      * PROPOSTA COBERTURA OUTROS           V1OUTRCOBERPROP   INPUT    *      */
        /*"      * PROPOSTA BENS OUTROS                V1OUTRBENSPROP    INPUT    *      */
        /*"      * PROPOSTA COBERTURA BENS             V1BENSCOBERPROP   INPUT    *      */
        /*"      * PROPOSTA CLAUSULAS                  V1PROPCLAUSULA    INPUT    *      */
        /*"      * APOLICE OUTROS                      V0OUTROSAPOL      OUTPUT   *      */
        /*"      * COBERTURA OUTROS                    V0OUTROSCOBER     OUTPUT   *      */
        /*"      * BENS OUTROS                         V0OUTROSBENS      OUTPUT   *      */
        /*"      * COBERTURA BENS                      V0BENSCOBER       OUTPUT   *      */
        /*"      * APOLICE CLAUSULAS                   V0APOLCLAUSULA    OUTPUT   *      */
        /*"      * EMISSAO DIARIA                      V0EMISDIARIA      OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 05/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-FONTE         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRPROPOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUM-APOL      PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis WHOST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-NRENDOS       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-DTMOVABE      PIC  X(010).*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-COD-MOEDA     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-VLCRUZAD      PIC S9(006)V9(9) VALUE +0  COMP-3*/
        public DoubleBasis WHOST_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         WHOST-CODCORR       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1COBP-PCT-TOTAL    PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PCT_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1COBP-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         VIND-NUM-ATA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ANO-ATA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-SORT       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DAT_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTAPOLM        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTAPOLM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-RCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DAT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIMESTAMP      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESAUT       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESAUT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESACE       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESACE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESRCF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESRCF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESAPP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESAPP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDEACESS       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_IDEACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PRMTARIFA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PRMTARIFA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ULTENDO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ULTENDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODCLIEN       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESPLCA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESPLCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESPLRF      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESPLRF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESPLAP      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESPLAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCAGPLRF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCAGPLRF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCAGPLAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCAGPLAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODPRODU       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-ORGAO        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO         PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-PRM    PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-IMP    PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-CODPRODU     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-VLCRUZAD     PIC S9(006)V9(9)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1MOED-VLCR-IMP     PIC S9(006)V9(9)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCR_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1MOED-VLCR-PRM     PIC S9(006)V9(9)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCR_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1PROU-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROU_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1PROU_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROU-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROU_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-NRRISCO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROU_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROU_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1PROU_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROU-PROPRIET     PIC  X(040).*/
        public StringBasis V1PROU_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1PROU-COD-LOGRAD   PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PROU_COD_LOGRAD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PROU_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APOU-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOU_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOU_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOU-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOU_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-NRRISCO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOU_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOU_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APOU_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOU-PROPRIET     PIC  X(040).*/
        public StringBasis V0APOU_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0APOU-COD-LOGRAD   PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOU_COD_LOGRAD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APOU_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOU-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APOU_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APOU_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRCO-COD-EMPRESA  PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCO-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCO-NRPROPOS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCO-NRRISCO      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCO-RAMOFR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCO-MODALIFR     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCO-COD-COBER    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRCO_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCO-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRCO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCO-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRCO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCO-IMP-SEG-IX   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRCO-IMP-SEG-VR   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRCO-TAXA-IS      PIC S9(003)V9(9) VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
        /*"77         V1PRCO-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCO-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCO-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCO-VRFROBR-IX   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_VRFROBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRCO-LIM-IND-IX   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PRCO_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCO-SITUACAO     PIC  X(001).*/
        public StringBasis V1PRCO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRCO-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRCO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APOC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APOC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOC-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APOC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOC-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APOC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOC-NRRISCO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APOC_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOC-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APOC_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOC-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APOC_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOC-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APOC_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOC-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APOC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOC-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APOC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOC-IMP-SEG-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APOC-IMP-SEG-VR   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APOC-TAXA-IS      PIC S9(003)V9(9) VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
        /*"77         V0APOC-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APOC-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APOC-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APOC-VRFROBR-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_VRFROBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APOC-LIM-IND-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APOC_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APOC-SITUACAO     PIC  X(001).*/
        public StringBasis V0APOC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0APOC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APOC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APOC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PROB-COD-EMPRESA  PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PROB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROB-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PROB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROB-NRPROPOS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PROB_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROB-NRRISCO      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PROB_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROB-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PROB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROB-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PROB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROB-NRBEM        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PROB_NRBEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROB-DESCRBEM     PIC  X(040).*/
        public StringBasis V1PROB_DESCRBEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1PROB-NRSERIE      PIC  X(015).*/
        public StringBasis V1PROB_NRSERIE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V1PROB-IMP-SEG-IX   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V1PROB_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PROB-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PROB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APOB-COD-EMPRESA  PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOB-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOB-NRPROPOS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APOB_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOB-NRRISCO      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APOB_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOB-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOB-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APOB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOB-NRBEM        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APOB_NRBEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOB-DESCRBEM     PIC  X(040).*/
        public StringBasis V0APOB_DESCRBEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0APOB-NRSERIE      PIC  X(015).*/
        public StringBasis V0APOB_NRSERIE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0APOB-IMP-SEG-IX   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0APOB_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APOB-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0APOB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOB-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APOB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOB-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRBC-COD-EMPRESA  PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PRBC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRBC-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRBC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRBC-NRPROPOS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PRBC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRBC-NRRISCO      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1PRBC_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRBC-COD-COBER    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRBC_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRBC-NRBEM        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PRBC_NRBEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRBC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRBC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APBC-COD-EMPRESA  PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APBC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APBC-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APBC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APBC-NRPROPOS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APBC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APBC-NRRISCO      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APBC_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APBC-COD-COBER    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APBC_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APBC-NRBEM        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APBC_NRBEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APBC-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0APBC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APBC-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0APBC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APBC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APBC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1COBP-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-NRRISCO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBP-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBP-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBP-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1COBP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1COBP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-ITEM     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PCT-COBERT   PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0COBA-FATOR-MULT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-SITUACAO     PIC  X(001).*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COBA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-NUM-ITEM     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-COD-COBER    PIC S9(004)                COMP.*/
        public IntBasis V1COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-PCT-COBERT   PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COBA-FATOR-MULT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V1COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V1COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-COD-COBERT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_COD_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCL-NRITEM       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1PRCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-CODCLAUS     PIC  X(003).*/
        public StringBasis V1PRCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1PRCL-LIM-IND-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V1PRCL_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APCL-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0APCL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCL-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-COD-COBERT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_COD_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCL-NRITEM       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-CODCLAUS     PIC  X(003).*/
        public StringBasis V0APCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0APCL-LIM-IND-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0APCL_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0EDIA-CODRELAT     PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0EDIA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0EDIA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-DTMOVTO      PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0EDIA-ORGAO        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-RAMO         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CONGENER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-SITUACAO     PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0EDIA-COD-EMPRESA  PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public EM0911S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0911S_AREA_DE_WORK();
        public class EM0911S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WFIM-V1OUTROSPROP      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1OUTROSPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1OUTRCOBERPROP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1OUTRCOBERPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1OUTRBENSPROP    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1OUTRBENSPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1BENSCOBERPROP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1BENSCOBERPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCLAU        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERAPOL       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1OUTRCOBERP      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1OUTRCOBERP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         CH-I-V0COBERAPOL       PIC  X(001)    VALUE SPACES.*/
            public StringBasis CH_I_V0COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WCH-ULTENDO            PIC  X(001)    VALUE SPACES.*/
            public StringBasis WCH_ULTENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         CH-COBER-ATU.*/
            public EM0911S_CH_COBER_ATU CH_COBER_ATU { get; set; } = new EM0911S_CH_COBER_ATU();
            public class EM0911S_CH_COBER_ATU : VarBasis
            {
                /*"    10       CH-FONT-ATU             PIC S9(004)    VALUE +0.*/
                public IntBasis CH_FONT_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-PROP-ATU             PIC S9(009)    VALUE +0.*/
                public IntBasis CH_PROP_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-RAMO-ATU             PIC S9(004)    VALUE +0.*/
                public IntBasis CH_RAMO_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05         CH-COBER-ANT.*/
            }
            public EM0911S_CH_COBER_ANT CH_COBER_ANT { get; set; } = new EM0911S_CH_COBER_ANT();
            public class EM0911S_CH_COBER_ANT : VarBasis
            {
                /*"    10       CH-FONT-ANT             PIC S9(004)    VALUE +0.*/
                public IntBasis CH_FONT_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-PROP-ANT             PIC S9(009)    VALUE +0.*/
                public IntBasis CH_PROP_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-RAMO-ANT             PIC S9(004)    VALUE +0.*/
                public IntBasis CH_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05            AC-S-OUTRBENSPROP      PIC  9(004)  VALUE ZEROS.*/
            }
            public IntBasis AC_S_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-OUTROSBENS        PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-BENSCOBERPROP     PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-BENSCOBER         PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-OUTROSPROP        PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-OUTROSAPOL        PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-OUTRCOBERPROP     PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-OUTROSCOBER       PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-PROPCLAU          PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-APOLCLAU          PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-COBERAPOL         PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-OUTRCOBERP        PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-EMISDIARIA        PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        WABEND.*/
            public EM0911S_WABEND WABEND { get; set; } = new EM0911S_WABEND();
            public class EM0911S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0911S'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0911S");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01               LK-PROPOSTA.*/
            }
        }
        public EM0911S_LK_PROPOSTA LK_PROPOSTA { get; set; } = new EM0911S_LK_PROPOSTA();
        public class EM0911S_LK_PROPOSTA : VarBasis
        {
            /*"  05             LK-FONTE             PIC S9(004)        COMP.*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-NRPROPOS          PIC S9(009)        COMP.*/
            public IntBasis LK_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-NUM-APOL          PIC S9(013)        COMP-3.*/
            public IntBasis LK_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05             LK-NRENDOS           PIC S9(009)        COMP.*/
            public IntBasis LK_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-DTMOVABE          PIC  X(010).*/
            public StringBasis LK_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05             LK-CODCORR           PIC S9(009)        COMP.*/
            public IntBasis LK_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-RETORNO           PIC  X(070).*/
            public StringBasis LK_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05             LK-CODPRODU          PIC S9(004)        COMP.*/
            public IntBasis LK_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-S-OUTRBENSPROP    PIC  9(004).*/
            public IntBasis LK_S_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-OUTROSBENS      PIC  9(004).*/
            public IntBasis LK_I_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-BENSCOBERPROP   PIC  9(004).*/
            public IntBasis LK_S_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-BENSCOBER       PIC  9(004).*/
            public IntBasis LK_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-OUTROSPROP      PIC  9(004).*/
            public IntBasis LK_S_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-OUTROSAPOL      PIC  9(004).*/
            public IntBasis LK_I_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-OUTRCOBERPROP   PIC  9(004).*/
            public IntBasis LK_S_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-OUTROSCOBER     PIC  9(004).*/
            public IntBasis LK_I_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-PROPCLAU        PIC  9(004).*/
            public IntBasis LK_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-APOLCLAU        PIC  9(004).*/
            public IntBasis LK_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-OUTRCOBERP      PIC  9(004).*/
            public IntBasis LK_S_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-COBERAPOL       PIC  9(004).*/
            public IntBasis LK_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-EMISDIARIA      PIC  9(004).*/
            public IntBasis LK_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }


        public EM0911S_V1OUTROSPROP V1OUTROSPROP { get; set; } = new EM0911S_V1OUTROSPROP();
        public EM0911S_V1OUTRCOBERPROP V1OUTRCOBERPROP { get; set; } = new EM0911S_V1OUTRCOBERPROP();
        public EM0911S_V1OUTRBENSPROP V1OUTRBENSPROP { get; set; } = new EM0911S_V1OUTRBENSPROP();
        public EM0911S_V1BENSCOBERPROP V1BENSCOBERPROP { get; set; } = new EM0911S_V1BENSCOBERPROP();
        public EM0911S_V1PROPCLAU V1PROPCLAU { get; set; } = new EM0911S_V1PROPCLAU();
        public EM0911S_V1OUTRCOBERP V1OUTRCOBERP { get; set; } = new EM0911S_V1OUTRCOBERP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0911S_LK_PROPOSTA EM0911S_LK_PROPOSTA_P) //PROCEDURE DIVISION USING 
        /*LK_PROPOSTA*/
        {
            try
            {
                this.LK_PROPOSTA = EM0911S_LK_PROPOSTA_P;

                /*" -526- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -527- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -530- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -534- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -534- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PROPOSTA, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -556- MOVE ZEROS TO AC-S-OUTRBENSPROP AC-I-OUTROSBENS AC-S-BENSCOBERPROP AC-I-BENSCOBER AC-S-OUTROSPROP AC-I-OUTROSAPOL AC-S-OUTRCOBERPROP AC-I-OUTROSCOBER AC-S-PROPCLAU AC-I-APOLCLAU AC-S-OUTRCOBERP AC-I-COBERAPOL AC-I-EMISDIARIA. */
            _.Move(0, AREA_DE_WORK.AC_S_OUTRBENSPROP, AREA_DE_WORK.AC_I_OUTROSBENS, AREA_DE_WORK.AC_S_BENSCOBERPROP, AREA_DE_WORK.AC_I_BENSCOBER, AREA_DE_WORK.AC_S_OUTROSPROP, AREA_DE_WORK.AC_I_OUTROSAPOL, AREA_DE_WORK.AC_S_OUTRCOBERPROP, AREA_DE_WORK.AC_I_OUTROSCOBER, AREA_DE_WORK.AC_S_PROPCLAU, AREA_DE_WORK.AC_I_APOLCLAU, AREA_DE_WORK.AC_S_OUTRCOBERP, AREA_DE_WORK.AC_I_COBERAPOL, AREA_DE_WORK.AC_I_EMISDIARIA);

            /*" -557- IF LK-CODPRODU EQUAL 99 */

            if (LK_PROPOSTA.LK_CODPRODU == 99)
            {

                /*" -559- GO TO R0000-90-FINAL. */

                R0000_90_FINAL(); //GOTO
                return;
            }


            /*" -560- MOVE LK-FONTE TO WHOST-FONTE */
            _.Move(LK_PROPOSTA.LK_FONTE, WHOST_FONTE);

            /*" -561- MOVE LK-NRPROPOS TO WHOST-NRPROPOS */
            _.Move(LK_PROPOSTA.LK_NRPROPOS, WHOST_NRPROPOS);

            /*" -562- MOVE LK-NUM-APOL TO WHOST-NUM-APOL */
            _.Move(LK_PROPOSTA.LK_NUM_APOL, WHOST_NUM_APOL);

            /*" -563- MOVE LK-NRENDOS TO WHOST-NRENDOS */
            _.Move(LK_PROPOSTA.LK_NRENDOS, WHOST_NRENDOS);

            /*" -564- MOVE LK-DTMOVABE TO WHOST-DTMOVABE */
            _.Move(LK_PROPOSTA.LK_DTMOVABE, WHOST_DTMOVABE);

            /*" -566- MOVE LK-CODCORR TO WHOST-CODCORR */
            _.Move(LK_PROPOSTA.LK_CODCORR, WHOST_CODCORR);

            /*" -566- PERFORM R1000-00-PROCESSA-REGISTRO. */

            R1000_00_PROCESSA_REGISTRO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINAL */

            R0000_90_FINAL();

        }

        [StopWatch]
        /*" R0000-90-FINAL */
        private void R0000_90_FINAL(bool isPerform = false)
        {
            /*" -571- MOVE AC-S-OUTRBENSPROP TO LK-S-OUTRBENSPROP */
            _.Move(AREA_DE_WORK.AC_S_OUTRBENSPROP, LK_PROPOSTA.LK_S_OUTRBENSPROP);

            /*" -572- MOVE AC-I-OUTROSBENS TO LK-I-OUTROSBENS */
            _.Move(AREA_DE_WORK.AC_I_OUTROSBENS, LK_PROPOSTA.LK_I_OUTROSBENS);

            /*" -573- MOVE AC-S-BENSCOBERPROP TO LK-S-BENSCOBERPROP */
            _.Move(AREA_DE_WORK.AC_S_BENSCOBERPROP, LK_PROPOSTA.LK_S_BENSCOBERPROP);

            /*" -574- MOVE AC-I-BENSCOBER TO LK-I-BENSCOBER */
            _.Move(AREA_DE_WORK.AC_I_BENSCOBER, LK_PROPOSTA.LK_I_BENSCOBER);

            /*" -575- MOVE AC-S-OUTROSPROP TO LK-S-OUTROSPROP */
            _.Move(AREA_DE_WORK.AC_S_OUTROSPROP, LK_PROPOSTA.LK_S_OUTROSPROP);

            /*" -576- MOVE AC-I-OUTROSAPOL TO LK-I-OUTROSAPOL */
            _.Move(AREA_DE_WORK.AC_I_OUTROSAPOL, LK_PROPOSTA.LK_I_OUTROSAPOL);

            /*" -577- MOVE AC-S-OUTRCOBERPROP TO LK-S-OUTRCOBERPROP */
            _.Move(AREA_DE_WORK.AC_S_OUTRCOBERPROP, LK_PROPOSTA.LK_S_OUTRCOBERPROP);

            /*" -578- MOVE AC-I-OUTROSCOBER TO LK-I-OUTROSCOBER */
            _.Move(AREA_DE_WORK.AC_I_OUTROSCOBER, LK_PROPOSTA.LK_I_OUTROSCOBER);

            /*" -579- MOVE AC-S-PROPCLAU TO LK-S-PROPCLAU */
            _.Move(AREA_DE_WORK.AC_S_PROPCLAU, LK_PROPOSTA.LK_S_PROPCLAU);

            /*" -580- MOVE AC-I-APOLCLAU TO LK-I-APOLCLAU */
            _.Move(AREA_DE_WORK.AC_I_APOLCLAU, LK_PROPOSTA.LK_I_APOLCLAU);

            /*" -581- MOVE AC-S-OUTRCOBERP TO LK-S-OUTRCOBERP */
            _.Move(AREA_DE_WORK.AC_S_OUTRCOBERP, LK_PROPOSTA.LK_S_OUTRCOBERP);

            /*" -582- MOVE AC-I-COBERAPOL TO LK-I-COBERAPOL */
            _.Move(AREA_DE_WORK.AC_I_COBERAPOL, LK_PROPOSTA.LK_I_COBERAPOL);

            /*" -584- MOVE AC-I-EMISDIARIA TO LK-I-EMISDIARIA */
            _.Move(AREA_DE_WORK.AC_I_EMISDIARIA, LK_PROPOSTA.LK_I_EMISDIARIA);

            /*" -586- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -586- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -599- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -601- PERFORM R1100-00-SELECT-V1ENDOSSO */

            R1100_00_SELECT_V1ENDOSSO_SECTION();

            /*" -602- PERFORM R2100-00-DECLARE-V1OUTROSPROP */

            R2100_00_DECLARE_V1OUTROSPROP_SECTION();

            /*" -603- MOVE SPACES TO WFIM-V1OUTROSPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1OUTROSPROP);

            /*" -606- PERFORM R2110-00-INSERT-V0OUTROSAPOL UNTIL WFIM-V1OUTROSPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1OUTROSPROP.IsEmpty()))
            {

                R2110_00_INSERT_V0OUTROSAPOL_SECTION();
            }

            /*" -607- PERFORM R2300-00-DECLARE-OUTRCOBERPROP */

            R2300_00_DECLARE_OUTRCOBERPROP_SECTION();

            /*" -608- MOVE SPACES TO WFIM-V1OUTRCOBERPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1OUTRCOBERPROP);

            /*" -611- PERFORM R2310-00-INSERT-V0OUTROSCOBER UNTIL WFIM-V1OUTRCOBERPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1OUTRCOBERPROP.IsEmpty()))
            {

                R2310_00_INSERT_V0OUTROSCOBER_SECTION();
            }

            /*" -612- PERFORM R2400-00-DECLAR-V1OUTRBENSPROP */

            R2400_00_DECLAR_V1OUTRBENSPROP_SECTION();

            /*" -613- MOVE SPACES TO WFIM-V1OUTRBENSPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1OUTRBENSPROP);

            /*" -616- PERFORM R2410-00-INSERT-V0OUTROSBENS UNTIL WFIM-V1OUTRBENSPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1OUTRBENSPROP.IsEmpty()))
            {

                R2410_00_INSERT_V0OUTROSBENS_SECTION();
            }

            /*" -617- PERFORM R2500-00-DECLA-V1BENSCOBERPROP */

            R2500_00_DECLA_V1BENSCOBERPROP_SECTION();

            /*" -618- MOVE SPACES TO WFIM-V1BENSCOBERPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1BENSCOBERPROP);

            /*" -621- PERFORM R2510-00-INSERT-V0BENSCOBER UNTIL WFIM-V1BENSCOBERPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1BENSCOBERPROP.IsEmpty()))
            {

                R2510_00_INSERT_V0BENSCOBER_SECTION();
            }

            /*" -622- PERFORM R2600-00-DECLA-V1PROPCLAU */

            R2600_00_DECLA_V1PROPCLAU_SECTION();

            /*" -623- MOVE SPACES TO WFIM-V1PROPCLAU */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPCLAU);

            /*" -626- PERFORM R2610-00-INSERT-V0APOLCLAU UNTIL WFIM-V1PROPCLAU NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PROPCLAU.IsEmpty()))
            {

                R2610_00_INSERT_V0APOLCLAU_SECTION();
            }

            /*" -631- IF (V1ENDO-CODPRODU EQUAL ZEROS) OR (V1ENDO-RAMO EQUAL 71) OR (V1ENDO-RAMO EQUAL 14) OR (V1ENDO-RAMO EQUAL 16) OR (V1ENDO-RAMO EQUAL 18) */

            if ((V1ENDO_CODPRODU == 00) || (V1ENDO_RAMO == 71) || (V1ENDO_RAMO == 14) || (V1ENDO_RAMO == 16) || (V1ENDO_RAMO == 18))
            {

                /*" -631- PERFORM R3000-00-MONTA-V0EMISDIARIA. */

                R3000_00_MONTA_V0EMISDIARIA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-SECTION */
        private void R1100_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -647- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -665- PERFORM R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -669- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -671- MOVE 'V1ENDOSSO (DOCUMENTO NAO CADASTRADO)' TO LK-RETORNO */
                    _.Move("V1ENDOSSO (DOCUMENTO NAO CADASTRADO)", LK_PROPOSTA.LK_RETORNO);

                    /*" -672- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -673- ELSE */
                }
                else
                {


                    /*" -675- MOVE 'PROBLEMAS NO SELECT (V1ENDOSSO) ... ' TO LK-RETORNO */
                    _.Move("PROBLEMAS NO SELECT (V1ENDOSSO) ... ", LK_PROPOSTA.LK_RETORNO);

                    /*" -677- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -678- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -678- MOVE ZEROS TO V1ENDO-CODPRODU. */
                _.Move(0, V1ENDO_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -665- EXEC SQL SELECT ORGAO, RAMO, FONTE, COD_MOEDA_PRM, COD_MOEDA_IMP, TIPO_ENDOSSO , CODPRODU INTO :V1ENDO-ORGAO, :V1ENDO-RAMO, :V1ENDO-FONTE, :V1ENDO-MOEDA-PRM, :V1ENDO-MOEDA-IMP, :V1ENDO-TIPO-ENDO, :V1ENDO-CODPRODU:VIND-CODPRODU FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS END-EXEC. */

            var r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_ORGAO, V1ENDO_ORGAO);
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_FONTE, V1ENDO_FONTE);
                _.Move(executed_1.V1ENDO_MOEDA_PRM, V1ENDO_MOEDA_PRM);
                _.Move(executed_1.V1ENDO_MOEDA_IMP, V1ENDO_MOEDA_IMP);
                _.Move(executed_1.V1ENDO_TIPO_ENDO, V1ENDO_TIPO_ENDO);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1MOEDA-SECTION */
        private void R1200_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -692- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -699- PERFORM R1200_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R1200_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -703- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -705- MOVE 'V1MOEDA (NAO EXISTE COTACAO)' TO LK-RETORNO */
                    _.Move("V1MOEDA (NAO EXISTE COTACAO)", LK_PROPOSTA.LK_RETORNO);

                    /*" -706- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -707- ELSE */
                }
                else
                {


                    /*" -709- MOVE 'PROBLEMAS NO SELECT (V1MOEDA) ... ' TO LK-RETORNO */
                    _.Move("PROBLEMAS NO SELECT (V1MOEDA) ... ", LK_PROPOSTA.LK_RETORNO);

                    /*" -711- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -712- IF WHOST-VLCRUZAD NOT NUMERIC */

            if (!WHOST_VLCRUZAD.IsNumeric())
            {

                /*" -714- MOVE 'V1MOEDA (COTACAO INVALIDA)  ' TO LK-RETORNO */
                _.Move("V1MOEDA (COTACAO INVALIDA)  ", LK_PROPOSTA.LK_RETORNO);

                /*" -716- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -717- IF WHOST-VLCRUZAD EQUAL ZEROS */

            if (WHOST_VLCRUZAD == 00)
            {

                /*" -719- MOVE 'V1MOEDA (COTACAO INVALIDA)  ' TO LK-RETORNO */
                _.Move("V1MOEDA (COTACAO INVALIDA)  ", LK_PROPOSTA.LK_RETORNO);

                /*" -719- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R1200_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -699- EXEC SQL SELECT VLCRUZAD INTO :WHOST-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-COD-MOEDA AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

            var r1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                WHOST_COD_MOEDA = WHOST_COD_MOEDA.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLCRUZAD, WHOST_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-V1OUTROSPROP-SECTION */
        private void R2100_00_DECLARE_V1OUTROSPROP_SECTION()
        {
            /*" -733- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -746- PERFORM R2100_00_DECLARE_V1OUTROSPROP_DB_DECLARE_1 */

            R2100_00_DECLARE_V1OUTROSPROP_DB_DECLARE_1();

            /*" -748- PERFORM R2100_00_DECLARE_V1OUTROSPROP_DB_OPEN_1 */

            R2100_00_DECLARE_V1OUTROSPROP_DB_OPEN_1();

            /*" -751- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -753- MOVE 'PROBLEMAS NO OPEN (V1OUTROSPROP) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (V1OUTROSPROP) ", LK_PROPOSTA.LK_RETORNO);

                /*" -753- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1OUTROSPROP-DB-DECLARE-1 */
        public void R2100_00_DECLARE_V1OUTROSPROP_DB_DECLARE_1()
        {
            /*" -746- EXEC SQL DECLARE V1OUTROSPROP CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NRRISCO , CODCLIEN , OCORR_ENDERECO, PROPRIET , COD_LOGRADOURO FROM SEGUROS.V1OUTROSPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY NRRISCO END-EXEC. */
            V1OUTROSPROP = new EM0911S_V1OUTROSPROP(true);
            string GetQuery_V1OUTROSPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRRISCO
							, 
							CODCLIEN
							, 
							OCORR_ENDERECO
							, 
							PROPRIET
							, 
							COD_LOGRADOURO 
							FROM SEGUROS.V1OUTROSPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY NRRISCO";

                return query;
            }
            V1OUTROSPROP.GetQueryEvent += GetQuery_V1OUTROSPROP;

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1OUTROSPROP-DB-OPEN-1 */
        public void R2100_00_DECLARE_V1OUTROSPROP_DB_OPEN_1()
        {
            /*" -748- EXEC SQL OPEN V1OUTROSPROP END-EXEC. */

            V1OUTROSPROP.Open();

        }

        [StopWatch]
        /*" R2300-00-DECLARE-OUTRCOBERPROP-DB-DECLARE-1 */
        public void R2300_00_DECLARE_OUTRCOBERPROP_DB_DECLARE_1()
        {
            /*" -897- EXEC SQL DECLARE V1OUTRCOBERPROP CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NRRISCO , RAMOFR , MODALIFR , COD_COBERTURA , DTINIVIG , DTTERVIG , IMP_SEGURADA_IX , IMP_SEGURADA_VAR , TAXA_IS , PRM_ANUAL_IX , PRM_TARIFARIO_IX , PRM_TARIFARIO_VAR , VRFROBR_IX , LIMITE_INDENIZA_IX, SITUACAO FROM SEGUROS.V1OUTRCOBERPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY NRRISCO , RAMOFR , MODALIFR , COD_COBERTURA END-EXEC. */
            V1OUTRCOBERPROP = new EM0911S_V1OUTRCOBERPROP(true);
            string GetQuery_V1OUTRCOBERPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRRISCO
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							IMP_SEGURADA_IX
							, 
							IMP_SEGURADA_VAR
							, 
							TAXA_IS
							, 
							PRM_ANUAL_IX
							, 
							PRM_TARIFARIO_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							VRFROBR_IX
							, 
							LIMITE_INDENIZA_IX
							, 
							SITUACAO 
							FROM SEGUROS.V1OUTRCOBERPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY NRRISCO
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA";

                return query;
            }
            V1OUTRCOBERPROP.GetQueryEvent += GetQuery_V1OUTRCOBERPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-INSERT-V0OUTROSAPOL-SECTION */
        private void R2110_00_INSERT_V0OUTROSAPOL_SECTION()
        {
            /*" -765- PERFORM R2120-00-FETCH-V1OUTROSPROP */

            R2120_00_FETCH_V1OUTROSPROP_SECTION();

            /*" -766- IF WFIM-V1OUTROSPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1OUTROSPROP.IsEmpty())
            {

                /*" -768- GO TO R2110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -770- PERFORM R2130-00-MONTA-V0OUTROSAPOL */

            R2130_00_MONTA_V0OUTROSAPOL_SECTION();

            /*" -773- MOVE '211' TO WNR-EXEC-SQL. */
            _.Move("211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -786- PERFORM R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1 */

            R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1();

            /*" -789- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -791- MOVE 'V0OUTROSPROP (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0OUTROSPROP (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -793- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -794- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -796- MOVE 'V0OUTROSPROP (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0OUTROSPROP (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -798- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -798- ADD 1 TO AC-I-OUTROSAPOL. */
            AREA_DE_WORK.AC_I_OUTROSAPOL.Value = AREA_DE_WORK.AC_I_OUTROSAPOL + 1;

        }

        [StopWatch]
        /*" R2110-00-INSERT-V0OUTROSAPOL-DB-INSERT-1 */
        public void R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1()
        {
            /*" -786- EXEC SQL INSERT INTO SEGUROS.V0OUTROSAPOL VALUES (:V0APOU-COD-EMPRESA, :V0APOU-FONTE , :V0APOU-NRPROPOS , :V0APOU-NRRISCO , :V0APOU-CODCLIEN , :V0APOU-OCORR-END , :V0APOU-PROPRIET , :V0APOU-COD-LOGRAD , :V0APOU-NUM-APOL , :V0APOU-NRENDOS , CURRENT TIMESTAMP) END-EXEC. */

            var r2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1 = new R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1()
            {
                V0APOU_COD_EMPRESA = V0APOU_COD_EMPRESA.ToString(),
                V0APOU_FONTE = V0APOU_FONTE.ToString(),
                V0APOU_NRPROPOS = V0APOU_NRPROPOS.ToString(),
                V0APOU_NRRISCO = V0APOU_NRRISCO.ToString(),
                V0APOU_CODCLIEN = V0APOU_CODCLIEN.ToString(),
                V0APOU_OCORR_END = V0APOU_OCORR_END.ToString(),
                V0APOU_PROPRIET = V0APOU_PROPRIET.ToString(),
                V0APOU_COD_LOGRAD = V0APOU_COD_LOGRAD.ToString(),
                V0APOU_NUM_APOL = V0APOU_NUM_APOL.ToString(),
                V0APOU_NRENDOS = V0APOU_NRENDOS.ToString(),
            };

            R2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1.Execute(r2110_00_INSERT_V0OUTROSAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-FETCH-V1OUTROSPROP-SECTION */
        private void R2120_00_FETCH_V1OUTROSPROP_SECTION()
        {
            /*" -812- MOVE '212' TO WNR-EXEC-SQL. */
            _.Move("212", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -821- PERFORM R2120_00_FETCH_V1OUTROSPROP_DB_FETCH_1 */

            R2120_00_FETCH_V1OUTROSPROP_DB_FETCH_1();

            /*" -824- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -825- MOVE 'S' TO WFIM-V1OUTROSPROP */
                _.Move("S", AREA_DE_WORK.WFIM_V1OUTROSPROP);

                /*" -825- PERFORM R2120_00_FETCH_V1OUTROSPROP_DB_CLOSE_1 */

                R2120_00_FETCH_V1OUTROSPROP_DB_CLOSE_1();

                /*" -828- GO TO R2120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -832- DISPLAY 'PROBLEMAS NO FETCH (V1OUTROSPROP) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (V1OUTROSPROP) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -834- ADD 1 TO AC-S-OUTROSPROP. */
            AREA_DE_WORK.AC_S_OUTROSPROP.Value = AREA_DE_WORK.AC_S_OUTROSPROP + 1;

        }

        [StopWatch]
        /*" R2120-00-FETCH-V1OUTROSPROP-DB-FETCH-1 */
        public void R2120_00_FETCH_V1OUTROSPROP_DB_FETCH_1()
        {
            /*" -821- EXEC SQL FETCH V1OUTROSPROP INTO :V1PROU-COD-EMPRESA, :V1PROU-FONTE , :V1PROU-NRPROPOS , :V1PROU-NRRISCO , :V1PROU-CODCLIEN , :V1PROU-OCORR-END , :V1PROU-PROPRIET , :V1PROU-COD-LOGRAD END-EXEC. */

            if (V1OUTROSPROP.Fetch())
            {
                _.Move(V1OUTROSPROP.V1PROU_COD_EMPRESA, V1PROU_COD_EMPRESA);
                _.Move(V1OUTROSPROP.V1PROU_FONTE, V1PROU_FONTE);
                _.Move(V1OUTROSPROP.V1PROU_NRPROPOS, V1PROU_NRPROPOS);
                _.Move(V1OUTROSPROP.V1PROU_NRRISCO, V1PROU_NRRISCO);
                _.Move(V1OUTROSPROP.V1PROU_CODCLIEN, V1PROU_CODCLIEN);
                _.Move(V1OUTROSPROP.V1PROU_OCORR_END, V1PROU_OCORR_END);
                _.Move(V1OUTROSPROP.V1PROU_PROPRIET, V1PROU_PROPRIET);
                _.Move(V1OUTROSPROP.V1PROU_COD_LOGRAD, V1PROU_COD_LOGRAD);
            }

        }

        [StopWatch]
        /*" R2120-00-FETCH-V1OUTROSPROP-DB-CLOSE-1 */
        public void R2120_00_FETCH_V1OUTROSPROP_DB_CLOSE_1()
        {
            /*" -825- EXEC SQL CLOSE V1OUTROSPROP END-EXEC */

            V1OUTROSPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-MONTA-V0OUTROSAPOL-SECTION */
        private void R2130_00_MONTA_V0OUTROSAPOL_SECTION()
        {
            /*" -848- MOVE '213' TO WNR-EXEC-SQL. */
            _.Move("213", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -849- MOVE V1PROU-COD-EMPRESA TO V0APOU-COD-EMPRESA */
            _.Move(V1PROU_COD_EMPRESA, V0APOU_COD_EMPRESA);

            /*" -850- MOVE WHOST-FONTE TO V0APOU-FONTE */
            _.Move(WHOST_FONTE, V0APOU_FONTE);

            /*" -851- MOVE WHOST-NRPROPOS TO V0APOU-NRPROPOS */
            _.Move(WHOST_NRPROPOS, V0APOU_NRPROPOS);

            /*" -852- MOVE V1PROU-NRRISCO TO V0APOU-NRRISCO */
            _.Move(V1PROU_NRRISCO, V0APOU_NRRISCO);

            /*" -853- MOVE V1PROU-CODCLIEN TO V0APOU-CODCLIEN */
            _.Move(V1PROU_CODCLIEN, V0APOU_CODCLIEN);

            /*" -854- MOVE V1PROU-OCORR-END TO V0APOU-OCORR-END */
            _.Move(V1PROU_OCORR_END, V0APOU_OCORR_END);

            /*" -855- MOVE V1PROU-PROPRIET TO V0APOU-PROPRIET */
            _.Move(V1PROU_PROPRIET, V0APOU_PROPRIET);

            /*" -856- MOVE V1PROU-COD-LOGRAD TO V0APOU-COD-LOGRAD */
            _.Move(V1PROU_COD_LOGRAD, V0APOU_COD_LOGRAD);

            /*" -857- MOVE WHOST-NUM-APOL TO V0APOU-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APOU_NUM_APOL);

            /*" -857- MOVE WHOST-NRENDOS TO V0APOU-NRENDOS. */
            _.Move(WHOST_NRENDOS, V0APOU_NRENDOS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DECLARE-OUTRCOBERPROP-SECTION */
        private void R2300_00_DECLARE_OUTRCOBERPROP_SECTION()
        {
            /*" -871- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -897- PERFORM R2300_00_DECLARE_OUTRCOBERPROP_DB_DECLARE_1 */

            R2300_00_DECLARE_OUTRCOBERPROP_DB_DECLARE_1();

            /*" -899- PERFORM R2300_00_DECLARE_OUTRCOBERPROP_DB_OPEN_1 */

            R2300_00_DECLARE_OUTRCOBERPROP_DB_OPEN_1();

            /*" -902- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -904- MOVE 'PROBLEMAS NO OPEN (V1OUTRCOBERPROP) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (V1OUTRCOBERPROP) ", LK_PROPOSTA.LK_RETORNO);

                /*" -904- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-DECLARE-OUTRCOBERPROP-DB-OPEN-1 */
        public void R2300_00_DECLARE_OUTRCOBERPROP_DB_OPEN_1()
        {
            /*" -899- EXEC SQL OPEN V1OUTRCOBERPROP END-EXEC. */

            V1OUTRCOBERPROP.Open();

        }

        [StopWatch]
        /*" R2400-00-DECLAR-V1OUTRBENSPROP-DB-DECLARE-1 */
        public void R2400_00_DECLAR_V1OUTRBENSPROP_DB_DECLARE_1()
        {
            /*" -1069- EXEC SQL DECLARE V1OUTRBENSPROP CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NRRISCO , DTINIVIG , DTTERVIG , NRBEM , DESCRBEM , NRSERIE , IMP_SEGURADA_IX FROM SEGUROS.V1OUTRBENSPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY FONTE, NRPROPOS, NRRISCO END-EXEC. */
            V1OUTRBENSPROP = new EM0911S_V1OUTRBENSPROP(true);
            string GetQuery_V1OUTRBENSPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRRISCO
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							NRBEM
							, 
							DESCRBEM
							, 
							NRSERIE
							, 
							IMP_SEGURADA_IX 
							FROM SEGUROS.V1OUTRBENSPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							NRRISCO";

                return query;
            }
            V1OUTRBENSPROP.GetQueryEvent += GetQuery_V1OUTRBENSPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-INSERT-V0OUTROSCOBER-SECTION */
        private void R2310_00_INSERT_V0OUTROSCOBER_SECTION()
        {
            /*" -916- PERFORM R2320-00-FETCH-V1OUTRCOBERPROP */

            R2320_00_FETCH_V1OUTRCOBERPROP_SECTION();

            /*" -917- IF WFIM-V1OUTRCOBERPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1OUTRCOBERPROP.IsEmpty())
            {

                /*" -919- GO TO R2310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -921- PERFORM R2330-00-MONTA-V0OUTROSCOBER */

            R2330_00_MONTA_V0OUTROSCOBER_SECTION();

            /*" -924- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -947- PERFORM R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1 */

            R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1();

            /*" -950- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -952- MOVE 'V0OUTROSCOBER (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0OUTROSCOBER (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -954- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -955- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -957- MOVE 'V0OUTROSCOBER (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0OUTROSCOBER (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -959- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -959- ADD 1 TO AC-I-OUTROSCOBER. */
            AREA_DE_WORK.AC_I_OUTROSCOBER.Value = AREA_DE_WORK.AC_I_OUTROSCOBER + 1;

        }

        [StopWatch]
        /*" R2310-00-INSERT-V0OUTROSCOBER-DB-INSERT-1 */
        public void R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1()
        {
            /*" -947- EXEC SQL INSERT INTO SEGUROS.V0OUTROSCOBER VALUES (:V0APOC-COD-EMPRESA, :V0APOC-FONTE , :V0APOC-NRPROPOS , :V0APOC-NRRISCO , :V0APOC-RAMOFR , :V0APOC-MODALIFR , :V0APOC-COD-COBER , :V0APOC-DTINIVIG , :V0APOC-DTTERVIG , :V0APOC-IMP-SEG-IX , :V0APOC-IMP-SEG-VR , :V0APOC-TAXA-IS , :V0APOC-PRM-ANU-IX , :V0APOC-PRM-TAR-IX , :V0APOC-PRM-TAR-VR , :V0APOC-VRFROBR-IX , :V0APOC-LIM-IND-IX , :V0APOC-SITUACAO , :V0APOC-NUM-APOL , :V0APOC-NRENDOS , CURRENT TIMESTAMP) END-EXEC. */

            var r2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1 = new R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1()
            {
                V0APOC_COD_EMPRESA = V0APOC_COD_EMPRESA.ToString(),
                V0APOC_FONTE = V0APOC_FONTE.ToString(),
                V0APOC_NRPROPOS = V0APOC_NRPROPOS.ToString(),
                V0APOC_NRRISCO = V0APOC_NRRISCO.ToString(),
                V0APOC_RAMOFR = V0APOC_RAMOFR.ToString(),
                V0APOC_MODALIFR = V0APOC_MODALIFR.ToString(),
                V0APOC_COD_COBER = V0APOC_COD_COBER.ToString(),
                V0APOC_DTINIVIG = V0APOC_DTINIVIG.ToString(),
                V0APOC_DTTERVIG = V0APOC_DTTERVIG.ToString(),
                V0APOC_IMP_SEG_IX = V0APOC_IMP_SEG_IX.ToString(),
                V0APOC_IMP_SEG_VR = V0APOC_IMP_SEG_VR.ToString(),
                V0APOC_TAXA_IS = V0APOC_TAXA_IS.ToString(),
                V0APOC_PRM_ANU_IX = V0APOC_PRM_ANU_IX.ToString(),
                V0APOC_PRM_TAR_IX = V0APOC_PRM_TAR_IX.ToString(),
                V0APOC_PRM_TAR_VR = V0APOC_PRM_TAR_VR.ToString(),
                V0APOC_VRFROBR_IX = V0APOC_VRFROBR_IX.ToString(),
                V0APOC_LIM_IND_IX = V0APOC_LIM_IND_IX.ToString(),
                V0APOC_SITUACAO = V0APOC_SITUACAO.ToString(),
                V0APOC_NUM_APOL = V0APOC_NUM_APOL.ToString(),
                V0APOC_NRENDOS = V0APOC_NRENDOS.ToString(),
            };

            R2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1.Execute(r2310_00_INSERT_V0OUTROSCOBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-FETCH-V1OUTRCOBERPROP-SECTION */
        private void R2320_00_FETCH_V1OUTRCOBERPROP_SECTION()
        {
            /*" -973- MOVE '232' TO WNR-EXEC-SQL. */
            _.Move("232", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -992- PERFORM R2320_00_FETCH_V1OUTRCOBERPROP_DB_FETCH_1 */

            R2320_00_FETCH_V1OUTRCOBERPROP_DB_FETCH_1();

            /*" -995- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -996- MOVE 'S' TO WFIM-V1OUTRCOBERPROP */
                _.Move("S", AREA_DE_WORK.WFIM_V1OUTRCOBERPROP);

                /*" -996- PERFORM R2320_00_FETCH_V1OUTRCOBERPROP_DB_CLOSE_1 */

                R2320_00_FETCH_V1OUTRCOBERPROP_DB_CLOSE_1();

                /*" -999- GO TO R2320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1003- DISPLAY 'PROBLEMAS NO FETCH (V1OUTRCOBERPROP) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (V1OUTRCOBERPROP) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1005- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1005- ADD 1 TO AC-S-OUTRCOBERPROP. */
            AREA_DE_WORK.AC_S_OUTRCOBERPROP.Value = AREA_DE_WORK.AC_S_OUTRCOBERPROP + 1;

        }

        [StopWatch]
        /*" R2320-00-FETCH-V1OUTRCOBERPROP-DB-FETCH-1 */
        public void R2320_00_FETCH_V1OUTRCOBERPROP_DB_FETCH_1()
        {
            /*" -992- EXEC SQL FETCH V1OUTRCOBERPROP INTO :V1PRCO-COD-EMPRESA, :V1PRCO-FONTE , :V1PRCO-NRPROPOS , :V1PRCO-NRRISCO , :V1PRCO-RAMOFR , :V1PRCO-MODALIFR , :V1PRCO-COD-COBER , :V1PRCO-DTINIVIG , :V1PRCO-DTTERVIG , :V1PRCO-IMP-SEG-IX , :V1PRCO-IMP-SEG-VR , :V1PRCO-TAXA-IS , :V1PRCO-PRM-ANU-IX , :V1PRCO-PRM-TAR-IX , :V1PRCO-PRM-TAR-VR , :V1PRCO-VRFROBR-IX , :V1PRCO-LIM-IND-IX , :V1PRCO-SITUACAO END-EXEC. */

            if (V1OUTRCOBERPROP.Fetch())
            {
                _.Move(V1OUTRCOBERPROP.V1PRCO_COD_EMPRESA, V1PRCO_COD_EMPRESA);
                _.Move(V1OUTRCOBERPROP.V1PRCO_FONTE, V1PRCO_FONTE);
                _.Move(V1OUTRCOBERPROP.V1PRCO_NRPROPOS, V1PRCO_NRPROPOS);
                _.Move(V1OUTRCOBERPROP.V1PRCO_NRRISCO, V1PRCO_NRRISCO);
                _.Move(V1OUTRCOBERPROP.V1PRCO_RAMOFR, V1PRCO_RAMOFR);
                _.Move(V1OUTRCOBERPROP.V1PRCO_MODALIFR, V1PRCO_MODALIFR);
                _.Move(V1OUTRCOBERPROP.V1PRCO_COD_COBER, V1PRCO_COD_COBER);
                _.Move(V1OUTRCOBERPROP.V1PRCO_DTINIVIG, V1PRCO_DTINIVIG);
                _.Move(V1OUTRCOBERPROP.V1PRCO_DTTERVIG, V1PRCO_DTTERVIG);
                _.Move(V1OUTRCOBERPROP.V1PRCO_IMP_SEG_IX, V1PRCO_IMP_SEG_IX);
                _.Move(V1OUTRCOBERPROP.V1PRCO_IMP_SEG_VR, V1PRCO_IMP_SEG_VR);
                _.Move(V1OUTRCOBERPROP.V1PRCO_TAXA_IS, V1PRCO_TAXA_IS);
                _.Move(V1OUTRCOBERPROP.V1PRCO_PRM_ANU_IX, V1PRCO_PRM_ANU_IX);
                _.Move(V1OUTRCOBERPROP.V1PRCO_PRM_TAR_IX, V1PRCO_PRM_TAR_IX);
                _.Move(V1OUTRCOBERPROP.V1PRCO_PRM_TAR_VR, V1PRCO_PRM_TAR_VR);
                _.Move(V1OUTRCOBERPROP.V1PRCO_VRFROBR_IX, V1PRCO_VRFROBR_IX);
                _.Move(V1OUTRCOBERPROP.V1PRCO_LIM_IND_IX, V1PRCO_LIM_IND_IX);
                _.Move(V1OUTRCOBERPROP.V1PRCO_SITUACAO, V1PRCO_SITUACAO);
            }

        }

        [StopWatch]
        /*" R2320-00-FETCH-V1OUTRCOBERPROP-DB-CLOSE-1 */
        public void R2320_00_FETCH_V1OUTRCOBERPROP_DB_CLOSE_1()
        {
            /*" -996- EXEC SQL CLOSE V1OUTRCOBERPROP END-EXEC */

            V1OUTRCOBERPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2330-00-MONTA-V0OUTROSCOBER-SECTION */
        private void R2330_00_MONTA_V0OUTROSCOBER_SECTION()
        {
            /*" -1019- MOVE '233' TO WNR-EXEC-SQL. */
            _.Move("233", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1020- MOVE V1PRCO-COD-EMPRESA TO V0APOC-COD-EMPRESA */
            _.Move(V1PRCO_COD_EMPRESA, V0APOC_COD_EMPRESA);

            /*" -1021- MOVE WHOST-FONTE TO V0APOC-FONTE */
            _.Move(WHOST_FONTE, V0APOC_FONTE);

            /*" -1022- MOVE WHOST-NRPROPOS TO V0APOC-NRPROPOS */
            _.Move(WHOST_NRPROPOS, V0APOC_NRPROPOS);

            /*" -1023- MOVE V1PRCO-NRRISCO TO V0APOC-NRRISCO */
            _.Move(V1PRCO_NRRISCO, V0APOC_NRRISCO);

            /*" -1024- MOVE V1PRCO-RAMOFR TO V0APOC-RAMOFR */
            _.Move(V1PRCO_RAMOFR, V0APOC_RAMOFR);

            /*" -1025- MOVE V1PRCO-MODALIFR TO V0APOC-MODALIFR */
            _.Move(V1PRCO_MODALIFR, V0APOC_MODALIFR);

            /*" -1026- MOVE V1PRCO-COD-COBER TO V0APOC-COD-COBER */
            _.Move(V1PRCO_COD_COBER, V0APOC_COD_COBER);

            /*" -1027- MOVE V1PRCO-DTINIVIG TO V0APOC-DTINIVIG */
            _.Move(V1PRCO_DTINIVIG, V0APOC_DTINIVIG);

            /*" -1028- MOVE V1PRCO-DTTERVIG TO V0APOC-DTTERVIG */
            _.Move(V1PRCO_DTTERVIG, V0APOC_DTTERVIG);

            /*" -1029- MOVE V1PRCO-IMP-SEG-IX TO V0APOC-IMP-SEG-IX */
            _.Move(V1PRCO_IMP_SEG_IX, V0APOC_IMP_SEG_IX);

            /*" -1030- MOVE V1PRCO-IMP-SEG-VR TO V0APOC-IMP-SEG-VR */
            _.Move(V1PRCO_IMP_SEG_VR, V0APOC_IMP_SEG_VR);

            /*" -1031- MOVE V1PRCO-TAXA-IS TO V0APOC-TAXA-IS */
            _.Move(V1PRCO_TAXA_IS, V0APOC_TAXA_IS);

            /*" -1032- MOVE V1PRCO-PRM-ANU-IX TO V0APOC-PRM-ANU-IX */
            _.Move(V1PRCO_PRM_ANU_IX, V0APOC_PRM_ANU_IX);

            /*" -1033- MOVE V1PRCO-PRM-TAR-IX TO V0APOC-PRM-TAR-IX */
            _.Move(V1PRCO_PRM_TAR_IX, V0APOC_PRM_TAR_IX);

            /*" -1034- MOVE V1PRCO-PRM-TAR-VR TO V0APOC-PRM-TAR-VR */
            _.Move(V1PRCO_PRM_TAR_VR, V0APOC_PRM_TAR_VR);

            /*" -1035- MOVE V1PRCO-VRFROBR-IX TO V0APOC-VRFROBR-IX */
            _.Move(V1PRCO_VRFROBR_IX, V0APOC_VRFROBR_IX);

            /*" -1036- MOVE V1PRCO-LIM-IND-IX TO V0APOC-LIM-IND-IX */
            _.Move(V1PRCO_LIM_IND_IX, V0APOC_LIM_IND_IX);

            /*" -1037- MOVE WHOST-NUM-APOL TO V0APOC-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APOC_NUM_APOL);

            /*" -1038- MOVE WHOST-NRENDOS TO V0APOC-NRENDOS */
            _.Move(WHOST_NRENDOS, V0APOC_NRENDOS);

            /*" -1038- MOVE V1PRCO-SITUACAO TO V0APOC-SITUACAO. */
            _.Move(V1PRCO_SITUACAO, V0APOC_SITUACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2330_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-DECLAR-V1OUTRBENSPROP-SECTION */
        private void R2400_00_DECLAR_V1OUTRBENSPROP_SECTION()
        {
            /*" -1052- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1069- PERFORM R2400_00_DECLAR_V1OUTRBENSPROP_DB_DECLARE_1 */

            R2400_00_DECLAR_V1OUTRBENSPROP_DB_DECLARE_1();

            /*" -1071- PERFORM R2400_00_DECLAR_V1OUTRBENSPROP_DB_OPEN_1 */

            R2400_00_DECLAR_V1OUTRBENSPROP_DB_OPEN_1();

            /*" -1074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1076- MOVE 'PROBLEMAS NO OPEN (V1OUTRBENSPROP) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (V1OUTRBENSPROP) ", LK_PROPOSTA.LK_RETORNO);

                /*" -1076- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-DECLAR-V1OUTRBENSPROP-DB-OPEN-1 */
        public void R2400_00_DECLAR_V1OUTRBENSPROP_DB_OPEN_1()
        {
            /*" -1071- EXEC SQL OPEN V1OUTRBENSPROP END-EXEC. */

            V1OUTRBENSPROP.Open();

        }

        [StopWatch]
        /*" R2500-00-DECLA-V1BENSCOBERPROP-DB-DECLARE-1 */
        public void R2500_00_DECLA_V1BENSCOBERPROP_DB_DECLARE_1()
        {
            /*" -1222- EXEC SQL DECLARE V1BENSCOBERPROP CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NRRISCO , COD_COBERTURA, NRBEM FROM SEGUROS.V1BENSCOBERPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY FONTE, NRPROPOS, NRRISCO END-EXEC. */
            V1BENSCOBERPROP = new EM0911S_V1BENSCOBERPROP(true);
            string GetQuery_V1BENSCOBERPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRRISCO
							, 
							COD_COBERTURA
							, 
							NRBEM 
							FROM SEGUROS.V1BENSCOBERPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							NRRISCO";

                return query;
            }
            V1BENSCOBERPROP.GetQueryEvent += GetQuery_V1BENSCOBERPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-INSERT-V0OUTROSBENS-SECTION */
        private void R2410_00_INSERT_V0OUTROSBENS_SECTION()
        {
            /*" -1088- PERFORM R2420-00-FETCH-V1OUTRBENSPROP */

            R2420_00_FETCH_V1OUTRBENSPROP_SECTION();

            /*" -1089- IF WFIM-V1OUTRBENSPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1OUTRBENSPROP.IsEmpty())
            {

                /*" -1091- GO TO R2410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1093- PERFORM R2430-00-MONTA-V0OUTROSBENS */

            R2430_00_MONTA_V0OUTROSBENS_SECTION();

            /*" -1096- MOVE '241' TO WNR-EXEC-SQL. */
            _.Move("241", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1112- PERFORM R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1 */

            R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1();

            /*" -1115- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1117- MOVE 'V0OUTROSBENS (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0OUTROSBENS (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1119- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1120- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1122- MOVE 'V0OUTROSBENS (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0OUTROSBENS (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1124- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1124- ADD 1 TO AC-I-OUTROSBENS. */
            AREA_DE_WORK.AC_I_OUTROSBENS.Value = AREA_DE_WORK.AC_I_OUTROSBENS + 1;

        }

        [StopWatch]
        /*" R2410-00-INSERT-V0OUTROSBENS-DB-INSERT-1 */
        public void R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1()
        {
            /*" -1112- EXEC SQL INSERT INTO SEGUROS.V0OUTROSBENS VALUES (:V0APOB-COD-EMPRESA, :V0APOB-FONTE , :V0APOB-NRPROPOS , :V0APOB-NRRISCO , :V0APOB-DTINIVIG , :V0APOB-DTTERVIG , :V0APOB-NRBEM , :V0APOB-DESCRBEM , :V0APOB-NRSERIE , :V0APOB-IMP-SEG-IX , :V0APOB-NUM-APOL , :V0APOB-NRENDOS , CURRENT TIMESTAMP) END-EXEC. */

            var r2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1 = new R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1()
            {
                V0APOB_COD_EMPRESA = V0APOB_COD_EMPRESA.ToString(),
                V0APOB_FONTE = V0APOB_FONTE.ToString(),
                V0APOB_NRPROPOS = V0APOB_NRPROPOS.ToString(),
                V0APOB_NRRISCO = V0APOB_NRRISCO.ToString(),
                V0APOB_DTINIVIG = V0APOB_DTINIVIG.ToString(),
                V0APOB_DTTERVIG = V0APOB_DTTERVIG.ToString(),
                V0APOB_NRBEM = V0APOB_NRBEM.ToString(),
                V0APOB_DESCRBEM = V0APOB_DESCRBEM.ToString(),
                V0APOB_NRSERIE = V0APOB_NRSERIE.ToString(),
                V0APOB_IMP_SEG_IX = V0APOB_IMP_SEG_IX.ToString(),
                V0APOB_NUM_APOL = V0APOB_NUM_APOL.ToString(),
                V0APOB_NRENDOS = V0APOB_NRENDOS.ToString(),
            };

            R2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1.Execute(r2410_00_INSERT_V0OUTROSBENS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2420-00-FETCH-V1OUTRBENSPROP-SECTION */
        private void R2420_00_FETCH_V1OUTRBENSPROP_SECTION()
        {
            /*" -1138- MOVE '242' TO WNR-EXEC-SQL. */
            _.Move("242", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1149- PERFORM R2420_00_FETCH_V1OUTRBENSPROP_DB_FETCH_1 */

            R2420_00_FETCH_V1OUTRBENSPROP_DB_FETCH_1();

            /*" -1152- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1153- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1154- MOVE 'S' TO WFIM-V1OUTRBENSPROP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1OUTRBENSPROP);

                    /*" -1154- PERFORM R2420_00_FETCH_V1OUTRBENSPROP_DB_CLOSE_1 */

                    R2420_00_FETCH_V1OUTRBENSPROP_DB_CLOSE_1();

                    /*" -1156- GO TO R2420-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/ //GOTO
                    return;

                    /*" -1157- ELSE */
                }
                else
                {


                    /*" -1159- MOVE 'PROBLEMAS NO FETCH (V1OUTRBENSPROP) ' TO LK-RETORNO */
                    _.Move("PROBLEMAS NO FETCH (V1OUTRBENSPROP) ", LK_PROPOSTA.LK_RETORNO);

                    /*" -1161- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1161- ADD 1 TO AC-S-OUTRBENSPROP. */
            AREA_DE_WORK.AC_S_OUTRBENSPROP.Value = AREA_DE_WORK.AC_S_OUTRBENSPROP + 1;

        }

        [StopWatch]
        /*" R2420-00-FETCH-V1OUTRBENSPROP-DB-FETCH-1 */
        public void R2420_00_FETCH_V1OUTRBENSPROP_DB_FETCH_1()
        {
            /*" -1149- EXEC SQL FETCH V1OUTRBENSPROP INTO :V1PROB-COD-EMPRESA, :V1PROB-FONTE , :V1PROB-NRPROPOS , :V1PROB-NRRISCO , :V1PROB-DTINIVIG , :V1PROB-DTTERVIG , :V1PROB-NRBEM , :V1PROB-DESCRBEM , :V1PROB-NRSERIE , :V1PROB-IMP-SEG-IX END-EXEC. */

            if (V1OUTRBENSPROP.Fetch())
            {
                _.Move(V1OUTRBENSPROP.V1PROB_COD_EMPRESA, V1PROB_COD_EMPRESA);
                _.Move(V1OUTRBENSPROP.V1PROB_FONTE, V1PROB_FONTE);
                _.Move(V1OUTRBENSPROP.V1PROB_NRPROPOS, V1PROB_NRPROPOS);
                _.Move(V1OUTRBENSPROP.V1PROB_NRRISCO, V1PROB_NRRISCO);
                _.Move(V1OUTRBENSPROP.V1PROB_DTINIVIG, V1PROB_DTINIVIG);
                _.Move(V1OUTRBENSPROP.V1PROB_DTTERVIG, V1PROB_DTTERVIG);
                _.Move(V1OUTRBENSPROP.V1PROB_NRBEM, V1PROB_NRBEM);
                _.Move(V1OUTRBENSPROP.V1PROB_DESCRBEM, V1PROB_DESCRBEM);
                _.Move(V1OUTRBENSPROP.V1PROB_NRSERIE, V1PROB_NRSERIE);
                _.Move(V1OUTRBENSPROP.V1PROB_IMP_SEG_IX, V1PROB_IMP_SEG_IX);
            }

        }

        [StopWatch]
        /*" R2420-00-FETCH-V1OUTRBENSPROP-DB-CLOSE-1 */
        public void R2420_00_FETCH_V1OUTRBENSPROP_DB_CLOSE_1()
        {
            /*" -1154- EXEC SQL CLOSE V1OUTRBENSPROP END-EXEC */

            V1OUTRBENSPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2430-00-MONTA-V0OUTROSBENS-SECTION */
        private void R2430_00_MONTA_V0OUTROSBENS_SECTION()
        {
            /*" -1175- MOVE '243' TO WNR-EXEC-SQL. */
            _.Move("243", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1176- MOVE V1PROB-DTINIVIG TO WHOST-DTINIVIG */
            _.Move(V1PROB_DTINIVIG, WHOST_DTINIVIG);

            /*" -1177- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

            /*" -1178- PERFORM R1200-00-SELECT-V1MOEDA */

            R1200_00_SELECT_V1MOEDA_SECTION();

            /*" -1180- MOVE WHOST-VLCRUZAD TO V1MOED-VLCR-PRM */
            _.Move(WHOST_VLCRUZAD, V1MOED_VLCR_PRM);

            /*" -1181- MOVE V1ENDO-MOEDA-IMP TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_IMP, WHOST_COD_MOEDA);

            /*" -1182- PERFORM R1200-00-SELECT-V1MOEDA */

            R1200_00_SELECT_V1MOEDA_SECTION();

            /*" -1184- MOVE WHOST-VLCRUZAD TO V1MOED-VLCR-IMP */
            _.Move(WHOST_VLCRUZAD, V1MOED_VLCR_IMP);

            /*" -1185- MOVE WHOST-NUM-APOL TO V0APOB-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APOB_NUM_APOL);

            /*" -1186- MOVE WHOST-NRENDOS TO V0APOB-NRENDOS */
            _.Move(WHOST_NRENDOS, V0APOB_NRENDOS);

            /*" -1187- MOVE V1PROB-COD-EMPRESA TO V0APOB-COD-EMPRESA */
            _.Move(V1PROB_COD_EMPRESA, V0APOB_COD_EMPRESA);

            /*" -1188- MOVE V1PROB-FONTE TO V0APOB-FONTE */
            _.Move(V1PROB_FONTE, V0APOB_FONTE);

            /*" -1189- MOVE V1PROB-NRPROPOS TO V0APOB-NRPROPOS */
            _.Move(V1PROB_NRPROPOS, V0APOB_NRPROPOS);

            /*" -1190- MOVE V1PROB-NRRISCO TO V0APOB-NRRISCO */
            _.Move(V1PROB_NRRISCO, V0APOB_NRRISCO);

            /*" -1191- MOVE V1PROB-DTINIVIG TO V0APOB-DTINIVIG */
            _.Move(V1PROB_DTINIVIG, V0APOB_DTINIVIG);

            /*" -1192- MOVE V1PROB-DTTERVIG TO V0APOB-DTTERVIG */
            _.Move(V1PROB_DTTERVIG, V0APOB_DTTERVIG);

            /*" -1193- MOVE V1PROB-NRBEM TO V0APOB-NRBEM */
            _.Move(V1PROB_NRBEM, V0APOB_NRBEM);

            /*" -1194- MOVE V1PROB-DESCRBEM TO V0APOB-DESCRBEM */
            _.Move(V1PROB_DESCRBEM, V0APOB_DESCRBEM);

            /*" -1195- MOVE V1PROB-NRSERIE TO V0APOB-NRSERIE */
            _.Move(V1PROB_NRSERIE, V0APOB_NRSERIE);

            /*" -1195- MOVE V1PROB-IMP-SEG-IX TO V0APOB-IMP-SEG-IX. */
            _.Move(V1PROB_IMP_SEG_IX, V0APOB_IMP_SEG_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2430_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-DECLA-V1BENSCOBERPROP-SECTION */
        private void R2500_00_DECLA_V1BENSCOBERPROP_SECTION()
        {
            /*" -1209- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1222- PERFORM R2500_00_DECLA_V1BENSCOBERPROP_DB_DECLARE_1 */

            R2500_00_DECLA_V1BENSCOBERPROP_DB_DECLARE_1();

            /*" -1224- PERFORM R2500_00_DECLA_V1BENSCOBERPROP_DB_OPEN_1 */

            R2500_00_DECLA_V1BENSCOBERPROP_DB_OPEN_1();

            /*" -1227- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1229- MOVE 'PROBLEMAS NO OPEN (V1BENSCOBERPROP) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (V1BENSCOBERPROP) ", LK_PROPOSTA.LK_RETORNO);

                /*" -1229- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-DECLA-V1BENSCOBERPROP-DB-OPEN-1 */
        public void R2500_00_DECLA_V1BENSCOBERPROP_DB_OPEN_1()
        {
            /*" -1224- EXEC SQL OPEN V1BENSCOBERPROP END-EXEC. */

            V1BENSCOBERPROP.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLA-V1PROPCLAU-DB-DECLARE-1 */
        public void R2600_00_DECLA_V1PROPCLAU_DB_DECLARE_1()
        {
            /*" -1350- EXEC SQL DECLARE V1PROPCLAU CURSOR FOR SELECT COD_EMPRESA, FONTE, NRPROPOS, RAMOFR, MODALIFR, COD_COBERTURA, DTINIVIG, DTTERVIG, NRITEM, CODCLAUS, LIMITE_INDENIZA_IX FROM SEGUROS.V1PROPCLAUSULA WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY FONTE, NRPROPOS END-EXEC. */
            V1PROPCLAU = new EM0911S_V1PROPCLAU(true);
            string GetQuery_V1PROPCLAU()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							NRITEM
							, 
							CODCLAUS
							, 
							LIMITE_INDENIZA_IX 
							FROM SEGUROS.V1PROPCLAUSULA 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY FONTE
							, NRPROPOS";

                return query;
            }
            V1PROPCLAU.GetQueryEvent += GetQuery_V1PROPCLAU;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-INSERT-V0BENSCOBER-SECTION */
        private void R2510_00_INSERT_V0BENSCOBER_SECTION()
        {
            /*" -1241- PERFORM R2520-00-FETCH-V1BENSCOBERPROP */

            R2520_00_FETCH_V1BENSCOBERPROP_SECTION();

            /*" -1242- IF WFIM-V1BENSCOBERPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1BENSCOBERPROP.IsEmpty())
            {

                /*" -1244- GO TO R2510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1246- PERFORM R2530-00-MONTA-V0BENSCOBER */

            R2530_00_MONTA_V0BENSCOBER_SECTION();

            /*" -1249- MOVE '251' TO WNR-EXEC-SQL. */
            _.Move("251", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1260- PERFORM R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1 */

            R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1();

            /*" -1263- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1265- MOVE 'V0BENSCOBER (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0BENSCOBER (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1267- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1268- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1270- MOVE 'V0BENSCOBER (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0BENSCOBER (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1272- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1272- ADD 1 TO AC-I-BENSCOBER. */
            AREA_DE_WORK.AC_I_BENSCOBER.Value = AREA_DE_WORK.AC_I_BENSCOBER + 1;

        }

        [StopWatch]
        /*" R2510-00-INSERT-V0BENSCOBER-DB-INSERT-1 */
        public void R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1()
        {
            /*" -1260- EXEC SQL INSERT INTO SEGUROS.V0BENSCOBER VALUES (:V0APBC-COD-EMPRESA:VIND-COD-EMP, :V0APBC-FONTE , :V0APBC-NRPROPOS , :V0APBC-NRRISCO , :V0APBC-COD-COBER , :V0APBC-NRBEM , :V0APBC-NUM-APOL , :V0APBC-NRENDOS , CURRENT TIMESTAMP) END-EXEC. */

            var r2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1 = new R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1()
            {
                V0APBC_COD_EMPRESA = V0APBC_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0APBC_FONTE = V0APBC_FONTE.ToString(),
                V0APBC_NRPROPOS = V0APBC_NRPROPOS.ToString(),
                V0APBC_NRRISCO = V0APBC_NRRISCO.ToString(),
                V0APBC_COD_COBER = V0APBC_COD_COBER.ToString(),
                V0APBC_NRBEM = V0APBC_NRBEM.ToString(),
                V0APBC_NUM_APOL = V0APBC_NUM_APOL.ToString(),
                V0APBC_NRENDOS = V0APBC_NRENDOS.ToString(),
            };

            R2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1.Execute(r2510_00_INSERT_V0BENSCOBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-FETCH-V1BENSCOBERPROP-SECTION */
        private void R2520_00_FETCH_V1BENSCOBERPROP_SECTION()
        {
            /*" -1286- MOVE '252' TO WNR-EXEC-SQL. */
            _.Move("252", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1293- PERFORM R2520_00_FETCH_V1BENSCOBERPROP_DB_FETCH_1 */

            R2520_00_FETCH_V1BENSCOBERPROP_DB_FETCH_1();

            /*" -1296- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1297- MOVE 'S' TO WFIM-V1BENSCOBERPROP */
                _.Move("S", AREA_DE_WORK.WFIM_V1BENSCOBERPROP);

                /*" -1297- PERFORM R2520_00_FETCH_V1BENSCOBERPROP_DB_CLOSE_1 */

                R2520_00_FETCH_V1BENSCOBERPROP_DB_CLOSE_1();

                /*" -1300- GO TO R2520-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1300- ADD 1 TO AC-S-BENSCOBERPROP. */
            AREA_DE_WORK.AC_S_BENSCOBERPROP.Value = AREA_DE_WORK.AC_S_BENSCOBERPROP + 1;

        }

        [StopWatch]
        /*" R2520-00-FETCH-V1BENSCOBERPROP-DB-FETCH-1 */
        public void R2520_00_FETCH_V1BENSCOBERPROP_DB_FETCH_1()
        {
            /*" -1293- EXEC SQL FETCH V1BENSCOBERPROP INTO :V1PRBC-COD-EMPRESA:VIND-COD-EMP, :V1PRBC-FONTE , :V1PRBC-NRPROPOS , :V1PRBC-NRRISCO , :V1PRBC-COD-COBER , :V1PRBC-NRBEM END-EXEC. */

            if (V1BENSCOBERPROP.Fetch())
            {
                _.Move(V1BENSCOBERPROP.V1PRBC_COD_EMPRESA, V1PRBC_COD_EMPRESA);
                _.Move(V1BENSCOBERPROP.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(V1BENSCOBERPROP.V1PRBC_FONTE, V1PRBC_FONTE);
                _.Move(V1BENSCOBERPROP.V1PRBC_NRPROPOS, V1PRBC_NRPROPOS);
                _.Move(V1BENSCOBERPROP.V1PRBC_NRRISCO, V1PRBC_NRRISCO);
                _.Move(V1BENSCOBERPROP.V1PRBC_COD_COBER, V1PRBC_COD_COBER);
                _.Move(V1BENSCOBERPROP.V1PRBC_NRBEM, V1PRBC_NRBEM);
            }

        }

        [StopWatch]
        /*" R2520-00-FETCH-V1BENSCOBERPROP-DB-CLOSE-1 */
        public void R2520_00_FETCH_V1BENSCOBERPROP_DB_CLOSE_1()
        {
            /*" -1297- EXEC SQL CLOSE V1BENSCOBERPROP END-EXEC */

            V1BENSCOBERPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R2530-00-MONTA-V0BENSCOBER-SECTION */
        private void R2530_00_MONTA_V0BENSCOBER_SECTION()
        {
            /*" -1314- MOVE '253' TO WNR-EXEC-SQL. */
            _.Move("253", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1315- MOVE WHOST-NUM-APOL TO V0APBC-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APBC_NUM_APOL);

            /*" -1316- MOVE WHOST-NRENDOS TO V0APBC-NRENDOS */
            _.Move(WHOST_NRENDOS, V0APBC_NRENDOS);

            /*" -1317- MOVE V1PRBC-COD-EMPRESA TO V0APBC-COD-EMPRESA */
            _.Move(V1PRBC_COD_EMPRESA, V0APBC_COD_EMPRESA);

            /*" -1318- MOVE V1PRBC-FONTE TO V0APBC-FONTE */
            _.Move(V1PRBC_FONTE, V0APBC_FONTE);

            /*" -1319- MOVE V1PRBC-NRPROPOS TO V0APBC-NRPROPOS */
            _.Move(V1PRBC_NRPROPOS, V0APBC_NRPROPOS);

            /*" -1320- MOVE V1PRBC-NRRISCO TO V0APBC-NRRISCO */
            _.Move(V1PRBC_NRRISCO, V0APBC_NRRISCO);

            /*" -1321- MOVE V1PRBC-COD-COBER TO V0APBC-COD-COBER */
            _.Move(V1PRBC_COD_COBER, V0APBC_COD_COBER);

            /*" -1321- MOVE V1PRBC-NRBEM TO V0APBC-NRBEM. */
            _.Move(V1PRBC_NRBEM, V0APBC_NRBEM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLA-V1PROPCLAU-SECTION */
        private void R2600_00_DECLA_V1PROPCLAU_SECTION()
        {
            /*" -1334- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1350- PERFORM R2600_00_DECLA_V1PROPCLAU_DB_DECLARE_1 */

            R2600_00_DECLA_V1PROPCLAU_DB_DECLARE_1();

            /*" -1352- PERFORM R2600_00_DECLA_V1PROPCLAU_DB_OPEN_1 */

            R2600_00_DECLA_V1PROPCLAU_DB_OPEN_1();

            /*" -1355- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1356- DISPLAY 'R2600-00 (ERRO DECLARE V1PROPCLAU)' */
                _.Display($"R2600-00 (ERRO DECLARE V1PROPCLAU)");

                /*" -1356- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-DECLA-V1PROPCLAU-DB-OPEN-1 */
        public void R2600_00_DECLA_V1PROPCLAU_DB_OPEN_1()
        {
            /*" -1352- EXEC SQL OPEN V1PROPCLAU END-EXEC. */

            V1PROPCLAU.Open();

        }

        [StopWatch]
        /*" R4200-00-DECLA-V1OUTRCOBERPROP-DB-DECLARE-1 */
        public void R4200_00_DECLA_V1OUTRCOBERPROP_DB_DECLARE_1()
        {
            /*" -1653- EXEC SQL DECLARE V1OUTRCOBERP CURSOR FOR SELECT FONTE, NRPROPOS, NRRISCO, RAMOFR, MODALIFR, COD_COBERTURA, IMP_SEGURADA_IX, IMP_SEGURADA_VAR, PRM_TARIFARIO_IX, PRM_TARIFARIO_VAR, DTINIVIG, DTTERVIG FROM SEGUROS.V1OUTRCOBERPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY FONTE, NRPROPOS, RAMOFR, NRRISCO END-EXEC. */
            V1OUTRCOBERP = new EM0911S_V1OUTRCOBERP(true);
            string GetQuery_V1OUTRCOBERP()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS
							, 
							NRRISCO
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA
							, 
							IMP_SEGURADA_IX
							, 
							IMP_SEGURADA_VAR
							, 
							PRM_TARIFARIO_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							DTINIVIG
							, 
							DTTERVIG 
							FROM SEGUROS.V1OUTRCOBERPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							RAMOFR
							, 
							NRRISCO";

                return query;
            }
            V1OUTRCOBERP.GetQueryEvent += GetQuery_V1OUTRCOBERP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-INSERT-V0APOLCLAU-SECTION */
        private void R2610_00_INSERT_V0APOLCLAU_SECTION()
        {
            /*" -1368- PERFORM R2620-00-FETCH-V1PROPCLAU */

            R2620_00_FETCH_V1PROPCLAU_SECTION();

            /*" -1369- IF WFIM-V1PROPCLAU NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPCLAU.IsEmpty())
            {

                /*" -1371- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1373- PERFORM R2630-00-MONTA-V0APOLCLAU */

            R2630_00_MONTA_V0APOLCLAU_SECTION();

            /*" -1375- MOVE '263' TO WNR-EXEC-SQL. */
            _.Move("263", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1390- PERFORM R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1 */

            R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1();

            /*" -1393- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1396- DISPLAY 'R2610-00 (REGISTRO DUPLICADO) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"R2610-00 (REGISTRO DUPLICADO) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1398- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1399- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1402- DISPLAY 'R2610-00 (PROBLEMAS NA INSERCAO) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"R2610-00 (PROBLEMAS NA INSERCAO) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1404- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1404- ADD +1 TO AC-I-APOLCLAU. */
            AREA_DE_WORK.AC_I_APOLCLAU.Value = AREA_DE_WORK.AC_I_APOLCLAU + +1;

        }

        [StopWatch]
        /*" R2610-00-INSERT-V0APOLCLAU-DB-INSERT-1 */
        public void R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1()
        {
            /*" -1390- EXEC SQL INSERT INTO SEGUROS.V0APOLCLAUSULA VALUES (:V0APCL-COD-EMPRESA:VIND-COD-EMP, :V0APCL-NUM-APOL, :V0APCL-NRENDOS, :V0APCL-RAMOFR, :V0APCL-MODALIFR, :V0APCL-COD-COBERT, :V0APCL-DTINIVIG, :V0APCL-DTTERVIG, :V0APCL-NRITEM, :V0APCL-CODCLAUS, '0' , :V0APCL-LIM-IND-IX, CURRENT TIMESTAMP) END-EXEC. */

            var r2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1 = new R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1()
            {
                V0APCL_COD_EMPRESA = V0APCL_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0APCL_NUM_APOL = V0APCL_NUM_APOL.ToString(),
                V0APCL_NRENDOS = V0APCL_NRENDOS.ToString(),
                V0APCL_RAMOFR = V0APCL_RAMOFR.ToString(),
                V0APCL_MODALIFR = V0APCL_MODALIFR.ToString(),
                V0APCL_COD_COBERT = V0APCL_COD_COBERT.ToString(),
                V0APCL_DTINIVIG = V0APCL_DTINIVIG.ToString(),
                V0APCL_DTTERVIG = V0APCL_DTTERVIG.ToString(),
                V0APCL_NRITEM = V0APCL_NRITEM.ToString(),
                V0APCL_CODCLAUS = V0APCL_CODCLAUS.ToString(),
                V0APCL_LIM_IND_IX = V0APCL_LIM_IND_IX.ToString(),
            };

            R2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1.Execute(r2610_00_INSERT_V0APOLCLAU_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2620-00-FETCH-V1PROPCLAU-SECTION */
        private void R2620_00_FETCH_V1PROPCLAU_SECTION()
        {
            /*" -1417- MOVE '262' TO WNR-EXEC-SQL. */
            _.Move("262", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1429- PERFORM R2620_00_FETCH_V1PROPCLAU_DB_FETCH_1 */

            R2620_00_FETCH_V1PROPCLAU_DB_FETCH_1();

            /*" -1432- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1433- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1434- MOVE 'S' TO WFIM-V1PROPCLAU */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PROPCLAU);

                    /*" -1434- PERFORM R2620_00_FETCH_V1PROPCLAU_DB_CLOSE_1 */

                    R2620_00_FETCH_V1PROPCLAU_DB_CLOSE_1();

                    /*" -1436- GO TO R2620-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/ //GOTO
                    return;

                    /*" -1437- ELSE */
                }
                else
                {


                    /*" -1438- DISPLAY 'R2620-00 (ERRO FETCH V1PROPCLAU) ... ' */
                    _.Display($"R2620-00 (ERRO FETCH V1PROPCLAU) ... ");

                    /*" -1440- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1440- ADD +1 TO AC-S-PROPCLAU. */
            AREA_DE_WORK.AC_S_PROPCLAU.Value = AREA_DE_WORK.AC_S_PROPCLAU + +1;

        }

        [StopWatch]
        /*" R2620-00-FETCH-V1PROPCLAU-DB-FETCH-1 */
        public void R2620_00_FETCH_V1PROPCLAU_DB_FETCH_1()
        {
            /*" -1429- EXEC SQL FETCH V1PROPCLAU INTO :V1PRCL-COD-EMPRESA:VIND-COD-EMP, :V1PRCL-FONTE, :V1PRCL-NRPROPOS, :V1PRCL-RAMOFR, :V1PRCL-MODALIFR, :V1PRCL-COD-COBERT, :V1PRCL-DTINIVIG, :V1PRCL-DTTERVIG, :V1PRCL-NRITEM, :V1PRCL-CODCLAUS, :V1PRCL-LIM-IND-IX END-EXEC. */

            if (V1PROPCLAU.Fetch())
            {
                _.Move(V1PROPCLAU.V1PRCL_COD_EMPRESA, V1PRCL_COD_EMPRESA);
                _.Move(V1PROPCLAU.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(V1PROPCLAU.V1PRCL_FONTE, V1PRCL_FONTE);
                _.Move(V1PROPCLAU.V1PRCL_NRPROPOS, V1PRCL_NRPROPOS);
                _.Move(V1PROPCLAU.V1PRCL_RAMOFR, V1PRCL_RAMOFR);
                _.Move(V1PROPCLAU.V1PRCL_MODALIFR, V1PRCL_MODALIFR);
                _.Move(V1PROPCLAU.V1PRCL_COD_COBERT, V1PRCL_COD_COBERT);
                _.Move(V1PROPCLAU.V1PRCL_DTINIVIG, V1PRCL_DTINIVIG);
                _.Move(V1PROPCLAU.V1PRCL_DTTERVIG, V1PRCL_DTTERVIG);
                _.Move(V1PROPCLAU.V1PRCL_NRITEM, V1PRCL_NRITEM);
                _.Move(V1PROPCLAU.V1PRCL_CODCLAUS, V1PRCL_CODCLAUS);
                _.Move(V1PROPCLAU.V1PRCL_LIM_IND_IX, V1PRCL_LIM_IND_IX);
            }

        }

        [StopWatch]
        /*" R2620-00-FETCH-V1PROPCLAU-DB-CLOSE-1 */
        public void R2620_00_FETCH_V1PROPCLAU_DB_CLOSE_1()
        {
            /*" -1434- EXEC SQL CLOSE V1PROPCLAU END-EXEC */

            V1PROPCLAU.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/

        [StopWatch]
        /*" R2630-00-MONTA-V0APOLCLAU-SECTION */
        private void R2630_00_MONTA_V0APOLCLAU_SECTION()
        {
            /*" -1453- MOVE '263' TO WNR-EXEC-SQL. */
            _.Move("263", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1454- MOVE ZEROS TO V0APCL-COD-EMPRESA */
            _.Move(0, V0APCL_COD_EMPRESA);

            /*" -1455- MOVE WHOST-NUM-APOL TO V0APCL-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APCL_NUM_APOL);

            /*" -1456- MOVE ZEROS TO V0APCL-NRENDOS */
            _.Move(0, V0APCL_NRENDOS);

            /*" -1457- MOVE V1PRCL-RAMOFR TO V0APCL-RAMOFR */
            _.Move(V1PRCL_RAMOFR, V0APCL_RAMOFR);

            /*" -1458- MOVE V1PRCL-MODALIFR TO V0APCL-MODALIFR */
            _.Move(V1PRCL_MODALIFR, V0APCL_MODALIFR);

            /*" -1459- MOVE V1PRCL-COD-COBERT TO V0APCL-COD-COBERT */
            _.Move(V1PRCL_COD_COBERT, V0APCL_COD_COBERT);

            /*" -1460- MOVE V1PRCL-DTINIVIG TO V0APCL-DTINIVIG */
            _.Move(V1PRCL_DTINIVIG, V0APCL_DTINIVIG);

            /*" -1461- MOVE V1PRCL-DTTERVIG TO V0APCL-DTTERVIG */
            _.Move(V1PRCL_DTTERVIG, V0APCL_DTTERVIG);

            /*" -1462- MOVE V1PRCL-NRITEM TO V0APCL-NRITEM */
            _.Move(V1PRCL_NRITEM, V0APCL_NRITEM);

            /*" -1463- MOVE V1PRCL-CODCLAUS TO V0APCL-CODCLAUS */
            _.Move(V1PRCL_CODCLAUS, V0APCL_CODCLAUS);

            /*" -1463- MOVE V1PRCL-LIM-IND-IX TO V0APCL-LIM-IND-IX. */
            _.Move(V1PRCL_LIM_IND_IX, V0APCL_LIM_IND_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2630_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-V0EMISDIARIA-SECTION */
        private void R3000_00_MONTA_V0EMISDIARIA_SECTION()
        {
            /*" -1481- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1483- MOVE 'EM0200B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0200B1", V0EDIA_CODRELAT);

            /*" -1484- MOVE WHOST-NUM-APOL TO V0EDIA-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0EDIA_NUM_APOL);

            /*" -1485- MOVE WHOST-NRENDOS TO V0EDIA-NRENDOS */
            _.Move(WHOST_NRENDOS, V0EDIA_NRENDOS);

            /*" -1486- MOVE ZEROS TO V0EDIA-NRPARCEL */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -1487- MOVE WHOST-DTMOVABE TO V0EDIA-DTMOVTO */
            _.Move(WHOST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -1488- MOVE V1ENDO-ORGAO TO V0EDIA-ORGAO */
            _.Move(V1ENDO_ORGAO, V0EDIA_ORGAO);

            /*" -1489- MOVE V1ENDO-RAMO TO V0EDIA-RAMO */
            _.Move(V1ENDO_RAMO, V0EDIA_RAMO);

            /*" -1490- MOVE V1ENDO-FONTE TO V0EDIA-FONTE */
            _.Move(V1ENDO_FONTE, V0EDIA_FONTE);

            /*" -1491- MOVE ZEROS TO V0EDIA-CONGENER */
            _.Move(0, V0EDIA_CONGENER);

            /*" -1496- MOVE WHOST-CODCORR TO V0EDIA-CODCORR */
            _.Move(WHOST_CODCORR, V0EDIA_CODCORR);

            /*" -1497- IF V1ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (V1ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -1498- MOVE '9' TO V0EDIA-SITUACAO */
                _.Move("9", V0EDIA_SITUACAO);

                /*" -1499- ELSE */
            }
            else
            {


                /*" -1501- MOVE '0' TO V0EDIA-SITUACAO. */
                _.Move("0", V0EDIA_SITUACAO);
            }


            /*" -1502- MOVE V1PROU-COD-EMPRESA TO V0EDIA-COD-EMPRESA. */
            _.Move(V1PROU_COD_EMPRESA, V0EDIA_COD_EMPRESA);

            /*" -1507- PERFORM R3100-00-INSERT-V0EMISDIARIA */

            R3100_00_INSERT_V0EMISDIARIA_SECTION();

            /*" -1508- MOVE 'EM0220B1' TO V0EDIA-CODRELAT */
            _.Move("EM0220B1", V0EDIA_CODRELAT);

            /*" -1510- PERFORM R3100-00-INSERT-V0EMISDIARIA. */

            R3100_00_INSERT_V0EMISDIARIA_SECTION();

            /*" -1511- MOVE 'EM0241B1' TO V0EDIA-CODRELAT */
            _.Move("EM0241B1", V0EDIA_CODRELAT);

            /*" -1511- PERFORM R3100-00-INSERT-V0EMISDIARIA. */

            R3100_00_INSERT_V0EMISDIARIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-V0EMISDIARIA-SECTION */
        private void R3100_00_INSERT_V0EMISDIARIA_SECTION()
        {
            /*" -1525- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1540- PERFORM R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1 */

            R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1();

            /*" -1543- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1545- MOVE 'V0EMISDIARIA (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0EMISDIARIA (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1547- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1550- MOVE 'V0EMISDIARIA (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0EMISDIARIA (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1552- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1552- ADD 1 TO AC-I-EMISDIARIA. */
            AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + 1;

        }

        [StopWatch]
        /*" R3100-00-INSERT-V0EMISDIARIA-DB-INSERT-1 */
        public void R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -1540- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1()
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
                V0EDIA_COD_EMPRESA = V0EDIA_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATAMENTO-COBERAPOL-SECTION */
        private void R4000_00_TRATAMENTO_COBERAPOL_SECTION()
        {
            /*" -1566- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1567- MOVE ZEROS TO W1COBP-PRM-TAR-VR */
            _.Move(0, W1COBP_PRM_TAR_VR);

            /*" -1569- MOVE ZEROS TO W1COBP-PCT-TOTAL */
            _.Move(0, W1COBP_PCT_TOTAL);

            /*" -1570- MOVE SPACES TO WFIM-V1OUTRCOBERP */
            _.Move("", AREA_DE_WORK.WFIM_V1OUTRCOBERP);

            /*" -1572- MOVE SPACES TO CH-I-V0COBERAPOL */
            _.Move("", AREA_DE_WORK.CH_I_V0COBERAPOL);

            /*" -1574- PERFORM R4100-00-SELEC-V1OUTRCOBERPROP */

            R4100_00_SELEC_V1OUTRCOBERPROP_SECTION();

            /*" -1575- PERFORM R4200-00-DECLA-V1OUTRCOBERPROP */

            R4200_00_DECLA_V1OUTRCOBERPROP_SECTION();

            /*" -1576- PERFORM R4210-00-FETCH-V1OUTRCOBERPROP */

            R4210_00_FETCH_V1OUTRCOBERPROP_SECTION();

            /*" -1577- IF WFIM-V1OUTRCOBERP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1OUTRCOBERP.IsEmpty())
            {

                /*" -1579- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1582- PERFORM R4300-00-INSERT-V0COBERAPOL UNTIL WFIM-V1OUTRCOBERP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1OUTRCOBERP.IsEmpty()))
            {

                R4300_00_INSERT_V0COBERAPOL_SECTION();
            }

            /*" -1583- IF CH-I-V0COBERAPOL NOT EQUAL SPACES */

            if (!AREA_DE_WORK.CH_I_V0COBERAPOL.IsEmpty())
            {

                /*" -1583- PERFORM R5000-00-UPDATE-V0COBERAPOL. */

                R5000_00_UPDATE_V0COBERAPOL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-SELEC-V1OUTRCOBERPROP-SECTION */
        private void R4100_00_SELEC_V1OUTRCOBERPROP_SECTION()
        {
            /*" -1597- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1603- PERFORM R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1 */

            R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1();

            /*" -1606- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1608- MOVE 'PROBLEMAS NO SUM (V1OUTRCOBERPROP) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO SUM (V1OUTRCOBERPROP) ", LK_PROPOSTA.LK_RETORNO);

                /*" -1610- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1611- IF VIND-PRMTARIFA LESS 0 */

            if (VIND_PRMTARIFA < 0)
            {

                /*" -1613- MOVE ZEROS TO W1COBP-PRM-TAR-VR. */
                _.Move(0, W1COBP_PRM_TAR_VR);
            }


            /*" -1614- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1616- MOVE ZEROS TO W1COBP-PRM-TAR-VR. */
                _.Move(0, W1COBP_PRM_TAR_VR);
            }


            /*" -1618- IF (V1ENDO-TIPO-ENDO EQUAL '3' OR '5' ) AND (W1COBP-PRM-TAR-VR NOT EQUAL ZEROS) */

            if ((V1ENDO_TIPO_ENDO.In("3", "5")) && (W1COBP_PRM_TAR_VR != 00))
            {

                /*" -1619- COMPUTE W1COBP-PRM-TAR-VR = W1COBP-PRM-TAR-VR * -1. */
                W1COBP_PRM_TAR_VR.Value = W1COBP_PRM_TAR_VR * -1;
            }


        }

        [StopWatch]
        /*" R4100-00-SELEC-V1OUTRCOBERPROP-DB-SELECT-1 */
        public void R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1()
        {
            /*" -1603- EXEC SQL SELECT SUM(PRM_TARIFARIO_VAR) INTO :W1COBP-PRM-TAR-VR:VIND-PRMTARIFA FROM SEGUROS.V1OUTRCOBERPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS END-EXEC. */

            var r4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1_Query1 = new R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1_Query1()
            {
                WHOST_NRPROPOS = WHOST_NRPROPOS.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
            };

            var executed_1 = R4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1_Query1.Execute(r4100_00_SELEC_V1OUTRCOBERPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1COBP_PRM_TAR_VR, W1COBP_PRM_TAR_VR);
                _.Move(executed_1.VIND_PRMTARIFA, VIND_PRMTARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-DECLA-V1OUTRCOBERPROP-SECTION */
        private void R4200_00_DECLA_V1OUTRCOBERPROP_SECTION()
        {
            /*" -1633- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1653- PERFORM R4200_00_DECLA_V1OUTRCOBERPROP_DB_DECLARE_1 */

            R4200_00_DECLA_V1OUTRCOBERPROP_DB_DECLARE_1();

            /*" -1655- PERFORM R4200_00_DECLA_V1OUTRCOBERPROP_DB_OPEN_1 */

            R4200_00_DECLA_V1OUTRCOBERPROP_DB_OPEN_1();

            /*" -1658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1660- MOVE 'PROBLEMAS NO OPEN (V1OUTRCOBERPROP) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (V1OUTRCOBERPROP) ", LK_PROPOSTA.LK_RETORNO);

                /*" -1660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4200-00-DECLA-V1OUTRCOBERPROP-DB-OPEN-1 */
        public void R4200_00_DECLA_V1OUTRCOBERPROP_DB_OPEN_1()
        {
            /*" -1655- EXEC SQL OPEN V1OUTRCOBERP END-EXEC. */

            V1OUTRCOBERP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4210-00-FETCH-V1OUTRCOBERPROP-SECTION */
        private void R4210_00_FETCH_V1OUTRCOBERPROP_SECTION()
        {
            /*" -1674- MOVE '421' TO WNR-EXEC-SQL. */
            _.Move("421", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1687- PERFORM R4210_00_FETCH_V1OUTRCOBERPROP_DB_FETCH_1 */

            R4210_00_FETCH_V1OUTRCOBERPROP_DB_FETCH_1();

            /*" -1690- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1691- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1692- MOVE 'S' TO WFIM-V1OUTRCOBERP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1OUTRCOBERP);

                    /*" -1693- MOVE HIGH-VALUES TO CH-COBER-ATU */

                    AREA_DE_WORK.CH_COBER_ATU.IsHighValues = true;

                    /*" -1693- PERFORM R4210_00_FETCH_V1OUTRCOBERPROP_DB_CLOSE_1 */

                    R4210_00_FETCH_V1OUTRCOBERPROP_DB_CLOSE_1();

                    /*" -1695- GO TO R4210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1696- ELSE */
                }
                else
                {


                    /*" -1698- MOVE 'PROBLEMAS NO FETCH (V1OUTRCOBERPROP) ' TO LK-RETORNO */
                    _.Move("PROBLEMAS NO FETCH (V1OUTRCOBERPROP) ", LK_PROPOSTA.LK_RETORNO);

                    /*" -1700- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1701- MOVE V1COBP-FONTE TO CH-FONT-ATU */
            _.Move(V1COBP_FONTE, AREA_DE_WORK.CH_COBER_ATU.CH_FONT_ATU);

            /*" -1702- MOVE V1COBP-NRPROPOS TO CH-PROP-ATU */
            _.Move(V1COBP_NRPROPOS, AREA_DE_WORK.CH_COBER_ATU.CH_PROP_ATU);

            /*" -1704- MOVE V1COBP-RAMOFR TO CH-RAMO-ATU. */
            _.Move(V1COBP_RAMOFR, AREA_DE_WORK.CH_COBER_ATU.CH_RAMO_ATU);

            /*" -1704- ADD 1 TO AC-S-OUTRCOBERP. */
            AREA_DE_WORK.AC_S_OUTRCOBERP.Value = AREA_DE_WORK.AC_S_OUTRCOBERP + 1;

        }

        [StopWatch]
        /*" R4210-00-FETCH-V1OUTRCOBERPROP-DB-FETCH-1 */
        public void R4210_00_FETCH_V1OUTRCOBERPROP_DB_FETCH_1()
        {
            /*" -1687- EXEC SQL FETCH V1OUTRCOBERP INTO :V1COBP-FONTE , :V1COBP-NRPROPOS , :V1COBP-NRRISCO , :V1COBP-RAMOFR , :V1COBP-MODALIFR , :V1COBP-COD-COBER , :V1COBP-IMP-SEG-IX, :V1COBP-IMP-SEG-VR, :V1COBP-PRM-TAR-IX, :V1COBP-PRM-TAR-VR, :V1COBP-DTINIVIG , :V1COBP-DTTERVIG END-EXEC. */

            if (V1OUTRCOBERP.Fetch())
            {
                _.Move(V1OUTRCOBERP.V1PRCO_COD_EMPRESA, V1COBP_FONTE);
                _.Move(V1OUTRCOBERP.V1PRCO_FONTE, V1COBP_NRPROPOS);
                _.Move(V1OUTRCOBERP.V1PRCO_NRPROPOS, V1COBP_NRRISCO);
                _.Move(V1OUTRCOBERP.V1PRCO_NRRISCO, V1COBP_RAMOFR);
                _.Move(V1OUTRCOBERP.V1PRCO_RAMOFR, V1COBP_MODALIFR);
                _.Move(V1OUTRCOBERP.V1PRCO_MODALIFR, V1COBP_COD_COBER);
                _.Move(V1OUTRCOBERP.V1PRCO_COD_COBER, V1COBP_IMP_SEG_IX);
                _.Move(V1OUTRCOBERP.V1PRCO_DTINIVIG, V1COBP_IMP_SEG_VR);
                _.Move(V1OUTRCOBERP.V1PRCO_DTTERVIG, V1COBP_PRM_TAR_IX);
                _.Move(V1OUTRCOBERP.V1PRCO_IMP_SEG_IX, V1COBP_PRM_TAR_VR);
                _.Move(V1OUTRCOBERP.V1PRCO_IMP_SEG_VR, V1COBP_DTINIVIG);
                _.Move(V1OUTRCOBERP.V1PRCO_TAXA_IS, V1COBP_DTTERVIG);
            }

        }

        [StopWatch]
        /*" R4210-00-FETCH-V1OUTRCOBERPROP-DB-CLOSE-1 */
        public void R4210_00_FETCH_V1OUTRCOBERPROP_DB_CLOSE_1()
        {
            /*" -1693- EXEC SQL CLOSE V1OUTRCOBERP END-EXEC */

            V1OUTRCOBERP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INSERT-V0COBERAPOL-SECTION */
        private void R4300_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -1718- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1719- MOVE ZEROS TO W0COBA-IMP-SEG-IX */
            _.Move(0, W0COBA_IMP_SEG_IX);

            /*" -1720- MOVE ZEROS TO W0COBA-PRM-TAR-IX */
            _.Move(0, W0COBA_PRM_TAR_IX);

            /*" -1721- MOVE ZEROS TO W0COBA-IMP-SEG-VR */
            _.Move(0, W0COBA_IMP_SEG_VR);

            /*" -1723- MOVE ZEROS TO W0COBA-PRM-TAR-VR */
            _.Move(0, W0COBA_PRM_TAR_VR);

            /*" -1725- MOVE CH-COBER-ATU TO CH-COBER-ANT */
            _.Move(AREA_DE_WORK.CH_COBER_ATU, AREA_DE_WORK.CH_COBER_ANT);

            /*" -1728- PERFORM R4400-00-MONTA-COBER-ITEM UNTIL CH-COBER-ATU NOT EQUAL CH-COBER-ANT. */

            while (!(AREA_DE_WORK.CH_COBER_ATU != AREA_DE_WORK.CH_COBER_ANT))
            {

                R4400_00_MONTA_COBER_ITEM_SECTION();
            }

            /*" -1730- PERFORM R4500-00-MONTA-COBER-TOT */

            R4500_00_MONTA_COBER_TOT_SECTION();

            /*" -1730- PERFORM R4600-00-INSERE-V0COBERAPOL. */

            R4600_00_INSERE_V0COBERAPOL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-MONTA-COBER-ITEM-SECTION */
        private void R4400_00_MONTA_COBER_ITEM_SECTION()
        {
            /*" -1746- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1747- ADD V1COBP-IMP-SEG-IX TO W0COBA-IMP-SEG-IX */
            W0COBA_IMP_SEG_IX.Value = W0COBA_IMP_SEG_IX + V1COBP_IMP_SEG_IX;

            /*" -1748- ADD V1COBP-PRM-TAR-IX TO W0COBA-PRM-TAR-IX */
            W0COBA_PRM_TAR_IX.Value = W0COBA_PRM_TAR_IX + V1COBP_PRM_TAR_IX;

            /*" -1749- ADD V1COBP-IMP-SEG-VR TO W0COBA-IMP-SEG-VR */
            W0COBA_IMP_SEG_VR.Value = W0COBA_IMP_SEG_VR + V1COBP_IMP_SEG_VR;

            /*" -1749- ADD V1COBP-PRM-TAR-VR TO W0COBA-PRM-TAR-VR. */
            W0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR + V1COBP_PRM_TAR_VR;

            /*" -0- FLUXCONTROL_PERFORM R4400_90_LEITURA_COBERPROP */

            R4400_90_LEITURA_COBERPROP();

        }

        [StopWatch]
        /*" R4400-90-LEITURA-COBERPROP */
        private void R4400_90_LEITURA_COBERPROP(bool isPerform = false)
        {
            /*" -1753- PERFORM R4210-00-FETCH-V1OUTRCOBERPROP. */

            R4210_00_FETCH_V1OUTRCOBERPROP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-MONTA-COBER-TOT-SECTION */
        private void R4500_00_MONTA_COBER_TOT_SECTION()
        {
            /*" -1767- MOVE '450' TO WNR-EXEC-SQL. */
            _.Move("450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1768- MOVE WHOST-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0COBA_NUM_APOL);

            /*" -1769- MOVE WHOST-NRENDOS TO V0COBA-NRENDOS */
            _.Move(WHOST_NRENDOS, V0COBA_NRENDOS);

            /*" -1770- MOVE CH-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(AREA_DE_WORK.CH_COBER_ANT.CH_RAMO_ANT, V0COBA_RAMOFR);

            /*" -1773- MOVE ZEROS TO V0COBA-MODALIFR V0COBA-NUM-ITEM V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_MODALIFR, V0COBA_NUM_ITEM, V0COBA_COD_EMPRESA);

            /*" -1774- MOVE V0APOC-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0APOC_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -1776- MOVE V0APOC-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0APOC_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -1777- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -1779- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -1781- IF ((V1ENDO-TIPO-ENDO EQUAL '3' OR '5' ) AND (W0COBA-PRM-TAR-VR NOT EQUAL ZEROS)) */

            if (((V1ENDO_TIPO_ENDO.In("3", "5")) && (W0COBA_PRM_TAR_VR != 00)))
            {

                /*" -1784- COMPUTE W0COBA-PRM-TAR-VR = W0COBA-PRM-TAR-VR * -1. */
                W0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR * -1;
            }


            /*" -1785- MOVE W0COBA-IMP-SEG-IX TO V0COBA-IMP-SEG-IX */
            _.Move(W0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_IX);

            /*" -1786- MOVE W0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-IX */
            _.Move(W0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_IX);

            /*" -1787- MOVE W0COBA-IMP-SEG-VR TO V0COBA-IMP-SEG-VR */
            _.Move(W0COBA_IMP_SEG_VR, V0COBA_IMP_SEG_VR);

            /*" -1789- MOVE W0COBA-PRM-TAR-VR TO V0COBA-PRM-TAR-VR */
            _.Move(W0COBA_PRM_TAR_VR, V0COBA_PRM_TAR_VR);

            /*" -1790- IF W1COBP-PRM-TAR-VR EQUAL ZEROS */

            if (W1COBP_PRM_TAR_VR == 00)
            {

                /*" -1791- MOVE ZEROS TO V0COBA-PCT-COBERT */
                _.Move(0, V0COBA_PCT_COBERT);

                /*" -1792- ELSE */
            }
            else
            {


                /*" -1793- IF W0COBA-PRM-TAR-VR NOT EQUAL ZEROS */

                if (W0COBA_PRM_TAR_VR != 00)
                {

                    /*" -1796- COMPUTE V0COBA-PCT-COBERT = W0COBA-PRM-TAR-VR * 100 / W1COBP-PRM-TAR-VR */
                    V0COBA_PCT_COBERT.Value = W0COBA_PRM_TAR_VR * 100 / W1COBP_PRM_TAR_VR;

                    /*" -1797- ELSE */
                }
                else
                {


                    /*" -1799- MOVE ZEROS TO V0COBA-PCT-COBERT. */
                    _.Move(0, V0COBA_PCT_COBERT);
                }

            }


            /*" -1801- ADD V0COBA-PCT-COBERT TO W1COBP-PCT-TOTAL */
            W1COBP_PCT_TOTAL.Value = W1COBP_PCT_TOTAL + V0COBA_PCT_COBERT;

            /*" -1801- MOVE 1 TO V0COBA-FATOR-MULT. */
            _.Move(1, V0COBA_FATOR_MULT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INSERE-V0COBERAPOL-SECTION */
        private void R4600_00_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -1815- MOVE '460' TO WNR-EXEC-SQL. */
            _.Move("460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1835- PERFORM R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1 */

            R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -1838- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1844- DISPLAY 'R4600-00 (REGISTRO DUPLICADO) ... ' ' ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"R4600-00 (REGISTRO DUPLICADO) ...  {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1846- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1847- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1853- DISPLAY 'R4600-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"R4600-00 (PROBLEMAS NA INSERCAO) ...  {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1855- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1857- MOVE '*' TO CH-I-V0COBERAPOL. */
            _.Move("*", AREA_DE_WORK.CH_I_V0COBERAPOL);

            /*" -1857- ADD 1 TO AC-I-COBERAPOL. */
            AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + 1;

        }

        [StopWatch]
        /*" R4600-00-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -1835- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA, CURRENT TIMESTAMP , NULL) END-EXEC. */

            var r4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
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
            };

            R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-UPDATE-V0COBERAPOL-SECTION */
        private void R5000_00_UPDATE_V0COBERAPOL_SECTION()
        {
            /*" -1871- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1872- IF W1COBP-PCT-TOTAL EQUAL ZEROS */

            if (W1COBP_PCT_TOTAL == 00)
            {

                /*" -1874- GO TO R5000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1878- COMPUTE V0COBA-PCT-COBERT = V0COBA-PCT-COBERT + (100 - W1COBP-PCT-TOTAL) */
            V0COBA_PCT_COBERT.Value = V0COBA_PCT_COBERT + (100 - W1COBP_PCT_TOTAL);

            /*" -1888- PERFORM R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1 */

            R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1();

            /*" -1891- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1896- DISPLAY 'R5000-00 (PROBLEMAS UPDATE V0COBERAPOL) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS ' ' WHOST-NUM-APOL ' ' WHOST-NRENDOS */

                $"R5000-00 (PROBLEMAS UPDATE V0COBERAPOL) ...  {WHOST_FONTE} {WHOST_NRPROPOS} {WHOST_NUM_APOL} {WHOST_NRENDOS}"
                .Display();

                /*" -1896- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-UPDATE-V0COBERAPOL-DB-UPDATE-1 */
        public void R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -1888- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET PCT_COBERTURA = :V0COBA-PCT-COBERT, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0COBA-NUM-APOL AND NRENDOS = :V0COBA-NRENDOS AND NUM_ITEM = :V0COBA-NUM-ITEM AND OCORHIST = :V0COBA-OCORHIST AND RAMOFR = :V0COBA-RAMOFR AND MODALIFR = :V0COBA-MODALIFR END-EXEC. */

            var r5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 = new R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1()
            {
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
            };

            R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1.Execute(r5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1912- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1914- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1914- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1916- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1920- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1922- IF LK-RETORNO EQUAL SPACES OR LOW-VALUES */

            if (LK_PROPOSTA.LK_RETORNO.IsLowValues())
            {

                /*" -1924- MOVE ALL '*' TO LK-RETORNO. */
                _.MoveAll("*", LK_PROPOSTA.LK_RETORNO);
            }


            /*" -1924- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}