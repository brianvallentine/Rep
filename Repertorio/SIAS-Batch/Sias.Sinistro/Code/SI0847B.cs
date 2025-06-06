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
using Sias.Sinistro.DB2.SI0847B;

namespace Code
{
    public class SI0847B
    {
        public bool IsCall { get; set; }

        public SI0847B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - EDSON              */
        /*"      *-----------------------------------------------------------*           */
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0847B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  BARAN                              *      */
        /*"      *   PROGRAMADOR ............  BARAN                              *      */
        /*"      *   DATA CODIFICACAO .......  FEV/1999                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  RELACAO DE SINISTROS AVISADOS      *      */
        /*"      *                             PERDA TOTAL AZULCAR POR FILIAL     *      */
        /*"      *                             EM MM/AAAA.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * EMPRESAS                            V1EMPRESA         INPUT    *      */
        /*"      * RELATORIOS                          V0RELATORIOS      I-O      *      */
        /*"      * FONTE                               V1FONTE           INPUT    *      */
        /*"      * HISTORICO DE SINISTRO               V1HISTSINI        INPUT    *      */
        /*"      * MESTRE DE SINISTRO                  V1MESTSINI        INPUT    *      */
        /*"      * SINISTROS DE AUTO                   V1SINISTRO-AUTO1  INPUT    *      */
        /*"      * CAUSAS DE SINISTRO                  V1SINICAUSA       INPUT    *      */
        /*"      * DESCRICAO DO VEICULO                V1DESCRVEI        INPUT    *      */
        /*"      * AUTOAPOL                            V1AUTOAPOL        INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * 24/09/2018 - CADMUS 168975 - LISIANE BRAGANCA SOARES           *      */
        /*"      *              MUDANCA NA PLACA DO VEICULO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    03/03/2001 - ENRICO (PRODEXTER) - PROCURAR EB0303           *      */
        /*"      *                 INCLUSAO DA VERSAO NO ACESSO DA TABELA         *      */
        /*"      *                 V1DESCRVEI                                     *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR JO0800)                                          *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0847B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0847B
        {
            get
            {
                _.Move(REG_SI0847B, _RSI0847B); VarBasis.RedefinePassValue(REG_SI0847B, _RSI0847B, REG_SI0847B); return _RSI0847B;
            }
        }
        /*"01              REG-SI0847B.*/
        public SI0847B_REG_SI0847B REG_SI0847B { get; set; } = new SI0847B_REG_SI0847B();
        public class SI0847B_REG_SI0847B : VarBasis
        {
            /*"  05            REG-LINHA             PIC  X(132).*/
            public StringBasis REG_LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-PRMTAR         PIC S9(004)                COMP.*/
        public IntBasis VIND_PRMTAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COUNT          PIC S9(004)                COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-MESREFER      PIC S9(004)                COMP.*/
        public IntBasis WHOST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-ANOREFER      PIC S9(004)                COMP.*/
        public IntBasis WHOST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-COUNT         PIC S9(004)                COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NIVEL         PIC S9(004)                COMP.*/
        public IntBasis WHOST_NIVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-CODRELAT      PIC  X(008).*/
        public StringBasis WHOST_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(004)                COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RELA-MES-REFER    PIC S9(004)                COMP.*/
        public IntBasis V1RELA_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-ANO-REFER    PIC S9(004)                COMP.*/
        public IntBasis V1RELA_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-SITUACAO     PIC  X(001).*/
        public StringBasis V1RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SCAU-DESCAU       PIC  X(040).*/
        public StringBasis V1SCAU_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1APOL-NOME         PIC  X(040).*/
        public StringBasis V1APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1RAMO-NOMERAMO     PIC  X(040).*/
        public StringBasis V1RAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1MSIN-COD-EMP      PIC S9(009)                COMP.*/
        public IntBasis V1MSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77         V1MSIN-NRCERTIF     PIC S9(015)                COMP-3*/
        public IntBasis V1MSIN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
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
        /*"77         V1MSIN-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V1MSIN_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         HOST-FONTE          PIC S9(004)                COMP.*/
        public IntBasis HOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HSIN-COD-EMP      PIC S9(009)                COMP.*/
        public IntBasis V1HSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HSIN-TIPREG       PIC  X(001).*/
        public StringBasis V1HSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HSIN-NUM-SINI     PIC S9(013)                COMP-3*/
        public IntBasis V1HSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HSIN-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V1HSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HSIN-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V1HSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HSIN-HORAOPER     PIC  X(008).*/
        public StringBasis V1HSIN_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HSIN-NOMFAV       PIC  X(040).*/
        public StringBasis V1HSIN_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1HSIN-VAL-OPERACAO PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1HSIN_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1HSIN-LIMCRR       PIC  X(010).*/
        public StringBasis V1HSIN_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HSIN-TIPFAV       PIC  X(001).*/
        public StringBasis V1HSIN_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HSIN-DATNEG       PIC  X(010).*/
        public StringBasis V1HSIN_DATNEG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HSIN-FONPAG       PIC S9(004)                COMP.*/
        public IntBasis V1HSIN_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HSIN-CODPSVI      PIC S9(009)                COMP.*/
        public IntBasis V1HSIN_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HSIN-CODSVI       PIC S9(004)                COMP.*/
        public IntBasis V1HSIN_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HSIN-NUMOPG       PIC S9(009)                COMP.*/
        public IntBasis V1HSIN_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HSIN-NUMREC       PIC S9(009)                COMP.*/
        public IntBasis V1HSIN_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HSIN-MOVPCS       PIC S9(009)                COMP.*/
        public IntBasis V1HSIN_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HSIN-CODUSU       PIC  X(008).*/
        public StringBasis V1HSIN_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HSIN-SITCONTB     PIC  X(001).*/
        public StringBasis V1HSIN_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1HSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1HSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1SAUT-NRITEM       PIC S9(009)                COMP.*/
        public IntBasis V1SAUT_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1DVEI-CDVEICL      PIC S9(009)                COMP.*/
        public IntBasis V1DVEI_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1DVEI-VERSAO       PIC S9(009)                COMP.*/
        public IntBasis V1DVEI_VERSAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1DVEI-DESCVEIC     PIC  X(040).*/
        public StringBasis V1DVEI_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1AUAP-ANOVEICL     PIC S9(004)                COMP.*/
        public IntBasis V1AUAP_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUAP-ANOMOD       PIC S9(004)                COMP.*/
        public IntBasis V1AUAP_ANOMOD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUAP-PLACAUF      PIC  X(002).*/
        public StringBasis V1AUAP_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1AUAP-PLACALET     PIC  X(003).*/
        public StringBasis V1AUAP_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1AUAP-PLACANR      PIC  X(004).*/
        public StringBasis V1AUAP_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77         V1AUAP-CHASSIS      PIC  X(020).*/
        public StringBasis V1AUAP_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1AUAP-PROPRIET     PIC  X(040).*/
        public StringBasis V1AUAP_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1AUAP-NRPRRESS     PIC S9(009)                COMP.*/
        public IntBasis V1AUAP_NRPRRESS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FONT-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1FONT_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01              AREA-DE-WORK.*/
        public SI0847B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0847B_AREA_DE_WORK();
        public class SI0847B_AREA_DE_WORK : VarBasis
        {
            /*"  05            FILLER          PIC  X(035)    VALUE                'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"  05            AC-PENDENTE     PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-LINIMP       PIC 9(005)    VALUE  ZEROS.*/
            public IntBasis AC_LINIMP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WSTATUS         PIC  X(002)   VALUE   ZEROS.*/
            public StringBasis WSTATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05            WZEROS          PIC S9(003)   VALUE  +0  COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05            WRESTO          PIC S9(005)   VALUE  +0  COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05            WCH-FINAL       PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WCODRELAT       PIC  X(008)   VALUE  SPACES.*/
            public StringBasis WCODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05            FILLER          REDEFINES     WCODRELAT.*/
            private _REDEF_SI0847B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_SI0847B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_SI0847B_FILLER_1(); _.Move(WCODRELAT, _filler_1); VarBasis.RedefinePassValue(WCODRELAT, _filler_1, WCODRELAT); _filler_1.ValueChanged += () => { _.Move(_filler_1, WCODRELAT); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WCODRELAT); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_1 : VarBasis
            {
                /*"    10          WNOME-PROGRAMA.*/
                public SI0847B_WNOME_PROGRAMA WNOME_PROGRAMA { get; set; } = new SI0847B_WNOME_PROGRAMA();
                public class SI0847B_WNOME_PROGRAMA : VarBasis
                {
                    /*"      15        WNOME-PROGRAM   PIC  X(007).*/
                    public StringBasis WNOME_PROGRAM { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"      15        WNOME-SEQUENC   PIC  X(001).*/
                    public StringBasis WNOME_SEQUENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"  05            WFIM-V1SISTEMA  PIC  X(001)     VALUE SPACES.*/

                    public SI0847B_WNOME_PROGRAMA()
                    {
                        WNOME_PROGRAM.ValueChanged += OnValueChanged;
                        WNOME_SEQUENC.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_SI0847B_FILLER_1()
                {
                    WNOME_PROGRAMA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-SINISTRO   PIC  X(001)     VALUE SPACES.*/
            public StringBasis WFIM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-PROCESSO   PIC  X(001)     VALUE LOW-VALUES*/
            public StringBasis WFIM_PROCESSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05            WFIM-V1RELATORIOS PIC  X(001)   VALUE SPACES.*/
            public StringBasis WFIM_V1RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-FECHAMENTO   PIC  X(001)   VALUE SPACES.*/
            public StringBasis WFIM_FECHAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            AC-LINHAS       PIC  9(002)     VALUE  80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05            AC-PAGINA       PIC  9(004)     VALUE  ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-V1SISTEMA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_S_V1SISTEMA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-V1SISTEMA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_U_V1SISTEMA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-V1SISTEMA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_I_V1SISTEMA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-V1SISTEMA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_D_V1SISTEMA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-V1EMPRESA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_S_V1EMPRESA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-V1EMPRESA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_U_V1EMPRESA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-V1EMPRESA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_I_V1EMPRESA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-V1EMPRESA  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_D_V1EMPRESA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-V1RELATOR  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_S_V1RELATOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-V1RELATOR  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_U_V1RELATOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-V1RELATOR  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_I_V1RELATOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-V1RELATOR  PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_D_V1RELATOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-V1FONTES   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_S_V1FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-V1FONTES   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_U_V1FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-V1FONTES   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_I_V1FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-V1FONTES   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_D_V1FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-V1RAMOS    PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_S_V1RAMOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-V1RAMOS    PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_U_V1RAMOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-V1RAMOS    PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_I_V1RAMOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-V1RAMOS    PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_D_V1RAMOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-SINISTRO   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_S_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-SINISTRO   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_U_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-SINISTRO   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_I_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-SINISTRO   PIC  9(005)     VALUE ZEROS.*/
            public IntBasis AC_D_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WWORK-SELECT    PIC  ZZZZZ.*/
            public StringBasis WWORK_SELECT { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            WWORK-UPDATE    PIC  ZZZZZ.*/
            public StringBasis WWORK_UPDATE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            WWORK-INSERT    PIC  ZZZZZ.*/
            public StringBasis WWORK_INSERT { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            WWORK-DELETE    PIC  ZZZZZ.*/
            public StringBasis WWORK_DELETE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            CH-FONTE-ATU     PIC  9(004).*/
            public IntBasis CH_FONTE_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05            CH-CAUSA-ATU     PIC  9(004).*/
            public IntBasis CH_CAUSA_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05            CH-FONTE-ANT     PIC  9(004).*/
            public IntBasis CH_FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05            CH-CAUSA-ANT     PIC  9(004).*/
            public IntBasis CH_CAUSA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WTIME-DAY         PIC  99.99.99.99.*/
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_SI0847B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_SI0847B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_SI0847B_FILLER_2(); _.Move(WTIME_DAY, _filler_2); VarBasis.RedefinePassValue(WTIME_DAY, _filler_2, WTIME_DAY); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTIME_DAY); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_2 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public SI0847B_WTIME_DAYR WTIME_DAYR { get; set; } = new SI0847B_WTIME_DAYR();
                public class SI0847B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public SI0847B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE        PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WDATA-CURR.*/

                public _REDEF_SI0847B_FILLER_2()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public SI0847B_WDATA_CURR WDATA_CURR { get; set; } = new SI0847B_WDATA_CURR();
            public class SI0847B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-CURR.*/
            }
            public SI0847B_WHORA_CURR WHORA_CURR { get; set; } = new SI0847B_WHORA_CURR();
            public class SI0847B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public SI0847B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0847B_WDATA_CABEC();
            public class SI0847B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public SI0847B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0847B_WHORA_CABEC();
            public class SI0847B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-DTMOVTO     PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-DTMOVTO.*/
            private _REDEF_SI0847B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_SI0847B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_SI0847B_FILLER_9(); _.Move(WDATA_DTMOVTO, _filler_9); VarBasis.RedefinePassValue(WDATA_DTMOVTO, _filler_9, WDATA_DTMOVTO); _filler_9.ValueChanged += () => { _.Move(_filler_9, WDATA_DTMOVTO); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WDATA_DTMOVTO); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_9 : VarBasis
            {
                /*"    10       WDATA-ANOMOV      PIC  9(004).*/
                public IntBasis WDATA_ANOMOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MESMOV      PIC  9(002).*/
                public IntBasis WDATA_MESMOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DIAMOV      PIC  9(002).*/
                public IntBasis WDATA_DIAMOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-INIVIG      PIC  X(010)    VALUE ZEROS.*/

                public _REDEF_SI0847B_FILLER_9()
                {
                    WDATA_ANOMOV.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDATA_MESMOV.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WDATA_DIAMOV.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-INIVIG.*/
            private _REDEF_SI0847B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_SI0847B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_SI0847B_FILLER_12(); _.Move(WDATA_INIVIG, _filler_12); VarBasis.RedefinePassValue(WDATA_INIVIG, _filler_12, WDATA_INIVIG); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_INIVIG); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_INIVIG); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_12 : VarBasis
            {
                /*"    10       WDATA-INI-ANO     PIC  9(004).*/
                public IntBasis WDATA_INI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-INI-MES     PIC  9(002).*/
                public IntBasis WDATA_INI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-INI-DIA     PIC  9(002).*/
                public IntBasis WDATA_INI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-TERVIG      PIC  X(010)    VALUE ZEROS.*/

                public _REDEF_SI0847B_FILLER_12()
                {
                    WDATA_INI_ANO.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDATA_INI_MES.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDATA_INI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-TERVIG.*/
            private _REDEF_SI0847B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_SI0847B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_SI0847B_FILLER_15(); _.Move(WDATA_TERVIG, _filler_15); VarBasis.RedefinePassValue(WDATA_TERVIG, _filler_15, WDATA_TERVIG); _filler_15.ValueChanged += () => { _.Move(_filler_15, WDATA_TERVIG); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WDATA_TERVIG); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_15 : VarBasis
            {
                /*"    10       WDATA-TER-ANO     PIC  9(004).*/
                public IntBasis WDATA_TER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-TER-MES     PIC  9(002).*/
                public IntBasis WDATA_TER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-TER-DIA     PIC  9(002).*/
                public IntBasis WDATA_TER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_SI0847B_FILLER_15()
                {
                    WDATA_TER_ANO.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                    WDATA_TER_MES.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    WDATA_TER_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_SI0847B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_SI0847B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_SI0847B_FILLER_18(); _.Move(WDATA_REL, _filler_18); VarBasis.RedefinePassValue(WDATA_REL, _filler_18, WDATA_REL); _filler_18.ValueChanged += () => { _.Move(_filler_18, WDATA_REL); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, WDATA_REL); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_18 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_SI0847B_FILLER_18()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_19.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_20.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public SI0847B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new SI0847B_WDAT_REL_LIT();
            public class SI0847B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WREFE-REFERENCIA  PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WREFE_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WREFE-REFERENCIA.*/
            private _REDEF_SI0847B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_SI0847B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_SI0847B_FILLER_23(); _.Move(WREFE_REFERENCIA, _filler_23); VarBasis.RedefinePassValue(WREFE_REFERENCIA, _filler_23, WREFE_REFERENCIA); _filler_23.ValueChanged += () => { _.Move(_filler_23, WREFE_REFERENCIA); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WREFE_REFERENCIA); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_23 : VarBasis
            {
                /*"    10       WREFE-ANOREFER    PIC  9(004).*/
                public IntBasis WREFE_ANOREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREFE-MESREFER    PIC  9(002).*/
                public IntBasis WREFE_MESREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREFE-DIAREFER    PIC  9(002).*/
                public IntBasis WREFE_DIAREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA     PIC  X(010)    VALUE SPACES.*/

                public _REDEF_SI0847B_FILLER_23()
                {
                    WREFE_ANOREFER.ValueChanged += OnValueChanged;
                    FILLER_24.ValueChanged += OnValueChanged;
                    WREFE_MESREFER.ValueChanged += OnValueChanged;
                    FILLER_25.ValueChanged += OnValueChanged;
                    WREFE_DIAREFER.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-SISTEMA.*/
            private _REDEF_SI0847B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_SI0847B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_SI0847B_FILLER_26(); _.Move(WDATA_SISTEMA, _filler_26); VarBasis.RedefinePassValue(WDATA_SISTEMA, _filler_26, WDATA_SISTEMA); _filler_26.ValueChanged += () => { _.Move(_filler_26, WDATA_SISTEMA); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WDATA_SISTEMA); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_26 : VarBasis
            {
                /*"    10       WDATA-SIST-ANO    PIC  9(004).*/
                public IntBasis WDATA_SIST_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIST-MES    PIC  9(002).*/
                public IntBasis WDATA_SIST_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIST-DIA    PIC  9(002).*/
                public IntBasis WDATA_SIST_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSIST-DATA        PIC  X(010)    VALUE ZEROS.*/

                public _REDEF_SI0847B_FILLER_26()
                {
                    WDATA_SIST_ANO.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                    WDATA_SIST_MES.ValueChanged += OnValueChanged;
                    FILLER_28.ValueChanged += OnValueChanged;
                    WDATA_SIST_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA.*/
            private _REDEF_SI0847B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_SI0847B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_SI0847B_FILLER_29(); _.Move(WSIST_DATA, _filler_29); VarBasis.RedefinePassValue(WSIST_DATA, _filler_29, WSIST_DATA); _filler_29.ValueChanged += () => { _.Move(_filler_29, WSIST_DATA); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_29 : VarBasis
            {
                /*"    10       WSIST-ANOMES.*/
                public SI0847B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new SI0847B_WSIST_ANOMES();
                public class SI0847B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO          PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WSIS-MES          PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public SI0847B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_30.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DIA          PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDTMOVTO          PIC  X(010).*/

                public _REDEF_SI0847B_FILLER_29()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_31.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FILLER            REDEFINES      WDTMOVTO.*/
            private _REDEF_SI0847B_FILLER_32 _filler_32 { get; set; }
            public _REDEF_SI0847B_FILLER_32 FILLER_32
            {
                get { _filler_32 = new _REDEF_SI0847B_FILLER_32(); _.Move(WDTMOVTO, _filler_32); VarBasis.RedefinePassValue(WDTMOVTO, _filler_32, WDTMOVTO); _filler_32.ValueChanged += () => { _.Move(_filler_32, WDTMOVTO); }; return _filler_32; }
                set { VarBasis.RedefinePassValue(value, _filler_32, WDTMOVTO); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_32 : VarBasis
            {
                /*"    10       WDTMOVTO-ANO      PIC  9(004).*/
                public IntBasis WDTMOVTO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDTMOVTO-MES      PIC  9(002).*/
                public IntBasis WDTMOVTO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDTMOVTO-DIA      PIC  9(002).*/
                public IntBasis WDTMOVTO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            LC01.*/

                public _REDEF_SI0847B_FILLER_32()
                {
                    WDTMOVTO_ANO.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                    WDTMOVTO_MES.ValueChanged += OnValueChanged;
                    FILLER_34.ValueChanged += OnValueChanged;
                    WDTMOVTO_DIA.ValueChanged += OnValueChanged;
                }

            }
            public SI0847B_LC01 LC01 { get; set; } = new SI0847B_LC01();
            public class SI0847B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(010) VALUE 'SI0847B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0847B.1");
                /*"    10          FILLER          PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public SI0847B_LC02 LC02 { get; set; } = new SI0847B_LC02();
            public class SI0847B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public SI0847B_LC03 LC03 { get; set; } = new SI0847B_LC03();
            public class SI0847B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(029) VALUE   SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    10          FILLER          PIC  X(051) VALUE    'SINISTROS AVISADOS AUTO COM PERDA TOTAL      EM : '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"SINISTROS AVISADOS AUTO COM PERDA TOTAL      EM : ");
                /*"    10          LC03-MES        PIC  X(009) VALUE   SPACES.*/
                public StringBasis LC03_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10          FILLER          PIC  X(004) VALUE   ' DE '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    10          LC03-ANO        PIC  9(004) VALUE   ZEROS.*/
                public IntBasis LC03_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(020) VALUE   SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE  'HORA'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE   SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public SI0847B_LC04 LC04 { get; set; } = new SI0847B_LC04();
            public class SI0847B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(008) VALUE 'FONTE - '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"FONTE - ");
                /*"    10          LC04-FONTE      PIC  9(003) VALUE  ZEROS.*/
                public IntBasis LC04_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    10          FILLER          PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    10          LC04-NOMEFTE    PIC  X(040).*/
                public StringBasis LC04_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05            LC05.*/
            }
            public SI0847B_LC05 LC05 { get; set; } = new SI0847B_LC05();
            public class SI0847B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(008) VALUE 'CAUSA - '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CAUSA - ");
                /*"    10          LC05-CODCAU     PIC  9(003) VALUE  ZEROS.*/
                public IntBasis LC05_CODCAU { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    10          FILLER          PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    10          LC05-DESCAU     PIC  X(040).*/
                public StringBasis LC05_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05            LC55.*/
            }
            public SI0847B_LC55 LC55 { get; set; } = new SI0847B_LC55();
            public class SI0847B_LC55 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  05            LC06.*/
            }
            public SI0847B_LC06 LC06 { get; set; } = new SI0847B_LC06();
            public class SI0847B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC07.*/
            }
            public SI0847B_LC07 LC07 { get; set; } = new SI0847B_LC07();
            public class SI0847B_LC07 : VarBasis
            {
                /*"    10          FILLER    PIC  X(011) VALUE 'OCORRENCIA '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"OCORRENCIA ");
                /*"    10          FILLER    PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          FILLER    PIC  X(011) VALUE 'N. SINISTRO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"N. SINISTRO");
                /*"    10          FILLER    PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          FILLER    PIC  X(009) VALUE 'VL. AVISO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"VL. AVISO");
                /*"    10          FILLER    PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER    PIC  X(009) VALUE 'DESCRICAO'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DESCRICAO");
                /*"    10          FILLER    PIC  X(025) VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10          FILLER    PIC  X(004) VALUE 'FABR'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"FABR");
                /*"    10          FILLER    PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER    PIC  X(004) VALUE ' MOD'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" MOD");
                /*"    10          FILLER    PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER    PIC  X(002) VALUE 'UF'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
                /*"    10          FILLER    PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER    PIC  X(005) VALUE 'PLACA'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PLACA");
                /*"    10          FILLER    PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          FILLER    PIC  X(007) VALUE 'CHASSIS'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CHASSIS");
                /*"    10          FILLER    PIC  X(019) VALUE SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10          FILLER    PIC  X(005) VALUE 'AVISO'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"AVISO");
                /*"  05            LD01.*/
            }
            public SI0847B_LD01 LD01 { get; set; } = new SI0847B_LD01();
            public class SI0847B_LD01 : VarBasis
            {
                /*"    10          LD01-DIA        PIC  9(002).*/
                public IntBasis LD01_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MES        PIC  9(002).*/
                public IntBasis LD01_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANO        PIC  9(004).*/
                public IntBasis LD01_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-SINISTRO   PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VALOR      PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DESCVEIC   PIC  X(33).*/
                public StringBasis LD01_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "33", "X(33)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-ANOVEICL   PIC  9(04).*/
                public IntBasis LD01_ANOVEICL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-ANOMOD     PIC  9(04).*/
                public IntBasis LD01_ANOMOD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-PLACAUF    PIC  X(02).*/
                public StringBasis LD01_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-PLACALET   PIC  X(03).*/
                public StringBasis LD01_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE  '-'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          LD01-PLACANR    PIC  X(04).*/
                public StringBasis LD01_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-CHASSIS    PIC  X(20).*/
                public StringBasis LD01_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"    10          FILLER          PIC  X(004) VALUE  SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          LD01-DIA-AV     PIC  9(002).*/
                public IntBasis LD01_DIA_AV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-MES-AV     PIC  9(002).*/
                public IntBasis LD01_MES_AV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          LD01-ANO-AV     PIC  9(004).*/
                public IntBasis LD01_ANO_AV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05            LT01.*/
            }
            public SI0847B_LT01 LT01 { get; set; } = new SI0847B_LT01();
            public class SI0847B_LT01 : VarBasis
            {
                /*"    10          LT01-TOT   PIC  X(022).*/
                public StringBasis LT01_TOT { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
                /*"    10          LT01-VALOR PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            TABELA-MESES.*/
            }
            public SI0847B_TABELA_MESES TABELA_MESES { get; set; } = new SI0847B_TABELA_MESES();
            public class SI0847B_TABELA_MESES : VarBasis
            {
                /*"    10          FILLER          PIC X(010)  VALUE '0  JANEIRO'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  JANEIRO");
                /*"    10          FILLER          PIC X(010)  VALUE '0FEVEREIRO'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0FEVEREIRO");
                /*"    10          FILLER          PIC X(010)  VALUE '0    MARCO'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    MARCO");
                /*"    10          FILLER          PIC X(010)  VALUE '0    ABRIL'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    ABRIL");
                /*"    10          FILLER          PIC X(010)  VALUE '0     MAIO'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0     MAIO");
                /*"    10          FILLER          PIC X(010)  VALUE '0    JUNHO'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    JUNHO");
                /*"    10          FILLER          PIC X(010)  VALUE '0    JULHO'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0    JULHO");
                /*"    10          FILLER          PIC X(010)  VALUE '0   AGOSTO'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0   AGOSTO");
                /*"    10          FILLER          PIC X(010)  VALUE '0 SETEMBRO'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 SETEMBRO");
                /*"    10          FILLER          PIC X(010)  VALUE '0  OUTUBRO'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  OUTUBRO");
                /*"    10          FILLER          PIC X(010)  VALUE '0 NOVEMBRO'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 NOVEMBRO");
                /*"    10          FILLER          PIC X(010)  VALUE '0 DEZEMBRO'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 DEZEMBRO");
                /*"  05            FILLER          REDEFINES   TABELA-MESES                                OCCURS      12.*/
            }
            private ListBasis<_REDEF_SI0847B_FILLER_96> _filler_96 { get; set; }
            public ListBasis<_REDEF_SI0847B_FILLER_96> FILLER_96
            {
                get { _filler_96 = new ListBasis<_REDEF_SI0847B_FILLER_96>(12); _.Move(TABELA_MESES, _filler_96); VarBasis.RedefinePassValue(TABELA_MESES, _filler_96, TABELA_MESES); _filler_96.ValueChanged += () => { _.Move(_filler_96, TABELA_MESES); }; return _filler_96; }
                set { VarBasis.RedefinePassValue(value, _filler_96, TABELA_MESES); }
            }  //Redefines
            public class _REDEF_SI0847B_FILLER_96 : VarBasis
            {
                /*"    10          TAB-FLGMES      PIC  X(001).*/
                public StringBasis TAB_FLGMES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          TAB-MES         PIC  X(009).*/
                public StringBasis TAB_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"  05            AC-VALLID-GER   PIC S9(013)V99 VALUE +0 COMP-3.*/

                public _REDEF_SI0847B_FILLER_96()
                {
                    TAB_FLGMES.ValueChanged += OnValueChanged;
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis AC_VALLID_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALCOS-GER   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALCOS_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALRES-GER   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALRES_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALTOT-GER   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALTOT_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALLID-TOT   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALLID_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALCOS-TOT   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALCOS_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALRES-TOT   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALRES_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALTOT-TOT   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALTOT_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALLID-RAM   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALLID_RAM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALCOS-RAM   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALCOS_RAM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALRES-RAM   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALRES_RAM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALTOT-FON   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALTOT_FON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALLID-PEN   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALLID_PEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALCOS-PEN   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALCOS_PEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALRES-PEN   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALRES_PEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05            AC-VALTOT-PEN   PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AC_VALTOT_PEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05        WABEND.*/
            public SI0847B_WABEND WABEND { get; set; } = new SI0847B_WABEND();
            public class SI0847B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' SI0847B'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0847B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(015) VALUE           ' *** PARAGRAFO '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" *** PARAGRAFO ");
                /*"    10      PARAGRAFO           PIC  X(040) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0847B_LK_LINK LK_LINK { get; set; } = new SI0847B_LK_LINK();
        public class SI0847B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0847B_SINISTRO SINISTRO { get; set; } = new SI0847B_SINISTRO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0847B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0847B.SetFile(RSI0847B_FILE_NAME_P);

                /*" -714- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -715- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -718- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -721- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -721- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -730- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -731- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -732- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -734- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -739- DISPLAY 'SI0847B - INICIO DE EXECUCAO ' WDATA-CABEC ' ' WHORA-CABEC */

            $"SI0847B - INICIO DE EXECUCAO {AREA_DE_WORK.WDATA_CABEC} {AREA_DE_WORK.WHORA_CABEC}"
            .Display();

            /*" -740- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -741- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -742- MOVE '*' TO WCH-FINAL */
                _.Move("*", AREA_DE_WORK.WCH_FINAL);

                /*" -744- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -745- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -746- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -747- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -751- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -752- PERFORM R0150-00-SELECT-V1RELATORIOS */

            R0150_00_SELECT_V1RELATORIOS_SECTION();

            /*" -753- IF WFIM-V1RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty())
            {

                /*" -754- MOVE SPACE TO WCH-FINAL */
                _.Move("", AREA_DE_WORK.WCH_FINAL);

                /*" -756- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -758- PERFORM R0400-00-MONTA-CABECALHO */

            R0400_00_MONTA_CABECALHO_SECTION();

            /*" -762- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -763- PERFORM R0900-00-DECLARE-SINISTRO */

            R0900_00_DECLARE_SINISTRO_SECTION();

            /*" -764- PERFORM R0910-00-FETCH-SINISTRO */

            R0910_00_FETCH_SINISTRO_SECTION();

            /*" -765- IF WFIM-PROCESSO EQUAL HIGH-VALUES */

            if (AREA_DE_WORK.WFIM_PROCESSO.IsHighValues)
            {

                /*" -767- GO TO R0000-50-SEM-MOVIMENTO. */

                R0000_50_SEM_MOVIMENTO(); //GOTO
                return;
            }


            /*" -772- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-SINISTRO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_SINISTRO.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -773- MOVE AC-VALTOT-GER TO LT01-VALOR */
            _.Move(AREA_DE_WORK.AC_VALTOT_GER, AREA_DE_WORK.LT01.LT01_VALOR);

            /*" -775- MOVE 'TOTAL GERAL: ' TO LT01-TOT */
            _.Move("TOTAL GERAL: ", AREA_DE_WORK.LT01.LT01_TOT);

            /*" -776- ADD +2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + +2;

            /*" -777- IF AC-LINHAS GREATER +52 */

            if (AREA_DE_WORK.AC_LINHAS > +52)
            {

                /*" -779- PERFORM R4000-00-CABECALHOS. */

                R4000_00_CABECALHOS_SECTION();
            }


            /*" -779- WRITE REG-SI0847B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R0000_50_SEM_MOVIMENTO */

            R0000_50_SEM_MOVIMENTO();

        }

        [StopWatch]
        /*" R0000-50-SEM-MOVIMENTO */
        private void R0000_50_SEM_MOVIMENTO(bool isPerform = false)
        {
            /*" -786- PERFORM R0800-00-DELETE-V0RELATORIOS */

            R0800_00_DELETE_V0RELATORIOS_SECTION();

            /*" -786- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -790- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -795- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -796- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -797- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -798- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -800- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -801- DISPLAY ' ' */
            _.Display($" ");

            /*" -802- DISPLAY ' LINHAS IMPRESSAS: ' AC-LINIMP. */
            _.Display($" LINHAS IMPRESSAS: {AREA_DE_WORK.AC_LINIMP}");

            /*" -804- DISPLAY ' ' */
            _.Display($" ");

            /*" -805- IF WCH-FINAL EQUAL SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -806- DISPLAY ' ' */
                _.Display($" ");

                /*" -808- DISPLAY 'SI0847B - FIM NORMAL ' WDATA-CABEC ' ' WHORA-CABEC */

                $"SI0847B - FIM NORMAL {AREA_DE_WORK.WDATA_CABEC} {AREA_DE_WORK.WHORA_CABEC}"
                .Display();

                /*" -809- ELSE */
            }
            else
            {


                /*" -810- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -813- DISPLAY 'SI0847B - ENCERRADO COM PROBLEMAS ' WDATA-CABEC ' ' WHORA-CABEC. */

                $"SI0847B - ENCERRADO COM PROBLEMAS {AREA_DE_WORK.WDATA_CABEC} {AREA_DE_WORK.WHORA_CABEC}"
                .Display();
            }


            /*" -813- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -826- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -831- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -834- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -835- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -836- DISPLAY 'SISTEMA DE SINISTROS NAO CADASTRADO' */
                    _.Display($"SISTEMA DE SINISTROS NAO CADASTRADO");

                    /*" -837- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -838- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -839- ELSE */
                }
                else
                {


                    /*" -840- DISPLAY 'PROBLEMAS ACESSO V1SISTEMA' */
                    _.Display($"PROBLEMAS ACESSO V1SISTEMA");

                    /*" -844- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -846- DISPLAY 'DATA DO MOVIMENTO ' V1SIST-DTMOVABE */
            _.Display($"DATA DO MOVIMENTO {V1SIST_DTMOVABE}");

            /*" -846- ADD 1 TO AC-S-V1SISTEMA. */
            AREA_DE_WORK.AC_S_V1SISTEMA.Value = AREA_DE_WORK.AC_S_V1SISTEMA + 1;

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -831- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-V1RELATORIOS-SECTION */
        private void R0150_00_SELECT_V1RELATORIOS_SECTION()
        {
            /*" -857- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -867- PERFORM R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1 */

            R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1();

            /*" -870- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -871- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -872- DISPLAY 'NAO HOUVE SOLICITACAO PARA EXECUCAO' */
                    _.Display($"NAO HOUVE SOLICITACAO PARA EXECUCAO");

                    /*" -873- MOVE 'S' TO WFIM-V1RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RELATORIOS);

                    /*" -874- GO TO R0150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/ //GOTO
                    return;

                    /*" -875- ELSE */
                }
                else
                {


                    /*" -876- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -878- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -880- ADD 1 TO AC-S-V1RELATOR */
            AREA_DE_WORK.AC_S_V1RELATOR.Value = AREA_DE_WORK.AC_S_V1RELATOR + 1;

            /*" -881- DISPLAY '  ' */
            _.Display($"  ");

            /*" -882- DISPLAY 'MES SOLICITADO: ' V1RELA-MES-REFER */
            _.Display($"MES SOLICITADO: {V1RELA_MES_REFER}");

            /*" -883- DISPLAY 'ANO SOLICITADO: ' V1RELA-ANO-REFER */
            _.Display($"ANO SOLICITADO: {V1RELA_ANO_REFER}");

            /*" -885- DISPLAY '  ' */
            _.Display($"  ");

            /*" -886- MOVE V1RELA-CODRELAT TO WCODRELAT */
            _.Move(V1RELA_CODRELAT, AREA_DE_WORK.WCODRELAT);

            /*" -887- MOVE WNOME-PROGRAM TO WHOST-CODRELAT. */
            _.Move(AREA_DE_WORK.FILLER_1.WNOME_PROGRAMA.WNOME_PROGRAM, WHOST_CODRELAT);

            /*" -889- MOVE V1SIST-DTMOVABE TO WSIST-DATA WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.WDATA_REL);

            /*" -890- MOVE V1RELA-MES-REFER TO WSIS-MES */
            _.Move(V1RELA_MES_REFER, AREA_DE_WORK.FILLER_29.WSIST_ANOMES.WSIS_MES);

            /*" -891- MOVE V1RELA-ANO-REFER TO WSIS-ANO */
            _.Move(V1RELA_ANO_REFER, AREA_DE_WORK.FILLER_29.WSIST_ANOMES.WSIS_ANO);

            /*" -892- MOVE 01 TO WSIS-DIA */
            _.Move(01, AREA_DE_WORK.FILLER_29.WSIS_DIA);

            /*" -893- MOVE WSIST-DATA TO WHOST-DTINIVIG. */
            _.Move(AREA_DE_WORK.WSIST_DATA, WHOST_DTINIVIG);

            /*" -894- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_18.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -895- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_18.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -897- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_18.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -898- IF WSIS-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.FILLER_29.WSIST_ANOMES.WSIS_MES.In("04", "06", "09", "11"))
            {

                /*" -899- MOVE 30 TO WSIS-DIA */
                _.Move(30, AREA_DE_WORK.FILLER_29.WSIS_DIA);

                /*" -900- ELSE */
            }
            else
            {


                /*" -901- IF WSIS-MES EQUAL 02 */

                if (AREA_DE_WORK.FILLER_29.WSIST_ANOMES.WSIS_MES == 02)
                {

                    /*" -903- COMPUTE WRESTO = WSIS-ANO - (WSIS-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.FILLER_29.WSIST_ANOMES.WSIS_ANO - (AREA_DE_WORK.FILLER_29.WSIST_ANOMES.WSIS_ANO / 4 * 4);

                    /*" -904- IF WRESTO EQUAL ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -905- MOVE 29 TO WSIS-DIA */
                        _.Move(29, AREA_DE_WORK.FILLER_29.WSIS_DIA);

                        /*" -906- ELSE */
                    }
                    else
                    {


                        /*" -907- MOVE 28 TO WSIS-DIA */
                        _.Move(28, AREA_DE_WORK.FILLER_29.WSIS_DIA);

                        /*" -908- ELSE */
                    }

                }
                else
                {


                    /*" -910- MOVE 31 TO WSIS-DIA. */
                    _.Move(31, AREA_DE_WORK.FILLER_29.WSIS_DIA);
                }

            }


            /*" -917- MOVE WSIST-DATA TO WDATA-SISTEMA WHOST-DTTERVIG V1SIST-DTMOVABE. */
            _.Move(AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.WDATA_SISTEMA, WHOST_DTTERVIG, V1SIST_DTMOVABE);

            /*" -918- DISPLAY ' ' */
            _.Display($" ");

            /*" -919- DISPLAY ' DATA INICIAL DE SELECAO: ' WHOST-DTINIVIG. */
            _.Display($" DATA INICIAL DE SELECAO: {WHOST_DTINIVIG}");

            /*" -919- DISPLAY ' DATA FINAL   DE SELECAO: ' WHOST-DTTERVIG. */
            _.Display($" DATA FINAL   DE SELECAO: {WHOST_DTTERVIG}");

        }

        [StopWatch]
        /*" R0150-00-SELECT-V1RELATORIOS-DB-SELECT-1 */
        public void R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1()
        {
            /*" -867- EXEC SQL SELECT CODRELAT ,MES_REFERENCIA ,ANO_REFERENCIA INTO :V1RELA-CODRELAT ,:V1RELA-MES-REFER ,:V1RELA-ANO-REFER FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0847B1' AND SITUACAO = '0' END-EXEC. */

            var r0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1 = new R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RELA_CODRELAT, V1RELA_CODRELAT);
                _.Move(executed_1.V1RELA_MES_REFER, V1RELA_MES_REFER);
                _.Move(executed_1.V1RELA_ANO_REFER, V1RELA_ANO_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-MONTA-CABECALHO-SECTION */
        private void R0400_00_MONTA_CABECALHO_SECTION()
        {
            /*" -933- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -934- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -935- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -936- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -937- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -939- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -940- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -941- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -942- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -943- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -945- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -946- MOVE TAB-MES(V1RELA-MES-REFER) TO LC03-MES */
            _.Move(AREA_DE_WORK.FILLER_96[V1RELA_MES_REFER].TAB_MES, AREA_DE_WORK.LC03.LC03_MES);

            /*" -948- MOVE V1RELA-ANO-REFER TO LC03-ANO */
            _.Move(V1RELA_ANO_REFER, AREA_DE_WORK.LC03.LC03_ANO);

            /*" -952- PERFORM R0400_00_MONTA_CABECALHO_DB_SELECT_1 */

            R0400_00_MONTA_CABECALHO_DB_SELECT_1();

            /*" -955- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -956- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -957- DISPLAY 'EMPRESA NAO CADASTRADA' */
                    _.Display($"EMPRESA NAO CADASTRADA");

                    /*" -958- MOVE 'S' TO WFIM-FECHAMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_FECHAMENTO);

                    /*" -959- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -960- ELSE */
                }
                else
                {


                    /*" -961- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -963- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -965- ADD 1 TO AC-S-V1EMPRESA */
            AREA_DE_WORK.AC_S_V1EMPRESA.Value = AREA_DE_WORK.AC_S_V1EMPRESA + 1;

            /*" -966- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -968- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -969- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -970- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -971- ELSE */
            }
            else
            {


                /*" -972- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -972- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0400-00-MONTA-CABECALHO-DB-SELECT-1 */
        public void R0400_00_MONTA_CABECALHO_DB_SELECT_1()
        {
            /*" -952- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1 = new R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1.Execute(r0400_00_MONTA_CABECALHO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-DELETE-V0RELATORIOS-SECTION */
        private void R0800_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -983- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -987- PERFORM R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -990- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -991- DISPLAY 'PROBLEMAS DELETE V0RELATORIOS ... ' */
                _.Display($"PROBLEMAS DELETE V0RELATORIOS ... ");

                /*" -993- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -993- ADD 1 TO AC-D-V1RELATOR. */
            AREA_DE_WORK.AC_D_V1RELATOR.Value = AREA_DE_WORK.AC_D_V1RELATOR + 1;

        }

        [StopWatch]
        /*" R0800-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -987- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = :V1RELA-CODRELAT AND SITUACAO = '0' END-EXEC. */

            var r0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
            };

            R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-SINISTRO-SECTION */
        private void R0900_00_DECLARE_SINISTRO_SECTION()
        {
            /*" -1006- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1034- PERFORM R0900_00_DECLARE_SINISTRO_DB_DECLARE_1 */

            R0900_00_DECLARE_SINISTRO_DB_DECLARE_1();

            /*" -1036- PERFORM R0900_00_DECLARE_SINISTRO_DB_OPEN_1 */

            R0900_00_DECLARE_SINISTRO_DB_OPEN_1();

            /*" -1039- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1040- DISPLAY 'PROBLEMAS DECLARE SINISTRO ... ' */
                _.Display($"PROBLEMAS DECLARE SINISTRO ... ");

                /*" -1040- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-SINISTRO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_SINISTRO_DB_DECLARE_1()
        {
            /*" -1034- EXEC SQL DECLARE SINISTRO CURSOR FOR SELECT A.NUM_APOLICE, A.NRENDOS, A.DATORR, A.FONTE, A.CODCAU, A.RAMO, B.NUM_APOL_SINISTRO, B.VAL_OPERACAO, B.DTMOVTO, C.NUM_ITEM FROM SEGUROS.V0MESTSINI A, SEGUROS.V0HISTSINI B, SEGUROS.V0SINISTRO_AUTO1 C WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO AND A.TIPREG = '1' AND A.RAMO = 31 AND A.SITUACAO <> '2' AND B.SITUACAO <> '2' AND C.SITUACAO <> '2' AND B.TIPREG = '1' AND B.OPERACAO = 101 AND A.CODCAU IN(10,11,12,13,14,15,16,17,18,20) AND B.DTMOVTO BETWEEN :WHOST-DTINIVIG AND :WHOST-DTTERVIG ORDER BY A.FONTE,A.CODCAU,A.DATORR END-EXEC. */
            SINISTRO = new SI0847B_SINISTRO(true);
            string GetQuery_SINISTRO()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.DATORR
							, 
							A.FONTE
							, 
							A.CODCAU
							, 
							A.RAMO
							, 
							B.NUM_APOL_SINISTRO
							, 
							B.VAL_OPERACAO
							, 
							B.DTMOVTO
							, 
							C.NUM_ITEM 
							FROM SEGUROS.V0MESTSINI A
							, 
							SEGUROS.V0HISTSINI B
							, 
							SEGUROS.V0SINISTRO_AUTO1 C 
							WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO 
							AND A.TIPREG = '1' 
							AND A.RAMO = 31 
							AND A.SITUACAO <> '2' 
							AND B.SITUACAO <> '2' 
							AND C.SITUACAO <> '2' 
							AND B.TIPREG = '1' 
							AND B.OPERACAO = 101 
							AND A.CODCAU IN(10
							,11
							,12
							,13
							,14
							,15
							,16
							,17
							,18
							,20) 
							AND B.DTMOVTO BETWEEN '{WHOST_DTINIVIG}' 
							AND '{WHOST_DTTERVIG}' 
							ORDER BY A.FONTE
							,A.CODCAU
							,A.DATORR";

                return query;
            }
            SINISTRO.GetQueryEvent += GetQuery_SINISTRO;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-SINISTRO-DB-OPEN-1 */
        public void R0900_00_DECLARE_SINISTRO_DB_OPEN_1()
        {
            /*" -1036- EXEC SQL OPEN SINISTRO END-EXEC. */

            SINISTRO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-SINISTRO-SECTION */
        private void R0910_00_FETCH_SINISTRO_SECTION()
        {
            /*" -1053- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1065- PERFORM R0910_00_FETCH_SINISTRO_DB_FETCH_1 */

            R0910_00_FETCH_SINISTRO_DB_FETCH_1();

            /*" -1068- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1069- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1070- MOVE 'S' TO WFIM-SINISTRO */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISTRO);

                    /*" -1071- MOVE HIGH-VALUES TO WFIM-PROCESSO */

                    AREA_DE_WORK.WFIM_PROCESSO.IsHighValues = true;

                    /*" -1072- MOVE 9999 TO CH-FONTE-ATU */
                    _.Move(9999, AREA_DE_WORK.CH_FONTE_ATU);

                    /*" -1072- PERFORM R0910_00_FETCH_SINISTRO_DB_CLOSE_1 */

                    R0910_00_FETCH_SINISTRO_DB_CLOSE_1();

                    /*" -1074- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1075- ELSE */
                }
                else
                {


                    /*" -1076- DISPLAY 'PROBLEMAS FETCH SINISTRO ... ' */
                    _.Display($"PROBLEMAS FETCH SINISTRO ... ");

                    /*" -1078- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1079- MOVE V1MSIN-FONTE TO CH-FONTE-ATU */
            _.Move(V1MSIN_FONTE, AREA_DE_WORK.CH_FONTE_ATU);

            /*" -1081- MOVE V1MSIN-CODCAU TO CH-CAUSA-ATU */
            _.Move(V1MSIN_CODCAU, AREA_DE_WORK.CH_CAUSA_ATU);

            /*" -1081- ADD 1 TO AC-S-SINISTRO. */
            AREA_DE_WORK.AC_S_SINISTRO.Value = AREA_DE_WORK.AC_S_SINISTRO + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-SINISTRO-DB-FETCH-1 */
        public void R0910_00_FETCH_SINISTRO_DB_FETCH_1()
        {
            /*" -1065- EXEC SQL FETCH SINISTRO INTO :V1MSIN-NUM-APOL, :V1MSIN-NRENDOS, :V1MSIN-DATORR, :V1MSIN-FONTE, :V1MSIN-CODCAU, :V1MSIN-RAMO, :V1HSIN-NUM-SINI, :V1HSIN-VAL-OPERACAO, :V1HSIN-DTMOVTO, :V1SAUT-NRITEM END-EXEC. */

            if (SINISTRO.Fetch())
            {
                _.Move(SINISTRO.V1MSIN_NUM_APOL, V1MSIN_NUM_APOL);
                _.Move(SINISTRO.V1MSIN_NRENDOS, V1MSIN_NRENDOS);
                _.Move(SINISTRO.V1MSIN_DATORR, V1MSIN_DATORR);
                _.Move(SINISTRO.V1MSIN_FONTE, V1MSIN_FONTE);
                _.Move(SINISTRO.V1MSIN_CODCAU, V1MSIN_CODCAU);
                _.Move(SINISTRO.V1MSIN_RAMO, V1MSIN_RAMO);
                _.Move(SINISTRO.V1HSIN_NUM_SINI, V1HSIN_NUM_SINI);
                _.Move(SINISTRO.V1HSIN_VAL_OPERACAO, V1HSIN_VAL_OPERACAO);
                _.Move(SINISTRO.V1HSIN_DTMOVTO, V1HSIN_DTMOVTO);
                _.Move(SINISTRO.V1SAUT_NRITEM, V1SAUT_NRITEM);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-SINISTRO-DB-CLOSE-1 */
        public void R0910_00_FETCH_SINISTRO_DB_CLOSE_1()
        {
            /*" -1072- EXEC SQL CLOSE SINISTRO END-EXEC */

            SINISTRO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1093- MOVE CH-FONTE-ATU TO CH-FONTE-ANT */
            _.Move(AREA_DE_WORK.CH_FONTE_ATU, AREA_DE_WORK.CH_FONTE_ANT);

            /*" -1094- MOVE 9999 TO CH-CAUSA-ATU */
            _.Move(9999, AREA_DE_WORK.CH_CAUSA_ATU);

            /*" -1096- PERFORM R4000-00-CABECALHOS. */

            R4000_00_CABECALHOS_SECTION();

            /*" -1102- PERFORM R1200-00-PROCESSA-FONTE UNTIL CH-FONTE-ATU NOT EQUAL CH-FONTE-ANT OR WFIM-SINISTRO NOT EQUAL SPACES. */

            while (!(AREA_DE_WORK.CH_FONTE_ATU != AREA_DE_WORK.CH_FONTE_ANT || !AREA_DE_WORK.WFIM_SINISTRO.IsEmpty()))
            {

                R1200_00_PROCESSA_FONTE_SECTION();
            }

            /*" -1103- MOVE AC-VALTOT-FON TO LT01-VALOR */
            _.Move(AREA_DE_WORK.AC_VALTOT_FON, AREA_DE_WORK.LT01.LT01_VALOR);

            /*" -1105- MOVE 'TOTAL FONTE:  ' TO LT01-TOT */
            _.Move("TOTAL FONTE:  ", AREA_DE_WORK.LT01.LT01_TOT);

            /*" -1106- ADD +2 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + +2;

            /*" -1107- IF AC-LINHAS GREATER +52 */

            if (AREA_DE_WORK.AC_LINHAS > +52)
            {

                /*" -1109- PERFORM R4000-00-CABECALHOS. */

                R4000_00_CABECALHOS_SECTION();
            }


            /*" -1113- WRITE REG-SI0847B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1114- ADD AC-VALTOT-FON TO AC-VALTOT-GER. */
            AREA_DE_WORK.AC_VALTOT_GER.Value = AREA_DE_WORK.AC_VALTOT_GER + AREA_DE_WORK.AC_VALTOT_FON;

            /*" -1114- MOVE ZEROS TO AC-VALTOT-FON. */
            _.Move(0, AREA_DE_WORK.AC_VALTOT_FON);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-FONTE-SECTION */
        private void R1200_00_PROCESSA_FONTE_SECTION()
        {
            /*" -1126- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1127- IF CH-CAUSA-ATU NOT EQUAL CH-CAUSA-ANT */

            if (AREA_DE_WORK.CH_CAUSA_ATU != AREA_DE_WORK.CH_CAUSA_ANT)
            {

                /*" -1128- PERFORM R1300-00-IMPRIME-DESCAU */

                R1300_00_IMPRIME_DESCAU_SECTION();

                /*" -1131- MOVE V1MSIN-CODCAU TO CH-CAUSA-ATU CH-CAUSA-ANT. */
                _.Move(V1MSIN_CODCAU, AREA_DE_WORK.CH_CAUSA_ATU, AREA_DE_WORK.CH_CAUSA_ANT);
            }


            /*" -1133- PERFORM R2310-00-SELECT-V1SINIAUTO. */

            R2310_00_SELECT_V1SINIAUTO_SECTION();

            /*" -1135- PERFORM R2320-00-SELECT-V1AUTOAPOL. */

            R2320_00_SELECT_V1AUTOAPOL_SECTION();

            /*" -1137- PERFORM R2330-00-SELECT-V1DESCRVEI. */

            R2330_00_SELECT_V1DESCRVEI_SECTION();

            /*" -1138- MOVE V1MSIN-DATORR TO WDTMOVTO. */
            _.Move(V1MSIN_DATORR, AREA_DE_WORK.WDTMOVTO);

            /*" -1139- MOVE WDTMOVTO-DIA TO LD01-DIA. */
            _.Move(AREA_DE_WORK.FILLER_32.WDTMOVTO_DIA, AREA_DE_WORK.LD01.LD01_DIA);

            /*" -1140- MOVE WDTMOVTO-MES TO LD01-MES. */
            _.Move(AREA_DE_WORK.FILLER_32.WDTMOVTO_MES, AREA_DE_WORK.LD01.LD01_MES);

            /*" -1141- MOVE WDTMOVTO-ANO TO LD01-ANO. */
            _.Move(AREA_DE_WORK.FILLER_32.WDTMOVTO_ANO, AREA_DE_WORK.LD01.LD01_ANO);

            /*" -1142- MOVE V1HSIN-NUM-SINI TO LD01-SINISTRO */
            _.Move(V1HSIN_NUM_SINI, AREA_DE_WORK.LD01.LD01_SINISTRO);

            /*" -1143- MOVE V1HSIN-VAL-OPERACAO TO LD01-VALOR. */
            _.Move(V1HSIN_VAL_OPERACAO, AREA_DE_WORK.LD01.LD01_VALOR);

            /*" -1144- MOVE V1DVEI-DESCVEIC TO LD01-DESCVEIC. */
            _.Move(V1DVEI_DESCVEIC, AREA_DE_WORK.LD01.LD01_DESCVEIC);

            /*" -1145- MOVE V1AUAP-ANOVEICL TO LD01-ANOVEICL. */
            _.Move(V1AUAP_ANOVEICL, AREA_DE_WORK.LD01.LD01_ANOVEICL);

            /*" -1146- MOVE V1AUAP-ANOMOD TO LD01-ANOMOD. */
            _.Move(V1AUAP_ANOMOD, AREA_DE_WORK.LD01.LD01_ANOMOD);

            /*" -1147- MOVE V1AUAP-PLACAUF TO LD01-PLACAUF. */
            _.Move(V1AUAP_PLACAUF, AREA_DE_WORK.LD01.LD01_PLACAUF);

            /*" -1148- MOVE V1AUAP-PLACALET TO LD01-PLACALET. */
            _.Move(V1AUAP_PLACALET, AREA_DE_WORK.LD01.LD01_PLACALET);

            /*" -1149- MOVE V1AUAP-PLACANR TO LD01-PLACANR. */
            _.Move(V1AUAP_PLACANR, AREA_DE_WORK.LD01.LD01_PLACANR);

            /*" -1150- MOVE V1AUAP-CHASSIS TO LD01-CHASSIS. */
            _.Move(V1AUAP_CHASSIS, AREA_DE_WORK.LD01.LD01_CHASSIS);

            /*" -1151- MOVE V1HSIN-DTMOVTO TO WDTMOVTO. */
            _.Move(V1HSIN_DTMOVTO, AREA_DE_WORK.WDTMOVTO);

            /*" -1152- MOVE WDTMOVTO-DIA TO LD01-DIA-AV. */
            _.Move(AREA_DE_WORK.FILLER_32.WDTMOVTO_DIA, AREA_DE_WORK.LD01.LD01_DIA_AV);

            /*" -1153- MOVE WDTMOVTO-MES TO LD01-MES-AV. */
            _.Move(AREA_DE_WORK.FILLER_32.WDTMOVTO_MES, AREA_DE_WORK.LD01.LD01_MES_AV);

            /*" -1155- MOVE WDTMOVTO-ANO TO LD01-ANO-AV. */
            _.Move(AREA_DE_WORK.FILLER_32.WDTMOVTO_ANO, AREA_DE_WORK.LD01.LD01_ANO_AV);

            /*" -1156- ADD +1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + +1;

            /*" -1157- IF AC-LINHAS GREATER +52 */

            if (AREA_DE_WORK.AC_LINHAS > +52)
            {

                /*" -1159- PERFORM R4000-00-CABECALHOS. */

                R4000_00_CABECALHOS_SECTION();
            }


            /*" -1161- WRITE REG-SI0847B FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1162- ADD V1HSIN-VAL-OPERACAO TO AC-VALTOT-FON. */
            AREA_DE_WORK.AC_VALTOT_FON.Value = AREA_DE_WORK.AC_VALTOT_FON + V1HSIN_VAL_OPERACAO;

            /*" -1164- ADD 1 TO AC-LINIMP */
            AREA_DE_WORK.AC_LINIMP.Value = AREA_DE_WORK.AC_LINIMP + 1;

            /*" -1164- PERFORM R0910-00-FETCH-SINISTRO. */

            R0910_00_FETCH_SINISTRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-IMPRIME-DESCAU-SECTION */
        private void R1300_00_IMPRIME_DESCAU_SECTION()
        {
            /*" -1174- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1175- PERFORM R2300-00-SELECT-V1SINICAUSA */

            R2300_00_SELECT_V1SINICAUSA_SECTION();

            /*" -1176- MOVE V1MSIN-CODCAU TO LC05-CODCAU */
            _.Move(V1MSIN_CODCAU, AREA_DE_WORK.LC05.LC05_CODCAU);

            /*" -1177- MOVE V1SCAU-DESCAU TO LC05-DESCAU */
            _.Move(V1SCAU_DESCAU, AREA_DE_WORK.LC05.LC05_DESCAU);

            /*" -1178- ADD +3 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + +3;

            /*" -1179- IF AC-LINHAS GREATER +52 */

            if (AREA_DE_WORK.AC_LINHAS > +52)
            {

                /*" -1181- PERFORM R4000-00-CABECALHOS. */

                R4000_00_CABECALHOS_SECTION();
            }


            /*" -1182- WRITE REG-SI0847B FROM LC05 AFTER 2. */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1182- WRITE REG-SI0847B FROM LC55 AFTER 1. */
            _.Move(AREA_DE_WORK.LC55.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-V1FONTE-SECTION */
        private void R2200_00_SELECT_V1FONTE_SECTION()
        {
            /*" -1194- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1199- PERFORM R2200_00_SELECT_V1FONTE_DB_SELECT_1 */

            R2200_00_SELECT_V1FONTE_DB_SELECT_1();

            /*" -1202- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1202- MOVE ALL 'X' TO V1FONT-NOMEFTE. */
                _.MoveAll("X", V1FONT_NOMEFTE);
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-V1FONTE-DB-SELECT-1 */
        public void R2200_00_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -1199- EXEC SQL SELECT NOMEFTE INTO :V1FONT-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :V1MSIN-FONTE END-EXEC. */

            var r2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 = new R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1()
            {
                V1MSIN_FONTE = V1MSIN_FONTE.ToString(),
            };

            var executed_1 = R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-V1SINICAUSA-SECTION */
        private void R2300_00_SELECT_V1SINICAUSA_SECTION()
        {
            /*" -1212- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1218- PERFORM R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1 */

            R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1();

            /*" -1221- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1221- MOVE ALL 'X' TO V1SCAU-DESCAU. */
                _.MoveAll("X", V1SCAU_DESCAU);
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-V1SINICAUSA-DB-SELECT-1 */
        public void R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1()
        {
            /*" -1218- EXEC SQL SELECT DESCAU INTO :V1SCAU-DESCAU FROM SEGUROS.V1SINICAUSA WHERE CODCAU = :V1MSIN-CODCAU AND RAMO = :V1MSIN-RAMO END-EXEC. */

            var r2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1 = new R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1()
            {
                V1MSIN_CODCAU = V1MSIN_CODCAU.ToString(),
                V1MSIN_RAMO = V1MSIN_RAMO.ToString(),
            };

            var executed_1 = R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SCAU_DESCAU, V1SCAU_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-SELECT-V1SINIAUTO-SECTION */
        private void R2310_00_SELECT_V1SINIAUTO_SECTION()
        {
            /*" -1231- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1237- PERFORM R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1 */

            R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1();

            /*" -1240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1241- DISPLAY 'PROBLEMAS SELECT V1SINISTRO-AUTO1 ... ' */
                _.Display($"PROBLEMAS SELECT V1SINISTRO-AUTO1 ... ");

                /*" -1242- DISPLAY 'NUM_APOLICE         :' V1MSIN-NUM-APOL */
                _.Display($"NUM_APOLICE         :{V1MSIN_NUM_APOL}");

                /*" -1243- DISPLAY 'NUM_APOL_SINISTRO   :' V1HSIN-NUM-SINI */
                _.Display($"NUM_APOL_SINISTRO   :{V1HSIN_NUM_SINI}");

                /*" -1243- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2310-00-SELECT-V1SINIAUTO-DB-SELECT-1 */
        public void R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1()
        {
            /*" -1237- EXEC SQL SELECT NUM_ITEM INTO :V1SAUT-NRITEM FROM SEGUROS.V1SINISTRO_AUTO1 WHERE NUM_APOLICE = :V1MSIN-NUM-APOL AND NUM_APOL_SINISTRO = :V1HSIN-NUM-SINI END-EXEC. */

            var r2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1 = new R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_APOL = V1MSIN_NUM_APOL.ToString(),
                V1HSIN_NUM_SINI = V1HSIN_NUM_SINI.ToString(),
            };

            var executed_1 = R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1.Execute(r2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SAUT_NRITEM, V1SAUT_NRITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-SELECT-V1AUTOAPOL-SECTION */
        private void R2320_00_SELECT_V1AUTOAPOL_SECTION()
        {
            /*" -1253- MOVE '232' TO WNR-EXEC-SQL. */
            _.Move("232", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1275- PERFORM R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1 */

            R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1();

            /*" -1278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1279- DISPLAY 'PROBLEMAS SELECT V1AUTOAPOL ... ' */
                _.Display($"PROBLEMAS SELECT V1AUTOAPOL ... ");

                /*" -1280- DISPLAY ' NRITEM          : ' V1SAUT-NRITEM */
                _.Display($" NRITEM          : {V1SAUT_NRITEM}");

                /*" -1281- DISPLAY 'NUM_APOLICE      : ' V1MSIN-NUM-APOL */
                _.Display($"NUM_APOLICE      : {V1MSIN_NUM_APOL}");

                /*" -1282- DISPLAY 'NRENDOS          : ' V1MSIN-NRENDOS */
                _.Display($"NRENDOS          : {V1MSIN_NRENDOS}");

                /*" -1282- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2320-00-SELECT-V1AUTOAPOL-DB-SELECT-1 */
        public void R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1()
        {
            /*" -1275- EXEC SQL SELECT CDVEICL, ANOVEICL, ANOMOD, PLACAUF, PLACALET, PLACANR, CHASSIS, NRPRRESS INTO :V1DVEI-CDVEICL, :V1AUAP-ANOVEICL, :V1AUAP-ANOMOD, :V1AUAP-PLACAUF, :V1AUAP-PLACALET, :V1AUAP-PLACANR, :V1AUAP-CHASSIS , :V1AUAP-NRPRRESS FROM SEGUROS.V1AUTOAPOL WHERE NRITEM = :V1SAUT-NRITEM AND NUM_APOLICE = :V1MSIN-NUM-APOL AND NRENDOS = :V1MSIN-NRENDOS END-EXEC. */

            var r2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1 = new R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_APOL = V1MSIN_NUM_APOL.ToString(),
                V1MSIN_NRENDOS = V1MSIN_NRENDOS.ToString(),
                V1SAUT_NRITEM = V1SAUT_NRITEM.ToString(),
            };

            var executed_1 = R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1.Execute(r2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1DVEI_CDVEICL, V1DVEI_CDVEICL);
                _.Move(executed_1.V1AUAP_ANOVEICL, V1AUAP_ANOVEICL);
                _.Move(executed_1.V1AUAP_ANOMOD, V1AUAP_ANOMOD);
                _.Move(executed_1.V1AUAP_PLACAUF, V1AUAP_PLACAUF);
                _.Move(executed_1.V1AUAP_PLACALET, V1AUAP_PLACALET);
                _.Move(executed_1.V1AUAP_PLACANR, V1AUAP_PLACANR);
                _.Move(executed_1.V1AUAP_CHASSIS, V1AUAP_CHASSIS);
                _.Move(executed_1.V1AUAP_NRPRRESS, V1AUAP_NRPRRESS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2330-00-SELECT-V1DESCRVEI-SECTION */
        private void R2330_00_SELECT_V1DESCRVEI_SECTION()
        {
            /*" -1292- MOVE '233' TO WNR-EXEC-SQL. */
            _.Move("233", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1293- IF V1AUAP-NRPRRESS LESS 203 */

            if (V1AUAP_NRPRRESS < 203)
            {

                /*" -1294- MOVE ZEROS TO V1DVEI-VERSAO */
                _.Move(0, V1DVEI_VERSAO);

                /*" -1295- ELSE */
            }
            else
            {


                /*" -1297- MOVE V1AUAP-NRPRRESS TO V1DVEI-VERSAO. */
                _.Move(V1AUAP_NRPRRESS, V1DVEI_VERSAO);
            }


            /*" -1303- PERFORM R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1 */

            R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1();

            /*" -1306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1307- DISPLAY 'PROBLEMAS SELECT V1DESCRVEI ... ' */
                _.Display($"PROBLEMAS SELECT V1DESCRVEI ... ");

                /*" -1308- DISPLAY 'VERSAO  = : ' V1DVEI-VERSAO */
                _.Display($"VERSAO  = : {V1DVEI_VERSAO}");

                /*" -1309- DISPLAY 'CDVEICL = : ' V1DVEI-CDVEICL */
                _.Display($"CDVEICL = : {V1DVEI_CDVEICL}");

                /*" -1309- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2330-00-SELECT-V1DESCRVEI-DB-SELECT-1 */
        public void R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1()
        {
            /*" -1303- EXEC SQL SELECT DESCVEIC INTO :V1DVEI-DESCVEIC FROM SEGUROS.V1DESCRVEI WHERE VERSAO = :V1DVEI-VERSAO AND CDVEICL = :V1DVEI-CDVEICL END-EXEC. */

            var r2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1 = new R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1()
            {
                V1DVEI_CDVEICL = V1DVEI_CDVEICL.ToString(),
                V1DVEI_VERSAO = V1DVEI_VERSAO.ToString(),
            };

            var executed_1 = R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1.Execute(r2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1DVEI_DESCVEIC, V1DVEI_DESCVEIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2333_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-CABECALHOS-SECTION */
        private void R4000_00_CABECALHOS_SECTION()
        {
            /*" -1340- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1341- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -1342- MOVE AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1344- MOVE +08 TO AC-LINHAS */
            _.Move(+08, AREA_DE_WORK.AC_LINHAS);

            /*" -1345- MOVE CH-FONTE-ANT TO HOST-FONTE */
            _.Move(AREA_DE_WORK.CH_FONTE_ANT, HOST_FONTE);

            /*" -1346- PERFORM R2200-00-SELECT-V1FONTE */

            R2200_00_SELECT_V1FONTE_SECTION();

            /*" -1347- MOVE CH-FONTE-ANT TO LC04-FONTE */
            _.Move(AREA_DE_WORK.CH_FONTE_ANT, AREA_DE_WORK.LC04.LC04_FONTE);

            /*" -1349- MOVE V1FONT-NOMEFTE TO LC04-NOMEFTE */
            _.Move(V1FONT_NOMEFTE, AREA_DE_WORK.LC04.LC04_NOMEFTE);

            /*" -1350- PERFORM R2300-00-SELECT-V1SINICAUSA */

            R2300_00_SELECT_V1SINICAUSA_SECTION();

            /*" -1351- MOVE V1MSIN-CODCAU TO LC05-CODCAU */
            _.Move(V1MSIN_CODCAU, AREA_DE_WORK.LC05.LC05_CODCAU);

            /*" -1353- MOVE V1SCAU-DESCAU TO LC05-DESCAU */
            _.Move(V1SCAU_DESCAU, AREA_DE_WORK.LC05.LC05_DESCAU);

            /*" -1354- WRITE REG-SI0847B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1355- WRITE REG-SI0847B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1356- WRITE REG-SI0847B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1358- WRITE REG-SI0847B FROM LC04 AFTER 2. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1359- WRITE REG-SI0847B FROM LC06 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1360- WRITE REG-SI0847B FROM LC07 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

            /*" -1360- WRITE REG-SI0847B FROM LC06. */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_SI0847B);

            RSI0847B.Write(REG_SI0847B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -1371- OPEN OUTPUT RSI0847B. */
            RSI0847B.Open(REG_SI0847B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -1382- CLOSE RSI0847B. */
            RSI0847B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1400- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1402- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1404- CLOSE RSI0847B */
            RSI0847B.Close();

            /*" -1404- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1406- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1410- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1410- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}