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
using Sias.VidaAzul.DB2.VA0127B;

namespace Code
{
    public class VA0127B
    {
        public bool IsCall { get; set; }

        public VA0127B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  EFETUA CREDITO PELA REDUCAO DO IOF *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FREDERICO FONSECA.                 *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0127B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  22/09/2004                         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *          A L T E R A C O E    E F E T U A D A S                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
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
        /*"01  V0PARC-NRPARCEL                  PIC S9(4) COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V0PARC-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HOST-COUNT-CRED                  PIC S9(4) COMP.*/
        public IntBasis HOST_COUNT_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
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
        /*"01  DIFERENCA                        PIC S9(13)V99 VALUE ZEROS.*/
        public DoubleBasis DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFERENCAVG                      PIC S9(13)V99 VALUE ZEROS.*/
        public DoubleBasis DIFERENCAVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFERENCAAP                      PIC S9(13)V99 VALUE ZEROS.*/
        public DoubleBasis DIFERENCAAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  QUOCIENTE                        PIC  9(4) VALUE ZEROS.*/
        public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  RESTO                            PIC  9(4) VALUE ZEROS.*/
        public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  TEM-DIFERENCA                    PIC  X(1).*/
        public StringBasis TEM_DIFERENCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
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
        /*"01  V0HCTB-PREMIO200                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO200 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO200VG               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO200VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO200AP               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO200AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO400                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO400 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO400VG               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO400VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO400AP               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO400AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO500                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO500 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO500VG               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO500VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIO500AP               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIO500AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIOPAGO                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIOPAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIOPAGOVG              PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIOPAGOVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PREMIOPAGOAP              PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PREMIOPAGOAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  HOST-DIFVG                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_DIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  HOST-DIFAP                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_DIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
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
        /*"01  WS-WORK-AREAS.*/
        public VA0127B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0127B_WS_WORK_AREAS();
        public class VA0127B_WS_WORK_AREAS : VarBasis
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
            public VA0127B_W01A0100 W01A0100 { get; set; } = new VA0127B_W01A0100();
            public class VA0127B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03     TABELA-ULTIMOS-DIAS.*/
            public VA0127B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA0127B_TABELA_ULTIMOS_DIAS();
            public class VA0127B_TABELA_ULTIMOS_DIAS : VarBasis
            {
                /*"       05  FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                /*"    03     TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
            }
            private _REDEF_VA0127B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
            public _REDEF_VA0127B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
            {
                get { _tab_ultimos_dias = new _REDEF_VA0127B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
                set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
            }  //Redefines
            public class _REDEF_VA0127B_TAB_ULTIMOS_DIAS : VarBasis
            {
                /*"       05  TAB-DIA-MESES        OCCURS 12.*/
                public ListBasis<VA0127B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA0127B_TAB_DIA_MESES>(12);
                public class VA0127B_TAB_DIA_MESES : VarBasis
                {
                    /*"           10 TAB-ULT-DIA       PIC 9(002).*/
                    public IntBasis TAB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    03 W01DTSQL.*/

                    public VA0127B_TAB_DIA_MESES()
                    {
                        TAB_ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0127B_TAB_ULTIMOS_DIAS()
                {
                    TAB_DIA_MESES.ValueChanged += OnValueChanged;
                }

            }
            public VA0127B_W01DTSQL W01DTSQL { get; set; } = new VA0127B_W01DTSQL();
            public class VA0127B_W01DTSQL : VarBasis
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
            public VA0127B_W02DTSQL W02DTSQL { get; set; } = new VA0127B_W02DTSQL();
            public class VA0127B_W02DTSQL : VarBasis
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
            public VA0127B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA0127B_WS_CTA_CORRENTE_R();
            public class VA0127B_WS_CTA_CORRENTE_R : VarBasis
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
            /*"    03       WS-DATA-FIM             PIC  X(010).*/
            public StringBasis WS_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03       WS-DATA-INI             PIC  X(010).*/
            public StringBasis WS_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03       WS-DATA-INI-R REDEFINES WS-DATA-INI.*/
            private _REDEF_VA0127B_WS_DATA_INI_R _ws_data_ini_r { get; set; }
            public _REDEF_VA0127B_WS_DATA_INI_R WS_DATA_INI_R
            {
                get { _ws_data_ini_r = new _REDEF_VA0127B_WS_DATA_INI_R(); _.Move(WS_DATA_INI, _ws_data_ini_r); VarBasis.RedefinePassValue(WS_DATA_INI, _ws_data_ini_r, WS_DATA_INI); _ws_data_ini_r.ValueChanged += () => { _.Move(_ws_data_ini_r, WS_DATA_INI); }; return _ws_data_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_ini_r, WS_DATA_INI); }
            }  //Redefines
            public class _REDEF_VA0127B_WS_DATA_INI_R : VarBasis
            {
                /*"      05     WS-ANO-INI              PIC  9(004).*/
                public IntBasis WS_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-TRA-IN1              PIC  X(001).*/
                public StringBasis WS_TRA_IN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WS-MES-INI              PIC  9(002).*/
                public IntBasis WS_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05     WS-TRA-IN2              PIC  X(001).*/
                public StringBasis WS_TRA_IN2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      05     WS-DIA-INI              PIC  9(002).*/
                public IntBasis WS_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-INF             PIC  9(006).*/

                public _REDEF_VA0127B_WS_DATA_INI_R()
                {
                    WS_ANO_INI.ValueChanged += OnValueChanged;
                    WS_TRA_IN1.ValueChanged += OnValueChanged;
                    WS_MES_INI.ValueChanged += OnValueChanged;
                    WS_TRA_IN2.ValueChanged += OnValueChanged;
                    WS_DIA_INI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_INF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-INF-R REDEFINES WS-DATA-INF.*/
            private _REDEF_VA0127B_WS_DATA_INF_R _ws_data_inf_r { get; set; }
            public _REDEF_VA0127B_WS_DATA_INF_R WS_DATA_INF_R
            {
                get { _ws_data_inf_r = new _REDEF_VA0127B_WS_DATA_INF_R(); _.Move(WS_DATA_INF, _ws_data_inf_r); VarBasis.RedefinePassValue(WS_DATA_INF, _ws_data_inf_r, WS_DATA_INF); _ws_data_inf_r.ValueChanged += () => { _.Move(_ws_data_inf_r, WS_DATA_INF); }; return _ws_data_inf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_inf_r, WS_DATA_INF); }
            }  //Redefines
            public class _REDEF_VA0127B_WS_DATA_INF_R : VarBasis
            {
                /*"      05     WS-ANO-INF              PIC  9(004).*/
                public IntBasis WS_ANO_INF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-INF              PIC  9(002).*/
                public IntBasis WS_MES_INF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-SUP             PIC  9(006).*/

