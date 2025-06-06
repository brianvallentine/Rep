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
using Sias.VidaAzul.DB2.VA0010B;

namespace Code
{
    public class VA0010B
    {
        public bool IsCall { get; set; }

        public VA0010B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  INTEGRA NA ESTRUTURA DO MULTIPRE-  *      */
        /*"      *                             MIADO (V0PROPOSTAVA, V0OPCAOPAGVA, *      */
        /*"      *                             V0COBERPROPVA) OS SEGURADOS MARCA- *      */
        /*"      *                             DOS (NUM_CARNE <> ZEROS) DOS PRO - *      */
        /*"      *                             DUTOS DO VIDAZUL (TRD, MST, PRM,   *      */
        /*"      *                             EXC, SNR, MCE).                    *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  FREDERICO FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0010B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  03/08/98                           *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           16/09/1998  *      */
        /*"      ******************************************************************      */
        /*"      *         A L T E R A C O E S    E F E T U A D A S               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CADMUS 154.956                                   *      */
        /*"      *             - DESCONSIDERAR MODALIDADE NA CONSULTA DE COBERTURA*      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CADMUS 141793-EV-Rede-Resseguro Vida da Gente    *      */
        /*"      *             - SELECIONAR A MODALIDADE DA APOLICE               *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/09/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                               PROCURE POR V.03 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 01  CAD 101217                                                */
        /*"      *                                                                       */
        /*"      *             ALTERACAO RESSEGURO                                       */
        /*"      *                                                                       */
        /*"      *   EM 22/08/2014 - LUIZ GUSTAVO DE OLIVEIRA                            */
        /*"      *                                                                       */
        /*"      *                                      PROCURE POR V.01                 */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  CUSTCAP-VLCUSTCAP                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CUSTCAP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  PLACAP-QTTITCAP                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis PLACAP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-DTVENCTO                    PIC  X(10).*/
        public StringBasis HOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DTPROXVEN                   PIC  X(10).*/
        public StringBasis HOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-OPCAOPAG                    PIC  X(01).*/
        public StringBasis HOST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  HOST-IND                         PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-PERIPGTO                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-OPRCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-NUMCTADEB                   PIC S9(13)  COMP-3 VALUE +0*/
        public IntBasis HOST_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-DIGCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-QTTITCAP                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-VALOPERACAO                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_VALOPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VLTITCAP                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VLCUSCAP                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_VLCUSCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-IMPSEGCDG                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VLCUSTCDG                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-IMPSEGAUXF                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VLCUSTAUXF                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-IMPSEGAUXF-I                PIC S9(04)    COMP.*/
        public IntBasis HOST_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-VLCUSTAUXF-I                PIC S9(04)    COMP.*/
        public IntBasis HOST_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-OCORHIST                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-IDADE                       PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-IMPSEGUR                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-IMPSEGIND                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-DIFERENCA                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-IS-ACID-ANT                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_IS_ACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-IS-ACID-ATU                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_IS_ACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-DIA-DEBITO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-PARC-ATU                    PIC  X(10).*/
        public StringBasis HOST_PARC_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-PARC-PRX                    PIC  X(10).*/
        public StringBasis HOST_PARC_PRX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-SITUACAO                    PIC  X(01).*/
        public StringBasis HOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  HOST-PR-TAR-NEW                  PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis HOST_PR_TAR_NEW { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  WDATA-MOVTO                      PIC X(10).*/
        public StringBasis WDATA_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WDATA-TERVIG                     PIC X(10).*/
        public StringBasis WDATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-VLPREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-PRMVG                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-PRMAP                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0CCOR-OPCAOCAP          PIC S9(004)    COMP.*/
        public IntBasis V0CCOR_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CCOR-OPCAOCAP-I        PIC S9(004)    COMP.*/
        public IntBasis V0CCOR_OPCAOCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CCOR-DIA-DEBITO        PIC S9(004)    COMP.*/
        public IntBasis V0CCOR_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CCOR-DIA-DEBITO-I      PIC S9(004)    COMP.*/
        public IntBasis V0CCOR_DIA_DEBITO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CCOR-COD-AGENCIA       PIC S9(004)    COMP.*/
        public IntBasis V0CCOR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CCOR-NUM-CTA-CORRENTE  PIC S9(017)    COMP-3.*/
        public IntBasis V0CCOR_NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"77            V0CCOR-DAC-CTA-CORRENTE  PIC  X(001).*/
        public StringBasis V0CCOR_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0CCOR-DESC-FAIXA   PIC  X(030).*/
        public StringBasis V0CCOR_DESC_FAIXA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77  V0PROD-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROD-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PROD_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0PROD-TEM-CDG-I                 PIC S9(04)    COMP.*/
        public IntBasis V0PROD_TEM_CDG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V1SEGV_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1SEGV-DVCERTIF                  PIC  X(01).*/
        public StringBasis V1SEGV_DVCERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1SEGV-CODCLI                    PIC S9(09)    COMP.*/
        public IntBasis V1SEGV_CODCLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1SEGV-OCORR-END                 PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-AGECOBR                   PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-DTINIVIG                  PIC  X(10).*/
        public StringBasis V1SEGV_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SEGV-DTNASCIM                  PIC  X(10).*/
        public StringBasis V1SEGV_DTNASCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SEGV-DTNASCIM-I                PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_DTNASCIM_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-DTADMISS                  PIC  X(10).*/
        public StringBasis V1SEGV_DTADMISS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SEGV-DTADMISS-I                PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_DTADMISS_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-IDE-SEXO                  PIC  X(01).*/
        public StringBasis V1SEGV_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1SEGV-EST-CIVIL                 PIC  X(01).*/
        public StringBasis V1SEGV_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1SEGV-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-ITEM                      PIC S9(09)    COMP.*/
        public IntBasis V1SEGV_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1SEGV-NRPROPOS                  PIC S9(09)    COMP.*/
        public IntBasis V1SEGV_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1SEGV-NUM-CARNE                 PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_NUM_CARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SEGV-SITUACAO                  PIC  X(01).*/
        public StringBasis V1SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1SEGV-MATRICULA                 PIC S9(15)    COMP-3.*/
        public IntBasis V1SEGV_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1SEGV-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V1SEGV_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1SEGV-COD-SUBGRUPO              PIC S9(04)    COMP.*/
        public IntBasis V1SEGV_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-APOL-COD-MODALIDADE           PIC S9(04)    USAGE COMP.*/
        public IntBasis WS_APOL_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1CLIE-CGCCPF                    PIC S9(15)    COMP-3.*/
        public IntBasis V1CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1CLIE-DTNASCIM                  PIC  X(10).*/
        public StringBasis V1CLIE_DTNASCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1CLIE-DTNASCIM-I                PIC S9(04)    COMP.*/
        public IntBasis V1CLIE_DTNASCIM_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SIST-DTMOVABE                  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SIST-DTMOVABE-05               PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_05 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SIST-DTMOVABE-75               PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_75 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HSEG-DTMOVTO                   PIC  X(10).*/
        public StringBasis V1HSEG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1HSEG-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V1HSEG_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HSEG-CODMOEDA                  PIC S9(04)    COMP.*/
        public IntBasis V1HSEG_CODMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HSEG-CODMOEDA-I                PIC S9(04)    COMP.*/
        public IntBasis V1HSEG_CODMOEDA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1HSEG-CODOPER-ANT               PIC S9(04)    COMP.*/
        public IntBasis V1HSEG_CODOPER_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MOEDA-VALCPR                     PIC S9(06)V9(09) COMP-3.*/
        public DoubleBasis MOEDA_VALCPR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
        /*"77  V0PLAN-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PLAN_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0PLAN-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PLAN_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-VG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-AP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-IP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_IP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-IPA                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_IPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-AMDS               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-DH                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CIMP-SEGURADA-DIT                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CPRM-TARIFARIO-VG                PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis CPRM_TARIFARIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  CPRM-TARIFARIO-AP                PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis CPRM_TARIFARIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  CFATOR-MULTIPLICA                PIC S9(04)      COMP.*/
        public IntBasis CFATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VLPREMIO                         PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  PRMVG                            PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  PRMAP                            PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V1COBA-IS-MN-ATU                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1COBA_IS_MN_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1COBA-PR-TAR-VG                 PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis V1COBA_PR_TAR_VG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  V1COBA-DTINIVIG-ATU              PIC  X(10).*/
        public StringBasis V1COBA_DTINIVIG_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1COBA-DTTERVIG-ATU              PIC  X(10).*/
        public StringBasis V1COBA_DTTERVIG_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1COBA-PR-TAR-AP                 PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis V1COBA_PR_TAR_AP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  V1COBA-IS-MN-ANT                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1COBA_IS_MN_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1COBA-PR-TAR-TOT                PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis V1COBA_PR_TAR_TOT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  V1COBA-DTINIVIG-ANT              PIC  X(10).*/
        public StringBasis V1COBA_DTINIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1COBA-DTTERVIG-ANT              PIC  X(10).*/
        public StringBasis V1COBA_DTTERVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0COBP-IMPMORNATU-ALL            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPMORNATU_ALL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0PROP-NRPRIPARATZ               PIC S9(04)    COMP.*/
        public IntBasis V0PROP_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-QTDPARATZ                 PIC S9(04)    COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-AGECOBR                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-DTQITBCO                  PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PROPAZ-AGENCIA                 PIC S9(04)    COMP.*/
        public IntBasis V0PROPAZ_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPAZ-DIA-DEBITO              PIC S9(04)    COMP.*/
        public IntBasis V0PROPAZ_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0OPCA-DTINIVIG                  PIC  X(10).*/
        public StringBasis V0OPCA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CDGC-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0CDGC_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PARAMETROS.*/
        public VA0010B_PARAMETROS PARAMETROS { get; set; } = new VA0010B_PARAMETROS();
        public class VA0010B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public VA0010B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VA0010B_LK_NASCIMENTO();
            public class VA0010B_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                PIC S9(03) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01  W-NUM-CTA-CORRENTE          PIC  9(017)   VALUE ZEROS.*/
        }
        public IntBasis W_NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("9", "17", "9(017)"));
        /*"01  FILLER                      REDEFINES    W-NUM-CTA-CORRENTE.*/
        private _REDEF_VA0010B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VA0010B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VA0010B_FILLER_0(); _.Move(W_NUM_CTA_CORRENTE, _filler_0); VarBasis.RedefinePassValue(W_NUM_CTA_CORRENTE, _filler_0, W_NUM_CTA_CORRENTE); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_CTA_CORRENTE); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_CTA_CORRENTE); }
        }  //Redefines
        public class _REDEF_VA0010B_FILLER_0 : VarBasis
        {
            /*"  05    WZEROS                  PIC  9(001).*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05    WOPRCTADEB              PIC  9(004).*/
            public IntBasis WOPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05    WNUMCTADEB              PIC  9(012).*/
            public IntBasis WNUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"01  WDIGCTADEB                  PIC  9(001).*/

            public _REDEF_VA0010B_FILLER_0()
            {
                WZEROS.ValueChanged += OnValueChanged;
                WOPRCTADEB.ValueChanged += OnValueChanged;
                WNUMCTADEB.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WDIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01  FILLER                      REDEFINES    WDIGCTADEB.*/
        private _REDEF_VA0010B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_VA0010B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_VA0010B_FILLER_1(); _.Move(WDIGCTADEB, _filler_1); VarBasis.RedefinePassValue(WDIGCTADEB, _filler_1, WDIGCTADEB); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDIGCTADEB); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, WDIGCTADEB); }
        }  //Redefines
        public class _REDEF_VA0010B_FILLER_1 : VarBasis
        {
            /*"  05    W-DAC-CTA-CORRENTE      PIC  X(001).*/
            public StringBasis W_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01  WS-WORK-AREAS.*/

            public _REDEF_VA0010B_FILLER_1()
            {
                W_DAC_CTA_CORRENTE.ValueChanged += OnValueChanged;
            }

        }
        public VA0010B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0010B_WS_WORK_AREAS();
        public class VA0010B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 WS-VALOR-DIF                  PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_VALOR_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03 WS-DATA-BASE.*/
            public VA0010B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VA0010B_WS_DATA_BASE();
            public class VA0010B_WS_DATA_BASE : VarBasis
            {
                /*"       05 WS-ANO-BASE                PIC  9(004).*/
                public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MES-BASE                PIC  9(002).*/
                public IntBasis WS_MES_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-DIA-BASE                PIC  9(002).*/
                public IntBasis WS_DIA_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WCERTIFICADO                  PIC  9(015)   VALUE ZEROS.*/
            }
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    03 FILLER                        REDEFINES     WCERTIFICADO.*/
            private _REDEF_VA0010B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0010B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0010B_FILLER_4(); _.Move(WCERTIFICADO, _filler_4); VarBasis.RedefinePassValue(WCERTIFICADO, _filler_4, WCERTIFICADO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WCERTIFICADO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WCERTIFICADO); }
            }  //Redefines
            public class _REDEF_VA0010B_FILLER_4 : VarBasis
            {
                /*"       05 WNRCERTIF                  PIC  9(014).*/
                public IntBasis WNRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"       05 WDVCERTIF                  PIC  9(001).*/
                public IntBasis WDVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03 WFIM-SEGURAVG                 PIC X VALUE SPACES.*/

                public _REDEF_VA0010B_FILLER_4()
                {
                    WNRCERTIF.ValueChanged += OnValueChanged;
                    WDVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WTEM-COBERTURA                PIC X VALUE SPACES.*/
            public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 AC-L-SEGURAVG                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_SEGURAVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-COMMIT                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_COMMIT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-HISTSEGVG                PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_HISTSEGVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-COBERAPOL                PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-PARCELASVG               PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_PARCELASVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PROPOSTAVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-COBERPROPVA              PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PARCELVA                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCOBVA                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-OPCAOPAGVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-CDGCOBER                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_CDGCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-W-CONTA                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_W_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ACEITOS                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-TIME                       PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 WDIFERENCA                    PIC S9(13)V99 COMP VALUE +0*/
            public DoubleBasis WDIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 WDATA-INIVIG.*/
            public VA0010B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VA0010B_WDATA_INIVIG();
            public class VA0010B_WDATA_INIVIG : VarBasis
            {
                /*"       05 ANO-INIVIG                 PIC 9(04).*/
                public IntBasis ANO_INIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-INIVIG                 PIC 9(02).*/
                public IntBasis MES_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-INIVIG                 PIC 9(02).*/
                public IntBasis DIA_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-NASC.*/
            }
            public VA0010B_WDATA_NASC WDATA_NASC { get; set; } = new VA0010B_WDATA_NASC();
            public class VA0010B_WDATA_NASC : VarBasis
            {
                /*"       05 ANO-NASC                   PIC 9(04).*/
                public IntBasis ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-NASC                   PIC 9(02).*/
                public IntBasis MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-NASC                   PIC 9(02).*/
                public IntBasis DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WS-DATA-SQL.*/
            }
            public VA0010B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA0010B_WS_DATA_SQL();
            public class VA0010B_WS_DATA_SQL : VarBasis
            {
                /*"       05 WS-ANO-SQL                 PIC 9(04).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-MES-SQL                 PIC 9(02).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-DIA-SQL                 PIC 9(02).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-ATU.*/
            }
            public VA0010B_WDATA_PARC_ATU WDATA_PARC_ATU { get; set; } = new VA0010B_WDATA_PARC_ATU();
            public class VA0010B_WDATA_PARC_ATU : VarBasis
            {
                /*"       05 WDATA-PAR-ANO              PIC 9(04).*/
                public IntBasis WDATA_PAR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-MES              PIC 9(02).*/
                public IntBasis WDATA_PAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-DIA              PIC 9(02).*/
                public IntBasis WDATA_PAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-PRX.*/
            }
            public VA0010B_WDATA_PARC_PRX WDATA_PARC_PRX { get; set; } = new VA0010B_WDATA_PARC_PRX();
            public class VA0010B_WDATA_PARC_PRX : VarBasis
            {
                /*"       05 WDATA-PRX-ANO              PIC 9(04).*/
                public IntBasis WDATA_PRX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-MES              PIC 9(02).*/
                public IntBasis WDATA_PRX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-DIA              PIC 9(02).*/
                public IntBasis WDATA_PRX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"01  WABEND.*/
            }
        }
        public VA0010B_WABEND WABEND { get; set; } = new VA0010B_WABEND();
        public class VA0010B_WABEND : VarBasis
        {
            /*"        10    FILLER                   PIC  X(016) VALUE              '*** VA0010B *** '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VA0010B *** ");
            /*"        10    FILLER                   PIC  X(013) VALUE              'ERRO SQL *** '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"        10    FILLER                   PIC  X(010) VALUE              'SQLCODE = '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"        10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"        10    FILLER                   PIC  X(011)   VALUE              'SQLERRD1 = '.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"        10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"        10    FILLER                   PIC  X(011)   VALUE              'SQLERRD2 = '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"        10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03     LOCALIZA-ABEND-1.*/
            public VA0010B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0010B_LOCALIZA_ABEND_1();
            public class VA0010B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"       05    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"       05    PARAGRAFO                PIC  X(040)   VALUE SPACES*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    03     LOCALIZA-ABEND-2.*/
            }
            public VA0010B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0010B_LOCALIZA_ABEND_2();
            public class VA0010B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"       05    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"       05    COMANDO                  PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA0010B_CSEGURAVG CSEGURAVG { get; set; } = new VA0010B_CSEGURAVG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -425- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -427- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -429- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -432- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -433- DISPLAY 'PROGRAMA EM EXECUCAO VA0010B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO VA0010B   ");

            /*" -434- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -437- DISPLAY 'VERSAO V.04 154.956 20/10/2017 ' . */
            _.Display($"VERSAO V.04 154.956 20/10/2017 ");

            /*" -439- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -441- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -443- PERFORM 0889-SELECT-V1SISTEMA. */

            M_0889_SELECT_V1SISTEMA_SECTION();

            /*" -445- PERFORM 0900-DECLA-SEGURAVG */

            M_0900_DECLA_SEGURAVG_SECTION();

            /*" -447- PERFORM 0910-FETCH-SEGURAVG */

            M_0910_FETCH_SEGURAVG_SECTION();

            /*" -448- IF WFIM-SEGURAVG NOT EQUAL SPACES */

            if (!WS_WORK_AREAS.WFIM_SEGURAVG.IsEmpty())
            {

                /*" -449- DISPLAY '*** SEM MOVIMENTO NA V1SEGURAVG' */
                _.Display($"*** SEM MOVIMENTO NA V1SEGURAVG");

                /*" -451- GO TO 0000-FIM-NORMAL. */

                M_0000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -453- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -455- DISPLAY '** VA0010B ** PROCESSANDO ... ' WS-TIME. */
            _.Display($"** VA0010B ** PROCESSANDO ... {WS_WORK_AREAS.WS_TIME}");

            /*" -456- PERFORM 1000-PROCESSA UNTIL WFIM-SEGURAVG EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_SEGURAVG == "S"))
            {

                M_1000_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_0000_FIM_NORMAL */

            M_0000_FIM_NORMAL();

        }

        [StopWatch]
        /*" M-0000-FIM-NORMAL */
        private void M_0000_FIM_NORMAL(bool isPerform = false)
        {
            /*" -461- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -461- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -464- DISPLAY '** VA0010B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
            _.Display($"** VA0010B ** LIDOS SEGURAVG    {WS_WORK_AREAS.AC_L_SEGURAVG}");

            /*" -465- DISPLAY '** VA0010B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
            _.Display($"** VA0010B ** LIDOS HISTSEGVG   {WS_WORK_AREAS.AC_L_HISTSEGVG}");

            /*" -466- DISPLAY '** VA0010B ** LIDOS COBERAPOL   ' AC-L-COBERAPOL */
            _.Display($"** VA0010B ** LIDOS COBERAPOL   {WS_WORK_AREAS.AC_L_COBERAPOL}");

            /*" -467- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -468- DISPLAY '** VA0010B ** INCL. PROPOSTAVA  ' AC-I-PROPOSTAVA */
            _.Display($"** VA0010B ** INCL. PROPOSTAVA  {WS_WORK_AREAS.AC_I_PROPOSTAVA}");

            /*" -469- DISPLAY '** VA0010B ** INCL. COBERPROPVA ' AC-I-COBERPROPVA */
            _.Display($"** VA0010B ** INCL. COBERPROPVA {WS_WORK_AREAS.AC_I_COBERPROPVA}");

            /*" -470- DISPLAY '** VA0010B ** INCL. OPCAOPAGVA  ' AC-I-OPCAOPAGVA */
            _.Display($"** VA0010B ** INCL. OPCAOPAGVA  {WS_WORK_AREAS.AC_I_OPCAOPAGVA}");

            /*" -471- DISPLAY '** VA0010B ** INCL. CDGCOBER    ' AC-I-CDGCOBER */
            _.Display($"** VA0010B ** INCL. CDGCOBER    {WS_WORK_AREAS.AC_I_CDGCOBER}");

            /*" -472- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -474- DISPLAY '** VA0010B ** TERMINO NORMAL    ' . */
            _.Display($"** VA0010B ** TERMINO NORMAL    ");

            /*" -476- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -476- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-0889-SELECT-V1SISTEMA-SECTION */
        private void M_0889_SELECT_V1SISTEMA_SECTION()
        {
            /*" -485- MOVE '0889-SELECT-V1SISTEMA' TO PARAGRAFO. */
            _.Move("0889-SELECT-V1SISTEMA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -487- MOVE 'SELECT V1SISTEMA     ' TO COMANDO. */
            _.Move("SELECT V1SISTEMA     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -494- PERFORM M_0889_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_0889_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -497- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -498- DISPLAY '0889 - PROBLEMAS SELECT  V1SISTEMA - VA ..' */
                _.Display($"0889 - PROBLEMAS SELECT  V1SISTEMA - VA ..");

                /*" -499- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -501- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -503- MOVE 'SELECT PLANOS_VA_VGAP ' TO COMANDO. */
            _.Move("SELECT PLANOS_VA_VGAP ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -514- PERFORM M_0889_SELECT_V1SISTEMA_DB_SELECT_2 */

            M_0889_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -517- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -518- DISPLAY '0889 - PROBLEMAS SELECT  PLANOS_VA_VGAP ..' */
                _.Display($"0889 - PROBLEMAS SELECT  PLANOS_VA_VGAP ..");

                /*" -519- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -519- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0889-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_0889_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -494- EXEC SQL SELECT DTMOVABE, DTMOVABE + 5 DAYS INTO :V1SIST-DTMOVABE, :V1SIST-DTMOVABE-05 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var m_0889_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new M_0889_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0889_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_0889_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_05, V1SIST_DTMOVABE_05);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0889_FIM*/

        [StopWatch]
        /*" M-0889-SELECT-V1SISTEMA-DB-SELECT-2 */
        public void M_0889_SELECT_V1SISTEMA_DB_SELECT_2()
        {
            /*" -514- EXEC SQL SELECT IMPSEGCDG, VLCUSTCDG INTO :HOST-IMPSEGCDG, :HOST-VLCUSTCDG FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = 97010000889 AND CODSUBES = 3603 AND OPCAO_COBER = 'A' AND IDADE_INICIAL = 16 AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(m_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_IMPSEGCDG, HOST_IMPSEGCDG);
                _.Move(executed_1.HOST_VLCUSTCDG, HOST_VLCUSTCDG);
            }


        }

        [StopWatch]
        /*" M-0900-DECLA-SEGURAVG-SECTION */
        private void M_0900_DECLA_SEGURAVG_SECTION()
        {
            /*" -529- MOVE '0900-DECLA-SEGURAVG' TO PARAGRAFO. */
            _.Move("0900-DECLA-SEGURAVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -531- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -534- DISPLAY '** VA0010B ** INICIO DECLARE CSEGURAVG.. ' WS-TIME. */
            _.Display($"** VA0010B ** INICIO DECLARE CSEGURAVG.. {WS_WORK_AREAS.WS_TIME}");

            /*" -565- PERFORM M_0900_DECLA_SEGURAVG_DB_DECLARE_1 */

            M_0900_DECLA_SEGURAVG_DB_DECLARE_1();

            /*" -567- PERFORM M_0900_DECLA_SEGURAVG_DB_OPEN_1 */

            M_0900_DECLA_SEGURAVG_DB_OPEN_1();

            /*" -570- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -571- DISPLAY '0900 - PROBLEMAS DECLARE V1SEGURAVG ..' */
                _.Display($"0900 - PROBLEMAS DECLARE V1SEGURAVG ..");

                /*" -572- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -574- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -576- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -577- DISPLAY '** VA0010B ** FINAL  DECLARE CSEGURAVG.. ' WS-TIME. */
            _.Display($"** VA0010B ** FINAL  DECLARE CSEGURAVG.. {WS_WORK_AREAS.WS_TIME}");

        }

        [StopWatch]
        /*" M-0900-DECLA-SEGURAVG-DB-DECLARE-1 */
        public void M_0900_DECLA_SEGURAVG_DB_DECLARE_1()
        {
            /*" -565- EXEC SQL DECLARE CSEGURAVG CURSOR WITH HOLD FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, NUM_ITEM, COD_CLIENTE, COD_FONTE, OCORR_HISTORICO, ESTADO_CIVIL, IDE_SEXO, OCORR_ENDERECO, NUM_MATRICULA, DATA_INIVIGENCIA, DATA_ADMISSAO, DATA_NASCIMENTO, SIT_REGISTRO, NUM_PROPOSTA, NUM_CARNE FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = 97010000889 AND COD_SUBGRUPO IN (1 , 1948 , 1949, 1950 , 1951, 2910) AND NUM_MATRICULA >= 0 AND TIPO_SEGURADO = '1' AND SIT_REGISTRO IN ( '0' , '1' ) AND NUM_CARNE > 0 FOR UPDATE OF NUM_CARNE END-EXEC. */
            CSEGURAVG = new VA0010B_CSEGURAVG(false);
            string GetQuery_CSEGURAVG()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							NUM_ITEM
							, 
							COD_CLIENTE
							, 
							COD_FONTE
							, 
							OCORR_HISTORICO
							, 
							ESTADO_CIVIL
							, 
							IDE_SEXO
							, 
							OCORR_ENDERECO
							, 
							NUM_MATRICULA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_ADMISSAO
							, 
							DATA_NASCIMENTO
							, 
							SIT_REGISTRO
							, 
							NUM_PROPOSTA
							, 
							NUM_CARNE 
							FROM SEGUROS.V1SEGURAVG 
							WHERE NUM_APOLICE = 97010000889 
							AND COD_SUBGRUPO IN (1
							, 1948
							, 1949
							, 
							1950
							, 1951
							, 
							2910) 
							AND NUM_MATRICULA >= 0 
							AND TIPO_SEGURADO = '1' 
							AND SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND NUM_CARNE > 0";

                return query;
            }
            CSEGURAVG.GetQueryEvent += GetQuery_CSEGURAVG;

        }

        [StopWatch]
        /*" M-0900-DECLA-SEGURAVG-DB-OPEN-1 */
        public void M_0900_DECLA_SEGURAVG_DB_OPEN_1()
        {
            /*" -567- EXEC SQL OPEN CSEGURAVG END-EXEC. */

            CSEGURAVG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-SEGURAVG-SECTION */
        private void M_0910_FETCH_SEGURAVG_SECTION()
        {
            /*" -587- MOVE '0900-FETCH-SEGURAVG' TO PARAGRAFO. */
            _.Move("0900-FETCH-SEGURAVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -606- PERFORM M_0910_FETCH_SEGURAVG_DB_FETCH_1 */

            M_0910_FETCH_SEGURAVG_DB_FETCH_1();

            /*" -609- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -610- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -611- MOVE 'S' TO WFIM-SEGURAVG */
                    _.Move("S", WS_WORK_AREAS.WFIM_SEGURAVG);

                    /*" -611- PERFORM M_0910_FETCH_SEGURAVG_DB_CLOSE_1 */

                    M_0910_FETCH_SEGURAVG_DB_CLOSE_1();

                    /*" -613- GO TO 0910-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/ //GOTO
                    return;

                    /*" -614- ELSE */
                }
                else
                {


                    /*" -614- PERFORM M_0910_FETCH_SEGURAVG_DB_CLOSE_2 */

                    M_0910_FETCH_SEGURAVG_DB_CLOSE_2();

                    /*" -616- DISPLAY '0900 - (PROBLEMAS NO FETCH V1SEGURAVG ..' */
                    _.Display($"0900 - (PROBLEMAS NO FETCH V1SEGURAVG ..");

                    /*" -617- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -618- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -619- ELSE */
                }

            }
            else
            {


                /*" -621- ADD 1 TO AC-L-SEGURAVG AC-W-CONTA */
                WS_WORK_AREAS.AC_L_SEGURAVG.Value = WS_WORK_AREAS.AC_L_SEGURAVG + 1;
                WS_WORK_AREAS.AC_W_CONTA.Value = WS_WORK_AREAS.AC_W_CONTA + 1;

                /*" -623- ADD 1 TO AC-L-COMMIT. */
                WS_WORK_AREAS.AC_L_COMMIT.Value = WS_WORK_AREAS.AC_L_COMMIT + 1;
            }


            /*" -624- IF AC-W-CONTA > 999 */

            if (WS_WORK_AREAS.AC_W_CONTA > 999)
            {

                /*" -625- MOVE ZEROS TO AC-W-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_W_CONTA);

                /*" -626- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -626- DISPLAY '*** LIDOS V0SEGURAVG ' AC-L-SEGURAVG ' ' WS-TIME. */

                $"*** LIDOS V0SEGURAVG {WS_WORK_AREAS.AC_L_SEGURAVG} {WS_WORK_AREAS.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" M-0910-FETCH-SEGURAVG-DB-FETCH-1 */
        public void M_0910_FETCH_SEGURAVG_DB_FETCH_1()
        {
            /*" -606- EXEC SQL FETCH CSEGURAVG INTO :V1SEGV-NUM-APOLICE, :V1SEGV-COD-SUBGRUPO, :V1SEGV-NRCERTIF, :V1SEGV-DVCERTIF, :V1SEGV-ITEM, :V1SEGV-CODCLI, :V1SEGV-FONTE, :V1SEGV-OCORHIST, :V1SEGV-EST-CIVIL, :V1SEGV-IDE-SEXO, :V1SEGV-OCORR-END, :V1SEGV-MATRICULA, :V1SEGV-DTINIVIG, :V1SEGV-DTADMISS:V1SEGV-DTADMISS-I, :V1SEGV-DTNASCIM:V1SEGV-DTNASCIM-I, :V1SEGV-SITUACAO, :V1SEGV-NRPROPOS, :V1SEGV-NUM-CARNE END-EXEC. */

            if (CSEGURAVG.Fetch())
            {
                _.Move(CSEGURAVG.V1SEGV_NUM_APOLICE, V1SEGV_NUM_APOLICE);
                _.Move(CSEGURAVG.V1SEGV_COD_SUBGRUPO, V1SEGV_COD_SUBGRUPO);
                _.Move(CSEGURAVG.V1SEGV_NRCERTIF, V1SEGV_NRCERTIF);
                _.Move(CSEGURAVG.V1SEGV_DVCERTIF, V1SEGV_DVCERTIF);
                _.Move(CSEGURAVG.V1SEGV_ITEM, V1SEGV_ITEM);
                _.Move(CSEGURAVG.V1SEGV_CODCLI, V1SEGV_CODCLI);
                _.Move(CSEGURAVG.V1SEGV_FONTE, V1SEGV_FONTE);
                _.Move(CSEGURAVG.V1SEGV_OCORHIST, V1SEGV_OCORHIST);
                _.Move(CSEGURAVG.V1SEGV_EST_CIVIL, V1SEGV_EST_CIVIL);
                _.Move(CSEGURAVG.V1SEGV_IDE_SEXO, V1SEGV_IDE_SEXO);
                _.Move(CSEGURAVG.V1SEGV_OCORR_END, V1SEGV_OCORR_END);
                _.Move(CSEGURAVG.V1SEGV_MATRICULA, V1SEGV_MATRICULA);
                _.Move(CSEGURAVG.V1SEGV_DTINIVIG, V1SEGV_DTINIVIG);
                _.Move(CSEGURAVG.V1SEGV_DTADMISS, V1SEGV_DTADMISS);
                _.Move(CSEGURAVG.V1SEGV_DTADMISS_I, V1SEGV_DTADMISS_I);
                _.Move(CSEGURAVG.V1SEGV_DTNASCIM, V1SEGV_DTNASCIM);
                _.Move(CSEGURAVG.V1SEGV_DTNASCIM_I, V1SEGV_DTNASCIM_I);
                _.Move(CSEGURAVG.V1SEGV_SITUACAO, V1SEGV_SITUACAO);
                _.Move(CSEGURAVG.V1SEGV_NRPROPOS, V1SEGV_NRPROPOS);
                _.Move(CSEGURAVG.V1SEGV_NUM_CARNE, V1SEGV_NUM_CARNE);
            }

        }

        [StopWatch]
        /*" M-0910-FETCH-SEGURAVG-DB-CLOSE-1 */
        public void M_0910_FETCH_SEGURAVG_DB_CLOSE_1()
        {
            /*" -611- EXEC SQL CLOSE CSEGURAVG END-EXEC */

            CSEGURAVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-SEGURAVG-DB-CLOSE-2 */
        public void M_0910_FETCH_SEGURAVG_DB_CLOSE_2()
        {
            /*" -614- EXEC SQL CLOSE CSEGURAVG END-EXEC */

            CSEGURAVG.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-SECTION */
        private void M_1000_PROCESSA_SECTION()
        {
            /*" -636- MOVE '1000-PROCESSA      ' TO PARAGRAFO. */
            _.Move("1000-PROCESSA      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -638- MOVE 'SELECT V0PROPOSTAVA ' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -643- PERFORM M_1000_PROCESSA_DB_SELECT_1 */

            M_1000_PROCESSA_DB_SELECT_1();

            /*" -646- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -648- GO TO 1000-JA-INTEGRADO. */

                M_1000_JA_INTEGRADO(); //GOTO
                return;
            }


            /*" -650- MOVE 'SELECT V0PROPAZUL   ' TO COMANDO. */
            _.Move("SELECT V0PROPAZUL   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -658- PERFORM M_1000_PROCESSA_DB_SELECT_2 */

            M_1000_PROCESSA_DB_SELECT_2();

            /*" -661- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -662- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -664- MOVE ZEROS TO V0PROPAZ-AGENCIA V0PROPAZ-DIA-DEBITO */
                    _.Move(0, V0PROPAZ_AGENCIA, V0PROPAZ_DIA_DEBITO);

                    /*" -665- ELSE */
                }
                else
                {


                    /*" -666- DISPLAY 'ERRO ACESSO V0PROPAZUL ' V1SEGV-NRCERTIF */
                    _.Display($"ERRO ACESSO V0PROPAZUL {V1SEGV_NRCERTIF}");

                    /*" -668- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -670- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -677- PERFORM M_1000_PROCESSA_DB_SELECT_3 */

            M_1000_PROCESSA_DB_SELECT_3();

            /*" -680- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -681- DISPLAY 'ERRO ACESSO CLIENTE ' V1SEGV-NRCERTIF */
                _.Display($"ERRO ACESSO CLIENTE {V1SEGV_NRCERTIF}");

                /*" -683- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -684- IF V1SEGV-DTNASCIM-I = 0 */

            if (V1SEGV_DTNASCIM_I == 0)
            {

                /*" -685- IF V1CLIE-DTNASCIM-I = 0 */

                if (V1CLIE_DTNASCIM_I == 0)
                {

                    /*" -686- IF V1SEGV-DTNASCIM = V1CLIE-DTNASCIM */

                    if (V1SEGV_DTNASCIM == V1CLIE_DTNASCIM)
                    {

                        /*" -687- MOVE V1SEGV-DTNASCIM TO WDATA-NASC */
                        _.Move(V1SEGV_DTNASCIM, WS_WORK_AREAS.WDATA_NASC);

                        /*" -688- ELSE */
                    }
                    else
                    {


                        /*" -689- MOVE V1CLIE-DTNASCIM TO WDATA-NASC */
                        _.Move(V1CLIE_DTNASCIM, WS_WORK_AREAS.WDATA_NASC);

                        /*" -690- ELSE */
                    }

                }
                else
                {


                    /*" -691- MOVE V1SEGV-DTNASCIM TO WDATA-NASC */
                    _.Move(V1SEGV_DTNASCIM, WS_WORK_AREAS.WDATA_NASC);

                    /*" -692- MOVE V1SEGV-DTNASCIM TO V1CLIE-DTNASCIM */
                    _.Move(V1SEGV_DTNASCIM, V1CLIE_DTNASCIM);

                    /*" -693- ELSE */
                }

            }
            else
            {


                /*" -694- IF V1CLIE-DTNASCIM-I = 0 */

                if (V1CLIE_DTNASCIM_I == 0)
                {

                    /*" -695- MOVE V1CLIE-DTNASCIM TO WDATA-NASC */
                    _.Move(V1CLIE_DTNASCIM, WS_WORK_AREAS.WDATA_NASC);

                    /*" -696- ELSE */
                }
                else
                {


                    /*" -698- DISPLAY 'DATA DE NASCIMENTO NULA ' V1SEGV-NRCERTIF ' ' V1SEGV-CODCLI */

                    $"DATA DE NASCIMENTO NULA {V1SEGV_NRCERTIF} {V1SEGV_CODCLI}"
                    .Display();

                    /*" -699- DISPLAY 'SEGURADO NAO INTEGRADO ' */
                    _.Display($"SEGURADO NAO INTEGRADO ");

                    /*" -701- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -703- MOVE 'SELECT V0CONTACOR' TO COMANDO. */
            _.Move("SELECT V0CONTACOR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -717- PERFORM M_1000_PROCESSA_DB_SELECT_4 */

            M_1000_PROCESSA_DB_SELECT_4();

            /*" -720- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -721- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -722- MOVE '3' TO HOST-OPCAOPAG */
                    _.Move("3", HOST_OPCAOPAG);

                    /*" -725- MOVE -1 TO HOST-IND V0CCOR-DIA-DEBITO-I V0CCOR-OPCAOCAP-I */
                    _.Move(-1, HOST_IND, V0CCOR_DIA_DEBITO_I, V0CCOR_OPCAOCAP_I);

                    /*" -730- MOVE ZEROS TO V0CCOR-COD-AGENCIA HOST-OPRCTADEB HOST-NUMCTADEB HOST-DIGCTADEB V0CCOR-DIA-DEBITO */
                    _.Move(0, V0CCOR_COD_AGENCIA, HOST_OPRCTADEB, HOST_NUMCTADEB, HOST_DIGCTADEB, V0CCOR_DIA_DEBITO);

                    /*" -731- GO TO 1000-COBERTURAS */

                    M_1000_COBERTURAS(); //GOTO
                    return;

                    /*" -732- ELSE */
                }
                else
                {


                    /*" -734- DISPLAY ' AUSENCIA DE CONTACORR - ' SQLCODE ' ' V1SEGV-NRCERTIF */

                    $" AUSENCIA DE CONTACORR - {DB.SQLCODE} {V1SEGV_NRCERTIF}"
                    .Display();

                    /*" -735- DISPLAY 'SEGURADO NAO INTEGRADO   ' */
                    _.Display($"SEGURADO NAO INTEGRADO   ");

                    /*" -737- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -738- IF V0CCOR-COD-AGENCIA EQUAL ZEROS */

            if (V0CCOR_COD_AGENCIA == 00)
            {

                /*" -739- MOVE '3' TO HOST-OPCAOPAG */
                _.Move("3", HOST_OPCAOPAG);

                /*" -741- MOVE -1 TO HOST-IND V0CCOR-DIA-DEBITO-I */
                _.Move(-1, HOST_IND, V0CCOR_DIA_DEBITO_I);

                /*" -746- MOVE ZEROS TO V0CCOR-COD-AGENCIA HOST-OPRCTADEB HOST-NUMCTADEB HOST-DIGCTADEB V0CCOR-DIA-DEBITO */
                _.Move(0, V0CCOR_COD_AGENCIA, HOST_OPRCTADEB, HOST_NUMCTADEB, HOST_DIGCTADEB, V0CCOR_DIA_DEBITO);

                /*" -748- GO TO 1000-COBERTURAS. */

                M_1000_COBERTURAS(); //GOTO
                return;
            }


            /*" -749- MOVE ZEROS TO HOST-IND */
            _.Move(0, HOST_IND);

            /*" -750- MOVE V0CCOR-NUM-CTA-CORRENTE TO W-NUM-CTA-CORRENTE */
            _.Move(V0CCOR_NUM_CTA_CORRENTE, W_NUM_CTA_CORRENTE);

            /*" -751- MOVE V0CCOR-DAC-CTA-CORRENTE TO W-DAC-CTA-CORRENTE */
            _.Move(V0CCOR_DAC_CTA_CORRENTE, FILLER_1.W_DAC_CTA_CORRENTE);

            /*" -752- MOVE WOPRCTADEB TO HOST-OPRCTADEB */
            _.Move(FILLER_0.WOPRCTADEB, HOST_OPRCTADEB);

            /*" -753- MOVE WNUMCTADEB TO HOST-NUMCTADEB */
            _.Move(FILLER_0.WNUMCTADEB, HOST_NUMCTADEB);

            /*" -755- MOVE WDIGCTADEB TO HOST-DIGCTADEB. */
            _.Move(WDIGCTADEB, HOST_DIGCTADEB);

            /*" -756- IF WOPRCTADEB EQUAL 13 */

            if (FILLER_0.WOPRCTADEB == 13)
            {

                /*" -757- MOVE '2' TO HOST-OPCAOPAG */
                _.Move("2", HOST_OPCAOPAG);

                /*" -758- ELSE */
            }
            else
            {


                /*" -758- MOVE '1' TO HOST-OPCAOPAG. */
                _.Move("1", HOST_OPCAOPAG);
            }


            /*" -0- FLUXCONTROL_PERFORM M_1000_COBERTURAS */

            M_1000_COBERTURAS();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-1 */
        public void M_1000_PROCESSA_DB_SELECT_1()
        {
            /*" -643- EXEC SQL SELECT CODPRODU INTO :V0PROD-CODPRODU FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :V1SEGV-NRCERTIF END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_1_Query1 = new M_1000_PROCESSA_DB_SELECT_1_Query1()
            {
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }


        }

        [StopWatch]
        /*" M-1000-COBERTURAS */
        private void M_1000_COBERTURAS(bool isPerform = false)
        {
            /*" -763- IF V0CCOR-OPCAOCAP-I < ZEROS */

            if (V0CCOR_OPCAOCAP_I < 00)
            {

                /*" -765- MOVE 0 TO V0CCOR-OPCAOCAP. */
                _.Move(0, V0CCOR_OPCAOCAP);
            }


            /*" -766- IF V0CCOR-DIA-DEBITO-I < ZEROS */

            if (V0CCOR_DIA_DEBITO_I < 00)
            {

                /*" -771- MOVE 28 TO V0CCOR-DIA-DEBITO. */
                _.Move(28, V0CCOR_DIA_DEBITO);
            }


            /*" -773- MOVE V1SEGV-NUM-APOLICE TO LK-APOLICE. */
            _.Move(V1SEGV_NUM_APOLICE, PARAMETROS.LK_APOLICE);

            /*" -775- MOVE V1SEGV-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(V1SEGV_COD_SUBGRUPO, PARAMETROS.LK_SUBGRUPO);

            /*" -797- MOVE ZEROS TO LK-IDADE LK-DATA-NASCIMENTO LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE LK-MENSAGEM. */
            _.Move(0, PARAMETROS.LK_IDADE, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE, PARAMETROS.LK_MENSAGEM);

            /*" -799- MOVE 'SELECT V0HISTSEGVG ' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -810- PERFORM M_1000_COBERTURAS_DB_SELECT_1 */

            M_1000_COBERTURAS_DB_SELECT_1();

            /*" -813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -815- DISPLAY 'ERRO ACESSO HISTSEGVG ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-ITEM */

                $"ERRO ACESSO HISTSEGVG {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_ITEM}"
                .Display();

                /*" -818- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


            /*" -820- ADD 1 TO AC-L-HISTSEGVG. */
            WS_WORK_AREAS.AC_L_HISTSEGVG.Value = WS_WORK_AREAS.AC_L_HISTSEGVG + 1;

            /*" -821- IF V1HSEG-CODMOEDA-I < 0 */

            if (V1HSEG_CODMOEDA_I < 0)
            {

                /*" -823- MOVE 17 TO V1HSEG-CODMOEDA. */
                _.Move(17, V1HSEG_CODMOEDA);
            }


            /*" -830- PERFORM M_1000_COBERTURAS_DB_SELECT_2 */

            M_1000_COBERTURAS_DB_SELECT_2();

            /*" -833- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -834- DISPLAY 'LEITURA V0COTACAO      ' SQLCODE */
                _.Display($"LEITURA V0COTACAO      {DB.SQLCODE}");

                /*" -836- DISPLAY V1SEGV-NUM-APOLICE ' ' V1SEGV-OCORHIST ' ' V1HSEG-DTMOVTO ' ' V1HSEG-CODMOEDA */

                $"{V1SEGV_NUM_APOLICE} {V1SEGV_OCORHIST} {V1HSEG_DTMOVTO} {V1HSEG_CODMOEDA}"
                .Display();

                /*" -839- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


            /*" -841- PERFORM 3000-00-SELECT-APOLICE. */

            M_3000_00_SELECT_APOLICE_SECTION();

            /*" -843- MOVE 'SELECT V0COBERAPOL 93-11' TO COMANDO. */
            _.Move("SELECT V0COBERAPOL 93-11", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -861- PERFORM M_1000_COBERTURAS_DB_SELECT_3 */

            M_1000_COBERTURAS_DB_SELECT_3();

            /*" -864- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -865- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -868- MOVE ZEROS TO CIMP-SEGURADA-VG CPRM-TARIFARIO-VG CFATOR-MULTIPLICA */
                    _.Move(0, CIMP_SEGURADA_VG, CPRM_TARIFARIO_VG, CFATOR_MULTIPLICA);

                    /*" -869- ELSE */
                }
                else
                {


                    /*" -871- DISPLAY 'ERRO ACESSO COBERAPOL 93 ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-ITEM */

                    $"ERRO ACESSO COBERAPOL 93 {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_ITEM}"
                    .Display();

                    /*" -873- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -875- ADD 1 TO AC-L-COBERAPOL. */
            WS_WORK_AREAS.AC_L_COBERAPOL.Value = WS_WORK_AREAS.AC_L_COBERAPOL + 1;

            /*" -879- COMPUTE CIMP-SEGURADA-VG = CIMP-SEGURADA-VG * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CIMP_SEGURADA_VG.Value = CIMP_SEGURADA_VG * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -883- COMPUTE CPRM-TARIFARIO-VG = CPRM-TARIFARIO-VG * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CPRM_TARIFARIO_VG.Value = CPRM_TARIFARIO_VG * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -885- MOVE 'SELECT V0COBERAPOL 81-01' TO COMANDO. */
            _.Move("SELECT V0COBERAPOL 81-01", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -901- PERFORM M_1000_COBERTURAS_DB_SELECT_4 */

            M_1000_COBERTURAS_DB_SELECT_4();

            /*" -904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -905- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -908- MOVE ZEROS TO CIMP-SEGURADA-AP CPRM-TARIFARIO-AP CFATOR-MULTIPLICA */
                    _.Move(0, CIMP_SEGURADA_AP, CPRM_TARIFARIO_AP, CFATOR_MULTIPLICA);

                    /*" -909- ELSE */
                }
                else
                {


                    /*" -911- DISPLAY 'ERRO ACESSO COBERAPOL AP 81-01 ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-ITEM */

                    $"ERRO ACESSO COBERAPOL AP 81-01 {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_ITEM}"
                    .Display();

                    /*" -913- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -915- ADD 1 TO AC-L-COBERAPOL. */
            WS_WORK_AREAS.AC_L_COBERAPOL.Value = WS_WORK_AREAS.AC_L_COBERAPOL + 1;

            /*" -919- COMPUTE CIMP-SEGURADA-AP = CIMP-SEGURADA-AP * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CIMP_SEGURADA_AP.Value = CIMP_SEGURADA_AP * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -923- COMPUTE CPRM-TARIFARIO-AP = CPRM-TARIFARIO-AP * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CPRM_TARIFARIO_AP.Value = CPRM_TARIFARIO_AP * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -925- MOVE 'SELECT V0COBERAPOL 81-02' TO COMANDO. */
            _.Move("SELECT V0COBERAPOL 81-02", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -939- PERFORM M_1000_COBERTURAS_DB_SELECT_5 */

            M_1000_COBERTURAS_DB_SELECT_5();

            /*" -942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -943- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -945- MOVE ZEROS TO CIMP-SEGURADA-IP CFATOR-MULTIPLICA */
                    _.Move(0, CIMP_SEGURADA_IP, CFATOR_MULTIPLICA);

                    /*" -946- ELSE */
                }
                else
                {


                    /*" -948- DISPLAY 'ERRO ACESSO COBERAPOL AP 81-02 ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-ITEM */

                    $"ERRO ACESSO COBERAPOL AP 81-02 {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_ITEM}"
                    .Display();

                    /*" -950- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -952- ADD 1 TO AC-L-COBERAPOL. */
            WS_WORK_AREAS.AC_L_COBERAPOL.Value = WS_WORK_AREAS.AC_L_COBERAPOL + 1;

            /*" -957- COMPUTE CIMP-SEGURADA-IP = CIMP-SEGURADA-IP * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CIMP_SEGURADA_IP.Value = CIMP_SEGURADA_IP * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -959- MOVE 'SELECT V0COBERAPOL 81-03' TO COMANDO. */
            _.Move("SELECT V0COBERAPOL 81-03", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -973- PERFORM M_1000_COBERTURAS_DB_SELECT_6 */

            M_1000_COBERTURAS_DB_SELECT_6();

            /*" -976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -977- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -979- MOVE ZEROS TO CIMP-SEGURADA-AMDS CFATOR-MULTIPLICA */
                    _.Move(0, CIMP_SEGURADA_AMDS, CFATOR_MULTIPLICA);

                    /*" -980- ELSE */
                }
                else
                {


                    /*" -982- DISPLAY 'ERRO ACESSO COBERAPOL AP 81-03 ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-ITEM */

                    $"ERRO ACESSO COBERAPOL AP 81-03 {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_ITEM}"
                    .Display();

                    /*" -984- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -986- ADD 1 TO AC-L-COBERAPOL. */
            WS_WORK_AREAS.AC_L_COBERAPOL.Value = WS_WORK_AREAS.AC_L_COBERAPOL + 1;

            /*" -990- COMPUTE CIMP-SEGURADA-AMDS = CIMP-SEGURADA-AMDS * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CIMP_SEGURADA_AMDS.Value = CIMP_SEGURADA_AMDS * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -992- MOVE 'SELECT V0COBERAPOL 81-04' TO COMANDO. */
            _.Move("SELECT V0COBERAPOL 81-04", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1006- PERFORM M_1000_COBERTURAS_DB_SELECT_7 */

            M_1000_COBERTURAS_DB_SELECT_7();

            /*" -1009- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1010- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1012- MOVE ZEROS TO CIMP-SEGURADA-DH CFATOR-MULTIPLICA */
                    _.Move(0, CIMP_SEGURADA_DH, CFATOR_MULTIPLICA);

                    /*" -1013- ELSE */
                }
                else
                {


                    /*" -1015- DISPLAY 'ERRO ACESSO COBERAPOL AP 81-04 ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-NUM-APOLICE */

                    $"ERRO ACESSO COBERAPOL AP 81-04 {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_NUM_APOLICE}"
                    .Display();

                    /*" -1017- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1019- ADD 1 TO AC-L-COBERAPOL. */
            WS_WORK_AREAS.AC_L_COBERAPOL.Value = WS_WORK_AREAS.AC_L_COBERAPOL + 1;

            /*" -1023- COMPUTE CIMP-SEGURADA-DH = CIMP-SEGURADA-DH * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CIMP_SEGURADA_DH.Value = CIMP_SEGURADA_DH * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -1025- MOVE 'SELECT V0COBERAPOL 81-05' TO COMANDO. */
            _.Move("SELECT V0COBERAPOL 81-05", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1039- PERFORM M_1000_COBERTURAS_DB_SELECT_8 */

            M_1000_COBERTURAS_DB_SELECT_8();

            /*" -1042- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1043- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1045- MOVE ZEROS TO CIMP-SEGURADA-DIT CFATOR-MULTIPLICA */
                    _.Move(0, CIMP_SEGURADA_DIT, CFATOR_MULTIPLICA);

                    /*" -1046- ELSE */
                }
                else
                {


                    /*" -1048- DISPLAY 'ERRO ACESSO COBERAPOL AP 81-05 ' SQLCODE ' ' V1SEGV-NUM-APOLICE ' ' V1SEGV-ITEM */

                    $"ERRO ACESSO COBERAPOL AP 81-05 {DB.SQLCODE} {V1SEGV_NUM_APOLICE} {V1SEGV_ITEM}"
                    .Display();

                    /*" -1050- GO TO 1000-NEXT. */

                    M_1000_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1052- ADD 1 TO AC-L-COBERAPOL. */
            WS_WORK_AREAS.AC_L_COBERAPOL.Value = WS_WORK_AREAS.AC_L_COBERAPOL + 1;

            /*" -1056- COMPUTE CIMP-SEGURADA-DIT = CIMP-SEGURADA-DIT * MOEDA-VALCPR * CFATOR-MULTIPLICA. */
            CIMP_SEGURADA_DIT.Value = CIMP_SEGURADA_DIT * MOEDA_VALCPR * CFATOR_MULTIPLICA;

            /*" -1057- MOVE CIMP-SEGURADA-VG TO LK-PURO-MORTE-NATURAL */
            _.Move(CIMP_SEGURADA_VG, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -1058- MOVE CIMP-SEGURADA-AP TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(CIMP_SEGURADA_AP, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -1059- MOVE CIMP-SEGURADA-IP TO LK-PURO-INV-PERMANENTE */
            _.Move(CIMP_SEGURADA_IP, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -1060- MOVE CIMP-SEGURADA-AMDS TO LK-PURO-ASS-MEDICA */
            _.Move(CIMP_SEGURADA_AMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -1061- MOVE CIMP-SEGURADA-DH TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(CIMP_SEGURADA_DH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -1063- MOVE CIMP-SEGURADA-DIT TO LK-PURO-DIARIA-INTERNACAO */
            _.Move(CIMP_SEGURADA_DIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -1065- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -1066- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -1067- DISPLAY 'ERRO SUBROTINA VG0710S ' */
                _.Display($"ERRO SUBROTINA VG0710S ");

                /*" -1068- DISPLAY 'MENSAGEM ' LK-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS.LK_MENSAGEM}");

                /*" -1070- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1071- MOVE LK-COBT-MORTE-NATURAL TO CIMP-SEGURADA-VG */
            _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, CIMP_SEGURADA_VG);

            /*" -1072- MOVE LK-COBT-MORTE-ACIDENTAL TO CIMP-SEGURADA-AP */
            _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, CIMP_SEGURADA_AP);

            /*" -1073- MOVE LK-COBT-INV-PERMANENTE TO CIMP-SEGURADA-IP */
            _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, CIMP_SEGURADA_IP);

            /*" -1074- MOVE LK-COBT-INV-POR-ACIDENTE TO CIMP-SEGURADA-IPA */
            _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, CIMP_SEGURADA_IPA);

            /*" -1075- MOVE LK-COBT-ASS-MEDICA TO CIMP-SEGURADA-AMDS */
            _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, CIMP_SEGURADA_AMDS);

            /*" -1076- MOVE LK-COBT-DIARIA-HOSPITALAR TO CIMP-SEGURADA-DH */
            _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, CIMP_SEGURADA_DH);

            /*" -1078- MOVE LK-COBT-DIARIA-INTERNACAO TO CIMP-SEGURADA-DIT. */
            _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, CIMP_SEGURADA_DIT);

            /*" -1079- MOVE CPRM-TARIFARIO-VG TO PRMVG. */
            _.Move(CPRM_TARIFARIO_VG, PRMVG);

            /*" -1080- MOVE CPRM-TARIFARIO-AP TO PRMAP. */
            _.Move(CPRM_TARIFARIO_AP, PRMAP);

            /*" -1084- MOVE ZEROS TO HOST-QTTITCAP HOST-VLTITCAP HOST-VLCUSCAP. */
            _.Move(0, HOST_QTTITCAP, HOST_VLTITCAP, HOST_VLCUSCAP);

            /*" -1086- COMPUTE VLPREMIO = PRMVG + PRMAP. */
            VLPREMIO.Value = PRMVG + PRMAP;

            /*" -1087- IF V0CCOR-OPCAOCAP = 1 */

            if (V0CCOR_OPCAOCAP == 1)
            {

                /*" -1088- COMPUTE VLPREMIO = VLPREMIO + 1,71 */
                VLPREMIO.Value = VLPREMIO + 1.71;

                /*" -1089- MOVE 1 TO HOST-QTTITCAP */
                _.Move(1, HOST_QTTITCAP);

                /*" -1090- MOVE 10000,00 TO HOST-VLTITCAP */
                _.Move(10000.00, HOST_VLTITCAP);

                /*" -1091- MOVE 1,71 TO HOST-VLCUSCAP */
                _.Move(1.71, HOST_VLCUSCAP);

                /*" -1093- GO TO 1000-IDADE. */

                M_1000_IDADE(); //GOTO
                return;
            }


            /*" -1095- MOVE 'SELECT V0PLACAPVG       ' TO COMANDO. */
            _.Move("SELECT V0PLACAPVG       ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1105- PERFORM M_1000_COBERTURAS_DB_SELECT_9 */

            M_1000_COBERTURAS_DB_SELECT_9();

            /*" -1108- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1109- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1110- MOVE ZEROS TO PLACAP-QTTITCAP */
                    _.Move(0, PLACAP_QTTITCAP);

                    /*" -1111- ELSE */
                }
                else
                {


                    /*" -1112- DISPLAY 'LEITURA V0PLACAPVG (ERR)' SQLCODE */
                    _.Display($"LEITURA V0PLACAPVG (ERR){DB.SQLCODE}");

                    /*" -1114- DISPLAY V1SEGV-NRCERTIF ' ' V1HSEG-DTMOVTO */

                    $"{V1SEGV_NRCERTIF} {V1HSEG_DTMOVTO}"
                    .Display();

                    /*" -1116- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1118- MOVE 'SELECT V0CUSTOCAPVG     ' TO COMANDO. */
            _.Move("SELECT V0CUSTOCAPVG     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1126- PERFORM M_1000_COBERTURAS_DB_SELECT_10 */

            M_1000_COBERTURAS_DB_SELECT_10();

            /*" -1129- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1130- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1131- MOVE ZEROS TO CUSTCAP-VLCUSTCAP */
                    _.Move(0, CUSTCAP_VLCUSTCAP);

                    /*" -1132- ELSE */
                }
                else
                {


                    /*" -1133- DISPLAY 'LEITURA V0CUSTOCAPVG (ERR)' SQLCODE */
                    _.Display($"LEITURA V0CUSTOCAPVG (ERR){DB.SQLCODE}");

                    /*" -1135- DISPLAY V1SEGV-NRCERTIF ' ' V1HSEG-DTMOVTO */

                    $"{V1SEGV_NRCERTIF} {V1HSEG_DTMOVTO}"
                    .Display();

                    /*" -1137- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1138- MOVE PLACAP-QTTITCAP TO HOST-QTTITCAP. */
            _.Move(PLACAP_QTTITCAP, HOST_QTTITCAP);

            /*" -1140- MOVE CUSTCAP-VLCUSTCAP TO HOST-VLCUSCAP. */
            _.Move(CUSTCAP_VLCUSTCAP, HOST_VLCUSCAP);

            /*" -1141- IF HOST-QTTITCAP = ZEROS */

            if (HOST_QTTITCAP == 00)
            {

                /*" -1142- MOVE ZEROS TO HOST-VLTITCAP */
                _.Move(0, HOST_VLTITCAP);

                /*" -1143- ELSE */
            }
            else
            {


                /*" -1145- MOVE 10000,00 TO HOST-VLTITCAP. */
                _.Move(10000.00, HOST_VLTITCAP);
            }


            /*" -1148- COMPUTE CUSTCAP-VLCUSTCAP = CUSTCAP-VLCUSTCAP * PLACAP-QTTITCAP. */
            CUSTCAP_VLCUSTCAP.Value = CUSTCAP_VLCUSTCAP * PLACAP_QTTITCAP;

            /*" -1149- COMPUTE VLPREMIO = VLPREMIO + CUSTCAP-VLCUSTCAP. */
            VLPREMIO.Value = VLPREMIO + CUSTCAP_VLCUSTCAP;

        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-1 */
        public void M_1000_COBERTURAS_DB_SELECT_1()
        {
            /*" -810- EXEC SQL SELECT DATA_MOVIMENTO, COD_OPERACAO, COD_MOEDA_PRM INTO :V1HSEG-DTMOVTO, :V1HSEG-CODOPER, :V1HSEG-CODMOEDA:V1HSEG-CODMOEDA-I FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NUM_ITEM = :V1SEGV-ITEM AND OCORR_HISTORICO = :V1SEGV-OCORHIST END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_1_Query1 = new M_1000_COBERTURAS_DB_SELECT_1_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_1_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HSEG_DTMOVTO, V1HSEG_DTMOVTO);
                _.Move(executed_1.V1HSEG_CODOPER, V1HSEG_CODOPER);
                _.Move(executed_1.V1HSEG_CODMOEDA, V1HSEG_CODMOEDA);
                _.Move(executed_1.V1HSEG_CODMOEDA_I, V1HSEG_CODMOEDA_I);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-2 */
        public void M_1000_PROCESSA_DB_SELECT_2()
        {
            /*" -658- EXEC SQL SELECT AGENCIA, DIA_DEBITO INTO :V0PROPAZ-AGENCIA, :V0PROPAZ-DIA-DEBITO FROM SEGUROS.V0PROPAZUL WHERE NRCERTIF = :V1SEGV-NRCERTIF AND SITUACAO NOT IN ( '0' , '5' ) END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_2_Query1 = new M_1000_PROCESSA_DB_SELECT_2_Query1()
            {
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_2_Query1.Execute(m_1000_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROPAZ_AGENCIA, V0PROPAZ_AGENCIA);
                _.Move(executed_1.V0PROPAZ_DIA_DEBITO, V0PROPAZ_DIA_DEBITO);
            }


        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-2 */
        public void M_1000_COBERTURAS_DB_SELECT_2()
        {
            /*" -830- EXEC SQL SELECT VALCPR INTO :MOEDA-VALCPR FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1HSEG-CODMOEDA AND DTINIVIG <= :V1HSEG-DTMOVTO AND DTTERVIG >= :V1HSEG-DTMOVTO END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_2_Query1 = new M_1000_COBERTURAS_DB_SELECT_2_Query1()
            {
                V1HSEG_CODMOEDA = V1HSEG_CODMOEDA.ToString(),
                V1HSEG_DTMOVTO = V1HSEG_DTMOVTO.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_2_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDA_VALCPR, MOEDA_VALCPR);
            }


        }

        [StopWatch]
        /*" M-1000-IDADE */
        private void M_1000_IDADE(bool isPerform = false)
        {
            /*" -1158- MOVE V1HSEG-DTMOVTO TO WS-DATA-BASE. */
            _.Move(V1HSEG_DTMOVTO, WS_WORK_AREAS.WS_DATA_BASE);

            /*" -1160- COMPUTE HOST-IDADE = WS-ANO-BASE - ANO-NASC. */
            HOST_IDADE.Value = WS_WORK_AREAS.WS_DATA_BASE.WS_ANO_BASE - WS_WORK_AREAS.WDATA_NASC.ANO_NASC;

            /*" -1161- IF MES-NASC GREATER WS-MES-BASE */

            if (WS_WORK_AREAS.WDATA_NASC.MES_NASC > WS_WORK_AREAS.WS_DATA_BASE.WS_MES_BASE)
            {

                /*" -1162- SUBTRACT 1 FROM HOST-IDADE */
                HOST_IDADE.Value = HOST_IDADE - 1;

                /*" -1163- ELSE */
            }
            else
            {


                /*" -1164- IF MES-NASC EQUAL WS-MES-BASE */

                if (WS_WORK_AREAS.WDATA_NASC.MES_NASC == WS_WORK_AREAS.WS_DATA_BASE.WS_MES_BASE)
                {

                    /*" -1165- IF DIA-NASC GREATER WS-DIA-BASE */

                    if (WS_WORK_AREAS.WDATA_NASC.DIA_NASC > WS_WORK_AREAS.WS_DATA_BASE.WS_DIA_BASE)
                    {

                        /*" -1167- SUBTRACT 1 FROM HOST-IDADE. */
                        HOST_IDADE.Value = HOST_IDADE - 1;
                    }

                }

            }


            /*" -1169- MOVE 'SELECT V0PRODUTOSVG ' TO COMANDO. */
            _.Move("SELECT V0PRODUTOSVG ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1179- PERFORM M_1000_IDADE_DB_SELECT_1 */

            M_1000_IDADE_DB_SELECT_1();

            /*" -1182- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1184- DISPLAY 'ERRO ACESSO PRODUTO ' V1SEGV-NUM-APOLICE ' ' V1SEGV-COD-SUBGRUPO */

                $"ERRO ACESSO PRODUTO {V1SEGV_NUM_APOLICE} {V1SEGV_COD_SUBGRUPO}"
                .Display();

                /*" -1186- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1187- IF V0PROD-TEM-CDG-I LESS ZEROS */

            if (V0PROD_TEM_CDG_I < 00)
            {

                /*" -1188- MOVE 'N' TO V0PROD-TEM-CDG. */
                _.Move("N", V0PROD_TEM_CDG);
            }


            /*" -1189- MOVE 'SELECT V0PARCELVA   ' TO COMANDO */
            _.Move("SELECT V0PARCELVA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1201- PERFORM M_1000_IDADE_DB_SELECT_2 */

            M_1000_IDADE_DB_SELECT_2();

            /*" -1203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1205- DISPLAY 'ERRO ACESSO V0PARCELVA ' V1SEGV-NRCERTIF ' ' V1SEGV-NUM-CARNE */

                $"ERRO ACESSO V0PARCELVA {V1SEGV_NRCERTIF} {V1SEGV_NUM_CARNE}"
                .Display();

                /*" -1207- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1208- IF VLPREMIO NOT EQUAL HOST-VALOPERACAO */

            if (VLPREMIO != HOST_VALOPERACAO)
            {

                /*" -1209- DISPLAY 'DIVERGENCIA PREMIO  ' V1SEGV-NRCERTIF */
                _.Display($"DIVERGENCIA PREMIO  {V1SEGV_NRCERTIF}");

                /*" -1210- DISPLAY 'NUMERO PARCELA      ' V1SEGV-NUM-CARNE */
                _.Display($"NUMERO PARCELA      {V1SEGV_NUM_CARNE}");

                /*" -1211- DISPLAY 'VALOR DA PARCELA    ' HOST-VALOPERACAO */
                _.Display($"VALOR DA PARCELA    {HOST_VALOPERACAO}");

                /*" -1213- DISPLAY 'VALOR DO PREMIO     ' VLPREMIO. */
                _.Display($"VALOR DO PREMIO     {VLPREMIO}");
            }


            /*" -1214- IF HOST-DIA-DEBITO GREATER THAN 28 */

            if (HOST_DIA_DEBITO > 28)
            {

                /*" -1216- MOVE 28 TO HOST-DIA-DEBITO. */
                _.Move(28, HOST_DIA_DEBITO);
            }


            /*" -1217- IF V0PROPAZ-DIA-DEBITO GREATER THAN 28 */

            if (V0PROPAZ_DIA_DEBITO > 28)
            {

                /*" -1219- MOVE 28 TO V0PROPAZ-DIA-DEBITO. */
                _.Move(28, V0PROPAZ_DIA_DEBITO);
            }


            /*" -1220- IF HOST-OPCAOPAG EQUAL '3' */

            if (HOST_OPCAOPAG == "3")
            {

                /*" -1222- MOVE HOST-DIA-DEBITO TO V0CCOR-DIA-DEBITO. */
                _.Move(HOST_DIA_DEBITO, V0CCOR_DIA_DEBITO);
            }


            /*" -1225- MOVE HOST-DTPROXVEN TO WDATA-PARC-PRX. */
            _.Move(HOST_DTPROXVEN, WS_WORK_AREAS.WDATA_PARC_PRX);

            /*" -1226- IF V0PROPAZ-DIA-DEBITO GREATER ZEROS */

            if (V0PROPAZ_DIA_DEBITO > 00)
            {

                /*" -1228- MOVE V0PROPAZ-DIA-DEBITO TO WDATA-PRX-DIA. */
                _.Move(V0PROPAZ_DIA_DEBITO, WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_DIA);
            }


            /*" -1229- IF WDATA-PARC-PRX LESS HOST-DTPROXVEN */

            if (WS_WORK_AREAS.WDATA_PARC_PRX < HOST_DTPROXVEN)
            {

                /*" -1230- COMPUTE WDATA-PRX-MES = WDATA-PRX-MES + 1 */
                WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES + 1;

                /*" -1231- IF WDATA-PRX-MES > 12 */

                if (WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES > 12)
                {

                    /*" -1232- MOVE 1 TO WDATA-PRX-MES */
                    _.Move(1, WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES);

                    /*" -1234- COMPUTE WDATA-PRX-ANO = WDATA-PRX-ANO + 1. */
                    WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_ANO.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_ANO + 1;
                }

            }


            /*" -1241- MOVE WDATA-PARC-PRX TO HOST-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.WDATA_PARC_PRX, HOST_DTPROXVEN);

            /*" -1243- PERFORM 2000-INSERT-PROPOSTAVA. */

            M_2000_INSERT_PROPOSTAVA_SECTION();

            /*" -1245- PERFORM 2100-INSERT-COBERPROPVA. */

            M_2100_INSERT_COBERPROPVA_SECTION();

            /*" -1247- PERFORM 2400-INSERT-OPCAOPAGVA. */

            M_2400_INSERT_OPCAOPAGVA_SECTION();

            /*" -1248- IF V0PROD-TEM-CDG = 'S' */

            if (V0PROD_TEM_CDG == "S")
            {

                /*" -1248- PERFORM 2500-INSERT-CDGCOBER. */

                M_2500_INSERT_CDGCOBER_SECTION();
            }


        }

        [StopWatch]
        /*" M-1000-IDADE-DB-SELECT-1 */
        public void M_1000_IDADE_DB_SELECT_1()
        {
            /*" -1179- EXEC SQL SELECT CODPRODU, PERIPGTO, TEM_CDG INTO :V0PROD-CODPRODU, :HOST-PERIPGTO, :V0PROD-TEM-CDG:V0PROD-TEM-CDG-I FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND CODSUBES = :V1SEGV-COD-SUBGRUPO END-EXEC. */

            var m_1000_IDADE_DB_SELECT_1_Query1 = new M_1000_IDADE_DB_SELECT_1_Query1()
            {
                V1SEGV_COD_SUBGRUPO = V1SEGV_COD_SUBGRUPO.ToString(),
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_IDADE_DB_SELECT_1_Query1.Execute(m_1000_IDADE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_CODPRODU, V0PROD_CODPRODU);
                _.Move(executed_1.HOST_PERIPGTO, HOST_PERIPGTO);
                _.Move(executed_1.V0PROD_TEM_CDG, V0PROD_TEM_CDG);
                _.Move(executed_1.V0PROD_TEM_CDG_I, V0PROD_TEM_CDG_I);
            }


        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-3 */
        public void M_1000_COBERTURAS_DB_SELECT_3()
        {
            /*" -861- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :CIMP-SEGURADA-VG, :CPRM-TARIFARIO-VG, :CFATOR-MULTIPLICA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V1SEGV-ITEM AND OCORHIST = :V1SEGV-OCORHIST AND RAMOFR = 93 AND MODALIFR >= 0 AND COD_COBERTURA = 11 END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_3_Query1 = new M_1000_COBERTURAS_DB_SELECT_3_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_3_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_VG, CIMP_SEGURADA_VG);
                _.Move(executed_1.CPRM_TARIFARIO_VG, CPRM_TARIFARIO_VG);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-1000-IDADE-DB-SELECT-2 */
        public void M_1000_IDADE_DB_SELECT_2()
        {
            /*" -1201- EXEC SQL SELECT DAY(DTVENCTO), DTVENCTO, DTVENCTO + :HOST-PERIPGTO MONTHS, PRMVG + PRMAP INTO :HOST-DIA-DEBITO, :HOST-DTVENCTO, :HOST-DTPROXVEN, :HOST-VALOPERACAO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V1SEGV-NRCERTIF AND NRPARCEL = :V1SEGV-NUM-CARNE END-EXEC */

            var m_1000_IDADE_DB_SELECT_2_Query1 = new M_1000_IDADE_DB_SELECT_2_Query1()
            {
                V1SEGV_NUM_CARNE = V1SEGV_NUM_CARNE.ToString(),
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
                HOST_PERIPGTO = HOST_PERIPGTO.ToString(),
            };

            var executed_1 = M_1000_IDADE_DB_SELECT_2_Query1.Execute(m_1000_IDADE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DIA_DEBITO, HOST_DIA_DEBITO);
                _.Move(executed_1.HOST_DTVENCTO, HOST_DTVENCTO);
                _.Move(executed_1.HOST_DTPROXVEN, HOST_DTPROXVEN);
                _.Move(executed_1.HOST_VALOPERACAO, HOST_VALOPERACAO);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-3 */
        public void M_1000_PROCESSA_DB_SELECT_3()
        {
            /*" -677- EXEC SQL SELECT DATA_NASCIMENTO, CGCCPF INTO :V1CLIE-DTNASCIM:V1CLIE-DTNASCIM-I, :V1CLIE-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V1SEGV-CODCLI END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_3_Query1 = new M_1000_PROCESSA_DB_SELECT_3_Query1()
            {
                V1SEGV_CODCLI = V1SEGV_CODCLI.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_3_Query1.Execute(m_1000_PROCESSA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIE_DTNASCIM, V1CLIE_DTNASCIM);
                _.Move(executed_1.V1CLIE_DTNASCIM_I, V1CLIE_DTNASCIM_I);
                _.Move(executed_1.V1CLIE_CGCCPF, V1CLIE_CGCCPF);
            }


        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-4 */
        public void M_1000_COBERTURAS_DB_SELECT_4()
        {
            /*" -901- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :CIMP-SEGURADA-AP, :CPRM-TARIFARIO-AP, :CFATOR-MULTIPLICA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V1SEGV-ITEM AND OCORHIST = :V1SEGV-OCORHIST AND RAMOFR = 81 AND MODALIFR >= 0 AND COD_COBERTURA = 01 END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_4_Query1 = new M_1000_COBERTURAS_DB_SELECT_4_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_4_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_AP, CIMP_SEGURADA_AP);
                _.Move(executed_1.CPRM_TARIFARIO_AP, CPRM_TARIFARIO_AP);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-1000-JA-INTEGRADO */
        private void M_1000_JA_INTEGRADO(bool isPerform = false)
        {
            /*" -1255- PERFORM M_1000_JA_INTEGRADO_DB_UPDATE_1 */

            M_1000_JA_INTEGRADO_DB_UPDATE_1();

            /*" -1258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1260- DISPLAY 'ERRO UPDATE V0SEGURAVG ' V1SEGV-NRCERTIF ' ' V1SEGV-NUM-CARNE */

                $"ERRO UPDATE V0SEGURAVG {V1SEGV_NRCERTIF} {V1SEGV_NUM_CARNE}"
                .Display();

                /*" -1260- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-JA-INTEGRADO-DB-UPDATE-1 */
        public void M_1000_JA_INTEGRADO_DB_UPDATE_1()
        {
            /*" -1255- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET NUM_CARNE = 0 WHERE CURRENT OF CSEGURAVG END-EXEC. */

            var m_1000_JA_INTEGRADO_DB_UPDATE_1_Update1 = new M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1(CSEGURAVG)
            {
            };

            M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1.Execute(m_1000_JA_INTEGRADO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-5 */
        public void M_1000_COBERTURAS_DB_SELECT_5()
        {
            /*" -939- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :CIMP-SEGURADA-IP, :CFATOR-MULTIPLICA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V1SEGV-ITEM AND OCORHIST = :V1SEGV-OCORHIST AND RAMOFR = 81 AND MODALIFR >= 0 AND COD_COBERTURA = 02 END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_5_Query1 = new M_1000_COBERTURAS_DB_SELECT_5_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_5_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_IP, CIMP_SEGURADA_IP);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-4 */
        public void M_1000_PROCESSA_DB_SELECT_4()
        {
            /*" -717- EXEC SQL SELECT OPCAOCAP, COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, DIA_DEBITO INTO :V0CCOR-OPCAOCAP:V0CCOR-OPCAOCAP-I, :V0CCOR-COD-AGENCIA, :V0CCOR-NUM-CTA-CORRENTE, :V0CCOR-DAC-CTA-CORRENTE, :V0CCOR-DIA-DEBITO:V0CCOR-DIA-DEBITO-I FROM SEGUROS.V0CONTACOR WHERE NUM_CERTIFICADO = :V1SEGV-NRCERTIF END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_4_Query1 = new M_1000_PROCESSA_DB_SELECT_4_Query1()
            {
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_4_Query1.Execute(m_1000_PROCESSA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CCOR_OPCAOCAP, V0CCOR_OPCAOCAP);
                _.Move(executed_1.V0CCOR_OPCAOCAP_I, V0CCOR_OPCAOCAP_I);
                _.Move(executed_1.V0CCOR_COD_AGENCIA, V0CCOR_COD_AGENCIA);
                _.Move(executed_1.V0CCOR_NUM_CTA_CORRENTE, V0CCOR_NUM_CTA_CORRENTE);
                _.Move(executed_1.V0CCOR_DAC_CTA_CORRENTE, V0CCOR_DAC_CTA_CORRENTE);
                _.Move(executed_1.V0CCOR_DIA_DEBITO, V0CCOR_DIA_DEBITO);
                _.Move(executed_1.V0CCOR_DIA_DEBITO_I, V0CCOR_DIA_DEBITO_I);
            }


        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-6 */
        public void M_1000_COBERTURAS_DB_SELECT_6()
        {
            /*" -973- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :CIMP-SEGURADA-AMDS, :CFATOR-MULTIPLICA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V1SEGV-ITEM AND OCORHIST = :V1SEGV-OCORHIST AND RAMOFR = 81 AND MODALIFR >= 0 AND COD_COBERTURA = 03 END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_6_Query1 = new M_1000_COBERTURAS_DB_SELECT_6_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_6_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_AMDS, CIMP_SEGURADA_AMDS);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -1265- IF AC-L-COMMIT > 4999 */

            if (WS_WORK_AREAS.AC_L_COMMIT > 4999)
            {

                /*" -1266- MOVE ZEROS TO AC-L-COMMIT */
                _.Move(0, WS_WORK_AREAS.AC_L_COMMIT);

                /*" -1267- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -1268- DISPLAY '*** COMMIT ' WS-TIME ' ' V1SEGV-NRCERTIF */

                $"*** COMMIT {WS_WORK_AREAS.WS_TIME} {V1SEGV_NRCERTIF}"
                .Display();

                /*" -1268- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();
            }


            /*" -1270- PERFORM 0910-FETCH-SEGURAVG. */

            M_0910_FETCH_SEGURAVG_SECTION();

        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-7 */
        public void M_1000_COBERTURAS_DB_SELECT_7()
        {
            /*" -1006- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :CIMP-SEGURADA-DH, :CFATOR-MULTIPLICA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V1SEGV-ITEM AND OCORHIST = :V1SEGV-OCORHIST AND RAMOFR = 81 AND MODALIFR >= 0 AND COD_COBERTURA = 04 END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_7_Query1 = new M_1000_COBERTURAS_DB_SELECT_7_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_7_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_DH, CIMP_SEGURADA_DH);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-8 */
        public void M_1000_COBERTURAS_DB_SELECT_8()
        {
            /*" -1039- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :CIMP-SEGURADA-DIT, :CFATOR-MULTIPLICA FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V1SEGV-ITEM AND OCORHIST = :V1SEGV-OCORHIST AND RAMOFR = 81 AND MODALIFR >= 0 AND COD_COBERTURA = 05 END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_8_Query1 = new M_1000_COBERTURAS_DB_SELECT_8_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1SEGV_ITEM = V1SEGV_ITEM.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_8_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CIMP_SEGURADA_DIT, CIMP_SEGURADA_DIT);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-2000-INSERT-PROPOSTAVA-SECTION */
        private void M_2000_INSERT_PROPOSTAVA_SECTION()
        {
            /*" -1280- IF V0PROPAZ-AGENCIA = ZEROS */

            if (V0PROPAZ_AGENCIA == 00)
            {

                /*" -1281- IF V0CCOR-COD-AGENCIA = ZEROS */

                if (V0CCOR_COD_AGENCIA == 00)
                {

                    /*" -1282- MOVE ZEROS TO V0PROP-AGECOBR */
                    _.Move(0, V0PROP_AGECOBR);

                    /*" -1283- ELSE */
                }
                else
                {


                    /*" -1284- MOVE V0CCOR-COD-AGENCIA TO V0PROP-AGECOBR */
                    _.Move(V0CCOR_COD_AGENCIA, V0PROP_AGECOBR);

                    /*" -1285- ELSE */
                }

            }
            else
            {


                /*" -1288- MOVE V0PROPAZ-AGENCIA TO V0PROP-AGECOBR. */
                _.Move(V0PROPAZ_AGENCIA, V0PROP_AGECOBR);
            }


            /*" -1290- MOVE 'INSERT V0PROPOSTAVA' TO COMANDO. */
            _.Move("INSERT V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1400- PERFORM M_2000_INSERT_PROPOSTAVA_DB_INSERT_1 */

            M_2000_INSERT_PROPOSTAVA_DB_INSERT_1();

            /*" -1403- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1404- IF SQLCODE EQUAL -180 */

                if (DB.SQLCODE == -180)
                {

                    /*" -1405- DISPLAY 'DATA INVALIDA NO INSERT DA PROPOSTAVA ' */
                    _.Display($"DATA INVALIDA NO INSERT DA PROPOSTAVA ");

                    /*" -1406- DISPLAY 'CERTIF ' V1SEGV-NRCERTIF */
                    _.Display($"CERTIF {V1SEGV_NRCERTIF}");

                    /*" -1407- DISPLAY 'DTINIV ' V1SEGV-DTINIVIG */
                    _.Display($"DTINIV {V1SEGV_DTINIVIG}");

                    /*" -1408- DISPLAY 'DTMOVT ' V1HSEG-DTMOVTO */
                    _.Display($"DTMOVT {V1HSEG_DTMOVTO}");

                    /*" -1409- DISPLAY 'PROX   ' HOST-DTPROXVEN */
                    _.Display($"PROX   {HOST_DTPROXVEN}");

                    /*" -1410- DISPLAY 'VENCTO ' HOST-DTVENCTO */
                    _.Display($"VENCTO {HOST_DTVENCTO}");

                    /*" -1411- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1412- ELSE */
                }
                else
                {


                    /*" -1414- DISPLAY 'PROBLEMA INSERT DA V0PROPOSTAVA ..' V1SEGV-NRCERTIF ' ' SQLCODE */

                    $"PROBLEMA INSERT DA V0PROPOSTAVA ..{V1SEGV_NRCERTIF} {DB.SQLCODE}"
                    .Display();

                    /*" -1416- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1416- ADD 1 TO AC-I-PROPOSTAVA. */
            WS_WORK_AREAS.AC_I_PROPOSTAVA.Value = WS_WORK_AREAS.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" M-2000-INSERT-PROPOSTAVA-DB-INSERT-1 */
        public void M_2000_INSERT_PROPOSTAVA_DB_INSERT_1()
        {
            /*" -1400- EXEC SQL INSERT INTO SEGUROS.V0PROPOSTAVA (NRCERTIF, CODPRODU, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTQITBCO, AGECTAVEN, OPRCTAVEN, NUMCTAVEN, DIGCTAVEN, NRMATRVEN, CODOPER, PROFISSAO, DTINCLUS, DTMOVTO, SITUACAO, NUM_APOLICE, CODSUBES, OCORHIST, NRPRIPARATZ, QTDPARATZ, DTPROXVEN, NRPARCE, DTVENCTO, SIT_INTERFACE, DTFENAE, CODUSU, TIMESTAMP, IDADE, IDE_SEXO, ESTADO_CIVIL, OPCAO_MARCADA, SIGLA_CRM, COD_CRM, APOS_INVALIDEZ, ASSINATURA, ACATAMENTO, NOME_ESPOSA, DTNASC_ESPOSA, PROFIS_ESPOSA, DPS_TITULAR, DPS_ESPOSA, NUM_MATRICULA, GRAU_PARENTESCO, DATA_ADMISSAO, NRPROPOS, EM_ATIVIDADE, LOC_ATIVIDADE, INFO_COMPLEMENTAR, NRMALADIR, NRCERTIFANT, COD_CCT) VALUES (:V1SEGV-NRCERTIF, :V0PROD-CODPRODU, :V1SEGV-CODCLI, :V1SEGV-OCORR-END, :V1SEGV-FONTE, :V0PROP-AGECOBR, ' ' , :V1SEGV-DTINIVIG, 0, 0, 0, 0, 0, :V1HSEG-CODOPER, ' ' , :V1SEGV-DTINIVIG, :V1HSEG-DTMOVTO, '3' , :V1SEGV-NUM-APOLICE, :V1SEGV-COD-SUBGRUPO, :V1SEGV-OCORHIST, 0, 0, :HOST-DTPROXVEN, :V1SEGV-NUM-CARNE, :HOST-DTVENCTO, ' ' , '9999-12-31' , 'VA0010B' , CURRENT TIMESTAMP, :HOST-IDADE, :V1SEGV-IDE-SEXO, :V1SEGV-EST-CIVIL, ' ' , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, :V1SEGV-NRPROPOS, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var m_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 = new M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1()
            {
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
                V0PROD_CODPRODU = V0PROD_CODPRODU.ToString(),
                V1SEGV_CODCLI = V1SEGV_CODCLI.ToString(),
                V1SEGV_OCORR_END = V1SEGV_OCORR_END.ToString(),
                V1SEGV_FONTE = V1SEGV_FONTE.ToString(),
                V0PROP_AGECOBR = V0PROP_AGECOBR.ToString(),
                V1SEGV_DTINIVIG = V1SEGV_DTINIVIG.ToString(),
                V1HSEG_CODOPER = V1HSEG_CODOPER.ToString(),
                V1HSEG_DTMOVTO = V1HSEG_DTMOVTO.ToString(),
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1SEGV_COD_SUBGRUPO = V1SEGV_COD_SUBGRUPO.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                HOST_DTPROXVEN = HOST_DTPROXVEN.ToString(),
                V1SEGV_NUM_CARNE = V1SEGV_NUM_CARNE.ToString(),
                HOST_DTVENCTO = HOST_DTVENCTO.ToString(),
                HOST_IDADE = HOST_IDADE.ToString(),
                V1SEGV_IDE_SEXO = V1SEGV_IDE_SEXO.ToString(),
                V1SEGV_EST_CIVIL = V1SEGV_EST_CIVIL.ToString(),
                V1SEGV_NRPROPOS = V1SEGV_NRPROPOS.ToString(),
            };

            M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1.Execute(m_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-9 */
        public void M_1000_COBERTURAS_DB_SELECT_9()
        {
            /*" -1105- EXEC SQL SELECT QTTITCAP INTO :PLACAP-QTTITCAP FROM SEGUROS.V0PLACAPVG WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND CODSUBES = :V1SEGV-COD-SUBGRUPO AND DTINIVIG <= :V1HSEG-DTMOVTO AND DTTERVIG >= :V1HSEG-DTMOVTO AND IMPSEGINI <= :CIMP-SEGURADA-VG AND IMPSEGFIM >= :CIMP-SEGURADA-VG END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_9_Query1 = new M_1000_COBERTURAS_DB_SELECT_9_Query1()
            {
                V1SEGV_COD_SUBGRUPO = V1SEGV_COD_SUBGRUPO.ToString(),
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                CIMP_SEGURADA_VG = CIMP_SEGURADA_VG.ToString(),
                V1HSEG_DTMOVTO = V1HSEG_DTMOVTO.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_9_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLACAP_QTTITCAP, PLACAP_QTTITCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-1000-COBERTURAS-DB-SELECT-10 */
        public void M_1000_COBERTURAS_DB_SELECT_10()
        {
            /*" -1126- EXEC SQL SELECT VLCUSTCAP INTO :CUSTCAP-VLCUSTCAP FROM SEGUROS.V0CUSTOCAPVG WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE AND CODSUBES = :V1SEGV-COD-SUBGRUPO AND DTINIVIG <= :V1HSEG-DTMOVTO AND DTTERVIG >= :V1HSEG-DTMOVTO END-EXEC. */

            var m_1000_COBERTURAS_DB_SELECT_10_Query1 = new M_1000_COBERTURAS_DB_SELECT_10_Query1()
            {
                V1SEGV_COD_SUBGRUPO = V1SEGV_COD_SUBGRUPO.ToString(),
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
                V1HSEG_DTMOVTO = V1HSEG_DTMOVTO.ToString(),
            };

            var executed_1 = M_1000_COBERTURAS_DB_SELECT_10_Query1.Execute(m_1000_COBERTURAS_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CUSTCAP_VLCUSTCAP, CUSTCAP_VLCUSTCAP);
            }


        }

        [StopWatch]
        /*" M-2100-INSERT-COBERPROPVA-SECTION */
        private void M_2100_INSERT_COBERPROPVA_SECTION()
        {
            /*" -1426- MOVE 'INS V0COBERPROPVA ' TO COMANDO. */
            _.Move("INS V0COBERPROPVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1427- IF CIMP-SEGURADA-VG = ZEROS */

            if (CIMP_SEGURADA_VG == 00)
            {

                /*" -1429- MOVE CIMP-SEGURADA-AP TO HOST-IMPSEGIND HOST-IMPSEGUR */
                _.Move(CIMP_SEGURADA_AP, HOST_IMPSEGIND, HOST_IMPSEGUR);

                /*" -1430- ELSE */
            }
            else
            {


                /*" -1433- MOVE CIMP-SEGURADA-VG TO HOST-IMPSEGIND HOST-IMPSEGUR. */
                _.Move(CIMP_SEGURADA_VG, HOST_IMPSEGIND, HOST_IMPSEGUR);
            }


            /*" -1434- IF CIMP-SEGURADA-IP = ZEROS */

            if (CIMP_SEGURADA_IP == 00)
            {

                /*" -1436- MOVE CIMP-SEGURADA-IPA TO CIMP-SEGURADA-IP. */
                _.Move(CIMP_SEGURADA_IPA, CIMP_SEGURADA_IP);
            }


            /*" -1437- IF V0PROD-TEM-CDG = 'N' */

            if (V0PROD_TEM_CDG == "N")
            {

                /*" -1439- MOVE ZEROS TO V0PLAN-IMPSEGCDG V0PLAN-VLCUSTCDG */
                _.Move(0, V0PLAN_IMPSEGCDG, V0PLAN_VLCUSTCDG);

                /*" -1440- ELSE */
            }
            else
            {


                /*" -1441- MOVE HOST-IMPSEGCDG TO V0PLAN-IMPSEGCDG */
                _.Move(HOST_IMPSEGCDG, V0PLAN_IMPSEGCDG);

                /*" -1443- MOVE HOST-VLCUSTCDG TO V0PLAN-VLCUSTCDG. */
                _.Move(HOST_VLCUSTCDG, V0PLAN_VLCUSTCDG);
            }


            /*" -1474- PERFORM M_2100_INSERT_COBERPROPVA_DB_INSERT_1 */

            M_2100_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -1477- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1479- DISPLAY '2100 - PROBLEMA INSERT V0COBERPROPVA        ..' V1SEGV-NRCERTIF ' ' SQLCODE */

                $"2100 - PROBLEMA INSERT V0COBERPROPVA        ..{V1SEGV_NRCERTIF} {DB.SQLCODE}"
                .Display();

                /*" -1481- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1481- ADD 1 TO AC-I-COBERPROPVA. */
            WS_WORK_AREAS.AC_I_COBERPROPVA.Value = WS_WORK_AREAS.AC_I_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" M-2100-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void M_2100_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -1474- EXEC SQL INSERT INTO SEGUROS.V0COBERPROPVA VALUES (:V1SEGV-NRCERTIF, :V1SEGV-OCORHIST, :V1HSEG-DTMOVTO, '9999-12-31' , :HOST-IMPSEGUR, 1, :HOST-IMPSEGIND, :V1HSEG-CODOPER, ' ' , :CIMP-SEGURADA-VG, :CIMP-SEGURADA-AP, :CIMP-SEGURADA-IP, 0, 0, 0, :VLPREMIO, :PRMVG, :PRMAP, :HOST-QTTITCAP, :HOST-VLTITCAP, :HOST-VLCUSCAP, :V0PLAN-IMPSEGCDG, :V0PLAN-VLCUSTCDG, 'VA0010B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
                V1SEGV_OCORHIST = V1SEGV_OCORHIST.ToString(),
                V1HSEG_DTMOVTO = V1HSEG_DTMOVTO.ToString(),
                HOST_IMPSEGUR = HOST_IMPSEGUR.ToString(),
                HOST_IMPSEGIND = HOST_IMPSEGIND.ToString(),
                V1HSEG_CODOPER = V1HSEG_CODOPER.ToString(),
                CIMP_SEGURADA_VG = CIMP_SEGURADA_VG.ToString(),
                CIMP_SEGURADA_AP = CIMP_SEGURADA_AP.ToString(),
                CIMP_SEGURADA_IP = CIMP_SEGURADA_IP.ToString(),
                VLPREMIO = VLPREMIO.ToString(),
                PRMVG = PRMVG.ToString(),
                PRMAP = PRMAP.ToString(),
                HOST_QTTITCAP = HOST_QTTITCAP.ToString(),
                HOST_VLTITCAP = HOST_VLTITCAP.ToString(),
                HOST_VLCUSCAP = HOST_VLCUSCAP.ToString(),
                V0PLAN_IMPSEGCDG = V0PLAN_IMPSEGCDG.ToString(),
                V0PLAN_VLCUSTCDG = V0PLAN_VLCUSTCDG.ToString(),
            };

            M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/

        [StopWatch]
        /*" M-2400-INSERT-OPCAOPAGVA-SECTION */
        private void M_2400_INSERT_OPCAOPAGVA_SECTION()
        {
            /*" -1492- MOVE 'INSERT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("INSERT V0OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1519- PERFORM M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1 */

            M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1();

            /*" -1522- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1524- DISPLAY '2400 - PROBLEMA INSERT DA V0OPCAOPAGVA ..' V1SEGV-NRCERTIF ' ' SQLCODE */

                $"2400 - PROBLEMA INSERT DA V0OPCAOPAGVA ..{V1SEGV_NRCERTIF} {DB.SQLCODE}"
                .Display();

                /*" -1526- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1526- ADD 1 TO AC-I-OPCAOPAGVA. */
            WS_WORK_AREAS.AC_I_OPCAOPAGVA.Value = WS_WORK_AREAS.AC_I_OPCAOPAGVA + 1;

        }

        [StopWatch]
        /*" M-2400-INSERT-OPCAOPAGVA-DB-INSERT-1 */
        public void M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1()
        {
            /*" -1519- EXEC SQL INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB) VALUES (:V1SEGV-NRCERTIF, :V1SEGV-DTINIVIG, '9999-12-31' , :HOST-OPCAOPAG, :HOST-PERIPGTO, :V0CCOR-DIA-DEBITO, 'VA0010B' , CURRENT TIMESTAMP, :V0CCOR-COD-AGENCIA:HOST-IND, :HOST-OPRCTADEB:HOST-IND, :HOST-NUMCTADEB:HOST-IND, :HOST-DIGCTADEB:HOST-IND) END-EXEC. */

            var m_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 = new M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1()
            {
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
                V1SEGV_DTINIVIG = V1SEGV_DTINIVIG.ToString(),
                HOST_OPCAOPAG = HOST_OPCAOPAG.ToString(),
                HOST_PERIPGTO = HOST_PERIPGTO.ToString(),
                V0CCOR_DIA_DEBITO = V0CCOR_DIA_DEBITO.ToString(),
                V0CCOR_COD_AGENCIA = V0CCOR_COD_AGENCIA.ToString(),
                HOST_IND = HOST_IND.ToString(),
                HOST_OPRCTADEB = HOST_OPRCTADEB.ToString(),
                HOST_NUMCTADEB = HOST_NUMCTADEB.ToString(),
                HOST_DIGCTADEB = HOST_DIGCTADEB.ToString(),
            };

            M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1.Execute(m_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2400_FIM*/

        [StopWatch]
        /*" M-2500-INSERT-CDGCOBER-SECTION */
        private void M_2500_INSERT_CDGCOBER_SECTION()
        {
            /*" -1535- IF V1SEGV-NUM-CARNE < 7 */

            if (V1SEGV_NUM_CARNE < 7)
            {

                /*" -1537- GO TO 2500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/ //GOTO
                return;
            }


            /*" -1539- MOVE 'SELECT V0CDGCOBER  ' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1550- PERFORM M_2500_INSERT_CDGCOBER_DB_SELECT_1 */

            M_2500_INSERT_CDGCOBER_DB_SELECT_1();

            /*" -1553- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1555- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1556- ELSE */
                }
                else
                {


                    /*" -1558- DISPLAY '2500 - PROBLEMA INSERT DA V0CDGCOBER ....' V1SEGV-NRCERTIF ' ' SQLCODE */

                    $"2500 - PROBLEMA INSERT DA V0CDGCOBER ....{V1SEGV_NRCERTIF} {DB.SQLCODE}"
                    .Display();

                    /*" -1559- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1560- ELSE */
                }

            }
            else
            {


                /*" -1562- GO TO 2500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/ //GOTO
                return;
            }


            /*" -1564- MOVE 'INSERT V0CDGCOBER  ' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1576- PERFORM M_2500_INSERT_CDGCOBER_DB_INSERT_1 */

            M_2500_INSERT_CDGCOBER_DB_INSERT_1();

            /*" -1579- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1580- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1581- GO TO 2500-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/ //GOTO
                    return;

                    /*" -1582- ELSE */
                }
                else
                {


                    /*" -1584- DISPLAY '2500 - PROBLEMA INSERT DA V0CDGCOBER ....' V1SEGV-NRCERTIF ' ' SQLCODE */

                    $"2500 - PROBLEMA INSERT DA V0CDGCOBER ....{V1SEGV_NRCERTIF} {DB.SQLCODE}"
                    .Display();

                    /*" -1586- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1586- ADD 1 TO AC-I-CDGCOBER. */
            WS_WORK_AREAS.AC_I_CDGCOBER.Value = WS_WORK_AREAS.AC_I_CDGCOBER + 1;

        }

        [StopWatch]
        /*" M-2500-INSERT-CDGCOBER-DB-SELECT-1 */
        public void M_2500_INSERT_CDGCOBER_DB_SELECT_1()
        {
            /*" -1550- EXEC SQL SELECT CODCLIEN INTO :V0CDGC-CODCLIEN FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V1SEGV-CODCLI AND DTINIVIG <= :V1SIST-DTMOVABE AND DTTERVIG >= :V1SIST-DTMOVABE END-EXEC. */

            var m_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1 = new M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1SEGV_CODCLI = V1SEGV_CODCLI.ToString(),
            };

            var executed_1 = M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1.Execute(m_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_CODCLIEN, V0CDGC_CODCLIEN);
            }


        }

        [StopWatch]
        /*" M-2500-INSERT-CDGCOBER-DB-INSERT-1 */
        public void M_2500_INSERT_CDGCOBER_DB_INSERT_1()
        {
            /*" -1576- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V1SEGV-CODCLI, :V1SIST-DTMOVABE, '9999-12-31' , :HOST-IMPSEGCDG, :HOST-VLCUSTCDG, :V1SEGV-NRCERTIF, 0, '0' , 'VA0010B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1 = new M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1()
            {
                V1SEGV_CODCLI = V1SEGV_CODCLI.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                HOST_IMPSEGCDG = HOST_IMPSEGCDG.ToString(),
                HOST_VLCUSTCDG = HOST_VLCUSTCDG.ToString(),
                V1SEGV_NRCERTIF = V1SEGV_NRCERTIF.ToString(),
            };

            M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1.Execute(m_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/

        [StopWatch]
        /*" M-3000-00-SELECT-APOLICE-SECTION */
        private void M_3000_00_SELECT_APOLICE_SECTION()
        {
            /*" -1596- MOVE 'SELECT MODALIDADE  ' TO COMANDO. */
            _.Move("SELECT MODALIDADE  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1602- PERFORM M_3000_00_SELECT_APOLICE_DB_SELECT_1 */

            M_3000_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -1605- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1607- DISPLAY '*** VA0010B PROBLEMAS ACESSO APOLICES ' V1SEGV-NUM-APOLICE */
                _.Display($"*** VA0010B PROBLEMAS ACESSO APOLICES {V1SEGV_NUM_APOLICE}");

                /*" -1608- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1609- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3000-00-SELECT-APOLICE-DB-SELECT-1 */
        public void M_3000_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -1602- EXEC SQL SELECT COD_MODALIDADE INTO :WS-APOL-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE WITH UR END-EXEC. */

            var m_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                V1SEGV_NUM_APOLICE = V1SEGV_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(m_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_APOL_COD_MODALIDADE, WS_APOL_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_99_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -1620- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1621- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1622- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1623- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1629- DISPLAY V1SEGV-NRCERTIF ' ' V1SEGV-ITEM ' ' V1SEGV-CODCLI ' ' V1SEGV-OCORHIST ' ' V1SEGV-MATRICULA ' ' . */

            $"{V1SEGV_NRCERTIF} {V1SEGV_ITEM} {V1SEGV_CODCLI} {V1SEGV_OCORHIST} {V1SEGV_MATRICULA} "
            .Display();

            /*" -1631- DISPLAY '*** VA0010B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0010B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1631- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1634- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1635- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1635- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1639- DISPLAY '*** VA0010B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0010B *** ERRO DE EXECUCAO");

            /*" -1640- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1640- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/
    }
}