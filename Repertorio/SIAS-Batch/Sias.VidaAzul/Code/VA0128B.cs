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
using Sias.VidaAzul.DB2.VA0128B;

namespace Code
{
    public class VA0128B
    {
        public bool IsCall { get; set; }

        public VA0128B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  EFETUA AUMENTO/REDUCAO - IOF       *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FREDERICO FONSECA.                 *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0128B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  26/08/2004                         *      */
        /*"      *                                                                *      */
        /*"      *   ALTERA OS PREMIOS DOS PRODUTOS VIDA CUJO PREMIO E PAGO INTE- *      */
        /*"      *   GRALMENTE PELO SEGURADO.                                     *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *          A L T E R A C O E    E F E T U A D A S                *      */
        /*"      ******************************************************************      */
        /*"      * 10/07/2006                        LUCIA VIEIRA                 *      */
        /*"      *      V.01  CORRIGE ABEND - SQLCODE 100 NA SEGUROS.V0SEGURAVG   *      */
        /*"      *                            SOLUCAO: VOLTA LER OUTRO            *      */
        /*"      * PROCURAR POR V.01                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  V0RIND-DATA-BASE                 PIC  X(10).*/
        public StringBasis V0RIND_DATA_BASE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RIND-DTMOVTO                   PIC  X(10).*/
        public StringBasis V0RIND_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RIND-DTMOVTO-1DAY              PIC  X(10).*/
        public StringBasis V0RIND_DTMOVTO_1DAY { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RIND-PCIOF-ATU                 PIC S9(03)V99.*/
        public DoubleBasis V0RIND_PCIOF_ATU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99."), 2);
        /*"01  V0RIND-PCIOF-ANT                 PIC S9(03)V99.*/
        public DoubleBasis V0RIND_PCIOF_ANT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99."), 2);
        /*"01  PCIOF-ATU-DET                    PIC -9(03),99.*/
        public DoubleBasis PCIOF_ATU_DET { get; set; } = new DoubleBasis(new PIC("-9", "3", "-9(03)V99."), 2);
        /*"01  PCIOF-ANT-DET                    PIC -9(03),99.*/
        public DoubleBasis PCIOF_ANT_DET { get; set; } = new DoubleBasis(new PIC("-9", "3", "-9(03)V99."), 2);
        /*"01  VALOR-DET                        PIC -------------9,99.*/
        public DoubleBasis VALOR_DET { get; set; } = new DoubleBasis(new PIC("9", "14", "-------------9V99."), 2);
        /*"01  INDAGE                           PIC S9(4) COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDOPR                           PIC S9(4) COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDNUM                           PIC S9(4) COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDDIG                           PIC S9(4) COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-CDG                     PIC S9(4) COMP.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-SAF                     PIC S9(4) COMP.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-IGPM                    PIC S9(4) COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RESIDUO                          PIC S9(4)V99 VALUE ZEROS.*/
        public DoubleBasis RESIDUO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V99"), 2);
        /*"01  QUOCIENTE                        PIC  9(4) VALUE ZEROS.*/
        public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  RESTO                            PIC  9(4) VALUE ZEROS.*/
        public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  TEM-VG                           PIC  X(1).*/
        public StringBasis TEM_VG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  TEM-AP                           PIC  X(1).*/
        public StringBasis TEM_AP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  TEM-IP                           PIC  X(1).*/
        public StringBasis TEM_IP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  TEM-DIT                          PIC  X(1).*/
        public StringBasis TEM_DIT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  TEM-ERRO-COBER                   PIC  X(1).*/
        public StringBasis TEM_ERRO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRPROPAZ                  PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODCLIEN                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-OCOREND                   PIC S9(04) COMP.*/
        public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-FONTE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-AGECOBR                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OPCAO-COBER               PIC  X(1).*/
        public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTPROXVEN                 PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-DTMOVTO                   PIC  X(10).*/
        public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OCORHIST                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SIT-INTERF                PIC  X(1).*/
        public StringBasis PROPVA_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-TIMESTAMP                 PIC  X(26).*/
        public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  PROPVA-SEXO                      PIC  X(1).*/
        public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-EST-CIV                   PIC  X(1).*/
        public StringBasis PROPVA_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTQITBCO-1YEAR            PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-IDADE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-OPCAOPAG                  PIC  X(1).*/
        public StringBasis OPCAOP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  OPCAOP-PERIPGTO                  PIC S9(4) COMP.*/
        public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-AGECTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-OPRCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-NUMCTADEB                 PIC S9(13) COMP-3.*/
        public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  OPCAOP-DIGCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  HISCOBPR-DTINIVIG-1DAY           PIC  X(10).*/
        public StringBasis HISCOBPR_DTINIVIG_1DAY { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DATA-MOVIMENTO                   PIC  X(10).*/
        public StringBasis DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COD-OPERACAO                     PIC S9(04)    COMP.*/
        public IntBasis COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis COBERP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  COBERP-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis COBERP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-OCORHIST-ANT              PIC S9(04)    COMP.*/
        public IntBasis COBERP_OCORHIST_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IMPSEGUR                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-QUANT-VIDAS               PIC S9(09)    COMP.*/
        public IntBasis COBERP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  COBERP-IMPSEGIND                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis COBERP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-OPCAO-COBER               PIC  X(01).*/
        public StringBasis COBERP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  COBERP-IMPMORNATU-ANT            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID-ANT            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM-ANT            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS-ANT               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH-ANT                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT-ANT                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO-ANT              PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-ANT                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-ANT                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMDIT-ANT                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMDIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORNATU-ATU            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID-ATU            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM-ATU            PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS-ATU               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH-ATU                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT-ATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO-ATU              PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-ATU                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-ATU                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMDIT-ATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMDIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMDIT-I                  PIC S9(004)      COMP.*/
        public IntBasis COBERP_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  COBERP-QTTITCAP                  PIC S9(04)    COMP.*/
        public IntBasis COBERP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-VLTITCAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF-I              PIC S9(004)      COMP.*/
        public IntBasis COBERP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  COBERP-VLCUSTAUXF-I              PIC S9(004)      COMP.*/
        public IntBasis COBERP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  COBERP-QTDIT                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_QTDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-QTDIT-I                   PIC S9(004)      COMP.*/
        public IntBasis COBERP_QTDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  COBERP-DTTERVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTTERVIG-ANT              PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG-ANT              PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG-NEW              PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG_NEW { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  VGHISR-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis VGHISR_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  VGHISR-NUM-RAMO                  PIC S9(04)    COMP.*/
        public IntBasis VGHISR_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISR-NUM-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGHISR_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISR-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGHISR_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISR-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGHISR_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISR-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGHISR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISR-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGHISR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISR-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGHISR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  VGHISA-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis VGHISA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  VGHISA-NUM-ACESSORIO             PIC S9(04)    COMP.*/
        public IntBasis VGHISA_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISA-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGHISA_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGHISA-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGHISA_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISA-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGHISA_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGHISA-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGHISA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PRODVG-ESTR-COBR                 PIC  X(10).*/
        public StringBasis PRODVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis PRODVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis PRODVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis PRODVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-TEM-IGPM                  PIC  X(01).*/
        public StringBasis PRODVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-COBERADIC-PREMIO          PIC  X(01).*/
        public StringBasis PRODVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis PRODVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-RAMO                      PIC S9(04) COMP.*/
        public IntBasis PRODVG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SEGURA-NUM-ITEM                  PIC S9(09) COMP.*/
        public IntBasis SEGURA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  SEGURA-DTINIVIG                  PIC  X(10).*/
        public StringBasis SEGURA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SEGURA-SIT-REGISTRO              PIC  X(01).*/
        public StringBasis SEGURA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  SEGURA-DTNASC-I                  PIC S9(04) COMP.*/
        public IntBasis SEGURA_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SEGURA-FAIXA                     PIC S9(04) COMP.*/
        public IntBasis SEGURA_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SEGURA-TXVG                      PIC  S9(003)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  SEGURA-TXAPMA                    PIC  S9(003)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  SEGURA-TXAPIP                    PIC  S9(003)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  SEGURA-TXAPAMDS                  PIC  S9(003)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  SEGURA-TXAPDH                    PIC  S9(003)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPDH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  SEGURA-TXAPDIT                   PIC  S9(003)V9(4) COMP-3.*/
        public DoubleBasis SEGURA_TXAPDIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  SEGURA-LOT-EMP-SEGURADO          PIC   X(030).*/
        public StringBasis SEGURA_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"01  SEGURA-OCORHIST                  PIC S9(04) COMP.*/
        public IntBasis SEGURA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WLOT-EMP-SEGURADO                PIC S9(04) COMP.*/
        public IntBasis WLOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISTSG-DTMOVTO-ANT               PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO                   PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO-1DAY              PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_1DAY { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO-DTTERVIG          PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-OCORHIST                  PIC S9(04) COMP.*/
        public IntBasis HISTSG_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISTSG-CODOPER                   PIC S9(04) COMP.*/
        public IntBasis HISTSG_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CLIENT-DTNASC                    PIC  X(10).*/
        public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I                  PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FONTE-PROPAUTOM                  PIC S9(009) COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SISTEMA-DTMOVABE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRENT                  PIC  X(010).*/
        public StringBasis SISTEMA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMAXALTIGPM             PIC  X(010).*/
        public StringBasis SISTEMA_DTMAXALTIGPM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTTERCOT                 PIC  X(010).*/
        public StringBasis SISTEMA_DTTERCOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTINICOT                 PIC  X(010).*/
        public StringBasis SISTEMA_DTINICOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOV01M                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOV01M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MNUM-CTA-CORRENTE                PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  MDAC-CTA-CORRENTE                PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  COTACAO-DTINIVIG                 PIC  X(10).*/
        public StringBasis COTACAO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COTACAO-VAL-VENDA                PIC S9(006)V9(09) COMP-3.*/
        public DoubleBasis COTACAO_VAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
        /*"01  MOVTO-LIDOS                      PIC S9(009)       COMP.*/
        public IntBasis MOVTO_LIDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  MOVTO-DTALTIGPM                  PIC  X(010).*/
        public StringBasis MOVTO_DTALTIGPM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  FATFIL-NUM-FATURA                PIC S9(009)       COMP.*/
        public IntBasis FATFIL_NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  01        PARAMETROS.*/
        public VA0128B_PARAMETROS PARAMETROS { get; set; } = new VA0128B_PARAMETROS();
        public class VA0128B_PARAMETROS : VarBasis
        {
            /*"    10      LK710-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK710_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK710-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK710_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK710_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-NASCIMENTO.*/
            public VA0128B_LK710_NASCIMENTO LK710_NASCIMENTO { get; set; } = new VA0128B_LK710_NASCIMENTO();
            public class VA0128B_LK710_NASCIMENTO : VarBasis
            {
                /*"      15 LK710-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK710_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      LK710-SALARIO               PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK710_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-INV-POR-ACIDENTE   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-RETURN-CODE           PIC S9(03) COMP-3.*/
            public IntBasis LK710_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK710-MENSAGEM              PIC  X(77).*/
            public StringBasis LK710_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01          PARAMETROS-702.*/
        }
        public VA0128B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VA0128B_PARAMETROS_702();
        public class VA0128B_PARAMETROS_702 : VarBasis
        {
            /*"    10      LK-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK-NASCIMENTO.*/
            public VA0128B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VA0128B_LK_NASCIMENTO();
            public class VA0128B_LK_NASCIMENTO : VarBasis
            {
                /*"      15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-RETURN-CODE           PIC S9(03) COMP.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK-MENSAGEM              PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01  WS-WORK-AREAS.*/
        }
        public VA0128B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0128B_WS_WORK_AREAS();
        public class VA0128B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOC                       PIC X VALUE SPACES.*/
            public StringBasis WS_EOC { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WPROCESSA                    PIC X VALUE SPACES.*/
            public StringBasis WPROCESSA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WS-TEVE-ALTERACAO            PIC 9 VALUE 0.*/
            public IntBasis WS_TEVE_ALTERACAO { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WFIM-VGHISRAMC               PIC X VALUE SPACES.*/
            public StringBasis WFIM_VGHISRAMC { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WFIM-VGHISTACE               PIC X VALUE SPACES.*/
            public StringBasis WFIM_VGHISTACE { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WIND-1                       PIC 9(3) VALUE 0.*/
            public IntBasis WIND_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"));
            /*"    03  WS-IND                       PIC 9(3) VALUE 0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"));
            /*"    03  INF                          PIC 9(3) VALUE 0.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"));
            /*"    03  SUP                          PIC 9(3) VALUE 0.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"));
            /*"    03  WS-IGPM-ACUM                 PIC S9(6)V9(9) COMP-3.*/
            public DoubleBasis WS_IGPM_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"    03  WS-IGPM-ACUM-DISPLAY         PIC ZZZ.ZZ9,999999999.*/
            public DoubleBasis WS_IGPM_ACUM_DISPLAY { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V999999999."), 9);
            /*"    03  WS-PRMADIC                   PIC S9(13)V99  COMP-3.*/
            public DoubleBasis WS_PRMADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WS-GUARDA-PRMADIC            PIC S9(13)V99  COMP-3.*/
            public DoubleBasis WS_GUARDA_PRMADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W01A0100.*/
            public VA0128B_W01A0100 W01A0100 { get; set; } = new VA0128B_W01A0100();
            public class VA0128B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03     TABELA-ULTIMOS-DIAS.*/
            public VA0128B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA0128B_TABELA_ULTIMOS_DIAS();
            public class VA0128B_TABELA_ULTIMOS_DIAS : VarBasis
            {
                /*"       05  FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                /*"    03     TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
            }
            private _REDEF_VA0128B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
            public _REDEF_VA0128B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
            {
                get { _tab_ultimos_dias = new _REDEF_VA0128B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
                set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
            }  //Redefines
            public class _REDEF_VA0128B_TAB_ULTIMOS_DIAS : VarBasis
            {
                /*"       05  TAB-DIA-MESES        OCCURS 12.*/
                public ListBasis<VA0128B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA0128B_TAB_DIA_MESES>(12);
                public class VA0128B_TAB_DIA_MESES : VarBasis
                {
                    /*"           10 TAB-ULT-DIA       PIC 9(002).*/
                    public IntBasis TAB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    03 W01DTSQL.*/

                    public VA0128B_TAB_DIA_MESES()
                    {
                        TAB_ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0128B_TAB_ULTIMOS_DIAS()
                {
                    TAB_DIA_MESES.ValueChanged += OnValueChanged;
                }

            }
            public VA0128B_W01DTSQL W01DTSQL { get; set; } = new VA0128B_W01DTSQL();
            public class VA0128B_W01DTSQL : VarBasis
            {
                /*"       05  W01AASQL                  PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL                  PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL                  PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL                  PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL                  PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL.*/
            }
            public VA0128B_W02DTSQL W02DTSQL { get; set; } = new VA0128B_W02DTSQL();
            public class VA0128B_W02DTSQL : VarBasis
            {
                /*"       05  W02AASQL                  PIC 9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W02T1SQL                  PIC X(001).*/
                public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02MMSQL                  PIC 9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W02T2SQL                  PIC X(001).*/
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-CTA-CORRENTE-R.*/
            }
            public VA0128B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA0128B_WS_CTA_CORRENTE_R();
            public class VA0128B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"       05 WS-OPER-SEG                PIC  9(004).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA-SEG                 PIC  9(012).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03       WS-DATA-INF             PIC  9(006).*/
            public IntBasis WS_DATA_INF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-INF-R REDEFINES WS-DATA-INF.*/
            private _REDEF_VA0128B_WS_DATA_INF_R _ws_data_inf_r { get; set; }
            public _REDEF_VA0128B_WS_DATA_INF_R WS_DATA_INF_R
            {
                get { _ws_data_inf_r = new _REDEF_VA0128B_WS_DATA_INF_R(); _.Move(WS_DATA_INF, _ws_data_inf_r); VarBasis.RedefinePassValue(WS_DATA_INF, _ws_data_inf_r, WS_DATA_INF); _ws_data_inf_r.ValueChanged += () => { _.Move(_ws_data_inf_r, WS_DATA_INF); }; return _ws_data_inf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_inf_r, WS_DATA_INF); }
            }  //Redefines
            public class _REDEF_VA0128B_WS_DATA_INF_R : VarBasis
            {
                /*"      05     WS-ANO-INF              PIC  9(004).*/
                public IntBasis WS_ANO_INF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-INF              PIC  9(002).*/
                public IntBasis WS_MES_INF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-SUP             PIC  9(006).*/

                public _REDEF_VA0128B_WS_DATA_INF_R()
                {
                    WS_ANO_INF.ValueChanged += OnValueChanged;
                    WS_MES_INF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_SUP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-SUP-R REDEFINES WS-DATA-SUP.*/
            private _REDEF_VA0128B_WS_DATA_SUP_R _ws_data_sup_r { get; set; }
            public _REDEF_VA0128B_WS_DATA_SUP_R WS_DATA_SUP_R
            {
                get { _ws_data_sup_r = new _REDEF_VA0128B_WS_DATA_SUP_R(); _.Move(WS_DATA_SUP, _ws_data_sup_r); VarBasis.RedefinePassValue(WS_DATA_SUP, _ws_data_sup_r, WS_DATA_SUP); _ws_data_sup_r.ValueChanged += () => { _.Move(_ws_data_sup_r, WS_DATA_SUP); }; return _ws_data_sup_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sup_r, WS_DATA_SUP); }
            }  //Redefines
            public class _REDEF_VA0128B_WS_DATA_SUP_R : VarBasis
            {
                /*"      05     WS-ANO-SUP              PIC  9(004).*/
                public IntBasis WS_ANO_SUP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-SUP              PIC  9(002).*/
                public IntBasis WS_MES_SUP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDATA1                  PIC  9(006).*/

                public _REDEF_VA0128B_WS_DATA_SUP_R()
                {
                    WS_ANO_SUP.ValueChanged += OnValueChanged;
                    WS_MES_SUP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDATA1-R REDEFINES WDATA1.*/
            private _REDEF_VA0128B_WDATA1_R _wdata1_r { get; set; }
            public _REDEF_VA0128B_WDATA1_R WDATA1_R
            {
                get { _wdata1_r = new _REDEF_VA0128B_WDATA1_R(); _.Move(WDATA1, _wdata1_r); VarBasis.RedefinePassValue(WDATA1, _wdata1_r, WDATA1); _wdata1_r.ValueChanged += () => { _.Move(_wdata1_r, WDATA1); }; return _wdata1_r; }
                set { VarBasis.RedefinePassValue(value, _wdata1_r, WDATA1); }
            }  //Redefines
            public class _REDEF_VA0128B_WDATA1_R : VarBasis
            {
                /*"      05     WDATA1-AA               PIC  9(004).*/
                public IntBasis WDATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WDATA1-MM               PIC  9(002).*/
                public IntBasis WDATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDTINIVIG               PIC  9(006).*/

                public _REDEF_VA0128B_WDATA1_R()
                {
                    WDATA1_AA.ValueChanged += OnValueChanged;
                    WDATA1_MM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDTINIVIG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDTINIVIG-R REDEFINES WDTINIVIG.*/
            private _REDEF_VA0128B_WDTINIVIG_R _wdtinivig_r { get; set; }
            public _REDEF_VA0128B_WDTINIVIG_R WDTINIVIG_R
            {
                get { _wdtinivig_r = new _REDEF_VA0128B_WDTINIVIG_R(); _.Move(WDTINIVIG, _wdtinivig_r); VarBasis.RedefinePassValue(WDTINIVIG, _wdtinivig_r, WDTINIVIG); _wdtinivig_r.ValueChanged += () => { _.Move(_wdtinivig_r, WDTINIVIG); }; return _wdtinivig_r; }
                set { VarBasis.RedefinePassValue(value, _wdtinivig_r, WDTINIVIG); }
            }  //Redefines
            public class _REDEF_VA0128B_WDTINIVIG_R : VarBasis
            {
                /*"      05     WAAINIVIG               PIC  9(004).*/
                public IntBasis WAAINIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WMMINIVIG               PIC  9(002).*/
                public IntBasis WMMINIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MAX             PIC  9(006).*/

                public _REDEF_VA0128B_WDTINIVIG_R()
                {
                    WAAINIVIG.ValueChanged += OnValueChanged;
                    WMMINIVIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MAX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MAX-R REDEFINES WS-DATA-MAX.*/
            private _REDEF_VA0128B_WS_DATA_MAX_R _ws_data_max_r { get; set; }
            public _REDEF_VA0128B_WS_DATA_MAX_R WS_DATA_MAX_R
            {
                get { _ws_data_max_r = new _REDEF_VA0128B_WS_DATA_MAX_R(); _.Move(WS_DATA_MAX, _ws_data_max_r); VarBasis.RedefinePassValue(WS_DATA_MAX, _ws_data_max_r, WS_DATA_MAX); _ws_data_max_r.ValueChanged += () => { _.Move(_ws_data_max_r, WS_DATA_MAX); }; return _ws_data_max_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_max_r, WS_DATA_MAX); }
            }  //Redefines
            public class _REDEF_VA0128B_WS_DATA_MAX_R : VarBasis
            {
                /*"      05     WS-ANO-MAX              PIC  9(004).*/
                public IntBasis WS_ANO_MAX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MAX              PIC  9(002).*/
                public IntBasis WS_MES_MAX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MIN             PIC  9(006).*/

                public _REDEF_VA0128B_WS_DATA_MAX_R()
                {
                    WS_ANO_MAX.ValueChanged += OnValueChanged;
                    WS_MES_MAX.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MIN-R REDEFINES WS-DATA-MIN.*/
            private _REDEF_VA0128B_WS_DATA_MIN_R _ws_data_min_r { get; set; }
            public _REDEF_VA0128B_WS_DATA_MIN_R WS_DATA_MIN_R
            {
                get { _ws_data_min_r = new _REDEF_VA0128B_WS_DATA_MIN_R(); _.Move(WS_DATA_MIN, _ws_data_min_r); VarBasis.RedefinePassValue(WS_DATA_MIN, _ws_data_min_r, WS_DATA_MIN); _ws_data_min_r.ValueChanged += () => { _.Move(_ws_data_min_r, WS_DATA_MIN); }; return _ws_data_min_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_min_r, WS_DATA_MIN); }
            }  //Redefines
            public class _REDEF_VA0128B_WS_DATA_MIN_R : VarBasis
            {
                /*"      05     WS-ANO-MIN              PIC  9(004).*/
                public IntBasis WS_ANO_MIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MIN              PIC  9(002).*/
                public IntBasis WS_MES_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       TABELA-IGPM.*/

                public _REDEF_VA0128B_WS_DATA_MIN_R()
                {
                    WS_ANO_MIN.ValueChanged += OnValueChanged;
                    WS_MES_MIN.ValueChanged += OnValueChanged;
                }

            }
            public VA0128B_TABELA_IGPM TABELA_IGPM { get; set; } = new VA0128B_TABELA_IGPM();
            public class VA0128B_TABELA_IGPM : VarBasis
            {
                /*"      05     FILLER            OCCURS 300 TIMES.*/
                public ListBasis<VA0128B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VA0128B_FILLER_1>(300);
                public class VA0128B_FILLER_1 : VarBasis
                {
                    /*"        10   TB-DATA-IGPM      PIC  9(006).*/
                    public IntBasis TB_DATA_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"        10   TB-DATA-IGPM-R REDEFINES TB-DATA-IGPM.*/
                    private _REDEF_VA0128B_TB_DATA_IGPM_R _tb_data_igpm_r { get; set; }
                    public _REDEF_VA0128B_TB_DATA_IGPM_R TB_DATA_IGPM_R
                    {
                        get { _tb_data_igpm_r = new _REDEF_VA0128B_TB_DATA_IGPM_R(); _.Move(TB_DATA_IGPM, _tb_data_igpm_r); VarBasis.RedefinePassValue(TB_DATA_IGPM, _tb_data_igpm_r, TB_DATA_IGPM); _tb_data_igpm_r.ValueChanged += () => { _.Move(_tb_data_igpm_r, TB_DATA_IGPM); }; return _tb_data_igpm_r; }
                        set { VarBasis.RedefinePassValue(value, _tb_data_igpm_r, TB_DATA_IGPM); }
                    }  //Redefines
                    public class _REDEF_VA0128B_TB_DATA_IGPM_R : VarBasis
                    {
                        /*"          15 TB-ANO-IGPM       PIC  9(004).*/
                        public IntBasis TB_ANO_IGPM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"          15 TB-MES-IGPM       PIC  9(002).*/
                        public IntBasis TB_MES_IGPM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        10   TB-VAL-IGPM       PIC S9(006)V9(9)  COMP-3.*/

                        public _REDEF_VA0128B_TB_DATA_IGPM_R()
                        {
                            TB_ANO_IGPM.ValueChanged += OnValueChanged;
                            TB_MES_IGPM.ValueChanged += OnValueChanged;
                        }

                    }
                    public DoubleBasis TB_VAL_IGPM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                    /*"    03 AC-LIDOS                      PIC  9(006) VALUE  0.*/
                }
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-COM-ERRO                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_COM_ERRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-IOF                        PIC  9(006) VALUE  0.*/
            public IntBasis AC_IOF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-IGPM                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-VENDA                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_VENDA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-AUMENTO               PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_AUMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-PRODUTO               PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_PRODUTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-FATURA                PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_FATURA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-MOVIM                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_MOVIM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DESP-DATAIOF               PIC  9(006) VALUE  0.*/
            public IntBasis AC_DESP_DATAIOF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  WABEND.*/
        }
        public VA0128B_WABEND WABEND { get; set; } = new VA0128B_WABEND();
        public class VA0128B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VA0128B  '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0128B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10      LOCALIZA-ABEND-1.*/
            public VA0128B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0128B_LOCALIZA_ABEND_1();
            public class VA0128B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15  PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public VA0128B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0128B_LOCALIZA_ABEND_2();
            public class VA0128B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15  COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public VA0128B_CPROPVA CPROPVA { get; set; } = new VA0128B_CPROPVA();
        public VA0128B_VGHISRAMC VGHISRAMC { get; set; } = new VA0128B_VGHISRAMC();
        public VA0128B_VGHISTACE VGHISTACE { get; set; } = new VA0128B_VGHISTACE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -489- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -491- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -493- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -496- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -498- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -511- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -514- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -516- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -517- IF SISTEMA-DTMOVABE LESS '2004-09-01' */

            if (SISTEMA_DTMOVABE < "2004-09-01")
            {

                /*" -518- MOVE '2004-09-01' TO V0RIND-DTMOVTO */
                _.Move("2004-09-01", V0RIND_DTMOVTO);

                /*" -519- ELSE */
            }
            else
            {


                /*" -521- MOVE SISTEMA-DTMOVABE TO V0RIND-DTMOVTO. */
                _.Move(SISTEMA_DTMOVABE, V0RIND_DTMOVTO);
            }


            /*" -523- MOVE 'SELECT V0PARAMRAMO ' TO COMANDO. */
            _.Move("SELECT V0PARAMRAMO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -540- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -543- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -545- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -547- MOVE 'SELECT V0RAMOIND ATUAL ' TO COMANDO. */
            _.Move("SELECT V0RAMOIND ATUAL ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -562- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

            M_0000_PRINCIPAL_DB_SELECT_3();

            /*" -565- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -567- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -570- COMPUTE V0RIND-PCIOF-ATU = 1 + (RAMOCOMP-PCT-IOCC-RAMO / 100). */
            V0RIND_PCIOF_ATU.Value = 1 + (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f);

            /*" -572- MOVE RAMOCOMP-DATA-INIVIGENCIA TO V0RIND-DATA-BASE. */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA, V0RIND_DATA_BASE);

            /*" -574- MOVE 'SELECT V0RAMOIND ANTERIOR ' TO COMANDO. */
            _.Move("SELECT V0RAMOIND ANTERIOR ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -585- PERFORM M_0000_PRINCIPAL_DB_SELECT_4 */

            M_0000_PRINCIPAL_DB_SELECT_4();

            /*" -588- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -590- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -593- COMPUTE V0RIND-PCIOF-ANT = 1 + (RAMOCOMP-PCT-IOCC-RAMO / 100). */
            V0RIND_PCIOF_ANT.Value = 1 + (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f);

            /*" -594- MOVE V0RIND-PCIOF-ANT TO PCIOF-ANT-DET. */
            _.Move(V0RIND_PCIOF_ANT, PCIOF_ANT_DET);

            /*" -596- MOVE V0RIND-PCIOF-ATU TO PCIOF-ATU-DET. */
            _.Move(V0RIND_PCIOF_ATU, PCIOF_ATU_DET);

            /*" -597- DISPLAY ' IOFS UTILIZADOS NO CALCULO ' . */
            _.Display($" IOFS UTILIZADOS NO CALCULO ");

            /*" -598- DISPLAY ' -------------------------- ' . */
            _.Display($" -------------------------- ");

            /*" -599- DISPLAY ' IOF ANTERIOR ' PCIOF-ANT-DET */
            _.Display($" IOF ANTERIOR {PCIOF_ANT_DET}");

            /*" -601- DISPLAY ' IOF ATUAL    ' PCIOF-ATU-DET. */
            _.Display($" IOF ATUAL    {PCIOF_ATU_DET}");

            /*" -602- IF V0RIND-PCIOF-ATU EQUAL V0RIND-PCIOF-ANT */

            if (V0RIND_PCIOF_ATU == V0RIND_PCIOF_ANT)
            {

                /*" -603- DISPLAY '--> NAO HOUVE MUDANCA DE ALIQUOTA <-- ' */
                _.Display($"--> NAO HOUVE MUDANCA DE ALIQUOTA <-- ");

                /*" -610- GO TO 0000-TERMINA. */

                M_0000_TERMINA(); //GOTO
                return;
            }


            /*" -612- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -644- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -647- DISPLAY '*** VA0128B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA0128B *** ABRINDO CURSOR ...");

            /*" -648- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -648- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -652- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -654- DISPLAY '*** VA0128B *** PROCESSANDO ...' . */
            _.Display($"*** VA0128B *** PROCESSANDO ...");

            /*" -655- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -511- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DTMOVABE - 1 MONTH, DTMOVABE - 12 MONTH, DTMOVABE + 1 MONTH INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRENT, :SISTEMA-DTTERCOT, :SISTEMA-DTINICOT, :SISTEMA-DTMOV01M FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRENT, SISTEMA_CURRENT);
                _.Move(executed_1.SISTEMA_DTTERCOT, SISTEMA_DTTERCOT);
                _.Move(executed_1.SISTEMA_DTINICOT, SISTEMA_DTINICOT);
                _.Move(executed_1.SISTEMA_DTMOV01M, SISTEMA_DTMOV01M);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -661- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -663- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -663- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -540- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, RAMO_SAUDE, RAMO_SA_INDV, RAMO_EDUCACAO, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-RAMO-SAUDE, :PARAMRAM-RAMO-SA-INDV, :PARAMRAM-RAMO-EDUCACAO, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WHERE 1 = 1 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VGAPC, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC);
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
                _.Move(executed_1.PARAMRAM_RAMO_SAUDE, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_SAUDE);
                _.Move(executed_1.PARAMRAM_RAMO_SA_INDV, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_SA_INDV);
                _.Move(executed_1.PARAMRAM_RAMO_EDUCACAO, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_EDUCACAO);
                _.Move(executed_1.PARAMRAM_NUM_RAMO_PRSTMISTA, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -673- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -677- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -678- IF PROPVA-DTQITBCO NOT LESS V0RIND-DATA-BASE */

            if (PROPVA_DTQITBCO >= V0RIND_DATA_BASE)
            {

                /*" -679- ADD 1 TO AC-DESP-DATAIOF */
                WS_WORK_AREAS.AC_DESP_DATAIOF.Value = WS_WORK_AREAS.AC_DESP_DATAIOF + 1;

                /*" -683- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -685- MOVE 'SELECT V0PRODUTOSVG' TO COMANDO. */
            _.Move("SELECT V0PRODUTOSVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -705- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -710- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -711- IF VIND-TEM-CDG LESS ZEROES */

            if (VIND_TEM_CDG < 00)
            {

                /*" -713- MOVE 'N' TO PRODVG-TEM-CDG. */
                _.Move("N", PRODVG_TEM_CDG);
            }


            /*" -714- IF VIND-TEM-SAF LESS ZEROES */

            if (VIND_TEM_SAF < 00)
            {

                /*" -716- MOVE 'N' TO PRODVG-TEM-SAF. */
                _.Move("N", PRODVG_TEM_SAF);
            }


            /*" -718- IF PRODVG-ORIG-PRODU EQUAL 'AVERB' OR 'ESPEC' OR 'EMPRE' OR SPACES OR '****' */

            if (PRODVG_ORIG_PRODU.In("AVERB", "ESPEC", "EMPRE", string.Empty, "****"))
            {

                /*" -719- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -721- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -723- IF PRODVG-ESTR-COBR NOT EQUAL 'MULT' AND PRODVG-ESTR-COBR NOT EQUAL 'FEDERAL' */

            if (PRODVG_ESTR_COBR != "MULT" && PRODVG_ESTR_COBR != "FEDERAL")
            {

                /*" -724- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -731- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -733- MOVE 'SELECT V0MOVIMENTO' TO COMANDO. */
            _.Move("SELECT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -741- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -744- IF MOVTO-LIDOS NOT EQUAL ZEROS */

            if (MOVTO_LIDOS != 00)
            {

                /*" -745- DISPLAY '** VA0128B - EXISTEM MOVIMENTOS PENDENTES ' */
                _.Display($"** VA0128B - EXISTEM MOVIMENTOS PENDENTES ");

                /*" -746- DISPLAY '** CERTIF  - ' PROPVA-NRCERTIF */
                _.Display($"** CERTIF  - {PROPVA_NRCERTIF}");

                /*" -747- ADD 1 TO AC-DESP-MOVIM */
                WS_WORK_AREAS.AC_DESP_MOVIM.Value = WS_WORK_AREAS.AC_DESP_MOVIM + 1;

                /*" -752- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -754- MOVE 'SELECT V0SEGURAVG 1' TO COMANDO. */
            _.Move("SELECT V0SEGURAVG 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -782- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

            /*" -785- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -786- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -787- DISPLAY '** NAO ENCONTROU APOLICE NA SEGUROS.V0SEGURAVG' */
                    _.Display($"** NAO ENCONTROU APOLICE NA SEGUROS.V0SEGURAVG");

                    /*" -788- DISPLAY 'APOLICE .... = ' PROPVA-NUM-APOLICE */
                    _.Display($"APOLICE .... = {PROPVA_NUM_APOLICE}");

                    /*" -789- DISPLAY 'SUBGRUPO ... = ' PROPVA-CODSUBES */
                    _.Display($"SUBGRUPO ... = {PROPVA_CODSUBES}");

                    /*" -790- DISPLAY 'CERTIFICADO  = ' PROPVA-NRCERTIF */
                    _.Display($"CERTIFICADO  = {PROPVA_NRCERTIF}");

                    /*" -791- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -792- ELSE */
                }
                else
                {


                    /*" -794- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -795- IF SEGURA-SIT-REGISTRO EQUAL '2' OR '9' */

            if (SEGURA_SIT_REGISTRO.In("2", "9"))
            {

                /*" -796- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -798- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -800- MOVE 'SELECT V0HISTSEGVG LAST' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG LAST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -809- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -812- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -814- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -816- MOVE 'SELECT V0HISTSEGVG MAX' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -818- MOVE 0 TO WS-TEVE-ALTERACAO. */
            _.Move(0, WS_WORK_AREAS.WS_TEVE_ALTERACAO);

            /*" -825- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -828- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -830- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -831- IF HISTSG-OCORHIST NOT EQUAL ZEROES */

            if (HISTSG_OCORHIST != 00)
            {

                /*" -832- MOVE 1 TO WS-TEVE-ALTERACAO */
                _.Move(1, WS_WORK_AREAS.WS_TEVE_ALTERACAO);

                /*" -833- MOVE 'SELECT V0HISTSEGVG 2 ' TO COMANDO */
                _.Move("SELECT V0HISTSEGVG 2 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -842- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

                /*" -844- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -845- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -846- ELSE */
                }
                else
                {


                    /*" -847- IF HISTSG-DTMOVTO-ANT NOT LESS V0RIND-DATA-BASE */

                    if (HISTSG_DTMOVTO_ANT >= V0RIND_DATA_BASE)
                    {

                        /*" -848- ADD 1 TO AC-DESP-AUMENTO */
                        WS_WORK_AREAS.AC_DESP_AUMENTO.Value = WS_WORK_AREAS.AC_DESP_AUMENTO + 1;

                        /*" -852- GO TO 0100-NEXT. */

                        M_0100_NEXT(); //GOTO
                        return;
                    }

                }

            }


            /*" -854- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -859- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

            /*" -863- IF SQLCODE NOT EQUAL ZEROES OR CLIENT-DTNASC-I LESS ZEROES */

            if (DB.SQLCODE != 00 || CLIENT_DTNASC_I < 00)
            {

                /*" -864- MOVE 'SELECT V0SEGURAVG' TO COMANDO */
                _.Move("SELECT V0SEGURAVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -871- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_8 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_8();

                /*" -874- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -875- DISPLAY 'ERRO ACESSO SEGURAVG ' PROPVA-NRCERTIF */
                    _.Display($"ERRO ACESSO SEGURAVG {PROPVA_NRCERTIF}");

                    /*" -876- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -877- ELSE */
                }
                else
                {


                    /*" -878- IF SEGURA-DTNASC-I LESS ZEROES */

                    if (SEGURA_DTNASC_I < 00)
                    {

                        /*" -879- DISPLAY 'DATA NASCIMENTO NULA ' PROPVA-NRCERTIF */
                        _.Display($"DATA NASCIMENTO NULA {PROPVA_NRCERTIF}");

                        /*" -881- GO TO 0100-NEXT. */

                        M_0100_NEXT(); //GOTO
                        return;
                    }

                }

            }


            /*" -883- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -899- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_9 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_9();

            /*" -902- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -903- DISPLAY 'ERRO ACESSO OPCAOPAG ' PROPVA-NRCERTIF */
                _.Display($"ERRO ACESSO OPCAOPAG {PROPVA_NRCERTIF}");

                /*" -905- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -906- IF OPCAOP-OPCAOPAG EQUAL '4' */

            if (OPCAOP_OPCAOPAG == "4")
            {

                /*" -907- ADD 1 TO AC-DESP-PRODUTO */
                WS_WORK_AREAS.AC_DESP_PRODUTO.Value = WS_WORK_AREAS.AC_DESP_PRODUTO + 1;

                /*" -911- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -913- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -979- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_10 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_10();

            /*" -982- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -983- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -984- DISPLAY 'ERRO ACESSO COBERPROP ' PROPVA-NRCERTIF */
                    _.Display($"ERRO ACESSO COBERPROP {PROPVA_NRCERTIF}");

                    /*" -985- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -986- ELSE */
                }
                else
                {


                    /*" -988- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -990- PERFORM 0200-VERIFICA-COBER THRU 0200-FIM. */

            M_0200_VERIFICA_COBER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


            /*" -991- IF TEM-ERRO-COBER EQUAL 'S' */

            if (TEM_ERRO_COBER == "S")
            {

                /*" -992- ADD 1 TO AC-COM-ERRO */
                WS_WORK_AREAS.AC_COM_ERRO.Value = WS_WORK_AREAS.AC_COM_ERRO + 1;

                /*" -994- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -994- PERFORM 0300-CORRIGE-IOF THRU 0300-FIM. */

            M_0300_CORRIGE_IOF(true);

            M_0300_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -705- EXEC SQL SELECT TEM_IGPM, RAMO, COBERADIC_PREMIO, CUSTOCAP_TOTAL, TEM_CDG, TEM_SAF, VALUE(ORIG_PRODU, '****' ), VALUE(ESTR_COBR, 'XXXX' ) INTO :PRODVG-TEM-IGPM:VIND-TEM-IGPM, :PRODVG-RAMO, :PRODVG-COBERADIC-PREMIO, :PRODVG-CUSTOCAP-TOTAL, :PRODVG-TEM-CDG:VIND-TEM-CDG, :PRODVG-TEM-SAF:VIND-TEM-SAF, :PRODVG-ORIG-PRODU, :PRODVG-ESTR-COBR FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_TEM_IGPM, PRODVG_TEM_IGPM);
                _.Move(executed_1.VIND_TEM_IGPM, VIND_TEM_IGPM);
                _.Move(executed_1.PRODVG_RAMO, PRODVG_RAMO);
                _.Move(executed_1.PRODVG_COBERADIC_PREMIO, PRODVG_COBERADIC_PREMIO);
                _.Move(executed_1.PRODVG_CUSTOCAP_TOTAL, PRODVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.PRODVG_TEM_CDG, PRODVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.PRODVG_TEM_SAF, PRODVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.PRODVG_ORIG_PRODU, PRODVG_ORIG_PRODU);
                _.Move(executed_1.PRODVG_ESTR_COBR, PRODVG_ESTR_COBR);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -644- EXEC SQL DECLARE CPROPVA CURSOR WITH HOLD FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTPROXVEN, CODOPER, DTMOVTO, NUM_APOLICE, CODSUBES, OCORHIST, SIT_INTERFACE, TIMESTAMP, IDE_SEXO, ESTADO_CIVIL, DTQITBCO + 1 YEAR, DTQITBCO, IDADE FROM SEGUROS.V0PROPOSTAVA WHERE SITUACAO IN ( '3' , '6' ) AND NUM_APOLICE <> 109300000635 FOR UPDATE OF CODOPER, DTMOVTO, OCORHIST, SIT_INTERFACE, TIMESTAMP END-EXEC. */
            CPROPVA = new VA0128B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							CODCLIEN
							, 
							OCOREND
							, 
							FONTE
							, 
							AGECOBR
							, 
							OPCAO_COBER
							, 
							DTPROXVEN
							, 
							CODOPER
							, 
							DTMOVTO
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							OCORHIST
							, 
							SIT_INTERFACE
							, 
							TIMESTAMP
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							DTQITBCO + 1 YEAR
							, 
							DTQITBCO
							, 
							IDADE 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE SITUACAO IN ( '3'
							, '6' ) 
							AND NUM_APOLICE <> 109300000635";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -741- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :MOVTO-LIDOS FROM SEGUROS.V0MOVIMENTO WHERE DATA_AVERBACAO IS NOT NULL AND DATA_INCLUSAO IS NULL AND NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVTO_LIDOS, MOVTO_LIDOS);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -648- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0410-00-DECLARE-VGHISTRAMCOB-DB-DECLARE-1 */
        public void M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1()
        {
            /*" -1760- EXEC SQL DECLARE VGHISRAMC CURSOR FOR SELECT NUM_CERTIFICADO, NUM_RAMO, NUM_COBERTURA, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_HIST_RAMO_COB WHERE NUM_CERTIFICADO = :COBERP-NRCERTIF AND OCORR_HISTORICO = :COBERP-OCORHIST-ANT ORDER BY NUM_RAMO, NUM_COBERTURA END-EXEC. */
            VGHISRAMC = new VA0128B_VGHISRAMC(true);
            string GetQuery_VGHISRAMC()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_RAMO
							, 
							NUM_COBERTURA
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_HIST_RAMO_COB 
							WHERE NUM_CERTIFICADO = '{COBERP_NRCERTIF}' 
							AND OCORR_HISTORICO = '{COBERP_OCORHIST_ANT}' 
							ORDER BY NUM_RAMO
							, 
							NUM_COBERTURA";

                return query;
            }
            VGHISRAMC.GetQueryEvent += GetQuery_VGHISRAMC;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -782- EXEC SQL SELECT NUM_ITEM, FAIXA, TAXA_VG, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, SIT_REGISTRO, LOT_EMP_SEGURADO, OCORR_HISTORICO INTO :SEGURA-NUM-ITEM, :SEGURA-FAIXA, :SEGURA-TXVG, :SEGURA-TXAPMA, :SEGURA-TXAPIP, :SEGURA-TXAPAMDS, :SEGURA-TXAPDH, :SEGURA-TXAPDIT, :SEGURA-SIT-REGISTRO, :SEGURA-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO, :SEGURA-OCORHIST FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_CERTIFICADO = :PROPVA-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURA_NUM_ITEM, SEGURA_NUM_ITEM);
                _.Move(executed_1.SEGURA_FAIXA, SEGURA_FAIXA);
                _.Move(executed_1.SEGURA_TXVG, SEGURA_TXVG);
                _.Move(executed_1.SEGURA_TXAPMA, SEGURA_TXAPMA);
                _.Move(executed_1.SEGURA_TXAPIP, SEGURA_TXAPIP);
                _.Move(executed_1.SEGURA_TXAPAMDS, SEGURA_TXAPAMDS);
                _.Move(executed_1.SEGURA_TXAPDH, SEGURA_TXAPDH);
                _.Move(executed_1.SEGURA_TXAPDIT, SEGURA_TXAPDIT);
                _.Move(executed_1.SEGURA_SIT_REGISTRO, SEGURA_SIT_REGISTRO);
                _.Move(executed_1.SEGURA_LOT_EMP_SEGURADO, SEGURA_LOT_EMP_SEGURADO);
                _.Move(executed_1.WLOT_EMP_SEGURADO, WLOT_EMP_SEGURADO);
                _.Move(executed_1.SEGURA_OCORHIST, SEGURA_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -562- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_INIVIGENCIA - 1 DAY, PCT_IOCC_RAMO INTO :RAMOCOMP-DATA-INIVIGENCIA, :V0RIND-DTMOVTO-1DAY, :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :PARAMRAM-RAMO-VG AND DATA_INIVIGENCIA <= :V0RIND-DTMOVTO AND DATA_TERVIGENCIA >= :V0RIND-DTMOVTO END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_PRINCIPAL_DB_SELECT_3_Query1()
            {
                PARAMRAM_RAMO_VG = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(),
                V0RIND_DTMOVTO = V0RIND_DTMOVTO.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_DATA_INIVIGENCIA, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA);
                _.Move(executed_1.V0RIND_DTMOVTO_1DAY, V0RIND_DTMOVTO_1DAY);
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -809- EXEC SQL SELECT DATA_MOVIMENTO, DATA_MOVIMENTO + 1 DAY INTO :HISTSG-DTMOVTO-DTTERVIG, :HISTSG-DTMOVTO-1DAY FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND OCORR_HISTORICO = :SEGURA-OCORHIST END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
                SEGURA_OCORHIST = SEGURA_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_DTMOVTO_DTTERVIG, HISTSG_DTMOVTO_DTTERVIG);
                _.Move(executed_1.HISTSG_DTMOVTO_1DAY, HISTSG_DTMOVTO_1DAY);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -998- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -825- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO),0) INTO :HISTSG-OCORHIST FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND COD_OPERACAO IN (796, 896) END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_OCORHIST, HISTSG_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-4 */
        public void M_0000_PRINCIPAL_DB_SELECT_4()
        {
            /*" -585- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :PARAMRAM-RAMO-VG AND DATA_INIVIGENCIA <= :V0RIND-DTMOVTO-1DAY AND DATA_TERVIGENCIA >= :V0RIND-DTMOVTO-1DAY END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_4_Query1 = new M_0000_PRINCIPAL_DB_SELECT_4_Query1()
            {
                V0RIND_DTMOVTO_1DAY = V0RIND_DTMOVTO_1DAY.ToString(),
                PARAMRAM_RAMO_VG = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_4_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -842- EXEC SQL SELECT DATA_MOVIMENTO, COD_OPERACAO INTO :HISTSG-DTMOVTO-ANT, :HISTSG-CODOPER FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND OCORR_HISTORICO = :HISTSG-OCORHIST END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
                HISTSG_OCORHIST = HISTSG_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_DTMOVTO_ANT, HISTSG_DTMOVTO_ANT);
                _.Move(executed_1.HISTSG_CODOPER, HISTSG_CODOPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -859- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -1009- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1011- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1034- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -1037- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1038- MOVE 1 TO WS-EOF */
                _.Move(1, WS_WORK_AREAS.WS_EOF);

                /*" -1039- MOVE 'CLOSE CPROPVA' TO COMANDO */
                _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1039- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                M_0110_FETCH_DB_CLOSE_1();

                /*" -1040- GO TO 0110-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -1034- EXEC SQL FETCH CPROPVA INTO :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTPROXVEN, :PROPVA-CODOPER, :PROPVA-DTMOVTO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-DTQITBCO-1YEAR, :PROPVA-DTQITBCO, :PROPVA-IDADE END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_AGECOBR, PROPVA_AGECOBR);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_CODOPER, PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTMOVTO, PROPVA_DTMOVTO);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_SIT_INTERF, PROPVA_SIT_INTERF);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_SEXO, PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_EST_CIV, PROPVA_EST_CIV);
                _.Move(CPROPVA.PROPVA_DTQITBCO_1YEAR, PROPVA_DTQITBCO_1YEAR);
                _.Move(CPROPVA.PROPVA_DTQITBCO, PROPVA_DTQITBCO);
                _.Move(CPROPVA.PROPVA_IDADE, PROPVA_IDADE);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -1039- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-8 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_8()
        {
            /*" -871- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:SEGURA-DTNASC-I FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.SEGURA_DTNASC_I, SEGURA_DTNASC_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-9 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_9()
        {
            /*" -899- EXEC SQL SELECT PERIPGTO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, OPCAOPAG INTO :OPCAOP-PERIPGTO, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG, :OPCAOP-OPCAOPAG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCAOP_PERIPGTO, OPCAOP_PERIPGTO);
                _.Move(executed_1.OPCAOP_AGECTADEB, OPCAOP_AGECTADEB);
                _.Move(executed_1.INDAGE, INDAGE);
                _.Move(executed_1.OPCAOP_OPRCTADEB, OPCAOP_OPRCTADEB);
                _.Move(executed_1.INDOPR, INDOPR);
                _.Move(executed_1.OPCAOP_NUMCTADEB, OPCAOP_NUMCTADEB);
                _.Move(executed_1.INDNUM, INDNUM);
                _.Move(executed_1.OPCAOP_DIGCTADEB, OPCAOP_DIGCTADEB);
                _.Move(executed_1.INDDIG, INDDIG);
                _.Move(executed_1.OPCAOP_OPCAOPAG, OPCAOP_OPCAOPAG);
            }


        }

        [StopWatch]
        /*" M-0200-VERIFICA-COBER */
        private void M_0200_VERIFICA_COBER(bool isPerform = false)
        {
            /*" -1052- MOVE '0200-VERIFICA-COBER ' TO PARAGRAFO. */
            _.Move("0200-VERIFICA-COBER ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1054- MOVE 'SELECT CONDITEC     ' TO COMANDO. */
            _.Move("SELECT CONDITEC     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1055- MOVE 'N' TO TEM-ERRO-COBER. */
            _.Move("N", TEM_ERRO_COBER);

            /*" -1056- MOVE 'N' TO TEM-VG. */
            _.Move("N", TEM_VG);

            /*" -1057- MOVE 'N' TO TEM-AP. */
            _.Move("N", TEM_AP);

            /*" -1059- MOVE 'N' TO TEM-IP. */
            _.Move("N", TEM_IP);

            /*" -1113- PERFORM M_0200_VERIFICA_COBER_DB_SELECT_1 */

            M_0200_VERIFICA_COBER_DB_SELECT_1();

            /*" -1116- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1117- DISPLAY 'ERRO ACESSO CONDITEC - ' SQLCODE */
                _.Display($"ERRO ACESSO CONDITEC - {DB.SQLCODE}");

                /*" -1118- DISPLAY 'NUM_APOLICE          = ' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE          = {PROPVA_NUM_APOLICE}");

                /*" -1119- DISPLAY 'COD_SUBGRUPO         = ' PROPVA-CODSUBES */
                _.Display($"COD_SUBGRUPO         = {PROPVA_CODSUBES}");

                /*" -1121- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1122- IF CONDITEC-TAXA-AP-MORACID GREATER ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID > 00)
            {

                /*" -1124- MOVE 'S' TO TEM-AP. */
                _.Move("S", TEM_AP);
            }


            /*" -1125- IF CONDITEC-TAXA-AP-INVPERM GREATER ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM > 00)
            {

                /*" -1127- MOVE 'S' TO TEM-IP. */
                _.Move("S", TEM_IP);
            }


            /*" -1129- MOVE 'SELECT FAIXAETA     ' TO COMANDO. */
            _.Move("SELECT FAIXAETA     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1140- PERFORM M_0200_VERIFICA_COBER_DB_SELECT_2 */

            M_0200_VERIFICA_COBER_DB_SELECT_2();

            /*" -1143- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1144- DISPLAY 'ERRO ACESSO FAIXAETA - ' SQLCODE */
                _.Display($"ERRO ACESSO FAIXAETA - {DB.SQLCODE}");

                /*" -1145- DISPLAY 'NUM_APOLICE          = ' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE          = {PROPVA_NUM_APOLICE}");

                /*" -1146- DISPLAY 'COD_SUBGRUPO         = ' PROPVA-CODSUBES */
                _.Display($"COD_SUBGRUPO         = {PROPVA_CODSUBES}");

                /*" -1148- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1149- IF FAIXAETA-TAXA-VG GREATER ZEROS */

            if (FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG > 00)
            {

                /*" -1151- MOVE 'S' TO TEM-VG. */
                _.Move("S", TEM_VG);
            }


            /*" -1153- MOVE 'SELECT FAIXASAL     ' TO COMANDO. */
            _.Move("SELECT FAIXASAL     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1163- PERFORM M_0200_VERIFICA_COBER_DB_SELECT_3 */

            M_0200_VERIFICA_COBER_DB_SELECT_3();

            /*" -1166- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1167- DISPLAY 'ERRO ACESSO FAIXASAL - ' SQLCODE */
                _.Display($"ERRO ACESSO FAIXASAL - {DB.SQLCODE}");

                /*" -1168- DISPLAY 'NUM_APOLICE          = ' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE          = {PROPVA_NUM_APOLICE}");

                /*" -1169- DISPLAY 'COD_SUBGRUPO         = ' PROPVA-CODSUBES */
                _.Display($"COD_SUBGRUPO         = {PROPVA_CODSUBES}");

                /*" -1171- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1172- IF FAIXASAL-TAXA-VG GREATER ZEROS */

            if (FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG > 00)
            {

                /*" -1174- MOVE 'S' TO TEM-VG. */
                _.Move("S", TEM_VG);
            }


            /*" -1175- IF TEM-VG = 'S' */

            if (TEM_VG == "S")
            {

                /*" -1176- IF HISCOBPR-PRMVG NOT GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG <= 00)
                {

                    /*" -1177- MOVE 'S' TO TEM-ERRO-COBER */
                    _.Move("S", TEM_ERRO_COBER);

                    /*" -1178- DISPLAY 'TEM VG SEM PREMIO = ' PROPVA-NRCERTIF */
                    _.Display($"TEM VG SEM PREMIO = {PROPVA_NRCERTIF}");

                    /*" -1179- GO TO 0200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                    return;

                    /*" -1180- ELSE */
                }
                else
                {


                    /*" -1183- IF HISCOBPR-IMP-MORNATU NOT GREATER ZEROS OR HISCOBPR-IMPSEGUR NOT GREATER ZEROS OR HISCOBPR-IMPSEGIND NOT GREATER ZEROS */

                    if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND <= 00)
                    {

                        /*" -1184- MOVE 'S' TO TEM-ERRO-COBER */
                        _.Move("S", TEM_ERRO_COBER);

                        /*" -1185- DISPLAY 'TEM VG SEM IS     = ' PROPVA-NRCERTIF */
                        _.Display($"TEM VG SEM IS     = {PROPVA_NRCERTIF}");

                        /*" -1187- GO TO 0200-FIM. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1188- IF TEM-AP = 'S' */

            if (TEM_AP == "S")
            {

                /*" -1189- IF HISCOBPR-PRMAP NOT GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP <= 00)
                {

                    /*" -1190- MOVE 'S' TO TEM-ERRO-COBER */
                    _.Move("S", TEM_ERRO_COBER);

                    /*" -1191- DISPLAY 'TEM AP SEM PREMIO = ' PROPVA-NRCERTIF */
                    _.Display($"TEM AP SEM PREMIO = {PROPVA_NRCERTIF}");

                    /*" -1192- GO TO 0200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                    return;

                    /*" -1193- ELSE */
                }
                else
                {


                    /*" -1196- IF HISCOBPR-IMPMORACID NOT GREATER ZEROS OR HISCOBPR-IMPSEGUR NOT GREATER ZEROS OR HISCOBPR-IMPSEGIND NOT GREATER ZEROS */

                    if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND <= 00)
                    {

                        /*" -1197- MOVE 'S' TO TEM-ERRO-COBER */
                        _.Move("S", TEM_ERRO_COBER);

                        /*" -1198- DISPLAY 'TEM AP SEM IS     = ' PROPVA-NRCERTIF */
                        _.Display($"TEM AP SEM IS     = {PROPVA_NRCERTIF}");

                        /*" -1200- GO TO 0200-FIM. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1201- IF TEM-AP = 'N' AND TEM-VG = 'S' */

            if (TEM_AP == "N" && TEM_VG == "S")
            {

                /*" -1202- IF HISCOBPR-PRMAP GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP > 00)
                {

                    /*" -1204- COMPUTE HISCOBPR-PRMVG = HISCOBPR-PRMVG + HISCOBPR-PRMAP */
                    HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

                    /*" -1206- MOVE ZEROS TO HISCOBPR-PRMAP. */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                }

            }


            /*" -1207- IF TEM-AP = 'S' AND TEM-VG = 'N' */

            if (TEM_AP == "S" && TEM_VG == "N")
            {

                /*" -1208- IF HISCOBPR-PRMVG GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG > 00)
                {

                    /*" -1210- COMPUTE HISCOBPR-PRMAP = HISCOBPR-PRMAP + HISCOBPR-PRMVG */
                    HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG;

                    /*" -1212- MOVE ZEROS TO HISCOBPR-PRMVG. */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                }

            }


            /*" -1213- IF TEM-IP = 'S' */

            if (TEM_IP == "S")
            {

                /*" -1214- IF HISCOBPR-PRMAP NOT GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP <= 00)
                {

                    /*" -1215- MOVE 'S' TO TEM-ERRO-COBER */
                    _.Move("S", TEM_ERRO_COBER);

                    /*" -1216- DISPLAY 'TEM IP SEM PREMIO AP = ' PROPVA-NRCERTIF */
                    _.Display($"TEM IP SEM PREMIO AP = {PROPVA_NRCERTIF}");

                    /*" -1217- GO TO 0200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                    return;

                    /*" -1218- ELSE */
                }
                else
                {


                    /*" -1222- IF HISCOBPR-IMPMORACID NOT GREATER ZEROS OR HISCOBPR-IMPINVPERM NOT GREATER ZEROS OR HISCOBPR-IMPSEGUR NOT GREATER ZEROS OR HISCOBPR-IMPSEGIND NOT GREATER ZEROS */

                    if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR <= 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND <= 00)
                    {

                        /*" -1223- MOVE 'S' TO TEM-ERRO-COBER */
                        _.Move("S", TEM_ERRO_COBER);

                        /*" -1224- DISPLAY 'TEM AP SEM IS - IP= ' PROPVA-NRCERTIF */
                        _.Display($"TEM AP SEM IS - IP= {PROPVA_NRCERTIF}");

                        /*" -1228- GO TO 0200-FIM. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1230- INITIALIZE PARAMETROS. */
            _.Initialize(
                PARAMETROS
            );

            /*" -1231- MOVE PROPVA-NUM-APOLICE TO LK710-APOLICE OF PARAMETROS. */
            _.Move(PROPVA_NUM_APOLICE, PARAMETROS.LK710_APOLICE);

            /*" -1235- MOVE PROPVA-CODSUBES TO LK710-SUBGRUPO OF PARAMETROS. */
            _.Move(PROPVA_CODSUBES, PARAMETROS.LK710_SUBGRUPO);

            /*" -1236- IF TEM-VG = 'S' */

            if (TEM_VG == "S")
            {

                /*" -1239- MOVE HISCOBPR-IMPSEGUR TO LK710-PU-MORTE-NATURAL OF PARAMETROS. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, PARAMETROS.LK710_PU_MORTE_NATURAL);
            }


            /*" -1240- IF TEM-AP = 'S' */

            if (TEM_AP == "S")
            {

                /*" -1243- MOVE HISCOBPR-IMPSEGUR TO LK710-PU-MORTE-ACIDENTAL OF PARAMETROS. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);
            }


            /*" -1244- IF TEM-IP = 'S' */

            if (TEM_IP == "S")
            {

                /*" -1251- MOVE HISCOBPR-IMPSEGUR TO LK710-PU-INV-PERMANENTE OF PARAMETROS. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, PARAMETROS.LK710_PU_INV_PERMANENTE);
            }


            /*" -1253- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -1254- IF LK710-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK710_RETURN_CODE != 00)
            {

                /*" -1255- DISPLAY '** PROBLEMA COM SUBROTINA VG0710S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0710S **");

                /*" -1256- DISPLAY 'APOLICE : ' PROPVA-NUM-APOLICE */
                _.Display($"APOLICE : {PROPVA_NUM_APOLICE}");

                /*" -1257- DISPLAY 'SUBGRUPO: ' PROPVA-CODSUBES */
                _.Display($"SUBGRUPO: {PROPVA_CODSUBES}");

                /*" -1258- DISPLAY 'CERTIF. : ' PROPVA-NRCERTIF */
                _.Display($"CERTIF. : {PROPVA_NRCERTIF}");

                /*" -1259- DISPLAY 'MENSAGEM DA VG0710S -> ' LK710-MENSAGEM */
                _.Display($"MENSAGEM DA VG0710S -> {PARAMETROS.LK710_MENSAGEM}");

                /*" -1261- DISPLAY 'COD.ERRO DA VG0710S -> ' LK710-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0710S -> {PARAMETROS.LK710_RETURN_CODE}");

                /*" -1263- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1267- DISPLAY 'VG0710S MN - ' LK710-CO-MORTE-NATURAL ' MA - ' LK710-CO-MORTE-ACIDENTAL ' IP - ' LK710-CO-INV-PERMANENTE. */

            $"VG0710S MN - {PARAMETROS.LK710_CO_MORTE_NATURAL} MA - {PARAMETROS.LK710_CO_MORTE_ACIDENTAL} IP - {PARAMETROS.LK710_CO_INV_PERMANENTE}"
            .Display();

            /*" -1268- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMP-MORNATU. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -1269- MOVE LK710-CO-MORTE-ACIDENTAL TO HISCOBPR-IMPMORACID. */
            _.Move(PARAMETROS.LK710_CO_MORTE_ACIDENTAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -1269- MOVE LK710-CO-INV-PERMANENTE TO HISCOBPR-IMPINVPERM. */
            _.Move(PARAMETROS.LK710_CO_INV_PERMANENTE, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

        }

        [StopWatch]
        /*" M-0200-VERIFICA-COBER-DB-SELECT-1 */
        public void M_0200_VERIFICA_COBER_DB_SELECT_1()
        {
            /*" -1113- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_AP , CARREGA_PRINCIPAL, CARREGA_CONJUGE , CARREGA_FILHOS , GARAN_ADIC_IEA , GARAN_ADIC_IPA , GARAN_ADIC_IPD , GARAN_ADIC_HD , TAXA_DESPESA_ADM , TAXA_IRB , LIM_CAP_MORNATU , LIM_CAP_MORACID , LIM_CAP_INVAPER INTO :CONDITEC-NUM-APOLICE , :CONDITEC-COD-SUBGRUPO , :CONDITEC-QTD-SAL-MORNATU , :CONDITEC-QTD-SAL-MORACID , :CONDITEC-QTD-SAL-INVPERM , :CONDITEC-TAXA-AP-MORACID , :CONDITEC-TAXA-AP-INVPERM , :CONDITEC-TAXA-AP-AMDS , :CONDITEC-TAXA-AP-DH , :CONDITEC-TAXA-AP-DIT , :CONDITEC-TAXA-AP , :CONDITEC-CARREGA-PRINCIPAL, :CONDITEC-CARREGA-CONJUGE , :CONDITEC-CARREGA-FILHOS , :CONDITEC-GARAN-ADIC-IEA , :CONDITEC-GARAN-ADIC-IPA , :CONDITEC-GARAN-ADIC-IPD , :CONDITEC-GARAN-ADIC-HD , :CONDITEC-TAXA-DESPESA-ADM , :CONDITEC-TAXA-IRB , :CONDITEC-LIM-CAP-MORNATU , :CONDITEC-LIM-CAP-MORACID , :CONDITEC-LIM-CAP-INVAPER FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC. */

            var m_0200_VERIFICA_COBER_DB_SELECT_1_Query1 = new M_0200_VERIFICA_COBER_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0200_VERIFICA_COBER_DB_SELECT_1_Query1.Execute(m_0200_VERIFICA_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_NUM_APOLICE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_NUM_APOLICE);
                _.Move(executed_1.CONDITEC_COD_SUBGRUPO, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);
                _.Move(executed_1.CONDITEC_QTD_SAL_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU);
                _.Move(executed_1.CONDITEC_QTD_SAL_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID);
                _.Move(executed_1.CONDITEC_QTD_SAL_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM);
                _.Move(executed_1.CONDITEC_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID);
                _.Move(executed_1.CONDITEC_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM);
                _.Move(executed_1.CONDITEC_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS);
                _.Move(executed_1.CONDITEC_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH);
                _.Move(executed_1.CONDITEC_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT);
                _.Move(executed_1.CONDITEC_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP);
                _.Move(executed_1.CONDITEC_CARREGA_PRINCIPAL, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL);
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_HD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_HD);
                _.Move(executed_1.CONDITEC_TAXA_DESPESA_ADM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_DESPESA_ADM);
                _.Move(executed_1.CONDITEC_TAXA_IRB, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_IRB);
                _.Move(executed_1.CONDITEC_LIM_CAP_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORNATU);
                _.Move(executed_1.CONDITEC_LIM_CAP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORACID);
                _.Move(executed_1.CONDITEC_LIM_CAP_INVAPER, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_INVAPER);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-10 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_10()
        {
            /*" -979- EXEC SQL SELECT NUM_CERTIFICADO, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ, VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, COD_USUARIO, TIMESTAMP, VALUE(IMPSEGAUXF,0), VALUE(VLCUSTAUXF,0), VALUE(PRMDIT,0), VALUE(QTMDIT,0), DATA_INIVIGENCIA + 1 DAY INTO :HISCOBPR-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, :HISCOBPR-COD-USUARIO, :HISCOBPR-TIMESTAMP, :HISCOBPR-IMPSEGAUXF, :HISCOBPR-VLCUSTAUXF, :HISCOBPR-PRMDIT, :HISCOBPR-QTMDIT, :HISCOBPR-DTINIVIG-1DAY FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND OCORR_HISTORICO = :PROPVA-OCORHIST END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);
                _.Move(executed_1.HISCOBPR_COD_USUARIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);
                _.Move(executed_1.HISCOBPR_TIMESTAMP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_TIMESTAMP);
                _.Move(executed_1.HISCOBPR_IMPSEGAUXF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGAUXF);
                _.Move(executed_1.HISCOBPR_VLCUSTAUXF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF);
                _.Move(executed_1.HISCOBPR_PRMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
                _.Move(executed_1.HISCOBPR_DTINIVIG_1DAY, HISCOBPR_DTINIVIG_1DAY);
            }


        }

        [StopWatch]
        /*" M-0200-VERIFICA-COBER-DB-SELECT-2 */
        public void M_0200_VERIFICA_COBER_DB_SELECT_2()
        {
            /*" -1140- EXEC SQL SELECT VALUE(SUM(TAXA_VG),0) INTO :FAIXAETA-TAXA-VG FROM SEGUROS.FAIXA_ETARIA WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var m_0200_VERIFICA_COBER_DB_SELECT_2_Query1 = new M_0200_VERIFICA_COBER_DB_SELECT_2_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0200_VERIFICA_COBER_DB_SELECT_2_Query1.Execute(m_0200_VERIFICA_COBER_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXAETA_TAXA_VG, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0200-VERIFICA-COBER-DB-SELECT-3 */
        public void M_0200_VERIFICA_COBER_DB_SELECT_3()
        {
            /*" -1163- EXEC SQL SELECT VALUE(SUM(TAXA_VG),0) INTO :FAIXASAL-TAXA-VG FROM SEGUROS.FAIXA_SALARIAL WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC. */

            var m_0200_VERIFICA_COBER_DB_SELECT_3_Query1 = new M_0200_VERIFICA_COBER_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0200_VERIFICA_COBER_DB_SELECT_3_Query1.Execute(m_0200_VERIFICA_COBER_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXASAL_TAXA_VG, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG);
            }


        }

        [StopWatch]
        /*" M-0300-CORRIGE-IOF */
        private void M_0300_CORRIGE_IOF(bool isPerform = false)
        {
            /*" -1281- MOVE '0300-CORRIGE-IOF' TO PARAGRAFO. */
            _.Move("0300-CORRIGE-IOF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1283- MOVE 'UPDATE V0COBERPROPVA' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1284- IF V0RIND-PCIOF-ATU EQUAL V0RIND-PCIOF-ANT */

            if (V0RIND_PCIOF_ATU == V0RIND_PCIOF_ANT)
            {

                /*" -1286- GO TO 0300-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/ //GOTO
                return;
            }


            /*" -1287- IF V0RIND-PCIOF-ATU GREATER THAN V0RIND-PCIOF-ANT */

            if (V0RIND_PCIOF_ATU > V0RIND_PCIOF_ANT)
            {

                /*" -1288- MOVE 896 TO COD-OPERACAO */
                _.Move(896, COD_OPERACAO);

                /*" -1289- ELSE */
            }
            else
            {


                /*" -1293- MOVE 796 TO COD-OPERACAO. */
                _.Move(796, COD_OPERACAO);
            }


            /*" -1294- IF HISTSG-DTMOVTO-1DAY GREATER THAN HISCOBPR-DTINIVIG-1DAY */

            if (HISTSG_DTMOVTO_1DAY > HISCOBPR_DTINIVIG_1DAY)
            {

                /*" -1295- MOVE HISTSG-DTMOVTO-1DAY TO DATA-MOVIMENTO */
                _.Move(HISTSG_DTMOVTO_1DAY, DATA_MOVIMENTO);

                /*" -1296- ELSE */
            }
            else
            {


                /*" -1298- MOVE HISCOBPR-DTINIVIG-1DAY TO DATA-MOVIMENTO. */
                _.Move(HISCOBPR_DTINIVIG_1DAY, DATA_MOVIMENTO);
            }


            /*" -1300- IF DATA-MOVIMENTO GREATER THAN V0RIND-DATA-BASE NEXT SENTENCE */

            if (DATA_MOVIMENTO > V0RIND_DATA_BASE)
            {

                /*" -1301- ELSE */
            }
            else
            {


                /*" -1305- MOVE V0RIND-DATA-BASE TO DATA-MOVIMENTO. */
                _.Move(V0RIND_DATA_BASE, DATA_MOVIMENTO);
            }


            /*" -1311- PERFORM M_0300_CORRIGE_IOF_DB_UPDATE_1 */

            M_0300_CORRIGE_IOF_DB_UPDATE_1();

            /*" -1314- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1316- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1318- MOVE 'UPDATE V0COBERPROPVA - ANT' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA - ANT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1323- PERFORM M_0300_CORRIGE_IOF_DB_UPDATE_2 */

            M_0300_CORRIGE_IOF_DB_UPDATE_2();

            /*" -1326- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1328- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1330- MOVE PROPVA-OCORHIST TO COBERP-OCORHIST-ANT. */
            _.Move(PROPVA_OCORHIST, COBERP_OCORHIST_ANT);

            /*" -1332- COMPUTE PROPVA-OCORHIST = PROPVA-OCORHIST + 1. */
            PROPVA_OCORHIST.Value = PROPVA_OCORHIST + 1;

            /*" -1334- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1342- PERFORM M_0300_CORRIGE_IOF_DB_UPDATE_3 */

            M_0300_CORRIGE_IOF_DB_UPDATE_3();

            /*" -1345- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1350- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1351- MOVE ZEROS TO WS-PRMADIC. */
            _.Move(0, WS_WORK_AREAS.WS_PRMADIC);

            /*" -1353- MOVE ZEROS TO WS-GUARDA-PRMADIC. */
            _.Move(0, WS_WORK_AREAS.WS_GUARDA_PRMADIC);

            /*" -1354- IF PRODVG-TEM-CDG = 'S' */

            if (PRODVG_TEM_CDG == "S")
            {

                /*" -1355- ADD HISCOBPR-VLCUSTCDG TO WS-PRMADIC */
                WS_WORK_AREAS.WS_PRMADIC.Value = WS_WORK_AREAS.WS_PRMADIC + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG;

                /*" -1357- ADD HISCOBPR-VLCUSTCDG TO WS-GUARDA-PRMADIC. */
                WS_WORK_AREAS.WS_GUARDA_PRMADIC.Value = WS_WORK_AREAS.WS_GUARDA_PRMADIC + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG;
            }


            /*" -1358- IF PRODVG-TEM-SAF = 'S' */

            if (PRODVG_TEM_SAF == "S")
            {

                /*" -1359- ADD HISCOBPR-VLCUSTAUXF TO WS-PRMADIC */
                WS_WORK_AREAS.WS_PRMADIC.Value = WS_WORK_AREAS.WS_PRMADIC + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF;

                /*" -1361- ADD HISCOBPR-VLCUSTAUXF TO WS-GUARDA-PRMADIC. */
                WS_WORK_AREAS.WS_GUARDA_PRMADIC.Value = WS_WORK_AREAS.WS_GUARDA_PRMADIC + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF;
            }


            /*" -1362- IF PRODVG-CUSTOCAP-TOTAL = 'S' */

            if (PRODVG_CUSTOCAP_TOTAL == "S")
            {

                /*" -1363- ADD HISCOBPR-VAL-CUSTO-CAPITALI TO WS-PRMADIC */
                WS_WORK_AREAS.WS_PRMADIC.Value = WS_WORK_AREAS.WS_PRMADIC + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI;

                /*" -1364- ADD HISCOBPR-VAL-CUSTO-CAPITALI TO WS-GUARDA-PRMADIC */
                WS_WORK_AREAS.WS_GUARDA_PRMADIC.Value = WS_WORK_AREAS.WS_GUARDA_PRMADIC + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI;

                /*" -1365- ELSE */
            }
            else
            {


                /*" -1368- COMPUTE WS-PRMADIC = WS-PRMADIC + (HISCOBPR-VAL-CUSTO-CAPITALI * HISCOBPR-QTDE-TIT-CAPITALIZ) */
                WS_WORK_AREAS.WS_PRMADIC.Value = WS_WORK_AREAS.WS_PRMADIC + (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI * HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);

                /*" -1374- COMPUTE WS-GUARDA-PRMADIC = WS-GUARDA-PRMADIC + (HISCOBPR-VAL-CUSTO-CAPITALI * HISCOBPR-QTDE-TIT-CAPITALIZ). */
                WS_WORK_AREAS.WS_GUARDA_PRMADIC.Value = WS_WORK_AREAS.WS_GUARDA_PRMADIC + (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI * HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
            }


            /*" -1376- COMPUTE COBERP-PRMVG-ATU ROUNDED = HISCOBPR-PRMVG / V0RIND-PCIOF-ANT. */
            COBERP_PRMVG_ATU.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG / V0RIND_PCIOF_ANT;

            /*" -1378- COMPUTE COBERP-PRMAP-ATU ROUNDED = HISCOBPR-PRMAP / V0RIND-PCIOF-ANT. */
            COBERP_PRMAP_ATU.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP / V0RIND_PCIOF_ANT;

            /*" -1381- COMPUTE COBERP-PRMDIT-ATU ROUNDED = HISCOBPR-PRMDIT / V0RIND-PCIOF-ANT. */
            COBERP_PRMDIT_ATU.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT / V0RIND_PCIOF_ANT;

            /*" -1383- COMPUTE COBERP-PRMVG-ATU ROUNDED = COBERP-PRMVG-ATU * V0RIND-PCIOF-ATU. */
            COBERP_PRMVG_ATU.Value = COBERP_PRMVG_ATU * V0RIND_PCIOF_ATU;

            /*" -1385- COMPUTE COBERP-PRMAP-ATU ROUNDED = COBERP-PRMAP-ATU * V0RIND-PCIOF-ATU. */
            COBERP_PRMAP_ATU.Value = COBERP_PRMAP_ATU * V0RIND_PCIOF_ATU;

            /*" -1391- COMPUTE COBERP-PRMDIT-ATU ROUNDED = COBERP-PRMDIT-ATU * V0RIND-PCIOF-ATU. */
            COBERP_PRMDIT_ATU.Value = COBERP_PRMDIT_ATU * V0RIND_PCIOF_ATU;

            /*" -1392- IF PRODVG-COBERADIC-PREMIO = 'S' */

            if (PRODVG_COBERADIC_PREMIO == "S")
            {

                /*" -1394- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU */
                COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU;

                /*" -1395- ELSE */
            }
            else
            {


                /*" -1401- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU + WS-GUARDA-PRMADIC. */
                COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU + WS_WORK_AREAS.WS_GUARDA_PRMADIC;
            }


            /*" -1403- MOVE 'INSERT V0COBERPROPVA' TO COMANDO. */
            _.Move("INSERT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1464- PERFORM M_0300_CORRIGE_IOF_DB_INSERT_1 */

            M_0300_CORRIGE_IOF_DB_INSERT_1();

            /*" -1467- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1469- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1473- IF INDAGE < 0 OR INDOPR < 0 OR INDNUM < 0 OR INDDIG < 0 */

            if (INDAGE < 0 || INDOPR < 0 || INDNUM < 0 || INDDIG < 0)
            {

                /*" -1474- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -1475- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -1476- ELSE */
            }
            else
            {


                /*" -1477- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -1478- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -1479- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -1480- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -1482- MOVE W01A0100 TO MDAC-CTA-CORRENTE. */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);
            }


            /*" -1484- MOVE 'SELECT V0FONTE' TO COMANDO. */
            _.Move("SELECT V0FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1489- PERFORM M_0300_CORRIGE_IOF_DB_SELECT_1 */

            M_0300_CORRIGE_IOF_DB_SELECT_1();

            /*" -1492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1495- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1497- INITIALIZE PARAMETROS-702. */
            _.Initialize(
                PARAMETROS_702
            );

            /*" -1498- MOVE PROPVA-NUM-APOLICE TO LK-APOLICE. */
            _.Move(PROPVA_NUM_APOLICE, PARAMETROS_702.LK_APOLICE);

            /*" -1500- MOVE PROPVA-CODSUBES TO LK-SUBGRUPO. */
            _.Move(PROPVA_CODSUBES, PARAMETROS_702.LK_SUBGRUPO);

            /*" -1501- MOVE HISCOBPR-IMP-MORNATU TO LK-CO-MORTE-NATURAL */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, PARAMETROS_702.LK_CO_MORTE_NATURAL);

            /*" -1502- MOVE HISCOBPR-IMPMORACID TO LK-CO-MORTE-ACIDENTAL */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, PARAMETROS_702.LK_CO_MORTE_ACIDENTAL);

            /*" -1503- MOVE HISCOBPR-IMPINVPERM TO LK-CO-INV-PERMANENTE */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, PARAMETROS_702.LK_CO_INV_PERMANENTE);

            /*" -1504- MOVE ZEROS TO LK-CO-ASS-MEDICA */
            _.Move(0, PARAMETROS_702.LK_CO_ASS_MEDICA);

            /*" -1505- MOVE ZEROS TO LK-CO-DI-HOSPITALAR */
            _.Move(0, PARAMETROS_702.LK_CO_DI_HOSPITALAR);

            /*" -1507- MOVE HISCOBPR-IMPDIT TO LK-CO-DI-INTERNACAO */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, PARAMETROS_702.LK_CO_DI_INTERNACAO);

            /*" -1509- CALL 'VG0702S' USING PARAMETROS-702. */
            _.Call("VG0702S", PARAMETROS_702);

            /*" -1510- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS_702.LK_RETURN_CODE != 00)
            {

                /*" -1511- DISPLAY '** PROBLEMA COM SUBROTINA VG0702S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0702S **");

                /*" -1512- DISPLAY 'APOLICE : ' PROPVA-NUM-APOLICE */
                _.Display($"APOLICE : {PROPVA_NUM_APOLICE}");

                /*" -1513- DISPLAY 'SUBGRUPO: ' PROPVA-CODSUBES */
                _.Display($"SUBGRUPO: {PROPVA_CODSUBES}");

                /*" -1514- DISPLAY 'CERTIF. : ' PROPVA-NRCERTIF */
                _.Display($"CERTIF. : {PROPVA_NRCERTIF}");

                /*" -1515- DISPLAY 'MENSAGEM DA VG0702S -> ' LK-MENSAGEM */
                _.Display($"MENSAGEM DA VG0702S -> {PARAMETROS_702.LK_MENSAGEM}");

                /*" -1517- DISPLAY 'COD.ERRO DA VG0702S -> ' LK-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0702S -> {PARAMETROS_702.LK_RETURN_CODE}");

                /*" -1523- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1523- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

        }

        [StopWatch]
        /*" M-0300-CORRIGE-IOF-DB-UPDATE-1 */
        public void M_0300_CORRIGE_IOF_DB_UPDATE_1()
        {
            /*" -1311- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = :DATA-MOVIMENTO, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_0300_CORRIGE_IOF_DB_UPDATE_1_Update1 = new M_0300_CORRIGE_IOF_DB_UPDATE_1_Update1()
            {
                DATA_MOVIMENTO = DATA_MOVIMENTO.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_0300_CORRIGE_IOF_DB_UPDATE_1_Update1.Execute(m_0300_CORRIGE_IOF_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM */
        private void M_0300_PROPAUTOM(bool isPerform = false)
        {
            /*" -1528- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1532- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -1534- MOVE SPACES TO SEGURA-LOT-EMP-SEGURADO. */
            _.Move("", SEGURA_LOT_EMP_SEGURADO);

            /*" -1536- MOVE 'INSERT V0MOVIMENTO 1' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1613- PERFORM M_0300_PROPAUTOM_DB_INSERT_1 */

            M_0300_PROPAUTOM_DB_INSERT_1();

            /*" -1616- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1617- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1618- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1619- DISPLAY 'VA0128B - PROPOSTA DUPLICADA NA V0MOVIMENTO' */
                    _.Display($"VA0128B - PROPOSTA DUPLICADA NA V0MOVIMENTO");

                    /*" -1620- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -1621- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -1622- GO TO 0300-PROPAUTOM */
                    new Task(() => M_0300_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1623- ELSE */
                }
                else
                {


                    /*" -1624- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1625- DISPLAY 'VA0128B - ERRO INSERT DA V0MOVIMENTO' */
                    _.Display($"VA0128B - ERRO INSERT DA V0MOVIMENTO");

                    /*" -1627- DISPLAY '          APOLICE..........  ' PROPVA-NUM-APOLICE */
                    _.Display($"          APOLICE..........  {PROPVA_NUM_APOLICE}");

                    /*" -1628- DISPLAY '          SUBGRUPO.........  ' PROPVA-CODSUBES */
                    _.Display($"          SUBGRUPO.........  {PROPVA_CODSUBES}");

                    /*" -1629- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -1630- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -1631- DISPLAY '          CERTIFICADO......  ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO......  {PROPVA_NRCERTIF}");

                    /*" -1632- DISPLAY '          SQLCODE..........  ' SQLCODE */
                    _.Display($"          SQLCODE..........  {DB.SQLCODE}");

                    /*" -1634- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1636- MOVE 'UPDATE V0FONTE' TO COMANDO. */
            _.Move("UPDATE V0FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1641- PERFORM M_0300_PROPAUTOM_DB_UPDATE_1 */

            M_0300_PROPAUTOM_DB_UPDATE_1();

            /*" -1644- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1646- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1648- ADD 1 TO AC-IOF. */
            WS_WORK_AREAS.AC_IOF.Value = WS_WORK_AREAS.AC_IOF + 1;

            /*" -1649- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -1653- PERFORM 0400-00-SELECT-V0COBERPROPVA. */

            M_0400_00_SELECT_V0COBERPROPVA_SECTION();

            /*" -1655- PERFORM 0410-00-DECLARE-VGHISTRAMCOB. */

            M_0410_00_DECLARE_VGHISTRAMCOB_SECTION();

            /*" -1657- PERFORM 0500-00-DECLARE-VGHISTACESSCOB. */

            M_0500_00_DECLARE_VGHISTACESSCOB_SECTION();

            /*" -1657- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1660- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1660- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-INSERT-1 */
        public void M_0300_PROPAUTOM_DB_INSERT_1()
        {
            /*" -1613- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , '4' , :PROPVA-CODCLIEN, 0, 0, 0, 0, :SEGURA-FAIXA, 'S' , 'S' , :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :PROPVA-AGECOBR, ' ' , 0, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :SEGURA-TXAPMA, :SEGURA-TXAPIP, :SEGURA-TXAPAMDS, :SEGURA-TXAPDH, :SEGURA-TXAPDIT, :SEGURA-TXVG, :LK-PU-MORTE-NATURAL, :LK-PU-MORTE-NATURAL, :LK-PU-MORTE-ACIDENTAL, :LK-PU-MORTE-ACIDENTAL, :LK-PU-INV-PERMANENTE, :LK-PU-INV-PERMANENTE, :LK-PU-ASS-MEDICA, :LK-PU-ASS-MEDICA, :LK-PU-DI-HOSPITALAR, :LK-PU-DI-HOSPITALAR, :LK-PU-DI-INTERNACAO, :LK-PU-DI-INTERNACAO, :HISCOBPR-PRMVG, :COBERP-PRMVG-ATU, :HISCOBPR-PRMAP, :COBERP-PRMAP-ATU, :COD-OPERACAO, :SISTEMA-DTMOVABE, 0, '1' , 'VA0128B' , :SISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :SISTEMA-DTMOVABE, :DATA-MOVIMENTO, NULL, :SEGURA-LOT-EMP-SEGURADO) END-EXEC. */

            var m_0300_PROPAUTOM_DB_INSERT_1_Insert1 = new M_0300_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                SEGURA_FAIXA = SEGURA_FAIXA.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                SEGURA_TXAPMA = SEGURA_TXAPMA.ToString(),
                SEGURA_TXAPIP = SEGURA_TXAPIP.ToString(),
                SEGURA_TXAPAMDS = SEGURA_TXAPAMDS.ToString(),
                SEGURA_TXAPDH = SEGURA_TXAPDH.ToString(),
                SEGURA_TXAPDIT = SEGURA_TXAPDIT.ToString(),
                SEGURA_TXVG = SEGURA_TXVG.ToString(),
                LK_PU_MORTE_NATURAL = PARAMETROS_702.LK_PU_MORTE_NATURAL.ToString(),
                LK_PU_MORTE_ACIDENTAL = PARAMETROS_702.LK_PU_MORTE_ACIDENTAL.ToString(),
                LK_PU_INV_PERMANENTE = PARAMETROS_702.LK_PU_INV_PERMANENTE.ToString(),
                LK_PU_ASS_MEDICA = PARAMETROS_702.LK_PU_ASS_MEDICA.ToString(),
                LK_PU_DI_HOSPITALAR = PARAMETROS_702.LK_PU_DI_HOSPITALAR.ToString(),
                LK_PU_DI_INTERNACAO = PARAMETROS_702.LK_PU_DI_INTERNACAO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                COD_OPERACAO = COD_OPERACAO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                DATA_MOVIMENTO = DATA_MOVIMENTO.ToString(),
                SEGURA_LOT_EMP_SEGURADO = SEGURA_LOT_EMP_SEGURADO.ToString(),
            };

            M_0300_PROPAUTOM_DB_INSERT_1_Insert1.Execute(m_0300_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-UPDATE-1 */
        public void M_0300_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -1641- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_0300_PROPAUTOM_DB_UPDATE_1_Update1 = new M_0300_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            M_0300_PROPAUTOM_DB_UPDATE_1_Update1.Execute(m_0300_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0300-CORRIGE-IOF-DB-UPDATE-2 */
        public void M_0300_CORRIGE_IOF_DB_UPDATE_2()
        {
            /*" -1323- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = DTTERVIG - 1 DAY WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_0300_CORRIGE_IOF_DB_UPDATE_2_Update1 = new M_0300_CORRIGE_IOF_DB_UPDATE_2_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_0300_CORRIGE_IOF_DB_UPDATE_2_Update1.Execute(m_0300_CORRIGE_IOF_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0300-CORRIGE-IOF-DB-INSERT-1 */
        public void M_0300_CORRIGE_IOF_DB_INSERT_1()
        {
            /*" -1464- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ, VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, COD_USUARIO, TIMESTAMP, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTMDIT) VALUES ( :PROPVA-NRCERTIF, :PROPVA-OCORHIST, :DATA-MOVIMENTO, '9999-12-31' , :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :COBERP-VLPREMIO-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ATU, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VA0128B' , CURRENT TIMESTAMP, :HISCOBPR-IMPSEGAUXF, :HISCOBPR-VLCUSTAUXF, :COBERP-PRMDIT-ATU, :HISCOBPR-QTMDIT) END-EXEC. */

            var m_0300_CORRIGE_IOF_DB_INSERT_1_Insert1 = new M_0300_CORRIGE_IOF_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                DATA_MOVIMENTO = DATA_MOVIMENTO.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_QUANT_VIDAS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND.ToString(),
                COD_OPERACAO = COD_OPERACAO.ToString(),
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT.ToString(),
                COBERP_VLPREMIO_ATU = COBERP_VLPREMIO_ATU.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG.ToString(),
                HISCOBPR_IMPSEGAUXF = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGAUXF.ToString(),
                HISCOBPR_VLCUSTAUXF = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF.ToString(),
                COBERP_PRMDIT_ATU = COBERP_PRMDIT_ATU.ToString(),
                HISCOBPR_QTMDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT.ToString(),
            };

            M_0300_CORRIGE_IOF_DB_INSERT_1_Insert1.Execute(m_0300_CORRIGE_IOF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0300-CORRIGE-IOF-DB-SELECT-1 */
        public void M_0300_CORRIGE_IOF_DB_SELECT_1()
        {
            /*" -1489- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_0300_CORRIGE_IOF_DB_SELECT_1_Query1 = new M_0300_CORRIGE_IOF_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_0300_CORRIGE_IOF_DB_SELECT_1_Query1.Execute(m_0300_CORRIGE_IOF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0300-CORRIGE-IOF-DB-UPDATE-3 */
        public void M_0300_CORRIGE_IOF_DB_UPDATE_3()
        {
            /*" -1342- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODOPER = :COD-OPERACAO, DTMOVTO = :DATA-MOVIMENTO, OCORHIST = :PROPVA-OCORHIST, SIT_INTERFACE = '0' , TIMESTAMP = CURRENT TIMESTAMP WHERE CURRENT OF CPROPVA END-EXEC. */

            var m_0300_CORRIGE_IOF_DB_UPDATE_3_Update1 = new M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1(CPROPVA)
            {
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                DATA_MOVIMENTO = DATA_MOVIMENTO.ToString(),
                COD_OPERACAO = COD_OPERACAO.ToString(),
            };

            M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1.Execute(m_0300_CORRIGE_IOF_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-0400-00-SELECT-V0COBERPROPVA-SECTION */
        private void M_0400_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -1727- PERFORM M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -1730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1731- DISPLAY '0400-00- ' PROPVA-NRCERTIF */
                _.Display($"0400-00- {PROPVA_NRCERTIF}");

                /*" -1733- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1733- COMPUTE COBERP-OCORHIST-ANT = COBERP-OCORHIST - 1. */
            COBERP_OCORHIST_ANT.Value = COBERP_OCORHIST - 1;

        }

        [StopWatch]
        /*" M-0400-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -1727- EXEC SQL SELECT NRCERTIF, OCORHIST, DTINIVIG, DTTERVIG, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, CODOPER, OPCAO_COBER, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDC, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :COBERP-NRCERTIF, :COBERP-OCORHIST, :COBERP-DTINIVIG, :COBERP-DTTERVIG, :COBERP-IMPSEGUR, :COBERP-QUANT-VIDAS, :COBERP-IMPSEGIND, :COBERP-CODOPER, :COBERP-OPCAO-COBER, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ATU, :COBERP-VLPREMIO-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ATU, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ATU:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(m_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_NRCERTIF, COBERP_NRCERTIF);
                _.Move(executed_1.COBERP_OCORHIST, COBERP_OCORHIST);
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_DTTERVIG, COBERP_DTTERVIG);
                _.Move(executed_1.COBERP_IMPSEGUR, COBERP_IMPSEGUR);
                _.Move(executed_1.COBERP_QUANT_VIDAS, COBERP_QUANT_VIDAS);
                _.Move(executed_1.COBERP_IMPSEGIND, COBERP_IMPSEGIND);
                _.Move(executed_1.COBERP_CODOPER, COBERP_CODOPER);
                _.Move(executed_1.COBERP_OPCAO_COBER, COBERP_OPCAO_COBER);
                _.Move(executed_1.COBERP_IMPMORNATU_ATU, COBERP_IMPMORNATU_ATU);
                _.Move(executed_1.COBERP_IMPMORACID_ATU, COBERP_IMPMORACID_ATU);
                _.Move(executed_1.COBERP_IMPINVPERM_ATU, COBERP_IMPINVPERM_ATU);
                _.Move(executed_1.COBERP_IMPAMDS_ATU, COBERP_IMPAMDS_ATU);
                _.Move(executed_1.COBERP_IMPDH_ATU, COBERP_IMPDH_ATU);
                _.Move(executed_1.COBERP_IMPDIT_ATU, COBERP_IMPDIT_ATU);
                _.Move(executed_1.COBERP_VLPREMIO_ATU, COBERP_VLPREMIO_ATU);
                _.Move(executed_1.COBERP_PRMVG_ATU, COBERP_PRMVG_ATU);
                _.Move(executed_1.COBERP_PRMAP_ATU, COBERP_PRMAP_ATU);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_VLTITCAP, COBERP_VLTITCAP);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IMPSEGAUXF_I, COBERP_IMPSEGAUXF_I);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF_I, COBERP_VLCUSTAUXF_I);
                _.Move(executed_1.COBERP_PRMDIT_ATU, COBERP_PRMDIT_ATU);
                _.Move(executed_1.COBERP_PRMDIT_I, COBERP_PRMDIT_I);
                _.Move(executed_1.COBERP_QTDIT, COBERP_QTDIT);
                _.Move(executed_1.COBERP_QTDIT_I, COBERP_QTDIT_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_99_FIM*/

        [StopWatch]
        /*" M-0410-00-DECLARE-VGHISTRAMCOB-SECTION */
        private void M_0410_00_DECLARE_VGHISTRAMCOB_SECTION()
        {
            /*" -1746- MOVE 'DECLARE VGHISRAMC' TO COMANDO. */
            _.Move("DECLARE VGHISRAMC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1760- PERFORM M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1 */

            M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1();

            /*" -1764- MOVE 'OPEN  VGHISRAMC' TO COMANDO. */
            _.Move("OPEN  VGHISRAMC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1764- PERFORM M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1 */

            M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1();

            /*" -1768- MOVE SPACES TO WFIM-VGHISRAMC. */
            _.Move("", WS_WORK_AREAS.WFIM_VGHISRAMC);

            /*" -1769- PERFORM 0420-00-FETCH-VG-HISTRAMCOB UNTIL WFIM-VGHISRAMC NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_VGHISRAMC.IsEmpty()))
            {

                M_0420_00_FETCH_VG_HISTRAMCOB_SECTION();
            }

        }

        [StopWatch]
        /*" M-0410-00-DECLARE-VGHISTRAMCOB-DB-OPEN-1 */
        public void M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1()
        {
            /*" -1764- EXEC SQL OPEN VGHISRAMC END-EXEC. */

            VGHISRAMC.Open();

        }

        [StopWatch]
        /*" M-0500-00-DECLARE-VGHISTACESSCOB-DB-DECLARE-1 */
        public void M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1()
        {
            /*" -1876- EXEC SQL DECLARE VGHISTACE CURSOR FOR SELECT NUM_CERTIFICADO, NUM_ACESSORIO, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_HIST_ACESS_COB WHERE NUM_CERTIFICADO = :COBERP-NRCERTIF AND OCORR_HISTORICO = :COBERP-OCORHIST-ANT ORDER BY NUM_ACESSORIO END-EXEC. */
            VGHISTACE = new VA0128B_VGHISTACE(true);
            string GetQuery_VGHISTACE()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_ACESSORIO
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_HIST_ACESS_COB 
							WHERE NUM_CERTIFICADO = '{COBERP_NRCERTIF}' 
							AND OCORR_HISTORICO = '{COBERP_OCORHIST_ANT}' 
							ORDER BY NUM_ACESSORIO";

                return query;
            }
            VGHISTACE.GetQueryEvent += GetQuery_VGHISTACE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0410_99_FIM*/

        [StopWatch]
        /*" M-0420-00-FETCH-VG-HISTRAMCOB-SECTION */
        private void M_0420_00_FETCH_VG_HISTRAMCOB_SECTION()
        {
            /*" -1778- MOVE '0420-00-FETCH-VG-HIST-RAMO-COB' TO COMANDO */
            _.Move("0420-00-FETCH-VG-HIST-RAMO-COB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1780- MOVE 'FETCH VGHISRAMC' TO COMANDO. */
            _.Move("FETCH VGHISRAMC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1789- PERFORM M_0420_00_FETCH_VG_HISTRAMCOB_DB_FETCH_1 */

            M_0420_00_FETCH_VG_HISTRAMCOB_DB_FETCH_1();

            /*" -1792- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1793- MOVE 'S' TO WFIM-VGHISRAMC */
                _.Move("S", WS_WORK_AREAS.WFIM_VGHISRAMC);

                /*" -1793- PERFORM M_0420_00_FETCH_VG_HISTRAMCOB_DB_CLOSE_1 */

                M_0420_00_FETCH_VG_HISTRAMCOB_DB_CLOSE_1();

                /*" -1796- GO TO 0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1796- PERFORM 0430-00-INSERT-VG-HISTRAMCOB. */

            M_0430_00_INSERT_VG_HISTRAMCOB_SECTION();

        }

        [StopWatch]
        /*" M-0420-00-FETCH-VG-HISTRAMCOB-DB-FETCH-1 */
        public void M_0420_00_FETCH_VG_HISTRAMCOB_DB_FETCH_1()
        {
            /*" -1789- EXEC SQL FETCH VGHISRAMC INTO :VGHISR-NRCERTIF, :VGHISR-NUM-RAMO, :VGHISR-NUM-COBERTURA, :VGHISR-QTD-COBERTURA, :VGHISR-IMPSEGURADA, :VGHISR-CUSTO, :VGHISR-PREMIO END-EXEC. */

            if (VGHISRAMC.Fetch())
            {
                _.Move(VGHISRAMC.VGHISR_NRCERTIF, VGHISR_NRCERTIF);
                _.Move(VGHISRAMC.VGHISR_NUM_RAMO, VGHISR_NUM_RAMO);
                _.Move(VGHISRAMC.VGHISR_NUM_COBERTURA, VGHISR_NUM_COBERTURA);
                _.Move(VGHISRAMC.VGHISR_QTD_COBERTURA, VGHISR_QTD_COBERTURA);
                _.Move(VGHISRAMC.VGHISR_IMPSEGURADA, VGHISR_IMPSEGURADA);
                _.Move(VGHISRAMC.VGHISR_CUSTO, VGHISR_CUSTO);
                _.Move(VGHISRAMC.VGHISR_PREMIO, VGHISR_PREMIO);
            }

        }

        [StopWatch]
        /*" M-0420-00-FETCH-VG-HISTRAMCOB-DB-CLOSE-1 */
        public void M_0420_00_FETCH_VG_HISTRAMCOB_DB_CLOSE_1()
        {
            /*" -1793- EXEC SQL CLOSE VGHISRAMC END-EXEC */

            VGHISRAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0420_99_SAIDA*/

        [StopWatch]
        /*" M-0430-00-INSERT-VG-HISTRAMCOB-SECTION */
        private void M_0430_00_INSERT_VG_HISTRAMCOB_SECTION()
        {
            /*" -1805- MOVE 'INSERT VG_HIST_RAMO_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_RAMO_COB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1806- IF VGHISR-NUM-RAMO EQUAL 82 */

            if (VGHISR_NUM_RAMO == 82)
            {

                /*" -1807- IF VGHISR-NUM-COBERTURA EQUAL 01 */

                if (VGHISR_NUM_COBERTURA == 01)
                {

                    /*" -1808- MOVE COBERP-IMPMORACID-ATU TO VGHISR-IMPSEGURADA */
                    _.Move(COBERP_IMPMORACID_ATU, VGHISR_IMPSEGURADA);

                    /*" -1810- MOVE COBERP-PRMAP-ATU TO VGHISR-CUSTO VGHISR-PREMIO */
                    _.Move(COBERP_PRMAP_ATU, VGHISR_CUSTO, VGHISR_PREMIO);

                    /*" -1811- ELSE */
                }
                else
                {


                    /*" -1812- IF VGHISR-NUM-COBERTURA EQUAL 02 */

                    if (VGHISR_NUM_COBERTURA == 02)
                    {

                        /*" -1813- MOVE COBERP-IMPINVPERM-ATU TO VGHISR-IMPSEGURADA */
                        _.Move(COBERP_IMPINVPERM_ATU, VGHISR_IMPSEGURADA);

                        /*" -1814- END-IF */
                    }


                    /*" -1815- IF VGHISR-NUM-COBERTURA EQUAL 03 */

                    if (VGHISR_NUM_COBERTURA == 03)
                    {

                        /*" -1816- MOVE COBERP-IMPAMDS-ATU TO VGHISR-IMPSEGURADA */
                        _.Move(COBERP_IMPAMDS_ATU, VGHISR_IMPSEGURADA);

                        /*" -1817- END-IF */
                    }


                    /*" -1818- IF VGHISR-NUM-COBERTURA EQUAL 04 */

                    if (VGHISR_NUM_COBERTURA == 04)
                    {

                        /*" -1819- MOVE COBERP-IMPDH-ATU TO VGHISR-IMPSEGURADA */
                        _.Move(COBERP_IMPDH_ATU, VGHISR_IMPSEGURADA);

                        /*" -1820- END-IF */
                    }


                    /*" -1821- IF VGHISR-NUM-COBERTURA EQUAL 05 */

                    if (VGHISR_NUM_COBERTURA == 05)
                    {

                        /*" -1822- MOVE COBERP-IMPDIT-ATU TO VGHISR-IMPSEGURADA */
                        _.Move(COBERP_IMPDIT_ATU, VGHISR_IMPSEGURADA);

                        /*" -1824- MOVE COBERP-PRMDIT-ATU TO VGHISR-CUSTO VGHISR-PREMIO */
                        _.Move(COBERP_PRMDIT_ATU, VGHISR_CUSTO, VGHISR_PREMIO);

                        /*" -1825- END-IF */
                    }


                    /*" -1827- IF VGHISR-NUM-COBERTURA EQUAL 06 NEXT SENTENCE */

                    if (VGHISR_NUM_COBERTURA == 06)
                    {

                        /*" -1828- END-IF */
                    }


                    /*" -1829- ELSE */
                }

            }
            else
            {


                /*" -1830- IF VGHISR-NUM-RAMO EQUAL 93 */

                if (VGHISR_NUM_RAMO == 93)
                {

                    /*" -1831- IF VGHISR-NUM-COBERTURA EQUAL 11 */

                    if (VGHISR_NUM_COBERTURA == 11)
                    {

                        /*" -1832- MOVE COBERP-IMPMORNATU-ATU TO VGHISR-IMPSEGURADA */
                        _.Move(COBERP_IMPMORNATU_ATU, VGHISR_IMPSEGURADA);

                        /*" -1834- MOVE COBERP-PRMVG-ATU TO VGHISR-CUSTO VGHISR-PREMIO */
                        _.Move(COBERP_PRMVG_ATU, VGHISR_CUSTO, VGHISR_PREMIO);

                        /*" -1835- END-IF */
                    }


                    /*" -1836- END-IF */
                }


                /*" -1838- END-IF */
            }


            /*" -1848- PERFORM M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1 */

            M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1();

            /*" -1851- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1851- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0430-00-INSERT-VG-HISTRAMCOB-DB-INSERT-1 */
        public void M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1()
        {
            /*" -1848- EXEC SQL INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES (:VGHISR-NRCERTIF, :COBERP-OCORHIST, :VGHISR-NUM-RAMO, :VGHISR-NUM-COBERTURA, :VGHISR-QTD-COBERTURA, :VGHISR-IMPSEGURADA, :VGHISR-CUSTO, :VGHISR-PREMIO) END-EXEC. */

            var m_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1 = new M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1()
            {
                VGHISR_NRCERTIF = VGHISR_NRCERTIF.ToString(),
                COBERP_OCORHIST = COBERP_OCORHIST.ToString(),
                VGHISR_NUM_RAMO = VGHISR_NUM_RAMO.ToString(),
                VGHISR_NUM_COBERTURA = VGHISR_NUM_COBERTURA.ToString(),
                VGHISR_QTD_COBERTURA = VGHISR_QTD_COBERTURA.ToString(),
                VGHISR_IMPSEGURADA = VGHISR_IMPSEGURADA.ToString(),
                VGHISR_CUSTO = VGHISR_CUSTO.ToString(),
                VGHISR_PREMIO = VGHISR_PREMIO.ToString(),
            };

            M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1.Execute(m_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0430_99_FIM*/

        [StopWatch]
        /*" M-0500-00-DECLARE-VGHISTACESSCOB-SECTION */
        private void M_0500_00_DECLARE_VGHISTACESSCOB_SECTION()
        {
            /*" -1864- MOVE 'DECLARE VGHISTACESSCOB' TO COMANDO. */
            _.Move("DECLARE VGHISTACESSCOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1876- PERFORM M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1 */

            M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1();

            /*" -1880- MOVE 'OPEN  VGHISTACE' TO COMANDO. */
            _.Move("OPEN  VGHISTACE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1880- PERFORM M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1 */

            M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1();

            /*" -1884- MOVE SPACES TO WFIM-VGHISTACE. */
            _.Move("", WS_WORK_AREAS.WFIM_VGHISTACE);

            /*" -1885- PERFORM 0510-00-FETCH-VG-HISTACESCOB UNTIL WFIM-VGHISTACE NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_VGHISTACE.IsEmpty()))
            {

                M_0510_00_FETCH_VG_HISTACESCOB_SECTION();
            }

        }

        [StopWatch]
        /*" M-0500-00-DECLARE-VGHISTACESSCOB-DB-OPEN-1 */
        public void M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1()
        {
            /*" -1880- EXEC SQL OPEN VGHISTACE END-EXEC. */

            VGHISTACE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_99_FIM*/

        [StopWatch]
        /*" M-0510-00-FETCH-VG-HISTACESCOB-SECTION */
        private void M_0510_00_FETCH_VG_HISTACESCOB_SECTION()
        {
            /*" -1894- MOVE '0510-00-FETCH-VG-HIST-ACESSORIO' TO COMANDO */
            _.Move("0510-00-FETCH-VG-HIST-ACESSORIO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1896- MOVE 'FETCH VGHISTACESSCOB' TO COMANDO. */
            _.Move("FETCH VGHISTACESSCOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1904- PERFORM M_0510_00_FETCH_VG_HISTACESCOB_DB_FETCH_1 */

            M_0510_00_FETCH_VG_HISTACESCOB_DB_FETCH_1();

            /*" -1907- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1908- MOVE 'S' TO WFIM-VGHISTACE */
                _.Move("S", WS_WORK_AREAS.WFIM_VGHISTACE);

                /*" -1908- PERFORM M_0510_00_FETCH_VG_HISTACESCOB_DB_CLOSE_1 */

                M_0510_00_FETCH_VG_HISTACESCOB_DB_CLOSE_1();

                /*" -1911- GO TO 0510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1911- PERFORM 0520-00-INSERT-VG-HISTACESCOB. */

            M_0520_00_INSERT_VG_HISTACESCOB_SECTION();

        }

        [StopWatch]
        /*" M-0510-00-FETCH-VG-HISTACESCOB-DB-FETCH-1 */
        public void M_0510_00_FETCH_VG_HISTACESCOB_DB_FETCH_1()
        {
            /*" -1904- EXEC SQL FETCH VGHISTACE INTO :VGHISA-NRCERTIF , :VGHISA-NUM-ACESSORIO, :VGHISA-QTD-COBERTURA, :VGHISA-IMPSEGURADA, :VGHISA-CUSTO, :VGHISA-PREMIO END-EXEC. */

            if (VGHISTACE.Fetch())
            {
                _.Move(VGHISTACE.VGHISA_NRCERTIF, VGHISA_NRCERTIF);
                _.Move(VGHISTACE.VGHISA_NUM_ACESSORIO, VGHISA_NUM_ACESSORIO);
                _.Move(VGHISTACE.VGHISA_QTD_COBERTURA, VGHISA_QTD_COBERTURA);
                _.Move(VGHISTACE.VGHISA_IMPSEGURADA, VGHISA_IMPSEGURADA);
                _.Move(VGHISTACE.VGHISA_CUSTO, VGHISA_CUSTO);
                _.Move(VGHISTACE.VGHISA_PREMIO, VGHISA_PREMIO);
            }

        }

        [StopWatch]
        /*" M-0510-00-FETCH-VG-HISTACESCOB-DB-CLOSE-1 */
        public void M_0510_00_FETCH_VG_HISTACESCOB_DB_CLOSE_1()
        {
            /*" -1908- EXEC SQL CLOSE VGHISTACE END-EXEC */

            VGHISTACE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_99_SAIDA*/

        [StopWatch]
        /*" M-0520-00-INSERT-VG-HISTACESCOB-SECTION */
        private void M_0520_00_INSERT_VG_HISTACESCOB_SECTION()
        {
            /*" -1922- MOVE 'INSERT VG_HIST_ACESS_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_ACESS_COB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1923- IF VGHISA-NUM-ACESSORIO EQUAL 05 */

            if (VGHISA_NUM_ACESSORIO == 05)
            {

                /*" -1925- COMPUTE VGHISA-IMPSEGURADA ROUNDED = VGHISA-IMPSEGURADA * 1 */
                VGHISA_IMPSEGURADA.Value = VGHISA_IMPSEGURADA * 1;

                /*" -1927- COMPUTE VGHISA-PREMIO ROUNDED = VGHISA-PREMIO * 1 */
                VGHISA_PREMIO.Value = VGHISA_PREMIO * 1;

                /*" -1929- COMPUTE VGHISA-CUSTO ROUNDED = VGHISA-CUSTO * 1 */
                VGHISA_CUSTO.Value = VGHISA_CUSTO * 1;

                /*" -1931- END-IF */
            }


            /*" -1940- PERFORM M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1 */

            M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1();

            /*" -1943- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1943- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0520-00-INSERT-VG-HISTACESCOB-DB-INSERT-1 */
        public void M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1()
        {
            /*" -1940- EXEC SQL INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES (:VGHISA-NRCERTIF, :COBERP-OCORHIST, :VGHISA-NUM-ACESSORIO, :VGHISA-QTD-COBERTURA, :VGHISA-IMPSEGURADA, :VGHISA-CUSTO, :VGHISA-PREMIO) END-EXEC. */

            var m_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1 = new M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1()
            {
                VGHISA_NRCERTIF = VGHISA_NRCERTIF.ToString(),
                COBERP_OCORHIST = COBERP_OCORHIST.ToString(),
                VGHISA_NUM_ACESSORIO = VGHISA_NUM_ACESSORIO.ToString(),
                VGHISA_QTD_COBERTURA = VGHISA_QTD_COBERTURA.ToString(),
                VGHISA_IMPSEGURADA = VGHISA_IMPSEGURADA.ToString(),
                VGHISA_CUSTO = VGHISA_CUSTO.ToString(),
                VGHISA_PREMIO = VGHISA_PREMIO.ToString(),
            };

            M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1.Execute(m_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0520_99_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA-SECTION */
        private void M_9000_FINALIZA_SECTION()
        {
            /*" -1950- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1951- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1951- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1954- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1955- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1956- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1957- DISPLAY 'CORRECOES - IOF      .......... ' AC-IOF. */
            _.Display($"CORRECOES - IOF      .......... {WS_WORK_AREAS.AC_IOF}");

            /*" -1958- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1959- DISPLAY 'DESPREZADOS - ' . */
            _.Display($"DESPREZADOS - ");

            /*" -1960- DISPLAY 'ALGUM ERRO DE COBERTURA    .... ' AC-COM-ERRO */
            _.Display($"ALGUM ERRO DE COBERTURA    .... {WS_WORK_AREAS.AC_COM_ERRO}");

            /*" -1961- DISPLAY 'SEGURADOS FORA DA DATA IOF .... ' AC-DESP-DATAIOF */
            _.Display($"SEGURADOS FORA DA DATA IOF .... {WS_WORK_AREAS.AC_DESP_DATAIOF}");

            /*" -1962- DISPLAY 'PRODUTO S/ AJUSTE PELO IOF .... ' AC-DESP-PRODUTO */
            _.Display($"PRODUTO S/ AJUSTE PELO IOF .... {WS_WORK_AREAS.AC_DESP_PRODUTO}");

            /*" -1963- DISPLAY 'MOVIMENTACAO PENDENTE ......... ' AC-DESP-MOVIM */
            _.Display($"MOVIMENTACAO PENDENTE ......... {WS_WORK_AREAS.AC_DESP_MOVIM}");

            /*" -1964- DISPLAY 'FATURA ABERTA ................. ' AC-DESP-FATURA */
            _.Display($"FATURA ABERTA ................. {WS_WORK_AREAS.AC_DESP_FATURA}");

            /*" -1965- DISPLAY 'AUMENTO/INCLUSAO ANTES DO IGP-M ' AC-DESP-IGPM */
            _.Display($"AUMENTO/INCLUSAO ANTES DO IGP-M {WS_WORK_AREAS.AC_DESP_IGPM}");

            /*" -1966- DISPLAY 'ALTERACOES ANTES DE 1 ANO:' . */
            _.Display($"ALTERACOES ANTES DE 1 ANO:");

            /*" -1967- DISPLAY '  AUMENTO ..................... ' AC-DESP-AUMENTO */
            _.Display($"  AUMENTO ..................... {WS_WORK_AREAS.AC_DESP_AUMENTO}");

            /*" -1968- DISPLAY '  VENDA ....................... ' AC-DESP-VENDA */
            _.Display($"  VENDA ....................... {WS_WORK_AREAS.AC_DESP_VENDA}");

            /*" -1969- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1969- DISPLAY '*** VA0128B *** TERMINO NORMAL' . */
            _.Display($"*** VA0128B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -1980- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1981- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1982- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1983- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -1985- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1987- DISPLAY '*** VA0128B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0128B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1987- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1990- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1991- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1991- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1994- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1995- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1996- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1997- DISPLAY 'CORRECOES PELO IOF   .......... ' AC-IOF. */
            _.Display($"CORRECOES PELO IOF   .......... {WS_WORK_AREAS.AC_IOF}");

            /*" -1999- DISPLAY ' ' */
            _.Display($" ");

            /*" -2000- DISPLAY 'FONTE.........  ' PROPVA-FONTE */
            _.Display($"FONTE.........  {PROPVA_FONTE}");

            /*" -2001- DISPLAY 'PROPOSTA......  ' FONTE-PROPAUTOM */
            _.Display($"PROPOSTA......  {FONTE_PROPAUTOM}");

            /*" -2002- DISPLAY 'CERTIFICADO...  ' PROPVA-NRCERTIF. */
            _.Display($"CERTIFICADO...  {PROPVA_NRCERTIF}");

            /*" -2003- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2005- DISPLAY '*** VA0128B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0128B *** ERRO DE EXECUCAO");

            /*" -2006- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2006- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}