                public _REDEF_VA0127B_WS_DATA_INF_R()
                {
                    WS_ANO_INF.ValueChanged += OnValueChanged;
                    WS_MES_INF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_SUP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-SUP-R REDEFINES WS-DATA-SUP.*/
            private _REDEF_VA0127B_WS_DATA_SUP_R _ws_data_sup_r { get; set; }
            public _REDEF_VA0127B_WS_DATA_SUP_R WS_DATA_SUP_R
            {
                get { _ws_data_sup_r = new _REDEF_VA0127B_WS_DATA_SUP_R(); _.Move(WS_DATA_SUP, _ws_data_sup_r); VarBasis.RedefinePassValue(WS_DATA_SUP, _ws_data_sup_r, WS_DATA_SUP); _ws_data_sup_r.ValueChanged += () => { _.Move(_ws_data_sup_r, WS_DATA_SUP); }; return _ws_data_sup_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sup_r, WS_DATA_SUP); }
            }  //Redefines
            public class _REDEF_VA0127B_WS_DATA_SUP_R : VarBasis
            {
                /*"      05     WS-ANO-SUP              PIC  9(004).*/
                public IntBasis WS_ANO_SUP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-SUP              PIC  9(002).*/
                public IntBasis WS_MES_SUP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDATA1                  PIC  9(006).*/

