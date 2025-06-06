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
using Sias.VidaEmGrupo.DB2.VG1651B;

namespace Code
{
    public class VG1651B
    {
        public bool IsCall { get; set; }

        public VG1651B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (REDE-SIM)      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1651B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  LUIZ MARQUES (FAST COMPUTER)       *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  LUIZ MARQUES (FAST COMPUTER)       *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2012                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CANCELAR OS SEGUROS COM TERMINO DE *      */
        /*"      *                             VIGENCIA EXPIRADOS (MENSAL).       *      */
        /*"      *                             APOLICE COMERCIALIZADA PELO CANAL  *      */
        /*"      *                             DE VENDAS REDE-SIM.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CADMUS 154.956                                   *      */
        /*"      *             - DESCONSIDERAR MODALIDADE NA CONSULTA DE COBERTURA*      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 00 - VERSAO ORIGINAL.                                   *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 72.667  DATA: 22/09/2012                           *      */
        /*"      *                                                                *      */
        /*"      *           LUIZ EDUARDO MARQUES         FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         V1PAR-RAMO-VG       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PAR-RAMO-AP       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTMOVTO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ESTR-COBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ORIG-PRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-SAF        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-IGPM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-CDG        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-MIN-DTPROXVEN PIC  X(010).*/
        public StringBasis WHOST_MIN_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-VLPREMIO      PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1SIST-DTREFFAT     PIC  X(010).*/
        public StringBasis V1SIST_DTREFFAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DATA-HOJE    PIC  X(010).*/
        public StringBasis V1SIST_DATA_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0SEGV-NUM-ITEM          PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0SEGV_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGV-SITUACAO          PIC  X(001).*/
        public StringBasis V0SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SEGU-TPINCLUS          PIC  X(001).*/
        public StringBasis V0SEGU_TPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SEGU-AGENCIADOR        PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0SEGU_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGU-ITEM              PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0SEGU_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGU-OCORHIST          PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0SEGU_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0SEGU-LOT-EMP-SEGURADO  PIC X(030).*/
        public StringBasis V0SEGU_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77         VIND-LOT-EMP-SEG         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_LOT_EMP_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0SEGU-CODCLIEN          PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0SEGU_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HIST-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-DTMOVTO-1YEAR PIC  X(010).*/
        public StringBasis V0HIST_DTMOVTO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PROP-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-DTCANCELA    PIC  X(010).*/
        public StringBasis V0PROP_DTCANCELA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTTERVIG     PIC  X(010).*/
        public StringBasis V0PROP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PROP-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-DTINIVIG-1   PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBP-VLPREMIO     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCAP    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCDG    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTAUXF   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-IVLCUSTAUXF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-QTTITCAP     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMTOTANT    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V3DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V3DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HICB-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HICB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HICB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HICB-SITUACAO     PIC  X(001).*/
        public StringBasis V0HICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HICB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MOVI-COUNT        PIC S9(009) COMP.*/
        public IntBasis V0MOVI_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FONT-PROPAUTOM    PIC S9(009)      COMP.*/
        public IntBasis V0FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATC-DTREF        PIC  X(010).*/
        public StringBasis V0FATC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-PRMVG        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PRMAP        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01       WDATA-SQL           PIC  X(010).*/
        public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01       FILLER              REDEFINES    WDATA-SQL.*/
        private _REDEF_VG1651B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VG1651B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VG1651B_FILLER_0(); _.Move(WDATA_SQL, _filler_0); VarBasis.RedefinePassValue(WDATA_SQL, _filler_0, WDATA_SQL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_SQL); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_SQL); }
        }  //Redefines
        public class _REDEF_VG1651B_FILLER_0 : VarBasis
        {
            /*"    10   WANO-SQL            PIC  9(004).*/
            public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10   FILLER              PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10   WMES-SQL            PIC  9(002).*/
            public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10   FILLER              PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10   WDIA-SQL            PIC  9(002).*/
            public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WPRI-PARCELA                PIC  9(001)   VALUE ZEROS.*/

            public _REDEF_VG1651B_FILLER_0()
            {
                WANO_SQL.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                WMES_SQL.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                WDIA_SQL.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WPRI_PARCELA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  W-IGPM-CADASTRADO           PIC  X(001)   VALUE SPACES.*/
        public StringBasis W_IGPM_CADASTRADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VG1651B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_VG1651B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_VG1651B_FILLER_3(); _.Move(W_NUMR_TITULO, _filler_3); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_3, W_NUMR_TITULO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_NUMR_TITULO); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VG1651B_FILLER_3 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_VG1651B_FILLER_3()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VG1651B_DPARM01X DPARM01X { get; set; } = new VG1651B_DPARM01X();
        public class VG1651B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VG1651B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VG1651B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VG1651B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VG1651B_DPARM01_R : VarBasis
            {
                /*"    10          DPARM01-1         PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-2         PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-3         PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-4         PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-5         PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-6         PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-7         PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-8         PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-9         PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-10        PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05            DPARM01-D1        PIC  9(001).*/

                public _REDEF_VG1651B_DPARM01_R()
                {
                    DPARM01_1.ValueChanged += OnValueChanged;
                    DPARM01_2.ValueChanged += OnValueChanged;
                    DPARM01_3.ValueChanged += OnValueChanged;
                    DPARM01_4.ValueChanged += OnValueChanged;
                    DPARM01_5.ValueChanged += OnValueChanged;
                    DPARM01_6.ValueChanged += OnValueChanged;
                    DPARM01_7.ValueChanged += OnValueChanged;
                    DPARM01_8.ValueChanged += OnValueChanged;
                    DPARM01_9.ValueChanged += OnValueChanged;
                    DPARM01_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01           AREA-DE-WORK.*/
        }
        public VG1651B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG1651B_AREA_DE_WORK();
        public class VG1651B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WANO-BISSEXTO     PIC  9(004).*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WACC-COMMIT       PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WFIM-CPROPVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WREGULARIZOU    PIC X(001)  VALUE SPACES.*/
            public StringBasis WREGULARIZOU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WNSAS           PIC 9(005).*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05         WDATA-SISTEMA-AUX.*/
            public VG1651B_WDATA_SISTEMA_AUX WDATA_SISTEMA_AUX { get; set; } = new VG1651B_WDATA_SISTEMA_AUX();
            public class VG1651B_WDATA_SISTEMA_AUX : VarBasis
            {
                /*"    10       WDATA-AUX-ANO     PIC  9(004).*/
                public IntBasis WDATA_AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-AUX-MES     PIC  9(002).*/
                public IntBasis WDATA_AUX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-AUX-DIA     PIC  9(002).*/
                public IntBasis WDATA_AUX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/
            }
            public VG1651B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VG1651B_WDATA_SISTEMA();
            public class VG1651B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-PRIMEIRA.*/
            }
            public VG1651B_WDATA_PRIMEIRA WDATA_PRIMEIRA { get; set; } = new VG1651B_WDATA_PRIMEIRA();
            public class VG1651B_WDATA_PRIMEIRA : VarBasis
            {
                /*"    10       WDATA-PRI-ANO     PIC  9(004).*/
                public IntBasis WDATA_PRI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-MES     PIC  9(002).*/
                public IntBasis WDATA_PRI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-DIA     PIC  9(002).*/
                public IntBasis WDATA_PRI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VG1651B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VG1651B_WDATA_VIGENCIA();
            public class VG1651B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002).*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA1.*/
            }
            public VG1651B_WDATA_VIGENCIA1 WDATA_VIGENCIA1 { get; set; } = new VG1651B_WDATA_VIGENCIA1();
            public class VG1651B_WDATA_VIGENCIA1 : VarBasis
            {
                /*"    10       WDATA-VIG-ANO1    PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES1    PIC  9(002).*/
                public IntBasis WDATA_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA1    PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VENCIMENTO.*/
            }
            public VG1651B_WDATA_VENCIMENTO WDATA_VENCIMENTO { get; set; } = new VG1651B_WDATA_VENCIMENTO();
            public class VG1651B_WDATA_VENCIMENTO : VarBasis
            {
                /*"    10       WDATA-VCT-ANO     PIC  9(004).*/
                public IntBasis WDATA_VCT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-MES     PIC  9(002).*/
                public IntBasis WDATA_VCT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-DIA     PIC  9(002).*/
                public IntBasis WDATA_VCT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W01DTSQL.*/
            }
            public VG1651B_W01DTSQL W01DTSQL { get; set; } = new VG1651B_W01DTSQL();
            public class VG1651B_W01DTSQL : VarBasis
            {
                /*"    10       W01AASQL          PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W01T1SQL          PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01MMSQL          PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01T2SQL          PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01DDSQL          PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
            }
            public VG1651B_WABEND WABEND { get; set; } = new VG1651B_WABEND();
            public class VG1651B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA0853B '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0853B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05        WSQLERRO.*/
            }
            public VG1651B_WSQLERRO WSQLERRO { get; set; } = new VG1651B_WSQLERRO();
            public class VG1651B_WSQLERRO : VarBasis
            {
                /*"    10      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    10      WSQLERRMC           PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public VG1651B_CPROPVA CPROPVA { get; set; } = new VG1651B_CPROPVA();
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
            /*" -326- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -327- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -328- DISPLAY 'PROGRAMA EM EXECUCAO  VG1651B  ' . */
            _.Display($"PROGRAMA EM EXECUCAO  VG1651B  ");

            /*" -329- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -331- DISPLAY 'VERSAO V.01 154.956 20/10/2017 ' . */
            _.Display($"VERSAO V.01 154.956 20/10/2017 ");

            /*" -332- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -334- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -335- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -338- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -341- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -345- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -350- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -354- DISPLAY 'VA1651B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                _.Display($"VA1651B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                /*" -356- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -358- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -360- PERFORM R0100-00-SELECT-V1SISTEMAS. */

            R0100_00_SELECT_V1SISTEMAS_SECTION();

            /*" -362- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -378- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -382- DISPLAY '*** VG1651B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG1651B *** ABRINDO CURSOR ...");

            /*" -384- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -384- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -387- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -388- DISPLAY 'PROBLEMAS NO OPEN (CPROPVA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVA   ) ... ");

                /*" -390- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -392- DISPLAY '*** VG1651B *** PROCESSANDO ... ' . */
            _.Display($"*** VG1651B *** PROCESSANDO ... ");

            /*" -394- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

            /*" -395- IF WFIM-CPROPVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty())
            {

                /*" -397- DISPLAY '*** VG1651B *** NENHUMA PROPOSTA A PROCESSAR' */
                _.Display($"*** VG1651B *** NENHUMA PROPOSTA A PROCESSAR");

                /*" -399- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -403- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CPROPVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -404- DISPLAY 'PROPOSTAS LIDAS ............ ' WACC-LIDOS. */
            _.Display($"PROPOSTAS LIDAS ............ {AREA_DE_WORK.WACC_LIDOS}");

            /*" -406- DISPLAY 'CANCELAMENTOS GERADOS ...... ' WACC-GRAVADOS. */
            _.Display($"CANCELAMENTOS GERADOS ...... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -409- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -409- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -350- EXEC SQL SELECT RAMO_VG, RAMO_AP INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PAR_RAMO_VG, V1PAR_RAMO_VG);
                _.Move(executed_1.V1PAR_RAMO_AP, V1PAR_RAMO_AP);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -378- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, SITUACAO, DTQITBCO, DTQITBCO + 1 MONTH - 1 DAY, DTQITBCO + 1 MONTH, FONTE FROM SEGUROS.V0PROPOSTAVA WHERE NUM_APOLICE = 108210871143 AND CODSUBES > 0 AND SITUACAO IN ( '3' , '6' ) AND DTPROXVEN = '9999-12-31' END-EXEC. */
            CPROPVA = new VG1651B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							SITUACAO
							, 
							DTQITBCO
							, 
							DTQITBCO + 1 MONTH - 1 DAY
							, 
							DTQITBCO + 1 MONTH
							, 
							FONTE 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE NUM_APOLICE = 108210871143 
							AND CODSUBES > 0 
							AND SITUACAO IN ( '3'
							, '6' ) 
							AND DTPROXVEN = '9999-12-31'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -384- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -415- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -416- DISPLAY ' ' */
            _.Display($" ");

            /*" -417- DISPLAY '*--------  VG1651B - FIM NORMAL  --------*' */
            _.Display($"*--------  VG1651B - FIM NORMAL  --------*");

            /*" -417- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMAS-SECTION */
        private void R0100_00_SELECT_V1SISTEMAS_SECTION()
        {
            /*" -429- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -440- PERFORM R0100_00_SELECT_V1SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMAS_DB_SELECT_1();

            /*" -443- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -444- DISPLAY 'ERRO SELECT V1SISTEMA VG' */
                _.Display($"ERRO SELECT V1SISTEMA VG");

                /*" -445- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -445- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMAS_DB_SELECT_1()
        {
            /*" -440- EXEC SQL SELECT DTMOVABE , CURRENT DATE , LAST_DAY(CURRENT DATE) + 1 DAY INTO :V1SIST-DTMOVABE , :V1SIST-DATA-HOJE , :V1SIST-DTREFFAT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DATA_HOJE, V1SIST_DATA_HOJE);
                _.Move(executed_1.V1SIST_DTREFFAT, V1SIST_DTREFFAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-SECTION */
        private void R0910_00_FETCH_CPROPVA_SECTION()
        {
            /*" -457- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -466- PERFORM R0910_00_FETCH_CPROPVA_DB_FETCH_1 */

            R0910_00_FETCH_CPROPVA_DB_FETCH_1();

            /*" -469- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -470- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -470- PERFORM R0910_00_FETCH_CPROPVA_DB_CLOSE_1 */

                    R0910_00_FETCH_CPROPVA_DB_CLOSE_1();

                    /*" -472- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -473- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -474- ELSE */
                }
                else
                {


                    /*" -475- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPVA   )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPVA   )...");

                    /*" -477- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -477- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-FETCH-1 */
        public void R0910_00_FETCH_CPROPVA_DB_FETCH_1()
        {
            /*" -466- EXEC SQL FETCH CPROPVA INTO :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTTERVIG, :V0PROP-DTCANCELA, :V0PROP-FONTE END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPVA.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVA.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPVA.V0PROP_DTTERVIG, V0PROP_DTTERVIG);
                _.Move(CPROPVA.V0PROP_DTCANCELA, V0PROP_DTCANCELA);
                _.Move(CPROPVA.V0PROP_FONTE, V0PROP_FONTE);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_CPROPVA_DB_CLOSE_1()
        {
            /*" -470- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -489- MOVE '100X' TO WNR-EXEC-SQL. */
            _.Move("100X", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -495- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -498- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -499- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -500- DISPLAY 'SEGURADO NAO INTEGRADO ' V0PROP-NRCERTIF */
                    _.Display($"SEGURADO NAO INTEGRADO {V0PROP_NRCERTIF}");

                    /*" -501- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -502- ELSE */
                }
                else
                {


                    /*" -504- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -505- IF V0SEGV-SITUACAO EQUAL '2' */

            if (V0SEGV_SITUACAO == "2")
            {

                /*" -506- DISPLAY 'SEGURADO CANCELADO     ' V0PROP-NRCERTIF */
                _.Display($"SEGURADO CANCELADO     {V0PROP_NRCERTIF}");

                /*" -508- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -509- IF V0PROP-DTTERVIG NOT LESS V1SIST-DATA-HOJE */

            if (V0PROP_DTTERVIG >= V1SIST_DATA_HOJE)
            {

                /*" -511- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -511- PERFORM R2000-00-CANCELA-SEGURO. */

            R2000_00_CANCELA_SEGURO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -495- EXEC SQL SELECT SIT_REGISTRO INTO :V0SEGV-SITUACAO FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGV_SITUACAO, V0SEGV_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -515- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-SECTION */
        private void R2000_00_CANCELA_SEGURO_SECTION()
        {
            /*" -530- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -542- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_1 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_1();

            /*" -545- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -547- MOVE 0 TO V0MOVI-COUNT. */
                _.Move(0, V0MOVI_COUNT);
            }


            /*" -548- IF V0MOVI-COUNT GREATER ZEROS */

            if (V0MOVI_COUNT > 00)
            {

                /*" -552- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -554- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -571- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_2 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_2();

            /*" -574- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -575- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -576- GO TO R2000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;

                    /*" -577- ELSE */
                }
                else
                {


                    /*" -578- DISPLAY 'R2000-00 (ERRO - SELECT V0SEGURAVG)' */
                    _.Display($"R2000-00 (ERRO - SELECT V0SEGURAVG)");

                    /*" -579- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -584- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -586- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -591- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_3 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_3();

            /*" -594- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -596- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -598- COMPUTE V0FONT-PROPAUTOM = V0FONT-PROPAUTOM + 1. */
            V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

            /*" -602- MOVE V1SIST-DTREFFAT TO V0FATC-DTREF. */
            _.Move(V1SIST_DTREFFAT, V0FATC_DTREF);

            /*" -604- MOVE '2080' TO WNR-EXEC-SQL. */
            _.Move("2080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -619- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_4 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_4();

            /*" -622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -623- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -625- MOVE ZEROS TO V0COBA-IMPMORNATU V0COBA-PRMVG */
                    _.Move(0, V0COBA_IMPMORNATU, V0COBA_PRMVG);

                    /*" -626- ELSE */
                }
                else
                {


                    /*" -627- DISPLAY 'R2000-00 (ERRO - SELECT V0COBERAPOL-VG)' */
                    _.Display($"R2000-00 (ERRO - SELECT V0COBERAPOL-VG)");

                    /*" -628- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -630- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -632- MOVE '2082' TO WNR-EXEC-SQL. */
            _.Move("2082", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -647- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_5 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_5();

            /*" -650- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -651- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -653- MOVE ZEROS TO V0COBA-IMPMORACID V0COBA-PRMAP */
                    _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);

                    /*" -654- ELSE */
                }
                else
                {


                    /*" -655- DISPLAY 'R2000-00 (ERRO - SELECT V0COBERAPOL-MA)' */
                    _.Display($"R2000-00 (ERRO - SELECT V0COBERAPOL-MA)");

                    /*" -656- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -659- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -661- MOVE '2084' TO WNR-EXEC-SQL. */
            _.Move("2084", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -674- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_6 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_6();

            /*" -677- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -679- MOVE 0 TO V0COBA-IMPINVPERM. */
                _.Move(0, V0COBA_IMPINVPERM);
            }


            /*" -681- MOVE '2086' TO WNR-EXEC-SQL. */
            _.Move("2086", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -694- PERFORM R2000_00_CANCELA_SEGURO_DB_SELECT_7 */

            R2000_00_CANCELA_SEGURO_DB_SELECT_7();

            /*" -697- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -699- MOVE 0 TO V0COBA-IMPDIT. */
                _.Move(0, V0COBA_IMPDIT);
            }


            /*" -701- IF V0COBA-PRMVG NOT GREATER ZEROS AND V0COBA-PRMAP NOT GREATER ZEROS */

            if (V0COBA_PRMVG <= 00 && V0COBA_PRMAP <= 00)
            {

                /*" -702- DISPLAY 'R2000-00 (ERRO - PREMIOS INVALIDOS VG AP )' */
                _.Display($"R2000-00 (ERRO - PREMIOS INVALIDOS VG AP )");

                /*" -703- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -703- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2000_20_PROPAUTOM */

            R2000_20_PROPAUTOM();

        }

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-1 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_1()
        {
            /*" -542- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :V0MOVI-COUNT FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' AND DATA_INCLUSAO IS NULL AND DATA_AVERBACAO IS NOT NULL AND COD_OPERACAO BETWEEN 300 AND 499 END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_1_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVI_COUNT, V0MOVI_COUNT);
            }


        }

        [StopWatch]
        /*" R2000-20-PROPAUTOM */
        private void R2000_20_PROPAUTOM(bool isPerform = false)
        {
            /*" -711- MOVE '2990' TO WNR-EXEC-SQL. */
            _.Move("2990", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -712- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -791- PERFORM R2000_20_PROPAUTOM_DB_INSERT_1 */

            R2000_20_PROPAUTOM_DB_INSERT_1();

            /*" -794- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -795- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -796- ADD 1 TO V0FONT-PROPAUTOM */
                    V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

                    /*" -797- GO TO R2000-20-PROPAUTOM */
                    new Task(() => R2000_20_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -798- ELSE */
                }
                else
                {


                    /*" -799- DISPLAY 'R2000-00 (ERRO - INSERT V0MOVIMENTO  )' */
                    _.Display($"R2000-00 (ERRO - INSERT V0MOVIMENTO  )");

                    /*" -802- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' 'FONTE:  ' V0PROP-FONTE ' ' 'PROPOS: ' V0FONT-PROPAUTOM */

                    $"CERTIF: {V0PROP_NRCERTIF} FONTE:  {V0PROP_FONTE} PROPOS: {V0FONT_PROPAUTOM}"
                    .Display();

                    /*" -804- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -805- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -809- MOVE '2060' TO WNR-EXEC-SQL. */
            _.Move("2060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -814- PERFORM R2000_20_PROPAUTOM_DB_UPDATE_1 */

            R2000_20_PROPAUTOM_DB_UPDATE_1();

            /*" -817- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -819- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -819- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R2000-20-PROPAUTOM-DB-INSERT-1 */
        public void R2000_20_PROPAUTOM_DB_INSERT_1()
        {
            /*" -791- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0FONT-PROPAUTOM, '1' , :V0PROP-NRCERTIF, ' ' , :V0SEGU-TPINCLUS, :V0SEGU-CODCLIEN, :V0SEGU-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , 01, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , 0, 0, ' ' , 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, 419, CURRENT DATE, 0, '1' , 'VA1651B' , CURRENT DATE, NULL, NULL, NULL, NULL, :V0FATC-DTREF, :V0PROP-DTCANCELA, NULL, :V0SEGU-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEG) END-EXEC. */

            var r2000_20_PROPAUTOM_DB_INSERT_1_Insert1 = new R2000_20_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SEGU_TPINCLUS = V0SEGU_TPINCLUS.ToString(),
                V0SEGU_CODCLIEN = V0SEGU_CODCLIEN.ToString(),
                V0SEGU_AGENCIADOR = V0SEGU_AGENCIADOR.ToString(),
                V0COBA_IMPMORNATU = V0COBA_IMPMORNATU.ToString(),
                V0COBA_IMPMORACID = V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = V0COBA_IMPDIT.ToString(),
                V0COBA_PRMVG = V0COBA_PRMVG.ToString(),
                V0COBA_PRMAP = V0COBA_PRMAP.ToString(),
                V0FATC_DTREF = V0FATC_DTREF.ToString(),
                V0PROP_DTCANCELA = V0PROP_DTCANCELA.ToString(),
                V0SEGU_LOT_EMP_SEGURADO = V0SEGU_LOT_EMP_SEGURADO.ToString(),
                VIND_LOT_EMP_SEG = VIND_LOT_EMP_SEG.ToString(),
            };

            R2000_20_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r2000_20_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2000-20-PROPAUTOM-DB-UPDATE-1 */
        public void R2000_20_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -814- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V0FONT-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0PROP-FONTE END-EXEC. */

            var r2000_20_PROPAUTOM_DB_UPDATE_1_Update1 = new R2000_20_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
            };

            R2000_20_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r2000_20_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-2 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_2()
        {
            /*" -571- EXEC SQL SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, LOT_EMP_SEGURADO, COD_CLIENTE INTO :V0SEGU-TPINCLUS, :V0SEGU-AGENCIADOR, :V0SEGU-ITEM, :V0SEGU-OCORHIST, :V0SEGU-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEG, :V0SEGU-CODCLIEN FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGU_TPINCLUS, V0SEGU_TPINCLUS);
                _.Move(executed_1.V0SEGU_AGENCIADOR, V0SEGU_AGENCIADOR);
                _.Move(executed_1.V0SEGU_ITEM, V0SEGU_ITEM);
                _.Move(executed_1.V0SEGU_OCORHIST, V0SEGU_OCORHIST);
                _.Move(executed_1.V0SEGU_LOT_EMP_SEGURADO, V0SEGU_LOT_EMP_SEGURADO);
                _.Move(executed_1.VIND_LOT_EMP_SEG, VIND_LOT_EMP_SEG);
                _.Move(executed_1.V0SEGU_CODCLIEN, V0SEGU_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-3 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_3()
        {
            /*" -591- EXEC SQL SELECT PROPAUTOM INTO :V0FONT-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :V0PROP-FONTE END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_3_Query1()
            {
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_3_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONT_PROPAUTOM, V0FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -831- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -833- DISPLAY 'CERTIFICADO......: ' V0PROP-NRCERTIF. */
            _.Display($"CERTIFICADO......: {V0PROP_NRCERTIF}");

            /*" -835- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -837- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERRO.WSQLERRMC);

            /*" -839- DISPLAY WSQLERRO */
            _.Display(AREA_DE_WORK.WSQLERRO);

            /*" -839- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -843- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -843- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-4 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_4()
        {
            /*" -619- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = :V1PAR-RAMO-VG AND MODALIFR >= 0 AND COD_COBERTURA = 11 WITH UR END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_4_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_4_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V1PAR_RAMO_VG = V1PAR_RAMO_VG.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_4_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, V0COBA_PRMVG);
            }


        }

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-5 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_5()
        {
            /*" -647- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, :V1PAR-RAMO-AP) AND MODALIFR >= 0 AND COD_COBERTURA = 1 WITH UR END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_5_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_5_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-6 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_6()
        {
            /*" -674- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, :V1PAR-RAMO-AP) AND MODALIFR >= 0 AND COD_COBERTURA = 2 WITH UR END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_6_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_6_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_6_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }

        [StopWatch]
        /*" R2000-00-CANCELA-SEGURO-DB-SELECT-7 */
        public void R2000_00_CANCELA_SEGURO_DB_SELECT_7()
        {
            /*" -694- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, :V1PAR-RAMO-AP) AND MODALIFR >= 0 AND COD_COBERTURA = 5 WITH UR END-EXEC. */

            var r2000_00_CANCELA_SEGURO_DB_SELECT_7_Query1 = new R2000_00_CANCELA_SEGURO_DB_SELECT_7_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R2000_00_CANCELA_SEGURO_DB_SELECT_7_Query1.Execute(r2000_00_CANCELA_SEGURO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }
    }
}