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
using Sias.VidaAzul.DB2.VA5421B;

namespace Code
{
    public class VA5421B
    {
        public bool IsCall { get; set; }

        public VA5421B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................  GERA MOVIMENTO DOS SEGURADOS COM SAF*      */
        /*"      *                            - SEGURADOS DA SUL AMERICA - COM FA-*      */
        /*"      *                            TURAMENTO NO DIA 31.                *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FREDERICO FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA5421B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  19/11/1999                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTREF                       PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTREABI                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTREABI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTINICDG                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTINICDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTQITBCO                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SIST-DTMOVABE                  PIC  X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0FATUR-DTREFER                  PIC  X(10).*/
        public StringBasis V0FATUR_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-DTREFERENCIA              PIC  X(10).*/
        public StringBasis V0RELA_DTREFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SAFC-DTINIVIG                  PIC  X(10).*/
        public StringBasis V0SAFC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SAFC-DTTERVIG                  PIC  X(10).*/
        public StringBasis V0SAFC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SAFC-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0SAFC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SAFC-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0SAFC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0SAFC-SEMSAF                    PIC  X(01) VALUE ' '.*/
        public StringBasis V0SAFC_SEMSAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"77  V0CDGC-DTINIVIG                  PIC  X(10).*/
        public StringBasis V0CDGC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CDGC-DTTERVIG                  PIC  X(10).*/
        public StringBasis V0CDGC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CDGC-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0CDGC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0CDGC-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0CDGC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0CDGC-DTINICDG                  PIC  X(10).*/
        public StringBasis V0CDGC_DTINICDG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HSAF-DTREF                     PIC  X(10).*/
        public StringBasis V0HSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HSAF-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HSAF_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HSAF-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HSAF_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HSAF-DTMOVTO                   PIC  X(10).*/
        public StringBasis V0HSAF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0COBV-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-VLCUSTCDG-I               PIC S9(04)    COMP.*/
        public IntBasis V0COBV_VLCUSTCDG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0COBV-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-IMPSEGCDG-I               PIC S9(04)    COMP.*/
        public IntBasis V0COBV_IMPSEGCDG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0COBV-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBV_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0COBV-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBV_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0PROP-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0PROP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PROP-NUM-MATRICULA             PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0PROP-NUM-MATRICULA-I           PIC S9(04)    COMP.*/
        public IntBasis V0PROP_NUM_MATRICULA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-DTQITBCO                  PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HSEG-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HSEG_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HSEG-DTMOVTO                   PIC  X(10).*/
        public StringBasis V0HSEG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HSEG-DTREABI                   PIC  X(10).*/
        public StringBasis V0HSEG_DTREABI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SEGV-NUMITEM                   PIC S9(09)    COMP.*/
        public IntBasis V0SEGV_NUMITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SEGV-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0SEGV_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SEGV-SITUACAO                  PIC  X(01).*/
        public StringBasis V0SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0FCEF-VALOR3                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FCEF_VALOR3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0FCEF-MESVIG                    PIC S9(04)    COMP.*/
        public IntBasis V0FCEF_MESVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SUBG-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0SUBG_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PROP-NUM-APOLANT               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PROP-CODSUBESANT               PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBESANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01     AC-L-SEGURAVG                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_SEGURAVG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-HISTSEGVG                PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_HISTSEGVG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-PROPOVA                  PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-CDGCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_CDGCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-COBERPROPVA              PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-CONTA                      PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-G-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_G_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-I-REPASSECDG               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_I_REPASSECDG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-I-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_I_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-C-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_C_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-C-CDGCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_C_CDGCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-R-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_R_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-R-CDGCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_R_CDGCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-A-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_A_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-C-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_C_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-S-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_S_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-I-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_I_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-R-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_R_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-D-CDG                      PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_D_CDG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-SEM-SAF                    PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_SEM_SAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     WFIM-CPROPOVA                 PIC X(01) VALUE SPACES.*/
        public StringBasis WFIM_CPROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WTEM-SOLICITACAO              PIC X(01) VALUE SPACES.*/
        public StringBasis WTEM_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WS-HOUVE-REABI                PIC X(03) VALUE 'NAO'.*/
        public StringBasis WS_HOUVE_REABI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"01     WTEM-COB-OPCIONAIS            PIC X(03) VALUE 'SIM'.*/
        public StringBasis WTEM_COB_OPCIONAIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
        /*"01     WTEM-COB-CDG                  PIC X(03) VALUE 'SIM'.*/
        public StringBasis WTEM_COB_CDG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
        /*"01     WTEM-COB-SAF                  PIC X(03) VALUE 'SIM'.*/
        public StringBasis WTEM_COB_SAF { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
        /*"01     WACHEI-SAF1                   PIC X(01) VALUE SPACES.*/
        public StringBasis WACHEI_SAF1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WACHEI-SAF2                   PIC X(01) VALUE SPACES.*/
        public StringBasis WACHEI_SAF2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WDATA-WORK.*/
        public VA5421B_WDATA_WORK WDATA_WORK { get; set; } = new VA5421B_WDATA_WORK();
        public class VA5421B_WDATA_WORK : VarBasis
        {
            /*"    05 ANO-WORK                   PIC 9(04).*/
            public IntBasis ANO_WORK { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 MES-WORK                   PIC 9(02).*/
            public IntBasis MES_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 DIA-WORK                   PIC 9(02).*/
            public IntBasis DIA_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WDATA-INIVIG.*/
        }
        public VA5421B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VA5421B_WDATA_INIVIG();
        public class VA5421B_WDATA_INIVIG : VarBasis
        {
            /*"    05 SEC-WORK-INIVIG            PIC 9(04).*/
            public IntBasis SEC_WORK_INIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 MES-WORK-INIVIG            PIC 9(02).*/
            public IntBasis MES_WORK_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 DIA-WORK-INIVIG            PIC 9(02).*/
            public IntBasis DIA_WORK_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WMES-VIG                      PIC 9(06).*/
        }
        public IntBasis WMES_VIG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
        /*"01     WMES-VIG-R REDEFINES WMES-VIG.*/
        private _REDEF_VA5421B_WMES_VIG_R _wmes_vig_r { get; set; }
        public _REDEF_VA5421B_WMES_VIG_R WMES_VIG_R
        {
            get { _wmes_vig_r = new _REDEF_VA5421B_WMES_VIG_R(); _.Move(WMES_VIG, _wmes_vig_r); VarBasis.RedefinePassValue(WMES_VIG, _wmes_vig_r, WMES_VIG); _wmes_vig_r.ValueChanged += () => { _.Move(_wmes_vig_r, WMES_VIG); }; return _wmes_vig_r; }
            set { VarBasis.RedefinePassValue(value, _wmes_vig_r, WMES_VIG); }
        }  //Redefines
        public class _REDEF_VA5421B_WMES_VIG_R : VarBasis
        {
            /*"    05 MES-VIG                    PIC 9(02).*/
            public IntBasis MES_VIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 ANO-VIG                    PIC 9(04).*/
            public IntBasis ANO_VIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01     WS-TIME                       PIC X(08).*/

            public _REDEF_VA5421B_WMES_VIG_R()
            {
                MES_VIG.ValueChanged += OnValueChanged;
                ANO_VIG.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01     WS-DATA-SQL.*/
        public VA5421B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA5421B_WS_DATA_SQL();
        public class VA5421B_WS_DATA_SQL : VarBasis
        {
            /*"    05 WS-ANO-SQL                 PIC 9(04).*/
            public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 WS-MES-SQL                 PIC 9(02).*/
            public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 WS-DIA-SQL                 PIC 9(02).*/
            public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WS-DTQITBCO                   PIC 9(008).*/
        }
        public IntBasis WS_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01     FILLER REDEFINES WS-DTQITBCO.*/
        private _REDEF_VA5421B_FILLER_6 _filler_6 { get; set; }
        public _REDEF_VA5421B_FILLER_6 FILLER_6
        {
            get { _filler_6 = new _REDEF_VA5421B_FILLER_6(); _.Move(WS_DTQITBCO, _filler_6); VarBasis.RedefinePassValue(WS_DTQITBCO, _filler_6, WS_DTQITBCO); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_DTQITBCO); }; return _filler_6; }
            set { VarBasis.RedefinePassValue(value, _filler_6, WS_DTQITBCO); }
        }  //Redefines
        public class _REDEF_VA5421B_FILLER_6 : VarBasis
        {
            /*"    05 WS-AAQITBCO                PIC 9(04).*/
            public IntBasis WS_AAQITBCO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-MMQITBCO                PIC 9(02).*/
            public IntBasis WS_MMQITBCO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DDQITBCO                PIC 9(02).*/
            public IntBasis WS_DDQITBCO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WS-DTREFER                    PIC 9(008).*/

            public _REDEF_VA5421B_FILLER_6()
            {
                WS_AAQITBCO.ValueChanged += OnValueChanged;
                WS_MMQITBCO.ValueChanged += OnValueChanged;
                WS_DDQITBCO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_DTREFER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01     FILLER REDEFINES WS-DTREFER.*/
        private _REDEF_VA5421B_FILLER_7 _filler_7 { get; set; }
        public _REDEF_VA5421B_FILLER_7 FILLER_7
        {
            get { _filler_7 = new _REDEF_VA5421B_FILLER_7(); _.Move(WS_DTREFER, _filler_7); VarBasis.RedefinePassValue(WS_DTREFER, _filler_7, WS_DTREFER); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_DTREFER); }; return _filler_7; }
            set { VarBasis.RedefinePassValue(value, _filler_7, WS_DTREFER); }
        }  //Redefines
        public class _REDEF_VA5421B_FILLER_7 : VarBasis
        {
            /*"    05 WS-AAREFER                 PIC 9(04).*/
            public IntBasis WS_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-MMREFER                 PIC 9(02).*/
            public IntBasis WS_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DDREFER                 PIC 9(02).*/
            public IntBasis WS_DDREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WABEND.*/

            public _REDEF_VA5421B_FILLER_7()
            {
                WS_AAREFER.ValueChanged += OnValueChanged;
                WS_MMREFER.ValueChanged += OnValueChanged;
                WS_DDREFER.ValueChanged += OnValueChanged;
            }

        }
        public VA5421B_WABEND WABEND { get; set; } = new VA5421B_WABEND();
        public class VA5421B_WABEND : VarBasis
        {
            /*"    05    FILLER*/
            public VA5421B_FILLER_8 FILLER_8 { get; set; } = new VA5421B_FILLER_8();
            public class VA5421B_FILLER_8 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(016) VALUE            '*** VA5421B *** '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VA5421B *** ");
                /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
                /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA5421B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA5421B_LOCALIZA_ABEND_1();
            public class VA5421B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA5421B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA5421B_LOCALIZA_ABEND_2();
            public class VA5421B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA5421B_CPROPOVA CPROPOVA { get; set; } = new VA5421B_CPROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -250- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -252- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -254- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -258- MOVE 'R000-VA5421B  ' TO PARAGRAFO. */
                _.Move("R000-VA5421B  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                /*" -260- PERFORM R001-SELECT-SISTEMA. */

                R001_SELECT_SISTEMA_SECTION();

                /*" -262- PERFORM R002-SELECT-RELATORIOS. */

                R002_SELECT_RELATORIOS_SECTION();

                /*" -263- IF WTEM-SOLICITACAO = 'N' */

                if (WTEM_SOLICITACAO == "N")
                {

                    /*" -264- DISPLAY '*----------------------------------*' */
                    _.Display($"*----------------------------------*");

                    /*" -265- DISPLAY '*--- VA5421B ** TERMINO NORMAL ---**' */
                    _.Display($"*--- VA5421B ** TERMINO NORMAL ---**");

                    /*" -266- DISPLAY '*- NAO HA SOLICITACAO  NESTA DATA -*' */
                    _.Display($"*- NAO HA SOLICITACAO  NESTA DATA -*");

                    /*" -267- DISPLAY '*----------------------------------*' */
                    _.Display($"*----------------------------------*");

                    /*" -268- MOVE ZEROS TO RETURN-CODE */
                    _.Move(0, RETURN_CODE);

                    /*" -270- STOP RUN. */

                    throw new GoBack();   // => STOP RUN.
                }


                /*" -272- PERFORM R010-DECLARE-PROPOVA. */

                R010_DECLARE_PROPOVA_SECTION();

                /*" -274- PERFORM R020-FETCH-PROPOVA. */

                R020_FETCH_PROPOVA_SECTION();

                /*" -275- IF WFIM-CPROPOVA EQUAL ' ' */

                if (WFIM_CPROPOVA == " ")
                {

                    /*" -276- DISPLAY '** VA5421B ** PROCESSANDO ...' */
                    _.Display($"** VA5421B ** PROCESSANDO ...");

                    /*" -277- ELSE */
                }
                else
                {


                    /*" -278- DISPLAY '** VA5421B ** S/ MOVIM. NESTA DATA ...' */
                    _.Display($"** VA5421B ** S/ MOVIM. NESTA DATA ...");

                    /*" -278- EXEC SQL COMMIT WORK END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -281- STOP RUN. */

                    throw new GoBack();   // => STOP RUN.
                }


                /*" -283- PERFORM R025-SELECT-DTREFER */

                R025_SELECT_DTREFER_SECTION();

                /*" -284- MOVE V0PROP-NUM-APOLICE TO V0PROP-NUM-APOLANT. */
                _.Move(V0PROP_NUM_APOLICE, V0PROP_NUM_APOLANT);

                /*" -286- MOVE V0PROP-CODSUBES TO V0PROP-CODSUBESANT. */
                _.Move(V0PROP_CODSUBES, V0PROP_CODSUBESANT);

                /*" -290- PERFORM R030-PROCESSAMENTO THRU R030-EXIT UNTIL WFIM-CPROPOVA EQUAL 'S' . */

                while (!(WFIM_CPROPOVA == "S"))
                {

                    R030_PROCESSAMENTO_SECTION();

                    R030_NEXT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -291- MOVE 'COMMIT WORK' TO COMANDO. */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -291- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -294- DISPLAY '** VA5421B ** LIDOS PROPOVA     ' AC-L-PROPOVA */
                _.Display($"** VA5421B ** LIDOS PROPOVA     {AC_L_PROPOVA}");

                /*" -295- DISPLAY '** VA5421B ** LIDOS COBERPROP   ' AC-L-COBERPROPVA */
                _.Display($"** VA5421B ** LIDOS COBERPROP   {AC_L_COBERPROPVA}");

                /*" -296- DISPLAY '** VA5421B ** LIDOS SAFCOBER    ' AC-L-SAFCOBER */
                _.Display($"** VA5421B ** LIDOS SAFCOBER    {AC_L_SAFCOBER}");

                /*" -297- DISPLAY '** VA5421B ** LIDOS CDGCOBER    ' AC-L-CDGCOBER */
                _.Display($"** VA5421B ** LIDOS CDGCOBER    {AC_L_CDGCOBER}");

                /*" -298- DISPLAY '** VA5421B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
                _.Display($"** VA5421B ** LIDOS SEGURAVG    {AC_L_SEGURAVG}");

                /*" -299- DISPLAY '** VA5421B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
                _.Display($"** VA5421B ** LIDOS HISTSEGVG   {AC_L_HISTSEGVG}");

                /*" -300- DISPLAY '                                ' . */
                _.Display($"                                ");

                /*" -301- DISPLAY '** VA5421B ** INCL. HISTREPSAF  ' AC-I-HISTREPSAF */
                _.Display($"** VA5421B ** INCL. HISTREPSAF  {AC_I_HISTREPSAF}");

                /*" -302- DISPLAY '** VA5421B ** INCL. REPASSECDG  ' AC-I-REPASSECDG */
                _.Display($"** VA5421B ** INCL. REPASSECDG  {AC_I_REPASSECDG}");

                /*" -303- DISPLAY '** VA5421B ** AVER. HISTREPSAF  ' AC-A-HISTREPSAF */
                _.Display($"** VA5421B ** AVER. HISTREPSAF  {AC_A_HISTREPSAF}");

                /*" -304- DISPLAY '** VA5421B ** AVER. REPASSECDG  ' AC-I-REPASSECDG */
                _.Display($"** VA5421B ** AVER. REPASSECDG  {AC_I_REPASSECDG}");

                /*" -305- DISPLAY '** VA5421B ** CANC. SAFCOBER    ' AC-C-SAFCOBER */
                _.Display($"** VA5421B ** CANC. SAFCOBER    {AC_C_SAFCOBER}");

                /*" -306- DISPLAY '** VA5421B ** CANC. HISTREPSAF  ' AC-C-HISTREPSAF */
                _.Display($"** VA5421B ** CANC. HISTREPSAF  {AC_C_HISTREPSAF}");

                /*" -307- DISPLAY '** VA5421B ** CANC. CDGCOBER    ' AC-C-CDGCOBER */
                _.Display($"** VA5421B ** CANC. CDGCOBER    {AC_C_CDGCOBER}");

                /*" -308- DISPLAY '** VA5421B ** SUSP. HISTREPSAF  ' AC-S-HISTREPSAF */
                _.Display($"** VA5421B ** SUSP. HISTREPSAF  {AC_S_HISTREPSAF}");

                /*" -309- DISPLAY '** VA5421B ** REAB. SAFCOBER    ' AC-R-SAFCOBER */
                _.Display($"** VA5421B ** REAB. SAFCOBER    {AC_R_SAFCOBER}");

                /*" -310- DISPLAY '** VA5421B ** REAB. HISTREPSAF  ' AC-R-HISTREPSAF */
                _.Display($"** VA5421B ** REAB. HISTREPSAF  {AC_R_HISTREPSAF}");

                /*" -311- DISPLAY '** VA5421B ** REAB. CDGCOBER    ' AC-R-CDGCOBER */
                _.Display($"** VA5421B ** REAB. CDGCOBER    {AC_R_CDGCOBER}");

                /*" -312- DISPLAY '** VA5421B ** DESP. REPASSECDG  ' AC-D-CDG */
                _.Display($"** VA5421B ** DESP. REPASSECDG  {AC_D_CDG}");

                /*" -313- DISPLAY '                                ' . */
                _.Display($"                                ");

                /*" -315- DISPLAY '** VA5421B ** TERMINO NORMAL    ' . */
                _.Display($"** VA5421B ** TERMINO NORMAL    ");

                /*" -317- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -317- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R001-SELECT-SISTEMA-SECTION */
        private void R001_SELECT_SISTEMA_SECTION()
        {
            /*" -325- MOVE 'R001-SELECT-SISTEMA ' TO PARAGRAFO. */
            _.Move("R001-SELECT-SISTEMA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -330- PERFORM R001_SELECT_SISTEMA_DB_SELECT_1 */

            R001_SELECT_SISTEMA_DB_SELECT_1();

            /*" -333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -334- DISPLAY 'R001 - PROBLEMAS SELECT V0SISTEMA ....' */
                _.Display($"R001 - PROBLEMAS SELECT V0SISTEMA ....");

                /*" -335- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -335- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R001-SELECT-SISTEMA-DB-SELECT-1 */
        public void R001_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -330- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VP' END-EXEC. */

            var r001_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R001_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R001_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r001_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R001_EXIT*/

        [StopWatch]
        /*" R002-SELECT-RELATORIOS-SECTION */
        private void R002_SELECT_RELATORIOS_SECTION()
        {
            /*" -345- MOVE 'R002-SELECT-RELATORIOS ' TO PARAGRAFO. */
            _.Move("R002-SELECT-RELATORIOS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -351- PERFORM R002_SELECT_RELATORIOS_DB_SELECT_1 */

            R002_SELECT_RELATORIOS_DB_SELECT_1();

            /*" -354- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -355- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -356- MOVE 'N' TO WTEM-SOLICITACAO */
                    _.Move("N", WTEM_SOLICITACAO);

                    /*" -357- ELSE */
                }
                else
                {


                    /*" -358- DISPLAY 'R002 - PROBLEMAS SELECT V0RELATORIOS .' */
                    _.Display($"R002 - PROBLEMAS SELECT V0RELATORIOS .");

                    /*" -359- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -359- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R002-SELECT-RELATORIOS-DB-SELECT-1 */
        public void R002_SELECT_RELATORIOS_DB_SELECT_1()
        {
            /*" -351- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DTREFERENCIA FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA1417B' AND SITUACAO = '0' END-EXEC. */

            var r002_SELECT_RELATORIOS_DB_SELECT_1_Query1 = new R002_SELECT_RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R002_SELECT_RELATORIOS_DB_SELECT_1_Query1.Execute(r002_SELECT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DTREFERENCIA, V0RELA_DTREFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R002_EXIT*/

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-SECTION */
        private void R010_DECLARE_PROPOVA_SECTION()
        {
            /*" -369- MOVE 'R010-DECLARE-PROPOVA' TO PARAGRAFO. */
            _.Move("R010-DECLARE-PROPOVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -392- PERFORM R010_DECLARE_PROPOVA_DB_DECLARE_1 */

            R010_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -394- PERFORM R010_DECLARE_PROPOVA_DB_OPEN_1 */

            R010_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -397- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -398- DISPLAY 'R010 - PROBLEMAS DECLARE CPROPOVA ....' */
                _.Display($"R010 - PROBLEMAS DECLARE CPROPOVA ....");

                /*" -399- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -399- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R010_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -392- EXEC SQL DECLARE CPROPOVA CURSOR FOR SELECT A.NRCERTIF, A.CODCLIEN, A.CODOPER, A.SITUACAO, A.OCORHIST, A.NUM_MATRICULA, A.DTQITBCO + 6 MONTHS, A.DTQITBCO, B.NUM_APOLICE, B.CODSUBES, C.COD_CLIENTE FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B, SEGUROS.V0SUBGRUPO C WHERE B.DIA_FATURA = 31 AND B.COD_SEGU_SAF = 2 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.CODSUBES = B.CODSUBES AND A.NUM_APOLICE = C.NUM_APOLICE AND A.CODSUBES = C.COD_SUBGRUPO AND A.SITUACAO IN ( '3' , '4' , '6' ) ORDER BY B.NUM_APOLICE, B.CODSUBES, A.NRCERTIF END-EXEC. */
            CPROPOVA = new VA5421B_CPROPOVA(false);
            string GetQuery_CPROPOVA()
            {
                var query = @$"SELECT A.NRCERTIF
							, 
							A.CODCLIEN
							, 
							A.CODOPER
							, 
							A.SITUACAO
							, 
							A.OCORHIST
							, 
							A.NUM_MATRICULA
							, 
							A.DTQITBCO + 6 MONTHS
							, 
							A.DTQITBCO
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							C.COD_CLIENTE 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0PRODUTOSVG B
							, 
							SEGUROS.V0SUBGRUPO C 
							WHERE B.DIA_FATURA = 31 
							AND B.COD_SEGU_SAF = 2 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.CODSUBES = B.CODSUBES 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.CODSUBES = C.COD_SUBGRUPO 
							AND A.SITUACAO IN ( '3'
							, '4'
							, '6' ) 
							ORDER BY B.NUM_APOLICE
							, B.CODSUBES
							, A.NRCERTIF";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R010_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -394- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-FETCH-PROPOVA-SECTION */
        private void R020_FETCH_PROPOVA_SECTION()
        {
            /*" -409- MOVE 'R020-FETCH-PROPOVA ' TO PARAGRAFO. */
            _.Move("R020-FETCH-PROPOVA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -421- PERFORM R020_FETCH_PROPOVA_DB_FETCH_1 */

            R020_FETCH_PROPOVA_DB_FETCH_1();

            /*" -424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -425- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -426- MOVE 'S' TO WFIM-CPROPOVA */
                    _.Move("S", WFIM_CPROPOVA);

                    /*" -426- PERFORM R020_FETCH_PROPOVA_DB_CLOSE_1 */

                    R020_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -428- ELSE */
                }
                else
                {


                    /*" -429- DISPLAY 'R020 - (PROBLEMAS NO FETCH CPROPOVA ....' */
                    _.Display($"R020 - (PROBLEMAS NO FETCH CPROPOVA ....");

                    /*" -430- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -430- PERFORM R020_FETCH_PROPOVA_DB_CLOSE_2 */

                    R020_FETCH_PROPOVA_DB_CLOSE_2();

                    /*" -432- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -433- ELSE */
                }

            }
            else
            {


                /*" -435- ADD 1 TO AC-L-PROPOVA AC-CONTA. */
                AC_L_PROPOVA.Value = AC_L_PROPOVA + 1;
                AC_CONTA.Value = AC_CONTA + 1;
            }


            /*" -436- IF AC-CONTA > 999 */

            if (AC_CONTA > 999)
            {

                /*" -437- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -438- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -440- DISPLAY 'LIDOS ' AC-L-PROPOVA ' ' WS-TIME. */

                $"LIDOS {AC_L_PROPOVA} {WS_TIME}"
                .Display();
            }


            /*" -441- IF V0PROP-NUM-MATRICULA-I LESS ZEROS */

            if (V0PROP_NUM_MATRICULA_I < 00)
            {

                /*" -441- MOVE ZEROS TO V0PROP-NUM-MATRICULA. */
                _.Move(0, V0PROP_NUM_MATRICULA);
            }


        }

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-FETCH-1 */
        public void R020_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -421- EXEC SQL FETCH CPROPOVA INTO :V0PROP-NRCERTIF, :V0PROP-CODCLIEN, :V0PROP-CODOPER, :V0PROP-SITUACAO, :V0PROP-OCORHIST, :V0PROP-NUM-MATRICULA:V0PROP-NUM-MATRICULA-I, :V0CDGC-DTINICDG:VIND-DTINICDG, :V0PROP-DTQITBCO:VIND-DTQITBCO, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0SUBG-CODCLIEN END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPOVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPOVA.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPOVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPOVA.V0PROP_OCORHIST, V0PROP_OCORHIST);
                _.Move(CPROPOVA.V0PROP_NUM_MATRICULA, V0PROP_NUM_MATRICULA);
                _.Move(CPROPOVA.V0PROP_NUM_MATRICULA_I, V0PROP_NUM_MATRICULA_I);
                _.Move(CPROPOVA.V0CDGC_DTINICDG, V0CDGC_DTINICDG);
                _.Move(CPROPOVA.VIND_DTINICDG, VIND_DTINICDG);
                _.Move(CPROPOVA.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPOVA.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(CPROPOVA.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPOVA.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPOVA.V0SUBG_CODCLIEN, V0SUBG_CODCLIEN);
            }

        }

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R020_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -426- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-CLOSE-2 */
        public void R020_FETCH_PROPOVA_DB_CLOSE_2()
        {
            /*" -430- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }

        [StopWatch]
        /*" R030-PROCESSAMENTO-SECTION */
        private void R030_PROCESSAMENTO_SECTION()
        {
            /*" -452- IF V0PROP-NUM-APOLICE NOT EQUAL V0PROP-NUM-APOLANT */

            if (V0PROP_NUM_APOLICE != V0PROP_NUM_APOLANT)
            {

                /*" -453- MOVE V0PROP-NUM-APOLICE TO V0PROP-NUM-APOLANT */
                _.Move(V0PROP_NUM_APOLICE, V0PROP_NUM_APOLANT);

                /*" -454- MOVE V0PROP-CODSUBES TO V0PROP-CODSUBESANT */
                _.Move(V0PROP_CODSUBES, V0PROP_CODSUBESANT);

                /*" -456- PERFORM R025-SELECT-DTREFER. */

                R025_SELECT_DTREFER_SECTION();
            }


            /*" -457- IF V0PROP-CODSUBES NOT EQUAL V0PROP-CODSUBESANT */

            if (V0PROP_CODSUBES != V0PROP_CODSUBESANT)
            {

                /*" -458- MOVE V0PROP-CODSUBES TO V0PROP-CODSUBESANT */
                _.Move(V0PROP_CODSUBES, V0PROP_CODSUBESANT);

                /*" -460- PERFORM R025-SELECT-DTREFER. */

                R025_SELECT_DTREFER_SECTION();
            }


            /*" -462- MOVE V0PROP-DTQITBCO TO WS-DATA-SQL. */
            _.Move(V0PROP_DTQITBCO, WS_DATA_SQL);

            /*" -463- MOVE WS-ANO-SQL TO WS-AAQITBCO */
            _.Move(WS_DATA_SQL.WS_ANO_SQL, FILLER_6.WS_AAQITBCO);

            /*" -464- MOVE WS-MES-SQL TO WS-MMQITBCO */
            _.Move(WS_DATA_SQL.WS_MES_SQL, FILLER_6.WS_MMQITBCO);

            /*" -469- MOVE 01 TO WS-DDQITBCO. */
            _.Move(01, FILLER_6.WS_DDQITBCO);

            /*" -470- IF WS-DTREFER LESS WS-DTQITBCO */

            if (WS_DTREFER < WS_DTQITBCO)
            {

                /*" -472- GO TO R030-NEXT. */

                R030_NEXT(); //GOTO
                return;
            }


            /*" -473- MOVE 'SIM' TO WTEM-COB-OPCIONAIS. */
            _.Move("SIM", WTEM_COB_OPCIONAIS);

            /*" -474- MOVE 'SIM' TO WTEM-COB-CDG. */
            _.Move("SIM", WTEM_COB_CDG);

            /*" -476- MOVE 'SIM' TO WTEM-COB-SAF. */
            _.Move("SIM", WTEM_COB_SAF);

            /*" -478- PERFORM R040-SELECT-COBERPROPVA. */

            R040_SELECT_COBERPROPVA_SECTION();

            /*" -480- IF V0COBV-VLCUSTAUXF-I LESS 0 OR V0COBV-VLCUSTAUXF EQUAL ZEROS */

            if (V0COBV_VLCUSTAUXF_I < 0 || V0COBV_VLCUSTAUXF == 00)
            {

                /*" -481- DISPLAY 'SEGURADO NAO POSSUI COBERTURA SAF' */
                _.Display($"SEGURADO NAO POSSUI COBERTURA SAF");

                /*" -482- MOVE 'NAO' TO WTEM-COB-SAF */
                _.Move("NAO", WTEM_COB_SAF);

                /*" -483- ELSE */
            }
            else
            {


                /*" -485- IF V0COBV-VLCUSTCDG-I LESS 0 OR V0COBV-VLCUSTCDG EQUAL ZEROS */

                if (V0COBV_VLCUSTCDG_I < 0 || V0COBV_VLCUSTCDG == 00)
                {

                    /*" -486- DISPLAY 'SEGURADO NAO POSSUI COBERTURA CDG' */
                    _.Display($"SEGURADO NAO POSSUI COBERTURA CDG");

                    /*" -488- MOVE 'NAO' TO WTEM-COB-CDG. */
                    _.Move("NAO", WTEM_COB_CDG);
                }

            }


            /*" -490- IF WTEM-COB-CDG EQUAL 'NAO' AND WTEM-COB-SAF EQUAL 'NAO' */

            if (WTEM_COB_CDG == "NAO" && WTEM_COB_SAF == "NAO")
            {

                /*" -492- MOVE 'NAO' TO WTEM-COB-OPCIONAIS. */
                _.Move("NAO", WTEM_COB_OPCIONAIS);
            }


            /*" -493- IF WTEM-COB-OPCIONAIS EQUAL 'NAO' */

            if (WTEM_COB_OPCIONAIS == "NAO")
            {

                /*" -494- DISPLAY '*----------------------------------*' */
                _.Display($"*----------------------------------*");

                /*" -495- DISPLAY '*---          VA5421B           ---*' */
                _.Display($"*---          VA5421B           ---*");

                /*" -496- DISPLAY '  SEGURADO NAO POSSUI COBS.OPCIONAIS' */
                _.Display($"  SEGURADO NAO POSSUI COBS.OPCIONAIS");

                /*" -497- DISPLAY '  ' V0PROP-NRCERTIF */
                _.Display($"  {V0PROP_NRCERTIF}");

                /*" -498- DISPLAY '*----------------------------------*' */
                _.Display($"*----------------------------------*");

                /*" -500- GO TO R030-NEXT. */

                R030_NEXT(); //GOTO
                return;
            }


            /*" -502- MOVE V0FATUR-DTREFER TO WDATA-INIVIG. */
            _.Move(V0FATUR_DTREFER, WDATA_INIVIG);

            /*" -504- PERFORM R060-SELECT-SEGURAVG. */

            R060_SELECT_SEGURAVG_SECTION();

            /*" -506- PERFORM R070-SELECT-HISTSEGVG. */

            R070_SELECT_HISTSEGVG_SECTION();

            /*" -507- IF WTEM-COB-SAF EQUAL 'SIM' */

            if (WTEM_COB_SAF == "SIM")
            {

                /*" -509- PERFORM R080-PROCESSA-COB-SAF. */

                R080_PROCESSA_COB_SAF_SECTION();
            }


            /*" -510- IF WTEM-COB-CDG EQUAL 'SIM' */

            if (WTEM_COB_CDG == "SIM")
            {

                /*" -510- PERFORM R110-PROCESSA-COB-CDG. */

                R110_PROCESSA_COB_CDG_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R030_NEXT */

            R030_NEXT();

        }

        [StopWatch]
        /*" R030-NEXT */
        private void R030_NEXT(bool isPerform = false)
        {
            /*" -514- PERFORM R020-FETCH-PROPOVA. */

            R020_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R040-SELECT-COBERPROPVA-SECTION */
        private void R040_SELECT_COBERPROPVA_SECTION()
        {
            /*" -524- MOVE 'SELECT R040-COBERPROPVA' TO PARAGRAFO. */
            _.Move("SELECT R040-COBERPROPVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -536- PERFORM R040_SELECT_COBERPROPVA_DB_SELECT_1 */

            R040_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -542- DISPLAY 'R040 - PROBLEMAS SELECT V0COBERPROPVA.' ' CERT ' V0PROP-NRCERTIF ' ' ' OCOH ' V0PROP-OCORHIST */

                $"R040 - PROBLEMAS SELECT V0COBERPROPVA. CERT {V0PROP_NRCERTIF}  OCOH {V0PROP_OCORHIST}"
                .Display();

                /*" -544- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -544- ADD 1 TO AC-L-COBERPROPVA. */
            AC_L_COBERPROPVA.Value = AC_L_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R040-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R040_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -536- EXEC SQL SELECT IMPSEGCDC, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF INTO :V0COBV-IMPSEGCDG:V0COBV-IMPSEGCDG-I, :V0COBV-VLCUSTCDG:V0COBV-VLCUSTCDG-I, :V0COBV-IMPSEGAUXF:V0COBV-IMPSEGAUXF-I, :V0COBV-VLCUSTAUXF:V0COBV-VLCUSTAUXF-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 = new R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1.Execute(r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBV_IMPSEGCDG, V0COBV_IMPSEGCDG);
                _.Move(executed_1.V0COBV_IMPSEGCDG_I, V0COBV_IMPSEGCDG_I);
                _.Move(executed_1.V0COBV_VLCUSTCDG, V0COBV_VLCUSTCDG);
                _.Move(executed_1.V0COBV_VLCUSTCDG_I, V0COBV_VLCUSTCDG_I);
                _.Move(executed_1.V0COBV_IMPSEGAUXF, V0COBV_IMPSEGAUXF);
                _.Move(executed_1.V0COBV_IMPSEGAUXF_I, V0COBV_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBV_VLCUSTAUXF, V0COBV_VLCUSTAUXF);
                _.Move(executed_1.V0COBV_VLCUSTAUXF_I, V0COBV_VLCUSTAUXF_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R025-SELECT-DTREFER-SECTION */
        private void R025_SELECT_DTREFER_SECTION()
        {
            /*" -553- MOVE 'SELECT R025-DTREFER' TO PARAGRAFO. */
            _.Move("SELECT R025-DTREFER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -559- PERFORM R025_SELECT_DTREFER_DB_SELECT_1 */

            R025_SELECT_DTREFER_DB_SELECT_1();

            /*" -562- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -563- DISPLAY 'R025 - PROBLEMAS ACESSO A V0HISTREPSAF..' */
                _.Display($"R025 - PROBLEMAS ACESSO A V0HISTREPSAF..");

                /*" -564- DISPLAY 'CODCLIEN....  ' V0SUBG-CODCLIEN */
                _.Display($"CODCLIEN....  {V0SUBG_CODCLIEN}");

                /*" -565- DISPLAY 'COPDOPER....  ' 1800 */
                _.Display($"COPDOPER....  1800");

                /*" -566- DISPLAY 'SQLCODE  ' SQLCODE */
                _.Display($"SQLCODE  {DB.SQLCODE}");

                /*" -568- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -569- IF VIND-DTREF LESS 0 */

            if (VIND_DTREF < 0)
            {

                /*" -570- DISPLAY 'DATA REFERENCIA NULA ' */
                _.Display($"DATA REFERENCIA NULA ");

                /*" -571- DISPLAY 'V0FATUR-DTREFER..... ' V0FATUR-DTREFER */
                _.Display($"V0FATUR-DTREFER..... {V0FATUR_DTREFER}");

                /*" -573- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -575- MOVE V0FATUR-DTREFER TO WS-DATA-SQL. */
            _.Move(V0FATUR_DTREFER, WS_DATA_SQL);

            /*" -576- MOVE WS-ANO-SQL TO WS-AAREFER */
            _.Move(WS_DATA_SQL.WS_ANO_SQL, FILLER_7.WS_AAREFER);

            /*" -577- MOVE WS-MES-SQL TO WS-MMREFER */
            _.Move(WS_DATA_SQL.WS_MES_SQL, FILLER_7.WS_MMREFER);

            /*" -577- MOVE 01 TO WS-DDREFER. */
            _.Move(01, FILLER_7.WS_DDREFER);

        }

        [StopWatch]
        /*" R025-SELECT-DTREFER-DB-SELECT-1 */
        public void R025_SELECT_DTREFER_DB_SELECT_1()
        {
            /*" -559- EXEC SQL SELECT MAX(DTREF) + 1 MONTH INTO :V0FATUR-DTREFER FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0SUBG-CODCLIEN AND CODOPER = 1800 END-EXEC. */

            var r025_SELECT_DTREFER_DB_SELECT_1_Query1 = new R025_SELECT_DTREFER_DB_SELECT_1_Query1()
            {
                V0SUBG_CODCLIEN = V0SUBG_CODCLIEN.ToString(),
            };

            var executed_1 = R025_SELECT_DTREFER_DB_SELECT_1_Query1.Execute(r025_SELECT_DTREFER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FATUR_DTREFER, V0FATUR_DTREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R025_EXIT*/

        [StopWatch]
        /*" R060-SELECT-SEGURAVG-SECTION */
        private void R060_SELECT_SEGURAVG_SECTION()
        {
            /*" -587- MOVE 'SELECT R060-SEGURAVG   ' TO PARAGRAFO. */
            _.Move("SELECT R060-SEGURAVG   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -597- PERFORM R060_SELECT_SEGURAVG_DB_SELECT_1 */

            R060_SELECT_SEGURAVG_DB_SELECT_1();

            /*" -600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -602- DISPLAY 'R060 - PROBLEMAS SELECT V0SEGURAVG  ..' ' CERT ' V0PROP-NRCERTIF */

                $"R060 - PROBLEMAS SELECT V0SEGURAVG  .. CERT {V0PROP_NRCERTIF}"
                .Display();

                /*" -604- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -604- ADD 1 TO AC-L-SEGURAVG. */
            AC_L_SEGURAVG.Value = AC_L_SEGURAVG + 1;

        }

        [StopWatch]
        /*" R060-SELECT-SEGURAVG-DB-SELECT-1 */
        public void R060_SELECT_SEGURAVG_DB_SELECT_1()
        {
            /*" -597- EXEC SQL SELECT SIT_REGISTRO, OCORR_HISTORICO, NUM_ITEM INTO :V0SEGV-SITUACAO, :V0SEGV-OCORHIST, :V0SEGV-NUMITEM FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r060_SELECT_SEGURAVG_DB_SELECT_1_Query1 = new R060_SELECT_SEGURAVG_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R060_SELECT_SEGURAVG_DB_SELECT_1_Query1.Execute(r060_SELECT_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGV_SITUACAO, V0SEGV_SITUACAO);
                _.Move(executed_1.V0SEGV_OCORHIST, V0SEGV_OCORHIST);
                _.Move(executed_1.V0SEGV_NUMITEM, V0SEGV_NUMITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

        [StopWatch]
        /*" R070-SELECT-HISTSEGVG-SECTION */
        private void R070_SELECT_HISTSEGVG_SECTION()
        {
            /*" -616- MOVE 'R070-SELECT V0HISTSEGVG' TO PARAGRAFO. */
            _.Move("R070-SELECT V0HISTSEGVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -627- PERFORM R070_SELECT_HISTSEGVG_DB_SELECT_1 */

            R070_SELECT_HISTSEGVG_DB_SELECT_1();

            /*" -630- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -634- DISPLAY 'R070 - PROBLEMAS SELECT V0HISTSEGVG ..' ' CERT ' V0PROP-NRCERTIF ' ' ' ITEM ' V0SEGV-NUMITEM ' ' ' OCOH ' V0SEGV-OCORHIST */

                $"R070 - PROBLEMAS SELECT V0HISTSEGVG .. CERT {V0PROP_NRCERTIF}  ITEM {V0SEGV_NUMITEM}  OCOH {V0SEGV_OCORHIST}"
                .Display();

                /*" -636- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -636- ADD 1 TO AC-L-HISTSEGVG. */
            AC_L_HISTSEGVG.Value = AC_L_HISTSEGVG + 1;

        }

        [StopWatch]
        /*" R070-SELECT-HISTSEGVG-DB-SELECT-1 */
        public void R070_SELECT_HISTSEGVG_DB_SELECT_1()
        {
            /*" -627- EXEC SQL SELECT COD_OPERACAO, DATA_MOVIMENTO, DATA_MOVIMENTO + 6 MONTHS INTO :V0HSEG-CODOPER, :V0HSEG-DTMOVTO, :V0HSEG-DTREABI:VIND-DTREABI FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NUM_ITEM = :V0SEGV-NUMITEM AND OCORR_HISTORICO = :V0SEGV-OCORHIST END-EXEC. */

            var r070_SELECT_HISTSEGVG_DB_SELECT_1_Query1 = new R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGV_OCORHIST = V0SEGV_OCORHIST.ToString(),
                V0SEGV_NUMITEM = V0SEGV_NUMITEM.ToString(),
            };

            var executed_1 = R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1.Execute(r070_SELECT_HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSEG_CODOPER, V0HSEG_CODOPER);
                _.Move(executed_1.V0HSEG_DTMOVTO, V0HSEG_DTMOVTO);
                _.Move(executed_1.V0HSEG_DTREABI, V0HSEG_DTREABI);
                _.Move(executed_1.VIND_DTREABI, VIND_DTREABI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/

        [StopWatch]
        /*" R080-PROCESSA-COB-SAF-SECTION */
        private void R080_PROCESSA_COB_SAF_SECTION()
        {
            /*" -648- MOVE ' ' TO V0SAFC-SEMSAF. */
            _.Move(" ", V0SAFC_SEMSAF);

            /*" -650- PERFORM R090-SELECT-SAFCOBER */

            R090_SELECT_SAFCOBER_SECTION();

            /*" -651- IF V0SAFC-SEMSAF = ' ' */

            if (V0SAFC_SEMSAF == " ")
            {

                /*" -651- PERFORM R100-ATUALIZA-REPASSE-SAF. */

                R100_ATUALIZA_REPASSE_SAF_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/

        [StopWatch]
        /*" R090-SELECT-SAFCOBER-SECTION */
        private void R090_SELECT_SAFCOBER_SECTION()
        {
            /*" -663- MOVE 'SELECT R090-SAFCOBER   ' TO PARAGRAFO. */
            _.Move("SELECT R090-SAFCOBER   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -674- PERFORM R090_SELECT_SAFCOBER_DB_SELECT_1 */

            R090_SELECT_SAFCOBER_DB_SELECT_1();

            /*" -677- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -678- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -679- MOVE 'S' TO V0SAFC-SEMSAF */
                    _.Move("S", V0SAFC_SEMSAF);

                    /*" -680- GO TO R090-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R090_EXIT*/ //GOTO
                    return;

                    /*" -681- ELSE */
                }
                else
                {


                    /*" -682- DISPLAY 'R090 - PROBLEMAS ACESSO A V0SAFCOBER' */
                    _.Display($"R090 - PROBLEMAS ACESSO A V0SAFCOBER");

                    /*" -683- DISPLAY 'CERTIFICADO  ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO  {V0PROP_NRCERTIF}");

                    /*" -684- DISPLAY 'COD.CLIENTE  ' V0PROP-CODCLIEN */
                    _.Display($"COD.CLIENTE  {V0PROP_CODCLIEN}");

                    /*" -685- DISPLAY 'SQLCODE      ' SQLCODE */
                    _.Display($"SQLCODE      {DB.SQLCODE}");

                    /*" -687- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -688- ADD 1 TO V0SAFC-OCORHIST AC-L-SAFCOBER. */
            V0SAFC_OCORHIST.Value = V0SAFC_OCORHIST + 1;
            AC_L_SAFCOBER.Value = AC_L_SAFCOBER + 1;

        }

        [StopWatch]
        /*" R090-SELECT-SAFCOBER-DB-SELECT-1 */
        public void R090_SELECT_SAFCOBER_DB_SELECT_1()
        {
            /*" -674- EXEC SQL SELECT DTTERVIG, OCORHIST, NRCERTIF INTO :V0SAFC-DTTERVIG, :V0SAFC-OCORHIST, :V0SAFC-NRCERTIF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTINIVIG <= :V0SIST-DTMOVABE AND DTTERVIG >= :V0SIST-DTMOVABE END-EXEC. */

            var r090_SELECT_SAFCOBER_DB_SELECT_1_Query1 = new R090_SELECT_SAFCOBER_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R090_SELECT_SAFCOBER_DB_SELECT_1_Query1.Execute(r090_SELECT_SAFCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_DTTERVIG, V0SAFC_DTTERVIG);
                _.Move(executed_1.V0SAFC_OCORHIST, V0SAFC_OCORHIST);
                _.Move(executed_1.V0SAFC_NRCERTIF, V0SAFC_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R090_EXIT*/

        [StopWatch]
        /*" R100-ATUALIZA-REPASSE-SAF-SECTION */
        private void R100_ATUALIZA_REPASSE_SAF_SECTION()
        {
            /*" -701- MOVE ZEROS TO V0HSAF-CODOPER. */
            _.Move(0, V0HSAF_CODOPER);

            /*" -703- MOVE 'NAO' TO WS-HOUVE-REABI. */
            _.Move("NAO", WS_HOUVE_REABI);

            /*" -705- MOVE WDATA-INIVIG TO V0SAFC-DTINIVIG. */
            _.Move(WDATA_INIVIG, V0SAFC_DTINIVIG);

            /*" -706- IF V0PROP-SITUACAO = '4' */

            if (V0PROP_SITUACAO == "4")
            {

                /*" -707- IF V0SEGV-SITUACAO = '2' OR '9' */

                if (V0SEGV_SITUACAO.In("2", "9"))
                {

                    /*" -709- IF V0HSEG-CODOPER > 399 AND V0HSEG-CODOPER < 500 */

                    if (V0HSEG_CODOPER > 399 && V0HSEG_CODOPER < 500)
                    {

                        /*" -711- IF V0SAFC-DTTERVIG EQUAL ( '1999-12-31' OR '9999-12-31' ) */

                        if (V0SAFC_DTTERVIG.In("1999-12-31", "9999-12-31"))
                        {

                            /*" -712- ADD 1 TO AC-C-HISTREPSAF */
                            AC_C_HISTREPSAF.Value = AC_C_HISTREPSAF + 1;

                            /*" -713- MOVE V0HSEG-CODOPER TO V0HSAF-CODOPER */
                            _.Move(V0HSEG_CODOPER, V0HSAF_CODOPER);

                            /*" -714- MOVE V0HSEG-DTMOVTO TO V0HSAF-DTMOVTO */
                            _.Move(V0HSEG_DTMOVTO, V0HSAF_DTMOVTO);

                            /*" -715- IF V0SAFC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                            if (V0SAFC_NRCERTIF == V0PROP_NRCERTIF)
                            {

                                /*" -717- GO TO R100-CANCELA-REPASSE-SAF. */

                                R100_CANCELA_REPASSE_SAF(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -718- IF V0PROP-SITUACAO = '3' */

            if (V0PROP_SITUACAO == "3")
            {

                /*" -719- IF V0SEGV-SITUACAO = '2' OR '9' */

                if (V0SEGV_SITUACAO.In("2", "9"))
                {

                    /*" -721- IF V0SAFC-DTTERVIG EQUAL ( '1999-12-31' OR '9999-12-31' ) */

                    if (V0SAFC_DTTERVIG.In("1999-12-31", "9999-12-31"))
                    {

                        /*" -725- DISPLAY ' SITUACOES *** ' ' SEGV-SITU ' V0SEGV-SITUACAO ' PROP-SITU ' V0PROP-SITUACAO ' CERTIFICA ' V0PROP-NRCERTIF */

                        $" SITUACOES ***  SEGV-SITU {V0SEGV_SITUACAO} PROP-SITU {V0PROP_SITUACAO} CERTIFICA {V0PROP_NRCERTIF}"
                        .Display();

                        /*" -727- IF V0HSEG-CODOPER > 399 AND V0HSEG-CODOPER < 500 */

                        if (V0HSEG_CODOPER > 399 && V0HSEG_CODOPER < 500)
                        {

                            /*" -728- ADD 1 TO AC-C-HISTREPSAF */
                            AC_C_HISTREPSAF.Value = AC_C_HISTREPSAF + 1;

                            /*" -729- MOVE V0HSEG-CODOPER TO V0HSAF-CODOPER */
                            _.Move(V0HSEG_CODOPER, V0HSAF_CODOPER);

                            /*" -730- MOVE V0HSEG-DTMOVTO TO V0HSAF-DTMOVTO */
                            _.Move(V0HSEG_DTMOVTO, V0HSAF_DTMOVTO);

                            /*" -731- IF V0SAFC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                            if (V0SAFC_NRCERTIF == V0PROP_NRCERTIF)
                            {

                                /*" -732- GO TO R100-CANCELA-REPASSE-SAF */

                                R100_CANCELA_REPASSE_SAF(); //GOTO
                                return;

                                /*" -734- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -735- ELSE */
                            }

                        }
                        else
                        {


                            /*" -736- MOVE 400 TO V0HSAF-CODOPER */
                            _.Move(400, V0HSAF_CODOPER);

                            /*" -737- MOVE V0HSEG-DTMOVTO TO V0HSAF-DTMOVTO */
                            _.Move(V0HSEG_DTMOVTO, V0HSAF_DTMOVTO);

                            /*" -738- IF V0SAFC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                            if (V0SAFC_NRCERTIF == V0PROP_NRCERTIF)
                            {

                                /*" -740- GO TO R100-CANCELA-REPASSE-SAF. */

                                R100_CANCELA_REPASSE_SAF(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -741- IF V0PROP-SITUACAO = '3' */

            if (V0PROP_SITUACAO == "3")
            {

                /*" -742- IF V0SEGV-SITUACAO = '0' OR '1' */

                if (V0SEGV_SITUACAO.In("0", "1"))
                {

                    /*" -746- IF V0HSEG-CODOPER > 499 AND V0HSEG-CODOPER < 600 AND V0SAFC-DTTERVIG NOT EQUAL ( '1999-12-31' AND '9999-12-31' ) */

                    if (V0HSEG_CODOPER > 499 && V0HSEG_CODOPER < 600 && !V0SAFC_DTTERVIG.In("1999-12-31", "9999-12-31"))
                    {

                        /*" -747- ADD 1 TO AC-R-HISTREPSAF */
                        AC_R_HISTREPSAF.Value = AC_R_HISTREPSAF + 1;

                        /*" -748- MOVE V0HSEG-CODOPER TO V0HSAF-CODOPER */
                        _.Move(V0HSEG_CODOPER, V0HSAF_CODOPER);

                        /*" -749- MOVE V0HSEG-DTMOVTO TO V0HSAF-DTMOVTO */
                        _.Move(V0HSEG_DTMOVTO, V0HSAF_DTMOVTO);

                        /*" -750- IF V0SAFC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                        if (V0SAFC_NRCERTIF == V0PROP_NRCERTIF)
                        {

                            /*" -752- GO TO R100-REABILITA-REPASSE. */

                            R100_REABILITA_REPASSE(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -753- IF V0HSAF-CODOPER = 0 */

            if (V0HSAF_CODOPER == 0)
            {

                /*" -757- DISPLAY ' INCONSISTENCIA DE SITUACOES *** ' ' SEGV-SITU ' V0SEGV-SITUACAO ' PROP-SITU ' V0PROP-SITUACAO ' CERTIFICA ' V0PROP-NRCERTIF */

                $" INCONSISTENCIA DE SITUACOES ***  SEGV-SITU {V0SEGV_SITUACAO} PROP-SITU {V0PROP_SITUACAO} CERTIFICA {V0PROP_NRCERTIF}"
                .Display();

                /*" -760- GO TO R100-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/ //GOTO
                return;
            }


            /*" -760- GO TO R100-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R100-CANCELA-REPASSE-SAF */
        private void R100_CANCELA_REPASSE_SAF(bool isPerform = false)
        {
            /*" -766- MOVE 'R100-CANCELA-REPASSE-SAF' TO PARAGRAFO. */
            _.Move("R100-CANCELA-REPASSE-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -776- PERFORM R100_CANCELA_REPASSE_SAF_DB_UPDATE_1 */

            R100_CANCELA_REPASSE_SAF_DB_UPDATE_1();

            /*" -779- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -783- DISPLAY 'PROBLEMA UPDATE DA V0SAFCOBER ....' V0PROP-NRCERTIF ' ' V0SAFC-DTINIVIG ' ' V0PROP-CODCLIEN ' ' SQLCODE */

                $"PROBLEMA UPDATE DA V0SAFCOBER ....{V0PROP_NRCERTIF} {V0SAFC_DTINIVIG} {V0PROP_CODCLIEN} {DB.SQLCODE}"
                .Display();

                /*" -786- GO TO R100-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/ //GOTO
                return;
            }


            /*" -792- PERFORM R100_CANCELA_REPASSE_SAF_DB_UPDATE_2 */

            R100_CANCELA_REPASSE_SAF_DB_UPDATE_2();

            /*" -795- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -799- DISPLAY 'PROBLEMA UPDATE2 DA V0SAFCOBER ....' V0PROP-NRCERTIF ' ' V0SAFC-DTINIVIG ' ' V0PROP-CODCLIEN ' ' SQLCODE */

                $"PROBLEMA UPDATE2 DA V0SAFCOBER ....{V0PROP_NRCERTIF} {V0SAFC_DTINIVIG} {V0PROP_CODCLIEN} {DB.SQLCODE}"
                .Display();

                /*" -801- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -803- ADD 1 TO AC-C-SAFCOBER. */
            AC_C_SAFCOBER.Value = AC_C_SAFCOBER + 1;

            /*" -803- GO TO R100-INCLUI-HISTREPSAF. */

            R100_INCLUI_HISTREPSAF(); //GOTO
            return;

        }

        [StopWatch]
        /*" R100-CANCELA-REPASSE-SAF-DB-UPDATE-1 */
        public void R100_CANCELA_REPASSE_SAF_DB_UPDATE_1()
        {
            /*" -776- EXEC SQL UPDATE SEGUROS.V0SAFCOBER SET DTTERVIG = :V0SAFC-DTINIVIG, NRCERTIF = :V0PROP-NRCERTIF, CODUSU = 'VA5421B' , OCORHIST = :V0SAFC-OCORHIST, SITUACA = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r100_CANCELA_REPASSE_SAF_DB_UPDATE_1_Update1 = new R100_CANCELA_REPASSE_SAF_DB_UPDATE_1_Update1()
            {
                V0SAFC_DTINIVIG = V0SAFC_DTINIVIG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SAFC_OCORHIST = V0SAFC_OCORHIST.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R100_CANCELA_REPASSE_SAF_DB_UPDATE_1_Update1.Execute(r100_CANCELA_REPASSE_SAF_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R100-REABILITA-REPASSE */
        private void R100_REABILITA_REPASSE(bool isPerform = false)
        {
            /*" -809- MOVE 'R100-REABILITA-REPASSE ' TO PARAGRAFO. */
            _.Move("R100-REABILITA-REPASSE ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -821- PERFORM R100_REABILITA_REPASSE_DB_INSERT_1 */

            R100_REABILITA_REPASSE_DB_INSERT_1();

            /*" -824- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -827- DISPLAY 'PROBLEMA INSERT DA V0SAFCOBER ....' V0PROP-NRCERTIF ' ' V0PROP-CODCLIEN ' ' SQLCODE */

                $"PROBLEMA INSERT DA V0SAFCOBER ....{V0PROP_NRCERTIF} {V0PROP_CODCLIEN} {DB.SQLCODE}"
                .Display();

                /*" -830- DISPLAY 'R100-REABILITA-REPASSE ....' . */
                _.Display($"R100-REABILITA-REPASSE ....");
            }


            /*" -832- ADD 1 TO AC-R-SAFCOBER. */
            AC_R_SAFCOBER.Value = AC_R_SAFCOBER + 1;

            /*" -848- PERFORM R100_REABILITA_REPASSE_DB_INSERT_2 */

            R100_REABILITA_REPASSE_DB_INSERT_2();

            /*" -851- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -857- DISPLAY 'PROBL. INSERT REAB V0HISTREPSAF...' ' OPERACAO  ' V0HSAF-CODOPER ' CERTIF    ' V0PROP-NRCERTIF ' CODCLI    ' V0PROP-CODCLIEN ' DTINIVIG  ' V0SAFC-DTINIVIG ' SQLCODE   ' SQLCODE */

                $"PROBL. INSERT REAB V0HISTREPSAF... OPERACAO  {V0HSAF_CODOPER} CERTIF    {V0PROP_NRCERTIF} CODCLI    {V0PROP_CODCLIEN} DTINIVIG  {V0SAFC_DTINIVIG} SQLCODE   {DB.SQLCODE}"
                .Display();

                /*" -859- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -860- ADD 1 TO AC-R-HISTREPSAF. */
            AC_R_HISTREPSAF.Value = AC_R_HISTREPSAF + 1;

            /*" -862- ADD 1 TO AC-I-HISTREPSAF. */
            AC_I_HISTREPSAF.Value = AC_I_HISTREPSAF + 1;

            /*" -864- MOVE 1100 TO V0HSAF-CODOPER. */
            _.Move(1100, V0HSAF_CODOPER);

            /*" -864- MOVE 'SIM' TO WS-HOUVE-REABI. */
            _.Move("SIM", WS_HOUVE_REABI);

        }

        [StopWatch]
        /*" R100-REABILITA-REPASSE-DB-INSERT-1 */
        public void R100_REABILITA_REPASSE_DB_INSERT_1()
        {
            /*" -821- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0SAFC-DTINIVIG, '9999-12-31' , :V0COBV-IMPSEGAUXF, :V0COBV-VLCUSTAUXF, :V0PROP-NRCERTIF, :V0SAFC-OCORHIST, '0' , 'VA5421B' , CURRENT TIMESTAMP) END-EXEC. */

            var r100_REABILITA_REPASSE_DB_INSERT_1_Insert1 = new R100_REABILITA_REPASSE_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0SAFC_DTINIVIG = V0SAFC_DTINIVIG.ToString(),
                V0COBV_IMPSEGAUXF = V0COBV_IMPSEGAUXF.ToString(),
                V0COBV_VLCUSTAUXF = V0COBV_VLCUSTAUXF.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SAFC_OCORHIST = V0SAFC_OCORHIST.ToString(),
            };

            R100_REABILITA_REPASSE_DB_INSERT_1_Insert1.Execute(r100_REABILITA_REPASSE_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R100-CANCELA-REPASSE-SAF-DB-UPDATE-2 */
        public void R100_CANCELA_REPASSE_SAF_DB_UPDATE_2()
        {
            /*" -792- EXEC SQL UPDATE SEGUROS.V0SAFCOBER SET DTTERVIG = DTTERVIG - 1 DAY, CODUSU = 'VA5421B' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODCLIEN = :V0PROP-CODCLIEN END-EXEC. */

            var r100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1 = new R100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1.Execute(r100_CANCELA_REPASSE_SAF_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R100-REABILITA-REPASSE-DB-INSERT-2 */
        public void R100_REABILITA_REPASSE_DB_INSERT_2()
        {
            /*" -848- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0SAFC-DTINIVIG, :V0PROP-NRCERTIF, :V0SAFC-OCORHIST, :V0PROP-NUM-MATRICULA, :V0COBV-VLCUSTAUXF, :V0HSAF-CODOPER, '0' , '0' , 000, 000, 'VA5421B' , CURRENT TIMESTAMP, :V0SAFC-DTINIVIG:VIND-DTMOVTO) END-EXEC. */

            var r100_REABILITA_REPASSE_DB_INSERT_2_Insert1 = new R100_REABILITA_REPASSE_DB_INSERT_2_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0SAFC_DTINIVIG = V0SAFC_DTINIVIG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SAFC_OCORHIST = V0SAFC_OCORHIST.ToString(),
                V0PROP_NUM_MATRICULA = V0PROP_NUM_MATRICULA.ToString(),
                V0COBV_VLCUSTAUXF = V0COBV_VLCUSTAUXF.ToString(),
                V0HSAF_CODOPER = V0HSAF_CODOPER.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R100_REABILITA_REPASSE_DB_INSERT_2_Insert1.Execute(r100_REABILITA_REPASSE_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R100-INCLUI-HISTREPSAF */
        private void R100_INCLUI_HISTREPSAF(bool isPerform = false)
        {
            /*" -870- MOVE 'R100-INCLUI-REPASSE   ' TO PARAGRAFO. */
            _.Move("R100-INCLUI-REPASSE   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -886- PERFORM R100_INCLUI_HISTREPSAF_DB_INSERT_1 */

            R100_INCLUI_HISTREPSAF_DB_INSERT_1();

            /*" -889- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -890- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -891- GO TO R100-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/ //GOTO
                    return;

                    /*" -892- ELSE */
                }
                else
                {


                    /*" -898- DISPLAY 'PROBLEMA INSERT DA V0HISTREPSAF...' ' OPERACAO  ' V0HSAF-CODOPER ' CERTIF    ' V0PROP-NRCERTIF ' CODCLI    ' V0PROP-CODCLIEN ' DTINIVIG  ' V0SAFC-DTINIVIG ' SQLCODE   ' SQLCODE */

                    $"PROBLEMA INSERT DA V0HISTREPSAF... OPERACAO  {V0HSAF_CODOPER} CERTIF    {V0PROP_NRCERTIF} CODCLI    {V0PROP_CODCLIEN} DTINIVIG  {V0SAFC_DTINIVIG} SQLCODE   {DB.SQLCODE}"
                    .Display();

                    /*" -900- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -902- ADD 1 TO AC-I-HISTREPSAF. */
            AC_I_HISTREPSAF.Value = AC_I_HISTREPSAF + 1;

            /*" -906- PERFORM R100_INCLUI_HISTREPSAF_DB_UPDATE_1 */

            R100_INCLUI_HISTREPSAF_DB_UPDATE_1();

            /*" -909- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -910- DISPLAY 'PROBLEMA UPDATE DA  V0SAFCOBER ....  ' */
                _.Display($"PROBLEMA UPDATE DA  V0SAFCOBER ....  ");

                /*" -911- DISPLAY 'UPDATE DO OCORHIST  -  SQLCODE ....  ' SQLCODE */
                _.Display($"UPDATE DO OCORHIST  -  SQLCODE ....  {DB.SQLCODE}");

                /*" -912- DISPLAY 'CODCLIEN        ' V0PROP-CODCLIEN */
                _.Display($"CODCLIEN        {V0PROP_CODCLIEN}");

                /*" -913- DISPLAY 'DTINIVIG        ' V0SAFC-DTINIVIG */
                _.Display($"DTINIVIG        {V0SAFC_DTINIVIG}");

                /*" -914- DISPLAY 'NRCERTIF        ' V0PROP-NRCERTIF */
                _.Display($"NRCERTIF        {V0PROP_NRCERTIF}");

                /*" -914- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R100-INCLUI-HISTREPSAF-DB-INSERT-1 */
        public void R100_INCLUI_HISTREPSAF_DB_INSERT_1()
        {
            /*" -886- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0SAFC-DTINIVIG, :V0PROP-NRCERTIF, :V0SAFC-OCORHIST, :V0PROP-NUM-MATRICULA, :V0COBV-VLCUSTAUXF, :V0HSAF-CODOPER, '0' , '0' , 000, 000, 'VA5421B' , CURRENT TIMESTAMP, :V0HSAF-DTMOVTO:VIND-DTMOVTO) END-EXEC. */

            var r100_INCLUI_HISTREPSAF_DB_INSERT_1_Insert1 = new R100_INCLUI_HISTREPSAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0SAFC_DTINIVIG = V0SAFC_DTINIVIG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SAFC_OCORHIST = V0SAFC_OCORHIST.ToString(),
                V0PROP_NUM_MATRICULA = V0PROP_NUM_MATRICULA.ToString(),
                V0COBV_VLCUSTAUXF = V0COBV_VLCUSTAUXF.ToString(),
                V0HSAF_CODOPER = V0HSAF_CODOPER.ToString(),
                V0HSAF_DTMOVTO = V0HSAF_DTMOVTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R100_INCLUI_HISTREPSAF_DB_INSERT_1_Insert1.Execute(r100_INCLUI_HISTREPSAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R100-INCLUI-HISTREPSAF-DB-UPDATE-1 */
        public void R100_INCLUI_HISTREPSAF_DB_UPDATE_1()
        {
            /*" -906- EXEC SQL UPDATE SEGUROS.V0SAFCOBER SET OCORHIST = :V0SAFC-OCORHIST WHERE CODCLIEN = :V0PROP-CODCLIEN END-EXEC. */

            var r100_INCLUI_HISTREPSAF_DB_UPDATE_1_Update1 = new R100_INCLUI_HISTREPSAF_DB_UPDATE_1_Update1()
            {
                V0SAFC_OCORHIST = V0SAFC_OCORHIST.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R100_INCLUI_HISTREPSAF_DB_UPDATE_1_Update1.Execute(r100_INCLUI_HISTREPSAF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-PROCESSA-COB-CDG-SECTION */
        private void R110_PROCESSA_COB_CDG_SECTION()
        {
            /*" -929- MOVE WDATA-INIVIG TO V0CDGC-DTINIVIG. */
            _.Move(WDATA_INIVIG, V0CDGC_DTINIVIG);

            /*" -931- PERFORM R120-SELECT-CDGCOBER. */

            R120_SELECT_CDGCOBER_SECTION();

            /*" -932- IF V0HSAF-CODOPER EQUAL 1100 */

            if (V0HSAF_CODOPER == 1100)
            {

                /*" -933- IF WS-HOUVE-REABI EQUAL 'NAO' */

                if (WS_HOUVE_REABI == "NAO")
                {

                    /*" -934- PERFORM R130-GERA-REPASSE-CDG */

                    R130_GERA_REPASSE_CDG_SECTION();

                    /*" -935- ELSE */
                }
                else
                {


                    /*" -936- IF V0CDGC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                    if (V0CDGC_NRCERTIF == V0PROP_NRCERTIF)
                    {

                        /*" -937- PERFORM R150-REABI-VIG-CDG */

                        R150_REABI_VIG_CDG_SECTION();

                        /*" -939- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -940- ELSE */
                    }

                }

            }
            else
            {


                /*" -942- IF (V0HSAF-CODOPER > 399 AND V0HSAF-CODOPER < 500) */

                if ((V0HSAF_CODOPER > 399 && V0HSAF_CODOPER < 500))
                {

                    /*" -943- IF V0CDGC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                    if (V0CDGC_NRCERTIF == V0PROP_NRCERTIF)
                    {

                        /*" -944- PERFORM R140-ENCERRA-VIG-CDG */

                        R140_ENCERRA_VIG_CDG_SECTION();

                        /*" -946- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -947- ELSE */
                    }

                }
                else
                {


                    /*" -949- IF (V0HSAF-CODOPER > 499 AND V0HSAF-CODOPER < 600) */

                    if ((V0HSAF_CODOPER > 499 && V0HSAF_CODOPER < 600))
                    {

                        /*" -950- IF V0CDGC-NRCERTIF EQUAL V0PROP-NRCERTIF */

                        if (V0CDGC_NRCERTIF == V0PROP_NRCERTIF)
                        {

                            /*" -951- PERFORM R150-REABI-VIG-CDG */

                            R150_REABI_VIG_CDG_SECTION();

                            /*" -953- ELSE NEXT SENTENCE */
                        }
                        else
                        {


                            /*" -954- ELSE */
                        }

                    }
                    else
                    {


                        /*" -954- ADD 1 TO AC-D-CDG. */
                        AC_D_CDG.Value = AC_D_CDG + 1;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-SELECT-CDGCOBER-SECTION */
        private void R120_SELECT_CDGCOBER_SECTION()
        {
            /*" -966- MOVE 'SELECT R120-CDGCOBER   ' TO PARAGRAFO. */
            _.Move("SELECT R120-CDGCOBER   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -975- PERFORM R120_SELECT_CDGCOBER_DB_SELECT_1 */

            R120_SELECT_CDGCOBER_DB_SELECT_1();

            /*" -978- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -979- DISPLAY 'R120 - PROBLEMAS ACESSO A V0CDGCOBER' */
                _.Display($"R120 - PROBLEMAS ACESSO A V0CDGCOBER");

                /*" -980- DISPLAY 'NRCERTIF    ' V0PROP-NRCERTIF */
                _.Display($"NRCERTIF    {V0PROP_NRCERTIF}");

                /*" -981- DISPLAY 'CODCLIEN    ' V0PROP-CODCLIEN */
                _.Display($"CODCLIEN    {V0PROP_CODCLIEN}");

                /*" -982- DISPLAY 'SQLCODE     ' SQLCODE */
                _.Display($"SQLCODE     {DB.SQLCODE}");

                /*" -984- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -984- ADD 1 TO AC-L-CDGCOBER. */
            AC_L_CDGCOBER.Value = AC_L_CDGCOBER + 1;

        }

        [StopWatch]
        /*" R120-SELECT-CDGCOBER-DB-SELECT-1 */
        public void R120_SELECT_CDGCOBER_DB_SELECT_1()
        {
            /*" -975- EXEC SQL SELECT DTTERVIG, OCORHIST, NRCERTIF INTO :V0CDGC-DTTERVIG, :V0CDGC-OCORHIST, :V0CDGC-NRCERTIF FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN END-EXEC. */

            var r120_SELECT_CDGCOBER_DB_SELECT_1_Query1 = new R120_SELECT_CDGCOBER_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R120_SELECT_CDGCOBER_DB_SELECT_1_Query1.Execute(r120_SELECT_CDGCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_DTTERVIG, V0CDGC_DTTERVIG);
                _.Move(executed_1.V0CDGC_OCORHIST, V0CDGC_OCORHIST);
                _.Move(executed_1.V0CDGC_NRCERTIF, V0CDGC_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-GERA-REPASSE-CDG-SECTION */
        private void R130_GERA_REPASSE_CDG_SECTION()
        {
            /*" -997- MOVE 'R130-GERA-REPASSE-CDG' TO PARAGRAFO. */
            _.Move("R130-GERA-REPASSE-CDG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -999- ADD 1 TO V0CDGC-OCORHIST. */
            V0CDGC_OCORHIST.Value = V0CDGC_OCORHIST + 1;

            /*" -1009- PERFORM R130_GERA_REPASSE_CDG_DB_INSERT_1 */

            R130_GERA_REPASSE_CDG_DB_INSERT_1();

            /*" -1012- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1013- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1014- GO TO R130-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/ //GOTO
                    return;

                    /*" -1015- ELSE */
                }
                else
                {


                    /*" -1016- DISPLAY 'PROBLEMA INSERT DA V0REPASSECDG...' */
                    _.Display($"PROBLEMA INSERT DA V0REPASSECDG...");

                    /*" -1017- DISPLAY ' CERTIF    ' V0PROP-NRCERTIF */
                    _.Display($" CERTIF    {V0PROP_NRCERTIF}");

                    /*" -1018- DISPLAY ' CODCLI    ' V0PROP-CODCLIEN */
                    _.Display($" CODCLI    {V0PROP_CODCLIEN}");

                    /*" -1019- DISPLAY ' DTINIVIG  ' V0CDGC-DTINIVIG */
                    _.Display($" DTINIVIG  {V0CDGC_DTINIVIG}");

                    /*" -1020- DISPLAY ' SQLCODE   ' SQLCODE */
                    _.Display($" SQLCODE   {DB.SQLCODE}");

                    /*" -1022- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1024- ADD 1 TO AC-I-REPASSECDG. */
            AC_I_REPASSECDG.Value = AC_I_REPASSECDG + 1;

            /*" -1029- PERFORM R130_GERA_REPASSE_CDG_DB_UPDATE_1 */

            R130_GERA_REPASSE_CDG_DB_UPDATE_1();

            /*" -1032- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1033- DISPLAY 'PROBLEMA UPDATE DA  V0CDGCOBER.....  ' */
                _.Display($"PROBLEMA UPDATE DA  V0CDGCOBER.....  ");

                /*" -1034- DISPLAY ' CERTIF    ' V0PROP-NRCERTIF */
                _.Display($" CERTIF    {V0PROP_NRCERTIF}");

                /*" -1035- DISPLAY ' CODCLI    ' V0PROP-CODCLIEN */
                _.Display($" CODCLI    {V0PROP_CODCLIEN}");

                /*" -1036- DISPLAY ' DTINIVIG  ' V0CDGC-DTINIVIG */
                _.Display($" DTINIVIG  {V0CDGC_DTINIVIG}");

                /*" -1037- DISPLAY ' SQLCODE   ' SQLCODE */
                _.Display($" SQLCODE   {DB.SQLCODE}");

                /*" -1037- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R130-GERA-REPASSE-CDG-DB-INSERT-1 */
        public void R130_GERA_REPASSE_CDG_DB_INSERT_1()
        {
            /*" -1009- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0CDGC-DTINIVIG, :V0COBV-VLCUSTCDG, :V0PROP-NRCERTIF, :V0CDGC-OCORHIST, '0' , :V0HSAF-DTMOVTO:VIND-DTMOVTO, CURRENT TIMESTAMP) END-EXEC. */

            var r130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1 = new R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0CDGC_DTINIVIG = V0CDGC_DTINIVIG.ToString(),
                V0COBV_VLCUSTCDG = V0COBV_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0CDGC_OCORHIST = V0CDGC_OCORHIST.ToString(),
                V0HSAF_DTMOVTO = V0HSAF_DTMOVTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1.Execute(r130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R130-GERA-REPASSE-CDG-DB-UPDATE-1 */
        public void R130_GERA_REPASSE_CDG_DB_UPDATE_1()
        {
            /*" -1029- EXEC SQL UPDATE SEGUROS.V0CDGCOBER SET OCORHIST = :V0CDGC-OCORHIST WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '9999-12-31' , '1999-12-31' ) END-EXEC. */

            var r130_GERA_REPASSE_CDG_DB_UPDATE_1_Update1 = new R130_GERA_REPASSE_CDG_DB_UPDATE_1_Update1()
            {
                V0CDGC_OCORHIST = V0CDGC_OCORHIST.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R130_GERA_REPASSE_CDG_DB_UPDATE_1_Update1.Execute(r130_GERA_REPASSE_CDG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R140-ENCERRA-VIG-CDG-SECTION */
        private void R140_ENCERRA_VIG_CDG_SECTION()
        {
            /*" -1049- MOVE 'R140-ENCERA-VIG-CDG ' TO PARAGRAFO. */
            _.Move("R140-ENCERA-VIG-CDG ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1058- PERFORM R140_ENCERRA_VIG_CDG_DB_UPDATE_1 */

            R140_ENCERRA_VIG_CDG_DB_UPDATE_1();

            /*" -1061- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1065- DISPLAY 'PROBLEMA UPDATE DA V0CDGCOBER ....' V0PROP-NRCERTIF ' ' V0CDGC-DTINICDG ' ' V0PROP-CODCLIEN ' ' SQLCODE */

                $"PROBLEMA UPDATE DA V0CDGCOBER ....{V0PROP_NRCERTIF} {V0CDGC_DTINICDG} {V0PROP_CODCLIEN} {DB.SQLCODE}"
                .Display();

                /*" -1067- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1072- PERFORM R140_ENCERRA_VIG_CDG_DB_UPDATE_2 */

            R140_ENCERRA_VIG_CDG_DB_UPDATE_2();

            /*" -1075- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1078- DISPLAY 'PROBLEMA UPDATE2 DA V0CDGCOBER ....' V0PROP-CODCLIEN ' ' V0CDGC-DTINICDG ' ' SQLCODE */

                $"PROBLEMA UPDATE2 DA V0CDGCOBER ....{V0PROP_CODCLIEN} {V0CDGC_DTINICDG} {DB.SQLCODE}"
                .Display();

                /*" -1080- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1080- ADD 1 TO AC-C-CDGCOBER. */
            AC_C_CDGCOBER.Value = AC_C_CDGCOBER + 1;

        }

        [StopWatch]
        /*" R140-ENCERRA-VIG-CDG-DB-UPDATE-1 */
        public void R140_ENCERRA_VIG_CDG_DB_UPDATE_1()
        {
            /*" -1058- EXEC SQL UPDATE SEGUROS.V0CDGCOBER SET DTTERVIG = :V0CDGC-DTINIVIG, NRCERTIF = :V0PROP-NRCERTIF, CODUSU = 'VA5421B' , SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r140_ENCERRA_VIG_CDG_DB_UPDATE_1_Update1 = new R140_ENCERRA_VIG_CDG_DB_UPDATE_1_Update1()
            {
                V0CDGC_DTINIVIG = V0CDGC_DTINIVIG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R140_ENCERRA_VIG_CDG_DB_UPDATE_1_Update1.Execute(r140_ENCERRA_VIG_CDG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/

        [StopWatch]
        /*" R140-ENCERRA-VIG-CDG-DB-UPDATE-2 */
        public void R140_ENCERRA_VIG_CDG_DB_UPDATE_2()
        {
            /*" -1072- EXEC SQL UPDATE SEGUROS.V0CDGCOBER SET DTTERVIG = DTTERVIG - 1 DAY, TIMESTAMP = CURRENT TIMESTAMP WHERE CODCLIEN = :V0PROP-CODCLIEN END-EXEC. */

            var r140_ENCERRA_VIG_CDG_DB_UPDATE_2_Update1 = new R140_ENCERRA_VIG_CDG_DB_UPDATE_2_Update1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R140_ENCERRA_VIG_CDG_DB_UPDATE_2_Update1.Execute(r140_ENCERRA_VIG_CDG_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R150-REABI-VIG-CDG-SECTION */
        private void R150_REABI_VIG_CDG_SECTION()
        {
            /*" -1092- MOVE 'R150-REABI-VIG-CDG    ' TO PARAGRAFO. */
            _.Move("R150-REABI-VIG-CDG    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1104- PERFORM R150_REABI_VIG_CDG_DB_INSERT_1 */

            R150_REABI_VIG_CDG_DB_INSERT_1();

            /*" -1107- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1108- DISPLAY 'PROBLEMA INSERT DA V0CDGCOBER ....' */
                _.Display($"PROBLEMA INSERT DA V0CDGCOBER ....");

                /*" -1109- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -1110- DISPLAY 'CLIENTE     ' V0PROP-CODCLIEN */
                _.Display($"CLIENTE     {V0PROP_CODCLIEN}");

                /*" -1111- DISPLAY 'SQLCODE     ' SQLCODE */
                _.Display($"SQLCODE     {DB.SQLCODE}");

                /*" -1114- DISPLAY 'R150-REABI-VIG-CDG.........' . */
                _.Display($"R150-REABI-VIG-CDG.........");
            }


            /*" -1116- ADD 1 TO AC-R-CDGCOBER. */
            AC_R_CDGCOBER.Value = AC_R_CDGCOBER + 1;

            /*" -1116- PERFORM R130-GERA-REPASSE-CDG. */

            R130_GERA_REPASSE_CDG_SECTION();

        }

        [StopWatch]
        /*" R150-REABI-VIG-CDG-DB-INSERT-1 */
        public void R150_REABI_VIG_CDG_DB_INSERT_1()
        {
            /*" -1104- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0HSEG-DTREABI, '9999-12-31' , :V0COBV-IMPSEGCDG, :V0COBV-VLCUSTCDG, :V0PROP-NRCERTIF, :V0CDGC-OCORHIST, '0' , 'VA5421B' , CURRENT TIMESTAMP) END-EXEC. */

            var r150_REABI_VIG_CDG_DB_INSERT_1_Insert1 = new R150_REABI_VIG_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0HSEG_DTREABI = V0HSEG_DTREABI.ToString(),
                V0COBV_IMPSEGCDG = V0COBV_IMPSEGCDG.ToString(),
                V0COBV_VLCUSTCDG = V0COBV_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0CDGC_OCORHIST = V0CDGC_OCORHIST.ToString(),
            };

            R150_REABI_VIG_CDG_DB_INSERT_1_Insert1.Execute(r150_REABI_VIG_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -1132- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.FILLER_8.WSQLCODE);

            /*" -1133- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_8.WSQLERRD1);

            /*" -1134- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_8.WSQLERRD2);

            /*" -1136- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1137- DISPLAY '** VA5421B ** LIDOS PROPOVA     ' AC-L-PROPOVA */
            _.Display($"** VA5421B ** LIDOS PROPOVA     {AC_L_PROPOVA}");

            /*" -1138- DISPLAY '** VA5421B ** LIDOS COBERPROP   ' AC-L-COBERPROPVA */
            _.Display($"** VA5421B ** LIDOS COBERPROP   {AC_L_COBERPROPVA}");

            /*" -1139- DISPLAY '** VA5421B ** LIDOS SAFCOBER    ' AC-L-SAFCOBER */
            _.Display($"** VA5421B ** LIDOS SAFCOBER    {AC_L_SAFCOBER}");

            /*" -1140- DISPLAY '** VA5421B ** LIDOS CDGCOBER    ' AC-L-CDGCOBER */
            _.Display($"** VA5421B ** LIDOS CDGCOBER    {AC_L_CDGCOBER}");

            /*" -1141- DISPLAY '** VA5421B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
            _.Display($"** VA5421B ** LIDOS SEGURAVG    {AC_L_SEGURAVG}");

            /*" -1142- DISPLAY '** VA5421B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
            _.Display($"** VA5421B ** LIDOS HISTSEGVG   {AC_L_HISTSEGVG}");

            /*" -1143- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -1144- DISPLAY '** VA5421B ** INCL. HISTREPSAF  ' AC-I-HISTREPSAF */
            _.Display($"** VA5421B ** INCL. HISTREPSAF  {AC_I_HISTREPSAF}");

            /*" -1145- DISPLAY '** VA5421B ** INCL. REPASSECDG  ' AC-I-REPASSECDG */
            _.Display($"** VA5421B ** INCL. REPASSECDG  {AC_I_REPASSECDG}");

            /*" -1146- DISPLAY '** VA5421B ** AVER. HISTREPSAF  ' AC-A-HISTREPSAF */
            _.Display($"** VA5421B ** AVER. HISTREPSAF  {AC_A_HISTREPSAF}");

            /*" -1147- DISPLAY '** VA5421B ** AVER. REPASSECDG  ' AC-I-REPASSECDG */
            _.Display($"** VA5421B ** AVER. REPASSECDG  {AC_I_REPASSECDG}");

            /*" -1148- DISPLAY '** VA5421B ** CANC. SAFCOBER    ' AC-C-SAFCOBER */
            _.Display($"** VA5421B ** CANC. SAFCOBER    {AC_C_SAFCOBER}");

            /*" -1149- DISPLAY '** VA5421B ** CANC. HISTREPSAF  ' AC-C-HISTREPSAF */
            _.Display($"** VA5421B ** CANC. HISTREPSAF  {AC_C_HISTREPSAF}");

            /*" -1150- DISPLAY '** VA5421B ** CANC. CDGCOBER    ' AC-C-CDGCOBER */
            _.Display($"** VA5421B ** CANC. CDGCOBER    {AC_C_CDGCOBER}");

            /*" -1151- DISPLAY '** VA5421B ** SUSP. HISTREPSAF  ' AC-S-HISTREPSAF */
            _.Display($"** VA5421B ** SUSP. HISTREPSAF  {AC_S_HISTREPSAF}");

            /*" -1152- DISPLAY '** VA5421B ** REAB. SAFCOBER    ' AC-R-SAFCOBER */
            _.Display($"** VA5421B ** REAB. SAFCOBER    {AC_R_SAFCOBER}");

            /*" -1153- DISPLAY '** VA5421B ** REAB. HISTREPSAF  ' AC-R-HISTREPSAF */
            _.Display($"** VA5421B ** REAB. HISTREPSAF  {AC_R_HISTREPSAF}");

            /*" -1154- DISPLAY '** VA5421B ** REAB. CDGCOBER    ' AC-R-CDGCOBER */
            _.Display($"** VA5421B ** REAB. CDGCOBER    {AC_R_CDGCOBER}");

            /*" -1155- DISPLAY '** VA5421B ** DESP. REPASSECDG  ' AC-D-CDG */
            _.Display($"** VA5421B ** DESP. REPASSECDG  {AC_D_CDG}");

            /*" -1156- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -1157- DISPLAY '** VA5421B ** TERMINO ANORMAL   ' . */
            _.Display($"** VA5421B ** TERMINO ANORMAL   ");

            /*" -1159- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -1161- DISPLAY '*** VA5421B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA5421B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1161- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1164- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1165- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1165- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1169- DISPLAY '*** VA5421B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA5421B *** ERRO DE EXECUCAO");

            /*" -1170- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1170- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/
    }
}