                public _REDEF_VA0127B_WS_DATA_SUP_R()
                {
                    WS_ANO_SUP.ValueChanged += OnValueChanged;
                    WS_MES_SUP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDATA1-R REDEFINES WDATA1.*/
            private _REDEF_VA0127B_WDATA1_R _wdata1_r { get; set; }
            public _REDEF_VA0127B_WDATA1_R WDATA1_R
            {
                get { _wdata1_r = new _REDEF_VA0127B_WDATA1_R(); _.Move(WDATA1, _wdata1_r); VarBasis.RedefinePassValue(WDATA1, _wdata1_r, WDATA1); _wdata1_r.ValueChanged += () => { _.Move(_wdata1_r, WDATA1); }; return _wdata1_r; }
                set { VarBasis.RedefinePassValue(value, _wdata1_r, WDATA1); }
            }  //Redefines
            public class _REDEF_VA0127B_WDATA1_R : VarBasis
            {
                /*"      05     WDATA1-AA               PIC  9(004).*/
                public IntBasis WDATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WDATA1-MM               PIC  9(002).*/
                public IntBasis WDATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDTINIVIG               PIC  9(006).*/

                public _REDEF_VA0127B_WDATA1_R()
                {
                    WDATA1_AA.ValueChanged += OnValueChanged;
                    WDATA1_MM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDTINIVIG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDTINIVIG-R REDEFINES WDTINIVIG.*/
            private _REDEF_VA0127B_WDTINIVIG_R _wdtinivig_r { get; set; }
            public _REDEF_VA0127B_WDTINIVIG_R WDTINIVIG_R
            {
                get { _wdtinivig_r = new _REDEF_VA0127B_WDTINIVIG_R(); _.Move(WDTINIVIG, _wdtinivig_r); VarBasis.RedefinePassValue(WDTINIVIG, _wdtinivig_r, WDTINIVIG); _wdtinivig_r.ValueChanged += () => { _.Move(_wdtinivig_r, WDTINIVIG); }; return _wdtinivig_r; }
                set { VarBasis.RedefinePassValue(value, _wdtinivig_r, WDTINIVIG); }
            }  //Redefines
            public class _REDEF_VA0127B_WDTINIVIG_R : VarBasis
            {
                /*"      05     WAAINIVIG               PIC  9(004).*/
                public IntBasis WAAINIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WMMINIVIG               PIC  9(002).*/
                public IntBasis WMMINIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MAX             PIC  9(006).*/

                public _REDEF_VA0127B_WDTINIVIG_R()
                {
                    WAAINIVIG.ValueChanged += OnValueChanged;
                    WMMINIVIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MAX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MAX-R REDEFINES WS-DATA-MAX.*/
            private _REDEF_VA0127B_WS_DATA_MAX_R _ws_data_max_r { get; set; }
            public _REDEF_VA0127B_WS_DATA_MAX_R WS_DATA_MAX_R
            {
                get { _ws_data_max_r = new _REDEF_VA0127B_WS_DATA_MAX_R(); _.Move(WS_DATA_MAX, _ws_data_max_r); VarBasis.RedefinePassValue(WS_DATA_MAX, _ws_data_max_r, WS_DATA_MAX); _ws_data_max_r.ValueChanged += () => { _.Move(_ws_data_max_r, WS_DATA_MAX); }; return _ws_data_max_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_max_r, WS_DATA_MAX); }
            }  //Redefines
            public class _REDEF_VA0127B_WS_DATA_MAX_R : VarBasis
            {
                /*"      05     WS-ANO-MAX              PIC  9(004).*/
                public IntBasis WS_ANO_MAX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MAX              PIC  9(002).*/
                public IntBasis WS_MES_MAX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MIN             PIC  9(006).*/

                public _REDEF_VA0127B_WS_DATA_MAX_R()
                {
                    WS_ANO_MAX.ValueChanged += OnValueChanged;
                    WS_MES_MAX.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MIN-R REDEFINES WS-DATA-MIN.*/
            private _REDEF_VA0127B_WS_DATA_MIN_R _ws_data_min_r { get; set; }
            public _REDEF_VA0127B_WS_DATA_MIN_R WS_DATA_MIN_R
            {
                get { _ws_data_min_r = new _REDEF_VA0127B_WS_DATA_MIN_R(); _.Move(WS_DATA_MIN, _ws_data_min_r); VarBasis.RedefinePassValue(WS_DATA_MIN, _ws_data_min_r, WS_DATA_MIN); _ws_data_min_r.ValueChanged += () => { _.Move(_ws_data_min_r, WS_DATA_MIN); }; return _ws_data_min_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_min_r, WS_DATA_MIN); }
            }  //Redefines
            public class _REDEF_VA0127B_WS_DATA_MIN_R : VarBasis
            {
                /*"      05     WS-ANO-MIN              PIC  9(004).*/
                public IntBasis WS_ANO_MIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MIN              PIC  9(002).*/
                public IntBasis WS_MES_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       TABELA-IGPM.*/

                public _REDEF_VA0127B_WS_DATA_MIN_R()
                {
                    WS_ANO_MIN.ValueChanged += OnValueChanged;
                    WS_MES_MIN.ValueChanged += OnValueChanged;
                }

            }
            public VA0127B_TABELA_IGPM TABELA_IGPM { get; set; } = new VA0127B_TABELA_IGPM();
            public class VA0127B_TABELA_IGPM : VarBasis
            {
                /*"      05     FILLER            OCCURS 300 TIMES.*/
                public ListBasis<VA0127B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VA0127B_FILLER_1>(300);
                public class VA0127B_FILLER_1 : VarBasis
                {
                    /*"        10   TB-DATA-IGPM      PIC  9(006).*/
                    public IntBasis TB_DATA_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"        10   TB-DATA-IGPM-R REDEFINES TB-DATA-IGPM.*/
                    private _REDEF_VA0127B_TB_DATA_IGPM_R _tb_data_igpm_r { get; set; }
                    public _REDEF_VA0127B_TB_DATA_IGPM_R TB_DATA_IGPM_R
                    {
                        get { _tb_data_igpm_r = new _REDEF_VA0127B_TB_DATA_IGPM_R(); _.Move(TB_DATA_IGPM, _tb_data_igpm_r); VarBasis.RedefinePassValue(TB_DATA_IGPM, _tb_data_igpm_r, TB_DATA_IGPM); _tb_data_igpm_r.ValueChanged += () => { _.Move(_tb_data_igpm_r, TB_DATA_IGPM); }; return _tb_data_igpm_r; }
                        set { VarBasis.RedefinePassValue(value, _tb_data_igpm_r, TB_DATA_IGPM); }
                    }  //Redefines
                    public class _REDEF_VA0127B_TB_DATA_IGPM_R : VarBasis
                    {
                        /*"          15 TB-ANO-IGPM       PIC  9(004).*/
                        public IntBasis TB_ANO_IGPM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"          15 TB-MES-IGPM       PIC  9(002).*/
                        public IntBasis TB_MES_IGPM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        10   TB-VAL-IGPM       PIC S9(006)V9(9)  COMP-3.*/

                        public _REDEF_VA0127B_TB_DATA_IGPM_R()
                        {
                            TB_ANO_IGPM.ValueChanged += OnValueChanged;
                            TB_MES_IGPM.ValueChanged += OnValueChanged;
                        }

                    }
                    public DoubleBasis TB_VAL_IGPM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                    /*"    03 AC-LIDOS                      PIC  9(006)    VALUE  0.*/
                }
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-COM-ERRO                   PIC  9(006)    VALUE  0.*/
            public IntBasis AC_COM_ERRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-CANCELADOS                 PIC  9(006)    VALUE  0.*/
            public IntBasis AC_CANCELADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-AVERBADOS                  PIC  9(006)    VALUE  0.*/
            public IntBasis AC_AVERBADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-IOF                        PIC  9(006)    VALUE  0.*/
            public IntBasis AC_IOF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-SEG                    PIC  9(006)    VALUE  0.*/
            public IntBasis AC_SEM_SEG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-OPC                    PIC  9(006)    VALUE  0.*/
            public IntBasis AC_SEM_OPC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-IOF                    PIC  9(006)    VALUE  0.*/
            public IntBasis AC_SEM_IOF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-MOV                    PIC  9(006)    VALUE  0.*/
            public IntBasis AC_SEM_MOV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-DIF                    PIC  9(006)    VALUE  0.*/
            public IntBasis AC_SEM_DIF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-SEM-PARCELA                PIC  9(006)    VALUE  0.*/
            public IntBasis AC_SEM_PARCELA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-JA-TEM-CRED                PIC  9(006)    VALUE  0.*/
            public IntBasis AC_JA_TEM_CRED { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ANUAL                      PIC  9(006)    VALUE  0.*/
            public IntBasis AC_ANUAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-NAO-PAGOU                  PIC  9(006)    VALUE  0.*/
            public IntBasis AC_NAO_PAGOU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DIFERENCAS                 PIC  9(006)    VALUE  0.*/
            public IntBasis AC_DIFERENCAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-VALOR-DIF                  PIC S9(013)V99 VALUE  0.*/
            public DoubleBasis AC_VALOR_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03 AC-VALOR-DIF-EDT              PIC -------------0,99.*/
            public DoubleBasis AC_VALOR_DIF_EDT { get; set; } = new DoubleBasis(new PIC("9", "0", "-------------0V99."), 0);
            /*"01  WABEND.*/
        }
        public VA0127B_WABEND WABEND { get; set; } = new VA0127B_WABEND();
        public class VA0127B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VA0127B  '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0127B  ");
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
            public VA0127B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0127B_LOCALIZA_ABEND_1();
            public class VA0127B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15    FILLER                 PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15    PARAGRAFO              PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public VA0127B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0127B_LOCALIZA_ABEND_2();
            public class VA0127B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15    FILLER                 PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15    COMANDO                PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.DIFERPAR DIFERPAR { get; set; } = new Dclgens.DIFERPAR();
        public VA0127B_CPROPVA CPROPVA { get; set; } = new VA0127B_CPROPVA();
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
            /*" -419- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -421- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -423- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -426- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -427- DISPLAY '     PROGRAMA EM EXECUCAO VA0127B      ' */
            _.Display($"     PROGRAMA EM EXECUCAO VA0127B      ");

            /*" -428- DISPLAY '                                       ' */
            _.Display($"                                       ");

            /*" -429- DISPLAY 'VERSAO V.01 NSGD - 16/10/2014 ' */
            _.Display($"VERSAO V.01 NSGD - 16/10/2014 ");

            /*" -431- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -432- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -434- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -447- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -450- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -452- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -453- IF SISTEMA-DTMOVABE LESS '2004-09-01' */

            if (SISTEMA_DTMOVABE < "2004-09-01")
            {

                /*" -454- MOVE '2004-09-01' TO V0RIND-DTMOVTO */
                _.Move("2004-09-01", V0RIND_DTMOVTO);

                /*" -455- ELSE */
            }
            else
            {


                /*" -457- MOVE SISTEMA-DTMOVABE TO V0RIND-DTMOVTO. */
                _.Move(SISTEMA_DTMOVABE, V0RIND_DTMOVTO);
            }


            /*" -459- MOVE 'SELECT V0PARAMRAMO ' TO COMANDO. */
            _.Move("SELECT V0PARAMRAMO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -476- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -479- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -481- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -483- MOVE 'SELECT V0RAMOIND ATUAL ' TO COMANDO. */
            _.Move("SELECT V0RAMOIND ATUAL ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -498- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

            M_0000_PRINCIPAL_DB_SELECT_3();

            /*" -501- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -503- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -506- COMPUTE V0RIND-PCIOF-ATU = 1 + (RAMOCOMP-PCT-IOCC-RAMO / 100). */
            V0RIND_PCIOF_ATU.Value = 1 + (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f);

            /*" -508- MOVE RAMOCOMP-DATA-INIVIGENCIA TO V0RIND-DATA-BASE. */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA, V0RIND_DATA_BASE);

            /*" -510- MOVE 'SELECT V0RAMOIND ANTERIOR ' TO COMANDO. */
            _.Move("SELECT V0RAMOIND ANTERIOR ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -521- PERFORM M_0000_PRINCIPAL_DB_SELECT_4 */

            M_0000_PRINCIPAL_DB_SELECT_4();

            /*" -524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -526- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -529- COMPUTE V0RIND-PCIOF-ANT = 1 + (RAMOCOMP-PCT-IOCC-RAMO / 100). */
            V0RIND_PCIOF_ANT.Value = 1 + (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f);

            /*" -530- MOVE V0RIND-PCIOF-ANT TO PCIOF-ANT-DET. */
            _.Move(V0RIND_PCIOF_ANT, PCIOF_ANT_DET);

            /*" -532- MOVE V0RIND-PCIOF-ATU TO PCIOF-ATU-DET. */
            _.Move(V0RIND_PCIOF_ATU, PCIOF_ATU_DET);

            /*" -533- DISPLAY ' IOFS UTILIZADOS NO CALCULO ' . */
            _.Display($" IOFS UTILIZADOS NO CALCULO ");

            /*" -534- DISPLAY ' -------------------------- ' . */
            _.Display($" -------------------------- ");

            /*" -535- DISPLAY ' IOF ANTERIOR ' PCIOF-ANT-DET */
            _.Display($" IOF ANTERIOR {PCIOF_ANT_DET}");

            /*" -537- DISPLAY ' IOF ATUAL    ' PCIOF-ATU-DET. */
            _.Display($" IOF ATUAL    {PCIOF_ATU_DET}");

            /*" -538- IF V0RIND-PCIOF-ATU EQUAL V0RIND-PCIOF-ANT */

            if (V0RIND_PCIOF_ATU == V0RIND_PCIOF_ANT)
            {

                /*" -539- DISPLAY '--> NAO HOUVE MUDANCA DE ALIQUOTA <-- ' */
                _.Display($"--> NAO HOUVE MUDANCA DE ALIQUOTA <-- ");

                /*" -541- GO TO 0000-TERMINA. */

                M_0000_TERMINA(); //GOTO
                return;
            }


            /*" -542- MOVE V0RIND-DATA-BASE TO WS-DATA-INI. */
            _.Move(V0RIND_DATA_BASE, WS_WORK_AREAS.WS_DATA_INI);

            /*" -544- MOVE 01 TO WS-DIA-INI. */
            _.Move(01, WS_WORK_AREAS.WS_DATA_INI_R.WS_DIA_INI);

            /*" -546- MOVE 'SELECT DATA_FIM ' TO COMANDO. */
            _.Move("SELECT DATA_FIM ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -551- PERFORM M_0000_PRINCIPAL_DB_SELECT_5 */

            M_0000_PRINCIPAL_DB_SELECT_5();

            /*" -554- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -555- DISPLAY 'ERRO ACESSO DATA_FIM ' PROPVA-NRCERTIF */
                _.Display($"ERRO ACESSO DATA_FIM {PROPVA_NRCERTIF}");

                /*" -557- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -564- DISPLAY ' PERIODO PESQUISADO ' WS-DATA-INI ' A ' WS-DATA-FIM. */

            $" PERIODO PESQUISADO {WS_WORK_AREAS.WS_DATA_INI} A {WS_WORK_AREAS.WS_DATA_FIM}"
            .Display();

            /*" -566- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -593- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -596- DISPLAY '*** VA0127B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA0127B *** ABRINDO CURSOR ...");

            /*" -597- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -597- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -601- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -603- DISPLAY '*** VA0127B *** PROCESSANDO ...' . */
            _.Display($"*** VA0127B *** PROCESSANDO ...");

            /*" -604- PERFORM M-0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_GERA_DIFERENCA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -447- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DTMOVABE - 1 MONTH, DTMOVABE - 12 MONTH, DTMOVABE + 1 MONTH INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRENT, :SISTEMA-DTTERCOT, :SISTEMA-DTINICOT, :SISTEMA-DTMOV01M FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

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
            /*" -610- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -612- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -612- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -476- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, RAMO_SAUDE, RAMO_SA_INDV, RAMO_EDUCACAO, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-RAMO-SAUDE, :PARAMRAM-RAMO-SA-INDV, :PARAMRAM-RAMO-EDUCACAO, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WHERE 1 = 1 END-EXEC. */

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
            /*" -622- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -624- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -626- MOVE 'SELECT V0OPCAOPAGVA ' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -628- MOVE PROPVA-NRCERTIF TO OPCPAGVI-NUM-CERTIFICADO. */
            _.Move(PROPVA_NRCERTIF, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -639- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -642- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -643- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -644- ADD 1 TO AC-SEM-OPC */
                    WS_WORK_AREAS.AC_SEM_OPC.Value = WS_WORK_AREAS.AC_SEM_OPC + 1;

                    /*" -645- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -646- ELSE */
                }
                else
                {


                    /*" -648- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -649- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 12 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12)
            {

                /*" -650- ADD 1 TO AC-ANUAL */
                WS_WORK_AREAS.AC_ANUAL.Value = WS_WORK_AREAS.AC_ANUAL + 1;

                /*" -652- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -653- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '4' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "4")
            {

                /*" -654- ADD 1 TO AC-AVERBADOS */
                WS_WORK_AREAS.AC_AVERBADOS.Value = WS_WORK_AREAS.AC_AVERBADOS + 1;

                /*" -659- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -661- MOVE 'SELECT V0SEGURAVG 1' TO COMANDO. */
            _.Move("SELECT V0SEGURAVG 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -689- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -692- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -693- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -694- ADD 1 TO AC-SEM-SEG */
                    WS_WORK_AREAS.AC_SEM_SEG.Value = WS_WORK_AREAS.AC_SEM_SEG + 1;

                    /*" -695- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -696- ELSE */
                }
                else
                {


                    /*" -698- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -699- IF SEGURA-SIT-REGISTRO EQUAL '2' OR '9' */

            if (SEGURA_SIT_REGISTRO.In("2", "9"))
            {

                /*" -700- ADD 1 TO AC-CANCELADOS */
                WS_WORK_AREAS.AC_CANCELADOS.Value = WS_WORK_AREAS.AC_CANCELADOS + 1;

                /*" -702- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -704- MOVE 'SELECT V0HISTSEGVG MAX' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -706- MOVE 0 TO WS-TEVE-ALTERACAO. */
            _.Move(0, WS_WORK_AREAS.WS_TEVE_ALTERACAO);

            /*" -713- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

            /*" -716- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -718- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -719- IF HISTSG-OCORHIST EQUAL ZEROES */

            if (HISTSG_OCORHIST == 00)
            {

                /*" -720- ADD 1 TO AC-SEM-IOF */
                WS_WORK_AREAS.AC_SEM_IOF.Value = WS_WORK_AREAS.AC_SEM_IOF + 1;

                /*" -722- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -723- IF HISTSG-OCORHIST NOT EQUAL ZEROES */

            if (HISTSG_OCORHIST != 00)
            {

                /*" -724- MOVE 1 TO WS-TEVE-ALTERACAO */
                _.Move(1, WS_WORK_AREAS.WS_TEVE_ALTERACAO);

                /*" -725- MOVE 'SELECT V0HISTSEGVG 2 ' TO COMANDO */
                _.Move("SELECT V0HISTSEGVG 2 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -734- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

                /*" -736- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -737- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -738- ELSE */
                }
                else
                {


                    /*" -739- IF HISTSG-DTMOVTO-ANT NOT LESS V0RIND-DATA-BASE */

                    if (HISTSG_DTMOVTO_ANT >= V0RIND_DATA_BASE)
                    {

                        /*" -740- ADD 1 TO AC-IOF */
                        WS_WORK_AREAS.AC_IOF.Value = WS_WORK_AREAS.AC_IOF + 1;

                        /*" -741- ELSE */
                    }
                    else
                    {


                        /*" -745- GO TO 0100-NEXT. */

                        M_0100_NEXT(); //GOTO
                        return;
                    }

                }

            }


            /*" -747- MOVE 'SELECT V0PARCELVA   ' TO COMANDO. */
            _.Move("SELECT V0PARCELVA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -758- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -761- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -764- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -765- ADD 1 TO AC-SEM-PARCELA */
                    WS_WORK_AREAS.AC_SEM_PARCELA.Value = WS_WORK_AREAS.AC_SEM_PARCELA + 1;

                    /*" -766- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -767- ELSE */
                }
                else
                {


                    /*" -769- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -771- MOVE 'SELECT V0HITSCONTABILVA 200 ' TO COMANDO. */
            _.Move("SELECT V0HITSCONTABILVA 200 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -784- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

            /*" -787- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -790- DISPLAY 'FALHA NO CALCULO DO PAGTO - 200 ' PROPVA-NRCERTIF ' ' V0PARC-NRPARCEL */

                $"FALHA NO CALCULO DO PAGTO - 200 {PROPVA_NRCERTIF} {V0PARC_NRPARCEL}"
                .Display();

                /*" -792- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -794- MOVE 'SELECT V0HITSCONTABILVA 400 ' TO COMANDO. */
            _.Move("SELECT V0HITSCONTABILVA 400 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -807- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

            /*" -810- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -813- DISPLAY 'FALHA NO CALCULO DO PAGTO - 400 ' PROPVA-NRCERTIF ' ' V0PARC-NRPARCEL */

                $"FALHA NO CALCULO DO PAGTO - 400 {PROPVA_NRCERTIF} {V0PARC_NRPARCEL}"
                .Display();

                /*" -815- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -817- MOVE 'SELECT V0HITSCONTABILVA 500 ' TO COMANDO. */
            _.Move("SELECT V0HITSCONTABILVA 500 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -830- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_8 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_8();

            /*" -833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -836- DISPLAY 'FALHA NO CALCULO DO PAGTO - 500 ' PROPVA-NRCERTIF ' ' V0PARC-NRPARCEL */

                $"FALHA NO CALCULO DO PAGTO - 500 {PROPVA_NRCERTIF} {V0PARC_NRPARCEL}"
                .Display();

                /*" -838- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -846- COMPUTE V0HCTB-PREMIOPAGO = (V0HCTB-PREMIO200VG + V0HCTB-PREMIO200AP) - (V0HCTB-PREMIO400VG + V0HCTB-PREMIO400AP) - (V0HCTB-PREMIO500VG + V0HCTB-PREMIO500AP). */
            V0HCTB_PREMIOPAGO.Value = (V0HCTB_PREMIO200VG + V0HCTB_PREMIO200AP) - (V0HCTB_PREMIO400VG + V0HCTB_PREMIO400AP) - (V0HCTB_PREMIO500VG + V0HCTB_PREMIO500AP);

            /*" -851- COMPUTE V0HCTB-PREMIOPAGOVG = V0HCTB-PREMIO200VG - V0HCTB-PREMIO400VG - V0HCTB-PREMIO500VG. */
            V0HCTB_PREMIOPAGOVG.Value = V0HCTB_PREMIO200VG - V0HCTB_PREMIO400VG - V0HCTB_PREMIO500VG;

            /*" -856- COMPUTE V0HCTB-PREMIOPAGOAP = V0HCTB-PREMIO200AP - V0HCTB-PREMIO400AP - V0HCTB-PREMIO500AP. */
            V0HCTB_PREMIOPAGOAP.Value = V0HCTB_PREMIO200AP - V0HCTB_PREMIO400AP - V0HCTB_PREMIO500AP;

            /*" -857- IF V0HCTB-PREMIOPAGO NOT GREATER ZEROS */

            if (V0HCTB_PREMIOPAGO <= 00)
            {

                /*" -858- ADD 1 TO AC-NAO-PAGOU */
                WS_WORK_AREAS.AC_NAO_PAGOU.Value = WS_WORK_AREAS.AC_NAO_PAGOU + 1;

                /*" -862- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -864- MOVE 'SELECT V0DIFPARCELVA' TO COMANDO. */
            _.Move("SELECT V0DIFPARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -875- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_9 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_9();

            /*" -878- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -880- DISPLAY 'PROBLEMAS DE ACESSO NA V0DIFPARCELVA ' PROPVA-NRCERTIF ' ' V0PARC-NRPARCEL */

                $"PROBLEMAS DE ACESSO NA V0DIFPARCELVA {PROPVA_NRCERTIF} {V0PARC_NRPARCEL}"
                .Display();

                /*" -882- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -883- IF HOST-COUNT-CRED GREATER ZEROS */

            if (HOST_COUNT_CRED > 00)
            {

                /*" -886- ADD 1 TO AC-JA-TEM-CRED */
                WS_WORK_AREAS.AC_JA_TEM_CRED.Value = WS_WORK_AREAS.AC_JA_TEM_CRED + 1;

                /*" -890- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -892- MOVE 'SELECT V0COBERPROPVA - MAIOR OCORHIST' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA - MAIOR OCORHIST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -901- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_10 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_10();

            /*" -904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -906- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -907- IF HISCOBPR-OCORR-HISTORICO EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO == 00)
            {

                /*" -908- ADD 1 TO AC-SEM-MOV */
                WS_WORK_AREAS.AC_SEM_MOV.Value = WS_WORK_AREAS.AC_SEM_MOV + 1;

                /*" -910- DISPLAY 'SEGUR NAO POSSUI MOVIMENTO NO PERIODO INFORMADO ' PROPVA-NRCERTIF */
                _.Display($"SEGUR NAO POSSUI MOVIMENTO NO PERIODO INFORMADO {PROPVA_NRCERTIF}");

                /*" -912- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -914- MOVE 'SELECT V0COBERPROPVA PERIODO ' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA PERIODO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -980- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_11 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_11();

            /*" -983- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -984- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -985- DISPLAY 'ERRO ACESSO COBERPROP ' PROPVA-NRCERTIF */
                    _.Display($"ERRO ACESSO COBERPROP {PROPVA_NRCERTIF}");

                    /*" -986- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -987- ELSE */
                }
                else
                {


                    /*" -989- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -993- COMPUTE DIFERENCA ROUNDED = ((HISCOBPR-VLPREMIO / V0RIND-PCIOF-ATU * V0RIND-PCIOF-ANT) - HISCOBPR-VLPREMIO) * 1,02. */
            DIFERENCA.Value = ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO / V0RIND_PCIOF_ATU * V0RIND_PCIOF_ANT) - HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO) * 1.02;

            /*" -997- COMPUTE DIFERENCAVG ROUNDED = ((HISCOBPR-PRMVG / V0RIND-PCIOF-ATU * V0RIND-PCIOF-ANT) - HISCOBPR-PRMVG) * 1,02. */
            DIFERENCAVG.Value = ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG / V0RIND_PCIOF_ATU * V0RIND_PCIOF_ANT) - HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG) * 1.02;

            /*" -1002- COMPUTE DIFERENCAAP ROUNDED = ((HISCOBPR-PRMAP / V0RIND-PCIOF-ATU * V0RIND-PCIOF-ANT) - HISCOBPR-PRMAP) * 1,02. */
            DIFERENCAAP.Value = ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP / V0RIND_PCIOF_ATU * V0RIND_PCIOF_ANT) - HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP) * 1.02;

            /*" -1003- IF DIFERENCA LESS ZEROS */

            if (DIFERENCA < 00)
            {

                /*" -1005- COMPUTE DIFERENCA = DIFERENCA * -1. */
                DIFERENCA.Value = DIFERENCA * -1;
            }


            /*" -1006- IF DIFERENCAVG LESS ZEROS */

            if (DIFERENCAVG < 00)
            {

                /*" -1008- COMPUTE DIFERENCAVG = DIFERENCAVG * -1. */
                DIFERENCAVG.Value = DIFERENCAVG * -1;
            }


            /*" -1009- IF DIFERENCAAP LESS ZEROS */

            if (DIFERENCAAP < 00)
            {

                /*" -1011- COMPUTE DIFERENCAAP = DIFERENCAAP * -1. */
                DIFERENCAAP.Value = DIFERENCAAP * -1;
            }


            /*" -1013- COMPUTE DIFERENCAAP = DIFERENCA - DIFERENCAVG. */
            DIFERENCAAP.Value = DIFERENCA - DIFERENCAVG;

            /*" -1015- IF HISCOBPR-VLPREMIO LESS V0HCTB-PREMIOPAGO NEXT SENTENCE */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO < V0HCTB_PREMIOPAGO)
            {

                /*" -1016- ELSE */
            }
            else
            {


                /*" -1019- ADD 1 TO AC-SEM-DIF */
                WS_WORK_AREAS.AC_SEM_DIF.Value = WS_WORK_AREAS.AC_SEM_DIF + 1;

                /*" -1019- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -639- EXEC SQL SELECT PERI_PAGAMENTO, OPCAO_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO, :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -498- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_INIVIGENCIA - 1 DAY, PCT_IOCC_RAMO INTO :RAMOCOMP-DATA-INIVIGENCIA, :V0RIND-DTMOVTO-1DAY, :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :PARAMRAM-RAMO-VG AND DATA_INIVIGENCIA <= :V0RIND-DTMOVTO AND DATA_TERVIGENCIA >= :V0RIND-DTMOVTO END-EXEC. */

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
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -689- EXEC SQL SELECT NUM_ITEM, FAIXA, TAXA_VG, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, SIT_REGISTRO, LOT_EMP_SEGURADO, OCORR_HISTORICO INTO :SEGURA-NUM-ITEM, :SEGURA-FAIXA, :SEGURA-TXVG, :SEGURA-TXAPMA, :SEGURA-TXAPIP, :SEGURA-TXAPAMDS, :SEGURA-TXAPDH, :SEGURA-TXAPDIT, :SEGURA-SIT-REGISTRO, :SEGURA-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO, :SEGURA-OCORHIST FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_CERTIFICADO = :PROPVA-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
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
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -593- EXEC SQL DECLARE CPROPVA CURSOR WITH HOLD FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTPROXVEN, CODOPER, DTMOVTO, NUM_APOLICE, CODSUBES, OCORHIST, SIT_INTERFACE, TIMESTAMP, IDE_SEXO, ESTADO_CIVIL, DTQITBCO + 1 YEAR, DTQITBCO, IDADE FROM SEGUROS.V0PROPOSTAVA WHERE SITUACAO = '3' AND NUM_APOLICE <> 109300000635 WITH UR END-EXEC. */
            CPROPVA = new VA0127B_CPROPVA(false);
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
							WHERE SITUACAO = '3' 
							AND NUM_APOLICE <> 109300000635";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -713- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO),0) INTO :HISTSG-OCORHIST FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND COD_OPERACAO IN (796, 896) END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_OCORHIST, HISTSG_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -597- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -734- EXEC SQL SELECT DATA_MOVIMENTO, COD_OPERACAO INTO :HISTSG-DTMOVTO-ANT, :HISTSG-CODOPER FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :SEGURA-NUM-ITEM AND OCORR_HISTORICO = :HISTSG-OCORHIST END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SEGURA_NUM_ITEM = SEGURA_NUM_ITEM.ToString(),
                HISTSG_OCORHIST = HISTSG_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSG_DTMOVTO_ANT, HISTSG_DTMOVTO_ANT);
                _.Move(executed_1.HISTSG_CODOPER, HISTSG_CODOPER);
            }


        }

        [StopWatch]
        /*" M-0100-GERA-DIFERENCA */
        private void M_0100_GERA_DIFERENCA(bool isPerform = false)
        {
            /*" -1025- MOVE 'N' TO TEM-DIFERENCA. */
            _.Move("N", TEM_DIFERENCA);

            /*" -1028- MOVE ZEROS TO HOST-DIFVG HOST-DIFAP. */
            _.Move(0, HOST_DIFVG, HOST_DIFAP);

            /*" -1029- COMPUTE HOST-DIFVG = V0HCTB-PREMIOPAGOVG - HISCOBPR-PRMVG. */
            HOST_DIFVG.Value = V0HCTB_PREMIOPAGOVG - HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG;

            /*" -1032- COMPUTE HOST-DIFAP = V0HCTB-PREMIOPAGOAP - HISCOBPR-PRMAP. */
            HOST_DIFAP.Value = V0HCTB_PREMIOPAGOAP - HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -1034- IF HOST-DIFVG LESS ZEROS OR HOST-DIFAP LESS ZEROS */

            if (HOST_DIFVG < 00 || HOST_DIFAP < 00)
            {

                /*" -1036- DISPLAY ' ENCONTRADAS DIFERENCAS NEGATIVAS ' PROPVA-NRCERTIF */
                _.Display($" ENCONTRADAS DIFERENCAS NEGATIVAS {PROPVA_NRCERTIF}");

                /*" -1038- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -1040- IF HOST-DIFVG = ZEROS AND HOST-DIFAP = ZEROS */

            if (HOST_DIFVG == 00 && HOST_DIFAP == 00)
            {

                /*" -1042- DISPLAY ' ENCONTRADAS DIFERENCAS ZERADAS   ' PROPVA-NRCERTIF */
                _.Display($" ENCONTRADAS DIFERENCAS ZERADAS   {PROPVA_NRCERTIF}");

                /*" -1044- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -1045- IF HOST-DIFVG GREATER DIFERENCAVG */

            if (HOST_DIFVG > DIFERENCAVG)
            {

                /*" -1046- MOVE 'S' TO TEM-DIFERENCA */
                _.Move("S", TEM_DIFERENCA);

                /*" -1049- DISPLAY 'DIFERENCA VG MAIOR QUE A ESPERADA ' HOST-DIFVG ' ' DIFERENCAVG ' ' PROPVA-NRCERTIF */

                $"DIFERENCA VG MAIOR QUE A ESPERADA {HOST_DIFVG} {DIFERENCAVG} {PROPVA_NRCERTIF}"
                .Display();

                /*" -1051- MOVE DIFERENCAVG TO HOST-DIFVG. */
                _.Move(DIFERENCAVG, HOST_DIFVG);
            }


            /*" -1052- IF HOST-DIFAP GREATER DIFERENCAAP */

            if (HOST_DIFAP > DIFERENCAAP)
            {

                /*" -1053- MOVE 'S' TO TEM-DIFERENCA */
                _.Move("S", TEM_DIFERENCA);

                /*" -1056- DISPLAY 'DIFERENCA AP MAIOR QUE A ESPERADA ' HOST-DIFAP ' ' DIFERENCAAP ' ' PROPVA-NRCERTIF */

                $"DIFERENCA AP MAIOR QUE A ESPERADA {HOST_DIFAP} {DIFERENCAAP} {PROPVA_NRCERTIF}"
                .Display();

                /*" -1059- MOVE DIFERENCAAP TO HOST-DIFAP. */
                _.Move(DIFERENCAAP, HOST_DIFAP);
            }


            /*" -1061- MOVE 'INSERT DIFPARCEL ' TO COMANDO */
            _.Move("INSERT DIFPARCEL ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1062- MOVE PROPVA-NRCERTIF TO DIFERPAR-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_NUM_CERTIFICADO);

            /*" -1063- MOVE 9999 TO DIFERPAR-NUM-PARCELA */
            _.Move(9999, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_NUM_PARCELA);

            /*" -1064- MOVE V0PARC-NRPARCEL TO DIFERPAR-NUM-PARCELA-DIF */
            _.Move(V0PARC_NRPARCEL, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_NUM_PARCELA_DIF);

            /*" -1065- MOVE 696 TO DIFERPAR-COD-OPERACAO */
            _.Move(696, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_COD_OPERACAO);

            /*" -1066- MOVE V0PARC-DTVENCTO TO DIFERPAR-DATA-VENCIMENTO */
            _.Move(V0PARC_DTVENCTO, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_DATA_VENCIMENTO);

            /*" -1067- MOVE HISCOBPR-PRMVG TO DIFERPAR-PRMDEVVG */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDEVVG);

            /*" -1068- MOVE HISCOBPR-PRMAP TO DIFERPAR-PRMDEVAP */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDEVAP);

            /*" -1069- MOVE V0HCTB-PREMIOPAGOVG TO DIFERPAR-PRMPAGVG */
            _.Move(V0HCTB_PREMIOPAGOVG, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMPAGVG);

            /*" -1070- MOVE V0HCTB-PREMIOPAGOAP TO DIFERPAR-PRMPAGAP */
            _.Move(V0HCTB_PREMIOPAGOAP, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMPAGAP);

            /*" -1071- MOVE HOST-DIFVG TO DIFERPAR-PRMDIFVG */
            _.Move(HOST_DIFVG, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDIFVG);

            /*" -1072- MOVE HOST-DIFAP TO DIFERPAR-PRMDIFAP */
            _.Move(HOST_DIFAP, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDIFAP);

            /*" -1073- MOVE ZEROS TO DIFERPAR-VAL-MULTA */
            _.Move(0, DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_VAL_MULTA);

            /*" -1075- MOVE SPACES TO DIFERPAR-SITUACAO */
            _.Move("", DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_SITUACAO);

            /*" -1104- PERFORM M_0100_GERA_DIFERENCA_DB_INSERT_1 */

            M_0100_GERA_DIFERENCA_DB_INSERT_1();

            /*" -1107- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1108- DISPLAY '0100 - PROBLEMAS INSERT DIFERPAR       ..' */
                _.Display($"0100 - PROBLEMAS INSERT DIFERPAR       ..");

                /*" -1110- DISPLAY 'SQLCODE - ' SQLCODE ' ' PROPVA-NRCERTIF ' ' V0PARC-NRPARCEL */

                $"SQLCODE - {DB.SQLCODE} {PROPVA_NRCERTIF} {V0PARC_NRPARCEL}"
                .Display();

                /*" -1112- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1113- ADD 1 TO AC-DIFERENCAS. */
            WS_WORK_AREAS.AC_DIFERENCAS.Value = WS_WORK_AREAS.AC_DIFERENCAS + 1;

            /*" -1114- ADD HOST-DIFVG TO AC-VALOR-DIF. */
            WS_WORK_AREAS.AC_VALOR_DIF.Value = WS_WORK_AREAS.AC_VALOR_DIF + HOST_DIFVG;

            /*" -1116- ADD HOST-DIFAP TO AC-VALOR-DIF. */
            WS_WORK_AREAS.AC_VALOR_DIF.Value = WS_WORK_AREAS.AC_VALOR_DIF + HOST_DIFAP;

            /*" -1116- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" M-0100-GERA-DIFERENCA-DB-INSERT-1 */
        public void M_0100_GERA_DIFERENCA_DB_INSERT_1()
        {
            /*" -1104- EXEC SQL INSERT INTO SEGUROS.DIFERENCA_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA , NUM_PARCELA_DIF, COD_OPERACAO , DATA_VENCIMENTO, PRMDEVVG , PRMDEVAP , PRMPAGVG , PRMPAGAP , PRMDIFVG , PRMDIFAP , VAL_MULTA , SITUACAO) VALUES (:DIFERPAR-NUM-CERTIFICADO, :DIFERPAR-NUM-PARCELA , :DIFERPAR-NUM-PARCELA-DIF, :DIFERPAR-COD-OPERACAO , :DIFERPAR-DATA-VENCIMENTO, :DIFERPAR-PRMDEVVG , :DIFERPAR-PRMDEVAP , :DIFERPAR-PRMPAGVG , :DIFERPAR-PRMPAGAP , :DIFERPAR-PRMDIFVG , :DIFERPAR-PRMDIFAP , :DIFERPAR-VAL-MULTA , :DIFERPAR-SITUACAO) END-EXEC */

            var m_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1 = new M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1()
            {
                DIFERPAR_NUM_CERTIFICADO = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_NUM_CERTIFICADO.ToString(),
                DIFERPAR_NUM_PARCELA = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_NUM_PARCELA.ToString(),
                DIFERPAR_NUM_PARCELA_DIF = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_NUM_PARCELA_DIF.ToString(),
                DIFERPAR_COD_OPERACAO = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_COD_OPERACAO.ToString(),
                DIFERPAR_DATA_VENCIMENTO = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_DATA_VENCIMENTO.ToString(),
                DIFERPAR_PRMDEVVG = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDEVVG.ToString(),
                DIFERPAR_PRMDEVAP = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDEVAP.ToString(),
                DIFERPAR_PRMPAGVG = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMPAGVG.ToString(),
                DIFERPAR_PRMPAGAP = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMPAGAP.ToString(),
                DIFERPAR_PRMDIFVG = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDIFVG.ToString(),
                DIFERPAR_PRMDIFAP = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_PRMDIFAP.ToString(),
                DIFERPAR_VAL_MULTA = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_VAL_MULTA.ToString(),
                DIFERPAR_SITUACAO = DIFERPAR.DCLDIFERENCA_PARCELVA.DIFERPAR_SITUACAO.ToString(),
            };

            M_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1.Execute(m_0100_GERA_DIFERENCA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -758- EXEC SQL SELECT NRPARCEL, DTVENCTO INTO :V0PARC-NRPARCEL, :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTVENCTO BETWEEN :WS-DATA-INI AND :WS-DATA-FIM AND SITUACAO IN ( '0' , '1' , ' ' ) END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                WS_DATA_INI = WS_WORK_AREAS.WS_DATA_INI.ToString(),
                WS_DATA_FIM = WS_WORK_AREAS.WS_DATA_FIM.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-4 */
        public void M_0000_PRINCIPAL_DB_SELECT_4()
        {
            /*" -521- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :PARAMRAM-RAMO-VG AND DATA_INIVIGENCIA <= :V0RIND-DTMOVTO-1DAY AND DATA_TERVIGENCIA >= :V0RIND-DTMOVTO-1DAY END-EXEC. */

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
            /*" -784- EXEC SQL SELECT VALUE(SUM(PRMVG),0), VALUE(SUM(PRMAP),0) INTO :V0HCTB-PREMIO200VG, :V0HCTB-PREMIO200AP FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND CODOPER BETWEEN 200 AND 299 END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_PREMIO200VG, V0HCTB_PREMIO200VG);
                _.Move(executed_1.V0HCTB_PREMIO200AP, V0HCTB_PREMIO200AP);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -1120- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -807- EXEC SQL SELECT VALUE(SUM(PRMVG),0), VALUE(SUM(PRMAP),0) INTO :V0HCTB-PREMIO400VG, :V0HCTB-PREMIO400AP FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND CODOPER BETWEEN 400 AND 499 END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_PREMIO400VG, V0HCTB_PREMIO400VG);
                _.Move(executed_1.V0HCTB_PREMIO400AP, V0HCTB_PREMIO400AP);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-5 */
        public void M_0000_PRINCIPAL_DB_SELECT_5()
        {
            /*" -551- EXEC SQL SELECT DATE(:WS-DATA-INI) + 1 MONTH - 1 DAY INTO :WS-DATA-FIM FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_5_Query1 = new M_0000_PRINCIPAL_DB_SELECT_5_Query1()
            {
                WS_DATA_INI = WS_WORK_AREAS.WS_DATA_INI.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_5_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_FIM, WS_WORK_AREAS.WS_DATA_FIM);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-8 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_8()
        {
            /*" -830- EXEC SQL SELECT VALUE(SUM(PRMVG),0), VALUE(SUM(PRMAP),0) INTO :V0HCTB-PREMIO500VG, :V0HCTB-PREMIO500AP FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND CODOPER BETWEEN 500 AND 599 END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_PREMIO500VG, V0HCTB_PREMIO500VG);
                _.Move(executed_1.V0HCTB_PREMIO500AP, V0HCTB_PREMIO500AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-9 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_9()
        {
            /*" -875- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT-CRED FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCELDIF = :V0PARC-NRPARCEL AND CODOPER BETWEEN 600 AND 699 AND DTVENCTO = :V0PARC-DTVENCTO END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT_CRED, HOST_COUNT_CRED);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -1131- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1133- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1156- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -1159- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1160- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1161- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -1162- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1162- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -1164- ELSE */
                }
                else
                {


                    /*" -1164- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -1156- EXEC SQL FETCH CPROPVA INTO :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTPROXVEN, :PROPVA-CODOPER, :PROPVA-DTMOVTO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-DTQITBCO-1YEAR, :PROPVA-DTQITBCO, :PROPVA-IDADE END-EXEC. */

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
            /*" -1162- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-10 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_10()
        {
            /*" -901- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO),0) INTO :HISCOBPR-OCORR-HISTORICO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND DATA_INIVIGENCIA BETWEEN :WS-DATA-INI AND :WS-DATA-FIM END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                WS_DATA_INI = WS_WORK_AREAS.WS_DATA_INI.ToString(),
                WS_DATA_FIM = WS_WORK_AREAS.WS_DATA_FIM.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-11 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_11()
        {
            /*" -980- EXEC SQL SELECT NUM_CERTIFICADO, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ, VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, COD_USUARIO, TIMESTAMP, VALUE(IMPSEGAUXF,0), VALUE(VLCUSTAUXF,0), VALUE(PRMDIT,0), VALUE(QTMDIT,0), DATA_INIVIGENCIA + 1 DAY INTO :HISCOBPR-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, :HISCOBPR-COD-USUARIO, :HISCOBPR-TIMESTAMP, :HISCOBPR-IMPSEGAUXF, :HISCOBPR-VLCUSTAUXF, :HISCOBPR-PRMDIT, :HISCOBPR-QTMDIT, :HISCOBPR-DTINIVIG-1DAY FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1);
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
        /*" M-9000-FINALIZA-SECTION */
        private void M_9000_FINALIZA_SECTION()
        {
            /*" -1172- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1173- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1173- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1177- MOVE AC-VALOR-DIF TO AC-VALOR-DIF-EDT. */
            _.Move(WS_WORK_AREAS.AC_VALOR_DIF, WS_WORK_AREAS.AC_VALOR_DIF_EDT);

            /*" -1178- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1197- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1198- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1198- DISPLAY '*** VA0127B *** TERMINO NORMAL' . */
            _.Display($"*** VA0127B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -1209- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1210- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1211- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1212- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -1214- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1216- DISPLAY '*** VA0127B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0127B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1216- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1219- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1220- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1220- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1223- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1224- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1225- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1226- DISPLAY 'PROCESSADOS (IOF) ............. ' AC-IOF. */
            _.Display($"PROCESSADOS (IOF) ............. {WS_WORK_AREAS.AC_IOF}");

            /*" -1228- DISPLAY ' ' */
            _.Display($" ");

            /*" -1229- DISPLAY 'CERTIFICADO...  ' PROPVA-NRCERTIF. */
            _.Display($"CERTIFICADO...  {PROPVA_NRCERTIF}");

            /*" -1230- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1232- DISPLAY '*** VA0127B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0127B *** ERRO DE EXECUCAO");

            /*" -1233- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1233- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}