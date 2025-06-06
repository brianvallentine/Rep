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
using Sias.VidaAzul.DB2.VA1184B;

namespace Code
{
    public class VA1184B
    {
        public bool IsCall { get; set; }

        public VA1184B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  ATUALIZA VALOR DE CUSTO DE CAPITA- *      */
        /*"      *                             LIZACAO NA V0COBERPROPVA E GERA    *      */
        /*"      *                             OPERACAO 799 NA V0MOVIMENTO EM FUN-*      */
        /*"      *                             CAO DO AJUSTE DE PREMIO DE CAPITA- *      */
        /*"      *                             LIZACAO.                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  MANOEL MESSIAS                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA1184B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  01/11/2000                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  INDAGE                           PIC S9(4) COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDOPR                           PIC S9(4) COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDNUM                           PIC S9(4) COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDDIG                           PIC S9(4) COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-IGPM                    PIC S9(4) COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  QUOCIENTE                        PIC  9(4) VALUE ZEROS.*/
        public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  RESTO                            PIC  9(4) VALUE ZEROS.*/
        public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  MOVIME-COUNT                     PIC S9(9) COMP.*/
        public IntBasis MOVIME_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PRODVG-COBERADIC                 PIC  X(01).*/
        public StringBasis PRODVG_COBERADIC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-CUSTOCAP                  PIC  X(01).*/
        public StringBasis PRODVG_CUSTOCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-ESTRCOBR                  PIC  X(10).*/
        public StringBasis PRODVG_ESTRCOBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-ARQFDCAP                  PIC S9(4) COMP.*/
        public IntBasis PRODVG_ARQFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-DTSOLICITACAO             PIC  X(10).*/
        public StringBasis RELATO_DTSOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  RELATO-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis RELATO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  RELATO-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis RELATO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis RELATO_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  RELATO-OPERACAO                  PIC S9(4) COMP.*/
        public IntBasis RELATO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-PCT-AUMENTO               PIC S9(03)V99 COMP-3.*/
        public DoubleBasis RELATO_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  RELATO-SITUACAO                  PIC  X(01).*/
        public StringBasis RELATO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
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
        /*"01  PROPVA-SITUACAO                  PIC  X(1).*/
        public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTQITBCO-1YEAR            PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"01  COBERP-DTINIVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTINIVIG1DAY              PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG1DAY { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"01  PRODVG-TEM-IGPM                  PIC  X(01).*/
        public StringBasis PRODVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-RAMO                      PIC S9(04) COMP.*/
        public IntBasis PRODVG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SEGURA-NUM-ITEM                  PIC S9(09) COMP.*/
        public IntBasis SEGURA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  SEGURA-SIT-REGISTRO              PIC  X(01).*/
        public StringBasis SEGURA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  SEGURA-DTINIVIG                  PIC  X(10).*/
        public StringBasis SEGURA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"01  SEGURA-LOT-EMP-SEGURADO          PIC  X(30).*/
        public StringBasis SEGURA_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  WLOT-EMP-SEGURADO                PIC S9(04) COMP.*/
        public IntBasis WLOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISTSG-DTMOVTO-1YEAR             PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  HISTSG-DTMOVTO                   PIC  X(10).*/
        public StringBasis HISTSG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"01  MNUM-CTA-CORRENTE                PIC S9(017)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
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
        public VA1184B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA1184B_WS_WORK_AREAS();
        public class VA1184B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOC                       PIC X VALUE SPACES.*/
            public StringBasis WS_EOC { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WPROCESSA                    PIC X VALUE SPACES.*/
            public StringBasis WPROCESSA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03  WS-TEVE-ALTERACAO              PIC 9 VALUE 0.*/
            public IntBasis WS_TEVE_ALTERACAO { get; set; } = new IntBasis(new PIC("9", "1", "9"));
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
            /*"    03  WS-PRMADIC-ANT               PIC S9(13)V99  COMP-3.*/
            public DoubleBasis WS_PRMADIC_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  WS-PRMADIC-ATU               PIC S9(13)V99  COMP-3.*/
            public DoubleBasis WS_PRMADIC_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03  W01A0100.*/
            public VA1184B_W01A0100 W01A0100 { get; set; } = new VA1184B_W01A0100();
            public class VA1184B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03     TABELA-ULTIMOS-DIAS.*/
            public VA1184B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA1184B_TABELA_ULTIMOS_DIAS();
            public class VA1184B_TABELA_ULTIMOS_DIAS : VarBasis
            {
                /*"       05  FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                /*"    03     TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
            }
            private _REDEF_VA1184B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
            public _REDEF_VA1184B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
            {
                get { _tab_ultimos_dias = new _REDEF_VA1184B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
                set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
            }  //Redefines
            public class _REDEF_VA1184B_TAB_ULTIMOS_DIAS : VarBasis
            {
                /*"       05  TAB-DIA-MESES        OCCURS 12.*/
                public ListBasis<VA1184B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA1184B_TAB_DIA_MESES>(12);
                public class VA1184B_TAB_DIA_MESES : VarBasis
                {
                    /*"           10 TAB-ULT-DIA       PIC 9(002).*/
                    public IntBasis TAB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    03 W01DTSQL.*/

                    public VA1184B_TAB_DIA_MESES()
                    {
                        TAB_ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA1184B_TAB_ULTIMOS_DIAS()
                {
                    TAB_DIA_MESES.ValueChanged += OnValueChanged;
                }

            }
            public VA1184B_W01DTSQL W01DTSQL { get; set; } = new VA1184B_W01DTSQL();
            public class VA1184B_W01DTSQL : VarBasis
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
            public VA1184B_W02DTSQL W02DTSQL { get; set; } = new VA1184B_W02DTSQL();
            public class VA1184B_W02DTSQL : VarBasis
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
            public VA1184B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA1184B_WS_CTA_CORRENTE_R();
            public class VA1184B_WS_CTA_CORRENTE_R : VarBasis
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
            private _REDEF_VA1184B_WS_DATA_INF_R _ws_data_inf_r { get; set; }
            public _REDEF_VA1184B_WS_DATA_INF_R WS_DATA_INF_R
            {
                get { _ws_data_inf_r = new _REDEF_VA1184B_WS_DATA_INF_R(); _.Move(WS_DATA_INF, _ws_data_inf_r); VarBasis.RedefinePassValue(WS_DATA_INF, _ws_data_inf_r, WS_DATA_INF); _ws_data_inf_r.ValueChanged += () => { _.Move(_ws_data_inf_r, WS_DATA_INF); }; return _ws_data_inf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_inf_r, WS_DATA_INF); }
            }  //Redefines
            public class _REDEF_VA1184B_WS_DATA_INF_R : VarBasis
            {
                /*"      05     WS-ANO-INF              PIC  9(004).*/
                public IntBasis WS_ANO_INF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-INF              PIC  9(002).*/
                public IntBasis WS_MES_INF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-SUP             PIC  9(006).*/

                public _REDEF_VA1184B_WS_DATA_INF_R()
                {
                    WS_ANO_INF.ValueChanged += OnValueChanged;
                    WS_MES_INF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_SUP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-SUP-R REDEFINES WS-DATA-SUP.*/
            private _REDEF_VA1184B_WS_DATA_SUP_R _ws_data_sup_r { get; set; }
            public _REDEF_VA1184B_WS_DATA_SUP_R WS_DATA_SUP_R
            {
                get { _ws_data_sup_r = new _REDEF_VA1184B_WS_DATA_SUP_R(); _.Move(WS_DATA_SUP, _ws_data_sup_r); VarBasis.RedefinePassValue(WS_DATA_SUP, _ws_data_sup_r, WS_DATA_SUP); _ws_data_sup_r.ValueChanged += () => { _.Move(_ws_data_sup_r, WS_DATA_SUP); }; return _ws_data_sup_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sup_r, WS_DATA_SUP); }
            }  //Redefines
            public class _REDEF_VA1184B_WS_DATA_SUP_R : VarBasis
            {
                /*"      05     WS-ANO-SUP              PIC  9(004).*/
                public IntBasis WS_ANO_SUP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-SUP              PIC  9(002).*/
                public IntBasis WS_MES_SUP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDATA1                  PIC  9(006).*/

                public _REDEF_VA1184B_WS_DATA_SUP_R()
                {
                    WS_ANO_SUP.ValueChanged += OnValueChanged;
                    WS_MES_SUP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDATA1-R REDEFINES WDATA1.*/
            private _REDEF_VA1184B_WDATA1_R _wdata1_r { get; set; }
            public _REDEF_VA1184B_WDATA1_R WDATA1_R
            {
                get { _wdata1_r = new _REDEF_VA1184B_WDATA1_R(); _.Move(WDATA1, _wdata1_r); VarBasis.RedefinePassValue(WDATA1, _wdata1_r, WDATA1); _wdata1_r.ValueChanged += () => { _.Move(_wdata1_r, WDATA1); }; return _wdata1_r; }
                set { VarBasis.RedefinePassValue(value, _wdata1_r, WDATA1); }
            }  //Redefines
            public class _REDEF_VA1184B_WDATA1_R : VarBasis
            {
                /*"      05     WDATA1-AA               PIC  9(004).*/
                public IntBasis WDATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WDATA1-MM               PIC  9(002).*/
                public IntBasis WDATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WDTINIVIG               PIC  9(006).*/

                public _REDEF_VA1184B_WDATA1_R()
                {
                    WDATA1_AA.ValueChanged += OnValueChanged;
                    WDATA1_MM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDTINIVIG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WDTINIVIG-R REDEFINES WDTINIVIG.*/
            private _REDEF_VA1184B_WDTINIVIG_R _wdtinivig_r { get; set; }
            public _REDEF_VA1184B_WDTINIVIG_R WDTINIVIG_R
            {
                get { _wdtinivig_r = new _REDEF_VA1184B_WDTINIVIG_R(); _.Move(WDTINIVIG, _wdtinivig_r); VarBasis.RedefinePassValue(WDTINIVIG, _wdtinivig_r, WDTINIVIG); _wdtinivig_r.ValueChanged += () => { _.Move(_wdtinivig_r, WDTINIVIG); }; return _wdtinivig_r; }
                set { VarBasis.RedefinePassValue(value, _wdtinivig_r, WDTINIVIG); }
            }  //Redefines
            public class _REDEF_VA1184B_WDTINIVIG_R : VarBasis
            {
                /*"      05     WAAINIVIG               PIC  9(004).*/
                public IntBasis WAAINIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WMMINIVIG               PIC  9(002).*/
                public IntBasis WMMINIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MAX             PIC  9(006).*/

                public _REDEF_VA1184B_WDTINIVIG_R()
                {
                    WAAINIVIG.ValueChanged += OnValueChanged;
                    WMMINIVIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MAX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MAX-R REDEFINES WS-DATA-MAX.*/
            private _REDEF_VA1184B_WS_DATA_MAX_R _ws_data_max_r { get; set; }
            public _REDEF_VA1184B_WS_DATA_MAX_R WS_DATA_MAX_R
            {
                get { _ws_data_max_r = new _REDEF_VA1184B_WS_DATA_MAX_R(); _.Move(WS_DATA_MAX, _ws_data_max_r); VarBasis.RedefinePassValue(WS_DATA_MAX, _ws_data_max_r, WS_DATA_MAX); _ws_data_max_r.ValueChanged += () => { _.Move(_ws_data_max_r, WS_DATA_MAX); }; return _ws_data_max_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_max_r, WS_DATA_MAX); }
            }  //Redefines
            public class _REDEF_VA1184B_WS_DATA_MAX_R : VarBasis
            {
                /*"      05     WS-ANO-MAX              PIC  9(004).*/
                public IntBasis WS_ANO_MAX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MAX              PIC  9(002).*/
                public IntBasis WS_MES_MAX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       WS-DATA-MIN             PIC  9(006).*/

                public _REDEF_VA1184B_WS_DATA_MAX_R()
                {
                    WS_ANO_MAX.ValueChanged += OnValueChanged;
                    WS_MES_MAX.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_MIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03       WS-DATA-MIN-R REDEFINES WS-DATA-MIN.*/
            private _REDEF_VA1184B_WS_DATA_MIN_R _ws_data_min_r { get; set; }
            public _REDEF_VA1184B_WS_DATA_MIN_R WS_DATA_MIN_R
            {
                get { _ws_data_min_r = new _REDEF_VA1184B_WS_DATA_MIN_R(); _.Move(WS_DATA_MIN, _ws_data_min_r); VarBasis.RedefinePassValue(WS_DATA_MIN, _ws_data_min_r, WS_DATA_MIN); _ws_data_min_r.ValueChanged += () => { _.Move(_ws_data_min_r, WS_DATA_MIN); }; return _ws_data_min_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_min_r, WS_DATA_MIN); }
            }  //Redefines
            public class _REDEF_VA1184B_WS_DATA_MIN_R : VarBasis
            {
                /*"      05     WS-ANO-MIN              PIC  9(004).*/
                public IntBasis WS_ANO_MIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      05     WS-MES-MIN              PIC  9(002).*/
                public IntBasis WS_MES_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03       TABELA-IGPM.*/

                public _REDEF_VA1184B_WS_DATA_MIN_R()
                {
                    WS_ANO_MIN.ValueChanged += OnValueChanged;
                    WS_MES_MIN.ValueChanged += OnValueChanged;
                }

            }
            public VA1184B_TABELA_IGPM TABELA_IGPM { get; set; } = new VA1184B_TABELA_IGPM();
            public class VA1184B_TABELA_IGPM : VarBasis
            {
                /*"      05     FILLER            OCCURS 300 TIMES.*/
                public ListBasis<VA1184B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VA1184B_FILLER_1>(300);
                public class VA1184B_FILLER_1 : VarBasis
                {
                    /*"        10   TB-DATA-IGPM      PIC  9(006).*/
                    public IntBasis TB_DATA_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"        10   TB-DATA-IGPM-R REDEFINES TB-DATA-IGPM.*/
                    private _REDEF_VA1184B_TB_DATA_IGPM_R _tb_data_igpm_r { get; set; }
                    public _REDEF_VA1184B_TB_DATA_IGPM_R TB_DATA_IGPM_R
                    {
                        get { _tb_data_igpm_r = new _REDEF_VA1184B_TB_DATA_IGPM_R(); _.Move(TB_DATA_IGPM, _tb_data_igpm_r); VarBasis.RedefinePassValue(TB_DATA_IGPM, _tb_data_igpm_r, TB_DATA_IGPM); _tb_data_igpm_r.ValueChanged += () => { _.Move(_tb_data_igpm_r, TB_DATA_IGPM); }; return _tb_data_igpm_r; }
                        set { VarBasis.RedefinePassValue(value, _tb_data_igpm_r, TB_DATA_IGPM); }
                    }  //Redefines
                    public class _REDEF_VA1184B_TB_DATA_IGPM_R : VarBasis
                    {
                        /*"          15 TB-ANO-IGPM       PIC  9(004).*/
                        public IntBasis TB_ANO_IGPM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"          15 TB-MES-IGPM       PIC  9(002).*/
                        public IntBasis TB_MES_IGPM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        10   TB-VAL-IGPM       PIC S9(006)V9(9)  COMP-3.*/

                        public _REDEF_VA1184B_TB_DATA_IGPM_R()
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
            /*"    03 AC-IGPM                       PIC  9(006) VALUE  0.*/
            public IntBasis AC_IGPM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            /*"01  WABEND.*/
        }
        public VA1184B_WABEND WABEND { get; set; } = new VA1184B_WABEND();
        public class VA1184B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VA1184B  '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1184B  ");
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
            public VA1184B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1184B_LOCALIZA_ABEND_1();
            public class VA1184B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15    PARAGRAFO              PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public VA1184B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1184B_LOCALIZA_ABEND_2();
            public class VA1184B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15    COMANDO                PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA1184B_CPROPVA CPROPVA { get; set; } = new VA1184B_CPROPVA();
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
            /*" -329- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -331- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -333- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -336- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -338- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -345- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -348- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -350- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -352- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -366- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -369- DISPLAY '*** VA1184B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA1184B *** ABRINDO CURSOR ...");

            /*" -370- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -370- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -374- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);

            /*" -375- DISPLAY '*** VA1184B *** PROCESSANDO ...' . */
            _.Display($"*** VA1184B *** PROCESSANDO ...");

            /*" -376- PERFORM M-0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

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
            /*" -345- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRENT FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRENT, SISTEMA_CURRENT);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -366- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT DATA_SOLICITACAO, NUM_APOLICE, CODSUBES, NRCERTIF, OPERACAO, PCT_AUMENTO, SITUACAO FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA1184B' AND SITUACAO = '0' FOR UPDATE OF SITUACAO END-EXEC. */
            CPROPVA = new VA1184B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT DATA_SOLICITACAO
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							OPERACAO
							, 
							PCT_AUMENTO
							, 
							SITUACAO 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'VA1184B' 
							AND SITUACAO = '0'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -370- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -382- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -384- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -384- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -394- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -396- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -398- MOVE 'SELECT V0SEGURAVG1 ' TO COMANDO. */
            _.Move("SELECT V0SEGURAVG1 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -408- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -411- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -413- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -414- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -415- ELSE */
                }
                else
                {


                    /*" -417- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -419- IF SEGURA-SIT-REGISTRO NOT EQUAL '0' AND '1' */

            if (!SEGURA_SIT_REGISTRO.In("0", "1"))
            {

                /*" -421- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -423- MOVE 'SELECT V0MOVIMENTO  ' TO COMANDO. */
            _.Move("SELECT V0MOVIMENTO  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -430- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -433- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -435- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -436- IF MOVIME-COUNT > ZEROES */

            if (MOVIME_COUNT > 00)
            {

                /*" -437- DISPLAY 'EXISTE MOVIMENTO - NRCERTIF = ' RELATO-NRCERTIF */
                _.Display($"EXISTE MOVIMENTO - NRCERTIF = {RELATO_NRCERTIF}");

                /*" -439- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -441- MOVE 'SELECT V0PROPOSTAVA ' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -454- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

            /*" -457- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -459- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -460- IF PROPVA-SITUACAO NOT EQUAL '3' AND '6' */

            if (!PROPVA_SITUACAO.In("3", "6"))
            {

                /*" -461- DISPLAY 'SITUACAO DIF. DE 3 E 6  ' RELATO-NRCERTIF */
                _.Display($"SITUACAO DIF. DE 3 E 6  {RELATO_NRCERTIF}");

                /*" -463- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -465- MOVE 'SELECT V0PRODUTOSVG' TO COMANDO. */
            _.Move("SELECT V0PRODUTOSVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -480- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -483- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -484- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -485- DISPLAY 'NAO POSSUI CAPITALIZACAO ' RELATO-NRCERTIF */
                    _.Display($"NAO POSSUI CAPITALIZACAO {RELATO_NRCERTIF}");

                    /*" -486- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -487- ELSE */
                }
                else
                {


                    /*" -489- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -490- IF PRODVG-ARQFDCAP = 0 */

            if (PRODVG_ARQFDCAP == 0)
            {

                /*" -491- DISPLAY 'PRODUTO NAO POSSUI CAPITALIZACAO ' RELATO-NRCERTIF */
                _.Display($"PRODUTO NAO POSSUI CAPITALIZACAO {RELATO_NRCERTIF}");

                /*" -496- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -498- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -503- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -507- IF SQLCODE NOT EQUAL ZEROES OR CLIENT-DTNASC-I LESS ZEROES */

            if (DB.SQLCODE != 00 || CLIENT_DTNASC_I < 00)
            {

                /*" -508- MOVE 'SELECT V0SEGURAVG2' TO COMANDO */
                _.Move("SELECT V0SEGURAVG2", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -515- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

                /*" -518- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -519- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -520- ELSE */
                }
                else
                {


                    /*" -521- IF SEGURA-DTNASC-I LESS ZEROES */

                    if (SEGURA_DTNASC_I < 00)
                    {

                        /*" -522- DISPLAY 'DATA NASCIMENTO NULA ' RELATO-NRCERTIF */
                        _.Display($"DATA NASCIMENTO NULA {RELATO_NRCERTIF}");

                        /*" -523- MOVE '9999-12-31' TO CLIENT-DTNASC */
                        _.Move("9999-12-31", CLIENT_DTNASC);

                        /*" -525- MOVE ZEROS TO SEGURA-DTNASC-I. */
                        _.Move(0, SEGURA_DTNASC_I);
                    }

                }

            }


            /*" -527- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -541- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

            /*" -544- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -548- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -550- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -594- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_8 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_8();

            /*" -597- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -599- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -600- IF COBERP-PRMDIT-I LESS 0 */

            if (COBERP_PRMDIT_I < 0)
            {

                /*" -602- MOVE 0 TO COBERP-PRMDIT-ANT. */
                _.Move(0, COBERP_PRMDIT_ANT);
            }


            /*" -603- IF COBERP-VLCUSTAUXF-I LESS 0 */

            if (COBERP_VLCUSTAUXF_I < 0)
            {

                /*" -605- MOVE 0 TO COBERP-VLCUSTAUXF. */
                _.Move(0, COBERP_VLCUSTAUXF);
            }


            /*" -605- PERFORM 0300-ATUALIZA-TABELAS THRU 0300-FIM. */

            M_0300_ATUALIZA_TABELAS(true);

            M_0300_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -408- EXEC SQL SELECT SIT_REGISTRO, FAIXA, LOT_EMP_SEGURADO INTO :SEGURA-SIT-REGISTRO, :SEGURA-FAIXA, :SEGURA-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :RELATO-NUM-APOLICE AND COD_SUBGRUPO = :RELATO-CODSUBES AND NUM_CERTIFICADO = :RELATO-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                RELATO_NUM_APOLICE = RELATO_NUM_APOLICE.ToString(),
                RELATO_CODSUBES = RELATO_CODSUBES.ToString(),
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURA_SIT_REGISTRO, SEGURA_SIT_REGISTRO);
                _.Move(executed_1.SEGURA_FAIXA, SEGURA_FAIXA);
                _.Move(executed_1.SEGURA_LOT_EMP_SEGURADO, SEGURA_LOT_EMP_SEGURADO);
                _.Move(executed_1.WLOT_EMP_SEGURADO, WLOT_EMP_SEGURADO);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -609- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -430- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :MOVIME-COUNT FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :RELATO-NRCERTIF AND DATA_AVERBACAO IS NOT NULL AND DATA_INCLUSAO IS NULL END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIME_COUNT, MOVIME_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -454- EXEC SQL SELECT CODCLIEN, OCORHIST, OPCAO_COBER, FONTE, SITUACAO INTO :PROPVA-CODCLIEN, :PROPVA-OCORHIST, :PROPVA-OPCAO-COBER, :PROPVA-FONTE, :PROPVA-SITUACAO FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :RELATO-NRCERTIF END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(executed_1.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(executed_1.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(executed_1.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(executed_1.PROPVA_SITUACAO, PROPVA_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -620- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -622- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -631- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -634- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -635- MOVE 1 TO WS-EOF */
                _.Move(1, WS_WORK_AREAS.WS_EOF);

                /*" -636- MOVE 'CLOSE CPROPVA' TO COMANDO */
                _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -636- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                M_0110_FETCH_DB_CLOSE_1();

                /*" -637- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -631- EXEC SQL FETCH CPROPVA INTO :RELATO-DTSOLICITACAO, :RELATO-NUM-APOLICE, :RELATO-CODSUBES, :RELATO-NRCERTIF, :RELATO-OPERACAO, :RELATO-PCT-AUMENTO, :RELATO-SITUACAO END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.RELATO_DTSOLICITACAO, RELATO_DTSOLICITACAO);
                _.Move(CPROPVA.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(CPROPVA.RELATO_CODSUBES, RELATO_CODSUBES);
                _.Move(CPROPVA.RELATO_NRCERTIF, RELATO_NRCERTIF);
                _.Move(CPROPVA.RELATO_OPERACAO, RELATO_OPERACAO);
                _.Move(CPROPVA.RELATO_PCT_AUMENTO, RELATO_PCT_AUMENTO);
                _.Move(CPROPVA.RELATO_SITUACAO, RELATO_SITUACAO);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -636- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -480- EXEC SQL SELECT VALUE(ARQ_FDCAP,0), VALUE(ESTR_COBR, '         ' ), COBERADIC_PREMIO, CUSTOCAP_TOTAL INTO :PRODVG-ARQFDCAP, :PRODVG-ESTRCOBR, :PRODVG-COBERADIC, :PRODVG-CUSTOCAP FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :RELATO-NUM-APOLICE AND CODSUBES = :RELATO-CODSUBES END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                RELATO_NUM_APOLICE = RELATO_NUM_APOLICE.ToString(),
                RELATO_CODSUBES = RELATO_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_ARQFDCAP, PRODVG_ARQFDCAP);
                _.Move(executed_1.PRODVG_ESTRCOBR, PRODVG_ESTRCOBR);
                _.Move(executed_1.PRODVG_COBERADIC, PRODVG_COBERADIC);
                _.Move(executed_1.PRODVG_CUSTOCAP, PRODVG_CUSTOCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -503- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0300-ATUALIZA-TABELAS */
        private void M_0300_ATUALIZA_TABELAS(bool isPerform = false)
        {
            /*" -652- MOVE '0300-ATUALIZA-TABELAS' TO PARAGRAFO. */
            _.Move("0300-ATUALIZA-TABELAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -653- IF RELATO-DTSOLICITACAO NOT GREATER COBERP-DTINIVIG */

            if (RELATO_DTSOLICITACAO <= COBERP_DTINIVIG)
            {

                /*" -655- MOVE COBERP-DTINIVIG1DAY TO RELATO-DTSOLICITACAO. */
                _.Move(COBERP_DTINIVIG1DAY, RELATO_DTSOLICITACAO);
            }


            /*" -657- MOVE 'UPDATE V0COBERPROPVA1' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -663- PERFORM M_0300_ATUALIZA_TABELAS_DB_UPDATE_1 */

            M_0300_ATUALIZA_TABELAS_DB_UPDATE_1();

            /*" -666- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -668- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -670- MOVE 'UPDATE V0COBERPROPVA2' TO COMANDO. */
            _.Move("UPDATE V0COBERPROPVA2", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -676- PERFORM M_0300_ATUALIZA_TABELAS_DB_UPDATE_2 */

            M_0300_ATUALIZA_TABELAS_DB_UPDATE_2();

            /*" -679- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -681- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -683- COMPUTE PROPVA-OCORHIST = PROPVA-OCORHIST + 1. */
            PROPVA_OCORHIST.Value = PROPVA_OCORHIST + 1;

            /*" -685- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -692- PERFORM M_0300_ATUALIZA_TABELAS_DB_UPDATE_3 */

            M_0300_ATUALIZA_TABELAS_DB_UPDATE_3();

            /*" -695- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -697- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -699- COMPUTE COBERP-IMPMORNATU-ATU = COBERP-IMPMORNATU-ANT. */
            COBERP_IMPMORNATU_ATU.Value = COBERP_IMPMORNATU_ANT;

            /*" -701- COMPUTE COBERP-IMPMORACID-ATU = COBERP-IMPMORACID-ANT. */
            COBERP_IMPMORACID_ATU.Value = COBERP_IMPMORACID_ANT;

            /*" -703- COMPUTE COBERP-IMPINVPERM-ATU = COBERP-IMPINVPERM-ANT. */
            COBERP_IMPINVPERM_ATU.Value = COBERP_IMPINVPERM_ANT;

            /*" -705- COMPUTE COBERP-IMPAMDS-ATU = COBERP-IMPAMDS-ANT. */
            COBERP_IMPAMDS_ATU.Value = COBERP_IMPAMDS_ANT;

            /*" -707- COMPUTE COBERP-IMPDH-ATU = COBERP-IMPDH-ANT. */
            COBERP_IMPDH_ATU.Value = COBERP_IMPDH_ANT;

            /*" -711- COMPUTE COBERP-IMPDIT-ATU = COBERP-IMPDIT-ANT. */
            COBERP_IMPDIT_ATU.Value = COBERP_IMPDIT_ANT;

            /*" -713- MOVE ZEROS TO WS-PRMADIC-ANT WS-PRMADIC-ATU. */
            _.Move(0, WS_WORK_AREAS.WS_PRMADIC_ANT, WS_WORK_AREAS.WS_PRMADIC_ATU);

            /*" -714- IF PRODVG-CUSTOCAP NOT EQUAL 'S' */

            if (PRODVG_CUSTOCAP != "S")
            {

                /*" -716- COMPUTE WS-PRMADIC-ANT = (COBERP-QTTITCAP * COBERP-VLCUSTCAP) */
                WS_WORK_AREAS.WS_PRMADIC_ANT.Value = (COBERP_QTTITCAP * COBERP_VLCUSTCAP);

                /*" -718- COMPUTE WS-PRMADIC-ATU = (COBERP-QTTITCAP * RELATO-PCT-AUMENTO) */
                WS_WORK_AREAS.WS_PRMADIC_ATU.Value = (COBERP_QTTITCAP * RELATO_PCT_AUMENTO);

                /*" -719- ELSE */
            }
            else
            {


                /*" -722- MOVE 0 TO WS-PRMADIC-ANT WS-PRMADIC-ATU. */
                _.Move(0, WS_WORK_AREAS.WS_PRMADIC_ANT, WS_WORK_AREAS.WS_PRMADIC_ATU);
            }


            /*" -723- IF PRODVG-COBERADIC NOT EQUAL 'S' */

            if (PRODVG_COBERADIC != "S")
            {

                /*" -727- COMPUTE WS-PRMADIC-ANT = WS-PRMADIC-ANT + COBERP-VLCUSTAUXF + COBERP-VLCUSTCDG */
                WS_WORK_AREAS.WS_PRMADIC_ANT.Value = WS_WORK_AREAS.WS_PRMADIC_ANT + COBERP_VLCUSTAUXF + COBERP_VLCUSTCDG;

                /*" -731- COMPUTE WS-PRMADIC-ATU = WS-PRMADIC-ATU + COBERP-VLCUSTAUXF + COBERP-VLCUSTCDG */
                WS_WORK_AREAS.WS_PRMADIC_ATU.Value = WS_WORK_AREAS.WS_PRMADIC_ATU + COBERP_VLCUSTAUXF + COBERP_VLCUSTCDG;

                /*" -732- ELSE */
            }
            else
            {


                /*" -735- MOVE 0 TO WS-PRMADIC-ANT WS-PRMADIC-ATU. */
                _.Move(0, WS_WORK_AREAS.WS_PRMADIC_ANT, WS_WORK_AREAS.WS_PRMADIC_ATU);
            }


            /*" -738- COMPUTE COBERP-PRMVG-ATU = COBERP-PRMVG-ANT - (WS-PRMADIC-ATU - WS-PRMADIC-ANT). */
            COBERP_PRMVG_ATU.Value = COBERP_PRMVG_ANT - (WS_WORK_AREAS.WS_PRMADIC_ATU - WS_WORK_AREAS.WS_PRMADIC_ANT);

            /*" -740- MOVE COBERP-PRMAP-ANT TO COBERP-PRMAP-ATU. */
            _.Move(COBERP_PRMAP_ANT, COBERP_PRMAP_ATU);

            /*" -742- MOVE COBERP-VLPREMIO-ANT TO COBERP-VLPREMIO-ATU. */
            _.Move(COBERP_VLPREMIO_ANT, COBERP_VLPREMIO_ATU);

            /*" -744- MOVE RELATO-PCT-AUMENTO TO COBERP-VLCUSTCAP. */
            _.Move(RELATO_PCT_AUMENTO, COBERP_VLCUSTCAP);

            /*" -746- MOVE 'INSERT V0COBERPROPVA' TO COMANDO. */
            _.Move("INSERT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -806- PERFORM M_0300_ATUALIZA_TABELAS_DB_INSERT_1 */

            M_0300_ATUALIZA_TABELAS_DB_INSERT_1();

            /*" -809- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -811- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -815- IF INDAGE < 0 OR INDOPR < 0 OR INDNUM < 0 OR INDDIG < 0 */

            if (INDAGE < 0 || INDOPR < 0 || INDNUM < 0 || INDDIG < 0)
            {

                /*" -817- MOVE 0 TO MNUM-CTA-CORRENTE OPCAOP-AGECTADEB */
                _.Move(0, MNUM_CTA_CORRENTE, OPCAOP_AGECTADEB);

                /*" -818- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -819- ELSE */
            }
            else
            {


                /*" -820- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -821- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -822- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -823- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -825- MOVE W01A0100 TO MDAC-CTA-CORRENTE. */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);
            }


            /*" -827- MOVE 'SELECT V0FONTE' TO COMANDO. */
            _.Move("SELECT V0FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -832- PERFORM M_0300_ATUALIZA_TABELAS_DB_SELECT_1 */

            M_0300_ATUALIZA_TABELAS_DB_SELECT_1();

            /*" -835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -837- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -838- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -840- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

        }

        [StopWatch]
        /*" M-0300-ATUALIZA-TABELAS-DB-UPDATE-1 */
        public void M_0300_ATUALIZA_TABELAS_DB_UPDATE_1()
        {
            /*" -663- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = :RELATO-DTSOLICITACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :RELATO-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1 = new M_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1()
            {
                RELATO_DTSOLICITACAO = RELATO_DTSOLICITACAO.ToString(),
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1.Execute(m_0300_ATUALIZA_TABELAS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -515- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:SEGURA-DTNASC-I FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :RELATO-NUM-APOLICE AND COD_SUBGRUPO = :RELATO-CODSUBES AND NUM_CERTIFICADO = :RELATO-NRCERTIF END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                RELATO_NUM_APOLICE = RELATO_NUM_APOLICE.ToString(),
                RELATO_CODSUBES = RELATO_CODSUBES.ToString(),
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.SEGURA_DTNASC_I, SEGURA_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0300-ATUALIZA-TABELAS-DB-UPDATE-2 */
        public void M_0300_ATUALIZA_TABELAS_DB_UPDATE_2()
        {
            /*" -676- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = DTTERVIG - 1 DAY, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :RELATO-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST END-EXEC. */

            var m_0300_ATUALIZA_TABELAS_DB_UPDATE_2_Update1 = new M_0300_ATUALIZA_TABELAS_DB_UPDATE_2_Update1()
            {
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_0300_ATUALIZA_TABELAS_DB_UPDATE_2_Update1.Execute(m_0300_ATUALIZA_TABELAS_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0300-ATUALIZA-TABELAS-DB-INSERT-1 */
        public void M_0300_ATUALIZA_TABELAS_DB_INSERT_1()
        {
            /*" -806- EXEC SQL INSERT INTO SEGUROS.V0COBERPROPVA ( NRCERTIF ,OCORHIST ,DTINIVIG ,DTTERVIG ,IMPSEGUR ,QUANT_VIDAS ,IMPSEGIND ,CODOPER ,OPCAO_COBER ,IMPMORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMVG ,PRMAP ,QTTITCAP ,VLTITCAP ,VLCUSTCAP ,IMPSEGCDC ,VLCUSTCDG ,CODUSU ,TIMESTAMP ,IMPSEGAUXF ,VLCUSTAUXF ,PRMDIT ,QTDIT ) VALUES (:RELATO-NRCERTIF, :PROPVA-OCORHIST, :RELATO-DTSOLICITACAO, '9999-12-31' , :COBERP-IMPMORNATU-ATU, 1, :COBERP-IMPMORNATU-ATU, :RELATO-OPERACAO, :PROPVA-OPCAO-COBER, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ATU, :COBERP-VLPREMIO-ATU, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ATU, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, 'VA1184B' , CURRENT TIMESTAMP, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I) END-EXEC. */

            var m_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1 = new M_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1()
            {
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                RELATO_DTSOLICITACAO = RELATO_DTSOLICITACAO.ToString(),
                COBERP_IMPMORNATU_ATU = COBERP_IMPMORNATU_ATU.ToString(),
                RELATO_OPERACAO = RELATO_OPERACAO.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORACID_ATU = COBERP_IMPMORACID_ATU.ToString(),
                COBERP_IMPINVPERM_ATU = COBERP_IMPINVPERM_ATU.ToString(),
                COBERP_IMPAMDS_ATU = COBERP_IMPAMDS_ATU.ToString(),
                COBERP_IMPDH_ATU = COBERP_IMPDH_ATU.ToString(),
                COBERP_IMPDIT_ATU = COBERP_IMPDIT_ATU.ToString(),
                COBERP_VLPREMIO_ATU = COBERP_VLPREMIO_ATU.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                COBERP_QTTITCAP = COBERP_QTTITCAP.ToString(),
                COBERP_VLTITCAP = COBERP_VLTITCAP.ToString(),
                COBERP_VLCUSTCAP = COBERP_VLCUSTCAP.ToString(),
                COBERP_IMPSEGCDG = COBERP_IMPSEGCDG.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_IMPSEGAUXF_I = COBERP_IMPSEGAUXF_I.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                COBERP_VLCUSTAUXF_I = COBERP_VLCUSTAUXF_I.ToString(),
                COBERP_PRMDIT_ANT = COBERP_PRMDIT_ANT.ToString(),
                COBERP_PRMDIT_I = COBERP_PRMDIT_I.ToString(),
                COBERP_QTDIT = COBERP_QTDIT.ToString(),
                COBERP_QTDIT_I = COBERP_QTDIT_I.ToString(),
            };

            M_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1.Execute(m_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0300-ATUALIZA-TABELAS-DB-SELECT-1 */
        public void M_0300_ATUALIZA_TABELAS_DB_SELECT_1()
        {
            /*" -832- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_0300_ATUALIZA_TABELAS_DB_SELECT_1_Query1 = new M_0300_ATUALIZA_TABELAS_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_0300_ATUALIZA_TABELAS_DB_SELECT_1_Query1.Execute(m_0300_ATUALIZA_TABELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" M-0300-PROPAUTOM */
        private void M_0300_PROPAUTOM(bool isPerform = false)
        {
            /*" -846- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -847- IF COBERP-PRMAP-ANT = 0 */

            if (COBERP_PRMAP_ANT == 0)
            {

                /*" -852- MOVE 0 TO COBERP-IMPMORACID-ATU COBERP-IMPMORACID-ANT COBERP-IMPINVPERM-ATU COBERP-IMPINVPERM-ANT. */
                _.Move(0, COBERP_IMPMORACID_ATU, COBERP_IMPMORACID_ANT, COBERP_IMPINVPERM_ATU, COBERP_IMPINVPERM_ANT);
            }


            /*" -853- IF COBERP-PRMVG-ANT = 0 */

            if (COBERP_PRMVG_ANT == 0)
            {

                /*" -856- MOVE 0 TO COBERP-IMPMORNATU-ATU COBERP-IMPMORNATU-ANT. */
                _.Move(0, COBERP_IMPMORNATU_ATU, COBERP_IMPMORNATU_ANT);
            }


            /*" -858- IF (COBERP-PRMVG-ANT > 0 AND COBERP-PRMAP-ANT > 0) */

            if ((COBERP_PRMVG_ANT > 0 && COBERP_PRMAP_ANT > 0))
            {

                /*" -860- COMPUTE COBERP-IMPMORACID-ATU = COBERP-IMPMORNATU-ATU */
                COBERP_IMPMORACID_ATU.Value = COBERP_IMPMORNATU_ATU;

                /*" -863- COMPUTE COBERP-IMPMORACID-ANT = COBERP-IMPMORNATU-ANT. */
                COBERP_IMPMORACID_ANT.Value = COBERP_IMPMORNATU_ANT;
            }


            /*" -864- IF WLOT-EMP-SEGURADO LESS ZEROS */

            if (WLOT_EMP_SEGURADO < 00)
            {

                /*" -866- MOVE SPACES TO SEGURA-LOT-EMP-SEGURADO. */
                _.Move("", SEGURA_LOT_EMP_SEGURADO);
            }


            /*" -943- PERFORM M_0300_PROPAUTOM_DB_INSERT_1 */

            M_0300_PROPAUTOM_DB_INSERT_1();

            /*" -946- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -947- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -948- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -949- DISPLAY 'VA1184B - PROPOSTA DUPLICADA NA V0MOVIMENTO' */
                    _.Display($"VA1184B - PROPOSTA DUPLICADA NA V0MOVIMENTO");

                    /*" -950- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -951- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -952- GO TO 0300-PROPAUTOM */
                    new Task(() => M_0300_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -953- ELSE */
                }
                else
                {


                    /*" -954- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -955- DISPLAY 'VA1184B - ERRO INSERT DA V0MOVIMENTO' */
                    _.Display($"VA1184B - ERRO INSERT DA V0MOVIMENTO");

                    /*" -957- DISPLAY '          APOLICE..........  ' RELATO-NUM-APOLICE */
                    _.Display($"          APOLICE..........  {RELATO_NUM_APOLICE}");

                    /*" -958- DISPLAY '          SUBGRUPO.........  ' RELATO-CODSUBES */
                    _.Display($"          SUBGRUPO.........  {RELATO_CODSUBES}");

                    /*" -959- DISPLAY '          FONTE............  ' PROPVA-FONTE */
                    _.Display($"          FONTE............  {PROPVA_FONTE}");

                    /*" -960- DISPLAY '          NUM. PROPOSTA....  ' FONTE-PROPAUTOM */
                    _.Display($"          NUM. PROPOSTA....  {FONTE_PROPAUTOM}");

                    /*" -961- DISPLAY '          CERTIFICADO......  ' RELATO-NRCERTIF */
                    _.Display($"          CERTIFICADO......  {RELATO_NRCERTIF}");

                    /*" -962- DISPLAY '          SQLCODE..........  ' SQLCODE */
                    _.Display($"          SQLCODE..........  {DB.SQLCODE}");

                    /*" -964- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -966- MOVE 'UPDATE V0FONTE' TO COMANDO. */
            _.Move("UPDATE V0FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -971- PERFORM M_0300_PROPAUTOM_DB_UPDATE_1 */

            M_0300_PROPAUTOM_DB_UPDATE_1();

            /*" -974- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -976- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -978- MOVE 'UPDATE V0RELATORIOS' TO COMANDO. */
            _.Move("UPDATE V0RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -982- PERFORM M_0300_PROPAUTOM_DB_UPDATE_2 */

            M_0300_PROPAUTOM_DB_UPDATE_2();

            /*" -985- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -987- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -988- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-INSERT-1 */
        public void M_0300_PROPAUTOM_DB_INSERT_1()
        {
            /*" -943- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:RELATO-NUM-APOLICE, :RELATO-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :RELATO-NRCERTIF, ' ' , '4' , :PROPVA-CODCLIEN, 0, 0, 0, 0, :SEGURA-FAIXA, 'S' , 'S' , :OPCAOP-PERIPGTO, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, :OPCAOP-AGECTADEB, ' ' , 0, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORNATU-ATU, :COBERP-IMPMORACID-ANT, :COBERP-IMPMORACID-ATU, :COBERP-IMPINVPERM-ANT, :COBERP-IMPINVPERM-ATU, :COBERP-IMPAMDS-ANT, :COBERP-IMPAMDS-ATU, :COBERP-IMPDH-ANT, :COBERP-IMPDH-ATU, :COBERP-IMPDIT-ANT, :COBERP-IMPDIT-ATU, :COBERP-PRMVG-ANT, :COBERP-PRMVG-ATU, :COBERP-PRMAP-ANT, :COBERP-PRMAP-ATU, :RELATO-OPERACAO, :SISTEMA-DTMOVABE, 0, '1' , 'VA1184B' , :SISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :RELATO-DTSOLICITACAO, :RELATO-DTSOLICITACAO, NULL, :SEGURA-LOT-EMP-SEGURADO) END-EXEC. */

            var m_0300_PROPAUTOM_DB_INSERT_1_Insert1 = new M_0300_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                RELATO_NUM_APOLICE = RELATO_NUM_APOLICE.ToString(),
                RELATO_CODSUBES = RELATO_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                SEGURA_FAIXA = SEGURA_FAIXA.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                OPCAOP_AGECTADEB = OPCAOP_AGECTADEB.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                COBERP_IMPMORNATU_ANT = COBERP_IMPMORNATU_ANT.ToString(),
                COBERP_IMPMORNATU_ATU = COBERP_IMPMORNATU_ATU.ToString(),
                COBERP_IMPMORACID_ANT = COBERP_IMPMORACID_ANT.ToString(),
                COBERP_IMPMORACID_ATU = COBERP_IMPMORACID_ATU.ToString(),
                COBERP_IMPINVPERM_ANT = COBERP_IMPINVPERM_ANT.ToString(),
                COBERP_IMPINVPERM_ATU = COBERP_IMPINVPERM_ATU.ToString(),
                COBERP_IMPAMDS_ANT = COBERP_IMPAMDS_ANT.ToString(),
                COBERP_IMPAMDS_ATU = COBERP_IMPAMDS_ATU.ToString(),
                COBERP_IMPDH_ANT = COBERP_IMPDH_ANT.ToString(),
                COBERP_IMPDH_ATU = COBERP_IMPDH_ATU.ToString(),
                COBERP_IMPDIT_ANT = COBERP_IMPDIT_ANT.ToString(),
                COBERP_IMPDIT_ATU = COBERP_IMPDIT_ATU.ToString(),
                COBERP_PRMVG_ANT = COBERP_PRMVG_ANT.ToString(),
                COBERP_PRMVG_ATU = COBERP_PRMVG_ATU.ToString(),
                COBERP_PRMAP_ANT = COBERP_PRMAP_ANT.ToString(),
                COBERP_PRMAP_ATU = COBERP_PRMAP_ATU.ToString(),
                RELATO_OPERACAO = RELATO_OPERACAO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                RELATO_DTSOLICITACAO = RELATO_DTSOLICITACAO.ToString(),
                SEGURA_LOT_EMP_SEGURADO = SEGURA_LOT_EMP_SEGURADO.ToString(),
            };

            M_0300_PROPAUTOM_DB_INSERT_1_Insert1.Execute(m_0300_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-UPDATE-1 */
        public void M_0300_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -971- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_0300_PROPAUTOM_DB_UPDATE_1_Update1 = new M_0300_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            M_0300_PROPAUTOM_DB_UPDATE_1_Update1.Execute(m_0300_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0300-ATUALIZA-TABELAS-DB-UPDATE-3 */
        public void M_0300_ATUALIZA_TABELAS_DB_UPDATE_3()
        {
            /*" -692- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODOPER = :RELATO-OPERACAO, DTMOVTO = :RELATO-DTSOLICITACAO, OCORHIST = :PROPVA-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :RELATO-NRCERTIF END-EXEC. */

            var m_0300_ATUALIZA_TABELAS_DB_UPDATE_3_Update1 = new M_0300_ATUALIZA_TABELAS_DB_UPDATE_3_Update1()
            {
                RELATO_DTSOLICITACAO = RELATO_DTSOLICITACAO.ToString(),
                RELATO_OPERACAO = RELATO_OPERACAO.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            M_0300_ATUALIZA_TABELAS_DB_UPDATE_3_Update1.Execute(m_0300_ATUALIZA_TABELAS_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-0300-PROPAUTOM-DB-UPDATE-2 */
        public void M_0300_PROPAUTOM_DB_UPDATE_2()
        {
            /*" -982- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CURRENT OF CPROPVA END-EXEC. */

            var m_0300_PROPAUTOM_DB_UPDATE_2_Update1 = new M_0300_PROPAUTOM_DB_UPDATE_2_Update1(CPROPVA)
            {
            };

            M_0300_PROPAUTOM_DB_UPDATE_2_Update1.Execute(m_0300_PROPAUTOM_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -541- EXEC SQL SELECT PERIPGTO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB INTO :OPCAOP-PERIPGTO, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :RELATO-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1);
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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-8 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_8()
        {
            /*" -594- EXEC SQL SELECT DTINIVIG, DTINIVIG + 1 DAY, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDC, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :COBERP-DTINIVIG, :COBERP-DTINIVIG1DAY, :COBERP-IMPMORNATU-ANT, :COBERP-IMPMORACID-ANT, :COBERP-IMPINVPERM-ANT, :COBERP-IMPAMDS-ANT, :COBERP-IMPDH-ANT, :COBERP-IMPDIT-ANT, :COBERP-VLPREMIO-ANT, :COBERP-PRMVG-ANT, :COBERP-PRMAP-ANT, :COBERP-QTTITCAP, :COBERP-VLTITCAP, :COBERP-VLCUSTCAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I, :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I, :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I, :COBERP-QTDIT:COBERP-QTDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :RELATO-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1()
            {
                RELATO_NRCERTIF = RELATO_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_DTINIVIG1DAY, COBERP_DTINIVIG1DAY);
                _.Move(executed_1.COBERP_IMPMORNATU_ANT, COBERP_IMPMORNATU_ANT);
                _.Move(executed_1.COBERP_IMPMORACID_ANT, COBERP_IMPMORACID_ANT);
                _.Move(executed_1.COBERP_IMPINVPERM_ANT, COBERP_IMPINVPERM_ANT);
                _.Move(executed_1.COBERP_IMPAMDS_ANT, COBERP_IMPAMDS_ANT);
                _.Move(executed_1.COBERP_IMPDH_ANT, COBERP_IMPDH_ANT);
                _.Move(executed_1.COBERP_IMPDIT_ANT, COBERP_IMPDIT_ANT);
                _.Move(executed_1.COBERP_VLPREMIO_ANT, COBERP_VLPREMIO_ANT);
                _.Move(executed_1.COBERP_PRMVG_ANT, COBERP_PRMVG_ANT);
                _.Move(executed_1.COBERP_PRMAP_ANT, COBERP_PRMAP_ANT);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_VLTITCAP, COBERP_VLTITCAP);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IMPSEGAUXF_I, COBERP_IMPSEGAUXF_I);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF_I, COBERP_VLCUSTAUXF_I);
                _.Move(executed_1.COBERP_PRMDIT_ANT, COBERP_PRMDIT_ANT);
                _.Move(executed_1.COBERP_PRMDIT_I, COBERP_PRMDIT_I);
                _.Move(executed_1.COBERP_QTDIT, COBERP_QTDIT);
                _.Move(executed_1.COBERP_QTDIT_I, COBERP_QTDIT_I);
            }


        }

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -999- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1000- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1000- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1003- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1004- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1005- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1005- DISPLAY '*** VA1184B *** TERMINO NORMAL' . */
            _.Display($"*** VA1184B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1016- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1017- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1018- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1019- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -1021- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1023- DISPLAY '*** VA1184B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA1184B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1023- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1026- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1027- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1027- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1030- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1031- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1033- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1034- DISPLAY 'FONTE.........  ' PROPVA-FONTE */
            _.Display($"FONTE.........  {PROPVA_FONTE}");

            /*" -1035- DISPLAY 'PROPOSTA......  ' FONTE-PROPAUTOM */
            _.Display($"PROPOSTA......  {FONTE_PROPAUTOM}");

            /*" -1036- DISPLAY 'CERTIFICADO...  ' RELATO-NRCERTIF. */
            _.Display($"CERTIFICADO...  {RELATO_NRCERTIF}");

            /*" -1037- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1039- DISPLAY '*** VA1184B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA1184B *** ERRO DE EXECUCAO");

            /*" -1040- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1040- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}